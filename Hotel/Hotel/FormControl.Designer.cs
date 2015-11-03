namespace Hotel
{
    partial class FormControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGoodsSet = new System.Windows.Forms.TabPage();
            this.dgvGoodsList = new System.Windows.Forms.DataGridView();
            this.GoodsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGoodsPrice = new System.Windows.Forms.TextBox();
            this.btnGoodsSave = new System.Windows.Forms.Button();
            this.cboGoodsStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGoodsUnit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGoodsName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tpSysUserSet = new System.Windows.Forms.TabPage();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Psw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.btnUserSave = new System.Windows.Forms.Button();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPsw = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tpRoomSet = new System.Windows.Forms.TabPage();
            this.dgvRoomInfo = new System.Windows.Forms.DataGridView();
            this.RoomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTypeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FloorNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FloorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRoomSave = new System.Windows.Forms.Button();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.cboFloor = new System.Windows.Forms.ComboBox();
            this.txtRoomPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoomRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpParamterSet = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvParamList = new System.Windows.Forms.DataGridView();
            this.ParamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParamDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpOtherSet = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpGoodsSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tpSysUserSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tpRoomSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tpParamterSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamList)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGoodsSet);
            this.tabControl1.Controls.Add(this.tpSysUserSet);
            this.tabControl1.Controls.Add(this.tpRoomSet);
            this.tabControl1.Controls.Add(this.tpParamterSet);
            this.tabControl1.Controls.Add(this.tpOtherSet);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 529);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpGoodsSet
            // 
            this.tpGoodsSet.Controls.Add(this.dgvGoodsList);
            this.tpGoodsSet.Controls.Add(this.groupBox2);
            this.tpGoodsSet.Location = new System.Drawing.Point(4, 21);
            this.tpGoodsSet.Name = "tpGoodsSet";
            this.tpGoodsSet.Padding = new System.Windows.Forms.Padding(3);
            this.tpGoodsSet.Size = new System.Drawing.Size(524, 504);
            this.tpGoodsSet.TabIndex = 1;
            this.tpGoodsSet.Text = "商品设置";
            this.tpGoodsSet.UseVisualStyleBackColor = true;
            // 
            // dgvGoodsList
            // 
            this.dgvGoodsList.AllowUserToAddRows = false;
            this.dgvGoodsList.AllowUserToResizeRows = false;
            this.dgvGoodsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvGoodsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GoodsId,
            this.GoodsName,
            this.Unit,
            this.Price,
            this.Status});
            this.dgvGoodsList.Location = new System.Drawing.Point(6, 143);
            this.dgvGoodsList.MultiSelect = false;
            this.dgvGoodsList.Name = "dgvGoodsList";
            this.dgvGoodsList.ReadOnly = true;
            this.dgvGoodsList.RowHeadersVisible = false;
            this.dgvGoodsList.RowTemplate.Height = 23;
            this.dgvGoodsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoodsList.Size = new System.Drawing.Size(515, 353);
            this.dgvGoodsList.TabIndex = 6;
            this.dgvGoodsList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGoodsList_UserDeletingRow);
            this.dgvGoodsList.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvGoodsList_UserDeletedRow);
            this.dgvGoodsList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGoodsList_CellMouseDoubleClick);
            // 
            // GoodsId
            // 
            this.GoodsId.HeaderText = "GoodsId";
            this.GoodsId.Name = "GoodsId";
            this.GoodsId.ReadOnly = true;
            this.GoodsId.Visible = false;
            // 
            // GoodsName
            // 
            this.GoodsName.HeaderText = "商品名称";
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.ReadOnly = true;
            this.GoodsName.Width = 150;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "价格";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGoodsPrice);
            this.groupBox2.Controls.Add(this.btnGoodsSave);
            this.groupBox2.Controls.Add(this.cboGoodsStatus);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtGoodsUnit);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtGoodsName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 131);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtGoodsPrice
            // 
            this.txtGoodsPrice.Location = new System.Drawing.Point(323, 14);
            this.txtGoodsPrice.Name = "txtGoodsPrice";
            this.txtGoodsPrice.Size = new System.Drawing.Size(100, 21);
            this.txtGoodsPrice.TabIndex = 2;
            // 
            // btnGoodsSave
            // 
            this.btnGoodsSave.Location = new System.Drawing.Point(348, 89);
            this.btnGoodsSave.Name = "btnGoodsSave";
            this.btnGoodsSave.Size = new System.Drawing.Size(75, 23);
            this.btnGoodsSave.TabIndex = 5;
            this.btnGoodsSave.Text = "保存";
            this.btnGoodsSave.UseVisualStyleBackColor = true;
            this.btnGoodsSave.Click += new System.EventHandler(this.btnGoodsSave_Click);
            // 
            // cboGoodsStatus
            // 
            this.cboGoodsStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoodsStatus.FormattingEnabled = true;
            this.cboGoodsStatus.Location = new System.Drawing.Point(323, 52);
            this.cboGoodsStatus.Name = "cboGoodsStatus";
            this.cboGoodsStatus.Size = new System.Drawing.Size(100, 20);
            this.cboGoodsStatus.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "状态";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "价格";
            // 
            // txtGoodsUnit
            // 
            this.txtGoodsUnit.Location = new System.Drawing.Point(65, 52);
            this.txtGoodsUnit.Name = "txtGoodsUnit";
            this.txtGoodsUnit.Size = new System.Drawing.Size(100, 21);
            this.txtGoodsUnit.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "单位";
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(65, 14);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Size = new System.Drawing.Size(100, 21);
            this.txtGoodsName.TabIndex = 1;
            this.txtGoodsName.Tag = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "名称";
            // 
            // tpSysUserSet
            // 
            this.tpSysUserSet.Controls.Add(this.dgvUserList);
            this.tpSysUserSet.Controls.Add(this.groupBox3);
            this.tpSysUserSet.Location = new System.Drawing.Point(4, 21);
            this.tpSysUserSet.Name = "tpSysUserSet";
            this.tpSysUserSet.Size = new System.Drawing.Size(524, 504);
            this.tpSysUserSet.TabIndex = 2;
            this.tpSysUserSet.Text = "操作员设置";
            this.tpSysUserSet.UseVisualStyleBackColor = true;
            // 
            // dgvUserList
            // 
            this.dgvUserList.AllowUserToAddRows = false;
            this.dgvUserList.AllowUserToResizeRows = false;
            this.dgvUserList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.UserNo,
            this.UserName,
            this.Psw,
            this.RoleName,
            this.RoleId});
            this.dgvUserList.Location = new System.Drawing.Point(6, 143);
            this.dgvUserList.MultiSelect = false;
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.ReadOnly = true;
            this.dgvUserList.RowHeadersVisible = false;
            this.dgvUserList.RowTemplate.Height = 23;
            this.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserList.Size = new System.Drawing.Size(515, 353);
            this.dgvUserList.TabIndex = 6;
            this.dgvUserList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvUserList_UserDeletingRow);
            this.dgvUserList.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvUserList_UserDeletedRow);
            this.dgvUserList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUserList_CellMouseDoubleClick);
            // 
            // UserId
            // 
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            // 
            // UserNo
            // 
            this.UserNo.HeaderText = "用户编号";
            this.UserNo.Name = "UserNo";
            this.UserNo.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "姓名";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Psw
            // 
            this.Psw.HeaderText = "密码";
            this.Psw.Name = "Psw";
            this.Psw.ReadOnly = true;
            this.Psw.Width = 120;
            // 
            // RoleName
            // 
            this.RoleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoleName.HeaderText = "角色";
            this.RoleName.Name = "RoleName";
            this.RoleName.ReadOnly = true;
            // 
            // RoleId
            // 
            this.RoleId.HeaderText = "RoleId";
            this.RoleId.Name = "RoleId";
            this.RoleId.ReadOnly = true;
            this.RoleId.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblName);
            this.groupBox3.Controls.Add(this.txtPsw);
            this.groupBox3.Controls.Add(this.btnUserSave);
            this.groupBox3.Controls.Add(this.cboRole);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblPsw);
            this.groupBox3.Controls.Add(this.txtUserName);
            this.groupBox3.Controls.Add(this.txtUserNo);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 131);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "姓    名";
            // 
            // txtPsw
            // 
            this.txtPsw.Location = new System.Drawing.Point(323, 14);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(100, 21);
            this.txtPsw.TabIndex = 2;
            // 
            // btnUserSave
            // 
            this.btnUserSave.Location = new System.Drawing.Point(348, 89);
            this.btnUserSave.Name = "btnUserSave";
            this.btnUserSave.Size = new System.Drawing.Size(75, 23);
            this.btnUserSave.TabIndex = 5;
            this.btnUserSave.Text = "保存";
            this.btnUserSave.UseVisualStyleBackColor = true;
            this.btnUserSave.Click += new System.EventHandler(this.btnUserSave_Click);
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(323, 52);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(100, 20);
            this.cboRole.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "角色";
            // 
            // lblPsw
            // 
            this.lblPsw.AutoSize = true;
            this.lblPsw.Location = new System.Drawing.Point(264, 17);
            this.lblPsw.Name = "lblPsw";
            this.lblPsw.Size = new System.Drawing.Size(29, 12);
            this.lblPsw.TabIndex = 4;
            this.lblPsw.Text = "密码";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(65, 52);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 3;
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(65, 14);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(100, 21);
            this.txtUserNo.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "用户编号";
            // 
            // tpRoomSet
            // 
            this.tpRoomSet.Controls.Add(this.dgvRoomInfo);
            this.tpRoomSet.Controls.Add(this.groupBox1);
            this.tpRoomSet.Location = new System.Drawing.Point(4, 21);
            this.tpRoomSet.Name = "tpRoomSet";
            this.tpRoomSet.Padding = new System.Windows.Forms.Padding(3);
            this.tpRoomSet.Size = new System.Drawing.Size(524, 504);
            this.tpRoomSet.TabIndex = 0;
            this.tpRoomSet.Text = "房间设置";
            this.tpRoomSet.UseVisualStyleBackColor = true;
            // 
            // dgvRoomInfo
            // 
            this.dgvRoomInfo.AllowUserToAddRows = false;
            this.dgvRoomInfo.AllowUserToResizeRows = false;
            this.dgvRoomInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoomInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomId,
            this.RoomNo,
            this.RoomTypeDesc,
            this.RoomType,
            this.RoomRate,
            this.RoomPhone,
            this.FloorNo,
            this.FloorId});
            this.dgvRoomInfo.Location = new System.Drawing.Point(6, 143);
            this.dgvRoomInfo.MultiSelect = false;
            this.dgvRoomInfo.Name = "dgvRoomInfo";
            this.dgvRoomInfo.ReadOnly = true;
            this.dgvRoomInfo.RowHeadersVisible = false;
            this.dgvRoomInfo.RowTemplate.Height = 23;
            this.dgvRoomInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomInfo.Size = new System.Drawing.Size(515, 353);
            this.dgvRoomInfo.TabIndex = 7;
            this.dgvRoomInfo.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvRoomInfo_UserDeletingRow);
            this.dgvRoomInfo.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvRoomInfo_UserDeletedRow);
            this.dgvRoomInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRoomInfo_CellMouseDoubleClick);
            // 
            // RoomId
            // 
            this.RoomId.HeaderText = "RoomId";
            this.RoomId.Name = "RoomId";
            this.RoomId.ReadOnly = true;
            this.RoomId.Visible = false;
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "房间号";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            // 
            // RoomTypeDesc
            // 
            this.RoomTypeDesc.HeaderText = "房间类型";
            this.RoomTypeDesc.Name = "RoomTypeDesc";
            this.RoomTypeDesc.ReadOnly = true;
            // 
            // RoomType
            // 
            this.RoomType.HeaderText = "RoomType";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            this.RoomType.Visible = false;
            // 
            // RoomRate
            // 
            this.RoomRate.HeaderText = "房间价格";
            this.RoomRate.Name = "RoomRate";
            this.RoomRate.ReadOnly = true;
            // 
            // RoomPhone
            // 
            this.RoomPhone.HeaderText = "房间电话";
            this.RoomPhone.Name = "RoomPhone";
            this.RoomPhone.ReadOnly = true;
            // 
            // FloorNo
            // 
            this.FloorNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FloorNo.HeaderText = "楼层";
            this.FloorNo.Name = "FloorNo";
            this.FloorNo.ReadOnly = true;
            // 
            // FloorId
            // 
            this.FloorId.HeaderText = "FloorId";
            this.FloorId.Name = "FloorId";
            this.FloorId.ReadOnly = true;
            this.FloorId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRoomSave);
            this.groupBox1.Controls.Add(this.cboRoomType);
            this.groupBox1.Controls.Add(this.cboFloor);
            this.groupBox1.Controls.Add(this.txtRoomPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRoomRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRoomNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnRoomSave
            // 
            this.btnRoomSave.Location = new System.Drawing.Point(348, 89);
            this.btnRoomSave.Name = "btnRoomSave";
            this.btnRoomSave.Size = new System.Drawing.Size(75, 23);
            this.btnRoomSave.TabIndex = 6;
            this.btnRoomSave.Text = "保存";
            this.btnRoomSave.UseVisualStyleBackColor = true;
            this.btnRoomSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboRoomType
            // 
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.Location = new System.Drawing.Point(323, 52);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(100, 20);
            this.cboRoomType.TabIndex = 5;
            // 
            // cboFloor
            // 
            this.cboFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFloor.FormattingEnabled = true;
            this.cboFloor.Location = new System.Drawing.Point(323, 14);
            this.cboFloor.Name = "cboFloor";
            this.cboFloor.Size = new System.Drawing.Size(100, 20);
            this.cboFloor.TabIndex = 4;
            // 
            // txtRoomPhone
            // 
            this.txtRoomPhone.Location = new System.Drawing.Point(65, 91);
            this.txtRoomPhone.Name = "txtRoomPhone";
            this.txtRoomPhone.Size = new System.Drawing.Size(100, 21);
            this.txtRoomPhone.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "房间类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "楼   层";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "房间电话";
            // 
            // txtRoomRate
            // 
            this.txtRoomRate.Location = new System.Drawing.Point(65, 52);
            this.txtRoomRate.Name = "txtRoomRate";
            this.txtRoomRate.Size = new System.Drawing.Size(100, 21);
            this.txtRoomRate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "房间价格";
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.Location = new System.Drawing.Point(65, 14);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(100, 21);
            this.txtRoomNo.TabIndex = 1;
            this.txtRoomNo.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "房间号";
            // 
            // tpParamterSet
            // 
            this.tpParamterSet.Controls.Add(this.label12);
            this.tpParamterSet.Controls.Add(this.dgvParamList);
            this.tpParamterSet.Location = new System.Drawing.Point(4, 21);
            this.tpParamterSet.Name = "tpParamterSet";
            this.tpParamterSet.Size = new System.Drawing.Size(524, 504);
            this.tpParamterSet.TabIndex = 3;
            this.tpParamterSet.Text = "系统参数设定";
            this.tpParamterSet.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(4, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(247, 36);
            this.label12.TabIndex = 9;
            this.label12.Text = "系统参数表请勿随意修改!\r\n错误的数据将会导致程序运行出错!\r\n如需修改,请双击对应的值.空值无需修改!";
            // 
            // dgvParamList
            // 
            this.dgvParamList.AllowUserToAddRows = false;
            this.dgvParamList.AllowUserToDeleteRows = false;
            this.dgvParamList.AllowUserToResizeRows = false;
            this.dgvParamList.BackgroundColor = System.Drawing.Color.White;
            this.dgvParamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamId,
            this.ParamName,
            this.ParamDesc,
            this.Value1,
            this.Value2,
            this.Value3});
            this.dgvParamList.Location = new System.Drawing.Point(6, 52);
            this.dgvParamList.MultiSelect = false;
            this.dgvParamList.Name = "dgvParamList";
            this.dgvParamList.RowHeadersVisible = false;
            this.dgvParamList.RowTemplate.Height = 23;
            this.dgvParamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParamList.Size = new System.Drawing.Size(515, 449);
            this.dgvParamList.TabIndex = 8;
            this.dgvParamList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParamList_CellEndEdit);
            this.dgvParamList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParamList_CellEnter);
            // 
            // ParamId
            // 
            this.ParamId.HeaderText = "ParamId";
            this.ParamId.Name = "ParamId";
            this.ParamId.Visible = false;
            // 
            // ParamName
            // 
            this.ParamName.HeaderText = "参数名称";
            this.ParamName.Name = "ParamName";
            this.ParamName.ReadOnly = true;
            this.ParamName.Width = 120;
            // 
            // ParamDesc
            // 
            this.ParamDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ParamDesc.HeaderText = "参数描述";
            this.ParamDesc.Name = "ParamDesc";
            this.ParamDesc.ReadOnly = true;
            // 
            // Value1
            // 
            this.Value1.HeaderText = "值1";
            this.Value1.Name = "Value1";
            this.Value1.Width = 60;
            // 
            // Value2
            // 
            this.Value2.HeaderText = "值2";
            this.Value2.Name = "Value2";
            this.Value2.Width = 60;
            // 
            // Value3
            // 
            this.Value3.HeaderText = "值3";
            this.Value3.Name = "Value3";
            this.Value3.Width = 60;
            // 
            // tpOtherSet
            // 
            this.tpOtherSet.Location = new System.Drawing.Point(4, 21);
            this.tpOtherSet.Name = "tpOtherSet";
            this.tpOtherSet.Size = new System.Drawing.Size(524, 504);
            this.tpOtherSet.TabIndex = 4;
            this.tpOtherSet.Text = "其他设置";
            this.tpOtherSet.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(556, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblStatus
            // 
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(467, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "新增请直接按保存.修改信息请双击列表,按保存提交.删除房间请选中项目后按Delete键";
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 581);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormControl";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.FormControl_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormControl_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tpGoodsSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpSysUserSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tpRoomSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpParamterSet.ResumeLayout(false);
            this.tpParamterSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamList)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpRoomSet;
        private System.Windows.Forms.TabPage tpGoodsSet;
        private System.Windows.Forms.TabPage tpSysUserSet;
        private System.Windows.Forms.TabPage tpParamterSet;
        private System.Windows.Forms.TabPage tpOtherSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRoomInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.TextBox txtRoomRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoomNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoomPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFloor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRoomSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTypeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn FloorNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FloorId;
        private System.Windows.Forms.DataGridView dgvGoodsList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGoodsSave;
        private System.Windows.Forms.ComboBox cboGoodsStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGoodsUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGoodsName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGoodsPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.Button btnUserSave;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPsw;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Psw;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvParamList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value3;
        private System.Windows.Forms.Label label12;
    }
}