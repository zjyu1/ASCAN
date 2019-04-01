using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ascan;

namespace NIMotion
{
    public partial class CscanMotion : Form
    {
        public CscanMotion()
        {
            InitializeComponent();
        }

        private void CscanMotion_Load(object sender, EventArgs e)
        {  
            cmbScanAxis.SelectedIndex = 0;
            NMC.HardwareOpen();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int axis1;
            double range1;
            int axis2;
            double range2;

            bool flag = false;
            if (nudXRange.Text == "" || nudYRange.Text == "" ||
                nudSpeed.Text == "" || nudStep.Text == "")
            {
                MessageShow.show("Warning:Inputting is null, please input!",
                   "警告：输入为空，请重新输入!");
                return;
            }

            double xRange = Convert.ToDouble(nudXRange.Value);
            double yRange = Convert.ToDouble(nudYRange.Value);
            double speed = Convert.ToDouble(nudSpeed.Value);
            double step = Convert.ToDouble(nudStep.Value);

            if (cmbScanAxis.SelectedIndex == 0) //X轴为扫描轴
            {
                axis1 = 1;
                range1 = xRange;
                axis2 = 2;
                range2 = yRange;
            }
            else//y轴为扫描轴
            {
                axis1 = 2;
                range1 = yRange;
                axis2 = 1;
                range2 = xRange;
            }

            NMC.HardwareSigStart2Hardware();
            flag = NMC.HardwareGoPlanar(axis1, range1, axis2, range2, speed, step);
            if (!flag)
            {
                MessageShow.show("Bscan move failed, pls check!", "B扫运动失败，请检查!");
                return;
            }
            NMC.HardwareSigStop2Hardware();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            NMC.HardwareEHalt();
        }


    }
}
