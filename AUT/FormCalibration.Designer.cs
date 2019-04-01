namespace AUT
{
    partial class FormCalibration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.calibInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.session = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.axialStartPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.axialEndPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.circleStartPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.circleEndPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startCalibrateButton = new System.Windows.Forms.Button();
            this.reCalibrateButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.dircLabel = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.areaComboBox = new System.Windows.Forms.ComboBox();
            this.dircComboBox = new System.Windows.Forms.ComboBox();
            this.sessionDataGridView = new System.Windows.Forms.DataGridView();
            this.sessionAttr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupState = new System.Windows.Forms.GroupBox();
            this.textBoxRealDirec = new System.Windows.Forms.TextBox();
            this.labelRealDirection = new System.Windows.Forms.Label();
            this.textBoxRealSpeed = new System.Windows.Forms.TextBox();
            this.textBoxRealPos = new System.Windows.Forms.TextBox();
            this.labelRealSpeed = new System.Windows.Forms.Label();
            this.labelRealPos = new System.Windows.Forms.Label();
            this.groupSetting = new System.Windows.Forms.GroupBox();
            this.radioNegDir = new System.Windows.Forms.RadioButton();
            this.radioPosDir = new System.Windows.Forms.RadioButton();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.textBoxRange = new System.Windows.Forms.TextBox();
            this.labelDirection = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelRange = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stopButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibInfoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupState.SuspendLayout();
            this.groupSetting.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(41, 20);
            this.fileToolStrip.Text = "file";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.openToolStripMenuItem.Text = "open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.saveToolStripMenuItem.Text = "save";
            // 
            // groupToolStrip
            // 
            this.groupToolStrip.Name = "groupToolStrip";
            this.groupToolStrip.Size = new System.Drawing.Size(47, 20);
            this.groupToolStrip.Text = "group";
            // 
            // helpToolStrip
            // 
            this.helpToolStrip.Name = "helpToolStrip";
            this.helpToolStrip.Size = new System.Drawing.Size(41, 20);
            this.helpToolStrip.Text = "help";
            // 
            // calibInfoDataGridView
            // 
            this.calibInfoDataGridView.AllowUserToAddRows = false;
            this.calibInfoDataGridView.AllowUserToResizeColumns = false;
            this.calibInfoDataGridView.AllowUserToResizeRows = false;
            this.calibInfoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.calibInfoDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.calibInfoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.calibInfoDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.calibInfoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.calibInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calibInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.session,
            this.area,
            this.type,
            this.axialStartPos,
            this.axialEndPos,
            this.circleStartPos,
            this.circleEndPos});
            this.calibInfoDataGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.calibInfoDataGridView.Location = new System.Drawing.Point(14, 8);
            this.calibInfoDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.calibInfoDataGridView.Name = "calibInfoDataGridView";
            this.calibInfoDataGridView.RowHeadersVisible = false;
            this.calibInfoDataGridView.RowTemplate.Height = 27;
            this.calibInfoDataGridView.Size = new System.Drawing.Size(775, 159);
            this.calibInfoDataGridView.TabIndex = 0;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle2;
            this.name.FillWeight = 406.0913F;
            this.name.Frozen = true;
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.Width = 60;
            // 
            // session
            // 
            this.session.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.session.DefaultCellStyle = dataGridViewCellStyle3;
            this.session.FillWeight = 56.27267F;
            this.session.Frozen = true;
            this.session.HeaderText = "通道";
            this.session.Name = "session";
            this.session.Width = 60;
            // 
            // area
            // 
            this.area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.area.DefaultCellStyle = dataGridViewCellStyle4;
            this.area.FillWeight = 56.27267F;
            this.area.Frozen = true;
            this.area.HeaderText = "区域";
            this.area.Name = "area";
            this.area.Width = 80;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.type.DefaultCellStyle = dataGridViewCellStyle5;
            this.type.FillWeight = 56.27267F;
            this.type.Frozen = true;
            this.type.HeaderText = "伤类型";
            this.type.Name = "type";
            this.type.Width = 80;
            // 
            // axialStartPos
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.axialStartPos.DefaultCellStyle = dataGridViewCellStyle6;
            this.axialStartPos.FillWeight = 56.27267F;
            this.axialStartPos.HeaderText = "轴向起点(mm)";
            this.axialStartPos.Name = "axialStartPos";
            // 
            // axialEndPos
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.axialEndPos.DefaultCellStyle = dataGridViewCellStyle7;
            this.axialEndPos.FillWeight = 56.27267F;
            this.axialEndPos.HeaderText = "轴向终点(mm)";
            this.axialEndPos.Name = "axialEndPos";
            // 
            // circleStartPos
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.circleStartPos.DefaultCellStyle = dataGridViewCellStyle8;
            this.circleStartPos.FillWeight = 56.27267F;
            this.circleStartPos.HeaderText = "周向起点(mm)";
            this.circleStartPos.Name = "circleStartPos";
            // 
            // circleEndPos
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.circleEndPos.DefaultCellStyle = dataGridViewCellStyle9;
            this.circleEndPos.FillWeight = 56.27267F;
            this.circleEndPos.HeaderText = "周向终点(mm)";
            this.circleEndPos.Name = "circleEndPos";
            // 
            // startCalibrateButton
            // 
            this.startCalibrateButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startCalibrateButton.Location = new System.Drawing.Point(16, 410);
            this.startCalibrateButton.Margin = new System.Windows.Forms.Padding(2);
            this.startCalibrateButton.Name = "startCalibrateButton";
            this.startCalibrateButton.Size = new System.Drawing.Size(104, 33);
            this.startCalibrateButton.TabIndex = 0;
            this.startCalibrateButton.Text = "开始校准";
            this.startCalibrateButton.UseVisualStyleBackColor = true;
            this.startCalibrateButton.Click += new System.EventHandler(this.startCalibrateButton_Click);
            // 
            // reCalibrateButton
            // 
            this.reCalibrateButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reCalibrateButton.Location = new System.Drawing.Point(16, 457);
            this.reCalibrateButton.Margin = new System.Windows.Forms.Padding(2);
            this.reCalibrateButton.Name = "reCalibrateButton";
            this.reCalibrateButton.Size = new System.Drawing.Size(104, 33);
            this.reCalibrateButton.TabIndex = 1;
            this.reCalibrateButton.Text = "复核校验";
            this.reCalibrateButton.UseVisualStyleBackColor = true;
            this.reCalibrateButton.Click += new System.EventHandler(this.reCalibrateButton_Click);
            // 
            // resultButton
            // 
            this.resultButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultButton.Location = new System.Drawing.Point(16, 505);
            this.resultButton.Margin = new System.Windows.Forms.Padding(2);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(104, 33);
            this.resultButton.TabIndex = 2;
            this.resultButton.Text = "校验结果";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeLabel.Location = new System.Drawing.Point(7, 11);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(32, 17);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "类型";
            // 
            // dircLabel
            // 
            this.dircLabel.AutoSize = true;
            this.dircLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dircLabel.Location = new System.Drawing.Point(7, 69);
            this.dircLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dircLabel.Name = "dircLabel";
            this.dircLabel.Size = new System.Drawing.Size(32, 17);
            this.dircLabel.TabIndex = 4;
            this.dircLabel.Text = "方向";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.areaLabel.Location = new System.Drawing.Point(7, 40);
            this.areaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(32, 17);
            this.areaLabel.TabIndex = 2;
            this.areaLabel.Text = "区域";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "FILL",
            "HP",
            "LCP",
            "ROOT",
            "ALL"});
            this.typeComboBox.Location = new System.Drawing.Point(39, 11);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(80, 20);
            this.typeComboBox.TabIndex = 1;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            // 
            // areaComboBox
            // 
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.Location = new System.Drawing.Point(39, 40);
            this.areaComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(80, 20);
            this.areaComboBox.TabIndex = 3;
            this.areaComboBox.SelectedIndexChanged += new System.EventHandler(this.areaComboBox_SelectedIndexChanged);
            // 
            // dircComboBox
            // 
            this.dircComboBox.FormattingEnabled = true;
            this.dircComboBox.Items.AddRange(new object[] {
            "L",
            "R",
            "ALL"});
            this.dircComboBox.Location = new System.Drawing.Point(39, 69);
            this.dircComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.dircComboBox.Name = "dircComboBox";
            this.dircComboBox.Size = new System.Drawing.Size(80, 20);
            this.dircComboBox.TabIndex = 5;
            this.dircComboBox.SelectedIndexChanged += new System.EventHandler(this.dircComboBox_SelectedIndexChanged);
            // 
            // sessionDataGridView
            // 
            this.sessionDataGridView.AllowUserToAddRows = false;
            this.sessionDataGridView.AllowUserToResizeColumns = false;
            this.sessionDataGridView.AllowUserToResizeRows = false;
            this.sessionDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sessionDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.sessionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sessionAttr});
            this.sessionDataGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.sessionDataGridView.Location = new System.Drawing.Point(39, 103);
            this.sessionDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.sessionDataGridView.Name = "sessionDataGridView";
            this.sessionDataGridView.RowHeadersVisible = false;
            this.sessionDataGridView.RowTemplate.Height = 27;
            this.sessionDataGridView.Size = new System.Drawing.Size(80, 282);
            this.sessionDataGridView.TabIndex = 6;
            // 
            // sessionAttr
            // 
            this.sessionAttr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sessionAttr.DefaultCellStyle = dataGridViewCellStyle11;
            this.sessionAttr.HeaderText = "通道";
            this.sessionAttr.Name = "sessionAttr";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 704);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.calibInfoDataGridView);
            this.panel4.Controls.Add(this.groupState);
            this.panel4.Controls.Add(this.groupSetting);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(132, 447);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1132, 257);
            this.panel4.TabIndex = 9;
            // 
            // groupState
            // 
            this.groupState.Controls.Add(this.textBoxRealDirec);
            this.groupState.Controls.Add(this.labelRealDirection);
            this.groupState.Controls.Add(this.textBoxRealSpeed);
            this.groupState.Controls.Add(this.textBoxRealPos);
            this.groupState.Controls.Add(this.labelRealSpeed);
            this.groupState.Controls.Add(this.labelRealPos);
            this.groupState.Location = new System.Drawing.Point(987, 10);
            this.groupState.Name = "groupState";
            this.groupState.Size = new System.Drawing.Size(143, 127);
            this.groupState.TabIndex = 2;
            this.groupState.TabStop = false;
            this.groupState.Text = "状态";
            // 
            // textBoxRealDirec
            // 
            this.textBoxRealDirec.Location = new System.Drawing.Point(41, 94);
            this.textBoxRealDirec.Name = "textBoxRealDirec";
            this.textBoxRealDirec.ReadOnly = true;
            this.textBoxRealDirec.Size = new System.Drawing.Size(89, 21);
            this.textBoxRealDirec.TabIndex = 6;
            this.textBoxRealDirec.Text = "正";
            // 
            // labelRealDirection
            // 
            this.labelRealDirection.AutoSize = true;
            this.labelRealDirection.Location = new System.Drawing.Point(10, 98);
            this.labelRealDirection.Name = "labelRealDirection";
            this.labelRealDirection.Size = new System.Drawing.Size(29, 12);
            this.labelRealDirection.TabIndex = 5;
            this.labelRealDirection.Text = "方向";
            // 
            // textBoxRealSpeed
            // 
            this.textBoxRealSpeed.Location = new System.Drawing.Point(76, 55);
            this.textBoxRealSpeed.Name = "textBoxRealSpeed";
            this.textBoxRealSpeed.ReadOnly = true;
            this.textBoxRealSpeed.Size = new System.Drawing.Size(54, 21);
            this.textBoxRealSpeed.TabIndex = 4;
            this.textBoxRealSpeed.Text = "0.0";
            // 
            // textBoxRealPos
            // 
            this.textBoxRealPos.Location = new System.Drawing.Point(75, 14);
            this.textBoxRealPos.Name = "textBoxRealPos";
            this.textBoxRealPos.ReadOnly = true;
            this.textBoxRealPos.Size = new System.Drawing.Size(54, 21);
            this.textBoxRealPos.TabIndex = 3;
            this.textBoxRealPos.Text = "0.0";
            // 
            // labelRealSpeed
            // 
            this.labelRealSpeed.AutoSize = true;
            this.labelRealSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRealSpeed.Location = new System.Drawing.Point(7, 55);
            this.labelRealSpeed.Name = "labelRealSpeed";
            this.labelRealSpeed.Size = new System.Drawing.Size(73, 17);
            this.labelRealSpeed.TabIndex = 1;
            this.labelRealSpeed.Text = "速度(mm/s)";
            // 
            // labelRealPos
            // 
            this.labelRealPos.AutoSize = true;
            this.labelRealPos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRealPos.Location = new System.Drawing.Point(7, 14);
            this.labelRealPos.Name = "labelRealPos";
            this.labelRealPos.Size = new System.Drawing.Size(62, 17);
            this.labelRealPos.TabIndex = 0;
            this.labelRealPos.Text = "位置(mm)";
            // 
            // groupSetting
            // 
            this.groupSetting.Controls.Add(this.radioNegDir);
            this.groupSetting.Controls.Add(this.radioPosDir);
            this.groupSetting.Controls.Add(this.textBoxSpeed);
            this.groupSetting.Controls.Add(this.textBoxRange);
            this.groupSetting.Controls.Add(this.labelDirection);
            this.groupSetting.Controls.Add(this.labelSpeed);
            this.groupSetting.Controls.Add(this.labelRange);
            this.groupSetting.Location = new System.Drawing.Point(810, 10);
            this.groupSetting.Name = "groupSetting";
            this.groupSetting.Size = new System.Drawing.Size(142, 127);
            this.groupSetting.TabIndex = 1;
            this.groupSetting.TabStop = false;
            this.groupSetting.Text = "设定";
            // 
            // radioNegDir
            // 
            this.radioNegDir.AutoSize = true;
            this.radioNegDir.Location = new System.Drawing.Point(97, 96);
            this.radioNegDir.Name = "radioNegDir";
            this.radioNegDir.Size = new System.Drawing.Size(35, 16);
            this.radioNegDir.TabIndex = 6;
            this.radioNegDir.TabStop = true;
            this.radioNegDir.Text = "反";
            this.radioNegDir.UseVisualStyleBackColor = true;
            this.radioNegDir.Click += new System.EventHandler(this.radioNegDir_Click);
            // 
            // radioPosDir
            // 
            this.radioPosDir.AutoSize = true;
            this.radioPosDir.Checked = true;
            this.radioPosDir.Location = new System.Drawing.Point(45, 96);
            this.radioPosDir.Name = "radioPosDir";
            this.radioPosDir.Size = new System.Drawing.Size(35, 16);
            this.radioPosDir.TabIndex = 5;
            this.radioPosDir.TabStop = true;
            this.radioPosDir.Text = "正";
            this.radioPosDir.UseVisualStyleBackColor = true;
            this.radioPosDir.Click += new System.EventHandler(this.radioPosDir_Click);
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(72, 51);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(64, 21);
            this.textBoxSpeed.TabIndex = 4;
            this.textBoxSpeed.Text = "0.0";
            this.textBoxSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSpeed_KeyPress);
            this.textBoxSpeed.Leave += new System.EventHandler(this.textBoxSpeed_Leave);
            // 
            // textBoxRange
            // 
            this.textBoxRange.Location = new System.Drawing.Point(72, 13);
            this.textBoxRange.Name = "textBoxRange";
            this.textBoxRange.Size = new System.Drawing.Size(64, 21);
            this.textBoxRange.TabIndex = 3;
            this.textBoxRange.Text = "0.0";
            this.textBoxRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRange_KeyPress);
            this.textBoxRange.Leave += new System.EventHandler(this.textBoxRange_Leave);
            // 
            // labelDirection
            // 
            this.labelDirection.AutoSize = true;
            this.labelDirection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDirection.Location = new System.Drawing.Point(6, 94);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(32, 17);
            this.labelDirection.TabIndex = 2;
            this.labelDirection.Text = "方向";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSpeed.Location = new System.Drawing.Point(6, 55);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(73, 17);
            this.labelSpeed.TabIndex = 1;
            this.labelSpeed.Text = "速度(mm/s)";
            // 
            // labelRange
            // 
            this.labelRange.AutoSize = true;
            this.labelRange.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRange.Location = new System.Drawing.Point(6, 16);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(62, 17);
            this.labelRange.TabIndex = 0;
            this.labelRange.Text = "范围(mm)";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(132, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1132, 447);
            this.panel3.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.vScrollBar);
            this.splitContainer1.Size = new System.Drawing.Size(1130, 445);
            this.splitContainer1.SplitterDistance = 1101;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(2, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(24, 443);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dircComboBox);
            this.panel2.Controls.Add(this.sessionDataGridView);
            this.panel2.Controls.Add(this.areaComboBox);
            this.panel2.Controls.Add(this.areaLabel);
            this.panel2.Controls.Add(this.typeComboBox);
            this.panel2.Controls.Add(this.dircLabel);
            this.panel2.Controls.Add(this.stopButton);
            this.panel2.Controls.Add(this.resultButton);
            this.panel2.Controls.Add(this.typeLabel);
            this.panel2.Controls.Add(this.startCalibrateButton);
            this.panel2.Controls.Add(this.reCalibrateButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(132, 704);
            this.panel2.TabIndex = 7;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopButton.Location = new System.Drawing.Point(16, 551);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(104, 33);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // FormCalibration
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 704);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalibration";
            this.Text = "FormCalibration";
            this.Load += new System.EventHandler(this.FormCalibration_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibInfoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupState.ResumeLayout(false);
            this.groupState.PerformLayout();
            this.groupSetting.ResumeLayout(false);
            this.groupSetting.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStrip;
        private System.Windows.Forms.DataGridView calibInfoDataGridView;
        private System.Windows.Forms.Button startCalibrateButton;
        private System.Windows.Forms.Button reCalibrateButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label dircLabel;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.ComboBox areaComboBox;
        private System.Windows.Forms.ComboBox dircComboBox;
        private System.Windows.Forms.DataGridView sessionDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessionAttr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.GroupBox groupState;
        private System.Windows.Forms.GroupBox groupSetting;
        private System.Windows.Forms.TextBox textBoxRange;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Label labelRealSpeed;
        private System.Windows.Forms.Label labelRealPos;
        private System.Windows.Forms.TextBox textBoxRealSpeed;
        private System.Windows.Forms.TextBox textBoxRealPos;
        private System.Windows.Forms.TextBox textBoxRealDirec;
        private System.Windows.Forms.Label labelRealDirection;
        private System.Windows.Forms.RadioButton radioNegDir;
        private System.Windows.Forms.RadioButton radioPosDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn session;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn axialStartPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn axialEndPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn circleStartPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn circleEndPos;
    }
}