namespace TakoTea.Controls
{
    partial class TakoyakiItemControl
    {
        private System.ComponentModel.IContainer components = null;

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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProductIcon
            // 
            this.pictureBoxProductIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProductIcon.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxProductIcon.Name = "pictureBoxProductIcon";
            this.pictureBoxProductIcon.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxProductIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProductIcon.TabIndex = 0;
            this.pictureBoxProductIcon.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(96, 32);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(77, 40);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "[Product]";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TakoyakiItemControl
            // 
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pictureBoxProductIcon);
            this.Controls.Add(this.titleLabel);
            this.Name = "TakoyakiItemControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(196, 96);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProductIcon)).EndInit();
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.PictureBox pictureBoxProductIcon;
        public System.Windows.Forms.Label titleLabel;
    }
}