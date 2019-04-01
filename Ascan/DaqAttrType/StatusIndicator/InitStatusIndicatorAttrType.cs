using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitStatusIndicatorAttrType
    {
        /**Read StatusIndicatorAttrType form StatusIndicator.xml*/
        public static void read()
        {
            StrStatusIndicator param;

            StatusIndicatorXml statusIndicatorXml = SystemConfig.DeserializeFromXml<StatusIndicatorXml>("DaqAttrTypeXml/StatusIndicator.xml");

            if (statusIndicatorXml == null)
            {
                MessageShow.show("Get Status indicator parameter from StatusIndicator.xml failed",
                    "从StatusIndicator.xml获取接口地址失败");
                return;
            }
            param = statusIndicatorXml.statusIndicator.Param;

            DaqAttrType.statusIndicator.Machine = addAddress(param.Machine, DaqAttrType.baseAddr);
            DaqAttrType.statusIndicator.Errcode = addAddress(param.Errcode, DaqAttrType.baseAddr);
            DaqAttrType.statusIndicator.BeatHeart = addAddress(param.BeatHeart, DaqAttrType.baseAddr);
            DaqAttrType.statusIndicator.AcqInProgress = addAddress(param.AcqInProgress, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
