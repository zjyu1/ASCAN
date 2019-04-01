namespace Ascan
{
    partial class FormGateInfo
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
            this.dataGridView_sgGate = new System.Windows.Forms.DataGridView();
            this.SingleGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amp1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tof1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_dbGate = new System.Windows.Forms.DataGridView();
            this.DoubleGate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amp2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tof2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sgGate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dbGate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_sgGate
            // 
            this.dataGridView_sgGate.AllowUserToAddRows = false;
            this.dataGridView_sgGate.AllowUserToResizeColumns = false;
            this.dataGridView_sgGate.AllowUserToResizeRows = false;
            this.dataGridView_sgGate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_sgGate.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_sgGate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_sgGate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sgGate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SingleGate,
            this.amp1,
            this.tof1});
            this.dataGridView_sgGate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_sgGate.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_sgGate.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_sgGate.Name = "dataGridView_sgGate";
            this.dataGridView_sgGate.RowHeadersVisible = false;
            this.dataGridView_sgGate.RowHeadersWidth = 38;
            this.dataGridView_sgGate.RowTemplate.Height = 23;
            this.dataGridView_sgGate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_sgGate.Size = new System.Drawing.Size(240, 100);
            this.dataGridView_sgGate.TabIndex = 2;
            // 
            // SingleGate
            // 
            this.SingleGate.HeaderText = "Gate";
            this.SingleGate.Name = "SingleGate";
            // 
            // amp1
            // 
            this.amp1.HeaderText = "Amp(%)";
            this.amp1.Name = "amp1";
            // 
            // tof1
            // 
            this.tof1.HeaderText = "Tof(us)";
            this.tof1.Name = "tof1";
            // 
            // dataGridView_dbGate
            // 
            this.dataGridView_dbGate.AllowUserToAddRows = false;
            this.dataGridView_dbGate.AllowUserToResizeColumns = false;
            this.dataGridView_dbGate.AllowUserToResizeRows = false;
            this.dataGridView_dbGate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_dbGate.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_dbGate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_dbGate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dbGate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DoubleGate,
            this.Amp2,
            this.Tof2});
            this.dataGridView_dbGate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_dbGate.Location = new System.Drawing.Point(0, 100);
            this.dataGridView_dbGate.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_dbGate.Name = "dataGridView_dbGate";
            this.dataGridView_dbGate.RowHeadersVisible = false;
            this.dataGridView_dbGate.RowTemplate.Height = 23;
            this.dataGridView_dbGate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_dbGate.Size = new System.Drawing.Size(240, 100);
            this.dataGridView_dbGate.TabIndex = 0;
            // 
            // DoubleGate
            // 
            this.DoubleGate.HeaderText = "DoubleGate";
            this.DoubleGate.Name = "DoubleGate";
            this.DoubleGate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Amp2
            // 
            this.Amp2.HeaderText = "AmpDiff(dB)";
            this.Amp2.Name = "Amp2";
            // 
            // Tof2
            // 
            this.Tof2.HeaderText = "TofDiff(us)";
            this.Tof2.Name = "Tof2";
            // 
            // FormGateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(80, 0);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(240, 213);
            this.Controls.Add(this.dataGridView_dbGate);
            this.Controls.Add(this.dataGridView_sgGate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGateInfo";
            this.Text = "FormGateInfo1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sgGate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dbGate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_sgGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SingleGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn amp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tof1;
        private System.Windows.Forms.DataGridView dataGridView_dbGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoubleGate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amp2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tof2;




    }
}