using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Hotel.Common;

namespace Hotel.DataAccess
{
    /// <summary>
    /// DB辅助类
    /// </summary>
    public class DBHelper
    {
        /// <summary>
        /// 是否写Log
        /// </summary>
        private bool IsWriteLog = false;
        /// <summary>
        /// 定义连接字符串
        /// </summary>
        private string myConnectionString = string.Empty;

        public DBHelper()
        {
            IsWriteLog = ConfigurationManager.AppSettings["IS_WRITE_SQL"].Trim().ToUpper().Equals("YES") ? true : false;
            myConnectionString = ConfigurationManager.ConnectionStrings["HotelConnection"].ConnectionString;
        }
        public DBHelper(string sConnnStr, bool WriteLog)
        {
            IsWriteLog = WriteLog;
            myConnectionString = sConnnStr;
        }
        /// <summary>
        /// 返回得到DataSet对象
        /// </summary>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sSql)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            DataSet ds = new DataSet();
            using (myConnection)
            {
                if (myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                SqlCommand myCommand = new SqlCommand(sSql, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                da.Fill(ds);
            }
            Log.WriteLog(sSql, IsWriteLog);
            return ds;
        }
        /// <summary>
        /// 执行Inset,Update,Delete,返回影响行数
        /// </summary>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public int ExcuteNonQuery(string sSql)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            using (myConnection)
            {
                if (myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                SqlCommand myCommand = new SqlCommand(sSql, myConnection);
                if (IsWriteLog)
                {
                    Log.WriteLog(sSql);
                }
                return myCommand.ExecuteNonQuery();
            }
        }

        //public static int ExcuteNonQuery(string sSql,OleDbTransaction otMyTransaction)
        //{
        //    string myConnectionString = ConfigurationManager.ConnectionStrings["WaterFactory.Properties.Settings.water1ConnectionString"].ConnectionString;// "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\DataBase\\water1.mdb";
        //    SqlConnection myConnection = new SqlConnection(myConnectionString);
        //    using (myConnection)
        //    {
        //        if (myConnection.State == ConnectionState.Closed)
        //        {
        //            myConnection.Open();
        //        }
        //        SqlCommand myCommand = new SqlCommand(sSql, myConnection);
        //        myCommand.Transaction = otMyTransaction;
        //        return myCommand.ExecuteNonQuery();
        //    }
        //}

        /// <summary>
        /// 获取DBReader,可逐条读取数据
        /// </summary>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sSql)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);

            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }
            SqlCommand myCommand = new SqlCommand(sSql, myConnection);
            if (IsWriteLog)
            {
                Log.WriteLog(sSql);
            }
            return myCommand.ExecuteReader();
        }

        /// <summary>
        /// 执行查询,返回查询的第一行第一列,忽略其他数据
        /// </summary>
        /// <param name="sSql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sSql)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            using (myConnection)
            {
                if (myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }
                SqlCommand myCommand = new SqlCommand(sSql, myConnection);
                if (IsWriteLog)
                {
                    Log.WriteLog(sSql);
                }
                return myCommand.ExecuteScalar();
            }
        }

        /// <summary>
        /// 获取DB时间
        /// </summary>
        public DateTime GetDBTime
        {
            get
            {
                string sql = "SELECT CONVERT(varchar(100), GETDATE(), 20)";
                return DateTime.Parse(ExecuteScalar(sql).ToString());
            }
        }

        /// <summary>
        /// 组SQL,转换成SQL中可以识别的格式.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SQL(DateTime dt)
        {
            return "'" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }

        /// <summary>
        /// 组SQL,转换成SQL中可以识别的格式.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SQL(string sValue)
        {
            return "'" + sValue + "'";
        }

        /// <summary>
        /// 组SQL,转换成SQL中可以识别的格式.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int SQL(int nValue)
        {
            return nValue;
        }

        /// <summary>
        /// 组SQL,转换成SQL中可以识别的格式.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SQL(char sValue)
        {
            return "'" + sValue.ToString() + "'";
        }

        /// <summary>
        /// 组SQL,转换成SQL中可以识别的格式.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static double SQL(double dValue)
        {
            return dValue;
        }

        /// <summary>
        /// 组SQL,转换成SQL中可以识别的格式,以","结尾,可用于Update语句.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string SQLC(string sValue)
        {
            return "'" + sValue + "',";
        }

        /// <summary>
        /// 模糊查询Like
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public static string SQLL(string sValue)
        {
            return "'" + sValue + "%'";
        }

        /// <summary>
        /// 将数据库中取到的数据进行格式转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Int32 ToInt32(object obj)
        {
            if (obj != null && obj.ToString() != string.Empty)
            {
                return Convert.ToInt32(obj);
            }
            return -1;
        }

        /// <summary>
        /// 将数据库中取到的数据进行格式转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public String ToString(object obj)
        {
            if (obj != null && obj.ToString() != string.Empty)
            {
                return obj.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// 将数据库中取到的数据进行格式转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DateTime ToDateTime(object obj)
        {
            if (obj != null && obj.ToString() != string.Empty)
            {
                return Convert.ToDateTime(obj);
            }
            return DateTime.Parse("1900-01-01");
        }

        /// <summary>
        /// 将数据库中取到的数据进行格式转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Double ToDouble(object obj)
        {
            if (obj != null && obj.ToString() != string.Empty)
            {
                return Convert.ToDouble(obj);
            }
            return 0.0;
        }

        /// <summary>
        /// 将数据库中取到的数据进行格式转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Char ToChar(object obj)
        {
            if (obj != null && obj.ToString() != string.Empty)
            {
                return obj.ToString().ToCharArray(0, 1)[0];
            }
            return '?';
        }
    }
}
