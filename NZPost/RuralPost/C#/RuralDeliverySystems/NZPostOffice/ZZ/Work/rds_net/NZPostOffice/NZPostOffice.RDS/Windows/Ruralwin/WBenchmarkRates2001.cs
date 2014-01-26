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
    // TJB  Jan-2014
    // Added Try/Catch to pfc_postopen to try to troubleshoot problem at Rural Pust testing
    // Disabled for 7.1.11 release

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
            this.dw_renewals = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_criteria = new NZPostOffice.RDS.Controls.URdsDw();
            this.dw_listing = new NZPostOffice.RDS.Controls.URdsDw();
            this.rb_last_article_count = new System.Windows.Forms.RadioButton();
            this.rb_last_but_one_article_count = new System.Windows.Forms.RadioButton();
            this.rb_average_article_count = new System.Windows.Forms.RadioButton();
            this.rb_last_renewal = new System.Windows.Forms.RadioButton();
            this.gb_3 = new System.Windows.Forms.GroupBox();
            this.gb_2 = new System.Windows.Forms.GroupBox();
            this.gb_1 = new System.Windows.Forms.GroupBox();
            this.cb_selectall = new System.Windows.Forms.Button();
            this.cb_deselectall = new System.Windows.Forms.Button();
            this.cb_runwhatif = new System.Windows.Forms.Button();
            this.cb_showrates = new System.Windows.Forms.Button();
            this.cb_1 = new System.Windows.Forms.Button();
            this.cb_newrates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(1, 374);
            this.st_label.Size = new System.Drawing.Size(171, 17);
            this.st_label.Text = "WBenchmarkRates2001";
            // 
            // dw_renewals
            // 
            this.dw_renewals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dw_renewals.DataObject = null;
            this.dw_renewals.FireConstructor = false;
            this.dw_renewals.Location = new System.Drawing.Point(10, 80);
            this.dw_renewals.Name = "dw_renewals";
            this.dw_renewals.Size = new System.Drawing.Size(284, 253);
            this.dw_renewals.TabIndex = 5;
            this.dw_renewals.RowFocusChanged += new System.EventHandler(this.dw_renewals_rowfocuschanged);
            this.dw_renewals.Click += new System.EventHandler(this.dw_renewals_Click);
            // 
            // dw_criteria
            // 
            this.dw_criteria.DataObject = null;
            this.dw_criteria.FireConstructor = false;
            this.dw_criteria.Location = new System.Drawing.Point(319, 16);
            this.dw_criteria.Name = "dw_criteria";
            this.dw_criteria.Size = new System.Drawing.Size(247, 59);
            this.dw_criteria.TabIndex = 8;
            // 
            // dw_listing
            // 
            this.dw_listing.DataObject = null;
            this.dw_listing.FireConstructor = false;
            this.dw_listing.Location = new System.Drawing.Point(317, 80);
            this.dw_listing.Name = "dw_listing";
            this.dw_listing.Size = new System.Drawing.Size(297, 253);
            this.dw_listing.TabIndex = 10;
            // 
            // rb_last_article_count
            // 
            this.rb_last_article_count.BackColor = System.Drawing.SystemColors.Control;
            this.rb_last_article_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rb_last_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_last_article_count.Location = new System.Drawing.Point(41, 38);
            this.rb_last_article_count.Name = "rb_last_article_count";
            this.rb_last_article_count.Size = new System.Drawing.Size(44, 18);
            this.rb_last_article_count.TabIndex = 2;
            this.rb_last_article_count.Text = "Last";
            this.rb_last_article_count.UseVisualStyleBackColor = false;
            // 
            // rb_last_but_one_article_count
            // 
            this.rb_last_but_one_article_count.BackColor = System.Drawing.SystemColors.Control;
            this.rb_last_but_one_article_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rb_last_but_one_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_last_but_one_article_count.Location = new System.Drawing.Point(160, 20);
            this.rb_last_but_one_article_count.Name = "rb_last_but_one_article_count";
            this.rb_last_but_one_article_count.Size = new System.Drawing.Size(87, 18);
            this.rb_last_but_one_article_count.TabIndex = 3;
            this.rb_last_but_one_article_count.Text = "Last but one";
            this.rb_last_but_one_article_count.UseVisualStyleBackColor = false;
            // 
            // rb_average_article_count
            // 
            this.rb_average_article_count.BackColor = System.Drawing.SystemColors.Control;
            this.rb_average_article_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rb_average_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_average_article_count.Location = new System.Drawing.Point(160, 38);
            this.rb_average_article_count.Name = "rb_average_article_count";
            this.rb_average_article_count.Size = new System.Drawing.Size(65, 18);
            this.rb_average_article_count.TabIndex = 4;
            this.rb_average_article_count.Text = "Average";
            this.rb_average_article_count.UseVisualStyleBackColor = false;
            // 
            // rb_last_renewal
            // 
            this.rb_last_renewal.BackColor = System.Drawing.SystemColors.Control;
            this.rb_last_renewal.Checked = true;
            this.rb_last_renewal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rb_last_renewal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rb_last_renewal.Location = new System.Drawing.Point(41, 20);
            this.rb_last_renewal.Name = "rb_last_renewal";
            this.rb_last_renewal.Size = new System.Drawing.Size(88, 18);
            this.rb_last_renewal.TabIndex = 1;
            this.rb_last_renewal.TabStop = true;
            this.rb_last_renewal.Text = "Last renewal";
            this.rb_last_renewal.UseVisualStyleBackColor = false;
            // 
            // gb_3
            // 
            this.gb_3.BackColor = System.Drawing.SystemColors.Control;
            this.gb_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_3.Location = new System.Drawing.Point(3, 64);
            this.gb_3.Name = "gb_3";
            this.gb_3.Size = new System.Drawing.Size(300, 304);
            this.gb_3.TabIndex = 14;
            this.gb_3.TabStop = false;
            this.gb_3.Text = "Renewal Rates";
            // 
            // gb_2
            // 
            this.gb_2.BackColor = System.Drawing.SystemColors.Control;
            this.gb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_2.Location = new System.Drawing.Point(308, 1);
            this.gb_2.Name = "gb_2";
            this.gb_2.Size = new System.Drawing.Size(316, 367);
            this.gb_2.TabIndex = 15;
            this.gb_2.TabStop = false;
            this.gb_2.Text = "Contracts";
            // 
            // gb_1
            // 
            this.gb_1.BackColor = System.Drawing.SystemColors.Control;
            this.gb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gb_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gb_1.Location = new System.Drawing.Point(3, 1);
            this.gb_1.Name = "gb_1";
            this.gb_1.Size = new System.Drawing.Size(300, 59);
            this.gb_1.TabIndex = 16;
            this.gb_1.TabStop = false;
            this.gb_1.Text = "What-If Calculator Source";
            // 
            // cb_selectall
            // 
            this.cb_selectall.Enabled = false;
            this.cb_selectall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_selectall.Location = new System.Drawing.Point(449, 339);
            this.cb_selectall.Name = "cb_selectall";
            this.cb_selectall.Size = new System.Drawing.Size(72, 22);
            this.cb_selectall.TabIndex = 11;
            this.cb_selectall.Tag = "ComponentName=Run What-If;";
            this.cb_selectall.Text = "Select All";
            this.cb_selectall.Click += new System.EventHandler(this.cb_selectall_clicked);
            // 
            // cb_deselectall
            // 
            this.cb_deselectall.Enabled = false;
            this.cb_deselectall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_deselectall.Location = new System.Drawing.Point(537, 339);
            this.cb_deselectall.Name = "cb_deselectall";
            this.cb_deselectall.Size = new System.Drawing.Size(78, 22);
            this.cb_deselectall.TabIndex = 12;
            this.cb_deselectall.Tag = "ComponentName=Run What-If;";
            this.cb_deselectall.Text = "&Unselect All";
            this.cb_deselectall.Click += new System.EventHandler(this.cb_deselectall_clicked);
            // 
            // cb_runwhatif
            // 
            this.cb_runwhatif.Enabled = false;
            this.cb_runwhatif.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_runwhatif.Location = new System.Drawing.Point(491, 374);
            this.cb_runwhatif.Name = "cb_runwhatif";
            this.cb_runwhatif.Size = new System.Drawing.Size(134, 22);
            this.cb_runwhatif.TabIndex = 13;
            this.cb_runwhatif.Tag = "ComponentName=Run What-If;";
            this.cb_runwhatif.Text = "Run What If Calculator...";
            this.cb_runwhatif.Click += new System.EventHandler(this.cb_runwhatif_clicked);
            // 
            // cb_showrates
            // 
            this.cb_showrates.Enabled = false;
            this.cb_showrates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_showrates.Location = new System.Drawing.Point(103, 339);
            this.cb_showrates.Name = "cb_showrates";
            this.cb_showrates.Size = new System.Drawing.Size(87, 22);
            this.cb_showrates.TabIndex = 6;
            this.cb_showrates.Tag = "ComponentName=Show Rates;";
            this.cb_showrates.Text = "Show Rates...";
            this.cb_showrates.Click += new System.EventHandler(this.cb_showrates_clicked);
            // 
            // cb_1
            // 
            this.cb_1.Enabled = false;
            this.cb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_1.Location = new System.Drawing.Point(565, 33);
            this.cb_1.Name = "cb_1";
            this.cb_1.Size = new System.Drawing.Size(54, 22);
            this.cb_1.TabIndex = 9;
            this.cb_1.Tag = "ComponentName=Run What-If;";
            this.cb_1.Text = "&Search";
            this.cb_1.Click += new System.EventHandler(this.cb_1_clicked);
            // 
            // cb_newrates
            // 
            this.cb_newrates.Enabled = false;
            this.cb_newrates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_newrates.Location = new System.Drawing.Point(208, 339);
            this.cb_newrates.Name = "cb_newrates";
            this.cb_newrates.Size = new System.Drawing.Size(87, 22);
            this.cb_newrates.TabIndex = 7;
            this.cb_newrates.Tag = "ComponentName=New Rates;";
            this.cb_newrates.Text = "New Rates...";
            this.cb_newrates.Click += new System.EventHandler(this.cb_newrates_clicked);
            // 
            // WBenchmarkRates2001
            // 
            this.AcceptButton = this.cb_1;
            this.ClientSize = new System.Drawing.Size(632, 408);
            this.Controls.Add(this.rb_last_article_count);
            this.Controls.Add(this.rb_last_but_one_article_count);
            this.Controls.Add(this.rb_average_article_count);
            this.Controls.Add(this.rb_last_renewal);
            this.Controls.Add(this.cb_selectall);
            this.Controls.Add(this.cb_deselectall);
            this.Controls.Add(this.cb_runwhatif);
            this.Controls.Add(this.cb_showrates);
            this.Controls.Add(this.cb_1);
            this.Controls.Add(this.cb_newrates);
            this.Controls.Add(this.dw_renewals);
            this.Controls.Add(this.dw_criteria);
            this.Controls.Add(this.dw_listing);
            this.Controls.Add(this.gb_3);
            this.Controls.Add(this.gb_2);
            this.Controls.Add(this.gb_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(1, 1);
            this.MaximizeBox = false;
            this.Name = "WBenchmarkRates2001";
            this.Text = "Rates/What-If";
            this.Controls.SetChildIndex(this.gb_1, 0);
            this.Controls.SetChildIndex(this.gb_2, 0);
            this.Controls.SetChildIndex(this.gb_3, 0);
            this.Controls.SetChildIndex(this.dw_listing, 0);
            this.Controls.SetChildIndex(this.dw_criteria, 0);
            this.Controls.SetChildIndex(this.dw_renewals, 0);
            this.Controls.SetChildIndex(this.cb_newrates, 0);
            this.Controls.SetChildIndex(this.cb_1, 0);
            this.Controls.SetChildIndex(this.cb_showrates, 0);
            this.Controls.SetChildIndex(this.cb_runwhatif, 0);
            this.Controls.SetChildIndex(this.cb_deselectall, 0);
            this.Controls.SetChildIndex(this.cb_selectall, 0);
            this.Controls.SetChildIndex(this.rb_last_renewal, 0);
            this.Controls.SetChildIndex(this.rb_average_article_count, 0);
            this.Controls.SetChildIndex(this.rb_last_but_one_article_count, 0);
            this.Controls.SetChildIndex(this.rb_last_article_count, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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
            string sErrmsg = "";
            //try
            //{
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
            //}
            //catch(Exception e)
            //{
            //    sErrmsg = e.Message;
            //    MessageBox.Show("Error caught: "+sErrmsg,"WBenchmarkRates2001.pfc_postopen");
            //}
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
            dw_renewals.Retrieve(new object[] {il_region});

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