using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WMaintainAddressOnly : WMaintainAddress
    {
        // TJB  Oct-2011  NOTE: This doesn't appear to be used any more.
        // Thought it was called when a customer was being transferred, but a search 
        // of the code didn't find any references to it.
        public WMaintainAddressOnly()
        {
            this.InitializeComponent();
            dw_header.DataObject = new DAddressDetails();
            dw_details.DataObject = new DAddressOccupants();
            dw_movement.DataObject = new DAddressOccupantsMovement();

            dw_details.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_details_constructor);
        }

        #region Form Design

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // st_label
            // 
            // 
            // dw_header
            // 
            //!dw_header.DataObject = new DAddressDetails();
            // 
            // dw_details
            // 
            //!dw_details.DataObject = new DAddressOccupants();
            dw_details.TabIndex = 0;
            dw_details.Top = 295;
            dw_details.Visible = false;
            //dw_details.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_details_constructor);
            // 
            // cb_open
            // 
            cb_open.TabIndex = 0;
            cb_open.Location = new System.Drawing.Point(410, 296);
            cb_open.Visible = false;
            // 
            // cb_transfer
            // 
            cb_transfer.TabIndex = 0;
            cb_transfer.Location = new System.Drawing.Point(410, 380);
            cb_transfer.Visible = false;
            // 
            // cb_remove
            // 
            cb_remove.TabIndex = 0;
            cb_remove.Location = new System.Drawing.Point(410, 352);
            cb_remove.Visible = false;
            // 
            // cb_new
            // 
            cb_new.TabIndex = 0;
            cb_new.Location = new System.Drawing.Point(410, 324);
            cb_new.Visible = false;
            // 
            // gb_details
            // 
            gb_details.Location = new System.Drawing.Point(5, 280);
            gb_details.Visible = false;
            // 
            // cb_save
            // 
            cb_save.TabIndex = 2;
            cb_save.Location = new System.Drawing.Point(405, 212);
            // 
            // cb_close
            // 
            cb_close.TabIndex = 3;
            cb_close.Location = new System.Drawing.Point(486, 212);
            // 
            // dw_movement
            // 
            //!dw_movement.DataObject = new DAddressOccupantsMovement();
            dw_movement.Location = new System.Drawing.Point(195, 465);
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
        }

        public override void dw_details_constructor()
        {
            dw_details.of_SetUpdateable(false);
            this.st_label.Text = "WMaintainAddressOnly";
        }
    }
}