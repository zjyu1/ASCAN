using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitInLineAttrType
    {
        /**Read MaterialVelocityAttrType form MaterialVelocity.xml*/
        public static void read()
        {
            StrInLine param;

            InLineXml inLineXml = SystemConfig.DeserializeFromXml<InLineXml>("DaqAttrTypeXml/InLine.xml");

            if (inLineXml == null)
            {
                MessageShow.show("Get in line parameter from InLine.xml failed",
                    "从InLine.xml获取接口地址失败");
                return;
            }
            param = inLineXml.inLine.Param;

            DaqAttrType.inLine.Line0Route = addAddress(param.Line0Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line1Route = addAddress(param.Line1Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line2Route = addAddress(param.Line2Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line3Route = addAddress(param.Line3Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line4Route = addAddress(param.Line4Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line5Route = addAddress(param.Line5Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line6Route = addAddress(param.Line6Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line7Route = addAddress(param.Line7Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line8Route = addAddress(param.Line8Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line9Route = addAddress(param.Line9Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line10Route = addAddress(param.Line10Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line11Route = addAddress(param.Line11Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line12Route = addAddress(param.Line12Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line13Route = addAddress(param.Line13Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line14Route = addAddress(param.Line14Route, DaqAttrType.baseAddr);
            DaqAttrType.inLine.Line15Route = addAddress(param.Line15Route, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
