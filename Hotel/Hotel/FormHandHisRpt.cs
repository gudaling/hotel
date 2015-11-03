using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.BLL;
using Hotel.Model;
using Hotel.Common;

namespace Hotel
{
    public partial class FormHandHisRpt : BaseForm
    {
        private HotelMainLogic hml = new HotelMainLogic();
        private SysUserInfo bUser = new SysUserInfo();
        private HandOverModel mHandOver = new HandOverModel();
        private HandOverInfo bHandOver = new HandOverInfo();
        private PrintInfo bPrint = new PrintInfo();
        private List<SysUserInfoModel> listUser = new List<SysUserInfoModel>();
        private List<HandOverModel> listHandOver = new List<HandOverModel>();
        public FormHandHisRpt()
        {
            InitializeComponent();
        }

        private void BindHour()
        {
            for (int i = 0; i < 24; i++)
            {
                cboHourS.Items.Add(i);
                cboHourE.Items.Add(i);
            }
            cboHourS.SelectedIndex = 7;
            cboHourE.SelectedIndex = 19;

            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "yyyy-MM-dd";
            dtpEnd.CustomFormat = "yyyy-MM-dd";

            dtpStart.Value = cmn.DateBaseDate.AddDays(-1);
            dtpEnd.Value = cmn.DateBaseDate;
        }

        /// <summary>
        /// 绑定系统用户
        /// </summary>
        private void BindUser()
        {
            listUser = bUser.GetUserInfoList();
            foreach (SysUserInfoModel mUser in listUser)
            {
                cboUserList.Items.Add(mUser.UserName);
            }
            cboUserList.Items.Insert(0, "所有用户");
            cboUserList.SelectedIndex = 0;
        }

        private void BindGridView(List<HandOverModel> listSource)
        {
            dgvHandHis.Rows.Clear();
            int i = 0;
            foreach (HandOverModel mHandTmp in listSource)
            {
                dgvHandHis.Rows.Add();
                dgvHandHis.Rows[i].Cells["StartDate"].Value = mHandTmp.CommonInfo.StartDate;
                dgvHandHis.Rows[i].Cells["CUserName"].Value = mHandTmp.CurrentUserInfo.UserName;
                dgvHandHis.Rows[i].Cells["NUserName"].Value = mHandTmp.NextUserInfo.UserName;
                dgvHandHis.Rows[i].Cells["FromLast"].Value = mHandTmp.FromLastMoney;
                dgvHandHis.Rows[i].Cells["CurrentDeposit"].Value = mHandTmp.CurrentDeposit;
                dgvHandHis.Rows[i].Cells["CurrentPaid"].Value = mHandTmp.CurrentPaidMoney;
                dgvHandHis.Rows[i].Cells["HandOverMoney"].Value = mHandTmp.HandOverMoney;
                dgvHandHis.Rows[i].Cells["HandInMoney"].Value = mHandTmp.HandInMoney;
                dgvHandHis.Rows[i].Cells["ToNextMoney"].Value = mHandTmp.ToNextMoney;
                i++;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                oCtrl.Reset();
                HandOverModel mHandOverHis = new HandOverModel();

                if (cboUserList.SelectedIndex != 0)
                {
                    var query = listUser.Where(c => c.UserName == cboUserList.SelectedItem.ToString()).FirstOrDefault();
                    mHandOverHis.CurrentUserInfo = query;
                    oCtrl.Add(MCtrl.ByCUserId);
                }

                mHandOverHis.CommonInfo.StartDate = GetDateTimePickValue(dtpStart, cboHourS);
                mHandOverHis.CommonInfo.EndDate = GetDateTimePickValue(dtpEnd, cboHourE);
                rptHelper1.StartTime = mHandOverHis.CommonInfo.StartDate;
                rptHelper1.EndTime = mHandOverHis.CommonInfo.EndDate;
                oCtrl.Add(MCtrl.ByCreateDate);
                listHandOver = bHandOver.GetHandOverList(mHandOverHis, oCtrl);
                BindGridView(listHandOver);
            }
            catch (Exception err)
            {
                lblMsg1.Text = err.Message;
            }
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

        private void FormHandHisRpt_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void LoadUIInfo()
        {
            BindUser();
            BindHour();
            rptHelper1.GridViewSource = dgvHandHis;
            rptHelper1.FormName = this.Name;
            rptHelper1.OpUserInfo = UserInfo;
            //rptHelper1.ShowDialog = true;
            //rptHelper1.DrawLine = true;
        }

        //private void pbtnExcel_Click(object sender, EventArgs e)
        //{
        //    cmn.ExportExcel(dgvHandHis, true);
        //}

        //private void pbtnPrint_Click(object sender, EventArgs e)
        //{
        //    if (cmn.CheckEOF(listHandOver))
        //    {
        //        PrintModel mPrint = new PrintModel();
        //        mPrint = bPrint.GetPrintModel(new PrintModel(this.Name), new ObjectControls(MCtrl.ByPrintNo));
        //        CommonModel mComm = new CommonModel();
        //        mComm.StartDate = GetDateTimePickValue(dtpStart, cboHourS);
        //        mComm.EndDate = GetDateTimePickValue(dtpEnd, cboHourE);
        //        mPrint = bPrint.GetPrintSet(mPrint, new Object[] { UserInfo, mComm });
        //        DataGridViewPrint dgvp = new DataGridViewPrint(new DataGridView[] { dgvHandHis });
        //        dgvp.GetPrintConfig = mPrint;
        //        dgvp.Print(false);
        //    }
        //}
    }
}
