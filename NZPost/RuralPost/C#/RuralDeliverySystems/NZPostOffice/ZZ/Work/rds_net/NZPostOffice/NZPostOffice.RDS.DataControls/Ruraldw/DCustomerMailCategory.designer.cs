
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DCustomerMailCategory
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private Metex.Windows.DataGridViewEntityComboColumn  mc_key_1;
		private Metex.Windows.DataGridViewEntityComboColumn  mc_key_2;
		private Metex.Windows.DataGridViewEntityComboColumn  mc_key_3;
        private System.Windows.Forms.Label st_customer;
	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.CustomerMailCategory);



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
			//this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(0,15);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;
            this.Controls.Add(grid);

			//
			// mc_key_1
			//
			mc_key_1 = new Metex.Windows.DataGridViewEntityComboColumn();
			this.mc_key_1.DataPropertyName = "McKey1";
			this.mc_key_1.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.mc_key_1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mc_key_1.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.mc_key_1.HeaderText = "Mail Categories";
			this.mc_key_1.Name = "d_dddw_mail_category";
			this.mc_key_1.Width = 150;
			this.mc_key_1.DropDownWidth = 714;
			this.grid.Columns.Add(mc_key_1);


			//
			// mc_key_2
			//
			mc_key_2 = new Metex.Windows.DataGridViewEntityComboColumn();
			this.mc_key_2.DataPropertyName = "McKey2";
			this.mc_key_2.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.mc_key_2.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mc_key_2.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.mc_key_2.HeaderText = "";
			this.mc_key_2.Name = "d_dddw_mail_category";
			this.mc_key_2.Width = 153;
			this.mc_key_2.DropDownWidth = 214;
			this.grid.Columns.Add(mc_key_2);


			//
			// mc_key_3
			//
			mc_key_3 = new Metex.Windows.DataGridViewEntityComboColumn();
			this.mc_key_3.DataPropertyName = "McKey3";
			this.mc_key_3.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.mc_key_3.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.mc_key_3.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.mc_key_3.HeaderText = "";
			this.mc_key_3.Name = "d_dddw_mail_category";
			this.mc_key_3.Width = 154;
			this.grid.Columns.Add(mc_key_3);


            //
            // st_customer
            //
            this.st_customer = new System.Windows.Forms.Label();
            this.st_customer.Font = new System.Drawing.Font("Arial", 8F);
            this.st_customer.ForeColor = System.Drawing.Color.Black;
            this.st_customer.Location = new System.Drawing.Point(1, 1);
            this.st_customer.Name = "st_customer";
            this.st_customer.Size = new System.Drawing.Size(500, 14);
            this.st_customer.Text = "Customer: ";
            this.st_customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.st_customer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(st_customer);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
		
		}
		#endregion

	}
}
