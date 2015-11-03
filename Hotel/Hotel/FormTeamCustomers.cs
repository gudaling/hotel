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
using Indexsoft.NewIdCard;

namespace Hotel
{
    public partial class FormTeamCustomers : BaseForm
    {
        private BasRoomInfo bRoom = new BasRoomInfo();
        private CustomerStayInfo bCustomerStay = new CustomerStayInfo();
        private HotelMainLogic hml = new HotelMainLogic();
        private TreeNode tnSelected = new TreeNode();
        private List<BasRoomModel> listSelectedRoom = new List<BasRoomModel>();
        private List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
        private CustomerModel mCustomer = new CustomerModel();

        private double dDiskon = 1.0;
        public FormTeamCustomers()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTeamCustomers_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }
        private void LoadUIInfo()
        {
            oCtrl.Reset();
            oCtrl.Add(MCtrl.ByRoomStatus);
            BasRoomModel mRoom = new BasRoomModel();
            mRoom.Status = 'E';
            listRoomInfo = bRoom.GetRoomInfo(mRoom, oCtrl);
            BindEnabledRoomTree(listRoomInfo);
            BindCodeInfo(cboPayType, "CUSTOMER_STAY_INFO", "PAY_TYPE");
            cboSex.SelectedIndex = 0;
            dDiskon = double.Parse(hml.ToParameter(listSysParameter, "DEFAULT_DISKON").Value1);
        }

        private void BindEnabledRoomTree(List<BasRoomModel>listRoomTmp)
        {
            tvEnableRoom.Nodes.Clear();
            foreach (BasRoomModel mR in listRoomTmp)
            {
                AddTvNode(mR);
            }
        }

        private void AddTvNode(BasRoomModel mRoom)
        {
            TreeNode tn = new TreeNode();
            tn.Text = mRoom.RoomNo;
            tn.Name = mRoom.RoomId.ToString();
            TreeNode[] tnl = tvEnableRoom.Nodes.Find(mRoom.RoomType.ToString(), false);
            if (tnl.Length > 0)
            {
                tnl[0].Nodes.Add(tn);
            }
            else
            {
                TreeNode tnN = new TreeNode();
                tnN.Text = mRoom.RoomTypeDesc;
                tnN.Name = mRoom.RoomType.ToString();
                tnN.Nodes.Add(tn);
                tvEnableRoom.Nodes.Add(tnN);
            }
        }
        private void BindSelectedRoomDgv(List<BasRoomModel> listRoomTmp)
        {
            dgvSelectedRoom.Rows.Clear();
            int i = 0;
            foreach (BasRoomModel mRoom in listRoomTmp)
            {
                dgvSelectedRoom.Rows.Add();
                dgvSelectedRoom.Rows[i].Cells["RoomType"].Value = mRoom.RoomTypeDesc;
                dgvSelectedRoom.Rows[i].Cells["RoomNo"].Value = mRoom.RoomNo;
                dgvSelectedRoom.Rows[i].Cells["RoomRate"].Value = mRoom.RoomRate;
                dgvSelectedRoom.Rows[i].Cells["Diskon"].Value = dDiskon;
                dgvSelectedRoom.Rows[i].Cells["RoomRateNow"].Value = dDiskon * mRoom.RoomRate;
                i++;
            }
        }

        private void txtRoomOrName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==13)
            {
                foreach (TreeNode tn in tvEnableRoom.Nodes)
                {
                    foreach (TreeNode tn1 in tn.Nodes)
                    {
                        if (tn1.Text == txtRoomOrName.Text)
                        {
                            tn.Expand();
                            tvEnableRoom.SelectedNode = tn1;
                            tn1.EnsureVisible();
                            break;
                        }
                    }
                }
            }
        }

        private void tvEnableRoom_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null&&e.Node.Level>0)
            {
                BasRoomModel mSelectedRoom = new BasRoomModel();
                var query = listRoomInfo.Where(c => c.RoomNo == e.Node.Text).First();
                mSelectedRoom = query;
                listSelectedRoom.Add(mSelectedRoom);
                listRoomInfo.Remove(query);
                tvEnableRoom.Nodes.Remove(e.Node);
                BindSelectedRoomDgv(listSelectedRoom);
                BindMainRoom(listSelectedRoom);
            } 
        }

        private void dgvSelectedRoom_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e != null)
            {
                BasRoomModel mSelectedRoom = new BasRoomModel();
                var query = listSelectedRoom.Where(c => c.RoomNo == dgvSelectedRoom.Rows[e.RowIndex].Cells["RoomNo"].Value.ToString()).First();
                mSelectedRoom = query;
                listRoomInfo.Add(mSelectedRoom);
                listSelectedRoom.Remove(query);
                AddTvNode(mSelectedRoom);
                BindSelectedRoomDgv(listSelectedRoom);
                BindMainRoom(listSelectedRoom);
            }
        }

        private void pbtnAdd_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvEnableRoom.SelectedNode;
            if (tn != null && tn.Level > 0)
            {
                BasRoomModel mSelectedRoom = new BasRoomModel();
                var query = listRoomInfo.Where(c => c.RoomNo == tn.Text).First();
                mSelectedRoom = query;
                listSelectedRoom.Add(mSelectedRoom);
                listRoomInfo.Remove(query);
                tvEnableRoom.Nodes.Remove(tn);
                BindSelectedRoomDgv(listSelectedRoom);
                BindMainRoom(listSelectedRoom);
            }
        }

        private void pbtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSelectedRoom.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = dgvSelectedRoom.SelectedRows[0];
                if (dgvr != null)
                {
                    BasRoomModel mSelectedRoom = new BasRoomModel();
                    var query = listSelectedRoom.Where(c => c.RoomNo == dgvr.Cells["RoomNo"].Value.ToString()).First();
                    mSelectedRoom = query;
                    listRoomInfo.Add(mSelectedRoom);
                    listSelectedRoom.Remove(query);
                    AddTvNode(mSelectedRoom);
                    BindSelectedRoomDgv(listSelectedRoom);
                    BindMainRoom(listSelectedRoom);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cmn.CheckEOF(listSelectedRoom))
                {
                    throw new Exception("请选择房间");
                }
                if (string.IsNullOrEmpty(txtCustomerName.Text.Trim()))
                {
                    throw new Exception("请输入主客姓名");
                }
                if (string.IsNullOrEmpty(txtIDCard.Text.Trim()))
                {
                    throw new Exception("请输入证件号码");
                }
                if (string.IsNullOrEmpty(txtStayDays.Text.Trim()))
                {
                    throw new Exception("请输入预住天数");
                }
                if (string.IsNullOrEmpty(txtDeposit.Text.Trim()))
                {
                    throw new Exception("请输入押金数");
                }
                int nRoomCount = listSelectedRoom.Count;
                if (nRoomCount < 2)
                {
                    throw new Exception("团队房间数不能小于2间,否则请使用散客开单功能.");  
                }
                double dDeposit = cmn.CheckIsDouble(txtDeposit, "押金");
                int nMainRoomId = int.Parse(cboMainRoom.SelectedValue.ToString());
                List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();
               double dEachDeposit=0.0;
               if (chkAvgDeposit.Checked)
               {
                   dEachDeposit = (dDeposit - dDeposit % listSelectedRoom.Count) / nRoomCount;
               }
               else
               {
                   dEachDeposit = dDeposit;
               }

               for (int i = 0; i < nRoomCount; i++)
                {
                    CustomerStayModel mTeamCustomerStay = new CustomerStayModel();
                    if (chkAvgDeposit.Checked)
                    {
                        mTeamCustomerStay.Deposit = i == nRoomCount - 1 ? dEachDeposit + dDeposit % nRoomCount : dEachDeposit;
                    }
                    else
                    {
                        mTeamCustomerStay.Deposit = listSelectedRoom[i].RoomId == nMainRoomId ? dEachDeposit : 0.0;
                    }
                    mTeamCustomerStay.Hours = cmn.CheckIsInt(txtStayDays, "入住天数") * 24;
                    mTeamCustomerStay.MainRoomId = nMainRoomId;
                    mTeamCustomerStay.Notice = txtNotice.Text;
                    mTeamCustomerStay.PayType = cmn.ToChar(cboPayType.SelectedValue);
                    mTeamCustomerStay.RoomStayType = 'D';
                    mTeamCustomerStay.Status = 'I';
                    mTeamCustomerStay.CommonInfo = new CommonModel();
                    mTeamCustomerStay.CommonInfo.CreateUserId = UserInfo.UserId;
                    mTeamCustomerStay.CommonInfo.UpdateUserId = UserInfo.UserId;
                    mTeamCustomerStay.CommonInfo.StartDate = cmn.DateBaseDate;
                    mTeamCustomerStay.CommonInfo.EndDate = hml.GetEndDateByStayDays(mTeamCustomerStay.CommonInfo.StartDate, cmn.CheckIsInt(txtStayDays, "入住天数"), listSysParameter);
                    mTeamCustomerStay.RoomRate = listSelectedRoom[i].RoomRate * dDiskon;
                    mTeamCustomerStay.RoomId = listSelectedRoom[i].RoomId;
                    mTeamCustomerStay.RoomInfo = new BasRoomModel();
                    mTeamCustomerStay.RoomInfo.Status = 'T';

                    mTeamCustomerStay.CustomerList = new List<CustomerModel>();
                    //CustomerModel mCustomer = new CustomerModel();
                    mCustomer.Name = txtCustomerName.Text;
                    mCustomer.IdCardNo = txtIDCard.Text;
                    mCustomer.Sex = cboSex.SelectedItem.ToString();
                    mCustomer.Phone = txtPhone.Text;
                    mCustomer.Company = txtCompany.Text;
                    mCustomer.Address = txtAddress.Text;
                    if (pbxUserImg.Image != null)
                    {
                        mCustomer.Picture = cmn.SaveImage(pbxUserImg.Image, cmn.DateBaseDate.ToString("yyyyMMddHHmmss"), "CARD_IMG");
                    }
                    mCustomer.CommonInfo = mTeamCustomerStay.CommonInfo;
                    mCustomer.CustomerStayHisInfo = new CustomerStayHisModel();
                    mCustomer.CustomerStayHisInfo.HisStatus = 'E';
                    mCustomer.CustomerStayHisInfo.StayType = 'M';
                    mCustomer.CustomerStayHisInfo.CommonInfo = mTeamCustomerStay.CommonInfo;
                    mTeamCustomerStay.CustomerList.Add(mCustomer);
                    listCustomerStay.Add(mTeamCustomerStay);
                }
                if (hml.OpendOrUpdateRoom(listCustomerStay, listCustomerStay[0].CustomerList, RoomLogicType.OpenRoom))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        private void BindMainRoom(List<BasRoomModel>listRoomTmp)
        {
            cboMainRoom.DataSource = null;
            if (cmn.CheckEOF(listRoomTmp))
            {
                cboMainRoom.DataSource = listRoomTmp;
                cboMainRoom.DisplayMember = "RoomNo";
                cboMainRoom.ValueMember = "RoomId";
                cboMainRoom.SelectedIndex = 0;
            }
        }

        private void txtStayDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtStayDays, e, "0123456789",3);
        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtDeposit, e, "0123456789.",5);
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
                mCustomer = new CustomerModel();
                pbxUserImg.Image = null;
                IdentityCardProviderImp IdCard = new IdentityCardProviderImp();
                IdentityCardInfo mCardInfo = IdCard.ReadIdCard(1, true);

                pbxUserImg.Image = mCardInfo.IdImage;
                txtCustomerName.Text = mCardInfo.Name;
                txtAddress.Text = mCardInfo.Address;
                cboSex.SelectedItem = mCardInfo.SexName;
                txtIDCard.Text = mCardInfo.CardId;

                mCustomer.Nation = mCardInfo.NationName;
                mCustomer.Birthday = mCardInfo.Birthday;

            }
            catch (Exception err)
            {
                lblMsg.Text = err.Message;
            }
        }

        //private void tvEnableRoom_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        TreeNode tn = e.Node;
        //        if (tnSelected != tn)
        //        {
        //            tnSelected.ForeColor = tn.ForeColor;
        //            tn.ForeColor = Color.Red;
        //            tn.NodeFont = tvEnableRoom.Font;
        //            tnSelected = tn;
        //        }
        //    }
        //}
    }
}
