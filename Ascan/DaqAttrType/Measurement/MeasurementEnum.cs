using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum MeasAlarmActive
    {
        OFF = 0,
        ON = 1
    }

    public enum MeasAlarmDisp
    {
        ITofMin = 0x1,
        ITofMax = 0x1<<1,
        IAmpThreld = 0x1<<2,
        IOutAgcRange = 0x1<<3,

        ATofMin = 0x1<<4,
        ATofMax = 0x1<<5,
        AAmpThreld = 0x1<<6,
        AOutAgcRange = 0x1<<7,

        BTofMin = 0x1<<8,
        BTofMax = 0x1<<9,
        BAmpThreld = 0x1<<10,
        BOutAgcRange = 0x1<<11,
        
        CTofMin = 0x1<<12,
        CTofMax = 0x1<<13,
        CAmpThreld = 0x1<<14,
        COutAgcRange = 0x1<<15,

        BAThicknessMin = 0x1<<16,
        BAThicknessMax = 0x1<<17,
        BAInvalidValue = 0x1<<18,
     
        AIThicknessMin = 0x1<<20,
        AIThicknessMax = 0x1<<21,
        AIInvalidValue = 0x1<<22,

        BIThicknessMin = 0x1<<24,
        BIThicknessMax = 0x1<<25,
        BIInvalidValue = 0x1<<26 ,

        CIThicknessMin = 0x1<<28,
        CIThicknessMax = 0x1<<29,
        CIInvalidValue = 0x1 << 30
    }
}
