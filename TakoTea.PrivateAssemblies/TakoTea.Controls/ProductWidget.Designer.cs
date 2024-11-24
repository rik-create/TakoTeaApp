namespace TakoTea.Controls
{
    partial class ProductWidget
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
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelProductContainer = new System.Windows.Forms.Panel();
            this.panelLblHolder = new System.Windows.Forms.Panel();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.panelProductContainer.SuspendLayout();
            this.panelLblHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // panelProductContainer
            // 
            this.panelProductContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelProductContainer.Controls.Add(this.panelLblHolder);
            this.panelProductContainer.Controls.Add(this.pictureBoxProduct);
            this.panelProductContainer.Location = new System.Drawing.Point(10, 10);
            this.panelProductContainer.Name = "panelProductContainer";
            this.panelProductContainer.Size = new System.Drawing.Size(140, 180);
            this.panelProductContainer.TabIndex = 0;
            // 
            // panelLblHolder
            // 
            this.panelLblHolder.Controls.Add(this.lblProductPrice);
            this.panelLblHolder.Controls.Add(this.lblProductName);
            this.panelLblHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLblHolder.Location = new System.Drawing.Point(0, 120);
            this.panelLblHolder.Name = "panelLblHolder";
            this.panelLblHolder.Size = new System.Drawing.Size(136, 56);
            this.panelLblHolder.TabIndex = 5;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductPrice.Location = new System.Drawing.Point(8, 32);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(120, 23);
            this.lblProductPrice.TabIndex = 7;
            this.lblProductPrice.Text = "PHP 1,000";
            this.lblProductPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(8, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(120, 23);
            this.lblProductName.TabIndex = 7;
            this.lblProductName.Text = "Takoyaki";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxProduct.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(136, 120);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 4;
            this.pictureBoxProduct.TabStop = false;
            // 
            // ProductWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panelProductContainer);
            this.Name = "ProductWidget";
            this.Size = new System.Drawing.Size(160, 196);
            this.Load += new System.EventHandler(this.ProductWidget_Load);
            this.panelProductContainer.ResumeLayout(false);
            this.panelLblHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        public System.Windows.Forms.PictureBox pictureBoxProduct;
        public System.Windows.Forms.Panel panelLblHolder;
        public System.Windows.Forms.Panel panelProductContainer;
        public System.Windows.Forms.Label lblProductPrice;
        public System.Windows.Forms.Label lblProductName;
    }
}
