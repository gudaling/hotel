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
    public partial class FormControl : BaseForm
    {
        private BasRoomInfo bRoom = new BasRoomInfo();
        private BasGoodsInfo bGoods = new BasGoodsInfo();
        private HotelMainLogic hml = new HotelMainLogic();
        private SysUserInfo bUser = new SysUserInfo();
        private SysParameterInfo bParam = new SysParameterInfo();
        private List<BasRoomModel> listRoom = new List<BasRoomModel>();
        private List<BasGoodsModel> listGoods = new List<BasGoodsModel>();
        private List<SysUserInfoModel> listUser = new List<SysUserInfoModel>();
        private List<SysParameterModel> listParam = new List<SysParameterModel>();

        private string ParamValue = "";

        public FormControl()
        {
            InitializeComponent();
            tslblStatus.ForeColor = Color.Red;
        }

        private void BindRoomList()
        {
            dgvRoomInfo.Rows.Clear();
            listRoom = bRoom.GetRoomInfo(null, oCtrl.EmptyCtrl);
            int i = 0;
            foreach (BasRoomModel mRoom in listRoom)
            {
                dgvRoomInfo.Rows.Add();
                dgvRoomInfo.Rows[i].Cells["RoomId"].Value = mRoom.RoomId;
                dgvRoomInfo.Rows[i].Cells["RoomNo"].Value = mRoom.RoomNo;
                dgvRoomInfo.Rows[i].Cells["RoomType"].Value = mRoom.RoomType;
                dgvRoomInfo.Rows[i].Cells["RoomTypeDesc"].Value = mRoom.RoomTypeDesc;
                dgvRoomInfo.Rows[i].Cells["RoomRate"].Value = mRoom.RoomRate;

                dgvRoomInfo.Rows[i].Cells["RoomPhone"].Value = mRoom.RoomPhone;
                dgvRoomInfo.Rows[i].Cells["FloorId"].Value = mRoom.FloorInfo.FloorId;
                dgvRoomInfo.Rows[i].Cells["FloorNo"].Value = mRoom.FloorInfo.FloorName;
                i++;
            }

        }

        private void BindFloor()
        {
            cboFloor.DataSource = new BasFloorInfo().GetFloorInfo();
            cboFloor.DisplayMember = "FloorName";
            cboFloor.ValueMember = "FloorId";
            cboFloor.SelectedIndex = 0;
        }

        private void BindRole()
        {
            cboRole.DataSource =bUser.GetRoleList();
            cboRole.DisplayMember = "RoleName";
            cboRole.ValueMember = "RoleId";
        }

        private void CheckTextValue(Object[] objList)
        {
            foreach (Object obj in objList)
            {
                TextBox txt = (TextBox)obj;
                if (txt.Text.Trim().Equals(""))
                {
                    throw new Exception("保存信息不完整,请确认输入!");
                }
            }
        }
        private void BindGoodsList()
        {
            dgvGoodsList.Rows.Clear();
            listGoods = bGoods.GetGoodsInfo(null, oCtrl.EmptyCtrl);
            var query = listGoods.Where(c => c.Type == 'R');
            if (query.Count() > 0)
            {
                listGoods.Remove(query.First());
            }
            int i = 0;
            foreach (BasGoodsModel mGoods in listGoods)
            {
                dgvGoodsList.Rows.Add();
                dgvGoodsList.Rows[i].Cells["GoodsId"].Value = mGoods.GoodsId;
                dgvGoodsList.Rows[i].Cells["GoodsName"].Value = mGoods.GoodsName;
                dgvGoodsList.Rows[i].Cells["Unit"].Value = mGoods.GoodsUnit;
                dgvGoodsList.Rows[i].Cells["Price"].Value = mGoods.Price;
                dgvGoodsList.Rows[i].Cells["Status"].Value = mGoods.Status;
                i++;
            }
        }

        private void BindUserList()
        {
            dgvUserList.Rows.Clear();
            listUser = bUser.GetUserInfoList();
            int i = 0;
            foreach (SysUserInfoModel mUser in listUser)
            {
                dgvUserList.Rows.Add();
                dgvUserList.Rows[i].Cells["UserId"].Value = mUser.UserId;
                dgvUserList.Rows[i].Cells["UserNo"].Value = mUser.UserNo;
                dgvUserList.Rows[i].Cells["UserName"].Value = mUser.UserName;
                dgvUserList.Rows[i].Cells["Psw"].Value = mUser.UserPassWord;
                dgvUserList.Rows[i].Cells["RoleName"].Value = mUser.RoleInfo.RoleName;
                dgvUserList.Rows[i].Cells["RoleId"].Value = mUser.RoleInfo.RoleId;
                i++;
            }
        }

        private void BindSysParameter()
        {
            listParam = bParam.GetSysParameter(null, oCtrl.EmptyCtrl);
            dgvParamList.Rows.Clear();
            int i=0;
            foreach (SysParameterModel mParam in listParam)
            {
                dgvParamList.Rows.Add();
                dgvParamList.Rows[i].Cells["ParamId"].Value = mParam.ParamId;
                dgvParamList.Rows[i].Cells["ParamName"].Value = mParam.ParamName;
                dgvParamList.Rows[i].Cells["ParamDesc"].Value = mParam.ParamDesc;
                dgvParamList.Rows[i].Cells["Value1"].Value = mParam.Value1;
                dgvParamList.Rows[i].Cells["Value2"].Value = mParam.Value2;
                dgvParamList.Rows[i].Cells["Value3"].Value = mParam.Value3;
                i++;
            }
        }

        private void LoadForm(int nIndex)
        {
            try
            {
                switch (nIndex)
                {
                    case 0:
                        BindCodeInfo(cboGoodsStatus, "BAS_GOODS_INFO", "STATUS");
                        cboGoodsStatus.SelectedIndex = 0;
                        BindGoodsList();
                        break;
                    case 1:
                        BindRole();
                        BindUserList();
                        break;
                    case 2:
                        BindCodeInfo(cboRoomType, "BAS_ROOM_INFO", "ROOM_TYPE");
                        cboRoomType.SelectedIndex = 0;
                        BindFloor();
                        BindRoomList();
                        break;
                    case 3:
                        BindSysParameter();
                        break;
                    case 4:

                        break;
                }
            }
            catch (Exception err)
            {
                tslblStatus.Text = err.Message;
            }
        }

        private void dgvRoomInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtRoomNo.Text = dgvRoomInfo.Rows[e.RowIndex].Cells["RoomNo"].Value.ToString();
                txtRoomNo.Tag = dgvRoomInfo.Rows[e.RowIndex].Cells["RoomId"].Value;
                txtRoomPhone.Text = dgvRoomInfo.Rows[e.RowIndex].Cells["RoomPhone"].Value.ToString();
                txtRoomRate.Text = dgvRoomInfo.Rows[e.RowIndex].Cells["RoomRate"].Value.ToString();
                cboFloor.SelectedValue = int.Parse(dgvRoomInfo.Rows[e.RowIndex].Cells["FloorId"].Value.ToString());
                cboRoomType.SelectedIndex = GetComboxIndexByKey(cboRoomType, dgvRoomInfo.Rows[e.RowIndex].Cells["RoomType"].Value);
            }
        }

        private void dgvGoodsList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                txtGoodsName.Tag = dgvGoodsList.Rows[e.RowIndex].Cells["GoodsId"].Value;
                txtGoodsName.Text = dgvGoodsList.Rows[e.RowIndex].Cells["GoodsName"].Value.ToString();
                txtGoodsPrice.Text = dgvGoodsList.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                txtGoodsUnit.Text = dgvGoodsList.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                cboGoodsStatus.SelectedIndex = GetComboxIndexByKey(cboGoodsStatus, dgvGoodsList.Rows[e.RowIndex].Cells["Status"].Value);
            }
        }

        private void dgvUserList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (UserInfo.UserNo == dgvUserList.Rows[e.RowIndex].Cells["UserNo"].Value.ToString())
                {
                    cmn.Show("不能修改自己的信息.\r如需修改,请用其他管理员账号登陆\r如无其他管理员账号,请新增管理员之后,再进行修改.");
                    return;
                }
                txtUserName.Tag = dgvUserList.Rows[e.RowIndex].Cells["UserId"].Value;
                txtUserName.Text = dgvUserList.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                txtUserNo.Text = dgvUserList.Rows[e.RowIndex].Cells["UserNo"].Value.ToString();
                txtPsw.Text = dgvUserList.Rows[e.RowIndex].Cells["Psw"].Value.ToString();
                cboRole.SelectedValue = dgvUserList.Rows[e.RowIndex].Cells["RoleId"].Value;
            }
        }

        private void dgvUserList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (UserInfo.UserId == Convert.ToInt32(e.Row.Cells["UserId"].Value))
            {
                cmn.Show("不能删除自己!");
                e.Cancel = true;
                return;
            }
            if (!cmn.Confirm("确定删除用户" + e.Row.Cells["UserName"].Value))
            {
                e.Cancel = true;
                return;
            }

            var query = listUser.Where(c => c.UserId == Convert.ToInt32(e.Row.Cells["UserId"].Value));
            bUser.DeleteUserInfo(query.First());
        }

        private void dgvRoomInfo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!cmn.Confirm("确定删除房间" + e.Row.Cells["RoomNo"].Value))
            {
                e.Cancel = true;
                return;
            }

            var query = listRoom.Where(c => c.RoomId == Convert.ToInt32(e.Row.Cells["RoomId"].Value));
            bRoom.DeleteRoomInfo(query.First());

        }

        private void dgvGoodsList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!cmn.Confirm("确定删除商品" + e.Row.Cells["GoodsName"].Value))
            {
                e.Cancel = true;
                return;
            }

            var query = listGoods.Where(c => c.GoodsId == Convert.ToInt32(e.Row.Cells["GoodsId"].Value));
            if (query.Count() > 0)
            {
                BasGoodsModel mGoodes = query.First();
                mGoodes.Status = 'D';
                bGoods.UpdateGoods(mGoodes, new ObjectControls(MCtrl.SetGoodsStaus));
            }

        }

        private void FormControl_Load(object sender, EventArgs e)
        {
            LoadForm(0);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadForm(tabControl1.SelectedIndex);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckTextValue(new Object[] { txtRoomNo, txtRoomRate });
                if (!cmn.Confirm("保存房间信息?"))
                {
                    return;
                }
                int nRoomId = 0;
                if (txtRoomNo.Tag != null && txtRoomNo.Tag.ToString() != "")
                {
                    nRoomId = Convert.ToInt32(txtRoomNo.Tag);
                }
                var query = listRoom.Where(c => c.RoomId == nRoomId);
                if (query.Count() > 0)
                {
                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.SetRoomNo);
                    oCtrl.Add(MCtrl.SetRoomRate);
                    oCtrl.Add(MCtrl.SetRoomType);
                    oCtrl.Add(MCtrl.SetFloorId);
                    oCtrl.Add(MCtrl.SetPhone);
                    BasRoomModel mRoom = new BasRoomModel();
                    mRoom.RoomNo = txtRoomNo.Text;
                    mRoom.RoomPhone = txtRoomPhone.Text;
                    mRoom.RoomRate = cmn.CheckIsDouble(txtRoomRate, "房间价格");
                    mRoom.RoomType = cmn.ToChar(cboRoomType.SelectedValue);
                    mRoom.FloorInfo.FloorId = int.Parse(cboFloor.SelectedValue.ToString());
                    mRoom.RoomId = query.First().RoomId;
                    bRoom.UpdateRoomInfo(mRoom, oCtrl);
                }
                else
                {
                    query = listRoom.Where(c => c.RoomNo == txtRoomNo.Text);
                    if (query.Count() > 0)
                    {
                        cmn.Show("房间号已经存在,无法新增!");
                        return;
                    }
                    BasRoomModel mRoom = new BasRoomModel();
                    mRoom.RoomNo = txtRoomNo.Text;
                    mRoom.RoomPhone = txtRoomPhone.Text;
                    mRoom.RoomRate = cmn.CheckIsDouble(txtRoomRate, "房间价格");
                    mRoom.RoomType = cmn.ToChar(cboRoomType.SelectedValue);
                    mRoom.FloorInfo.FloorId = int.Parse(cboFloor.SelectedValue.ToString());
                    mRoom.Status = 'E';
                    mRoom.RoomNotice = "";
                    mRoom.CommonInfo.CreateUserId = UserInfo.UserId;
                    bRoom.InsertRoomInfo(mRoom);
                }
                BindRoomList();
                tslblStatus.Text = "保存完毕";
                txtRoomNo.Text = "";
                txtRoomNo.Tag = "";
                txtRoomPhone.Text = "";
                txtRoomRate.Text = "";
            }
            catch (Exception err)
            {
                tslblStatus.Text = err.Message;
            }
        }

        private void btnGoodsSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckTextValue(new Object[] { txtGoodsName, txtGoodsPrice, txtGoodsUnit });
                if (!cmn.Confirm("保存商品信息?"))
                {
                    return;
                }
                int nGoodsId = 0;
                if (txtGoodsName.Tag != null && txtGoodsName.Tag.ToString() != "")
                {
                    nGoodsId = Convert.ToInt32(txtGoodsName.Tag);
                }
                var query = listGoods.Where(c => c.GoodsId == nGoodsId);
                if (query.Count() > 0)
                {
                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.SetGoodsName);
                    oCtrl.Add(MCtrl.SetGoodsStaus);
                    oCtrl.Add(MCtrl.SetUnitPrice);
                    oCtrl.Add(MCtrl.SetUnit);
                    BasGoodsModel mGoods = new BasGoodsModel();
                    mGoods.GoodsName = txtGoodsName.Text;
                    mGoods.GoodsUnit = txtGoodsUnit.Text;
                    mGoods.Price = cmn.CheckIsDouble(txtGoodsPrice, "商品价格");
                    mGoods.Status = cmn.ToChar(cboGoodsStatus.SelectedValue);
                    mGoods.GoodsId = query.First().GoodsId;
                    bGoods.UpdateGoods(mGoods, oCtrl);
                }
                else
                {
                    query = listGoods.Where(c => c.GoodsName == txtGoodsName.Text);
                    if (query.Count() > 0)
                    {
                        cmn.Show("商品已经存在,无法新增!");
                        return;
                    }
                    BasGoodsModel mGoods = new BasGoodsModel();
                    mGoods.GoodsName = txtGoodsName.Text;
                    mGoods.GoodsUnit = txtGoodsUnit.Text;
                    mGoods.Price = cmn.CheckIsDouble(txtGoodsPrice, "商品价格");
                    mGoods.Status = cmn.ToChar(cboGoodsStatus.SelectedValue);
                    bGoods.InsertGoods(mGoods);
                }
                BindGoodsList();
                tslblStatus.Text = "保存完毕";
                txtGoodsName.Text = "";
                txtGoodsName.Tag = "";
                txtGoodsUnit.Text = "";
                txtGoodsPrice.Text = "";
            }
            catch (Exception err)
            {
                tslblStatus.Text = err.Message;
            }
        }

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckTextValue(new Object[] { txtUserName, txtUserNo,txtPsw });
                if (UserInfo.UserNo == txtUserNo.Text)
                {
                    cmn.Show("不能修改自己的信息.\r如需修改,请用其他管理员账号登陆\r如无其他管理员账号,请新增管理员之后,再进行修改.");
                    return;
                }
                if (!cmn.Confirm("保存用户信息?"))
                {
                    return;
                }
                if (cboRole.SelectedIndex == 0 && !cmn.Confirm("您选择的是管理员角色,该角色能够修改系统设置\r权利较大,请慎重添加\r是否继续?"))
                {
                    return;
                }
                int nUserId = 0;
                if (txtUserName.Tag != null && txtUserName.Tag.ToString() != "")
                {
                    nUserId = Convert.ToInt32(txtUserName.Tag);
                }
                var query = listUser.Where(c => c.UserId == nUserId);
                if (query.Count() > 0)
                {
                    oCtrl.Reset();
                    oCtrl.Add(MCtrl.SetUserNo);
                    oCtrl.Add(MCtrl.SetUserName);
                    oCtrl.Add(MCtrl.SetRoleId);
                    oCtrl.Add(MCtrl.SetPsw);
                    SysUserInfoModel mUser = new SysUserInfoModel();
                    mUser.UserNo = txtUserNo.Text;
                    mUser.UserName = txtUserName.Text;
                    mUser.NewPsw = MyMD5.MD5Encrypt(txtPsw.Text, "INDEXSFT");
                    mUser.RoleInfo.RoleId = int.Parse(cboRole.SelectedValue.ToString());
                    mUser.UserId = query.First().UserId;
                    bUser.UpdateUserInfo(mUser, oCtrl);
                }
                else
                {
                    query = listUser.Where(c => c.UserNo == txtUserNo.Text);
                    if (query.Count() > 0)
                    {
                        cmn.Show("该用户编号已经存在,无法新增!");
                        return;
                    }
                    SysUserInfoModel mUser = new SysUserInfoModel();
                    mUser.UserNo = txtUserNo.Text;
                    mUser.UserName = txtUserName.Text;
                    mUser.UserPassWord = MyMD5.MD5Encrypt(txtPsw.Text, "INDEXSFT");
                    mUser.RoleInfo.RoleId = int.Parse(cboRole.SelectedValue.ToString());
                    mUser.CommonInfo.CreateUserId = UserInfo.UserId;
                    mUser.CommonInfo.UpdateUserId = UserInfo.UserId;
                    bUser.InsertUserInfo(mUser);
                }
                BindUserList();
                tslblStatus.Text = "保存完毕";
                txtUserNo.Text = "";
                txtUserName.Text = "";
                txtUserName.Tag = "";
                txtPsw.Text = "";
            }
            catch (Exception err)
            {
                tslblStatus.Text = err.Message;
            }
        }

        private void dgvGoodsList_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BindGoodsList();
        }

        private void dgvRoomInfo_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BindRoomList();
        }

        private void dgvUserList_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            BindUserList();
        }

        private void FormControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvParamList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ParamValue = dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : "";
        }

        private void dgvParamList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && ParamValue == dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
            {
                return;
            }
            if (e.ColumnIndex == 3 && !string.IsNullOrEmpty(ParamValue) && (dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Equals("")))
            {
                cmn.Show("当前值不能修改为空!");
                dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ParamValue;
                return;
            }

            if (!cmn.Confirm("修改当前行的值?"))
            {
                dgvParamList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ParamValue;
            }
            else
            {
                SysParameterModel mParamter = new SysParameterModel();
                mParamter.ParamId = int.Parse(dgvParamList.Rows[e.RowIndex].Cells["ParamId"].Value.ToString());
                mParamter.Value1 = dgvParamList.Rows[e.RowIndex].Cells["Value1"].Value.ToString().ToUpper();
                mParamter.Value2 = dgvParamList.Rows[e.RowIndex].Cells["Value2"].Value == null ? "" : dgvParamList.Rows[e.RowIndex].Cells["Value2"].Value.ToString().ToUpper();
                mParamter.Value3 = dgvParamList.Rows[e.RowIndex].Cells["Value3"].Value == null ? "" : dgvParamList.Rows[e.RowIndex].Cells["Value3"].Value.ToString().ToUpper();
                oCtrl.Reset();
                oCtrl.Add(MCtrl.SetValue1);
                oCtrl.Add(MCtrl.SetValue2);
                oCtrl.Add(MCtrl.SetValue3);
                bParam.UpdateParameter(mParamter, oCtrl);
            }
        }

    }

}
