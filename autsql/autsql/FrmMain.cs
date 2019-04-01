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
    public partial class FrmMain : Form
    {
        
        public FrmMain()
        {             
            InitializeComponent();  
        }
        public OderInfo od = new OderInfo();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               
                MySqlConnection mycon = new MySqlConnection(DataClass.MySqlHelper.Conn);
                mycon.Open();
                MessageBox.Show("数据库已打开！");
            }
            catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message );
            }

                     
        }

        private void btnNwOrder_Click(object sender, EventArgs e)
        {
            FrmNwOrder frmno = new FrmNwOrder();
            frmno.Flag = textOrder.Text ;
            
            if (frmno.ShowDialog() == DialogResult.OK)
            {
                textOrder.Text = frmno.Flag;

                DataSet ds = new DataSet();
                ds = DataClass.MySQLFunction.BindData(textOrder.Text.Trim());
                
                dataBatch.DataSource = ds.Tables[0];
                dataBatch.RowHeadersVisible = false;
               
                dataBatch.Columns[0].ReadOnly = true;
                textSize.Text = DataClass.MySQLFunction.GetDateSize();
            }
            
           
        }
        private void btnOpOrder_Click(object sender, EventArgs e)
        {

            FrmOpOrder frmoo = new FrmOpOrder();
            List<OderInfo> lst = new List<OderInfo>();
          
            if (frmoo.ShowDialog() == DialogResult.OK)
            {
                textOrder.Text = frmoo.Flag;
                try
                {
                    
                    dataBatch.DataSource = DataClass.MySQLFunction.BindData(textOrder.Text.Trim()).Tables[0];
                    lst = DataClass.MySQLFunction.ReadOrderData(textOrder.Text);
                    //多条记录
                    this.od = lst[0];
                    od.isLoad = true;
                    textSize.Text = DataClass.MySQLFunction.GetDateSize();
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
           
            

            
        }

        private void btnDelOrder_Click(object sender, EventArgs e)
        {
            if (textOrder.Text != "")
            {
                DialogResult isDel = MessageBox.Show("确定要将订单:" + textOrder.Text + "已经这个订单下面所有的批次检测记录均删除？", "提示", MessageBoxButtons.YesNo);
                if (isDel == DialogResult.Yes)
                {
                    try
                    {
                        string sql = "delete from " + DataClass.MySQLFunction.order_tbl + " where  订单号=" + "'" + textOrder.Text.Trim() + "'";

                        DataClass.MySqlHelper.ExecuteNonQuery(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);

                        DataClass.MySQLFunction.DelDatafromtbl(textOrder.Text.Trim());

                        dataBatch.DataSource = null;
                        textOrder.Clear();
                        textSize.Text = DataClass.MySQLFunction.GetDateSize();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }
        }

        private void btnPakOrder_Click(object sender, EventArgs e)
        {
           
            if (textOrder.Text != "")
            {
                //string srcPath, desPath;
                string DBname = "test";
                DataClass.MySQLFunction.MySQLdump(DBname);
               //MessageBox.Show("请选择需要备份的检测文件所在目录！");

               // FolderBrowserDialog sfd = new FolderBrowserDialog();
                
               //     if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               //     {
               //         srcPath = sfd.SelectedPath;

               //     }
                
               // MessageBox.Show("请选择需要将检测文件备份的文件路径！");
               // SaveFileDialog sfd2 = new SaveFileDialog();
                                
               //    if (sfd2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               //     {
               //         desPath = sfd2.FileName;
                       
               //     }
               // DataClass.MySQLFunction.createZip(srcPath, desPath);


            }
            else
            {
                MessageBox.Show("请打开你要打包的数据库！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataClass.MySQLFunction.Createdatabase();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Application.Exit();
             this.Hide(); 
        }
          
        private void btnNwBatch_Click(object sender, EventArgs e)
        {
         
            FrmNwBatchA frnba = new FrmNwBatchA();
            frnba.Flag = textOrder.Text.Trim();
           
            frnba.Show();            
         }
    
        private void btnEdBatch_Click(object sender, EventArgs e)
        {
            

            
        }

        private void btnDelBatch_Click(object sender, EventArgs e)
        {
           
            DialogResult RSS = MessageBox.Show(this, "确定要删除选中的行数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    for (int i = this.dataBatch.SelectedRows.Count; i > 0; i--)
                    {
                        int batchID = Convert.ToInt32(dataBatch.SelectedRows[i - 1].Cells[0].Value);
                        string batchName = Convert.ToString(dataBatch.SelectedRows[i - 1].Cells[1].Value);
                        dataBatch.Rows.RemoveAt(dataBatch.SelectedRows[i - 1].Index);
                        //使用获得ID删除数据库的数据
                        try
                        {
                            MySqlConnection connection = new MySqlConnection(DataClass.MySqlHelper.Conn);
                            connection.Open();


                            MySqlCommand cmd = connection.CreateCommand();
                            cmd.CommandText = "delete from " + DataClass.MySQLFunction.batch_tbl + " where batchId="+ batchID;
                            int s = cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from " + DataClass.MySQLFunction.record_tbl + " where 批次名=" +"'"+ batchName+"'";
                            cmd.ExecuteNonQuery();

                            connection.Close();

                            if (s != 0)
                            {
                                MessageBox.Show("成功删除选中行数据！");
                            }
                        }
                        catch
                        { throw; }
                    }
                    break;
                case DialogResult.No:
                    break;


            }
            
        }
           
        private void dataBatch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            DialogResult RSS = MessageBox.Show(this, "确定要对数据进行修改吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (RSS)
            {
                case DialogResult.Yes:
                    {
                        int batchID = 0;
                        try
                        { batchID = Convert.ToInt32(dataBatch.Rows[e.RowIndex].Cells[0].Value.ToString().Trim()); }
                        catch (Exception er)
                        {
                            MessageBox.Show("不要选择空白数据，请重新选择"+er.Message);
                            
                        }
                       
                        string fieldName = dataBatch.Columns[dataBatch.CurrentCell.ColumnIndex].HeaderText;


                        string value = this.dataBatch.CurrentCell.Value.ToString().Trim();

                        //使用获得ID修改数据库的数据
                        DataClass.MySQLFunction.ModifySqldata(fieldName, batchID, value);
                        }
                    break;
                case DialogResult.No:
                    break;
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sourcePath = @"c:\test";
            string desPath = @"c:\des";
            DataClass.MySQLFunction.createZip(sourcePath, desPath);
        }

        public void SaveDataToRecord(string record_tbl)
        {
            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            // cmd.CommandText = "INSERT INTO " + record_tbl + " (批次名,检测结果,数据 )values (@batch_No,@results,@data)";
            cmd.CommandText = "INSERT INTO " + record_tbl + " (批次名 )values (@batch_No)";

            //   string batchname =record_tbl.Substring(0,record_tbl.IndexOf('_'));
            string batchname = "123";
            cmd.Parameters.AddWithValue("@batch_No", DataClass.MySQLFunction.SqlNull(batchname));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOptbl_Click(object sender, EventArgs e)
        {
            FrmOpOrder frmoo = new FrmOpOrder();
            //  frmoo.Flag = textOrder.Text;
            if (frmoo.ShowDialog() == DialogResult.OK)
            {
                textOrder.Text = frmoo.Flag;

                // DataClass.MySQLFunction.BindDatagridView(textOrder.Text.Trim());
                dataBatch.DataSource = DataClass.MySQLFunction.BindDatagridView(textOrder.Text.Trim()).Tables[0];
               
            }
            textSize.Text = DataClass.MySQLFunction.GetDateSize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //将batchlist第2个批次名 下增加record记录
            try
            {
                BatchInfo bi = od.batchList[1];
                od.batchList[1].dt = dataType.modify;
                od.batchList[1].productTypeFullPath = "002";
                od.batchList[1].testingSetUpFullPatch = @"d:\test";
                for (int i = 0; i < bi.recordList.Count; i++)
                {
                    bi.recordList[i].dt = dataType.add;
                    bi.recordList[i].batchName = bi.name;
                    bi.recordList[i].weldNo = i + 1;
                    bi.recordList[i].num = i + 10;
                    bi.recordList[i].result = "ok";
                    bi.recordList[i].fileFullPath = @"d:\test";
                    OderInfo.ReSync(od);
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
          

        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            if (DataClass.MySQLFunction.addfin==true)
            {
                if (textOrder.Text != "")
                {
                    DataSet ds = new DataSet();
                    ds = DataClass.MySQLFunction.BindData(textOrder.Text.Trim());
                    dataBatch.DataSource = ds.Tables[0];

                }
                DataClass.MySQLFunction.addfin = false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textOrder.Text != "")
            {
                DialogResult isDel = MessageBox.Show("确定要将订单:" + textOrder.Text + "已经这个订单下面所有的批次检测记录均删除？", "提示", MessageBoxButtons.YesNo);
                if (isDel == DialogResult.Yes)
                {
                    try
                    {
                        DataClass.MySqlHelper.ExecuteNonQuery(DataClass.MySqlHelper.Conn, CommandType.Text, "DROP TABLE " + textOrder.Text.Trim(), null);
                        dataBatch.DataSource = null;
                        textOrder.Clear();
                        textSize.Text = DataClass.MySQLFunction.GetDateSize();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入你要删除的订单名！");
            }
        }
    }
}


