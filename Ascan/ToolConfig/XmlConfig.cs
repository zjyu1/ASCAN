using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System.IO;

namespace Ascan
{
	public class SystemConfig
	{
        public static string fname;
        public static string sessionListPath;
        public static string productPath;
        public static string probePath;
        public static string wedgePath;
        public static string detectionModePath;
        public static bool saveFlag = false;
        private static List<SessionInfo> sessionIfo = new List<SessionInfo>();
		#region"基本操作函数"
		/// <summary>
		/// 得到程序工作目录
		/// </summary>
		/// <returns></returns>
		private static string GetWorkDirectory()
		{
			try
			{
				return Path.GetDirectoryName(typeof(SystemConfig).Assembly.Location);
			}
			catch
			{
				return System.Windows.Forms.Application.StartupPath;
			}
		}
		/// <summary>
		/// 判断字符串是否为空串
		/// </summary>
		/// <param name="szString">目标字符串</param>
		/// <returns>true:为空串;false:非空串</returns>
		private static bool IsEmptyString(string szString)
		{
			if (szString == null)
				return true;
			if (szString.Trim() == string.Empty)
				return true;
			return false;
		}
		/// <summary>
		/// 创建一个制定根节点名的XML文件
		/// </summary>
		/// <param name="szFileName">XML文件</param>
		/// <param name="szRootName">根节点名</param>
		/// <returns>bool</returns>
		private static bool CreateXmlFile(string szFileName, string szRootName)
		{
			if (szFileName == null || szFileName.Trim() == "")
				return false;
			if (szRootName == null || szRootName.Trim() == "")
				return false;

			XmlDocument clsXmlDoc = new XmlDocument();
			clsXmlDoc.AppendChild(clsXmlDoc.CreateXmlDeclaration("1.0", "GBK", null));
			clsXmlDoc.AppendChild(clsXmlDoc.CreateNode(XmlNodeType.Element, szRootName, ""));
			try
			{
				clsXmlDoc.Save(szFileName);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 从XML文件获取对应的XML文档对象
		/// </summary>
		/// <param name="szXmlFile">XML文件</param>
		/// <returns>XML文档对象</returns>
		private static XmlDocument GetXmlDocument(string szXmlFile)
		{
			if (IsEmptyString(szXmlFile))
				return null;
			if (!File.Exists(szXmlFile))
				return null;
			XmlDocument clsXmlDoc = new XmlDocument();
			try
			{
				clsXmlDoc.Load(szXmlFile);
			}
			catch
			{
				return null;
			}
			return clsXmlDoc;
		}

		/// <summary>
		/// 将XML文档对象保存为XML文件
		/// </summary>
		/// <param name="clsXmlDoc">XML文档对象</param>
		/// <param name="szXmlFile">XML文件</param>
		/// <returns>bool:保存结果</returns>
		private static bool SaveXmlDocument(XmlDocument clsXmlDoc, string szXmlFile)
		{
			if (clsXmlDoc == null)
				return false;
			if (IsEmptyString(szXmlFile))
				return false;
			try
			{
				if (File.Exists(szXmlFile))
					File.Delete(szXmlFile);
			}
			catch
			{
				return false;
			}
			try
			{
				clsXmlDoc.Save(szXmlFile);
			}
			catch
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 获取XPath指向的单一XML节点
		/// </summary>
		/// <param name="clsRootNode">XPath所在的根节点</param>
		/// <param name="szXPath">XPath表达式</param>
		/// <returns>XmlNode</returns>
		private static XmlNode SelectXmlNode(XmlNode clsRootNode, string szXPath)
		{
			if (clsRootNode == null || IsEmptyString(szXPath))
				return null;
			try
			{
				return clsRootNode.SelectSingleNode(szXPath);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 获取XPath指向的XML节点集
		/// </summary>
		/// <param name="clsRootNode">XPath所在的根节点</param>
		/// <param name="szXPath">XPath表达式</param>
		/// <returns>XmlNodeList</returns>
		private static XmlNodeList SelectXmlNodes(XmlNode clsRootNode, string szXPath)
		{
			if (clsRootNode == null || IsEmptyString(szXPath))
				return null;
			try
			{
				return clsRootNode.SelectNodes(szXPath);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 创建一个XmlNode并添加到文档
		/// </summary>
		/// <param name="clsParentNode">父节点</param>
		/// <param name="szNodeName">结点名称</param>
		/// <returns>XmlNode</returns>
		private static XmlNode CreateXmlNode(XmlNode clsParentNode, string szNodeName)
		{
			try
			{
				XmlDocument clsXmlDoc = null;
				if (clsParentNode.GetType() != typeof(XmlDocument))
					clsXmlDoc = clsParentNode.OwnerDocument;
				else
					clsXmlDoc = clsParentNode as XmlDocument;
				XmlNode clsXmlNode = clsXmlDoc.CreateNode(XmlNodeType.Element, szNodeName, string.Empty);
				if (clsParentNode.GetType() == typeof(XmlDocument))
				{
					clsXmlDoc.LastChild.AppendChild(clsXmlNode);
				}
				else
				{
					clsParentNode.AppendChild(clsXmlNode);
				}
				return clsXmlNode;
			}
			catch
			{
				return null;
			}
		}


		/// <summary>
		/// 设置指定节点中指定属性的值
		/// </summary>
		/// <param name="parentNode">XML节点</param>
		/// <param name="szAttrName">属性名</param>
		/// <param name="szAttrValue">属性值</param>
		/// <returns>bool</returns>
		private static bool SetXmlAttr(XmlNode clsXmlNode, string szAttrName, string szAttrValue)
		{
			if (clsXmlNode == null)
				return false;
			if (IsEmptyString(szAttrName))
				return false;
			if (IsEmptyString(szAttrValue))
				szAttrValue = string.Empty;
			XmlAttribute clsAttrNode = clsXmlNode.Attributes.GetNamedItem(szAttrName) as XmlAttribute;
			if (clsAttrNode == null)
			{
				XmlDocument clsXmlDoc = clsXmlNode.OwnerDocument;
				if (clsXmlDoc == null)
					return false;
				clsAttrNode = clsXmlDoc.CreateAttribute(szAttrName);
				clsXmlNode.Attributes.Append(clsAttrNode);
			}
			clsAttrNode.Value = szAttrValue;
			return true;
		}
		#endregion

		#region"配置文件的读取和写入"
		/// <summary>
		///  读取指定的配置文件中指定Key的值
		/// </summary>
		/// <param name="szKeyName">读取的Key名称</param>
		/// <param name="szDefaultValue">指定的Key不存在时,返回的值</param>
		/// <returns>Key值</returns>
		public static double GetConfigData(string file, string szKeyName, double nDefaultValue)
		{
			string szValue = GetConfigData(file, szKeyName, nDefaultValue.ToString());
			try
			{
				return double.Parse(szValue);
			}
			catch
			{
				return nDefaultValue;
			}
		}

		public static int GetConfigData(string file, string szKeyName, int nDefaultValue)
		{
			string szValue = GetConfigData(file, szKeyName, nDefaultValue.ToString());
			try
			{
				return int.Parse(szValue);
			}
			catch
			{
				return nDefaultValue;
			}
		}

        public static uint GetConfigData(string file, string szKeyName, uint nDefaultValue)
        {
            string szValue = GetConfigData(file, szKeyName, nDefaultValue.ToString());
            try
            {
                return Convert.ToUInt32(szValue,16);
            }
            catch
            {
                return nDefaultValue;
            }
        }

		/// <summary>
		///  读取指定的配置文件中指定Key的值
		/// </summary>
		/// <param name="szKeyName">读取的Key名称</param>
		/// <param name="szDefaultValue">指定的Key不存在时,返回的值</param>
		/// <returns>Key值</returns>
		public static float GetConfigData(string file, string szKeyName, float fDefaultValue)
		{
			string szValue = GetConfigData(file, szKeyName, fDefaultValue.ToString());
			try
			{
				return float.Parse(szValue);
			}
			catch
			{
				return fDefaultValue;
			}
		}

		/// <summary>
		///  读取指定的配置文件中指定Key的值
		/// </summary>
		/// <param name="szKeyName">读取的Key名称</param>
		/// <param name="szDefaultValue">指定的Key不存在时,返回的值</param>
		/// <returns>Key值</returns>
		public static bool GetConfigData(string file, string szKeyName, bool bDefaultValue)
		{
			string szValue = GetConfigData(file, szKeyName, bDefaultValue.ToString());
			try
			{
				return bool.Parse(szValue);
			}
			catch
			{
				return bDefaultValue;
			}
		}

		/// <summary>
		///  读取指定的配置文件中指定Key的值
		/// </summary>
		/// <param name="szKeyName">读取的Key名称</param>
		/// <param name="szDefaultValue">指定的Key不存在时,返回的值</param>
		/// <returns>Key值</returns>
		public static string GetConfigData(string file, string szKeyName, string szDefaultValue)
		{
			string szConfigFile = file; //= string.Format("{0}\\{1}", GetWorkDirectory(), CONFIG_FILE);
			if (!File.Exists(szConfigFile))
			{
				return szDefaultValue;
			}

			XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
			if (clsXmlDoc == null)
				return szDefaultValue;

			string szXPath = "/main/" + szKeyName;//string.Format("/SystemConfig/%s", szKeyName);
			XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
			if (clsXmlNode == null)
			{
				return szDefaultValue;
			}
			return clsXmlNode.InnerText;

			/*
			string szXPath = string.Format(".//key[@name='{0}']", szKeyName);
			XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
			if (clsXmlNode == null)
			{
				return szDefaultValue;
			}

			XmlNode clsValueAttr = clsXmlNode.Attributes.GetNamedItem("valueTCGGCG");
			if (clsValueAttr == null)
				return szDefaultValue;
             
			return clsValueAttr.Value;
			*/
		}

		/// <summary>
		///  保存指定Key的值到指定的配置文件中
		/// </summary>
		/// <param name="szKeyName">要被修改值的Key名称</param>
		/// <param name="szValue">新修改的值</param>
		public static bool WriteConfigData(string file, string szKeyName, string szValue)
		{
			string szConfigFile = file;// string.Format("{0}\\{1}", GetWorkDirectory(), CONFIG_FILE);
			if (!File.Exists(szConfigFile))
			{
				if (!CreateXmlFile(szConfigFile, "main"))
					return false;
			}
			XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);

			string szXPath = "/main/" + szKeyName;//string.Format("/SystemConfig/%s", szKeyName);
			XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
			if (clsXmlNode == null)
			{
				clsXmlNode = CreateXmlNode(clsXmlDoc, szKeyName);
			}
			clsXmlNode.InnerText = szValue;
			/*
			string szXPath = string.Format(".//key[@name='{0}']", szKeyName);
			XmlNode clsXmlNode = SelectXmlNode(clsXmlDoc, szXPath);
			if (clsXmlNode == null)
			{
				clsXmlNode = CreateXmlNode(clsXmlDoc, "key");
			}
			if (!SetXmlAttr(clsXmlNode, "name", szKeyName))
				return false;
			if (!SetXmlAttr(clsXmlNode, "valueTCGGCG", szValue))
				return false;
			*/
			//
			return SaveXmlDocument(clsXmlDoc, szConfigFile);
		}

		///// <summary>
		///// </summary>
		///// <param name="bytes"></param>
		///// <returns></returns>
		//private static string ByteToHexString(byte[] bytes)
		//{

		//    /*
		//    string str = string.Empty;
		//    if (bytes != null)
		//    {
		//        for (int i = 0; i < bytes.Length; i++)
		//        {
		//            str += bytes[i].ToString("X2");
		//        }
		//    }
		//    return str;
		//    */

		//    string hexString = string.Empty;
		//    if (bytes != null)
		//    {
		//        StringBuilder strB = new StringBuilder();

		//        for (int i = 0; i < bytes.Length; i++)
		//        {
		//            strB.Append(bytes[i].ToString("X2"));
		//        }
		//        hexString = strB.ToString();
		//    }
		//    return hexString;
		//}


		public static bool WriteBase64Data(string file, string name, object obj)
		{
			string szConfigFile = file; //string.Format("{0}\\{1}", GetWorkDirectory(), CONFIG_FILE);
			if (!File.Exists(szConfigFile))
			{
				if (!CreateXmlFile(szConfigFile, "main"))
					return false;
			}

			//序列化
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			System.IO.MemoryStream memStream = new System.IO.MemoryStream();
			serializer.Serialize(memStream, obj);
			byte[] buf = memStream.GetBuffer();

			XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
			string textString = System.Convert.ToBase64String(buf);
			XmlText text = clsXmlDoc.CreateTextNode(textString);

			XmlNode node = clsXmlDoc.SelectSingleNode("main/" + name);
			if (node != null)
			{
				node.InnerText = textString;
			}
			else
			{
				XmlElement elem = clsXmlDoc.CreateElement(name);
				clsXmlDoc.DocumentElement.AppendChild(elem);
				clsXmlDoc.DocumentElement.LastChild.AppendChild(text);
			}

			return SaveXmlDocument(clsXmlDoc, szConfigFile);
		}


		//public static bool WriteBinHexSampleData(string file, string name, object obj)
		//{
		//    string szConfigFile = file;// string.Format("{0}\\{1}", GetWorkDirectory(), CONFIG_FILE);
		//    if (!File.Exists(szConfigFile))
		//    {
		//        if (!CreateXmlFile(szConfigFile, "main"))
		//            return false;
		//    }
		//    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		//    System.IO.MemoryStream memStream = new System.IO.MemoryStream();
		//    serializer.Serialize(memStream, obj);
		//    byte[] buf = memStream.GetBuffer();
		//    XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);

		//    //string textString = xmlTextWriter.WriteBinHex(;
		//    string textString = ByteToHexString(buf);
		//    XmlText text = clsXmlDoc.CreateTextNode(textString);
		//    XmlNode node = clsXmlDoc.SelectSingleNode("main/"+name);
		//    if (node != null)
		//    {
		//        node.InnerText = textString;
		//    }
		//    else
		//    {
		//        XmlElement elem = clsXmlDoc.CreateElement(name);
		//        clsXmlDoc.DocumentElement.AppendChild(elem);
		//        clsXmlDoc.DocumentElement.LastChild.AppendChild(text);
		//    }

		//    return SaveXmlDocument(clsXmlDoc, szConfigFile);
		//}



        //反序列化
		public static object ReadBase64Data(string file, string name)
		{
			int readByte = 0;

			string szConfigFile = file;//= string.Format("{0}\\{1}", GetWorkDirectory(), CONFIG_FILE);
			if (!File.Exists(szConfigFile))
			{
				return null;
			}
			object newobj = null;
			try
			{
				XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
				XmlTextReader xmlTextReader = new XmlTextReader(szConfigFile);
				XmlElement theImage = (XmlElement)clsXmlDoc.SelectSingleNode("/main/" + name);
				xmlTextReader.MoveToElement();
				while (xmlTextReader.Read())
				{
					if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == name)
					{

						//读缓存
						int len = theImage.InnerText.Length;
						byte[] buf = new byte[len];
						readByte = xmlTextReader.ReadBase64(buf, 0, len);
						//反序列化
						System.IO.MemoryStream memStream = new MemoryStream(buf);
						memStream.Position = 0;
						System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer =
						new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
						newobj = deserializer.Deserialize(memStream);
						memStream.Close();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				newobj = null;
			}

			return newobj;
		}


		//public static object ReadBinHexSampleData(string file, string name)
		//{
		//    int readByte = 0;

		//    string szConfigFile = file;//= string.Format("{0}\\{1}", GetWorkDirectory(), CONFIG_FILE);
		//    if (!File.Exists(szConfigFile))
		//    {
		//        return null;
		//    }

		//    XmlDocument clsXmlDoc = GetXmlDocument(szConfigFile);
		//    XmlTextReader xmlTextReader = new XmlTextReader(szConfigFile);
		//    XmlElement theImage = (XmlElement)clsXmlDoc.SelectSingleNode("/main/"+ name );
		//    xmlTextReader.MoveToElement();
		//    while (xmlTextReader.Read())
		//    {
		//        if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == name)
		//        {
		//            int len = theImage.InnerText.Length;
		//            byte[] buf = new byte[len];
		//            readByte = xmlTextReader.ReadBinHex(buf, 0, len);
		//            System.IO.MemoryStream memStream = new MemoryStream(buf);
		//            memStream.Position = 0;
		//            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer =
		//            new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		//            object newobj = deserializer.Deserialize(memStream);
		//            //xmlTextReader.ReadContentAsBinHex(buf,0,int.MaxValue)
		//            memStream.Close();
		//            return newobj;
		//        }
		//    }  
		//    return null;
		//}

        /// <summary>
        /// 从某一XML文件反序列化到某一类型
        /// </summary>
        /// <param name="filePath">待反序列化的XML文件名称</param>
        /// <param name="type">反序列化出的</param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                    throw new ArgumentNullException(filePath + " not Exists");

                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    T ret = (T)xs.Deserialize(reader);
                    reader.Close();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        //重载 by jpc
        public static T DeserializeFromXml<T>(string filePath, T ret)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                    throw new ArgumentNullException(filePath + " not Exists");

                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    ret = (T)xs.Deserialize(reader);
                    reader.Close();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return default(T);
            }
        }

        //

        //从某一类型序列化到XML文件
        public static void SerializeToXml<T>(string filePath, T obj)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    xs.Serialize(writer, obj);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

		#endregion

        public static string GlobalLoad(string formname)
        {
            //string filename;
            string globalFile = AppDomain.CurrentDomain.BaseDirectory.ToString()+"LoadData\\" +fname+"\\"+ formname + ".xml";
            if (File.Exists(globalFile))
                return globalFile;
            else
            {
                return "";
            }
        }

        public static string GlobalSave(string formname)
        {
            string globalFile = AppDomain.CurrentDomain.BaseDirectory.ToString() + "LoadData\\" + fname + "\\" + formname + ".xml";
            return globalFile;

        }

        public static void LoadPara()
        {
            sessionIfo = FormList.mySessionsListForm.sessionsAttrs;

            string filename = SystemConfig.GlobalLoad("GateI");
            if (filename != "")
            {
                string gateName = "GateI";
                LoadGate(filename,gateName);
            }

            filename = SystemConfig.GlobalLoad("GateA");
            if (filename != "")
            {
                string gateName = "GateA";
                LoadGate(filename, gateName);
            }

            filename = SystemConfig.GlobalLoad("GateB");
            if (filename != "")
            {
                string gateName = "GateB";
                LoadGate(filename,gateName);
            }

            filename = SystemConfig.GlobalLoad("GateC");
            if (filename != "")
            {
                string gateName = "GateC";
                LoadGate(filename, gateName);
            }

            filename = SystemConfig.GlobalLoad("MDIChildPara");
            if (filename != "")
            {
                string name = "MDIChildPara";
                LoadMDIPara(filename, name);
            }

        }

        private static void LoadGate(string filename, string gatename)
        {
            List<Gate> gate;
            gate = (List<Gate>)SystemConfig.ReadBase64Data(filename, gatename);
            if (gate == null) return;

            for (int i = 0; i < sessionIfo.Count; i++)
            {
                int error_code;
                SelectAscan.sessionIndex = (uint)sessionIfo[i].sessionIndex;
                SelectAscan.userIndex = (uint)sessionIfo[i].userIndex;
                SelectAscan.port = (uint)sessionIfo[i].port;

                if (gate[i].gateDelay == 0 && gate[i].gateThreshold == 0 && gate[i].gateWidth == 0)
                    continue;

                GateType gateNum = (GateType)gate[i].gateNum;

                bool isSetPre = false;
                if (SetBatchDAQ.isOn)
                    isSetPre = SetBatchDAQ.setTofMode(SelectAscan.sessionIndex, gateNum,(TofMode)gate[i].tofModeNum);
                else
                    isSetPre = SetGateDAQ.setTofMode(SelectAscan.sessionIndex, SelectAscan.port, gateNum, (TofMode)gate[i].tofModeNum);

                if (gate[i].gateLogicOff == 0)
                {
                    if (SetBatchDAQ.isOn)
                        SetBatchDAQ.AlarmActive(SelectAscan.sessionIndex, gateNum, GateAlarmActive.OFF);
                    else
                        SetGateDAQ.AlarmActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, GateAlarmActive.OFF);
                }
                else
                {
                    if (SetBatchDAQ.isOn)
                    {
                        error_code = SetBatchDAQ.AlarmLogic(SelectAscan.sessionIndex, gateNum, (GateAlarmLogic)gate[i].gateLogicNum);
                        error_code |= SetBatchDAQ.AlarmActive(SelectAscan.sessionIndex, gateNum, GateAlarmActive.ON);
                    }
                    else
                    {
                        error_code = SetGateDAQ.AlarmLogic(SelectAscan.sessionIndex, SelectAscan.port, gateNum, (GateAlarmLogic)gate[i].gateLogicNum);
                        error_code = SetGateDAQ.AlarmActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, GateAlarmActive.ON);
                    }
                }

                if (SetBatchDAQ.isOn)
                {
                    error_code = SetBatchDAQ.GateDlay(SelectAscan.sessionIndex, gateNum, gate[i].gateDelay);
                    error_code = SetBatchDAQ.GateWidth(SelectAscan.sessionIndex, gateNum, gate[i].gateWidth);
                    error_code = SetBatchDAQ.GateThreshold(SelectAscan.sessionIndex, gateNum, gate[i].gateThreshold);
                }
                else
                {
                    error_code = SetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gateNum, gate[i].gateDelay);
                    error_code = SetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gateNum, gate[i].gateWidth);
                    error_code = SetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, gateNum, gate[i].gateThreshold);
                }

                if (gate[i].suppressionOn == true)
                {
                    if (SetBatchDAQ.isOn)
                    {
                        error_code = SetBatchDAQ.ScActive(SelectAscan.sessionIndex, gateNum, SuppressCounterActive.ON);
                        SetBatchDAQ.ScCounter(SelectAscan.sessionIndex, gateNum, gate[i].suppressionCount);
                    }
                    else
                    {
                        error_code = SetGateDAQ.ScActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, SuppressCounterActive.ON);
                        SetGateDAQ.ScCounter(SelectAscan.sessionIndex, SelectAscan.port, gateNum, gate[i].suppressionCount);
                    }

                }
                else
                    error_code = SetGateDAQ.ScActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, SuppressCounterActive.OFF);

                if ((GateType)gate[i].gateNum != GateType.I) continue;
                if (gate[i].IfOnOff == true)
                {
                    if (SetBatchDAQ.isOn)
                    {
                        error_code |= SetBatchDAQ.GateIFActive(SelectAscan.sessionIndex, GateType.I, IFActive.ON);
                        error_code |= SetBatchDAQ.AscanVideoIFActive(SelectAscan.sessionIndex, GateType.I, AscanIFActive.ON);
                    }
                    else
                    {
                        error_code |= SetGateDAQ.iFActive(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, IFActive.ON);
                        error_code |= SetAscanVideoDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, AscanIFActive.ON);
                    }
                }

            }
        }

        private static void LoadMDIPara(string filename, string name)
        {
            List<MDIChildPara> mdiChild;
            mdiChild = (List<MDIChildPara>)SystemConfig.ReadBase64Data(filename, name);
            if (mdiChild == null) return;

            for (int i = 0; i < sessionIfo.Count; i++)
            {
                bool isSetPre = false;
                //int error_code;
                SelectAscan.sessionIndex = (uint)sessionIfo[i].sessionIndex;
                SelectAscan.userIndex = (uint)sessionIfo[i].userIndex;
                SelectAscan.port = (uint)sessionIfo[i].port;    

                if (SetBatchDAQ.isOn)
                {
                    SetBatchDAQ.AnalogGain(SelectAscan.sessionIndex, mdiChild[i].gainNum);
                    SetBatchDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, mdiChild[i].speedNum);
                    isSetPre = SetBatchDAQ.WaveMode(SelectAscan.sessionIndex, (AscanWaveDectionMode)mdiChild[i].receiverNum);
                    SetBatchDAQ.RecieverMode(SelectAscan.sessionIndex, (RecieverType)mdiChild[i].tranmissionNum);
                    SetBatchDAQ.EnvlopActive(SelectAscan.sessionIndex, (AscanEnvelopActive)mdiChild[i].envelopNum);
                }
                else
                {
                    SetReceiverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].gainNum);
                    SetAscanVideoDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].speedNum);
                    isSetPre = SetAscanVideoDAQ.WaveMode(SelectAscan.sessionIndex, SelectAscan.port, (AscanWaveDectionMode)mdiChild[i].receiverNum);
                    SetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, (RecieverType)mdiChild[i].tranmissionNum);
                    SetAscanVideoDAQ.EnvlopActive(SelectAscan.sessionIndex, SelectAscan.port, (AscanEnvelopActive)mdiChild[i].envelopNum);
                }

                SetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, (TrigMode)mdiChild[i].trigModeNum);
                SetPulserTransmitDAQ.Prf(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].prfNum);

                //SetReceiverDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, (ReceiverActive)mdiChild[i].recNum);
                //SetReceiverDAQ.AnalogHPF(SelectAscan.sessionIndex, SelectAscan.port, (FilterCutoffFreq)mdiChild[i].AHPFNum);
                //SetReceiverDAQ.AnalogLPF(SelectAscan.sessionIndex, SelectAscan.port, (FilterCutoffFreq)mdiChild[i].ALPFNum);
                //SetReceiverDAQ.DigitalHPF(SelectAscan.sessionIndex, SelectAscan.port, (FilterCutoffFreq)mdiChild[i].DHPFNum);
                //SetReceiverDAQ.DigitalLPF(SelectAscan.sessionIndex, SelectAscan.port, (FilterCutoffFreq)mdiChild[i].DLPFNum);
                //SetReceiverDAQ.RecieverPATH(SelectAscan.sessionIndex, SelectAscan.port, (ReceiverPATH)mdiChild[i].recPathNum);
                //if (mdiChild[i].matchOnOff == 1)
                //{
                //    SetReceiverDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, DampingActive.ON);
                //    SetReceiverDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].matchNum);
                //}
                //else
                //{
                //    SetReceiverDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, DampingActive.OFF);
                //}

                //SetPulserTransmitDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, (PluserActive)mdiChild[i].pulserEnableNum);
                //SetPulserTransmitDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].pulserDelay);
                //SetPulserTransmitDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].pulserWidth);
                //SetPulserTransmitDAQ.Intensity(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].pulserVoltage);
                //if ((PulserDampingActive)mdiChild[i].pulserMatch == PulserDampingActive.ON)
                //{
                //    SetPulserTransmitDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, PulserDampingActive.ON);
                //    SetPulserTransmitDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].pulserMatchValue);
                //}
                //else
                //{
                //    SetPulserTransmitDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, PulserDampingActive.OFF);
                //}

                SetMaterialVelocityDAQ.Velocity(SelectAscan.sessionIndex, SelectAscan.port, mdiChild[i].materialVelocity);

                for (int j = 0; j < 4; j++)
                {
                    if (mdiChild[i].toleranceActiveMode[j] == 2)
                        continue;
                    else if (mdiChild[i].toleranceActiveMode[j] == 0)
                    {
                        SetDGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, TMActive.OFF);
                        SetGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, TMActive.ON);
                        SetGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, mdiChild[i].toleranceMax[j]);
                        SetGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, mdiChild[i].toleranceMin[j]);
                        SetGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, mdiChild[i].toleranceSuppressCnt[j]);
                    }
                    else if (mdiChild[i].toleranceActiveMode[j] == 1)
                    {
                        SetDGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, TMActive.ON);
                        SetGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, TMActive.OFF);
                        SetDGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, mdiChild[i].toleranceMax[j]);
                        SetDGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, mdiChild[i].toleranceMin[j]);
                        SetDGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, mdiChild[i].toleranceSuppressCnt[j]);
                    }
                }

            }

        }

        public static void SavePara() 
        {
            sessionIfo = FormList.mySessionsListForm.sessionsAttrs;
            SaveGate(GateType.I, "GateI");
            SaveGate(GateType.A, "GateA");
            SaveGate(GateType.B, "GateB");
            SaveGate(GateType.C, "GateC");

            SaveMDIPara("MDIChildPara");
            SaveParaPath("parapath");

        }

        private static void SaveGate(GateType gate,string gatename)
        {
            int error_code;
            List<Gate> gateParaList = new List<Gate>();
            for (int i = 0; i < sessionIfo.Count;i++ )
            {
                Gate gatePara = new Gate();
                SelectAscan.sessionIndex = (uint)sessionIfo[i].sessionIndex;
                SelectAscan.userIndex = (uint)sessionIfo[i].userIndex;
                SelectAscan.port = (uint)sessionIfo[i].port;

                gatePara.gateNum = (int)gate;
                TofMode tofMode = TofMode.Peak;
                error_code = GetGateDAQ.TofMode(SelectAscan.sessionIndex, SelectAscan.port, gate, ref tofMode);
                gatePara.tofModeNum = (int)tofMode;

                GateAlarmLogic gateLogic = GateAlarmLogic.Negative;
                GateAlarmActive alarmActive = GateAlarmActive.OFF;
                error_code = GetGateDAQ.AlarmActive(SelectAscan.sessionIndex, SelectAscan.port, gate, ref alarmActive);
                if (alarmActive == GateAlarmActive.OFF)
                {
                    gatePara.gateLogicOff = (int)GateAlarmActive.OFF;
                }
                else if (alarmActive == GateAlarmActive.ON)
                {
                    error_code = GetGateDAQ.AlarmLogic(SelectAscan.sessionIndex, SelectAscan.port, gate, ref gateLogic);
                    gatePara.gateLogicOff = (int)GateAlarmActive.ON;
                    gatePara.gateLogicNum = (int)gateLogic;
                }

                double delay = 0;
                double width = 0;
                double threshold = 0;
                error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gate, ref delay);
                error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gate, ref width);
                error_code = GetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, gate, ref threshold);
                gatePara.gateDelay = delay;
                gatePara.gateWidth = width;
                gatePara.gateThreshold = threshold;

                SuppressCounterActive scActive = SuppressCounterActive.OFF;
                error_code = GetGateDAQ.ScActive(SelectAscan.sessionIndex, SelectAscan.port, gate, ref scActive);

                if (scActive == SuppressCounterActive.ON)
                {
                    gatePara.suppressionOn = true;
                    uint supressCount = 0;
                    error_code = GetGateDAQ.ScCounter(SelectAscan.sessionIndex, SelectAscan.port, gate, ref supressCount);
                    gatePara.suppressionCount = supressCount;                   
                }
                else
                {
                    gatePara.suppressionOn = false;
                }

                if (gate == GateType.I)
                {
                    IFActive ifActive = IFActive.OFF;
                    error_code |= GetGateDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref ifActive);
                    if (ifActive == IFActive.ON) gatePara.IfOnOff = true;
                }

                gateParaList.Add(gatePara);
            }

            string filename = SystemConfig.GlobalSave(gatename);
            SystemConfig.WriteBase64Data(filename, gatename, gateParaList);
        }

        private static void SaveMDIPara(string name)
        {
            int error_code;
            List<MDIChildPara> mdiChildParaList = new List<MDIChildPara>();
            for (int i=0; i < sessionIfo.Count;i++)
            {
                MDIChildPara mdiChild = new MDIChildPara();
                SelectAscan.sessionIndex = (uint)sessionIfo[i].sessionIndex;
                SelectAscan.userIndex = (uint)sessionIfo[i].userIndex;
                SelectAscan.port = (uint)sessionIfo[i].port;

                error_code = GetRecieverDAQ.AnalogGain(SelectAscan.sessionIndex, SelectAscan.port, ref mdiChild.gainNum);
                error_code = GetAsacnVideoDAQ.EnvlopDecayFactor(SelectAscan.sessionIndex, SelectAscan.port, ref mdiChild.speedNum);

                AscanWaveDectionMode waveMode = AscanWaveDectionMode.Rf;
                error_code = GetAsacnVideoDAQ.DetectionWaveMode(SelectAscan.sessionIndex, SelectAscan.port, ref waveMode);
                mdiChild.receiverNum = (int)waveMode;

                RecieverType type = RecieverType.Pe;
                error_code = GetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, ref type);
                mdiChild.tranmissionNum = (int)type;

                AscanEnvelopActive active = AscanEnvelopActive.OFF;
                error_code = GetAsacnVideoDAQ.EnvlopActive(SelectAscan.sessionIndex, SelectAscan.port, ref active);
                mdiChild.envelopNum = (int)active;

                TrigMode trigMode = TrigMode.TrigSoft;
                error_code = GetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, ref trigMode);
                mdiChild.trigModeNum = (int)trigMode;
                error_code = GetPulserTransmitDAQ.Prf(SelectAscan.sessionIndex, SelectAscan.port, ref mdiChild.prfNum);

                ReceiverActive rec = ReceiverActive.OFF;
                error_code = GetRecieverDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, ref rec);
                mdiChild.recNum = (int)rec;

                FilterCutoffFreq analogHPF = FilterCutoffFreq.FilterPassAway;
                FilterCutoffFreq analogLPF = FilterCutoffFreq.FilterPassAway;
                error_code = GetRecieverDAQ.AnalogHPF(SelectAscan.sessionIndex, SelectAscan.port, ref analogHPF);
                error_code = GetRecieverDAQ.AnalogLPF(SelectAscan.sessionIndex, SelectAscan.port, ref analogLPF);
                mdiChild.AHPFNum = (int)analogHPF;
                mdiChild.ALPFNum = (int)analogLPF;

                FilterCutoffFreq digitalHPF = FilterCutoffFreq.FilterPassAway;
                FilterCutoffFreq digitalLPF = FilterCutoffFreq.FilterPassAway;
                error_code = GetRecieverDAQ.DigitalHPF(SelectAscan.sessionIndex, SelectAscan.port, ref digitalHPF);
                error_code = GetRecieverDAQ.DigitalLPF(SelectAscan.sessionIndex, SelectAscan.port, ref digitalLPF);
                mdiChild.DHPFNum = (int)digitalHPF;
                mdiChild.DLPFNum = (int)digitalLPF;

                ReceiverPATH receiverPATH = ReceiverPATH.Normal;
                error_code = GetRecieverDAQ.ReceiverPATH(SelectAscan.sessionIndex, SelectAscan.port, ref receiverPATH);
                mdiChild.recPathNum = (int)receiverPATH;

                DampingActive dampingActive = DampingActive.OFF;
                error_code = GetRecieverDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, ref dampingActive);
                if (dampingActive == DampingActive.ON)
                {
                    mdiChild.matchOnOff = (int)DampingActive.ON;
                    error_code = GetRecieverDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, ref mdiChild.matchNum); 
                } 
                else
                {
                    mdiChild.matchOnOff = (int)DampingActive.OFF;
                }

                PluserActive pulseractive = PluserActive.OFF;
                error_code = GetPulserTransmitDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, ref pulseractive);
                mdiChild.pulserEnableNum = (int)pulseractive;

                double timeDelay = 0;
                double pulseWidth = 0;
                error_code = GetPulserTransmitDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, ref timeDelay);
                error_code = GetPulserTransmitDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, ref pulseWidth);
                mdiChild.pulserDelay = timeDelay;
                mdiChild.pulserWidth = pulseWidth;

                double intensity = 0;
                error_code = GetPulserTransmitDAQ.Intensity(SelectAscan.sessionIndex, SelectAscan.port, ref intensity);
                mdiChild.pulserVoltage = intensity;

                PulserDampingActive puslerMatchActive = PulserDampingActive.OFF;
                uint dampingValue = 0;
                error_code = GetPulserTransmitDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, ref puslerMatchActive);
                error_code = GetPulserTransmitDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, ref dampingValue);
                if (puslerMatchActive == PulserDampingActive.ON)
                {
                    mdiChild.pulserMatch = (int)PulserDampingActive.ON;
                    mdiChild.pulserMatchValue = dampingValue;
                } 
                else
                {
                    mdiChild.pulserMatch = (int)PulserDampingActive.OFF;
                }

                double velocity = 0;
                error_code = GetMaterialVelocityDAQ.Velocity(SelectAscan.sessionIndex, SelectAscan.port, ref velocity);
                mdiChild.materialVelocity = velocity;


                
                for (int j = 0; j < 4;j++)
                {
                    double min = 0;
                    double max = 0;
                    uint suppressCnt = 0;
                    TMActive gateActive = TMActive.OFF;
                    TMActive dGateActive = TMActive.OFF;
                    error_code = GetGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, ref gateActive);
                    error_code = GetDGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, ref dGateActive);
                    if (gateActive == TMActive.ON && dGateActive == TMActive.ON)
                        continue;
                    else if (gateActive == TMActive.ON)
                    {
                        mdiChild.toleranceActiveMode[j] = 0;
                        error_code = GetGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, ref max);
                        error_code = GetGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, ref min);
                        error_code = GetGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, (GateType)j, ref suppressCnt);
                        mdiChild.toleranceMax[j] = max;
                        mdiChild.toleranceMin[j] = min;
                        mdiChild.toleranceSuppressCnt[j] = suppressCnt;
                    }
                    else if (dGateActive == TMActive.ON)
                    {
                        mdiChild.toleranceActiveMode[j] = 1;
                        error_code = GetDGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, ref max);
                        error_code = GetDGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, ref min);
                        error_code = GetDGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)j, ref suppressCnt);
                        mdiChild.toleranceMax[j] = max;
                        mdiChild.toleranceMin[j] = min;
                        mdiChild.toleranceSuppressCnt[j] = suppressCnt;
                    }
                }



                mdiChildParaList.Add(mdiChild);
            }
            string filename = SystemConfig.GlobalSave(name);
            SystemConfig.WriteBase64Data(filename, name, mdiChildParaList);
        }

        private static void SaveParaPath(string name)
        {
            ParaPath path = new ParaPath();
            path.sessionListPath = sessionListPath;
            path.productPath = productPath;
            path.probePath = probePath;
            path.wedgePath = wedgePath;
            path.detectionModePath = detectionModePath;

            string filename = SystemConfig.GlobalSave(name);
            SystemConfig.WriteBase64Data(filename, name, path);
        }

        public static void LoadParaPath()
        {
            string filename = SystemConfig.GlobalLoad("parapath");
            if (filename != "")
            {
                ParaPath parapath;
                parapath = (ParaPath)SystemConfig.ReadBase64Data(filename, "parapath");

                sessionListPath = parapath.sessionListPath;
                productPath = parapath.productPath;
                probePath = parapath.probePath;
                wedgePath = parapath.wedgePath;
                detectionModePath = parapath.detectionModePath;
            }
        }

	}

    [Serializable]
    public class Gate
    {
        public int gateNum;
        public int tofModeNum;
        public int gateLogicNum;
        public int gateLogicOff;
        public double gateDelay;
        public double gateWidth;
        public double gateThreshold;
        public bool suppressionOn;
        public uint suppressionCount;
        public bool IfOnOff;

        public Gate()
        {
            gateNum = 0;
            tofModeNum = 0;
            gateLogicNum = 0;
            gateLogicOff = 0;
            gateDelay = 0.00;
            gateWidth = 0.00;
            gateThreshold = 0.00;
            suppressionOn = false;
            suppressionCount = 0;
            IfOnOff = false;
        }
    }

    [Serializable]
    public class MDIChildPara
    {
        //public int magifyIndex;
        public double gainNum;
        public uint speedNum;
        public int receiverNum;
        public int tranmissionNum;
        public int envelopNum;

        public int trigModeNum;
        public uint prfNum;

        public int recNum;
        public int AHPFNum;
        public int ALPFNum;
        public int DHPFNum;
        public int DLPFNum;
        public int recPathNum;
        public int matchOnOff;
        public uint matchNum;

        public int pulserEnableNum;
        public double pulserDelay;
        public double pulserWidth;
        public double pulserVoltage;
        public int pulserMatch;
        public uint pulserMatchValue;

        public double materialVelocity;

        public int[] toleranceActiveMode;
        public double[] toleranceMax;
        public double[] toleranceMin;
        public uint[] toleranceSuppressCnt;


        public MDIChildPara()
        {
            //magifyIndex = 0;
            gainNum = 0.00;
            speedNum = 0;
            receiverNum = 0;
            tranmissionNum = 0;
            envelopNum = 0;

            trigModeNum = 0;
            prfNum = 0;

            recNum = 0;
            AHPFNum = 0;
            ALPFNum = 0;
            DHPFNum = 0;
            DLPFNum = 0;
            recPathNum = 0;
            matchOnOff = 0;
            matchNum = 0;

            pulserEnableNum = 0;
            pulserDelay = 0.00;
            pulserWidth = 0.00;
            pulserVoltage = 0.00;
            pulserMatch = 0;
            pulserMatchValue = 0;

            materialVelocity = 0.00;

            toleranceActiveMode = new int[4] { 2, 2, 2, 2 };
            toleranceMax = new double[4] { 0.00, 0.00, 0.00, 0.00 };
            toleranceMin = new double[4] { 0.00, 0.00, 0.00, 0.00 };
            toleranceSuppressCnt = new uint[4] { 0, 0, 0, 0 };

        }
    }

    [Serializable]
    public class ParaPath
    {
        public string sessionListPath;
        public string productPath;
        public string probePath;
        public string wedgePath;
        public string detectionModePath;

        public ParaPath()
        {
            sessionListPath = "";
            productPath = "";
            probePath = "";
            wedgePath = "";
            detectionModePath = "";
        }
    }


    interface LoadandSave
    {
        void FormLoad();
        void FormSave();
    }
}
