using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class PosTriggerXml
    {
        [XmlElement("PosTrigger")]
        public PosTrigger posTrigger;
    }

    [XmlType(TypeName = "PosTrigger")]
    public class PosTrigger
    {
        public StrPosTrigger Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrPosTrigger
    {
        [XmlAttribute]
        public string PosTriggerSource;

        [XmlAttribute]
        public string EncoderTriggerSource;
    }
}
