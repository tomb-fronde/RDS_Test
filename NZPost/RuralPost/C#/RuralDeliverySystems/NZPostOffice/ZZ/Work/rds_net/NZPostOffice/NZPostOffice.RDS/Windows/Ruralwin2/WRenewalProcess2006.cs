using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using System.Collections.Generic;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Windows.Ruralbase;
using System.Threading;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    // Renewal and Benchmark window
    public class WRenewalProcess2006 : WAncestorWindow
    {
        #region Define
        private const string DEFAULT_ASSEMBLY = "NZPostOffice.RDS.DataControls";
        private const string DEFAULT_VERSION = "1.0.0.0";

        public DataUserControlContainer dw_benchmark_report;

        public URdsDw dw_criteria;

        public URdsDw dw_listing;

        public Button cb_search;

        public Button cb_create;

        public Button cb_benchmark;

        public Button cb_print;

        public int il_Ticks;

        public Dictionary<int, int> lcontractlist = new Dictionary<int, int>();

        public Dictionary<int, int> lrenewallist = new Dictionary<int, int>();

        public bool ib_PrintAbort;
        public List<object> sScheduleDWs = new List<object>();// Dictionary<int, object>();

        /*public string[] sScheduleDWs = new string[]{
                    "r_schedulea_single_contract",
                    "r_scheduleb_single_contract",
                    "r_vehicle_schedule_single_contractv2",
                    "r_route_description_single_contract",
                    "r_mail_carried_single_contract",
                    "r_contract_summary"};
        */
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_schedule;

        public TabControl tab_1;

        public TabPage tabpage_1;

        public UCb cb_clear;

        public URdsDw dw_criteria1;

        public URdsDw dw_listings;

        public Button cb_create_pending;

        public Button cb_bm;

        public Button cb_2s;

        public Button cb_bmlast;

        public Button cb_update_pv;

        public Button cb_printsked;

        public Button cb_searchs;

        public Button cb_1;

        public Panel l_1;

        public TabPage tabpage_2;

        public URdsDw dw_bm_report;

        public Button cb_printbm;

        #endregion

        public WRenewalProcess2006()
        {
            this.InitializeComponent();

            //pp! following lines moved from InitializeComponent to the ctnructor of windiw in order to open design mode of this window
            dw_criteria1.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria1_constructor);
            ((DListContractsForProcessing2001)dw_listings.DataObject).CellDoubleClick += new EventHandler(dw_listings_doubleclicked);
            dw_listings.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_listings_constructor);
            dw_bm_report.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_bm_report_constructor);
            dw_bm_report.DataObject.RetrieveStart += new RetrieveEventHandler(dw_bm_report_retrievestart);
            //pp! end of code moved from InitializeComponent

            cb_printbm_constructor();
            cb_create_pending_constructor();
            cb_bm_constructor();
            cb_searchs_constructor();
            cb_printbm_constructor();

            sScheduleDWs.Add("r_schedulea_single_contract");
            sScheduleDWs.Add("r_scheduleb_single_contract");
            sScheduleDWs.Add("r_vehicle_schedule_single_contractv2");
            sScheduleDWs.Add("r_route_description_single_contract");
            sScheduleDWs.Add("r_mail_carried_single_contract");
            sScheduleDWs.Add("r_contract_summary");
        }

        public virtual void ue_abort()
        {
            ib_PrintAbort = true;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
                // dw_Criteria.Modify("region_id.initial='" 
                //                    + string(gnv_App.of_Get_Securitymanager().of_Get_User().of_Get_RegionId())+"'")
            dw_criteria.InsertItem<RenewalProcessCriteria>(0);
                //?dw_listing.SetRowFocusIndicator(focusrect!);
                //?dw_benchmark_report.Modify("datawindow.print.preview=yes");
                //?dw_benchmark_report.Modify("datawindow.print.preview.zoom=" + 90).ToString();
            il_Ticks = of_getticks();

            dw_listings.URdsDw_GetFocus(null, null);//added by jlwang
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Renewal Process");
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_schedule = new URdsDw();
            dw_schedule.DataObject = new RScheduleaSingleContract();
            this.tab_1 = new TabControl();
            Controls.Add(tab_1);
            Controls.Add(dw_schedule);
            this.Text = "Renewal Process";
            this.Location = new System.Drawing.Point(1, 1);
            this.Size = new System.Drawing.Size(593, 440);
            // 
            // st_label
            // 
            st_label.Text = "RDRENPROC";
            st_label.Location = new System.Drawing.Point(19, 479);
            st_label.Visible = false;
            // 
            // dw_schedule
            // 
            dw_schedule.TabIndex = 1;
            dw_schedule.Location = new System.Drawing.Point(467, 328);
            dw_schedule.Size = new System.Drawing.Size(83, 58);
            dw_schedule.Visible = false;
            // 
            // tab_1
            // 
            // Gegerated from create event for tab_1
            tabpage_1 = new TabPage();
            tabpage_2 = new TabPage();
            tab_1.Controls.Add(tabpage_1);
            tab_1.Controls.Add(tabpage_2);
            tab_1.SelectedIndex = 0;
            tab_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_1.TabIndex = 2;
            tab_1.Size = new System.Drawing.Size(570, 400);
            tab_1.Location = new System.Drawing.Point(5, 7);
            // 
            // tabpage_1
            // 
            // Gegerated from create event for tabpage_1
            cb_clear = new UCb();
            l_1 = new Panel();
            dw_criteria1 = new URdsDw();
            dw_criteria1.DataObject = new DRenewalProcessCriteria();
            dw_listings = new URdsDw();
            dw_listings.DataObject = new DListContractsForProcessing2001();
            cb_create_pending = new Button();
            cb_bm = new Button();
            cb_2s = new Button();
            cb_bmlast = new Button();
            cb_update_pv = new Button();
            cb_printsked = new Button();
            cb_searchs = new Button();
            cb_1 = new Button();
            tabpage_1.Controls.Add(cb_clear);
            tabpage_1.Controls.Add(l_1);
            tabpage_1.Controls.Add(dw_criteria1);
            tabpage_1.Controls.Add(dw_listings);
            tabpage_1.Controls.Add(cb_create_pending);
            tabpage_1.Controls.Add(cb_bm);
            tabpage_1.Controls.Add(cb_2s);
            tabpage_1.Controls.Add(cb_bmlast);
            tabpage_1.Controls.Add(cb_update_pv);
            tabpage_1.Controls.Add(cb_printsked);
            tabpage_1.Controls.Add(cb_searchs);
            tabpage_1.Controls.Add(cb_1);
            tabpage_1.ToolTipText = "Contract selection tabpage for creating pendings and benchmarking";
            tabpage_1.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_1.Text = "Benchmark";
            tabpage_1.Name = tabpage_1.Text; //

            tabpage_1.BackColor = System.Drawing.Color.FromArgb(4, 192, 192, 192);
            tabpage_1.Top = 25;
            tabpage_1.Left = 3;
            tabpage_1.Size = new System.Drawing.Size(562, 362);

            // 
            // cb_clear
            // 
            cb_clear.Text = "&Clear";
            cb_clear.TabIndex = 13;
            cb_clear.Location = new System.Drawing.Point(437, 32);
            cb_clear.Size = new System.Drawing.Size(76, 22);
            cb_clear.Click += new EventHandler(cb_clear_clicked);
            // 
            // dw_criteria1
            // 
            //?dw_criteria1.vscrollbar = false;
            dw_criteria1.TabIndex = 12;
            dw_criteria1.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_criteria1.Location = new System.Drawing.Point(51, 4);
            dw_criteria1.Size = new System.Drawing.Size(350, 90);
            dw_criteria1.ItemChanged += new EventHandler(dw_criteria1_itemchanged);
            //p!            dw_criteria1.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_criteria1_constructor);

            // 
            // l_1
            // 
            l_1.Height = 1;
            l_1.Width = 345;
            l_1.BackColor = System.Drawing.Color.Black;
            l_1.BorderStyle = BorderStyle.Fixed3D;
            l_1.Location = new System.Drawing.Point(55, 338);
            // 
            // dw_listings
            // 
            dw_listings.TabIndex = 4;
            dw_listings.Location = new System.Drawing.Point(51, 95);
            dw_listings.Size = new System.Drawing.Size(350, 275);
            dw_listings.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //p!            ((DListContractsForProcessing2001)dw_listings.DataObject).CellDoubleClick += new EventHandler(dw_listings_doubleclicked);
            //p!            dw_listings.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_listings_constructor);
            // 
            // cb_create_pending
            // 
            cb_create_pending.Text = "Create &Pendings";
            cb_create_pending.Enabled = false;
            cb_create_pending.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_create_pending.TabIndex = 3;
            cb_create_pending.Location = new System.Drawing.Point(437, 196);
            cb_create_pending.Size = new System.Drawing.Size(97, 22);
            cb_create_pending.Tag = "ComponentName=Create Pendings;";
            cb_create_pending.Click += new EventHandler(cb_create_pending_clicked);
            // 
            // cb_bm
            // 
            cb_bm.Text = "Benchmark";
            cb_bm.Enabled = false;
            cb_bm.Font = new System.Drawing.Font("MS Sans Serif", 8, cb_bm.Font.Style);
            cb_bm.TabIndex = 5;
            cb_bm.Location = new System.Drawing.Point(437, 230);
            cb_bm.Size = new System.Drawing.Size(97, 22);
            cb_bm.Tag = "ComponentName=Benchmark;";
            cb_bm.Click += new EventHandler(cb_bm_clicked);
            // 
            // cb_2s
            // 
            cb_2s.Text = "Select &All";
            cb_2s.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_2s.TabIndex = 2;
            cb_2s.Location = new System.Drawing.Point(437, 88);
            cb_2s.Size = new System.Drawing.Size(76, 22);
            cb_2s.Click += new EventHandler(cb_2s_clicked);
            // 
            // cb_bmlast
            // 
            cb_bmlast.Text = "Benchmark Last";
            cb_bmlast.Enabled = false;
            cb_bmlast.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_bmlast.TabIndex = 6;
            cb_bmlast.Location = new System.Drawing.Point(437, 264);
            cb_bmlast.Size = new System.Drawing.Size(97, 22);
            cb_bmlast.Tag = "ComponentName=Benchmark Last;";
            cb_bmlast.Click += new EventHandler(cb_bmlast_clicked);
            // 
            // cb_update_pv
            // 
            cb_update_pv.Text = "Update PValues";
            cb_update_pv.Enabled = false;
            cb_update_pv.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_update_pv.TabIndex = 7;
            cb_update_pv.Location = new System.Drawing.Point(437, 298);
            cb_update_pv.Size = new System.Drawing.Size(97, 22);
            cb_update_pv.Tag = "ComponentName=Update Payment Values;";
            cb_update_pv.Click += new EventHandler(cb_update_pv_clicked);
            // 
            // cb_printsked
            // 
            cb_printsked.Text = "Print Schedules...";
            cb_printsked.Enabled = false;
            cb_printsked.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_printsked.TabIndex = 8;
            cb_printsked.Location = new System.Drawing.Point(437, 332);
            cb_printsked.Size = new System.Drawing.Size(97, 22);
            cb_printsked.Tag = "ComponentName=Print Schedules;";
            cb_printsked.Click += new EventHandler(cb_printsked_clicked);
            // 
            // cb_searchs
            // 
            this.AcceptButton = cb_searchs;
            cb_searchs.Text = "&Search";
            cb_searchs.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_searchs.TabIndex = 5;
            cb_searchs.Location = new System.Drawing.Point(437, 6);
            cb_searchs.Size = new System.Drawing.Size(76, 22);
            cb_searchs.Click += new EventHandler(cb_searchs_clicked);
            // 
            // cb_1
            // 
            cb_1.Text = "&Unselect All";
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 5;
            cb_1.Location = new System.Drawing.Point(437, 120);
            cb_1.Size = new System.Drawing.Size(76, 22);
            cb_1.Click += new EventHandler(cb_1_clicked);
            // 
            // tabpage_2
            // 
            // Gegerated from create event for tabpage_2
            dw_bm_report = new URdsDw();
            dw_bm_report.DataObject = new RBenchmarkReport2006();
            dw_bm_report.DataObject.BorderStyle = BorderStyle.Fixed3D;
            cb_printbm = new Button();
            tabpage_2.Controls.Add(dw_bm_report);
            tabpage_2.Controls.Add(cb_printbm);
            tabpage_2.ToolTipText = "Benchmark report - enabled only when benchmark process is successful";
            tabpage_2.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_2.Text = "Report";
            tabpage_2.Name = tabpage_2.Text;//

            tabpage_2.Enabled = false;
            tabpage_2.Top = 25;
            tabpage_2.Left = 3;
            tabpage_2.Size = new System.Drawing.Size(562, 362);
            // 
            // dw_bm_report
            // 
            dw_bm_report.TabIndex = 12;
            dw_bm_report.Location = new System.Drawing.Point(5, 8);
            dw_bm_report.Size = new System.Drawing.Size(550, 318);
            //dw_bm_report.DoubleClick += new EventHandler(dw_bm_report_doubleclicked);
            //p!            dw_bm_report.DataObject.RetrieveStart += new RetrieveEventHandler(dw_bm_report_retrievestart);
            //p!            dw_bm_report.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_bm_report_constructor);
            // 
            // cb_printbm
            // 
            cb_printbm.Text = "&Print";
            cb_printbm.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_printbm.TabIndex = 3;
            cb_printbm.Location = new System.Drawing.Point(486, 334);
            cb_printbm.Size = new System.Drawing.Size(70, 22);
            cb_printbm.Click += new EventHandler(cb_printbm_clicked);
            this.ResumeLayout();
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
        public virtual int setredraw()
        {
            /*? if (al_redraw == 1) {
                   setredraw(true);
                }
                else {
                    setredraw(false);
                } */
            return 1;
        }

        public virtual WRenewalProcess2006 of_getparent()
        {
            return this;
        }

        public virtual int of_getnumselectedrows()
        {
                // count rows for progress bar
            int ll_Cnt = 0;
            int ll_Ctr = 0;
            int lRow;
            lRow = dw_listing.GetSelectedRow(0);
            while (lRow >= 0)
            {
                ll_Cnt++;
                lRow = dw_listing.GetSelectedRow(lRow + 1);
            }
            return ll_Cnt;
        }

        public virtual int of_getticks()
        {
                // gets ticks per second
            DateTime tn;
            int ll_ctr = 0;
            tn = DateTime.Now;
                //while (SecondsAfter(tn, DateTime.Now) < 2)
            while (DateTime.Now.Second - tn.Second < 2)
            {
                ll_ctr++;
            }
            return Convert.ToInt32(ll_ctr / 2);    // Round(ll_ctr / 2, 0);
        }

        public virtual int of_clear()
        {
                //  TWC - 23/12/2003 - initial version
                //  This function will clear the search criteria 
                //  and search results boxes
                //  This is response to powerbuilder 8.0.4 not recogizing firing of delete key strokes
            int? ll_null;
            string ls_null;
            ll_null = null;
            ls_null = null;
                //  clear the search criteria
                //dw_criteria.GetItem<RenewalProcessCriteria>(0).RegionId = ll_null;
                //dw_criteria.GetItem<RenewalProcessCriteria>(0).ContractNo = ll_null;
                //dw_criteria.GetItem<RenewalProcessCriteria>(0).RgCode = ll_null;
                //ttjin.above can not clear DDDW.
            dw_criteria.Reset();
            dw_criteria.InsertItem<RenewalProcessCriteria>(0);
                //  clear the results box
            dw_listing.DataObject.Reset();
            return 1;
        }

        public virtual void dw_criteria1_constructor()
        {
                //?base.constructor();
            dw_criteria1.of_SetUpdateable(false);
            dw_criteria = dw_criteria1;
        }

        public virtual void dw_listings_constructor()
        {
            dw_listings.of_SetUpdateable(false);
            dw_listings.of_SetRowSelect(true);
            dw_listings.of_SetStyle(1);    //?inv_rowselect.of_SetStyle(1);
            dw_listing = dw_listings;
        }

        public virtual void cb_searchs_constructor()
        {
            cb_search = cb_searchs;
        }

        public virtual void dw_bm_report_constructor()
        {
                //  TJB  SR4661  May 2005
                //  Changed to use r_benchmark_report2005
                //  TJB  SR4684  June 2006
                //  Changed to use r_benchmark_report2006
            dw_bm_report.of_SetUpdateable(false);
            dw_benchmark_report = dw_bm_report;
        }

        public virtual void cb_printbm_constructor()
        {
            cb_print = cb_printbm;
        }

        public virtual void cb_create_pending_constructor()
        {
            cb_create = cb_create_pending;
        }

        public virtual void cb_bm_constructor()
        {
            cb_benchmark = cb_bm;
        }

        private WStatusabort w_statusabort = null;

        private void WStatusabortShow()
        {
            w_statusabort = new WStatusabort();
            w_statusabort.ShowDialog();          
        }

        #endregion

        #region Events
        public override void resize(object sender, EventArgs args)
        {
            base.resize(sender, args);
                // this.setRedraw ( false)
            tab_1.Width = this.Width - 21;
            tab_1.Height = this.Height - 40;
            dw_benchmark_report.Width = this.Width - 40;
            dw_benchmark_report.Height = this.Height - 112;
            cb_print.Top = Height - 95;
            cb_print.Left = Width - 114;
                // 
                // idw_report.height  = idw_summary.height
                // idw_dist.height = idw_summary.height
                // idw_report.width  = idw_summary.width
                // idw_dist.width = idw_summary.width
                // 
                // cb_print.y = tab_1.height + tab_1.y + 20
                // cb_close.y = cb_print.y
                // cb_close.x = this.width - 360
                // cb_print.x = cb_close.x - 400
                // 
                // cb_how.y = cb_print.y
                // cb_NOT.y = cb_how.y
                // this.ResumeLayout ( false )
        }

        public virtual void cb_clear_clicked(object sender, EventArgs e)
        {
                //?base.clicked();
            of_clear();
        }

        public virtual void dw_criteria1_itemchanged(object sender, EventArgs e)
        {
                // WARNING: Call not Isimmediate Ancestor Event : change manually
                // u_rds_dw.itemchanged();
            dw_criteria1.URdsDw_Itemchanged(sender, e);
            int? lNull;
            lNull = null;
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyDelete))
            {
                dw_criteria1.SetValue(dw_criteria1.GetRow(), dw_criteria1.GetColumnName(), lNull);
            }
        }

        public virtual void dw_listings_doubleclicked(object sender, EventArgs e)
        {
            int ll_Row;
            int? ll_ContractNo;
            string ls_Title;
            WContract2001 lw_contract2001;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            //  TJB SR4684  June 2006
            //  Ensures doubleclick selects the row
            dw_listings.SelectRow(dw_listings.GetRow() + 1, true);
            ll_Row = dw_listings.GetRow();// dw_listings.GetSelectedRow(0);
            if (ll_Row < 0)
            {
                MessageBox.Show("Please search for a contract before trying to open one.", 
                                "Contract Search", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ll_ContractNo = dw_listings.GetItem<ListContractsForProcessing2001>(ll_Row).ContractNo;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("contract_no", ll_ContractNo);
            lnv_msg.of_addcriteria(lnv_Criteria);
            Cursor.Current = Cursors.WaitCursor;
            ls_Title = "Contract:  (" + ll_ContractNo.ToString() + ") " 
                       + dw_listings.GetItem<ListContractsForProcessing2001>(dw_listings.GetRow()).ConTitle;   
                           /*dw_listings.GetSelectedRow(0)*/

                /*if (!(IsValid(StaticVariables.gnv_app.of_findwindow(ls_Title,"w_contract2001") != null)) */
            if (!(StaticVariables.gnv_app.of_findwindow(ls_Title, "w_contract2001") != null))
            {
                    //OpenSheetWithParm(lw_contract2001, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                OpenSheet<WContract2001>(StaticVariables.MainMDI);
            }
                // window wSheet
                // w_contract wContract
                // string sTitle
                // long  lContract
                // 
                // IF row=0 then
                //     return
                // end if
                // 
                // lContract = dw_listing.GetItemNumber(dw_listing.GetRow(),"contract_no")
                // sTitle    = "Contract: (" + lContract.ToString() + ") " 
                //             + dw_listing.GetItemString(dw_listing.GetRow(),"con_title")
                // 
                // wSheet = w_main_mdi.GetFirstSheet ( )
                // DO while isvalid (  wSheet )
                //     if wSheet.title = sTitle then
                //     wContract = wSheet
                //     exit
                //     end if
                //     wSheet = w_main_mdi.GetNextSheet ( wSheet)
                // LOOP
                //
                // setpointer ( hourglass!)
                // opensheetwithparm ( wContract, lContract, w_main_mdi, 0, original!)
        }

        WStatus w_status = null;

        public virtual void cb_create_pending_clicked(object sender, EventArgs e)
        {
                //Not parsed PB function body
            int lRow = -1;
            DialogResult ll_rc;
            int? lContract, lSequence;
            String saddr;
            String sname;
            String sphone;
            DateTime? dtermdate;
            int l_ctr;
            Dictionary<int, int> dummylist = new Dictionary<int, int>();
            Dictionary<int, int> dummylist1 = new Dictionary<int, int>();  //pp! added this dummy, used only to rest values 
            int ll_Ctr = 0;
            int ll_Cnt;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            ll_rc = MessageBox.Show("Do you really want to create pendings?", 
                                    "Create Pendings", 
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (ll_rc == DialogResult.No)
            {
                return;
            }
                //?SetPointer ( HourGlass!);
                //reset contents
            lcontractlist = dummylist;
            lrenewallist = dummylist1;
                //count rows for progress bar
            ll_Cnt = of_getnumselectedrows();
            l_ctr = 0;
            lRow = dw_listing.GetSelectedRow(0);
            if (lRow < 0)
            {
                MessageBox.Show("Please select a contract.", "Create Pendings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            while (lRow >= 0)
            {
                ll_Ctr++;
                StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Ctr, ll_Cnt, "Generating pendings...");
                lContract = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ContractNo;
                    // SELECT contract.con_date_terminated INTO :dtermdate  
                    //   FROM contract  
                    //  WHERE contract.contract_no = :lContract
                dtermdate = RDSDataService.GetConDateTerminatedFromContract(lContract, ref SQLCode, ref SQLErrText);
                if (SQLCode == -1)
                {
                    MessageBox.Show(SQLErrText, "Date terminated selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                if ((dtermdate == null || dtermdate == DateTime.MinValue) && 
                    dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).Rowstatus == "Active")
                {
                    lContract = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ContractNo;
                    lSequence = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ConActiveSequence;
                        /* SELECT contract_renewals.con_relief_driver_name,   
                         *        contract_renewals.con_relief_driver_address,   
                         *        contract_renewals.con_relief_driver_home_phone  
                         *   INTO :sname,:saddr,:sphone  
                         *   FROM contract_renewals  
                         *  WHERE contract_renewals.contract_no = :lcontract
                         *    AND contract_renewals.contract_seq_number = :lsequence  */

                    List<ContractRenewalsItem> vlist = new List<ContractRenewalsItem>();
                    RDSDataService dataService = RDSDataService.GetContractRenewalsList(lContract, lSequence, ref SQLCode, ref SQLErrText);
                    vlist = dataService.ContractRenewalsList;
                    sname = vlist[0].Con_relief_driver_name;
                    saddr = vlist[0].Con_relief_driver_address;
                    sphone = vlist[0].Con_relief_driver_home_phone;
                    if (SQLCode == -1)
                    {
                        MessageBox.Show(SQLErrText, "Relief driver selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    lSequence++;
                        /* insert into contract_renewals
                         *     (contract_no, contract_seq_number,con_relief_driver_name,con_relief_driver_address,con_relief_driver_home_phone)
                         * values
                         *     ( :lContract, :lSequence,:sname,:saddr,:sphone); */
                    RDSDataService.InsertIntoContractRenewals(lContract, lSequence, sname, saddr, sphone, ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show("Database Error\r" + SQLErrText, 
                                        "Contract renewals insertion", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //?rollback;
                        StaticVariables.gnv_app.of_hidestatus(ref w_status);
                        return;
                    }
                    dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).MaxSequence = lSequence;
                    dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ConAcceptanceFlag = "N";
                }
                if (dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ConAcceptanceFlag == "N")
                {
                    l_ctr++;
                    lcontractlist[l_ctr] = lContract.GetValueOrDefault();
                    lrenewallist[l_ctr] = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).MaxSequence.GetValueOrDefault();
                }
                   // dw_listing.SelectRow(lRow, False)
                lRow = dw_listing.GetSelectedRow(lRow + 1);
            }
            StaticVariables.gnv_app.of_hidestatus(ref w_status);
            //?commit;
            if (lcontractlist.Count >= 0)
            {
                    // openwithparm(w_assign_article_counts_bulk2001,of_GetParent() );
                StaticMessage.PowerObjectParm = this.of_getparent();
                WAssignArticleCountsBulk2001 w_assign_article_counts_bulk2001 = new WAssignArticleCountsBulk2001();
                w_assign_article_counts_bulk2001.ShowDialog();
            }
            if (StaticMessage.DoubleParm == 1)
            {
                if (MessageBox.Show("Do you want the system to produce benchmark reports for the selected contract(s)?", "", 
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cb_benchmark_clicked(this, null);
                    cb_bm_clicked(this, null);
                }
            }
        }

        public virtual void cb_bm_clicked(object sender, EventArgs e)
        {
            int lRow = -1;
            int? lContract;
            int? lSequence;
            int ltest;
            bool bPrintBenchmark = false;
            string test;
            int ll_Ctr = 0;
            int ll_Cnt;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            dw_benchmark_report.DataObject.Reset();
                // count rows for progress bar
            ll_Cnt = of_getnumselectedrows();
            lRow = dw_listing.GetSelectedRow(0);

            if (lRow < 0)
            {
                MessageBox.Show("Please select a contract to benchmark.", 
                                "Benchmark", 
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ((RBenchmarkReport2006)dw_benchmark_report.DataObject).ClearSource();

            while (lRow >= 0)
            {
                ll_Ctr++;
                test = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).Rowstatus;
                lContract = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ContractNo;
                lSequence = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).MaxSequence;
                    //  TJB  SR4661  May 2005
                    //  Changed benchmarkCalc stored proc name
                    //
                    // UPDATE contract_renewals set con_renewal_benchmark_price = BenchmarkCalc2005(contract_no, contract_seq_number)
                    //  where contract_no = :lContract 
                    //    and contract_seq_number = :lSequence;
                RDSDataService.UpdateContractRenewals(lContract, lSequence, ref SQLCode, ref SQLErrText);
                if (SQLCode != 0)
                {
                    MessageBox.Show(SQLErrText, "Database error (w_renewal_process2006.cb_bm.clicked)", 
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                ((RBenchmarkReport2006)dw_benchmark_report.DataObject).Retrieve(lContract, lSequence);
                StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Ctr, ll_Cnt, "Generating benchmark report...");
                lRow = dw_listing.GetSelectedRow(lRow + 1);
            }
            if (dw_benchmark_report.RowCount > 0)
            {
                tabpage_2.Enabled = true;
                tab_1.SelectedIndex = 1;     //.selectTab(2);
                    //?dw_benchmark_report.Modify("datawindow.print.preview.zoom=" + 90).ToString();
            }
                //?commit;
            StaticVariables.gnv_app.of_hidestatus(ref w_status);
        }

        public virtual void cb_2s_clicked(object sender, EventArgs e)
        {
            dw_listing.SelectRow(0, true);
        }

        public virtual void cb_bmlast_clicked(object sender, EventArgs e)
        {
            int lRow = -1;
            int? lContract;
            int? lSequence;
            bool bPrintBenchmark = false;
            int ll_Ctr = 0;
            int ll_Cnt;
            bPrintBenchmark = true;
            dw_benchmark_report.DataObject.Reset();
                // count rows for progress bar
            ll_Cnt = of_getnumselectedrows();
            lRow = dw_listing.GetSelectedRow(0);
            if (lRow < 0)
            {
                MessageBox.Show("Please select a contract to benchmark.", 
                                "Benchmark Last", 
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            while (lRow >= 0)
            {
                ll_Ctr++;
                StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Ctr, ll_Cnt, "Generating benchmark report...");
                lContract = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ContractNo;
                lSequence = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).MaxSequence;
                if (bPrintBenchmark)
                {
                        //!if (lSequence >= 1)
                    if (lSequence > 1)
                    {
                        ((RBenchmarkReport2006)dw_benchmark_report.DataObject).Retrieve(lContract, lSequence - 1);
                    }
                }
                lRow = dw_listing.GetSelectedRow(lRow + 1);
            }
                //?commit;
            StaticVariables.gnv_app.of_hidestatus(ref w_status);
            if (dw_benchmark_report.RowCount > 0)
            {
                tabpage_2.Enabled = true;
                    //?dw_benchmark_report.Modify("datawindow.print.preview.zoom=" + 90).ToString();
                tab_1.SelectedIndex = 1;    //.selectTab(2);
            }
        }

        public virtual void cb_update_pv_clicked(object sender, EventArgs e)
        {
            int lRow = -1;
            int ll_TicksCtr;
            DialogResult ll_rc;
            int? lContract;
            int? lSequence;
            bool bBulkUpdate = false;
            int ll_Ctr = 0;
            int ll_Cnt;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            ll_rc = MessageBox.Show("Do you want the system to update the payment values \r\n" 
                                         + "to the benchmark values for the selected contract?", 
                                    "Update Payment Values", 
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ll_rc == DialogResult.No)
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            // count rows for progress bar
            ll_Cnt = of_getnumselectedrows();
            lRow = dw_listing.GetSelectedRow(0);
            if (lRow < 0)
            {
                MessageBox.Show("Please select a contract.", 
                                "Update Payment Values", 
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            while (lRow >= 0)
            {
                ll_Ctr++;
                StaticVariables.gnv_app.of_showstatus(ref w_status, ll_Ctr, ll_Cnt, "Updating payment values...");
                for (ll_TicksCtr = 1; ll_TicksCtr <= il_Ticks / 10; ll_TicksCtr++)
                {
                }
                if (dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).Rowstatus != "Active")
                {
                    lContract = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ContractNo;
                    lSequence = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).MaxSequence;
                        /*
                         * UPDATE contract_renewals SET con_renewal_payment_value = con_renewal_benchmark_price  
                         * WHERE contract_renewals.contract_no = :lContract 
                         *   AND contract_renewals.contract_seq_number =  :lSequence ;
                         */
                    RDSDataService.UpdateContractRenewals2(lContract, lSequence, ref SQLCode, ref SQLErrText);
                    if (SQLCode == -(1))
                    {
                        MessageBox.Show(SQLErrText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //?rollback;
                        StaticVariables.gnv_app.of_hidestatus(ref w_status);
                        return;
                    }
                }
                    // dw_listing.SelectRow ( lRow, False)
                lRow = dw_listing.GetSelectedRow(lRow + 1);
            }
                //?commit ;
            StaticVariables.gnv_app.of_hidestatus(ref w_status);
                //?SetPointer(arrow!);
        }

        public virtual void cb_printsked_clicked(object sender, EventArgs e)
        {
            int lRow;
            int? lContract;
            int? lSequence;
            int lLoop;
            int lUpperBound;
            DateTime dDate = new DateTime();
            int ll_Cnt;
            int ll_Ctr = 0;
            int li_sched_row;
            string ls_dispatch = null;
            bool lb_printReport;

                //OpenWithParm(w_select_schedules2001, of_getparent());
            StaticMessage.PowerObjectParm = this.of_getparent();
            WSelectSchedules2001 w_select_schedules2001 = new WSelectSchedules2001();
            w_select_schedules2001.ShowDialog();

            if (StaticMessage.DoubleParm != 1)
            {
                return;
            }
            lRow = dw_listing.GetSelectedRow(0);
            if (lRow < 0)
            {
                MessageBox.Show("Please select a contract.", "Print Schedules", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ll_Cnt = of_getnumselectedrows();
 
                //jlwang: thread            
            Thread thread = new Thread(new ThreadStart(WStatusabortShow));
            thread.Priority = ThreadPriority.Highest;
            thread.Start();

            lUpperBound = sScheduleDWs.Count;    //..UpperBound;
            while (lRow >= 0)
            {
                ll_Ctr++;
                    //?if (IsValid(w_statusabort))
                    //{
                    //    w_statusabort.of_draw(ll_Ctr, ll_Cnt);
                    //}
                lContract = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).ContractNo;
                lSequence = dw_listing.DataObject.GetItem<ListContractsForProcessing2001>(lRow).MaxSequence;
                for (lLoop = 0; lLoop < lUpperBound; lLoop++)
                {
                        //dw_schedule.DataObject = sScheduleDWs[lLoop];
                        //!dw_schedule.SetDataObject(DEFAULT_ASSEMBLY, DEFAULT_VERSION, 
                        //!    "NZPostOffice.RDS.DataControls.Ruralrpt." + StaticFunctions.migrateName(sScheduleDWs[lLoop].ToString()));
                        //
                        //pp! modified the name to be full name otherwise there is another class 
                        //pp! NZPostOffice.RDS.DataControls.Report.Name which is report not DataUserControl
                    Type type = GetTypeInAssemblyByName(
                            string.Format("{0}, Version={1}, Culture=neutral, PublicKeyToken=null", DEFAULT_ASSEMBLY, DEFAULT_VERSION),
                            "NZPostOffice.RDS.DataControls.Ruralrpt." + StaticFunctions.migrateName(sScheduleDWs[lLoop].ToString()));
                    dw_schedule.DataObject = System.Activator.CreateInstance(type) as Metex.Windows.DataUserControl;




                        //?dw_schedule.settransobject(StaticVariables.sqlca);
                    if (sScheduleDWs[lLoop].ToString() == "r_contract_summary")
                    {
                            //?dDate = StaticFunctions.RelativeDate(Today(), 0 - Day(Today()));
                        dw_schedule.Retrieve(new object[] { lContract, lSequence, dDate });
                    }
                    else
                    {
                        dw_schedule.Retrieve(new object[] { lContract, lSequence });
                    }
                         //  TJB SR4615
                         //  Don't print where there's nothing to print on a schedule of mail carried.
                         //     ( decided by there being nothing in the mc_dispatch_carried column)
                    lb_printReport = true;
                    if (sScheduleDWs[lLoop].ToString() == "r_mail_carried_single_contract")
                    {
                        li_sched_row = dw_schedule.GetRow();

                        if(dw_schedule.GetValue(li_sched_row, "mc_dispatch_carried") != null)
                        {
                            ls_dispatch = dw_schedule.GetValue(li_sched_row, "mc_dispatch_carried").ToString();
                        }

                        if (ls_dispatch == null)
                        {
                            lb_printReport = false;
                        }
                    }
                    if (lb_printReport == true)
                    {                      
                        CrystalDecisions.Windows.Forms.CrystalReportViewer viewer = 
                            (CrystalDecisions.Windows.Forms.CrystalReportViewer)dw_schedule.DataObject.GetControlByName("viewer");

                        if (viewer != null)
                        {
                            viewer.RefreshReport();

                            ((CrystalDecisions.CrystalReports.Engine.ReportClass)
                                (((CrystalDecisions.Windows.Forms.CrystalReportViewer)
                                              (dw_schedule.DataObject.GetControlByName("viewer"))).ReportSource)).PrintToPrinter(1, false, 0, 0);
                        }

                            //!viewer.PrintReport();

                            /*? dw_schedule.Print(false);
                             *   while (Yield()) 
                             *  {
                             *  }
                             */
                    }                  


                    if (ib_PrintAbort)
                    {
                        lLoop = lUpperBound;
                        break;
                    }
                }
                if (ib_PrintAbort)
                {
                    lRow = 0;
                }
                else
                {
                        //dw_listing.SelectRow ( lRow, False)
                    lRow = dw_listing.GetSelectedRow(lRow + 1);
                }
            }

            if (thread != null && w_statusabort != null)
            {
                    //w_statusabort.Close();
                thread.Abort();
            }
        }


        private Type GetTypeInAssemblyByName(string assemblyName, string typeName)
        {
            System.Reflection.AssemblyName dllName = new System.Reflection.AssemblyName(assemblyName);

            System.Reflection.Assembly dll = System.Reflection.Assembly.Load(dllName);
            Type[] types = dll.GetTypes();
            foreach (Type t in types)
            {
                if (t.FullName == typeName)
                {
                    return t;
                }
            }
            return null;
        }

        public virtual void cb_searchs_clicked(object sender, EventArgs e)
        {
            int? lRegion;
            int? lRenewal;
            int? lContract;
            string sIndicator = string.Empty;
            bool bCheckRows = true;
            dw_criteria.AcceptText();
            lRegion = dw_criteria.GetItem<RenewalProcessCriteria>(0).RegionId;
            lRenewal = dw_criteria.GetItem<RenewalProcessCriteria>(0).RgCode;
            lContract = dw_criteria.GetItem<RenewalProcessCriteria>(0).ContractNo;
            if (StaticFunctions.f_nempty(lRenewal) && StaticFunctions.f_nempty(lContract))
            {
                MessageBox.Show("A renewal group or a contract has to be selected prior to performing a search on " + "the database", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bCheckRows = false;
            }
            else if (!(StaticFunctions.f_nempty(lRenewal)))
            {
                    /* select nvr_frozen_indicator into :sIndicator 
                     *   from non_vehicle_rate 
                     *  where rg_code = :lRenewal 
                     *    and nvr_rates_effective_date = (select max(nvr_rates_effective_date)
                     *                                      from non_vehicle_rate
                     *                                     where rg_code = :lRenewal);
                     */
                sIndicator = RDSDataService.GetNvrForzenIndicatorFormNonVehicle(lRenewal);
                if (sIndicator != "Y")
                {
                    MessageBox.Show("The current renewal group cannot be selected because its renewal rates have not " 
                                     + "been frozen", "", 
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bCheckRows = false;
                }
                else
                {
                    ((DListContractsForProcessing2001)dw_listing.DataObject).Retrieve(lRegion, lRenewal, lContract);
                }
            }
            else
            {
                ((DListContractsForProcessing2001)dw_listing.DataObject).Retrieve(lRegion, lRenewal, lContract);
            }
            if (dw_listing.RowCount > 0)
            {
                dw_listing.SelectRow(0, false);
            }
            if (bCheckRows)
            {
                if (dw_listing.RowCount == 0)
                {
                    MessageBox.Show("The search was not successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!(StaticFunctions.f_nempty(lContract)))
                {
                    dw_listing.SelectRow(1, true);
                }
            }
            this.l_1.Width = 328;
        }

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            dw_listing.SelectRow(0, false);
        }

        public virtual void dw_bm_report_doubleclicked(object sender, EventArgs e)
        {
            // this.print ( )
        }

        public virtual void dw_bm_report_retrievestart(object sender, EventArgs e)
        {
            //?return 2;
        }

        public virtual void cb_printbm_clicked(object sender, EventArgs e)
        {
            ((RBenchmarkReport2006)dw_benchmark_report.DataObject).Print();
        }

        #endregion
    }
}
