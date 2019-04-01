using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetGateDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        private const GateType gateTypeMin = GateType.I;
        private const GateType gateTypeMax = GateType.C;

        private static Dictionary<int, double> delayForGateI = new Dictionary<int, double>();
        private static Dictionary<int, double> delayForGateA = new Dictionary<int, double>();
        private static Dictionary<int, double> delayForGateB = new Dictionary<int, double>();
        private static Dictionary<int, double> delayForGateC = new Dictionary<int, double>();
        private static Dictionary<int, double> widthForGateI = new Dictionary<int, double>();
        private static Dictionary<int, double> widthForGateA = new Dictionary<int, double>();
        private static Dictionary<int, double> widthForGateB = new Dictionary<int, double>();
        private static Dictionary<int, double> widthForGateC = new Dictionary<int, double>();

        public static int Delay(uint ascanNum, uint ascanPort, GateType type, double delay)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].Delay;
            double val = delay;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Delay of gate failed", "错误：设置门的起始位置失败");
                return error_code;
            }
            setDelayDictionary(ascanNum, ascanPort, type, val);
            return error_code;
        }

        public static void setDelayDictionary(uint ascanNum, uint ascanPort, GateType type, double delay)
        {
            SessionInfo info = SessionHardWare.getSessionAttr((int)ascanNum);
            if (info == null)
                return;
            int classNum = (int)info.myHardInfo.ClassicNum;
            int slotNum = (int)info.myHardInfo.SlotNum;
            int upPort = (classNum << 16) + (slotNum << 8) + (int)ascanPort;

            switch (type)
            {
                case GateType.I:
                    delayForGateI[upPort] = delay;
                    break;
                case GateType.A:
                    delayForGateA[upPort] = delay;
                    break;
                case GateType.B:
                    delayForGateB[upPort] = delay;
                    break;
                case GateType.C:
                    delayForGateC[upPort] = delay;
                    break;
            }
        }

        public static double getDelayDictionary(int upPort, int type)
        {
            double delay = -1;
            switch (type)
            {
                case (int)GateType.I:
                    if (delayForGateI.ContainsKey((int)upPort))
                        delay = delayForGateI[upPort];
                    break;
                case (int)GateType.A:
                    if (delayForGateA.ContainsKey((int)upPort))
                        delay = delayForGateA[upPort];
                    break;
                case (int)GateType.B:
                    if (delayForGateB.ContainsKey((int)upPort))
                        delay = delayForGateB[upPort];
                    break;
                case (int)GateType.C:
                    if (delayForGateC.ContainsKey((int)upPort))
                        delay = delayForGateC[upPort];
                    break;
            }
            return delay;
        }

        public static int Width(uint ascanNum, uint ascanPort, GateType type, double width)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].Width;
            double val = width;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Width of gate failed", "错误：设置门的宽度失败");
                return error_code;
            }
            setWidthDictionary(ascanNum, ascanPort, type, width);
            return error_code;
        }

        public static void setWidthDictionary(uint ascanNum, uint ascanPort, GateType type, double width)
        {
            SessionInfo info = SessionHardWare.getSessionAttr((int)ascanNum);
            if (info == null)
                return;
            int classNum = (int)info.myHardInfo.ClassicNum;
            int slotNum = (int)info.myHardInfo.SlotNum;
            int upPort = (classNum << 16) + (slotNum << 8) + (int)ascanPort;

            switch (type)
            {
                case GateType.I:
                    widthForGateI[upPort] = width;
                    break;
                case GateType.A:
                    widthForGateA[upPort] = width;
                    break;
                case GateType.B:
                    widthForGateB[upPort] = width;
                    break;
                case GateType.C:
                    widthForGateC[upPort] = width;
                    break;
            }
        }

        public static double getWidthDictionary(int upPort, int type)
        {
            double width = -1;
            switch (type)
            {
                case (int)GateType.I:
                    if (widthForGateI.ContainsKey((int)upPort))
                        width = widthForGateI[upPort];
                    break;
                case (int)GateType.A:
                    if (widthForGateA.ContainsKey((int)upPort))
                        width = widthForGateA[upPort];
                    break;
                case (int)GateType.B:
                    if (widthForGateB.ContainsKey((int)upPort))
                        width = widthForGateB[upPort];
                    break;
                case (int)GateType.C:
                    if (widthForGateC.ContainsKey((int)upPort))
                        width = widthForGateC[upPort];
                    break;
            }
            return width;
        }

        public static int Threshold(uint ascanNum, uint ascanPort, GateType type, double threshold)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].Threshold;
            double val = threshold;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Threshold of gate failed", "错误：设置门的高度失败");
            }
            return error_code;
        }

        public static int iFActive(uint ascanNum, uint ascanPort, GateType type, IFActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].IF;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set IF Gate failed!", "错误：设置IF Gate失败!");
            }
            return error_code;
        }

        public  static int tofMode(uint ascanNum, uint ascanPort, GateType type, TofMode mode)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TofMode;
            uint val = (uint)mode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set TOF Mode failed!", "错误:设置TOF Mode失败!");
            }
            return error_code;
        }
        
        public static bool setTofMode(uint sessionIndex, uint port, GateType gateNum, TofMode tofMode)
        {
            int error_code;
            bool isSetPre = false;
            AscanWaveDectionMode waveMode = AscanWaveDectionMode.Rf;
            IFActive iFGate = IFActive.OFF;

            error_code = GetGateDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref iFGate);
            if (error_code != 0)
                return isSetPre = true;

            error_code = GetAsacnVideoDAQ.DetectionWaveMode(SelectAscan.sessionIndex, SelectAscan.port, ref waveMode);
            if (error_code != 0)
                return isSetPre = true;

            if (tofMode == TofMode.ZeroAfter || tofMode == TofMode.ZeroBefore)
            {
                if (waveMode != AscanWaveDectionMode.Rf)
                {
                    MessageShow.show("Warn:TOF Mode = Zero Befor,Need to set Wave Mode->RF Mode!",
                                       "警告：TOF模式为Zero Befor，必须设置检波模式为RF模式");
                    return isSetPre = true;
                }
                else if ((gateNum == GateType.I) && (iFGate == IFActive.ON))
                {
                    MessageShow.show("Warn:The function of IF Gate or IF Start has opened, can't Set!",
                                      "警告：IF Gate 或 IF Start功能开启，不能设置!");
                    return isSetPre = true;
                }
            }
            else if (tofMode == TofMode.Peak)
            {
                if ((gateNum == GateType.I) && (iFGate == IFActive.ON))
                {
                    MessageShow.show("Warn:The function of IF Gate or IF Start has opened, can't Set!",
                                     "警告:IF Gate 或 IF Start功能开启，不能设置!");
                    return isSetPre = true;
                }
            }

            error_code = SetGateDAQ.tofMode(SelectAscan.sessionIndex, SelectAscan.port, gateNum, tofMode);
            if (error_code != 0)
                return isSetPre = true;

            return isSetPre;
        }

        public static int DnsActive(uint ascanNum, uint ascanPort, GateType type, DNSActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Dns Active failed!", "错误:设置Dns Active失败!");
            }
            return error_code;
        }

        public static int DnsBw(uint ascanNum, uint ascanPort, GateType type, double dnsBw)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsBw;
            double val = dnsBw;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the dns Band width failed!", "错误:设置BNS Bandwidth失败!");
            }
            return error_code;
        }

        public static int DnsStart(uint ascanNum, uint ascanPort, GateType type, double dnsStart)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsStart;
            double val = dnsStart;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the the dns Band start failed!", "错误:设置BNS start失败!");
            }
            return error_code;
        }

        public static int DnsStep(uint ascanNum, uint ascanPort, GateType type, double dnsStep)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsSetp;
            double val = dnsStep;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the dns Band step failed!", "错误:设置BNS step失败!");
            }
            return error_code;
        }

        public static int AlarmLogic(uint ascanNum, uint ascanPort, GateType type, GateAlarmLogic logic)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmLogic;
            uint val = (uint)logic;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Gate Alarm Logic failed!", "错误:设置Gate Alarm Logic失败!");
            }
            return error_code;
        }

        /**get gate suppress counter active*/
        public static int ScActive(uint ascanNum, uint ascanPort, GateType type, SuppressCounterActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].ScActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Active of Suppress Counter failed!", "错误:设置Suppress Counter Active失败!");
            }
            return error_code;
        }

        public static int ScCounter(uint ascanNum, uint ascanPort, GateType type, uint cnt)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].ScCounter;
            uint val = cnt;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Suppress Counter failed!", "错误:设置Suppress Counter失败!");
            }
            return error_code;
        }

        /**get dynamic threld suppression (dts) active*/
        public static int DtsActive(uint ascanNum, uint ascanPort, GateType type, DTSActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Dts Active failed!", "错误:设置Dts Active失败!");
            }
            return error_code;
        }

        public static int DtsBand(uint ascanNum, uint ascanPort, GateType type, double dtsBand)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsBand;
            double val = dtsBand;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the dts Band failed!", "错误:设置BTS band失败!");
            }
            return error_code;
        }

        public static int DtsStart(uint ascanNum, uint ascanPort, GateType type, double start)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsStart;
            double val = start;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the dts Start failed!", "错误:设置BTS start失败!");
            }
            return error_code;
        }

        public static int DtsStep(uint ascanNum, uint ascanPort, GateType type, double step)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsStep;
            double val = step;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the dts Step failed!", "错误:设置BTS step失败!");
            }
            return error_code;
        }

        //tolerance monitor(TM) active
        public static int TolMonitorActive(uint ascanNum, uint ascanPort, GateType type, TMActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Tolerance Monitor Active failed!", "错误:设置Tolerance Monitor Active失败!");
            }
            return error_code;
        }

        public static int TolMonitorMax(uint ascanNum, uint ascanPort, GateType type, double max)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorMax;
            double val = max;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Tolerance Monitor Max failed!", "错误:设置Tolerance Monitor Max失败!");
            }
            return error_code;
        }

        public static int TolMonitorMin(uint ascanNum, uint ascanPort, GateType type, double min)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorMax;
            double val = min;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Tolerance Monitor Min failed!", "错误:设置Tolerance Monitor Min失败!");
            }
            return error_code;
        }

        /**TM suppress counter(TMSc)*/
        public static int TolMonitorSc(uint ascanNum, uint ascanPort, GateType type, uint cnt)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorSc;
            uint val = cnt;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Tolerance Monitor Suppress Counter failed!", "错误:设置Tolerance Monitor Suppress Counter失败!");
            }
            return error_code;
        }

        public static int AlarmActive(uint ascanNum, uint ascanPort, GateType type, GateAlarmActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Alarm Active failed!", "错误:设置Alarm active失败!");
            }
            return error_code;
        }

        public static int AlarmMode(uint ascanNum, uint ascanPort, GateType type, GateAlarmMode mode)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmMode;
            uint val = (uint)mode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set Alarm Mode failed!", "错误:设置Alarm Mode失败!");
            }
            return error_code;
        }

        public static int AlarmSignalLength(uint ascanNum, uint ascanPort, GateType type, GateAlarmSignalLength len)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmSignalLength;
            uint val = (uint)len;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Gate alarm signal length failed!", "错误:设置Gate alarm signal length失败!");
            }
            return error_code;
        }

        ////public static int AlarmTimeLength(uint ascanNum, uint ascanPort, GateType type, ref GateAlarmSignalLength len)
        //{
        //    int error_code;
        //    int gateNum = (int)type;
        //    uint attr = DaqAttrType.gate[gateNum].AlarmActive;
        //    uint val = (uint)len;

        //    if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
        //    {
        //        error_code = -1;
        //        return error_code;
        //    }

        //    if (type < gateTypeMin || type > gateTypeMax)
        //    {
        //        error_code = -1;
        //        return error_code;
        //    }

        //    error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
        //    if (error_code != (int)PDAQ_ERR.GOOD)
        //    {
        //        MessageShow.show("Error:Get the Gate alarm signal length failed!", "错误:获取Gate alarm signal length失败!");
        //    }
        //    return error_code;
        //}

        public static int AlarmActiveLevel(uint ascanNum, uint ascanPort, GateType type, GateAlarmLevel level)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmActiveLevel;
            uint val = (uint)level;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set alarm active level failed!", "错误:设置Alarm active level失败!");
            }
            return error_code;
        }

        /**gate measment active*/
        public static int MeasActive(uint ascanNum, uint ascanPort, GateType type, MeasActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].MeasActive;
            uint val = (uint)active;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Gate measment active failed!", "错误:设置Gate measment active失败!");
            }
            return error_code;
        }

        /**gate measment mode, pls see MeasMode Enum for part of list*/
        public static int MeasMode(uint ascanNum, uint ascanPort, GateType type, MeasMode mode)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].MeasMode;
            uint val = (uint)mode;

            if (ascanNum < ascanNumMin || ascanNum > ascanNumMax)
            {
                error_code = -1;
                return error_code;
            }

            if (type < gateTypeMin || type > gateTypeMax)
            {
                error_code = -1;
                return error_code;
            }

            error_code = DAQ.daqSet(ascanNum, ascanPort, attr, val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Set the Gate measment mode failed!", "错误:设置Gate measment mode失败!");
            }
            return error_code;
        }
    }
}
