using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum GateType
    {
        I = 0,
        A = 1,
        B = 2,
        C = 3,
        //double gate
        //21 is the combine of the B(2) and A(1)
        BA = 21,
        AI = 10,
        BI = 20,
        CI = 30
    }

    public enum GateAlarmLogic
    {
        Negative = 0,
        Positive = 1
    }

    public enum GateAlarmActive
    {
        OFF = 0,
        ON = 1
    }

    public enum GateAlarmLevel
    {
        Low = 0,
        High = 1
    }

    public enum GateAlarmMode
    {
        None = 0,
        TofMin = 1,
        TofMax = 2,
        AmpThrd = 4,
        AgcRange = 8,
        Others = 9
    }

    public enum GateAlarmSignalLength
    {
        Timed = 0,
        Hold = 1,
        OnePrf = 2,
        AutoClear = 3
    }

    public enum TofMode
    {
        Peak = 0,
        FirstPeak = 1,
        Flank = 2,
        ZeroBefore = 3,
        ZeroAfter = 4
    }

    public enum SuppressCounterActive
    {
        OFF = 0,
        ON = 1
    }

    public enum IFActive
    {
        OFF = 0,
        ON = 1
    }

    public enum DNSActive
    {
        OFF = 0,
        ON = 1
    }

    public enum DTSActive
    {
        OFF = 0,
        ON = 1
    }

    public enum TMActive
    {
        OFF = 0,
        ON = 1
    }

    public enum MeasActive
    {
        OFF = 0,
        ON = 1
    }

    public enum MeasMode
    {
        None = 0,
        TofPeak = 1,
        TofMax = 2,
        TofMin = 4,
        AmpPercent = 8,
        AmpDb = 16,
        SurfaceDistance = 32,
        ReductedSurfaceDistance = 64,
        Depth = 128,
        Leg = 256,
        AmpToDacPercent = 512,
        AmpToDacDb = 1024,
        GateInData = 2048,
        Others
    }

}
