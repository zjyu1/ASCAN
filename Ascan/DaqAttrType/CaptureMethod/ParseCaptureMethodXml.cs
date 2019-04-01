using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class CaptureMethodXml
    {
        [XmlElement("CaptureMethod")]
        public CaptureMethod captureMethod;
    }

    [XmlType(TypeName = "CaptureMethod")]
    public class CaptureMethod
    {
        public StrCaptureMethod Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrCaptureMethod
    {
        [XmlAttribute]
        public string AcquireMode;

        [XmlAttribute]
        public string FrameCount;

        [XmlAttribute]
        public string LastValidBuffer;

        [XmlAttribute]        
        public string FrameWaitMsec;

        [XmlAttribute]
        public string NumBuffers;

        [XmlAttribute]
        public string LostFrams;

        [XmlAttribute]
        public string LastActiveFrame;

        [XmlAttribute]
        public string AcquireBufferNum;

        [XmlAttribute]
        public string AcquireBufferIndex;

        [XmlAttribute]
        public string TransferBufferNum;

        [XmlAttribute]
        public string TransferBufferIndex;

        [XmlAttribute]
        public string ActiveBuffer;

        [XmlAttribute]
        public string LoadFileDownAddr;

        [XmlAttribute]
        public string LoadFileRunAddr;
    }
}
