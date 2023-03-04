namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    // TJB  RPCR_060  Mar-2014: NEW

    partial class DHsType
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private Metex.Windows.DataEntityGrid grid;
		#region Component Designer generated code
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.hst_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HstHelp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HstAdditionalDateErrmsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HstNotesErrmsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.HSType);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hst_name,
            this.HstHelp,
            this.HstAdditionalDateErrmsg,
            this.HstNotesErrmsg});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(688, 252);
            this.grid.TabIndex = 0;
            // 
            // hst_name
            // 
            this.hst_name.DataPropertyName = "HstName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hst_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.hst_name.HeaderText = "HS Type";
            this.hst_name.Name = "hst_name";
            this.hst_name.Width = 160;
            // 
            // HstHelp
            // 
            this.HstHelp.DataPropertyName = "HstHelp";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HstHelp.DefaultCellStyle = dataGridViewCellStyle3;
            this.HstHelp.HeaderText = "Notes Help";
            this.HstHelp.Name = "HstHelp";
            this.HstHelp.Width = 175;
            // 
            // HstAdditionalDateErrmsg
            // 
            this.HstAdditionalDateErrmsg.DataPropertyName = "HstAdditionalDateErrmsg";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HstAdditionalDateErrmsg.DefaultCellStyle = dataGridViewCellStyle4;
            this.HstAdditionalDateErrmsg.HeaderText = "Additional Date Error Msg";
            this.HstAdditionalDateErrmsg.Name = "HstAdditionalDateErrmsg";
            this.HstAdditionalDateErrmsg.Width = 175;
            // 
            // HstNotesErrmsg
            // 
            this.HstNotesErrmsg.DataPropertyName = "HstNotesErrmsg";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HstNotesErrmsg.DefaultCellStyle = dataGridViewCellStyle5;
            this.HstNotesErrmsg.HeaderText = "Notes Error Msg";
            this.HstNotesErrmsg.Name = "HstNotesErrmsg";
            this.HstNotesErrmsg.Width = 175;
            // 
            // DHsType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DHsType";
            this.Size = new System.Drawing.Size(688, 252);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn hst_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn HstHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn HstAdditionalDateErrmsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn HstNotesErrmsg;






    }
}
