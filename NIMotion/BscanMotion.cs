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
    public partial class BscanMotion : Form
    {
        private int axisIndex;

        public BscanMotion()
        {
            InitializeComponent();
        }

        private void BscanMotion_Load(object sender, EventArgs e)
        {
            cmbAxis.SelectedIndex = 0;
            axisIndex = cmbAxis.SelectedIndex + 1;

            NMC.HardwareOpen();
        }

        private void cmbAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            axisIndex = cmbAxis.SelectedIndex + 1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (nudVelocity.Text == "" || nudRange.Text == "")
            {
                MessageShow.show("Warning:Inputting is null, please input!",
                   "警告：输入为空，请重新输入!");
                return;
            }

            double speed = Convert.ToDouble(nudVelocity.Value);
            double range = Convert.ToDouble(nudRange.Value);

            NMC.HardwareSigStart2Hardware();
            flag = NMC.HardwareGo(axisIndex, range, speed);
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
