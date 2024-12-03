using System.Drawing;
using System.Windows.Forms;

namespace TakoTea.Views.mainform
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtBoxUserName = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtBoxPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(128)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(117, 177);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "TakoTea POS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(100, 372);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(216, 32);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Sign in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.AnimateReadOnly = false;
            this.txtBoxUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxUserName.Depth = 0;
            this.txtBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxUserName.HelperText = "Username";
            this.txtBoxUserName.HideSelection = true;
            this.txtBoxUserName.Hint = "Username";
            this.txtBoxUserName.LeadingIcon = null;
            this.txtBoxUserName.Location = new System.Drawing.Point(34, 236);
            this.txtBoxUserName.MaxLength = 32767;
            this.txtBoxUserName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.PasswordChar = '\0';
            this.txtBoxUserName.PrefixSuffixText = null;
            this.txtBoxUserName.ReadOnly = false;
            this.txtBoxUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxUserName.SelectedText = "";
            this.txtBoxUserName.SelectionLength = 0;
            this.txtBoxUserName.SelectionStart = 0;
            this.txtBoxUserName.ShortcutsEnabled = true;
            this.txtBoxUserName.ShowAssistiveText = true;
            this.txtBoxUserName.Size = new System.Drawing.Size(339, 52);
            this.txtBoxUserName.TabIndex = 6;
            this.txtBoxUserName.TabStop = false;
            this.txtBoxUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip1.SetToolTip(this.txtBoxUserName, "Username");
            this.txtBoxUserName.TrailingIcon = null;
            this.txtBoxUserName.UseAccent = false;
            this.txtBoxUserName.UseSystemPasswordChar = false;
            this.txtBoxUserName.UseTallSize = false;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.AnimateReadOnly = false;
            this.txtBoxPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxPassword.Depth = 0;
            this.txtBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxPassword.HelperText = "Password";
            this.txtBoxPassword.HideSelection = true;
            this.txtBoxPassword.Hint = "Password";
            this.txtBoxPassword.LeadingIcon = null;
            this.txtBoxPassword.Location = new System.Drawing.Point(34, 304);
            this.txtBoxPassword.MaxLength = 32767;
            this.txtBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '●';
            this.txtBoxPassword.PrefixSuffixText = null;
            this.txtBoxPassword.ReadOnly = false;
            this.txtBoxPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxPassword.SelectedText = "";
            this.txtBoxPassword.SelectionLength = 0;
            this.txtBoxPassword.SelectionStart = 0;
            this.txtBoxPassword.ShortcutsEnabled = true;
            this.txtBoxPassword.ShowAssistiveText = true;
            this.txtBoxPassword.Size = new System.Drawing.Size(339, 52);
            this.txtBoxPassword.TabIndex = 6;
            this.txtBoxPassword.TabStop = false;
            this.txtBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip1.SetToolTip(this.txtBoxPassword, "Password");
            this.txtBoxPassword.TrailingIcon = null;
            this.txtBoxPassword.UseSystemPasswordChar = true;
            this.txtBoxPassword.UseTallSize = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(123, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(407, 427);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(325, 384);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TakoTea POS Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private MaterialSkin.Controls.MaterialTextBox2 txtBoxUserName;
        private MaterialSkin.Controls.MaterialTextBox2 txtBoxPassword;
        private ToolTip toolTip1;
    }
}