using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hotel
{
    public partial class FormReports : BaseForm
    {
        public FormReports()
        {
            InitializeComponent();
        }

        private void pbtnIncomeRpt_Click(object sender, EventArgs e)
        {
            FormInComeRpt frmIncome = new FormInComeRpt();
            frmIncome.Show();
        }

        private void pbtnHandHisRpt_Click(object sender, EventArgs e)
        {
            FormHandHisRpt frmHandHis = new FormHandHisRpt();
            frmHandHis.Show();
        }

        private void pbtnCustomerStay_Click(object sender, EventArgs e)
        {
            FormCustomerStayRpt frmCustomerStay = new FormCustomerStayRpt();
            frmCustomerStay.Show();
        }

        private void pbtnStayRateRpt_Click(object sender, EventArgs e)
        {
            FormStayRateRpt frmStayRate = new FormStayRateRpt();
            frmStayRate.Show();
        }

    }
}
