using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ascan;

namespace ScanImage
{
    public partial class FormScan : MainForm
    {
        public FormScan(): base()
        {
            InitializeComponent();
        }

        protected override void RefreshTableControl()
        {
            if (this.measMode == RunMode.ManulMode)
            {
                tbManualMode.Parent = this.tbShow;
                this.tbShow.Dock = DockStyle.Fill;
                tbAutoMode.Parent = null;
            }
            else if (this.measMode == RunMode.Auto)
            {
                this.tbShow.Dock = DockStyle.Fill;
                if (FormList.FormMeasurement == null)
                {
                    FormList.FormMeasurement = new FormImage();
                }
                FormList.FormMeasurement.Show();
                addFormToPanels(FormList.FormMeasurement, this.tbAutoMode);

                tbAutoMode.Parent = this.tbShow;
                tbManualMode.Parent = null;
            }

            /*
            this.tbShow.Dock = DockStyle.Fill;
            FormList.FormMeasurement = new FormImage();
            FormList.FormMeasurement.Show();
            */
        }
        /*
        protected override void measurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormList.FormMeasurement == null)
            {
                FormList.FormMeasurement = new FormImage();
            }

            FormList.FormMeasurement.Show();
        }
        */
    }
}
