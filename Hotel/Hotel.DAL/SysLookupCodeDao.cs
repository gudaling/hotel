using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;

namespace Hotel.DAL
{
    public class SysLookupCodeDao:AbBaseDao
    {
        public List<SysLookupCodeModel> GetSysLookUpCode(SysLookupCodeModel mSysLookupCode,ObjectControls oCtrl)
        {
            string sql = "SELECT A.CODE_ID,A.CODE_NO,A.TABLE_NAME,A.COLUMN_NAME,A.CODE_DESC FROM SYS_LOOKUP_CODE A WHERE 1=1";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCodeId) && oCtrl.Append(ref sql, " AND A.CODE_ID=" +mSysLookupCode.CodeId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByCodeNo) && oCtrl.Append(ref sql, " AND A.CODE_NO=" + SQL(mSysLookupCode.CodeNo)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByTableName) && oCtrl.Append(ref sql, " AND A.TABLE_NAME=" + SQL(mSysLookupCode.TableName)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByColumnName) && oCtrl.Append(ref sql, " AND A.COLUMN_NAME=" + SQL(mSysLookupCode.ColumnName)));
            sdr = ExecuteReader(sql);
            List<SysLookupCodeModel> listLookupCode = new List<SysLookupCodeModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    SysLookupCodeModel mCode = new SysLookupCodeModel();
                    mCode.CodeId = ToInt32(sdr["CODE_ID"]);
                    mCode.CodeNo = ToString(sdr["CODE_NO"]);
                    mCode.TableName = ToString(sdr["TABLE_NAME"]);
                    mCode.ColumnName = ToString(sdr["COLUMN_NAME"]);
                    mCode.CodeDesc = ToString(sdr["CODE_DESC"]);
                    listLookupCode.Add(mCode);
                }
            }
            return listLookupCode;
        }
    }
}
