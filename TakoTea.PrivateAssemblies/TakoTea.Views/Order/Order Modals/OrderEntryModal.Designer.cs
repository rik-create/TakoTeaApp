using System.Windows.Forms;

namespace TakoTea.Views.Order.Order_Modals
{
    partial class OrderEntryModal
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.groupBoxProduct = new System.Windows.Forms.GroupBox();
            this.productCard = new TakoTea.Controls.TakoyakiItemControl();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbSizes = new MaterialSkin.Controls.MaterialComboBox();
            this.chckListBoxAddOns = new System.Windows.Forms.CheckedListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddToDgViewOrderList = new System.Windows.Forms.Button();
            this.lblTotalPrice = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.materialCard1.SuspendLayout();
            this.groupBoxProduct.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.groupBoxProduct);
            this.materialCard1.Controls.Add(this.panel2);
            this.materialCard1.Controls.Add(this.panel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 24);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(528, 423);
            this.materialCard1.TabIndex = 0;
            // 
            // groupBoxProduct
            // 
            this.groupBoxProduct.Controls.Add(this.productCard);
            this.groupBoxProduct.Controls.Add(this.materialLabel3);
            this.groupBoxProduct.Controls.Add(this.cmbSizes);
            this.groupBoxProduct.Controls.Add(this.chckListBoxAddOns);
            this.groupBoxProduct.Controls.Add(this.materialLabel2);
            this.groupBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProduct.Location = new System.Drawing.Point(14, 60);
            this.groupBoxProduct.Name = "groupBoxProduct";
            this.groupBoxProduct.Size = new System.Drawing.Size(500, 310);
            this.groupBoxProduct.TabIndex = 103;
            this.groupBoxProduct.TabStop = false;
            this.groupBoxProduct.Text = "Product";
            // 
            // productCard
            // 
            this.productCard.BackColor = System.Drawing.Color.White;
            this.productCard.Location = new System.Drawing.Point(64, 32);
            this.productCard.Name = "productCard";
            this.productCard.Padding = new System.Windows.Forms.Padding(5);
            this.productCard.Size = new System.Drawing.Size(350, 75);
            this.productCard.TabIndex = 133;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(60, 120);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(40, 23);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Sizes";
            // 
            // cmbSizes
            // 
            this.cmbSizes.AutoResize = false;
            this.cmbSizes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbSizes.Depth = 0;
            this.cmbSizes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSizes.DropDownHeight = 174;
            this.cmbSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizes.DropDownWidth = 121;
            this.cmbSizes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbSizes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbSizes.FormattingEnabled = true;
            this.cmbSizes.Hint = "Choose size";
            this.cmbSizes.IntegralHeight = false;
            this.cmbSizes.ItemHeight = 43;
            this.cmbSizes.Location = new System.Drawing.Point(60, 150);
            this.cmbSizes.MaxDropDownItems = 4;
            this.cmbSizes.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbSizes.Name = "cmbSizes";
            this.cmbSizes.Size = new System.Drawing.Size(360, 49);
            this.cmbSizes.StartIndex = 0;
            this.cmbSizes.TabIndex = 132;
            // 
            // chckListBoxAddOns
            // 
            this.chckListBoxAddOns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chckListBoxAddOns.CheckOnClick = true;
            this.chckListBoxAddOns.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chckListBoxAddOns.FormattingEnabled = true;
            this.chckListBoxAddOns.Location = new System.Drawing.Point(64, 240);
            this.chckListBoxAddOns.Name = "chckListBoxAddOns";
            this.chckListBoxAddOns.Size = new System.Drawing.Size(360, 60);
            this.chckListBoxAddOns.TabIndex = 134;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(60, 210);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(240, 23);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = " Add Ons (Optional, max 4)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.materialLabel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(14, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 46);
            this.panel2.TabIndex = 101;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel4.Location = new System.Drawing.Point(224, 10);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(51, 24);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Order";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddToDgViewOrderList);
            this.panel1.Controls.Add(this.lblTotalPrice);
            this.panel1.Controls.Add(this.numericUpDownQuantity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(14, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 39);
            this.panel1.TabIndex = 1;
            // 
            // btnAddToDgViewOrderList
            // 
            this.btnAddToDgViewOrderList.Location = new System.Drawing.Point(410, 10);
            this.btnAddToDgViewOrderList.Name = "btnAddToDgViewOrderList";
            this.btnAddToDgViewOrderList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToDgViewOrderList.TabIndex = 2;
            this.btnAddToDgViewOrderList.Text = "Add";
            this.btnAddToDgViewOrderList.UseVisualStyleBackColor = true;
            this.btnAddToDgViewOrderList.Click += new System.EventHandler(this.btnAddToDgViewOrderList_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Depth = 0;
            this.lblTotalPrice.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalPrice.Location = new System.Drawing.Point(150, 10);
            this.lblTotalPrice.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(70, 23);
            this.lblTotalPrice.TabIndex = 1;
            this.lblTotalPrice.Text = "PHP 200";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(20, 10);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantity.TabIndex = 0;
            this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.numericUpDownQuantity_ValueChanged);
            // 
            // OrderEntryModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 450);
            this.Controls.Add(this.materialCard1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "OrderEntryModal";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.Text = "OrderEntryModal";
            this.materialCard1.ResumeLayout(false);
            this.groupBoxProduct.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddToDgViewOrderList;
        private MaterialSkin.Controls.MaterialLabel lblTotalPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.GroupBox groupBoxProduct;
        private Controls.TakoyakiItemControl productCard;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox cmbSizes;
        private System.Windows.Forms.CheckedListBox chckListBoxAddOns;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}