namespace TakoTea.Dashboard
{
    partial class StockAlertsForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialButtonEditThreshold = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonViewStock = new MaterialSkin.Controls.MaterialButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.panelMain.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.progressBar1);
            this.panelMain.Controls.Add(this.materialCard1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.panelMain.Size = new System.Drawing.Size(1118, 615);
            this.panelMain.TabIndex = 18;
            // 
            // materialCard1
            // 
            this.materialCard1.AutoSize = true;
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.panel1);
            this.materialCard1.Controls.Add(this.materialButtonViewStock);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(23, 23);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1011, 629);
            this.materialCard1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.materialButton1);
            this.panel1.Controls.Add(this.materialButton2);
            this.panel1.Controls.Add(this.materialButtonEditThreshold);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(17, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 538);
            this.panel1.TabIndex = 2;
            // 
            // materialButtonEditThreshold
            // 
            this.materialButtonEditThreshold.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonEditThreshold.BackColor = System.Drawing.SystemColors.Control;
            this.materialButtonEditThreshold.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonEditThreshold.Depth = 0;
            this.materialButtonEditThreshold.HighEmphasis = true;
            this.materialButtonEditThreshold.Icon = null;
            this.materialButtonEditThreshold.Location = new System.Drawing.Point(783, 45);
            this.materialButtonEditThreshold.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonEditThreshold.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonEditThreshold.Name = "materialButtonEditThreshold";
            this.materialButtonEditThreshold.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonEditThreshold.Size = new System.Drawing.Size(141, 36);
            this.materialButtonEditThreshold.TabIndex = 10;
            this.materialButtonEditThreshold.Text = "Edit Threshold";
            this.materialButtonEditThreshold.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonEditThreshold.UseAccentColor = false;
            this.materialButtonEditThreshold.UseVisualStyleBackColor = false;
            // 
            // materialButtonViewStock
            // 
            this.materialButtonViewStock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonViewStock.BackColor = System.Drawing.SystemColors.Control;
            this.materialButtonViewStock.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonViewStock.Depth = 0;
            this.materialButtonViewStock.HighEmphasis = true;
            this.materialButtonViewStock.Icon = null;
            this.materialButtonViewStock.Location = new System.Drawing.Point(792, 29);
            this.materialButtonViewStock.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonViewStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonViewStock.Name = "materialButtonViewStock";
            this.materialButtonViewStock.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonViewStock.Size = new System.Drawing.Size(162, 36);
            this.materialButtonViewStock.TabIndex = 9;
            this.materialButtonViewStock.Text = "View Stock Levels";
            this.materialButtonViewStock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonViewStock.UseAccentColor = false;
            this.materialButtonViewStock.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(934, 456);
            this.dataGridView1.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(991, 215);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(123, 10);
            this.progressBar1.TabIndex = 85;
            this.progressBar1.Visible = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(17, 505);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(15, 15, 450, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(191, 19);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "Showing 1 to 3 of 10 alerts";
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(786, 496);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(91, 36);
            this.materialButton1.TabIndex = 12;
            this.materialButton1.Text = "Previous";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = true;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(885, 496);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(64, 36);
            this.materialButton2.TabIndex = 13;
            this.materialButton2.Text = "Next";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = true;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // StockAlertsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1118, 615);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.DoubleBuffered = false;
            this.DrawerAutoHide = false;
            this.DrawerHighlightWithAccent = false;
            this.DrawerWidth = 0;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockAlertsForm";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StockAlerts";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton materialButtonEditThreshold;
        private MaterialSkin.Controls.MaterialButton materialButtonViewStock;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
    }
}