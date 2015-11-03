using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 宾客订单信息
    /// </summary>
    public class OrderInfoModel
    {
        public OrderInfoModel()
        {
            OrderId = -1;
        }

        public OrderInfoModel(int nOrderId)
            : this()
        {
            OrderId = nOrderId;
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 订单保留时间
        /// </summary>
        public DateTime KeepDate { get; set; }

        /// <summary>
        /// 一些时间信息,例如创建,修改,房间住宿开始时间,结束时间等等
        /// </summary>
        private CommonModel mComm = new CommonModel();

        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }

        public char Status { get; set; }
        public string Notice { get; set; }

        public double OrderRoomRate { get; set; }

        private BasRoomModel mRoomInfo = new BasRoomModel();
        public BasRoomModel RoomInfo
        {
            get { return mRoomInfo; }
            set { mRoomInfo = value; }
        }

    }
}
