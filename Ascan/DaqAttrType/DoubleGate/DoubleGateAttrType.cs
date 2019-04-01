using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    //Double Gate
    public struct  DGateAttrType
    {
        public uint TolMonitorActive;// Tolerance monitor, Ref to enum TMActive(GateEnum.cs)
        public uint TolMonitorMax; // Tolerance monitor maximum value  
        public uint TolMonitorMin; // Tolerance monitor minimum value 
        public uint TolMonitorSc; // Tolerance monitor supress counter

        public uint AlarmActive;// Ref to enum GateAlarmActive(GateEnum.cs) 
        public uint AlarmMode; // Ref to DAQ_ATTR_2GATE_ALARM_THICKNESS_MIN  
        public uint AlarmSignalLength; // Ref to enum GateAlarmSignalLength(GateEnum.cs)
        public uint AlarmTimeLength; // unit is micro sencond
        public uint AlarmLevel; // Ref to enum GateAlarmLevel(GateEnum.cs)   

        public uint MeasActive;// Ref to enum MeasActive(GateEnum.cs)
        public uint MeasMode;// Ref to enum DGateMeasMode
    }
}
