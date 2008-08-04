using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using System;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WQsContractor : WMaster
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public URdsDw dw_2;

        public Button pb_search;

        public Button pb_return;

        public Button pb_cancel;

        #endregion

        public WQsContractor()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            dw_1.GetControlByName("suppno").GotFocus += new EventHandler(dw_1_getfocus);
            dw_1.GetControlByName("suppname").GotFocus += new EventHandler(dw_1_getfocus);
            dw_1.Constructor += new UserEventDelegate(dw_1_constructor);
            dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;
            ((DQsContractorList)dw_2.DataObject).CellDoubleClick += new EventHandler(dw_2_doubleclicked);
            dw_2.Constructor += new UserEventDelegate(dw_2_constructor);
            dw_2.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwnag:end
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_1 = new URdsDw();
            this.dw_2 = new URdsDw();
            this.dw_1.DataObject = new DQsContractorCriteria();
            this.dw_2.DataObject = new DQsContractorList();
            this.pb_search = new Button();
            this.pb_return = new Button();
            this.pb_cancel = new Button();
            Controls.Add(dw_1);
            Controls.Add(dw_2);
            Controls.Add(pb_search);
            Controls.Add(pb_return);
            Controls.Add(pb_cancel);
            this.Text = "Owner Driver Select";
            this.ControlBox = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(356, 370);
            // 
            // dw_1
            // 
            dw_1.TabIndex = 1;
            dw_1.Location = new System.Drawing.Point(3, 4);
            dw_1.Size = new System.Drawing.Size(277, 60);
            dw_1.DataObject.GotFocus += new EventHandler(dw_1_getfocus);

            //dw_1.GetControlByName("suppno").GotFocus += new EventHandler(dw_1_getfocus);
            //dw_1.GetControlByName("suppname").GotFocus += new EventHandler(dw_1_getfocus);
            //dw_1.Constructor += new UserEventDelegate(dw_1_constructor);
            // 
            // dw_2
            // 
            dw_2.TabIndex = 4;
            dw_2.Location = new System.Drawing.Point(3, 67);
            dw_2.Size = new System.Drawing.Size(277, 269);
            dw_2.GotFocus += new EventHandler(dw_2_getfocus);
            dw_2.RowFocusChanged += new EventHandler(dw_2_rowfocuschanged);

            //((DQsContractorList)dw_2.DataObject).CellDoubleClick += new EventHandler(dw_2_doubleclicked);
            //dw_2.Constructor += new UserEventDelegate(dw_2_constructor);
            // 
            // pb_search
            // 
            pb_search.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = pb_search;
            pb_search.Image = global::NZPostOffice.Shared.Properties.Resources.SEARCH;
            pb_search.TabIndex = 2;
            pb_search.Location = new System.Drawing.Point(288, 4);
            pb_search.Size = new System.Drawing.Size(59, 31);
            pb_search.Click += new EventHandler(pb_search_clicked);
            // 
            // pb_return
            // 
            pb_return.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_return.Image = global::NZPostOffice.Shared.Properties.Resources.RETURN;
            pb_return.TabIndex = 3;
            pb_return.Location = new System.Drawing.Point(289, 43);
            pb_return.Size = new System.Drawing.Size(59, 31);
            pb_return.Click += new EventHandler(pb_return_clicked);
            // 
            // pb_cancel
            // 
            pb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = pb_cancel;
            pb_cancel.Image = global::NZPostOffice.Shared.Properties.Resources.CANCEL;
            pb_cancel.TabIndex = 5;
            pb_cancel.Location = new System.Drawing.Point(289, 83);
            pb_cancel.Size = new System.Drawing.Size(59, 31);
            pb_cancel.Click += new EventHandler(pb_cancel_clicked);
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
            this.of_set_componentname("Owner Driver");
        }

        public override void pfc_postopen()
        {
            StaticVariables.gnv_app.of_get_parameters().longparm = -(1);
            //?dw_2.settransobject(StaticVariables.sqlca);
            dw_1.DataObject.InsertItem<QsContractorCriteria>(0);
            dw_1.DataObject.SetValue(0, "suppname", StaticVariables.gnv_app.of_get_parameters().stringparm);//dw_1.DataObject.SetValue(0, 2, StaticVariables.gnv_app.of_get_parameters().stringparm);
            dw_1.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public virtual void dw_1_constructor()
        {
            dw_1.of_SetUpdateable(false);
        }

        public virtual void dw_2_constructor()
        {
            dw_2.of_SetUpdateable(false);
        }

        #region Events
        public virtual void dw_1_getfocus(object sender, EventArgs e)
        {
            //pb_search.default = true;
            //pb_return.default = false;
            this.AcceptButton = pb_search;
        }

        public virtual void dw_2_getfocus(object sender, EventArgs e)
        {
            //pb_search.default = false;
            //pb_return.default = true;
            this.AcceptButton = pb_return;
        }

        public virtual void dw_2_rowfocuschanged(object sender, EventArgs e)
        {
            dw_2.SelectRow(0, false);
            if (dw_2.GetRow() >= 0)
                dw_2.SelectRow(dw_2.GetRow() + 1, true);
        }

        public virtual void dw_2_doubleclicked(object sender, EventArgs e)
        {
            pb_return_clicked(this, null);
        }

        public virtual void pb_search_clicked(object sender, EventArgs e)
        {
            int? lSupplier;
            string sSupplier;
            dw_1.DataObject.AcceptText();
            lSupplier = dw_1.DataObject.GetItem<QsContractorCriteria>(0).Suppno;
            sSupplier = dw_1.DataObject.GetItem<QsContractorCriteria>(0).Suppname;
            ((DQsContractorList)dw_2.DataObject).Retrieve(lSupplier, sSupplier);
            if (dw_2.RowCount == 0)
            {
                MessageBox.Show("There are no owner drivers that match the entered criteria", "Search Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Focus();
            }
            else
            {
                dw_2.Focus();
            }
        }

        public virtual void pb_return_clicked(object sender, EventArgs e)
        {
            if (dw_2.GetRow() >= 0)
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = dw_2.DataObject.GetItem<QsContractorList>(dw_2.GetRow()).ContractorSupplierNo;
                StaticVariables.gnv_app.of_get_parameters().stringparm = dw_2.DataObject.GetItem<QsContractorList>(dw_2.GetRow()).ContractorName;
                this.Close();
            }
        }

        public virtual void pb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
