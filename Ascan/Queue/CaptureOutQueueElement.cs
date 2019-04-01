/*************************************************************************
 * Copyright (C) 2015 Zhejiang University, ZJU128 Group
 * Copyright.
 *
 * FileName: CaptureOutQueueElement.cs
 * File Desc: capture thread output queue element .
 *
 * Create Tag: 2015-11-27, by Wueryong@ZJU base on QWS's captureThread class
 *             
 * Revision Tag:
 * Revision Desc:
 *
 * Revision Tag:
 * Revision Desc:
 **************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ascan
{
    public class CaptureOutQueueElement : IClone<CaptureOutQueueElement>
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

        //construct
        public CaptureOutQueueElement()
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

        public void clone(CaptureOutQueueElement destElement)
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

            //Buffer.BlockCopy(this.setPacket.ud, 0, destElement.setPacket.ud, 0, setPacket.ud.Length);
            //Buffer.BlockCopy(this.setPacket.fd, 0, destElement.setPacket.fd, 0, setPacket.fd.Length);

            Array.Copy(this.setPacket.ud, destElement.setPacket.ud, setPacket.ud.Length);
            Array.Copy(this.setPacket.fd, destElement.setPacket.fd, setPacket.fd.Length);

            Array.Copy(this.setPacket.stop, destElement.setPacket.stop, setPacket.stop.Length);
        }

    }//end of class CaptureOutQueueElement

} //end of Ascan namespace
