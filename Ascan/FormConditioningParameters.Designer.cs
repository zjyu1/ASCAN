namespace Ascan
{
    partial class FormConditioningParameters
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
            this.grpReceiveEnable = new System.Windows.Forms.GroupBox();
            this.rdoOFF = new System.Windows.Forms.RadioButton();
            this.rdoON = new System.Windows.Forms.RadioButton();
            this.grpAnalogFilter = new System.Windows.Forms.GroupBox();
            this.cboALPF = new System.Windows.Forms.ComboBox();
            this.labelLpCutOffFreq = new System.Windows.Forms.Label();
            this.cboAHPF = new System.Windows.Forms.ComboBox();
            this.labelHpCutOffFreq = new System.Windows.Forms.Label();
            this.grpDigitalFilter = new System.Windows.Forms.GroupBox();
            this.cboDLPF = new System.Windows.Forms.ComboBox();
            this.labelLpCutOffFreq1 = new System.Windows.Forms.Label();
            this.cboDHPF = new System.Windows.Forms.ComboBox();
            this.labelHpCutOffFreq1 = new System.Windows.Forms.Label();
            this.grpReceivePath = new System.Windows.Forms.GroupBox();
            this.rdoTransmitVoltageAcquisition = new System.Windows.Forms.RadioButton();
            this.rdoTestInput = new System.Windows.Forms.RadioButton();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.grpImpedanceMatch = new System.Windows.Forms.GroupBox();
            this.chkImpedanceMatch = new System.Windows.Forms.CheckBox();
            this.labelImpedance = new System.Windows.Forms.Label();
            this.textBoxImpedance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpReceiveEnable.SuspendLayout();
            this.grpAnalogFilter.SuspendLayout();
            this.grpDigitalFilter.SuspendLayout();
            this.grpReceivePath.SuspendLayout();
            this.grpImpedanceMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReceiveEnable
            // 
            this.grpReceiveEnable.Controls.Add(this.rdoOFF);
            this.grpReceiveEnable.Controls.Add(this.rdoON);
            this.grpReceiveEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpReceiveEnable.Location = new System.Drawing.Point(2, 12);
            this.grpReceiveEnable.Name = "grpReceiveEnable";
            this.grpReceiveEnable.Size = new System.Drawing.Size(280, 53);
            this.grpReceiveEnable.TabIndex = 0;
            this.grpReceiveEnable.TabStop = false;
            this.grpReceiveEnable.Text = "ReceiveEnable";
            // 
            // rdoOFF
            // 
            this.rdoOFF.AutoSize = true;
            this.rdoOFF.Location = new System.Drawing.Point(144, 23);
            this.rdoOFF.Name = "rdoOFF";
            this.rdoOFF.Size = new System.Drawing.Size(48, 21);
            this.rdoOFF.TabIndex = 1;
            this.rdoOFF.TabStop = true;
            this.rdoOFF.Text = "OFF";
            this.rdoOFF.UseVisualStyleBackColor = true;
            this.rdoOFF.Click += new System.EventHandler(this.rdoOFF_Click);
            // 
            // rdoON
            // 
            this.rdoON.AutoSize = true;
            this.rdoON.Location = new System.Drawing.Point(11, 23);
            this.rdoON.Name = "rdoON";
            this.rdoON.Size = new System.Drawing.Size(46, 21);
            this.rdoON.TabIndex = 0;
            this.rdoON.TabStop = true;
            this.rdoON.Text = "ON";
            this.rdoON.UseVisualStyleBackColor = true;
            this.rdoON.Click += new System.EventHandler(this.rdoON_Click);
            // 
            // grpAnalogFilter
            // 
            this.grpAnalogFilter.Controls.Add(this.cboALPF);
            this.grpAnalogFilter.Controls.Add(this.labelLpCutOffFreq);
            this.grpAnalogFilter.Controls.Add(this.cboAHPF);
            this.grpAnalogFilter.Controls.Add(this.labelHpCutOffFreq);
            this.grpAnalogFilter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpAnalogFilter.Location = new System.Drawing.Point(2, 71);
            this.grpAnalogFilter.Name = "grpAnalogFilter";
            this.grpAnalogFilter.Size = new System.Drawing.Size(280, 94);
            this.grpAnalogFilter.TabIndex = 1;
            this.grpAnalogFilter.TabStop = false;
            this.grpAnalogFilter.Text = "AnalogFilter";
            // 
            // cboALPF
            // 
            this.cboALPF.FormattingEnabled = true;
            this.cboALPF.Items.AddRange(new object[] {
            "0HZ",
            "0.5MHZ",
            "1MHZ",
            "1.5MHZ",
            "2MHZ",
            "2.5MHZ",
            "3MHZ",
            "3.5MHZ",
            "4MHZ",
            "4.5MHZ",
            "5MHZ",
            "5.5MHZ",
            "6MHZ",
            "6.5MHZ",
            "7MHZ",
            "7.5MHZ",
            "8MHZ",
            "8.5MHZ",
            "9MHZ",
            "9.5MHZ",
            "10MHZ",
            "10.5MHZ",
            "11MHZ",
            "11.5MHZ",
            "12MHZ",
            "12.5MHZ",
            "13MHZ",
            "13.5MHZ",
            "14MHZ",
            "14.5MHZ",
            "15MHZ",
            "15.5MHZ",
            "16MHZ",
            "16.5MHZ",
            "17MHZ",
            "17.5MHZ",
            "18MHZ",
            "18.5MHZ",
            "19MHZ",
            "19.5MHZ",
            "20MHZ",
            "20.5MHZ",
            "21MHZ",
            "21.5MHZ",
            "22MHZ",
            "22.5MHZ",
            "23MHZ",
            "23.5MHZ",
            "24MHZ",
            "24.5MHZ",
            "25MHZ"});
            this.cboALPF.Location = new System.Drawing.Point(173, 57);
            this.cboALPF.Name = "cboALPF";
            this.cboALPF.Size = new System.Drawing.Size(97, 25);
            this.cboALPF.TabIndex = 3;
            this.cboALPF.SelectedIndexChanged += new System.EventHandler(this.cboALPF_SelectedIndexChanged);
            // 
            // labelLpCutOffFreq
            // 
            this.labelLpCutOffFreq.AutoSize = true;
            this.labelLpCutOffFreq.Location = new System.Drawing.Point(10, 60);
            this.labelLpCutOffFreq.Name = "labelLpCutOffFreq";
            this.labelLpCutOffFreq.Size = new System.Drawing.Size(153, 17);
            this.labelLpCutOffFreq.TabIndex = 2;
            this.labelLpCutOffFreq.Text = "LowPassCutOffFrequency";
            // 
            // cboAHPF
            // 
            this.cboAHPF.FormattingEnabled = true;
            this.cboAHPF.Items.AddRange(new object[] {
            "0HZ",
            "0.5MHZ",
            "1MHZ",
            "1.5MHZ",
            "2MHZ",
            "2.5MHZ",
            "3MHZ",
            "3.5MHZ",
            "4MHZ",
            "4.5MHZ",
            "5MHZ",
            "5.5MHZ",
            "6MHZ",
            "6.5MHZ",
            "7MHZ",
            "7.5MHZ",
            "8MHZ",
            "8.5MHZ",
            "9MHZ",
            "9.5MHZ",
            "10MHZ",
            "10.5MHZ",
            "11MHZ",
            "11.5MHZ",
            "12MHZ",
            "12.5MHZ",
            "13MHZ",
            "13.5MHZ",
            "14MHZ",
            "14.5MHZ",
            "15MHZ",
            "15.5MHZ",
            "16MHZ",
            "16.5MHZ",
            "17MHZ",
            "17.5MHZ",
            "18MHZ",
            "18.5MHZ",
            "19MHZ",
            "19.5MHZ",
            "20MHZ",
            "20.5MHZ",
            "21MHZ",
            "21.5MHZ",
            "22MHZ",
            "22.5MHZ",
            "23MHZ",
            "23.5MHZ",
            "24MHZ",
            "24.5MHZ",
            "25MHZ"});
            this.cboAHPF.Location = new System.Drawing.Point(173, 25);
            this.cboAHPF.Name = "cboAHPF";
            this.cboAHPF.Size = new System.Drawing.Size(97, 25);
            this.cboAHPF.TabIndex = 1;
            this.cboAHPF.SelectedIndexChanged += new System.EventHandler(this.cboAHPF_SelectedIndexChanged);
            // 
            // labelHpCutOffFreq
            // 
            this.labelHpCutOffFreq.AutoSize = true;
            this.labelHpCutOffFreq.Location = new System.Drawing.Point(10, 28);
            this.labelHpCutOffFreq.Name = "labelHpCutOffFreq";
            this.labelHpCutOffFreq.Size = new System.Drawing.Size(157, 17);
            this.labelHpCutOffFreq.TabIndex = 0;
            this.labelHpCutOffFreq.Text = "HighPassCutOffFrequency";
            // 
            // grpDigitalFilter
            // 
            this.grpDigitalFilter.Controls.Add(this.cboDLPF);
            this.grpDigitalFilter.Controls.Add(this.labelLpCutOffFreq1);
            this.grpDigitalFilter.Controls.Add(this.cboDHPF);
            this.grpDigitalFilter.Controls.Add(this.labelHpCutOffFreq1);
            this.grpDigitalFilter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpDigitalFilter.Location = new System.Drawing.Point(2, 171);
            this.grpDigitalFilter.Name = "grpDigitalFilter";
            this.grpDigitalFilter.Size = new System.Drawing.Size(280, 91);
            this.grpDigitalFilter.TabIndex = 2;
            this.grpDigitalFilter.TabStop = false;
            this.grpDigitalFilter.Text = "DigitalFilter";
            // 
            // cboDLPF
            // 
            this.cboDLPF.FormattingEnabled = true;
            this.cboDLPF.Items.AddRange(new object[] {
            "0HZ",
            "0.5MHZ",
            "1MHZ",
            "1.5MHZ",
            "2MHZ",
            "2.5MHZ",
            "3MHZ",
            "3.5MHZ",
            "4MHZ",
            "4.5MHZ",
            "5MHZ",
            "5.5MHZ",
            "6MHZ",
            "6.5MHZ",
            "7MHZ",
            "7.5MHZ",
            "8MHZ",
            "8.5MHZ",
            "9MHZ",
            "9.5MHZ",
            "10MHZ",
            "10.5MHZ",
            "11MHZ",
            "11.5MHZ",
            "12MHZ",
            "12.5MHZ",
            "13MHZ",
            "13.5MHZ",
            "14MHZ",
            "14.5MHZ",
            "15MHZ",
            "15.5MHZ",
            "16MHZ",
            "16.5MHZ",
            "17MHZ",
            "17.5MHZ",
            "18MHZ",
            "18.5MHZ",
            "19MHZ",
            "19.5MHZ",
            "20MHZ",
            "20.5MHZ",
            "21MHZ",
            "21.5MHZ",
            "22MHZ",
            "22.5MHZ",
            "23MHZ",
            "23.5MHZ",
            "24MHZ",
            "24.5MHZ",
            "25MHZ"});
            this.cboDLPF.Location = new System.Drawing.Point(173, 55);
            this.cboDLPF.Name = "cboDLPF";
            this.cboDLPF.Size = new System.Drawing.Size(97, 25);
            this.cboDLPF.TabIndex = 7;
            this.cboDLPF.SelectedIndexChanged += new System.EventHandler(this.cboDLPF_SelectedIndexChanged);
            // 
            // labelLpCutOffFreq1
            // 
            this.labelLpCutOffFreq1.AutoSize = true;
            this.labelLpCutOffFreq1.Location = new System.Drawing.Point(8, 58);
            this.labelLpCutOffFreq1.Name = "labelLpCutOffFreq1";
            this.labelLpCutOffFreq1.Size = new System.Drawing.Size(153, 17);
            this.labelLpCutOffFreq1.TabIndex = 6;
            this.labelLpCutOffFreq1.Text = "LowPassCutOffFrequency";
            // 
            // cboDHPF
            // 
            this.cboDHPF.FormattingEnabled = true;
            this.cboDHPF.Items.AddRange(new object[] {
            "0HZ",
            "0.5MHZ",
            "1MHZ",
            "1.5MHZ",
            "2MHZ",
            "2.5MHZ",
            "3MHZ",
            "3.5MHZ",
            "4MHZ",
            "4.5MHZ",
            "5MHZ",
            "5.5MHZ",
            "6MHZ",
            "6.5MHZ",
            "7MHZ",
            "7.5MHZ",
            "8MHZ",
            "8.5MHZ",
            "9MHZ",
            "9.5MHZ",
            "10MHZ",
            "10.5MHZ",
            "11MHZ",
            "11.5MHZ",
            "12MHZ",
            "12.5MHZ",
            "13MHZ",
            "13.5MHZ",
            "14MHZ",
            "14.5MHZ",
            "15MHZ",
            "15.5MHZ",
            "16MHZ",
            "16.5MHZ",
            "17MHZ",
            "17.5MHZ",
            "18MHZ",
            "18.5MHZ",
            "19MHZ",
            "19.5MHZ",
            "20MHZ",
            "20.5MHZ",
            "21MHZ",
            "21.5MHZ",
            "22MHZ",
            "22.5MHZ",
            "23MHZ",
            "23.5MHZ",
            "24MHZ",
            "24.5MHZ",
            "25MHZ"});
            this.cboDHPF.Location = new System.Drawing.Point(173, 22);
            this.cboDHPF.Name = "cboDHPF";
            this.cboDHPF.Size = new System.Drawing.Size(97, 25);
            this.cboDHPF.TabIndex = 5;
            this.cboDHPF.SelectedIndexChanged += new System.EventHandler(this.cboDHPF_SelectedIndexChanged);
            // 
            // labelHpCutOffFreq1
            // 
            this.labelHpCutOffFreq1.AutoSize = true;
            this.labelHpCutOffFreq1.Location = new System.Drawing.Point(10, 25);
            this.labelHpCutOffFreq1.Name = "labelHpCutOffFreq1";
            this.labelHpCutOffFreq1.Size = new System.Drawing.Size(157, 17);
            this.labelHpCutOffFreq1.TabIndex = 4;
            this.labelHpCutOffFreq1.Text = "HighPassCutOffFrequency";
            // 
            // grpReceivePath
            // 
            this.grpReceivePath.Controls.Add(this.rdoTransmitVoltageAcquisition);
            this.grpReceivePath.Controls.Add(this.rdoTestInput);
            this.grpReceivePath.Controls.Add(this.rdoNormal);
            this.grpReceivePath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpReceivePath.Location = new System.Drawing.Point(2, 268);
            this.grpReceivePath.Name = "grpReceivePath";
            this.grpReceivePath.Size = new System.Drawing.Size(280, 85);
            this.grpReceivePath.TabIndex = 3;
            this.grpReceivePath.TabStop = false;
            this.grpReceivePath.Text = "ReceivePath";
            // 
            // rdoTransmitVoltageAcquisition
            // 
            this.rdoTransmitVoltageAcquisition.AutoSize = true;
            this.rdoTransmitVoltageAcquisition.Location = new System.Drawing.Point(13, 51);
            this.rdoTransmitVoltageAcquisition.Name = "rdoTransmitVoltageAcquisition";
            this.rdoTransmitVoltageAcquisition.Size = new System.Drawing.Size(184, 21);
            this.rdoTransmitVoltageAcquisition.TabIndex = 2;
            this.rdoTransmitVoltageAcquisition.TabStop = true;
            this.rdoTransmitVoltageAcquisition.Text = "TransmitVoltageAcquisition";
            this.rdoTransmitVoltageAcquisition.UseVisualStyleBackColor = true;
            this.rdoTransmitVoltageAcquisition.Click += new System.EventHandler(this.rdoTransmitVoltageAcquisition_Click);
            // 
            // rdoTestInput
            // 
            this.rdoTestInput.AutoSize = true;
            this.rdoTestInput.Location = new System.Drawing.Point(144, 22);
            this.rdoTestInput.Name = "rdoTestInput";
            this.rdoTestInput.Size = new System.Drawing.Size(80, 21);
            this.rdoTestInput.TabIndex = 1;
            this.rdoTestInput.TabStop = true;
            this.rdoTestInput.Text = "TestInput";
            this.rdoTestInput.UseVisualStyleBackColor = true;
            this.rdoTestInput.Click += new System.EventHandler(this.rdoTestInput_Click);
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Location = new System.Drawing.Point(11, 23);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(70, 21);
            this.rdoNormal.TabIndex = 0;
            this.rdoNormal.TabStop = true;
            this.rdoNormal.Text = "Normal";
            this.rdoNormal.UseVisualStyleBackColor = true;
            this.rdoNormal.Click += new System.EventHandler(this.rdoNormal_Click);
            // 
            // grpImpedanceMatch
            // 
            this.grpImpedanceMatch.Controls.Add(this.label5);
            this.grpImpedanceMatch.Controls.Add(this.textBoxImpedance);
            this.grpImpedanceMatch.Controls.Add(this.labelImpedance);
            this.grpImpedanceMatch.Controls.Add(this.chkImpedanceMatch);
            this.grpImpedanceMatch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpImpedanceMatch.Location = new System.Drawing.Point(2, 360);
            this.grpImpedanceMatch.Name = "grpImpedanceMatch";
            this.grpImpedanceMatch.Size = new System.Drawing.Size(280, 77);
            this.grpImpedanceMatch.TabIndex = 4;
            this.grpImpedanceMatch.TabStop = false;
            this.grpImpedanceMatch.Text = "ImpedanceMatch";
            // 
            // chkImpedanceMatch
            // 
            this.chkImpedanceMatch.AutoSize = true;
            this.chkImpedanceMatch.Location = new System.Drawing.Point(11, 23);
            this.chkImpedanceMatch.Name = "chkImpedanceMatch";
            this.chkImpedanceMatch.Size = new System.Drawing.Size(128, 21);
            this.chkImpedanceMatch.TabIndex = 0;
            this.chkImpedanceMatch.Text = "ImpedanceMatch";
            this.chkImpedanceMatch.UseVisualStyleBackColor = true;
            this.chkImpedanceMatch.Click += new System.EventHandler(this.chkImpedanceMatch_Click);
            // 
            // labelImpedance
            // 
            this.labelImpedance.AutoSize = true;
            this.labelImpedance.Location = new System.Drawing.Point(6, 47);
            this.labelImpedance.Name = "labelImpedance";
            this.labelImpedance.Size = new System.Drawing.Size(73, 17);
            this.labelImpedance.TabIndex = 4;
            this.labelImpedance.Text = "Impedance";
            // 
            // textBoxImpedance
            // 
            this.textBoxImpedance.Location = new System.Drawing.Point(85, 44);
            this.textBoxImpedance.Name = "textBoxImpedance";
            this.textBoxImpedance.Size = new System.Drawing.Size(100, 23);
            this.textBoxImpedance.TabIndex = 5;
            this.textBoxImpedance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxImpedance_KeyPress);
            this.textBoxImpedance.Leave += new System.EventHandler(this.textBoxImpedance_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ω";
            // 
            // FormConditioningParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 439);
            this.Controls.Add(this.grpImpedanceMatch);
            this.Controls.Add(this.grpReceivePath);
            this.Controls.Add(this.grpDigitalFilter);
            this.Controls.Add(this.grpAnalogFilter);
            this.Controls.Add(this.grpReceiveEnable);
            this.Name = "FormConditioningParameters";
            this.Text = "ConditioningParameters";
            this.Load += new System.EventHandler(this.FormConditioningParameters_Load);
            this.grpReceiveEnable.ResumeLayout(false);
            this.grpReceiveEnable.PerformLayout();
            this.grpAnalogFilter.ResumeLayout(false);
            this.grpAnalogFilter.PerformLayout();
            this.grpDigitalFilter.ResumeLayout(false);
            this.grpDigitalFilter.PerformLayout();
            this.grpReceivePath.ResumeLayout(false);
            this.grpReceivePath.PerformLayout();
            this.grpImpedanceMatch.ResumeLayout(false);
            this.grpImpedanceMatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReceiveEnable;
        private System.Windows.Forms.RadioButton rdoOFF;
        private System.Windows.Forms.RadioButton rdoON;
        private System.Windows.Forms.GroupBox grpAnalogFilter;
        private System.Windows.Forms.ComboBox cboALPF;
        private System.Windows.Forms.Label labelLpCutOffFreq;
        private System.Windows.Forms.ComboBox cboAHPF;
        private System.Windows.Forms.Label labelHpCutOffFreq;
        private System.Windows.Forms.GroupBox grpDigitalFilter;
        private System.Windows.Forms.ComboBox cboDLPF;
        private System.Windows.Forms.Label labelLpCutOffFreq1;
        private System.Windows.Forms.ComboBox cboDHPF;
        private System.Windows.Forms.Label labelHpCutOffFreq1;
        private System.Windows.Forms.GroupBox grpReceivePath;
        private System.Windows.Forms.RadioButton rdoTestInput;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.RadioButton rdoTransmitVoltageAcquisition;
        private System.Windows.Forms.GroupBox grpImpedanceMatch;
        private System.Windows.Forms.CheckBox chkImpedanceMatch;
        private System.Windows.Forms.Label labelImpedance;
        private System.Windows.Forms.TextBox textBoxImpedance;
        private System.Windows.Forms.Label label5;
    }
}