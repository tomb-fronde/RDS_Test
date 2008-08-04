namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRoadSuburbMapV2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rt_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sl_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  sl_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rt_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  road_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  road_id;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RoadSuburbMapV2);

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
			// road_id
			//
			road_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.road_id.DataPropertyName = "RoadId";
			this.road_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.road_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.road_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.road_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.road_id.HeaderText = "Road Id";
			this.road_id.Name = "road_id";
			this.road_id.ReadOnly = true;
			this.road_id.Width = 54;
			this.grid.Columns.Add(road_id);


			//
			// road_name
			//
			road_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.road_name.DataPropertyName = "RoadName";
			this.road_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.road_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.road_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.road_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.road_name.HeaderText = "Road Name";
			this.road_name.Name = "road_name";
			this.road_name.ReadOnly = true;
			this.road_name.Width = 249;
			this.grid.Columns.Add(road_name);


			//
			// rt_id
			//
			rt_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rt_id.DataPropertyName = "RtId";
			this.rt_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rt_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rt_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rt_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rt_id.HeaderText = "Rt Id";
			this.rt_id.Name = "rt_id";
			this.rt_id.ReadOnly = true;
			this.rt_id.Width = 60;
			this.grid.Columns.Add(rt_id);


			//
			// rt_name
			//
			rt_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rt_name.DataPropertyName = "RtName";
			this.rt_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rt_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rt_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rt_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.rt_name.HeaderText = "Rt Name";
			this.rt_name.Name = "rt_name";
			this.rt_name.ReadOnly = true;
			this.rt_name.Width = 255;
			this.grid.Columns.Add(rt_name);


			//
			// sl_id
			//
			sl_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sl_id.DataPropertyName = "SlId";
			this.sl_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
