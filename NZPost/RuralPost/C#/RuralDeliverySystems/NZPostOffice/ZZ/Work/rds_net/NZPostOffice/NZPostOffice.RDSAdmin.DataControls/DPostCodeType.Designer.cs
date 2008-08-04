namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DPostCodeType
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  post_mail_town;
		//private System.Windows.Forms.DataGridViewTextBoxColumn  post_code_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn  post_code;
		private System.Windows.Forms.DataGridViewTextBoxColumn  post_district;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.PostCodeType);

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

            ////
            //// post_code_id
            ////
            //post_code_id= new System.Windows.Forms.DataGridViewTextBoxColumn();
            //this.post_code_id.DataPropertyName = "PostCodeId";
            //this.post_code_id.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //this.post_code_id.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            //this.post_code_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            //this.post_code_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            //this.post_code_id.HeaderText = "Post District:";
            //this.post_code_id.Name = "post_code_id";
            //this.post_code_id.ReadOnly = true;
            //this.post_code_id.Width = 71;
            //this.grid.Columns.Add(post_code_id);

			//
			// post_code
			//
			post_code= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.post_code.DataPropertyName = "PostCode";
			this.post_code.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.post_code.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
			this.post_code.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.post_code.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.post_code.HeaderText = "Post Code:";
			this.post_code.Name = "post_code";
			this.post_code.Width = 100;
			this.grid.Columns.Add(post_code);

            //
            // post_mail_town
            //
            post_mail_town = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_mail_town.DataPropertyName = "PostMailTown";
            this.post_mail_town.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.post_mail_town.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.post_mail_town.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.post_mail_town.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.post_mail_town.HeaderText = "Post Mail Town:";
            this.post_mail_town.Name = "post_mail_town";
            this.post_mail_town.Width = 160;
            this.grid.Columns.Add(post_mail_town);

            //
            // post_district
            //
            post_district = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.post_district.DataPropertyName = "PostDistrict";
            this.post_district.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.post_district.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1090519039);
            this.post_district.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.post_district.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.post_district.HeaderText = "Post District:";
            this.post_district.Name = "post_district";
            this.post_district.Width = 201;
            this.grid.Columns.Add(post_district);


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
