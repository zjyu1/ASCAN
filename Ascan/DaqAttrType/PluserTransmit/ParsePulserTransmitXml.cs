using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class PulserTransmitXml
    {
        [XmlElement("PulserTransmit")]
        public PulserTransmit pt;
    }

    [XmlType(TypeName = "PulserTransmit")]
    public class PulserTransmit
    {
        public StrPulserTransmit Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrPulserTransmit
    {
        [XmlAttribute]
        public string Active;

        [XmlAttribute]
        public string Delay;

        [XmlAttribute]
        public string Width;

        [XmlAttribute]
        public string Intensity;

        [XmlAttribute]
        public string DampingActive;

        [XmlAttribute]
        public string DampingValue;

        [XmlAttribute]
        public string RecieverMode;

        [XmlAttribute]
        public string Prf;
    }
}
