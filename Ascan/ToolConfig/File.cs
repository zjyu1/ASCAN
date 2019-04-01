using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ascan
{
    public static class LogFile
    {
        private static readonly String fileName = @"time.txt";
        private static StreamWriter writer;

        public static void  init()
        {
            if (writer == null)
                writer = new StreamWriter(fileName, false);
        }

        public static void flush()
        {
            if (writer != null)
            {
                writer.Flush();
            }
        }

        public static void close()
        {
            if(writer != null)
            {
                writer.Flush();
                writer.Close();
            }
        }

        public static void write(String str)
        {
            String time = System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second + "-" + System.DateTime.Now.Millisecond;
            writer.WriteLine(str + ": " + time);
        }
    }
}
