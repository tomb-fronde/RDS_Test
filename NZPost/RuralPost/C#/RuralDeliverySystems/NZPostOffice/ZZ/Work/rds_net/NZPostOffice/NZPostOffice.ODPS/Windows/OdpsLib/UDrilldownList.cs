using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    //declare delegate for insert delete 
    public delegate void EventDelegate();

    public partial class UDrilldownList : Panel
    {
        public UDrilldownList()
        {
            InitializeComponent();
        }

        public UDrilldownList(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public virtual void ue_new()
        {
            //?dw_selection.triggerevent("pfc_AddRow");
            //?dw_selection.Focus();
        }

        public virtual void ue_delete()
        {
            //?dw_selection.triggerevent("pfc_DeleteRow");
            //?dw_selection.Focus();
            DialogResult dlg;
            dlg = MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
                this.dw_selection.DeleteItemAt(this.dw_selection.GetRow());
        }

        public virtual void constructor()
        {
            cb_open.Left = Width - 60 - cb_open.Width;
            cb_open.Top = 40;
            cb_new.Left = cb_open.Left;
            cb_new.Top = cb_open.Top + cb_open.Height + 40;
            cb_delete.Left = cb_open.Left ;
            cb_delete.Top  = cb_new.Top + cb_new.Height + 40;
            dw_selection.Left = 40;
            dw_selection.Top  = 40;
            dw_selection.Width = cb_open.Left - 80;
            dw_selection.Height = Height - 100;
        }

        public virtual void cb_open_clicked(object sender, EventArgs e)
        {
            //?base.clicked();
            //?parent.TriggerEvent("ue_open");
            this.ue_open();
        }
        public virtual void ue_open()
        {

        }
        
        public virtual void cb_new_clicked(object sender, EventArgs e)
        {
            //base.clicked();
            //parent.TriggerEvent("ue_new");
            this.ue_new();
        }

        public virtual void cb_delete_clicked(object sender, EventArgs e)
        {
            //?base.clicked();
            //dw_selection.triggerevent("pfc_deleterow");
            ue_delete();
        }
 
        public virtual void dw_selection_doubleclicked(object sender, EventArgs e)
        {
            //?base.doubleclicked();
            //?parent.TriggerEvent("ue_open");
        }

        public virtual void dw_selection_constructor()
        {
            //?base.constructor();
            // 	HELP:	make the connection to the database
            
            //?dw_selection.of_settransobject(StaticVariables.sqlca);
            //?ib_rmbmenu = false;
            // 	HELP:	start the services for the datawindow
            // 	HELP:	for certain services, you can also disallow updates by calling of_SetUpdateable  (  FALSE )
            // This.of_SetBase  (  TRUE )
            // This.of_SetAutoInstantiate  (  TRUE )
            // This.of_SetBusinessRule  (  TRUE, "YOURBUSINESSRULE", "HANDLENAME" )

            //?dw_selection.of_setcolormanager(true);
            //?dw_selection.of_setcolumnmanager(true);


            // This.of_SetDate  (  TRUE )							// this is autoinstantiated if allowed
            // This.of_SetDelete  (  TRUE )
            // This.of_SetDropDownFilter  (  TRUE )
            // This.of_SetDropDownSearch  (  TRUE )			//	this is autoinstantiated if allowed
            // This.of_SetDuplicate  (  TRUE )
            // This.of_SetDynamicCreate  (  TRUE )
            // This.of_SetFilter  (  TRUE )
            // This.of_SetFind  (  TRUE )
            // This.of_SetGenerateUniqueNbr  (  TRUE ) 		//	this is autoinstantiated if allowed
            // This.of_SetMultiTable  (  TRUE )					// this is autoinstantiated if allowed
            // This.of_SetPrintPreview  (  TRUE )
            // This.of_SetQueryMode  (  TRUE )
            // This.of_SetReport  (  TRUE )
            
            //?dw_selection.of_setreqcolumn(true);
            //?dw_selection.of_setrowmanager(true);
            //?inv_rowmanager.of_setconfirmondelete(true);
           
            // This.of_SetRowSelect  (  TRUE )
            
            //?dw_selection.of_setsort(true);
            //?dw_selection.of_setvalidation(true);
            //?dw_selection.of_setupdateable(true);
        }

        public virtual void pfc_retrieve()
        {
            //?base.pfc_retrieve();
            // 	Object:			cs_Template_w_Singledw.dw_Single
            // 	Method:			pfc_Retrieve
            // 	Description:	retrieve the datawindow
            // 	HELP:	you should adjust this if there is any retrieval arguments for this dw
            
            //?return dw_selection.Retrieve();
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
