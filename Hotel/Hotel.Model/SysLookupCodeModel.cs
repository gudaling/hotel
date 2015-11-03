using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 系统代码对应
    /// </summary>
    public class SysLookupCodeModel
    {
        public int CodeId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string CodeNo { get; set; }
        public string CodeDesc { get; set; }
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
    }
}
