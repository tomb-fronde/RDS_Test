using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using System.Reflection;

namespace NZPostOffice.ODPS.Controls
{
    public class WMaster : FormBase
    {
        #region Define
        //public bool ib_BypassSecurity;
        //public bool ib_NationalAccessRequired ;
        //public string is_ComponentName = String.Empty;

        public int? il_regionid;

        protected string is_access;

        bool ib_close = false;

        // Required designer variable.
        private System.ComponentModel.IContainer components = null;

        #endregion

        public WMaster()
        {
            this.InitializeComponent();
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Icon = global::NZPostOffice.Shared.Properties.Resources.SAFE02;
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

        protected override void InitializationFormEvent()
        {
            this.Shown += new EventHandler(WMaster_Shown);
            this.FormClosing += new FormClosingEventHandler(FormBase_FormClosing);
            this.FormClosed += new FormClosedEventHandler(FormBase_FormClosed);
        }

        public void WMaster_Shown(object sender, EventArgs e)
        {
            this.Resize += new EventHandler(resize);
            InvokeDwConstructor(this);
            pfc_preopen();
            open();
            show();
            pfc_postopen();
        }

        private void InvokeDwConstructor(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is URdsDw)
                {
                    (c as URdsDw).FireConstructor = true;
                }
                else if (c is TabControl || c is TabPage)
                {
                    InvokeDwConstructor(c);
                }
            }
        }

        public override void show()
        {
            //Purpose: 	Set up security services
            //Author: 	Rex Bustria
            //          Show ( This)
            //If This.of_Set_Security ( )=1 Then
            //   This.of_Check_NationalAccess ( )
            //   This.ResumeLayout ( false )
            //End if
        }

        public override int of_set_regionid(int? al_id)
        {
            il_regionid = al_id;
            return 0;
        }

        public override int? of_get_regionid()
        {
            return il_regionid;
        }

        public override int of_set_security()
        {
            // of_Set_Security
            // Purpose: 	Set up security. Usually called from pfc_postopen
            // 				- Calls functions to enable hidden/disabled controls
            // 				- Calls functions to enable menuitems corresponding to the associated menu
            // Author: 	Rex Bustria
            //Menu lm_Menu;
            Cursor.Current = Cursors.WaitCursor;

            // Check if security is bypassed ( usually from simple popup windows)
            if (ib_BypassSecurity)
            {
                //return 1;
                return SUCCESS;
            }
            // This.Setredraw ( FALSE)
            //StringArray ls_args = new StringArray();
            int ll_Ctr;
            // Some advanced stuff for you: Check if the security manager is actually declared
            //ClassDefinition cd_gnv_App;
            Type cd_gnv_App;
            //Cl_VariableDefinitionArray vl_gnv_App = new Cl_VariableDefinitionArray();
            MemberInfo[] vl_gnv_App;

            string ls_VarDefClass;
            bool lb_FoundSecurityManager = false;
            bool lb_valid = false;

            // Get the class definition for gnv_App
            //cd_gnv_App = gnv_app.ClassDefinition;
            cd_gnv_App = StaticVariables.gnv_app.GetType();
            // If classdefinition found
            //lb_valid = IsValid(cd_gnv_App);
            //if (lb_valid)
            //{
            //    // Get its variable list
            //    vl_gnv_App = cd_gnv_App.VariableList;
            //    // Inspect the variable list and find inv_Security_manager
            //    for (ll_Ctr = 1; ll_Ctr <= vl_gnv_App.UpperBound; ll_Ctr++)
            //    {
            //        ls_VarDefClass = vl_gnv_App[ll_Ctr].ClassName();
            //        if (Lower(vl_gnv_App[ll_Ctr].Name) == "inv_security_manager") {
            //            lb_FoundSecurityManager = true;
            //            break;
            //        }
            //    }
            //}
            if (cd_gnv_App != null)
            {
                vl_gnv_App = cd_gnv_App.GetMembers();
                foreach (MemberInfo var in vl_gnv_App)
                {
                    ls_VarDefClass = var.Name;
                    if (ls_VarDefClass.ToLower() == "inv_security_manager")
                    {
                        lb_FoundSecurityManager = true;
                        break;
                    }
                }
            }
            if (!lb_FoundSecurityManager)
            {
                MessageBox.Show("Security Initialisation Failure: Security services not available.\r\nInv_security" + "_manager must be declared.\r\nPlease contact your system administrator", "Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
                //return -(1);
                return FAILURE;
            }
            //if ( this.of_get_componentname().Len() > 0) 
            if (this.of_get_componentname().Length > 0)
            {
                if (!(StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid(this.of_get_componentname()))))
                {
                    // 		Messagebox ( "Security","You have no access to this window")
                    // 		Close ( This)
                    // 		Return FAILURE
                }
            }
            // Enable CRUD menuitems for this component
            //lb_valid = IsValid(gnv_app);
            //if (lb_valid) 
            if (StaticVariables.gnv_app != null)
            {
                // Lookup menu from cache - caching menus don't work too well
                // 	- some menu items disabled for no reason
                // lm_Menu = gnv_App.of_Get_MenuCache ( ).of_Get_Menu ( Classname ( ))
                //lb_valid = IsValid(gnv_app.of_Get_SecurityManager());
                //if (lb_valid)
                if (StaticVariables.gnv_app.of_get_securitymanager() != null)
                {
                    // Enable associated menuitems
                    //lb_valid = IsValid(lm_Menu);
                    //if (lb_valid) 
                    if (this.IsMdiContainer)
                    {
                        // This.Post ChangeMenu ( lm_Menu)
                        StaticVariables.gnv_app.of_get_securitymanager().of_enable_component_menuitems(this.MainMenuStrip);
                    }
                    else
                    {
                        //gnv_app.of_Get_SecurityManager().of_Enable_Component_MenuItems(MenuID);
                        if (this.MdiParent != null)
                            StaticVariables.gnv_app.of_get_securitymanager().of_enable_component_menuitems(this.MdiParent.MainMenuStrip);
                        // gnv_App.of_Get_MenuCache ( ).of_Set_Menu ( Menuid, Classname ( ))
                    }
                    // For each object within this window, enable access
                    StaticVariables.gnv_app.of_get_securitymanager().of_enable_controls(this);
                }
            }
            this.ResumeLayout(false);
            return 1;
        }

        public override int of_set_componentname(string as_name)
        {
            is_ComponentName = as_name;
            return 1;
        }

        public override string of_get_componentname()
        {
            return is_ComponentName;
        }

        public override int of_check_nationalaccess()
        {
            // Require national access to this component
            //int ll_UserRegionId;
            int? ll_UserRegionId;
            // Check if national access flag is set
            if (this.of_get_nationalaccess())
            {
                // Get user's region
                ll_UserRegionId = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
                if (ll_UserRegionId == null && StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid(this.of_get_componentname())))
                {
                    // 	Allowed
                }
                else
                {
                    // Not allowed
                    MessageBox.Show("Only users with National access are allowed to open this window.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Post 'close' Event call
                    this.Close();
                }
            }
            //return 1;
            return SUCCESS;
        }

        public override bool of_get_nationalaccess()
        {
            // Return the flag indicating whether national access is required for this window.
            // If true, the user's own region must be National
            return ib_NationalAccessRequired;
        }

        public override int of_set_nationalaccess(bool ab_access)
        {
            ib_NationalAccessRequired = ab_access;
            return 1;
        }

        public override int of_bypass_security(bool ab_Bypass)
        {
            ib_BypassSecurity = ab_Bypass;
            return 1;
        }

        protected virtual bool of_close()
        {
            return ib_close;
        }

        protected virtual string of_getaccess()
        {
            return is_access;
        }

        protected virtual int of_setaccess(string s_access)
        {
            is_access = s_access;
            return 0;
        }
    }
}