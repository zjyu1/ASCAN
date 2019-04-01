using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    public struct GateAttrType
    {
        public uint Delay;//Gate start position, Unit ref to TOF unit @ DAQ_GATE_TOF_UNIT Register 
        public uint Width;//Gate width,Unit same to TOF unit
        public uint Threshold;//Gate threld, Unit ref to AMP unit @ DAQ_GATE_AMP_UNIT Register 
        public uint IF;//Interface Echo tracking switch , Ref to enum IFActive 
        public uint TofMode;//Gate Detection Mode，Ref to enum TofMode 
        public uint DnsActive;//dynamic noise suppressing(DNS) on /off, Ref to enum DNSActive  
        public uint DnsBw;//DNS band width, Unit ref to TOF unit  
        public uint DnsStart;//DNS start Position,Unit ref to TOF unit
        public uint DnsSetp;//DNS step,Unit ref to TOF unit
        public uint AlarmLogic;//Alarm logic,positive or negtive, Ref to enum GateAlarmLogic
        public uint ScActive;//Supress counter on/off, Ref to enum SuppressCounterActive
        public uint ScCounter;//Supress counter
        public uint DtsActive;//Gate Dynamic threld on/off, Ref to enum DTSActive	
        public uint DtsBand;//Gate Dynamic threld band,   Ref to AMP unit
        public uint DtsStart;//Gate Dynamic threld start,  Ref to MP unit
        public uint DtsStep;//Gate Dynamic threld step,   Ref to AMP unit
        public uint TolMonitorActive;//Tolerance monitor,Ref to enum TMActive
        public uint TolMonitorMax;// Tolerance monitor maximum value
        public uint TolMonitorMin;// Tolerance monitor minimum value
        public uint TolMonitorSc;// Tolerance monitor supress counter
        public uint AlarmActive;//Ref to GateAlarmActive
        public uint AlarmMode;//Ref to pseudo code DAQ_GATE_ALARM_TOF_MIN etc
        public uint AlarmSignalLength;//Ref to enum GateAlarmSignalLength
        public uint AlarmTimeLength;//time unit is micro second 
        public uint AlarmActiveLevel;//Ref to enum GateAlarmLevel
        public uint MeasActive;//Ref to enum MeasActive
        public uint MeasMode;//Ref to pseudo code enum MeasMode 
    }

}
