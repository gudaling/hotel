using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DAL;
using Hotel.Common;
using System.Data;

namespace Hotel.BLL
{
    public class OrdersInfo : AbBaseBll
    {
        private OrderInfoDao dOrder = new OrderInfoDao();
        /// <summary>
        /// 获取预定信息
        /// </summary>
        /// <param name="mOrder"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<OrderInfoModel> GetOrderInfo(OrderInfoModel mOrder, ObjectControls oCtrl)
        {
            return dOrder.GetOrderInfo(mOrder, oCtrl);
        }

        public DataSet GetOrderInfoDs(OrderInfoModel mOrder, ObjectControls oCtrl)
        {
            return dOrder.GetOrderInfoDs(mOrder, oCtrl);
        }

        public int InsertOrderInfo(OrderInfoModel mOrder)
        {
            return dOrder.InsertOrderInfo(mOrder);
        }

        public int UpdateOrderInfo(OrderInfoModel mOrder, ObjectControls oCtrl)
        {
            return dOrder.UpdateOrderInfo(mOrder, oCtrl);
        }

        public int DeleteOrder(OrderInfoModel mOrder)
        {
            return dOrder.DeleteOrder(mOrder);
        }
    }
}
