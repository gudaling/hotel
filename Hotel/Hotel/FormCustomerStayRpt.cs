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
    public partial class FormCustomerStayRpt : BaseForm
    {
        private List<SysLookupCodeModel> listCode = new List<SysLookupCodeModel>();
        private List<SysLookupCodeModel> listCodePay = new List<SysLookupCodeModel>();

        private HotelMainLogic hml = new HotelMainLogic();
        private CustomerStayInfo bCustomerStay = new CustomerStayInfo();

        public FormCustomerStayRpt()
        {
            InitializeComponent();
        }

        private void FormCustomerStayRpt_Load(object sender, EventArgs e)
        {
            dtpStart.Enabled = false;
            dtpEnd.Enabled = false;
            cboHourS.Enabled = false;
            cboHourE.Enabled = false;
            lblStart.Text = "入住/离店起始时间";
            lblEnd.Text = "入住/离店结束时间";
            listCode = hml.GetCodeDesc("CUSTOMER_STAY_INFO", "STATUS");
            listCodePay = hml.GetCodeDesc("CUSTOMER_STAY_INFO", "PAY_TYPE");
            BindCbo();
            BindHour();
            rptHelper1.GridViewSource = dgvCustomerStay;
            rptHelper1.PrintVisible = false;
        }

        private void BindCbo()
        {
            SysLookupCodeModel mCode = new SysLookupCodeModel();
            mCode.CodeNo = "A";
            mCode.CodeDesc = "所有宾客";
            listCode.Insert(0, mCode);
            cboStayStaus.DataSource = listCode;
            cboStayStaus.DisplayMember = "CodeDesc";
            cboStayStaus.ValueMember = "CodeNo";
        }

        private void BindHour()
        {
            for (int i = 0; i < 24; i++)
            {
                cboHourS.Items.Add(i);
                cboHourE.Items.Add(i);
            }
            cboHourS.SelectedIndex = 0;
            cboHourE.SelectedIndex = 23;
            dtpStart.CustomFormat = "yyyy-MM-dd";
            dtpEnd.CustomFormat = "yyyy-MM-dd";
            dtpStart.Value = dtpEnd.Value.AddDays(-1);
        }

        private void BindDgv(List<CustomerStayModel> listCustomerStay)
        {
            dgvCustomerStay.Rows.Clear();
            int i = 0;
            DateTime dtmNow = cmn.DateBaseDate;
            foreach (CustomerStayModel mCs in listCustomerStay)
            {
                foreach (CustomerModel mc in mCs.CustomerList)
                {
                    dgvCustomerStay.Rows.Add();

                    dgvCustomerStay.Rows[i].Cells["StayNo"].Value = mCs.StayNo;
                    dgvCustomerStay.Rows[i].Cells["RoomNo"].Value = mCs.RoomInfo.RoomNo;
                    RoomStayType eRst = mCs.RoomStayType == 'D' ? RoomStayType.Day : RoomStayType.Hour;
                    if (mc.CustomerStayHisInfo.HisStatus == 'E')
                    {
                        dgvCustomerStay.Rows[i].Cells["StayStatus"].Value = "在住";

                        //dgvCustomerStay.Rows[i].Cells["Days"].Value = hml.GetCustomerStayDays(mc.CustomerStayHisInfo.CommonInfo.StartDate, mc.CustomerStayHisInfo.CommonInfo.EndDate, dtmNow, eRst, listSysParameter);
                        dgvCustomerStay.Rows[i].Cells["UpdateUserName"].Value = mCs.CommonInfo.UpateUserName;
                        dgvCustomerStay.Rows[i].Cells["UpdateDate"].Value = mCs.CommonInfo.UpdateDate;
                        dgvCustomerStay.Rows[i].Cells["Days"].Value = hml.GetCustomerStayDays(mc.CustomerStayHisInfo.CommonInfo.StartDate, dtmNow, dtmNow, eRst, listSysParameter);

                    }
                    else
                    {
                        dgvCustomerStay.Rows[i].Cells["StayStatus"].Value = "离店";
                        //RoomStayType eRst = mCs.RoomStayType == 'D' ? RoomStayType.Day : RoomStayType.Hour;
                        dgvCustomerStay.Rows[i].Cells["UpdateUserName"].Value = mCs.CommonInfo.UpateUserName;
                        dgvCustomerStay.Rows[i].Cells["UpdateDate"].Value = mCs.CommonInfo.UpdateDate;
                        dgvCustomerStay.Rows[i].Cells["Days"].Value = hml.GetCustomerStayDays(mc.CustomerStayHisInfo.CommonInfo.StartDate, mc.CustomerStayHisInfo.CommonInfo.EndDate, dtmNow, eRst, listSysParameter);

                        //dgvCustomerStay.Rows[i].Cells["StartDate"].Value = mc.CustomerStayHisInfo.CommonInfo.CreateDate;
                        //dgvCustomerStay.Rows[i].Cells["EndDate"].Value = mc.CustomerStayHisInfo.CommonInfo.UpdateDate;
                        //dgvCustomerStay.Rows[i].Cells["Days"].Value = hml.GetCustomerStayDays(mc.CustomerStayHisInfo.CommonInfo.CreateDate, mc.CustomerStayHisInfo.CommonInfo.UpdateDate, dtmNow, eRst, listSysParameter);
                    }
                    dgvCustomerStay.Rows[i].Cells["StartDate"].Value = mc.CustomerStayHisInfo.CommonInfo.StartDate;
                    dgvCustomerStay.Rows[i].Cells["EndDate"].Value = mc.CustomerStayHisInfo.CommonInfo.EndDate;

                    dgvCustomerStay.Rows[i].Cells["CustomerName"].Value = mc.Name;
                    dgvCustomerStay.Rows[i].Cells["Sex"].Value = mc.Sex;
                    dgvCustomerStay.Rows[i].Cells["CardID"].Value = mc.IdCardNo;

                    dgvCustomerStay.Rows[i].Cells["Deposit"].Value = mCs.Deposit;
                    dgvCustomerStay.Rows[i].Cells["PayType"].Value = GetPayDesc(mCs.PayType.ToString());
                    dgvCustomerStay.Rows[i].Cells["Notice"].Value = mCs.Notice;
                    i++;
                }
            }
        }

        private void pbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerStayModel mCustomerStay = new CustomerStayModel();
                oCtrl.Reset();
                mCustomerStay.ConSumeDetailList = new List<ConsumeDetailModel>();
                CustomerModel mCustomer = new CustomerModel();
                mCustomer.Name = txtCondition.Text;


                mCustomerStay.RoomInfo = new BasRoomModel();
                mCustomerStay.RoomInfo.RoomNo = txtCondition.Text;

                if (!string.IsNullOrEmpty(txtCondition.Text))
                {
                    oCtrl.Add(MCtrl.ByNPR);
                }
                if (cboStayStaus.SelectedIndex != 0)//如果选择在住或者离店
                {
                    //mCustomerStay.Status = cmn.ToChar(cboStayStaus.SelectedValue);
                    mCustomer.CustomerStayHisInfo.HisStatus = cmn.ToChar(cboStayStaus.SelectedValue) == 'I' ? 'E' : 'O';
                    oCtrl.Add(MCtrl.ByHisStatus);
                    //oCtrl.Add(MCtrl.ByStayStatus);
                }
                else//如果选择所有,则查询his中状态不为D的宾客.E为在住,O为离店.D为删除的用户.没有意义.
                {
                    //mCustomerStay.Status = cmn.ToChar(cboStayStaus.SelectedValue);
                    mCustomer.CustomerStayHisInfo.HisStatus = 'D';
                    oCtrl.Add(MCtrl.ByHisStatusNotEqual);
                }
                if (chkByDateTime.Checked)
                {
                    mCustomer.CustomerStayHisInfo.CommonInfo.StartDate = GetDateTimePickValue(dtpStart, cboHourS);
                    mCustomer.CustomerStayHisInfo.CommonInfo.EndDate = GetDateTimePickValue(dtpEnd, cboHourE);
                    if (mCustomer.CustomerStayHisInfo.HisStatus == 'E')
                    {
                        oCtrl.Add(MCtrl.ByHisStartTime);
                    }
                    else if (mCustomer.CustomerStayHisInfo.HisStatus == 'O')
                    {
                        oCtrl.Add(MCtrl.ByHisEndTime);
                    }
                    else
                    {
                        oCtrl.Add(MCtrl.ByHisStartOrEndTime);
                    }
                }
                mCustomerStay.CustomerList.Add(mCustomer);
                List<CustomerStayModel> listCustomerStay = bCustomerStay.GetCustomerStayList(mCustomerStay, oCtrl);
                BindDgv(listCustomerStay);
            }
            catch (Exception err)
            {
                tslblMsg.Text = err.Message;
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

        private void chkByDateTime_CheckedChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = chkByDateTime.Checked;
            dtpEnd.Enabled = chkByDateTime.Checked;
            cboHourS.Enabled = chkByDateTime.Checked;
            cboHourE.Enabled = chkByDateTime.Checked;
        }

        private void cboStayStaus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStayStaus.SelectedIndex == 0)
            {
                lblStart.Text = "入住/离店起始时间";
                lblEnd.Text = "入住/离店结束时间";
            }
            else if (cboStayStaus.SelectedIndex == 1)
            {
                lblStart.Text = cboStayStaus.Text + "起始时间";
                lblEnd.Text = cboStayStaus.Text + "结束时间";
            }
            else
            {
                lblStart.Text = cboStayStaus.Text + "起始时间";
                lblEnd.Text = cboStayStaus.Text + "结束时间";
            }
        }

        private void pbtnSearch_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("查询", new Font("宋体", 10), new SolidBrush(Color.Black), 10, pbtnSearch.Height - 12);
        }

        private void pbtn_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(48, 73);
        }

        private void pbtn_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(45, 70);
        }
    }
}
