using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class PGateXml
    {
        [XmlArray("Gates")]
        public List<PGateItem> Gates { get; set; }
    }

    [XmlType(TypeName = "Gate")]
    public class PGateItem
    {
        [XmlAttribute]
        public string name { get; set; }

        public PGate Param { get; set; }
    }

    [XmlType(TypeName = "Param")]
    public struct PGate
    {
        [XmlAttribute]
        public double Delay;

        [XmlAttribute]
        public double Width;

        [XmlAttribute]
        public double Threshold;

        [XmlAttribute]
        public IFActive IF;

        [XmlAttribute]
        public TofMode TofMode;

        [XmlAttribute]
        public DNSActive DnsActive;

        [XmlAttribute]
        public double DnsBw;

        [XmlAttribute]
        public double DnsStart;

        [XmlAttribute]
        public double DnsStep;

        [XmlAttribute]
        public GateAlarmLogic AlarmLogic;

        [XmlAttribute]
        public SuppressCounterActive ScActive;

        [XmlAttribute]
        public uint ScCounter;

        [XmlAttribute]
        public DTSActive DtsActive;

        [XmlAttribute]
        public double DtsBand;

        [XmlAttribute]
        public double DtsStart;

        [XmlAttribute]
        public double DtsStep;

        [XmlAttribute]
        public TMActive TolMonitorActive;

        [XmlAttribute]
        public double TolMonitorMax;

        [XmlAttribute]
        public double TolMonitorMin;

        [XmlAttribute]
        public uint TolMonitorSc;

        [XmlAttribute]
        public GateAlarmActive AlarmActive;

        [XmlAttribute]
        public GateAlarmMode AlarmMode;

        [XmlAttribute]
        public GateAlarmSignalLength AlarmSignalLength;

        /*
        [XmlAttribute]
        public string AlarmTimeLength;
         */

        [XmlAttribute]
        public GateAlarmLevel AlarmActiveLevel;

        [XmlAttribute]
        public MeasActive MeasActive;

        [XmlAttribute]
        public MeasMode MeasMode;
    }
}
