namespace Ascan
{
    partial class FormMDAC
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
            this.multiDAC = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.curveD = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.curveC = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.curveB = new System.Windows.Forms.Label();
            this.curveA = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.corrections = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.labelTransferLoss = new System.Windows.Forms.Label();
            this.labelTestObject = new System.Windows.Forms.Label();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.multiDAC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.corrections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            this.SuspendLayout();
            // 
            // multiDAC
            // 
            this.multiDAC.Controls.Add(this.label10);
            this.multiDAC.Controls.Add(this.label9);
            this.multiDAC.Controls.Add(this.label6);
            this.multiDAC.Controls.Add(this.label5);
            this.multiDAC.Controls.Add(this.numericUpDown4);
            this.multiDAC.Controls.Add(this.curveD);
            this.multiDAC.Controls.Add(this.numericUpDown3);
            this.multiDAC.Controls.Add(this.curveC);
            this.multiDAC.Controls.Add(this.numericUpDown2);
            this.multiDAC.Controls.Add(this.curveB);
            this.multiDAC.Controls.Add(this.curveA);
            this.multiDAC.Controls.Add(this.numericUpDown1);
            this.multiDAC.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.multiDAC.Location = new System.Drawing.Point(4, 4);
            this.multiDAC.Name = "multiDAC";
            this.multiDAC.Size = new System.Drawing.Size(181, 234);
            this.multiDAC.TabIndex = 0;
            this.multiDAC.TabStop = false;
            this.multiDAC.Text = "Multi DAC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(137, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 17);
            this.label10.TabIndex = 11;
            this.label10.Text = "dB";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(137, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "dB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "dB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "dB";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(11, 202);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown4.TabIndex = 7;
            // 
            // curveD
            // 
            this.curveD.AutoSize = true;
            this.curveD.ForeColor = System.Drawing.Color.Red;
            this.curveD.Location = new System.Drawing.Point(8, 183);
            this.curveD.Name = "curveD";
            this.curveD.Size = new System.Drawing.Size(54, 17);
            this.curveD.TabIndex = 6;
            this.curveD.Text = "Curve D";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(11, 147);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown3.TabIndex = 5;
            // 
            // curveC
            // 
            this.curveC.AutoSize = true;
            this.curveC.ForeColor = System.Drawing.Color.Fuchsia;
            this.curveC.Location = new System.Drawing.Point(8, 128);
            this.curveC.Name = "curveC";
            this.curveC.Size = new System.Drawing.Size(53, 17);
            this.curveC.TabIndex = 4;
            this.curveC.Text = "Curve C";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(11, 93);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown2.TabIndex = 3;
            // 
            // curveB
            // 
            this.curveB.AutoSize = true;
            this.curveB.ForeColor = System.Drawing.Color.Lime;
            this.curveB.Location = new System.Drawing.Point(8, 74);
            this.curveB.Name = "curveB";
            this.curveB.Size = new System.Drawing.Size(53, 17);
            this.curveB.TabIndex = 2;
            this.curveB.Text = "Curve B";
            // 
            // curveA
            // 
            this.curveA.AutoSize = true;
            this.curveA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.curveA.Location = new System.Drawing.Point(8, 19);
            this.curveA.Name = "curveA";
            this.curveA.Size = new System.Drawing.Size(53, 17);
            this.curveA.TabIndex = 1;
            this.curveA.Text = "Curve A";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(11, 38);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 0;
            // 
            // corrections
            // 
            this.corrections.Controls.Add(this.label12);
            this.corrections.Controls.Add(this.label11);
            this.corrections.Controls.Add(this.numericUpDown7);
            this.corrections.Controls.Add(this.labelTransferLoss);
            this.corrections.Controls.Add(this.labelTestObject);
            this.corrections.Controls.Add(this.numericUpDown8);
            this.corrections.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.corrections.Location = new System.Drawing.Point(4, 244);
            this.corrections.Name = "corrections";
            this.corrections.Size = new System.Drawing.Size(181, 131);
            this.corrections.TabIndex = 1;
            this.corrections.TabStop = false;
            this.corrections.Text = "Corrections";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(137, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "dB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(137, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "dB/mm";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(11, 93);
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown7.TabIndex = 3;
            // 
            // labelTransferLoss
            // 
            this.labelTransferLoss.AutoSize = true;
            this.labelTransferLoss.Location = new System.Drawing.Point(8, 74);
            this.labelTransferLoss.Name = "labelTransferLoss";
            this.labelTransferLoss.Size = new System.Drawing.Size(86, 17);
            this.labelTransferLoss.TabIndex = 2;
            this.labelTransferLoss.Text = "Transfer Loss";
            // 
            // labelTestObject
            // 
            this.labelTestObject.AutoSize = true;
            this.labelTestObject.Location = new System.Drawing.Point(8, 19);
            this.labelTestObject.Name = "labelTestObject";
            this.labelTestObject.Size = new System.Drawing.Size(74, 17);
            this.labelTestObject.TabIndex = 1;
            this.labelTestObject.Text = "Test Object";
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(11, 38);
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown8.TabIndex = 0;
            // 
            // FormMDAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 378);
            this.Controls.Add(this.corrections);
            this.Controls.Add(this.multiDAC);
            this.Name = "FormMDAC";
            this.Text = "MDAC";
            this.Load += new System.EventHandler(this.FormMDAC_Load);
            this.multiDAC.ResumeLayout(false);
            this.multiDAC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.corrections.ResumeLayout(false);
            this.corrections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox multiDAC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label curveD;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label curveC;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label curveB;
        private System.Windows.Forms.Label curveA;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox corrections;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.Label labelTransferLoss;
        private System.Windows.Forms.Label labelTestObject;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
    }
}