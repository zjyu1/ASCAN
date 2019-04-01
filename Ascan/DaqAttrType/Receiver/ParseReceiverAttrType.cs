using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class ReceiverXml
    {
        [XmlElement("Receiver")]
        public Receiver receiver;
    }

    [XmlType(TypeName = "Receiver")]
    public class Receiver
    {
        public StrReceiver Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrReceiver
    {
        [XmlAttribute]
        public string Active;

        [XmlAttribute]
        public string AnalogHPF;

        [XmlAttribute]
        public string AnalogLPF;

        [XmlAttribute]
        public string DigitalHPF;

        [XmlAttribute]
        public string DigitalLPF;

        [XmlAttribute]
        public string ReceiverPATH;

        [XmlAttribute]
        public string DampingActive;

        [XmlAttribute]
        public string DampingValue;

        [XmlAttribute]
        public string AnalogGain;

        [XmlAttribute]
        public string Delay;

        [XmlAttribute]
        public string Intensity;
    }
}
