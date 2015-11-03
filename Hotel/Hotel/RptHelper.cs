using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Common;
using Hotel.Model;
using Hotel.BLL;

namespace Hotel
{
    public partial class RptHelper : UserControl
    {
        private DataGridView dgv = new DataGridView();

        private CommonLibrary cmn = new CommonLibrary();

        public DataGridView GridViewSource
        {
            get { return dgv; }
            set { dgv = value; }
        }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool ExcelVisible
        {
            set { pbtnExcel.Visible = value; }
        }

        public bool PrintVisible
        {
            set { pbtnPrint.Visible = value; }
        }

        public bool ShowDialog=true;

        public bool DrawLine = true;

        private SysUserInfoModel mUserInfo = new SysUserInfoModel();

        public SysUserInfoModel OpUserInfo { get; set; }

        public string FormName { get; set; }

        public RptHelper()
        {
            InitializeComponent();
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

        private void pbtnExcel_Click(object sender, EventArgs e)
        {
            cmn.ExportExcel(dgv, true);
        }

        private void pbtnPrint_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count>0)
            {
                PrintInfo bPrint = new PrintInfo();
                PrintModel mPrint = new PrintModel();
                mPrint = bPrint.GetPrintModel(new PrintModel(FormName), new ObjectControls(MCtrl.ByPrintNo));
                CommonModel mComm = new CommonModel();
                mComm.StartDate = StartTime;
                mComm.EndDate = EndTime;
                mPrint = bPrint.GetPrintSet(mPrint, new Object[] { mUserInfo, mComm });
                DataGridViewPrint dgvp = new DataGridViewPrint(new DataGridView[] { dgv });
                dgvp.GetPrintConfig = mPrint;
                dgvp.Print(ShowDialog, DrawLine);
            }
        }
    }
}
