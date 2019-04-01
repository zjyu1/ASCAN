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
    /**A class for the UI thread of measurement and its callbackfunction.*/
    public class MeasureUIThread
    {
        private System.Timers.Timer timer = new System.Timers.Timer(100);
        /**A thread for the measurement UI.*/
        private Thread thread;
        /** IntputQueue of the thread.*/
        private RingBufferQueue<MeasureQueueElement> measureQueue;

        private MeasureQueueElement measureQueueElement;

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

        private delegate void updateDelegate();
        private updateDelegate updateCallBack;

        public MeasureUIThread(MeasureUIThreadEnv tmpEnv)
        {
            init = tmpEnv.init;
            clean = tmpEnv.clean;
            status = tmpEnv.status;
            measureQueue = tmpEnv.measureQueue;

            measureQueueElement = new MeasureQueueElement();

            thread = new Thread(MeasureUIFunc);
            thread.IsBackground = true;

            //timer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateAUT);
            timer.AutoReset = true;
        }

        /**Start thread.*/
        public void start()
        {

            if (status != ThreadCondition.run)
            {
                thread.Start();
                status = ThreadCondition.run;
                //timer.Enabled = true;
                //timer.Start();
            }
        }

        /**Measure UI thread function.*/
        private void MeasureUIFunc()
        {
            //DEFINATION
            //bool isError;

            bool isDequeSuccess;

            //INIT
            //isError = false;
            isDequeSuccess = false;

            //PROCESSING
            init.handclasp_meet();

            while (!GlobalQuit.Quit)
            {
                try
                {
                    //if (measureUpdateList.Count != mapRowDataList.Count)
                        //bindMeasureDrawEvent();

                    isDequeSuccess = measureQueue.Dequeue(ref measureQueueElement);

                    if (isDequeSuccess)
                    {
                        //if receive the end atom of queue, just break and stop the thread.
                        if (measureQueueElement.IsEnd == true)
                            break;

                        if (FormList.FormMeasurement == null)
                            continue;

                        if (!MainForm.IsToStop)
                        {
                            FormList.FormMeasurement.addPoints(measureQueueElement);
                            //FormList.FormCalibrate.addPoints(measureQueueElement);
                        }
                    }
                    else
                    {
                        StackTrace st = new StackTrace(new StackFrame(true));
                        LogHelper.WriteLog("MeasureUI thread timed out when Dequeue!", st);
#if USE_WARNING
                        MessageBox.Show("融合显示线程出队超时，请马上设置断点检查。位置：MeasureUIThread.MeasureUIFunc");
#endif
                        status = ThreadCondition.error;
                        //isError = true;
                    }
                }
                catch (Exception e)
                {
                    StackTrace st = new StackTrace(new StackFrame(true));
                    LogHelper.WriteLog(e, st);
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

        //private void UpdateAUT(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    if (FormList.FormMeasurement == null)
        //        return;
        //    if (updateCallBack ==null)
        //        updateCallBack = new updateDelegate(FormList.FormMeasurement.updatePicture);
        //    FormList.FormMeasurement.BeginInvoke(updateCallBack);
        //}
    }

    /**Measure UI thread environment.*/
    public class MeasureUIThreadEnv
    {
        /** ThreadHandClasp for init.*/
        public ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        public ThreadHandClasp clean;
        /** The states of the thread.*/
        public ThreadCondition status;

        /** IntputQueue of the thread.*/
        public RingBufferQueue<MeasureQueueElement> measureQueue;
    }
}
