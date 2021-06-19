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
    // TJB Allowances 12-Mar-2021: New
    // DataControl for Fixed Allowance maintenance tab
    // [31-Mar-2021] Annual amount calculation added
    // [31-Mar-2021] Rearranged columns
    // [ 5-May-2021] Changed grid_CellValueChanged
    // [19-June-2021] Disabled validating (in designer)

    public partial class DMaintainFixedAllowance : Metex.Windows.DataUserControl
	{
		public DMaintainFixedAllowance()
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
            this.alt_key.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_key.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.grid.RowsAdded += new DataGridViewRowsAddedEventHandler(grid_RowsAdded);
        }

        void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int nRows = this.grid.RowCount;
            int nRow = e.RowIndex;
            string s1, s2;

            s2 = "";
            for (nRow = 0; nRow < nRows; nRow++)
            {
                s1 = (string)this.grid.Rows[nRow].Cells["alt_key"].Value;
                DateTime? paid = (DateTime?)this.grid.Rows[nRow].Cells["ca_paid_to_date"].Value;
                if (s1 != null && s1 == s2)
                {
                    if (paid != null)
                    {
                        for (int nCol = 0; nCol < this.grid.ColumnCount; nCol++)
                        {
                            this.grid.Rows[nRow].Cells[nCol].ReadOnly = true;
                            this.grid.Rows[nRow].Cells[nCol].Style.BackColor
                                           = System.Drawing.Color.WhiteSmoke;   // A lighter grey
                        }
                    }
                }
                else
                    s2 = s1;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
    	{
            //if (!DesignMode)
            //{
            //    //InitializeDropdown();
            //}
            base.OnHandleCreated(e);
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
    	}

        //private void InitializeDropdown()
        //{
        //    alt_key.AssignDropdownType<DddwAllowanceTypesFixed>();
        //}

		public int Retrieve( int? inContract, int? inAlctId)
		{
            return RetrieveCore<MaintainAllowanceV2>(new List<MaintainAllowanceV2>
                                        (MaintainAllowanceV2.GetAllMaintainAllowanceV2(inContract, inAlctId)));
            //set_row_readability();
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

        public void SelectGridCell(int pRow, string pColumnName, bool pValue)
        {
            // TJB: derived from SetGridCellSelected
            for (int i = 0; i < this.grid.RowCount; i++)
                for (int j = 0; j < this.grid.ColumnCount; j++)
                    this.grid.Rows[i].Cells[j].Selected = false;

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

        void set_row_readability()
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    // Note: changed alt_key to readonly
                    SetGridCellReadonly(i, "alt_key", true);
                    SetGridCellReadonly(i, "ca_annual_amount", false);
                    SetGridCellReadonly(i, "ca_effective_date", false);
                    //SetGridCellReadonly(i, "ca_end_date", false);
                    SetGridCellReadonly(i, "ca_doc_description", false);
                    SetGridCellReadonly(i, "ca_approved", false);
                    SetGridCellReadonly(i, "ca_paid_to_date", true);
                    SetGridCellReadonly(i, "ca_notes", false);
                }
                else
                {
                    SetGridCellReadonly(i, "alt_key", true);
                    SetGridCellReadonly(i, "ca_annual_amount", true);
                    SetGridCellReadonly(i, "ca_effective_date", true);
                    //SetGridCellReadonly(i, "ca_end_date", true);
                    SetGridCellReadonly(i, "ca_doc_description", true);
                    SetGridCellReadonly(i, "ca_approved", true);
                    SetGridCellReadonly(i, "ca_paid_to_date", true);
                    SetGridCellReadonly(i, "ca_notes", true);
                }
            }
        }

        void bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                {
                    // Note: changed alt_key to readonly
                    SetGridCellReadonly(i, "alt_key", true);
                    SetGridCellReadonly(i, "ca_annual_amount", false);
                    SetGridCellReadonly(i, "ca_effective_date", false);
                    //SetGridCellReadonly(i, "ca_end_date", false);
                    SetGridCellReadonly(i, "ca_doc_description", false);
                    SetGridCellReadonly(i, "ca_approved", false);
                    SetGridCellReadonly(i, "ca_paid_to_date", true);
                    SetGridCellReadonly(i, "ca_notes", false);
                }
                else
                {
                    SetGridCellReadonly(i, "alt_key", true);
                    SetGridCellReadonly(i, "ca_annual_amount", true);
                    SetGridCellReadonly(i, "ca_effective_date", true);
                    //SetGridCellReadonly(i, "ca_end_date", true);
                    SetGridCellReadonly(i, "ca_doc_description", true);
                    SetGridCellReadonly(i, "ca_approved", true);
                    SetGridCellReadonly(i, "ca_paid_to_date", true);
                    SetGridCellReadonly(i, "ca_notes", true);
                }

                if (grid.Rows[i].Cells["ca_approved"].Value != null
                    && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                    SetGridCellReadonly(i, "ca_annual_amount", true);
                else
                    SetGridCellReadonly(i, "ca_annual_amount", false);

                if (this.st_protect_confirm.Text == "Y")
                    SetGridCellReadonly(i, "ca_approved", true);
                else if (grid.Rows[i].Cells["ca_paid_to_date"].Value == null)
                    SetGridCellReadonly(i, "ca_approved", false);
                else if (grid.Rows[i].Cells["ca_approved"].Value != null
                         && grid.Rows[i].Cells["ca_approved"].Value.ToString() == "Y")
                    SetGridCellReadonly(i, "ca_approved", true);
                else
                    SetGridCellReadonly(i, "ca_approved", false);
            }
        }

        // TJB  Allowances  9-Apr-2021
        // Updated the Row_changed value to "new" usage
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /*****************************************************
            * NOTE:                                             *
            *    There are no variable or fixed components used *
            *    to calculate the annual amount.                *
            *                                                   *
            *    Annual amount = <value entered>                *
            *****************************************************/
            int thisRow = e.RowIndex;
            int column = e.ColumnIndex;
            string column_name = this.grid.Columns[column].Name;

            // Get the RowChanged value, or "X" if not set
            string sRowChanged = (string)grid.Rows[thisRow].Cells["ca_row_changed"].Value ?? "X";

            if (column_name == "ca_row_changed" || column_name == "net_amount" || column_name == "calc_amount")
            {
                // Ignore RowChanged, NetAmt and CalcAmt changes triggered by changes to them below
            }
            else if (column_name == "ca_annual_amount")
            {
                // A new ca_annual_amount has been entered
                decimal? annualAmt = (decimal?)grid.Rows[thisRow].Cells["ca_annual_amount"].Value ?? 0.0M;
                decimal? calcAmt = (decimal?)grid.Rows[thisRow].Cells["calc_amount"].Value ?? 0.0M;
                decimal? netAmt = (decimal?)grid.Rows[thisRow].Cells["net_amount"].Value ?? 0.0M;
                string Approved = (string)grid.Rows[thisRow].Cells["ca_approved"].Value ?? "N";

                // Determine the previous NetAmt
                decimal? prevNetAmt;
                if( Approved == "Y" )
                    // If this is an approved allowance we'll be creating 
                    // an additional allowance to add on to the current allowance
                    prevNetAmt = netAmt;
                else
                    // If this allowance has not been approved, we'll be changing the 
                    // net amount that was added on to the pervious allowance.  To do this
                    // we take away this record's change amount which is held in the 
                    // calc_amount column (the annual_amount has already been changed,
                    // so we need its value that was previously entered).
                    prevNetAmt = netAmt - calcAmt;

                // Copy the entered ca_annual_amount to the calc_amount field
                // (which for other calc types, holds the new entered value).
                grid.Rows[thisRow].Cells["calc_amount"].Value
                                = grid.Rows[thisRow].Cells["ca_annual_amount"].Value;

                // and update the Net Amount
                grid.Rows[thisRow].Cells["net_amount"].Value = annualAmt + prevNetAmt;

                // And mark it modified ("M") if it isn't already marked new ("N") or modified.
                if ( sRowChanged != "N" && sRowChanged != "M" )
                    grid.Rows[thisRow].Cells["ca_row_changed"].Value = "M";
            }
            else if (sRowChanged != "N" && sRowChanged != "M" && sRowChanged != "C")
            {
                // Something other than the ca_annual_amount, calc_amount, net_amount, or ca_row_changed
                // has been changed.
                // If RowChanged has not already been set to one of the new ("N"), modified ("M") 
                // or changed ("C") values, mark it changed.
                grid.Rows[thisRow].Cells["ca_row_changed"].Value = "C";
            }
        }
    }
}
