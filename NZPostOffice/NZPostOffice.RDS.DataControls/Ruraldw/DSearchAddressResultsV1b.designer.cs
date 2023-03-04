namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DSearchAddressResultsV1b
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  primary_contract;
		private System.Windows.Forms.DataGridViewTextBoxColumn  adr_num;
		private Metex.Windows.DataGridViewEntityComboColumn  tc_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  indicator;
		private Metex.Windows.DataGridViewEntityComboColumn  sl_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  road_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  adr_rd_no;
		private System.Windows.Forms.DataGridViewTextBoxColumn  multiple_prime;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.SearchAddressResultsV1b);

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
			// multiple_prime
			//
			multiple_prime= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.multiple_prime.DataPropertyName = "MultiplePrime";
			this.multiple_prime.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.multiple_prime.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.multiple_prime.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
			this.multiple_prime.DefaultCellStyle.Font = new System.Drawing.Font("Wingdings", 12F);
			this.multiple_prime.HeaderText = "Cus";
			this.multiple_prime.Name = "multiple_prime";
			this.multiple_prime.Width = 18;
			this.grid.Columns.Add(multiple_prime);


			//
			// indicator
			//
			indicator= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.indicator.DataPropertyName = "Indicator";
			this.indicator.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.indicator.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.indicator.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
			this.indicator.DefaultCellStyle.Font = new System.Drawing.Font("Wingdings", 12F);
			this.indicator.HeaderText = "Ok";
			this.indicator.Name = "indicator";
			this.indicator.Width = 19;
			this.grid.Columns.Add(indicator);


			//
			// adr_num
			//
			adr_num= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adr_num.DataPropertyName = "AdrNum";
			this.adr_num.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.adr_num.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.adr_num.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.adr_num.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.adr_num.HeaderText = "St No";
			this.adr_num.Name = "adr_num";
			this.adr_num.ReadOnly = true;
			this.adr_num.Width = 40;
			this.grid.Columns.Add(adr_num);


			//
			// road_name
			//
			road_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.road_name.DataPropertyName = "RoadName";
			this.road_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.road_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.road_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.road_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.road_name.HeaderText = "Street / Road";
			this.road_name.Name = "road_name";
			this.road_name.ReadOnly = true;
			this.road_name.Width = 120;
			this.grid.Columns.Add(road_name);


			//
			// sl_id
			//
			sl_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.sl_id.DataPropertyName = "SlId";
			this.sl_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.sl_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.sl_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.sl_id.HeaderText = "Suburb / Locality";
			this.sl_id.Name = "d_dddw_suburb";
			this.sl_id.Width = 88;
			this.grid.Columns.Add(sl_id);


			//
			// adr_rd_no
			//
			adr_rd_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adr_rd_no.DataPropertyName = "AdrRdNo";
			this.adr_rd_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.adr_rd_no.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.adr_rd_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.adr_rd_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.adr_rd_no.HeaderText = "RD";
			this.adr_rd_no.Name = "adr_rd_no";
			this.adr_rd_no.ReadOnly = true;
			this.adr_rd_no.Width = 26;
			this.grid.Columns.Add(adr_rd_no);


			//
			// tc_id
			//
			tc_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.tc_id.DataPropertyName = "TcId";
			this.tc_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tc_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.tc_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.tc_id.HeaderText = "Town / City";
			this.tc_id.Name = "d_dddw_town";
			this.tc_id.Width = 82;
			this.grid.Columns.Add(tc_id);


			//
			// primary_contract
			//
			primary_contract= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.primary_contract.DataPropertyName = "PrimaryContract";
			this.primary_contract.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.primary_contract.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.primary_contract.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.primary_contract.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.primary_contract.HeaderText = "Primary Customer";
			this.primary_contract.Name = "primary_contract";
			this.primary_contract.Width = 130;
			this.grid.Columns.Add(primary_contract);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(1086902488);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
