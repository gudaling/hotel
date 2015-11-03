using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Model;
using Hotel.Common;

namespace Hotel.DAL
{
    public class BasGoodsDao:AbBaseDao
    {
        public List<BasGoodsModel> GetGoodsInfo(BasGoodsModel mGoods, ObjectControls oCtrl)
        {
            string sql = @"SELECT GOODS_ID, GOODS_NAME, GOODS_UNIT, PRICE, TYPE, STATUS
                            FROM BAS_GOODS_INFO WHERE 1=1 ";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByGoodsId) && oCtrl.Append(ref sql, " AND GOODS_ID=" + mGoods.GoodsId));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByGoodsName) && oCtrl.Append(ref sql, " AND GOODS_NAME=" + SQL(mGoods.GoodsName)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByGoodsType) && oCtrl.Append(ref sql, " AND TYPE=" + SQL(mGoods.Type)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.ByGoodsStatus) && oCtrl.Append(ref sql, " AND STATUS=" + SQL(mGoods.Status)));
            sdr = ExecuteReader(sql);
            List<BasGoodsModel> listGoodsInfo = new List<BasGoodsModel>();
            using (sdr)
            {
                while (sdr.Read())
                {
                    BasGoodsModel mGoodsInfo = new BasGoodsModel();
                    mGoodsInfo.GoodsId = ToInt32(sdr["GOODS_ID"]);
                    mGoodsInfo.GoodsName = ToString(sdr["GOODS_NAME"]);
                    mGoodsInfo.GoodsUnit = ToString(sdr["GOODS_UNIT"]);
                    mGoodsInfo.Price = ToDouble(sdr["PRICE"]);
                    mGoodsInfo.Type = ToChar(sdr["TYPE"]);
                    mGoodsInfo.Status = ToChar(sdr["STATUS"]);
                    listGoodsInfo.Add(mGoodsInfo);

                }
            }
            return listGoodsInfo;
        }

        public int UpdateGoods(BasGoodsModel mGoods, ObjectControls oCtrl)
        {
            string sql = "UPDATE BAS_GOODS_INFO  SET TYPE=TYPE";
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetGoodsName) && oCtrl.Append(ref sql, ",GOODS_NAME=" + SQL(mGoods.GoodsName)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetUnit) && oCtrl.Append(ref sql, ",GOODS_UNIT=" + SQL(mGoods.GoodsUnit)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetUnitPrice) && oCtrl.Append(ref sql, ",PRICE=" + SQL(mGoods.Price)));
            oCtrl.Helper(oCtrl.Exsit(MCtrl.SetGoodsStaus) && oCtrl.Append(ref sql, ",STATUS=" + SQL(mGoods.Status)));
            sql += " WHERE GOODS_ID=" + mGoods.GoodsId;
            return ExcuteNonQuery(sql);
        }

        public int InsertGoods(BasGoodsModel mGoods)
        {
            BAS_GOODS_INFO bgi = new BAS_GOODS_INFO
            {
                GOODS_NAME = mGoods.GoodsName,
                GOODS_UNIT = mGoods.GoodsUnit,
                PRICE = mGoods.Price,
                STATUS = mGoods.Status,
                TYPE = 'G'
            };
            dc.BAS_GOODS_INFO.InsertOnSubmit(bgi);
            dc.SubmitChanges();
            return bgi.GOODS_ID;
        }

        public int DeleteGoods(BasGoodsModel mGoods)
        {
            string sql = "DELETE FROM BAS_GOODS_INFO  WHERE GOODS_ID= " + mGoods.GoodsId;
            return ExcuteNonQuery(sql);
        }
    }
}
