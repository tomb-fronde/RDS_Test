using System;
using System.Windows.Forms;
using System.Collections.Generic;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WBenchmarkRates2001 : WAncestorWindow
    {
        #region Define
        public int? il_region;

        public int? il_rg_code;

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_renewals;

        public URdsDw dw_criteria;

        public URdsDw dw_listing;

        public RadioButton rb_last_article_count;

        public RadioButton rb_last_but_one_article_count;

        public RadioButton rb_average_article_count;

        public RadioButton rb_last_renewal;

        public GroupBox gb_3;

        public GroupBox gb_2;

        public GroupBox gb_1;

        public Button cb_selectall;

        public Button cb_deselectall;

        public Button cb_runwhatif;

        public Button cb_showrates;

        public Button cb_1;

        public Button cb_newrates;

        #endregion

        public WBenchmarkRates2001()
        {
            this.InitializeComponent();

            this.dw_renewals.DataObject = new DRenewalDates2001a();
            dw_renewals.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_criteria.DataObject = new DBenchmarkCalcCriteria();
            this.dw_listing.DataObject = new DWhatifContractSelection();
            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_listing.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            ((DRenewalDates2001a)dw_renewals.DataObject).CellDoubleClick += new EventHandler(dw_renewals_doubleclicked);
            dw_renewals.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_renewals_constructor);
            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);
            ((DWhatifContractSelection)dw_listing.DataObject).CellDoubleClick += new EventHandler(dw_listing_doubleclicked);
            dw_listing.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_listing_constructor);
            //jlwagn:end
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_renewals = new URdsDw();
//!            this.dw_renewals.DataObject = new DRenewalDates2001a();
            this.dw_criteria = new URdsDw();
//!            this.dw_criteria.DataObject = new DBenchmarkCalcCriteria();
            this.dw_listing = new URdsDw();
//!            this.dw_listing.DataObject = new DWhatifContractSelection();
            this.rb_last_article_count = new RadioButton();
            this.rb_last_but_one_article_count = new RadioButton();
            this.rb_average_article_count = new RadioButton();
            this.rb_last_renewal = new RadioButton();
            this.gb_3 = new GroupBox();
            this.gb_2 = new GroupBox();
            this.gb_1 = new GroupBox();
            this.cb_selectall = new Button();
            this.cb_deselectall = new Button();
            this.cb_runwhatif = new Button();
            this.cb_showrates = new Button();
            this.cb_1 = new Button();
            this.cb_newrates = new Button();

           
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Rates/What-If";
            this.Location = new System.Drawing.Point(1, 1);
            this.Size = new System.Drawing.Size(638, 433);
            // 
            // st_label
            // 
            st_label.Text = "w_benchmark_rates2001";
            st_label.Height = 17;
            st_label.Top = 374;
            // 
            // dw_renewals
            // 
            dw_renewals.TabIndex = 5;
            dw_renewals.Location = new System.Drawing.Point(10, 80);
            dw_renewals.Size = new System.Drawing.Size(284, 253);
            dw_renewals.Cursor = System.Windows.Forms.Cursors.Hand;
//!            dw_renewals.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_renewals.RowFocusChanged += new EventHandler(dw_renewals_rowfocuschanged);
            dw_renewals.Click += new EventHandler(dw_renewals_Click);            

            // 
            // dw_criteria
            // 
//!            dw_criteria.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_criteria.VerticalScroll.Visible = false;
            dw_criteria.TabIndex = 8;
            dw_criteria.Location = new System.Drawing.Point(319, 16);
            dw_criteria.Size = new System.Drawing.Size(247, 59);
            //dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria_constructor);
            // 
            // dw_listing
            // 
            dw_listing.TabIndex = 10;
            dw_listing.Location = new System.Drawing.Point(317, 80);
            dw_listing.Size = new System.Drawing.Size(297, 253);
//!            dw_listing.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //((DWhatifContractSelection)dw_listing.DataObject).CellDoubleClick += new EventHandler(dw_listing_doubleclicked);
            //dw_listing.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_listing_constructor);
            // 
            // rb_last_article_count
            // 
            rb_last_article_count.Text = "Last";
            rb_last_article_count.BackColor = System.Drawing.SystemColors.Control;
            rb_last_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_last_article_count.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_last_article_count.TabIndex = 2;
            rb_last_article_count.Location = new System.Drawing.Point(41, 38);
            rb_last_article_count.Size = new System.Drawing.Size(44, 18);
            // 
            // rb_last_but_one_article_count
            // 
            rb_last_but_one_article_count.Text = "Last but one";
            rb_last_but_one_article_count.BackColor = System.Drawing.SystemColors.Control;
            rb_last_but_one_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_last_but_one_article_count.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_last_but_one_article_count.TabIndex = 3;
            rb_last_but_one_article_count.Location = new System.Drawing.Point(160, 20);
            rb_last_but_one_article_count.Size = new System.Drawing.Size(87, 18);
            // 
            // rb_average_article_count
            // 
            rb_average_article_count.Text = "Average";
            rb_average_article_count.BackColor = System.Drawing.SystemColors.Control;
            rb_average_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_average_article_count.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_average_article_count.TabIndex = 4;
            rb_average_article_count.Location = new System.Drawing.Point(160, 38);
            rb_average_article_count.Size = new System.Drawing.Size(65, 18);
            // 
            // rb_last_renewal
            // 
            rb_last_renewal.Checked = true;
            rb_last_renewal.Text = "Last renewal";
            rb_last_renewal.BackColor = System.Drawing.SystemColors.Control;
            rb_last_renewal.ForeColor = System.Drawing.SystemColors.WindowText;
            rb_last_renewal.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_last_renewal.TabIndex = 1;
            rb_last_renewal.Location = new System.Drawing.Point(41, 20);
            rb_last_renewal.Size = new System.Drawing.Size(88, 18);
            // 
            // gb_3
            // 
            gb_3.Text = "Renewal Rates";
            gb_3.BackColor = System.Drawing.SystemColors.Control;
            gb_3.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_3.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_3.Location = new System.Drawing.Point(3, 64);
            gb_3.Size = new System.Drawing.Size(300, 304);
            // 
            // gb_2
            // 
            gb_2.Text = "Contracts";
            gb_2.BackColor = System.Drawing.SystemColors.Control;
            gb_2.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_2.Location = new System.Drawing.Point(308, 1);
            gb_2.Size = new System.Drawing.Size(316, 367);
            // 
            // gb_1
            // 
            gb_1.Text = "What-If Calculator Source";
            gb_1.BackColor = System.Drawing.SystemColors.Control;
            gb_1.ForeColor = System.Drawing.SystemColors.WindowText;
            gb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_1.Size = new System.Drawing.Size(300, 59);
            gb_1.Location = new System.Drawing.Point(3, 1);
            // 
            // cb_selectall
            // 
            cb_selectall.Text = "Select All";
            cb_selectall.Enabled = false;
            cb_selectall.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_selectall.TabIndex = 11;
            cb_selectall.Location = new System.Drawing.Point(449, 339);
            cb_selectall.Size = new System.Drawing.Size(72, 22);
            cb_selectall.Tag = "ComponentName=Run What-If;";
            cb_selectall.Click += new EventHandler(cb_selectall_clicked);
            // 
            // cb_deselectall
            // 
            cb_deselectall.Text = "&Unselect All";
            cb_deselectall.Enabled = false;
            cb_deselectall.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_deselectall.TabIndex = 12;
            cb_deselectall.Location = new System.Drawing.Point(537, 339);
            cb_deselectall.Size = new System.Drawing.Size(78, 22);
            cb_deselectall.Tag = "ComponentName=Run What-If;";
            cb_deselectall.Click += new EventHandler(cb_deselectall_clicked);
            // 
            // cb_runwhatif
            // 
            cb_runwhatif.Text = "Run What If Calculator...";
            cb_runwhatif.Enabled = false;
            cb_runwhatif.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_runwhatif.TabIndex = 13;
            cb_runwhatif.Location = new System.Drawing.Point(491, 374);
            cb_runwhatif.Size = new System.Drawing.Size(134, 22);
            cb_runwhatif.Tag = "ComponentName=Run What-If;";
            cb_runwhatif.Click += new EventHandler(cb_runwhatif_clicked);
            // 
            // cb_showrates
            // 
            cb_showrates.Text = "Show Rates...";
            cb_showrates.Enabled = false;
            cb_showrates.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_showrates.TabIndex = 6;
            cb_showrates.Location = new System.Drawing.Point(103, 339);
            cb_showrates.Size = new System.Drawing.Size(87, 22);
            cb_showrates.Tag = "ComponentName=Show Rates;";
            cb_showrates.Click += new EventHandler(cb_showrates_clicked);
            // 
            // cb_1
            // 
            this.AcceptButton = cb_1;
            cb_1.Text = "&Search";
            cb_1.Enabled = false;
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 9;
            cb_1.Location = new System.Drawing.Point(565, 33);
            cb_1.Size = new System.Drawing.Size(54, 22);
            cb_1.Tag = "ComponentName=Run What-If;";
            cb_1.Click += new EventHandler(cb_1_clicked);
            // 
            // cb_newrates
            // 
            cb_newrates.Text = "New Rates...";
            cb_newrates.Enabled = false;
            cb_newrates.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_newrates.TabIndex = 7;
            cb_newrates.Location = new System.Drawing.Point(208, 339);
            cb_newrates.Size = new System.Drawing.Size(87, 22);
            cb_newrates.Tag = "ComponentName=New Rates;";
            cb_newrates.Click += new EventHandler(cb_newrates_clicked);

            Controls.Add(rb_last_article_count);
            Controls.Add(rb_last_but_one_article_count);
            Controls.Add(rb_average_article_count);
            Controls.Add(rb_last_renewal);
            Controls.Add(cb_selectall);
            Controls.Add(cb_deselectall);
            Controls.Add(cb_runwhatif);
            Controls.Add(cb_showrates);
            Controls.Add(cb_1);
            Controls.Add(cb_newrates);
            Controls.Add(dw_renewals);
            Controls.Add(dw_criteria);
            Controls.Add(dw_listing);
            Controls.Add(gb_3);
            Controls.Add(gb_2);
            Controls.Add(gb_1);
            this.ResumeLayout();
        }

        void dw_renewals_Click(object sender, EventArgs e)
        {
            dw_renewals.URdsDw_GetFocus(null, null);
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

        #region Methods

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int? ll_Region;
            ll_Region = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
            il_region = ll_Region;
            //?dw_criteria.settransobject(StaticVariables.sqlca);
            dw_criteria.InsertItem<BenchmarkCalcCriteria>(0);
            //?dw_renewals.setrowfocusindicator(focusrect!);
            //?dw_renewals.settransobject(StaticVariables.sqlca);
            ((DRenewalDates2001a)dw_renewals.DataObject).Retrieve(ll_Region);
            if (dw_renewals.RowCount > 0)
            {
                dw_renewals.SelectRow(1, true);
            }
            //?dw_listing.settransobject(StaticVariables.sqlca);
            dw_listing.URdsDw_GetFocus(null, null);//added by jlwang

            // TJB RPI_007 July-2010: Added
            // Check to see if the the 'New Rates' button should be enabled.
            enableNewRates();
        }

        public override void pfc_preopen()
        {
            this.of_set_componentname("Renewal Rates");
        }

        // TJB RPI_007 July-2010: Added
        private void enableNewRates()
       {
            // Check to see if the 'New Rates' Button should be enabled
            string Frozen = "";
            bool allFrozen = true;
            int nRows = dw_renewals.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                Frozen = dw_renewals.GetItem<RenewalDates2001a>(nRow).RrFrozenIndicator;
                if (!(Frozen == "Y"))
                    allFrozen = false;
            }
            if (allFrozen)
                this.cb_newrates.Enabled = true;
            else
                this.cb_newrates.Enabled = false;
        }

        public virtual int of_openrates(bool ab_newrates)
        {
            WShowRates2001 lw_RatesWindow = new WShowRates2001();
            FormBase wCurrentSheet = null;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_Msg;
            int? ll_RgCode;
            DateTime? ld_effectivedate;
            int? ll_Rates_Complete;
            Cursor.Current = Cursors.WaitCursor;
            lnv_Criteria = new NCriteria();
            lnv_Msg = new NRdsMsg();
            //!if (dw_renewals.GetSelectedRow(0) == 0)
            if (dw_renewals.GetSelectedRow(0) < 0)
            {
                dw_renewals.DataObject.AddItem<RenewalDates2001a>(new RenewalDates2001a());
            }
            ll_RgCode = dw_renewals.GetItem<RenewalDates2001a>(dw_renewals.GetRow()).RgCode;
            ld_effectivedate = dw_renewals.GetItem<RenewalDates2001a>(dw_renewals.GetRow()).RrRatesEffectiveDate;//dw_renewals.GetItemDateTime(dw_renewals.getrow().Date, "rr_rates_effective_date");
            ll_Rates_Complete = dw_renewals.GetItem<RenewalDates2001a>(dw_renewals.GetRow()).RatesComplete;//dw_renewals.getitemnumber(dw_renewals.getrow(), "rates_complete");
            lnv_Criteria.of_addcriteria("rg_code", ll_RgCode);
            lnv_Criteria.of_addcriteria("effective_date", ld_effectivedate);
            lnv_Criteria.of_addcriteria("caller", this);
            lnv_Criteria.of_addcriteria("rates_complete", ll_Rates_Complete);
            if (ab_newrates)
            {
                lnv_Criteria.of_addcriteria("editable", "W");
            }
            else if (dw_renewals.GetItem<RenewalDates2001a>(dw_renewals.GetRow()).RrFrozenIndicator == "Y") //else if (dw_renewals.getitemstring(dw_renewals.GetRow(), "rr_frozen_indicator") == 'Y') {
            {
                lnv_Criteria.of_addcriteria("editable", "N");
            }
            else
            {
                lnv_Criteria.of_addcriteria("editable", "Y");
            }
            lnv_Msg.of_addcriteria(lnv_Criteria);
            if (ab_newrates)
            {
                //OpenSheetWithParm(lw_RatesWindow, lnv_Msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_Msg;
                lw_RatesWindow.MdiParent = this.MdiParent;
                lw_RatesWindow.Show();
                return 1;
            }
            wCurrentSheet = ((WMainMdi)this.MdiParent).GetFirstSheet();//wCurrentSheet = w_main_mdi.GetFirstSheet();
            while ((wCurrentSheet != null))
            {
                if (wCurrentSheet.Name.ToUpper() == "w_Show_Rates2001".ToUpper()) //if (Upper(wCurrentSheet.ClassName()) == Upper("w_Show_Rates2001")) {
                {
                    if (wCurrentSheet.Tag.ToString() == ll_RgCode.ToString() + ld_effectivedate.ToString())
                    {
                        wCurrentSheet.BringToFront();
                        return 1;
                    }
                }
                wCurrentSheet = ((WMainMdi)this.MdiParent).GetNextSheet(wCurrentSheet);//wCurrentSheet = w_main_mdi.GetNextSheet(wCurrentSheet);
            }
            //OpenSheetWithParm(lw_RatesWindow, lnv_Msg, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = lnv_Msg;
            lw_RatesWindow.MdiParent = this.MdiParent;
            lw_RatesWindow.Show();
            return 1;
        }

        public virtual int of_retrievelist()
        {
            dw_renewals.Retrieve(new object[] { il_region });

            // TJB RPI_007 July-2010: Added
            // Check to see if the user froze the editable rates and
            // enable the 'New Rates' button if all rates are now frozen.
            // (of_retrievelist is called from WShowRates)
            enableNewRates();

            return 1;
        }

        public virtual int of_opencalculator()
        {
            NCriteria lnv_Criteria;
            NRdsMsg lnv_Msg;
            int ll_Row;
            int? ll_RgCode;
            DateTime ld_Date;
            string ls_Group;
            Metex.Windows.DataUserControl dwc;
            Dictionary<int, int> ll_contract = new Dictionary<int, int>();
            Dictionary<int, int> ll_sequence = new Dictionary<int, int>();
            int ll_DwcRow;
            if (dw_listing.GetSelectedRow(0) == -1)
            {
                MessageBox.Show("Please select contract(s) to use"
                                , "What-If Calculator"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            if (dw_renewals.RowCount == 0)
            {
                MessageBox.Show("Please define rates first"
                                , "What-If Calculator"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            // get renewal info
            ll_Row = dw_renewals.GetSelectedRow(0);
            if (ll_Row == -1)
            {
                MessageBox.Show("Please select a renewal rate to use"
                                , "What-If Calculator"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            Cursor.Current = Cursors.WaitCursor;
            ld_Date = dw_renewals.GetItem<RenewalDates2001a>(ll_Row).RrRatesEffectiveDate.GetValueOrDefault().Date;
            ll_RgCode = dw_renewals.GetItem<RenewalDates2001a>(ll_Row).RgCode;
            dwc = dw_renewals.DataObject.GetChild("rg_code");
            //?ll_DwcRow = dwc.Find("rg_code", il_rg_code);//ll_DwcRow = dwc.Find( "rg_code = " + il_rg_code).ToString().Length);
            ll_DwcRow = 0;
            ls_Group = "";// dwc.GetItem<DddwRenewalgroup>(ll_DwcRow).RgDescription;
            lnv_Criteria = new NCriteria();
            lnv_Msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("rg_code", ll_RgCode);
            lnv_Criteria.of_addcriteria("effective_date", ld_Date);
            lnv_Criteria.of_addcriteria("caller", this);
            lnv_Criteria.of_addcriteria("groupname", ls_Group);
            lnv_Criteria.of_addcriteria("reportgroupname", ls_Group + ' ' + ld_Date.ToString("MMM yy"));
            if (rb_last_renewal.Checked == true)
            {
                lnv_Criteria.of_addcriteria("VolumeSource", "last_renewal");
            }
            if (rb_last_article_count.Checked == true)
            {
                lnv_Criteria.of_addcriteria("VolumeSource", "last_article_count");
            }
            if (rb_last_but_one_article_count.Checked == true)
            {
                lnv_Criteria.of_addcriteria("VolumeSource", "last_but_one_article_count");
            }
            if (rb_average_article_count.Checked == true)
            {
                lnv_Criteria.of_addcriteria("VolumeSource", "average_article_count");
            }
            lnv_Msg.of_addcriteria(lnv_Criteria);
            //OpenSheetWithParm(w_whatif_calc2001, lnv_Msg, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = lnv_Msg;
            WWhatifCalc2001 w_whatif_calc2001 = new WWhatifCalc2001();
            w_whatif_calc2001.MdiParent = this.MdiParent;
            w_whatif_calc2001.Show();
            return 1;
        }

        public virtual void dw_renewals_constructor()
        {
            dw_renewals.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(0);
            dw_renewals.of_SetUpdateable(false);
        }

        public virtual void dw_criteria_constructor()
        {
            dw_criteria.of_SetUpdateable(false);
        }

        public virtual void dw_listing_constructor()
        {
            dw_listing.of_SetRowSelect(true);
            dw_listing.of_SetStyle(1);//inv_rowselect.of_SetStyle(1);
            dw_listing.of_SetUpdateable(false);
        }

        #endregion

        #region Events

        public virtual void dw_renewals_rowfocuschanged(object sender, EventArgs e)
        {
            //?dw_renewals.SelectRow(0, false);
            //?dw_renewals.SelectRow(dw_renewals.GetRow(), true);
        }

        public virtual void dw_renewals_doubleclicked(object sender, EventArgs e)
        {
            if (cb_showrates.Enabled)
            {
                cb_showrates_clicked(this, null);
            }
        }

        public virtual void dw_listing_doubleclicked(object sender, EventArgs e)
        {
            if (cb_runwhatif.Enabled)
            {
                cb_runwhatif_clicked(this, null);
            }
        }

        public virtual void cb_selectall_clicked(object sender, EventArgs e)
        {
            dw_listing.SelectAllRows(true);
        }

        public virtual void cb_deselectall_clicked(object sender, EventArgs e)
        {
            dw_listing.SelectAllRows(false);
        }

        public virtual void cb_runwhatif_clicked(object sender, EventArgs e)
        {
            of_opencalculator();
        }

        public virtual void cb_showrates_clicked(object sender, EventArgs e)
        {
            if (dw_renewals.RowCount > 0)
            {
                this.of_openrates(false);
            }
            else
            {
                MessageBox.Show("No rates have been defined. Please create new rates.", "Show Rates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            int? lRegion;
            int? lRGCode;
            lRegion = dw_criteria.GetItem<BenchmarkCalcCriteria>(0).RegionId;
            lRGCode = dw_criteria.GetItem<BenchmarkCalcCriteria>(0).RgCode;
            il_rg_code = lRGCode;
            if ((lRegion == null))
            {
                lRegion = 0;
            }
            if ((lRGCode == null))
            {
                lRGCode = 0;
            }
            if ((lRGCode == null))
            {
                il_rg_code = 0;
            }
            ((DWhatifContractSelection)dw_listing.DataObject).Retrieve(lRegion, lRGCode, lRegion, lRGCode);
            dw_listing.SelectRow(0, false);
        }

        public virtual void cb_newrates_clicked(object sender, EventArgs e)
        {
            this.of_openrates(true);
        }

        #endregion
    }
}