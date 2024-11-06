namespace TakoTea.View.Batch
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
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.panelItemList = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewStockLevels = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnShowFilter = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.panelExportButtons = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.floatingActionButtonAddBatch = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pictureBoxExportPdf = new System.Windows.Forms.PictureBox();
            this.buttonEditBatch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).BeginInit();
            this.materialCard2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelFilteringComponents.SuspendLayout();
            this.panelItemList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockLevels)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelExportButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportPdf)).BeginInit();
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
            this.materialCard2.Controls.Add(this.floatingActionButtonAddBatch);
            this.materialCard2.Controls.Add(this.flowLayoutPanel1);
            this.materialCard2.Controls.Add(this.panel3);
            this.materialCard2.Controls.Add(this.panel1);
            this.materialCard2.Controls.Add(this.panelExportButtons);
            this.materialCard2.Controls.Add(this.materialLabel2);
            this.materialCard2.Controls.Add(this.materialLabel1);
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
            this.panelFilteringComponents.Controls.Add(this.materialButton1);
            this.panelFilteringComponents.Controls.Add(this.dateTimePicker3);
            this.panelFilteringComponents.Controls.Add(this.dateTimePicker2);
            this.panelFilteringComponents.Controls.Add(this.materialRadioButton1);
            this.panelFilteringComponents.Controls.Add(this.materialRadioButton2);
            this.panelFilteringComponents.Controls.Add(this.materialLabel3);
            this.panelFilteringComponents.Enabled = false;
            this.panelFilteringComponents.Location = new System.Drawing.Point(3, 3);
            this.panelFilteringComponents.Name = "panelFilteringComponents";
            this.panelFilteringComponents.Size = new System.Drawing.Size(1127, 110);
            this.panelFilteringComponents.TabIndex = 107;
            this.panelFilteringComponents.Visible = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(360, 10);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(182, 36);
            this.materialButton1.TabIndex = 98;
            this.materialButton1.Text = "Filter by date range";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(194, 10);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(159, 31);
            this.dateTimePicker3.TabIndex = 97;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(20, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(159, 31);
            this.dateTimePicker2.TabIndex = 96;
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialRadioButton1.Location = new System.Drawing.Point(25, 79);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = false;
            this.materialRadioButton1.Size = new System.Drawing.Size(204, 20);
            this.materialRadioButton1.TabIndex = 95;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "Expiration Date(Farthest)";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialRadioButton2.Location = new System.Drawing.Point(229, 79);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = false;
            this.materialRadioButton2.Size = new System.Drawing.Size(200, 20);
            this.materialRadioButton2.TabIndex = 94;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "Expiration Date(Nearest)";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(22, 54);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(56, 19);
            this.materialLabel3.TabIndex = 93;
            this.materialLabel3.Text = "Sort By:";
            // 
            // panelItemList
            // 
            this.panelItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItemList.Controls.Add(this.bindingNavigator1);
            this.panelItemList.Controls.Add(this.dataGridViewStockLevels);
            this.panelItemList.Location = new System.Drawing.Point(3, 119);
            this.panelItemList.Name = "panelItemList";
            this.panelItemList.Size = new System.Drawing.Size(1127, 521);
            this.panelItemList.TabIndex = 106;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BackColor = System.Drawing.SystemColors.Control;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1125, 25);
            this.bindingNavigator1.TabIndex = 9;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGridViewStockLevels
            // 
            this.dataGridViewStockLevels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStockLevels.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewStockLevels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStockLevels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStockLevels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStockLevels.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStockLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStockLevels.EnableHeadersVisualStyles = false;
            this.dataGridViewStockLevels.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStockLevels.Name = "dataGridViewStockLevels";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStockLevels.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewStockLevels.Size = new System.Drawing.Size(1125, 519);
            this.dataGridViewStockLevels.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonEditBatch);
            this.panel3.Controls.Add(this.btnShowFilter);
            this.panel3.Controls.Add(this.materialButton2);
            this.panel3.Controls.Add(this.materialTextBox21);
            this.panel3.Location = new System.Drawing.Point(20, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel3.Size = new System.Drawing.Size(1150, 60);
            this.panel3.TabIndex = 104;
            // 
            // btnShowFilter
            // 
            this.btnShowFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShowFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnShowFilter.Depth = 0;
            this.btnShowFilter.HighEmphasis = true;
            this.btnShowFilter.Icon = null;
            this.btnShowFilter.Location = new System.Drawing.Point(700, 10);
            this.btnShowFilter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnShowFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShowFilter.Name = "btnShowFilter";
            this.btnShowFilter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnShowFilter.Size = new System.Drawing.Size(77, 36);
            this.btnShowFilter.TabIndex = 93;
            this.btnShowFilter.Text = "Filters";
            this.btnShowFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnShowFilter.UseAccentColor = false;
            this.btnShowFilter.UseVisualStyleBackColor = true;
            this.btnShowFilter.Click += new System.EventHandler(this.btnShowFilter_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(347, 9);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(78, 36);
            this.materialButton2.TabIndex = 93;
            this.materialButton2.Text = "Search";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
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
            this.materialLabel4.Click += new System.EventHandler(this.materialLabel4_Click);
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
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(30, 680);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(189, 19);
            this.materialLabel2.TabIndex = 95;
            this.materialLabel2.Text = "Total Nearing Expiration: 2";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(30, 660);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(116, 19);
            this.materialLabel1.TabIndex = 94;
            this.materialLabel1.Text = "Total Batches: 5";
            // 
            // floatingActionButtonAddBatch
            // 
            this.floatingActionButtonAddBatch.Depth = 0;
            this.floatingActionButtonAddBatch.Icon = global::TakoTea.Properties.Resources.plus;
            this.floatingActionButtonAddBatch.Location = new System.Drawing.Point(1110, 80);
            this.floatingActionButtonAddBatch.Mini = true;
            this.floatingActionButtonAddBatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.floatingActionButtonAddBatch.Name = "floatingActionButtonAddBatch";
            this.floatingActionButtonAddBatch.Size = new System.Drawing.Size(40, 40);
            this.floatingActionButtonAddBatch.TabIndex = 102;
            this.floatingActionButtonAddBatch.UseVisualStyleBackColor = true;
            this.floatingActionButtonAddBatch.Click += new System.EventHandler(this.floatingActionButtonAddBatch_Click_1);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
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
            // pictureBoxExportExcel
            // 
            this.pictureBoxExportExcel.Image = global::TakoTea.Properties.Resources.icons8_export_excel_48;
            this.pictureBoxExportExcel.Location = new System.Drawing.Point(3, 5);
            this.pictureBoxExportExcel.Name = "pictureBoxExportExcel";
            this.pictureBoxExportExcel.Size = new System.Drawing.Size(33, 27);
            this.pictureBoxExportExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExportExcel.TabIndex = 96;
            this.pictureBoxExportExcel.TabStop = false;
            // 
            // pictureBoxExportPdf
            // 
            this.pictureBoxExportPdf.Image = global::TakoTea.Properties.Resources.icons8_export_pdf_48;
            this.pictureBoxExportPdf.Location = new System.Drawing.Point(38, 5);
            this.pictureBoxExportPdf.Name = "pictureBoxExportPdf";
            this.pictureBoxExportPdf.Size = new System.Drawing.Size(33, 27);
            this.pictureBoxExportPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExportPdf.TabIndex = 97;
            this.pictureBoxExportPdf.TabStop = false;
            // 
            // buttonEditBatch
            // 
            this.buttonEditBatch.Location = new System.Drawing.Point(930, 20);
            this.buttonEditBatch.Name = "buttonEditBatch";
            this.buttonEditBatch.Size = new System.Drawing.Size(75, 23);
            this.buttonEditBatch.TabIndex = 94;
            this.buttonEditBatch.Text = "Edit Batch";
            this.buttonEditBatch.UseVisualStyleBackColor = true;
            this.buttonEditBatch.Click += new System.EventHandler(this.buttonEditBatch_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).EndInit();
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelFilteringComponents.ResumeLayout(false);
            this.panelFilteringComponents.PerformLayout();
            this.panelItemList.ResumeLayout(false);
            this.panelItemList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockLevels)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelExportButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportPdf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingNavigator miniToolStrip;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private System.Windows.Forms.Panel panelExportButtons;
        private System.Windows.Forms.PictureBox pictureBoxExportExcel;
        private System.Windows.Forms.PictureBox pictureBoxExportPdf;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialFloatingActionButton floatingActionButtonAddBatch;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelFilteringComponents;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Panel panelItemList;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView dataGridViewStockLevels;
        private MaterialSkin.Controls.MaterialButton btnShowFilter;
        private System.Windows.Forms.Button buttonEditBatch;
    }
}