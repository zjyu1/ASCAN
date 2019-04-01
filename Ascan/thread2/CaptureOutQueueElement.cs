/*----------------------------------------------------------------
// Copyright (C) 2015 Zhejiang University, ZJU128 Group
// Copyright.
//
// FileName: CaptureOutQueueElement.cs
// File Desc: capture thread output queue element .
//
// Create Tag: 2015-11-27, by Wueryong@ZJU base on QWS's captureThread class
//              
// Revision Tag:
// Revision Desc:
//
// Revision Tag:
// Revision Desc:
//----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ascan
{
       
    //
    public class CaptureOutQueueElement : IDisposable
    {
        //is freed
        private bool disposed;

        //pkg counter 
        public uint pkgCounter;

        //buf
        public byte[] pBuf;

        //indicate is flush buff
        public bool isEnd;

        //construct
        public CaptureOutQueueElement(bool isAlloc)
        {
            pkgCounter = 0;

            if (isAlloc == true)
            {
                pBuf = new byte[Gbl.defaultCaptureBufElementSize]; //1M size
            }
            else
            {
                pBuf = null;
            }

            isEnd = false;

            disposed = false;
        }

        public CaptureOutQueueElement()
        {
            pkgCounter = 0;

            pBuf = new byte[Gbl.defaultCaptureBufElementSize];   

            isEnd = false;

            disposed = false;
        }


        //
        public void Dispose()
        {
            //must be true
            Dispose(true);

            //call GC to free
            GC.SuppressFinalize(this);
        }

        //desconstruct, for programmer forget call Dispose
        ~CaptureOutQueueElement()
        {
            Dispose(false);
        }

        //
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // free managed res
                if (pBuf != null)
                {
                    pBuf = null;
                }
            }

            //update
            disposed = true;
        }

    }//end of class CaptureOutQueueElement

} //end of Ascan namespace
