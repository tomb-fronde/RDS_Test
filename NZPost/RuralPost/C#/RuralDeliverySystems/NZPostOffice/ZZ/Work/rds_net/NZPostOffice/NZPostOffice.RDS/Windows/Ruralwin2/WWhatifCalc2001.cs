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
        #region Define

        public List<int> ila_VtKeys = new List<int>();// IntArray ila_VtKeys = new IntArray();

        public DataUserControl idw_Crosstab;

        public int il_RGCode;

        public DateTime id_EffectDate = DateTime.MinValue;

        public List<decimal> idec_Current = new List<decimal>();// DecimalArray idec_Current = new DecimalArray();

        public decimal? id_RateOf;

        public List<decimal?> id_RateOfReturn = new List<decimal?>();// DecimalArray id_RateOfReturn = new DecimalArray();

        public string is_reportRenewal = String.Empty;

        public DataUserControl idw_summary;

        public DataUserControl idw_report;

        public DataUserControl idw_dist;

        //  TJB SR4560  Used to save contract number  ( in of_setup) for use by of_showVehicleRates 
        public int? il_contract;

        public int? il_sequence;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_close;

        public TabControl tab_1;

        public TabPage tabpage_1;

        public URdsDw dw_summary;

        public TabPage tabpage_2;

        public URdsDw dw_whatifreport;

        public TabPage tabpage_3;

        public URdsDw dw_distribution;

        public Button cb_print;

        public Button cb_how;

        public Button cb_not;

        public WStatus w_status = null;

        #endregion

        public WWhatifCalc2001()
        {
            this.InitializeComponent();

            //jlwang:moved from IC

            //((DWhatifCalulator2005)dw_summary.DataObject).CellDoubleClick += new EventHandler(dw_summary_doubleclicked);
            dw_summary.DataObject.RetrieveEnd += new EventHandler(dw_summary_retrieveend);
            dw_summary.DataObject.RetrieveStart += new RetrieveEventHandler(dw_summary_retrievestart);
            dw_summary.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_summary_constructor);

            dw_whatifreport.DataObject.RetrieveStart += new RetrieveEventHandler(dw_whatifreport_retrievestart);
            dw_whatifreport.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_whatifreport_constructor);

            dw_distribution.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_distribution_constructor);

            //jlwang;end
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
            this.cb_how = new Button();
            this.cb_not = new Button();
            Controls.Add(cb_close);
            Controls.Add(tab_1);
            Controls.Add(cb_print);
            Controls.Add(cb_how);
            Controls.Add(cb_not);
            this.Text = "Whatif Calculation";
            this.Height = 438;
            this.Width = 594;
            this.Top = 0;
            this.Left = 0;
            this.Name = "w_whatif_calc2001";
            this.DoubleClick += new EventHandler(doubleclicked);
            // 
            // st_label
            // 
            st_label.Location = new System.Drawing.Point(5, 390);
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
            tabpage_1 = new TabPage();
            tabpage_2 = new TabPage();
            tabpage_3 = new TabPage();
            tab_1.Controls.Add(tabpage_1);
            tab_1.Controls.Add(tabpage_2);
            tab_1.Controls.Add(tabpage_3);

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
            // tabpage_1
            // 
            dw_summary = new URdsDw();
            dw_summary.DataObject = new DWhatifCalulator2005();
            tabpage_1.Controls.Add(dw_summary);
            tabpage_1.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_1.Text = "Summary Report";
            tabpage_1.Name = tabpage_1.Text;//

            tabpage_1.Size = new System.Drawing.Size(565, 342);
            tabpage_1.Location = new System.Drawing.Point(3, 25);
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
            // tabpage_2
            // 
            dw_whatifreport = new URdsDw();
            dw_whatifreport.DataObject = new DWhatifCalculatorReport2005();
            tabpage_2.Controls.Add(dw_whatifreport);
            tabpage_2.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_2.Text = "Full Report";
            tabpage_2.Name = tabpage_2.Text;//

            tabpage_2.Size = new System.Drawing.Size(565, 342);
            tabpage_2.Location = new System.Drawing.Point(3, 25);
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
            // tabpage_3
            // 
            dw_distribution = new URdsDw();
            dw_distribution.DataObject = new DWhatifDistribution2001();
            tabpage_3.Controls.Add(dw_distribution);
            tabpage_3.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_3.Text = "Distribution Report";
            tabpage_3.Name = tabpage_3.Text;//

            tabpage_3.Size = new System.Drawing.Size(565, 342);
            tabpage_3.Location = new System.Drawing.Point(3, 25);
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
            // cb_how
            // 
            cb_how.Text = "ShowCalcs";
            cb_how.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_how.TabIndex = 4;
            cb_how.Size = new System.Drawing.Size(66, 22);
            cb_how.Location = new System.Drawing.Point(7, 379);
            cb_how.Visible = false;
            cb_how.Click += new EventHandler(cb_how_clicked);
            // 
            // cb_not
            // 
            cb_not.Text = "Hide Calcs";
            cb_not.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            cb_not.TabIndex = 5;
            cb_not.Location = new System.Drawing.Point(78, 379);
            cb_not.Size = new System.Drawing.Size(70, 22);
            cb_not.Visible = false;
            cb_not.Click += new EventHandler(cb_not_clicked);
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
            this.BringToFront();// BringToTop = true;
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
            int ll_Count;
            int ll_Ctr;
            NRdsMsg lnv_Msg;
            NCriteria lnv_Criteria;
            WBenchmarkRates2001 lw_Rates;

            //DECLARE GetRouteFreq CURSOR FOR  
            //SELECT	route_frequency.sf_key, route_frequency.rf_delivery_days, route_frequency.rf_distance  
            //FROM route_frequency WHERE 	route_frequency.rf_active = 'Y' AND route_frequency.contract_no = :ll_Contract;



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

            ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(0);
            ll_Count = 0;
            ll_Ctr = 0;
            while (!(ll_RateRow == -1))
            {
                ll_Count++;
                ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(ll_RateRow + 1);
            }
            // Loop through the caller's datawindow's contract list
            ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(0);
            ll_NumContracts = lw_Rates.dw_listing.RowCount;

            while (!(ll_RateRow == -1))
            {
                // yield ( )
                ll_Ctr++;
                StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Ctr, ll_Count, "Retrieving Rates...");
                ll_Contracts++;
                ll_Contract = lw_Rates.dw_listing.GetItem<WhatifContractSelection>(ll_RateRow).ContractNo;//lw_Rates.dw_listing.getitemnumber(ll_RateRow, "contract_no");
                ll_Sequence = lw_Rates.dw_listing.GetItem<WhatifContractSelection>(ll_RateRow).ContractSeqNumber;
                ll_FirstRow = -1;
                // Get frequencies

                //OPEN GetRouteFreq
                //FETCH GetRouteFreq INTO :ll_SfKey, :ls_DelDays, :ldec_Distance;
                List<RouteFrequencyItem> rfList = new List<RouteFrequencyItem>();
                RDSDataService rService = RDSDataService.GetRouteFrequencyList(ll_Contract.GetValueOrDefault());
                rfList = rService.RoutFrequencyList;
                for (int i = 0; i < rfList.Count; i++) //while (StaticVariables.sqlca.SQLCode == 0)
                {
                    ll_SfKey = rfList[i].SfKey;
                    ls_DelDays = rfList[i].RfDeliveryDays;
                    ldec_Distance = rfList[i].RfDistance;

                    if (ll_FirstRow == -1)
                    {
                        ((DWhatifCalulator2005)idw_summary).Retrieve(ll_Contract, ll_Sequence, il_RGCode, ld_EffectDate, ls_VolumeSource);
                        // Store vt_keys
                        //?idw_summary.GroupCalc();
                        ll_FirstRow = idw_summary.RowCount - 1;
                        idw_summary.SetValue(ll_FirstRow, "firstrow", "Y");
                        ll_numberboxholders = idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Numberboxholders;//.GetItemNumber(ll_FirstRow, "numberboxholders");
                        if (ll_numberboxholders > 0)
                        {
                            ll_volume = (int)idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Volume;//.GetItemNumber(ll_FirstRow, "volume");
                            idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Itemspercust = Math.Round(System.Convert.ToDecimal(ll_volume) / System.Convert.ToDecimal(ll_numberboxholders), 3);
                        }
                        else
                        {
                            idw_summary.GetItem<WhatifCalulator2005>(ll_FirstRow).Itemspercust = 0m;
                        }
                    }
                    else
                    {
                        ((DWhatifCalulator2005)idw_summary).Retrieve(ll_Contract, ll_Sequence, il_RGCode, ld_EffectDate, ls_VolumeSource);
                        //?idw_summary.RowsCopy(ll_FirstRow, ll_FirstRow, primary!, idw_summary, idw_summary.RowCount + 1, primary!);
                        idw_summary.SetValue(idw_summary.RowCount - 1, "firstrow", "N");
                        idw_summary.GetItem<WhatifCalulator2005>(idw_summary.RowCount - 1).Itemspercust = idw_summary.GetItem<WhatifCalulator2005>(idw_summary.RowCount - 2).Itemspercust;
                    }
                    ll_Row = idw_summary.RowCount - 1;
                    idw_summary.SetValue(ll_Row, "sf_key", ll_SfKey);
                    idw_summary.SetValue(ll_Row, "rf_deliverydays", ls_DelDays);
                    idw_summary.SetValue(ll_Row, "rf_distance", ldec_Distance);

                    //select rtd_days_per_annum into :ll_DaysYear from rate_days where rg_code = :il_RGCode and rr_rates_effective_date = :ld_EffectDate and sf_key = :ll_SfKey;
                    ll_DaysYear = RDSDataService.GetRateDaysValue(il_RGCode, ld_EffectDate, ll_SfKey);
                    idw_summary.SetValue(ll_Row, "rf_daysyear", ll_DaysYear);
                    //FETCH GetRouteFreq INTO :ll_SfKey, :ls_DelDays, :ldec_Distance;
                }
                //CLOSE GetRouteFreq
                ll_RateRow = lw_Rates.dw_listing.GetSelectedRow(ll_RateRow + 1);
            }

            ll_RowCount = idw_summary.RowCount;
            store_group_value();
            //?idw_summary.GroupCalc();
            if (ll_RowCount > 0)
            {
                for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
                {
                    StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Row, ll_RowCount, "Calculating final benchmark...");
                    idec_Current.Add(idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Opcost);// idec_Current[ll_Row] = idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Opcost;//.GetItemNumber(ll_Row, "opcost");
                    idw_summary.SetValue(ll_Row, "finalbenchmark", System.Convert.ToInt32(idec_Current[ll_Row]));
                }
                if (idw_summary.GetControlByName("st_contract") != null)
                    idw_summary.GetControlByName("st_contract").Text = "\'" + idw_summary.GetItem<WhatifCalulator2005>(0).ContractNo.ToString() + "\'";//idw_summary.DataControl["st_contract"].Text = "\'" + String((DWhatifCalulator2005)idw_summary.GetItemNumber(1, "contract_no")) + '\'');
                if (idw_summary.GetControlByName("st_no_contracts") != null)
                    idw_summary.GetControlByName("st_no_contracts").Text = "\'" + ll_Contracts.ToString() + "\'";//idw_summary.DataControl["st_no_contracts"].Text = "\'" + ll_Contracts.ToString() + '\'');
                if (ll_RowCount > 0)
                {
                    for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
                    {
                        id_RateOfReturn.Add(idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Rateofreturn1);// id_RateOfReturn[ll_Row] = (decimal)idw_summary.GetItem<WhatifCalulator2005>(ll_Row).Rateofreturn1;//.GetItemNumber(ll_Row, "rateofreturn_1");
                    }
                }
            }
            store_group_value();

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
            int j = 0;
            l_contract_no_old = idw_summary.GetItem<WhatifCalulator2005>(0).ContractNo;
            for (int i = 0; i < idw_summary.RowCount; i++)
            {
                l_contract_no = idw_summary.GetItem<WhatifCalulator2005>(i).ContractNo;
                if (l_contract_no == l_contract_no_old)
                {
                    if (idw_summary.GetItem<WhatifCalulator2005>(i).RfActive == "Y")
                    {
                        l_group += idw_summary.GetItem<WhatifCalulator2005>(i).RfDistance * idw_summary.GetItem<WhatifCalulator2005>(i).RfDaysyear;
                    }
                    else
                    {
                    }
                }
                else
                {
                    for (int k = j; k < i; k++)
                    {
                        idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance = l_group;
                    }
                    l_group = idw_summary.GetItem<WhatifCalulator2005>(i).RfDistance * idw_summary.GetItem<WhatifCalulator2005>(i).RfDaysyear;
                    j = i;
                }
            }
            for (int k = j; k < idw_summary.RowCount; k++)
            {
                idw_summary.GetItem<WhatifCalulator2005>(k).Calcroutedistance = l_group.GetValueOrDefault();
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
            //?idw_report.Modify("datawindow.print.preview=yes");
            dwc1 = idw_summary.GetChild("dw_rates");
            dwc2 = idw_report.GetChild("dw_rates");
            of_showvehiclerates();

            //?dwc2.Retrieve(il_RGCode, id_EffectDate );
            //idw_summary.ShareData(idw_report
            idw_report.Reset();

            for (int i = 0; i < idw_summary.RowCount; i++)
            {
                WhatifCalculatorReport2005 l_temp = new WhatifCalculatorReport2005();
                WhatifCalulator2005 data = idw_summary.GetItem<WhatifCalulator2005>(i);
                l_temp.ContractNo = data.ContractNo;
                l_temp.ContractSeqNumber = data.ContractSeqNumber;
                l_temp.ConTitle = data.ConTitle;
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
                idw_report.InsertItem<WhatifCalculatorReport2005>(i, l_temp);
            }
            store_group_report();
            if (dwc2 != null)
            {
                dwc1.ShareData(dwc2);
            }
            //?idw_report.DataControl["st_renewals"].Text = "\'" + is_reportRenewal + '\'');
            //?idw_report.GroupCalc();
            idw_report.Visible = true;
            //?idw_report.Focus();
            //?idw_report.Modify("datawindow.print.preview.zoom=" + 90).ToString();
            this.ResumeLayout();
            return 1;
        }

        public virtual void store_group_report()
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
            decimal? l_Totacc = 0;
            decimal? l_Totwd = 0;
            decimal? l_Totwp = 0;
            decimal? l_Totwr = 0;
            l_contract_no_old = idw_report.GetItem<WhatifCalculatorReport2005>(0).ContractNo;
            l_Totacc = idw_report.GetItem<WhatifCalculatorReport2005>(0).Acccost.GetValueOrDefault();
            l_Totwd = idw_report.GetItem<WhatifCalculatorReport2005>(0).Delcosts.GetValueOrDefault();
            l_Totwp = idw_report.GetItem<WhatifCalculatorReport2005>(0).Proccosts.GetValueOrDefault();
            l_Totwr = idw_report.GetItem<WhatifCalculatorReport2005>(0).Relcosts.GetValueOrDefault();
            for (int i = 0; i < idw_report.RowCount; i++)
            {
                l_contract_no = idw_report.GetItem<WhatifCalculatorReport2005>(i).ContractNo;
                if (l_contract_no == l_contract_no_old)
                {
                }
                else
                {
                    l_Totacc += idw_report.GetItem<WhatifCalculatorReport2005>(i).Acccost.GetValueOrDefault();
                    l_Totwd += idw_report.GetItem<WhatifCalculatorReport2005>(i).Delcosts.GetValueOrDefault();
                    l_Totwp += idw_report.GetItem<WhatifCalculatorReport2005>(i).Proccosts.GetValueOrDefault();
                    l_Totwr += idw_report.GetItem<WhatifCalculatorReport2005>(i).Relcosts.GetValueOrDefault();
                }
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
                    l_Stelephone = idw_report.GetItem<WhatifCalculatorReport2005>(i).Telephone;
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

            //pp! ADDED CODE - update vehicle rates which are not binded but assigned from app code           
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
                        //FETCH c_vtype INTO :ll_vtkey, :ls_vt;
                        continue;
                    }

                    ll_Ctr++;
                    WhatifCalculatorReport2005 item = idw_report.GetItem<WhatifCalculatorReport2005>(k);

                    //?idw_report.Modify("st_nvv" + ll_Ctr.ToString() + ".text=\'" + String(ldec_nominal_vehicle_value, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_nominal_vehicle_value.GetValueOrDefault().ToString("#,##0.00");
                            item.RrrateNomvehicle.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_rm" + ll_Ctr.ToString() + ".text=\'" + String(ldec_repairs_maintenance_rate, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject).Text)
                         || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_repairs_maintenance_rate.GetValueOrDefault().ToString("#,##0.00");
                            item.RERrrateRepairsmaint.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_t" + ll_Ctr.ToString() + ".text=\'" + String(ldec_tyre_tubes_rate, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_tyre_tubes_rate.GetValueOrDefault().ToString("#,##0.00");
                            item.RrrateTyretubes.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_va" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_allowance_rate, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject).Text)
                         || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_vehicle_allowance_rate.GetValueOrDefault().ToString("#,##0.00");
                            item.RrrateVehallow.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_vi" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_value_insurance_pct, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_vehicle_value_insurance_pct.GetValueOrDefault().ToString("#,##0.00");
                            item.RERrrateVehinsurance.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_via" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_insurance_base_premium, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_vehicle_insurance_base_premium.GetValueOrDefault().ToString("#,##0.00");
                        item.RrrateVehinsurance.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_l" + ll_Ctr.ToString() + ".text=\'" + String(ldec_licence_rate, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_licence_rate.GetValueOrDefault().ToString("#,##0.00");
                            item.RERrrateLicense.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_vrr" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_rate_of_return_pct, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_vehicle_rate_of_return_pct.GetValueOrDefault().ToString("#,##0.00");
                            item.RERrrateVehrateofreturn.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_sr" + ll_Ctr.ToString() + ".text=\'" + String(ldec_salvage_ratio, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_salvage_ratio.GetValueOrDefault().ToString("#,##0.00");
                            item.Salvageratio.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_ruc" + ll_Ctr.ToString() + ".text=\'" + String(ldec_ruc, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject).Text)
                        || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_ruc.GetValueOrDefault().ToString("#,##0.00");            
                            item.RERrrateRuc.GetValueOrDefault().ToString("#,##0.00");
                    }

                    //?idw_report.Modify("st_sk" + ll_Ctr.ToString() + ".text=\'" + String(ldec_sundries_k, "#,##0.00") + '\'');
                    if (string.IsNullOrEmpty((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject).Text)
                         || ((((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject).Text) == "0.00"
                        )
                    {
                        (((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject).Text =
                            //!ldec_sundries_k.GetValueOrDefault().ToString("#,##0.00");         
                            item.RERrrateSundriesk.GetValueOrDefault().ToString("#,##0.00");
                    }
                }
            }
            //pp! EOF ADDED CODE - update vehicle rates which are not binded but assigned from app code           

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
                    /*lRow =*/
                    //idw_dist.InsertItem<WhatifDistribution2001>(0);//.InsertRow(0);
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
            // idw_dist.print ( true)
            //?idw_dist.Modify("datawindow.print.preview=yes");
            //?idw_dist.Modify("datawindow.print.preview.zoom=" + 90).ToString();
            //?((DWhatifDistribution2001)idw_dist).RefreshData();

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

            /*
            DECLARE c_vtype CURSOR FOR
            SELECT  vt_key,vt_description FROM vehicle_type where vt_key = 2 
            union SELECT  vt_key, vt_description FROM vehicle_type where vt_key = 1
            union SELECT  vt_key, vt_description FROM vehicle_type where vt_key not in  ( 1, 2);
            OPEN c_vtype FETCH c_vtype INTO :ll_vtkey, :ls_vt;*/

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
                    //FETCH c_vtype INTO :ll_vtkey, :ls_vt;
                    continue;
                }
                if (ll_Ctr == 4)
                {
                    //idw_report.DataControl["st_cannotdisplay"].Text = "\'Some rates cannot be displayed due to space limitations\'";
                    ((TextObject)(((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_cannotdisplay"])).Text = "Some rates cannot be displayed due to space limitations";
                    break;
                }
                ll_Ctr++;

                //idw_report.Modify("st_title" + ll_Ctr.ToString() + ".text=\'" + ls_vt + '\'');
                ((TextObject)(((DWhatifCalculatorReport2005)idw_report).Report.ReportDefinition.ReportObjects["st_title" + ll_Ctr.ToString()])).Text = ls_vt;

                /*
                SELECT vr_nominal_vehicle_value, vr_repairs_maintenance_rate, vr_tyre_tubes_rate,   
                vr_vehicle_allowance_rate, vr_licence_rate, vr_vehicle_rate_of_return_pct,   
                vr_salvage_ratio, vr_ruc, vr_sundries_k, vr_vehicle_value_insurance_pct,   
                vr_livery, nvr_vehicle_insurance_base_premium
                INTO :ldec_nominal_vehicle_value, :ldec_repairs_maintenance_rate, :ldec_tyre_tubes_rate,
                :ldec_vehicle_allowance_rate, :ldec_licence_rate, :ldec_vehicle_rate_of_return_pct,
                :ldec_salvage_ratio, :ldec_ruc, :ldec_sundries_k, :ldec_vehicle_value_insurance_pct,
                :ldec_livery, :ldec_vehicle_insurance_base_premium
                FROM vehicle_rate, non_vehicle_rate 
                WHERE vt_key = :ll_vtkey AND vr_rates_effective_date =  :id_effectdate 
                AND non_vehicle_rate.nvr_rates_effective_date  = vehicle_rate.vr_rates_effective_date 
                AND non_vehicle_rate.rg_code = :il_rgcode ;
                */

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
                //  il_contract  ( and il_sequence) will be set to the contract number 
                //   ( in of_loadvtkeys) if there's only one contract; to 0 otherwise.
                if (il_contract != 0)
                {
                    /*
                    SELECT first vor_nominal_vehicle_value ,vor_repairs_maintenance_rate ,vor_tyre_tubes_rate
                    ,vor_vehical_allowance_rate ,vor_licence_rate ,vor_vehicle_rate_of_return_pct
                    ,vor_salvage_ratio ,vor_ruc ,vor_sundries_k ,vor_vehicle_insurance_premium ,vor_livery
                    INTO :ldec_vor_nominal_vehicle_value , :ldec_vor_repairs_maintenance_rate ,
                    :ldec_vor_tyre_tubes_rate , :ldec_vor_vehicle_allowance_rate , :ldec_vor_licence_rate , 
                    :ldec_vor_vehicle_rate_of_return_pct , :ldec_vor_salvage_ratio , :ldec_vor_ruc ,
                    :ldec_vor_sundries_k , :ldec_vor_vehicle_insurance_premium , :ldec_vor_livery 
                    FROM vehicle_override_rate
                    WHERE contract_no = :il_contract and contract_seq_number = :il_sequence 
                    order by vor_effective_date desc;
                   */
                    List<VehicleOverrideRateItem> vlist = new List<VehicleOverrideRateItem>();
                    RDSDataService rdsService2 = RDSDataService.GetVehicleOverrideRateList(il_contract, il_sequence);
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

                //?idw_report.Modify("st_nvv" + ll_Ctr.ToString() + ".text=\'" + String(ldec_nominal_vehicle_value, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_nvv" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_nominal_vehicle_value.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_rm" + ll_Ctr.ToString() + ".text=\'" + String(ldec_repairs_maintenance_rate, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_rm" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_repairs_maintenance_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_t" + ll_Ctr.ToString() + ".text=\'" + String(ldec_tyre_tubes_rate, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_t" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_tyre_tubes_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_va" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_allowance_rate, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_va" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_allowance_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_vi" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_value_insurance_pct, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_vi" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_value_insurance_pct.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_via" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_insurance_base_premium, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_via" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_insurance_base_premium.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_l" + ll_Ctr.ToString() + ".text=\'" + String(ldec_licence_rate, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_l" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_licence_rate.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_vrr" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_rate_of_return_pct, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_vrr" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_vehicle_rate_of_return_pct.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_sr" + ll_Ctr.ToString() + ".text=\'" + String(ldec_salvage_ratio, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_sr" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_salvage_ratio.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_ruc" + ll_Ctr.ToString() + ".text=\'" + String(ldec_ruc, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_ruc" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_ruc.GetValueOrDefault().ToString("#,##0.00");
                }
                //?idw_report.Modify("st_sk" + ll_Ctr.ToString() + ".text=\'" + String(ldec_sundries_k, "#,##0.00") + '\'');
                txt = report.ReportDefinition.ReportObjects["st_sk" + ll_Ctr.ToString()] as TextObject;
                if (txt != null)
                {
                    txt.Text = ldec_sundries_k.GetValueOrDefault().ToString("#,##0.00");
                }

                //FETCH c_vtype INTO :ll_vtkey, :ls_vt;
            }
            //?CLOSE c_vtype

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
            il_contract = 0;
            lb_oneContract = false;
            for (ll_Ctr = 0; ll_Ctr < idw_summary.RowCount; ll_Ctr++)
            {
                //?StaticVariables.gnv_app.of_showstatus(ll_Ctr, idw_summary.RowCount, "Recalculating...");
                ll_VtKey = idw_summary.GetItem<WhatifCalulator2005>(ll_Ctr).Nvtkey.GetValueOrDefault();
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
                    ila_VtKeys.Add(ll_VtKey); //ila_VtKeys[ila_VtKeys.Count + 1] = ll_VtKey;
                }
            }
            if (lb_oneContract == false)
            {
                il_contract = 0;
                il_sequence = 0;
            }

            /*?
             while (SecondsAfter(tnow, Now()) < 1)
             {
             }
              */
            //?StaticVariables.gnv_app.of_hidestatus();
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
            /*
            DECLARE c_vtype CURSOR FOR
            SELECT  vt_key, vt_description FROM vehicle_type where vt_key = 2 union
            SELECT  vt_key, vt_description FROM vehicle_type where vt_key = 1 union
            SELECT  vt_key, vt_description FROM vehicle_type where vt_key not in  ( 1, 2);
            OPEN c_vtype
            FETCH c_vtype INTO :ll_vtkey, :ls_vt;
            while (StaticVariables.sqlca.SQLCode == 0)
             */

            List<VehicleTypeItem> vtList = new List<VehicleTypeItem>();
            RDSDataService rService = RDSDataService.GetVehicleTypeList();
            vtList = rService.VehicleTypeList;

            //while (StaticVariables.sqlca.SQLCode == 0) {
            for (int i = 0; i < vtList.Count; i++)
            {
                ll_vtkey = vtList[i].VtKey;
                ls_vt = vtList[i].VtDescription;

                if (!(of_isvtkeyinlist(ll_vtkey)))
                {
                    //FETCH c_vtype INTO :ll_vtkey, :ls_vt;
                    continue;
                }
                if (ll_Ctr == 4)
                {
                    //?idw_report.DataControl["st_cannotdisplay"].Text = "\'Some rates cannot be displayed due to space limitations\'";
                    break;
                }
                ll_Ctr++;
                // set title
                //?idw_report.Modify("st_title" + ll_Ctr.ToString() + ".text=\'" + ls_vt + '\'');
                // get rates

                /*
                SELECT vr_nominal_vehicle_value,vr_repairs_maintenance_rate,vr_tyre_tubes_rate,vr_vehicle_allowance_rate,   
                vr_licence_rate,vr_vehicle_rate_of_return_pct,vr_salvage_ratio,vr_ruc,   
                vr_sundries_k,vr_vehicle_value_insurance_pct,vr_livery,nvr_vehicle_insurance_base_premium
                INTO  :ldec_nominal_vehicle_value,:ldec_repairs_maintenance_rate,:ldec_tyre_tubes_rate,
                :ldec_vehicle_allowance_rate,:ldec_licence_rate,:ldec_vehicle_rate_of_return_pct,
                :ldec_salvage_ratio,:ldec_ruc,:ldec_sundries_k,
                :ldec_vehicle_value_insurance_pct,:ldec_livery,:ldec_vehicle_insurance_base_premium
                FROM vehicle_rate,non_vehicle_rate  
                WHERE vt_key = :ll_vtkey  AND  
                vr_rates_effective_date =  :id_effectdate and 
                non_vehicle_rate.nvr_rates_effective_date  = vehicle_rate.vr_rates_effective_date and   
                non_vehicle_rate.rg_code = :il_rgcode ;
                */

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
                // set rates
                //?idw_report.Modify("st_nvv" + ll_Ctr.ToString() + ".text=\'" + String(ldec_nominal_vehicle_value, "#,##0.00") + '\'');
                //?idw_report.Modify("st_rm" + ll_Ctr.ToString() + ".text=\'" + String(ldec_repairs_maintenance_rate, "#,##0.00") + '\'');
                //?idw_report.Modify("st_t" + ll_Ctr.ToString() + ".text=\'" + String(ldec_tyre_tubes_rate, "#,##0.00") + '\'');
                //?idw_report.Modify("st_va" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_allowance_rate, "#,##0.00") + '\'');
                //?idw_report.Modify("st_vi" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_value_insurance_pct, "#,##0.00") + '\'');
                //?idw_report.Modify("st_via" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_insurance_base_premium, "#,##0.00") + '\'');
                //?idw_report.Modify("st_l" + ll_Ctr.ToString() + ".text=\'" + String(ldec_licence_rate, "#,##0.00") + '\'');
                //?idw_report.Modify("st_vrr" + ll_Ctr.ToString() + ".text=\'" + String(ldec_vehicle_rate_of_return_pct, "#,##0.00") + '\'');
                //?idw_report.Modify("st_sr" + ll_Ctr.ToString() + ".text=\'" + String(ldec_salvage_ratio, "#,##0.00") + '\'');
                //?idw_report.Modify("st_ruc" + ll_Ctr.ToString() + ".text=\'" + String(ldec_ruc, "#,##0.00") + '\'');
                //?idw_report.Modify("st_sk" + ll_Ctr.ToString() + ".text=\'" + String(ldec_sundries_k, "#,##0.00") + '\'');

                //FETCH c_vtype INTO :ll_vtkey, :ls_vt;
            }
            //CLOSE c_vtype

            // idw_report.DataControl["st_title1"].Text = "'FUCK OFF'")
            return 1;
        }

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
            idw_dist.Height = idw_summary.Height;
            idw_report.Width = idw_summary.Width;
            idw_dist.Width = idw_summary.Width;
            cb_print.Top = tab_1.Height + tab_1.Location.Y + 6;
            cb_close.Top = cb_print.Location.Y;
            cb_close.Left = this.Width - 81;
            cb_print.Left = cb_close.Location.X - 80;
            cb_how.Top = cb_print.Location.Y;
            cb_not.Top = cb_how.Location.Y;
            this.ResumeLayout();
        }

        public virtual void doubleclicked(object sender, EventArgs e)
        {
            /*?
            if (KeyDown(keycontrol!) && KeyDown(keyshift!)) {
                cb_not.visible = true;
                cb_how.visible = true;
            }*/
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyCtrl) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyShift))
            {
                cb_not.Visible = true;
                cb_how.Visible = true;

                cb_not.BringToFront();
                cb_how.BringToFront();
            }
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            // dw_1.saveas ( )
            this.Close();
        }

        public virtual void tab_1_selectionchanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string str = tab_1.TabPages[tab_1.SelectedIndex].Text.ToLower().Trim();
            if (str == "full report") //(tab_1.SelectedIndex == 1)// (newindex == 2)
            {
                of_showreport();
            }
            if (str == "distribution report")//(tab_1.SelectedIndex == 2) //(newindex == 3)
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
            if (sObjectAtPointer != "")// (!(StaticVariables.gnv_app.of_isempty(sObjectAtPointer))) 
            {
                sObjectAtPointer = sObjectAtPointer.Substring(sObjectAtPointer.IndexOf("~") + 1);//  TextUtil.Mid (sObjectAtPointer, TextUtil.Pos (sObjectAtPointer, '~') + 1);
                lRow = System.Convert.ToInt32(sObjectAtPointer);
                if (lRow > 0)
                {
                    lContract = idw_summary.GetItem<WhatifCalulator2005>(lRow).ContractNo;//.GetItemNumber(lRow, "contract_no");
                    //?idw_summary.DataControl["st_contract"].Text = "\'" + lContract.ToString() + '\'');
                }
            }
            this.ResumeLayout(); //SetRedraw(true);
        }

        public virtual void dw_summary_doubleclicked(object sender, EventArgs e)
        {
            string ls_oap = "";
            ls_oap = ((Metex.Windows.DataEntityGrid)sender).CurrentColumnName;//dw_summary.GetObjectAtPointer();
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
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int TestExpr = tab_1.SelectedIndex;//.SelectedTab;
            if (TestExpr == 0)//1)
            {
                ((DWhatifCalulator2005)idw_summary).Print();
            }
            else if (TestExpr == 1)//2)
            {
                ((DWhatifCalculatorReport2005)idw_report).Print();
            }
            else if (TestExpr == 2)//3)
            {
                ((DWhatifDistribution2001)idw_dist).Print();
            }
        }

        public virtual void cb_how_clicked(object sender, EventArgs e)
        {
            //?idw_summary.Modify("DataWindow.Trailer.1.Height=2500");
            //?idw_summary.Modify("DataWindow.Detail.Height=444");
            //?idw_summary.Modify("datawindow.print.preview=yes");

            DWhatifCalulator2005 dw = (DWhatifCalulator2005)idw_summary;
            dw.ShowReport();
        }

        public virtual void cb_not_clicked(object sender, EventArgs e)
        {
            //?idw_summary.Modify("DataWindow.Trailer.1.Height=76");
            //?idw_summary.Modify("DataWindow.Detail.Height=0");
            //?idw_summary.Modify("datawindow.print.preview=NO");

            DWhatifCalulator2005 dw = (DWhatifCalulator2005)idw_summary;
            dw.ShowReport();
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
