namespace Hotel
{
    partial class FormHandHisRpt
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
            this.label14 = new System.Windows.Forms.Label();
            this.cboHourE = new System.Windows.Forms.ComboBox();
            this.cboHourS = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dgvHandHis = new System.Windows.Forms.DataGridView();
            this.cboUserList = new System.Windows.Forms.ComboBox();
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.pbtnSearch = new System.Windows.Forms.PictureBox();
            this.rptHelper1 = new Hotel.RptHelper();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromLast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HandOverMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HandInMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToNextMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHandHis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(246, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 17;
            this.label14.Text = "~";
            // 
            // cboHourE
            // 
            this.cboHourE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHourE.FormattingEnabled = true;
            this.cboHourE.Location = new System.Drawing.Point(355, 36);
            this.cboHourE.Name = "cboHourE";
            this.cboHourE.Size = new System.Drawing.Size(39, 20);
            this.cboHourE.TabIndex = 14;
            // 
            // cboHourS
            // 
            this.cboHourS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHourS.FormattingEnabled = true;
            this.cboHourS.Location = new System.Drawing.Point(199, 36);
            this.cboHourS.Name = "cboHourS";
            this.cboHourS.Size = new System.Drawing.Size(39, 20);
            this.cboHourS.TabIndex = 15;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(263, 35);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(86, 21);
            this.dtpEnd.TabIndex = 18;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(107, 36);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(86, 21);
            this.dtpStart.TabIndex = 16;
            // 
            // dgvHandHis
            // 
            this.dgvHandHis.AllowUserToAddRows = false;
            this.dgvHandHis.AllowUserToDeleteRows = false;
            this.dgvHandHis.BackgroundColor = System.Drawing.Color.White;
            this.dgvHandHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHandHis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartDate,
            this.CUserName,
            this.NUserName,
            this.FromLast,
            this.CurrentDeposit,
            this.CurrentPaid,
            this.HandOverMoney,
            this.HandInMoney,
            this.ToNextMoney});
            this.dgvHandHis.Location = new System.Drawing.Point(25, 92);
            this.dgvHandHis.Name = "dgvHandHis";
            this.dgvHandHis.ReadOnly = true;
            this.dgvHandHis.RowHeadersVisible = false;
            this.dgvHandHis.RowTemplate.Height = 23;
            this.dgvHandHis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHandHis.Size = new System.Drawing.Size(907, 352);
            this.dgvHandHis.TabIndex = 13;
            // 
            // cboUserList
            // 
            this.cboUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserList.FormattingEnabled = true;
            this.cboUserList.Location = new System.Drawing.Point(24, 36);
            this.cboUserList.Name = "cboUserList";
            this.cboUserList.Size = new System.Drawing.Size(77, 20);
            this.cboUserList.TabIndex = 12;
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.ForeColor = System.Drawing.Color.Red;
            this.lblMsg1.Location = new System.Drawing.Point(23, 65);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(0, 12);
            this.lblMsg1.TabIndex = 20;
            // 
            // pbtnSearch
            // 
            this.pbtnSearch.BackgroundImage = global::Hotel.Properties.Resources.Search;
            this.pbtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnSearch.Location = new System.Drawing.Point(416, 14);
            this.pbtnSearch.Name = "pbtnSearch";
            this.pbtnSearch.Size = new System.Drawing.Size(45, 70);
            this.pbtnSearch.TabIndex = 23;
            this.pbtnSearch.TabStop = false;
            this.pbtnSearch.MouseLeave += new System.EventHandler(this.pbtn_MouseLeave);
            this.pbtnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.pbtnSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pbt_Paint);
            this.pbtnSearch.MouseEnter += new System.EventHandler(this.pbtn_MouseEnter);
            // 
            // rptHelper1
            // 
            this.rptHelper1.EndTime = new System.DateTime(((long)(0)));
            this.rptHelper1.FormName = null;
            this.rptHelper1.Location = new System.Drawing.Point(467, 1);
            this.rptHelper1.Name = "rptHelper1";
            this.rptHelper1.OpUserInfo = null;
            this.rptHelper1.Size = new System.Drawing.Size(122, 85);
            this.rptHelper1.StartTime = new System.DateTime(((long)(0)));
            this.rptHelper1.TabIndex = 24;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "交班时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 140;
            // 
            // CUserName
            // 
            this.CUserName.HeaderText = "交班员工";
            this.CUserName.Name = "CUserName";
            this.CUserName.ReadOnly = true;
            this.CUserName.Width = 80;
            // 
            // NUserName
            // 
            this.NUserName.HeaderText = "接班员工";
            this.NUserName.Name = "NUserName";
            this.NUserName.ReadOnly = true;
            this.NUserName.Width = 80;
            // 
            // FromLast
            // 
            this.FromLast.HeaderText = "上班结余金额";
            this.FromLast.Name = "FromLast";
            this.FromLast.ReadOnly = true;
            // 
            // CurrentDeposit
            // 
            this.CurrentDeposit.HeaderText = "本班收取押金";
            this.CurrentDeposit.Name = "CurrentDeposit";
            this.CurrentDeposit.ReadOnly = true;
            // 
            // CurrentPaid
            // 
            this.CurrentPaid.HeaderText = "本班盈利现金";
            this.CurrentPaid.Name = "CurrentPaid";
            this.CurrentPaid.ReadOnly = true;
            // 
            // HandOverMoney
            // 
            this.HandOverMoney.HeaderText = "合计现金";
            this.HandOverMoney.Name = "HandOverMoney";
            this.HandOverMoney.ReadOnly = true;
            // 
            // HandInMoney
            // 
            this.HandInMoney.HeaderText = "上缴财务金额";
            this.HandInMoney.Name = "HandInMoney";
            this.HandInMoney.ReadOnly = true;
            // 
            // ToNextMoney
            // 
            this.ToNextMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ToNextMoney.HeaderText = "下放金额";
            this.ToNextMoney.Name = "ToNextMoney";
            this.ToNextMoney.ReadOnly = true;
            // 
            // FormHandHisRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 474);
            this.Controls.Add(this.rptHelper1);
            this.Controls.Add(this.pbtnSearch);
            this.Controls.Add(this.lblMsg1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboHourE);
            this.Controls.Add(this.cboHourS);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dgvHandHis);
            this.Controls.Add(this.cboUserList);
            this.Name = "FormHandHisRpt";
            this.Text = "交接班历史记录查询";
            this.Load += new System.EventHandler(this.FormHandHisRpt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHandHis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboHourE;
        private System.Windows.Forms.ComboBox cboHourS;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DataGridView dgvHandHis;
        private System.Windows.Forms.ComboBox cboUserList;
        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.PictureBox pbtnSearch;
        private RptHelper rptHelper1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn HandOverMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn HandInMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToNextMoney;

    }
}