using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class HandOverModel
    {
        public HandOverModel()
        {
            HandOverId = -1;
        }
        public HandOverModel(int nHandId)
            : this()
        {
            HandOverId = nHandId;
        }
        public int HandOverId { get; set; }

        private SysUserInfoModel mCurrentUserInfo = new SysUserInfoModel();
        public SysUserInfoModel CurrentUserInfo
        {
            get { return mCurrentUserInfo; }
            set { mCurrentUserInfo = value; }
        }

        private SysUserInfoModel mNextUserInfo = new SysUserInfoModel();
        public SysUserInfoModel NextUserInfo
        {
            get { return mNextUserInfo; }
            set { mNextUserInfo = value; }
        }

        private CommonModel mCommon = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mCommon; }
            set { mCommon = value; }
        }

        /// <summary>
        /// 交接时金额
        /// </summary>
        public double HandOverMoney { get; set; }

        /// <summary>
        /// 上交金额
        /// </summary>
        public double HandInMoney { get; set; }

        /// <summary>
        /// 留给接收人金额
        /// </summary>
        public double ToNextMoney { get; set; }

        /// <summary>
        /// 上班结余金额
        /// </summary>
        public double FromLastMoney { get; set; }

        /// <summary>
        /// 未结账的押金
        /// </summary>
        public double CurrentDeposit { get; set; }

        /// <summary>
        /// 营业收入
        /// </summary>
        public double CurrentPaidMoney { get; set; }

    }
}
