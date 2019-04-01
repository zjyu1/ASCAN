using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;

namespace Ascan
{
    class INIOperation
    {
        
        #region
      
        //DllImport只能放置在方法声明上
        [DllImport("kernel32")]
        //用DllImport属性修饰的方法必须具有extern修饰符
        private static extern int GetPrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedString,
            int nSize,
            string lpFileName);

        public string ContentReader(string area, string filepath,string key, string def)
        {
            StringBuilder stringBuilder = new StringBuilder(1024); 				//定义一个最大长度为1024的可变字符串
            GetPrivateProfileString(area, key, def, stringBuilder, 1024, filepath); 			//读取INI文件
            return stringBuilder.ToString();								//返回INI文件的内容
        }

        [DllImport("kernel32")]
        //用DllImport属性修饰的方法必须具有extern修饰符
        private static extern long WritePrivateProfileString(
            string mpAppName,
            string mpKeyName,
            string mpDefault,
            string mpFileName);
        //返回所读取的字符串值得真实长度
        [DllImport("Kernel32.dll")]
        private extern static int GetPrivateProfileSectionNamesA(byte[] buffer, int iLen, string fileName);
        //返回所读取的字符串值的真实长度  
        [DllImport("Kernel32.dll")]
        private extern static int GetPrivateProfileStringA(string strAppName, string strKeyName, string sDefault, byte[] buffer, int nSize, string strFileName);
        [DllImport("Kernel32.dll")]
        private static extern int GetPrivateProfileInt(string strAppName, string strKeyName, int nDefault, string strFileName);
        #endregion



        /// <summary>  
        /// 返回该配置文件中所有Section名称的集合  
        /// </summary>  
        /// <returns></returns>  
        public ArrayList ReadSections(string filepath)
        {
            byte[] buffer = new byte[65535];
            int rel = GetPrivateProfileSectionNamesA(buffer, buffer.GetUpperBound(0), filepath);
            int iCnt, iPos;
            ArrayList arrayList = new ArrayList();
            string tmp;
            if (rel > 0)
            {
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = System.Text.ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                            arrayList.Add(tmp);
                    }
                }
            }
            return arrayList;
        }


        /// <summary>  
        ///  获取指定节点的所有KEY的名称  
        /// </summary>  
        /// <param name="sectionName"></param>  
        /// <returns></returns>  
        public ArrayList ReadKeys(string filepath,string sectionName)
        {

            byte[] buffer = new byte[5120];
            int rel = GetPrivateProfileStringA(sectionName, null, "", buffer, buffer.GetUpperBound(0), filepath);

            int iCnt, iPos;
            ArrayList arrayList = new ArrayList();
            string tmp;
            if (rel > 0)
            {
                iCnt = 0; iPos = 0;
                for (iCnt = 0; iCnt < rel; iCnt++)
                {
                    if (buffer[iCnt] == 0x00)
                    {
                        tmp = System.Text.ASCIIEncoding.Default.GetString(buffer, iPos, iCnt - iPos).Trim();
                        iPos = iCnt + 1;
                        if (tmp != "")
                            arrayList.Add(tmp);
                    }
                }
            }
            return arrayList;
        }

        /// <summary>  
        /// 读取指定节点下的指定key的value返回string  
        /// </summary>  
        /// <param name="section"></param>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public string GetIniKeyValueForStr(string filepath,string section, string key)
        {
            if (section.Trim().Length <= 0 || key.Trim().Length <= 0)
                return string.Empty;
            StringBuilder strTemp = new StringBuilder(256);
            GetPrivateProfileString(section, key, string.Empty, strTemp, 256, filepath);
            return strTemp.ToString().Trim();
        }

        /// <summary>  
        /// 从指定的节点中获取一个整数值( Long，找到的key的值；如指定的key未找到，就返回默认值。如找到的数字不是一个合法的整数，函数会返回其中合法的一部分。如，对于“xyz=55zz”这个条目，函数返回55。)  
        /// </summary>  
        /// <param name="section"></param>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public int GetIniKeyValueForInt(string filepath,string section, string key)
        {
            if (section.Trim().Length <= 0 || key.Trim().Length <= 0) return 0;
            return GetPrivateProfileInt(section, key, 0, filepath);
        }




        public long WriteToIni(string mpAppName,string mpKeyName,string mpDefault,string mpFileName)
        {
            long a;
            a=WritePrivateProfileString(mpAppName, mpKeyName,mpDefault,mpFileName);
            return a;
        }

    }
}
