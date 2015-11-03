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
using System.Threading;

namespace Hotel
{
    public partial class FormInComeRpt : BaseForm
    {
        private CustomerStayInfo bCustomerStay = new CustomerStayInfo();
        private HotelMainLogic hml = new HotelMainLogic();
        private PrintInfo bPrint = new PrintInfo();
        private List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();
        private List<SysLookupCodeModel> listCode = new List<SysLookupCodeModel>();

        int nSelectedRowIndex = -1;
        public FormInComeRpt()
        {
            InitializeComponent();
        }

        private void FormInComeRpt_Load(object sender, EventArgs e)
        {
            BindHour();
            listCode = new HotelMainLogic().GetCodeDesc("CUSTOMER_STAY_INFO", "PAY_TYPE");
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
        }

        private void pbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerStayModel mCustomerStay = new CustomerStayModel();
                mCustomerStay.CommonInfo.StartDate = GetDateTimePickValue(dtpStart, cboHourS);
                mCustomerStay.CommonInfo.EndDate = GetDateTimePickValue(dtpEnd, cboHourE);
                mCustomerStay.Status = 'O';
                ObjectControls oCtrl = new ObjectControls();

                mCustomerStay.CustomerList = new List<CustomerModel>();
                CustomerModel mc = new CustomerModel();
                mc.CustomerStayHisInfo = new CustomerStayHisModel();
                //mc.CustomerStayHisInfo.StayType = 'M';
                mc.CustomerStayHisInfo.HisStatus = 'O';//取离店宾客入住历史记录.
                mCustomerStay.CustomerList.Add(mc);

                oCtrl.Add(MCtrl.ByStayStatus);
                oCtrl.Add(MCtrl.ByHisStatus);
                oCtrl.Add(MCtrl.ByUpdateDate);
                listCustomerStay = bCustomerStay.GetCustomerStayList(mCustomerStay, oCtrl);
                BindDgv(listCustomerStay);
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void BindDgv(List<CustomerStayModel> listCustomerStay)
        {
            dgvIncomeInfo.Rows.Clear();
            int i = 0;
            double dPaidMoney = 0.0;
            double dTotalMoney = 0.0;
            foreach (CustomerStayModel mCs in listCustomerStay)
            {
                dgvIncomeInfo.Rows.Add();

                dgvIncomeInfo.Rows[i].Cells["StayId"].Value = mCs.StayId;
                dgvIncomeInfo.Rows[i].Cells["StayNo"].Value = mCs.StayNo;
                dgvIncomeInfo.Rows[i].Cells["RoomNo"].Value = mCs.RoomInfo.RoomNo;
                string sName="";
                foreach (CustomerModel mc in mCs.CustomerList)
                {
                    sName += mc.Name + ";";
                }
                dgvIncomeInfo.Rows[i].Cells["CustomerName"].Value = sName.Remove(sName.Length - 1, 1);
                dgvIncomeInfo.Rows[i].Cells["StartDate"].Value = mCs.CommonInfo.StartDate;
                dgvIncomeInfo.Rows[i].Cells["EndDate"].Value = mCs.CommonInfo.EndDate;
                dgvIncomeInfo.Rows[i].Cells["PaidMoney"].Value = mCs.PaidMoney;
                dgvIncomeInfo.Rows[i].Cells["PayType"].Value = GetPayDesc(mCs.PayType.ToString());
                dgvIncomeInfo.Rows[i].Cells["Total"].Value = mCs.Total;
                dgvIncomeInfo.Rows[i].Cells["Notice"].Value = mCs.Notice;
                RoomStayType eRst = mCs.RoomStayType == 'D' ? RoomStayType.Day : RoomStayType.Hour;
                dgvIncomeInfo.Rows[i].Cells["Days"].Value = hml.GetCustomerStayDays(mCs.CommonInfo.StartDate, mCs.CommonInfo.EndDate, mCs.CommonInfo.EndDate, eRst, listSysParameter);
                dgvIncomeInfo.Rows[i].Cells["UpdateUserName"].Value = mCs.CommonInfo.UpateUserName;
                dgvIncomeInfo.Rows[i].Cells["UpdateDate"].Value = mCs.CommonInfo.UpdateDate;
                dPaidMoney += mCs.PaidMoney;
                dTotalMoney += mCs.Total;
                i++;
            }
            tsslblTotal.Text = "合计收取现金:   " + dPaidMoney + "元" + "    合计应收金额:" + dTotalMoney + "元";
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

        private void pbt_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            switch (pic.Name)
            {
                case "pbtnSearch":
                    e.Graphics.DrawString("查询", new Font("宋体", 10), new SolidBrush(Color.Black), 5, pic.Height - 12);
                    break;

                case "pbtnPrint":
                    e.Graphics.DrawString("打印", new Font("宋体", 10), new SolidBrush(Color.Black), 5, pic.Height - 12);
                    break;

                case "pbtnExcel":
                    e.Graphics.DrawString("EXCEL", new Font("宋体", 10), new SolidBrush(Color.Black), 5, pic.Height - 12);
                    break;
            }
        }

        private void pbtnPrint_Click(object sender, EventArgs e)
        {
            if (cmn.CheckEOF(listCustomerStay))
            {
                PrintModel mPrint = new PrintModel();
                mPrint = bPrint.GetPrintModel(new PrintModel(this.Name), new ObjectControls(MCtrl.ByPrintNo));
                CommonModel mComm=new CommonModel ();
                mComm.StartDate=GetDateTimePickValue(dtpStart, cboHourS);
                mComm.EndDate= GetDateTimePickValue(dtpEnd, cboHourE);
                mPrint = bPrint.GetPrintSet(mPrint,new Object[]{UserInfo,mComm});
                DataGridViewPrint dgvp = new DataGridViewPrint(new DataGridView[] { dgvIncomeInfo });
                dgvp.GetPrintConfig = mPrint;
                dgvp.Print(true,true);
            }
        }

        private void pbtnExcel_Click(object sender, EventArgs e)
        {
            cmn.ExportExcel(dgvIncomeInfo, true);
        }

        private string GetPayDesc(string sCode)
        {
            var query = listCode.Where(c => c.CodeNo == sCode);
            if (query.Count() > 0)
            {
                return query.First().CodeDesc;
            }
            return "";
        }

        private void dgvIncomeInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    //dgvIncomeInfo.Rows[e.RowIndex].Selected = true;
                    dgvIncomeInfo.ClearSelection();
                    nSelectedRowIndex = e.RowIndex;
                    dgvIncomeInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
            }
        }

        private void tsmPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (nSelectedRowIndex >= 0)
                {
                    var q = listCustomerStay.Where(c => c.StayId == int.Parse(dgvIncomeInfo.Rows[nSelectedRowIndex].Cells["StayId"].Value.ToString())).First();
                    FormConsumeDetail frmConcume = new FormConsumeDetail(q);
                    frmConcume.Show();
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

    }
}
