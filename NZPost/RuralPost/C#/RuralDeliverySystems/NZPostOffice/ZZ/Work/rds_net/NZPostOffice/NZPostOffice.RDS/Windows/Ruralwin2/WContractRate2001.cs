using System;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin2;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin2;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public partial class WContractRate2001 : WMaster
    {
        #region Define

        public int? il_contract;

        public int? il_sequence;

        public int? il_economiclife;

        public int il_inserted;

        private string senderName = string.Empty; //ygu

        public decimal? idc_original_benchmark;

        public DateTime? id_previous_effective_date = DateTime.MinValue;

        public URdsDw idw_vehiclerates;

        public URdsDw idw_nonvehiclerates;

        public URdsDw idw_otherrates;

        //  TJB  SR4695  Jan-2007
        //  TJB  RD7_0038  Jan-2009: Changed ids_nonvehiclerateshistory to ids_nonvehicleratehistory
        public DsNonVehicleOverrideRateHistory ids_nonvehicleratehistory;

        // tempory variable
        private NZPostOffice.RDS.DataService.RDSDataService dataService = new NZPostOffice.RDS.DataService.RDSDataService();

        #endregion

        public WContractRate2001()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            dw_vehicle_rates.DataObject = new DVehicleOverrideRates();
            dw_non_vehicle_rates.DataObject = new DNonVehicleOverrideRates();
            dw_other_rates.DataObject = new DOtherOverrideRates();

            dw_vehicle_rates.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_vehicle_constructor);
            dw_vehicle_rates.PfcUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_vehicle_rates_pfc_update);
            dw_vehicle_rates.PfcValidation += new UserEventDelegate1(dw_vehicle_rates_pfc_validation);
            dw_vehicle_rates.DataObject.GotFocus += new EventHandler(dw_vehicle_rates_getfocus);
            ((DVehicleOverrideRates)dw_vehicle_rates.DataObject).TextBoxLostFocus += new EventHandler(dw_vehicle_rates_itemchanged);

            dw_non_vehicle_rates.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_non_vehicle_ratesconstructor);
            dw_non_vehicle_rates.PfcPostUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_non_vehicle_rates_pfc_postupdate);
            dw_non_vehicle_rates.DataObject.GotFocus += new EventHandler(dw_non_vehicle_rates_getfocus);
            //dw_non_vehicle_rates.ItemChanged += new EventHandler(dw_non_vehicle_rates_itemchanged);
            ((DNonVehicleOverrideRates)dw_non_vehicle_rates.DataObject).TextBoxLostFocus += new EventHandler(dw_non_vehicle_rates_itemchanged);

            dw_other_rates.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_other_rates_constructor);
            dw_other_rates.URdsDwEditChanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_other_rateseditchanged);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public override void pfc_postopen()
        {
            int ll_rc;
            int ll_row;
            string ls_heading;
            il_contract = StaticVariables.gnv_app.of_get_parameters().longparm;
            il_sequence = StaticVariables.gnv_app.of_get_parameters().integerparm;

            // Retrieve rates
            idw_vehiclerates.Retrieve(new object[] { il_contract, il_sequence });
            idw_nonvehiclerates.Retrieve(new object[] { il_contract, il_sequence });
            idw_otherrates.Retrieve(new object[] { il_contract, il_sequence });
            // Insert a blank row if no rows were retrieved
            if (idw_vehiclerates.RowCount == 0)
            {
                ll_row = idw_vehiclerates.RowCount;
                idw_vehiclerates.InsertItem<VehicleOverrideRates>(ll_row);
                idw_vehiclerates.GetItem<VehicleOverrideRates>(ll_row).ContractNo = il_contract;
                idw_vehiclerates.GetItem<VehicleOverrideRates>(ll_row).ContractSeqNumber = il_sequence;
                idw_vehiclerates.GetItem<VehicleOverrideRates>(ll_row).VorEffectiveDate = System.DateTime.Today;
                id_previous_effective_date = null;
            }
            else
            {
                id_previous_effective_date = idw_vehiclerates.GetItem<VehicleOverrideRates>(0).VorEffectiveDate;
            }
            if (idw_nonvehiclerates.RowCount == 0)
            {
                idw_nonvehiclerates.InsertItem<NonVehicleOverrideRates>(0);
                ll_row = 0;
            }

            //  Make the heading of the datawindows = to the Contract_no, contract_seq_no and Contract name
            ls_heading = StaticMessage.StringParm;
            ls_heading = StaticVariables.gnv_app.of_get_parameters().stringparm;
            //?idw_vehiclerates.DataObject.GetControlByName("st_renewal").Text = ls_heading;
            //?idw_nonvehiclerates.GetControlByName("st_renewal").Text = ls_heading;

            // Make the columns read only if the contract has been accepted
            // If gnv_App.of_Get_Parameters().booleanparm Then
            // 	tab_override_rates.tabpage_vehicle_rates.dw_vehicle_rates.of_ProtectColumns()
            // 	tab_override_rates.tabpage_non_vehicle_rates.dw_non_vehicle_rates.of_ProtectColumns()
            // 	tab_override_rates.tabpage_other_rates.dw_other_rates.of_ProtectColumns()
            // End If
            il_economiclife = of_getremainingeconomiclife();
            if (il_economiclife == null || il_economiclife == 0)
            {
                il_economiclife = 200000;
            }
            //  If new rows were inserted above, this marks them unmodified
            //  otherwise, if no changes were made, the user would be asked
            //  whether to save them.  We only want to save them if the 
            //  user makes changes.
            idw_vehiclerates.ResetUpdate();
            //  TJB  SR4661  May 2005
            //  Changed benchmarkCalc stored proc name
            //  Obtain the original benchmark rate

            // SELECT	BenchmarkCalc2005(:il_contract, :il_sequence) 
            //   INTO	:idc_original_benchmark 
            //   FROM	dummy
            //  USING	SQLCA
            RDSDataService dataService = RDSDataService.GetBenchmarkCalc2005(il_sequence, il_contract);
            this.idc_original_benchmark = dataService.decVal;
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Unable to retreive the original benchmark for the contract."
                               , "WContractRate2001.pfc_postopen: Database Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //  TJB  SR4695  Jan-2007
            //  Create a datastore for the (new) Non-vehicle_override_rate_history table
            ids_nonvehicleratehistory = new DsNonVehicleOverrideRateHistory();
            //  ids_nonvehicleratehistory.retrieve(il_contract, il_sequence)
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Renewal Rates");
        }

        #region Methods
        public override void pfc_default()
        {
            int ll_rc;

            base.pfc_default();
            ll_rc = this.pfc_save();
            if (ll_rc >= 0)
            {
                this.Close();
            }
        }

        public override int pfc_preclose()
        {
            decimal? ldc_temp;

            base.pfc_preclose();
            //  TJB  SR4661  May 2005
            //  Added update of nvor_wage_hourly_rate from (new)
            //  nvor_processing_wage_rate 'just in case' the user
            //  has changed it (they're supposed to be identical)
            // 
            //  This is also in cb_ok.clicked.  The instance here
            //  catches updates triggered when the user closes the
            //  window with the window-close button  ( which doesn't
            //  go through pfc_default).
            idw_nonvehiclerates.AcceptText();
            idw_nonvehiclerates.AcceptText();
            idw_nonvehiclerates.AcceptText();
            //  Only do the update if the row is marked modified 
            //  (whether or not the processing wage was changed).
            //  If you copy the processing wage to the hourly wage
            //  "just in case" you'll mark the record modified and 
            //  set up a potential unwanted save (the user will 
            //  always be asked about saving because the vehicle 
            //  windows has been modified with today's date as the
            //  'new' effective date).
            if (StaticFunctions.IsDirty(idw_nonvehiclerates))
            {
                ldc_temp = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorProcessingWageRate;
                idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorWageHourlyRate = ldc_temp;
            }
            return SUCCESS;
        }

        public virtual int? of_getremainingeconomiclife()
        {
            int? ll_ecolife = null;
            // Get remaining economic life for the car
            // SELECT vehicle.v_remaining_economic_life INTO :ll_ecolife 
            //   FROM contract_vehical, vehicle 
            //  WHERE vehicle.vehicle_number = contract_vehical.vehicle_number 
            //    and contract_vehical.contract_no = :il_contract 
            //    AND contract_vehical.contract_seq_number = :il_sequence
            RDSDataService dataService = RDSDataService.GetVehicleLifeCode(il_sequence, il_contract);
            ll_ecolife = dataService.intVal;
            return ll_ecolife;
        }

        public virtual bool of_isterminated(int? al_contract)
        {
            //  TJB  SR4695  Jan-2007
            //  Check whether this contract is terminated
            //  Return
            // 		TRUE		Contract is terminated
            // 		FALSE		Contract isn't terminated
            DateTime? ld_temp = null;
            // select con_date_terminated into :ld_temp from contract where contract_no = :al_contract using SQLCA;
            RDSDataService dataService = RDSDataService.GetContractDateTerminated(al_contract);
            ld_temp = dataService.dtVal;
            if (ld_temp == null || ld_temp == DateTime.MinValue)
            {
                return false;
            }
            return true;
        }

        public virtual DateTime? of_get_next_fa_date(int? al_contract, int? al_sequence, DateTime? ad_effective_date)
        {
            //  TJB  SR4695  Feb-2007   New
            //  Return the next available fd_effective_date for the frequency_adjustments
            //  table for the contract.  This code is similar to (and largely copied from)
            //  that in the n_frequency_adjustment.of_set_effective_date function.
            // 
            //  Returns
            // 		Next available date.
            // 		NULL if there was an error
            int ll_count = 0;
            int? ll_sfkey = 0;
            string ls_deldays = "";
            DateTime? ld_next_date;
            DateTime? ld_null = null;

            //  Need to grab the first available "active" sf_key!
            //  Get the route frequency and delivery days from the Route_Frequency table
            // SELECT FIRST sf_key, rf_delivery_days INTO :ll_sfkey, :ls_deldays
            //   FROM route_frequency 
            //  WHERE contract_no = :al_contract 
            //    AND rf_active = 'Y'
            RDSDataService dataService = RDSDataService.GetFirstRouteFrequenctSfKey(al_contract);
            if (dataService.FirstRouteFrequenctSfKeyList.Count > 0)
            {
                FirstRouteFrequenctSfKeyItem item = dataService.FirstRouteFrequenctSfKeyList[0];
                ll_sfkey = item.SfKey;
                ls_deldays = item.RfDeliveryDays;
            }
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("ERROR: Looking up route details for the contract.\n\n" 
                                 + dataService.SQLErrText
                               , "Database Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ld_null;
            }

            //  Check that no other extensions are made to the database
            ld_next_date = ad_effective_date;

            // SELECT count(*) INTO :ll_count 
            //   FROM frequency_distances
            //  WHERE contract_no = :al_contract 
            //    AND sf_key = :ll_sfkey				
            //    AND rf_delivery_days = :ls_deldays 
            //    AND fd_effective_date = :ld_next_date
            dataService = RDSDataService.GetFrequencyDistancesCount( ll_sfkey
                                                                   , ls_deldays
                                                                   , ld_next_date
                                                                   , al_contract);
            ll_count = dataService.intVal;
            if (dataService.SQLCode == -(1))
            {
                MessageBox.Show("ERROR: Looking for duplicate effective date. \n\n" 
                                 + dataService.SQLErrText
                               , "Database error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ld_null;
            }
            if (ll_count > 0)
            {
                //  There is already an extension defined for this effective date. 
                //  Will get the next available effecitve date
                while (dataService.SQLCode == 0 && ll_count > 0)
                {
                    ld_next_date = ld_next_date.Value.AddDays(1);
                    // SELECT count(*) INTO	:ll_count 
                    //   FROM frequency_distances 
                    //  WHERE contract_no = :al_contract
                    //    AND sf_key = :ll_sfkey 
                    //    AND rf_delivery_days = :ls_deldays 
                    //    AND fd_effective_date = :ld_next_date
                    dataService = RDSDataService.GetFrequencyDistancesCount2( ll_sfkey
                                                                            , ls_deldays
                                                                            , ld_next_date
                                                                            , al_contract);
                    ll_count = dataService.intVal;
                    if (dataService.SQLCode == -(1))
                    {
                        MessageBox.Show("ERROR: Looking for next effective date. \n\n" 
                                         + dataService.SQLErrText
                                       , "Database error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ld_null;
                    }
                }
            }
            return ld_next_date;
        }

        public virtual void dw_vehicle_constructor()
        {
            idw_vehiclerates = dw_vehicle_rates;
        }

        public virtual void dw_vehicle_pfc_prermbmenu()
        {
            // 
        }

        public virtual int dw_vehicle_rates_pfc_update()
        {
            decimal? ldc_benchmark = 0;
            decimal? ldc_amount_to_pay = 0;
            int ll_return;
            int li_rc;
            int li_rows;
            DateTime? ld_effective_date;
            NFrequencyAdjustment n_freq;
            int li_return = 1;

            idw_vehiclerates.AcceptText();
            ld_effective_date = idw_vehiclerates.GetItem<VehicleOverrideRates>(0).VorEffectiveDate;
            // TJB  RD7_0038  Nov-2009
            // Removed nonvehiclerates save at this point; the save is done in the cb_ok_clicked event.
            //            if (StaticFunctions.IsDirty(idw_nonvehiclerates))
            //            {
            //                idw_nonvehiclerates.Save();
            //                ll_return = SUCCESS; //?
            //                if (ll_return != SUCCESS)
            //                {
            //                    return -1;
            //                }
            //            }
            //  PBY 12/06/2002 
            //  SR#4401 Do not create a frequency adjustment if
            //  the contract sequence is not the active contract sequence 
            //  (ie, if modifing override rates for a pending contract,
            //  no frequency adjustments should be created)
            li_rows = 0;
            // SELECT count(*) INTO	:li_rows 
            //   FROM contract 
            //  WHERE contract_no = :il_contract 
            //    AND con_active_sequence = :il_sequence 
            //  USING SQLCA
            RDSDataService dataService = RDSDataService.GetContractCountByNoAndSeq(il_sequence, il_contract);
            li_rows = dataService.intVal;
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Unable to determine the contract status.\n\n" 
                                 + "Error Text: " + dataService.SQLErrText
                               , "Database Error (WContractRate2001.pfc_update)"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                //? Rollback;
                return -(1);
            }
            if (li_rows <= 0)
            {
                //  This is not an active contract
                //  do not create any frequency adjustments
                //? COMMIT;
                return li_return;
            }
            n_freq = new NFrequencyAdjustment();
            n_freq.of_set_contract(il_contract, il_sequence);
            n_freq.is_reason = "New override rate entered. ";
            n_freq.of_set_effective_date(ld_effective_date);
            //  TJB SR4632 29-July-2004   - added setting is_confirmed
            n_freq.is_confirmed = "N";
            //  TJB  SR4661  May 2005
            //  Changed BenchmarkCalc subroutine name
            //  Obtain the new benchmark

            // SELECT BenchmarkCalc2005(:il_contract,:il_sequence) INTO :ldc_benchmark FROM dummy USING SQLCA;
            dataService = RDSDataService.GetBenchmarkCalc2005(il_sequence, il_contract);
            ldc_benchmark = dataService.decVal;
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Unable to calculate a new benchmark for the contract.\n\n" 
                                 + "Error Text: " + dataService.SQLErrText
                               , "Database Error (WContractRate2001.pfc_update)"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                //? Rollback;
                return -(1);
            }
            ldc_amount_to_pay = ldc_benchmark - idc_original_benchmark;
            n_freq.idc_new_benchmark = ldc_benchmark;
            n_freq.idc_amount_to_pay = ldc_amount_to_pay;
            n_freq.idc_adjustment_amount = ldc_amount_to_pay;
            li_rc = -(1);
            if (ldc_benchmark > 0)
            {
                li_rc = n_freq.of_save();
            }
            if (li_rc > 0)
            {
                //? Commit;
            }
            else
            {
                //? Rollback;
            }
            return li_return;
        }

        public virtual int dw_vehicle_rates_pfc_validation()
        {
            DateTime? ld_effective_date = null;
            DateTime? id_date_exists = null;
            decimal? ldc_benchmark;
            decimal? ldc_amount_to_pay;
            int ll_return;
            int li_rc = -(1);
            int li_rows = 0;
            DateTime? ld_upperlimitdate = null;
            int li_return = 1;

            dw_vehicle_rates.AcceptText();
            ld_effective_date = dw_vehicle_rates.GetItem<VehicleOverrideRates>(0).VorEffectiveDate;
            if (il_inserted == 1)
            {
                //  Check that the effective date entered is not already on the db
                //  PBY 25/06/2002 SR#4414 Also make sure the effective date entered
                //  is later than the previous effective date entered.
                if (!(id_previous_effective_date == null) && ld_effective_date <= id_previous_effective_date)
                {
                    MessageBox.Show("The Effective Date you have selected must be later than " 
                                     + string.Format("dd/MM/yyyy", id_previous_effective_date) + "."
                                   , "Invalid Date"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //? return -(1);
                }
                //  PBY 02/09/2002 SR#4414 also make sure effective date cannot be greater than
                //  today()+30days
                //? ld_upperlimitdate = StaticMethods.RelativeDate(System.Convert.ToDateTime(StaticVariables.gnv_app.of_gettimestamp()),30);
                if (!(id_previous_effective_date == null) && ld_effective_date > ld_upperlimitdate)
                {
                    MessageBox.Show("The Effective Date you have selected must not be later than " 
                                     + string.Format("dd/MM/yyyy", ld_upperlimitdate) + "."
                                   , "Invalid Date"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //? return -(1);
                }
                // select vor_effective_date into :id_date_exists 
                //   from vehicle_override_rate
                //  where contract_no = :il_contract 
                //    and contract_seq_number = :il_sequence
                //    and vor_effective_date = :ld_effective_date
                RDSDataService dataService = RDSDataService.GetVovEffectiveDate(ld_effective_date, il_sequence, il_contract);
                id_date_exists = dataService.dtVal;
                if (id_date_exists != null)
                {
                    MessageBox.Show("The Effective Date you have selected already exists. " 
                                     + "Please select another."
                                   , "Invalid Date"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -(1);
                }
            }
            return li_return;
        }

        public virtual void pfc_preupdate()
        {
            //? return CONTINUE_ACTION;
        }

        public virtual void dw_non_vehicle_ratesconstructor()
        {
            idw_nonvehiclerates = dw_non_vehicle_rates;
        }

        public virtual void dw_non_vehicle_rates_pfc_prermbmenu()
        {
            // Override ancestor to prevent pop menu
        }

        public virtual void dw_non_vehicle_rates_pfc_postupdate()
        {
            int ll_row;
            int? ll_rc = null;
            int ll_vor_rows;
            int ll_nvor_rows;
            DateTime? ld_effective = null;
            decimal? ldc_hourly = 0;
            decimal? ldc_public = 0;
            decimal? ldc_carrier = 0;
            decimal? ldc_acc = 0;
            decimal? ldc_item = 0;
            decimal? ldc_accounting = 0;
            decimal? ldc_telephone = 0;
            decimal? ldc_sundries = 0;
            decimal? ldc_acc_amount = 0;
            decimal? ldc_uniform = 0;
            decimal? ldc_delivery = 0;
            decimal? ldc_processing = 0;
            string ls_frozen = null;

            ll_vor_rows = idw_vehiclerates.RowCount;
            ll_nvor_rows = idw_nonvehiclerates.RowCount;
            if (ll_vor_rows >= 1)
            {
                ld_effective = idw_vehiclerates.GetItem<VehicleOverrideRates>(0).VorEffectiveDate;
            }
            if (ll_nvor_rows >= 1)
            {
                ldc_hourly = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorWageHourlyRate;
                ldc_public = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorPublicLiabilityRate2;
                ldc_carrier = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorCarrierRiskRate;
                ldc_acc = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorAccRate;
                ldc_item = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorItemProcRatePerHour;
                ls_frozen = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorFrozen;
                ldc_accounting = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorAccounting;
                ldc_telephone = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorTelephone;
                ldc_sundries = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorSundries;
                ldc_acc_amount = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorAccRateAmount;
                ldc_uniform = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorUniform;
                ldc_delivery = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorDeliveryWageRate;
                ldc_processing = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).NvorProcessingWageRate;
            }

            ll_row = ids_nonvehicleratehistory.RowCount;
            ids_nonvehicleratehistory.InsertItem<NonVehicleOverrideRateHistory>(ll_row);
            if (ll_row < 0)
            {
                MessageBox.Show("Error creating new entry for non_vehicle_override_rate_history table."
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).ContractNo = il_contract;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).ContractSeqNumber = il_sequence;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorEffectiveDate = ld_effective;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorWageHourlyRate = ldc_hourly;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorPublicLiabilityRate2 = ldc_public;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorCarrierRiskRate = ldc_carrier;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorAccRate = ldc_acc;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorItemProcRatePerHour = (int?)ldc_item;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorFrozen = ls_frozen;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorAccounting = ldc_accounting;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorTelephone = ldc_telephone;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorSundries = ldc_sundries;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorAccRateAmount = ldc_acc_amount;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorUniform = ldc_uniform;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorDeliveryWageRate = ldc_delivery;
                ids_nonvehicleratehistory.GetItem<NonVehicleOverrideRateHistory>(ll_row).NvorProcessingWageRate = ldc_processing;
                ids_nonvehicleratehistory.Save();     // NOTE: Save doesn't return a return code!
                ll_rc = (ll_rc == null) ? 0 : ll_rc;   //       This and following ll_rc stuff is irrelevant
                if (ll_rc < 0)
                {
                    MessageBox.Show("Error inserting new entry into non_vehicle_override_rate_history table. \n" 
                                     + "Row = " + ll_row + ", RC = " + ll_rc
                                   , "Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public virtual void dw_other_rates_constructor()
        {
            idw_otherrates = dw_other_rates;
        }

        #endregion

        #region Events

        public virtual void tab_override_rates_selectionchanged(object sender, EventArgs e)
        {
            //
        }

        public virtual void dw_vehicle_rates_getfocus(object sender, EventArgs e)
        {
            dw_vehicle_rates.URdsDw_GetFocus(sender, e);
            // if the datawindow retrieves a record make the datawindow readonly
            if (dw_vehicle_rates.RowCount > 0 && il_inserted != 1 && dw_vehicle_rates.GetItem<VehicleOverrideRates>(0).VorEffectiveDate != null/*System.Convert.ToDateTime("00/00/0000")*/)
            {
                foreach (Control var in dw_vehicle_rates.DataObject.Controls)
                {
                    if (var is TextBox)
                    {
                        ((TextBox)var).ReadOnly = true;
                    }
                    else if (var is MaskedTextBox)
                    {
                        ((MaskedTextBox)var).ReadOnly = true;
                    }
                }
            }
            // TJB  RD7_0038  Nov-2009:  Added to enable updates
            else
            {
                foreach (Control var in dw_vehicle_rates.DataObject.Controls)
                {
                    if (var is TextBox)
                    {
                        ((TextBox)var).ReadOnly = false;
                    }
                    else if (var is MaskedTextBox)
                    {
                        ((MaskedTextBox)var).ReadOnly = false;
                    }
                }
            }
        }

        public virtual void dw_vehicle_rates_itemchanged(object sender, EventArgs e)
        {
            dw_vehicle_rates.URdsDw_Itemchanged(sender, e);
            // Set the contract_no and the contract_seq_no
            // tab_override_rates.tabpage_vehicle_rates.dw_vehicle_rates.SetItem(1, "Contract_no", il_contract)
            // tab_override_rates.tabpage_vehicle_rates.dw_vehicle_rates.SetItem(1, "Contract_seq_number", il_sequence)
            idw_vehiclerates.GetItem<VehicleOverrideRates>(0).ContractNo = il_contract;
            idw_vehiclerates.GetItem<VehicleOverrideRates>(0).ContractSeqNumber = il_sequence;
            // calculate allowance
            decimal? ldec_SalvageRatio;
            decimal? ldec_NominalVehical;
            dw_vehicle_rates.AcceptText();
            Metex.Core.EntityBase row = idw_vehiclerates.GetItem<VehicleOverrideRates>(0);
            if (row.IsDirty)
            {
                ldec_SalvageRatio = idw_vehiclerates.GetItem<VehicleOverrideRates>(0).VorSalvageRatio;
                ldec_NominalVehical = idw_vehiclerates.GetItem<VehicleOverrideRates>(0).VorNominalVehicleValue;
                idw_vehiclerates.GetItem<VehicleOverrideRates>(0).VorVehicalAllowanceRate = ldec_SalvageRatio == null ? ldec_SalvageRatio : System.Math.Round(((1 - ldec_SalvageRatio / 100) * ldec_NominalVehical * 1000 / il_economiclife).GetValueOrDefault(), 2);
                idw_vehiclerates.DataObject.BindingSource.CurrencyManager.Refresh();
            }
        }

        public virtual void dw_non_vehicle_rates_getfocus(object sender, EventArgs e)
        {
            dw_non_vehicle_rates.URdsDw_GetFocus(sender, e);
            //  TJB SR4586 28-July-2004
            //  cb_newrates sets il_inserted.  
            //  If set, turn readonly off to allow changes
            if (il_inserted != 1)
            {
                foreach (Control var in dw_non_vehicle_rates.DataObject.Controls)
                {
                    if (var is TextBox)
                    {
                        ((TextBox)var).ReadOnly = true;
                    }
                    else if (var is MaskedTextBox)
                    {
                        ((MaskedTextBox)var).ReadOnly = true;
                    }
                }
            }
            else
            {
                foreach (Control var in dw_non_vehicle_rates.DataObject.Controls)
                {
                    if (var is TextBox)
                    {
                        ((TextBox)var).ReadOnly = false;
                    }
                    else if (var is MaskedTextBox)
                    {
                        ((MaskedTextBox)var).ReadOnly = false;
                    }
                }
            }
        }

        public virtual void dw_non_vehicle_rates_itemchanged(object sender, EventArgs e)
        {
            dw_non_vehicle_rates.URdsDw_Itemchanged(sender, e);
            //  TJB SR4586 28-July-2004
            //      Moved from editchanged 
            //  TJB  SR4695  Feb-2007
            //  Removed.  Contract details set when NVOR record created
            // Set the contract_no and the contract_seq_no
            //  tab_override_rates.tabpage_non_vehicle_rates.dw_non_vehicle_rates.SetItem(1, "Contract_no", gnv_App.of_Get_Parameters().longparm)
            //  tab_override_rates.tabpage_non_vehicle_rates.dw_non_vehicle_rates.SetItem(1, "Contract_seq_number", gnv_App.of_Get_Parameters().integerparm)
        }

        public virtual void dw_other_rateseditchanged(object sender, EventArgs e)
        {
            // Set the contract_no and the contract_seq_no
            dw_other_rates.GetItem<OtherOverrideRates>(0).ContractNo = (int?)StaticMessage.LongParm;
            dw_other_rates.GetItem<OtherOverrideRates>(0).ContractSeqNumber = StaticMessage.IntegerParm;
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4661  May 2005
            //  Added update of nvor_wage_hourly_rate from (new)
            //  nvor_processing_wage_rate 'just in case' the user
            //  has changed it (they're supposed to be identical)
            int ll_rc, ll_row;
            int? ll_temp;

            idw_vehiclerates.AcceptText();
            idw_nonvehiclerates.AcceptText();
            idw_otherrates.AcceptText();
            //  Only do the update if the row is marked modified (whether or not 
            //  the processing wage was changed). If you copy the processing wage 
            //  to the hourly wage "just in case" you'll mark the record modified 
            //  and set up a potential unwanted save (the user will always be asked 
            //  about saving because the vehicle override window has been modified 
            //  with today's date as the 'new' effective date).

            ll_rc = 0;
            if (StaticFunctions.IsDirty(idw_nonvehiclerates))
            {
                ll_row = idw_nonvehiclerates.GetRow();
                ll_temp = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(ll_row).ContractNo;
                if (ll_temp == null)
                {
                    idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(ll_row).ContractNo = il_contract;
                    idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(ll_row).ContractSeqNumber = il_sequence;
                }
                // TJB  Release 7.1.1 fixup  Dec-2009
                // The idw_vehiclerates.Save() creates the frequency adjustment record and
                // must go last, otherwise any non-vehicle rate changes won't be reflected
                // in the frequency adjustments.
                ll_rc = idw_nonvehiclerates.Save();
            }

            if (StaticFunctions.IsDirty(idw_vehiclerates))
            {
                ll_rc = idw_vehiclerates.Save();
            }
            if (ll_rc >= 0)
            {
                senderName = "OK";
                this.Close(); // close(parent)
            }
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            // //Save Changes
            // If idw_vehiclerates.Update() >0 Then
            // 	If idw_nonvehiclerates.Update() > 0 Then
            //  		If tab_override_rates.tabpage_other_rates.dw_other_rates.Update()>0 Then
            // 		End If 
            // 	End If
            // End If
            // 
            //  TJB  SR4661  May 2005
            //  Fix the cancel function.
            //  Clear any changes before closing to stop the 
            //  pfc function asking if you'd like to save them.
            senderName = "Cancel";
            idw_vehiclerates.Reset();
            idw_nonvehiclerates.Reset();
            idw_otherrates.Reset();
            this.Close();
        }

        public virtual void cb_newrates_clicked(object sender, EventArgs e)
        {
            /***********************************************************************
                Purpose: NewOverrideRate button clicked event
                Revision History:
                Date     	Initials		Description
                ??/??/????	???			Initial version
                13/02/2002	PBY			Support Request #4334
                Instead of inserting a new row, reuse the existing
                to retain the original value.  Change the row
                status to New! to enable insert later.
            ********************************************************************** */
            int ll_rc;
            string ls_msg;
            string ls_rc;
            DateTime? ld_effective_date;
            //  TJB  SR4695  Jan-2007
            //  updating override rates is allowed only for non-terminated contracts
            if (of_isterminated(il_contract))
            {
                MessageBox.Show("This contract has been terminated.  \n" 
                                 + "New override rates may not be added."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //  TJB SR4632 29-Jul-2004
            //  Added 'Note:' to message.
            ls_msg = "Inserting new Vehicle Override Rates will effect the Benchmark Calculation.";
            ls_msg = ls_msg + "\nNote: the resulting frequency adjustment needs to be confirmed separately.   ";
            ls_msg = ls_msg + "\nDo you wish to continue?";
            DialogResult answer;
            answer = MessageBox.Show(ls_msg
                               , "Inserting new rates"
                               , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
            {
                il_inserted = 1;
                /*  
                    13-Feb-2002 PBY commented out
                    idw_vehiclerates.reset()
                    idw_vehiclerates.InsertRow(1)
                    idw_vehiclerates.setitem(1, "vor_effective_date", today())
                 */
                //  TJB  SR4695  Feb-2007
                //  If there's no previous VOR for today the effective date 
                //  defaults to today.
                //  If there's already a route extension for the default route for today 
                //  there is a frequency_adjustment for today.  
                //  When the VOR is saved, the frequency_adjustment effective date
                //  conflicts with the extension FA's effective date, and the code 
                //  (in n_frequency_adjustment.of_set_effective_date) changes the FA 
                //  effective date by -1 day(!!) making the FA's effective date 
                //  different than the VOR's.
                // 
                //  Changed code to check for this conflict and set the effective
                //  date so that the frequency_adjustment, frequency_distances, VOR,
                //  and NVOR_history tables' effective dates can all be the same.  If
                //  this date is not the same as the default VOR effective date, 
                //  warn the user.
                DateTime? ld_default_eff_date;
                DateTime? ld_next_eff_date;
                ll_rc = idw_vehiclerates.ResetUpdate();
                // * IF IsNull(id_previous_effective_date) OR today() > id_previous_effective_date THEN
                // *	ll_rc = idw_vehiclerates.setitem(1,"vor_effective_date",today())
                // * ELSE
                // *	ll_rc = idw_vehiclerates.setitem(1,"vor_effective_date",StaticMethods.RelativeDate( id_previous_effective_date,1))
                // * END IF
                if (id_previous_effective_date == null || System.DateTime.Today > id_previous_effective_date)
                {
                    ld_default_eff_date = System.DateTime.Today;
                }
                else
                {
                    ld_default_eff_date = id_previous_effective_date.Value.AddDays(1);
                }
                ld_next_eff_date = of_get_next_fa_date(il_contract, il_sequence, ld_default_eff_date);
                if (ld_next_eff_date == null)
                {
                    return;
                }
                idw_vehiclerates.GetItem<VehicleOverrideRates>(0).VorEffectiveDate = ld_next_eff_date;
                idw_vehiclerates.GetItem<VehicleOverrideRates>(0).marknew(); // new!
                idw_vehiclerates.DataObject.BindingSource.CurrencyManager.Refresh();
                //  Re-activate the datawindow for input
                idw_vehiclerates.Enabled = true;
                // TJB SR4586 28-July-2004
                //        Add management of non-vehicle overrides
                //  Set up the non-vehicle override rates for update
                // TJB  RD7_0038  Nov-2009
                //   Add code to set up an insert or update of the non_vehicle_override_rate table
                int? t_contract = idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).ContractNo;
                if (t_contract == null)
                {
                    idw_nonvehiclerates.GetItem<NonVehicleOverrideRates>(0).marknew();
                    idw_nonvehiclerates.DataObject.BindingSource.CurrencyManager.Refresh();
                }
                else
                {
                    idw_nonvehiclerates.ResetUpdate();
                } 
                idw_nonvehiclerates.Enabled = true;
            }
            cb_ok.Focus();
        }

        protected override void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (senderName == "")
            {
                // TJB  RD7_0038  Nov-2009:  Added warning when user closes window
                if (StaticFunctions.IsDirty(idw_vehiclerates) || StaticFunctions.IsDirty(idw_nonvehiclerates))
                {
                    MessageBox.Show("Changes have not been saved.","Warning"
                                   ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                return;
            }
            if (senderName != "OK" && senderName != "Cancel")
            {
                base.FormBase_FormClosing(null, null);
            }
            pfc_preclose();
        }
        #endregion

    }
}