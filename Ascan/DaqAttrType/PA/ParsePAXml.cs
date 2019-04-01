using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public  class PAXml
    {
        [XmlElement("PA")]
        public PA pA;
    }

    [XmlType(TypeName = "PA")]
    public class PA
    {
        public StrPA Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrPA
    {
        [XmlAttribute]
        public string SeqScanRepeatMode;

        [XmlAttribute]
        public string ScanMode;

        [XmlAttribute]
        public string BeamFormerFile;

        [XmlAttribute]
        public string RealElementSize;

        [XmlAttribute]
        public string VirtualElementSize;

        [XmlAttribute]
        public string SeqPeriodTimes;
    }
}
