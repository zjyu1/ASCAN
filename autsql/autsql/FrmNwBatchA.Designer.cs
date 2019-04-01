namespace autsql
{
    partial class FrmNwBatchA
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_batchName = new System.Windows.Forms.TextBox();
            this.textNum = new System.Windows.Forms.TextBox();
            this.dateStop = new System.Windows.Forms.DateTimePicker();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "批次名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "产品数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "开始时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "结束时间";
            // 
            // txb_batchName
            // 
            this.txb_batchName.Location = new System.Drawing.Point(110, 56);
            this.txb_batchName.Name = "txb_batchName";
            this.txb_batchName.Size = new System.Drawing.Size(200, 21);
            this.txb_batchName.TabIndex = 4;
            this.txb_batchName.TextChanged += new System.EventHandler(this.txb_batchName_TextChanged);
            // 
            // textNum
            // 
            this.textNum.Location = new System.Drawing.Point(110, 91);
            this.textNum.Name = "textNum";
            this.textNum.Size = new System.Drawing.Size(100, 21);
            this.textNum.TabIndex = 5;
            this.textNum.TextChanged += new System.EventHandler(this.textNum_TextChanged);
            this.textNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNum_KeyPress);
            // 
            // dateStop
            // 
            this.dateStop.Location = new System.Drawing.Point(110, 164);
            this.dateStop.MinDate = new System.DateTime(1755, 7, 17, 0, 0, 0, 0);
            this.dateStop.Name = "dateStop";
            this.dateStop.Size = new System.Drawing.Size(247, 21);
            this.dateStop.TabIndex = 8;
            this.dateStop.UseWaitCursor = true;
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(235, 91);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(75, 23);
            this.btnMore.TabIndex = 9;
            this.btnMore.Text = "详细...";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(197, 217);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 10;
            this.btnContinue.Text = "继续>>";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btncontinue);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(307, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(110, 129);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(247, 21);
            this.dateStart.TabIndex = 7;
            this.dateStart.ValueChanged += new System.EventHandler(this.dataStart_ValueChanged);
            // 
            // FrmNwBatchA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 252);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.dateStop);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.textNum);
            this.Controls.Add(this.txb_batchName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmNwBatchA";
            this.Text = "批次属性";
            this.Load += new System.EventHandler(this.FrmNwBatchA_Load);
            this.Shown += new System.EventHandler(this.FrmNwBatchA_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_batchName;
        private System.Windows.Forms.TextBox textNum;
        private System.Windows.Forms.DateTimePicker dateStop;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dateStart;
    }
}