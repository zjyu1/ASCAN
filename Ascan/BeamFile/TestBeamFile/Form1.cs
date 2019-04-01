using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ascan
{
    public partial class FormTest : Form
    {
        private String lastFileName;
        public FormTest()
        {
            InitializeComponent();

            lastFileName = null;
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBox1.Text);
            if (num <= 0)
                return;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string filePath = Application.StartupPath + @"\BeamFile";
            openFileDialog1.Filter = "txt文件(*.txt)|*.txt|所有文件(*.*)|*.*";

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
            openFileDialog1.InitialDirectory = filePath;
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                readFromTXT(fileName);
            }
        }

        private void readFromTXT(string file)
        {
            int num = Convert.ToInt32(textBox1.Text);
            if (num <= 0)
                return;

            StreamReader sr = new StreamReader(file, Encoding.Default);
            String line;
            for (int i = 0; i < num; i++)
            {
                if ((line = sr.ReadLine()) != null)
                {
                    ClassBeamFile beamFile = new ClassBeamFile();
                    beamFile.rxSize = 32;
                    beamFile.txSize = 32;
                    String[] arrays = line.Split('\t');
                    for (int j = 0; j < 32; j++)
                    {
                        beamFile.txDelay[j] = (float)((double)Convert.ToInt32(arrays[j]) / 1000 * 0.78);
                        beamFile.rxDelay[j] = beamFile.txDelay[j];
                        
                    }
                    BinForm binForm = new BinForm(beamFile);
                    binForm.ShowDialog();
                    saveToXML(beamFile);
                }
                else
                    break;
            }

            sr.Close();
        }

        private void saveToXML(ClassBeamFile beamFile)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filePath;

            if (lastFileName == null)
                filePath = Application.StartupPath + @"\BeamFile";
            else
                filePath = lastFileName;

            if (filePath.IndexOf('\\') < 0 && filePath.IndexOf('/') < 0 || filePath.StartsWith(":"))
            {
                MessageBox.Show("路径格式错误！");
                return;
            }
            string str = Directory.GetDirectoryRoot(filePath);
            //str = System.IO.Path.GetPathRoot(Path.GetFullPath( filePath));
            if (!Directory.Exists(str))
            {
                MessageBox.Show("该盘符不存在，请选择其他保存路径！");
                return;
            }

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            saveFileDialog1.InitialDirectory = filePath;
            saveFileDialog1.Filter = "bm文件(*.bm)|*.bm|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
                date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
                SystemConfig.WriteConfigData(saveFileDialog1.FileName, "date", date);
                SystemConfig.WriteBase64Data(saveFileDialog1.FileName, "beamFile", beamFile);
                lastFileName = Path.GetDirectoryName(saveFileDialog1.FileName);
            }
        }
    }
}
