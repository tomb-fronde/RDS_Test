using System;
using System.Collections.Generic;
using System.Text;
using Metex.Windows;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.DataControls;
using NZPostOffice.Entity;

namespace NZPostOffice.Shared.VisualComponents
{
    //declare  delegates.
    public delegate void EventDelegate(object send, EventArgs e);
    public delegate void UserEventDelegate();

    public class UDw : DataUserControlContainer
    {
        #region Define
        public const int SUCCESS = 1;
        public const int FAILURE = -1;
        public const int CANCLE = 3;
        public const int NO_ACTION = 0;

        public string is_Componentname = String.Empty;

        public bool ib_IsUpdateable = true;

        //? private URdsAuditmanager inv_AuditManager;

        public string isErrorColumn = String.Empty;

        public string isTag = String.Empty;

        public int ilRow;

        public bool ib_audittoggle = true;

        public bool ib_setaudit = false;

        public bool ib_autoinsert = false;

        // Instance  
        public int il_First_Column;

        public DateTime idt_last_updated = DateTime.MinValue;

        //? public Cl_n_audit_attribArray inv_AuditAttrib = new Cl_n_audit_attribArray();

        public bool ib_Filter_ContractTypes = true;

        public int? il_RegionId;

        public bool ib_AllowCreate;

        public bool ib_AllowRead;

        public bool ib_AllowModify;

        public bool ib_AllowDelete;

        public int il_RightClicked;

        public bool ib_BypassContractTypeFilter = false;

        public bool ib_BypassRegionFilter = false;

        public bool ib_RegionColumnFound;

        public DataUserControlContainer ids_UserComponentRegions;

        #endregion

        public UDw()
        {
            InitializeComponent();

        }

        protected virtual void rbuttondown()
        {
            /*? base.rbuttondown();
            il_RightClicked = row; */
        }

        public virtual bool of_setautoinsert(bool ab_autoinsert)
        {
            // Purpose: 	Set autoinsert property
            // 					-migrated from old code
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            ib_autoinsert = ab_autoinsert;
            return ib_autoinsert == ab_autoinsert;
        }

        /*?
        public virtual int of_setup_calendar() {
            // Purpose: 	Set up dropdown calendar - PFC 6.5 version quite buggy
            // 					- therefore not used
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            string sObjectList;
            string sObject;
            string ls_Coltype;
            string sTab = '~';
            sObjectList = this.Describe("Datawindow.Objects");
            while ( sObjectList.Len() > 0) {
                if (Pos(sObjectList, sTab) > 0) {
                    sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
                    sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
                }
                else {
                    sObject = sObjectList;
                    sObjectList = "";
                }
                ls_Coltype = Describe(sObject + ".ColType");
                if (Pos(Upper(ls_Coltype), "DATE") > 0) {
                    this.iuo_Calendar.of_register(sObject, this.iuo_Calendar.DDLB);
                }
            }
            return 1;
        } */

        public virtual int of_filter_contracttypes()
        {
            string sObjectList;
            string sObject = string.Empty;
            string ls_Coltype;
            string sTab = "\\";
            int? ll_Ret;
            DataUserControl lds_user_contract_types;
            DataUserControl dwc_contract_type;
            bool lbDefaulManaged = false;
            // See if bypassed
            if (ib_BypassContractTypeFilter)
            {
                return SUCCESS;
            }
            
            //jlwang:support Cry-report
            if (this.DataObject == null)
                return SUCCESS;

            Control ct_key_control = this.DataObject.GetControlByName("ct_key");
            if (ct_key_control != null) // panel
            {
                if (ct_key_control is DataEntityCombo)
                {
                    //  Only proceed the following check if the user contract types have
                    //  not been filtered.
                    // Retrieve cached contract types for the user
                    lds_user_contract_types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
                    dwc_contract_type = this.DataObject.GetChild("ct_key");//sObject);
                    if (lds_user_contract_types.RowCount == StaticVariables.gnv_app.of_gettotalcontracttypes())
                    {
                        // SR#4355 Only default the COntract TYpe to 'RD' when
                        // the column does not have an assigned value
                        dwc_contract_type.InsertItem<DddwContractTypes>(0);
                        dwc_contract_type.GetItem<DddwContractTypes>(0).CtKey = null;
                        dwc_contract_type.GetItem<DddwContractTypes>(0).ContractType = "";
                        dwc_contract_type.GetItem<DddwContractTypes>(0).CtRdRefMandatory = "";

                        if (this.RowCount > 0)
                        {
                            ll_Ret = this.GetValue<int?>(0, "ct_key");//.GetItemNumber(1, "ct_key");
                            if (ll_Ret == null || ll_Ret <= 0)
                            {
                                this.SetValue(0, sObject, 1);//,.SetItem(1, sObject, 1);
                            }
                            lbDefaulManaged = true;
                        }
                    }
                    else
                    {
                        // Repopulate the datawindowchild based on the current user id
                        dwc_contract_type.Reset();
                        // ll_Ret = lds_user_Contract_Types.ShareData ( dwc_contract_type)
                        //lds_user_contract_types.RowCopy<>(1, lds_user_Contract_Types.RowCount, , dwc_contract_type, 1);
                        for (int i = lds_user_contract_types.RowCount -1; i >= 0; i--)
                        {
                            dwc_contract_type.InsertItem<DddwContractTypes>(0);
                            dwc_contract_type.GetItem<DddwContractTypes>(0).CtKey = lds_user_contract_types.GetValue<int?>(i, "ct_key");
                            dwc_contract_type.GetItem<DddwContractTypes>(0).ContractType = lds_user_contract_types.GetValue<string>(i, "contract_type");
                            dwc_contract_type.GetItem<DddwContractTypes>(0).CtRdRefMandatory = lds_user_contract_types.GetValue<string>(i, "ct_rd_ref_mandatory");
                        }


                        dwc_contract_type.ResetUpdate();
                        // SR#4355 Only default the COntract TYpe to 'RD' when
                        // the column does not have an assigned value
                        if (this.RowCount > 0)
                        {
                            ll_Ret = this.GetValue<int?>(0, "ct_key");//.GetItemNumber(1, "ct_key");
                            if (ll_Ret > 0)
                            {
                                lbDefaulManaged = true;
                            }
                        }
                        if (lbDefaulManaged == false)
                        {
                            //  THe datawindow does not have a row yet and
                            //  hence cannot manage the default
                            ll_Ret = dwc_contract_type.Find("ct_key", 1);

                            if (ll_Ret >= 0)
                            {
                                //this.SetItem(1, sObject, 1);
                                BeginInvoke(new delegateInvoke(afterDel));
                            }
                            else
                            {
                                ll_Ret = dwc_contract_type.GetValue<int?>(0, "ct_key");//.GetItemNumber(1, "ct_key");
                                // Protect column if no access
                                if (ll_Ret == -99)
                                {
                                    dwc_contract_type.FilterString = "ct_key = -99";
                                    dwc_contract_type.FilterOnce<DddwContractTypes>(FilterCT);//.Filter<DddwContractTypes>();

                                    if (dwc_contract_type.GetItem<DddwContractTypes>(0).IsNew && ((DataEntityCombo)this.DataObject.GetControlByName("ct_key")).Enabled)
                                    {
                                        // Modify (  sObject + '.Protect="0~tif ( isRowNew ( ),1,1)"')
                                        // Modify (  sObject + ".Background.Color='79216776'")
                                        // Modify (  sObject + ".Background.Color='13160660'")
                                        ((DataEntityCombo)this.DataObject.GetControlByName("ct_key")).Enabled = false;
                                    }
                                }
                                //this.SetItem(1, sObject, ll_Ret);
                                BeginInvoke(new delegateInvoke2(afterDel), ll_Ret);
                            }
                        }
                        if (dwc_contract_type.RowCount == 1)
                        {
                            if (dwc_contract_type.GetItem<DddwContractTypes>(0).IsNew && ((DataEntityCombo)this.DataObject.GetControlByName("ct_key")).Enabled)
                            {
                                // Modify(sObject + ".Protect=\"0~tif ( isRowNew ( ),1,1)\"");
                                // Modify(sObject + ".Background.Color=\'79216776\'");
                                ((DataEntityCombo)this.DataObject.GetControlByName("ct_key")).Enabled = false;
                            }
                        }

                 
                        //jlwang:support nullable
                        dwc_contract_type.InsertItem<DddwContractTypes>(0);
                        dwc_contract_type.GetItem<DddwContractTypes>(0).CtKey = null;
                        dwc_contract_type.GetItem<DddwContractTypes>(0).ContractType = "";
                        dwc_contract_type.GetItem<DddwContractTypes>(0).CtRdRefMandatory = "";

                    }
                    this.DataObject.BindingSource.CurrencyManager.Refresh();
                }
            }
            return 1;
        }

        bool FilterCT(DddwContractTypes item)
        {
            if (!string.IsNullOrEmpty(item.CtKey.ToString()) && (item.CtKey == -99))
            {
                return true;
            }
            return false;
        }

        private delegate void delegateInvoke();
        public virtual void afterDel()
        {
            this.DataObject.SetValue(0, "ct_key", 1);
        }

        private delegate void delegateInvoke2(int? row);

        public virtual void afterDel(int? row)
        {
            this.DataObject.SetValue(0, "ct_key", row);
        }

        public virtual int of_set_filter_ContractTypes(bool ab_filter)
        {
            ib_Filter_ContractTypes = ab_filter;
            return 1;
        }

        public virtual int of_filter()
        {
            if (this.ib_Filter_ContractTypes)
            {
                this.of_filter_contracttypes();
            }
            this.of_filter_regions();
            return 1;
        }

        public virtual int of_filter_regions()
        {

            return of_filter_regions(this.of_get_componentname());

            /*?

            // Purpose: 	Filter the user's default region
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            string sObjectList;
            string sObject;
            string ls_Coltype;
            string sTab = '~';
            int ll_Ret;
            int ll_DefaultRegion;
            DataControlBuilder dwc_contract_type;
            // Get the user's default region
            ll_DefaultRegion = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
            // Get Objects list
            sObjectList = this.Describe("Datawindow.Objects");
            while ( sObjectList.Len() > 0) {
                // Extract an object name
                if (Pos(sObjectList, sTab) > 0) {
                    sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
                    sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
                }
                else {
                    sObject = sObjectList;
                    sObjectList = "";
                }
                // Is it region id?
                if (Pos(sObject, "region_id") > 0) {
                    // Determine if dddw 
                    ls_Coltype = this.Describe(sObject + ".dddw.name");
                    // If no, get next object name
                    if (ls_Coltype == '!' || ls_Coltype == '?') {
                        continue;
                    }
                    // Set the Region
                    if (ll_DefaultRegion >= 0) {
                        this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
                        this.Modify("Region_Id.Protect=1");
                        this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
                        // 			This.Modify ( "Region_Id.Background.Color='13160660'")
                    }
                }
            }
            return SUCCESS;
            */
        }

        public virtual int of_protectcolumns()
        {
            // Purpose: 	Protect all columns
            // Author: 	NOT Rex Bustria
            /*?
            int ll_Ctr = 0;
            string ls_Coltype;
            string ls_Describe;
            string sObjectList;
            string sObject;
            string sTab = '~';
            string ls_Result;
            sObjectList = Describe("Datawindow.Objects");
            while ( sObjectList.Len() > 0) {
                if (Pos(sObjectList, sTab) > 0) {
                    sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
                    sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
                }
                else {
                    sObject = sObjectList;
                    sObjectList = "";
                }
                ls_Result = Describe(sObject + ".Background.Color");
                // 16776960
                // 79216776, 1073741824)
                // Modify (  sObject + ".Background.Color='79216776'")
                if (ls_Result == "16776960") {
                    ls_Result = Modify(sObject + ".Background.Color=\'16776960~tIf ( IsRowNew ( ),16776960,79216776)\'");
                }
                else {
                    ls_Result = Modify(sObject + ".Background.Color=\'79216776~tIf ( IsRowNew ( ),1073741824,79216776)\'");
                }
                ls_Describe = this.Describe(sObject + ".edit.name");
                if (ls_Describe != '!') {
                    // This.Modify (  sObject + ".Edit.DisplayOnly=Yes")
                }
                ls_Describe = this.Describe(sObject + ".editmask.name");
                if (ls_Describe != '!') {
                    this.Modify(sObject + ".EditMask.DisplayOnly=Yes");
                }
                ls_Result = this.Modify(sObject + ".Protect=\'1~tIf ( IsRowNew ( ),0,1)\'");
                // 	ls_Describe = This.Describe ( sObject+ ".dddw.DataColumn")
                // 	If ls_Describe <> '!' and ls_Describe <> '?' THEN
                // 		//This.Modify (  sObject + ".Tabsequence=0")
                // 	End if
            }
             */
            if (this.RowCount <= 0)
                return 0;
            EntityBase l_temp = this.DataObject.GetItem<EntityBase>();
            foreach (Control var in this.DataObject.Controls)
            {
                if (var is Label)
                {
                    continue;
                }

                //TextBox
                if (var is TextBox)
                {
                    if (l_temp.IsNew)
                    {
                        ((TextBox)var).ReadOnly = false;
                        continue;
                    }
                    else
                    {
                        ((TextBox)var).ReadOnly = true;
                        continue;
                    }
                }
                //NumericalMaskedTextBox
                if (var is NumericalMaskedTextBox)
                {
                    if (l_temp.IsNew)
                    {
                        ((NumericalMaskedTextBox)var).ReadOnly = false;  
                        ((NumericalMaskedTextBox)var).BackColor = System.Drawing.Color.White;
                        ((NumericalMaskedTextBox)var).TabStop = true;
                    
                        continue;
                    }
                    else
                    {
                        ((NumericalMaskedTextBox)var).ReadOnly = true;
                        ((NumericalMaskedTextBox)var).BackColor = System.Drawing.SystemColors.Control;
                        ((NumericalMaskedTextBox)var).TabStop = false;
                        continue;
                    }
                }
                //DateTimeMaskedTextBox
                if (var is DateTimeMaskedTextBox)
                {
                    if (l_temp.IsNew)
                    {
                        ((DateTimeMaskedTextBox)var).ReadOnly = false;
                        continue;
                    }
                    else
                    {
                        ((DateTimeMaskedTextBox)var).ReadOnly = true;
                        continue;
                    }
                }
                //DataEntityGrid
                if (var is DataEntityGrid)
                {
                    if (l_temp.IsNew)
                    {
                        ((DataEntityGrid)var).ReadOnly = false;
                        continue;
                    }
                    else
                    {
                        ((DataEntityGrid)var).ReadOnly = true;
                        continue;
                    }
                }
                //other control type add here
                if (var is Metex.Windows.DataEntityGrid)
                {
                    ((Metex.Windows.DataEntityGrid)var).CellFormatting -= new DataGridViewCellFormattingEventHandler(UDw_CellFormatting);
                    ((Metex.Windows.DataEntityGrid)var).CellFormatting += new DataGridViewCellFormattingEventHandler(UDw_CellFormatting);
                    if (l_temp.IsNew)
                    {
                        var.Enabled = true;
                        continue;
                    }
                    else
                    {
                        var.Enabled = false;
                        continue;
                    }
                }
                //default control type
                if (l_temp.IsNew)
                {
                    var.Enabled = true;
                    continue;
                }
                else
                {
                    var.Enabled = false;
                    continue;
                }

            }
            return 0;
        }

        void UDw_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            EntityBase ll_temp = this.DataObject.GetItem<EntityBase>(e.RowIndex);
            if (ll_temp.IsNew)
            {
                ((Metex.Windows.DataEntityGrid)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                e.CellStyle.BackColor = System.Drawing.Color.White;
            }
            else
            {
                ((Metex.Windows.DataEntityGrid)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                e.CellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            }
        }

        public virtual int of_unprotectColumns()
        {
            // Purpose: 	Unprotect columns. Migrated from old code
            // Author: 	NOT Rex Bustria
            /*?
            this.DataObject.Enaled = true;
            while ( sObjectList.Len() > 0) {
                if (Pos(sObjectList, sTab) > 0) {
                    sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
                    sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
                }
                else {
                    sObject = sObjectList;
                    sObjectList = "";
                }
                if (Modify(sObject + ".Protect=\"0~tif ( isRowNew ( ),0,0)\"") == "") {
                    ll_Ctr++;
                    SetTabOrder(sObject, ll_Ctr);
                }
            } */
            return 0;
        }

        public virtual int of_set_regionid(int? al_regionId)
        {
            il_RegionId = al_regionId;
            return SUCCESS;
        }

        public virtual int? of_get_regionid()
        {
            return il_RegionId;
        }

        public virtual int of_set_readpriv(bool ab_priv)
        {
            ib_AllowRead = ab_priv;
            return SUCCESS;
        }

        public virtual int of_set_createpriv(bool ab_priv)
        {
            ib_AllowCreate = ab_priv;
            return SUCCESS;
        }

        public virtual int of_set_modifypriv(bool ab_priv)
        {
            ib_AllowModify = ab_priv;
            return SUCCESS;
        }

        public virtual int of_set_deletepriv(bool ab_priv)
        {
            ib_AllowDelete = ab_priv;
            return SUCCESS;
        }

        public virtual bool of_get_readpriv()
        {
            return ib_AllowRead;
        }

        public virtual bool of_get_createpriv()
        {
            return ib_AllowCreate;
        }

        public virtual bool of_get_modifypriv()
        {
            return ib_AllowModify;
        }

        public virtual bool of_get_deletepriv()
        {
            return ib_AllowDelete;
        }

        public virtual bool uf_setaudit(bool ab_Audit)
        {
            /*? ib_setaudit = ab_Audit;
            if (ib_setaudit == true && !(IsValid(inv_AuditManager))) {
                inv_AuditManager = new URdsAuditmanager();
            } */
            return ib_setaudit;
        }

        public virtual int of_bypasscontracttypefilter(bool ab_Bypass)
        {
            ib_BypassContractTypeFilter = ab_Bypass;
            return SUCCESS;
        }

        public virtual int zof_filter_regions()
        {
            /*?
            // Purpose: 	Filter the user's default region
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            string sObjectList;
            string sObject;
            string ls_Coltype;
            string sTab = '~';
            int ll_Ret;
            int ll_DefaultRegion;
            DataControlBuilder dwc_contract_type;
            // Get the user's default region
            ll_DefaultRegion = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
            // Get Objects list
            sObjectList = this.Describe("Datawindow.Objects");
            while ( sObjectList.Len() > 0) {
                // Extract an object name
                if (Pos(sObjectList, sTab) > 0) {
                    sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
                    sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
                }
                else {
                    sObject = sObjectList;
                    sObjectList = "";
                }
                // Is it region id?
                if (Pos(sObject, "region_id") > 0) {
                    // Determine if dddw 
                    ls_Coltype = this.Describe(sObject + ".dddw.name");
                    // If no, get next object name
                    if (ls_Coltype == '!' || ls_Coltype == '?') {
                        continue;
                    }
                    // Set the Region
                    if (ll_DefaultRegion >= 0) {
                        this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
                        this.Modify("Region_Id.Protect=1");
                        this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
                        // 			This.Modify ( "Region_Id.Background.Color='13160660'")
                    }
                }
            }
             */
            return SUCCESS;
        }

        public DataUserControlContainer ldwc;
        public int? ll_row = -1; //jlwang:

        public virtual int of_filter_regions(string as_componentname)
        {

            // Purpose: 	Filter the user's default region
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            //  PBY 03/09/2002 SR#4450
            // /See if bypassed
            if (ib_BypassRegionFilter)
            {
                return SUCCESS;
            }
            // If not ib_RegionColumnFound Then
            if (!(this.of_hascolumn("region_id")))
            {
                return SUCCESS;
            }

            bool lb_HasAccessToOwnRegion = false;
            string ls_Region = "";
            string ls_Filter;
            string ls_TabCharacter = "~";
            int ll_Ret;
            int? ll_DefaultRegion;
            int? ll_Region;
            int ll_ctr;
            int ll_NumRegions = 0;
            ldwc = new DataUserControlContainer();// DataControlBuilder ldwc;
            DataUserControl dwc_contract_type;// DataControlBuilder dwc_contract_type;
            // Get the user's default region
            ll_DefaultRegion = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
            // Get regions user is allowed to see for the component

            id = new List<int?>();  //jlwang:

            if (ids_UserComponentRegions.RowCount == 0)
            {
                ll_Ret = ids_UserComponentRegions.Retrieve(new object[] { StaticVariables.gnv_app.of_getuserid(), as_componentname });
            }

            // Create filter expression
            // ls_Filter = " region_id in  ( " +ll_DefaultRegion.ToString()+','
            ls_Filter = " region_id in  ( ";
            // Scan region ids to build regions list
            for (ll_ctr = 0; ll_ctr < ids_UserComponentRegions.RowCount; ll_ctr++)
            {
                ll_Region = ids_UserComponentRegions.GetValue<int?>(ll_ctr, "region_id");
                ls_Filter += ll_Region.ToString() + ",";
                id.Add(ll_Region);

                if (ll_Region == 0 || ll_DefaultRegion == ll_Region)
                {
                    lb_HasAccessToOwnRegion = true;
                }
                ll_NumRegions++;
            }

            // Add user's own region
            if (lb_HasAccessToOwnRegion == true)
            {
                ls_Filter += ll_DefaultRegion.ToString() + ",";
                id.Add(ll_DefaultRegion);
            }
            // Remove trailing commas
            if (ls_Filter.Substring(ls_Filter.Length - 1) == ",")
            {
                ls_Filter = ls_Filter.Substring(0, ls_Filter.Length - 1);
            }
            // Add trailing )
            if (ls_Filter.Length > 0)
            {
                ls_Filter += ")";
            }

            // Final check for national users
            if (lb_HasAccessToOwnRegion && ll_DefaultRegion == null)
            {
                ls_Filter = "region_id >= 0"; //for support blank row ,set it equal to 0;
                id.Clear();
            }
            //this.GetChild("region_id", ldwc);
            ldwc.DataObject = this.DataObject.GetChild("region_id");

            if (ll_NumRegions > 0)
            {
                //ldwc.SetFilter(ls_filter);
                //ldwc.Filter();
                ldwc.DataObject.FilterString = ls_Filter;
                ldwc.DataObject.FilterOnce<DddwRegions>(FilterMu);

                // Set the Region
                if (ll_NumRegions == 1 && ll_DefaultRegion > 0)
                {
                    //this.Modify("Region_Id.Protect=1");
                    ((DataEntityCombo)this.DataObject.GetControlByName("region_id")).Enabled = false;
                    //?this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
                }
                if (lb_HasAccessToOwnRegion)
                {
                    if (ll_DefaultRegion > 0)
                    {
                        ll_row = ll_DefaultRegion;//this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
                    }
                }
                else
                {
                    ll_Region = ids_UserComponentRegions.GetValue<int?>(0, "region_id");//.GetItemNumber(1, "region_id");
                    ll_row = ll_Region;// this.Modify("region_id.initial=\'" + ll_region.ToString() + '\'');
                }
            }
            else if (lb_HasAccessToOwnRegion)
            {
                ls_Filter = "region_id = " + ll_DefaultRegion.ToString();
                //ldwc.SetFilter(ls_filter);
                //ldwc.Filter();
                ll_row = ll_DefaultRegion; //this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
                ldwc.DataObject.FilterOnce<DddwRegions>(FilterDF);
            }
            else
            {
                ls_Filter = "region_id = -99";
                //ldwc.SetFilter(ls_Filter);
                //ldwc.Filter();
                ldwc.DataObject.FilterString = ls_Filter;
                ldwc.DataObject.FilterOnce<DddwRegions>(FilterRG);

                //ldwc.InsertRow(0);
                ldwc.InsertItem<DddwRegions>(0);
                //add by mkwang
                insertRow(ldwc.DataObject, 0);
                ldwc.SetValue(0, "region_id", -99);
                ldwc.SetValue(0, "rgn_name", "<No Access>");
                insertRow(ldwc.DataObject, 0);
                ldwc.DataObject.DeleteItemAt(0);

                //ldwc.SetValue(0, "region_id", -99);  //.SetItem(1, "region_id", -(99));
                //ldwc.SetValue(0, "rgn_name", "<No Access>");//.SetItem(1, "rgn_Name", "<No Access>");

                //this.Modify("Region_Id.Protect=1");
                ((DataEntityCombo)this.DataObject.GetControlByName("region_id")).Enabled = false;

                //?this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");

                ll_row = -99; //this.Modify("region_id.initial=\'-99\'");
            }

            return SUCCESS;
        }
        //add by mkwang
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

        List<int?> id = null;

        bool FilterRG(DddwRegions item)
        {
            if (!string.IsNullOrEmpty(item.RegionId.ToString()) && (item.RegionId == -99))
            {
                return true;
            }
            return false;
        }

        bool FilterMu(DddwRegions item)
        {
            if (id.Count > 0)
            {
                foreach (int? _id in id)
                {
                    if (_id == item.RegionId)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                if (!string.IsNullOrEmpty(item.RegionId.ToString()) && (item.RegionId >= 0))
                {
                    return true;
                }
                return false;
            }
        }

        bool FilterDF(DddwRegions item)
        {
            if (!string.IsNullOrEmpty(item.RegionId.ToString()) && (item.RegionId == ll_row))
            {
                return true;
            }
            return false;
        }

        public virtual bool of_hascolumn(string as_columnname)
        {
            // Purpose: 	Filter the user's default region
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            if (this.DataObject == null)
                return false;
            if (this.DataObject.GetControlByName(as_columnname) != null)
                return true;
            else if (this.DataObject.GetControlByName("grid") != null)
                return ((DataEntityGrid)this.DataObject.GetControlByName("grid")).Columns.Contains(as_columnname);
            else
                return false;
        }

        public virtual int of_bypassregionfilter(bool ab_Bypass)
        {
            ib_BypassRegionFilter = ab_Bypass;
            return SUCCESS;
        }

        public virtual void uf_settoolbar()
        {
            /*?
            //  TJB  Release 6.8.9 fixup  Nov 2005  NEW
            //  Set the toolbar according to the privileges set for
            //  this datawindow (via the of_set_xxxxxPriv functions)
            MMainMenu lm_SheetMenu;
            MMainMenu lm_FrameMenu;
            MRdsDw lm_Dw;
            WMaster lw_Master;
            lm_Dw = new MRdsDw();
            // Get sheet menu
            this.of_GetParentWindow(lw_Master);
            if (IsValid(lw_Master)) {
                lm_SheetMenu = lw_Master.MenuID;
            }
            else {
                return;
            }
            // Process frame menu
            if (IsValid(StaticVariables.gnv_app.of_getframe())) {
                lm_FrameMenu = StaticVariables.gnv_app.of_getframe().MenuID;
            }
            if (lm_FrameMenu != null) {
                lm_FrameMenu.of_set_editoff();
            }
            if (!(IsValid(lm_SheetMenu))) {
                return;
            }
            // Turn off sheet menuitems
            lm_SheetMenu.of_set_editoff();
            if (IsValid(inv_RowSelect)) {
                if (inv_RowSelect.of_GetStyle() == 1 || inv_RowSelect.of_GetStyle() == 2) {
                    lm_SheetMenu.m_Edit.m_SelectAll.Enabled = true;
                    lm_SheetMenu.m_Edit.m_SelectAll.visible = true;
                }
            }
            // Turn off rmb menu items
            lm_Dw.m_table.m_Insert.Enabled = false;
            lm_Dw.m_table.m_Insert.Visible = false;
            lm_Dw.m_table.m_Delete.Enabled = false;
            lm_Dw.m_table.m_Delete.Visible = false;
            lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = false;
            lm_Dw.m_table.m_SaveChangesToDatabase.Visible = false;
            // Process the rmb menuitems
            if (this.of_GetUpdateable()) {
                if (this.of_get_createpriv()) {
                    lm_SheetMenu.of_set_insertrow();
                    lm_Dw.m_table.m_Insert.enabled = true;
                    lm_Dw.m_table.m_Insert.visible = true;
                    lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
                    lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
                }
                if (this.of_get_modifypriv()) {
                    lm_SheetMenu.of_set_update();
                    lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
                    lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
                }
                if (this.of_get_deletepriv()) {
                    lm_SheetMenu.of_set_deleterow();
                    lm_Dw.m_table.m_Delete.Enabled = true;
                    lm_Dw.m_table.m_Delete.Visible = true;
                    lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
                    lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
                }
            } */
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Height = 139;
            this.Width = 162;
            this.ResumeLayout();
        }

        public virtual int of_SetUpdateable(bool ab_isupdateable)//ybfan
        {
            ib_IsUpdateable = ab_isupdateable;
            return SUCCESS;
        }

        public virtual bool of_GetUpdateable()
        {
            return ib_IsUpdateable;
        }

        public virtual int of_Reset()//ybfan
        {
            int li_rc;
            //if (IsValid(inv_Linkage))
            //{
            //    li_rc = inv_Linkage.of_reset();
            //}
            //else
            //{
            //    li_rc = this.Reset();
            //}
            this.Reset();
            return 0;//return li_rc;
        }

        public virtual void Reset()
        {
            DataObject.Reset();
            //added by jlwang
            System.Reflection.FieldInfo field = typeof(Metex.Windows.DataUserControl).GetField("deletedList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            ((IList<Metex.Core.ISavableEntity>)field.GetValue(this.DataObject)).Clear();
        }

        public virtual int of_SetRowSelect(bool ab_switch)
        {
            //?if (ab_switch)
            //{
            //    if (IsNull(inv_RowSelect) || !(IsValid(inv_RowSelect)))
            //    {
            //        inv_RowSelect = new n_cst_dwsrv_rowselection();
            //        inv_RowSelect.of_setrequestor(this);
            //        return SUCCESS;
            //    }
            //}
            //else if (IsValid(inv_RowSelect))
            //{
            //    inv_RowSelect = null;
            //    return SUCCESS;
            //}
            return NO_ACTION;
        }

        public virtual int of_SetResize(bool ab_switch)
        {
            //?if (ab_switch)
            //{
            //    if (IsNull(inv_Resize) || !(IsValid(inv_Resize)))
            //    {
            //        inv_Resize = new n_cst_dwsrv_resize();
            //        inv_Resize.of_setrequestor(this);
            //        inv_Resize.of_setorigsize(this.Width, this.Height);
            //        return SUCCESS;
            //    }
            //}
            //else if (IsValid(inv_Resize))
            //{
            //    inv_Resize = null;
            //    return SUCCESS;
            //}
            return NO_ACTION;
        }

        public virtual string of_get_componentname()
        {
            return is_Componentname;
        }

        public virtual int of_set_componentname(string as_Componentname)
        {
            is_Componentname = as_Componentname;
            return 1;
        }

        // TJB  July-2011: Added
        public virtual bool IsNew(int row)
        {
            if (row >= 0 && row < this.DataObject.RowCount)
                return ((Metex.Core.EntityBase)this.DataObject.BindingSource.List[row]).IsNew;
            else
                return false;
        }

        public virtual int ModifiedCount()
        {
            int l_count = 0;
            for (int row = 0; row < this.DataObject.RowCount; row++)
            {
                if (((Metex.Core.EntityBase)this.DataObject.BindingSource.List[row]).IsDirty)
                    l_count++;
            }
            return l_count;
        }

        //added by jlwang
        //public virtual int DeleteCount()
        //{
        //    int l_count = 0;
        //    for (int i = 0; i < this.DataObject.RowCount ; i++)
        //    {
        //        if (((EntityBase)this.DataObject.BindingSource.List[i]).IsDeleted)
        //            l_count++;
        //    }
        //    return l_count;
        //}

        //added by jlwang

        public virtual int NewCount()
        {
            int l_count = 0;
            for (int i = 0; i < this.DataObject.RowCount; i++)
            {
                if (((EntityBase)this.DataObject.BindingSource.List[i]).IsNew)
                    l_count++;
            }
            return l_count;
        }

        public virtual int of_CheckRequired(UDw adw_buffer, ref int al_row, ref int ai_col, ref string as_colname, bool ab_updateonly)
        {

            FormBase lw_pfcparent;//? w_master lw_pfcparent;
            FormBase lw_parent;
            bool lb_skipmessage = false;
            //StringArray ls_msgparm = new StringArray(2);
            Dictionary<int, string> ls_msgparm = new Dictionary<int, string>();
            int li_rc = 1;
            //  Check arguments
            if (adw_buffer == null || al_row == null || ai_col == null || as_colname == null)
            {
                return FAILURE;
            }

            Cursor.Current = Cursors.WaitCursor;
            //  Call FindRequired to locate first error, if any

            //?if (this.FindRequired(adw_buffer, al_row, ai_col, as_colname, ab_updateonly) < 0) {
            //?    return FAILURE;
            //?}

            //  Double Check if failure condition was ecountered.
            if (al_row < 0)
            {
                return FAILURE;
            }
            //  Check if no missing values were found.
            if (al_row == 0)
            {
                return 0;
            }
            //  -- A Missing Value was encountered. --
            //  Get a reference to the window

            //?this.of_GetParentWindow(lw_parent);
            //?if (IsValid(lw_parent)) {
            //?    if (lw_parent.TriggerEvent("pfc_descendant") == 1) {
            //?        lw_pfcparent = lw_parent;
            //?    }
            //?}

            //  Make sure the window is not closing.  

            //?if (lw_pfcparent != null ) 
            //?{
            //?    if (lw_pfcparent.of_getclosestatus()) {
            //?       //  It is closing, so don't show errors now.	
            //?       lb_skipmessage = true;
            //?   }
            //?}

            //  Skip the message if the window is closing.	
            if (!lb_skipmessage)
            {
                //  Call stub function to either handle condition or provide a more suitable
                //  column name.
                //?li_rc = this.pfc_checkrequirederror(al_row, as_colname);
                //?if (li_rc < 0) {
                //?    return -(1);
                //?}
                if (li_rc >= 1)
                {
                    //  Display condition.
                    /*?if (StaticVariables.gnv_app.inv_error != null ) 
                    {
                        ls_msgparm[1] = as_colname;
                        ls_msgparm[2] = al_row.ToString();
                        StaticVariables.gnv_app.inv_error.of_message("pfc_requiredmissing", ls_msgparm, StaticVariables.gnv_app.iapp_object.DisplayName);
                    }
                    else   */
                    {
                        //?of_MessageBox("pfc_checkrequired_missingvalue", StaticVariables.gnv_app.iapp_object.DisplayName, "Required value missing for " + as_colname + " on row " + al_row.ToString() + ".  Please enter a value.", information!, ok!, 1);
                        MessageBox.Show("Required value missing for " + as_colname + " on row " + al_row.ToString() + ".  Please enter a value.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //  Make sure row/column gets focus.
                    //?this.SetRow(al_row);
                    //?this.ScrollToRow(al_row);
                    //?this.SetColumn(ai_col);
                    //?this.Focus( );
                }
            }
            //  Return that a required column does contain a null value.
            return 1;
        }
    }

    public struct UsInstance
    {

        public int first_column;

        public DateTime last_updated;

        public int security_access_level;

        public int security_group;

    }
}
