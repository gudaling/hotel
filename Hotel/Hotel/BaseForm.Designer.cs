namespace Hotel
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.skinCollectionItem1 = new Sunisoft.IrisSkin.SkinCollectionItem();
            this.skinCollectionItem2 = new Sunisoft.IrisSkin.SkinCollectionItem();
            this.skinCollectionItem3 = new Sunisoft.IrisSkin.SkinCollectionItem();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.AddtionalBuiltInSkins.Add(this.skinCollectionItem1);
            this.skinEngine1.AddtionalBuiltInSkins.Add(this.skinCollectionItem2);
            this.skinEngine1.AddtionalBuiltInSkins.Add(this.skinCollectionItem3);
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // skinCollectionItem1
            // 
            this.skinCollectionItem1.SkinPassword = null;
            this.skinCollectionItem1.SkinSteam = ((System.IO.MemoryStream)(resources.GetObject("skinCollectionItem1.SkinSteam")));
            // 
            // skinCollectionItem2
            // 
            this.skinCollectionItem2.SkinPassword = null;
            this.skinCollectionItem2.SkinSteam = ((System.IO.MemoryStream)(resources.GetObject("skinCollectionItem2.SkinSteam")));
            // 
            // skinCollectionItem3
            // 
            this.skinCollectionItem3.SkinPassword = null;
            this.skinCollectionItem3.SkinSteam = ((System.IO.MemoryStream)(resources.GetObject("skinCollectionItem3.SkinSteam")));
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.ResumeLayout(false);

        }

        #endregion

        public Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private Sunisoft.IrisSkin.SkinCollectionItem skinCollectionItem1;
        private Sunisoft.IrisSkin.SkinCollectionItem skinCollectionItem2;
        private Sunisoft.IrisSkin.SkinCollectionItem skinCollectionItem3;
    }
}