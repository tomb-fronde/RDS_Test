namespace NZPostOffice.ODPS.DataControls.Ruralbase
{
	partial class DDatadict
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  in_primary_key;
		private System.Windows.Forms.DataGridViewTextBoxColumn  syslength;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cname;
		private System.Windows.Forms.DataGridViewTextBoxColumn  nulls;
		private System.Windows.Forms.DataGridViewTextBoxColumn  coltype;
		private System.Windows.Forms.DataGridViewTextBoxColumn  length;

	
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
            this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.Ruralbase.Datadict);

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
			// cname
			//
			cname= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cname.DataPropertyName = "Cname";
			this.cname.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cname.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cname.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cname.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cname.HeaderText = "Data Dictionary";
			this.cname.Name = "cname";
			this.cname.ReadOnly = true;
			this.cname.Width = 1096;
			this.grid.Columns.Add(cname);


			//
			// coltype
			//
			coltype= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.coltype.DataPropertyName = "Coltype";
			this.coltype.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.coltype.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.coltype.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.coltype.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.coltype.HeaderText = "Data Dictionary";
			this.coltype.Name = "coltype";
			this.coltype.ReadOnly = true;
			this.coltype.Width = 846;
			this.grid.Columns.Add(coltype);


			//
			// in_primary_key
			//
			in_primary_key= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.in_primary_key.DataPropertyName = "InPrimaryKey";
			this.in_primary_key.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.in_primary_key.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.in_primary_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.in_primary_key.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.in_primary_key.HeaderText = "Data Dictionary";
			this.in_primary_key.Name = "in_primary_key";
			this.in_primary_key.ReadOnly = true;
			this.in_primary_key.Width = 846;
			this.grid.Columns.Add(in_primary_key);


			//
			// nulls
			//
			nulls= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nulls.DataPropertyName = "Nulls";
			this.nulls.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.nulls.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.nulls.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.nulls.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.nulls.HeaderText = "Data Dictionary";
			this.nulls.Name = "nulls";
			this.nulls.ReadOnly = true;
			this.nulls.Width = 846;
			this.grid.Columns.Add(nulls);


			//
			// length
			//
			length= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.length.DataPropertyName = "Length";
			this.length.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.length.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.length.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.length.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.length.DefaultCellStyle.Format = "###";
			this.length.HeaderText = "Data Dictionary";
			this.length.Name = "length";
			this.length.ReadOnly = true;
			this.length.Width = 846;
			this.grid.Columns.Add(length);


			//
			// syslength
			//
			syslength= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.syslength.DataPropertyName = "Syslength";
			this.syslength.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.syslength.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.syslength.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.syslength.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.syslength.DefaultCellStyle.Format = "###";
			this.syslength.HeaderText = "Data Dictionary";
			this.syslength.Name = "syslength";
			this.syslength.ReadOnly = true;
			this.syslength.Width = 846;
			this.grid.Columns.Add(syslength);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(grid);
		}
		#endregion

	}
}
