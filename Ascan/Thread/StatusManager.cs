using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class StatusManager
    {
        /**A locker.*/
        private readonly object locker;

        /**Last status of boards.
         * 1 represents idle or reseting;
         * 2 represents running;
         * 3 represents error.
         */
        private int preBoardsStatus;

        /**Last status of threads.
         * 1 represents created or exit;
         * 2 represents running;
         * 3 represents error.
         */
        private int preThreadsStatus;

        private MainForm mainForm;

        private delegate void showStatusClass(int i);

        private showStatusClass showBoardsStatus;

        public StatusManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            locker = new object();
            preBoardsStatus = 0;
            preThreadsStatus = 0;

            showBoardsStatus = new showStatusClass(mainForm.showBoardsStatus);
        }

        public void compareBoardStatus(int status)
        {
            int result;

            if ((status == 1) || (status == 0))
            {
                result = 1;
            }
            else
            {
                result = status;
            }

            lock (locker)
            {
                if (preBoardsStatus != result)
                {
                    //Invoke;
                    showBoardsStatus.Invoke(result);
                    preBoardsStatus = result;
                }
            }
        }
    }
}
