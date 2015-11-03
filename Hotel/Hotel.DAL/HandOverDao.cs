using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Common;
using Hotel.DataAccess;
using Hotel.Model;

namespace Hotel.DAL
{
    public class HandOverDao : AbBaseDao
    {
        public List<HandOverModel> GetHandOverList(HandOverModel mHandOver,ObjectControls oCtrl)
        {
            string sql = @"SELECT A.HAND_OVER_ID, A.C_USER_ID, A.N_USER_ID, A.START_DATE, A.END_DATE, 
                            A.FROM_LAST_MONEY, A.HAND_OVER_MONEY, A.HAND_IN_MONEY, 
                             A.CURRENT_DEPOSIT, A.CURRENT_PAID,A.TO_NEXT_MONEY, A.CREATE_DATE, 
                              A.CREATE_USERID,B.USER_NAME C_USER_NAME,B.USER_NO C_USER_NO,C.USER_NAME N_USER_NAME,
                            C.USER_NO N_USER_NO FROM HAND_OVER_INFO A,SYS_USER_INFO B,
                            SYS_USER_INFO C WHERE A.C_USER_ID=B.USER_ID AND A.N_USER_ID=C.USER_ID";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHandOverId) && oCtrl.Append(ref sql, " AND A.HAND_OVER_ID=" + mHandOver.HandOverId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCUserId) && oCtrl.Append(ref sql, " AND A.C_USER_ID=" + mHandOver.CurrentUserInfo.UserId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByNUserId) && oCtrl.Append(ref sql, " AND A.N_USER_ID=" + mHandOver.NextUserInfo.UserId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCreateDate) && oCtrl.Append(ref sql, " AND A.CREATE_DATE BETWEEN " + SQL(mHandOver.CommonInfo.StartDate) + " AND " + SQL(mHandOver.CommonInfo.EndDate)));

            sdr = ExecuteReader(sql);
            using (sdr)
            {
                List<HandOverModel> listHandOver = new List<HandOverModel>();
                while (sdr.Read())
                {
                    HandOverModel mHandOverNew = new HandOverModel();
                    mHandOverNew.HandOverId = ToInt32(sdr["HAND_OVER_ID"]);
                    mHandOverNew.CurrentUserInfo.UserId = ToInt32(sdr["C_USER_ID"]);
                    mHandOverNew.CurrentUserInfo.UserName = ToString(sdr["C_USER_NAME"]);
                    mHandOverNew.CurrentUserInfo.UserNo = ToString(sdr["C_USER_NO"]);
                    mHandOverNew.NextUserInfo.UserId = ToInt32(sdr["N_USER_ID"]);
                    mHandOverNew.NextUserInfo.UserName = ToString(sdr["N_USER_NAME"]);
                    mHandOverNew.NextUserInfo.UserNo = ToString(sdr["N_USER_NO"]);
                    mHandOverNew.CommonInfo.StartDate = ToDateTime(sdr["START_DATE"]);
                    mHandOverNew.CommonInfo.EndDate = ToDateTime(sdr["END_DATE"]);
                    mHandOverNew.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mHandOverNew.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mHandOverNew.HandOverMoney = ToDouble(sdr["HAND_OVER_MONEY"]);
                    mHandOverNew.HandInMoney = ToDouble(sdr["HAND_IN_MONEY"]);
                    mHandOverNew.CurrentPaidMoney = ToDouble(sdr["CURRENT_PAID"]);
                    mHandOverNew.CurrentDeposit = ToDouble(sdr["CURRENT_DEPOSIT"]);
                    mHandOverNew.FromLastMoney = ToDouble(sdr["FROM_LAST_MONEY"]);
                    mHandOverNew.ToNextMoney = ToDouble(sdr["TO_NEXT_MONEY"]);
                    listHandOver.Add(mHandOverNew);
                }
                return listHandOver;
            }
        }

        public int GetHandOverLatestId()
        {
            string sql = "SELECT MAX(HAND_OVER_ID) FROM HAND_OVER_INFO";
            return ToInt32(ExecuteScalar(sql));
        }

        public int InsertHandOver(HandOverModel mHandOver)
        {
            HAND_OVER_INFO hoi = new HAND_OVER_INFO();
            hoi.C_USER_ID = mHandOver.CurrentUserInfo.UserId;
            hoi.CREATE_DATE = GetDBTime;
            hoi.CREATE_USERID = mHandOver.CommonInfo.CreateUserId;
            hoi.CURRENT_DEPOSIT = mHandOver.CurrentDeposit;
            hoi.CURRENT_PAID = mHandOver.CurrentPaidMoney;
            hoi.FROM_LAST_MONEY = mHandOver.FromLastMoney;
            hoi.END_DATE = mHandOver.CommonInfo.EndDate;
            hoi.HAND_IN_MONEY = mHandOver.HandInMoney;
            hoi.HAND_OVER_MONEY = mHandOver.HandOverMoney;
            hoi.N_USER_ID = mHandOver.NextUserInfo.UserId;
            hoi.START_DATE = mHandOver.CommonInfo.StartDate;
            hoi.TO_NEXT_MONEY = mHandOver.ToNextMoney;
            dc.HAND_OVER_INFO.InsertOnSubmit(hoi);
            dc.SubmitChanges();
            return hoi.HAND_OVER_ID;
        }

        public int UpdateHandOver(HandOverModel mHandOver, ObjectControls oCtrl)
        {
            string sql = "UPDATE HAND_OVER_INFO SET CREATE_DATE=CREATE_DATE";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetCUserId) && oCtrl.Append(ref sql, " ,C_USER_ID=" + mHandOver.NextUserInfo.UserId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetNUserId) && oCtrl.Append(ref sql, " ,N_USER_ID=" + mHandOver.NextUserInfo.UserId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetHandInMoney) && oCtrl.Append(ref sql, " ,HAND_IN_MONEY=" + SQL(mHandOver.HandInMoney)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetHandOverMoney) && oCtrl.Append(ref sql, " ,HAND_OVER_MONEY=" + SQL(mHandOver.HandOverMoney)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetPaidMoney) && oCtrl.Append(ref sql, " ,CURRENT_PAID=" + SQL(mHandOver.CurrentPaidMoney)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetDeposit) && oCtrl.Append(ref sql, " ,CURRENT_DEPOSIT=" + SQL(mHandOver.CurrentDeposit)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetStartDate) && oCtrl.Append(ref sql, " ,START_DATE=" + SQL(mHandOver.CommonInfo.StartDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetEndDate) && oCtrl.Append(ref sql, " ,END_DATE=" + SQL(mHandOver.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetCurrentIncome) && oCtrl.Append(ref sql, " ,FROM_LAST_MONEY=" + SQL(mHandOver.FromLastMoney)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetToNextMoney) && oCtrl.Append(ref sql, " ,TO_NEXT_MONEY=" +SQL(mHandOver.ToNextMoney)));

            return ExcuteNonQuery(sql);
        }

        public int DeleteHandOver(HandOverModel mHandOver)
        {
            string sql = "DELETE FROM HAND_OVER_INFO WHERE HAND_OVER_ID="+mHandOver.HandOverId;
            return ExcuteNonQuery(sql);
        }
    }
}
