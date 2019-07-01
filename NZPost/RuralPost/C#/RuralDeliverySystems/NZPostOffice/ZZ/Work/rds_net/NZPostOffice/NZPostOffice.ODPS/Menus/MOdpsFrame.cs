using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Windows.OdpsPayrun;
using NZPostOffice.ODPS.Windows.Odps;
using NZPostOffice.ODPS.Windows.OdpsLib;
using NZPostOffice.ODPS.Windows.OdpsRep;
using NZPostOffice.ODPS.Windows.OdpsInvoice;
using NZPostOffice.ODPS.Windows.Ruralbase;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
using CrystalDecisions.Windows.Forms;

namespace NZPostOffice.ODPS.Menus
{
    // TJB  RPCR_128  Jun-2019
    // Added m_irdPaydayInterface and m_irdPaydayInterface_clicked
    //
    // TJB  RPCR_098  Jan-2016
    // Added m_ptdimport and m_ptdimport_clicked()

    public class MOdpsFrame : MFrame
    {
        public MOdpsFrame(Form form)
            : base(form)
        {
        }

        #region Menu Define
        //Record
        public ToolStripMenuItem m_record;
        public ToolStripMenuItem m_addrow;
        public ToolStripMenuItem m_insertrow;
        public ToolStripMenuItem m_deleterow;

        //Owner Driver Payment
        public ToolStripMenuItem m_odps;
        public ToolStripMenuItem m_paymentrun;
        public ToolStripMenuItem m_codetabelemaintenance;
        public ToolStripMenuItem m_generalledgeraccrualinterface;
        public ToolStripMenuItem m_payments;
        public ToolStripMenuItem m_accruals;
        public ToolStripMenuItem m_invoicemailinginterface;
        public ToolStripMenuItem m_accountspayableinterface;
        public ToolStripMenuItem m_ir3interfacereport;
        public ToolStripMenuItem m_ir348interface;
        public ToolStripMenuItem m_irdPaydayInterface;
        public ToolStripMenuItem m_updatedcontractorsexport;
        public ToolStripMenuItem m_shellimport;
        public ToolStripMenuItem m_telecomimport;
        public ToolStripMenuItem m_ptdimport;
        public ToolStripMenuItem m_pots;

        //Rural Delvery
        public ToolStripMenuItem m_ruraldelivery;
        public ToolStripMenuItem m_contracts;
        public ToolStripMenuItem m_ownerdrivers;
        public ToolStripMenuItem m_piecerates;

        //Report
        public ToolStripMenuItem m_reports;
        public ToolStripMenuItem m_historyofchanges;
        public ToolStripMenuItem m_withholdingtax;
        public ToolStripMenuItem m_yearlyearnings;
        public ToolStripMenuItem m_ir68air68p;
        public ToolStripMenuItem m_ir66es;
        public ToolStripMenuItem m_negativepay;
        public ToolStripMenuItem m_grosspayvariance;
        public ToolStripMenuItem m_ir66n;
        public ToolStripMenuItem m_auditrecordofchanges;
        public ToolStripMenuItem m_contractoraddresschanges;
        public ToolStripMenuItem m_paymentsummary;
        public ToolStripMenuItem m_post_taxadjustment;
        public ToolStripMenuItem m_summary;
        public ToolStripMenuItem m_detailsregional;

        public ToolStripMenuItem m_post_taxadjustments2; //needs remove?

        public ToolStripMenuItem m_volumesvalues;
        public ToolStripMenuItem m_summary1;
        public ToolStripMenuItem m_detail;

        public ToolStripMenuItem m_volumesvalues2; //needs remove?

        //Security
        public ToolStripMenuItem m_security;
        public ToolStripMenuItem m_changepassword;

        //File
        public ToolStripMenuItem m_printersetup;

        //Help
        public ToolStripMenuItem m_index;
        #endregion

        #region ToolBar Define
        //toolStrip
        public ToolStripButton _m_printersetup;
        public ToolStripButton _m_paymentrun;
        public ToolStripButton _m_invoicemailinginterface;

        #endregion

        public override void BuildMenu(Form form)
        {
            base.BuildMenu(form);

            //set the showtext unchecked
            ((ToolStripMenuItem)this.ToolStrip.ContextMenuStrip.Items[8]).Checked = false;

            MenuStrip.Items.Remove(m_window);
            MenuStrip.Items.Remove(m_help);

            #region File
            //
            //file
            //
            m_new.Visible = false;
            m_open.Visible = false;
            m_dash11.Visible = false;
            m_save.Visible = false;
            m_saveas.Visible = false;
            m_print.Visible = false;
            m_printpreview.Visible = false;
            m_pagesetup.Visible = false;
            m_printimmediate.Visible = false;
            m_dash13.Visible = false;
            m_delete.Visible = false;
            m_properties.Visible = false;
            m_dash14.Visible = false;
            m_pfcmrudash1.Visible = false;
            m_pfcmru1.Visible = false;
            m_pfcmru2.Visible = false;
            m_pfcmru3.Visible = false;
            m_pfcmru4.Visible = false;
            m_pfcmru5.Visible = false;

            m_printersetup = new ToolStripMenuItem();
            m_printersetup.Text = "Printer Set&up";

            m_file.DropDownItems.Add(m_printersetup);
            m_printersetup.Click += new EventHandler(m_printersetup_clicked);

            m_file.DropDownItems.Add(new ToolStripSeparator());

            m_file.DropDownItems.Remove(m_exit);
            m_file.DropDownItems.Add(m_exit);
            m_exit.Click += new EventHandler(m_exit_clicked);

            #endregion

            #region Edit

            //
            //m_edit
            //
            m_edit.Visible = false;
            m_edit.Enabled = false;
            m_pastespecial.Visible = false;
            m_clear.Visible = false;
            m_dash22.Visible = false;
            m_selectall.Visible = false;
            m_dash23.Visible = false;
            m_find.Visible = false;
            m_replace.Visible = false;
            m_dash24.Visible = false;
            m_updatelinks.Visible = false;
            m_object1.Visible = false;

            #endregion

            #region View
            //
            //m_view
            //
            m_view.Visible = false;
            m_view.Enabled = false;

            #endregion

            #region Record
            //
            //m_record
            //
            m_record = new ToolStripMenuItem("&Record", null, null, "m_record");
            m_record.MergeAction = MergeAction.Replace;
            MenuStrip.Items.Add(m_record);

            m_record.Visible = false;
            m_record.Enabled = false;
            //
            //m_addrow
            //
            m_addrow = new ToolStripMenuItem("&Add Row", null, null, "m_addrow");
            //m_addrow.ToolTipText = "Add a new row at the bottom";
            m_record.DropDown.Items.Add(m_addrow);
            m_addrow.Click += new EventHandler(m_addrow_clicked);
            //
            //m_insertrow
            //
            m_insertrow = new ToolStripMenuItem("&Insert Row", null, null, "m_insertrow");
            m_record.DropDownItems.Add(m_insertrow);
            //m_insertrow.ToolTipText = "Insert a new row before the current row";
            m_record.DropDownItems.Add(new ToolStripSeparator());
            m_insertrow.Click += new EventHandler(m_insertrow_clicked);

            //
            //m_deleterow
            //
            m_deleterow = new ToolStripMenuItem("&Delete Row", null, null, "m_deleterow");
            m_record.DropDownItems.Add(m_deleterow);
            //m_deleterow.ToolTipText = "Delete the current row";
            m_deleterow.Click += new EventHandler(m_deleterow_clicked);

            #endregion

            #region Owner Driver Payment

            // 
            // m_odps
            // 
            m_odps = new ToolStripMenuItem();
            m_odps.Enabled = false;
            m_odps.Visible = false;

            m_odps.MergeAction = MergeAction.Remove;
            m_odps.Text = "&Owner Driver Payment";

            m_odps.Tag = "ComponentName=ODPS Payrun;ComponentName=ODPS Parameters;ComponentName=ODPS Financials;ComponentName=ODPS Invoice;";

            m_paymentrun = new ToolStripMenuItem();
            m_codetabelemaintenance = new ToolStripMenuItem();
            m_generalledgeraccrualinterface = new ToolStripMenuItem();
            m_invoicemailinginterface = new ToolStripMenuItem();
            m_accountspayableinterface = new ToolStripMenuItem();
            m_ir3interfacereport = new ToolStripMenuItem();
            m_ir348interface = new ToolStripMenuItem();
            m_irdPaydayInterface = new ToolStripMenuItem();
            m_updatedcontractorsexport = new ToolStripMenuItem();
            m_shellimport = new ToolStripMenuItem();
            m_telecomimport = new ToolStripMenuItem();
            m_ptdimport = new ToolStripMenuItem();
            m_pots = new ToolStripMenuItem();

            MenuStrip.Items.Add(m_odps);

            m_odps.DropDownItems.Add(m_paymentrun);
            m_odps.DropDownItems.Add(m_codetabelemaintenance);
            m_odps.DropDownItems.Add(m_generalledgeraccrualinterface);
            m_odps.DropDownItems.Add(m_invoicemailinginterface);
            m_odps.DropDownItems.Add(m_accountspayableinterface);
            m_odps.DropDownItems.Add(m_ir3interfacereport);
            m_odps.DropDownItems.Add(m_ir348interface);
            m_odps.DropDownItems.Add(m_irdPaydayInterface);
            m_odps.DropDownItems.Add(m_updatedcontractorsexport);
            m_odps.DropDownItems.Add(m_shellimport);
            m_odps.DropDownItems.Add(m_telecomimport);
            m_odps.DropDownItems.Add(m_ptdimport);
            m_odps.DropDownItems.Add(m_pots);

            // 
            // m_paymentrun
            // 
            m_paymentrun.Text = "&Payment Run";
            m_paymentrun.Enabled = false;
            m_paymentrun.Visible = false;

            m_paymentrun.Tag = "ComponentName=ODPS Payrun;";
            //?m_paymentrun.EnabledChanged += new EventHandler(m_paymentrun_EnabledChanged);
            m_paymentrun.Click += new EventHandler(m_paymentrun_clicked);

            // 
            // m_codetabelemaintenance
            // 
            m_codetabelemaintenance.Text = "&Code Table Maintenance";
            m_codetabelemaintenance.Enabled = false;
            m_codetabelemaintenance.Visible = false;

            m_codetabelemaintenance.ToolTipText = "Code table maintenance";
            m_codetabelemaintenance.Tag = "ComponentName=ODPS Parameters;";
            m_codetabelemaintenance.Click += new EventHandler(m_codetabelemaintenance_clicked);

            // 
            // m_generalledgeraccrualinterface
            // 
            m_generalledgeraccrualinterface.Text = "&General Ledger Accrual Interface";
            m_generalledgeraccrualinterface.Enabled = false;
            m_generalledgeraccrualinterface.Visible = false;

            m_generalledgeraccrualinterface.Tag = "ComponentName=ODPS Financials;";
            m_payments = new ToolStripMenuItem();
            m_accruals = new ToolStripMenuItem();
            m_generalledgeraccrualinterface.DropDownItems.Add(m_payments);
            m_generalledgeraccrualinterface.DropDownItems.Add(m_accruals);
            // 
            // m_payments
            // 
            m_payments.Text = "Payments";
            m_payments.Click += new EventHandler(m_payments_clicked);

            // 
            // m_accruals
            // 
            m_accruals.Text = "Accruals";
            m_accruals.Click += new EventHandler(m_accruals_clicked);

            // 
            // m_invoicemailinginterface
            // 
            m_invoicemailinginterface.Text = "&Invoice PSR File";
            m_invoicemailinginterface.Enabled = false;
            m_invoicemailinginterface.Visible = false;

            m_invoicemailinginterface.Tag = "ComponentName=ODPS Invoice;";
            //?m_invoicemailinginterface.EnabledChanged += new EventHandler(m_invoicemailinginterface_EnabledChanged);
            m_invoicemailinginterface.Click += new EventHandler(m_invoicemailinginterface_clicked);


            // 
            // m_accountspayableinterface
            // 
            m_accountspayableinterface.Text = "&Accounts Payable Interface";
            m_accountspayableinterface.Enabled = false;
            m_accountspayableinterface.Visible = false;

            m_accountspayableinterface.Tag = "ComponentName=ODPS Financials;";
            m_accountspayableinterface.Click += new EventHandler(m_accountspayableinterface_clicked);

            // 
            // m_ir3interfacereport
            // 
            m_ir3interfacereport.Text = "IR&13 Interface/Report";
            m_ir3interfacereport.Enabled = false;
            m_ir3interfacereport.Visible = false;

            m_ir3interfacereport.Tag = "ComponentName=ODPS Financials;";
            m_ir3interfacereport.Click += new EventHandler(m_ir3interfacereport_clicked);

            // 
            // m_ir348interface
            // 
            m_ir348interface.Text = "IR348 Interface";
            m_ir348interface.Enabled = false;
            m_ir348interface.Visible = false;

            m_ir348interface.Tag = "ComponentName=ODPS Financials;";
            m_ir348interface.Click += new EventHandler(m_ir348interface_clicked);
            // 
            // m_irdPaydayInterface
            // 
            m_irdPaydayInterface.Text = "IRD Payday Interface";
            m_irdPaydayInterface.Enabled = false;
            m_irdPaydayInterface.Visible = false;

            m_irdPaydayInterface.Tag = "ComponentName=ODPS Financials;";
            m_irdPaydayInterface.Click += new EventHandler(m_irdPaydayInterface_clicked);
            // 
            // m_updatedcontractorsexport
            // 
            m_updatedcontractorsexport.Text = "Updated Contractors Export";
            m_updatedcontractorsexport.Enabled = false;
            m_updatedcontractorsexport.Visible = false;

            m_updatedcontractorsexport.Tag = "ComponentName=ODPS Financials;";
            m_updatedcontractorsexport.Click += new EventHandler(m_updatedcontractorsexport_clicked);
            // 
            // m_shellimport
            // 
            m_shellimport.Text = "&Shell Import...";
            m_shellimport.Enabled = false;
            m_shellimport.Visible = false;
            m_shellimport.Tag = "ComponentName=ODPS Financials;";
            m_shellimport.Click += new EventHandler(m_shellimport_clicked);
            // 
            // m_telecomimport
            // 
            m_telecomimport.Text = "&Telecom Import...";
            m_telecomimport.Enabled = false;
            m_telecomimport.Visible = false;
            m_telecomimport.Tag = "ComponentName=ODPS Financials;";
            m_telecomimport.Click += new EventHandler(m_telecomimport_clicked);
            // 
            // m_ptdimport
            // 
            m_ptdimport.Text = "&PTD Import...";
            m_ptdimport.Enabled = false;
            m_ptdimport.Visible = false;
            m_ptdimport.Tag = "ComponentName=ODPS Financials;";
            m_ptdimport.Click += new EventHandler(m_ptdimport_clicked);

            //
            //m_pots
            //
            m_pots.Text = "POTS";
            m_pots.Tag = "Payments outside the system";
            m_pots.Click += new EventHandler(m_pots_clicked);
            #endregion

            #region Rural Delivery

            // 
            // m_ruraldelivery
            // 
            m_ruraldelivery = new ToolStripMenuItem();
            m_ruraldelivery.Text = "&Rural Delivery";
            m_ruraldelivery.Visible = false;
            m_ruraldelivery.Enabled = false;
            m_contracts = new ToolStripMenuItem();
            m_ownerdrivers = new ToolStripMenuItem();
            m_piecerates = new ToolStripMenuItem();

            MenuStrip.Items.Add(m_ruraldelivery);

            m_ruraldelivery.DropDownItems.Add(m_contracts);
            m_ruraldelivery.DropDownItems.Add(m_ownerdrivers);
            m_ruraldelivery.DropDownItems.Add(m_piecerates);
            // 
            // m_contracts
            // 
            m_contracts.Text = "&Contracts";
            m_contracts.Visible = false;
            m_contracts.Enabled = false;
            m_contracts.Click += new EventHandler(m_contracts_clicked);

            // 
            // m_ownerdrivers
            // 
            m_ownerdrivers.Text = "&Owner Drivers";
            m_ownerdrivers.Visible = false;
            m_ownerdrivers.Enabled = false;
            m_ownerdrivers.Click += new EventHandler(m_ownerdrivers_clicked);
            // 
            // m_piecerates
            // 
            m_piecerates.Text = "&Piece Rates Import";
            m_piecerates.Visible = false;
            m_piecerates.Enabled = false;
            m_piecerates.Click += new EventHandler(m_piecerates_clicked);
            #endregion

            #region Report

            // 
            // m_reports
            // 
            m_reports = new ToolStripMenuItem();
            m_reports.Enabled = false;
            m_reports.Visible = false;

            m_reports.MergeAction = MergeAction.Remove;

            m_reports.Tag = "ComponentName=ODPS Reports;";
            m_reports.Text = "Re&ports";
            MenuStrip.Items.Add(m_reports);


            // 
            // m_historyofchanges
            // 
            m_historyofchanges = new ToolStripMenuItem();
            m_historyofchanges.Text = "&History of Changes";

            //jlwang:customer require
            //m_reports.DropDownItems.Add(m_historyofchanges);
            m_historyofchanges.Click += new EventHandler(m_historyofchanges_clicked);

            // 
            // m_withholdingtax
            // 
            m_withholdingtax = new ToolStripMenuItem();
            m_withholdingtax.Text = "&Withholding Tax";
            m_reports.DropDownItems.Add(m_withholdingtax);
            m_withholdingtax.Click += new EventHandler(m_withholdingtax_clicked);
            // 
            // m_yearlyearnings
            // 
            m_yearlyearnings = new ToolStripMenuItem();
            m_yearlyearnings.Text = "&Yearly Earnings";
            m_reports.DropDownItems.Add(m_yearlyearnings);
            m_yearlyearnings.Click += new EventHandler(m_yearlyearnings_clicked);
            // 
            // m_ir68air68p
            // 
            m_ir68air68p = new ToolStripMenuItem();
            m_ir68air68p.Text = "&IR68A && IR68P";
            //jlwang:customer require
            //m_reports.DropDownItems.Add(m_ir68air68p);
            m_ir68air68p.Click += new EventHandler(m_ir68air68p_clicked);
            // 
            // m_ir66es
            // 
            m_ir66es = new ToolStripMenuItem();
            m_ir66es.Text = "IR66E&S";
            m_reports.DropDownItems.Add(m_ir66es);
            m_ir66es.Click += new EventHandler(m_ir66es_clicked);
            // 
            // m_negativepay
            // 
            m_negativepay = new ToolStripMenuItem();
            m_negativepay.Text = "&Negative Pay";
            //jlwang:customer require
            //m_reports.DropDownItems.Add(m_negativepay);
            m_negativepay.Click += new EventHandler(m_negativepay_clicked);
            // 
            // m_grosspayvariance
            // 
            m_grosspayvariance = new ToolStripMenuItem();
            m_grosspayvariance.Text = "Gross Pay &Variance";
            m_reports.DropDownItems.Add(m_grosspayvariance);
            m_grosspayvariance.Click += new EventHandler(m_grosspayvariance_clicked);
            // 
            // m_ir66n
            // 
            m_ir66n = new ToolStripMenuItem();
            m_ir66n.Text = "IR345";
            m_reports.DropDownItems.Add(m_ir66n);
            m_ir66n.Click += new EventHandler(m_ir66n_clicked);
            // 
            // m_auditrecordofchanges
            // 
            m_auditrecordofchanges = new ToolStripMenuItem();
            m_auditrecordofchanges.Text = "&Audit Record of Changes";
            m_reports.DropDownItems.Add(m_auditrecordofchanges);
            m_auditrecordofchanges.Click += new EventHandler(m_auditrecordofchanges_clicked);
            // 
            // m_contractoraddresschanges
            // 
            m_contractoraddresschanges = new ToolStripMenuItem();
            m_contractoraddresschanges.Text = "C&ontractor Address Changes";
            m_reports.DropDownItems.Add(m_contractoraddresschanges);
            m_contractoraddresschanges.Click += new EventHandler(m_contractoraddresschanges_clicked);
            // 
            // m_paymentsummary
            // 
            m_paymentsummary = new ToolStripMenuItem();
            m_paymentsummary.Text = "Paymen&t Summary";
            m_reports.DropDownItems.Add(m_paymentsummary);
            m_paymentsummary.Click += new EventHandler(m_paymentsummary_clicked);
            // 
            // m_post-taxadjustment
            // 
            m_post_taxadjustment = new ToolStripMenuItem();
            m_post_taxadjustment.Text = "&Post-Tax Adjustment";
            m_reports.DropDownItems.Add(m_post_taxadjustment);

            // 
            // m_summary
            // 
            m_summary = new ToolStripMenuItem();
            m_summary.Text = "Summary  ( National)";
            m_post_taxadjustment.DropDownItems.Add(m_summary);
            m_summary.Click += new EventHandler(m_summary_clicked);
            // 
            // m_detailsregional
            // 
            m_detailsregional = new ToolStripMenuItem();
            m_detailsregional.Text = "Detail  ( Regional)";
            m_post_taxadjustment.DropDownItems.Add(m_detailsregional);
            m_detailsregional.Click += new EventHandler(m_detailsregional_clicked);
            // 
            // m_post-taxadjustments2
            // 
            m_post_taxadjustments2 = new ToolStripMenuItem();

            m_post_taxadjustments2.Text = "&Post-Tax Adjustments";
            m_post_taxadjustments2.Visible = false;
            m_post_taxadjustments2.Enabled = false;
            m_reports.DropDownItems.Add(m_post_taxadjustments2);
            m_post_taxadjustments2.Click += new EventHandler(m_post_taxadjustments2_clicked);

            // 
            // m_volumesvalues
            // 
            m_volumesvalues = new ToolStripMenuItem();
            m_volumesvalues.Text = "Pie&ce Rates";
            m_reports.DropDownItems.Add(m_volumesvalues);


            // 
            // m_summary1
            // 
            m_summary1 = new ToolStripMenuItem();
            m_summary1.Text = "Summary";
            m_volumesvalues.DropDownItems.Add(m_summary1);
            m_summary1.Click += new EventHandler(m_summary1_clicked);
            // 
            // m_detail
            // 
            m_detail = new ToolStripMenuItem();
            m_detail.Text = "Detail";
            m_volumesvalues.DropDownItems.Add(m_detail);
            m_detail.Click += new EventHandler(m_detail_clicked);
            // 
            // m_volumesvalues2
            // 
            m_volumesvalues2 = new ToolStripMenuItem();

            m_volumesvalues2.Visible = false;
            m_volumesvalues2.Enabled = false;
            m_volumesvalues2.Text = "Pie&ce Rates";
            m_volumesvalues2.Enabled = false;
            m_reports.DropDownItems.Add(m_volumesvalues2);
            m_volumesvalues2.Click += new EventHandler(m_volumesvalues2_clicked);

            #endregion

            #region Security
            // 
            // m_security
            // 
            m_security = new ToolStripMenuItem();
            m_security.MergeAction = MergeAction.Replace;
            m_security.Text = "&Security";
            MenuStrip.Items.Add(m_security);

            //
            //m_changepassword
            //
            m_changepassword = new ToolStripMenuItem();
            m_changepassword.Text = "&Change password";
            m_security.DropDownItems.Add(m_changepassword);
            m_changepassword.Click += new EventHandler(m_changepassword_clicked);

            #endregion

            #region m_window
            m_minimizeall.Visible = false;
            m_undoarrange.Visible = false;
            m_dash51.Visible = false;

            if (form.IsMdiContainer)
            {
                MenuStrip.Items.Add(m_window);
                MenuStrip.MdiWindowListItem = m_window;
            }
            #endregion

            #region m_help
            m_index = new ToolStripMenuItem();
            m_index.Text = "&Index";


            MenuStrip.Items.Add(m_help);
            m_help.DropDownItems.Insert(1, m_index);

            #endregion

            #region Toolbar

            _m_printersetup = new ToolStripButton("Printer Setup", global::NZPostOffice.Shared.Properties.Resources.print22, null, "_m_printersetup");
            _m_printersetup.MergeAction = MergeAction.MatchOnly;
            _m_printersetup.ImageTransparentColor = System.Drawing.Color.White;
            _m_printersetup.Click += new EventHandler(m_printersetup_clicked);
            ToolStrip.Items.Add(_m_printersetup);

            ToolStrip.Items.Add(new ToolStripSeparator());

            _m_paymentrun = new ToolStripButton("Payment Run", global::NZPostOffice.Shared.Properties.Resources.Run, null, "_m_paymentrun");
            _m_paymentrun.Visible = false;

            _m_paymentrun.MergeAction = MergeAction.MatchOnly;
            _m_paymentrun.ImageTransparentColor = System.Drawing.Color.White;
            _m_paymentrun.Click += new EventHandler(m_paymentrun_clicked);
            ToolStrip.Items.Add(_m_paymentrun);

            _m_invoicemailinginterface = new ToolStripButton("Invoice", global::NZPostOffice.Shared.Properties.Resources.FormatDollar_, null, "_m_invoicemailinginterface");
            _m_invoicemailinginterface.Visible = false;

            _m_invoicemailinginterface.MergeAction = MergeAction.MatchOnly;
            _m_invoicemailinginterface.Click += new EventHandler(m_invoicemailinginterface_clicked);
            ToolStrip.Items.Add(_m_invoicemailinginterface);

            if (_m_exit != null)
            {
                ToolStrip.Items.Remove(_m_exit);
                _m_exit.Image = global::NZPostOffice.Shared.Properties.Resources.EXIT1;
                ToolStrip.Items.Add(_m_exit);
            }
            else
            {
                _m_exit = new ToolStripButton("Exit", null, null, "m_exit");
                _m_exit.Image = global::NZPostOffice.Shared.Properties.Resources.EXIT1;
                _m_exit.ImageTransparentColor = System.Drawing.Color.White;
                _m_exit.Click += new EventHandler(m_exit_clicked);
                ToolStrip.Items.Add(_m_exit);
            }

            #endregion
        }

        #region Event

        public virtual void m_printersetup_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //PrintSetup();
            PrintDialog printDlg = new PrintDialog();
            printDlg.ShowDialog();
        }

        public virtual void m_addrow_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_AddRow
            // 	Method:			Clicked
            // 	Description:	send a message to the control to add a row
            // of_sendmessage("pfc_AddRow");

            ((WCodeTableMaintenance)StaticVariables.MainMDI.ActiveMdiChild).pfc_addrow();
        }

        public virtual void m_insertrow_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_InsertRow
            // 	Method:			Clicked
            // 	Description:	send a message to the control to Insert a row
            // of_sendmessage("pfc_InsertRow");


        }

        public virtual void m_deleterow_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_DeleteRow
            // 	Method:			Clicked
            // 	Description:	send a message to the control to Delete a row
            // of_sendmessage("pfc_DeleteRow");
            ((WCodeTableMaintenance)StaticVariables.MainMDI.ActiveMdiChild).pfc_deleterow();
        }

        public virtual void m_paymentrun_clicked(object sender, EventArgs e)
        {
            DialogResult ll_response;
            //WPots w_window;
            Cursor.Current = Cursors.WaitCursor;
            //  TWC - 26/05/2003 - ask the user if there are any POTS to be inputted
            ll_response = MessageBox.Show("Are there any POTS to be entered for this payment run?", "Payment run detail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ll_response == DialogResult.Yes)
            {
                //  opent the pots window
                //OpenSheetWithParm(w_window, "POTS", ParentWindow, 0, original!);
                OpenSheet<WPots>(StaticVariables.MainMDI);
            }
            else
            {
                //OpenSheet(w_payment_run_search, ParentWindow, 0, original!);
                OpenSheet<WPaymentRunSearch>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_codetabelemaintenance_clicked(object sender, EventArgs e)
        {
            // 	Object:			m_OrderEntry.m_Edit.m_CodeMaintenance
            // 	Method:			Clicked
            // 	Description:	open the sheet for code maintenance
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_code_table_maintenance, ParentWindow, 0, original!);
            OpenSheet<WCodeTableMaintenance>(StaticVariables.MainMDI);
        }

        public virtual void m_payments_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("General Ledger Interface-Payments")))
            {
                //OpenSheetWithParm(w_window, "GL Interface-Payments", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "GL Interface-Payments";
                OpenSheetAll<WExportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_accruals_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("General Ledger Interface-Accruals")))
            {
                //OpenSheetWithParm(w_window, "GL Interface-Accruals", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "GL Interface-Accruals";
                OpenSheetAll<WExportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_invoicemailinginterface_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("Invoice")))
            {
                //OpenSheetWithParm(w_invoice_search, "Invoice", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "Invoice";
                OpenSheetAll<WInvoiceSearch>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_accountspayableinterface_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("Accounts Payable Interface")))
            {
                //OpenSheetWithParm(w_window, "Accounts Payable Interface", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "Accounts Payable Interface";
                OpenSheetAll<WExportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_ir3interfacereport_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("IR13 Interface")))
            {
                //OpenSheetWithParm(w_window, "IR13 Interface", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "IR13 Interface";
                OpenSheetAll<WExportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_ir348interface_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("IR348 Interface")))
            {
                //OpenSheetWithParm(w_window, "IR348 Interface", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "IR348 Interface";
                OpenSheetAll<WExportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_irdPaydayInterface_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("IRD Payday Interface")))
            {
                //OpenSheetWithParm(w_window, "IRD Payday Interface", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "IRD Payday Interface";
                OpenSheetAll<WExportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_updatedcontractorsexport_clicked(object sender, EventArgs e)
        {
            WExportCriteria w_window;
            if (!(mf_check_window("Updated Contractors")))
            {
                //OpenSheetWithParm(w_window, "Updated Contractors", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "Updated Contractors";
                OpenSheetAll<WExportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_shellimport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_shell_import, ParentWindow, 0, original!);
            OpenSheet<WShellImport>(StaticVariables.MainMDI);
        }

        public virtual void m_telecomimport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_telecom_import, ParentWindow, 0, original!);
            OpenSheet<WTelecomImport>(StaticVariables.MainMDI);
        }

        public virtual void m_ptdimport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenSheet<WPTDImport>(StaticVariables.MainMDI);
        }

        public virtual void m_contracts_clicked(object sender, EventArgs e)
        {
            //?mf_run_rds("Contract Search");
        }

        public virtual void m_ownerdrivers_clicked(object sender, EventArgs e)
        {
            //?mf_run_rds("Owner Driver");
        }

        public virtual void m_piecerates_clicked(object sender, EventArgs e)
        {
            //?mf_run_rds("Piece Rates Import");
        }

        public virtual void m_pots_clicked(object sender, EventArgs e)
        {
            WPots w_window;
            if (!(mf_check_window("POTS")))
            {
                //OpenSheetWithParm(w_window, "POTS", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "POTS";
                OpenSheetAll<WPots>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_historyofchanges_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("History of Changes Report")))
            {
                // OpenSheetWithParm(w_window, "HistoryOfChanges", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "HistoryOfChanges";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_withholdingtax_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Withholding Tax Report")))
            {
                // OpenSheetWithParm(w_window, "WithholdingTax", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "WithholdingTax";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_yearlyearnings_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Yearly Earnings Report")))
            {
                // OpenSheetWithParm(w_window, "YearlyEarnings", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "YearlyEarnings";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_ir68air68p_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("IR68A and IR68P Report")))
            {
                // OpenSheetWithParm(w_window, "IR68A&IR68P", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "IR68A&IR68P";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_ir66es_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("IR66ES Report")))
            {
                // OpenSheetWithParm(w_window, "IR66ES", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "IR66ES";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_negativepay_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Negative Pay Report")))
            {
                // OpenSheetWithParm(w_window, "NegativePay", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "NegativePay";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_grosspayvariance_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Gross Pay Variance Report")))
            {
                // OpenSheetWithParm(w_window, "GrossPayVariance", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "GrossPayVariance";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_ir66n_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("IR66N Report")))
            {
                // OpenSheetWithParm(w_window, "IR66N", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "IR66N";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_auditrecordofchanges_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;

            if (!(mf_check_window("Audit Record Changes Report")))
            {
                // OpenSheetWithParm(w_window, "AuditRecordChanges", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "AuditRecordChanges";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_contractoraddresschanges_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Contractor Address Changes Report")))
            {
                // OpenSheetWithParm(w_window, "ContractorAddressChanges", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "ContractorAddressChanges";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_paymentsummary_clicked(object sender, EventArgs e)
        {
            WReportCriteriaCtype w_window;
            if (!(mf_check_window("Payment Summary Report")))
            {
                //OpenSheetWithParm(w_window, "PaymentSummary", gnv_app.of_getframe(), 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "PaymentSummary";
                OpenSheetAll<WReportCriteriaCtype>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_summary_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Post Tax Adjustments Summary")))
            {
                // OpenSheetWithParm(w_window, "PostTaxAdjustments", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "PostTaxAdjustments";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_detailsregional_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Post Tax Adjustments Detail")))
            {
                // OpenSheetWithParm(w_window, "PostTaxAdjustments2", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "PostTaxAdjustments2";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_post_taxadjustments2_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Post Tax Adjustments Report")))
            {
                // OpenSheetWithParm(w_window, "PostTaxAdjustments2", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "PostTaxAdjustments2";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_summary1_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Piece Rate Summary")))
            {
                // OpenSheetWithParm(w_window, "VolumesValues", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "VolumesValues";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_detail_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Piece Rate Detail")))
            {
                // OpenSheetWithParm(w_window, "VolumesValues2", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "VolumesValues2";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_volumesvalues2_clicked(object sender, EventArgs e)
        {
            WReportCriteria w_window;
            if (!(mf_check_window("Piece Rate Detail")))
            {
                // OpenSheetWithParm(w_window, "VolumesValues2", ParentWindow, 0, original!);
                Cursor.Current = Cursors.WaitCursor;
                StaticMessage.StringParm = "VolumesValues2";
                OpenSheetAll<WReportCriteria>(StaticVariables.MainMDI);
            }
        }

        public virtual void m_changepassword_clicked(object sender, EventArgs e)
        {
            //Open(w_password_change);
            NZPostOffice.ODPS.Windows.Ruralbase.WPasswordChange w_password_change = new NZPostOffice.ODPS.Windows.Ruralbase.WPasswordChange();
            w_password_change.Show();
        }

        public override void m_about_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Open(w_system_about);
            NZPostOffice.ODPS.Windows.Odps.WAbout w_system_about = new NZPostOffice.ODPS.Windows.Odps.WAbout();
            w_system_about.ShowDialog();
        }

        protected virtual bool mf_check_window(string title)
        {
            foreach (Form frm in StaticVariables.MainMDI.MdiChildren)
            {
                if (frm.Text == title)
                {
                    frm.Activate();
                    return true;
                }
            }
            return false;
        }

        public override void m_print_clicked(object sender, EventArgs e)
        {
            Control actCtrl = StaticVariables.MainMDI.ActiveMdiChild.ActiveControl;
            if (actCtrl is URdsDw)
            {
                try
                {
                    CrystalReportViewer viewer = (CrystalReportViewer)((URdsDw)actCtrl).DataObject.GetControlByName("viewer");
                    {
                        if (viewer != null)
                        {
                            //? viewer.RefreshReport();
                            viewer.PrintReport();
                        }
                    }
                }
                catch
                { }
            }
        }

        public override void m_cut_clicked(object sender, EventArgs e)
        {
            Control actCtrl = StaticVariables.MainMDI.ActiveMdiChild.ActiveControl;
            if (actCtrl is URdsDw)
            {
                Control iCtrl = ((URdsDw)actCtrl).DataObject.ActiveControl;
                if (iCtrl.Text != "")
                {
                    if (iCtrl is TextBox)
                    {
                        Clipboard.SetText(((TextBox)iCtrl).SelectedText);
                        ((TextBox)iCtrl).SelectedText = "";
                    }
                    else if (iCtrl is RichTextBox)
                    {
                        Clipboard.SetText(((RichTextBox)iCtrl).SelectedText);
                        ((RichTextBox)iCtrl).SelectedText = "";
                    }
                    else
                    {
                        Clipboard.SetText(iCtrl.Text);
                        iCtrl.Text = "";
                    }
                }
            }
        }

        public override void m_copy_clicked(object sender, EventArgs e)
        {
            Control actCtrl = StaticVariables.MainMDI.ActiveMdiChild.ActiveControl;
            if (actCtrl is URdsDw)
            {
                Control iCtrl = ((URdsDw)actCtrl).DataObject.ActiveControl;
                if (iCtrl.Text != "")
                {
                    if (iCtrl is TextBox)
                    {
                        Clipboard.SetText(((TextBox)iCtrl).SelectedText);
                    }
                    else if (iCtrl is RichTextBox)
                    {
                        Clipboard.SetText(((RichTextBox)iCtrl).SelectedText);
                    }
                    else
                    {
                        Clipboard.SetText(iCtrl.Text);
                    }
                }
            }
        }

        public override void m_paste_clicked(object sender, EventArgs e)
        {
            Control actCtrl = StaticVariables.MainMDI.ActiveMdiChild.ActiveControl;
            if (actCtrl is URdsDw)
            {
                Control iCtrl = ((URdsDw)actCtrl).DataObject.ActiveControl;
                string str = Clipboard.GetText();
                if (iCtrl is TextBox)
                {
                    ((TextBox)iCtrl).SelectedText = "";
                    iCtrl.Text = ((TextBox)iCtrl).Text.Insert(((TextBox)iCtrl).SelectionStart, str);
                }
                else if (iCtrl is RichTextBox)
                {
                    ((RichTextBox)iCtrl).SelectedText = "";
                    iCtrl.Text = ((RichTextBox)iCtrl).Text.Insert(((RichTextBox)iCtrl).SelectionStart, str);
                }
                else
                {
                    iCtrl.Text = str;
                }
            }
        }

        public static T OpenSheetAll<T>(Form parent) where T : FormBase
        {
            if (!parent.IsMdiContainer)
                parent = parent.FindForm().MdiParent;

            T instance = Activator.CreateInstance<T>();
            //foreach (Form frm in parent.MdiChildren)
            //{
            //    if (instance.GetType() == frm.GetType())
            //    {
            //        frm.Activate();
            //        return instance;
            //    }
            //}
            instance.MdiParent = parent;
            instance.Show();
            return instance;
        }
        #endregion
    }
}
