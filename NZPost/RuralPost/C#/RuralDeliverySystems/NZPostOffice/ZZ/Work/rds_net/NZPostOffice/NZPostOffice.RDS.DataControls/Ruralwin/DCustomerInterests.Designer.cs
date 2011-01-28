namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	partial class DCustomerInterests
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  ct_rd_ref_mandatory;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ct_next_contract;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract_type;

	
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
			components = new System.ComponentModel.Container();
			grid = new Metex.Windows.DataEntityGrid();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.CustomerInterests);
			this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
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
			// contract_type
			//
			contract_type= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract_type.DataPropertyName = "ContractType";
			this.contract_type.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contract_type.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.contract_type.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contract_type.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contract_type.HeaderText = "Contract Types";
			this.contract_type.Name = "contract_type";
			this.contract_type.Width = 205;
			this.grid.Columns.Add(contract_type);
			//
			// ct_next_contract
			//
			ct_next_contract= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ct_next_contract.DataPropertyName = "CtNextContract";
			this.ct_next_contract.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.ct_next_contract.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.ct_next_contract.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ct_next_contract.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.ct_next_contract.HeaderText = "Next Contract";
			this.ct_next_contract.Name = "ct_next_contract";
			this.ct_next_contract.Width = 84;
			this.ct_next_contract.ReadOnly = true;
			this.grid.Columns.Add(ct_next_contract);
			//
			// ct_rd_ref_mandatory
			//
			ct_rd_ref_mandatory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ct_rd_ref_mandatory.DataPropertyName = "CtRdRefMandatory";
			this.ct_rd_ref_mandatory.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.ct_rd_ref_mandatory.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
			this.ct_rd_ref_mandatory.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ct_rd_ref_mandatory.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.ct_rd_ref_mandatory.DefaultCellStyle.NullValue = false;
			this.ct_rd_ref_mandatory.HeaderText = "RD Text Mandatory";
			this.ct_rd_ref_mandatory.Name = "ct_rd_ref_mandatory";
			this.ct_rd_ref_mandatory.TrueValue = "Y";
			this.ct_rd_ref_mandatory.FalseValue = "N";
			this.ct_rd_ref_mandatory.Width = 122;
			this.grid.Columns.Add(ct_rd_ref_mandatory);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

		private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs args)
		{
			if (args.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
			{
				if (((NZPostOffice.RDS.Entity.Ruralwin.CustomerInterests)this.bindingSource.List[args.NewIndex]).IsNew)
				{
					// delayedChangeList.Add(args.NewIndex);
					grid.Rows[args.NewIndex].Cells["ct_next_contract"].ReadOnly = false;
				}
			}
		}
	}
}
