using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Hotel.Model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Hotel.DataAccess;
using Hotel.Common;

namespace Hotel.JFWebService
{
    
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class JFService : System.Web.Services.WebService
    {
       private SqlDataReader sdr;
       private string myConnectionString = ConfigurationManager.ConnectionStrings["WebServiceConn"].ConnectionString;
       private bool IsWriteLog = ConfigurationManager.AppSettings["IS_WRITE_SQL"].Trim().ToUpper().Equals("YES") ? true : false;
       private DBHelper dbhelper;

       public JFService()
       {
           dbhelper = new DBHelper(myConnectionString, IsWriteLog);
       }
       private SqlDataReader ExecuteReader(string sSql)
       {
           SqlConnection myConnection = new SqlConnection(myConnectionString);

           if (myConnection.State == ConnectionState.Closed)
           {
               myConnection.Open();
           }
           SqlCommand myCommand = new SqlCommand(sSql, myConnection);
           return myCommand.ExecuteReader();
       }
        private CommonLibrary cmn = new CommonLibrary();
        /// <summary>
        /// 是否写Log
        /// </summary>
        /// <summary>
        /// 定义连接字符串
        /// </summary>
        [WebMethod]
        public byte[] GetPhoteDetail(byte[] bytJf, byte[] bytCtrl, DateTime dtmNow)
        {
            JFModel mJf = (JFModel)cmn.DeserializeObject(bytJf);
            ObjectControls oCtrl = (ObjectControls)cmn.DeserializeObject(bytCtrl);
            if (dtmNow < mJf.CommonInfo.StartDate)
            {
                return cmn.SerializeObject(new List<JFModel>());
            }
            DateTime dtEndDate = dtmNow <= mJf.CommonInfo.EndDate ? dtmNow : mJf.CommonInfo.EndDate;
            List<JFModel> listJFModel = new List<JFModel>();
            for (DateTime dt = mJf.CommonInfo.StartDate.Date; dt.Date <= dtEndDate.Date; )
            {
                string sql = "";
                for (DateTime dtTmp = dt.Date; dtTmp < dt.Date.AddDays(2); )
                {
                    string sTableName = "DW" + dtTmp.ToString("yyyyMMdd");
                    if (dtTmp.Date < dtmNow.Date)
                    {
                        if (CheckTableExist(sTableName))
                        {
                            if (dtTmp.Date != dt.Date)
                            {
                                sql += " UNION ALL ";
                            }
                            sql += @"SELECT A.OPNO,CONVERT(CHAR(100),DATEADD(SS,A.STARTTIME,'19940101'),20) START_DATE,
                                            CONVERT(CHAR(100),DATEADD(SS,A.ENDTIME,'19940101'),20) END_DATE,
                                            A.FREEID,A.OPCAT,A.LINKNO,B.JF_TYPE,C.SERCATNAME 
                            FROM " + sTableName + @" A,JFJF_ID B,JFSERCATID C 
                            WHERE 1=1 AND A.FREEID=B.JF_ID AND A.OPCAT=C.SERCAT ";
                            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone) && oCtrl.Append(ref sql, " AND OPNO IN (" + mJf.PhoneNoGroup + ")"));
                            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStartDate) && oCtrl.Append(ref sql,
                             " AND CONVERT(CHAR(100),DATEADD(SS,STARTTIME,'19940101'),20) >= " + DBHelper.SQL(mJf.CommonInfo.StartDate)
                            + " AND CONVERT(CHAR(100),DATEADD(SS,ENDTIME,'19940101'),20) <= " + DBHelper.SQL(dtEndDate)));
                        }
                    }
                    else if (dtTmp.Date == dtmNow.Date)
                    {
                        if (!sql.Trim().Equals(""))
                        {
                            sql += " UNION ALL ";
                        }
                        sql += @"SELECT A.OPNO,CONVERT(CHAR(100),DATEADD(SS,A.STARTTIME,'19940101'),20) START_DATE,
                                            CONVERT(CHAR(100),DATEADD(SS,A.ENDTIME,'19940101'),20) END_DATE,
                                            A.FREEID,A.OPCAT,A.LINKNO,B.JF_TYPE,C.SERCATNAME 
                            FROM ZXJHD A,JFJF_ID B,JFSERCATID C 
                            WHERE 1=1 AND A.FREEID=B.JF_ID AND A.OPCAT=C.SERCAT ";
                        oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone) && oCtrl.Append(ref sql, " AND OPNO IN (" + mJf.PhoneNoGroup + ")"));
                        oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStartDate) && oCtrl.Append(ref sql,
                         " AND CONVERT(CHAR(100),DATEADD(SS,STARTTIME,'19940101'),20) >= " + DBHelper.SQL(mJf.CommonInfo.StartDate)
                        + " AND CONVERT(CHAR(100),DATEADD(SS,ENDTIME,'19940101'),20)<= " + DBHelper.SQL(dtEndDate)));
                    }
                    dtTmp = dtTmp.AddDays(1);
                }
                if (string.IsNullOrEmpty(sql))
                {
                    dt = dt.Date < dtEndDate.Date.AddDays(-2) ? dt.AddDays(2) : dt.AddDays(1);
                    continue;
                }
                sdr = ExecuteReader(sql);
                using (sdr)
                {
                    while (sdr.Read())
                    {
                        JFModel jfmodel = new JFModel();
                        jfmodel.PhoneNo = dbhelper.ToString(sdr["OPNO"]);
                        jfmodel.CommonInfo.StartDate = dbhelper.ToDateTime(sdr["START_DATE"]);
                        jfmodel.CommonInfo.EndDate = dbhelper.ToDateTime(sdr["END_DATE"]);
                        jfmodel.FreeId = dbhelper.ToInt32(sdr["FREEID"]);
                        jfmodel.FreeDesc = dbhelper.ToString(sdr["JF_TYPE"]);
                        jfmodel.OpCat = dbhelper.ToInt32(sdr["OPCAT"]);
                        jfmodel.OpCatDesc = dbhelper.ToString(sdr["SERCATNAME"]);
                        jfmodel.LinkNo = dbhelper.ToString(sdr["LINKNO"]);
                        listJFModel.Add(jfmodel);
                    }
                }
                dt = dt.Date < dtEndDate.Date.AddDays(-2) ? dt.AddDays(2) : dt.AddDays(1);
            }
            return cmn.SerializeObject(listJFModel);
        }

        private bool CheckTableExist(string sTableName)
        {
            string sql = @" SELECT ID FROM SYSOBJECTS WHERE ID =  
                                OBJECT_ID(N'[DBO].["+sTableName+@"]') 
                                 AND OBJECTPROPERTY(ID, N'ISUSERTABLE') = 1";

            if (dbhelper.ExecuteScalar(sql) != null)
            {
                return true;
            }
            return false;
        }
    }

}
