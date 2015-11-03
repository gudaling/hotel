using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Common;
using Hotel.Model;
using Hotel.DAL;

namespace Hotel.BLL
{
    public class BasFloorInfo:AbBaseBll
    {
        /// <summary>
        /// 获取楼层信息
        /// </summary>
        /// <returns></returns>
        public List<BasFloorModel> GetFloorInfo()
        {
            var query = dc.BAS_FLOOR_INFO.Where(c => c.STATUS == 'E');
            List<BasFloorModel> listFloorInfo = new List<BasFloorModel>();
            foreach (BAS_FLOOR_INFO bfi in query)
            {
                BasFloorModel mFloor = new BasFloorModel();
                mFloor.FloorId = bfi.FLOOR_ID;
                mFloor.FloorName = bfi.FLOOR_NAME;
                mFloor.Status = bfi.STATUS;
                mFloor.CommonInfo = new CommonModel();
                mFloor.CommonInfo.CreateDate = bfi.CREATE_DATE;
                mFloor.CommonInfo.CreateUserId = bfi.CREATE_USERID;
                listFloorInfo.Add(mFloor);
            }
            return listFloorInfo;
        }
    }
}
