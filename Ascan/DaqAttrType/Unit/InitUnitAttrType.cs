using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitUnitAttrType
    {
        /**Read UnitAttrType form Tesout.xml*/
        public static void read()
        {
            StrUnit param;

            UnitXml unitXml = SystemConfig.DeserializeFromXml<UnitXml>("DaqAttrTypeXml/Unit.xml");

            if (unitXml == null)
            {
                MessageShow.show("Get unit parameter from Unit.xml failed",
                    "从Unit.xml获取接口地址失败");
                return;
            }
            param = unitXml.unit.Param;

            DaqAttrType.unit.Tof = addAddress(param.Tof, DaqAttrType.baseAddr);
            DaqAttrType.unit.Amp = addAddress(param.Amp, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
