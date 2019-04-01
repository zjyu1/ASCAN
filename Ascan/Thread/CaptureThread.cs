using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Ascan
{
    /**A class for the capture thread and its callbackfunction.*/
    public class CaptureThread
    {
        private uint boardId;
        /**A thread for the capture.*/
        private Thread thread;
        /**Output queue for the thread.*/
        private RingBufferQueue<CaptureOutQueueElement> outputQueue;

        /**ThreadHandClasp for init.*/
        private ThreadHandClasp init;
        /**ThreadHandClasp for clean.*/
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

        //pkg counter 
        private uint pkgCounter;

        public uint PkgCounter
        {
            get
            {
                return pkgCounter;
            }
        }

        public CaptureThread(CaptureThreadEnv tmpEnv)
        {
            boardId = (uint)tmpEnv.boardId;
            init = tmpEnv.init;
            clean = tmpEnv.clean;
            status = tmpEnv.status;
            outputQueue = tmpEnv.captureOutQueue;
            pkgCounter = 0;

            thread = new Thread(captureFunc);
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

        /**Capture thread funcion.*/
        private void captureFunc()
        {
            CaptureOutQueueElement outQueueElement;
            //A queue atom represent the end of the input.
            CaptureOutQueueElement queueFlush;
            int readResult;
            bool isEnqueue;

            outQueueElement = new CaptureOutQueueElement();
            queueFlush = new CaptureOutQueueElement();
            queueFlush.IsEnd = true;
            readResult = 0;
            //isError = false;
            isEnqueue = false;

            init.handclasp_meet();

            while (!GlobalQuit.Quit)
            {
                try
                {
                    readResult = GetPDAQ.daqRead(boardId, ref outQueueElement.setPacket);
                    //outQueueElement.setPacket.id = 512;
                    if (0 == readResult)
                    {
                        //LogFile.write("收到采集信号");
                        //the receiver count++
                        pkgCounter++;

                        //enqueue
                        isEnqueue = outputQueue.Enqueue(outQueueElement);
                        //LogFile.write("采集入队成功");
                        if (!isEnqueue)
                        {
                            StackTrace st = new StackTrace(new StackFrame(true));
                            LogHelper.WriteLog(boardId + "# CaptureThread timed out when Enqueue!", st);
#if USE_WARNING
                            MessageBox.Show("采集线程入队超时，请马上设置断点检查。位置：CaptureThread.captureFunc");
#endif
                            status = ThreadCondition.error;
                            //isError = true;
                        }
                    }
                    //A symbol for the last one
                    else if (1 == readResult)
                    {
                        outputQueue.Enqueue(queueFlush);
                        break;
                    }
                    else
                    {
                        StackTrace st = new StackTrace(new StackFrame(true));
                        LogHelper.WriteLog("Can't read from DAQ. ErrorCoed = " + readResult, st);
#if USE_WARNING
                        MessageBox.Show("采集线程读取DAQ数据错误，请马上设置断点检查。位置：CaptureThread.captureFunc, " + boardId.ToString() + "#采集线程错误！");
#endif
                        status = ThreadCondition.error;
                        //isError = true;
                    }
                }
                catch(Exception e)
                {
                    StackTrace st = new StackTrace(new StackFrame(true));
                    LogHelper.WriteLog(e, st);
#if USE_WARNING
                    MessageBox.Show("检测到异常，请马上设置断点检查。位置：CaptureThread.captureFunc, " + boardId.ToString() + "#采集线程异常！");
#endif
                    status = ThreadCondition.error;
                    //isError = true;
                }
            }
            init.handclasp_force();

            //outputQueue.Enqueue(queueFlush);
            clean.handclasp_meet();

            status = ThreadCondition.exit;
        }
    }

    /**Capture thread environment.*/
    public class CaptureThreadEnv
    {
        /** ThreadHandClasp for init.*/
        public ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        public ThreadHandClasp clean;
        /** The states of the thread.*/
        public ThreadCondition status;

        /** OutputQueue of the thread.*/
        public RingBufferQueue<CaptureOutQueueElement> captureOutQueue;

        public int boardId;
    }

}
