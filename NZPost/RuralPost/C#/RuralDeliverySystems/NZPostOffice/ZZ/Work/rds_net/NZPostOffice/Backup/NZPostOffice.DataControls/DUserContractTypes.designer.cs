namespace NZPostOffice.DataControls
{
	partial class DUserContractTypes
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ct_key;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ui_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contract_type_contract_type;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.Entity.UserContractTypes);

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
			// ct_key
			//
			ct_key= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ct_key.DataPropertyName = "CtKey";
			this.ct_key.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ct_key.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.ct_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ct_key.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.ct_key.HeaderText = "Ct Key";
			this.ct_key.Name = "ct_key";
			this.ct_key.ReadOnly = true;
			this.ct_key.Width = 32;
			this.grid.Columns.Add(ct_key);


			//
			// ui_id
			//
			ui_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ui_id.DataPropertyName = "UiId";
			this.ui_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ui_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.ui_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ui_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.ui_id.HeaderText = "Ui Id";
			this.ui_id.Name = "ui_id";
			this.ui_id.ReadOnly = true;
			this.ui_id.Width = 26;
			this.grid.Columns.Add(ui_id);


			//
			// contract_type_contract_type
			//
			contract_type_contract_type= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contract_type_contract_type.DataPropertyName = "ContractTypeContractType";
			this.contract_type_contract_type.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contract_type_contract_type.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.contract_type_contract_type.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contract_type_contract_type.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.contract_type_contract_type.HeaderText = "Contract Type Contract Type";
			this.contract_type_contract_type.Name = "contract_type_contract_type";
			this.contract_type_contract_type.ReadOnly = true;
			this.contract_type_contract_type.Width = 103;
			this.grid.Columns.Add(contract_type_contract_type);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(grid);
		}
		#endregion

	}
}
