using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;
using Hotel.DataAccess;

namespace Hotel.DAL
{
    public class StayRateDao : AbBaseDao
    {
        public List<StayRateModel> GetStayRate(StayRateModel mStayRate, ObjectControls oCtrl)
        {
            string sql = "SELECT A.ID,A.STAY_RATE,A.DAYS FROM STAY_RATE A WHERE 1=1 ";

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ById) && oCtrl.Append(ref sql, " AND A.ID=" + SQL(mStayRate.Id)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCreateDate) && oCtrl.Append(ref sql, " AND A.DAYS=" + SQL(mStayRate.Days)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStartDateBetween) && oCtrl.Append(ref sql, " AND A.DAYS BETWEEN " + SQL(mStayRate.CommonInfo.StartDate) + " AND " + SQL(mStayRate.CommonInfo.EndDate)));
            sql += " ORDER BY A.DAYS";
            sdr=ExecuteReader(sql);
            using (sdr)
            {
                List<StayRateModel> listStayRate = new List<StayRateModel>();
                while (sdr.Read())
                {
                    StayRateModel mStayRateNew = new StayRateModel();
                    mStayRateNew.Id = ToInt32(sdr["ID"]);
                    mStayRateNew.StayRate = ToDouble(sdr["STAY_RATE"]);
                    mStayRateNew.Days = ToDateTime(sdr["DAYS"]);
                    listStayRate.Add(mStayRateNew);
                }
                return listStayRate;
            }
        }

        public int UpdateStayRate(StayRateModel mStayRate)
        {
            string sql = "UPDATE STAY_RATE SET STAY_RATE=" + mStayRate.StayRate;
            sql += " WHERE ID=" + mStayRate.Id;

            return ExcuteNonQuery(sql);
        }


        public int InsertStayRate(StayRateModel mStayRate)
        {
            STAY_RATE sr = new STAY_RATE()
            {
                DAYS = mStayRate.Days,
                STAY_RATE1 = mStayRate.StayRate
            };
            dc.STAY_RATE.InsertOnSubmit(sr);
            dc.SubmitChanges();
            return sr.ID;
        }
    }
}
