/*----------------------------------------------------------------
// Copyright (C) 2015 Zhejiang University, ZJU128 Group
// Copyright.
//
// FileName: Gbl.cs
// File Desc: Global data defination, and its get or set with lock protected
//
//
// Create Tag: 2015-11-27, by Wueryong@ZJU
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
    public enum GblErr
    {
        Success = 0,
        Failor = -1
    }

    public class Gbl
    {
        //glbal quit for all thread 
        private static bool quit;

        //lock for get/set quit
        private readonly object quitLockObj;

        public Gbl()
        {
            quitLockObj = new Object();
            quit = false; //not quit
        }

        //get
        public bool gblGetQuit()
        {
            bool q;

            lock(quitLockObj)
            {
                q = quit;
            }

            return q;       
        }

        //set
        public void gblSetQuit(bool q)
        {
            lock(quitLockObj)
            {
                quit = q;
            } 
        }
 
    } //end of class Gbl

} //end of namespace Ascan