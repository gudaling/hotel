using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DataAccess;
using Hotel.Common;
using Hotel.Model;

namespace Hotel.DAL
{
    public class CallInfoDao:AbBaseDao
    {
        public List<CallModel> GetCallList(CallModel mCall,ObjectControls oCtrl)
        {
            string sql = @"SELECT A.LIST_ID, A.ROOM_ID, A.PHONE, A.STAY_ID, A.FREE_ID, A.CAT_ID, 
                                    A.START_TIME, A.END_TIME, A.CREATE_DATE, A.CREATE_USERID, B.CAT_DESC, 
                                    B.CAT_RATE, C.ROOM_NO
                                FROM CALL_LIST AS A INNER JOIN
                                        PHONE_CAT AS B ON A.CAT_ID = B.CAT_ID INNER JOIN
                                        BAS_ROOM_INFO AS C ON A.ROOM_ID = C.ROOM_ID";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone) && oCtrl.Append(ref sql, " AND A.PHONE=" + mCall.RoomInfo.RoomPhone));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayId) && oCtrl.Append(ref sql, " AND A.STAY_ID=" + mCall.StayId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFreeId) && oCtrl.Append(ref sql, " AND A.FREE_ID=" + mCall.FreeId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCatId) && oCtrl.Append(ref sql, " AND A.CAT_ID=" + mCall.PhoneCatInfo.CatId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) && oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mCall.RoomInfo.RoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomNo) && oCtrl.Append(ref sql, " AND C.ROOM_NO=" + mCall.RoomInfo.RoomNo));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByListId) && oCtrl.Append(ref sql, " AND A.LIST_ID=" + mCall.ListId));

            sdr = ExecuteReader(sql);
            using (sdr)
            {
                List<CallModel> listCall = new List<CallModel>();
                while (sdr.Read())
                {
                    CallModel mCallNew = new CallModel();
                    mCallNew.ListId = ToInt32(sdr["LIST_ID"]);
                    mCallNew.RoomInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                    mCallNew.RoomInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                    mCallNew.RoomInfo.RoomPhone = ToString(sdr["PHONE"]);
                    mCallNew.StayId = ToInt32(sdr["STAY_ID"]);
                    mCallNew.FreeId = ToInt32(sdr["FREE_ID"]);
                    mCallNew.PhoneCatInfo.CatId = ToInt32(sdr["CAT_ID"]);
                    mCallNew.PhoneCatInfo.CatDesc = ToString(sdr["CAT_DESC"]);
                    mCallNew.PhoneCatInfo.CatRate = ToDouble(sdr["CAT_RATE"]);
                    mCallNew.CommonInfo.StartDate = ToDateTime(sdr["START_TIME"]);
                    mCallNew.CommonInfo.EndDate = ToDateTime(sdr["END_TIME"]);
                    mCallNew.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mCallNew.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    listCall.Add(mCallNew);
                }
                return listCall;
            }
        }

        public int InsertCallList(CallModel mCall)
        {
            CALL_LIST cl = new CALL_LIST();
            cl.CAT_ID = mCall.PhoneCatInfo.CatId;
            cl.CREATE_DATE = GetDBTime;
            cl.CREATE_USERID = mCall.CommonInfo.CreateUserId;
            cl.END_TIME = mCall.CommonInfo.EndDate;
            cl.FREE_ID = mCall.FreeId;
            cl.PHONE = mCall.RoomInfo.RoomPhone;
            cl.ROOM_ID = mCall.RoomInfo.RoomId;
            cl.START_TIME = mCall.CommonInfo.StartDate;
            cl.STAY_ID = mCall.StayId;
            dc.CALL_LIST.InsertOnSubmit(cl);
            dc.SubmitChanges();
            return cl.LIST_ID;
        }



        public List<PhoneCatModel> GetPhoneCatList(PhoneCatModel mPhoneCat, ObjectControls oCtrl)
        {
            string sql = @"SELECT CAT_ID,CAT_DESC,CAT_RATE
                                  FROM PHONE_CAT
                                WHERE 1=1 ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCatId) && oCtrl.Append(ref sql, " AND CAT_ID=" + mPhoneCat.CatId));

            sdr = ExecuteReader(sql);
            using (sdr)
            {
                List<PhoneCatModel> listPhoneCat = new List<PhoneCatModel>();
                while (sdr.Read())
                {
                    PhoneCatModel mCatNew = new PhoneCatModel();
                    mCatNew.CatId = ToInt32(sdr["CAT_ID"]);
                    mCatNew.CatDesc = ToString(sdr["CAT_DESC"]);
                    mCatNew.CatRate = ToDouble(sdr["CAT_RATE"]);
                    listPhoneCat.Add(mCatNew);
                }
                return listPhoneCat;
            }
        }
    }
}
