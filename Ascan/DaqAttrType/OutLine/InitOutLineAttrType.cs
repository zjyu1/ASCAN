using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitOutLineAttrType
    {
        /**Read MaterialVelocityAttrType form MaterialVelocity.xml*/
        public static void read()
        {
            StrOutLine param;

            OutLineXml outLineXml = SystemConfig.DeserializeFromXml<OutLineXml>("DaqAttrTypeXml/OutLine.xml");

            if (outLineXml == null)
            {
                MessageShow.show("Get outline parameter from OutLine.xml failed",
                    "从OutLine.xml获取接口地址失败");
                return;
            }
            param = outLineXml.outLine.Param;

            DaqAttrType.outLine.Line0Route = addAddress(param.Line0Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line1Route = addAddress(param.Line1Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line2Route = addAddress(param.Line2Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line3Route = addAddress(param.Line3Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line4Route = addAddress(param.Line4Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line5Route = addAddress(param.Line5Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line6Route = addAddress(param.Line6Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line7Route = addAddress(param.Line7Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line8Route = addAddress(param.Line8Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line9Route = addAddress(param.Line9Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line10Route = addAddress(param.Line10Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line11Route = addAddress(param.Line11Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line12Route = addAddress(param.Line12Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line13Route = addAddress(param.Line13Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line14Route = addAddress(param.Line14Route, DaqAttrType.baseAddr);
            DaqAttrType.outLine.Line15Route = addAddress(param.Line15Route, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
