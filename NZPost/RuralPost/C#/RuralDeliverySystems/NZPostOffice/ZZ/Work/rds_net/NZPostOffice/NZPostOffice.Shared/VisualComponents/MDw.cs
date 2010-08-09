namespace NZPostOffice.Shared.VisualComponents
{
    using System;
    using System.Windows.Forms;

    // PFC datawindow menu class
    public class MDw : ContextMenuStrip
    {
        // TJB  Release 7.1.3 fixups Aug 2010
        // Added m_modify and m_modify_clicked
        
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        /// Reference to the menu functions

        public ToolStripMenuItem m_table;

        public ToolStripMenuItem m_cut;

        public ToolStripMenuItem m_copy;

        public ToolStripMenuItem m_paste;

        public ToolStripMenuItem m_selectall;

        public ToolStripSeparator m_dash11;

        public ToolStripMenuItem m_insert;

        public ToolStripMenuItem m_modify;

        public ToolStripMenuItem m_addrow;

        public ToolStripMenuItem m_delete;

        public ToolStripMenuItem m_restorerow;

        public ToolStripSeparator m_dash12;

        public ToolStripMenuItem m_columns;

        public ToolStripMenuItem m_functions;

        public ToolStripMenuItem m_operators;

        public ToolStripMenuItem m_values;

        public ToolStripSeparator m_dash13;

        public ToolStripMenuItem m_debug;

        public ToolStripMenuItem m_properties;

        public MDw()
        {
            this.InitializeComponent();
        }

        //!public Controls.UDw idw_parent;
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //m_table = new ToolStripMenuItem();
            //Items.Add(m_table);
            // 
            // m_table
            // 
            //m_table.Text = "&Table";
            m_cut = new ToolStripMenuItem();
            m_copy = new ToolStripMenuItem();
            m_paste = new ToolStripMenuItem();
            m_selectall = new ToolStripMenuItem();
            m_dash11 = new ToolStripSeparator();
            m_insert = new ToolStripMenuItem();
            m_modify = new ToolStripMenuItem();
            m_addrow = new ToolStripMenuItem();
            m_delete = new ToolStripMenuItem();
            m_restorerow = new ToolStripMenuItem();
            m_dash12 = new ToolStripSeparator();
            m_columns = new ToolStripMenuItem();
            m_functions = new ToolStripMenuItem();
            m_operators = new ToolStripMenuItem();
            m_values = new ToolStripMenuItem();
            m_dash13 = new ToolStripSeparator();
            m_debug = new ToolStripMenuItem();
            m_properties = new ToolStripMenuItem();
            Items.Add(m_cut);
            Items.Add(m_copy);
            Items.Add(m_paste);
            Items.Add(m_selectall);
            Items.Add(m_dash11);
            Items.Add(m_insert);
            Items.Add(m_modify);
            Items.Add(m_addrow);
            Items.Add(m_delete);
            Items.Add(m_restorerow);
            Items.Add(m_dash12);
            Items.Add(m_columns);
            Items.Add(m_functions);
            Items.Add(m_operators);
            Items.Add(m_values);
            Items.Add(m_dash13);
            Items.Add(m_debug);
            Items.Add(m_properties);
            // 
            // m_cut
            // 
            m_cut.Text = "C&ut";
            m_cut.ToolTipText = "Moves the selection to the Clipboard";
            m_cut.Enabled = false;
            // 
            // m_copy
            // 
            m_copy.Text = "&Copy";
            m_copy.ToolTipText = "Copies the selection to the Clipboard";
            m_copy.Enabled = false;
            // 
            // m_paste
            // 
            m_paste.Text = "&Paste";
            m_paste.ToolTipText = "Inserts Clipboard contents at current insertion point";
            m_paste.Enabled = false;
            // 
            // m_selectall
            // 
            m_selectall.Text = "Select A&ll";
            m_selectall.ToolTipText = "Selects all items or information";
            m_selectall.Enabled = false;
            // 
            // m_dash11
            // 
            m_dash11.Text = "-";
            // 
            // m_insert
            // 
            m_insert.Text = "&Insert";
            m_insert.ToolTipText = "Inserts a new row";
            m_insert.Enabled = false;
            m_insert.ShortcutKeys = (Keys)Shortcut.CtrlIns;
            // 
            // m_modify
            // 
            m_modify.Text = "&Update";
            m_modify.ToolTipText = "Update a row";
            m_modify.Enabled = false;
            m_modify.Visible = false;
            //m_modify.ShortcutKeys = (Keys)Shortcut.CtrlIns;
            // 
            // m_addrow
            // 
            m_addrow.Text = "&Add";
            m_addrow.ToolTipText = "Adds a new row to the end";
            m_addrow.Enabled = false;
            // 
            // m_delete
            // 
            m_delete.Text = "&Delete";
            m_delete.ToolTipText = "Deletes selected rows";
            m_delete.Enabled = false;
            m_delete.ShortcutKeys = (Keys)Shortcut.CtrlDel;
            // 
            // m_restorerow
            // 
            m_restorerow.Text = "Re&store...";
            m_restorerow.ToolTipText = "Restores rows that have been deleted";
            m_restorerow.Visible = false;
            m_restorerow.Enabled = false;
            // 
            // m_dash12
            // 
            m_dash12.Text = "-";
            m_dash12.Visible = false;
            // 
            // m_columns
            // 
            m_columns.Text = "C&olumns...";
            m_columns.ToolTipText = "Select from a list of available column names";
            m_columns.Visible = false;
            m_columns.Enabled = false;
            // 
            // m_functions
            // 
            m_functions.Text = "&Functions...";
            m_functions.ToolTipText = "Select from a list of available functions";
            m_functions.Visible = false;
            m_functions.Enabled = false;
            // 
            // m_operators
            // 
            m_operators.Text = "Op&erators...";
            m_operators.ToolTipText = "Select from a list of available operators";
            m_operators.Visible = false;
            m_operators.Enabled = false;
            // 
            // m_values
            // 
            m_values.Text = "&Values...";
            m_values.ToolTipText = "Select from a list of available values";
            m_values.Visible = false;
            m_values.Enabled = false;
            // 
            // m_dash13
            // 
            m_dash13.Text = "-";
            m_dash13.Visible = false;
            // 
            // m_debug
            // 
            m_debug.Text = "Data&Window Properties...";
            m_debug.ToolTipText = "Displays or changes properties of the DataWindow";
            m_debug.Visible = false;
            m_debug.Enabled = false;
            // 
            // m_properties
            // 
            m_properties.Text = "P&roperties";
            m_properties.ToolTipText = "Displays or changes properties of the item";
            m_properties.Visible = false;
            m_properties.Enabled = false;
            m_cut.Click += new EventHandler(m_cut_clicked);
            m_copy.Click += new EventHandler(m_copy_clicked);
            m_paste.Click += new EventHandler(m_paste_clicked);
            m_selectall.Click += new EventHandler(m_selectall_clicked);
            m_insert.Click += new EventHandler(m_insert_clicked);
            m_modify.Click += new EventHandler(m_modify_clicked);
            m_addrow.Click += new EventHandler(m_addrow_clicked);
            m_delete.Click += new EventHandler(m_delete_clicked);
            m_restorerow.Click += new EventHandler(m_restorerow_clicked);
            m_columns.Click += new EventHandler(m_columns_clicked);
            m_functions.Click += new EventHandler(m_functions_clicked);
            m_operators.Click += new EventHandler(m_operators_clicked);
            m_values.Click += new EventHandler(m_values_clicked);
            m_debug.Click += new EventHandler(m_debug_clicked);
        }

        //!public virtual int of_setparent(Controls.UDw adw_parent)
        //{
        //    // ////////////////////////////////////////////////////////////////////////////
        //    // 
        //    // 	Function:  of_SetParent
        //    // 
        //    // 	Access:  public
        //    // 
        //    // 	Arguments:
        //    // 	adw_parent   parent object of the menu
        //    // 
        //    // 	Returns:  integer
        //    // 	 1 = success
        //    // 	-1 = failure, parent reference is not valid
        //    // 
        //    // 	Description:  Sets the parent object of this menu
        //    // 
        //    // ////////////////////////////////////////////////////////////////////////////
        //    // 
        //    // 	Revision History
        //    // 
        //    // 	Version
        //    // 	5.0   Initial version
        //    // 
        //    // ////////////////////////////////////////////////////////////////////////////
        //    // 
        //    // 	Copyright © 1996-1997 Sybase, Inc. and its subsidiaries.  All rights reserved.
        //    // 	Any distribution of the PowerBuilder Foundation Classes  ( PFC)
        //    // 	source code by other than Sybase, Inc. and its subsidiaries is prohibited.
        //    // 
        //    // ////////////////////////////////////////////////////////////////////////////
        //    //int li_rc = 1;
        //    //if (IsValid(adw_parent))
        //    //{
        //    //    idw_parent = adw_parent;
        //    //}
        //    //else
        //    //{
        //    //    li_rc = -(1);
        //    //}
        //    //return li_rc;
        //    idw_parent = adw_parent;
        //    if (adw_parent.DataControl is DataGridUserControl)
        //    {
        //        ((DataGridUserControl)adw_parent.DataControl).DataGrid.ContextMenuStrip = this;
        //    }
        //    else
        //    {
        //        adw_parent.DataControl.ContextMenuStrip = this;
        //    }
        //    return 1;
        //}

        public virtual void m_cut_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_cut();

        }

        public virtual void m_copy_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_copy();
        }

        public virtual void m_paste_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_paste();
        }

        public virtual void m_selectall_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_selectall();
        }

        public virtual void m_insert_clicked(object sender, EventArgs e)
        {
            //idw_parent.pfc_insertrow();
            //!idw_parent.InsertRow(0);
        }

        public virtual void m_modify_clicked(object sender, EventArgs e)
        {
            //idw_parent.pfc_insertrow();
            //!idw_parent.InsertRow(0);
        }

        public virtual void m_addrow_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_addrow();
        }

        public virtual void m_delete_clicked(object sender, EventArgs e)
        {
            //idw_parent.pfc_deleterow();
            //!idw_parent.DeleteRow(idw_parent.GetRow());
        }

        public virtual void m_restorerow_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_restorerow();
        }

        public virtual void m_columns_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_columns();
        }

        public virtual void m_functions_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_functions();
        }

        public virtual void m_operators_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_operators();
        }

        public virtual void m_values_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_values();
        }

        public virtual void m_debug_clicked(object sender, EventArgs e)
        {
            //!idw_parent.pfc_debug();
        }
    }
}
