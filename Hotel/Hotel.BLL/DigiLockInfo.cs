using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;
using System.Configuration;


namespace Hotel.BLL
{
    public class DigiLockInfo : AbBaseBll
    {
        private DigiLock.HotelTypeService hts = new Hotel.BLL.DigiLock.HotelTypeService();
        public DigiLockInfo()
        {
            hts.Url = ConfigurationManager.AppSettings["DigiLock"];
        }
        public List<RoomListModel> GetPhoneDetail()
        {
            return (List<RoomListModel>)cmn.DeserializeObject(hts.GetRommList());
        }
    }
}
