using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ascan
{
    public partial class FormWarning : Form
    {
        public FormWarning(string str)
        {
            InitializeComponent();
            label1.Text = str;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWarning_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }
    }

    public partial class MessageShow
    {
        public static void show(string strEN, string strZH)
        {
            FormWarning warning;
            if (MultiLanguage.lang == "EN")
                warning = new FormWarning(strEN);
            else
                warning = new FormWarning(strZH);
            warning.ShowDialog();
        }
    }
}
