using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum InterfaceType
    {
        PXI = 0,
        Ethernet = 1,
        Serial = 2,
    }

    public enum PulsePolar
    {
        ActiveL = 0,
        ActiveH = 1
    }

    public enum LineFilter
    {
        OFF = 0,
        ON= 1
    }
}
