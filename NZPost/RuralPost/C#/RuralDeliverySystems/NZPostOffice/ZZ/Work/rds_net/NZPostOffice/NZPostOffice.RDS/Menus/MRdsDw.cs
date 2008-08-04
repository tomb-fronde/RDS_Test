using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using Metex.Windows;

namespace NZPostOffice.RDS.Menus
{
    //public interface IWMaster
    //{
    //    void pfc_insertrow();
    //    void pfc_deleterow();
    //    void pfc_save();
    //}

    class MRdsDw : NZPostOffice.Shared.VisualComponents.MDw
    {

        private URdsDw udw;

        public MRdsDw(URdsDw _udw)
        {
            this.InitializeComponent();
            udw = _udw;
        }

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public ToolStripMenuItem m_savechangestodatabase;

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
            // 
            // m_table
            // 
            m_savechangestodatabase = new ToolStripMenuItem();
            this.Items.Add(m_savechangestodatabase);
            // 
            // m_cut
            // 
            m_cut.Visible = false;
            m_cut.Enabled = false; //true;;;

            // 
            // m_copy
            // 
            m_copy.Visible = false;
            m_copy.Enabled = false; //true;
            // 
            // m_paste
            // 
            m_paste.Visible = false;
            m_paste.Enabled = false; //true;; 
            // 
            // m_selectall
            // 

            m_selectall.Visible = false; //true;;
            // 
            // m_dash11
            // 
            m_dash11.Visible = false;
            // 
            // m_insert
            // 
            m_insert.Visible = false;
            m_insert.Text = "&Insert Row";
            // 
            // m_addrow
            // 
            m_addrow.Visible = false;
            // 
            // m_delete
            // 
            m_delete.Visible = false;
            m_delete.Text = "&Delete Row";
            // 
            // m_restorerow
            // 
            // 
            // m_dash12
            // 
            // 
            // m_columns
            // 
            // 
            // m_functions
            // 
            // 
            // m_operators
            // 
            // 
            // m_values
            // 
            // 
            // m_dash13
            // 
            // 
            // m_debug
            // 
            // 
            // m_properties
            // 
            // 
            // m_savechangestodatabase
            // 
            m_savechangestodatabase.Visible = false;
            m_savechangestodatabase.Text = "&Save Changes to Database";
            m_savechangestodatabase.Enabled = false;
            m_savechangestodatabase.ToolTipText = "[m_rds_dw.table] ";
            m_savechangestodatabase.Click += new EventHandler(m_savechangestodatabase_clicked);
        }

        public override void m_selectall_clicked(object sender, EventArgs e)
        {
           int i= udw.SelectAllRows(true);


           //int retVal = -1;
           //if (udw.DataObject.Controls.Count > 0 && udw.DataObject.Controls[0] != null)
           //{
           //    if (udw.DataObject.Controls[0] is DataEntityGrid)  //bug:may be is not the fist control
           //    {
           //        if (((DataEntityGrid)udw.DataObject.Controls[0]).Rows.Count > 0)
           //        {
           //            foreach (DataGridViewRow rowItem in ((DataEntityGrid)udw.DataObject.Controls[0]).Rows)
           //            {
           //                rowItem.Selected = true;
           //            }
           //            retVal = 1;
           //        }
           //    }
           //}

        }

        public override void m_insert_clicked(object sender, EventArgs e)
        {

            udw.PfcInsertRow();
        }

        public override void m_delete_clicked(object sender, EventArgs e)
        {
            udw.PfcDeleteRow();
        }

        public virtual void m_savechangestodatabase_clicked(object sender, EventArgs e)
        {
            udw.Save();
        }
    }
}
