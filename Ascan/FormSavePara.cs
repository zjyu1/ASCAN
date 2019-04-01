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
    public partial class FormSavePara : Form
    {
        public FormSavePara()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SystemConfig.fname == null)
            {
                MessageShow.show("No Previous File,Please Save As", "无原文件，请选择另存为");
                return;
            }
            SystemConfig.saveFlag = true;
            FormList.mySessionsListForm.FormSave();
            FormList.FormProduct.FormSave();
            FormList.FormProbe.FormSave();
            FormList.FormWedge.FormSave();
            SystemConfig.SavePara();
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!= null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "LoadData\\" + textBox1.Text;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                SystemConfig.saveFlag = true;
                SystemConfig.fname = textBox1.Text;
                FormList.mySessionsListForm.FormSave();
                FormList.FormProduct.FormSave();
                FormList.FormProbe.FormSave();
                FormList.FormWedge.FormSave();
                FormList.FormDetectionMode.FormSave();
                SystemConfig.SavePara();
                this.Close();
            }
            else
            {
                MessageShow.show("Please Input", "请输入产品名称！");
                return;
            }
            
        }
    }
}
