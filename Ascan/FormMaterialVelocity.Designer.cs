namespace Ascan
{
    partial class FormMaterialVelocity
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
            this.materialVel = new System.Windows.Forms.GroupBox();
            this.tranverse = new System.Windows.Forms.RadioButton();
            this.longitudinal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownMatVelocity = new System.Windows.Forms.NumericUpDown();
            this.materialList = new System.Windows.Forms.DataGridView();
            this.materialVel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMatVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialList)).BeginInit();
            this.SuspendLayout();
            // 
            // materialVel
            // 
            this.materialVel.Controls.Add(this.tranverse);
            this.materialVel.Controls.Add(this.longitudinal);
            this.materialVel.Controls.Add(this.label1);
            this.materialVel.Controls.Add(this.numUpDownMatVelocity);
            this.materialVel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialVel.Location = new System.Drawing.Point(3, 12);
            this.materialVel.Name = "materialVel";
            this.materialVel.Size = new System.Drawing.Size(227, 78);
            this.materialVel.TabIndex = 0;
            this.materialVel.TabStop = false;
            this.materialVel.Text = "Material Velocity";
            // 
            // tranverse
            // 
            this.tranverse.AutoSize = true;
            this.tranverse.Location = new System.Drawing.Point(130, 52);
            this.tranverse.Name = "tranverse";
            this.tranverse.Size = new System.Drawing.Size(83, 21);
            this.tranverse.TabIndex = 3;
            this.tranverse.TabStop = true;
            this.tranverse.Text = "Tranverse";
            this.tranverse.UseVisualStyleBackColor = true;
            this.tranverse.Click += new System.EventHandler(this.tranverse_Click);
            // 
            // longitudinal
            // 
            this.longitudinal.AutoSize = true;
            this.longitudinal.Location = new System.Drawing.Point(15, 52);
            this.longitudinal.Name = "longitudinal";
            this.longitudinal.Size = new System.Drawing.Size(97, 21);
            this.longitudinal.TabIndex = 2;
            this.longitudinal.TabStop = true;
            this.longitudinal.Text = "Longitudinal";
            this.longitudinal.UseVisualStyleBackColor = true;
            this.longitudinal.Click += new System.EventHandler(this.longitudinal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "m/s";
            // 
            // numUpDownMatVelocity
            // 
            this.numUpDownMatVelocity.Location = new System.Drawing.Point(15, 22);
            this.numUpDownMatVelocity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUpDownMatVelocity.Name = "numUpDownMatVelocity";
            this.numUpDownMatVelocity.Size = new System.Drawing.Size(169, 23);
            this.numUpDownMatVelocity.TabIndex = 0;
            this.numUpDownMatVelocity.Click += new System.EventHandler(this.numUpDownMatVelocity_Click);
            this.numUpDownMatVelocity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numUpDownMatVelocity_KeyPress);
            this.numUpDownMatVelocity.Leave += new System.EventHandler(this.numUpDownMatVelocity_Leave);
            // 
            // materialList
            // 
            this.materialList.AllowUserToAddRows = false;
            this.materialList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.materialList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialList.Location = new System.Drawing.Point(3, 96);
            this.materialList.Name = "materialList";
            this.materialList.RowHeadersVisible = false;
            this.materialList.RowTemplate.Height = 23;
            this.materialList.Size = new System.Drawing.Size(227, 447);
            this.materialList.TabIndex = 1;
            this.materialList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.materialList_CellClick);
            // 
            // FormMaterialVelocity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 547);
            this.Controls.Add(this.materialList);
            this.Controls.Add(this.materialVel);
            this.Name = "FormMaterialVelocity";
            this.Text = "MaterialVelocity";
            this.Load += new System.EventHandler(this.FormMaterialVelocity_Load);
            this.materialVel.ResumeLayout(false);
            this.materialVel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMatVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox materialVel;
        private System.Windows.Forms.RadioButton tranverse;
        private System.Windows.Forms.RadioButton longitudinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownMatVelocity;
        private System.Windows.Forms.DataGridView materialList;
    }
}