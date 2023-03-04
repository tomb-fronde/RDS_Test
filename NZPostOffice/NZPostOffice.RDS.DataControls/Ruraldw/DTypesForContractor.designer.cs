namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DTypesForContractor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Metex.Windows.DataGridViewEntityComboColumn  ct_key_1;
		private Metex.Windows.DataGridViewEntityComboColumn  ct_key_2;
		private Metex.Windows.DataGridViewEntityComboColumn  ct_key_3;
        private System.Windows.Forms.Label st_contract;
	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.TypesForContractor);
            //
            // t_1
            //
            this.st_contract = new System.Windows.Forms.Label();
            this.st_contract.Font = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_contract.ForeColor = System.Drawing.Color.Black;
            this.st_contract.Location = new System.Drawing.Point(1, 1);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(500, 14);
            this.st_contract.Text = "Owner Driver:";
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_contract.BackColor = System.Drawing.SystemColors.Control;
            this.st_contract.BorderStyle = System.Windows.Forms.BorderStyle.None;
           

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grid.ColumnHeadersHeight = 28;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			//this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 15);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None ;
            this.grid.Size = new System.Drawing.Size(500, 245);
			this.grid.TabIndex = 0;
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);

			//
			// ct_key_1
			//
			ct_key_1 = new Metex.Windows.DataGridViewEntityComboColumn();
			this.ct_key_1.DataPropertyName = "CtKey";
			this.ct_key_1.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
			this.ct_key_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ct_key_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ct_key_1.HeaderText = "Contract Types";
            this.ct_key_1.HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.ct_key_1.Name = "d_dddw_contract_types";
			this.ct_key_1.Width = 146;
			this.grid.Columns.Add(ct_key_1);


            ////
            //// ct_key_2
            ////
            //ct_key_2 = new Metex.Windows.DataGridViewEntityComboColumn();
            //this.ct_key_2.DataPropertyName = "CtKey2";
            //this.ct_key_2.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
            //this.ct_key_2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //this.ct_key_2.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.ct_key_2.HeaderText = "";
            //this.ct_key_2.Name = "d_dddw_contract_types";
            //this.ct_key_2.Width = 146;
            //this.grid.Columns.Add(ct_key_2);


            ////
            //// ct_key_3
            ////
            //ct_key_3 = new Metex.Windows.DataGridViewEntityComboColumn();
            //this.ct_key_3.DataPropertyName = "CtKey3";
            //this.ct_key_3.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
            //this.ct_key_3.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //this.ct_key_3.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.ct_key_3.HeaderText = "";
            //this.ct_key_3.Name = "d_dddw_contract_types";
            //this.ct_key_3.Width = 146;
            //this.grid.Columns.Add(ct_key_3);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(500, 245);
            this.BackColor = System.Drawing.SystemColors.Control; 
			this.Controls.Add(grid);
            this.Controls.Add(st_contract);
		}

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            this.grid.EndEdit();
        }
		#endregion

	}
}
