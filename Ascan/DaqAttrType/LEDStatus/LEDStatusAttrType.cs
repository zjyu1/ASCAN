using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct LEDStatusAttrType
    {
        public uint Run;// The state of the Pass LED,    READONLY, Ref to enum LEDState
        public uint SysFail;// The state of the SysFail LED, READONLY 
        public uint Acess;// The state of the Access LED,  READONLY 
        public uint Fail;// The state of the fail LED,    READONLy                  
    }
}
