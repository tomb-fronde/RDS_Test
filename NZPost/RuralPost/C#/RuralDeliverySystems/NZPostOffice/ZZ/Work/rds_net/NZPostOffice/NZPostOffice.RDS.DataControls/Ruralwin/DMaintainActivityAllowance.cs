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
    // DataControl for Activity Allowance maintenance tab
    // [31-Mar-2021] Added calculation for annual amount

    public partial class DMaintainActivityAllowance : Metex.Windows.DataUserControl
	{
        public DMaintainActivityAllowance()
		{
			InitializeComponent();

            // For dates, it sets the prompt to '\0' instead of '0'
            this.ca_effective_date.PromptChar = '0';
            this.ca_effective_date.Mask = "00/00/0000";
            this.ca_effective_date.ValueType = typeof(System.DateTime);

            // These settings allow the row height to adjust to the text if it wraps.
            this.ca_doc_description.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_doc_description.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.ca_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		}

        protected override void OnHandleCreated(EventArgs e)
    	{
            //if (!DesignMode)
            //{
            //    InitializeDropdown();
            //}
            base.OnHandleCreated(e);
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
    	}

        //private void InitializeDropdown()
        //{
        //    alt_key.AssignDropdownType<DddwAllowanceTypesActivity>();
        //}

		public int Retrieve( int? inContract, int? inAlctId)
		{
            return RetrieveCore<MaintainAllowanceV2>(new List<MaintainAllowanceV2>
                                        (MaintainAllowanceV2.GetAllMaintainAllowanceV2(inContract, inAlctId)));
		}

        public void SetGridCellFocus(int pRow, string pColumnName, bool pValue)
        {
            if (pValue)
            {
                this.grid.CurrentCell = this.grid.Rows[pRow].Cells[pColumnName];
                this.grid.BeginEdit(true);
            }
            else
                this.grid.CurrentCell = this.grid.Rows[pRow].Cells["alt_key"];
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

        // TJB  Allowance  16-Mar-2021
        // The grid columns for this tab (see designer)
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /************************************************************
            * NOTE:                                                    *
            *    Activity count  = ca_var1     from contract_allowance *
            *    Activity rate   = alt_rate    from allowance_type     *
            *    Weeks per year  = alt_wks_yr  from allowance_type     *
            *                                                          *
            *    Annual amount = Count * rate * WeeksPerYear           *
            ***********************************************************/
            int thisRow = e.RowIndex;
            int column = e.ColumnIndex;
            string column_name = this.grid.Columns[column].Name;

            // Get the RowChanged value, or "X" if not set
            string sRowChanged = (string)grid.Rows[thisRow].Cells["ca_row_changed"].Value ?? "X";

            if (column_name == "ca_row_changed" || column_name == "net_amount"
                || column_name == "calc_amount" || column_name == "ca_annual_amount")
            {
                // Ignore rowChanged, netAmt, calcAmt and annualAmt changes triggered by changes to them below
            }
            else if (column_name == "ca_var1")
            {
                // A new activity count (in ca_var1) has been entered
                decimal? annualAmt = (decimal?)grid.Rows[thisRow].Cells["ca_annual_amount"].Value ?? 0.0M;
                decimal? activity_count = (decimal?)grid.Rows[thisRow].Cells["ca_var1"].Value ?? 0.0M;
                decimal? activity_rate = (decimal?)grid.Rows[thisRow].Cells["alt_rate"].Value ?? 0.0M;
                decimal? wks_per_year = (decimal?)grid.Rows[thisRow].Cells["alt_wks_yr"].Value ?? 0.0M;
                decimal? acc = (decimal?)grid.Rows[thisRow].Cells["alt_acc"].Value ?? 0.0M;
                decimal? netAmt = (decimal?)grid.Rows[thisRow].Cells["net_amount"].Value ?? 0.0M;
                string   Approved = (string)grid.Rows[thisRow].Cells["ca_approved"].Value ?? "N";

                // Determine the previous NetAmt
                decimal? prevNetAmt;
                if (Approved == "Y")
                    // If this is an approved allowance we'll be creating 
                    // an additional allowance to add on to the current allowance
                    prevNetAmt = netAmt;
                else
                    // If this allowance has not been approved, we'll be changing the 
                    // net amount that was added on to the pervious allowance. To do this
                    // we take away this record's previous change amount (still in
                    // ca_annual_amount; we're about to replace it with a new change amount).
                    prevNetAmt = netAmt - annualAmt;

                // Calculate the new net amount and save in calc_amount and net_amount
                decimal? newNetAmt = (activity_count * wks_per_year * activity_rate);
                newNetAmt = Decimal.Round((decimal)newNetAmt, 2);
                grid.Rows[thisRow].Cells["calc_amount"].Value = newNetAmt;
                grid.Rows[thisRow].Cells["net_amount"].Value = newNetAmt;

                // Calculate the change amount and save in ca_annual_amount
                decimal? changeAmt = newNetAmt - prevNetAmt;
                grid.Rows[thisRow].Cells["ca_annual_amount"].Value = changeAmt;

                // Mark it modified ("M") if it isn't already marked new ("N") or modified.
                if (sRowChanged != "N" && sRowChanged != "M")
                    grid.Rows[thisRow].Cells["ca_row_changed"].Value = "M";
            }
            else if (sRowChanged != "N" && sRowChanged != "M" && sRowChanged != "C")
            {
                // Something other than the ca_annual_amount, calc_amount, net_amount, investment amount (ca_var1),
                // or ca_row_changed has been changed.
                // If RowChanged has not already been set to one of the new ("N"), modified ("M") 
                // or changed ("C") values, mark it changed.
                grid.Rows[thisRow].Cells["ca_row_changed"].Value = "C";
            }
        }
    }
}
