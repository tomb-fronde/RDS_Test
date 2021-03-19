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
    // TJB  Allowances  19-Mar-2019
    // Changed display.  Added ca_end_date, ca_doc_description columns
    // and removed ca_annual_amount, ca_approved and ca_paid_to_date
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
            this.alt_key.DefaultCellStyle.NullValue = null;
            this.alt_key.DefaultCellStyle.DataSourceNullValue = null;
            this.alt_key.ValueMember = "AltKey";
            this.alt_key.DisplayMember = "AltDescription";

            this.ca_effective_date.Mask = "00/00/0000";
            this.ca_effective_date.PromptChar = '0';
            this.ca_effective_date.ValueType = typeof(System.DateTime);

            this.ca_end_date.Mask = "00/00/0000";
            this.ca_end_date.PromptChar = '0';
            this.ca_end_date.ValueType = typeof(System.DateTime);
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
			alt_key.AssignDropdownType<DddwAllowanceTypes>();
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

        // TJB 16-Sept-2010: Added
        // When the user changes the value in the amount column,
        // Recalculate the column total and update it on the form.
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int column;
            string column_name;

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
    }
}
