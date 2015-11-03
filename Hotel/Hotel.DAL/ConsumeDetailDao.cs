using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Common;
using Hotel.Model;

namespace Hotel.DAL
{
    public class ConsumeDetailDao:AbBaseDao
    {
        public List<ConsumeDetailModel> GetConsumeList(ConsumeDetailModel mConsume, ObjectControls oCtrl)
        {
            string sql = @"SELECT CONSUME_ID,A.STAY_ID, A.GOODS_ID, A.CREATE_DATE, A.CREATE_USERID, A.UPDATE_DATE, 
                              A.UPDATE_USERID, A.UNIT_PRICE, A.NUMBER, A.TOTAL,
                              B.GOODS_NAME, B.GOODS_UNIT, B.PRICE , B.TYPE, B.STATUS, 
                              D.ROOM_NO,E.USER_NAME
                        FROM CONSUME_DETAIL AS A INNER JOIN
                              CUSTOMER_STAY_INFO AS C ON A.STAY_ID = C.STAY_ID INNER JOIN
                              BAS_GOODS_INFO AS B ON A.GOODS_ID = B.GOODS_ID
                              INNER JOIN
                              BAS_ROOM_INFO AS D ON C.ROOM_ID = D.ROOM_ID
                              INNER JOIN
                              SYS_USER_INFO AS E ON A.CREATE_USERID = E.USER_ID";
            sql += " WHERE 1=1";

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayIdGroup) && oCtrl.Append(ref sql, " AND A.STAY_ID IN (" + mConsume.StayIdGroup + ")"));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayId) && oCtrl.Append(ref sql, " AND A.STAY_ID=" + mConsume.StayId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByGoodsId) && oCtrl.Append(ref sql, " AND A.GOODS_ID=" + mConsume.GoodsId));
            sql += " ORDER BY A.CREATE_DATE";
            sdr = ExecuteReader(sql);
            List<ConsumeDetailModel> listConsumDetail = new List<ConsumeDetailModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    ConsumeDetailModel mConsumeInfo = new ConsumeDetailModel();
                    mConsumeInfo.ConsumeId = ToInt32(sdr["CONSUME_ID"]);
                    mConsumeInfo.StayId = ToInt32(sdr["STAY_ID"]);
                    mConsumeInfo.GoodsId = ToInt32(sdr["GOODS_ID"]);
                    mConsumeInfo.CommonInfo = new CommonModel();
                    mConsumeInfo.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mConsumeInfo.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mConsumeInfo.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                    mConsumeInfo.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                    mConsumeInfo.UnitPrice = ToDouble(sdr["UNIT_PRICE"]);
                    mConsumeInfo.Number = ToDouble(sdr["NUMBER"]);
                    mConsumeInfo.Total = ToDouble(sdr["TOTAL"]);
                    mConsumeInfo.GoodsInfo = new BasGoodsModel();
                    mConsumeInfo.GoodsInfo.GoodsName = ToString(sdr["GOODS_NAME"]);
                    mConsumeInfo.GoodsInfo.GoodsUnit = ToString(sdr["GOODS_UNIT"]);
                    mConsumeInfo.GoodsInfo.Price = ToDouble(sdr["PRICE"]);
                    mConsumeInfo.GoodsInfo.Type = ToChar(sdr["TYPE"]);
                    mConsumeInfo.GoodsInfo.Status = ToChar(sdr["STATUS"]);
                    mConsumeInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                    mConsumeInfo.CommonInfo.CreateUserName = ToString(sdr["USER_NAME"]);
                    listConsumDetail.Add(mConsumeInfo);
                }
            }
            return listConsumDetail;
        }

        public int InsertConsumeDetail(ConsumeDetailModel mConsume)
        {
            CONSUME_DETAIL cd = new CONSUME_DETAIL();
            cd.CREATE_DATE = mConsume.CommonInfo.CreateDate;
            cd.CREATE_USERID = mConsume.CommonInfo.CreateUserId;
            cd.GOODS_ID = mConsume.GoodsId;
            cd.NUMBER = mConsume.Number;
            cd.STAY_ID = mConsume.StayId;
            cd.TOTAL = mConsume.Total;
            cd.UNIT_PRICE = mConsume.UnitPrice;
            cd.UPDATE_DATE = GetDBTime;
            cd.UPDATE_USERID = mConsume.CommonInfo.UpdateUserId;
            dc.CONSUME_DETAIL.InsertOnSubmit(cd);
            dc.SubmitChanges();
            return cd.CONSUME_ID;
        }

        public int UpdateConsumeDetail(ConsumeDetailModel mConsume, ObjectControls oCtrl)
        {
            string sql = " UPDATE CONSUME_DETAIL SET CREATE_DATE=CREATE_DATE";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetStayId) && oCtrl.Append(ref sql, ",STAY_ID=" + SQL(mConsume.StayId)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetGoodsId) && oCtrl.Append(ref sql, ",GOODS_ID=" + SQL(mConsume.GoodsId)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetNumber) && oCtrl.Append(ref sql, ",NUMBER=" + SQL(mConsume.Number)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetUnitPrice) && oCtrl.Append(ref sql, ",UNIT_PRICE=" + SQL(mConsume.UnitPrice)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetTotal) && oCtrl.Append(ref sql, ",TOTAL=" + SQL(mConsume.Total)));
            sql += " ,UPDATE_DATE=" + SQL(GetDBTime) + ",UPDATE_USERID=" + SQL(mConsume.CommonInfo.UpdateUserId);
            return ExcuteNonQuery(sql);
        }

        public int DeleteConsumeDetail(ConsumeDetailModel mConsume)
        {
            string sql = "DELETE FROM CONSUME_DETAIL WHERE CONSUME_ID=" + mConsume.ConsumeId;
            return ExcuteNonQuery(sql);
        }
    }
}
