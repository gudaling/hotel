using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class ConsumeDetailModel
    {
        public ConsumeDetailModel()
        {
            ConsumeId = -1;
        }
        public ConsumeDetailModel(int nConsumeId)
            :this()
        {
            ConsumeId = nConsumeId;
        }
        public int ConsumeId { get; set; }
        public int StayId { get; set; }
        public string StayIdGroup { get; set; }
        public int GoodsId { get; set; }
        public double Number { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
        public BasGoodsModel GoodsInfo { get; set; }
        public string RoomNo { get; set; }
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
    }
}
