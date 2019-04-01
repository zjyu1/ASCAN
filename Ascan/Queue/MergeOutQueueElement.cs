using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class MeasureQueueElement : IClone<MeasureQueueElement>
    {
        //indicate is flush buff
        private bool isEnd;

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

        //board id of the packet
        public int boardIndex;

        //a frame of measure data
        public GatePacket gatePacket;

        public MeasureQueueElement()
        {
            isEnd = false;
            boardIndex = -1;
            gatePacket = new GatePacket();
        }

        public void clone(MeasureQueueElement dest)
        {
            dest.isEnd = this.isEnd;
            dest.boardIndex = this.boardIndex;
            gatePacket.clone(dest.gatePacket);
        }
    }
}
