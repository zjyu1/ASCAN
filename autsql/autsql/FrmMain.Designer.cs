namespace autsql
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataBatch = new System.Windows.Forms.DataGridView();
            this.batchmanagementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mEDataSet = new autsql.MEDataSet();
            this.btnNwOrder = new System.Windows.Forms.Button();
            this.btnOpOrder = new System.Windows.Forms.Button();
            this.btnDelOrder = new System.Windows.Forms.Button();
            this.btnPakOrder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textOrder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textSize = new System.Windows.Forms.TextBox();
            this.batchmanagementTableAdapter = new autsql.MEDataSetTableAdapters.batchmanagementTableAdapter();
            this.btnEdBatch = new System.Windows.Forms.Button();
            this.btnNwBatch = new System.Windows.Forms.Button();
            this.btnDelBatch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOptbl = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchmanagementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataBatch
            // 
            this.dataBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBatch.Location = new System.Drawing.Point(18, 97);
            this.dataBatch.Name = "dataBatch";
            this.dataBatch.RowTemplate.Height = 23;
            this.dataBatch.Size = new System.Drawing.Size(777, 287);
            this.dataBatch.TabIndex = 0;
            this.dataBatch.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataBatch_CellEndEdit);
            // 
            // batchmanagementBindingSource
            // 
            this.batchmanagementBindingSource.DataMember = "batchmanagement";
            this.batchmanagementBindingSource.DataSource = this.mEDataSet;
            // 
            // mEDataSet
            // 
            this.mEDataSet.DataSetName = "MEDataSet";
            this.mEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnNwOrder
            // 
            this.btnNwOrder.Location = new System.Drawing.Point(4, 28);
            this.btnNwOrder.Name = "btnNwOrder";
            this.btnNwOrder.Size = new System.Drawing.Size(75, 23);
            this.btnNwOrder.TabIndex = 2;
            this.btnNwOrder.Text = "新建";
            this.btnNwOrder.UseVisualStyleBackColor = true;
            this.btnNwOrder.Click += new System.EventHandler(this.btnNwOrder_Click);
            // 
            // btnOpOrder
            // 
            this.btnOpOrder.Font = new System.Drawing.Font("宋体", 9F);
            this.btnOpOrder.Location = new System.Drawing.Point(96, 28);
            this.btnOpOrder.Name = "btnOpOrder";
            this.btnOpOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOpOrder.TabIndex = 3;
            this.btnOpOrder.Text = "打开订单";
            this.btnOpOrder.UseVisualStyleBackColor = true;
            this.btnOpOrder.Click += new System.EventHandler(this.btnOpOrder_Click);
            // 
            // btnDelOrder
            // 
            this.btnDelOrder.Font = new System.Drawing.Font("宋体", 10F);
            this.btnDelOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelOrder.Location = new System.Drawing.Point(187, 28);
            this.btnDelOrder.Name = "btnDelOrder";
            this.btnDelOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDelOrder.TabIndex = 4;
            this.btnDelOrder.Text = "删除订单";
            this.btnDelOrder.UseVisualStyleBackColor = true;
            this.btnDelOrder.Click += new System.EventHandler(this.btnDelOrder_Click);
            // 
            // btnPakOrder
            // 
            this.btnPakOrder.Location = new System.Drawing.Point(284, 28);
            this.btnPakOrder.Name = "btnPakOrder";
            this.btnPakOrder.Size = new System.Drawing.Size(75, 23);
            this.btnPakOrder.TabIndex = 5;
            this.btnPakOrder.Text = "打包";
            this.btnPakOrder.UseVisualStyleBackColor = true;
            this.btnPakOrder.Click += new System.EventHandler(this.btnPakOrder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "订单号";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textOrder
            // 
            this.textOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textOrder.Location = new System.Drawing.Point(484, 31);
            this.textOrder.Name = "textOrder";
            this.textOrder.ReadOnly = true;
            this.textOrder.Size = new System.Drawing.Size(100, 26);
            this.textOrder.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(665, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "大小";
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(719, 46);
            this.textSize.Name = "textSize";
            this.textSize.ReadOnly = true;
            this.textSize.Size = new System.Drawing.Size(57, 21);
            this.textSize.TabIndex = 10;
            // 
            // batchmanagementTableAdapter
            // 
            this.batchmanagementTableAdapter.ClearBeforeFill = true;
            // 
            // btnEdBatch
            // 
            this.btnEdBatch.Location = new System.Drawing.Point(124, 403);
            this.btnEdBatch.Name = "btnEdBatch";
            this.btnEdBatch.Size = new System.Drawing.Size(75, 23);
            this.btnEdBatch.TabIndex = 11;
            this.btnEdBatch.Text = "编辑";
            this.btnEdBatch.UseVisualStyleBackColor = true;
            this.btnEdBatch.Click += new System.EventHandler(this.btnEdBatch_Click);
            // 
            // btnNwBatch
            // 
            this.btnNwBatch.Location = new System.Drawing.Point(18, 403);
            this.btnNwBatch.Name = "btnNwBatch";
            this.btnNwBatch.Size = new System.Drawing.Size(75, 23);
            this.btnNwBatch.TabIndex = 12;
            this.btnNwBatch.Text = "增加";
            this.btnNwBatch.UseVisualStyleBackColor = true;
            this.btnNwBatch.Click += new System.EventHandler(this.btnNwBatch_Click);
            // 
            // btnDelBatch
            // 
            this.btnDelBatch.Location = new System.Drawing.Point(232, 403);
            this.btnDelBatch.Name = "btnDelBatch";
            this.btnDelBatch.Size = new System.Drawing.Size(75, 23);
            this.btnDelBatch.TabIndex = 13;
            this.btnDelBatch.Text = "删除";
            this.btnDelBatch.UseVisualStyleBackColor = true;
            this.btnDelBatch.Click += new System.EventHandler(this.btnDelBatch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textOrder);
            this.groupBox1.Controls.Add(this.btnDelOrder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPakOrder);
            this.groupBox1.Controls.Add(this.btnOpOrder);
            this.groupBox1.Controls.Add(this.btnNwOrder);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 67);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单";
            // 
            // btnOptbl
            // 
            this.btnOptbl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOptbl.Location = new System.Drawing.Point(3, 3);
            this.btnOptbl.Name = "btnOptbl";
            this.btnOptbl.Size = new System.Drawing.Size(59, 28);
            this.btnOptbl.TabIndex = 18;
            this.btnOptbl.Text = "打开表";
            this.btnOptbl.UseVisualStyleBackColor = true;
            this.btnOptbl.Click += new System.EventHandler(this.btnOptbl_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(647, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 67);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(463, 406);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(350, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "测试用按钮";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "更改add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnOptbl);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(605, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 57);
            this.panel1.TabIndex = 22;
            this.panel1.Tag = "";
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btndelete.Location = new System.Drawing.Point(3, 33);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(82, 23);
            this.btndelete.TabIndex = 8;
            this.btndelete.Text = "删除表";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 454);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDelBatch);
            this.Controls.Add(this.btnNwBatch);
            this.Controls.Add(this.btnEdBatch);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataBatch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmMain";
            this.Text = "批次管理";
            this.Activated += new System.EventHandler(this.FrmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchmanagementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataBatch;
        private System.Windows.Forms.Button btnNwOrder;
        private System.Windows.Forms.Button btnOpOrder;
        private System.Windows.Forms.Button btnDelOrder;
        private System.Windows.Forms.Button btnPakOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textSize;
        private MEDataSet mEDataSet;
        private System.Windows.Forms.BindingSource batchmanagementBindingSource;
        private MEDataSetTableAdapters.batchmanagementTableAdapter batchmanagementTableAdapter;
        private System.Windows.Forms.Button btnEdBatch;
        private System.Windows.Forms.Button btnNwBatch;
        private System.Windows.Forms.Button btnDelBatch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox textOrder;
        private System.Windows.Forms.Button btnOptbl;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btndelete;
    }
}

