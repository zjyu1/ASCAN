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
    public partial class FormMotion : Form
    {
        private Motion motion;
        private int dir, range, speed;
        double realTimePos, realTimeSpeed;
        private System.Timers.Timer motiontimer = new System.Timers.Timer(100);
        private delegate void updateDelegate();
        private updateDelegate updateMotionCallBack;
        public FormMotion()
        {
            InitializeComponent();
            motion = MainForm.motion;
            motiontimer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateMotionState);
        }

        private void updateMotionState()
        {
            //realTimePos = motion.ReadPosition();
            //realTimeSpeed = motion.ReadSpeed();
            //tbRealPos.Text = Convert.ToString(realTimePos);
            //tbRealSpeed.Text = Convert.ToString(realTimeSpeed);
            //if (realTimeSpeed >= 0)
            //    tbRealDir.Text = "正";
            //else
            //    tbRealDir.Text = "反";
        }

        private void UpdateMotionState(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (updateMotionCallBack == null)
                updateMotionCallBack = new updateDelegate(updateMotionState);
            this.BeginInvoke(updateMotionCallBack);
        }

        private void judgeTextBoxInput(TextBox textbox, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                && e.KeyChar != '.')// '0 - 9', '.' and backspace , this three input is allowed 
            {
                e.Handled = true;   //ignore this input
            }

            if (e.KeyChar == '.' && textbox.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
        }

        private void tbTargetPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeTextBoxInput(tbTargetPos, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                range = (int)Convert.ToDouble(tbTargetPos.Text);
            }
        }

        private void tbTargetPos_Leave(object sender, EventArgs e)
        {
            if (tbTargetPos.Text == "")
            {
                tbTargetPos.Text = "0";
                range = 0;
            }
            range = (int)Convert.ToDouble(tbTargetPos.Text);
        }

        private void tbTargetSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeTextBoxInput(tbTargetSpeed, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                speed = (int)Convert.ToDouble(tbTargetSpeed.Text);
                if (speed > 15)
                {
                    speed = 15;
                    tbTargetSpeed.Text = "15.0";
                }
            }
        }

        private void tbTargetSpeed_Leave(object sender, EventArgs e)
        {
            if (tbTargetSpeed.Text == "")
            {
                tbTargetSpeed.Text = "0";
                speed = 0;
            }
            speed = (int)Convert.ToDouble(tbTargetSpeed.Text);
            if (speed > 15)
            {
                speed = 15;
                tbTargetSpeed.Text = "15.0";
            }
        }

        private void radioPosDir_CheckedChanged(object sender, EventArgs e)
        {
            dir = 0;
        }

        private void radioNegDir_CheckedChanged(object sender, EventArgs e)
        {
            dir = 1;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            motiontimer.Enabled = true;
            if (motion == null)
            {
                MessageBox.Show("运动控制初始化失败！");
                return;
            }
            motion.Go(dir, range, speed * 66);
        }

        private void buttonHold_Click(object sender, EventArgs e)
        {
            motiontimer.Enabled = false;
            motion.Stop();
            motion.SetStopIO();
        }
    }
}
