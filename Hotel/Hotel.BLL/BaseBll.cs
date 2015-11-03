using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Hotel.Common;
using Hotel.DAL;
using System.Data;
using System.Data.Common;


namespace Hotel.BLL
{
    public abstract class AbBaseBll
    {
        public static string DbConnectionString = ConfigurationManager.ConnectionStrings["HotelConnection"].ConnectionString;
        public static bool IsWriteSql = ConfigurationManager.AppSettings["IS_WRITE_SQL"].Trim().ToUpper().Equals("YES") ? true : false;
        public HotelDBDataContext Dc = new HotelDBDataContext(DbConnectionString);
        public CommonLibrary Cmn = new CommonLibrary();
        public void OpenConnection(DbConnection dbc)
        {
            if (dbc.State == ConnectionState.Closed)
            {
                dbc.Open();
            }
        }
    }
    /// <summary>
    /// 逻辑类别,是开房还是编辑房间信息
    /// </summary>
    public enum RoomLogicType
    {
        OpenRoom, EditRoomInfo
    }
    /// <summary>
    /// 开房类型,是日常房间或钟点房
    /// </summary>
    public enum RoomStayType
    { 
        Day,Hour
    }
}
