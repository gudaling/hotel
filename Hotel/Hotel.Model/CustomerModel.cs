using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 宾客信息
    /// </summary>
    public class CustomerModel
    {
        private DateTime dtBirthday = DateTime.Parse("1900-01-01");
        public int CustomerId { get; set; }
        private CustomerStayHisModel mHis = new CustomerStayHisModel();
        public CustomerStayHisModel CustomerStayHisInfo
        {
            get { return mHis; }
            set { mHis = value; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public DateTime Birthday 
        {
            get { return dtBirthday; }
            set { dtBirthday = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        private string sPicture = "";
        /// <summary>
        /// 照片地址
        /// </summary>
        public string Picture
        {
            get { return sPicture; }
            set { sPicture = value; }
        }
        /// <summary>
        /// 类型.还未使用
        /// </summary>
        public char Type { get; set; }
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
    }
    public class CustomerStayHisModel
    {
        public CustomerStayHisModel()
        {
            HisId = -1;
        }
        public int HisId { get; set; }
        public int StayId { get; set; }
        public int CustomerId { get; set; }
        /// <summary>
        /// 宾客主从关系
        /// </summary>
        public char StayType { get; set; }
        /// <summary>
        /// 宾客入住状态,是否在该房间.主要考虑的是房间的人员可能变动
        /// 同时需要记录住宿的状态
        /// </summary>
        public char HisStatus { get; set; }
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
    }
}
