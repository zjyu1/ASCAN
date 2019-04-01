namespace Ascan
{
    partial class FormModify
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
            this.defectX = new System.Windows.Forms.Label();
            this.defectangle = new System.Windows.Forms.Label();
            this.xtext = new System.Windows.Forms.TextBox();
            this.angletext = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defectX
            // 
            this.defectX.AutoSize = true;
            this.defectX.Location = new System.Drawing.Point(67, 38);
            this.defectX.Name = "defectX";
            this.defectX.Size = new System.Drawing.Size(47, 12);
            this.defectX.TabIndex = 0;
            this.defectX.Text = "defectx";
            // 
            // defectangle
            // 
            this.defectangle.AutoSize = true;
            this.defectangle.Location = new System.Drawing.Point(67, 102);
            this.defectangle.Name = "defectangle";
            this.defectangle.Size = new System.Drawing.Size(71, 12);
            this.defectangle.TabIndex = 2;
            this.defectangle.Text = "defectangle";
            // 
            // xtext
            // 
            this.xtext.Location = new System.Drawing.Point(180, 35);
            this.xtext.Name = "xtext";
            this.xtext.Size = new System.Drawing.Size(100, 21);
            this.xtext.TabIndex = 3;
            // 
            // angletext
            // 
            this.angletext.Location = new System.Drawing.Point(180, 99);
            this.angletext.Name = "angletext";
            this.angletext.Size = new System.Drawing.Size(100, 21);
            this.angletext.TabIndex = 5;
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(69, 148);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 6;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(205, 148);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // FormModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(352, 200);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.angletext);
            this.Controls.Add(this.xtext);
            this.Controls.Add(this.defectangle);
            this.Controls.Add(this.defectX);
            this.Name = "FormModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormModify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormModify_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label defectX;
        private System.Windows.Forms.Label defectangle;
        private System.Windows.Forms.TextBox xtext;
        private System.Windows.Forms.TextBox angletext;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
    }
}