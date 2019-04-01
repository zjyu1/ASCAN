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
    public partial class FormConditioningParameters : Form
    {
        public FormConditioningParameters()
        {
            InitializeComponent();
        }

        private void FormConditioningParameters_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            init();
        }

        public void init()
        {
            removeAllEvent();
            initReceiveEnable();
            initAnologFilter();
            initDigitalFilter();
            initReceiverPath();
            initImpedanceMatch();
            bindAllEvent();
        }

        private void initReceiveEnable()
        {
            int error_code;
            ReceiverActive active = ReceiverActive.OFF;
            error_code = GetRecieverDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, ref active);
            if (error_code != 0)
                return;

            switch (active)
            {
                case ReceiverActive.OFF:
                    rdoOFF.Checked = true;
                    break;

                case ReceiverActive.ON:
                    rdoON.Checked = true;
                    break;

                default:
                    MessageShow.show("Error:Initial receive anable failed!",
                        "错误：初始化接收使能失败!");
                    break;
            }
        }

        private void initAnologFilter()
        {
            int error_code;
            FilterCutoffFreq analogHPF = FilterCutoffFreq.FilterPassAway;
            FilterCutoffFreq analogLPF = FilterCutoffFreq.FilterPassAway;
            error_code = GetRecieverDAQ.AnalogHPF(SelectAscan.sessionIndex, SelectAscan.port, ref analogHPF);
            if (error_code != 0)
                return;

            error_code = GetRecieverDAQ.AnalogLPF(SelectAscan.sessionIndex, SelectAscan.port, ref analogLPF);
            if (error_code != 0)
                return;

            cboAHPF.SelectedIndex = (int)analogHPF;
            cboALPF.SelectedIndex = (int)analogLPF;
        }

        private void initDigitalFilter()
        {
            int error_code;
            FilterCutoffFreq digitalHPF = FilterCutoffFreq.FilterPassAway;
            FilterCutoffFreq digitalLPF = FilterCutoffFreq.FilterPassAway;
            error_code = GetRecieverDAQ.DigitalHPF(SelectAscan.sessionIndex, SelectAscan.port, ref digitalHPF);
            if (error_code != 0)
                return;

            error_code = GetRecieverDAQ.DigitalLPF(SelectAscan.sessionIndex, SelectAscan.port, ref digitalLPF);
            if (error_code != 0)
                return;

            cboDHPF.SelectedIndex = (int)digitalHPF;
            cboDLPF.SelectedIndex = (int)digitalLPF;          
        }

        private void initReceiverPath()
        {
            int error_code;
            ReceiverPATH receiverPATH = ReceiverPATH.Normal;
            error_code = GetRecieverDAQ.ReceiverPATH(SelectAscan.sessionIndex, SelectAscan.port, ref receiverPATH);
            if (error_code != 0)
                return;

            switch (receiverPATH)
            {
                case ReceiverPATH.Normal:
                    rdoNormal.Checked = true;
                    break;

                case ReceiverPATH.Hvsense:
                    rdoTransmitVoltageAcquisition.Checked = true;
                    break;

                case ReceiverPATH.Testin:
                    rdoTestInput.Checked = true;
                    break;

                default:
                    MessageShow.show("Error:Initial receiver path failed!", 
                        "错误：初始化接收路径失败!");
                    break;
            }
        }

        private void initImpedanceMatch()
        {
            int error_code;
            uint dampingValue = 0;
            DampingActive dampingActive = DampingActive.OFF;
            error_code = GetRecieverDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, ref dampingActive);
            if (error_code != 0)
                return;

            error_code = GetRecieverDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, ref dampingValue); 
            if(error_code!=0)
                return;

            switch (dampingActive)
            {
                case DampingActive.OFF:
                    textBoxImpedance.Enabled = false;
                    chkImpedanceMatch.Checked = false;
                    break;

                case DampingActive.ON:
                    textBoxImpedance.Enabled = true;
                    chkImpedanceMatch.Checked = true;
                    break;
                
                default:
                    MessageShow.show("Error:Initial impedance match failed!",
                        "错误：初始化匹配阻抗失败!");
                    break;
            }

            textBoxImpedance.Text = dampingValue.ToString();
        }

        private void rdoON_Click(object sender, EventArgs e)
        {
            SetReceiverDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, ReceiverActive.ON);
        }

        private void rdoOFF_Click(object sender, EventArgs e)
        {
            SetReceiverDAQ.Active(SelectAscan.sessionIndex, SelectAscan.port, ReceiverActive.OFF);
        }

        private void cboAHPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCutoffFreq freq = (FilterCutoffFreq)cboAHPF.SelectedIndex;
            SetReceiverDAQ.AnalogHPF(SelectAscan.sessionIndex, SelectAscan.port, freq);
        }

        private void cboALPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCutoffFreq freq = (FilterCutoffFreq)cboALPF.SelectedIndex;
            SetReceiverDAQ.AnalogLPF(SelectAscan.sessionIndex, SelectAscan.port, freq);
        }

        private void cboDHPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCutoffFreq freq = (FilterCutoffFreq)cboDHPF.SelectedIndex;
            SetReceiverDAQ.DigitalHPF(SelectAscan.sessionIndex, SelectAscan.port, freq);
        }

        private void cboDLPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCutoffFreq freq = (FilterCutoffFreq)cboDLPF.SelectedIndex;
            SetReceiverDAQ.DigitalLPF(SelectAscan.sessionIndex, SelectAscan.port, freq);
        }

        private void rdoNormal_Click(object sender, EventArgs e)
        {
            SetReceiverDAQ.RecieverPATH(SelectAscan.sessionIndex, SelectAscan.port, ReceiverPATH.Normal);
        }

        private void rdoTestInput_Click(object sender, EventArgs e)
        {
            SetReceiverDAQ.RecieverPATH(SelectAscan.sessionIndex, SelectAscan.port, ReceiverPATH.Testin);
        }

        private void rdoTransmitVoltageAcquisition_Click(object sender, EventArgs e)
        {
            SetReceiverDAQ.RecieverPATH(SelectAscan.sessionIndex, SelectAscan.port, ReceiverPATH.Hvsense);
        }

        private void chkImpedanceMatch_Click(object sender, EventArgs e)
        {
            if (chkImpedanceMatch.Checked == true)
            {
                textBoxImpedance.Enabled = true;
                SetReceiverDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, DampingActive.ON);
            }
            else
            {
                textBoxImpedance.Enabled = false;
                SetReceiverDAQ.DampingActive(SelectAscan.sessionIndex, SelectAscan.port, DampingActive.OFF);
            }
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
                uint  dampingValue = Convert.ToUInt32(textBoxImpedance.Text);
                SetReceiverDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, dampingValue);
            }
        }

        private void textBoxImpedance_Leave(object sender, EventArgs e)
        {
            uint dampingValue = Convert.ToUInt32(textBoxImpedance.Text);
            SetReceiverDAQ.DampingValue(SelectAscan.sessionIndex, SelectAscan.port, dampingValue);
        }

        private void removeAllEvent()
        {
            cboAHPF.SelectedIndexChanged -= cboAHPF_SelectedIndexChanged;
            cboALPF.SelectedIndexChanged -= cboALPF_SelectedIndexChanged;
            cboDHPF.SelectedIndexChanged -= cboDHPF_SelectedIndexChanged;
            cboDLPF.SelectedIndexChanged -= cboDLPF_SelectedIndexChanged;
        }

        private void bindAllEvent()
        {
            cboAHPF.SelectedIndexChanged += cboAHPF_SelectedIndexChanged;
            cboALPF.SelectedIndexChanged += cboALPF_SelectedIndexChanged;
            cboDHPF.SelectedIndexChanged += cboDHPF_SelectedIndexChanged;
            cboDLPF.SelectedIndexChanged += cboDLPF_SelectedIndexChanged;
        }

    }
}
