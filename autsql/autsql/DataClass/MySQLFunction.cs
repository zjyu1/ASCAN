using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;


namespace autsql.DataClass
{
    class MySQLFunction
    {
        public static string batch_tbl = "batch_tbl";
        public static string record_tbl = "record_tbl";
        public static string order_tbl = "order_tbl";
        public static BatchInfo BatchInfoB = new BatchInfo();
        public static bool addfin;
        private const long BUFFER_SIZE = 20480;
      

        public static string GetDateSize()
        {
        //    string Conn = "Database='information_schema';Data Source='localhost';User Id='root';Password='12345';charset='utf8';pooling=true";
            string Conn = "Database='information_schema';Data Source='192.168.1.236';User Id='root';Password='12345';charset='utf8';pooling=true";
            string sql = "select concat(round(sum(data_length/1024/1024),3),'MB') as size from tables where table_schema='test'";
            MySqlDataReader sdr = DataClass.MySqlHelper.ExecuteReader(Conn, CommandType.Text, sql, null);
            sdr.Read();
            return sdr[0].ToString();
        }
        //数据库备份
        public static void MySQLdump(string textOrder)
        {
            string IP = "192.168.1.236";
         //   string IP = "localhost";
            string sqlAddress = " -h " + IP + " -u root -p  test ";
           
      
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "数据库文件|*.sql";
                sfd.FilterIndex = 0;
                sfd.RestoreDirectory = true;
                sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmm") + textOrder.ToString() + ".sql";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    string cmd = "mysqldump  " + sqlAddress  + " > \"" + filePath + "\"";
                    string result = RunCmd(cmd);
                    if (result.Trim() == "")
                    {
                        MessageBox.Show("数据库备份成功!", "提示", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show(result, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

        }

        //数据库的还原
        // 还原数据库
        public static void MySQLImport(string filePath)
        {
            string IP = "192.168.1.236";
            //string IP = "localhost";
            string sqlAddress = " -h " + IP + " -u root -p  test ";
            if (filePath == "")
            {
                MessageBox.Show("请选择要恢复的文件!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //this.GetExecute(G_Con, "create database if not exists clothes");
            string cmd = "mysql " + sqlAddress + " < \"" + filePath + "\"";
            string result = RunCmd(cmd);
            if (result.Trim() == "")
            {
                MessageBox.Show("数据库恢复成功!", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(result, "提示", MessageBoxButtons.OK);
            }
        }

        // 命令行操作
        private static string RunCmd(string command)
        {
            //例Process
            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe";           //确定程序名
            p.StartInfo.Arguments = "/c " + command;    //确定程式命令行
            p.StartInfo.UseShellExecute = false;        //Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向输入
            p.StartInfo.RedirectStandardOutput = true; //重定向输出
            p.StartInfo.RedirectStandardError = true;   //重定向输出错误
            p.StartInfo.CreateNoWindow = false;          //设置置不显示示窗口
            p.Start();   //00
             
            p.StandardInput.WriteLine(command);       //也可以用这种方式输入入要行的命令

            p.StandardInput.WriteLine("exit");        //要得加上Exit要不然下一行程式
            //p.WaitForExit();
            //p.Close();
            //return p.StandardOutput.ReadToEnd();        //输出出流取得命令行结果果
            return p.StandardError.ReadToEnd();
        }

        //打开订单表
        public static void LoadOrderData()//without output, just for test?
        {
            MySqlConnection connection = new MySqlConnection(DataClass.MySqlHelper.Conn);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from order_tbl";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
            }
            catch(Exception e)
            {
                //throw;
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

        }

        //查询数据表，读取一个批次号下的多条记录，写到recordInfo类，添加到list<recordInfo>
        public static List<RecordInfo> ReadRecordData(string batchName)
        {
            List<RecordInfo> recordList = new List<RecordInfo>();
            string CommandText = "select * from  " + record_tbl + " where 批次名 =" + "'" + batchName + "'"; //select all mates columns  

            DataSet ds = new DataSet();

            ds = DataClass.MySqlHelper.GetDataSet(DataClass.MySqlHelper.Conn, CommandType.Text, CommandText, null);
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RecordInfo ri = new RecordInfo();

                ri.batchName = Convert.ToString(dt.Rows[i]["批次名"]);
                ri.weldNo = Convert.ToInt32(dt.Rows[i]["焊缝号"]);

                ri.num = Convert.ToInt32(dt.Rows[i]["检测次数"]);
                ri.fileFullPath = Convert.ToString(dt.Rows[i]["数据"]);
                ri.result = Convert.ToString(dt.Rows[i]["检测结果"]);
                ri.dt = dataType.orig;
                recordList.Add(ri);

            }

            return recordList;

        }

        static public object SqlNull(object obj)
        {
            if (obj == null)
                return DBNull.Value;

            return obj;
        }


        //查询批次表，读取同一订单号下的多个批次记录，写到batchInfo类，添加到list<batchInfo>
        public static List<BatchInfo> ReadBatchData(string orderName)
        {

            string CommandText = "select * from  batch_tbl where 订单号=" + "'" + orderName + "'";

            List<BatchInfo> batchList = new List<BatchInfo>();

            DataSet ds = new DataSet();

            ds = DataClass.MySqlHelper.GetDataSet(DataClass.MySqlHelper.Conn, CommandType.Text, CommandText, null);
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BatchInfo bi = new BatchInfo();
                bi.dt = dataType.orig;
                bi.name = Convert.ToString(dt.Rows[i]["批次名"]);
                bi.orderName = Convert.ToString(dt.Rows[i]["订单号"]);
                bi.endDateTime = Convert.ToString(dt.Rows[i]["终止日期"]);
                bi.startDateTime = Convert.ToString(dt.Rows[i]["起始日期"]);
                bi.productTypeFullPath = Convert.ToString(dt.Rows[i]["产品类型"]);
                bi.testingSetUpFullPatch = Convert.ToString(dt.Rows[i]["检测模式"]);
                bi.nbDetected = Convert.ToInt32(dt.Rows[i]["检测数量"]);
                bi.nbGood = Convert.ToInt32(dt.Rows[i]["合格数量"]);
                bi.nbFail = Convert.ToInt32(dt.Rows[i]["不合格数量"]);
                bi.operatorId = Convert.ToString(dt.Rows[i]["操作员工号"]);
                bi.operatorName = Convert.ToString(dt.Rows[i]["操作员"]);
                bi.custormerName = Convert.ToString(dt.Rows[i]["客户名称"]);
                bi.fileNum = Convert.ToString(dt.Rows[i]["文件数量"]);
                bi.heatProcess = Convert.ToString(dt.Rows[i]["热处理"]);
                bi.grade = Convert.ToString(dt.Rows[i]["等级"]);
                bi.nuanceOfSteel = Convert.ToString(dt.Rows[i]["材料"]);
                bi.dim = Convert.ToString(dt.Rows[i]["产品尺寸"]);
                bi.area = Convert.ToString(dt.Rows[i]["厂区"]);
                bi.controlSpec = Convert.ToString(dt.Rows[i]["规范"]);

                bi.recordList = ReadRecordData(bi.name);

                batchList.Add(bi);


            }
            return batchList;

        }

        public static List<OderInfo> ReadOrderData(string orderName)
        {
            OderInfo orderData = new OderInfo();

            string sqlorder = "select * from order_tbl where 订单号= " + "'" + orderName + "'";

            // 从订单表、批次表、记录表中取出数据
            DataSet ds = new DataSet();
            ds = DataClass.MySqlHelper.GetDataSet(DataClass.MySqlHelper.Conn, CommandType.Text, sqlorder, null);
            DataTable dtorder = ds.Tables[0];

            List<OderInfo> orderList = new List<OderInfo>();//gai

            for (int i = 0; i < dtorder.Rows.Count; i++)
            {
                OderInfo oi = new OderInfo();

                oi.name = Convert.ToString(dtorder.Rows[i]["订单号"]);
                oi.date = Convert.ToString(dtorder.Rows[i]["订单时间"]);
                //     oi.batchName = Convert.ToString(dtorder.Rows[i]["批次名"]);               

                oi.batchList = ReadBatchData(oi.name);

                orderList.Add(oi);

            }

            return orderList;

        }

        //将list<ASCAN.BATchList>写入batch_tbl
        public static void AddListToBatchtbl(List<BatchInfo> bdLst)
        {

            for (int i = 0; i < bdLst.Count; i++)
            {
                MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                switch (bdLst[i].dt)
                {
                    case dataType.orig:
                        AddListToRecordtbl(bdLst[i]);
                        break;

                    case dataType.del:
                        cmd.CommandText = " delete  from " + batch_tbl + "where 批次名 ＝" + "'" + bdLst[i].name + "'";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = " delete  from " + record_tbl + "where 批次名 ＝" + "'" + bdLst[i].name + "'";
                        cmd.ExecuteNonQuery();
                        break;
                    case dataType.modify:
                        cmd.CommandText = "update  " + batch_tbl + "  set 合格数量=@nbgood,不合格数量=@nbFail,产品类型=@product,检测模式=@setup  where 批次名 =" + "'" + bdLst[i].name + "'";

                        cmd.Parameters.AddWithValue("@nbgood", bdLst[i].nbGood);
                        cmd.Parameters.AddWithValue("@nbFail", bdLst[i].nbFail);
                        cmd.Parameters.AddWithValue("@product", bdLst[i].productTypeFullPath);
                        cmd.Parameters.AddWithValue("@setup", bdLst[i].testingSetUpFullPatch);

                        cmd.ExecuteNonQuery();
                        AddListToRecordtbl(bdLst[i]);
                        break;
                }

                conn.Close();

            }



        }

        //list添加数据到brecord表
        public static int AddListToRecordtbl(BatchInfo baf)
        {
            int res = 0;
            List<RecordInfo> rdLst = baf.recordList;
            for (int i = 0; i < rdLst.Count; i++)
            {
                MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                switch (rdLst[i].dt)
                {
                    case dataType.orig: break;
                    case dataType.add:
                        cmd.CommandText = "INSERT INTO " + record_tbl + " (批次名,焊缝号,检测次数,检测结果,数据 )values (@batch_No,@weldNo,@num,@results,@data)";
                        cmd.Parameters.AddWithValue("@batch_No", rdLst[i].batchName);
                        cmd.Parameters.AddWithValue("@weldNo", rdLst[i].weldNo);
                        cmd.Parameters.AddWithValue("@num", rdLst[i].num);
                        cmd.Parameters.AddWithValue("@results", rdLst[i].result);
                        cmd.Parameters.AddWithValue("@data", rdLst[i].fileFullPath);
                        res += cmd.ExecuteNonQuery();
                        break;
                    case dataType.del:
                        cmd.CommandText = " delete  from " + record_tbl + " where  检测结果=" + "'" + rdLst[i].result + "'" + " and 焊缝号=" + rdLst[i].weldNo;
                        res += cmd.ExecuteNonQuery();
                        break;
                    case dataType.modify:

                        string CommandText = "select * from " + record_tbl + "  where 批次名=" + "'" + rdLst[i].batchName + "'";

                        DataSet ds = new DataSet();

                        ds = DataClass.MySqlHelper.GetDataSet(DataClass.MySqlHelper.Conn, CommandType.Text, CommandText, null);
                        DataTable dt = ds.Tables[0];

                        cmd.CommandText = "update  " + record_tbl + "  set  检测结果=@results, 数据=@data,焊缝号=@weldNo,检测次数=@num  where  RecordID=" + dt.Rows[i]["RecordID"];

                        ////    rdLst[i].batchName = bi.name;
                        //rdLst[i].weldNo = i + 2;
                        //rdLst[i].num = i + 11;
                        //rdLst[i].result = "ok";
                        //rdLst[i].fileFullPath = "d:\test";

                        cmd.Parameters.AddWithValue("@results", rdLst[i].result);
                        cmd.Parameters.AddWithValue("@weldNo", rdLst[i].weldNo);
                        cmd.Parameters.AddWithValue("@num", rdLst[i].num);
                        cmd.Parameters.AddWithValue("@data", rdLst[i].fileFullPath);


                        res += cmd.ExecuteNonQuery();
                        break;
                }
                conn.Close();

            }
            return res;

        }

        public static void SaveDataToRecord(string batchname)
        {
            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            // cmd.CommandText = "INSERT INTO " + record_tbl + " (批次名,检测结果,数据 )values (@batch_No,@results,@data)";
            cmd.CommandText = "INSERT INTO " + record_tbl + " (批次名,焊缝号,检测次数)values (@batch_No,@weldNo,@num)";

            int weldNo = 0; int num = 0; 
            cmd.Parameters.AddWithValue("@batch_No", DataClass.MySQLFunction.SqlNull(batchname));
            cmd.Parameters.AddWithValue("@weldNo", weldNo);
            cmd.Parameters.AddWithValue("@num", num);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //新建订单，向订单表中增加数据
        public static bool AddDataToOrder(string order_name)
        {
            DateTime order_date = new DateTime();
            order_date = System.DateTime.Now;

            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            //judge is existed
            cmd.CommandText = "select  count(*)  from order_tbl  where 订单号 = " + "'" + order_name + "'";
            int num = Convert.ToInt16(cmd.ExecuteScalar());
            if (num > 0)
            {
                MessageBox.Show("订单号已存在，请重新输入！");
                return false;
            }
            else
            {
                cmd.CommandText = "INSERT INTO order_tbl(订单号,订单时间)values (@order_Name,@order_Date)";
                cmd.Parameters.AddWithValue("@order_Name", order_name);
                cmd.Parameters.AddWithValue("@order_Date", order_date);
                try
                {
                    cmd.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conn.Close();
                return true;
            }
        }

        //新建订单表若不存在
        public static void CreateOrderTable()
        {
            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            string sql = "CREATE TABLE If Not Exists  " + DataClass.MySQLFunction.order_tbl +
                        "(orderID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 订单号 VARCHAR(100),订单时间 datetime   )";
            DataClass.MySqlHelper.ExecuteNonQuery(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);
            conn.Close();

        }

        //建批次表 
        public static void CreateBacthTable()
        {
            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            string sql = "CREATE TABLE if Not Exists " + batch_tbl +
                  "(BatchId INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 批次名 VARCHAR(255), 订单号 VARCHAR(255),起始日期 datetime,终止日期 datetime,产品类型 VARCHAR(255),检测模式 varCHAR(255),检测数量 int," +
                  "客户名称 varCHAR(255),文件数量 varCHAR(255),热处理 varCHAR(255),等级 varCHAR(255),材料 VARCHAR(255),产品尺寸 VARCHAR(255),厂区 VARCHAR(255),规范 VARCHAR(255),"
                  + "操作员 VARCHAR(255),操作员工号  VARCHAR(255),合格数量 INT,不合格数量 INT )";

            DataClass.MySqlHelper.ExecuteNonQuery(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);
            conn.Close();

        }

        public static void Createdatabase()
        {
            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId='root'; PWD='12345';;charset='utf8';pooling=true;");
            MySqlCommand cmd = new MySqlCommand("CREATE DATABASE if not exists test;", conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //向批次表中增加数据
        public static void AddDataToBatchTable()
        {
            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            //批次名 VARCHAR(50),订单号 起始日期 datetime,终止日期 datetime,规格 VARCHAR(10),产品类型 varchar(50),检测模式 varCHAR(50),检测数量 int," +
            // "客户名称 varCHAR(10),文件数量 varCHAR(10),热处理 varCHAR(10),等级 varCHAR(10),材料 VARCHAR(10),产品尺寸 VARCHAR(10),厂区 VARCHAR(10),规范 VARCHAR(10),"
            // + "操作员 VARCHAR(6),操作员工号  VARCHAR(10),合格数量 INT,不合格数量 INT,已检测数量 INT 
            cmd.CommandText = "INSERT INTO " + batch_tbl + " (订单号,批次名,起始日期,终止日期,产品类型,检测模式 ,检测数量,客户名称,文件数量,热处理,"
         + "等级 ,材料,产品尺寸 ,厂区 ,规范, 操作员,操作员工号,合格数量,不合格数量  )values (@order_name,@batch_No,@startDateTime,@endDateTime,@productTypeFullPath,"
      + "@testingSetupFullPatch,@nbDetected,@customerName,@fileNum,@heatProcess,@grade,@nuanceOfSteel,@dim,@area,@controlSpec,@operator,@operatorId,@nbGood,@nbFail)";

            cmd.Parameters.AddWithValue("@order_name", SqlNull(DataClass.MySQLFunction.BatchInfoB.orderName));
            cmd.Parameters.AddWithValue("@batch_No", SqlNull(DataClass.MySQLFunction.BatchInfoB.name));
            cmd.Parameters.AddWithValue("@startDateTime", Convert.ToDateTime(DataClass.MySQLFunction.BatchInfoB.startDateTime));
            cmd.Parameters.AddWithValue("@endDateTime", Convert.ToDateTime(DataClass.MySQLFunction.BatchInfoB.endDateTime));
            cmd.Parameters.AddWithValue("@productTypeFullPath", SqlNull(DataClass.MySQLFunction.BatchInfoB.productTypeFullPath));
            cmd.Parameters.AddWithValue("@testingSetupFullPatch", SqlNull(DataClass.MySQLFunction.BatchInfoB.testingSetUpFullPatch));

            cmd.Parameters.AddWithValue("@nbDetected", DataClass.MySQLFunction.BatchInfoB.nbDetected);
            cmd.Parameters.AddWithValue("@customerName", SqlNull(DataClass.MySQLFunction.BatchInfoB.custormerName));
            cmd.Parameters.AddWithValue("@fileNum", SqlNull(DataClass.MySQLFunction.BatchInfoB.fileNum));
            cmd.Parameters.AddWithValue("@heatProcess", SqlNull(DataClass.MySQLFunction.BatchInfoB.heatProcess));
            cmd.Parameters.AddWithValue("@grade", SqlNull(DataClass.MySQLFunction.BatchInfoB.grade));
            cmd.Parameters.AddWithValue("@nuanceOfSteel", SqlNull(DataClass.MySQLFunction.BatchInfoB.nuanceOfSteel));
            cmd.Parameters.AddWithValue("@dim", SqlNull(DataClass.MySQLFunction.BatchInfoB.dim));
            cmd.Parameters.AddWithValue("@area", SqlNull(DataClass.MySQLFunction.BatchInfoB.area));
            cmd.Parameters.AddWithValue("@controlSpec", SqlNull(DataClass.MySQLFunction.BatchInfoB.controlSpec));
            cmd.Parameters.AddWithValue("@operator", SqlNull(DataClass.MySQLFunction.BatchInfoB.operatorName));
            cmd.Parameters.AddWithValue("@operatorId", SqlNull(DataClass.MySQLFunction.BatchInfoB.operatorId));

            cmd.Parameters.AddWithValue("@nbGood", SqlNull(DataClass.MySQLFunction.BatchInfoB.nbGood));
            cmd.Parameters.AddWithValue("@nbFail", SqlNull(DataClass.MySQLFunction.BatchInfoB.nbFail));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }

        //新建记录表
        public static void CreateRecordTable()
        {

            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            string sql = "CREATE TABLE If Not Exists  " + DataClass.MySQLFunction.record_tbl +
                        "(RecordID INT NOT NULL AUTO_INCREMENT PRIMARY KEY, 批次名 VARCHAR(255),焊缝号 int,检测次数 int ,检测结果 VARCHAR(255),数据 varCHAR(255)  )";
            DataClass.MySqlHelper.ExecuteNonQuery(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);
            conn.Close();

        }

        //批次号写写入订单表
        public static void SaveBatchToOrder(string order_name, string batch_no)
        {
            MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from order_tbl where 订单号 = " + "'" + order_name + "'" + " and 批次名 is null";


            int s = Convert.ToInt32(cmd.ExecuteScalar());
            if (s > 0)
            {
                cmd.CommandText = "update  order_tbl  set   批次名  = " + "'" + batch_no + "'" + " where 订单号 = " + "'" + order_name + "'" + "  and  批次名 is null";
                cmd.ExecuteNonQuery();
            }
            else
            {
                DateTime dt = Convert.ToDateTime(System.DateTime.Now.ToLongDateString().ToString());
                cmd.CommandText = "INSERT INTO order_tbl  (订单号,订单时间,批次名) values (@order_name,@order_date,@batch_no)";
                cmd.Parameters.AddWithValue("@order_name", order_name);
                cmd.Parameters.AddWithValue("@batch_no", batch_no);

                cmd.Parameters.AddWithValue("@order_date", System.DateTime.Now.ToString());


                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        //绑定 数据表中的数据到mainFRM的datagrid。
        public static DataSet BindDatagridView(string tableName)
        {
            DataSet ds = new DataSet();
            string sql = "select * from " + tableName;
            ds = DataClass.MySqlHelper.GetDataSet(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);
            return ds;

        }
        //绑定同一个订单号下面数据到mainFRM的datagrid。
        public static DataSet BindData(string orderName)
        {
            DataSet ds = new DataSet();
            string sql = "select * from  " + batch_tbl + " where 订单号 = " + "'" + orderName + "'";
            ds = DataClass.MySqlHelper.GetDataSet(DataClass.MySqlHelper.Conn, CommandType.Text, sql, null);
            return ds;
        }

        //删除批次表中的当前订单号下的批次数据，以及record表中相关批次下所有的数据

        public static void DelDatafromtbl(string order_name)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(DataClass.MySqlHelper.Conn);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select  count(*)  from " + batch_tbl + "  where 订单号 = " + "'" + order_name + "'";
                int num = Convert.ToInt16(cmd.ExecuteScalar());
                if (num > 0)
                {
                    string CommandText = "select * from  batch_tbl where 订单号=" + "'" + order_name + "'";

                    DataSet ds = new DataSet();

                    ds = DataClass.MySqlHelper.GetDataSet(DataClass.MySqlHelper.Conn, CommandType.Text, CommandText, null);
                    DataTable dt = ds.Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cmd.CommandText = "delete  from  " + record_tbl + "  where 批次名=" + "'" + dt.Rows[i]["批次名"] + "'";
                        cmd.ExecuteNonQuery();

                    }

                    cmd.CommandText = "delete  from " + batch_tbl + " where 订单号=" + "'" + order_name + "'";
                    cmd.ExecuteNonQuery();

                }

                conn.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        //修改数据库中的数据
        public static void ModifySqldata(string fieldName, int batchId, string desValue)
        {
            if ((fieldName == "起始日期") || (fieldName == "终止日期"))

            {
                MessageBox.Show("日期不能修改");
            }
            else
            {
                string des= desValue;
                if ((fieldName == "产品类型") || (fieldName == "检测模式"))
                {
                     des = @desValue ;
                }

                
                try
                {
                    MySqlConnection connection = new MySqlConnection(DataClass.MySqlHelper.Conn);
                    connection.Open();

                    MySqlCommand cmd = connection.CreateCommand();

                    cmd.CommandText = "update  " + DataClass.MySQLFunction.batch_tbl + " set " + fieldName + "=" + "'"+ des + "'"  + " where BatchId=" + batchId;
                    int s = cmd.ExecuteNonQuery();

                    if (s != 0)
                    {
                        MessageBox.Show("成功修改选中行数据！");
                    }
                    connection.Close();
                }
                catch (Exception err)
                {
                    //throw;
                    MessageBox.Show(err.Message);
                }
            }
        }
        public static void createZip(string sourcePath, string desPath)
        {
            Queue<FileSystemInfo> Folders = new Queue<FileSystemInfo>(new DirectoryInfo(sourcePath).GetFileSystemInfos());
            desPath = (desPath.LastIndexOf(Path.DirectorySeparatorChar) == desPath.Length - 1) ? desPath : desPath + Path.DirectorySeparatorChar + Path.GetFileName(sourcePath);
            Directory.CreateDirectory(desPath);
            while (Folders.Count > 0)
            {
                FileSystemInfo atom = Folders.Dequeue();
                FileInfo sourceFile = atom as FileInfo;
                if (sourceFile == null)
                {
                    DirectoryInfo directory = atom as DirectoryInfo;
                    Directory.CreateDirectory(directory.FullName.Replace(sourcePath, desPath));
                    foreach (FileSystemInfo nextatom in directory.GetFileSystemInfos())
                        Folders.Enqueue(nextatom);
                }
                else
                {
                    string sourcefilename = sourceFile.FullName;
                    string zipfilename = sourceFile.FullName.Replace(sourcePath, desPath) + ".zip";
                    if (!File.Exists(zipfilename))
                    {
                        FileStream sourceStream = null;
                        FileStream destinationStream = null;
                        GZipStream compressedStream = null;
                        try
                        {
                            // Read the bytes from the source file into a byte array
                            sourceStream = new FileStream(sourcefilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                            // Open the FileStream to write to
                            destinationStream = new FileStream(zipfilename, FileMode.OpenOrCreate, FileAccess.Write);
                            // Create a compression stream pointing to the destiantion stream
                            compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true);
                            long bufferSize = sourceStream.Length < BUFFER_SIZE ? sourceStream.Length : BUFFER_SIZE;
                            byte[] buffer = new byte[bufferSize];
                            int bytesRead = 0;
                            long bytesWritten = 0;
                            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                compressedStream.Write(buffer, 0, bytesRead);
                                bytesWritten += bufferSize;
                            }
                        }
                        catch (ApplicationException)
                        {
                            continue;
                        }
                        finally
                        {
                            // Make sure we allways close all streams
                            if (sourceStream != null) sourceStream.Close();
                            if (compressedStream != null) compressedStream.Close();
                            if (destinationStream != null) destinationStream.Close();
                        }
                    }

                }
            }

        }

    }
}
