using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    [Serializable]
    public class CallModel
    {
        public CallModel()
        {
            ListId = -1;
        }

        public CallModel(int nCallId)
            : this()
        {

        }

        public int ListId { get; set; }

        private BasRoomModel mRoom = new BasRoomModel();

        public BasRoomModel RoomInfo
        {
            get { return mRoom; }
            set { mRoom = value; }
        }

        public int StayId { get; set; }

        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }

        public int FreeId { get; set; }

        private PhoneCatModel mCat = new PhoneCatModel();
        public PhoneCatModel PhoneCatInfo
        {
            get { return mCat; }
            set { mCat = value; }
        }
    }

    [Serializable]
    public class PhoneCatModel
    {
        public PhoneCatModel()
        {
            CatId = -1;
        }
        public int CatId { get; set; }

        public string CatDesc { get; set; }

        public double CatRate { get; set; }
    }
}
