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
    public partial class FormToleranceMonitor : Form
    {
        private uint tolMonitorMode1;//I or BA
        private uint tolMonitorMode2;//A or AI
        private uint tolMonitorMode3;//B or BI
        private uint tolMonitorMode4;//C OR CI

        public FormToleranceMonitor()
        {
            InitializeComponent();
        }

        private void FormToranceMonitor_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
            initTolerance();
        }

        private void initTolerance()
        {
            int error_code;
            TMActive gateActive = TMActive.OFF;
            TMActive dGateActive =TMActive.OFF;

            for (int tolMonitorIndex = 0; tolMonitorIndex < 4; tolMonitorIndex++)
            {
                error_code = GetGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (GateType)tolMonitorIndex, ref gateActive);
                if (error_code != 0)
                    return;

                error_code = GetDGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, (DGateType)tolMonitorIndex, ref dGateActive);
                if (error_code != 0)
                    return;

                if (gateActive == TMActive.ON && dGateActive == TMActive.ON)
                    MessageShow.show("Warn:Gate and double gate tolerance monitor are all active,need to select one to active!",
                        "警告：门容限误差和双门容限误差都打开，只能选择一种容限误差模式！");
                else if (gateActive == TMActive.ON)
                {
                    ((CheckBox)(Controls.Find("check" + tolMonitorIndex+ 1 + "ON", true)[0])).Checked = true;
                    ((RadioButton)(Controls.Find("gate" + tolMonitorIndex + 1, true)[0])).Checked = true;
                }
                else if (dGateActive == TMActive.ON)
                {
                    ((CheckBox)(Controls.Find("check" + tolMonitorIndex + 1 + "ON", true)[0])).Checked = true;
                    ((RadioButton)(Controls.Find("dGate" + tolMonitorIndex + 1, true)[0])).Enabled = true;
                }
                else
                    setControlsEnabled(tolMonitorIndex + 1, false);
            }
        }

        private void checkBox1ON_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 1;
            setCheckBox(tolMonitorIndex, GateType.I, DGateType.BA);
        }

        private void checkBox2ON_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 2;
            setCheckBox(tolMonitorIndex, GateType.A, DGateType.AI);
        }

        private void checkBox3ON_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 3;
            setCheckBox(tolMonitorIndex, GateType.B, DGateType.BI);
        }

        private void checkBox4ON_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 4;
            setCheckBox(tolMonitorIndex, GateType.C, DGateType.CI);
        }

        private void getGateTolMonitor(GateType gateType, DGateType dGatetType, int tolMonitorIndex)
        {
            int error_code;
            double min = 0;
            double max = 0;
            uint suppressCnt = 0;

            //Close double gate tolerance active
            error_code = SetDGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, dGatetType, TMActive.OFF);
            if (error_code != 0)
                return;

            //Open gate tolerance active
            error_code = SetGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, gateType, TMActive.ON);
            if (error_code != 0)
                return;

            error_code = GetGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref max);
            if (error_code != 0)
                return;
            ((NumericUpDown)(Controls.Find("numUpDownMax" + tolMonitorIndex, true)[0])).Text = max.ToString();

            error_code = GetGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref min);
            if (error_code != 0)
                return;
            ((NumericUpDown)(Controls.Find("numUpDownMin" + tolMonitorIndex, true)[0])).Text = min.ToString();

            error_code = GetGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref suppressCnt);
            if (error_code != 0)
                return;
            ((NumericUpDown)(Controls.Find("numUpDownSc" + tolMonitorIndex, true)[0])).Text = suppressCnt.ToString();
        }
       
        private void setCheckBox(int tolMonitorIndex, GateType gateType, DGateType dGateType)
        {
            bool isCheckBoxChecked;

            isCheckBoxChecked = ((CheckBox)(Controls.Find("checkBox" + tolMonitorIndex + "ON", true)[0])).Checked;

            if (isCheckBoxChecked == true)
            {
                setControlsEnabled(tolMonitorIndex, true);
                ((RadioButton)(Controls.Find("dGate" + tolMonitorIndex, true)[0])).Checked = true;//Active double gate tolerance monitor defaultly
            }
            else
            {
                setControlsEnabled(tolMonitorIndex, false);
                SetGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, gateType, TMActive.OFF);
                SetDGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, dGateType, TMActive.OFF);
            }
        }
        
        private void setControlsEnabled(int tolMonitorIndex, bool enabled)
        {
            ((RadioButton)(Controls.Find("gate" + tolMonitorIndex, true)[0])).Enabled = enabled;
            ((RadioButton)(Controls.Find("dGate" + tolMonitorIndex, true)[0])).Enabled = enabled;
            ((Button)(Controls.Find("buttonGet" + tolMonitorIndex, true)[0])).Enabled = enabled;
            ((NumericUpDown)(Controls.Find("numUpDownMax" + tolMonitorIndex, true)[0])).Enabled = enabled;
            ((NumericUpDown)(Controls.Find("numUpDownMin" + tolMonitorIndex, true)[0])).Enabled = enabled;
            ((NumericUpDown)(Controls.Find("numUpDownSc" + tolMonitorIndex, true)[0])).Enabled = enabled;
        }

        private void getDoubleGateTolMonitor(GateType gateType, DGateType dGatetType, int tolMonitorIndex)
        {
            int error_code;
            double min = 0;
            double max = 0;
            uint suppressCnt = 0;

            //Close gate tolerance active
            error_code = SetGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, gateType, TMActive.OFF);
            if (error_code != 0)
                return;

            //Open double gate tolerance active
            error_code = SetDGateDAQ.TolMonitorActive(SelectAscan.sessionIndex, SelectAscan.port, dGatetType, TMActive.ON);
            if (error_code != 0)
                return;

            error_code = GetDGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, dGatetType, ref max);
            if (error_code != 0)
                return;
            ((NumericUpDown)(Controls.Find("numUpDownMax" + tolMonitorIndex, true)[0])).Text = max.ToString();

            error_code = GetDGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, dGatetType, ref min);
            if (error_code != 0)
                return;
            ((NumericUpDown)(Controls.Find("numUpDownMin" + tolMonitorIndex, true)[0])).Text = min.ToString();

            error_code = GetDGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, dGatetType, ref suppressCnt);
            if (error_code != 0)
                return;
            ((NumericUpDown)(Controls.Find("numUpDownSc" + tolMonitorIndex, true)[0])).Text = suppressCnt.ToString();
        }

        private void gate1_Click(object sender, EventArgs e)
        {
            tolMonitorMode1 = (uint)TolMonitorMode.Gate;
            int tolMonitorIndex = 1;
            getGateTolMonitor(GateType.I, DGateType.BA, tolMonitorIndex);
        }

        private void dGate1_Click(object sender, EventArgs e)
        {
            tolMonitorMode1 = (uint)TolMonitorMode.DGate;
            int tolMonitorIndex = 1;
            getDoubleGateTolMonitor(GateType.I, DGateType.BA, tolMonitorIndex);
        }

        private void setTolMonitorMax(GateType gateType, DGateType dGateType, double tolMonitorMax)
        {
            if ((TolMonitorMode)tolMonitorMode1 == TolMonitorMode.Gate)
                SetGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, gateType, tolMonitorMax);
            else
                SetDGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, dGateType, tolMonitorMax);
        }

        private void numUpDownMax1_Click(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToDouble(numUpDownMax1.Value);
            setTolMonitorMax(GateType.I, DGateType.BA, tolMonitorMax);
        }

        private void numUpDownMin1_Click(object sender, EventArgs e)
        {
            double tolMonitorMin = Convert.ToDouble(numUpDownMin1.Value);
            setTolMonitorMin(GateType.I, DGateType.BA, tolMonitorMin);         
        }

        private void numUpDownSc1_Click(object sender, EventArgs e)
        {
            uint suppressCnt = Convert.ToUInt32(numUpDownSc1.Value);
            setTolMonitorSc(GateType.I, DGateType.BA, suppressCnt);
        }

        private void judgeNumUpDownInput(NumericUpDown numUpDown, KeyPressEventArgs e)
        {
            if (numUpDown.Value.ToString().Length > 8)
            {
                e.Handled = true;
                MessageShow.show("The data input length surpass the prescribed length", "输入值超过规定的长度");
            }
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

        private void setTolMonitorSc(GateType gateType, DGateType dGateType, uint suppressCnt)
        {
            if ((TolMonitorMode)tolMonitorMode1 == TolMonitorMode.Gate)
                SetGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, gateType, suppressCnt);
            else
                SetDGateDAQ.TolMonitorSc(SelectAscan.sessionIndex, SelectAscan.port, dGateType, suppressCnt);
        }

        private void numUpDownMax1_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMax1, e);
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax1.Value);
            if(e.KeyChar==(char)Keys.Enter)
                setTolMonitorMax(GateType.I, DGateType.BA, tolMonitorMax);     
        }

        private void numUpDownMax1_Leave(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax1.Value);
            setTolMonitorMax(GateType.I, DGateType.BA, tolMonitorMax);  
        }

        private void numUpDownMin1_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMin1, e);
            double tolMonitorMin = Convert.ToUInt32(numUpDownMin1.Value);
            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorMin(GateType.I, DGateType.BA, tolMonitorMin);
        }

        private void numUpDownMin1_Leave(object sender, EventArgs e)
        {
            double tolMonitorMin = Convert.ToUInt32(numUpDownMin1.Value);
            setTolMonitorMin(GateType.I, DGateType.BA, tolMonitorMin);
        }

        private void numUpDownSc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)//(char)8 is the Key of BackSpace
                e.Handled = true;

            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc1);

            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorSc(GateType.I, DGateType.BA, tolMonitorSc);
        }

        private void numUpDownSc1_Leave(object sender, EventArgs e)
        {
            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc1);
            setTolMonitorSc(GateType.I, DGateType.BA, tolMonitorSc);
        }

        /**Caculate tolMonitorMax and tolMonitorMin accordint to dGateType.
         * @param gateType1 and gateType2 accord to dGateType.
         * */
        private void tolMonitorAccordToDGate(GateType gateType1, GateType gateType2, DGateType dGateType, int tolMonitorIndex)
        {
            int error_code;
            GateType gateType;
            double tolMonitorMax;
            double tolMonitorMin;
            int gate1 = 0;
            int gate2 = 1;
            double[] delay = new double[2] { 0, 0};//index=0,delay of gateType1;index=1,delay of gateType2
            double[] width = new double[2] { 0, 0};
            double[] gateEnd = new double[2] { 0, 0 };

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                    gateType = gateType1;
                else
                    gateType = gateType2;

                error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref delay[i]);
                if (error_code != 0)
                    return;

                error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref width[i]);
                if (error_code != 0)
                    return;

                gateEnd[i] = delay[i] + width[i];
            }

            //caculate tolMonitorMax and tolMonitorMin
            if (delay[gate1] > delay[gate2])
            {
                if (delay[gate1] > gateEnd[gate2])
                {
                    tolMonitorMax = gateEnd[gate1] - delay[gate2];
                    tolMonitorMin = delay[gate1] - gateEnd[gate2];
                }
                else if (delay[gate1] <= gateEnd[gate2] && gateEnd[gate2] <= gateEnd[gate1])
                {
                    tolMonitorMax = gateEnd[gate1] - delay[gate2];
                    tolMonitorMin = 0;
                }
                else
                {
                    tolMonitorMax = gateEnd[gate2] - delay[gate2];
                    tolMonitorMin = 0;
                }
            }
            else
            {
                if (delay[gate2] > gateEnd[gate1])
                {
                    tolMonitorMax = gateEnd[gate2] - delay[gate1];
                    tolMonitorMin = delay[gate2] - gateEnd[gate1];
                }
                else if (delay[gate2] <= gateEnd[gate1] && gateEnd[gate1] <= gateEnd[gate2])
                {
                    tolMonitorMax = gateEnd[gate2] - delay[gate1];
                    tolMonitorMin = 0;
                }
                else
                {
                    tolMonitorMax = gateEnd[gate1] - delay[gate1];
                    tolMonitorMin = 0;
                }
            }

            ((NumericUpDown)(Controls.Find("numUpDownMax" + tolMonitorIndex, true)[0])).Text = tolMonitorMax.ToString();
            ((NumericUpDown)(Controls.Find("numUpDownMin" + tolMonitorIndex, true)[0])).Text = tolMonitorMin.ToString();

            SetDGateDAQ.TolMonitorMax(SelectAscan.sessionIndex, SelectAscan.port, dGateType, tolMonitorMax);
            SetDGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, dGateType, tolMonitorMin);
        }

        private void setTolMonitorMin(GateType gateType, DGateType dGateType, double tolMonitorMin)
        {
            if ((TolMonitorMode)tolMonitorMode1 == TolMonitorMode.Gate)
                SetGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, gateType, tolMonitorMin);
            else
                SetDGateDAQ.TolMonitorMin(SelectAscan.sessionIndex, SelectAscan.port, dGateType, tolMonitorMin);
        }

        private void tolMonitorAccordToGate(GateType gateType, int tolMonitorIndex)
        {
            int error_code;
            double delay = 0;
            double width = 0;
            double tolMonitorMax;
            double tolMonitorMin;

            error_code = GetGateDAQ.Delay(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref delay);
            if (error_code != 0)
                return;

            error_code = GetGateDAQ.Width(SelectAscan.sessionIndex, SelectAscan.port, gateType, ref width);
            if (error_code != 0)
                return;

            tolMonitorMin = delay;
            tolMonitorMax = delay + width;

            ((NumericUpDown)(Controls.Find("numUpDownMax" + tolMonitorIndex, true)[0])).Text = tolMonitorMax.ToString();
            ((NumericUpDown)(Controls.Find("numUpDownMin" + tolMonitorIndex, true)[0])).Text = tolMonitorMin.ToString();
        }

        private void buttonGet1_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 1;

            if ((TolMonitorMode)tolMonitorMode1 == TolMonitorMode.Gate)
                tolMonitorAccordToGate(GateType.I, tolMonitorIndex);
            else
                tolMonitorAccordToDGate(GateType.B, GateType.A, DGateType.BA, tolMonitorIndex);
        }

        private void gate2_Click(object sender, EventArgs e)
        {
            tolMonitorMode2 = (uint)TolMonitorMode.Gate;
            int tolMonitorIndex = 2;
            getGateTolMonitor(GateType.A, DGateType.AI, tolMonitorIndex);
        }

        private void dGate2_Click(object sender, EventArgs e)
        {
            tolMonitorMode2 = (uint)TolMonitorMode.DGate;
            int tolMonitorIndex = 2;
            getDoubleGateTolMonitor(GateType.A, DGateType.AI, tolMonitorIndex);
        }

        private void numUpDownMax2_Click(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToDouble(numUpDownMax2.Value);
            setTolMonitorMax(GateType.A, DGateType.AI, tolMonitorMax);
        }

        private void numUpDownMin2_Click(object sender, EventArgs e)
        {
            double tolMonitorMin = Convert.ToDouble(numUpDownMin2.Value);
            setTolMonitorMin(GateType.A, DGateType.AI, tolMonitorMin);        
        }

        private void numUpDownSc2_Click(object sender, EventArgs e)
        {
            uint suppressCnt = Convert.ToUInt32(numUpDownSc2.Value);    
            setTolMonitorSc(GateType.A, DGateType.AI, suppressCnt);           
        }

        private void numUpDownMax2_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMax2, e);
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax2.Value);
            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorMax(GateType.A, DGateType.AI, tolMonitorMax);     
        }

        private void numUpDownMax2_Leave(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax2.Value);
            setTolMonitorMax(GateType.A, DGateType.AI, tolMonitorMax);  
        }

        private void numUpDownMin2_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMin2, e);
            double tolMonitorMin = Convert.ToUInt32(numUpDownMin2.Value);
            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorMin(GateType.A, DGateType.AI, tolMonitorMin);
        }

        private void numUpDownMin2_Leave(object sender, EventArgs e)
        {
            double tolMonitorMin = Convert.ToUInt32(numUpDownMin2.Value);
            setTolMonitorMin(GateType.A, DGateType.AI, tolMonitorMin);
        }

        private void numUpDownSc2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)//(char)8 is the Key of BackSpace
                e.Handled = true;

            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc2);

            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorSc(GateType.A, DGateType.AI, tolMonitorSc);
        }

        private void numUpDownSc2_Leave(object sender, EventArgs e)
        {
            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc2);
            setTolMonitorSc(GateType.A, DGateType.AI, tolMonitorSc);
        }

        private void buttonGet2_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 2;

            if ((TolMonitorMode)tolMonitorMode2 == TolMonitorMode.Gate)
                tolMonitorAccordToGate(GateType.A, tolMonitorIndex);
            else
                tolMonitorAccordToDGate(GateType.A, GateType.I, DGateType.AI, tolMonitorIndex);
        }

        private void gate3_Click(object sender, EventArgs e)
        {
            tolMonitorMode3 = (uint)TolMonitorMode.Gate;
            int tolMonitorIndex = 3;
            getGateTolMonitor(GateType.B, DGateType.BI, tolMonitorIndex);
        }

        private void dGate3_Click(object sender, EventArgs e)
        {
            tolMonitorMode3 = (uint)TolMonitorMode.DGate;
            int tolMonitorIndex = 3;
            getDoubleGateTolMonitor(GateType.B, DGateType.BI, tolMonitorIndex);
        }

        private void numUpDownMax3_Click(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToDouble(numUpDownMax3.Value);
            setTolMonitorMax(GateType.B, DGateType.BI, tolMonitorMax);
        }

        private void numUpDownMin3_Click(object sender, EventArgs e)
        {
            double tolMonitorMin = Convert.ToDouble(numUpDownMin3.Value);
            setTolMonitorMin(GateType.B, DGateType.BI, tolMonitorMin);        
        }

        private void numUpDownSc3_Click(object sender, EventArgs e)
        {
            uint suppressCnt = Convert.ToUInt32(numUpDownSc3.Value);
            setTolMonitorSc(GateType.B, DGateType.BI, suppressCnt);           
        }

        private void numUpDownMax3_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMax3, e);
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax3.Value);
            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorMax(GateType.B, DGateType.BI, tolMonitorMax);     
        }

        private void numUpDownMax3_Leave(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax3.Value);
            setTolMonitorMax(GateType.B, DGateType.BI, tolMonitorMax);  
        }

        private void numUpDownMin3_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMin3, e);
            double tolMonitorMin = Convert.ToUInt32(numUpDownMin3.Value);
            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorMin(GateType.B, DGateType.BI, tolMonitorMin);
        }

        private void numUpDownMin3_Leave(object sender, EventArgs e)
        {
            double tolMonitorMin = Convert.ToUInt32(numUpDownMin3.Value);
            setTolMonitorMin(GateType.B, DGateType.BI, tolMonitorMin);
        }

        private void numUpDownSc3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)//(char)8 is the Key of BackSpace
                e.Handled = true;

            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc3);

            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorSc(GateType.B, DGateType.BI, tolMonitorSc);
        }

        private void numUpDownSc3_Leave(object sender, EventArgs e)
        {
            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc2);
            setTolMonitorSc(GateType.B, DGateType.BI, tolMonitorSc);
        }

        private void buttonGet3_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 3;

            if ((TolMonitorMode)tolMonitorMode3 == TolMonitorMode.Gate)
                tolMonitorAccordToGate(GateType.B, tolMonitorIndex);
            else
                tolMonitorAccordToDGate(GateType.B, GateType.I, DGateType.BI, tolMonitorIndex);
        }

        private void gate4_Click(object sender, EventArgs e)
        {
            tolMonitorMode4 = (uint)TolMonitorMode.Gate;
            int tolMonitorIndex = 4;
            getGateTolMonitor(GateType.C, DGateType.CI, tolMonitorIndex);
        }

        private void dGate4_Click(object sender, EventArgs e)
        {
            tolMonitorMode4 = (uint)TolMonitorMode.DGate;
            int tolMonitorIndex = 4;
            getDoubleGateTolMonitor(GateType.C, DGateType.CI, tolMonitorIndex);
        }

        private void numUpDownMax4_Click(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToDouble(numUpDownMax4.Value);
            setTolMonitorMax(GateType.C, DGateType.CI, tolMonitorMax);
        }

        private void numUpDownMin4_Click(object sender, EventArgs e)
        {
            double tolMonitorMin = Convert.ToDouble(numUpDownMin4.Value);
            setTolMonitorMin(GateType.C, DGateType.CI, tolMonitorMin);       
        }

        private void numUpDownSc4_Click(object sender, EventArgs e)
        {
            uint suppressCnt = Convert.ToUInt32(numUpDownSc4.Value);
            setTolMonitorSc(GateType.C, DGateType.CI, suppressCnt);           
        }

        private void numUpDownMax4_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMax4, e);
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax4.Value);
            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorMax(GateType.C, DGateType.CI, tolMonitorMax);     
        }

        private void numUpDownMax4_Leave(object sender, EventArgs e)
        {
            double tolMonitorMax = Convert.ToUInt32(numUpDownMax4.Value);
            setTolMonitorMax(GateType.C, DGateType.CI, tolMonitorMax);  
        }

        private void numUpDownMin4_KeyPress(object sender, KeyPressEventArgs e)
        {
            judgeNumUpDownInput(numUpDownMin4, e);
            double tolMonitorMin = Convert.ToUInt32(numUpDownMin4.Value);
            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorMin(GateType.C, DGateType.CI, tolMonitorMin);
        }

        private void numUpDownMin4_Leave(object sender, EventArgs e)
        {
            double tolMonitorMin4 = Convert.ToUInt32(numUpDownMin4.Value);
            setTolMonitorMin(GateType.C, DGateType.CI, tolMonitorMin4);
        }

        private void numUpDownSc4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)//(char)8 is the Key of BackSpace
                e.Handled = true;

            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc4);

            if (e.KeyChar == (char)Keys.Enter)
                setTolMonitorSc(GateType.C, DGateType.CI, tolMonitorSc);
        }

        private void numUpDownSc4_Leave(object sender, EventArgs e)
        {
            uint tolMonitorSc = Convert.ToUInt32(numUpDownSc4);
            setTolMonitorSc(GateType.C, DGateType.CI, tolMonitorSc);
        }

        private void buttonGet4_Click(object sender, EventArgs e)
        {
            int tolMonitorIndex = 4;

            if ((TolMonitorMode)tolMonitorMode4 == TolMonitorMode.Gate)
                tolMonitorAccordToGate(GateType.C, tolMonitorIndex);
            else
                tolMonitorAccordToDGate(GateType.C, GateType.I, DGateType.CI, tolMonitorIndex);

        }
    }

    public enum TolMonitorMode
    {
        Gate = 0,
        DGate = 1
    }
}