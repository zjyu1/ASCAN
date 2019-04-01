using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct PosTriggerAttrType
    {
        public uint PosTriggerSource;// Decide which  signal as pos trig's source, ref to enum PosTriggerSource
        public uint EncoderTriggerSource;//same to above
    }
}
