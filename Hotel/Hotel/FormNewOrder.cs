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
using System.Threading;

namespace Hotel
{
    public partial class FormNewOrder : BaseForm
    {
        private BasRoomModel mRoomInfo = new BasRoomModel();
        private BasRoomInfo bRoom = new BasRoomInfo();
        private OrdersInfo bOrder = new OrdersInfo();
        /// <summary>
        /// 本次新增或者修改的订单
        /// </summary>
        private List<OrderInfoModel> listOrderRoomInfo = new List<OrderInfoModel>();
        /// <summary>
        /// 预定中的订单
        /// </summary>
        private List<OrderInfoModel> listOrder = new List<OrderInfoModel>();
        private List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
        private HotelMainLogic hml = new HotelMainLogic();
        private OrderInfoModel mOrderInfo = new OrderInfoModel();
        public FormNewOrder()
        {
            InitializeComponent();
        }

        public FormNewOrder(BasRoomModel mRoom)
        {
            InitializeComponent();
            mRoomInfo = mRoom;
        }

        public FormNewOrder(OrderInfoModel mOrder)
        {
            InitializeComponent();
            mOrderInfo = mOrder;
            listOrderRoomInfo.Add(mOrderInfo);
        }

        private void FormNewOrder_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void LoadUIInfo()
        {
            try
            {
                dtpStartDate.Format = DateTimePickerFormat.Custom;
                dtpEndDate.Format = DateTimePickerFormat.Custom;
                dtpKeepDate.Format = DateTimePickerFormat.Custom;

                dtpStartDate.CustomFormat = "yyyy-MM-dd";
                dtpEndDate.CustomFormat = "yyyy-MM-dd";
                dtpKeepDate.CustomFormat = "yyyy-MM-dd";

                dtpEndDate.Value = cmn.DateBaseDate.AddDays(1);
                dtpKeepDate.Value = dtpEndDate.Value;
                BindCodeInfo(cboRoomType, "BAS_ROOM_INFO", "ROOM_TYPE");
                BasRoomModel mRoomTmp = mOrderInfo.OrderId > 0 ? mOrderInfo.RoomInfo : mRoomInfo;
                cboRoomType.SelectedIndex = GetComboxIndexByKey(cboRoomType, mRoomTmp.RoomType);
                string sRoomNo = mRoomTmp.RoomId > 0 ? mRoomTmp.RoomNo : "";
                gbOrdered.Text = string.Format("已预定{0}的宾客", sRoomNo);

                BindRoomInfo();
                BindHour();
                if (mRoomTmp.RoomId > 0)
                {
                    for (int i = 0; i < cboRoomNo.Items.Count; i++)
                    {
                        if (((BasRoomModel)cboRoomNo.Items[i]).RoomId == mRoomTmp.RoomId)
                        {
                            cboRoomNo.SelectedIndex = i;
                            break;
                        }
                    }
                }
                if (mOrderInfo.OrderId > 0)
                {
                    txtName.Text = mOrderInfo.Name;
                    txtPhone.Text = mOrderInfo.Phone;
                    txtIDCard.Text = mOrderInfo.IdCardNo;
                    txtRoomRate.Text = mOrderInfo.OrderRoomRate.ToString();
                    txtNotice.Text = mOrderInfo.Notice;

                    dtpStartDate.Value = mOrderInfo.CommonInfo.StartDate.Date;
                    cboHourS.SelectedItem = mOrderInfo.CommonInfo.StartDate.Hour;

                    dtpEndDate.Value = mOrderInfo.CommonInfo.EndDate.Date;
                    cboHourE.SelectedItem = mOrderInfo.CommonInfo.EndDate.Hour;

                    dtpKeepDate.Value = mOrderInfo.KeepDate.Date;
                    cboHourK.SelectedItem = mOrderInfo.KeepDate.Hour;
                    pbtnAdd.Enabled = false;
                }

            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void BindRoomInfo()
        {
            BasRoomModel mRoom = new BasRoomModel();
            mRoom.RoomType = cmn.ToChar(cboRoomType.SelectedValue);
           // mRoom.StatusGroup = "'E','C','I','T'";
            oCtrl.Reset();
            oCtrl.Add(MCtrl.ByRoomType);
            //oCtrl.Add(MCtrl.ByRoomStatusGroup);
            listRoomInfo = bRoom.GetRoomInfo(mRoom, oCtrl);
            cboRoomNo.DataSource = listRoomInfo;
            cboRoomNo.DisplayMember = "RoomNo";
            cboRoomNo.ValueMember = "RoomId";
        }

        private void BindHour()
        {
            for (int i = 0; i < 24; i++)
            {
                cboHourS.Items.Add(i);
                cboHourE.Items.Add(i);
                cboHourK.Items.Add(i);
            }
            cboHourS.SelectedIndex = 12;
            cboHourE.SelectedIndex = 12;
        }

        /// <summary>
        /// 绑定本次预定的订单信息
        /// </summary>
        /// <param name="mOrder"></param>
        private void BindGridViewRoomInfo(OrderInfoModel mOrder)
        {
            dgvRoomNo.Rows.Add();
            dgvRoomNo.Rows[dgvRoomNo.Rows.Count - 1].Cells["RoomType"].Value = mOrder.RoomInfo.RoomTypeDesc;
            dgvRoomNo.Rows[dgvRoomNo.Rows.Count - 1].Cells["RoomNo"].Value = mOrder.RoomInfo.RoomNo;
            listOrderRoomInfo.Add(mOrder);
            listOrder.Add(mOrder);
        }

        /// <summary>
        /// 绑定房间已经预定的订单信息
        /// </summary>
        /// <param name="listSource"></param>
        private void BindOrderedRoomInfo(List<OrderInfoModel>listSource)
        {
            dgvOrdered.Rows.Clear();
            if (cmn.CheckEOF(listSource))
            {
                int i = 0;
                foreach (OrderInfoModel mO in listSource)
                {
                    dgvOrdered.Rows.Add();
                    dgvOrdered.Rows[i].Cells["CustomerName"].Value = mO.Name;
                    dgvOrdered.Rows[i].Cells["StartDate"].Value = mO.CommonInfo.StartDate;
                    dgvOrdered.Rows[i].Cells["Phone"].Value = mO.Phone;
                    i++;
                }
            }
        }

        private OrderInfoModel CheckOrder(OrderInfoModel mOrder)
        {
            lblMsg.Text = "";
            if (!cmn.CheckEOF(listRoomInfo))
            {
                throw new Exception("无可预定房间");
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                throw new Exception("宾客姓名不能为空");
            }
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                throw new Exception("联系电话不能为空");
            }
            if (string.IsNullOrEmpty(txtRoomRate.Text.Trim()))
            {
                throw new Exception("房间价格不能为空");
            }
            DateTime dtKeepDate = GetDateTimePickValue(dtpKeepDate, cboHourK);
            DateTime dtStartDate = GetDateTimePickValue(dtpStartDate, cboHourS);
            DateTime dtEndDate = GetDateTimePickValue(dtpEndDate, cboHourE);

            if (dtEndDate <= dtStartDate)
            {
                throw new Exception("预抵时间不能小于预离时间");
            }
            if (dtKeepDate <= cmn.DateBaseDate)
            {
                throw new Exception("保留时间不能小于当前时间");
            }
            var query = listRoomInfo.Where(c => c.RoomId == int.Parse(cboRoomNo.SelectedValue.ToString()));

            if (query.Count() > 0)
            {
                if (mOrder.OrderId < 0)
                {
                    if (!hml.CheckRoomOrdered(listOrder, query.First(), dtStartDate, dtEndDate))
                    {
                        return null;
                    }
                }
                mOrder.Name = txtName.Text;
                mOrder.IdCardNo = txtIDCard.Text;
                mOrder.Phone = txtPhone.Text;
                mOrder.Notice = txtNotice.Text;
                mOrder.RoomInfo = query.First();
                mOrder.OrderRoomRate = cmn.CheckIsDouble(txtRoomRate, "房间费用");
                mOrder.CommonInfo = new CommonModel();
                mOrder.CommonInfo.CreateUserId = UserInfo.UserId;
                mOrder.CommonInfo.UpdateUserId = UserInfo.UserId;
                mOrder.CommonInfo.StartDate = dtStartDate;
                mOrder.CommonInfo.EndDate = dtEndDate;
                mOrder.KeepDate = dtKeepDate;
                mOrder.Status = 'E';
            }
            return mOrder;
        }

        private void txtRoomRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtRoomRate, e, "0123456789",5);
        }

        private void txtIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtIDCard, e, "0123456789Xx",18);
        }

        private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRoomInfo();
        }

        private void cboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var query = listRoomInfo.Where(c => c.RoomId == int.Parse(cboRoomNo.SelectedValue.ToString())).First();
            listOrder = hml.GetRoomOrder(query);
            BindOrderedRoomInfo(listOrder);
            txtRoomRate.Text = query.RoomRate.ToString();
            string sRoomNo = query.RoomId > 0 ? query.RoomNo : "";
            gbOrdered.Text = string.Format("已预定{0}的宾客", sRoomNo);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Value = dtpStartDate.Value.AddDays(1);
            DateTime dtStartDate = GetDateTimePickValue(dtpStartDate, cboHourS);
            dtpKeepDate.Value =dtStartDate.AddHours(6).Date;
            cboHourK.SelectedItem=dtStartDate.AddHours(6).Hour;
        }

        private void cboHourS_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dtStartDate = GetDateTimePickValue(dtpStartDate, cboHourS);
            dtpEndDate.Value = dtStartDate.AddDays(1);
            dtpKeepDate.Value = dtStartDate.AddHours(6).Date;
            cboHourK.SelectedItem = dtStartDate.AddHours(6).Hour;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtPhone, e, "0123456789-()*#",20);
        }

        private void pbtnAdd_MouseLeave(object sender, EventArgs e)
        {
            pbtnAdd.Location = new Point(pbtnAdd.Location.X-3, pbtnAdd.Location.Y);
        }

        private void pbtnAdd_MouseEnter(object sender, EventArgs e)
        {
            pbtnAdd.Location = new Point(pbtnAdd.Location.X + 3, pbtnAdd.Location.Y);
        }

        private void pbtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OrderInfoModel mOrder = new OrderInfoModel();
                mOrder = CheckOrder(mOrder);
                if (mOrder != null)
                {
                    BindGridViewRoomInfo(mOrder);
                }
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmn.CheckEOF(listOrderRoomInfo))
                {
                    if (mOrderInfo.OrderId < 0)
                    {
                        foreach (OrderInfoModel mOrder in listOrderRoomInfo)
                        {
                            bOrder.InsertOrderInfo(mOrder);
                            if (mOrder.RoomInfo.Status != 'I' && mOrder.RoomInfo.Status != 'T')
                            {
                                mOrder.RoomInfo.Status = 'O';
                                hml.UpdateRoomStatusByRoomId(mOrder.RoomInfo,UserInfo);
                            }
                        }
                    }
                    else
                    {
                        mOrderInfo = CheckOrder(mOrderInfo);
                        oCtrl.Reset();
                        oCtrl.Add(MCtrl.SetName);
                        oCtrl.Add(MCtrl.SetPhone);
                        oCtrl.Add(MCtrl.SetIdCard);
                        oCtrl.Add(MCtrl.SetStartDate);
                        oCtrl.Add(MCtrl.SetEndDate);
                        oCtrl.Add(MCtrl.SetKeepDate);
                        oCtrl.Add(MCtrl.SetRoomId);
                        oCtrl.Add(MCtrl.SetRoomRate);
                        oCtrl.Add(MCtrl.SetNotice);
                        oCtrl.Add(MCtrl.SetOrderStatus);
                        bOrder.UpdateOrderInfo(mOrderInfo, oCtrl);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
