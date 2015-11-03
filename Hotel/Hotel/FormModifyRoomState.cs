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
    public partial class FormModifyRoomState : BaseForm
    {
        private BasRoomModel mRoomInfo = new BasRoomModel();
        private CustomerStayModel mCustomerStay = new CustomerStayModel();
        private CustomerStayInfo bCustomerStay = new CustomerStayInfo();
        private BasRoomInfo bRoom = new BasRoomInfo();
        private HotelMainLogic hml = new HotelMainLogic();
        public FormModifyRoomState()
        {
            InitializeComponent();
        }

        public FormModifyRoomState(BasRoomModel mRoomInfo)
        {
            InitializeComponent();
            this.mRoomInfo = mRoomInfo;
        }

        private void LoadUIInfo()
        {
            lblRoomNo.Text = mRoomInfo.RoomNo;
            lblRoomStatus.Text = hml.ToLookupCodeDesc("BAS_ROOM_INFO", "STATUS", mRoomInfo.Status.ToString());
            mCustomerStay = hml.GetStayInRoomInfo(mRoomInfo, 'I', "M");
            txtNotice.Text = mRoomInfo.RoomNotice;
            //if (mCustomerStay != null)
            //{
            //    lblDeposit.Text = mCustomerStay.Deposit.ToString();
            //    lblTotal.Text = hml.GetTotalRates(mCustomerStay, mCustomerStay.ConSumeDetailList, listSysParameter).ToString();
            //}
        }

        private void FormModifyRoomState_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        /// <summary>
        /// 修改房态只能对处于非占用状态的房间进行状态修改
        /// </summary>
        /// <param name="cRoomStatus"></param>
        private void UpdateRoomStatus(char cRoomStatus)
        {
            try
            {
                if (mCustomerStay != null)
                {
                    if (mCustomerStay.RoomInfo.Status == cRoomStatus)
                    {
                        throw new Exception("房间状态未变!");
                    }

                    if (cRoomStatus == 'I' || cRoomStatus == 'T')
                    {
                        #region 已入住房间可以变更为散客房或者团体房

                        string sRoomType = cRoomStatus == 'I' ? "散客房间" : "团队房间";

                        if (!cmn.Confirm(string.Format("确定要将房间{0}变更为{1}?", mRoomInfo.RoomNo, sRoomType)))
                        {
                            return;
                        }

                        #region 变为散客房

                        if (cRoomStatus == 'I')
                        {
                            if (mCustomerStay.MainRoomId == mCustomerStay.RoomId)
                            {
                                if (!hml.UpdateCustomerStayMainRoomId(mCustomerStay))
                                {
                                    return;
                                }
                            }
                            else
                            {
                                mCustomerStay.MainRoomId = -1;
                                bCustomerStay.UpdateCustomerStay(mCustomerStay, new ObjectControls(MCtrl.SetMainRoomId));
                            }
                        }

                        #endregion

                        #region 变为团体房

                        else if (cRoomStatus == 'T')
                        {
                            List<CustomerStayModel> listCustomerStay =bCustomerStay.GetMainRoomGroup();

                            if (!cmn.CheckEOF(listCustomerStay))
                            {
                                throw new Exception("无团队房间,无法将散客房间变更为团队房间!");
                            }

                            FormTeamRoomSelector frmTeam = new FormTeamRoomSelector(listCustomerStay);
                            if (frmTeam.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                            hml.UpdateSingleRoomToTeamRoom(mCustomerStay, frmTeam.MainRoomId, frmTeam.CustomerId, UserInfo);
                        }

                        #endregion

                        #endregion
                    }
                    else
                    {
                        throw new Exception("已入住房间不能变更为可用,清理,预定或不可用状态");
                    }
                }
                mRoomInfo.Status = cRoomStatus;
                mRoomInfo.RoomNotice = txtNotice.Text;
                mRoomInfo.CommonInfo.UpdateUserId = UserInfo.UserId;
                oCtrl.Reset();
                oCtrl.Add(MCtrl.SetNotice);
                oCtrl.Add(MCtrl.SetRoomStatus);
                bRoom.UpdateRoomInfo(mRoomInfo, oCtrl);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void pbtnEnable_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus('E');
        }

        private void pbtnInRoom_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus('I');
        }

        private void pbtnClean_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus('C');
        }

        private void pbtnOrder_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus('O');
        }

        private void pbtnDisable_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus('D');
        }

        protected void pbMouseEnter(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(35, 35);
        }

        protected void pbMouseLeave(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(32, 32);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UpdateRoomStatus('T');
        }
    }
}
