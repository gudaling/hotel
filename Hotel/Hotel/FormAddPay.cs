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
    public partial class FormAddPay : BaseForm
    {
        private BasRoomModel mRoomInfo = new BasRoomModel();
        private ConsumeDetail bConsume = new ConsumeDetail();
        private BasGoodsInfo bGoods = new BasGoodsInfo();
        private List<BasGoodsModel> listGoods = new List<BasGoodsModel>();
        private CustomerStayModel mCustomerStay = new CustomerStayModel();
        private List<ConsumeDetailModel> listConsumeOld = new List<ConsumeDetailModel>();
        private HotelMainLogic hml = new HotelMainLogic();
        //private List<int> listAddGoods = new List<int>();
        private double dTotal = 0.0;

        public FormAddPay()
        {
            InitializeComponent();
        }

        public FormAddPay(CustomerStayModel mCustomerStayInfo)
        {
            InitializeComponent();
            this.mRoomInfo = mCustomerStayInfo.RoomInfo;
            mCustomerStay = mCustomerStayInfo;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    hml.AddConsume(mCustomerStay.ConSumeDetailList, listConsumeOld);
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //catch (Exception err)
            //{
            //    cmn.Show(err.Message);
            //}
        }

        private void LoadUIInfo()
        {
            try
            {
                txtNumber.Text = "1";
                lblRoomNo.Text = mRoomInfo.RoomNo;
                if (mCustomerStay != null)
                {
                    listGoods = GetGoodsList();
                    BindGoodsList(listGoods);
                    BindConsumeDetail(mCustomerStay.ConSumeDetailList);
                    foreach (ConsumeDetailModel mConsume in mCustomerStay.ConSumeDetailList)
                    {
                        listConsumeOld.Add(mConsume);
                    }
                }
                else
                {
                    cmn.Show("该房间不存在入住记录,无法提前消费.");
                    this.Close();
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        /// <summary>
        /// 取得商品列表
        /// </summary>
        /// <returns></returns>
        private List<BasGoodsModel> GetGoodsList()
        {
            BasGoodsModel mGoods = new BasGoodsModel();
            mGoods.Status = 'E';
            return bGoods.GetGoodsInfo(mGoods, new ObjectControls(MCtrl.ByGoodsStatus));
        }

        /// <summary>
        /// 绑定商品
        /// </summary>
        /// <param name="listSource"></param>
        private void BindGoodsList(List<BasGoodsModel> listSource)
        {
            dgvGoodsList.Rows.Clear();
            if (cmn.CheckEOF(listSource))
            {
                int i=0;
                foreach (BasGoodsModel mGoods in listSource)
                {
                    dgvGoodsList.Rows.Add();
                    dgvGoodsList.Rows[i].Cells["GoodsName"].Value = mGoods.GoodsName;
                    dgvGoodsList.Rows[i].Cells["Unit"].Value = mGoods.GoodsUnit;
                    dgvGoodsList.Rows[i].Cells["Price"].Value = mGoods.Price;
                    dgvGoodsList.Rows[i].Cells["GoodsId"].Value = mGoods.GoodsId;
                    i++;
                }
            }
        }

        /// <summary>
        /// 绑定消费
        /// </summary>
        /// <param name="listSource"></param>
        private void BindConsumeDetail(List<ConsumeDetailModel> listSource)
        {
            dgvConsumeList.Rows.Clear();
            dTotal = 0.0;
            for (int i = 0; i < listSource.Count; i++)
            {
                dgvConsumeList.Rows.Add();
                dgvConsumeList.Rows[i].Cells["GoodsIDD"].Value = listSource[i].GoodsId;
                dgvConsumeList.Rows[i].Cells["ConsumeGoodsName"].Value = listSource[i].GoodsInfo.GoodsName;
                dgvConsumeList.Rows[i].Cells["UnitPrice"].Value = listSource[i].UnitPrice;
                dgvConsumeList.Rows[i].Cells["Number"].Value = listSource[i].Number;
                dgvConsumeList.Rows[i].Cells["ConsumePrice"].Value = listSource[i].Total;
                dgvConsumeList.Rows[i].Cells["CreateDate"].Value = listSource[i].CommonInfo.CreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                dgvConsumeList.Rows[i].Cells["CreateUserName"].Value = listSource[i].CommonInfo.CreateUserName;

                dTotal += listSource[i].Total;
                //if (listAddGoods.Where(c => c == listSource[i].GoodsId).Count() > 0 && listSource[i].ConsumeId == -1)
                //{
                //    dgvConsumeList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                //}
            }
            lblTotal.Text = dTotal.ToString();
        }

        /// <summary>
        /// 增加消费
        /// </summary>
        private void AddConsume()
        {
            try
            {
                if (dgvGoodsList.SelectedRows.Count == 0)
                {
                    return;
                }
                if (int.Parse(txtNumber.Text) <= 0 || !cmn.Confirm("确定增加商品" + dgvGoodsList.SelectedRows[0].Cells["GoodsName"].Value.ToString() + " 数量为" + txtNumber.Text))
                {
                    return;
                }
                int GoodsId = int.Parse(dgvGoodsList.SelectedRows[0].Cells["GoodsId"].Value.ToString());
                var query = mCustomerStay.ConSumeDetailList.Where(c => c.GoodsId == GoodsId);
                ConsumeDetailModel mConsumeNew = new ConsumeDetailModel();
                mConsumeNew.GoodsId = GoodsId;
                mConsumeNew.GoodsInfo = new BasGoodsModel();
                mConsumeNew.GoodsInfo.GoodsName = dgvGoodsList.SelectedRows[0].Cells["GoodsName"].Value.ToString();
                mConsumeNew.StayId = mCustomerStay.StayId;
                mConsumeNew.Number = txtNumber.Text.Equals("") ? 1 : cmn.CheckIsDouble(txtNumber, "消费数量");
                mConsumeNew.UnitPrice = double.Parse(dgvGoodsList.SelectedRows[0].Cells["Price"].Value.ToString());
                mConsumeNew.Total = mConsumeNew.Number * mConsumeNew.UnitPrice;
                mConsumeNew.CommonInfo = new CommonModel();
                mConsumeNew.CommonInfo.CreateUserId = UserInfo.UserId;
                mConsumeNew.CommonInfo.CreateUserName = UserInfo.UserName;
                mConsumeNew.CommonInfo.CreateDate = cmn.DateBaseDate;
                mConsumeNew.CommonInfo.UpdateUserId = UserInfo.UserId;
                //mCustomerStay.ConSumeDetailList.Add(mConsumeNew);
                //if (!listAddGoods.Contains(GoodsId))
                //{
                //    listAddGoods.Add(GoodsId);
                //}
                txtNumber.Text = "1";
                bConsume.InsertConsumeDetail(mConsumeNew);
                mCustomerStay = hml.GetStayInRoomInfo(mRoomInfo, 'I', "M");
                BindConsumeDetail(mCustomerStay.ConSumeDetailList);
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }

        }

        /// <summary>
        /// 移除消费
        /// </summary>
        private void RemoveConsume()
        {
            try
            {
                if (dgvConsumeList.SelectedRows.Count > 0)
                {
                    int GoodsId = int.Parse(dgvConsumeList.SelectedRows[0].Cells["GoodsIDD"].Value.ToString());
                    var query = mCustomerStay.ConSumeDetailList.Where(c => c.GoodsId == GoodsId);
                    if (query.Count() > 0)
                    {
                        if (cmn.Confirm("确定删除该消费,删除后将无法恢复?"))
                        {
                            bConsume.DeleteConsumeDetail(query.First());
                            //mCustomerStay.ConSumeDetailList.Remove(query.First());
                            mCustomerStay = hml.GetStayInRoomInfo(mRoomInfo, 'I', "M");
                            BindConsumeDetail(mCustomerStay.ConSumeDetailList);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                cmn.Show(err.Message);
            }
        }

        private void FormAddPay_Load(object sender, EventArgs e)
        {
            LoadUIInfo();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckKeyInNumber(txtNumber, e, "1234567890.",3);
            if (e.KeyChar == (char)13)
            {
                AddConsume();
            }
        }

        private void dgvGoodsList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e != null)
            {
                AddConsume();
            }
        }

        private void dgvConsumeList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e != null)
            {
                RemoveConsume();
            }
        }

        private void btnDeleteConsume_Click(object sender, EventArgs e)
        {
            RemoveConsume();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddConsume();
        }

        private void FormAddPay_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    //this.Close();
        //}
    }
}
