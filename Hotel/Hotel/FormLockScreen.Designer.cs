namespace Hotel
{
    partial class FormLockScreen
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.btnUnLock = new System.Windows.Forms.Button();
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(105, 66);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 2;
            // 
            // pnlBorder
            // 
            this.pnlBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBorder.Controls.Add(this.label1);
            this.pnlBorder.Controls.Add(this.lblMsg);
            this.pnlBorder.Controls.Add(this.txtPsw);
            this.pnlBorder.Controls.Add(this.btnUnLock);
            this.pnlBorder.Location = new System.Drawing.Point(12, 1);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Size = new System.Drawing.Size(278, 87);
            this.pnlBorder.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "请输入解锁密码";
            // 
            // txtPsw
            // 
            this.txtPsw.Location = new System.Drawing.Point(107, 39);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(112, 21);
            this.txtPsw.TabIndex = 0;
            this.txtPsw.UseSystemPasswordChar = true;
            // 
            // btnUnLock
            // 
            this.btnUnLock.Location = new System.Drawing.Point(227, 38);
            this.btnUnLock.Name = "btnUnLock";
            this.btnUnLock.Size = new System.Drawing.Size(46, 23);
            this.btnUnLock.TabIndex = 6;
            this.btnUnLock.Text = "解锁";
            this.btnUnLock.UseVisualStyleBackColor = true;
            this.btnUnLock.Click += new System.EventHandler(this.btnUnLock_Click);
            // 
            // FormLockScreen
            // 
            this.AcceptButton = this.btnUnLock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(291, 100);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBorder);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLockScreen";
            this.ShowInTaskbar = false;
            this.Text = "FormLockScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLockScreen_FormClosing);
            this.pnlBorder.ResumeLayout(false);
            this.pnlBorder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.Button btnUnLock;
    }
}