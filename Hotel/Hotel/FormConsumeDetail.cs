using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Hotel.BLL;
using Hotel.Model;
using Hotel.Common;

namespace Hotel
{
    public partial class FormConsumeDetail : BaseForm
    {
        private bool IsCountPhone = false;
        private List<JFModel> listJf = new List<JFModel>();
        private JFModel mJf = new JFModel();
        private DateTime dtmNow;
        private CallInfo bCall = new CallInfo();
        private HotelMainLogic hml = new HotelMainLogic();
        private CustomerStayModel mCustomerStay = new CustomerStayModel();
        private List<PhoneCatModel> listCat = new List<PhoneCatModel>();
        private List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();
        private double dTotal = 0.0;
        public FormConsumeDetail(CustomerStayModel mCustomerStay)
        {
            InitializeComponent();
            dtmNow = cmn.DateBaseDate;
            this.mCustomerStay = mCustomerStay;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PintCertificate();
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void BindConsumeDetail(List<CustomerStayModel> listSource)
        {
            dgvConsumeDetail.Rows.Clear();
            if (cmn.CheckEOF(listSysParameter))
            {
                //double dt = 0.0;
                dTotal = 0.0;
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
                    dTotal += double.Parse(dgvConsumeDetail.Rows[i].Cells["TotalMoney"].Value.ToString());
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
                            dTotal += mCustomerStayTmp.ConSumeDetailList[j].Total;
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
                            dTotal += dPhone;
                            i++;
                        }

                        #endregion
                    }
                }
            }
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
            return listJf;
        }

        private void PintCertificate()
        {
            DataGridView dgv = new DataGridView();
            dgv.Columns.Add("ConsumeName", "消费项目");
            dgv.Columns.Add("UnitPrice", "单价");
            dgv.Columns.Add("Unit", "单位");
            dgv.Columns.Add("Number", "消费数量");
            dgv.Columns.Add("TotalMoney", "应收");

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

            dgv.AllowUserToAddRows = false;

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
            //dgv.Rows[i].Cells["ConsumeName"].Value = "合计：";
            //dgv.Rows[i].Cells["UnitPrice"].Value = dTotal.ToString();
            //dgv.Rows[i].Cells["Unit"].Value = "找零：";
            //dgv.Rows[i].Cells["Number"].Value = listCustomerStay[0].Deposit - dTotal;
            dgv.Rows[i].Cells["ConsumeName"].Value = "合计：";
            dgv.Rows[i].Cells["UnitPrice"].Value = dTotal.ToString();
            dgv.Rows[i].Cells["Unit"].Value = "押金：";
            dgv.Rows[i].Cells["Number"].Value =+ listCustomerStay[0].Deposit;
            dgv.Rows[i].Cells["TotalMoney"].Value = "找零：" + (listCustomerStay[0].Deposit - dTotal).ToString();

            if (dgvConsumeDetail.Rows.Count > 0)
            {
                PrintInfo bPrint = new PrintInfo();
                PrintModel mPrint = new PrintModel();
                mPrint = bPrint.GetPrintModel(new PrintModel("FormPayMoney"), new ObjectControls(MCtrl.ByPrintNo));
                CommonModel mComm = new CommonModel();
                mPrint = bPrint.GetPrintSet(mPrint, new Object[] { UserInfo });
                DataGridViewPrint dgvp = new DataGridViewPrint(new DataGridView[] { dgv });
                dgvp.GetPrintConfig = mPrint;
                dgvp.Print(true,false);
            }
        }

        private void FormConsumeDetail_Load(object sender, EventArgs e)
        {
            listCat = bCall.GetPhoneCatList(null, oCtrl.EmptyCtrl);
            mCustomerStay = hml.GetStayInRoomInfo(this.mCustomerStay.RoomInfo, 'O', "M");
            if (mCustomerStay != null)
            {
                listCustomerStay.Add(mCustomerStay);
                BindConsumeDetail(listCustomerStay);
            }
        }

    }
}
