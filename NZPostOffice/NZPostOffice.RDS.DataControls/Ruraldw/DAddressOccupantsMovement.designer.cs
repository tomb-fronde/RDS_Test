namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DAddressOccupantsMovement
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  adr_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  move_in_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  move_out_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_id;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AddressOccupantsMovement);

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
			// adr_id
			//
			adr_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adr_id.DataPropertyName = "AdrId";
			this.adr_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.adr_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.adr_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.adr_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.adr_id.HeaderText = "Adr Id";
			this.adr_id.Name = "adr_id";
			this.adr_id.ReadOnly = true;
			this.adr_id.Width = 214;
			this.grid.Columns.Add(adr_id);


			//
			// cust_id
			//
			cust_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_id.DataPropertyName = "CustId";
			this.cust_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.cust_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cust_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cust_id.HeaderText = "Cust Id";
			this.cust_id.Name = "cust_id";
			this.cust_id.ReadOnly = true;
			this.cust_id.Width = 214;
			this.grid.Columns.Add(cust_id);


			//
			// move_in_date
			//
			move_in_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.move_in_date.DataPropertyName = "MoveInDate";
			this.move_in_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.move_in_date.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.move_in_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.move_in_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.move_in_date.HeaderText = "Move In Date";
			this.move_in_date.Name = "move_in_date";
			this.move_in_date.ReadOnly = true;
			this.move_in_date.Width = 129;
			this.grid.Columns.Add(move_in_date);


			//
			// move_out_date
			//
			move_out_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.move_out_date.DataPropertyName = "MoveOutDate";
			this.move_out_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.move_out_date.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.move_out_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.move_out_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.move_out_date.HeaderText = "Move Out Date";
			this.move_out_date.Name = "move_out_date";
			this.move_out_date.ReadOnly = true;
			this.move_out_date.Width = 59;
			this.grid.Columns.Add(move_out_date);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
