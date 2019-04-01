using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ascan
{
    public class GetGateDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        private const GateType gateTypeMin = GateType.I;
        private const GateType gateTypeMax = GateType.C;

        public static int Delay(uint ascanNum, uint ascanPort, GateType type, ref double delay)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].Delay;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Delay of gate failed", "错误：获得门的起始位置失败");
                return error_code;
            }
            delay = val;
            SetGateDAQ.setDelayDictionary(ascanNum, ascanPort, type, delay);
            return error_code;
        }

        public static int Width(uint ascanNum, uint ascanPort, GateType type, ref double width)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].Width;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Width of gate failed", "错误：获得门的宽度失败");
                return error_code;
            }
            width = val;
            SetGateDAQ.setWidthDictionary(ascanNum, ascanPort, type, width);
            return error_code;
        }

        public static int Threshold(uint ascanNum, uint ascanPort, GateType type, ref double threshold)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].Threshold;
            double val = 0;

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

            error_code = DAQ.daqGet((uint)ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Threshold of gate failed", "错误：获得门的高度失败");
            }
            threshold = val;
            return error_code;
        }

        public static int IFActive(uint ascanNum, uint ascanPort, GateType type, ref IFActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].IF;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get IF Gate failed!", "错误：获得IF Gate失败!");
            }
            active = (IFActive)val;
            return error_code;
        }

        public static int TofMode(uint ascanNum, uint ascanPort, GateType type, ref TofMode mode)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TofMode;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get TOF Mode failed!", "错误:获取TOF Mode失败!");
            }
            mode = (TofMode)val;
            return error_code;
        }

        public static int DnsActive(uint ascanNum, uint ascanPort, GateType type, ref DNSActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsActive;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Dns Active failed!", "错误:获取Dns Active失败!");
            }
            active = (DNSActive)val;
            return error_code;
        }

        public static int DnsBw(uint ascanNum, uint ascanPort, GateType type, ref double dnsBw)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsBw;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the dns Band width failed!", "错误:获取BNS Bandwidth失败!");
            }
            dnsBw = val;
            return error_code;
        }

        public static int DnsStart(uint ascanNum, uint ascanPort, GateType type, ref double dnsStart)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsStart;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the the dns Band start failed!", "错误:获取BNS start失败!");
            }
            dnsStart = val;
            return error_code;
        }

        public static int DnsStep(uint ascanNum, uint ascanPort, GateType type, ref double dnsStep)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DnsSetp;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the dns Band step failed!", "错误:获取BNS step失败!");
            }
            dnsStep = val;
            return error_code;
        }

        public static int AlarmLogic(uint ascanNum, uint ascanPort, GateType type, ref GateAlarmLogic logic)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmLogic;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Gate Alarm Logic failed!", "错误:获取Gate Alarm Logic失败!");
            }
            logic = (GateAlarmLogic)val;
            return error_code;
        }

        /**get gate suppress counter active*/
        public static int ScActive(uint ascanNum, uint ascanPort, GateType type, ref SuppressCounterActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].ScActive;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Active of Suppress Counter failed!", "错误:获取Suppress Counter Active失败!");
            }
            active = (SuppressCounterActive)val;
            return error_code;
        }

        public static int ScCounter(uint ascanNum, uint ascanPort, GateType type, ref uint cnt)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].ScCounter;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Suppress Counter failed!", "错误:获取Suppress Counter失败!");
            }
            cnt = val;
            return error_code;
        }

        /**get dynamic threld suppression (dts) active*/
        public static int DtsActive(uint ascanNum, uint ascanPort, GateType type, ref DTSActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsActive;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Dts Active failed!", "错误:获取Dts Active失败!");
            }
            active = (DTSActive)val;
            return error_code;
        }

        public static int DtsBand(uint ascanNum, uint ascanPort, GateType type, ref double dtsBand)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsBand;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the dts Band failed!", "错误:获取BTS band失败!");
            }
            dtsBand = val;
            return error_code;
        }

        public static int DtsStart(uint ascanNum, uint ascanPort, GateType type, ref double start)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsStart;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the dts Start failed!", "错误:获取BTS start失败!");
            }
            start = val;
            return error_code;
        }

        public static int DtsStep(uint ascanNum, uint ascanPort, GateType type, ref double step)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].DtsStep;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the dts Step failed!", "错误:获取BTS step失败!");
            }
            step = val;
            return error_code;
        }

        //tolerance monitor(TM) active
        public static int TolMonitorActive(uint ascanNum, uint ascanPort, GateType type, ref TMActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorActive;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Tolerance Monitor Active failed!", "错误:获取Tolerance Monitor Active失败!");
            }
            active = (TMActive)val;
            return error_code;
        }

        public static int TolMonitorMax(uint ascanNum, uint ascanPort, GateType type, ref double max)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorMax;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Tolerance Monitor Max failed!", "错误:获取Tolerance Monitor Max失败!");
            }
            max = val;
            return error_code;
        }

        public static int TolMonitorMin(uint ascanNum, uint ascanPort, GateType type, ref double min)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorMax;
            double val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Tolerance Monitor Min failed!", "错误:获取Tolerance Monitor Min失败!");
            }
            min = val;
            return error_code;
        }

        /**TM suppress counter(TMSc)*/
        public static int TolMonitorSc(uint ascanNum, uint ascanPort, GateType type, ref uint cnt)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].TolMonitorSc;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Tolerance Monitor Suppress Counter failed!", "错误:获取Tolerance Monitor Suppress Counter失败!");
            }
            cnt = val;
            return error_code;
        }

        public static int AlarmActive(uint ascanNum, uint ascanPort, GateType type, ref GateAlarmActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmActive;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Alarm Active failed!", "错误:获取Alarm active失败!");
            }
            active = (GateAlarmActive)val;
            return error_code;
        }

        public static int AlarmMode(uint ascanNum, uint ascanPort, GateType type, ref GateAlarmMode mode)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmMode;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get Alarm Mode failed!", "错误:获取Alarm Mode失败!");
            }
            mode = (GateAlarmMode)val;
            return error_code;
        }

        public static int AlarmSignalLength(uint ascanNum, uint ascanPort, GateType type, ref GateAlarmSignalLength len)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmSignalLength;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Gate alarm signal length failed!", "错误:获取Gate alarm signal length失败!");
            }
            len = (GateAlarmSignalLength)val;
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

        public static int AlarmActiveLevel(uint ascanNum, uint ascanPort, GateType type, ref GateAlarmLevel level)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].AlarmActiveLevel;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get alarm active level failed!", "错误:获取Alarm active level失败!");
            }
            level = (GateAlarmLevel)val;
            return error_code;
        }

        /**gate measment active*/
        public static int MeasActive(uint ascanNum, uint ascanPort, GateType type, ref MeasActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].MeasActive;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Gate measment active failed!", "错误:获取Gate measment active失败!");
            }
            active = (MeasActive)val;
            return error_code;
        }

        /**gate measment mode, pls see MeasMode Enum for part of list*/
        public static int MeasMode(uint ascanNum, uint ascanPort, GateType type, ref MeasMode mode)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.gate[gateNum].MeasMode;
            uint val = 0;

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

            error_code = DAQ.daqGet(ascanNum, ascanPort, attr, ref val);
            if (error_code != (int)PDAQ_ERR.GOOD)
            {
                MessageShow.show("Error:Get the Gate measment mode failed!", "错误:获取Gate measment mode失败!");
            }
            mode = (MeasMode)val;
            return error_code;
        }
    }
}
