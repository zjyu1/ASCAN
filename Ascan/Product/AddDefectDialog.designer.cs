namespace Ascan
{
    partial class AddDefectDialog
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
            this.btnNO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBA = new System.Windows.Forms.TextBox();
            this.txtEA = new System.Windows.Forms.TextBox();
            this.txtBR = new System.Windows.Forms.TextBox();
            this.txtER = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtSubregion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(59, 325);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnNO
            // 
            this.btnNO.Location = new System.Drawing.Point(199, 325);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(75, 23);
            this.btnNO.TabIndex = 1;
            this.btnNO.Text = "取消";
            this.btnNO.UseVisualStyleBackColor = true;
            this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分区";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "轴向起始位置(mm)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "轴向结束位置(mm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "周向起始位置(°)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "周向结束位置(°)";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(185, 29);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 9;
            // 
            // txtBA
            // 
            this.txtBA.Location = new System.Drawing.Point(185, 149);
            this.txtBA.MaxLength = 10;
            this.txtBA.Name = "txtBA";
            this.txtBA.Size = new System.Drawing.Size(100, 21);
            this.txtBA.TabIndex = 10;
            this.txtBA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBA_KeyPress);
            // 
            // txtEA
            // 
            this.txtEA.Location = new System.Drawing.Point(185, 189);
            this.txtEA.MaxLength = 10;
            this.txtEA.Name = "txtEA";
            this.txtEA.Size = new System.Drawing.Size(100, 21);
            this.txtEA.TabIndex = 11;
            this.txtEA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEA_KeyPress);
            // 
            // txtBR
            // 
            this.txtBR.Location = new System.Drawing.Point(185, 229);
            this.txtBR.MaxLength = 5;
            this.txtBR.Name = "txtBR";
            this.txtBR.Size = new System.Drawing.Size(100, 21);
            this.txtBR.TabIndex = 12;
            this.txtBR.TextChanged += new System.EventHandler(this.txtBR_TextChanged);
            this.txtBR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBR_KeyPress);
            // 
            // txtER
            // 
            this.txtER.Location = new System.Drawing.Point(185, 269);
            this.txtER.MaxLength = 5;
            this.txtER.Name = "txtER";
            this.txtER.Size = new System.Drawing.Size(100, 21);
            this.txtER.TabIndex = 13;
            this.txtER.TextChanged += new System.EventHandler(this.txtER_TextChanged);
            this.txtER.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtER_KeyPress);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(185, 109);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 21);
            this.txtType.TabIndex = 16;
            // 
            // txtSubregion
            // 
            this.txtSubregion.Location = new System.Drawing.Point(185, 69);
            this.txtSubregion.Name = "txtSubregion";
            this.txtSubregion.Size = new System.Drawing.Size(100, 21);
            this.txtSubregion.TabIndex = 17;
            // 
            // AddDefectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 396);
            this.Controls.Add(this.txtSubregion);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtER);
            this.Controls.Add(this.txtBR);
            this.Controls.Add(this.txtEA);
            this.Controls.Add(this.txtBA);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNO);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDefectDialog";
            this.Text = "AddDefect";
            this.Load += new System.EventHandler(this.AddDefectDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBA;
        private System.Windows.Forms.TextBox txtEA;
        private System.Windows.Forms.TextBox txtBR;
        private System.Windows.Forms.TextBox txtER;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtSubregion;
    }
}