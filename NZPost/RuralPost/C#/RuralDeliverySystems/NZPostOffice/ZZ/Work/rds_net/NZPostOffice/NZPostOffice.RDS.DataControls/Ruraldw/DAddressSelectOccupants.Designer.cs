namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DAddressSelectOccupants
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  name;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  move_ind;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AddressSelectOccupants);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;//.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;

			//
			// move_ind
			//
			move_ind = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.move_ind.DataPropertyName = "MoveInd";
			this.move_ind.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.move_ind.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;;
			this.move_ind.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.move_ind.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.move_ind.DefaultCellStyle.NullValue = false;
            this.move_ind.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.move_ind.HeaderText = "";
			this.move_ind.Name = "move_ind";
			this.move_ind.TrueValue = "Y";
			this.move_ind.FalseValue = "N";
			this.move_ind.Width = 38;
			this.grid.Columns.Add(move_ind);


			//
			// name
			//
			name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name.DataPropertyName = "Name";
			this.name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.name.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.name.HeaderText = "Customer Name";
			this.name.Name = "name";
           // this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.name.Width = 185;
			this.grid.Columns.Add(name);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(1087955144);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
