using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
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
            // cb_open
            // 
            this.cb_open.Enabled = false;
            this.cb_open.Location = new System.Drawing.Point(697, 97);
            this.cb_open.TabIndex = 0;
            this.cb_open.Visible = false;
            // 
            // cb_new
            // 
            this.cb_new.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_new.Location = new System.Drawing.Point(605, 165);
            // 
            // cb_select
            // 
            this.cb_select.Enabled = true;
            this.cb_select.Location = new System.Drawing.Point(605, 131);
            this.cb_select.TabIndex = 5;
            this.cb_select.Visible = true;
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(5, 387);
            this.st_label.Text = "w_address_search_select";
            // 
            // WAddressSearchSelect
            // 
            this.CancelButton = this.cb_new;
            this.ClientSize = new System.Drawing.Size(690, 406);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WAddressSearchSelect";
            this.Controls.SetChildIndex(this.cb_select, 0);
            this.Controls.SetChildIndex(this.cb_print, 0);
            this.Controls.SetChildIndex(this.idw_results, 0);
            this.Controls.SetChildIndex(this.st_count, 0);
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
            cb_select.Enabled = true;
            cb_select.Visible = true;
            cb_select.Location = new System.Drawing.Point(605, 131);
            if (!((il_rdContractSelect == null)))
            {
                tab_criteria.of_setrdflag(il_rdContractSelect, 1);
            }
        }
    }
}