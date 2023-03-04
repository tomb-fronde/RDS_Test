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
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    partial class WMaintainAddress
    {
        // TJB  RPCR_029  Oct-2011
        // Added checkbox for adr_location_ind to window.
        // Also added readonly textbox controls for road_type, road_suffix, 
        // suburb name and town name.  These are used to replace the combo boxes 
        // when NPAD is enabled so the fields look the same as the other header
        // textbox fields.
        // TJB  Jan-2011 Sequencing Review

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_header;

        public URdsDw dw_details;

        public UCb cb_open;

        public UCb cb_transfer;

        public UCb cb_remove;

        public UCb cb_new;

        public UGb gb_details;

        public UCb cb_save;

        public UCb cb_close;

        public URdsDw dw_movement;

        public Button cb_restore;

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dw_header = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_selectfreq = new System.Windows.Forms.Button();
            this.dw_details = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_open = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_transfer = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_remove = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_new = new NZPostOffice.Shared.VisualComponents.UCb();
            this.gb_details = new NZPostOffice.Shared.VisualComponents.UGb();
            this.cb_save = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_close = new NZPostOffice.Shared.VisualComponents.UCb();
            this.dw_movement = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_restore = new System.Windows.Forms.Button();
            this.dw_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(5, 410);
            this.st_label.Size = new System.Drawing.Size(150, 23);
            this.st_label.Text = "w_maintain_address";
            // 
            // dw_header
            // 
            this.dw_header.Controls.Add(this.cb_selectfreq);
            this.dw_header.DataObject = null;
            this.dw_header.FireConstructor = false;
            this.dw_header.Location = new System.Drawing.Point(5, 5);
            this.dw_header.Name = "dw_header";
            this.dw_header.Size = new System.Drawing.Size(650, 200);
            this.dw_header.TabIndex = 1;
            this.dw_header.EditChanged += new System.EventHandler(this.dw_header_editchanged);
            this.dw_header.Click += new System.EventHandler(this.dw_header_Click);
            // 
            // cb_selectfreq
            // 
            this.cb_selectfreq.Location = new System.Drawing.Point(466, 114);
            this.cb_selectfreq.Name = "cb_selectfreq";
            this.cb_selectfreq.Size = new System.Drawing.Size(108, 23);
            this.cb_selectfreq.TabIndex = 9;
            this.cb_selectfreq.Text = "Select Freqencies";
            this.cb_selectfreq.UseVisualStyleBackColor = true;
            this.cb_selectfreq.Click += new System.EventHandler(this.cb_selectfreq_Click);
            // 
            // dw_details
            // 
            this.dw_details.DataObject = null;
            this.dw_details.FireConstructor = false;
            this.dw_details.Location = new System.Drawing.Point(16, 225);
            this.dw_details.Name = "dw_details";
            this.dw_details.Size = new System.Drawing.Size(457, 168);
            this.dw_details.TabIndex = 2;
            this.dw_details.Click += new System.EventHandler(this.dw_details_clicked);
            // 
            // cb_open
            // 
            this.cb_open.Enabled = false;
            this.cb_open.Location = new System.Drawing.Point(480, 240);
            this.cb_open.Name = "cb_open";
            this.cb_open.Size = new System.Drawing.Size(75, 23);
            this.cb_open.TabIndex = 3;
            this.cb_open.Tag = "ComponentName=Customer;ComponentPrivilege=R;ComponentPrivilege=M;";
            this.cb_open.Text = "&Open";
            this.cb_open.Click += new System.EventHandler(this.cb_open_clicked);
            // 
            // cb_transfer
            // 
            this.cb_transfer.Enabled = false;
            this.cb_transfer.Location = new System.Drawing.Point(480, 323);
            this.cb_transfer.Name = "cb_transfer";
            this.cb_transfer.Size = new System.Drawing.Size(75, 23);
            this.cb_transfer.TabIndex = 6;
            this.cb_transfer.Tag = "ComponentName=Address;ComponentPrivilege=M;";
            this.cb_transfer.Text = "&Transfer";
            this.cb_transfer.Click += new System.EventHandler(this.cb_transfer_clicked);
            // 
            // cb_remove
            // 
            this.cb_remove.Enabled = false;
            this.cb_remove.Location = new System.Drawing.Point(480, 295);
            this.cb_remove.Name = "cb_remove";
            this.cb_remove.Size = new System.Drawing.Size(75, 23);
            this.cb_remove.TabIndex = 5;
            this.cb_remove.Tag = "ComponentName=Address;ComponentPrivilege=M;";
            this.cb_remove.Text = "&Move Out";
            this.cb_remove.Click += new System.EventHandler(this.cb_remove_clicked);
            // 
            // cb_new
            // 
            this.cb_new.Enabled = false;
            this.cb_new.Location = new System.Drawing.Point(480, 267);
            this.cb_new.Name = "cb_new";
            this.cb_new.Size = new System.Drawing.Size(75, 23);
            this.cb_new.TabIndex = 4;
            this.cb_new.Tag = "ComponentName=Customer;ComponentPrivilege=C;";
            this.cb_new.Text = "&New";
            this.cb_new.Click += new System.EventHandler(this.cb_new_clicked);
            // 
            // gb_details
            // 
            this.gb_details.Location = new System.Drawing.Point(8, 210);
            this.gb_details.Name = "gb_details";
            this.gb_details.Size = new System.Drawing.Size(560, 190);
            this.gb_details.TabIndex = 0;
            this.gb_details.TabStop = false;
            this.gb_details.Text = "Customers / Occupants";
            // 
            // cb_save
            // 
            this.cb_save.Location = new System.Drawing.Point(408, 410);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 7;
            this.cb_save.Text = "Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_close
            // 
            this.cb_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_close.Location = new System.Drawing.Point(490, 410);
            this.cb_close.Name = "cb_close";
            this.cb_close.Size = new System.Drawing.Size(75, 23);
            this.cb_close.TabIndex = 8;
            this.cb_close.Text = "Close";
            this.cb_close.Click += new System.EventHandler(this.cb_close_clicked);
            // 
            // dw_movement
            // 
            this.dw_movement.DataObject = null;
            this.dw_movement.FireConstructor = false;
            this.dw_movement.Location = new System.Drawing.Point(196, 517);
            this.dw_movement.Name = "dw_movement";
            this.dw_movement.Size = new System.Drawing.Size(162, 139);
            this.dw_movement.TabIndex = 0;
            this.dw_movement.Tag = "ComponentName=Hidden;";
            this.dw_movement.Visible = false;
            // 
            // cb_restore
            // 
            this.cb_restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_restore.Location = new System.Drawing.Point(170, 410);
            this.cb_restore.Name = "cb_restore";
            this.cb_restore.Size = new System.Drawing.Size(85, 23);
            this.cb_restore.TabIndex = 8;
            this.cb_restore.Text = "Restore Custs";
            this.cb_restore.Click += new System.EventHandler(this.cb_restore_clicked);
            // 
            // WMaintainAddress
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_close;
            this.ClientSize = new System.Drawing.Size(677, 440);
            this.Controls.Add(this.dw_header);
            this.Controls.Add(this.dw_details);
            this.Controls.Add(this.cb_open);
            this.Controls.Add(this.cb_transfer);
            this.Controls.Add(this.cb_remove);
            this.Controls.Add(this.cb_new);
            this.Controls.Add(this.gb_details);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.cb_close);
            this.Controls.Add(this.dw_movement);
            this.Controls.Add(this.cb_restore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WMaintainAddress";
            this.Text = "Address";
            this.Controls.SetChildIndex(this.cb_restore, 0);
            this.Controls.SetChildIndex(this.dw_movement, 0);
            this.Controls.SetChildIndex(this.cb_close, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.gb_details, 0);
            this.Controls.SetChildIndex(this.cb_new, 0);
            this.Controls.SetChildIndex(this.cb_remove, 0);
            this.Controls.SetChildIndex(this.cb_transfer, 0);
            this.Controls.SetChildIndex(this.cb_open, 0);
            this.Controls.SetChildIndex(this.dw_details, 0);
            this.Controls.SetChildIndex(this.dw_header, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.dw_header.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
   
        private void dw_header_Click(object sender, EventArgs e) //added by jlwang
        {
            dw_header.URdsDw_GetFocus(null, null);
        }

        private void AttachDwEvents()
        {
            //? dw_header.ItemFocusChanged += new EventHandler(dw_header_itemfocuschanged);
            dw_header.ItemChanged += new EventHandler(dw_header_itemchanged);
            dw_header.LostFocus += new EventHandler(dw_header_losefocus);
            dw_header.URdsDwEditChanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_header_editchanged);
            dw_header.URdsDwItemFocuschanged += new  NZPostOffice.RDS.Controls.EventDelegate(dw_header_itemfocuschanged);
            dw_header.PfcPreUpdate += new UserEventDelegate1(dw_header_pfc_preupdate);// UserEventDelegate(dw_header_pfc_preupdate);
            dw_header.PfcValidation += new UserEventDelegate1(dw_header_pfc_validation);//UserEventDelegate(dw_header_pfc_validation);
            dw_details.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_details_constructor);
            dw_details.RowFocusChanged += new EventHandler(dw_details_rowfocuschanged);
            ((DAddressOccupants)dw_details.DataObject).CellClick += new EventHandler(dw_details_clicked);
//!            dw_details.ItemChanged += new EventHandler(dw_details_itemchanged);
            ((DAddressOccupants)dw_details.DataObject).CellDoubleClick += new EventHandler(dw_details_doubleclicked);
            dw_details.PfcInsertRow += new   NZPostOffice.RDS.Controls.UserEventDelegate(dw_details_pfc_insertrow);
            dw_movement.Constructor += new  NZPostOffice.RDS.Controls.UserEventDelegate(dw_movement_constructor);
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

        private Button cb_selectfreq;
    }
}
