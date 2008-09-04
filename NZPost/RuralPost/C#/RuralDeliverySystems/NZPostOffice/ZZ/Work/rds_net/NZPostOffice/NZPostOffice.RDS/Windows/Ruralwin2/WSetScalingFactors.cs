using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.RDS.Controls;
using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Menus;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WSetScalingFactors : WAncestorWindow
    {
        #region Define
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public Button cb_update;

        #endregion

        public WSetScalingFactors()
        {
            this.InitializeComponent();
            this.dw_1.DataObject = new DSetScalingFactor();
            dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:mvoed from IC
            this.FormClosing -= new FormClosingEventHandler(FormBase_FormClosing);
        }

        public override void open()
        {
            base.open();
            dw_1.InsertItem<SetScalingFactor>(0);
            //?dw_1.setItemStatus(1, 0, primary!, datamodified!);
            ((CheckBox)((DSetScalingFactor)dw_1.DataObject).GetControlByName("updateall")).Checked = true;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // Set the component name 
            this.of_set_componentname("Set Scaling Factors");
            // Tell security that the user must have national access  ( Own region=National)
            this.of_set_nationalaccess(true);
        }

        public virtual void dw_1_constructor()
        {
            dw_1.of_SetUpdateable(false);
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
            //!this.dw_1.DataObject = new DSetScalingFactor();
            this.cb_update = new Button();
            Controls.Add(cb_update);
            Controls.Add(dw_1);

            this.Text = "Scaling Factors";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(190, 130);
            this.Name = "w_set_scaling_factors";
            // 
            // st_label
            // 
            st_label.Text = "w_set_scaling_factors";// 
            st_label.Font = new System.Drawing.Font("Arial Narrow", st_label.Font.Size, st_label.Font.Style);
            st_label.Width = 110;
            st_label.Location = new System.Drawing.Point(3, 77);
            st_label.BringToFront();
            st_label.Visible = true;

            // 
            // dw_1
            // 
            dw_1.TabIndex = 1;
            dw_1.Size = new System.Drawing.Size(175, 66);
            //!dw_1.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_1.Location = new System.Drawing.Point(3, 5);
            //?dw_1.Constructor += new UserEventDelegate(dw_1_constructor);

            // 
            // cb_update
            // 
            cb_update.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_update;
            cb_update.Text = "Update";
            cb_update.TabIndex = 2;
            cb_update.Size = new System.Drawing.Size(54, 22);
            cb_update.Location = new System.Drawing.Point(120, 78);
            cb_update.Click += new EventHandler(cb_update_clicked);
            //this.FormClosing -= new FormClosingEventHandler(FormBase_FormClosing);
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

        public virtual void cb_update_clicked(object sender, EventArgs e)
        {
            DateTime? dDate;
            decimal? decScalingFactor;
            int SQLNRows = 0;
            if (dw_1.DataObject.AcceptText()) //(dw_1.accepttext() > 0) 
            {
                if (dw_1.uf_not_entered(0, "Acdate", "artical count date"))
                {
                    dw_1.DataObject.GetControlByName("acdate").Focus();//dw_1.DataControl["acdate"].Focus();
                    return;
                }
                if (dw_1.uf_not_entered_deci(0, "ScalingFactor", "scaling factor"))
                {
                    dw_1.DataObject.GetControlByName("scaling_factor").Focus(); //dw_1.DataControl["scaling_factor"].Focus();
                    return;
                }

                dDate = dw_1.GetItem<SetScalingFactor>(0).Acdate;// dw_1.GetItemDateTime(1, "acdate").Date;
                decScalingFactor = dw_1.GetItem<SetScalingFactor>(0).ScalingFactor;// dw_1.getItemSystem.Conver.ToDouble ( 1, "scaling_factor" );
                if (dw_1.GetItem<SetScalingFactor>(0).Updateall.GetValueOrDefault())// == "Y")// dw_1.getitemstring(1, "updateall") == 'Y') 
                {
                    //UPDATE artical_count SET ac_scale_factor = :decScalingFactor WHERE artical_count.ac_start_week_period = :dDate AND artical_count.contract_seq_number is null ;
                    SQLNRows = RDSDataService.UpdateArticalCountValue(decScalingFactor, dDate);
                }
                else
                {
                    //UPDATE artical_count SET ac_scale_factor = :decScalingFactor WHERE artical_count.ac_start_week_period = :dDate AND ac_scale_factor is null AND contract_seq_number is null;
                    SQLNRows = RDSDataService.UpdateArticalCountValue2(decScalingFactor, dDate);
                }
                MessageBox.Show( /*?String(app.sqlca.SQLNRows)*/SQLNRows.ToString() + " contracts were updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);// parent.Title );
                //?commit;
            }
        }
        #endregion
    }
}
