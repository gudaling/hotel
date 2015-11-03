using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    public class StayRateModel
    {
        public StayRateModel()
        {
            Id = -1;
        }

        public int Id { get; set; }

        /// <summary>
        /// 入住率
        /// </summary>
        public double StayRate { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Days { get; set; }

        public CommonModel CommonInfo { get; set; }
    }
}
