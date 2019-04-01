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
            this.defectY = new System.Windows.Forms.Label();
            this.defectangle = new System.Windows.Forms.Label();
            this.xtext = new System.Windows.Forms.TextBox();
            this.angletext = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.methodlabel = new System.Windows.Forms.Label();
            this.methodbox = new System.Windows.Forms.ComboBox();
            this.Yrange = new System.Windows.Forms.Label();
            this.Anglerange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // defectY
            // 
            this.defectY.AutoSize = true;
            this.defectY.Location = new System.Drawing.Point(67, 65);
            this.defectY.Name = "defectY";
            this.defectY.Size = new System.Drawing.Size(59, 12);
            this.defectY.TabIndex = 0;
            this.defectY.Text = "DefectY：";
            // 
            // defectangle
            // 
            this.defectangle.AutoSize = true;
            this.defectangle.Location = new System.Drawing.Point(67, 110);
            this.defectangle.Name = "defectangle";
            this.defectangle.Size = new System.Drawing.Size(83, 12);
            this.defectangle.TabIndex = 2;
            this.defectangle.Text = "DefectAngle：";
            // 
            // xtext
            // 
            this.xtext.Location = new System.Drawing.Point(180, 62);
            this.xtext.Name = "xtext";
            this.xtext.Size = new System.Drawing.Size(100, 21);
            this.xtext.TabIndex = 3;
            // 
            // angletext
            // 
            this.angletext.Location = new System.Drawing.Point(180, 107);
            this.angletext.Name = "angletext";
            this.angletext.Size = new System.Drawing.Size(100, 21);
            this.angletext.TabIndex = 5;
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(69, 162);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 6;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(247, 162);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // methodlabel
            // 
            this.methodlabel.AutoSize = true;
            this.methodlabel.Location = new System.Drawing.Point(67, 24);
            this.methodlabel.Name = "methodlabel";
            this.methodlabel.Size = new System.Drawing.Size(89, 12);
            this.methodlabel.TabIndex = 8;
            this.methodlabel.Text = "DefectMethod：";
            // 
            // methodbox
            // 
            this.methodbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodbox.FormattingEnabled = true;
            this.methodbox.Items.AddRange(new object[] {
            "Direct",
            "Reflect",
            "Series"});
            this.methodbox.Location = new System.Drawing.Point(180, 21);
            this.methodbox.Name = "methodbox";
            this.methodbox.Size = new System.Drawing.Size(100, 20);
            this.methodbox.TabIndex = 9;
            this.methodbox.SelectedIndexChanged += new System.EventHandler(this.methodbox_SelectedIndexChanged);
            // 
            // Yrange
            // 
            this.Yrange.AutoSize = true;
            this.Yrange.Location = new System.Drawing.Point(300, 65);
            this.Yrange.Name = "Yrange";
            this.Yrange.Size = new System.Drawing.Size(11, 12);
            this.Yrange.TabIndex = 10;
            this.Yrange.Text = "0";
            // 
            // Anglerange
            // 
            this.Anglerange.AutoSize = true;
            this.Anglerange.Location = new System.Drawing.Point(300, 110);
            this.Anglerange.Name = "Anglerange";
            this.Anglerange.Size = new System.Drawing.Size(35, 12);
            this.Anglerange.TabIndex = 11;
            this.Anglerange.Text = "angle";
            // 
            // FormModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(397, 216);
            this.Controls.Add(this.Anglerange);
            this.Controls.Add(this.Yrange);
            this.Controls.Add(this.methodbox);
            this.Controls.Add(this.methodlabel);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.angletext);
            this.Controls.Add(this.xtext);
            this.Controls.Add(this.defectangle);
            this.Controls.Add(this.defectY);
            this.Name = "FormModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormModify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormModify_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label defectY;
        private System.Windows.Forms.Label defectangle;
        private System.Windows.Forms.TextBox xtext;
        private System.Windows.Forms.TextBox angletext;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label methodlabel;
        private System.Windows.Forms.ComboBox methodbox;
        private System.Windows.Forms.Label Yrange;
        private System.Windows.Forms.Label Anglerange;
    }
}