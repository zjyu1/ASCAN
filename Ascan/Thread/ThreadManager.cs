using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ascan
{
    /**The class is used to control all the threads we creat in the software.*/
    public class ThreadManager
    {
        /**ThreadHandClasp for init.*/
        private ThreadHandClasp threadHandClaspInit;
        /**ThreadHandClasp for cleanup.*/
        private ThreadHandClasp threadHandClaspCleanup;

        /**A list to hold all the capture threads.*/
        private List<CaptureThread> captureThreadList;
        /**A list to hold all the parse threads.*/
        private List<ParseThread> parseThreadList;
        /**Merge thread.*/
        private MergeThread mergeThread;
        /**Ascan UI thread.*/
        private AscanUIThread AscanUIThread;
        /**Measurement UI thread.*/
        private MeasureUIThread measureUIThread;

        /**The capacity of the thread list.*/
        private int sessionNum;

        private QueueManager queueManager;

        public ThreadManager(int sessionNum, QueueManager queueManager)
        {
            this.sessionNum = sessionNum;
            this.queueManager = queueManager;

            threadHandClaspInit = new ThreadHandClasp(sessionNum * 2 + 2);
            threadHandClaspCleanup = new ThreadHandClasp(sessionNum * 2 + 2);

            captureThreadList = new List<CaptureThread>(sessionNum);
            parseThreadList = new List<ParseThread>(sessionNum);
            
            initPrimaryThreads();
        }
            
        /**Initial the capture threads and dispens threads according to the thread environment.*/
        private void initPrimaryThreads()
        {
            for (int i = 0; i < sessionNum; i++)
            {
                CaptureThreadEnv tmpCaptureThreadEnv = new CaptureThreadEnv();
                setCaptureThreadEnv(tmpCaptureThreadEnv, i);
                CaptureThread captureThread = new CaptureThread(tmpCaptureThreadEnv);
                captureThreadList.Add(captureThread);
                

                ParseThreadEnv tmpParseThreadEnv = new ParseThreadEnv();
                setParseThreadEnv(tmpParseThreadEnv, i);
                ParseThread parseThread = new ParseThread(tmpParseThreadEnv);
                parseThreadList.Add(parseThread);
            }

            MergeThreadEnv tmpMergeThreadEvn = new MergeThreadEnv();
            setMergeThreadEnv(tmpMergeThreadEvn);
            mergeThread = new MergeThread(tmpMergeThreadEvn);

            AscanUIThreadEnv tmpAscanUIThreadEnv = new AscanUIThreadEnv();
            setAscanUIThreadEnv(tmpAscanUIThreadEnv);
            AscanUIThread = new AscanUIThread(tmpAscanUIThreadEnv);

            MeasureUIThreadEnv tmpMeasureUIThreadEnv = new MeasureUIThreadEnv();
            setMeasureUIThreadEnv(tmpMeasureUIThreadEnv);
            measureUIThread = new MeasureUIThread(tmpMeasureUIThreadEnv);
        }

        /**Start all threads.*/
        public void threadsStart()
        {
            for (int i = 0; i < sessionNum; i++)
            {
                captureThreadList[i].start();
                parseThreadList[i].start();
            }

            mergeThread.start();
            //AscanUIThread.start();
            measureUIThread.start();
        }

        /**
         * Set the enviroment of the capture thread.
         * @param thrdEnv the capture environment to be set
         * @param index the index of capture thread in thread list
         * @return thrdEnv a capture thread environment whose paraments are set
         */
        private void setCaptureThreadEnv(CaptureThreadEnv threadEnv, int indexOfThreadList)
        {
            int count = queueManager.captureOutList.Count;
            if (indexOfThreadList >= count)
            {
                return;
            }

            threadEnv.init = threadHandClaspInit;
            threadEnv.clean = threadHandClaspCleanup;
            threadEnv.status = ThreadCondition.created;
            threadEnv.captureOutQueue = queueManager.captureOutList[indexOfThreadList];
            threadEnv.boardId = indexOfThreadList;
        }

        /**
         * Set the enviroment of the parse thread.
         * @param thrdEnv the parse environment to be set
         * @param index the index of parse thread in thread list
         * @return thrdEnv a parse thread environment whose paraments are set
         */
        private void setParseThreadEnv(ParseThreadEnv threadEnv, int indexOfThreadList)
        {
            int count = queueManager.captureOutList.Count;
            if (indexOfThreadList >= count)
            {
                return;
            }

            threadEnv.init = threadHandClaspInit;
            threadEnv.clean = threadHandClaspCleanup;
            threadEnv.status = ThreadCondition.created;
            threadEnv.index = indexOfThreadList;

            threadEnv.captureOutQueue = queueManager.captureOutList[indexOfThreadList];
            threadEnv.ascanQueue = queueManager.ascanList[indexOfThreadList];
            threadEnv.mergeInQueue = queueManager.mergeInList[indexOfThreadList];
        }

         /**
         * Set the enviroment of the merge thread.
         * @param thrdEnv the merge environment to be set
         * @return thrdEnv a merge thread environment whose paraments are set
         */
        private void setMergeThreadEnv(MergeThreadEnv threadEnv)
        {
            threadEnv.init = threadHandClaspInit;
            threadEnv.clean = threadHandClaspCleanup;
            threadEnv.status = ThreadCondition.created;

            threadEnv.mergeInList = queueManager.mergeInList;
            threadEnv.measureQueue = queueManager.measurementQueue;
        }

        /**
        * Set the enviroment of the Ascan UI thread.
        * @param thrdEnv the UI thread environment to be set
        * @return thrdEnv a UI thread environment whose paraments are set
        */
        private void setAscanUIThreadEnv(AscanUIThreadEnv threadEnv)
        {
            threadEnv.init = threadHandClaspInit;
            threadEnv.clean = threadHandClaspCleanup;
            threadEnv.status = ThreadCondition.created;

            threadEnv.ascanInList = queueManager.ascanList;
        }

        /**
        * Set the enviroment of the measure UI thread.
        * @param thrdEnv the UI thread environment to be set
        * @return thrdEnv a UI thread environment whose paraments are set
        */
        private void setMeasureUIThreadEnv(MeasureUIThreadEnv threadEnv)
        {
            threadEnv.init = threadHandClaspInit;
            threadEnv.clean = threadHandClaspCleanup;
            threadEnv.status = ThreadCondition.created;

            threadEnv.measureQueue = queueManager.measurementQueue;
        }

        public bool isBoardsStatusOK()
        {
            int n1 = queueManager.captureOutList[0].Count;
            int n2 = queueManager.ascanList[0].Count;
            if(parseThreadList.Count == 0)
                return false;

            for (int i = 0; i < parseThreadList.Count; i++)
            {
                if (!parseThreadList[i].IsBoardStatusOK)
                    return false;
            }
            return true;
        }

        public bool isThreadsStatusOK()
        {
            if ((parseThreadList.Count == 0)||(captureThreadList.Count == 0)||(AscanUIThread == null))
                return false;

            for (int i = 0; i < captureThreadList.Count; i++)
            {
                if (captureThreadList[i].Status != ThreadCondition.run)
                    return false;
            }
            for (int i = 0; i < parseThreadList.Count; i++)
            {
                if (parseThreadList[i].Status != ThreadCondition.run)
                    return false;
            }
            if (mergeThread.Status != ThreadCondition.run)
                return false;
            if (AscanUIThread.Status != ThreadCondition.run)
                return false;
            if (measureUIThread.Status != ThreadCondition.run)
                return false;
            return true;
        }

        public bool isThreadsExit()
        {
            if ((parseThreadList.Count == 0) || (captureThreadList.Count == 0) || (AscanUIThread == null))
                return false;

            for (int i = 0; i < captureThreadList.Count; i++)
            {
                if (captureThreadList[i].Status != ThreadCondition.exit)
                    return false;
            }
            for (int i = 0; i < parseThreadList.Count; i++)
            {
                if (parseThreadList[i].Status != ThreadCondition.exit)
                    return false;
            }
            if (mergeThread.Status != ThreadCondition.exit)
                return false;
            if (AscanUIThread.Status != ThreadCondition.exit)
                return false;
            if (measureUIThread.Status != ThreadCondition.exit)
                return false;
            return true;
        }

        public void Clear()
        {
            threadHandClaspInit = null;
            threadHandClaspCleanup = null;

            captureThreadList.Clear();
            captureThreadList = null;

            parseThreadList.Clear();
            parseThreadList = null;

            mergeThread = null;

            AscanUIThread = null;

            measureUIThread = null;
            System.GC.Collect();
        }
    }

    public enum ThreadCondition
    {
        created,   /**<Initial states.*/
        exit,      /**<Exit states.*/
        run,       /**<Running states.*/
        error     /**<Error states.*/
    }
}
