using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct PulserTranmitAttrType
    {
        public uint Active;// see enum PluserActive 
        public uint Delay;// unit is ns
        public uint Width;// unit is ns
        public uint Intensity;// Only 8 bits coder for HV_GEN_MOD of our labtory   
        public uint DampingActive;// Damping on/off，Ref to enum PulserDampingActive 
        public uint DampingValue;// Setting according to 8 bits coder DAMPING, for utsp only to code, for ust 8 bits 
        public uint RecieverMode;// Pluse echo (PE) or Pluse catch(PC) ,Ref to enum RecieverType
        public uint Prf;//PRF, Unit: Hz
    }
}
