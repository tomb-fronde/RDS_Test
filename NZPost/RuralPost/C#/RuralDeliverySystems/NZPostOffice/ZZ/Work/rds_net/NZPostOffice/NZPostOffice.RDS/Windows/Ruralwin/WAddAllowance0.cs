using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;
using System.Collections.Generic;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddAllowance : WAncestorWindow
    {
        #region Define
        //public dw_allowance idw_allowance;
        public URdsDw idw_allowance;

        public int il_contract;

        public int il_altKey;

        public int il_caRow;

        public string is_errmsg = String.Empty;

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_allowance;

        public Button cb_save;

        public Button cb_cancel;

        #endregion

        public WAddAllowance()
        {
            this.InitializeComponent();

            this.dw_allowance.DataObject = new DAddAllowance();
            dw_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            dw_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_allowance_constructor);
            //jlwang:end

            idw_allowance = dw_allowance;
        }

        #region FormDesign
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_allowance = new URdsDw();
            //!this.dw_allowance.DataObject = new DAddAllowance();
            this.cb_save = new Button();
            this.cb_cancel = new Button();
            Controls.Add(dw_allowance);
            Controls.Add(cb_save);
            Controls.Add(cb_cancel);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Add Contract Allowance";
            this.Location = new System.Drawing.Point(46, 55);
            this.Size = new System.Drawing.Size(476, 242);
            // 
            // st_label
            // 
            st_label.Text = "w_add_allowance";
            st_label.Width = 136;
            st_label.Location = new System.Drawing.Point(8, 192);
            // 
            // dw_allowance
            // 
            dw_allowance.VerticalScroll.Visible = false;
            //!dw_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_allowance.TabIndex = 1;
            dw_allowance.Location = new System.Drawing.Point(8, 8);
            dw_allowance.Size = new System.Drawing.Size(449, 168);
            //dw_allowance.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_allowance_constructor);
            // 
            // cb_save
            // 
            this.AcceptButton = cb_save;
            cb_save.Text = "Save";
            cb_save.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_save.TabIndex = 2;
            cb_save.Location = new System.Drawing.Point(296, 184);
            cb_save.Size = new System.Drawing.Size(75, 23);
            cb_save.Click += new EventHandler(cb_save_clicked);
            // 
            // cb_cancel
            // 
            cb_cancel.Text = "Cancel";
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(382, 184);
            cb_cancel.Size = new System.Drawing.Size(75, 23);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            this.Name = "w_add_allowance";
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

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int ll_row;
            string ls_title;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;
            this.of_set_componentname("Allowance");
            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            il_altKey = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alt_key"));
            il_caRow = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("allowance_row"));
            ls_title = lvn_Criteria.of_getcriteria("contract_title") as string;
            idw_allowance.DataObject.Reset();
            idw_allowance.DataObject.AddItem<AddAllowance>(new AddAllowance());
            ll_row = idw_allowance.GetRow();//.RowCount;
            idw_allowance.GetItem<AddAllowance>(ll_row).ContractTitle = ls_title;
            idw_allowance.GetItem<AddAllowance>(ll_row).ContractNo = il_contract;
            idw_allowance.GetItem<AddAllowance>(ll_row).AltKey = il_altKey;
            idw_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
            idw_allowance.GetControlByName("alt_key").Focus();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_bypass_security(true);
        }

        public override void close()
        {
            //?base.close();
            //  Tell the parent to refresh
            int ll_sheetcount;
            int ll_rc;
            Dictionary<int, WContract2001> lw_opensheets = new Dictionary<int, WContract2001>();
            FormBase lw_frame;
            lw_frame = StaticVariables.gnv_app.of_getframe();
            //?if ((lw_frame.inv_sheetmanager != null) == false) {
            //    lw_frame.inv_sheetmanager = new NCstWinsrvSheetmanager();
            //}
            //?ll_sheetcount = lw_frame.inv_sheetmanager.of_getsheetsbyclass(lw_opensheets, "w_contract2001");
            //if (ll_sheetcount < 2 && ll_sheetcount > 0) {
            //    ll_rc = lw_opensheets[1].idw_allowances.Reset();
            //    ll_rc = lw_opensheets[1].idw_allowances.Retrieve(new object[]{il_contract});
            //    ll_rc = lw_opensheets[1].idw_allowances.SelectRow(0, false);
            //    ll_rc = lw_opensheets[1].idw_allowances.SelectRow(il_caRow, true);
            //}
            //? this.Close();//close(this);
            ((WContract2001)StaticVariables.window).idw_allowances.Reset();
            ((WContract2001)StaticVariables.window).idw_allowances.Retrieve(new object[] { il_contract });
            StaticVariables.window = null;
        }

        public virtual int wf_validate(int arow)
        {
            DateTime? ld_effdate;
            DateTime? ld_maxdate;
            Decimal? ldc_amount;
            int? ll_altkey;
            ll_altkey = null;
            int FAILURE2 = -(2);
            is_errmsg = "";
            ld_effdate = idw_allowance.GetItem<AddAllowance>(arow).EffectiveDate;
            ldc_amount = idw_allowance.GetItem<AddAllowance>(arow).AnnualAmount;
            ll_altkey = idw_allowance.GetItem<AddAllowance>(arow).AltKey;
            if ((ldc_amount == null) || ldc_amount == 0)
            {
                is_errmsg = "You must enter an amount.";
                return FAILURE;
            }
            if ((ld_effdate == null))
            {
                is_errmsg = "You must enter an effective date.";
                return FAILURE;
            }
            else
            {
                if (!(StaticVariables.gnv_app.of_sanedate(ld_effdate.GetValueOrDefault(), "effective date")))
                {
                    return FAILURE2;
                }
                ld_maxdate = new DateTime();//System.Convert.ToDateTime("00/00/0000");
                /*select max ( ca_effective_date) into :ld_maxdate from contract_allowance where contract_no = :il_contract and alt_key = :ll_altkey;*/
                int SQLCode = 0;
                string SQLErrText = string.Empty;
                ld_maxdate = RDSDataService.GetContractAllownceMaxCaEffective(il_contract, ll_altkey, ref SQLCode, ref SQLErrText);

                if (SQLCode != 0 && SQLCode != 100) //if (StaticVariables.sqlca.SQLCode != 0 && StaticVariables.sqlca.SQLCode != 100)
                {
                    MessageBox.Show("Failed looking up max ( ca_effective_date): ~r" + "contract=" + il_contract.ToString() + ", alt_key=" + ll_altkey.ToString() + "~r~r" + "Error Code: " + SQLCode.ToString() + "~" + "Error Text: " + SQLErrText, "Database error"); //MessageBox.Show("Failed looking up max ( ca_effective_date): ~r" + "contract=" + String(il_contract) + ", alt_key=" + String(ll_altkey) + "~r~r" + "Error Code: " + String(app.sqlca.SQLCode) + '~' + "Error Text: " + app.sqlca.SQLErrText, "Database error");
                    //?rollback;
                    return FAILURE2;
                }
                //?rollback;
                if (ld_effdate <= ld_maxdate)
                {
                    is_errmsg = "The effective date must be greater than " + ld_maxdate.GetValueOrDefault().ToString("dd/MM/yyyy") + '.';
                    return FAILURE;
                }
            }
            //?rollback;
            return SUCCESS;
        }

        public virtual void dw_allowance_constructor()
        {
            idw_allowance = dw_allowance;
        }

        #region Events
        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            cb_save.Focus();
            int ll_RowCount;
            int ll_error;
            idw_allowance.DataObject.AcceptText();
            is_errmsg = "";
            ll_RowCount = idw_allowance.RowCount;
            if (!(ll_RowCount == 1))
            {
                is_errmsg = "Incorrect number of rows to insert  ( " + ll_RowCount.ToString() + ")??\r" + " ( programming bug - please report)";
                ll_error = FAILURE;
            }
            else
            {
                ll_error = wf_validate(ll_RowCount - 1);
            }
            if (!(ll_error == SUCCESS))
            {
                if (ll_error == FAILURE)
                {
                    MessageBox.Show(is_errmsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;//?return FAILURE;
            }
            idw_allowance.Save();//idw_allowance.Update();
            if (idw_allowance.GetItem<AddAllowance>(0).SQLCode != 0) //(StaticVariables.sqlca.SQLCode != 0)
            {
                //MessageBox.Show("Unable to update.  \n\n" + "Error Code: " + String(app.sqlca.SQLCode) + "\n\n" + "Error Text: " + app.sqlca.SQLErrText, "Database Error");
                MessageBox.Show("Unable to update.  \n\n" + "Error Code: " + idw_allowance.GetItem<AddAllowance>(0).SQLCode.ToString() + "\n\n" + "Error Text: " + idw_allowance.GetItem<AddAllowance>(0).SQLErrText, "Database Error");

                //?RollBack;
                return;//?return FAILURE;
            }
            //COMMIT;
            this.Close();
            //?return SUCCESS;
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            idw_allowance.DataObject.Reset();
            this.Close();
        }
        #endregion
    }
}
