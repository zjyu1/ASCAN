using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitPowerAttrType
    {
        /**Read PowerAttrType form Power.xml*/
        public static void read()
        {
            StrPower param;

            PowerXml powerXml = SystemConfig.DeserializeFromXml<PowerXml>("DaqAttrTypeXml/Power.xml");

            if (powerXml == null)
            {
                MessageShow.show("Get power parameter from Power.xml failed",
                    "从Power.xml获取接口地址失败");
                return;
            }
            param = powerXml.power.Param;

            DaqAttrType.power.Hv = addAddress(param.Hv, DaqAttrType.baseAddr);
            DaqAttrType.power.Optocoupler = addAddress(param.Optocoupler, DaqAttrType.baseAddr);
            DaqAttrType.power.Opa = addAddress(param.Opa, DaqAttrType.baseAddr);
            DaqAttrType.power.Testout = addAddress(param.Testout, DaqAttrType.baseAddr);
            DaqAttrType.power.Power12vp = addAddress(param.Power12vp, DaqAttrType.baseAddr);
            DaqAttrType.power.Ethernet = addAddress(param.Ethernet, DaqAttrType.baseAddr);
            DaqAttrType.power.Serial = addAddress(param.Serial, DaqAttrType.baseAddr);
   
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
