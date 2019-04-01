using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public partial class GateCfg
    {
        /**Read parameter from board,then,save to Gate.xml*/
        public static int save(uint ascanNum, uint ascanPort,string filePath)
        {
            int error_code = 0;
            string fileName = filePath + @"\Gate.xml";
            GateType gateType;
            PGateXml gateXml = new PGateXml();
            gateXml.Gates = new List<PGateItem>();
            PGateItem gateItem = new PGateItem();
            PGate gate = new PGate();

            for (int i = 0; i < 4; i++)
            {
                gateType = (GateType)i;
                error_code = getGate(ascanNum, ascanPort, gateType, ref gate);
                if (error_code != 0)
                {
                    return error_code;
                }
                
                gateItem.name = "Gate"+gateType.ToString();
                gateItem.Param = gate;

                gateXml.Gates.Add(gateItem);
            }
            SystemConfig.SerializeToXml(fileName, gateXml);

            return error_code;
        }

        /**Get Gate DAQ*/
        private static int getGate(uint ascanNum, uint ascanPort,GateType gateType, ref PGate param)
        {
            int error_code;

            error_code = GetGateDAQ.Delay(ascanNum, ascanPort, gateType, ref param.Delay);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.Width(ascanNum, ascanPort, gateType, ref param.Width);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.Threshold(ascanNum, ascanPort, gateType, ref param.Threshold);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.IFActive(ascanNum, ascanPort, gateType, ref param.IF);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.TofMode(ascanNum, ascanPort, gateType, ref param.TofMode);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DnsActive(ascanNum, ascanPort, gateType, ref param.DnsActive);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DnsBw(ascanNum, ascanPort, gateType, ref param.DnsBw);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DnsStart(ascanNum, ascanPort, gateType, ref param.DnsStart);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DnsStep(ascanNum, ascanPort, gateType, ref param.DnsStep);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.AlarmLogic(ascanNum, ascanPort, gateType, ref param.AlarmLogic);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.ScActive(ascanNum, ascanPort, gateType, ref param.ScActive);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.ScCounter(ascanNum, ascanPort, gateType, ref param.ScCounter);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DtsActive(ascanNum, ascanPort, gateType, ref param.DtsActive);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DtsBand(ascanNum, ascanPort, gateType, ref param.DtsBand);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DtsStart(ascanNum, ascanPort, gateType, ref param.DtsStart);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.DtsStep(ascanNum, ascanPort, gateType, ref param.DtsStep);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.TolMonitorActive(ascanNum, ascanPort, gateType, ref param.TolMonitorActive);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.TolMonitorMax(ascanNum, ascanPort, gateType, ref param.TolMonitorMax);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.TolMonitorMin(ascanNum, ascanPort, gateType, ref param.TolMonitorMin);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.TolMonitorSc(ascanNum, ascanPort, gateType, ref param.TolMonitorSc);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.AlarmActive(ascanNum, ascanPort, gateType, ref param.AlarmActive);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.AlarmMode(ascanNum, ascanPort, gateType, ref param.AlarmMode);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.AlarmSignalLength(ascanNum, ascanPort, gateType, ref param.AlarmSignalLength);
            if (error_code != 0)
                return error_code;

            //error_code = SetGateDAQ.AlarmTimeLength(ascanNum, gateType, param.);
            //if (error_code != 0)
            //    return error_code;

            error_code = GetGateDAQ.AlarmActiveLevel(ascanNum, ascanPort, gateType, ref param.AlarmActiveLevel);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.MeasActive(ascanNum, ascanPort, gateType, ref param.MeasActive);
            if (error_code != 0)
                return error_code;

            error_code = GetGateDAQ.MeasMode(ascanNum, ascanPort, gateType, ref param.MeasMode);
            if (error_code != 0)
                return error_code;
            return error_code;
        }
    }
}
