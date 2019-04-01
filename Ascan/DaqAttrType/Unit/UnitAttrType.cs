using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct UnitAttrType
    {
        public uint Tof;//Ref to enum TofUnit, mm or us  
        public uint Amp;//Ref to enum AmpUnit, % or dB
    }
}
