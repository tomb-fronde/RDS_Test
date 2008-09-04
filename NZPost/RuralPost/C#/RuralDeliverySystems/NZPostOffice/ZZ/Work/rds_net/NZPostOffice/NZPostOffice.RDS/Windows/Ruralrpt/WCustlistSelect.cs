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
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustlistSelect : WAncestorWindow
    {   
        public URdsDw idw_custlist;

        public WCustlistSelect()
        {
            InitializeComponent();
            this.dw_custlist.DataObject = new DCustlistSelect();

            //jlwang:moved from IC
            this.dw_custlist.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_custlist_constructor);
            //jlwang:end
        }

        public virtual void dw_custlist_constructor()
        {
            //! added code for he title of form which appears empty after parent class assigns ""
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = "Rural Delivery System with NPAD Extensions (enabled)";
            }

            idw_custlist = dw_custlist;
            idw_custlist.Reset();
            ((DCustlistSelect)idw_custlist.DataObject).Retrieve();
        }

        #region Events
        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void dw_custlist_clicked(object sender, EventArgs e)
        {
            //if (dw_custlist.GetRow() >= 0)
            //{
            //    if (dw_custlist.IsSelected(dw_custlist.GetRow()))
            //    {
            //        dw_custlist.SelectRow(dw_custlist.GetRow() + 1, false);
            //    }
            //    else
            //    {
            //        dw_custlist.SelectRow(dw_custlist.GetRow() + 1, true);
            //    }
            //}
        }

        public virtual void cb_all_clicked(object sender, EventArgs e)
        {
            int ll_row;
            int ll_nrows;
            ll_nrows = idw_custlist.RowCount;
            if (cb_all.Text == "Select All")
            {
                for (ll_row = 0; ll_row < ll_nrows; ll_row++)
                {
                    idw_custlist.SelectRow(ll_row, true);
                }
                cb_all.Text = "Unselect All";
            }
            else
            {
                for (ll_row = 0; ll_row < ll_nrows; ll_row++)
                {
                    idw_custlist.SelectRow(ll_row, false);
                }
                cb_all.Text = "Select All";
            }
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
        {
            int ll_row;
            int ll_nrows;
            int ll_selectedRows;
            int? ll_custid;
            string ls_msg;
            string ls_selectedlist;
            ll_nrows = idw_custlist.RowCount;
            ls_msg = "";
            ls_selectedlist = "";
            ll_selectedRows = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            Cursor.Current = Cursors.WaitCursor;
            for (ll_row = 0; ll_row < ll_nrows; ll_row++)
            {
                if (idw_custlist.IsSelected(ll_row))
                {
                    ll_custid = idw_custlist.GetItem<CustlistSelect>(ll_row).CustId;
                    ls_selectedlist = ls_selectedlist + ll_custid.ToString() + ",";
                    ll_selectedRows++;
                }
            }
            if (ll_selectedRows == 0)
            {
                MessageBox.Show("No customers selected", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!(ll_selectedRows == ll_nrows))
                {
                    ls_selectedlist = ls_selectedlist.Substring(0, ls_selectedlist.Length - 1);
                    // 		ls_msg = 'Selected rows = '+ll_selectedRows.ToString()  &
                    // 				+' of '+ll_nrows.ToString()          &
                    // 				+'\r\r'+ls_selectedlist
                    // 
                    // 		messagebox ( 'w_custlist_select', ls_msg )
                    for (ll_row = 0; ll_row < ll_nrows; ll_row++)
                    {
                        if (!(idw_custlist.IsSelected(ll_row)))
                        {
                            ll_custid = idw_custlist.GetItem<CustlistSelect>(ll_row).CustId;
                            // DELETE FROM rd.report_temp WHERE report_temp.customer_id = :ll_custid USING SQLCA;
                            RDSDataService.DeleteReportTemp(ll_custid, ref SQLCode, ref SQLErrText);
                            if (SQLCode == -(1))
                            {
                                MessageBox.Show("Error deleting customer id " + ll_custid.ToString() + " from list~r~r" + SQLErrText, "SQL error");
                            }
                            //? COMMIT;
                        }
                    }
                }
                idw_custlist.Reset();
                idw_custlist.Retrieve();
                cb_all.Text = "Select All";
            }
        }

        public virtual void cb_labels_clicked(object sender, EventArgs e)
        {
            //  TJB  Jan 2005
            //  Note: For some reason, if this button is left visible
            //  while the addresses are being retrieved  ( it takes 
            //  a loooong time!), it shows through the overlying 
            //  label window until the data has been retrieved and 
            //  displayed.  Enabling it after the 'OpenSheet' works,
            //  but I don't know why the timing is OK.
            cb_labels.Hide();
            //  OpenSheet(wCustLabels, w_main_mdi, 0, original);
            OpenSheet<WCustomerLabels>(StaticVariables.MainMDI);
            cb_labels.Show();
        }
        #endregion
    }
}