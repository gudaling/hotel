using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;

namespace Hotel.DAL
{
    public class CustomerStayDao:AbBaseDao
    {
        public CustomerStayModel GetCustomerStayInfo(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            string sql = @"SELECT A.STAY_ID,A.STAY_NO, A.ROOM_ID, A.MAIN_ROOM_ID, A.ROOM_STAY_TYPE,
                      A.START_DATE, A.END_DATE,A.HOURS, A.DEPOSIT, A.ROOM_RATES AS CURRENT_RATE,A.PAID_MONEY, A.PAY_TYPE,A.TOTAL_MONEY, A.STATUS, 
                      A.NOTICE, A.CREATE_DATE, A.CREATE_USERID,F.USER_NAME AS CREATE_USER_NAME,G.USER_NAME AS UPDATE_USER_NAME, A.UPDATE_DATE, 
                      A.UPDATE_USERID, B.CUSTOMER_ID, B.ID_CARD, B.NAME, B.SEX, B.NATION, 
                      B.BIRTHDAY, B.ADDRESS, B.COMPANY, B.PHONE, B.PICTURE, B.TYPE, E.STAY_TYPE,E.HIS_STATUS,E.HIS_ID,
                        E.START_TIME,E.END_TIME,
                      C.ROOM_NO, C.ROOM_TYPE, C.ROOM_RATES AS DEFAULT_RATE, C.ROOM_NOTICE,
                      C.ROOM_PHONE, C.STATUS AS ROOM_STATUS, C.FLOOR_ID,D.FLOOR_NAME
                     FROM CUSTOMER_STAY_INFO AS A INNER JOIN
                      CUSTOMER_STAY_HIS E ON A.STAY_ID =E.STAY_ID";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayType) && oCtrl.Append(ref sql, " AND E.STAY_TYPE=" + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.StayType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStatus) && oCtrl.Append(ref sql, " AND E.HIS_STATUS=" + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.HisStatus)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStatusNotEqual) && oCtrl.Append(ref sql, " AND E.HIS_STATUS !=" + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.HisStatus)));

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStartTime) && oCtrl.Append(ref sql, " AND E.START_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate) + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisEndTime) && oCtrl.Append(ref sql, " AND E.END_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate) + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate)));

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStartOrEndTime) && oCtrl.Append(ref sql, " AND (E.START_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate)
                + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate)
                + " OR E.END_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate)
                + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate) + ")"));
            sql += @" INNER JOIN
                      CUSTOMER_INFO AS B ON E.CUSTOMER_ID = B.CUSTOMER_ID ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByName) && oCtrl.Append(ref sql, " AND B.NAME=" + SQL(mCustomerStay.CustomerList[0].Name)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone) && oCtrl.Append(ref sql, " AND B.PHONE=" + SQL(mCustomerStay.CustomerList[0].Phone)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCustomerType) && oCtrl.Append(ref sql, " AND B.TYPE=" + SQL(mCustomerStay.CustomerList[0].Type)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCustomerId) && oCtrl.Append(ref sql, " AND B.CUSTOMER_ID=" + mCustomerStay.CustomerList[0].CustomerId));
            sql+=@" INNER JOIN
                      BAS_ROOM_INFO AS C ON A.ROOM_ID = C.ROOM_ID INNER JOIN
                       SYS_USER_INFO AS F ON A.CREATE_USERID = F.USER_ID INNER JOIN
                    SYS_USER_INFO AS G ON A.UPDATE_USERID = G.USER_ID INNER JOIN
                      BAS_FLOOR_INFO AS D ON C.FLOOR_ID = D.FLOOR_ID";
            sql += " WHERE 1=1";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) &&  oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mCustomerStay.RoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorId) &&  oCtrl.Append(ref sql, " AND D.FLOOR_ID=" + mCustomerStay.RoomInfo.FloorInfo.FloorId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomNo) &&  oCtrl.Append(ref sql, " AND C.ROOM_NO=" + SQL(mCustomerStay.RoomInfo.RoomNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStartDate) &&  oCtrl.Append(ref sql, " AND A.START_DATE=" + SQL(mCustomerStay.CommonInfo.StartDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByEndDate)&& oCtrl.Append(ref sql, " AND A.END_DATE=" + SQL(mCustomerStay.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayStatus) &&  oCtrl.Append(ref sql, " AND A.STATUS=" + SQL(mCustomerStay.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStayType) && oCtrl.Append(ref sql, " AND A.ROOM_STAY_TYPE=" + mCustomerStay.RoomStayType));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayNo) && oCtrl.Append(ref sql, " AND A.STAY_NO=" + mCustomerStay.StayNo));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayId) &&  oCtrl.Append(ref sql, " AND A.STAY_ID=" + mCustomerStay.StayId));

            sdr = ExecuteReader(sql);
           
            using (sdr)
            {
                if (!sdr.HasRows)
                {
                    return null;
                }
                CustomerStayModel mCustomerStayInfo = new CustomerStayModel();
                mCustomerStayInfo.CustomerList = new List<CustomerModel>();
                while(sdr.Read())
                {
                    mCustomerStayInfo.CommonInfo = new CommonModel();
                    mCustomerStayInfo.StayNo = ToString(sdr["STAY_NO"]);
                    mCustomerStayInfo.StayId = ToInt32(sdr["STAY_ID"]);
                    mCustomerStayInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                    mCustomerStayInfo.MainRoomId = ToInt32(sdr["MAIN_ROOM_ID"]);
                    mCustomerStayInfo.CommonInfo.StartDate = ToDateTime(sdr["START_DATE"]);
                    mCustomerStayInfo.CommonInfo.EndDate = ToDateTime(sdr["END_DATE"]);
                    mCustomerStayInfo.Deposit = ToDouble(sdr["DEPOSIT"]);
                    mCustomerStayInfo.RoomRate = ToInt32(sdr["CURRENT_RATE"]);
                    mCustomerStayInfo.Total = ToDouble(sdr["TOTAL_MONEY"]);
                    mCustomerStayInfo.PayType = ToChar(sdr["PAY_TYPE"]);
                    mCustomerStayInfo.Status = ToChar(sdr["STATUS"]);
                    mCustomerStayInfo.Notice = ToString(sdr["NOTICE"]);
                    mCustomerStayInfo.Hours = ToInt32(sdr["HOURS"]);
                    mCustomerStayInfo.RoomStayType = ToChar(sdr["ROOM_STAY_TYPE"]);
                    mCustomerStayInfo.PaidMoney = ToDouble(sdr["PAID_MONEY"]);
                    mCustomerStayInfo.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mCustomerStayInfo.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mCustomerStayInfo.CommonInfo.CreateUserName = ToString(sdr["CREATE_USER_NAME"]);
                    mCustomerStayInfo.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                    mCustomerStayInfo.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                    mCustomerStayInfo.CommonInfo.UpateUserName = ToString(sdr["UPDATE_USER_NAME"]);

                    CustomerModel mCustomerInfo = new CustomerModel();
                    mCustomerInfo.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                    mCustomerInfo.IdCardNo = ToString(sdr["ID_CARD"]);
                    mCustomerInfo.Name = ToString(sdr["NAME"]);
                    mCustomerInfo.Nation = ToString(sdr["NATION"]);
                    mCustomerInfo.Phone = ToString(sdr["PHONE"]);
                    mCustomerInfo.Picture = ToString(sdr["PICTURE"]);
                    mCustomerInfo.Type = ToChar(sdr["TYPE"]);
                    mCustomerInfo.Sex = ToString(sdr["SEX"]);
                    mCustomerInfo.Birthday = ToDateTime(sdr["BIRTHDAY"]);
                    mCustomerInfo.Address = ToString(sdr["ADDRESS"]);
                    mCustomerInfo.Company = ToString(sdr["COMPANY"]);

                    mCustomerInfo.CustomerStayHisInfo = new CustomerStayHisModel();
                    mCustomerInfo.CustomerStayHisInfo.HisId = ToInt32(sdr["HIS_ID"]);
                    mCustomerInfo.CustomerStayHisInfo.StayId = ToInt32(sdr["STAY_ID"]);
                    mCustomerInfo.CustomerStayHisInfo.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                    mCustomerInfo.CustomerStayHisInfo.StayType = ToChar(sdr["STAY_TYPE"]);
                    mCustomerInfo.CustomerStayHisInfo.HisStatus = ToChar(sdr["HIS_STATUS"]);
                    mCustomerInfo.CustomerStayHisInfo.CommonInfo.StartDate = ToDateTime(sdr["START_TIME"]);
                    mCustomerInfo.CustomerStayHisInfo.CommonInfo.EndDate = ToDateTime(sdr["END_TIME"]);
                    mCustomerInfo.CommonInfo = new CommonModel();
                    mCustomerStayInfo.CustomerList.Add(mCustomerInfo);

                    mCustomerStayInfo.RoomInfo = new BasRoomModel();
                    mCustomerStayInfo.RoomInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                    mCustomerStayInfo.RoomInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                    mCustomerStayInfo.RoomInfo.RoomType = ToChar(sdr["ROOM_TYPE"]);
                    mCustomerStayInfo.RoomInfo.RoomRate = ToDouble(sdr["DEFAULT_RATE"]);
                    mCustomerStayInfo.RoomInfo.RoomPhone = ToString(sdr["ROOM_PHONE"]);
                    mCustomerStayInfo.RoomInfo.Status = ToChar(sdr["ROOM_STATUS"]);
                    mCustomerStayInfo.RoomInfo.RoomNotice = ToString(sdr["ROOM_NOTICE"]);
                    mCustomerStayInfo.RoomInfo.FloorInfo = new BasFloorModel();
                    mCustomerStayInfo.RoomInfo.FloorInfo.FloorId = ToInt32(sdr["FLOOR_ID"]);
                    mCustomerStayInfo.RoomInfo.FloorInfo.FloorName = ToString(sdr["FLOOR_NAME"]);
                }
                return mCustomerStayInfo;
            }
        }

        public List<CustomerStayModel> GetMainRoomGroup()
        {
            string sql = @"SELECT DISTINCT A.MAIN_ROOM_ID,B.NAME,D.ROOM_NO,B.CUSTOMER_ID 
                                FROM CUSTOMER_STAY_INFO A,CUSTOMER_INFO B,CUSTOMER_STAY_HIS C,BAS_ROOM_INFO D 
                                WHERE A.STAY_ID=C.STAY_ID AND C.CUSTOMER_ID=B.CUSTOMER_ID 
                                AND A.MAIN_ROOM_ID=D.ROOM_ID 
                                AND A.STATUS='I' 
                                AND C.HIS_STATUS='E' 
                                AND C.STAY_TYPE='M' 
                                AND MAIN_ROOM_ID>0";
            sdr = ExecuteReader(sql);
            List<CustomerStayModel> listTeamRoom = new List<CustomerStayModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    CustomerStayModel mCustomerStay = new CustomerStayModel();
                    mCustomerStay.MainRoomId = ToInt32(sdr["MAIN_ROOM_ID"]);
                    mCustomerStay.RoomInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                    mCustomerStay.CustomerList = new List<CustomerModel>();
                    CustomerModel mc = new CustomerModel();
                    mc.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                    mc.Name = ToString(sdr["NAME"]);
                    mCustomerStay.CustomerList.Add(mc);
                    listTeamRoom.Add(mCustomerStay);
                }
            }
            return listTeamRoom;
        }

        public List<CustomerStayModel> GetCustomerStayList(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            string sql = @"SELECT A.STAY_ID,A.STAY_NO, A.ROOM_ID, A.MAIN_ROOM_ID, A.ROOM_STAY_TYPE,
                      A.START_DATE, A.END_DATE,A.HOURS, A.DEPOSIT, A.ROOM_RATES AS CURRENT_RATE,A.PAID_MONEY, A.PAY_TYPE, A.STATUS, A.TOTAL_MONEY, 
                      A.NOTICE, A.CREATE_DATE, A.CREATE_USERID,F.USER_NAME AS CREATE_USER_NAME,G.USER_NAME AS UPDATE_USER_NAME, A.UPDATE_DATE, 
                      A.UPDATE_USERID, B.CUSTOMER_ID, B.ID_CARD, B.NAME, B.SEX, B.NATION, 
                      B.BIRTHDAY, B.ADDRESS, B.COMPANY, B.PHONE, B.PICTURE, B.TYPE, E.STAY_TYPE,E.HIS_STATUS,E.HIS_ID,
                        E.START_TIME,E.END_TIME,
                      C.ROOM_NO, C.ROOM_TYPE, C.ROOM_RATES AS DEFAULT_RATE, C.ROOM_NOTICE,
                      C.ROOM_PHONE, C.STATUS AS ROOM_STATUS, C.FLOOR_ID,D.FLOOR_NAME
                     FROM CUSTOMER_STAY_INFO AS A INNER JOIN
                      CUSTOMER_STAY_HIS E ON A.STAY_ID =E.STAY_ID";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayType) && oCtrl.Append(ref sql, " AND E.STAY_TYPE=" + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.StayType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStatus) && oCtrl.Append(ref sql, " AND E.HIS_STATUS=" + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.HisStatus)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStatusNotEqual) && oCtrl.Append(ref sql, " AND E.HIS_STATUS !=" + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.HisStatus)));

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStartTime) && oCtrl.Append(ref sql, " AND E.START_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate) + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisEndTime) && oCtrl.Append(ref sql, " AND E.END_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate) + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate)));

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStartOrEndTime) && oCtrl.Append(ref sql, " AND (E.START_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate) 
                + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate) 
                + " OR E.END_TIME BETWEEN " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.StartDate) 
                + " AND " + SQL(mCustomerStay.CustomerList[0].CustomerStayHisInfo.CommonInfo.EndDate) + ")"));

            sql += @" INNER JOIN
                      CUSTOMER_INFO AS B ON E.CUSTOMER_ID = B.CUSTOMER_ID ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByName) && oCtrl.Append(ref sql, " AND B.NAME=" + SQL(mCustomerStay.CustomerList[0].Name)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone) && oCtrl.Append(ref sql, " AND B.PHONE=" + SQL(mCustomerStay.CustomerList[0].Phone)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCustomerType) && oCtrl.Append(ref sql, " AND B.TYPE=" + SQL(mCustomerStay.CustomerList[0].Type)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCustomerId) && oCtrl.Append(ref sql, " AND B.CUSTOMER_ID=" + mCustomerStay.CustomerList[0].CustomerId));
            sql += @" INNER JOIN
                      BAS_ROOM_INFO AS C ON A.ROOM_ID = C.ROOM_ID INNER JOIN
                       SYS_USER_INFO AS F ON A.CREATE_USERID = F.USER_ID INNER JOIN
                    SYS_USER_INFO AS G ON A.UPDATE_USERID = G.USER_ID INNER JOIN
                      BAS_FLOOR_INFO AS D ON C.FLOOR_ID = D.FLOOR_ID";
            sql += " WHERE 1=1";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomId) && oCtrl.Append(ref sql, " AND A.ROOM_ID=" + mCustomerStay.RoomId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomIdGroup) && oCtrl.Append(ref sql, " AND A.ROOM_ID IN (" + mCustomerStay.RoomInfo.RoomIdGroup + ")"));

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByFloorId) && oCtrl.Append(ref sql, " AND D.FLOOR_ID=" + mCustomerStay.RoomInfo.FloorInfo.FloorId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomNo) && oCtrl.Append(ref sql, " AND C.ROOM_NO=" + SQL(mCustomerStay.RoomInfo.RoomNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByNPR) && oCtrl.Append(ref sql, " AND C.ROOM_NO LIKE " + SQLL(mCustomerStay.RoomInfo.RoomNo) + " OR B.NAME LIKE " + SQLL(mCustomerStay.CustomerList[0].Name)));

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStartDate) && oCtrl.Append(ref sql, " AND A.START_DATE=" + SQL(mCustomerStay.CommonInfo.StartDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByEndDate) && oCtrl.Append(ref sql, " AND A.END_DATE=" + SQL(mCustomerStay.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCreateDate) && oCtrl.Append(ref sql, " AND A.CREATE_DATE BETWEEN " + SQL(mCustomerStay.CommonInfo.StartDate) + " AND " + SQL(mCustomerStay.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByUpdateDate) && oCtrl.Append(ref sql, " AND A.UPDATE_DATE BETWEEN " + SQL(mCustomerStay.CommonInfo.StartDate) + " AND " + SQL(mCustomerStay.CommonInfo.EndDate)));

            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayStatus) && oCtrl.Append(ref sql, " AND A.STATUS=" + SQL(mCustomerStay.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByRoomStayType) && oCtrl.Append(ref sql, " AND A.ROOM_STAY_TYPE=" + mCustomerStay.RoomStayType));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayNo) && oCtrl.Append(ref sql, " AND A.STAY_NO=" + mCustomerStay.StayNo));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayId) && oCtrl.Append(ref sql, " AND A.STAY_ID=" + mCustomerStay.StayId));

            sdr = ExecuteReader(sql);

            using (sdr)
            {
                List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();
                while (sdr.Read())
                {
                    var q = listCustomerStay.Where(c => c.StayId == ToInt32(sdr["STAY_ID"]));
                    if (q.Count() > 0)
                    {
                        CustomerModel mCustomerInfo = new CustomerModel();
                        mCustomerInfo.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                        mCustomerInfo.IdCardNo = ToString(sdr["ID_CARD"]);
                        mCustomerInfo.Name = ToString(sdr["NAME"]);
                        mCustomerInfo.Nation = ToString(sdr["NATION"]);
                        mCustomerInfo.Phone = ToString(sdr["PHONE"]);
                        mCustomerInfo.Picture = ToString(sdr["PICTURE"]);
                        mCustomerInfo.Type = ToChar(sdr["TYPE"]);
                        mCustomerInfo.Sex = ToString(sdr["SEX"]);
                        mCustomerInfo.Birthday = ToDateTime(sdr["BIRTHDAY"]);
                        mCustomerInfo.Address = ToString(sdr["ADDRESS"]);
                        mCustomerInfo.Company = ToString(sdr["COMPANY"]);
                        mCustomerInfo.CustomerStayHisInfo = new CustomerStayHisModel();
                        mCustomerInfo.CustomerStayHisInfo.HisId = ToInt32(sdr["HIS_ID"]);
                        mCustomerInfo.CustomerStayHisInfo.StayId = ToInt32(sdr["STAY_ID"]);
                        mCustomerInfo.CustomerStayHisInfo.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                        mCustomerInfo.CustomerStayHisInfo.StayType = ToChar(sdr["STAY_TYPE"]);
                        mCustomerInfo.CustomerStayHisInfo.HisStatus = ToChar(sdr["HIS_STATUS"]);
                        mCustomerInfo.CustomerStayHisInfo.CommonInfo.StartDate = ToDateTime(sdr["START_TIME"]);
                        mCustomerInfo.CustomerStayHisInfo.CommonInfo.EndDate = ToDateTime(sdr["END_TIME"]);
                        mCustomerInfo.CommonInfo = new CommonModel();
                        q.First().CustomerList.Add(mCustomerInfo);
                    }
                    else
                    {
                        CustomerStayModel mCustomerStayInfo = new CustomerStayModel();
                        mCustomerStayInfo.CustomerList = new List<CustomerModel>();

                        mCustomerStayInfo.CommonInfo = new CommonModel();
                        mCustomerStayInfo.StayNo = ToString(sdr["STAY_NO"]);
                        mCustomerStayInfo.StayId = ToInt32(sdr["STAY_ID"]);
                        mCustomerStayInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                        mCustomerStayInfo.MainRoomId = ToInt32(sdr["MAIN_ROOM_ID"]);
                        mCustomerStayInfo.CommonInfo.StartDate = ToDateTime(sdr["START_DATE"]);
                        mCustomerStayInfo.CommonInfo.EndDate = ToDateTime(sdr["END_DATE"]);
                        mCustomerStayInfo.Deposit = ToDouble(sdr["DEPOSIT"]);
                        mCustomerStayInfo.RoomRate = ToInt32(sdr["CURRENT_RATE"]);
                        mCustomerStayInfo.PayType = ToChar(sdr["PAY_TYPE"]);
                        mCustomerStayInfo.Total = ToDouble(sdr["TOTAL_MONEY"]);
                        mCustomerStayInfo.Status = ToChar(sdr["STATUS"]);
                        mCustomerStayInfo.Notice = ToString(sdr["NOTICE"]);
                        mCustomerStayInfo.Hours = ToInt32(sdr["HOURS"]);
                        mCustomerStayInfo.RoomStayType = ToChar(sdr["ROOM_STAY_TYPE"]);
                        mCustomerStayInfo.PaidMoney = ToDouble(sdr["PAID_MONEY"]);
                        mCustomerStayInfo.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                        mCustomerStayInfo.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                        mCustomerStayInfo.CommonInfo.CreateUserName = ToString(sdr["CREATE_USER_NAME"]);
                        mCustomerStayInfo.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                        mCustomerStayInfo.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                        mCustomerStayInfo.CommonInfo.UpateUserName = ToString(sdr["UPDATE_USER_NAME"]);

                        CustomerModel mCustomerInfo = new CustomerModel();
                        mCustomerInfo.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                        mCustomerInfo.IdCardNo = ToString(sdr["ID_CARD"]);
                        mCustomerInfo.Name = ToString(sdr["NAME"]);
                        mCustomerInfo.Nation = ToString(sdr["NATION"]);
                        mCustomerInfo.Phone = ToString(sdr["PHONE"]);
                        mCustomerInfo.Picture = ToString(sdr["PICTURE"]);
                        mCustomerInfo.Type = ToChar(sdr["TYPE"]);
                        mCustomerInfo.Sex = ToString(sdr["SEX"]);
                        mCustomerInfo.Birthday = ToDateTime(sdr["BIRTHDAY"]);
                        mCustomerInfo.Address = ToString(sdr["ADDRESS"]);
                        mCustomerInfo.Company = ToString(sdr["COMPANY"]);
                        mCustomerInfo.CustomerStayHisInfo = new CustomerStayHisModel();
                        mCustomerInfo.CustomerStayHisInfo.HisId = ToInt32(sdr["HIS_ID"]);
                        mCustomerInfo.CustomerStayHisInfo.StayId = ToInt32(sdr["STAY_ID"]);
                        mCustomerInfo.CustomerStayHisInfo.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                        mCustomerInfo.CustomerStayHisInfo.StayType = ToChar(sdr["STAY_TYPE"]);
                        mCustomerInfo.CustomerStayHisInfo.HisStatus = ToChar(sdr["HIS_STATUS"]);

                        mCustomerInfo.CustomerStayHisInfo.CommonInfo.StartDate = ToDateTime(sdr["START_TIME"]);
                        mCustomerInfo.CustomerStayHisInfo.CommonInfo.EndDate = ToDateTime(sdr["END_TIME"]);

                        mCustomerStayInfo.CustomerList.Add(mCustomerInfo);

                        mCustomerStayInfo.RoomInfo = new BasRoomModel();
                        mCustomerStayInfo.RoomInfo.RoomId = ToInt32(sdr["ROOM_ID"]);
                        mCustomerStayInfo.RoomInfo.RoomNo = ToString(sdr["ROOM_NO"]);
                        mCustomerStayInfo.RoomInfo.RoomType = ToChar(sdr["ROOM_TYPE"]);
                        mCustomerStayInfo.RoomInfo.RoomRate = ToDouble(sdr["DEFAULT_RATE"]);
                        mCustomerStayInfo.RoomInfo.RoomPhone = ToString(sdr["ROOM_PHONE"]);
                        mCustomerStayInfo.RoomInfo.Status = ToChar(sdr["ROOM_STATUS"]);
                        mCustomerStayInfo.RoomInfo.RoomNotice = ToString(sdr["ROOM_NOTICE"]);
                        mCustomerStayInfo.RoomInfo.FloorInfo = new BasFloorModel();
                        mCustomerStayInfo.RoomInfo.FloorInfo.FloorId = ToInt32(sdr["FLOOR_ID"]);
                        mCustomerStayInfo.RoomInfo.FloorInfo.FloorName = ToString(sdr["FLOOR_NAME"]);
                        listCustomerStay.Add(mCustomerStayInfo);
                    }
                }
                return listCustomerStay;
            }
        }

        public HandOverModel GetHandOverStayInfo(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            string sql = "SELECT ";
            if (mCustomerStay.Status == 'I')
            {
                sql += "ISNULL(SUM(A.DEPOSIT),0) MONEY";
            }
            else
            {
                sql += "ISNULL(SUM(A.PAID_MONEY),0) MONEY";
            }
            sql += " FROM CUSTOMER_STAY_INFO A WHERE 1=1";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayStatus) && oCtrl.Append(ref sql, " AND A.STATUS=" + SQL(mCustomerStay.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCreateDate) && oCtrl.Append(ref sql, " AND A.CREATE_DATE >" + SQL(mCustomerStay.CommonInfo.CreateDate)));
          
            sdr = ExecuteReader(sql);
            using (sdr)
            {
                HandOverModel mHandOver = new HandOverModel();

                while (sdr.Read())
                {
                    if (mCustomerStay.Status == 'I')
                    {
                        mHandOver.CurrentDeposit = ToDouble(sdr["MONEY"]);
                    }
                    else
                    {
                        mHandOver.CurrentPaidMoney = ToDouble(sdr["MONEY"]);
                    }
                }
                return mHandOver;
            }
        }
        
        public List<CustomerStayHisModel> GetStayHis(CustomerStayHisModel mStayHis, ObjectControls oCtrl)
        {
            string sql = "SELECT * FROM CUSTOMER_STAY_HIS A WHERE 1=1";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCustomerId) && oCtrl.Append(ref sql, " AND A.CUSTOMER_ID=" + mStayHis.CustomerId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayId) && oCtrl.Append(ref sql, " AND A.STAY_ID=" + mStayHis.StayId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayType) && oCtrl.Append(ref sql, " AND A.STAY_TYPE=" + mStayHis.StayType));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisStatus) && oCtrl.Append(ref sql, " AND A.HIS_STATUS=" + mStayHis.HisStatus));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByHisId) && oCtrl.Append(ref sql, " AND A.HIS_ID=" + mStayHis.HisId));

            sdr = ExecuteReader(sql);
            using (sdr)
            {
                List<CustomerStayHisModel> listStayHis = new List<CustomerStayHisModel>();
                while (sdr.Read())
                {
                    CustomerStayHisModel mStayHisNew = new CustomerStayHisModel();
                    mStayHisNew.HisId = ToInt32(sdr["HIS_ID"]);
                    mStayHisNew.StayId =ToInt32(sdr["STAY_ID"]);
                    mStayHisNew.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                    mStayHisNew.HisStatus = ToChar(sdr["HIS_STATUS"]);
                    mStayHisNew.StayType = ToChar(sdr["STAY_TYPE"]);
                    mStayHisNew.CommonInfo = new CommonModel();
                    mStayHisNew.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mStayHisNew.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mStayHisNew.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                    mStayHisNew.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                    listStayHis.Add(mStayHisNew);
                }
                return listStayHis;
            }
        }

        public int InsertCustomerStay(CustomerStayModel mCustomerStay)
        {
            try
            {
                CUSTOMER_STAY_INFO cti = new CUSTOMER_STAY_INFO();
                cti.CREATE_DATE = GetDBTime;
                cti.CREATE_USERID = mCustomerStay.CommonInfo.CreateUserId;
                cti.DEPOSIT = mCustomerStay.Deposit;
                cti.END_DATE = mCustomerStay.CommonInfo.EndDate;
                cti.HOURS = mCustomerStay.Hours;
                cti.MAIN_ROOM_ID = mCustomerStay.MainRoomId;
                cti.NOTICE = mCustomerStay.Notice;
                cti.PAY_TYPE = mCustomerStay.PayType;
                cti.ROOM_ID = mCustomerStay.RoomId;
                cti.ROOM_RATES = mCustomerStay.RoomRate;
                cti.START_DATE = mCustomerStay.CommonInfo.StartDate;
                cti.STATUS = mCustomerStay.Status;
                cti.STAY_NO = mCustomerStay.StayNo;
                cti.PAID_MONEY = mCustomerStay.PaidMoney;
                cti.ROOM_STAY_TYPE = mCustomerStay.RoomStayType;
                cti.UPDATE_DATE = cti.CREATE_DATE;
                cti.UPDATE_USERID = mCustomerStay.CommonInfo.UpdateUserId;
                dc.CUSTOMER_STAY_INFO.InsertOnSubmit(cti);
                dc.SubmitChanges();
                return cti.STAY_ID;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int InsertCustomerStayHis(CustomerStayHisModel mHis)
        {
            try
            {
                CUSTOMER_STAY_HIS cth = new CUSTOMER_STAY_HIS();
                cth.CREATE_DATE = GetDBTime;
                cth.CREATE_USERID = mHis.CommonInfo.CreateUserId;
                cth.STAY_TYPE = mHis.StayType;
                cth.STAY_ID = mHis.StayId;
                cth.CUSTOMER_ID = mHis.CustomerId;
                cth.HIS_STATUS = mHis.HisStatus;
                cth.UPDATE_DATE = GetDBTime;
                cth.UPDATE_USERID = cth.CREATE_USERID;
                cth.START_TIME = mHis.CommonInfo.StartDate;
                cth.END_TIME = mHis.CommonInfo.EndDate;
                dc.CUSTOMER_STAY_HIS.InsertOnSubmit(cth);
                dc.SubmitChanges();
                return cth.HIS_ID;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int UpdateCustomerStay(CustomerStayModel mCustomerStay, ObjectControls oCtrl)
        {
            string sql = "UPDATE  CUSTOMER_STAY_INFO SET CREATE_DATE=CREATE_DATE";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetStayNo) && oCtrl.Append(ref sql, ",STAY_NO=" + SQL(mCustomerStay.StayNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomId) && oCtrl.Append(ref sql, ",ROOM_ID=" + SQL(mCustomerStay.RoomId)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetMainRoomId) && oCtrl.Append(ref sql, ",MAIN_ROOM_ID=" + SQL(mCustomerStay.MainRoomId)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetHours) && oCtrl.Append(ref sql, ",HOURS=" + SQL(mCustomerStay.Hours)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomStayType) && oCtrl.Append(ref sql, ",ROOM_STAY_TYPE=" + SQL(mCustomerStay.RoomStayType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetStartDate) && oCtrl.Append(ref sql, ",START_DATE=" + SQL(mCustomerStay.CommonInfo.StartDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetEndDate) && oCtrl.Append(ref sql, ",END_DATE=" + SQL(mCustomerStay.CommonInfo.EndDate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetDeposit) && oCtrl.Append(ref sql, ",DEPOSIT=" + SQL(mCustomerStay.Deposit)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetRoomRate) && oCtrl.Append(ref sql, ",ROOM_RATES=" + SQL(mCustomerStay.RoomRate)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetTotal) && oCtrl.Append(ref sql, ",TOTAL_MONEY=" + SQL(mCustomerStay.Total)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetPayType) && oCtrl.Append(ref sql, ",PAY_TYPE=" + SQL(mCustomerStay.PayType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetCustomerStayStatus) && oCtrl.Append(ref sql, ",STATUS=" + SQL(mCustomerStay.Status)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetPaidMoney) && oCtrl.Append(ref sql, ",PAID_MONEY=" + SQL(mCustomerStay.PaidMoney)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetNotice) && oCtrl.Append(ref sql, ",NOTICE=" + SQL(mCustomerStay.Notice)));

            sql += ",UPDATE_DATE=" + SQL(GetDBTime);
            sql += ",UPDATE_USERID=" + SQL(mCustomerStay.CommonInfo.UpdateUserId);
            sql += " WHERE STAY_ID=" + mCustomerStay.StayId;
            return ExcuteNonQuery(sql);
        }

        public int UpdateStayHis(CustomerStayHisModel mHis, ObjectControls oCtrl)
        {
            string sql = "UPDATE CUSTOMER_STAY_HIS  SET  CREATE_DATE=CREATE_DATE";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetCustomerId) && oCtrl.Append(ref sql, ",CUSTOMER_ID=" + SQL(mHis.CustomerId)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetHisType) && oCtrl.Append(ref sql, ",STAY_TYPE=" + SQL(mHis.StayType)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetHisStatus) && oCtrl.Append(ref sql, ",HIS_STATUS=" + SQL(mHis.HisStatus)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetEndDate) && oCtrl.Append(ref sql, ",END_TIME=" + SQL(mHis.CommonInfo.EndDate)));

            sql += ",UPDATE_DATE=" + SQL(GetDBTime);
            sql += ",UPDATE_USERID=" + SQL(mHis.CommonInfo.UpdateUserId);
            sql += " WHERE HIS_ID=" + mHis.HisId;
            //STAY_ID=" + mHis.StayId;
            //sql += " AND CUSTOMER_ID=" + mHis.CustomerId;
            return ExcuteNonQuery(sql);
        }

        public int DeleteCustomerStay(CustomerStayModel mCustomerStay)
        {
            string sql = "DELETE FROM CUSTOMER_STAY_INFO WHERE STAY_ID=" + mCustomerStay.StayId;
            return ExcuteNonQuery(sql);
        }

    }
}
