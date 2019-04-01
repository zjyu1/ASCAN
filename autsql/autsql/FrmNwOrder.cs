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
    public partial class FrmNwOrder : Form
    {

        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public FrmNwOrder()
        {
            InitializeComponent();
          
        }
        private void FrmNwOrder_Load(object sender, EventArgs e)
        {
            
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();            
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (textOrder.Text == "")
            {
                MessageBox.Show("请输入订单名！");
            }
            else
            {
                //向订单表中增加新的 订单名称、订单时间、批次名称为空。
                DataClass.MySQLFunction.CreateOrderTable();
                 string order_name = textOrder.Text;
                bool isExists = DataClass.MySQLFunction.AddDataToOrder(order_name);
                
              if(isExists == true)

                {
                    //新建批次表，若表不存在
                    try
                    {
                        DataClass.MySQLFunction.CreateBacthTable();
                        DataClass.MySQLFunction.CreateRecordTable();
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                     flag = this.textOrder.Text ;
                    
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
                   
                
               
            }
        }
    }
}
