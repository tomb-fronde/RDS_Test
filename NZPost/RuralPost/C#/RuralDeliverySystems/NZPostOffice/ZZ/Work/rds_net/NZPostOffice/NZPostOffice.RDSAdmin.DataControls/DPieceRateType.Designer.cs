namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DPieceRateType
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  prt_print_on_schedule;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  prs_true_value;
		private System.Windows.Forms.DataGridViewTextBoxColumn  prt_code;
        private Metex.Windows.DataGridViewEntityComboColumn prs_key;
		private System.Windows.Forms.DataGridViewTextBoxColumn  prt_description;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.PieceRateType);

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
			this.grid.ColumnHeadersHeight = 32;
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
			// prt_description
			//
			prt_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.prt_description.DataPropertyName = "PrtDescription";
			this.prt_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.prt_description.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.prt_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.prt_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.prt_description.HeaderText = "Piece Rate Types";
			this.prt_description.Name = "prt_description";
			this.prt_description.Width = 195;
			this.grid.Columns.Add(prt_description);


			//
			// prs_key
			//
			prs_key = new  Metex.Windows.DataGridViewEntityComboColumn();
			this.prs_key.DataPropertyName = "PrsKey";
			this.prs_key.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.prs_key.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.prs_key.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.prs_key.HeaderText = "Supplier";
			this.prs_key.Name = "d_dddw_piece_rate_suppliers";
			this.prs_key.Width = 176;
			this.grid.Columns.Add(prs_key);


			//
			// prt_code
			//
			prt_code= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.prt_code.DataPropertyName = "PrtCode";
			this.prt_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.prt_code.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.prt_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.prt_code.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.prt_code.HeaderText = "Code";
			this.prt_code.Name = "prt_code";
			this.prt_code.Width = 40;
			this.grid.Columns.Add(prt_code);


			//
			// prt_print_on_schedule
			//
			prt_print_on_schedule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.prt_print_on_schedule.DataPropertyName = "PrtPrintOnSchedule";
			this.prt_print_on_schedule.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.prt_print_on_schedule.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.prt_print_on_schedule.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.prt_print_on_schedule.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.prt_print_on_schedule.DefaultCellStyle.NullValue = false;
			this.prt_print_on_schedule.HeaderText = "Print On\nSchedule";
			this.prt_print_on_schedule.Name = "prt_print_on_schedule";
			this.prt_print_on_schedule.TrueValue = "Y";
			this.prt_print_on_schedule.FalseValue = "N";
			this.prt_print_on_schedule.Width = 53;
			this.grid.Columns.Add(prt_print_on_schedule);


			//
			// prs_true_value
			//
			prs_true_value = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.prs_true_value.DataPropertyName = "PrsTrueValue";
			this.prs_true_value.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.prs_true_value.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.prs_true_value.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.prs_true_value.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.prs_true_value.DefaultCellStyle.NullValue = false;
			this.prs_true_value.HeaderText = "True Value";
			this.prs_true_value.Name = "prs_true_value";
			this.prs_true_value.TrueValue = "Y";
			this.prs_true_value.FalseValue = "N";
			this.prs_true_value.Width = 66;
			this.grid.Columns.Add(prs_true_value);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
		}
		#endregion

	}
}
