namespace Hotel
{
    partial class FormOneCustomer
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRoomInfo = new System.Windows.Forms.Label();
            this.lblRoomRate = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboPayType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRoomMsg = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.chkHourRoom = new System.Windows.Forms.CheckBox();
            this.txtCustomerNumber = new System.Windows.Forms.TextBox();
            this.txtCurrentRate = new System.Windows.Forms.TextBox();
            this.txtDiskonRate = new System.Windows.Forms.TextBox();
            this.txtCurrentDeposit = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.pbxUserImg = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.cboCustomerType = new System.Windows.Forms.ComboBox();
            this.btnReadIDCard = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.dgvCustomerInfo = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOffHotel = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUserImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRoomInfo);
            this.groupBox1.Controls.Add(this.lblRoomRate);
            this.groupBox1.Controls.Add(this.lblRoomType);
            this.groupBox1.Controls.Add(this.lblRoom);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "房间信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "预设价格:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "房间类型:";
            // 
            // lblRoomInfo
            // 
            this.lblRoomInfo.AutoSize = true;
            this.lblRoomInfo.Location = new System.Drawing.Point(84, 32);
            this.lblRoomInfo.Name = "lblRoomInfo";
            this.lblRoomInfo.Size = new System.Drawing.Size(0, 12);
            this.lblRoomInfo.TabIndex = 0;
            // 
            // lblRoomRate
            // 
            this.lblRoomRate.AutoSize = true;
            this.lblRoomRate.Location = new System.Drawing.Point(419, 32);
            this.lblRoomRate.Name = "lblRoomRate";
            this.lblRoomRate.Size = new System.Drawing.Size(0, 12);
            this.lblRoomRate.TabIndex = 0;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new System.Drawing.Point(233, 32);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(0, 12);
            this.lblRoomType.TabIndex = 0;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Location = new System.Drawing.Point(19, 32);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(59, 12);
            this.lblRoom.TabIndex = 0;
            this.lblRoom.Text = "房间号码:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(13, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(583, 400);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(572, 374);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboPayType);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.lblRoomMsg);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.txtNotice);
            this.tabPage1.Controls.Add(this.chkHourRoom);
            this.tabPage1.Controls.Add(this.txtCustomerNumber);
            this.tabPage1.Controls.Add(this.txtCurrentRate);
            this.tabPage1.Controls.Add(this.txtDiskonRate);
            this.tabPage1.Controls.Add(this.txtCurrentDeposit);
            this.tabPage1.Controls.Add(this.txtDay);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(558, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "客房信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboPayType
            // 
            this.cboPayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayType.FormattingEnabled = true;
            this.cboPayType.Location = new System.Drawing.Point(317, 81);
            this.cboPayType.Name = "cboPayType";
            this.cboPayType.Size = new System.Drawing.Size(99, 20);
            this.cboPayType.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "付款方式:";
            // 
            // lblRoomMsg
            // 
            this.lblRoomMsg.AutoSize = true;
            this.lblRoomMsg.ForeColor = System.Drawing.Color.Red;
            this.lblRoomMsg.Location = new System.Drawing.Point(80, 153);
            this.lblRoomMsg.Name = "lblRoomMsg";
            this.lblRoomMsg.Size = new System.Drawing.Size(0, 12);
            this.lblRoomMsg.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 6;
            this.label18.Text = "支付备注:";
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(80, 114);
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(336, 21);
            this.txtNotice.TabIndex = 5;
            // 
            // chkHourRoom
            // 
            this.chkHourRoom.AutoSize = true;
            this.chkHourRoom.Location = new System.Drawing.Point(18, 150);
            this.chkHourRoom.Name = "chkHourRoom";
            this.chkHourRoom.Size = new System.Drawing.Size(60, 16);
            this.chkHourRoom.TabIndex = 3;
            this.chkHourRoom.Text = "钟点房";
            this.chkHourRoom.UseVisualStyleBackColor = true;
            this.chkHourRoom.CheckedChanged += new System.EventHandler(this.chkHourRoom_CheckedChanged);
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(81, 81);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerNumber.TabIndex = 1;
            this.txtCustomerNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDay_KeyPress);
            // 
            // txtCurrentRate
            // 
            this.txtCurrentRate.Location = new System.Drawing.Point(316, 49);
            this.txtCurrentRate.Name = "txtCurrentRate";
            this.txtCurrentRate.Size = new System.Drawing.Size(100, 21);
            this.txtCurrentRate.TabIndex = 1;
            this.txtCurrentRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentRate_KeyPress);
            // 
            // txtDiskonRate
            // 
            this.txtDiskonRate.Location = new System.Drawing.Point(81, 49);
            this.txtDiskonRate.Name = "txtDiskonRate";
            this.txtDiskonRate.Size = new System.Drawing.Size(100, 21);
            this.txtDiskonRate.TabIndex = 1;
            this.txtDiskonRate.TextChanged += new System.EventHandler(this.txtDiskonRate_TextChanged);
            this.txtDiskonRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiskonRate_KeyPress);
            // 
            // txtCurrentDeposit
            // 
            this.txtCurrentDeposit.Location = new System.Drawing.Point(316, 16);
            this.txtCurrentDeposit.Name = "txtCurrentDeposit";
            this.txtCurrentDeposit.Size = new System.Drawing.Size(100, 21);
            this.txtCurrentDeposit.TabIndex = 1;
            this.txtCurrentDeposit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentRate_KeyPress);
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(81, 16);
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(100, 21);
            this.txtDay.TabIndex = 1;
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDay_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "宾客人数:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "打折比率:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "实际单价:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(251, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "实收押金:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "预住天数:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.pbxUserImg);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblMsg);
            this.tabPage2.Controls.Add(this.cboSex);
            this.tabPage2.Controls.Add(this.txtAddress);
            this.tabPage2.Controls.Add(this.txtCompany);
            this.tabPage2.Controls.Add(this.txtIDCard);
            this.tabPage2.Controls.Add(this.txtPhone);
            this.tabPage2.Controls.Add(this.txtCustomerName);
            this.tabPage2.Controls.Add(this.cboCustomerType);
            this.tabPage2.Controls.Add(this.btnReadIDCard);
            this.tabPage2.Controls.Add(this.btnAddCustomer);
            this.tabPage2.Controls.Add(this.dgvCustomerInfo);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(564, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "宾客信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(8, 330);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(327, 12);
            this.label20.TabIndex = 11;
            this.label20.Text = "如宾格信息登记错误,请用按delete键删除列表中的宾客";
            // 
            // pbxUserImg
            // 
            this.pbxUserImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxUserImg.Location = new System.Drawing.Point(447, 7);
            this.pbxUserImg.Name = "pbxUserImg";
            this.pbxUserImg.Size = new System.Drawing.Size(105, 127);
            this.pbxUserImg.TabIndex = 10;
            this.pbxUserImg.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "第一个默认为主客";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(18, 147);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 6;
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(313, 36);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(100, 20);
            this.cboSex.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(77, 94);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(336, 21);
            this.txtAddress.TabIndex = 7;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(77, 64);
            this.txtCompany.MaxLength = 100;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(175, 21);
            this.txtCompany.TabIndex = 5;
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(77, 36);
            this.txtIDCard.MaxLength = 18;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(175, 21);
            this.txtIDCard.TabIndex = 3;
            this.txtIDCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDCard_KeyPress);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(313, 62);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 21);
            this.txtPhone.TabIndex = 6;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(313, 7);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerName.TabIndex = 2;
            // 
            // cboCustomerType
            // 
            this.cboCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerType.FormattingEnabled = true;
            this.cboCustomerType.Location = new System.Drawing.Point(77, 9);
            this.cboCustomerType.Name = "cboCustomerType";
            this.cboCustomerType.Size = new System.Drawing.Size(86, 20);
            this.cboCustomerType.TabIndex = 1;
            // 
            // btnReadIDCard
            // 
            this.btnReadIDCard.Location = new System.Drawing.Point(477, 141);
            this.btnReadIDCard.Name = "btnReadIDCard";
            this.btnReadIDCard.Size = new System.Drawing.Size(75, 23);
            this.btnReadIDCard.TabIndex = 8;
            this.btnReadIDCard.Text = "读取身份证";
            this.btnReadIDCard.UseVisualStyleBackColor = true;
            this.btnReadIDCard.Click += new System.EventHandler(this.btnReadIDCard_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(313, 121);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(100, 23);
            this.btnAddCustomer.TabIndex = 8;
            this.btnAddCustomer.Text = "提交宾客信息";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // dgvCustomerInfo
            // 
            this.dgvCustomerInfo.AllowUserToAddRows = false;
            this.dgvCustomerInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.CustomerName,
            this.Sex,
            this.IDCard,
            this.Phone,
            this.Nation,
            this.Birthday,
            this.Company,
            this.Address,
            this.CustomerId});
            this.dgvCustomerInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCustomerInfo.Location = new System.Drawing.Point(6, 168);
            this.dgvCustomerInfo.MultiSelect = false;
            this.dgvCustomerInfo.Name = "dgvCustomerInfo";
            this.dgvCustomerInfo.ReadOnly = true;
            this.dgvCustomerInfo.RowHeadersVisible = false;
            this.dgvCustomerInfo.RowTemplate.Height = 23;
            this.dgvCustomerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerInfo.ShowEditingIcon = false;
            this.dgvCustomerInfo.Size = new System.Drawing.Size(546, 134);
            this.dgvCustomerInfo.TabIndex = 1;
            this.dgvCustomerInfo.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCustomerInfo_UserDeletingRow);
            this.dgvCustomerInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerInfo_CellDoubleClick);
            this.dgvCustomerInfo.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomerInfo_CellMouseDown);
            this.dgvCustomerInfo.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvCustomerInfo_UserDeletedRow);
            // 
            // Type
            // 
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 60;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 80;
            // 
            // Sex
            // 
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Width = 60;
            // 
            // IDCard
            // 
            this.IDCard.HeaderText = "证件号码";
            this.IDCard.Name = "IDCard";
            this.IDCard.ReadOnly = true;
            this.IDCard.Width = 120;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "电话";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 80;
            // 
            // Nation
            // 
            this.Nation.HeaderText = "民族";
            this.Nation.Name = "Nation";
            this.Nation.ReadOnly = true;
            this.Nation.Width = 60;
            // 
            // Birthday
            // 
            this.Birthday.HeaderText = "出生年月";
            this.Birthday.Name = "Birthday";
            this.Birthday.ReadOnly = true;
            // 
            // Company
            // 
            this.Company.HeaderText = "公司";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.HeaderText = "地址";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 120;
            // 
            // CustomerId
            // 
            this.CustomerId.HeaderText = "宾客编号";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOffHotel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // tsmOffHotel
            // 
            this.tsmOffHotel.Name = "tsmOffHotel";
            this.tsmOffHotel.Size = new System.Drawing.Size(94, 22);
            this.tsmOffHotel.Text = "离店";
            this.tsmOffHotel.Click += new System.EventHandler(this.tsmOffHotel_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(259, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(419, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "姓名:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 94);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "地址信息:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "公司名称:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(274, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "电话:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(274, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "性别:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "证件编码:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "宾客类型:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(111, 503);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(368, 503);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(8, 308);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(561, 12);
            this.label21.TabIndex = 12;
            this.label21.Text = "如宾客事先离店,请右击宾客列表,选择\"离店\"操作.不可使用删除功能,否则将无法找到宾客记录.";
            // 
            // FormOneCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(608, 543);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormOneCustomer";
            this.Text = "散客开单";
            this.Load += new System.EventHandler(this.FormOneCustomer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUserImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtDiskonRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCurrentRate;
        private System.Windows.Forms.TextBox txtCurrentDeposit;
        private System.Windows.Forms.CheckBox chkHourRoom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblRoomInfo;
        private System.Windows.Forms.Label lblRoomRate;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.DataGridView dgvCustomerInfo;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ComboBox cboCustomerType;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblRoomMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReadIDCard;
        private System.Windows.Forms.PictureBox pbxUserImg;
        private System.Windows.Forms.ComboBox cboPayType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmOffHotel;
        private System.Windows.Forms.Label label21;
    }
}