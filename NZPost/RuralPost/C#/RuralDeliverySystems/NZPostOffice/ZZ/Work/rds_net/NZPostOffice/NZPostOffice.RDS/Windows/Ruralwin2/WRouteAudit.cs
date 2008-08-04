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

        public RadioButton rb_blank1;

        public RadioButton rb_audit1;

        public GroupBox gb_print1;

        public URdsDw dw_11;

        public URdsDw dw_report1;

        public TabPage tabpage_2;

        public TabControl tab_2;

        public TabPage tabpage_3;

        public URdsDw dw_1;

        public TabPage tabpage_4;

        public URdsDw dw_2;

        public RadioButton rb_blank2;

        public RadioButton rb_details2;

        public GroupBox gb_1;

        public Button cb_print;

        #endregion

        public WRouteAudit()
        {
            m_sheet = new NZPostOffice.RDS.Menus.MSheet(this);
            this.InitializeComponent();
            m_sheet.m_print.Visible = false;
            m_sheet._m_print.Visible = false;

            this.ShowInTaskbar = false;
            AttachItemChangeEvent(); //added by jlwang for call itemchange

            //jlwang:moved fromIC
            //dw_11.DataObject.ItemChanged += new EventHandler(dw_11_itemchanged);
            dw_11.PfcValidation += new UserEventDelegate1(dw_11_pfcValidation);
            dw_1.DataObject.RetrieveEnd += new EventHandler(dw_1_retrieveend);
            //jlwang:end
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
            this.cb_print = new Button();
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(tab_1);
            Controls.Add(cb_print);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Route Audit";
            this.Size = new System.Drawing.Size(633, 488);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // 
            // cb_ok
            // 
            cb_ok.Text = "&OK";
            cb_ok.Enabled = false;
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(410, 431);
            cb_ok.Size = new System.Drawing.Size(54, 22);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "&Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(478, 431);
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
            rb_blank1 = new RadioButton();
            rb_audit1 = new RadioButton();
            st_contract = new Label();
            gb_print1 = new GroupBox();
            dw_11 = new URdsDw();
            dw_11.DataObject = new DRouteAuditDe();
            dw_report1 = new URdsDw();
            dw_report1.DataObject = new DRouteAuditDePrint();
            tabpage_1.Controls.Add(rb_blank1);
            tabpage_1.Controls.Add(rb_audit1);
            tabpage_1.Controls.Add(gb_print1);
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
            // rb_blank1
            // 
            rb_blank1.Text = "Blank Form";
            rb_blank1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            rb_blank1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_blank1.Size = new System.Drawing.Size(88, 18);
            rb_blank1.Top = 359;
            rb_blank1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            rb_blank1.Left = 222;
            rb_blank1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rb_audit1
            // 
            rb_audit1.Checked = true;
            rb_audit1.Text = "Details";
            rb_audit1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            rb_audit1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            rb_audit1.Location = new System.Drawing.Point(222, 340);
            rb_audit1.Size = new System.Drawing.Size(88, 17);
            rb_audit1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_print1
            // 
            gb_print1.Text = "Print";
            gb_print1.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            gb_print1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            gb_print1.TabIndex = 3;
            gb_print1.Location = new System.Drawing.Point(214, 326);
            gb_print1.Size = new System.Drawing.Size(107, 55);
            // 
            // dw_11
            // 
            dw_11.TabIndex = 0;
            dw_11.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_11.Location = new System.Drawing.Point(1, 3);
            dw_11.Size = new System.Drawing.Size(606, 319);

            //dw_11.DataObject.ItemChanged += new EventHandler(dw_11_itemchanged);
            //dw_11.PfcValidation += new UserEventDelegate1(dw_11_pfcValidation);

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
            dw_1.DataObject = new DRouteFrequencyForRouteAudit();
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
            dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_1.Size = new System.Drawing.Size(573, 338);
            dw_1.Location = new System.Drawing.Point(5, 13);
            dw_1.Click += new EventHandler(dw_1_clicked);
            //dw_1.DataObject.RetrieveEnd += new EventHandler(dw_1_retrieveend);
            // 
            // tabpage_4
            // 
            dw_2 = new URdsDw();
            dw_2.DataObject = new DwRunningSheetHeader();
            rb_blank2 = new RadioButton();
            rb_details2 = new RadioButton();
            gb_1 = new GroupBox();
            tabpage_4.Controls.Add(dw_2);
            tabpage_4.Controls.Add(rb_blank2);
            tabpage_4.Controls.Add(rb_details2);
            tabpage_4.Controls.Add(gb_1);
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
            dw_2.Size = new System.Drawing.Size(573, 283);
            // 
            // rb_blank2
            // 
            rb_blank2.Text = "Blank Form";
            rb_blank2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            rb_blank2.Location = new System.Drawing.Point(225, 314);
            rb_blank2.Size = new System.Drawing.Size(82, 19);
            rb_blank2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rb_details2
            // 
            rb_details2.Checked = true;
            rb_details2.Text = "Details";
            rb_details2.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            rb_details2.Location = new System.Drawing.Point(225, 331);
            rb_details2.Size = new System.Drawing.Size(82, 18);
            rb_details2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gb_1
            // 
            gb_1.Text = "Print";
            gb_1.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            gb_1.TabIndex = 3;
            gb_1.Location = new System.Drawing.Point(212, 297);
            gb_1.Size = new System.Drawing.Size(107, 56);
            // 
            // cb_print
            // 
            cb_print.Text = "Print";
            cb_print.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_print.TabIndex = 4;
            cb_print.Location = new System.Drawing.Point(247, 431);
            cb_print.Size = new System.Drawing.Size(54, 22);
            cb_print.Click += new EventHandler(cb_print_clicked);
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
            if (dAuditDate == DateTime.MinValue/*System.Convert.ToDateTime("00-00-0000")*/)
            {
                dw_12.InsertItem<RouteAuditDe>(0);
                dw_12.SetValue(0, "contract_no", ilcontract);
                dw_12.SetValue(0, "ra_commencement_ok", "N");
                ((System.Windows.Forms.RadioButton)dw_12.GetControlByName("radioButton11")).Checked = true;//added by ylwang
            }
            else
            {
                dw_12.Retrieve(new object[] { ilcontract, dAuditDate });
                cb_print.Enabled = true;
            }
        }

        public override void close()
        {
            base.close();
            //  testing twc
            //  get contract window to retrieve again
            int ll_sheetcount = int.MinValue;
            List<WContract2001> lw_opensheets = new List<WContract2001>();
            FormBase lw_frame;// w_frame lw_frame;
            lw_frame = StaticVariables.gnv_app.of_getframe();
            /*?if (IsValid(lw_frame.inv_sheetmanager) == false) {
                lw_frame.inv_sheetmanager = new NCstWinsrvSheetmanager();
            }*/
            //ll_sheetcount = lw_frame.inv_sheetmanager.of_getsheetsbyclass(lw_opensheets, "w_contract2001");
            //if (ll_sheetcount < 2 && ll_sheetcount > 0)
            //{
            //    lw_opensheets[1].idw_route_audit.Retrieve(new object[] { ilcontract });
            //}

            //ttjin
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

        public int dw_11_pfcValidation()
        {
            if (dw_11.GetItem<RouteAuditDe>(0).RaTimetableChange == null ||
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

        public virtual void ue_dwnrbuttonclk()
        {
            // 
        }

        public virtual void tab_2_constructor()
        {
            //?dw_1.settransobject(StaticVariables.sqlca);
            //?dw_2.settransobject(StaticVariables.sqlca);
        }

        public virtual void constructor()
        {
            //?base.constructor();
        }

        #region Events
        public override void resize(object sender, EventArgs args)
        {
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
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //Not parsed PB function body

            dw_12.DataObject.Save();// dw_1.Save();
            DateTime? checkdate;
            DateTime? starttime, endtime;
            checkdate = dw_12.GetValue<DateTime?>(0, "ra_date_of_check");
            starttime = dw_12.GetValue<DateTime?>(0, "ra_time_finished_sort");
            endtime = dw_12.GetValue<DateTime?>(0, "ra_time_started_sort");
            //update
            //UPDATE "contract" SET "con_last_delivery_check" = :checkdate WHERE  "contract"."contract_no" = :ilcontract ;
            RDSDataService dataService = RDSDataService.UpdateContract(checkdate, ilcontract);

            if (!(starttime == null) || !(endtime == null))
            {
                //UPDATE "contract" SET "con_last_work_msrmnt_check" = :checkdate WHERE  "contract"."contract_no" = :ilcontract ;
                dataService = RDSDataService.UpdateContract2(checkdate, ilcontract);
            }
            if (dataService.SQLCode != 0)
            {
                //?Rollback;
            }
            else
            {
                //?Commit;
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void tab_1_selectionchanged(object sender, EventArgs e)
        {
            if (tab_1.TabPages[tab_1.SelectedIndex].Text.ToLower().Trim() == "running sheet")//(tab_1.SelectedIndex == 1)
            {
                DataUserControlContainer dwa_1 = new DataUserControlContainer();
                dwa_1 = dw_1;
                dwa_1.Retrieve(new object[] { ilcontract });
                if (dwa_1.RowCount > 0)
                {
                    dwa_1.SelectRow(0, true);
                }
            }
        }

        public virtual void dw_11_itemchanged(object sender, EventArgs e)
        {
            //?base.itemchanged();
            DateTime? tStartTime;
            DateTime? tEndTime;
            DateTime? tHours = null;// new DateTime();
            DateTime? tMeals = null;
            DateTime? tExtra = null;
            DateTime? tTotal = null;// new DateTime();
            bool bCalcTime = false;
            bool bCalcDistance = false;
            int iCount = 0;
            DateTime? dtCheck;
            int? ll_Contract = 0;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = (((Control)sender)).Name;// dw_11.GetColumnName();
            if (TestExpr == "ra_date_of_check")
            {
                dtCheck = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaDateOfCheck;
                ll_Contract = StaticVariables.gnv_app.of_get_parameters().integerparm;
                //select count(*) into :icount from route_audit where ra_date_of_check = :dtCheck and contract_no = :ll_Contract ;
                iCount = RDSDataService.GetRouteAuditCount(dtCheck, ll_Contract);
                if (iCount > 0)
                {
                    MessageBox.Show("There is already a route audit for " + Convert.ToString(dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaDateOfCheck) + ".~rYou may not have two route audits for the same day.~rEither select a different" + " date or delete the old route audit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //dw_11.SetText("");
                    dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaDateOfCheck = Convert.ToDateTime("");
                    // 		This.DataControl["ra_date_of_check"].Focus()
                    //return 2;
                    return;
                }
                else
                {
                    DateTime ret;
                    cb_ok.Enabled = DateTime.TryParse(Convert.ToString(dw_11.GetValue(dw_11.GetRow(), "ra_date_of_check")), out ret);// IsDate(dw_11.GetText());
                }
            }
            else if (TestExpr == "ra_time_returned")
            {
                tEndTime = Convert.ToDateTime(dw_11.GetControlByName("ra_time_returned").Text);// Time(dw_11.GetText());
                tStartTime = Convert.ToDateTime(tEndTime.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(0).RaTimeDeparted.GetValueOrDefault().ToString("HH:mm"));
                // tStartTime = dw_11.GetItem<RouteAuditDe>(0).RaTimeDeparted;// dw_11.GetItemDateTime(1, "ra_time_departed").TimeOfDay;
                tHours = StaticVariables.gnv_app.of_hoursafter(tStartTime, tEndTime);
                dw_11.SetValue(0, "ra_total_hours", tHours);
                bCalcTime = true;
            }
            else if (TestExpr == "ra_time_departed")
            {
                tStartTime = Convert.ToDateTime(dw_11.GetControlByName("ra_time_departed").Text);// Time(dw_11.GetText());
                tEndTime = Convert.ToDateTime(tStartTime.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(0).RaTimeReturned.GetValueOrDefault().ToString("HH:mm"));
                tHours = StaticVariables.gnv_app.of_hoursafter(tStartTime, tEndTime);
                dw_11.SetValue(0, "ra_total_hours", tHours);
                bCalcTime = true;
            }
            else if (TestExpr == "ra_meal_breaks")
            {
                tMeals = Convert.ToDateTime(dw_11.GetControlByName("ra_meal_breaks").Text);//Time(dw_11.GetText());
               // tExtra = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaExtraTime; //dw_11.GetItemDateTime(1, "ra_extra_time").TimeOfDay;
                tExtra = Convert.ToDateTime(tMeals.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaExtraTime.GetValueOrDefault().ToString("HH:mm"));
                tHours = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaTotalHours; //dw_11.GetItemDateTime(1, "ra_total_hours").TimeOfDay;
                bCalcTime = true;
            }
            else if (TestExpr == "ra_extra_time")
            {
                tExtra = Convert.ToDateTime(dw_11.GetControlByName("ra_extra_time").Text); //Time(dw_11.GetText());
               // tMeals = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaMealBreaks; //dw_11.GetItemDateTime(1, "ra_meal_breaks").TimeOfDay;
                tMeals = Convert.ToDateTime(tExtra.GetValueOrDefault().ToString("dd/MM/yyyy") + " " + dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaMealBreaks.GetValueOrDefault().ToString("HH:mm"));
                tHours = dw_11.GetItem<RouteAuditDe>(dw_11.GetRow()).RaTotalHours; //dw_11.GetItemDateTime(1, "ra_total_hours").TimeOfDay;
                bCalcTime = true;
            }
            if (bCalcTime)
            {
                tTotal = StaticVariables.gnv_app.of_subhours(tHours, tMeals);
                tTotal = StaticVariables.gnv_app.of_subhours(tTotal, tExtra);
                dw_11.SetValue(0, "ra_final_hours", tTotal);
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
            int TestExpr = tab_2.SelectedIndex;// newindex;
            string str = tab_2.TabPages[tab_2.SelectedIndex].Text.ToLower().Trim();
            if (str == "frequencies")//(TestExpr == 0)
            {
                if (dwa_1.RowCount == 0)
                {
                    dwa_1.Retrieve(new object[] { ilcontract });
                    if (dwa_1.RowCount > 0)
                    {
                        dwa_1.SelectRow(1, true);
                    }
                }
            }
            else if (str == "details")// (TestExpr == 1)
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
                        MessageBox.Show("Please select a frequency", "Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public virtual void dw_1_clicked(object sender, EventArgs e)
        {
            //?base.clicked();
            if (dw_1.GetRow() >= 0)
            {
                dw_1.SelectRow(0, false);
                dw_1.SelectRow(dw_1.GetRow() + 1, true);
            }
        }

        public virtual void dw_1_retrieveend(object sender, EventArgs e)
        {
            //?base.retrieveend();
            //  PBY 21/06/2002 SR#4407
            dw_1.DataObject.GetControlByName("st_contract").Text = is_ContractTitle;
        }

        public virtual void cb_print_clicked(object sender, EventArgs e)
        {
            int lContract;
            string test;
            DataUserControlContainer dw_audit = new DataUserControlContainer();
            DataUserControlContainer dwa_2 = new DataUserControlContainer();
            dw_audit = dw_2;
            if (tab_1.SelectedIndex == 0)
            {
                dw_report.DataObject.Reset();
                if (rb_audit1.Checked)
                {
                    dw_report.DataObject = new DRouteAuditDePrint();
                    ((DRouteAuditDePrint)dw_report.DataObject).Retrieve(ilcontract, Convert.ToDateTime(((NRdsMsg)StaticMessage.PowerObjectParm).of_getcriteria().of_getcriteria("ra_date_of_check")));
                    //?dw_1.Print();
                    TextObject obj = ((DRouteAuditDePrint)dw_report.DataObject).ReportDocument.ReportDefinition.ReportObjects["st_contract"] as TextObject;
                    if (obj != null)
                    {
                        obj.Text = is_ContractTitle;
                    }
                    ((DRouteAuditDePrint)dw_report.DataObject).Print();
                }
                else
                {
                    dw_report.DataObject = new DRouteAuditDePrintBlank();
                    dw_report.InsertItem<RouteAuditDePrintBlank>(0);
                    //test = dw_report.DataObject.GetControlByName("st_contract").Text = is_ContractTitle;
                    //?dw_report.Print();
                    TextObject obj = ((DRouteAuditDePrintBlank)dw_report.DataObject).ReportDocument.ReportDefinition.ReportObjects["st_contract"] as TextObject;
                    if (obj != null)
                    {
                        obj.Text = is_ContractTitle;
                    }
                    ((DRouteAuditDePrintBlank)dw_report.DataObject).Print();
                }
                return;
            }
            // Above is the new version of what the code below could not do !
            // if tab_1.selectedtab=1  then
            // 
            // 	dw_report.Reset ( )
            // 		if tab_1.tabpage_1.rb_audit1.checked  then
            // 		dw_report.dataobject = "d_route_audit_de_print"
            // 	else
            // 		dw_report.dataobject = "d_route_audit_de_print_blank"
            // 		dw_report.insertrow ( 1)
            // 	end if
            // 	   //dw_1.ShareData ( dw_report)
            // 
            // //	lContract 	= gnv_App.of_Get_Parameters ( ).integerparm
            // 
            // 	dw_report.Print ( )
            // 	//dw_1.print ( )
            // 	//dw_1.ShareDataOff ( )
            // 	return
            // end if
            // 
            if (dw_audit.Visible)
            {
                if (rb_details2.Checked)
                {
                    /*
                    int l1;
                    int l2;
                    string srows;
                    DataUserControlContainer dwa_1 = new DataUserControlContainer();
                    dwa_1.DataObject = dw_1.DataObject;
                    dwa_2.DataObject = dw_2.DataObject;
                    if (dwa_1.RowCount > 0)
                    {
                        int lsfk;
                        int lrow;
                        string sdeldays;
                        lrow = dwa_1.GetSelectedRow(0);
                        if (lrow > 0)
                        {
                            lsfk = Convert.ToInt32(dwa_1.DataObject.GetValue(lrow, "sf_key"));
                            sdeldays = Convert.ToString(dwa_1.DataObject.GetValue(lrow, "rf_delivery_days"));
                            ((DwRunningSheetHeader)dwa_2.DataObject).Retrieve(ilcontract, lsfk, sdeldays);
                            if (dwa_2.RowCount < 16)
                            {
                                while (dwa_2.RowCount < 16)
                                {
                                    dwa_2.InsertItem<RunningSheetHeader>(0);
                                }
                            }
                        }
                    }
                    l1 = dw_audit.RowCount;
                    //  fill up last page 
                    //?dw_audit.Object.DataWindow.Print.preview = "no";
                    //dw_audit.ScrollToRow(1000);
                    dw_audit.SetCurrent(1000);
                    for (l2 = 1; l2 <= 16 - 16 / l1; l2++)//Mod(l1, 16)
                    {
                        dw_audit.InsertItem<RunningSheetHeader>(0);
                    }
                    //dw_audit.ScrollToRow(1);
                    dw_audit.SetCurrent(0);
                    //?dw_audit.Object.DataWindow.Print.preview = "yes";
                    dw_audit.ResumeLayout(false);
                    //?dw_audit.Print();
                    */
                }
                else
                {
                    /*
                    dw_2.Reset();
                    
                    //dwa_2.DataObject = dw_2.DataObject;
                    //?dwa_2.Object.DataWindow.Print.preview = "no";
                    dwa_2.SuspendLayout();
                    for (il = 1; il <= 16; il++)
                    {
                        dwa_2.InsertItem<RunningSheetHeader>(0);
                    }
                    //?dwa_2.Object.DataWindow.Print.preview = "yes";
                    dwa_2.ResumeLayout(false);
                    //?dwa_2.Print();
                    */
                    int il;
                    dw_audit.DataObject.Reset();
                    for (il = 1; il <= 16; il++)
                    {
                        dw_audit.InsertItem<RunningSheetHeader>(0);
                    }
                }
                ((NZPostOffice.RDS.DataControls.Ruraldw.DwRunningSheetHeader)dw_audit.DataObject).Print();
            }
        }
        #endregion
    }
}
