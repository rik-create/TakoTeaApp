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
            this.lblProductPrice = new MaterialSkin.Controls.MaterialLabel();
            this.lblProductName = new MaterialSkin.Controls.MaterialLabel();
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
            this.lblProductPrice.AutoSize = true;
            this.lblProductPrice.Depth = 0;
            this.lblProductPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblProductPrice.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblProductPrice.Location = new System.Drawing.Point(39, 30);
            this.lblProductPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(58, 19);
            this.lblProductPrice.TabIndex = 6;
            this.lblProductPrice.Text = "PHP: 30";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Depth = 0;
            this.lblProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProductName.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblProductName.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(19, 10);
            this.lblProductName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(90, 17);
            this.lblProductName.TabIndex = 5;
            this.lblProductName.Text = "Octo-takoyaki";
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
            this.panelLblHolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Panel panelLblHolder;
        private MaterialSkin.Controls.MaterialLabel lblProductPrice;
        private MaterialSkin.Controls.MaterialLabel lblProductName;
        public System.Windows.Forms.Panel panelProductContainer;
    }
}
