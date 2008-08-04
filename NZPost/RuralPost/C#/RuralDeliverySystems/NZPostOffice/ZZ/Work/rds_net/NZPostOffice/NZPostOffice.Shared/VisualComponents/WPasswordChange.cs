using System;
using System.Configuration;
using System.Windows.Forms;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.Shared.VisualComponents
{
    public partial class WPasswordChange : WResponse
    {
        public bool b_canclose = false;

        public string is_OldPassword = "";

        public WPasswordChange()
        {
            this.InitializeComponent();
            dw_1_constructor();
        }

        public void WPasswordChange_Load(object sender, EventArgs e)
        {
            dw_1.InsertItem<NZPostOffice.Entity.Password>(0);
            NZPostOffice.Shared.StaticMessage.BooleanParm = false;
            //is_OldPassword = NZPostOffice.Shared.StaticMessage.StringParm;
            is_OldPassword = StaticVariables.gnv_app.of_get_parameters().of_get_stringparm();
        }

        public override void pfc_preopen()
        {
            this.of_bypass_security(true);
        }

        public void dw_1_constructor()
        {
            // dw_1.of_SetUpdateable(false);
        }

        public virtual void cb_ok_clicked(object sender, EventArgs e)
        {
            //Not parsed PB function body
            string sOldPassword;
            string sNewPassword;
            System.DateTime dExpiry;
            string OldPass = null;
            string ls_ui_userid;
            int ll_ui_id = 0;
            dw_1.AcceptText();
            sOldPassword = dw_1.GetValue<string>(0, "old_password");
            sNewPassword = dw_1.GetValue<string>(0, "new_password");
            if (string.IsNullOrEmpty(sOldPassword))
            {
                MessageBox.Show("Please enter the current password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Controls["old_password"].Focus();
                return;
            }
            if (string.IsNullOrEmpty(sNewPassword))
            {
                MessageBox.Show("Please enter the new password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Controls["new_password"].Focus();
                return;
            }
            else
            {
                if (sNewPassword.Length < 6)
                {
                    MessageBox.Show("The new password must be at least 6 characters long", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_1.Controls["new_password"].Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(dw_1.GetValue<string>(0, "new_password_check")))
            {
                MessageBox.Show("Please enter the new password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Controls["new_password_check"].Focus();
                return;
            }
            sOldPassword = StaticFunctions.f_encrypt(sOldPassword);
            if (sOldPassword != is_OldPassword)
            {
                MessageBox.Show("The current password is not correct", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Controls["old_password"].Focus();
                return;
            }
            sOldPassword = StaticFunctions.f_decrypt(sOldPassword);
            if (sNewPassword == sOldPassword)
            {
                MessageBox.Show("The new password cannot be the same as the old password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Controls["new_password"].Focus();
                return;
            }
            if (sNewPassword != dw_1.GetValue<string>(0, "new_password_check"))
            {
                MessageBox.Show("The new password and its check password are not the same", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.Controls["new_password"].Focus();
                return;
            }
            ls_ui_userid = StaticVariables.LoginId;
            // Need to obtain the ui_id first
            /*SELECT	ui_id
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
            NZPostOffice.DataService.LoginService.GetUiId(ls_ui_userid, ref ll_ui_id);
            NZPostOffice.DataService.LoginService.GetOldPass(ll_ui_id, sNewPassword, ref OldPass);
            if (sNewPassword == OldPass)
            {
                MessageBox.Show("You cannot use a previously used password, please select another one", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dExpiry = DateTime.Today.AddDays(40);
            sNewPassword = StaticFunctions.f_encrypt(sNewPassword);
            /* UPDATE	rd.rds_user_id
                SET		ui_password = :sNewPassword,
                ui_password_expiry = :dExpiry,
                ui_grace_logins = 4
                WHERE		ui_userid = :ls_ui_userid
            USING		 SQLCA;
            COMMIT;
            INSERT INTO	rd.used_password ( ui_id,up_password)
                VALUES ( :ll_ui_id,:sOldPassword)
            COMMIT; */
            NZPostOffice.DataService.LoginService.UpdatePassword(dExpiry, ls_ui_userid, ll_ui_id, sOldPassword, sNewPassword);
            //g_security.password = sNewPassword
            StaticMessage.BooleanParm = true;
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
