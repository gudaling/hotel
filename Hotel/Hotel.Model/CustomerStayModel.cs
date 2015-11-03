using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class CustomerStayModel
    {
        public CustomerStayModel()
        { }
        public CustomerStayModel(int nStayId)
        {
            StayId = nStayId;
        }
        public CustomerStayModel(string sStayNo)
        {
            StayNo = sStayNo;
        }
        public int StayId { get; set; }
        public string StayNo { get; set; }
        /// <summary>
        /// 房间编号
        /// </summary>
        public int RoomId { get; set; }
        /// <summary>
        /// 主客房间编号,可为空
        /// </summary>
        public int MainRoomId { get; set; }
        /// <summary>
        /// 入住时间信息
        /// </summary>
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
        /// <summary>
        /// 押金
        /// </summary>
        public double Deposit { get; set; }

        private double dPaidMoney = 0.0;
        /// <summary>
        /// 实收金额;如果宾客换过房间,则包括换房前的房间费用
        /// </summary>
        public double PaidMoney
        {
            get { return dPaidMoney; }
            set { dPaidMoney = value; }
        }

        /// <summary>
        /// 入住时间=天数*24小时
        /// </summary>
        public int Hours { get; set; }
        /// <summary>
        ///  房间入住类型.常包房,钟点房,普通房
        /// </summary>
        public char RoomStayType { get; set; }
        /// <summary>
        /// 房间定价,协议定价..
        /// </summary>
        public double RoomRate { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public char PayType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public char Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// 合计费用
        /// </summary>
        public double Total { get; set; }

        private BasRoomModel mRoom = new BasRoomModel();
        /// <summary>
        /// 房间信息
        /// </summary>
        public BasRoomModel RoomInfo
        {
            get { return mRoom; }
            set { mRoom = value; }
        }
        /// <summary>
        /// 宾客信息
        /// </summary>
        //public CustomerModel CustomerInfo { get; set; }

        //public BasHotelRates HotelRates { get; set; }
        private List<CustomerModel> listCustomer = new List<CustomerModel>();
        /// <summary>
        /// 消费明细
        /// </summary>
        public List<CustomerModel> CustomerList
        {
            get { return listCustomer; }
            set { listCustomer = value; }
        
        }

        private List<ConsumeDetailModel> listConSumeDetail = new List<ConsumeDetailModel>();
        /// <summary>
        /// 消费清单,不含房价
        /// </summary>
        public List<ConsumeDetailModel> ConSumeDetailList 
        {
            get { return listConSumeDetail; }
            set { listConSumeDetail = value; }
        }
    }
}
