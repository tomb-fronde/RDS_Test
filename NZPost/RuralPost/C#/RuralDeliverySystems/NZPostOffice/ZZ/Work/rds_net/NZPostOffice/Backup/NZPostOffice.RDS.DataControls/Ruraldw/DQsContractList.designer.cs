namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DQsContractList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contractor_supplier_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.QsContractList);

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
			this.contractor_supplier_no.Width = 75;
			this.grid.Columns.Add(contractor_supplier_no);

            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_1.DataPropertyName = "Compute1";
            this.compute_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.compute_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.compute_1.HeaderText = "Owner Driver";
            this.compute_1.Name = "compute_1";
            this.compute_1.ReadOnly = true;
            this.compute_1.Width = 184;
            this.grid.Columns.Add(compute_1);


            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
