using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct PluserModuleAttrType
    {
        public uint Mode;//ref to enum PluserMode
        public uint TimeBase;// ref to enum PluserTimeBase
        public uint RearmSource;// ref to enum PluserRearmSource
    }
}
