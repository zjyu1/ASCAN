using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace autsql
{
    public partial class FrmOpOrder : Form
    {
        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        
        
        public FrmOpOrder()
        {
            InitializeComponent();
        }

        private void FrmOpOrder_Load(object sender, EventArgs e)
        {
            listOrder.Items.Clear();
           // string sql = "show tables";

            string sql = "select 订单号 from    "+DataClass.MySQLFunction.order_tbl;
            try

            {
                MySqlDataReader sdr = DataClass.MySqlHelper.ExecuteReader(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);

                while (sdr.Read())
                {
                    listOrder.Items.Add(sdr[0].ToString());
                }
            }
            catch (Exception err)
            {
                
                MessageBox.Show(err.Message);
                               

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要打开的订单");
            }
            else
            {
                flag = listOrder.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "数据库文件|*.sql";
                ofd.FilterIndex = 0;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   DataClass.MySQLFunction.MySQLImport(ofd.FileName);
                }

            }
            listOrder.Items.Clear();
            string sql = "select 订单号 from    " + DataClass.MySQLFunction.order_tbl;
            MySqlDataReader sdr = DataClass.MySqlHelper.ExecuteReader(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);
            while (sdr.Read())
            {
                listOrder.Items.Add(sdr[0].ToString());
            } 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            listOrder.Items.Clear();
             string sql = "show tables";
           // string sql = "select 订单号 from  order_tbl  ";
            MySqlDataReader sdr = DataClass.MySqlHelper.ExecuteReader(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);
            while (sdr.Read())
            {
                listOrder.Items.Add(sdr[0].ToString());
            }
        }
    }
}
