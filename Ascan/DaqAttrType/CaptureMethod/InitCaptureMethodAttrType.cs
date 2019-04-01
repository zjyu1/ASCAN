using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class InitCaptureMethodAttrType
    {
        /**Read CaptureMethodAttrType form CaptureMethod.xml*/
        public static void read()
        {
            StrCaptureMethod param;

            CaptureMethodXml captureMethodXml = SystemConfig.DeserializeFromXml<CaptureMethodXml>("DaqAttrTypeXml/CaptureMethod.xml");

            if (captureMethodXml == null)
            {
                MessageShow.show("Get Capture method parameter from CaptureMethod.xml failed",
                    "从CaptureMethod.xml获取接口地址失败");
                return;
            }
            param = captureMethodXml.captureMethod.Param;

            DaqAttrType.captureMethod.AcquireMode = addAddress(param.AcquireMode, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.FrameCount = addAddress(param.FrameCount, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.LastValidBuffer = addAddress(param.LastValidBuffer, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.FrameWaitMsec = addAddress(param.FrameWaitMsec, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.NumBuffers = addAddress(param.NumBuffers, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.LostFrams = addAddress(param.LostFrams, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.LastActiveFrame = addAddress(param.LastActiveFrame, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.AcquireBufferNum = addAddress(param.AcquireBufferNum, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.AcquireBufferIndex = addAddress(param.AcquireBufferIndex, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.TransferBufferNum = addAddress(param.TransferBufferNum, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.TransferBufferIndex = addAddress(param.TransferBufferIndex, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.ActiveBuffer = addAddress(param.ActiveBuffer, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.LoadFileDownAddr = addAddress(param.LoadFileDownAddr, DaqAttrType.baseAddr);
            DaqAttrType.captureMethod.LoadFileRunAddr = addAddress(param.LoadFileRunAddr, DaqAttrType.baseAddr);
        }

        private static uint addAddress(string str, uint startAddr)
        {
            return Convert.ToUInt32(str, 16) + startAddr;
        }
    }
}
