namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DTowncity
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
        private Metex.Windows.DataGridViewEntityComboColumn region_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  tc_name;

	
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
			components = new System.ComponentModel.Container();
			grid = new Metex.Windows.DataEntityGrid();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.Towncity);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 28;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;
            this.grid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(grid_CellBeginEdit);

			//
			// tc_name
			//
			tc_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tc_name.DataPropertyName = "TcName";
			this.tc_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tc_name.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.tc_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.tc_name.HeaderText = "Town / City Name";
			this.tc_name.Name = "tc_name";
			this.tc_name.Width = 226;
			this.grid.Columns.Add(tc_name);


			//
			// region_id
			//
			region_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.region_id.DataPropertyName = "RegionId";
			this.region_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.region_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.region_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.region_id.HeaderText = "Town / City Name";
			this.region_id.Name = "d_dddw_region";
			this.region_id.Width = 212;
			this.grid.Columns.Add(region_id);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

        //!! Remove empty line for dropdown datawindow
        void grid_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs args)
        {
            System.Windows.Forms.DataGridViewCell cell = grid.Rows[args.RowIndex].Cells[args.ColumnIndex];
            if (cell is System.Windows.Forms.DataGridViewComboBoxCell && cell.Value != null)
            {
                System.Windows.Forms.DataGridViewComboBoxCell combo = (System.Windows.Forms.DataGridViewComboBoxCell)cell;
                if(((NZPostOffice.RDSAdmin.Entity.Security.DddwRegion)((System.Collections.IList)combo.DataSource)[0]).RegionId == null)
                    ((System.Collections.IList)combo.DataSource).RemoveAt(0);
            }
        }

	}
}
