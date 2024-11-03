namespace TakoTea.User_Controls
{
    partial class TakoyakiItemControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxProductIcon;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label priceLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxProductIcon = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProductIcon
            // 
            this.pictureBoxProductIcon.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxProductIcon.Name = "pictureBoxProductIcon";
            this.pictureBoxProductIcon.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxProductIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProductIcon.TabIndex = 0;
            this.pictureBoxProductIcon.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(100, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(72, 19);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "[Product]";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.descriptionLabel.Location = new System.Drawing.Point(100, 40);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(72, 13);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "[Description]";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.priceLabel.ForeColor = System.Drawing.Color.Black;
            this.priceLabel.Location = new System.Drawing.Point(270, 10);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(54, 21);
            this.priceLabel.TabIndex = 3;
            this.priceLabel.Text = "[PHP]";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TakoyakiItemControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBoxProductIcon);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.priceLabel);
            this.Name = "TakoyakiItemControl";
            this.Size = new System.Drawing.Size(350, 100);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
