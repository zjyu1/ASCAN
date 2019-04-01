using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Ascan;

namespace ScanImage
{

    public class BinarySerialize<T>
    {
        private BinaryFormatter formatter = new BinaryFormatter();
        private FileStream saveFile;
        private FileStream loadFile;

        public void  SerializeOpen(string strFilePath)
        {
            try
            {
                FileInfo fi = new FileInfo(strFilePath);
                if (fi.Length>0)
                    fi.Create();

                saveFile = new FileStream(strFilePath, FileMode.Append, FileAccess.Write);
                
            }
            catch
            {
                MessageShow.show("Serialize Open failed!", "序列化打开失败!");
            }
        }

        public void SerializeWrite(T obj)
        {
            try
            {
                formatter.Serialize(saveFile, obj);
            }
            catch
            {
                MessageShow.show("Serialize Write failed!", "序列化写入失败!");
            }
        }

        public void SetializeClose()
        {
            try
            {
                saveFile.Close();
            }
            catch
            {
                MessageShow.show("Serialize Close failed!", "序列化关闭失败!");
            }
        }

        public void DeSerializeOpen(string strFilePath)
        {
            try
            {
                FileInfo fi = new FileInfo(strFilePath);
                if (!fi.Exists)
                {
                    MessageShow.show("File is not exist!", "文件不存在!");
                    return;
                }

                loadFile = new FileStream(strFilePath, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                MessageShow.show("DeSerialize Open failed!", "反序列化打开失败!");
            }
        }

        public void DeSerializeRead(ref T obj)
        {
            try
            {
                while (loadFile.Position !=loadFile.Length)
                {
                    obj = (T)formatter.Deserialize(loadFile);
                }
            }
            catch
            {

            }
        }

        public void DeSetializeClose()
        {
            try
            {
                loadFile.Close();
            }
            catch
            {
                MessageShow.show("Serialize Close failed!", "序列化关闭失败!");
            }
        }
        
    }
}
