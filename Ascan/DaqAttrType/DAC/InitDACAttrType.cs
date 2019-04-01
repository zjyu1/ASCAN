using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitDACAttrType
    {
        /**Read DACAttrType form DAC.xml*/
        public static void read()
        {
            StrDAC param;

            DACXml dacXml = SystemConfig.DeserializeFromXml<DACXml>("DaqAttrTypeXml/DAC.xml");

            if (dacXml == null)
            {
                MessageShow.show("Get DAC parameter from DAC.xml failed",
                    "从DAC.xml获取接口地址失败");
                return;
            }
            param = dacXml.dac.Param;

            DaqAttrType.dac.Active = addAddress(param.Active, DaqAttrType.baseAddr);
            DaqAttrType.dac.Point = addAddress(param.Point, DaqAttrType.baseAddr);
            DaqAttrType.dac.File = addAddress(param.File, DaqAttrType.baseAddr);
            DaqAttrType.dac.Mode = addAddress(param.Mode, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
