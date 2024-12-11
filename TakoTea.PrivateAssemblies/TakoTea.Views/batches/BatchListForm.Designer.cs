namespace TakoTea.View.Batches
{
    partial class BatchListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchListForm));
            this.miniToolStrip = new System.Windows.Forms.BindingNavigator(this.components);
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFilteringComponents = new System.Windows.Forms.Panel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnClearFilters = new MaterialSkin.Controls.MaterialButton();
            this.panelItemList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pBoxShowFilter = new System.Windows.Forms.PictureBox();
            this.btnHideFilters = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.panelExportButtons = new System.Windows.Forms.Panel();
            this.pictureBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pictureBoxExportPdf = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewBatch = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorBatch = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).BeginInit();
            this.materialCard2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelFilteringComponents.SuspendLayout();
            this.panelItemList.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxShowFilter)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExportButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorBatch)).BeginInit();
            this.bindingNavigatorBatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AddNewItem = null;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.CountItem = null;
            this.miniToolStrip.DeleteItem = null;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(252, 3);
            this.miniToolStrip.MoveFirstItem = null;
            this.miniToolStrip.MoveLastItem = null;
            this.miniToolStrip.MoveNextItem = null;
            this.miniToolStrip.MovePreviousItem = null;
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.PositionItem = null;
            this.miniToolStrip.Size = new System.Drawing.Size(940, 25);
            this.miniToolStrip.TabIndex = 9;
            // 
            // materialCard2
            // 
            this.materialCard2.AutoScroll = true;
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.materialCard2.Controls.Add(this.flowLayoutPanel1);
            this.materialCard2.Controls.Add(this.panel3);
            this.materialCard2.Controls.Add(this.panel1);
            this.materialCard2.Controls.Add(this.panelExportButtons);
            this.materialCard2.Depth = 0;
            this.materialCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(3, 0);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(0);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(1191, 715);
            this.materialCard2.TabIndex = 70;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panelFilteringComponents);
            this.flowLayoutPanel1.Controls.Add(this.panelItemList);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 130);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1150, 520);
            this.flowLayoutPanel1.TabIndex = 105;
            // 
            // panelFilteringComponents
            // 
            this.panelFilteringComponents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilteringComponents.Controls.Add(this.materialLabel3);
            this.panelFilteringComponents.Controls.Add(this.dateTimePickerEndDate);
            this.panelFilteringComponents.Controls.Add(this.dateTimePickerStartDate);
            this.panelFilteringComponents.Controls.Add(this.btnClearFilters);
            this.panelFilteringComponents.Enabled = false;
            this.panelFilteringComponents.Location = new System.Drawing.Point(3, 3);
            this.panelFilteringComponents.Name = "panelFilteringComponents";
            this.panelFilteringComponents.Size = new System.Drawing.Size(1127, 110);
            this.panelFilteringComponents.TabIndex = 107;
            this.panelFilteringComponents.Visible = false;
            this.panelFilteringComponents.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFilteringComponents_Paint);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(16, 8);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(87, 19);
            this.materialLabel3.TabIndex = 147;
            this.materialLabel3.Text = "Date Range:";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(190, 40);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(159, 31);
            this.dateTimePickerEndDate.TabIndex = 146;
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(16, 40);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(159, 31);
            this.dateTimePickerStartDate.TabIndex = 145;
            this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStartDate_ValueChanged);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearFilters.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearFilters.Depth = 0;
            this.btnClearFilters.HighEmphasis = true;
            this.btnClearFilters.Icon = null;
            this.btnClearFilters.Location = new System.Drawing.Point(984, 8);
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClearFilters.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClearFilters.Size = new System.Drawing.Size(126, 36);
            this.btnClearFilters.TabIndex = 143;
            this.btnClearFilters.Text = "Clear filters";
            this.btnClearFilters.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClearFilters.UseAccentColor = true;
            this.btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // panelItemList
            // 
            this.panelItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItemList.Controls.Add(this.bindingNavigatorBatch);
            this.panelItemList.Controls.Add(this.dataGridViewBatch);
            this.panelItemList.Location = new System.Drawing.Point(3, 119);
            this.panelItemList.Name = "panelItemList";
            this.panelItemList.Size = new System.Drawing.Size(1127, 521);
            this.panelItemList.TabIndex = 106;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pBoxShowFilter);
            this.panel3.Controls.Add(this.btnHideFilters);
            this.panel3.Controls.Add(this.materialTextBox21);
            this.panel3.Location = new System.Drawing.Point(20, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel3.Size = new System.Drawing.Size(1150, 60);
            this.panel3.TabIndex = 104;
            // 
            // pBoxShowFilter
            // 
            this.pBoxShowFilter.Image = global::TakoTea.Views.Properties.Resources.filter;
            this.pBoxShowFilter.Location = new System.Drawing.Point(414, 9);
            this.pBoxShowFilter.Name = "pBoxShowFilter";
            this.pBoxShowFilter.Size = new System.Drawing.Size(40, 40);
            this.pBoxShowFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxShowFilter.TabIndex = 96;
            this.pBoxShowFilter.TabStop = false;
            this.pBoxShowFilter.Click += new System.EventHandler(this.pBoxShowFilter_Click);
            // 
            // btnHideFilters
            // 
            this.btnHideFilters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHideFilters.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHideFilters.Depth = 0;
            this.btnHideFilters.Enabled = false;
            this.btnHideFilters.HighEmphasis = true;
            this.btnHideFilters.Icon = null;
            this.btnHideFilters.Location = new System.Drawing.Point(464, 9);
            this.btnHideFilters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHideFilters.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHideFilters.Name = "btnHideFilters";
            this.btnHideFilters.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHideFilters.Size = new System.Drawing.Size(64, 36);
            this.btnHideFilters.TabIndex = 95;
            this.btnHideFilters.Text = "Hide";
            this.btnHideFilters.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHideFilters.UseAccentColor = true;
            this.btnHideFilters.UseVisualStyleBackColor = true;
            this.btnHideFilters.Click += new System.EventHandler(this.btnHideFilters_Click);
            // 
            // materialTextBox21
            // 
            this.materialTextBox21.AnimateReadOnly = false;
            this.materialTextBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox21.Depth = 0;
            this.materialTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox21.HideSelection = true;
            this.materialTextBox21.Hint = " Search for batches";
            this.materialTextBox21.LeadingIcon = null;
            this.materialTextBox21.Location = new System.Drawing.Point(12, 8);
            this.materialTextBox21.MaxLength = 32767;
            this.materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox21.Name = "materialTextBox21";
            this.materialTextBox21.PasswordChar = '\0';
            this.materialTextBox21.PrefixSuffixText = null;
            this.materialTextBox21.ReadOnly = false;
            this.materialTextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox21.SelectedText = "";
            this.materialTextBox21.SelectionLength = 0;
            this.materialTextBox21.SelectionStart = 0;
            this.materialTextBox21.ShortcutsEnabled = true;
            this.materialTextBox21.Size = new System.Drawing.Size(328, 48);
            this.materialTextBox21.TabIndex = 70;
            this.materialTextBox21.TabStop = false;
            this.materialTextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox21.TrailingIcon = null;
            this.materialTextBox21.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.materialLabel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 46);
            this.panel1.TabIndex = 101;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel4.Location = new System.Drawing.Point(535, 10);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(91, 24);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Batch List";
            // 
            // panelExportButtons
            // 
            this.panelExportButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExportButtons.Controls.Add(this.pictureBoxExportExcel);
            this.panelExportButtons.Controls.Add(this.pictureBoxExportPdf);
            this.panelExportButtons.Location = new System.Drawing.Point(1080, 660);
            this.panelExportButtons.Name = "panelExportButtons";
            this.panelExportButtons.Size = new System.Drawing.Size(76, 38);
            this.panelExportButtons.TabIndex = 98;
            // 
            // pictureBoxExportExcel
            // 
            this.pictureBoxExportExcel.Image = global::TakoTea.Views.Properties.Resources.icons8_export_excel_48;
            this.pictureBoxExportExcel.Location = new System.Drawing.Point(3, 5);
            this.pictureBoxExportExcel.Name = "pictureBoxExportExcel";
            this.pictureBoxExportExcel.Size = new System.Drawing.Size(33, 27);
            this.pictureBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExportExcel.TabIndex = 96;
            this.pictureBoxExportExcel.TabStop = false;
            // 
            // pictureBoxExportPdf
            // 
            this.pictureBoxExportPdf.Image = global::TakoTea.Views.Properties.Resources.icons8_export_pdf_48;
            this.pictureBoxExportPdf.Location = new System.Drawing.Point(38, 5);
            this.pictureBoxExportPdf.Name = "pictureBoxExportPdf";
            this.pictureBoxExportPdf.Size = new System.Drawing.Size(33, 27);
            this.pictureBoxExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExportPdf.TabIndex = 97;
            this.pictureBoxExportPdf.TabStop = false;
            this.pictureBoxExportPdf.Click += new System.EventHandler(this.pictureBoxExportPdf_Click);
            // 
            // dataGridViewBatch
            // 
            this.dataGridViewBatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBatch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBatch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBatch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBatch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewBatch.EnableHeadersVisualStyles = false;
            this.dataGridViewBatch.Location = new System.Drawing.Point(0, 32);
            this.dataGridViewBatch.Name = "dataGridViewBatch";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBatch.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBatch.Size = new System.Drawing.Size(1125, 487);
            this.dataGridViewBatch.TabIndex = 11;
            // 
            // bindingNavigatorBatch
            // 
            this.bindingNavigatorBatch.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorBatch.BackColor = System.Drawing.SystemColors.Control;
            this.bindingNavigatorBatch.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorBatch.DeleteItem = null;
            this.bindingNavigatorBatch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigatorBatch.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorBatch.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorBatch.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorBatch.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorBatch.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorBatch.Name = "bindingNavigatorBatch";
            this.bindingNavigatorBatch.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorBatch.Size = new System.Drawing.Size(1125, 25);
            this.bindingNavigatorBatch.TabIndex = 12;
            this.bindingNavigatorBatch.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(60, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // BatchListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1197, 718);
            this.Controls.Add(this.materialCard2);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "BatchListForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "BatchListForm";
            this.Load += new System.EventHandler(this.BatchListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).EndInit();
            this.materialCard2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelFilteringComponents.ResumeLayout(false);
            this.panelFilteringComponents.PerformLayout();
            this.panelItemList.ResumeLayout(false);
            this.panelItemList.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxShowFilter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelExportButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorBatch)).EndInit();
            this.bindingNavigatorBatch.ResumeLayout(false);
            this.bindingNavigatorBatch.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.BindingNavigator miniToolStrip;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private System.Windows.Forms.Panel panelExportButtons;
        private System.Windows.Forms.PictureBox pictureBoxExportExcel;
        private System.Windows.Forms.PictureBox pictureBoxExportPdf;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelFilteringComponents;
        private System.Windows.Forms.Panel panelItemList;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pBoxShowFilter;
        private MaterialSkin.Controls.MaterialButton btnHideFilters;
        private MaterialSkin.Controls.MaterialButton btnClearFilters;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DataGridView dataGridViewBatch;
        private System.Windows.Forms.BindingNavigator bindingNavigatorBatch;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
    }
}