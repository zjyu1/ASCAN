using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Ascan
{
    public class LogHelper
    {
        private static object locker = new object();

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }

        #endregion

        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        /// <param name="Tag">传入标签（这里用于标识函数由哪个线程调用）</param>
        public static void WriteLog(string Tag, StackTrace st)
        {
            lock (locker)
            {
                string filePath = Application.StartupPath + @"\Log\" + DateTime.Now.Year + @"\" + DateTime.Now.Month;
                if (!Directory.Exists(filePath))
                {
                    try
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    catch
                    {
                        filePath = Application.StartupPath;
                    }
                }
                string LogAddress = filePath + @"\" +
                        DateTime.Now.Year + '-' +
                        DateTime.Now.Month + '-' +
                        DateTime.Now.Day + "_Log.log";

                StackFrame sf = st.GetFrame(0);

                //把异常信息输出到文件
                StreamWriter sw = new StreamWriter(LogAddress, true);
                sw.WriteLine("文件名：" + sf.GetFileName());
                sw.WriteLine("函数名：" + sf.GetMethod().Name);
                sw.WriteLine("文件行号：" + sf.GetFileLineNumber());
                sw.WriteLine("文件列号：" + sf.GetFileColumnNumber());
                sw.WriteLine(String.Concat('[', DateTime.Now.ToString(), "] 错误描述:" + Tag));
                sw.WriteLine();
                sw.Close();
            }
        }

        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        /// <param name="Tag">传入标签（这里用于标识函数由哪个线程调用）</param>
        public static void WriteLog(Exception ex, StackTrace st)
        {
            lock (locker)
            {
                string filePath = Application.StartupPath + @"\Log\" + DateTime.Now.Year + @"\" + DateTime.Now.Month;
                if (!Directory.Exists(filePath))
                {
                    try
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    catch
                    {
                        filePath = Application.StartupPath;
                    }
                }
                string LogAddress = filePath + @"\" +
                        DateTime.Now.Year + '-' +
                        DateTime.Now.Month + '-' +
                        DateTime.Now.Day + "_Log.log";

                StackFrame sf = st.GetFrame(0);

                //把异常信息输出到文件
                StreamWriter sw = new StreamWriter(LogAddress, true);
                sw.WriteLine("文件名：" + sf.GetFileName());
                sw.WriteLine("函数名：" + sf.GetMethod().Name);
                sw.WriteLine("文件行号：" + sf.GetFileLineNumber());
                sw.WriteLine("文件列号：" + sf.GetFileColumnNumber());
                sw.WriteLine(String.Concat('[', DateTime.Now.ToString(), "] 异常描述:" + ex.Message));
                sw.WriteLine();
                sw.Close();
            }
        }

        public static void WriteMLog(string Tag, StackTrace st)
        {
            lock (locker)
            {
                string filePath = Application.StartupPath + @"\Log\" + DateTime.Now.Year + @"\" + DateTime.Now.Month;
                if (!Directory.Exists(filePath))
                {
                    try
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    catch
                    {
                        filePath = Application.StartupPath;
                    }
                }
                string LogAddress = filePath + @"\" +
                        DateTime.Now.Year + '-' +
                        DateTime.Now.Month + '-' +
                        DateTime.Now.Day + "_MLog.log";

                StackFrame sf = st.GetFrame(0);

                //把异常信息输出到文件
                StreamWriter sw = new StreamWriter(LogAddress, true);
                sw.WriteLine("文件名：" + sf.GetFileName());
                sw.WriteLine("函数名：" + sf.GetMethod().Name);
                sw.WriteLine("文件行号：" + sf.GetFileLineNumber());
                sw.WriteLine("文件列号：" + sf.GetFileColumnNumber());
                sw.WriteLine(String.Concat('[', DateTime.Now.ToString(), "] 错误描述:" + Tag));
                sw.WriteLine();
                sw.Close();
            }
        }

    }
}