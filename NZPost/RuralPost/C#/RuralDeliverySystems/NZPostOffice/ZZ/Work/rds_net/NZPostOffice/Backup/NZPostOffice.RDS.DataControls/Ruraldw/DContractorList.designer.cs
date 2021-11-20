namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DContractorList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contractor_supplier_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cr_effective_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contractor_name;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractorList);

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
			this.grid.ColumnHeadersHeight = 24;
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
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			//
			// contractor_supplier_no
			//
			contractor_supplier_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contractor_supplier_no.DataPropertyName = "ContractorSupplierNo";
			this.contractor_supplier_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.contractor_supplier_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_supplier_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contractor_supplier_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_supplier_no.HeaderText = "Supplier No";
			this.contractor_supplier_no.Name = "contractor_supplier_no";
			this.contractor_supplier_no.ReadOnly = true;
			this.contractor_supplier_no.Width = 70;
			this.grid.Columns.Add(contractor_supplier_no);


			//
			// cr_effective_date
			//
			cr_effective_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cr_effective_date.DataPropertyName = "CrEffectiveDate";
			this.cr_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cr_effective_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cr_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cr_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cr_effective_date.HeaderText = "Effective Date";
			this.cr_effective_date.Name = "cr_effective_date";
			this.cr_effective_date.ReadOnly = true;
			this.cr_effective_date.Width = 85;
			this.grid.Columns.Add(cr_effective_date);


			//
			// contractor_name
			//
			contractor_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contractor_name.DataPropertyName = "ContractorName";
			this.contractor_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.contractor_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contractor_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_name.HeaderText = "Owner Driver";
            this.contractor_name.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contractor_name.Name = "contractor_name";
			this.contractor_name.ReadOnly = true;
			this.contractor_name.Width = 415;
			this.grid.Columns.Add(contractor_name);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
