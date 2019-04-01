using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct GlobalCtrlAttrType
    {
        public uint TrigMode;//PRF trigger mode，Ref to enum TrigMode; 
        public uint RunMode;//Run mode，Ref to enum RunMode
        public uint PxistarTrigStartDelay;//mm as unit
        public uint PxistarTrigStopDelay;//mm as unit   
        public uint SoftStart;//Start, same as FPGA's  global_en
        public uint SoftStop;//Stop   
        public uint SoftReset;
    }
}
