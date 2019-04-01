using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct GlobleCtrl
    {
        public uint TrigMode;//PRF trigger mode，Ref to ENUM_DAQ_TRIG_MODE 
        public uint RunMode;//Run mode，Ref to ENUM_DAQ_RUN_MODE
        public uint PxistarTrigStartDelay;//mm as unit
        public uint PxistarTrigStopDelay;//mm as unit   
        public uint SoftStart;//Start, same as FPGA's  global_en
        public uint SoftStop;//Stop   
        public uint SoftReset;
    }
}
