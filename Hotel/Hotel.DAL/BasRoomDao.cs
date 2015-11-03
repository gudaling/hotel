using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Hotel.Common;
using Hotel.Model;

namespace Hotel.DAL
{
    public class BasRoomDao:AbBaseDao
    {
        public List<BasRoomModel> GetRoomInfo(BasRoomModel mRoom, ObjectControls oCtrl)
        {
            string sql = @"SELECT A.ROOM_ID, A.ROOM_NO, A.ROOM_TYPE,C.CODE_DESC AS ROOM_TYPE_DESC, A.ROOM_RATES, A.STATUS, 
                             A.CREATE_DATE, A.CREATE_USERID, A.ROOM_PHONE, A.ROOM_NOTICE,A.UPDATE_DATE,A.UPDATE_USERID,
                             B.FLOOR_ID, B.FLOOR_NAME, B.STATUS AS FLOOR_STATUS
                             FROM BAS_ROOM_INFO AS A INNER JOIN
                             BAS_FLOOR_INFO AS B ON A.FLOOR_ID = B.FLOOR_ID
                            INNER JOIN SYS_LOOKUP_CODE AS C ON A.ROOM_TYPE=C.CODE_NO AND C.TABLE_NAME='BAS_ROOM_INFO'
                             AND C.COLUMN_NAME='ROOM_TYPE' ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) && oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mRoom.RoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomNo) && oCtrl.Append(ref sql, " AND A.ROOM_NO=" + SQL(mRoom.RoomNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatus) && oCtrl.Append(ref sql, " AND A.STATUS=" + SQL(mRoom.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatusGroup) && oCtrl.Append(ref sql, " AND A.STATUS IN (" + mRoom.StatusGroup+")"));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomType) && oCtrl.Append(ref sql, " AND A.ROOM_TYPE=" + SQL(mRoom.RoomType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorId) && oCtrl.Append(ref sql, " AND B.FLOOR_ID=" + mRoom.FloorInfo.FloorId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorName) && oCtrl.Append(ref sql, " AND B.FLOOR_NAME=" + SQL(mRoom.FloorInfo.FloorName)));
            sql += " ORDER BY ROOM_NO";
            sdr = ExecuteReader(sql);
            List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    BasRoomModel mBasRoomInfo = new BasRoomModel();
                    mBasRoomInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                    mBasRoomInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                    mBasRoomInfo.RoomPhone = ToString(sdr["ROOM_PHONE"]);
                    mBasRoomInfo.RoomRate = ToDouble(sdr["ROOM_RATES"]);
                    mBasRoomInfo.RoomType = ToChar(sdr["ROOM_TYPE"]);
                    mBasRoomInfo.RoomTypeDesc = ToString(sdr["ROOM_TYPE_DESC"]);
                    mBasRoomInfo.RoomNotice = ToString(sdr["ROOM_NOTICE"]);
                    mBasRoomInfo.Status = ToChar(sdr["STATUS"]);
                    mBasRoomInfo.CommonInfo = new CommonModel();
                    mBasRoomInfo.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mBasRoomInfo.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mBasRoomInfo.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                    mBasRoomInfo.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                    mBasRoomInfo.FloorInfo = new BasFloorModel();
                    mBasRoomInfo.FloorInfo.FloorId = ToInt32(sdr["FLOOR_ID"]);
                    mBasRoomInfo.FloorInfo.FloorName = ToString(sdr["FLOOR_NAME"]);
                    mBasRoomInfo.FloorInfo.Status = ToChar(sdr["FLOOR_STATUS"]);
                    listRoomInfo.Add(mBasRoomInfo);
                }
            }
            return listRoomInfo;
        }

        public List<BasRoomModel> GetTeamRoomList(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            string sql = @"SELECT A.ROOM_ID,D.MAIN_ROOM_ID, A.ROOM_NO, A.ROOM_TYPE,C.CODE_DESC AS ROOM_TYPE_DESC, A.ROOM_RATES, A.STATUS, 
                             A.CREATE_DATE, A.CREATE_USERID, A.ROOM_PHONE,A.ROOM_NOTICE, A.UPDATE_DATE,A.UPDATE_USERID,
                             B.FLOOR_ID, B.FLOOR_NAME, B.STATUS AS FLOOR_STATUS
                             FROM BAS_ROOM_INFO AS A INNER JOIN
                              CUSTOMER_STAY_INFO AS D ON A.ROOM_ID=D.ROOM_ID  INNER JOIN
                             BAS_FLOOR_INFO AS B ON A.FLOOR_ID = B.FLOOR_ID
                            INNER JOIN SYS_LOOKUP_CODE AS C ON A.ROOM_TYPE=C.CODE_NO AND C.TABLE_NAME='BAS_ROOM_INFO'
                             AND C.COLUMN_NAME='ROOM_TYPE' ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) && oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mCustomerStay.RoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByMainRoomId) && oCtrl.Append(ref sql, " AND D.MAIN_ROOM_ID=" + mCustomerStay.MainRoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayStatus) && oCtrl.Append(ref sql, " AND D.STATUS=" + SQL(mCustomerStay.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomNo) && oCtrl.Append(ref sql, " AND A.ROOM_NO=" + SQL(mCustomerStay.RoomInfo.RoomNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatus) && oCtrl.Append(ref sql, " AND A.STATUS=" + SQL(mCustomerStay.RoomInfo.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatusGroup) && oCtrl.Append(ref sql, " AND A.STATUS IN (" + mCustomerStay.RoomInfo.StatusGroup + ")"));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomType) && oCtrl.Append(ref sql, " AND A.ROOM_TYPE=" + SQL(mCustomerStay.RoomInfo.RoomType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorId) && oCtrl.Append(ref sql, " AND B.FLOOR_ID=" + mCustomerStay.RoomInfo.FloorInfo.FloorId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorName) && oCtrl.Append(ref sql, " AND B.FLOOR_NAME=" + SQL(mCustomerStay.RoomInfo.FloorInfo.FloorName)));
            sdr = ExecuteReader(sql);
            List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    BasRoomModel mBasRoomInfo = new BasRoomModel();
                    mBasRoomInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                    mBasRoomInfo.MainRoomId = ToInt32(sdr["MAIN_ROOM_ID"]);
                    mBasRoomInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                    mBasRoomInfo.RoomPhone = ToString(sdr["ROOM_PHONE"]);
                    mBasRoomInfo.RoomRate = ToDouble(sdr["ROOM_RATES"]);
                    mBasRoomInfo.RoomType = ToChar(sdr["ROOM_TYPE"]);
                    mBasRoomInfo.RoomTypeDesc = ToString(sdr["ROOM_TYPE_DESC"]);
                    mBasRoomInfo.RoomNotice = ToString(sdr["ROOM_NOTICE"]);
                    mBasRoomInfo.Status = ToChar(sdr["STATUS"]);
                    mBasRoomInfo.CommonInfo = new CommonModel();
                    mBasRoomInfo.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mBasRoomInfo.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mBasRoomInfo.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                    mBasRoomInfo.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                    mBasRoomInfo.FloorInfo = new BasFloorModel();
                    mBasRoomInfo.FloorInfo.FloorId = ToInt32(sdr["FLOOR_ID"]);
                    mBasRoomInfo.FloorInfo.FloorName = ToString(sdr["FLOOR_NAME"]);
                    mBasRoomInfo.FloorInfo.Status = ToChar(sdr["FLOOR_STATUS"]);
                    listRoomInfo.Add(mBasRoomInfo);
                }
            }
            return listRoomInfo;
        }

        /// <summary>
        /// 新增房间信息
        /// </summary>
        /// <param name="mRoomInfo"></param>
        /// <returns></returns>
        public bool InsertRoomInfo(BasRoomModel mRoomInfo)
        {
            try
            {
                BAS_ROOM_INFO bri = new BAS_ROOM_INFO();
                bri.ROOM_NO = mRoomInfo.RoomNo;
                bri.ROOM_TYPE = mRoomInfo.RoomType;
                bri.ROOM_RATES = mRoomInfo.RoomRate;
                bri.ROOM_PHONE = mRoomInfo.RoomPhone;
                bri.STATUS = mRoomInfo.Status;
                bri.FLOOR_ID = mRoomInfo.FloorInfo.FloorId;
                bri.ROOM_NOTICE = mRoomInfo.RoomNotice;
                bri.CREATE_DATE = GetDBTime;
                bri.CREATE_USERID = mRoomInfo.CommonInfo.CreateUserId;
                bri.UPDATE_DATE = bri.CREATE_DATE;
                bri.UPDATE_USERID = bri.CREATE_USERID;
                dc.BAS_ROOM_INFO.InsertOnSubmit(bri);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改房间信息
        /// </summary>
        /// <param name="mRoomInfo"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public int UpdateRoomInfo(BasRoomModel mRoomInfo, ObjectControls oCtrl)
        {
            try
            {
                string sql = "UPDATE BAS_ROOM_INFO SET  CREATE_DATE=CREATE_DATE";
                oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomNo) && oCtrl.Append(ref sql, ",ROOM_NO=" + SQL(mRoomInfo.RoomNo)));
                oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomStatus) && oCtrl.Append(ref sql, ",STATUS=" + SQL(mRoomInfo.Status)));
                oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomRate) && oCtrl.Append(ref sql, ",ROOM_RATES=" + SQL(mRoomInfo.RoomRate)));
                oCtrl.Helper(oCtrl.Exsit(MCtrl.SetPhone) && oCtrl.Append(ref sql, ",ROOM_PHONE=" + SQL(mRoomInfo.RoomPhone)));
                oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomType) && oCtrl.Append(ref sql, ",ROOM_TYPE=" + SQL(mRoomInfo.RoomType)));
                oCtrl.Helper(oCtrl.Exsit(MCtrl.SetFloorId) && oCtrl.Append(ref sql, ",FLOOR_ID=" + SQL(mRoomInfo.FloorInfo.FloorId)));
                oCtrl.Helper(oCtrl.Exsit(MCtrl.SetNotice) && oCtrl.Append(ref sql, ",ROOM_NOTICE=" + SQL(mRoomInfo.RoomNotice)));
                sql += ",UPDATE_DATE=" + SQL(GetDBTime);
                sql += ",UPDATE_USERID=" + SQL(mRoomInfo.CommonInfo.UpdateUserId);
                sql += " WHERE ROOM_ID=" + mRoomInfo.RoomId;
                return ExcuteNonQuery(sql);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="mRoomInf"></param>
        /// <returns></returns>
        public bool DeleteRoomInfo(BasRoomModel mRoomInfo)
        {
            try
            {
                BAS_ROOM_INFO bri = dc.BAS_ROOM_INFO.First(c => c.ROOM_ID == mRoomInfo.RoomId);
                dc.BAS_ROOM_INFO.DeleteOnSubmit(bri);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
