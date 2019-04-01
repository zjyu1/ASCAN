using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum PluserActive
    {
        OFF = 0,
        ON = 1
    }

    public enum PulserDampingActive
    {
        OFF = 0,
        ON = 1
    }

    public enum RecieverType
    {
        Pe = 0, //pluse echo 模式，收发一体模式
        Pc = 1  //pluse catch模式，收发分离模式
    }
}
