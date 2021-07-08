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
    // [31-Mar-2021]  Added calculation for annual amount
    // [19-June-2021] Disabled validating (in designer)
    // [26 June 2021] Changed calculation to use PaidToDate instead of Approved
    // [28-June-2021] Refined set_row_readonly to handle both true and false (in designer)
    // [8-Jul-2021]   Bug fix: fuel_use_pk is fuel_use per 100Km
    // [8-Jul-2021]   Added code to grid_RowsAdded to hide alt_rate when effective_date < 1'Jul-2021'

    public partial class DMaintainDistanceAllowance : Metex.Windows.DataUserControl
	{
		public DMaintainDistanceAllowance()
		{
			InitializeComponent();

            // For dates, it sets the prompt to '\0' instead of '0'
            this.ca_effective_date.PromptChar = '0';
            this.ca_effective_date.Mask = "00/00/0000";
            this.ca_effective_date.ValueType = typeof(System.DateTime);

            // These settings allow the row height to adjust to the text if it wraps.
            this.ca_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.ca_doc_description.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ca_doc_description.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.alt_key.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_key.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //this.var_id.DefaultCellStyle.NullValue = null;
            //this.var_id.DefaultCellStyle.DataSourceNullValue = null;
            //this.var_id.ValueMember = "VarId";
            //this.var_id.DisplayMember = "VarDescription"; 

            this.grid.RowsAdded += new DataGridViewRowsAddedEventHandler(grid_RowsAdded);
        }

        void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int nRows = this.grid.RowCount;
            int nRow = e.RowIndex;
            DateTime? paidDate, effDate;
            DateTime dateLimit;
            string thisAltKey, prevAltKey;

            prevAltKey = "";
            for (nRow = 0; nRow < nRows; nRow++)
            {
                thisAltKey = (string)this.grid.Rows[nRow].Cells["alt_key"].Value;
                paidDate = (DateTime?)this.grid.Rows[nRow].Cells["ca_paid_to_date"].Value;
                if (thisAltKey != null && thisAltKey == prevAltKey)
                {
                    if (paidDate != null && paidDate > DateTime.MinValue)
                    {
                        for (int nCol = 0; nCol < this.grid.ColumnCount; nCol++)
                        {
                            this.grid.Rows[nRow].Cells[nCol].ReadOnly = true;
                            this.grid.Rows[nRow].Cells[nCol].Style.BackColor
                                           = System.Drawing.SystemColors.Control; // Grey
                        }
                    }
                    // If the contract allowance effective date is earlier than 
                    // the limit date (start of calculating allowances - RDS 7.1.17) 
                    // don't display the rate.
                    effDate = (DateTime?)this.grid.Rows[nRow].Cells["ca_effective_date"].Value;
                    dateLimit = DateTime.Parse("1-Jul-2021");
                    if (effDate == null || (DateTime)effDate < dateLimit)
                    {
                        this.grid.Rows[nRow].Cells["alt_rate"].Value = null;
                    }
                }
                else
                    // ... but do show the rate for any record that is modifiable
                    prevAltKey = thisAltKey;

                // A paid allowance's Approved may not be changed
                if (paidDate != null && paidDate > DateTime.MinValue)
                {
                    this.grid.Rows[nRow].Cells["ca_approved"].ReadOnly = true;
                    this.grid.Rows[nRow].Cells["ca_approved"].Style.BackColor
                                           = System.Drawing.SystemColors.Control; // Grey
                }
            }
        }

        //void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    //int nRows = this.grid.RowCount;
        //    int nRow = e.RowIndex;
        //    DateTime? paid;
        //    string thisAltKey, prevAltKey;

        //    // NOTE: the column called alt_key is actually alt_description
        //    //       so contains the allowance name, not its number
        //    thisAltKey = (string)this.grid.Rows[nRow].Cells["alt_key"].Value;
        //    if( nRow == 0 ) 
        //        prevAltKey = "xxx";
        //    else
        //        prevAltKey = (string)this.grid.Rows[nRow - 1].Cells["alt_key"].Value;

        //    if (thisAltKey != null &&  prevAltKey == thisAltKey)
        //        set_row_readonly(nRow,true);
        //    else  // This is the first occurrence
        //        set_row_readonly(nRow,false);
            
        //}

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
        //    alt_key.AssignDropdownType<DddwAllowanceTypesDistance>();
        //    var_id.AssignDropdownType<DddwVehicleAllowanceRates>();
        //}

		public int Retrieve( int? inContract, int? inAlctId)
		{
            //set_row_readability();
            return RetrieveCore<MaintainAllowanceV2>(new List<MaintainAllowanceV2>
                                        (MaintainAllowanceV2.GetAllMaintainAllowanceV2(inContract, inAlctId)));
		}

        public void SetGridCellFocus(int pRow, string pColumnName, bool pValue)
        {
            this.grid.ClearSelection();
            if (pValue)
            {
                this.grid.CurrentCell = this.grid.Rows[pRow].Cells[pColumnName];
                this.grid.BeginEdit(true);
            }
            else
            {
                this.grid.CurrentCell = this.grid.Rows[pRow].Cells["alt_key"];
                this.grid.CurrentCell.Selected = true;
            }
        }

        public void SetGridCellSelected(int pRow, string pColumnName, bool pValue)
        {
            this.grid.ClearSelection();
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
        
        //public bool GetGridRowReadOnly(int pRow)
        //{
        //    return this.grid.Rows[pRow].ReadOnly;
        //}

        public void SetGridColumnReadOnly(string pColumnName, bool pValue)
        {
            this.grid.Columns[pColumnName].ReadOnly = pValue;
            //for (int i = 0; i < this.grid.ColumnCount; i++)
            //    if (this.grid.Columns[i].Name == pColumnName)
            //    {
            //        this.grid.Columns[i].ReadOnly = pValue;
            //        break;
            //    }
        }

        public void SetGridCellReadonly(int nRow, string pColumnName, bool pValue)
        {
            // Set the cell's Readonly property to true/false
            // and its background colour to 'control' if readonly, 'Window' (white) if not
            grid.Rows[nRow].Cells[pColumnName].ReadOnly = pValue;
            if (pValue)
                grid.Rows[nRow].Cells[pColumnName].Style.BackColor = System.Drawing.SystemColors.Control; // Readonly = Grey
            else
                grid.Rows[nRow].Cells[pColumnName].Style.BackColor = System.Drawing.SystemColors.Window;  // Read/write = White

            grid.Rows[nRow].Cells[pColumnName].Style.ForeColor = System.Drawing.SystemColors.WindowText;  // Text = Black
        }

        private decimal of_GetDecimalValue(int thisRow, string sColumn)
        {
            // Gets the value of the named column and returns it as a Decimal.
            // The columns are Decimal? and may be null; return 0 in this case

            decimal? val = (decimal?)grid.Rows[thisRow].Cells[sColumn].Value;
            return (decimal)((val == null) ? 0.0M : val);
        }

        // TJB 16-Sept-2010: Added
        // When the user changes any of the contract_allowance values 
        // Recalculate the net amount, the change from the previous net amount 
        // and update the ca_annual_amount on the form with the change amount.
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /*************************************************************************
            * NOTE:                                                                 *
            *    Days per year    = ca_var1          from contract_allowance        *
            *    Distance per day = ca_dist_day      from contract_allowance        *
            *    Hours per week   = ca_hrs_wk        from contract_allowance        *
            *    Costs covered    = ca_costs_covered from contract_allowance        *
            *    Hourly rate      = alt_rate         from allowance_type            *
            *    Weeks per year   = alt_wks_yr       from allowance_type            *
            *    ACC%             = alt_acc          from allowance_type            *
            *    Carrier          = var_carrier_pa   from vehicle_alowance_rates    *
            *    Licencing        = var_licenc_pa    from vehicle_alowance_rates    *
            *    Insurance        = var_insurance_pa from vehicle_alowance_rates    *
            *    RoR              = var_ror_pa       from vehicle_alowance_rates    *
            *    Fuel_use_pk      = var_fuel_use_pk  from vehicle_alowance_rates    *
            *    Fuel_rate        = var_fuel_rate    from vehicle_alowance_rates    *
            *    RUC              = var_ruc_pk       from vehicle_alowance_rates    *
            *    Repairs          = var_repairs_pk   from vehicle_alowance_rates    *
            *    Tyres            = var_tyres_pk     from vehicle_alowance_rates    *
            *    Allowance        = var_allowance_pk from vehicle_alowance_rates    *
            *                                                                       *
            *    Annual hours = Hours-wk * Wks-yr                                   *
            *    Time amount = (Annual hours * Labour rate) * (1 + ACC%/100)        *
            *                                                                       *
            *    Yearly distance = Distance-day * Days-yr                           *
            *    Fuel/k per year = Fuel_use_pk * Fuel_rate                          *
            *    Distance amount                                                    *
            *        = (Fuel + RUC + Repairs + Tyres + Allowance) * (Distance/1000) *
            *                                                                       *
            *    if Costs covered  (= 'Y')                                          *
            *          Vehicle amount = Carrier + Licence + Insurance + RoR         * 
            *                                                                       *
            *    Net amount = Time amount                                           *
            *                 + Distance amount                                     *
            *                 + Vehicle amount                                      *
            *************************************************************************/
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
            else if (column_name == "ca_var1" || column_name == "ca_hrs_wk"
                     || column_name == "ca_dist_day" || column_name == "ca_costs_covered")
            {
                decimal? annualAmt = (decimal?)grid.Rows[thisRow].Cells["ca_annual_amount"].Value ?? 0.0M;
                decimal? netAmt = (decimal?)grid.Rows[thisRow].Cells["net_amount"].Value ?? 0.0M;
                decimal? initialAmt = (decimal?)grid.Rows[thisRow].Cells["initial_amount"].Value ?? 0.0M;
                decimal? initialNetAmt = (decimal?)grid.Rows[thisRow].Cells["initial_net_amount"].Value ?? 0.0M;

                // Determine the previous NetAmt
                decimal? prevNetAmt;
                DateTime? paid = (DateTime?)grid.Rows[thisRow].Cells["ca_paid_to_date"].Value;
                if (paid == null)
                    // If this allowance has not been paid, we'll be changing the 
                    // net amount that was added on to the pervious allowance. To do this
                    // we take away this record's previous change amount (still in
                    // ca_annual_amount; we're about to replace it with a new change amount).
                    prevNetAmt = netAmt - annualAmt;
                else
                    // If this allowance has been paid we'll be creating 
                    // an additional allowance to add on to the current allowance
                    prevNetAmt = netAmt;

                // Calculate the new net amount and save it in calc_amount, and calculate the 
                // change from the pevious net amount and save it in ca_annual_amount.

                // Get the values needed for the calculation
                // From contract_allowances
                decimal days_yr      = of_GetDecimalValue(thisRow, "ca_var1");
                decimal hours_wk     = of_GetDecimalValue(thisRow, "ca_hrs_wk");
                decimal distance_day = of_GetDecimalValue(thisRow, "ca_dist_day");

                // From allowance_type
                decimal rate_hr      = of_GetDecimalValue(thisRow, "alt_rate");
                decimal weeks_yr     = of_GetDecimalValue(thisRow, "alt_wks_yr");
                decimal ACC          = of_GetDecimalValue(thisRow, "alt_acc");

                // From vehicle_allowance_rates
                // 8-Jul-2021 bug fix: fuel_use_pk is fuel_use per 100Km
                decimal fuel_use_p100  = of_GetDecimalValue(thisRow, "var_fuel_use_pk");
                decimal fuel_rate    = of_GetDecimalValue(thisRow, "var_fuel_rate");
                decimal ruc_pk       = of_GetDecimalValue(thisRow, "var_ruc_rate_pk");
                decimal repairs_pk   = of_GetDecimalValue(thisRow, "var_repairs_pk");
                decimal tyres_pk     = of_GetDecimalValue(thisRow, "var_tyres_pk");
                decimal allowance_pk = of_GetDecimalValue(thisRow, "var_allowance_pk");
                decimal carrier_pa   = of_GetDecimalValue(thisRow, "var_carrier_pa");
                decimal licence_pa   = of_GetDecimalValue(thisRow, "var_licence_pa");
                decimal insurance_pa = of_GetDecimalValue(thisRow, "var_insurance_pa");
                decimal ror_pa       = of_GetDecimalValue(thisRow, "var_ror_pa");

                string costs_covered = (string)grid.Rows[thisRow].Cells["ca_costs_covered"].Value;

                // Intermediate calculated values
                decimal Hours = hours_wk * weeks_yr;
                decimal TimeAmt = (Hours * rate_hr) * (1 + (ACC * 0.01M));
                TimeAmt = Decimal.Round(TimeAmt,2);

                decimal Dist_yr = (distance_day * days_yr);
                decimal Fuel_allowance = (fuel_use_p100 * fuel_rate) * (Dist_yr / 100);
                decimal DistAmt = (ruc_pk + repairs_pk + tyres_pk + allowance_pk)
                                   * (Dist_yr / 1000)
                                   + Fuel_allowance;
                DistAmt = Decimal.Round(DistAmt,2);

                // If cost_covered is not 'Y', calculate the Vehicle amount
                // If cost_covered is 'Y', don't do the calculation and use $0
                decimal VehAmt;
                if (costs_covered != null && costs_covered == "Y")
                    VehAmt = 0.0M;
                else
                    VehAmt = carrier_pa + licence_pa + insurance_pa + ror_pa;
                VehAmt = Decimal.Round(VehAmt, 2);

                // Calculate the new net amount and save in calc_amount and net_amount
                decimal? newNetAmt = TimeAmt + DistAmt + VehAmt;
                grid.Rows[thisRow].Cells["calc_amount"].Value = newNetAmt;
                grid.Rows[thisRow].Cells["net_amount"].Value = newNetAmt;

                // Calculate the change amount and save in ca_annual_amount
                decimal? changeAmt = newNetAmt - prevNetAmt;
                grid.Rows[thisRow].Cells["ca_annual_amount"].Value = changeAmt;

                // Mark this record Modified ("M") if it isn't already marked New ("N") or Modified.
                if (sRowChanged != "N" && sRowChanged != "M")
                    grid.Rows[thisRow].Cells["ca_row_changed"].Value = "M";
            }
            else if (sRowChanged != "N" && sRowChanged != "M" && sRowChanged != "C")
            {
                // Something other than the ca_annual_amount, calc_amount, net_amount, investment amount (ca_var1),
                // or ca_row_changed has been changed.
                // If RowChanged has not already been set to one of the New ("N"), Modified ("M") 
                // or Changed ("C") values, mark it changed.
                grid.Rows[thisRow].Cells["ca_row_changed"].Value = "C";
            }
        }
    }
}
