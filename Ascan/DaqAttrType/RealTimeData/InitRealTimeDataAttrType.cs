using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitRealTimeDataAttrType
    {
        /**Read RealTimeDataAttrType form RealTimeData.xml*/
        public static void read()
        {
            StrRealTimeData param;

            RealTimeDataXml realTimeDataXml = SystemConfig.DeserializeFromXml<RealTimeDataXml>("DaqAttrTypeXml/RealTimeData.xml");

            if (realTimeDataXml == null)
            {
                MessageShow.show("Get real time data parameter from RealTimeData.xml failed",
                    "从RealTimeData.xml获取接口地址失败");
                return;
            }
            param = realTimeDataXml.realTimeData.Param;

            DaqAttrType.realTimeData.UploadMode = addAddress(param.UploadMode, DaqAttrType.baseAddr);
            DaqAttrType.realTimeData.UploadStamps = addAddress(param.UploadStamps, DaqAttrType.baseAddr);
            DaqAttrType.realTimeData.UploadType = addAddress(param.UploadType, DaqAttrType.baseAddr);

        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
