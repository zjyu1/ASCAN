namespace NI_Motion_test
{
    partial class NMC_Test
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_move = new System.Windows.Forms.Button();
            this.btn_zero = new System.Windows.Forms.Button();
            this.zDistance = new System.Windows.Forms.NumericUpDown();
            this.zSpeed = new System.Windows.Forms.NumericUpDown();
            this.yDistance = new System.Windows.Forms.NumericUpDown();
            this.ySpeed = new System.Windows.Forms.NumericUpDown();
            this.xDistance = new System.Windows.Forms.NumericUpDown();
            this.xSpeed = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.zPos = new System.Windows.Forms.TextBox();
            this.yPos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.xPos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Cscan_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelScanAxis = new System.Windows.Forms.Label();
            this.cmbScanAxis = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.nudStep = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.nudXRange = new System.Windows.Forms.NumericUpDown();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.nudYRange = new System.Windows.Forms.NumericUpDown();
            this.btn_sigstop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSpeed)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYRange)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "V(mm/s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "D(mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Z";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Controls.Add(this.btn_move);
            this.groupBox1.Controls.Add(this.btn_zero);
            this.groupBox1.Controls.Add(this.zDistance);
            this.groupBox1.Controls.Add(this.zSpeed);
            this.groupBox1.Controls.Add(this.yDistance);
            this.groupBox1.Controls.Add(this.ySpeed);
            this.groupBox1.Controls.Add(this.xDistance);
            this.groupBox1.Controls.Add(this.xSpeed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 174);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motion";
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(178, 145);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(53, 23);
            this.btn_stop.TabIndex = 13;
            this.btn_stop.Text = "stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_move
            // 
            this.btn_move.Location = new System.Drawing.Point(98, 145);
            this.btn_move.Name = "btn_move";
            this.btn_move.Size = new System.Drawing.Size(53, 23);
            this.btn_move.TabIndex = 12;
            this.btn_move.Text = "move";
            this.btn_move.UseVisualStyleBackColor = true;
            this.btn_move.Click += new System.EventHandler(this.btn_move_Click);
            // 
            // btn_zero
            // 
            this.btn_zero.Location = new System.Drawing.Point(18, 145);
            this.btn_zero.Name = "btn_zero";
            this.btn_zero.Size = new System.Drawing.Size(53, 23);
            this.btn_zero.TabIndex = 11;
            this.btn_zero.Text = "zero";
            this.btn_zero.UseVisualStyleBackColor = true;
            this.btn_zero.Click += new System.EventHandler(this.btn_zero_Click);
            // 
            // zDistance
            // 
            this.zDistance.DecimalPlaces = 2;
            this.zDistance.Location = new System.Drawing.Point(144, 111);
            this.zDistance.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.zDistance.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.zDistance.Name = "zDistance";
            this.zDistance.Size = new System.Drawing.Size(87, 21);
            this.zDistance.TabIndex = 10;
            // 
            // zSpeed
            // 
            this.zSpeed.DecimalPlaces = 2;
            this.zSpeed.Location = new System.Drawing.Point(44, 111);
            this.zSpeed.Name = "zSpeed";
            this.zSpeed.Size = new System.Drawing.Size(87, 21);
            this.zSpeed.TabIndex = 9;
            this.zSpeed.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // yDistance
            // 
            this.yDistance.DecimalPlaces = 2;
            this.yDistance.Location = new System.Drawing.Point(144, 77);
            this.yDistance.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.yDistance.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.yDistance.Name = "yDistance";
            this.yDistance.Size = new System.Drawing.Size(87, 21);
            this.yDistance.TabIndex = 8;
            // 
            // ySpeed
            // 
            this.ySpeed.DecimalPlaces = 2;
            this.ySpeed.Location = new System.Drawing.Point(44, 77);
            this.ySpeed.Name = "ySpeed";
            this.ySpeed.Size = new System.Drawing.Size(87, 21);
            this.ySpeed.TabIndex = 7;
            this.ySpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // xDistance
            // 
            this.xDistance.DecimalPlaces = 2;
            this.xDistance.Location = new System.Drawing.Point(144, 43);
            this.xDistance.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.xDistance.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.xDistance.Name = "xDistance";
            this.xDistance.Size = new System.Drawing.Size(87, 21);
            this.xDistance.TabIndex = 6;
            // 
            // xSpeed
            // 
            this.xSpeed.DecimalPlaces = 2;
            this.xSpeed.Location = new System.Drawing.Point(44, 43);
            this.xSpeed.Name = "xSpeed";
            this.xSpeed.Size = new System.Drawing.Size(87, 21);
            this.xSpeed.TabIndex = 5;
            this.xSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_sigstop);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.zPos);
            this.groupBox2.Controls.Add(this.yPos);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.xPos);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(263, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 173);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Position";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "mm";
            // 
            // zPos
            // 
            this.zPos.Location = new System.Drawing.Point(47, 110);
            this.zPos.Name = "zPos";
            this.zPos.ReadOnly = true;
            this.zPos.Size = new System.Drawing.Size(71, 21);
            this.zPos.TabIndex = 12;
            this.zPos.Text = "0";
            // 
            // yPos
            // 
            this.yPos.Location = new System.Drawing.Point(47, 76);
            this.yPos.Name = "yPos";
            this.yPos.ReadOnly = true;
            this.yPos.Size = new System.Drawing.Size(71, 21);
            this.yPos.TabIndex = 9;
            this.yPos.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "mm";
            // 
            // xPos
            // 
            this.xPos.Location = new System.Drawing.Point(47, 42);
            this.xPos.Name = "xPos";
            this.xPos.ReadOnly = true;
            this.xPos.Size = new System.Drawing.Size(71, 21);
            this.xPos.TabIndex = 8;
            this.xPos.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "Z";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "X";
            // 
            // Cscan_btn
            // 
            this.Cscan_btn.Location = new System.Drawing.Point(283, 27);
            this.Cscan_btn.Name = "Cscan_btn";
            this.Cscan_btn.Size = new System.Drawing.Size(75, 23);
            this.Cscan_btn.TabIndex = 8;
            this.Cscan_btn.Text = "Cscan";
            this.Cscan_btn.UseVisualStyleBackColor = true;
            this.Cscan_btn.Click += new System.EventHandler(this.Cscan_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelScanAxis);
            this.groupBox3.Controls.Add(this.Cscan_btn);
            this.groupBox3.Controls.Add(this.cmbScanAxis);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.nudStep);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.nudXRange);
            this.groupBox3.Controls.Add(this.nudSpeed);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.nudYRange);
            this.groupBox3.Location = new System.Drawing.Point(12, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(417, 134);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cscan";
            // 
            // labelScanAxis
            // 
            this.labelScanAxis.AutoSize = true;
            this.labelScanAxis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScanAxis.Location = new System.Drawing.Point(15, 29);
            this.labelScanAxis.Name = "labelScanAxis";
            this.labelScanAxis.Size = new System.Drawing.Size(58, 17);
            this.labelScanAxis.TabIndex = 2;
            this.labelScanAxis.Text = "ScanAxis";
            // 
            // cmbScanAxis
            // 
            this.cmbScanAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanAxis.FormattingEnabled = true;
            this.cmbScanAxis.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.cmbScanAxis.Location = new System.Drawing.Point(79, 29);
            this.cmbScanAxis.Name = "cmbScanAxis";
            this.cmbScanAxis.Size = new System.Drawing.Size(88, 20);
            this.cmbScanAxis.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(366, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 17);
            this.label12.TabIndex = 15;
            this.label12.Text = "mm";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(14, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 17);
            this.label19.TabIndex = 4;
            this.label19.Text = "XRange";
            // 
            // nudStep
            // 
            this.nudStep.DecimalPlaces = 2;
            this.nudStep.Location = new System.Drawing.Point(270, 104);
            this.nudStep.Name = "nudStep";
            this.nudStep.Size = new System.Drawing.Size(88, 21);
            this.nudStep.TabIndex = 8;
            this.nudStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(366, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "mm/s";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(211, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 17);
            this.label16.TabIndex = 7;
            this.label16.Text = "Step";
            // 
            // nudXRange
            // 
            this.nudXRange.DecimalPlaces = 2;
            this.nudXRange.Location = new System.Drawing.Point(79, 66);
            this.nudXRange.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudXRange.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.nudXRange.Name = "nudXRange";
            this.nudXRange.Size = new System.Drawing.Size(88, 21);
            this.nudXRange.TabIndex = 9;
            this.nudXRange.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudSpeed
            // 
            this.nudSpeed.DecimalPlaces = 2;
            this.nudSpeed.Location = new System.Drawing.Point(270, 66);
            this.nudSpeed.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(88, 21);
            this.nudSpeed.TabIndex = 11;
            this.nudSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(175, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 17);
            this.label14.TabIndex = 13;
            this.label14.Text = "mm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(174, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 17);
            this.label15.TabIndex = 12;
            this.label15.Text = "mm";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(14, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 17);
            this.label18.TabIndex = 5;
            this.label18.Text = "YRange";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(209, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 6;
            this.label17.Text = "Speed";
            // 
            // nudYRange
            // 
            this.nudYRange.DecimalPlaces = 2;
            this.nudYRange.Location = new System.Drawing.Point(79, 103);
            this.nudYRange.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudYRange.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.nudYRange.Name = "nudYRange";
            this.nudYRange.Size = new System.Drawing.Size(88, 21);
            this.nudYRange.TabIndex = 10;
            this.nudYRange.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btn_sigstop
            // 
            this.btn_sigstop.Location = new System.Drawing.Point(47, 145);
            this.btn_sigstop.Name = "btn_sigstop";
            this.btn_sigstop.Size = new System.Drawing.Size(75, 23);
            this.btn_sigstop.TabIndex = 15;
            this.btn_sigstop.Text = "stop";
            this.btn_sigstop.UseVisualStyleBackColor = true;
            this.btn_sigstop.Click += new System.EventHandler(this.btn_sigstop_Click);
            // 
            // NMC_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 338);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NMC_Test";
            this.Text = "NMC_Test";
            this.Load += new System.EventHandler(this.NMC_Test_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xSpeed)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYRange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_move;
        private System.Windows.Forms.Button btn_zero;
        private System.Windows.Forms.NumericUpDown zDistance;
        private System.Windows.Forms.NumericUpDown zSpeed;
        private System.Windows.Forms.NumericUpDown yDistance;
        private System.Windows.Forms.NumericUpDown ySpeed;
        private System.Windows.Forms.NumericUpDown xDistance;
        private System.Windows.Forms.NumericUpDown xSpeed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox zPos;
        private System.Windows.Forms.TextBox yPos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox xPos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Cscan_btn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.NumericUpDown nudYRange;
        private System.Windows.Forms.NumericUpDown nudXRange;
        private System.Windows.Forms.NumericUpDown nudStep;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbScanAxis;
        private System.Windows.Forms.Label labelScanAxis;
        private System.Windows.Forms.Button btn_sigstop;
    }
}

