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
    public partial class FormGatePosition : Form
    {
        
        private GateType gateNum;
        public bool fileFlag = false;

        //current baked tof mode radioButton, if change tof mode not success, can use reback  
        private RadioButton preRdo;

        public FormGatePosition()
        {
            InitializeComponent();
        }

        public GateType GateNum
        {
            get { return gateNum; }
        }

        private void FormGatePosition_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            MultiLanguage.getNames(this);
            init();

        }

        public void init()
        {
            gateNum = GateType.I;
            radioButtonGateI.Checked = true;
            showGatePara();
            //gateI.gateNum = 0;
        }

        //public int InitPara()
        //{
        //    int error_code1;
        //    int error_code2;
        //    int error_code3;
        //    int error_code4;
        //    error_code1 = initRadioButttonOfTofMode();
        //    error_code2 = initRadioButttonOfGateLogic();
        //    error_code3 = initCheckBoxOfSuppressCount();
        //    error_code4 = initGatePositionPara();
        //    if (error_code1 != 0 && error_code2 != 0 && error_code3 != 0 && error_code4 != 0)
        //        return error_code1;
        //    else
        //        return 0;
        //}

        private void radioButtonGateI_Click(object sender, EventArgs e)
        {
            gateNum = GateType.I;
            showGatePara();
        }

        private void radioButtonGateA_Click(object sender, EventArgs e)
        {
            gateNum = GateType.A;
            showGatePara();
        }

        private void radioButtonGateB_Click(object sender, EventArgs e)
        {
            gateNum = GateType.B;
            showGatePara();
        }

        private void radioButtonGateC_Click(object sender, EventArgs e)
        {
            gateNum = GateType.C;
            showGatePara();
        }

        private void setTofMode(TofMode tofMode, RadioButton rad)
        {
            bool isSetPre = false;
            if (SetBatchDAQ.isOn)
                isSetPre = SetBatchDAQ.setTofMode(SelectAscan.sessionIndex, gateNum, tofMode);
            else
                isSetPre = SetGateDAQ.setTofMode(SelectAscan.sessionIndex, SelectAscan.port, gateNum, tofMode);

            if (isSetPre)
                preRdo.Checked = true;
            else
                preRdo = rad;
        }

        private void radioButtonFlank_Click(object sender, EventArgs e)
        {
            setTofMode(TofMode.Flank, radioButtonFlank);
            //gatePara.tofModeNum = (int)TofMode.Flank;

        }

        private void radioButtonZeroB_Click(object sender, EventArgs e)
        {
            setTofMode(TofMode.ZeroBefore, radioButtonZeroB);
            //gatePara.tofModeNum = (int)TofMode.ZeroBefore;

        }

        private void radioButtonPeak_Click(object sender, EventArgs e)
        {
            setTofMode(TofMode.Peak, radioButtonPeak);
            //gatePara.tofModeNum = (int)TofMode.Peak;
        }

        private void radioButtonZeroA_Click(object sender, EventArgs e)
        {
            setTofMode(TofMode.ZeroAfter, radioButtonZeroA);
            //gatePara.tofModeNum = (int)TofMode.ZeroAfter;
        }

        private void radioButtonPositive_Click(object sender, EventArgs e)
        {
            setGateLogic(GateAlarmLogic.Positive);
            //gatePara.gateLogicNum = (int)GateAlarmLogic.Positive;

        }

        private void radioButtonNegative_Click(object sender, EventArgs e)
        {
            setGateLogic(GateAlarmLogic.Negative);
            //gatePara.gateLogicNum = (int)GateAlarmLogic.Negative;

        }

        private void radioButtonOff_Click(object sender, EventArgs e)
        {
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.AlarmActive(SelectAscan.sessionIndex, gateNum, GateAlarmActive.OFF);
            else
                SetGateDAQ.AlarmActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, GateAlarmActive.OFF);
            //gatePara.gateLogicOnOff = true;

        }

        private void numUpDownDelay_Click(object sender, EventArgs e)
        {
            setGateDelay();
            //gatePara.gateDelay = numUpDownDelay.Value;
        }

        private void numUpDownWidth_Click(object sender, EventArgs e)
        {
            setGateWidth();
            //gatePara.gateWidth = numUpDownWidth.Value;
        }

        private void numUpDownThreshold_Click(object sender, EventArgs e)
        {
            setGateThreshold();
            //gatePara.gateThreshold = numUpDownThreshold.Value;
        }

        private void numUpDownDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownDelay, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                setGateDelay();
            }
            //gatePara.gateDelay = numUpDownDelay.Value;
        }

        private void numUpDownWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownWidth, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                setGateWidth();
            }
            //gatePara.gateWidth = numUpDownWidth.Value;
        }

        private void numUpDownThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownThreshold, e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                setGateThreshold();
            }
            //gatePara.gateThreshold = numUpDownThreshold.Value;
        }

        private void checkBoxOn_Click(object sender, EventArgs e)
        {
            int error_code;
            uint supressCount = 0;
            if (checkBoxOn.Checked == true)
            {
                if (SetBatchDAQ.isOn)
                    error_code = SetBatchDAQ.ScActive(SelectAscan.sessionIndex, gateNum, SuppressCounterActive.ON);
                else
                    error_code = SetGateDAQ.ScActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, SuppressCounterActive.ON);

                error_code |= GetGateDAQ.ScCounter(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref supressCount);
                if (SetBatchDAQ.isOn)
                    error_code = SetBatchDAQ.ScCounter(SelectAscan.sessionIndex, gateNum, supressCount);

                if (error_code != 0)
                {
                    checkBoxOn.Checked = false;
                    return;
                }
                numUpDownSupressCount.Enabled = true;
                numUpDownSupressCount.Value = Convert.ToDecimal(supressCount);
            }
            else
            {
                error_code = SetGateDAQ.ScActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, SuppressCounterActive.OFF);
                if (error_code != 0)
                {
                    checkBoxOn.Checked = true;
                    return;
                }
                numUpDownSupressCount.Enabled = false;
            }
        }

        private void numUpDownSupressCount_Click(object sender, EventArgs e)
        {
            uint supressCount = Convert.ToUInt32(numUpDownSupressCount.Value);
            if (SetBatchDAQ.isOn)
                SetBatchDAQ.ScCounter(SelectAscan.sessionIndex, gateNum, supressCount);
            else
                SetGateDAQ.ScCounter(SelectAscan.sessionIndex, SelectAscan.port, gateNum, supressCount);
        }

        private void numUpDownSupressCount_KeyPress(object sender, KeyPressEventArgs e)
        {

            uint supressCount = Convert.ToUInt32(numUpDownSupressCount.Value);
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)//(char)8 is the Key of BackSpace
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (SetBatchDAQ.isOn)
                    SetBatchDAQ.ScCounter(SelectAscan.sessionIndex, gateNum, supressCount);
                else
                    SetGateDAQ.ScCounter(SelectAscan.sessionIndex, SelectAscan.port, gateNum, supressCount);
            }
        }

        /**Set alram logic to positive or negtive*/
        private void setGateLogic(GateAlarmLogic logic)
        {
            int error_code;
            if (SetBatchDAQ.isOn)
            {
                error_code = SetBatchDAQ.AlarmLogic(SelectAscan.sessionIndex, gateNum, logic);
                error_code |= SetBatchDAQ.AlarmActive(SelectAscan.sessionIndex, gateNum, GateAlarmActive.ON);
            }
            else
            {
                error_code = SetGateDAQ.AlarmLogic(SelectAscan.sessionIndex, SelectAscan.port, gateNum, logic);
                error_code = SetGateDAQ.AlarmActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, GateAlarmActive.ON);
            }

            if (error_code != 0)
                return;
        }

        private int initRadioButttonOfTofMode()
        {
            int error_code;
            TofMode tofMode = TofMode.Peak;
            error_code = GetGateDAQ.TofMode(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref tofMode);
            if (error_code != 0)
                return error_code;

            switch (tofMode)
            {
                case TofMode.Peak:
                    radioButtonPeak.Checked = true;
                    preRdo = radioButtonPeak;
                    break;
                case TofMode.Flank:
                    radioButtonFlank.Checked = true;
                    preRdo = radioButtonFlank;
                    break;
                case TofMode.ZeroBefore:
                    radioButtonZeroB.Checked = true;
                    preRdo = radioButtonZeroB;
                    break;
                case TofMode.ZeroAfter:
                    radioButtonZeroA.Checked = true;
                    preRdo = radioButtonZeroA;
                    break;
                default:
                    error_code = -1;
                    MessageShow.show("Warn:Bind controls of tof mode failed!", "警告:绑定Tof mode的控件失败!");
                    break;
            }
            return error_code;
        }

        private int initRadioButttonOfGateLogic()
        {
            int error_code;
            GateAlarmLogic gateLogic = GateAlarmLogic.Negative;
            GateAlarmActive alarmActive = GateAlarmActive.OFF;
            error_code = GetGateDAQ.AlarmActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref alarmActive);
            if (error_code != 0)
                return error_code;

            if (alarmActive == GateAlarmActive.OFF)
            {
                radioButtonOff.Checked = true;
                return error_code;
            }
            else if (alarmActive == GateAlarmActive.ON)
            {
                error_code = GetGateDAQ.AlarmLogic(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref gateLogic);
                if (error_code != 0)
                    return error_code;

                switch (gateLogic)
                {
                    case GateAlarmLogic.Negative:
                        radioButtonNegative.Checked = true;
                        break;
                    case GateAlarmLogic.Positive:
                        radioButtonPositive.Checked = true;
                        break;
                    default:
                        error_code = -1;
                        MessageShow.show("Warn:Bind the controls of gate logic failed!", "警告：绑定Gate logic 的控件失败!");
                        break;
                }
                return error_code;
            }
            else
            {
                MessageShow.show("Warn:Get the testing of gate logic!", "警告：获取Gate logic 的测试模式!");
                return error_code = -1;
            }
        }

        private int initCheckBoxOfSuppressCount()
        {
            int error_code;
            SuppressCounterActive scActive = SuppressCounterActive.OFF;
            error_code = GetGateDAQ.ScActive(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref scActive);
            if (error_code != 0)
                return error_code;

            if (scActive == SuppressCounterActive.ON)
            {
                checkBoxOn.Checked = true;
                numUpDownSupressCount.Enabled = true;
                error_code = initNumUpDownSupressCount();
            }
            else
            {
                checkBoxOn.Checked = false;
                numUpDownSupressCount.Enabled = false;
            }
            return error_code;
        }

        private int initNumUpDownSupressCount()
        {
            int error_code;
            uint supressCount = 0;
            error_code = GetGateDAQ.ScCounter(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref supressCount);
            if (error_code != 0)
            {
                checkBoxOn.Checked = false;
                numUpDownSupressCount.Enabled = false;
            }
            else
            {
                numUpDownSupressCount.Value = supressCount;
            }
            return error_code;
        }

        private int initGatePositionPara()
        {
            int error_code;
            double delay = 0;
            double width = 0;
            double threshold = 0;
            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref delay);
            if (error_code != 0)
                return error_code;

            numUpDownDelay.Text = delay.ToString();

            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref width);
            if (error_code != 0)
                return error_code;

            numUpDownWidth.Text = width.ToString();

            error_code = GetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref threshold);
            if (error_code != 0)
                return error_code;

            numUpDownThreshold.Text = threshold.ToString();
            return error_code;
        }

        private int initGateIf()
        {
            int error_code = 0;
            if (gateNum != GateType.I)
            {
                checkBoxIF.Checked = false;
                return error_code;
            }
            else
            {
                IFActive ifActive = IFActive.OFF;
                error_code |= GetGateDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref ifActive);
                if (ifActive == IFActive.ON) checkBoxIF.Checked = true;
                return error_code;
            }
        }

        private void showGatePara()
        {
            int error_code;
            error_code = initRadioButttonOfTofMode();
            if (error_code != 0)
                return;

            error_code = initRadioButttonOfGateLogic();
            if (error_code != 0)
                return;

            error_code = initCheckBoxOfSuppressCount();
            if (error_code != 0)
                return;

            error_code = initGatePositionPara();
            if (error_code != 0)
                return;

            error_code = initGateIf();
            if (error_code != 0)
                return; 
        }

        public void UpdateGateLine()
        {
            double delay = Convert.ToDouble(numUpDownDelay.Value);
            double width = Convert.ToDouble(numUpDownWidth.Value);
            double threshold = Convert.ToDouble(numUpDownThreshold.Value);

            FormList.MDIChild.updateGateLineFromNud((int)gateNum, delay, width, threshold);
            //DelegateGateLine delegateGateLine = new DelegateGateLine((int)gateNum,
            //FormList.MDIChild[ascanNum], delay, width, threshold);
            //delegateGateLine.GateLineTriggerEvent += new DelegateGateLine.GateLineTrigger(delegateGateLine.drawGateLine);
            //delegateGateLine.Execute();
        }

        private void setGateDelay()
        {
            int error_code;
            double delay = Convert.ToDouble(numUpDownDelay.Value);
            if (SetBatchDAQ.isOn)
                error_code = SetBatchDAQ.GateDlay(SelectAscan.sessionIndex, gateNum, delay);
            else
                error_code = SetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gateNum, delay);
            if (error_code != 0)
                return;
            UpdateGateLine();
        }

        private void setGateWidth()
        {
            int error_code;
            double width = Convert.ToDouble(numUpDownWidth.Value);
            if (SetBatchDAQ.isOn)
                error_code = SetBatchDAQ.GateWidth(SelectAscan.sessionIndex, gateNum, width);
            else
                error_code = SetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gateNum, width);

            if (error_code != 0)
                return;
            UpdateGateLine();
        }

        private void setGateThreshold()
        {
            int error_code;
            double threshold = Convert.ToDouble(numUpDownThreshold.Value);
            if (SetBatchDAQ.isOn)
                error_code = SetBatchDAQ.GateThreshold(SelectAscan.sessionIndex, gateNum, threshold);
            else
                error_code = SetGateDAQ.Threshold(SelectAscan.sessionIndex, SelectAscan.port, gateNum, threshold);

            if (error_code != 0)
                return;
            UpdateGateLine();
        }

        private void judgeNumUpDownInput(NumericUpDown numUpDown, KeyPressEventArgs e)
        {
            //if (numUpDown.Value.ToString().Length > 8)
            //{
            //    e.Handled = true;
            //    MessageShow.show("The data input length surpass the prescribed length", "输入值超过规定的长度");
            //}
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8
                && e.KeyChar != '.')//(char)8 is the Key of BackSpace
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && numUpDown.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
        }

        /*
        private void FormGatePosition_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(SystemColors.GradientActiveCaption, 3), 1, 0, 1, this.Height);
        }
        */

        private void checkBoxIF_Click(object sender, EventArgs e)
        {

            if ((int)gateNum == 0)
            {
                int error_code = 0;
                TofMode tofMode = TofMode.Flank;
                List<TofMode> list = new List<TofMode>();
                list.Clear();

                if (checkBoxIF.Checked)
                {
                    if (SetBatchDAQ.isOn)
                    {
                        error_code = SetBatchDAQ.getTOfMode(SelectAscan.sessionIndex, GateType.I, list);

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] != TofMode.Flank)
                            {
                                MessageShow.show("Warning:The TOF Mode GateI must select Flank mode!", "警告：门模式门I未选择Flank模式!");
                                checkBoxIF.Checked = false;
                                return;
                            }
                        }
                        error_code |= SetBatchDAQ.GateIFActive(SelectAscan.sessionIndex, GateType.I, IFActive.ON);
                        error_code |= SetBatchDAQ.AscanVideoIFActive(SelectAscan.sessionIndex, GateType.I, AscanIFActive.ON);
                        if (error_code != 0)
                            return;
                    }
                    else
                    {
                        error_code = GetGateDAQ.TofMode(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, ref tofMode);

                        if (tofMode != TofMode.Flank)
                        {
                            MessageShow.show("Warning:The TOF Mode GateI must select Flank mode!", "警告：门模式门I未选择Flank模式!");
                            checkBoxIF.Checked = false;
                            return;
                        }
                        error_code |= SetGateDAQ.iFActive(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, IFActive.ON);
                        error_code |= SetAscanVideoDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, AscanIFActive.ON);
                        if (error_code != 0)
                            return;
                    }
                    
                }
                else
                {
                    if (SetBatchDAQ.isOn)
                    {
                        error_code = SetGateDAQ.iFActive(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, IFActive.OFF);
                        error_code |= SetAscanVideoDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, AscanIFActive.OFF);
                    }
                    {
                        error_code = SetGateDAQ.iFActive(SelectAscan.sessionIndex, SelectAscan.port, GateType.I, IFActive.OFF);
                        error_code |= SetAscanVideoDAQ.IFActive(SelectAscan.sessionIndex, SelectAscan.port, AscanIFActive.OFF);
                    }

                    if (error_code != 0)
                        return;

                    FormList.MDIChild.drawGateIWhenIfStartDisabled();
                }
            }

            if ((int)gateNum == 1)
            {
                MessageShow.show("Warning:The Gate must select GateI!", "警告：门模式未选择门I!");
                checkBoxIF.Checked = false;
                return;
            }

            if ((int)gateNum == 2)
            {
                MessageShow.show("Warning:The Gate must select GateI!", "警告：门模式未选择门I!");
                checkBoxIF.Checked = false;
                return;
            }

            if ((int)gateNum == 3)
            {
                MessageShow.show("Warning:The Gate must select GateI!", "警告：门模式未选择门I!");
                checkBoxIF.Checked = false;
                return;
            }
        }

        //When the gate line in MDIChild are moved and draged ,update the NumricUpDown 
        //of the GatePosition. The UpdateGatePositionNudFromLine(int gateIndex, double delay, double width, double threshold) 
        //is used in MDIChild form.
        public void UpdateGatePositionNudFromLine(int gateIndex, double delay, double width, double threshold)
        {
            if ((int)gateNum == gateIndex) //门线拖动的序号等于当前选中要显示门的序号，则更新门位置的NumricUpDown
            {
                numUpDownDelay.Value = Convert.ToDecimal(delay);
                numUpDownWidth.Value = Convert.ToDecimal(width);
                numUpDownThreshold.Value = Convert.ToDecimal(threshold);
            }
        }

        private void numUpDownDelay_Leave(object sender, EventArgs e)
        {
            if (numUpDownDelay.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入!");
                return;
            }
            setGateDelay();
        }

        private void numUpDownWidth_Leave(object sender, EventArgs e)
        {
            if (numUpDownWidth.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入!");
                return;
            }
            setGateWidth();
        }

        private void numUpDownThreshold_Leave(object sender, EventArgs e)
        {
            if (numUpDownThreshold.Text == "")
            {
                MessageShow.show("Warning:Please input!", "警告:请输入!");
                return;
            }
            setGateThreshold();
        }

        private void checkBoxIF_CheckedChanged(object sender, EventArgs e)
        {

        }

        //private void SaveCurrent(string filename)
        //{
        //    SystemConfig.WriteBase64Data(filename, "GatePara", gatePara);
        //}

        //public void FormSave()
        //{
        //    if (gateI.Count != sessionInfoSave.Count)
        //    {
        //        MessageShow.show("Error:Save Gate failed!", "错误：门参数保存失败!");
        //        return;
        //    }
        //    string filename = SystemConfig.GlobalSave("GateI");
        //    SystemConfig.WriteBase64Data(filename, "GateI",gateI);

        //    filename = SystemConfig.GlobalSave("GateA");
        //    SystemConfig.WriteBase64Data(filename, "GateA", gateA);

        //    filename = SystemConfig.GlobalSave("GateB");
        //    SystemConfig.WriteBase64Data(filename, "GateB", gateB);

        //    filename = SystemConfig.GlobalSave("GateC");
        //    SystemConfig.WriteBase64Data(filename, "GateC", gateC);

        //    filename = SystemConfig.GlobalSave("SessionInfo");
        //    SystemConfig.WriteBase64Data(filename, "SessionInfo", sessionInfoSave);
        //}

    }

    

}
