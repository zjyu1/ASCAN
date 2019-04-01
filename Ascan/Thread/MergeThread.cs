using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Ascan
{
    public class MergeThread
    {
        /**A thread for the merge.*/
        private Thread thread;
        /**Input queue for the thread.*/
        private List<RingBufferQueue<MergeInQueueElement>> mergeInList;
        /** OutputQueue of the thread.*/
        private RingBufferQueue<MeasureQueueElement> measureQueue;

        /** ThreadHandClasp for init.*/
        private ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        private ThreadHandClasp clean;
        /** The states of the thread.*/
        private ThreadCondition status;

        public ThreadCondition Status
        {
            get
            {
                return status;
            }
        }

        private MeasureQueueElement measureQueueElement;

        public MergeThread(MergeThreadEnv tmpEnv)
        {
            init = tmpEnv.init;
            clean = tmpEnv.clean;
            status = tmpEnv.status;
            mergeInList = tmpEnv.mergeInList;
            measureQueue = tmpEnv.measureQueue;

            measureQueueElement = new MeasureQueueElement();

            thread = new Thread(mergeFunc); 
            thread.IsBackground = true;
        }

        /**Start thread.*/
        public void start()
        {
            if (status != ThreadCondition.run)
            {
                thread.Start();
                status = ThreadCondition.run;
            }
        }

        private void mergeFunc()
        {
            int dequeueResult;
            //bool isError;
            bool stop;
            bool isParseSuccess;
            int endCount;
            MergeInQueueElement outqueueElement;
            QueueData endQueue;

            //isError = false;
            stop = false;
            isParseSuccess = false;
            endCount = 0;
            outqueueElement = new MergeInQueueElement();
            endQueue = new QueueData();
            endQueue.isEnd = true;   //A queue atom represent the end of the input.

            init.handclasp_meet();

            while ((!GlobalQuit.Quit)&&(!stop))
            {
                try
                {
                   
                    for (int i = 0; i < mergeInList.Count; i++)
                    {
                        dequeueResult = mergeInList[i].DequeueWithSemaphor(ref outqueueElement, ConstParameter.TimeOutMilliSecondValue);

                        if (dequeueResult == -1)
                        {
                            StackTrace st = new StackTrace(new StackFrame(true));
                            LogHelper.WriteLog("MergeThread timed out when semaphor wait for receiving!", st);
#if USE_WARNING
                            MessageBox.Show("融合线程信号量超时，请马上设置断点检查。位置：MergeThread.mergeFunc");
#endif
                            status = ThreadCondition.error;
                            //isError = true;
                        }
                        else if (dequeueResult == 0)
                        {
                            continue;
                        }
                        else if (dequeueResult == 1)
                        {
                            //if receive the end atom of queue, just break and stop the thread.
                            if (outqueueElement.IsEnd == true)
                            {
                                endCount++;
                                if (endCount == mergeInList.Count)
                                {
                                    endCount = 0;
                                    stop = true;
                                    break;
                                }
                                else
                                    continue;
                            }

                            isParseSuccess = parsePacket(outqueueElement.setPacket, i);
                            if (!isParseSuccess)
                            {
                                StackTrace st = new StackTrace(new StackFrame(true));
                                LogHelper.WriteLog("The format of packet is wrong or MergeThread timed out when Enqueue!", st);
#if USE_WARNING
                                MessageBox.Show("融合线程获取的数据格式错误或入队失败，请马上设置断点检查。位置：MergeThread.mergeFunc");
#endif
                                status = ThreadCondition.error;
                                //isError = true;
                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    StackTrace st = new StackTrace(new StackFrame(true));
                    LogHelper.WriteLog(e, st);
#if USE_WARNING
                    MessageBox.Show("检测到异常，请马上设置断点检查。位置：MergeThread.mergeFunc");
#endif
                    status = ThreadCondition.error;
                    //isError = true;
                }
            }
            init.handclasp_force();

            measureQueueElement.IsEnd = true;
            measureQueue.Enqueue(measureQueueElement);

            clean.handclasp_meet();

            status = ThreadCondition.exit;
        }

        /**Get the datas ande enqueue.*/
        private bool parsePacket(UniSetPacket setPacket, int boardIndex)
        {
            //DEFINATION
            uint tmpId;
            bool isEnqueSuccess;

            //INIT
            tmpId = setPacket.id;
            isEnqueSuccess = false;

            //PROCESSING
            //Check start
            if (setPacket.start[0] != ConstParameter.StartLowFlag || setPacket.start[1] != ConstParameter.StartHighFlag)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("Check code of start unmatched!", st);
                return false;
            }
            //Check stop
            if (setPacket.stop[0] != ConstParameter.StopLowFlag || setPacket.stop[1] != ConstParameter.StopHighFlag)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("Check code of stop unmatched!", st);
                return false;
            }
            //Check the id
            if (!Enum.IsDefined(typeof(PacketId), (int)setPacket.id))
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("Packet ID is not defined!", st);
                return false;
            }


            if (tmpId == (uint)PacketId.none)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("Packet ID is 0!", st);
                return false;
            }
            else if (tmpId <= (uint)PacketId.CI2Gate || tmpId == (uint)PacketId.couple || tmpId == (uint)PacketId.eventId)
            {
                measureQueueElement.boardIndex = boardIndex;
                copyToMeasurement(measureQueueElement.gatePacket, setPacket);

                isEnqueSuccess = measureQueue.Enqueue(measureQueueElement);
                if (!isEnqueSuccess)
                    return false;
            }
            else if (tmpId == (uint)PacketId.alarmDisp)
            {
                //Alarm
                return true;
            }
            else
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("Packet ID is large than 256!", st);
                return false;
            }
            return isEnqueSuccess;
        }

         /**Copy the datas to the queue of measurement.*/
        private void copyToMeasurement(GatePacket gatePacket, UniSetPacket setPacket)
        {
            //DEFINATION
            ItemHeader head;
            UploadTagHeader tag;

            //INIT
            head = gatePacket.head;
            tag = gatePacket.tag;

            //PROCESSING
            //head
            head.port = setPacket.port;
            head.id = setPacket.id;
            head.bin = setPacket.bin;
            head.size = setPacket.size; 

            //tag
            tag.stampMode = setPacket.stampMode;
            Array.Copy(setPacket.stampPos, tag.stampPos, 3);
            Array.Copy(setPacket.stampInc, tag.stampInc, 3);
            tag.cellNum = setPacket.cellNum;

            if (tag.cellNum > ConstParameter.MaxMeasureDataLength)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("Cell number is larger than max measure data length!", st);
                tag.cellNum = ConstParameter.MaxMeasureDataLength;
            }

            Array.Copy(setPacket.fd, gatePacket.measureDate, tag.cellNum);
        }
    }

    /**Merge thread environment.*/
    public class MergeThreadEnv
    {
        /** ThreadHandClasp for init.*/
        public ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        public ThreadHandClasp clean;
        /** The states of the thread.*/
        public ThreadCondition status;

        /** InputQueue of the thread.*/
        public List<RingBufferQueue<MergeInQueueElement>> mergeInList;
        /** OutputQueue of the thread.*/
        public RingBufferQueue<MeasureQueueElement> measureQueue;
    }
}