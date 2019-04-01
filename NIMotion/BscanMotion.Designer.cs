namespace NIMotion
{
    partial class BscanMotion
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudRange = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudVelocity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAxis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudRange);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudVelocity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbAxis);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motion";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(14, 124);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(65, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "mm/s";
            // 
            // nudRange
            // 
            this.nudRange.DecimalPlaces = 2;
            this.nudRange.Location = new System.Drawing.Point(71, 92);
            this.nudRange.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRange.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudRange.Name = "nudRange";
            this.nudRange.Size = new System.Drawing.Size(84, 21);
            this.nudRange.TabIndex = 5;
            this.nudRange.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Range";
            // 
            // nudVelocity
            // 
            this.nudVelocity.DecimalPlaces = 2;
            this.nudVelocity.Location = new System.Drawing.Point(71, 54);
            this.nudVelocity.Name = "nudVelocity";
            this.nudVelocity.Size = new System.Drawing.Size(84, 21);
            this.nudVelocity.TabIndex = 3;
            this.nudVelocity.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Velocity";
            // 
            // cmbAxis
            // 
            this.cmbAxis.FormattingEnabled = true;
            this.cmbAxis.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.cmbAxis.Location = new System.Drawing.Point(71, 20);
            this.cmbAxis.Name = "cmbAxis";
            this.cmbAxis.Size = new System.Drawing.Size(84, 20);
            this.cmbAxis.TabIndex = 1;
            this.cmbAxis.SelectedIndexChanged += new System.EventHandler(this.cmbAxis_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Axis";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(121, 124);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // BscanMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 175);
            this.Controls.Add(this.groupBox1);
            this.Name = "BscanMotion";
            this.Text = "BscanMotion";
            this.Load += new System.EventHandler(this.BscanMotion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVelocity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAxis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudVelocity;
        private System.Windows.Forms.Button btnStop;

    }
}