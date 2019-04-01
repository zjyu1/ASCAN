using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ascan;
using Steema.TeeChart;
using Steema.TeeChart.Styles;
using System.IO;

namespace ScanImage
{
    public partial class FormBscanSet : Form
    {
        uint ascanIndex;
        BscanCofig bscanCofig;
        public FormBscanSet(BscanCofig bscanCofig)
        {
            InitializeComponent();
            this.bscanCofig = bscanCofig;
        }

        private void FormBscanSet_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            ascanIndex = 0;
            txtSessionName.Text = SessionHardWare.getSessionName((int)ascanIndex);

            cmbSelectGate.SelectedIndex = 0;
            cmbScanAxis.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (txtScanLength.Text == null || txtResolution.Text == null)
            {
                MessageShow.show("Please set parameter!", "请设置参数!");
                return;
            }

            setBscanCofig();
            this.Close();       
        }

        private void setBscanCofig()
        {
            double BGateDelay = 0;
            double BGateRange = 0; 
            bscanCofig.AscanIndex = (int)ascanIndex;
            bscanCofig.ScanAxisIndex = cmbScanAxis.SelectedIndex;

            GetGateDAQ.Delay(0,0, GateType.B, ref BGateDelay);
            GetGateDAQ.Width(0, 0,GateType.B, ref BGateRange);

            bscanCofig.HorizontalAxisMin = BGateDelay;
            bscanCofig.HorizontalAxisMax = BGateDelay + BGateRange;
            bscanCofig.VerticalAxisMin = 0;
            bscanCofig.VerticalAxisMax = Convert.ToDouble(txtScanLength.Text);
            bscanCofig.Range = BGateRange;

            bscanCofig.Resolution = Convert.ToDouble(txtResolution.Text);
            bscanCofig.ScanLength = Convert.ToDouble(txtScanLength.Text);

            bscanCofig.IsSetOk = true;

            bscanCofig.FileName = pathTxtBox.Text;
            bscanCofig.IsSave = checkBox.Checked;
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

    public class BscanCofig
    {
        public static int pointCnt = 256;

        private int ascanIndex;
        public int AscanIndex
        {
            get { return ascanIndex; }
            set { ascanIndex = value; }
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

        private double range;
        public double Range
        {
            get { return range; }
            set { range = value; }
        }

        private double resolution;
        public double Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

        private double scanLength;
        public double ScanLength
        {
            get { return scanLength; }
            set { scanLength = value; }
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
