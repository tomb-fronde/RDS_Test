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
    // TJB  Allowances  June-2021
    // Changed handling of existing unapproved DISTANCE records. Insert vehicle
    // type and effective date in existing record.
    //
    // TJB  Allowances  4-Apr-2021: New
    // Adapted from WAddAllowance.
    // Vastly different: Only used to determine the new allowance's type 
    // and associated vehicle if the calc type is distance-based.
    // [12-Apr-2021] Changed "maxDate" to be the contract renewal date (was DateTime.MinDate)
    // [13-May-2021] Added check for existing unapproved allowance and prevent creating
    //               another one.
    // Once determined, the new record is saved and WMaintainAllowance is 
    // initiated with the allowance calc type included so that WMaintainAllowance
    // can immediately switch to the correct tab.

    public class WAddAllowance2021 : WAncestorWindow
    {
        #region Define
        
        private object CallingObject;

        public int il_contract;
        public int il_contract_seq;
        public int newRow = -1;
        DateTime dtEffDate = DateTime.MinValue;
        string iChangeType = "Update";

        public int? il_altKey;
        public int? il_alctId;
        public int  il_caRow;
        public string ls_title;

        public string is_errmsg = String.Empty;
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_allowance;
        public URdsDw idw_allowance;

        public Button cb_save;
        private Label Title;
        public Button cb_cancel;

        // Define values for the different calculation types
        public readonly int FIXED = RDSDataService.LookupAllowanceCalcType("Fixed");
        public readonly int ROI = RDSDataService.LookupAllowanceCalcType("Return ");
        public readonly int ACTIVITY = RDSDataService.LookupAllowanceCalcType("Activity");
        public readonly int TIME = RDSDataService.LookupAllowanceCalcType("Time");
        public readonly int DISTANCE = RDSDataService.LookupAllowanceCalcType("Distance");

        #endregion

        public WAddAllowance2021()
        {
            this.InitializeComponent();

            this.dw_allowance.DataObject = new DAddAllowance();
            dw_allowance.DataObject.BorderStyle = BorderStyle.None;
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
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.st_label.Location = new System.Drawing.Point(8, 183);
            this.st_label.Size = new System.Drawing.Size(136, 23);
            this.st_label.Text = "WAddAllowance2021";
            // 
            // dw_allowance
            // 
            this.dw_allowance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dw_allowance.DataObject = null;
            this.dw_allowance.FireConstructor = false;
            this.dw_allowance.Location = new System.Drawing.Point(12, 32);
            this.dw_allowance.Name = "dw_allowance";
            this.dw_allowance.Size = new System.Drawing.Size(576, 123);
            this.dw_allowance.TabIndex = 1;
            // 
            // cb_save
            // 
            this.cb_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cb_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_save.Location = new System.Drawing.Point(427, 172);
            this.cb_save.Name = "cb_save";
            this.cb_save.Size = new System.Drawing.Size(75, 23);
            this.cb_save.TabIndex = 2;
            this.cb_save.Text = "OK";
            this.cb_save.Click += new System.EventHandler(this.cb_save_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cb_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_cancel.Location = new System.Drawing.Point(513, 172);
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
            // WAddAllowance2021
            // 
            this.AcceptButton = this.cb_save;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(599, 204);
            this.Controls.Add(this.dw_allowance);
            this.Controls.Add(this.cb_save);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.cb_cancel);
            this.Location = new System.Drawing.Point(46, 55);
            this.Name = "WAddAllowance2021";
            this.Text = "Select Allowance Type";
            this.Controls.SetChildIndex(this.cb_cancel, 0);
            this.Controls.SetChildIndex(this.Title, 0);
            this.Controls.SetChildIndex(this.cb_save, 0);
            this.Controls.SetChildIndex(this.dw_allowance, 0);
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

        public virtual void dw_allowance_constructor()
        {
            idw_allowance = dw_allowance;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
        }

        public override void pfc_postopen()
        {
            int nRow, nRows;
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;

            DateTime dtToday = DateTime.Today.Date;
            DateTime? dtPaidToDate, tmpDate;

            base.pfc_postopen();
            this.of_set_componentname("Allowance");

            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();
            il_contract = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("contract_no"));
            il_contract_seq = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("con_active_seq"));
            il_altKey = (int?)System.Convert.ToInt32(lvn_Criteria.of_getcriteria("alt_key"));
            il_caRow = System.Convert.ToInt32(lvn_Criteria.of_getcriteria("allowance_row"));
            ls_title = lvn_Criteria.of_getcriteria("contract_title") as string;

            CallingObject = StaticVariables.window;
            this.Title.Text = ls_title;

            // Get the Effective Date for this contract.
            // We only list those allowances whose effective date falls in the Contract's current period
            tmpDate = RDSDataService.GetConRatesEffDate((int?) il_contract, (int?) il_contract_seq);
            dtEffDate = (DateTime)tmpDate;

            idw_allowance.DataObject.Reset();
            //nRows = ((DAddAllowance)idw_allowance.DataObject).Retrieve(il_contract, dtEffDate);
            //((DAddAllowance)idw_allowance.DataObject).Retrieve(il_contract, dtToday);

            // Insert a new record at the beginning of the list
            newRow = 0;
            idw_allowance.DataObject.InsertItem<AddAllowance>(newRow, new AddAllowance());
            nRows = idw_allowance.RowCount;
            int n = nRows;
            // NOTE: 'newRow' is the row number of the added row.  If the row is added 
            // elsewhere (eg at the end of the list), newRow must be changed.
            // Set default values on the new row
            idw_allowance.GetItem<AddAllowance>(newRow).ContractTitle = ls_title;
            idw_allowance.GetItem<AddAllowance>(newRow).ContractNo = il_contract;
            idw_allowance.GetItem<AddAllowance>(newRow).EffectiveDate = dtToday;
            idw_allowance.GetItem<AddAllowance>(newRow).Approved = "N";
            idw_allowance.GetItem<AddAllowance>(newRow).RowChanged = "N";

            // Set the focus on the new record (which has been added (usually as the first row))
            ((DAddAllowance)(idw_allowance.DataObject)).SetCurrent(newRow);
            
            idw_allowance.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public void of_open_WMaintainAllowance()
        {
            NRdsMsg lnv_msg;
            NCriteria lvn_Criteria;
            //DateTime? dEffDate;

            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvn_Criteria = lnv_msg.of_getcriteria();

            il_altKey = idw_allowance.GetItem<AddAllowance>(0).AltKey;
            il_alctId = idw_allowance.GetItem<AddAllowance>(0).AlctId;
            //dEffDate  = idw_allowance.GetItem<AddAllowance>(0).EffectiveDate;

            Cursor.Current = Cursors.WaitCursor;
            lvn_Criteria.of_addcriteria("contract_no", il_contract);
            lvn_Criteria.of_addcriteria("con_active_seq", il_contract_seq);
            lvn_Criteria.of_addcriteria("alt_key", il_altKey);
            lvn_Criteria.of_addcriteria("alct_id", il_alctId);
            //lvn_Criteria.of_addcriteria("effective_date", dEffDate);
            lvn_Criteria.of_addcriteria("contract_title", ls_title);
            lvn_Criteria.of_addcriteria("optype", iChangeType);
            lnv_msg.of_addcriteria(lvn_Criteria);

            // TJB  RPCR_017 July-2010
            // Changed WAddAllowance significantly
            // (See WAddAllowance0 for previous version)
            StaticMessage.PowerObjectParm = lnv_msg;
            StaticVariables.window = CallingObject;  // WContract2001

            WMaintainAllowances w_maintain_allowances = new WMaintainAllowances();

            w_maintain_allowances.MdiParent = StaticVariables.MainMDI;
            w_maintain_allowances.Show();
            return;
        }

        public override void close()
        {
/*
            //  Tell the parent to refresh
            ((WContract2001)StaticVariables.window).idw_allowances.Reset();
            ((WContract2001)StaticVariables.window).idw_allowances.Retrieve(new object[]{il_contract});
            StaticVariables.window = null;
*/
        }

        public virtual int wf_validate(int pRow, out string pErrmsg)
        {
            // TJB 18-Mar-2021 Added sAltDescription

            // Validate the record at arow.
            //
            // Return codes
            //   SUCCESS  - Record is OK
            //   FAILURE  - Something's wrong.  Pass error message back in errmsg.
            //

            int? ll_altkey, ll_varid, ll_alctid;
            DateTime? ld_maxdate, ld_effdate;

            pErrmsg = "Succeeded";

            // Check to see if anything has been entered for the inserted record
            // If not, accept the record; it will not be inserted (silently).
            ll_altkey = idw_allowance.GetItem<AddAllowance>(pRow).AltKey;
            if (ll_altkey == null)
            {
                pErrmsg = "You must enter an allowance type.";
                ((DAddAllowance)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "alt_key", true);
                return FAILURE;
            }
            ld_effdate = idw_allowance.GetItem<AddAllowance>(pRow).EffectiveDate;
            if (ld_effdate == null || ld_effdate == DateTime.MinValue)
            {
                pErrmsg = "You must enter an effective date.";
                ((DAddAllowance)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "ca_effective_date", true);
                return FAILURE;
            }
            ll_alctid = idw_allowance.GetItem<AddAllowance>(newRow).AlctId;
            ll_alctid = (ll_alctid == null) ? 0 : ll_alctid;
            ll_varid = idw_allowance.GetItem<AddAllowance>(pRow).VarId;
            if (ll_varid == null && ll_alctid == 5)
            {
                pErrmsg = "You must enter a vehicle type.";
                ((DAddAllowance)(idw_allowance.DataObject)).SetGridCellSelected(pRow, "var_id", true);
                return FAILURE;
            }

            // This is the new record; check that its effective date is greater than that
            // of any existing allowances of the same type.
            if (newRow >= 0 && pRow == newRow)
            {
                DateTime dEffDate = (DateTime)ld_effdate;
                DateTime dMaxDate = (DateTime)RDSDataService.GetAllowanceMaxEffectiveDate(il_contract, ll_altkey);

                if (dEffDate <= dMaxDate)
                {
                    pErrmsg = "The effective date must be greater than "
                                + dMaxDate.ToString("dd/MM/yyyy") + '.';
                    return FAILURE;
                }
            }
            return SUCCESS;
        }

        #region Events
        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            cb_save.Focus();
            int rc, nRow, nRows;
            string errmsg = "";
            int? thisAltKey;
            DateTime? effDate;

            idw_allowance.DataObject.AcceptText();
            is_errmsg = "";

            nRow = 0;
            // Check to see if there already is an unapproved allowance of this type
            // If one exists, suggest the user update it instead of creating another one.
            thisAltKey = idw_allowance.GetItem<AddAllowance>(nRow).AltKey;
            effDate = RDSDataService.GetUnpaidAllowanceDate(il_contract, thisAltKey);
            int? varId = idw_allowance.GetItem<AddAllowance>(nRow).VarId;
            if (effDate != null)
            {
                // TJB  Allowances  June-2021
                // Changed handling of existing unapproved DISTANCE records. Insert vehicle
                // type and effective date in existing record.
                if (idw_allowance.GetItem<AddAllowance>(nRow).AlctId == DISTANCE)
                {
                    int sqlCode = 0;
                    string sqlErrText = "";
                    bool isOK = RDSDataService.UpdateAllowanceVehicleType(il_contract, thisAltKey, effDate, varId
                                                   , ref sqlCode, ref sqlErrText);
                    if (!isOK)
                    {
                        MessageBox.Show("Error updating allowance " + thisAltKey.ToString() + " vehicle type\n"
                                        + "sqlCode = " + sqlCode.ToString() + "\n"
                                        + "sqlErrText = " + sqlErrText
                                        , "WAddAllowance2021.cb_save_clicked");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("An allowance of this type already exists.\n"
                                   + "Please update it."
                                   , "Warning"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    iChangeType = "Update";
                    idw_allowance.GetItem<AddAllowance>(nRow).MarkClean();
                }
            }
            else
            {
                // Validate the row
                rc = wf_validate(nRow, out errmsg);
                if (!(rc == SUCCESS))
                {
                    ((DAddAllowance)(idw_allowance.DataObject)).SetCurrent(nRow);
                    this.ResumeLayout(true);
                    if (rc == FAILURE)
                        MessageBox.Show(errmsg, "Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // This is a new row.  Mark it New ("N").  In WMaintainAllowance, this will
                // be used when validating its effective date.
                idw_allowance.GetItem<AddAllowance>(nRow).RowChanged = "N";
                iChangeType = "Insert";

                // All OK, we can save it
                idw_allowance.DataObject.Save();
            }

            // Switch to WMaintainAllowance()
            of_open_WMaintainAllowance();

            this.Close();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            idw_allowance.DataObject.Reset();
            this.Close();
        }
        #endregion
    }
}
