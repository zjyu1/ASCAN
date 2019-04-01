using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitAscanDataAttrType
    {
        /**Read AscanDataAttrType form PulserTransmit.xml*/
        public static void read()
        {
            StrAscanData param;

            AscanDataXml ascanDataXml = SystemConfig.DeserializeFromXml<AscanDataXml>("DaqAttrTypeXml/AscanData.xml");

            if (ascanDataXml == null)
            {
                MessageShow.show("Get Ascan data parameter from AscanData.xml failed",
                    "从AscanData.xml获取接口地址失败");
                return;
            }
            param = ascanDataXml.ascanData.Param;

            DaqAttrType.ascanData.UploadMode = addAddress(param.UploadMode, DaqAttrType.baseAddr);
            DaqAttrType.ascanData.UploadStamps = addAddress(param.UploadStamps, DaqAttrType.baseAddr);
            DaqAttrType.ascanData.UploadType = addAddress(param.UploadType, DaqAttrType.baseAddr);
            
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
