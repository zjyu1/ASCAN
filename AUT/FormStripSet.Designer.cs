namespace AUT
{
    partial class FormStripSet
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
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMode = new System.Windows.Forms.Panel();
            this.labelMode = new System.Windows.Forms.Label();
            this.panelActive = new System.Windows.Forms.Panel();
            this.labelActive = new System.Windows.Forms.Label();
            this.panelCycle = new System.Windows.Forms.Panel();
            this.labelCycle = new System.Windows.Forms.Label();
            this.panelSource = new System.Windows.Forms.Panel();
            this.labelSource = new System.Windows.Forms.Label();
            this.btLoad = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMode.SuspendLayout();
            this.panelActive.SuspendLayout();
            this.panelCycle.SuspendLayout();
            this.panelSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.AliceBlue;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightYellow;
            this.splitContainer1.Panel2.Controls.Add(this.btLoad);
            this.splitContainer1.Panel2.Controls.Add(this.btSave);
            this.splitContainer1.Panel2.Controls.Add(this.btDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btAdd);
            this.splitContainer1.Size = new System.Drawing.Size(602, 360);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMode);
            this.panel1.Controls.Add(this.panelActive);
            this.panel1.Controls.Add(this.panelCycle);
            this.panel1.Controls.Add(this.panelSource);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 27);
            this.panel1.TabIndex = 7;
            // 
            // panelMode
            // 
            this.panelMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMode.Controls.Add(this.labelMode);
            this.panelMode.Location = new System.Drawing.Point(300, 0);
            this.panelMode.Name = "panelMode";
            this.panelMode.Size = new System.Drawing.Size(150, 25);
            this.panelMode.TabIndex = 4;
            // 
            // labelMode
            // 
            this.labelMode.BackColor = System.Drawing.Color.AliceBlue;
            this.labelMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMode.Location = new System.Drawing.Point(0, 0);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(148, 23);
            this.labelMode.TabIndex = 0;
            this.labelMode.Text = "Mode";
            this.labelMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelActive
            // 
            this.panelActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActive.Controls.Add(this.labelActive);
            this.panelActive.Location = new System.Drawing.Point(450, 0);
            this.panelActive.Name = "panelActive";
            this.panelActive.Size = new System.Drawing.Size(150, 25);
            this.panelActive.TabIndex = 6;
            // 
            // labelActive
            // 
            this.labelActive.BackColor = System.Drawing.Color.AliceBlue;
            this.labelActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelActive.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelActive.Location = new System.Drawing.Point(0, 0);
            this.labelActive.Name = "labelActive";
            this.labelActive.Size = new System.Drawing.Size(148, 23);
            this.labelActive.TabIndex = 0;
            this.labelActive.Text = "Active";
            this.labelActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCycle
            // 
            this.panelCycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCycle.Controls.Add(this.labelCycle);
            this.panelCycle.Location = new System.Drawing.Point(0, 0);
            this.panelCycle.Name = "panelCycle";
            this.panelCycle.Size = new System.Drawing.Size(150, 25);
            this.panelCycle.TabIndex = 2;
            // 
            // labelCycle
            // 
            this.labelCycle.BackColor = System.Drawing.Color.AliceBlue;
            this.labelCycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCycle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCycle.Location = new System.Drawing.Point(0, 0);
            this.labelCycle.Name = "labelCycle";
            this.labelCycle.Size = new System.Drawing.Size(148, 23);
            this.labelCycle.TabIndex = 0;
            this.labelCycle.Text = "Cycle";
            this.labelCycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSource
            // 
            this.panelSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSource.Controls.Add(this.labelSource);
            this.panelSource.Location = new System.Drawing.Point(150, 0);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(150, 25);
            this.panelSource.TabIndex = 3;
            // 
            // labelSource
            // 
            this.labelSource.BackColor = System.Drawing.Color.AliceBlue;
            this.labelSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSource.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSource.Location = new System.Drawing.Point(0, 0);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(148, 23);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Source";
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btLoad
            // 
            this.btLoad.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btLoad.Location = new System.Drawing.Point(485, 16);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(80, 30);
            this.btLoad.TabIndex = 10;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSave.Location = new System.Drawing.Point(335, 16);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(80, 30);
            this.btSave.TabIndex = 9;
            this.btSave.Text = "Save to file";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btDelete
            // 
            this.btDelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelete.Location = new System.Drawing.Point(185, 16);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(80, 30);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btAdd.Location = new System.Drawing.Point(35, 16);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(80, 30);
            this.btAdd.TabIndex = 7;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // FormStripSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 360);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormStripSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStripSet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStripSet_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelMode.ResumeLayout(false);
            this.panelActive.ResumeLayout(false);
            this.panelCycle.ResumeLayout(false);
            this.panelSource.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelCycle;
        private System.Windows.Forms.Label labelCycle;
        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Panel panelMode;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Panel panelActive;
        private System.Windows.Forms.Label labelActive;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btDelete;


    }
}