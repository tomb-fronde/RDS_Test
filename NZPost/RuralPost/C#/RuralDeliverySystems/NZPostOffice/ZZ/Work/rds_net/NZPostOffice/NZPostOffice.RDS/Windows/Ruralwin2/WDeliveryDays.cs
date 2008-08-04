using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WDeliveryDays : WMaster
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public Button cb_ok;

        public Button cb_cancel;

        #endregion

        public WDeliveryDays()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
        }

        public override void open()
        {
            base.open();
            this.of_set_componentname("Customer");
            int lLoop;
            dw_1.DataObject.InsertItem<DeliveryDays>(0);
            /*for (lLoop = 0; lLoop < 7; lLoop++) {
                dw_1.SetValue(0, lLoop, StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(lLoop, 1));
            }*/
            dw_1.GetItem<DeliveryDays>(0).Mon = StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(0, 1);
            dw_1.GetItem<DeliveryDays>(0).Tue = StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(1, 1);
            dw_1.GetItem<DeliveryDays>(0).Wed = StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(2, 1);
            dw_1.GetItem<DeliveryDays>(0).Thu = StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(3, 1);
            dw_1.GetItem<DeliveryDays>(0).Fri = StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(4, 1);
            dw_1.GetItem<DeliveryDays>(0).Sat = StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(5, 1);
            dw_1.GetItem<DeliveryDays>(0).Sun = StaticVariables.gnv_app.of_get_parameters().stringparm.Substring(6, 1);
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
            this.dw_1.DataObject = new DDeliveryDays();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_1);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Delivery Days";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(202, 134);
            this.Location = new System.Drawing.Point(10, 5);
            // 
            // dw_1
            // 
            dw_1.VerticalScroll.Visible = false;
            dw_1.HorizontalScroll.Visible = true;
            dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_1.TabIndex = 1;
            dw_1.Location = new System.Drawing.Point(3, 1);
            dw_1.Size = new System.Drawing.Size(188, 74);
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.Tag = "ComponentPrivilege=C;ComponentPrivilege=M;";
            cb_ok.Enabled = false;
            cb_ok.TabIndex = 3;
            cb_ok.Location = new System.Drawing.Point(38, 79);
            cb_ok.Size = new System.Drawing.Size(54, 22);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 2;
            cb_cancel.Location = new System.Drawing.Point(100, 79);
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

        #region Events
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            StaticVariables.gnv_app.of_get_parameters().stringparm = dw_1.GetItem<DeliveryDays>(0).Deliverystring;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}