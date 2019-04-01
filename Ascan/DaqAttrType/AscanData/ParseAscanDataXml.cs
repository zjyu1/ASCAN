using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class AscanDataXml
    {
        [XmlElement("AscanData")]
        public AscanData ascanData;
    }

    [XmlType(TypeName = "AscanData")]
    public class AscanData
    {
        public StrAscanData Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrAscanData
    {
        [XmlAttribute]
        public string UploadMode;

        [XmlAttribute]
        public string UploadStamps;

        [XmlAttribute]
        public string UploadType;
    }
}
