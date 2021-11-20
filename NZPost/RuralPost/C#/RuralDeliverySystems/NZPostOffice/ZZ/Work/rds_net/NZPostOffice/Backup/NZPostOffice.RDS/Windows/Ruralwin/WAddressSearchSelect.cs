using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_143 Sep-2019
    // Removed references to cb_print
    //
    // TJB 22-Feb-2012 Release 7.1.7 fixups
    // [pfc_postopen] Made cb_open and cb_select settings explicit.

    public class WAddressSearchSelect : WAddressSearch
    {
        #region Define
        public int? il_rdContractSelect;

        private System.ComponentModel.IContainer components = null;
        #endregion

        public WAddressSearchSelect()
        {
            this.InitializeComponent();
            //_menu.SetFunctionalPart();
            //_toolbar.SetFunctionalPart();
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // idw_results
            // 
            this.idw_results.Location = new System.Drawing.Point(8, 141);
            this.idw_results.Size = new System.Drawing.Size(672, 237);
            // 
            // tab_criteria
            // 
            this.tab_criteria.Size = new System.Drawing.Size(672, 129);
            // 
            // cb_search
            // 
            this.cb_search.Location = new System.Drawing.Point(688, 25);
            // 
            // cb_clear
            // 
            this.cb_clear.Location = new System.Drawing.Point(688, 52);
            // 
            // cb_open
            // 
            this.cb_open.Enabled = false;
            this.cb_open.Location = new System.Drawing.Point(778, 97);
            this.cb_open.TabIndex = 0;
            this.cb_open.Visible = false;
            // 
            // cb_new
            // 
            this.cb_new.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_new.Location = new System.Drawing.Point(688, 173);
            this.cb_new.Visible = false;
            // 
            // cb_select
            // 
            this.cb_select.Enabled = true;
            this.cb_select.Location = new System.Drawing.Point(688, 139);
            this.cb_select.TabIndex = 5;
            this.cb_select.Visible = true;
            // 
            // st_count
            // 
            this.st_count.Location = new System.Drawing.Point(454, 386);
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(5, 392);
            this.st_label.Text = "w_address_search_select";
            // 
            // WAddressSearchSelect
            // 
            this.CancelButton = this.cb_new;
            this.ClientSize = new System.Drawing.Size(771, 411);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WAddressSearchSelect";
            this.Controls.SetChildIndex(this.st_count, 0);
            this.Controls.SetChildIndex(this.cb_select, 0);
            this.Controls.SetChildIndex(this.idw_results, 0);
            this.Controls.SetChildIndex(this.cb_new, 0);
            this.Controls.SetChildIndex(this.cb_open, 0);
            this.Controls.SetChildIndex(this.cb_clear, 0);
            this.Controls.SetChildIndex(this.cb_search, 0);
            this.Controls.SetChildIndex(this.tab_criteria, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            string ls_message;
            il_rdContractSelect = StaticVariables.gnv_app.of_get_parameters().longparm;
            ls_message = StaticMessage.StringParm;
            if (ls_message == "SELECT")
            {
            }
            else
            {
                cb_new.Visible = false;
                cb_new.Enabled = false;
            }
            //?Menu lm_menu;
            //?this.ChangeMenu(lm_menu);
            //?of_setbase(true);
            //?this.inv_base.of_center();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // TJB  RD7_0042  Dec-2009
            // Added cb_select setup to make visible on address search screen
            // when called as addressSearchSelect.
            // TJB 22-Feb-2012 Release 7.1.7 fixups
            // Made cb_open and cb_select settings explicit.  These override those set in WAddressSearch.
            cb_select.Enabled = true;
            cb_select.Visible = true;
            cb_open.Enabled = false;
            cb_open.Visible = false;
            //cb_select.Location = new System.Drawing.Point(605, 131);
            if (!((il_rdContractSelect == null)))
            {
                tab_criteria.of_setrdflag(il_rdContractSelect, 1);
            }
        }
    }
}