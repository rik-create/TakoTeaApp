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
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.panelProductContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // panelProductContainer
            // 
            this.panelProductContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelProductContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductContainer.Controls.Add(this.lblProductCategory);
            this.panelProductContainer.Controls.Add(this.lblProductName);
            this.panelProductContainer.Controls.Add(this.pictureBoxProduct);
            this.panelProductContainer.Location = new System.Drawing.Point(10, 10);
            this.panelProductContainer.Name = "panelProductContainer";
            this.panelProductContainer.Size = new System.Drawing.Size(140, 180);
            this.panelProductContainer.TabIndex = 0;
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductCategory.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCategory.Location = new System.Drawing.Point(0, 120);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(138, 30);
            this.lblProductCategory.TabIndex = 8;
            this.lblProductCategory.Text = "Category";
            this.lblProductCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName
            // 
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProductName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(0, 150);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblProductName.Size = new System.Drawing.Size(138, 28);
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
            this.pictureBoxProduct.Size = new System.Drawing.Size(138, 120);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panelProductContainer;
        public System.Windows.Forms.Label lblProductName;
        public System.Windows.Forms.PictureBox pictureBoxProduct;
        public System.Windows.Forms.Label lblProductCategory; // New label for category
    }
}