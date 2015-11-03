namespace Hotel
{
    partial class FormStayRateRpt
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
            this.dgvStayRate = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StayRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.rptHelper1 = new Hotel.RptHelper();
            this.pbtnSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStayRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStayRate
            // 
            this.dgvStayRate.AllowUserToAddRows = false;
            this.dgvStayRate.AllowUserToDeleteRows = false;
            this.dgvStayRate.AllowUserToResizeRows = false;
            this.dgvStayRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStayRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Days,
            this.StayRate});
            this.dgvStayRate.Location = new System.Drawing.Point(13, 108);
            this.dgvStayRate.Name = "dgvStayRate";
            this.dgvStayRate.ReadOnly = true;
            this.dgvStayRate.RowHeadersVisible = false;
            this.dgvStayRate.RowTemplate.Height = 23;
            this.dgvStayRate.Size = new System.Drawing.Size(354, 383);
            this.dgvStayRate.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Days
            // 
            this.Days.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Days.HeaderText = "日期";
            this.Days.Name = "Days";
            this.Days.ReadOnly = true;
            // 
            // StayRate
            // 
            this.StayRate.HeaderText = "入住率";
            this.StayRate.Name = "StayRate";
            this.StayRate.ReadOnly = true;
            this.StayRate.Width = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "终结时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "起始时间";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(76, 58);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(88, 21);
            this.dtpEnd.TabIndex = 18;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(76, 31);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(88, 21);
            this.dtpStart.TabIndex = 17;
            // 
            // rptHelper1
            // 
            this.rptHelper1.EndTime = new System.DateTime(((long)(0)));
            this.rptHelper1.FormName = null;
            this.rptHelper1.Location = new System.Drawing.Point(245, 5);
            this.rptHelper1.Name = "rptHelper1";
            this.rptHelper1.OpUserInfo = null;
            this.rptHelper1.Size = new System.Drawing.Size(122, 85);
            this.rptHelper1.StartTime = new System.DateTime(((long)(0)));
            this.rptHelper1.TabIndex = 28;
            // 
            // pbtnSearch
            // 
            this.pbtnSearch.BackgroundImage = global::Hotel.Properties.Resources.Search;
            this.pbtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnSearch.Location = new System.Drawing.Point(183, 20);
            this.pbtnSearch.Name = "pbtnSearch";
            this.pbtnSearch.Size = new System.Drawing.Size(45, 70);
            this.pbtnSearch.TabIndex = 27;
            this.pbtnSearch.TabStop = false;
            this.pbtnSearch.MouseLeave += new System.EventHandler(this.pbtn_MouseLeave);
            this.pbtnSearch.Click += new System.EventHandler(this.pbtnSearch_Click);
            this.pbtnSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pbtnSearch_Paint);
            this.pbtnSearch.MouseEnter += new System.EventHandler(this.pbtn_MouseEnter);
            // 
            // FormStayRateRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 503);
            this.Controls.Add(this.rptHelper1);
            this.Controls.Add(this.pbtnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.dgvStayRate);
            this.Name = "FormStayRateRpt";
            this.Text = "FormStayRateRpt";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStayRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStayRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private RptHelper rptHelper1;
        private System.Windows.Forms.PictureBox pbtnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn StayRate;
    }
}