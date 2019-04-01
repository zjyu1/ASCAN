using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class LEDStatusXml
    {
        [XmlElement("LEDStatus")]
        public LEDStatus LEDStatus;
    }

    [XmlType(TypeName = "LEDStatus")]
    public class LEDStatus
    {
        public StrLEDStatus Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrLEDStatus
    {
        [XmlAttribute]
        public string Run;

        [XmlAttribute]
        public string SysFail;

        [XmlAttribute]
        public string Acess;

        [XmlAttribute]
        public string Fail;
    }
}
