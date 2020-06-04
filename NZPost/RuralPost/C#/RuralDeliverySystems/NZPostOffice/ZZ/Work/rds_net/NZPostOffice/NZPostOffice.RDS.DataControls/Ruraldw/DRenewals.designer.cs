namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRenewals
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.IContainer components = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.st_contract = new System.Windows.Forms.Label();
            this.st_active = new System.Windows.Forms.Label();
            this.compute_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_expiry_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RenewalType = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compute_1,
            this.con_start_date,
            this.con_expiry_date,
            this.contractor,
            this.status,
            this.RenewalType});
            this.grid.DataSource = this.bindingSource;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 15);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(530, 258);
            this.grid.TabIndex = 0;
            // 
            // st_contract
            // 
            this.st_contract.BackColor = System.Drawing.SystemColors.Control;
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_contract.ForeColor = System.Drawing.Color.Black;
            this.st_contract.Location = new System.Drawing.Point(1, 1);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(500, 14);
            this.st_contract.TabIndex = 1;
            this.st_contract.Text = "text";
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // st_active
            // 
            this.st_active.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.st_active.Font = new System.Drawing.Font("Arial", 8F);
            this.st_active.ForeColor = System.Drawing.Color.Black;
            this.st_active.Location = new System.Drawing.Point(1, 1);
            this.st_active.Name = "st_active";
            this.st_active.Size = new System.Drawing.Size(500, 14);
            this.st_active.TabIndex = 2;
            this.st_active.Text = "1";
            this.st_active.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_active.Visible = false;
            this.st_active.TextChanged += new System.EventHandler(this.st_active_TextChanged);
            // 
            // compute_1
            // 
            this.compute_1.DataPropertyName = "Compute1";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.compute_1.DefaultCellStyle = dataGridViewCellStyle9;
            this.compute_1.HeaderText = "Renewals";
            this.compute_1.Name = "compute_1";
            this.compute_1.ReadOnly = true;
            this.compute_1.Width = 60;
            // 
            // con_start_date
            // 
            this.con_start_date.DataPropertyName = "ConStartDate";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Format = "dd/MM/yyyy";
            this.con_start_date.DefaultCellStyle = dataGridViewCellStyle10;
            this.con_start_date.HeaderText = "Started";
            this.con_start_date.Name = "con_start_date";
            this.con_start_date.ReadOnly = true;
            this.con_start_date.Width = 65;
            // 
            // con_expiry_date
            // 
            this.con_expiry_date.DataPropertyName = "ConExpiryDate";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Format = "dd/MM/yyyy";
            this.con_expiry_date.DefaultCellStyle = dataGridViewCellStyle11;
            this.con_expiry_date.HeaderText = "Expiry";
            this.con_expiry_date.Name = "con_expiry_date";
            this.con_expiry_date.ReadOnly = true;
            this.con_expiry_date.Width = 65;
            // 
            // contractor
            // 
            this.contractor.DataPropertyName = "Contractor";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.contractor.DefaultCellStyle = dataGridViewCellStyle12;
            this.contractor.HeaderText = "Owner Driver";
            this.contractor.Name = "contractor";
            this.contractor.ReadOnly = true;
            this.contractor.Width = 185;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.status.DefaultCellStyle = dataGridViewCellStyle13;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.Width = 56;
            // 
            // RenewalType
            // 
            this.RenewalType.DataPropertyName = "RenewalType";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.RenewalType.DefaultCellStyle = dataGridViewCellStyle14;
            this.RenewalType.HeaderText = "RenewalType";
            this.RenewalType.Name = "RenewalType";
            this.RenewalType.Width = 86;
            // 
            // DRenewals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.st_contract);
            this.Controls.Add(this.st_active);
            this.Name = "DRenewals";
            this.Size = new System.Drawing.Size(546, 275);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}

        void st_active_TextChanged(object sender, System.EventArgs e)
        {
            foreach (NZPostOffice.RDS.Entity.Ruraldw.Renewals var in this.BindingSource.List)
            {
                var.Status = st_active.Text;
            }
        }
		#endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn con_expiry_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractor;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn RenewalType;








    }
}
