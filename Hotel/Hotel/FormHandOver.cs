using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.BLL;
using Hotel.Common;
using Hotel.Model;

namespace Hotel
{
    public partial class FormHandOver : BaseForm
    {
        private HotelMainLogic hml = new HotelMainLogic();
        private SysUserInfo bUser = new SysUserInfo();
        private HandOverModel mHandOver = new HandOverModel();
        private HandOverInfo bHandOver = new HandOverInfo();
        private List<SysUserInfoModel> listUser = new List<SysUserInfoModel>();

        public FormHandOver()
        {
            InitializeComponent();
        }

        private void FormHandOver_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void LoadUIInfo()
        {
            try
            {
                BindUser();
                mHandOver = hml.GetHandOverInfo();
                lblFromLastMoney.Text = mHandOver.FromLastMoney.ToString();
                lblDeposit.Text = mHandOver.CurrentDeposit.ToString();
                lblPaid.Text = mHandOver.CurrentPaidMoney.ToString();
                lblHandOver.Text = mHandOver.HandOverMoney.ToString();
                txtHandIn.Text = "0.0";
                lblToNext.Text = mHandOver.ToNextMoney.ToString();
                lblCurrentUser.Text = UserInfo.UserName;
                lblDate.Text = mHandOver.CommonInfo.StartDate.ToString("yyyy-MM-dd HH:mm") + "~" + mHandOver.CommonInfo.EndDate.ToString("yyyy-MM-dd HH:mm");
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        /// <summary>
        /// 绑定系统用户
        /// </summary>
        private void BindUser()
        {
            listUser=bUser.GetUserInfoList();
            cboUser.DataSource =listUser;
            cboUser.DisplayMember = "UserName";
            cboUser.ValueMember = "UserId";
        }

        private void txtHandIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtHandIn, e, "1234567890.", 7);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cmn.Confirm("确定交班?"))
                {
                    return;
                }
                SysUserInfoModel mUser=new SysUserInfoModel ();
                mUser.UserId=int.Parse(cboUser.SelectedValue.ToString());
                mUser.UserPassWord=txtPsw.Text;
                if (bUser.CheckUserInfo(mUser))
                {
                    mHandOver.CurrentUserInfo.UserId = UserInfo.UserId;
                    mHandOver.NextUserInfo.UserId = int.Parse(cboUser.SelectedValue.ToString());
                    mHandOver.HandInMoney = double.Parse(cmn.CheckIsDouble(txtHandIn, "上交金额").ToString("0.00"));
                    mHandOver.ToNextMoney = double.Parse(lblToNext.Text);
                    mHandOver.CommonInfo.CreateUserId = UserInfo.UserId;
                    if (bHandOver.InsertHandOver(mHandOver) > 0)
                    {
                        UserInfo = bUser.GetUserInfo(mUser);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    throw new Exception("密码验证错误!");
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void txtHandIn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtHandIn.Text != "")
                {
                    double dToNext = mHandOver.HandOverMoney - cmn.CheckIsDouble(txtHandIn, "上交金额");
                    if (dToNext < 0)
                    {
                        txtHandIn.Text = "0.0";
                        throw new Exception("上缴金额不能大于本班合计金额");
                    }
                    lblToNext.Text = dToNext.ToString();
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
