using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DAL;
using Hotel.Common;

namespace Hotel.BLL
{
    public class StayRateInfo:AbBaseBll
    {

        private StayRateDao dStayRate = new StayRateDao();

        public List<StayRateModel> GetStayRate(StayRateModel mStayRate, ObjectControls oCtrl)
        {
            return dStayRate.GetStayRate(mStayRate, oCtrl);
        }

        public int UpdateStayRate(StayRateModel mStayRate)
        {
            return dStayRate.UpdateStayRate(mStayRate);
        }

        public int InsertStayRate(StayRateModel mStayRate)
        {
            return dStayRate.InsertStayRate(mStayRate);
        }
    }
}
