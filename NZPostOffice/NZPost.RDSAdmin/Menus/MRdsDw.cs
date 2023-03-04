using System;
using System.Windows.Forms;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDSAdmin.Menus
{
    // TJB  Allowances  2-June-2021
    // Added m_save
    public class MRdsDw : MDw
    {
        private System.ComponentModel.IContainer components = null;
        private WMainMdi wMainMdi;

        public MRdsDw(WMainMdi _wMainMdi)
        {
            this.InitializeComponent();
            wMainMdi = _wMainMdi;
        }
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_cut.Visible = false;

            m_copy.Visible = false;

            m_paste.Visible = false;

            m_selectall.Visible = false;

            m_dash11.Visible = false;

            m_insert.Visible = false;
            m_insert.Enabled = true;

            m_addrow.Visible = false;

            m_delete.Enabled = true;

            m_save.Visible = false;
            m_save.Enabled = true;
        }

        public virtual void SetFunctionalPart(MRdsDw _m_rds_dw)
        {
            //!base.SetFunctionalPart(_m_rds_dw);
            //m_rds_dw = _m_rds_dw;
        }

        //public override void ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
        public virtual void ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {   /*!
            switch (this.Buttons.IndexOf(e.Button))
            {
                default:
                    //!base.ToolBarButtonClick(sender, e);
                    break;
            }
             */ 
        }
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

        public override void m_delete_clicked(object sender, EventArgs e)
        {
        }

        public override void m_save_clicked(object sender, EventArgs e)
        {
        }

        public override void m_insert_clicked(object sender, EventArgs e)
        {
        }
    }
}
