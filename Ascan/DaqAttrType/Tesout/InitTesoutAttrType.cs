using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitTesoutAttrType
    {
        /**Read TesoutAttrType form Tesout.xml*/
        public static void read()
        {
            StrTesout param;

            TesoutXml tesoutXml = SystemConfig.DeserializeFromXml<TesoutXml>("DaqAttrTypeXml/Tesout.xml");

            if (tesoutXml == null)
            {
                MessageShow.show("Get Tesout parameter from Tesout.xml failed",
                    "从Tesout.xml获取接口地址失败");
                return;
            }
            param = tesoutXml.tesout.Param;

            DaqAttrType.tesout.Active = addAddress(param.Active, DaqAttrType.baseAddr);
            DaqAttrType.tesout.Freq = addAddress(param.Freq, DaqAttrType.baseAddr);
            DaqAttrType.tesout.Mode = addAddress(param.Mode, DaqAttrType.baseAddr);
            
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
