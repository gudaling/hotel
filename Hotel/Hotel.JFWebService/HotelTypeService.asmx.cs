using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OleDb;
using Hotel.Model;
using System.Data.SqlClient;
using Hotel.DataAccess;
using System.Configuration;
using Hotel.Common;
namespace Hotel.JFWebService
{
    /// <summary>
    /// HotelTypeService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class HotelTypeService : System.Web.Services.WebService
    {
        private CommonLibrary cmn = new CommonLibrary();
        private DBHelper dbh;
        private string myConnectionString = ConfigurationManager.ConnectionStrings["WebServiceConn"].ConnectionString;
        private bool IsWriteLog = ConfigurationManager.AppSettings["IS_WRITE_SQL"].Trim().ToUpper().Equals("YES") ? true : false;

        public HotelTypeService()
        {
            dbh = new DBHelper(myConnectionString, IsWriteLog);
        }

        [WebMethod]
        public byte[] GetRommList()
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["DigiLock"].ConnectionString;
                OleDbConnection objConnection = new OleDbConnection(strConnection);
                objConnection.Open();//打开连接
                OleDbCommand odCommand = objConnection.CreateCommand();
                odCommand.CommandText = "SELECT ROOMNO,STATE,CARDQTY FROM ROOMLIST";
                OleDbDataReader reader = odCommand.ExecuteReader();
                List<RoomListModel> Roomlistmodel = new List<RoomListModel>();
                using (reader)
                {
                    while (reader.Read())
                    {
                        RoomListModel mRoom = new RoomListModel();
                        mRoom.State = dbh.ToString(reader["STATE"]);
                        mRoom.RoomNo = reader["RoomNo"].ToString().Substring(1, 3);
                        mRoom.CardQTY = dbh.ToInt32(reader["CARDQTY"]);
                        Roomlistmodel.Add(mRoom);
                    }
                    reader.Close();
                }
                objConnection.Close();
                return cmn.SerializeObject(Roomlistmodel);
            }
            catch (Exception err)
            {

                throw err;
            }

        }
    }
}
