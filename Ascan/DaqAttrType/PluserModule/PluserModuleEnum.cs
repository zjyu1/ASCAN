using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum PluserMode
    {
        Train =1,
        Single =2,
        SingleRearm =3,
    }

    public enum PluserTimeBase
    {
        PluserTimeBase10MHZ = 1,
        PluserTimeBase50MHZ =2,
        PluserTimeBaseMM = 3,
        PluserTimeBaseEncoder = 4
    }

    public enum PluserRearmSource
    {
        AcqDone = 1,
        BufComplete = 2,
        FixedFrequency =3
    }
}
