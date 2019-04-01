using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum DGateType
    {
        BA = 0,
        AI = 1,
        BI = 2,
        CI = 3
    }

    public enum DGateMeasMode
    {
        None = 0,
        ThicknessMax = 1,
        ThicknessMin = 2,
        AmpDiffPercent = 4,
        AmpDiffdB = 8
    }
     
}
