using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitGlobalCtrl
    {
        /**Read GlobalCtrlAttrType form GlobalControl.xml*/
        public static void read()
        {
            StrGlobalCtrl param;

            GlobalCtrlXml gloablCtrlXml = SystemConfig.DeserializeFromXml<GlobalCtrlXml>("DaqAttrTypeXml/GlobalControl.xml");

            if (gloablCtrlXml == null)
            {
                MessageShow.show("Get Global control parameter from GlobalControl.xml failed",
                    "从GlobalControl.xml获取接口地址失败");
                return;
            }
            param = gloablCtrlXml.globalCtrl.Param;

            DaqAttrType.globalCtrl.TrigMode = addAddress(param.TrigMode, DaqAttrType.baseAddr);
            DaqAttrType.globalCtrl.RunMode = addAddress(param.RunMode, DaqAttrType.baseAddr);
            DaqAttrType.globalCtrl.PxistarTrigStartDelay = addAddress(param.PxistarTrigStartDelay, DaqAttrType.baseAddr);
            DaqAttrType.globalCtrl.PxistarTrigStopDelay = addAddress(param.PxistarTrigStopDelay, DaqAttrType.baseAddr);
            DaqAttrType.globalCtrl.SoftStart = addAddress(param.SoftStart, DaqAttrType.baseAddr);
            DaqAttrType.globalCtrl.SoftStop = addAddress(param.SoftStop, DaqAttrType.baseAddr);
            DaqAttrType.globalCtrl.SoftReset = addAddress(param.SoftReset, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
