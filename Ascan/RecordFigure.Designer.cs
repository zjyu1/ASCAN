namespace Ascan
{
    partial class FormRecordFigure_AScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecordFigure_AScan));
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_I_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_I_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_A_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_A_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_B_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_B_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_C_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_C_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.baToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_BA_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_BA_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.aiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_AI_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_AI_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.biToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_BI_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_BI_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.ciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_CI_tof = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_CI_amp = new System.Windows.Forms.ToolStripMenuItem();
            this.lineRecord = new Steema.TeeChart.Styles.FastLine();
            this.tChartAscan = new Steema.TeeChart.TChart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picBoxColorBar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tChartBscan = new Steema.TeeChart.TChart();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.smoothing1 = new Steema.TeeChart.Functions.Smoothing();
            this.chartImage = new Steema.TeeChart.Tools.ChartImage();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxColorBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iToolStripMenuItem,
            this.aToolStripMenuItem,
            this.bToolStripMenuItem,
            this.cToolStripMenuItem,
            this.baToolStripMenuItem,
            this.aiToolStripMenuItem,
            this.biToolStripMenuItem,
            this.ciToolStripMenuItem});
            this.ContextMenuStrip.Name = "contextMenuStrip1";
            this.ContextMenuStrip.Size = new System.Drawing.Size(93, 180);
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_I_tof,
            this.cmsItem_I_amp});
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.iToolStripMenuItem.Text = "I";
            // 
            // cmsItem_I_tof
            // 
            this.cmsItem_I_tof.Name = "cmsItem_I_tof";
            this.cmsItem_I_tof.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_I_tof.Text = "Tof";
            this.cmsItem_I_tof.Click += new System.EventHandler(this.cmsItem_I_tof_Click);
            // 
            // cmsItem_I_amp
            // 
            this.cmsItem_I_amp.Name = "cmsItem_I_amp";
            this.cmsItem_I_amp.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_I_amp.Text = "Amp";
            this.cmsItem_I_amp.Click += new System.EventHandler(this.cmsItem_I_amp_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_A_tof,
            this.cmsItem_A_amp});
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.aToolStripMenuItem.Text = "A";
            // 
            // cmsItem_A_tof
            // 
            this.cmsItem_A_tof.Name = "cmsItem_A_tof";
            this.cmsItem_A_tof.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_A_tof.Text = "Tof";
            this.cmsItem_A_tof.Click += new System.EventHandler(this.cmsItem_A_tof_Click);
            // 
            // cmsItem_A_amp
            // 
            this.cmsItem_A_amp.Name = "cmsItem_A_amp";
            this.cmsItem_A_amp.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_A_amp.Text = "Amp";
            this.cmsItem_A_amp.Click += new System.EventHandler(this.cmsItem_A_amp_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_B_tof,
            this.cmsItem_B_amp});
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.bToolStripMenuItem.Text = "B";
            // 
            // cmsItem_B_tof
            // 
            this.cmsItem_B_tof.Name = "cmsItem_B_tof";
            this.cmsItem_B_tof.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_B_tof.Text = "Tof";
            this.cmsItem_B_tof.Click += new System.EventHandler(this.cmsItem_B_tof_Click);
            // 
            // cmsItem_B_amp
            // 
            this.cmsItem_B_amp.Name = "cmsItem_B_amp";
            this.cmsItem_B_amp.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_B_amp.Text = "Amp";
            this.cmsItem_B_amp.Click += new System.EventHandler(this.cmsItem_B_amp_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_C_tof,
            this.cmsItem_C_amp});
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.cToolStripMenuItem.Text = "C";
            // 
            // cmsItem_C_tof
            // 
            this.cmsItem_C_tof.Name = "cmsItem_C_tof";
            this.cmsItem_C_tof.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_C_tof.Text = "Tof";
            this.cmsItem_C_tof.Click += new System.EventHandler(this.cmsItem_C_tof_Click);
            // 
            // cmsItem_C_amp
            // 
            this.cmsItem_C_amp.Name = "cmsItem_C_amp";
            this.cmsItem_C_amp.Size = new System.Drawing.Size(103, 22);
            this.cmsItem_C_amp.Text = "Amp";
            this.cmsItem_C_amp.Click += new System.EventHandler(this.cmsItem_C_amp_Click);
            // 
            // baToolStripMenuItem
            // 
            this.baToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_BA_tof,
            this.cmsItem_BA_amp});
            this.baToolStripMenuItem.Name = "baToolStripMenuItem";
            this.baToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.baToolStripMenuItem.Text = "BA";
            // 
            // cmsItem_BA_tof
            // 
            this.cmsItem_BA_tof.Name = "cmsItem_BA_tof";
            this.cmsItem_BA_tof.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_BA_tof.Text = "Thick";
            this.cmsItem_BA_tof.Click += new System.EventHandler(this.cmsItem_BA_tof_Click);
            // 
            // cmsItem_BA_amp
            // 
            this.cmsItem_BA_amp.Name = "cmsItem_BA_amp";
            this.cmsItem_BA_amp.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_BA_amp.Text = "Amp";
            this.cmsItem_BA_amp.Click += new System.EventHandler(this.cmsItem_BA_amp_Click);
            // 
            // aiToolStripMenuItem
            // 
            this.aiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_AI_tof,
            this.cmsItem_AI_amp});
            this.aiToolStripMenuItem.Name = "aiToolStripMenuItem";
            this.aiToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.aiToolStripMenuItem.Text = "AI";
            // 
            // cmsItem_AI_tof
            // 
            this.cmsItem_AI_tof.Name = "cmsItem_AI_tof";
            this.cmsItem_AI_tof.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_AI_tof.Text = "Thick";
            this.cmsItem_AI_tof.Click += new System.EventHandler(this.cmsItem_AI_tof_Click);
            // 
            // cmsItem_AI_amp
            // 
            this.cmsItem_AI_amp.Name = "cmsItem_AI_amp";
            this.cmsItem_AI_amp.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_AI_amp.Text = "Amp";
            this.cmsItem_AI_amp.Click += new System.EventHandler(this.cmsItem_AI_amp_Click);
            // 
            // biToolStripMenuItem
            // 
            this.biToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_BI_tof,
            this.cmsItem_BI_amp});
            this.biToolStripMenuItem.Name = "biToolStripMenuItem";
            this.biToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.biToolStripMenuItem.Text = "BI";
            // 
            // cmsItem_BI_tof
            // 
            this.cmsItem_BI_tof.Name = "cmsItem_BI_tof";
            this.cmsItem_BI_tof.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_BI_tof.Text = "Thick";
            this.cmsItem_BI_tof.Click += new System.EventHandler(this.cmsItem_BI_tof_Click);
            // 
            // cmsItem_BI_amp
            // 
            this.cmsItem_BI_amp.Name = "cmsItem_BI_amp";
            this.cmsItem_BI_amp.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_BI_amp.Text = "Amp";
            this.cmsItem_BI_amp.Click += new System.EventHandler(this.cmsItem_BI_amp_Click);
            // 
            // ciToolStripMenuItem
            // 
            this.ciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_CI_tof,
            this.cmsItem_CI_amp});
            this.ciToolStripMenuItem.Name = "ciToolStripMenuItem";
            this.ciToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.ciToolStripMenuItem.Text = "CI";
            // 
            // cmsItem_CI_tof
            // 
            this.cmsItem_CI_tof.Name = "cmsItem_CI_tof";
            this.cmsItem_CI_tof.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_CI_tof.Text = "Thick";
            this.cmsItem_CI_tof.Click += new System.EventHandler(this.cmsItem_CI_tof_Click);
            // 
            // cmsItem_CI_amp
            // 
            this.cmsItem_CI_amp.Name = "cmsItem_CI_amp";
            this.cmsItem_CI_amp.Size = new System.Drawing.Size(106, 22);
            this.cmsItem_CI_amp.Text = "Amp";
            this.cmsItem_CI_amp.Click += new System.EventHandler(this.cmsItem_CI_amp_Click);
            // 
            // lineRecord
            // 
            // 
            // 
            // 
            this.lineRecord.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineRecord.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lineRecord.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lineRecord.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lineRecord.Marks.Callout.Distance = 0;
            this.lineRecord.Marks.Callout.Draw3D = false;
            this.lineRecord.Marks.Callout.Length = 10;
            this.lineRecord.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.lineRecord.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineRecord.Marks.Symbol.Shadow.Visible = true;
            this.lineRecord.Title = "lineRecord";
            // 
            // 
            // 
            this.lineRecord.XValues.DataMember = "X";
            this.lineRecord.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lineRecord.YValues.DataMember = "Y";
            // 
            // tChartAscan
            // 
            // 
            // 
            // 
            this.tChartAscan.Aspect.ElevationFloat = 345D;
            this.tChartAscan.Aspect.RotationFloat = 345D;
            this.tChartAscan.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAscan.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Bottom.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.Bottom.Title.Caption = "xx";
            this.tChartAscan.Axes.Bottom.Title.Lines = new string[] {
        "xx"};
            // 
            // 
            // 
            this.tChartAscan.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Left.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.Left.Title.Caption = "xx";
            this.tChartAscan.Axes.Left.Title.Lines = new string[] {
        "xx"};
            // 
            // 
            // 
            this.tChartAscan.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Right.Grid.ZPosition = 0D;
            this.tChartAscan.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.tChartAscan.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Top.Grid.ZPosition = 0D;
            this.tChartAscan.BackColor = System.Drawing.Color.Transparent;
            this.tChartAscan.ContextMenuStrip = this.ContextMenuStrip;
            this.tChartAscan.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartAscan.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tChartAscan.Header.Lines = new string[] {
        "TeeChart"};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAscan.Legend.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAscan.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartAscan.Legend.Title.Pen.Visible = false;
            this.tChartAscan.Legend.Visible = false;
            this.tChartAscan.Location = new System.Drawing.Point(0, 0);
            this.tChartAscan.Name = "tChartAscan";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAscan.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChartAscan.Panel.MarginBottom = 8D;
            this.tChartAscan.Panel.MarginLeft = 4D;
            this.tChartAscan.Panel.MarginTop = 10D;
            this.tChartAscan.Series.Add(this.lineRecord);
            this.tChartAscan.Size = new System.Drawing.Size(1118, 272);
            this.tChartAscan.TabIndex = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAscan.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartAscan.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChartAscan.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartAscan.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChartAscan.Zoom.Allow = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tChartAscan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1118, 547);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Controls.Add(this.picBoxColorBar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1118, 271);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picBoxColorBar
            // 
            this.picBoxColorBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picBoxColorBar.Location = new System.Drawing.Point(1001, 3);
            this.picBoxColorBar.Name = "picBoxColorBar";
            this.picBoxColorBar.Size = new System.Drawing.Size(103, 162);
            this.picBoxColorBar.TabIndex = 1;
            this.picBoxColorBar.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tChartBscan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 265);
            this.panel1.TabIndex = 2;
            // 
            // tChartBscan
            // 
            // 
            // 
            // 
            this.tChartBscan.Aspect.ElevationFloat = 345D;
            this.tChartBscan.Aspect.RotationFloat = 345D;
            this.tChartBscan.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartBscan.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Bottom.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Left.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Right.Grid.ZPosition = 0D;
            this.tChartBscan.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.tChartBscan.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Top.Grid.ZPosition = 0D;
            this.tChartBscan.Axes.Top.Visible = false;
            this.tChartBscan.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartBscan.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tChartBscan.Header.Lines = new string[] {
        "TeeChart"};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartBscan.Legend.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartBscan.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartBscan.Legend.Title.Pen.Visible = false;
            this.tChartBscan.Legend.Visible = false;
            this.tChartBscan.Location = new System.Drawing.Point(0, 0);
            this.tChartBscan.Name = "tChartBscan";
            this.tChartBscan.Series.Add(this.line1);
            this.tChartBscan.Size = new System.Drawing.Size(992, 265);
            this.tChartBscan.TabIndex = 0;
            this.tChartBscan.Tools.Add(this.chartImage);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartBscan.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartBscan.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChartBscan.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartBscan.Walls.Right.AutoHide = false;
            this.tChartBscan.SizeChanged += new System.EventHandler(this.tChartBscan_SizeChanged);
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.line1.Function = this.smoothing1;
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line1.Marks.Callout.Distance = 0;
            this.line1.Marks.Callout.Draw3D = false;
            this.line1.Marks.Callout.Length = 10;
            this.line1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.line1.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line1.Title = "line1";
            // 
            // 
            // 
            this.line1.XValues.DataMember = "X";
            this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line1.YValues.DataMember = "Y";
            // 
            // smoothing1
            // 
            this.smoothing1.Period = 1D;
            // 
            // FormRecordFigure_AScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 547);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormRecordFigure_AScan";
            this.Text = "RecordFigure";
            this.Load += new System.EventHandler(this.FormRecordFigure_Load);
            this.ContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxColorBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_I_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_I_amp;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_A_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_A_amp;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_B_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_B_amp;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_C_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_C_amp;
        private System.Windows.Forms.ToolStripMenuItem baToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_BA_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_BA_amp;
        private System.Windows.Forms.ToolStripMenuItem aiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_AI_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_AI_amp;
        private System.Windows.Forms.ToolStripMenuItem biToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_BI_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_BI_amp;
        private System.Windows.Forms.ToolStripMenuItem ciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_CI_tof;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_CI_amp;
        private Steema.TeeChart.Styles.FastLine lineRecord;
        private Steema.TeeChart.TChart tChartAscan;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picBoxColorBar;
        private System.Windows.Forms.Panel panel1;
        private Steema.TeeChart.TChart tChartBscan;
        private Steema.TeeChart.Tools.ChartImage chartImage;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Functions.Smoothing smoothing1;

    }
}