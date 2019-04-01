using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class EnvelopDataXml
    {
        [XmlElement("EnvelopData")]
        public EnvelopData envelopData;
    }

    [XmlType(TypeName = "EnvelopData")]
    public class EnvelopData
    {
        public StrEnvelopData Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrEnvelopData
    {
        [XmlAttribute]
        public string UploadMode;

        [XmlAttribute]
        public string UploadStamps;

        [XmlAttribute]
        public string UploadType;
    }
}
