using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct  PCIAttrType
    {
        public uint SyncAcqDone;//标志同步采集完成,READONLY, Ref to enum AcqDone
        public uint PCISlotNumber;//PCI SLOT号，通过GA[4..0]获得, READONLY, UINT
        public uint PCIClassicNumber;//PCI Calssic机箱号，WRITE ONLY, UINT         
    }
}
