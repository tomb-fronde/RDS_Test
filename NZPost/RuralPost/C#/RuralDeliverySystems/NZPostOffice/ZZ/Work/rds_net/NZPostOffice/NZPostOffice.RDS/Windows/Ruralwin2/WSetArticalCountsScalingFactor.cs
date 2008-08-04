using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin2
{
    public class WSetArticalCountsScalingFactor : WMaster
    {
        #region Define

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_scale;

        public Button cb_ok;

        public Button cb_cancel;

        #endregion

        public WSetArticalCountsScalingFactor()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dw_scale.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_scale_constructor);
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
            this.dw_scale = new URdsDw();
            this.dw_scale.DataObject = new DSetArticalCountsScalingFactor();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_scale);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Scaling Factor";
            this.Size = new System.Drawing.Size(158, 102);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // 
            // dw_scale
            // 
            dw_scale.TabIndex = 1;
            dw_scale.Size = new System.Drawing.Size(148, 25);
            dw_scale.Location = new System.Drawing.Point(3, 7);
            //dw_scale.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_scale_constructor);

            // 
            // cb_ok
            // 
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_ok.TabIndex = 2;
            cb_ok.Size = new System.Drawing.Size(51, 22);
            cb_ok.Location = new System.Drawing.Point(25, 38);
            cb_ok.Click += new EventHandler(cb_ok_clicked);

            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 3;
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Location = new System.Drawing.Point(84, 38);
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

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("View Factor");
            //?this.of_setupdateable(false);
            // IF NOT gnv_app.of_get_securitymanager ( ).of_get_componentPrivilege ( "ComponentName=Set Scaling Factors;", 'M') THEN
            // //	if gnv_App.of_Get_Parameters ( ).StringParm = "ReadOnly" then
            // 			dw_Scale.Modify ( "#1.border=0 #1.background.color=" + string ( gnv_App.of_GetColorCode ( "GREY")) + " #1.Pointer='Arrow!'")
            // 		end if
            // 	dw_Scale.SetTabOrder ( 1,0)
            // end if
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            dw_scale.DataObject.InsertItem<SetArticalCountsScalingFactor>(0); //dw_scale.insertrow(0);
            //?dw_scale.DataObject.GetItem<SetArticalCountsScalingFactor>(0).ScalingFactor = (int?)StaticMessage.DoubleParm; //dw_scale.SetItem(1, 1, StaticMessage.DoubleParm);
            dw_scale.SetValue(0, "scaling_factor", StaticMessage.DoubleParm);

            dw_scale.DataObject.BindingSource.CurrencyManager.Refresh();
            //?dw_scale.SetItemStatus(1, 0, primary!, datamodified!);
            StaticVariables.gnv_app.of_get_parameters().doubleparm = -(1);
            //  TJB SR4592 28-July-2004
            //  This was commented out; uncommented seems to fix the problem

            if (!(dw_scale.of_get_modifypriv()))
            {
                dw_scale.of_protectcolumns();
            }
        }

        public virtual void dw_scale_constructor()
        {
            dw_scale.of_SetUpdateable(false);
        }

        #region Events

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            dw_scale.DataObject.AcceptText();
            StaticVariables.gnv_app.of_get_parameters().doubleparm = dw_scale.GetItem<SetArticalCountsScalingFactor>(0).ScalingFactor;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
