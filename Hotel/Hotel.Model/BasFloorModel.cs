using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 楼层信息
    /// </summary>
    public class BasFloorModel
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public char Status { get; set; }
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
    }
}
