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
    public partial class FormDelays : Form
    {
        private ClassBeamFile beamFile;
        public FormDelays(ClassBeamFile beamFile)
        {
            InitializeComponent();
            this.beamFile = beamFile;

            init();
        }

        private void init()
        {
            //返回两个数较大的一个
            //使用的datagridview控件，可以自动的一行行显示
            int n = (int)Math.Max(beamFile.txSize, beamFile.rxSize);

            for (int i = 0; i < n; i++)
            {
                delayView.RowCount++;
                delayView.Rows[i].Cells["index"].Value = i;
                delayView.Rows[i].Cells["txDelay"].Value = beamFile.txDelay[i];
                delayView.Rows[i].Cells["rxDelay"].Value = beamFile.rxDelay[i];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = delayView.RowCount;

            for (int i = 0; i < n; i++)
            {
                beamFile.txDelay[i] = (float)Convert.ToDouble(delayView.Rows[i].Cells["txDelay"].Value);
                beamFile.rxDelay[i] = (float)Convert.ToDouble(delayView.Rows[i].Cells["rxDelay"].Value);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //程序启动路径+文件名
            string filePath = Application.StartupPath + @"\BeamFile";
            if (filePath.IndexOf('\\') < 0 && filePath.IndexOf('/') < 0 || filePath.StartsWith(":"))
            {
                MessageShow.show("Wrong format of path!", "路径格式错误！");
                return;
            }
            string str = Directory.GetDirectoryRoot(filePath);
            //str = System.IO.Path.GetPathRoot(Path.GetFullPath( filePath));
            if (!Directory.Exists(str))
            {
                MessageShow.show(str + "the director root doesn't exist, please change the path!",
                    str + "该盘符不存在，请选择其他保存路径！");
                return;
            }

            //如果盘符存在，但是文件不存在，那么创建该文件
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            saveFileDialog1.InitialDirectory = filePath;
            saveFileDialog1.Filter = "bm文件(*.bm)|*.bm|所有文件(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                writeToXML(saveFileDialog1.FileName);
            }
        }

        private void writeToXML(string file)
        {
            string date = string.Format("{0:yyyy-MM-dd HH_mm_ss}", DateTime.Now);
            date = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");//"G"
            SystemConfig.WriteConfigData(file, "date", date);
            SystemConfig.WriteBase64Data(file, "beamFile", beamFile);
        }
    }
}
