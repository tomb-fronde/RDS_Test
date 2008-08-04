namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwTown
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  tc_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  post_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn  post_code_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  tc_name;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DddwTown);

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
			this.grid.ColumnHeadersVisible = false;
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
			// tc_name
			//
			tc_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tc_name.DataPropertyName = "TcName";
			this.tc_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tc_name.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tc_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.tc_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.tc_name.HeaderText = "Tc Id";
			this.tc_name.Name = "tc_name";
			this.tc_name.Width = 349;
			this.grid.Columns.Add(tc_name);


			//
			// tc_id
			//
			tc_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tc_id.DataPropertyName = "TcId";
			this.tc_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.tc_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tc_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.tc_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.tc_id.HeaderText = "Tc Id";
			this.tc_id.Name = "tc_id";
			this.tc_id.Width = 60;
			this.grid.Columns.Add(tc_id);


			//
			// post_code
			//
			post_code= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.post_code.DataPropertyName = "PostCode";
			this.post_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.post_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.post_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.post_code.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.post_code.HeaderText = "Tc Id";
			this.post_code.Name = "post_code";
			this.post_code.ReadOnly = true;
			this.post_code.Width = 49;
			this.grid.Columns.Add(post_code);


			//
			// post_code_id
			//
			post_code_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.post_code_id.DataPropertyName = "PostCodeId";
			this.post_code_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.post_code_id.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.post_code_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.post_code_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.post_code_id.HeaderText = "Tc Id";
			this.post_code_id.Name = "post_code_id";
			this.post_code_id.ReadOnly = true;
			this.post_code_id.Width = 217;
			this.grid.Columns.Add(post_code_id);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
