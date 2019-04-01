using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class InLineXml
    {
        [XmlElement("InLine")]
        public InLine inLine;
    }

    [XmlType(TypeName = "InLine")]
    public class InLine
    {
        public StrInLine Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrInLine
    {
        [XmlAttribute]
        public string Line0Route;

        [XmlAttribute]
        public string Line1Route;

        [XmlAttribute]
        public string Line2Route;

        [XmlAttribute]
        public string Line3Route;

        [XmlAttribute]
        public string Line4Route;

        [XmlAttribute]
        public string Line5Route;

        [XmlAttribute]
        public string Line6Route;

        [XmlAttribute]
        public string Line7Route;

        [XmlAttribute]
        public string Line8Route;

        [XmlAttribute]
        public string Line9Route;

        [XmlAttribute]
        public string Line10Route;

        [XmlAttribute]
        public string Line11Route;

        [XmlAttribute]
        public string Line12Route;

        [XmlAttribute]
        public string Line13Route;

        [XmlAttribute]
        public string Line14Route;

        [XmlAttribute]
        public string Line15Route;
    }
}
