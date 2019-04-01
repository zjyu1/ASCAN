using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AUTCAN;
using ECAN;

namespace AUT
{
    class Motion
    {
        public ComProc mCan;
        CAN_OBJ sendMsg;
        CAN_OBJ recMsg;
        int speed;
        int position;
        int error;
        bool iscomplete;
        System.Timers.Timer SendTimer; 

        public Motion()
        { 
            mCan=new ComProc();
            sendMsg = new CAN_OBJ();
            recMsg = new CAN_OBJ();
            speed = 0;
            position = 0;
            error = 0;
            iscomplete = true;
            SendTimer = new System.Timers.Timer();

            SendTimer.Enabled = false;                                //初始化读取实时速度和位置的计时器，每5ms发送一次读取指令,读取速度和位置信息   
            SendTimer.AutoReset = false;
            SendTimer.Interval = 50;
            SendTimer.Elapsed += new System.Timers.ElapsedEventHandler(Send_tick);
        }

        public void Initial_Motion()
        {
            SetMode();
            SetAccelerate(5000);
            SetAccelerate(-5000);
        
        }

        public void SetMode()
        {
            bool err;

            err = SendCanMsg(mCan.PROFILEPOSITION);
            if (!err)
            {
                MessageBox.Show("发送运动模式失败！");
            }   
        }

        public void SetAccelerate(int value)
        {
            bool err;

            byte[] value_data = new byte[8];
            byte[] tmp = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                if (value > 0)
                {
                    value_data[i] = mCan.ACCELERATE[i];
                }
                else
                {
                    value_data[i] = mCan.DCCELERATE[i];
                }
                
            }
            
            tmp = TranIntToByte(System.Math.Abs(value));
            int j = 0;
            for (int i = 7; i > 3; i--)
            {
                value_data[i] = tmp[j];
                j = j + 1;
            }

            err = SendCanMsg(value_data);
            if (!err)
            {
                MessageBox.Show("加速度设置失败！");
            }
        }

        public void Go(int dir, int range, int speed)
        {
            int step_range;

            SetSpeed(speed);
            Enable();

            step_range = (int)(range * 66 * 2000 / (21 * System.Math.PI));

            switch (dir)
            {
                case 0:
                    {                        
                        SetStartIO();

                        if (ReadStatus())
                        { 
                            Move(step_range);
                            SendTimer.Enabled = true;                               
                            SendTimer.AutoReset = true;
                        }
                        
                        break;
                    }
                case 1:
                    {
                        SetStartIO();

                        if (ReadStatus())
                        {
                            Move(-step_range);
                            SendTimer.Enabled = true;
                            SendTimer.AutoReset = true;
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        private void SetSpeed(int speed)
        {
            bool err;

            byte[] speed_data = new byte[8];
            byte[] tmp = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                speed_data[i] = mCan.SPEED[i];
            }
            tmp = TranIntToByte(speed);
            int j = 0;
            for (int i = 7; i > 3; i--)
            {
                speed_data[i] = tmp[j];
                j = j + 1;
            }

            err = SendCanMsg(speed_data);

            if (!err)
            {
                MessageBox.Show("速度设置失败！");
            }
        }

        private void Enable()
        {
            bool err;

            err = SendCanMsg(mCan.RESET);

            if (!err)
            {
                MessageBox.Show("驱动器使能失败！");
            }

            err = SendCanMsg(mCan.ENABLE);

            if (!err)
            {
                MessageBox.Show("驱动器使能失败！");
            }
        }

        public void SetStartIO()
        {
            bool err;

            err = SendCanMsg(mCan.STARTIO);

            if (!err)
            {
                MessageBox.Show("设置start信号失败！");
            }
        }

        public  void SetStopIO()
        {
            bool err;

            err = SendCanMsg(mCan.STOPIO);

            if (!err)
            {
                MessageBox.Show("设置stop信号失败！");
            }
        }

        public double ReadPosition()
        {
            bool err;
            
            double pos;
            string tmpstr;

            err = SendCanMsg(mCan.READPOSITION);
            

            if (!err)
            {
                //MessageBox.Show("读取位置信息失败！");
            }
            else
            {
                if (recMsg.data != null)
                {
                    if (recMsg.data[0] == 0x43 && recMsg.data[1] == 0x64)
                    {
                        string str = "";
                        for (int j = 7; j >= 4; j--)
                        {
                            tmpstr = string.Format("{0:X2}", recMsg.data[j]);
                            str = str + tmpstr;
                        }
                        position = Convert.ToInt32(str, 16);
                    }
                }
            }

            pos = (double)position / 132000 * (System.Math.PI * 21);

            pos = Math.Round(pos,2);

            return pos;
        }

        public double ReadSpeed()
        {
            bool err;
            
            double vec;
            string tmpstr;

            err = SendCanMsg(mCan.READSPEED);
            

            if (!err)
            {
                //MessageBox.Show("读取速度信息失败！");
            }
            else
            {
                if (recMsg.data != null)
                {
                    if (recMsg.data[0] == 0x43 && recMsg.data[1] == 0x6c)
                    {
                        string str = "";
                        for (int j = 7; j >= 4; j--)
                        {
                            tmpstr = string.Format("{0:X2}", recMsg.data[j]);
                            str = str + tmpstr;
                        }
                        speed = Convert.ToInt32(str, 16);
                    }
                }
            }

            vec = (double)speed * 21 * Math.PI / (66 * 60);

            vec = Math.Round(vec,2);

            return vec;
        }


        public int ReadError()
        {
            bool err;
            
            string tmpstr;

            err = SendCanMsg(mCan.ERRORNUM);
            

            if (!err)
            {
                MessageBox.Show("读取错误码信息失败！");
            }
            else
            {
                if (recMsg.data != null)
                {
                    if (recMsg.data[1] == 0x03 && recMsg.data[2] == 0x10)
                    {
                        string str = "";
                        for (int j = 7; j >= 4; j--)
                        {
                            tmpstr = string.Format("{0:X2}", recMsg.data[j]);
                            str = str + tmpstr;
                        }
                        error = Convert.ToInt32(str, 16);
                    }
                }
            }
            return error;
        }

        public bool ReadStatus()
        {
            bool err;
                       

            err = SendCanMsg(mCan.READSTATUS);
            

            if (!err)
            {
                MessageBox.Show("读取状态信息失败！");
            }
            else
            {
                if (recMsg.data != null)
                {
                    if (recMsg.data[0] == 0x4B && recMsg.data[4] == 0x37 && recMsg.data[5] == 0x15)
                    {
                        iscomplete = true;
                        SetStopIO();
                    }
                    else if (recMsg.data[0] == 0x4B && recMsg.data[4] == 0x37 && recMsg.data[5] == 0x11)
                    {
                        iscomplete = false;
                    }
                    else
                    {
                        //iscomplete = false;
                    }

                }
            }
            return iscomplete;
        }


        private void Move(int range)
        {
            bool err;

            byte[] position_data = new byte[8];
            byte[] tmp = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                position_data[i] = mCan.STEP[i];
            }
            tmp = TranIntToByte(range);
            int j = 0;
            for (int i = 7; i > 3; i--)
            {
                position_data[i] = tmp[j];
                j = j + 1;
            }

            err=SendCanMsg(position_data);

            if (!err)
            {
                MessageBox.Show("设置位移量失败！");
            }

            err=SendCanMsg(mCan.PMOVE);

            if(!err)
            {
                MessageBox.Show("运动失败！");
            }
        }

        private bool SendCanMsg(byte[] Msg)
        {
            bool err;
            //create a Can message structure;

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


            err = mCan.Comm(sendMsg, out recMsg);
            
            if (!err)
            {
                //MessageBox.Show("发送失败");
                return false;
            }

            return true;
        }

        private byte[] TranIntToByte(int value)                 //transfer int to byte[4]
        {
            string str, tmpstr;
            string[] hex1 = new string[4];
            tmpstr = Convert.ToString(value, 16);
            str = tmpstr.PadLeft(8, '0');
            char[] chars = str.ToCharArray();
            byte[] bytes = new byte[4];
            int j = 0;
            int i = 0;
            for (i = 0; i < bytes.Length; i++)
            {
                hex1[i] = new string(new char[] { chars[j], chars[j + 1] });
                bytes[i] = Convert.ToByte(hex1[i], 16);
                j = j + 2;
            }
            return bytes;
        }

        private void Send_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
           
            ReadStatus();
 
        }
    }
}
