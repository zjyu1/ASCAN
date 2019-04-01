namespace NIMotion
{
    partial class CscanMotion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.nudYRange = new System.Windows.Forms.NumericUpDown();
            this.nudXRange = new System.Windows.Forms.NumericUpDown();
            this.nudStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbScanAxis = new System.Windows.Forms.ComboBox();
            this.labelScanAxis = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudSpeed);
            this.groupBox1.Controls.Add(this.nudYRange);
            this.groupBox1.Controls.Add(this.nudXRange);
            this.groupBox1.Controls.Add(this.nudStep);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbScanAxis);
            this.groupBox1.Controls.Add(this.labelScanAxis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motion";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(18, 196);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(173, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(173, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "mm/s";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(173, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(173, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "mm";
            // 
            // nudSpeed
            // 
            this.nudSpeed.DecimalPlaces = 2;
            this.nudSpeed.Location = new System.Drawing.Point(79, 123);
            this.nudSpeed.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
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
            // nudYRange
            // 
            this.nudYRange.DecimalPlaces = 2;
            this.nudYRange.Location = new System.Drawing.Point(79, 93);
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
            // nudXRange
            // 
            this.nudXRange.DecimalPlaces = 2;
            this.nudXRange.Location = new System.Drawing.Point(79, 63);
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
            // nudStep
            // 
            this.nudStep.DecimalPlaces = 2;
            this.nudStep.Location = new System.Drawing.Point(79, 157);
            this.nudStep.Name = "nudStep";
            this.nudStep.Size = new System.Drawing.Size(88, 21);
            this.nudStep.TabIndex = 8;
            this.nudStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(15, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Step";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "YRange";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "XRange";
            // 
            // cmbScanAxis
            // 
            this.cmbScanAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanAxis.FormattingEnabled = true;
            this.cmbScanAxis.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.cmbScanAxis.Location = new System.Drawing.Point(79, 26);
            this.cmbScanAxis.Name = "cmbScanAxis";
            this.cmbScanAxis.Size = new System.Drawing.Size(88, 20);
            this.cmbScanAxis.TabIndex = 3;
            // 
            // labelScanAxis
            // 
            this.labelScanAxis.AutoSize = true;
            this.labelScanAxis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScanAxis.Location = new System.Drawing.Point(15, 26);
            this.labelScanAxis.Name = "labelScanAxis";
            this.labelScanAxis.Size = new System.Drawing.Size(58, 17);
            this.labelScanAxis.TabIndex = 2;
            this.labelScanAxis.Text = "ScanAxis";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(148, 197);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 23);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // CscanMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 243);
            this.Controls.Add(this.groupBox1);
            this.Name = "CscanMotion";
            this.Text = "CscanMotion";
            this.Load += new System.EventHandler(this.CscanMotion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbScanAxis;
        private System.Windows.Forms.Label labelScanAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.NumericUpDown nudYRange;
        private System.Windows.Forms.NumericUpDown nudXRange;
        private System.Windows.Forms.NumericUpDown nudStep;
        private System.Windows.Forms.Button btnStop;
    }
}