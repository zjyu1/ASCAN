namespace AUT
{
    partial class FormReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.batchpanel = new System.Windows.Forms.Panel();
            this.number = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelload = new System.Windows.Forms.Panel();
            this.btload = new System.Windows.Forms.Button();
            this.WeldGrid = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.load = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settingBox = new System.Windows.Forms.TextBox();
            this.productBox = new System.Windows.Forms.TextBox();
            this.bacthBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rejectBox = new System.Windows.Forms.TextBox();
            this.passednumBox = new System.Windows.Forms.TextBox();
            this.testnumBox = new System.Windows.Forms.TextBox();
            this.rejectnum = new System.Windows.Forms.Label();
            this.passednum = new System.Windows.Forms.Label();
            this.testnum = new System.Windows.Forms.Label();
            this.custom = new System.Windows.Forms.Button();
            this.Defult = new System.Windows.Forms.Button();
            this.printbtn = new System.Windows.Forms.Button();
            this.loadbtn = new System.Windows.Forms.Button();
            this.selectallRbt = new System.Windows.Forms.RadioButton();
            this.settinglabel = new System.Windows.Forms.Label();
            this.productlabel = new System.Windows.Forms.Label();
            this.bacthlabel = new System.Windows.Forms.Label();
            this.mainArea = new System.Windows.Forms.SplitContainer();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.button1 = new System.Windows.Forms.Button();
            this.batchpanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeldGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainArea)).BeginInit();
            this.mainArea.Panel1.SuspendLayout();
            this.mainArea.Panel2.SuspendLayout();
            this.mainArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // batchpanel
            // 
            this.batchpanel.AutoScroll = true;
            this.batchpanel.BackColor = System.Drawing.SystemColors.Window;
            this.batchpanel.Controls.Add(this.button1);
            this.batchpanel.Controls.Add(this.number);
            this.batchpanel.Controls.Add(this.panel2);
            this.batchpanel.Controls.Add(this.settingBox);
            this.batchpanel.Controls.Add(this.productBox);
            this.batchpanel.Controls.Add(this.bacthBox);
            this.batchpanel.Controls.Add(this.panel1);
            this.batchpanel.Controls.Add(this.custom);
            this.batchpanel.Controls.Add(this.Defult);
            this.batchpanel.Controls.Add(this.printbtn);
            this.batchpanel.Controls.Add(this.loadbtn);
            this.batchpanel.Controls.Add(this.selectallRbt);
            this.batchpanel.Controls.Add(this.settinglabel);
            this.batchpanel.Controls.Add(this.productlabel);
            this.batchpanel.Controls.Add(this.bacthlabel);
            this.batchpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.batchpanel.Location = new System.Drawing.Point(0, 0);
            this.batchpanel.Name = "batchpanel";
            this.batchpanel.Size = new System.Drawing.Size(238, 619);
            this.batchpanel.TabIndex = 1;
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.number.Location = new System.Drawing.Point(15, 466);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(56, 17);
            this.number.TabIndex = 14;
            this.number.Text = "Number";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelload);
            this.panel2.Controls.Add(this.WeldGrid);
            this.panel2.Location = new System.Drawing.Point(5, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 168);
            this.panel2.TabIndex = 23;
            // 
            // panelload
            // 
            this.panelload.Controls.Add(this.btload);
            this.panelload.Location = new System.Drawing.Point(55, 64);
            this.panelload.Name = "panelload";
            this.panelload.Size = new System.Drawing.Size(55, 24);
            this.panelload.TabIndex = 22;
            this.panelload.Visible = false;
            // 
            // btload
            // 
            this.btload.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btload.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btload.Location = new System.Drawing.Point(0, 0);
            this.btload.Name = "btload";
            this.btload.Size = new System.Drawing.Size(55, 24);
            this.btload.TabIndex = 0;
            this.btload.Text = "Load";
            this.btload.UseVisualStyleBackColor = false;
            this.btload.Click += new System.EventHandler(this.btload_Click);
            // 
            // WeldGrid
            // 
            this.WeldGrid.AllowUserToAddRows = false;
            this.WeldGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WeldGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.WeldGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.WeldGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeldGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.time,
            this.result,
            this.load});
            this.WeldGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeldGrid.Location = new System.Drawing.Point(0, 0);
            this.WeldGrid.Name = "WeldGrid";
            this.WeldGrid.ReadOnly = true;
            this.WeldGrid.RowHeadersVisible = false;
            this.WeldGrid.RowTemplate.Height = 23;
            this.WeldGrid.Size = new System.Drawing.Size(219, 168);
            this.WeldGrid.TabIndex = 7;
            this.WeldGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WeldGrid_CellClick);
            // 
            // num
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.num.DefaultCellStyle = dataGridViewCellStyle2;
            this.num.HeaderText = "Num";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // time
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.time.DefaultCellStyle = dataGridViewCellStyle3;
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // result
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.result.DefaultCellStyle = dataGridViewCellStyle4;
            this.result.HeaderText = "Result";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            // 
            // load
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.load.DefaultCellStyle = dataGridViewCellStyle5;
            this.load.HeaderText = "Load";
            this.load.Name = "load";
            this.load.ReadOnly = true;
            // 
            // settingBox
            // 
            this.settingBox.Location = new System.Drawing.Point(92, 91);
            this.settingBox.Name = "settingBox";
            this.settingBox.ReadOnly = true;
            this.settingBox.Size = new System.Drawing.Size(104, 21);
            this.settingBox.TabIndex = 21;
            // 
            // productBox
            // 
            this.productBox.Location = new System.Drawing.Point(92, 57);
            this.productBox.Name = "productBox";
            this.productBox.ReadOnly = true;
            this.productBox.Size = new System.Drawing.Size(104, 21);
            this.productBox.TabIndex = 20;
            // 
            // bacthBox
            // 
            this.bacthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bacthBox.FormattingEnabled = true;
            this.bacthBox.Location = new System.Drawing.Point(92, 24);
            this.bacthBox.Name = "bacthBox";
            this.bacthBox.Size = new System.Drawing.Size(104, 20);
            this.bacthBox.TabIndex = 0;
            this.bacthBox.SelectedIndexChanged += new System.EventHandler(this.bacthBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rejectBox);
            this.panel1.Controls.Add(this.passednumBox);
            this.panel1.Controls.Add(this.testnumBox);
            this.panel1.Controls.Add(this.rejectnum);
            this.panel1.Controls.Add(this.passednum);
            this.panel1.Controls.Add(this.testnum);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(11, 478);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 129);
            this.panel1.TabIndex = 13;
            // 
            // rejectBox
            // 
            this.rejectBox.Location = new System.Drawing.Point(92, 84);
            this.rejectBox.Name = "rejectBox";
            this.rejectBox.ReadOnly = true;
            this.rejectBox.Size = new System.Drawing.Size(100, 23);
            this.rejectBox.TabIndex = 19;
            // 
            // passednumBox
            // 
            this.passednumBox.Location = new System.Drawing.Point(92, 53);
            this.passednumBox.Name = "passednumBox";
            this.passednumBox.ReadOnly = true;
            this.passednumBox.Size = new System.Drawing.Size(100, 23);
            this.passednumBox.TabIndex = 18;
            // 
            // testnumBox
            // 
            this.testnumBox.Location = new System.Drawing.Point(92, 22);
            this.testnumBox.Name = "testnumBox";
            this.testnumBox.ReadOnly = true;
            this.testnumBox.Size = new System.Drawing.Size(100, 23);
            this.testnumBox.TabIndex = 0;
            // 
            // rejectnum
            // 
            this.rejectnum.AutoSize = true;
            this.rejectnum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rejectnum.Location = new System.Drawing.Point(9, 87);
            this.rejectnum.Name = "rejectnum";
            this.rejectnum.Size = new System.Drawing.Size(74, 17);
            this.rejectnum.TabIndex = 17;
            this.rejectnum.Text = "RejectNum:";
            // 
            // passednum
            // 
            this.passednum.AutoSize = true;
            this.passednum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passednum.Location = new System.Drawing.Point(9, 56);
            this.passednum.Name = "passednum";
            this.passednum.Size = new System.Drawing.Size(80, 17);
            this.passednum.TabIndex = 16;
            this.passednum.Text = "PassedNum:";
            // 
            // testnum
            // 
            this.testnum.AutoSize = true;
            this.testnum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.testnum.Location = new System.Drawing.Point(9, 25);
            this.testnum.Name = "testnum";
            this.testnum.Size = new System.Drawing.Size(63, 17);
            this.testnum.TabIndex = 15;
            this.testnum.Text = "TestNum:";
            // 
            // custom
            // 
            this.custom.BackColor = System.Drawing.SystemColors.Control;
            this.custom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.custom.Location = new System.Drawing.Point(30, 424);
            this.custom.Name = "custom";
            this.custom.Size = new System.Drawing.Size(183, 39);
            this.custom.TabIndex = 12;
            this.custom.Text = "Custom Templet";
            this.custom.UseVisualStyleBackColor = false;
            // 
            // Defult
            // 
            this.Defult.BackColor = System.Drawing.SystemColors.Control;
            this.Defult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Defult.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Defult.Location = new System.Drawing.Point(30, 379);
            this.Defult.Name = "Defult";
            this.Defult.Size = new System.Drawing.Size(183, 39);
            this.Defult.TabIndex = 11;
            this.Defult.Text = "Defult Templet";
            this.Defult.UseVisualStyleBackColor = false;
            this.Defult.Click += new System.EventHandler(this.Defult_Click);
            // 
            // printbtn
            // 
            this.printbtn.BackColor = System.Drawing.SystemColors.Control;
            this.printbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printbtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.printbtn.Location = new System.Drawing.Point(138, 337);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(75, 23);
            this.printbtn.TabIndex = 10;
            this.printbtn.Text = "Print";
            this.printbtn.UseVisualStyleBackColor = false;
            // 
            // loadbtn
            // 
            this.loadbtn.BackColor = System.Drawing.SystemColors.Control;
            this.loadbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadbtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loadbtn.Location = new System.Drawing.Point(30, 337);
            this.loadbtn.Name = "loadbtn";
            this.loadbtn.Size = new System.Drawing.Size(75, 23);
            this.loadbtn.TabIndex = 9;
            this.loadbtn.Text = "LoadFile";
            this.loadbtn.UseVisualStyleBackColor = false;
            this.loadbtn.Click += new System.EventHandler(this.loadbtn_Click);
            // 
            // selectallRbt
            // 
            this.selectallRbt.AutoSize = true;
            this.selectallRbt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectallRbt.Location = new System.Drawing.Point(12, 303);
            this.selectallRbt.Name = "selectallRbt";
            this.selectallRbt.Size = new System.Drawing.Size(74, 21);
            this.selectallRbt.TabIndex = 8;
            this.selectallRbt.TabStop = true;
            this.selectallRbt.Text = "SelectAll";
            this.selectallRbt.UseVisualStyleBackColor = true;
            // 
            // settinglabel
            // 
            this.settinglabel.AutoSize = true;
            this.settinglabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settinglabel.Location = new System.Drawing.Point(24, 91);
            this.settinglabel.Name = "settinglabel";
            this.settinglabel.Size = new System.Drawing.Size(51, 17);
            this.settinglabel.TabIndex = 5;
            this.settinglabel.Text = "Setting:";
            // 
            // productlabel
            // 
            this.productlabel.AutoSize = true;
            this.productlabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productlabel.Location = new System.Drawing.Point(24, 57);
            this.productlabel.Name = "productlabel";
            this.productlabel.Size = new System.Drawing.Size(56, 17);
            this.productlabel.TabIndex = 3;
            this.productlabel.Text = "Product:";
            // 
            // bacthlabel
            // 
            this.bacthlabel.AutoSize = true;
            this.bacthlabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bacthlabel.Location = new System.Drawing.Point(24, 24);
            this.bacthlabel.Name = "bacthlabel";
            this.bacthlabel.Size = new System.Drawing.Size(43, 17);
            this.bacthlabel.TabIndex = 1;
            this.bacthlabel.Text = "Bacth:";
            // 
            // mainArea
            // 
            this.mainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainArea.Location = new System.Drawing.Point(238, 0);
            this.mainArea.Name = "mainArea";
            // 
            // mainArea.Panel1
            // 
            this.mainArea.Panel1.Controls.Add(this.panelTotal);
            // 
            // mainArea.Panel2
            // 
            this.mainArea.Panel2.Controls.Add(this.vScrollBar);
            this.mainArea.Panel2MinSize = 10;
            this.mainArea.Size = new System.Drawing.Size(901, 619);
            this.mainArea.SplitterDistance = 871;
            this.mainArea.SplitterWidth = 1;
            this.mainArea.TabIndex = 1;
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotal.Location = new System.Drawing.Point(0, 0);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(871, 619);
            this.panelTotal.TabIndex = 0;
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Location = new System.Drawing.Point(15, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(14, 619);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 619);
            this.Controls.Add(this.mainArea);
            this.Controls.Add(this.batchpanel);
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReport_FormClosing);
            this.SizeChanged += new System.EventHandler(this.FormReport_SizeChanged);
            this.batchpanel.ResumeLayout(false);
            this.batchpanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WeldGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainArea.Panel1.ResumeLayout(false);
            this.mainArea.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainArea)).EndInit();
            this.mainArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel batchpanel;
        private System.Windows.Forms.Label productlabel;
        private System.Windows.Forms.Label bacthlabel;
        private System.Windows.Forms.Label number;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox rejectBox;
        private System.Windows.Forms.TextBox passednumBox;
        private System.Windows.Forms.TextBox testnumBox;
        private System.Windows.Forms.Label rejectnum;
        private System.Windows.Forms.Label passednum;
        private System.Windows.Forms.Label testnum;
        private System.Windows.Forms.Button custom;
        private System.Windows.Forms.Button Defult;
        private System.Windows.Forms.Button printbtn;
        private System.Windows.Forms.Button loadbtn;
        private System.Windows.Forms.RadioButton selectallRbt;
        private System.Windows.Forms.DataGridView WeldGrid;
        private System.Windows.Forms.Label settinglabel;
        private System.Windows.Forms.ComboBox bacthBox;
        private System.Windows.Forms.SplitContainer mainArea;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.TextBox settingBox;
        private System.Windows.Forms.TextBox productBox;
        private System.Windows.Forms.Panel panelload;
        private System.Windows.Forms.Button btload;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn load;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
    }
}