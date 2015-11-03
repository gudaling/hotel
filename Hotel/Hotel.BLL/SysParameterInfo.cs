using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Hotel.Model;
using Hotel.DAL;
using Hotel.Common;

namespace Hotel.BLL
{
    public class SysParameterInfo:AbBaseBll
    {
        private SysParameterDao dSysParameter = new SysParameterDao();

        //public List<SysParameterModel> GetParameterList(SysParameterModel mParameter)
        //{
        //    var query = dc.SYS_PARAMETER.Where(c => c.PARAM_NO == mParameter.ParamNo);
        //    List<SysParameterModel> listParameter = new List<SysParameterModel>();
        //    Log.WriteLog(dc, query, AbBaseBll.IsWriteSql);
        //    foreach (SYS_PARAMETER sp in query)
        //    {
        //        SysParameterModel mSysParameterNew = new SysParameterModel();
        //        mSysParameterNew.ParamId = sp.PARAM_ID;
        //        mSysParameterNew.ParamName = sp.PARAM_NAME;
        //        mSysParameterNew.ParamNo = sp.PARAM_NO;
        //        mSysParameterNew.Value1 = sp.VALUE1;
        //        mSysParameterNew.Value2 = sp.VALUE2;
        //        mSysParameterNew.Value3 = sp.VALUE3;
        //        listParameter.Add(mSysParameterNew);
        //    }
        //    return listParameter;
        //}

        /// <summary>
        /// 获取系统设置参数表
        /// </summary>
        /// <param name="mParameter"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<SysParameterModel> GetSysParameter(SysParameterModel mParameter, ObjectControls oCtrl)
        {
            return dSysParameter.GetSysParameter(mParameter, oCtrl);   
        }
        public int UpdateParameter(SysParameterModel mParameter, ObjectControls oCtrl)
        {
            return dSysParameter.UpdateParameter(mParameter, oCtrl);  
        }
    }
}
