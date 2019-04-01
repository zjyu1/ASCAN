using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace Ascan
{
    /**A class for the UI timer of ascan and its callbackfunction.*/
    public class AscanUIThread
    {
        /**A thread for the ascan UI.*/
        private Thread thread;

        /**A timer for the ascan UI.*/
        //private System.Windows.Forms.Timer timer;

        /**Input queue for the timer.*/
        private List<RingBufferQueue<AscanQueueElement>> ascanInList;

        /** ThreadHandClasp for init.*/
        private ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        private ThreadHandClasp clean;
        /** The states of the timer.*/
        private ThreadCondition status;
        //private DelegateAscanUpdate ascanUpdate;
        private AscanQueueElement ascanQueueElement;

        public ThreadCondition Status
        {
            get
            {
                return status;
            }
        }

        public AscanUIThread(AscanUIThreadEnv tmpEnv)
        {
            init = tmpEnv.init;
            clean = tmpEnv.clean;
            status = tmpEnv.status;
            ascanInList = tmpEnv.ascanInList;

            ascanQueueElement = new AscanQueueElement();
            //timer = new System.Windows.Forms.Timer();
            //timer.Interval = ConstParameter.AscanTimerInterval;
            //timer.Tick += new EventHandler(AscanUIFunc);
            thread = new Thread(AscanUIFunc);
            thread.IsBackground = true;
        }

        /**Start timer.*/
        public void start()
        {
            if (status != ThreadCondition.run)
            {
                //timer.Enabled = true;
                thread.Start();
                status = ThreadCondition.run;     
            }
        }

        /**Stop timer.*/
        /*public void stop()
        {
            if (timer.Enabled)
                timer.Enabled = false;
        }*/

        /**Ascan UI timer function.*/
        private void AscanUIFunc()
        {
            //DEFINATION
            bool isError;

            int dequeueResult;
            int endCount;
            bool isQuit = false;

            //INIT
            isError = false;
            endCount = 0;

            //PROCESSING
            init.handclasp_meet();

            DelegateAscanUpdate ascanUpdate = new DelegateAscanUpdate();

            while (!GlobalQuit.Quit && !isQuit)
            {
                try
                {
                    for (int i = 0; i < SessionInfo.sessionNum; i++)
                    {
                        dequeueResult = ascanInList[i].DequeueWithSemaphor(ref ascanQueueElement, ConstParameter.TimeOutMilliSecondValue);

                        if (dequeueResult == -1)
                        {
                            StackTrace st = new StackTrace(new StackFrame(true));
                            LogHelper.WriteLog("Ascan UI Thread timed out when semaphor wait for receiving!", st);
#if USE_WARNING
                            MessageBox.Show("A扫UI线程信号量超时，请马上设置断点检查。位置：AscanUIThread.AscanUIFunc");
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
                            if (ascanQueueElement.IsEnd)
                            {
                                endCount++;
                                if (endCount == ascanInList.Count)
                                {
                                    endCount = 0;
                                    isQuit = true;
                                    //timer.Enabled = false;
                                    break;
                                }
                                else
                                    continue;
                            }

                            if (!MainForm.IsToStop)
                            {
                                if (i == SelectAscan.userIndex && (int)ascanQueueElement.getPort() == SelectAscan.port)
                                {
                                    MainForm.syncContext.Post(FormList.MDIChild.updateAscan, (Object)ascanQueueElement);
                                    //FormList.MDIChild.updateAscan(ascanQueueElement);
                                    //ascanUpdate.Execute(ascanQueueElement);
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    StackTrace st = new StackTrace(new StackFrame(true));
                    LogHelper.WriteLog(ex, st);
#if USE_WARNING
                    MessageBox.Show("检测到异常，请马上设置断点检查。位置：AscanUIThread.AscanUIFunc");
#endif
                    status = ThreadCondition.error;
                    //isError = true;
                }
            }
            init.handclasp_force();

            clean.handclasp_meet();

            status = ThreadCondition.exit;
        }
    }

    /**Ascan UI thread environment.*/
    public class AscanUIThreadEnv
    {
        /** ThreadHandClasp for init.*/
        public ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        public ThreadHandClasp clean;
        /** The states of the thread.*/
        public ThreadCondition status;

        /**Input queue for the thread.*/
        public List<RingBufferQueue<AscanQueueElement>> ascanInList;
    }

    public class DelegateAscanUpdate
    {
        private delegate void ascanDraw(AscanQueueElement ascanQueueElement);
        private event ascanDraw ascanDrawEvent;

        public DelegateAscanUpdate()
        {
            ascanDrawEvent += new ascanDraw(FormList.MDIChild.updateAscan);
        }

        public void Execute(AscanQueueElement ascanQueueElement)
        {
            if (ascanDrawEvent != null)
            {
                FormList.MDIChild.Invoke(ascanDrawEvent, ascanQueueElement);
            }
        }
    }

    public class SelectAscan
    {
        public static uint sessionIndex;
        public static uint userIndex;
        public static uint port;
    }

}
