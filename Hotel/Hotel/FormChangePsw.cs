using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Common;
using Hotel.Model;
using Hotel.BLL;

namespace Hotel
{
    public partial class FormChangePsw : BaseForm
    {
        private SysUserInfo bUser = new SysUserInfo();
        public FormChangePsw()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserInfo.UserId > 0)
                {
                    if (string.IsNullOrEmpty(txtOldPsw.Text) || string.IsNullOrEmpty(txtNewPsw.Text) || string.IsNullOrEmpty(txtCfmPsw.Text))
                    {
                        throw new Exception("信息不完整");
                    }
                    if (txtNewPsw.Text != txtCfmPsw.Text)
                    {
                        throw new Exception("密码不一致");
                    }
                    SysUserInfoModel mUser = new SysUserInfoModel();
                    mUser.UserId = UserInfo.UserId;
                    mUser.UserNo = UserInfo.UserNo;
                    mUser.UserPassWord = txtOldPsw.Text;

                    if (bUser.CheckUserInfo(mUser))
                    {
                        if (!cmn.Confirm("确定修改密码?你的新密码为" + txtNewPsw.Text))
                        {
                            return;
                        }
                        mUser.NewPsw = MyMD5.MD5Encrypt(txtNewPsw.Text, "INDEXSFT");
                        if (bUser.UpdateUserInfo(mUser, new ObjectControls(MCtrl.SetPsw)) > 0)
                        {
                            cmn.Show("密码修改成功.");
                        }
                        else
                        {
                            cmn.Show("发生未知错误,密码修改失败.");
                        }
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("密码不正确");
                    }
                }
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

    }
}
