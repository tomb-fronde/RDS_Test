using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.DataControls.OdpsLib;
using NZPostOffice.ODPS.Entity.OdpsLib;
using NZPostOffice.ODPS.DataService;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    public partial class WPasswordChange : WMaster 
    {
        #region Define
        public bool b_canclose = false;

        public string is_oldpassword = "";
        #endregion

        public WPasswordChange()
        {
            InitializeComponent();

            this.dw_1.DataObject = new DPassword();
        }

        public override void open()
        {
            //base.open();
            dw_1.InsertItem<Password>(0);
            StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
            is_oldpassword = StaticVariables.gnv_app.of_get_parameters().of_get_stringparm();
        }

        #region Events
        public void cb_ok_clicked(object sender, EventArgs e)
        {
            //Not parsed PB function body

            string sOldPassword;
            string sNewPassword;
            string sPasswordchk;
            string OldPass;
            //date dExpiry
            DateTime dExpiry;
          
            dw_1.AcceptText();
            sOldPassword = dw_1.GetItem<Password>(0).OldPassword;
            sNewPassword = dw_1.GetItem<Password>(0).NewPassword;

            if(StaticFunctions.f_isempty(sOldPassword))
            {
                MessageBox.Show("Please enter the current password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["old_password"].Focus();
                return;
            }

            if(StaticFunctions.f_isempty(sNewPassword))
            {
                MessageBox.Show("Please enter the new password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password"].Focus();
                return;
            }
            else 
            {
                if(sNewPassword.Length < 6)
                {
                    MessageBox.Show("The new password must be at least 6 characters long", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_1.DataObject.Controls["new_password"].Focus();
                    return;
                }
            }

            if(StaticFunctions.f_isempty(dw_1.GetItem<Password>(0).NewPasswordCheck))
            {
                MessageBox.Show("Please enter the new password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password_check"].Focus();
                return;
            }

            sOldPassword = StaticFunctions.f_encrypt(sOldPassword.ToUpper());
            if (sOldPassword != is_oldpassword)
            {
                MessageBox.Show("The current password is not correct", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["old_password"].Focus();
                return;
            }

            //Encrypt to check that new password is not the same as old password
            sNewPassword = StaticFunctions.f_encrypt(sNewPassword.ToUpper());

            if(sNewPassword == sOldPassword)
            {
                MessageBox.Show("The new password cannot be the same as the old password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password"].Focus();
                return;
            }

            //Encrypt to check the the user has re-entered the password correctly
            sPasswordchk = dw_1.GetItem<Password>(0).NewPasswordCheck;
            sPasswordchk = StaticFunctions.f_encrypt(sPasswordchk.ToUpper());

            if(sNewPassword != sPasswordchk)
            {
                MessageBox.Show("The new password and its check password are not the same", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_1.DataObject.Controls["new_password"].Focus();
                return;
            }
            //Decrypt to check that password has not been used before
            sNewPassword = StaticFunctions.f_encrypt(sNewPassword);

            //select up_password into :OldPass from rd.used_password where up_code = :g_security.u_usercode and up_password = :sNewPassword using sqlca;
            OldPass = ODPSDataService.SelectUpPassword(StaticVariables.LoginId, sNewPassword);
          
            if(sNewPassword == OldPass)
            {
                MessageBox.Show("You cannot use a previously used password, please select another one",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            dExpiry = DateTime.Now.AddDays(40);
            sNewPassword = StaticFunctions.f_encrypt(sNewPassword);

            //update rd.userids set u_password = :sNewPassword, u_password_expiry = :dExpiry, u_grace_logins = 4 where u_code = :g_security.u_usercode; commit;
            //UPDATE rd.rds_user_id SET ui_password = :sNewPassword, ui_password_expiry = :dExpiry, ui_grace_logins = 4 WHERE ui_userid = :ls_ui_userid USING SQLCA; COMMIT;

            //Decrypt to save to used_password table

            sOldPassword = StaticFunctions.f_decrypt(sOldPassword);
            
            //insert into rd.used_password ( up_code,up_password) values ( :g_security.u_usercode,:sOldPassword) using SQLCA; commit;
            ODPSDataService.InsertUpPassword(StaticVariables.LoginId, sOldPassword);

            StaticVariables.gnv_app.of_get_parameters().stringparm = sNewPassword;
            StaticVariables.gnv_app.of_get_parameters().booleanparm = true;

            this.Close();
            //string sOldPassword
            //string sNewPassword
            //date dExpiry
            //
            //dw_1.accepttext ( )
            //
            //sOldPassword = upper ( dw_1.GetItemString ( 1, "old_password"))
            //sNewPassword = upper ( dw_1.GetItemString ( 1, "new_password"))
            //
            //if f_Empty ( sOldPassword) then
            //	MessageBox ( Parent.title, "Please enter the current password")
            //	dw_1.DataControl["old_password"].Focus()
            //	return
            //end if
            //
            //if f_Empty ( sNewPassword) then
            //	MessageBox ( Parent.Title, "Please enter the new password")
            //	dw_1.DataControl["new_password"].Focus()
            //	return
            //else
            //	if len ( sNewPassword)  < 6 then
            //		MessageBox ( Parent.Title, "The new password must be at least 6 characters long")
            //		dw_1.DataControl["new_password"].Focus()
            //		return
            //	end if
            //end if
            //
            //if f_Empty ( dw_1.GetItemString ( 1, "new_password_check")) then
            //	MessageBox ( Parent.Title, "Please enter the new password")
            //	dw_1.DataControl["new_password_check"].Focus()
            //	return
            //end if
            //
            //if sOldPassword <> upper ( g_security.Password) then
            //	MessageBox ( Parent.Title, "The current password is not correct")
            //	dw_1.DataControl["old_password"].Focus()
            //	return
            //end if
            //
            //if sNewPassword = sOldPassword then
            //	MessageBox ( Parent.Title, "The new password cannot be the same as the old password")
            //	dw_1.DataControl["new_password"].Focus()
            //	return
            //end if
            //
            //if sNewPassword <> upper ( dw_1.getitemstring ( 1, "new_password_check")) then
            //	messagebox ( Parent.Title, "The new password and its check password are not the same")
            //	dw_1.DataControl["new_password"].Focus()
            //	return
            //end if
            //
            //dExpiry = StaticMethods.Relativedate( today ( ), 40)
            //
            //update rd.userids
            //	set u_password = :sNewPassword,
            //	    u_password_expiry = :dExpiry,
            //	    u_grace_logins = 4
            //where u_code = :g_security.u_usercode;
            //
            //commit;
            //
            //g_security.password = sNewPassword
            //g_Parameters.BooleanParm = true
            //
            //close ( parent)

        }

        public void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}