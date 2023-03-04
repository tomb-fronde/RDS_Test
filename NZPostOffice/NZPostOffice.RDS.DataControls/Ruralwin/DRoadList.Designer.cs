namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	partial class DRoadList
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rt_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  tc_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sl_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sl_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rt_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  tc_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rs_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  road_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rs_name;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.RoadList);

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
			// road_name
			//
			road_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.road_name.DataPropertyName = "RoadName";
			this.road_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.road_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.road_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.road_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.road_name.HeaderText = "Road Name";
			this.road_name.Name = "road_name";
			this.road_name.ReadOnly = true;
			this.road_name.Width = 123;
			this.grid.Columns.Add(road_name);


			//
			// rt_id
			//
			rt_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rt_id.DataPropertyName = "RtId";
			this.rt_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rt_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.rt_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rt_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rt_id.HeaderText = "Rt Id";
			this.rt_id.Name = "rt_id";
			this.rt_id.ReadOnly = true;
			this.rt_id.Width = 48;
			this.grid.Columns.Add(rt_id);


			//
			// rt_name
			//
			rt_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rt_name.DataPropertyName = "RtName";
			this.rt_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rt_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.rt_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rt_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rt_name.HeaderText = "Rt Name";
			this.rt_name.Name = "rt_name";
			this.rt_name.ReadOnly = true;
			this.rt_name.Width = 57;
			this.grid.Columns.Add(rt_name);


			//
			// rs_id
			//
			rs_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rs_id.DataPropertyName = "RsId";
			this.rs_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rs_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.rs_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rs_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rs_id.HeaderText = "Rs Id";
			this.rs_id.Name = "rs_id";
			this.rs_id.ReadOnly = true;
			this.rs_id.Width = 52;
			this.grid.Columns.Add(rs_id);


			//
			// rs_name
			//
			rs_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rs_name.DataPropertyName = "RsName";
			this.rs_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rs_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.rs_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rs_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rs_name.HeaderText = "Rs Name";
			this.rs_name.Name = "rs_name";
			this.rs_name.ReadOnly = true;
			this.rs_name.Width = 70;
			this.grid.Columns.Add(rs_name);


			//
			// sl_id
			//
			sl_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sl_id.DataPropertyName = "SlId";
			this.sl_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.sl_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.sl_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.sl_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.sl_id.HeaderText = "Sl Id";
			this.sl_id.Name = "sl_id";
			this.sl_id.ReadOnly = true;
			this.sl_id.Width = 39;
			this.grid.Columns.Add(sl_id);


			//
			// sl_name
			//
			sl_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sl_name.DataPropertyName = "SlName";
			this.sl_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.sl_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.sl_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.sl_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.sl_name.HeaderText = "Sl Name";
			this.sl_name.Name = "sl_name";
			this.sl_name.ReadOnly = true;
			this.sl_name.Width = 57;
			this.grid.Columns.Add(sl_name);


			//
			// tc_id
			//
			tc_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tc_id.DataPropertyName = "TcId";
			this.tc_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tc_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.tc_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_id.HeaderText = "Tc Id";
			this.tc_id.Name = "tc_id";
			this.tc_id.ReadOnly = true;
			this.tc_id.Width = 42;
			this.grid.Columns.Add(tc_id);


			//
			// tc_name
			//
			tc_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tc_name.DataPropertyName = "TcName";
			this.tc_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tc_name.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.ButtonFace;
			this.tc_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tc_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.tc_name.HeaderText = "Tc Name";
			this.tc_name.Name = "tc_name";
			this.tc_name.ReadOnly = true;
			this.tc_name.Width = 57;
			this.grid.Columns.Add(tc_name);

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
