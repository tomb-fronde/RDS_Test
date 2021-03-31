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
    // DataControl for Distance Allowance maintenance tab
    // [31-Mar-2021] Added calculation for annual amount

    public partial class DMaintainDistanceAllowance : Metex.Windows.DataUserControl
	{
		public DMaintainDistanceAllowance()
		{
			InitializeComponent();
            
            // For some reason, any changes to the grid in the designer
            // causes some of these values - particularly the ValueMember
            // and DisplayMember - to be omitted from the generated code
            // (and I don't have to remember to manually put them back).
            // Putting them here overrides the emitted code.
            this.alt_key.DefaultCellStyle.NullValue = null;
            this.alt_key.DefaultCellStyle.DataSourceNullValue = null;
            this.alt_key.ValueMember   = "AltKey";
            this.alt_key.DisplayMember = "AltDescription";

            // For dates, it sets the prompt to '\0' instead of '0'
            this.ca_effective_date.PromptChar = '0';
            this.ca_paid_to_date.PromptChar = '0';
            //this.ca_end_date.PromptChar = '0';

            // These settings allow the row height to adjust to the text if it wraps.
            this.ca_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.ca_doc_description.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_doc_description.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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
			alt_key.AssignDropdownType<DddwAllowanceTypesDistance>();
		}

		public int Retrieve( int? inContract, DateTime? inEffDate, int? inAlctId)
		{
            set_row_readability();
            return RetrieveCore<MaintainVehAllowance>(new List<MaintainVehAllowance>
                                        (MaintainVehAllowance.GetAllMaintainVehAllowance(inContract, inEffDate, inAlctId)));
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

        // TJB 16-Sept-2010: Added
        // When the user changes the value in the amount column,
        // Recalculate the column total and update it on the form.
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /********************************************************
            * NOTE:                                                *
            *    Days per week    = contract_allowance.ca_var1     *
            *    Distance per day = contract_allowance.ca_dist_day *
            *    Hours per week   = contract_allowance.ca_hrs_wk   *
            *    Hourly rate      = allowance_type.alt_rate        *
            *    Weeks per year   = allowance_type.alt_wks_yr      *
            *    ACC%             = allowance_type.alt_acc         *
            *                                                      *
            *    Annual hours = Days-wk * Hrs-wk * Wks-yr          *
            *    Yearly Hours amount = Annual hours * Labour rate  *
            *    Annual hours amount = Yearly amount               *
            *                          + Yearly amount * ACC%/100  *
            *                                                      *
            *    Yearly distance = Distance-day * Days-wk * Wks-yr *
            *    Annual distance amount = (TBA)                    *
            *                                                      *
            *    Annual fixed vehicle costs = (TBA)                *
            *                                                      *
            *    Annual amount = Annual hour amount                *
            *                    + Annual distance amount          *
            *                    + Annual fixed costs              *
            ********************************************************/
            int column, thisRow;
            string column_name;
            string sHdr;

            thisRow = e.RowIndex;
            column = e.ColumnIndex;
            column_name = this.grid.Columns[column].Name;
            sHdr = this.grid.Columns[column].HeaderText;
            string s = sHdr;

            // TJB March-2021
            // Some cell, not necessarily the ca_annual_amount cell - has changed;
            // mark the row changed
            grid.Rows[thisRow].Cells["row_changed"].Value = (string)"Y";

            if (column_name == "ca_var1" || column_name == "ca_dist_day" || column_name == "ca_hrs_wk")
            {
                // From contract_allowances
                decimal days_wk      = 0.0M;
                decimal hours_wk     = 0.0M;
                decimal distance_day = 0.0M;
                string  costs_covered = "N";

                // From allowance_type
                decimal rate_hr      = 0.0M;
                decimal weeks_yr     = 0.0M;
                decimal ACC          = 0.0M;
                decimal fuel_pk      = 0.0M;
                decimal ruc_pk       = 0.0M;

                // From vehicle_allowance_rates
                decimal carrier_pa   = 0.0M;
                decimal repairs_pk   = 0.0M;
                decimal licence_pa   = 0.0M;
                decimal tyres_pk     = 0.0M;
                decimal allowance_pk = 0.0M;
                decimal insurance_pa = 0.0M;
                decimal ror_pa       = 0.0M;

                // Intermediate calculated velues
                decimal HoursAmt     = 0.0M;
                decimal DistAmt      = 0.0M;
                decimal Dist_yr      = 0.0M;
                decimal VehCosts     = 0.0M;

                days_wk      = of_GetDecimalValue(thisRow, "ca_var1");
                hours_wk     = of_GetDecimalValue(thisRow, "ca_hrs_wk");
                distance_day = of_GetDecimalValue(thisRow, "ca_dist_day");

                rate_hr      = of_GetDecimalValue(thisRow, "alt_rate");
                weeks_yr     = of_GetDecimalValue(thisRow, "alt_wks_yr");
                ACC          = of_GetDecimalValue(thisRow, "alt_acc");
                fuel_pk      = of_GetDecimalValue(thisRow, "alt_fuel_pk");
                ruc_pk       = of_GetDecimalValue(thisRow, "alt_ruc_pk");

                repairs_pk   = of_GetDecimalValue(thisRow, "var_repairs_pk");
                tyres_pk     = of_GetDecimalValue(thisRow, "var_tyres_pk");
                allowance_pk = of_GetDecimalValue(thisRow, "var_allowance_pk");
                carrier_pa   = of_GetDecimalValue(thisRow, "var_carrier_pa");
                licence_pa   = of_GetDecimalValue(thisRow, "var_licence_pa");
                insurance_pa = of_GetDecimalValue(thisRow, "var_insurance_pa");
                ror_pa       = of_GetDecimalValue(thisRow, "var_ror_pa");

                costs_covered = (string)grid.Rows[thisRow].Cells["ca_costs_covered"].Value;
                
                HoursAmt = (hours_wk * weeks_yr) * rate_hr;
                Dist_yr  = (distance_day * days_wk * weeks_yr);
                DistAmt  = (Dist_yr/1000)*(ruc_pk + repairs_pk + tyres_pk + allowance_pk);

                if(costs_covered == "N" || costs_covered == "" || costs_covered == null)
                    VehCosts = carrier_pa + licence_pa + insurance_pa + ror_pa;
                else
                    VehCosts = 0.0M;

                grid.Rows[thisRow].Cells["ca_annual_amount"].Value = (decimal?)(HoursAmt + DistAmt + VehCosts);
            }
        }

        private decimal of_GetDecimalValue(int thisRow, string sColumn)
        {
            // Gets the value of the named column and returns it as a Decimal.
            // The columns are Decimal? and may be null; return 0 in this case

            decimal? val = (decimal?)grid.Rows[thisRow].Cells[sColumn].Value;
            return (decimal)((val == null) ? 0.0M : val);
        }
    }
}
