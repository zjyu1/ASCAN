using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum AscanVideoActive
    {
        OFF = 0,
        ON = 1
    }

    public enum AscanIFActive
    {
        OFF = 0,
        ON = 1
    }

    public enum AscanWaveDectionMode
    {
        Rf = 0,
        Full = 1,
        SemiPositve = 2,
        SemiNegtive = 3
    }

    public enum AscanEnvelopActive
    {
        OFF = 0,
        ON = 1
    }

    public enum AscanVideoLength
    {
        Point512 = 512,
        Point1024 = 1024
    }

    public enum AscanCompressedActive
    {
        OFF = 0,
        ON = 1
    }
}
