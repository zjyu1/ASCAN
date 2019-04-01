using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
        [XmlType(TypeName = "Config")]
        public class RealTimeDataXml
        {
            [XmlElement("RealTimeData")]
            public RealTimeData realTimeData;
        }

        [XmlType(TypeName = "RealTimeData")]
        public class RealTimeData
        {
            public StrRealTimeData Param;
        }

        [XmlType(TypeName = "Param")]
        public struct StrRealTimeData
        {
            [XmlAttribute]
            public string UploadMode;

            [XmlAttribute]
            public string UploadStamps;

            [XmlAttribute]
            public string UploadType;
        }
}
