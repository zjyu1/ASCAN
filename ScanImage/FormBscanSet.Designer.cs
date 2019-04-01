namespace ScanImage
{
    partial class FormBscanSet
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
            this.labelScanAxis = new System.Windows.Forms.Label();
            this.cmbScanAxis = new System.Windows.Forms.ComboBox();
            this.labelScanLength = new System.Windows.Forms.Label();
            this.txtScanLength = new System.Windows.Forms.TextBox();
            this.labelResolution = new System.Windows.Forms.Label();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelSelectGate = new System.Windows.Forms.Label();
            this.cmbSelectGate = new System.Windows.Forms.ComboBox();
            this.labelSessionName = new System.Windows.Forms.Label();
            this.txtSessionName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.pathTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelScanAxis
            // 
            this.labelScanAxis.AutoSize = true;
            this.labelScanAxis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScanAxis.Location = new System.Drawing.Point(8, 93);
            this.labelScanAxis.Name = "labelScanAxis";
            this.labelScanAxis.Size = new System.Drawing.Size(58, 17);
            this.labelScanAxis.TabIndex = 0;
            this.labelScanAxis.Text = "ScanAxis";
            // 
            // cmbScanAxis
            // 
            this.cmbScanAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanAxis.FormattingEnabled = true;
            this.cmbScanAxis.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.cmbScanAxis.Location = new System.Drawing.Point(98, 90);
            this.cmbScanAxis.Name = "cmbScanAxis";
            this.cmbScanAxis.Size = new System.Drawing.Size(88, 25);
            this.cmbScanAxis.TabIndex = 1;
            // 
            // labelScanLength
            // 
            this.labelScanLength.AutoSize = true;
            this.labelScanLength.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScanLength.Location = new System.Drawing.Point(8, 127);
            this.labelScanLength.Name = "labelScanLength";
            this.labelScanLength.Size = new System.Drawing.Size(74, 17);
            this.labelScanLength.TabIndex = 2;
            this.labelScanLength.Text = "ScanLength";
            // 
            // txtScanLength
            // 
            this.txtScanLength.Location = new System.Drawing.Point(98, 127);
            this.txtScanLength.Name = "txtScanLength";
            this.txtScanLength.Size = new System.Drawing.Size(88, 23);
            this.txtScanLength.TabIndex = 3;
            this.txtScanLength.Text = "100";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelResolution.Location = new System.Drawing.Point(7, 161);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(69, 17);
            this.labelResolution.TabIndex = 4;
            this.labelResolution.Text = "Resolution";
            // 
            // txtResolution
            // 
            this.txtResolution.Location = new System.Drawing.Point(98, 161);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(88, 23);
            this.txtResolution.TabIndex = 5;
            this.txtResolution.Text = "1";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(140, 312);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(62, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelSelectGate
            // 
            this.labelSelectGate.AutoSize = true;
            this.labelSelectGate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelectGate.Location = new System.Drawing.Point(7, 55);
            this.labelSelectGate.Name = "labelSelectGate";
            this.labelSelectGate.Size = new System.Drawing.Size(69, 17);
            this.labelSelectGate.TabIndex = 9;
            this.labelSelectGate.Text = "SelectGate";
            // 
            // cmbSelectGate
            // 
            this.cmbSelectGate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectGate.FormattingEnabled = true;
            this.cmbSelectGate.Items.AddRange(new object[] {
            "B"});
            this.cmbSelectGate.Location = new System.Drawing.Point(98, 55);
            this.cmbSelectGate.Name = "cmbSelectGate";
            this.cmbSelectGate.Size = new System.Drawing.Size(88, 25);
            this.cmbSelectGate.TabIndex = 10;
            // 
            // labelSessionName
            // 
            this.labelSessionName.AutoSize = true;
            this.labelSessionName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSessionName.Location = new System.Drawing.Point(8, 24);
            this.labelSessionName.Name = "labelSessionName";
            this.labelSessionName.Size = new System.Drawing.Size(87, 17);
            this.labelSessionName.TabIndex = 11;
            this.labelSessionName.Text = "SessionName";
            // 
            // txtSessionName
            // 
            this.txtSessionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSessionName.Location = new System.Drawing.Point(98, 24);
            this.txtSessionName.Name = "txtSessionName";
            this.txtSessionName.Size = new System.Drawing.Size(88, 23);
            this.txtSessionName.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSessionName);
            this.groupBox1.Controls.Add(this.txtSessionName);
            this.groupBox1.Controls.Add(this.labelScanAxis);
            this.groupBox1.Controls.Add(this.cmbScanAxis);
            this.groupBox1.Controls.Add(this.cmbSelectGate);
            this.groupBox1.Controls.Add(this.labelScanLength);
            this.groupBox1.Controls.Add(this.labelSelectGate);
            this.groupBox1.Controls.Add(this.txtScanLength);
            this.groupBox1.Controls.Add(this.labelResolution);
            this.groupBox1.Controls.Add(this.txtResolution);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 200);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox);
            this.groupBox2.Controls.Add(this.pathTxtBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(4, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 90);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data save";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(11, 26);
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
            this.pathTxtBox.Location = new System.Drawing.Point(47, 52);
            this.pathTxtBox.Name = "pathTxtBox";
            this.pathTxtBox.Size = new System.Drawing.Size(139, 23);
            this.pathTxtBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path";
            // 
            // FormBscanSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormBscanSet";
            this.Text = "FormBscanSet";
            this.Load += new System.EventHandler(this.FormBscanSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelScanAxis;
        private System.Windows.Forms.ComboBox cmbScanAxis;
        private System.Windows.Forms.Label labelScanLength;
        private System.Windows.Forms.TextBox txtScanLength;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.TextBox txtResolution;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelSelectGate;
        private System.Windows.Forms.ComboBox cmbSelectGate;
        private System.Windows.Forms.Label labelSessionName;
        private System.Windows.Forms.TextBox txtSessionName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TextBox pathTxtBox;
        private System.Windows.Forms.Label label1;
    }
}