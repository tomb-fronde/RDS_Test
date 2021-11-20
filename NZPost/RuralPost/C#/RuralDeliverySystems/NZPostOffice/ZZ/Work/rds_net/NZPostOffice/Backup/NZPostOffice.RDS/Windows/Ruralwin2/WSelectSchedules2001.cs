using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WSelectSchedules2001 : WMaster
    {
        #region Define
        private WRenewalProcess2006 w_parent;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public CheckBox cbx_schedulea;

        public CheckBox cbx_scheduleb;

        public CheckBox cbx_vehicleschedule;

        public CheckBox cbx_rddescription;

        public CheckBox cbx_mailcarried;

        public CheckBox cbx_contractsummary;

        public Button cb_1;

        public Button cb_2;

        #endregion

        public WSelectSchedules2001()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cbx_schedulea = new CheckBox();
            this.cbx_scheduleb = new CheckBox();
            this.cbx_vehicleschedule = new CheckBox();
            this.cbx_rddescription = new CheckBox();
            this.cbx_mailcarried = new CheckBox();
            this.cbx_contractsummary = new CheckBox();
            this.cb_1 = new Button();
            this.cb_2 = new Button();
            Controls.Add(cbx_schedulea);
            Controls.Add(cbx_scheduleb);
            Controls.Add(cbx_vehicleschedule);
            Controls.Add(cbx_rddescription);
            Controls.Add(cbx_mailcarried);
            Controls.Add(cbx_contractsummary);
            Controls.Add(cb_1);
            Controls.Add(cb_2);
            this.Text = "Select Reports";
            this.Size = new System.Drawing.Size(232, 249);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // 
            // cbx_schedulea
            // 
            cbx_schedulea.Text = "Schedule A";
            cbx_schedulea.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            cbx_schedulea.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_schedulea.Size = new System.Drawing.Size(86, 19);
            cbx_schedulea.Location = new System.Drawing.Point(23, 18);
            // 
            // cbx_scheduleb
            // 
            cbx_scheduleb.Text = "Schedule B";
            cbx_scheduleb.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            cbx_scheduleb.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_scheduleb.Size = new System.Drawing.Size(89, 19);
            cbx_scheduleb.Location = new System.Drawing.Point(23, 42);
            // 
            // cbx_vehicleschedule
            // 
            cbx_vehicleschedule.Text = "Vehicle Schedule";
            cbx_vehicleschedule.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            cbx_vehicleschedule.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_vehicleschedule.Size = new System.Drawing.Size(117, 19);
            cbx_vehicleschedule.Location = new System.Drawing.Point(23, 66);
            // 
            // cbx_rddescription
            // 
            cbx_rddescription.Text = "Route Frequency Description";
            cbx_rddescription.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            cbx_rddescription.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_rddescription.Size = new System.Drawing.Size(174, 19);
            cbx_rddescription.Location = new System.Drawing.Point(23, 90);
            // 
            // cbx_mailcarried
            // 
            cbx_mailcarried.Text = "Schedule of Mail Carried";
            cbx_mailcarried.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            cbx_mailcarried.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_mailcarried.Top = 114;
            cbx_mailcarried.Left = 23;
            cbx_mailcarried.Size = new System.Drawing.Size(155, 19);
            // 
            // cbx_contractsummary
            // 
            cbx_contractsummary.Text = "Contract Summary";
            cbx_contractsummary.BackColor = System.Drawing.Color.FromArgb(4, 212, 208, 200);
            cbx_contractsummary.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cbx_contractsummary.Size = new System.Drawing.Size(118, 19);
            cbx_contractsummary.Location = new System.Drawing.Point(23, 138);
            // 
            // cb_1
            // 
            cb_1.Text = "&OK";
            cb_1.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_1.TabIndex = 0;
            cb_1.Location = new System.Drawing.Point(47, 170);
            cb_1.Size = new System.Drawing.Size(54, 27);
            cb_1.Click += new EventHandler(cb_1_clicked);
            // 
            // cb_2
            // 
            cb_2.Text = "&Cancel";
            cb_2.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_2.TabIndex = 0;
            cb_2.Location = new System.Drawing.Point(133, 170);
            cb_2.Size = new System.Drawing.Size(54, 27);
            cb_2.Click += new EventHandler(cb_2_clicked);
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

        public override void open()
        {
            base.open();
            w_parent = (WRenewalProcess2006)StaticMessage.PowerObjectParm;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_bypass_security(true);
        }

        #region Events

        public virtual void cb_1_clicked(object sender, EventArgs e)
        {
            //Cl_anyArray ScheduleDW = new Cl_anyArray();
            List<object> ScheduleDW = new List<object>();
            if (cbx_schedulea.Checked)
            {
                ScheduleDW.Add("r_schedulea_single_contract");
            }
            if (cbx_scheduleb.Checked)
            {
                ScheduleDW.Add("r_scheduleb_single_contract");
            }
            if (cbx_vehicleschedule.Checked)
            {
                ScheduleDW.Add("r_vehicle_schedule_single_contractv2");
            }
            if (cbx_rddescription.Checked)
            {
                ScheduleDW.Add("r_route_description_single_contract");
            }
            if (cbx_mailcarried.Checked)
            {
                ScheduleDW.Add("r_mail_carried_single_contract");
            }
            if (cbx_contractsummary.Checked)
            {
                ScheduleDW.Add("r_contract_summary");
            }
            w_parent.sScheduleDWs = ScheduleDW;
            //CloseWithReturn(parent, 1);
            StaticMessage.DoubleParm = 1;
            this.Close();
        }

        public virtual void cb_2_clicked(object sender, EventArgs e)
        {
            //CloseWithReturn(parent, 0);
            StaticMessage.LongParm = 0;
            StaticMessage.DoubleParm = 0;
            this.Close();
        }
        #endregion
    }
}
