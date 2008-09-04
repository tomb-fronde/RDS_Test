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
            this.SuspendLayout();
            this.dw_header = new URdsDw();
            this.dw_details = new URdsDw();
            this.cb_open = new UCb();
            this.cb_transfer = new UCb();
            this.cb_remove = new UCb();
            this.cb_new = new UCb();
            this.gb_details = new UGb();
            this.cb_save = new UCb();
            this.cb_close = new UCb();
            this.dw_movement = new URdsDw();
            this.cb_restore = new Button();

            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Text = "Address";
            this.ClientSize = new System.Drawing.Size(677, 440);
            // 
            // dw_header
            // 
            //? dw_header.vscrollbar = false;
            //!dw_header.DataObject = new DAddressDetails();
            //!dw_header.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_header.TabIndex = 1;
            this.dw_header.Size = new Size(650, 200);
            this.dw_header.Location = new Point(5, 5);
 
            dw_header.EditChanged +=new EventHandler(dw_header_editchanged);
            dw_header.Click  += new EventHandler(dw_header_Click); //added for focus the dw

            //dw_header.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_header_constructor);
            //((PictureBox)dw_header.GetControlByName("contract_button")).Click += new EventHandler(dw_header_clicked);
            //((DataEntityCombo)dw_header.GetControlByName("tc_id")).SelectedValueChanged += new EventHandler(dw_header_itemchanged);
            //((TextBox)dw_header.GetControlByName("road_name")).Leave += new EventHandler(dw_header_itemchanged);


            // 
            // dw_details
            // 
            //!dw_details.DataObject = new DAddressOccupants();
            dw_details.TabIndex = 2;
            this.dw_details.Location = new Point(16, 225);
            this.dw_details.Size = new Size(457, 168);
            this.dw_details.Click +=new EventHandler(dw_details_clicked);
            // 
            // cb_open
            // 
            cb_open.Text = "&Open";
            cb_open.Enabled = false;
            cb_open.TabIndex = 3;
            this.cb_open.Location = new Point(480, 240);
            cb_open.Tag = "ComponentName=Customer;ComponentPrivilege=R;ComponentPrivilege=M;";
            cb_open.Click += new EventHandler(cb_open_clicked);
            // 
            // cb_transfer
            // 
            cb_transfer.Text = "&Transfer";
            cb_transfer.Enabled = false;
            cb_transfer.TabIndex = 6;
            this.cb_transfer.Location = new Point(480, 323);
            cb_transfer.Tag = "ComponentName=Address;ComponentPrivilege=M;";
            cb_transfer.Click += new EventHandler(cb_transfer_clicked);
            // 
            // cb_remove
            // 
            cb_remove.Text = "&Move Out";
            cb_remove.Enabled = false;
            cb_remove.TabIndex = 5;
            this.cb_remove.Location = new Point(480, 295);
            cb_remove.Tag = "ComponentName=Address;ComponentPrivilege=M;";
            cb_remove.Click += new EventHandler(cb_remove_clicked);
            // 
            // cb_new
            // 
            cb_new.Text = "&New";
            cb_new.Enabled = false;
            cb_new.TabIndex = 4;
            this.cb_new.Location = new Point(480, 267);
            cb_new.Tag = "ComponentName=Customer;ComponentPrivilege=C;";
            cb_new.Click += new EventHandler(cb_new_clicked);
            // 
            // gb_details
            // 
            gb_details.Text = "Customers / Occupants";
            gb_details.TabIndex = 0;
            this.gb_details.Size = new Size(560,190);
            this.gb_details.Location = new Point(8, 210);
            // 
            // cb_save
            // 
            this.AcceptButton = cb_save;
            cb_save.Text = "Save";
            cb_save.TabIndex = 7;
            this.cb_save.Location = new Point(408, 410);
            cb_save.Click += new EventHandler(cb_save_clicked);
            // 
            // cb_close
            // 
            this.CancelButton = cb_close;
            cb_close.Text = "Close";
            cb_close.TabIndex = 8;
            this.cb_close.Location = new Point(490, 410);
            cb_close.Click += new EventHandler(cb_close_clicked);
            // 
            // dw_movement
            // 
            //!dw_movement.DataObject = new DAddressOccupantsMovement();
            dw_movement.TabIndex = 0;
            this.dw_movement.Location = new Point(196, 517);
            dw_movement.Visible = false;
            dw_movement.Tag = "ComponentName=Hidden;";
            // 
            // cb_restore
            // 
            cb_restore.Text = "Restore Custs";
            this.cb_restore.Location = new Point(170, 410);  
            this.cb_restore.Size = new Size(85, 23);
            cb_restore.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_restore.TabIndex = 8;
            cb_restore.Click += new EventHandler(cb_restore_clicked);

            //
            // st_label;
            //
            this.st_label.Location = new Point(5, 410);
            this.st_label.Size = new Size(150, 23);
            this.st_label.Text = "w_maintain_address";

            Controls.Add(dw_header);
            Controls.Add(dw_details);
            Controls.Add(cb_open);
            Controls.Add(cb_transfer);
            Controls.Add(cb_remove);
            Controls.Add(cb_new);
            Controls.Add(gb_details);
            Controls.Add(cb_save);
            Controls.Add(cb_close);
            Controls.Add(dw_movement);
            Controls.Add(cb_restore);
            this.ResumeLayout();
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
    }
}
