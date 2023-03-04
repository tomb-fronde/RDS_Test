using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddressTransferOccupants : WMaster
    {
        #region Define
        public Metex.Windows.DataUserControl ids_content;//public n_ds ids_content;

        public bool ib_ok_clicked = false;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_select;

        public UCb cb_ok;

        public UCb cb_cancel;

        public USt st_title;

        #endregion

        public WAddressTransferOccupants()
        {
            this.InitializeComponent();
            dw_select.DataObject = new DAddressSelectOccupants();

            // jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dw_select.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_select_constructor);
            //jlwang:end

            this.ShowInTaskbar = false;
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
            //!dw_select.DataObject = new DAddressSelectOccupants();

            this.cb_ok = new UCb();
            this.cb_cancel = new UCb();
            this.st_title = new USt();
            Controls.Add(dw_select);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            Controls.Add(st_title);
            this.Text = "Address Transfer: Select Customers";
            this.Size = new System.Drawing.Size(266, 276);
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // 
            // dw_select
            // 
            dw_select.TabIndex = 1;
            dw_select.Location = new System.Drawing.Point(7, 34);
            dw_select.Size = new System.Drawing.Size(245, 176);
            dw_select.Click += new EventHandler(dw_select_clicked);
            dw_select.RowFocusChanged += new EventHandler(dw_select_rowfocuschanged);
            //dw_select.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_select_constructor);

            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "OK";
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(95, 219);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "Cancel";
            cb_cancel.TabIndex = 2;
            cb_cancel.Location = new System.Drawing.Point(178, 219);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // st_title
            // 
            st_title.Text = "The customer(s) selected below will be transferred to another address.";
            st_title.Location = new System.Drawing.Point(8, 4);
            st_title.Size = new System.Drawing.Size(242, 31);
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
            int ll_cust_id = 0;
            ids_content = StaticMessage.PowerObjectParm as Metex.Windows.DataUserControl;// StaticMessage.PowerObjectParm;
            if ((ids_content == null) || !((ids_content != null)))
            {
                MessageBox.Show("Invalid content passed in", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            // ids_content.Retrieve ( ll_cust_id)
            ids_content.ShareData(dw_select.DataObject);
        }

        public override void pfc_default()
        {
            base.pfc_default();
            int ll_row;
            ib_ok_clicked = true;
            //  discard all rows where not selected
            for (ll_row = dw_select.RowCount; ll_row > 0; ll_row -= 1)
            {
                if (dw_select.GetItem<AddressSelectOccupants>(ll_row - 1).MoveInd == "N")
                {
                    dw_select.DataObject.RowsDiscard(ll_row - 1, ll_row - 1);//dw_select.RowsDiscard(ll_row, ll_row, primary!);
                }
            }
            this.Close();
        }

        public override void close()
        {
            base.close();
            if (ib_ok_clicked)
            {
                StaticMessage.PowerObjectParm = ids_content;
            }
            else
            {
                StaticMessage.PowerObjectParm = null;
            }
        }

        public virtual void dw_select_constructor()
        {
            dw_select.of_SetUpdateable(false);
        }

        #region Events
        public virtual void dw_select_clicked(object sender, EventArgs e)
        {
            int row = dw_select.GetRow();
            dw_select.SelectRow(0, false);
            dw_select.SelectRow(row + 1, true);
            dw_select.SetCurrent(row);
        }

        public virtual void dw_select_rowfocuschanged(object sender, EventArgs e)
        {
            dw_select.SelectRow(0, false);
            dw_select.SelectRow(dw_select.GetRow() + 1, true);
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            this.pfc_default();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}