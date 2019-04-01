using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum SeqScanRepeatMode
    {
        OneSlot = 0,
        Cycle = 1,
        ReturnStart = 2
    }

    public enum ScanMode
    {
        Linear = 0,
        Sector = 1,
        Vertical = 2,
        Unusual =3,
        FMC = 4 //full matrix scan   
    }
}
