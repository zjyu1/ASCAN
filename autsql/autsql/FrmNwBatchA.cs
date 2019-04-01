using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace autsql
{
    public partial class FrmNwBatchA : Form
    {

        public FrmNwBatchA()
        {
            InitializeComponent();

        }
        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private void FrmNwBatchA_Load(object sender, EventArgs e)
        {
            ClassBatch nwbatch = new ClassBatch();
        }

      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            FrmNwBatchB frnbb = new FrmNwBatchB();
            frnbb.Show();
        }

        private void dataStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btncontinue(object sender, EventArgs e)
        {
            if (textNum.Text == "")
            {
                MessageBox.Show("请输入产品数量!");
            }
            else
                DataClass.MySQLFunction.BatchInfoB.nbDetected = Convert.ToInt32(textNum.Text);//产品数量

            if (txb_batchName.Text == "")
                MessageBox.Show("请输入批次名！");
            else
            {
                MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select  count(*)  from  batch_tbl   where 批次名 = " +"'"+ txb_batchName.Text.Trim()+"'";
                int num = Convert.ToInt16(cmd.ExecuteScalar());
                if (num > 0)
                {
                    MessageBox.Show("批次号已存在，请重新输入！");

                }
                else

                {
                    DataClass.MySQLFunction.BatchInfoB.orderName = this.Flag; //订单号
                    DataClass.MySQLFunction.BatchInfoB.name = txb_batchName.Text;// 批号名
                    DataClass.MySQLFunction.BatchInfoB.startDateTime = dateStart.Value.ToString("yyyy-MM-dd HH:mm:ss"); //开始日期
                    DataClass.MySQLFunction.BatchInfoB.endDateTime = dateStop.Value.ToString("yyyy-MM-dd HH:mm:ss");//结束日期



                    if ((textNum.Text != "") && (txb_batchName.Text != ""))

                    {
                        FrmNwBatchC frnbc = new FrmNwBatchC();
                        frnbc.Flag = this.Flag;
                        frnbc.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void textNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Isdigit 作用是判断输入按键是否为数字
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }

            }
            if (!char.IsDigit(e.KeyChar))
                MessageBox.Show("请输入数字！");
        }

        private void textNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmNwBatchA_Shown(object sender, EventArgs e)
        {
           
        }

        private void txb_batchName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
