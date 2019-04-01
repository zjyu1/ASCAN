using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ascan
{
    class MyBeamFile
    {
        public uint beamIndex;

        //transmit
        public uint txSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] txElementBin;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] txDelay;
        //Double txIntensify[DAQ_MAX_PA_ELEMENT];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] txIntensify;

        //reciever
        public uint rxSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] rxElementBin;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] rxDelay;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] rxIntensify;

        public float gain;

        public uint txEn;

        public uint rxOn;

        public uint digitalHpf;

        public uint dampOn;

        public uint dampValue;

        public uint path;

        public uint digitalLpf;

        public uint beaOn;

        //Uint32 ctrl;
        //BIT0      BIT1      [7:2]                BIT8           BIT[15:9]           BIT16   [17:23]         [24]
        //TXEN     RXON     digital_hpf        DAMP_ON    DAMP_VALUE     PATH    digital_lpf       BEAON


        //public DACParas dac;
      
        
    }
}
