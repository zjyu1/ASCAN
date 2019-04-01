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
    public partial class FormLaunchParameters : Form
    {
        public FormLaunchParameters()
        {
            InitializeComponent();
        }

        private void FormLaunchParameters_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            init();
        }

        public void init()
        {
            initLaunchEnable();
            initDelayTime();
            initTransmitVoltage();
            initImpedanceMatch();

            int error_code = initTrans();
            if (error_code != 0)
                return;
           
        }

        /** Initial transmission RadioButton*/
        private int initTrans()
        {
            int error_code;
            RecieverType type = RecieverType.Pe;
            error_code = GetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, ref type);
            if (error_code != 0)
                return error_code;

            switch (type)
            {
                case RecieverType.Pc:
                    RadioButtonThrough.Checked = true;
                    break;
                case RecieverType.Pe:
                    RadioButtonReflection.Checked = true;
                    break;
                default:
                    error_code = -1;
                    MessageShow.show("Warn:Initial RadioButton of Transmission failed!",
                        "警告:初始化探头收发模式的控件失败!");
                    break;
            }
            return error_code;
        }

        private void RadioButtonThrough_Click(object sender, EventArgs e)
        {
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.RecieverMode(SelectAscan.sessionIndex, RecieverType.Pc);
            else
                SetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, RecieverType.Pc);
        }

        private void RadioButtonReflection_Click(object sender, EventArgs e)
        {
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.RecieverMode(SelectAscan.sessionIndex, RecieverType.Pe);
            else
                SetPulserTransmitDAQ.RecieverMode(SelectAscan.sessionIndex, SelectAscan.port, RecieverType.Pe);
        }


        private void initLaunchEnable()
        {
            int error_code;
            PluserActive active = PluserActive.OFF;
            error_code = GetPulserTransmitDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, ref active);
            if (error_code != 0)
                return;

            switch (active)
            {
                case PluserActive.OFF:
                    rdoOFF.Checked = true;
                    break;

                case PluserActive.ON:
                    rdoON.Checked = true;
                    break;

                default:
                    MessageShow.show("Error:Initial launch enable failed", 
                        "错误：初始化发射使能失败!");
                    break;
            }
        }

        private void initDelayTime()
        {
            int error_code;
            double timeDelay = 0;
            double pulseWidth = 0;
            error_code = GetPulserTransmitDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, ref timeDelay);
            if (error_code != 0)
                return;

            error_code = GetPulserTransmitDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, ref pulseWidth);
            if (error_code != 0)
                return;

            textBoxTimeDelay.Text = timeDelay.ToString();
            textBoxPulseWidth.Text = pulseWidth.ToString();
        }

        private void initTransmitVoltage()
        {
            int error_code;
            double intensity = 0;
            error_code = GetPulserTransmitDAQ.Intensity(SelectAscan.sessionIndex, SelectAscan.port, ref intensity);
            if (error_code != 0)
                return;

            if (intensity == 100)
            {
                rdo100.Checked = true;
            }
            else if (intensity == 400)
            {
                rdo400.Checked = true;
            }
            else
            {
                //MessageShow.show("Error:Initial transmit voltage failed!",
                        //"错误:初始化发射电压失败!");
            }
        }

        private void initImpedanceMatch()
        {
            int error_code;
            PulserDampingActive active = PulserDampingActive.OFF;
            uint dampingValue=0;
            error_code = GetPulserTransmitDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, ref active);
            if (error_code != 0)
                return;

            error_code = GetPulserTransmitDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, ref dampingValue);
            if (error_code != 0)
                return;

            switch (active)
            {
                case PulserDampingActive.OFF:
                    chkImpedanceMatch.Checked = false;
                    textBoxImpedance.Enabled = false;
                    break;

                case PulserDampingActive.ON:
                    chkImpedanceMatch.Checked = true;
                    textBoxImpedance.Enabled = true;
                    break;

                default:
                    MessageShow.show("Error:Initial impedance match failed!", 
                        "错误：初始化阻抗匹配失败!");
                    break;
            }

            textBoxImpedance.Text = dampingValue.ToString();
        }

        private void rdoON_Click(object sender, EventArgs e)
        {
            SetPulserTransmitDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, PluserActive.ON);
        }

        private void rdoOFF_Click(object sender, EventArgs e)
        {
            SetPulserTransmitDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, PluserActive.OFF);
        }

        private void textBoxTimeDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBoxTimeDelay.Text == "")
                {
                    MessageShow.show("Warn:Please input data!",
                        "警告：请输入数字!");
                    return;
                }

                double timeDelay = Convert.ToDouble(textBoxTimeDelay.Text);
                SetPulserTransmitDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, timeDelay);
            }
        }

        private void textBoxTimeDelay_Leave(object sender, EventArgs e)
        {
            uint timeDelay = Convert.ToUInt32(textBoxTimeDelay.Text);
            SetPulserTransmitDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, timeDelay);
        }

        private void textBoxPulseWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBoxPulseWidth.Text == "")
                {
                    MessageShow.show("Warn:Please input data!",
                        "警告：请输入数字!");
                    return;
                }

                double pulseWidth = Convert.ToDouble(textBoxPulseWidth.Text);
                SetPulserTransmitDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, pulseWidth);
            }
        }

        private void textBoxPulseWidth_Leave(object sender, EventArgs e)
        {
            uint pulseWidth = Convert.ToUInt32(textBoxPulseWidth.Text);
            SetPulserTransmitDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, pulseWidth);
        }

        private void chkImpedanceMatch_Click(object sender, EventArgs e)
        {
            if (chkImpedanceMatch.Checked == true)
            {
                textBoxImpedance.Enabled = true;
                SetPulserTransmitDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, PulserDampingActive.ON);
            }
            else
            {
                textBoxImpedance.Enabled = false;
                SetPulserTransmitDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, PulserDampingActive.OFF);
            }
        }

        private void textBoxImpedance_Leave(object sender, EventArgs e)
        {
            uint impedance = Convert.ToUInt32(textBoxImpedance.Text);
            SetPulserTransmitDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, impedance);
        }

        private void textBoxImpedance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBoxImpedance.Text == "")
                {
                    MessageShow.show("Warn:Please input data!",
                        "警告：请输入数字!");
                    return;
                }
                uint impedance = Convert.ToUInt32(textBoxImpedance.Text);
                SetPulserTransmitDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, impedance);
            }
        }

        private void rdo100_Click(object sender, EventArgs e)
        {
            SetPulserTransmitDAQ.Intensity(SelectAscan.sessionIndex, SelectAscan.port, 100);//100V
        }

        private void rdo400_Click(object sender, EventArgs e)
        {
            SetPulserTransmitDAQ.Intensity(SelectAscan.sessionIndex, SelectAscan.port, 400);//400V
        }

    }
}
