using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetAscanVideoDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static int Active(uint ascanNum, uint ascanPort, AscanVideoActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Active;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Ascan video active failed", "错误：设置Ascan video active失败");
            }
            return error_code;
        }

        public static int IFActive(uint ascanNum, uint ascanPort, AscanIFActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.IFActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Ascan if active failed", "错误：设置Ascan if active失败");
            }
            return error_code;
        }

        public static int Delay(uint ascanNum, uint ascanPort, double delay)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Delay;
            double val = delay;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Ascan delay failed", "错误：设置Ascan delay失败");
            }
            return error_code;
        }

        public static int Range(uint ascanNum, uint ascanPort, double range)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Range;
            double val = range;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Ascan range failed", "错误：设置Ascan range失败");
            }
            return error_code;
        }

        private static int DetectionWaveMode(uint ascanNum, uint ascanPort, AscanWaveDectionMode mode)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.DetectionWaveMode;
            uint val = (uint)mode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Detection wave mode of Asacn failed", "错误：设置A扫的检波失败");
            }
            return error_code;
        }

        /**Set wave mode to Positive、Negative、Full Wave acocording to  tofMode.*/
        public static bool WaveMode(uint ascanNum, uint ascanPort, AscanWaveDectionMode waveMode)
        {
            int error_code;
            int gateTotNum = 4;
            GateType gateNum;
            int gateI = (int)GateType.I;
            int gateA = (int)GateType.A;
            int gateB = (int)GateType.B;
            int gateC = (int)GateType.C;
            bool isSetPre = true;
            TofMode[] tofMode = new TofMode[gateTotNum];
            TofMode tofModeFlank = TofMode.Flank;
            for (int i = 0; i < gateTotNum; i++)
            {
                gateNum = (GateType)i;
                error_code = GetGateDAQ.TofMode(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref tofMode[i]);
                if (error_code != 0)
                {
                    return isSetPre;
                }
            }

            if (waveMode == AscanWaveDectionMode.SemiPositve || waveMode == AscanWaveDectionMode.SemiNegtive
                || waveMode == AscanWaveDectionMode.Full)
            {
                if (tofMode[gateI] > tofModeFlank || tofMode[gateA] > tofModeFlank
                    || tofMode[gateB] > tofModeFlank || tofMode[gateC] > tofModeFlank)//Tof Mode are Zero Before or Zero After
                {
                    MessageShow.show("Tof Mode = Zero Before or Zero After, need to set Receiver->RF!",
                        "Tof Mode = Zero Before or Zero After,必须设置Receiver->RF!");
                    return isSetPre;
                }
            }

            error_code = SetAscanVideoDAQ.DetectionWaveMode(ascanNum, ascanPort, waveMode);
            if (error_code != 0)
                return isSetPre;

            return isSetPre = false;
        }

        public static int EnvlopActive(uint ascanNum, uint ascanPort, AscanEnvelopActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.EnvlopActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Envelop active failed", "错误：设置Envelop active失败");
            }
            return error_code;
        }

        public static int Length(uint ascanNum, uint ascanPort, AscanVideoLength length)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.Length;
            uint val = (uint)length;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Ascan video length failed", "错误：设置Ascan video length失败");
            }
            return error_code;
        }

        public static int CompressdData(uint ascanNum, uint ascanPort, AscanCompressedActive active)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.CompressedData;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Compressed Data failed", "错误：设置Ascan Compressed Data失败");
            }
            return error_code;
        }

        public static int EnvlopDecayFactor(uint ascanNum, uint ascanPort, uint speed)
        {
            int error_code;
            uint attr = DaqAttrType.ascanVideo.EnvlopDecayFactor;
            uint val = speed;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Envlop Decay Factor failed！", "错误：设置包络速度失败！");
            }
            return error_code;
        }
    }
}
