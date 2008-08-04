using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddressContractInfo : WMaster
    {
        #region Define
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_info;

        #endregion

        public WAddressContractInfo()
        {
            this.InitializeComponent();

            //jlwang:moved from IC
            dw_info.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_info_constructor);
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
            this.dw_info = new URdsDw();
            this.dw_info.DataObject = new DContractorInfo();
            Controls.Add(dw_info);
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Size = new System.Drawing.Size(322, 143);
            // 
            // dw_info
            // 
            dw_info.DataObject.BorderStyle = BorderStyle.None;
            dw_info.DataObject.VerticalScroll.Visible = false;
            dw_info.TabIndex = 1;
            dw_info.Size = new System.Drawing.Size(320, 142);
            dw_info.LostFocus += new EventHandler(dw_info_losefocus);
            //dw_info.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_info_constructor);
            this.Deactivate += new EventHandler(dw_info_losefocus);
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
            this.of_bypass_security(true);
            this.Left = StaticVariables.gnv_app.of_getframe().PointToClient(Cursor.Position).X;
            this.Top = StaticVariables.gnv_app.of_getframe().PointToClient(Cursor.Position).Y;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int ll_id;
            ll_id = System.Convert.ToInt32(StaticMessage.DoubleParm);
            if (ll_id > 0)
            {
                dw_info.Retrieve(new object[] { ll_id });
            }
            else
            {
                MessageBox.Show(ll_id.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public virtual void dw_info_constructor()
        {
            //?base.constructor();
            dw_info.of_SetUpdateable(false);
        }    
        
        public virtual void dw_info_losefocus(object sender, EventArgs e)
        {
            //?base.losefocus();
            this.Close();// close(parent);
        }
    }
}
