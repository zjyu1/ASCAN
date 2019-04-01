namespace Ascan
{
    partial class FormGateSetting
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
            this.Gateinformation = new System.Windows.Forms.GroupBox();
            this.percent = new System.Windows.Forms.Label();
            this.after = new System.Windows.Forms.Label();
            this.before = new System.Windows.Forms.Label();
            this.gateb = new System.Windows.Forms.GroupBox();
            this.Bthreshold = new System.Windows.Forms.TextBox();
            this.Bafter = new System.Windows.Forms.TextBox();
            this.Bbefore = new System.Windows.Forms.TextBox();
            this.Threshold = new System.Windows.Forms.Label();
            this.gateafter = new System.Windows.Forms.Label();
            this.gatebefore = new System.Windows.Forms.Label();
            this.weldmode = new System.Windows.Forms.RadioButton();
            this.targetmode = new System.Windows.Forms.RadioButton();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.Gateinformation.SuspendLayout();
            this.gateb.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gateinformation
            // 
            this.Gateinformation.BackColor = System.Drawing.SystemColors.Control;
            this.Gateinformation.Controls.Add(this.percent);
            this.Gateinformation.Controls.Add(this.after);
            this.Gateinformation.Controls.Add(this.before);
            this.Gateinformation.Controls.Add(this.gateb);
            this.Gateinformation.Controls.Add(this.Threshold);
            this.Gateinformation.Controls.Add(this.gateafter);
            this.Gateinformation.Controls.Add(this.gatebefore);
            this.Gateinformation.Controls.Add(this.weldmode);
            this.Gateinformation.Controls.Add(this.targetmode);
            this.Gateinformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gateinformation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Gateinformation.Location = new System.Drawing.Point(0, 0);
            this.Gateinformation.Name = "Gateinformation";
            this.Gateinformation.Size = new System.Drawing.Size(331, 225);
            this.Gateinformation.TabIndex = 0;
            this.Gateinformation.TabStop = false;
            this.Gateinformation.Text = "Gate Information";
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.Location = new System.Drawing.Point(257, 167);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(11, 12);
            this.percent.TabIndex = 9;
            this.percent.Text = "%";
            // 
            // after
            // 
            this.after.AutoSize = true;
            this.after.Location = new System.Drawing.Point(257, 134);
            this.after.Name = "after";
            this.after.Size = new System.Drawing.Size(17, 12);
            this.after.TabIndex = 8;
            this.after.Text = "mm";
            // 
            // before
            // 
            this.before.AutoSize = true;
            this.before.Location = new System.Drawing.Point(257, 105);
            this.before.Name = "before";
            this.before.Size = new System.Drawing.Size(17, 12);
            this.before.TabIndex = 7;
            this.before.Text = "mm";
            // 
            // gateb
            // 
            this.gateb.Controls.Add(this.Bthreshold);
            this.gateb.Controls.Add(this.Bafter);
            this.gateb.Controls.Add(this.Bbefore);
            this.gateb.Location = new System.Drawing.Point(123, 86);
            this.gateb.Name = "gateb";
            this.gateb.Size = new System.Drawing.Size(115, 108);
            this.gateb.TabIndex = 6;
            this.gateb.TabStop = false;
            this.gateb.Text = "GateB";
            // 
            // Bthreshold
            // 
            this.Bthreshold.Location = new System.Drawing.Point(6, 81);
            this.Bthreshold.Name = "Bthreshold";
            this.Bthreshold.Size = new System.Drawing.Size(100, 21);
            this.Bthreshold.TabIndex = 2;
            // 
            // Bafter
            // 
            this.Bafter.Location = new System.Drawing.Point(6, 48);
            this.Bafter.Name = "Bafter";
            this.Bafter.Size = new System.Drawing.Size(100, 21);
            this.Bafter.TabIndex = 1;
            // 
            // Bbefore
            // 
            this.Bbefore.Location = new System.Drawing.Point(6, 19);
            this.Bbefore.Name = "Bbefore";
            this.Bbefore.Size = new System.Drawing.Size(100, 21);
            this.Bbefore.TabIndex = 0;
            // 
            // Threshold
            // 
            this.Threshold.AutoSize = true;
            this.Threshold.Location = new System.Drawing.Point(24, 167);
            this.Threshold.Name = "Threshold";
            this.Threshold.Size = new System.Drawing.Size(65, 12);
            this.Threshold.TabIndex = 4;
            this.Threshold.Text = "Threshold:";
            // 
            // gateafter
            // 
            this.gateafter.AutoSize = true;
            this.gateafter.Location = new System.Drawing.Point(24, 134);
            this.gateafter.Name = "gateafter";
            this.gateafter.Size = new System.Drawing.Size(71, 12);
            this.gateafter.TabIndex = 3;
            this.gateafter.Text = "Gate after:";
            // 
            // gatebefore
            // 
            this.gatebefore.AutoSize = true;
            this.gatebefore.Location = new System.Drawing.Point(24, 105);
            this.gatebefore.Name = "gatebefore";
            this.gatebefore.Size = new System.Drawing.Size(77, 12);
            this.gatebefore.TabIndex = 2;
            this.gatebefore.Text = "Gate before:";
            // 
            // weldmode
            // 
            this.weldmode.Location = new System.Drawing.Point(26, 54);
            this.weldmode.Name = "weldmode";
            this.weldmode.Size = new System.Drawing.Size(298, 32);
            this.weldmode.TabIndex = 1;
            this.weldmode.TabStop = true;
            this.weldmode.Text = "Before relative to target and After relative to weld centerline";
            this.weldmode.UseVisualStyleBackColor = true;
            // 
            // targetmode
            // 
            this.targetmode.AutoSize = true;
            this.targetmode.Location = new System.Drawing.Point(26, 32);
            this.targetmode.Name = "targetmode";
            this.targetmode.Size = new System.Drawing.Size(275, 16);
            this.targetmode.TabIndex = 0;
            this.targetmode.TabStop = true;
            this.targetmode.Text = "Before and After values relative to target";
            this.targetmode.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ok.Location = new System.Drawing.Point(35, 240);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = false;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Location = new System.Drawing.Point(212, 240);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // FormGateSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(331, 275);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.Gateinformation);
            this.Name = "FormGateSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGateSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGateSetting_FormClosing);
            this.Gateinformation.ResumeLayout(false);
            this.Gateinformation.PerformLayout();
            this.gateb.ResumeLayout(false);
            this.gateb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gateinformation;
        private System.Windows.Forms.Label Threshold;
        private System.Windows.Forms.Label gateafter;
        private System.Windows.Forms.Label gatebefore;
        private System.Windows.Forms.RadioButton weldmode;
        private System.Windows.Forms.RadioButton targetmode;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.GroupBox gateb;
        private System.Windows.Forms.TextBox Bthreshold;
        private System.Windows.Forms.TextBox Bafter;
        private System.Windows.Forms.TextBox Bbefore;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.Label after;
        private System.Windows.Forms.Label before;
    }
}