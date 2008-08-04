using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using System.Collections.Generic;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Menus;
using System.Reflection;
using NZPostOffice.Shared.Managers;

namespace NZPostOffice.RDS.Controls
{
    public class WMaster : FormBase
    {
        #region Define

        // Component associated with the window 
        //?public string is_ComponentName = String.Empty;

        // Region id associated with the window 
        //?public int il_RegionId;

        // Bypass flag set by simple popups 
        //?public bool ib_BypassSecurity = false;

        // National access is required for the window 
        //?public bool ib_NationalAccessRequired;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public MSheet m_sheet;

        #endregion

        public WMaster()
        {
            this.InitializeComponent();
        }

        #region Form Event & Methods
        protected override void InitializationFormEvent()
        {
            this.Shown += new EventHandler(WMaster_Shown);
            this.FormClosing += new FormClosingEventHandler(FormBase_FormClosing);
            this.FormClosed += new FormClosedEventHandler(FormBase_FormClosed);
        }

        public void WMaster_Shown(object sender, EventArgs e)
        {
            this.Resize += new EventHandler(resize);
            //RaiseDwConstructor();
            InvokeDwConstructor(this);
            pfc_preopen();
            open();
            show();
            pfc_postopen();
        }

        protected virtual void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            ib_closestatus = true;
            if (closequery() == 1)
            {
                e.Cancel = true;
            }
            ib_closestatus = false;
        }

        private void InvokeDwConstructor(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is URdsDw)
                {
                    (c as URdsDw).FireConstructor = true;
                }
                else if (c is TabControl || c is TabPage || c is TableLayoutPanel)//"c is TableLayoutPanel" added by hhuang 31/07/07,for the dw's constructor in multi-panel
                {
                    InvokeDwConstructor(c);
                }
            }
        }

        public override void show()
        {
            // Purpose: 	Set up security services
            // Author: 	Rex Bustria
            if (this.of_set_security() == SUCCESS)
            {
                this.of_check_nationalaccess();
            }
        }

        public override void open()
        {
            base.open();
        }

        public override int closequery()
        {
            if (ib_disableclosequery)
                return 0;
            return CheckUpdate(this);
        }

        private int CheckUpdate(Control control)
        {
            DialogResult iDialog;
            int i_check = -1;
            foreach (Control c in control.Controls)
            {
                if (c is URdsDw)
                {
                    if (
                            (c as URdsDw).DataObject != null && //pp! added check for null DataObject as it threw exception if null
                            (
                                (((URdsDw)c).ModifiedCount() > 0 || ((URdsDw)c).DataObject.DeletedCount > 0) && ((URdsDw)c).of_GetUpdateable()
                            )
                        )
                    {
                        int li_rc = ((URdsDw)c).PfcValidation();

                        if (li_rc == 0)
                        {
                            i_check = 0;
                            break;
                        }
                        else if (li_rc < 0)
                        {
                            //if (IsValid(StaticVariables.gnv_app.inv_error)) 
                            //{
                            //    li_msg = StaticVariables.gnv_app.inv_error.of_message("pfc_closequery_failsvalidation", ls_msgparms, StaticVariables.gnv_app.iapp_object.DisplayName);
                            //}
                            //else
                            //{
                            iDialog = MessageBox.Show("The information entered does not pass validation and " + "must be corrected before changes can be saved.\r\n\r\n" + "Close without saving changes?", StaticVariables.MainMDI.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            //}
                            if (iDialog == DialogResult.Yes)
                            {
                                i_check = 0;
                                break;
                            }
                            else
                            {
                                i_check = 1;
                                break;
                            }
                        }
                        else
                        {
                            iDialog = MessageBox.Show("Do you want to save changes?", StaticVariables.MainMDI.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                            if (iDialog == DialogResult.Yes)
                            {
                                ((URdsDw)c).Save();
                                i_check = 0;//in PB, 0  Allow the window to be closed   1  Prevent the window from closing
                                break;
                            }
                            else if (iDialog == DialogResult.No)
                            {
                                i_check = 0;
                                break;
                            }
                            else
                            {
                                i_check = 1;
                                break;
                            }
                        }
                    }
                }
                else if (c is TabControl || c is TabPage || c is TableLayoutPanel)
                {
                    i_check = CheckUpdate(c);
                    if (i_check == 1 || i_check == 0)
                    {
                        //i_check = 1;
                        break;
                    }
                }
            }

            return i_check;
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
            this.Icon = global::NZPostOffice.Shared.Properties.Resources.RDS;//.RDSYSTAB;
            this.FormClosing += new FormClosingEventHandler(WMaster_FormClosing);
            this.ResumeLayout();
        }

        void WMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
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

        #region Methods
        public override int of_set_componentname(string as_componentname)
        {
            // Purpose: Sets the component name associated with this window,
            // 					usually called at pfc_preopen
            // Author: Rex Bustria
            is_ComponentName = as_componentname;
            return 1;
        }

        public override string of_get_componentname()
        {
            // Purpose: Returns the component name associated with this window
            // 				- usually set by a component at preopen
            // Author:  Rex Bustria
            return is_ComponentName;
        }

        public override int of_set_security()
        {
            MenuStrip lm_Menu;
            Cursor.Current = Cursors.WaitCursor;

            if (ib_BypassSecurity)
            {
                this.ResumeLayout(false);
                return SUCCESS;
            }
            this.SuspendLayout();

            Dictionary<int, string> ls_args = new Dictionary<int, string>();
            int ll_Ctr;

            Type cd_gnv_App;
            MemberInfo[] vl_gnv_App;

            string ls_VarDefClass;
            bool lb_FoundSecurityManager = true;

            cd_gnv_App = StaticVariables.gnv_app.GetType();

            if ((cd_gnv_App != null))
            {
                vl_gnv_App = cd_gnv_App.GetMembers();
                //for (ll_Ctr = 1; ll_Ctr <= vl_gnv_App.UpperBound; ll_Ctr++)
                //{
                //    ls_VarDefClass = vl_gnv_App[ll_Ctr].ClassName();
                //    if (Lower(vl_gnv_App[ll_Ctr].Name) == "inv_security_manager")
                //    {
                //        lb_FoundSecurityManager = true;
                //        break;
                //    }
                //}
                foreach (MemberInfo var in vl_gnv_App)
                {
                    ls_VarDefClass = var.Name;
                    if (var.Name.ToLower() == "inv_security_manager")
                    {
                        lb_FoundSecurityManager = true;
                        break;
                    }
                }
            }

            if (!lb_FoundSecurityManager)
            {
                MessageBox.Show("Security Initialisation Failure: Security services not available.~r\nInv_security" + "_manager must be declared.~r\nPlease contact your system administrator", "Security", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
                return FAILURE;
            }
            if (this.of_get_componentname().Length > 0)
            {
            }

            if (StaticVariables.gnv_app != null)
            {
                if (StaticVariables.gnv_app.of_get_securitymanager() != null)
                {
                    if (this.IsMdiContainer)
                    {
                        StaticVariables.gnv_app.of_get_securitymanager().of_enable_component_menuitems(this.MainMenuStrip);
                    }
                    else
                    {
                        if (this.MdiParent != null) // may be a response! window
                            StaticVariables.gnv_app.of_get_securitymanager().of_enable_component_menuitems(this.MdiParent.MainMenuStrip);
                    }
                    StaticVariables.gnv_app.of_get_securitymanager().of_enable_controls(this);
                }
            }
            this.ResumeLayout(false);
            return SUCCESS;
        }

        public override int of_set_regionid(int? al_regionid)
        {
            il_RegionId = al_regionid;
            return 1;
        }

        public override int? of_get_regionid()
        {
            return il_RegionId;
        }

        public override int of_bypass_security(bool ab_BypassSecurity)
        {
            // Purpose: Allows certain windows to bypass security, eg certain information-only popups
            // 				to speed up window openings
            ib_BypassSecurity = ab_BypassSecurity;
            return SUCCESS;
        }

        public override bool of_issecurity_bypassed()
        {
            return ib_BypassSecurity;
        }

        public override int of_set_nationalaccess(bool ab_access)
        {
            // Set the flag indicating whether national access is required for this window.
            // If true, the user's own region must be National
            ib_NationalAccessRequired = ab_access;
            return SUCCESS;
        }

        public override bool of_get_nationalaccess()
        {
            // Return the flag indicating whether national access is required for this window.
            // If true, the user's own region must be National
            return ib_NationalAccessRequired;
        }

        public override int of_check_nationalaccess()
        {
            // Require national access to this component
            int? ll_UserRegionId;
            // Check if national access flag is set
            if (this.of_get_nationalaccess())
            {
                // Get user's region
                ll_UserRegionId = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
                if ((ll_UserRegionId == null) && StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid(this.of_get_componentname())))
                {
                    // 	Allowed
                }
                else
                {
                    // Not allowed
                    MessageBox.Show("Only users with National access are allowed to open this window.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);// Title);
                    // Post 'close' Event call
                    BeginInvoke(new delegateInvoke(closeInvoke));
                }
            }
            return SUCCESS;
        }

        private delegate void delegateInvoke();

        public virtual void closeInvoke()
        {
            this.Close();
        }
        #endregion
    }
}
