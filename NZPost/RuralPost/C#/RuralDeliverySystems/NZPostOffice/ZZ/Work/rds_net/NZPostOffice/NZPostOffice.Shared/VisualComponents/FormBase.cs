using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.Shared.VisualComponents
{
    // TJB  RPCR_117  July-2018
    // Added NOTSAVED and changed CANCLE to CANCEL

    /// <summary>
    /// Application windows ancester class
    /// </summary>
    public partial class FormBase : Form
    {
        #region Define

        public const int SUCCESS = 1;
        public const int FAILURE = -1;
        public const int NOTSAVED = 2;
        public const int CANCEL = 3;

        // Component associated with the window 
        public string is_ComponentName = String.Empty;

        // Region id associated with the window 
        public int? il_RegionId;

        // Bypass flag set by simple popups 
        public bool ib_BypassSecurity = false;

        // National access is required for the window 
        public bool ib_NationalAccessRequired;

        //  Logical Unit of Work -  SelfUpdatingObject - Save Process -  ( Attributes). 
        public bool ib_isupdateable = true;

        public bool ib_disableclosequery;

        //  Save process flag to include all objects in validation process. 
        public bool ib_alwaysvalidate;

        public bool ib_closestatus;

        private TextBox inforLabel;

        public bool ib_savestatus;

        #endregion

        public FormBase()
        {
            InitializeComponent();
            InitializationFormEvent();
        }

        protected virtual void InitializationFormEvent()
        {
            this.Shown += new EventHandler(FormBase_Shown);
            this.FormClosing += new FormClosingEventHandler(FormBase_FormClosing);
            this.FormClosed += new FormClosedEventHandler(FormBase_FormClosed);
        }

        protected void FormBase_Shown(object sender, EventArgs e)
        {
            open();
        }

        protected void FormBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }

        protected void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (closequery() == -1)
            //{
            //    e.Cancel = true;
            //}
        }

        public string ClassName
        {
            get
            {
                System.Text.StringBuilder sName = new System.Text.StringBuilder();
                for (int i = 0; i < Name.Length; i++)
                {
                    char c = Name[i];
                    if (i == 0 || char.IsLower(c))
                    {
                        sName.Append(c);
                    }
                    else if (char.IsUpper(c))//||char.IsDigit(c))
                    {
                        sName.Append("_" + c);
                    }
                    else
                    {
                        sName.Append(c);
                    }
                }
                return sName.ToString().ToLower();
            }
        }

        public FormBase GetFirstSheet()
        {
            return this.ActiveMdiChild as FormBase;
        }

        public FormBase GetNextSheet(FormBase curfrm)
        {
            bool bl = false;
            FormBase tmp_frm = null;
            foreach (FormBase frm in curfrm.MdiParent.MdiChildren)
            {
                //? if (tmp_frm == null) // temp_frm can never be null!
                //?    tmp_frm = frm;

                if (frm == curfrm)
                {
                    bl = true;
                }
                else if (bl)
                {
                    return frm;
                }
            }
            return tmp_frm;
        }

        public virtual void pfc_preopen()
        {
        }

        public virtual void pfc_postopen()
        {
        }

        public virtual int pfc_save()
        {
            return 1;
        }

        public virtual void pfc_exit()
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        public virtual void pfc_default()
        {
        }

        public virtual void pfc_cancel()
        {
        }

        public virtual int pfc_preclose()
        {
            return 1;
        }

        public virtual void show()
        {
        }

        public virtual void close()
        {
        }

        public virtual int closequery()
        {
            return 1;
        }

        public virtual void open()
        {
        }

        public virtual void resize(object sender, EventArgs args)
        {
        }

        public virtual int of_updatechecks()
        {
            return 0; // should check all controls for modifications/
        }

        public virtual int of_set_componentname(string as_componentname)
        {
            // Purpose: Sets the component name associated with this window,
            // 					usually called at pfc_preopen
            // Author: Rex Bustria
            is_ComponentName = as_componentname;
            return 1;
        }

        public virtual string of_get_componentname()
        {
            // Purpose: Returns the component name associated with this window
            // 				- usually set by a component at preopen
            // Author:  Rex Bustria
            return is_ComponentName;
        }

        public virtual int of_set_security()
        {
            return SUCCESS;
        }

        public virtual int of_set_regionid(int? al_regionid)
        {
            // Purpose: Sets the region ID associated with this window
            // Author: Rex Bustria
            il_RegionId = al_regionid;
            return 1;
        }

        public virtual int? of_get_regionid()
        {
            // Purpose: Returns the region id associated with this window
            //          Set by the descendant winow eg contract
            // Author: Rex Bustria
            return il_RegionId;
        }

        public virtual int of_bypass_security(bool ab_BypassSecurity)
        {
            // Purpose: Allows certain windows to bypass security, eg certain information-only popups
            // 				to speed up window openings
            ib_BypassSecurity = ab_BypassSecurity;
            return SUCCESS;
        }

        public virtual bool of_issecurity_bypassed()
        {
            return ib_BypassSecurity;
        }

        public virtual int of_set_nationalaccess(bool ab_access)
        {
            // Set the flag indicating whether national access is required for this window.
            // If true, the user's own region must be National
            ib_NationalAccessRequired = ab_access;
            return SUCCESS;
        }

        public virtual bool of_get_nationalaccess()
        {
            // Return the flag indicating whether national access is required for this window.
            // If true, the user's own region must be National
            return ib_NationalAccessRequired;
        }

        public virtual int of_check_nationalaccess()
        {
            // Require national access to this component
            int ll_UserRegionId;
            // Check if national access flag is set
            if (this.of_get_nationalaccess())
            {
                // Get user's region
                //ll_UserRegionId = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
                //if (IsNull(ll_UserRegionId) && StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid(this.of_get_componentname())))
                //{
                //    // 	Allowed
                //}
                //else
                //{
                //    // Not allowed
                //    MessageBox.Show("Only users with National access are allowed to open this window.", Title);
                //    // Post 'close' Event call
                //    close(this);
                //}
            }
            return SUCCESS;
        }

        public virtual int pfc_saveas()
        {
            return 1;
        }

        public virtual void pfc_undo()
        {
        }

        public virtual void pfc_cut()
        {

        }

        public virtual void ue_refresh()
        {
        }

        public static T OpenSheet<T>(Form parent) where T : FormBase
        {
            if (!parent.IsMdiContainer)
                parent = parent.FindForm().MdiParent;

            T instance = Activator.CreateInstance<T>();
            foreach (Form frm in parent.MdiChildren)
            {
                if (instance.GetType() == frm.GetType())
                {
                    frm.Activate();
                    return instance;
                }
            }
            instance.MdiParent = parent;
            instance.Show();
            return instance;
        }

        private void InitializeComponent()
        {
            this.inforLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inforLabel
            // 
            this.inforLabel.Location = new System.Drawing.Point(2, -22);
            this.inforLabel.Name = "inforLabel";
            this.inforLabel.Size = new System.Drawing.Size(178, 20);
            this.inforLabel.TabIndex = 0;
            this.inforLabel.Visible = false;
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FormBase_KeyDown);
            this.Controls.Add(this.inforLabel);
            this.Name = "FormBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FormBase_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Insert) && (e.Modifiers == Keys.Alt))
            {
                inforLabel.Dock = DockStyle.Top;
                inforLabel.Left = this.Left + 10;
                inforLabel.Top = this.Top + 30;
                inforLabel.Size = new System.Drawing.Size(350, 20);
                inforLabel.Text = "Window is: " + this.GetType().Assembly.GetName().Name + "." + this.GetType().Name;
                inforLabel.Visible = true;
                inforLabel.BringToFront();
               //? Clipboard.Clear();
                Clipboard.SetText(this.GetType().Name);
                e.Handled = true;
            }
            else if (inforLabel.Visible == true)
            {
                inforLabel.Visible = false;
                inforLabel.SendToBack();
                e.Handled = true;
            }
        }
    }
}
