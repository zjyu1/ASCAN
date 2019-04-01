using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class GetDGateDAQ
    {
        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        private const DGateType gateTypeMin = DGateType.BA;
        private const DGateType gateTypeMax = DGateType.CI;

        public static int TolMonitorActive(uint ascanNum, uint ascanPort, DGateType type, ref TMActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].TolMonitorActive;
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
                MessageShow.show("Error:Get tolerance monitor active of double gate failed！", "错误：获得门的容限误差使能失败！");
            }
            active = (TMActive)val;
            return error_code;
        }

        public static int TolMonitorMax(uint ascanNum, uint ascanPort, DGateType type, ref double tolMonitorMax)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].TolMonitorMax;
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
                MessageShow.show("Error:Get tolerance monitor max of double gate failed！", "错误：获得门的最大容限误差失败！");
            }
            tolMonitorMax = val;
            return error_code;
        }

        public static int TolMonitorMin(uint ascanNum, uint ascanPort, DGateType type, ref double tolMonitorMin)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].TolMonitorMin;
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
                MessageShow.show("Error:Get tolerance monitor min of double gate failed！", "错误：获得门的最小容限误差失败！");
            }
            tolMonitorMin = val;
            return error_code;
        }

        public static int TolMonitorSc(uint ascanNum, uint ascanPort, DGateType type, ref uint tolMonitorSc)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].TolMonitorSc;
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
                MessageShow.show("Error:Get tolerance monitor suppresser count of double gate failed！", "错误：获得门的容限误差计数失败！");
            }
            tolMonitorSc = val; 
            return error_code;
        }

        public static int AlarmActive(uint ascanNum, uint ascanPort, DGateType type, ref GateAlarmActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].AlarmActive;
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
                MessageShow.show("Error:Get alarm active of double gate failed！", "错误：获得门的报警使能失败！");
            }
            active = (GateAlarmActive)val;
            return error_code;
        }

        //需要确定
        //public static int AlarmMode(uint ascanNum, uint ascanPort, GateType type, GateAlarmActive active)
        //{
        //    int error_code;
        //    int gateNum = (int)type;
        //    uint attr = DaqAttrType.dGate[gateNum].AlarmActive;
        //    uint val = 0;

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
        //        MessageShow.show("Error:Get alarm active double gate failed！", "错误：获得门的报警使能失败！");
        //    }
        //    active = (GateAlarmActive)val;
        //    return error_code;
        //}

        public static int AlarmSignalLength(uint ascanNum, uint ascanPort, DGateType type, ref GateAlarmSignalLength length)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].AlarmSignalLength;
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
                MessageShow.show("Error:Get alarm singal length of double gate failed！", "错误：获得门的报警信号长度失败！");
            }
            length = (GateAlarmSignalLength)val;
            return error_code;
        }

        public static int AlarmLevel(uint ascanNum, uint ascanPort, DGateType type, GateAlarmLevel level)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].AlarmLevel;
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
                MessageShow.show("Error:Get alarm level of double gate failed！", "错误：获得门的报警等级失败！");
            }
            level = (GateAlarmLevel)val;
            return error_code;
        }

        public static int MeasActive(uint ascanNum, uint ascanPort, DGateType type, MeasActive active)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].MeasActive;
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
                MessageShow.show("Error:Get measurement active of double gate failed！", "错误：获得门的测量使能失败！");
            }
            active = (MeasActive)val;
            return error_code;
        }

        public static int MeasMode(uint ascanNum, uint ascanPort, DGateType type, MeasMode mode)
        {
            int error_code;
            int gateNum = (int)type;
            uint attr = DaqAttrType.dGate[gateNum].MeasMode;
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
                MessageShow.show("Error:Get measurement mode of double gate failed！", "错误：获得门的测量模式失败！");
            }
            mode = (MeasMode)val;
            return error_code;
        }
    }
}
