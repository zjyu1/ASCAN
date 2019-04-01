namespace Ascan
{
    partial class FormFocus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.paraGrid = new System.Windows.Forms.DataGridView();
            this.channel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txrx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.config = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activenb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wavepath = new Steema.TeeChart.TChart();
            this.para = new System.Windows.Forms.Panel();
            this.selectedpara = new System.Windows.Forms.Panel();
            this.seletctedPara = new System.Windows.Forms.TextBox();
            this.autoset = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.GroupBox();
            this.displayselected = new System.Windows.Forms.RadioButton();
            this.displayall = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gatesetting = new System.Windows.Forms.Button();
            this.Recommend = new System.Windows.Forms.Button();
            this.chanDelete = new System.Windows.Forms.Button();
            this.chanAdd = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.panelModify = new System.Windows.Forms.Panel();
            this.paraModify = new System.Windows.Forms.Button();
            this.chanmodify = new System.Windows.Forms.Button();
            this.panelchanpara = new System.Windows.Forms.Panel();
            this.btn_addcouple = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paraGrid)).BeginInit();
            this.para.SuspendLayout();
            this.selectedpara.SuspendLayout();
            this.display.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelModify.SuspendLayout();
            this.panelchanpara.SuspendLayout();
            this.SuspendLayout();
            // 
            // paraGrid
            // 
            this.paraGrid.AllowUserToAddRows = false;
            this.paraGrid.AllowUserToDeleteRows = false;
            this.paraGrid.AllowUserToResizeRows = false;
            this.paraGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.paraGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.paraGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.paraGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paraGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.channel,
            this.txrx,
            this.name,
            this.config,
            this.wave,
            this.angle,
            this.element,
            this.activenb,
            this.index,
            this.velocity,
            this.skew,
            this.modify});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.paraGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.paraGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paraGrid.GridColor = System.Drawing.SystemColors.Control;
            this.paraGrid.Location = new System.Drawing.Point(0, 0);
            this.paraGrid.Margin = new System.Windows.Forms.Padding(6);
            this.paraGrid.Name = "paraGrid";
            this.paraGrid.RowHeadersVisible = false;
            this.paraGrid.RowTemplate.Height = 23;
            this.paraGrid.Size = new System.Drawing.Size(907, 274);
            this.paraGrid.TabIndex = 0;
            this.paraGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.paraGrid_CellClick);
            // 
            // channel
            // 
            this.channel.HeaderText = "Channel";
            this.channel.Name = "channel";
            // 
            // txrx
            // 
            this.txrx.HeaderText = "Tx/Rx";
            this.txrx.Name = "txrx";
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.Width = 64;
            // 
            // config
            // 
            this.config.HeaderText = "Config";
            this.config.Name = "config";
            // 
            // wave
            // 
            this.wave.HeaderText = "Wave";
            this.wave.Name = "wave";
            // 
            // angle
            // 
            this.angle.HeaderText = "Angle";
            this.angle.Name = "angle";
            // 
            // element
            // 
            this.element.HeaderText = "Element";
            this.element.Name = "element";
            // 
            // activenb
            // 
            this.activenb.HeaderText = "ActiveNb";
            this.activenb.Name = "activenb";
            // 
            // index
            // 
            this.index.HeaderText = "Index";
            this.index.Name = "index";
            // 
            // velocity
            // 
            this.velocity.HeaderText = "Velocity";
            this.velocity.Name = "velocity";
            // 
            // skew
            // 
            this.skew.HeaderText = "Skew";
            this.skew.Name = "skew";
            // 
            // modify
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.modify.DefaultCellStyle = dataGridViewCellStyle2;
            this.modify.HeaderText = "Modify";
            this.modify.Name = "modify";
            // 
            // wavepath
            // 
            // 
            // 
            // 
            this.wavepath.Aspect.ElevationFloat = 345D;
            this.wavepath.Aspect.RotationFloat = 345D;
            this.wavepath.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.wavepath.Axes.Bottom.AutomaticMaximum = false;
            this.wavepath.Axes.Bottom.AutomaticMinimum = false;
            // 
            // 
            // 
            this.wavepath.Axes.Bottom.Grid.ZPosition = 0D;
            this.wavepath.Axes.Bottom.Maximum = 40D;
            this.wavepath.Axes.Bottom.Minimum = -6D;
            this.wavepath.Axes.Bottom.Visible = false;
            // 
            // 
            // 
            this.wavepath.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.wavepath.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.wavepath.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.wavepath.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.wavepath.Axes.Left.AutomaticMaximum = false;
            this.wavepath.Axes.Left.AutomaticMinimum = false;
            // 
            // 
            // 
            this.wavepath.Axes.Left.Grid.ZPosition = 0D;
            this.wavepath.Axes.Left.Inverted = true;
            this.wavepath.Axes.Left.Maximum = 13D;
            this.wavepath.Axes.Left.Minimum = -1D;
            this.wavepath.Axes.Left.Visible = false;
            // 
            // 
            // 
            this.wavepath.Axes.Right.AutomaticMaximum = false;
            this.wavepath.Axes.Right.AutomaticMinimum = false;
            // 
            // 
            // 
            this.wavepath.Axes.Right.Grid.ZPosition = 0D;
            this.wavepath.Axes.Right.Maximum = 0D;
            this.wavepath.Axes.Right.Minimum = 0D;
            this.wavepath.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.wavepath.Axes.Top.AutomaticMaximum = false;
            this.wavepath.Axes.Top.AutomaticMinimum = false;
            // 
            // 
            // 
            this.wavepath.Axes.Top.Grid.ZPosition = 0D;
            this.wavepath.Axes.Top.Maximum = 40D;
            this.wavepath.Axes.Top.Minimum = -6D;
            this.wavepath.Axes.Top.Visible = false;
            this.wavepath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.wavepath.Cursor = System.Windows.Forms.Cursors.Default;
            this.wavepath.Dock = System.Windows.Forms.DockStyle.Left;
            // 
            // 
            // 
            this.wavepath.Header.Lines = new string[] {
        "TeeChart"};
            this.wavepath.Header.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.wavepath.Legend.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.wavepath.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.wavepath.Legend.Title.Pen.Visible = false;
            this.wavepath.Legend.Visible = false;
            this.wavepath.Location = new System.Drawing.Point(0, 0);
            this.wavepath.Name = "wavepath";
            // 
            // 
            // 
            // 
            // 
            // 
            this.wavepath.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.wavepath.Panel.Brush.ForegroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.wavepath.Panel.Brush.Solid = false;
            this.wavepath.Panel.Brush.Style = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.wavepath.Panel.MarginBottom = 5D;
            this.wavepath.Panel.MarginLeft = 0D;
            this.wavepath.Panel.MarginRight = 0D;
            this.wavepath.Panel.MarginTop = 5D;
            // 
            // 
            // 
            this.wavepath.Panel.Pen.Visible = true;
            this.wavepath.Size = new System.Drawing.Size(779, 190);
            this.wavepath.TabIndex = 1;
            // 
            // 
            // 
            // 
            // 
            // 
            this.wavepath.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.wavepath.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.wavepath.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.wavepath.Walls.Right.AutoHide = false;
            this.wavepath.Walls.Visible = false;
            // 
            // para
            // 
            this.para.Controls.Add(this.selectedpara);
            this.para.Controls.Add(this.wavepath);
            this.para.Location = new System.Drawing.Point(21, 292);
            this.para.Name = "para";
            this.para.Size = new System.Drawing.Size(907, 190);
            this.para.TabIndex = 3;
            // 
            // selectedpara
            // 
            this.selectedpara.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectedpara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedpara.Controls.Add(this.seletctedPara);
            this.selectedpara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedpara.Location = new System.Drawing.Point(779, 0);
            this.selectedpara.Name = "selectedpara";
            this.selectedpara.Size = new System.Drawing.Size(128, 190);
            this.selectedpara.TabIndex = 4;
            // 
            // seletctedPara
            // 
            this.seletctedPara.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.seletctedPara.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seletctedPara.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seletctedPara.Location = new System.Drawing.Point(0, 3);
            this.seletctedPara.Multiline = true;
            this.seletctedPara.Name = "seletctedPara";
            this.seletctedPara.Size = new System.Drawing.Size(126, 182);
            this.seletctedPara.TabIndex = 0;
            // 
            // autoset
            // 
            this.autoset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.autoset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.autoset.Location = new System.Drawing.Point(0, 12);
            this.autoset.Name = "autoset";
            this.autoset.Size = new System.Drawing.Size(86, 23);
            this.autoset.TabIndex = 4;
            this.autoset.Text = "AutoSet";
            this.autoset.UseVisualStyleBackColor = true;
            this.autoset.Click += new System.EventHandler(this.autoset_Click);
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.SystemColors.ControlDark;
            this.display.Controls.Add(this.displayselected);
            this.display.Controls.Add(this.displayall);
            this.display.Location = new System.Drawing.Point(330, 3);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(306, 69);
            this.display.TabIndex = 5;
            this.display.TabStop = false;
            this.display.Text = "Display";
            // 
            // displayselected
            // 
            this.displayselected.AutoSize = true;
            this.displayselected.Location = new System.Drawing.Point(6, 42);
            this.displayselected.Name = "displayselected";
            this.displayselected.Size = new System.Drawing.Size(149, 16);
            this.displayselected.TabIndex = 1;
            this.displayselected.Text = "Display Selected Beam";
            this.displayselected.UseVisualStyleBackColor = true;
            this.displayselected.CheckedChanged += new System.EventHandler(this.displayselected_CheckedChanged);
            // 
            // displayall
            // 
            this.displayall.AutoSize = true;
            this.displayall.Checked = true;
            this.displayall.Location = new System.Drawing.Point(6, 20);
            this.displayall.Name = "displayall";
            this.displayall.Size = new System.Drawing.Size(83, 16);
            this.displayall.TabIndex = 0;
            this.displayall.TabStop = true;
            this.displayall.Text = "DisplayAll";
            this.displayall.UseVisualStyleBackColor = true;
            this.displayall.CheckedChanged += new System.EventHandler(this.autoset_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btn_addcouple);
            this.panel1.Controls.Add(this.gatesetting);
            this.panel1.Controls.Add(this.Recommend);
            this.panel1.Controls.Add(this.chanDelete);
            this.panel1.Controls.Add(this.chanAdd);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.test);
            this.panel1.Controls.Add(this.cancel);
            this.panel1.Controls.Add(this.confirm);
            this.panel1.Controls.Add(this.display);
            this.panel1.Controls.Add(this.autoset);
            this.panel1.Location = new System.Drawing.Point(21, 488);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 76);
            this.panel1.TabIndex = 6;
            // 
            // gatesetting
            // 
            this.gatesetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gatesetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gatesetting.Location = new System.Drawing.Point(229, 12);
            this.gatesetting.Name = "gatesetting";
            this.gatesetting.Size = new System.Drawing.Size(86, 23);
            this.gatesetting.TabIndex = 13;
            this.gatesetting.Text = "GateSetting";
            this.gatesetting.UseVisualStyleBackColor = true;
            this.gatesetting.Click += new System.EventHandler(this.gatesetting_Click);
            // 
            // Recommend
            // 
            this.Recommend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Recommend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Recommend.Location = new System.Drawing.Point(691, 45);
            this.Recommend.Name = "Recommend";
            this.Recommend.Size = new System.Drawing.Size(86, 23);
            this.Recommend.TabIndex = 12;
            this.Recommend.Text = "Recommend";
            this.Recommend.UseVisualStyleBackColor = true;
            this.Recommend.Click += new System.EventHandler(this.Recommend_Click);
            // 
            // chanDelete
            // 
            this.chanDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chanDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chanDelete.Location = new System.Drawing.Point(115, 45);
            this.chanDelete.Name = "chanDelete";
            this.chanDelete.Size = new System.Drawing.Size(86, 23);
            this.chanDelete.TabIndex = 11;
            this.chanDelete.Text = "Delete";
            this.chanDelete.UseVisualStyleBackColor = true;
            this.chanDelete.Click += new System.EventHandler(this.chanDelete_Click);
            // 
            // chanAdd
            // 
            this.chanAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chanAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chanAdd.Location = new System.Drawing.Point(115, 12);
            this.chanAdd.Name = "chanAdd";
            this.chanAdd.Size = new System.Drawing.Size(86, 23);
            this.chanAdd.TabIndex = 10;
            this.chanAdd.Text = "Add";
            this.chanAdd.UseVisualStyleBackColor = true;
            this.chanAdd.Click += new System.EventHandler(this.chanAdd_Click);
            // 
            // save
            // 
            this.save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save.Location = new System.Drawing.Point(0, 45);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(86, 23);
            this.save.TabIndex = 9;
            this.save.Text = "Save to File";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // test
            // 
            this.test.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.test.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.test.Location = new System.Drawing.Point(691, 12);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(86, 23);
            this.test.TabIndex = 8;
            this.test.Text = "test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Visible = false;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // cancel
            // 
            this.cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancel.Location = new System.Drawing.Point(821, 45);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(86, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // confirm
            // 
            this.confirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.confirm.Location = new System.Drawing.Point(821, 12);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(86, 23);
            this.confirm.TabIndex = 6;
            this.confirm.Text = "OK";
            this.confirm.UseVisualStyleBackColor = true;
            // 
            // panelModify
            // 
            this.panelModify.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelModify.Controls.Add(this.paraModify);
            this.panelModify.Controls.Add(this.chanmodify);
            this.panelModify.Location = new System.Drawing.Point(544, 120);
            this.panelModify.Name = "panelModify";
            this.panelModify.Size = new System.Drawing.Size(70, 23);
            this.panelModify.TabIndex = 7;
            this.panelModify.Visible = false;
            // 
            // paraModify
            // 
            this.paraModify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paraModify.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.paraModify.Location = new System.Drawing.Point(0, 0);
            this.paraModify.Name = "paraModify";
            this.paraModify.Size = new System.Drawing.Size(70, 23);
            this.paraModify.TabIndex = 1;
            this.paraModify.Text = "Modify";
            this.paraModify.UseVisualStyleBackColor = true;
            this.paraModify.Click += new System.EventHandler(this.paraModify_Click);
            // 
            // chanmodify
            // 
            this.chanmodify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chanmodify.Location = new System.Drawing.Point(0, 0);
            this.chanmodify.Name = "chanmodify";
            this.chanmodify.Size = new System.Drawing.Size(70, 23);
            this.chanmodify.TabIndex = 0;
            this.chanmodify.Text = "modify";
            this.chanmodify.UseVisualStyleBackColor = true;
            // 
            // panelchanpara
            // 
            this.panelchanpara.Controls.Add(this.panelModify);
            this.panelchanpara.Controls.Add(this.paraGrid);
            this.panelchanpara.Location = new System.Drawing.Point(20, 12);
            this.panelchanpara.Name = "panelchanpara";
            this.panelchanpara.Size = new System.Drawing.Size(907, 274);
            this.panelchanpara.TabIndex = 8;
            // 
            // btn_addcouple
            // 
            this.btn_addcouple.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_addcouple.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_addcouple.Location = new System.Drawing.Point(229, 45);
            this.btn_addcouple.Name = "btn_addcouple";
            this.btn_addcouple.Size = new System.Drawing.Size(86, 23);
            this.btn_addcouple.TabIndex = 14;
            this.btn_addcouple.Text = "Couple";
            this.btn_addcouple.UseVisualStyleBackColor = true;
            this.btn_addcouple.Click += new System.EventHandler(this.btn_addcouple_Click);
            // 
            // FormFocus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(952, 564);
            this.Controls.Add(this.panelchanpara);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.para);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFocus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " FormFocus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFocus_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.paraGrid)).EndInit();
            this.para.ResumeLayout(false);
            this.selectedpara.ResumeLayout(false);
            this.selectedpara.PerformLayout();
            this.display.ResumeLayout(false);
            this.display.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelModify.ResumeLayout(false);
            this.panelchanpara.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView paraGrid;
        private Steema.TeeChart.TChart wavepath;
        private System.Windows.Forms.Panel para;
        private System.Windows.Forms.Panel selectedpara;
        private System.Windows.Forms.Button autoset;
        private System.Windows.Forms.GroupBox display;
        private System.Windows.Forms.RadioButton displayselected;
        private System.Windows.Forms.RadioButton displayall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox seletctedPara;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Panel panelModify;
        private System.Windows.Forms.Button chanmodify;
        private System.Windows.Forms.Panel panelchanpara;
        private System.Windows.Forms.Button paraModify;
        private System.Windows.Forms.Button chanAdd;
        private System.Windows.Forms.Button chanDelete;
        private System.Windows.Forms.Button Recommend;
        private System.Windows.Forms.DataGridViewTextBoxColumn channel;
        private System.Windows.Forms.DataGridViewTextBoxColumn txrx;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn config;
        private System.Windows.Forms.DataGridViewTextBoxColumn wave;
        private System.Windows.Forms.DataGridViewTextBoxColumn angle;
        private System.Windows.Forms.DataGridViewTextBoxColumn element;
        private System.Windows.Forms.DataGridViewTextBoxColumn activenb;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn velocity;
        private System.Windows.Forms.DataGridViewTextBoxColumn skew;
        private System.Windows.Forms.DataGridViewTextBoxColumn modify;
        private System.Windows.Forms.Button gatesetting;
        private System.Windows.Forms.Button btn_addcouple;

    }
}