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
    public partial class FormGateInfo : Form
    {
        int I = 0;
        int A = 1;
        int B = 2;
        int C = 3;

        public FormGateInfo()
        {
            InitializeComponent();

            this.dataGridView_sgGate.Rows.Add();
            this.dataGridView_sgGate.Rows.Add();
            this.dataGridView_sgGate.Rows.Add();
            this.dataGridView_sgGate.Rows.Add();
            this.dataGridView_sgGate.Rows[0].Cells[0].Value = "I";
            this.dataGridView_sgGate.Rows[1].Cells[0].Value = "A";
            this.dataGridView_sgGate.Rows[2].Cells[0].Value = "B";
            this.dataGridView_sgGate.Rows[3].Cells[0].Value = "C";

            this.dataGridView_dbGate.Rows.Add();
            this.dataGridView_dbGate.Rows.Add();
            this.dataGridView_dbGate.Rows.Add();
            this.dataGridView_dbGate.Rows.Add();
            this.dataGridView_dbGate.Rows[0].Cells[0].Value = "BA";
            this.dataGridView_dbGate.Rows[1].Cells[0].Value = "AI";
            this.dataGridView_dbGate.Rows[2].Cells[0].Value = "BI";
            this.dataGridView_dbGate.Rows[3].Cells[0].Value = "CI";
        }

        private void FormGateInfo_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            MultiLanguage.getNames(this);
        }


        public void updateGateInfo(float[] GateTof, float[] GateAmp)
        {
            for (int row = 0; row < 4; row++)
            {
                this.dataGridView_sgGate.Rows[row].Cells[1].Value = Math.Round( GateAmp[row]*100 , 2);
                this.dataGridView_sgGate.Rows[row].Cells[2].Value = Math.Round(GateTof[row], 2 );
            }

            //
            
            double BAtof = Math.Round(System.Math.Abs(GateTof[B] - GateTof[A]), 2);
            double BAamp=System.Math.Round(Math.Log10(GateAmp[B] / GateAmp[A]) * 20,2);
            this.dataGridView_dbGate.Rows[0].Cells[1].Value = BAamp;
            this.dataGridView_dbGate.Rows[0].Cells[2].Value = BAtof;

            for (int i = 1; i <=3 ; i++)
            {
                double tof = Math.Round(System.Math.Abs(GateTof[I] - GateTof[i]), 2);
                double amp = System.Math.Round(Math.Log10(GateAmp[i] / GateAmp[I]) * 20,2);
                this.dataGridView_dbGate.Rows[i].Cells[1].Value =amp;
                this.dataGridView_dbGate.Rows[i].Cells[2].Value = tof;
            }


        }


    }
}
