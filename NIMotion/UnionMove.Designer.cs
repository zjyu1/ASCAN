namespace NIMotion
{
    partial class UnionMove
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.nudZd = new System.Windows.Forms.NumericUpDown();
            this.nudZv = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudYd = new System.Windows.Forms.NumericUpDown();
            this.nudYv = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudXd = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudXv = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBscan = new System.Windows.Forms.Button();
            this.btnCscan = new System.Windows.Forms.Button();
            this.btnCTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnMove);
            this.groupBox1.Controls.Add(this.btnZero);
            this.groupBox1.Controls.Add(this.nudZd);
            this.groupBox1.Controls.Add(this.nudZv);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudYd);
            this.groupBox1.Controls.Add(this.nudYv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudXd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudXv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motion";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(167, 131);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 23);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(94, 132);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(50, 23);
            this.btnMove.TabIndex = 12;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(19, 131);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(50, 23);
            this.btnZero.TabIndex = 11;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // nudZd
            // 
            this.nudZd.DecimalPlaces = 2;
            this.nudZd.Location = new System.Drawing.Point(139, 96);
            this.nudZd.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudZd.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.nudZd.Name = "nudZd";
            this.nudZd.Size = new System.Drawing.Size(78, 21);
            this.nudZd.TabIndex = 10;
            this.nudZd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudZv
            // 
            this.nudZv.DecimalPlaces = 2;
            this.nudZv.Location = new System.Drawing.Point(35, 95);
            this.nudZv.Name = "nudZv";
            this.nudZv.Size = new System.Drawing.Size(78, 21);
            this.nudZv.TabIndex = 9;
            this.nudZv.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Z";
            // 
            // nudYd
            // 
            this.nudYd.DecimalPlaces = 2;
            this.nudYd.Location = new System.Drawing.Point(139, 67);
            this.nudYd.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudYd.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.nudYd.Name = "nudYd";
            this.nudYd.Size = new System.Drawing.Size(78, 21);
            this.nudYd.TabIndex = 7;
            this.nudYd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudYv
            // 
            this.nudYv.DecimalPlaces = 2;
            this.nudYv.Location = new System.Drawing.Point(35, 66);
            this.nudYv.Name = "nudYv";
            this.nudYv.Size = new System.Drawing.Size(78, 21);
            this.nudYv.TabIndex = 6;
            this.nudYv.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "D(mm)";
            // 
            // nudXd
            // 
            this.nudXd.DecimalPlaces = 2;
            this.nudXd.Location = new System.Drawing.Point(139, 35);
            this.nudXd.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudXd.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            -2147483648});
            this.nudXd.Name = "nudXd";
            this.nudXd.Size = new System.Drawing.Size(78, 21);
            this.nudXd.TabIndex = 3;
            this.nudXd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "V(mm/s)";
            // 
            // nudXv
            // 
            this.nudXv.DecimalPlaces = 2;
            this.nudXv.Location = new System.Drawing.Point(35, 35);
            this.nudXv.Name = "nudXv";
            this.nudXv.Size = new System.Drawing.Size(78, 21);
            this.nudXv.TabIndex = 1;
            this.nudXv.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // btnBscan
            // 
            this.btnBscan.Location = new System.Drawing.Point(31, 201);
            this.btnBscan.Name = "btnBscan";
            this.btnBscan.Size = new System.Drawing.Size(50, 23);
            this.btnBscan.TabIndex = 14;
            this.btnBscan.Text = "Bscan";
            this.btnBscan.UseVisualStyleBackColor = true;
            this.btnBscan.Click += new System.EventHandler(this.btnBscan_Click);
            // 
            // btnCscan
            // 
            this.btnCscan.Location = new System.Drawing.Point(106, 201);
            this.btnCscan.Name = "btnCscan";
            this.btnCscan.Size = new System.Drawing.Size(50, 23);
            this.btnCscan.TabIndex = 15;
            this.btnCscan.Text = "Cscan";
            this.btnCscan.UseVisualStyleBackColor = true;
            this.btnCscan.Click += new System.EventHandler(this.btnCscan_Click);
            // 
            // btnCTest
            // 
            this.btnCTest.Location = new System.Drawing.Point(165, 201);
            this.btnCTest.Name = "btnCTest";
            this.btnCTest.Size = new System.Drawing.Size(83, 23);
            this.btnCTest.TabIndex = 16;
            this.btnCTest.Text = "C扫一行测试";
            this.btnCTest.UseVisualStyleBackColor = true;
            this.btnCTest.Click += new System.EventHandler(this.btnCTest_Click);
            // 
            // UnionMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 236);
            this.Controls.Add(this.btnCTest);
            this.Controls.Add(this.btnCscan);
            this.Controls.Add(this.btnBscan);
            this.Controls.Add(this.groupBox1);
            this.Name = "UnionMove";
            this.Text = "UnionMotion";
            this.Load += new System.EventHandler(this.UnionMove_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.NumericUpDown nudZd;
        private System.Windows.Forms.NumericUpDown nudZv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudYd;
        private System.Windows.Forms.NumericUpDown nudYv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudXd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudXv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBscan;
        private System.Windows.Forms.Button btnCscan;
        private System.Windows.Forms.Button btnCTest;
    }
}

