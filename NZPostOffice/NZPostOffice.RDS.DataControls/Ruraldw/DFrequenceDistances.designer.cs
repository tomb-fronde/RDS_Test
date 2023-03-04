namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DFrequenceDistances
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  fd_effective_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fd_change_reason;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.FrequenceDistances);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 40;
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
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);

            //
            // fd_effective_date
            //
            fd_effective_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fd_effective_date.DataPropertyName = "FdEffectiveDate";
            this.fd_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.fd_effective_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.fd_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.fd_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.fd_effective_date.DefaultCellStyle.Format = "dd/MM/yy";
            this.fd_effective_date.HeaderText = "Effective Date";
            this.fd_effective_date.Name = "fd_effective_date";
            this.fd_effective_date.ReadOnly = true;
            this.fd_effective_date.Width = 60;
            this.grid.Columns.Add(fd_effective_date);


			//
			// fd_change_reason
			//
			fd_change_reason= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fd_change_reason.DataPropertyName = "FdChangeReason";
			this.fd_change_reason.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.fd_change_reason.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.fd_change_reason.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.fd_change_reason.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.fd_change_reason.HeaderText = "Change Reason";
            this.fd_change_reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.fd_change_reason.Name = "fd_change_reason";
			this.fd_change_reason.ReadOnly = true;
			this.fd_change_reason.Width = 225;
            
            this.fd_change_reason.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            
			this.grid.Columns.Add(fd_change_reason);


			
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
            this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(grid);
		}

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            fd_change_reason.DataGridView.AutoResizeRows();
        }
		#endregion

	}
}
