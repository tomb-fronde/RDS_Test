namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DTownSuburbMap
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  region_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  tc_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sl_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sl_name;
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.TownSuburbMap);

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
			// tc_id
			//
			tc_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tc_id.DataPropertyName = "TcId";
			this.tc_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.tc_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tc_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.tc_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_id.HeaderText = "Tc Id";
			this.tc_id.Name = "tc_id";
			this.tc_id.ReadOnly = true;
			this.tc_id.Width = 60;
			this.grid.Columns.Add(tc_id);


			//
			// region_id
			//
			region_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.region_id.DataPropertyName = "RegionId";
			this.region_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.region_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.region_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.region_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.region_id.HeaderText = "Region Id";
			this.region_id.Name = "region_id";
			this.region_id.ReadOnly = true;
			this.region_id.Width = 60;
			this.grid.Columns.Add(region_id);


			//
			// tc_name
			//
			tc_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tc_name.DataPropertyName = "TcName";
			this.tc_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tc_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tc_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.tc_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_name.HeaderText = "Tc Name";
			this.tc_name.Name = "tc_name";
			this.tc_name.ReadOnly = true;
			this.tc_name.Width = 255;
			this.grid.Columns.Add(tc_name);


			//
			// sl_id
			//
			sl_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sl_id.DataPropertyName = "SlId";
			this.sl_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.sl_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.sl_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.sl_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.sl_id.HeaderText = "Sl Id";
			this.sl_id.Name = "sl_id";
			this.sl_id.ReadOnly = true;
			this.sl_id.Width = 60;
			this.grid.Columns.Add(sl_id);


			//
			// sl_name
			//
			sl_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sl_name.DataPropertyName = "SlName";
			this.sl_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.sl_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.sl_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.sl_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.sl_name.HeaderText = "Sl Name";
			this.sl_name.Name = "sl_name";
			this.sl_name.ReadOnly = true;
			this.sl_name.Width = 255;
			this.grid.Columns.Add(sl_name);

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
