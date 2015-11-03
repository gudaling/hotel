using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Common;
using Hotel.BLL;
using Hotel.Model;
using System.Runtime.InteropServices;
using System.Threading;
using Sunisoft.IrisSkin;

namespace Hotel
{
    public partial class FormMain : BaseForm
    {
        private Point ptcts = new Point();

        private BasRoomInfo bRoomInfo = new BasRoomInfo();
        private BasFloorInfo bFloorInfo = new BasFloorInfo();
        private SysParameterInfo bSysParameter = new SysParameterInfo();
        private CustomerStayInfo bStay = new CustomerStayInfo();
        private ConsumeDetail bConsume = new ConsumeDetail();
        private CallInfo bCall = new CallInfo();
        private DigiLockInfo bDigiLock = new DigiLockInfo();
        private HotelMainLogic hml = new HotelMainLogic();

        public SkinEngine sk
        {
            get { return skinEngine1; }
            set { skinEngine1 = value; }
        }
        private List<BasRoomModel> listAllRoomInfo = new List<BasRoomModel>();
        private List<PhoneCatModel> listCat = new List<PhoneCatModel>();
        private List<JFModel> listJf = new List<JFModel>();
        private List<RoomListModel> DigiRoomList = new List<RoomListModel>();

        PictureBox Clickedpb;
        private double dCurrentJf = 0.0;
        private bool IsCountPhone
        {
            get
            {
                return hml.ToParameter(listSysParameter, "PHONE_JF").Value1.Equals("Y") ? true : false;
            }
        }

        private bool IsConnectDigiLock
        {
            get
            {
                return hml.ToParameter(listSysParameter, "DIGILOCK").Value1.Equals("Y") ? true : false;
            }
        }

        private string DigiStatus(string sRoomNo, string Status)
        {
            if (Status.Equals("E") || Status.Equals("C"))
            {
                var query = DigiRoomList.Where(c => c.RoomNo == sRoomNo);
                return query.Count() > 0 ? query.First().State : "";
            }
            return "";
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                listSysParameter = bSysParameter.GetSysParameter(null, oCtrl.EmptyCtrl);
                listCat = bCall.GetPhoneCatList(null, oCtrl.EmptyCtrl);
                HideSysCtrl();
                ApplySetting();
                ShowRoom(-1);
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        #region 杂项

        private void tmrFlash_Tick(object sender, EventArgs e)
        {
            ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
        }

        delegate void SetbgCallback(Bitmap btm, bool IsVisible, DockStyle ds);

        private void GrayScaleForm()
        {
            SetPnBg(GrayScale.MakeGrayscale(GrayScale.GetFormImage(this)), true, DockStyle.Fill);
        }

        private void HideSysCtrl()
        {
            pbtnSysSet.Visible = UserInfo.RoleInfo.RoleId == 1 ? true : false;
            label18.Visible = pbtnSysSet.Visible;
            tsSysSet.Visible = pbtnSysSet.Visible;
        }

        private void ApplySetting()
        {
            //宾馆标题
            this.Text = hml.ToParameter(listSysParameter, "HOTEL_NAME").Value1;

            //启用自动刷新功能
            tmrFlash.Enabled = hml.ToParameter(listSysParameter, "FLASH_ROOM_INFO").Value1.Equals("Y") ? true : false;
            tmrFlash.Interval = Convert.ToInt32(hml.ToParameter(listSysParameter, "FLASH_ROOM_INFO").Value2);

            //启动自动统计入住率
            tmAutoSetStayRate.Enabled = hml.ToParameter(listSysParameter, "AUTO_STAY_RATE").Value1.Equals("Y") ? true : false;
            tmAutoSetStayRate.Interval = Convert.ToInt32(hml.ToParameter(listSysParameter, "AUTO_STAY_RATE").Value2);

        }
        /// <summary>
        /// 将pn的背景修改成灰度图像
        /// </summary>
        /// <param name="btm"></param>
        /// <param name="IsVisible"></param>
        /// <param name="ds"></param>
        private void SetPnBg(Bitmap btm, bool IsVisible, DockStyle ds)
        {
            if (this.GrayPnl.InvokeRequired)
            {
                SetbgCallback d = new SetbgCallback(SetPnBg);
                this.Invoke(d, new object[] { btm, IsVisible, ds });
            }
            else
            {
                this.GrayPnl.BackgroundImage = btm;
                msBar.Visible = !IsVisible;
                GrayPnl.Visible = IsVisible;
                GrayPnl.Dock = ds;
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (!cmn.Confirm("确定锁定屏幕?"))
            {
                return;
            }
            ThreadStart ts = new ThreadStart(GrayScaleForm);
            Thread th = new Thread(ts);
            th.Start();

            FormLockScreen frmLockScreen = new FormLockScreen();
            if (frmLockScreen.ShowDialog() == DialogResult.OK)
            {
                if (th.IsAlive)
                {
                    th.Abort();
                }
                GrayPnl.BackgroundImage = null;
                GrayPnl.Visible = false;
                msBar.Visible = true;
            }
        }

        private void btnReFlash_Click(object sender, EventArgs e)
        {
            ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
        }

        private void btnRoomDetail_Click(object sender, EventArgs e)
        {
            FormRoomDetail frmRoomDetail = new FormRoomDetail();
            if (frmRoomDetail.ShowDialog() == DialogResult.OK)
            {
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        #endregion

        #region 主界面图标

        private void pbtnOne_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null && hml.OpenRoomCheck(mRoomNo))
            {
                FormOneCustomer frmOneCustomer = new FormOneCustomer(mRoomNo);
                if (frmOneCustomer.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        private void pbtnTeam_Click(object sender, EventArgs e)
        {
            FormTeamCustomers frmTeam = new FormTeamCustomers();
            if (frmTeam.ShowDialog() == DialogResult.OK)
            {
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        private void pbtnAddPay_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormAddPay frmAddPay = new FormAddPay(mCustomerStay);
                    if (frmAddPay.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能.");
                }
            }
        }

        private void pbtnPayMoney_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormPayMoney frmPayMoney = new FormPayMoney(mRoomNo);
                    if (frmPayMoney.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能.");
                }
            }
        }

        private void pbtnOrders_Click(object sender, EventArgs e)
        {
            FormOrders frmOrders = new FormOrders();
            frmOrders.ShowDialog();
        }

        private void pbtnHandOver_Click(object sender, EventArgs e)
        {
            FormHandOver frmHandOver = new FormHandOver();
            if (frmHandOver.ShowDialog() == DialogResult.OK)
            {
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        private void pbtnReport_Click(object sender, EventArgs e)
        {
            FormReports frmReports = new FormReports();
            frmReports.ShowDialog();
        }

        #endregion

        #region 房间菜单

        private void tsmOneOpenRoom_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null && hml.OpenRoomCheck(mRoomNo))
            {
                FormOneCustomer frmOne = new FormOneCustomer(mRoomNo);
                if (frmOne.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        private void tsmPayMoney_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null)
            {
                FormPayMoney frmPayMoney = new FormPayMoney(mRoomNo);
                if (frmPayMoney.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        private void tsmAddPay_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormAddPay frmAddPay = new FormAddPay(mCustomerStay);
                    if (frmAddPay.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能");
                }
            }
        }

        private void tsmChangeRoom_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null)
            {
                FormChangeRoom frmAddPay = new FormChangeRoom(mRoomNo);
                if (frmAddPay.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        private void tsmReturnDeposit_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormReturnDeposit frmReturnDeposit = new FormReturnDeposit(mCustomerStay);
                    if (frmReturnDeposit.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能.");
                }
            }
        }

        private void tsmChangeRoomState_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null)
            {
                FormModifyRoomState frmModifyRoom = new FormModifyRoomState(mRoomNo);
                if (frmModifyRoom.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        private void tsmModifyRegister_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormOneCustomer frmOne = new FormOneCustomer(mRoomNo);
                    if (frmOne.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能.");
                }
            }
        }

        private void tsmTeamOpenRoom_Click(object sender, EventArgs e)
        {
            FormTeamCustomers frmTeam = new FormTeamCustomers();
            if (frmTeam.ShowDialog() == DialogResult.OK)
            {
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        private void tsmCustomerOrder_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetSelectRoomNo(GetSelectPBX(ptcts));
            if (mRoomNo != null)
            {
                FormNewOrder frmNewOrder = new FormNewOrder(mRoomNo);
                if (frmNewOrder.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        #endregion

        #region 工具栏菜单

        private void tsOneCustomer_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null && hml.OpenRoomCheck(mRoomNo))
            {
                FormOneCustomer frmOneCustomer = new FormOneCustomer(mRoomNo);
                if (frmOneCustomer.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        private void tsReturnDeposit_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormReturnDeposit frmReturnDeposit = new FormReturnDeposit(mCustomerStay);
                    if (frmReturnDeposit.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能.");
                }
            }
        }

        private void tsChangeRoom_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null)
            {
                FormChangeRoom frmChangeRoom = new FormChangeRoom(mRoomNo);
                frmChangeRoom.Show();
            }
        }

        private void tsModifyRoomState_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null)
            {
                FormModifyRoomState frmModifyState = new FormModifyRoomState(mRoomNo);
                if (frmModifyState.ShowDialog() == DialogResult.OK)
                {
                    ShowRoom(mRoomNo.FloorInfo.FloorId);
                }
            }
        }

        private void tsTeamCustomer_Click(object sender, EventArgs e)
        {
            FormTeamCustomers frmTeamCustomer = new FormTeamCustomers();
            if (frmTeamCustomer.ShowDialog() == DialogResult.OK)
            {
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        private void tsEditRegister_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormOneCustomer formOneCustomer = new FormOneCustomer(mRoomNo);
                    if (formOneCustomer.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能.");
                }
            }
        }

        private void tsPayMoney_Click(object sender, EventArgs e)
        {
            BasRoomModel mRoomNo = GetKeyRoomNo();
            if (mRoomNo != null)
            {
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(mRoomNo, 'I', "M");
                if (mCustomerStay != null)
                {
                    FormPayMoney frmPayMoney = new FormPayMoney(mRoomNo);
                    if (frmPayMoney.ShowDialog() == DialogResult.OK)
                    {
                        ShowRoom(mRoomNo.FloorInfo.FloorId);
                    }
                }
                else
                {
                    cmn.Show("非占用房间无法使用本功能.");
                }
            }
        }

        private void tsChangePsw_Click(object sender, EventArgs e)
        {
            FormChangePsw frmCpsw = new FormChangePsw();
            frmCpsw.Show();
        }

        private void tsExitSys_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbtnSysSet_Click(object sender, EventArgs e)
        {
            FormControl frmCtrl = new FormControl();
            if (frmCtrl.ShowDialog() == DialogResult.OK)
            {
                listSysParameter = bSysParameter.GetSysParameter(null, oCtrl.EmptyCtrl);
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        /// <summary>
        /// 保存备注信息.如房间已近入住,则备注保存于CUSTOMER_STAY_INFO 的notice,否则保存到BAS_ROOM_INFO 的ROOM_NOTICE栏位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbtnSaveNotice_Click(object sender, EventArgs e)
        {
            if (txtNotice.Tag != null && cmn.Confirm("保存备注?"))
            {
                if (txtNotice.Tag.ToString() == "E")
                {
                    BasRoomModel mr = new BasRoomModel();
                    mr.RoomId = int.Parse(txtNotice.AccessibleName);
                    mr.RoomNotice = txtNotice.Text;
                    mr.CommonInfo.UpdateUserId = UserInfo.UserId;
                    bRoomInfo.UpdateRoomInfo(mr, new ObjectControls(MCtrl.SetNotice));
                }
                else
                {
                    CustomerStayModel mcs = new CustomerStayModel();
                    mcs.StayId = int.Parse(txtNotice.Tag.ToString());
                    mcs.Notice = txtNotice.Text;
                    mcs.CommonInfo.UpdateUserId = UserInfo.UserId;
                    bStay.UpdateCustomerStay(mcs, new ObjectControls(MCtrl.SetNotice));
                }
                cmn.Show("保存完毕!");
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        #endregion

        #region 主界面展示

        private PictureBox GetSelectPBX(Point pt)
        {
            Point pt1 = tbcRoomInfo.TabPages[tbcRoomInfo.SelectedIndex].PointToClient(ptcts);
            PictureBox ctrl = tbcRoomInfo.TabPages[tbcRoomInfo.SelectedIndex].GetChildAtPoint(pt1) as PictureBox;
            return ctrl;
        }

        private Image SelectRoomImage(char cStatus)
        {
            switch (cStatus)
            {
                case 'E':
                    return Properties.Resources.EnableRoom;
                case 'I':
                    return Properties.Resources.InRoom;
                case 'C':
                    return Properties.Resources.CleanRoom;
                case 'D':
                    return Properties.Resources.DisableRoom;
                case 'O':
                    return Properties.Resources.OrderRoom;
                case 'T':
                    return Properties.Resources.OccupyRoom;
                default:
                    return Properties.Resources.DefaultRoom;
            }
        }

        private BasRoomModel GetKeyRoomNo()
        {
            FormKeyRoomNo frmKeyRoomNo = new FormKeyRoomNo();
            if (frmKeyRoomNo.ShowDialog() == DialogResult.OK)
            {
                return listAllRoomInfo.Where(c => c.RoomNo == frmKeyRoomNo.sRoomNo).FirstOrDefault();
            }
            return null;
        }

        private BasRoomModel GetSelectRoomNo(PictureBox pb)
        {
            if (pb != null)
            {
                return listAllRoomInfo.Where(c => c.RoomNo == pb.Name).FirstOrDefault();
            }
            return null;
        }

        private void peh(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            switch (DigiStatus(pic.Name, pic.AccessibleDescription))
            {
                case "1":
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Blue), pic.Width / 5, pic.Height - 15);
                    break;
                case "2":
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.DarkOrange), pic.Width / 5, pic.Height - 15);
                    break;
                case "3":
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Red), pic.Width / 5, pic.Height - 15);
                    break;
                default:
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10), new SolidBrush(Color.Black), pic.Width / 4, pic.Height - 15);
                    break;
            }
        }

        protected void pbMouseEnter(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            //foreach (Control ct in tbcRoomInfo.SelectedTab.Controls)
            //{
            //    if (ct.Size.Width == 35)
            //    {
            //        ct.Size = new Size(32, 64);
            //    }
            //    break;
            //}
            pb.Size = new Size(35, 68);
        }

        protected void pbMouseLeave(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(32, 64);
        }

        private void pbtnOne_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(51, 51);
        }

        private void pbtnOne_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(48, 48);
        }

        protected void pbClick(Object sender, EventArgs e)
        {
            try
            {
                PictureBox pb = (PictureBox)sender;
                Clickedpb = pb;
                CustomerStayModel mCustomerStay = hml.GetStayInRoomInfo(new BasRoomModel(int.Parse(pb.Tag.ToString())), 'I', "M");
                dgvPayDetail.Rows.Clear();
                if (mCustomerStay != null)
                {
                    GetCustomerStayJF(mCustomerStay, IsCountPhone);
                    BindConsumeDetail(mCustomerStay.ConSumeDetailList);
                    lblName.Text = mCustomerStay.CustomerList[0].Name;
                    lblRoomType.Text = mCustomerStay.RoomInfo.RoomTypeDesc;
                    lblDefaultRate.Text = mCustomerStay.RoomInfo.RoomRate + "元";
                    lblCurrRate.Text = mCustomerStay.RoomRate + "元";
                    lblDeposit.Text = mCustomerStay.Deposit + "元";
                    lblUsedHours.Text = hml.GetUsedDays(mCustomerStay.CommonInfo.StartDate);
                    lblTotal.Text = hml.GetTotalRates(mCustomerStay, mCustomerStay.ConSumeDetailList, listSysParameter, cmn.DateBaseDate, dCurrentJf).ToString("0.0") + "元";
                    lblStartDate.Text = mCustomerStay.CommonInfo.StartDate.ToString("MM-dd HH:mm:ss");
                    lblPhone.Text = mCustomerStay.RoomInfo.RoomPhone;
                    txtNotice.Text = mCustomerStay.Notice;
                    txtNotice.Tag = mCustomerStay.StayId;
                }
                else
                {
                    lblName.Text = string.Empty;
                    lblTotal.Text = string.Empty;
                    lblDeposit.Text = string.Empty;
                    lblUsedHours.Text = string.Empty;
                    lblStartDate.Text = string.Empty;
                    var query = listAllRoomInfo.Where(c => c.RoomNo == pb.Name).First();
                    lblDefaultRate.Text = query.RoomRate.ToString();
                    lblRoomType.Text = query.RoomTypeDesc;
                    lblCurrRate.Text = 0.0 + "元";
                    lblPhone.Text = query.RoomPhone;
                    txtNotice.Text = query.RoomNotice;
                    txtNotice.AccessibleName = query.RoomId.ToString();
                    txtNotice.Tag = "E";
                }
                if (!string.IsNullOrEmpty(txtNotice.Text))
                {
                    tbcRoomDetail.SelectedTab = tbcRoomDetail.TabPages[1];
                    txtNotice.ForeColor = Color.Red;
                }
                else
                {
                    tbcRoomDetail.SelectedTab = tbcRoomDetail.TabPages[0];
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        /// <summary>
        /// 获取电话清单
        /// </summary>
        /// <param name="mcs"></param>
        /// <param name="IsCountJF"></param>
        private void  GetCustomerStayJF(CustomerStayModel mcs,bool IsCountJF)
        {
            if (IsCountPhone)
            {
                JFModel mJf = new JFModel();
                mJf.CommonInfo.StartDate = mcs.CommonInfo.StartDate;
                mJf.CommonInfo.EndDate = cmn.DateBaseDate;
                mJf.PhoneNoGroup = cmn.MakeGroup(mcs.RoomInfo.RoomPhone);
                mJf.CatList = listCat;
                listJf = hml.GetPhoneList(mJf, mJf.CommonInfo.EndDate);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cmn.Confirm("确定退出系统?"))
            {
                e.Cancel = true;
            }
        }

        private void ctmsFunction_Opening(object sender, CancelEventArgs e)
        {
            ptcts = new Point(ctmsFunction.Left, ctmsFunction.Top);
            PictureBox ctrl = GetSelectPBX(ptcts);
            if (ctrl != null)
            {
                var query = listAllRoomInfo.Where(c => c.RoomNo == ctrl.Name);
                if (query.Count() > 0)
                {
                    ContentMenuState(query.First().Status);
                    pbClick(ctrl, new EventArgs());
                }
            }
        }

        private void tbcRoomInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcRoomInfo.SelectedTab != null)
            {
                ShowRoom(int.Parse(tbcRoomInfo.SelectedTab.Name));
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtFastSearch.Text.Trim()))
            {
                var query = listAllRoomInfo.Where(c => c.RoomNo.Contains(txtFastSearch.Text.Trim().ToUpper()));
                if (query.Count() > 0)
                {
                    tbcRoomInfo.SelectedTab = tbcRoomInfo.TabPages[query.First().FloorInfo.FloorId.ToString()];
                    foreach (Control ct in tbcRoomInfo.SelectedTab.Controls)
                    {
                        if (ct.Name == txtFastSearch.Text.Trim())
                        {
                            PictureBox pb = ct as PictureBox;
                            pb.Size = new Size(35, 68);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 根据房间状态去显示房间的菜单.
        /// </summary>
        /// <param name="cStatus">房间状态</param>
        private void ContentMenuState(char cStatus)
        {
            for (int i = 0; i < ctmsFunction.Items.Count; i++)
            {
                ctmsFunction.Items[i].Enabled = false;
            }
            switch (cStatus)
            {
                case 'E'://可用
                    ctmsFunction.Items["tsmOneOpenRoom"].Enabled = true;
                    ctmsFunction.Items["tsmTeamOpenRoom"].Enabled = true;
                    ctmsFunction.Items["tsmChangeRoomState"].Enabled = true;
                    ctmsFunction.Items["tsmCustomerOrder"].Enabled = true;
                    break;
                case 'D'://停用
                    ctmsFunction.Items["tsmChangeRoomState"].Enabled = true;
                    ctmsFunction.Items["tsmCustomerOrder"].Enabled = true;
                    break;
                case 'I'://入住
                    for (int i = 0; i < ctmsFunction.Items.Count; i++)
                    {
                        ctmsFunction.Items[i].Enabled = true;
                    }
                    ctmsFunction.Items["tsmOneOpenRoom"].Enabled = false;
                    break;
                case 'C'://清理
                    ctmsFunction.Items["tsmOneOpenRoom"].Enabled = true;
                    ctmsFunction.Items["tsmTeamOpenRoom"].Enabled = true;
                    ctmsFunction.Items["tsmChangeRoomState"].Enabled = true;
                    ctmsFunction.Items["tsmCustomerOrder"].Enabled = true;
                    break;
                case 'O'://预定
                    ctmsFunction.Items["tsmOneOpenRoom"].Enabled = true;
                    ctmsFunction.Items["tsmTeamOpenRoom"].Enabled = true;
                    ctmsFunction.Items["tsmChangeRoomState"].Enabled = true;
                    ctmsFunction.Items["tsmCustomerOrder"].Enabled = true;
                    break;
                case 'T'://团队
                    for (int i = 0; i < ctmsFunction.Items.Count; i++)
                    {
                        ctmsFunction.Items[i].Enabled = true;
                    }
                    ctmsFunction.Items["tsmOneOpenRoom"].Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ShowRoom(int nFloorId)
        {
            if (nFloorId > 0)
            {
                GetRoomByFloor(nFloorId);
            }
            else
            {
                tbcRoomInfo.TabPages.Clear();
                List<BasFloorModel> listFloorInfo = new List<BasFloorModel>();
                BasFloorInfo bFloor = new BasFloorInfo();
                listFloorInfo = bFloor.GetFloorInfo();
                foreach (BasFloorModel mFloor in listFloorInfo)
                {
                    TabPage tp = new TabPage(mFloor.FloorName);
                    tp.Name = mFloor.FloorId.ToString();
                    tp.BackColor = Color.White;
                    tbcRoomInfo.TabPages.Add(tp);
                    GetRoomByFloor(mFloor.FloorId);
                }
            }
            listAllRoomInfo = bRoomInfo.GetRoomInfo(null, oCtrl.EmptyCtrl);
            if (cmn.CheckEOF(listAllRoomInfo))
            {
                double dUsed = listAllRoomInfo.Where(c => c.Status == 'I' || c.Status == 'T').Count();
                double dTotalCount = listAllRoomInfo.Count();
                lblTotalCount.Text = dTotalCount.ToString();
                lblUsed.Text = dUsed.ToString();
                lblOrdered.Text = listAllRoomInfo.Where(c => c.Status == 'O').Count().ToString();
                lblCleaning.Text = listAllRoomInfo.Where(c => c.Status == 'C').Count().ToString();
                lblEnable.Text = listAllRoomInfo.Where(c => c.Status == 'E').Count().ToString();
                lblDisable.Text = listAllRoomInfo.Where(c => c.Status == 'D').Count().ToString();
                lblUseRate.Text = dTotalCount == 0 ? "0%" : (dUsed / dTotalCount).ToString("0.0%");
            }
            if (Clickedpb != null)
            {
                pbClick(Clickedpb, new EventArgs());
            }
            tmAutoSetStayRate_Tick(null, null);
        }

        private void GetRoomByFloor(int nFloorId)
        {
            if (tbcRoomInfo.TabCount > 0)
            {
                tbcRoomInfo.TabPages[nFloorId.ToString()].Controls.Clear();
            }
            BasRoomModel mRoomInfo = new BasRoomModel();
            mRoomInfo.FloorInfo = new BasFloorModel();
            mRoomInfo.FloorInfo.FloorId = nFloorId;
            oCtrl.Reset();
            oCtrl.Add(MCtrl.ByFloorId);
            List<BasRoomModel> listRoomInfo = bRoomInfo.GetRoomInfo(mRoomInfo, oCtrl);

            if (IsConnectDigiLock)
            {
                DigiRoomList = bDigiLock.GetPhoneDetail();
            }
            double dCleanTime = double.Parse(hml.ToParameter(listSysParameter, "DEFAULT_CLEAN_TIME").Value1);//退房后一段时间内默认为清理时间.单位为分钟
            for (int i = 0; i < listRoomInfo.Count; i++)
            {
                PictureBox pc = new PictureBox();

                //如果超过清理时间,则将房间状态更新为E (listRoomInfo[i].Status == 'O' && !cmn.CheckEOF(hml.GetRoomOrder(listRoomInfo[i])
                if ((listRoomInfo[i].Status == 'C' && dCleanTime > 0 &&
                    cmn.DateBaseDate.Subtract(listRoomInfo[i].CommonInfo.UpdateDate).TotalMinutes
                    >= dCleanTime))// && hml.GetCustomerStayInfoByRoom(listRoomInfo[i], 'I') == null
                {
                    listRoomInfo[i].Status = 'E';
                    hml.UpdateRoomStatusByRoomId(listRoomInfo[i], UserInfo);
                }
                pc.BackgroundImage = SelectRoomImage(listRoomInfo[i].Status);
                pc.AccessibleDescription = listRoomInfo[i].Status.ToString();
                pc.BackgroundImageLayout = ImageLayout.Zoom;
                pc.Tag = listRoomInfo[i].RoomId.ToString();
                pc.Name = listRoomInfo[i].RoomNo;
                pc.Size = new Size(32, 64);
                pc.Cursor = Cursors.Hand;
                pc.ContextMenuStrip = ctmsFunction;
                pc.Paint += new PaintEventHandler(peh);
                pc.MouseEnter += new EventHandler(pbMouseEnter);
                pc.MouseLeave += new EventHandler(pbMouseLeave);
                pc.Click += new EventHandler(pbClick);
                pc.Location = new Point(tbcRoomInfo.Location.X + (i % 19) * (pc.Size.Width + 10), tbcRoomInfo.Location.Y + Convert.ToInt32(i / 19) * (pc.Size.Height + 5));
                tbcRoomInfo.TabPages[nFloorId.ToString()].Controls.Add(pc);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        } 

        private void BindConsumeDetail(List<ConsumeDetailModel> listSource)
        {
            for (int i = 0; i < listSource.Count; i++)
            {
                dgvPayDetail.Rows.Add();
                dgvPayDetail.Rows[i].Cells["ConsumeName"].Value = listSource[i].GoodsInfo.GoodsName;
                dgvPayDetail.Rows[i].Cells["UnitPrice"].Value = listSource[i].UnitPrice;
                dgvPayDetail.Rows[i].Cells["Number"].Value = listSource[i].Number;
                dgvPayDetail.Rows[i].Cells["ConsumePrice"].Value = listSource[i].Total;
                dgvPayDetail.Rows[i].Cells["CreateDate"].Value = listSource[i].CommonInfo.CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                dgvPayDetail.Rows[i].Cells["CreateUserName"].Value = listSource[i].CommonInfo.CreateUserName;
            }
            if (cmn.CheckEOF(listJf))
            {
                dCurrentJf = hml.GetPhoneJF(listJf, listCat);
                if (dCurrentJf > 0)
                {
                    int i = dgvPayDetail.Rows.Count;
                    dgvPayDetail.Rows.Add();
                    dgvPayDetail.Rows[i].Cells["ConsumeName"].Value = "话费";
                    dgvPayDetail.Rows[i].Cells["ConsumePrice"].Value = dCurrentJf;
                }
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerStayInfo bs = new CustomerStayInfo();
            CustomerStayModel mcs = new CustomerStayModel();
            mcs.Status = 'O';
            oCtrl.Reset();
            oCtrl.Add(MCtrl.ByStayStatus);
            List<CustomerStayModel> listC =bs.GetCustomerStayList(mcs, oCtrl);
            foreach (CustomerStayModel m in listC)
            {
                foreach (CustomerModel c in m.CustomerList)
                {
                    if (c.CustomerStayHisInfo.HisStatus == 'E')
                    {
                        c.CustomerStayHisInfo.CommonInfo.EndDate = m.CommonInfo.EndDate;
                        bs.UpdateStayHis(c.CustomerStayHisInfo, new ObjectControls(MCtrl.SetEndDate));
                    }
                }
            }

            bs = new CustomerStayInfo();
            mcs = new CustomerStayModel();
            mcs.Status = 'I';
            oCtrl.Reset();
            oCtrl.Add(MCtrl.ByStayStatus);
            listC = bs.GetCustomerStayList(mcs, oCtrl);
            foreach (CustomerStayModel m in listC)
            {
                foreach (CustomerModel c in m.CustomerList)
                {
                    if (c.CustomerStayHisInfo.HisStatus == 'E')
                    {
                        c.CustomerStayHisInfo.CommonInfo.EndDate = m.CommonInfo.EndDate;
                        bs.UpdateStayHis(c.CustomerStayHisInfo, new ObjectControls(MCtrl.SetEndDate));
                    }
                }
            }
        }

        private void tsChangeSkin_Click(object sender, EventArgs e)
        {
            FormSetSkin frmSetSkin = new FormSetSkin();
            frmSetSkin.Owner = this;
            frmSetSkin.ShowDialog();
            sk.ApplyAdditionalBuiltInSkins(UserInfo.SkinId);
            //sk.ApplyAdditionalBuiltInSkins(UserInfo.SkinId);
           // skinEngine1.ApplyAdditionalBuiltInSkins(UserInfo.SkinId);
        }

        private void tmAutoSetStayRate_Tick(object sender, EventArgs e)
        {
            StayRateModel mStayRate = new StayRateModel();
            mStayRate.StayRate = double.Parse(lblUseRate.Text.Replace("%", ""));
            mStayRate.Days = cmn.DateBaseDate.Date;
            hml.DoStayRate(mStayRate);
        }

    }
}
