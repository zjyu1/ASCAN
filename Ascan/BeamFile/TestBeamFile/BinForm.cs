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
    public partial class BinForm : Form
    {
        //classbeamfile在别的源文件定义，怎么引过来的？
        private ClassBeamFile beamFile;

        public BinForm(ClassBeamFile beamFile)
        {
            InitializeComponent();
            this.beamFile = beamFile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beamFile.txElementBin[0] = (uint)int.Parse(bin0.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[0] = beamFile.txElementBin[0];
            beamFile.txElementBin[1] = (uint)int.Parse(bin1.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[1] = beamFile.txElementBin[1];
            beamFile.txElementBin[2] = (uint)int.Parse(bin2.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[2] = beamFile.txElementBin[2];
            beamFile.txElementBin[3] = (uint)int.Parse(bin3.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[3] = beamFile.txElementBin[3];
            beamFile.txElementBin[4] = (uint)int.Parse(bin4.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[4] = beamFile.txElementBin[4];
            beamFile.txElementBin[5] = (uint)int.Parse(bin5.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[5] = beamFile.txElementBin[5];
            beamFile.txElementBin[6] = (uint)int.Parse(bin6.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[6] = beamFile.txElementBin[6];
            beamFile.txElementBin[7] = (uint)int.Parse(bin7.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
            beamFile.rxElementBin[7] = beamFile.txElementBin[7];
            this.Close();
        }
      
    }
}
