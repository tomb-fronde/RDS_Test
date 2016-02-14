using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections;

namespace NZPostOffice.Shared.VisualComponents
{
    // TJB  Feb 2016
    // Commented out closing each form separately in m_exit_clicked()

    // Extension/Example of frame menu
    public class MFrame : MenuBuilder
    {
        #region Menu Define

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

        public ToolStripMenuItem m_printimmediate;

        public ToolStripSeparator m_dash13;

        public ToolStripMenuItem m_delete;

        public ToolStripMenuItem m_properties;

        public ToolStripSeparator m_dash14;

        public ToolStripMenuItem m_exit;

        public ToolStripMenuItem m_pfcmrudash1;

        public ToolStripMenuItem m_pfcmru1;

        public ToolStripMenuItem m_pfcmru2;

        public ToolStripMenuItem m_pfcmru3;

        public ToolStripMenuItem m_pfcmru4;

        public ToolStripMenuItem m_pfcmru5;

        public ToolStripMenuItem m_edit;

        public ToolStripMenuItem m_undo;

        public ToolStripSeparator m_dash21;

        public ToolStripMenuItem m_cut;

        public ToolStripMenuItem m_copy;

        public ToolStripMenuItem m_paste;

        public ToolStripMenuItem m_pastespecial;

        public ToolStripMenuItem m_clear;

        public ToolStripSeparator m_dash22;

        public ToolStripMenuItem m_selectall;

        public ToolStripSeparator m_dash23;

        public ToolStripMenuItem m_find;

        public ToolStripMenuItem m_replace;

        public ToolStripSeparator m_dash24;

        public ToolStripMenuItem m_updatelinks;

        public ToolStripMenuItem m_object1;

        public ToolStripMenuItem m_edit1;

        public ToolStripMenuItem m_open1;

        public ToolStripMenuItem m_view;

        public ToolStripMenuItem m_ruler;

        public ToolStripSeparator m_dash31;

        public ToolStripMenuItem m_largeicon;

        public ToolStripMenuItem m_smallicons;

        public ToolStripMenuItem m_list;

        public ToolStripMenuItem m_details;

        public ToolStripSeparator m_dash32;

        public ToolStripMenuItem m_arrangeicons;

        public ToolStripMenuItem m_by1;

        public ToolStripSeparator m_dash33;

        public ToolStripMenuItem m_autoarrange;

        public ToolStripSeparator m_dash34;

        public ToolStripMenuItem m_first;

        public ToolStripMenuItem m_priorpage;

        public ToolStripMenuItem m_nextpage;

        public ToolStripMenuItem m_lastpage;

        public ToolStripSeparator m_dash35;

        public ToolStripMenuItem m_sort;

        public ToolStripMenuItem m_filter;

        public ToolStripSeparator m_dash36;

        public ToolStripMenuItem m_zoom;

        public ToolStripMenuItem m_insert;

        public ToolStripMenuItem m_insertfile;

        public ToolStripMenuItem m_picture;

        public ToolStripSeparator m_dash41;

        public ToolStripMenuItem m_object;

        public ToolStripMenuItem m_tools;

        public ToolStripMenuItem m_toolbars;

        public ToolStripMenuItem m_window;

        public ToolStripMenuItem m_cascade;

        public ToolStripMenuItem m_tilehorizontal;

        public ToolStripMenuItem m_tilevertical;

        public ToolStripMenuItem m_layer;

        public ToolStripSeparator m_dash51;

        public ToolStripMenuItem m_minimizeall;

        public ToolStripMenuItem m_undoarrange;

        public ToolStripMenuItem m_help;

        public ToolStripMenuItem m_helptopics;

        public ToolStripSeparator m_dash61;

        public ToolStripMenuItem m_about;

        #endregion

        public ToolStripButton _m_exit;

        public Form _form;

        public MFrame()
        {
        }

        public MFrame(Form form)
        {
            BuildMenu(form);
            AddMenuItemEnableEvent();
            _form = form;
        }

        public override void BuildMenu(Form form)
        {
            ToolStrip tstrip = GetToolStripInControl(form);
            if (tstrip == null)
            {
                ToolStrip t = new ToolStrip();
                t.ContextMenuStrip = new FramPopMenus(t);
                t.ItemAdded += new ToolStripItemEventHandler(ToolStrip_ItemAdded);
                form.Controls.Add(t);
                ToolStrip = t;
                ToolStrip.TabStop = false;
            }

            MenuStrip m = GetMenuStripInControl(form);
            if (m == null)
            {
                MenuStrip = new MenuStrip();
                form.Controls.Add(MenuStrip);
            }
            //  MenuStrip.Name = Functions.GetPBName(this.GetType().Name);
            if (form.IsMdiContainer)
            {
                _m_exit = new ToolStripButton("Exit", null, null, "m_exit");
                _m_exit.ImageTransparentColor = System.Drawing.Color.White;
                _m_exit.Click += new EventHandler(m_exit_clicked);
                if (ToolStrip is StatusStrip)
                {
                }
                else
                {
                    ToolStrip.Items.Add(_m_exit);
                    form.MainMenuStrip = MenuStrip;
                }
            }
            else
            {
                form.MainMenuStrip = MenuStrip;
                MenuStrip.Visible = false;
            }


            //form.MainMenuStrip = MenuStrip;

            m_file = new ToolStripMenuItem();
            m_file.MergeAction = MergeAction.Replace;

            m_edit = new ToolStripMenuItem();
            m_edit.Tag = "ComponentPrivilege=C;ComponentPrivilege=D;ComponentPrivilege=M;";

            m_edit.MergeAction = MergeAction.Replace;

            m_view = new ToolStripMenuItem();
            m_view.MergeAction = MergeAction.Replace;

            m_insert = new ToolStripMenuItem();
            m_insert.MergeAction = MergeAction.Replace;

            m_tools = new ToolStripMenuItem();
            m_tools.MergeAction = MergeAction.Replace;

            m_window = new ToolStripMenuItem();
            m_window.MergeAction = MergeAction.Replace;

            m_help = new ToolStripMenuItem();
            m_help.MergeAction = MergeAction.Replace;


            MenuStrip.Items.Add(m_file);
            MenuStrip.Items.Add(m_edit);
            //? MenuStrip.Items.Add(m_view);
            //? MenuStrip.Items.Add(m_insert);
            //? MenuStrip.Items.Add(m_tools);
            MenuStrip.Items.Add(m_window);
            MenuStrip.Items.Add(m_help);

            #region m_file
            // 
            // m_file
            // 
            m_file.Text = "&File";
            m_new = new ToolStripMenuItem();
            m_open = new ToolStripMenuItem();
            m_close = new ToolStripMenuItem();
            m_dash11 = new ToolStripSeparator();
            m_save = new ToolStripMenuItem();
            m_saveas = new ToolStripMenuItem();
            m_dash12 = new ToolStripSeparator();
            m_print = new ToolStripMenuItem();
            m_printpreview = new ToolStripMenuItem();
            m_pagesetup = new ToolStripMenuItem();
            m_printimmediate = new ToolStripMenuItem();
            m_dash13 = new ToolStripSeparator();
            m_delete = new ToolStripMenuItem();
            m_properties = new ToolStripMenuItem();
            m_dash14 = new ToolStripSeparator();
            m_exit = new ToolStripMenuItem();
            m_pfcmrudash1 = new ToolStripMenuItem();
            m_pfcmru1 = new ToolStripMenuItem();
            m_pfcmru2 = new ToolStripMenuItem();
            m_pfcmru3 = new ToolStripMenuItem();
            m_pfcmru4 = new ToolStripMenuItem();
            m_pfcmru5 = new ToolStripMenuItem();
            m_file.DropDownItems.Add(m_new);
            m_file.DropDownItems.Add(m_open);
            m_file.DropDownItems.Add(m_close);
            m_file.DropDownItems.Add(m_dash11);
            m_file.DropDownItems.Add(m_save);
            m_file.DropDownItems.Add(m_saveas);
            m_file.DropDownItems.Add(m_dash12);
            m_file.DropDownItems.Add(m_print);
            m_file.DropDownItems.Add(m_printpreview);
            m_file.DropDownItems.Add(m_pagesetup);
            m_file.DropDownItems.Add(m_printimmediate);
            m_file.DropDownItems.Add(m_dash13);
            m_file.DropDownItems.Add(m_delete);
            m_file.DropDownItems.Add(m_properties);
            m_file.DropDownItems.Add(m_dash14);
            m_file.DropDownItems.Add(m_exit);
            m_file.DropDownItems.Add(m_pfcmrudash1);
            m_file.DropDownItems.Add(m_pfcmru1);
            m_file.DropDownItems.Add(m_pfcmru2);
            m_file.DropDownItems.Add(m_pfcmru3);
            m_file.DropDownItems.Add(m_pfcmru4);
            m_file.DropDownItems.Add(m_pfcmru5);
            // 
            // m_new
            // 
            m_new.Text = "New";
            m_new.ToolTipText = "New";
           
            // 
            // m_open
            // 
            m_open.Text = "Open";
            m_open.ToolTipText = "Open";
           
            // 
            // m_close
            // 
            m_close.Text = "Close";
            m_close.ToolTipText = "Close";
           
            // 
            // m_dash11
            // 
            m_dash11.Text = "-";
            // 
            // m_save
            // 
            m_save.Text = "Save";
            m_save.ShortcutKeys = Keys.Control | Keys.S;
           
            m_save.ToolTipText = "Save";
           
            // 
            // m_saveas
            // 
            m_saveas.Text = "Save As...";
            m_saveas.ToolTipText = "Save As";
           
            // 
            // m_dash12
            // 
            m_dash12.Text = "-";
            // 
            // m_print
            // 
            m_print.Text = "Print...";
            m_print.ShortcutKeys = Keys.Control | Keys.P;
           
            m_print.ToolTipText = "Prints the item";
            // 
            // m_printpreview
            // 
            m_printpreview.Text = "Print Preview";
            m_printpreview.ToolTipText = "View pages as they will be printed";
           
            // 
            // m_pagesetup
            // 
            m_pagesetup.Text = "Page Setup...";
            m_pagesetup.ToolTipText = "Changes page layout settings";
            // 
            // m_printimmediate
            // 
            m_printimmediate.Visible = false;
            m_printimmediate.Text = "Print Immediate";
            m_printimmediate.ToolTipText = "Prints the item";
           
            // 
            // m_dash13
            // 
            m_dash13.Visible = false;
            m_dash13.Text = "-";
            // 
            // m_delete
            // 
            m_delete.Visible = false;
            m_delete.Text = "Delete";
            m_delete.ShortcutKeys = Keys.Control | Keys.D;
            m_delete.Enabled = false;
           
            m_delete.ToolTipText = "Deletes the item";
           
            // 
            // m_properties
            // 
            m_properties.Visible = false;
            m_properties.Text = "Properties";
            m_properties.Enabled = false;
            m_properties.ToolTipText = "Displays or changes properties of the item";
           
            // 
            // m_dash14
            // 
            m_dash14.Text = "-";
            // 
            // m_exit
            // 
            m_exit.Text = "Exit";
            m_exit.ToolTipText = "Quits the application";
           
            // 
            // m_pfcmrudash1
            // 
            m_pfcmrudash1.Visible = false;
            m_pfcmrudash1.Text = "-";
            // 
            // m_pfcmru1
            // 
            m_pfcmru1.Visible = false;
            m_pfcmru1.Text = "pfcmru1";
            // 
            // m_pfcmru2
            // 
            m_pfcmru2.Visible = false;
            m_pfcmru2.Text = "pfcmru2";
            // 
            // m_pfcmru3
            // 
            m_pfcmru3.Visible = false;
            m_pfcmru3.Text = "pfcmru3";
            // 
            // m_pfcmru4
            // 
            m_pfcmru4.Visible = false;
            m_pfcmru4.Text = "pfcmru4";
            // 
            // m_pfcmru5
            // 
            m_pfcmru5.Visible = false;
            m_pfcmru5.Text = "pfcmru5";

            #endregion

            #region m_edit
            // 
            // m_edit
            // 
            m_edit.Text = "Edit";
            m_edit.Tag = "ComponentPrivilege=C;ComponentPrivilege=D;ComponentPrivilege=M;";
            m_undo = new ToolStripMenuItem();
            m_dash21 = new ToolStripSeparator();

            m_dash21.Tag = "Ignore;";
            m_cut = new ToolStripMenuItem();
            m_copy = new ToolStripMenuItem();
            m_paste = new ToolStripMenuItem();
            m_pastespecial = new ToolStripMenuItem();
            m_clear = new ToolStripMenuItem();
            m_dash22 = new ToolStripSeparator();
            m_dash22.Tag = "Ignore;";

            m_selectall = new ToolStripMenuItem();
            m_dash23 = new ToolStripSeparator();
            m_find = new ToolStripMenuItem();
            m_replace = new ToolStripMenuItem();
            m_dash24 = new ToolStripSeparator();
            m_updatelinks = new ToolStripMenuItem();
            m_object1 = new ToolStripMenuItem();
            m_edit.DropDownItems.Add(m_undo);
            m_edit.DropDownItems.Add(m_dash21);
            m_edit.DropDownItems.Add(m_cut);
            m_edit.DropDownItems.Add(m_copy);
            m_edit.DropDownItems.Add(m_paste);
            m_edit.DropDownItems.Add(m_pastespecial);
            m_edit.DropDownItems.Add(m_clear);
            m_edit.DropDownItems.Add(m_dash22);
            m_edit.DropDownItems.Add(m_selectall);
            m_edit.DropDownItems.Add(m_dash23);
            m_edit.DropDownItems.Add(m_find);
            m_edit.DropDownItems.Add(m_replace);
            m_edit.DropDownItems.Add(m_dash24);
            m_edit.DropDownItems.Add(m_updatelinks);
            m_edit.DropDownItems.Add(m_object1);
            // 
            // m_undo
            // 
            m_undo.Text = "Undo";
            m_undo.ShortcutKeys = Keys.Control | Keys.Z;
           
            m_undo.ToolTipText = "Reverses last action";
           
            // 
            // m_dash21
            // 
            m_dash21.Text = "-";
            // 
            // m_cut
            // 
            m_cut.Text = "Cut";
            m_cut.ShortcutKeys = Keys.Control | Keys.X;
           
            m_cut.ToolTipText = "Moves the selection to the Clipboard";
           
            // 
            // m_copy
            // 
            m_copy.Text = "Copy";
            m_copy.ShortcutKeys = Keys.Control | Keys.C;
           
            m_copy.ToolTipText = "Copies the selection to the Clipboard";
           
            // 
            // m_paste
            // 
            m_paste.Text = "Paste";
            m_paste.ShortcutKeys = Keys.Control | Keys.V;
           
            m_paste.ToolTipText = "Inserts Clipboard contents at current insertion point";
           
            // 
            // m_pastespecial
            // 
            m_pastespecial.Text = "Paste Special...";
            m_pastespecial.ToolTipText = "Inserts the clipboard contents as a link, object, or other format";
            // 
            // m_clear
            // 
            m_clear.Text = "Clear";
            m_clear.ToolTipText = "Removes the selection";
           
            // 
            // m_dash22
            // 
            m_dash22.Text = "-";
            // 
            // m_selectall
            // 
            m_selectall.Text = "Select All";
            m_selectall.ShortcutKeys = Keys.Control | Keys.A;
           
            m_selectall.ToolTipText = "Selects all items or information";
           
            // 
            // m_dash23
            // 
            m_dash23.Text = "-";
            // 
            // m_find
            // 
            m_find.Text = "Find...";
            m_find.ShortcutKeys = Keys.Control | Keys.F;
           
            m_find.ToolTipText = "Finds the specified text";
           
            // 
            // m_replace
            // 
            m_replace.Text = "&Replace...";
            m_replace.ShortcutKeys = Keys.Control | Keys.H;
           
            m_replace.ToolTipText = "Replaces specific text with different text";
           
            // 
            // m_dash24
            // 
            m_dash24.Text = "-";
            // 
            // m_updatelinks
            // 
            m_updatelinks.Text = "Update Links";
            m_updatelinks.ToolTipText = "Allows links to be updated";
            // 
            // m_object1
            // 
            m_object1.Text = "&Object";
            m_object1.ToolTipText = "Contains commands for activating an object";
            m_edit1 = new ToolStripMenuItem();
            m_open1 = new ToolStripMenuItem();
            m_object1.DropDownItems.Add(m_edit1);
            m_object1.DropDownItems.Add(m_open1);
            // 
            // m_edit1
            // 
            m_edit1.Text = "&Edit";
            m_edit1.ToolTipText = "Activates selected object";
            // 
            // m_open1
            // 
            m_open1.Text = "Open";
            m_open1.ToolTipText = "Activates selected object";

            #endregion

            #region m_view
            // 
            // m_view
            // 
            m_view.Text = "View";
            m_ruler = new ToolStripMenuItem();
            m_dash31 = new ToolStripSeparator();
            m_largeicon = new ToolStripMenuItem();
            m_smallicons = new ToolStripMenuItem();
            m_list = new ToolStripMenuItem();
            m_details = new ToolStripMenuItem();
            m_dash32 = new ToolStripSeparator();
            m_arrangeicons = new ToolStripMenuItem();
            m_dash34 = new ToolStripSeparator();
            m_first = new ToolStripMenuItem();
            m_priorpage = new ToolStripMenuItem();
            m_nextpage = new ToolStripMenuItem();
            m_lastpage = new ToolStripMenuItem();
            m_dash35 = new ToolStripSeparator();
            m_sort = new ToolStripMenuItem();
            m_filter = new ToolStripMenuItem();
            m_dash36 = new ToolStripSeparator();
            m_zoom = new ToolStripMenuItem();
            m_view.DropDownItems.Add(m_ruler);
            m_view.DropDownItems.Add(m_dash31);
            m_view.DropDownItems.Add(m_largeicon);
            m_view.DropDownItems.Add(m_smallicons);
            m_view.DropDownItems.Add(m_list);
            m_view.DropDownItems.Add(m_details);
            m_view.DropDownItems.Add(m_dash32);
            m_view.DropDownItems.Add(m_arrangeicons);
            m_view.DropDownItems.Add(m_dash34);
            m_view.DropDownItems.Add(m_first);
            m_view.DropDownItems.Add(m_priorpage);
            m_view.DropDownItems.Add(m_nextpage);
            m_view.DropDownItems.Add(m_lastpage);
            m_view.DropDownItems.Add(m_dash35);
            m_view.DropDownItems.Add(m_sort);
            m_view.DropDownItems.Add(m_filter);
            m_view.DropDownItems.Add(m_dash36);
            m_view.DropDownItems.Add(m_zoom);
            // 
            // m_ruler
            // 
            m_ruler.Text = "Ruler";
            m_ruler.ToolTipText = "Shows or hides the ruler";
            // 
            // m_dash31
            // 
            m_dash31.Text = "-";
            // 
            // m_largeicon
            // 
            m_largeicon.Visible = false;
            m_largeicon.Text = "Large Icons";
            m_largeicon.Enabled = false;
            m_largeicon.ToolTipText = "Displays items by using large icons";
           
            // 
            // m_smallicons
            // 
            m_smallicons.Visible = false;
            m_smallicons.Text = "Small Icons";
            m_smallicons.Enabled = false;
            m_smallicons.ToolTipText = "Displays items by using small icons";
           
            // 
            // m_list
            // 
            m_list.Visible = false;
            m_list.Text = "List";
            m_list.Enabled = false;
            m_list.ToolTipText = "Displays items in a list";
           
            // 
            // m_details
            // 
            m_details.Visible = false;
            m_details.Text = "Details";
            m_details.Enabled = false;
            m_details.ToolTipText = "Displays information about each item";
           
            // 
            // m_dash32
            // 
            m_dash32.Visible = false;
            m_dash32.Text = "-";
            // 
            // m_arrangeicons
            // 
            m_arrangeicons.Visible = false;
            m_arrangeicons.Text = "Arrange &Icons";
            m_arrangeicons.Enabled = false;
            m_arrangeicons.ToolTipText = "Contains commands for arranging items";
            m_by1 = new ToolStripMenuItem();
            m_dash33 = new ToolStripSeparator();
            m_autoarrange = new ToolStripMenuItem();
            m_arrangeicons.DropDownItems.Add(m_by1);
            m_arrangeicons.DropDownItems.Add(m_dash33);
            m_arrangeicons.DropDownItems.Add(m_autoarrange);
            // 
            // m_by1
            // 
            m_by1.Text = "by";
            m_by1.ToolTipText = "Arrange by";
            // 
            // m_dash33
            // 
            m_dash33.Text = "-";
            // 
            // m_autoarrange
            // 
            m_autoarrange.Text = "&Auto Arrange";
            m_autoarrange.ToolTipText = "Arranges the icons automatically";

            // 
            // m_dash34
            // 
            m_dash34.Visible = false;
            m_dash34.Text = "-";
            // 
            // m_first
            // 
            m_first.Text = "&First";
            m_first.ToolTipText = "First";
           
            // 
            // m_priorpage
            // 
            m_priorpage.Text = "&Prior";
            m_priorpage.ToolTipText = "Prior";
           
            // 
            // m_nextpage
            // 
            m_nextpage.Text = "&Next";
            m_nextpage.ToolTipText = "Next";
           
            // 
            // m_lastpage
            // 
            m_lastpage.Text = "L&ast";
            m_lastpage.ToolTipText = "Last";
           
            // 
            // m_dash35
            // 
            m_dash35.Text = "-";
            // 
            // m_sort
            // 
            m_sort.Text = "&Sort...";
            m_sort.ToolTipText = "Sorts items";
            // 
            // m_filter
            // 
            m_filter.Text = "Fil&ter...";
            m_filter.ToolTipText = "Filters items";
            // 
            // m_dash36
            // 
            m_dash36.Text = "-";
            // 
            // m_zoom
            // 
            m_zoom.Text = "&Zoom...";
            m_zoom.ToolTipText = "Scales the display of the print preview";
            #endregion

            #region m_insert
            // 
            // m_insert
            // 
            m_insert.Text = "&Insert";
            m_insertfile = new ToolStripMenuItem();
            m_picture = new ToolStripMenuItem();
            m_dash41 = new ToolStripSeparator();
            m_object = new ToolStripMenuItem();
            m_insert.DropDownItems.Add(m_insertfile);
            m_insert.DropDownItems.Add(m_picture);
            m_insert.DropDownItems.Add(m_dash41);
            m_insert.DropDownItems.Add(m_object);
            // 
            // m_insertfile
            // 
            m_insertfile.Text = "&File...";
            m_insertfile.ToolTipText = "Inserts the text of another file";
            // 
            // m_picture
            // 
            m_picture.Text = "&Picture...";
            m_picture.ToolTipText = "Inserts a picture from a graphics file";
            // 
            // m_dash41
            // 
            m_dash41.Text = "-";
            // 
            // m_object
            // 
            m_object.Text = "&Object...";
            m_object.ToolTipText = "Inserts an object";
            #endregion

            #region m_tools
            // 
            // m_tools
            // 
            m_tools.Text = "&Tools";
            m_toolbars = new ToolStripMenuItem();
            m_tools.DropDownItems.Add(m_toolbars);
            // 
            // m_toolbars
            // 
            m_toolbars.Text = "&Customize Toolbars...";
            m_toolbars.ToolTipText = "Arranges toolbar buttons";
            #endregion

            #region m_window
            // 
            // m_window
            // 
            m_window.Text = "&Window";
            m_cascade = new ToolStripMenuItem();
            m_tilehorizontal = new ToolStripMenuItem();
            m_tilevertical = new ToolStripMenuItem();
            m_layer = new ToolStripMenuItem();
            m_dash51 = new ToolStripSeparator();
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
            m_undoarrange.Enabled = false;
      
            m_undoarrange.ToolTipText = "Undo";
            #endregion

            #region m_help
            // 
            // m_help
            // 
            m_help.Text = "&Help";
            m_helptopics = new ToolStripMenuItem();
            m_dash61 = new ToolStripSeparator();
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

            #endregion
            undoDefine = new UndoDefine(m_undoarrange);
            undoDefine.AddUndoMonitor(m_layer);
            undoDefine.AddUndoMonitor(m_minimizeall);
            undoDefine.AddUndoMonitor(m_tilehorizontal);
            undoDefine.AddUndoMonitor(m_tilevertical);
            undoDefine.AddUndoMonitor(m_cascade);
         

            #region Event Call
            m_new.Click += new EventHandler(m_new_clicked);
            m_open.Click += new EventHandler(m_open_clicked);
            m_close.Click += new EventHandler(m_close_clicked);
            m_save.Click += new EventHandler(m_save_clicked);
            m_saveas.Click += new EventHandler(m_saveas_clicked);
            m_print.Click += new EventHandler(m_print_clicked);
            m_printpreview.Click += new EventHandler(m_printpreview_clicked);
            m_pagesetup.Click += new EventHandler(m_pagesetup_clicked);
            m_printimmediate.Click += new EventHandler(m_printimmediate_clicked);
            m_exit.Click += new EventHandler(m_exit_clicked);

            m_pfcmru1.Click += new EventHandler(m_pfcmru1_clicked);
            m_pfcmru2.Click += new EventHandler(m_pfcmru2_clicked);
            m_pfcmru3.Click += new EventHandler(m_pfcmru3_clicked);
            m_pfcmru4.Click += new EventHandler(m_pfcmru4_clicked);
            m_pfcmru5.Click += new EventHandler(m_pfcmru5_clicked);
            m_undo.Click += new EventHandler(m_undo_clicked);
            m_cut.Click += new EventHandler(m_cut_clicked);
            m_copy.Click += new EventHandler(m_copy_clicked);
            m_paste.Click += new EventHandler(m_paste_clicked);
            m_pastespecial.Click += new EventHandler(m_pastespecial_clicked);
            m_clear.Click += new EventHandler(m_clear_clicked);
            m_selectall.Click += new EventHandler(m_selectall_clicked);
            m_find.Click += new EventHandler(m_find_clicked);
            m_replace.Click += new EventHandler(m_replace_clicked);
            m_updatelinks.Click += new EventHandler(m_updatelinks_clicked);
            m_edit1.Click += new EventHandler(m_edit1_clicked);
            m_open1.Click += new EventHandler(m_open1_clicked);
            m_ruler.Click += new EventHandler(m_ruler_clicked);
            m_first.Click += new EventHandler(m_first_clicked);
            m_priorpage.Click += new EventHandler(m_priorpage_clicked);
            m_nextpage.Click += new EventHandler(m_nextpage_clicked);
            m_lastpage.Click += new EventHandler(m_lastpage_clicked);
            m_sort.Click += new EventHandler(m_sort_clicked);
            m_filter.Click += new EventHandler(m_filter_clicked);
            m_zoom.Click += new EventHandler(m_zoom_clicked);
            m_insertfile.Click += new EventHandler(m_insertfile_clicked);
            m_picture.Click += new EventHandler(m_picture_clicked);
            m_object.Click += new EventHandler(m_object_clicked);
            m_toolbars.Click += new EventHandler(m_toolbars_clicked);
            m_cascade.Click += new EventHandler(m_cascade_clicked);
            m_tilehorizontal.Click += new EventHandler(m_tilehorizontal_clicked);
            m_tilevertical.Click += new EventHandler(m_tilevertical_clicked);
            m_layer.Click += new EventHandler(m_layer_clicked);
            m_minimizeall.Click += new EventHandler(m_minimizeall_clicked);
            m_undoarrange.Click += new EventHandler(m_undoarrange_clicked);
            m_helptopics.Click += new EventHandler(m_helptopics_clicked);
            m_about.Click += new EventHandler(m_about_clicked);

            #endregion
        }

        protected virtual void AddMenuItemEnableEvent()
        {
            foreach (ToolStripMenuItem menuItem in MenuStrip.Items)
            {
                AddMenuItemEnableEvent(menuItem);
            }
        }

        private void AddMenuItemEnableEvent(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripItem subMenuItem in menuItem.DropDownItems)
            {
                if (subMenuItem is ToolStripMenuItem)
                {
                    AddMenuItemEnableEvent((ToolStripMenuItem)subMenuItem);
                }
            }
            if (ToolStrip.Items[menuItem.Name] != null)
            {
                menuItem.EnabledChanged += new EventHandler(MenuItemEnabledChanged);
            }
        }

        void ToolStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            ToolStripMenuItem showText = ((FramPopMenus)ToolStrip.ContextMenuStrip).Items["showTextToolStripMenuItem"] as ToolStripMenuItem;
            if (showText != null)
            {
                if (showText.CheckState == CheckState.Checked)
                {
                    e.Item.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                }
                else
                {
                    e.Item.DisplayStyle = ToolStripItemDisplayStyle.Image;
                }
            }
            e.Item.TextImageRelation = TextImageRelation.ImageAboveText;
        }

        protected virtual void MenuItemEnabledChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if (ToolStrip.Items[menuItem.Name] != null)
            {
                ToolStrip.Items[menuItem.Name].Enabled = menuItem.Enabled;
            }
        }

        public virtual int of_sendmessage(string as_message)
        {
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
            //!  NCstMenu lnv_menu;
            //!  return lnv_menu.of_sendmessage(this, as_message);
            return 1;//temporary variable
        }

        #region Remark
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
        //    as_title = f_Translate(as_title, '&', "");
        //    //?StaticVariables.gnv_app.of_get_parameters().StringParm = as_datawindow;
        //    // Find the window
        //    //?lw_searchwindow = StaticVariables.gnv_app.of_findwindow(as_title, as_classname);
        //    // none found
        //    if (!(IsValid(lw_searchwindow)))
        //    {
        //        //?OpenSheetWithParm(lw_window, as_title, as_classname, StaticVariables.gnv_app.of_getframe(), 0, original!);
        //        return 1;
        //    }
        //    else if (as_datawindow.Len() == 0)
        //    {
        //        return 1;
        //    }
        //    // found - so check the dws
        //    while (IsValid(lw_searchwindow))
        //    {
        //        if (as_datawindow.Len() > 0)
        //        {
        //            // check the dw name
        //            ls_wdw = lw_searchwindow.ue_get_dw();
        //            // found - it's already on top
        //            if (as_datawindow == ls_wdw)
        //            {
        //                return 1;
        //            }
        //            // Not found, get next window
        //            //? lw_searchwindow = StaticVariables.gnv_app.of_findwindow(as_title, as_classname, lw_searchwindow);
        //            // not same dw - open it
        //            if (!(IsValid(lw_searchwindow)))
        //            {
        //                //?OpenSheetWithParm(lw_window, as_title, as_classname, StaticVariables.gnv_app.of_getframe(), 0, original!);
        //                return 1;
        //            }?
        //        }?
        //    }?
        //    // None found - open something
        //    OpenSheetWithParm(lw_window, as_title, as_classname, StaticVariables.gnv_app.of_getframe(), 0, original!);
        //    return 1;
        //}

        #endregion

        #region Event

        public virtual void m_new_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_new");
        }

        public virtual void m_open_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_open");
        }

        public virtual void m_close_clicked(object sender, EventArgs e)
        {
            //?of_sendmessage("pfc_close");
            if (!this._form.FindForm().IsMdiContainer)
            {
                this._form.FindForm().Close();
            }
            else
                this._form.Close();
        }

        public virtual void m_save_clicked(object sender, EventArgs e)
        {
            //of_sendmessage("pfc_save");
        }

        public virtual void m_saveas_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_saveas");
        }

        public virtual void m_print_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //of_sendmessage("pfc_print");
            PrintDocument printDoc = new PrintDocument();
            printDoc.Print();

        }

        public virtual void m_printpreview_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_printpreview");
        }

        public virtual void m_pagesetup_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_pagesetup");
        }

        public virtual void m_printimmediate_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_printimmediate");
        }

        public virtual void m_exit_clicked(object sender, EventArgs e)
        {
            DialogResult dRst = DialogResult.None;
            dRst = MessageBox.Show("Are you sure you want to exit", StaticVariables.DisplayName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dRst == DialogResult.Yes)
            {
                // TJB  Feb 2016
                // Commented out closing each form separately
                // - File-->Exit under Windows 10 didn't close properly
                //    - Got message that app "stopped" and OS was looking for the reason
                //    - System.Environment.Exit(0) closes all forms anyway
            //    if (StaticVariables.MainMDI.ActiveMdiChild != null)
            //    {
            //        foreach (Form frm in StaticVariables.MainMDI.MdiChildren)
            //        {
            //            frm.Close();
            //        }
            //    }
                System.Environment.Exit(0);
            }
        }

        public virtual void m_pfcmru1_clicked(object sender, EventArgs e)
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:		Clicked
            // 
            // 	Arguments:	None
            // 
            // 	Returns:		None
            // 
            // 	Description:
            // 	Send menu item text from menu to event on window
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	6.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright ?1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            //! app.message.StringParm = m_pfcmru1.Text;
            of_sendmessage("pfc_mruclicked");
        }

        public virtual void m_pfcmru2_clicked(object sender, EventArgs e)
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:		Clicked
            // 
            // 	Arguments:	None
            // 
            // 	Returns:		None
            // 
            // 	Description:
            // 	Send menu item text from menu to event on window
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	6.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright ?1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            //!  app.message.StringParm = m_pfcmru2.Text;
            of_sendmessage("pfc_mruclicked");
        }

        public virtual void m_pfcmru3_clicked(object sender, EventArgs e)
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:		Clicked
            // 
            // 	Arguments:	None
            // 
            // 	Returns:		None
            // 
            // 	Description:
            // 	Send menu item text from menu to event on window
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	6.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright ?1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            //!  app.message.StringParm = m_pfcmru3.Text;
            of_sendmessage("pfc_mruclicked");
        }

        public virtual void m_pfcmru4_clicked(object sender, EventArgs e)
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:		Clicked
            // 
            // 	Arguments:	None
            // 
            // 	Returns:		None
            // 
            // 	Description:
            // 	Send menu item text from menu to event on window
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	6.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright ?1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            //!  app.message.StringParm = m_pfcmru4.Text;
            of_sendmessage("pfc_mruclicked");
        }

        public virtual void m_pfcmru5_clicked(object sender, EventArgs e)
        {
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Event:		Clicked
            // 
            // 	Arguments:	None
            // 
            // 	Returns:		None
            // 
            // 	Description:
            // 	Send menu item text from menu to event on window
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Revision History
            // 
            // 	Version
            // 	6.0   Initial version
            // 
            // ////////////////////////////////////////////////////////////////////////////
            // 
            // 	Copyright ?1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
            // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
            // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
            // 
            // ////////////////////////////////////////////////////////////////////////////
            //!  app.message.StringParm = m_pfcmru5.Text;
            of_sendmessage("pfc_mruclicked");
        }

        public virtual void m_undo_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_undo");
        }

        public virtual void m_cut_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_cut");
        }

        public virtual void m_copy_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_copy");
        }

        public virtual void m_paste_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_paste");
        }

        public virtual void m_pastespecial_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_pastespecial");
        }

        public virtual void m_clear_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_clear");
        }

        public virtual void m_selectall_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_selectall");
        }

        public virtual void m_find_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_finddlg");
        }

        public virtual void m_replace_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_replacedlg");
        }

        public virtual void m_updatelinks_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_updatelinks");
        }

        public virtual void m_edit1_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_editobject");
        }

        public virtual void m_open1_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_openobject");
        }

        public virtual void m_ruler_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_ruler");
        }

        public virtual void m_first_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_firstpage");
        }

        public virtual void m_priorpage_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_previouspage");
        }

        public virtual void m_nextpage_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_nextpage");
        }

        public virtual void m_lastpage_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_lastpage");
        }

        public virtual void m_sort_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_sortdlg");
        }

        public virtual void m_filter_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_filterdlg");
        }

        public virtual void m_zoom_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_zoom");
        }

        public virtual void m_insertfile_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_insertfile");
        }

        public virtual void m_picture_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_insertpicture");
        }

        public virtual void m_object_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_insertobject");
        }

        public virtual void m_toolbars_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            of_sendmessage("pfc_toolbars");
        }

        public virtual void m_window_selected()
        {
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
            //object la_rc;
            //bool lb_normal;
            //int li_rc;
            //int li_sheetcount;
            //int li_cnt = 1;
            //arrangetypes le_arrange;
            //NCstMenu lnv_menu;
            //Form lw_obj;
            //FormArray lw_sheet = new FormArray();
            //WFrame lw_frame;
            ////  Get frame window
            //li_rc = lnv_menu.of_getmdiframe(m_window, lw_obj);
            //if (li_rc < 0) {
            //    return;
            //}
            ////  Determine if frame is a PFC frame descendant
            //la_rc = lw_obj.pfc_descendant();
            //if (IsNull(la_rc)) {
            //    return;
            //}
            //lw_frame = lw_obj;
            ////  If sheetmanager service is enabled, allow for undo and minimize capabilities
            //if (IsValid(lw_frame.inv_sheetmanager)) {
            //    //  First determine if there are any nonminimized sheets open
            //    li_sheetcount = lw_frame.inv_sheetmanager.of_getsheets(lw_sheet);
            //    while (li_cnt <= li_sheetcount && !lb_normal) {
            //        if (lw_sheet[li_cnt].WindowState != minimized!) {
            //            lb_normal = true;
            //        }
            //        li_cnt++;
            //    }
            //    m_window.m_undoarrange.enabled = true;
            //    m_window.m_minimizeall.enabled = lb_normal;
            //    m_window.m_cascade.enabled = lb_normal;
            //    m_window.m_layer.enabled = lb_normal;
            //    m_window.m_tilehorizontal.enabled = lb_normal;
            //    m_window.m_tilevertical.enabled = lb_normal;
            //    //  Get current arrange state of windows and set undo text
            //    le_arrange = lw_frame.inv_sheetmanager.of_getcurrentstate();
            //    // PowerBuilder 'Choose Case' statement converted into 'if' statement
            //    arrangetypes TestExpr = le_arrange;
            //    if (TestExpr == tile!) {
            //        m_window.m_undoarrange.text = "&Undo Tile Vertical";
            //        m_window.m_undoarrange.microhelp = "Undoes vertical tile arrangement of windows";
            //    }
            //    else if (TestExpr == tilehorizontal!) {
            //        m_window.m_undoarrange.text = "&Undo Tile Horizontal";
            //        m_window.m_undoarrange.microhelp = "Undoes horizontal tile arrangement of windows";
            //    }
            //    else if (TestExpr == cascade!) {
            //        m_window.m_undoarrange.text = "&Undo Cascade";
            //        m_window.m_undoarrange.microhelp = "Undoes cascaded arrangement of windows";
            //    }
            //    else if (TestExpr == layer!) {
            //        m_window.m_undoarrange.text = "&Undo Layer";
            //        m_window.m_undoarrange.microhelp = "Undoes layered arrangement of windows";
            //    }
            //    else if (TestExpr == icons!) {
            //        m_window.m_undoarrange.text = "&Undo Minimize All";
            //        m_window.m_undoarrange.microhelp = "Undoes minimization of windows";
            //    }
            //    else {
            //        m_window.m_undoarrange.enabled = false;
            //        m_window.m_undoarrange.text = "&Undo";
            //        m_window.m_undoarrange.microhelp = "Undo";
            //    }
            //}
            //else {
            //    m_window.m_minimizeall.enabled = false;
            //    m_window.m_undoarrange.enabled = false;
            //}
        }

        public virtual void m_cascade_clicked(object sender, EventArgs e)
        {
            // of_sendmessage("pfc_cascade");
            StaticVariables.MainMDI.FindForm().LayoutMdi(MdiLayout.Cascade);
        }

        public virtual void m_tilehorizontal_clicked(object sender, EventArgs e)
        {
            //of_sendmessage("pfc_tilehorizontal");
            StaticVariables.MainMDI.LayoutMdi(MdiLayout.TileHorizontal);
        }

        public virtual void m_tilevertical_clicked(object sender, EventArgs e)
        {
            //of_sendmessage("pfc_tilevertical");
            StaticVariables.MainMDI.LayoutMdi(MdiLayout.TileVertical);
        }

        public virtual void m_layer_clicked(object sender, EventArgs e)
        {
            //of_sendmessage("pfc_layer");
            if (StaticVariables.MainMDI.ActiveMdiChild != null)
            {
                StaticVariables.MainMDI.ActiveMdiChild.WindowState = FormWindowState.Normal;
                StaticVariables.MainMDI.ActiveMdiChild.Location = new System.Drawing.Point(0, 0);
                foreach (Control control in StaticVariables.MainMDI.Controls)
                {
                    if (control as MdiClient != null)
                    {
                        StaticVariables.MainMDI.ActiveMdiChild.Size = control.Size;
                        break;
                    }
                }
            }
        }

        public virtual void m_minimizeall_clicked(object sender, EventArgs e)
        {
            //of_sendmessage("pfc_minimizeall");
            foreach (Form frm in StaticVariables.MainMDI.MdiChildren)
            {
                frm.WindowState = FormWindowState.Minimized;
            }
        }

        public virtual void m_undoarrange_clicked(object sender, EventArgs e)
        {
            //?of_sendmessage("pfc_undoarrange");
            m_cascade.Enabled = true;
            m_tilevertical.Enabled = true;
            m_tilehorizontal.Enabled = true;
            m_layer.Enabled = true;
            m_undoarrange.Text = "&Undo";
            m_undoarrange.Enabled = false;
        }

        public virtual void m_helptopics_clicked(object sender, EventArgs e)
        {
            of_sendmessage("pfc_help");
        }

        public virtual void m_about_clicked(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            //! gnv_app.of_about();
        }

        #endregion

        public static T OpenSheet<T>(Form parent) where T : FormBase
        {
            if (!parent.IsMdiContainer)
                parent = parent.FindForm().MdiParent;

            T instance = Activator.CreateInstance<T>();
            foreach (Form frm in parent.MdiChildren)
            {
                if (instance.GetType() == frm.GetType())
                {
                    frm.Activate();
                    return instance;
                }
            }
            instance.MdiParent = parent;
            instance.Show();
            return instance;
        } 
        
        protected UndoDefine undoDefine;

        protected class UndoDefine
        {
            private ToolStripItem item;
            private ToolStripItem undoitem;

            private Hashtable statusList;

            public class WindowStatus
            {
                private Point Location;
                private Size Size;
                private FormWindowState State;
                private bool Active;
                public WindowStatus()
                {
                }

                public void SaveStatus(Form form)
                {
                    Location = form.Location;
                    Size = form.Size;
                    State = form.WindowState;
                    Active = form.MdiParent.ActiveMdiChild == form;
                }

                public void ReloadStatus(Form form)
                {
                    form.Location = Location;
                    form.Size = Size;
                    form.WindowState = State;
                    if (Active)
                        form.Activate();
                }
            }

            public UndoDefine(ToolStripItem undoitem)
            {
                statusList = new Hashtable();
                this.undoitem = undoitem;
                undoitem.Click += new EventHandler(undoitem_Click);
            }

            public void AddUndoMonitor(ToolStripItem saveItem)
            {
                saveItem.Click += new EventHandler(saveItem_Click);
            }

            void saveItem_Click(object sender, EventArgs e)
            {
                changeText(sender as ToolStripItem);
                saveStatus();
            }

            void undoitem_Click(object sender, EventArgs e)
            {
                changeText(null);
                reloadStatus();
            }

            private void changeText(ToolStripItem saveItem)
            {
                item = saveItem;

                if (item == null)
                {
                    undoitem.Text = "Undo";
                    undoitem.Enabled = false;
                }
                else
                {
                    undoitem.Text = "Undo " + item.Text;
                    undoitem.Enabled = true;
                }
            }

            private void saveStatus()
            {
                foreach (Form form in StaticVariables.MainMDI.MdiChildren)
                {
                    WindowStatus ws = new WindowStatus();
                    ws.SaveStatus(form);
                    statusList[form] = ws;
                }
            }

            private void reloadStatus()
            {
                foreach (Form form in StaticVariables.MainMDI.MdiChildren)
                {
                    WindowStatus ws = statusList[form] as WindowStatus;
                    if (ws != null)
                    {
                        ws.ReloadStatus(form);
                    }
                }
            }
        }
    }
}
