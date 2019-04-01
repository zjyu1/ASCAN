using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace Ascan
{
    public static class DAQ
    {
        /** Alloc mem for Interface, Session and board, and initial datas.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int USCOMM_InitDevice(string devName, ref uint sessionNum);

        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int USCOMM_GetVersion(uint index, ref IdTarget target);

        /** Free mem of Interface, Session and board.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int USCOMM_CloseDevice();

        /** Get attrbute value whoes type is uInt.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_GetuInt(uint index, uint chn, uint attrType, ref uint pVal);

        /** Get attrbute value whoes type is Double.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_GetFloat(uint index, uint chn, uint attrType, ref float pVal);

        /** Get attrbute value whoes type is struct.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_GetDac(uint index, uint chn, uint attrType, ref DACParas pVal);

        /**Load Beamformer file*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_LoadBMFile(uint index, string fileName, ref uint size);

        /**Save Beamformer file*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_SaveBMFile(uint index, string fileName);

        /** Set attrbute value whoes type is uInt.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_SetuInt(uint index, uint chn, uint attrType, uint pVal);

        /** Set attrbute value whoes type is Double.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_SetFloat(uint index, uint chn, uint attrType, float pVal);

        /** Set attrbute value whoes type is struct.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_SetDac(uint index, uint chn, uint attrType, DACParas pVal);

        /** Set attrbute value whoes type is struct.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_SetBeam(uint index, uint chn, uint attrType, StructBeamFile pVal);

        /** Get attr's range info.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_GetRangeuInt(uint index, uint attrType, ref AttrRangeUInt pValSet);
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_GetRangeuDouble(uint index, uint attrType, ref AttrRangeDouble pValSet);

        /** Load dsp App. */
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_APILoadApp(uint index, ref char pBinFile);

        /** Start acquire. */
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_SessionRun(uint index);

        /** Stop acquire. */
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int USCOMM_SessionStop(uint index);

        /** Read buf datas in TSQ.*/
        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int USCOMM_Read(uint index, ref UniSetPacket setPacket, uint boolBlock);

        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int USCOMM_StreamStart(uint index, ref StreamEnable streamEnable);

        [DllImport("COMM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int USCOMM_StreamStop(uint index, ref StreamEnable streamEnable);

        public static int daqGet(uint index, uint chn, uint attrType, ref uint pVal)
        {
            int error_code;

            error_code = USCOMM_GetuInt(index, chn, attrType, ref pVal);
            return error_code;
        }

        public static int daqGet(uint index, uint chn, uint attrType, ref Double pVal)
        {
            int error_code;
            float flValue = 0f;

            error_code = USCOMM_GetFloat(index, chn, attrType, ref flValue);
            pVal = (Double)flValue;

            return error_code;
        }

        public static int daqGet(uint index, uint chn, uint attrType, ref DACParas pVal)
        {
            int error_code;

            error_code = USCOMM_GetDac(index, chn, attrType, ref pVal);
            return error_code;
        }

        public static int daqSet(uint index, uint chn, uint attrType, uint pVal)
        {
            int error_code;
            error_code = USCOMM_SetuInt(index, chn, attrType, pVal);
            return error_code;
        }

        public static int daqSet(uint index, uint chn, uint attrType, Double pVal)
        {
            int error_code;
            float ftValue = (float)pVal;

            error_code = USCOMM_SetFloat(index, chn, attrType, ftValue);

            return error_code;
        }

        public static int daqSet(uint index, uint chn, uint attrType, DACParas pVal)
        {
            int error_code;
            error_code = USCOMM_SetDac(index, chn, attrType, pVal);
            return error_code;
        }

        public static int daqSet(uint index, uint chn, uint attrType, StructBeamFile pVal)
        {
            int error_code;
            error_code = USCOMM_SetBeam(index, chn, attrType, pVal);
            return error_code;
        }

        /*public static int daqGet(uint index, uint attrType, IntPtr pValSet)
        {
            int error_code;
            error_code = daqGetRange(index, attrType, pValSet, dflag);
            return error_code;
        }*/

        public static int daqAPILoad(uint index, ref char pBinFile)
        {
            int error_code;
            error_code = USCOMM_APILoadApp(index, ref pBinFile);
            return error_code;
        }

        public static int daqRun(uint index)
        {
            int error_code;
            error_code = USCOMM_SessionRun(index);
            return error_code;
        }

        public static int daqStop(uint index)
        {
            int error_code;
            error_code = USCOMM_SessionStop(index);
            return error_code;
        }
    }

    [Serializable]
    public class SessionInfo
    {
        public static uint sessionNum; //real board
        public static uint portNum; //real board + virtual board
        public static uint[] virtualNumEachBoard = new uint[5];
        public static bool isInitSuccess;

        public HardwareInfo myHardInfo;
        public readonly int sessionIndex;
        public readonly int userIndex;

        public bool isRun;
        public bool isStreamStart;

        public int type;
        public int LR;
        public string zonename;

        public int port;

        public SessionInfo(int sessionIndex, int userIndex, int port)
        {
            this.sessionIndex = sessionIndex;
            this.userIndex = userIndex;
            this.port = port;
            isRun = false;
            isStreamStart = false;
            myHardInfo = new HardwareInfo(this.sessionIndex, this.port);
            //virtualNumEachBoard = new uint[5];
        }

    }

    public class HardwareInfo
    {
        private String boardName;
        private uint classicNum;
        private uint slotNum;
        private string assignedName;
        public int index;
        public int port;
        public bool enable;
        public int upPort;

        public HardwareInfo(int index, int port)
        {
            this.boardName = "";
            this.index = index;
            this.port = port;
            enable = true;
            getHardInfo();
            setUpPort();
        }

        public string BoardName
        {
            get
            {
                if (this.boardName == "")
                {
                    IdTarget target = new IdTarget();
                    StringBuilder builder = new StringBuilder();
                    int err = 0;
                    int index = 0;

                    err = DAQ.USCOMM_GetVersion((uint)this.index, ref target);
                    if (err == 0)
                    {
                        while (index < 16 && target.name[index] != '\0')
                        {
                            builder.Append(target.name[index]);
                            index++;
                        }
                        return builder.ToString();
                    }
                    else
                        return "";
                }
                else
                    return this.boardName;
            }
        }

        public TrigMode TrigMode
        {
            get
            {
                TrigMode trigMode = TrigMode.TrigPxiStar;
                GetGlobalControlDAQ.TrigMode((uint)index, (uint)port, ref trigMode);
                return trigMode;
            }
            set
            {
                int err = 0;
                err = SetGlobalControlDAQ.TrigMode((uint)index, (uint)port, value);
                if (err != 0)
                    MessageShow.show("Set TrigMode failed!", "设置触发模式失败！");
            }
        }

        public string Version
        {
            get
            {
                IdTarget target = new IdTarget();
                StringBuilder builder = new StringBuilder();
                int err = 0;
                int index = 0;

                err = DAQ.USCOMM_GetVersion((uint)this.index, ref target);
                if (err == 0)
                {
                    while (index < 16 && target.version[index] != '\0')
                    {
                        builder.Append(target.version[index]);
                        index++;
                    }
                    return builder.ToString();
                }
                else
                    return "";
            }
        }
//set is added by xll 2017-2-28
        public double StartDelay
        {
            get
            {
                uint delay = 0;
                int error_code = 0;

                error_code = GetGlobalControlDAQ.PxistarTrigStartDelay((uint)index, (uint)port, ref delay);
                if (error_code != 0)
                    delay = 0;

                return delay;
            }
            set
            {
                uint delay = 0;
                delay = (uint)value;
                int err_code = 0;
                err_code = SetGlobalControlDAQ.PxistarTrigStartDelay((uint)index, (uint)port, delay);
                if (err_code != 0)
                    MessageShow.show("Set StartDelay failed!", "设置发射延时失败！");
            }
        }

        public double StopDelay
        {
            get
            {
                uint delay = 0;
                int error_code = 0;

                error_code = GetGlobalControlDAQ.PxistarTrigStopDelay((uint)index, (uint)port, ref delay);
                if (error_code != 0)
                    delay = 0;

                return delay;
            }
            set
            {
                uint delay = 0;
                delay = (uint)value;
                int err_code = 0;
                err_code = SetGlobalControlDAQ.PxistarTrigStopDelay((uint)index, (uint)port, ref delay);
                if (err_code != 0)
                    MessageShow.show("Set StopDelay failed!", "设置接受延时失败！");
            }
        }

        public double PRF
        {
            get
            {
                uint aPrf = 0;
                int error_code = 0;

                error_code = error_code = GetPulserTransmitDAQ.Prf((uint)index, (uint)port, ref aPrf);
                if (error_code != 0)
                    aPrf = 0;

                return aPrf;
            }
            set
            {
                uint aPrf =(uint)value;
                int error_code = 0;

                error_code = error_code = SetPulserTransmitDAQ.Prf((uint)index, (uint)port, aPrf);
                if (error_code != 0)
                    MessageShow.show("Set PRF failed!", "设置PRF失败！");
            }

        }
//set is added by xll 2017-2-28
        public int Index
        {
            get { return index; }
        }

        public uint ClassicNum
        {
            get { return classicNum; }
        }

        public uint SlotNum
        {
            get { return slotNum; }
        }

        public string AssignedName
        {
            get { return assignedName; }
            set { assignedName = value; }
        }

        public void getHardInfo()
        {
            int error_code;
            uint cla_num = 0;
            uint slt_num = 0;

            error_code = DAQ.daqGet((uint)index, (uint)port, (uint)AttrbuteType.DAQ_ATTR_PCI_CLASSIC_NUMBER,ref cla_num);
            if (error_code == 0)
                classicNum = cla_num;
            else
                classicNum = 0;

            error_code = DAQ.daqGet((uint)index, (uint)port, (uint)AttrbuteType.DAQ_ATTR_PCI_SLOT_NUMBER,ref slt_num);
            if (error_code == 0)
                slotNum = slt_num;
            else
                slotNum = 0;

            if (assignedName == null)
            {
                assignedName = cla_num.ToString() + "-" + slotNum.ToString();
            }
        }

        public void setUpPort()
        {
            this.upPort = ((int)classicNum << 16) + ((int)slotNum << 8) + port;
        }
    }

}
