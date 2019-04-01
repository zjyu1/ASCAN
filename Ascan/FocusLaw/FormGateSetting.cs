using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ascan
{
    public partial class FormGateSetting : Form
    {
        private GateInformation gateB;
        private FormFocus formfocus;

        public FormGateSetting(FormFocus formfocus,GateInformation gateb)
        {
            InitializeComponent();
            gateB = gateb;
            this.formfocus = formfocus;
            InitGateInforemation();
        }

        private void InitGateInforemation()
        {
            targetmode.Checked = true;
            weldmode.Checked = false;
            Bbefore.Text = Convert.ToString(gateB.gatebefore);
            Bafter.Text = Convert.ToString(gateB.gateafter);
            Bthreshold.Text = Convert.ToString(gateB.gatethreshold * 100);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            GateMode tmpmode;
            if (targetmode.Checked == true)
            {
                tmpmode = GateMode.target;
            }
            else
            {
                tmpmode = GateMode.weld;
            }
            gateB.gatebefore = Convert.ToDouble(Bbefore.Text);
            gateB.gateafter = Convert.ToDouble(Bafter.Text);
            gateB.gatethreshold = Convert.ToDouble(Bthreshold.Text);
            gateB.mode = tmpmode;
            formfocus.GetGatedata(gateB);
            this.Hide();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormGateSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }

    public class GateInformation
    {
        private const double DefaultGateDelay = 3;
        private const double GateBDefaultThreshold = 0.2;
        public double gatebefore;
        public double gateafter;
        public double gatethreshold;
        public GateMode mode;

        public GateInformation()
        {
            gatebefore = DefaultGateDelay;
            gateafter = DefaultGateDelay;
            gatethreshold = GateBDefaultThreshold;
            mode = GateMode.target;
        }
    }

    public enum GateMode
    {
        target = 0,
        weld = 1
    }
}
