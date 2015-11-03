namespace Hotel
{
    partial class FormTeamCustomers
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
            this.tvEnableRoom = new System.Windows.Forms.TreeView();
            this.dgvSelectedRoom = new System.Windows.Forms.DataGridView();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diskon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomRateNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoomOrName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAvgDeposit = new System.Windows.Forms.CheckBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.txtStayDays = new System.Windows.Forms.TextBox();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.cboMainRoom = new System.Windows.Forms.ComboBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.cboPayType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbtnRemove = new System.Windows.Forms.PictureBox();
            this.pbtnAdd = new System.Windows.Forms.PictureBox();
            this.pbxUserImg = new System.Windows.Forms.PictureBox();
            this.btnReadIDCard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedRoom)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUserImg)).BeginInit();
            this.SuspendLayout();
            // 
            // tvEnableRoom
            // 
            this.tvEnableRoom.HideSelection = false;
            this.tvEnableRoom.Location = new System.Drawing.Point(12, 40);
            this.tvEnableRoom.Name = "tvEnableRoom";
            this.tvEnableRoom.Size = new System.Drawing.Size(174, 187);
            this.tvEnableRoom.TabIndex = 0;
            this.tvEnableRoom.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvEnableRoom_NodeMouseDoubleClick);
            // 
            // dgvSelectedRoom
            // 
            this.dgvSelectedRoom.AllowUserToAddRows = false;
            this.dgvSelectedRoom.AllowUserToDeleteRows = false;
            this.dgvSelectedRoom.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectedRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomType,
            this.RoomNo,
            this.RoomRate,
            this.Diskon,
            this.RoomRateNow});
            this.dgvSelectedRoom.Location = new System.Drawing.Point(228, 40);
            this.dgvSelectedRoom.Name = "dgvSelectedRoom";
            this.dgvSelectedRoom.ReadOnly = true;
            this.dgvSelectedRoom.RowHeadersVisible = false;
            this.dgvSelectedRoom.RowTemplate.Height = 23;
            this.dgvSelectedRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedRoom.ShowEditingIcon = false;
            this.dgvSelectedRoom.Size = new System.Drawing.Size(351, 187);
            this.dgvSelectedRoom.TabIndex = 1;
            this.dgvSelectedRoom.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSelectedRoom_CellMouseDoubleClick);
            // 
            // RoomType
            // 
            this.RoomType.HeaderText = "房间类型";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "房间号";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            this.RoomNo.Width = 80;
            // 
            // RoomRate
            // 
            this.RoomRate.HeaderText = "原房价";
            this.RoomRate.Name = "RoomRate";
            this.RoomRate.ReadOnly = true;
            this.RoomRate.Width = 80;
            // 
            // Diskon
            // 
            this.Diskon.HeaderText = "折扣";
            this.Diskon.Name = "Diskon";
            this.Diskon.ReadOnly = true;
            this.Diskon.Width = 60;
            // 
            // RoomRateNow
            // 
            this.RoomRateNow.HeaderText = "折后房价";
            this.RoomRateNow.Name = "RoomRateNow";
            this.RoomRateNow.ReadOnly = true;
            this.RoomRateNow.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "房间号";
            // 
            // txtRoomOrName
            // 
            this.txtRoomOrName.Location = new System.Drawing.Point(57, 12);
            this.txtRoomOrName.Name = "txtRoomOrName";
            this.txtRoomOrName.Size = new System.Drawing.Size(129, 21);
            this.txtRoomOrName.TabIndex = 0;
            this.txtRoomOrName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomOrName_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbxUserImg);
            this.groupBox1.Controls.Add(this.chkAvgDeposit);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtDeposit);
            this.groupBox1.Controls.Add(this.txtStayDays);
            this.groupBox1.Controls.Add(this.txtNotice);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtCompany);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.txtIDCard);
            this.groupBox1.Controls.Add(this.cboMainRoom);
            this.groupBox1.Controls.Add(this.cboSex);
            this.groupBox1.Controls.Add(this.cboPayType);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 237);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "宾客信息";
            // 
            // chkAvgDeposit
            // 
            this.chkAvgDeposit.AutoSize = true;
            this.chkAvgDeposit.Location = new System.Drawing.Point(19, 178);
            this.chkAvgDeposit.Name = "chkAvgDeposit";
            this.chkAvgDeposit.Size = new System.Drawing.Size(96, 16);
            this.chkAvgDeposit.TabIndex = 13;
            this.chkAvgDeposit.Text = "平均分配押金";
            this.chkAvgDeposit.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(76, 106);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(292, 21);
            this.txtAddress.TabIndex = 10;
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(454, 79);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(81, 21);
            this.txtDeposit.TabIndex = 11;
            this.txtDeposit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeposit_KeyPress);
            // 
            // txtStayDays
            // 
            this.txtStayDays.Location = new System.Drawing.Point(454, 51);
            this.txtStayDays.Name = "txtStayDays";
            this.txtStayDays.Size = new System.Drawing.Size(81, 21);
            this.txtStayDays.TabIndex = 9;
            this.txtStayDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStayDays_KeyPress);
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(76, 135);
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(292, 21);
            this.txtNotice.TabIndex = 12;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(234, 79);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(134, 21);
            this.txtPhone.TabIndex = 8;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(234, 51);
            this.txtCompany.MaxLength = 100;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(134, 21);
            this.txtCompany.TabIndex = 5;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(73, 22);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(84, 21);
            this.txtCustomerName.TabIndex = 1;
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(234, 22);
            this.txtIDCard.MaxLength = 18;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(134, 21);
            this.txtIDCard.TabIndex = 2;
            this.txtIDCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDCard_KeyPress);
            // 
            // cboMainRoom
            // 
            this.cboMainRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainRoom.FormattingEnabled = true;
            this.cboMainRoom.Location = new System.Drawing.Point(454, 23);
            this.cboMainRoom.Name = "cboMainRoom";
            this.cboMainRoom.Size = new System.Drawing.Size(81, 20);
            this.cboMainRoom.TabIndex = 3;
            // 
            // cboSex
            // 
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboSex.Location = new System.Drawing.Point(76, 51);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(81, 20);
            this.cboSex.TabIndex = 4;
            // 
            // cboPayType
            // 
            this.cboPayType.FormattingEnabled = true;
            this.cboPayType.Location = new System.Drawing.Point(76, 77);
            this.cboPayType.Name = "cboPayType";
            this.cboPayType.Size = new System.Drawing.Size(81, 20);
            this.cboPayType.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(395, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "实收押金";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(395, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "预住天数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "主客房间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "主客性别";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "地址信息";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(175, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "公司名称";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(20, 201);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(541, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(541, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(374, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(161, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "主客姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "证件编码";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "备注信息";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "联系电话";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "付款方式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "开单房间";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(134, 476);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbtnRemove
            // 
            this.pbtnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnRemove.Image = global::Hotel.Properties.Resources.Left;
            this.pbtnRemove.Location = new System.Drawing.Point(192, 140);
            this.pbtnRemove.Name = "pbtnRemove";
            this.pbtnRemove.Size = new System.Drawing.Size(27, 26);
            this.pbtnRemove.TabIndex = 4;
            this.pbtnRemove.TabStop = false;
            this.pbtnRemove.Click += new System.EventHandler(this.pbtnRemove_Click);
            // 
            // pbtnAdd
            // 
            this.pbtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnAdd.Image = global::Hotel.Properties.Resources.Right;
            this.pbtnAdd.Location = new System.Drawing.Point(192, 72);
            this.pbtnAdd.Name = "pbtnAdd";
            this.pbtnAdd.Size = new System.Drawing.Size(27, 26);
            this.pbtnAdd.TabIndex = 4;
            this.pbtnAdd.TabStop = false;
            this.pbtnAdd.Click += new System.EventHandler(this.pbtnAdd_Click);
            // 
            // pbxUserImg
            // 
            this.pbxUserImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxUserImg.Location = new System.Drawing.Point(430, 104);
            this.pbxUserImg.Name = "pbxUserImg";
            this.pbxUserImg.Size = new System.Drawing.Size(105, 127);
            this.pbxUserImg.TabIndex = 14;
            this.pbxUserImg.TabStop = false;
            // 
            // btnReadIDCard
            // 
            this.btnReadIDCard.Location = new System.Drawing.Point(469, 476);
            this.btnReadIDCard.Name = "btnReadIDCard";
            this.btnReadIDCard.Size = new System.Drawing.Size(75, 23);
            this.btnReadIDCard.TabIndex = 15;
            this.btnReadIDCard.Text = "读取身份证";
            this.btnReadIDCard.UseVisualStyleBackColor = true;
            this.btnReadIDCard.Click += new System.EventHandler(this.btnReadIDCard_Click);
            // 
            // FormTeamCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 524);
            this.Controls.Add(this.btnReadIDCard);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbtnRemove);
            this.Controls.Add(this.pbtnAdd);
            this.Controls.Add(this.txtRoomOrName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSelectedRoom);
            this.Controls.Add(this.tvEnableRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTeamCustomers";
            this.Text = "团体开单";
            this.Load += new System.EventHandler(this.FormTeamCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedRoom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUserImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvEnableRoom;
        private System.Windows.Forms.DataGridView dgvSelectedRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoomOrName;
        private System.Windows.Forms.PictureBox pbtnAdd;
        private System.Windows.Forms.PictureBox pbtnRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStayDays;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboPayType;
        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkAvgDeposit;
        private System.Windows.Forms.ComboBox cboMainRoom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diskon;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomRateNow;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.PictureBox pbxUserImg;
        private System.Windows.Forms.Button btnReadIDCard;
    }
}