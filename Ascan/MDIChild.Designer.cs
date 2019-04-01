namespace Ascan
{
    partial class MDIChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIChild));
            this.btn_freeze = new System.Windows.Forms.Button();
            this.comboBoxMagnify = new System.Windows.Forms.ComboBox();
            this.labelMagnify = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.NumUpDownRange = new System.Windows.Forms.NumericUpDown();
            this.labelRange = new System.Windows.Forms.Label();
            this.NumUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.labelDelay = new System.Windows.Forms.Label();
            this.tChart = new Steema.TeeChart.TChart();
            this.GateI = new Steema.TeeChart.Styles.Line();
            this.GateA = new Steema.TeeChart.Styles.Line();
            this.GateB = new Steema.TeeChart.Styles.Line();
            this.GateC = new Steema.TeeChart.Styles.Line();
            this.MaxUp = new Steema.TeeChart.Styles.Line();
            this.MaxDown = new Steema.TeeChart.Styles.Line();
            this.General = new Steema.TeeChart.Styles.Line();
            this.DACPoint = new Steema.TeeChart.Styles.Line();
            this.DACLine = new Steema.TeeChart.Styles.Line();
            this.TCG = new Steema.TeeChart.Styles.Line();
            this.MDAC1 = new Steema.TeeChart.Styles.Line();
            this.MDAC2 = new Steema.TeeChart.Styles.Line();
            this.MDAC3 = new Steema.TeeChart.Styles.Line();
            this.MDAC4 = new Steema.TeeChart.Styles.Line();
            this.GateIDragPoint = new Steema.TeeChart.Tools.DragPoint();
            this.GateADragPoint = new Steema.TeeChart.Tools.DragPoint();
            this.GateBDragPoint = new Steema.TeeChart.Tools.DragPoint();
            this.GateCDragPoint = new Steema.TeeChart.Tools.DragPoint();
            this.marksTip1 = new Steema.TeeChart.Tools.MarksTip();
            this.groupBoxGain = new System.Windows.Forms.GroupBox();
            this.TrackBarGain = new System.Windows.Forms.TrackBar();
            this.TextBoxGain = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toranceMonitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDACMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dACMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialVelocityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.probeDelayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.focusRuleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchParametersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conditioningParametersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triggerModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.cmbReceiver = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownDelay)).BeginInit();
            this.groupBoxGain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGain)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_freeze
            // 
            this.btn_freeze.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_freeze.Location = new System.Drawing.Point(902, 506);
            this.btn_freeze.Name = "btn_freeze";
            this.btn_freeze.Size = new System.Drawing.Size(58, 23);
            this.btn_freeze.TabIndex = 9;
            this.btn_freeze.Text = "Freeze";
            this.btn_freeze.UseVisualStyleBackColor = true;
            this.btn_freeze.Click += new System.EventHandler(this.btn_freeze_Click);
            // 
            // comboBoxMagnify
            // 
            this.comboBoxMagnify.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxMagnify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMagnify.FormattingEnabled = true;
            this.comboBoxMagnify.Items.AddRange(new object[] {
            "off",
            "I",
            "A",
            "B",
            "C"});
            this.comboBoxMagnify.Location = new System.Drawing.Point(68, 507);
            this.comboBoxMagnify.Name = "comboBoxMagnify";
            this.comboBoxMagnify.Size = new System.Drawing.Size(64, 20);
            this.comboBoxMagnify.TabIndex = 8;
            this.comboBoxMagnify.Tag = "5";
            this.comboBoxMagnify.SelectedIndexChanged += new System.EventHandler(this.comboBoxMagnify_SelectedIndexChanged);
            // 
            // labelMagnify
            // 
            this.labelMagnify.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMagnify.AutoSize = true;
            this.labelMagnify.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMagnify.Location = new System.Drawing.Point(3, 509);
            this.labelMagnify.Name = "labelMagnify";
            this.labelMagnify.Size = new System.Drawing.Size(59, 17);
            this.labelMagnify.TabIndex = 7;
            this.labelMagnify.Text = "Magnify";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(433, 511);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "us";
            // 
            // NumUpDownRange
            // 
            this.NumUpDownRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumUpDownRange.DecimalPlaces = 2;
            this.NumUpDownRange.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumUpDownRange.Location = new System.Drawing.Point(363, 506);
            this.NumUpDownRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumUpDownRange.Name = "NumUpDownRange";
            this.NumUpDownRange.Size = new System.Drawing.Size(64, 23);
            this.NumUpDownRange.TabIndex = 5;
            this.NumUpDownRange.Click += new System.EventHandler(this.NumUpDownRange_Click);
            this.NumUpDownRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumUpDownRange_KeyPress);
            this.NumUpDownRange.Leave += new System.EventHandler(this.NumUpDownRange_Leave);
            // 
            // labelRange
            // 
            this.labelRange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRange.AutoSize = true;
            this.labelRange.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRange.Location = new System.Drawing.Point(311, 509);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(46, 17);
            this.labelRange.TabIndex = 4;
            this.labelRange.Text = "Range";
            // 
            // NumUpDownDelay
            // 
            this.NumUpDownDelay.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumUpDownDelay.DecimalPlaces = 2;
            this.NumUpDownDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumUpDownDelay.Location = new System.Drawing.Point(203, 506);
            this.NumUpDownDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumUpDownDelay.Name = "NumUpDownDelay";
            this.NumUpDownDelay.Size = new System.Drawing.Size(64, 23);
            this.NumUpDownDelay.TabIndex = 3;
            this.NumUpDownDelay.Click += new System.EventHandler(this.NumUpDownDelay_Click);
            this.NumUpDownDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumUpDownDelay_KeyPress);
            this.NumUpDownDelay.Leave += new System.EventHandler(this.NumUpDownDelay_Leave);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(273, 511);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "us";
            // 
            // labelDelay
            // 
            this.labelDelay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDelay.AutoSize = true;
            this.labelDelay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDelay.Location = new System.Drawing.Point(154, 509);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(43, 17);
            this.labelDelay.TabIndex = 0;
            this.labelDelay.Text = "Delay";
            // 
            // tChart
            // 
            // 
            // 
            // 
            this.tChart.Aspect.ElevationFloat = 345D;
            this.tChart.Aspect.RotationFloat = 345D;
            this.tChart.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChart.Axes.Bottom.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.tChart.Axes.Bottom.Grid.Visible = false;
            this.tChart.Axes.Bottom.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.tChart.Axes.Bottom.Ticks.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            // 
            // 
            // 
            this.tChart.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChart.Axes.Depth.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChart.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChart.Axes.DepthTop.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChart.Axes.Left.AutomaticMaximum = false;
            this.tChart.Axes.Left.AutomaticMinimum = false;
            // 
            // 
            // 
            this.tChart.Axes.Left.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.tChart.Axes.Left.Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart.Axes.Left.Grid.Visible = false;
            this.tChart.Axes.Left.Grid.ZPosition = 0D;
            this.tChart.Axes.Left.Increment = 0.2D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Left.Maximum = 1353D;
            this.tChart.Axes.Left.Minimum = 339D;
            // 
            // 
            // 
            this.tChart.Axes.Left.Ticks.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.tChart.Axes.Left.TicksInner.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.tChart.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChart.Axes.Right.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.tChart.Axes.Right.Grid.ZPosition = 0D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.tChart.Axes.Right.Ticks.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChart.Axes.Right.Visible = false;
            // 
            // 
            // 
            this.tChart.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChart.Axes.Top.AxisPen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            this.tChart.Axes.Top.Grid.ZPosition = 0D;
            // 
            // 
            // 
            this.tChart.Axes.Top.Ticks.Visible = false;
            // 
            // 
            // 
            this.tChart.Axes.Top.TicksInner.Visible = false;
            this.tChart.Axes.Top.Visible = false;
            this.tChart.BackColor = System.Drawing.Color.Maroon;
            this.tChart.Cursor = System.Windows.Forms.Cursors.Default;
            this.tChart.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Footer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.tChart.Header.Lines = new string[] {
        "TeeChart"};
            this.tChart.Header.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Legend.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart.Legend.Title.Pen.Visible = false;
            this.tChart.Legend.Visible = false;
            this.tChart.Location = new System.Drawing.Point(0, 0);
            this.tChart.Name = "tChart";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Panel.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Panel.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Series.Add(this.GateI);
            this.tChart.Series.Add(this.GateA);
            this.tChart.Series.Add(this.GateB);
            this.tChart.Series.Add(this.GateC);
            this.tChart.Series.Add(this.MaxUp);
            this.tChart.Series.Add(this.MaxDown);
            this.tChart.Series.Add(this.General);
            this.tChart.Series.Add(this.DACPoint);
            this.tChart.Series.Add(this.DACLine);
            this.tChart.Series.Add(this.TCG);
            this.tChart.Series.Add(this.MDAC1);
            this.tChart.Series.Add(this.MDAC2);
            this.tChart.Series.Add(this.MDAC3);
            this.tChart.Series.Add(this.MDAC4);
            this.tChart.Size = new System.Drawing.Size(893, 496);
            this.tChart.TabIndex = 0;
            this.tChart.Tools.Add(this.GateIDragPoint);
            this.tChart.Tools.Add(this.GateADragPoint);
            this.tChart.Tools.Add(this.GateBDragPoint);
            this.tChart.Tools.Add(this.GateCDragPoint);
            this.tChart.Tools.Add(this.marksTip1);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChart.Walls.Back.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.tChart.Walls.Back.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tChart.Walls.Back.Pen.Width = 2;
            // 
            // 
            // 
            this.tChart.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChart.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart.Walls.Left.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.tChart.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChart.Walls.Right.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.tChart.Walls.Right.Gradient.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Walls.Right.Gradient.UseMiddle = true;
            // 
            // 
            // 
            this.tChart.Walls.Right.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tChart.Walls.Right.Transparent = true;
            this.tChart.Walls.Right.Visible = true;
            this.tChart.Walls.View3D = false;
            this.tChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tChart_MouseDown);
            this.tChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tChart_MouseUp);
            // 
            // GateI
            // 
            // 
            // 
            // 
            this.GateI.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.GateI.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.GateI.LinePen.Width = 2;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateI.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.GateI.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.GateI.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.GateI.Marks.Callout.Distance = 0;
            this.GateI.Marks.Callout.Draw3D = false;
            this.GateI.Marks.Callout.Length = 10;
            this.GateI.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.GateI.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateI.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateI.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.GateI.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.GateI.Title = "GateI";
            // 
            // 
            // 
            this.GateI.XValues.DataMember = "X";
            this.GateI.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.GateI.YValues.DataMember = "Y";
            // 
            // GateA
            // 
            // 
            // 
            // 
            this.GateA.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.GateA.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GateA.LinePen.Width = 2;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateA.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.GateA.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.GateA.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.GateA.Marks.Callout.Distance = 0;
            this.GateA.Marks.Callout.Draw3D = false;
            this.GateA.Marks.Callout.Length = 10;
            this.GateA.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.GateA.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateA.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateA.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.GateA.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.GateA.Title = "GateA";
            // 
            // 
            // 
            this.GateA.XValues.DataMember = "X";
            this.GateA.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.GateA.YValues.DataMember = "Y";
            // 
            // GateB
            // 
            // 
            // 
            // 
            this.GateB.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.GateB.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            this.GateB.LinePen.EndCap = System.Drawing.Drawing2D.LineCap.AnchorMask;
            this.GateB.LinePen.Width = 2;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateB.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.GateB.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.GateB.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.GateB.Marks.Callout.Distance = 0;
            this.GateB.Marks.Callout.Draw3D = false;
            this.GateB.Marks.Callout.Length = 10;
            this.GateB.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.GateB.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateB.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateB.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.GateB.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.GateB.Title = "GateB";
            // 
            // 
            // 
            this.GateB.XValues.DataMember = "X";
            this.GateB.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.GateB.YValues.DataMember = "Y";
            // 
            // GateC
            // 
            // 
            // 
            // 
            this.GateC.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.GateC.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.GateC.LinePen.Width = 2;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateC.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.GateC.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.GateC.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.GateC.Marks.Callout.Distance = 0;
            this.GateC.Marks.Callout.Draw3D = false;
            this.GateC.Marks.Callout.Length = 10;
            this.GateC.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.GateC.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateC.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.GateC.Pointer.Brush.Color = System.Drawing.Color.Yellow;
            this.GateC.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.GateC.Title = "Gatec";
            // 
            // 
            // 
            this.GateC.XValues.DataMember = "X";
            this.GateC.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.GateC.YValues.DataMember = "Y";
            // 
            // MaxUp
            // 
            // 
            // 
            // 
            this.MaxUp.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.MaxUp.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.MaxUp.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.MaxUp.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.MaxUp.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.MaxUp.Marks.Callout.Distance = 0;
            this.MaxUp.Marks.Callout.Draw3D = false;
            this.MaxUp.Marks.Callout.Length = 10;
            this.MaxUp.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.MaxUp.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MaxUp.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MaxUp.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MaxUp.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.MaxUp.Title = "MaxUp";
            // 
            // 
            // 
            this.MaxUp.XValues.DataMember = "X";
            this.MaxUp.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MaxUp.YValues.DataMember = "Y";
            // 
            // MaxDown
            // 
            // 
            // 
            // 
            this.MaxDown.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.MaxDown.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(153)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.MaxDown.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.MaxDown.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.MaxDown.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.MaxDown.Marks.Callout.Distance = 0;
            this.MaxDown.Marks.Callout.Draw3D = false;
            this.MaxDown.Marks.Callout.Length = 10;
            this.MaxDown.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.MaxDown.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MaxDown.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MaxDown.Pointer.Brush.Color = System.Drawing.Color.Red;
            this.MaxDown.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.MaxDown.Title = "MaxDown";
            // 
            // 
            // 
            this.MaxDown.XValues.DataMember = "X";
            this.MaxDown.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MaxDown.YValues.DataMember = "Y";
            // 
            // General
            // 
            // 
            // 
            // 
            this.General.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.General.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.General.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.General.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.General.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.General.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.General.Marks.Callout.Distance = 0;
            this.General.Marks.Callout.Draw3D = false;
            this.General.Marks.Callout.Length = 10;
            this.General.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.General.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.General.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.General.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.General.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.General.Title = "General";
            // 
            // 
            // 
            this.General.XValues.DataMember = "X";
            this.General.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.General.YValues.DataMember = "Y";
            // 
            // DACPoint
            // 
            // 
            // 
            // 
            this.DACPoint.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.DACPoint.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(77)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.DACPoint.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.DACPoint.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.DACPoint.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.DACPoint.Marks.Callout.Distance = 0;
            this.DACPoint.Marks.Callout.Draw3D = false;
            this.DACPoint.Marks.Callout.Length = 10;
            this.DACPoint.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.DACPoint.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.DACPoint.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.DACPoint.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DACPoint.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.DACPoint.Title = "DACPoint";
            // 
            // 
            // 
            this.DACPoint.XValues.DataMember = "X";
            this.DACPoint.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.DACPoint.YValues.DataMember = "Y";
            // 
            // DACLine
            // 
            // 
            // 
            // 
            this.DACLine.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.DACLine.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.DACLine.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.DACLine.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.DACLine.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.DACLine.Marks.Callout.Distance = 0;
            this.DACLine.Marks.Callout.Draw3D = false;
            this.DACLine.Marks.Callout.Length = 10;
            this.DACLine.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.DACLine.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.DACLine.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.DACLine.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DACLine.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.DACLine.Title = "DACLine";
            // 
            // 
            // 
            this.DACLine.XValues.DataMember = "X";
            this.DACLine.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.DACLine.YValues.DataMember = "Y";
            // 
            // TCG
            // 
            // 
            // 
            // 
            this.TCG.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.TCG.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.TCG.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.TCG.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.TCG.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.TCG.Marks.Callout.Distance = 0;
            this.TCG.Marks.Callout.Draw3D = false;
            this.TCG.Marks.Callout.Length = 10;
            this.TCG.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.TCG.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.TCG.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.TCG.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TCG.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.TCG.Title = "TCG";
            // 
            // 
            // 
            this.TCG.XValues.DataMember = "X";
            this.TCG.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.TCG.YValues.DataMember = "Y";
            // 
            // MDAC1
            // 
            // 
            // 
            // 
            this.MDAC1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            // 
            // 
            // 
            this.MDAC1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.MDAC1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.MDAC1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.MDAC1.Marks.Callout.Distance = 0;
            this.MDAC1.Marks.Callout.Draw3D = false;
            this.MDAC1.Marks.Callout.Length = 10;
            this.MDAC1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.MDAC1.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC1.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC1.Pointer.Brush.Color = System.Drawing.Color.Green;
            this.MDAC1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.MDAC1.Title = "MDAC1";
            this.MDAC1.Visible = false;
            // 
            // 
            // 
            this.MDAC1.XValues.DataMember = "X";
            this.MDAC1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MDAC1.YValues.DataMember = "Y";
            // 
            // MDAC2
            // 
            // 
            // 
            // 
            this.MDAC2.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.MDAC2.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.MDAC2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.MDAC2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.MDAC2.Marks.Callout.Distance = 0;
            this.MDAC2.Marks.Callout.Draw3D = false;
            this.MDAC2.Marks.Callout.Length = 10;
            this.MDAC2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.MDAC2.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC2.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC2.Pointer.Brush.Color = System.Drawing.Color.Yellow;
            this.MDAC2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.MDAC2.Title = "MDAC2";
            this.MDAC2.Visible = false;
            // 
            // 
            // 
            this.MDAC2.XValues.DataMember = "X";
            this.MDAC2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MDAC2.YValues.DataMember = "Y";
            // 
            // MDAC3
            // 
            // 
            // 
            // 
            this.MDAC3.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            this.MDAC3.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC3.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.MDAC3.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.MDAC3.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.MDAC3.Marks.Callout.Distance = 0;
            this.MDAC3.Marks.Callout.Draw3D = false;
            this.MDAC3.Marks.Callout.Length = 10;
            this.MDAC3.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.MDAC3.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC3.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC3.Pointer.Brush.Color = System.Drawing.Color.Blue;
            this.MDAC3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.MDAC3.Title = "MDAC3";
            this.MDAC3.Visible = false;
            // 
            // 
            // 
            this.MDAC3.XValues.DataMember = "X";
            this.MDAC3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MDAC3.YValues.DataMember = "Y";
            // 
            // MDAC4
            // 
            // 
            // 
            // 
            this.MDAC4.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.MDAC4.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(153)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC4.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.MDAC4.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.MDAC4.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.MDAC4.Marks.Callout.Distance = 0;
            this.MDAC4.Marks.Callout.Draw3D = false;
            this.MDAC4.Marks.Callout.Length = 10;
            this.MDAC4.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.MDAC4.Marks.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC4.Marks.Symbol.Shadow.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.MDAC4.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.MDAC4.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.MDAC4.Title = "MDAC4";
            this.MDAC4.Visible = false;
            // 
            // 
            // 
            this.MDAC4.XValues.DataMember = "X";
            this.MDAC4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.MDAC4.YValues.DataMember = "Y";
            // 
            // GateIDragPoint
            // 
            this.GateIDragPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GateIDragPoint.Series = this.GateI;
            this.GateIDragPoint.Style = Steema.TeeChart.Tools.DragPointStyles.X;
            this.GateIDragPoint.Drag += new Steema.TeeChart.Tools.DragPointEventHandler(this.GateIDragPoint_Drag);
            // 
            // GateADragPoint
            // 
            this.GateADragPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GateADragPoint.Series = this.GateA;
            this.GateADragPoint.Style = Steema.TeeChart.Tools.DragPointStyles.X;
            this.GateADragPoint.Drag += new Steema.TeeChart.Tools.DragPointEventHandler(this.GateADragPoint_Drag);
            // 
            // GateBDragPoint
            // 
            this.GateBDragPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GateBDragPoint.Series = this.GateB;
            this.GateBDragPoint.Style = Steema.TeeChart.Tools.DragPointStyles.X;
            this.GateBDragPoint.Drag += new Steema.TeeChart.Tools.DragPointEventHandler(this.GateBDragPoint_Drag);
            // 
            // GateCDragPoint
            // 
            this.GateCDragPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GateCDragPoint.Series = this.GateC;
            this.GateCDragPoint.Style = Steema.TeeChart.Tools.DragPointStyles.X;
            this.GateCDragPoint.Drag += new Steema.TeeChart.Tools.DragPointEventHandler(this.GateCDragPoint_Drag);
            // 
            // marksTip1
            // 
            this.marksTip1.Series = this.General;
            // 
            // groupBoxGain
            // 
            this.groupBoxGain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxGain.Controls.Add(this.TrackBarGain);
            this.groupBoxGain.Controls.Add(this.TextBoxGain);
            this.groupBoxGain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxGain.Location = new System.Drawing.Point(903, 3);
            this.groupBoxGain.Name = "groupBoxGain";
            this.groupBoxGain.Size = new System.Drawing.Size(56, 163);
            this.groupBoxGain.TabIndex = 5;
            this.groupBoxGain.TabStop = false;
            this.groupBoxGain.Text = "Gain";
            // 
            // TrackBarGain
            // 
            this.TrackBarGain.Location = new System.Drawing.Point(1, 47);
            this.TrackBarGain.Maximum = 820;
            this.TrackBarGain.Minimum = -480;
            this.TrackBarGain.Name = "TrackBarGain";
            this.TrackBarGain.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrackBarGain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TrackBarGain.RightToLeftLayout = true;
            this.TrackBarGain.Size = new System.Drawing.Size(45, 104);
            this.TrackBarGain.TabIndex = 1;
            this.TrackBarGain.Scroll += new System.EventHandler(this.TrackBarGain_Scroll);
            this.TrackBarGain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarGain_MouseUp);
            // 
            // TextBoxGain
            // 
            this.TextBoxGain.Location = new System.Drawing.Point(5, 20);
            this.TextBoxGain.Name = "TextBoxGain";
            this.TextBoxGain.Size = new System.Drawing.Size(45, 23);
            this.TextBoxGain.TabIndex = 0;
            this.TextBoxGain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxGain_KeyPress);
            this.TextBoxGain.Leave += new System.EventHandler(this.TextBoxGain_Leave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toranceMonitorMenuItem,
            this.mDACMenuItem,
            this.dACMenuItem,
            this.materialVelocityMenuItem,
            this.probeDelayMenuItem,
            this.focusRuleMenuItem,
            this.launchParametersMenuItem,
            this.conditioningParametersMenuItem,
            this.triggerModeMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(217, 202);
            // 
            // toranceMonitorMenuItem
            // 
            this.toranceMonitorMenuItem.Name = "toranceMonitorMenuItem";
            this.toranceMonitorMenuItem.Size = new System.Drawing.Size(216, 22);
            this.toranceMonitorMenuItem.Text = "ToleranceMonitor";
            this.toranceMonitorMenuItem.Click += new System.EventHandler(this.toranceMonitorMenuItem_Click);
            // 
            // mDACMenuItem
            // 
            this.mDACMenuItem.Name = "mDACMenuItem";
            this.mDACMenuItem.Size = new System.Drawing.Size(216, 22);
            this.mDACMenuItem.Text = "MDAC";
            this.mDACMenuItem.Click += new System.EventHandler(this.mDACMenuItem_Click);
            // 
            // dACMenuItem
            // 
            this.dACMenuItem.Name = "dACMenuItem";
            this.dACMenuItem.Size = new System.Drawing.Size(216, 22);
            this.dACMenuItem.Text = "DAC/GCG";
            this.dACMenuItem.Click += new System.EventHandler(this.dACMenuItem_Click);
            // 
            // materialVelocityMenuItem
            // 
            this.materialVelocityMenuItem.Name = "materialVelocityMenuItem";
            this.materialVelocityMenuItem.Size = new System.Drawing.Size(216, 22);
            this.materialVelocityMenuItem.Text = "MaterialVelocity";
            this.materialVelocityMenuItem.Click += new System.EventHandler(this.materialVelocityMenuItem_Click);
            // 
            // probeDelayMenuItem
            // 
            this.probeDelayMenuItem.Name = "probeDelayMenuItem";
            this.probeDelayMenuItem.Size = new System.Drawing.Size(216, 22);
            this.probeDelayMenuItem.Text = "ProbeDelay";
            this.probeDelayMenuItem.Click += new System.EventHandler(this.probeDelayMenuItem_Click);
            // 
            // focusRuleMenuItem
            // 
            this.focusRuleMenuItem.Name = "focusRuleMenuItem";
            this.focusRuleMenuItem.Size = new System.Drawing.Size(216, 22);
            this.focusRuleMenuItem.Text = "FocusRule";
            this.focusRuleMenuItem.Click += new System.EventHandler(this.focusRuleMenuItem_Click);
            // 
            // launchParametersMenuItem
            // 
            this.launchParametersMenuItem.Name = "launchParametersMenuItem";
            this.launchParametersMenuItem.Size = new System.Drawing.Size(216, 22);
            this.launchParametersMenuItem.Text = "LaunchParameters";
            this.launchParametersMenuItem.Click += new System.EventHandler(this.launchParametersMenuItem_Click);
            // 
            // conditioningParametersMenuItem
            // 
            this.conditioningParametersMenuItem.Name = "conditioningParametersMenuItem";
            this.conditioningParametersMenuItem.Size = new System.Drawing.Size(216, 22);
            this.conditioningParametersMenuItem.Text = "ConditioningParameters";
            this.conditioningParametersMenuItem.Click += new System.EventHandler(this.conditioningParametersMenuItem_Click);
            // 
            // triggerModeMenuItem
            // 
            this.triggerModeMenuItem.Name = "triggerModeMenuItem";
            this.triggerModeMenuItem.Size = new System.Drawing.Size(216, 22);
            this.triggerModeMenuItem.Text = "TriggerMode";
            this.triggerModeMenuItem.Click += new System.EventHandler(this.triggerModeMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxGain, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.label17, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxMagnify, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.NumUpDownRange, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDelay, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelRange, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.NumUpDownDelay, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label15, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMagnify, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelReceiver, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbReceiver, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_freeze, 11, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 533);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 11);
            this.panel1.Controls.Add(this.tChart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 496);
            this.panel1.TabIndex = 10;
            // 
            // labelReceiver
            // 
            this.labelReceiver.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelReceiver.Location = new System.Drawing.Point(460, 511);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(57, 12);
            this.labelReceiver.TabIndex = 12;
            this.labelReceiver.Text = "接收模式";
            // 
            // cmbReceiver
            // 
            this.cmbReceiver.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReceiver.FormattingEnabled = true;
            this.cmbReceiver.Items.AddRange(new object[] {
            "RF",
            "全波",
            "正半波",
            "负半波"});
            this.cmbReceiver.Location = new System.Drawing.Point(523, 507);
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.Size = new System.Drawing.Size(64, 20);
            this.cmbReceiver.TabIndex = 11;
            this.cmbReceiver.Tag = "4";
            this.cmbReceiver.SelectedIndexChanged += new System.EventHandler(this.cmbReceiver_SelectedIndexChanged);
            // 
            // MDIChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 533);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MDIChild";
            this.Text = "MDIChild";
            this.Load += new System.EventHandler(this.MDIChild_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownDelay)).EndInit();
            this.groupBoxGain.ResumeLayout(false);
            this.groupBoxGain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGain)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxGain;
        private System.Windows.Forms.TrackBar TrackBarGain;
        private System.Windows.Forms.TextBox TextBoxGain;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelDelay;
        private Steema.TeeChart.Styles.Line GateA;
        private Steema.TeeChart.Styles.Line GateB;
        private Steema.TeeChart.Styles.Line GateC;
        private Steema.TeeChart.Tools.DragPoint GateIDragPoint;
        private Steema.TeeChart.Tools.DragPoint GateADragPoint;
        private Steema.TeeChart.Tools.DragPoint GateBDragPoint;
        private Steema.TeeChart.Tools.DragPoint GateCDragPoint;
        private Steema.TeeChart.Styles.Line MaxUp;
        private Steema.TeeChart.Styles.Line MaxDown;
        private Steema.TeeChart.Styles.Line General;
        private Steema.TeeChart.Styles.Line DACPoint;
        private Steema.TeeChart.Styles.Line DACLine;
        private Steema.TeeChart.Styles.Line TCG;
        private Steema.TeeChart.Styles.Line MDAC1;
        private Steema.TeeChart.Styles.Line MDAC2;
        private Steema.TeeChart.Styles.Line MDAC3;
        private Steema.TeeChart.Styles.Line MDAC4;
        public Steema.TeeChart.TChart tChart;
        private Steema.TeeChart.Styles.Line GateI;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toranceMonitorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dACMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialVelocityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem probeDelayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mDACMenuItem;
        private System.Windows.Forms.ComboBox comboBoxMagnify;
        private System.Windows.Forms.Label labelMagnify;
        private System.Windows.Forms.ToolStripMenuItem focusRuleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchParametersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conditioningParametersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triggerModeMenuItem;
        private Steema.TeeChart.Tools.MarksTip marksTip1;
        private System.Windows.Forms.Button btn_freeze;
        public System.Windows.Forms.NumericUpDown NumUpDownRange;
        public System.Windows.Forms.NumericUpDown NumUpDownDelay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbReceiver;
        private System.Windows.Forms.Label labelReceiver;
    }
}