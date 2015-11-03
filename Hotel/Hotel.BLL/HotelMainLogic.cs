using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Hotel.Common;
using Hotel.BLL;
using Hotel.Model;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Hotel.BLL
{
    public class HotelMainLogic:AbBaseBll
    {
        private CustomerStayInfo bCustomerStay = new CustomerStayInfo();
        private CustomerInfo bCustomer = new CustomerInfo();
        private BasGoodsInfo bGoods = new BasGoodsInfo();
        private OrdersInfo bOrder = new OrdersInfo();
        private SysLookUpCodeInfo bLookUpCode = new SysLookUpCodeInfo();
        private BasRoomInfo bRoom = new BasRoomInfo();
        private ConsumeDetail bConsume = new ConsumeDetail();
        private PhoneJFInfo bPhone = new PhoneJFInfo();
        private StayRateInfo bStayRate = new StayRateInfo();

        /// <summary>
        /// 获取指定参数名称的值
        /// </summary>
        /// <param name="listParameter"></param>
        /// <param name="sParameterNo"></param>
        /// <returns></returns>
        public SysParameterModel ToParameter(List<SysParameterModel> listParameter, string sParameterNo)
        {
            return listParameter.Where(c => c.ParamNo == sParameterNo).FirstOrDefault();
        }

        /// <summary>
        /// 根据编号表名列名,获取对应的描述
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sColumn"></param>
        /// <param name="sCodeNo"></param>
        /// <returns></returns>
        public string ToLookupCodeDesc(string sTableName, string sColumn, string sCodeNo)
        {
            SysLookupCodeModel mCode = new SysLookupCodeModel();
            mCode.TableName = sTableName;
            mCode.ColumnName = sColumn;
            mCode.CodeNo = sCodeNo;
            ObjectControls oCtrl = new ObjectControls();
            oCtrl.Add(MCtrl.ByCodeNo);
            oCtrl.Add(MCtrl.ByColumnName);
            oCtrl.Add(MCtrl.ByTableName);
            List<SysLookupCodeModel> listLookUpCode = bLookUpCode.GetSysLookUpCode(mCode, oCtrl);
            if (cmn.CheckEOF(listLookUpCode))
            {
                return listLookUpCode[0].CodeDesc;
            }
            return string.Empty;
        }

        /// <summary>
        /// 计算宾客入住天数.计算费用时用到.支持浮动时间以及超时计费.
        /// </summary>
        /// <param name="dtStartDate">开始时间</param>
        /// <param name="dtEndDate">离店时间</param>
        /// <param name="listSysParameter">系统参数</param>
        /// <returns></returns>
        public double GetCustomerStayDays(DateTime dtStartDate, DateTime dtEndDate,DateTime dtNow, RoomStayType eRst, List<SysParameterModel> listSysParameter)
        {
            int nFloatTime = Convert.ToInt32(ToParameter(listSysParameter, "FLOAT_TIME").Value1);
            DateTime dtMinStartDate = Convert.ToDateTime(ToParameter(listSysParameter, "MIN_START_DATE").Value1);
            DateTime dtOffDate1 = Convert.ToDateTime(ToParameter(listSysParameter, "OFF_DATE_1").Value1);
            //double dAddDays = Convert.ToDouble(ToParameter(listSysParameter, "OFF_DATE_1").Value2);
            DateTime dtOffDate2 = Convert.ToDateTime(ToParameter(listSysParameter, "OFF_DATE_2").Value1);
            int nMinChargingTime = Convert.ToInt32(ToParameter(listSysParameter, "MIN_CHARGING_TIME").Value1);
            double dNumber=0.0;
            if (dtNow.Subtract(dtStartDate).TotalMinutes <= nMinChargingTime)
            {
                return dNumber;
            }
            if (eRst == RoomStayType.Day)
            {
                dNumber = double.Parse(dtEndDate.Date.Subtract(dtStartDate.Date).Days.ToString());
                if (DateTime.Parse(dtStartDate.ToShortTimeString()).AddMinutes(nFloatTime) < dtMinStartDate)
                {
                    dNumber += 1;
                }
                if (DateTime.Parse(dtEndDate.ToShortTimeString()).AddMinutes(-nFloatTime) >= dtOffDate1 && DateTime.Parse(dtEndDate.ToShortTimeString()).AddMinutes(-nFloatTime) < dtOffDate2)
                {
                    dNumber += double.Parse(ToParameter(listSysParameter, "OFF_DATE_1").Value2);
                }
                else if (DateTime.Parse(dtEndDate.ToShortTimeString()).AddMinutes(-nFloatTime) >= dtOffDate2)
                {
                    dNumber += double.Parse(ToParameter(listSysParameter, "OFF_DATE_1").Value2);
                }
                //如果入住时间在中午12点之前,退房时间也在当天中午12点之前,则以入住半天计算.
                if (dNumber == 0)
                {
                    dNumber += 0.5;
                }
            }
            else
            {
                dNumber = GetStayHours(dtStartDate, dtEndDate, listSysParameter);
            }
            return dNumber;
        }

        /// <summary>
        /// 根据入住天数计算离店时间
        /// </summary>
        /// <param name="dtStartDate">开始时间</param>
        /// <param name="nDays">天数</param>
        /// <param name="listSysParameter">系统参数</param>
        /// <returns></returns>
        public DateTime GetEndDateByStayDays(DateTime dtStartDate, int nDays, List<SysParameterModel> listSysParameter)
        {
            string sDefaultOffDate = ToParameter(listSysParameter, "DEFAULT_OFF_DATE").Value1;
            DateTime dtMinStartDate = Convert.ToDateTime(ToParameter(listSysParameter, "MIN_START_DATE").Value1);
            if (DateTime.Parse(dtStartDate.ToShortTimeString()) < dtMinStartDate)
            {
                return DateTime.Parse(dtStartDate.Date.AddDays(nDays - 1).ToShortDateString() + " " + sDefaultOffDate);
            }
            DateTime dtEndDate = dtStartDate.AddDays(nDays);
            return DateTime.Parse(dtEndDate.Date.ToShortDateString() + " " + sDefaultOffDate);
        }

        /// <summary>
        /// 计算总费用
        /// </summary>
        /// <param name="mCustomerStay">宾客信息</param>
        /// <param name="listConsumeInfo">费用明细</param>
        /// <param name="listSysParameter">系统参数</param>
        /// <param name="dtNow">当前时间</param>
        /// <param name="mJf">电话号码,入住起始结束时间</param>
        /// <returns></returns>
        public double GetTotalRates(CustomerStayModel mCustomerStay, List<ConsumeDetailModel> listConsumeInfo, List<SysParameterModel> listSysParameter,DateTime dtNow,double dPhoneRate)
        {
            DateTime dtEndDate = dtNow;
            double dTotal = 0.0;

            #region 计算商品费用

            if (cmn.CheckEOF(listConsumeInfo))
            {
                foreach (ConsumeDetailModel mConsume in listConsumeInfo)
                {
                    dTotal += mConsume.Total;
                }
            }

            #endregion

            #region 计算电话费用

            if (dPhoneRate > 0 && ToParameter(listSysParameter, "PHONE_JF").Value1.Equals("Y"))
            {
                //List<JFModel> listJF = new List<JFModel>();
                //listJF = GetPhoneList(mJf, dtNow);
                dTotal += dPhoneRate;//GetPhoneJFFromWS(listJF, mJf.CatList);
            }
            #endregion

            #region 计算房间费
            
            if (mCustomerStay.RoomStayType == 'D')
            {
                double dDays = GetCustomerStayDays(mCustomerStay.CommonInfo.StartDate, dtEndDate,dtNow, RoomStayType.Day, listSysParameter);
                dTotal += mCustomerStay.RoomRate * dDays;
            }
            else
            {
                double dHour = GetStayHours(mCustomerStay.CommonInfo.StartDate, dtEndDate, listSysParameter);
                dTotal += mCustomerStay.RoomRate * dHour;
            }

            #endregion

            return dTotal;
        }

        private double GetStayHours(DateTime dtStartDate, DateTime dtEndDate, List<SysParameterModel> listSysParameter)
        {
            double dMinChargingTime = Convert.ToDouble(ToParameter(listSysParameter, "MIN_CHARGING_TIME").Value1);
            double dMinute = dtEndDate.Subtract(dtStartDate).TotalMinutes;
            if (dMinute <= dMinChargingTime)
            {
                return 0.0;
            }
            else
            {
                return Math.Truncate(dMinute / 60) + 1.0;
            }
        }
        /// <summary>
        /// 获取已近入住时间.截止至Now(DB时间);返回格式为X天X小时.
        /// </summary>
        /// <param name="dtStartDate"></param>
        /// <returns></returns>
        public string GetUsedDays(DateTime dtStartDate)
        {
            double day = cmn.DateBaseDate.Subtract(dtStartDate).TotalDays;
            double hours = (day - Math.Truncate(day)) * 24;
            return Math.Truncate(day).ToString("0") + "天" + hours.ToString("0") + "小时";
        }

        /// <summary>
        /// 生成结账单号=编号+日期+StayId
        /// </summary>
        /// <param name="nStayId"></param>
        /// <param name="listSysParameter"></param>
        /// <returns></returns>
        public string GetStayNo(int nStayId,List<SysParameterModel> listSysParameter)
        {
            return ToParameter(listSysParameter, "DEFAULT_STAY_NO_START").Value1 + cmn.DateBaseDate.ToString("yyyyMMdd") + nStayId.ToString();
        }

        /// <summary>
        /// 根据一个RoomId获取团队所有房间
        /// </summary>
        /// <param name="mRoom"></param>
        /// <returns></returns>
        public List<BasRoomModel> GetTeamRoomListByRoomId(BasRoomModel mRoom,char cStayStatus)
        {
            CustomerStayModel mCustomerStay = new CustomerStayModel();
            mCustomerStay.RoomId = mRoom.RoomId;
            mCustomerStay.Status = cStayStatus;
            ObjectControls oCtrl = new ObjectControls();
            oCtrl.Add(MCtrl.ByStayStatus);
            oCtrl.Add(MCtrl.ByRoomId);
            CustomerStayModel mC = bCustomerStay.GetCustomerStayInfo(mCustomerStay, oCtrl);
            if (mC.MainRoomId > 0)
            {
                oCtrl.Reset();
                oCtrl.Add(MCtrl.ByStayStatus);
                oCtrl.Add(MCtrl.ByMainRoomId);
                return bRoom.GetTeamRoomList(mC, oCtrl);
            }
            else
            {
                return new List<BasRoomModel>();
            }
        }

        /// <summary>
        /// 获取宾客入住信息,消费明细
        /// </summary>
        /// <param name="mRoom">房间信息</param>
        /// <param name="cStayStatus">入住状态 I In / O off</param>
        /// <param name="sStayType">入住类型,主客M从客S,如包含主从则为""</param>
        /// <returns></returns>
        public CustomerStayModel GetStayInRoomInfo(BasRoomModel mRoom, char cStayStatus, string sStayType)
        { 
                CustomerStayModel mStayInfo = new CustomerStayModel();
                ObjectControls oCtrl = new ObjectControls();
                mStayInfo.RoomId = mRoom.RoomId;
                mStayInfo.Status = cStayStatus;
                mStayInfo.CustomerList = new List<CustomerModel>();
                CustomerModel mc = new CustomerModel();
                mc.CustomerStayHisInfo = new CustomerStayHisModel();
                if (!string.IsNullOrEmpty(sStayType))
                {
                    mc.CustomerStayHisInfo.StayType = cmn.ToChar(sStayType);
                    oCtrl.Add(MCtrl.ByStayType);
                }
                mc.CustomerStayHisInfo.HisStatus = cStayStatus == 'I' ? 'E' : 'O';
                mStayInfo.CustomerList.Add(mc);
                oCtrl.Add(MCtrl.ByRoomId);
                oCtrl.Add(MCtrl.ByStayStatus);
                oCtrl.Add(MCtrl.ByHisStatus);
                CustomerStayModel mCustomerStay = bCustomerStay.GetCustomerStayInfo(mStayInfo, oCtrl);
                if (mCustomerStay != null)
                {
                    List<ConsumeDetailModel> listGetConsumeDetail = new List<ConsumeDetailModel>();
                    ConsumeDetailModel mConsume = new ConsumeDetailModel();
                    mConsume.StayId = mCustomerStay.StayId;
                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.ByStayId);
                    listGetConsumeDetail = bConsume.GetConsumeList(mConsume, oCtrl);
                    if (cmn.CheckEOF(listGetConsumeDetail))
                    {
                        mCustomerStay.ConSumeDetailList = listGetConsumeDetail;
                    }
                }
                return mCustomerStay;
        }

        /// <summary>
        /// 获取在宾客信息清单
        /// </summary>
        /// <param name="listRoomInfo"></param>
        /// <param name="cStayStatus">该入住单是否在住</param>
        /// <param name="sStayType">宾客类型,主客Or从客</param>
        /// <param name="HisStayStatus">宾客是否退房</param>
        /// <param name="IsCountConsume">是否统计消费</param>
        /// <returns></returns>
        public List<CustomerStayModel> GetStayInRoomInfo(List<BasRoomModel> listRoomInfo, char cStayStatus,string sStayType, bool IsCountConsume)
        {
            List<CustomerStayModel> listCustomerStayInfo = new List<CustomerStayModel>();

            CustomerStayModel mStayInfo = new CustomerStayModel();
            ObjectControls oCtrl = new ObjectControls();
            foreach (BasRoomModel mRoom in listRoomInfo)
            {
                mStayInfo.RoomInfo.RoomIdGroup += cmn.MakeGroup(mRoom.RoomId.ToString());
            }
            mStayInfo.RoomInfo.RoomIdGroup = cmn.RemoveLastDou(mStayInfo.RoomInfo.RoomIdGroup);

            mStayInfo.Status = cStayStatus;
            mStayInfo.CustomerList = new List<CustomerModel>();
            CustomerModel mc = new CustomerModel();
            mc.CustomerStayHisInfo = new CustomerStayHisModel();
            if (!string.IsNullOrEmpty(sStayType))
            {
                mc.CustomerStayHisInfo.StayType = cmn.ToChar(sStayType);
                oCtrl.Add(MCtrl.ByStayType);
            }
            mc.CustomerStayHisInfo.HisStatus = cStayStatus == 'I' ? 'E' : 'O';
            mStayInfo.CustomerList.Add(mc);
            if (cmn.CheckEOF(listRoomInfo))
            {
                oCtrl.Add(MCtrl.ByRoomIdGroup);
            }
            oCtrl.Add(MCtrl.ByStayStatus);
            oCtrl.Add(MCtrl.ByHisStatus);
            listCustomerStayInfo = bCustomerStay.GetCustomerStayList(mStayInfo, oCtrl);
            if (cmn.CheckEOF(listCustomerStayInfo) && IsCountConsume)
            {
                foreach (CustomerStayModel mCustomerStay in listCustomerStayInfo)
                {
                    List<ConsumeDetailModel> listGetConsumeDetail = new List<ConsumeDetailModel>();
                    ConsumeDetailModel mConsume = new ConsumeDetailModel();
                    mConsume.StayId = mCustomerStay.StayId;
                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.ByStayId);
                    listGetConsumeDetail = bConsume.GetConsumeList(mConsume, oCtrl);
                    if (cmn.CheckEOF(listGetConsumeDetail))
                    {
                        mCustomerStay.ConSumeDetailList = listGetConsumeDetail;
                    }
                }
            }

            return listCustomerStayInfo;
        }

        /// <summary>
        /// By用户证件以及姓名获取用户信息
        /// </summary>
        /// <param name="mCustomer"></param>
        /// <returns></returns>
        public List<CustomerModel> GetExistCustomerInfo(CustomerModel mCustomer)
        {
            ObjectControls oCtrl = new ObjectControls();
            if (mCustomer.CustomerId > 0)
            {
                oCtrl.Add(MCtrl.ByCustomerId);
            }
            else
            {
                oCtrl.Add(MCtrl.ByIdCard);
                oCtrl.Add(MCtrl.ByName);
            }
            return bCustomer.GetCustomerInfo(mCustomer, oCtrl);
        }

        /// <summary>
        /// 获取房间有效的预定
        /// </summary>
        /// <param name="mRoom"></param>
        /// <returns></returns>
        public List<OrderInfoModel> GetRoomOrder(BasRoomModel mRoom)
        {
            OrderInfoModel mOrder = new OrderInfoModel();
            mOrder.RoomInfo = mRoom;
            mOrder.KeepDate = cmn.DateBaseDate;
            mOrder.Status = 'E';
            ObjectControls oCtrl = new ObjectControls();
            oCtrl.Reset();
            oCtrl.Add(MCtrl.ByRoomId);
            oCtrl.Add(MCtrl.ByKeepDateEnable);
            oCtrl.Add(MCtrl.ByOrderStatus);
            return bOrder.GetOrderInfo(mOrder, oCtrl);
        }

        /// <summary>
        /// 仅获取宾客入住信息
        /// </summary>
        /// <param name="mRoom"></param>
        /// <param name="cStayStatus"></param>
        /// <returns></returns>
        public CustomerStayModel GetCustomerStayInfoByRoom(BasRoomModel mRoom, char cStayStatus)
        {
            CustomerStayModel mStayInfo = new CustomerStayModel();
            ObjectControls oCtrl = new ObjectControls();
            mStayInfo.RoomId = mRoom.RoomId;
            mStayInfo.Status = cStayStatus;
            oCtrl.Add(MCtrl.ByRoomId);
            oCtrl.Add(MCtrl.ByStayStatus);
            return bCustomerStay.GetCustomerStayInfo(mStayInfo, oCtrl);
        }

        /// <summary>
        /// 开房前检测房间是否可用
        /// </summary>
        /// <param name="mRoom"></param>
        /// <returns></returns>
        public bool OpenRoomCheck(BasRoomModel mRoom)
        {
            if (mRoom.RoomId>0)
            {
                if (mRoom.Status == 'I' || mRoom.Status == 'T')
                {
                    cmn.Show("房间已被占用,无法开单.");
                    return false;
                }
                else if (mRoom.Status == 'C' || mRoom.Status == 'D')
                {
                    string sRoomStatus = mRoom.Status == 'C' ? "清理" : "停用";
                    if (!cmn.Confirm(string.Format("房间{0}处于{1}状态,继续开单?", mRoom.RoomNo, sRoomStatus)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改房态 ById
        /// </summary>
        /// <param name="mRoom"></param>
        public void UpdateRoomStatusByRoomId(BasRoomModel mRoom,SysUserInfoModel mUserInfo)
        {
            mRoom.CommonInfo.UpdateUserId = mUserInfo.UserId;
            bRoom.UpdateRoomInfo(mRoom, new ObjectControls(MCtrl.SetRoomStatus));
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="mCustomerNew">新的信息</param>
        /// <param name="mCustomerOld">以前旧信息</param>
        public void UpdateExsitCustomerInfo(CustomerModel mCustomerNew,CustomerModel mCustomerOld) 
        {
            ObjectControls oCtrl = new ObjectControls();
            if (!string.IsNullOrEmpty(mCustomerNew.Name))
            {
                mCustomerOld.Name = mCustomerNew.Name;
                oCtrl.Add(MCtrl.SetName);
            }
            if (!string.IsNullOrEmpty(mCustomerNew.IdCardNo))
            {
                mCustomerOld.IdCardNo = mCustomerNew.IdCardNo;
                oCtrl.Add(MCtrl.SetIdCard);
            }
            if (!string.IsNullOrEmpty(mCustomerNew.Address))
            {
                mCustomerOld.Address = mCustomerNew.Address;
                oCtrl.Add(MCtrl.SetAddress);
            }
            if (mCustomerNew.Birthday != DateTime.MinValue)
            {
                mCustomerOld.Birthday = mCustomerNew.Birthday;
                oCtrl.Add(MCtrl.SetBirthday);
            }
            if (!string.IsNullOrEmpty(mCustomerNew.Company))
            {
                mCustomerOld.Company = mCustomerNew.Company;
                oCtrl.Add(MCtrl.SetCompanyName);
            }
            if (!string.IsNullOrEmpty(mCustomerNew.Nation))
            {
                mCustomerOld.Nation = mCustomerNew.Nation;
                oCtrl.Add(MCtrl.SetNation);
            }
            if (!string.IsNullOrEmpty(mCustomerNew.Phone))
            {
                mCustomerOld.Phone = mCustomerNew.Phone;
                oCtrl.Add(MCtrl.SetPhone);
            }
            if (!string.IsNullOrEmpty(mCustomerNew.Picture))
            {
                mCustomerOld.Picture = mCustomerNew.Picture;
                oCtrl.Add(MCtrl.SetPicture);
            }
            if (!string.IsNullOrEmpty(mCustomerNew.Sex))
            {
                mCustomerOld.Sex = mCustomerNew.Sex;
                oCtrl.Add(MCtrl.SetSex);
            }
            if (!mCustomerNew.Type.Equals(mCustomerOld.Type))
            {
                mCustomerOld.Type = mCustomerNew.Type;
                oCtrl.Add(MCtrl.SetCustomerType);
            }
            mCustomerNew.CustomerId = mCustomerOld.CustomerId;
            mCustomerOld.CommonInfo.UpdateUserId = mCustomerNew.CommonInfo.UpdateUserId;
            bCustomer.UpdateCustomer(mCustomerOld, oCtrl);
        }

        /// <summary>
        /// 开房以及修改房间信息逻辑.支持房间多人以及团体开房.支持房间人数变更以及宾客信息变更.
        /// </summary>
        /// <param name="listCustomerStayInfo"></param>
        /// <param name="listCustomerInfo"></param>
        /// <param name="eRmType"></param>
        /// <returns></returns>
        public bool OpendOrUpdateRoom(List<CustomerStayModel> listCustomerStayInfo, List<CustomerModel> listCustomerInfo, RoomLogicType eRmType)
        {
            try
            {
                if (listCustomerStayInfo[0].RoomStayType == 'D' && listCustomerStayInfo[0].Hours == 0)
                {
                    throw new Exception("非钟点房,预住天数不能为零.");
                }
                if (eRmType == RoomLogicType.OpenRoom)
                {
                    #region 开单
                  
                    //如团体开房,则每个房间新增一个StayId
                    foreach (CustomerStayModel mCustomerStay in listCustomerStayInfo)
                    {
                        int nStayId = bCustomerStay.InsertCustomerStay(mCustomerStay);
                        BasRoomModel mRoom = new BasRoomModel();
                        mRoom.RoomId = mCustomerStay.RoomId;
                        mRoom.Status = mCustomerStay.RoomInfo.Status;
                        mRoom.CommonInfo = mCustomerStay.CommonInfo;
                        UpdateRoomStatusByRoomId(mRoom, new SysUserInfoModel(mCustomerStay.CommonInfo.UpdateUserId));
                        //每个房间可能多个入住人员
                        foreach (CustomerModel mCustomer in listCustomerInfo)
                        {
                            //检查宾客信息是否存在,存在则更新较新的信息.姓名和证件号不更新
                            List<CustomerModel> listCustomerOld = GetExistCustomerInfo(mCustomer);
                            int nCustomerId = 0;
                            if (cmn.CheckEOF(listCustomerOld))
                            {
                                UpdateExsitCustomerInfo(mCustomer, listCustomerOld[0]);
                                nCustomerId = listCustomerOld[0].CustomerId;
                            }
                            else
                            {
                                nCustomerId = bCustomer.InsertCustomer(mCustomer);
                            }
                            CustomerStayHisModel mHis = new CustomerStayHisModel();
                            mHis.StayId = nStayId;
                            mHis.CustomerId = nCustomerId;
                            mHis.StayType = mCustomer.CustomerStayHisInfo.StayType;
                            mHis.HisStatus = 'E';
                            mHis.CommonInfo = new CommonModel();
                            mHis.CommonInfo.StartDate = mCustomerStay.CommonInfo.StartDate;
                            mHis.CommonInfo.EndDate = mCustomerStay.CommonInfo.EndDate;

                            mHis.CommonInfo.CreateDate = mCustomerStay.CommonInfo.CreateDate;
                            mHis.CommonInfo.CreateUserId = mCustomerStay.CommonInfo.CreateUserId;

                            bCustomerStay.InsertCustomerStayHis(mHis);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 修改房间信息

                    foreach (CustomerStayModel mCustomerStay in listCustomerStayInfo)
                    {
                        ObjectControls oCtrl = new ObjectControls();
                        oCtrl.Add(MCtrl.SetDeposit);
                        oCtrl.Add(MCtrl.SetMainRoomId);
                        oCtrl.Add(MCtrl.SetNotice);
                        oCtrl.Add(MCtrl.SetPayType);
                        oCtrl.Add(MCtrl.SetRoomId);
                        oCtrl.Add(MCtrl.SetRoomRate);
                        oCtrl.Add(MCtrl.SetCustomerStayStatus);
                        oCtrl.Add(MCtrl.SetRoomStayType);
                        oCtrl.Add(MCtrl.SetEndDate);
                        oCtrl.Add(MCtrl.SetHours);
                        //修改入住信息
                        bCustomerStay.UpdateCustomerStay(mCustomerStay, oCtrl);
                        foreach (CustomerModel mCustomer in listCustomerInfo)
                        {
                            //检查宾客信息是否存在,存在则更新较新的信息.姓名和证件号不更新
                            List<CustomerModel> listCustomerOld = GetExistCustomerInfo(mCustomer);
                            int nCustomerId = 0;
                            if (cmn.CheckEOF(listCustomerOld))
                            {
                                mCustomer.CommonInfo.UpdateUserId = mCustomerStay.CommonInfo.UpdateUserId;
                                UpdateExsitCustomerInfo(mCustomer, listCustomerOld[0]);
                                nCustomerId = listCustomerOld[0].CustomerId;
                            }
                            else
                            {
                                nCustomerId = bCustomer.InsertCustomer(mCustomer);
                            }
                            CustomerStayHisModel mHis = new CustomerStayHisModel();
                            mHis.StayId = mCustomerStay.StayId;
                            mHis.CustomerId = nCustomerId;
                            oCtrl.Reset();
                            oCtrl.Add(MCtrl.ByStayId);
                            oCtrl.Add(MCtrl.ByCustomerId);
                            List<CustomerStayHisModel> listStayHis = bCustomerStay.GetStayHis(mHis, oCtrl);
                            if (cmn.CheckEOF(listStayHis))
                            {
                                mHis.HisId = listStayHis[0].HisId;
                                mHis.HisStatus = mCustomer.CustomerStayHisInfo.HisStatus;
                                mHis.StayType = mCustomer.CustomerStayHisInfo.StayType;
                                mHis.CommonInfo = new CommonModel();
                                mHis.CommonInfo.UpdateUserId = mCustomerStay.CommonInfo.UpdateUserId;
                                oCtrl.Reset();
                                oCtrl.Add(MCtrl.SetHisStatus);
                                oCtrl.Add(MCtrl.SetHisType);
                                //如果用户选择将房间内某一宾客离店,则该宾客的离店时间为现在.开始时间不变
                                if (mHis.HisStatus == 'O')
                                {
                                    mHis.CommonInfo.EndDate = cmn.DateBaseDate;
                                    oCtrl.Add(MCtrl.SetEndDate);
                                }
      
                                bCustomerStay.UpdateStayHis(mHis, oCtrl);
                            }
                            else
                            {
                                mHis.StayType = mCustomer.CustomerStayHisInfo.StayType;
                                mHis.HisStatus = mCustomer.CustomerStayHisInfo.HisStatus;
                                mHis.CommonInfo = new CommonModel();
                                mHis.CommonInfo.CreateUserId = mCustomerStay.CommonInfo.UpdateUserId;
                                mHis.CommonInfo.UpdateUserId = mCustomerStay.CommonInfo.UpdateUserId;

                                //如宾客为新增加到该房间内的.则他的入住时间从现在开始,到该房间的预住结束时间为止.
                                mHis.CommonInfo.StartDate = cmn.DateBaseDate;
                                mHis.CommonInfo.EndDate = mCustomerStay.CommonInfo.EndDate;

                                bCustomerStay.InsertCustomerStayHis(mHis);
                            }
                        }
                    }
                    #endregion
                }
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 退房逻辑
        /// </summary>
        /// <param name="listCustomerStayInfo"></param>
        /// <returns></returns>
        public bool CheckOutRoom(List<CustomerStayModel> listCustomerStayInfo)
        {
            try
            {
                ObjectControls oCtrl=new ObjectControls ();
                foreach (CustomerStayModel mCustomerStay in listCustomerStayInfo)
                {
                    #region 修改房间状态
                    mCustomerStay.RoomInfo.Status = 'C';
                    UpdateRoomStatusByRoomId(mCustomerStay.RoomInfo, new SysUserInfoModel(mCustomerStay.CommonInfo.UpdateUserId));

                    #endregion

                    #region 更新入住信息

                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.SetCustomerStayStatus);
                    oCtrl.Add(MCtrl.SetDeposit);
                    oCtrl.Add(MCtrl.SetEndDate);
                    oCtrl.Add(MCtrl.SetHours);
                    oCtrl.Add(MCtrl.SetNotice);
                    oCtrl.Add(MCtrl.SetPayType);
                    oCtrl.Add(MCtrl.SetPaidMoney);
                    oCtrl.Add(MCtrl.SetStayNo);
                    oCtrl.Add(MCtrl.SetTotal);
                    bCustomerStay.UpdateCustomerStay(mCustomerStay,oCtrl);
                    //退房时将stayhis的入住状态改为离店模式，以区分每个宾客的状态。有时候宾馆房间某一宾客会提前离开，所以需要设置每个宾客的状态。
                    //如提前离开需修改宾客登记，右击宾客详细列表，在菜单中进行离店操作。
                    //如要遇到宾客信息登记错误，需要删除，则启用DELETE键删除即可。
                    if (cmn.CheckEOF(mCustomerStay.CustomerList))
                    {
                        foreach (CustomerModel mcustomer in mCustomerStay.CustomerList)
                        {
                            CustomerStayHisModel mcshis = mcustomer.CustomerStayHisInfo;

                            //整个房间退房时,将HIS状态不为O的人改为O:OFF 离店.离店时间为现在.如果该宾客以及事先离店,则不更新.
                            if (mcshis.HisStatus != 'O')
                            {
                                oCtrl.Reset();
                                mcshis.HisStatus = 'O';
                                mcshis.CommonInfo.EndDate = cmn.DateBaseDate;
                                mcshis.CommonInfo.UpdateUserId = mCustomerStay.CommonInfo.UpdateUserId;//更新人员为操作员ID
                                oCtrl.Add(MCtrl.SetEndDate);
                                oCtrl.Add(MCtrl.SetHisStatus);
                                bCustomerStay.UpdateStayHis(mcshis, oCtrl);
                            }
                        }
                    }
                    #endregion
                }
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 增加消费逻辑.
        /// </summary>
        /// <param name="listLatestConsume">最新的消费列表,一定要包括之前消费的</param>
        /// <param name="listConsumeOld">上次消费的列表</param>
        public void AddConsume(List<ConsumeDetailModel> listLatestConsume, List<ConsumeDetailModel> listConsumeOld)
        {
            try
            {
                if (cmn.CheckEOF(listLatestConsume))
                {
                    if (cmn.CheckEOF(listConsumeOld))
                    {
                        var query = listLatestConsume.Except(listConsumeOld);
                        foreach (ConsumeDetailModel mConsume in query)
                        {
                            if (mConsume.ConsumeId == -1)
                            {
                                bConsume.InsertConsumeDetail(mConsume);
                            }
                        }
                        query = listConsumeOld.Except(listLatestConsume);
                        foreach (ConsumeDetailModel mConsume in query)
                        {
                            bConsume.DeleteConsumeDetail(mConsume);
                        }
                    }
                    else
                    {
                        foreach (ConsumeDetailModel mConsume in listLatestConsume)
                        {
                            bConsume.InsertConsumeDetail(mConsume);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 换房逻辑,换房只能从一个已入住房间换到状态为可用的房间.
        /// </summary>
        /// <param name="mCustomerStay">入住信息</param>
        /// <param name="mNewRoomInfo">新房信息</param>
        /// <param name="dNewRoomRate">新房费用</param>
        /// <param name="mUserInfo">系统用户信息</param>
        /// <param name="listSysParameter">系统参数</param>
        public void ChangeRoom(CustomerStayModel mCustomerStay, BasRoomModel mNewRoomInfo,double dNewRoomRate, SysUserInfoModel mUserInfo, List<SysParameterModel> listSysParameter)
        {
            try
            {
                #region 将之前房间费用(光房间费用)加入到消费清单中.

                ConsumeDetailModel mConsume = new ConsumeDetailModel();
                BasGoodsModel mGoods = new BasGoodsModel();
                mGoods.Type = 'R';
                List<BasGoodsModel> listGoods = bGoods.GetGoodsInfo(mGoods, new ObjectControls(MCtrl.ByGoodsType));
                if (cmn.CheckEOF(listGoods))
                {
                    mConsume.GoodsId = listGoods[0].GoodsId;
                }
                else
                {
                    throw new Exception("未定义类型的R的商品,该类型为房间费.");
                }
                mConsume.StayId = mCustomerStay.StayId;
                mConsume.UnitPrice = mCustomerStay.RoomRate;
                RoomStayType eRst = mCustomerStay.RoomStayType == 'D' ? RoomStayType.Day : RoomStayType.Hour;
                DateTime dtNow = cmn.DateBaseDate;
                mConsume.Number = GetCustomerStayDays(mCustomerStay.CommonInfo.StartDate, dtNow,dtNow, eRst, listSysParameter);
                mConsume.Total = GetTotalRates(mCustomerStay, null, listSysParameter, dtNow, 0.0);
                mConsume.CommonInfo = new CommonModel();
                mConsume.CommonInfo.CreateDate = mCustomerStay.CommonInfo.StartDate;
                mConsume.CommonInfo.CreateUserId = mUserInfo.UserId;
                mConsume.CommonInfo.UpdateUserId = mUserInfo.UserId;
                bConsume.InsertConsumeDetail(mConsume);

                #endregion

                #region 是否团队房间
                if (mCustomerStay.MainRoomId == mCustomerStay.RoomId)
                {
                    if (cmn.Confirm(string.Format("{0}为主房间,变更后{1}将成为主房间,是否继续?", mCustomerStay.RoomInfo.RoomNo, mNewRoomInfo.RoomNo)))
                    {
                        #region 将团队房间的MainRoomId变为新ID
                        List<BasRoomModel> listTeamRoom = GetTeamRoomListByRoomId(mCustomerStay.RoomInfo, 'I');
                        if (cmn.CheckEOF(listTeamRoom))
                        {
                            ObjectControls oCtrl = new ObjectControls();
                            oCtrl.Add(MCtrl.SetMainRoomId);
                            foreach (BasRoomModel mRoom in listTeamRoom)
                            {
                                CustomerStayModel mCs = new CustomerStayModel();
                                mCs.RoomId = mRoom.RoomId;
                                mCs.Status = 'I';
                                ObjectControls oc = new ObjectControls();
                                oc.Add(MCtrl.ByStayStatus);
                                oc.Add(MCtrl.ByRoomId);
                                mCs = bCustomerStay.GetCustomerStayInfo(mCs, oc);
                                if (mCs != null)
                                {
                                    mCs.MainRoomId = mNewRoomInfo.RoomId;
                                    bCustomerStay.UpdateCustomerStay(mCs, oCtrl);
                                }
                            }
                        }
                        #endregion
                    }
                }
                #endregion

                #region 将原来房间置为清理,将新房间设置为入住

                ObjectControls oCtrlMain = new ObjectControls();
                oCtrlMain.Add(MCtrl.SetRoomId);
                oCtrlMain.Add(MCtrl.SetStartDate);
                oCtrlMain.Add(MCtrl.SetHours);
                oCtrlMain.Add(MCtrl.SetRoomRate);
                mCustomerStay.RoomId = mNewRoomInfo.RoomId;
                mCustomerStay.CommonInfo.StartDate = cmn.DateBaseDate;
                double dDays = GetCustomerStayDays(mCustomerStay.CommonInfo.StartDate, mCustomerStay.CommonInfo.EndDate,mCustomerStay.CommonInfo.StartDate, eRst, listSysParameter);

                mCustomerStay.Hours = eRst == RoomStayType.Day ? Convert.ToInt32(dDays * 24) : Convert.ToInt32(dDays);
                mCustomerStay.RoomRate = dNewRoomRate;
                bCustomerStay.UpdateCustomerStay(mCustomerStay, oCtrlMain);

                mNewRoomInfo.Status = mCustomerStay.RoomInfo.Status;
                UpdateRoomStatusByRoomId(mNewRoomInfo, mUserInfo);

                mCustomerStay.RoomInfo.Status = 'C';
                UpdateRoomStatusByRoomId(mCustomerStay.RoomInfo, mUserInfo);

                #endregion
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 检测房间在这段时间内被预定或者处于不可预定状态.不可预定状态一般为RoomStatus为D
        /// </summary>
        /// <param name="listOrderedInfo">已预定的信息</param>
        /// <param name="mRoom">预定的房间</param>
        /// <param name="dtStartTime">预抵时间</param>
        /// <param name="dtEndTime">预离时间</param>
        /// <returns>如果验证通过返回True,反之返回False</returns>
        public bool CheckRoomOrdered(List<OrderInfoModel>listOrderedInfo,BasRoomModel mRoom, DateTime dtStartTime,DateTime dtEndTime)
        {
            if (cmn.CheckEOF(listOrderedInfo))
            {
                var qOrder = listOrderedInfo.Where(c => c.RoomInfo.RoomId == mRoom.RoomId);
                if (qOrder.Count() > 0 && (qOrder.First().RoomInfo.Status != 'E' ||
                    (qOrder.First().CommonInfo.StartDate < dtStartTime && qOrder.First().CommonInfo.EndDate > dtStartTime) ||
                     (qOrder.First().CommonInfo.StartDate < dtEndTime && qOrder.First().CommonInfo.EndDate > dtEndTime)
                    ))
                {
                    if (!cmn.Confirm("该房间目前处于非可用状态或者已经被预定,是否继续?"))
                    {
                        return false;
                    }
                }
            }
            else if (mRoom.Status != 'E')
            {
                if (!cmn.Confirm("该房间目前处于非可用状态,是否继续?"))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取交接班信息
        /// </summary>
        /// <returns></returns>
        public HandOverModel GetHandOverInfo()
        {
            try
            {
                HandOverInfo bHandOver = new HandOverInfo();
                int nHandOverId = bHandOver.GetHandOverLatestId();
                ObjectControls oCtrl = new ObjectControls();
                List<HandOverModel> listHandOver = new List<HandOverModel>();
                HandOverModel mHandOver = new HandOverModel();
                CustomerStayModel mCustomerStay = new CustomerStayModel();

                if (nHandOverId > 0)
                {
                    mHandOver.HandOverId = nHandOverId;
                    listHandOver = bHandOver.GetHandOverList(mHandOver, new ObjectControls(MCtrl.ByHandOverId));
                    if (cmn.CheckEOF(listHandOver))
                    {
                        mCustomerStay.CommonInfo.CreateDate = listHandOver[0].CommonInfo.EndDate;
                        mHandOver.CommonInfo.StartDate = listHandOver[0].CommonInfo.EndDate;
                        mHandOver.FromLastMoney = listHandOver[0].ToNextMoney;
                    }
                }
                else
                {
                    mCustomerStay.CommonInfo.CreateDate = DateTime.Parse("2005-01-01");
                    mHandOver.CommonInfo.StartDate = mCustomerStay.CommonInfo.CreateDate;
                    mHandOver.FromLastMoney = 0.0;
                }
                oCtrl.Add(MCtrl.ByCreateDate);
                mCustomerStay.Status = 'I';
                oCtrl.Add(MCtrl.ByStayStatus);
                mHandOver.CurrentDeposit = bCustomerStay.GetHandOverStayInfo(mCustomerStay, oCtrl).CurrentDeposit;
                mCustomerStay.Status = 'O';
                mHandOver.CurrentPaidMoney = bCustomerStay.GetHandOverStayInfo(mCustomerStay, oCtrl).CurrentPaidMoney;
                mHandOver.CommonInfo.EndDate = cmn.DateBaseDate;
                mHandOver.HandInMoney = 0;
                mHandOver.HandOverMoney = mHandOver.FromLastMoney + mHandOver.CurrentDeposit + mHandOver.CurrentPaidMoney;
                mHandOver.ToNextMoney = mHandOver.HandOverMoney;
                return mHandOver;
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        /// <summary>
        /// 从WebService获取电话计费总额
        /// </summary>
        /// <param name="mCustomerStay"></param>
        /// <param name="listSysParameter"></param>
        /// <returns></returns>
        public double GetPhoneJF(List<JFModel> listJf,List<PhoneCatModel>listCat)
        {
            try
            {
                double dPhoneTotal = 0.0;
                if (cmn.CheckEOF(listJf))
                {
                    foreach (JFModel mjfTmp in listJf)
                    {
                        dPhoneTotal += GetPhoneRate(mjfTmp, listCat);
                    }
                }
                return dPhoneTotal;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<JFModel> GetPhoneList(JFModel mJf, DateTime dtmNow)
        {
            ObjectControls oCtrl = new ObjectControls();
            oCtrl.Add(MCtrl.ByPhone);
            oCtrl.Add(MCtrl.ByStartDate);
            mJf.PhoneNoGroup = cmn.RemoveLastDou(mJf.PhoneNoGroup);
            return bPhone.GetPhoneDetail(mJf, oCtrl, dtmNow);
        }

        private double GetPhoneRate(JFModel mJf,List<PhoneCatModel>listCat)
        {
            try
            {
                if (mJf.FreeId != 0)
                {
                    var query = listCat.Where(c => c.CatId == mJf.OpCat).FirstOrDefault();
                    if (query.CatId > 0)
                    {
                        double dMinutes = mJf.CommonInfo.EndDate.Subtract(mJf.CommonInfo.StartDate).TotalMinutes;
                        if (dMinutes - Math.Truncate(dMinutes) > 0)
                        {
                            dMinutes = Math.Truncate(dMinutes) + 1;
                        }
                        return query.CatRate * dMinutes;
                    }
                }
                return 0.0;
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 更新团体房间的MainId,用于将团体房变为散客房
        /// </summary>
        /// <param name="mCustomerStay"></param>
        /// <returns></returns>
        public bool UpdateCustomerStayMainRoomId(CustomerStayModel mCustomerStay)
        {
            try
            {
                ObjectControls oCtrl = new ObjectControls();
                oCtrl.Add(MCtrl.ByStayStatus);
                oCtrl.Add(MCtrl.ByMainRoomId);
                //获取该房所在的团体所有房间
                List<BasRoomModel> listTeamRoom = bRoom.GetTeamRoomList(mCustomerStay, oCtrl);
                //是否有其他房间可以作为主房间
                var query = listTeamRoom.Where(c => c.RoomId != mCustomerStay.RoomId);
                if (query.Count() > 0)
                {
                    if (cmn.Confirm(string.Format("房间{0}是主房间,变为散客房之后,团队的主房间将变为{1},继续?", mCustomerStay.RoomInfo.RoomNo, query.First().RoomNo)))
                    {
                        List<CustomerStayModel> listTeamCustomer = new List<CustomerStayModel>();
                        listTeamCustomer = GetStayInRoomInfo(listTeamRoom, 'I',"M", false);

                        int nMainRoomId = query.First().RoomId;
                        foreach (CustomerStayModel mcs in listTeamCustomer)
                        {
                            if (mcs.RoomId == mCustomerStay.RoomId)
                            {
                                mcs.MainRoomId = -1; ;
                            }
                            else
                            {
                                mcs.MainRoomId = nMainRoomId;
                            }
                            bCustomerStay.UpdateCustomerStay(mcs, new ObjectControls(MCtrl.SetMainRoomId));
                        }
                        return true;
                    }
                }
                else
                {
                    throw new Exception("无主房间可供接替,无法变更为散客房!");
                }
                return false;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public void UpdateSingleRoomToTeamRoom(CustomerStayModel mCustomerStay,int nMainRoomId,int nTeamMainCustomerId,SysUserInfoModel mUserInfo)
        {
            try
            {
                mCustomerStay.MainRoomId = nMainRoomId;
                bCustomerStay.UpdateCustomerStay(mCustomerStay, new ObjectControls(MCtrl.SetMainRoomId));

                CustomerStayHisModel mHis = new CustomerStayHisModel();
                mHis.StayId = mCustomerStay.StayId;
                if (mCustomerStay.CustomerList[0].CustomerId > 0)
                {
                    if (mCustomerStay.CustomerList.Where(c => c.CustomerId == nTeamMainCustomerId).Count() == 0)
                    {
                        mHis.HisId = mCustomerStay.CustomerList[0].CustomerStayHisInfo.HisId;
                        mHis.StayType = 'S';
                        mHis.CommonInfo = new CommonModel();
                        mHis.CommonInfo.UpdateUserId = mUserInfo.UserId;
                        bCustomerStay.UpdateStayHis(mHis, new ObjectControls(MCtrl.SetHisType));

                        mHis.StayType = 'M';
                        mHis.HisStatus = 'E';
                        mHis.CustomerId = nTeamMainCustomerId;
                        mHis.CommonInfo = new CommonModel();
                        mHis.CommonInfo.CreateUserId = mUserInfo.UserId;
                        mHis.CommonInfo.UpdateUserId = mUserInfo.UserId;
                        bCustomerStay.InsertCustomerStayHis(mHis);
                    }
                }
                else
                {
                    mHis.StayType = 'M';
                    mHis.HisStatus = 'E';
                    mHis.CustomerId = nTeamMainCustomerId;
                    mHis.CommonInfo = new CommonModel();
                    mHis.CommonInfo.CreateUserId = mUserInfo.UserId;
                    mHis.CommonInfo.UpdateUserId = mUserInfo.UserId;
                    bCustomerStay.InsertCustomerStayHis(mHis);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<SysLookupCodeModel> GetCodeDesc(string sTable, string sColumn)
        {
            SysLookupCodeModel mSysLookupCode = new SysLookupCodeModel();
            mSysLookupCode.TableName = sTable;
            mSysLookupCode.ColumnName = sColumn;
            ObjectControls oLookCode = new ObjectControls();
            oLookCode.Add(MCtrl.ByColumnName);
            oLookCode.Add(MCtrl.ByTableName);
            return bLookUpCode.GetSysLookUpCode(mSysLookupCode, oLookCode);
        }

        public List<CustomerStayModel> GetCustomerDepositDetail(char cPayType,List<SysParameterModel> listSysParameter, DateTime dtmNow)
        {
            List<CustomerStayModel> listCustomer = new List<CustomerStayModel>();
            listCustomer = GetStayInRoomInfo(new List<BasRoomModel>(), 'I', "M", true);
            var query = listCustomer.Where(c => c.PayType == cPayType);
            foreach (CustomerStayModel mcs in query)
            {
                mcs.Total = GetTotalRates(mcs, mcs.ConSumeDetailList, listSysParameter, dtmNow, 0.0);
            }
            return query.ToList();
        }


        public void DoStayRate(StayRateModel mStayRate)
        { 
            List<StayRateModel> listStayRate = bStayRate.GetStayRate(mStayRate, new ObjectControls(MCtrl.ByCreateDate));
            if (cmn.CheckEOF(listStayRate))
            {
                listStayRate[0].StayRate = mStayRate.StayRate;
                bStayRate.UpdateStayRate(listStayRate[0]);
            }
            else
            {
                bStayRate.InsertStayRate(mStayRate);
            }
        }
    }
}
