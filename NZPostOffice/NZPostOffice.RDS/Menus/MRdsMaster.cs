using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Menus
{
    public  class MRdsMaster : MenuStrip
    {
         private System.ComponentModel.IContainer components = null;
        
        /// Reference to the menu functions
        //private MRdsMaster m_rds_master;
        
        public ToolStripMenuItem m_file;
        
        public ToolStripMenuItem m_open;
        
        public ToolStripMenuItem m_close;
        
        public ToolStripMenuItem m_dash11;
        
        public ToolStripMenuItem m_save;
        
        public ToolStripMenuItem m_saveas;
        
        public ToolStripMenuItem m_dash12;
        
        public ToolStripMenuItem m_print;
        
        public ToolStripMenuItem m_printpreview;
        
        public ToolStripMenuItem m_pagesetup;
        
        public ToolStripMenuItem m_exit;
        
        public ToolStripMenuItem m_edit;
        
        public ToolStripMenuItem m_undo;
        
        public ToolStripMenuItem m_dash21;
        
        public ToolStripMenuItem m_cut;
        
        public ToolStripMenuItem m_copy;
        
        public ToolStripMenuItem m_paste;
        
        public ToolStripMenuItem m_clear;
        
        public ToolStripMenuItem m_dash22;
        
        public ToolStripMenuItem m_selectall;
        
        public ToolStripMenuItem m_window;
        
        public ToolStripMenuItem m_cascade;
        
        public ToolStripMenuItem m_tilehorizontal;
        
        public ToolStripMenuItem m_tilevertical;
        
        public ToolStripMenuItem m_layer;
        
        public ToolStripMenuItem m_dash51;
        
        public ToolStripMenuItem m_minimizeall;
        
        public ToolStripMenuItem m_undoarrange;
        
        public ToolStripMenuItem m_help;
        
        public ToolStripMenuItem m_helptopics;
        
        public ToolStripMenuItem m_dash61;
        
        public ToolStripMenuItem m_about;

        private Form current_form;

        public MRdsMaster(Form form)
        {
            this.InitializeComponent();
            this.current_form = form;

            this.current_form.Controls.Add(this);

        }
        
        /// <summary>
        /// Set reference to the functional part of the menu
        /// </summary>
        /// <param name="_m_rds_master">Cl_m_rds_master that is the reference to the functional part of the menu</param>
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            m_file = new ToolStripMenuItem();
            m_edit = new ToolStripMenuItem();
            m_window = new ToolStripMenuItem();
            m_help = new ToolStripMenuItem();
            
            Items.Add(m_file);
            Items.Add(m_edit);
            Items.Add(m_window);
            Items.Add(m_help);
            // 
            // m_file
            // 
            m_file.Text = "&File";
            m_open = new ToolStripMenuItem();
            m_close = new ToolStripMenuItem();
            m_dash11 = new ToolStripMenuItem();
            m_save = new ToolStripMenuItem();
            m_saveas = new ToolStripMenuItem();
            m_dash12 = new ToolStripMenuItem();
            m_print = new ToolStripMenuItem();
            m_printpreview = new ToolStripMenuItem();
            m_pagesetup = new ToolStripMenuItem();
            m_exit = new ToolStripMenuItem();
            m_file.DropDownItems.Add(m_open);
            m_file.DropDownItems.Add(m_close);
            m_file.DropDownItems.Add(m_dash11);
            m_file.DropDownItems.Add(m_save);
            m_file.DropDownItems.Add(m_saveas);
            m_file.DropDownItems.Add(m_dash12);
            m_file.DropDownItems.Add(m_print);
            m_file.DropDownItems.Add(m_printpreview);
            m_file.DropDownItems.Add(m_pagesetup);
            m_file.DropDownItems.Add(m_exit);
            // 
            // m_open
            // 
            m_open.Text = "&Open";
            m_open.ToolTipText = "Open";
           
            // 
            // m_close
            // 
            m_close.Text = "&Close";
            m_close.ToolTipText = "Close";
           
            // 
            // m_dash11
            // 
            m_dash11.Text = "-";
            // 
            // m_save
            // 
            m_save.Text = "&Save~tCtrl+S";
           
            m_save.ToolTipText = "Save";
           
            // 
            // m_saveas
            // 
            m_saveas.Text = "Save &As...";
            m_saveas.ToolTipText = "Save As";
           
            // 
            // m_dash12
            // 
            m_dash12.Text = "-";
            // 
            // m_print
            // 
            m_print.Text = "&Print...~tCtrl+P";
           
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
            // m_exit
            // 
            m_exit.Text = "E&xit";
            m_exit.ToolTipText = "Quits the application";
           
            // 
            // m_edit
            // 
            m_edit.Text = "&Edit";
            m_undo = new ToolStripMenuItem();
            m_dash21 = new ToolStripMenuItem();
            m_cut = new ToolStripMenuItem();
            m_copy = new ToolStripMenuItem();
            m_paste = new ToolStripMenuItem();
            m_clear = new ToolStripMenuItem();
            m_dash22 = new ToolStripMenuItem();
            m_selectall = new ToolStripMenuItem();
            m_edit.DropDownItems.Add(m_undo);
            m_edit.DropDownItems.Add(m_dash21);
            m_edit.DropDownItems.Add(m_cut);
            m_edit.DropDownItems.Add(m_copy);
            m_edit.DropDownItems.Add(m_paste);
            m_edit.DropDownItems.Add(m_clear);
            m_edit.DropDownItems.Add(m_dash22);
            m_edit.DropDownItems.Add(m_selectall);
            // 
            // m_undo
            // 
            m_undo.Text = "&Undo~tCtrl+Z";
           
            m_undo.ToolTipText = "Reverses last action";
           
            // 
            // m_dash21
            // 
            m_dash21.Text = "-";
            // 
            // m_cut
            // 
            m_cut.Text = "Cu&t~tCtrl+X";
           
            m_cut.ToolTipText = "Moves the selection to the Clipboard";
           
            // 
            // m_copy
            // 
            m_copy.Text = "&Copy~tCtrl+C";
           
            m_copy.ToolTipText = "Copies the selection to the Clipboard";
           
            // 
            // m_paste
            // 
            m_paste.Text = "&Paste~tCtrl+V";
           
            m_paste.ToolTipText = "Inserts Clipboard contents at current insertion point";
           
            // 
            // m_clear
            // 
            m_clear.Text = "Cle&ar";
            m_clear.ToolTipText = "Removes the selection";
           
            // 
            // m_dash22
            // 
            m_dash22.Text = "-";
            // 
            // m_selectall
            // 
            m_selectall.Text = "Select A&ll~tCtrl+A";
           
            m_selectall.ToolTipText = "Selects all items or information";
           
            // 
            // m_window
            // 
            m_window.Text = "&Window";
            m_cascade = new ToolStripMenuItem();
            m_tilehorizontal = new ToolStripMenuItem();
            m_tilevertical = new ToolStripMenuItem();
            m_layer = new ToolStripMenuItem();
            m_dash51 = new ToolStripMenuItem();
            m_minimizeall = new ToolStripMenuItem();
            m_undoarrange = new ToolStripMenuItem();
            m_window.DropDownItems.Add(m_cascade);
            m_window.DropDownItems.Add(m_tilehorizontal);
            m_window.DropDownItems.Add(m_tilevertical);
            m_window.DropDownItems.Add(m_layer);
            m_window.DropDownItems.Add(m_dash51);
            m_window.DropDownItems.Add(m_minimizeall);
            m_window.DropDownItems.Add(m_undoarrange);
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
           
            // 
            // m_layer
            // 
            m_layer.Text = "&Layer";
            m_layer.ToolTipText = "Layer windows so that each one completely covers the one below it";
           
            // 
            // m_dash51
            // 
            m_dash51.Text = "-";
            // 
            // m_minimizeall
            // 
            m_minimizeall.Text = "&Minimize All Windows";
            m_minimizeall.ToolTipText = "Minimizes all windows";
            // 
            // m_undoarrange
            // 
            m_undoarrange.Text = "&Undo";
            m_undoarrange.ToolTipText = "Undo";
            // 
            // m_help
            // 
            m_help.Text = "&Help";
            m_helptopics = new ToolStripMenuItem();
            m_dash61 = new ToolStripMenuItem();
            m_about = new ToolStripMenuItem();
            m_help.DropDownItems.Add(m_helptopics);
            m_help.DropDownItems.Add(m_dash61);
            m_help.DropDownItems.Add(m_about);
            // 
            // m_helptopics
            // 
            m_helptopics.Text = "&Help Topics";
            m_helptopics.ToolTipText = "Displays help topics";
           
            // 
            // m_dash61
            // 
            m_dash61.Text = "-";
            // 
            // m_about
            // 
            m_about.Text = "&About";
            m_about.ToolTipText = "Displays program information";
            m_open.Click += new EventHandler(m_open_clicked);
            m_close.Click += new EventHandler(m_close_clicked);
            m_save.Click += new EventHandler(m_save_clicked);
            m_saveas.Click += new EventHandler(m_saveas_clicked);
            m_print.Click += new EventHandler(m_print_clicked);
            m_printpreview.Click += new EventHandler(m_printpreview_clicked);
            m_pagesetup.Click += new EventHandler(m_pagesetup_clicked);
            m_exit.Click += new EventHandler(m_exit_clicked);
            m_undo.Click += new EventHandler(m_undo_clicked);
            m_cut.Click += new EventHandler(m_cut_clicked);
            m_copy.Click += new EventHandler(m_copy_clicked);
            m_paste.Click += new EventHandler(m_paste_clicked);
            m_clear.Click += new EventHandler(m_clear_clicked);
            m_selectall.Click += new EventHandler(m_selectall_clicked);
            m_cascade.Click += new EventHandler(m_cascade_clicked);
            m_tilehorizontal.Click += new EventHandler(m_tilehorizontal_clicked);
            m_tilevertical.Click += new EventHandler(m_tilevertical_clicked);
            m_layer.Click += new EventHandler(m_layer_clicked);
            m_minimizeall.Click += new EventHandler(m_minimizeall_clicked);
            m_undoarrange.Click += new EventHandler(m_undoarrange_clicked);
            m_helptopics.Click += new EventHandler(m_helptopics_clicked);
            m_about.Click += new EventHandler(m_about_clicked);
        }

/*?         public virtual int of_sendmessage(string as_message) {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Function:  of_SendMessage
            // 
            // 	Access:  public
            // 
            // 	Arguments:		
            // 	as_message  message  ( event notification) to be sent
            // 
            // 	Returns:  integer
            // 	 1 = Message successfully sent
            // 	-1 = message could not be sent  ( use debug object for more info)
            // 
            // 	Description:
            // 	Sends a specified message  ( event notification) to a receiving window 
            // 	through the pfc_messagerouter event.
            // 
            // 	Sequence:
            // 	If application is MDI:
            // 	1) Active MDI sheet pfc_messagerouter event.
            // 	2) MDI Frame Window pfc_messagerouter event.
            // 
            // 	Application is SWI:
            // 	1) ParentWindow pfc_messagerouter event.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	5.0	Initial version
            // 	6.0	Function now calls of_sendMessage on n_cst_menu to consolidate code
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright ?1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            NCstMenu lnv_menu;
            return lnv_menu.of_sendmessage(this, as_message);
        }*/
        
        
        public virtual void m_open_clicked(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            //!of_sendmessage("pfc_open");
            ((FormBase)this.current_form).pfc_postopen();
        }
        
        public virtual void m_close_clicked(object sender, EventArgs e) {
            //!of_sendmessage("pfc_close");
            ((FormBase)this.current_form).pfc_preclose();
        }
        
        public virtual void m_save_clicked(object sender, EventArgs e) {
            //!of_sendmessage("pfc_save");
            ((FormBase)this.current_form).pfc_save();
        }
        
        public virtual void m_saveas_clicked(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            //!of_sendmessage("pfc_saveas");
            ((FormBase)this.current_form).pfc_saveas();
        }
        
        public virtual void m_print_clicked(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
            //  TWC - call 4550 -- will check if the w_cust_list_report is current - if so will need to print all of them
            Form lw_sheet;
/*?            FormArray lw_opensheets = new FormArray();
            int ll_sheetcount;
            int ll_counter;
            // n_cst_winsrv_sheetmanager lnv_sheetmanager 
            // lnv_sheetmanager = create n_cst_winsrv_sheetmanager
            WFrame lw_frame;
            ll_sheetcount = 0;
            lw_frame = StaticVariables.gnv_app.of_getframe();
            if (IsValid(lw_frame.inv_sheetmanager) == false) {
                lw_frame.inv_sheetmanager = new NCstWinsrvSheetmanager();
            }
            ll_sheetcount = lw_frame.inv_sheetmanager.of_getsheetsbyclass(lw_opensheets, "w_cust_list_report");
            //  if ll_sheetcount < 2 then
            of_sendmessage("pfc_print");
            //  else //print all the sheets
            //  for ll_counter = 1 to ll_sheetcount 
            //  trigger the print event in the window
            //  lw_opensheets[ll_counter].TriggerEvent ( "pfc_print")
            //  next
            //  end if
 **/
        }
        
        public virtual void m_printpreview_clicked(object sender, EventArgs e) {
            //!of_sendmessage("pfc_printpreview");
        }
        
        public virtual void m_pagesetup_clicked(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
           //! of_sendmessage("pfc_pagesetup");
        }
        
        public virtual void m_exit_clicked(object sender, EventArgs e) {
            //!StaticVariables.gnv_app.pfc_exit();
            ((FormBase)this.current_form).pfc_exit();
        }
        
        public virtual void m_undo_clicked(object sender, EventArgs e) {
            //!of_sendmessage("pfc_undo");
            ((FormBase)this.current_form).pfc_undo();
        }
        
        public virtual void m_cut_clicked(object sender, EventArgs e) {
            //!of_sendmessage("pfc_cut");
            ((FormBase)this.current_form).pfc_cut();

        }
        
        public virtual void m_copy_clicked(object sender, EventArgs e) {
            //!of_sendmessage("pfc_copy");
        }
        
        public virtual void m_paste_clicked(object sender, EventArgs e) {
            //?of_sendmessage("pfc_paste");
        }
        
        public virtual void m_clear_clicked(object sender, EventArgs e) {
            //?of_sendmessage("pfc_clear");
        }
        
        public virtual void m_selectall_clicked(object sender, EventArgs e) {
            //?of_sendmessage("pfc_selectall");
        }
        
        public virtual void m_window_selected() {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:  selected
            // 
            // 	Description:
            // 	Enables menu items based on sheet manager service
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	5.0   Initial version
            // 	6.0.01	Remove logic to disable menu items after windows have been minimized 
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright ?1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
 /*?           object la_rc;
            bool lb_normal;
            int li_rc;
            int li_sheetcount;
            int li_cnt = 1;
            arrangetypes le_arrange;
            NCstMenu lnv_menu;
            Form lw_obj;
            FormArray lw_sheet = new FormArray();
            WFrame lw_frame;
            //  Get frame window
            li_rc = lnv_menu.of_getmdiframe(m_window, lw_obj);
            if (li_rc < 0) {
                return;
            }
            //  Determine if frame is a PFC frame descendant
            la_rc = lw_obj.pfc_descendant();
            if (IsNull(la_rc)) {
                return;
            }
            lw_frame = lw_obj;
            //  If sheetmanager service is enabled, allow for undo and minimize capabilities
              if (IsValid(lw_frame.inv_sheetmanager)) {
                //  First determine if there are any nonminimized sheets open
                li_sheetcount = lw_frame.inv_sheetmanager.of_getsheets(lw_sheet);
              while (li_cnt <= li_sheetcount && !lb_normal) {
                    if (lw_sheet[li_cnt].WindowState != minimized!) {
                        lb_normal = true;
                    }
                    li_cnt++;
                }
                m_window.m_undoarrange.enabled = true;
                m_window.m_minimizeall.enabled = lb_normal;
                m_window.m_cascade.enabled = lb_normal;
                m_window.m_layer.enabled = lb_normal;
                m_window.m_tilehorizontal.enabled = lb_normal;
                m_window.m_tilevertical.enabled = lb_normal;
                //  Get current arrange state of windows and set undo text
                le_arrange = lw_frame.inv_sheetmanager.of_getcurrentstate();
                // PowerBuilder 'Choose Case' statement converted into 'if' statement
                arrangetypes TestExpr = le_arrange;
                if (TestExpr == tile!) {
                    m_window.m_undoarrange.text = "&Undo Tile Vertical";
                    m_window.m_undoarrange.microhelp = "Undoes vertical tile arrangement of windows";
                }
                else if (TestExpr == tilehorizontal!) {
                    m_window.m_undoarrange.text = "&Undo Tile Horizontal";
                    m_window.m_undoarrange.microhelp = "Undoes horizontal tile arrangement of windows";
                }
                else if (TestExpr == cascade!) {
                    m_window.m_undoarrange.text = "&Undo Cascade";
                    m_window.m_undoarrange.microhelp = "Undoes cascaded arrangement of windows";
                }
                else if (TestExpr == layer!) {
                    m_window.m_undoarrange.text = "&Undo Layer";
                    m_window.m_undoarrange.microhelp = "Undoes layered arrangement of windows";
                }
                else if (TestExpr == icons!) {
                    m_window.m_undoarrange.text = "&Undo Minimize All";
                    m_window.m_undoarrange.microhelp = "Undoes minimization of windows";
                }
                else {
                    m_window.m_undoarrange.enabled = false;
                    m_window.m_undoarrange.text = "&Undo";
                    m_window.m_undoarrange.microhelp = "Undo";
                }
            }
            else {
                m_window.m_minimizeall.enabled = false;
                m_window.m_undoarrange.enabled = false;
            }*/
        }
        
        public virtual void m_cascade_clicked(object sender, EventArgs e) {
           //? of_sendmessage("pfc_cascade");
        }
        
        public virtual void m_tilehorizontal_clicked(object sender, EventArgs e) {
           //?of_sendmessage("pfc_tilehorizontal");
        }
        
        public virtual void m_tilevertical_clicked(object sender, EventArgs e) {
           //?of_sendmessage("pfc_tilevertical");
        }
        
        public virtual void m_layer_clicked(object sender, EventArgs e) {
           //? of_sendmessage("pfc_layer");
        }
        
        public virtual void m_minimizeall_clicked(object sender, EventArgs e) {
           //?of_sendmessage("pfc_minimizeall");
        }
        
        public virtual void m_undoarrange_clicked(object sender, EventArgs e) {
           //?of_sendmessage("pfc_undoarrange");
        }
        
        public virtual void m_helptopics_clicked(object sender, EventArgs e) {
            //  of_SendMessage  ( "pfc_help")
            // 
            // 	Object:			cs_template_m_Application.m_Help.m_HelpTopics
            // 	Method:			Clicked
            // 	Description:	send the help/help message via the message router
            //  TJB  Feb 2005
            string ls_helpURL;
/*?            ls_helpURL = StaticVariables.gnv_app.of_gethelpurl();
            GetContextService("Internet", iinet_base);
            //  iinet_base.HyperlinkToURL ( "\\LHPSHOP1\DATA\SHARED\RDPOSTSHARED\OnlineHelp\HelpHomepage.htm")
            iinet_base.HyperLinkToURL(ls_helpURL);*/
        }
        
        public virtual void m_about_clicked(object sender, EventArgs e) {
            Cursor.Current = Cursors.WaitCursor;
          //?  StaticVariables.gnv_app.of_about();
            
        }
    }
}
