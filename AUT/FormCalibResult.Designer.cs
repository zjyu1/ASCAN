namespace AUT
{
    partial class FormCalibResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.isCalibrated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.session = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibrateValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.areaComboBox = new System.Windows.Forms.ComboBox();
            this.gateLabel = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.gateComboBox = new System.Windows.Forms.ComboBox();
            this.dircComboBox = new System.Windows.Forms.ComboBox();
            this.dircLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ensureButton = new System.Windows.Forms.Button();
            this.nonCalibrateButton = new System.Windows.Forms.Button();
            this.chooseNoneButton = new System.Windows.Forms.Button();
            this.chooseAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.AllowUserToAddRows = false;
            this.resultDataGridView.AllowUserToResizeColumns = false;
            this.resultDataGridView.AllowUserToResizeRows = false;
            this.resultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isCalibrated,
            this.type,
            this.area,
            this.direction,
            this.session,
            this.value,
            this.calibrateValue});
            this.resultDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGridView.Location = new System.Drawing.Point(0, 0);
            this.resultDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.RowHeadersVisible = false;
            this.resultDataGridView.RowTemplate.Height = 27;
            this.resultDataGridView.Size = new System.Drawing.Size(736, 286);
            this.resultDataGridView.TabIndex = 8;
            // 
            // isCalibrated
            // 
            this.isCalibrated.HeaderText = "校准？";
            this.isCalibrated.Name = "isCalibrated";
            // 
            // type
            // 
            this.type.HeaderText = "类型";
            this.type.Name = "type";
            // 
            // area
            // 
            this.area.HeaderText = "区域";
            this.area.Name = "area";
            // 
            // direction
            // 
            this.direction.HeaderText = "方向";
            this.direction.Name = "direction";
            // 
            // session
            // 
            this.session.HeaderText = "通道";
            this.session.Name = "session";
            // 
            // value
            // 
            this.value.HeaderText = "幅度(%)";
            this.value.Name = "value";
            // 
            // calibrateValue
            // 
            this.calibrateValue.HeaderText = "校准量(%)";
            this.calibrateValue.Name = "calibrateValue";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.typeComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.areaComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.gateLabel);
            this.splitContainer1.Panel1.Controls.Add(this.areaLabel);
            this.splitContainer1.Panel1.Controls.Add(this.gateComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.dircComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.dircLabel);
            this.splitContainer1.Panel1.Controls.Add(this.typeLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(793, 452);
            this.splitContainer1.SplitterDistance = 44;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 9;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "FILL",
            "HP",
            "LCP",
            "ROOT",
            "ALL"});
            this.typeComboBox.Location = new System.Drawing.Point(82, 18);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(70, 20);
            this.typeComboBox.TabIndex = 4;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.typeComboBox_SelectedIndexChanged);
            // 
            // areaComboBox
            // 
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.Location = new System.Drawing.Point(208, 18);
            this.areaComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(70, 20);
            this.areaComboBox.TabIndex = 5;
            this.areaComboBox.SelectedIndexChanged += new System.EventHandler(this.areaComboBox_SelectedIndexChanged);
            // 
            // gateLabel
            // 
            this.gateLabel.AutoSize = true;
            this.gateLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gateLabel.Location = new System.Drawing.Point(426, 18);
            this.gateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gateLabel.Name = "gateLabel";
            this.gateLabel.Size = new System.Drawing.Size(20, 17);
            this.gateLabel.TabIndex = 3;
            this.gateLabel.Text = "门";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.areaLabel.Location = new System.Drawing.Point(174, 18);
            this.areaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(32, 17);
            this.areaLabel.TabIndex = 1;
            this.areaLabel.Text = "区域";
            // 
            // gateComboBox
            // 
            this.gateComboBox.FormattingEnabled = true;
            this.gateComboBox.Location = new System.Drawing.Point(452, 18);
            this.gateComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.gateComboBox.Name = "gateComboBox";
            this.gateComboBox.Size = new System.Drawing.Size(70, 20);
            this.gateComboBox.TabIndex = 7;
            // 
            // dircComboBox
            // 
            this.dircComboBox.FormattingEnabled = true;
            this.dircComboBox.Items.AddRange(new object[] {
            "R",
            "L",
            "ALL"});
            this.dircComboBox.Location = new System.Drawing.Point(334, 18);
            this.dircComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.dircComboBox.Name = "dircComboBox";
            this.dircComboBox.Size = new System.Drawing.Size(70, 20);
            this.dircComboBox.TabIndex = 6;
            this.dircComboBox.SelectedIndexChanged += new System.EventHandler(this.dircComboBox_SelectedIndexChanged);
            // 
            // dircLabel
            // 
            this.dircLabel.AutoSize = true;
            this.dircLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dircLabel.Location = new System.Drawing.Point(300, 18);
            this.dircLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dircLabel.Name = "dircLabel";
            this.dircLabel.Size = new System.Drawing.Size(32, 17);
            this.dircLabel.TabIndex = 2;
            this.dircLabel.Text = "方向";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.typeLabel.Location = new System.Drawing.Point(48, 18);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(32, 17);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "类型";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cancelButton);
            this.splitContainer2.Panel2.Controls.Add(this.ensureButton);
            this.splitContainer2.Panel2.Controls.Add(this.nonCalibrateButton);
            this.splitContainer2.Panel2.Controls.Add(this.chooseNoneButton);
            this.splitContainer2.Panel2.Controls.Add(this.chooseAllButton);
            this.splitContainer2.Size = new System.Drawing.Size(793, 405);
            this.splitContainer2.SplitterDistance = 286;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(793, 286);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.resultDataGridView);
            this.splitContainer4.Size = new System.Drawing.Size(765, 286);
            this.splitContainer4.SplitterDistance = 736;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelButton.Location = new System.Drawing.Point(712, 51);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(68, 27);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ensureButton
            // 
            this.ensureButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ensureButton.Location = new System.Drawing.Point(638, 51);
            this.ensureButton.Margin = new System.Windows.Forms.Padding(2);
            this.ensureButton.Name = "ensureButton";
            this.ensureButton.Size = new System.Drawing.Size(68, 27);
            this.ensureButton.TabIndex = 3;
            this.ensureButton.Text = "确认";
            this.ensureButton.UseVisualStyleBackColor = true;
            this.ensureButton.Click += new System.EventHandler(this.ensureButton_Click);
            // 
            // nonCalibrateButton
            // 
            this.nonCalibrateButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nonCalibrateButton.Location = new System.Drawing.Point(212, 13);
            this.nonCalibrateButton.Margin = new System.Windows.Forms.Padding(2);
            this.nonCalibrateButton.Name = "nonCalibrateButton";
            this.nonCalibrateButton.Size = new System.Drawing.Size(68, 27);
            this.nonCalibrateButton.TabIndex = 2;
            this.nonCalibrateButton.Text = "仅选未校准";
            this.nonCalibrateButton.UseVisualStyleBackColor = true;
            this.nonCalibrateButton.Click += new System.EventHandler(this.nonCalibrateButton_Click);
            // 
            // chooseNoneButton
            // 
            this.chooseNoneButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chooseNoneButton.Location = new System.Drawing.Point(137, 13);
            this.chooseNoneButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseNoneButton.Name = "chooseNoneButton";
            this.chooseNoneButton.Size = new System.Drawing.Size(68, 27);
            this.chooseNoneButton.TabIndex = 1;
            this.chooseNoneButton.Text = "全不选";
            this.chooseNoneButton.UseVisualStyleBackColor = true;
            this.chooseNoneButton.Click += new System.EventHandler(this.chooseNoneButton_Click);
            // 
            // chooseAllButton
            // 
            this.chooseAllButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chooseAllButton.Location = new System.Drawing.Point(58, 13);
            this.chooseAllButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseAllButton.Name = "chooseAllButton";
            this.chooseAllButton.Size = new System.Drawing.Size(68, 27);
            this.chooseAllButton.TabIndex = 0;
            this.chooseAllButton.Text = "全选";
            this.chooseAllButton.UseVisualStyleBackColor = true;
            this.chooseAllButton.Click += new System.EventHandler(this.chooseAllButton_Click);
            // 
            // FormCalibResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 452);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCalibResult";
            this.Text = "校准结果";
            this.Load += new System.EventHandler(this.FormCalibResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCalibrated;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
        private System.Windows.Forms.DataGridViewTextBoxColumn direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn session;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibrateValue;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button nonCalibrateButton;
        private System.Windows.Forms.Button chooseNoneButton;
        private System.Windows.Forms.Button chooseAllButton;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.ComboBox areaComboBox;
        private System.Windows.Forms.Label gateLabel;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.ComboBox gateComboBox;
        private System.Windows.Forms.ComboBox dircComboBox;
        private System.Windows.Forms.Label dircLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button ensureButton;
    }
}