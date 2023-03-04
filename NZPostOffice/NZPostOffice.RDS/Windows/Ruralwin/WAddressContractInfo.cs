using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_037  Dec-2012
    // Added mobile2, primary_contact checkboxes, and contractor notes (in datacontrol)
    // Increased size of panel

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
            this.dw_info.DataObject = new DContractorInfo();
            dw_info.DataObject.BorderStyle = BorderStyle.None;
            dw_info.DataObject.VerticalScroll.Visible = false;

            dw_info.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_info_constructor);
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_info = new NZPostOffice.RDS.Controls.URdsDw();
            this.SuspendLayout();
            // 
            // dw_info
            // 
            this.dw_info.DataObject = null;
            this.dw_info.FireConstructor = false;
            this.dw_info.Location = new System.Drawing.Point(0, 0);
            this.dw_info.Name = "dw_info";
            this.dw_info.Size = new System.Drawing.Size(314, 227);
            this.dw_info.TabIndex = 1;
            this.dw_info.LostFocus += new System.EventHandler(this.dw_info_losefocus);
            // 
            // WAddressContractInfo
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(316, 228);
            this.ControlBox = false;
            this.Controls.Add(this.dw_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WAddressContractInfo";
            this.Deactivate += new System.EventHandler(this.dw_info_losefocus);
            this.Controls.SetChildIndex(this.dw_info, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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
