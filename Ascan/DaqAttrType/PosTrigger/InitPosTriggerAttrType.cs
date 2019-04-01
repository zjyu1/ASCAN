using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitPosTriggerAttrType
    {
        /**Read PosTriggerAttrType form PosTrigger.xml*/
        public static void read()
        {
            StrPosTrigger param;

            PosTriggerXml posTriggerXml = SystemConfig.DeserializeFromXml<PosTriggerXml>("DaqAttrTypeXml/PosTrigger.xml");

            if (posTriggerXml == null)
            {
                MessageShow.show("Get pos trigger parameter from PosTrigger.xml failed",
                    "从PosTrigger.xml获取接口地址失败");
                return;
            }
            param = posTriggerXml.posTrigger.Param;

            DaqAttrType.posTrigger.PosTriggerSource = addAddress(param.PosTriggerSource, DaqAttrType.baseAddr);
            DaqAttrType.posTrigger.EncoderTriggerSource = addAddress(param.EncoderTriggerSource, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
