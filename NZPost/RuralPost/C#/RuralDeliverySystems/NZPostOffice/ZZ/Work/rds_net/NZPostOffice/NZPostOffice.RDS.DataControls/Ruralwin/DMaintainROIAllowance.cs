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
    // DataControl for ROI Allowance maintenance tab
    // [31-Mar-2021] Added calculation for annual amount
    // [31-Mar-2021] Rearranged columns

    public partial class DMaintainROIAllowance : Metex.Windows.DataUserControl
	{
		public DMaintainROIAllowance()
		{
			InitializeComponent();
			//InitializeDropdown();

            // For some reason, any changes to the grid in the designer
            // causes some of these values - particularly the ValueMember
            // and DisplayMember - to be omitted from the generated code
            // (and I don't have to remember to manually put them back).
            // Putting them here overrides the emitted code.
            this.alt_key.HeaderText = "Allowance";
            this.alt_key.Name = "alt_key";
            this.alt_key.Width = 140;
            this.alt_key.DefaultCellStyle.NullValue = null;
            this.alt_key.DefaultCellStyle.DataSourceNullValue = null;
            this.alt_key.ValueMember = "AltKey";
            this.alt_key.DisplayMember = "AltDescription";
            this.alt_key.DropDownWidth = 210;
            this.ca_effective_date.PromptChar = '0';
            this.ca_effective_date.Mask = "00/00/0000";
            this.ca_effective_date.ValueType = typeof(System.DateTime);
            this.ca_end_date.PromptChar = '0';
            this.ca_end_date.Mask = "00/00/0000";
            this.ca_end_date.ValueType = typeof(System.DateTime);

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
			alt_key.AssignDropdownType<DddwAllowanceTypesROI>();
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

        // TJB Allowances 16-Mar-2021
        // New columns - see designer
        // this.grid.Columns
        //  0    this.alt_key,
        //  1    this.ca_var2   (investment amount)
        //  2    this.ca_var3   (roi)
        //  3    this.ca_annual_amount,
        //  4    this.ca_effective_date,
        //  5    this.ca_approved,
        //  6    this.ca_paid_to_date,
        //  7    this.ca_notes});

        // TJB 16-Sept-2010: Added
        // When the user changes the value in the amount column,
        // Recalculate the column total and update it on the form.
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /*****************************************************
            * NOTE:                                             *
            *    Investment amount = contract_allowance.ca_var1 *
            *    ROI%              = allowance_type.alt_rate    *
            *                                                   *
            *    Annual amount = investment * ROI%              *
            *****************************************************/
            int column, thisRow;
            string column_name;

            thisRow = e.RowIndex;
            column  = e.ColumnIndex;
            column_name = this.grid.Columns[column].Name;

            // TJB March-2021
            // Some cell, not necessarily the ca_annual_amount cell - has changed;
            // mark the row changed
            grid.Rows[thisRow].Cells["row_changed"].Value = (string)"Y";

            if (column_name == "ca_var1")
            {
                decimal? investment_value = 0.0M;
                decimal? roi_value = 0.0M;
                decimal? ThisAmt = 0.0M;

                investment_value = (decimal?)grid.Rows[thisRow].Cells["ca_var1"].Value;
                roi_value        = (decimal?)grid.Rows[thisRow].Cells["alt_rate"].Value;

                ThisAmt = ((investment_value == null) ? 0.0M : (decimal)investment_value)
                          * ((roi_value == null) ? 0.0M : (decimal)roi_value)/100.0M;

                grid.Rows[thisRow].Cells["ca_annual_amount"].Value = ThisAmt;
            }
        }
    
    }
}
