using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitPAAttrType
    {
        /**Read PAAttrType form PA.xml*/
        public static void read()
        {
            StrPA param;

            PAXml pAXml = SystemConfig.DeserializeFromXml<PAXml>("DaqAttrTypeXml/PA.xml");

            if (pAXml == null)
            {
                MessageShow.show("Get Ascan video parameter from PA.xml failed",
                    "从PA.xml获取接口地址失败");
                return;
            }
            param = pAXml.pA.Param;

            DaqAttrType.pA.SeqScanRepeatMode = addAddress(param.SeqScanRepeatMode, DaqAttrType.baseAddr);
            DaqAttrType.pA.ScanMode = addAddress(param.ScanMode, DaqAttrType.baseAddr);
            DaqAttrType.pA.BeamFormerFile = addAddress(param.BeamFormerFile, DaqAttrType.baseAddr);
            DaqAttrType.pA.RealElementSize = addAddress(param.RealElementSize, DaqAttrType.baseAddr);
            DaqAttrType.pA.VirtualElementSize = addAddress(param.VirtualElementSize, DaqAttrType.baseAddr);
            DaqAttrType.pA.SeqPeriodTimes = addAddress(param.SeqPeriodTimes, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
