namespace Ascan
{
    partial class FormDAC
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
            this.grpDACMode = new System.Windows.Forms.GroupBox();
            this.modeGCG = new System.Windows.Forms.RadioButton();
            this.modeMdac = new System.Windows.Forms.RadioButton();
            this.modeDac = new System.Windows.Forms.RadioButton();
            this.modeTcg = new System.Windows.Forms.RadioButton();
            this.modeEdit = new System.Windows.Forms.RadioButton();
            this.modeOff = new System.Windows.Forms.RadioButton();
            this.amplitudeMode = new System.Windows.Forms.GroupBox();
            this.radioButtonDB = new System.Windows.Forms.RadioButton();
            this.radioButtonPercent = new System.Windows.Forms.RadioButton();
            this.dacTable = new System.Windows.Forms.GroupBox();
            this.dacGridView = new System.Windows.Forms.DataGridView();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.gcgTable = new System.Windows.Forms.GroupBox();
            this.gcgGridView = new System.Windows.Forms.DataGridView();
            this.grpDACMode.SuspendLayout();
            this.amplitudeMode.SuspendLayout();
            this.dacTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dacGridView)).BeginInit();
            this.gcgTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcgGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDACMode
            // 
            this.grpDACMode.Controls.Add(this.modeGCG);
            this.grpDACMode.Controls.Add(this.modeMdac);
            this.grpDACMode.Controls.Add(this.modeDac);
            this.grpDACMode.Controls.Add(this.modeTcg);
            this.grpDACMode.Controls.Add(this.modeEdit);
            this.grpDACMode.Controls.Add(this.modeOff);
            this.grpDACMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDACMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpDACMode.Location = new System.Drawing.Point(0, 0);
            this.grpDACMode.Name = "grpDACMode";
            this.grpDACMode.Size = new System.Drawing.Size(200, 97);
            this.grpDACMode.TabIndex = 0;
            this.grpDACMode.TabStop = false;
            this.grpDACMode.Text = "DAC Mode";
            // 
            // modeGCG
            // 
            this.modeGCG.AutoSize = true;
            this.modeGCG.Location = new System.Drawing.Point(107, 70);
            this.modeGCG.Name = "modeGCG";
            this.modeGCG.Size = new System.Drawing.Size(52, 21);
            this.modeGCG.TabIndex = 5;
            this.modeGCG.Text = "GCG";
            this.modeGCG.UseVisualStyleBackColor = true;
            // 
            // modeMdac
            // 
            this.modeMdac.AutoSize = true;
            this.modeMdac.Location = new System.Drawing.Point(12, 71);
            this.modeMdac.Name = "modeMdac";
            this.modeMdac.Size = new System.Drawing.Size(63, 21);
            this.modeMdac.TabIndex = 4;
            this.modeMdac.Text = "MDAC";
            this.modeMdac.UseVisualStyleBackColor = true;
            // 
            // modeDac
            // 
            this.modeDac.AutoSize = true;
            this.modeDac.Location = new System.Drawing.Point(12, 47);
            this.modeDac.Name = "modeDac";
            this.modeDac.Size = new System.Drawing.Size(51, 21);
            this.modeDac.TabIndex = 2;
            this.modeDac.Text = "DAC";
            this.modeDac.UseVisualStyleBackColor = true;
            // 
            // modeTcg
            // 
            this.modeTcg.AutoSize = true;
            this.modeTcg.Location = new System.Drawing.Point(107, 47);
            this.modeTcg.Name = "modeTcg";
            this.modeTcg.Size = new System.Drawing.Size(50, 21);
            this.modeTcg.TabIndex = 3;
            this.modeTcg.Text = "TCG";
            this.modeTcg.UseVisualStyleBackColor = true;
            // 
            // modeEdit
            // 
            this.modeEdit.AutoSize = true;
            this.modeEdit.Location = new System.Drawing.Point(107, 23);
            this.modeEdit.Name = "modeEdit";
            this.modeEdit.Size = new System.Drawing.Size(48, 21);
            this.modeEdit.TabIndex = 1;
            this.modeEdit.Text = "Edit";
            this.modeEdit.UseVisualStyleBackColor = true;
            // 
            // modeOff
            // 
            this.modeOff.AutoSize = true;
            this.modeOff.Checked = true;
            this.modeOff.Location = new System.Drawing.Point(12, 23);
            this.modeOff.Name = "modeOff";
            this.modeOff.Size = new System.Drawing.Size(44, 21);
            this.modeOff.TabIndex = 0;
            this.modeOff.TabStop = true;
            this.modeOff.Text = "Off";
            this.modeOff.UseVisualStyleBackColor = true;
            // 
            // amplitudeMode
            // 
            this.amplitudeMode.Controls.Add(this.radioButtonDB);
            this.amplitudeMode.Controls.Add(this.radioButtonPercent);
            this.amplitudeMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.amplitudeMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.amplitudeMode.Location = new System.Drawing.Point(0, 97);
            this.amplitudeMode.Name = "amplitudeMode";
            this.amplitudeMode.Size = new System.Drawing.Size(200, 50);
            this.amplitudeMode.TabIndex = 1;
            this.amplitudeMode.TabStop = false;
            this.amplitudeMode.Text = "Amplitude Mode";
            // 
            // radioButtonDB
            // 
            this.radioButtonDB.AutoSize = true;
            this.radioButtonDB.Location = new System.Drawing.Point(107, 22);
            this.radioButtonDB.Name = "radioButtonDB";
            this.radioButtonDB.Size = new System.Drawing.Size(42, 21);
            this.radioButtonDB.TabIndex = 4;
            this.radioButtonDB.Text = "dB";
            this.radioButtonDB.UseVisualStyleBackColor = true;
            // 
            // radioButtonPercent
            // 
            this.radioButtonPercent.AutoSize = true;
            this.radioButtonPercent.Checked = true;
            this.radioButtonPercent.Location = new System.Drawing.Point(12, 22);
            this.radioButtonPercent.Name = "radioButtonPercent";
            this.radioButtonPercent.Size = new System.Drawing.Size(37, 21);
            this.radioButtonPercent.TabIndex = 1;
            this.radioButtonPercent.TabStop = true;
            this.radioButtonPercent.Text = "%";
            this.radioButtonPercent.UseVisualStyleBackColor = true;
            // 
            // dacTable
            // 
            this.dacTable.Controls.Add(this.dacGridView);
            this.dacTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.dacTable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dacTable.Location = new System.Drawing.Point(0, 147);
            this.dacTable.Name = "dacTable";
            this.dacTable.Size = new System.Drawing.Size(200, 141);
            this.dacTable.TabIndex = 2;
            this.dacTable.TabStop = false;
            this.dacTable.Text = "DAC Table";
            // 
            // dacGridView
            // 
            this.dacGridView.AllowUserToAddRows = false;
            this.dacGridView.AllowUserToOrderColumns = true;
            this.dacGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dacGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dacGridView.Location = new System.Drawing.Point(6, 18);
            this.dacGridView.Name = "dacGridView";
            this.dacGridView.RowTemplate.Height = 23;
            this.dacGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dacGridView.Size = new System.Drawing.Size(192, 115);
            this.dacGridView.TabIndex = 0;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRecord.Location = new System.Drawing.Point(0, 447);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonRecord.TabIndex = 3;
            this.buttonRecord.Text = "Record";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDelete.Location = new System.Drawing.Point(117, 447);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // gcgTable
            // 
            this.gcgTable.Controls.Add(this.gcgGridView);
            this.gcgTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcgTable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcgTable.Location = new System.Drawing.Point(0, 288);
            this.gcgTable.Name = "gcgTable";
            this.gcgTable.Size = new System.Drawing.Size(200, 144);
            this.gcgTable.TabIndex = 5;
            this.gcgTable.TabStop = false;
            this.gcgTable.Text = "GCG Table";
            // 
            // gcgGridView
            // 
            this.gcgGridView.AllowUserToAddRows = false;
            this.gcgGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gcgGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcgGridView.Location = new System.Drawing.Point(6, 20);
            this.gcgGridView.Name = "gcgGridView";
            this.gcgGridView.RowTemplate.Height = 23;
            this.gcgGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gcgGridView.Size = new System.Drawing.Size(192, 115);
            this.gcgGridView.TabIndex = 0;
            // 
            // FormDAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 472);
            this.Controls.Add(this.gcgTable);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.dacTable);
            this.Controls.Add(this.amplitudeMode);
            this.Controls.Add(this.grpDACMode);
            this.Name = "FormDAC";
            this.Text = "DAC";
            this.Load += new System.EventHandler(this.FormDAC_Load);
            this.grpDACMode.ResumeLayout(false);
            this.grpDACMode.PerformLayout();
            this.amplitudeMode.ResumeLayout(false);
            this.amplitudeMode.PerformLayout();
            this.dacTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dacGridView)).EndInit();
            this.gcgTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcgGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDACMode;
        private System.Windows.Forms.RadioButton modeMdac;
        private System.Windows.Forms.RadioButton modeDac;
        private System.Windows.Forms.RadioButton modeTcg;
        private System.Windows.Forms.RadioButton modeEdit;
        private System.Windows.Forms.RadioButton modeOff;
        private System.Windows.Forms.GroupBox amplitudeMode;
        private System.Windows.Forms.RadioButton radioButtonDB;
        private System.Windows.Forms.RadioButton radioButtonPercent;
        private System.Windows.Forms.GroupBox dacTable;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dacGridView;
        private System.Windows.Forms.RadioButton modeGCG;
        private System.Windows.Forms.GroupBox gcgTable;
        private System.Windows.Forms.DataGridView gcgGridView;
    }
}