using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct StatusIndicatorAttrType
    {
        public uint Machine;// Board status machine state,         READ ONLY 
        public uint Errcode;// Board status error code, see below, READ ONLY
        public uint BeatHeart;// none zero value, and increment,     READ ONLY 
        public uint AcqInProgress;//TRUE or False, 正在采集状态属性, ref to enum AcqInProgressActive
    }
}
