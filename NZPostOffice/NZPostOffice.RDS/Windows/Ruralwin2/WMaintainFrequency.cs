using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WMaintainFrequency : WMaster
    {
        // TJB  RPCR_036  23-Apr-2012
        // Update address.adr_delivery_days if the user changes the address'
        // frequencies.
        // See WMaintainFrequency_PfcPostUpdate()
        //
        // TJB  Sequencing review  Jan-2011:  New
        //      Displays list of frequencies associated with a contract with check boxes 
        //      indicating which frequencies the specific address is associated with.
        //      Changes updated in the address_frequency table.
        //      Called from the wCustomer2001 window.

        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_list;

        public Button cb_ok;

        public Button cb_cancel;

        private int? adrId;

        private int? contractNo;

        #endregion

        public WMaintainFrequency()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            this.dw_list.DataObject = new DContractAddressFrequency();
            dw_list.DataObject.BorderStyle = BorderStyle.Fixed3D;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.KeyDown += new KeyEventHandler(WMaintainFrequency_KeyDown);
            this.dw_list.PfcPostUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate(WMaintainFrequency_PfcPostUpdate);

            ((DContractAddressFrequency)dw_list.DataObject).CellDoubleClick += new EventHandler(dw_list_doubleclicked);
        }

        public override void open()
        {
            contractNo = StaticVariables.gnv_app.of_get_parameters().longparm;
            adrId = StaticVariables.gnv_app.of_get_parameters().integerparm;

            base.open();
            ((DContractAddressFrequency)dw_list.DataObject).Retrieve(contractNo, adrId);
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
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_list);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Maintain Frequencies";
            this.ControlBox = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size(323, 200);
            // 
            // dw_list
            // 
            dw_list.AutoScroll = true;
            dw_list.TabIndex = 1;
            dw_list.Location = new System.Drawing.Point(5, 6);
            dw_list.Size = new System.Drawing.Size(306, 125);
            dw_list.Click += new EventHandler(dw_list_clicked);
            dw_list.RowFocusChanged += new EventHandler(dw_list_rowfocuschanged);
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
            StaticVariables.gnv_app.of_get_parameters().stringparm = dw_list.GetItem<ContractAddressFrequency>(dw_list.GetRow()).RfDeliveryDays;
            StaticVariables.gnv_app.of_get_parameters().integerparm = dw_list.GetItem<ContractAddressFrequency>(dw_list.GetRow()).SfKey;  
            this.Close();
        }

        public virtual void WMaintainFrequency_KeyDown(object sender, KeyEventArgs e)
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

        // TJB  20-Apr-2012  RPCR_036
        // Update the adr_delivery_days column for this address when the 
        // address' frequencies change.
        public virtual void WMaintainFrequency_PfcPostUpdate()
        {
            RDSDataService.UpdateAdrDeliveryDays(adrId);
        }
    }
}
