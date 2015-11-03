using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;
using Hotel.DAL;

namespace Hotel.BLL
{
    public class CallInfo:AbBaseBll
    {
        private CallInfoDao dCall = new CallInfoDao();

        /// <summary>
        /// 获取电话清单
        /// </summary>
        /// <param name="mCall"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<CallModel> GetCallList(CallModel mCall, ObjectControls oCtrl)
        {
            return dCall.GetCallList(mCall, oCtrl);
        }

        public int InsertCallList(CallModel mCall)
        {
            return dCall.InsertCallList(mCall);
        }
        /// <summary>
        /// 获取电话拨打类别以及其计费标准
        /// </summary>
        /// <param name="mPhoneCat"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<PhoneCatModel> GetPhoneCatList(PhoneCatModel mPhoneCat, ObjectControls oCtrl)
        {
            return dCall.GetPhoneCatList(mPhoneCat, oCtrl);
        }

    }
}
