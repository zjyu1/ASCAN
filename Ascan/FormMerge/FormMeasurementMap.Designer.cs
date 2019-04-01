namespace Ascan
{
    partial class AscanMeasureMap
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
            /*if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);*/
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mainShowRigon = new System.Windows.Forms.SplitContainer();
            this.measureShow = new System.Windows.Forms.SplitContainer();
            this.reinspect = new System.Windows.Forms.Button();
            this.inspectStop = new System.Windows.Forms.Button();
            this.currentNum = new System.Windows.Forms.Button();
            this.inspectStatus = new System.Windows.Forms.Button();
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAlter = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkBoxName = new System.Windows.Forms.CheckBox();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dataGridShow = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.comboBoxConfig = new System.Windows.Forms.ComboBox();
            this.labelConfig = new System.Windows.Forms.Label();
            this.comboBoxNum = new System.Windows.Forms.ComboBox();
            this.labelNum = new System.Windows.Forms.Label();
            this.comboBoxBatch = new System.Windows.Forms.ComboBox();
            this.labelBatch = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainShowRigon)).BeginInit();
            this.mainShowRigon.Panel1.SuspendLayout();
            this.mainShowRigon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.measureShow)).BeginInit();
            this.measureShow.Panel1.SuspendLayout();
            this.measureShow.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShow)).BeginInit();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStrip,
            this.groupToolStrip,
            this.helpToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStrip,
            this.saveToolStrip});
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(39, 21);
            this.fileToolStrip.Text = "File";
            // 
            // openToolStrip
            // 
            this.openToolStrip.Name = "openToolStrip";
            this.openToolStrip.Size = new System.Drawing.Size(108, 22);
            this.openToolStrip.Text = "Open";
            this.openToolStrip.Click += new System.EventHandler(this.openToolStrip_Click);
            // 
            // saveToolStrip
            // 
            this.saveToolStrip.Name = "saveToolStrip";
            this.saveToolStrip.Size = new System.Drawing.Size(108, 22);
            this.saveToolStrip.Text = "Save";
            this.saveToolStrip.Click += new System.EventHandler(this.saveToolStrip_Click);
            // 
            // groupToolStrip
            // 
            this.groupToolStrip.Name = "groupToolStrip";
            this.groupToolStrip.Size = new System.Drawing.Size(57, 21);
            this.groupToolStrip.Text = "Group";
            this.groupToolStrip.Click += new System.EventHandler(this.groupToolStrip_Click);
            // 
            // helpToolStrip
            // 
            this.helpToolStrip.Name = "helpToolStrip";
            this.helpToolStrip.Size = new System.Drawing.Size(47, 21);
            this.helpToolStrip.Text = "Help";
            // 
            // mainShowRigon
            // 
            this.mainShowRigon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainShowRigon.Location = new System.Drawing.Point(0, 25);
            this.mainShowRigon.Name = "mainShowRigon";
            this.mainShowRigon.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainShowRigon.Panel1
            // 
            this.mainShowRigon.Panel1.Controls.Add(this.measureShow);
            // 
            // mainShowRigon.Panel2
            // 
            this.mainShowRigon.Panel2.BackColor = System.Drawing.Color.White;
            this.mainShowRigon.Panel2Collapsed = true;
            this.mainShowRigon.Size = new System.Drawing.Size(1020, 680);
            this.mainShowRigon.SplitterDistance = 167;
            this.mainShowRigon.TabIndex = 1;
            // 
            // measureShow
            // 
            this.measureShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measureShow.Location = new System.Drawing.Point(0, 0);
            this.measureShow.Name = "measureShow";
            // 
            // measureShow.Panel1
            // 
            this.measureShow.Panel1.Controls.Add(this.reinspect);
            this.measureShow.Panel1.Controls.Add(this.inspectStop);
            this.measureShow.Panel1.Controls.Add(this.currentNum);
            this.measureShow.Panel1.Controls.Add(this.inspectStatus);
            this.measureShow.Panel1.Controls.Add(this.panelControl);
            this.measureShow.Panel1.Controls.Add(this.panelGrid);
            this.measureShow.Panel1.Controls.Add(this.panelInfo);
            this.measureShow.Size = new System.Drawing.Size(1020, 680);
            this.measureShow.SplitterDistance = 163;
            this.measureShow.SplitterWidth = 1;
            this.measureShow.TabIndex = 0;
            // 
            // reinspect
            // 
            this.reinspect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.reinspect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reinspect.Location = new System.Drawing.Point(0, 533);
            this.reinspect.Name = "reinspect";
            this.reinspect.Size = new System.Drawing.Size(165, 39);
            this.reinspect.TabIndex = 6;
            this.reinspect.Text = "ReInspect";
            this.reinspect.UseVisualStyleBackColor = false;
            // 
            // inspectStop
            // 
            this.inspectStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.inspectStop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inspectStop.Location = new System.Drawing.Point(0, 569);
            this.inspectStop.Name = "inspectStop";
            this.inspectStop.Size = new System.Drawing.Size(165, 39);
            this.inspectStop.TabIndex = 5;
            this.inspectStop.Text = "Stop";
            this.inspectStop.UseVisualStyleBackColor = false;
            // 
            // currentNum
            // 
            this.currentNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.currentNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentNum.Location = new System.Drawing.Point(0, 605);
            this.currentNum.Name = "currentNum";
            this.currentNum.Size = new System.Drawing.Size(165, 39);
            this.currentNum.TabIndex = 4;
            this.currentNum.Text = "0#";
            this.currentNum.UseVisualStyleBackColor = false;
            // 
            // inspectStatus
            // 
            this.inspectStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.inspectStatus.Enabled = false;
            this.inspectStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inspectStatus.Location = new System.Drawing.Point(0, 641);
            this.inspectStatus.Name = "inspectStatus";
            this.inspectStatus.Size = new System.Drawing.Size(165, 39);
            this.inspectStatus.TabIndex = 3;
            this.inspectStatus.Text = "DisInspecting";
            this.inspectStatus.UseVisualStyleBackColor = false;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.White;
            this.panelControl.Controls.Add(this.buttonDelete);
            this.panelControl.Controls.Add(this.buttonAlter);
            this.panelControl.Controls.Add(this.buttonAdd);
            this.panelControl.Controls.Add(this.checkBoxName);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 441);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(163, 76);
            this.panelControl.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDelete.Location = new System.Drawing.Point(107, 33);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(45, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAlter
            // 
            this.buttonAlter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAlter.Location = new System.Drawing.Point(56, 33);
            this.buttonAlter.Name = "buttonAlter";
            this.buttonAlter.Size = new System.Drawing.Size(45, 23);
            this.buttonAlter.TabIndex = 2;
            this.buttonAlter.Text = "Alter";
            this.buttonAlter.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAdd.Location = new System.Drawing.Point(5, 33);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(45, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxName
            // 
            this.checkBoxName.AutoSize = true;
            this.checkBoxName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxName.Location = new System.Drawing.Point(12, 6);
            this.checkBoxName.Name = "checkBoxName";
            this.checkBoxName.Size = new System.Drawing.Size(140, 21);
            this.checkBoxName.TabIndex = 0;
            this.checkBoxName.Text = "NamedAutomaticlly";
            this.checkBoxName.UseVisualStyleBackColor = true;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dataGridShow);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrid.Location = new System.Drawing.Point(0, 98);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(163, 343);
            this.panelGrid.TabIndex = 1;
            // 
            // dataGridShow
            // 
            this.dataGridShow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridShow.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Count,
            this.Result});
            this.dataGridShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridShow.Location = new System.Drawing.Point(0, 0);
            this.dataGridShow.Name = "dataGridShow";
            this.dataGridShow.RowHeadersVisible = false;
            this.dataGridShow.RowTemplate.Height = 23;
            this.dataGridShow.Size = new System.Drawing.Size(163, 343);
            this.dataGridShow.TabIndex = 0;
            // 
            // Num
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Num.DefaultCellStyle = dataGridViewCellStyle1;
            this.Num.HeaderText = "Num";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            // 
            // Count
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Count.DefaultCellStyle = dataGridViewCellStyle2;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            // 
            // Result
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Result.DefaultCellStyle = dataGridViewCellStyle3;
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.comboBoxConfig);
            this.panelInfo.Controls.Add(this.labelConfig);
            this.panelInfo.Controls.Add(this.comboBoxNum);
            this.panelInfo.Controls.Add(this.labelNum);
            this.panelInfo.Controls.Add(this.comboBoxBatch);
            this.panelInfo.Controls.Add(this.labelBatch);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(163, 98);
            this.panelInfo.TabIndex = 0;
            // 
            // comboBoxConfig
            // 
            this.comboBoxConfig.FormattingEnabled = true;
            this.comboBoxConfig.Location = new System.Drawing.Point(52, 70);
            this.comboBoxConfig.Name = "comboBoxConfig";
            this.comboBoxConfig.Size = new System.Drawing.Size(111, 20);
            this.comboBoxConfig.TabIndex = 5;
            // 
            // labelConfig
            // 
            this.labelConfig.AutoSize = true;
            this.labelConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfig.Location = new System.Drawing.Point(2, 70);
            this.labelConfig.Name = "labelConfig";
            this.labelConfig.Size = new System.Drawing.Size(49, 17);
            this.labelConfig.TabIndex = 4;
            this.labelConfig.Text = "Config:";
            // 
            // comboBoxNum
            // 
            this.comboBoxNum.FormattingEnabled = true;
            this.comboBoxNum.Location = new System.Drawing.Point(52, 38);
            this.comboBoxNum.Name = "comboBoxNum";
            this.comboBoxNum.Size = new System.Drawing.Size(111, 20);
            this.comboBoxNum.TabIndex = 3;
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNum.Location = new System.Drawing.Point(2, 38);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(39, 17);
            this.labelNum.TabIndex = 2;
            this.labelNum.Text = "Num:";
            // 
            // comboBoxBatch
            // 
            this.comboBoxBatch.FormattingEnabled = true;
            this.comboBoxBatch.Location = new System.Drawing.Point(52, 7);
            this.comboBoxBatch.Name = "comboBoxBatch";
            this.comboBoxBatch.Size = new System.Drawing.Size(111, 20);
            this.comboBoxBatch.TabIndex = 1;
            // 
            // labelBatch
            // 
            this.labelBatch.AutoSize = true;
            this.labelBatch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBatch.Location = new System.Drawing.Point(3, 9);
            this.labelBatch.Name = "labelBatch";
            this.labelBatch.Size = new System.Drawing.Size(43, 17);
            this.labelBatch.TabIndex = 0;
            this.labelBatch.Text = "Batch:";
            // 
            // FormMeasurementMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 705);
            this.Controls.Add(this.mainShowRigon);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMeasurementMap";
            this.Text = "FormMeasurementMap";
            this.Load += new System.EventHandler(this.FormMeasurementMap_Load);
            this.SizeChanged += new System.EventHandler(this.setControls);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainShowRigon.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainShowRigon)).EndInit();
            this.mainShowRigon.ResumeLayout(false);
            this.measureShow.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.measureShow)).EndInit();
            this.measureShow.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShow)).EndInit();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStrip;
        private System.Windows.Forms.ToolStripMenuItem groupToolStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStrip;
        private System.Windows.Forms.SplitContainer mainShowRigon;
        private System.Windows.Forms.ToolStripMenuItem openToolStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStrip;
        private System.Windows.Forms.SplitContainer measureShow;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dataGridShow;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.ComboBox comboBoxNum;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.ComboBox comboBoxBatch;
        private System.Windows.Forms.Label labelBatch;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button inspectStatus;
        private System.Windows.Forms.ComboBox comboBoxConfig;
        private System.Windows.Forms.Label labelConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.CheckBox checkBoxName;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAlter;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button reinspect;
        private System.Windows.Forms.Button inspectStop;
        private System.Windows.Forms.Button currentNum;

    }
}