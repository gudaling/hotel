using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.DataAccess;
using Hotel.Model;
using Hotel.Common;
using System.Data;

namespace Hotel.DAL
{
    public class OrderInfoDao:AbBaseDao
    {
        public List<OrderInfoModel> GetOrderInfo(OrderInfoModel mOrder, ObjectControls oCtrl)
        {
            string sql = @"SELECT D.ORDER_ID,D.NAME,D.PHONE,D.ID_CARD,D.ROOM_RATE AS ORDER_RATE,D.STATUS AS ORDER_STATUS,D.START_DATE,D.END_DATE,D.KEEP_DATE,D.NOTICE,
                            D.CREATE_DATE,D.CREATE_USERID,D.UPDATE_DATE,D.UPDATE_USERID, 
                            A.ROOM_ID, A.ROOM_NO, A.ROOM_TYPE,C.CODE_DESC AS ROOM_TYPE_DESC, A.ROOM_RATES, A.STATUS AS ROOM_STATUS, 
                             A.ROOM_PHONE,B.FLOOR_ID, B.FLOOR_NAME, B.STATUS AS FLOOR_STATUS

                             FROM ORDER_INFO D INNER JOIN
							BAS_ROOM_INFO AS A ON D.ROOM_ID=A.ROOM_ID INNER JOIN
                             BAS_FLOOR_INFO AS B ON A.FLOOR_ID = B.FLOOR_ID
                            INNER JOIN SYS_LOOKUP_CODE AS C ON A.ROOM_TYPE=C.CODE_NO AND C.TABLE_NAME='BAS_ROOM_INFO'
                             AND C.COLUMN_NAME='ROOM_TYPE' ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) && oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mOrder.RoomInfo.RoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomNo) && oCtrl.Append(ref sql, " AND A.ROOM_NO=" + SQL(mOrder.RoomInfo.RoomNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatus) && oCtrl.Append(ref sql, " AND A.STATUS=" + SQL(mOrder.RoomInfo.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatusGroup) && oCtrl.Append(ref sql, " AND A.STATUS IN (" + mOrder.RoomInfo.StatusGroup + ")"));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomType) && oCtrl.Append(ref sql, " AND A.ROOM_TYPE=" + SQL(mOrder.RoomInfo.RoomType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorId) && oCtrl.Append(ref sql, " AND B.FLOOR_ID=" + mOrder.RoomInfo.FloorInfo.FloorId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorName) && oCtrl.Append(ref sql, " AND B.FLOOR_NAME=" + SQL(mOrder.RoomInfo.FloorInfo.FloorName)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStartDateBetween) && oCtrl.Append(ref sql, " AND D.START_DATE BETWEEN " + SQL(mOrder.CommonInfo.StartDate) + " AND " + SQL(mOrder.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByEndDateBetween) && oCtrl.Append(ref sql, " AND D.END_DATE BETWEEN " + SQL(mOrder.CommonInfo.StartDate) + " AND " + SQL(mOrder.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByKeepDateEnable) && oCtrl.Append(ref sql, " AND D.KEEP_DATE >= " + SQL(mOrder.KeepDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByKeepDateDisable) && oCtrl.Append(ref sql, " AND D.KEEP_DATE < " + SQL(mOrder.KeepDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByOrderStatus) && oCtrl.Append(ref sql, " AND D.STATUS=" + SQL(mOrder.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByIdCard) && oCtrl.Append(ref sql, " AND D.ID_CARD=" + SQL(mOrder.IdCardNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByName) && oCtrl.Append(ref sql, " AND D.NAME=" + SQL(mOrder.Name)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone) && oCtrl.Append(ref sql, " AND D.PHONE=" + SQL(mOrder.Phone)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByNPR) && oCtrl.Append(ref sql, " AND (D.NAME LIKE " + SQLL(mOrder.Name) + " OR D.PHONE LIKE " + SQLL(mOrder.Name) + " OR A.ROOM_NO LIKE " + SQLL(mOrder.Name)+")"));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByOrderId) && oCtrl.Append(ref sql, " AND  D.ORDER_ID=" + mOrder.OrderId));
            sql += " ORDER BY D.CREATE_DATE DESC";
            sdr = ExecuteReader(sql);
            List<OrderInfoModel> listOrderInfo = new List<OrderInfoModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    OrderInfoModel mOrderInfo = new OrderInfoModel();
                    mOrderInfo.OrderId = ToInt32(sdr["ORDER_ID"]);
                    mOrderInfo.Name = ToString(sdr["NAME"]);
                    mOrderInfo.Phone = ToString(sdr["PHONE"]);
                    mOrderInfo.IdCardNo = ToString(sdr["ID_CARD"]);
                    mOrderInfo.OrderRoomRate = ToDouble(sdr["ORDER_RATE"]);
                    mOrderInfo.CommonInfo = new CommonModel();
                    mOrderInfo.CommonInfo.StartDate = ToDateTime(sdr["START_DATE"]);
                    mOrderInfo.CommonInfo.EndDate = ToDateTime(sdr["END_DATE"]);
                    mOrderInfo.KeepDate = ToDateTime(sdr["KEEP_DATE"]);
                    mOrderInfo.Notice = ToString(sdr["NOTICE"]);
                    mOrderInfo.Status = ToChar(sdr["ORDER_STATUS"]);
                    mOrderInfo.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mOrderInfo.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mOrderInfo.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                    mOrderInfo.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                    mOrderInfo.RoomInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                    mOrderInfo.RoomInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                    mOrderInfo.RoomInfo.RoomPhone = ToString(sdr["ROOM_PHONE"]);
                    mOrderInfo.RoomInfo.RoomRate = ToDouble(sdr["ROOM_RATES"]);
                    mOrderInfo.RoomInfo.RoomType = ToChar(sdr["ROOM_TYPE"]);
                    mOrderInfo.RoomInfo.RoomTypeDesc = ToString(sdr["ROOM_TYPE_DESC"]);
                    mOrderInfo.RoomInfo.Status = ToChar(sdr["ROOM_STATUS"]);
                    mOrderInfo.RoomInfo.FloorInfo = new BasFloorModel();
                    mOrderInfo.RoomInfo.FloorInfo.FloorId = ToInt32(sdr["FLOOR_ID"]);
                    mOrderInfo.RoomInfo.FloorInfo.FloorName = ToString(sdr["FLOOR_NAME"]);
                    mOrderInfo.RoomInfo.FloorInfo.Status = ToChar(sdr["FLOOR_STATUS"]);
                    listOrderInfo.Add(mOrderInfo);
                }
            }
            return listOrderInfo;
        }

        public DataSet GetOrderInfoDs(OrderInfoModel mOrder, ObjectControls oCtrl)
        {
            string sql = @"SELECT D.ORDER_ID,D.NAME,D.PHONE,D.ID_CARD,D.ROOM_RATE AS ORDER_RATE,D.STATUS AS ORDER_STATUS,D.START_DATE,D.END_DATE,D.KEEP_DATE,D.NOTICE,
                            D.CREATE_DATE,D.CREATE_USERID,D.UPDATE_DATE,D.UPDATE_USERID, 
                            A.ROOM_ID, A.ROOM_NO, A.ROOM_TYPE,C.CODE_DESC AS ROOM_TYPE_DESC, A.ROOM_RATES, A.STATUS AS ROOM_STATUS, 
                             A.ROOM_PHONE,B.FLOOR_ID, B.FLOOR_NAME, B.STATUS AS FLOOR_STATUS

                             FROM ORDER_INFO D INNER JOIN
							BAS_ROOM_INFO AS A ON D.ROOM_ID=A.ROOM_ID INNER JOIN
                             BAS_FLOOR_INFO AS B ON A.FLOOR_ID = B.FLOOR_ID
                            INNER JOIN SYS_LOOKUP_CODE AS C ON A.ROOM_TYPE=C.CODE_NO AND C.TABLE_NAME='BAS_ROOM_INFO'
                             AND C.COLUMN_NAME='ROOM_TYPE' ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) && oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mOrder.RoomInfo.RoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomNo) && oCtrl.Append(ref sql, " AND A.ROOM_NO=" + SQL(mOrder.RoomInfo.RoomNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatus) && oCtrl.Append(ref sql, " AND A.STATUS=" + SQL(mOrder.RoomInfo.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStatusGroup) && oCtrl.Append(ref sql, " AND A.STATUS IN (" + mOrder.RoomInfo.StatusGroup + ")"));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomType) && oCtrl.Append(ref sql, " AND A.ROOM_TYPE=" + SQL(mOrder.RoomInfo.RoomType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorId) && oCtrl.Append(ref sql, " AND B.FLOOR_ID=" + mOrder.RoomInfo.FloorInfo.FloorId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorName) && oCtrl.Append(ref sql, " AND B.FLOOR_NAME=" + SQL(mOrder.RoomInfo.FloorInfo.FloorName)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStartDateBetween) && oCtrl.Append(ref sql, " AND D.START_DATE BETWEEN " + SQL(mOrder.CommonInfo.StartDate) + " AND " + SQL(mOrder.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByEndDateBetween) && oCtrl.Append(ref sql, " AND D.END_DATE BETWEEN " + SQL(mOrder.CommonInfo.StartDate) + " AND " + SQL(mOrder.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByKeepDateEnable) && oCtrl.Append(ref sql, " AND D.KEEP_DATE >= " + SQL(mOrder.KeepDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByKeepDateDisable) && oCtrl.Append(ref sql, " AND D.KEEP_DATE < " + SQL(mOrder.KeepDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByOrderStatus) && oCtrl.Append(ref sql, " AND D.STATUS=" + SQL(mOrder.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByIdCard) && oCtrl.Append(ref sql, " AND D.ID_CARD=" + SQL(mOrder.IdCardNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByName) && oCtrl.Append(ref sql, " AND D.NAME=" + SQL(mOrder.Name)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone) && oCtrl.Append(ref sql, " AND D.PHONE=" + SQL(mOrder.Phone)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByNPR) && oCtrl.Append(ref sql, " AND (D.NAME LIKE " + SQLL(mOrder.Name) + " OR D.PHONE LIKE " + SQLL(mOrder.Name) + " OR A.ROOM_NO LIKE " + SQLL(mOrder.Name) + ")"));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByOrderId) && oCtrl.Append(ref sql, " AND  D.ORDER_ID=" + mOrder.OrderId));
            sql += " ORDER BY D.CREATE_DATE DESC";
            return ExecuteDataSet(sql);
        }

        public int InsertOrderInfo(OrderInfoModel mOrder)
        {
            ORDER_INFO oi = new ORDER_INFO();
            oi.CREATE_DATE = GetDBTime;
            oi.CREATE_USERID = mOrder.CommonInfo.CreateUserId;
            oi.END_DATE = mOrder.CommonInfo.EndDate;
            oi.ID_CARD = mOrder.IdCardNo;
            oi.KEEP_DATE = mOrder.KeepDate;
            oi.NAME = mOrder.Name;
            oi.NOTICE = mOrder.Notice;
            oi.PHONE = mOrder.Phone;
            oi.STATUS = mOrder.Status;
            oi.ROOM_ID = mOrder.RoomInfo.RoomId;
            oi.ROOM_RATE = mOrder.OrderRoomRate;
            oi.START_DATE = mOrder.CommonInfo.StartDate;
            oi.UPDATE_DATE = oi.CREATE_DATE;
            oi.UPDATE_USERID = mOrder.CommonInfo.UpdateUserId;
            dc.ORDER_INFO.InsertOnSubmit(oi);
            dc.SubmitChanges();
            return oi.ORDER_ID;
        }

        public int UpdateOrderInfo(OrderInfoModel mOrder, ObjectControls oCtrl)
        {
            string sql = " UPDATE ORDER_INFO SET CREATE_DATE=CREATE_DATE";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetName) && oCtrl.Append(ref sql, ",NAME=" + SQL(mOrder.Name)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetIdCard) && oCtrl.Append(ref sql, ",ID_CARD=" + SQL(mOrder.IdCardNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetPhone) && oCtrl.Append(ref sql, ",PHONE=" + SQL(mOrder.Phone)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetStartDate) && oCtrl.Append(ref sql, ",START_DATE=" + SQL(mOrder.CommonInfo.StartDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetEndDate) && oCtrl.Append(ref sql, ",END_DATE=" + SQL(mOrder.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetKeepDate) && oCtrl.Append(ref sql, ",KEEP_DATE=" + SQL(mOrder.KeepDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomId) && oCtrl.Append(ref sql, ",ROOM_ID=" + SQL(mOrder.RoomInfo.RoomId)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomRate) && oCtrl.Append(ref sql, ",ROOM_RATE=" + SQL(mOrder.OrderRoomRate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetNotice) && oCtrl.Append(ref sql, ",NOTICE=" + SQL(mOrder.Notice)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetOrderStatus) && oCtrl.Append(ref sql, ",STATUS=" + SQL(mOrder.Status)));

            sql += ",UPDATE_DATE=" + SQL(GetDBTime);
            sql += ",UPDATE_USERID=" + SQL(mOrder.CommonInfo.UpdateUserId);
            sql += " WHERE ORDER_ID=" + mOrder.OrderId;
            return ExcuteNonQuery(sql);
        }

        public int DeleteOrder(OrderInfoModel mOrder)
        {
            string sql = "DELETE FROM ORDER_INFO WHERE ORDER_ID=" + mOrder.OrderId;
            return ExcuteNonQuery(sql);
        }
    }
}
