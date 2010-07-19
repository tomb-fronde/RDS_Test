using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;
using System.Collections.Generic;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddAllowance3 : WAncestorWindow
    {
        #region Define
        //public dw_allowance idw_allowance;
        public URdsDw idw_allowance;

        public int il_contract;
        public int il_contract_seq;
        int newRow;

        public int il_altKey;

        public int il_caRow;

        public string is_errmsg = String.Empty;

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_allowance;

        public Button cb_save;
        private Label Title;
        private Label Total;
        private Button cb_delete;

        public Button cb_cancel;

        #endregion

        public WAddAllowance3()
        {
            this.InitializeComponent();

            this.dw_allowance.DataObject = new DAddAllowance3();
            //dw_allowance.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_allowance.DataObject.BorderStyle = BorderStyle.None;

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
            this.dw_allowance = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_save = new System.Windows.Forms.Button();
            this.cb_cancel = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.cb_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.st_label.Location = new System.Drawing.Point(8, 245);
            this.st_label.Size = new System.Drawing.Size(136, 23);
            this.st_label.Text = "wAddAllowance3";
            // 
            // dw_allowance
            // 
            this.dw_allowance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_allowance.DataObject = null;
            this.dw_allowance.FireConstructor = false;
            this.dw_allowance.Location = new System.Drawing.Point(8, 32);
            this.dw_allowance.Name = "dw_allowance";
            this.dw_allowance.Size = new System.Drawing.Size(600, 180);
            this.dw_allowance.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(444, 234);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "Save";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(530, 234);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 3;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(8, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(217, 15);
            this.Title.TabIndex = 4;
            this.Title.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // Total
            // 
            this.Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Total.BackColor = System.Drawing.SystemColors.Control;
            this.Total.Location = new System.Drawing.Point(176, 218);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(100, 13);
            this.Total.TabIndex = 6;
            this.Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_delete
            // 
            this.cb_delete.Location = new System.Drawing.Point(328, 234);
            this.cb_delete.Name = "cb_delete";
            this.cb_delete.Size = new System.Drawing.Size(82, 23);
            this.cb_delete.TabIndex = 7;
            this.cb_delete.Text = "Delete record";
            this.cb_delete.UseVisualStyleBackColor = true;
            this.cb_delete.Click += new System.EventHandler(this.cb_delete_Click);
            // 
            // WAddAllowance3
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(616, 261);
            this.Controls.Add(this.cb_delete);
            this.Controls.Add(this.dw_allowance);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.cb_cancel);
            this.Location = new System.Drawing.Point(46, 55);
            this.Name = "WAddAllowance3";
            this.Text = "Add Contract Allowance";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.Title, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.Total, 0);
            this.Controls.SetChildIndex(this.dw_allowance, 0);
            this.Controls.SetChildIndex(this.cb_delete, 0);
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

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int nRow, nRows;
            string ls_title;
            decimal dTotalAmt = 0.0M;
            decimal? dThisAmt = 0.0M;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;

            DateTime dtEffDate = DateTime.MinValue;
            DateTime dtToday = DateTime.Today.Date;
            DateTime? dtPaidToDate, tmpDate;

            this.of_set_componentname("Allowance");

            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            il_contract_seq = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("con_active_seq"));
            il_altKey = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alt_key"));
            il_caRow = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("allowance_row"));
            ls_title = lvn_Criteria.of_getcriteria("contract_title") as string;
            this.Title.Text = ls_title;
            tmpDate = RDSDataService.GetConRatesEffDate((int?) il_contract, (int?) il_contract_seq);
            dtEffDate = (DateTime)tmpDate;

            idw_allowance.DataObject.Reset();
            ((DAddAllowance3)idw_allowance.DataObject).Retrieve(il_contract, dtEffDate);
            //idw_allowance.DataObject.AddItem<AddAllowance2>(new AddAllowance2());
            idw_allowance.DataObject.InsertItem<AddAllowance2>(0, new AddAllowance2());
            nRows = idw_allowance.RowCount;
            newRow = 0; // newRow = nRows - 1;
            idw_allowance.GetItem<AddAllowance2>(newRow).ContractTitle = ls_title;
            idw_allowance.GetItem<AddAllowance2>(newRow).ContractNo = il_contract;
            idw_allowance.GetItem<AddAllowance2>(newRow).EffectiveDate = dtToday;
            // Calculate the total of the AnnualPayments
            dTotalAmt = 0.0M;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                dThisAmt = idw_allowance.GetItem<AddAllowance2>(nRow).AnnualAmount;
                if (dThisAmt != null)
                    dTotalAmt += (decimal)dThisAmt;
            }
            // Display the total
            this.Total.Text = dTotalAmt.ToString("###,###.00");

            // Check to see if the allowance has been paid already; 
            // if so mark the row read-only.
            for (nRow = 0; nRow < nRows; nRow++)
            {
                dtPaidToDate = idw_allowance.GetItem<AddAllowance2>(nRow).PaidToDate;
                if ( dtPaidToDate != null )
                    ((DAddAllowance3)(idw_allowance.DataObject)).SetGridRowReadOnly(nRow, true);
            }

            // Check to see if this user is allowed to approve allowances
            string grouplist = "Payroll, System Administrators";
            bool ismemberofgroup = StaticVariables.gnv_app.inv_Security_Manager.inv_User.of_ismemberof_list(grouplist);
            if (ismemberofgroup)
                ((DAddAllowance3)(idw_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", false);
            else
                ((DAddAllowance3)(idw_allowance.DataObject)).SetGridColumnReadOnly("ca_approved", true);

            // Set the focus on the new record (which has been added as the last row)
            ((DAddAllowance3)(idw_allowance.DataObject)).SetCurrent(newRow);
            
            //idw_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
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
            ((WContract2001)StaticVariables.window).idw_allowances.Retrieve(new object[]{il_contract});
            StaticVariables.window = null;
        }

        public virtual int wf_validate(int pRow, out string pErrmsg)
        {
            // Validate the record at arow.
            //
            // Return codes
            //   SUCCESS  - Record is OK
            //   FAILURE  - Something's wrong.  Pass error message back in errmsg.
            //   FAILURE2 - Something's wrong but we've already told the user so
            //              the caller doesn't need to tell the user again.
            //              (or, for the new records, the user doesn't want it)
            //

            DateTime? ld_effdate;
            DateTime? ld_maxdate;
            Decimal? ldc_amount;
            string ls_notes;
            int? ll_altkey;
            int FAILURE2 = -(2);

            pErrmsg = "Succeeded";

            // Check to see if anything has been entered for the inserted record
            // If not, accept the record; it will not be inserted (silently).
            ll_altkey = idw_allowance.GetItem<AddAllowance2>(pRow).AltKey;
            if (ll_altkey == null)
            {
                pErrmsg = "You must enter an allowance type.";
                ((DAddAllowance3)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "alt_key", true);
                return FAILURE;
            }
            ldc_amount = idw_allowance.GetItem<AddAllowance2>(pRow).AnnualAmount;
            if (ldc_amount == null || ldc_amount == 0)
            {
                pErrmsg = "You must enter an amount.";
                ((DAddAllowance3)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "ca_annual_amount", true);
                return FAILURE;
            }
            ld_effdate = idw_allowance.GetItem<AddAllowance2>(pRow).EffectiveDate;
            if (ld_effdate == null || ld_effdate == DateTime.MinValue)
            {
                pErrmsg = "You must enter an effective date.";
                ((DAddAllowance3)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "ca_effective_date", true);
                return FAILURE;
            }
            ls_notes = idw_allowance.GetItem<AddAllowance2>(pRow).Notes;
            if (ls_notes == null || ls_notes == "")
            {
                pErrmsg = "You must enter a Note.";
                ((DAddAllowance3)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "ca_notes", true);
                return FAILURE;
            }
            if (!(StaticVariables.gnv_app.of_sanedate(ld_effdate.GetValueOrDefault(), "effective date")))
            {
                pErrmsg = "Date failed sanity check";
                ((DAddAllowance3)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "ca_effective_date", true);
                return FAILURE2;
            }
            // if this is the new record, check that its effective date is later than that
            // of any existing allowances of the same type.
            if (newRow >= 0 && pRow == newRow)
            {
                ld_maxdate = new DateTime();
                /*select max(ca_effective_date) into :ld_maxdate from contract_allowance where contract_no = :il_contract and alt_key = :ll_altkey;*/
                int SQLCode = 0;
                string SQLErrText = string.Empty;
                ld_maxdate = RDSDataService.GetContractAllownceMaxCaEffective(il_contract, ll_altkey, ref SQLCode, ref SQLErrText);

                if (SQLCode != 0 && SQLCode != 100)
                {
                    MessageBox.Show("Failed looking up max(ca_effective_date): \n"
                                    + "contract=" + il_contract.ToString()
                                    + ", alt_key=" + ll_altkey.ToString() + "\n\n"
                                    + "Error Code: " + SQLCode.ToString() + "\n"
                                    + "Error Text: " + SQLErrText
                                    , "Database error");
                    //?rollback;
                    pErrmsg = "Failed looking up max(ca_effective_date)";
                    ((DAddAllowance3)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "ca_effective_date", true);
                    return FAILURE2;
                }
                //?rollback;
                if (ld_effdate <= ld_maxdate)
                {
                    pErrmsg = "The effective date must be greater than "
                                + ld_maxdate.GetValueOrDefault().ToString("dd/MM/yyyy") + '.';
                    return FAILURE;
                }
            }
            return SUCCESS;
        }

        public virtual void dw_allowance_constructor()
        {
            idw_allowance = dw_allowance;
        }

        private bool check_for_save_error(out int pRow)
        {
            int nSQLCode = 0;
            string sSQLErrText = "";
            string sErrType = "";

            for (int nRow = 0; nRow < idw_allowance.RowCount; nRow++)
            {
                nSQLCode = idw_allowance.GetItem<AddAllowance2>(nRow).SQLCode;
                sSQLErrText = idw_allowance.GetItem<AddAllowance2>(nRow).SQLErrText;
                sErrType = "Save: Other error";

                if (nSQLCode == -1)
                    sErrType = "Update error";
                else if (nSQLCode == -2)
                    sErrType = "Insert error";
                if (nSQLCode == -2 && nRow == newRow)
                {
                    // If there was an insert error (SQLCode == -2) and its on the new 
                    // record, assume the user didn't want to insert anything and may 
                    // have simply changed an existing record (and the update was successful).  
                    // This error is passed back to the called to possibly notify the user.
                    pRow = nRow;
                    return true;
                }
                if (nSQLCode != 0)
                {
                    MessageBox.Show(sErrType + " Row " + (nRow + 1).ToString() + "\n"
                                   + "Error Code: " + nSQLCode.ToString() + "\n"
                                   + "Error Text: " + sSQLErrText
                                   , "Database Save Error");
                    pRow = nRow;
                    return true;
                }
            }
            // If there is no failure, the pRow value is not used.
            // We have to assign it something, so use a value that cannot be 
            // interpreted as a valid row value.
            pRow = -1;
            return false;
        }

        #region Events
        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            cb_save.Focus();
            int rc, nRow, nRows, startRow;
            bool deleteNewRow = false;
            string errmsg = "";

            idw_allowance.DataObject.AcceptText();
            is_errmsg = "";
            startRow = 0;

            // Check to see if the ne row has been filled in.
            // If not, ask the user whether to keep it or not.
            if ( newRow >= 0 )
            {
                DateTime? ld_effdate;
                Decimal? ldc_amount;
                string ls_notes;
                int? ll_altkey;

                ll_altkey = idw_allowance.GetItem<AddAllowance2>(newRow).AltKey;
                ldc_amount = idw_allowance.GetItem<AddAllowance2>(newRow).AnnualAmount;
                ld_effdate = idw_allowance.GetItem<AddAllowance2>(newRow).EffectiveDate;
                ls_notes = idw_allowance.GetItem<AddAllowance2>(newRow).Notes;

                if (ll_altkey == null
                    && ldc_amount == null
                    && ls_notes == null)
                {
                    DialogResult ans = MessageBox.Show("The new row is missing required values; did you intend enter a new allowance?\n"
                                     + "    " + "Yes = The Save will be cancelled \n"
                                     + "    " + " No = The new record will not be inserted. \n"
                                     , "Warning"
                                     , MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                                     , MessageBoxDefaultButton.Button1);

                    if (ans == DialogResult.Yes)
                    {
                        return;
                    }
                    deleteNewRow = true;
                    startRow = 1;
                }
            }
            // If the user didn't want to create a new record
            // the new record will have been deleted.  Check the
            // rest of the rows.
            // If the user had started filling in the new row, check it too
            nRows = idw_allowance.RowCount;
            for (nRow = startRow; nRow < nRows; nRow++)
            {
                rc = wf_validate(nRow, out errmsg);
                if (!(rc == SUCCESS))
                {
                    ((DAddAllowance3)(idw_allowance.DataObject)).SetCurrent(nRow);
                    this.ResumeLayout(true);
                    if (rc == FAILURE)
                        MessageBox.Show(errmsg
                                       , "Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (deleteNewRow)
            {
                idw_allowance.GetItem<AddAllowance2>(newRow).AltKey = null;
                idw_allowance.DeleteItemAt(newRow);
                newRow = -1;
                //idw_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            idw_allowance.Save();
            nRow = 0;
            if (check_for_save_error(out nRow))
            {
                // If there was an insert error (SQLCode == -2) and its
                // on the new record, assuem the user didn't want to insert anything
                // and may have simply changed an existing record (and the update was
                // successful).  This error wasn't reported to the user in check_for_save_error
                // but may be reported here (just in case the user intended to insert 
                // something).
                int nSQLCode = idw_allowance.GetItem<AddAllowance2>(nRow).SQLCode;
                if ( !(nSQLCode == -2 && nRow == newRow))
                //{
                //}
                //else
                {
                    return;
                }
            }
            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            idw_allowance.DataObject.Reset();
            this.Close();
        }
        #endregion

        private void cb_delete_Click(object sender, EventArgs e)
        {
            int nRow = 0;
            nRow = idw_allowance.DataObject.GetRow();
            if (!((DAddAllowance3)(idw_allowance.DataObject)).GetGridRowReadOnly(nRow))
            {
                if ((nRow == newRow))
                {
                    newRow = -1;
                    idw_allowance.GetItem<AddAllowance2>(nRow).AltKey = null;
                }
                idw_allowance.DataObject.DeleteItemAt(nRow);
                //idw_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
            }
        }
    }
}
