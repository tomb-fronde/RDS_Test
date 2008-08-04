namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DPieceRates
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  prt_description;
		private System.Windows.Forms.DataGridViewTextBoxColumn  pr_rate;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  pr_active_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_readonly;
	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.PieceRates);

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
			// prt_description
			//
			prt_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.prt_description.DataPropertyName = "PrtDescription";
			this.prt_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.prt_description.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.prt_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.prt_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.prt_description.HeaderText = "Piece Rate";
			this.prt_description.Name = "prt_description";
			this.prt_description.ReadOnly = true;
			this.prt_description.Width = 149;
			this.grid.Columns.Add(prt_description);


			//
			// pr_rate
			//
			pr_rate= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pr_rate.DataPropertyName = "PrRate";
			this.pr_rate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pr_rate.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.ColorTranslator.FromWin32(1087955144~tif(describe('st_readonly.text')='N',16777215,12632256));
			this.pr_rate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.pr_rate.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.pr_rate.HeaderText = "Rate ($)";
			this.pr_rate.Name = "pr_rate";
			this.pr_rate.Width = 52;
			this.grid.Columns.Add(pr_rate);


			//
			// pr_active_status
			//
			pr_active_status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.pr_active_status.DataPropertyName = "PrActiveStatus";
			this.pr_active_status.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.pr_active_status.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.pr_active_status.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.pr_active_status.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.pr_active_status.DefaultCellStyle.NullValue = false;
            this.pr_active_status.HeaderText = "Inactive";
			this.pr_active_status.Name = "pr_active_status";
			this.pr_active_status.TrueValue = "N";
			this.pr_active_status.FalseValue = "Y";
			this.pr_active_status.Width = 47;
			this.grid.Columns.Add(pr_active_status);

            //
            // pr_rate
            //
            st_readonly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_readonly.DataPropertyName = "st_readonly";
            this.st_readonly.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;            
            this.st_readonly.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.st_readonly.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.st_readonly.HeaderText = "";
            this.st_readonly.Name = "st_readonly";
            this.st_readonly.Width = 8;
            this.st_readonly.ReadOnly = true;
            this.st_readonly.Visible = false;
            this.grid.Columns.Add(st_readonly);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
