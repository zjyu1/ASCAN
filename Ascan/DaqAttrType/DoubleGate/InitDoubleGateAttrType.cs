using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitDGateAttrType
    {
        /**Read DoubleGateAtrrType form DoubleGate.xml*/
        public static void read()
        {
            //gate quatity
            int cnt = 0;
            StrDGate param;

            DGateXml gateXml = SystemConfig.DeserializeFromXml<DGateXml>("DaqAttrTypeXml/DoubleGate.xml");
            cnt = gateXml.DGates.Count;

            if (cnt != 4)
            {
                MessageShow.show("Double gate quatity not equal 4, pls check DoubleGate.xml!",
                                  "DoubleGate.xml 中的门的数量不等于4，请检查");
                return;
            }
            DaqAttrType.dGate = new DGateAttrType[cnt];

            for (int i = 0; i < cnt; i++)
            {
                param = gateXml.DGates[i].Param;

                DaqAttrType.dGate[i].TolMonitorActive = addAddress(param.TolMonitorActive, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].TolMonitorMax = addAddress(param.TolMonitorMax, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].TolMonitorMin = addAddress(param.TolMonitorMin, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].TolMonitorSc = addAddress(param.TolMonitorSc, DaqAttrType.baseAddr);

                DaqAttrType.dGate[i].AlarmActive = addAddress(param.AlarmActive, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].AlarmMode = addAddress(param.AlarmMode, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].AlarmSignalLength = addAddress(param.AlarmSignalLength, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].AlarmTimeLength = addAddress(param.AlarmTimeLength, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].AlarmLevel = addAddress(param.AlarmLevel, DaqAttrType.baseAddr);

                DaqAttrType.dGate[i].MeasActive = addAddress(param.MeasActive, DaqAttrType.baseAddr);
                DaqAttrType.dGate[i].MeasMode = addAddress(param.MeasMode, DaqAttrType.baseAddr);
            }
        }


        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
