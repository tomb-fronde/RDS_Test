namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	partial class DRestoreCust
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  cust_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn  moveoutdate;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruralwin.RestoreCust);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
            this.grid.BackgroundColor = System.Drawing.Color.White;
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
			// cust_id
			//
			cust_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_id.DataPropertyName = "CustId";
			this.cust_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.cust_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.cust_id.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cust_id.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_id.HeaderText = "Cust Id";
			this.cust_id.Name = "cust_id";
			this.cust_id.ReadOnly = true;
			this.cust_id.Width = 49;
			this.grid.Columns.Add(cust_id);
		
			//
			// cust_name
			//
			cust_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cust_name.DataPropertyName = "CustName";
			this.cust_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cust_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.cust_name.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cust_name.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.cust_name.HeaderText = "Customer Name";
			this.cust_name.Name = "cust_name";
			this.cust_name.Width = 271;
			this.grid.Columns.Add(cust_name);

            //
			// moveoutdate
			//
			moveoutdate= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.moveoutdate.DataPropertyName = "Moveoutdate";
			this.moveoutdate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.moveoutdate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.moveoutdate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.moveoutdate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.moveoutdate.HeaderText = "Move Out Date";
			this.moveoutdate.Name = "moveoutdate";
			this.moveoutdate.Width = 98;
			this.grid.Columns.Add(moveoutdate);


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
