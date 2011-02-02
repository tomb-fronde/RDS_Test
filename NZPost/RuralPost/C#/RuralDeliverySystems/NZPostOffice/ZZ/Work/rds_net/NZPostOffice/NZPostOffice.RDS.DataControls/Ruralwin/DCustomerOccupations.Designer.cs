namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	partial class DCustomerOccupations
	{
        // TJB  Feb-2011  RPCR_023: New
        // Implements list of occupations with checkboxes for selections
        // (not to be confused with Occupation!)

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private Metex.Windows.DataEntityGrid grid;
		public Metex.Windows.DataEntityGrid Grid
		{
			get
			{
				return grid;
			}
		}

		#region Component Designer generated code
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new Metex.Windows.DataEntityGrid();
            this.coSelectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.occupationDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.CustomerOccupations);
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coSelectedDataGridViewTextBoxColumn,
            this.occupationDescriptionDataGridViewTextBoxColumn});
            this.grid.DataSource = this.bindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(405, 179);
            this.grid.TabIndex = 0;
            // 
            // coSelectedDataGridViewTextBoxColumn
            // 
            this.coSelectedDataGridViewTextBoxColumn.DataPropertyName = "CoSelected";
            this.coSelectedDataGridViewTextBoxColumn.FalseValue = "0";
            this.coSelectedDataGridViewTextBoxColumn.HeaderText = "Selected";
            this.coSelectedDataGridViewTextBoxColumn.Name = "coSelectedDataGridViewTextBoxColumn";
            this.coSelectedDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.coSelectedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.coSelectedDataGridViewTextBoxColumn.TrueValue = "1";
            this.coSelectedDataGridViewTextBoxColumn.Width = 50;
            // 
            // occupationDescriptionDataGridViewTextBoxColumn
            // 
            this.occupationDescriptionDataGridViewTextBoxColumn.DataPropertyName = "OccupationDescription";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.occupationDescriptionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.occupationDescriptionDataGridViewTextBoxColumn.HeaderText = "Occupation";
            this.occupationDescriptionDataGridViewTextBoxColumn.Name = "occupationDescriptionDataGridViewTextBoxColumn";
            this.occupationDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.occupationDescriptionDataGridViewTextBoxColumn.Width = 312;
            // 
            // DCustomerOccupations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.Controls.Add(this.grid);
            this.Name = "DCustomerOccupations";
            this.Size = new System.Drawing.Size(405, 179);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs args)
		{
			if (args.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
			{
				if (((NZPostOffice.RDS.Entity.Ruralwin.CustomerOccupations)this.bindingSource.List[args.NewIndex]).IsNew)
				{
					// delayedChangeList.Add(args.NewIndex);
					grid.Rows[args.NewIndex].Cells["ct_next_contract"].ReadOnly = false;
				}
			}
        }

        private System.Windows.Forms.DataGridViewCheckBoxColumn coSelectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn occupationDescriptionDataGridViewTextBoxColumn;
	}
}
