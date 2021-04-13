using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB Allowances 9-Mar-2021: New
    // DataControl for Time-based Allowance maintenance tab
    // [31-Mar-2021] Added calculation for annual amount

    public partial class DMaintainTimeAllowance : Metex.Windows.DataUserControl
	{
		public DMaintainTimeAllowance()
		{
			InitializeComponent();
            // For some reason, any changes to the grid in the designer
            // causes some of these values - particularly the ValueMember
            // and DisplayMember - to be omitted from the generated code
            // (and I don't have to remember to manually put them back).
            // Putting them here overrides the emitted code.
            this.alt_key.DefaultCellStyle.NullValue = null;
            this.alt_key.DefaultCellStyle.DataSourceNullValue = null;
            this.alt_key.ValueMember = "AltKey";
            this.alt_key.DisplayMember = "AltDescription";

            // For dates, it sets the prompt to '\0' instead of '0'
            this.ca_effective_date.PromptChar = '0';
            this.ca_paid_to_date.PromptChar = '0';
            //this.ca_end_date.PromptChar = '0';

            // These settings allow the row height to adjust to the text if it wraps.
            this.ca_doc_description.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_doc_description.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.ca_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        protected override void OnHandleCreated(EventArgs e)
    	{
            if (!DesignMode)
    	    {
            	InitializeDropdown();
            }
            base.OnHandleCreated(e);
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
    	}

		private void InitializeDropdown()
		{
			alt_key.AssignDropdownType<DddwAllowanceTypesTime>();
		}

		public int Retrieve( int? inContract, DateTime? inEffDate, int? inAlctId)
		{
            //set_row_readability();
            return RetrieveCore<MaintainAllowance>(new List<MaintainAllowance>
                                        (MaintainAllowance.GetAllMaintainAllowance(inContract, inEffDate, inAlctId)));
		}

        public void SetGridCellSelected(int pRow, string pColumnName, bool pValue)
        {
            this.grid.Rows[pRow].Cells[pColumnName].Selected = pValue;
            for (int i = 0; i < this.grid.ColumnCount; i++)
                if (this.grid.Columns[i].Name == pColumnName)
                {
                    this.grid.Rows[pRow].Cells[i].Selected = pValue;
                    break;
                }
        }

        public void SetGridRowReadOnly(int pRow, bool pValue)
        {
            this.grid.Rows[pRow].ReadOnly = pValue;
        }

        public bool GetGridRowReadOnly(int pRow)
        {
            return this.grid.Rows[pRow].ReadOnly;
        }

        public void SetGridColumnReadOnly(string pColumnName, bool pValue)
        {
            for (int i = 0; i < this.grid.ColumnCount; i++)
                if (this.grid.Columns[i].Name == pColumnName)
                {
                    this.grid.Columns[i].ReadOnly = pValue;
                    break;
                }
        }

        public void SetGridCellReadonly(int nRow, string sCell, bool bValue)
        {
            // Set the cell's Readonly property to true/false
            // and its background colour to 'control' if readonly, 'Window' (white) if not
            grid.Rows[nRow].Cells[sCell].ReadOnly = bValue;
            if (bValue)
                grid.Rows[nRow].Cells[sCell].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey
            else
                grid.Rows[nRow].Cells[sCell].Style.BackColor = System.Drawing.SystemColors.Window;  // Read/write = White

            grid.Rows[nRow].Cells[sCell].Style.ForeColor = System.Drawing.SystemColors.WindowText;  // Text = Black
        }

        // TJB 16-Sept-2010: Added
        // When the user changes the value in the amount column,
        // Recalculate the column total and update it on the form.
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /***************************************************
            * NOTE:                                           *
            *    Hours per week = contract_allowance.ca_var1  *
            *    Labour rate    = allowance_type.alt_rate     *
            *    Weeks per year = allowance_type.alt_wks_yr   *
            *    ACC%           = allowance_type.alt_acc      *
            *                                                 *
            *    Activity amount = Hours * rate * weeks       *
            *    ACC amount      = Activity amount * ACC%     *
            *                                                 *
            *    Annual_amount = Activity amount + ACC amount *
            ***************************************************/
            int column, thisRow;
            string column_name;

            thisRow = e.RowIndex;
            column = e.ColumnIndex;
            column_name = this.grid.Columns[column].Name;

            if (column_name == "ca_var1")
            {
                decimal? hours;
                decimal? rate;
                decimal? wks;
                decimal? acc;
                decimal? TimeAmt = 0.0M;
                decimal? ACCAmt  = 0.0M;

                hours = (decimal?)grid.Rows[thisRow].Cells["ca_var1"].Value;
                rate  = (decimal?)grid.Rows[thisRow].Cells["alt_rate"].Value;
                wks   = (decimal?)grid.Rows[thisRow].Cells["alt_wks_yr"].Value;
                acc   = (decimal?)grid.Rows[thisRow].Cells["alt_acc"].Value;

                TimeAmt = ((hours == null) ? 0.0M : (decimal)hours)
                          * ((rate == null) ? 0.0M : (decimal)rate)
                          * ((wks == null) ? 0.0M : (decimal)wks);

                ACCAmt = TimeAmt * ((acc == null) ? 0.0M : (decimal)acc);

                grid.Rows[thisRow].Cells["ca_annual_amount"].Value = TimeAmt + ACCAmt;
            }

            // TJB 9-April-2021
            // If the ca_annual_amount or hours (ca_var1) has changed and this row 
            // isn't marked as new ("N") and hasn't already been marked modified ("M"), 
            // mark it mark it changed ("C") or modified ("M") as appropriate
            string sRowChanged = (string)grid.Rows[thisRow].Cells["ca_row_changed"].Value ?? "X";
            if (!(sRowChanged == "N" || sRowChanged == "M"))
            {
                if (column_name == "ca_annual_amount" || column_name == "ca_var1")
                    grid.Rows[thisRow].Cells["ca_row_changed"].Value = (string)"M";
                else
                    grid.Rows[thisRow].Cells["ca_row_changed"].Value = (string)"C";
            }
        }
    }
}
