using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hotel.Common;
using Hotel.DAL;
using Hotel.Model;

namespace Hotel.BLL
{
    public class HandOverInfo:AbBaseBll
    {
        private HandOverDao dHandOver = new HandOverDao();

        /// <summary>
        /// 获取交接班信息
        /// </summary>
        /// <param name="mHandOver"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public List<HandOverModel> GetHandOverList(HandOverModel mHandOver, ObjectControls oCtrl)
        {
            return dHandOver.GetHandOverList(mHandOver, oCtrl);
        }

        /// <summary>
        /// 获取最后一次交接记录
        /// </summary>
        /// <returns></returns>
        public int GetHandOverLatestId()
        {
            return dHandOver.GetHandOverLatestId();
        }
        public int InsertHandOver(HandOverModel mHandOver)
        {
            return dHandOver.InsertHandOver(mHandOver);
        }

        public int UpdateHandOver(HandOverModel mHandOver, ObjectControls oCtrl)
        {
            return dHandOver.UpdateHandOver(mHandOver, oCtrl);
        }

        public int DeleteHandOver(HandOverModel mHandOver)
        {
            return dHandOver.DeleteHandOver(mHandOver);
        }
    }
}
