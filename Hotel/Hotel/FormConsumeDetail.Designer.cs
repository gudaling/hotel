namespace Hotel
{
    partial class FormConsumeDetail
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
            this.dgvConsumeDetail = new System.Windows.Forms.DataGridView();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsumeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsumeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumeDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsumeDetail
            // 
            this.dgvConsumeDetail.AllowUserToAddRows = false;
            this.dgvConsumeDetail.AllowUserToDeleteRows = false;
            this.dgvConsumeDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsumeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNo,
            this.ConsumeName,
            this.UnitPrice,
            this.Unit,
            this.Number,
            this.TotalMoney,
            this.ConsumeDate,
            this.CreateUserName});
            this.dgvConsumeDetail.Location = new System.Drawing.Point(12, 12);
            this.dgvConsumeDetail.MultiSelect = false;
            this.dgvConsumeDetail.Name = "dgvConsumeDetail";
            this.dgvConsumeDetail.ReadOnly = true;
            this.dgvConsumeDetail.RowHeadersVisible = false;
            this.dgvConsumeDetail.RowTemplate.Height = 23;
            this.dgvConsumeDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsumeDetail.ShowEditingIcon = false;
            this.dgvConsumeDetail.Size = new System.Drawing.Size(766, 258);
            this.dgvConsumeDetail.TabIndex = 1;
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "房间号";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            this.RoomNo.Width = 80;
            // 
            // ConsumeName
            // 
            this.ConsumeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ConsumeName.HeaderText = "消费项目";
            this.ConsumeName.Name = "ConsumeName";
            this.ConsumeName.ReadOnly = true;
            this.ConsumeName.Width = 78;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "单价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 60;
            // 
            // Number
            // 
            this.Number.HeaderText = "消费数量";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // TotalMoney
            // 
            this.TotalMoney.HeaderText = "应收";
            this.TotalMoney.Name = "TotalMoney";
            this.TotalMoney.ReadOnly = true;
            this.TotalMoney.Width = 120;
            // 
            // ConsumeDate
            // 
            this.ConsumeDate.HeaderText = "消费时间";
            this.ConsumeDate.Name = "ConsumeDate";
            this.ConsumeDate.ReadOnly = true;
            this.ConsumeDate.Width = 120;
            // 
            // CreateUserName
            // 
            this.CreateUserName.HeaderText = "记账人";
            this.CreateUserName.Name = "CreateUserName";
            this.CreateUserName.ReadOnly = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(310, 278);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印消费清单";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FormConsumeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 313);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvConsumeDetail);
            this.Name = "FormConsumeDetail";
            this.Text = "FormConsumeDetail";
            this.Load += new System.EventHandler(this.FormConsumeDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumeDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsumeDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateUserName;
        private System.Windows.Forms.Button btnPrint;
    }
}