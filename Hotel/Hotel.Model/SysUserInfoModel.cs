using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SysUserInfoModel
    {
        public SysUserInfoModel()
        {
            UserId = -1;
        }
        public SysUserInfoModel(int nUserId)
            : this()
        {
            UserId = nUserId;
        }
        public int UserId { get; set; }
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
        public string NewPsw { get; set; }
        public char Status { get; set; }
        public DateTime LoginDate { get; set; }
        public string LoginIp { get; set; }
        private int nSkinId = 0;
        public int SkinId {
            get { return nSkinId; }
            set { nSkinId = value; }
        }
        private CommonModel mComm = new CommonModel();
        public CommonModel CommonInfo
        {
            get { return mComm; }
            set { mComm = value; }
        }
        private SysRoleModel mRole = new SysRoleModel();
        public SysRoleModel RoleInfo
        {
            get { return mRole; }
            set { mRole = value; }
        }
        public DateTime SysDate
        {
            get { return DateTime.Now; }
        }
    }
}
