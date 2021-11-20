namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	partial class DCustlistSelect
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_1;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_2;
		private System.Windows.Forms.DataGridViewTextBoxColumn  road_road_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  report_temp_customer_id;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralrpt.CustlistSelect);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
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
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;
            
            //
            // cust_id
            //
            cust_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_id.DataPropertyName = "CustId";
            this.cust_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.cust_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.cust_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cust_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.cust_id.HeaderText = "Cust Id";
            this.cust_id.Name = "cust_id";
            this.cust_id.ReadOnly = true;
            this.cust_id.Width = 52;
            this.grid.Columns.Add(cust_id);


            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_1.DataPropertyName = "Compute1";
            this.compute_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.compute_1.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
            this.compute_1.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this.compute_1.HeaderText = "Customer";
            this.compute_1.Name = "compute_1";
            this.compute_1.Width = 206;
            this.grid.Columns.Add(compute_1);

			//
			// compute_2
			//
			compute_2= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_2.DataPropertyName = "Compute2";
			this.compute_2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.compute_2.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.compute_2.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.compute_2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_2.HeaderText = "Address";
			this.compute_2.Name = "compute_2";
			this.compute_2.Width = 510;
			this.grid.Columns.Add(compute_2);


			//
			// report_temp_customer_id
			//
			report_temp_customer_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_temp_customer_id.DataPropertyName = "CustId";
			this.report_temp_customer_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.report_temp_customer_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.report_temp_customer_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.report_temp_customer_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F);
			this.report_temp_customer_id.HeaderText = "";
			this.report_temp_customer_id.Name = "report_temp_customer_id";
			this.report_temp_customer_id.ReadOnly = true;
			this.report_temp_customer_id.Width = 510;
            this.report_temp_customer_id.Visible = false;
			this.grid.Columns.Add(report_temp_customer_id);

			//
			// road_road_name
			//
			road_road_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.road_road_name.DataPropertyName = "RoadRoadName";
			this.road_road_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.road_road_name.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.road_road_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.road_road_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F);
			this.road_road_name.HeaderText = "";
			this.road_road_name.Name = "road_road_name";
			this.road_road_name.Width = 510;
            this.road_road_name.Visible = false;
			this.grid.Columns.Add(road_road_name);

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
