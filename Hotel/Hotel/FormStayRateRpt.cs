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
    public partial class FormStayRateRpt : BaseForm
    {
        private StayRateInfo bStayInfo = new StayRateInfo();
        public FormStayRateRpt()
        {
            InitializeComponent();
            rptHelper1.GridViewSource = dgvStayRate;
            rptHelper1.PrintVisible = false;
            dtpStart.Value = DateTime.Parse(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, "1"));
        }

        private void pbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                StayRateModel mStayRate = new StayRateModel();
                mStayRate.CommonInfo = new CommonModel();
                mStayRate.CommonInfo.StartDate = GetDateTimePickValue(dtpStart, null);
                mStayRate.CommonInfo.EndDate = GetDateTimePickValue(dtpEnd, null);
                dgvStayRate.AutoGenerateColumns = false;

                List<StayRateModel> listStayRate = bStayInfo.GetStayRate(mStayRate, new ObjectControls(MCtrl.ByStartDateBetween));

                dgvStayRate.Rows.Clear();

                if (cmn.CheckEOF(listStayRate))
                {
                    int i = 0;
                    double dTotal = 0.0;
                    foreach (StayRateModel msr in listStayRate)
                    {
                        dgvStayRate.Rows.Add();
                        dgvStayRate.Rows[i].Cells["ID"].Value = msr.Id;
                        dgvStayRate.Rows[i].Cells["StayRate"].Value = msr.StayRate + "%";
                        dgvStayRate.Rows[i].Cells["Days"].Value = msr.Days.ToString("yyyy-MM-dd");
                        dTotal += msr.StayRate;
                        i++;
                    }
                    dTotal = Math.Round(dTotal / listStayRate.Count, 2);

                    dgvStayRate.Rows.Add();
                    dgvStayRate.Rows[i].Cells["Days"].Value = "平均入住率";
                    dgvStayRate.Rows[i].Cells["StayRate"].Value = dTotal + "%";
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
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
