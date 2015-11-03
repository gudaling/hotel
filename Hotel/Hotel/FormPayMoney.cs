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
using System.Threading;

namespace Hotel
{
    public partial class FormPayMoney : BaseForm
    {
        private BasRoomModel mRoomInfo = new BasRoomModel();
        private BasRoomInfo bRoom = new BasRoomInfo();
        private HotelMainLogic hml = new HotelMainLogic();
        private CustomerStayModel mCustomerStay = new CustomerStayModel();
        private List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();
        private List<ConsumeDetailModel> listConsume = new List<ConsumeDetailModel>();
        private List<PhoneCatModel> listCat = new List<PhoneCatModel>();
        private List<JFModel> listJf= new List<JFModel>();
        private CallInfo bCall = new CallInfo();
        private JFModel mJf = new JFModel();
        private double dTotal = 0.0,ddeposit=0.0;
        private bool IsCountPhone = false;
        private DateTime dtmNow;

        public FormPayMoney()
        {
            InitializeComponent();
        }

        public FormPayMoney(BasRoomModel mRoomInfo)
        {
            InitializeComponent();
            this.mRoomInfo = mRoomInfo;
        }

        private void FormPayMoney_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void LoadUIInfo()
        {
            try
            {

                List<BasRoomModel> listRoom = new List<BasRoomModel>();
                BasRoomModel mRoom = new BasRoomModel();
                dtmNow = cmn.DateBaseDate;
                mRoom.StatusGroup = "'I','T'";
                IsCountPhone = hml.ToParameter(listSysParameter, "PHONE_JF").Value1.Equals("Y") ? true : false;
                btnPhoneList.Visible = IsCountPhone;
                listCat = bCall.GetPhoneCatList(null, oCtrl.EmptyCtrl);

                listRoom = bRoom.GetRoomInfo(mRoom, new ObjectControls(MCtrl.ByRoomStatusGroup));
                BindCodeInfo(cboPayType, "CUSTOMER_STAY_INFO", "PAY_TYPE");
                char cPayType = 'C';
                if (mRoomInfo.Status == 'I')
                {
                    #region 散客结账
                    mCustomerStay = hml.GetStayInRoomInfo(mRoomInfo, 'I',"");
                    if (mCustomerStay != null)
                    {
                        listCustomerStay.Add(mCustomerStay);
                        lblRoomNo.Text = mRoomInfo.RoomNo;
                        txtStayNo.Text = hml.GetStayNo(mCustomerStay.StayId, listSysParameter);
                        lblMainCustomer.Text = mCustomerStay.CustomerList[0].Name;
                        if (cmn.CheckEOF(mCustomerStay.CustomerList))
                        {
                            if (cmn.FileExsit(cmn.GetImgFilePath(mCustomerStay.CustomerList[0].Picture)))
                            {
                                pbxUserImg.Image = Image.FromFile(cmn.GetImgFilePath(mCustomerStay.CustomerList[0].Picture));
                            }
                            else
                            {
                                pbxUserImg.Image = mCustomerStay.CustomerList[0].Sex == "男" ? Properties.Resources.DefaultMan : Properties.Resources.DefaultWoman;
                            }
                            pbxUserImg.Size = pbxUserImg.Image.Size;
                        }
                        cPayType=mCustomerStay.PayType;
                        txtNotice.Text = mCustomerStay.Notice;
                        var q = listRoom.Where(c => c.RoomId == mRoomInfo.RoomId).First();
                        listRoom.Remove(q);
                        BindTreeViewRoom(tvUsedRooms, listRoom, "入住房间");
                        listRoom = new List<BasRoomModel>();
                        listRoom.Add(mRoomInfo);
                        BindTreeViewRoom(tvPayRooms, listRoom, "结账房间");
                        BindConsumeDetail(listCustomerStay);
                    }
                    else
                    {
                        cmn.Show("该房间不存在消费记录!");
                        this.Dispose();
                        return;
                    }
                    #endregion
                }
                else if (mRoomInfo.Status == 'T')
                {
                    #region 团队结账
                    List<BasRoomModel> listTeamRoom = hml.GetTeamRoomListByRoomId(mRoomInfo, 'I');
                    if (cmn.CheckEOF(listTeamRoom))
                    {
                        BindTreeViewRoom(tvPayRooms, listTeamRoom, "结账房间");
                        foreach (BasRoomModel mTeamRoom in listTeamRoom)
                        {
                            listRoom.Remove(listRoom.Where(c => c.RoomId == mTeamRoom.RoomId).FirstOrDefault());
                        }
                        listCustomerStay = hml.GetStayInRoomInfo(listTeamRoom, 'I',"", true);

                        BindTreeViewRoom(tvUsedRooms, listRoom, "入住房间");
                        BindConsumeDetail(listCustomerStay);

                        lblRoomNo.Text = "结账区域房间";
                        txtStayNo.Text = hml.GetStayNo(mCustomerStay.StayId, listSysParameter);
                        lblMainCustomer.Text = listCustomerStay[0].CustomerList[0].Name;
                        if (cmn.CheckEOF(listCustomerStay[0].CustomerList))
                        {
                            if (cmn.FileExsit(cmn.GetImgFilePath(listCustomerStay[0].CustomerList[0].Picture)))
                            {
                                pbxUserImg.Image = Image.FromFile(cmn.GetImgFilePath(listCustomerStay[0].CustomerList[0].Picture));
                            }
                            else
                            {
                                pbxUserImg.Image = listCustomerStay[0].CustomerList[0].Sex == "男" ? Properties.Resources.DefaultMan : Properties.Resources.DefaultWoman;
                            }
                            pbxUserImg.Size = pbxUserImg.Image.Size;
                        }
                        cPayType = listCustomerStay[0].PayType;
                        txtNotice.Text = listCustomerStay[0].Notice;
                    }
                    #endregion
                }
                else
                {
                    cmn.Show("该房间不存在消费记录!");
                    this.Close();
                }
                cboPayType.SelectedIndex = GetComboxIndexByKey(cboPayType,cPayType);
                CalculateTotal();
                CalculateChange();
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        /// <summary>
        /// 绑定DataGirdView
        /// </summary>
        /// <param name="listSource"></param>
        private void BindConsumeDetail(List<CustomerStayModel> listSource)
        {
            dgvConsumeDetail.Rows.Clear();
            if (cmn.CheckEOF(listSysParameter))
            {
                double dt = 0.0;
                int i = 0;
                if (IsCountPhone)
                {
                    listJf = GetPhoneList(listSource);
                }
                foreach (CustomerStayModel mCustomerStayTmp in listSource)
                {
                    dgvConsumeDetail.Rows.Add();
                    dgvConsumeDetail.Rows[i].Cells["RoomNo"].Value = mCustomerStayTmp.RoomInfo.RoomNo;
                    dgvConsumeDetail.Rows[i].Cells["ConsumeName"].Value = "房间费";
                    dgvConsumeDetail.Rows[i].Cells["UnitPrice"].Value = mCustomerStayTmp.RoomRate;

                    #region 结账时,统计房间使用时间需按照开房类型以及结账时间来计算.

                    RoomStayType eRst = mCustomerStayTmp.RoomStayType.Equals('D') ? RoomStayType.Day : RoomStayType.Hour;
                    dgvConsumeDetail.Rows[i].Cells["Number"].Value = hml.GetCustomerStayDays(mCustomerStayTmp.CommonInfo.StartDate, dtmNow, dtmNow, eRst, listSysParameter);
                    //单项目时,只计算房价,不计算消费的商品费用.


                    dgvConsumeDetail.Rows[i].Cells["TotalMoney"].Value = hml.GetTotalRates(mCustomerStayTmp, null, listSysParameter, dtmNow, 0.0);
                    dt += double.Parse(dgvConsumeDetail.Rows[i].Cells["TotalMoney"].Value.ToString());
                    #endregion

                    dgvConsumeDetail.Rows[i].Cells["Unit"].Value = eRst == RoomStayType.Day ? "天" : "小时";
                    dgvConsumeDetail.Rows[i].Cells["ConsumeDate"].Value = mCustomerStayTmp.CommonInfo.CreateDate;
                    dgvConsumeDetail.Rows[i].Cells["CreateUserName"].Value = mCustomerStayTmp.CommonInfo.CreateUserName;

                    #region 商品消费明细
                    
                    if (cmn.CheckEOF(mCustomerStayTmp.ConSumeDetailList))
                    {
                        for (int j = 0; j < mCustomerStayTmp.ConSumeDetailList.Count; j++)
                        {
                            dgvConsumeDetail.Rows.Add();
                            dgvConsumeDetail.Rows[i + 1].Cells["RoomNo"].Value = mCustomerStayTmp.RoomInfo.RoomNo;
                            dgvConsumeDetail.Rows[i + 1].Cells["ConsumeName"].Value = mCustomerStayTmp.ConSumeDetailList[j].GoodsInfo.GoodsName;
                            dgvConsumeDetail.Rows[i + 1].Cells["UnitPrice"].Value = mCustomerStayTmp.ConSumeDetailList[j].UnitPrice;
                            dgvConsumeDetail.Rows[i + 1].Cells["Unit"].Value = mCustomerStayTmp.ConSumeDetailList[j].GoodsInfo.GoodsUnit;
                            dgvConsumeDetail.Rows[i + 1].Cells["Number"].Value = mCustomerStayTmp.ConSumeDetailList[j].Number;
                            dgvConsumeDetail.Rows[i + 1].Cells["TotalMoney"].Value = mCustomerStayTmp.ConSumeDetailList[j].Total;
                            dgvConsumeDetail.Rows[i + 1].Cells["ConsumeDate"].Value = mCustomerStayTmp.ConSumeDetailList[j].CommonInfo.CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                            dgvConsumeDetail.Rows[i + 1].Cells["CreateUserName"].Value = mCustomerStayTmp.ConSumeDetailList[j].CommonInfo.CreateUserName;
                            dt += mCustomerStayTmp.ConSumeDetailList[j].Total;
                            i++;
                        }
                    }

                    #endregion

                    i++;
                    if (IsCountPhone)
                    {
                        #region 话费明细

                        var query = listJf.Where(c => c.PhoneNo == mCustomerStayTmp.RoomInfo.RoomPhone);
                        double dPhone = 0.0;
                        if (query.Count() > 0)
                        {
                            dPhone = hml.GetPhoneJF(query.ToList(), listCat);
                        }
                        else
                        {
                            JFModel mEmptyJf = new JFModel();
                            mEmptyJf.PhoneNo = mCustomerStayTmp.RoomInfo.RoomPhone;
                            listJf.Add(mEmptyJf);
                        }

                        if (dPhone > 0)
                        {
                            dgvConsumeDetail.Rows.Add();
                            dgvConsumeDetail.Rows[i].Cells["RoomNo"].Value = mCustomerStayTmp.RoomInfo.RoomNo;
                            dgvConsumeDetail.Rows[i].Cells["ConsumeName"].Value = "电话费";
                            dgvConsumeDetail.Rows[i].Cells["UnitPrice"].Value = "";
                            dgvConsumeDetail.Rows[i].Cells["TotalMoney"].Value = dPhone;
                            dt += dPhone;
                            i++;
                        }

                        #endregion
                    }
                }
                lblSelectedRoom.Text = listSource.Count > 1 ? "结账区内房间" : listSource[0].RoomInfo.RoomNo;
                lblSelectedRoomTotal.Text = dt.ToString();
            }
        }

        /// <summary>
        /// 计算找零
        /// </summary>
        private void CalculateChange()
        {
            try
            {
                double dCustomerPay = txtCustomerPay.Text.Equals("") ? 0.0 : cmn.CheckIsDouble(txtCustomerPay, "宾客支付");
                double dPaidMoney = txtTotal.Text.Equals("") ? 0.0 : cmn.CheckIsDouble(txtTotal, "实收费用");
                double dDeposit = lblDeposit.Text.Equals("") ? 0.0 : double.Parse(lblDeposit.Text);
                lblChange.Text = (dDeposit + dCustomerPay - dPaidMoney).ToString();
                lblCash.Text = cboPayType.SelectedValue.ToString() == "C" ? dPaidMoney.ToString() : "0.0";
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        /// <summary>
        /// 计算结账费用
        /// </summary>
        private void CalculateTotal()
        {
            txtTotal.Text = lblSelectedRoomTotal.Text;
            dTotal = txtTotal.Text == "" ? 0.0 : double.Parse(txtTotal.Text);
            ddeposit = 0.0;
            foreach (CustomerStayModel mc in listCustomerStay)
            {
                ddeposit += mc.Deposit;
            }
            lblDeposit.Text = ddeposit.ToString();
        }

        private List<JFModel> GetPhoneList(List<CustomerStayModel> listSource)
        {
            mJf = new JFModel();
            mJf.CatList = listCat;
            var query = (from p in listSource select p.MainRoomId).Distinct();
            foreach (int nMainId in query)
            {
                if (nMainId > 0)
                {
                    var qTeamRoom = listSource.Where(c => c.MainRoomId == nMainId);
                    List<CustomerStayModel> listChangeRomCustomerStay = new List<CustomerStayModel>();
                    foreach (CustomerStayModel mcs in qTeamRoom)
                    {
                        if (listJf.Where(c => c.PhoneNo == mcs.RoomInfo.RoomPhone).Count() > 0)
                        {
                            continue;
                        }
                        mJf.CommonInfo.StartDate = mcs.CommonInfo.StartDate;
                        if (mcs.ConSumeDetailList.Where(c => c.GoodsInfo.Type == 'R').Count() == 0)
                        {
                            mJf.PhoneNoGroup += cmn.MakeGroup(mcs.RoomInfo.RoomPhone);
                        }
                        else
                        {
                            listChangeRomCustomerStay.Add(mcs);
                        }
                    }
                    if (mJf.PhoneNoGroup != "")
                    {
                        mJf.CommonInfo.EndDate = dtmNow;
                        listJf.AddRange(hml.GetPhoneList(mJf, dtmNow));
                    }
                    if (cmn.CheckEOF(listChangeRomCustomerStay))
                    {
                        foreach (CustomerStayModel mcs in listChangeRomCustomerStay)
                        {
                            if (listJf.Where(c => c.PhoneNo == mcs.RoomInfo.RoomPhone).Count() > 0)
                            {
                                continue;
                            }
                            mJf.CommonInfo.StartDate = mcs.CommonInfo.StartDate;
                            mJf.CommonInfo.EndDate = dtmNow;
                            mJf.PhoneNoGroup = cmn.MakeGroup(mcs.RoomInfo.RoomPhone);
                            listJf.AddRange(hml.GetPhoneList(mJf, dtmNow));
                        }
                    }
                }
                else
                {
                    var qRooms = listSource.Where(c => c.MainRoomId == nMainId);
                    foreach (CustomerStayModel mcs in qRooms)
                    {
                        if (listJf.Where(c => c.PhoneNo == mcs.RoomInfo.RoomPhone).Count() > 0)
                        {
                            continue;
                        }
                        mJf.CommonInfo.StartDate = mcs.CommonInfo.StartDate;
                        mJf.CommonInfo.EndDate = dtmNow;
                        mJf.PhoneNoGroup = cmn.MakeGroup(mcs.RoomInfo.RoomPhone);
                        listJf.AddRange(hml.GetPhoneList(mJf, dtmNow));
                    }
                }
            }
            //foreach (CustomerStayModel mcs in listSource)
            //{
            //    if (listJf.Where(c => c.PhoneNo == mcs.RoomInfo.RoomPhone).Count() > 0)
            //    {
            //        continue;
            //    }
            //    #region 话费明细

            //    mJf.CommonInfo.StartDate = dtmNow.AddDays(-100); //mCustomerStayTmp.CommonInfo.StartDate;
            //    mJf.CommonInfo.EndDate = dtmNow;
            //    mJf.PhoneNoGroup = hml.MakeGroup(mcs.RoomInfo.RoomPhone);
            //    listJf.AddRange(hml.GetPhoneList(mJf, dtmNow));

            //    #endregion
            //}
            return listJf;
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            if (tvUsedRooms.SelectedNode == null)
            {
                return;
            }
            if (tvUsedRooms.SelectedNode.Level > 1)
            {
                MessageBox.Show("团队房间不能单独结账");
                return;
            }
            if (tvUsedRooms.SelectedNode.Level == 1)
            {
                TreeNode tn = new TreeNode();
                tn = (TreeNode)tvUsedRooms.SelectedNode.Clone();
                if (!tvPayRooms.Nodes[0].Nodes.Contains(tn))
                {
                    tvPayRooms.Nodes[0].Nodes.Add(tn);
                    tvUsedRooms.SelectedNode.Remove();
                    CustomerStayModel mSelectedRoomConsume = new CustomerStayModel();
                    mSelectedRoomConsume = hml.GetStayInRoomInfo(new BasRoomModel(int.Parse(tn.Name)), 'I', "");
                    if (listCustomerStay.Where(c => c.RoomId == int.Parse(tn.Name)).Count() == 0)
                    {
                        listCustomerStay.Add(mSelectedRoomConsume);
                    }
                    foreach (TreeNode tn1 in tn.Nodes)
                    {
                        mSelectedRoomConsume = hml.GetStayInRoomInfo(new BasRoomModel(int.Parse(tn1.Name)), 'I', "");
                        if (listCustomerStay.Where(c => c.RoomId == int.Parse(tn1.Name)).Count() == 0)
                        {
                            listCustomerStay.Add(mSelectedRoomConsume);
                        }
                    }
                    BindConsumeDetail(listCustomerStay);
                    CalculateTotal();
                }
            }
        }

        private void pbxRemove_Click(object sender, EventArgs e)
        {
            if (tvPayRooms.SelectedNode == null)
            {
                return;
            }
            if (tvPayRooms.SelectedNode.Level == 1 && tvPayRooms.SelectedNode.Name != mRoomInfo.RoomId.ToString() 
                && tvPayRooms.SelectedNode.Name!=listCustomerStay[0].MainRoomId.ToString())
            {
                TreeNode tn = new TreeNode();
                tn = (TreeNode)tvPayRooms.SelectedNode.Clone();
                if (!tvUsedRooms.Nodes[0].Nodes.Contains(tn))
                {
                    tvUsedRooms.Nodes[0].Nodes.Add(tn);
                    tvPayRooms.SelectedNode.Remove();

                    var q = listCustomerStay.Where(c => c.RoomId == int.Parse(tn.Name)).First();
                    listCustomerStay.Remove(q);
                    foreach (TreeNode tn1 in tn.Nodes)
                    {
                        q = listCustomerStay.Where(c => c.RoomId == int.Parse(tn1.Name)).First();
                        listCustomerStay.Remove(q);
                    }
                    BindConsumeDetail(listCustomerStay);
                    CalculateTotal();
                }
            }
        }

        private void tvUsedRooms_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level >=1)
            {
               BindConsumeDetail(GetSelectedNodesConsume(e.Node, true));
            }
        }

        private void tvPayRooms_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level >= 1)
            {
                BindConsumeDetail(GetSelectedNodesConsume(e.Node, true));
            }
            else if (e.Node.Level == 0)
            {
                BindConsumeDetail(GetSelectedNodesConsume(e.Node, false));
            }
        }

        private List<CustomerStayModel> GetSelectedNodesConsume(TreeNode tn, bool IsContainCurrentNode)
        {
            List<CustomerStayModel> listTmp = new List<CustomerStayModel>();
            CustomerStayModel mSelectedRoomConsume = new CustomerStayModel();
            if (IsContainCurrentNode)
            {
                mSelectedRoomConsume = hml.GetStayInRoomInfo(new BasRoomModel(int.Parse(tn.Name)), 'I', "");
                if (mSelectedRoomConsume != null)
                {
                    listTmp.Add(mSelectedRoomConsume);
                }
            }
            foreach (TreeNode tnC in tn.Nodes)
            {
                if (tnC.Nodes.Count > 0)
                {
                    foreach (TreeNode tnC1 in tnC.Nodes)
                    {
                        mSelectedRoomConsume = hml.GetStayInRoomInfo(new BasRoomModel(int.Parse(tnC1.Name)), 'I', "");
                        if (mSelectedRoomConsume != null)
                        {
                            listTmp.Add(mSelectedRoomConsume);
                        }
                    }
                }
                mSelectedRoomConsume = hml.GetStayInRoomInfo(new BasRoomModel(int.Parse(tnC.Name)), 'I', "");
                if (mSelectedRoomConsume != null)
                {
                    listTmp.Add(mSelectedRoomConsume);
                }
            }
            return listTmp;
        }

        private void txtCustomerPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtCustomerPay, e,"0123456789.",8);
        }

        private void txtCustomerPay_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(lblChange.Text) < 0)
                {
                    throw new Exception("付款金额不足,不能结账!");
                }
                if (txtStayNo.Text.Trim() == "")
                {
                    throw new Exception("结账单号不能为空!");
                }
                if (!cmn.Confirm("确定结账?\r结账单号码为:" + txtStayNo.Text))
                {
                    return;
                }
                btnPay.Enabled = false;
                if (cmn.Confirm("附加打印消费清单?"))
                {
                    BindConsumeDetail(listCustomerStay);//重新绑定一下GridView.防止用户选择了其他房间节点,照成GridView上显示的信息与结账房不符
                    ThreadStart ts = new ThreadStart(PintCertificate);
                    Thread th = new Thread(ts);
                    th.Start();
                }

                foreach (CustomerStayModel mCS in listCustomerStay)
                {
                    mCS.Deposit = mCS.Deposit;
                    mCS.CommonInfo.EndDate = dtmNow;
                    mCS.Hours = Convert.ToInt32(mCS.CommonInfo.EndDate.Subtract(mCS.CommonInfo.StartDate).TotalHours);
                    mCS.Notice = txtNotice.Text;
                    mCS.PayType = cmn.ToChar(cboPayType.SelectedValue);
                    mCS.PaidMoney = mCS.RoomId == mRoomInfo.RoomId ? double.Parse(lblCash.Text) : 0.0;
                    mCS.Total = mCS.RoomId == mRoomInfo.RoomId ? double.Parse(txtTotal.Text) : 0.0;
                    mCS.Status = 'O';
                    mCS.CommonInfo.UpdateUserId = UserInfo.UserId;
                    mCS.StayNo = txtStayNo.Text;
                }
                if (hml.CheckOutRoom(listCustomerStay))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
               
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void txtFastSelectRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                foreach (TreeNode tn in tvUsedRooms.Nodes[0].Nodes)
                {
                    if (tn.Text == txtFastSelectRoom.Text)
                    {
                        tvUsedRooms.SelectedNode = tn;
                        break;
                    }
                    if (tn.Nodes.Count > 0)
                    {
                        bool IsFind = false;
                        foreach (TreeNode tn1 in tn.Nodes)
                        {
                            if (tn1.Text == txtFastSelectRoom.Text)
                            {
                                tn1.Expand();
                                tvUsedRooms.SelectedNode = tn1;
                                tn1.EnsureVisible();
                                IsFind = true;
                                break;
                            }
                        }
                        if (IsFind)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void btnPhoneList_Click(object sender, EventArgs e)
        {
            if (cmn.CheckEOF(listJf))
            {
                FormPhoneList frmPhoneList = new FormPhoneList(listJf,listCat,listCustomerStay);
                frmPhoneList.ShowDialog();
            }
        }

        private void cboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomerPay.Enabled = cboPayType.SelectedValue.ToString() == "F" ? false : true;
            txtTotal.Enabled = txtCustomerPay.Enabled;
            txtTotal.Text = cboPayType.SelectedValue.ToString() == "F" ? "0.0" : dTotal.ToString();
            lblCash.Text = cboPayType.SelectedValue.ToString() == "C" ? dTotal.ToString() : "0.0";
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void PintCertificate()
        {
            DataGridView dgv = new DataGridView();
            dgv.Columns.Add("Name", "姓名");
            dgv.Columns.Add("ToTime", "抵店日期");
            dgv.Columns.Add("OutTime", "抵店时间");

            dgv.Columns.Add("ConsumeName", "消费项目");
            dgv.Columns.Add("UnitPrice", "单价");
            dgv.Columns.Add("Unit", "单位");
            dgv.Columns.Add("Number", "消费数量");
            dgv.Columns.Add("TotalMoney", "应收");
            //dgv.Columns["Name"].Width = dgvConsumeDetail.Columns["Name"].Width;
            dgv.Columns["ConsumeName"].Width = dgvConsumeDetail.Columns["ConsumeName"].Width;
            dgv.Columns["UnitPrice"].Width = dgvConsumeDetail.Columns["UnitPrice"].Width;
            dgv.Columns["Unit"].Width = dgvConsumeDetail.Columns["Unit"].Width;
            dgv.Columns["Number"].Width = dgvConsumeDetail.Columns["Number"].Width;
            dgv.Columns["TotalMoney"].Width = dgvConsumeDetail.Columns["TotalMoney"].Width;

            dgv.Width = dgv.Columns["ConsumeName"].Width
         + dgv.Columns["UnitPrice"].Width
         + dgv.Columns["Unit"].Width
         + dgv.Columns["Number"].Width
         + dgv.Columns["TotalMoney"].Width;

            dgv.AllowUserToAddRows = true;

            int i = 0;
            foreach (DataGridViewRow dgvr in dgvConsumeDetail.Rows)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells["ConsumeName"].Value = dgvr.Cells["ConsumeName"].Value;
                dgv.Rows[i].Cells["UnitPrice"].Value = dgvr.Cells["UnitPrice"].Value;
                dgv.Rows[i].Cells["Unit"].Value = dgvr.Cells["Unit"].Value;
                dgv.Rows[i].Cells["Number"].Value = dgvr.Cells["Number"].Value;
                dgv.Rows[i].Cells["TotalMoney"].Value = dgvr.Cells["TotalMoney"].Value;
                i++;
            }
            dgv.Rows.Add();
            dgv.Rows[i].Cells["ConsumeName"].Value = "合计：";
            dgv.Rows[i].Cells["UnitPrice"].Value = txtTotal.Text;
            dgv.Rows[i].Cells["Unit"].Value = "押金：" ;
            dgv.Rows[i].Cells["Number"].Value = lblDeposit.Text;
            dgv.Rows[i].Cells["TotalMoney"].Value = "找零：" + (double.Parse(lblDeposit.Text) - double.Parse(txtTotal.Text)).ToString();

            if (dgvConsumeDetail.Rows.Count > 0)
            {
                PrintInfo bPrint = new PrintInfo();
                PrintModel mPrint = new PrintModel();
                mPrint = bPrint.GetPrintModel(new PrintModel(this.Name), new ObjectControls(MCtrl.ByPrintNo));
                CommonModel mComm = new CommonModel();
                mPrint = bPrint.GetPrintSet(mPrint, new Object[] { UserInfo });
                DataGridViewPrint dgvp = new DataGridViewPrint(new DataGridView[] { dgv });
                dgvp.GetPrintConfig = mPrint;
                dgvp.Print(true, false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmn.Confirm("打印消费清单?"))
            {
                BindConsumeDetail(listCustomerStay);//重新绑定一下GridView.防止用户选择了其他房间节点,照成GridView上显示的信息与结账房不符
                PintCertificate();
            }
        }
    }
}
