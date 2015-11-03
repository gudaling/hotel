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
using Hotel.Model;

namespace Hotel
{
    public partial class FormOrders : BaseForm
    {
        private OrdersInfo bOrder = new OrdersInfo();
        private BasRoomInfo bRoom = new BasRoomInfo();
        private List<OrderInfoModel> listOrderInfo = new List<OrderInfoModel>();
        private HotelMainLogic hml = new HotelMainLogic();

        public FormOrders()
        {
            InitializeComponent();
        }

        private void LoadUIInfo()
        {
            dtpStart.CustomFormat = "yyyy-MM-dd";
            dtpEnd.CustomFormat = "yyyy-MM-dd";
            dtpStart.Value = cmn.DateBaseDate.Date;
            dtpEnd.Value = dtpStart.Value.AddDays(3);
            BindHour();
            BindCodeInfo(cboStatus, "ORDER_INFO", "STATUS");
            cboStatus.SelectedIndex = 0;
            GetOrderInfo();
        }

        private void BindHour()
        {
            for (int i = 0; i < 24; i++)
            {
                cboHourS.Items.Add(i);
                cboHourE.Items.Add(i);
            }
            cboHourS.SelectedIndex = 6;
            cboHourE.SelectedIndex = 23;
        }

        private void BindOrderList(List<OrderInfoModel> listOrder)
        {
            dgvOrderList.Rows.Clear();
            DateTime dtNow = cmn.DateBaseDate;
            int i = 0;
            foreach (OrderInfoModel mOrder in listOrder)
            {
                dgvOrderList.Rows.Add();
                dgvOrderList.Rows[i].Cells["OrderId"].Value = mOrder.OrderId;
                if (mOrder.Status == 'E' || mOrder.Status == 'D')
                {
                    dgvOrderList.Rows[i].Cells["OrderStatus"].Value = mOrder.KeepDate > dtNow ? "预定中" : "已过期";
                }
                else
                {
                    dgvOrderList.Rows[i].Cells["OrderStatus"].Value = mOrder.Status == 'C' ? "已取消" : "已入住";
                }
                dgvOrderList.Rows[i].Cells["RoomType"].Value = mOrder.RoomInfo.RoomTypeDesc;
                dgvOrderList.Rows[i].Cells["RoomNo"].Value = mOrder.RoomInfo.RoomNo;
                dgvOrderList.Rows[i].Cells["CustomerName"].Value = mOrder.Name;
                dgvOrderList.Rows[i].Cells["Phone"].Value = mOrder.Phone;
                dgvOrderList.Rows[i].Cells["StartDate"].Value = mOrder.CommonInfo.StartDate.ToString("yyyy-MM-dd hh:mm:ss");
                dgvOrderList.Rows[i].Cells["EndDate"].Value = mOrder.CommonInfo.EndDate.ToString("yyyy-MM-dd hh:mm:ss");
                dgvOrderList.Rows[i].Cells["KeepDate"].Value = mOrder.KeepDate.ToString("yyyy-MM-dd hh:mm:ss");
                dgvOrderList.Rows[i].Cells["CreateDate"].Value = mOrder.CommonInfo.CreateDate.ToString("yyyy-MM-dd hh:mm:ss");
                dgvOrderList.Rows[i].Cells["Notice"].Value = mOrder.Notice;
                i++;
            }
        }

        private void GetOrderInfo()
        {
            OrderInfoModel mOrder = new OrderInfoModel();
            oCtrl.Reset();
            if (!string.IsNullOrEmpty(txtNPR.Text.Trim()))
            {
                mOrder.Name = txtNPR.Text;
                oCtrl.Add(MCtrl.ByNPR);
            }
            else
            {
                if (cboStatus.SelectedValue.ToString() != "A")
                {
                    mOrder.KeepDate = cmn.DateBaseDate;
                    switch (cboStatus.SelectedValue.ToString())
                    {
                        case "E"://预定中
                            mOrder.Status = 'E';
                            oCtrl.Add(MCtrl.ByKeepDateEnable);
                            oCtrl.Add(MCtrl.ByOrderStatus);
                            break;
                        case "D"://已过期
                            mOrder.Status = 'E';
                            oCtrl.Add(MCtrl.ByOrderStatus);
                            oCtrl.Add(MCtrl.ByKeepDateDisable);
                            break;
                        case "C"://已取消
                            mOrder.Status = 'C';
                            oCtrl.Add(MCtrl.ByOrderStatus);
                            break;
                        case "I"://已入住
                            mOrder.Status = 'I';
                            oCtrl.Add(MCtrl.ByOrderStatus);
                            break;
                    }
                }
            }
            mOrder.CommonInfo = new CommonModel();
            mOrder.CommonInfo.StartDate = GetDateTimePickValue(dtpStart, cboHourS);
            mOrder.CommonInfo.EndDate = GetDateTimePickValue(dtpEnd, cboHourE);
            oCtrl.Add(MCtrl.ByStartDateBetween);

            listOrderInfo = bOrder.GetOrderInfo(mOrder, oCtrl);
            BindOrderList(listOrderInfo);
        }

        private OrderInfoModel GetSelectedOrder()
        {
            if (dgvOrderList.SelectedRows.Count > 0)
            {
                var query = listOrderInfo.Where(c => c.OrderId == int.Parse(dgvOrderList.SelectedRows[0].Cells["OrderId"].Value.ToString()));
                if (query.Count() > 0)
                {
                    return query.First();
                }
            }
            return null;
        }

        private void pbtnAddOrder_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            e.Graphics.DrawString("新增", new Font("宋体", 10), new SolidBrush(Color.Black), 0, pic.Height - 15);
        }

        private void pbtnEditOrder_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            e.Graphics.DrawString("修改", new Font("宋体", 10), new SolidBrush(Color.Black), 0, pic.Height - 15);
        }

        private void pbtnDeleteOrder_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            e.Graphics.DrawString("删除", new Font("宋体", 10), new SolidBrush(Color.Black), 0, pic.Height - 15);
        }

        private void pbtnOpenOrder_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            e.Graphics.DrawString("开单", new Font("宋体", 10), new SolidBrush(Color.Black), 0, pic.Height - 15);
        }

        private void pbtnCancel_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            e.Graphics.DrawString("取消", new Font("宋体", 10), new SolidBrush(Color.Black), 0, pic.Height - 15);
        }

        private void pbtnAddOrder_Click(object sender, EventArgs e)
        {
            FormNewOrder frmNewOrder = new FormNewOrder();
            if (frmNewOrder.ShowDialog() == DialogResult.OK)
            {
                GetOrderInfo();
            }
        }

        private void pbtnEditOrder_Click(object sender, EventArgs e)
        {
            OrderInfoModel mOrder = GetSelectedOrder();
            if (mOrder != null)
            {
                if (mOrder.Status == 'I')
                {
                    cmn.Show("宾客已入住,不能编辑");
                    return;
                }
                FormNewOrder frmNewOrder = new FormNewOrder(mOrder);
                if (frmNewOrder.ShowDialog() == DialogResult.OK)
                {
                    GetOrderInfo();
                }
            }
        }

        private void pbtnCancel_Click(object sender, EventArgs e)
        {
            OrderInfoModel mOrder = GetSelectedOrder();
            if (mOrder != null)
            {
                if (mOrder.Status == 'I')
                {
                    cmn.Show("宾客已入住,不能取消");
                    return;
                }
                if (cmn.Confirm(string.Format("确定取消宾客{0}在房间{1}的预定?", mOrder.Name, mOrder.RoomInfo.RoomNo)))
                {
                    mOrder.Status = 'C';
                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.SetOrderStatus);
                    bOrder.UpdateOrderInfo(mOrder, oCtrl);
                    if (mOrder.RoomInfo.Status != 'I' && mOrder.RoomInfo.Status != 'T')
                    {
                        mOrder.RoomInfo.Status = 'E';
                        hml.UpdateRoomStatusByRoomId(mOrder.RoomInfo, UserInfo);
                    }
                    GetOrderInfo();
                }
            }
        }

        private void pbtnDeleteOrder_Click(object sender, EventArgs e)
        {
            OrderInfoModel mOrder  = GetSelectedOrder();
            if (mOrder != null)
            {
                if (mOrder.Status == 'I')
                {
                    cmn.Show("宾客已入住,不能删除");
                    return;
                }
                if (cmn.Confirm(string.Format("确定删除宾客{0}在房间{1}的预定?", mOrder.Name, mOrder.RoomInfo.RoomNo)))
                {
                    bOrder.DeleteOrder(mOrder);
                    if (mOrder.RoomInfo.Status != 'I' && mOrder.RoomInfo.Status != 'T')
                    {
                        mOrder.RoomInfo.Status = 'E';
                        hml.UpdateRoomStatusByRoomId(mOrder.RoomInfo, UserInfo);
                    }
                    GetOrderInfo();
                }
            }
        }

        private void pbtnOpenOrder_Click(object sender, EventArgs e)
        {
            try
            {
                OrderInfoModel mOrder = GetSelectedOrder();
                if (mOrder != null)
                {
                    if (!hml.OpenRoomCheck(mOrder.RoomInfo))
                    {
                        return;
                    }
                    FormOneCustomer frmOneCustomer = new FormOneCustomer(mOrder.RoomInfo);
                    if (frmOneCustomer.ShowDialog() == DialogResult.OK)
                    {
                        GetOrderInfo();
                    }
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void txtNPR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtNPR.Text.Trim()))
            {
                GetOrderInfo();
                BindOrderList(listOrderInfo);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetOrderInfo();
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedItem != null)
            {
                GetOrderInfo();
            }
        }

        protected void pbMouseEnter(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(35, 68);
        }

        protected void pbMouseLeave(Object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Size = new Size(32, 64);
        }

    }
}
