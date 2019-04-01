using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitStartAddrAttrType
    {
        public static void read()
        {
            uint startAddr = 0;
            startAddr = SystemConfig.GetConfigData("DaqAttrTypeXml/StartAddr.xml", "StartAddr", startAddr);
            if (startAddr == 0)
            {
                MessageShow.show("Read StartAddr.xml failed!", "StartAddr.xml获得首地址失败!");
                return;
            }
            DaqAttrType.baseAddr = startAddr;
        }
    }
}
