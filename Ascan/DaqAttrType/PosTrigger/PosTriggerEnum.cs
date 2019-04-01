using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum PosTriggerSource
    {
        None = 0,
        RotorEncoderA,
        RotorEncoderB,
        RotorEncoderZ,
        MmEncoderA,
        MmEncoderB,
        MmEncoderZ,
        Start,
        Stop,
        AlarmClk,
        ExtTrig,

        //Motor drive  
        XEncoderA,
        XEncoderB,
        XEncoderZ,
        YEncoderA,
        YEncoderB,
        YEncoderZ,
        ZEncoderA,
        ZEncoderB,
        ZEncoderZ,

        //pxi trig bus  
        PXIStartTrigLine,
        PXITrigLine0,
        PXITrigLine1,
        PXITrigLine2,
        PXITrigLine3,
        PXITrigLine4,
        PXITrigLine5,
        PXITrigLine6,
        PXITrigLine7
    }
}
