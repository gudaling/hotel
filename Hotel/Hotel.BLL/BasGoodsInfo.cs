using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;
using Hotel.DAL;

namespace Hotel.BLL
{
    public class BasGoodsInfo:AbBaseBll
    {
        private BasGoodsDao dGoodsDao = new BasGoodsDao();
        public BasGoodsInfo()
        { 
            
        }
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="mGoods"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<BasGoodsModel> GetGoodsInfo(BasGoodsModel mGoods, ObjectControls oCtrl)
        {
            return dGoodsDao.GetGoodsInfo(mGoods, oCtrl);
        }
        public int DeleteGoods(BasGoodsModel mGoods)
        {
            return dGoodsDao.DeleteGoods(mGoods);   
        }
        public int InsertGoods(BasGoodsModel mGoods)
        {
            return dGoodsDao.InsertGoods(mGoods);   
        }
        public int UpdateGoods(BasGoodsModel mGoods, ObjectControls oCtrl)
        {
            return dGoodsDao.UpdateGoods(mGoods,oCtrl);   
        }
    }
}
