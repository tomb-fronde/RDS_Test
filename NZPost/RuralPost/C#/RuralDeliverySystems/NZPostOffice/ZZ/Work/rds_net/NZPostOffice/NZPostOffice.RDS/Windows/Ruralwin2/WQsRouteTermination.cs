using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WQsRouteTermination : WMaster
    {
        #region Define
        public int? ilfrequency;

        public int? ilcontract;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public URdsDw dw_2;

        public Button pb_search;

        public Button pb_return;

        public Button pb_cancel;
        #endregion

        public WQsRouteTermination()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            //jlwang:moved from IC
            dw_1.Constructor += new UserEventDelegate(dw_1_constructor);

            ((DQsRouteTerminationList)dw_2.DataObject).CellDoubleClick += new EventHandler(dw_2_doubleclicked);
            dw_2.Constructor += new UserEventDelegate(dw_2_constructor);
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
            this.dw_1 = new URdsDw();
            this.dw_1.DataObject = new DQsRouteTerminationCriteria();
            this.dw_2 = new URdsDw();
            this.dw_2.DataObject = new DQsRouteTerminationList();
            this.pb_search = new Button();
            this.pb_return = new Button();
            this.pb_cancel = new Button();
            Controls.Add(dw_1);
            Controls.Add(dw_2);
            Controls.Add(pb_search);
            Controls.Add(pb_return);
            Controls.Add(pb_cancel);
            this.Text = "Route Termination Select";
            this.ControlBox = true;
            this.Width = 356;
            // 
            // dw_1
            // 
            dw_1.TabIndex = 1;
            dw_1.Location = new System.Drawing.Point(3, 4);
            dw_1.Size = new System.Drawing.Size(277, 60);
            dw_1.GotFocus += new EventHandler(dw_1_getfocus);
            //dw_1.Constructor += new UserEventDelegate(dw_1_constructor);

            // 
            // dw_2
            // 
            dw_2.TabIndex = 4;
            dw_2.Location = new System.Drawing.Point(3, 67);
            dw_2.Size = new System.Drawing.Size(277, 267);
            dw_2.RowFocusChanged += new EventHandler(dw_2_rowfocuschanged);
            dw_2.GotFocus += new EventHandler(dw_2_getfocus);
            //((DQsRouteTerminationList)dw_2.DataObject).CellDoubleClick += new EventHandler(dw_2_doubleclicked);
            //dw_2.Constructor += new UserEventDelegate(dw_2_constructor);

            // 
            // pb_search
            // 
            pb_search.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = pb_search;
            pb_search.Image = global::NZPostOffice.Shared.Properties.Resources.SEARCH;
            pb_search.TabIndex = 2;
            pb_search.Location = new System.Drawing.Point(289, 4);
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

        public override void pfc_postopen()
        {
            ilfrequency = StaticVariables.gnv_app.of_get_parameters().longparm;
            ilcontract = StaticVariables.gnv_app.of_get_parameters().contracttypeparm;
            StaticVariables.gnv_app.of_get_parameters().longparm = -(1);
            //?dw_2.settransobject(StaticVariables.sqlca);
            dw_1.DataObject.InsertItem<QsRouteTerminationCriteria>(0);
            dw_1.DataObject.SetValue(0, "street_name", StaticMessage.StringParm);//.SetValue(0, 0, StaticMessage.StringParm);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Frequency");
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

        public virtual void dw_2_rowfocuschanged(object sender, EventArgs e)
        {
            dw_2.SelectRow(0, false);
            dw_2.SelectRow(dw_2.GetRow(), true);
        }

        public virtual void dw_2_getfocus(object sender, EventArgs e)
        {
            //pb_search.default = false;
            //pb_return.default = true;
            this.AcceptButton = pb_return;
        }

        public virtual void dw_2_doubleclicked(object sender, EventArgs e)
        {
            pb_return_clicked(this, null);
        }

        public virtual void pb_search_clicked(object sender, EventArgs e)
        {
            string street_name;
            //  Get street
            dw_1.DataObject.AcceptText();
            street_name = dw_1.DataObject.GetItem<QsRouteTerminationCriteria>(dw_1.GetRow()).StreetName;
            ((DQsRouteTerminationList)dw_2.DataObject).Retrieve(ilcontract, street_name);
            if (dw_2.RowCount == 0)
            {
                MessageBox.Show("There are no customers that match the entered criteria", "Search Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Focus();
            }
            else
            {
                dw_2.SetCurrent(0);
                dw_2.Focus();
            }
        }

        public virtual void pb_return_clicked(object sender, EventArgs e)
        {
            if (dw_2.GetRow() >= 0)
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = dw_2.DataObject.GetItem<QsRouteTerminationList>(dw_2.GetRow()).CustomerCustId;
                StaticVariables.gnv_app.of_get_parameters().stringparm = dw_2.DataObject.GetItem<QsRouteTerminationList>(dw_2.GetRow()).CcustName;
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
