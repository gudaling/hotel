namespace Hotel
{
    partial class FormRoomDetail
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
            this.cboRoomStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbcRoomInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPayType = new System.Windows.Forms.ComboBox();
            this.dgvCustomerStay = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctmsFunction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsClean = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StayStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tbcRoomInfo.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerStay)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.ctmsFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboRoomStatus
            // 
            this.cboRoomStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboRoomStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoomStatus.FormattingEnabled = true;
            this.cboRoomStatus.Location = new System.Drawing.Point(83, 20);
            this.cboRoomStatus.Name = "cboRoomStatus";
            this.cboRoomStatus.Size = new System.Drawing.Size(91, 20);
            this.cboRoomStatus.TabIndex = 12;
            this.cboRoomStatus.SelectedIndexChanged += new System.EventHandler(this.cboRoomStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "房间状态";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboRoomStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 47);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // tbcRoomInfo
            // 
            this.tbcRoomInfo.Controls.Add(this.tabPage1);
            this.tbcRoomInfo.Controls.Add(this.tabPage2);
            this.tbcRoomInfo.Location = new System.Drawing.Point(12, 66);
            this.tbcRoomInfo.Name = "tbcRoomInfo";
            this.tbcRoomInfo.SelectedIndex = 0;
            this.tbcRoomInfo.Size = new System.Drawing.Size(614, 517);
            this.tbcRoomInfo.TabIndex = 15;
            this.tbcRoomInfo.SelectedIndexChanged += new System.EventHandler(this.tbcRoomInfo_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(606, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cboPayType);
            this.tabPage2.Controls.Add(this.dgvCustomerStay);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(606, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "押金状态";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "支付类型";
            // 
            // cboPayType
            // 
            this.cboPayType.FormattingEnabled = true;
            this.cboPayType.Location = new System.Drawing.Point(65, 6);
            this.cboPayType.Name = "cboPayType";
            this.cboPayType.Size = new System.Drawing.Size(89, 20);
            this.cboPayType.TabIndex = 29;
            this.cboPayType.SelectedIndexChanged += new System.EventHandler(this.cboPayType_SelectedIndexChanged);
            // 
            // dgvCustomerStay
            // 
            this.dgvCustomerStay.AllowUserToAddRows = false;
            this.dgvCustomerStay.AllowUserToDeleteRows = false;
            this.dgvCustomerStay.AllowUserToResizeRows = false;
            this.dgvCustomerStay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomerStay.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomerStay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerStay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNo,
            this.CustomerName,
            this.StartDate,
            this.Deposit,
            this.NeedPay,
            this.Balance,
            this.StayStatus,
            this.PayType,
            this.Notice,
            this.UpdateUserName,
            this.UpdateDate});
            this.dgvCustomerStay.Location = new System.Drawing.Point(0, 38);
            this.dgvCustomerStay.Name = "dgvCustomerStay";
            this.dgvCustomerStay.ReadOnly = true;
            this.dgvCustomerStay.RowHeadersVisible = false;
            this.dgvCustomerStay.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomerStay.RowTemplate.Height = 23;
            this.dgvCustomerStay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerStay.Size = new System.Drawing.Size(600, 448);
            this.dgvCustomerStay.TabIndex = 28;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 587);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(638, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblTotal
            // 
            this.tslblTotal.Name = "tslblTotal";
            this.tslblTotal.Size = new System.Drawing.Size(0, 17);
            // 
            // ctmsFunction
            // 
            this.ctmsFunction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsEnable,
            this.tsClean,
            this.tsDisable});
            this.ctmsFunction.Name = "ctmsFunction";
            this.ctmsFunction.Size = new System.Drawing.Size(119, 70);
            this.ctmsFunction.Opening += new System.ComponentModel.CancelEventHandler(this.ctmsFunction_Opening);
            // 
            // tsEnable
            // 
            this.tsEnable.Name = "tsEnable";
            this.tsEnable.Size = new System.Drawing.Size(118, 22);
            this.tsEnable.Text = "变为可供";
            this.tsEnable.Click += new System.EventHandler(this.tsEnable_Click);
            // 
            // tsClean
            // 
            this.tsClean.Name = "tsClean";
            this.tsClean.Size = new System.Drawing.Size(118, 22);
            this.tsClean.Text = "变为清理";
            this.tsClean.Click += new System.EventHandler(this.tsClean_Click);
            // 
            // tsDisable
            // 
            this.tsDisable.Name = "tsDisable";
            this.tsDisable.Size = new System.Drawing.Size(118, 22);
            this.tsDisable.Text = "变为停用";
            this.tsDisable.Click += new System.EventHandler(this.tsDisable_Click);
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "房间号";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            this.RoomNo.Width = 80;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "宾客姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "进店时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 130;
            // 
            // Deposit
            // 
            this.Deposit.HeaderText = "押金数";
            this.Deposit.Name = "Deposit";
            this.Deposit.ReadOnly = true;
            // 
            // NeedPay
            // 
            this.NeedPay.HeaderText = "消费金额";
            this.NeedPay.Name = "NeedPay";
            this.NeedPay.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.HeaderText = "相差金额";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // StayStatus
            // 
            this.StayStatus.HeaderText = "入住状态";
            this.StayStatus.Name = "StayStatus";
            this.StayStatus.ReadOnly = true;
            // 
            // PayType
            // 
            this.PayType.HeaderText = "支付类型";
            this.PayType.Name = "PayType";
            this.PayType.ReadOnly = true;
            // 
            // Notice
            // 
            this.Notice.HeaderText = "支付备注";
            this.Notice.Name = "Notice";
            this.Notice.ReadOnly = true;
            // 
            // UpdateUserName
            // 
            this.UpdateUserName.HeaderText = "更新人员";
            this.UpdateUserName.Name = "UpdateUserName";
            this.UpdateUserName.ReadOnly = true;
            this.UpdateUserName.Width = 80;
            // 
            // UpdateDate
            // 
            this.UpdateDate.HeaderText = "最后更新时间";
            this.UpdateDate.Name = "UpdateDate";
            this.UpdateDate.ReadOnly = true;
            this.UpdateDate.Width = 130;
            // 
            // FormRoomDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 609);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbcRoomInfo);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRoomDetail";
            this.Text = "FormRoomDetail";
            this.Load += new System.EventHandler(this.FormRoomDetail_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRoomDetail_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbcRoomInfo.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerStay)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctmsFunction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboRoomStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tbcRoomInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblTotal;
        private System.Windows.Forms.ContextMenuStrip ctmsFunction;
        private System.Windows.Forms.ToolStripMenuItem tsEnable;
        private System.Windows.Forms.ToolStripMenuItem tsClean;
        private System.Windows.Forms.ToolStripMenuItem tsDisable;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvCustomerStay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn StayStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notice;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
    }
}