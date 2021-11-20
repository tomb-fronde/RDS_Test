namespace NZPostOffice.RDS.DataControls.Ruralsec
{
	partial class DUserGroupRights
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  region_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rur_modify;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ug_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rur_delete;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rur_read;
		private System.Windows.Forms.DataGridViewTextBoxColumn  name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rc_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rur_create;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rur_id;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralsec.UserGroupRights);

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
			// rur_id
			//
			rur_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rur_id.DataPropertyName = "RurId";
			this.rur_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rur_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rur_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rur_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rur_id.HeaderText = "Rur Id";
			this.rur_id.Name = "rur_id";
			this.rur_id.Width = 52;
			this.grid.Columns.Add(rur_id);


			//
			// ug_id
			//
			ug_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ug_id.DataPropertyName = "UgId";
			this.ug_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.ug_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.ug_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ug_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.ug_id.HeaderText = "Ug Id";
			this.ug_id.Name = "ug_id";
			this.ug_id.Width = 40;
			this.grid.Columns.Add(ug_id);


			//
			// rc_id
			//
			rc_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rc_id.DataPropertyName = "RcId";
			this.rc_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.rc_id.DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
			this.rc_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rc_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rc_id.HeaderText = "Rc Id";
			this.rc_id.Name = "rc_id";
			this.rc_id.Width = 40;
			this.grid.Columns.Add(rc_id);


			//
			// rur_create
			//
			rur_create= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rur_create.DataPropertyName = "RurCreate";
			this.rur_create.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rur_create.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rur_create.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rur_create.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rur_create.HeaderText = "Create";
			this.rur_create.Name = "rur_create";
			this.rur_create.Width = 38;
			this.grid.Columns.Add(rur_create);


			//
			// rur_read
			//
			rur_read= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rur_read.DataPropertyName = "RurRead";
			this.rur_read.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rur_read.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rur_read.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rur_read.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rur_read.HeaderText = "Read";
			this.rur_read.Name = "rur_read";
			this.rur_read.Width = 32;
			this.grid.Columns.Add(rur_read);


			//
			// rur_modify
			//
			rur_modify= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rur_modify.DataPropertyName = "RurModify";
			this.rur_modify.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rur_modify.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rur_modify.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rur_modify.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rur_modify.HeaderText = "Mod";
			this.rur_modify.Name = "rur_modify";
			this.rur_modify.Width = 35;
			this.grid.Columns.Add(rur_modify);


			//
			// rur_delete
			//
			rur_delete= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rur_delete.DataPropertyName = "RurDelete";
			this.rur_delete.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rur_delete.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.rur_delete.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rur_delete.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.rur_delete.HeaderText = "Del";
			this.rur_delete.Name = "rur_delete";
			this.rur_delete.Width = 35;
			this.grid.Columns.Add(rur_delete);


			//
			// name
			//
			name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name.DataPropertyName = "Name";
			this.name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.name.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
			this.name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.name.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.name.HeaderText = "Component";
			this.name.Name = "name";
			this.name.ReadOnly = true;
			this.name.Width = 108;
			this.grid.Columns.Add(name);


			//
			// region_id
			//
			region_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.region_id.DataPropertyName = "RegionId";
			this.region_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.region_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.region_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.region_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8F);
			this.region_id.HeaderText = "Region id";
			this.region_id.Name = "region_id";
			this.region_id.Width = 67;
			this.grid.Columns.Add(region_id);

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
