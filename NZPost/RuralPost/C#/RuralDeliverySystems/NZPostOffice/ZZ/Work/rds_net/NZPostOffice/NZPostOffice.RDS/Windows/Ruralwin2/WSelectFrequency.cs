using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    // TJB 17-Feb-2021:  Increased width of window

    public class WSelectFrequency : WMaster
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_list;

        public Button cb_ok;

        public Button cb_cancel;

        #endregion

        public WSelectFrequency()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            this.dw_list.DataObject = new DContractRouteFrequencySelect2001();
            dw_list.DataObject.BorderStyle = BorderStyle.Fixed3D;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyDown += new KeyEventHandler(WSelectFrequency_KeyDown);

            ((DContractRouteFrequencySelect2001)dw_list.DataObject).CellDoubleClick += new EventHandler(dw_list_doubleclicked);
        }

        public override void open()
        {
            base.open();
            ((DContractRouteFrequencySelect2001)dw_list.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm);
            dw_list.DataObject.FilterString = "rf_active = 'Y'";
            dw_list.DataObject.Filter<ContractRouteFrequencySelect2001>();
            StaticVariables.gnv_app.of_get_parameters().stringparm = "NotFound";         
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_list = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_ok = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dw_list
            // 
            this.dw_list.AutoScroll = true;
            this.dw_list.DataObject = null;
            this.dw_list.FireConstructor = false;
            this.dw_list.Location = new System.Drawing.Point(5, 6);
            this.dw_list.Name = "dw_list";
            this.dw_list.Size = new System.Drawing.Size(343, 125);
            this.dw_list.TabIndex = 1;
            this.dw_list.RowFocusChanged += new System.EventHandler(this.dw_list_rowfocuschanged);
            this.dw_list.Click += new System.EventHandler(this.dw_list_clicked);
            // 
            // cb_ok
            // 
            this.cb_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_ok.Location = new System.Drawing.Point(209, 138);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new System.Drawing.Size(57, 22);
            this.cb_ok.TabIndex = 3;
            this.cb_ok.Text = "&OK";
            this.cb_ok.Click += new System.EventHandler(this.cb_ok_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(286, 138);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(57, 22);
            this.cb_cancel.TabIndex = 2;
            this.cb_cancel.Text = "&Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // WSelectFrequency
            // 
            this.AcceptButton = this.cb_ok;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(354, 173);
            this.Controls.Add(this.dw_list);
            this.Controls.Add(this.cb_ok);
            this.Controls.Add(this.cb_cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WSelectFrequency";
            this.Text = "Select a Frequency";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.cb_ok, 0);
            this.Controls.SetChildIndex(this.dw_list, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        #region Events
        public virtual void dw_list_clicked(object sender, EventArgs e)
        {
            int lRow;
            lRow = this.dw_list.GetRow();
            if (lRow >= 0)
            {
                dw_list.SetCurrent(lRow);
            }
        }

        public virtual void dw_list_rowfocuschanged(object sender, EventArgs e)
        {
            if (dw_list.GetRow() >= 0)
            {
                dw_list.SelectRow(0, false);
                dw_list.SelectRow(dw_list.GetRow() + 1, true);
            }
        }

        public virtual void dw_list_doubleclicked(object sender, EventArgs e)
        {
            if (dw_list.GetRow() >= 0)
            {
                cb_ok_clicked(this, null);
            }
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            StaticVariables.gnv_app.of_get_parameters().stringparm = dw_list.GetItem<ContractRouteFrequencySelect2001>(dw_list.GetRow()).RfDeliveryDays;// dw_list.GetItemString(dw_list.getrow(), "rf_delivery_days");
            StaticVariables.gnv_app.of_get_parameters().integerparm = dw_list.GetItem<ContractRouteFrequencySelect2001>(dw_list.GetRow()).SfKey;  //dw_list.GetItemNumber(dw_list.getrow(), "sf_key");
            this.Close();
        }

        public virtual void WSelectFrequency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.cb_ok.Focus();
                this.cb_ok_clicked(null, null);
                e.SuppressKeyPress = true;
            }
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
