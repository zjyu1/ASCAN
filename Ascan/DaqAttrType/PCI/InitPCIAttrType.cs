using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitPCIAttrType
    {
        /**Read PCIAttrType form PCI.xml*/
        public static void read()
        {
            StrPCI param;

            PCIXml PCIXml = SystemConfig.DeserializeFromXml<PCIXml>("DaqAttrTypeXml/PCI.xml");

            if (PCIXml == null)
            {
                MessageShow.show("Get PCI parameter from PCI.xml failed",
                    "从PCI.xml获取接口地址失败");
                return;
            }
            param = PCIXml.pci.Param;


            DaqAttrType.pci.SyncAcqDone = addAddress(param.SyncAcqDone, DaqAttrType.baseAddr);
            DaqAttrType.pci.PCISlotNumber = addAddress(param.PCISlotNumber, DaqAttrType.baseAddr);
            DaqAttrType.pci.PCIClassicNumber = addAddress(param.PCIClassicNumber, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
