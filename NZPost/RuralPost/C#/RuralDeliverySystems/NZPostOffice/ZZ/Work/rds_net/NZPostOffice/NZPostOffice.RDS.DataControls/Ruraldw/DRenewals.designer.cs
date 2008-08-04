namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRenewals
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  con_acceptance_flag;
		private System.Windows.Forms.DataGridViewTextBoxColumn  con_start_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  con_expiry_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  status;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contractor;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.Label st_contract;
        private System.Windows.Forms.Label st_active;
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.Renewals);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			//this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			//this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 15);
			this.grid.MultiSelect = true;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(539, 258);
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Controls.Add(grid);

            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_1.DataPropertyName = "Compute1";
            this.compute_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.compute_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.compute_1.HeaderText = "Renewals";
            this.compute_1.Name = "compute_1";
            this.compute_1.ReadOnly = true;
            this.compute_1.Width = 60;
            this.grid.Columns.Add(compute_1);


			//
			// con_start_date
			//
			con_start_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con_start_date.DataPropertyName = "ConStartDate";
			this.con_start_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.con_start_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.con_start_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.con_start_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.con_start_date.DefaultCellStyle.Format = "dd/MM/yyyy";
			this.con_start_date.HeaderText = "Started";
			this.con_start_date.Name = "con_start_date";
			this.con_start_date.ReadOnly = true;
			this.con_start_date.Width = 65;
			this.grid.Columns.Add(con_start_date);


			//
			// con_expiry_date
			//
			con_expiry_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con_expiry_date.DataPropertyName = "ConExpiryDate";
			this.con_expiry_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.con_expiry_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.con_expiry_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.con_expiry_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.con_expiry_date.DefaultCellStyle.Format = "dd/MM/yyyy";
			this.con_expiry_date.HeaderText = "Expiry";
			this.con_expiry_date.Name = "con_expiry_date";
			this.con_expiry_date.ReadOnly = true;
			this.con_expiry_date.Width = 65;
			this.grid.Columns.Add(con_expiry_date);


			//
			// contractor
			//
			contractor= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contractor.DataPropertyName = "Contractor";
			this.contractor.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contractor.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contractor.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor.HeaderText = "Owner Driver";
			this.contractor.Name = "contractor";
			this.contractor.ReadOnly = true;
			this.contractor.Width = 285;
			this.grid.Columns.Add(contractor);


			//
			// status
			//
			status= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.status.DataPropertyName = "Status";
			this.status.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.status.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;//.ColorTranslator.FromWin32(553648127);
			this.status.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.status.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.status.HeaderText = "Status";
			this.status.Name = "status";
			this.status.Width = 66;
			this.grid.Columns.Add(status);


			//
			// con_acceptance_flag
			//
			con_acceptance_flag= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.con_acceptance_flag.DataPropertyName = "ConAcceptanceFlag";
			this.con_acceptance_flag.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.con_acceptance_flag.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;//.ColorTranslator.FromWin32(553648127);
			this.con_acceptance_flag.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.con_acceptance_flag.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.con_acceptance_flag.HeaderText = "";
			this.con_acceptance_flag.Name = "con_acceptance_flag";
			this.con_acceptance_flag.ReadOnly = true;
			this.con_acceptance_flag.Width = 20;
			this.grid.Columns.Add(con_acceptance_flag);


            //
            // st_contract
            //
            this.st_contract = new System.Windows.Forms.Label();
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_contract.ForeColor = System.Drawing.Color.Black;
            this.st_contract.Location = new System.Drawing.Point(1, 1);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(500, 14);
            this.st_contract.Text = "text";
            this.st_contract.Visible = true;
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_contract.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(st_contract);
            //
            // st_active
            //
            this.st_active = new System.Windows.Forms.Label();
            this.st_active.Font = new System.Drawing.Font("Arial", 8F);
            this.st_active.ForeColor = System.Drawing.Color.Black;
            this.st_active.Location = new System.Drawing.Point(1, 1);
            this.st_active.Name = "st_active";
            this.st_active.Size = new System.Drawing.Size(500, 14);
            this.st_active.Text = "1";
            this.st_active.Visible = false;
            this.st_active.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_active.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.st_active.TextChanged += new System.EventHandler(st_active_TextChanged);
            this.Controls.Add(st_active);


			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.SystemColors.Control;//.ColorTranslator.FromWin32(80269524);
		
		}

        void st_active_TextChanged(object sender, System.EventArgs e)
        {
            foreach (NZPostOffice.RDS.Entity.Ruraldw.Renewals var in this.BindingSource.List)
            {
                var.Status = st_active.Text;
            }
        }
		#endregion

	}
}
