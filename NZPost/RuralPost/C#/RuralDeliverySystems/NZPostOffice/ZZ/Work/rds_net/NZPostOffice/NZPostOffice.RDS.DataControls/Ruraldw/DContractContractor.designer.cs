using System.Windows.Forms;
namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DContractContractor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewTextBoxColumn  contractor_supplier_no;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn cr_effective_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ccontractor_name;
        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.DataGridViewImageColumn pcklst_p;
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.ContractContractor);
            st_title = new System.Windows.Forms.Label();
            st_title.Height = 14;
            st_title.Width = 600;
            st_title.Font = new System.Drawing.Font("MS Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            st_title.Text = "text";
            st_title.Name = "st_title";
            this.Controls.Add(st_title);
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
            this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.grid.Size = new System.Drawing.Size(570, 252);
			this.grid.TabIndex = 0;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid.BorderStyle = BorderStyle.None;
            this.grid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;

            //this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(grid_CurrentCellDirtyStateChanged);
            this.grid.DataError +=new System.Windows.Forms.DataGridViewDataErrorEventHandler(grid_DataError);
            
			//
			// contractor_supplier_no
			//
			contractor_supplier_no= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contractor_supplier_no.DataPropertyName = "ContractorSupplierNo";
			this.contractor_supplier_no.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.contractor_supplier_no.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
			this.contractor_supplier_no.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.contractor_supplier_no.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.contractor_supplier_no.HeaderText = "Supplier No";
			this.contractor_supplier_no.Name = "contractor_supplier_no";
			this.contractor_supplier_no.Width = 68;
            this.contractor_supplier_no.DefaultCellStyle.NullValue = null;
			this.grid.Columns.Add(contractor_supplier_no);


			//
			// ccontractor_name
			//
			ccontractor_name= new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ccontractor_name.DataPropertyName = "CcontractorName";
			this.ccontractor_name.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			//this.ccontractor_name.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromWin32(1087955144);
			this.ccontractor_name.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.ccontractor_name.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.ccontractor_name.HeaderText = "Owner Driver";
			this.ccontractor_name.Name = "ccontractor_name";
			this.ccontractor_name.Width = 262;
            this.ccontractor_name.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			this.grid.Columns.Add(ccontractor_name);

            pcklst_p = new System.Windows.Forms.DataGridViewImageColumn();
            this.pcklst_p.Width = 24;
            this.pcklst_p.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            pcklst_p.Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;
            this.grid.Columns.Add(pcklst_p);


			//
			// cr_effective_date
			//
			cr_effective_date= new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();
			this.cr_effective_date.DataPropertyName = "CrEffectiveDate";
			this.cr_effective_date.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.cr_effective_date.DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
			this.cr_effective_date.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.cr_effective_date.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.cr_effective_date.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.cr_effective_date.DefaultCellStyle.NullValue = "00/00/0000";
            this.cr_effective_date.ValueType = typeof(System.DateTime);
			this.cr_effective_date.HeaderText = "Effective Date";
			this.cr_effective_date.Name = "cr_effective_date";
			this.cr_effective_date.Width = 89;
            this.cr_effective_date.Mask = "00/00/0000";
            this.cr_effective_date.PromptChar = '0';
            this.cr_effective_date.ValueType = typeof(System.DateTime);
			this.grid.Columns.Add(cr_effective_date);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(638, 252);
			//this.BackColor = System.Drawing.ColorTranslator.FromWin32(80269524);
			this.Controls.Add(grid);
            //this.grid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(grid_Validating);
		}

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 3)//! should be date time values
            {
                MessageBox.Show("Item does not pass validation.\nPlease enter a valid Date.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            this.grid.EndEdit();
        }

        void grid_Validating(object sender,System.Windows.Forms.DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                System.DateTime outer = new System.DateTime() ;
                if (e.FormattedValue != null && e.FormattedValue.ToString() != "" && !System.DateTime.TryParse(e.FormattedValue.ToString(), out outer))
                    e.Cancel = true;
            }
        }
		#endregion

	}
}
