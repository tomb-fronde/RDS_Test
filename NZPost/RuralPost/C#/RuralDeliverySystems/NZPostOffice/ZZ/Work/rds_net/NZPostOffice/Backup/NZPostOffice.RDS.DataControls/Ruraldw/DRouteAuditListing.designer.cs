namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRouteAuditListing
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ra_date_of_check;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ra_contractor;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ra_frequency;
        private System.Windows.Forms.Label st_contract;

	
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
            st_contract = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RouteAuditListing);

            // 
            // st_contract
            // 
            this.st_contract.Dock = System.Windows.Forms.DockStyle.Top;
            this.st_contract.Name = "st_contract";
            this.st_contract.Height = 14;
            this.st_contract.Width = 600;
            this.st_contract.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.st_contract.Font = new System.Drawing.Font("MS Sans Serif", 8F,System.Drawing.FontStyle.Bold);
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
            //this.grid.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 15);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 255);
			this.grid.TabIndex = 0;

			//
			// ra_date_of_check
			//
			ra_date_of_check= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ra_date_of_check.DataPropertyName = "RaDateOfCheck";
			this.ra_date_of_check.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ra_date_of_check.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ra_date_of_check.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ra_date_of_check.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ra_date_of_check.DefaultCellStyle.Format = "dd/MM/yyyy";
			this.ra_date_of_check.HeaderText = "Date";
            this.ra_date_of_check.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ra_date_of_check.Name = "ra_date_of_check";
			this.ra_date_of_check.ReadOnly = true;
			this.ra_date_of_check.Width = 66;
			this.grid.Columns.Add(ra_date_of_check);


			//
			// ra_frequency
			//
			ra_frequency= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ra_frequency.DataPropertyName = "RaFrequency";
			this.ra_frequency.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ra_frequency.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ra_frequency.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ra_frequency.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ra_frequency.HeaderText = "Frequency";
            this.ra_frequency.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ra_frequency.Name = "ra_frequency";
			this.ra_frequency.ReadOnly = true;
			this.ra_frequency.Width = 165;
			this.grid.Columns.Add(ra_frequency);


			//
			// ra_contractor
			//
			ra_contractor= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ra_contractor.DataPropertyName = "RaContractor";
			this.ra_contractor.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ra_contractor.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ra_contractor.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ra_contractor.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ra_contractor.HeaderText = "Owner Driver";
            this.ra_contractor.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ra_contractor.Name = "ra_contractor";
			this.ra_contractor.ReadOnly = true;
			this.ra_contractor.Width = 315;
			this.grid.Columns.Add(ra_contractor);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.SystemColors.ButtonFace;//.ColorTranslator.FromWin32(80269524);
            
			this.Controls.Add(grid);
            this.Controls.Add(this.st_contract);
		}
		#endregion

	}
}
