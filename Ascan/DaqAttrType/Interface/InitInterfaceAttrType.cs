using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class InitInterfaceAttrType
    {
        /**Read InterfaceAttrType form Interface.xml*/
        public static void read()
        {
            StrInterface param;

            InterfaceXml interfaceXmlXml = SystemConfig.DeserializeFromXml<InterfaceXml>("DaqAttrTypeXml/Interface.xml");

            if (interfaceXmlXml == null)
            {
                MessageShow.show("Get interface parameter from Interface.xml failed",
                    "从Interface.xml获取接口地址失败");
                return;
            }
            param = interfaceXmlXml.interfaceType.Param;

            DaqAttrType.interfaceType.InterfaceType = addAddress(param.InterfaceType, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.Hasram = addAddress(param.Hasram, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.Ramsize = addAddress(param.Ramsize, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.Channel = addAddress(param.Channel, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.NumRtsiLines = addAddress(param.NumRtsiLines, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.NumRtsiInUse = addAddress(param.NumRtsiInUse, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.ClockFreq = addAddress(param.ClockFreq, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.NumIsoInLines = addAddress(param.NumIsoInLines, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.NumIsoOutLines = addAddress(param.NumIsoOutLines, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.NumPostTriggerBuffers = addAddress(param.NumPostTriggerBuffers, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.ExtTrigLineFilter = addAddress(param.ExtTrigLineFilter, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.RrsilineFilter = addAddress(param.RrsilineFilter, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.NumPorts = addAddress(param.NumPorts, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.CurrentPortNum = addAddress(param.CurrentPortNum, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.EncoderPhaseAPolarity = addAddress(param.EncoderPhaseAPolarity, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.EncoderPhaseBPolarity = addAddress(param.EncoderPhaseBPolarity, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.EncoderPhaseZPolarity = addAddress(param.EncoderPhaseZPolarity, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.EncoderFilter = addAddress(param.EncoderFilter, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.EncoderDividerFactor = addAddress(param.EncoderDividerFactor, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.EncoderPosition = addAddress(param.EncoderPosition, DaqAttrType.baseAddr);
            DaqAttrType.interfaceType.Temperature = addAddress(param.Temperature, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
