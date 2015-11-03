using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Model;
using Hotel.Common;
using Hotel.BLL;
using Indexsoft.NewIdCard;
using System.IO;

namespace Hotel
{
    public partial class FormOneCustomer :BaseForm
    {
        private BasRoomModel mRoomInfo = new BasRoomModel();

        private CustomerStayInfo bCustomer = new CustomerStayInfo();

        private List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();

        private List<CustomerModel> listCustomer = new List<CustomerModel>();

        private CustomerModel mCustomerInfo;

        private HotelMainLogic hml = new HotelMainLogic();

        private OrderInfoModel mOrderInfo;

        public FormOneCustomer(BasRoomModel mRoomInfo)
        {
            InitializeComponent();
            this.mRoomInfo = mRoomInfo;
        }

        public FormOneCustomer()
        {
            InitializeComponent();
        }

        private void LoadInfo()
        {
            BindCodeInfo(cboPayType, "CUSTOMER_STAY_INFO", "PAY_TYPE");
            BindCodeInfo(cboCustomerType, "CUSTOMER_STAY_HIS", "STAY_TYPE");
            cboSex.SelectedIndex = 0;
            lblRoomInfo.Text = mRoomInfo.RoomNo;
            lblRoomType.Text = mRoomInfo.RoomTypeDesc;
            lblRoomRate.Text = mRoomInfo.RoomRate + "元";
            if (!mRoomInfo.Status.Equals('E'))
            {
                CustomerStayModel mCustomerStayInfo = new CustomerStayModel();
                mCustomerStayInfo.RoomId = mRoomInfo.RoomId;
                mCustomerStayInfo.Status = 'I';
                mCustomerStayInfo.CustomerList = new List<CustomerModel>();
                CustomerModel mc = new CustomerModel();
                mc.CustomerStayHisInfo = new CustomerStayHisModel();
                mc.CustomerStayHisInfo.HisStatus = 'E';
                mCustomerStayInfo.CustomerList.Add(mc);
                oCtrl = new ObjectControls();
                oCtrl.Add(MCtrl.ByRoomId);
                oCtrl.Add(MCtrl.ByStayStatus);
                oCtrl.Add(MCtrl.ByHisStatus);
                CustomerStayModel mCustomerStay =bCustomer.GetCustomerStayInfo(mCustomerStayInfo, oCtrl);
                if (mCustomerStay != null)
                {
                    this.Text = "修改登记";
                    listCustomerStay.Add(mCustomerStay);
                    txtDay.Text = (mCustomerStay.Hours / 24).ToString(); //hml.GetCustomerStayDays(mCustomerStay.CommonInfo.StartDate, mCustomerStay.CommonInfo.EndDate, listSysParameter).ToString("0.0"); //listSysParameter.Where(c => c.ParamNo == "DEFAULT_STAY_DAYS").Select(c => c.Value1).First();
                    txtCurrentDeposit.Text = mCustomerStay.Deposit.ToString();
                    txtCurrentRate.Text = mCustomerStay.RoomRate.ToString();
                    txtDiskonRate.Enabled = false;
                    //txtDiskonRate.Text = (mCustomerStay.RoomRate / mCustomerStay.RoomInfo.RoomRate).ToString("0.00");
                    txtCustomerNumber.Text = mCustomerStay.CustomerList.Count.ToString();
                    txtNotice.Text = mCustomerStay.Notice;
                    chkHourRoom.Checked = mCustomerStay.RoomStayType == 'H' ? true : false;
                    cboPayType.SelectedIndex = GetComboxIndexByKey(cboPayType, mCustomerStay.PayType);

                    if (cmn.FileExsit(cmn.GetImgFilePath(mCustomerStay.CustomerList[0].Picture)))
                    {
                        pbxUserImg.Image = Image.FromFile(cmn.GetImgFilePath(mCustomerStay.CustomerList[0].Picture));
                    }
                    listCustomer = mCustomerStay.CustomerList;
                    BindCustomer(listCustomer);
                    return;
                }
            }
            this.Text = "散客开单";

            List<OrderInfoModel> listOrder = hml.GetRoomOrder(mRoomInfo);
            if (cmn.CheckEOF(listOrder))
            {
                FormSelectOrder frmSelectOrder = new FormSelectOrder(listOrder);
                if (frmSelectOrder.ShowDialog() == DialogResult.OK)
                {
                    mOrderInfo = frmSelectOrder.mOrderInfo;
                    if (mOrderInfo != null)
                    {
                        txtCustomerName.Text = mOrderInfo.Name;
                        txtPhone.Text = mOrderInfo.Phone;
                        txtIDCard.Text = mOrderInfo.IdCardNo;
                        txtCurrentRate.Text = mOrderInfo.OrderRoomRate.ToString();
                        txtNotice.Text = mOrderInfo.Notice;
                        btnAddCustomer_Click(null, new EventArgs());
                    }
                }
            }
            txtDay.Text = hml.ToParameter(listSysParameter, "DEFAULT_STAY_DAYS").Value1; //listSysParameter.Where(c => c.ParamNo == "DEFAULT_STAY_DAYS").Select(c => c.Value1).First();
            txtCurrentDeposit.Text = hml.ToParameter(listSysParameter, "DEFAULT_DEPOSIT").Value1;
            txtCurrentRate.Text = txtCurrentRate.Text.Equals("") ? mRoomInfo.RoomRate.ToString() : txtCurrentRate.Text;
            txtDiskonRate.Text = hml.ToParameter(listSysParameter, "DEFAULT_DISKON").Value1;
            txtCustomerNumber.Text = hml.ToParameter(listSysParameter, "DEFAULT_CUSTOMER_NUMBER").Value1;

        }

        private void ClearUI()
        {
            txtCustomerName.Text = string.Empty;
            txtIDCard.Text = string.Empty;
            txtPhone.Text = string.Empty;
            pbxUserImg.Image = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOneCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInfo();
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (mCustomerInfo == null)
                {
                    mCustomerInfo = new CustomerModel();
                }
                mCustomerInfo.Name = cmn.CheckNullOrEmpty(txtCustomerName, "宾客姓名");
                mCustomerInfo.Address = txtAddress.Text;
                mCustomerInfo.Company = txtCompany.Text;
                mCustomerInfo.IdCardNo = cmn.CheckNullOrEmpty(txtIDCard, "证件号码");
                mCustomerInfo.Phone = txtPhone.Text;
                mCustomerInfo.Sex = cboSex.SelectedItem.ToString();
                mCustomerInfo.CustomerStayHisInfo=new CustomerStayHisModel ();
                mCustomerInfo.CustomerStayHisInfo.HisStatus='E';
                if (pbxUserImg.Image != null)
                {
                    mCustomerInfo.Picture = cmn.SaveImage(pbxUserImg.Image, cmn.DateBaseDate.ToString("yyyyMMddHHmmss"), "CARD_IMG");
                }
                //第一个加入的宾客默认为主客.
                if (listCustomer.Count == 0)
                {
                    mCustomerInfo.CustomerStayHisInfo.StayType = 'M';
                }
                else
                {
                    mCustomerInfo.CustomerStayHisInfo.StayType = cmn.ToChar(cboCustomerType.SelectedValue);
                }
                mCustomerInfo.CommonInfo = new CommonModel();
                mCustomerInfo.CommonInfo.CreateUserId = UserInfo.UserId;
                mCustomerInfo.CommonInfo.UpdateUserId = UserInfo.UserId;
                var query=listCustomer.Where(c => c.IdCardNo == mCustomerInfo.IdCardNo && c.Name == mCustomerInfo.Name);
                if (query.Count() > 0)
                {
                    listCustomer.Remove(query.First());
                }
                query = listCustomer.Where(c => c.CustomerStayHisInfo.StayType == mCustomerInfo.CustomerStayHisInfo.StayType && c.CustomerStayHisInfo.StayType=='M');
                if (query.Count() > 0)
                {
                    if (cmn.Confirm(string.Format("已指定主客为{0}确实要将主客变更为{1}?", query.First().Name, mCustomerInfo.Name)))
                    {
                        query.First().CustomerStayHisInfo.StayType = 'S';
                    }
                    else { return; }
                }
                if (!listCustomer.Contains(mCustomerInfo))
                {
                    listCustomer.Add(mCustomerInfo);
                }
                BindCustomer(listCustomer);
                if (mCustomerInfo.CustomerStayHisInfo.StayType.Equals('M'))
                {
                    cboCustomerType.SelectedValue = "S";
                }
                mCustomerInfo = null;
                ClearUI();
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        private void BindCustomer(List<CustomerModel> listSource)
        {
            dgvCustomerInfo.Rows.Clear();
            List<CustomerModel> listTmp = new List<CustomerModel>();
            var query = listCustomer.Where(c => c.CustomerStayHisInfo.HisStatus == 'E');
            //dgvCustomerInfo.Rows.Add(query.Count());
            int i = 0;
            foreach (var q in query)
            {
                dgvCustomerInfo.Rows.Add();
                dgvCustomerInfo.Rows[i].Cells["Type"].Value = q.CustomerStayHisInfo.StayType.Equals('M') ? "主客" : "从客";
                dgvCustomerInfo.Rows[i].Cells["CustomerName"].Value = q.Name;
                dgvCustomerInfo.Rows[i].Cells["Sex"].Value = q.Sex;
                dgvCustomerInfo.Rows[i].Cells["IDCard"].Value = q.IdCardNo;
                dgvCustomerInfo.Rows[i].Cells["Phone"].Value = q.Phone;
                dgvCustomerInfo.Rows[i].Cells["Nation"].Value = q.Nation;
                dgvCustomerInfo.Rows[i].Cells["Birthday"].Value = q.Birthday.ToShortDateString();
                dgvCustomerInfo.Rows[i].Cells["Company"].Value = q.Company;
                dgvCustomerInfo.Rows[i].Cells["Address"].Value = q.Address;
                dgvCustomerInfo.Rows[i].Cells["CustomerId"].Value = q.CustomerId;
                i++;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                RoomLogicType eType;
                if (!cmn.CheckEOF(listCustomer))
                {
                    cmn.Show("请先添加宾客信息！");
                    return;
                }
                if (!cmn.Confirm("确定收取押金数为 " + txtCurrentDeposit.Text + "\r支付方式为 " + cboPayType.Text+"\r这将会影响最终的结账方式以及收费金额."))
                {
                    return;
                }
                if (cmn.CheckEOF(listCustomerStay))
                {
                    #region 修改宾客入住信息

                    listCustomerStay[0].Deposit = cmn.CheckIsDouble(txtCurrentDeposit, "押金数");
                    listCustomerStay[0].MainRoomId = listCustomerStay[0].MainRoomId;
                    listCustomerStay[0].Notice = txtNotice.Text;
                    listCustomerStay[0].PayType = cmn.ToChar(cboPayType.SelectedValue);
                    listCustomerStay[0].RoomId = mRoomInfo.RoomId;
                    listCustomerStay[0].RoomRate = cmn.CheckIsDouble(txtCurrentRate, "房价");
                    int nDays = chkHourRoom.Checked ? 1 : cmn.CheckIsInt(txtDay, "入住天数");
                    listCustomerStay[0].Hours = nDays * 24;
                    listCustomerStay[0].RoomStayType = chkHourRoom.Checked ? 'H' : 'D';
                    listCustomerStay[0].CommonInfo.EndDate = hml.GetEndDateByStayDays(listCustomerStay[0].CommonInfo.StartDate, nDays, listSysParameter);
                    listCustomerStay[0].CommonInfo.UpdateUserId = UserInfo.UserId;
                    eType = RoomLogicType.EditRoomInfo;

                    #endregion
                }
                else
                {
                    #region 散客开房

                    CustomerStayModel mCustomerStay = new CustomerStayModel();
                    mCustomerStay.Deposit = cmn.CheckIsDouble(txtCurrentDeposit, "押金数");
                    mCustomerStay.MainRoomId = -1;
                    mCustomerStay.PaidMoney = 0.0;
                    mCustomerStay.Notice = txtNotice.Text;
                    mCustomerStay.PayType = cmn.ToChar(cboPayType.SelectedValue);
                    mCustomerStay.RoomId = mRoomInfo.RoomId;
                    mCustomerStay.RoomRate = cmn.CheckIsDouble(txtCurrentRate, "房价");
                    mCustomerStay.Status = 'I';
                    mCustomerStay.RoomInfo = new BasRoomModel();
                    mCustomerStay.RoomInfo.Status = 'I';
                    mCustomerStay.CommonInfo = new CommonModel();
                    mCustomerStay.CommonInfo.StartDate = cmn.DateBaseDate;
                    int nDays = chkHourRoom.Checked ? 1 : cmn.CheckIsInt(txtDay, "入住天数");
                    mCustomerStay.Hours = nDays * 24;
                    mCustomerStay.RoomStayType = chkHourRoom.Checked ? 'H' : 'D';
                    mCustomerStay.CommonInfo.EndDate = hml.GetEndDateByStayDays(mCustomerStay.CommonInfo.StartDate, nDays, listSysParameter);
                    mCustomerStay.CommonInfo.CreateUserId = UserInfo.UserId;
                    mCustomerStay.CommonInfo.UpdateUserId = UserInfo.UserId;
                    listCustomerStay.Add(mCustomerStay);
                    eType = RoomLogicType.OpenRoom;

                    #endregion
                }
                if (hml.OpendOrUpdateRoom(listCustomerStay, listCustomer, eType))
                {
                    #region 如果有预定,将预定状态改为已入住

                    if (mOrderInfo != null)
                    {
                        OrdersInfo bOrder = new OrdersInfo();
                        mOrderInfo.Status = 'I';
                        oCtrl.Reset();
                        oCtrl.Add(MCtrl.SetOrderStatus);
                        bOrder.UpdateOrderInfo(mOrderInfo, oCtrl);
                    }
                    #endregion

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void dgvCustomerInfo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (cmn.Confirm("确认删除该宾客信息?"))
            {
                //CustomerModel mDeleteCustomer = new CustomerModel();
                var query = listCustomer.Where(c => c.CustomerId == Convert.ToInt32(e.Row.Cells["CustomerId"].Value)).FirstOrDefault();
                //如果删除的用户是主客,且剩余入住宾客数>=1;则将剩余的宾客设为主客
                if (query.CustomerStayHisInfo.StayType == 'M' && listCustomer.Count >1)
                {
                    var q = listCustomer.Where(c => c.CustomerId != query.CustomerId);
                    if (q.Count() > 0)
                    {
                        q.First().CustomerStayHisInfo.StayType = 'M';
                    }
                }
                query.CustomerStayHisInfo.StayType='S';
                query.CustomerStayHisInfo.HisStatus = 'D';
            }
        }

        private void dgvCustomerInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null)
            {
                cboCustomerType.Text = dgvCustomerInfo["Type", e.RowIndex].Value.ToString();
                cboSex.SelectedItem = dgvCustomerInfo["Sex", e.RowIndex].Value;
                txtCustomerName.Text = dgvCustomerInfo["CustomerName", e.RowIndex].Value.ToString();
                txtIDCard.Text = dgvCustomerInfo["IDCard", e.RowIndex].Value.ToString();
                txtCompany.Text = dgvCustomerInfo["Company", e.RowIndex].Value.ToString();
                txtAddress.Text = dgvCustomerInfo["Address", e.RowIndex].Value.ToString();
                txtPhone.Text = dgvCustomerInfo["Phone", e.RowIndex].Value.ToString();
                
                mCustomerInfo = new CustomerModel();
                mCustomerInfo = listCustomer.Where(c => c.CustomerId == Convert.ToInt32(dgvCustomerInfo["CustomerId", e.RowIndex].Value)).FirstOrDefault();
                if (cmn.FileExsit(cmn.GetImgFilePath(mCustomerInfo.Picture)))
                {
                    pbxUserImg.Image = Image.FromFile(cmn.GetImgFilePath(mCustomerInfo.Picture));
                }
                //dgvCustomerInfo.Rows.RemoveAt(e.RowIndex);
                //listCustomer.Remove(mCustomerInfo);
                //BindCustomer(listCustomer);
            }
        }

        private void dgvCustomerInfo_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BindCustomer(listCustomer);
        }

        private void chkHourRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHourRoom.Checked)
            {
                txtDay.Enabled = false;
                //txtCurrentRate.Enabled = false;
                txtDiskonRate.Enabled = false;
                txtDay.Text = "1";
                txtCurrentRate.Text = hml.ToParameter(listSysParameter, "HOUR_ROOM_RATE").Value1;
                txtCurrentDeposit.Text = hml.ToParameter(listSysParameter, "HOUR_ROOM_DEPOSIT").Value1;
                txtDiskonRate.Text = hml.ToParameter(listSysParameter, "DEFAULT_DISKON").Value1;
            }
            else
            {
                //txtCurrentRate.Enabled = true;
                txtDay.Enabled = true;
                txtDiskonRate.Enabled = true;
                txtDay.Text = hml.ToParameter(listSysParameter, "DEFAULT_STAY_DAYS").Value1; //listSysParameter.Where(c => c.ParamNo == "DEFAULT_STAY_DAYS").Select(c => c.Value1).First();
                txtCurrentDeposit.Text = hml.ToParameter(listSysParameter, "DEFAULT_DEPOSIT").Value1;
                txtCurrentRate.Text = mRoomInfo.RoomRate.ToString();
                txtDiskonRate.Text = hml.ToParameter(listSysParameter, "DEFAULT_DISKON").Value1;
            }
        }

        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            CheckKeyInNumber(txt, e, "0123456789",3);
        }

        private void txtCurrentRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBox txt = (TextBox)sender;
            CheckKeyInNumber(txt, e, "0123456789.",5);
        }

        private void txtIDCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtIDCard, e, "0123456789Xx",18);
        }

        private void btnReadIDCard_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = string.Empty;
                pbxUserImg.Image = null;
                IdentityCardProviderImp IdCard = new IdentityCardProviderImp();
                IdentityCardInfo mCardInfo = IdCard.ReadIdCard(1, true);

                pbxUserImg.Image = mCardInfo.IdImage;
                txtCustomerName.Text = mCardInfo.Name;
                txtAddress.Text = mCardInfo.Address;
                cboSex.SelectedItem = mCardInfo.SexName;
                txtIDCard.Text = mCardInfo.CardId;
                mCustomerInfo = new CustomerModel();
                mCustomerInfo.Nation = mCardInfo.NationName;
                mCustomerInfo.Birthday = mCardInfo.Birthday;

                //btnAddCustomer_Click(sender, new EventArgs());
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        private void txtDiskonRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtDiskonRate, e, "0123456789.", 3);
        }

        private void txtDiskonRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDiskonRate.Text != "" && cmn.CheckIsDouble(txtDiskonRate, "折扣率") > 1)
                {
                    //txtDiskonRate.Text = "1.0";
                    //throw new Exception("折扣率不能大于1");
                }
                txtCurrentRate.Text = (mRoomInfo.RoomRate * cmn.CheckIsDouble(txtDiskonRate, "折扣率")).ToString();
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void cboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPayType.SelectedValue.ToString() == "F")
            {
                if (cmn.Confirm("确定免费?"))
                {
                    txtCurrentDeposit.Text = "0.0";
                    txtCurrentRate.Text = "0.0";
                }
                else
                {
                    cboPayType.SelectedIndex = 0;
                    txtCurrentRate.Text = mRoomInfo.RoomRate.ToString();
                }
            }
        }

        private void tsmOffHotel_Click(object sender, EventArgs e)
        {
            if (!cmn.Confirm("确定" + dgvCustomerInfo.SelectedRows[0].Cells[1].Value + "离店?"))
            {
                return;
            }

            var query = listCustomer.Where(c => c.CustomerId == Convert.ToInt32(dgvCustomerInfo.SelectedRows[0].Cells["CustomerId"].Value)).FirstOrDefault();
            //如果删除的用户是主客,且剩余入住宾客数>=1;则将剩余的宾客设为主客
            if (query.CustomerStayHisInfo.StayType == 'M' && listCustomer.Count > 1)
            {
                var q = listCustomer.Where(c => c.CustomerId != query.CustomerId);
                if (q.Count() > 0)
                {
                    q.First().CustomerStayHisInfo.StayType = 'M';
                }
            }
            query.CustomerStayHisInfo.StayType = 'S';
            query.CustomerStayHisInfo.HisStatus = 'O';
            BindCustomer(listCustomer);
        }

        private void dgvCustomerInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    dgvCustomerInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
            }
        }

    }
}
