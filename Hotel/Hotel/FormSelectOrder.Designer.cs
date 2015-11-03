namespace Hotel
{
    partial class FormSelectOrder
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
            this.dgvOrderedInfo = new System.Windows.Forms.DataGridView();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderedInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderedInfo
            // 
            this.dgvOrderedInfo.AllowUserToAddRows = false;
            this.dgvOrderedInfo.AllowUserToDeleteRows = false;
            this.dgvOrderedInfo.AllowUserToResizeRows = false;
            this.dgvOrderedInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderedInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderedInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelect,
            this.CustomerName,
            this.StartDate,
            this.Phone,
            this.OrderId});
            this.dgvOrderedInfo.Location = new System.Drawing.Point(12, 12);
            this.dgvOrderedInfo.MultiSelect = false;
            this.dgvOrderedInfo.Name = "dgvOrderedInfo";
            this.dgvOrderedInfo.RowHeadersVisible = false;
            this.dgvOrderedInfo.RowTemplate.Height = 23;
            this.dgvOrderedInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderedInfo.Size = new System.Drawing.Size(344, 153);
            this.dgvOrderedInfo.TabIndex = 0;
            this.dgvOrderedInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderedInfo_CellContentClick);
            // 
            // chkSelect
            // 
            this.chkSelect.HeaderText = "";
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Width = 20;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "宾客姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "开始时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Width = 120;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "联系电话";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // OrderId
            // 
            this.OrderId.HeaderText = "订单号";
            this.OrderId.Name = "OrderId";
            this.OrderId.ReadOnly = true;
            this.OrderId.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(135, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormSelectOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 211);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvOrderedInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSelectOrder";
            this.Text = "选择预定";
            this.Load += new System.EventHandler(this.FormSelectOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderedInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderedInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
    }
}