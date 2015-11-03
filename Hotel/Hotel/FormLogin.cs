using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Model;
using Hotel.BLL;
using Hotel.Common;

namespace Hotel
{
    public partial class FormLogin : Form
    {
        private SysUserInfoModel mUserInfo = new SysUserInfoModel();
        private int oldX = 0;
        private int oldY = 0;
        public FormLogin()
        {
            InitializeComponent();
            pnlBorder.Size = this.Size;
            pnlBorder.Location = this.Location;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckFormInfo())
                {
                    lblMsg.Text = "登陆信息不完整";
                }
                else
                {
                    SysUserInfo bUser = new SysUserInfo();
                    mUserInfo=bUser.GetUserInfo(mUserInfo);
                    if (mUserInfo != null)
                    {
                        BaseForm.UserInfo = mUserInfo;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("密码验证失败");
                    }
                }
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        private bool CheckFormInfo()
        {
            if (string.IsNullOrEmpty(txtUserNo.Text.Trim()) || string.IsNullOrEmpty(txtPsw.Text))
            {
                return false;
            }
            else
            {
                mUserInfo = new SysUserInfoModel();
                mUserInfo.UserNo = txtUserNo.Text.Trim().ToUpper();
                mUserInfo.UserPassWord = txtPsw.Text.MD5Encrypt("INDEXSFT");
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.Location.X - this.oldX;        //新的鼠标位置
                this.Top += e.Location.Y - this.oldY;
            }
        }

        private void pnlBorder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.oldX = e.Location.X;        //鼠标原来位置
                this.oldY = e.Location.Y;
            }
        }
    }
}
