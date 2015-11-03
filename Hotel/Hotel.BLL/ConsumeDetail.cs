using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Hotel.Model;
using Hotel.DAL;
using Hotel.Common;

namespace Hotel.BLL
{
    public class ConsumeDetail
    {
        private ConsumeDetailDao dConsumeDetail = new ConsumeDetailDao();

        /// <summary>
        /// 获取消费明细
        /// </summary>
        /// <param name="mConsume"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<ConsumeDetailModel> GetConsumeList(ConsumeDetailModel mConsume, ObjectControls oCtrl)
        {
            return dConsumeDetail.GetConsumeList(mConsume, oCtrl);
        }
        public int InsertConsumeDetail(ConsumeDetailModel mConsume)
        {
            return dConsumeDetail.InsertConsumeDetail(mConsume);
        }
        public int UpdateConsumeDetail(ConsumeDetailModel mConsume, ObjectControls oCtrl) 
        {
            return dConsumeDetail.UpdateConsumeDetail(mConsume, oCtrl);
        }
        public int DeleteConsumeDetail(ConsumeDetailModel mConsume)
        {
            return dConsumeDetail.DeleteConsumeDetail(mConsume);
        }
    }
}
