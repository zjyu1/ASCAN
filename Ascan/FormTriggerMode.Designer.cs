namespace Ascan
{
    partial class FormTriggerMode
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
            this.grpTriggerMode = new System.Windows.Forms.GroupBox();
            this.rdoOutsideTrigger = new System.Windows.Forms.RadioButton();
            this.rdoSoftwareTrigger = new System.Windows.Forms.RadioButton();
            this.rdoEncoderTrigger = new System.Windows.Forms.RadioButton();
            this.rdoPositionTrigger = new System.Windows.Forms.RadioButton();
            this.rdoStarSlotTrigger = new System.Windows.Forms.RadioButton();
            this.grpPulseRepetitionFreq = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrf = new System.Windows.Forms.TextBox();
            this.labelPrf = new System.Windows.Forms.Label();
            this.grpTriggerMode.SuspendLayout();
            this.grpPulseRepetitionFreq.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTriggerMode
            // 
            this.grpTriggerMode.Controls.Add(this.rdoOutsideTrigger);
            this.grpTriggerMode.Controls.Add(this.rdoSoftwareTrigger);
            this.grpTriggerMode.Controls.Add(this.rdoEncoderTrigger);
            this.grpTriggerMode.Controls.Add(this.rdoPositionTrigger);
            this.grpTriggerMode.Controls.Add(this.rdoStarSlotTrigger);
            this.grpTriggerMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpTriggerMode.Location = new System.Drawing.Point(3, 3);
            this.grpTriggerMode.Name = "grpTriggerMode";
            this.grpTriggerMode.Size = new System.Drawing.Size(280, 109);
            this.grpTriggerMode.TabIndex = 0;
            this.grpTriggerMode.TabStop = false;
            this.grpTriggerMode.Text = "TriggerMode";
            // 
            // rdoOutsideTrigger
            // 
            this.rdoOutsideTrigger.AutoSize = true;
            this.rdoOutsideTrigger.Location = new System.Drawing.Point(9, 76);
            this.rdoOutsideTrigger.Name = "rdoOutsideTrigger";
            this.rdoOutsideTrigger.Size = new System.Drawing.Size(114, 21);
            this.rdoOutsideTrigger.TabIndex = 4;
            this.rdoOutsideTrigger.TabStop = true;
            this.rdoOutsideTrigger.Text = "OutsideTrigger";
            this.rdoOutsideTrigger.UseVisualStyleBackColor = true;
            this.rdoOutsideTrigger.Click += new System.EventHandler(this.rdoOutsideTrigger_Click);
            // 
            // rdoSoftwareTrigger
            // 
            this.rdoSoftwareTrigger.AutoSize = true;
            this.rdoSoftwareTrigger.Location = new System.Drawing.Point(154, 49);
            this.rdoSoftwareTrigger.Name = "rdoSoftwareTrigger";
            this.rdoSoftwareTrigger.Size = new System.Drawing.Size(120, 21);
            this.rdoSoftwareTrigger.TabIndex = 3;
            this.rdoSoftwareTrigger.TabStop = true;
            this.rdoSoftwareTrigger.Text = "SoftwareTrigger";
            this.rdoSoftwareTrigger.UseVisualStyleBackColor = true;
            this.rdoSoftwareTrigger.Click += new System.EventHandler(this.rdoSoftwareTrigger_Click);
            // 
            // rdoEncoderTrigger
            // 
            this.rdoEncoderTrigger.AutoSize = true;
            this.rdoEncoderTrigger.Location = new System.Drawing.Point(9, 49);
            this.rdoEncoderTrigger.Name = "rdoEncoderTrigger";
            this.rdoEncoderTrigger.Size = new System.Drawing.Size(117, 21);
            this.rdoEncoderTrigger.TabIndex = 2;
            this.rdoEncoderTrigger.TabStop = true;
            this.rdoEncoderTrigger.Text = "EncoderTrigger";
            this.rdoEncoderTrigger.UseVisualStyleBackColor = true;
            this.rdoEncoderTrigger.Click += new System.EventHandler(this.rdoEncoderTrigger_Click);
            // 
            // rdoPositionTrigger
            // 
            this.rdoPositionTrigger.AutoSize = true;
            this.rdoPositionTrigger.Location = new System.Drawing.Point(154, 22);
            this.rdoPositionTrigger.Name = "rdoPositionTrigger";
            this.rdoPositionTrigger.Size = new System.Drawing.Size(115, 21);
            this.rdoPositionTrigger.TabIndex = 1;
            this.rdoPositionTrigger.TabStop = true;
            this.rdoPositionTrigger.Text = "PositionTrigger";
            this.rdoPositionTrigger.UseVisualStyleBackColor = true;
            this.rdoPositionTrigger.Click += new System.EventHandler(this.rdommTrigger_Click);            // 
            // rdoStarSlotTrigger
            // 
            this.rdoStarSlotTrigger.AutoSize = true;
            this.rdoStarSlotTrigger.Location = new System.Drawing.Point(9, 22);
            this.rdoStarSlotTrigger.Name = "rdoStarSlotTrigger";
            this.rdoStarSlotTrigger.Size = new System.Drawing.Size(114, 21);
            this.rdoStarSlotTrigger.TabIndex = 0;
            this.rdoStarSlotTrigger.TabStop = true;
            this.rdoStarSlotTrigger.Text = "StarSlotTrigger";
            this.rdoStarSlotTrigger.UseVisualStyleBackColor = true;
            this.rdoStarSlotTrigger.Click += new System.EventHandler(this.rdoStarSlotTrigger_Click);
            // 
            // grpPulseRepetitionFreq
            // 
            this.grpPulseRepetitionFreq.Controls.Add(this.label2);
            this.grpPulseRepetitionFreq.Controls.Add(this.textBoxPrf);
            this.grpPulseRepetitionFreq.Controls.Add(this.labelPrf);
            this.grpPulseRepetitionFreq.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpPulseRepetitionFreq.Location = new System.Drawing.Point(3, 118);
            this.grpPulseRepetitionFreq.Name = "grpPulseRepetitionFreq";
            this.grpPulseRepetitionFreq.Size = new System.Drawing.Size(280, 62);
            this.grpPulseRepetitionFreq.TabIndex = 1;
            this.grpPulseRepetitionFreq.TabStop = false;
            this.grpPulseRepetitionFreq.Text = "PulseRepetitionFrequency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hz";
            // 
            // textBoxPrf
            // 
            this.textBoxPrf.Location = new System.Drawing.Point(54, 25);
            this.textBoxPrf.Name = "textBoxPrf";
            this.textBoxPrf.Size = new System.Drawing.Size(100, 23);
            this.textBoxPrf.TabIndex = 1;
            this.textBoxPrf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrf_KeyPress);
            this.textBoxPrf.Leave += new System.EventHandler(this.textBoxPrf_Leave);
            // 
            // labelPrf
            // 
            this.labelPrf.AutoSize = true;
            this.labelPrf.Location = new System.Drawing.Point(9, 28);
            this.labelPrf.Name = "labelPrf";
            this.labelPrf.Size = new System.Drawing.Size(29, 17);
            this.labelPrf.TabIndex = 0;
            this.labelPrf.Text = "PRF";
            // 
            // FormTriggerMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 182);
            this.Controls.Add(this.grpPulseRepetitionFreq);
            this.Controls.Add(this.grpTriggerMode);
            this.Name = "FormTriggerMode";
            this.Text = "TriggerMode";
            this.Load += new System.EventHandler(this.FormTriggerMode_Load);
            this.grpTriggerMode.ResumeLayout(false);
            this.grpTriggerMode.PerformLayout();
            this.grpPulseRepetitionFreq.ResumeLayout(false);
            this.grpPulseRepetitionFreq.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTriggerMode;
        private System.Windows.Forms.RadioButton rdoOutsideTrigger;
        private System.Windows.Forms.RadioButton rdoSoftwareTrigger;
        private System.Windows.Forms.RadioButton rdoEncoderTrigger;
        private System.Windows.Forms.RadioButton rdoPositionTrigger;
        private System.Windows.Forms.RadioButton rdoStarSlotTrigger;
        private System.Windows.Forms.GroupBox grpPulseRepetitionFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrf;
        private System.Windows.Forms.Label labelPrf;
    }
}