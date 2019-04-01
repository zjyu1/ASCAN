using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ascan;

namespace AUT
{
    public partial class FormAUT : MainForm
    {
        private static FormStripMap formstrip;
        private static FormCalibration formcalib;
        private static FormReport formreport;
        public FormAUT():base()
        {
            InitializeComponent();
        }

        protected override void measurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormList.FormMeasurement == null)
            {
                FormList.FormMeasurement = new FormStripMap(this);
            }
            FormList.FormMeasurement.Show();
        }

        //Refresh the tableControl according to the measurement mode
        protected override void openReport()
        {
            if (FormList.FormBatch.od.batchList == null)
            {
                MessageShow.show("Please Creat or Open a Batch!", "请在批次面板新建或打开一个批次！");
                return;
            }
            if (formreport == null)
            {
                formreport = new FormReport(this);
            }
            formreport.Show();
        }

        protected override void RefreshTableControl()
        {
            if (this.measMode == RunMode.ManulMode)
            {
                tbManualMode.Parent = this.tbShow;
                this.tbShow.Dock = DockStyle.Fill;
                tbAutoMode.Parent = null;
                tbCheckMode.Parent = null;
            }
            else if (this.measMode == RunMode.Auto)
            {
                if (this.detectionmode == null)
                {
                    MessageBox.Show("请先配置检测模式！");
                    return;
                }
                if (FormList.FormBatch.od.batchList == null)
                {
                    MessageBox.Show("请在批次面板新建或打开一个批次！");
                    return;
                }
                this.tbShow.Dock = DockStyle.Fill;
                if (FormList.FormMeasurement == null || formstrip == null)
                {
                    formstrip = new FormStripMap(this);
                }
                FormList.FormMeasurement = formstrip;
                addFormToPanels(FormList.FormMeasurement, this.tbAutoMode);

                tbAutoMode.Parent = this.tbShow;
                tbManualMode.Parent = null;
                tbCheckMode.Parent = null;
            }
            else if (this.measMode == RunMode.CheckMode)
            {
                this.tbShow.Dock = DockStyle.Fill;
                if (FormList.FormMeasurement == null || formcalib == null)
                {
                    formcalib = new FormCalibration(this);
                }
                FormList.FormMeasurement = formcalib;
                addFormToPanels(FormList.FormMeasurement, this.tbCheckMode);
                //if (FormList.FormCalibrate == null)
                //    FormList.FormCalibrate = new FormCalibration(this);
                //addFormToPanels(FormList.FormCalibrate, this.tbCheckMode);

                tbCheckMode.Parent = this.tbShow;
                tbManualMode.Parent = null;
                tbAutoMode.Parent = null;
            }
        }
    }
}
