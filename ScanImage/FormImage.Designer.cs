namespace ScanImage
{
    partial class FormImage
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
            this.tChartBscan = new Steema.TeeChart.TChart();
            this.lineB = new Steema.TeeChart.Styles.Line();
            this.tChartAscan = new Steema.TeeChart.TChart();
            this.AscanLine = new Steema.TeeChart.Styles.HorizLine();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_paramater = new System.Windows.Forms.Button();
            this.Btn_start = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.BpicBox = new System.Windows.Forms.PictureBox();
            this.tChartCscan = new Steema.TeeChart.TChart();
            this.lineC = new Steema.TeeChart.Styles.Line();
            this.CpicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BpicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CpicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tChartBscan
            // 
            // 
            // 
            // 
            this.tChartBscan.Aspect.ColorPaletteIndex = -1;
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
            this.tChartBscan.Axes.Bottom.Grid.Color = System.Drawing.Color.Gray;
            this.tChartBscan.Axes.Bottom.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.Bottom.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartBscan.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Depth.Grid.Color = System.Drawing.Color.Gray;
            this.tChartBscan.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.Depth.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartBscan.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.DepthTop.Grid.Color = System.Drawing.Color.Gray;
            this.tChartBscan.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.DepthTop.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartBscan.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Left.Grid.Color = System.Drawing.Color.Gray;
            this.tChartBscan.Axes.Left.Grid.ZPosition = 0D;
            this.tChartBscan.Axes.Left.Inverted = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Left.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartBscan.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Right.Grid.Color = System.Drawing.Color.Gray;
            this.tChartBscan.Axes.Right.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.Right.Ticks.Length = 2;
            this.tChartBscan.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.tChartBscan.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartBscan.Axes.Top.Grid.Color = System.Drawing.Color.Gray;
            this.tChartBscan.Axes.Top.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartBscan.Axes.Top.Ticks.Length = 2;
            this.tChartBscan.Axes.Top.Visible = false;
            this.tChartBscan.BackColor = System.Drawing.Color.White;
            this.tChartBscan.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartBscan.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tChartBscan.Header.Lines = new string[] {
        "Bscan"};
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartBscan.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartBscan.Panel.Brush.Color = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tChartBscan.Panel.Gradient.EndColor = System.Drawing.Color.Yellow;
            this.tChartBscan.Panel.Gradient.MiddleColor = System.Drawing.Color.Empty;
            this.tChartBscan.Panel.Gradient.StartColor = System.Drawing.Color.White;
            this.tChartBscan.Panel.MarginBottom = 5D;
            this.tChartBscan.Panel.MarginLeft = 5D;
            this.tChartBscan.Panel.MarginRight = 5D;
            this.tChartBscan.Panel.MarginTop = 9D;
            // 
            // 
            // 
            this.tChartBscan.Panel.Shadow.Height = 0;
            this.tChartBscan.Panel.Shadow.Width = 0;
            this.tChartBscan.Series.Add(this.lineB);
            this.tChartBscan.Size = new System.Drawing.Size(686, 225);
            this.tChartBscan.TabIndex = 0;
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
            // 
            // 
            // 
            this.tChartBscan.Walls.Right.Brush.Color = System.Drawing.Color.Silver;
            // 
            // 
            // 
            this.tChartBscan.Zoom.AnimatedSteps = 7;
            // 
            // lineB
            // 
            // 
            // 
            // 
            this.lineB.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.lineB.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineB.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lineB.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lineB.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lineB.Marks.Callout.Distance = 0;
            this.lineB.Marks.Callout.Draw3D = false;
            this.lineB.Marks.Callout.Length = 10;
            this.lineB.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.lineB.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineB.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineB.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.lineB.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.lineB.Title = "line1";
            // 
            // 
            // 
            this.lineB.XValues.DataMember = "X";
            this.lineB.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lineB.YValues.DataMember = "Y";
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
            this.tChartAscan.Axes.Bottom.Grid.Color = System.Drawing.Color.Gray;
            this.tChartAscan.Axes.Bottom.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.Bottom.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartAscan.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Depth.Grid.Color = System.Drawing.Color.Gray;
            this.tChartAscan.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.Depth.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartAscan.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.DepthTop.Grid.Color = System.Drawing.Color.Gray;
            this.tChartAscan.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.DepthTop.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartAscan.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Left.Grid.Color = System.Drawing.Color.Gray;
            this.tChartAscan.Axes.Left.Grid.ZPosition = 0D;
            this.tChartAscan.Axes.Left.Inverted = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Left.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartAscan.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Right.Grid.Color = System.Drawing.Color.Gray;
            this.tChartAscan.Axes.Right.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.Right.Ticks.Length = 2;
            this.tChartAscan.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.tChartAscan.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartAscan.Axes.Top.Grid.Color = System.Drawing.Color.Gray;
            this.tChartAscan.Axes.Top.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChartAscan.Axes.Top.Ticks.Length = 2;
            this.tChartAscan.Axes.Top.Visible = false;
            this.tChartAscan.BackColor = System.Drawing.Color.White;
            this.tChartAscan.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartAscan.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tChartAscan.Header.Lines = new string[] {
        "Ascan"};
            // 
            // 
            // 
            this.tChartAscan.Legend.LegendStyle = Steema.TeeChart.LegendStyles.Palette;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAscan.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.tChartAscan.Panel.Brush.Color = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tChartAscan.Panel.Gradient.EndColor = System.Drawing.Color.Yellow;
            this.tChartAscan.Panel.Gradient.MiddleColor = System.Drawing.Color.Empty;
            this.tChartAscan.Panel.Gradient.StartColor = System.Drawing.Color.White;
            this.tChartAscan.Panel.MarginLeft = 6D;
            this.tChartAscan.Panel.MarginRight = 9D;
            // 
            // 
            // 
            this.tChartAscan.Panel.Shadow.Height = 0;
            this.tChartAscan.Panel.Shadow.Width = 0;
            this.tChartAscan.Series.Add(this.AscanLine);
            this.tChartAscan.Size = new System.Drawing.Size(201, 554);
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
            this.tChartAscan.Walls.Right.Brush.Color = System.Drawing.Color.Silver;
            // 
            // AscanLine
            // 
            // 
            // 
            // 
            this.AscanLine.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.AscanLine.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.AscanLine.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.AscanLine.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.AscanLine.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.AscanLine.Marks.Callout.Distance = 0;
            this.AscanLine.Marks.Callout.Draw3D = false;
            this.AscanLine.Marks.Callout.Length = 10;
            this.AscanLine.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.AscanLine.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.AscanLine.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.AscanLine.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.AscanLine.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.AscanLine.Title = "horizLine1";
            // 
            // 
            // 
            this.AscanLine.XValues.DataMember = "X";
            // 
            // 
            // 
            this.AscanLine.YValues.DataMember = "Y";
            this.AscanLine.YValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1115, 554);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer4.Size = new System.Drawing.Size(220, 554);
            this.splitContainer4.SplitterDistance = 441;
            this.splitContainer4.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn_stop, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_paramater, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_start, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 109);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_stop.Location = new System.Drawing.Point(58, 76);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(103, 29);
            this.btn_stop.TabIndex = 7;
            this.btn_stop.Text = "停止检测";
            this.btn_stop.UseVisualStyleBackColor = true;
            // 
            // btn_paramater
            // 
            this.btn_paramater.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_paramater.Location = new System.Drawing.Point(58, 4);
            this.btn_paramater.Name = "btn_paramater";
            this.btn_paramater.Size = new System.Drawing.Size(103, 28);
            this.btn_paramater.TabIndex = 5;
            this.btn_paramater.Text = "参数配置";
            this.btn_paramater.UseVisualStyleBackColor = true;
            this.btn_paramater.Click += new System.EventHandler(this.btn_paramater_Click);
            // 
            // Btn_start
            // 
            this.Btn_start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_start.Location = new System.Drawing.Point(58, 40);
            this.Btn_start.Name = "Btn_start";
            this.Btn_start.Size = new System.Drawing.Size(103, 28);
            this.Btn_start.TabIndex = 6;
            this.Btn_start.Text = "开始检测";
            this.Btn_start.UseVisualStyleBackColor = true;
            this.Btn_start.Click += new System.EventHandler(this.Btn_start_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tChartAscan);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(891, 554);
            this.splitContainer2.SplitterDistance = 201;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.BpicBox);
            this.splitContainer3.Panel1.Controls.Add(this.tChartBscan);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tChartCscan);
            this.splitContainer3.Panel2.Controls.Add(this.CpicBox);
            this.splitContainer3.Size = new System.Drawing.Size(686, 554);
            this.splitContainer3.SplitterDistance = 225;
            this.splitContainer3.TabIndex = 0;
            // 
            // BpicBox
            // 
            this.BpicBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.BpicBox.Location = new System.Drawing.Point(666, 0);
            this.BpicBox.Name = "BpicBox";
            this.BpicBox.Size = new System.Drawing.Size(20, 225);
            this.BpicBox.TabIndex = 1;
            this.BpicBox.TabStop = false;
            // 
            // tChartCscan
            // 
            // 
            // 
            // 
            this.tChartCscan.Aspect.ColorPaletteIndex = -1;
            this.tChartCscan.Aspect.ElevationFloat = 345D;
            this.tChartCscan.Aspect.RotationFloat = 345D;
            this.tChartCscan.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChartCscan.Axes.Bottom.Grid.Centered = true;
            this.tChartCscan.Axes.Bottom.Grid.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Bottom.Grid.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.tChartCscan.Axes.Bottom.Grid.Visible = false;
            this.tChartCscan.Axes.Bottom.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Bottom.Labels.Font.Name = "Times New Roman";
            this.tChartCscan.Axes.Bottom.Labels.Font.Size = 10;
            this.tChartCscan.Axes.Bottom.Labels.Font.SizeFloat = 10F;
            // 
            // 
            // 
            this.tChartCscan.Axes.Bottom.MinorTicks.Visible = false;
            // 
            // 
            // 
            this.tChartCscan.Axes.Bottom.Ticks.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Bottom.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartCscan.Axes.Bottom.TicksInner.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Bottom.Title.Font.Name = "Times New Roman";
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.AxisPen.Width = 1;
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.Grid.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Depth.Grid.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.tChartCscan.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.Labels.Font.Name = "Times New Roman";
            this.tChartCscan.Axes.Depth.Labels.Font.Size = 10;
            this.tChartCscan.Axes.Depth.Labels.Font.SizeFloat = 10F;
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.MinorTicks.Visible = false;
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.Ticks.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Depth.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.TicksInner.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Depth.Title.Font.Name = "Times New Roman";
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.AxisPen.Width = 1;
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.Grid.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.DepthTop.Grid.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.tChartCscan.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.Labels.Font.Name = "Times New Roman";
            this.tChartCscan.Axes.DepthTop.Labels.Font.Size = 10;
            this.tChartCscan.Axes.DepthTop.Labels.Font.SizeFloat = 10F;
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.MinorTicks.Visible = false;
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.Ticks.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.DepthTop.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.TicksInner.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.DepthTop.Title.Font.Name = "Times New Roman";
            // 
            // 
            // 
            this.tChartCscan.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartCscan.Axes.Left.Grid.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Left.Grid.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.tChartCscan.Axes.Left.Grid.Visible = false;
            this.tChartCscan.Axes.Left.Grid.ZPosition = 0D;
            this.tChartCscan.Axes.Left.Inverted = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Left.Labels.Font.Name = "Times New Roman";
            this.tChartCscan.Axes.Left.Labels.Font.Size = 10;
            this.tChartCscan.Axes.Left.Labels.Font.SizeFloat = 10F;
            // 
            // 
            // 
            this.tChartCscan.Axes.Left.MinorTicks.Visible = false;
            // 
            // 
            // 
            this.tChartCscan.Axes.Left.Ticks.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Left.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartCscan.Axes.Left.TicksInner.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Left.Title.Font.Name = "Times New Roman";
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.AxisPen.Width = 1;
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.Grid.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Right.Grid.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.tChartCscan.Axes.Right.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.Labels.Font.Name = "Times New Roman";
            this.tChartCscan.Axes.Right.Labels.Font.Size = 10;
            this.tChartCscan.Axes.Right.Labels.Font.SizeFloat = 10F;
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.MinorTicks.Visible = false;
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.Ticks.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Right.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.TicksInner.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Right.Title.Font.Name = "Times New Roman";
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.AxisPen.Width = 1;
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.Grid.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Top.Grid.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.tChartCscan.Axes.Top.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.Labels.Font.Name = "Times New Roman";
            this.tChartCscan.Axes.Top.Labels.Font.Size = 10;
            this.tChartCscan.Axes.Top.Labels.Font.SizeFloat = 10F;
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.MinorTicks.Visible = false;
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.Ticks.Color = System.Drawing.Color.Black;
            this.tChartCscan.Axes.Top.Ticks.Length = 2;
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.TicksInner.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Axes.Top.Title.Font.Name = "Times New Roman";
            this.tChartCscan.BackColor = System.Drawing.Color.White;
            this.tChartCscan.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartCscan.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Header.Font.Brush.Color = System.Drawing.Color.Black;
            this.tChartCscan.Header.Font.Name = "Times New Roman";
            this.tChartCscan.Header.Font.Size = 12;
            this.tChartCscan.Header.Font.SizeFloat = 12F;
            this.tChartCscan.Header.Lines = new string[] {
        "Cscan"};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Legend.Font.Name = "Times New Roman";
            this.tChartCscan.Legend.Font.Size = 10;
            this.tChartCscan.Legend.Font.SizeFloat = 10F;
            // 
            // 
            // 
            this.tChartCscan.Legend.Pen.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tChartCscan.Legend.Shadow.Height = 0;
            this.tChartCscan.Legend.Shadow.Visible = true;
            this.tChartCscan.Legend.Shadow.Width = 0;
            // 
            // 
            // 
            this.tChartCscan.Legend.Symbol.DefaultPen = false;
            // 
            // 
            // 
            this.tChartCscan.Legend.Symbol.Pen.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartCscan.Legend.Title.Pen.Visible = false;
            this.tChartCscan.Legend.Transparent = true;
            this.tChartCscan.Legend.Visible = false;
            this.tChartCscan.Location = new System.Drawing.Point(0, 0);
            this.tChartCscan.Name = "tChartCscan";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartCscan.Panel.Brush.Color = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tChartCscan.Panel.Gradient.EndColor = System.Drawing.Color.Yellow;
            this.tChartCscan.Panel.Gradient.MiddleColor = System.Drawing.Color.Empty;
            this.tChartCscan.Panel.Gradient.StartColor = System.Drawing.Color.White;
            this.tChartCscan.Panel.MarginBottom = 6D;
            this.tChartCscan.Panel.MarginLeft = 5D;
            this.tChartCscan.Panel.MarginTop = 5D;
            // 
            // 
            // 
            this.tChartCscan.Panel.Pen.Visible = true;
            // 
            // 
            // 
            this.tChartCscan.Panel.Shadow.Height = 0;
            this.tChartCscan.Panel.Shadow.Width = 0;
            this.tChartCscan.Series.Add(this.lineC);
            this.tChartCscan.Size = new System.Drawing.Size(666, 325);
            this.tChartCscan.TabIndex = 2;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartCscan.Walls.Back.ApplyDark = false;
            this.tChartCscan.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartCscan.Walls.Back.Brush.Color = System.Drawing.Color.White;
            this.tChartCscan.Walls.Back.Size = 8;
            this.tChartCscan.Walls.Back.Transparent = false;
            // 
            // 
            // 
            this.tChartCscan.Walls.Bottom.ApplyDark = false;
            this.tChartCscan.Walls.Bottom.AutoHide = false;
            this.tChartCscan.Walls.Bottom.Size = 8;
            // 
            // 
            // 
            this.tChartCscan.Walls.Left.ApplyDark = false;
            this.tChartCscan.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartCscan.Walls.Left.Brush.Color = System.Drawing.Color.White;
            this.tChartCscan.Walls.Left.Size = 8;
            // 
            // 
            // 
            this.tChartCscan.Walls.Right.ApplyDark = false;
            this.tChartCscan.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChartCscan.Walls.Right.Brush.Color = System.Drawing.Color.White;
            this.tChartCscan.Walls.Right.Size = 8;
            // 
            // lineC
            // 
            // 
            // 
            // 
            this.lineC.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.lineC.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineC.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lineC.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lineC.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lineC.Marks.Callout.Distance = 0;
            this.lineC.Marks.Callout.Draw3D = false;
            this.lineC.Marks.Callout.Length = 10;
            this.lineC.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.lineC.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineC.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.lineC.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.lineC.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.lineC.Title = "lineC";
            // 
            // 
            // 
            this.lineC.XValues.DataMember = "X";
            this.lineC.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lineC.YValues.DataMember = "Y";
            // 
            // CpicBox
            // 
            this.CpicBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.CpicBox.Location = new System.Drawing.Point(666, 0);
            this.CpicBox.Name = "CpicBox";
            this.CpicBox.Size = new System.Drawing.Size(20, 325);
            this.CpicBox.TabIndex = 1;
            this.CpicBox.TabStop = false;
            // 
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 554);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormImage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormImage_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BpicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CpicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Steema.TeeChart.TChart tChartBscan;
        private Steema.TeeChart.Styles.Line lineB;
        private Steema.TeeChart.TChart tChartAscan;
        private Steema.TeeChart.Styles.HorizLine AscanLine;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PictureBox BpicBox;
        private System.Windows.Forms.PictureBox CpicBox;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_paramater;
        private System.Windows.Forms.Button Btn_start;
        private Steema.TeeChart.TChart tChartCscan;
        private Steema.TeeChart.Styles.Line lineC;

    }
}