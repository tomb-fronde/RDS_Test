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
    // Layout for Activity Allowance maintenance tab
    // [31-Mar-2021] Added calculation for annual amount

    public partial class DMaintainActivityAllowance : Metex.Windows.DataUserControl
	{
        public DMaintainActivityAllowance(int inActivityId)
		{
			InitializeComponent();
			//InitializeDropdown();

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
            this.ca_end_date.PromptChar = '0';

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
            alt_key.AssignDropdownType<DddwAllowanceTypesActivity>();
		}

		public int Retrieve( int? inContract, DateTime? inEffDate, int? inAlctId)
		{
            set_row_readability();
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

        // TJB  Allowance  16-Mar-2021
        // The grid columns for this tab (see designer)
        // this.grid.Columns
        //  0    this.alt_description,
        //  1    this.activity_count, (per week)
        //  2    this.activity_rate,
        //  3    this.wks_per_year
        //  4    this.ca_annual_amount,
        //  5    this.ca_effective_date,
        //  6    this.ca_approved,
        //  7    this.ca_paid_to_date,
        //  8    this.ca_notes});
        //
        // TJB 16-Sept-2010: Added
        // When the user changes the value in the amount column,
        // Recalculate the column total and update it on the form.
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /*****************************************************
            * NOTE:                                             *
            *    Activity count = contract_allowance.ca_var1    *
            *    Activity rate  = allowance_type.alt_rate       *
            *    Weeks per year = allowance_type.alt_wks_yr     *
            *                                                   *
            *    Annual amount = Count * rate * WeeksPerYear    *
            *****************************************************/
            int column, thisRow;
            string column_name;

            thisRow = e.RowIndex;
            column = e.ColumnIndex;
            column_name = this.grid.Columns[column].Name;

            // TJB March-2021
            // Some cell, not necessarily the ca_annual_amount cell - has changed;
            // mark the row changed
            grid.Rows[thisRow].Cells["row_changed"].Value = (string)"Y";

            if (column_name == "ca_var1")
            {   // Calculate the allowance annual amount (ca_annual_amount)
                decimal? ThisAmt = 0.0M;
                decimal? activity_count = 0;
                decimal? wks_per_year = 0;
                decimal? activity_rate = 0.0M;

                activity_count = (decimal?)grid.Rows[thisRow].Cells["ca_var1"].Value;
                activity_rate = (decimal?)grid.Rows[thisRow].Cells["alt_rate"].Value;
                wks_per_year = (decimal?)grid.Rows[thisRow].Cells["alt_wks_yr"].Value;

                ThisAmt = ((activity_count == null) ? 0 : (int)activity_count)
                          * ((activity_rate == null) ? 0.0M : (decimal)activity_rate)
                          * ((wks_per_year == null) ? 0 : (int)wks_per_year);

                grid.Rows[thisRow].Cells["ca_annual_amount"].Value = ThisAmt;
            }
        }
    }
}
