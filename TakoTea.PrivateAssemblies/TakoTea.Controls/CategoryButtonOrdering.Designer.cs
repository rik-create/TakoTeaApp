namespace TakoTea.Controls
{
    partial class CategoryButtonOrdering
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // ... (Existing Dispose method) ...

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCategory = new System.Windows.Forms.Button(); // Windows Forms Button
            this.SuspendLayout();
            // 
            // buttonCategory
            // 
            this.buttonCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCategory.FlatAppearance.BorderSize = 0; // Remove default border
            this.buttonCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat; // Flat appearance
            this.buttonCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); // Larger font
            this.buttonCategory.Location = new System.Drawing.Point(0, 0);
            this.buttonCategory.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCategory.Name = "buttonCategory";
            this.buttonCategory.Size = new System.Drawing.Size(161, 57);
            this.buttonCategory.TabIndex = 0;
            this.buttonCategory.Text = "All Categories";
            this.buttonCategory.UseVisualStyleBackColor = true;
            // 
            // CategoryButtonOrdering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke; // Set background color
            this.Controls.Add(this.buttonCategory);
            this.Name = "CategoryButtonOrdering";
            this.Padding = new System.Windows.Forms.Padding(5); // Add some padding
            this.Size = new System.Drawing.Size(161, 57);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonCategory; // Windows Forms Button
    }
}