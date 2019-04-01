using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct PowerAttrType
    {
        public uint Hv;// ref to enum PowerActive, same to list below 
        public uint Optocoupler;
        public uint Opa;// analog amplifers, powerdown mode is off   
        public uint Testout;
        public uint Power12vp;
        public uint Ethernet;
        public uint Serial;
    }
}
