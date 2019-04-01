namespace AUT
{
    partial class FormStripMap
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
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.labelBatch = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.labelNum = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelConfig = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonclean = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtontest = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLable = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainShowPanel = new System.Windows.Forms.Panel();
            this.mainArea = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonSave = new System.Windows.Forms.Button();
            this.batchDataGridView = new System.Windows.Forms.DataGridView();
            this.weldColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.measureNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.buttonStop = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.autoNamecheckBox = new System.Windows.Forms.CheckBox();
            this.settinglabel = new System.Windows.Forms.Label();
            this.productlabel = new System.Windows.Forms.Label();
            this.batchlabel = new System.Windows.Forms.Label();
            this.settingComboBox = new System.Windows.Forms.ComboBox();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.batchComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mainShowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainArea)).BeginInit();
            this.mainArea.Panel1.SuspendLayout();
            this.mainArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStrip,
            this.groupToolStrip,
            this.helpToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStrip,
            this.saveToolStrip,
            this.saveToSQLToolStripMenuItem});
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(41, 18);
            this.fileToolStrip.Text = "File";
            // 
            // openToolStrip
            // 
            this.openToolStrip.Name = "openToolStrip";
            this.openToolStrip.Size = new System.Drawing.Size(136, 22);
            this.openToolStrip.Text = "Open";
            this.openToolStrip.Click += new System.EventHandler(this.openToolStrip_Click);
            // 
            // saveToolStrip
            // 
            this.saveToolStrip.Name = "saveToolStrip";
            this.saveToolStrip.Size = new System.Drawing.Size(136, 22);
            this.saveToolStrip.Text = "Save";
            this.saveToolStrip.Click += new System.EventHandler(this.saveToolStrip_Click);
            // 
            // saveToSQLToolStripMenuItem
            // 
            this.saveToSQLToolStripMenuItem.Name = "saveToSQLToolStripMenuItem";
            this.saveToSQLToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveToSQLToolStripMenuItem.Text = "Save to SQL";
            this.saveToSQLToolStripMenuItem.Click += new System.EventHandler(this.saveToSQLToolStripMenuItem_Click);
            // 
            // groupToolStrip
            // 
            this.groupToolStrip.Name = "groupToolStrip";
            this.groupToolStrip.Size = new System.Drawing.Size(47, 18);
            this.groupToolStrip.Text = "Group";
            this.groupToolStrip.Click += new System.EventHandler(this.groupToolStrip_Click);
            // 
            // helpToolStrip
            // 
            this.helpToolStrip.Name = "helpToolStrip";
            this.helpToolStrip.Size = new System.Drawing.Size(41, 18);
            this.helpToolStrip.Text = "Help";
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.White;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelBatch,
            this.toolStripComboBox1,
            this.toolStripSeparator1,
            this.labelNum,
            this.toolStripComboBox2,
            this.toolStripSeparator2,
            this.labelConfig,
            this.toolStripComboBox3,
            this.toolStripButtonclean,
            this.toolStripButtontest});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1020, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // labelBatch
            // 
            this.labelBatch.Name = "labelBatch";
            this.labelBatch.Size = new System.Drawing.Size(35, 22);
            this.labelBatch.Text = "Batch";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // labelNum
            // 
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(23, 22);
            this.labelNum.Text = "Num";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // labelConfig
            // 
            this.labelConfig.Name = "labelConfig";
            this.labelConfig.Size = new System.Drawing.Size(41, 22);
            this.labelConfig.Text = "Config";
            // 
            // toolStripComboBox3
            // 
            this.toolStripComboBox3.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripComboBox3.Name = "toolStripComboBox3";
            this.toolStripComboBox3.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButtonclean
            // 
            this.toolStripButtonclean.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonclean.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonclean.Name = "toolStripButtonclean";
            this.toolStripButtonclean.Size = new System.Drawing.Size(57, 22);
            this.toolStripButtonclean.Text = "清除绘图";
            this.toolStripButtonclean.Click += new System.EventHandler(this.toolStripButtonclean_Click);
            // 
            // toolStripButtontest
            // 
            this.toolStripButtontest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtontest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtontest.Name = "toolStripButtontest";
            this.toolStripButtontest.Size = new System.Drawing.Size(57, 22);
            this.toolStripButtontest.Text = "测试模式";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLable});
            this.statusStrip1.Location = new System.Drawing.Point(0, 680);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLable
            // 
            this.statusLable.Name = "statusLable";
            this.statusLable.Size = new System.Drawing.Size(47, 17);
            this.statusLable.Text = "Status:";
            // 
            // mainShowPanel
            // 
            this.mainShowPanel.AutoScroll = true;
            this.mainShowPanel.Controls.Add(this.mainArea);
            this.mainShowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainShowPanel.Location = new System.Drawing.Point(0, 49);
            this.mainShowPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainShowPanel.Name = "mainShowPanel";
            this.mainShowPanel.Size = new System.Drawing.Size(1020, 631);
            this.mainShowPanel.TabIndex = 5;
            // 
            // mainArea
            // 
            this.mainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainArea.Location = new System.Drawing.Point(0, 0);
            this.mainArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainArea.Name = "mainArea";
            // 
            // mainArea.Panel1
            // 
            this.mainArea.Panel1.Controls.Add(this.splitContainer1);
            this.mainArea.Panel1MinSize = 1;
            this.mainArea.Panel2MinSize = 1;
            this.mainArea.Size = new System.Drawing.Size(1020, 631);
            this.mainArea.SplitterDistance = 990;
            this.mainArea.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.buttonSave);
            this.splitContainer1.Panel1.Controls.Add(this.batchDataGridView);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStop);
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStart);
            this.splitContainer1.Panel1.Controls.Add(this.deleteButton);
            this.splitContainer1.Panel1.Controls.Add(this.modifyButton);
            this.splitContainer1.Panel1.Controls.Add(this.insertButton);
            this.splitContainer1.Panel1.Controls.Add(this.autoNamecheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.settinglabel);
            this.splitContainer1.Panel1.Controls.Add(this.productlabel);
            this.splitContainer1.Panel1.Controls.Add(this.batchlabel);
            this.splitContainer1.Panel1.Controls.Add(this.settingComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.productComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.batchComboBox);
            this.splitContainer1.Size = new System.Drawing.Size(990, 631);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(91, 335);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(60, 22);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "保存数据";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // batchDataGridView
            // 
            this.batchDataGridView.AllowUserToAddRows = false;
            this.batchDataGridView.AllowUserToResizeColumns = false;
            this.batchDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.batchDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.batchDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.batchDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.weldColumn,
            this.measureNumColumn,
            this.resultColumn});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.batchDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.batchDataGridView.EnableHeadersVisualStyles = false;
            this.batchDataGridView.Location = new System.Drawing.Point(0, 111);
            this.batchDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.batchDataGridView.Name = "batchDataGridView";
            this.batchDataGridView.RowHeadersVisible = false;
            this.batchDataGridView.RowTemplate.Height = 23;
            this.batchDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.batchDataGridView.Size = new System.Drawing.Size(137, 217);
            this.batchDataGridView.TabIndex = 0;
            this.batchDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.batchDataGridView_CellContentClick);
            // 
            // weldColumn
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.weldColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.weldColumn.HeaderText = "焊缝号";
            this.weldColumn.Name = "weldColumn";
            this.weldColumn.Width = 65;
            // 
            // measureNumColumn
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.measureNumColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.measureNumColumn.HeaderText = "检测次数";
            this.measureNumColumn.Name = "measureNumColumn";
            this.measureNumColumn.Width = 75;
            // 
            // resultColumn
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.resultColumn.HeaderText = "结果";
            this.resultColumn.Items.AddRange(new object[] {
            "好",
            "差"});
            this.resultColumn.Name = "resultColumn";
            this.resultColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.resultColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.resultColumn.Width = 85;
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Location = new System.Drawing.Point(21, 485);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(113, 30);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "停止检测";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(21, 447);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 30);
            this.button5.TabIndex = 11;
            this.button5.Text = "0#道焊缝";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.Location = new System.Drawing.Point(21, 409);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(113, 30);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "开始检测";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteButton.Location = new System.Drawing.Point(103, 360);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(48, 22);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modifyButton.Location = new System.Drawing.Point(51, 360);
            this.modifyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(48, 22);
            this.modifyButton.TabIndex = 8;
            this.modifyButton.Text = "修改";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.insertButton.Location = new System.Drawing.Point(0, 360);
            this.insertButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(48, 22);
            this.insertButton.TabIndex = 7;
            this.insertButton.Text = "插入";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // autoNamecheckBox
            // 
            this.autoNamecheckBox.AutoSize = true;
            this.autoNamecheckBox.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoNamecheckBox.Location = new System.Drawing.Point(6, 336);
            this.autoNamecheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autoNamecheckBox.Name = "autoNamecheckBox";
            this.autoNamecheckBox.Size = new System.Drawing.Size(67, 20);
            this.autoNamecheckBox.TabIndex = 0;
            this.autoNamecheckBox.Text = "自动命名";
            this.autoNamecheckBox.UseVisualStyleBackColor = true;
            this.autoNamecheckBox.CheckedChanged += new System.EventHandler(this.autoNamecheckBox_CheckedChanged);
            // 
            // settinglabel
            // 
            this.settinglabel.AutoSize = true;
            this.settinglabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settinglabel.Location = new System.Drawing.Point(3, 78);
            this.settinglabel.Name = "settinglabel";
            this.settinglabel.Size = new System.Drawing.Size(56, 17);
            this.settinglabel.TabIndex = 5;
            this.settinglabel.Text = "检测配置";
            // 
            // productlabel
            // 
            this.productlabel.AutoSize = true;
            this.productlabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productlabel.Location = new System.Drawing.Point(7, 47);
            this.productlabel.Name = "productlabel";
            this.productlabel.Size = new System.Drawing.Size(32, 17);
            this.productlabel.TabIndex = 4;
            this.productlabel.Text = "产品";
            // 
            // batchlabel
            // 
            this.batchlabel.AutoSize = true;
            this.batchlabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.batchlabel.Location = new System.Drawing.Point(7, 14);
            this.batchlabel.Name = "batchlabel";
            this.batchlabel.Size = new System.Drawing.Size(32, 17);
            this.batchlabel.TabIndex = 3;
            this.batchlabel.Text = "批次";
            // 
            // settingComboBox
            // 
            this.settingComboBox.FormattingEnabled = true;
            this.settingComboBox.Location = new System.Drawing.Point(60, 76);
            this.settingComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.settingComboBox.Name = "settingComboBox";
            this.settingComboBox.Size = new System.Drawing.Size(83, 24);
            this.settingComboBox.TabIndex = 2;
            this.settingComboBox.SelectedIndexChanged += new System.EventHandler(this.settingComboBox_SelectedIndexChanged);
            // 
            // productComboBox
            // 
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(60, 42);
            this.productComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(83, 24);
            this.productComboBox.TabIndex = 1;
            this.productComboBox.SelectedIndexChanged += new System.EventHandler(this.productComboBox_SelectedIndexChanged);
            // 
            // batchComboBox
            // 
            this.batchComboBox.FormattingEnabled = true;
            this.batchComboBox.Location = new System.Drawing.Point(60, 9);
            this.batchComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.batchComboBox.Name = "batchComboBox";
            this.batchComboBox.Size = new System.Drawing.Size(83, 24);
            this.batchComboBox.TabIndex = 0;
            this.batchComboBox.DropDown += new System.EventHandler(this.batchComboBox_DropDown);
            this.batchComboBox.SelectedIndexChanged += new System.EventHandler(this.batchComboBox_SelectedIndexChanged);
            // 
            // FormStripMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 702);
            this.Controls.Add(this.mainShowPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormStripMap";
            this.Text = "FormStripMap";
            this.Load += new System.EventHandler(this.FormStripMap_Load);
            this.VisibleChanged += new System.EventHandler(this.FormStripMap_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainShowPanel.ResumeLayout(false);
            this.mainArea.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainArea)).EndInit();
            this.mainArea.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.batchDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStrip;
        private System.Windows.Forms.ToolStripMenuItem groupToolStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLable;
        private System.Windows.Forms.Panel mainShowPanel;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.SplitContainer mainArea;
        private System.Windows.Forms.ToolStripButton toolStripButtonclean;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox settingComboBox;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.ComboBox batchComboBox;
        private System.Windows.Forms.Label settinglabel;
        private System.Windows.Forms.Label productlabel;
        private System.Windows.Forms.Label batchlabel;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.CheckBox autoNamecheckBox;
        private System.Windows.Forms.DataGridView batchDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn weldColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn measureNumColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn resultColumn;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolStripMenuItem saveToSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtontest;
        private System.Windows.Forms.ToolStripLabel labelBatch;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel labelNum;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelConfig;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox3;
    }
}