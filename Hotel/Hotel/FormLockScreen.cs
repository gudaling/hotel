using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.BLL;
using Hotel.Model;
using Hotel.Common;

namespace Hotel
{
    public partial class FormLockScreen : BaseForm
    {
        private SysUserInfo bUser = new SysUserInfo();
        public FormLockScreen()
        {
            InitializeComponent();
            pnlBorder.Size = this.Size;
            pnlBorder.Location = this.Location;
        }

        private void btnUnLock_Click(object sender, EventArgs e)
        {
            try
            {
                SysUserInfoModel mUser = new SysUserInfoModel();
                mUser.UserId = UserInfo.UserId;
                mUser.UserPassWord = txtPsw.Text;
                if (bUser.CheckUserInfo(mUser))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    throw new Exception("密码错误!");
                }
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        private void FormLockScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

    }
}
