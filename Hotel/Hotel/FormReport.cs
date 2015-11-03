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
using System.Reflection;

namespace Hotel
{
    public partial class FormReport : BaseForm
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            //OrdersInfo bOrder = new OrdersInfo();
            //DataSet ds= bOrder.GetOrderInfoDs(null, oCtrl.EmptyCtrl);
            //dataGridView1.DataSource = ds.Tables[0];

            //PhoneJFInfo bPhone = new PhoneJFInfo();
            //JFModel mJF = new JFModel();
            //mJF.CommonInfo.StartDate = DateTime.Now.AddDays(-10);
            //mJF.CommonInfo.EndDate = DateTime.Now.AddDays(-2);
            //mJF.PhoneNo = "83826912";
            //oCtrl.Add(MCtrl.ByPhone);
            //oCtrl.Add(MCtrl.ByStartDate);
            //dataGridView1.DataSource = bPhone.GetPhoneDetail(mJF, oCtrl, DateTime.Now.AddDays(-2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataGridViewPrint dgp = new DataGridViewPrint(new DataGridView[] { dataGridView1, dataGridView1, dataGridView1, dataGridView1, dataGridView1 });
            //dgp.Print(false); 

            webBrowser1.Navigate("http://192.168.1.5:81/Home/DSFp","",null, "Content-Type: application/x-www-form-urlencoded");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmn.ExportExcel(dataGridView1, true);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement hel = webBrowser1.Document.Forms["form1"].All["txtpayer"];
            hel.SetAttribute("value", "bbb");
            HtmlElement hel1 = webBrowser1.Document.Forms["form1"].All["btn"];
            hel1.InvokeMember("preview2()");

        }

    }
}
