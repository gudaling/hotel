namespace Hotel
{
    partial class FormInComeRpt
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
            this.dgvIncomeInfo = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHourE = new System.Windows.Forms.ComboBox();
            this.cboHourS = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsslblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbtnExcel = new System.Windows.Forms.PictureBox();
            this.pbtnPrint = new System.Windows.Forms.PictureBox();
            this.pbtnSearch = new System.Windows.Forms.PictureBox();
            this.StayNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomeInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.ss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIncomeInfo
            // 
            this.dgvIncomeInfo.AllowUserToAddRows = false;
            this.dgvIncomeInfo.AllowUserToDeleteRows = false;
            this.dgvIncomeInfo.AllowUserToResizeRows = false;
            this.dgvIncomeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncomeInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncomeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncomeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StayNo,
            this.RoomNo,
            this.CustomerName,
            this.StartDate,
            this.EndDate,
            this.Days,
            this.PaidMoney,
            this.Total,
            this.PayType,
            this.Notice,
            this.UpdateUserName,
            this.UpdateDate,
            this.StayId});
            this.dgvIncomeInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvIncomeInfo.Location = new System.Drawing.Point(24, 98);
            this.dgvIncomeInfo.Name = "dgvIncomeInfo";
            this.dgvIncomeInfo.ReadOnly = true;
            this.dgvIncomeInfo.RowHeadersVisible = false;
            this.dgvIncomeInfo.RowTemplate.Height = 23;
            this.dgvIncomeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvIncomeInfo.Size = new System.Drawing.Size(1058, 362);
            this.dgvIncomeInfo.TabIndex = 19;
            this.dgvIncomeInfo.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvIncomeInfo_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPrint});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // tsmPrint
            // 
            this.tsmPrint.Name = "tsmPrint";
            this.tsmPrint.Size = new System.Drawing.Size(142, 22);
            this.tsmPrint.Text = "查看消费明细";
            this.tsmPrint.Click += new System.EventHandler(this.tsmPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "终结时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "起始时间";
            // 
            // cboHourE
            // 
            this.cboHourE.FormattingEnabled = true;
            this.cboHourE.Location = new System.Drawing.Point(186, 55);
            this.cboHourE.Name = "cboHourE";
            this.cboHourE.Size = new System.Drawing.Size(39, 20);
            this.cboHourE.TabIndex = 13;
            // 
            // cboHourS
            // 
            this.cboHourS.FormattingEnabled = true;
            this.cboHourS.Location = new System.Drawing.Point(186, 28);
            this.cboHourS.Name = "cboHourS";
            this.cboHourS.Size = new System.Drawing.Size(39, 20);
            this.cboHourS.TabIndex = 14;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(81, 54);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(88, 21);
            this.dtpEnd.TabIndex = 12;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(81, 27);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(88, 21);
            this.dtpStart.TabIndex = 11;
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblTotal});
            this.ss.Location = new System.Drawing.Point(0, 472);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(1104, 22);
            this.ss.TabIndex = 20;
            this.ss.Text = "statusStrip1";
            // 
            // tsslblTotal
            // 
            this.tsslblTotal.Name = "tsslblTotal";
            this.tsslblTotal.Size = new System.Drawing.Size(0, 17);
            // 
            // pbtnExcel
            // 
            this.pbtnExcel.BackgroundImage = global::Hotel.Properties.Resources.Excel;
            this.pbtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnExcel.Location = new System.Drawing.Point(316, 7);
            this.pbtnExcel.Name = "pbtnExcel";
            this.pbtnExcel.Size = new System.Drawing.Size(45, 70);
            this.pbtnExcel.TabIndex = 17;
            this.pbtnExcel.TabStop = false;
            this.pbtnExcel.MouseLeave += new System.EventHandler(this.pbtn_MouseLeave);
            this.pbtnExcel.Click += new System.EventHandler(this.pbtnExcel_Click);
            this.pbtnExcel.Paint += new System.Windows.Forms.PaintEventHandler(this.pbt_Paint);
            this.pbtnExcel.MouseEnter += new System.EventHandler(this.pbtn_MouseEnter);
            // 
            // pbtnPrint
            // 
            this.pbtnPrint.BackgroundImage = global::Hotel.Properties.Resources.Print;
            this.pbtnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnPrint.Location = new System.Drawing.Point(380, 7);
            this.pbtnPrint.Name = "pbtnPrint";
            this.pbtnPrint.Size = new System.Drawing.Size(45, 70);
            this.pbtnPrint.TabIndex = 17;
            this.pbtnPrint.TabStop = false;
            this.pbtnPrint.MouseLeave += new System.EventHandler(this.pbtn_MouseLeave);
            this.pbtnPrint.Click += new System.EventHandler(this.pbtnPrint_Click);
            this.pbtnPrint.Paint += new System.Windows.Forms.PaintEventHandler(this.pbt_Paint);
            this.pbtnPrint.MouseEnter += new System.EventHandler(this.pbtn_MouseEnter);
            // 
            // pbtnSearch
            // 
            this.pbtnSearch.BackgroundImage = global::Hotel.Properties.Resources.Search;
            this.pbtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnSearch.Location = new System.Drawing.Point(253, 7);
            this.pbtnSearch.Name = "pbtnSearch";
            this.pbtnSearch.Size = new System.Drawing.Size(45, 70);
            this.pbtnSearch.TabIndex = 18;
            this.pbtnSearch.TabStop = false;
            this.pbtnSearch.MouseLeave += new System.EventHandler(this.pbtn_MouseLeave);
            this.pbtnSearch.Click += new System.EventHandler(this.pbtnSearch_Click);
            this.pbtnSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pbt_Paint);
            this.pbtnSearch.MouseEnter += new System.EventHandler(this.pbtn_MouseEnter);
            // 
            // StayNo
            // 
            this.StayNo.HeaderText = "结账单号";
            this.StayNo.Name = "StayNo";
            this.StayNo.ReadOnly = true;
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
            // EndDate
            // 
            this.EndDate.HeaderText = "离店时间";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Width = 130;
            // 
            // Days
            // 
            this.Days.HeaderText = "入住天数";
            this.Days.Name = "Days";
            this.Days.ReadOnly = true;
            // 
            // PaidMoney
            // 
            this.PaidMoney.HeaderText = "实收现金";
            this.PaidMoney.Name = "PaidMoney";
            this.PaidMoney.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "应收费用";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
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
            this.UpdateUserName.HeaderText = "收款人";
            this.UpdateUserName.Name = "UpdateUserName";
            this.UpdateUserName.ReadOnly = true;
            this.UpdateUserName.Width = 80;
            // 
            // UpdateDate
            // 
            this.UpdateDate.HeaderText = "结账时间";
            this.UpdateDate.Name = "UpdateDate";
            this.UpdateDate.ReadOnly = true;
            this.UpdateDate.Width = 130;
            // 
            // StayId
            // 
            this.StayId.HeaderText = "StayId";
            this.StayId.Name = "StayId";
            this.StayId.ReadOnly = true;
            this.StayId.Visible = false;
            // 
            // FormInComeRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1104, 494);
            this.Controls.Add(this.ss);
            this.Controls.Add(this.dgvIncomeInfo);
            this.Controls.Add(this.pbtnExcel);
            this.Controls.Add(this.pbtnPrint);
            this.Controls.Add(this.pbtnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboHourE);
            this.Controls.Add(this.cboHourS);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormInComeRpt";
            this.Text = "收入报表";
            this.Load += new System.EventHandler(this.FormInComeRpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomeInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncomeInfo;
        private System.Windows.Forms.PictureBox pbtnPrint;
        private System.Windows.Forms.PictureBox pbtnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboHourE;
        private System.Windows.Forms.ComboBox cboHourS;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTotal;
        private System.Windows.Forms.PictureBox pbtnExcel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn StayNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notice;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StayId;

    }
}