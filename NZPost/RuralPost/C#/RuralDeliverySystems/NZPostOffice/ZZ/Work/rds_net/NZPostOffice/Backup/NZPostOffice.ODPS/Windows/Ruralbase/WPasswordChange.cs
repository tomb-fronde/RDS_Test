using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;
using System.Windows.Forms;
using NZPostOffice.ODPS.DataService;

namespace NZPostOffice.ODPS.Windows.Ruralbase
{
    public partial class WPasswordChange : WMaster
    {
        #region Define

        public bool b_canclose = false;

        public string is_OldPassword = "";

        #endregion

        public WPasswordChange()
        {
            InitializeComponent();
            this.dw_1.DataObject = new NZPostOffice.ODPS.DataControls.Ruralbase.DPassword();
        }

        public override void open()
        {
            dw_1.InsertItem<NZPostOffice.ODPS.Entity.Ruralbase.Password>(0);
            StaticVariables.gnv_app.of_get_parameters().of_set_booleanparm(false);
            is_OldPassword = StaticVariables.gnv_app.of_get_parameters().of_get_stringparm();
        }

        public override void pfc_preopen()
        {
            //?base.pfc_preopen();
            this.of_bypass_security(true);
        }

        public override void show()
        {
            // 
        }

        public virtual void constructor()
        {
            //base.constructor();
            dw_1.of_SetUpdateable(false);
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //Not parsed PB function body

            string sOldPassword;
            string sNewPassword;
            DateTime dExpiry;
            string OldPass = "";
            string ls_ui_userid;
            int ll_ui_id;
            dw_1.AcceptText();
            sOldPassword = dw_1.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.Password>(0).OldPassword;
            sNewPassword = dw_1.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.Password>(0).NewPassword;

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
            if (StaticFunctions.f_isempty(dw_1.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.Password>(0).NewPasswordCheck))
            {
                MessageBox.Show("Please enter the new password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password_check"].Focus();
                return;
            }
            sOldPassword = StaticFunctions.f_encrypt(sOldPassword);
            if (sOldPassword != is_OldPassword)
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
            if (sNewPassword != dw_1.GetItem<NZPostOffice.ODPS.Entity.Ruralbase.Password>(0).NewPasswordCheck)
            {
                MessageBox.Show("The new password and its check password are not the same", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password"].Focus();
                return;
            }
            ls_ui_userid = StaticVariables.LoginId;

            ls_ui_userid = StaticVariables.gnv_app.of_getuserid();
            // Need to obtain the ui_id first

            //SELECT ui_id INTO :ll_ui_id FROM rd.rds_user_id WHERE ui_userid = :ls_ui_userid USING SQLCA;
            //SELECT up_password INTO :OldPass FROM rd.used_password WHERE ui_id = :ll_ui_id AND up_password = :sNewPassword USING sqlca;

            ODPSDataService service = ODPSDataService.SelectRdsUserId(ls_ui_userid);
            ll_ui_id = service.rdsUserId.UiId;

            service = ODPSDataService.SelectUsedPassword(ll_ui_id, sNewPassword);
            OldPass = service.usedPassword.UpPassword;

            if (sNewPassword == OldPass)
            {
                MessageBox.Show("You cannot use a previously used password, please select another one", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dExpiry = System.DateTime.Today.AddDays(40);//dExpiry = dExpiry.AddDays(40);
            sNewPassword = StaticFunctions.f_encrypt(sNewPassword);

            // UPDATE rd.rds_user_id SET ui_password = :sNewPassword, ui_password_expiry = :dExpiry, ui_grace_logins = 4 WHERE ui_userid = :ls_ui_userid USING SQLCA; COMMIT;
            // INSERT INTO	rd.used_password ( ui_id,up_password) VALUES ( :ll_ui_id,:sOldPassword) COMMIT;

            service = ODPSDataService.UpdateRdsUserId(sNewPassword, dExpiry, ls_ui_userid);
            service = ODPSDataService.InserIntoUsedPassword(ll_ui_id, sOldPassword);

            //g_security.password = sNewPassword
            StaticVariables.gnv_app.of_get_parameters().of_set_booleanparm(true);
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
