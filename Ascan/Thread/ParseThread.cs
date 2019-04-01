using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Ascan
{
    /**A class for the dispens thread and its callbackfunction.*/
    public class ParseThread
    {
        private System.Timers.Timer timer = new System.Timers.Timer(100);
        /**A thread for the parse.*/
        private Thread thread;
        /**Input queue for the thread.*/
        private RingBufferQueue<CaptureOutQueueElement> inputQueue;
        /** OutputQueue of the thread for ascan.*/
        public RingBufferQueue<AscanQueueElement> ascanQueue;
        /** OutputQueue of the thread for merge.*/
        public RingBufferQueue<MergeInQueueElement> mergeInQueue;
        /**Index of the thread.*/
        private int index;

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

        private bool isBoardStatusOK;

        public bool IsBoardStatusOK
        {
            get { return isBoardStatusOK;}
        }

        private MergeInQueueElement mergeInQueueElement;
        private AscanQueueElement ascanQueueElement;
        private BoardStatusSetPacket boardStatusPacket;

        private delegate void updateDelegate();
        private updateDelegate updateCallBack;
        private int count = 0;

        public ParseThread(ParseThreadEnv tmpEnv)
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateAscan);
            timer.AutoReset = true;

            init = tmpEnv.init;
            clean = tmpEnv.clean;
            status = tmpEnv.status;
            inputQueue = tmpEnv.captureOutQueue;
            ascanQueue = tmpEnv.ascanQueue;
            mergeInQueue = tmpEnv.mergeInQueue;

            mergeInQueueElement = new MergeInQueueElement();
            ascanQueueElement = new AscanQueueElement();
            boardStatusPacket = new BoardStatusSetPacket();

            thread = new Thread(parseFunc);
            thread.IsBackground = true;

            updateCallBack = new updateDelegate(FormList.MDIChild.updateAscanbytimer);
        }

        /**Start thread.*/
        public void start()
        {
            if (status != ThreadCondition.run)
            {
                thread.Start();
                status = ThreadCondition.run;
                timer.Enabled = true;
                timer.Start();
            }
        }

        /**Parse thread function.*/
        private void parseFunc()
        {
            //DEFINATION
            bool isDequeSuccess;
            bool isParseSuccess;
            //bool isError;
            CaptureOutQueueElement outqueueElement;
            //A queue atom represent the end of the ascan queue.
            AscanQueueElement ascanEndElement;
            //A queue atom represent the end of the mergein queue.
            MergeInQueueElement mergeInEndElement;

            //INIT
            isDequeSuccess = false;
            isParseSuccess = false;
            //isError = false;
            outqueueElement = new CaptureOutQueueElement();
            ascanEndElement = new AscanQueueElement();
            ascanEndElement.IsEnd = true;
            mergeInEndElement = new MergeInQueueElement();
            mergeInEndElement.IsEnd = true;

            //PROCESSING
            init.handclasp_meet();

            while (!GlobalQuit.Quit)
            {
                try
                {
                    isDequeSuccess = inputQueue.Dequeue(ref outqueueElement);

                    if (isDequeSuccess)
                    {
                        //if receive the end atom of queue, just break and stop the thread.
                        if (outqueueElement.IsEnd == true)
                            break;
                       // LogFile.write("开始分发");
                        isParseSuccess = parsePacket(outqueueElement.setPacket);
                      //  LogFile.write("分发结束");
                        if (!isParseSuccess)
                        {
                            StackTrace st = new StackTrace(new StackFrame(true));
                            LogHelper.WriteLog("The format of packet is wrong or ParseThread timed out when Enqueue!", st);
#if USE_WARNING
                            MessageBox.Show("分发线程获取的数据格式错误或入队失败，请马上设置断点检查。位置：ParseThread.parseFunc");
#endif
                            status = ThreadCondition.error;
                            //isError = true;
                        }
                    }
                    else
                    {
                        StackTrace st = new StackTrace(new StackFrame(true));
                        LogHelper.WriteLog("ParseThread timed out when Dequeue!", st);
#if USE_WARNING
                        MessageBox.Show("分发线程出队超时，请马上设置断点检查。位置：ParseThread.parseFunc");
#endif
                        status = ThreadCondition.error;
                       // isError = true;
                    }
                }
                catch (Exception e)
                {
                    StackTrace st = new StackTrace(new StackFrame(true));
                    LogHelper.WriteLog(e, st);
#if USE_WARNING
                    MessageBox.Show("检测到异常，请马上设置断点检查。位置：ParseThread.parseFunc");
#endif
                    status = ThreadCondition.error;
                    //isError = true;
                }
            }
            
            init.handclasp_force();

            //ascanQueue.EnqueueWithSemaphor(ascanEndElement);
            //mergeInQueue.EnqueueWithSemaphor(mergeInEndElement);

            clean.handclasp_meet();

            status = ThreadCondition.exit;
        }

        /**Get the datas ande enqueue.*/
        private bool parsePacket(UniSetPacket setPacket)
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
            else if (tmpId <= (uint)PacketId.alarmDisp || tmpId == (uint)PacketId.couple|| tmpId == (uint)PacketId.eventId)
            {
                if (tmpId == (uint)PacketId.eventId)
                {
                    tmpId = (uint)PacketId.eventId;
                }
                //Gate, Gate2, Alarm, just forward
                mergeInQueueElement.setPacket = setPacket;
                isEnqueSuccess = mergeInQueue.EnqueueWithSemaphor(mergeInQueueElement);
                if (!isEnqueSuccess)
                    return false;
            }
            else if (tmpId == (uint)PacketId.ascanVedio)
            {
                //AsacnVedio
                copyToAscanPacket(ascanQueueElement.ascanPacket, setPacket);
                SessionInfo sessionAttr = SessionHardWare.getSessionAttr((int)SelectAscan.userIndex);

                if (!MainForm.IsToStop)
                {
                    if ((int)ascanQueueElement.getPort() == sessionAttr.myHardInfo.upPort)
                    {
                        FormList.MDIChild.enqueue(ascanQueueElement);
                        //FormList.MDIChild.BeginInvoke(updateCallBack);
                        /*count++;
                        if (count >= 5)
                        {
                            FormList.MDIChild.BeginInvoke(updateCallBack);
                            count = 0;
                        }*/

                        //FormList.MDIChild.updateAscan(ascanQueueElement);
                        //ascanUpdate.Execute(ascanQueueElement);
                    }

                    //Sector Scan
                    if (FormList.Formsscan.isStart)
                    {
                        if (((int)ascanQueueElement.getPort() <= 512 + FormList.Formsscan.passNum - 1) && ((int)ascanQueueElement.getPort()>=512))
                        {
                            FormList.Formsscan.enqueue(ascanQueueElement, (int)ascanQueueElement.getPort()-512);
                        }
                    }                    
                }
                return true;
                //isEnqueSuccess = ascanQueue.EnqueueWithSemaphor(ascanQueueElement);
                //if (!isEnqueSuccess)
                    //return false;
            }
            else if(tmpId == (uint)PacketId.status)
            {
                //Status
                copyToStatusPacket(boardStatusPacket, setPacket);

                uint status = boardStatusPacket.status.status;

                switch(status)
                {
                    case 0x0:
                    case 0x1:
                    case 0x3:
                        isBoardStatusOK = false;
                        break;
                    case 0x2:
                        isBoardStatusOK = true;
                        break;
                    default:
                        isBoardStatusOK = false;
                        break;
                }
                return true;
            }

            return isEnqueSuccess;
        }

        /**Copy the datas to the queue of boardStatus.*/
        private void copyToStatusPacket(BoardStatusSetPacket statusPacket, UniSetPacket setPacket)
        {
            //DEFINATION
            ItemHeader head;
            UploadTagHeader tag;
            BoardStatus status;
            int uintOffset;

            //INIT
            head = statusPacket.head;
            tag = statusPacket.tag;
            status = statusPacket.status;
            uintOffset = 0;

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

            //status
            status.status = setPacket.ud[uintOffset++];
            status.errCode = (int)setPacket.ud[uintOffset++];
            status.beatHeart = setPacket.ud[uintOffset++];
        }

         /**Copy the datas to the queue of ascanStatus.*/
        private void copyToAscanPacket(AscanSetPacket ascanPacket, UniSetPacket setPacket)
        {
            //DEFINATION
            ItemHeader head;
            UploadTagHeader tag;
            AscanVideo ascan;
            int uintOffset;
            int floatOffset;

            //INIT
            head = ascanPacket.head;
            tag = ascanPacket.tag;
            ascan = ascanPacket.ascan;
            uintOffset = 0;
            floatOffset = 0;

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

            //ascan uint
            ascan.len = setPacket.ud[uintOffset++];
            ascan.ifStart = setPacket.ud[uintOffset++];
            ascan.tofUnit = setPacket.ud[uintOffset++];
            ascan.ampUnit = setPacket.ud[uintOffset++];
            ascan.echoMax = setPacket.ud[uintOffset++];
            ascan.waveDetectMode = setPacket.ud[uintOffset++];
            ascan.envelopStart = setPacket.ud[uintOffset++];
            Array.Copy(setPacket.ud, uintOffset, ascan.led, 0, 8);
            uintOffset += 8;

            //ascan double
            ascan.delay = setPacket.fd[floatOffset++];
            ascan.width = setPacket.fd[floatOffset++];
            ascan.gain = setPacket.fd[floatOffset++];
            ascan.bea = setPacket.fd[floatOffset++];
            ascan.decayFactor = setPacket.fd[floatOffset++];
            Array.Copy(setPacket.fd, floatOffset, ascan.ascanGateAmp, 0, 4);
            floatOffset += 4;
            Array.Copy(setPacket.fd, floatOffset, ascan.ascanGateTof, 0, 4);
            floatOffset += 4;
            Array.Copy(setPacket.fd, floatOffset, ascan.wave, 0, ascan.len);
            floatOffset += (int)ascan.len;
            Array.Copy(setPacket.fd, floatOffset, ascan.maxEnvelop, 0, ascan.len);
            floatOffset += (int)ascan.len;
            Array.Copy(setPacket.fd, floatOffset, ascan.minEnvelop, 0, ascan.len);
            floatOffset += (int)ascan.len;
        }

        private void UpdateAscan(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (FormList.MDIChild.IsHandleCreated)
            {
                FormList.MDIChild.BeginInvoke(updateCallBack);
            }
        }
    }


    /**Parse thread environment.*/
    public class ParseThreadEnv
    {
        /** ThreadHandClasp for init.*/
        public ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        public ThreadHandClasp clean;
        /** The states of the thread.*/
        public ThreadCondition status;
        public int index;

        /** InputQueue of the thread.*/
        public RingBufferQueue<CaptureOutQueueElement> captureOutQueue;
        /** OutputQueue of the thread for ascan.*/
        public RingBufferQueue<AscanQueueElement> ascanQueue;
        /** OutputQueue of the thread for merge.*/
        public RingBufferQueue<MergeInQueueElement> mergeInQueue;
    }
}
