namespace Ascan
{
    partial class FormTestStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestStrip));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tChartTof = new Steema.TeeChart.TChart();
            this.line2 = new Steema.TeeChart.Styles.Line();
            this.tChartAmp = new Steema.TeeChart.TChart();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.chanBox = new System.Windows.Forms.ComboBox();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.gateBox = new System.Windows.Forms.ComboBox();
            this.databox = new System.Windows.Forms.TextBox();
            this.cofirm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tChartTof, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tChartAmp, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chanBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.hScrollBar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.gateBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.databox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cofirm, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 435);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tChartTof
            // 
            // 
            // 
            // 
            this.tChartTof.Aspect.ElevationFloat = 345D;
            this.tChartTof.Aspect.RotationFloat = 345D;
            this.tChartTof.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Axes.Bottom.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartTof.Axes.Bottom.Grid.Visible = false;
            this.tChartTof.Axes.Bottom.Grid.ZPosition = 0D;
            this.tChartTof.Axes.Bottom.Increment = 10D;
            this.tChartTof.Axes.Bottom.Minimum = 0D;
            // 
            // 
            // 
            this.tChartTof.Axes.Depth.AutomaticMaximum = false;
            this.tChartTof.Axes.Depth.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartTof.Axes.Depth.Grid.ZPosition = 0D;
            this.tChartTof.Axes.Depth.Maximum = 0.5D;
            this.tChartTof.Axes.Depth.Minimum = -0.5D;
            // 
            // 
            // 
            this.tChartTof.Axes.DepthTop.AutomaticMaximum = false;
            this.tChartTof.Axes.DepthTop.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartTof.Axes.DepthTop.Grid.ZPosition = 0D;
            this.tChartTof.Axes.DepthTop.Maximum = 0.5D;
            this.tChartTof.Axes.DepthTop.Minimum = -0.5D;
            this.tChartTof.Axes.DrawBehind = false;
            // 
            // 
            // 
            this.tChartTof.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChartTof.Axes.Left.Grid.Visible = false;
            this.tChartTof.Axes.Left.Grid.ZPosition = 0D;
            this.tChartTof.Axes.Left.Increment = 20D;
            // 
            // 
            // 
            this.tChartTof.Axes.Left.Labels.CustomSize = 30;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tChartTof.Axes.Left.Labels.ValueFormat = "0";
            this.tChartTof.Axes.Left.MinorTickCount = 5;
            // 
            // 
            // 
            this.tChartTof.Axes.Left.Ticks.Length = 0;
            // 
            // 
            // 
            this.tChartTof.Axes.Left.TicksInner.Length = 4;
            // 
            // 
            // 
            this.tChartTof.Axes.Left.Title.Angle = 0;
            this.tChartTof.Axes.Left.Title.Caption = "us";
            this.tChartTof.Axes.Left.Title.Lines = new string[] {
        "us"};
            // 
            // 
            // 
            this.tChartTof.Axes.Right.AutomaticMaximum = false;
            this.tChartTof.Axes.Right.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartTof.Axes.Right.Grid.ZPosition = 0D;
            this.tChartTof.Axes.Right.Maximum = 0D;
            this.tChartTof.Axes.Right.Minimum = 0D;
            this.tChartTof.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.tChartTof.Axes.Top.AutomaticMaximum = false;
            this.tChartTof.Axes.Top.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartTof.Axes.Top.Grid.ZPosition = 0D;
            this.tChartTof.Axes.Top.Maximum = 0D;
            this.tChartTof.Axes.Top.Minimum = 0D;
            this.tChartTof.Axes.Top.Visible = false;
            this.tChartTof.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.SetColumnSpan(this.tChartTof, 4);
            this.tChartTof.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartTof.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Header.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartTof.Header.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Header.Font.Brush.Color = System.Drawing.Color.Black;
            this.tChartTof.Header.Font.Name = "新宋体";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Header.Font.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChartTof.Header.Font.Shadow.Height = 50;
            this.tChartTof.Header.Font.Size = 9;
            this.tChartTof.Header.Font.SizeFloat = 9F;
            this.tChartTof.Header.Lines = new string[] {
        "BScan",
        ""};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChartTof.Header.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Legend.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartTof.Legend.Title.Pen.Visible = false;
            this.tChartTof.Legend.Visible = false;
            this.tChartTof.Location = new System.Drawing.Point(3, 55);
            this.tChartTof.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tChartTof.Name = "tChartTof";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartTof.Panel.Brush.Color = System.Drawing.SystemColors.ButtonHighlight;
            this.tChartTof.Panel.MarginBottom = 10D;
            this.tChartTof.Panel.MarginLeft = 4D;
            this.tChartTof.Panel.MarginRight = 25D;
            this.tChartTof.Panel.MarginTop = 10D;
            this.tChartTof.Panel.MarginUnits = Steema.TeeChart.PanelMarginUnits.Pixels;
            // 
            // 
            // 
            this.tChartTof.Panel.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tChartTof.Panel.Pen.Visible = true;
            this.tChartTof.Series.Add(this.line2);
            this.tChartTof.Size = new System.Drawing.Size(902, 172);
            this.tChartTof.TabIndex = 3;
            this.tChartTof.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartTof.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartTof.Walls.Back.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartTof.Walls.Back.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            // 
            // 
            // 
            this.tChartTof.Walls.Back.Pen.Width = 2;
            // 
            // 
            // 
            this.tChartTof.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChartTof.Walls.Bottom.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartTof.Walls.Bottom.Pen.Width = 2;
            // 
            // 
            // 
            this.tChartTof.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartTof.Walls.Left.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartTof.Walls.Left.Pen.Width = 2;
            // 
            // 
            // 
            this.tChartTof.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChartTof.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartTof.Walls.Right.Pen.Width = 3;
            this.tChartTof.Walls.Right.Visible = true;
            // 
            // line2
            // 
            // 
            // 
            // 
            this.line2.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.line2.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line2.Marks.Callout.Distance = 0;
            this.line2.Marks.Callout.Draw3D = false;
            this.line2.Marks.Callout.Length = 10;
            this.line2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.line2.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line2.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.line2.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.line2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line2.Title = "line";
            // 
            // 
            // 
            this.line2.XValues.DataMember = "X";
            this.line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line2.YValues.DataMember = "Y";
            // 
            // tChartAmp
            // 
            // 
            // 
            // 
            this.tChartAmp.Aspect.ElevationFloat = 345D;
            this.tChartAmp.Aspect.RotationFloat = 345D;
            this.tChartAmp.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Axes.Bottom.AutomaticMaximum = false;
            this.tChartAmp.Axes.Bottom.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Bottom.Grid.Visible = false;
            this.tChartAmp.Axes.Bottom.Grid.ZPosition = 0D;
            this.tChartAmp.Axes.Bottom.Increment = 10D;
            this.tChartAmp.Axes.Bottom.Maximum = 100D;
            this.tChartAmp.Axes.Bottom.Minimum = 0D;
            // 
            // 
            // 
            this.tChartAmp.Axes.Bottom.Ticks.Visible = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Bottom.TicksInner.Visible = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Depth.AutomaticMaximum = false;
            this.tChartAmp.Axes.Depth.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Depth.Grid.ZPosition = 0D;
            this.tChartAmp.Axes.Depth.Maximum = 0.5D;
            this.tChartAmp.Axes.Depth.Minimum = -0.5D;
            // 
            // 
            // 
            this.tChartAmp.Axes.DepthTop.AutomaticMaximum = false;
            this.tChartAmp.Axes.DepthTop.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.DepthTop.Grid.ZPosition = 0D;
            this.tChartAmp.Axes.DepthTop.Maximum = 0.5D;
            this.tChartAmp.Axes.DepthTop.Minimum = -0.5D;
            this.tChartAmp.Axes.DrawBehind = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.AutomaticMaximum = false;
            this.tChartAmp.Axes.Left.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.Grid.Visible = false;
            this.tChartAmp.Axes.Left.Grid.ZPosition = 0D;
            this.tChartAmp.Axes.Left.Increment = 0.1D;
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.Labels.CustomSize = 30;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tChartAmp.Axes.Left.Labels.ValueFormat = "0";
            this.tChartAmp.Axes.Left.Maximum = 1D;
            this.tChartAmp.Axes.Left.Minimum = 0D;
            this.tChartAmp.Axes.Left.MinorTickCount = 5;
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.Ticks.Length = 0;
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.TicksInner.Length = 4;
            this.tChartAmp.Axes.Left.TicksInner.Visible = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Left.Title.Angle = 0;
            this.tChartAmp.Axes.Left.Title.Caption = "Am";
            this.tChartAmp.Axes.Left.Title.Lines = new string[] {
        "Am"};
            // 
            // 
            // 
            this.tChartAmp.Axes.Right.AutomaticMaximum = false;
            this.tChartAmp.Axes.Right.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Right.Grid.ZPosition = 0D;
            this.tChartAmp.Axes.Right.Maximum = 0D;
            this.tChartAmp.Axes.Right.Minimum = 0D;
            this.tChartAmp.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Top.AutomaticMaximum = false;
            this.tChartAmp.Axes.Top.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChartAmp.Axes.Top.Grid.ZPosition = 0D;
            this.tChartAmp.Axes.Top.Maximum = 0D;
            this.tChartAmp.Axes.Top.Minimum = 0D;
            this.tChartAmp.Axes.Top.Visible = false;
            this.tChartAmp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.SetColumnSpan(this.tChartAmp, 4);
            this.tChartAmp.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChartAmp.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Header.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartAmp.Header.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Header.Font.Brush.Color = System.Drawing.Color.Black;
            this.tChartAmp.Header.Font.Name = "新宋体";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Header.Font.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChartAmp.Header.Font.Shadow.Height = 50;
            this.tChartAmp.Header.Font.Size = 9;
            this.tChartAmp.Header.Font.SizeFloat = 9F;
            this.tChartAmp.Header.Lines = new string[] {
        "BScan",
        ""};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChartAmp.Header.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Legend.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChartAmp.Legend.Title.Pen.Visible = false;
            this.tChartAmp.Legend.Visible = false;
            this.tChartAmp.Location = new System.Drawing.Point(3, 237);
            this.tChartAmp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tChartAmp.Name = "tChartAmp";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChartAmp.Panel.Brush.Color = System.Drawing.SystemColors.ButtonHighlight;
            this.tChartAmp.Panel.MarginBottom = 10D;
            this.tChartAmp.Panel.MarginLeft = 4D;
            this.tChartAmp.Panel.MarginRight = 25D;
            this.tChartAmp.Panel.MarginTop = 10D;
            this.tChartAmp.Panel.MarginUnits = Steema.TeeChart.PanelMarginUnits.Pixels;
            // 
            // 
            // 
            this.tChartAmp.Panel.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tChartAmp.Panel.Pen.Visible = true;
            this.tChartAmp.Series.Add(this.line1);
            this.tChartAmp.Size = new System.Drawing.Size(902, 172);
            this.tChartAmp.TabIndex = 2;
            this.tChartAmp.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartAmp.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChartAmp.Walls.Back.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartAmp.Walls.Back.Gradient.Direction = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            // 
            // 
            // 
            this.tChartAmp.Walls.Back.Pen.Width = 2;
            // 
            // 
            // 
            this.tChartAmp.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChartAmp.Walls.Bottom.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartAmp.Walls.Bottom.Pen.Width = 2;
            // 
            // 
            // 
            this.tChartAmp.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChartAmp.Walls.Left.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartAmp.Walls.Left.Pen.Width = 2;
            // 
            // 
            // 
            this.tChartAmp.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChartAmp.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.tChartAmp.Walls.Right.Pen.Width = 3;
            this.tChartAmp.Walls.Right.Visible = true;
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.Red;
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
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
            this.line1.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line1.Title = "line";
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
            // chanBox
            // 
            this.chanBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chanBox.FormattingEnabled = true;
            this.chanBox.Location = new System.Drawing.Point(53, 15);
            this.chanBox.Name = "chanBox";
            this.chanBox.Size = new System.Drawing.Size(121, 20);
            this.chanBox.TabIndex = 1;
            this.chanBox.SelectedIndexChanged += new System.EventHandler(this.chanBox_SelectedIndexChanged);
            // 
            // hScrollBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.hScrollBar, 4);
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar.Location = new System.Drawing.Point(0, 414);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(908, 21);
            this.hScrollBar.TabIndex = 4;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // gateBox
            // 
            this.gateBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gateBox.FormattingEnabled = true;
            this.gateBox.Location = new System.Drawing.Point(280, 15);
            this.gateBox.Name = "gateBox";
            this.gateBox.Size = new System.Drawing.Size(121, 20);
            this.gateBox.TabIndex = 5;
            this.gateBox.SelectedIndexChanged += new System.EventHandler(this.gateBox_SelectedIndexChanged);
            // 
            // databox
            // 
            this.databox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.databox.Location = new System.Drawing.Point(517, 14);
            this.databox.Name = "databox";
            this.databox.Size = new System.Drawing.Size(100, 21);
            this.databox.TabIndex = 6;
            this.databox.Text = "10000";
            // 
            // cofirm
            // 
            this.cofirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cofirm.Location = new System.Drawing.Point(757, 13);
            this.cofirm.Name = "cofirm";
            this.cofirm.Size = new System.Drawing.Size(75, 23);
            this.cofirm.TabIndex = 7;
            this.cofirm.Text = "Confirm";
            this.cofirm.UseVisualStyleBackColor = true;
            this.cofirm.Click += new System.EventHandler(this.cofirm_Click);
            // 
            // FormTestStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 435);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormTestStrip";
            this.Text = "FormTestStrip";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox chanBox;
        public Steema.TeeChart.TChart tChartTof;
        public Steema.TeeChart.TChart tChartAmp;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Styles.Line line2;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.ComboBox gateBox;
        private System.Windows.Forms.TextBox databox;
        private System.Windows.Forms.Button cofirm;
    }
}