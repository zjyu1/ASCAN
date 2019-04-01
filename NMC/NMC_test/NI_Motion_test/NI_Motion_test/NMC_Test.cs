using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NIMotion;
using Ascan;

namespace NI_Motion_test
{
    public partial class NMC_Test : Form
    {
        System.Timers.Timer PosTimer = new System.Timers.Timer();

        public NMC_Test()
        {
            InitializeComponent();
            PosTimer.Enabled = true;                                //初始化读取实时速度和位置的计时器，每5ms发送一次读取指令,读取速度和位置信息   
            PosTimer.AutoReset = true;
            PosTimer.Interval = 20;
            PosTimer.Elapsed += new System.Timers.ElapsedEventHandler(ReadPos_tick);
        }

        delegate void SetTextCallback(string text);

        private void SetXposText(string text)
        {
            xPos.Text = text;
        }

        private void SetYposText(string text)
        {
            yPos.Text = text;
        }

        private void SetZposText(string text)
        {
            zPos.Text = text;
        }
        
        private void ReadPos_tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            double xPos = 0;
            double yPos = 0;
            double zPos = 0;
            NMC.HardwareGetCurPos((int)Axis.X,ref xPos);
            NMC.HardwareGetCurPos((int)Axis.Y, ref yPos);
            NMC.HardwareGetCurPos((int)Axis.Z, ref zPos);
            //xPos=Math.Round(xPos, 2);
           // yPos=Math.Round(yPos, 2);
           // zPos=Math.Round(zPos, 2);
            SetTextCallback xPosition = new SetTextCallback(SetXposText);
            try
            { 
                this.Invoke(xPosition, new object[] { Convert.ToString(xPos) });
            }
            catch { }
            
            SetTextCallback yPosition = new SetTextCallback(SetYposText);
            try
            {
                this.Invoke(yPosition, new object[] { Convert.ToString(yPos) });
            }
            catch { }

            SetTextCallback zPosition = new SetTextCallback(SetZposText);
            try
            {
                this.Invoke(zPosition, new object[] { Convert.ToString(zPos) });
            }
            catch { }
            
        }

        private void NMC_Test_Load(object sender, EventArgs e)
        {
            NMC.HardwareOpen();
        }

        private void btn_zero_Click(object sender, EventArgs e)
        {
            bool flag = false;
            flag = NMC.HardwareGoZero();
            if (!flag)
                MessageShow.show("Go zero failed, pls check!", "回零失败，请检查!");
        }

        private void btn_move_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (xSpeed.Text == "" || xDistance.Text == "" || ySpeed.Text == "" || yDistance.Text == ""
                || zSpeed.Text == "" || zDistance.Text == "")
            {
                MessageShow.show("Warning:Inputting is null, please input!",
                    "警告：输入为空，请重新输入!");
                return;
            }

            int axis1 = 1;
            double speed1 = Convert.ToDouble(xSpeed.Value);
            double range1 = Convert.ToDouble(xDistance.Value);

            int axis2 = 2;
            double speed2 = Convert.ToDouble(ySpeed.Value);
            double range2 = Convert.ToDouble(yDistance.Value);

            int axis3 = 3;
            double speed3 = Convert.ToDouble(zSpeed.Value);
            double range3 = Convert.ToDouble(zDistance.Value);

            flag = NMC.HardwareBGo(axis1, range1, speed1);

            flag |= NMC.HardwareBGo(axis2, range2, speed2);

            flag |= NMC.HardwareBGo(axis3, range3, speed3);

            if (!flag)
                MessageShow.show("Move failed, pls check!", "运动失败，请检查!");
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            NMC.HardwareEHalt();
        }

        private void Cscan_btn_Click(object sender, EventArgs e)
        {
            int axis1;
            double range1;
            int axis2;
            double range2;
            //NMC.HardwareSigStop2Hardware();
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
            flag = NMC.HardwareBGoPlanar(axis1, range1, axis2, range2, speed, step);
            if (!flag)
            {
                MessageShow.show("Bscan move failed, pls check!", "B扫运动失败，请检查!");
                return;
            }
            //
        }

        public enum Axis
        { 
            X=1,
            Y=2,
            Z=3
        }

        private void btn_sigstop_Click(object sender, EventArgs e)
        {
            NMC.HardwareSigStop2Hardware();
        }
    }
}
