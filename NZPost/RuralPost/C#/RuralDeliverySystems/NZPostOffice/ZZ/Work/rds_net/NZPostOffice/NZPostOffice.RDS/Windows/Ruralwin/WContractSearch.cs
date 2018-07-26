using System;
using System.Windows.Forms;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Entity.Ruraldw;
using Metex.Windows;
using NZPostOffice.Shared;
using System.Collections.Generic;
using Metex.Core;
using NZPostOffice.Entity;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_122  July-2018
    // Changed size of contract search window and dw_criteria sub-window
    // Added PBUCode element (dropdown select list) to Designer 
    // And search logic to WContractSearch (see references to PbuId 
    // in pb_search_clicked)

    public partial class WContractSearch : WGenericSearch
    {
        public WContractSearch()
        {
            this.InitializeComponent();
            this.dw_results.DataObject = new DContractListing();

            this.dw_criteria.DataObject = new DContractSearch();
            this.dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
            ((DContractListing)dw_results.DataObject).CellDoubleClick += new EventHandler(this.dw_results_doubleclicked);
            dw_criteria.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(this.dw_criteria_constructor);
            ((DContractSearch)this.dw_criteria.DataObject).ChildControlClick += new EventHandler(ChildControl_Click);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            // dw_criteria.Modify("region_id.initial='" + string(gnv_app.of_Get_SecurityManager().of_Get_User().of_Get_RegionId()) + "'")
            this.of_set_componentname("Contract");
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            dw_criteria.InsertItem<ContractSearch>(dw_criteria.RowCount);

            //? dw_results.SetRowFocusIndicator(focusrect!);
            DataUserControl lds_user_contract_types;
            int ll_row;
            int lNull;
            DataUserControl dwChild = null;
            lds_user_contract_types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
            dwChild = dw_criteria.GetChild("ct_key");

            //#region added by ylwang
            //Metex.Core.EntityBindingList<DddwContractTypes> bindingSource = (Metex.Core.EntityBindingList<DddwContractTypes>)dwChild.DataSource;
            //// dwChild.Retrieve ( )
            //bindingSource.Clear();

            //for (int i = 0; i < lds_user_contract_types.RowCount; i++)//added by ylwang
            //{
            //   DddwContractTypes obj = (DddwContractTypes)Activator.CreateInstance(typeof(DddwContractTypes));

            //    obj.CtKey = (Int32?)lds_user_contract_types.GetValue(i, "ct_key");
            //    obj.ContractType = (String)lds_user_contract_types.GetValue(i, "contract_type");
            //    obj.CtRdRefMandatory = (String)lds_user_contract_types.GetValue(i, "ct_rd_ref_mandatory");

            //    bindingSource.Insert(i, obj);
            //}

            //DddwContractTypes ContractTypesObj = (DddwContractTypes)Activator.CreateInstance(typeof(DddwContractTypes));

            //ContractTypesObj.CtKey = 0;
            //ContractTypesObj.ContractType = "";
            //ContractTypesObj.CtRdRefMandatory = "";

            //bindingSource.Insert(0, ContractTypesObj);
            //#endregion

            if (lds_user_contract_types.RowCount == StaticVariables.gnv_app.of_gettotalcontracttypes())
            {//add by mkwang
                int? Null;
                Null = null;
                dwChild = dw_criteria.GetChild("ct_key");
                dwChild.Retrieve();
                insertRow(dwChild, 0);
                dwChild.SetValue(0, "ct_key", Null);
                dwChild.SetValue(0, "contract_type", "<All Contract Types>");
                insertRow(dwChild, 0);
                dwChild.DeleteItemAt(0);
            }

            ll_row = dwChild.Find("ct_key", 1);
            if (ll_row > 0)
            {
                //dw_criteria.GetItem<ContractSearch>(0).CtKey = 1;
                BeginInvoke(new delegateInvoke(afterDel));
            }

            //jlwang: for different user 
            if (dw_criteria.ll_row >= 0)
                dw_criteria.SetValue(0, "region_id", dw_criteria.ll_row);
            else if (dw_criteria.ll_row == -99)
                dw_criteria.SetValue(0, "region_id", -99);
            //added by jlwang
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_criteria.URdsDw_GetFocus(null, null);
        }

        private delegate void delegateInvoke();

        public virtual void afterDel()
        {
            dw_criteria.GetItem<ContractSearch>(0).CtKey = 1; //dw_criteria.DataObject.SetValue(0, "ct_key", 1);
            //dw_criteria.SetCurrent(0);
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public virtual int of_clear()
        {
            //  TWC - 18/12/2003 - initial version
            //  This function will clear the search criteria 
            //  and search results boxes
            //  This is response to powerbuilder 8.0.4 not recogizing firing of delete key strokes
            int? ll_null;
            int? ll_ct;
            string ls_null;
            ll_null = null;
            ls_null = null;
            ll_ct = dw_criteria.GetItem<ContractSearch>(0).CtKey;
            //  clear the dw_criteria fields
            dw_criteria.uf_resetrows();
            //  dw_criteria.setitem ( 1, "region_id", ll_null)
            DataUserControl dwChild;
            dwChild = dw_criteria.GetChild("region_id");
            dwChild.Retrieve();
            dw_criteria.GetItem<ContractSearch>(0).ContractNo = ll_null; ;
            dw_criteria.GetItem<ContractSearch>(0).ConTitle = ls_null;
            dw_criteria.GetItem<ContractSearch>(0).ConOldMailServiceNo = ls_null;
            //  no longer want to undo contract type selections
            dw_criteria.GetItem<ContractSearch>(0).CtKey = ll_ct;

            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh(); //added by jlwang
            //  clear the results box
            dw_results.of_Reset();
            return 1;
        }

        public virtual void dw_results_constructor()
        {
            dw_results.of_SetUpdateable(false);
        }

        public virtual void dw_criteria_constructor()
        {
            //DataUserControl dwChild;
            //int? lNull;
            //lNull = null;
            //if (dw_criteria.GetControlByName("ct_key") is DataEntityCombo)
            //{
            //    dwChild = dw_criteria.GetChild("ct_key");
            //    dwChild.Retrieve();
            //    insertRow(dwChild, 0);
            //    dwChild.SetValue(0, "ct_key", lNull);
            //    dwChild.SetValue(0, "contract_type", "<All Contract Types>");
            //    insertRow(dwChild, 0);
            //    dwChild.DeleteItemAt(0);
            //   ((Metex.Windows.DataEntityCombo)(dw_criteria.GetControlByName("ct_key"))).SelectedIndex = 0;  
            //}
            //dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_criteria.of_SetUpdateable(false);
            dw_criteria.GetControlByName("contract_no").Focus();
        }

        private void addRow(DataUserControl dw)//added by ylwang
        {
            string typeName = dw.GetType().FullName.Replace("DataControls", "Entity");
            typeName = typeName.Replace(".D", ".");
            string st = dw.GetType().Assembly.ToString();
            st = st.Replace("DataControls", "Entity");

            System.Reflection.Assembly dll = System.Reflection.Assembly.Load(st);
            object obj = Activator.CreateInstance(dll.GetType(typeName));
            dw.BindingSource.List.Add((Metex.Core.EntityBase)obj);
        }

        private void insertRow(DataUserControl dw, int row)
        {
            //string typeName = dw.BindingSource.DataSource.GetType().ToString();
            //typeName = typeName.Substring(typeName.LastIndexOf("[") + 1);
            //typeName = typeName.Substring(0, typeName.Length - 1);
            //string st = dw.GetType().Assembly.ToString();
            //st = st.Replace("DataControls", "Entity");

            string typeName = dw.GetType().FullName.Replace("DataControls", "Entity");
            typeName = typeName.Replace(".D", ".");
            string st = dw.GetType().Assembly.ToString();
            st = st.Replace("DataControls", "Entity");

            System.Reflection.Assembly dll = System.Reflection.Assembly.Load(st);
            object obj = Activator.CreateInstance(dll.GetType(typeName));
            dw.BindingSource.List.Insert(row, (EntityBase)obj);
        }

        #region Events

        public void ChildControl_Click(object sender, EventArgs e)
        {
            this.AcceptButton = this.pb_search;
        }

        public virtual void dw_results_doubleclicked(object sender, EventArgs e)
        {
            dw_results.URdsDw_DoubleClick(sender, e);
            pb_open.Focus();
            pb_open_clicked(this, null);
        }

        public virtual void dw_results_rowfocuschanged(object sender, EventArgs e)
        {
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //  u_rds_dw.rowfocuschanged();
            dw_results.URdsDw_GetFocus(sender, e);
            dw_results.SelectRow(0, false);
            if (dw_results.GetRow() >= 0)
            {
                dw_results.SelectRow(dw_results.GetRow() + 1, true);
            }
            dw_results.SetCurrent(dw_results.GetRow());
        }

        public virtual void dw_results_getfocus(object sender, EventArgs e)
        {
            dw_results.URdsDw_GetFocus(null, null);
            this.AcceptButton = pb_open;
        }

        public virtual void dw_criteria_getfocus(object sender, EventArgs e)
        {
            dw_criteria.URdsDw_GetFocus(sender, e);
            this.AcceptButton = pb_search;
        }

        public virtual void pb_search_clicked(object sender, EventArgs e)
        {
            int? lRegion;
            int? lContract;
            string sConTitle;
            string sMSN;
            DateTime? dWorkStart;
            DateTime? dWorkEnd;
            DateTime? dServiceStart;
            DateTime? dServiceEnd;
            DateTime? dDelStart;
            DateTime? dDelEnd;
            int? ll_contract_type;
            int? lPbuId;

            dw_criteria.AcceptText();
            lRegion = dw_criteria.GetItem<ContractSearch>(0).RegionId;
            if (dw_criteria.ll_row == -99)
                lRegion = -99;

            lContract = dw_criteria.GetItem<ContractSearch>(0).ContractNo;
            // TJB  RPCR_122  July-2018: Added
            // Prevents "0" displayed as contract numberwhen previous number deleted
            if (lContract == 0)
                dw_criteria.GetItem<ContractSearch>(0).ContractNo = null;
            sConTitle = dw_criteria.GetItem<ContractSearch>(0).ConTitle;
            sMSN = (dw_criteria.GetItem<ContractSearch>(0).ConOldMailServiceNo == null ? null : dw_criteria.GetItem<ContractSearch>(0).ConOldMailServiceNo.Trim());
            dWorkStart = dw_criteria.GetItem<ContractSearch>(0).ConLastWorkMsr1;
            dWorkEnd = dw_criteria.GetItem<ContractSearch>(0).ConLastWorkMsr2;
            dServiceStart = dw_criteria.GetItem<ContractSearch>(0).ConLastServiceReview1;
            dServiceEnd = dw_criteria.GetItem<ContractSearch>(0).ConLastServiceReview2;
            dDelStart = dw_criteria.GetItem<ContractSearch>(0).ConLastDeliveryCheck1;
            dDelEnd = dw_criteria.GetItem<ContractSearch>(0).ConLastDeliveryCheck2;
            ll_contract_type = dw_criteria.GetItem<ContractSearch>(0).CtKey;
            lPbuId = dw_criteria.GetItem<ContractSearch>(0).PbuId;
            if (lRegion == null)
            {
                lRegion = 0;
            }
            if (lContract == null)
            {
                lContract = 0;
            }
            if (ll_contract_type == null)
            {
                ll_contract_type = 0;
            }
            if (StaticFunctions.f_isempty(sConTitle))
            {
                sConTitle = "";
            }
            if (StaticFunctions.f_isempty(sMSN))
            {
                sMSN = "";
            }
            if (lPbuId == null)
            {
                lPbuId = 0;
            }

            Cursor.Current = Cursors.WaitCursor;

            ((DContractListing)dw_results.DataObject).Retrieve(lRegion, lContract, sConTitle, sMSN
                                      , dServiceStart, dServiceEnd, dDelStart, dDelEnd, dWorkStart
                                      , dWorkEnd, ll_contract_type, lPbuId);
            if (dw_results.RowCount == 0)
            {
                MessageBox.Show("There are no contracts that satisfy the search criteria entered."
                               , "Unsuccessful Search"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_criteria.Focus();
            }
            else
            {
                dw_results.Focus();
                dw_results.DataObject.Focus();
                dw_results_rowfocuschanged(this.pb_search, new EventArgs());
            }
            this.l_2.Width = 330;//--add by mkwang(GUI)
        }

        public virtual void pb_new_clicked(object sender, EventArgs e)
        {
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("contract_no", -(1));
            lnv_msg.of_addcriteria(lnv_Criteria);
            //OpenSheetWithParm(w_contract2001, lnv_msg, w_main_mdi, 0, original!); 
            StaticMessage.PowerObjectParm = lnv_msg;
            OpenSheet<WContract2001>(StaticVariables.MainMDI);
        }

        public virtual void pb_open_clicked(object sender, EventArgs e)
        {
            int ll_row;
            int? ll_contractno;
            string ls_title;
            WContract2001 lw_contract2001;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            Cursor.Current = Cursors.WaitCursor;
            // Get selected row
            ll_row = dw_results.GetSelectedRow(0);
            if (ll_row < 0)
            {
                MessageBox.Show("Please search for a contract before trying to open one."
                              , "Contract Search"
                              , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Get contract no
            ll_contractno = dw_results.GetItem<ContractListing>(ll_row).ContractNo;
            // Create criteria
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("contract_no", ll_contractno);
            lnv_msg.of_addcriteria(lnv_Criteria);
            // Build title
            string ConTitle = dw_results.GetItem<ContractListing>(dw_results.GetSelectedRow(0)).ConTitle;
            ls_title = "Contract: (" + ll_contractno + ") " + ConTitle;
            // Open contract window if contract with title=ls_title not open
            if (!(StaticVariables.gnv_app.of_findwindow(ls_title, "w_contract2001") != null))
            {
                StaticMessage.PowerObjectParm = lnv_msg;
                lw_contract2001 = new WContract2001();
                lw_contract2001.MdiParent = StaticVariables.MainMDI;
                lw_contract2001.Show();
            }
        }

        public virtual void cb_clear_clicked(object sender, EventArgs e)
        {
            this.of_clear();
            this.AcceptButton = pb_search;
        }

        public void WContractSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.pb_open.Focus();
                this.pb_open_clicked(null, null);
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}