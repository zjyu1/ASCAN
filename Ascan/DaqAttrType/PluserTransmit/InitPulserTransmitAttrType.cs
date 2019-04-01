using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitPulserTransmitAttrType
    {
        /**Read PulserTransmitAttrType form PulserTransmit.xml*/
        public static void read()
        {
            StrPulserTransmit param;

            PulserTransmitXml pulserTransmitXml = SystemConfig.DeserializeFromXml<PulserTransmitXml>("DaqAttrTypeXml/PulserTransmit.xml");
            
            if (pulserTransmitXml == null)
            {
                MessageShow.show("Get pulser transmit parameter from PulserTransmit.xml failed", 
                    "从PulserTransmit.xml获取接口地址失败");
                return;
            }
            param = pulserTransmitXml.pt.Param;

            DaqAttrType.pulserTranmit.Active = addAddress(param.Active, DaqAttrType.baseAddr);
            DaqAttrType.pulserTranmit.Delay = addAddress(param.Delay, DaqAttrType.baseAddr); 
            DaqAttrType.pulserTranmit.Width = addAddress(param.Width, DaqAttrType.baseAddr);
            DaqAttrType.pulserTranmit.Intensity = addAddress(param.Intensity, DaqAttrType.baseAddr);
            DaqAttrType.pulserTranmit.DampingActive = addAddress(param.DampingActive, DaqAttrType.baseAddr);
            DaqAttrType.pulserTranmit.DampingValue = addAddress(param.DampingValue, DaqAttrType.baseAddr);
            DaqAttrType.pulserTranmit.RecieverMode = addAddress(param.RecieverMode, DaqAttrType.baseAddr);
            DaqAttrType.pulserTranmit.Prf = addAddress(param.Prf, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
