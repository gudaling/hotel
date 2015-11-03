using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel.Common;
using Hotel.BLL;

namespace Hotel
{
    public partial class FormKeyRoomNo : BaseForm
    {
        public FormKeyRoomNo()
        {
            InitializeComponent();
            pnlBorder.Size = this.Size;
            pnlBorder.Location = this.Location;
        }

        public string sRoomNo;
        private int oldX = 0;
        private int oldY = 0;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sRoomNo = cmn.ToRoomNo(txtRoomNo.Text);
            this.DialogResult = DialogResult.OK;
        }

        //private void FormKeyRoomNo_Paint(object sender, PaintEventArgs e)
        //{
        //    Pen pp = new Pen(Color.Black);
        //    e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.X + e.ClipRectangle.Width-1, e.ClipRectangle.Y + e.ClipRectangle.Height-1);
        //}

        private void pnlBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.Location.X - this.oldX;        //新的鼠标位置
                this.Top += e.Location.Y - this.oldY;
            }
        }

        private void pnlBorder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.oldX = e.Location.X;        //鼠标原来位置
                this.oldY = e.Location.Y;
            }
        }
    }
}
