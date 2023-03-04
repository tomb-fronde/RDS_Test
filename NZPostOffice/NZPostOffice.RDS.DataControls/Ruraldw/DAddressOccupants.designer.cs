namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DAddressOccupants
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  primary_ind;
		private Metex.Windows.DataGridViewEntityComboColumn  master_cust_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contact;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.AddressOccupants);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 20;
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
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(grid_DataError);
			this.grid.TabIndex = 0;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);
            //this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(grid_CellValueChanged);
			//
			// primary_ind
			//
			primary_ind = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.primary_ind.DataPropertyName = "PrimaryInd";
			this.primary_ind.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.primary_ind.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.primary_ind.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			//?this.primary_ind.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.primary_ind.DefaultCellStyle.NullValue = false;
			this.primary_ind.HeaderText = "Primary";
			this.primary_ind.Name = "primary_ind";
			this.primary_ind.TrueValue = 1;
			this.primary_ind.FalseValue = 0;
			this.primary_ind.Width = 45;
			this.grid.Columns.Add(primary_ind);


			//
			// contact
			//
			contact= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contact.DataPropertyName = "Contact";
			this.contact.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//?this.contact.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.contact.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contact.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contact.HeaderText = "Customer Name";
			this.contact.Name = "contact";
			this.contact.Width = 199;
			this.grid.Columns.Add(contact);


			//
			// master_cust_id
			//
        
			master_cust_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.master_cust_id.DataPropertyName = "MasterCustId";
			//?this.master_cust_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.master_cust_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.master_cust_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.master_cust_id.HeaderText = "Primary Contact";
            this.master_cust_id.Name = "master_cust_id";
			this.master_cust_id.Width = 204;
            this.master_cust_id.DisplayMember = "CustomerName";
            this.master_cust_id.ValueMember = "CustId";
            this.master_cust_id.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.grid.Columns.Add(master_cust_id);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.Controls.Add(grid);
		}

        //public event EventHandler valueChanged;

        //void grid_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        //{
        //    //OnItemChanged(sender,null);
        //    if(valueChanged != null)
        //        valueChanged(sender,null)
        //}

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            grid.EndEdit();
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (grid.RowCount <= 0)
                return;
            //if ( primary_ind = 1, 1, 0)            
            for (int i = 0; i < this.RowCount; i++)
            {
                if (this.GetItem<NZPostOffice.RDS.Entity.Ruraldw.AddressOccupants>(i).PrimaryInd == 1)
                    grid.Rows[i].Cells["master_cust_id"].ReadOnly = true;
                else
                    grid.Rows[i].Cells["master_cust_id"].ReadOnly = false;
            }
        }

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            if (grid.Columns[e.ColumnIndex].Name == "master_cust_id")
            {
                e.Cancel = false;
            }
        }
		#endregion

	}
}
