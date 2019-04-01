using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class GlobalCtrlXml
    {
        [XmlElement("GlobalCtrl")]
        public GlobalCtrl globalCtrl;
    }

    [XmlType(TypeName = "GlobalCtrl")]
    public class GlobalCtrl
    {
        public StrGlobalCtrl Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrGlobalCtrl
    {
        [XmlAttribute]
        public string TrigMode;

        [XmlAttribute]
        public string RunMode;

        [XmlAttribute]
        public string PxistarTrigStartDelay;

        [XmlAttribute]
        public string PxistarTrigStopDelay;

        [XmlAttribute]
        public string SoftStart;

        [XmlAttribute]
        public string SoftStop;

        [XmlAttribute]
        public string SoftReset;
    }
}
