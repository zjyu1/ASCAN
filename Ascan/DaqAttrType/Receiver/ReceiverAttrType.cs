using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    //Reciever parameters
    public struct RecieverAttrType
    {
        public uint Active; //  see enum RecieverActive
        public uint AnalogHPF; //  analog high pass filter,  -3dB cutoff frequency(Hz), Ref to enum FilterCutoffFreq
        public uint AnalogLPF; //  analog low pass filter 

        public uint DigitalHPF;// digital high pass filter
        public uint DigitalLPF;// digital low pass filter

        public uint ReceiverPATH; // hardware reciever channel select normal, testin or hvsense,Ref to enum RecieverPATH

        public uint DampingActive; // Damping active ，Ref to enum DampingActive 
        public uint DampingValue; // damping code 8 bits, each board has it coder meaning
        public uint AnalogGain; // analog gain 	

        public uint Delay;
        public uint Intensity;//reciever beamforming intension, for suppress lobe effect 
    }
}
