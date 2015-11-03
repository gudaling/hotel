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

namespace Hotel
{
    public partial class FormTeamRoomSelector : BaseForm
    {
        private List<CustomerStayModel> listCustomerStay = new List<CustomerStayModel>();
        public int MainRoomId = -1;
        public int CustomerId = -1;
        public FormTeamRoomSelector(List<CustomerStayModel> listCustomerStay)
        {
            InitializeComponent();
            this.listCustomerStay = listCustomerStay;
        }

        private void FormTeamRoomSelector_Load(object sender, EventArgs e)
        {
            foreach (CustomerStayModel mcs in listCustomerStay)
            {
                cboMainRoom.Items.Add(mcs.CustomerList[0].Name);
            }
            cboMainRoom.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var query = listCustomerStay.Where(c => c.CustomerList[0].Name == cboMainRoom.Text);
                MainRoomId = query.First().MainRoomId;
                CustomerId = query.First().CustomerList[0].CustomerId;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }
    }
}
