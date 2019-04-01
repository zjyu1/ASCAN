using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitReceiverAttrType
    {
        /**Read RecievertAttrType form Reciever.xml*/
        public static void read()
        {
            StrReceiver param;

            ReceiverXml receiverXml = SystemConfig.DeserializeFromXml<ReceiverXml>("DaqAttrTypeXml/Receiver.xml");

            if (receiverXml == null)
            {
                MessageShow.show("Get receiver parameter from Receiver.xml failed",
                    "从Receiver.xml获取接口地址失败");
                return;
            }
            param = receiverXml.receiver.Param;

            DaqAttrType.receiver.Active = addAddress(param.Active, DaqAttrType.baseAddr);
            DaqAttrType.receiver.AnalogHPF = addAddress(param.AnalogHPF, DaqAttrType.baseAddr);
            DaqAttrType.receiver.AnalogLPF = addAddress(param.AnalogLPF, DaqAttrType.baseAddr);

            DaqAttrType.receiver.DigitalHPF = addAddress(param.DigitalHPF, DaqAttrType.baseAddr);
            DaqAttrType.receiver.DigitalLPF = addAddress(param.DigitalLPF, DaqAttrType.baseAddr);

            DaqAttrType.receiver.ReceiverPATH = addAddress(param.ReceiverPATH, DaqAttrType.baseAddr);

            DaqAttrType.receiver.DampingActive = addAddress(param.DampingActive, DaqAttrType.baseAddr);
            DaqAttrType.receiver.DampingValue = addAddress(param.DampingValue, DaqAttrType.baseAddr);
            DaqAttrType.receiver.AnalogGain = addAddress(param.AnalogGain, DaqAttrType.baseAddr);

            DaqAttrType.receiver.Delay = addAddress(param.Delay, DaqAttrType.baseAddr);
            DaqAttrType.receiver.Intensity = addAddress(param.Intensity, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
