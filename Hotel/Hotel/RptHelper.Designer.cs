namespace Hotel
{
    partial class RptHelper
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbtnExcel = new System.Windows.Forms.PictureBox();
            this.pbtnPrint = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // pbtnExcel
            // 
            this.pbtnExcel.BackgroundImage = global::Hotel.Properties.Resources.Excel;
            this.pbtnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnExcel.Location = new System.Drawing.Point(3, 12);
            this.pbtnExcel.Name = "pbtnExcel";
            this.pbtnExcel.Size = new System.Drawing.Size(45, 70);
            this.pbtnExcel.TabIndex = 25;
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
            this.pbtnPrint.Location = new System.Drawing.Point(74, 12);
            this.pbtnPrint.Name = "pbtnPrint";
            this.pbtnPrint.Size = new System.Drawing.Size(45, 70);
            this.pbtnPrint.TabIndex = 24;
            this.pbtnPrint.TabStop = false;
            this.pbtnPrint.MouseLeave += new System.EventHandler(this.pbtn_MouseLeave);
            this.pbtnPrint.Click += new System.EventHandler(this.pbtnPrint_Click);
            this.pbtnPrint.Paint += new System.Windows.Forms.PaintEventHandler(this.pbt_Paint);
            this.pbtnPrint.MouseEnter += new System.EventHandler(this.pbtn_MouseEnter);
            // 
            // RptHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbtnExcel);
            this.Controls.Add(this.pbtnPrint);
            this.Name = "RptHelper";
            this.Size = new System.Drawing.Size(122, 85);
            ((System.ComponentModel.ISupportInitialize)(this.pbtnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbtnExcel;
        private System.Windows.Forms.PictureBox pbtnPrint;
    }
}
