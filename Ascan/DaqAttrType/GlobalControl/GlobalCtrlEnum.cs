using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum TrigMode
    {
        TrigSoft = 1,//get from pluse module
        TrigPos = 2,
        TrigEncoder = 3,
        TrigExternal = 4,
        TrigPxiStar = 5,
        TrigThreld = 6
    }

    public enum RunMode
    {
        Auto = 0,//自动运行依据start stop 信号产生检测数据，并报警IO输出
        CheckMode = 1,//校准模式依据start stop 信号产生检测数据 不做报警IO输出
        ManulMode = 2//手动模式不依据start stop物理信号产生检测数据，依据DAQ_SOFT_STOP，DAQ_SOFT_START
    }

    public enum PathMethod
    {
        Direct = 0,
        Reflect = 1, 
        Series = 2
    }

    public enum FocusConfig
    {
        Pulse_Echo = 0, 
        Pitch_Catch = 1
    }

    public enum GrooveType
    {
        NULL = -1,
        V = 0,
        X = 1,
        CRC =2
    }

    public enum ZoneType
    {
        Fill = 0,
        HP = 1,
        LCP = 2,
        Root = 3,
        Couple = 4
    }
}
