using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct AscanVideoAttrType
    {
        public uint Active;//Ref to enum AscanVideoActive
        public uint IFActive;//Ref to enum AscanIFActive
        public uint Delay;//unit ref to tof unit, mm or us
        public uint Range;//unit ref to tof unit, mm or us
        public uint DetectionWaveMode;//Ref to enum AscanWaveDectionMode
        public uint EnvlopActive;//Ref to enum AscanEnvelopActive   
        public uint Length;//Ref to enum AscanVideoLength 
        public uint CompressedData;//Ref to enum AscanCompressedActive    
        public uint EnvlopDecayFactor;//
    } 
}
