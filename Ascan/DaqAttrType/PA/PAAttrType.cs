using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct PAAttrType
    {
        public uint SeqScanRepeatMode;//PA repeat mode, one shot, cycle repeat, or return start repeat,ref to  enum SeqScanRepeatMode
        public uint ScanMode;//Ref to enum ScanMode
        public uint BeamFormerFile;//for download beamformer file    
        public uint RealElementSize;
        public uint VirtualElementSize;
        public uint SeqPeriodTimes;
    }
}
