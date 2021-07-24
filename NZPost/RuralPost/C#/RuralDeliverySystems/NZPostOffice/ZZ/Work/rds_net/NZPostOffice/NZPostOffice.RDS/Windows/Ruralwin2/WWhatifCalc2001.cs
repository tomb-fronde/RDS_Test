using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.RDS.Controls;
using Metex.Windows;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruralwin2;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralwin2;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Windows.Ruralwin;
using CrystalDecisions.CrystalReports.Engine;
using NZPostOffice.RDS.DataControls.Report;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WWhatifCalc2001 : WAncestorWindow
    {
        // TJB Frequencies & Vehicles 3-Mar-2021  
        // Added vt_key to GetVehicleOverrideRateList parameters
        // Bug fix: replaced RERrrateVehinsurance with RENinsurancepct in store_group_report
        // Add support for VtList - list of vehicle types in a contract - and add them
        //    to the set of vehicle types in the report
        // Commented out of_cachevtkeys; obsolete (could be deleted)
        // [24-Jul-2021] Changed nAccAmount to AccPerAnnum in report (REDWhatifCalculatorReport2005.rpt)
        //
        // TJB  RPCR_148 May-2020
        // Added new section for additional Vehicle rates to REDWhatifCalculatorReport2005.rpt
        // Changes here to add between 4 and 11 vehicle rates to report
        // Changed use of variable Compute6 to pass number of distinct vehicle rates to
        //    report; in report, this used to make added section visible if needed
        //    It didn't appear to be used for anything previously
        //    (see of_showreport).
        //
        // TJB  RPCR_126  July-2018 (Formerly Oct-2017 Bug fix:)
        // Fixed calculation of Sundries total for >1 contract.  
        // (see store_group_report).
        // [these changes are specific to RPCR_126]
        // Disabled scaling of Sundries and Wardrobe values in full Whatif report
        // (see REDWhatifCalculatorReport2005.rpt - tsundries in Formula Fields)
        // also for Benchmark report (see sp_getBenchmarkRpt2013)
        //
        // TJB  Aug-2013
        // Tidyup - removed irrelevant comments and other similar changes
        //
        // TJB  RPCR_041  Jan-2013
        // Changed 'show calcs' button to filp-flop show/hide; removed hide button
        // Changed Totacc, Totdev, Totproc, Totrel to sum AccPerAnnum, DeliveryCost, ProcessingCost, 
        //         ReliefCost from stored proc (rather than from recalculated values)
        //         - See of_showreport
        //
        // TJB  Nov-2012
        // Changed displayed title to "WWhatifRate2001" from PB format
        //
        //-----------------------------------------------------------------------------------------
        // Note:  
        // The WhatIf report executes the sp_GetWhatIfCalc2005 stored procedure via 
        // Entity.Ruralwin2.WhatIfCalculator2005.  To prepare the report, the values are copied to 
        // Entity.Ruralwin2.WhatIfCalculatorReport2005 in which many of the values calculated in 
        // the stored procedure are re-calculated under different, though similar, names.
        // If multiple contracts are selected for the WhatIf report, the individual contract's 
        // values are summed, though the summation is sometimes done in the WhatIfCalculatorReport2005
        // entity, and sometimes in this module (see of_showreport and store_group_report).
        // The report itself (REDEhatifCalculatorReport2005) uses values from the entity 
        // WhatIfCalculatorReport2005, mostly from the recalculated variables.
        // Very complex/confusing and in need of rationalisation.
        //-----------------------------------------------------------------------------------------

        #region Define

        // IntArray ila_VtKeys = new IntArray();
        public List<int> ila_VtKeys = new List<int>();

        public DataUserControl idw_Crosstab;

        public int il_RGCode;

        public DateTime id_EffectDate = DateTime.MinValue;

        // DecimalArray idec_Current = new DecimalArray();
        public List<decimal> idec_Current = new List<decimal>();

        public decimal? id_RateOf;

        // DecimalArray id_RateOfReturn = new DecimalArray();
        public List<decimal?> id_RateOfReturn = new List<decimal?>();

        public string is_reportRenewal = String.Empty;

        public DataUserControl idw_summary;

        public DataUserControl idw_report;

        public DataUserControl idw_dist;

        //  TJB SR4560  Used to save contract number (in of_setup) for use by of_showVehicleRates 
        public int? il_contract;

        public int? il_sequence;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_close;

        public TabControl tab_1;

        public TabPage tabpage_summary;

        public URdsDw dw_summary;

        public TabPage tabpage_report;

        public URdsDw dw_whatifreport;

        public TabPage tabpage_distribution;

        public URdsDw dw_distribution;

        public Button cb_print;

        public Button cb_showcalc;

        public WStatus w_status = null;

        #endregion

        public WWhatifCalc2001()
        {
            this.InitializeComponent();

            dw_summary.DataObject = new DWhatifCalulator2005();
            dw_whatifreport.DataObject = new DWhatifCalculatorReport2005();
            dw_distribution.DataObject = new DWhatifDistribution2001();

            //((DWhatifCalulator2005)dw_summary.DataObject).CellDoubleClick += new EventHandler(dw_summary_doubleclicked);
            dw_summary.DataObject.RetrieveEnd += new EventHandler(dw_summary_retrieveend);
            dw_summary.DataObject.RetrieveStart += new RetrieveEventHandler(dw_summary_retrievestart);
            dw_summary.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_summary_constructor);

            dw_whatifreport.DataObject.RetrieveStart += new RetrieveEventHandler(dw_whatifreport_retrievestart);
            dw_whatifreport.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_whatifreport_constructor);

            dw_distribution.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_distribution_constructor);

            ((CrystalDecisions.Windows.Forms.CrystalReportViewer)dw_summary.GetControlByName("viewer")).Drill += new CrystalDecisions.Windows.Forms.DrillEventHandler(WWhatifCalc2001_Drill);
            ((CrystalDecisions.Windows.Forms.CrystalReportViewer)dw_summary.GetControlByName("viewer")).DrillDownSubreport += new CrystalDecisions.Windows.Forms.DrillSubreportEventHandler(WWhatifCalc2001_DrillDownSubreport);
            //((CrystalDecisions.Windows.Forms.CrystalReportViewer)dw_summary.GetControlByName("viewer")).EnableDrillDown = false;
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        // </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_close = new Button();
            this.tab_1 = new TabControl();
            this.cb_print = new Button();
            this.cb_showcalc = new Button();
            Controls.Add(cb_close);
            Controls.Add(tab_1);
            Controls.Add(cb_print);
            Controls.Add(cb_showcalc);
            this.Text = "Whatif Calculation";
            this.Height = 438;
            this.Width = 594;
            this.Top = 0;
            this.Left = 0;
            this.Name = "WWhatifCalc2001";
            this.DoubleClick += new EventHandler(doubleclicked);
            // 
            // st_label
            // 
            st_label.Location = new System.Drawing.Point(7, 390);
            st_label.Width = 120;
            // 
            // cb_close
            // 
            cb_close.Text = "&Close";
            cb_close.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_close.TabIndex = 2;
            cb_close.Size = new System.Drawing.Size(65, 22);
            cb_close.Location = new System.Drawing.Point(513, 380);
            cb_close.Click += new EventHandler(cb_close_clicked);
            // 
            // tab_1
            // 
            tabpage_summary = new TabPage();
            tabpage_report = new TabPage();
            tabpage_distribution = new TabPage();
            tab_1.Controls.Add(tabpage_summary);
            tab_1.Controls.Add(tabpage_report);
            tab_1.Controls.Add(tabpage_distribution);

            tab_1.SelectedIndex = 0;//.SelectedTab = 1;
            tab_1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            tab_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_1.TabIndex = 1;
            tab_1.Height = 371;
            tab_1.Width = 573;
            tab_1.Top = 3;
            tab_1.Left = 3;
            tab_1.SelectedIndexChanged += new EventHandler(tab_1_selectionchanged);
            // 
            // tabpage_summary
            // 
            dw_summary = new URdsDw();
            //!dw_summary.DataObject = new DWhatifCalulator2005();
            tabpage_summary.Controls.Add(dw_summary);
            tabpage_summary.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_summary.Text = "Summary Report";
            tabpage_summary.Name = tabpage_summary.Text;//

            tabpage_summary.Size = new System.Drawing.Size(565, 342);
            tabpage_summary.Location = new System.Drawing.Point(3, 25);
            // 
            // dw_summary
            // 
            dw_summary.TabIndex = 3;
            dw_summary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                 | System.Windows.Forms.AnchorStyles.Left)
                 | System.Windows.Forms.AnchorStyles.Right)));
            dw_summary.Size = new System.Drawing.Size(555, 328);
            dw_summary.Location = new System.Drawing.Point(5, 7);
            dw_summary.Click += new EventHandler(dw_summary_clicked);

            //((DWhatifCalulator2005)dw_summary.DataObject).CellDoubleClick += new EventHandler(dw_summary_doubleclicked);
            //dw_summary.DataObject.RetrieveEnd += new EventHandler(dw_summary_retrieveend);
            //dw_summary.DataObject.RetrieveStart += new RetrieveEventHandler(dw_summary_retrievestart);
            //dw_summary.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_summary_constructor);
            // 
            // tabpage_report
            // 
            dw_whatifreport = new URdsDw();
            //!dw_whatifreport.DataObject = new DWhatifCalculatorReport2005();
            tabpage_report.Controls.Add(dw_whatifreport);
            tabpage_report.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_report.Text = "Full Report";
            tabpage_report.Name = tabpage_report.Text;
            tabpage_report.Size = new System.Drawing.Size(565, 342);
            tabpage_report.Location = new System.Drawing.Point(3, 25);
            // 
            // dw_whatifreport
            // 
            dw_whatifreport.AutoScroll = true;
            dw_whatifreport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            dw_whatifreport.TabIndex = 4;
            dw_whatifreport.Size = new System.Drawing.Size(555, 328);
            dw_whatifreport.Location = new System.Drawing.Point(5, 7);
            //dw_whatifreport.DataObject.RetrieveStart += new RetrieveEventHandler(dw_whatifreport_retrievestart);
            //dw_whatifreport.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_whatifreport_constructor);
            // 
            // tabpage_distribution
            // 
            dw_distribution = new URdsDw();
            //!dw_distribution.DataObject = new DWhatifDistribution2001();
            tabpage_distribution.Controls.Add(dw_distribution);
            tabpage_distribution.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_distribution.Text = "Distribution Report";
            tabpage_distribution.Name = tabpage_distribution.Text;//

            tabpage_distribution.Size = new System.Drawing.Size(565, 342);
            tabpage_distribution.Location = new System.Drawing.Point(3, 25);
            // 
            // dw_distribution
            //
            dw_distribution.TabIndex = 5;
            dw_distribution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            dw_distribution.Size = new System.Drawing.Size(555, 328);
            dw_distribution.Location = new System.Drawing.Point(5, 7);
            //dw_distribution.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_distribution_constructor);
            // 
            // cb_print
            // 
            cb_print.Text = "&Print";
            cb_print.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_print.TabIndex = 3;
            cb_print.Size = new System.Drawing.Size(65, 22);
            cb_print.Location = new System.Drawing.Point(433, 380);
            cb_print.Click += new EventHandler(cb_print_clicked);
            // 
            // cb_showcalc
            // 
            cb_showcalc.Text = "Show Calcs";
            cb_showcalc.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_showcalc.TabIndex = 4;
            cb_showcalc.Size = new System.Drawing.Size(66, 22);
            cb_showcalc.Location = new System.Drawing.Point(157, 379);
            cb_showcalc.Visible = false;
            cb_showcalc.Click += new EventHandler(cb_showcalc_clicked);
            this.ResumeLayout();
            //((CrystalDecisions.Windows.Forms.CrystalReportViewer)(dw_summary.DataObject.GetControlByName("viewer"))).DoubleClick += new EventHandler(WWhatifCalc2001_DoubleClick);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            this.BringToFront();
            this.of_setup();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.Location = new System.Drawing.Point(0, 0);
            this.of_set_componentname("Rates/What-if");
        }

        #region Methods
        public virtual int of_setup()
        {
            this.SuspendLayout();
            int ll_Row;
            int ll_NewRow;
            int ll_RateRow = 0;
            int ll_RowCount = 0;
            int? ll_Contract = 0;
            int? ll_Sequence = 0;
            int ll_NumContracts;
            int ll_SfKey = 0;
            int ll_DaysYear = 0;
            int ll_FirstRow = 0;
            int ll_Contracts = 0;
            int? ll_numberboxholders;
            int ll_volume;
            string ls_DelDays = string.Empty;
            string ls_VolumeSource;
            DateTime ld_EffectDate;
            decimal ldec_Distance = 0;
            decimal? dItemspercust;
            int ll_Count;
            int ll_Ctr;
            NRdsMsg lnv_Msg;
            NCriteria lnv_Criteria;
            WBenchmarkRates2001 lw_Rates;

            id_RateOf = 0;
            idw_summary.Reset();

            lnv_Msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lnv_Criteria = lnv_Msg.of_getcriteria();
            lw_Rates = lnv_Criteria.of_getcriteria("caller") as WBenchmarkRates2001;
            ls_VolumeSource = (string)lnv_Criteria.of_getcriteria("VolumeSource");
            il_RGCode = (int)lnv_Criteria.of_getcriteria("rg_code");
            ld_EffectDate = (DateTime)lnv_Criteria.of_getcriteria("effective_date");
            is_reportRenewal = (string)lnv_Criteria.of_getcriteria("reportgroupname");
            id_EffectDate = ld_EffectDate;

            // Count rows for progress bar
            ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(0);
            ll_Count = 0;
            ll_Ctr = 0;
            while (!(ll_RateRow == -1))
            {
                ll_Count++;
                ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(ll_RateRow + 1);
            }
            
            // Loop through the caller's datawindow's contract list
            // NOTE:  dw_listing is the list of contracts on the Rates/WhatIf window
            // (TJB)  and ll_RateRow is mis-named; should be something like ll_ContractRow
            ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(0);
            ll_NumContracts = lw_Rates.dw_listing.RowCount;
            while (!(ll_RateRow == -1))
            {
                ll_Ctr++;
                StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Ctr, ll_Count, "Retrieving Rates...");
                ll_Contracts++;
                //lw_Rates.dw_listing.getitemnumber(ll_RateRow, "contract_no");
                ll_Contract = lw_Rates.dw_listing.GetItem<WhatifContractSelection>(ll_RateRow).ContractNo;
                ll_Sequence = lw_Rates.dw_listing.GetItem<WhatifContractSelection>(ll_RateRow).ContractSeqNumber;
                ll_FirstRow = -1;

                // Get frequencies
                List<RouteFrequencyItem> rfList = new List<RouteFrequencyItem>();
                RDSDataService rService = RDSDataService.GetRouteFrequencyList(ll_Contract.GetValueOrDefault());
                rfList = rService.RoutFrequencyList;
                //while (StaticVariables.sqlca.SQLCode == 0)
                for (int i = 0; i < rfList.Count; i++) 
                {
                    ll_SfKey = rfList[i].SfKey;
                    ls_DelDays = rfList[i].RfDeliveryDays;
                    ldec_Distance = rfList[i].RfDistance;

                    if (ll_FirstRow == -1)
                    {
                        ((DWhatifCalulator2005)idw_summary).Retrieve(ll_Contract, ll_Sequence, il_RGCode, ld_EffectDate, ls_VolumeSource);
                        // Store vt_keys
                        ll_FirstRow = idw_summary.RowCount - 1;
                        idw_summary.SetValue(ll_FirstRow, "firstrow", "Y");
                        ll_numberboxholders = idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Numberboxholders;
                        ll_numberboxholders = (ll_numberboxholders == null) ? 0 : ll_numberboxholders;
                        if (ll_numberboxholders > 0)
                        {
                            ll_volume = (int)idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Volume;
                            //idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Itemspercust 
                            //                     = Math.Round(System.Convert.ToDecimal(ll_volume) 
                            //                        / System.Convert.ToDecimal(ll_numberboxholders), 3);
                            dItemspercust = Math.Round(System.Convert.ToDecimal(ll_volume)
                                                                 / System.Convert.ToDecimal(ll_numberboxholders), 3);
                            idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Itemspercust = dItemspercust;
                        }
                        else
                        {
                            idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Itemspercust = 0m;
                        }
                    }
                    else
                    {
                        ((DWhatifCalulator2005)idw_summary).Retrieve(ll_Contract, ll_Sequence, il_RGCode, ld_EffectDate, ls_VolumeSource);
                        idw_summary.SetValue(idw_summary.RowCount - 1, "firstrow", "N");
                        // idw_summary.GetItem<WhatifCalulator2005>(idw_summary.RowCount - 1).Itemspercust 
                        //                      = idw_summary.GetItem<WhatifCalulator2005>(idw_summary.RowCount - 2).Itemspercust;
                        dItemspercust = idw_summary.GetItem<WhatifCalulator2005>(idw_summary.RowCount - 2).Itemspercust;
                        dItemspercust = (dItemspercust == null) ? 0 : dItemspercust;
                        idw_summary.GetItem<WhatifCalulator2005>(idw_summary.RowCount - 1).Itemspercust = dItemspercust;
                    }
                    ll_Row = idw_summary.RowCount - 1;
                    idw_summary.SetValue(ll_Row, "sf_key", ll_SfKey);
                    idw_summary.SetValue(ll_Row, "rf_deliverydays", ls_DelDays);
                    idw_summary.SetValue(ll_Row, "rf_distance", ldec_Distance);

                    ll_DaysYear = RDSDataService.GetRateDaysValue(il_RGCode, ld_EffectDate, ll_SfKey);
                    idw_summary.SetValue(ll_Row, "rf_daysyear", ll_DaysYear);
                }
                ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(ll_RateRow + 1);
            }

            ll_RowCount = idw_summary.RowCount;
            //?idw_summary.GroupCalc();
            store_group_value();

            if (ll_RowCount > 0)
            {
                for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
                {
                    StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Row, ll_RowCount, "Calculating final benchmark...");
                    // idec_Current[ll_Row] = idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Opcost;//.GetItemNumber(ll_Row, "opcost");
                    // TJB: idec_Current is a list.  idec_Current.Add adds an item (Opcost) to the list 
                    //      then copies it to idw_summary, unchanged.  idec_Current isn't used anywhere
                    //      else so there's no need to use it.
                    //      thisOpcost is used only to see what's happening ...
                    //idec_Current.Add(idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Opcost);
                    //idw_summary.SetValue(ll_Row, "finalbenchmark", System.Convert.ToInt32(idec_Current[ll_Row]));
                    decimal thisOpcost = idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Opcost;
                    idw_summary.SetValue(ll_Row, "finalbenchmark", System.Convert.ToInt32(thisOpcost));
                }
                if (idw_summary.GetControlByName("st_contract") != null)
                    idw_summary.GetControlByName("st_contract").Text = "\'" + idw_summary.GetItem<WhatifCalulator2005>(0).ContractNo.ToString() + "\'";//idw_summary.DataControl["st_contract"].Text = "\'" + String((DWhatifCalulator2005)idw_summary.GetItemNumber(1, "contract_no")) + '\'');
                if (idw_summary.GetControlByName("st_no_contracts") != null)
                    idw_summary.GetControlByName("st_no_contracts").Text = "\'" + ll_Contracts.ToString() + "\'";//idw_summary.DataControl["st_no_contracts"].Text = "\'" + ll_Contracts.ToString() + '\'');
                if (ll_RowCount > 0)
                {
                    for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
                    {
                        decimal? dRateofreturn1 = idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Rateofreturn1;
                        id_RateOfReturn.Add(dRateofreturn1);  // TJB: id_RateOfReturn isn't used anywhere?
                    }
                }
            }
            // TJB  RD7_0036  Aug 2009
            // Removed.
            // store_group_value();   // TJB:  This isn't done in PB version??

            of_loadvtkeys();
            StaticVariables.gnv_app.of_hidestatus(ref w_status);
            this.ResumeLayout();
            return 1;
        }

        public virtual void store_group_value()
        {
            //sum( if(rf_active='Y',( rf_distance  *  rf_daysyear  ),0) for group 1 )
            int? l_contract_no = 0;
            int? l_contract_no_old = 0;
            decimal? l_group = 0;
            decimal? dRfDistance, dRfDaysyear, dCalcroutedistance;
            int j = 0;

            l_group = 0;
            l_contract_no_old = 0;
            for (int i = 0; i < idw_summary.RowCount; i++)
            {
                l_contract_no = idw_summary.GetItem<WhatifCalulator2005>(i).ContractNo;
                if (l_contract_no == l_contract_no_old)
                {
                    if (idw_summary.GetItem<WhatifCalulator2005>(i).RfActive == "Y")
                    {
                        //l_group += idw_summary.GetItem<WhatifCalulator2005>(i).RfDistance
                        //              * idw_summary.GetItem<WhatifCalulator2005>(i).RfDaysyear;
                        dRfDistance = idw_summary.GetItem<WhatifCalulator2005>(i).RfDistance;
                        dRfDaysyear = idw_summary.GetItem<WhatifCalulator2005>(i).RfDaysyear;
                        l_group += dRfDistance * dRfDaysyear;
                    }
                }
                else
                {
                    for (int k = j; k < i; k++)
                    {
                        // idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance = l_group;
                        dCalcroutedistance = idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance;
                        dCalcroutedistance = l_group;
                        idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance = dCalcroutedistance;
                    }
                    //l_group = idw_summary.GetItem<WhatifCalulator2005>(i).RfDistance 
                    //             * idw_summary.GetItem<WhatifCalulator2005>(i).RfDaysyear;
                    dRfDistance = idw_summary.GetItem<WhatifCalulator2005>(i).RfDistance;
                    dRfDaysyear = idw_summary.GetItem<WhatifCalulator2005>(i).RfDaysyear;
                    l_group = dRfDistance * dRfDaysyear;
                    j = i;
                }
                l_contract_no_old = l_contract_no;
            }
            for (int k = j; k < idw_summary.RowCount; k++)
            {
                //idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance 
                //                                                 = l_group.GetValueOrDefault();
                dCalcroutedistance = idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance;
                dCalcroutedistance = l_group.GetValueOrDefault();
                idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance = dCalcroutedistance;
            }

            System.Data.DataTable table = new NZPostOffice.RDS.DataControls.Report.WhatifCalulator2005DataSet(idw_summary.BindingSource.DataSource);
            if (((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_summary.GetControlByName("viewer")).ReportSource is REDWhatifCalculator2005)
            {
                ((REDWhatifCalculator2005)((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_summary.GetControlByName("viewer")).ReportSource).SetDataSource(table);
            }
            else
            {
                ((REDWhatifCalculator2005Detail)((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_summary.GetControlByName("viewer")).ReportSource).SetDataSource(table);
            }
            ((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_summary.GetControlByName("viewer")).RefreshReport();
        }

        public virtual int of_showreport()
        {
            this.SuspendLayout();
            DataUserControl dwc1;
            DataUserControl dwc2;
            DataUserControl dwc_rates;

            dwc1 = idw_summary.GetChild("dw_rates");
            dwc2 = idw_report.GetChild("dw_rates");
            of_showvehiclerates();

            idw_report.Reset();

            // TJB RPCR_148 May-2020  Get number of distinct vehicle types (for vehicle rates)
            int numVtKeys = of_countuniquevtkeys();

            for (int i = 0; i < idw_summary.RowCount; i++)
            {
                WhatifCalulator2005 data = idw_summary.GetItem<WhatifCalulator2005>(i);
                /* ------------------------- Debugging ------------------------- //
                string firstrowStatus = data.Firstrow;
                MessageBox.Show("i = " + i.ToString() + " of " + idw_summary.RowCount.ToString() + "\n"
                                + "Contract = " + data.ContractNo.ToString() + "\n"
                                + "Seq = " + data.ContractSeqNumber.ToString() + "\n"
                                + "Title = " + data.ConTitle + "\n"
                                + "FirstRow = " + firstrowStatus
                                , "RDS.Windows.Ruralwin2.WhatIfCalc2005.of_showreport");
                // ------------------------------------------------------------- */
                WhatifCalculatorReport2005 l_temp = new WhatifCalculatorReport2005();
                l_temp.ConTitle = data.ConTitle;
                l_temp.ContractNo = data.ContractNo;
                l_temp.ContractSeqNumber = data.ContractSeqNumber;
                l_temp.Nominalvehical = data.Nominalvehical;
                l_temp.Delwagerate = data.Delwagerate;
                l_temp.Repairsmaint = data.Repairsmaint;
                l_temp.Tyrestubes = data.Tyrestubes;
                l_temp.Vehicalallow = data.Vehicalallow;
                l_temp.Vehicalinsure = data.Vehicalinsure;
                l_temp.Publiclia = data.Publiclia;
                l_temp.Carrierrisk = data.Carrierrisk;
                l_temp.Accrate = data.Accrate;
                l_temp.Licence = data.Licence;
                l_temp.Rateofreturn = data.Rateofreturn;
                l_temp.Salvageratio = data.Salvageratio;
                l_temp.Itemshour = data.Itemshour;
                l_temp.Fuel = data.Fuel;
                l_temp.Consumption = data.Consumption;
                l_temp.Routedistance = data.Routedistance;
                l_temp.Deliveryhours = data.Deliveryhours;
                l_temp.Processinghours = data.Processinghours;
                l_temp.Volume = data.Volume;
                l_temp.Deliverydays = data.Deliverydays;
                l_temp.Maxdeliverydays = data.Maxdeliverydays;
                l_temp.Numberboxholders = data.Numberboxholders;
                l_temp.Routedistanceperday = data.Routedistanceperday;
                l_temp.Vehicledepreciation = data.Vehicledepreciation;
                l_temp.Fuelcostperannum = data.Fuelcostperannum;
                l_temp.Repairsperannum = data.Repairsperannum;
                l_temp.Tyrestubesperannum = data.Tyrestubesperannum;
                l_temp.Deliverycost = data.Deliverycost;
                l_temp.Processingcost = data.Processingcost;
                l_temp.Publicliabilitycost = data.Publicliabilitycost;
                l_temp.Accperannum = data.Accperannum;
                l_temp.Vehicleinsurance = data.Vehicleinsurance;
                l_temp.Licensing = data.Licensing;
                l_temp.Carrierriskrate = data.Carrierriskrate;
                l_temp.Benchmark = data.Benchmark;
                l_temp.Rateofreturn1 = data.Rateofreturn1;
                l_temp.Finalbenchmark = data.Finalbenchmark;
                l_temp.Retainedallowances = data.Retainedallowances;
                l_temp.Currentpayment = data.Currentpayment;
                l_temp.SfKey = data.SfKey;
                l_temp.RfDistance = data.RfDistance;
                l_temp.RfDeliverydays = data.RfDeliverydays;
                l_temp.RfDaysyear = data.RfDaysyear;
                l_temp.RfDaysweek = data.RfDaysweek;
                l_temp.Itemspercust = data.Itemspercust;
                l_temp.RfActive = data.RfActive;
                l_temp.Firstrow = data.Firstrow;
                l_temp.Currentbenchmark = data.Currentbenchmark;
                l_temp.Accounting = data.Accounting;
                l_temp.Telephone = data.Telephone;
                l_temp.Sundries = data.Sundries;
                l_temp.Ruc = data.Ruc;
                l_temp.RrrateNomvehicle = data.RrrateNomvehicle;
                l_temp.RrrateDelWage = data.RrrateDelWage;
                l_temp.RrrateRepairsmaint = data.RrrateRepairsmaint;
                l_temp.RrrateTyretubes = data.RrrateTyretubes;
                l_temp.RrrateVehallow = data.RrrateVehallow;
                l_temp.RrrateVehinsurance = data.RrrateVehinsurance;
                l_temp.RrratePubliclia = data.RrratePubliclia;
                l_temp.RrrateCarrierrisk = data.RrrateCarrierrisk;
                l_temp.RrrateAcc = data.RrrateAcc;
                l_temp.RrrateLicense = data.RrrateLicense;
                l_temp.RrrateVehrateofreturn = data.RrrateVehrateofreturn;
                l_temp.RrrateSalvageratio = data.RrrateSalvageratio;
                l_temp.RrrateItemprocrate = data.RrrateItemprocrate;
                l_temp.RrrateRuc = data.RrrateRuc;
                l_temp.RrrateAccounting = data.RrrateAccounting;
                l_temp.RrrateTelephone = data.RrrateTelephone;
                l_temp.RrrateSundries = data.RrrateSundries;
                l_temp.RrrateSundriesk = data.RrrateSundriesk;
                l_temp.Sundriesk = data.Sundriesk;
                l_temp.Nmultiplier = data.Nmultiplier;
                l_temp.Ninsurancepct = data.Ninsurancepct;
                l_temp.Nlivery = data.Nlivery;
                l_temp.Nuniform = data.Nuniform;
                l_temp.Naccamount = data.Naccamount;
                l_temp.Nvtkey = data.Nvtkey;
                l_temp.Reliefcost = data.Reliefcost;
                l_temp.Procwagerate = data.Procwagerate;
                l_temp.RrrateProcWage = data.RrrateProcWage;
                l_temp.Calcroutedistance = data.Calcroutedistance;
                l_temp.ReliefWeeks = data.ReliefWeeks;
                // TJB RPCR_148 May-2020  Changed usage of Compute6
                //     It appears to have to be set for all instances (hense within this loop)
                l_temp.Compute6 = Convert.ToDecimal(numVtKeys);   
                idw_report.InsertItem<WhatifCalculatorReport2005>(i, l_temp);
            }
            //store_group_report();
            // TJB RPCR_148 May-2020  
            // Added parameter to store_group_report to pass number of distinct vehicle types
            // (saves recalculating it)
            store_group_report(numVtKeys);
            if (dwc2 != null)
            {
                dwc1.ShareData(dwc2);
            }
            idw_report.Visible = true;
            this.ResumeLayout();
            return 1;
        }

        // TJB RPCR_148 May-2020  
        // Added parameter to store_group_report to pass number of distinct vehicle types
        public virtual void store_group_report(int nVtKeys)
        {
            int? l_contract_no_old;
            int? l_contract_no;
            int j;
            //Compute12
            for (int i = 0; i < idw_report.RowCount; i++)
            {
                idw_report.GetItem<WhatifCalculatorReport2005>(i).Compute12 = idw_report.GetItem<WhatifCalculatorReport2005>(0).Naccamount;
            }

            //Totacc,Totwd,Totwp
            decimal? l_Totacc = 0;     // Total ACC/yr
            decimal? l_Totwd = 0;      // Total delivery cost
            decimal? l_Totwp = 0;      // Total processing cost
            decimal? l_Totwr = 0;      // Total relief cost

            l_contract_no_old = idw_report.GetItem<WhatifCalculatorReport2005>(0).ContractNo;
            l_Totacc = idw_report.GetItem<WhatifCalculatorReport2005>(0).Accperannum.GetValueOrDefault();
            l_Totwd = idw_report.GetItem<WhatifCalculatorReport2005>(0).Deliverycost.GetValueOrDefault();
            l_Totwp = idw_report.GetItem<WhatifCalculatorReport2005>(0).Processingcost.GetValueOrDefault();
            l_Totwr = idw_report.GetItem<WhatifCalculatorReport2005>(0).Reliefcost.GetValueOrDefault();
            for (int i = 0; i < idw_report.RowCount; i++)
            {
                l_contract_no = idw_report.GetItem<WhatifCalculatorReport2005>(i).ContractNo;
                if (l_contract_no == l_contract_no_old)
                {
                }
                else
                {
                    l_Totacc += idw_report.GetItem<WhatifCalculatorReport2005>(i).Accperannum.GetValueOrDefault();
                    l_Totwd += idw_report.GetItem<WhatifCalculatorReport2005>(i).Deliverycost.GetValueOrDefault();
                    l_Totwp += idw_report.GetItem<WhatifCalculatorReport2005>(i).Processingcost.GetValueOrDefault();
                    l_Totwr += idw_report.GetItem<WhatifCalculatorReport2005>(i).Reliefcost.GetValueOrDefault();
                }
                // TJB  RD7_0036  3-Apr-2009
                // This is needed to fix a bug in the WhatIf full report
                l_contract_no_old = l_contract_no;
            }

            for (int i = 0; i < idw_report.RowCount; i++)
            {
                idw_report.GetItem<WhatifCalculatorReport2005>(i).Totacc = l_Totacc;
                idw_report.GetItem<WhatifCalculatorReport2005>(i).Totwd = l_Totwd;
                idw_report.GetItem<WhatifCalculatorReport2005>(i).Totwp = l_Totwp;
                idw_report.GetItem<WhatifCalculatorReport2005>(i).Totwr = l_Totwr;
            }
            //Stelephone,Ssundries
            decimal? l_Stelephone = 0;
            decimal? l_Ssundries = 0;
            j = 0;
            l_contract_no_old = idw_report.GetItem<WhatifCalculatorReport2005>(0).ContractNo;
            for (int i = 0; i < idw_report.RowCount; i++)
            {
                l_contract_no = idw_report.GetItem<WhatifCalculatorReport2005>(i).ContractNo;
                if (l_contract_no == l_contract_no_old)
                {
                    l_Stelephone += idw_report.GetItem<WhatifCalculatorReport2005>(i).Telephone;
                    l_Ssundries += idw_report.GetItem<WhatifCalculatorReport2005>(i).Sundries;
                }
                else
                {
                    for (int k = j; k < i; k++)
                    {
                        idw_report.GetItem<WhatifCalculatorReport2005>(k).Stelephone = l_Stelephone / (i - j);
                        idw_report.GetItem<WhatifCalculatorReport2005>(k).Ssundries = l_Ssundries / (i - j);
                    }
                    // TJB  RPCR_126  July-2018: Formal Change request
                    // Originally: Oct 2017  Bug fix: Added Sundries line
                    l_Stelephone = idw_report.GetItem<WhatifCalculatorReport2005>(i).Telephone;
                    l_Ssundries = idw_report.GetItem<WhatifCalculatorReport2005>(i).Sundries;
                    j = i;
                }
            }
            for (int k = j; k < idw_summary.RowCount; k++)
            {
                idw_report.GetItem<WhatifCalculatorReport2005>(k).Stelephone = l_Stelephone / (idw_summary.RowCount - j);
                idw_report.GetItem<WhatifCalculatorReport2005>(k).Ssundries = l_Ssundries / (idw_summary.RowCount - j);
            }

            System.Data.DataTable table = new NZPostOffice.RDS.DataControls.Report.WhatifCalculatorReport2005DataSet(idw_report.BindingSource.DataSource);
            ((REDWhatifCalculatorReport2005)((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_report.GetControlByName("viewer")).ReportSource).SetDataSource(table);

            int ll_vtkey = 0;
            string ls_vt;

            List<VehicleTypeItem> vtList = new List<VehicleTypeItem>();
            RDSDataService rService = RDSDataService.GetVehicleTypeList();
            vtList = rService.VehicleTypeList;

            int ll_Ctr = 0;
            for (int k = 0; k < idw_report.RowCount; k++)
            {
                ll_Ctr = 0;
                for (int i = 0; i < vtList.Count; i++)
                {
                    ll_vtkey = vtList[i].VtKey;
                    ls_vt = vtList[i].VtDescription;

                    if (!(of_isvtkeyinlist(ll_vtkey)))
                    {
                        continue;
                    }

                    // TJB  RPCR_148  May 2020
                    // ll_ctr counts the number of vehicle rates to display.
                    // Previousle, the form only had space for 4, and skipped any beyond that.
                    // Added a new section to the report for another 7 rates allowing for a 
                    // total of 11 now.
                    ll_Ctr++;
                    if (ll_Ctr > 11)   // TJB RPCR_148 May-2020  Increased from 4 to 11
                        continue;
                    WhatifCalculatorReport2005 item = idw_report.GetItem<WhatifCalculatorReport2005>(k);

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RrrateNomvehicle.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject).Text)
                         || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RERrrateRepairsmaint.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RrrateTyretubes.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject).Text)
                         || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RrrateVehallow.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    { // TJB Frequencies & Vehicles 3-Mar-2021  Bug fix: replaced RERrrateVehinsurance with RENinsurancepct
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RENinsurancepct.GetValueOrDefault().ToString("##0%");
                            //item.RERrrateVehinsurance.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject).Text =
                        item.RrrateVehinsurance.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RERrrateLicense.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RERrrateVehrateofreturn.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject).Text =
                            item.Salvageratio.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RERrrateRuc.GetValueOrDefault().ToString("#,##0.00");
                    }

                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject).Text)
                         || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject).Text =
                            item.RERrrateSundriesk.GetValueOrDefault().ToString("#,##0.00");
                    }
                    // TJB RPCR_148 May-2020
                    // Within the report, the display of the added section's headings can be supressed
                    // if not needed (determined via the count passed via Compute6).  But the line around
                    // the added section (box6) cannot be supressed in the same way.  Using this code, 
                    // the line is "hidden" by making it the same colour as the report's (assumed) paper.
                    if (nVtKeys <= 4)
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["Box6"] as BoxObject).LineColor = System.Drawing.Color.White;
                    }
                } // end vtList.Count loop
            }  // end idw_report.RowCount loop

            ((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_report.GetControlByName("viewer")).RefreshReport();
        }

        public virtual int of_showdistribution()
        {
            decimal d2Dist;
            decimal? RangeFrom = 0;
            decimal? RangeFromTemp;
            decimal? d2ToTemp = 0;
            decimal OffsetFromRangeFrom;
            int lRow = 0;
            int ldw1count;
            int lContracts;
            int lsumContracts = 0;
            bool bDone;
            int? lContract_no;
            decimal? Variance;
            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();
            idw_dist.Reset();
            //  The report spans ranges that are hard coded below
            //  They are in steps of 1000 until we get to -1000 then they change to 500 then
            //  to 100 steps . See dirty bit of code below
            for (d2Dist = -(11000); d2Dist <= 10000; d2Dist += 1000)
            {
                bDone = false;
                OffsetFromRangeFrom = 999.999m;
                RangeFrom = d2Dist;
                while (!bDone)
                {
                    if (RangeFrom == 0)
                    {
                        break;
                    }
                    else if (RangeFrom == 500)
                    {
                        break;
                    }
                    //  this is a dirty bit of code to get the ranges to change from 1000 to 100
                    //  around th number 0.  From -500 to 500.
                    if (RangeFrom > -(1001) && RangeFrom < 401)
                    {
                        if (OffsetFromRangeFrom == 499.999m)
                        {
                            RangeFrom = -(600);
                        }
                        if (RangeFrom == -(1000m))
                        {
                            OffsetFromRangeFrom = 499.999m;
                        }
                        else
                        {
                            RangeFrom = RangeFrom + 100;
                            OffsetFromRangeFrom = 99.999m;
                        }
                        if (RangeFrom == 0)
                        {
                            // RangeFrom = -10 
                            RangeFrom = -(0.001m);
                            // OffsetFromRangeFrom = 20
                            OffsetFromRangeFrom = 0.001m;
                        }
                        if (RangeFrom == 99.999m)
                        {
                            RangeFrom = 0.001m;
                            OffsetFromRangeFrom = 99.999m;
                        }
                        if (RangeFrom == -(100))
                        {
                            OffsetFromRangeFrom = 99.999m;
                        }
                        if (RangeFrom == 100.001m)
                        {
                            RangeFrom = 100;
                            OffsetFromRangeFrom = 99.999m;
                        }
                        if (RangeFrom == 500)
                        {
                            OffsetFromRangeFrom = 499.999m;
                        }
                    }
                    else
                    {
                        bDone = true;
                    }
                    idw_dist.AddItem<WhatifDistribution2001>(new WhatifDistribution2001());
                    idw_dist.SetValue(lRow, "from", System.Convert.ToDouble(RangeFrom));
                    idw_dist.SetValue(lRow, "to", System.Convert.ToDouble(RangeFrom + OffsetFromRangeFrom));
                    lContracts = 0;
                    lContract_no = 0;
                    // For each row in the summary, get the variance
                    for (ldw1count = 0; ldw1count < idw_summary.RowCount; ldw1count += 1)
                    {
                        Variance = idw_summary.GetItem<WhatifCalulator2005>(ldw1count).Vardist;
                        // Do not count same contract twice
                        if (lContract_no != idw_summary.GetItem<WhatifCalulator2005>(ldw1count).ContractNo)
                        {
                            lContract_no = idw_summary.GetItem<WhatifCalulator2005>(ldw1count).ContractNo;
                            if (RangeFrom == -(11000))
                            {
                                RangeFromTemp = Variance - 1;
                            }
                            else
                            {
                                RangeFromTemp = RangeFrom;
                            }
                            if (RangeFrom + OffsetFromRangeFrom > 10000)
                            {
                                d2ToTemp = Variance + 1;
                            }
                            else
                            {
                                d2ToTemp = RangeFrom + OffsetFromRangeFrom;
                            }
                            if (Variance >= RangeFromTemp && Variance <= d2ToTemp)
                            {
                                lContracts++;
                            }
                        }
                    }
                    idw_dist.SetValue(lRow, "contracts", lContracts);
                    lsumContracts = lsumContracts + lContracts;
                    idw_dist.SetValue(lRow, "sumcontracts", lsumContracts);
                    lRow++;
                }
            }
            store_group_distribution();
            this.ResumeLayout();
            return 0;
        }

        public virtual void store_group_distribution()
        {
            System.Data.DataTable table = new NZPostOffice.RDS.DataControls.Report.WhatifDistribution2001DataSet(idw_dist.BindingSource.DataSource);
            ((REDWhatifDistribution2001)((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_dist.GetControlByName("viewer")).ReportSource).SetDataSource(table);
            ((CrystalDecisions.Windows.Forms.CrystalReportViewer)idw_dist.GetControlByName("viewer")).RefreshReport();
        }

        public virtual int of_openfreqs(string as_objectatpointer)
        {
            int? lContract = 0;
            int lRow;
            int lConrow = 0;
            string sObjectAtPointer;
            NRdsMsg lnv_Msg;
            NCriteria lnv_Criteria;
            lnv_Msg = new NRdsMsg();
            lnv_Criteria = new NCriteria();
            if ((StaticVariables.gnv_app.of_isempty(as_objectatpointer)))
            {
                return 0;
            }
            if (as_objectatpointer.IndexOf("-") > 0)
                sObjectAtPointer = as_objectatpointer.Substring(0, as_objectatpointer.IndexOf("-"));//  TextUtil.Mid (as_objectatpointer, TextUtil.Pos (as_objectatpointer, '~') + 1);
            else
                sObjectAtPointer = as_objectatpointer;


            lRow = System.Convert.ToInt32(sObjectAtPointer);

            if (lRow >= 0)
            {
                lContract = idw_summary.GetItem<WhatifCalulator2005>(lRow).ContractNo;
                //?idw_summary.DataControl["st_contract"].Text = "\'" + lContract.ToString() + '\'');
                idw_summary.Left = idw_summary.Left;
                lConrow = idw_summary.Find("contract_no", lContract);//.Length);
            }
            lnv_Criteria.of_addcriteria("caller", this);
            lnv_Criteria.of_addcriteria("contract_no", lContract);
            lnv_Criteria.of_addcriteria("rateofreturn_1", idw_summary.GetItem<WhatifCalulator2005>(lRow).Rateofreturn1);
            lnv_Criteria.of_addcriteria("conrow", lConrow);
            lnv_Criteria.of_addcriteria("rowcount", idw_summary.RowCount);
            lnv_Criteria.of_addcriteria("deliveryhours", idw_summary.GetItem<WhatifCalulator2005>(lRow).Deliveryhours);
            lnv_Criteria.of_addcriteria("volume", idw_summary.GetItem<WhatifCalulator2005>(lRow).Volume);
            lnv_Criteria.of_addcriteria("effectivedate", id_EffectDate);
            lnv_Criteria.of_addcriteria("rgcode", il_RGCode);
            lnv_Msg.of_addcriteria(lnv_Criteria);
            //OpenWithParm(w_whatif_freqs2001, lnv_Msg);
            StaticMessage.PowerObjectParm = lnv_Msg;
            WWhatifFreqs2001 w_whatif_freqs2001 = new WWhatifFreqs2001();
            w_whatif_freqs2001.ShowDialog();
            return 1;
        }

        public virtual int of_showvehiclerates()
        {
            int ll_Ctr = 0;
            int ll_vtkey = 0;
            string ls_vt;
            decimal? ldec_nominal_vehicle_value;
            decimal? ldec_repairs_maintenance_rate;
            decimal? ldec_tyre_tubes_rate;
            decimal? ldec_vehicle_allowance_rate;
            decimal? ldec_licence_rate;
            decimal? ldec_vehicle_rate_of_return_pct;
            decimal? ldec_salvage_ratio;
            decimal? ldec_ruc;
            decimal? ldec_sundries_k;
            decimal? ldec_vehicle_value_insurance_pct;
            decimal? ldec_livery;
            decimal? ldec_vehicle_insurance_base_premium;
            //  TJB SR4560
            //  Added to hold override rate values
            decimal? ldec_vor_nominal_vehicle_value;
            decimal? ldec_vor_repairs_maintenance_rate;
            decimal? ldec_vor_tyre_tubes_rate;
            decimal? ldec_vor_vehicle_allowance_rate;
            decimal? ldec_vor_licence_rate;
            decimal? ldec_vor_vehicle_rate_of_return_pct;
            decimal? ldec_vor_salvage_ratio;
            decimal? ldec_vor_ruc;
            decimal? ldec_vor_sundries_k;
            decimal? ldec_vor_vehicle_insurance_premium;
            decimal? ldec_vor_livery;
            //  Need to set these to NULL because they initially default to 0n and
            //  if there are no override rates, there will be no nulls returned to
            //  set them to null, and the 0's will be used as the override values.
            ldec_vor_nominal_vehicle_value = null;
            ldec_vor_repairs_maintenance_rate = null;
            ldec_vor_tyre_tubes_rate = null;
            ldec_vor_vehicle_allowance_rate = null;
            ldec_vor_licence_rate = null;
            ldec_vor_vehicle_rate_of_return_pct = null;
            ldec_vor_salvage_ratio = null;
            ldec_vor_ruc = null;
            ldec_vor_sundries_k = null;
            ldec_vor_vehicle_insurance_premium = null;
            ldec_vor_livery = null;


            // vtList lists all vehicle types from rd.vehicle_type (vt_key and vt_description only)
            // ila_VtKeys lists the unique vehicle types in the contract(s) in the Whatif report
            //   - see of_isvtkeyinlist() and other places
            // vvList gets the full vehicle details for the vehicles in ila_VtKeys
            List<VehicleTypeItem> vtList = new List<VehicleTypeItem>();
            RDSDataService rService = RDSDataService.GetVehicleTypeList();
            vtList = rService.VehicleTypeList;

            //while (StaticVariables.sqlca.SQLCode == 0) 
            for (int i = 0; i < vtList.Count; i++)
            {
                ll_vtkey = vtList[i].VtKey;
                ls_vt = vtList[i].VtDescription;

                if (!(of_isvtkeyinlist(ll_vtkey)))
                {
                    continue;
                }
                ll_Ctr++;  // Counter for distinct vehicle types encountered

                if (ll_Ctr > 11)  // TJB RPCR_148 May-2020  Changed '== 4' to >11
                {
                    // TJB RPCR_148 May-2020
                    // Changed message text from "Some rates cannot be..."
                    ((TextObject)(((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_cannotdisplay"])).Text 
                        = "Some vehicle rates have not been displayed due to space limitations";
                    // Note: added field st_cannotdisplay to report so message could be displayed
                    //       Previously the field was not in the report and this code line was commented out
                    break;
                }

                ((TextObject)(((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_title" + ll_Ctr.ToString()])).Text = ls_vt;

                List<VehicleRateNonVehicleRateItem> vvList = new List<VehicleRateNonVehicleRateItem>();
                RDSDataService rdsService = RDSDataService.GetMoreValues1(ll_vtkey, id_EffectDate, il_RGCode);
                vvList = rdsService.VehicleRateNonVehicleRateList;

                ldec_nominal_vehicle_value = vvList[0].VrNominalVehicleValue;
                ldec_repairs_maintenance_rate = vvList[0].VrRepairsMaintenanceRate;
                ldec_tyre_tubes_rate = vvList[0].VrTyreTubesRate;

                ldec_vehicle_allowance_rate = vvList[0].VrVehicleAllowanceRate;
                ldec_licence_rate = vvList[0].VrLicenceRate;
                ldec_vehicle_rate_of_return_pct = vvList[0].VrVehicleRateOfReturnPct;

                ldec_salvage_ratio = vvList[0].VrSalvageRatio;
                ldec_ruc = vvList[0].VrRuc;
                ldec_sundries_k = vvList[0].VrSundriesK;

                ldec_vehicle_value_insurance_pct = vvList[0].VrVehicleValueInsurancePct;
                ldec_livery = vvList[0].VrLivery;
                ldec_vehicle_insurance_base_premium = vvList[0].NvrVehicleInsuranceBasePremium;

                //  TJB SR4560
                //  Get override rates if there's only one contract involved.
                //  il_contract (and il_sequence) will be set to the contract number 
                //  (in of_loadvtkeys) if there's only one contract; to 0 otherwise.
                if (il_contract != 0)
                {
                    //  Need to reset these for each contract vehicle
                    ldec_vor_nominal_vehicle_value = null;
                    ldec_vor_repairs_maintenance_rate = null;
                    ldec_vor_tyre_tubes_rate = null;
                    ldec_vor_vehicle_allowance_rate = null;
                    ldec_vor_licence_rate = null;
                    ldec_vor_vehicle_rate_of_return_pct = null;
                    ldec_vor_salvage_ratio = null;
                    ldec_vor_ruc = null;
                    ldec_vor_sundries_k = null;
                    ldec_vor_vehicle_insurance_premium = null;
                    ldec_vor_livery = null;

                    // TJB Frequencies & Vehicles 2-Mar-2021
                    // Added vt_key to GetVehicleOverrideRateList parameters; gets one of the
                    // sets of overrides if there is more than one vehicle of the same type.
                    List<VehicleOverrideRateItem> vlist = new List<VehicleOverrideRateItem>();
                    RDSDataService rdsService2 = RDSDataService.GetVehicleOverrideRateList(il_contract, il_sequence, ll_vtkey);
                    vlist = rdsService2.VehicleOverrideRateList;

                    if (vlist.Count > 0)
                    {
                        ldec_vor_nominal_vehicle_value = vlist[0].VorNominalVehicleValue;
                        ldec_vor_repairs_maintenance_rate = vlist[0].VorRepairsMaintenanceRate;
                        ldec_vor_tyre_tubes_rate = vlist[0].VorTyreTubesRate;
                        ldec_vor_vehicle_allowance_rate = vlist[0].VorVehicalAllowanceRate;
                        ldec_vor_licence_rate = vlist[0].VorLicenceRate;
                        ldec_vor_vehicle_rate_of_return_pct = vlist[0].VorVehicleRateOfReturnPct;
                        ldec_vor_salvage_ratio = vlist[0].VorSalvageRatio;
                        ldec_vor_ruc = vlist[0].VorRuc;
                        ldec_vor_sundries_k = vlist[0].VorSundriesK;
                        ldec_vor_vehicle_insurance_premium = vlist[0].VorVehicleInsurancePremium;
                        ldec_vor_livery = vlist[0].VorLivery;
                    }
                    //  Set override rates where not NULL
                    if (!(ldec_vor_nominal_vehicle_value == null))
                    {
                        ldec_nominal_vehicle_value = ldec_vor_nominal_vehicle_value;
                    }
                    if (!(ldec_vor_repairs_maintenance_rate == null))
                    {
                        ldec_repairs_maintenance_rate = ldec_vor_repairs_maintenance_rate;
                    }
                    if (!(ldec_vor_tyre_tubes_rate == null))
                    {
                        ldec_tyre_tubes_rate = ldec_vor_tyre_tubes_rate;
                    }
                    if (!(ldec_vor_vehicle_allowance_rate == null))
                    {
                        ldec_vehicle_allowance_rate = ldec_vor_vehicle_allowance_rate;
                    }
                    if (!(ldec_vor_vehicle_insurance_premium == null))
                    {
                        ldec_vehicle_insurance_base_premium = ldec_vor_vehicle_insurance_premium;
                    }
                    if (!(ldec_vor_licence_rate == null))
                    {
                        ldec_licence_rate = ldec_vor_licence_rate;
                    }
                    if (!(ldec_vor_vehicle_rate_of_return_pct == null))
                    {
                        ldec_vehicle_rate_of_return_pct = ldec_vor_vehicle_rate_of_return_pct;
                    }
                    if (!(ldec_vor_salvage_ratio == null))
                    {
                        ldec_salvage_ratio = ldec_vor_salvage_ratio;
                    }
                    if (!(ldec_vor_ruc == null))
                    {
                        ldec_ruc = ldec_vor_ruc;
                    }
                    if (!(ldec_vor_sundries_k == null))
                    {
                        ldec_sundries_k = ldec_vor_sundries_k;
                    }
                }
                CrystalDecisions.CrystalReports.Engine.ReportClass report = ((DWhatifCalculatorReport2005)idw_report).Report;
                TextObject txt;

                txt = report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_nominal_vehicle_value.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_repairs_maintenance_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_tyre_tubes_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_allowance_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_value_insurance_pct.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_insurance_base_premium.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_licence_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_rate_of_return_pct.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_salvage_ratio.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_ruc.GetValueOrDefault().ToString("#,##0.00");
                }
                txt = report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_sundries_k.GetValueOrDefault().ToString("#,##0.00");
                }
            }
            return 1;
        }

        public virtual int of_loadvtkeys()
        {
            int ll_Ctr;
            int ll_VtKey;
            DateTime tnow;
            tnow = System.DateTime.Now;// Now();
            int? ll_contract;
            bool lb_oneContract;
            string sVtList, sVtKey;
            int start, at, end, count;
            int nVtKey;

            il_contract = 0;
            lb_oneContract = false;
            for (ll_Ctr = 0; ll_Ctr < idw_summary.RowCount; ll_Ctr++)
            {
                //?StaticVariables.gnv_app.of_showstatus(ll_Ctr, idw_summary.RowCount, "Recalculating...");
                ll_VtKey = idw_summary.GetItem<WhatifCalulator2005>(ll_Ctr).Nvtkey.GetValueOrDefault();
                // TJB Frequencies & Vehicles  1-Feb-2021: Added
                // Get and parse the list of vehicle types for this contract
                // and add to the ila_VtKeys list.  ll_VtKey is no longer needed.
                sVtList = idw_summary.GetItem<WhatifCalulator2005>(ll_Ctr).VtList;
                end = sVtList.Length;
                start = 0;
                count = 0;
                at = 0;
                while ((start <= end) && (at > -1))
                {
                    count = end - start;
                    at = sVtList.IndexOf(",", start, count);
                    if (at == -1) break;
                    sVtKey = sVtList.Substring(start, (at - start));
                    if (Int32.TryParse(sVtKey, out nVtKey))
                    {
                        if (!(of_isvtkeyinlist(nVtKey)))
                        {
                            ila_VtKeys.Add(nVtKey);
                        }
                    }
                    start = at + 1;
                }
                
                ll_contract = idw_summary.GetItem<WhatifCalulator2005>(ll_Ctr).ContractNo;
                if (il_contract == 0)
                {
                    il_contract = ll_contract;
                    il_sequence = idw_summary.GetItem<WhatifCalulator2005>(ll_Ctr).ContractSeqNumber;
                    lb_oneContract = true;
                }
                else if (ll_contract != il_contract)
                {
                    lb_oneContract = false;
                }
                if (!(of_isvtkeyinlist(ll_VtKey)))
                {
                    ila_VtKeys.Add(ll_VtKey); 
                }
            }
            if (lb_oneContract == false)
            {
                il_contract = 0;
                il_sequence = 0;
            }

            return 1;
        }

        public virtual bool of_isvtkeyinlist(int? al_Vtkey)
        {
            int ll_Ctr;
            for (ll_Ctr = 0; ll_Ctr < ila_VtKeys.Count; ll_Ctr++)
            {
                if (ila_VtKeys[ll_Ctr] == al_Vtkey)
                {
                    return true;
                }
            }
            return false;
        }

        // TJB RPC_148 May-2020: New
        // Count the number of distinct vehicle types in the full report
        // (used to decide whether to make the second set of types visible)
        // Adapted from of_cachevtkeys (which doesn't appear to be used)
        public virtual int of_countuniquevtkeys()
        {
            int ll_Ctr = 0;
            int ll_vtkey = 0;

            List<VehicleTypeItem> vtList = new List<VehicleTypeItem>();
            RDSDataService rService = RDSDataService.GetVehicleTypeList();
            vtList = rService.VehicleTypeList;

            for (int i = 0; i < vtList.Count; i++)
            {
                ll_vtkey = vtList[i].VtKey;

                if (!(of_isvtkeyinlist(ll_vtkey)))
                {
                    continue;
                }
                ll_Ctr++;
            }
            return ll_Ctr;
        }

/*   TJB Feb-2021: obsolete
        public virtual int of_cachevtkeys()
        {
            // idw_report.dataobject = 'd_whatif_calculator_report2001bf3'
            int ll_Ctr = 0;
            int ll_vtkey = 0;
            string ls_vt;
            decimal? ldec_nominal_vehicle_value;
            decimal? ldec_repairs_maintenance_rate;
            decimal? ldec_tyre_tubes_rate;
            decimal? ldec_vehicle_allowance_rate;
            decimal? ldec_licence_rate;
            decimal? ldec_vehicle_rate_of_return_pct;
            decimal? ldec_salvage_ratio;
            decimal? ldec_ruc;
            decimal? ldec_sundries_k;
            decimal? ldec_vehicle_value_insurance_pct;
            decimal? ldec_livery;
            decimal? ldec_vehicle_insurance_base_premium;

            // vtList lists all vehicle types from rd.vehicle_type (vt_key and vt_description only)
            // ila_VtKeys lists the unique vehicle types in the contract(s) in the Whatif report
            // vvList gets the full vehicle details for the vehicles in ila_VtKeys
            List<VehicleTypeItem> vtList = new List<VehicleTypeItem>();
            RDSDataService rService = RDSDataService.GetVehicleTypeList();
            vtList = rService.VehicleTypeList;

            List<VehicleRateNonVehicleRateItem> vvList = new List<VehicleRateNonVehicleRateItem>();

            for (int i = 0; i < vtList.Count; i++)
            {
                ll_vtkey = vtList[i].VtKey;
                ls_vt = vtList[i].VtDescription;

                if (!(of_isvtkeyinlist(ll_vtkey)))
                {
                    //Skip if this key isn't one of the ones in ila_VtKeys
                    continue;
                }
                if (ll_Ctr >= 11)  // TJB Feb-2021: the limit was 4 and is now 11
                {
                    break;
                }
                ll_Ctr++;

                // Get the details for this vehicle
                RDSDataService rdsService = RDSDataService.GetMoreValues1(ll_vtkey, id_EffectDate, il_RGCode);
                vvList = rdsService.VehicleRateNonVehicleRateList;

                ldec_nominal_vehicle_value = vvList[0].VrNominalVehicleValue;
                ldec_repairs_maintenance_rate = vvList[0].VrRepairsMaintenanceRate;
                ldec_tyre_tubes_rate = vvList[0].VrTyreTubesRate;

                ldec_vehicle_allowance_rate = vvList[0].VrVehicleAllowanceRate;
                ldec_licence_rate = vvList[0].VrLicenceRate;
                ldec_vehicle_rate_of_return_pct = vvList[0].VrVehicleRateOfReturnPct;

                ldec_salvage_ratio = vvList[0].VrSalvageRatio;
                ldec_ruc = vvList[0].VrRuc;
                ldec_sundries_k = vvList[0].VrSundriesK;

                ldec_vehicle_value_insurance_pct = vvList[0].VrVehicleValueInsurancePct;
                ldec_livery = vvList[0].VrLivery;
                ldec_vehicle_insurance_base_premium = vvList[0].NvrVehicleInsuranceBasePremium;
            }

            return 1;
        }
*/
        public virtual void dw_summary_constructor()
        {
            //?base.constructor();
            idw_summary = dw_summary.DataObject;
            dw_summary.of_SetUpdateable(false);
        }

        public virtual void dw_whatifreport_constructor()
        {
            //?base.constructor();
            idw_report = dw_whatifreport.DataObject;
            dw_whatifreport.of_SetUpdateable(false);
        }

        public virtual void dw_distribution_constructor()
        {
            //?base.constructor();
            idw_dist = dw_distribution.DataObject;
            dw_distribution.of_SetUpdateable(false);
        }

        #endregion

        #region Events

        public override void resize(object sender, EventArgs args)
        {
            base.resize(sender, args);
            this.SuspendLayout();
            tab_1.Width = this.Width - 20;
            tab_1.Height = this.Height - 64;
            idw_summary.Width = this.Width - 70;
            idw_summary.Height = this.Height - 114;
            idw_report.Height = idw_summary.Height;
            idw_report.Width = idw_summary.Width;
            idw_dist.Height = idw_summary.Height;
            idw_dist.Width = idw_summary.Width;
            cb_print.Top = tab_1.Height + tab_1.Location.Y + 6;
            cb_close.Top = cb_print.Location.Y;
            cb_close.Left = this.Width - 81;
            cb_print.Left = cb_close.Location.X - 80;
            cb_showcalc.Top = cb_print.Location.Y;
            this.ResumeLayout();
        }

        public virtual void doubleclicked(object sender, EventArgs e)
        {
            /*?
            if (KeyDown(keycontrol!) && KeyDown(keyshift!)) {
                cb_showcalc.visible = true;
            }*/
            bool b_KeyCtrl = StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyCtrl);
            bool b_KeyShift = StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyShift);

            if ( b_KeyCtrl && b_KeyShift )
            {
                cb_showcalc.Visible = true;
                cb_showcalc.BringToFront();
            }
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void tab_1_selectionchanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string str = tab_1.TabPages[tab_1.SelectedIndex].Text.ToLower().Trim();
            if (str == "full report")
            {
                of_showreport();
            }
            if (str == "distribution report")
            {
                of_showdistribution();
            }
        }

        public virtual void dw_summary_clicked(object sender, EventArgs e)
        {
            int? lContract;
            int lRow;
            string sObjectAtPointer = "";
            //?sObjectAtPointer = dw_summary.GetObjectAtPointer();
            if (sObjectAtPointer != "")
            {
                sObjectAtPointer = sObjectAtPointer.Substring(sObjectAtPointer.IndexOf("~") + 1);
                lRow = System.Convert.ToInt32(sObjectAtPointer);
                if (lRow > 0)
                {
                    lContract = idw_summary.GetItem<WhatifCalulator2005>(lRow).ContractNo;
                }
            }
            this.ResumeLayout();
        }

        public virtual void dw_summary_doubleclicked(object sender, EventArgs e)
        {
            string ls_oap = "";
            ls_oap = ((Metex.Windows.DataEntityGrid)sender).CurrentColumnName;
            of_openfreqs(ls_oap);
        }

        public virtual void dw_summary_retrieveend(object sender, EventArgs e)
        {
            //?dw_summary.GroupCalc();
        }

        public virtual void dw_summary_retrievestart(object sender, EventArgs e)
        {
            return;//? 2;
        }

        public virtual void dw_whatifreport_retrievestart(object sender, EventArgs e)
        {
            return;// ?2;
        }

        public virtual void cb_print_clicked(object sender, EventArgs e)
        {
            int TestExpr = tab_1.SelectedIndex;
            if (TestExpr == 0)
            {
                ((DWhatifCalulator2005)idw_summary).Print();
            }
            else if (TestExpr == 1)
            {
                ((DWhatifCalculatorReport2005)idw_report).Print();
            }
            else if (TestExpr == 2)
            {
                ((DWhatifDistribution2001)idw_dist).Print();
            }
        }

        public virtual void cb_showcalc_clicked(object sender, EventArgs e)
        {
            DWhatifCalulator2005 dw = (DWhatifCalulator2005)idw_summary;
            dw.ShowReport();
            if (cb_showcalc.Text == "Show Calcs")
                cb_showcalc.Text = "Hide Calcs";
            else
                cb_showcalc.Text = "Show Calcs";
        }

        public void WWhatifCalc2001_DrillDownSubreport(object source, CrystalDecisions.Windows.Forms.DrillSubreportEventArgs e)
        {

        }

        public void WWhatifCalc2001_Drill(object source, CrystalDecisions.Windows.Forms.DrillEventArgs e)
        {
            //((CrystalDecisions.Windows.Forms.PageView)(source)).GetActiveDocument()..GroupTree.findSubtree(e.NewGroupNamePath)
            string ls_oap = "";
            int l_row = 0;
            int l_count = 0;
            if (e.NewGroupPath.IndexOf("-") > 0)
            {
                l_count = System.Convert.ToInt32(e.NewGroupPath.Substring(0, e.NewGroupPath.IndexOf("-")));
                l_row = System.Convert.ToInt32(e.NewGroupPath.Substring(e.NewGroupPath.IndexOf("-") + 1));
                if (l_count > 0)
                {
                    for (int i = 0; i < l_count; i++)
                    {
                        l_row += ((CrystalDecisions.Windows.Forms.PageView)(source)).GetActiveDocument().GroupTree.TreeRoot.SubGroupNodes[i].NumberOfChildren;
                    }
                }
            }
            else
            {
                l_count = System.Convert.ToInt32(e.NewGroupPath);
                if (l_count > 0)
                {
                    for (int i = 0; i < l_count; i++)
                    {
                        if (((CrystalDecisions.Windows.Forms.PageView)(source)).GetActiveDocument().GroupTree.TreeRoot.SubGroupNodes[i].NumberOfChildren == 0)
                        {
                            l_row += 1;
                        }
                        else
                        {
                            l_row += ((CrystalDecisions.Windows.Forms.PageView)(source)).GetActiveDocument().GroupTree.TreeRoot.SubGroupNodes[i].NumberOfChildren;
                        }
                    }
                }
            }
            of_openfreqs((l_row).ToString());
        }

        #endregion
    }
}
