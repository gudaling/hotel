namespace Hotel
{
    partial class FormOrders
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboHourE = new System.Windows.Forms.ComboBox();
            this.cboHourS = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtNPR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbtnOpenOrder = new System.Windows.Forms.PictureBox();
            this.pbtnCancel = new System.Windows.Forms.PictureBox();
            this.pbtnDeleteOrder = new System.Windows.Forms.PictureBox();
            this.pbtnEditOrder = new System.Windows.Forms.PictureBox();
            this.pbtnAddOrder = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeepDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOpenOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnDeleteOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnEditOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnAddOrder)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboHourE);
            this.groupBox1.Controls.Add(this.cboHourS);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtNPR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pbtnOpenOrder);
            this.groupBox1.Controls.Add(this.pbtnCancel);
            this.groupBox1.Controls.Add(this.pbtnDeleteOrder);
            this.groupBox1.Controls.Add(this.pbtnEditOrder);
            this.groupBox1.Controls.Add(this.pbtnAddOrder);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(336, 82);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(597, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "~";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "预抵时间";
            // 
            // cboHourE
            // 
            this.cboHourE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHourE.FormattingEnabled = true;
            this.cboHourE.Location = new System.Drawing.Point(706, 83);
            this.cboHourE.Name = "cboHourE";
            this.cboHourE.Size = new System.Drawing.Size(39, 20);
            this.cboHourE.TabIndex = 2;
            // 
            // cboHourS
            // 
            this.cboHourS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHourS.FormattingEnabled = true;
            this.cboHourS.Location = new System.Drawing.Point(550, 83);
            this.cboHourS.Name = "cboHourS";
            this.cboHourS.Size = new System.Drawing.Size(39, 20);
            this.cboHourS.TabIndex = 2;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(235, 84);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(84, 20);
            this.cboStatus.TabIndex = 2;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(614, 82);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(86, 21);
            this.dtpEnd.TabIndex = 5;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(458, 83);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(86, 21);
            this.dtpStart.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(663, 145);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 21);
            this.textBox2.TabIndex = 2;
            // 
            // txtNPR
            // 
            this.txtNPR.Location = new System.Drawing.Point(129, 83);
            this.txtNPR.Name = "txtNPR";
            this.txtNPR.Size = new System.Drawing.Size(100, 21);
            this.txtNPR.TabIndex = 1;
            this.txtNPR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNPR_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "房间号/姓名/电话";
            // 
            // pbtnOpenOrder
            // 
            this.pbtnOpenOrder.BackgroundImage = global::Hotel.Properties.Resources.xp系统桌面图标下载40;
            this.pbtnOpenOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnOpenOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnOpenOrder.Location = new System.Drawing.Point(235, 10);
            this.pbtnOpenOrder.Name = "pbtnOpenOrder";
            this.pbtnOpenOrder.Size = new System.Drawing.Size(32, 64);
            this.pbtnOpenOrder.TabIndex = 0;
            this.pbtnOpenOrder.TabStop = false;
            this.pbtnOpenOrder.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnOpenOrder.Click += new System.EventHandler(this.pbtnOpenOrder_Click);
            this.pbtnOpenOrder.Paint += new System.Windows.Forms.PaintEventHandler(this.pbtnOpenOrder_Paint);
            this.pbtnOpenOrder.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnCancel
            // 
            this.pbtnCancel.BackgroundImage = global::Hotel.Properties.Resources.Cancel;
            this.pbtnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnCancel.Location = new System.Drawing.Point(129, 10);
            this.pbtnCancel.Name = "pbtnCancel";
            this.pbtnCancel.Size = new System.Drawing.Size(32, 64);
            this.pbtnCancel.TabIndex = 0;
            this.pbtnCancel.TabStop = false;
            this.pbtnCancel.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnCancel.Click += new System.EventHandler(this.pbtnCancel_Click);
            this.pbtnCancel.Paint += new System.Windows.Forms.PaintEventHandler(this.pbtnCancel_Paint);
            this.pbtnCancel.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnDeleteOrder
            // 
            this.pbtnDeleteOrder.BackgroundImage = global::Hotel.Properties.Resources.DefaultRoom;
            this.pbtnDeleteOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnDeleteOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnDeleteOrder.Location = new System.Drawing.Point(182, 10);
            this.pbtnDeleteOrder.Name = "pbtnDeleteOrder";
            this.pbtnDeleteOrder.Size = new System.Drawing.Size(32, 64);
            this.pbtnDeleteOrder.TabIndex = 0;
            this.pbtnDeleteOrder.TabStop = false;
            this.pbtnDeleteOrder.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnDeleteOrder.Click += new System.EventHandler(this.pbtnDeleteOrder_Click);
            this.pbtnDeleteOrder.Paint += new System.Windows.Forms.PaintEventHandler(this.pbtnDeleteOrder_Paint);
            this.pbtnDeleteOrder.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnEditOrder
            // 
            this.pbtnEditOrder.BackgroundImage = global::Hotel.Properties.Resources.ModifyOrder;
            this.pbtnEditOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnEditOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnEditOrder.Location = new System.Drawing.Point(77, 10);
            this.pbtnEditOrder.Name = "pbtnEditOrder";
            this.pbtnEditOrder.Size = new System.Drawing.Size(32, 64);
            this.pbtnEditOrder.TabIndex = 0;
            this.pbtnEditOrder.TabStop = false;
            this.pbtnEditOrder.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnEditOrder.Click += new System.EventHandler(this.pbtnEditOrder_Click);
            this.pbtnEditOrder.Paint += new System.Windows.Forms.PaintEventHandler(this.pbtnEditOrder_Paint);
            this.pbtnEditOrder.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnAddOrder
            // 
            this.pbtnAddOrder.BackgroundImage = global::Hotel.Properties.Resources.AddOrder;
            this.pbtnAddOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnAddOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnAddOrder.Location = new System.Drawing.Point(22, 10);
            this.pbtnAddOrder.Name = "pbtnAddOrder";
            this.pbtnAddOrder.Size = new System.Drawing.Size(32, 64);
            this.pbtnAddOrder.TabIndex = 0;
            this.pbtnAddOrder.TabStop = false;
            this.pbtnAddOrder.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnAddOrder.Click += new System.EventHandler(this.pbtnAddOrder_Click);
            this.pbtnAddOrder.Paint += new System.Windows.Forms.PaintEventHandler(this.pbtnAddOrder_Paint);
            this.pbtnAddOrder.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvOrderList);
            this.groupBox2.Location = new System.Drawing.Point(13, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 286);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.AllowUserToAddRows = false;
            this.dgvOrderList.AllowUserToDeleteRows = false;
            this.dgvOrderList.AllowUserToResizeRows = false;
            this.dgvOrderList.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderStatus,
            this.RoomType,
            this.RoomNo,
            this.CustomerName,
            this.Phone,
            this.StartDate,
            this.EndDate,
            this.KeepDate,
            this.CreateDate,
            this.Notice,
            this.OrderId});
            this.dgvOrderList.Location = new System.Drawing.Point(7, 21);
            this.dgvOrderList.MultiSelect = false;
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.ReadOnly = true;
            this.dgvOrderList.RowHeadersVisible = false;
            this.dgvOrderList.RowTemplate.Height = 23;
            this.dgvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderList.Size = new System.Drawing.Size(751, 259);
            this.dgvOrderList.TabIndex = 0;
            // 
            // OrderStatus
            // 
            this.OrderStatus.HeaderText = "订单状态";
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.ReadOnly = true;
            this.OrderStatus.Width = 80;
            // 
            // RoomType
            // 
            this.RoomType.HeaderText = "房间类型";
            this.RoomType.Name = "RoomType";
            this.RoomType.ReadOnly = true;
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "房间编号";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            this.RoomNo.Width = 80;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "宾客姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 80;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "联系电话";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "预抵时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 120;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "预离时间";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Width = 120;
            // 
            // KeepDate
            // 
            this.KeepDate.HeaderText = "保留时间";
            this.KeepDate.Name = "KeepDate";
            this.KeepDate.ReadOnly = true;
            this.KeepDate.Width = 120;
            // 
            // CreateDate
            // 
            this.CreateDate.HeaderText = "预定时间";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 120;
            // 
            // Notice
            // 
            this.Notice.HeaderText = "备注";
            this.Notice.Name = "Notice";
            this.Notice.ReadOnly = true;
            this.Notice.Width = 200;
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.Name = "OrderId";
            this.OrderId.ReadOnly = true;
            this.OrderId.Visible = false;
            // 
            // FormOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(790, 428);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FormOrders";
            this.Text = "预定管理";
            this.Load += new System.EventHandler(this.FormOrders_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOpenOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnDeleteOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnEditOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnAddOrder)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbtnAddOrder;
        private System.Windows.Forms.PictureBox pbtnEditOrder;
        private System.Windows.Forms.PictureBox pbtnDeleteOrder;
        private System.Windows.Forms.PictureBox pbtnOpenOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNPR;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOrderList;
        private System.Windows.Forms.ComboBox cboHourS;
        private System.Windows.Forms.ComboBox cboHourE;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeepDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.PictureBox pbtnCancel;
    }
}