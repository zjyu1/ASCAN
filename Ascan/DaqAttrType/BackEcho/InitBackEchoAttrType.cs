using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitBackEchoAttrType
    {
        /**Read BackEchoAttrType form BackEcho.xml*/
        public static void read()
        {
            StrBackEcho param;

            BackEchoXml backEchoXml = SystemConfig.DeserializeFromXml<BackEchoXml>("DaqAttrTypeXml/BackEcho.xml");

            if (backEchoXml == null)
            {
                MessageShow.show("Get Ascan video parameter from BackEcho.xml failed",
                    "从BackEcho.xml获取接口地址失败");
                return;
            }
            param = backEchoXml.backEcho.Param;

            DaqAttrType.backEcho.Active = addAddress(param.Active, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
