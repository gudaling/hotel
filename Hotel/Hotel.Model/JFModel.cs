using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    [Serializable]
    public class JFModel
    {
        /// <summary>
        /// 主叫号码
        /// </summary>
        public string PhoneNo {get; set;}

        private string sPhoneNoGroup="";
        public string PhoneNoGroup         
        {
            get { return sPhoneNoGroup; }
            set { sPhoneNoGroup = value; }
        }

        private CommonModel mComm = new CommonModel();
        /// <summary>
        /// 开始时间和结束时间
        /// </summary>
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
        /// <summary>
        /// 是否计费
        /// </summary>
        public int FreeId {get; set;}

        /// <summary>
        /// 计费描述
        /// </summary>
        public string FreeDesc { get; set; }
        /// <summary>
        /// 通话类型
        /// </summary>
        public int OpCat { get; set;}

        public string OpCatDesc { get; set; }
        /// <summary>
        /// 被叫号码
        /// </summary>
        public string LinkNo { get; set; }

        private List<PhoneCatModel> listCat = new List<PhoneCatModel>();

        public List<PhoneCatModel> CatList
        {
            get { return listCat; }
            set { listCat = value; }
        }
    }
}
