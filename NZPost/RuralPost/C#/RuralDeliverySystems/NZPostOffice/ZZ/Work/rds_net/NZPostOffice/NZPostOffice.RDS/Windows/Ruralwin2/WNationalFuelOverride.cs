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
            int li_rc = -1;
            if (tab_rates.SelectedIndex == 0)
            {
                li_rc = tabpage_fuel_pfc_default();
            }
            else
            {
                li_rc = tabpage_other_rates_pfc_default();
            }
            if (li_rc < 0)
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
                if (ld_effective_date < DateTime.Today.Date)
                {
                    MessageBox.Show("The specified effective date must either be today or in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dw_criteria.GetControlByName("ad_effective_date").Focus();
                    dw_criteria.Focus();
                    this.Focus();
                    return -(1);
                }
            }
            else
            {
                MessageBox.Show("You must specify an effective date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dw_criteria.Controls["ad_effective_date"].Focus();
                dw_criteria.Focus();
                this.Focus();
                return -(1);
            }
            ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;
            if (ll_selected_rg_code == null)
            {
                MessageBox.Show("You must select a renewal group from the list.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dw_criteria.GetControlByName("al_renewal_group").Focus();
                dw_criteria.Focus();
                this.Focus();
                return -(1);
            }
            return 1;
        }

        public virtual int tabpage_fuel_pfc_default()
        {
            int ll_x = 0;
            decimal? ldc_original_fuel_rate;
            decimal? ldc_new_standard_fuel_rate;
            decimal? ldc_standard_fuel_rate_change;
            decimal? ldc_overridden_fuel_rate;
            decimal? ldc_new_override_fuel_rate;
            int ll_found;
            int? ll_fuel_key;
            int? ll_contract_no;
            int? ll_sequence_no;
            DateTime? ld_rates_effective_date;
            int? ll_rg_code;
            DataUserControl lds_new_benchmarks;
            decimal? ldc_new_benchmark;
            decimal? ldc_original_benchmark;
            decimal? ldc_amount_to_pay;
            //?n_frequency_adjustment	n_freq;
            DateTime? ld_effective_date;
            int ll_result = -1;
            bool lb_continue = true;
            string ls_test;
            string ls_reason;
            bool lb_go;
            int? ll_selected_rg_code;
            int li_return = -1;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            dw_details.AcceptText();
            if (!StaticFunctions.IsDirty(dw_details))
            {
                // No rates specified for this tab. ignore the tab
                return 1;
            }
            // Validate criteria fields
            if (of_validate_criteria() < 0)
            {
                return li_return;
            }
            ld_effective_date = null;
            ld_effective_date = dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate;
            ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;
            lb_go = false;
            for (ll_x = 0; ll_x < dw_details.RowCount; ll_x++)
            {
                ldc_original_fuel_rate = dw_details.GetItem<NationalFuelOverride>(ll_x).FuelRate;
                if (ldc_original_fuel_rate == null || ldc_original_fuel_rate == 0)
                {
                }
                else
                {
                    lb_go = true;
                }
            }
            if (!lb_go)
            {
                MessageBox.Show("You must specify at least one new fuel rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Focus();
                return li_return;
            }
            // Prompt for confirmation
            if (MessageBox.Show("Are you sure you want to proceed? \r\n" +
            "The change will impact on all currently active contracts \r\n" +
            "and benchmarks for the selected renewal group.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.Focus();
                return li_return;
            }

            this.Cursor = Cursors.WaitCursor;


            ids_original = new DContractsBenchmark();
            ((DContractsBenchmark)ids_original).Retrieve(ll_selected_rg_code);
            ids_standard_fuels = new DStandardFuelRates();
            ll_found = ids_standard_fuels.Retrieve();
            //?Commit;
            //?EXECUTE IMMEDIATE 'BEGIN TRANSACTION';
            for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
            {
                ldc_original_fuel_rate = null;
                ldc_new_standard_fuel_rate = null;
                ldc_new_override_fuel_rate = null;
                ldc_overridden_fuel_rate = null;
                ll_contract_no = null;
                ll_sequence_no = null;
                ld_rates_effective_date = null;
                ll_found = 0;
                ll_contract_no = ids_original.GetItem<ContractsBenchmark>(ll_x).ContractNo;
                ll_sequence_no = ids_original.GetItem<ContractsBenchmark>(ll_x).SequenceNo;
                ld_rates_effective_date = ids_original.GetItem<ContractsBenchmark>(ll_x).RatesEffectiveDate;
                ll_fuel_key = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelKey;
                // PBY 04/06/2002
                // Don't bother creating a frequency adjustment if we 
                // cannot determin the fule type used!
                if (ll_fuel_key == null)
                    continue;
                ll_rg_code = ids_original.GetItem<ContractsBenchmark>(ll_x).RgCode;
                ldc_original_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_x).OriginalFuelRate;
                ldc_overridden_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelRate;


                // Find the new rate for this 
                //!ll_found = dw_details.Find("ft_key", ll_fuel_key);
                ll_found = -1;
                for(int i = 0; i < dw_details.RowCount; i++)
                {
                    if (dw_details.GetItem<NationalFuelOverride>(i).FtKey == ll_fuel_key)
                    {
                        ll_found = i;
                        break;
                    }
                }

                if (ll_found >= 0)
                    ldc_new_standard_fuel_rate = dw_details.GetItem<NationalFuelOverride>(ll_found).FuelRate;
                else
                    ldc_new_standard_fuel_rate = null;
                ll_found = 0;
                if (ldc_overridden_fuel_rate == null || ldc_overridden_fuel_rate == 0 || ldc_new_standard_fuel_rate == null || ldc_new_standard_fuel_rate == 0)
                {
                    // Dont adjust the fuel rate override
                }
                else
                {
                    // An override rate exists for this contract and needs to be re-adjusted
                    //PP! seems null values in calculation return null in Powerbuilder too
                    ldc_new_override_fuel_rate = (ldc_overridden_fuel_rate - ldc_original_fuel_rate) + ldc_new_standard_fuel_rate;

                    /*UPDATE	vehicle_override_rate vor1
                    SET		vor1.vor_fuel_rate = :ldc_new_override_fuel_rate
                    WHERE		vor1.contract_no = :ll_contract_no
                    AND		vor1.contract_seq_number = :ll_sequence_no
                    AND		vor1.vor_effective_date >= :ld_rates_effective_date
                    AND		vor1.vor_effective_date =  ( SELECT	max ( vor2.vor_effective_date) 
                    FROM		vehicle_override_rate vor2 
                    WHERE		vor2.contract_no = vor1.contract_no
                    AND		vor2.contract_seq_number = vor1.contract_seq_number)
                    USING		itr_tran_obj; */
                    RDSDataService.UpdateVehicleOverrideRate(ldc_new_override_fuel_rate, ll_contract_no, ll_sequence_no, ld_rates_effective_date, ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show("Unable to update vehicle_override_rate table. \r\n" +
                            "The global update process will be aborted.\r\n\r\n" +
                            "Error Code: " + /*?string(itr_tran_obj.SQLDBCode) + */"\r\nError Text: " + SQLErrText, "Database Error");
                        lb_continue = false;
                        break;
                    }
                    else
                        lb_continue = true;
                }
                // Update the standard fuel rates if it changes
                if (ldc_new_standard_fuel_rate > 0)
                {
                    //ls_test = "ft_key= " + ll_fuel_key.ToString() +  " AND rg_code= " + ll_rg_code.ToString() + " AND rr_rates_effective_date= date ( '" + ld_rates_effective_date.ToString("dd/mm/yyyy") + "')";
                    //!ll_found = ids_standard_fuels.Find(new KeyValuePair<string, object>[] { 
                    //!new KeyValuePair<string, object>("ft_key", ll_fuel_key),
                    //!new KeyValuePair<string, object>("rg_code", ll_rg_code),
                    //!new KeyValuePair<string, object>("rr_rates_effective_date", ld_rates_effective_date)//pp! ld_effective_date)});
                    ll_found = -1;
                    for (int i = 0; i < ids_standard_fuels.RowCount; i++)
                    { 
                        StandardFuelRates record = ids_standard_fuels.GetItem<StandardFuelRates>(i);
                        if (record.FtKey == ll_fuel_key && record.RgCode == ll_rg_code && record.RrRatesEffectiveDate == ld_rates_effective_date)    
                        {
                            ll_found = i;
                            break;
                        }
                    }

                    if (ll_found >= 0)
                    {
                        ids_standard_fuels.GetItem<StandardFuelRates>(ll_found).FrFuelRate = ldc_new_standard_fuel_rate;
                    }
                    else
                    {
                        MessageBox.Show("row must exist", "double check!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (lb_continue)
            {
                // Saves the standard fuel rates
                ll_result = 1;
                ids_standard_fuels.Save(); // Update(TRUE, FALSE)
                if (ll_result <= 0)
                {
                    lb_continue = false;
                }
            }
            if (lb_continue)
            {
                // Obtain new benchmark
                lds_new_benchmarks = new DContractsBenchmark();
                ((DContractsBenchmark)lds_new_benchmarks).Retrieve(ll_selected_rg_code);
                // Loop thru the new benchmarks and see if benchmark is different
                for (ll_x = 0; ll_x < lds_new_benchmarks.RowCount; ll_x++)
                {
                    ll_found = 0;
                    ll_contract_no = null;
                    ll_sequence_no = null;
                    ldc_new_benchmark = null;
                    ldc_original_benchmark = null;
                    ldc_amount_to_pay = null;
                    ll_contract_no = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).ContractNo;
                    ll_sequence_no = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).SequenceNo;
                    ldc_new_benchmark = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).BenchMark;
                    ldc_new_standard_fuel_rate = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).OriginalFuelRate;
                    // PBY 04/06/2002
                    // IF new standard fuel rate is null, it should not be processed
                    if (ldc_new_standard_fuel_rate == null)
                        continue;


                        // Find the new rate for this 
                        //!ll_found = ids_original.Find(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("contract_no", ll_contract_no),
                        //!                                                                  new KeyValuePair<string, object>("sequence_no", ll_sequence_no) });
                        ll_found = -1;
                        for (int i = 0; i < ids_original.RowCount; i++)
                        {
                            ContractsBenchmark record = ids_original.GetItem<ContractsBenchmark>(i);
                            if (record.ContractNo == ll_contract_no && record.SequenceNo == ll_sequence_no)
                            {
                                ll_found = i;
                                break;
                            }
                        }

                        if (ll_found >= 0)
                        {
                            ldc_original_benchmark = ids_original.GetItem<ContractsBenchmark>(ll_found).BenchMark;
                            ldc_original_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_found).OriginalFuelRate;
                            if (ldc_new_benchmark == null || ldc_original_benchmark == null || ldc_new_benchmark == 0 || ldc_original_benchmark == 0)
                            {
                                // Some trouble calculating benchmark.  Do not create adjustments
                            }
                            else if (ldc_new_benchmark != ldc_original_benchmark)
                            {
                                // Create adjustment
                                NFrequencyAdjustment n_freq = new NFrequencyAdjustment();// n_freq = CREATE n_frequency_adjustment;                            
                                n_freq.of_set_contract(ll_contract_no, ll_sequence_no);
                                // TJB  SR4654  April 2005
                                // Change the wording of the reason for the change
                                //			n_freq.is_Reason = 'Global fuel rate changed. \n' &
                                //									  +'Original standard rate: ' + ldc_original_fuel_rate.ToString() + '\n' &
                                //									  +'New standard rate: ' + ldc_new_standard_fuel_rate.ToString()
                                ldc_standard_fuel_rate_change = ldc_new_standard_fuel_rate.GetValueOrDefault() - ldc_original_fuel_rate.GetValueOrDefault();
                                if (ldc_standard_fuel_rate_change >= 0)
                                {
                                    ls_reason = "Increase: ";
                                }
                                else
                                {
                                    ldc_standard_fuel_rate_change = Math.Abs((decimal)ldc_standard_fuel_rate_change);
                                    ls_reason = "Decrease: ";
                                }

                                n_freq.is_reason = "Global fuel rate changed.\r\n" + ls_reason + ldc_standard_fuel_rate_change + " cents/litre\r\n" + "New standard rate: " + ldc_new_standard_fuel_rate + " cpl";
                                n_freq.of_set_effective_date(ld_effective_date);
                                ldc_amount_to_pay = ldc_new_benchmark - ldc_original_benchmark;
                                n_freq.idc_new_benchmark = ldc_new_benchmark;
                                n_freq.idc_amount_to_pay = ldc_amount_to_pay;
                                n_freq.idc_adjustment_amount = ldc_amount_to_pay;

                                if (ldc_amount_to_pay != 0)
                                {
                                    ll_result = n_freq.of_save();
                                    if (ll_result <= 0)
                                    {
                                        lb_continue = false;
                                        break;
                                    }
                                }
                                //?DESTROY n_freq
                            }
                        }
                }
            }

            this.Cursor = Cursors.Default;

            if (lb_continue)
            {
                //?EXECUTE IMMEDIATE 'COMMIT';
                li_return = 1;
            }
            else
            {
                //?EXECUTE IMMEDIATE 'ROLLBACK';
                li_return = -1;
            }
            //?EXECUTE IMMEDIATE 'END TRANSACTION';
            return li_return;
        }

        //public virtual int tab_other_rates_fpc_default()
        //{
        //    int ll_x = 1;
        //    decimal? ldc_original_fuel_rate;
        //    decimal? ldc_new_standard_fuel_rate;
        //    decimal? ldc_standard_fuel_rate_change;
        //    decimal? ldc_overridden_fuel_rate;
        //    decimal? ldc_new_override_fuel_rate;
        //    int ll_found;
        //    int? ll_fuel_key;
        //    int? ll_contract_no;
        //    int? ll_sequence_no;
        //    DateTime? ld_rates_effective_date;
        //    long? ll_rg_code;
        //    DataUserControl lds_new_benchmarks;
        //    decimal? ldc_new_benchmark;
        //    decimal? ldc_original_benchmark;
        //    decimal? ldc_amount_to_pay;
        //    //?n_frequency_adjustment	n_freq;
        //    DateTime? ld_effective_date;
        //    long ll_result = -1;
        //    bool lb_continue = true;
        //    string ls_test;
        //    string ls_reason;
        //    bool lb_go;
        //    int? ll_selected_rg_code;
        //    int li_return = -1;
        //    int SQLCode = 0;
        //    string SQLErrText = string.Empty;


        //    /*
        //    This override process will impact on all contracts with the following matching criteria:
        //    * Its an RD contract type
        //    * Its currently active with a future expiry date
        //    The process will modify the Standard Rate instead of each contract's individual override
        //    rate.  The reason is because if override rates are modified, it is hard to 
        //    re-assess the differentials between the new global override rate and each constract's
        //    manually set override rate if any.
        //    Steps:
        //     ( 1) 	Retrieve benchmarks for all valid contracts
        //     ( 2)	For each contract with custom-set override rate, update the override rate
        //    to reflect the new differentials:
        //    New Override Rate =  ( Old Override Rate - Old Standard Rate) + New Global rate
        //    Note that the Standard Rate and Global Rate will be the rate for the contract's
        //    specified fuel type.  For example, if the fuel type is set to CNG then the global
        //    and standard CNG rates are retrieved.
        //     ( 3)	Update the standard rates for each different rates_effective_date and renewal group  ( rg_code)
        //     ( 4)	Obtain new benchmark figures for all valid contracts
        //     ( 5)	For each contract,
        //    IF the benchmark figure differs THEN
        //    CREATE a frequency adjustment for the contract
        //    END IF
        //    LOOP
        //    */
        //    dw_rates.AcceptText();
        //    if (!StaticFunctions.IsDirty(dw_rates))
        //    {
        //        // No rates specified for this tab. ignore the tab
        //        return 1;
        //    }
        //    // Validate criteria fields
        //    if (of_validate_criteria() < 0)
        //    {
        //        return li_return;
        //    }
        //    ld_effective_date = null;
        //    ld_effective_date = dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate;
        //    ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;
        //    lb_go = false;
        //    for (ll_x = 0; ll_x < dw_details.RowCount; ll_x++)
        //    {
        //        ldc_original_fuel_rate = dw_details.GetItem<NationalFuelOverride>(ll_x).FuelRate;
        //        if (ldc_original_fuel_rate == null || ldc_original_fuel_rate == 0)
        //        {
        //        }
        //        else
        //        {
        //            lb_go = true;
        //        }
        //    }
        //    if (!lb_go)
        //    {
        //        MessageBox.Show("You must specify at least one new fuel rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        this.Focus();
        //        return li_return;
        //    }
        //    // Prompt for confirmation
        //    if (MessageBox.Show("Are you sure you want to proceed? \r\n" +
        //    "The change will impact on all currently active contracts \r\n" +
        //    "and benchmarks for the selected renewal group.", "Warning",
        //    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
        //    {
        //        this.Focus();
        //        return li_return;
        //    }
        //    ids_original = new DContractsBenchmark();
        //    ((DContractsBenchmark)ids_original).Retrieve(ll_selected_rg_code);
        //    ids_standard_fuels = new DStandardFuelRates();
        //    ll_found = ((DStandardFuelRates)ids_standard_fuels).Retrieve();
        //    //? Commit;
        //    //?EXECUTE IMMEDIATE "BEGIN TRANSACTION";
        //    for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
        //    {
        //        ldc_original_fuel_rate = null;
        //        ldc_new_standard_fuel_rate = null;
        //        ldc_new_override_fuel_rate = null;
        //        ldc_overridden_fuel_rate = null;
        //        ll_contract_no = null;
        //        ll_sequence_no = null;
        //        ld_rates_effective_date = null;
        //        ll_found = 0;
        //        ll_contract_no = ids_original.GetItem<ContractsBenchmark>(ll_x).ContractNo;
        //        ll_sequence_no = ids_original.GetItem<ContractsBenchmark>(ll_x).SequenceNo;
        //        ld_rates_effective_date = ids_original.GetItem<ContractsBenchmark>(ll_x).RatesEffectiveDate;
        //        ll_fuel_key = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelKey;
        //        // PBY 04/06/2002
        //        // Don"t bother creating a frequency adjustment if we 
        //        // cannot determin the fule type used!
        //        if (ll_fuel_key == null)
        //        {
        //            continue;
        //        }
        //        ll_rg_code = ids_original.GetItem<ContractsBenchmark>(ll_x).RgCode;
        //        ldc_original_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_x).OriginalFuelRate;
        //        ldc_overridden_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_x).FuelRate;
        //        // Find the new rate for this 
        //        ll_found = dw_details.Find("ft_key", ll_fuel_key);
        //        if (ll_found >= 0)
        //        {
        //            ldc_new_standard_fuel_rate = dw_details.GetItem<NationalFuelOverride>(ll_found).FuelRate;
        //        }
        //        else
        //        {
        //            ldc_new_standard_fuel_rate = null;
        //        }
        //        ll_found = 0;
        //        if (ldc_overridden_fuel_rate == null
        //        || ldc_overridden_fuel_rate == 0
        //        || ldc_new_standard_fuel_rate == null
        //        || ldc_new_standard_fuel_rate == 0)
        //        {
        //            // Dont adjust the fuel rate override
        //        }
        //        else
        //        {
        //            // An override rate exists for this contract and needs to be re-adjusted
        //            ldc_new_override_fuel_rate = (ldc_overridden_fuel_rate - ldc_original_fuel_rate) + ldc_new_standard_fuel_rate;
        //            /* UPDATE	vehicle_override_rate vor1
        //                    SET		vor1.vor_fuel_rate = :ldc_new_override_fuel_rate
        //                    WHERE		vor1.contract_no = :ll_contract_no
        //                    AND		vor1.contract_seq_number = :ll_sequence_no
        //                    AND		vor1.vor_effective_date >= :ld_rates_effective_date
        //                    AND		vor1.vor_effective_date =  ( SELECT	max ( vor2.vor_effective_date) 
        //                    FROM		vehicle_override_rate vor2 
        //                    WHERE		vor2.contract_no = vor1.contract_no
        //                    AND		vor2.contract_seq_number = vor1.contract_seq_number)
        //                    USING		itr_tran_obj; */
        //            RDSDataService.UpdateVehicleOverrideRate(ldc_new_override_fuel_rate, ll_contract_no, ll_sequence_no, ld_rates_effective_date, ref SQLCode, ref SQLErrText);
        //            if (SQLCode != 0/* itr_tran_obj.SQLCode != 0 */)
        //            {
        //                MessageBox.Show (  "Unable to update vehicle_override_rate table. \r\n"  + "The global update process will be aborted.\r\n\n"     + "Error Code: " + /*?String ( itr_tran_obj.SQLDBCode)*/""+ "\nError Text: " + SQLErrText ,  "Database Error" );
        //                lb_continue = false;
        //                break;
        //            }
        //            else
        //            {
        //                lb_continue = true;
        //            }
        //        }
        //        // Update the standard fuel rates if it changes
        //        if (ldc_new_standard_fuel_rate > 0)
        //        {
        //            ll_found = ids_standard_fuels.Find(new KeyValuePair<string, object>[] {
        //        new KeyValuePair<string, object>("ft_key", ll_fuel_key),
        //        new KeyValuePair<string, object>("rg_code", ll_rg_code),
        //        new KeyValuePair<string, object>("rr_rates_effective_date", ld_rates_effective_date)
        //    });
        //            if (ll_found >= 0)
        //            {
        //                ids_standard_fuels.GetItem<StandardFuelRates>(ll_found).FrFuelRate = ldc_new_standard_fuel_rate;
        //            }
        //            else
        //            {
        //                MessageBox.Show("row must exist", "double check!!");
        //            }
        //        }
        //    }
        //    if (lb_continue)
        //    {
        //        // Saves the standard fuel rates
        //        ids_standard_fuels.Save(); // ids_standard_fuels.Update ( true, false);
        //        ll_result = 1;
        //        if (ll_result < 0)
        //        {
        //            lb_continue = false;
        //        }
        //    }
        //    if (lb_continue)
        //    {
        //        // Obtain new benchmark
        //        lds_new_benchmarks = new DContractsBenchmark();
        //        ((DContractsBenchmark)lds_new_benchmarks).Retrieve(ll_selected_rg_code);
        //        // Loop thru the new benchmarks and see if benchmark is different
        //        for (ll_x = 0; ll_x < lds_new_benchmarks.RowCount; ll_x++)
        //        {
        //            ll_found = 0;
        //            ll_contract_no = null;
        //            ll_sequence_no = null;
        //            ldc_new_benchmark = null;
        //            ldc_original_benchmark = null;
        //            ldc_amount_to_pay = null;
        //            ll_contract_no = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).ContractNo;
        //            ll_sequence_no = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).SequenceNo;
        //            ldc_new_benchmark = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).BenchMark;
        //            ldc_new_standard_fuel_rate = lds_new_benchmarks.GetItem<ContractsBenchmark>(ll_x).OriginalFuelRate;
        //            // PBY 04/06/2002
        //            // IF new standard fuel rate is null, it should not be processed
        //            if (ldc_new_standard_fuel_rate == null)
        //            {
        //                continue;
        //            }
        //            // Find the new rate for this 
        //            ll_found = ids_original.Find(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("contract_no", ll_contract_no),
        //                                         new KeyValuePair<string, object>("sequence_no", ll_sequence_no) });
        //            if (ll_found >= 0)
        //            {
        //                ldc_original_benchmark = ids_original.GetItem<ContractsBenchmark>(ll_found).BenchMark;
        //                ldc_original_fuel_rate = ids_original.GetItem<ContractsBenchmark>(ll_found).OriginalFuelRate;
        //                if (ldc_new_benchmark == null || ldc_original_benchmark == null ||
        //                ldc_new_benchmark == 0 || ldc_original_benchmark == 0)
        //                {
        //                    // Some trouble calculating benchmark.  Do not create adjustments
        //                }
        //                else if (ldc_new_benchmark != ldc_original_benchmark)
        //                {
        //                    // Create adjustment
        //                    NFrequencyAdjustment n_freq = new NFrequencyAdjustment();//n_freq = CREATE n_frequency_adjustment
        //                    n_freq.of_set_contract(ll_contract_no, ll_sequence_no);
        //                    // TJB  SR4654  April 2005
        //                    // Change the wording of the reason for the change
        //                    //			n_freq.is_Reason = "Global fuel rate changed. \r\n" 
        //                    //									  +"Original standard rate: " + ldc_original_fuel_rate.ToString() + "\r\n" 
        //                    //									  +"New standard rate: " + ldc_new_standard_fuel_rate.ToString()
        //                    ldc_standard_fuel_rate_change = ldc_new_standard_fuel_rate - ldc_original_fuel_rate;
        //                    if (ldc_standard_fuel_rate_change >= 0)
        //                        ls_reason = "Increase: ";
        //                    else
        //                    {
        //                        ldc_standard_fuel_rate_change = Math.Abs((decimal)ldc_standard_fuel_rate_change);
        //                        ls_reason = "Decrease: ";
        //                    }
        //                    n_freq.is_reason = "Global fuel rate changed.\r" + ls_reason + ldc_standard_fuel_rate_change.ToString() + " cents/litre\r" + "New standard rate: " + ldc_new_standard_fuel_rate.ToString() + " cpl";
        //                    n_freq.of_set_effective_date(ld_effective_date);
        //                    ldc_amount_to_pay = ldc_new_benchmark - ldc_original_benchmark;
        //                    n_freq.idc_new_benchmark = ldc_new_benchmark;
        //                    n_freq.idc_amount_to_pay = ldc_amount_to_pay;
        //                    n_freq.idc_adjustment_amount = ldc_amount_to_pay;
        //                    if (ldc_amount_to_pay != 0)
        //                    {
        //                        ll_result = n_freq.of_save();
        //                        if (ll_result <= 0)
        //                        {
        //                            lb_continue = false;
        //                            break;
        //                        }
        //                    }
        //                    //?DESTROY n_freq
        //                }
        //            }
        //        }
        //    }
        //    if (lb_continue)
        //    {
        //        //?EXECUTE IMMEDIATE "COMMIT";
        //        li_return = 1;
        //    }
        //    else
        //    {
        //        //?EXECUTE IMMEDIATE "ROLLBACK";
        //        li_return = -1;
        //    }
        //    //?EXECUTE IMMEDIATE "END TRANSACTION";
        //    return li_return;
        //}

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
            //  change 'Petrol' to 'Petrol  ( Diesel Equivalent)'.
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

        //public virtual void tab_other_rates_fpc_default()
        //{
        //    int ll_x = 1;
        //    decimal ldc_overridden_ruc_rate;
        //    decimal ldc_new_standard_ruc_rate;
        //    decimal ldc_original_ruc_rate;
        //    decimal ldc_new_override_ruc_rate;
        //    int ll_found;
        //    int ll_contract_no;
        //    int ll_sequence_no;
        //    DateTime ld_rates_effective_date;
        //    DataUserControl lds_new_benchmarks;
        //    decimal ldc_new_benchmark;
        //    decimal ldc_original_benchmark;
        //    decimal ldc_amount_to_pay;
        //    NFrequencyAdjustment n_freq;
        //    DateTime ld_effective_date;
        //    int ll_result = -1;
        //    bool lb_continue = TRUE;
        //    int ll_selected_rg_code;
        //    int li_RETURN = -1;
        //    /*
        //    This override process will impact on all contracts with the following matching criteria:
        //    * Its an RD contract type
        //    * Its currently active with a future expiry date
        //    * COntract with current vehicle fuel type of 'Diesel'
        //    The process will modify the Standard Rate instead of each contract's individual override
        //    rate.  The reason is because if override rates are modified, it is hard to 
        //    re-assess the differentials between the new global override rate and each constract's
        //    manually set override rate if any.
        //    Steps:
        //     ( 1) 	Retrieve benchmarks for all valid contracts
        //     ( 2)	For each contract with custom-set override rate, update the override rate
        //    to reflect the new differentials:
        //    New RUC Override Rate =  ( Old RUC Override Rate - Old RUC Standard Rate) + New RUC Global rate
        //     ( 3)	Update the standard rates for each different rates_effective_date and renewal group  ( rg_code)
        //     ( 4)	Obtain new benchmark figures for all valid contracts
        //     ( 5)	For each contract,
        //    IF the benchmark figure differs THEN
        //    CREATE a frequency adjustment for the contract
        //    END IF
        //    LOOP
        //    */
        //    dw_rates.AcceptText();
        //    if (!StaticFunctions.IsDirty(dw_rates)/*.ModifiedCount() = 0*/)
        //    {
        //        // No rates specified for this tab. ignore the tab
        //        return 1;
        //    }
        //    // Validate criteria fields
        //    if (of_validate_criteria() < 0)
        //    {
        //        return li_RETURN;
        //    }
        //    ld_effective_date = null;
        //    ld_effective_date = dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate;// .GetItemDateTime( 1, 'ad_effective_date').Date
        //    ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;//, 'al_renewal_group')
        //    ldc_new_standard_ruc_rate = dw_rates.GetItem<NationalRatesOverrideFields>(0).RucRate;//, 'ruc_rate' )
        //    if (ldc_new_standard_ruc_rate == null || ldc_new_standard_ruc_rate == 0)
        //    {
        //        MessageBox.Show("You must specify a Road User Charge rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        this.Focus();
        //        return li_RETURN;
        //    }
        //    // Prompt for confirmation
        //    DialogResult dlg = DialogResult.None;
        //    dlg = MessageBox("Warning", "Are you sure you want to proceed? \n The change will impact on all currently active contracts \n and benchmarks for the selected renewal group.", MessageBoxIcon.Question, MessageBoxButtons.YesNo);

        //    if (dlg == DialogResult.None)
        //    {
        //        this.Focus();
        //        return li_RETURN;
        //    }
        //    ids_original = new DataUserControl();//CREATE n_ds
        //    ids_original = new DContractsBenchmarkForRates();
        //    ((DContractsBenchmarkForRates)ids_original).Retrieve(ll_selected_rg_code);
        //    //?Commit;
        //    //?EXECUTE IMMEDIATE 'BEGIN TRANSACTION';
        //    for (ll_x = 1; ll_x < ids_original.RowCount; ll_x++)
        //    {
        //        ldc_original_ruc_rate = null;
        //        ldc_new_override_ruc_rate = null;
        //        ldc_overridden_ruc_rate = null;
        //        ll_contract_no = null;
        //        ll_sequence_no = null;
        //        ld_rates_effective_date = null;
        //        ll_found = 0;
        //        ll_contract_no = (int)ids_original.GetValue(ll_x, "contract_no");
        //        ll_sequence_no = (int)ids_original.GetValue(ll_x, "sequence_no");
        //        ld_rates_effective_date = (DateTime)ids_original.GetValue(ll_x, "rates_effective_date");
        //        ldc_original_ruc_rate = (decimal)ids_original.GetValue(ll_x, "original_ruc_rate");
        //        ldc_overridden_ruc_rate = (decimal)ids_original.GetValue(ll_x, "override_ruc_rate");
        //        if (ldc_overridden_ruc_rate == null || ldc_overridden_ruc_rate == 0)
        //        {
        //            // Dont adjust the ruc rate override
        //        }
        //        else
        //        {
        //            // An override rate exist for this contract and needs to be re-adjusted
        //            ldc_new_override_ruc_rate = (ldc_overridden_ruc_rate - ldc_original_ruc_rate) + ldc_new_standard_ruc_rate;
        //            /*?UPDATE	vehicle_override_rate vor1 SET vor1.vor_ruc = :ldc_new_override_ruc_rate 
        //                WHERE vor1.contract_no = :ll_contract_no AND vor1.contract_seq_number = :ll_sequence_no AND 
        //                vor1.vor_effective_date >= :ld_rates_effective_date AND 
        //                vor1.vor_effective_date = ( SELECT	max ( vor2.vor_effective_date) FROM vehicle_override_rate vor2 WHERE vor2.contract_no = vor1.contract_no AND vor2.contract_seq_number = vor1.contract_seq_number) 
        //                USING itr_tran_obj;
        //             */
        //            if (false)//itr_tran_obj.SQLCode <> 0 )
        //            {
        //                //?MessageBox.Show("Unable to update vehicle_override_rate table. \n The global update process will be aborted.\n\n Error Code: " + String ( itr_tran_obj.SQLDBCode) + & '\nError Text: ' + itr_tran_obj.SQLERRTEXT,  'Database Error' )
        //                lb_continue = false;
        //                continue;//EXIT
        //            }
        //            else
        //            {
        //                lb_continue = true;
        //            }
        //        }
        //        // Update the standard ruc rates for the rates_effective_date of the renewal group
        //        //? UPDATE	vehicle_rate vr1 SET vr1.vr_ruc = :ldc_new_standard_ruc_rate WHERE vr1.vr_rates_effective_date = :ld_rates_effective_date
        //        //? USING		itr_tran_obj;
        //        if (false) // itr_tran_obj.SQLCode <> 0 THEN
        //        {
        //            //?MessageBox.Show ( 'Unable to update vehicle_rate table. \n' + & 'The global update process will be aborted.\n\n' + &  'Error Code: ' + String ( itr_tran_obj.SQLDBCode) + & '\nError Text: ' + itr_tran_obj.SQLERRTEXT,  'Database Error' )
        //            lb_continue = false;
        //            continue;//EXIT
        //        }
        //    }

        //    if (lb_continue)
        //    {
        //        // Obtain new benchmark
        //        lds_new_benchmarks = new DataUserControl();// CREATE n_ds
        //        lds_new_benchmarks = new DContractsBenchmarkForRates();
        //        ((DContractsBenchmarkForRates)lds_new_benchmarks).Retrieve(ll_selected_rg_code);
        //        // Loop thru the new benchmarks and see if benchmark is different
        //        for (ll_x = 1; ll_x < lds_new_benchmarks.RowCount; ll_x++)
        //        {
        //            ll_contract_no = lds_new_benchmarks.GetValue(ll_x, "contract_no");
        //            ll_sequence_no = lds_new_benchmarks.GetValue(ll_x, "sequence_no");
        //            ldc_new_benchmark = lds_new_benchmarks.GetValue(ll_x, "bench_mark");
        //            ldc_new_standard_ruc_rate = lds_new_benchmarks.GetValue(ll_x, "original_ruc_rate");
        //            // Find the new rate for this 
        //            ll_found = ids_original.Find(new KeyValuePair<string, object>("contract_no", ll_contract_no.ToString())
        //                , new KeyValuePair<string, object>("sequence_no", ll_sequence_no.ToString()));// "contract_no = " , ll_contract_no.ToString() + " and sequence_no = " + ll_sequence_no.ToString(), 1, ids_original.RowCount);

        //            if (ll_found > 0)
        //            {
        //                ldc_original_benchmark = ids_original.GetValue(ll_found, "bench_mark");
        //                ldc_original_ruc_rate = ids_original.GetValue(ll_found, "original_ruc_rate");
        //                if (ldc_new_benchmark == null || ldc_original_benchmark == null || ldc_new_benchmark == 0 || ldc_original_benchmark == 0)
        //                {
        //                    // Some trouble calculating benchmark.  Do not create adjustments
        //                }
        //                else if (ldc_new_benchmark != ldc_original_benchmark)
        //                {
        //                    // Create adjustment
        //                    n_freq = new NFrequencyAdjustment();// CREATE  n_frequency_adjustment
        //                    n_freq.of_set_contract(ll_contract_no, ll_sequence_no);
        //                    n_freq.is_reason = "Global RUC rate changed. \nOriginal RUC rate:" + ldc_original_ruc_rate.ToString() + "\nNew RUC rate: " + ldc_new_standard_ruc_rate.ToString();

        //                    n_freq.of_set_effective_date(ld_effective_date);
        //                    ldc_amount_to_pay = ldc_new_benchmark - ldc_original_benchmark;
        //                    n_freq.idc_new_benchmark = ldc_new_benchmark;
        //                    n_freq.idc_amount_to_pay = ldc_amount_to_pay;
        //                    n_freq.idc_adjustment_amount = ldc_amount_to_pay;
        //                    if (ldc_amount_to_pay != 0)
        //                    {
        //                        ll_result = n_freq.of_save();
        //                        if (ll_result <= 0)
        //                        {
        //                            lb_continue = false;
        //                            continue;//EXIT
        //                        }
        //                    }
        //                    //DESTROY n_freq
        //                }
        //            }
        //            ll_found = 0;
        //            ll_contract_no = null;
        //            ll_sequence_no = null;
        //            ldc_new_benchmark = null;
        //            ldc_original_benchmark = null;
        //            ldc_amount_to_pay = null;
        //        }
        //    }
        //    if (lb_continue)
        //    {
        //        //?EXECUTE IMMEDIATE 'COMMIT';
        //        li_RETURN = 1;
        //    }
        //    else
        //    {
        //        //?EXECUTE IMMEDIATE 'ROLLBACK';
        //        li_RETURN = -1;
        //    }
        //    //?EXECUTE IMMEDIATE 'END TRANSACTION';
        //    return li_RETURN;

        //}

        public virtual int tabpage_other_rates_pfc_default()
        {
            int ll_x = 1;
            decimal? ldc_overridden_ruc_rate;
            decimal? ldc_new_standard_ruc_rate;
            decimal? ldc_original_ruc_rate;
            decimal? ldc_new_override_ruc_rate;
            int ll_found;
            int? ll_contract_no;
            int? ll_sequence_no;
            DateTime? ld_rates_effective_date;
            DataUserControlContainer lds_new_benchmarks;//n_ds
            decimal? ldc_new_benchmark;
            decimal? ldc_original_benchmark;
            decimal? ldc_amount_to_pay;
            NFrequencyAdjustment n_freq;
            DateTime? ld_effective_date;
            int ll_result = -1;
            bool lb_continue = true;
            int? ll_selected_rg_code;
            int li_RETURN = -1;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            dw_rates.AcceptText();
            if (!StaticFunctions.IsDirty(dw_rates))
                // No rates specified for this tab. ignore the tab
                return 1;

            // Validate criteria fields
            if (of_validate_criteria() < 0)
                return li_RETURN;

            ld_effective_date = null;
            ld_effective_date = dw_criteria.GetItem<FuelOverrideFields>(0).AdEffectiveDate;
            ll_selected_rg_code = dw_criteria.GetItem<FuelOverrideFields>(0).AlRenewalGroup;
            ldc_new_standard_ruc_rate = dw_rates.GetItem<NationalRatesOverrideFields>(0).RucRate;
            if (ldc_new_standard_ruc_rate == null || ldc_new_standard_ruc_rate == 0)
            {
                MessageBox.Show("You must specify a Road User Charge rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Focus();
                return li_RETURN;
            }
            // Prompt for confirmation
            if (MessageBox.Show("Are you sure you want to proceed? \n" + "The change will impact on all currently active contracts \n" + "and benchmarks for the selected renewal group.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                this.Focus();
                return li_RETURN;
            }
            //ids_original = CREATE n_ds;
            DataUserControlContainer ids_original = new DataUserControlContainer();
            ids_original.DataObject = new DContractsBenchmarkForRates();// 'd_contracts_benchmark_for_rates';
            ((DContractsBenchmarkForRates)ids_original.DataObject).Retrieve(ll_selected_rg_code);
            //?Commit;
            //?EXECUTE IMMEDIATE 'BEGIN TRANSACTION';;
            for (ll_x = 0; ll_x < ids_original.RowCount; ll_x++)
            {
                ldc_original_ruc_rate = null;
                ldc_new_override_ruc_rate = null;
                ldc_overridden_ruc_rate = null;
                ll_contract_no = null;
                ll_sequence_no = null;
                ld_rates_effective_date = null;
                ll_found = 0;
                ll_contract_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).ContractNo;
                ll_sequence_no = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).SequenceNo;
                ld_rates_effective_date = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).RatesEffectiveDate;
                ldc_original_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).OriginalRucRate;
                ldc_overridden_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).OverrideRucRate;
                if (ldc_overridden_ruc_rate == null || ldc_overridden_ruc_rate == 0)
                {
                    // Dont adjust the ruc rate override
                }
                else
                {
                    // An override rate exist for this contract and needs to be re-adjusted
                    ldc_new_override_ruc_rate = (ldc_overridden_ruc_rate.GetValueOrDefault() - ldc_original_ruc_rate.GetValueOrDefault()) + 
                        ldc_new_standard_ruc_rate.GetValueOrDefault();
                    /*UPDATE	vehicle_override_rate vor1
                    SET		vor1.vor_ruc = :ldc_new_override_ruc_rate
                    WHERE		vor1.contract_no = :ll_contract_no
                    AND		vor1.contract_seq_number = :ll_sequence_no
                    AND		vor1.vor_effective_date >= :ld_rates_effective_date
                    AND		vor1.vor_effective_date =  ( SELECT	max ( vor2.vor_effective_date) 
                    FROM		vehicle_override_rate vor2 
                    WHERE		vor2.contract_no = vor1.contract_no
                    AND		vor2.contract_seq_number = vor1.contract_seq_number)
                    USING		itr_tran_obj;*/
                    RDSDataService.UpdateVehicleOverrideRate(ldc_new_override_ruc_rate, ll_contract_no, ll_sequence_no, ld_rates_effective_date, 
                        ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show("nable to update vehicle_override_rate table. \n" + "The global update process will be aborted.\n\n" + 
                            "Error Code:" + /*?String(itr_tran_obj.SQLDBCode) +*/ "\nError Text:" + SQLErrText, "Database Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lb_continue = false;
                        break;
                    }
                    else
                    {
                        lb_continue = true;
                    }
                }
                // Update the standard ruc rates for the rates_effective_date of the renewal group
                /*UPDATE	vehicle_rate vr1
                SET		vr1.vr_ruc = :ldc_new_standard_ruc_rate
                WHERE		vr1.vr_rates_effective_date = :ld_rates_effective_date
                USING		itr_tran_obj;*/
                RDSDataService.UpdateVehicleRate(ldc_new_standard_ruc_rate, ld_rates_effective_date, ref SQLCode, ref SQLErrText);
                if (SQLCode != 0)
                {
                    MessageBox.Show("Unable to update vehicle_rate table. \n" + "The global update process will be aborted.\n\n" + 
                        "Error Code: " + /*?String ( itr_tran_obj.SQLDBCode) +*/ "\nError Text: " + SQLErrText, "Database Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lb_continue = false;
                    break;
                }
            }
            if (lb_continue == true)
            {
                // Obtain new benchmark
                //lds_new_benchmarks = CREATE n_ds
                lds_new_benchmarks = new DataUserControlContainer();
                lds_new_benchmarks.DataObject = new DContractsBenchmarkForRates();//'d_contracts_benchmark_for_rates';
                ((DContractsBenchmarkForRates)lds_new_benchmarks.DataObject).Retrieve(ll_selected_rg_code);
                // Loop thru the new benchmarks and see if benchmark is different
                for (ll_x = 0; ll_x < lds_new_benchmarks.RowCount; ll_x++)
                {
                    ll_contract_no = lds_new_benchmarks.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).ContractNo;
                    ll_sequence_no = lds_new_benchmarks.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).SequenceNo;
                    ldc_new_benchmark = lds_new_benchmarks.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).BenchMark;
                    ldc_new_standard_ruc_rate = lds_new_benchmarks.DataObject.GetItem<ContractsBenchmarkForRates>(ll_x).OriginalRucRate;

                    // Find the new rate for this 
                    //ll_found = ids_original.Find("contract_no = " + ll_contract_no.ToString() + " and sequence_no = " + ll_sequence_no.ToString(), 1, ids_original.RowCount);
                    //!ll_found = ids_original.DataObject.Find(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("contract_no", ll_contract_no),
                    //!                                                                  new KeyValuePair<string, object>("sequence_no", ll_sequence_no) });
                    ll_found = -1;
                    for (int i = 0; i < ids_original.DataObject.RowCount; i++)
                    {
                        ContractsBenchmarkForRates current = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(i);
                        if (current.ContractNo == ll_contract_no && current.SequenceNo == ll_sequence_no)
                        {
                            ll_found = i;
                            break;
                        }
                    }


                    if (ll_found >= 0)
                    {
                        ldc_original_benchmark = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_found).BenchMark;
                        ldc_original_ruc_rate = ids_original.DataObject.GetItem<ContractsBenchmarkForRates>(ll_found).OriginalRucRate;
                        if ((ldc_new_benchmark == null) || (ldc_original_benchmark == null) || ldc_new_benchmark == 0 || ldc_original_benchmark == 0)
                        {
                            // Some trouble calculating benchmark.  Do not create adjustments
                        }
                        else if (ldc_new_benchmark != ldc_original_benchmark)
                        {
                            // Create adjustment
                            //n_freq = CREATE n_frequency_adjustment;
                            n_freq = new NFrequencyAdjustment();
                            n_freq.of_set_contract(ll_contract_no, ll_sequence_no);
                            n_freq.is_reason = "Global RUC rate changed. \nOriginal RUC rate: " + ldc_original_ruc_rate.ToString() + "\nNew RUC rate:" + ldc_new_standard_ruc_rate.ToString();
                            n_freq.of_set_effective_date(ld_effective_date);
                            ldc_amount_to_pay = ldc_new_benchmark.GetValueOrDefault() - ldc_original_benchmark.GetValueOrDefault();
                            n_freq.idc_new_benchmark = ldc_new_benchmark;
                            n_freq.idc_amount_to_pay = ldc_amount_to_pay;
                            n_freq.idc_adjustment_amount = ldc_amount_to_pay;
                            if (ldc_amount_to_pay != 0)
                            {
                                ll_result = n_freq.of_save();
                                if (ll_result <= 0)
                                {
                                    lb_continue = false;
                                    break;//EXIT
                                }
                            }
                            //?DESTROY n_freq                            
                        }
                    }
                    ll_found = 0;
                    ll_contract_no = null;
                    ll_sequence_no = null;
                    ldc_new_benchmark = null;
                    ldc_original_benchmark = null;
                    ldc_amount_to_pay = null;
                }
            }
            if (lb_continue == true)
            {
                //?EXECUTE IMMEDIATE 'COMMIT';
                li_RETURN = 1;
            }
            else
            {
                //?EXECUTE IMMEDIATE 'ROLLBACK';
                li_RETURN = -1;
            }
            //?EXECUTE IMMEDIATE 'END TRANSACTION';
            return li_RETURN;
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
            if (tab_rates.SelectedIndex == 0)
            {
                li_rc = MessageBox.Show("Please confirm that the rates entered are correct, and\n" + "especially that the Petrol rate is a diesel equivalent.", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (li_rc == DialogResult.No || li_rc == DialogResult.Cancel)
                {
                    idw_details.Focus();
                    return;
                }
            }
            //  ( this is all that was in the original)
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
            if (tab_rates.SelectedIndex == 1) //(oldindex == 1)
            {
                ldw_temp = idw_details;
            }
            else
            {
                ldw_temp = idw_rates;
            }
            ldw_temp.AcceptText();
            if (ldw_temp.DataObject.DeletedCount > 0 && ldw_temp.ModifiedCount() > 0)
            {
                li_rc = MessageBox.Show("The changes you made will be lost if you switch to \n" + "the other tabpage.  Do you want to continue?", "Tabpage focus change", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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