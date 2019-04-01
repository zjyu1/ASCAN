using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public partial class GateCfg
    {
        /**Read Gate parmameters from Gate.xml, then, set parameters to board*/
        public static int load(uint ascanNum, uint ascanPort,string filePath)
        {       
            //gate quatity
            int cnt = 0;
            int error_code = 0;
            GateType gateType;
            PGate param;
            string fileName = filePath + @"\Gate.xml";
            PGateXml gateXml = SystemConfig.DeserializeFromXml<PGateXml>(fileName);
            if (gateXml == null)
                return error_code = -1;

            cnt = gateXml.Gates.Count;

            for (int i = 0; i < cnt; i++)
            {
                param = gateXml.Gates[i].Param;
                gateType = (GateType)i;

                error_code = setGate(ascanNum, ascanPort, gateType, param);
                if (error_code != 0)
                    return error_code;
            }
            return error_code;
        }

        /**Set Gate DAQ*/
        private static int setGate(uint ascanNum, uint ascanPort, GateType gateType, PGate param)
        {
            int error_code;

            error_code = SetGateDAQ.Delay(ascanNum, ascanPort, gateType, param.Delay);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.Width(ascanNum, ascanPort, gateType, param.Width);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.Threshold(ascanNum, ascanPort, gateType, param.Threshold);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.iFActive(ascanNum, ascanPort, gateType, param.IF);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.tofMode(ascanNum, ascanPort, gateType, param.TofMode);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DnsActive(ascanNum, ascanPort, gateType, param.DnsActive);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DnsBw(ascanNum, ascanPort, gateType, param.DnsBw);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DnsStart(ascanNum, ascanPort, gateType, param.DnsStart);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DnsStep(ascanNum, ascanPort, gateType, param.DnsStep);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.AlarmLogic(ascanNum, ascanPort, gateType, param.AlarmLogic);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.ScActive(ascanNum, ascanPort, gateType, param.ScActive);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.ScCounter(ascanNum, ascanPort, gateType, param.ScCounter);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DtsActive(ascanNum, ascanPort, gateType, param.DtsActive);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DtsBand(ascanNum, ascanPort, gateType, param.DtsBand);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DtsStart(ascanNum, ascanPort, gateType, param.DtsStart);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.DtsStep(ascanNum, ascanPort, gateType, param.DtsStep);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.TolMonitorActive(ascanNum, ascanPort, gateType, param.TolMonitorActive);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.TolMonitorMax(ascanNum, ascanPort, gateType, param.TolMonitorMax);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.TolMonitorMin(ascanNum, ascanPort, gateType, param.TolMonitorMin);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.TolMonitorSc(ascanNum, ascanPort, gateType, param.TolMonitorSc);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.AlarmActive(ascanNum, ascanPort, gateType, param.AlarmActive);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.AlarmMode(ascanNum, ascanPort, gateType, param.AlarmMode);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.AlarmSignalLength(ascanNum, ascanPort, gateType, param.AlarmSignalLength);
            if (error_code != 0)
                return error_code;

            //error_code = SetGateDAQ.AlarmTimeLength(ascanNum, gateType, param.);
            //if (error_code != 0)
            //    return error_code;

            error_code = SetGateDAQ.AlarmActiveLevel(ascanNum, ascanPort, gateType, param.AlarmActiveLevel);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.MeasActive(ascanNum, ascanPort, gateType, param.MeasActive);
            if (error_code != 0)
                return error_code;

            error_code = SetGateDAQ.MeasMode(ascanNum, ascanPort, gateType, param.MeasMode);
            if (error_code != 0)
                return error_code;
            return error_code;
        }
    }
}
