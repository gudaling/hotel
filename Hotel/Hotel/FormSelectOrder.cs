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
    public partial class FormSelectOrder :BaseForm
    {
        public OrderInfoModel mOrderInfo = new OrderInfoModel();
        private List<OrderInfoModel> listOrderInfo = new List<OrderInfoModel>();
        public FormSelectOrder(List<OrderInfoModel> listOrder)
        {
            InitializeComponent();
            listOrderInfo = listOrder;
        }

        private void LoadUIInfo()
        {
            BindOrderGridView(listOrderInfo);
        }

        private void BindOrderGridView(List<OrderInfoModel> listSource)
        {
            if (cmn.CheckEOF(listSource))
            {
                dgvOrderedInfo.Rows.Clear();
                int i = 0;
                foreach (OrderInfoModel mOrder in listSource)
                {
                    dgvOrderedInfo.Rows.Add();
                    dgvOrderedInfo.Rows[i].Cells["CustomerName"].Value = mOrder.Name;
                    dgvOrderedInfo.Rows[i].Cells["StartDate"].Value = mOrder.CommonInfo.StartDate;
                    dgvOrderedInfo.Rows[i].Cells["Phone"].Value = mOrder.Phone;
                    dgvOrderedInfo.Rows[i].Cells["OrderId"].Value = mOrder.OrderId;
                    i++;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvOrderedInfo.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvOrderedInfo.Rows[i].Cells["chkSelect"];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        mOrderInfo = listOrderInfo.Where(c => c.OrderId == int.Parse(dgvOrderedInfo.Rows[i].Cells["OrderId"].Value.ToString())).First();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                if (this.DialogResult != DialogResult.OK)
                {
                    mOrderInfo = null;
                }
                this.Close();
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void FormSelectOrder_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void dgvOrderedInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvOrderedInfo.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvOrderedInfo.Rows[i].Cells["chkSelect"];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    checkCell.Value = false;
                }
                continue;
            }

        }
    }
}
