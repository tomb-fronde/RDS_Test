using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using System.IO;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralmailmerge;
using NZPostOffice.RDS.Entity.Ruralmailmerge;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralmailmerge
{
    public partial class WSelectProcurements : WMaster
    {

        #region Define
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_select;

        public UCb cb_ok;

        public UCb cb_cancel;

        public USt st_title;

        #endregion

        public WSelectProcurements()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dw_select.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_select_constructor);
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
            this.dw_select = new URdsDw();
            this.dw_select.DataObject = new DSelectProcurements();
            this.cb_ok = new UCb();
            this.cb_cancel = new UCb();
            this.st_title = new USt();
            Controls.Add(dw_select);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(st_title);
            this.Text = "OwnerDriver MailMerge: select procurements";
            this.Size = new Size(271, 276);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 
            // dw_select
            // 

            dw_select.TabIndex = 1;
            dw_select.Size = new Size(232, 176);
            dw_select.Location = new Point(16, 32);
            ((DataEntityGrid)dw_select.GetControlByName("grid")).ScrollBars = ScrollBars.Vertical;
            dw_select.Click += new EventHandler(dw_select_clicked);
            dw_select.RowFocusChanged += new EventHandler(dw_select_rowfocuschanged);
            //dw_select.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_select_constructor);
            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "OK";
            cb_ok.TabIndex = 2;
            cb_ok.Location = new Point(95, 219);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "Cancel";
            cb_cancel.TabIndex = 2;
            cb_cancel.Location = new Point(178, 219);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // st_title
            // 
            st_title.Text = "Select the required procurements";
            st_title.Font = new Font("MS Sans Serif", 10F);
            st_title.Size = new Size(240, 24);
            st_title.Location = new Point(8, 8);
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

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // this.of_bypass_security ( TRUE)
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            //  TJB  SR4692  Aug 2006         ** NEW window **
            //  Display a list of the defined procurements
            //  and allow the user to select some, all, or none of them.
            //  Returns a list of selected procurements to the caller 
            //   ( w_mailmerge_ownerdriver_download_search)
            ((DSelectProcurements)dw_select.DataObject).Retrieve();
        }

        public virtual void dw_select_constructor()
        {
            dw_select.of_SetUpdateable(false);
        }

        #region Events
        public virtual void dw_select_clicked(object sender, EventArgs e)
        {
            dw_select.SelectRow(0, false);
            dw_select.SelectRow(dw_select.GetRow() + 1, true);
            dw_select.SetCurrent(dw_select.GetRow());
        }

        public virtual void dw_select_rowfocuschanged(object sender, EventArgs e)
        {
            dw_select.SelectRow(0, false);
            dw_select.SelectRow(dw_select.GetRow() + 1, true);
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4692  Aug 2006
            int ll_row;
            int ll_rows;
            int? ll_id;
            int ll_selected;
            string ls_ind;
            string ls_name;
            string ls_msg;
            string ls_selected;
            StaticVariables.gnv_app.of_get_parameters().longparm = 0;
            StaticVariables.gnv_app.of_get_parameters().stringparm = "";
            //  Scan the list of procurements  ( there aren't many)
            //  If the selected indicator is 'Y', save the procurement
            //  ID and name to be returned to the calling window.
            // 
            //  The return string has the format
            //  	"<id>,<name>,<id>,<name>,..."
            ll_rows = dw_select.RowCount;
            if (ll_rows > 0)
            {
                ll_selected = 0;
                ls_selected = "";
                ls_msg = "Rowcount = " + ll_rows.ToString() + '~';
                for (ll_row = 0; ll_row < ll_rows; ll_row++)
                {
                    ls_ind = dw_select.GetItem<SelectProcurements>(ll_row).SelectInd;
                    ls_name = dw_select.GetItem<SelectProcurements>(ll_row).ProcName;
                    ll_id = dw_select.GetItem<SelectProcurements>(ll_row).ProcId;
                    if (ls_ind == null)
                    {
                        ls_ind = "null";
                    }
                    if (ls_name == null)
                    {
                        ls_name = "null";
                    }
                    if (ll_id == 0)
                    {
                        ll_id = -(1);
                    }
                    ls_msg = ls_msg + '~' + ll_row.ToString() + ' ' + ls_ind + ' ' + ls_name + ' ' + ll_id.ToString();
                    if (ls_ind == "Y".ToString())
                    {
                        ls_selected = ls_selected + ll_id.ToString() + ',' + ls_name.ToString() + ',';
                        ll_selected = ll_selected + 1;
                    }
                }
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show (   & ls_msg ,  'w_select_procurements.cb_ok.clicked' )
                // ---------------------------------------------------------  */
                StaticVariables.gnv_app.of_get_parameters().longparm = ll_selected;
                StaticVariables.gnv_app.of_get_parameters().stringparm = ls_selected;
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
