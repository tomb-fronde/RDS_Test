namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DRenewalGroup
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rg_description;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rg_next_renewal_date;

	
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
			components = new System.ComponentModel.Container();
			grid = new Metex.Windows.DataEntityGrid();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.RenewalGroup);

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
			// rg_description
			//
			rg_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rg_description.DataPropertyName = "RgDescription";
			this.rg_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rg_description.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.rg_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rg_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rg_description.HeaderText = "Renewal Groups";
			this.rg_description.Name = "rg_description";
			this.rg_description.Width = 155;
			this.grid.Columns.Add(rg_description);


			//
			// rg_next_renewal_date
			//
			rg_next_renewal_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridViewCellStyle1.Format = "dd/MM/yy";
            this.rg_next_renewal_date.DefaultCellStyle = dataGridViewCellStyle1;
			this.rg_next_renewal_date.DataPropertyName = "RgNextRenewalDate";
			this.rg_next_renewal_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rg_next_renewal_date.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.rg_next_renewal_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rg_next_renewal_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rg_next_renewal_date.HeaderText = "Next Renewal";
			this.rg_next_renewal_date.Name = "rg_next_renewal_date";
			this.rg_next_renewal_date.Width = 90;
			this.grid.Columns.Add(rg_next_renewal_date);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
