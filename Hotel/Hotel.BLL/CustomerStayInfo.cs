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
    public class CustomerStayInfo
    {
        private CustomerStayDao dCustomerStay = new CustomerStayDao();

        /// <summary>
        /// 获取宾客入住信息
        /// </summary>
        /// <param name="mCustomerStay"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public CustomerStayModel GetCustomerStayInfo(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            return dCustomerStay.GetCustomerStayInfo(mCustomerStay, oCtrl);
        }
        /// <summary>
        /// 获取符合条件的所有入住信息
        /// </summary>
        /// <param name="mCustomerStay"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<CustomerStayModel> GetCustomerStayList(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            return dCustomerStay.GetCustomerStayList(mCustomerStay, oCtrl); 
        }
        /// <summary>
        /// 获取交接班时的金额信息,押金或者营业收入
        /// </summary>
        /// <param name="mCustomerStay"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public HandOverModel GetHandOverStayInfo(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            return dCustomerStay.GetHandOverStayInfo(mCustomerStay, oCtrl);
        }
        /// <summary>
        /// 获取入住历时信息
        /// </summary>
        /// <param name="mStayHis"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<CustomerStayHisModel> GetStayHis(CustomerStayHisModel mStayHis, ObjectControls oCtrl)
        {
            return dCustomerStay.GetStayHis(mStayHis, oCtrl);
        }

        /// <summary>
        /// 返回新增成功后的ID
        /// </summary>
        /// <param name="mHis"></param>
        /// <returns></returns>
        public int InsertCustomerStay(CustomerStayModel mCustomerStay)
        {
            return dCustomerStay.InsertCustomerStay(mCustomerStay);
        }

        /// <summary>
        /// 返回新增成功后的ID
        /// </summary>
        /// <param name="mHis"></param>
        /// <returns></returns>
        public int InsertCustomerStayHis(CustomerStayHisModel mHis)
        {
            return dCustomerStay.InsertCustomerStayHis(mHis);
        }

        public int UpdateCustomerStay(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            return dCustomerStay.UpdateCustomerStay(mCustomerStay, oCtrl);
        }

        public int UpdateStayHis(CustomerStayHisModel mHis, ObjectControls oCtrl)
        {
            return dCustomerStay.UpdateStayHis(mHis, oCtrl);            
        }

        public int DeleteCustomerStay(CustomerStayModel mCustomerStay)
        {
            return dCustomerStay.DeleteCustomerStay(mCustomerStay);
        }

        public List<CustomerStayModel> GetMainRoomGroup()
        {
            return dCustomerStay.GetMainRoomGroup();
        }
    }
}
