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
    public partial class FormMDAC : Form
    {
        public FormMDAC()
        {
            InitializeComponent();
        }

        private void FormMDAC_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }
    }
}
