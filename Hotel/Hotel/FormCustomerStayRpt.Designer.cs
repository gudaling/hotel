namespace Hotel
{
    partial class FormCustomerStayRpt
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
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.rptHelper1 = new Hotel.RptHelper();
            this.pbtnSearch = new System.Windows.Forms.PictureBox();
            this.dgvCustomerStay = new System.Windows.Forms.DataGridView();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StayStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StayNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboStayStaus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.cboHourE = new System.Windows.Forms.ComboBox();
            this.cboHourS = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkByDateTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerStay)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(131, 66);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(133, 21);
            this.txtCondition.TabIndex = 0;
            // 
            // rptHelper1
            // 
            this.rptHelper1.EndTime = new System.DateTime(((long)(0)));
            this.rptHelper1.FormName = null;
            this.rptHelper1.Location = new System.Drawing.Point(499, -3);
            this.rptHelper1.Name = "rptHelper1";
            this.rptHelper1.OpUserInfo = null;
            this.rptHelper1.Size = new System.Drawing.Size(122, 85);
            this.rptHelper1.StartTime = new System.DateTime(((long)(0)));
            this.rptHelper1.TabIndex = 26;
            // 
            // pbtnSearch
            // 
            this.pbtnSearch.BackgroundImage = global::Hotel.Properties.Resources.Search;
            this.pbtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnSearch.Location = new System.Drawing.Point(437, 12);
            this.pbtnSearch.Name = "pbtnSearch";
            this.pbtnSearch.Size = new System.Drawing.Size(45, 70);
            this.pbtnSearch.TabIndex = 25;
            this.pbtnSearch.TabStop = false;
            this.pbtnSearch.MouseLeave += new System.EventHandler(this.pbtn_MouseLeave);
            this.pbtnSearch.Click += new System.EventHandler(this.pbtnSearch_Click);
            this.pbtnSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pbtnSearch_Paint);
            this.pbtnSearch.MouseEnter += new System.EventHandler(this.pbtn_MouseEnter);
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
            this.Sex,
            this.CardID,
            this.Days,
            this.StayStatus,
            this.StartDate,
            this.EndDate,
            this.Deposit,
            this.PayType,
            this.Notice,
            this.StayNo,
            this.UpdateUserName,
            this.UpdateDate});
            this.dgvCustomerStay.Location = new System.Drawing.Point(12, 104);
            this.dgvCustomerStay.Name = "dgvCustomerStay";
            this.dgvCustomerStay.RowHeadersVisible = false;
            this.dgvCustomerStay.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomerStay.RowTemplate.Height = 23;
            this.dgvCustomerStay.Size = new System.Drawing.Size(1039, 398);
            this.dgvCustomerStay.TabIndex = 27;
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
            // 
            // Sex
            // 
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            // 
            // CardID
            // 
            this.CardID.HeaderText = "身份证号";
            this.CardID.Name = "CardID";
            this.CardID.Width = 140;
            // 
            // Days
            // 
            this.Days.HeaderText = "天数";
            this.Days.Name = "Days";
            this.Days.ReadOnly = true;
            this.Days.Width = 60;
            // 
            // StayStatus
            // 
            this.StayStatus.HeaderText = "入住状态";
            this.StayStatus.Name = "StayStatus";
            this.StayStatus.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "进店时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 130;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "离店时间";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Width = 130;
            // 
            // Deposit
            // 
            this.Deposit.HeaderText = "押金数";
            this.Deposit.Name = "Deposit";
            this.Deposit.ReadOnly = true;
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
            // StayNo
            // 
            this.StayNo.HeaderText = "结账单号";
            this.StayNo.Name = "StayNo";
            this.StayNo.ReadOnly = true;
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
            this.UpdateDate.HeaderText = "更新时间";
            this.UpdateDate.Name = "UpdateDate";
            this.UpdateDate.ReadOnly = true;
            this.UpdateDate.Width = 130;
            // 
            // cboStayStaus
            // 
            this.cboStayStaus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStayStaus.FormattingEnabled = true;
            this.cboStayStaus.Location = new System.Drawing.Point(270, 67);
            this.cboStayStaus.Name = "cboStayStaus";
            this.cboStayStaus.Size = new System.Drawing.Size(77, 20);
            this.cboStayStaus.TabIndex = 28;
            this.cboStayStaus.SelectedIndexChanged += new System.EventHandler(this.cboStayStaus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "宾客姓名/房间号";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1063, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblMsg
            // 
            this.tslblMsg.Name = "tslblMsg";
            this.tslblMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(13, 43);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(53, 12);
            this.lblEnd.TabIndex = 36;
            this.lblEnd.Text = "结束时间";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(13, 16);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(53, 12);
            this.lblStart.TabIndex = 35;
            this.lblStart.Text = "起始时间";
            // 
            // cboHourE
            // 
            this.cboHourE.FormattingEnabled = true;
            this.cboHourE.Location = new System.Drawing.Point(270, 40);
            this.cboHourE.Name = "cboHourE";
            this.cboHourE.Size = new System.Drawing.Size(77, 20);
            this.cboHourE.TabIndex = 33;
            // 
            // cboHourS
            // 
            this.cboHourS.FormattingEnabled = true;
            this.cboHourS.Location = new System.Drawing.Point(270, 13);
            this.cboHourS.Name = "cboHourS";
            this.cboHourS.Size = new System.Drawing.Size(77, 20);
            this.cboHourS.TabIndex = 34;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(131, 39);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(133, 21);
            this.dtpEnd.TabIndex = 32;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(131, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(133, 21);
            this.dtpStart.TabIndex = 31;
            // 
            // chkByDateTime
            // 
            this.chkByDateTime.AutoSize = true;
            this.chkByDateTime.Location = new System.Drawing.Point(353, 13);
            this.chkByDateTime.Name = "chkByDateTime";
            this.chkByDateTime.Size = new System.Drawing.Size(72, 16);
            this.chkByDateTime.TabIndex = 37;
            this.chkByDateTime.Text = "附加时间";
            this.chkByDateTime.UseVisualStyleBackColor = true;
            this.chkByDateTime.CheckedChanged += new System.EventHandler(this.chkByDateTime_CheckedChanged);
            // 
            // FormCustomerStayRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 527);
            this.Controls.Add(this.chkByDateTime);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.cboHourE);
            this.Controls.Add(this.cboHourS);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStayStaus);
            this.Controls.Add(this.dgvCustomerStay);
            this.Controls.Add(this.rptHelper1);
            this.Controls.Add(this.pbtnSearch);
            this.Controls.Add(this.txtCondition);
            this.Name = "FormCustomerStayRpt";
            this.Text = "宾客入住信息查询";
            this.Load += new System.EventHandler(this.FormCustomerStayRpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerStay)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCondition;
        private RptHelper rptHelper1;
        private System.Windows.Forms.PictureBox pbtnSearch;
        private System.Windows.Forms.DataGridView dgvCustomerStay;
        private System.Windows.Forms.ComboBox cboStayStaus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblMsg;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox cboHourE;
        private System.Windows.Forms.ComboBox cboHourS;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkByDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn StayStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StayNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
    }
}