namespace autsql
{
    partial class FrmNwBatchC
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxType = new System.Windows.Forms.ComboBox();
            this.BoxSetup = new System.Windows.Forms.ComboBox();
            this.benBack = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "检测模式";
            // 
            // BoxType
            // 
            this.BoxType.FormattingEnabled = true;
            this.BoxType.Location = new System.Drawing.Point(39, 67);
            this.BoxType.Name = "BoxType";
            this.BoxType.Size = new System.Drawing.Size(266, 20);
            this.BoxType.TabIndex = 2;
            // 
            // BoxSetup
            // 
            this.BoxSetup.FormattingEnabled = true;
            this.BoxSetup.Location = new System.Drawing.Point(39, 138);
            this.BoxSetup.Name = "BoxSetup";
            this.BoxSetup.Size = new System.Drawing.Size(266, 20);
            this.BoxSetup.TabIndex = 3;
            // 
            // benBack
            // 
            this.benBack.Location = new System.Drawing.Point(164, 196);
            this.benBack.Name = "benBack";
            this.benBack.Size = new System.Drawing.Size(75, 23);
            this.benBack.TabIndex = 4;
            this.benBack.Text = "<<返回";
            this.benBack.UseVisualStyleBackColor = true;
            this.benBack.Click += new System.EventHandler(this.benBack_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(245, 196);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(326, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmNwBatchC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 237);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.benBack);
            this.Controls.Add(this.BoxSetup);
            this.Controls.Add(this.BoxType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmNwBatchC";
            this.Text = "UT参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BoxType;
        private System.Windows.Forms.ComboBox BoxSetup;
        private System.Windows.Forms.Button benBack;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
    }
}