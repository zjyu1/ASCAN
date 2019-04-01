using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace autsql.DataClass
{
    class MyMeans   
    {
        #region MyRegion
            public static SqlConnection My_con;
            public static string M_str_sqlcon = "server=DESKTOP-2EHD0HH\\SQLEXPRESS;database=ME;UID=sa;PWD=123";
        #endregion

        public static SqlConnection getcon()        //建立与数据库的连接
        {
                My_con = new SqlConnection(M_str_sqlcon);
                My_con.Open();
                return My_con;
        }

        public static void con_close()     //关闭与数据库的连接
        {
            if(My_con.State == ConnectionState.Open)
            {
                My_con.Close();
                My_con.Dispose();
            }
        }

        //SQLstr传递的是SQL语句
        public static SqlDataReader getcom(string SQLstr)      //用SqlDataReader对象只读数据库的信息
        {
            getcon();
            SqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            SqlDataReader My_read = My_com.ExecuteReader();
            return My_read;
        }
        public static void getsqlcom(string SQLstr)    //通过SqlCommand对象执行数据库的操作    
        {
            getcon();
            SqlCommand SQLcom = new SqlCommand(SQLstr,My_con);
            SQLcom.ExecuteNonQuery();//执行SQL
            SQLcom.Dispose();//释放空间
            con_close();
        }
        public static DataSet getDataSet(string SQLstr, string tableName)  //通过或SqlDataAdapter对象执行数据库的操作
        {
            getcon ();
            SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet,tableName);
            con_close();
            return My_DataSet;
        }

    }
}
