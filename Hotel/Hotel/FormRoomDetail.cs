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
    public partial class FormRoomDetail : BaseForm
    {

        private BasRoomInfo bRoomInfo = new BasRoomInfo();
        private HotelMainLogic hml = new HotelMainLogic();
        private DigiLockInfo bDigiLock = new DigiLockInfo();

        private List<BasRoomModel> listAllRoomInfo = new List<BasRoomModel>();
        private List<RoomListModel> DigiRoomList = new List<RoomListModel>();
        private List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();
        private List<SysLookupCodeModel> listCodePay = new List<SysLookupCodeModel>();
        private bool IsConnectDigiLock
        {
            get
            {
                return hml.ToParameter(listSysParameter, "DIGILOCK").Value1.Equals("Y") ? true : false;
            }
        }

        public FormRoomDetail()
        {
            InitializeComponent();
        }

        private void LoadUIInfo()
        {
            try
            {
                listCodePay = hml.GetCodeDesc("CUSTOMER_STAY_INFO", "PAY_TYPE");
                BindCbo();
                cboRoomStatus.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
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

        private void BindCbo()
        {
            SysLookUpCodeInfo bCode = new SysLookUpCodeInfo();
            SysLookupCodeModel mCode = new SysLookupCodeModel();
            mCode.TableName = "BAS_ROOM_INFO";
            mCode.ColumnName = "STATUS";
            oCtrl.Reset();
            oCtrl.Add(MCtrl.ByTableName);
            oCtrl.Add(MCtrl.ByColumnName);
            List<SysLookupCodeModel> listRoomCode = bCode.GetSysLookUpCode(mCode, oCtrl);
            if (cmn.CheckEOF(listRoomCode))
            {
                SysLookupCodeModel mc = new SysLookupCodeModel();
                mc.CodeNo = "A";
                mc.CodeDesc = "所有房间";
                listRoomCode.Insert(0, mc);
                cboRoomStatus.DataSource = listRoomCode;
                cboRoomStatus.DisplayMember = "CodeDesc";
                cboRoomStatus.ValueMember = "CodeNo";
            }

            cboPayType.DataSource = listCodePay;
            cboPayType.DisplayMember = "CodeDesc";
            cboPayType.ValueMember = "CodeNo";
        }

        private void GetRoomByStatus(string sCode)
        {
            tbcRoomInfo.TabPages[0].Text = cboRoomStatus.Text;
            tbcRoomInfo.TabPages[0].Controls.Clear();

            List<BasRoomModel> listRoomInfo = new List<BasRoomModel>();
            BasRoomModel mRoomInfo = new BasRoomModel();
            if (cboRoomStatus.SelectedIndex != 0)
            {
                mRoomInfo.Status = cmn.ToChar(sCode);
                oCtrl.Reset();
                oCtrl.Add(MCtrl.ByRoomStatus);
            }
            else
            {
                oCtrl = oCtrl.EmptyCtrl;
            }
            listRoomInfo = bRoomInfo.GetRoomInfo(mRoomInfo, oCtrl);
            listAllRoomInfo = listRoomInfo;
            tslblTotal.Text = cboRoomStatus.Text + " 共计 " + listRoomInfo.Count() + "间房";
            if (IsConnectDigiLock)
            {
                DigiRoomList = bDigiLock.GetPhoneDetail();
            }
            double dCleanTime = double.Parse(hml.ToParameter(listSysParameter, "DEFAULT_CLEAN_TIME").Value1);//退房后一段时间内默认为清理时间.单位为分钟
            List<CustomerStayModel> listAllStayCustomer = new List<CustomerStayModel>();
            listAllStayCustomer = hml.GetStayInRoomInfo(listRoomInfo, 'I', "", false);
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
                pc.BackgroundImageLayout = ImageLayout.Center;
                pc.Tag = listRoomInfo[i].RoomId.ToString();
                pc.Name = listRoomInfo[i].RoomNo;

                if ((listRoomInfo[i].Status == 'I' || listRoomInfo[i].Status == 'T') && cmn.CheckEOF(listAllStayCustomer))
                {
                    var query = listAllStayCustomer.Where(c => c.RoomId == listRoomInfo[i].RoomId);
                    if (query.Count() > 0)
                    {
                        foreach (CustomerModel mc in query.First().CustomerList)
                        {
                            pc.AccessibleName += mc.Name + ";";
                        }
                        pc.AccessibleDescription = query.First().MainRoomId.ToString();
                    }
                }
                pc.AccessibleDefaultActionDescription = listRoomInfo[i].Status.ToString();
                

                pc.Size = new Size(40, 85);
                pc.Cursor = Cursors.Hand;
                pc.ContextMenuStrip = ctmsFunction;
                pc.Paint += new PaintEventHandler(peh);
                pc.MouseEnter += new EventHandler(pbMouseEnter);
                pc.MouseLeave += new EventHandler(pbMouseLeave);
                pc.Click += new EventHandler(pbClick);
                pc.Location = new Point(tbcRoomInfo.Location.X + (i % 12) * (pc.Size.Width + 10), Convert.ToInt32(i / 12) * (pc.Size.Height));
                tbcRoomInfo.TabPages[0].Controls.Add(pc);
            }
        }

        private void peh(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            switch (DigiStatus(pic.Name,pic.AccessibleDefaultActionDescription))
            {
                case "1":
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Blue), pic.Width / 5, pic.Height - 25);
                    break;
                case "2":
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.DarkOrange), pic.Width / 5, pic.Height - 25);
                    break;
                case "3":
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10, FontStyle.Bold), new SolidBrush(Color.Red), pic.Width / 5, pic.Height - 25);
                    break;
                default:
                    e.Graphics.DrawString(pic.Name, new Font("宋体", 10), new SolidBrush(Color.Black), pic.Width / 4, pic.Height - 25);
                    break;
            }
            //e.Graphics.DrawString(pic.Name, new Font("宋体", 10), new SolidBrush(Color.Black), pic.Width / 4, pic.Height - 25);
            if (!string.IsNullOrEmpty(pic.AccessibleName))
            {
                string[] arr = pic.AccessibleName.Split(';');

                if (arr.Count() > 2)
                {
                    for (int i = 0; i < arr.Count(); i++)
                    {
                        if (!string.IsNullOrEmpty(arr[i]))
                        {
                            e.Graphics.DrawString(arr[i].Replace(";",""), new Font("宋体", 9), new SolidBrush(Color.Black), 0, pic.Height - 70 - i * 12);
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawString(pic.AccessibleName.Replace(";", ""), new Font("宋体", 10), new SolidBrush(Color.Black), 0, pic.Height - 73);
                }
            }
        }

        protected void pbMouseEnter(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(40, 87);
        }

        protected void pbMouseLeave(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(40, 85);
        }

        protected void pbClick(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            //if (!string.IsNullOrEmpty(pb.AccessibleDescription) && int.Parse(pb.AccessibleDescription) > 0)
            //{
            foreach (Control c in tabPage1.Controls)
            {
                c.BackColor = Color.White;
                if (!string.IsNullOrEmpty(c.AccessibleDescription)
                    && !string.IsNullOrEmpty(pb.AccessibleDescription)
                    && int.Parse(pb.AccessibleDescription) > 0
                    && c.AccessibleDescription == pb.AccessibleDescription)
                {
                    c.BackColor = Color.BlanchedAlmond;
                }
            }

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

        private void cboRoomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRoomByStatus(cboRoomStatus.SelectedValue.ToString());
        }

        private void FormRoomDetail_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void tsEnable_Click(object sender, EventArgs e)
        {
            PictureBox pb = GetSelectedPbx();
            UpdateRoomStatus(pb.Name,int.Parse(pb.Tag.ToString()), 'E');
        }

        private void tsClean_Click(object sender, EventArgs e)
        {
            PictureBox pb = GetSelectedPbx();
            UpdateRoomStatus(pb.Name,int.Parse(pb.Tag.ToString()), 'C');

        }

        private void tsDisable_Click(object sender, EventArgs e)
        {
            PictureBox pb = GetSelectedPbx();
            UpdateRoomStatus(pb.Name, int.Parse(pb.Tag.ToString()), 'D');

        }

        private void UpdateRoomStatus(string sRoomNo, int nRoomId, char cStatus)
        {
            string sChangeType = "";
            switch (cStatus)
            {
                case 'E':
                    sChangeType = "可用";
                    break;
                case 'D':
                    sChangeType = "停用";
                    break;
                case 'C':
                    sChangeType = "清理";
                    break;
            }
            if (!cmn.Confirm(string.Format("确定更改房间{0}为{1}状态?", sRoomNo, sChangeType)))
            {
                return;
            }
            BasRoomModel mRoom = new BasRoomModel(nRoomId);
            mRoom.Status = cStatus;
            hml.UpdateRoomStatusByRoomId(mRoom, UserInfo);
            GetRoomByStatus(cboRoomStatus.SelectedValue.ToString());
        }

        private void ctmsFunction_Opening(object sender, CancelEventArgs e)
        {
            Point pt1 = tbcRoomInfo.TabPages[0].PointToClient(new Point(ctmsFunction.Left, ctmsFunction.Top));
            PictureBox ctrl = tbcRoomInfo.TabPages[tbcRoomInfo.SelectedIndex].GetChildAtPoint(pt1) as PictureBox;

            if (ctrl != null)
            {
                var query = listAllRoomInfo.Where(c => c.RoomNo == ctrl.Name);
                if (query.Count() > 0 && (query.First().Status == 'I' || query.First().Status == 'T'))
                {
                    ctmsFunction.Enabled = false;
                }
                else
                {
                    ctmsFunction.Enabled = true;
                }
            }
        }

        private PictureBox GetSelectedPbx()
        {
            Point pt1 = tbcRoomInfo.TabPages[0].PointToClient(new Point(ctmsFunction.Left, ctmsFunction.Top));
            PictureBox ctrl = tbcRoomInfo.TabPages[tbcRoomInfo.SelectedIndex].GetChildAtPoint(pt1) as PictureBox;
            return ctrl;
        }

        private void FormRoomDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void tbcRoomInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcRoomInfo.SelectedIndex == 1 && !cmn.CheckEOF(listCustomerStay))
            {
                listCustomerStay = hml.GetCustomerDepositDetail(cmn.ToChar(cboPayType.SelectedValue), listSysParameter, cmn.DateBaseDate);
                BindCustomerStay();
            }
        }

        private void BindCustomerStay()
        {
            dgvCustomerStay.Rows.Clear();
            int i = 0;
            foreach (CustomerStayModel mCs in listCustomerStay)
            {
                dgvCustomerStay.Rows.Add();
                dgvCustomerStay.Rows[i].Cells["RoomNo"].Value = mCs.RoomInfo.RoomNo;
                if (mCs.Status == 'I')
                {
                    dgvCustomerStay.Rows[i].Cells["StayStatus"].Value = "在住";
                }
                else
                {
                    dgvCustomerStay.Rows[i].Cells["StayStatus"].Value = "离店";
                    RoomStayType eRst = mCs.RoomStayType == 'D' ? RoomStayType.Day : RoomStayType.Hour;
                }
                dgvCustomerStay.Rows[i].Cells["UpdateUserName"].Value = mCs.CommonInfo.UpateUserName;
                dgvCustomerStay.Rows[i].Cells["UpdateDate"].Value = mCs.CommonInfo.UpdateDate;
                dgvCustomerStay.Rows[i].Cells["CustomerName"].Value = mCs.CustomerList[0].Name;
                dgvCustomerStay.Rows[i].Cells["StartDate"].Value = mCs.CommonInfo.StartDate;
                dgvCustomerStay.Rows[i].Cells["Deposit"].Value = mCs.Deposit;
                dgvCustomerStay.Rows[i].Cells["NeedPay"].Value = mCs.Total;
                dgvCustomerStay.Rows[i].Cells["Balance"].Value = mCs.Deposit - mCs.Total;
                dgvCustomerStay.Rows[i].Cells["PayType"].Value = GetPayDesc(mCs.PayType.ToString());
                dgvCustomerStay.Rows[i].Cells["Notice"].Value = mCs.Notice;
                if (mCs.Deposit - mCs.Total <= 0 || ((mCs.Deposit > 0) && mCs.Total / mCs.Deposit >= double.Parse(hml.ToParameter(listSysParameter, "MAX_DEPOSIT_RATE").Value1)))
                {
                    dgvCustomerStay.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                i++;
            }
        }

        private string GetPayDesc(string sCode)
        {
            var query = listCodePay.Where(c => c.CodeNo == sCode);
            if (query.Count() > 0)
            {
                return query.First().CodeDesc;
            }
            return "";
        }

        private void cboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCustomerStay = hml.GetCustomerDepositDetail(cmn.ToChar(cboPayType.SelectedValue), listSysParameter, cmn.DateBaseDate);
            BindCustomerStay();
        }
    }
}
