using System;
using System.Windows.Forms;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	partial class DRenewalAdjustments
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridViewCheckBoxColumn  ca_confirmed;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ca_reason;
		private Metex.Windows.DataGridViewEntityComboColumn  pct_id;
        private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn ca_date_paid;
		private NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn  ca_date_occured;
		private System.Windows.Forms.DataGridViewTextBoxColumn  ca_amount;
        private System.Windows.Forms.Label st_title;
        private System.Windows.Forms.Label st_protect_confirm;
	
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
			this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.RenewalAdjustments);


			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.AutoGenerateColumns = false;
			//this.grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8.25F);
			this.grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.grid.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid.ColumnHeadersHeight = 28;
            this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid.DataSource = this.bindingSource;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.grid.Location = new System.Drawing.Point(20, 15);
			this.grid.MultiSelect = true;
			this.grid.Name = "grid";
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(570, 252);
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(grid_DataError);
			this.grid.TabIndex = 0;
            this.grid.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(bindingSource_ListChanged);
            this.grid.CurrentCellDirtyStateChanged += new EventHandler(grid_CurrentCellDirtyStateChanged);
            this.grid.BorderStyle = BorderStyle.None;
            this.grid.CellValidating += new DataGridViewCellValidatingEventHandler(grid_Validating);
            this.Controls.Add(grid);

            //
            // ca_date_occured
            //
            ca_date_occured = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();// new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_date_occured.DataPropertyName = "CaDateOccured";
            this.ca_date_occured.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ca_date_occured.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ca_date_occured.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ca_date_occured.DefaultCellStyle.Format = "dd/MM/yyyy";
            this.ca_date_occured.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.Control;
            this.ca_date_occured.DefaultCellStyle.NullValue = "00/00/0000";
            this.ca_date_occured.HeaderText = "Occurred";
            this.ca_date_occured.Name = "ca_date_occured";
            this.ca_date_occured.Width = 70;
            this.ca_date_occured.Mask = "00/00/0000";
            this.ca_date_occured.PromptChar = '0';
            this.ca_date_occured.ValueType = typeof(DateTime);
            this.grid.Columns.Add(ca_date_occured);

            //
            // ca_reason
            //
            ca_reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_reason.DataPropertyName = "CaReason";
            this.ca_reason.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ca_reason.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ca_reason.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ca_reason.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.Control;
            this.ca_reason.HeaderText = "Reason";
            this.ca_reason.Name = "ca_reason";
            this.ca_reason.Width = 138;
            this.grid.Columns.Add(ca_reason);
            //
            // ca_date_paid
            //
            ca_date_paid = new NZPostOffice.Shared.VisualComponents.MaskedTextBoxColumn();// System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_date_paid.DataPropertyName = "CaDatePaid";
            this.ca_date_paid.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ca_date_paid.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ca_date_paid.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ca_date_paid.DefaultCellStyle.Format = "dd/MM/yy";
            this.ca_date_paid.DefaultCellStyle.NullValue = "00/00/00";
            this.ca_date_paid.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.ca_date_paid.HeaderText = "Paid";
            this.ca_date_paid.Name = "ca_date_paid";
            this.ca_date_paid.ReadOnly = true;
            this.ca_date_paid.Width = 70;
            this.ca_date_paid.PromptChar = '0';
            this.ca_date_paid.Mask = "00/00/00";
            this.grid.Columns.Add(ca_date_paid);
            //
            // ca_amount
            //
            ca_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca_amount.DataPropertyName = "CaAmount";
            this.ca_amount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ca_amount.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.ca_amount.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ca_amount.DefaultCellStyle.Format = "##,###.00";
            this.ca_amount.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.Control;
            this.ca_amount.DefaultCellStyle.NullValue = ".00";
            this.ca_amount.HeaderText = "Amount";
            this.ca_amount.Name = "ca_amount";
            this.ca_amount.Width = 47;
            this.grid.Columns.Add(ca_amount);
			//
			// ca_confirmed
			//
			ca_confirmed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ca_confirmed.DataPropertyName = "CaConfirmed";
			this.ca_confirmed.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			//this.ca_confirmed.DefaultCellStyle.ForeColor = System.Drawing.Color.Gray;
			//this.ca_confirmed.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.ca_confirmed.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
			this.ca_confirmed.DefaultCellStyle.NullValue = false;
            this.ca_confirmed.HeaderText = "Confirmed";
			this.ca_confirmed.Name = "ca_confirmed";
			this.ca_confirmed.TrueValue = "Y";
			this.ca_confirmed.FalseValue = "N";
			this.ca_confirmed.Width = 60;
			this.grid.Columns.Add(ca_confirmed);
			//
			// pct_id
			//
			pct_id = new Metex.Windows.DataGridViewEntityComboColumn();
			this.pct_id.DataPropertyName = "PctId";
			this.pct_id.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.pct_id.DefaultCellStyle.Font = new System.Drawing.Font("MS Sans Serif", 8F);
            this.pct_id.DefaultCellStyle.BackColor = System.Drawing.Color.White;//.SystemColors.Control;
			this.pct_id.HeaderText = "Pay Component Type";
            this.pct_id.Name = "pct_id";
			this.pct_id.Width = 140;
            this.pct_id.DefaultCellStyle.NullValue = null;
            this.pct_id.DefaultCellStyle.DataSourceNullValue = null;
            this.pct_id.ValueMember = "PctId";
            this.pct_id.DisplayMember = "PctDescription";
			this.pct_id.DropDownWidth = 210;
			this.grid.Columns.Add(pct_id);


            st_title = new System.Windows.Forms.Label();
            st_title.Name = "st_title";
            st_title.Width = 638;
            st_title.Height = 14;
            st_title.Font = new System.Drawing.Font("MS Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            st_title.Text = "Renewal:";
            this.Controls.Add(st_title);

            st_protect_confirm = new System.Windows.Forms.Label();
            st_protect_confirm.Name = "st_protect_confirm";
            st_protect_confirm.Width = 10;
            st_protect_confirm.Height = 14;
            st_protect_confirm.Text = "N";
            st_protect_confirm.Visible = false;
            this.Controls.Add(st_protect_confirm);

			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Size = new System.Drawing.Size(570, 252);
			this.BackColor = System.Drawing.SystemColors.Control;

		}

        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.grid.CurrentColumnName == "ca_date_occured")
            { 
            
            }
        }


        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.grid.CurrentColumnName == "pct_id")
            {
                this.grid.EndEdit();
            }
        }

        void grid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 2)//! should be date time values
            {
                MessageBox.Show("Item does not pass validation.\nPlease enter a valid Date.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);                               
                e.Cancel = true;
            }else if(e.ColumnIndex == 4)
            {
                MessageBox.Show("Item does not pass validation.\nPlease enter a valid numeric value.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }            
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (grid.RowCount <= 0)
                return;
            for (int i = 0; i < grid.RowCount; i++)
            {
                //if(isNull( ca_date_paid ) ,0,1)
                if (grid.Rows[i].Cells["ca_date_paid"].Value == null)
                {
                    grid.Rows[i].Cells["ca_date_occured"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_reason"].ReadOnly = false;
                    grid.Rows[i].Cells["pct_id"].ReadOnly = false;
                }
                else
                {
                    grid.Rows[i].Cells["ca_date_occured"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_reason"].ReadOnly = true;
                    grid.Rows[i].Cells["pct_id"].ReadOnly = true;
                }
                //if(ca_confirmed = "Y",1,0)
                if (grid.Rows[i].Cells["ca_confirmed"].Value != null && grid.Rows[i].Cells["ca_confirmed"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_amount"].ReadOnly = true;
                    grid.Rows[i].Cells["ca_amount"].Style.BackColor = System.Drawing.SystemColors.Control;
                    //this.ca_date_paid.DataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
                }
                else
                {
                    grid.Rows[i].Cells["ca_amount"].ReadOnly = false;
                    grid.Rows[i].Cells["ca_amount"].Style.BackColor = System.Drawing.Color.White;
                    
                }
                //if(DESCRIBE("st_protect_confirm.text")="Y", 1, if( isnull(ca_date_paid ),0,if(ca_confirmed = "Y",1,0))) 
                if (this.st_protect_confirm.Text == "Y")
                {
                    grid.Rows[i].Cells["ca_confirmed"].ReadOnly = true;
                }
                else if (grid.Rows[i].Cells["ca_date_paid"].Value == null)
                {
                    grid.Rows[i].Cells["ca_confirmed"].ReadOnly = false;
                }
                else if (grid.Rows[i].Cells["ca_confirmed"].Value != null && grid.Rows[i].Cells["ca_confirmed"].Value.ToString() == "Y")
                {
                    grid.Rows[i].Cells["ca_confirmed"].ReadOnly = true;
                }
                else
                {
                    grid.Rows[i].Cells["ca_confirmed"].ReadOnly = false;
                }
            }
          
        }
        #endregion

    }
}
