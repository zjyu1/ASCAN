using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ascan
{
    public class ThreadHandClasp
    {
        /**The num of thread the class has.*/
        private int orig;

        /**The num of thread who is processing.*/
        private int count;

        /**A lock.*/
        private readonly object lock_obj;
        private EventWaitHandle threadWaitHdl;

        public ThreadHandClasp(int _count)
        {
            orig = _count;
            count = _count;
            lock_obj = new object();
            threadWaitHdl = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        /**
        *@brief Called by a thread when it's initialization is done. This will
        *register that this thread is done initializing, and will block the calling
        *thread until the other threads are done initializing, after which all
        *threads will be unblocked at once.
       */
        public void handclasp_meet()
        {
            Monitor.Enter(lock_obj);
            if (--count > 0)
            {
                Monitor.Exit(lock_obj);
                threadWaitHdl.WaitOne();
            }
            else
            {
                threadWaitHdl.Set();
                Monitor.Exit(lock_obj);
            }
        }

        /**
         *@brief This call forces all threads blocking in handclasp_meet to unblock
         *no matter what the state is. Useful for error cleanup.
        */
        public void handclasp_force()
        {
            lock (lock_obj)
            {
                count = 0;
                threadWaitHdl.Set();
            }
        }

        /**
         * @brief This call resets the handclasp to it's original count at
         * opening time.
        */
        public void handclase_reset()
        {
            lock (lock_obj)
            {
                count = orig;
            }
        }
    }
}
