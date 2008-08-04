using System;
using System.Windows.Forms;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(661, 413);
            // 
            // st_label
            // 
            st_label.Text = "w_address_search_select";
            st_label.Location = new System.Drawing.Point(3, 368);
            // 
            // tab_criteria
            // 
            tab_criteria.Width = 551;
            // 
            // cb_search
            // 
            cb_search.Left = 569;
            // 
            // cb_clear
            // 
            cb_clear.Left = 569;
            // 
            // cb_open
            // 
            cb_open.Enabled = false;
            cb_open.TabIndex = 0;
            cb_open.Location = new System.Drawing.Point(697, 97);
            cb_open.Visible = false;
            // 
            // cb_new
            // 
            this.CancelButton = cb_new;
            cb_new.Location = new System.Drawing.Point(569, 165);
            // 
            // dw_results
            // 
            dw_results.Width = 551;
            // 
            // cb_select
            // 
            cb_select.Enabled = true;
            cb_select.TabIndex = 5;
            cb_select.Location = new System.Drawing.Point(569, 137);
            cb_select.Visible = true;
            // 
            // cb_cancel
            // 
            // 
            // st_count
            // 
            st_count.Location = new System.Drawing.Point(278, 456);
            // 
            // cb_print
            // 
            cb_print.Left = 569;
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
            if (!((il_rdContractSelect == null)))
            {
                tab_criteria.of_setrdflag(il_rdContractSelect, 1);
            }
        }
    }
}