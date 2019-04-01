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
    public partial class AddDefectDialog : Form
    {
        FormProduct f;
        int index;

        public AddDefectDialog(FormProduct f ,int index)
        {
            this.index = index;
            this.f = f ;
            InitializeComponent();
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool repeat =false;
            //check name
            if (index > 0)
            {
              for (int j = 0; j < index; j++)
              {    
                    if (txtName.Text == f.defectGrid.Rows[j].Cells[0].Value.ToString())
                    {
                        repeat = true;
                        MessageBox.Show("Name Repetition ", "error");
                        break;
                    }
                }

            }
            if (repeat ==false&&txtName!=null)
            {
                f.defectGrid.Rows[index].Cells["name"].Value = txtName.Text;
                f.defectGrid.Rows[index].Cells["subregion"].Value = txtSubregion.Text;
                f.defectGrid.Rows[index].Cells["type"].Value = txtType.Text;
                f.defectGrid.Rows[index].Cells["beginaxil"].Value = txtBA.Text;
                f.defectGrid.Rows[index].Cells["endaxial"].Value = txtEA.Text;
                f.defectGrid.Rows[index].Cells["beginradio"].Value = txtBR.Text;
                f.defectGrid.Rows[index].Cells["endradio"].Value = txtER.Text;
                this.DialogResult = DialogResult.OK;
            }
            else 
            {
                MessageBox.Show("lack of necessary information or duplication of name ", "ERROR");
                return ;
            }
        }

        private void txtBA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtBA.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtEA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtEA.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtBR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtBR.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }

        private void txtER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            if (Char.IsDigit(e.KeyChar) && ((e.KeyChar & 0xFF) == e.KeyChar))
                return;
            if (e.KeyChar == 46)
            {
                if (txtER.Text.Split('.').Length < 2)
                    return;
            }
            e.Handled = true;
        }


        private void txtBR_TextChanged(object sender, EventArgs e)
        {
            if(txtBR.Text!="")
            {
                double b = double.Parse(txtBR.Text);
                if (b > 360)
                {
                    txtBR.Text = "360";
                }
            }
        }

        private void txtER_TextChanged(object sender, EventArgs e)
        {
            if (txtER.Text != "")
            {
                double b = double.Parse(txtER.Text);
                if (b > 360)
                {
                    txtER.Text = "360";
                }
            }
        }

        private void AddDefectDialog_Load(object sender, EventArgs e)
        {
            MultiLanguage.getNames(this);
        }


    }
}
