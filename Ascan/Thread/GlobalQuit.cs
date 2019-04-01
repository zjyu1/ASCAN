using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public static class GlobalQuit
    {
        //global quit for all thread 
        private static bool quit = false;

        //lock for get/set quit
        private static readonly object quitLockObj = new Object();

        public static bool Quit
        {
            get
            {
                bool q;
                lock (quitLockObj)
                {
                    q = quit;
                }

                return q;
            }
            set
            {
                lock (quitLockObj)
                {
                    quit = value;
                }
            }
        }
    }

}
