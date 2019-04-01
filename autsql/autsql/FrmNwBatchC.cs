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
    public partial class FrmNwBatchC : Form
    {
        public FrmNwBatchC()
        {
            InitializeComponent();

        }
        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        // 向数据库中插入null值
        static public object SqlNull(object obj)
        {
            if (obj == null)
                return DBNull.Value;

            return obj;
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            // this.DialogResult = DialogResult.OK;        

            DataClass.MySQLFunction.BatchInfoB.productTypeFullPath = BoxType.Text;
            DataClass.MySQLFunction.BatchInfoB.testingSetUpFullPatch = BoxSetup.Text;

            //向批次表中增加记录
            
            DataClass.MySQLFunction.AddDataToBatchTable();
                
            //向记录表中，写入批次名
            //    DataClass.MySQLFunction.SaveDataToRecord(DataClass.MySQLFunction.BatchInfoB.name);
            //  
            DataClass.MySQLFunction.addfin = true;
            this.Close();
           
            }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void benBack_Click(object sender, EventArgs e)
        {
            FrmNwBatchA fnba = new FrmNwBatchA();
            fnba.Show();
            this.Hide();
            
        }
    }
}
