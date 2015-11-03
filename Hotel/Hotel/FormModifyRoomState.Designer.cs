namespace Hotel
{
    partial class FormModifyRoomState
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
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.pbtnInRoom = new System.Windows.Forms.PictureBox();
            this.pbtnDisable = new System.Windows.Forms.PictureBox();
            this.pbtnClean = new System.Windows.Forms.PictureBox();
            this.pbtnOrder = new System.Windows.Forms.PictureBox();
            this.pbtnEnable = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRoomStatus = new System.Windows.Forms.Label();
            this.lblRoomNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnDisable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnClean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnEnable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNotice);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pbtnInRoom);
            this.groupBox1.Controls.Add(this.pbtnDisable);
            this.groupBox1.Controls.Add(this.pbtnClean);
            this.groupBox1.Controls.Add(this.pbtnOrder);
            this.groupBox1.Controls.Add(this.pbtnEnable);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblRoomStatus);
            this.groupBox1.Controls.Add(this.lblRoomNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 164);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(77, 112);
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.Size = new System.Drawing.Size(254, 21);
            this.txtNotice.TabIndex = 5;
            // 
            // pbtnInRoom
            // 
            this.pbtnInRoom.BackgroundImage = global::Hotel.Properties.Resources.InRoom;
            this.pbtnInRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnInRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnInRoom.Location = new System.Drawing.Point(77, 49);
            this.pbtnInRoom.Name = "pbtnInRoom";
            this.pbtnInRoom.Size = new System.Drawing.Size(32, 32);
            this.pbtnInRoom.TabIndex = 3;
            this.pbtnInRoom.TabStop = false;
            this.pbtnInRoom.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnInRoom.Click += new System.EventHandler(this.pbtnInRoom_Click);
            this.pbtnInRoom.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnDisable
            // 
            this.pbtnDisable.BackgroundImage = global::Hotel.Properties.Resources.DisableRoom;
            this.pbtnDisable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnDisable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnDisable.Location = new System.Drawing.Point(299, 49);
            this.pbtnDisable.Name = "pbtnDisable";
            this.pbtnDisable.Size = new System.Drawing.Size(32, 32);
            this.pbtnDisable.TabIndex = 3;
            this.pbtnDisable.TabStop = false;
            this.pbtnDisable.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnDisable.Click += new System.EventHandler(this.pbtnDisable_Click);
            this.pbtnDisable.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnClean
            // 
            this.pbtnClean.BackgroundImage = global::Hotel.Properties.Resources.CleanRoom;
            this.pbtnClean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnClean.Location = new System.Drawing.Point(187, 49);
            this.pbtnClean.Name = "pbtnClean";
            this.pbtnClean.Size = new System.Drawing.Size(32, 32);
            this.pbtnClean.TabIndex = 3;
            this.pbtnClean.TabStop = false;
            this.pbtnClean.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnClean.Click += new System.EventHandler(this.pbtnClean_Click);
            this.pbtnClean.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnOrder
            // 
            this.pbtnOrder.BackgroundImage = global::Hotel.Properties.Resources.OrderRoom;
            this.pbtnOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnOrder.Location = new System.Drawing.Point(241, 49);
            this.pbtnOrder.Name = "pbtnOrder";
            this.pbtnOrder.Size = new System.Drawing.Size(32, 32);
            this.pbtnOrder.TabIndex = 3;
            this.pbtnOrder.TabStop = false;
            this.pbtnOrder.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnOrder.Click += new System.EventHandler(this.pbtnOrder_Click);
            this.pbtnOrder.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // pbtnEnable
            // 
            this.pbtnEnable.BackgroundImage = global::Hotel.Properties.Resources.EnableRoom;
            this.pbtnEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbtnEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnEnable.Location = new System.Drawing.Point(18, 49);
            this.pbtnEnable.Name = "pbtnEnable";
            this.pbtnEnable.Size = new System.Drawing.Size(32, 32);
            this.pbtnEnable.TabIndex = 3;
            this.pbtnEnable.TabStop = false;
            this.pbtnEnable.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pbtnEnable.Click += new System.EventHandler(this.pbtnEnable_Click);
            this.pbtnEnable.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "停用";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "预定";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "清理";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "散客";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "可用";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "当前状态";
            // 
            // lblRoomStatus
            // 
            this.lblRoomStatus.AutoSize = true;
            this.lblRoomStatus.Location = new System.Drawing.Point(298, 21);
            this.lblRoomStatus.Name = "lblRoomStatus";
            this.lblRoomStatus.Size = new System.Drawing.Size(0, 12);
            this.lblRoomStatus.TabIndex = 0;
            // 
            // lblRoomNo
            // 
            this.lblRoomNo.AutoSize = true;
            this.lblRoomNo.Location = new System.Drawing.Point(77, 21);
            this.lblRoomNo.Name = "lblRoomNo";
            this.lblRoomNo.Size = new System.Drawing.Size(0, 12);
            this.lblRoomNo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "备注";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前房间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "团队";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Hotel.Properties.Resources.OccupyRoom;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(133, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pbMouseLeave);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pbMouseEnter);
            // 
            // FormModifyRoomState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(382, 189);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormModifyRoomState";
            this.Text = "修改房态";
            this.Load += new System.EventHandler(this.FormModifyRoomState_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnInRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnDisable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnClean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnEnable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbtnOrder;
        private System.Windows.Forms.PictureBox pbtnDisable;
        private System.Windows.Forms.PictureBox pbtnInRoom;
        private System.Windows.Forms.Label lblRoomNo;
        private System.Windows.Forms.Label lblRoomStatus;
        private System.Windows.Forms.PictureBox pbtnClean;
        private System.Windows.Forms.PictureBox pbtnEnable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNotice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}