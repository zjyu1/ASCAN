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
    public partial class UnionMove : Form
    {
        public UnionMove()
        {
            InitializeComponent();
        }

        private void UnionMove_Load(object sender, EventArgs e)
        {
            NMC.HardwareOpen();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            bool flag = false;
            flag = NMC.HardwareGoZero();
            if(!flag)
                MessageShow.show("Go zero failed, pls check!", "回零失败，请检查!");
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (nudXv.Text == "" || nudXd.Text == "" || nudYv.Text == "" || nudYd.Text == ""
                || nudZv.Text == "" || nudZd.Text == "")
            {
                MessageShow.show("Warning:Inputting is null, please input!",
                    "警告：输入为空，请重新输入!");
                return;
            }

            int axis1 = 1;
            double speed1 = Convert.ToDouble(nudXv.Value);
            double range1 = Convert.ToDouble(nudXd.Value);

            int axis2 = 2;
            double speed2 = Convert.ToDouble(nudYv.Value);
            double range2 = Convert.ToDouble(nudYd.Value);

            int axis3 = 3;
            double speed3 = Convert.ToDouble(nudZv.Value);
            double range3 = Convert.ToDouble(nudZd.Value);

            flag = NMC.HardwareDGo(axis1, range1, speed1);

            flag |= NMC.HardwareDGo(axis2, range2, speed2);

            flag |= NMC.HardwareDGo(axis3, range3, speed3);

            if(!flag)
                MessageShow.show("Move failed, pls check!", "运动失败，请检查!");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            NMC.HardwareEHalt();
        }

        private void btnBscan_Click(object sender, EventArgs e)
        {
            BscanMotion bscan = new BscanMotion();
            bscan.Show();
        }

        private void btnCscan_Click(object sender, EventArgs e)
        {
            CscanMotion cscan = new CscanMotion();
            cscan.Show();
        }

        private void btnCTest_Click(object sender, EventArgs e)
        {
            NMC.HardwareSigStart2Hardware();
            bool flag = NMC.HardwareGo(1, 100, 10);
            if (!flag)
            {
                MessageShow.show("Bscan move failed, pls check!", "B扫运动失败，请检查!");
                return;
            }
            NMC.HardwareSigStop2Hardware();
        }

    }
}
