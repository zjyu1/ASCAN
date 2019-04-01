namespace Ascan
{
    partial class FormLaunchParameters
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
            this.grpLaunchEnable = new System.Windows.Forms.GroupBox();
            this.rdoOFF = new System.Windows.Forms.RadioButton();
            this.rdoON = new System.Windows.Forms.RadioButton();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPulseWidth = new System.Windows.Forms.TextBox();
            this.labelPulseWidth = new System.Windows.Forms.Label();
            this.textBoxTimeDelay = new System.Windows.Forms.TextBox();
            this.labelTimeDelay = new System.Windows.Forms.Label();
            this.grpTransmitVoltage = new System.Windows.Forms.GroupBox();
            this.rdo400 = new System.Windows.Forms.RadioButton();
            this.rdo100 = new System.Windows.Forms.RadioButton();
            this.grpImpedanceMatch = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxImpedance = new System.Windows.Forms.TextBox();
            this.labelImpedance = new System.Windows.Forms.Label();
            this.chkImpedanceMatch = new System.Windows.Forms.CheckBox();
            this.groupBoxTransmission = new System.Windows.Forms.GroupBox();
            this.RadioButtonReflection = new System.Windows.Forms.RadioButton();
            this.RadioButtonThrough = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grpLaunchEnable.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.grpTransmitVoltage.SuspendLayout();
            this.grpImpedanceMatch.SuspendLayout();
            this.groupBoxTransmission.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLaunchEnable
            // 
            this.grpLaunchEnable.Controls.Add(this.rdoOFF);
            this.grpLaunchEnable.Controls.Add(this.rdoON);
            this.grpLaunchEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLaunchEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpLaunchEnable.Location = new System.Drawing.Point(3, 83);
            this.grpLaunchEnable.Name = "grpLaunchEnable";
            this.grpLaunchEnable.Size = new System.Drawing.Size(227, 74);
            this.grpLaunchEnable.TabIndex = 0;
            this.grpLaunchEnable.TabStop = false;
            this.grpLaunchEnable.Text = "LaunchEnable";
            // 
            // rdoOFF
            // 
            this.rdoOFF.AutoSize = true;
            this.rdoOFF.Location = new System.Drawing.Point(128, 27);
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
            this.rdoON.Location = new System.Drawing.Point(13, 27);
            this.rdoON.Name = "rdoON";
            this.rdoON.Size = new System.Drawing.Size(46, 21);
            this.rdoON.TabIndex = 0;
            this.rdoON.TabStop = true;
            this.rdoON.Text = "ON";
            this.rdoON.UseVisualStyleBackColor = true;
            this.rdoON.Click += new System.EventHandler(this.rdoON_Click);
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.label3);
            this.grpTime.Controls.Add(this.label2);
            this.grpTime.Controls.Add(this.textBoxPulseWidth);
            this.grpTime.Controls.Add(this.labelPulseWidth);
            this.grpTime.Controls.Add(this.textBoxTimeDelay);
            this.grpTime.Controls.Add(this.labelTimeDelay);
            this.grpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpTime.Location = new System.Drawing.Point(3, 163);
            this.grpTime.Name = "grpTime";
            this.grpTime.Size = new System.Drawing.Size(227, 114);
            this.grpTime.TabIndex = 1;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "ns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "ns";
            // 
            // textBoxPulseWidth
            // 
            this.textBoxPulseWidth.Location = new System.Drawing.Point(87, 63);
            this.textBoxPulseWidth.Name = "textBoxPulseWidth";
            this.textBoxPulseWidth.Size = new System.Drawing.Size(100, 23);
            this.textBoxPulseWidth.TabIndex = 3;
            this.textBoxPulseWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPulseWidth_KeyPress);
            // 
            // labelPulseWidth
            // 
            this.labelPulseWidth.AutoSize = true;
            this.labelPulseWidth.Location = new System.Drawing.Point(9, 66);
            this.labelPulseWidth.Name = "labelPulseWidth";
            this.labelPulseWidth.Size = new System.Drawing.Size(72, 17);
            this.labelPulseWidth.TabIndex = 2;
            this.labelPulseWidth.Text = "PulseWidth";
            // 
            // textBoxTimeDelay
            // 
            this.textBoxTimeDelay.Location = new System.Drawing.Point(87, 26);
            this.textBoxTimeDelay.Name = "textBoxTimeDelay";
            this.textBoxTimeDelay.Size = new System.Drawing.Size(100, 23);
            this.textBoxTimeDelay.TabIndex = 1;
            this.textBoxTimeDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTimeDelay_KeyPress);
            // 
            // labelTimeDelay
            // 
            this.labelTimeDelay.AutoSize = true;
            this.labelTimeDelay.Location = new System.Drawing.Point(10, 29);
            this.labelTimeDelay.Name = "labelTimeDelay";
            this.labelTimeDelay.Size = new System.Drawing.Size(68, 17);
            this.labelTimeDelay.TabIndex = 0;
            this.labelTimeDelay.Text = "TimeDelay";
            // 
            // grpTransmitVoltage
            // 
            this.grpTransmitVoltage.Controls.Add(this.rdo400);
            this.grpTransmitVoltage.Controls.Add(this.rdo100);
            this.grpTransmitVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransmitVoltage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpTransmitVoltage.Location = new System.Drawing.Point(3, 283);
            this.grpTransmitVoltage.Name = "grpTransmitVoltage";
            this.grpTransmitVoltage.Size = new System.Drawing.Size(227, 74);
            this.grpTransmitVoltage.TabIndex = 2;
            this.grpTransmitVoltage.TabStop = false;
            this.grpTransmitVoltage.Text = " TransmitVoltage ";
            // 
            // rdo400
            // 
            this.rdo400.AutoSize = true;
            this.rdo400.Location = new System.Drawing.Point(139, 27);
            this.rdo400.Name = "rdo400";
            this.rdo400.Size = new System.Drawing.Size(55, 21);
            this.rdo400.TabIndex = 2;
            this.rdo400.TabStop = true;
            this.rdo400.Text = "400V";
            this.rdo400.UseVisualStyleBackColor = true;
            this.rdo400.Click += new System.EventHandler(this.rdo400_Click);
            // 
            // rdo100
            // 
            this.rdo100.AutoSize = true;
            this.rdo100.Location = new System.Drawing.Point(13, 27);
            this.rdo100.Name = "rdo100";
            this.rdo100.Size = new System.Drawing.Size(55, 21);
            this.rdo100.TabIndex = 1;
            this.rdo100.TabStop = true;
            this.rdo100.Text = "100V";
            this.rdo100.UseVisualStyleBackColor = true;
            this.rdo100.Click += new System.EventHandler(this.rdo100_Click);
            // 
            // grpImpedanceMatch
            // 
            this.grpImpedanceMatch.Controls.Add(this.label5);
            this.grpImpedanceMatch.Controls.Add(this.textBoxImpedance);
            this.grpImpedanceMatch.Controls.Add(this.labelImpedance);
            this.grpImpedanceMatch.Controls.Add(this.chkImpedanceMatch);
            this.grpImpedanceMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImpedanceMatch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpImpedanceMatch.Location = new System.Drawing.Point(3, 363);
            this.grpImpedanceMatch.Name = "grpImpedanceMatch";
            this.grpImpedanceMatch.Size = new System.Drawing.Size(227, 114);
            this.grpImpedanceMatch.TabIndex = 3;
            this.grpImpedanceMatch.TabStop = false;
            this.grpImpedanceMatch.Text = " ImpedanceMatch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ω";
            // 
            // textBoxImpedance
            // 
            this.textBoxImpedance.Location = new System.Drawing.Point(87, 52);
            this.textBoxImpedance.Name = "textBoxImpedance";
            this.textBoxImpedance.Size = new System.Drawing.Size(100, 23);
            this.textBoxImpedance.TabIndex = 4;
            this.textBoxImpedance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxImpedance_KeyPress);
            // 
            // labelImpedance
            // 
            this.labelImpedance.AutoSize = true;
            this.labelImpedance.Location = new System.Drawing.Point(12, 55);
            this.labelImpedance.Name = "labelImpedance";
            this.labelImpedance.Size = new System.Drawing.Size(73, 17);
            this.labelImpedance.TabIndex = 3;
            this.labelImpedance.Text = "Impedance";
            // 
            // chkImpedanceMatch
            // 
            this.chkImpedanceMatch.AutoSize = true;
            this.chkImpedanceMatch.Location = new System.Drawing.Point(13, 26);
            this.chkImpedanceMatch.Name = "chkImpedanceMatch";
            this.chkImpedanceMatch.Size = new System.Drawing.Size(132, 21);
            this.chkImpedanceMatch.TabIndex = 0;
            this.chkImpedanceMatch.Text = " ImpedanceMatch";
            this.chkImpedanceMatch.UseVisualStyleBackColor = true;
            this.chkImpedanceMatch.Click += new System.EventHandler(this.chkImpedanceMatch_Click);
            // 
            // groupBoxTransmission
            // 
            this.groupBoxTransmission.Controls.Add(this.RadioButtonReflection);
            this.groupBoxTransmission.Controls.Add(this.RadioButtonThrough);
            this.groupBoxTransmission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTransmission.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBoxTransmission.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTransmission.Name = "groupBoxTransmission";
            this.groupBoxTransmission.Size = new System.Drawing.Size(227, 74);
            this.groupBoxTransmission.TabIndex = 17;
            this.groupBoxTransmission.TabStop = false;
            this.groupBoxTransmission.Text = "Transmission";
            // 
            // RadioButtonReflection
            // 
            this.RadioButtonReflection.AutoSize = true;
            this.RadioButtonReflection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RadioButtonReflection.Location = new System.Drawing.Point(128, 25);
            this.RadioButtonReflection.Name = "RadioButtonReflection";
            this.RadioButtonReflection.Size = new System.Drawing.Size(83, 21);
            this.RadioButtonReflection.TabIndex = 1;
            this.RadioButtonReflection.Text = "Reflection";
            this.RadioButtonReflection.UseVisualStyleBackColor = true;
            this.RadioButtonReflection.Click += new System.EventHandler(this.RadioButtonReflection_Click);
            // 
            // RadioButtonThrough
            // 
            this.RadioButtonThrough.AutoSize = true;
            this.RadioButtonThrough.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RadioButtonThrough.Location = new System.Drawing.Point(7, 25);
            this.RadioButtonThrough.Name = "RadioButtonThrough";
            this.RadioButtonThrough.Size = new System.Drawing.Size(75, 21);
            this.RadioButtonThrough.TabIndex = 0;
            this.RadioButtonThrough.Text = "Through";
            this.RadioButtonThrough.UseVisualStyleBackColor = true;
            this.RadioButtonThrough.Click += new System.EventHandler(this.RadioButtonThrough_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grpImpedanceMatch, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.grpLaunchEnable, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.grpTransmitVoltage, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.grpTime, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxTransmission, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(233, 457);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // FormLaunchParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 457);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FormLaunchParameters";
            this.Text = "LaunchParameters";
            this.Load += new System.EventHandler(this.FormLaunchParameters_Load);
            this.grpLaunchEnable.ResumeLayout(false);
            this.grpLaunchEnable.PerformLayout();
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.grpTransmitVoltage.ResumeLayout(false);
            this.grpTransmitVoltage.PerformLayout();
            this.grpImpedanceMatch.ResumeLayout(false);
            this.grpImpedanceMatch.PerformLayout();
            this.groupBoxTransmission.ResumeLayout(false);
            this.groupBoxTransmission.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLaunchEnable;
        private System.Windows.Forms.RadioButton rdoOFF;
        private System.Windows.Forms.RadioButton rdoON;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPulseWidth;
        private System.Windows.Forms.Label labelPulseWidth;
        private System.Windows.Forms.TextBox textBoxTimeDelay;
        private System.Windows.Forms.Label labelTimeDelay;
        private System.Windows.Forms.GroupBox grpTransmitVoltage;
        private System.Windows.Forms.RadioButton rdo400;
        private System.Windows.Forms.RadioButton rdo100;
        private System.Windows.Forms.GroupBox grpImpedanceMatch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxImpedance;
        private System.Windows.Forms.Label labelImpedance;
        private System.Windows.Forms.CheckBox chkImpedanceMatch;
        private System.Windows.Forms.GroupBox groupBoxTransmission;
        public System.Windows.Forms.RadioButton RadioButtonReflection;
        public System.Windows.Forms.RadioButton RadioButtonThrough;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}