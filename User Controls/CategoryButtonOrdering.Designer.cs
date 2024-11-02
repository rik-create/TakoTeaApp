namespace TakoTea.User_Controls
{
    partial class CategoryButtonOrdering
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
            this.materialButtonCategory = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialButtonCategory
            // 
            this.materialButtonCategory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonCategory.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonCategory.Depth = 0;
            this.materialButtonCategory.HighEmphasis = true;
            this.materialButtonCategory.Icon = null;
            this.materialButtonCategory.Location = new System.Drawing.Point(10, 10);
            this.materialButtonCategory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonCategory.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonCategory.Name = "materialButtonCategory";
            this.materialButtonCategory.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonCategory.Size = new System.Drawing.Size(138, 36);
            this.materialButtonCategory.TabIndex = 0;
            this.materialButtonCategory.Text = "All Categories";
            this.materialButtonCategory.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonCategory.UseAccentColor = false;
            this.materialButtonCategory.UseVisualStyleBackColor = true;
            this.materialButtonCategory.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // CategoryButtonOrdering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialButtonCategory);
            this.Name = "CategoryButtonOrdering";
            this.Size = new System.Drawing.Size(161, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButtonCategory;
    }
}
