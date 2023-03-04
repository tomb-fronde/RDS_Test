using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Menus
{
    public class MOdpsMaster : MFrame
    {
        // Required designer variable.
        //private System.ComponentModel.IContainer components = null;
        
        //Reference to the menu functions
        //private m_odps_master m_odps_master;
        
        /*
        public ToolStripMenuItem m_file;
        public ToolStripMenuItem m_new;
        public ToolStripMenuItem m_open;
        public ToolStripMenuItem m_close;
        public ToolStripSeparator m_dash11;
        public ToolStripMenuItem m_save;
        public ToolStripMenuItem m_saveas;
        public ToolStripSeparator m_dash12;
        public ToolStripMenuItem m_print;
        public ToolStripMenuItem m_printpreview;
        public ToolStripMenuItem m_pagesetup;
        */
        public ToolStripMenuItem m_printersetup;
        /*
        public ToolStripSeparator m_dash13;
        public ToolStripMenuItem m_properties;
        public ToolStripSeparator m_dash14;
        public ToolStripMenuItem m_exit;
        */


        /*
        public ToolStripMenuItem m_edit;
        public ToolStripMenuItem m_undo;
        public ToolStripSeparator m_dash21;
        public ToolStripMenuItem m_cut;
        public ToolStripMenuItem m_copy;
        public ToolStripMenuItem m_paste;
        public ToolStripSeparator m_dash22;
        public ToolStripMenuItem m_find;
        public ToolStripMenuItem m_replace;
        */


        /*
        public ToolStripMenuItem m_view;
        public ToolStripMenuItem m_ruler;
        public ToolStripSeparator m_dash31;
        */
        public ToolStripMenuItem m_firstpage;
        /*
        public ToolStripMenuItem m_nextpage;
        public ToolStripMenuItem m_priorpage;
        public ToolStripMenuItem m_lastpage;
        public ToolStripSeparator m_dash32;
        */
        public ToolStripMenuItem m_nextgroup;
        public ToolStripMenuItem m_priorgroup;
        public new ToolStripSeparator m_dash33;
        /*
        public ToolStripMenuItem m_sort;
        public ToolStripMenuItem m_filter;
        public ToolStripSeparator m_dash34;
        */
        public ToolStripMenuItem m_notes;
        /*
        public ToolStripMenuItem m_zoom;
        */


        public ToolStripMenuItem m_record;
        public ToolStripMenuItem m_addrow;
        public ToolStripMenuItem m_insertrow;
        public new ToolStripSeparator m_dash41;
        public ToolStripMenuItem m_deleterow;


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
        public ToolStripMenuItem m_updatedcontractorsexport;
        public ToolStripMenuItem m_1;
        public ToolStripMenuItem m_shellimport;
        public ToolStripMenuItem m_ruraldelivery;
        public ToolStripMenuItem m_contracts;
        public ToolStripMenuItem m_ownerdrivers;
        public ToolStripMenuItem m_piecerates;


        public ToolStripMenuItem m_reports;


        public ToolStripMenuItem m_security;


        /*
        public ToolStripMenuItem m_window;
        public ToolStripMenuItem m_cascade;
        public ToolStripMenuItem m_tilehorizontal;
        public ToolStripMenuItem m_tilevertical;
        public ToolStripMenuItem m_layer;
        */
        public ToolStripSeparator m_dash91;
        public ToolStripMenuItem m_customizetoolbars;


        /*
        public ToolStripMenuItem m_help;
        public ToolStripMenuItem m_helptopics;
        */
        public ToolStripMenuItem m_index;
        public ToolStripMenuItem m_currentitem;
        /*
        public ToolStripSeparator m_dash61;
        public ToolStripMenuItem m_about;
        */


        //private Form current_form;


        public ToolStripButton m_printersetup_t;
        public ToolStripSeparator m_1_t;
        public ToolStripButton m_paymentrun_t;
        public ToolStripButton m_invoicemailinginterface_t;
        public ToolStripSeparator m_2_t;

        public MOdpsMaster()
        {
        }

        public MOdpsMaster(Form form) : base(form)
        {
        }

        public override void BuildMenu(Form form)
        {
            base.BuildMenu(form);

            //m_file = new ToolStripMenuItem();
            //m_edit = new ToolStripMenuItem();
            //m_view = new ToolStripMenuItem();
            m_record = new ToolStripMenuItem();
            m_odps = new ToolStripMenuItem();
            m_ruraldelivery = new ToolStripMenuItem();
            m_reports = new ToolStripMenuItem();
            m_security = new ToolStripMenuItem();
            //m_window = new ToolStripMenuItem();
            //m_help = new ToolStripMenuItem();

            //MenuStrip.Items.Add(m_file);
            //MenuStrip.Items.Add(m_edit);
            if(!MenuStrip.Items.Contains(m_view))
                MenuStrip.Items.Insert(2,m_view);
            MenuStrip.Items.Insert(3,m_record);
            MenuStrip.Items.Insert(4,m_odps);
            MenuStrip.Items.Insert(5,m_ruraldelivery);
            MenuStrip.Items.Insert(6,m_reports);
            MenuStrip.Items.Insert(7,m_security);
            //MenuStrip.Items.Add(m_window);
            //MenuStrip.Items.Add(m_help);
            // 
            // m_file
            // 
            //m_file.Text = "&File";
            //m_new = new ToolStripMenuItem();
            //m_open = new ToolStripMenuItem();
            //m_close = new ToolStripMenuItem();
            //m_dash11 = new ToolStripSeparator();
            //m_save = new ToolStripMenuItem();
            //m_saveas = new ToolStripMenuItem();
            //m_dash12 = new ToolStripSeparator();
            //m_print = new ToolStripMenuItem();
            //m_printpreview = new ToolStripMenuItem();
            //m_pagesetup = new ToolStripMenuItem();
            m_printersetup = new ToolStripMenuItem();
            //m_dash13 = new ToolStripSeparator();
            //m_properties = new ToolStripMenuItem();
            //m_dash14 = new ToolStripSeparator();
            //m_exit = new ToolStripMenuItem();
            //m_file.DropDownItems.Add(m_new);
            //m_file.DropDownItems.Add(m_open);
            //m_file.DropDownItems.Add(m_close);
            //m_file.DropDownItems.Add(m_dash11);
            //m_file.DropDownItems.Add(m_save);
            //m_file.DropDownItems.Add(m_saveas);
            //m_file.DropDownItems.Add(m_dash12);
            //m_file.DropDownItems.Add(m_print);
            //m_file.DropDownItems.Add(m_printpreview);
            //m_file.DropDownItems.Add(m_pagesetup);
            m_file.DropDownItems.Insert(10,m_printersetup);
            //m_file.DropDownItems.Add(m_dash13);
            //m_file.DropDownItems.Add(m_properties);
            //m_file.DropDownItems.Add(m_dash14);
            //m_file.DropDownItems.Add(m_exit);
            // 
            // m_new
            // 
            //m_new.Text = "&New~tCtrl+N";
            m_new.Text = "&New";
            m_new.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            // Metex Migrator Warning: property shortcut 334 was not converted
            m_new.ToolTipText = "New";
            // 
            // m_open
            // 
            //m_open.Text = "&Open...~tCtrl+O";
            m_open.Text = "&Open";
            m_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            // Metex Migrator Warning: property shortcut 335 was not converted
            m_open.ToolTipText = "Open";
            // 
            // m_close
            // 
            m_close.Text = "&Close";
            m_close.ToolTipText = "Close";
            // Metex Migrator Warning: property toolbaritemorder 9999 was not converted
            // 
            // m_dash11
            // 
            //m_dash11.Text = "-";
            // 
            // m_save
            // 
            //m_save.Text = "&Save~tCtrl+S";
            m_save.Text = "&Save";
            m_save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            // Metex Migrator Warning: property shortcut 339 was not converted
            m_save.ToolTipText = "Save";
            // 
            // m_saveas
            // 
            m_saveas.Text = "Save &As...";
            m_saveas.ToolTipText = "Save As";
            m_saveas.Visible = false;
            // 
            // m_dash12
            // 
            //m_dash12.Text = "-";
            // 
            // m_print
            // 
            //m_print.Text = "&Print...~tCtrl+P";
            m_print.Text = "&Print...";
            m_print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            // Metex Migrator Warning: property shortcut 336 was not converted
            m_print.ToolTipText = "Prints the item";
            // 
            // m_printpreview
            // 
            m_printpreview.Text = "Print Pre&view";
            m_printpreview.ToolTipText = "View pages as they will be printed";
            // 
            // m_pagesetup
            // 
            m_pagesetup.Text = "Page Set&up...";
            m_pagesetup.ToolTipText = "Changes page layout settings";
            // 
            // m_printersetup
            // 
            m_printersetup.Text = "Printer Set&up";
            // 
            // m_dash13
            // 
            m_dash13.Visible = false;
            //m_dash13.Text = "-";
            // 
            // m_properties
            // 
            m_properties.Text = "P&roperties";
            m_properties.Enabled = false;
            m_properties.ToolTipText = "Displays or changes properties of the item";
            // 
            // m_dash14
            // 
            //m_dash14.Text = "-";
            // 
            // m_exit
            // 
            m_exit.Text = "E&xit";
            m_exit.ToolTipText = "Quits the application";
            // Metex Migrator Warning: property toolbaritemorder 9999 was not converted
            // 
            // m_edit
            // 
            //m_edit.Text = "&Edit";
            //m_undo = new ToolStripMenuItem();
            //m_dash21 = new ToolStripSeparator();
            //m_cut = new ToolStripMenuItem();
            //m_copy = new ToolStripMenuItem();
            //m_paste = new ToolStripMenuItem();
            //m_dash22 = new ToolStripSeparator();
            //m_find = new ToolStripMenuItem();
            //m_replace = new ToolStripMenuItem();
            //m_edit.DropDownItems.Add(m_undo);
            //m_edit.DropDownItems.Add(m_dash21);
            //m_edit.DropDownItems.Add(m_cut);
            //m_edit.DropDownItems.Add(m_copy);
            //m_edit.DropDownItems.Add(m_paste);
            //m_edit.DropDownItems.Add(m_dash22);
            //m_edit.DropDownItems.Add(m_find);
            //m_edit.DropDownItems.Add(m_replace);
            // 
            // m_undo
            // 
            //m_undo.Text = "&Undo~tCtrl+Z";
            m_undo.Text = "&Undo";
            m_undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            // Metex Migrator Warning: property shortcut 346 was not converted
            m_undo.ToolTipText = "Reverses last action";
            // 
            // m_dash21
            // 
            //m_dash21.Text = "-";
            // 
            // m_cut
            // 
            //m_cut.Text = "Cu&t~tCtrl+X";
            m_cut.Text = "Cu&t";
            m_cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            // Metex Migrator Warning: property shortcut 344 was not converted
            m_cut.ToolTipText = "Moves the selection to the Clipboard";
            // 
            // m_copy
            // 
            //m_copy.Text = "&Copy~tCtrl+C";
            m_copy.Text = "&Copy";
            m_copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            // Metex Migrator Warning: property shortcut 323 was not converted
            m_copy.ToolTipText = "Copies the selection to the Clipboard";
            // 
            // m_paste
            // 
            //m_paste.Text = "&Paste~tCtrl+V";
            m_paste.Text = "&Paste";
            m_paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            // Metex Migrator Warning: property shortcut 342 was not converted
            m_paste.ToolTipText = "Inserts Clipboard contents at current insertion point";
            // 
            // m_dash22
            // 
            //m_dash22.Text = "-";
            // 
            // m_find
            // 
            //m_find.Text = "&Find...~tCtrl+F";
            m_find.Text = "&Find...";
            m_find.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            // Metex Migrator Warning: property shortcut 326 was not converted
            m_find.ToolTipText = "Finds the specified text";
            // 
            // m_replace
            // 
            //m_replace.Text = "&Replace...~tCtrl+H";
            m_replace.Text = "&Replace...";
            m_replace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            // Metex Migrator Warning: property shortcut 328 was not converted
            m_replace.ToolTipText = "Replaces specific text with different text";
            // 
            // m_view
            // 
            //m_view.Text = "&View";
            //m_ruler = new ToolStripMenuItem();
            //m_dash31 = new ToolStripSeparator();
            m_firstpage = new ToolStripMenuItem();
            //m_nextpage = new ToolStripMenuItem();
            //m_priorpage = new ToolStripMenuItem();
            //m_lastpage = new ToolStripMenuItem();
            //m_dash32 = new ToolStripSeparator();
            m_nextgroup = new ToolStripMenuItem();
            m_priorgroup = new ToolStripMenuItem();
            m_dash33 = new ToolStripSeparator();
            //m_sort = new ToolStripMenuItem();
            //m_filter = new ToolStripMenuItem();
            //m_dash34 = new ToolStripSeparator();
            m_notes = new ToolStripMenuItem();
            //m_zoom = new ToolStripMenuItem();
            //m_view.DropDownItems.Add(m_ruler);
            //m_view.DropDownItems.Add(m_dash31);
            m_view.DropDownItems.Insert(2,m_firstpage);
            //m_view.DropDownItems.Add(m_nextpage);
            //m_view.DropDownItems.Add(m_priorpage);
            //m_view.DropDownItems.Add(m_lastpage);
            //m_view.DropDownItems.Add(m_dash32);
            m_view.DropDownItems.Insert(7,m_nextgroup);
            m_view.DropDownItems.Insert(8,m_priorgroup);
            m_view.DropDownItems.Insert(9,m_dash33);
            //m_view.DropDownItems.Add(m_sort);
            //m_view.DropDownItems.Add(m_filter);
            //m_view.DropDownItems.Add(m_dash34);
            m_view.DropDownItems.Insert(13,m_notes);
            //m_view.DropDownItems.Add(m_zoom);
            // 
            // m_ruler
            // 
            m_ruler.Text = "&Ruler";
            m_ruler.ToolTipText = "Shows or hides the ruler";
            // 
            // m_-6
            // 
            //m_dash31.Text = "-";
            // 
            // m_firstpage
            // 
            m_firstpage.Text = "&First";
            m_firstpage.ToolTipText = "First";
            // 
            // m_nextpage
            // 
            m_nextpage.Text = "&Next";
            m_nextpage.ToolTipText = "Next";
            // 
            // m_priorpage
            // 
            m_priorpage.Text = "&Prior";
            m_priorpage.ToolTipText = "Prior";
            // 
            // m_lastpage
            // 
            m_lastpage.Text = "L&ast";
            m_lastpage.ToolTipText = "Last";
            // 
            // m_-2
            // 
            //m_dash32.Text = "-";
            // 
            // m_nextgroup
            // 
            m_nextgroup.Text = "Ne&xt Group";
            m_nextgroup.ToolTipText = "Scroll to the next group break";
            m_nextgroup.Visible = false;
            // 
            // m_priorgroup
            // 
            m_priorgroup.Text = "Pri&or Group";
            m_priorgroup.ToolTipText = "Scroll to previous group break";
            m_priorgroup.Visible = false;
            // 
            // m_dash35
            // 
            //m_dash33.Text = "-";
            m_dash35.Visible = false;
            // 
            // m_sort
            // 
            m_sort.Text = "&Sort...";
            m_sort.ToolTipText = "Sorts items";
            m_sort.Visible = false;
            // 
            // m_filter
            // 
            m_filter.Text = "Fil&ter...";
            m_filter.ToolTipText = "Filters items";
            m_filter.Visible = false;
            // 
            // m_-
            // 
            //m_dash34.Text = "-";
            m_dash34.Visible = false;
            // 
            // m_notes
            // 
            m_notes.Text = "N&otes";
            m_notes.ToolTipText = "View notes for current object";
            m_notes.Visible = false;
            // 
            // m_zoom
            // 
            m_zoom.Text = "&Zoom...";
            m_zoom.ToolTipText = "Scales the display of the print preview";
            // 
            // m_record
            // 
            m_record.Text = "&Record";
            m_addrow = new ToolStripMenuItem();
            m_insertrow = new ToolStripMenuItem();
            m_dash41 = new ToolStripSeparator();
            m_deleterow = new ToolStripMenuItem();
            m_record.DropDownItems.Add(m_addrow);
            m_record.DropDownItems.Add(m_insertrow);
            m_record.DropDownItems.Add(m_dash41);
            m_record.DropDownItems.Add(m_deleterow);
            // 
            // m_addrow
            // 
            m_addrow.Text = "&Add Row";
            m_addrow.ToolTipText = "Add a new row at the bottom";
            // 
            // m_insertrow
            // 
            m_insertrow.Text = "&Insert Row";
            m_insertrow.ToolTipText = "Insert a new row before the current row";
            // 
            // m_-4
            // 
            //m_dash41.Text = "-";
            // 
            // m_deleterow
            // 
            m_deleterow.Text = "&Delete Row";
            m_deleterow.ToolTipText = "Delete the current row";
            // 
            // m_odps
            // 
            m_odps.Text = "&Owner Driver Payment";
            m_paymentrun = new ToolStripMenuItem();
            m_codetabelemaintenance = new ToolStripMenuItem();
            m_generalledgeraccrualinterface = new ToolStripMenuItem();
            m_invoicemailinginterface = new ToolStripMenuItem();
            m_accountspayableinterface = new ToolStripMenuItem();
            m_ir3interfacereport = new ToolStripMenuItem();
            m_ir348interface = new ToolStripMenuItem();
            m_updatedcontractorsexport = new ToolStripMenuItem();
            m_1 = new ToolStripMenuItem();
            m_shellimport = new ToolStripMenuItem();
            m_odps.DropDownItems.Add(m_paymentrun);
            m_odps.DropDownItems.Add(m_codetabelemaintenance);
            m_odps.DropDownItems.Add(m_generalledgeraccrualinterface);
            m_odps.DropDownItems.Add(m_invoicemailinginterface);
            m_odps.DropDownItems.Add(m_accountspayableinterface);
            m_odps.DropDownItems.Add(m_ir3interfacereport);
            m_odps.DropDownItems.Add(m_ir348interface);
            m_odps.DropDownItems.Add(m_updatedcontractorsexport);
            m_odps.DropDownItems.Add(m_1);
            m_odps.DropDownItems.Add(m_shellimport);
            // 
            // m_paymentrun
            // 
            m_paymentrun.Visible = false;
            m_paymentrun.Text = "&Payment Run";
            m_paymentrun.Enabled = false;
            m_paymentrun.Tag = "ComponentName=ODPS Payrun;";
            m_paymentrun.EnabledChanged += new EventHandler(m_paymentrun_EnabledChanged);
            // 
            // m_codetabelemaintenance
            // 
            m_codetabelemaintenance.Visible = false;
            m_codetabelemaintenance.Text = "&Code Table Maintenance";
            m_codetabelemaintenance.Enabled = false;
            m_codetabelemaintenance.ToolTipText = "Code table maintenance";
            m_codetabelemaintenance.Tag = "ComponentName=ODPS Parameters;";
            // 
            // m_generalledgeraccrualinterface
            // 
            m_generalledgeraccrualinterface.Visible = false;
            m_generalledgeraccrualinterface.Text = "&General Ledger Accrual Interface";
            m_generalledgeraccrualinterface.Enabled = false;
            m_generalledgeraccrualinterface.Tag = "ComponentName=ODPS Financials;";
            m_payments = new ToolStripMenuItem();
            m_accruals = new ToolStripMenuItem();
            m_generalledgeraccrualinterface.DropDownItems.Add(m_payments);
            m_generalledgeraccrualinterface.DropDownItems.Add(m_accruals);
            // 
            // m_payments
            // 
            m_payments.Text = "Payments";
            // 
            // m_accruals
            // 
            m_accruals.Text = "Accruals";
            // 
            // m_invoicemailinginterface
            // 
            m_invoicemailinginterface.Visible = false;
            m_invoicemailinginterface.Text = "&Invoice PSR File";
            m_invoicemailinginterface.Enabled = false;
            m_invoicemailinginterface.Tag = "ComponentName=ODPS Invoice;";
            m_invoicemailinginterface.EnabledChanged += new EventHandler(m_invoicemailinginterface_EnabledChanged);
            // 
            // m_-3
            // 
            // 
            // m_accountspayableinterface
            // 
            m_accountspayableinterface.Visible = false;
            m_accountspayableinterface.Text = "&Accounts Payable Interface";
            m_accountspayableinterface.Enabled = false;
            m_accountspayableinterface.Tag = "ComponentName=ODPS Financials;";
            // 
            // m_ir3interfacereport
            // 
            m_ir3interfacereport.Visible = false;
            m_ir3interfacereport.Text = "IR&3 Interface/Report";
            m_ir3interfacereport.Enabled = false;
            m_ir3interfacereport.Tag = "ComponentName=ODPS Financials;";
            // 
            // m_ir348interface
            // 
            m_ir348interface.Visible = false;
            m_ir348interface.Text = "IR348 Interface";
            m_ir348interface.Enabled = false;
            m_ir348interface.Tag = "ComponentName=ODPS Financials;";
            // 
            // m_updatedcontractorsexport
            // 
            m_updatedcontractorsexport.Visible = false;
            m_updatedcontractorsexport.Text = "Updated Contractors Export";
            m_updatedcontractorsexport.Enabled = false;
            m_updatedcontractorsexport.Tag = "ComponentName=ODPS Financials;";
            // 
            // m_1
            // 
            m_1.Visible = false;
            m_1.Text = "&Shell Import...";
            m_1.Enabled = false;
            m_1.Tag = "ComponentName=ODPS Financials;";
            // 
            // m_shellimport
            // 
            m_shellimport.Visible = false;
            m_shellimport.Text = "&Telecom Import...";
            m_shellimport.Enabled = false;
            m_shellimport.Tag = "ComponentName=ODPS Financials;";
            // 
            // m_ruraldelivery
            // 
            m_ruraldelivery.Visible = false;
            m_ruraldelivery.Text = "&Rural Delivery";
            m_ruraldelivery.Enabled = false;
            m_contracts = new ToolStripMenuItem();
            m_ownerdrivers = new ToolStripMenuItem();
            m_piecerates = new ToolStripMenuItem();
            m_ruraldelivery.DropDownItems.Add(m_contracts);
            m_ruraldelivery.DropDownItems.Add(m_ownerdrivers);
            m_ruraldelivery.DropDownItems.Add(m_piecerates);
            // 
            // m_contracts
            // 
            m_contracts.Text = "&Contracts";
            // 
            // m_ownerdrivers
            // 
            m_ownerdrivers.Text = "&Owner Drivers";
            // 
            // m_piecerates
            // 
            m_piecerates.Text = "&Piece Rates Import";
            // 
            // m_reports
            // 
            m_reports.Text = "Re&ports";
            // 
            // m_security
            // 
            m_security.Text = "&Security";
            // 
            // m_window
            // 
            //m_window.Text = "&Window";
            //m_cascade = new ToolStripMenuItem();
            //m_tilehorizontal = new ToolStripMenuItem();
            //m_tilevertical = new ToolStripMenuItem();
            //m_layer = new ToolStripMenuItem();
            m_dash91 = new ToolStripSeparator();
            m_customizetoolbars = new ToolStripMenuItem();
            //m_window.DropDownItems.Add(m_cascade);
            //m_window.DropDownItems.Add(m_tilehorizontal);
            //m_window.DropDownItems.Add(m_tilevertical);
            //m_window.DropDownItems.Add(m_layer);
            m_window.DropDownItems.Insert(4,m_dash91);
            m_window.DropDownItems.Insert(5, m_customizetoolbars);
            m_window.DropDownItems.Remove(m_dash51);
            m_window.DropDownItems.Remove(m_minimizeall);
            m_window.DropDownItems.Remove(m_undoarrange);
            // 
            // m_cascade
            // 
            m_cascade.Text = "&Cascade";
            m_cascade.ToolTipText = "Cascade windows so that each title bar is visible";
            // 
            // m_tilehorizontal
            // 
            m_tilehorizontal.Text = "Tile &Horizontal";
            m_tilehorizontal.ToolTipText = "Tile windows horizontally so that none are overlapping";
            // 
            // m_tilevertical
            // 
            m_tilevertical.Text = "Tile &Vertical";
            m_tilevertical.ToolTipText = "Tile windows vertically so that none are overlapping";
            // Metex Migrator Warning: property toolbaritemorder 230 was not converted
            // 
            // m_layer
            // 
            m_layer.Text = "&Layer";
            m_layer.ToolTipText = "Layer windows so that each one completely covers the one below it";
            // 
            // m_-1
            // 
            //m_dash91.Text = "-";
            // 
            // m_customizetoolbars
            // 
            m_customizetoolbars.Text = "&Customize Toolbars";
            m_customizetoolbars.ToolTipText = "Arranges toolbar buttons";
            // 
            // m_help
            // 
            //m_help.Text = "&Help";
            //m_helptopics = new ToolStripMenuItem();
            m_index = new ToolStripMenuItem();
            m_currentitem = new ToolStripMenuItem();
            //m_dash61 = new ToolStripSeparator();
            //m_about = new ToolStripMenuItem();
            //m_help.DropDownItems.Add(m_helptopics);
            m_help.DropDownItems.Insert(1,m_index);
            m_help.DropDownItems.Insert(2,m_currentitem);
            //m_help.DropDownItems.Add(m_dash61);
            //m_help.DropDownItems.Add(m_about);
            // 
            // m_helptopics
            // 
            m_helptopics.Text = "&Help Topics";
            m_helptopics.ToolTipText = "Displays help topics";
            // 
            // m_index
            // 
            m_index.Text = "&Index";
            m_index.ToolTipText = "Display index of help topics";
            // 
            // m_currentitem
            // 
            m_currentitem.Text = "&Current Item~tShift+F1";
            // Metex Migrator Warning: property shortcut 1136 was not converted
            m_currentitem.ToolTipText = "Display help for currently selected item";
            // 
            // m_dash61
            // 
            //m_dash61.Text = "-";
            // 
            // m_about
            // 
            m_about.Text = "&About";
            m_about.ToolTipText = "Displays program information";

            //
            //m_printersetup
            //
            m_printersetup_t = new ToolStripButton("Printer Setup",null,null,"m_printersetup_t");
            ToolStrip.Items.Add(m_printersetup_t);
            m_printersetup_t.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            m_printersetup_t.Image = global::NZPostOffice.Shared.Properties.Resources.RunReport5_;
            m_printersetup_t.MergeAction = MergeAction.Replace;
            m_printersetup_t.Click += new EventHandler(m_printersetup_t_click);

            //
            //m_1_t
            //
            m_1_t = new ToolStripSeparator();
            ToolStrip.Items.Add(m_1_t);
            //
            //m_paymentrun
            //
            m_paymentrun_t = new ToolStripButton("Payment Run", null, null, "m_paymentrun_t");
            ToolStrip.Items.Add(m_paymentrun_t);
            m_paymentrun_t.Visible = false;
            m_paymentrun_t.Enabled = false;
            m_paymentrun_t.MergeAction = MergeAction.Replace;
            m_paymentrun_t.Image = global::NZPostOffice.Shared.Properties.Resources.Run;
            m_paymentrun_t.Click += new EventHandler(m_paymentrun_t_click);
            m_paymentrun_t.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            
            //
            //m_invoicemailinginterface_t
            //
            m_invoicemailinginterface_t = new ToolStripButton("Invoice", null, null, "m_invoicemailinginterface_t");
            ToolStrip.Items.Add(m_invoicemailinginterface_t);
            m_invoicemailinginterface_t.Visible = false;
            m_invoicemailinginterface_t.Enabled = false;
            m_invoicemailinginterface_t.MergeAction = MergeAction.Replace;
            m_invoicemailinginterface_t.Image = global::NZPostOffice.Shared.Properties.Resources.FormatDollar_;
            m_invoicemailinginterface_t.Click += new EventHandler(m_invoicemailinginterface_t_click);
            m_invoicemailinginterface_t.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            
            //
            //m_2_t
            //
            m_2_t = new ToolStripSeparator();
            m_2_t.Visible = false;
            ToolStrip.Items.Add(m_2_t);
            //
            //_m_exit
            //
            if (_m_exit != null)
            {
                _m_exit.Image = global::NZPostOffice.Shared.Properties.Resources.EXIT1;

                if(!ToolStrip.Items.Contains(_m_exit))
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
            _m_exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;

            m_new.Click += new EventHandler(m_new_clicked);
            m_open.Click += new EventHandler(m_open_clicked);
            m_close.Click += new EventHandler(m_close_clicked);
            m_save.Click += new EventHandler(m_save_clicked);
            m_saveas.Click += new EventHandler(m_saveas_clicked);
            m_print.Click += new EventHandler(m_print_clicked);
            m_printpreview.Click += new EventHandler(m_printpreview_clicked);
            m_pagesetup.Click += new EventHandler(m_pagesetup_clicked);
            m_printersetup.Click += new EventHandler(m_printersetup_clicked);
            m_properties.Click += new EventHandler(m_properties_clicked);
            m_exit.Click += new EventHandler(m_exit_clicked);
            m_undo.Click += new EventHandler(m_undo_clicked);
            m_cut.Click += new EventHandler(m_cut_clicked);
            m_copy.Click += new EventHandler(m_copy_clicked);
            m_paste.Click += new EventHandler(m_paste_clicked);
            m_find.Click += new EventHandler(m_find_clicked);
            m_replace.Click += new EventHandler(m_replace_clicked);
            m_ruler.Click += new EventHandler(m_ruler_clicked);
            m_firstpage.Click += new EventHandler(m_firstpage_clicked);
            m_nextpage.Click += new EventHandler(m_nextpage_clicked);
            m_priorpage.Click += new EventHandler(m_priorpage_clicked);
            m_lastpage.Click += new EventHandler(m_lastpage_clicked);
            m_nextgroup.Click += new EventHandler(m_nextgroup_clicked);
            m_priorgroup.Click += new EventHandler(m_priorgroup_clicked);
            m_sort.Click += new EventHandler(m_sort_clicked);
            m_filter.Click += new EventHandler(m_filter_clicked);
            m_notes.Click += new EventHandler(m_notes_clicked);
            m_zoom.Click += new EventHandler(m_zoom_clicked);
            m_addrow.Click += new EventHandler(m_addrow_clicked);
            m_insertrow.Click += new EventHandler(m_insertrow_clicked);
            m_deleterow.Click += new EventHandler(m_deleterow_clicked);
            m_paymentrun.Click += new EventHandler(m_paymentrun_clicked);
            m_codetabelemaintenance.Click += new EventHandler(m_codetabelemaintenance_clicked);
            m_payments.Click += new EventHandler(m_payments_clicked);
            m_accruals.Click += new EventHandler(m_accruals_clicked);
            m_invoicemailinginterface.Click += new EventHandler(m_invoicemailinginterface_clicked);
            m_accountspayableinterface.Click += new EventHandler(m_accountspayableinterface_clicked);
            m_ir3interfacereport.Click += new EventHandler(m_ir3interfacereport_clicked);
            m_ir348interface.Click += new EventHandler(m_ir348interface_clicked);
            m_updatedcontractorsexport.Click += new EventHandler(m_updatedcontractorsexport_clicked);
            m_1.Click += new EventHandler(m_1_clicked);
            m_shellimport.Click += new EventHandler(m_shellimport_clicked);
            m_contracts.Click += new EventHandler(m_contracts_clicked);
            m_ownerdrivers.Click += new EventHandler(m_ownerdrivers_clicked);
            m_piecerates.Click += new EventHandler(m_piecerates_clicked);
            m_cascade.Click += new EventHandler(m_cascade_clicked);
            m_tilehorizontal.Click += new EventHandler(m_tilehorizontal_clicked);
            m_tilevertical.Click += new EventHandler(m_tilevertical_clicked);
            m_layer.Click += new EventHandler(m_layer_clicked);
            m_customizetoolbars.Click += new EventHandler(m_customizetoolbars_clicked);
            m_helptopics.Click += new EventHandler(m_helptopics_clicked);
            m_index.Click += new EventHandler(m_index_clicked);
            m_currentitem.Click += new EventHandler(m_currentitem_clicked);
            m_about.Click += new EventHandler(m_about_clicked);


        }

        private void m_paymentrun_EnabledChanged(object sender, EventArgs e)
        {
            m_paymentrun_t.Visible = m_paymentrun.Enabled;
            m_paymentrun_t.Enabled = m_paymentrun.Enabled;
        }

        private void m_invoicemailinginterface_EnabledChanged(object sender, EventArgs e)
        {
            m_invoicemailinginterface_t.Visible = m_invoicemailinginterface.Enabled;
            m_invoicemailinginterface_t.Enabled = m_invoicemailinginterface.Enabled;

            if (m_invoicemailinginterface.Enabled)
            {
                m_2_t.Visible = true;
            }
        }

        public virtual void m_new_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_New
            // 	Method:			Clicked
            // 	Description:	send the file/new message via the message router
            Cursor.Current = Cursors.WaitCursor;
            ((FormBase)base._form).pfc_default();
            //of_sendmessage("pfc_New");
        }

        public virtual void m_open_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_Open
            // 	Method:			Clicked
            // 	Description:	send the file/open message via the message router
            Cursor.Current = Cursors.WaitCursor;
            //of_sendmessage("pfc_Open");
            ((FormBase)base._form).pfc_postopen();
        }

        public virtual void m_close_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_Close
            // 	Method:			Clicked
            // 	Description:	send the file/close message via the message router
            Cursor.Current = Cursors.WaitCursor;
            //of_sendmessage("pfc_Close");
            ((FormBase)base._form).pfc_preclose();
        }

        public virtual void m_save_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_Save
            // 	Method:			Clicked
            // 	Description:	send the file/save message via the message router
            Cursor.Current = Cursors.WaitCursor;
            //of_sendmessage("pfc_Save");
            ((FormBase)base._form).pfc_save();
        }

        public virtual void m_saveas_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_SaveAs
            // 	Method:			Clicked
            // 	Description:	send the file/saveas message via the message router
            Cursor.Current = Cursors.WaitCursor;
            //of_sendmessage("pfc_SaveAs");
            ((FormBase)base._form).pfc_saveas();
        }

        public virtual void m_print_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_Print
            // 	Method:			Clicked
            // 	Description:	send the file/print message via the message router
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_Print");
        }

        public virtual void m_printpreview_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_PrintPreview
            // 	Method:			Clicked
            // 	Description:	send the file/printpreview message via the message router
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_PrintPreview");
            
        }

        public virtual void m_pagesetup_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_pagesetup");
        }

        public virtual void m_printersetup_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
//?         PrintSetup();
        }

        public virtual void m_properties_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_Properties
            // 	Method:			Clicked
            // 	Description:	open the response window used to maintain user preferences
            Cursor.Current = Cursors.WaitCursor;
//?         Open(w_properties);
        }

        public virtual void m_exit_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_File.m_Exit
            // 	Method:			Clicked
            // 	Description:	close the application via the application manager
            Cursor.Current = Cursors.WaitCursor;
            //gnv_app.pfc_Exit();
            ((FormBase)base._form).pfc_exit();
        }

        public virtual void m_undo_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_Undo
            // 	Method:			Clicked
            // 	Description:	send the edit/undo message via the message router
            //of_sendmessage("pfc_Undo");
            ((FormBase)base._form).pfc_undo();
        }

        public virtual void m_cut_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_Cut
            // 	Method:			Clicked
            // 	Description:	send the edit/cut message via the message router
            //of_sendmessage("pfc_Cut");
            ((FormBase)base._form).pfc_cut();
        }

        public virtual void m_copy_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_Copy
            // 	Method:			Clicked
            // 	Description:	send the edit/copy message via the message router
//?         of_sendmessage("pfc_Copy");
            
        }

        public virtual void m_paste_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_Paste
            // 	Method:			Clicked
            // 	Description:	send the edit/paste message via the message router
//?         of_sendmessage("pfc_Paste");
        }

        public virtual void m_find_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_Find
            // 	Method:			Clicked
            // 	Description:	send the edit/find message via the message router
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_FindDlg");
        }

        public virtual void m_replace_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_Replace
            // 	Method:			Clicked
            // 	Description:	send the edit/replace message via the message router
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_ReplaceDlg");
        }

        public virtual void m_ruler_clicked(object sender, EventArgs e)
        {
//?         of_sendmessage("pfc_ruler");
            
        }

        public virtual void m_firstpage_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_First
            // 	Method:			Clicked
            // 	Description:	send the view/first message via the message router
//?         of_sendmessage("pfc_FirstPage");
            
        }

        public virtual void m_nextpage_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_NextPage
            // 	Method:			Clicked
            // 	Description:	send the view/next message via the message router
//?         of_sendmessage("pfc_NextPage");
        }

        public virtual void m_priorpage_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_PriorPage
            // 	Method:			Clicked
            // 	Description:	send the view/priorpage message via the message router
//?         of_sendmessage("pfc_PreviousPage");
        }

        public virtual void m_lastpage_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_LastPage
            // 	Method:			Clicked
            // 	Description:	send the view/last message via the message router
//?         of_sendmessage("pfc_LastPage");
        }

        public virtual void m_nextgroup_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_NextGroup
            // Method:			Clicked
            // 	Description:	scroll to the next group break
//?         of_sendmessage("cs_NextGroup");
        }

        public virtual void m_priorgroup_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_PriorGroup
            // Method:			Clicked
            // 	Description:	scroll to the previous group break
//?         of_sendmessage("cs_PriorGroup");
        }

        public virtual void m_sort_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_Sort
            // 	Method:			Clicked
            // 	Description:	send the view/sort message via the message router
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_SortDlg");
        }

        public virtual void m_filter_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_Filter
            // 	Method:			Clicked
            // 	Description:	send the view/filter message via the message router
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_FilterDlg");
        }

        public virtual void m_notes_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_Notes
            // 	Method:			Clicked
            // 	Description:	view any sticky notes related to the window
/*?
            Form lw_Parent;
            w_master lw_Master;
            lw_Parent = ParentWindow;
            if (lw_Parent.TriggerEvent("cs_Descendant") > 0)
            {
                lw_Master = lw_Parent;
                lw_Master.cs_viewnotes(lw_Master, 0, "");
            }
*/
        }

        public virtual void m_zoom_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_zoom");
            
        }

        public virtual void m_addrow_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_AddRow
            // 	Method:			Clicked
            // 	Description:	send a message to the control to add a row
//?         of_sendmessage("pfc_AddRow");
            
        }

        public virtual void m_insertrow_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_InsertRow
            // 	Method:			Clicked
            // 	Description:	send a message to the control to Insert a row
//?         of_sendmessage("pfc_InsertRow");
        }

        public virtual void m_deleterow_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Edit.m_DeleteRow
            // 	Method:			Clicked
            // 	Description:	send a message to the control to Delete a row
//?         of_sendmessage("pfc_DeleteRow");
        }

        public virtual void m_paymentrun_clicked(object sender, EventArgs e) 
        {
/*?
            int ll_response;
            w_pots w_window;
            Cursor.Current = Cursors.WaitCursor;
            //  TWC - 26/05/2003 - ask the user if there are any POTS to be inputted
            ll_response = MessageBox("Payment run detail", "Are there any POTS to be entered for this payment run?", question!, yesno!);
            if (ll_response == 1) {
                //  opent the pots window
                OpenSheetWithParm(w_window, "POTS", ParentWindow, 0, original!);
            }
            else {
                OpenSheet(w_payment_run_search, ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_codetabelemaintenance_clicked(object sender, EventArgs e)
        {
            // 	Object:			m_OrderEntry.m_Edit.m_CodeMaintenance
            // 	Method:			Clicked
            // 	Description:	open the sheet for code maintenance
            Cursor.Current = Cursors.WaitCursor;
//?         OpenSheet(w_code_table_maintenance, ParentWindow, 0, original!);
        }

        public virtual void m_payments_clicked(object sender, EventArgs e) 
        {
/*?
            w_export_criteria w_window;
            if (!(mf_check_window("General Ledger Interface-Payments")))
            {
            Cursor.Current = Cursors.WaitCursor;
                OpenSheetWithParm(w_window, "GL Interface-Payments", ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_accruals_clicked(object sender, EventArgs e) 
        {
/*?
            w_export_criteria w_window;
            if (!(mf_check_window("General Ledger Interface-Accruals"))) {
            Cursor.Current = Cursors.WaitCursor;
                OpenSheetWithParm(w_window, "GL Interface-Accruals", ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_invoicemailinginterface_clicked(object sender, EventArgs e) 
        {
/*?
            w_export_criteria w_window;
            if (!(mf_check_window("Invoice"))) {
            Cursor.Current = Cursors.WaitCursor;
                OpenSheetWithParm(w_invoice_search, "Invoice", ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_accountspayableinterface_clicked(object sender, EventArgs e)
        {
/*?
            w_export_criteria w_window;
            if (!(mf_check_window("Accounts Payable Interface"))) 
            {
            Cursor.Current = Cursors.WaitCursor;
                OpenSheetWithParm(w_window, "Accounts Payable Interface", ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_ir3interfacereport_clicked(object sender, EventArgs e)
        {
/*?
            w_export_criteria w_window;
            if (!(mf_check_window("IR13 Interface")))
            {
            Cursor.Current = Cursors.WaitCursor;
                OpenSheetWithParm(w_window, "IR13 Interface", ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_ir348interface_clicked(object sender, EventArgs e) 
        {
/*?
            w_export_criteria w_window;
            if (!(mf_check_window("IR348 Interface"))) 
            {
            Cursor.Current = Cursors.WaitCursor;
                OpenSheetWithParm(w_window, "IR348 Interface", ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_updatedcontractorsexport_clicked(object sender, EventArgs e)
        {
/*?
            w_export_criteria w_window;
            if (!(mf_check_window("Updated Contractors"))) 
            {
                Cursor.Current = Cursors.WaitCursor;
                OpenSheetWithParm(w_window, "Updated Contractors", ParentWindow, 0, original!);
            }
*/
        }

        public virtual void m_1_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
//?         OpenSheet(w_shell_import, ParentWindow, 0, original!);
        }

        public virtual void m_shellimport_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
//?         OpenSheet(w_telecom_import, ParentWindow, 0, original!);
        }

        public virtual void m_contracts_clicked(object sender, EventArgs e)
        {
//?         mf_run_rds("Contract Search");
        }

        public virtual void m_ownerdrivers_clicked(object sender, EventArgs e)
        {
//?         mf_run_rds("Owner Driver");
        }

        public virtual void m_piecerates_clicked(object sender, EventArgs e)
        {
//?         mf_run_rds("Piece Rates Import");
        }

        public virtual void m_window_selected()
        {
            // 	Object:			cs_template_m_Application.m_Windows
            // 	Method:			Selected
            // 	Description:	enable or disable the appropriate submenuitems

/*?
            object lany_Return;
            bool lb_Normal;
            bool lb_valid;
            int li_Return;
            int li_SheetCount;
            int li_Count = 1;
            n_cst_menu lnv_Menu;
            Form lw_Window;
            FormArray lw_Sheet = new FormArray();
            w_frame lw_Frame;
            //  Get frame window
            li_Return = lnv_Menu.of_getmdiframe(m_window, lw_Window);
            if (li_Return < 0)
            {
                return;
            }
            //  Determine IF frame is a PFC frame descendant
            lany_Return = lw_Window.pfc_Descendant();
            if (IsNull(lany_Return)) 
            {
                return;
            }
            lw_Frame = lw_Window;
            //  IF sheetmanager service is enabled, allow for undo and minimize capabilities
            lb_valid = IsValid(lw_Frame.inv_sheetmanager);
            if (lb_valid) {
                //  First determine IF there are any nonminimized sheets open
                li_SheetCount = lw_Frame.inv_sheetmanager.of_getsheets(lw_Sheet);
                while (li_Count <= li_SheetCount && lb_Normal == false) 
                {
                    if (lw_Sheet[li_Count].WindowState != minimized!) 
                    {
                        lb_Normal = true;
                    }
                    li_Count++;
                }
                m_window.m_Cascade.Enabled = lb_Normal;
                m_window.m_Layer.Enabled = lb_Normal;
                m_window.m_TileHorizontal.Enabled = lb_Normal;
                m_window.m_TileVertical.Enabled = lb_Normal;
            }
*/
        }

        public virtual void m_cascade_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Windows.m_Cascade
            // 	Method:			Clicked
            // 	Description:	send the windows/cascade message via the message router
//?         of_sendmessage("pfc_Cascade");
        }

        public virtual void m_tilehorizontal_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Windows.m_TileHorizontal
            // 	Method:			Clicked
            // 	Description:	send the windows/tilehorizontal message via the message router
//?         of_sendmessage("pfc_TileHorizontal");
        }

        public virtual void m_tilevertical_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Windows.m_TileVertical
            // 	Method:			Clicked
            // 	Description:	send the windows/tilevertical message via the message router
//?         of_sendmessage("pfc_TileVertical");
        }

        public virtual void m_layer_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Windows.m_Layer
            // 	Method:			Clicked
            // 	Description:	send the windows/layer message via the message router
//?         of_sendmessage("pfc_Layer");
        }

        public virtual void m_customizetoolbars_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_View.m_ToolBars
            // 	Method:			Clicked
            // 	Description:	send the view/toolbars message via the message router
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("pfc_ToolBars");
        }

        public virtual void m_helptopics_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Help.m_HelpTopics
            // 	Method:			Clicked
            // 	Description:	send the help/help message via the message router
            //  TJB  Feb 2005

/*?
            string ls_helpURL;
            ls_helpURL = gnv_app.of_getHelpURL();
            GetContextService("Internet", iinet_base);
            // iinet_base.HyperlinkToURL ( "\\LHPSHOP1\DATA\SHARED\RDPOSTSHARED\OnlineHelp\HelpHomepage.htm")
            iinet_base.HyperLinkToURL(ls_helpURL);
*/
        }

        public virtual void m_index_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Help.m_Index
            // 	Method:			Clicked
            // 	Description:	execute the help index
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("cs_HelpIndex");
        }

        public virtual void m_currentitem_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Help.m_CurrentItem
            // 	Method:			Clicked
            // 	Description:	execute the help for the current item, if no current item, the index will be displayed
            Cursor.Current = Cursors.WaitCursor;
//?         of_sendmessage("cs_HelpCurrentItem");
        }

        public virtual void m_about_clicked(object sender, EventArgs e)
        {
            // 	Object:			cs_template_m_Application.m_Help.m_About
            // 	Method:			Clicked
            // 	Description:	open the about dialog from the application manager
            Cursor.Current = Cursors.WaitCursor;
//?         gnv_app.of_About();
        }


        public virtual void m_paymentrun_t_click(object sender, EventArgs e)
        {
            //int ll_response;
            //w_pots w_window;
            //Cursor.Current = Cursors.WaitCursor;
            ////  TWC - 26/05/2003 - ask the user if there are any POTS to be inputted
            //ll_response = MessageBox("Payment run detail", "Are there any POTS to be entered for this payment run?", question!, yesno!);
            //if (ll_response == 1) 
            //{
            //    //  opent the pots window
            //    OpenSheetWithParm(w_window, "POTS", ParentWindow, 0, original!);
            //}
            //else 
            //{
            //    OpenSheet(w_payment_run_search, ParentWindow, 0, original!);
            //}
        }

        public virtual void m_printersetup_t_click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //PrintSetup();
        }
        public virtual void m_invoicemailinginterface_t_click(object sender, EventArgs e)
        {
            
        }
    }
}
