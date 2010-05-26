using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.Windows.Ruralrpt;
using NZPostOffice.RDS.Windows.Ruralmailmerge;
using NZPostOffice.RDS.Windows.Ruralbase;
using NZPostOffice.RDS.Controls;
using CrystalDecisions.Windows.Forms;

namespace NZPostOffice.RDS.Menus
{

    public class MMainMenu : MFrame
    {
        #region Menu Define
        public ToolStripMenuItem m_printersetup;

        public ToolStripMenuItem m_printzoom;

        public ToolStripMenuItem m_insertrow;

        public ToolStripMenuItem m_deleterow;

        public ToolStripMenuItem m_updatedatabase;

        // public ToolStripMenuItem m_6;

        public ToolStripMenuItem m_toolbars1;

        public ToolStripMenuItem m_ruraldelivery;

        public ToolStripMenuItem m_contractors;

        public ToolStripMenuItem m_contracts;

        public ToolStripMenuItem m_addresses;

        // public ToolStripMenuItem m_-;

        public ToolStripMenuItem m_addarticalcounts;

        // public ToolStripMenuItem m_-1;

        public ToolStripMenuItem m_benchmarkcalculator;

        public ToolStripMenuItem m_extensions;

        public ToolStripMenuItem m_renewalprocess1;

        public ToolStripMenuItem m_setscalingfactors;

        // public ToolStripMenuItem m_-2;

        public ToolStripMenuItem m_contractadjustmentsimport;

        public ToolStripMenuItem m_piecerateimport;

        // TJB  ECL Data Import  Apr-2010: Added
        public ToolStripMenuItem m_ecldataimport;

        // public ToolStripMenuItem m_-4;

        public ToolStripMenuItem m_renewalrates;

        public ToolStripMenuItem m_posttaxdeduction;

        public ToolStripMenuItem m_nationalfueloverride;

        public ToolStripMenuItem m_privatebags;

        public ToolStripMenuItem m_reports;

        public ToolStripMenuItem m_contract1;

        public ToolStripMenuItem m_chedulea_ownerdriver;

        public ToolStripMenuItem m_scheduleb_payment;

        public ToolStripMenuItem m_contractsummarysheet;

        public ToolStripMenuItem m_routefrequencydescription;

        public ToolStripMenuItem m_scheduleofmailscarried;

        public ToolStripMenuItem m_vehicleschedule;

        public ToolStripMenuItem m_mailcountforms;

        public ToolStripMenuItem m_ehicleagereport;

        public ToolStripMenuItem m_allowancesummary;

        public ToolStripMenuItem m_contractorprocurements;

        public ToolStripMenuItem m_financialsstatistics;

        public ToolStripMenuItem m_rcmsstatisticalreport;

        // TJB  ECL Data Import  Apr-2010: Changed from m_ieceratesummary
        public ToolStripMenuItem m_pieceratesummary;

        public ToolStripMenuItem m_vehiclesummary;

        public ToolStripMenuItem m_performancesummary;

        public ToolStripMenuItem m_vehicleexpiry;

        public ToolStripMenuItem m_deedcompliance;

        public ToolStripMenuItem m_outstandingvalidationlist;

        public ToolStripMenuItem m_baseofficeoutlets;

        // public ToolStripMenuItem m_-5;

        public ToolStripMenuItem m_addresslabels;

        public ToolStripMenuItem m_wnerdriveraddress;

        public ToolStripMenuItem m_outletaddress;

        public ToolStripMenuItem m_customers1;

        public ToolStripMenuItem m_bydeliverydayofweek;

        public ToolStripMenuItem m_bydeliveryfrequency;

        public ToolStripMenuItem m_routebook;

        public ToolStripMenuItem m_nocommencementdates;

        public ToolStripMenuItem m_ustomercount;

        public ToolStripMenuItem m_stomercategorystatistics;

        public ToolStripMenuItem m_occupations;

        public ToolStripMenuItem m_interests;

        public ToolStripMenuItem m_unoccupieddeliverypoints;

        public ToolStripMenuItem m_bycontracttown;

        public ToolStripMenuItem m_customermailinglist;

        public ToolStripMenuItem m_unnumberedaddresses;

        public ToolStripMenuItem m_roadnames;

        public ToolStripMenuItem m_mailmerge;

        public ToolStripMenuItem m_mmcustomers;

        public ToolStripMenuItem m_mmownerdrivers;

        public ToolStripMenuItem m_security;

        public ToolStripMenuItem m_changepassword;

        #endregion

        #region Toolbar Define
        public ToolStripButton _m_contractors;

        public ToolStripButton _m_contracts;

        public ToolStripButton _m_addresses;

        public ToolStripButton _m_print;

        public ToolStripButton _m_insertrow;

        public ToolStripButton _m_deleterow;

        public ToolStripButton _m_updatedatabase;

        public ToolStripButton _m_renewalrates;

        #endregion

        public MMainMenu(Form form)
            : base(form)
        {
        }

        public override void BuildMenu(Form form)
        {
            base.BuildMenu(form);

            MenuStrip.Items.Remove(m_window);
            MenuStrip.Items.Remove(m_help);
            m_edit.Visible = false;
            m_view.Visible = false;
            m_insert.Visible = false;
            m_tools.Visible = false;

            #region m_file

            //
            //m_file
            //
            m_printersetup = new ToolStripMenuItem();
            m_printersetup.Text = "Printer Setup...";
            m_printersetup.Click += new EventHandler(m_printersetup_clicked);
            // m_printzoom = new ToolStripMenuItem();
            m_file.DropDownItems.Add(m_printersetup);
            // m_file.DropDownItems.Add(m_printzoom);

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
            m_file.DropDownItems.Remove(m_exit);
            m_file.DropDownItems.Add(m_exit);

            // 
            // m_close
            // 
            m_close.Text = "&Close";
            m_close.ShortcutKeys = Keys.Control | Keys.F4;
            m_close.ToolTipText = "Close the active window";
            m_close.Click += new EventHandler(m_close_clicked);

            // 
            // m_exit
            // 
            m_exit.Text = "E&xit";
            m_exit.ShortcutKeys = Keys.Alt | Keys.F4;
            m_exit.ToolTipText = "Exit the application";

            #endregion

            #region m_edit
            m_undo.Visible = false;
            m_dash21.Visible = false;
            m_cut.Visible = false;
            m_copy.Visible = false;
            m_paste.Visible = false;
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
            //
            //m_insertrow
            //
            m_insertrow = new ToolStripMenuItem();
            m_insertrow.Tag = "ComponentPrivilege=C;";
            m_insertrow.Text = "Insert Row";
            m_insertrow.ShortcutKeys = Keys.Control | Keys.I;
            m_insertrow.Click += new EventHandler(m_insertrow_clicked);
            m_edit.DropDownItems.Add(m_insertrow);


            //
            //m_deleterow
            //
            m_deleterow = new ToolStripMenuItem();
            m_deleterow.Tag = "ComponentPrivilege=D;";
            m_deleterow.Text = "Delete Row";
            m_deleterow.ShortcutKeys = Keys.Control | Keys.D;
            m_deleterow.Click += new EventHandler(m_deleterow_clicked);
            m_edit.DropDownItems.Add(m_deleterow);

            //
            //m_updatedatabase
            //
            m_updatedatabase = new ToolStripMenuItem();
            m_updatedatabase.Tag = "ComponentPrivilege=C;ComponentPrivilege=D;ComponentPrivilege=M;";
            m_updatedatabase.Text = "&Save Changes to Database";
            m_updatedatabase.ShortcutKeys = Keys.Control | Keys.S;
            m_updatedatabase.Click += new EventHandler(m_updatedatabase_clicked);
            m_edit.DropDownItems.Add(m_updatedatabase);


            #endregion

            #region m_ruraldelivery

            // 
            // m_ruraldelivery
            // 
            m_ruraldelivery = new ToolStripMenuItem();
            m_ruraldelivery.Visible = false;
            m_ruraldelivery.Enabled = false; //add 
            m_ruraldelivery.MergeAction = MergeAction.Replace;
            m_ruraldelivery.Text = "Rural &Delivery";
            m_ruraldelivery.Tag = "ComponentName=Owner Driver;ComponentName=Contracts;ComponentName=Add Article Count;ComponentName=Rates/What-if;ComponentName=Extensions;ComponentName=Renewal Process;ComponentName=Set Scaling Factors;";

            MenuStrip.Items.Add(m_ruraldelivery);


            m_contractors = new ToolStripMenuItem();
            m_contracts = new ToolStripMenuItem();
            m_addresses = new ToolStripMenuItem();
            m_addarticalcounts = new ToolStripMenuItem();
            m_benchmarkcalculator = new ToolStripMenuItem();
            m_extensions = new ToolStripMenuItem();
            m_renewalprocess1 = new ToolStripMenuItem();
            m_setscalingfactors = new ToolStripMenuItem();
            m_contractadjustmentsimport = new ToolStripMenuItem();
            m_piecerateimport = new ToolStripMenuItem();
            m_ecldataimport = new ToolStripMenuItem();        // TJB  ECL Data Import  Apr-2010: Added
            m_nationalfueloverride = new ToolStripMenuItem();
            m_privatebags = new ToolStripMenuItem();

            m_ruraldelivery.DropDownItems.Add(m_contractors);
            m_ruraldelivery.DropDownItems.Add(m_contracts);
            m_ruraldelivery.DropDownItems.Add(m_addresses);
            m_ruraldelivery.DropDownItems.Add(m_addarticalcounts);
            m_ruraldelivery.DropDownItems.Add(m_benchmarkcalculator);
            m_ruraldelivery.DropDownItems.Add(m_extensions);
            m_ruraldelivery.DropDownItems.Add(m_renewalprocess1);
            m_ruraldelivery.DropDownItems.Add(m_setscalingfactors);
            m_ruraldelivery.DropDownItems.Add(m_contractadjustmentsimport);
            m_ruraldelivery.DropDownItems.Add(m_piecerateimport);
            m_ruraldelivery.DropDownItems.Add(m_ecldataimport);        // TJB  ECL Data Import  Apr-2010: Added
            m_ruraldelivery.DropDownItems.Add(m_nationalfueloverride);
            m_ruraldelivery.DropDownItems.Add(m_privatebags);

            // 
            // m_contractors
            // 
            m_contractors.Text = "&Owner Driver";
            m_contractors.Visible = false;//add
            m_contractors.Enabled = false; //add

            m_contractors.ShortcutKeys = Keys.Control | Keys.Shift | Keys.O;
            m_contractors.ToolTipText = "Manage contractors";
            m_contractors.Tag = "ComponentName=Owner Driver;ComponentName=OD Contract Type;ComponentName=Contracts Held;ComponentName=DS Number;ComponentName=Procurements;";
            m_contractors.Click += new EventHandler(m_contractors_clicked);

            // 
            // m_contracts
            // 
            m_contracts.Text = "&Contracts";
            m_contracts.Visible = false;//add
            m_contracts.Enabled = false; //add

            m_contracts.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            m_contracts.ToolTipText = "Manage contracts";
            m_contracts.Tag = "ComponentName=Contract;ComponentName=Customer;ComponentName=Renewal;ComponentName=Frequency;ComponentName=Route Audit;ComponentName=Contract Type;ComponentName=Allowance;ComponentName=Article Count;ComponentName=Piece Rate;ComponentName=Fixed Asset;";
            m_contracts.Click += new EventHandler(m_contracts_clicked);

            // 
            // m_addresses
            // 
            m_addresses.Text = "&Addresses";
            m_addresses.Visible = false;//add
            m_addresses.Enabled = false; //add

            m_addresses.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            m_addresses.ToolTipText = "Manage addresses";
            m_addresses.Tag = "ComponentName=Address;ComponentName=Customer;";
            m_addresses.Click += new EventHandler(m_addresses_clicked);

            // 
            // m_addarticalcounts
            // 
            m_addarticalcounts.Text = "A&dd Article Counts";
            m_addarticalcounts.Visible = false;//add
            m_addarticalcounts.Enabled = false; //add

            m_addarticalcounts.ToolTipText = "Add article counts";
            m_addarticalcounts.Tag = "ComponentName=Add Article Count;";
            m_addarticalcounts.Click += new EventHandler(m_addarticalcounts_clicked);

            // 
            // m_benchmarkcalculator
            // 
            m_benchmarkcalculator.Text = "Rates / &What If";
            m_benchmarkcalculator.Visible = false;//add
            m_benchmarkcalculator.Enabled = false; //add

            m_benchmarkcalculator.ToolTipText = "Manage benchmark rates or run What-if calculator";
            m_benchmarkcalculator.Tag = "ComponentName=Rates/What-if;ComponentName=Show Rates;ComponentName=New Rates;ComponentName=Run What-If;	ComponentName=What-If Frequencies;";
            m_benchmarkcalculator.Click += new EventHandler(m_benchmarkcalculator_clicked);
            // 
            // m_extensions
            // 
            m_extensions.Text = "E&xtensions";
            m_extensions.Visible = false;//add
            m_extensions.Enabled = false; //add

            m_extensions.ToolTipText = "Add extensions";
            m_extensions.Tag = "ComponentName=Extensions;";
            m_extensions.Click += new EventHandler(m_extensions_clicked);

            // 
            // m_renewalprocess1
            // 
            m_renewalprocess1.Text = "Renewal Process";
            m_renewalprocess1.Visible = false;//add
            m_renewalprocess1.Enabled = false; //add

            m_renewalprocess1.ToolTipText = "Renew contracts";
            m_renewalprocess1.Tag = "ComponentName=Renewal Process;ComponentName=Update Payment Values;ComponentName=Benchmark;ComponentName=Benchmark Last;	ComponentName=Print Schedules;ComponentName=Create Pendings;";
            m_renewalprocess1.Click += new EventHandler(m_renewalprocess1_clicked);

            // 
            // m_setscalingfactors
            // 
            m_setscalingfactors.Text = "Set Scaling &Factors";
            m_setscalingfactors.Visible = false;//add
            m_setscalingfactors.Enabled = false; //add

            m_setscalingfactors.ToolTipText = "Set scaling factors";
            m_setscalingfactors.Tag = "ComponentName=Set Scaling Factors;";
            m_setscalingfactors.Click += new EventHandler(m_setscalingfactors_clicked);

            // 
            // m_contractadjustmentsimport
            // 
            m_contractadjustmentsimport.Text = "Contract Adjustments Import";
            m_contractadjustmentsimport.Click += new EventHandler(m_contractadjustmentsimport_clicked);

            // 
            // m_piecerateimport
            // 
            m_piecerateimport.Text = "Piece Rate &Import";
            m_piecerateimport.Visible = false;//add
            m_piecerateimport.Enabled = false; //add
            m_piecerateimport.ToolTipText = "Import piece rates from a file";
            m_piecerateimport.Tag = "ComponentName=Piece Rate Import;";
            m_piecerateimport.Click += new EventHandler(m_piecerateimport_clicked);

            // TJB  ECL Data Import  Apr-2010: Added
            // 
            // m_ecldataimport
            // 
            m_ecldataimport.Text = "ECL Data &Import";
            m_ecldataimport.Visible = false;//add
            m_ecldataimport.Enabled = false; //add
            m_ecldataimport.ToolTipText = "Import ECL data from a file";
            m_ecldataimport.Tag = "ComponentName=ECL Data Import;";
            m_ecldataimport.Click += new EventHandler(m_ecldataimport_clicked);

            // 
            // m_nationalfueloverride
            // 
            m_nationalfueloverride.Text = "&National Fuel Override";
            m_nationalfueloverride.Visible = false;//add
            m_nationalfueloverride.Enabled = false; //add

            m_nationalfueloverride.ToolTipText = "Manage national fuel override rates";
            m_nationalfueloverride.Tag = "ComponentName=National Fuel Overrides;";
            m_nationalfueloverride.Click += new EventHandler(m_nationalfueloverride_clicked);
           
            // 
            // m_privatebags
            // 
            m_privatebags.Text = "Private Bags";
            m_privatebags.ToolTipText = "Update private bag counts";
            m_privatebags.Tag = "Update private bag counts";
            m_privatebags.Click += new EventHandler(m_privatebags_clicked);

            #endregion

            #region m_reports
            // 
            // m_reports
            // 
            m_reports = new ToolStripMenuItem();
            m_reports.Visible = false;
            m_reports.Enabled = false;
            m_reports.MergeAction = MergeAction.Replace;

            m_reports.Text = "Reports";
            m_replace.Tag = "ComponentName=Schedule A;ComponentName=Schedule B;ComponentName=Contract Summary;ComponentName=Route Description;ComponentName=Schedule of Mails Carried;ComponentName=Vehicle Schedule;ComponentName=Mail Count Forms;ComponentName=Vehicle Age Analysis;Component";

            MenuStrip.Items.Add(m_reports);

            m_contract1 = new ToolStripMenuItem();
            m_financialsstatistics = new ToolStripMenuItem();
            m_baseofficeoutlets = new ToolStripMenuItem();
            m_addresslabels = new ToolStripMenuItem();
            m_customers1 = new ToolStripMenuItem();
            m_mailmerge = new ToolStripMenuItem();

            m_reports.DropDownItems.Add(m_contract1);
            m_reports.DropDownItems.Add(m_financialsstatistics);

            //customer needs
            //m_reports.DropDownItems.Add(m_baseofficeoutlets);
            //m_reports.DropDownItems.Add(m_addresslabels);
            m_reports.DropDownItems.Add(m_customers1);
            //m_reports.DropDownItems.Add(m_mailmerge);

            // 
            // m_contract1
            // 
            m_contract1.Text = "&Contracts";
            m_contract1.Visible = false; //add
            m_contract1.Enabled = false;  //add

            m_contract1.Tag = "ComponentName=Schedule A;ComponentName=Schedule B;ComponentName=Contract Summary;ComponentName=Route Description;ComponentName=Schedule of Mails Carried;ComponentName=Vehicle Schedule;ComponentName=Mail Count Forms;ComponentName=Vehicle Age Analysis;";

            m_chedulea_ownerdriver = new ToolStripMenuItem();
            m_scheduleb_payment = new ToolStripMenuItem();
            m_contractsummarysheet = new ToolStripMenuItem();
            m_routefrequencydescription = new ToolStripMenuItem();
            m_scheduleofmailscarried = new ToolStripMenuItem();
            m_vehicleschedule = new ToolStripMenuItem();
            m_mailcountforms = new ToolStripMenuItem();
            m_ehicleagereport = new ToolStripMenuItem();
            m_allowancesummary = new ToolStripMenuItem();
            m_contractorprocurements = new ToolStripMenuItem();

            m_contract1.DropDownItems.Add(m_chedulea_ownerdriver);
            m_contract1.DropDownItems.Add(m_scheduleb_payment);
            m_contract1.DropDownItems.Add(m_contractsummarysheet);
            m_contract1.DropDownItems.Add(m_routefrequencydescription);
            m_contract1.DropDownItems.Add(m_scheduleofmailscarried);
            m_contract1.DropDownItems.Add(m_vehicleschedule);
            m_contract1.DropDownItems.Add(m_mailcountforms);
            m_contract1.DropDownItems.Add(m_ehicleagereport);
            m_contract1.DropDownItems.Add(m_allowancesummary);
            m_contract1.DropDownItems.Add(m_contractorprocurements);

            // 
            // m_chedulea-ownerdriver
            // 
            m_chedulea_ownerdriver.Text = "Schedule A - Owner Driver";
            m_chedulea_ownerdriver.Visible = false; //add
            m_chedulea_ownerdriver.Enabled = false;  //add

            m_chedulea_ownerdriver.Tag = "ComponentName=Schedule A;";
            m_chedulea_ownerdriver.Click += new EventHandler(m_chedulea_ownerdriver_clicked);
            
            // 
            // m_scheduleb-payment
            // 
            m_scheduleb_payment.Text = "Schedule B - Payment";
            m_scheduleb_payment.Visible = false; //add
            m_scheduleb_payment.Enabled = false;  //add

            m_scheduleb_payment.Tag = "ComponentName=Schedule B;";
            m_scheduleb_payment.Click += new EventHandler(m_scheduleb_payment_clicked);

            // 
            // m_contractsummarysheet
            // 
            m_contractsummarysheet.Text = "Contract Summary Sheet";
            m_contractsummarysheet.Visible = false; //add
            m_contractsummarysheet.Enabled = false;  //add

            m_contractsummarysheet.Tag = "ComponentName=Contract Summary;";
            m_contractsummarysheet.Click += new EventHandler(m_contractsummarysheet_clicked);
            
            // 
            // m_routefrequencydescription
            // 
            m_routefrequencydescription.Text = "Route Frequency Description";
            m_routefrequencydescription.Visible = false; //add
            m_routefrequencydescription.Enabled = false;  //add

            m_routefrequencydescription.Tag = "ComponentName=Route Description;";
            m_routefrequencydescription.Click += new EventHandler(m_routefrequencydescription_clicked);
            
            // 
            // m_scheduleofmailscarried
            // 
            m_scheduleofmailscarried.Text = "Schedule of Mails Carried";
            m_scheduleofmailscarried.Visible = false; //add
            m_scheduleofmailscarried.Enabled = false;  //add

            m_scheduleofmailscarried.Tag = "ComponentName=Schedule of Mails Carried;";
            m_scheduleofmailscarried.Click += new EventHandler(m_scheduleofmailscarried_clicked);
          
            // 
            // m_vehicleschedule
            // 
            m_vehicleschedule.Text = "Vehicle Schedule";
            m_vehicleschedule.Visible = false; //add
            m_vehicleschedule.Enabled = false;  //add

            m_vehicleschedule.Tag = "ComponentName=Vehicle Schedule;";
            m_vehicleschedule.Click += new EventHandler(m_vehicleschedule_clicked);
            
            // 
            // m_mailcountforms
            // 
            m_mailcountforms.Text = "Mail Count &Forms";
            m_mailcountforms.Visible = false; //add
            m_mailcountforms.Enabled = false;  //add

            m_mailcountforms.Tag = "ComponentName=Mail Count Forms;";
            m_mailcountforms.Click += new EventHandler(m_mailcountforms_clicked);

            // 
            // m_ehicleagereport
            // 
            m_ehicleagereport.Text = "Vehicle A&ge Report";
            m_ehicleagereport.Visible = false; //add
            m_ehicleagereport.Enabled = false;  //add

            m_ehicleagereport.Tag = "ComponentName=Vehicle Age Analysis;";
            m_ehicleagereport.Click += new EventHandler(m_ehicleagereport_clicked);
           
            // 
            // m_allowancesummary
            // 
            m_allowancesummary.Text = "A&llowance Summary";
            m_allowancesummary.Visible = false; //add
            m_allowancesummary.Enabled = false;  //add

            m_allowancesummary.Tag = "ComponentName=Allowance Summary;";
            m_allowancesummary.Click += new EventHandler(m_allowancesummary_clicked);
           
            // 
            // m_contractorprocurements
            // 
            m_contractorprocurements.Text = "Contractor &Procurements";
            m_contractorprocurements.Visible = false; //add
            m_contractorprocurements.Enabled = false;  //add

            m_contractorprocurements.Tag = "ComponentName=Procurements;";
            m_contractorprocurements.Click += new EventHandler(m_contractorprocurements_clicked);
            
            // 
            // m_financialsstatistics
            // 
            m_financialsstatistics.Text = "Financials/Statistics";
            m_financialsstatistics.Visible = false; //add
            m_financialsstatistics.Enabled = false;  //add

            m_financialsstatistics.Tag = "ComponentName=RCMs Stats Report;ComponentName=Piece Rate Summary;ComponentName=Vehicle Summary;ComponentName=Performance Summary;";

            m_rcmsstatisticalreport = new ToolStripMenuItem();
            m_pieceratesummary = new ToolStripMenuItem();
            m_vehiclesummary = new ToolStripMenuItem();
            //? m_performancesummary = new ToolStripMenuItem();
            m_vehicleexpiry = new ToolStripMenuItem();
            m_deedcompliance = new ToolStripMenuItem();
            m_outstandingvalidationlist = new ToolStripMenuItem();

            m_financialsstatistics.DropDownItems.Add(m_rcmsstatisticalreport);
            m_financialsstatistics.DropDownItems.Add(m_pieceratesummary);
            m_financialsstatistics.DropDownItems.Add(m_vehiclesummary);
            //? m_financialsstatistics.DropDownItems.Add(m_performancesummary);
            m_financialsstatistics.DropDownItems.Add(m_vehicleexpiry);
            m_financialsstatistics.DropDownItems.Add(m_deedcompliance);
            m_financialsstatistics.DropDownItems.Add(m_outstandingvalidationlist);

            // 
            // m_rcmsstatisticalreport
            // 
            m_rcmsstatisticalreport.Text = "RCMs Statistical Report";
            m_rcmsstatisticalreport.Visible = false; //add
            m_rcmsstatisticalreport.Enabled = false;  //add

            m_rcmsstatisticalreport.Tag = "ComponentName=RCMs Stats Report;";
            m_rcmsstatisticalreport.Click += new EventHandler(m_rcmsstatisticalreport_clicked);
        
            // 
            // m_pieceratesummary
            // 
            m_pieceratesummary.Text = "P&iece Rate Summary";
            m_pieceratesummary.Visible = false; //add
            m_pieceratesummary.Enabled = false;  //add

            m_pieceratesummary.Tag = "ComponentName=Piece Rate Summary;";
            m_pieceratesummary.Click += new EventHandler(m_pieceratesummary_clicked);
            
            // 
            // m_vehiclesummary
            // 
            m_vehiclesummary.Text = "Vehicle Summary";
            m_vehiclesummary.Visible = false; //add
            m_vehiclesummary.Enabled = false;  //add

            m_vehiclesummary.Tag = "ComponentName=Vehicle Summary;";
            m_vehiclesummary.Click += new EventHandler(m_vehiclesummary_clicked);
           
            //// 
            //// m_performancesummary
            //// 
            //m_performancesummary.Visible = false;
            //m_performancesummary.Text = "&Performance Summary";
            //m_performancesummary.Tag="ComponentName=Disabled;";
            //m_performancesummary.Enabled = false;

            // 
            // m_vehicleexpiry
            // 
            m_vehicleexpiry.Text = "Vehicle E&xpiry ";
            m_vehicleexpiry.ToolTipText = "Report on Vehicle Expiry dates";
            m_vehicleexpiry.Tag = "Report on Vehicle Expiry dates;";
            m_vehicleexpiry.Click += new EventHandler(m_vehicleexpiry_clicked);

            // 
            // m_deedcompliance
            // 
            m_deedcompliance.Text = "&Deed Compliance";
            m_deedcompliance.ToolTipText = "Report on national and regional deed compliance";
            m_deedcompliance.Tag = "Report on national and regional deed compliance;";
            m_deedcompliance.Click += new EventHandler(m_deedcompliance_clicked);

            // 
            // m_outstandingvalidationlist
            // 
            m_outstandingvalidationlist.Text = "&Outstanding Validation List";
            m_outstandingvalidationlist.ToolTipText = "Report on Outstanding Contract validations";
            m_outstandingvalidationlist.Tag = "Report on Outstanding Contract validations;";
            m_outstandingvalidationlist.Click += new EventHandler(m_outstandingvalidationlist_clicked);

            // 
            // m_baseofficeoutlets
            // 
            m_baseofficeoutlets.Text = "Base Office Outlets";
            m_baseofficeoutlets.Visible = false; //add
            m_baseofficeoutlets.Enabled = false;  //add

            m_baseofficeoutlets.ToolTipText = "Base Office Outlets by Region";
            m_baseofficeoutlets.Tag = "Base Office Outlet Report;";
            m_baseofficeoutlets.Click += new EventHandler(m_baseofficeoutlets_clicked);

            // 
            // m_addresslabels
            // 
            m_addresslabels.Text = "Address Labels";
            m_addresslabels.Visible = false; //add
            m_addresslabels.Enabled = false;  //add

            m_addresslabels.Tag = "ComponentName=Owner Drivers Label;ComponentName=Outlet Label;";

            m_wnerdriveraddress = new ToolStripMenuItem();
            m_outletaddress = new ToolStripMenuItem();
            m_addresslabels.DropDownItems.Add(m_wnerdriveraddress);
            m_addresslabels.DropDownItems.Add(m_outletaddress);

            // 
            // m_wnerdriveraddress
            // 
            m_wnerdriveraddress.Text = "Owner Driver Address";
            m_wnerdriveraddress.Visible = false; //add
            m_wnerdriveraddress.Enabled = false;  //add

            m_wnerdriveraddress.ToolTipText = "Owner driver address labels";
            m_wnerdriveraddress.Tag = "ComponentName=Owner Drivers Label;";
            m_wnerdriveraddress.Click += new EventHandler(m_wnerdriveraddress_clicked);

            // 
            // m_outletaddress
            // 
            m_outletaddress.Text = "Outlet Address";
            m_outletaddress.Visible = false; //add
            m_outletaddress.Enabled = false;  //add

            m_outletaddress.ToolTipText = "Outlet address labels";
            m_outletaddress.Tag = "ComponentName=Outlet Label;";
            m_outletaddress.Click += new EventHandler(m_outletaddress_clicked);

            // 
            // m_customers1
            // 
            m_customers1.Text = "C&ustomers Listing";
            m_customers1.Visible = false; //add
            m_customers1.Enabled = false;  //add

            m_customers1.Tag = "ComponentName=CC Occupations;ComponentName=CC Interests;ComponentName=CL Customer Count;ComponentName=CL No Commencement Date;ComponentName=CL Route Book;ComponentName=CL By Frequency;ComponentName=CL By Day of Week;";

            m_bydeliverydayofweek = new ToolStripMenuItem();
            m_bydeliveryfrequency = new ToolStripMenuItem();
            m_routebook = new ToolStripMenuItem();

            //?m_nocommencementdates = new ToolStripMenuItem();
            m_ustomercount = new ToolStripMenuItem();
            m_stomercategorystatistics = new ToolStripMenuItem();
            m_unoccupieddeliverypoints = new ToolStripMenuItem();
            m_bycontracttown = new ToolStripMenuItem();
            m_customermailinglist = new ToolStripMenuItem();
            m_unnumberedaddresses = new ToolStripMenuItem();
            m_roadnames = new ToolStripMenuItem();

            //m_customers1.DropDownItems.Add(m_bydeliverydayofweek);
            m_customers1.DropDownItems.Add(m_bydeliveryfrequency);
            //m_customers1.DropDownItems.Add(m_routebook);
            //? m_customers1.DropDownItems.Add(m_nocommencementdates);
            //m_customers1.DropDownItems.Add(m_ustomercount);
            //m_customers1.DropDownItems.Add(m_stomercategorystatistics);
            //m_customers1.DropDownItems.Add(m_unoccupieddeliverypoints);
            //m_customers1.DropDownItems.Add(m_bycontracttown);
            m_customers1.DropDownItems.Add(m_customermailinglist);
            //m_customers1.DropDownItems.Add(m_unnumberedaddresses);
            //m_customers1.DropDownItems.Add(m_roadnames);

            
            // 
            // m_bydeliverydayofweek
            // 
            m_bydeliverydayofweek.Text = "by &Delivery Day of Week";
            m_bydeliverydayofweek.Visible = false; //add
            m_bydeliverydayofweek.Enabled = false;  //add

            m_bydeliverydayofweek.Tag = "ComponentName=CL By Day of Week;";
            m_bydeliverydayofweek.Click += new EventHandler(m_bydeliverydayofweek_clicked);

            // 
            // m_bydeliveryfrequency
            // 
            m_bydeliveryfrequency.Text = "by Delivery &Frequency";
            m_bydeliveryfrequency.Visible = false; //add
            m_bydeliveryfrequency.Enabled = false;  //add

            m_bydeliveryfrequency.Tag = "ComponentName=CL By Frequency;";
            m_bydeliveryfrequency.Click += new EventHandler(m_bydeliveryfrequency_clicked);

            // 
            // m_routebook
            // 
            m_routebook.Text = "Route Book";
            m_routebook.Visible = false; //add
            m_routebook.Enabled = false;  //add

            m_routebook.Tag = "ComponentName=CL Route Book;";
            m_routebook.Click += new EventHandler(m_routebook_clicked);

            //// 
            //// m_nocommencementdates
            //// 
            //m_nocommencementdates.Text = "&No Commencement Dates";
            //m_nocommencementdates.Tag="ComponentName=Disabled;";

            // 
            // m_ustomercount
            // 
            m_ustomercount.Text = "Kiwimail Count";
            m_ustomercount.Visible = false; //add
            m_ustomercount.Enabled = false;  //add

            m_ustomercount.Tag = "ComponentName=CL Customer Count;";
            m_ustomercount.Click += new EventHandler(m_ustomercount_clicked);

            // 
            // m_stomercategorystatistics
            // 
            m_stomercategorystatistics.Text = "Customer Category &Statistics";
            m_stomercategorystatistics.Visible = false; //add
            m_stomercategorystatistics.Enabled = false;  //add

            m_stomercategorystatistics.Tag = "ComponentName=CC Occupations;ComponentName=CC Interests;";

            m_occupations = new ToolStripMenuItem();
            m_interests = new ToolStripMenuItem();
            m_stomercategorystatistics.DropDownItems.Add(m_occupations);
            m_stomercategorystatistics.DropDownItems.Add(m_interests);

            // 
            // m_occupations
            // 
            m_occupations.Text = "Occupations";
            m_occupations.Visible = false; //add
            m_occupations.Enabled = false;  //add

            m_occupations.Tag = "ComponentName=CC Occupations;";
            m_occupations.Click += new EventHandler(m_occupations_clicked);

            // 
            // m_interests
            // 
            m_interests.Text = "Interests";
            m_interests.Visible = false; //add
            m_interests.Enabled = false;  //add

            m_interests.Tag = "ComponentName=CC Interests;";
            m_interests.Click += new EventHandler(m_interests_clicked);

            // 
            // m_unoccupieddeliverypoints
            // 
            m_unoccupieddeliverypoints.Text = "Unoccupied Delivery &Points";
            m_unoccupieddeliverypoints.Visible = false; //add
            m_unoccupieddeliverypoints.Enabled = false;  //add

            m_unoccupieddeliverypoints.ToolTipText = "Unoccupied delivery points report";
            m_unoccupieddeliverypoints.Tag = "Unoccupied delivery points report;";
            m_unoccupieddeliverypoints.Click += new EventHandler(m_unoccupieddeliverypoints_clicked);

            // 
            // m_bycontracttown
            // 
            m_bycontracttown.Text = "by Contract or Town";
            m_bycontracttown.Visible = false; //add
            m_bycontracttown.Enabled = false;  //add

            m_bycontracttown.ToolTipText = "Customers by Contract or Town";
            m_bycontracttown.Tag = "Customers by Contract or Town;";
            m_bycontracttown.Click += new EventHandler(m_bycontracttown_clicked);

            // 
            // m_customermailinglist
            // 
            m_customermailinglist.Text = "Customer Mailing List";
            //m_customermailinglist.Visible = false; //add
            //m_customermailinglist.Enabled = false;  //add

            m_customermailinglist.ToolTipText = "Customer Mailing List search";
            m_customermailinglist.Tag = "Customer Mailing List search;";
            m_customermailinglist.Click += new EventHandler(m_customermailinglist_clicked);

            // 
            // m_unnumberedaddresses
            // 
            m_unnumberedaddresses.Text = "Unnumbered &Addresses";
            m_unnumberedaddresses.Visible = false; //add
            m_unnumberedaddresses.Enabled = false;  //add

            m_unnumberedaddresses.ToolTipText = "Report on unnumbered addresses";
            m_unnumberedaddresses.Tag = "Report on unnumbered addresses;";
            m_unnumberedaddresses.Click += new EventHandler(m_unnumberedaddresses_clicked);

            // 
            // m_roadnames
            // 
            m_roadnames.Text = "Road &Names ";
            m_roadnames.Visible = false; //add
            m_roadnames.Enabled = false;  //add

            m_roadnames.ToolTipText = "Report to display road names.";
            m_roadnames.Tag = "Report to display road names.";
            m_roadnames.Click += new EventHandler(m_roadnames_clicked);

            // 
            // m_mailmerge
            // 
            m_mailmerge.Text = "Mail Merge";
            m_mailmerge.Visible = false; //add
            m_mailmerge.Enabled = false;  //add

            m_mailmerge.Tag = "ComponentName=MM Customers;ComponentName=MM Owner Drivers;";

            m_mmcustomers = new ToolStripMenuItem();
            m_mmownerdrivers = new ToolStripMenuItem();
            m_mailmerge.DropDownItems.Add(m_mmcustomers);
            m_mailmerge.DropDownItems.Add(m_mmownerdrivers);

            // 
            // m_mmcustomers
            // 

            //m_mmcustomers.Text = "Customers";
            m_mmcustomers.Text = "Customer Mail Merge"; //chanage of 16/11/2007
            m_mmcustomers.Visible = false; //add
            m_mmcustomers.Enabled = false;  //add

            m_mmcustomers.Tag = "ComponentName=MM Customers;";
            m_mmcustomers.Click += new EventHandler(m_mmcustomers_clicked);

            // 
            // m_mmownerdrivers
            // 
            m_mmownerdrivers.Text = "Owner Drivers";
            m_mmownerdrivers.Visible = false; //add
            m_mmownerdrivers.Enabled = false;  //add

            m_mmownerdrivers.Tag = "ComponentName=MM Owner Drivers;";
            m_mmownerdrivers.Click += new EventHandler(m_mmownerdrivers_clicked);


            //All three can appear under Reports, Customer Listing (the last one can be renamed on the menu as "Customer Mail Merge" rather than create a separate menu tree for one item).
            m_customers1.DropDownItems.Add(m_mmcustomers);

            #endregion

            #region m_security
            // 
            // m_security
            // 
            m_security = new ToolStripMenuItem();
            m_security.MergeAction = MergeAction.Replace;

            MenuStrip.Items.Add(m_security);

            m_security.Text = "Security";
            m_changepassword = new ToolStripMenuItem();
            m_security.DropDownItems.Add(m_changepassword);
            // 
            // m_changepassword
            // 
            m_changepassword.Text = "Change &Password";
            m_changepassword.ToolTipText = "Change password";
            m_changepassword.Click += new EventHandler(m_changepassword_clicked);

            #endregion

            #region m_window
           
          // 
            if (form.IsMdiContainer)
            {
                MenuStrip.Items.Add(m_window);
                MenuStrip.MdiWindowListItem = m_window;
                //?m_window.Visible = false;
            }
           
            #endregion

            #region m_help

            MenuStrip.Items.Add(m_help);

            #endregion

            #region ToolBar
            _m_contractors = new ToolStripButton("OwnrDrvr", null, null, "_m_contractors");
            _m_contractors.Visible = false;

            _m_contractors.MergeAction = MergeAction.MatchOnly ;
            _m_contractors.ToolTipText = "OwnrDrvr";
            _m_contractors.Image = global::NZPostOffice.Shared.Properties.Resources.OWNRDRVR;
            _m_contractors.ImageTransparentColor = System.Drawing.Color.White;

            _m_contractors.Click += new EventHandler(m_contractors_clicked);
            ToolStrip.Items.Add(_m_contractors);

            _m_contracts = new ToolStripButton("Contract", null, null, "_m_contracts");
            _m_contracts.Visible = false;

            _m_contracts.MergeAction = MergeAction.MatchOnly;
            _m_contracts.ToolTipText = "Contract";
            _m_contracts.Image = global::NZPostOffice.Shared.Properties.Resources.CONTRACT;
            _m_contracts.ImageTransparentColor = System.Drawing.Color.White;

            _m_contracts.Click += new EventHandler(m_contracts_clicked);
            ToolStrip.Items.Add(_m_contracts);

            _m_addresses = new ToolStripButton("Address", null, null, "_m_addresses");
            _m_addresses.Visible = false;

            _m_addresses.MergeAction = MergeAction.MatchOnly;
            _m_addresses.ToolTipText = "Address";
            _m_addresses.Image = global::NZPostOffice.Shared.Properties.Resources.ADDRESS;
            _m_addresses.ImageTransparentColor = System.Drawing.Color.White;

            _m_addresses.Click += new EventHandler(m_addresses_clicked);
            ToolStrip.Items.Add(_m_addresses);

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
            //
            //_m_print
            //
            _m_print = new ToolStripButton("Print", null, null, "_m_print");
            _m_print.Visible = false;
            _m_print.Image = global::NZPostOffice.Shared.Properties.Resources.PRINT;
            _m_print.ImageTransparentColor = System.Drawing.Color.White;
            _m_print.Click += new EventHandler(m_print_clicked);
            ToolStrip.Items.Add(_m_print);

            //
            //_m_insert
            //
            _m_insertrow = new ToolStripButton("Insert", null, null, "_m_insertrow");
            _m_insertrow.Visible = false;
            _m_insertrow.Image = global::NZPostOffice.Shared.Properties.Resources.Insert;
            _m_insertrow.ImageTransparentColor = System.Drawing.Color.White;

            //?_m_insertrow.MergeAction = MergeAction.Replace;
            _m_insertrow.ToolTipText = "Insert";
            _m_insertrow.Click += new EventHandler(m_insertrow_clicked);
            ToolStrip.Items.Add(_m_insertrow);

            //
            //_m_deleterow
            //
            _m_deleterow = new ToolStripButton("Delete", null, null, "_m_deleterow");
            _m_deleterow.Visible = false;
            _m_deleterow.Image = global::NZPostOffice.Shared.Properties.Resources.Delete;
            _m_deleterow.ImageTransparentColor = System.Drawing.Color.White;

            //?_m_deleterow.MergeAction = MergeAction.Replace;
            _m_deleterow.ToolTipText = "Delete";
            _m_deleterow.Click += new EventHandler(m_deleterow_clicked);
            ToolStrip.Items.Add(_m_deleterow);

            //
            //_m_updatedatabase
            //
            _m_updatedatabase = new ToolStripButton("Save", null, null, "_m_updatedatabase");
            _m_updatedatabase.Visible = false;
            _m_updatedatabase.Image = global::NZPostOffice.Shared.Properties.Resources.SaveAll;
            _m_updatedatabase.ImageTransparentColor = System.Drawing.Color.White;

            //?_m_updatedatabase.MergeAction = MergeAction.Replace;
            _m_updatedatabase.ToolTipText = "Save";
            _m_updatedatabase.Click += new EventHandler(m_updatedatabase_clicked);
            ToolStrip.Items.Add(_m_updatedatabase);

            _m_renewalrates = new ToolStripButton("Override$", null, null, "_m_renewalrates");

            _m_renewalrates.ToolTipText = "Override$";
            _m_renewalrates.Visible = false;
            _m_renewalrates.Image = global::NZPostOffice.Shared.Properties.Resources.FormatDollar_;
            _m_renewalrates.ImageTransparentColor = System.Drawing.Color.White;
            _m_renewalrates.Click += new EventHandler(m_renewalrates_clicked);
            ToolStrip.Items.Add(_m_renewalrates);
            #endregion
        }

        #region Comment
        //public virtual int of_openwindow(string as_title, string as_classname)
        //{
        //    this.of_openwindow(as_title, as_classname, "");
        //    return 1;
        //}

        //public virtual int of_openwindow(string as_title, string as_classname, string as_datawindow)
        //{
        //    Form lw_Window;
        //    Form lw_SearchWindow;
        //    string ls_Wdw;
        //    bool lb_Found;
        //    as_title = StaticFunctions.f_translate(as_title, "&", "");
        //     StaticVariables.gnv_app.of_get_parameters().stringparm = as_datawindow;
        //    // Find the window
        //     lw_SearchWindow = StaticVariables.gnv_app.of_findwindow(as_title, as_classname);
        //    // none found
        //    if (lw_SearchWindow ==null )
        //    {
        //        //?OpenSheetWithParm(lw_window, as_title, as_classname, StaticVariables.gnv_app.of_getframe(), 0, original!);

        //        return 1;
        //    }
        //    else if (as_datawindow.Length == 0)
        //    {
        //        return 1;
        //    }
        //    // found - so check the dws
        //    while (lw_SearchWindow != null)
        //    {
        //        if (as_datawindow.Length > 0)
        //        {
        //            // check the dw name
        //            ls_Wdw = ((WAncestorWindow)lw_SearchWindow).ue_get_dw();
        //            // found - it's already on top
        //            if (as_datawindow == ls_Wdw)
        //            {
        //                return 1;
        //            }
        //            // Not found, get next window
        //            //? lw_searchwindow = StaticVariables.gnv_app.of_findwindow(as_title, as_classname, lw_searchwindow);
        //            // not same dw - open it
        //            if ( lw_SearchWindow == null )
        //            {
        //                //?OpenSheetWithParm(lw_window, as_title, as_classname, StaticVariables.gnv_app.of_getframe(), 0, original!);
        //                return 1;
        //            }
        //        }
        //    }
        //    // None found - open something

        //    //?OpenSheetWithParm(lw_window, as_title, as_classname, StaticVariables.gnv_app.of_getframe(), 0, original!);

        //    return 1;
        //}

        #endregion

        #region Methods
        public virtual int of_set_insertrow()
        {
            // Messagebox ( 'menu','yo create!')

            m_edit.Enabled = true;
            m_edit.Visible = true;
            m_insertrow.Enabled = true;
            m_insertrow.Visible = true;
            _m_insertrow.Visible = true;//this.m_insertrow.ToolbaritemVisible = true;
            return 1;
        }

        public virtual int of_set_deleterow()
        {
            // Messagebox ( 'menu','yo delete!')
            this.m_edit.Enabled = true;
            this.m_edit.Visible = true;
            this.m_deleterow.Enabled = true;
            this.m_deleterow.Visible = true;
            _m_deleterow.Visible = true;//this.m_deleterow.ToolbaritemVisible = true;
            return 1;
        }

        public virtual int of_set_update()
        {
            // Messagebox ( 'menu','yo update!')
            this.m_edit.Enabled = true;
            this.m_edit.Visible = true;
            this.m_updatedatabase.Enabled = true;
            this.m_updatedatabase.Visible = true;
            _m_updatedatabase.Visible = true;//this.m_updatedatabase.ToolbaritemVisible = true;
            return 1;
        }

        public virtual int of_set_editoff()
        {
            // Messagebox ( 'Oi!','Off!')
            this.m_edit.Enabled = false;
            this.m_edit.Visible = false;
            this.m_deleterow.Enabled = false;
            this.m_deleterow.Visible = false;
            _m_deleterow.Visible = false;//this.m_deleterow.ToolbaritemVisible = false;
            this.m_insertrow.Enabled = false;
            this.m_insertrow.Visible = false;
            _m_insertrow.Visible = false; //this.m_insertrow.ToolbaritemVisible = false;
            this.m_updatedatabase.Enabled = false;
            this.m_updatedatabase.Visible = false;
            _m_updatedatabase.Visible = false;//this.m_updatedatabase.ToolbaritemVisible = false;

            return 1;
        }

        #endregion

        #region Event

        public virtual void m_printersetup_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //PrintSetup();
            PrintDialog printDlg = new PrintDialog();
            printDlg.ShowDialog();
        }

        public virtual void m_printzoom_clicked(object sender, EventArgs e)
        {
            //?of_sendmessage("ue_printzoom");
        }

        public virtual void m_insertrow_clicked(object sender, EventArgs e)
        {
            //?of_sendmessage("Pfc_insertrow");
            ((URdsDw)StaticVariables.URdsDwName).PfcInsertRow();
        }

        public virtual void m_deleterow_clicked(object sender, EventArgs e)
        {
            //?of_sendmessage("pfc_deleterow");
            ((URdsDw)StaticVariables.URdsDwName).PfcDeleteRow();
        }

        public virtual void m_updatedatabase_clicked(object sender, EventArgs e)
        {
            //?of_sendmessage("pfc_save");
            ((URdsDw)StaticVariables.URdsDwName).Save();
        }

        public virtual void m_toolbars1_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //?Open(w_toolbars);
        }

        public override void m_about_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Open(w_system_about);
            WSystemAbout w_system_about = new WSystemAbout();
            w_system_about.ShowDialog();
        }

        public virtual void m_contractors_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_contractor_search, w_main_mdi, 0, original!);
            OpenSheet<WContractorSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_contracts_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_contract_search, w_main_mdi, 0, original!);
            OpenSheet<WContractSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_addresses_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_address_search, w_main_mdi, 0, original!);
            OpenSheet<WAddressSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_addarticalcounts_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_add_article_counts, w_main_mdi, 0, original!);
            OpenSheet<WAddArticleCounts>(StaticVariables.MainMDI);
        }

        public virtual void m_benchmarkcalculator_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_benchmark_rates2001, w_main_mdi, 0, original!);
            OpenSheet<WBenchmarkRates2001>(StaticVariables.MainMDI);
        }

        public virtual void m_extensions_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenSheet<WExtentions2001>(StaticVariables.MainMDI);
        }

        public virtual void m_renewalprocess1_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_renewal_process2001, w_main_mdi, 0, original!);
            //opensheet(w_Renewal_Process2006, w_main_mdi, 0, originaL!)
            OpenSheet<WRenewalProcess2006>(StaticVariables.MainMDI);
        }

        public virtual void m_setscalingfactors_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_set_scaling_factors, w_main_mdi, 0, original!);
            OpenSheet<WSetScalingFactors>(StaticVariables.MainMDI);
        }

        public virtual void m_contractadjustmentsimport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenSheet<WContractAdjustmentsImport>(StaticVariables.MainMDI);
        }

        public virtual void m_piecerateimport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenSheet<WPieceRateImport>(StaticVariables.MainMDI);//OpenSheet(w_piece_rate_import, w_main_mdi, 0, original!);
        }

        // TJB  ECL Data Import  Apr-2010: Added
        public virtual void m_ecldataimport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenSheet<WEclDataImport>(StaticVariables.MainMDI);
        }

        public virtual void m_renewalrates_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //?of_sendmessage("ue_open_rates");
            ((WRenewal2001)this._form).ue_open_rates();
        }

        public virtual void m_posttaxdeduction_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //?of_sendmessage("ue_posttax");
        }

        public virtual void m_nationalfueloverride_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //OpenSheet(w_national_fuel_override, w_main_mdi, 0, original!);
            OpenSheet<WNationalFuelOverride>(StaticVariables.MainMDI);
        }

        public virtual void m_privatebags_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //  check if the user has read access to this window first
            if (StaticVariables.gnv_app.of_get_securitymanager().of_getreadprivilege(StaticVariables.gnv_app.of_getuserid(), "Private Bags"))
            {
                //OpenSheetWithParm(w_pvt_bags_update, 0, w_main_mdi, 0, original!);
                StaticMessage.IntegerParm = 0;
                OpenSheet<WPvtBagsUpdate>(StaticVariables.MainMDI);
            }
            else
            {
                MessageBox.Show("You do not have access to this window. Please contact your system administrator f" + "or access.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public virtual void m_chedulea_ownerdriver_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_chedulea_ownerdriver.Tag.ToString()));
            //of_openwindow(m_chedulea - ownerdriver.Text, "w_Generic_Report_Search", "r_schedulea_single_contract");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_schedulea_single_contract";
            StaticMessage.StringParm = m_chedulea_ownerdriver.Text;
            OpenSheet<WGenericReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_scheduleb_payment_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_scheduleb_payment.Tag.ToString()));
            //of_openwindow(m_scheduleb - payment.Text, "w_Generic_Report_Search", "r_scheduleb_single_contract");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_scheduleb_single_contract";
            StaticMessage.StringParm = m_scheduleb_payment.Text;
            OpenSheet<WGenericReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_contractsummarysheet_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_contractsummarysheet.Tag.ToString()));
            //?of_openwindow(m_contractsummarysheet.Text, "w_Generic_Report_Search_With_Date", "r_contract_summary");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_contract_summary";
            StaticMessage.StringParm = m_contractsummarysheet.Text;
            OpenSheet<WGenericReportSearchWithDate>(StaticVariables.MainMDI);
        }

        public virtual void m_routefrequencydescription_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_routefrequencydescription.Tag.ToString()));
            //?of_openwindow(m_routefrequencydescription.Text, "w_route_frequency_report_search", "r_route_description_single_contract");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_route_description_single_contract";
            StaticMessage.StringParm = m_routefrequencydescription.Text;
            OpenSheet<WRouteFrequencyReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_scheduleofmailscarried_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_scheduleofmailscarried.Tag.ToString()));
            //?of_openwindow(m_scheduleofmailscarried.Text, "w_route_frequency_report_search", "r_mail_carried_single_contract");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_mail_carried_single_contract";
            StaticMessage.StringParm = m_scheduleofmailscarried.Text;
            OpenSheet<WRouteFrequencyReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_vehicleschedule_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_vehicleschedule.Tag.ToString()));
            //?of_openwindow(m_vehicleschedule.Text, "w_Generic_Report_Search", "r_vehicle_schedule_single_contractv2");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_vehicle_schedule_single_contractv2";
            StaticMessage.StringParm = m_vehicleschedule.Text;
            OpenSheet<WGenericReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_mailcountforms_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_mailcountforms.Tag.ToString()));
            //?of_openwindow(m_mailcountforms.Text, "w_mail_count_Search", "r_mail_count_form");
            WMailCountSearch w_mail_count_Search = new WMailCountSearch();
            w_mail_count_Search.MdiParent = StaticVariables.MainMDI;
            w_mail_count_Search.Show();
            w_mail_count_Search.Text = m_mailcountforms.Text;
            StaticMessage.StringParm = "Mail Count Forms";//m_mailcountforms.Text;
        }

        public virtual void m_ehicleagereport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_ehicleagereport.Tag.ToString()));
            StaticMessage.StringParm = "";
            //OpenSheet(w_vehicle_report_search, w_main_mdi, 0, original!);
            OpenSheet<WVehicleReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_allowancesummary_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_allowancesummary.Tag.ToString()));
            //OpenSheet(w_allowance_search, w_main_mdi, 0, original!);
            StaticMessage.StringParm = "";
            OpenSheet<WAllowanceSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_contractorprocurements_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_contractorprocurements.Tag.ToString()));
            //OpenSheet(w_procurement_select, w_main_mdi, 0, original!);
            OpenSheet<WProcurementSelect>(StaticVariables.MainMDI);
        }

        public virtual void m_rcmsstatisticalreport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_rcmsstatisticalreport.Tag.ToString()));
            //?of_openwindow(m_rcmsstatisticalreport.Text, "w_Report_rcm_Search", "r_rcm_stat_nested_report");
            WReportRcmSearch w_Report_rcm_Search = new WReportRcmSearch();
            w_Report_rcm_Search.MdiParent = StaticVariables.MainMDI;
            w_Report_rcm_Search.Show();
            w_Report_rcm_Search.Text = m_rcmsstatisticalreport.Text;
            StaticMessage.StringParm = "RCMs Statistical Report";
        }

        public virtual void m_pieceratesummary_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_pieceratesummary.Tag.ToString()));
            //OpenSheet(w_piece_rate_search, w_main_mdi, 0, original!);
            StaticMessage.StringParm = "";
            OpenSheet<WPieceRateSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_vehiclesummary_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_vehiclesummary.Tag.ToString()));
            //?of_openwindow(m_vehiclesummary.Text, "w_generic_report_reg_outlet_search", "r_vehicle_perf")
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_vehicle_perf";
            StaticMessage.StringParm = m_vehiclesummary.Text;
            OpenSheet<WGenericReportRegOutletSearch>(StaticVariables.MainMDI);

        }

        public virtual void m_performancesummary_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_performancesummary.Tag.ToString()));
            //?of_openwindow(m_performancesummary.Text, "w_ps_search", "r_performance_summary");
        }

        public virtual void m_vehicleexpiry_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen("Vehicle Expiry");
            //OpenSheet(w_v_expiry_search, w_main_mdi, 0, original!);
            StaticMessage.StringParm = "";
            OpenSheet<WVExpirySearch>(StaticVariables.MainMDI);
        }

        public virtual void m_deedcompliance_clicked(object sender, EventArgs e)
        {
            int ll_pvt_result;
            int ll_response;
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_deedcompliance.Tag.ToString()));
            //OpenSheet(w_deed_comp, w_main_mdi, 0, original!);
            OpenSheet<WDeedComp>(StaticVariables.MainMDI);
        }

        public virtual void m_outstandingvalidationlist_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen("Outstanding Validation List");
            //OpenSheet(w_out_val_report, w_main_mdi, 0, original!);
            OpenSheet<WOutValReport>(StaticVariables.MainMDI);
        }

        public virtual void m_baseofficeoutlets_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_baseofficeoutlets.Tag.ToString()));
            //OpenSheet(w_outlet_report_search, w_main_mdi, 0, original!);
            OpenSheet<WOutletReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_wnerdriveraddress_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_wnerdriveraddress.Tag.ToString()));
            //?of_openwindow(m_wnerdriveraddress.Text, "w_owner_driver_labels_criteria", "");
            StaticMessage.StringParm = StaticFunctions.f_translate(m_wnerdriveraddress.Text, "&", "");
            WOwnerDriverLabelsCriteria w_owner_driver_labels_criteria = new WOwnerDriverLabelsCriteria();
            w_owner_driver_labels_criteria.MdiParent = StaticVariables.MainMDI;
            w_owner_driver_labels_criteria.Show();
            w_owner_driver_labels_criteria.Text = m_wnerdriveraddress.Text;
        }

        public virtual void m_outletaddress_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_outletaddress.Tag.ToString()));
            //?of_openwindow(m_outletaddress.Text, "w_generic_report_region_search", "r_outlet_label");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_outlet_label";
            StaticMessage.StringParm = m_outletaddress.Text;
            OpenSheet<WGenericReportRegionSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_bydeliverydayofweek_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_bydeliverydayofweek.Tag.ToString()));
            StaticMessage.StringParm = "";
            //OpenSheet(w_customer_counter_del_days, w_main_mdi, 0, original!);
            OpenSheet<WCustomerCounterDelDays>(StaticVariables.MainMDI);
        }

        public virtual void m_bydeliveryfrequency_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_bydeliveryfrequency.Tag.ToString()));
            StaticMessage.StringParm = "";
            //OpenSheet(w_customer_counter_del_freq, w_main_mdi, 0, original!);
            OpenSheet<WCustomerCounterDelFreq>(StaticVariables.MainMDI);
        }

        public virtual void m_routebook_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_routebook.Tag.ToString()));
            StaticMessage.StringParm = "";
            //OpenSheet(w_customer_del_sequence, w_main_mdi, 0, original!);
            OpenSheet<WCustomerDelSequence>(StaticVariables.MainMDI);
        }

        public virtual void m_nocommencementdates_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_nocommencementdates.Tag.ToString()));
            //OpenSheet(w_no_commencement_search, w_main_mdi, 0, original!);
            OpenSheet<WNoCommencementSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_ustomercount_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_ustomercount.Tag.ToString()));
            //OpenSheet(w_customer_count_report_search, w_main_mdi, 0, original!);
            OpenSheet<WCustomerCountReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_occupations_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = "d_occupationlist";
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_occupations.Tag.ToString()));
            //?of_openwindow(m_occupations.Text, "w_customer_statistics_Report_Search", "d_cust_occupation_stat");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "d_cust_occupation_stat";
            StaticMessage.StringParm = m_occupations.Text;
            OpenSheet<WCustomerStatisticsReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_interests_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = "d_interestlist";
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_interests.Tag.ToString()));
            StaticVariables.gnv_app.of_get_parameters().stringparm = "d_cust_interest_stat";
            StaticMessage.StringParm = m_interests.Text;
            //?of_openwindow(m_interests.Text, "w_customer_statistics_Report_Search", "d_cust_interest_stat");
            OpenSheet<WCustomerStatisticsReportSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_unoccupieddeliverypoints_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen("Unoccupied");
            //of_openwindow(m_unoccupieddeliverypoints.Text, "w_unoccupied_Search", "r_ps_unoccupied_rpt");
            StaticVariables.gnv_app.of_get_parameters().stringparm = "r_ps_unoccupied_rpt";
            StaticMessage.StringParm = m_unoccupieddeliverypoints.Text;
            OpenSheet<WUnoccupiedSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_bycontracttown_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen("Customer Listing");
            //OpenSheet(w_cust_list_search, w_main_mdi, 0, original!);
            StaticMessage.StringParm = "";
            OpenSheet<WCustListSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_customermailinglist_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen("Customer Mailing Listing");
            //OpenSheet(w_mailing_list_search, w_main_mdi, 0, original!);
            OpenSheet<WMailingListSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_unnumberedaddresses_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen("Unnumbered Roads");
            //OpenSheet(w_no_roadnum_search, w_main_mdi, 0, original!);
            OpenSheet<WNoRoadnumSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_roadnames_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen("Road Names");
            //OpenSheet(w_roadname_search, w_main_mdi, 0, original!);
            OpenSheet<WRoadnameSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_mmcustomers_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_mmcustomers.Tag.ToString()));
            //OpenSheet(w_mailmerge_customer_download_search, w_main_mdi, 0, original!);
            OpenSheet<WMailmergeCustomerDownloadSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_mmownerdrivers_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            StaticVariables.gnv_app.of_set_componenttoopen(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentname(m_mmownerdrivers.Tag.ToString()));
            //OpenSheet(w_mailmerge_ownerdriver_download_search, w_main_mdi, 0, original!);
            StaticMessage.StringParm = "";
            OpenSheet<WMailmergeOwnerdriverDownloadSearch>(StaticVariables.MainMDI);
        }

        public virtual void m_changepassword_clicked(object sender, EventArgs e)
        {
            //Open(w_password_change);
            NZPostOffice.RDS.Windows.Ruralbase.WPasswordChange w_password_change = new NZPostOffice.RDS.Windows.Ruralbase.WPasswordChange();
            w_password_change.ShowDialog();
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
            
        
        #endregion
    }
}
