using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 基本信息类
    /// </summary>
    [Serializable]
    public class CommonModel
    {
        private DateTime dtCreateDate;
        private DateTime dtUpdateDate;
        private DateTime dtStartDate;
        private DateTime dtEndDate;
        private int nCreateUserId;
        private int nUpdateUserId;

        public string CreateUserName { get; set; }

        public string UpateUserName { get; set; }

        public CommonModel()
        {
            dtCreateDate = DateTime.MinValue;
            dtUpdateDate = DateTime.MinValue;
            dtStartDate = DateTime.MinValue;
            dtEndDate = DateTime.MinValue;
            nCreateUserId = -1;
            nUpdateUserId = -1;
        }

        public DateTime CreateDate
        {
            get { return dtCreateDate; }
            set { dtCreateDate = value; }
        }

        public DateTime UpdateDate
        {
            get { return dtUpdateDate; }
            set { dtUpdateDate = value; }
        }

        public DateTime StartDate
        {
            get { return dtStartDate; }
            set { dtStartDate = value; }
        }

        public DateTime EndDate
        {
            get { return dtEndDate; }
            set { dtEndDate = value; }
        }

        public int CreateUserId
        {
            get { return nCreateUserId; }
            set { nCreateUserId = value; }
        }

        public int UpdateUserId
        {
            get { return nUpdateUserId; }
            set { nUpdateUserId = value; }
        }
    }
}
