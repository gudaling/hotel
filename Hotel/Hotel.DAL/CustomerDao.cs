using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;

namespace Hotel.DAL
{
    public class CustomerDao : AbBaseDao
    {
        public List<CustomerModel> GetCustomerInfo(CustomerModel mCustomer, ObjectControls oCtrl)
        {
            string sql = @"SELECT CUSTOMER_ID, ID_CARD, NAME, SEX, NATION, BIRTHDAY, ADDRESS, COMPANY, 
                            PHONE, PICTURE, TYPE, CREATE_DATE, CREATE_USERID, UPDATE_DATE, 
                            UPDATE_USERID 
                            FROM CUSTOMER_INFO WHERE 1=1";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCustomerId) && oCtrl.Append(ref sql, " AND CUSTOMER_ID=" + mCustomer.CustomerId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByName) && oCtrl.Append(ref sql, " AND NAME=" + SQL(mCustomer.Name)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByIdCard)&& oCtrl.Append( ref sql, " AND ID_CARD=" + SQL(mCustomer.IdCardNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.BySex)&& oCtrl.Append( ref sql, " AND SEX=" + SQL(mCustomer.Sex)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByPhone)&& oCtrl.Append(ref sql, " AND PHONE=" + SQL(mCustomer.Phone)));
            //oCtrl.Helper(oCtrl.Exsit(MCtrl.ByStayId)&& oCtrl.Append(ref sql, " AND A.STAY_ID=" + mCustomer.StayId));

            sdr = ExecuteReader(sql);
            List<CustomerModel> listCustomer = new List<CustomerModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    CustomerModel mCustomerInfo = new CustomerModel();
                    mCustomerInfo.CustomerId = ToInt32(sdr["CUSTOMER_ID"]);
                   // mCustomerInfo.CustomerStayHisInfo.StayId = ToInt32(sdr["STAY_ID"]);
                    mCustomerInfo.IdCardNo = ToString(sdr["ID_CARD"]);
                    mCustomerInfo.Name = ToString(sdr["NAME"]);
                    mCustomerInfo.Sex = ToString(sdr["SEX"]);
                    mCustomerInfo.Birthday = ToDateTime(sdr["BIRTHDAY"]);
                    mCustomerInfo.Address = ToString(sdr["ADDRESS"]);
                    mCustomerInfo.Company = ToString(sdr["COMPANY"]);
                    mCustomerInfo.Nation = ToString(sdr["NATION"]);
                    mCustomerInfo.Phone = ToString(sdr["PHONE"]);
                    mCustomerInfo.Picture = ToString(sdr["PICTURE"]);
                    mCustomerInfo.Type = ToChar(sdr["TYPE"]);
                    mCustomerInfo.CommonInfo = new CommonModel();
                    mCustomerInfo.CommonInfo.CreateDate = ToDateTime(sdr["CREATE_DATE"]);
                    mCustomerInfo.CommonInfo.CreateUserId = ToInt32(sdr["CREATE_USERID"]);
                    mCustomerInfo.CommonInfo.UpdateDate = ToDateTime(sdr["UPDATE_DATE"]);
                    mCustomerInfo.CommonInfo.UpdateUserId = ToInt32(sdr["UPDATE_USERID"]);
                    listCustomer.Add(mCustomerInfo);
                }
            }
            return listCustomer;
        }

        /// <summary>
        /// 返回新增成功后的ID
        /// </summary>
        /// <param name="mHis"></param>
        /// <returns></returns>
        public int InsertCustomer(CustomerModel mCustomer)
        {
            try
            {
                CUSTOMER_INFO ci = new CUSTOMER_INFO();
                ci.ADDRESS = mCustomer.Address;
                ci.BIRTHDAY = mCustomer.Birthday;
                ci.COMPANY = mCustomer.Company;
                ci.CREATE_DATE = GetDBTime;
                ci.CREATE_USERID = mCustomer.CommonInfo.CreateUserId;
                ci.ID_CARD = mCustomer.IdCardNo;
                ci.NAME = mCustomer.Name;
                ci.NATION = mCustomer.Nation;
                ci.PHONE = mCustomer.Phone;
                ci.PICTURE = mCustomer.Picture;
                ci.SEX = mCustomer.Sex;
                ci.TYPE = mCustomer.Type;
                ci.UPDATE_DATE = GetDBTime;
                ci.UPDATE_USERID = mCustomer.CommonInfo.UpdateUserId;
                dc.CUSTOMER_INFO.InsertOnSubmit(ci);
                dc.SubmitChanges();
                return ci.CUSTOMER_ID;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int UpdateCustomer(CustomerModel mCustomer, ObjectControls oCtrl)
        {
            string sql = "UPDATE CUSTOMER_INFO SET CREATE_DATE = CREATE_DATE";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetName) && oCtrl.Append(ref sql, ",NAME=" + SQL(mCustomer.Name)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetNation) && oCtrl.Append(ref sql, ",NATION=" + SQL(mCustomer.Nation)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetIdCard) && oCtrl.Append(ref sql, ",ID_CARD=" + SQL(mCustomer.IdCardNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetSex) && oCtrl.Append(ref sql, ",SEX=" + SQL(mCustomer.Sex)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetBirthday) && oCtrl.Append(ref sql, ",BIRTHDAY=" + SQL(mCustomer.Birthday)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetCompanyName) && oCtrl.Append( ref sql, ",COMPANY=" + SQL(mCustomer.Company)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetAddress) && oCtrl.Append(ref sql, ",ADDRESS=" + SQL(mCustomer.Address)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetCustomerType) && oCtrl.Append( ref sql, ",ADDRESS=" + SQL(mCustomer.Type)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetPicture) && oCtrl.Append(ref sql, ",PICTURE=" + SQL(mCustomer.Picture)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetPhone) && oCtrl.Append(ref sql, ",PHONE=" + SQL(mCustomer.Phone)));
            sql += ",UPDATE_DATE=" + SQL(GetDBTime);
            sql += ",UPDATE_USERID=" + SQL(mCustomer.CommonInfo.UpdateUserId);
            sql += " WHERE CUSTOMER_ID=" + mCustomer.CustomerId;

            return ExcuteNonQuery(sql);
        }

        public int DeleteCustomer(CustomerModel mCustomer)
        {
            string sql = "DELETE FROM CUSTOMER_INFO WHERE CUSTOMER_ID=" + mCustomer.CustomerId;
            return ExcuteNonQuery(sql);
        }
    }
}
