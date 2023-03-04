namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DTypesForContract
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label st_contract;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        private Metex.Windows.DataGridViewEntityComboColumn ct_key;
        private Metex.Windows.DataEntityGrid grid;

		#region Component Designer generated code
		private void InitializeComponent()
		{
            this.st_contract = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.TypesForContract);


            // 
            // grid
            // 
            grid = new Metex.Windows.DataEntityGrid();
            this.grid.AllowUserToAddRows = false;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
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
            //?this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(0, 18);
            this.grid.MultiSelect = true;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(638, 252);
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid.TabIndex = 0;
            this.Controls.Add(grid);

            // 
            // ct_key
            // 
            ct_key = new Metex.Windows.DataGridViewEntityComboColumn();
            this.ct_key.DataPropertyName = "CtKey";
            this.ct_key.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ct_key.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;//.SystemColors.ButtonFace;
            this.ct_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ct_key.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ct_key.HeaderText = "Contract Types";
            this.ct_key.Name = "ct_key";
            this.ct_key.Width = 180;
            this.grid.Columns.Add(ct_key);

            // 
            // st_contract
            // 
            this.st_contract.BackColor = System.Drawing.SystemColors.Control;
            this.st_contract.Font = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_contract.ForeColor = System.Drawing.Color.Black;
            this.st_contract.Location = new System.Drawing.Point(1, 1);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(540, 15);
            this.st_contract.TabIndex = 0;
            this.st_contract.Text = "text";
            this.st_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.st_contract);
     
            this.Name = "DTypesForContract";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.SizeChanged += new System.EventHandler(DTypesForContract_SizeChanged);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);
		}

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.grid.CurrentColumnName == "ct_key")
            {
                this.grid.EndEdit();
            }
        }

        void DTypesForContract_SizeChanged(object sender, System.EventArgs e)
        {
            this.grid.Height = this.Height - grid.Top;
            this.grid.Width = this.Width - grid.Left;
        }
		#endregion

	}
}
