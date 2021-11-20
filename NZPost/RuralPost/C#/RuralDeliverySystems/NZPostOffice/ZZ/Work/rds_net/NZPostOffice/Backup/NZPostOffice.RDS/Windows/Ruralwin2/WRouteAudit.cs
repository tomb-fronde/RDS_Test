using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using Metex.Windows;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.Shared.VisualComponents;
using System.Collections.Generic;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    // TJB Release 7.1.6.5 Fixups
    // Fixed date string display for several dates (4-digit years)
    // - these in DRouteAuditDe and DRouteAuditDe.designer.
    // Added resizing (here).
    // NOTE:  Changing things via the designer can mess things up; hence the 
    //        object Anchor's added below.
    //
    // TJB  RPCR_027  May-2011
    // Added cb_print_detail, cb_print_blank buttons, and removed cb_print.
    // Removed print radio buttons (rb_detail1, rb_dblank1, rb_detail2, rb_detail2)
    // and surrounding groupings (gb_print1 and gb_1).
    // Lengthened dw_1, dw_2, dw_11.
    // Modified display of print buttons to be visible only when available.
    // Disabled the Resize code (it messes things up if the user tries to resize).
    //
    // NOTE:
    //     Don't try to modify the screens using the GUI editor!!!  The structure
    //     of this window seems to have been carefully crafted, and the GUI overwrites 
    //     it in a way that stuffs it up (no longer works)!!  
    // ==> Make any modifications by hand.

    public class WRouteAudit : WMaster
    {
        #region Define

        public URdsDw dw_12 = new URdsDw();//for variable dw_1 in pb

        public DataUserControlContainer dw_report = new DataUserControlContainer();

        public int ilcontract;

        public string is_ContractTitle = String.Empty;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_ok;

        public Label st_contract;

        public Button cb_cancel;

        public TabControl tab_1;

        public TabPage tabpage_1;

        public URdsDw dw_11;

        public URdsDw dw_report1;

        public TabPage tabpage_2;

        public TabControl tab_2;

        public TabPage tabpage_3;

        public URdsDw dw_1;

        public TabPage tabpage_4;

        public URdsDw dw_2;

        private Button cb_print_detail;

        private Button cb_print_blank;

        private Boolean ib_new;     // TJB RPCR_027: Added to flag inserted record

        #endregion

        public WRouteAudit()
        {
            m_sheet = new NZPostOffice.RDS.Menus.MSheet(this);
            this.InitializeComponent();

            dw_11.DataObject = new DRouteAuditDe();
            dw_report1.DataObject = new DRouteAuditDePrint();
            dw_11.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_2.DataObject = new DwRunningSheetHeader();

            m_sheet.m_print.Visible = false;
            m_sheet._m_print.Visible = false;

            this.ShowInTaskbar = false;
            AttachItemChangeEvent(); //added by jlwang for call itemchange

            dw_1.DataObject = new DRouteFrequencyForRouteAudit();
            dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //jlwang:moved fromIC
            //dw_11.DataObject.ItemChanged += new EventHandler(dw_11_itemchanged);
            // TJB  RPCR_027  May-2011: Changed validation to only the Date of Check
            dw_11.PfcValidation += new UserEventDelegate1(dw_11_pfcValidation);
            dw_1.DataObject.RetrieveEnd += new EventHandler(dw_1_retrieveend);
            //jlwang:end

            this.cb_print_detail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_print_blank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            
            this.tab_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));

            this.dw_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            this.tab_1 = new TabControl();
            this.cb_print_detail = new Button();
            this.cb_print_blank = new Button();
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(tab_1);
            Controls.Add(cb_print_detail);
            Controls.Add(cb_print_blank);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Route Audit";
            this.Size = new System.Drawing.Size(633, 488);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // 
            // cb_ok
            // 
            cb_ok.Text = "&OK";
            cb_ok.Enabled = true;
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(497, 428);
            cb_ok.Size = new System.Drawing.Size(54, 22);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "&Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(559, 428);
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // tab_1
            // 
            tabpage_1 = new TabPage();
            tabpage_2 = new TabPage();
            tab_1.Controls.Add(tabpage_1);
            tab_1.Controls.Add(tabpage_2);
            tab_1.SelectedIndex = 0;
            tab_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            tab_1.TabIndex = 1;
            tab_1.Location = new System.Drawing.Point(5, 1);
            tab_1.Size = new System.Drawing.Size(618, 423);
            tab_1.SelectedIndexChanged += new EventHandler(tab_1_selectionchanged);
            // 
            // tabpage_1
            // 
            st_contract = new Label();
            dw_11 = new URdsDw();
            //!dw_11.DataObject = new DRouteAuditDe();
            dw_report1 = new URdsDw();
            //!dw_report1.DataObject = new DRouteAuditDePrint();
            tabpage_1.Controls.Add(st_contract);
            tabpage_1.Controls.Add(dw_11);
            tabpage_1.Controls.Add(dw_report1);
            tabpage_1.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_1.Text = "Route Audit";
            tabpage_1.Name = tabpage_1.Text; // 
            tabpage_1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            tabpage_1.Top = 26;
            tabpage_1.Left = 3;
            tabpage_1.Size = new System.Drawing.Size(610, 393);

            // 
            // st_contract
            // 
            this.st_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_contract.ForeColor = System.Drawing.Color.Black;
            this.st_contract.BackColor = System.Drawing.SystemColors.Control;
            this.st_contract.Location = new System.Drawing.Point(3, 5);
            this.st_contract.Name = "st_contract";
            this.st_contract.Size = new System.Drawing.Size(407, 19);
            this.st_contract.TabIndex = 0;
            this.st_contract.BorderStyle = BorderStyle.None;
            this.st_contract.Text = "Contract: 5000 - This is the description for contract 5000";
            // 
            // dw_11
            // 
            dw_11.TabIndex = 0;
            //!dw_11.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_11.Location = new System.Drawing.Point(1, 3);
            dw_11.Size = new System.Drawing.Size(606, 390);

            // 
            // dw_report1
            // 
            dw_report1.TabIndex = 3;
            dw_report1.Location = new System.Drawing.Point(339, 11);
            dw_report1.Size = new System.Drawing.Size(154, 107);
            dw_report1.Visible = false;
            // 
            // tabpage_2
            // 
            tab_2 = new TabControl();
            tabpage_2.Controls.Add(tab_2);
            tabpage_2.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_2.Text = "Running Sheet";
            tabpage_2.Name = tabpage_2.Text;//
            tabpage_2.Size = new System.Drawing.Size(610, 393);
            tabpage_2.Top = 26;
            tabpage_2.Left = 3;
            // 
            // tab_2
            // 
            tabpage_3 = new TabPage();
            tabpage_4 = new TabPage();
            tab_2.Controls.Add(tabpage_3);
            tab_2.Controls.Add(tabpage_4);
            tab_2.SelectedIndex = 0;
            tab_2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            tab_2.TabIndex = 3;
            tab_2.Location = new System.Drawing.Point(8, 9);
            tab_2.Size = new System.Drawing.Size(594, 384);
            tab_2.SelectedIndexChanged += new EventHandler(tab_2_selectionchanged);
            // 
            // tabpage_3
            // 
            dw_1 = new URdsDw();
            //!            dw_1.DataObject = new DRouteFrequencyForRouteAudit();
            tabpage_3.Controls.Add(dw_1);
            tabpage_3.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_3.Text = "Frequencies";
            tabpage_3.Name = tabpage_3.Text;//
            tabpage_3.Size = new System.Drawing.Size(586, 354);
            tabpage_3.Top = 26;
            tabpage_3.Left = 3;
            // 
            // dw_1
            // 
            dw_1.TabIndex = 0;
            dw_1.Location = new System.Drawing.Point(5, 13);
            //!            dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_1.Size = new System.Drawing.Size(573, 368);
            dw_1.Location = new System.Drawing.Point(5, 13);
            dw_1.Click += new EventHandler(dw_1_clicked);
            //dw_1.DataObject.RetrieveEnd += new EventHandler(dw_1_retrieveend);
            // 
            // tabpage_4
            // 
            dw_2 = new URdsDw();
            //!dw_2.DataObject = new DwRunningSheetHeader();
            tabpage_4.Controls.Add(dw_2);
            tabpage_4.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_4.Text = "Details";
            tabpage_4.Name = tabpage_4.Text;//
            tabpage_4.Size = new System.Drawing.Size(586, 354);
            tabpage_4.Top = 26;
            tabpage_4.Left = 3;
            // 
            // dw_2
            // 
            //?dw_2.hscrollbar = true;
            dw_2.TabIndex = 3;
            dw_2.Location = new System.Drawing.Point(5, 8);
            dw_2.Size = new System.Drawing.Size(573, 348);
            // 
            // cb_print_detail
            // 
            cb_print_detail.Text = "Print Details";
            cb_print_detail.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_print_detail.TabIndex = 4;
            cb_print_detail.Location = new System.Drawing.Point(203, 428);
            cb_print_detail.Size = new System.Drawing.Size(96, 22);
            cb_print_detail.Click += new EventHandler(cb_print_detail_clicked);
            // 
            // cb_print_blank
            // 
            cb_print_blank.Text = "Print Blank Form";
            cb_print_blank.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_print_blank.TabIndex = 4;
            cb_print_blank.Location = new System.Drawing.Point(307, 428);
            cb_print_blank.Size = new System.Drawing.Size(96, 22);
            cb_print_blank.Click += new EventHandler(cb_print_blank_clicked);

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

        //added by jlwang 
        private void AttachItemChangeEvent()
        {
            foreach (Control control in this.dw_11.DataObject.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Validated += new EventHandler(dw_11_itemchanged);
                }
                else if (control is MaskedTextBox)
                {
                    //?((MaskedTextBox)control).TextChanged += new EventHandler(dw_11_itemchanged);
                    ((MaskedTextBox)control).Validated += new EventHandler(dw_11_itemchanged);
                }
            }
        }

        public override void open()
        {
            base.open();
            string sTitle;
            DateTime dAuditDate;
            dw_12 = dw_11;
            dw_report.DataObject = dw_report1.DataObject;
            NRdsMsg lnv_msg = new NRdsMsg();
            NCriteria lvn_Criteria = new NCriteria();
            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            ilcontract = Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            sTitle = Convert.ToString(lvn_Criteria.of_getcriteria("contract_title"));
            dAuditDate = Convert.ToDateTime(lvn_Criteria.of_getcriteria("ra_date_of_check"));
            is_ContractTitle = "Contract: " + ilcontract.ToString() + " - " + sTitle;
            dw_12.GetControlByName("st_contract").Text = is_ContractTitle;
            this.st_contract.Text = is_ContractTitle;
            if (dAuditDate == DateTime.MinValue)
            {
                dw_12.InsertItem<RouteAuditDe>(0);
                dw_12.SetValue(0, "contract_no", ilcontract);
                dw_12.SetValue(0, "ra_commencement_ok", "N");
                ((System.Windows.Forms.RadioButton)dw_12.GetControlByName("radioButton11")).Checked = true;//added by ylwang
                ib_new = true;
            }
            else
            {
                dw_12.Retrieve(new object[] { ilcontract, dAuditDate });
                ib_new = false;
            }
        }

        public override void close()
        {
            base.close();
            int iSheet = -1;
            for (int i = 0; i < StaticVariables.MainMDI.MdiChildren.Length; i++)
            {
                if (StaticVariables.MainMDI.MdiChildren[i] is WContract2001)
                {
                    iSheet = i;
                    break;
                }
            }
            if (iSheet >= 0)
                ((WContract2001)StaticVariables.MainMDI.MdiChildren[iSheet]).idw_route_audit.Retrieve(new object[] { ilcontract });
        }

        // TJB RPCR_027 May-2011: Modified to only check the date of check
        public int dw_11_pfcValidation()
        {
            // Returns
            //    1     Validated OK
            //   -1     Error (already diaplayed)

            // TJB RPCR_027 May-2011: Added message about what failed
            if (dw_11.GetItem<RouteAuditDe>(0).RaDateOfCheck == null)
            {
                MessageBox.Show("Validation errors in Audit report:\n\n"
                                + "Date of Check must be specified.\n"
                                , "Validation error");
                return -1;
            }
            return 1;
        }
        // TJB RPCR_027 May-2011: This is the original validation function
        public int dw_11_pfcValidation_original()
        {
            // Returns
            //    1     Validated OK
            //   -1     Error (already diaplayed)

            // TJB RPCR_027 May-2011: Added message about what failed
            string msg = "";
            if (dw_11.GetItem<RouteAuditDe>(0).RaDateOfCheck == null)
                msg += "Date of Check must be specified.\n";
            if (dw_11.GetItem<RouteAuditDe>(0).RaTimetableChange == null)
                msg += "RaTimetableChange is null\n";
            if (dw_11.GetItem<RouteAuditDe>(0).RaRouteOk == null)
                msg += "RaRouteOk is null\n";
            if (dw_11.GetItem<RouteAuditDe>(0).RaDeviations == null)
                msg += "RaDeviations is null\n";
            if (dw_11.GetItem<RouteAuditDe>(0).RaDeviationInDesc == null)
                msg += "RaDeviationInDesc is null\n";
            if (dw_11.GetItem<RouteAuditDe>(0).RaDescriptionUotdated == null)
                msg += "RaDescriptionUotdated is null\n";
            if (dw_11.GetItem<RouteAuditDe>(0).RaSaftyPracticesExists == null)
                msg += "RaSaftyPracticesExists is null\n";
            if (dw_11.GetItem<RouteAuditDe>(0).RaSaftyPlanCompleted == null)
                msg += "RaSaftyPlanCompleted is null\n";
            if ( msg != "" )
                MessageBox.Show("Validation errors in Audit report:\n\n" + msg
                                , "Validation errors");

            if (dw_11.GetItem<RouteAuditDe>(0).RaDateOfCheck == null ||
                dw_11.GetItem<RouteAuditDe>(0).RaTimetableChange == null ||
                dw_11.GetItem<RouteAuditDe>(0).RaRouteOk == null ||
                dw_11.GetItem<RouteAuditDe>(0).RaDeviations == null ||
                dw_11.GetItem<RouteAuditDe>(0).RaDeviationInDesc == null ||
                dw_11.GetItem<RouteAuditDe>(0).RaDescriptionUotdated == null ||
                dw_11.GetItem<RouteAuditDe>(0).RaSaftyPracticesExists == null ||
                dw_11.GetItem<RouteAuditDe>(0).RaSaftyPlanCompleted == null)
            {
                return -1;
            }
            return 1;
        }

        #region Events
        public override void resize(object sender, EventArgs args)
        {
            /*
                base.resize(sender, args);

                // setredraw ( false)
                tab_1.Height = Height - 250;
                tab_1.Width = Width - 100;
                cb_print.Top = tab_1.Left + tab_1.Height + 20;
                cb_ok.Top = cb_print.Top;
                cb_cancel.Top = cb_print.Top;
                dw_11.Width = tab_1.Width - 100;
                dw_11.Height = tab_1.Height - 400;
                gb_print1.Top = dw_11.Left + dw_11.Height + 20;
                rb_audit1.Top = gb_print1.Top + 50;
                rb_blank1.Top = rb_audit1.Top + 83;
                tab_2.Width = tab_1.Width - 100;
                tab_2.Height = tab_1.Height - 200;
                dw_1.Width = tab_2.Width - 100;
                dw_1.Height = tab_2.Height - 250;
                dw_2.Width = tab_2.Width - 100;
                dw_2.Height = tab_2.Height - 400;
                gb_1.Top = dw_2.Top + dw_2.Height + 20;
                rb_blank2.Top = gb_1.Top + 50;
                rb_details2.Top = rb_blank2.Top + 83;
                //?SetRedraw(true);
            */
        }

        // TJB  RPCR_027  May-2011
        // Split off from cb_ok_clicked so can be called separately
        public virtual void save_audit_details(URdsDw dw)
        {
            DateTime? checkdate;
            DateTime? starttime, endtime;

            dw.DataObject.Save();
            checkdate = dw.GetValue<DateTime?>(0, "ra_date_of_check");
            starttime = dw.GetValue<DateTime?>(0, "ra_time_finished_sort");
            endtime = dw.GetValue<DateTime?>(0, "ra_time_started_sort");
            //UPDATE contract SET con_last_delivery_check = :checkdate 
            // WHERE contract_no  = :ilcontract
            RDSDataService dataService = RDSDataService.UpdateContract(checkdate, ilcontract);

            if (!(starttime == null) || !(endtime == null))
            {
                //UPDATE contract SET con_last_work_msrmnt_check = :checkdate 
                // WHERE  contract_no = :ilcontract
                dataService = RDSDataService.UpdateContract2(checkdate, ilcontract);
            }
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            // TJB  RPCR_027  May-2011
            // Actions split off into a separate function

            // If the datawindow is "dirty", we need to save it
            if (StaticFunctions.IsDirty(dw_11))
            {
                if (dw_11_pfcValidation() == 1)
                {
                    save_audit_details(dw_11);
                }
                else
                {
                    DialogResult ans;
                    ans = MessageBox.Show("The information entered does not pass validation  \n"
                                    + "and must be corrected before changes can be saved.  \n"
                                    + "\n"
                                    + "Close without saving changes?"
                                    , "Warning"
                                    , MessageBoxButtons.YesNo
                                    , MessageBoxIcon.Exclamation
                                    , MessageBoxDefaultButton.Button1);
                    if (ans == DialogResult.Yes)
                        StaticFunctions.MarkDwClean(dw_11);
                    else
                        return;
                }
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            if ( StaticFunctions.IsDirty( dw_11 ) ) {
                StaticFunctions.MarkDwClean( dw_11 );
            }
            this.Close();
        }

        public virtual void tab_1_selectionchanged(object sender, EventArgs e)
        {
            int tab1SelectedIndex = tab_1.SelectedIndex;
            if (tab1SelectedIndex < 0)
            {
                return;
            }
            if (tab1SelectedIndex < 0) tab1SelectedIndex = 0;
            if (tab_1.TabPages[tab1SelectedIndex].Text.ToLower().Trim() == "running sheet")//(tab_1.SelectedIndex == 1)
            {
                DataUserControlContainer dwa_1 = new DataUserControlContainer();
                dwa_1 = dw_1;
                dwa_1.Retrieve(new object[] { ilcontract });
                if (dwa_1.RowCount > 0)
                {
                    dwa_1.SelectRow(0, true);
                }
                cb_print_detail.Enabled = false;
                cb_print_blank.Enabled = false;
            }
            else
            {
                cb_print_detail.Enabled = true;
                cb_print_blank.Enabled = true;
            }
        }

        public virtual void dw_11_itemchanged(object sender, EventArgs e)
        {
            DateTime? tStartTime;
            DateTime? tEndTime;
            DateTime? tHours = null;
            DateTime? tMeals = null;
            DateTime? tExtra = null;
            DateTime? tTotal = null;
            bool bCalcTime = false;
            bool bCalcConsumption = false;
            int iCount = 0;
            DateTime? dtCheck;
            int? ll_Contract = ilcontract;

            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string FieldChanged = (((Control)sender)).Name;
            if (FieldChanged == "ra_date_of_check")
            {
                dtCheck = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaDateOfCheck;
                //ll_Contract = StaticVariables.gnv_app.of_get_parameters().integerparm;
                //select count(*) into :icount from route_audit where ra_date_of_check = :dtCheck and contract_no = :ll_Contract ;
                iCount = RDSDataService.GetRouteAuditCount(dtCheck, ll_Contract);
                if (ib_new && iCount > 0)
                {
                    string sDateCheck = Convert.ToString(dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaDateOfCheck);
                    sDateCheck = sDateCheck.Substring(0, sDateCheck.IndexOf(' '));  // Use only the date part
                    MessageBox.Show("There is already a route audit for " + sDateCheck + ".\n" 
                                    + "You may not have two route audits for the same day.\n" 
                                    + "Either select a different date or delete the old route audit."
                                    , this.Text
                                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else if (FieldChanged == "ra_time_returned")
            {
                tEndTime = Convert.ToDateTime(dw_11.GetControlByName("ra_time_returned").Text);
                tStartTime = Convert.ToDateTime(tEndTime.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(0).RaTimeDeparted.GetValueOrDefault().ToString("HH:mm"));
                tHours = StaticVariables.gnv_app.of_hoursafter(tStartTime, tEndTime);
                dw_11.SetValue(0, "ra_total_hours", tHours);
                bCalcTime = true;
            }
            else if (FieldChanged == "ra_time_departed")
            {
                tStartTime = Convert.ToDateTime(dw_11.GetControlByName("ra_time_departed").Text);// Time(dw_11.GetText());
                tEndTime = Convert.ToDateTime(tStartTime.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(0).RaTimeReturned.GetValueOrDefault().ToString("HH:mm"));
                tHours = StaticVariables.gnv_app.of_hoursafter(tStartTime, tEndTime);
                dw_11.SetValue(0, "ra_total_hours", tHours);
                bCalcTime = true;
            }
            else if (FieldChanged == "ra_meal_breaks")
            {
                tMeals = Convert.ToDateTime(dw_11.GetControlByName("ra_meal_breaks").Text);//Time(dw_11.GetText());
                // tExtra = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaExtraTime; //dw_11.GetItemDateTime(1, "ra_extra_time").TimeOfDay;
                tExtra = Convert.ToDateTime(tMeals.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaExtraTime.GetValueOrDefault().ToString("HH:mm"));
                tHours = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaTotalHours; //dw_11.GetItemDateTime(1, "ra_total_hours").TimeOfDay;
                bCalcTime = true;
            }
            else if (FieldChanged == "ra_extra_time")
            {
                tExtra = Convert.ToDateTime(dw_11.GetControlByName("ra_extra_time").Text); //Time(dw_11.GetText());
                // tMeals = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaMealBreaks; //dw_11.GetItemDateTime(1, "ra_meal_breaks").TimeOfDay;
                tMeals = Convert.ToDateTime(tExtra.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaMealBreaks.GetValueOrDefault().ToString("HH:mm"));
                tHours = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaTotalHours; //dw_11.GetItemDateTime(1, "ra_total_hours").TimeOfDay;
                bCalcTime = true;
            }
            else if (FieldChanged == "ra_fuel_used" || FieldChanged == "ra_fuel_distance")
            {
                bCalcConsumption = true;
            }
            if (bCalcTime)
            {
                tTotal = StaticVariables.gnv_app.of_subhours(tHours, tMeals);
                tTotal = StaticVariables.gnv_app.of_subhours(tTotal, tExtra);
                dw_11.SetValue(0, "ra_final_hours", tTotal);
            }
            if (bCalcConsumption)
            {
                string sFuelUsed, sFuelDistance;
                decimal dFuelUsed, dFuelDistance, dFuelConsumption;
                sFuelUsed = dw_11.GetControlByName("ra_fuel_used").Text;
                sFuelDistance = dw_11.GetControlByName("ra_fuel_distance").Text;
                dFuelUsed = Convert.ToDecimal(sFuelUsed);
                dFuelDistance = Convert.ToDecimal(sFuelDistance);
                if (dFuelDistance == 0)
                    dFuelConsumption = 0;
                else
                    dFuelConsumption = (dFuelUsed * 100) / dFuelDistance;

                dw_11.SetValue(0, "ra_fuel_consumption", dFuelConsumption);
            }
            this.dw_11.AcceptText();
            this.dw_11.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public virtual void tab_2_selectionchanged(object sender, EventArgs e)
        {
            DataUserControlContainer dwa_1 = new DataUserControlContainer();
            DataUserControlContainer dwa_2 = new DataUserControlContainer();
            dwa_1 = dw_1;
            dwa_2 = dw_2;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string str = tab_2.TabPages[tab_2.SelectedIndex].Text.ToLower().Trim();
            if (str == "frequencies")
            {
                if (dwa_1.RowCount == 0)
                {
                    dwa_1.Retrieve(new object[] { ilcontract });
                    if (dwa_1.RowCount > 0)
                        dwa_1.SelectRow(1, true);
                }
                cb_print_detail.Enabled = false;
                cb_print_blank.Enabled = false;
            }
            else if (str == "details")
            {
                if (dwa_1.RowCount > 0)
                {
                    int lsfk;
                    int lrow;
                    string sdeldays;
                    lrow = dwa_1.GetRow();// lrow = dwa_1.GetSelectedRow(0);
                    if (lrow >= 0)
                    {
                        lsfk = Convert.ToInt32(dwa_1.DataObject.GetValue(lrow, "sf_key"));
                        sdeldays = Convert.ToString(dwa_1.DataObject.GetValue(lrow, "rf_delivery_days"));
                        dwa_2.Retrieve(new object[] { ilcontract, lsfk, sdeldays });
                        if (dwa_2.RowCount < 16)
                        {
                            while (dwa_2.RowCount < 16)
                            {
                                dwa_2.InsertItem<RunningSheetHeader>(0);
                            }
                        }
                        //?dwa_2.Object.DataWindow.Print.preview = "yes";
                    }
                    else
                    {
                        MessageBox.Show("Please select a frequency"
                                        , this.Text
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                cb_print_detail.Enabled = true;
                cb_print_blank.Enabled = true;
            }
        }

        public virtual void dw_1_clicked(object sender, EventArgs e)
        {
            if (dw_1.GetRow() >= 0)
            {
                dw_1.SelectRow(0, false);
                dw_1.SelectRow(dw_1.GetRow() + 1, true);
            }
        }

        public virtual void dw_1_retrieveend(object sender, EventArgs e)
        {
            dw_1.DataObject.GetControlByName("st_contract").Text = is_ContractTitle;
        }

        public virtual void cb_print_detail_clicked(object sender, EventArgs e)
        {
            DataUserControlContainer dw_audit = new DataUserControlContainer();
            dw_audit = dw_2;
            if (tab_1.SelectedIndex == 0)
            {
                // TJB  RPCR_027  May-2011
                // If the datawindow is "dirty", we need to save it 
                // before we can print it (because the print uses Crystal 
                // Reports, and that retrieves the data it wants from the 
                // database rather than using the existing datawindow).
                if (StaticFunctions.IsDirty(dw_11))
                {
                    if (dw_11_pfcValidation() == 1)
                    {
                        dw_11.AcceptText();
                        save_audit_details(dw_11);
                    }
                    else
                    {
                        MessageBox.Show("The information entered does not pass validation  \n"
                                       + "and cannot be saved or printed.  \n"
                                       , "Warning" );
                        return;
                    }
                }
                dw_report.DataObject.Reset();
                dw_report.DataObject = new DRouteAuditDePrint();
                ((DRouteAuditDePrint)dw_report.DataObject).Retrieve(ilcontract, Convert.ToDateTime(((NRdsMsg)StaticMessage.PowerObjectParm).of_getcriteria().of_getcriteria("ra_date_of_check")));
                TextObject obj = ((DRouteAuditDePrint)dw_report.DataObject).ReportDocument.ReportDefinition.ReportObjects["st_contract"] as TextObject;
                if (obj != null)
                {
                    obj.Text = is_ContractTitle;
                }
                ((DRouteAuditDePrint)dw_report.DataObject).Print();
            }
            else
            {
                ((NZPostOffice.RDS.DataControls.Ruraldw.DwRunningSheetHeader)dw_audit.DataObject).Print();
            }
        }

        public virtual void cb_print_blank_clicked(object sender, EventArgs e)
        {
            DataUserControlContainer dw_audit = new DataUserControlContainer();
            dw_audit = dw_2; 
            if (tab_1.SelectedIndex == 0)
            {
                dw_report.DataObject.Reset();
                dw_report.DataObject = new DRouteAuditDePrintBlank();
                dw_report.InsertItem<RouteAuditDePrintBlank>(0);
                TextObject obj = ((DRouteAuditDePrintBlank)dw_report.DataObject).ReportDocument.ReportDefinition.ReportObjects["st_contract"] as TextObject;
                if (obj != null)
                {
                    obj.Text = is_ContractTitle;
                }
                ((DRouteAuditDePrintBlank)dw_report.DataObject).Print();
            }
            else
            {
                int il;
                dw_audit.DataObject.Reset();
                for (il = 1; il <= 16; il++)
                {
                    dw_audit.InsertItem<RunningSheetHeader>(0);
                }
                ((NZPostOffice.RDS.DataControls.Ruraldw.DwRunningSheetHeader)dw_audit.DataObject).Print();
            }
        }

        #endregion
    }
}
