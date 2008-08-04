using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAssignArticalCountToRenewal : WMaster
    {
        #region Define

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_renewal;

        public Button cb_ok;

        public Button cb_cancel;

        #endregion

        public WAssignArticalCountToRenewal()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            //jlwang:moved from IC
            ((DAssignArticalCountToRenewal)dw_renewal.DataObject).CellDoubleClick += new EventHandler(dw_renewal_doubleclicked);
            ((DAssignArticalCountToRenewal)dw_renewal.DataObject).CellClick += new EventHandler(dw_renewal_clicked);
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
            this.dw_renewal = new URdsDw();
            dw_renewal.DataObject = new DAssignArticalCountToRenewal();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_renewal);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Renewal";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(133, 254);
            // 
            // dw_renewal
            // 
            dw_renewal.VerticalScroll.Visible = true;
            dw_renewal.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_renewal.TabIndex = 1;
            dw_renewal.Location = new System.Drawing.Point(3, 4);
            dw_renewal.Size = new System.Drawing.Size(111, 187);
            dw_renewal.RowFocusChanged += new EventHandler(dw_renewal_rowfocuschanged);

            //((DAssignArticalCountToRenewal)dw_renewal.DataObject).CellDoubleClick += new EventHandler(dw_renewal_doubleclicked);
            //((DAssignArticalCountToRenewal)dw_renewal.DataObject).CellClick += new EventHandler(dw_renewal_clicked);

            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Location = new System.Drawing.Point(3, 197);
            cb_ok.Size = new System.Drawing.Size(51, 22);
            cb_ok.Click += new EventHandler(cb_ok_clicked);

            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(62, 197);
            cb_cancel.Size = new System.Drawing.Size(54, 22);
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

        public override void pfc_postopen()
        {
            int lRow;
            ((DAssignArticalCountToRenewal)dw_renewal.DataObject).Retrieve(StaticVariables.gnv_app.of_get_parameters().longparm);
            if (!(StaticFunctions.f_nempty(StaticVariables.gnv_app.of_get_parameters().integerparm)))
            {
                lRow = dw_renewal.Find("contract_seq_number", StaticVariables.gnv_app.of_get_parameters().integerparm);
                if (lRow > 0)
                {
                    dw_renewal.SetCurrent(lRow);
                }
            }
            StaticVariables.gnv_app.of_get_parameters().longparm = -(1);
        }

        #region Events
        public virtual void dw_renewal_doubleclicked(object sender, EventArgs e)
        {
            if (dw_renewal.GetRow() >= 0)
            {
                cb_ok_clicked(this, null);
            }
        }

        public virtual void dw_renewal_clicked(object sender, EventArgs e)
        {
            if (dw_renewal.GetRow() >= 0)
            {
                dw_renewal.SetCurrent(dw_renewal.GetRow());
            }
        }

        public virtual void dw_renewal_rowfocuschanged(object sender, EventArgs e)
        {
            dw_renewal.SelectRow(0, false);
            dw_renewal.SelectRow(dw_renewal.GetRow() + 1, true);
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            if (dw_renewal.RowCount > 0)
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = dw_renewal.GetItem<AssignArticalCountToRenewal>(dw_renewal.GetRow()).ContractSeqNumber;
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