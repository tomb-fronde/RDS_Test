namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DDddwMailCategory
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  farflag;
		private Metex.Windows.DataGridViewEntityComboColumn  mc_mail_category;
		private System.Windows.Forms.DataGridViewTextBoxColumn  busflag;
		private System.Windows.Forms.DataGridViewTextBoxColumn  resflag;
		private System.Windows.Forms.DataGridViewTextBoxColumn  mc_description;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.DddwMailCategory);

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
			// mc_mail_category
			//
			mc_mail_category = new Metex.Windows.DataGridViewEntityComboColumn();
			this.mc_mail_category.DataPropertyName = "McMailCategory";
			//this.mc_mail_category.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.mc_mail_category.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;;
			this.mc_mail_category.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.mc_mail_category.HeaderText = "Customer Type";
			this.mc_mail_category.Name = "mc_mail_category";
			this.mc_mail_category.ReadOnly = true;
			this.mc_mail_category.Width = 93;
			this.grid.Columns.Add(mc_mail_category);


			//
			// mc_description
			//
			mc_description= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mc_description.DataPropertyName = "McDescription";
			this.mc_description.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.mc_description.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.mc_description.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mc_description.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.mc_description.HeaderText = "Mail Category";
			this.mc_description.Name = "mc_description";
			this.mc_description.ReadOnly = true;
			this.mc_description.Width = 205;
			this.grid.Columns.Add(mc_description);


			//
			// busflag
			//
			busflag= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.busflag.DataPropertyName = "Busflag";
			this.busflag.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.busflag.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.busflag.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.busflag.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.busflag.HeaderText = "";
			this.busflag.Name = "busflag";
			this.busflag.Width = 64;
			this.grid.Columns.Add(busflag);


			//
			// resflag
			//
			resflag= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.resflag.DataPropertyName = "Resflag";
			this.resflag.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.resflag.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.resflag.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.resflag.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.resflag.HeaderText = "";
			this.resflag.Name = "resflag";
			this.resflag.Width = 64;
			this.grid.Columns.Add(resflag);


			//
			// farflag
			//
			farflag= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.farflag.DataPropertyName = "Farflag";
			this.farflag.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.farflag.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(553648127);
			this.farflag.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.farflag.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8F);
			this.farflag.HeaderText = "";
			this.farflag.Name = "farflag";
			this.farflag.Width = 64;
			this.grid.Columns.Add(farflag);

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
