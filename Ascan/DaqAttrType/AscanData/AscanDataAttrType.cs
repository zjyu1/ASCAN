using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    public struct AscanDataAttrType
    {
        public uint UploadMode;// Ref to enum UploadMode
        public uint UploadStamps;// Corresponding to mode above
        public uint UploadType;//Ref to enum UploadType 
    }
}
