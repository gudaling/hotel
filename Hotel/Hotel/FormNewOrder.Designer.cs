namespace Hotel
{
    partial class FormNewOrder
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pbtnAdd = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.cboHourE = new System.Windows.Forms.ComboBox();
            this.cboHourS = new System.Windows.Forms.ComboBox();
            this.cboHourK = new System.Windows.Forms.ComboBox();
            this.dtpKeepDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvRoomNo = new System.Windows.Forms.DataGridView();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbOrdered = new System.Windows.Forms.GroupBox();
            this.dgvOrdered = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboRoomNo = new System.Windows.Forms.ComboBox();
            this.cboRoomType = new System.Windows.Forms.ComboBox();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.txtRoomRate = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnAdd)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomNo)).BeginInit();
            this.gbOrdered.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdered)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.pbtnAdd);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.cboHourE);
            this.groupBox1.Controls.Add(this.cboHourS);
            this.groupBox1.Controls.Add(this.cboHourK);
            this.groupBox1.Controls.Add(this.dtpKeepDate);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.gbOrdered);
            this.groupBox1.Controls.Add(this.cboRoomNo);
            this.groupBox1.Controls.Add(this.cboRoomType);
            this.groupBox1.Controls.Add(this.txtNotice);
            this.groupBox1.Controls.Add(this.txtIDCard);
            this.groupBox1.Controls.Add(this.txtRoomRate);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 364);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "添加预定";
            // 
            // pbtnAdd
            // 
            this.pbtnAdd.BackgroundImage = global::Hotel.Properties.Resources.Right;
            this.pbtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnAdd.Location = new System.Drawing.Point(78, 357);
            this.pbtnAdd.Name = "pbtnAdd";
            this.pbtnAdd.Size = new System.Drawing.Size(38, 32);
            this.pbtnAdd.TabIndex = 22;
            this.pbtnAdd.TabStop = false;
            this.pbtnAdd.MouseLeave += new System.EventHandler(this.pbtnAdd_MouseLeave);
            this.pbtnAdd.Click += new System.EventHandler(this.pbtnAdd_Click);
            this.pbtnAdd.MouseEnter += new System.EventHandler(this.pbtnAdd_MouseEnter);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.OldLace;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(247, 364);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 21;
            // 
            // cboHourE
            // 
            this.cboHourE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHourE.FormattingEnabled = true;
            this.cboHourE.Location = new System.Drawing.Point(174, 150);
            this.cboHourE.Name = "cboHourE";
            this.cboHourE.Size = new System.Drawing.Size(40, 20);
            this.cboHourE.TabIndex = 20;
            // 
            // cboHourS
            // 
            this.cboHourS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHourS.FormattingEnabled = true;
            this.cboHourS.Location = new System.Drawing.Point(174, 119);
            this.cboHourS.Name = "cboHourS";
            this.cboHourS.Size = new System.Drawing.Size(40, 20);
            this.cboHourS.TabIndex = 20;
            this.cboHourS.SelectedIndexChanged += new System.EventHandler(this.cboHourS_SelectedIndexChanged);
            // 
            // cboHourK
            // 
            this.cboHourK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHourK.FormattingEnabled = true;
            this.cboHourK.Location = new System.Drawing.Point(174, 182);
            this.cboHourK.Name = "cboHourK";
            this.cboHourK.Size = new System.Drawing.Size(40, 20);
            this.cboHourK.TabIndex = 20;
            // 
            // dtpKeepDate
            // 
            this.dtpKeepDate.Location = new System.Drawing.Point(77, 181);
            this.dtpKeepDate.Name = "dtpKeepDate";
            this.dtpKeepDate.Size = new System.Drawing.Size(91, 21);
            this.dtpKeepDate.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(77, 150);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(91, 21);
            this.dtpEndDate.TabIndex = 5;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(78, 118);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(90, 21);
            this.dtpStartDate.TabIndex = 4;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "保留时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "预离时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "预抵时间";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvRoomNo);
            this.groupBox3.Location = new System.Drawing.Point(243, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 144);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "本次预定的房间";
            // 
            // dgvRoomNo
            // 
            this.dgvRoomNo.AllowUserToAddRows = false;
            this.dgvRoomNo.AllowUserToDeleteRows = false;
            this.dgvRoomNo.AllowUserToResizeRows = false;
            this.dgvRoomNo.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoomNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomNo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomType,
            this.RoomNo});
            this.dgvRoomNo.Location = new System.Drawing.Point(6, 14);
            this.dgvRoomNo.MultiSelect = false;
            this.dgvRoomNo.Name = "dgvRoomNo";
            this.dgvRoomNo.ReadOnly = true;
            this.dgvRoomNo.RowHeadersVisible = false;
            this.dgvRoomNo.RowTemplate.Height = 23;
            this.dgvRoomNo.Size = new System.Drawing.Size(326, 124);
            this.dgvRoomNo.TabIndex = 17;
            // 
            // RoomType
            // 
            this.RoomType.HeaderText = "房间类型";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            this.RoomType.Width = 150;
            // 
            // RoomNo
            // 
            this.RoomNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoomNo.HeaderText = "房间编号";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            // 
            // gbOrdered
            // 
            this.gbOrdered.Controls.Add(this.dgvOrdered);
            this.gbOrdered.Location = new System.Drawing.Point(243, 20);
            this.gbOrdered.Name = "gbOrdered";
            this.gbOrdered.Size = new System.Drawing.Size(338, 188);
            this.gbOrdered.TabIndex = 4;
            this.gbOrdered.TabStop = false;
            this.gbOrdered.Text = "已预定xx房的宾客";
            // 
            // dgvOrdered
            // 
            this.dgvOrdered.AllowUserToAddRows = false;
            this.dgvOrdered.AllowUserToDeleteRows = false;
            this.dgvOrdered.AllowUserToResizeRows = false;
            this.dgvOrdered.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdered.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.StartDate,
            this.Phone});
            this.dgvOrdered.Location = new System.Drawing.Point(7, 21);
            this.dgvOrdered.MultiSelect = false;
            this.dgvOrdered.Name = "dgvOrdered";
            this.dgvOrdered.ReadOnly = true;
            this.dgvOrdered.RowHeadersVisible = false;
            this.dgvOrdered.RowTemplate.Height = 23;
            this.dgvOrdered.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdered.Size = new System.Drawing.Size(325, 161);
            this.dgvOrdered.TabIndex = 16;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "宾客姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "预抵时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 120;
            // 
            // Phone
            // 
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phone.HeaderText = "联系电话";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // cboRoomNo
            // 
            this.cboRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomNo.FormattingEnabled = true;
            this.cboRoomNo.Location = new System.Drawing.Point(77, 242);
            this.cboRoomNo.Name = "cboRoomNo";
            this.cboRoomNo.Size = new System.Drawing.Size(139, 20);
            this.cboRoomNo.TabIndex = 8;
            this.cboRoomNo.SelectedIndexChanged += new System.EventHandler(this.cboRoomNo_SelectedIndexChanged);
            // 
            // cboRoomType
            // 
            this.cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.Location = new System.Drawing.Point(77, 211);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(139, 20);
            this.cboRoomType.TabIndex = 7;
            this.cboRoomType.SelectedIndexChanged += new System.EventHandler(this.cboRoomType_SelectedIndexChanged);
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(76, 305);
            this.txtNotice.MaxLength = 200;
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(140, 47);
            this.txtNotice.TabIndex = 12;
            // 
            // txtIDCard
            // 
            this.txtIDCard.Location = new System.Drawing.Point(77, 51);
            this.txtIDCard.MaxLength = 18;
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(139, 21);
            this.txtIDCard.TabIndex = 2;
            this.txtIDCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDCard_KeyPress);
            // 
            // txtRoomRate
            // 
            this.txtRoomRate.Location = new System.Drawing.Point(76, 274);
            this.txtRoomRate.Name = "txtRoomRate";
            this.txtRoomRate.Size = new System.Drawing.Size(139, 21);
            this.txtRoomRate.TabIndex = 19;
            this.txtRoomRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomRate_KeyPress);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(77, 85);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(139, 21);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(139, 21);
            this.txtName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "备注信息";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "房间价格";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "房间编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "房间类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "证件号码";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(222, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(222, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(222, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "联系电话";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "宾客姓名";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(152, 418);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(383, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormNewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(612, 453);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormNewOrder";
            this.Text = "宾客预定";
            this.Load += new System.EventHandler(this.FormNewOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnAdd)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomNo)).EndInit();
            this.gbOrdered.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdered)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRoomNo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbOrdered;
        private System.Windows.Forms.DataGridView dgvOrdered;
        private System.Windows.Forms.DataGridView dgvRoomNo;
        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRoomRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpKeepDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboHourK;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.ComboBox cboHourE;
        private System.Windows.Forms.ComboBox cboHourS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.PictureBox pbtnAdd;
        private System.Windows.Forms.Label label14;
    }
}