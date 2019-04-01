using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct InterfaceAttrType
    {
        public uint InterfaceType;// Ref to enum InterfaceType
        public uint Hasram;// TRUE = has on-board SRAM
        public uint Ramsize; // SRAM size, Unit Byte 
        public uint Channel; // How much channel board has, Uint32 
        public uint NumRtsiLines; // how much  RTSI line board has  
        public uint NumRtsiInUse;
        public uint ClockFreq;// returns the max clock freq of the board, MHz 
        public uint NumIsoInLines;// The number of iso in lines the device supports
        public uint NumIsoOutLines;// The number of iso out lines the device supports 
        public uint NumPostTriggerBuffers;// The number of buffers that hardware should continue acquire after sensing a stop trigger before it finally does stop
        public uint ExtTrigLineFilter;// Whether to use filtering on the TTL trigger lines
        public uint RrsilineFilter;// Whether to use filtering on the RTSI trigger lines
        public uint NumPorts;// Returns the number of ports that this device supports.
        public uint CurrentPortNum;// Returns the port number that the given interface is using.
        public uint EncoderPhaseAPolarity;// The polarity of the phase A encoder input, ref to enum PulsePolar
        public uint EncoderPhaseBPolarity;// The polarity of the phase B encoder input
        public uint EncoderPhaseZPolarity;// The polarity of the phase Z encoder input
        public uint EncoderFilter;// Specifies whether to use filtering on the encoder input, Ref to enum LineFilter
        public uint EncoderDividerFactor;// The divide factor for the encoder scaler 
        public uint EncoderPosition;// Returns the current value of the absolute encoder position as a uInt64 
        public uint Temperature;// The device's current temperature, in degrees C 
    }
}
