using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class DGateXml
    {
        [XmlArray("DGates")]
        public List<DGateItem> DGates { get; set; }
    }

    [XmlType(TypeName = "DGate")]
    public class DGateItem
    {
        [XmlAttribute]
        public string name { get; set; }

        public StrDGate Param { get; set; }
    }

    [XmlType(TypeName = "Param")]
    public struct StrDGate
    {
        [XmlAttribute]
        public string TolMonitorActive;

        [XmlAttribute]
        public string TolMonitorMax;

        [XmlAttribute]
        public string TolMonitorMin;

        [XmlAttribute]
        public string TolMonitorSc;

        [XmlAttribute]
        public string AlarmActive;

        [XmlAttribute]
        public string AlarmMode;

        [XmlAttribute]
        public string AlarmSignalLength;

        [XmlAttribute]
        public string AlarmTimeLength;

        [XmlAttribute]
        public string AlarmLevel;

        [XmlAttribute]
        public string MeasActive;

        [XmlAttribute]
        public string MeasMode;
    }
}
