namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DEclQualityMappings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ecl_column_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ecl_match_string;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ecl_match_type;

	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private Metex.Windows.DataEntityGrid grid;
		public Metex.Windows.DataEntityGrid Grid
		{
			get
			{
				return grid;
			}
		}

		#region Component Designer generated code
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.eclColumnNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eclMatchStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eclMatchTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.EclQualityMappings);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 32;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eclColumnNameDataGridViewTextBoxColumn,
            this.eclMatchStringDataGridViewTextBoxColumn,
            this.eclMatchTypeDataGridViewTextBoxColumn});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(489, 228);
            this.grid.TabIndex = 0;
            // 
            // eclColumnNameDataGridViewTextBoxColumn
            // 
            this.eclColumnNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.eclColumnNameDataGridViewTextBoxColumn.DataPropertyName = "EclColumnName";
            this.eclColumnNameDataGridViewTextBoxColumn.HeaderText = "Ecl Column Name";
            this.eclColumnNameDataGridViewTextBoxColumn.Name = "eclColumnNameDataGridViewTextBoxColumn";
            this.eclColumnNameDataGridViewTextBoxColumn.Width = 132;
            // 
            // eclMatchStringDataGridViewTextBoxColumn
            // 
            this.eclMatchStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.eclMatchStringDataGridViewTextBoxColumn.DataPropertyName = "EclMatchString";
            this.eclMatchStringDataGridViewTextBoxColumn.FillWeight = 120F;
            this.eclMatchStringDataGridViewTextBoxColumn.HeaderText = "Ecl Match String";
            this.eclMatchStringDataGridViewTextBoxColumn.Name = "eclMatchStringDataGridViewTextBoxColumn";
            this.eclMatchStringDataGridViewTextBoxColumn.Width = 180;
            // 
            // eclMatchTypeDataGridViewTextBoxColumn
            // 
            this.eclMatchTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.eclMatchTypeDataGridViewTextBoxColumn.DataPropertyName = "EclMatchType";
            this.eclMatchTypeDataGridViewTextBoxColumn.FillWeight = 50F;
            this.eclMatchTypeDataGridViewTextBoxColumn.HeaderText = "Ecl Match Type";
            this.eclMatchTypeDataGridViewTextBoxColumn.Name = "eclMatchTypeDataGridViewTextBoxColumn";
            this.eclMatchTypeDataGridViewTextBoxColumn.Width = 119;
            // 
            // DEclQualityMappings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DEclQualityMappings";
            this.Size = new System.Drawing.Size(489, 228);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn eclColumnNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eclMatchStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eclMatchTypeDataGridViewTextBoxColumn;
	}
}
