using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;

namespace Ascan
{
    /**The class is used to control all the queues we used in the software.*/
    public class QueueManager
    {
        public const int SEMAPHORMAXCOUNT = int.MaxValue;

        /**The queues of list used between capture thread and parse thread.*/
        public List<RingBufferQueue<CaptureOutQueueElement>> captureOutList;
        /**The queues of list used between parse thread and ascan display thread.*/
        public List<RingBufferQueue<AscanQueueElement>> ascanList;
        /**The queues of list used between parse thread and merge thread.*/
        public List<RingBufferQueue<MergeInQueueElement>> mergeInList;
        /**The queues used for merge out.*/
        public RingBufferQueue<MeasureQueueElement> measurementQueue;
        /**The count of session.*/
        private int sessionNum;

        /** Semaphore for the merge.*/
        private Semaphore semaphorForMerge;
        /** Semaphore for the ascan.*/
        private Semaphore semaphorForAscan;

        public QueueManager(int sessionNum)
        {
            this.sessionNum = sessionNum;
            captureOutList = new List<RingBufferQueue<CaptureOutQueueElement>>(this.sessionNum);
            ascanList = new List<RingBufferQueue<AscanQueueElement>>(this.sessionNum);
            mergeInList = new List<RingBufferQueue<MergeInQueueElement>>(this.sessionNum);

            semaphorForMerge = new Semaphore(0, SEMAPHORMAXCOUNT);
            semaphorForAscan = new Semaphore(0, SEMAPHORMAXCOUNT);

            for (int i = 0; i < this.sessionNum; i++)
            {
                RingBufferQueue<CaptureOutQueueElement> captureOutQueue = new RingBufferQueue<CaptureOutQueueElement>();
                captureOutList.Add(captureOutQueue);

                RingBufferQueue<AscanQueueElement> ascanQueue = new RingBufferQueue<AscanQueueElement>(semaphorForAscan);
                ascanList.Add(ascanQueue);

                RingBufferQueue<MergeInQueueElement> mergeInQueue = new RingBufferQueue<MergeInQueueElement>(semaphorForMerge);
                mergeInList.Add(mergeInQueue);
            }

            measurementQueue = new RingBufferQueue<MeasureQueueElement>();
        }

        public void Clear()
        {
            sessionNum = 0;

            captureOutList.Clear();
            captureOutList = null;

            ascanList.Clear();
            ascanList = null;

            mergeInList.Clear();
            mergeInList = null;

            measurementQueue = null;

            semaphorForMerge = null;
            semaphorForAscan = null;

            System.GC.Collect();
        }
    }

    /**A queue who is secure in multithreading condition and will be blocked when empty or full.*/
    public class ThreadSafeQueue<T>
    {
        private ConcurrentQueue<T> queue;
        private BlockingCollection<int> block;
        public int Count
        {
            get
            {
                return queue.Count;
            }
        }

        public ThreadSafeQueue()
        {
            queue = new ConcurrentQueue<T>();
            block = new BlockingCollection<int>(ConstParameter.MaxQueueItemCount);
        }

        public bool Enqueue(T item)
        {
            bool result = true;

            result = block.TryAdd(1, ConstParameter.TimeOutMilliSecondValue);
            if (!result)
            {
                //StackTrace st = new StackTrace(new StackFrame(true));
                //LogHelper.WriteLog("Timed out when Enqueue!", st);
                return false;
            }

            queue.Enqueue(item);
            return true;
        }

        public bool Dequeue(out T item)
        {
            bool result;
            int tmp;

            //When the count of block is 0, the current thread will be blocking after this.
            result = block.TryTake(out tmp, ConstParameter.TimeOutMilliSecondValue);
            if (!result)
            {
                item = default(T);
                //StackTrace st = new StackTrace(new StackFrame(true));
                //LogHelper.WriteLog("Timed out when Dequeue!", st);
                return false;
            }
            result = queue.TryDequeue(out item);
            while (!result)
            {
                result = queue.TryDequeue(out item);
            }
            return result;
        }

        /**When one of parseOutQueue is dequeuing and the count is 0, we check other parseOutQueues rather
         *than blocking the current thread .
         */
        public bool DequeueWithoutBlocking(out T item)
        {
            bool result;
            result = queue.TryDequeue(out item);
            if (result)
                block.Take();
            return result;
        }
    }

    /**A queue with ring buffer.
     *With this queue, we don't need to malloc room for Dequeue and Enqueue.
     *What we do is just recyceling the current malloced room. 
     */
    public class RingBufferQueue<T>
        where T:IClone<T>, new()
    {
        private ThreadSafeQueue<T> input;
        private ThreadSafeQueue<T> output;
        private List<T> sourceList;

        private Semaphore semaphore;

        public int Count
        {
            get 
            {
                return input.Count;
            }
        }

        public RingBufferQueue()
        {
            input = new ThreadSafeQueue<T>();
            output = new ThreadSafeQueue<T>();
            sourceList = new List<T>(ConstParameter.MaxQueueItemCount);
            for (int i = 0; i < ConstParameter.MaxQueueItemCount; i++)
            {   
                T item = new T();
                sourceList.Add(item);
                output.Enqueue(item);
            }

            this.semaphore = null;
        }

        public RingBufferQueue(Semaphore semaphore)
        {
            input = new ThreadSafeQueue<T>();
            output = new ThreadSafeQueue<T>();
            sourceList = new List<T>(ConstParameter.MaxQueueItemCount);
            for (int i = 0; i < ConstParameter.MaxQueueItemCount; i++)
            {
                T item = new T();
                sourceList.Add(item);
                output.Enqueue(item);
            }

            this.semaphore = semaphore;
        }

        public bool Enqueue(T item)
        {
            T inputItem;
            bool result = true;

            //Get null item
            result = output.Dequeue(out inputItem);
            if (!result)
            {
               // StackTrace st = new StackTrace(new StackFrame(true));
                //LogHelper.WriteLog("Get null item failed!", st);
                return false;
            }

            //Copy
            item.clone(inputItem);

            //Fill item
            result = input.Enqueue(inputItem);
            if (!result)
            {
                //StackTrace st = new StackTrace(new StackFrame(true));
                //LogHelper.WriteLog("Fill item failed!", st);
                return false;
            }

            return result;
        }

        public bool Dequeue(ref T item)
        {
            T outputItem;
            bool result = true;

            //Fetch item
            result = input.Dequeue(out outputItem);
            if (!result)
            {
                if (!result)
                {
                    //StackTrace st = new StackTrace(new StackFrame(true));
                    //LogHelper.WriteLog("Fetch item failed!", st);
                    return false;
                }
                return false;
            }

            //Copy
            outputItem.clone(item);

            //Reback item
            result = output.Enqueue(outputItem);
            if (!result)
            {
                //StackTrace st = new StackTrace(new StackFrame(true));
                //LogHelper.WriteLog("Reback item failed!", st);
                return false;
            }

            return result;
        }

        /**When one of parseOutQueue is dequeuing and the count is 0, we check other parseOutQueues rather
        *than blocking the current thread .
        */
        private bool DequeueWithoutBlocking(ref T item)
        {
            T outputItem;

            if ((input.Count <= 0) || (output.Count >= ConstParameter.MaxQueueItemCount))
                return false;

            //Fetch item
            input.Dequeue(out outputItem);

            //Copy
            outputItem.clone(item);

            //Reback item
            output.Enqueue(outputItem);

            return true;
        }

        /**Enqueue with semaphor.*/
        public bool EnqueueWithSemaphor(T item)
        {
            bool result;

            if (this.semaphore == null)
                return false;

            result = Enqueue(item);
            if (!result)
                return false;   //enqueue timed out

            semaphore.Release();
            return true;       //enqueue successfully
        }

        /**
         * Dequeue with semaphor.
         * @param item to contain the itom dequeued
         * @param semaphor the semaphore we used
         * @return result where -1 represents semaphore timed out or is null, 0 represents the queue is empty
         *          and 1 represents dequeue successfully
         */
        public int DequeueWithSemaphor(ref T item, int msecondTimeOut)
        {
            bool result;

            if (this.semaphore == null)
                return -1;

            result = semaphore.WaitOne(msecondTimeOut);
            if (!result)
            {
                return -1;   //timed out
            }

            result = DequeueWithoutBlocking(ref item);

            if (!result)
            {
                semaphore.Release();  //the queue is empty, but another queue has item.
                return 0;
            }

            return 1; //dequeue successfully
        }
    }

    public class QueueData
    {
        public bool isEnd;  //Check weather this is the last ont to put into the queue.

        public QueueData()
        {
            isEnd = false;
        }
    }
    public interface IClone<T>
    {
        void clone(T dest);
    }
}
