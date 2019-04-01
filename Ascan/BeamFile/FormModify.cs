using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.IO;

namespace Ascan
{
    public partial class FormModify : Form
    {
        private FormFocus formFocus;
        public double xd = 0;
        public double angled = 0;
        private int cancelflag = 1;

        public FormModify(FormFocus fromFocus)
        {
            InitializeComponent();
            this.formFocus = fromFocus;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            try
            {
                xd = Convert.ToDouble(xtext.Text);
                angled = Convert.ToDouble(angletext.Text);
                cancelflag = 0;
            }
            catch
            {
                //MessageShow.show("input error","输入错误");
                return;
            }
        }

        private void FormModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            formFocus.Modifypara(this,cancelflag);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cancelflag = 1;
            this.Close();
            formFocus.Modifypara(this, cancelflag);
        }






    }
}
