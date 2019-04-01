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
    public partial class FrmNwBatchB : Form
    {
        public FrmNwBatchB()
        {
            InitializeComponent();
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            //将客户名称、产品尺寸、文件数量、厂区、热处理、规范、等级、操作员、材料写入batchInfoB类
            //  
            DataClass.MySQLFunction.BatchInfoB.custormerName = textCustomer.Text;
            DataClass.MySQLFunction.BatchInfoB.dim = textDimension.Text;
            DataClass.MySQLFunction.BatchInfoB.fileNum = textFileNum.Text;//若输入数字，会有错误吗？
            DataClass.MySQLFunction.BatchInfoB.area = textArea.Text;
            DataClass.MySQLFunction.BatchInfoB.heatProcess = textHeat.Text;
            DataClass.MySQLFunction.BatchInfoB.controlSpec = textSpecification.Text;
            DataClass.MySQLFunction.BatchInfoB.grade = textGrade.Text;
            DataClass.MySQLFunction.BatchInfoB.operatorId = textOpId.Text;
            DataClass.MySQLFunction.BatchInfoB.operatorName = textOperator.Text;
            DataClass.MySQLFunction.BatchInfoB.nuanceOfSteel = textNuance.Text;

                        this.Hide();
        }

        private void textFileNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void textFileNum_KeyPress(object sender, KeyPressEventArgs e)
        {
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
    }
}
