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
    public partial class FormChangeRoom : BaseForm
    {
        private BasRoomModel mRoomInfo = new BasRoomModel();
        private BasRoomInfo bRoom = new BasRoomInfo();
        private List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
        private HotelMainLogic hml = new HotelMainLogic();
        private CustomerStayModel mCustomerStay = new CustomerStayModel();
        public FormChangeRoom()
        {
            InitializeComponent();
        }

        public FormChangeRoom(BasRoomModel mRoomInfo)
        {
            InitializeComponent();
            this.mRoomInfo = mRoomInfo;
        }

        private void LoadUIInfo()
        {
            try
            {
                mCustomerStay = hml.GetStayInRoomInfo(mRoomInfo, 'I',"M");
                if (mCustomerStay != null)
                {
                    if (mCustomerStay.CommonInfo.EndDate.Date <= cmn.DateBaseDate.Date)
                    {
                        throw new Exception("已到达退房日期,请先续住后再换房");
                    }
                    lblRoomNo.Text = mRoomInfo.RoomNo;
                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.ByRoomStatus);
                    BasRoomModel mRoom = new BasRoomModel();
                    mRoom.Status = 'E';
                    listRoomInfo = bRoom.GetRoomInfo(mRoom, oCtrl);
                    if (cmn.CheckEOF(listRoomInfo))
                    {
                        cboNewRoom.DataSource = listRoomInfo;
                        cboNewRoom.DisplayMember = "RoomNo";
                        cboNewRoom.ValueMember = "RoomId";
                        txtRoomRate.Text = listRoomInfo[0].RoomRate.ToString();
                    }
                }
                else
                {
                    throw new Exception("该房间无入住信息,无法换房");
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboNewRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nRoomId = 0;
            if (int.TryParse(cboNewRoom.SelectedValue.ToString(), out nRoomId))
            {
                var query = listRoomInfo.Where(c => c.RoomId == nRoomId);
                if (query.Count() > 0)
                {
                    txtRoomRate.Text = query.First().RoomRate.ToString();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNewRoom.SelectedValue != null)
                {
                    List<BasRoomModel> listNewRoomInfo = listRoomInfo.Where(c => c.RoomId == int.Parse(cboNewRoom.SelectedValue.ToString())).ToList(); ;//bRoom.GetRoomInfo(new BasRoomModel (int.Parse(cboNewRoom.SelectedValue.ToString())),new ObjectControls (MCtrl.ByRoomId));
                    if (cmn.CheckEOF(listNewRoomInfo))
                    {
                        double dNewRoomRate = txtRoomRate.Text.Trim().Equals("") ? listNewRoomInfo[0].RoomRate : cmn.CheckIsDouble(txtRoomRate, "房间费用");
                        hml.ChangeRoom(mCustomerStay, listNewRoomInfo[0], dNewRoomRate, UserInfo, listSysParameter);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    throw new Exception("无可用房间可换.");
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void FormChangeRoom_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }
    }
}