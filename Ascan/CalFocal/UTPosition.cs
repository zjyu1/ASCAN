using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ascan
{
    [Serializable]
    public class UTPosition
    {
        public double wedgePosition;
        public double probePosition;

        public UTPosition()
        {
            wedgePosition = 0;
            probePosition = 0;
        }
    }
}
