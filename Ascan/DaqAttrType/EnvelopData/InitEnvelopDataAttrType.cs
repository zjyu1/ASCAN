using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitEnvelopDataAttrType
    {
        /**Read EnvelopDataAttrType form EnvelopData.xml*/
        public static void read()
        {
            StrEnvelopData param;

            EnvelopDataXml envelopDataXml = SystemConfig.DeserializeFromXml<EnvelopDataXml>("DaqAttrTypeXml/EnvelopData.xml");

            if (envelopDataXml == null)
            {
                MessageShow.show("Get Envelop data parameter from EnvelopData.xml failed",
                    "从EnvelopData.xml获取接口地址失败");
                return;
            }
            param = envelopDataXml.envelopData.Param;

            DaqAttrType.envelopData.UploadMode = addAddress(param.UploadMode, DaqAttrType.baseAddr);
            DaqAttrType.envelopData.UploadStamps = addAddress(param.UploadStamps, DaqAttrType.baseAddr);
            DaqAttrType.envelopData.UploadType = addAddress(param.UploadType, DaqAttrType.baseAddr);

        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
