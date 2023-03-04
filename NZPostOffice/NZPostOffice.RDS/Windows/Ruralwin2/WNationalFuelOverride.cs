using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using System.Collections.Generic;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    // TJB Frequencies & Allowances  March-2022  Github copy
    // Changes to handle multiple vehicles per contract
    // (see tabpage_fuel_pfc_default and tabpage_other_rates_pfc_default (RUCs))
    // Changed detection of rate changes and allow both fuel and RUC rates to be processed
    // 
    // TJB 10-July-2019
    // Cosmetic changes: re-formatted MessageBox.Show for readability
    //
    // TJB  RPCR_099  8-Jan-2016:  Name change
    // Changed UpdateVehicleOverrideRate to UpdateVehicleOverrideFuelRate

    public partial class WNationalFuelOverride : WMaster
    {
        #region Define

        public DataUserControl ids_original;

        public DataUserControl ids_standard_fuels;

        public DataUserControl itr_tran_obj;

        public URdsDw idw_criteria;

        public URdsDw idw_details;

        public URdsDw idw_rates;

        #endregion

        public WNationalFuelOverride()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            this.dw_criteria.DataObject = new DFuelOverrideFields();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            dw_details.DataObject = new DwNationalFuelOverride();
            dw_details.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            dw_rates.DataObject = new DNationalRatesOverrideFields();
            dw_rates.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            //jlwang:moved from IC
            dw_details.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_details_constructor);
            dw_rates.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_rates_constructor);
            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);
            //jlwang:end
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("National Fuel Overrides");
            // Tell security that the user must have national access  ( Own region=National)
            this.of_set_nationalaccess(true);
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // itr_tran_obj = CREATE n_tr
            // SQLCA.of_CopyTo ( itr_tran_obj)
            // itr_tran_obj.of_SetAutoRollback ( FALSE)
            // itr_tran_obj.of_Connect ( )
            //?itr_tran_obj = StaticVariables.sqlca;
            dw_details_ue_initialise();
            dw_rates_ue_initialise();
            dw_criteria.InsertItem<FuelOverrideFields>(0);
            dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate = System.DateTime.Today;
            // em_effective_date.Text = String ( Today ( ), 'dd/mm/yyyy')

            //added by jlwang
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public override void pfc_default()
        {
            base.pfc_default();
            int li_rc = FAILED;

            // TJB Frequencies & Allowances  Mar-2022
            // Changed detection of rate changes and allow both fuel and RUC rates to be processed
            //if (tab_rates.SelectedIndex == 0)
            if (StaticFunctions.IsDirty(dw_details))
            {
                li_rc = tabpage_fuel_pfc_default();
            }
            //else
            if (StaticFunctions.IsDirty(dw_rates))
            {
                li_rc = tabpage_other_rates_pfc_default();
            }
            if (li_rc < OK)
            {
                return;
            }
            this.Close();
        }

        public override void pfc_cancel()
        {
            base.pfc_cancel();
            ib_disableclosequery = true;
            this.Close();
        }

        #region Methods

        public virtual int of_validate_criteria()
        {
            DateTime? ld_effective_date;
            int? ll_selected_rg_code = null;
            dw_criteria.AcceptText();
            ld_effective_date = null;
            ld_effective_date = dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate;
            if (!(ld_effective_date == null))
            {
                if (Debugging)
                {
                    MessageBox.Show("Skipping date check"
                        + "\nDebugging is enabled"
                        , "Debugging");
                }
                if (Testing)
                {
                    MessageBox.Show("Skipping date check"
                        + "\nDebugging is not enabled"
                        , "Testing");
                }
                else
                {
                    if (ld_effective_date < DateTime.Today.Date)
                    {
                        MessageBox.Show("The specified effective date must either be today or in the future."
                                       , "Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dw_criteria.GetControlByName("ad_effective_date").Focus();
                        dw_criteria.Focus();
                        this.Focus();
                        return FAILED;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must specify an effective date."
                               , "Validation Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dw_criteria.Controls["ad_effective_date"].Focus();
                dw_criteria.Focus();
                this.Focus();
                return FAILED;
            }
            ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;
            if (ll_selected_rg_code == null)
            {
                MessageBox.Show("You must select a renewal group from the list."
                              , "Validation Error"
                              , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dw_criteria.GetControlByName("al_renewal_group").Focus();
                dw_criteria.Focus();
                this.Focus();
                return FAILED;
            }
            return SUCCESS;
        }

        bool Debugging = false;
        bool Testing = true;

        private string convert_to_string(decimal? val)
        {
            return (val.HasValue ? Convert.ToString(val.Value) : "Null");
        }

        private decimal? get_new_fuel_rate(int? pFuelKey)
        {
            for (int i = 0; i < dw_details.RowCount; i++)
            {
                if (dw_details.GetItem<NationalFuelOverride>(i).FtKey == pFuelKey)
                {
                    return dw_details.GetItem<NationalFuelOverride>(i).FuelRate;
                }
            }

            return null;
        }

        private DateTime? get_rates_effective_date(DateTime? pEffectiveDate)
        {   // Find the maximum date that is less than or equal to the effective date entered
            DateTime? date = DateTime.MinValue;
            DateTime? thisDate = DateTime.MaxValue;
            for (int i = 0; i < ids_standard_fuels.RowCount; i++)
            {
                thisDate = ids_standard_fuels.GetItem<StandardFuelRates>(i).RrRatesEffectiveDate;
                if (thisDate.HasValue && thisDate <= pEffectiveDate)
                {
                    if (thisDate > date)
                        date = thisDate;
                }
            }
            return date;
        }
        private int find_std_fuel_index(int? pFuelKey, int? pRgCode, DateTime? pEffectiveDate)
        {
            for (int i = 0; i < ids_standard_fuels.RowCount; i++)
            {
                if (ids_standard_fuels.GetItem<StandardFuelRates>(i).FtKey == pFuelKey
                    && ids_standard_fuels.GetItem<StandardFuelRates>(i).RgCode == pRgCode
                    && ids_standard_fuels.GetItem<StandardFuelRates>(i).RrRatesEffectiveDate == pEffectiveDate)
                {
                    return i;
                }
            }
            return -1;
        }

        public virtual int tabpage_fuel_pfc_default()
        {
            //-------------------------------------------------------------------------
            // Process new fuel rates
            // Does so in 3 steps
            // Initially, exec the sp_ContractsBenchmark stored procedure to get
            // the set of contracts and their vehicles that may be affected by a
            // change in standard fuel rate.
            // Step 1) 
            //    Scan the set, and update the vehicle override rate where its 
            //    standard fuel rate has been changed.
            // Step 2)
            //    Update the standard fuel rates with the new rates.
            // Step 3)
            //    Re-scan the set and create frequency_adjustments where the benchmark 
            //    has changed.  Where there are multiple vehicles in a contract, a 
            //    frequency adjustment is created for each vehicle where that vehicle's
            //    contribution to the benchmark has changed.
            //-------------------------------------------------------------------------

            // TJB Frequencies & Allowances  March-2022
            // Changed to handle multiple vehicles per contract
            // - Change ContractsBenchmark to return separate rows for each vehicle
            // - Create separate frequency_adjustments and frequency_distances
            //   for each vehicle with accumulating benchmark values for each contract.
            //
            // RETURNS
            //   -1   Some failure (reported via messagebox)
            //    1   OK

            int ll_x = 0;
            decimal? ldc_original_fuel_rate;
            decimal? ldc_new_standard_fuel_rate;
            decimal? ldc_standard_fuel_rate_change;
            decimal? ldc_overridden_fuel_rate;
            decimal? ldc_new_override_fuel_rate;
            int ll_result = FAILURE;
            int? ll_fuel_key;
            int? ll_contract_no;
            int? ll_sequence_no;
            int? vehicle_no;
            int? ll_rg_code;
            int? originalBM, originalBMVeh, BMVehChange;
            int? newBM, newBMVeh;

            DateTime? ld_rates_effective_date;
            DateTime? ld_effective_date;
            string ls_reason;
            bool lb_go;
            int? ll_selected_rg_code;
            int li_return = -1;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            if (Debugging)
            {
                MessageBox.Show("Debugging is enabled", "tabpage_fuel_pfc_default");
            }

            //--------------------------------------------------------------------
            // Check that useable information has been entered
            //--------------------------------------------------------------------

            dw_details.AcceptText();
            if (!StaticFunctions.IsDirty(dw_details))
            {
                // No rates specified for this tab. ignore the tab
                return OK;
            }
            // Validate criteria fields
            if (of_validate_criteria() < 0)
            {
                return FAILED;
            }
            ld_effective_date = null;
            ld_effective_date = dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate;
            ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;
            lb_go = false;
            // Check that at least one nationl override rate has been specified

            for (ll_x = 0; ll_x < dw_details.RowCount; ll_x++)
            {
                ldc_original_fuel_rate = dw_details.GetItem<NationalFuelOverride>(ll_x).FuelRate;

                if (ldc_original_fuel_rate == null || ldc_original_fuel_rate == 0)
                {
                }
                else
                {
                    lb_go = true;
                    break;   // no need to go on
                }
            }
            if (!lb_go)
            {
                MessageBox.Show("You must specify at least one new fuel rate."
                              , "Validation Error"
                              , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Focus();
                return li_return;
            }
            // Prompt for confirmation
            if (MessageBox.Show("Are you sure you want to proceed with the new fuel rates? \n"
                              + "The change will impact on all currently active contracts \n"
                              + "and benchmarks for the selected renewal group."
                              , "Warning"
                              , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                              , MessageBoxDefaultButton.Button2)
                == DialogResult.No)
            {
                this.Focus();
                return li_return;
            }

            //--------------------------------------------------------------------
            // Start by getting the set of contracts and their vehicles to process
            // ContractsBenchmark returns each relevant contract and its vehicles, 
            // the contract's current benchmark (repeated for each vehicle), and 
            // some info about the vehicle's fuel type, override rate and the standard 
            // rate for that fuel type.
            //--------------------------------------------------------------------

            this.Cursor = Cursors.WaitCursor;  // This doesn'tseem to work

            // Get the set of contracts and their vehicles that might be affected by a fuel rate change.
            ids_original = new DContractsBenchmark();
            ((DContractsBenchmark)ids_original).Retrieve(ll_selected_rg_code, ld_effective_date);
            // Also get the current standard fuel rates
            ids_standard_fuels = new DStandardFuelRates();
            ids_standard_fuels.Retrieve();

            //if (Debugging)
            //{
            //    string msg = "";
            //    for (int i = 0; i < ids_original.RowCount; i++)
            //    {
            //        ll_contract_no = ids_original.GetItem<ContractsBenchmark>(i).ContractNo;
            //        ll_sequence_no = ids_original.GetItem<ContractsBenchmark>(i).SequenceNo;
            //        vehicle_no = ids_original.GetItem<ContractsBenchmark>(i).VehicleNumber;
            //        msg += "\n  Contract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
            //            + ", Vehicle " + vehicle_no.ToString();
            //    }
            //    MessageBox.Show((ids_original.RowCount).ToString() + " contract/vehicle records found."
            //        + msg
            //        , "Debugging");
            //}

            for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
            {
                ldc_original_fuel_rate = null;
                ldc_new_standard_fuel_rate = null;
                ldc_new_override_fuel_rate = null;
                ldc_overridden_fuel_rate = null;
                ll_contract_no = null;
                ll_sequence_no = null;
                ld_rates_effective_date = null;
                ll_contract_no = ids_original.GetItem<ContractsBenchmark>(ll_x).ContractNo;
                ll_sequence_no = ids_original.GetItem<ContractsBenchmark>(ll_x).SequenceNo;
                ll_rg_code = ids_original.GetItem<ContractsBenchmark>(ll_x).RgCode;
                ld_rates_effective_date = ids_original.GetItem<ContractsBenchmark>(ll_x).RatesEffectiveDate;
                ll_fuel_key = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelKey;
                vehicle_no = ids_original.GetItem<ContractsBenchmark>(ll_x).VehicleNumber;


                // PBY 04/06/2002
                // Don't bother creating a frequency adjustment if we 
                // cannot determine the fuel type used!
                if (ll_fuel_key == null)
                    continue;
                ldc_original_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_x).OriginalFuelRate;
                ldc_overridden_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelRate;

                // Find the new rate for this 
                ldc_new_standard_fuel_rate = get_new_fuel_rate(ll_fuel_key);

                // If overridden (vor) fuel rate is null (no override for this contract/vehicle),
                // or the standard fuel rate is null (no standard fuel rate for this fuel type)
                // skip this record.
                if (ldc_overridden_fuel_rate == null || ldc_overridden_fuel_rate == 0
                    || ldc_new_standard_fuel_rate == null || ldc_new_standard_fuel_rate == 0)
                {
                    continue;
                }

                // An override rate exists for this contract and needs to be adjusted.
                // The new override rate is adjusted by the difference between the old 
                // standard fuel rate, and the new national override rate.

                ldc_new_override_fuel_rate = ldc_overridden_fuel_rate
                                           + (ldc_new_standard_fuel_rate - ldc_original_fuel_rate);

                if (Debugging)
                {
                    MessageBox.Show("Update Vehicle Override Fuel Rate "
                        + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                        + "\nVehicle " + vehicle_no.ToString()
                        + "\nOverride effective_date = " + ((DateTime)ld_effective_date).ToString("dd-MMM-yyy")
                        + "\nRates effective_date = " + ((DateTime)ld_rates_effective_date).ToString("dd-MMM-yyy")
                        + "\nFuel key " + ll_fuel_key.ToString()
                        + "\nOriginal_standard_fuel_rate = " + convert_to_string(ldc_original_fuel_rate)
                        + "\nNew_standard_fuel_rate = " + convert_to_string(ldc_new_standard_fuel_rate)
                        + "\nOriginal_override_fuel_rate = " + convert_to_string(ldc_overridden_fuel_rate)
                        + "\nNew_override_fuel_rate = " + convert_to_string(ldc_new_override_fuel_rate)
                        , "Debugging");
                    SQLCode = 0;
                }
                //else
                {
                    // TJB  RPCR_099  8-Jan-2016:  Name change: UpdateVehicleOverrideRate to UpdateVehicleOverrideFuelRate
                    RDSDataService.UpdateVehicleOverrideFuelRate(ldc_new_override_fuel_rate
                                                                , ll_contract_no, ll_sequence_no
                                                                , vehicle_no
                                                                , ld_rates_effective_date
                                                                , ref SQLCode
                                                                , ref SQLErrText);

                    if (SQLCode != 0)
                    {
                        MessageBox.Show("Unable to update vehicle_override_rate table. \n"
                                        + "The global update process will be aborted.\n\n"
                                        + "Error Code: " + SQLCode.ToString() + "\n"
                                        + "Error Text: " + SQLErrText
                                        , "Database Error");
                        return FAILURE;
                    }
                }
            } // End loop updating each vehicle's override rate

            //--------------------------------------------------------------------
            // Update standard fuel rates
            //--------------------------------------------------------------------

            int std_fuel_index;
            bool std_fuels_updated = false;
            ld_rates_effective_date = get_rates_effective_date(ld_effective_date);
            for (int i = 0; i < dw_details.RowCount; i++)
            {
                ll_fuel_key = dw_details.GetItem<NationalFuelOverride>(i).FtKey;
                ldc_new_standard_fuel_rate = dw_details.GetItem<NationalFuelOverride>(i).FuelRate;
                if (ldc_new_standard_fuel_rate == null || ldc_new_standard_fuel_rate.Value == 0)
                    continue;  //Can't set a standard rate to 0 via these National Override Rates

                std_fuel_index = find_std_fuel_index(ll_fuel_key, ll_selected_rg_code, ld_rates_effective_date);
                if (std_fuel_index >= 0)
                {
                    if (Debugging)
                    {
                        decimal? ldc_old_standard_rate = ids_standard_fuels.GetItem<StandardFuelRates>(std_fuel_index).FrFuelRate;
                        MessageBox.Show("Update standard fuel rate"
                        + "\nFuel key = " + ll_fuel_key.ToString()
                        + "\nRG Code  = " + ll_selected_rg_code.ToString()
                        + "\nEffective date " + ((DateTime)ld_effective_date).ToString("dd-MMM-yyyy")
                        + "\nOld rate = " + convert_to_string(ldc_old_standard_rate)
                        + "\nNew rate = " + convert_to_string(ldc_new_standard_fuel_rate)
                        , "Debugging");
                    }
                    //else
                    {
                        ids_standard_fuels.GetItem<StandardFuelRates>(std_fuel_index).FrFuelRate
                                   = ldc_new_standard_fuel_rate;
                        std_fuels_updated = true;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to find standard fuel rate to update\n"
                            + "Fuel key = " + ll_fuel_key.ToString() + "\n"
                            + "RG Code  = " + ll_selected_rg_code.ToString() + "\n"
                            + "Effective date " + ((DateTime)ld_rates_effective_date).ToString("dd-MMM-yyyy")
                            , "Error");
                    return FAILURE;
                }
            }  // End of standard fuel rates update loop

            // Save the updated standard fuel rates
            if (std_fuels_updated)
            {
                ids_standard_fuels.Save();
            }

            //--------------------------------------------------------------------
            // Calculate new vehicle benchmarks for each contract/vehicle
            // and create frequency adjustments for each contract vehicle where
            // the vehicle benchmark has changed.
            //--------------------------------------------------------------------

            // Determine the benchmark change attributable to each vehicle and create frequency adjustments
            // for each, with a rolling total for the contract.  The last vehicle's rolling benchmark total
            // should be the new contract benchmark.

            decimal? oldVorFuelRate;
            decimal? newVorFuelRate;
            decimal? oldStdFuelRate;
            decimal? newStdFuelRate;
            int? rollingBM = 0;
            int? thisContractNo = -1;  // To detect change in contractNo

            // Loop over the original list of contracts/vehicles (they're in contract, vehicle order)
            for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
            {
                // Initialise things for this contract/vehicle

                ll_contract_no = ids_original.GetItem<ContractsBenchmark>(ll_x).ContractNo;
                ll_sequence_no = ids_original.GetItem<ContractsBenchmark>(ll_x).SequenceNo;
                vehicle_no = ids_original.GetItem<ContractsBenchmark>(ll_x).VehicleNumber;
                originalBM = ids_original.GetItem<ContractsBenchmark>(ll_x).BenchMark;
                originalBMVeh = ids_original.GetItem<ContractsBenchmark>(ll_x).BenchMarkVeh;

                // if this is a new contract, reset the rolling benchmark
                if (thisContractNo != ll_contract_no)
                {
                    rollingBM = originalBM;
                    thisContractNo = ll_contract_no;
                }

                ld_rates_effective_date = ids_original.GetItem<ContractsBenchmark>(ll_x).RatesEffectiveDate;
                ll_fuel_key = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelKey;
                ll_rg_code = ids_original.GetItem<ContractsBenchmark>(ll_x).RgCode;

                oldVorFuelRate = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelRate;
                oldStdFuelRate = ids_original.GetItem<ContractsBenchmark>(ll_x).OriginalFuelRate;
                // Look up the new standard fuel rate (saved above)
                int i = find_std_fuel_index(ll_fuel_key, ll_rg_code, ld_rates_effective_date);
                if (i >= 0)
                    newStdFuelRate = ids_standard_fuels.GetItem<StandardFuelRates>(i).FrFuelRate;
                else
                    newStdFuelRate = null;

                // Determine this vehicle's contribution to the new contract benchmark
                // NOTE1: If the contract's BM has changed, it will be because one or
                //        more of its vehicle's BMs have changed, so we only need to look 
                //        for vehicle BM changes.
                // NOTE2: The vehicle BM includes the vehicle's portion of the contract's BM,
                //        and the (unchanged) non-vehicle portion.

                // Get the vehicle's new BM
                RDSDataService obj = RDSDataService.GetVehBenchmark(ll_contract_no, ll_sequence_no, vehicle_no);
                newBMVeh = (int?)obj.decVal;
                if (newBMVeh == null)
                    continue;
                else
                    newBMVeh = (int)newBMVeh;

                // If the vehicle's BM hasn't changed, skip creating a frequence adjustment
                if (newBMVeh == originalBMVeh)
                {
                    if (Debugging)
                    {
                        MessageBox.Show("Preparing a frequency adjustment"
                            + "\nSkipping - o change in vehicle BM"
                            + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                            + "\nVehicle " + vehicle_no.ToString()
                            , "Debugging");
                    }
                    continue;
                }

                // Calculate its contribution to the new contract BM
                //    veh contribution = new Veh BM - old Contract BM 
                BMVehChange = newBMVeh - originalBMVeh;

                // Calculate the new rolling contract benchmark
                //    rollingBM = rollingBM + veh contribution
                rollingBM = rollingBM + BMVehChange;

                if (Debugging)
                {
                    newVorFuelRate = oldVorFuelRate + (newStdFuelRate - oldStdFuelRate);
                    RDSDataService obj2 = RDSDataService.GetBenchmarkCalc(ll_contract_no, ll_sequence_no);
                    newBM = (int?)obj2.decVal;
                    MessageBox.Show("Preparing a frequency adjustment"
                        + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                        + "\nVehicle " + vehicle_no.ToString()
                        + "\nOld VOR fuel rate      = " + convert_to_string(oldVorFuelRate)
                        + "\nNew VOR fuel rate      = " + convert_to_string(newVorFuelRate)
                        + "\nOld standard fuel rate = " + convert_to_string(oldStdFuelRate)
                        + "\nNew standard fuel rate = " + convert_to_string(newStdFuelRate)
                        + "\nOld contract BM        = " + convert_to_string(originalBM)
                        + "\nNew contract BM        = " + convert_to_string(newBM)
                        + "\nOld vehicle BM         = " + convert_to_string(originalBMVeh)
                        + "\nNew vehicle BM         = " + convert_to_string(newBMVeh)
                        + "\nVehicle contribution   = " + convert_to_string(BMVehChange)
                        + "\nRolling contract BM    = " + convert_to_string(rollingBM)
                        , "Debugging frequency adjustments");
                }

                //--------------------------------------------------------------------
                // Create a frequency adjustment for this contract vehicle
                //--------------------------------------------------------------------

                if (originalBM == null || originalBM == 0
                    || newBMVeh == null || newBMVeh == 0)
                {
                    // There was some trouble calculating benchmark.  Do not create adjustments
                }
                else if (rollingBM != originalBM)
                {
                    // Create adjustment
                    NFrequencyAdjustment n_freq = new NFrequencyAdjustment();
                    n_freq.of_set_contract(ll_contract_no, ll_sequence_no);

                    ldc_standard_fuel_rate_change = newStdFuelRate.GetValueOrDefault() - oldStdFuelRate.GetValueOrDefault();
                    if (ldc_standard_fuel_rate_change >= 0)
                    {
                        ls_reason = "\r\nIncrease: ";
                    }
                    else
                    {
                        ls_reason = "\r\nDecrease: ";
                        ldc_standard_fuel_rate_change = Math.Abs((decimal)ldc_standard_fuel_rate_change);
                    }

                    // TJB  SR4654  April 2005
                    // Change the wording of the reason for the change
                    //			n_freq.is_Reason = 'Global fuel rate changed. \n' &
                    //									  +'Original standard rate: ' + ldc_original_fuel_rate.ToString() + '\n' &
                    //									  +'New standard rate: ' + ldc_new_standard_fuel_rate.ToString()
                    n_freq.is_reason = "Global fuel rate changed."
                                       + ls_reason + ldc_standard_fuel_rate_change.ToString() + " cents/litre"
                                       + "\r\nNew standard rate: " + newStdFuelRate.ToString() + " cpl";

                    n_freq.of_set_effective_date(ld_effective_date);
                    n_freq.idc_new_benchmark = rollingBM;
                    n_freq.idc_amount_to_pay = BMVehChange;
                    n_freq.idc_adjustment_amount = BMVehChange;

                    if (Debugging)
                    {
                        MessageBox.Show("For frequency adjustment:"
                        + "\nFreq effective date " + ((DateTime)ld_effective_date).ToString("d MMM yyyy")
                        + "\nFreq new benchmark  = " + convert_to_string(rollingBM)
                        + "\nFreq amount to pay  = " + convert_to_string(BMVehChange)
                        + "\nFreq adjustment amt = " + convert_to_string(BMVehChange)
                        , "Debugging");
                    }

                    if (BMVehChange != 0)
                    {
                        ll_result = n_freq.of_save();
                        if (ll_result <= 0)
                        {
                            MessageBox.Show("Problem saving frequency adjustment,"
                                    + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                                    + "\nVehicle " + vehicle_no.ToString()
                                    + "\n\n Save result = " + ll_result.ToString()
                                    , "Error");
                            return FAILURE;
                        }
                    }
                }
            } // end of frequency adjustments loop

            this.Cursor = Cursors.Default;  // This doesn't seem to work
            return SUCCESS;
        }

        public virtual void dw_details_ue_initialise()
        {
            int ll_rowcount;
            int ll_row;
            string ls_description = null;
            dw_details.Reset();
            //dw_details.Retrieve(new object[] { 0 });
            ((DwNationalFuelOverride)dw_details.DataObject).Retrieve(0);
            //  TJB SR4636 1-Dec-2004
            //  Set up the captions on the override rate values, so we can
            //  change 'Petrol' to 'Petrol (Diesel Equivalent)'.
            //  The captions were previously part of the datawindow but 
            //  overriding the 'Petrol' caption caused the selectionchanging 
            //  code to trigger. 
            ll_rowcount = dw_details.RowCount;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ls_description = dw_details.GetItem<NationalFuelOverride>(ll_row).Description;
                if (ls_description == "Petrol")
                {
                    ls_description = "Petrol  ( Diesel Equivalent)";
                }
                // PowerBuilder 'Choose Case' statement converted into 'if' statement
                long TestExpr = ll_row + 1;
                if (TestExpr == 1)
                {
                    description_1.Text = ls_description;
                }
                else if (TestExpr == 2)
                {
                    description_2.Text = ls_description;
                }
                else if (TestExpr == 3)
                {
                    description_3.Text = ls_description;
                }
                else if (TestExpr == 4)
                {
                    description_4.Text = ls_description;
                }
                else if (TestExpr == 5)
                {
                    description_5.Text = ls_description;
                }
                else if (TestExpr == 6)
                {
                    description_6.Text = ls_description;
                }
                else if (TestExpr == 7)
                {
                    description_7.Text = ls_description;
                }
                else if (TestExpr == 8)
                {
                    description_8.Text = ls_description;
                }
                else if (TestExpr == 9)
                {
                    description_9.Text = ls_description;
                }
                else if (TestExpr == 10)
                {
                    description_10.Text = ls_description;
                }
            }
        }

        public virtual void dw_details_constructor()
        {
            dw_details.of_SetUpdateable(false);
            idw_details = dw_details;
        }

        public virtual int tabpage_other_rates_pfc_default()
        {
            int ll_x = 1;
            decimal? ldc_standard_ruc_rate;
            decimal? ldc_new_standard_ruc_rate;
            decimal? ldc_old_override_ruc_rate;
            decimal? ldc_new_override_ruc_rate;
            int? ll_contract_no;
            int? ll_sequence_no;
            DateTime? ld_rates_effective_date = DateTime.MinValue;
            decimal? ldc_original_benchmark;
            decimal? ldc_new_benchmark;
            decimal? ldc_original_veh_benchmark;
            decimal? ldc_new_veh_benchmark;
            decimal? ldc_veh_contribution;
            NFrequencyAdjustment n_freq;
            DateTime? ld_effective_date;
            int ll_result = FAILURE;
            int? ll_selected_rg_code;
            int? vehicle_no;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            //--------------------------------------------------------------------
            // Check that useable information has been entered
            //--------------------------------------------------------------------

            dw_rates.AcceptText();
            if (!StaticFunctions.IsDirty(dw_rates))
                // No rates specified for this tab. ignore the tab
                return SUCCESS;

            if (Debugging)
            {
                MessageBox.Show("Debugging is enabled", "tabpage_rates_pfc_default");
            }

            // Validate criteria fields
            if (of_validate_criteria() < 0)
                return FAILURE;

            ld_effective_date = null;
            ld_effective_date = dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate;
            ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;
            ldc_new_standard_ruc_rate = dw_rates.GetItem<NationalRatesOverrideFields>(0).RucRate;
            if (ldc_new_standard_ruc_rate == null || ldc_new_standard_ruc_rate == 0)
            {
                MessageBox.Show("You must specify a Road User Charge rate."
                              , "Validation Error"
                              , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Focus();
                return FAILURE;
            }

            // Prompt for confirmation
            if (MessageBox.Show("Are you sure you want to proceed with the new RUC rate? \n"
                              + "The change will impact on all currently active contracts \n"
                              + "and benchmarks for the selected renewal group."
                              , "Warning"
                              , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                              , MessageBoxDefaultButton.Button2)
                == DialogResult.No)
            {
                this.Focus();
                return FAILURE;
            }

            //--------------------------------------------------------------------
            // Start by getting the set of contracts and their vehicles to process
            // ContractsBenchmark returns each relevant contract and its vehicles, 
            // the contract's current benchmark (repeated for each vehicle), and 
            // the vehicle's RUC override rate and its standard rate.
            //--------------------------------------------------------------------

            DataUserControlContainer ids_original = new DataUserControlContainer();
            ids_original.DataObject = new DContractsBenchmarkForRates();
            ((DContractsBenchmarkForRates)ids_original.DataObject).Retrieve(ll_selected_rg_code, ld_effective_date);
            if (ids_original.RowCount <= 0)
            {
                MessageBox.Show("No contracts found to update");
            }
            if (Debugging)
            {
                string msg;
                msg = (ids_original.RowCount).ToString() + " rows found";
                for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
                {
                    ll_contract_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).ContractNo;
                    ll_sequence_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).SequenceNo;
                    vehicle_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).VehicleNumber;
                    ldc_old_override_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).OverrideRucRate;
                    msg += "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                        + "\nVehicle " + vehicle_no.ToString()
                        + "\nVeh_override_ruc_rate = " + convert_to_string(ldc_old_override_ruc_rate);
                }
                MessageBox.Show(msg, "Debugging");
            }
            for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
            {
                ldc_standard_ruc_rate = null;
                ldc_new_override_ruc_rate = null;
                ldc_old_override_ruc_rate = null;
                ll_contract_no = null;
                ll_sequence_no = null;
                ld_rates_effective_date = null;
                ll_contract_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).ContractNo;
                ll_sequence_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).SequenceNo;
                vehicle_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).VehicleNumber;
                ld_rates_effective_date = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).RatesEffectiveDate;
                ldc_standard_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).StandardRucRate;
                ldc_old_override_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).OverrideRucRate;

                if (ldc_old_override_ruc_rate == null || ldc_old_override_ruc_rate == 0)
                {
                    // Note: Query returns records with with and without RUC overrides
                    // Skip if this vehicle doesn't have an override
                    // If its override is 0, we don't adjust it
                    continue;
                }
                else
                {
                    // An override rate exists for this contract and needs to be re-adjusted
                    ldc_new_override_ruc_rate = ldc_old_override_ruc_rate
                                                + (ldc_new_standard_ruc_rate - ldc_standard_ruc_rate);

                    if (Debugging)
                    {
                        MessageBox.Show("Update Vehicle Override RUC Rate "
                            + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                            + "\nVehicle " + vehicle_no.ToString()
                            + "\nOriginal_standard_ruc_rate = " + convert_to_string(ldc_standard_ruc_rate)
                            + "\nNew_standard_ruc_rate = " + convert_to_string(ldc_new_standard_ruc_rate)
                            + "\nOld_veh_override_ruc_rate = " + convert_to_string(ldc_old_override_ruc_rate)
                            + "\nNew_veh_override_ruc_rate = " + convert_to_string(ldc_new_override_ruc_rate)
                            , "Debugging");
                    }
                    //else
                    {
                        // TJB Mar 2022: Fixed bug: Changed name to UpdateVehicleOverrideRucRate and created new dataservice
                        // TJB  RPCR_099  8-Jan-2016:  Name change: UpdateVehicleOverrideRate to UpdateVehicleOverrideFuelRate
                        RDSDataService.UpdateVehicleOverrideRucRate(ldc_new_override_ruc_rate
                                                 , ll_contract_no
                                                 , ll_sequence_no
                                                 , vehicle_no
                                                 , ld_rates_effective_date
                                                 , ref SQLCode, ref SQLErrText);
                        if (SQLCode != 0)
                        {
                            MessageBox.Show("Unable to update vehicle_override_rate table."
                                + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                                + "\nVehicle " + vehicle_no.ToString()
                                + "\n\nThe global update process will be aborted."
                                + "\nError Code:" + SQLCode.ToString()
                                + "\nError Text:" + SQLErrText
                                , "Database Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return FAILURE;
                        }
                    }
                }
            }  // End loop processing each contract vehicle

            //--------------------------------------------------------------------
            // Update standard RUC rates
            //--------------------------------------------------------------------

            // Update the standard ruc rates for the rates_effective_date of the renewal group
            // NOTE: Currently (Mar 2022) there is only one standard RUC rate for all vehicle types
            //       and renewal groups.  I suspect this will need to be changed in the near future 
            //       at least for Deisel, PHEV, and BEV vehicle types.
            //
            // Originally each standard rate was updated to the new value for each of the several
            // hundred contracts being processed.  Doing so once for each of the new rates should
            // save a fraction of a second processing time :-)

            if (Debugging)
            {
                MessageBox.Show("Update the standard ruc rates"
                    + "\nNew_standard_ruc_rate = " + convert_to_string(ldc_new_standard_ruc_rate)
                    , "Debugging");
            }
            //else
            {   // TJB: Changed name from UpdateVehicleRate to UpdateVehicleRucRate
                RDSDataService.UpdateVehicleRucRate(ldc_new_standard_ruc_rate, ld_rates_effective_date
                                                , ref SQLCode, ref SQLErrText);
                if (SQLCode != 0)
                {
                    MessageBox.Show("Unable to update vehicle_rate table. \n"
                        + "The global update process will be aborted.\n\n"
                        + "Error Code: " + SQLCode.ToString() + "\n"
                        + "Error Text: " + SQLErrText
                        , "Database Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return FAILURE;
                }
            }

            //--------------------------------------------------------------------
            // Calculate new vehicle benchmarks for each contract/vehicle
            // and create frequency adjustments for each contract vehicle.
            //--------------------------------------------------------------------

            // Note: modified to handle multiple RUC-paying vehicles (TJB Mar 2022)

            int? ll_last_contract;
            decimal? ldc_rolling_benchmark;
            ll_last_contract = -1;
            ldc_rolling_benchmark = 0;

            // For each contract/vehicle affected by the RUC Change, create a frequency adjustment
            for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
            {
                ldc_standard_ruc_rate = null;
                ldc_new_override_ruc_rate = null;
                ldc_old_override_ruc_rate = null;
                ll_contract_no = null;
                ll_sequence_no = null;
                ld_rates_effective_date = null;
                ldc_original_benchmark = null;
                ldc_original_veh_benchmark = null;
                ll_contract_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).ContractNo;
                ll_sequence_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).SequenceNo;
                vehicle_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).VehicleNumber;
                ld_rates_effective_date = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).RatesEffectiveDate;
                ldc_standard_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).StandardRucRate;
                ldc_old_override_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).OverrideRucRate;
                ldc_original_benchmark = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).BenchMark;
                ldc_original_veh_benchmark = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).VehBenchMark;

                RDSDataService obj1 = RDSDataService.GetBenchmarkCalc(ll_contract_no, ll_sequence_no);
                ldc_new_benchmark = obj1.decVal;

                // Get the new vehicle benchmark (changed as a result of its override RUC rate being changed)
                RDSDataService Obj = RDSDataService.GetVehBenchmark(ll_contract_no, ll_sequence_no, vehicle_no);
                ldc_new_veh_benchmark = Obj.decVal;

                if ((ldc_new_veh_benchmark == null) || (ldc_original_benchmark == null)
                    || ldc_new_veh_benchmark == 0 || ldc_original_benchmark == 0)
                {
                    // Some trouble calculating benchmark.  Do not create adjustments.
                    int errcode = Obj.SQLCode;
                    string errmsg = Obj.SQLErrText;
                    MessageBox.Show("Error calculating new vehicle benchmark for frequency adjustment."
                        + "\nSQLCode = " + errcode.ToString()
                        + "\nSQLErrMsg = " + errmsg
                        + "\n\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                        + "\nVehicle " + vehicle_no.ToString()
                        + "\nOriginal benchmark = " + convert_to_string(ldc_original_benchmark)
                        + "\nNew benchmark = " + convert_to_string(ldc_new_benchmark)
                        + "\nOriginal Vehicle benchmark = " + convert_to_string(ldc_original_veh_benchmark)
                        + "\nNew Vehicle benchmark = " + convert_to_string(ldc_new_veh_benchmark)
                        , "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return FAILURE;
                }

                // Calculate the contribution this vehicle is making to the new contract benchmark
                // Accumulate the rolling total BM
                ldc_veh_contribution = ldc_new_veh_benchmark - ldc_original_veh_benchmark;

                if (Debugging)
                {
                    MessageBox.Show("New Vehicle benchmark calculated"
                        + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                        + "\nVehicle " + vehicle_no.ToString()
                        + "\nOriginal benchmark = " + convert_to_string(ldc_original_benchmark)
                        + "\nNew benchmark = " + convert_to_string(ldc_new_benchmark)
                        + "\nOld Vehicle benchmark = " + convert_to_string(ldc_original_veh_benchmark)
                        + "\nNew Vehicle benchmark = " + convert_to_string(ldc_new_veh_benchmark)
                        + "\nVehicle contribution = " + convert_to_string(ldc_veh_contribution)
                        , "Debugging");
                }

                //--------------------------------------------------------------------
                // Create frequency adjustments for each contract vehicle.
                //--------------------------------------------------------------------

                // If the contract number changes, reset the rolling benchmark.  If there are multiple 
                // vehicles in a contract affected by the change in RUC, the rolling benchmark will 
                // accumulate the incremental change in benchmark attributable to each vehicle and
                // will be the new contract benchmark for the last (or only) vehicle.
                if (ll_last_contract != ll_contract_no)
                {
                    ldc_rolling_benchmark = ldc_original_benchmark;
                    ll_last_contract = ll_contract_no;
                }

                if (ldc_new_veh_benchmark != ldc_original_benchmark)
                {
                    // Calculate the rolling benchmark (for single-vehicle contracts, will be the 
                    // same as the new contract BM.  For multiple vehicle contracts, the rolling BM 
                    // for the last vehicle will be the same as the contract BM.
                    ldc_rolling_benchmark = ldc_rolling_benchmark + ldc_veh_contribution;

                    string ls_reason;
                    ls_reason = "Global RUC rate changed. \nOriginal RUC rate: " + ldc_standard_ruc_rate.ToString()
                                + "\nNew RUC rate:" + ldc_new_standard_ruc_rate.ToString();

                    if (Debugging)
                    {
                        MessageBox.Show("Create frequency adjustment"
                            + "\nContract " + ll_contract_no.ToString() + "/" + ll_sequence_no.ToString()
                            + "\nVehicle " + vehicle_no.ToString()
                            + "\nReason: " + ls_reason
                            + "\nOriginal benchmark = " + convert_to_string(ldc_original_benchmark)
                            + "\nNew benchmark = " + convert_to_string(ldc_new_benchmark)
                            + "\nOld Vehicle benchmark = " + convert_to_string(ldc_original_veh_benchmark)
                            + "\nNew Vehicle benchmark = " + convert_to_string(ldc_new_veh_benchmark)
                            + "\nVehicle contribution = " + convert_to_string(ldc_veh_contribution)
                            + "\nRolling benchmark = " + convert_to_string(ldc_rolling_benchmark)
                            + "\nAmount to pay = " + convert_to_string(ldc_veh_contribution)
                            + "\nAdjustment amount = " + convert_to_string(ldc_veh_contribution)
                            , "Debugging");
                    }
                    //else
                    {
                        n_freq = new NFrequencyAdjustment();
                        n_freq.of_set_contract(ll_contract_no, ll_sequence_no);
                        n_freq.is_reason = ls_reason;
                        n_freq.of_set_effective_date(ld_effective_date);
                        n_freq.idc_new_benchmark = ldc_rolling_benchmark;
                        n_freq.idc_amount_to_pay = ldc_veh_contribution;
                        n_freq.idc_adjustment_amount = ldc_veh_contribution;

                        if (ldc_veh_contribution != 0)
                        {
                            ll_result = n_freq.of_save();
                            if (ll_result <= 0)
                            {
                                return FAILURE;
                            }
                        }
                    }
                }
            }
            return SUCCESS;
        }

        public virtual void dw_rates_ue_initialise()
        {
            dw_rates.Reset();
            dw_rates.InsertItem<NationalRatesOverrideFields>(0);
            dw_rates.GetItem<NationalRatesOverrideFields>(0).MarkClean();
        }

        public virtual void dw_rates_constructor()
        {
            dw_rates.of_SetUpdateable(false);
            idw_rates = dw_rates;
        }

        public virtual void dw_criteria_constructor()
        {
            dw_criteria.of_SetUpdateable(false);
            idw_criteria = dw_criteria;
        }

        #endregion

        #region Events

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            DialogResult li_rc;
            //  TJB SR4636 1-Dec-2004
            //  If we're OK'ing the details, ask the user to confirm
            //  that they're correct.  we really want a double-check 
            //  that the Petrol override is really a diesel equivalent.

            // TJB  Frequencies and Allowances  Mar-2022: Changed detection of changes to fuel rates
            //if (tab_rates.SelectedIndex == 0)
            if (StaticFunctions.IsDirty(dw_details))
            {
                li_rc = MessageBox.Show("Please confirm that the rates entered are correct, and\n"
                                      + "especially that the Petrol rate is a diesel equivalent."
                                      , "Confirm"
                                      , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                      , MessageBoxDefaultButton.Button2);
                if (li_rc == DialogResult.No || li_rc == DialogResult.Cancel)
                {
                    idw_details.Focus();
                    return;
                }
            }
            // (this is all that was in the original)
            this.pfc_default();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.pfc_cancel();
        }

        public virtual void tab_rates_selectionchanging(object sender, TabControlCancelEventArgs e)
        {
            URdsDw ldw_temp;
            DialogResult li_rc;
            if (tab_rates.SelectedIndex == 1) // Fuel
            {
                ldw_temp = idw_details;
            }
            else                              // RUC
            {
                ldw_temp = idw_rates;
            }
            ldw_temp.AcceptText();
            if (ldw_temp.DataObject.DeletedCount > 0 && ldw_temp.ModifiedCount() > 0)
            {
                li_rc = MessageBox.Show("The changes you made will be lost if you switch to \n"
                                      + "the other tabpage.  Do you want to continue?"
                                      , "Tabpage focus change"
                                      , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                      , MessageBoxDefaultButton.Button2);
                if (li_rc == DialogResult.No)
                {
                    //  Return 1 to prevent focus from changing
                    e.Cancel = true;
                }
                else
                {
                    if (ldw_temp.DataObject is DwNationalFuelOverride)
                        dw_details_ue_initialise();
                    else
                        dw_rates_ue_initialise();
                }
            }
        }

        public virtual void dw_details_losefocus(object sender, EventArgs e)
        {
            dw_details.AcceptText();
        }

        public virtual void dw_rates_losefocus(object sender, EventArgs e)
        {
            dw_rates.AcceptText();
        }
        #endregion
    }
}