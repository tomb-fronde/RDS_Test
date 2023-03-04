namespace NZPostOffice.ODPS.DataControls.OdpsLib
{
	partial class DShellImportProcessed
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridViewTextBoxColumn _null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0002;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contractor;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0003;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0004;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0005;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0006;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0010;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0013;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0014;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0015;
		private System.Windows.Forms.DataGridViewTextBoxColumn  compute_0017;
		private System.Windows.Forms.DataGridViewTextBoxColumn  null_1;
		private System.Windows.Forms.DataGridViewTextBoxColumn  null_2;
		private System.Windows.Forms.DataGridViewTextBoxColumn  null_3;
		private System.Windows.Forms.DataGridViewTextBoxColumn  null_4;
		private System.Windows.Forms.DataGridViewTextBoxColumn  null_5;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.ODPS.Entity.OdpsLib.ShellImportProcessed);

			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.White;
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
            this.grid.BackgroundColor = System.Drawing.Color.White;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;

			//
            // _null
			//
            _null = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._null.DataPropertyName = "Null";
            this._null.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this._null.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._null.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this._null.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
            this._null.HeaderText = "Null";
            this._null.Name = "null";
            this._null.ReadOnly = true;
            this._null.Width = 60;
            this.grid.Columns.Add(_null);


			//
			// compute_0002
			//
			compute_0002= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0002.DataPropertyName = "Compute0002";
			this.compute_0002.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.compute_0002.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0002.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0002.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0002.HeaderText = "'shell Deduction Month'+' '+string(month(today(*) 30))";
			this.compute_0002.Name = "compute_0002";
			this.compute_0002.ReadOnly = true;
			this.compute_0002.Width = 270;
			this.grid.Columns.Add(compute_0002);


			//
			// compute_0003
			//
			compute_0003= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0003.DataPropertyName = "Compute0003";
			this.compute_0003.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.compute_0003.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0003.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0003.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0003.HeaderText = "1";
			this.compute_0003.Name = "compute_0003";
			this.compute_0003.ReadOnly = true;
			this.compute_0003.Width = 60;
			this.grid.Columns.Add(compute_0003);


			//
			// compute_0004
			//
			compute_0004= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0004.DataPropertyName = "Compute0004";
			this.compute_0004.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.compute_0004.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0004.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0004.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0004.HeaderText = "6";
			this.compute_0004.Name = "compute_0004";
			this.compute_0004.ReadOnly = true;
			this.compute_0004.Width = 60;
			this.grid.Columns.Add(compute_0004);


			//
			// compute_0005
			//
			compute_0005= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0005.DataPropertyName = "Compute0005";
			this.compute_0005.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.compute_0005.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0005.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0005.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0005.HeaderText = "'shell Deductions Imported On ' || String(today(*))";
			this.compute_0005.Name = "compute_0005";
			this.compute_0005.ReadOnly = true;
			this.compute_0005.Width = 250;
			this.grid.Columns.Add(compute_0005);


			//
			// compute_0006
			//
			compute_0006= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0006.DataPropertyName = "Compute0006";
			this.compute_0006.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.compute_0006.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0006.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0006.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0006.HeaderText = "'m'";
			this.compute_0006.Name = "compute_0006";
			this.compute_0006.ReadOnly = true;
			this.compute_0006.Width = 15;
			this.grid.Columns.Add(compute_0006);


			//
			// null_1
			//
			null_1= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.null_1.DataPropertyName = "Null1";
			this.null_1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.null_1.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.null_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.null_1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.null_1.HeaderText = "Null";
			this.null_1.Name = "null_1";
			this.null_1.ReadOnly = true;
			this.null_1.Width = 60;
			this.grid.Columns.Add(null_1);


			//
			// null_2
			//
			null_2= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.null_2.DataPropertyName = "Null2";
			this.null_2.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.null_2.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.null_2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.null_2.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.null_2.HeaderText = "Null";
			this.null_2.Name = "null_2";
			this.null_2.ReadOnly = true;
			this.null_2.Width = 60;
			this.grid.Columns.Add(null_2);


			//
			// null_3
			//
			null_3= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.null_3.DataPropertyName = "Null3";
			this.null_3.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.null_3.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.null_3.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.null_3.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.null_3.HeaderText = "Null";
			this.null_3.Name = "null_3";
			this.null_3.ReadOnly = true;
			this.null_3.Width = 60;
			this.grid.Columns.Add(null_3);


			//
			// compute_0010
			//
			compute_0010= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0010.DataPropertyName = "Compute0010";
            this.compute_0010.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.compute_0010.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0010.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0010.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0010.HeaderText = "Sum(t Shell Import.total Deduction)";
			this.compute_0010.Name = "compute_0010";
			this.compute_0010.ReadOnly = true;
			this.compute_0010.Width = 180;
			this.grid.Columns.Add(compute_0010);


			//
			// null_4
			//
			null_4= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.null_4.DataPropertyName = "Null4";
			this.null_4.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.null_4.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.null_4.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.null_4.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.null_4.HeaderText = "Null";
			this.null_4.Name = "null_4";
			this.null_4.ReadOnly = true;
			this.null_4.Width = 60;
			this.grid.Columns.Add(null_4);


			//
			// null_5
			//
			null_5= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.null_5.DataPropertyName = "Null5";
			this.null_5.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.null_5.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.null_5.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.null_5.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.null_5.HeaderText = "Null";
			this.null_5.Name = "null_5";
			this.null_5.ReadOnly = true;
			this.null_5.Width = 60;
			this.grid.Columns.Add(null_5);


			//
			// compute_0013
			//
			compute_0013= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0013.DataPropertyName = "Compute0013";
            this.compute_0013.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.compute_0013.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0013.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0013.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0013.HeaderText = "Sum(t Shell Import.total Deduction)";
			this.compute_0013.Name = "compute_0013";
			this.compute_0013.ReadOnly = true;
			this.compute_0013.Width = 185;
			this.grid.Columns.Add(compute_0013);


			//
			// compute_0014
			//
			compute_0014= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0014.DataPropertyName = "Compute0014";
            this.compute_0014.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.compute_0014.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0014.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0014.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0014.HeaderText = "Sum(t Shell Import.total Deduction)";
			this.compute_0014.Name = "compute_0014";
			this.compute_0014.ReadOnly = true;
			this.compute_0014.Width = 185;
			this.grid.Columns.Add(compute_0014);


			//
			// compute_0015
			//
			compute_0015= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0015.DataPropertyName = "Compute0015";
            this.compute_0015.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.compute_0015.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0015.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0015.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0015.HeaderText = "Sum(t Shell Import.total Deduction)";
			this.compute_0015.Name = "compute_0015";
			this.compute_0015.ReadOnly = true;
			this.compute_0015.Width = 185;
			this.grid.Columns.Add(compute_0015);


			//
			// contractor
			//
			contractor= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contractor.DataPropertyName = "Contractor";
			this.contractor.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.contractor.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.contractor.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contractor.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.contractor.HeaderText = "0";
			this.contractor.Name = "contractor";
			this.contractor.Width = 200;
			this.grid.Columns.Add(contractor);


			//
			// compute_0017
			//
			compute_0017= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.compute_0017.DataPropertyName = "Compute0017";
			this.compute_0017.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.compute_0017.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.compute_0017.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.compute_0017.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.compute_0017.HeaderText = "";
			this.compute_0017.Name = "compute_0017";
			this.compute_0017.Width = 200;
			this.grid.Columns.Add(compute_0017);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(grid);
		}
		#endregion

	}
}
