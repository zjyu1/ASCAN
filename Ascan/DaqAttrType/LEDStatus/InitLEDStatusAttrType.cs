using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitLEDStatusAttrType
    {
        /**Read LEDStatusAttrType form LEDStatus.xml*/
        public static void read()
        {
            StrLEDStatus param;

            LEDStatusXml LEDStatusXml = SystemConfig.DeserializeFromXml<LEDStatusXml>("DaqAttrTypeXml/LEDStatus.xml");

            if (LEDStatusXml == null)
            {
                MessageShow.show("Get LED status parameter from LEDStatus.xml failed",
                    "从LEDStatus.xml获取接口地址失败");
                return;
            }
            param = LEDStatusXml.LEDStatus.Param;


            DaqAttrType.ledStatus.Run = addAddress(param.Run, DaqAttrType.baseAddr);
            DaqAttrType.ledStatus.SysFail = addAddress(param.SysFail, DaqAttrType.baseAddr);
            DaqAttrType.ledStatus.Acess = addAddress(param.Acess, DaqAttrType.baseAddr);
            DaqAttrType.ledStatus.Fail = addAddress(param.Fail, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
