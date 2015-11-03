using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;

namespace Hotel.DAL
{
    public class SysParameterDao:AbBaseDao
    {
        public List<SysParameterModel> GetSysParameter(SysParameterModel mParameter, ObjectControls oCtrl)
        {
            string sql = "SELECT A.PARAM_ID,A.PARAM_NO,A.PARAM_NAME,A.PARAM_DESC,A.VALUE1,A.VALUE2,A.VALUE3 FROM SYS_PARAMETER A WHERE 1=1";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByParameterId)   && oCtrl.Append(ref sql, " AND A.PARAM_ID=" + mParameter.ParamId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByParameterNo)   && oCtrl.Append(ref sql, " AND A.PARAM_NO=" + mParameter.ParamNo));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByParameterName) && oCtrl.Append(ref sql, " AND A.PARAM_NAME=" + mParameter.ParamName));
            sdr = ExecuteReader(sql);
            List<SysParameterModel> listParameter = new List<SysParameterModel>(); 
            using (sdr)
            {
                while (sdr.Read())
                {
                    SysParameterModel mSysParameterInfo = new SysParameterModel();
                    mSysParameterInfo.ParamId   = ToInt32(sdr["PARAM_ID"]);
                    mSysParameterInfo.ParamNo   = ToString(sdr["PARAM_NO"]);
                    mSysParameterInfo.ParamName = ToString(sdr["PARAM_NAME"]);
                    mSysParameterInfo.ParamDesc = ToString(sdr["PARAM_DESC"]);
                    mSysParameterInfo.Value1    = ToString(sdr["VALUE1"]);
                    mSysParameterInfo.Value2    = ToString(sdr["VALUE2"]);
                    mSysParameterInfo.Value3    = ToString(sdr["VALUE3"]);
                    listParameter.Add(mSysParameterInfo);
                }
            }
            return listParameter;
        }

        public int UpdateParameter(SysParameterModel mParameter, ObjectControls oCtrl)
        {
            string sql = "UPDATE SYS_PARAMETER SET PARAM_NO=PARAM_NO ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetValue1) && oCtrl.Append(ref sql, ",VALUE1=" + SQL(mParameter.Value1)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetValue2) && oCtrl.Append(ref sql, ",VALUE2=" + SQL(mParameter.Value2)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetValue3) && oCtrl.Append(ref sql, ",VALUE3=" + SQL(mParameter.Value3)));
            sql += " WHERE PARAM_ID=" + mParameter.ParamId;
            return ExcuteNonQuery(sql);

        }
    }
}
