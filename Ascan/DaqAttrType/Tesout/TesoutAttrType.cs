using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct TesoutAttrType
    {
        public uint Active;// ref to enum TesoutActive
        public uint Freq;// Unit is Hz  
        public uint Mode;// ref to enum TesoutMode  
    }
}
