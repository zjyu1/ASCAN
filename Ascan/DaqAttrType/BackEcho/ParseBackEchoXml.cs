using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class BackEchoXml
    {
        [XmlElement("BackEcho")]
        public BackEcho backEcho;
    }

    [XmlType(TypeName = "BackEcho")]
    public class BackEcho
    {
        public StrBackEcho Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrBackEcho
    {
        [XmlAttribute]
        public string Active;
    }

}
