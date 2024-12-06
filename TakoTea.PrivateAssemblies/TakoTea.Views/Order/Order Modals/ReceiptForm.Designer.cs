namespace TakoTea.Views.Order.Order_Modals
{
    partial class ReceiptForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReceiptContent = new System.Windows.Forms.Label();
            this.buttonSendToEmail = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblReceiptContent);
            this.panel1.Controls.Add(this.buttonSendToEmail);
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 450);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblReceiptContent
            // 
            this.lblReceiptContent.AutoSize = true;
            this.lblReceiptContent.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptContent.Location = new System.Drawing.Point(10, 9);
            this.lblReceiptContent.Name = "lblReceiptContent";
            this.lblReceiptContent.Size = new System.Drawing.Size(144, 17);
            this.lblReceiptContent.TabIndex = 3;
            this.lblReceiptContent.Text = "[Receipt Content]";
            // 
            // buttonSendToEmail
            // 
            this.buttonSendToEmail.Location = new System.Drawing.Point(205, 420);
            this.buttonSendToEmail.Name = "buttonSendToEmail";
            this.buttonSendToEmail.Size = new System.Drawing.Size(87, 23);
            this.buttonSendToEmail.TabIndex = 2;
            this.buttonSendToEmail.Text = "Send to email";
            this.buttonSendToEmail.UseVisualStyleBackColor = true;
            this.buttonSendToEmail.Click += new System.EventHandler(this.buttonSendToEmail_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(296, 420);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ReceiptForm";
            this.Text = "ReceiptForm";
            this.Load += new System.EventHandler(this.ReceiptReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button buttonSendToEmail;
        public System.Windows.Forms.Button buttonPrint;
        public System.Windows.Forms.Label lblReceiptContent;
    }
}