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
    public partial class FormSelecting : Form
    {
        public FormSelecting(string str)
        {
            InitializeComponent();
            label1.Text = str;
        }

        private void FormSelecting_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public partial class MessageShow
    {
        public static DialogResult showSelecting(string strEN, string strZH)
        {
            FormSelecting warning;
            if (MultiLanguage.lang == "EN")
                warning = new FormSelecting("    " + strEN);
            else
                warning = new FormSelecting("       " + strZH);

            return warning.ShowDialog();
        }
    }
}
