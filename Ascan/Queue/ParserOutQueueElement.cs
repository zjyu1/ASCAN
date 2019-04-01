using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class AscanQueueElement : IClone<AscanQueueElement>
    {
        //indicate is flush buff
        private bool isEnd;

        //a frame of ascan
        public AscanSetPacket ascanPacket;

        public bool IsEnd
        {
            get
            {
                return isEnd;
            }
            set
            {
                isEnd = value;
            }
        }

        public AscanQueueElement()
        {
            isEnd = false;
            ascanPacket = new AscanSetPacket();
        }

        public void clone(AscanQueueElement dest)
        {
            dest.isEnd = this.isEnd;
            ascanPacket.clone(dest.ascanPacket);
        }

        public uint getPort()
        {
            return ascanPacket.head.port;
        }
    }

    public class MergeInQueueElement : IClone<MergeInQueueElement>
    {
        //indicate is flush buff
        private bool isEnd;
        public UniSetPacket setPacket;

        public bool IsEnd
        {
            get
            {
                return isEnd;
            }
            set
            {
                isEnd = value;
            }
        }

        public MergeInQueueElement()
        {
            isEnd = false;
            setPacket = new UniSetPacket();

            setPacket.start = new uint[2];
            setPacket.stampPos = new int[3];
            setPacket.stampInc = new int[3];

            setPacket.ud = new uint[ConstParameter.MaxUintArrayCount];
            setPacket.fd = new float[ConstParameter.MaxFloatArrayCount];

            setPacket.stop = new uint[2];
        }

        public void clone(MergeInQueueElement destElement)
        {
            destElement.isEnd = this.isEnd;

            destElement.setPacket.port = this.setPacket.port;
            destElement.setPacket.id = this.setPacket.id;
            destElement.setPacket.bin = this.setPacket.bin;
            destElement.setPacket.size = this.setPacket.size;

            Array.Copy(this.setPacket.start, destElement.setPacket.start, setPacket.start.Length);

            destElement.setPacket.stampMode = this.setPacket.stampMode;

            Array.Copy(this.setPacket.stampPos, destElement.setPacket.stampPos, setPacket.stampPos.Length);
            Array.Copy(this.setPacket.stampInc, destElement.setPacket.stampInc, setPacket.stampInc.Length);

            destElement.setPacket.cellNum = this.setPacket.cellNum;

            Array.Copy(this.setPacket.ud, destElement.setPacket.ud, setPacket.ud.Length);
            Array.Copy(this.setPacket.fd, destElement.setPacket.fd, setPacket.fd.Length);
            Array.Copy(this.setPacket.stop, destElement.setPacket.stop, setPacket.stop.Length);
        }
    }
}
