using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralbase;
using NZPostOffice.RDS.Entity.Ruralbase;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralbase
{
    public class WPasswordChange : WMaster
    {
        #region Define
        public bool b_canclose = false;

        public string is_oldpassword = "";

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_1;

        public Button cb_ok;

        public Button cb_cancel;

        #endregion

        public WPasswordChange()
        {
            this.InitializeComponent();
            this.ShowInTaskbar = false;
            this.Load += new EventHandler(WPasswordChange_Load);

            //jlwang:moved from IC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dw_1.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
            //jlwang:end
        }

        #region Methods
        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_bypass_security(true);
        }

        public override void show()
        {
            // 
        }
     
        public virtual void dw_1_constructor()
        {
            //? base.constructor();
            dw_1.of_SetUpdateable(false);
        }
        #endregion

        #region Form Events

        public virtual void WPasswordChange_Load(object sender, EventArgs args)
        {
            dw_1.InsertItem<Password>(dw_1.RowCount);
            StaticVariables.gnv_app.of_get_parameters().of_set_booleanparm(false);
            is_oldpassword = StaticVariables.gnv_app.of_get_parameters().of_get_stringparm();
        }
        #endregion

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_1 = new URdsDw();
            dw_1.DataObject = new DPassword();
            this.cb_ok = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_1);
            Controls.Add(cb_ok);
            Controls.Add(cb_cancel);
            this.Text = "Password Change";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(226, 142);
            // 
            // dw_1
            // 
            dw_1.VerticalScroll.Visible = false;
            dw_1.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_1.TabIndex = 1;
            dw_1.Size = new Size(212, 85);
            dw_1.Location = new Point(0, 0);
            //dw_1.Constructor +=new NZPostOffice.RDS.Controls.UserEventDelegate(dw_1_constructor);
            // 
            // cb_ok
            // 
            cb_ok.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.AcceptButton = cb_ok;
            cb_ok.Text = "&OK";
            cb_ok.TabIndex = 2;
            cb_ok.Size = new Size(54, 22);
            cb_ok.Location = new Point(50, 88);
            cb_ok.Click += new EventHandler(cb_ok_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "&Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Size = new Size(54, 22);
            cb_cancel.Location = new Point(111, 88);
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

        #region Event
        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //Not parsed PB function body

            string sOldPassword;
            string sNewPassword;
            DateTime dExpiry;
            string OldPass = "";
            string ls_ui_userid;
            int? ll_ui_id;
            dw_1.AcceptText();
            sOldPassword = dw_1.GetItem<Password>(0).OldPassword;
            sNewPassword = dw_1.GetItem<Password>(0).NewPassword;
            if (StaticFunctions.f_isempty(sOldPassword))
            {
                MessageBox.Show("Please enter the current password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["old_password"].Focus();
                return;
            }
            if (StaticFunctions.f_isempty(sNewPassword))
            {
                MessageBox.Show("Please enter the new password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password"].Focus();
                return;
            }
            else
            {
                if (sNewPassword.Length < 6)
                {
                    MessageBox.Show("The new password must be at least 6 characters long", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_1.DataObject.Controls["new_password"].Focus();
                    return;
                }
            }
            if (StaticFunctions.f_isempty(dw_1.GetItem<Password>(0).NewPasswordCheck))
            {
                MessageBox.Show("Please enter the new password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password_check"].Focus();
                return;
            }
            sOldPassword = StaticFunctions.f_encrypt(sOldPassword);
            if (sOldPassword != is_oldpassword)
            {
                MessageBox.Show("The current password is not correct", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["old_password"].Focus();
                return;
            }
            sOldPassword = StaticFunctions.f_decrypt(sOldPassword);
            if (sNewPassword == sOldPassword)
            {
                MessageBox.Show("The new password cannot be the same as the old password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password"].Focus();
                return;
            }
            if (sNewPassword != dw_1.GetItem<Password>(0).NewPasswordCheck)
            {
                MessageBox.Show("The new password and its check password are not the same", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password"].Focus();
                return;
            }
            ls_ui_userid = StaticVariables.LoginId;
            // Need to obtain the ui_id first
            /*? SELECT	ui_id
            INTO		:ll_ui_id
            FROM		rd.rds_user_id
            WHERE		ui_userid = :ls_ui_userid
            USING		SQLCA;
            SELECT	up_password 
            INTO		:OldPass
            FROM		rd.used_password
            WHERE		ui_id = :ll_ui_id
            AND		up_password = :sNewPassword
            USING		sqlca; */
            RDSDataService dataService = RDSDataService.GetUiid(ls_ui_userid);
            ll_ui_id = dataService.intVal;
            dataService = RDSDataService.GetUpPassword(ll_ui_id, sNewPassword);
            OldPass = dataService.strVal;
            if (sNewPassword == OldPass)
            {
                MessageBox.Show("You cannot use a previously used password, please select another one", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dExpiry = System.DateTime.Today.AddDays(40);
            sNewPassword = StaticFunctions.f_encrypt(sNewPassword);
            /*? UPDATE	rd.rds_user_id
            SET		ui_password = :sNewPassword,
            ui_password_expiry = :dExpiry,
            ui_grace_logins = 4
            WHERE		ui_userid = :ls_ui_userid
            USING		 SQLCA;
            COMMIT;
            INSERT INTO	rd.used_password ( ui_id,up_password)
            VALUES ( :ll_ui_id,:sOldPassword)
            COMMIT; */
            RDSDataService.UpdatePassword(ls_ui_userid, dExpiry, sNewPassword);
            RDSDataService.AddUsedPassword(sOldPassword, ll_ui_id);
            //g_security.password = sNewPassword
            StaticMessage.BooleanParm = true;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}