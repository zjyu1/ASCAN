using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class PowerXml
    {
        [XmlElement("Power")]
        public Power power;
    }

    [XmlType(TypeName = "Power")]
    public class Power
    {
        public StrPower Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrPower
    {
        [XmlAttribute]
        public string Hv;

        [XmlAttribute]
        public string Optocoupler;

        [XmlAttribute]
        public string Opa;

        [XmlAttribute]
        public string Testout;

        [XmlAttribute]
        public string Power12vp;

        [XmlAttribute]
        public string Ethernet;

        [XmlAttribute]
        public string Serial;
    }
}
