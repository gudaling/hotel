using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 房间信息
    /// </summary>
    public class BasRoomModel
    {
        public BasRoomModel(int id)
            :this()
        {
            RoomId = id;
        }
        public BasRoomModel()
        {
        }
        private int nRoomId = -1;
        public int RoomId
        {
            get { return nRoomId; }
            set { nRoomId = value; }
        }
        private int nMainRoomId = -1;
        public int MainRoomId
        {
            get { return nMainRoomId; }
            set { nMainRoomId = value; }
        }
        public string RoomNo { get; set; }
        public string RoomIdGroup { get; set; }
        public char RoomType { get; set; }
        public string RoomTypeDesc { get; set; }
        public string RoomNotice { get; set; }
        /// <summary>
        /// 房间定价,如为空则以该房间类型定价为准
        /// </summary>
        public double RoomRate { get; set; }
        public char Status { get; set; }
        public string StatusGroup { get; set; }
        public string RoomPhone { get; set; }
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
        private BasFloorModel mFloor = new BasFloorModel();
        public BasFloorModel FloorInfo
        {
            get { return mFloor; }
            set { mFloor = value; }
        }
    }
    ///// <summary>
    ///// 宾馆房间价格.按房间类型定价
    ///// </summary>
    //public class BasHotelRates
    //{
    //    public string RoomType { get; set; }
    //    public double RoomRate { get; set; }
    //}
}
