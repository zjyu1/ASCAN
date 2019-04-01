using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitGateAtrrType
    {
        /**Read GateAtrrType form Gate.xml*/
        public static void read()
        {
            //gate quatity
            int cnt = 0;
            StrGate param;

            GateXml gateXml = SystemConfig.DeserializeFromXml<GateXml>("DaqAttrTypeXml/Gate.xml");
            cnt = gateXml.Gates.Count; 

            if (cnt != 4)
            {
                MessageShow.show("Gate quatity not equal 4, pls check Gate.xml!",
                                  "Gate.xml 中的门的数量不等于4，请检查");
                return;
            }
            DaqAttrType.gate = new GateAttrType[gateXml.Gates.Count];

            for (int i = 0; i < gateXml.Gates.Count; i++)
            {
                param = gateXml.Gates[i].Param;

                DaqAttrType.gate[i].Delay = addAddress(param.Delay, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].Width = addAddress(param.Width, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].Threshold = addAddress(param.Threshold, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].IF = addAddress(param.IF, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].TofMode = addAddress(param.TofMode, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].DnsActive = addAddress(param.DnsActive, DaqAttrType.baseAddr);

                DaqAttrType.gate[i].DnsBw = addAddress(param.DnsBw, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].DnsStart = addAddress(param.DnsStart, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].DnsSetp = addAddress(param.DnsSetp, DaqAttrType.baseAddr);

                DaqAttrType.gate[i].AlarmLogic = addAddress(param.AlarmLogic, DaqAttrType.baseAddr);

                DaqAttrType.gate[i].ScActive = addAddress(param.ScActive, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].ScCounter = addAddress(param.ScCounter, DaqAttrType.baseAddr);

                DaqAttrType.gate[i].DtsActive = addAddress(param.DtsActive, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].DtsBand = addAddress(param.DtsBand, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].DtsStart = addAddress(param.DtsStart, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].DtsStep = addAddress(param.DtsStep, DaqAttrType.baseAddr);

                DaqAttrType.gate[i].TolMonitorActive = addAddress(param.TolMonitorActive, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].TolMonitorMax = addAddress(param.TolMonitorMax, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].TolMonitorMin = addAddress(param.TolMonitorMin, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].TolMonitorSc = addAddress(param.TolMonitorSc, DaqAttrType.baseAddr);

                DaqAttrType.gate[i].AlarmActive = addAddress(param.AlarmActive, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].AlarmMode = addAddress(param.AlarmMode, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].AlarmSignalLength = addAddress(param.AlarmSignalLength, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].AlarmTimeLength = addAddress(param.AlarmTimeLength, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].AlarmActiveLevel = addAddress(param.AlarmActiveLevel, DaqAttrType.baseAddr);

                DaqAttrType.gate[i].MeasActive = addAddress(param.MeasActive, DaqAttrType.baseAddr);
                DaqAttrType.gate[i].MeasMode = addAddress(param.MeasMode, DaqAttrType.baseAddr);

            }
        }


        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
