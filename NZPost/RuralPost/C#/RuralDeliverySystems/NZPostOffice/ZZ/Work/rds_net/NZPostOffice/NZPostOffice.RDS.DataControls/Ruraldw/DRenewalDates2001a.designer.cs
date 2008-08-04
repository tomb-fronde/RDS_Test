using System;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRenewalDates2001a
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rr_rates_effective_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  status;
		private System.Windows.Forms.DataGridViewTextBoxColumn  rates_complete;
		private Metex.Windows.DataGridViewEntityComboColumn  rg_code;

	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RenewalDates2001a);

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
            this.grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grid.Size = new System.Drawing.Size(638, 252);
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);

			//
			// rr_rates_effective_date
			//
			rr_rates_effective_date= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rr_rates_effective_date.DataPropertyName = "RrRatesEffectiveDate";
			this.rr_rates_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.rr_rates_effective_date.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control; //System.Drawing.ColorTranslator.FromWin32(553648127);
			//?this.rr_rates_effective_date.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif (rates_complete =0 and  status <;>;'Frozen',rgb(255,0,0),rgb(0,0,0)));
			this.rr_rates_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.rr_rates_effective_date.DefaultCellStyle.Format = "MMM yy";
            this.rr_rates_effective_date.HeaderText = "Date";
			this.rr_rates_effective_date.Name = "rr_rates_effective_date";
			this.rr_rates_effective_date.ReadOnly = true;
			this.rr_rates_effective_date.Width = 42;
			this.grid.Columns.Add(rr_rates_effective_date);

            //
            // rg_code
            //
            rg_code = new Metex.Windows.DataGridViewEntityComboColumn();
            this.rg_code.DataPropertyName = "RgCode";
            this.rg_code.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;// System.Drawing.ColorTranslator.FromWin32(553648127);
            //?this.rg_code.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif (rates_complete =0 and  status <;>;'Frozen',rgb(255,0,0),rgb(0,0,0)));
            this.rg_code.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.rg_code.HeaderText = "Renewal Group";
            this.rg_code.Name = "d_dddw_renewalgroup";
            this.rg_code.Width = 119;
            this.rg_code.DisplayMember = "RgDescription";
            this.rg_code.ValueMember = "RgCode";
            this.rg_code.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.rg_code.ReadOnly = true;
            this.grid.Columns.Add(rg_code);


            //
            // status
            //
            status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status.DataPropertyName = "Status";
            this.status.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.status.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control; //System.Drawing.ColorTranslator.FromWin32(553648127);
            //?this.status.DefaultCellStyle.ForeColor = System.Drawing.ColorTranslator.FromWin32(0~tif (rates_complete =0 and  status <;>;'Frozen',rgb(255,0,0),rgb(0,0,0)));
            this.status.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.Width = 126;
            this.grid.Columns.Add(status);

            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(grid_DataError);
			//
			// rates_complete
			//
			rates_complete= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rates_complete.DataPropertyName = "RatesComplete";
			this.rates_complete.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.rates_complete.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
			this.rates_complete.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.rates_complete.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12F);
			this.rates_complete.HeaderText = "";
			this.rates_complete.Name = "rates_complete";
			this.rates_complete.ReadOnly = true;
			this.rates_complete.Width = 82;
            this.rates_complete.Visible = false;
			this.grid.Columns.Add(rates_complete);


			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(79216776);
			this.Controls.Add(grid);
		}

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            //if (rates_complete =0 and  status <>'Frozen',rgb(255,0,0),rgb(0,0,0))
            for (int i = 0; i < grid.RowCount; i++)
            {
                if (Convert.ToInt32(grid.Rows[i].Cells["rates_complete"].Value) == 0 && 
                    Convert.ToString(grid.Rows[i].Cells["status"].Value) != "Frozen")
                {
                    grid.Rows[i].Cells["rr_rates_effective_date"].Style.ForeColor = System.Drawing.Color.Red;
                    grid.Rows[i].Cells["d_dddw_renewalgroup"].Style.ForeColor = System.Drawing.Color.Red;
                    grid.Rows[i].Cells["status"].Style.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    grid.Rows[i].Cells["rr_rates_effective_date"].Style.ForeColor = System.Drawing.Color.Black;
                    grid.Rows[i].Cells["d_dddw_renewalgroup"].Style.ForeColor = System.Drawing.Color.Black;
                    grid.Rows[i].Cells["status"].Style.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            return;
        }
		#endregion

	}
}
