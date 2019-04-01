using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    //Material velocity attribute type
    public struct MatVelocityAttrType
    {
        public uint Longitudinal;//uint is m/s
        public uint Transverse;//uint is m/s
        public uint Velocity;
    }
}
