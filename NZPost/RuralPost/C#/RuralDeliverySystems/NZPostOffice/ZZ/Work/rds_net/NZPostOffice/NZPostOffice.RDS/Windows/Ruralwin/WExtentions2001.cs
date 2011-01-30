using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Windows.Ruralwin2;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public partial class WExtentions2001 : WAncestorWindow
    {
        // TJB Oct-2010: 
        // Changed benchmark report to BenchmarkReport2010 (was 2006)

        #region Define

        public int iltravellingspeed = 50;

        public decimal? ilcustomerdeliverytime = (decimal)25.0 / 60 / 60;

        public URdsDw dw_extension;

        public DataUserControl dw_benchmark_report;

        #endregion

        public WExtentions2001()
        {
            this.InitializeComponent();

            this.dw_ext.DataObject = new DExtension2005();
            this.dw_ext.DataObject.BorderStyle = BorderStyle.Fixed3D;

            this.dw_contract.DataObject = new DContractNoEntry2001();
            this.dw_contract.DataObject.BorderStyle = BorderStyle.Fixed3D;

            this.dw_bm.DataObject = new NZPostOffice.RDS.DataControls.Ruralrpt.RBenchmarkReport2010();
            //this.dw_bm.DataObject.BorderStyle = BorderStyle.None;

            this.dw_ext.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_ext_constructor);
            this.dw_ext.PfcUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate1(this.dw_ext_pfc_update);
            this.dw_ext.PfcPostUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_ext_pfc_postupdate);
            //this.dw_ext.UpdateStart += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_ext_updatestart);
            ((DExtension2005)this.dw_ext.DataObject).TextBoxLostFocus += new EventHandler(this.dw_ext_itemchanged);
            ((DExtension2005)this.dw_ext.DataObject).extn_effective_date_change += new System.ComponentModel.CancelEventHandler(WExtentions2001_extn_effective_date_change);

            this.dw_bm.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_bm_constructor);
            this.dw_contract.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_contract_constructor);
            dw_contract.GotFocus += new EventHandler(dw_contract_getfocus);
        }

        public override int closequery()
        {
            if (!(wf_update(false)))
            {
                StaticMessage.ReturnValue = 1;
                return 1;
            }
            return 0;
        }

        public override void open()
        {
            base.open();
            //? dw_contract.settransobject(StaticVariables.sqlca);
            dw_contract.InsertItem<ContractNoEntry2001>(-1);
            dw_contract.GetControlByName("contract_no").Focus();
            // declare - speeds up next SQL stmt 10/2/98 Rex B as part of the performance improvements
            // authorised by NZ Post
            // DECLARE conproc procedure for rd.sp_Extension_Deliverytime;
            //  PBY 13/11/2002 #4469 Commented out
            // if sqlca.sqlcode < 0 then
            // 	messagebox ( "Fetch procedure error",sqlca.sqlerrtext)
            // end if
            //? execute conproc ;
            RDSDataService dataService = RDSDataService.SpExtensionDeliveryTime();
            if (dataService.SQLCode < 0)
            {
                MessageBox.Show(dataService.SQLErrText
                               , "Execute procedure error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //? fetch conproc INTO   :iltravellingspeed, :ilcustomerdeliverytime;
            iltravellingspeed = dataService.intVal;
            ilcustomerdeliverytime = dataService.decVal;
            if (dataService.SQLCode < 0)
            {
                MessageBox.Show(dataService.SQLErrText
                               , "Fetch procedure error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //? CLOSE conproc
            // Speed this up:
            // SELECT del_hours_variables.dhv_travelling_speed,   
            //        del_hours_variables.dhr_seconds_customer
            // INTO :iltravellingspeed,   
            //      :ilcustomerdeliverytime  
            // FROM del_hours_variables  ;
            ilcustomerdeliverytime = ilcustomerdeliverytime / 60 / 60;

        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Extensions");
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            tabpage_2.Enabled = false; //pp! as Enabled property does nothing added code to disable in tab_1_SelectedIndexChanged
        }

        #region Methods

        public virtual void pfc_dberror()
        {
            // 
        }

        public virtual bool wf_update(bool aautomatic)
        {
            bool bReturn = true;
            Cursor.Current = Cursors.WaitCursor;
            dw_extension.AcceptText();
            if (StaticFunctions.IsDirty(dw_extension))
            {
                if (!aautomatic)
                {
                    // PowerBuilder 'Choose Case' statement converted into 'if' statement
                    DialogResult TestExpr 
                        = MessageBox.Show("Do you want to update the database?"
                                         , this.Text
                                         , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (TestExpr == DialogResult.Cancel)
                    {
                        return false;
                    }
                    else if (TestExpr == DialogResult.No)
                    {
                        return true;
                    }
                    else if (TestExpr == DialogResult.Yes)
                    {
                        bReturn = wf_addextn() == 0;
                    }
                }
                else
                {
                    bReturn = wf_addextn() == 0;
                }
            }
            // if bReturn and aAutomatic then
            // 	close ( this)
            // end if
            if (bReturn)
            {
                //? dw_extension.of_protectcolumns();
            }
            return bReturn;
        }

        public virtual int wf_addextn()
        {
            DateTime? dEffectiveDate;
            int? lContract;
            int? lSFKey;
            string sDeliveryDays;
            decimal? dDistance;
            int? lNoBoxes;
            int? lNoRuralBags;
            int? lNoOtherBags;
            int? lNoPrivateBags;
            int? lNoPostOffices;
            int? lNoCMBS;
            int? lNoCMBCustomers;
            int? lVolume;
            int? lSequence;
            int? lNextSeq = null;
            decimal? dBenchmark;
            decimal? dAmountToPay;
            int? iReturn = 0;
            int? iEfCount = 0;
            string sReason;
            decimal? decDelHrs;
            decimal? decProcHrs;
            int lCount = 0;
            dEffectiveDate = dw_extension.GetItem<Extension2005>(0).ExtnEffectiveDate;
            lContract = dw_contract.GetItem<ContractNoEntry2001>(0).ContractNo;
            lSFKey = dw_contract.GetItem<ContractNoEntry2001>(0).SfKey;
            sDeliveryDays = dw_contract.GetItem<ContractNoEntry2001>(0).RfDeliveryDays;
            // Rex
            //? SqlConnection MyTrans;
            //? MyTrans = new SqlConnection();
            //? MyTrans = StaticVariables.sqlca;
            /* select count ( *)
                into :lCount
                from contract join contract_renewals
                on contract.contract_no = contract_renewals.contract_no
                and contract.con_active_sequence = contract_renewals.contract_seq_number
                where :dEffectiveDate between contract_renewals.con_start_date and contract_renewals.con_expiry_date
                and contract.contract_no = :lContract; */
            RDSDataService dataService = RDSDataService.GetContractCountWithRenewals(dEffectiveDate, lContract);
            lCount = dataService.intVal;
            //  TJB  SR4695  Jan-2007
            //  Modified SQL error messages to identify which statement generated the error
            if (dataService.SQLCode == -(1))
            {
                MessageBox.Show("Counting contracts\n\n" + dataService.SQLErrText
                               , "w_extentions2001.wf_addextn: Database error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (lCount != 1)
            {
                MessageBox.Show("The extension effective date is outside the current contracts start and end dates.\n" 
                                   + "Please change the effective date before saving the extension"
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -(1);
            }
            dDistance = dw_extension.GetItem<Extension2005>(0).ExtnDistance;
            lNoBoxes = dw_extension.GetItem<Extension2005>(0).ExtnBoxes;
            lNoRuralBags = dw_extension.GetItem<Extension2005>(0).ExtnRuralBags;
            lNoOtherBags = dw_extension.GetItem<Extension2005>(0).ExtnOtherBags;
            lNoPrivateBags = dw_extension.GetItem<Extension2005>(0).ExtnPrivateBags;
            lNoPostOffices = dw_extension.GetItem<Extension2005>(0).ExtnPostOffices;
            lNoCMBS = dw_extension.GetItem<Extension2005>(0).ExtnNoCmbs;
            lNoCMBCustomers = dw_extension.GetItem<Extension2005>(0).ExtnNoCmbCustomers;
            lVolume = (int?)dw_extension.GetItem<Extension2005>(0).VolumeChange;
            sReason = dw_extension.GetItem<Extension2005>(0).ExtnReason;
            if (StaticVariables.gnv_app.of_isempty(sReason))
            {
                MessageBox.Show("The reason for this extension has to be entered before it can be saved to the database."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -(1);
            }
            decDelHrs = dw_extension.GetItem<Extension2005>(0).ExtnDelHrs;
            decProcHrs = dw_extension.GetItem<Extension2005>(0).ProcHrsChange;
            /* select count (*)
                into :iEfCount
                from frequency_distances
                where contract_no 		 =	:lContract			
                and sf_key				 =	:lSFKey				
                and rf_delivery_days	 =	:sDeliveryDays		
                and fd_effective_date =	:dEffectiveDate; */
            dataService = RDSDataService.GetFreqDistCount(dEffectiveDate, lContract, lSFKey, sDeliveryDays);
            iEfCount = dataService.intVal;
            if (dataService.SQLCode == -(1))
            {
                MessageBox.Show("Counting frequency_distances\n\n" 
                                   + dataService.SQLErrText
                                , "w_extentions2001.wf_addextn: Database error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (iEfCount > 0)
            {
                MessageBox.Show("You cannot add this extension to the database because there is already \n"
                                    + "an extension for this frequency defined for this effective date"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                //? rollback;
                return -(1);
            }
            /* 
            insert into frequency_distances
                 ( fd_effective_date,
                contract_no,
                sf_key,
                rf_delivery_days,
                fd_distance,
                fd_no_of_boxes,
                fd_no_rural_bags,
                fd_no_other_bags,
                fd_no_private_bags,
                fd_no_post_offices,
                fd_no_cmbs,
                fd_no_cmb_customers,
                fd_volume,
                fd_change_reason,
                fd_delivery_hrs_per_week,
                fd_processing_hrs_week)
                values
                 ( :dEffectiveDate,
                :lContract,
                :lSFKey,
                :sDeliveryDays,
                :dDistance,
                :lNoBoxes,
                :lNoRuralBags,
                :lNoOtherBags,
                :lNoPrivateBags,
                :lNoPostOffices,
                :lNoCMBS,
                :lNoCMBCustomers,
                :lVolume,
                :sReason,
                :decDelHrs,
                :decProcHrs); */
            dataService = RDSDataService.InsertIntoFreqDist(lNoOtherBags, lVolume, lNoRuralBags, lNoCMBCustomers, dEffectiveDate,
                lNoCMBS, lNoPostOffices, decDelHrs, sReason, dDistance, lNoPrivateBags, lSFKey, sDeliveryDays, lNoBoxes, lContract, decProcHrs);
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("Inserting into frequency_distances\n\n" 
                                    + dataService.SQLErrText
                               , "w_extentions2001.wf_addextn: Database error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                //? rollback;
                iReturn = -(1);
            }
            else
            {
                /* UPDATE route_frequency set rf_distance = rf_distance + :dDistance  
                    where contract_no = :lContract
                    and sf_key = :lSFKey 
                    and rf_delivery_days = :sDeliveryDays; */
                dataService = RDSDataService.UpdateRouteFreqRfDist(lContract, dDistance, lSFKey, sDeliveryDays);
                if (dataService.SQLCode == -(1))
                {
                    MessageBox.Show("Updating route_frequency\n\n" 
                                       + dataService.SQLErrText
                                   , "w_extentions2001.wf_addextn: Database error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                /* select max(contract_seq_number) into :lSequence  
                   from contract_renewals
                   where contract_no = :lContract; */
                dataService = RDSDataService.GetMaxContractRenewalsSeqNumber(lContract);
                lSequence = dataService.intVal;
                if (dataService.SQLCode == -(1))
                {
                    MessageBox.Show("Determining max(contract_seq_number)\n\n" 
                                       + dataService.SQLErrText
                                   , "w_extentions2001.wf_addextn: Database error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                /* select max(fd_unique_seq_number) into :lNextSeq
                   from frequency_adjustments 
                   where contract_no = :lContract and contract_seq_number = :lSequence; */
                dataService = RDSDataService.GetMaxFreqAdjustmentsSeqNumber(lSequence, lContract);
                lNextSeq = dataService.intVal;
                if (dataService.SQLCode == -(1))
                {
                    MessageBox.Show("Determining max(fd_unique_seq_number)\n\n" 
                                       + dataService.SQLErrText
                                   , "w_extentions2001.wf_addextn: Database error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lNextSeq = (lNextSeq == null) ? 1 : lNextSeq + 1;
                
                //if (lNextSeq == null)
                //{
                //   lNextSeq = 1;
                //}
                //else
                //{
                //    lNextSeq++;
                //}
                dBenchmark = dw_extension.GetItem<Extension2005>(0).Extnamnt;
                dAmountToPay = dw_extension.GetItem<Extension2005>(0).Extnamount;
                //  Changing the recalc amount to be the benchmark difference from the database
                //? dw_extension.GetItem<Extension2005>(0).Extnamnt = this.of_recalc_adjust();
                //  TJB  SR4661  May 2005
                //  Changed benchmarkCalc stored procedure name
                //  TJB  SR4695  Jan-2007
                //  Added sf_key and rf_delivery_days insert 
                //   (new columns in table to link to frequency_distances)
                /* INSERT INTO frequency_adjustments 
                 *     (contract_no, contract_seq_number, fd_unique_seq_number,   
                 *      fd_adjustment_amount, fd_paid_to_date, fd_bm_after_extn,   
                 *      fd_confirmed, fd_amount_to_pay, fd_effective_date, sf_key, rf_delivery_days)  
                 *  VALUES 
                 *     (:lContract, :lSequence, :lNextSeq, :dBenchmark, null, BenchmarkCalc2005(:lContract, :lSequence),
                 *      'N', :dAmountToPay, :dEffectiveDate, :lSFKey, :sDeliveryDays)  ; */
                dataService = RDSDataService.InsertFreqAdjustments(dBenchmark, lNextSeq, dEffectiveDate, lSequence, lSFKey, sDeliveryDays, dAmountToPay, lContract);
                if (dataService.SQLCode == -(1))
                {
                    MessageBox.Show("Inserting into frequency_adjustments\n\n" 
                                       + dataService.SQLErrText
                                   , "w_extentions2001.wf_addextn: Database error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //? commit;
                if (MessageBox.Show("Do you want a benchmark report produced of the current contract?"
                                   , this.Text
                                   , MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Question) 
                         == DialogResult.Yes)
                {
                    ((NZPostOffice.RDS.DataControls.Ruralrpt.RBenchmarkReport2010)dw_benchmark_report).Retrieve(lContract, lSequence);
                    dw_benchmark_report.Visible = true;
                    // 	cb_search.Visible=false
                    // 	dw_contract.Visible=false
                    // 	dw_extension.Visible=false
                    // 	st_showcalc.Visible=false
                    cb_print.Visible = true;

                    tab_1.TabPages[1].Enabled = true;//pp! added to make TabIndexChanged event handler work
                    Enabled = true;

                    tab_1.SelectedIndex = 1;
                    //? dw_benchmark_report.Modify("datawindow.print.preview.zoom=" + 90).ToString();
                    // 	dw_benchmark_report.print ( )
                }
                dw_extension.ResetUpdate();
                dw_ext.Enabled = false;
            }
            return (int)iReturn;
        }

        public override int wf_saveas()
        {
            //? dw_extension.SaveAs();
            return 0;
        }

        public virtual int of_recalc_adjust()
        {
            //  Tim Chan 12/05/2003
            //  this function will recalculate the adjustment amount
            decimal? ld_prev = 0;
            decimal? ld_new = 0;
            decimal? ld_adjust = 0;
            int? li_contract;
            int? li_seq;
            li_contract = dw_contract.GetItem<ContractNoEntry2001>(0).ContractNo;
            //  get the previous benchmark

            // SELECT get_prev_bench(:li_contract) INTO :ld_prev FROM sys.dummy;
            RDSDataService dataService = RDSDataService.GetPrevBench(li_contract);
            ld_prev = dataService.decVal;

            // select max(contract_seq_number) into :li_seq from contract_renewals where contract_no = :li_contract;
            dataService = RDSDataService.GetMaxContractRenewals(li_contract);
            li_seq = dataService.intVal;
            //  TJB  SR4661  May 2005
            //  Changed benchmarkCalc stored proc name

            // SELECT BenchmarkCalc2005 ( :li_contract, :li_seq) INTO :ld_new FROM sys.dummy;
            dataService = RDSDataService.GetBenchmarkCalc2005(li_seq, li_contract);
            ld_new = dataService.decVal;
            ld_adjust = ld_new - ld_prev;
            return (int)ld_adjust;
        }

        public virtual void dw_ext_ue_reenter_amount()
        {
                // TJB  20-Jul-2009  RD7_0033: Extentions fixes
                // Split the assignment into parts to see what's going on
                // Changed method of assignment (probably made no difference)
            decimal? dExtnamnt;
            
            //dw_ext.SetValue(0, "extnamount", dw_ext.GetItem<NZPostOffice.RDS.Entity.Ruraldw.Extension2005>(0).Extnamnt);
            dExtnamnt = (decimal)dw_ext.GetItem<Extension2005>(0).Extnamnt;
            dw_ext.GetItem<Extension2005>(0).Extnamount = dExtnamnt;
        }

        public virtual void dw_ext_ue_dwnprocessenter()
        {
            //? return 1;
        }

        public virtual void dw_ext_updatestart()
        {
            //? return 1;
        }

        public virtual void dw_ext_constructor()
        {
            BeginInvoke(new delInvoke(constructInvoke));
            dw_extension = dw_ext;
        }

        private delegate void delInvoke();

        public virtual void constructInvoke()
        {
            dw_ext.of_set_createpriv(false);
            dw_ext.of_set_deletepriv(false);
            dw_ext.of_set_modifypriv(true);

            dw_ext.URdsDw_GetFocus(null, null);//added by jlwang
        }

        public virtual int dw_ext_pfc_update()
        {
            if (wf_update(true))
            {
                return 1;
            }
            else
            {
                return -(1);
            }
        }

        public virtual void dw_ext_pfc_postupdate()
        {
            //?dw_ext.of_SetUpdateable(false);
            //? return ancestorreturnvalue;
        }

        public virtual void dw_bm_constructor()
        {
            //  TJB  SR4661  May 2005
            //  Changed to use r_benchmark_report2005
            //  TJB  SR4684  June 2006
            //  Changed to use r_benchmark_report2006
            dw_benchmark_report = dw_bm.DataObject;
            dw_bm.of_SetUpdateable(false);
        }

        public virtual void dw_contract_constructor()
        {
            //jlwang:does not need this set
            dw_contract.of_SetUpdateable(false);
            this.dw_contract_getfocus(null, null);
        }
        #endregion

        #region Events
        public void WExtentions2001_extn_effective_date_change(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string extn_date_text = dw_ext.GetControlByName("extn_effective_date").Text;
                // TJB  15-Jul-2009   RD7_0033
                //     Added this test.  If an invalid date is entered, the entry field
                //     validation replaces the value entered with "00/00/0000".
            if ( extn_date_text == "00/00/0000" )
            {
                MessageBox.Show("Invalid date entered.  Please re-enter the effective date."
                               , "Warning");
                e.Cancel = true;
            }

            if (dw_ext.RowCount > 0)//pp! added condition or of nor row there is exception
            {
                try
                {
                    if (!(StaticVariables.gnv_app.of_sanedate(System.Convert.ToDateTime(extn_date_text), "effective date")))
                    {
                        e.Cancel = true;
                        // TJB  15-Jul-2009  RD7_0033
                        //    Changed value set in extn_effective_date.  Commented out setting
                        //    includes a time as part of the string.
                        // dw_ext.GetControlByName("extn_effective_date").Text = dw_ext.GetItem<Extension2005>(0).ExtnEffectiveDate.ToString();
                        dw_ext.GetControlByName("extn_effective_date").Text = extn_date_text;
                        dw_ext.DataObject.BindingSource.CurrencyManager.Refresh();
                        return;//?2;
                    }
                }
                catch (Exception ex)
                {
                    dw_ext.GetControlByName("extn_effective_date").Text = dw_ext.GetItem<Extension2005>(0).ExtnEffectiveDate.ToString();
                }
            }
        }

        public virtual void doubleclicked(object sender, EventArgs e)
        {
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyCtrl) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyShift))
            {
                st_showcalcs.Visible = true;
                //  this.maxbox = true
                // 	cb_showcalcs.Visible=true
                dw_extension.HorizontalScroll.Visible = true;// hscrollbar = true;
            }
        }

        public override void resize(object sender, EventArgs args)
        {
            base.resize(sender, args);
            // this.setRedraw ( false)
            //tab_1.Width = this.Width - 21;
            //tab_1.Width = this.Height - 40;
            //if (dw_bm != null)
            //
            //  dw_bm.Width = this.Width - 40;
            //  dw_bm.Height = this.Height - 112;
            //
            //cb_print.Top = this.Height - 95;
            //cb_print.Left = this.Width - 114;
        }

        //pp! code to disable tab pages
        void tab_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_1.SelectedIndex == 0)
                dw_ext.Focus();
            if (tabpage_2.Enabled == false)//! Enabled property does nothing, so it needs extra code to disable the second tab
            {
                if (this.tab_1.SelectedTab == this.tab_1.TabPages[1])
                {
                    this.tab_1.SelectedTab = this.tab_1.TabPages[0];
                }
            }
        }

        public virtual void cb_search_clicked(object sender, EventArgs e)
        {
            this.SuspendLayout();
            int? lContract;
            int lCount = 0;
            int lDaysYear = 0;
            string stype;
            decimal? decDistance = 0;
            if (dw_extension.RowCount > 0)
            {
                dw_extension.Focus();
                this.ResumeLayout(false);
                return;
            }
            dw_contract.AcceptText();
            lContract = dw_contract.GetItem<ContractNoEntry2001>(0).ContractNo;
            // declare - Some embedded SQL Statements here transferred to stored procs-  
            // 10/2/98 Rex B as part of the performance improvements
            // authorised by NZ Post
            // 1. See if contract exists
            // if g_Security.Access_Groups[3] = 4 then stype='1' else stype='0'
            // Rex migrate
            // long ll_region
            // ll_region
            int? ll_rc_id;
            string ls_ui_userid;
            ll_rc_id = StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid("Extensions");
            ls_ui_userid = StaticVariables.LoginId;
            /* DECLARE conproc2 procedure for rd.sp_Extension_CustCount2
                inContract = :lContract,
                inComponentId = :ll_rc_id,
                inUIUserId=:ls_ui_userid; */
            RDSDataService dataService = RDSDataService.SpExtensionCustCount2(ls_ui_userid, lContract, ll_rc_id);
            if (dataService.SQLCode < 0)
            {
                this.ResumeLayout(false);
                MessageBox.Show(dataService.SQLErrText
                               , "Declare procedure error - sp_Extension_CustCount"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // execute conproc2 ;
            if (dataService.SQLCode < 0)
            {
                this.ResumeLayout(false);
                MessageBox.Show(dataService.SQLErrText
                               , "Execute procedure error- sp_Extension_CustCount"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                //? CLOSE conproc2
                return;
            }
            // fetch conproc2 INTO   :lCount;
            lCount = dataService.intVal;
            if (dataService.SQLCode < 0)
            {
                this.ResumeLayout(false);
                //? CLOSE conproc2
                MessageBox.Show(dataService.SQLErrText
                               , "Fetch procedure error - sp_Extension_CustCount"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //? CLOSE conproc2
            if (lCount == 0)
            {
                this.ResumeLayout(false);
                MessageBox.Show("The entered contract number does not exist on the database,\n" 
                                  + "or you do not have the authority to apply an extension to it."
                                , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // check if renewed under new rules
                /* SELECT count(*) into  :lCount FROM non_vehicle_rate, contract_renewals, contract  
                    WHERE contract.contract_no = contract_renewals.contract_no  
                    and contract.rg_code = non_vehicle_rate.rg_code  
                    and contract_renewals.con_rates_effective_date = non_vehicle_rate.nvr_rates_effective_date  
                    and contract.contract_no = :lContract; */
                dataService = RDSDataService.GetContractCountByRenewalAndRgCode(lContract);
                lCount = dataService.intVal;
                if (lCount == 0)
                {
                    this.ResumeLayout(false);
                    if (MessageBox.Show("This contract has not been renewed under 2001 benchmark specifications.\n" 
                                          + "Extension amount may not be calculated.\n" 
                                          + "Continue with the extension?"
                                        , "Extension"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                        , MessageBoxDefaultButton.Button2) 
                        == DialogResult.No)
                    {
                        return;
                    }
                    // dw_extension.uf_protect ( )
                }
                // See if there is a pending renewal
                /* DECLARE conproc1 procedure for rd.sp_GetCurrentrenewal
                    inContract = :lContract; */
                if (dataService.SQLCode < 0)
                {
                    this.ResumeLayout(false);
                    MessageBox.Show(dataService.SQLErrText
                                   , "Declare procedure error - sp_GetCurrentrenewal"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //? CLOSE conproc1
                    return;
                }
                //? execute conproc1 ;
                dataService = RDSDataService.SpGetCurrentRenewal(lContract);
                if (dataService.SQLCode < 0)
                {
                    this.ResumeLayout(false);
                    MessageBox.Show(dataService.SQLErrText
                                   , "Execute procedure error - sp_GetCurrentrenewal"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //? CLOSE conproc1
                    return;
                }
                //? fetch conproc1 INTO :lCount;
                lCount = dataService.intVal;
                if (dataService.SQLCode < 0)
                {
                    this.ResumeLayout(false);
                    MessageBox.Show(dataService.SQLErrText
                                   , "Fetch procedure error - sp_GetCurrentrenewal"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //? CLOSE conproc1
                    return;
                }
                //? CLOSE conproc1
                if (lCount > 0)
                {
                    MessageBox.Show("This contract has a pending renewal. An extension cannot be run against this contract."
                                   , this.Text
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // TJB  RD7_0051  Oct2009
                    // Added to allow new contract to be selected
                    return;
                }
                else
                {
                    StaticVariables.gnv_app.of_get_parameters().longparm = lContract;
                    WSelectFrequency w_select_frequency = new WSelectFrequency();
                    w_select_frequency.ShowDialog();
                    string test = StaticVariables.gnv_app.of_get_parameters().stringparm;
                    string t = test;

                    if (StaticVariables.gnv_app.of_get_parameters().stringparm == "NotFound")
                    {
                        // TJB  RD7_0051  Oct2009
                        // Added == NotFound to allow new contract to be selected
                        return;
                    }
                    else
                    {
                        // Get days per annum
                        int? ll_key;
                        ll_key = StaticVariables.gnv_app.of_get_parameters().integerparm;
                        /* DECLARE conproc3 procedure for rd.sp_Extension_DaysPerAnnum
                            inContract = :lContract,
                            inkey = :ll_key; */
                        if (dataService.SQLCode < 0)
                        {
                            this.ResumeLayout(false);
                            MessageBox.Show(dataService.SQLErrText
                                           , "Declare procedure error - sp_Extension_DaysPerAnnum"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //? CLOSE conproc3
                            return;
                        }
                        //? execute conproc3 ;
                        dataService = RDSDataService.SpExtensionDaysPerAnnum(ll_key, lContract);
                        if (dataService.SQLCode < 0)
                        {
                            this.ResumeLayout(false);
                            MessageBox.Show(dataService.SQLErrText
                                           , "Execute procedure error - sp_Extension_DaysPerAnnum"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //? CLOSE conproc3
                            return;
                        }
                        //? fetch conproc3 INTO :lDaysYear;
                        lDaysYear = dataService.intVal;
                        if (dataService.SQLCode < 0)
                        {
                            this.ResumeLayout(false);
                            MessageBox.Show(dataService.SQLErrText
                                           , "Fetch procedure error - sp_Extension_DaysPerAnnum"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //? CLOSE conproc3
                            return;
                        }
                        //? CLOSE conproc3
                        // messagebox ( "",ldaysyear).ToString()
                        dw_contract.GetItem<ContractNoEntry2001>(0).SfKey = StaticVariables.gnv_app.of_get_parameters().integerparm;
                        dw_contract.GetItem<ContractNoEntry2001>(0).RfDeliveryDays = StaticVariables.gnv_app.of_get_parameters().stringparm;
                        ((DExtension2005)dw_extension.DataObject).Retrieve(lContract);
                        if (dw_extension.RowCount > 0)
                        {
                            dw_extension.GetItem<Extension2005>(0).NoDelDaysYear = lDaysYear;
                            dw_extension.GetItem<Extension2005>(0).ExtnReason = "";
                        }
                        // get frequency distance
                        /* DECLARE conproc4 procedure for rd.sp_Extension_RFDistance
                            inContract = :lContract,
                            inkey  = :param1,
                            indays = :param2; */
                        int param1 = (int)StaticVariables.gnv_app.of_get_parameters().integerparm;
                        string param2 = StaticVariables.gnv_app.of_get_parameters().stringparm;
                        if (dataService.SQLCode < 0)
                        {
                            this.ResumeLayout(false);
                            //? CLOSE conproc4
                            MessageBox.Show(dataService.SQLErrText
                                           , "Declare procedure error - sp_Extension_RFDistance"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //? execute conproc4 ;
                        dataService = RDSDataService.SpExtenstionRFDistance(lContract, param2, param1);
                        if (dataService.SQLCode < 0)
                        {
                            this.ResumeLayout(false);
                            //? CLOSE conproc4
                            MessageBox.Show(dataService.SQLErrText
                                           , "Execute procedure error - sp_Extension_RFDistance"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //? fetch conproc4 INTO :decDistance;
                        decDistance = dataService.decVal;
                        if (dataService.SQLCode < 0)
                        {
                            this.ResumeLayout(false);
                            //? CLOSE conproc4
                            MessageBox.Show(dataService.SQLErrText
                                           , "Fetch procedure error - sp_Extension_RFDistance"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //? CLOSE conproc4
                        dw_extension.DataObject.Controls["gb_3"].Controls["st_daily_distance"].Text = decDistance.Value.ToString("#,###.00");
                    }
                }
            }
            dw_extension.GetControlByName("compute_1").Visible = false;
            dw_extension.GetControlByName("cust_change").Visible = false;
            dw_extension.GetControlByName("volume_change").Visible = false;
            dw_extension.GetControlByName("proc_hrs_change").Visible = false;
            dw_extension.GetControlByName("extnamnt").Visible = false;
            dw_extension.GetControlByName("compute_4").Visible = false;
            // dw_extension.ResetUpdate ( )
            cb_search.Enabled = false;
            dw_contract.ResetUpdate();
            dw_contract.DataObject.BindingSource.CurrencyManager.Refresh();
            if (dw_extension.RowCount > 0)
            {
                ((System.Windows.Forms.TextBox)(dw_contract.GetControlByName("contract_no"))).ReadOnly = true;//dw_contract.DataObject.Enabled = false;
                dw_contract.GetControlByName("contract_no").BackColor = System.Drawing.SystemColors.ButtonFace; // 79216776;               
            }
            this.ResumeLayout(false);
        }

        public virtual void dw_contract_getfocus(object sender, EventArgs e)
        {
            dw_contract.URdsDw_GetFocus(null, null);
            this.AcceptButton = cb_search;
        }

        //jlwang:no use 
        //public virtual void dw_ext_getfocus(object sender, EventArgs e)
        //{
        //    // base.getfocus();
        //    // if this.RowCount > 0 then
        //    // 	dw_contract.modify ( "datawindow.readonly=yes")
        //    // 	dw_contract.GetControlByName("contract_no").BackColor = RGB ( 192, 192, 192)
        //    // end if
        //}

        public virtual void dw_ext_itemchanged(object sender, EventArgs e)
        {
            //  base.itemchanged();
            dw_ext.URdsDw_Itemchanged(sender, e);
            bool bRecalc      = false;
            decimal dDistance = 0;
            int lCustomers    = 0;
            decimal dDelHours = 0;
            decimal dextnamnt = 0;
            decimal dExtnDelHrs = 0;

            string sColumn;
            object value;
            string data;

                // TJB  20-Jul-2009  RD7_0033: Extentions fixes
                //    Moved extraction of 'value' outside 'if' structure
            sColumn = ((TextBoxBase)sender).Name;        //dw_ext.GetColumnName();
            value   = dw_ext.GetValue<object>(0, sColumn);

            if (dw_ext.RowCount > 0)//pp! added condition or of no row there is exception
            {
                data  = value != null ? value.ToString() : null;
                if (sColumn == "extn_distance")
                {
                    decimal.TryParse(dw_ext.GetControlByName(sColumn).Text, out dDistance);
                    lCustomers = (int)dw_ext.GetItem<Extension2005>(0).CustChange;
                    bRecalc = true;
                    dw_extension.GetControlByName("compute_1").Visible = true;
                    dw_extension.GetControlByName("extnamnt").Visible  = true;
                }
                else if (sColumn == "extn_boxes")
                {
                    dDistance = (decimal)dw_ext.GetItem<Extension2005>(0).ExtnDistance;
                    lCustomers = (int)value;
                    if (StaticFunctions.f_nempty(lCustomers))
                    {
                        lCustomers = (int)dw_ext.GetItem<NZPostOffice.RDS.Entity.Ruraldw.Extension2005>(0).ExtnNoCmbCustomers;
                    }
                    else if (!(StaticFunctions.f_nempty(dw_ext.GetItem<Extension2005>(0).ExtnNoCmbCustomers)))
                    {
                        lCustomers = lCustomers + (int)dw_ext.GetItem<Extension2005>(0).ExtnNoCmbCustomers;
                    }
                    // TJB  20-Jul-2009  Extentions fixes
                    //     Moved this block outside "if" blocks
                    // if (lCustomers != 0)
                    // {
                    //     dw_extension.GetControlByName("cust_change").Visible     = true;
                    //     dw_extension.GetControlByName("volume_change").Visible   = true;
                    //     dw_extension.GetControlByName("proc_hrs_change").Visible = true;
                    //     dw_extension.GetControlByName("extnamnt").Visible        = true;
                    // }
                    bRecalc = true;
                }
                else if (sColumn == "extn_no_cmb_customers")
                {
                    dDistance = (decimal)dw_ext.GetItem<Extension2005>(0).ExtnDistance;
                    lCustomers = (int)value;
                    if (StaticFunctions.f_nempty(lCustomers))
                    {
                        lCustomers = (int)dw_ext.GetItem<Extension2005>(0).ExtnBoxes;
                    }
                    else if (!(StaticFunctions.f_nempty(dw_ext.GetItem<Extension2005>(0).ExtnBoxes)))
                    {
                        lCustomers = lCustomers + (int)dw_ext.GetItem<Extension2005>(0).ExtnBoxes;
                    }
                    bRecalc = true;
                }
                else if (sColumn == "extn_effective_date")
                {
                    try
                    {
                        if (!(StaticVariables.gnv_app.of_sanedate(
                            System.Convert.ToDateTime(dw_ext.GetControlByName(sColumn).Text), "effective date")))
                        {
                            return;//?2;
                        }
                    }
                    catch (Exception ex)
                    {
                        dw_ext.GetControlByName(sColumn).Text = "00/00/0000";
                    }
                }
                else if (sColumn == "extn_del_hrs")
                {
                        // TJB  20-Jul-2009  Extentions fixes
                        //    Turned on bRecalc flag (was commented out)
                        //    Needed to enable recalculation of amount if extn_del_hrs manually changed
                    dw_extension.GetControlByName("extnamnt").Visible = true;
                    bRecalc = true;
                }
                    // tjb  15-Jul-2009  Extensions fixes
                    //    Moved from below if(bRecalc)
                else if (sColumn == "extnamount")
                {
                    if (dw_ext.GetItem<Extension2005>(0).Extnamount != 0)
                    {
                        dw_extension.GetControlByName("compute_4").Visible = true;
                        dw_ext.DataObject.BindingSource.CurrencyManager.Refresh();
                    }
                    bRecalc = true;
                }
                    // TJB  20-Jul-2009  Extentions fixes
                    //    Moved to make these fields visible when # customesrs changed
                if (lCustomers != 0)
                {
                    dw_extension.GetControlByName("cust_change").Visible = true;
                    dw_extension.GetControlByName("volume_change").Visible = true;
                    dw_extension.GetControlByName("proc_hrs_change").Visible = true;
                    dw_extension.GetControlByName("extnamnt").Visible = true;
                }
                if (bRecalc)
                {
                    // 	if not f_nEmpty ( dDistance) then
                    // 		dDelHrs = dDistance / iltravellingspeed
                    // 	end if
                    // 	if not f_nEmpty ( lCustomers) then
                    // 		dDelHrs = dDelHrs +  ( lCustomers * ilcustomerdeliverytime)
                    // 	end if
                    // 	this.setitem ( 1, "extn_del_hrs", This.GetItemNumber ( 1, "del_days_per_week")
                    // 
                    //  TWC - 18/09/2003 call 4566 
                    //  accept text so all variables are current before recalculating
                    dw_ext.AcceptText();

                       // TJB  20-Jul-2009  Extentions fixes
                       //    Added test for extn_del_hrs column
                       //    In PB version, changing the ExtnDelHrs value here was reversed (somehow)
                       //    when dw_ext_ue_reenter_amount() was entered, and the relevant calculations
                       //    worked correctly.  In C#, setting the ExtnDelHrs value is permanent and
                       //    usually resulted in it being set to 0.
                       //    This code ensures the value entered is the value seen by
                       //    dw_ext_ue_reenter_amount().
                    if (sColumn == "extn_del_hrs")
                    {
                        dExtnDelHrs = (decimal)value;
                        dw_ext.GetItem<Extension2005>(0).ExtnDelHrs = dExtnDelHrs;
                    } 
                    else
                    {
                        dDelHours = (decimal)dw_ext.GetItem<Extension2005>(0).DelDaysPerWeek;
                        dDelHours = Math.Round(dDelHours, 2);
                        dw_ext.GetItem<Extension2005>(0).ExtnDelHrs = dDelHours;
                        // dw_ext.DataObject.SetCurrent(0);
                        // dw_ext.GetControlByName("extn_del_hrs").Text = dw_ext.GetValue(0, "extn_del_hrs").ToString();
                            // TJB  20-Jul-2009  Extentions fixes
                            //    The line below was  commented-out because it is redundant
                        // dw_ext.SetValue(0, "extn_del_hrs", dDelHours);    // dw_ext.SetItem(1, "extn_del_hrs", dDelHours);
                    }
                    dw_ext_ue_reenter_amount();                          // post
                        // TJB  20-Jul-2009  Extentions fixes
                        //    Redundant
                    // dw_ext.DataObject.BindingSource.CurrencyManager.Refresh();
                }
                dw_ext.DataObject.BindingSource.CurrencyManager.Refresh();
            }
        }

        public virtual void cb_print_clicked(object sender, EventArgs e)
        {
            //? dw_benchmark_report.Print();
        }

        #endregion
    }
}