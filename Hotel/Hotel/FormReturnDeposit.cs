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

namespace Hotel
{
    public partial class FormReturnDeposit : BaseForm
    {
        private BasRoomModel mRoomInfo = new BasRoomModel();
        private HotelMainLogic hml = new HotelMainLogic();
        private CustomerStayModel mCustomerStay = new CustomerStayModel();
        private CustomerStayInfo bCustomerStay = new CustomerStayInfo();
        public FormReturnDeposit()
        {
            InitializeComponent();
        }

        public FormReturnDeposit(CustomerStayModel mCustomerStayInfo)
        {
            InitializeComponent();
            mCustomerStay = mCustomerStayInfo;
            mRoomInfo = mCustomerStayInfo.RoomInfo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReturnDeposit_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }
        private void LoadUIInfo()
        {

            lblRoomNo.Text = mRoomInfo.RoomNo;
            BindCodeInfo(cboPayType, "CUSTOMER_STAY_INFO", "PAY_TYPE");
            if (mCustomerStay != null)
            {
                lblCustomerName.Text = mCustomerStay.CustomerList[0].Name;
                cboPayType.SelectedIndex = GetComboxIndexByKey(cboPayType, mCustomerStay.PayType);
                txtOverStayDays.Text = "0";
                txtDeposit.Text = "0.0";
            }
            else
            {
                this.Close();
            }
        }

        private void txtOverStayDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtOverStayDays, e, "0123456789",3);
        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtDeposit, e, "-0123456789",5);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (mCustomerStay.Deposit + cmn.CheckIsDouble(txtDeposit, "押金") < 0)
                { 
                    throw new Exception("退还押金数不可以大于预付押金数!");
                }
                mCustomerStay.Deposit += cmn.CheckIsDouble(txtDeposit, "押金");
                int nOverStayDays = cmn.CheckIsInt(txtOverStayDays, "续住天数");
                oCtrl.Reset();
                if (nOverStayDays > 0)
                {
                    mCustomerStay.CommonInfo.EndDate = mCustomerStay.CommonInfo.EndDate > cmn.DateBaseDate ? mCustomerStay.CommonInfo.EndDate.AddDays(nOverStayDays) : DateTime.Parse(cmn.DateBaseDate.AddDays(nOverStayDays).ToShortDateString() +" "+ mCustomerStay.CommonInfo.EndDate.ToShortTimeString());
                    mCustomerStay.Hours = Convert.ToInt32(hml.GetCustomerStayDays(mCustomerStay.CommonInfo.StartDate, mCustomerStay.CommonInfo.EndDate, cmn.DateBaseDate, RoomStayType.Day, listSysParameter) * 24);
                    oCtrl.Add(MCtrl.SetEndDate);
                    oCtrl.Add(MCtrl.SetHours);
                }
                oCtrl.Add(MCtrl.SetDeposit);
     
                if (bCustomerStay.UpdateCustomerStay(mCustomerStay, oCtrl) > 0)
                {

                    CustomerStayModel mcs = hml.GetStayInRoomInfo(mCustomerStay.RoomInfo, 'I', "");
                    foreach (CustomerModel mc in mcs.CustomerList)
                    {
                        mc.CustomerStayHisInfo.CommonInfo.EndDate = mCustomerStay.CommonInfo.EndDate;
                        oCtrl.Reset();
                        oCtrl.Add(MCtrl.SetEndDate);
                        bCustomerStay.UpdateStayHis(mc.CustomerStayHisInfo, oCtrl);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }
    }
}
