/*----------------------------------------------------------------
// Copyright (C) 2015 Zhejiang University, ZJU128 Group
// Copyright.
//
// FileName: CaptureThread2.cs
// File Desc: capture thread.
//
// Create Tag: 2015-11-27, by Wueryong@ZJU base on QWS's captureThread class
//              
// Revision Tag:
// Revision Desc:
//
// Revision Tag:
// Revision Desc:
//----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ascan
{
    
    public class CaptureThread2
    {
        //board id
        private uint boardId;
       
        //own thread object
        private Thread thread;

        //output queue
        private Queue<QueueData> outQueue;

        //output queue lock object
        private readonly object outQueueLock;

        //input tsq interface
          //directly call DAQ interface through board id

        //thread quit flag
        private bool quit;
      
        //thread init Rendezvous 
        private ThreadHandClasp init;

        //thread clean Rendezvous
        private ThreadHandClasp clean;
        
        //thread own state
        public ThreadState state;

        //recieved package counter
        private int pRcvPkgCounter;
        public int  rcvPkgCounter
        {
            get {return pRcvPkgCounter;}
        }
        //sended package counter
        private int pTxdPkgCounter;
        public int txdPkgCounter
        {
            get {return pTxdPkgCounter;}
        }

        //Construct 
        public CaptureThread2(CaptureThreadEnv2 env)
        {
            //inputed board id, used by DAQ
            boardId = env.boardId;

            //share all thread's init and clean Rendezvous
            init = env.init;
            clean = env.clean;
            
            state = ThreadState.Unstarted;

            //share inputs queue and queue lock instance
            outQueue = env.captureOutQueueAbstract.queue;
            outQueueLock = env.captureOutQueueAbstract.queueLock;

            //quit is false
            quit = false;

            //creat thread and go run
            thread = new Thread(captureFunc2);
            thread.IsBackground = true;
            thread.Start();
            
            //thread state flag update
            state = ThreadState.Running;

        }
        

        //thread function
        private void captureFunc2()
        {
            //DEFINATION
            //last one element
            CaptureOutQueueElement cFlush; //last element

            //queue capcity
            int  numCapBufs;

            //caputure element
            CaptureOutQueueElement ce;  

            //driver element
            DrvQueueElement   de;

            //
            uint boardStatus;

            //daq return
            int errCode;


            //CHECK INPUTS
            //none.

            //INIT
            cFlush = new CaptureOutQueueElement(false);
            cFlush.isEnd = true;

            //MAIN PROCESSING
            try
            {
                //check board is normal?
                errCode = DAQ.get(boardId, AttrbuteType.DAQ_ATTR_BOARD_STATUS_MACHINE, ref boardStatus, (uint)DAQ_TYPE.DAQ_UINT_TYPE);
                if (errCode != (int)DAQErr.Success)
                {
                    throw new Exception("daq err return");
                }
                if (boardStatus != (uint)DAQ_BOARD_STATUS_MACHINE.DAQ_BOARD_STATUS_MACHINE_IDLE)
                {
                    throw new Exception("daq not correct board status");
                }

                //wait init Rendezvous
                init.handclasp_meet();

                //thread function
                while ((quit = Gbl.GetQuit()) != true)
                { 
                    //new ce read from tsq interface, if timeout, throw error

                    //check output queue is full? if not full, 
                    //
                }//end while(...

            }//end try
            catch(Exception e)
            {
                MessageShow.show("Error of " + index.ToString() + "# capture thread!", index.ToString() + "#capture thread！" + e.ToString());
            }//end catch


           

          
        }
    }

    /**Capture thread environment.*/
    public class CaptureThreadEnv2
    {
        /** ThreadHandClasp for init.*/
        public ThreadHandClasp init;
        /** ThreadHandClasp for clean.*/
        public ThreadHandClasp clean;
        /** The states of the thread.*/
        public ThreadCondition states;

        /** OutputQueue of the thread.*/
        public QueueAbstract captureOutQueueAbstract;

        public int boardId;
    }

   

} //end of Ascan namespace
