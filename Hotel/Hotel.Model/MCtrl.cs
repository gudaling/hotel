using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class MCtrl
    {
        #region UserInfo

        public static readonly string ByUserId = "ByUserId";
        public static readonly string ByUserName = "ByUserName";
        public static readonly string ByUserNo = "ByUserNo";
        public static readonly string ByPassWord = "ByPassWord";

        #endregion

        #region SysLookupCode
        public static readonly string ByCodeId = "ByCodeId";
        public static readonly string ByCodeNo = "ByCodeNo";
        public static readonly string ByTableName = "ByTableName";
        public static readonly string ByColumnName = "ByColumnName";
        #endregion

        #region SysParameter

        public static readonly string ByParameterId = "ByParameterId";
        public static readonly string ByParameterNo = "ByParameterNo";
        public static readonly string ByParameterName = "ByParameterName";

        #endregion

        #region ByRoom&FLoor

        public static readonly string ByRoomNo = "ByRoomNo";
        public static readonly string ByRoomId = "ByRoomId";
        public static readonly string ByRoomIdGroup = "ByRoomIdGroup";
        public static readonly string ByMainRoomId = "ByMainRoomId";
        public static readonly string ByRoomType = "ByRoomType";
        public static readonly string ByRoomStatus = "ByRoomStatus";
        public static readonly string ByRoomStatusGroup = "ByRoomStatusGroup";
        public static readonly string ByFloorId = "ByFloorId";
        public static readonly string ByFloorName = "ByFloorName";
        public static readonly string ByFloorStatus = "ByFloorStatus";

        #endregion

        #region ByCustomer

        public static readonly string ByCustomerId = "ByCustomerId";
        public static readonly string ByMainCustomerId = "ByMainCustomerId";
        public static readonly string ByName = "ByName";
        public static readonly string ByIdCard = "ByIdCard";
        public static readonly string ByPhone = "ByPhone";
        public static readonly string BySex = "BySex";
        public static readonly string ByCustomerType = "ByCustomerType";
        public static readonly string ByCompanyName = "ByCompanyName";

        #endregion

        #region ByGoods

        public static readonly string ByGoodsId = "ByGoodsId";
        public static readonly string ByGoodsName = "ByGoodsName";
        public static readonly string ByGoodsUnit = "ByGoodsUnit";
        public static readonly string ByPrice = "ByPrice";
        public static readonly string ByGoodsType = "ByGoodsType";
        public static readonly string ByGoodsStatus = "ByGoodsStatus";
        #endregion

        #region ByCustomerStay
        public static readonly string ByStayId = "ByStayId";
        public static readonly string ByStayIdGroup = "ByStayIdGroup";
        public static readonly string ByStayNo = "ByStayNo";
        public static readonly string ByStayStatus = "ByStayStatus";
        public static readonly string ByPayType = "ByPayType";
        public static readonly string ByStartDate = "ByStartDate";
        public static readonly string ByEndDate = "ByEndDate";
        public static readonly string ByCreateDate = "ByCreateDate";
        public static readonly string ByUpdateDate = "ByUpdateDate";
        public static readonly string ByStayType = "ByStayType";
        public static readonly string ByHisStatus = "ByHisStatus";
        public static readonly string ByHisId = "ByHisId";
        public static readonly string ByRoomStayType = "ByRoomStayType";
        public static readonly string ByHisStatusNotEqual = "ByHisStatusNotEqual";

        public static readonly string ByHisStartTime = "ByHisStartTime";
        public static readonly string ByHisEndTime = "ByHisEndTime";
        public static readonly string ByHisStartOrEndTime = "ByHisStartOrEndTime";

        public static readonly string ByUpdateOrCreate = "ByUpdateOrCreate";

        #endregion

        #region ByOrder

        public static readonly string ByOrderId = "ByOrderId";
        public static readonly string ByOrderStatus = "ByOrderStatus";
        public static readonly string ByKeepDateEnable = "ByKeepDateEnable";
        public static readonly string ByKeepDateDisable = "ByKeepDateDisable";
        public static readonly string ByStartDateBetween = "ByStartDateBetween";
        public static readonly string ByEndDateBetween = "ByEndDateBetween";
        public static readonly string ByNPR = "ByNPR";

        #endregion

        #region ByHandOver

        public static readonly string ByHandOverId = "ByHandOverId";
        public static readonly string ByCUserId = "ByCUserId";
        public static readonly string ByNUserId = "ByNUserId";

        #endregion

        #region ByPrint

        public static readonly string ByPrintId = "ByPrintId";
        public static readonly string ByPrintDetailId = "ByPrintDetailId";
        public static readonly string ByPrintNo = "ByPrintNo";
        public static readonly string ByFreeId = "ByFreeId";

        #endregion

        #region ByCallList

        public static readonly string ByListId = "ByListId";
        public static readonly string ByCatId = "ByCatId";

        #endregion

        #region StayRate

        public static readonly string ById = "ById";


        #endregion

        #region SetCustomer

        public static readonly string SetName = "SetName";
        public static readonly string SetIdCard = "SetIdCard";
        public static readonly string SetPhone = "SetPhone";
        public static readonly string SetSex = "SetSex";
        public static readonly string SetCustomerType = "SetCustomerType";
        public static readonly string SetStayId = "SetStayId";
        public static readonly string SetCompanyName = "SetCompanyName";
        public static readonly string SetNation = "SetNation";
        public static readonly string SetBirthday = "SetBirthday";
        public static readonly string SetAddress = "SetAddress";
        public static readonly string SetPicture = "SetPicture";

        #endregion

        #region SetRoom
        public static readonly string SetRoomId = "SetRoomId";
        public static readonly string SetRoomNo = "SetRoomNo";
        public static readonly string SetRoomType = "SetRoomType";
        public static readonly string SetRoomRate = "SetRoomRate";
        public static readonly string SetFloorId = "SetFloorId";
        public static readonly string SetRoomStatus = "SetRoomStatus";

        #endregion

        #region SetCustomerStay

        public static readonly string SetCustomerId = "SetCustomerId";
        public static readonly string SetMainRoomId = "SetMainRoomId";
        public static readonly string SetStartDate = "SetStartDate";
        public static readonly string SetEndDate = "SetEndDate";
        public static readonly string SetDeposit = "SetDeposit";
        public static readonly string SetPayType = "SetPayType";
        public static readonly string SetPaidMoney = "SetPaidMoney";
        public static readonly string SetRoomStayType = "SetRoomStayType";
        public static readonly string SetCustomerStayStatus = "SetCustomerStayStatus";
        public static readonly string SetNotice = "SetNotice";
        public static readonly string SetTotal = "SetTotal";
        public static readonly string SetHours = "SetHours";
        public static readonly string SetStayNo = "SetStayNo";
        public static readonly string SetUpdateDate = "SetUpdateDate";
        public static readonly string SetUpdateUserId = "SetUpdateUserId";

        public static readonly string SetHisStatus = "SetHisStatus";
        public static readonly string SetHisType = "SetHisType";


        #endregion

        #region SetConsumeDetail

        public static readonly string SetGoodsName = "SetGoodsName";
        public static readonly string SetUnit = "SetUnit";
        public static readonly string SetGoodsStaus = "SetGoodsStaus";

        public static readonly string SetGoodsId = "SetGoodsId";
        public static readonly string SetUnitPrice = "SetUnitPrice";
        public static readonly string SetNumber = "SetNumber";

        #endregion

        #region SetOrder

        public static readonly string SetKeepDate = "SetKeepDate";
        public static readonly string SetOrderStatus = "SetOrderStatus";

        #endregion

        #region SetUserInfo

        public static readonly string SetPsw = "SetPsw";
        public static readonly string SetUserNo = "SetUserNo";
        public static readonly string SetUserName = "SetUserName";
        public static readonly string SetRoleId = "SetRoleId";
        public static readonly string SetSkinId = "SetSkinId";
        #endregion

        #region SetHandOver

        public static readonly string SetCUserId = "SetCUserId";
        public static readonly string SetNUserId = "SetNUserId";
        public static readonly string SetHandOverMoney = "SetHandOverMoney";
        public static readonly string SetHandInMoney = "SetHandInMoney";
        public static readonly string SetCurrentIncome = "SetCurrentIncome";
        public static readonly string SetToNextMoney = "SetToNextMoney";

        #endregion

        #region SetParameter
        public static readonly string SetValue1 = "SetValue1";
        public static readonly string SetValue2 = "SetValue2";
        public static readonly string SetValue3 = "SetValue3";

        #endregion


    }
}
