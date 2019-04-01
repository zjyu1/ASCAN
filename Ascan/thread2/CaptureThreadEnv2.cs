/*----------------------------------------------------------------
// Copyright (C) 2015 Zhejiang University, ZJU128 Group
// Copyright.
//
// FileName: CaptureThreadEnv2.cs
// File Desc: capture thread environment.
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
    // Capture thread environment
    public class CaptureThreadEnv2
    {
        // init Rendezvous
        public ThreadHandClasp init;

        // clean Rendezvous
        public ThreadHandClasp clean;

        // OutputQueue of the thread
        public QueueAbstract captureOutQueueAbstract;

        //board id
        public uint boardId;
    }

} //end of Ascan namespace

