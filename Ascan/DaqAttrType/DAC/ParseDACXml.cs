using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class DACXml
    {
        [XmlElement("DAC")]
        public DAC dac;
    }

    [XmlType(TypeName = "DAC")]
    public class DAC
    {
        public StrDAC Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrDAC
    {
        [XmlAttribute]
        public string Active;

        [XmlAttribute]
        public string Point;

        [XmlAttribute]
        public string File;

        [XmlAttribute]
        public string Mode;
    }
}
