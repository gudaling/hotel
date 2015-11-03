namespace Hotel
{
    partial class FormPhoneList
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
            this.rptHelper1 = new Hotel.RptHelper();
            this.dgvPhoneList = new System.Windows.Forms.DataGridView();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneList)).BeginInit();
            this.SuspendLayout();
            // 
            // rptHelper1
            // 
            this.rptHelper1.EndTime = new System.DateTime(((long)(0)));
            this.rptHelper1.FormName = null;
            this.rptHelper1.Location = new System.Drawing.Point(897, 8);
            this.rptHelper1.Name = "rptHelper1";
            this.rptHelper1.OpUserInfo = null;
            this.rptHelper1.Size = new System.Drawing.Size(122, 85);
            this.rptHelper1.StartTime = new System.DateTime(((long)(0)));
            this.rptHelper1.TabIndex = 0;
            // 
            // dgvPhoneList
            // 
            this.dgvPhoneList.AllowUserToAddRows = false;
            this.dgvPhoneList.AllowUserToDeleteRows = false;
            this.dgvPhoneList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhoneList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNo,
            this.PhoneNo,
            this.LinkNo,
            this.IsFree,
            this.StartDate,
            this.EndDate,
            this.CallLength,
            this.CatType,
            this.Rate,
            this.CurrentRate});
            this.dgvPhoneList.Location = new System.Drawing.Point(13, 99);
            this.dgvPhoneList.Name = "dgvPhoneList";
            this.dgvPhoneList.ReadOnly = true;
            this.dgvPhoneList.RowHeadersVisible = false;
            this.dgvPhoneList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPhoneList.RowTemplate.Height = 23;
            this.dgvPhoneList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhoneList.Size = new System.Drawing.Size(1006, 523);
            this.dgvPhoneList.TabIndex = 1;
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "房间号";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            // 
            // PhoneNo
            // 
            this.PhoneNo.HeaderText = "主叫号码";
            this.PhoneNo.Name = "PhoneNo";
            this.PhoneNo.ReadOnly = true;
            // 
            // LinkNo
            // 
            this.LinkNo.HeaderText = "被叫号码";
            this.LinkNo.Name = "LinkNo";
            this.LinkNo.ReadOnly = true;
            // 
            // IsFree
            // 
            this.IsFree.HeaderText = "是否免费";
            this.IsFree.Name = "IsFree";
            this.IsFree.ReadOnly = true;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "开始时间";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "结束时间";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // CallLength
            // 
            this.CallLength.HeaderText = "通话时长";
            this.CallLength.Name = "CallLength";
            this.CallLength.ReadOnly = true;
            // 
            // CatType
            // 
            this.CatType.HeaderText = "通话类型";
            this.CatType.Name = "CatType";
            this.CatType.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "费率";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // CurrentRate
            // 
            this.CurrentRate.HeaderText = "单次费用";
            this.CurrentRate.Name = "CurrentRate";
            this.CurrentRate.ReadOnly = true;
            // 
            // FormPhoneList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 634);
            this.Controls.Add(this.dgvPhoneList);
            this.Controls.Add(this.rptHelper1);
            this.MaximizeBox = false;
            this.Name = "FormPhoneList";
            this.Text = "电话清单";
            this.Load += new System.EventHandler(this.FormPhoneList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhoneList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RptHelper rptHelper1;
        private System.Windows.Forms.DataGridView dgvPhoneList;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsFree;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentRate;
    }
}