namespace Hotel
{
    partial class FormAddPay
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.dgvGoodsList = new System.Windows.Forms.DataGridView();
            this.GoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRoomNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDeleteConsume = new System.Windows.Forms.Button();
            this.dgvConsumeList = new System.Windows.Forms.DataGridView();
            this.ConsumeGoodsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsumePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumeList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.dgvGoodsList);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目清单";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "消费数量";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(65, 19);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(70, 21);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // dgvGoodsList
            // 
            this.dgvGoodsList.AllowUserToAddRows = false;
            this.dgvGoodsList.AllowUserToDeleteRows = false;
            this.dgvGoodsList.AllowUserToResizeRows = false;
            this.dgvGoodsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvGoodsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GoodsName,
            this.Unit,
            this.Price,
            this.GoodsId});
            this.dgvGoodsList.Location = new System.Drawing.Point(7, 43);
            this.dgvGoodsList.MultiSelect = false;
            this.dgvGoodsList.Name = "dgvGoodsList";
            this.dgvGoodsList.ReadOnly = true;
            this.dgvGoodsList.RowHeadersVisible = false;
            this.dgvGoodsList.RowTemplate.Height = 23;
            this.dgvGoodsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoodsList.Size = new System.Drawing.Size(209, 280);
            this.dgvGoodsList.TabIndex = 0;
            this.dgvGoodsList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGoodsList_CellMouseDoubleClick);
            // 
            // GoodsName
            // 
            this.GoodsName.HeaderText = "商品名称";
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.ReadOnly = true;
            this.GoodsName.Width = 80;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 60;
            // 
            // Price
            // 
            this.Price.HeaderText = "价格";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // GoodsId
            // 
            this.GoodsId.HeaderText = "ID";
            this.GoodsId.Name = "GoodsId";
            this.GoodsId.ReadOnly = true;
            this.GoodsId.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(141, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblRoomNo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.btnDeleteConsume);
            this.groupBox2.Controls.Add(this.dgvConsumeList);
            this.groupBox2.Location = new System.Drawing.Point(241, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "消费清单";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "金额";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(300, 281);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 12);
            this.lblTotal.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "消费清单";
            // 
            // lblRoomNo
            // 
            this.lblRoomNo.AutoSize = true;
            this.lblRoomNo.Location = new System.Drawing.Point(116, 20);
            this.lblRoomNo.Name = "lblRoomNo";
            this.lblRoomNo.Size = new System.Drawing.Size(0, 12);
            this.lblRoomNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "房间号";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(267, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDeleteConsume
            // 
            this.btnDeleteConsume.Location = new System.Drawing.Point(6, 279);
            this.btnDeleteConsume.Name = "btnDeleteConsume";
            this.btnDeleteConsume.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteConsume.TabIndex = 1;
            this.btnDeleteConsume.Text = "删除";
            this.btnDeleteConsume.UseVisualStyleBackColor = true;
            this.btnDeleteConsume.Click += new System.EventHandler(this.btnDeleteConsume_Click);
            // 
            // dgvConsumeList
            // 
            this.dgvConsumeList.AllowUserToAddRows = false;
            this.dgvConsumeList.AllowUserToDeleteRows = false;
            this.dgvConsumeList.AllowUserToResizeRows = false;
            this.dgvConsumeList.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsumeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsumeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConsumeGoodsName,
            this.UnitPrice,
            this.Number,
            this.ConsumePrice,
            this.CreateDate,
            this.CreateUserName,
            this.GoodsIDD});
            this.dgvConsumeList.Location = new System.Drawing.Point(6, 43);
            this.dgvConsumeList.MultiSelect = false;
            this.dgvConsumeList.Name = "dgvConsumeList";
            this.dgvConsumeList.ReadOnly = true;
            this.dgvConsumeList.RowHeadersVisible = false;
            this.dgvConsumeList.RowTemplate.Height = 23;
            this.dgvConsumeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsumeList.Size = new System.Drawing.Size(395, 230);
            this.dgvConsumeList.TabIndex = 0;
            this.dgvConsumeList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConsumeList_CellMouseDoubleClick);
            // 
            // ConsumeGoodsName
            // 
            this.ConsumeGoodsName.HeaderText = "商品名称";
            this.ConsumeGoodsName.Name = "ConsumeGoodsName";
            this.ConsumeGoodsName.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "单价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            this.UnitPrice.Width = 60;
            // 
            // Number
            // 
            this.Number.HeaderText = "数量";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 60;
            // 
            // ConsumePrice
            // 
            this.ConsumePrice.HeaderText = "金额";
            this.ConsumePrice.Name = "ConsumePrice";
            this.ConsumePrice.ReadOnly = true;
            this.ConsumePrice.Width = 60;
            // 
            // CreateDate
            // 
            this.CreateDate.HeaderText = "消费时间";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // CreateUserName
            // 
            this.CreateUserName.HeaderText = "记账人";
            this.CreateUserName.Name = "CreateUserName";
            this.CreateUserName.ReadOnly = true;
            // 
            // GoodsIDD
            // 
            this.GoodsIDD.HeaderText = "id";
            this.GoodsIDD.Name = "GoodsIDD";
            this.GoodsIDD.ReadOnly = true;
            this.GoodsIDD.Visible = false;
            // 
            // FormAddPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(660, 354);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAddPay";
            this.Text = "增加消费";
            this.Load += new System.EventHandler(this.FormAddPay_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddPay_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvGoodsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.DataGridView dgvConsumeList;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDeleteConsume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblRoomNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumeGoodsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsumePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsIDD;
        private System.Windows.Forms.Button btnAdd;
    }
}