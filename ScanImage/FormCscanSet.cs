using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ascan;
using AUT;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System.IO;

namespace ScanImage
{
    public partial class FormCscanSet : Form
    {
        uint ascanIndex;

        CscanConfig cscanConfig;
        BscanCofig bscanCofig;

        public FormCscanSet(CscanConfig cscanConfig ,BscanCofig bscanCofig)
        {
            InitializeComponent();
            this.cscanConfig = cscanConfig;
            this.bscanCofig = bscanCofig;
        }

        private void FormCscanSet_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            ascanIndex = 0;
            txtSessionName.Text = SessionHardWare.getSessionName((int)ascanIndex);

            cmbSelectGate.SelectedIndex = 2;
            cmbScanAxis.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (txtXScanLength.Text == null || txtYScanLength.Text == null ||
                txtXResolution.Text == null || txtYResolution.Text == null)
            {
                MessageShow.show("Please set parameter!", "请设置参数!");
                return;
            }

            setCscanConfig();
            setBscanCofig();

            this.Close();
        }



        private void setCscanConfig()
        {
            cscanConfig.AscanIndex = (int)ascanIndex;
            cscanConfig.SelectGate = (int)Math.Pow(2, cmbSelectGate.SelectedIndex);
            cscanConfig.ScanAxisIndex = cmbScanAxis.SelectedIndex;
            cscanConfig.VerticalAxisMin = 0;
            cscanConfig.VerticalAxisMax = Convert.ToDouble(txtYScanLength.Text);
            cscanConfig.HorizontalAxisMin = 0;
            cscanConfig.HorizontalAxisMax = Convert.ToDouble(txtXScanLength.Text);
            cscanConfig.XResolution = Convert.ToDouble(txtXResolution.Text);
            cscanConfig.YResolution = Convert.ToDouble(txtYResolution.Text);
            cscanConfig.IsSetOk = true;
            cscanConfig.FileName = pathTxtBox.Text;
            cscanConfig.IsSave = checkBox.Checked;
        }

        private void setBscanCofig()
        {
            double BGateDelay = 0;
            double BGateRange = 0;

            GetGateDAQ.Delay(0, 0, GateType.B, ref BGateDelay);
            GetGateDAQ.Width(0, 0, GateType.B, ref BGateRange);

            bscanCofig.HorizontalAxisMin = 0;
            bscanCofig.HorizontalAxisMax = Convert.ToDouble(txtXScanLength.Text); 
            bscanCofig.VerticalAxisMin = BGateDelay;
            bscanCofig.VerticalAxisMax = BGateDelay + BGateRange;
            bscanCofig.Range = BGateRange;

            bscanCofig.Resolution = Convert.ToDouble(txtXResolution.Text);
            bscanCofig.ScanLength = Convert.ToDouble(txtXScanLength.Text);

            bscanCofig.IsSetOk = true;

            bscanCofig.FileName = pathTxtBox.Text;
            bscanCofig.IsSave = checkBox.Checked;
        }

        private void cmbSelectGate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cscanConfig.SelectGate = (int)Math.Pow(2, cmbSelectGate.SelectedIndex);
        }

        private void cmbScanAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            cscanConfig.AscanIndex = cmbScanAxis.SelectedIndex;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                string filePath = Application.StartupPath + @"\GateData";
                openFileDialog1.Filter = "bin文件(*.bin)|*.bin|所有文件(*.*)|*.*";

                if (!Directory.Exists(filePath))
                {
                    try
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    catch
                    {
                        filePath = Application.StartupPath;
                    }
                }
                openFileDialog1.InitialDirectory = filePath;
                openFileDialog1.FilterIndex = 1;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    pathTxtBox.Text = fileName;
                }
            }
        }
    }

    public class CscanConfig
    {
        private int ascanIndex;
        public int AscanIndex
        {
            get { return ascanIndex; }
            set { ascanIndex = value; }
        }

        private int selectGate;
        public int SelectGate
        {
            get { return selectGate; }
            set { selectGate = value; }
        }

        private int scanAxisIndex;
        public int ScanAxisIndex
        {
            get { return scanAxisIndex; }
            set { scanAxisIndex = value; }
        }

        private double verticalAxisMin;
        public double VerticalAxisMin
        {
            get { return verticalAxisMin; }
            set { verticalAxisMin = value; }
        }

        private double verticalAxisMax;
        public double VerticalAxisMax
        {
            get { return verticalAxisMax; }
            set { verticalAxisMax = value; }
        }

        private double horizontalAxisMin;
        public double HorizontalAxisMin
        {
            get { return horizontalAxisMin; }
            set { horizontalAxisMin = value; }
        }

        private double horizontalAxisMax;
        public double HorizontalAxisMax
        {
            get { return horizontalAxisMax; }
            set { horizontalAxisMax = value; }
        }

        private double xResolution;
        public double XResolution
        {
            get { return xResolution; }
            set { xResolution = value; }
        }

        private double yResolution;
        public double YResolution
        {
            get { return yResolution; }
            set { yResolution = value; }
        }

        private bool isSetOk;
        public bool IsSetOk
        {
            get { return isSetOk; }
            set { isSetOk = value; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private bool isSave;
        public bool IsSave
        {
            get { return isSave; }
            set { isSave = value; }
        }
    }
}
