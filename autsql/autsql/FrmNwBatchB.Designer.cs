namespace autsql
{
    partial class FrmNwBatchB
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textCustomer = new System.Windows.Forms.TextBox();
            this.textFileNum = new System.Windows.Forms.TextBox();
            this.textHeat = new System.Windows.Forms.TextBox();
            this.textGrade = new System.Windows.Forms.TextBox();
            this.textNuance = new System.Windows.Forms.TextBox();
            this.textDimension = new System.Windows.Forms.TextBox();
            this.textArea = new System.Windows.Forms.TextBox();
            this.textSpecification = new System.Windows.Forms.TextBox();
            this.textOperator = new System.Windows.Forms.TextBox();
            this.textOpId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(221, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(331, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "客户名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "热处理";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "等级";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "材料";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "产品尺寸";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "厂区";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(219, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "规范";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "操作员";
            // 
            // textCustomer
            // 
            this.textCustomer.Location = new System.Drawing.Point(86, 33);
            this.textCustomer.Name = "textCustomer";
            this.textCustomer.Size = new System.Drawing.Size(100, 21);
            this.textCustomer.TabIndex = 11;
            // 
            // textFileNum
            // 
            this.textFileNum.Location = new System.Drawing.Point(86, 72);
            this.textFileNum.Name = "textFileNum";
            this.textFileNum.Size = new System.Drawing.Size(100, 21);
            this.textFileNum.TabIndex = 12;
            this.textFileNum.TextChanged += new System.EventHandler(this.textFileNum_TextChanged);
            this.textFileNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFileNum_KeyPress);
            // 
            // textHeat
            // 
            this.textHeat.Location = new System.Drawing.Point(86, 111);
            this.textHeat.Name = "textHeat";
            this.textHeat.Size = new System.Drawing.Size(100, 21);
            this.textHeat.TabIndex = 13;
            // 
            // textGrade
            // 
            this.textGrade.Location = new System.Drawing.Point(86, 147);
            this.textGrade.Name = "textGrade";
            this.textGrade.Size = new System.Drawing.Size(100, 21);
            this.textGrade.TabIndex = 14;
            // 
            // textNuance
            // 
            this.textNuance.Location = new System.Drawing.Point(86, 181);
            this.textNuance.Name = "textNuance";
            this.textNuance.Size = new System.Drawing.Size(100, 21);
            this.textNuance.TabIndex = 15;
            // 
            // textDimension
            // 
            this.textDimension.Location = new System.Drawing.Point(268, 35);
            this.textDimension.Name = "textDimension";
            this.textDimension.Size = new System.Drawing.Size(100, 21);
            this.textDimension.TabIndex = 16;
            // 
            // textArea
            // 
            this.textArea.Location = new System.Drawing.Point(269, 72);
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(100, 21);
            this.textArea.TabIndex = 17;
            // 
            // textSpecification
            // 
            this.textSpecification.Location = new System.Drawing.Point(269, 112);
            this.textSpecification.Name = "textSpecification";
            this.textSpecification.Size = new System.Drawing.Size(100, 21);
            this.textSpecification.TabIndex = 18;
            // 
            // textOperator
            // 
            this.textOperator.Location = new System.Drawing.Point(269, 148);
            this.textOperator.Name = "textOperator";
            this.textOperator.Size = new System.Drawing.Size(100, 21);
            this.textOperator.TabIndex = 19;
            // 
            // textOpId
            // 
            this.textOpId.Location = new System.Drawing.Point(268, 184);
            this.textOpId.Name = "textOpId";
            this.textOpId.Size = new System.Drawing.Size(100, 21);
            this.textOpId.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "操作员ID";
            // 
            // FrmNwBatchB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 249);
            this.Controls.Add(this.textOpId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textOperator);
            this.Controls.Add(this.textSpecification);
            this.Controls.Add(this.textArea);
            this.Controls.Add(this.textDimension);
            this.Controls.Add(this.textNuance);
            this.Controls.Add(this.textGrade);
            this.Controls.Add(this.textHeat);
            this.Controls.Add(this.textFileNum);
            this.Controls.Add(this.textCustomer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmNwBatchB";
            this.Text = "批次属性（详细）";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textCustomer;
        private System.Windows.Forms.TextBox textFileNum;
        private System.Windows.Forms.TextBox textHeat;
        private System.Windows.Forms.TextBox textGrade;
        private System.Windows.Forms.TextBox textNuance;
        private System.Windows.Forms.TextBox textDimension;
        private System.Windows.Forms.TextBox textArea;
        private System.Windows.Forms.TextBox textSpecification;
        private System.Windows.Forms.TextBox textOperator;
        private System.Windows.Forms.TextBox textOpId;
        private System.Windows.Forms.Label label10;
    }
}