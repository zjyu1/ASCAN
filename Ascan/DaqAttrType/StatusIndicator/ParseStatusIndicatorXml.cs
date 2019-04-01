using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class StatusIndicatorXml
    {
        [XmlElement("StatusIndicator")]
        public StatusIndicator statusIndicator;
    }

    [XmlType(TypeName = "StatusIndicator")]
    public class StatusIndicator
    {
        public StrStatusIndicator Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrStatusIndicator
    {
        [XmlAttribute]
        public string Machine;

        [XmlAttribute]
        public string Errcode;

        [XmlAttribute]
        public string BeatHeart;

        [XmlAttribute]
        public string AcqInProgress;
    }
}
