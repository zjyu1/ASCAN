using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class GateXml
    {
        [XmlArray("Gates")]
        public List<GateItem> Gates { get; set; }
    }

    [XmlType(TypeName = "Gate")]
    public class GateItem
    {
        [XmlAttribute]
        public string name { get; set; }

        public StrGate Param { get; set; }
    }

    [XmlType(TypeName = "Param")]
    public struct StrGate
    {
        [XmlAttribute]
        public string Delay;

        [XmlAttribute]
        public string Width;

        [XmlAttribute]
        public string Threshold;

        [XmlAttribute]
        public string IF;

        [XmlAttribute]
        public string TofMode;

        [XmlAttribute]
        public string DnsActive;

        [XmlAttribute]
        public string DnsBw;

        [XmlAttribute]
        public string DnsStart;

        [XmlAttribute]
        public string DnsSetp;

        [XmlAttribute]
        public string AlarmLogic;

        [XmlAttribute]
        public string ScActive;

        [XmlAttribute]
        public string ScCounter;

        [XmlAttribute]
        public string DtsActive;

        [XmlAttribute]
        public string DtsBand;

        [XmlAttribute]
        public string DtsStart;

        [XmlAttribute]
        public string DtsStep;

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
        public string AlarmActiveLevel;

        [XmlAttribute]
        public string MeasActive;

        [XmlAttribute]
        public string MeasMode;
    }
}
