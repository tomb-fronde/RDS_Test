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


            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyDown += new KeyEventHandler(WSelectFrequency_KeyDown);

            ((DContractRouteFrequencySelect2001)dw_list.DataObject).CellDoubleClick += new EventHandler(dw_list_doubleclicked);
        }

        public override void open()
        {
            base.open();
            //?dw_list.settransobject(StaticVariables.sqlca);
            ((DContractRouteFrequencySelect2001)dw_list.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm);
            dw_list.DataObject.FilterString = "rf_active = 'Y'";
            dw_list.DataObject.Filter<ContractRouteFrequencySelect2001>();
            //?dw_list.setrowfocusindicator(focusrect!);
            StaticVariables.gnv_app.of_get_parameters().stringparm = "NotFound";         
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_list = new URdsDw();
//!            this.dw_list.DataObject = new DContractRouteFrequencySelect2001();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_list);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Select a Frequency";
            this.ControlBox = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(323, 200);
            // 
            // dw_list
            // 
            dw_list.AutoScroll = true;
//!            dw_list.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_list.TabIndex = 1;
            dw_list.Location = new System.Drawing.Point(5, 6);
            dw_list.Size = new System.Drawing.Size(306, 125);
            dw_list.Click += new EventHandler(dw_list_clicked);
            dw_list.RowFocusChanged += new EventHandler(dw_list_rowfocuschanged);
//!            ((DContractRouteFrequencySelect2001)dw_list.DataObject).CellDoubleClick += new EventHandler(dw_list_doubleclicked);
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 3;
            cb_ok.Size = new System.Drawing.Size(57, 22);
            cb_ok.Location = new System.Drawing.Point(177, 138);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 2;
            cb_cancel.Location = new System.Drawing.Point(254, 138);
            cb_cancel.Size = new System.Drawing.Size(57, 22);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
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
