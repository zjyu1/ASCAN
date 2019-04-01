using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class InterfaceXml
    {
        [XmlElement("Interface")]
        public Interface interfaceType;
    }

    [XmlType(TypeName = "Interface")]
    public class Interface
    {
        public StrInterface Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrInterface
    {
        [XmlAttribute]
        public string InterfaceType;

        [XmlAttribute]
        public string Hasram;

        [XmlAttribute]
        public string Ramsize;

        [XmlAttribute]
        public string Channel;

        [XmlAttribute]
        public string NumRtsiLines;

        [XmlAttribute]
        public string NumRtsiInUse;

        [XmlAttribute]
        public string ClockFreq;

        [XmlAttribute]
        public string NumIsoInLines;

        [XmlAttribute]
        public string NumIsoOutLines;

        [XmlAttribute]
        public string NumPostTriggerBuffers;

        [XmlAttribute]
        public string ExtTrigLineFilter;

        [XmlAttribute]
        public string RrsilineFilter;

        [XmlAttribute]
        public string NumPorts;

        [XmlAttribute]
        public string CurrentPortNum;

        [XmlAttribute]
        public string EncoderPhaseAPolarity;

        [XmlAttribute]
        public string EncoderPhaseBPolarity;

        [XmlAttribute]
        public string EncoderPhaseZPolarity;

        [XmlAttribute]
        public string EncoderFilter;

        [XmlAttribute]
        public string EncoderDividerFactor;

        [XmlAttribute]
        public string EncoderPosition;

        [XmlAttribute]
        public string Temperature;
    }
}
