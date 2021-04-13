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
    // TJB  Allowances  March-2021
    // Changed display.  Added ca_end_date, ca_doc_description columns
    // and removed ca_annual_amount, ca_approved and ca_paid_to_date.
    // Set row height to adjust to fit multi-line text.
    // [2-Apr-2021] Removed (commented out) DataGridViewCellEventHandler: obsolete
    // [6-Apr-2021] Removed ca_end_date
    //
    // TJB 16-Sept-2010: Added
    // Update total amount when an item amount is changed.
    // See grid_CellValueChanged

    // TJB RPCR_017 July-2010
    // Significantly re-written
    // Displays all current period records in a gris, rather than
    // a single added record in a Windows form.
    // See DAddAllowance0 for original

    public partial class DAddAllowance : Metex.Windows.DataUserControl
	{
		public DAddAllowance()
		{
			InitializeComponent();
			//InitializeDropdown();

            // These are either missing or incorrectly included in the 
            // designer-generated code.
            this.var_id.DefaultCellStyle.NullValue = null;
            this.var_id.DefaultCellStyle.DataSourceNullValue = null;
            this.var_id.ValueMember = "VarId";
            this.var_id.DisplayMember = "VarDescription";

            this.alt_key.DefaultCellStyle.NullValue = null;
            this.alt_key.DefaultCellStyle.DataSourceNullValue = null;
            this.alt_key.ValueMember = "AltKey";
            this.alt_key.DisplayMember = "AltDescription";

            this.ca_effective_date.Mask = "00/00/0000";
            this.ca_effective_date.PromptChar = '0';
            this.ca_effective_date.ValueType = typeof(System.DateTime);
/*
            // These settings allow the row height to adjust to the text if it wraps.
            this.ca_doc_description.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_doc_description.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.ca_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
*/
        }

        protected override void OnHandleCreated(EventArgs e)
    	{
    	    {
            	InitializeDropdown();
            }
            base.OnHandleCreated(e);
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
    	}

		private void InitializeDropdown()
		{
            alt_key.AssignDropdownType<DddwAllowanceTypes>();
            var_id.AssignDropdownType<DddwVehicleAllowanceRates>();
        }

		public int Retrieve( int? inContract, DateTime? inEffDate)
		{
            set_row_readability();
            return RetrieveCore<AddAllowance>(new List<AddAllowance>
			                           	(AddAllowance.GetAllAddAllowance(inContract, inEffDate)));
		}

        // TJB RPCR_017 July-2010
        // These have been added to provide a mechanism for altering
        // grid properties.  I couldn't figure out how to access the grid
        // properties from the WAddAllowance form.
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

        // TJB Allowances 2-Apr-2021
        // New function: if the selected allowance type is of distance-based calculation
        // make the Vehicle type visible; otherwise not visible.  Only distance-based
        // calculations need to know whay type of vehicle is involved.
        // NOTE: alct_id = 5 is a distance-based calculation.  Sorry its hard-coded ;(
        //
        // this didn't work either
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int column, thisRow;
            string column_name;
            int? nAlctId;

            thisRow = e.RowIndex;
            column = e.ColumnIndex;
            column_name = this.grid.Columns[column].Name;
            if (column_name == "alt_key")
            {
                string sAltDescription = (string)((DataGridView)sender).CurrentCell.EditedFormattedValue;
                int i = sAltDescription.IndexOf(',');
                int j = sAltDescription.IndexOf('.', i);
                string s = sAltDescription.Substring(i + 1, (j - (i + 1)));

                nAlctId = (int.TryParse(s, out i)) ? i : (int?)null;

                if (nAlctId == 5)
                {
                    grid.Rows[thisRow].Cells["alct_id"].Value = nAlctId;
                    grid.Rows[thisRow].Cells["var_id"].ReadOnly = false;
                    grid.Rows[thisRow].Cells["var_id"].Style.BackColor 
                                       = System.Drawing.SystemColors.Window;
                }
                else
                {
                    grid.Rows[thisRow].Cells["alct_id"].Value = nAlctId;
                    grid.Rows[thisRow].Cells["var_id"].ReadOnly = true;
                    grid.Rows[thisRow].Cells["var_id"].Style.BackColor
                                       = System.Drawing.SystemColors.Control;
                }

                // The grid is inside a panel inside the form, 
                // thus we have to go two layers out to get to the form.
//                this.Parent.Parent.Controls["Total"].Text = sumThisAmt.ToString();
            }
        }
/*
        // TJB 16-Sept-2010: Added  [Obsolete as of Apr-2021]
        // When the user changes the value in the amount column,
        // Recalculate the column total and update it on the form.
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int column, thisRow;
            string column_name;

            thisRow = e.RowIndex;
            column = e.ColumnIndex;
            column_name = this.grid.Columns[column].Name;
            if (column_name == "ca_annual_amount")
            {
                int row, nRows;
                decimal? value = 0.0M;
                decimal sumThisAmt = 0.0M;

                // Recalculate the column total
                nRows = this.grid.RowCount;
                for (row = 0; row < nRows; row++)
                {
                    value = (decimal?)this.grid[column, row].Value;
                    sumThisAmt += (value == null) ? 0.0M : (decimal)value;
                }
                // Update the total on the form.
                // The grid is inside a panel inside the form, 
                // thus we have to go two layers out to get to the form.
                this.Parent.Parent.Controls["Total"].Text = sumThisAmt.ToString();
            }
        }
*/
    }
}
