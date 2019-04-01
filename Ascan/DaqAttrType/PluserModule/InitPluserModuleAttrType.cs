using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitPluserModuleAttrType
    {
        /**Read PluserModuleAttrType form PulserTransmit.xml*/
        public static void read()
        {
            StrPluserModule param;

            PluserModuleXml pluserModuleXml = SystemConfig.DeserializeFromXml<PluserModuleXml>("DaqAttrTypeXml/PluserModule.xml");

            if (pluserModuleXml == null)
            {
                MessageShow.show("Get pluser module parameter from PluserModule.xml failed",
                    "从PluserModule.xml获取接口地址失败");
                return;
            }
            param = pluserModuleXml.pluserModule.Param;

            DaqAttrType.pluserModule.Mode = addAddress(param.Mode, DaqAttrType.baseAddr);
            DaqAttrType.pluserModule.TimeBase = addAddress(param.TimeBase, DaqAttrType.baseAddr);
            DaqAttrType.pluserModule.RearmSource = addAddress(param.RearmSource, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
