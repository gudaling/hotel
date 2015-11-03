using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Hotel.DAL;
using Hotel.Model;
using Hotel.Common;

namespace Hotel.BLL
{
    public class SysLookUpCodeInfo
    {
        private SysLookupCodeDao dSysLookupCode = new SysLookupCodeDao();

        /// <summary>
        /// 获取系统代码描述
        /// </summary>
        /// <param name="mSysLookupCode"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<SysLookupCodeModel> GetSysLookUpCode(SysLookupCodeModel mSysLookupCode, ObjectControls oCtrl)
        {
            return dSysLookupCode.GetSysLookUpCode(mSysLookupCode, oCtrl);
        }

    }
}
