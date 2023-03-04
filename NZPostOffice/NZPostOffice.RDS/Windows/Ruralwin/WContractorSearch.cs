using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralsec;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Entity;
using Metex.Windows;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_140  June-2019
    // Added Unsuccessful Search message matching contract search's
    // Had to explicitly set initial contract type dropdown to <blank>.
    // If the user specifies a contractor, allow <Open> to work without 
    // requiring a search first.
    // Fixed a bug in of_clear.

    public class WContractorSearch : WGenericSearch
    {
        #region Define

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_results;

        public URdsDw dw_criteria;

        public Button pb_search;

        public Button pb_new;

        public Button pb_open;

        public Button cb_clear;

        public System.Windows.Forms.Panel l_2;

        #endregion

        public WContractorSearch()
        {
            this.InitializeComponent();
            this.dw_results.DataObject = new DContractorList();
            this.dw_criteria.DataObject = new DContractorSearch();
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_results_constructor);
            ((DContractorList)dw_results.DataObject).Click += new EventHandler(WContractorSearch_Click);
            ((DContractorList)dw_results.DataObject).DoubleClick += new EventHandler(this.dw_results_doubleclicked);

            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_criteria_constructor);
            ((DContractorSearch)this.dw_criteria.DataObject).ChildControlClick += new EventHandler(ChildControl_Click);
            //jlwang:end

            ((Metex.Windows.DataEntityGrid)this.dw_results.DataObject.GetControlByName("grid")).KeyDown += new KeyEventHandler(WContractorSearch_KeyDown);
            dw_results.RowFocusChanged += new EventHandler(dw_results_rowfocuschanged);
            dw_results.GotFocus += new EventHandler(dw_results_getfocus);
            dw_criteria.GotFocus += new EventHandler(dw_criteria_getfocus);       

        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.l_2 = new Panel();
            this.dw_results = new URdsDw();
            //!this.dw_results.DataObject = new DContractorList();

            this.dw_criteria = new URdsDw();
            //!this.dw_criteria.DataObject = new DContractorSearch();


            this.pb_search = new Button();
            this.pb_new = new Button();
            this.pb_open = new Button();
            this.cb_clear = new Button();
            this.Name = "w_contractor_search";

            Controls.Add(l_2);
            Controls.Add(dw_criteria);
            Controls.Add(dw_results);
            Controls.Add(pb_search);
            Controls.Add(pb_new);
            Controls.Add(pb_open);
            Controls.Add(cb_clear);
            Controls.Add(st_label);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.MaximizeBox = false;
            this.Text = "Owner Driver Search";
            this.Size = new System.Drawing.Size(405, 400);
            this.Location = new System.Drawing.Point(46, 55);
            // 
            // st_label
            // 
            st_label.Text = "w_contractor_search";
            st_label.Location = new System.Drawing.Point(5, 353);

            // 
            // l_2
            //
            l_2.Size = new System.Drawing.Size(326, 1);
            l_2.BackColor = System.Drawing.Color.Black;
            l_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            l_2.Location = new System.Drawing.Point(3, 200);

            // 
            // dw_results
            // 
            dw_results.Location = new System.Drawing.Point(3, 176);
            dw_results.Size = new System.Drawing.Size(326, 178);
            dw_results.TabIndex = 5;
            

//!            dw_results.RowFocusChanged += new EventHandler(dw_results_rowfocuschanged);
//!            dw_results.GotFocus += new EventHandler(dw_results_getfocus);            

            // 
            // dw_criteria
            // 
            dw_criteria.VerticalScroll.Visible = false;
            //!dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_criteria.TabIndex = 1;
            dw_criteria.Size = new System.Drawing.Size(326, 172);
            dw_criteria.Location = new System.Drawing.Point(3, 4);
//!            dw_criteria.GotFocus += new EventHandler(dw_criteria_getfocus);           

            // 
            // pb_search
            // 
            pb_search.Image = global ::NZPostOffice.Shared.Properties.Resources.SEARCH;
            this.AcceptButton = pb_search;
            pb_search.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_search.TabIndex = 2;
            pb_search.Location = new System.Drawing.Point(336, 4);
            pb_search.Size = new System.Drawing.Size(59, 31);
            pb_search.Click += new EventHandler(pb_search_clicked);
            // 
            // pb_new
            // 
            pb_new.Image = global ::NZPostOffice.Shared.Properties.Resources.NEW;
            pb_new.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_new.TabIndex = 3;
            pb_new.Location = new System.Drawing.Point(336, 45);
            pb_new.Size = new System.Drawing.Size(59, 31);
            pb_new.Tag = "ComponentPrivilege=C;";
            pb_new.Visible = false;
            pb_new.Click += new EventHandler(pb_new_clicked);
            // 
            // pb_open
            // 
            pb_open.Image = global ::NZPostOffice.Shared.Properties.Resources.OPEN;
            pb_open.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            pb_open.TabIndex = 4;
            pb_open.Location = new System.Drawing.Point(336, 166);
            pb_open.Size = new System.Drawing.Size(59, 31);
            pb_open.Click += new EventHandler(pb_open_clicked);
            // 
            // cb_clear
            // 
            cb_clear.Text = "&Clear";
            cb_clear.TabIndex = 5;
            cb_clear.Location = new System.Drawing.Point(336, 86);
            cb_clear.Size = new System.Drawing.Size(59, 31);
            cb_clear.Click += new EventHandler(cb_clear_clicked);
//!            ((Metex.Windows.DataEntityGrid)this.dw_results.DataObject.GetControlByName("grid")).KeyDown += new KeyEventHandler(WContractorSearch_KeyDown);
            this.ResumeLayout();
        }

        void WContractorSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.pb_open.Focus();
                pb_open_clicked(dw_results, e);
                e.SuppressKeyPress = true;
            }
        }

        private void WContractorSearch_Click(object sender, EventArgs e)
        {
            this.AcceptButton = this.pb_open;
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
            // dw_Results.uf_Initialise ( {""},3)
            //dw_criteria.uf_InsertRow();
            dw_criteria.InsertItem<ContractorSearch>(0);
            //Metex.Windows.DataUserControl dw_child = dw_criteria.GetChild("ct_key");
            //dw_child.Reset();
            //foreach (FilteredContractTypes var in StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types().BindingSource.List)
            //{
            //    DddwContractTypes l_row = new DddwContractTypes();
            //    l_row.ContractType = var.ContractType;
            //    l_row.CtKey = var.CtKey;
            //    l_row.CtRdRefMandatory = var.CtRdRefMandatory;
            //    l_row.MarkClean();
            //    dw_child.AddItem<DddwContractTypes>(l_row);
            //    dw_child.SortString = "contract_type A";
            //    dw_child.Sort<DddwContractTypes>();
            //}
            //?dw_results.SetRowFocusIndicator(focusrect!);
            //  dw_criteria.GetItem<ContractorSearch>(0).CtKey = 1;//SetValueem ( 1,'ct_key',1)

            //added by jlwang
            //?dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            DataUserControl lds_user_contract_types;
            //DataUserControl dwc_contract_type;
            lds_user_contract_types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
            //dwc_contract_type = dw_criteria.GetChild("ct_key");//sObject);
            if (lds_user_contract_types.RowCount == StaticVariables.gnv_app.of_gettotalcontracttypes())
            {
                ((Metex.Windows.DataEntityCombo)dw_criteria.GetControlByName("ct_key")).SelectedIndex = 0;
            }
            else
            {
                // TJB  RPCR_140 June 2019
                // Have to explicitly set initial contract type dropdown to <blank>
                //this.dw_criteria.DataObject.SetValue(0, "ct_key", 1);
                ((Metex.Windows.DataEntityCombo)dw_criteria.GetControlByName("ct_key")).SelectedIndex = 0;

                this.dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            }
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Owner Driver");
        }

        public virtual int of_clear()
        {
            //  TWC - 18/12/2003 - initial version
            //  This function will clear the search criteria 
            //  and search results boxes
            //  This is response to powerbuilder 8.0.4 not recogizing firing of delete key strokes
            int? ll_null;
            string ls_null;
            ll_null = null;
            ls_null = null;

            //  clear the results box
            //dw_results.of_reset();
            dw_results.Reset();

            //  clear the dw_criteria fields
            //dw_criteria.uf_resetrows();
            dw_criteria.Reset();
            if (dw_criteria.RowCount == 0)
                dw_criteria.InsertItem<ContractorSearch>(0);
            // dw_criteria.of_retrieve (  )
            dw_criteria.SetValue(0, "contractor_supplier_no", ll_null);
            dw_criteria.SetValue(0, "contract_no", ll_null);
            dw_criteria.SetValue(0, "region_id", ll_null);
            dw_criteria.SetValue(0, "c_surname_company", ls_null);
            dw_criteria.SetValue(0, "c_first_names", ls_null);
            dw_criteria.SetValue(0, "c_phone_day", ls_null);
            // TJB  RPCR_140  June-2019
            // For some reason, these don't clear the contract type in all cases
/*            ((DataEntityCombo)dw_criteria.GetControlByName("ct_key")).SelectedIndex = 0;//jlwang
            dw_criteria.SetValue(0, "ct_key", ll_null);
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_criteria.SetCurrent(0);
*/
            // but this does??
            of_Set_Contract_Type(0);
            return 1;
        }

        public void dw_results_constructor()
        {
            dw_results.of_SetUpdateable(false);
        }

        public void dw_criteria_constructor()
        {
            dw_criteria.of_SetUpdateable(false);
            //  PBY 03/09/2002 SR#4450
            //  Do not restrict the region dropdown
            dw_criteria.of_bypassregionfilter(true);
            dw_criteria.Focus();
        }

        #region Events

        public void ChildControl_Click(object sender, EventArgs e)
        {
            this.AcceptButton = this.pb_search;
        }

        public void dw_results_doubleclicked(object sender, EventArgs e)
        {
            dw_results.URdsDw_DoubleClick(sender, e);
            this.pb_open.Focus();
            pb_open_clicked(this, null);
        }

        public void dw_results_rowfocuschanged(object sender, EventArgs e)
        {
            dw_results.SelectRow(0, false);
            //dw_results.SelectRow(dw_results.GetRow(), true);
            if (dw_results.GetRow() > -1)
            {
                dw_results.SelectRow(dw_results.GetRow() + 1, true);
            }
        }

        public void dw_results_getfocus(object sender, EventArgs e)
        {
            dw_results.URdsDw_GetFocus(sender, e);
            //pb_search.default = false;
            //pb_open.default = true;
            this.AcceptButton = pb_open;
        }

        public void dw_criteria_getfocus(object sender, EventArgs e)
        {
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //?base.getfocus();
            dw_criteria.URdsDw_GetFocus(null, null);
            //pb_open.default = false;
            //pb_search.default = true;
            this.AcceptButton = pb_search;
        }

        // TJB RPCR_140 June-2019
        // If a contract number has been specified as well as a contract type
        // ensure the contract type is correct for the contract specified
        // If the contract type is different, return the correct one in the
        // ref pCtKey parameter.  If there's a database error, return that
        // as the function value.
        private int of_verify_contract_type(int? pContractNo, ref int? pCtKey)
        {
            int nCtKey = -1;

            // Get the ct_key for the contract
            RDSDataService Service = RDSDataService.GetContractTypeKey(pContractNo);
            if (Service.SQLCode == 0)
            {
                nCtKey = Service.intVal;

                // If the contract's ct_key is different than the one in the 
                // search screen, change the screen to match the contract's
                if (nCtKey != pCtKey)
                {   
                    of_Set_Contract_Type(nCtKey);
/*                    // There may be a better way to do this, but this works ...
                    DataUserControl dwChild;  // Get the ct_key object
                    dwChild = dw_criteria.GetChild("ct_key");
                    dwChild.Reset();  // Clear it, then set to the element we want
                    dw_criteria.GetItem<ContractorSearch>(0).CtKey = nCtKey;
                    dwChild.Retrieve();  // Now re-retrieve the dropdown's values
                    // then refersh the screen to show the new contract type
                    dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
*/
                    // Don't forget to change the type that will be used in the search!
                    pCtKey = nCtKey;
                }
            }
            else
            {// "This shouldn't ever happen
                MessageBox.Show("Error looking up the contract's type \n"
                               + Service.SQLErrText + "\n"
                               + "(the contract number may not be valid)"
                               , "Warning - SQL Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return 0;
        }

        // TJB  RPCR_140  June-2019: Added
        // There may be a better way to do this, but this works ...
        private void of_Set_Contract_Type(int pCtKey)
        {
            DataUserControl dwChild;  // Get the ct_key object
            dwChild = dw_criteria.GetChild("ct_key");
            dwChild.Reset();  // Clear it, then set it to the value we want
            dw_criteria.GetItem<ContractorSearch>(0).CtKey = pCtKey;
            dwChild.Retrieve();  // Now re-retrieve the dropdown's values
            // and refresh the screen to show the new contract type
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public void pb_search_clicked(object sender, EventArgs e)
        {
            of_search();
        }

        private void of_search()
        {
            int? lContractor, lContract, lContractType, lRegion;
            string sSurname, sFirstName, sPhone;

            dw_criteria.AcceptText();

            lContractor = dw_criteria.GetItem<ContractorSearch>(0).ContractorSupplierNo;
            lContract = dw_criteria.GetItem<ContractorSearch>(0).ContractNo;
            lContractType = dw_criteria.GetItem<ContractorSearch>(0).CtKey;
            lRegion = dw_criteria.GetItem<ContractorSearch>(0).RegionId;
            sSurname = dw_criteria.GetItem<ContractorSearch>(0).CSurnameCompany;
            sFirstName = dw_criteria.GetItem<ContractorSearch>(0).CFirstNames;
            sPhone = dw_criteria.GetItem<ContractorSearch>(0).CPhoneDay;

            if (lContractor == null)
                lContractor = 0;
            if (lContract == null)
                lContract = 0;
            if (lContractType == null)
                lContractType = 0;
            if (lRegion == null)
                lRegion = 0;
            if (sSurname == null)
                sSurname = "";
            if (sFirstName == null)
                sFirstName = "";
            if (sPhone == null)
                sPhone = "";

            // TJB RPCR_140  June-2019
            // If a contract is specified, and a contract type is present
            // (the type seems to be automatically set to Rural Delivery) 
            // check that the type corresponds to the contract's type and 
            // change the search criteria if not.
            if (lContract > 0 && lContractType > 0)
            {
                int err = of_verify_contract_type( lContract, ref lContractType);
                if (err != 0)
                    return;
            }

            // TJB  RPCR_140  June-2019
            // If a contractor has been specified and a contract type is specified 
            // but no contract, clear the contract type (it may have been automatically 
            // populated and not for a type the contractor has - the contractor may
            // have more than one contract type).
            if (lContractor > 0 && lContractType > 0 && lContract == 0)
            {
                of_Set_Contract_Type(0);
                lContractType = 0;
            }

            this.Cursor = Cursors.WaitCursor;//SetPointer(HourGlass!);
            dw_results.Retrieve(new Object[] { lContractor, lContract, lContractType, lRegion, sSurname, sFirstName, sPhone });
            this.Cursor = Cursors.Arrow;
            if (dw_results.RowCount == 0)
            {
                // TJB  RPCR_140  June-2019: Added Unsuccessful Search message
                MessageBox.Show("There are no contracts that satisfy the search criteria entered."
                               , "Unsuccessful Search"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_criteria.Focus();
            }
            else
            {
                dw_results.Focus();
                //dw_Results.TriggerEvent(RowFocusChanged!);
                this.dw_results_rowfocuschanged(null, null);
            }
            this.l_2.Width = 308;//--add by mkwang(GUI)
        }

        public void pb_new_clicked(object sender, EventArgs e)
        {
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("contractor_supplier_no", -(1));
            lnv_msg.of_addcriteria(lnv_Criteria);
            //OpenSheetWithParm(w_contractor2001, lnv_msg, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = lnv_msg;
            StaticVariables.window = this;
            WContractor2001 w_contractor2001 = new WContractor2001();
            w_contractor2001.MdiParent = StaticVariables.MainMDI;
            w_contractor2001.Show();
        }

        public void pb_open_clicked(object sender, EventArgs e)
        {
            string ls_Title;
            WContractor2001 lw_contractor2001;
            int? lContractor;
            int ll_Row;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;

            Cursor.Current = Cursors.WaitCursor;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            pb_open.Focus();

            // TJB  RPCR_140  June-2019
            // Allow immediate Open if a contractor has been specified in the
            // search criteria.
            dw_criteria.AcceptText();
            lContractor = dw_criteria.GetItem<ContractorSearch>(0).ContractorSupplierNo;

            // Did user select a contractor?
            if (lContractor == null || lContractor <= 0)  // No; check for a search result
            {
                if (dw_results.GetRow() < 0)  // NO: tell the user to do a search first
                {
                    MessageBox.Show("Please search for a contractor before trying to open one."
                                   , "Contractor Search"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Get contractor no and add it to criteria object
            ll_Row = dw_results.GetRow();
            if (ll_Row >= 0)  // if there was a search result selected, use that contractor number
            {
                lContractor = dw_results.GetItem<ContractorList>(ll_Row).ContractorSupplierNo;
                ls_Title = "Owner Driver: " + dw_results.GetItem<ContractorList>(dw_results.GetRow()).ContractorName;
            }
            else  // TJB  RPCR_140  June-2019
            {     // We're using the contractor number from the search criteria
                  // for which there is no contractor name; we have to look it up.
                int sqlErr = 0;
                string sqlErrText = "";
                ls_Title = RDSDataService.GetContractorName(lContractor, ref sqlErr, ref sqlErrText);
                if (sqlErr != 0)
                {
                    if (sqlErr == 100)
                        MessageBox.Show("Contractor not found"
                                       , "Database lookup failure"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Error getting the contractor's name \n"
                                       + sqlErrText
                                       , "Database lookup error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ls_Title = "Owner Driver: " + ls_Title;
            }

            //lnv_Criteria.of_addcriteria("contractor_supplier_no", dw_results.GetItem<ContractorList>(ll_Row).ContractorSupplierNo);
            lnv_Criteria.of_addcriteria("contractor_supplier_no", lContractor);
            lnv_msg.of_addcriteria(lnv_Criteria);
            // Build title
            // Open the contractor window if title not found
            if (!((StaticVariables.gnv_app.of_findwindow(ls_Title, "w_contractor2001") != null)))
            {
                StaticVariables.window = this;
                //OpenSheetWithParm(lw_contractor2001, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                lw_contractor2001 = new WContractor2001();
                lw_contractor2001.MdiParent = StaticVariables.MainMDI;
                lw_contractor2001.Show();
            }
        }

        public void cb_clear_clicked(object sender, EventArgs e)
        {
            this.of_clear();
        }

        #endregion
    }
}
