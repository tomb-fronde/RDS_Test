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
using NZPostOffice.RDS.Windows.Ruralbase;

namespace NZPostOffice.RDS.Controls
{
    // TJB  Apr-2014
    // Created to allow setting of ib_disableclosequery when inaccessible
    // Used by WDriverInfoMaint
    public partial class WAncestorWindow : WMaster
    {
        #region Define
        public bool ib_setaudit = false;

        public string isDataWindow = String.Empty;

        private System.ComponentModel.IContainer components = null;

        #endregion

        public USt st_label;

        public WAncestorWindow()
        {
            m_sheet = new MSheet(this);
            this.InitializeComponent();

            //m_sheet_menu.SetFunctionalPart(m_sheet);
            //m_sheet_toolbar.SetFunctionalPart(m_sheet);
        }

        public virtual void ue_search()
        {
            wf_search();
        }

        public virtual void ue_reset()
        {
            wf_reset();
        }

        public virtual void ue_insertrow()
        {
            wf_insertrow();
        }

        public virtual void ue_deleterow()
        {
            wf_deleterow();
        }

        public virtual void ue_quicklist()
        {
            wf_quicklist();
        }

        public virtual int ue_scrollnext()
        {
            return wf_scroll("NextPage");
        }

        public virtual void ue_scrollprior()
        {
            wf_scroll("LastPage");
        }

        public virtual void ue_printzoom()
        {
            wf_printzoom();
        }

        public virtual string ue_get_dw()
        {
            return isDataWindow;
        }

        public virtual void activate()
        {
            //?base.activate();
            //?StaticVariables.gnv_app.of_set_activesheet(this);
        }

        // TJB  Apr-2014
        // Created to allow setting of ib_disableclosequery when inaccessible
        // Used by WDriverInfoMaint
        public virtual void set_disableclosequery(bool value)
        {
            ib_disableclosequery = value;
        }

        public virtual void pfc_preupdate()
        {
            //? base.pfc_preupdate();
            if (!(this.of_validate()))
            {
                //? return -(1);
            }
            else
            {
                //?return 1;
            }
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            st_label.Text = this.Name;//this is right not to change
        }

        public override void pfc_postopen()
        {
            // Turn off two toolbars that don't make sense on a sheet that 
            //security system has enabled
            //MSheet lm_Menu;
            //lm_Menu = m_sheet;
            //if (m_sheet != null)
            //{
            // m_sheet._m_contractors.Visible = false;
            // m_sheet._m_contracts.Visible = false;
            // m_sheet._m_addresses.Visible = false;
            //}
        }

        public override void resize(object sender, EventArgs args)
        {
            base.resize(sender, args);
            st_label.Top = this.Height - 50;// this.Height - 175;
        }

        public virtual void pfc_begintran()
        {
            //base.pfc_begintran();-- it not needed
            //int li_rc;
            //EXECUTE IMMEDIATE 'BEGIN TRANSACTION';
            //if (StaticVariables.sqlca.SQLCode == 0) {
            //    return 1;
            //}
            //else {
            //    return -(1);
            //}
        }

        public virtual void pfc_endtran(int ai_update_results)
        {
            //base.pfc_endtran();-- it not needed
            //int li_rc;
            //if (ai_update_results == 1) {
            //    EXECUTE IMMEDIATE "COMMIT";
            //}
            //else {
            //    EXECUTE IMMEDIATE "ROLLBACK";
            //}
            //if (StaticVariables.sqlca.SQLCode == 0) {
            //    return 1;
            //}
            //else {
            //    return -(1);
            //}
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackColor = System.Drawing.SystemColors.Control;
            // 
            // st_label
            // 
            this.st_label = new USt();
            st_label.Width = 171;
            st_label.Location = new Point(1, 309);
            st_label.ForeColor = System.Drawing.Color.Gray;
            Controls.Add(st_label);
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

        public virtual int wf_insertrow()
        {
            int li_rc = 0;
            MSheet am_source;
            am_source = this.m_sheet;//MenuID;
            if (am_source != null)
            {
                //?li_rc = this.pfc_insertrow();//li_rc = am_source.ParentWindow.pfc_messagerouter("pfc_insertrow");
            }
            return li_rc;
        }

        public virtual int wf_deleterow()
        {
            int li_rc = 0;
            MSheet am_source;
            am_source = this.m_sheet;//MenuID;
            if (am_source != null)
            {
                //?li_rc = this.pfc_deleterow();//li_rc = am_source.ParentWindow.pfc_messagerouter("pfc_deleterow");
            }
            return li_rc;
        }

        public virtual int wf_search()
        {
            return 0;
        }

        public virtual int wf_reset()
        {
            int li_rc = 0;
            MSheet am_source;
            am_source = this.m_sheet;//MenuID; 
            if (am_source != null)
            {
                this.ue_reset();//li_rc = am_source.ParentWindow.pfc_messagerouter("ue_reset");
            }
            return li_rc;
        }

        public virtual int wf_quicklist()
        {
            return 0;
        }

        public virtual int wf_printpreview()
        {
            int li_rc = 0;
            MSheet am_source;
            am_source = this.m_sheet;//MenuID; 
            if (am_source != null)
            {
                //?li_rc = this.pfc_printpreview();//li_rc = am_source.ParentWindow.pfc_messagerouter("pfc_printpreview");
            }
            return li_rc;
        }

        public virtual int wf_saveas()
        {
            int li_rc = 0;
            MSheet am_source;
            am_source = this.m_sheet;//MenuID; 
            if (am_source != null)
            {
                //?li_rc = this.ue_saveas();//li_rc = am_source.ParentWindow.pfc_messagerouter("ue_saveas");
            }
            return li_rc;
        }

        public virtual bool wf_setaudit(bool ab_setaudit)
        {
            ib_setaudit = ab_setaudit;
            return ib_setaudit;
        }

        public virtual int of_pause(int al_secs)
        {
            int ll;
            int mm = 0;
            for (ll = 1; ll <= al_secs * 1000; ll++)
            {
                mm++;
            }
            return 0;
        }

        public virtual int wf_scroll(string aMethod)
        {
            return 0;
        }

        public virtual int wf_printzoom()
        {
            return 0;
        }

        public virtual bool wf_canundo()
        {
            return true;
        }

        public virtual bool of_validate()
        {
            return true;
        }
    }
}
