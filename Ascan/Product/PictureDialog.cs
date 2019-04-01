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
    public partial class PictureDialog : Form
    {
        public PictureDialog(PictureBox pb)
        {
            InitializeComponent();
            this.pictureBox1.Image = pb.Image;
        }
    }
}
