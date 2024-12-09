namespace TakoTea.View.Batches
{
    partial class BatchListLogsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchListLogsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.miniToolStrip = new System.Windows.Forms.BindingNavigator(this.components);
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelFilteringComponents = new System.Windows.Forms.Panel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.checkedListBoxAction = new System.Windows.Forms.CheckedListBox();
            this.chkListBoxColumnName = new System.Windows.Forms.CheckedListBox();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.materialLabel21 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.panelItemList = new System.Windows.Forms.Panel();
            this.bindingNavigatorBatch = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewBatchLogs = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pBoxShowFilter = new System.Windows.Forms.PictureBox();
            this.btnHideFilters = new MaterialSkin.Controls.MaterialButton();
            this.txtBoxSearchLogs = new MaterialSkin.Controls.MaterialTextBox2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.panelExportButtons = new System.Windows.Forms.Panel();
            this.pictureBoxExportExcel = new System.Windows.Forms.PictureBox();
            this.pictureBoxExportPdf = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).BeginInit();
            this.materialCard2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelFilteringComponents.SuspendLayout();
            this.panelItemList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorBatch)).BeginInit();
            this.bindingNavigatorBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchLogs)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxShowFilter)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelExportButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.panelFilteringComponents.Controls.Add(this.materialLabel1);
            this.panelFilteringComponents.Controls.Add(this.checkedListBoxAction);
            this.panelFilteringComponents.Controls.Add(this.chkListBoxColumnName);
            this.panelFilteringComponents.Controls.Add(this.dateTimePickerEnd);
            this.panelFilteringComponents.Controls.Add(this.materialLabel21);
            this.panelFilteringComponents.Controls.Add(this.dateTimePickerStart);
            this.panelFilteringComponents.Enabled = false;
            this.panelFilteringComponents.Location = new System.Drawing.Point(3, 3);
            this.panelFilteringComponents.Name = "panelFilteringComponents";
            this.panelFilteringComponents.Size = new System.Drawing.Size(1127, 165);
            this.panelFilteringComponents.TabIndex = 107;
            this.panelFilteringComponents.Visible = false;
            this.panelFilteringComponents.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFilteringComponents_Paint);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(6, 8);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(38, 19);
            this.materialLabel3.TabIndex = 150;
            this.materialLabel3.Text = "Date:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(550, 8);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(50, 19);
            this.materialLabel1.TabIndex = 149;
            this.materialLabel1.Text = "Action:";
            // 
            // checkedListBoxAction
            // 
            this.checkedListBoxAction.CheckOnClick = true;
            this.checkedListBoxAction.FormattingEnabled = true;
            this.checkedListBoxAction.Location = new System.Drawing.Point(550, 40);
            this.checkedListBoxAction.Name = "checkedListBoxAction";
            this.checkedListBoxAction.Size = new System.Drawing.Size(136, 109);
            this.checkedListBoxAction.TabIndex = 148;
            this.checkedListBoxAction.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAction_SelectedIndexChanged);
            // 
            // chkListBoxColumnName
            // 
            this.chkListBoxColumnName.CheckOnClick = true;
            this.chkListBoxColumnName.FormattingEnabled = true;
            this.chkListBoxColumnName.Location = new System.Drawing.Point(358, 40);
            this.chkListBoxColumnName.Name = "chkListBoxColumnName";
            this.chkListBoxColumnName.Size = new System.Drawing.Size(176, 109);
            this.chkListBoxColumnName.TabIndex = 147;
            this.chkListBoxColumnName.SelectedIndexChanged += new System.EventHandler(this.chkListBoxColumnName_SelectedIndexChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarFont = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(182, 40);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(159, 32);
            this.dateTimePickerEnd.TabIndex = 145;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // materialLabel21
            // 
            this.materialLabel21.AutoSize = true;
            this.materialLabel21.Depth = 0;
            this.materialLabel21.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel21.Location = new System.Drawing.Point(360, 8);
            this.materialLabel21.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel21.Name = "materialLabel21";
            this.materialLabel21.Size = new System.Drawing.Size(129, 19);
            this.materialLabel21.TabIndex = 146;
            this.materialLabel21.Text = "Filter By Category:";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarFont = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.dateTimePickerStart.Font = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(8, 40);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(159, 32);
            this.dateTimePickerStart.TabIndex = 144;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // panelItemList
            // 
            this.panelItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelItemList.Controls.Add(this.bindingNavigatorBatch);
            this.panelItemList.Controls.Add(this.dataGridViewBatchLogs);
            this.panelItemList.Location = new System.Drawing.Point(3, 174);
            this.panelItemList.Name = "panelItemList";
            this.panelItemList.Size = new System.Drawing.Size(1127, 521);
            this.panelItemList.TabIndex = 106;
            // 
            // bindingNavigatorBatch
            // 
            this.bindingNavigatorBatch.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorBatch.BackColor = System.Drawing.SystemColors.Control;
            this.bindingNavigatorBatch.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorBatch.DeleteItem = this.bindingNavigatorDeleteItem;
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
            this.bindingNavigatorBatch.TabIndex = 9;
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
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
            // dataGridViewBatchLogs
            // 
            this.dataGridViewBatchLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBatchLogs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBatchLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBatchLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBatchLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBatchLogs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBatchLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewBatchLogs.EnableHeadersVisualStyles = false;
            this.dataGridViewBatchLogs.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewBatchLogs.Name = "dataGridViewBatchLogs";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBatchLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBatchLogs.Size = new System.Drawing.Size(1125, 489);
            this.dataGridViewBatchLogs.TabIndex = 5;
            this.dataGridViewBatchLogs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBatch_CellDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pbSearch);
            this.panel3.Controls.Add(this.pBoxShowFilter);
            this.panel3.Controls.Add(this.btnHideFilters);
            this.panel3.Controls.Add(this.txtBoxSearchLogs);
            this.panel3.Location = new System.Drawing.Point(20, 70);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel3.Size = new System.Drawing.Size(1150, 60);
            this.panel3.TabIndex = 104;
            // 
            // pbSearch
            // 
            this.pbSearch.Image = global::TakoTea.Views.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(352, 8);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(40, 40);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 97;
            this.pbSearch.TabStop = false;
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
            // txtBoxSearchLogs
            // 
            this.txtBoxSearchLogs.AnimateReadOnly = false;
            this.txtBoxSearchLogs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBoxSearchLogs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBoxSearchLogs.Depth = 0;
            this.txtBoxSearchLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBoxSearchLogs.HideSelection = true;
            this.txtBoxSearchLogs.Hint = " Search for batch logs";
            this.txtBoxSearchLogs.LeadingIcon = null;
            this.txtBoxSearchLogs.Location = new System.Drawing.Point(12, 8);
            this.txtBoxSearchLogs.MaxLength = 32767;
            this.txtBoxSearchLogs.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBoxSearchLogs.Name = "txtBoxSearchLogs";
            this.txtBoxSearchLogs.PasswordChar = '\0';
            this.txtBoxSearchLogs.PrefixSuffixText = null;
            this.txtBoxSearchLogs.ReadOnly = false;
            this.txtBoxSearchLogs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxSearchLogs.SelectedText = "";
            this.txtBoxSearchLogs.SelectionLength = 0;
            this.txtBoxSearchLogs.SelectionStart = 0;
            this.txtBoxSearchLogs.ShortcutsEnabled = true;
            this.txtBoxSearchLogs.Size = new System.Drawing.Size(328, 48);
            this.txtBoxSearchLogs.TabIndex = 70;
            this.txtBoxSearchLogs.TabStop = false;
            this.txtBoxSearchLogs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBoxSearchLogs.TrailingIcon = null;
            this.txtBoxSearchLogs.UseSystemPasswordChar = false;
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
            this.materialLabel4.Location = new System.Drawing.Point(492, 10);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(174, 24);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Batch Changes Log";
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
            // BatchListLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1197, 718);
            this.Controls.Add(this.materialCard2);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "BatchListLogsForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorBatch)).EndInit();
            this.bindingNavigatorBatch.ResumeLayout(false);
            this.bindingNavigatorBatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchLogs)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxShowFilter)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelExportButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExportPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        private MaterialSkin.Controls.MaterialTextBox2 txtBoxSearchLogs;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelFilteringComponents;
        private System.Windows.Forms.Panel panelItemList;
        private System.Windows.Forms.BindingNavigator bindingNavigatorBatch;
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
        private System.Windows.Forms.DataGridView dataGridViewBatchLogs;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.PictureBox pBoxShowFilter;
        private MaterialSkin.Controls.MaterialButton btnHideFilters;
        private System.Windows.Forms.PictureBox pbSearch;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.CheckedListBox checkedListBoxAction;
        private System.Windows.Forms.CheckedListBox chkListBoxColumnName;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private MaterialSkin.Controls.MaterialLabel materialLabel21;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
    }
}