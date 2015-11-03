using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Hotel.Model;
using Hotel.DAL;
using Hotel.Common;

namespace Hotel.BLL
{
    public class SysUserInfo : AbBaseBll
    {
        public SysUserInfo()
        {
        }

        /// <summary>
        /// 获取用户验证信息
        /// </summary>
        /// <param name="mUserInfo"></param>
        /// <returns></returns>
        public SysUserInfoModel GetUserInfo(SysUserInfoModel mUserInfo)
        {
            var query = from c in dc.SYS_USER_INFO where (c.USER_NO == mUserInfo.UserNo && c.PASSWORD == mUserInfo.UserPassWord) || (c.USER_ID == mUserInfo.UserId && c.PASSWORD == mUserInfo.UserPassWord) join d in dc.SYS_ROLE_INFO on c.ROLE_ID equals d.ROLE_ID select new { user = c, roleName = d.ROLE_NAME };
            Log.WriteLog(dc, query, AbBaseBll.IsWriteSql);
            SysUserInfoModel mUserInfoNew = new SysUserInfoModel();
            if (query.Count() > 0)
            {
                mUserInfoNew.UserId = query.First().user.USER_ID;
                mUserInfoNew.UserName = query.First().user.USER_NAME;
                mUserInfoNew.UserNo = query.First().user.USER_NO;
                mUserInfoNew.Status = query.First().user.STATUS;
                mUserInfoNew.SkinId = query.First().user.SKIN_ID == null ? 0 : int.Parse(query.First().user.SKIN_ID.ToString());
                mUserInfoNew.RoleInfo = new SysRoleModel();
                mUserInfoNew.RoleInfo.RoleId = query.First().user.ROLE_ID;
                mUserInfoNew.RoleInfo.RoleName = query.First().roleName;
                return mUserInfoNew;
            }
            return null;
        }

        /// <summary>
        /// 获取系统用户列表
        /// </summary>
        /// <returns></returns>
        public List<SysUserInfoModel> GetUserInfoList()
        {
            var query = from c in dc.SYS_USER_INFO join d in dc.SYS_ROLE_INFO on c.ROLE_ID equals d.ROLE_ID select new { user = c, roleName = d.ROLE_NAME,roleId=d.ROLE_ID };
            Log.WriteLog(dc, query, AbBaseBll.IsWriteSql);
            List<SysUserInfoModel> listUserInfo = new List<SysUserInfoModel>();
            foreach (var value in query)
            {
                SysUserInfoModel mUserInfoNew = new SysUserInfoModel();
                mUserInfoNew.UserId = value.user.USER_ID;
                mUserInfoNew.UserName = value.user.USER_NAME;
                mUserInfoNew.UserNo = value.user.USER_NO;
                mUserInfoNew.UserPassWord = MyMD5.MD5Decrypt(value.user.PASSWORD, "INDEXSFT");
                mUserInfoNew.SkinId = value.user.SKIN_ID == null ? 0 : int.Parse(value.user.SKIN_ID.ToString());
                mUserInfoNew.RoleInfo = new SysRoleModel();
                mUserInfoNew.RoleInfo.RoleId = value.roleId;
                mUserInfoNew.RoleInfo.RoleName = value.roleName;

                listUserInfo.Add(mUserInfoNew);
            }
            return listUserInfo;
        }
        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="mUserInfo"></param>
        /// <returns></returns>
        public bool CheckUserInfo(SysUserInfoModel mUserInfo)
        {
            mUserInfo.UserPassWord = MyMD5.MD5Encrypt(mUserInfo.UserPassWord, "INDEXSFT");
            mUserInfo = GetUserInfo(mUserInfo);
            if (mUserInfo != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="mUser"></param>
        /// <param name="oCtrl"></param>
        /// <returns></returns>
        public int UpdateUserInfo(SysUserInfoModel mUser, ObjectControls oCtrl)
        {
            SYS_USER_INFO sui = new SYS_USER_INFO();
            var query = dc.SYS_USER_INFO.Where(c => c.USER_ID == mUser.UserId);
            if (query.Count() > 0)
            {
                sui = query.First();
                if (oCtrl.Exsit(MCtrl.SetPsw))
                {
                    sui.PASSWORD = mUser.NewPsw;
                }
                if (oCtrl.Exsit(MCtrl.SetUserName))
                {
                    sui.USER_NAME = mUser.UserName;
                }
                if (oCtrl.Exsit(MCtrl.SetUserNo))
                {
                    sui.USER_NO = mUser.UserNo;
                }
                if (oCtrl.Exsit(MCtrl.SetRoleId))
                {
                    sui.ROLE_ID = mUser.RoleInfo.RoleId;
                }
                if (oCtrl.Exsit(MCtrl.SetSkinId))
                {
                    sui.SKIN_ID = mUser.SkinId;
                }
                sui.UPDATE_DATE = cmn.DateBaseDate;
                sui.UPDATE_USERID = mUser.UserId;
                dc.SubmitChanges();
                return sui.USER_ID;
            }
            return -1;
        }

        public int InsertUserInfo(SysUserInfoModel mUser)
        {
            SYS_USER_INFO sui = new SYS_USER_INFO
            {
                USER_NO = mUser.UserNo,
                STATUS = 'E',
                CREATE_DATE = cmn.DateBaseDate,
                CREATE_USERID = mUser.CommonInfo.CreateUserId,
                UPDATE_DATE = cmn.DateBaseDate,
                ROLE_ID = mUser.RoleInfo.RoleId,
                PASSWORD = mUser.UserPassWord,
                USER_NAME = mUser.UserName,
                SKIN_ID=mUser.SkinId,
                UPDATE_USERID = mUser.CommonInfo.CreateUserId
            };
            dc.SYS_USER_INFO.InsertOnSubmit(sui);
            dc.SubmitChanges();
            return sui.USER_ID;
        }

        public void DeleteUserInfo(SysUserInfoModel mUser)
        {
            dc.SYS_USER_INFO.DeleteAllOnSubmit(dc.SYS_USER_INFO.Where(c => c.USER_ID == mUser.UserId));
            dc.SubmitChanges();
        }

        public List<SysRoleModel> GetRoleList()
        {
            var query = dc.SYS_ROLE_INFO;
            List<SysRoleModel> listRole = new List<SysRoleModel>();
            foreach (SYS_ROLE_INFO sui in query)
            {
                SysRoleModel mRole = new SysRoleModel();
                mRole.RoleId = sui.ROLE_ID;
                mRole.RoleName = sui.ROLE_NAME;
                listRole.Add(mRole);
            }
            return listRole;
        }
    }
}
