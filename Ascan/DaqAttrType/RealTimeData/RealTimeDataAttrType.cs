using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct  RealTimeDataAttrType
    {
        public uint UploadMode;// Ref to enum UploadMode(AscanDataEnum.cs)
        public uint UploadStamps;// Corresponding to mode above
        public uint UploadType;//Ref to enum UploadType(AscanDataEnum.cs)
    }
}
