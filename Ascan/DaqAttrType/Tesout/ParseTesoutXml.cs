using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class TesoutXml
    {
        [XmlElement("Tesout")]
        public Tesout tesout;
    }

    [XmlType(TypeName = "Tesout")]
    public class Tesout
    {
        public StrTesout Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrTesout
    {
        [XmlAttribute]
        public string Active;

        [XmlAttribute]
        public string Freq;

        [XmlAttribute]
        public string Mode; 
    }
}
