using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum UploadMode
    {
        StampsPrf = 0,
        StampsPos = 1,
        StampsEnc = 2,
        RepeatReturnTimed=3
    }

    public enum UploadType
    {
        Schar = 0,
        Int32 = 1,
        Float = 2
    }
}
