using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DAL;
using Hotel.Common;

namespace Hotel.BLL
{
    public class BasRoomInfo : AbBaseBll
    {
        private BasRoomDao bRoomDao = new BasRoomDao();

        /// <summary>
        /// 获取房间信息
        /// </summary>
        /// <param name="mRoom"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<BasRoomModel> GetRoomInfo(BasRoomModel mRoom, ObjectControls oCtrl)
        {
            return bRoomDao.GetRoomInfo(mRoom, oCtrl);
        }
        /// <summary>
        /// 获取团队房间信息.
        /// </summary>
        /// <param name="mCustomerStay"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<BasRoomModel> GetTeamRoomList(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            return bRoomDao.GetTeamRoomList(mCustomerStay, oCtrl);
        }
        public bool InsertRoomInfo(BasRoomModel mRoomInfo)
        {
            return bRoomDao.InsertRoomInfo(mRoomInfo);
        }

        public int UpdateRoomInfo(BasRoomModel mRoomInfo, ObjectControls oCtrl)
        {
            return bRoomDao.UpdateRoomInfo(mRoomInfo, oCtrl);
        }

        public bool DeleteRoomInfo(BasRoomModel mRoomInfo)
        {
            return bRoomDao.DeleteRoomInfo(mRoomInfo);
        }
        ///// <summary>
        ///// 获取房间信息
        ///// </summary>
        ///// <param name="mRoomInfo"></param>
        ///// <returns></returns>
        //public List<BasRoomModel> GetAllRoomInfo()
        //{

        //    var query = from a in dc.BAS_FLOOR_INFO join b in dc.BAS_ROOM_INFO on a.FLOOR_ID equals b.FLOOR_ID select new { FloorId = a.FLOOR_ID, FloorName = a.FLOOR_NAME, RoomInfo = b };
        //    if (query.Count() > 0)
        //    {
        //        List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
        //        foreach (var value in query)
        //        {
        //            BasRoomModel mRoomInfoNew = new BasRoomModel();
        //            mRoomInfoNew.RoomId = value.RoomInfo.ROOM_ID;
        //            mRoomInfoNew.RoomNo = value.RoomInfo.ROOM_NO;
        //            mRoomInfoNew.RoomRate = value.RoomInfo.ROOM_RATES;
        //            mRoomInfoNew.RoomType = value.RoomInfo.ROOM_TYPE;
        //            mRoomInfoNew.Status = value.RoomInfo.STATUS;
        //            mRoomInfoNew.FloorInfo = new BasFloorModel();
        //            mRoomInfoNew.FloorInfo.FloorId = value.FloorId;
        //            mRoomInfoNew.FloorInfo.FloorName = value.FloorName;
        //            listRoomInfo.Add(mRoomInfoNew);
        //        }
        //        return listRoomInfo;
        //    }
        //    return null;
        //}

        //public List<BasRoomModel> GetRoomInfoByFloorId(BasRoomModel mBasRoom)
        //{
        //    var query = from a in dc.BAS_FLOOR_INFO join b in dc.BAS_ROOM_INFO.Where(b => b.FLOOR_ID == mBasRoom.FloorInfo.FloorId) on a.FLOOR_ID equals b.FLOOR_ID select new { FloorId = a.FLOOR_ID, FloorName = a.FLOOR_NAME, RoomInfo = b };
        //    List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
        //    foreach (var value in query)
        //    {
        //        BasRoomModel mRoomInfoNew = new BasRoomModel();
        //        mRoomInfoNew.RoomId = value.RoomInfo.ROOM_ID;
        //        mRoomInfoNew.RoomNo = value.RoomInfo.ROOM_NO;
        //        mRoomInfoNew.RoomRate = value.RoomInfo.ROOM_RATES;
        //        mRoomInfoNew.RoomType = value.RoomInfo.ROOM_TYPE;
        //        mRoomInfoNew.Status = value.RoomInfo.STATUS;
        //        mRoomInfoNew.FloorInfo = new BasFloorModel();
        //        mRoomInfoNew.FloorInfo.FloorId = value.FloorId;
        //        mRoomInfoNew.FloorInfo.FloorName = value.FloorName;
        //        listRoomInfo.Add(mRoomInfoNew);
        //    }
        //    return listRoomInfo;
        //}

    }
}
