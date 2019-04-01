using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct  DACAttrType
    {
        public uint Active;//DAC active，Ref to enum DACActive
        public uint Point;//Maximum 32 Point 
        public uint File;//for download dac file
        public uint Mode;//Ref to enum DACMode
    }
}
