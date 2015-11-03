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
    public class CustomerInfo
    {
        private CustomerDao dCustomer = new CustomerDao();
        /// <summary>
        /// 获取宾客信息
        /// </summary>
        /// <param name="mCustomer"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<CustomerModel> GetCustomerInfo(CustomerModel mCustomer, ObjectControls oCtrl)
        {
            return dCustomer.GetCustomerInfo(mCustomer, oCtrl);
        }

        public int InsertCustomer(CustomerModel mCustomer)
        {
            return dCustomer.InsertCustomer(mCustomer);
        }

        public int UpdateCustomer(CustomerModel mCustomer, ObjectControls oCtrl)
        {
            return dCustomer.UpdateCustomer(mCustomer, oCtrl);
        }

        public int DeleteCustomer(CustomerModel mCustomer)
        {
            return dCustomer.DeleteCustomer(mCustomer);
        }
    }
}