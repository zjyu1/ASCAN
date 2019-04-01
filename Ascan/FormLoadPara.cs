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
    public partial class FormLoadPara : Form
    {
        public FormLoadPara()
        {
            InitializeComponent();
            string path1 = AppDomain.CurrentDomain.BaseDirectory + "LoadData\\";
            string[] filenames = Directory.GetDirectories(path1);
            //string[] filenames = new DirectoryInfo(path1).Name;
            foreach (string fname in filenames)
            {
                if (Directory.Exists(fname))
                {
                    string name = new DirectoryInfo(fname).Name;
                    comboLoadPara.Items.Add(name);
                }
            }
        }

        private void comboLoadPara_SelectedIndexChanged(object sender, EventArgs e)
        {
            SystemConfig.fname = comboLoadPara.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemConfig.LoadParaPath();
            FormList.mySessionsListForm.FormLoad();
            FormList.FormProduct.FormLoad();
            FormList.FormProbe.FormLoad();
            FormList.FormWedge.FormLoad();
            FormList.FormDetectionMode.FormLoad();
            FormList.mySessionsListForm.FormHide();
            SystemConfig.LoadPara();
            this.Close();
        }

    }
}
