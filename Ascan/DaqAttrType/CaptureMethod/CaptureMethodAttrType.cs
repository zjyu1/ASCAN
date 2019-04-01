using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public struct CaptureMethodAttrType
    {
        public uint AcquireMode;// ref to ENUM_DAQ_ACQIURE_MODE
        public uint FrameCount;//帧数 
        public uint LastValidBuffer;//最新缓存号   
        public uint FrameWaitMsec;
        public uint NumBuffers;//缓存的个数
        public uint LostFrams;//丢失的帧数  
        public uint LastActiveFrame; // returns the cummulative buffer index (frame#)
        public uint AcquireBufferNum;
        public uint AcquireBufferIndex;
        public uint TransferBufferNum;
        public uint TransferBufferIndex;
        public uint ActiveBuffer;
        public uint LoadFileDownAddr;
        public uint LoadFileRunAddr;
    }
}
