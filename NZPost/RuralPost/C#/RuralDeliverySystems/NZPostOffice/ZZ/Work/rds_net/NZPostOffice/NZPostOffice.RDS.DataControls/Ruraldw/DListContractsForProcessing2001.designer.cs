namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DListContractsForProcessing2001
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rowstatus;
		private System.Windows.Forms.DataGridViewTextBoxColumn  con_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn compute_1;
        private System.Windows.Forms.Label t_2;
        private System.Windows.Forms.Label t_3;
        //private System.Windows.Forms.Label t_4;
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
            //t_4 = new System.Windows.Forms.Label();
            //t_4.Text = "__________________________________________________________________";
            //t_4.Location = new System.Drawing.Point(1, 228);
            //t_4.Size = new System.Drawing.Size(400, 14);
           
            t_2 = new System.Windows.Forms.Label();
            t_2.Text = "Double Click on contract to open";
            t_2.Name = "t_2";
            t_2.Location = new System.Drawing.Point(1, 241);
            t_2.Size = new System.Drawing.Size(328, 15);
            t_2.BorderStyle = System.Windows.Forms.BorderStyle.None;

            t_3 = new System.Windows.Forms.Label();
            t_3.Text = "NOTE:  Only contracts that can be renewed will be retrieved";
            t_3.Name = "t_2";
            t_3.Location = new System.Drawing.Point(1, 254);
            t_3.Size = new System.Drawing.Size(328, 13);
            t_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			components = new System.ComponentModel.Container();
			grid = new Metex.Windows.DataEntityGrid();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();

			// 
			// bindingSource
			//
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ListContractsForProcessing2001);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 28;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grid.DataSource = this.bindingSource;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 220);
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//
			// rowstatus
			//
			rowstatus= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rowstatus.DataPropertyName = "Rowstatus";
			this.rowstatus.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rowstatus.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rowstatus.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rowstatus.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rowstatus.HeaderText = "Status";
			this.rowstatus.Name = "rowstatus";
			this.rowstatus.Width = 50;
			this.grid.Columns.Add(rowstatus);

            //
            // compute_1
            //
            compute_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compute_1.DataPropertyName = "Compute1";
            this.compute_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.compute_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.compute_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.compute_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.compute_1.HeaderText = "Contract";
            this.compute_1.Name = "compute_1";
            this.compute_1.Width = 55;
            this.grid.Columns.Add(compute_1);

			//
			// con_title
			//
			con_title= new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con_title.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.con_title.DataPropertyName = "ConTitle";
			this.con_title.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.con_title.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.con_title.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.con_title.HeaderText = "Title";
			this.con_title.Name = "con_title";
			this.con_title.ReadOnly = true;
			this.con_title.Width = 242;
            this.con_title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.grid.Columns.Add(con_title);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 268);
            //?this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
            this.Controls.Add(t_2);
            this.Controls.Add(t_3);
            //this.Controls.Add(t_4);
            this.Controls.Add(grid);  	          
		}
		#endregion

	}
}
