using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 系统参数
    /// </summary>
    public class SysParameterModel
    {
        public int ParamId { get; set; }
        public string ParamNo { get; set; }
        public string ParamName { get; set; }
        public string ParamDesc { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }
}
