namespace ScanImage
{
    partial class FormCscanSet
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
            this.txtSessionName = new System.Windows.Forms.TextBox();
            this.labelSessionName = new System.Windows.Forms.Label();
            this.cmbSelectGate = new System.Windows.Forms.ComboBox();
            this.labelSelectGate = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.txtXResolution = new System.Windows.Forms.TextBox();
            this.labelResolutionX = new System.Windows.Forms.Label();
            this.txtXScanLength = new System.Windows.Forms.TextBox();
            this.labelScanLength = new System.Windows.Forms.Label();
            this.cmbScanAxis = new System.Windows.Forms.ComboBox();
            this.labelScanAxis = new System.Windows.Forms.Label();
            this.txtYScanLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYResolution = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.pathTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSessionName
            // 
            this.txtSessionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSessionName.Location = new System.Drawing.Point(107, 29);
            this.txtSessionName.Name = "txtSessionName";
            this.txtSessionName.Size = new System.Drawing.Size(88, 23);
            this.txtSessionName.TabIndex = 23;
            // 
            // labelSessionName
            // 
            this.labelSessionName.AutoSize = true;
            this.labelSessionName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSessionName.Location = new System.Drawing.Point(17, 29);
            this.labelSessionName.Name = "labelSessionName";
            this.labelSessionName.Size = new System.Drawing.Size(87, 17);
            this.labelSessionName.TabIndex = 22;
            this.labelSessionName.Text = "SessionName";
            // 
            // cmbSelectGate
            // 
            this.cmbSelectGate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectGate.FormattingEnabled = true;
            this.cmbSelectGate.Items.AddRange(new object[] {
            "I",
            "A",
            "B",
            "C"});
            this.cmbSelectGate.Location = new System.Drawing.Point(107, 60);
            this.cmbSelectGate.Name = "cmbSelectGate";
            this.cmbSelectGate.Size = new System.Drawing.Size(88, 25);
            this.cmbSelectGate.TabIndex = 21;
            this.cmbSelectGate.SelectedIndexChanged += new System.EventHandler(this.cmbSelectGate_SelectedIndexChanged);
            // 
            // labelSelectGate
            // 
            this.labelSelectGate.AutoSize = true;
            this.labelSelectGate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelectGate.Location = new System.Drawing.Point(16, 60);
            this.labelSelectGate.Name = "labelSelectGate";
            this.labelSelectGate.Size = new System.Drawing.Size(69, 17);
            this.labelSelectGate.TabIndex = 20;
            this.labelSelectGate.Text = "SelectGate";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(166, 375);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(62, 23);
            this.buttonOK.TabIndex = 19;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // txtXResolution
            // 
            this.txtXResolution.Location = new System.Drawing.Point(105, 191);
            this.txtXResolution.Name = "txtXResolution";
            this.txtXResolution.Size = new System.Drawing.Size(88, 23);
            this.txtXResolution.TabIndex = 18;
            this.txtXResolution.Text = "1";
            // 
            // labelResolutionX
            // 
            this.labelResolutionX.AutoSize = true;
            this.labelResolutionX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelResolutionX.Location = new System.Drawing.Point(17, 191);
            this.labelResolutionX.Name = "labelResolutionX";
            this.labelResolutionX.Size = new System.Drawing.Size(82, 17);
            this.labelResolutionX.TabIndex = 17;
            this.labelResolutionX.Text = "X-Resolution";
            // 
            // txtXScanLength
            // 
            this.txtXScanLength.Location = new System.Drawing.Point(106, 128);
            this.txtXScanLength.Name = "txtXScanLength";
            this.txtXScanLength.Size = new System.Drawing.Size(88, 23);
            this.txtXScanLength.TabIndex = 16;
            this.txtXScanLength.Text = "100";
            // 
            // labelScanLength
            // 
            this.labelScanLength.AutoSize = true;
            this.labelScanLength.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScanLength.Location = new System.Drawing.Point(16, 128);
            this.labelScanLength.Name = "labelScanLength";
            this.labelScanLength.Size = new System.Drawing.Size(87, 17);
            this.labelScanLength.TabIndex = 15;
            this.labelScanLength.Text = "X-ScanLength";
            // 
            // cmbScanAxis
            // 
            this.cmbScanAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanAxis.FormattingEnabled = true;
            this.cmbScanAxis.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.cmbScanAxis.Location = new System.Drawing.Point(107, 95);
            this.cmbScanAxis.Name = "cmbScanAxis";
            this.cmbScanAxis.Size = new System.Drawing.Size(88, 25);
            this.cmbScanAxis.TabIndex = 14;
            this.cmbScanAxis.SelectedIndexChanged += new System.EventHandler(this.cmbScanAxis_SelectedIndexChanged);
            // 
            // labelScanAxis
            // 
            this.labelScanAxis.AutoSize = true;
            this.labelScanAxis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScanAxis.Location = new System.Drawing.Point(17, 98);
            this.labelScanAxis.Name = "labelScanAxis";
            this.labelScanAxis.Size = new System.Drawing.Size(58, 17);
            this.labelScanAxis.TabIndex = 13;
            this.labelScanAxis.Text = "ScanAxis";
            // 
            // txtYScanLength
            // 
            this.txtYScanLength.Location = new System.Drawing.Point(105, 159);
            this.txtYScanLength.Name = "txtYScanLength";
            this.txtYScanLength.Size = new System.Drawing.Size(88, 23);
            this.txtYScanLength.TabIndex = 25;
            this.txtYScanLength.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Y-ScanLength";
            // 
            // txtYResolution
            // 
            this.txtYResolution.Location = new System.Drawing.Point(105, 221);
            this.txtYResolution.Name = "txtYResolution";
            this.txtYResolution.Size = new System.Drawing.Size(88, 23);
            this.txtYResolution.TabIndex = 27;
            this.txtYResolution.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Y-Resolution";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSessionName);
            this.groupBox1.Controls.Add(this.txtYResolution);
            this.groupBox1.Controls.Add(this.labelScanAxis);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbScanAxis);
            this.groupBox1.Controls.Add(this.txtYScanLength);
            this.groupBox1.Controls.Add(this.labelScanLength);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtXScanLength);
            this.groupBox1.Controls.Add(this.txtSessionName);
            this.groupBox1.Controls.Add(this.labelResolutionX);
            this.groupBox1.Controls.Add(this.txtXResolution);
            this.groupBox1.Controls.Add(this.cmbSelectGate);
            this.groupBox1.Controls.Add(this.labelSelectGate);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 263);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox);
            this.groupBox2.Controls.Add(this.pathTxtBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 90);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data save";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(17, 26);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(60, 21);
            this.checkBox.TabIndex = 14;
            this.checkBox.Text = "check";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // pathTxtBox
            // 
            this.pathTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTxtBox.Enabled = false;
            this.pathTxtBox.Location = new System.Drawing.Point(53, 52);
            this.pathTxtBox.Name = "pathTxtBox";
            this.pathTxtBox.Size = new System.Drawing.Size(139, 23);
            this.pathTxtBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path";
            // 
            // FormCscanSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormCscanSet";
            this.Text = "FormCscanSet";
            this.Load += new System.EventHandler(this.FormCscanSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSessionName;
        private System.Windows.Forms.Label labelSessionName;
        private System.Windows.Forms.ComboBox cmbSelectGate;
        private System.Windows.Forms.Label labelSelectGate;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox txtXResolution;
        private System.Windows.Forms.Label labelResolutionX;
        private System.Windows.Forms.TextBox txtXScanLength;
        private System.Windows.Forms.Label labelScanLength;
        private System.Windows.Forms.ComboBox cmbScanAxis;
        private System.Windows.Forms.Label labelScanAxis;
        private System.Windows.Forms.TextBox txtYScanLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TextBox pathTxtBox;
        private System.Windows.Forms.Label label3;
    }
}