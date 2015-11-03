namespace Hotel
{
    partial class FormReports
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
            this.label1 = new System.Windows.Forms.Label();
            this.pbtnIncomeRpt = new System.Windows.Forms.PictureBox();
            this.pbtnHandHisRpt = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbtnCustomerStay = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbtnStayRateRpt = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnIncomeRpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnHandHisRpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnCustomerStay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnStayRateRpt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "收入报表";
            // 
            // pbtnIncomeRpt
            // 
            this.pbtnIncomeRpt.BackgroundImage = global::Hotel.Properties.Resources.Report;
            this.pbtnIncomeRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnIncomeRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnIncomeRpt.Location = new System.Drawing.Point(37, 22);
            this.pbtnIncomeRpt.Name = "pbtnIncomeRpt";
            this.pbtnIncomeRpt.Size = new System.Drawing.Size(48, 48);
            this.pbtnIncomeRpt.TabIndex = 0;
            this.pbtnIncomeRpt.TabStop = false;
            this.pbtnIncomeRpt.Click += new System.EventHandler(this.pbtnIncomeRpt_Click);
            // 
            // pbtnHandHisRpt
            // 
            this.pbtnHandHisRpt.BackgroundImage = global::Hotel.Properties.Resources.Report;
            this.pbtnHandHisRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnHandHisRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnHandHisRpt.Location = new System.Drawing.Point(124, 22);
            this.pbtnHandHisRpt.Name = "pbtnHandHisRpt";
            this.pbtnHandHisRpt.Size = new System.Drawing.Size(48, 48);
            this.pbtnHandHisRpt.TabIndex = 0;
            this.pbtnHandHisRpt.TabStop = false;
            this.pbtnHandHisRpt.Click += new System.EventHandler(this.pbtnHandHisRpt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "交班历史查询";
            // 
            // pbtnCustomerStay
            // 
            this.pbtnCustomerStay.BackgroundImage = global::Hotel.Properties.Resources.Report;
            this.pbtnCustomerStay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnCustomerStay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnCustomerStay.Location = new System.Drawing.Point(222, 22);
            this.pbtnCustomerStay.Name = "pbtnCustomerStay";
            this.pbtnCustomerStay.Size = new System.Drawing.Size(48, 48);
            this.pbtnCustomerStay.TabIndex = 0;
            this.pbtnCustomerStay.TabStop = false;
            this.pbtnCustomerStay.Click += new System.EventHandler(this.pbtnCustomerStay_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "宾客信息查询";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "宾馆入住率";
            // 
            // pbtnStayRateRpt
            // 
            this.pbtnStayRateRpt.BackgroundImage = global::Hotel.Properties.Resources.Report;
            this.pbtnStayRateRpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnStayRateRpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnStayRateRpt.Location = new System.Drawing.Point(322, 22);
            this.pbtnStayRateRpt.Name = "pbtnStayRateRpt";
            this.pbtnStayRateRpt.Size = new System.Drawing.Size(48, 48);
            this.pbtnStayRateRpt.TabIndex = 2;
            this.pbtnStayRateRpt.TabStop = false;
            this.pbtnStayRateRpt.Click += new System.EventHandler(this.pbtnStayRateRpt_Click);
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(477, 515);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbtnStayRateRpt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbtnCustomerStay);
            this.Controls.Add(this.pbtnHandHisRpt);
            this.Controls.Add(this.pbtnIncomeRpt);
            this.Name = "FormReports";
            this.Text = "报表查询";
            ((System.ComponentModel.ISupportInitialize)(this.pbtnIncomeRpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnHandHisRpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnCustomerStay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnStayRateRpt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbtnIncomeRpt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbtnHandHisRpt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbtnCustomerStay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbtnStayRateRpt;
    }
}