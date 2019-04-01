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
    public partial class FormTriggerMode : Form
    {
        public FormTriggerMode()
        {
            InitializeComponent();
        }

        private void FormTriggerMode_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            init();
        }

        public void init()
        {
            initTriggerMode();
            initPRF();
        }

        private void initTriggerMode()
        {
            int error_code;
            TrigMode trigMode = TrigMode.TrigSoft;
            error_code = GetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, ref trigMode);
            if (error_code != 0)
                return;

            switch (trigMode)
            {
                case TrigMode.TrigSoft:
                    rdoSoftwareTrigger.Checked = true;
                    break;

                case TrigMode.TrigEncoder:
                    rdoEncoderTrigger.Checked = true;
                    break;

                case TrigMode.TrigExternal:
                    rdoOutsideTrigger.Checked = true;
                    break;

                case TrigMode.TrigPxiStar:
                    rdoStarSlotTrigger.Checked = true;
                    break;

                case TrigMode.TrigPos:
                    rdoPositionTrigger.Checked = true;
                    break;
                
                default:
                    MessageShow.show("Error:Initial the radioButton of trigger mode failed!",
                        "错误：初始化触发模式按钮失败!");
                    break;
            }
        }

        private void initPRF()
        {
            int error_code;
            uint prf = 0;
            error_code = GetPulserTransmitDAQ.Prf(SelectAscan.sessionIndex, SelectAscan.port, ref prf);
            if (error_code != 0)
                return;

            textBoxPrf.Text = prf.ToString();
        }

        private void rdoStarSlotTrigger_Click(object sender, EventArgs e)
        {
            SetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, TrigMode.TrigPxiStar);
        }

        private void rdommTrigger_Click(object sender, EventArgs e)
        {
            SetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, TrigMode.TrigPos);
        }

        private void rdoEncoderTrigger_Click(object sender, EventArgs e)
        {
            SetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, TrigMode.TrigEncoder);
        }

        private void rdoSoftwareTrigger_Click(object sender, EventArgs e)
        {
            SetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, TrigMode.TrigSoft);
        }

        private void rdoOutsideTrigger_Click(object sender, EventArgs e)
        {
            SetGlobalControlDAQ.TrigMode(SelectAscan.sessionIndex, SelectAscan.port, TrigMode.TrigExternal);
        }

        private void textBoxPrf_KeyPress(object sender, KeyPressEventArgs e)
        {
            uint prf;
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

           if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBoxPrf.Text == "")
                {
                    MessageShow.show("Warn:Please input data!",
                        "警告：请输入数字!");
                    return;
                }

                prf = Convert.ToUInt32(textBoxPrf.Text);
                SetPulserTransmitDAQ.Prf(SelectAscan.sessionIndex, SelectAscan.port, prf);
            }
        }

        private void textBoxPrf_Leave(object sender, EventArgs e)
        {
            uint prf = Convert.ToUInt32(textBoxPrf.Text);
            SetPulserTransmitDAQ.Prf(SelectAscan.sessionIndex, SelectAscan.port, prf);
        }
    }
}
