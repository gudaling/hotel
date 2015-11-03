using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Hotel.DataAccess;
using Hotel.DAL;

namespace Hotel.DAL
{
    public abstract class AbBaseDao : DBHelper
    {
        public static string DBConnectionString = ConfigurationManager.ConnectionStrings["HotelConnection"].ConnectionString;
        public HotelDBDataContext dc = new HotelDBDataContext(DBConnectionString);
        public SqlDataReader sdr;
    }
}
