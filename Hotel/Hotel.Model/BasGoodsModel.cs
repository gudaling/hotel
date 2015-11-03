using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class BasGoodsModel
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsUnit { get; set; }
        public double Price { get; set; }
        public char Type { get; set; }
        public char Status { get; set; }
    }
}
