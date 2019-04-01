using System;
using System.Collections.Generic;
using System.Text;
using ECAN;
using System.Threading;
using System.Windows.Forms;

namespace AUTCAN
{
    class ComProc
    {
        private INIT_CONFIG init_config;
        private bool isOpen;

        //通过CAN发给驱动器，各功能的数据帧
        //public readonly byte[] AUTOMODE = new byte[] { 0x22, 0x60, 0x60, 0x00, 0x03, 0x00, 0x00, 0x00 };
        public readonly byte[] PROFILESPPED = new byte[] { 0x22, 0x60, 0x60, 0x00, 0x03, 0x00, 0x00, 0x00 };
        public readonly byte[] ACCELERATE = new byte[] { 0x22, 0x83, 0x60, 0x00 };
        public readonly byte[] DCCELERATE = new byte[] { 0x22, 0x84, 0x60, 0x00 };
        public readonly byte[] STARTMOVE = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x0F, 0x00, 0x00, 0x00 };
        public readonly byte[] FAULTCLEAR = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x80, 0x00, 0x00, 0x00 };
        public readonly byte[] ERRORNUM = new byte[] { 0x40, 0x03, 0x10, 0x01, 0x00, 0x00, 0x00, 0x00 };
        public readonly byte[] MAXCURRENT = new byte[] { 0x22, 0x10, 0x64, 0x01 };
        public readonly byte[] STEPMODE = new byte[] { 0x22, 0x60, 0x60, 0x00, 0x01, 0x00, 0x00, 0x00 };
        public readonly byte[] HOMEMODE = new byte[] { 0x22, 0x60, 0x60, 0x00, 0x06, 0x00, 0x00, 0x00 };
        public readonly byte[] RESET = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x06, 0x00, 0x00, 0x00 };
        public readonly byte[] ENABLE = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x0f, 0x00, 0x00, 0x00 };
        public readonly byte[] SPEED = new byte[] { 0x22, 0x81, 0x60, 0x00 };
        public readonly byte[] STEP = new byte[] { 0x22, 0x7a, 0x60, 0x00 };
        public readonly byte[] PMOVE = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x5f, 0x00, 0x00, 0x00 };
        public readonly byte[] P_ABMOVE = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x1f, 0x00, 0x00, 0x00 };
        public readonly byte[] READSPEED = new byte[] { 0x40, 0x6c, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00 };
        public readonly byte[] READPOSITION = new byte[] { 0x40, 0x64, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00 };
        public readonly byte[] READSTATUS = new byte[] { 0x40, 0x41, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00 };
        public readonly byte[] STOP = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x0F, 0x01, 0x00, 0x00 };
        public readonly byte[] HOMEMETHOD = new byte[] { 0x22, 0x98, 0x60, 0x00, 0x07, 0x00, 0x00, 0x00 };
        public readonly byte[] STARTHOME = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x1f, 0x00, 0x00, 0x00 };
        public readonly byte[] STOPHOME = new byte[] { 0x22, 0x40, 0x60, 0x00, 0x0b, 0x00, 0x00, 0x00 };
        public readonly byte[] STARTIO = new byte[] { 0x22, 0x78, 0x20, 0x01, 0x05, 0x80, 0x00, 0x00 };
        public readonly byte[] STOPIO = new byte[] { 0x22, 0x78, 0x20, 0x01, 0x05, 0x40, 0x00, 0x00 };
        public readonly byte[] PROFILEPOSITION = new byte[] { 0x22, 0x60, 0x60, 0x00, 0x01, 0x00, 0x00, 0x00 };


        public ComProc()        //构造函数，对参数进行初始化
        {

            this.init_config = InitCan();

            if (!OpenComm())
            {
                MessageBox.Show("连接失败！");
                isOpen = false;
            }
            else
            {
                isOpen = true;
            }
        }


        public bool Comm(CAN_OBJ sendmsg, out CAN_OBJ recmsg)
        { 
            int sendnum;
            int recnum;
            uint mLen;

            sendnum = 0;
            recnum = 0;

            CAN_OBJ msg = new CAN_OBJ();

            if (!isOpen)
            {
                OpenComm();
            }

            mLen = 1;
            while (ECANDLL.Transmit(1, 0, 0, ref sendmsg, (ushort)mLen) != ECAN.ECANStatus.STATUS_OK)
            {
                sendnum++;

                Thread.Sleep(1);

                if (sendnum == 10)
                {
                    recmsg = msg;
                    return false;
                }
            }

            while (ECANDLL.Receive(1, 0, 0, out recmsg, 1, 1) != ECAN.ECANStatus.STATUS_OK)
            {
                recnum++;

                Thread.Sleep(1);

                if (recnum == 10)
                {
                    return false;
                }
            }
            return true;
            
        }



        public bool RestCan()
        {
            if (ECANDLL.ResetCAN(1, 0, 0) == ECAN.ECANStatus.STATUS_OK)
            {
                return true;
            }
            return false;
        }



        private bool OpenCan()
        {
            if (ECANDLL.OpenDevice(1, 0, 0) != ECAN.ECANStatus.STATUS_OK)
            {
                return false;                               //若未打开usb转can设备则返回false
            }

            if (ECANDLL.InitCAN(1, 0, 0, ref init_config) != ECAN.ECANStatus.STATUS_OK)
            {
                ECANDLL.CloseDevice(1, 0);
                return false;                               //若未能初始化CAN设备，则关闭can设备并返回false
            }

            if (ECANDLL.StartCAN(1, 0, 0) != ECAN.ECANStatus.STATUS_OK)
            {
                ECANDLL.CloseDevice(1, 0);
                return false;                               //若未能启动CAN设备，则关闭can设备并返回false
            }

            return true;
        }

        public bool OpenComm()
        {
            int num;

            num = 0;
            while (!OpenCan())
            {
                num++;

                Thread.Sleep(1);

                if (num == 10)
                {
                    return false;
                }
                
            }

            return true;
        }

        private INIT_CONFIG InitCan()                                   //初始化CAN，设置好波特率（这里设为500kb/s）
        {           
            init_config.AccCode = 0;
            init_config.AccMask = 0xffffff;
            init_config.Filter = 0;
            init_config.Timing0 = 0;
            init_config.Timing1 = 0x1c;
            init_config.Mode = 0;
            return init_config;
        }

        public void Close()                                             //关闭CAN设备    
        {
            ECANDLL.CloseDevice(1, 0);                                  
        }

        public void SendTest()
        {
            CAN_OBJ sendMsg = new CAN_OBJ();
            byte[] Msg = new byte[8];

            sendMsg.SendType = 0;
            sendMsg.data = new byte[8];
            //sendMsg.Reserved = new byte[2];
            sendMsg.ID = 0x601;
            sendMsg.DataLen = Convert.ToByte(8);
            sendMsg.ExternFlag = 0;
            sendMsg.RemoteFlag = 0;

            for (int i = 0; i < Msg.Length; i++)
            {
                sendMsg.data[i] = Msg[i];
            }

            uint mLen = 1;

            if (ECANDLL.Transmit(1, 0, 0, ref sendMsg, (ushort)mLen) != ECANStatus.STATUS_OK)
            {
                MessageBox.Show("fail");
            }
            else
            {
                MessageBox.Show("sucess");
            }

        }
    }
}
