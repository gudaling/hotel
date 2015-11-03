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

namespace Hotel
{
    public partial class FormPhoneList : BaseForm
    {
        private List<JFModel> listJF = new List<JFModel>();
        private List<PhoneCatModel> listCat = new List<PhoneCatModel>();
        private List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();

        public FormPhoneList()
        {
            InitializeComponent();
        }
        public FormPhoneList(List<JFModel> listJF, List<PhoneCatModel> listCat, List<CustomerStayModel> listCustomerStay)
        {
            InitializeComponent();
            this.listJF = listJF;
            this.listCat = listCat;
            this.listCustomerStay = listCustomerStay;
        }
        private void LoadUiInfo()
        {
            int i = 0;
            foreach (CustomerStayModel mcs in listCustomerStay)
            {
                var query = listJF.Where(c => c.PhoneNo == mcs.RoomInfo.RoomPhone);
                foreach (JFModel mJf in query)
                {
                    dgvPhoneList.Rows.Add();
                    dgvPhoneList.Rows[i].Cells["RoomNo"].Value = mcs.RoomInfo.RoomNo;
                    dgvPhoneList.Rows[i].Cells["PhoneNo"].Value = mJf.PhoneNo;
                    dgvPhoneList.Rows[i].Cells["LinkNo"].Value = mJf.LinkNo;
                    dgvPhoneList.Rows[i].Cells["IsFree"].Value = mJf.FreeDesc;
                    dgvPhoneList.Rows[i].Cells["StartDate"].Value = mJf.CommonInfo.StartDate;
                    dgvPhoneList.Rows[i].Cells["EndDate"].Value = mJf.CommonInfo.EndDate;
                    dgvPhoneList.Rows[i].Cells["CallLength"].Value = mJf.CommonInfo.EndDate.Subtract(mJf.CommonInfo.StartDate).Minutes + "分" + mJf.CommonInfo.EndDate.Subtract(mJf.CommonInfo.StartDate).Seconds + "秒";
                    i++;
                }
            }
        }

        private void FormPhoneList_Load(object sender, EventArgs e)
        {
            LoadUiInfo();
            rptHelper1.OpUserInfo = UserInfo;
            rptHelper1.GridViewSource = dgvPhoneList;
        }
    }
}
