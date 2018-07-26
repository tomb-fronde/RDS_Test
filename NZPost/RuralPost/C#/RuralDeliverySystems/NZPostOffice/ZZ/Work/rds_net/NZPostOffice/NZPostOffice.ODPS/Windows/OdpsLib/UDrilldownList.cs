using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    // TJB  RPCR_113  July 2018:  Cosmetic
    // Various commented-out code snippets removed
    // dw_selection.doubleClick reference moved from designer
    // as part of CR code development/testing

    // TJB  RPCR_054  July-2013
    // Added cb_save

    //declare delegate for insert delete 
    public delegate void EventDelegate();

    public partial class UDrilldownList : Panel
    {
        public UDrilldownList()
        {
            InitializeComponent();
            dw_selection.DoubleClick += new EventHandler(dw_selection_doubleclicked);
        }

        public UDrilldownList(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public virtual void constructor()
        {
            cb_open.Left = Width - 60 - cb_open.Width;
            cb_open.Top = 40;
            cb_new.Left = cb_open.Left;
            cb_new.Top = cb_open.Top + cb_open.Height + 40;
            cb_delete.Left = cb_open.Left ;
            cb_delete.Top  = cb_new.Top + cb_new.Height + 40;
            cb_save.Left = cb_open.Left;
            cb_save.Top = cb_delete.Top + cb_delete.Height + 40;
            dw_selection.Left = 40;
            dw_selection.Top  = 40;
            dw_selection.Width = cb_open.Left - 80;
            dw_selection.Height = Height - 100;
        }

        public virtual void cb_open_clicked(object sender, EventArgs e)
        {
            //MessageBox.Show("cb_open_clicked","UDrilldownList");
            this.ue_open();
        }
        public virtual void ue_open()
        {

        }
        
        public virtual void cb_new_clicked(object sender, EventArgs e)
        {
            //MessageBox.Show("cb_new_clicked", "UDrilldownList");
            this.ue_new();
        }

        public virtual void ue_new()
        {
        }

        public virtual void cb_delete_clicked(object sender, EventArgs e)
        {
            //MessageBox.Show("cb_delete_clicked", "UDrilldownList");
            ue_delete();
        }

        public virtual void ue_delete()
        {
            DialogResult dlg;
            dlg = MessageBox.Show("Are you sure you want to delete this row?"
                                  , "Confirm Delete"
                                  , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
                this.dw_selection.DeleteItemAt(this.dw_selection.GetRow());
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            this.ue_save();
        }
        
        public virtual void ue_save()
        {
        }

        public virtual void dw_selection_doubleclicked(object sender, EventArgs e)
        {
            //MessageBox.Show("UDrillDownList.dw_selection_doubleclicked");
        }

        public virtual void dw_selection_constructor()
        {
        }

        public virtual void pfc_retrieve()
        {
        }

        //?public virtual void dw_selection_dberror(object sender, DbEventArgs e)
        //{
        //    if (sqldbcode == -(198))
        //    {
        //        MessageBox.Show("Cannot delete the row as it is referenced in another table.", "Error");
        //        return 1;
        //    }
        //    else
        //    {
        //        base.dberror();
        //    }
        //}

      
    }
}
