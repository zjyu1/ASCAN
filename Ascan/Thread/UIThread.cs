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
    /**A class for the UI thread and its callbackfunction.*/
    public class UIThread
    {
        /**A thread for the UI.*/
        private Thread thread;
        /**Input queue for the thread.*/
        private List<RingBufferQueue<AscanQueueElement>> ascanInList;

        /** ThreadHandClasp for init.*/
        private ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        private ThreadHandClasp clean;
        /** The states of the thread.*/
        private ThreadCondition status;

        private List<SessionAttrs> sessionsAttrs;
        private List<DelegateAscanUpdate> ascanUpdateList;
        private AscanQueueElement ascanQueueElement;

        public ThreadCondition Status
        {
            get
            {
                return status;
            }
        }

        public UIThread(UIThreadEnv tmpEnv)
        {
            init = tmpEnv.init;
            clean = tmpEnv.clean;
            status = tmpEnv.status;
            ascanInList = tmpEnv.ascanInList;

            this.sessionsAttrs = tmpEnv.sessionsAttrs;
            ascanQueueElement = new AscanQueueElement();

            thread = new Thread(UIFunc);
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

        /**UI thread function.*/
        private void UIFunc()
        {
            //DEFINATION
            bool isError;

            int dequeueResult;

            //INIT
            isError = false;

            //PROCESSING
            init.handclasp_meet();

            bindAscanDrawEvent();

            while (!GlobalQuit.Quit)
            {
                try
                {
                    for (int i = 0; i < sessionsAttrs.Count; i++)
                    {
                        dequeueResult = ascanInList[i].DequeueWithSemaphor(ref ascanQueueElement);

                        if (dequeueResult == -1)
                        {
                            StackTrace st = new StackTrace(new StackFrame(true));
                            LogHelper.WriteLog("UI Thread timed out when semaphor wait for receiving!", st);
#if USE_WARNING
                            MessageBox.Show("UI主线程信号量超时，请马上设置断点检查。位置：UIThread.UIFunc");
#endif
                            status = ThreadCondition.error;
                            isError = true;
                        }
                        else if (dequeueResult == 0)
                        {
                            continue;
                        }
                        else if (dequeueResult == 1)
                        {
                            if (sessionsAttrs[i].myHardInfo.enable)
                            {
                                ascanUpdateList[i].Execute(ascanQueueElement);
                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    StackTrace st = new StackTrace(new StackFrame(true));
                    LogHelper.WriteLog(e, st);
#if USE_WARNING
                    MessageBox.Show("检测到异常，请马上设置断点检查。位置：UIThread.UIFunc");
#endif
                    status = ThreadCondition.error;
                    isError = true;
                }
            }

            init.handclasp_force();

            clean.handclasp_meet();

            if (!isError)
                status = ThreadCondition.exit;
        }

        private void bindAscanDrawEvent()
        {
            ascanUpdateList = new List<DelegateAscanUpdate>();

            for (uint i = 0; i < sessionsAttrs.Count; i++)
            {
                DelegateAscanUpdate ascanUpdate = new DelegateAscanUpdate(i);
                ascanUpdateList.Add(ascanUpdate);
            }
        }
    }

    /**UI thread environment.*/
    public class UIThreadEnv
    {
        /** ThreadHandClasp for init.*/
        public ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        public ThreadHandClasp clean;
        /** The states of the thread.*/
        public ThreadCondition status;

        /**Input queue for the thread.*/
        public List<RingBufferQueue<AscanQueueElement>> ascanInList;
        /**Session attributes.*/
        public List<SessionAttrs> sessionsAttrs;
    }

    public class DelegateAscanUpdate
    {
        private uint ascanNum;
        private delegate void ascanDraw(AscanQueueElement ascanQueueElement);
        private event ascanDraw ascanDrawEvent;

        public DelegateAscanUpdate(uint ascanNum)
        {
            this.ascanNum = ascanNum;
            ascanDrawEvent += new ascanDraw(FormList.MDIChild[ascanNum].updateAscan);
        }

        public void Execute(AscanQueueElement ascanQueueElement)
        {
            if (ascanDrawEvent != null)
            {
                FormList.MDIChild[ascanNum].Invoke(ascanDrawEvent, ascanQueueElement);
                //ascanDrawEvent.Invoke(ascanQueueElement);
            }
        }
    }
}
