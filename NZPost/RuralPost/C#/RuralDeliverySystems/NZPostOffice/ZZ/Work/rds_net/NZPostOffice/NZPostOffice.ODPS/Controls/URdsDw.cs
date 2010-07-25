using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using System.Windows.Forms;
using Metex.Core;
using Metex.Windows;
using System.IO;
using NZPostOffice.DataControls;

namespace NZPostOffice.ODPS.Controls
{
    //declare  delegates.
    public delegate void EventDelegate(object send, EventArgs e);
    public delegate void UserEventDelegate();

    public class URdsDw : UDw
    {
        // TJB  RPI_005  June 2010
        // Changed ValidateExportValue to allow " " strings to pass untrimmed

        public string is_Componentname = String.Empty;

        //public const int SUCCESS = 1;

        # region delegate

        public UserEventDelegate Constructor;
        public EventDelegate URdsDwItemFocuschanged;

        #endregion

        public URdsDw()
        {
            InitializeComponent();
            InitializeEventDelegate();
        }

        #region Initialize Delegate

        private void InitializeEventDelegate()
        {
            Constructor = new UserEventDelegate(constructor);

            this.DataObjectChanged += new EventHandler(URdsDw_DataObjectChanged);
            this.DataObjectChanged += new EventHandler(AttachEvents);
        }

        private void AttachEvents(object sender, EventArgs e)
        {
            if (DataObject != null)
            {
                //this.DataObject.EditChanged += new EventHandler(URdsDwEditChanged);
                //this.DataObject.RetrieveEnd += new EventHandler(URdsDwRetrieveEnd);

                foreach (Control c in DataObject.Controls)
                {
                    c.Enter += new EventHandler(DoTriggerItemFocusChanged);
                }
            }
        }

        private void DoTriggerItemFocusChanged(object sender, EventArgs e)
        {
            OnItemFocusChanged(e);
        }

        protected void OnItemFocusChanged(EventArgs e)
        {
            if (URdsDwItemFocuschanged != null)
            {
                URdsDwItemFocuschanged(this, e);
            }
        }

        private bool _fireConstructor = false;

        public bool FireConstructor
        {
            get
            {
                return _fireConstructor;
            }
            set
            {
                if (value == true && _fireConstructor != value)
                {
                    _fireConstructor = value;
                    OnConstructor();
                }
            }
        }

        private void OnConstructor()
        {
            if (Constructor != null)
            {
                Constructor();
            }
        }

        #endregion

        public virtual void ue_deleteitem()
        {
            // allow del key to clear column
            string sName;
            int lRow;
            int? lNull;
            string sNull;
            DateTime? dNull;
            lNull = null;
            sNull = null;
            dNull = null;
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyDelete))
            {
                sName = this.GetColumnName();
                // if contract type and user has no full rights
                if (sName.ToLower() == "ct_key")
                {
                    if (!(StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_isnationaluser()))
                    {
                        if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types().RowCount != StaticVariables.gnv_app.of_gettotalcontracttypes())
                        {
                            return;
                        }
                    }
                }
                if (sName.ToLower() == "region_id")
                {
                    if (!(StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_isnationaluser()))
                    {
                        return;
                    }
                }
                /*? if(Trim(this.Describe(sName + ".dddw.name")) != '?') 
                   {
                       // PowerBuilder 'Choose Case' statement converted into 'if' statement
                   unknown TestExpr = Upper(Left(this.Describe(sName + ".coltype"), 4));
                       if (TestExpr == "CHAR")
                       {
                           // this.SetItem(this.GetRow(), sName, sNull);
                           this.SetValue(this.GetRow(), sName, sNull);
                       }
                       else if (TestExpr == "NUMB" || TestExpr == "DECI")
                       {
                           //this.SetItem(this.GetRow(), sName, lNull);
                           this.SetValue(this.GetRow(), sName, lNull);
                       }
                       else if (TestExpr == "DATE")
                       {
                           //this.SetItem(this.GetRow(), sName, dNull);
                           this.SetValue(this.GetRow(), sName, dNull);
                       }
                   }*/
            }
        }

        //?public virtual void ue_saveas()
        //{
        //    SaveAs();
        //}

        //?public virtual void editchanged()
        //{
        //    // enable autocomplete
        //    string sText;
        //    sText = this.GetText();
        //    if (Left(this.GetText(), 1) == ' ')
        //    {
        //        this.SetText(Mid(sText, 2));
        //    }
        //}

        public virtual void URdsDw_RetrieveEnd(object sender, EventArgs e)
        {
            //?base.retrieveend();
            this.of_filter();
        }

        public virtual void URdsDw_DoubleClick(object sender, EventArgs e)
        {
            //?if (row == 0)
            //{
            //    return;
            //}

            // Process backdoor entry columns
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyCtrl) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyShift) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyAlt))
            {
                if (MessageBox.Show("Are you sure you want to unlock all columns?\r\nUse this facility only when you c" + "annot access data \r\nthat needs to be changed.", "Unlock columns", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    of_unprotectColumns();
                    //this.of_setupdateable(true);
                    this.of_SetUpdateable(true);
                    MessageBox.Show("All columns have been unprotected.", "Unlock columns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public virtual void constructor()
        {
            // Set up transaction object
            ib_RegionColumnFound = this.of_hascolumn("region_id");
            ids_UserComponentRegions = new DataUserControlContainer();
            ids_UserComponentRegions.DataObject = new DUserComponentRegionlist();
        }

        //?public virtual void u_rds_dw_itemchanged()
        //{
        //    base.itemchanged();
        //    this.ue_PostItemChanged(row, dwo, data);
        //}

        //?public virtual void u_rds_dw_clicked()
        //{
        //    base.clicked();
        //    // Make sure we have aplace to process post-0clicks
        //    this.ue_postclicked(xpos, ypos, row, dwo);
        //}

        //?public virtual void pfc_insertrow()
        //{
        //    int ll_Row;
        //    ll_Row = base.pfc_insertrow();
        //    ScrollToRow(ll_Row);
        //    this.of_filter();
        //    return ll_Row;
        //}

        //?public virtual void pfc_preupdate()
        //{
        //    base.pfc_preupdate();
        //    int lActionCode = 0;
        //    ilRow = this.GetNextModified(0, primary!);
        //    while (ilRow > 0) {
        //        isErrorColumn = "";
        //        StaticMessage.WordParm =  0;
        //        StaticMessage.LongParm =  ilRow;
        //        this.ue_validate();
        //        if (!(gnv_app.of_IsEmpty(isErrorColumn))) {
        //            this.ScrollToRow(ilRow);
        //            this.SetColumn(isErrorColumn);
        //            lActionCode = 1;
        //            ilRow = 0;
        //        }
        //        else {
        //            ilRow = this.GetNextModified(ilRow, primary!);
        //        }
        //    }
        //// return 1
        //}

        //?public virtual void pfc_prermbmenu()
        //{
        // m_main_menu 	lm_SheetMenu
        // m_main_menu 	lm_FrameMenu
        // m_rds_dw 		lm_Dw
        // w_Master 		lw_Master
        // Long				ll_Temp
        // 
        // lm_Dw = Create m_rds_dw 
        // 
        // //Get sheet menu
        // This.of_GetParentWindow ( lw_Master)
        // If isValid ( lw_Master) Then
        // 	lm_SheetMenu = lw_Master.menuid
        // Else
        // 	Return
        // End if
        // 
        // //Process frame menu
        // lm_FrameMenu = gnv_App.of_getFrame ( ).MenuId
        // If isValid ( lm_FrameMenu) Then
        // 	lm_FrameMenu.Dynamic of_Set_EditOff ( )
        // End if
        // 
        // //Turn off sheet menuitems
        // if isValid ( lm_SheetMenu) Then lm_SheetMenu.Dynamic of_Set_EditOff ( )
        // 
        // //Turn off rmb menu items
        // lm_Dw.m_Table.m_Insert.Enabled = False
        // lm_Dw.m_Table.m_Insert.Visible = False
        // 
        // lm_Dw.m_Table.m_Delete.Enabled= False
        // lm_Dw.m_Table.m_Delete.Visible= False
        // 
        // lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= False
        // lm_Dw.m_Table.m_SaveChangesToDatabase.Visible = False
        // 
        // //Process the rmb menuitems
        // If This.of_GetUpdateable ( ) Then
        // 
        // 	If This.of_Get_CreatePriv ( ) Then
        // 		if isValid ( lm_SheetMenu) Then  lm_SheetMenu.Dynamic of_Set_InsertRow ( )
        // 
        // 		lm_Dw.m_Table.m_Insert.enabled= True
        // 		lm_Dw.m_Table.m_Insert.visible= True
        // 
        // 
        // 		lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= True		
        // 		lm_Dw.m_Table.m_SaveChangesToDatabase.Visible= True		
        // 	End if
        // 
        // 	If This.of_Get_ModifyPriv ( ) Then
        // 		if isValid ( lm_SheetMenu) Then lm_SheetMenu.Dynamic of_set_Update ( )
        // 		lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= True
        // 		lm_Dw.m_Table.m_SaveChangesToDatabase.Visible= True
        // 	End if
        // 
        // 	If This.of_Get_DeletePriv  ( ) Then
        // 		if isValid ( lm_SheetMenu) Then lm_SheetMenu.Dynamic of_set_DeleteRow ( )
        // 		lm_Dw.m_Table.m_Delete.Enabled= True
        // 		lm_Dw.m_Table.m_Delete.Visible= True
        // 		lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= True
        // 		lm_Dw.m_Table.m_SaveChangesToDatabase.Visible= True
        // 	End if
        // 
        // End if
        // 
        // if isValid ( inv_RowSelect) then
        // 	if inv_RowSelect.of_GetStyle ( )=1 or inv_RowSelect.of_GetStyle ( )=2 then
        // 		if isValid ( lm_SheetMenu) Then lm_SheetMenu.m_Edit.m_SelectAll.Enabled=true
        // 		if isValid ( lm_SheetMenu) Then lm_SheetMenu.m_Edit.m_SelectAll.visible=true
        // 		lm_Dw.m_Table.m_SelectAll.Enabled= True
        // 		lm_Dw.m_Table.m_SelectAll.Visible= True
        // 
        // 	End if
        // end if
        // 
        // //Don't forget to assign current dw as parent
        // lm_Dw.of_SetParent ( This)
        // am_dw = lm_Dw
        // 
        //}

        //?public virtual void u_rds_dw_getfocus()
        //{
        //    base.getfocus();
        //     m_main_menu 	lm_SheetMenu
        //     m_main_menu 	lm_FrameMenu
        //     m_rds_dw 		lm_Dw
        //     w_Master 		lw_Master
        //     lm_Dw = Create m_rds_dw 
        //     //Get sheet menu
        //     This.of_GetParentWindow ( lw_Master)
        //     If isValid ( lw_Master) Then
        //        lm_SheetMenu = lw_Master.menuid
        //     Else
        //        Return
        //     End if
        //     //Process frame menu
        //     if isValid ( gnv_App.of_GetFrame ( )) Then
        //        lm_FrameMenu = gnv_App.of_getFrame ( ).MenuId
        //     End if
        //     If isValid ( lm_FrameMenu) Then
        //        lm_FrameMenu.Dynamic of_Set_EditOff ( )
        //     End if
        //     If not isValid ( lm_SheetMenu) Then
        //        Return
        //     End if
        //     //Turn off sheet menuitems
        //     lm_SheetMenu.Dynamic of_Set_EditOff ( )
        //     if isValid ( inv_RowSelect) then
        //        if inv_RowSelect.of_GetStyle ( )=1 or inv_RowSelect.of_GetStyle ( )=2 then
        //            lm_SheetMenu.m_Edit.m_SelectAll.Enabled=true
        //            lm_SheetMenu.m_Edit.m_SelectAll.visible=true
        //        End if
        //     end if
        //     //Turn off rmb menu items
        //     lm_Dw.m_Table.m_Insert.Enabled = False
        //     lm_Dw.m_Table.m_Insert.Visible = False
        //     lm_Dw.m_Table.m_Delete.Enabled= False
        //     lm_Dw.m_Table.m_Delete.Visible= False
        //     lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= False
        //     lm_Dw.m_Table.m_SaveChangesToDatabase.Visible = False
        //     //Process the rmb menuitems
        //     If This.of_GetUpdateable ( ) Then
        //        If This.of_Get_CreatePriv ( ) Then
        //            lm_SheetMenu.Dynamic of_Set_InsertRow ( )
        //            lm_Dw.m_Table.m_Insert.enabled= True
        //            lm_Dw.m_Table.m_Insert.visible= True
        //            lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= True		
        //            lm_Dw.m_Table.m_SaveChangesToDatabase.Visible= True		
        //        End if
        //        If This.of_Get_ModifyPriv ( ) Then
        //            lm_SheetMenu.Dynamic of_set_Update ( )
        //            lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= True
        //            lm_Dw.m_Table.m_SaveChangesToDatabase.Visible= True
        //        End if
        //        If This.of_Get_DeletePriv  ( ) Then
        //            lm_SheetMenu.Dynamic of_set_DeleteRow ( )
        //            lm_Dw.m_Table.m_Delete.Enabled= True
        //            lm_Dw.m_Table.m_Delete.Visible= True
        //            lm_Dw.m_Table.m_SaveChangesToDatabase.Enabled= True
        //            lm_Dw.m_Table.m_SaveChangesToDatabase.Visible= True
        //        End if
        //     End if
        //    // 
        //}

        //?protected override void rbuttondown()
        //{
        //     base.rbuttondown();
        //     il_RightClicked = row;
        //}

        //?public virtual void updatestart()
        //{
        //   int lActionCode = 0;
        //   ilRow = this.GetNextModified(0, primary!);
        //   while (ilRow > 0) {
        //       isErrorColumn = "";
        //       StaticMessage.WordParm =  0;
        //       StaticMessage.LongParm =  ilRow;
        //       this.ue_validate();
        //       if ( isErrorColumn.Len() > 0) {
        //           this.ScrollToRow(ilRow);
        //           this.SetColumn(isErrorColumn);
        //           lActionCode = 1;
        //           ilRow = 0;
        //       }
        //       else {
        //           ilRow = this.GetNextModified(ilRow, primary!);
        //       }
        //   }
        //   return lActionCode;
        //}

        //?public virtual void pfc_selectall()
        //{
        //    base.pfc_selectall();
        //    this.SelectRow(0, true);
        //    return 1;
        //}

        //?public virtual void pfc_preinsertrow()
        //{
        //    base.pfc_preinsertrow();
        //    if (!ib_AllowCreate)
        //    {
        //        // 	return 0
        //    }
        //    else
        //    {
        //        // return 1
        //    }
        //}

        //?public virtual void pfc_predeleterow()
        //{
        //    base.pfc_predeleterow();
        //    if (!ib_AllowDelete)
        //    {
        //        // 	return 0
        //    }
        //    else
        //    {
        //        // 	return 1
        //    }
        //}

        //?public virtual int of_filter_contracttypes()
        //{
        //    string sObjectList;
        //    string sObject;
        //    string ls_Coltype;
        //    string sTab = "";
        //    int ll_Ret;
        //   n_ds lds_user_Contract_Types;
        //    DataControlBuilder dwc_contract_type;
        //    bool lbDefaulManaged = false;
        //    // See if bypassed
        //    if (ib_BypassContractTypeFilter) {
        //        return SUCCESS;
        //    }
        //    // Get objects list
        //    sObjectList = this.Describe("Datawindow.Objects");
        //    // Look for ct_key dddw column
        //    while ( sObjectList.Len() > 0) {
        //        if (Pos(sObjectList, sTab) > 0) {
        //            sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //            sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //        }
        //        else {
        //            sObject = sObjectList;
        //            sObjectList = "";
        //        }
        //        if (Pos(sObject, "ct_key") > 0) {
        //            ls_Coltype = this.Describe(sObject + ".dddw.name");
        //            if (ls_Coltype == '!' || ls_Coltype == '?') {
        //                continue;
        //            }
        //            //  Only proceed the following check if the user contract types have
        //            //  not been filtered.
        //            // Retrieve cached contract types for the user
        //            lds_user_Contract_Types = gnv_app.of_Get_SecurityManager().of_Get_User().of_Get_Contract_Types();
        //            this.GetChild(sObject, dwc_contract_type);
        //            if (lds_user_Contract_Types.RowCount == gnv_app.of_GetTotalContractTypes()) {
        //                // SR#4355 Only default the COntract TYpe to 'RD' when
        //                // the column does not have an assigned value
        //                if (this.RowCount > 0) {
        //                    ll_Ret = this.GetItemNumber(1, "ct_Key");
        //                    if (IsNull(ll_Ret) || ll_Ret <= 0) {
        //                        this.SetItem(1, sObject, 1);
        //                    }
        //                    lbDefaulManaged = true;
        //                }
        //            }
        //            else {
        //                // Repopulate the datawindowchild based on the current user id
        //                dwc_contract_type.Reset();
        //                // ll_Ret = lds_user_Contract_Types.ShareData ( dwc_contract_type)
        //                lds_user_Contract_Types.RowsCopy(1, lds_user_Contract_Types.RowCount, primary!, dwc_contract_type, 1, primary!);
        //                dwc_contract_type.ResetUpdate();
        //                // SR#4355 Only default the COntract TYpe to 'RD' when
        //                // the column does not have an assigned value
        //                if (this.RowCount > 0) {
        //                    ll_Ret = this.GetItemNumber(1, "ct_Key");
        //                    if (ll_Ret > 0) {
        //                        lbDefaulManaged = true;
        //                    }
        //                }
        //                if (lbDefaulManaged == false) {
        //                    //  THe datawindow does not have a row yet and
        //                    //  hence cannot manage the default
        //                    ll_Ret = dwc_contract_type.Find( "ct_key=1" ).Length);
        //                    if (ll_Ret > 0) {
        //                        this.SetItem(1, sObject, 1);
        //                    }
        //                    else {
        //                        ll_Ret = dwc_contract_type.GetItemNumber(1, "ct_Key");
        //                        // Protect column if no access
        //                        if (ll_Ret == -(99)) {
        //                            dwc_contract_type.FilterString = "ct_key=-99";
        //                            dwc_contract_type.Filter();
        //                            // Modify (  sObject + '.Protect="0~tif ( isRowNew ( ),1,1)"')
        //                            // Modify (  sObject + ".Background.Color='79216776'")
        //                            // Modify (  sObject + ".Background.Color='13160660'")
        //                        }
        //                        this.SetItem(1, sObject, ll_Ret);
        //                    }
        //                }
        //                if (dwc_contract_type.RowCount == 1) {
        //                    Modify(sObject + ".Protect=\"0~tif ( isRowNew ( ),1,1)\"");
        //                    Modify(sObject + ".Background.Color=\'79216776\'");
        //                }
        //            }
        //        }
        //    }
        //    return 1;
        //}

        public virtual int of_set_filter_ContractTypes(bool ab_filter)
        {
            //?  ib_Filter_ContractTypes = ab_filter;
            return 1;
        }

        //?public virtual int of_filter()
        //{
        //    if (this.ib_Filter_ContractTypes)
        //    {
        //        this.of_filter_contracttypes();
        //    }
        //    this.of_filter_regions();
        //    return 1;
        //}

        //?public virtual int of_protectcolumns()
        //{
        //    // Purpose: 	Protect all columns
        //    // Author: 	NOT Rex Bustria
        //    int ll_Ctr = 0;
        //    string ls_Coltype;
        //    string ls_Describe;
        //    string sObjectList;
        //    string sObject;
        //    string sTab = "";
        //    string ls_Result;
        //     sObjectList = Describe("Datawindow.Objects");
        //     while ( sObjectList.Len() > 0) {
        //         if (Pos(sObjectList, sTab) > 0) {
        //             sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //             sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //         }
        //         else {
        //             sObject = sObjectList;
        //             sObjectList = "";
        //         }
        //         ls_Result = Describe(sObject + ".Background.Color");
        //         // 16776960
        //         // 79216776, 1073741824)
        //         // Modify (  sObject + ".Background.Color='79216776'")
        //         if (ls_Result == "16776960") {
        //             ls_Result = Modify(sObject + ".Background.Color=\'16776960~tIf ( IsRowNew ( ),16776960,79216776)\'");
        //         }
        //         else {
        //             ls_Result = Modify(sObject + ".Background.Color=\'79216776~tIf ( IsRowNew ( ),1073741824,79216776)\'");
        //         }
        //         ls_Describe = this.Describe(sObject + ".edit.name");
        //         if (ls_Describe != '!') {
        //             // This.Modify (  sObject + ".Edit.DisplayOnly=Yes")
        //         }
        //         ls_Describe = this.Describe(sObject + ".editmask.name");
        //         if (ls_Describe != '!') {
        //             this.Modify(sObject + ".EditMask.DisplayOnly=Yes");
        //         }
        //         ls_Result = this.Modify(sObject + ".Protect=\'1~tIf ( IsRowNew ( ),0,1)\'");
        //         // 	ls_Describe = This.Describe ( sObject+ ".dddw.DataColumn")
        //         // 	If ls_Describe <> '!' and ls_Describe <> '?' THEN
        //         // 		//This.Modify (  sObject + ".Tabsequence=0")
        //         // 	End if
        //     }
        //    return 0;
        //}

        //?public virtual int of_unprotectColumns()
        //{
        //    // Purpose: 	Unprotect columns. Migrated from old code
        //    // Author: 	NOT Rex Bustria
        //    string sObjectList;
        //    string sObject;
        //    string sTab = "";
        //    int ll_Ctr;
        //    sObjectList = Describe("Datawindow.Objects");
        //     this.Modify("datawindow.readonly=NO");
        //     while ( sObjectList.Len() > 0) {
        //         if (Pos(sObjectList, sTab) > 0) {
        //             sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //             sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //         }
        //         else {
        //             sObject = sObjectList;
        //             sObjectList = "";
        //         }
        //         if (Modify(sObject + ".Protect=\"0~tif ( isRowNew ( ),0,0)\"") == "") {
        //             ll_Ctr++;
        //             SetTabOrder(sObject, ll_Ctr);
        //         }
        //     }
        //    return 0;
        //}

        public virtual int of_set_regionid(int al_id)
        {
            //? il_Regionid = al_regionId;
            return SUCCESS;
        }

        public virtual int of_get_regionid()
        {
            return 0;//?il_Regionid;
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

        //?public virtual int of_bypasscontracttypefilter(bool ab_Bypass)
        //{
        //    ib_BypassContractTypeFilter = ab_Bypass;
        //    return SUCCESS;
        //}

        //?public virtual int zof_filter_regions()
        //{
        //    // Purpose: 	Filter the user's default region
        //    // Author: 	Rex Bustria
        //    // Date:	 	Feb 19, 2002
        //    string sObjectList;
        //    string sObject;
        //    string ls_Coltype;
        //    string sTab = "";
        //    int ll_Ret;
        //    int ll_DefaultRegion;
        //   DataControlBuilder dwc_contract_type;
        //    // Get the user's default region
        //    ll_DefaultRegion = gnv_app.of_Get_SecurityManager().of_Get_User().of_Get_RegionId();
        //    // Get Objects list
        //    sObjectList = this.Describe("Datawindow.Objects");
        //    while ( sObjectList.Len() > 0) {
        //        // Extract an object name
        //        if (Pos(sObjectList, sTab) > 0) {
        //            sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //            sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //        }
        //        else {
        //            sObject = sObjectList;
        //            sObjectList = "";
        //        }
        //        // Is it region id?
        //        if (Pos(sObject, "region_id") > 0) {
        //            // Determine if dddw 
        //            ls_Coltype = this.Describe(sObject + ".dddw.name");
        //            // If no, get next object name
        //            if (ls_Coltype == '!' || ls_Coltype == '?') {
        //                continue;
        //            }
        //            // Set the Region
        //            if (ll_DefaultRegion >= 0) {
        //                this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
        //                this.Modify("Region_Id.Protect=1");
        //                this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
        //                // 			This.Modify ( "Region_Id.Background.Color='13160660'")
        //            }
        //        }
        //    return SUCCESS;
        //}

        public virtual bool of_hascolumn(string as_columnname)
        {
            // Purpose: 	Filter the user's default region
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            string ls_ObjectList;
            string ls_Object;
            string ls_Coltype;
            string ls_Filter;
            string ls_TabCharacter = "";
            // Get Objects list
            /*?   ls_ObjectList = this.Describe("Datawindow.Objects");
               while ( ls_ObjectList.Len() > 0) {
                   // Extract an object name
                   if (Pos(ls_ObjectList, ls_TabCharacter) > 0) {
                       ls_Object =  TextUtil.Left(ls_ObjectList, TextUtil.Pos (ls_ObjectList, ls_TabCharacter) - 1);
                       ls_ObjectList =  TextUtil.Mid (ls_ObjectList, TextUtil.Pos (ls_ObjectList, ls_TabCharacter) + 1);
                   }
                   else {
                       ls_Object = ls_ObjectList;
                       ls_ObjectList = "";
                   }
                   // Is column found?
                   if (Lower( ls_Object).Trim() == Lower( as_columnname)).Trim() {
                       return true;
                   }
                   else {
                       continue;
                   }
               }*/
            return false;
        }

        public virtual string of_get_componentname()
        {
            return is_Componentname;
        }

        public virtual int of_set_componentname()
        {
            string as_Componentname;
            //?is_Componentname = as_Componentname;
            return 1;
        }

        #region DataUserControl function

        public virtual Control GetControlByName(string name)
        {
            return DataObject.GetControlByName(name);
        }

        public virtual string GetColumnName()
        {
            return DataObject.GetColumnName();
        }

        public virtual void ShareData(Metex.Windows.DataUserControl toControl)
        {
            DataObject.ShareData(toControl);
        }

        public virtual void ShareData(URdsDw toControl)
        {
            DataObject.ShareData(toControl.DataObject);
        }

        public virtual T GetItem<T>() where T : IEntity
        {
            return DataObject.GetItem<T>();
        }

        public virtual T GetItem<T>(int idx) where T : IEntity
        {
            return DataObject.GetItem<T>(idx);
        }

        public virtual void GetItem<T>(int idx, out T entity) where T : IEntity
        {
            DataObject.GetItem<T>(idx, out entity);
        }

        public virtual object GetValue(int idx, string propName)
        {
            return DataObject.GetValue(idx, propName);
        }

        public int Find(string propName, object key)
        {
            return DataObject.Find(propName, key);
        }

        public int Find(params System.Collections.Generic.KeyValuePair<string, object>[] findPair)
        {
            return DataObject.Find(findPair);
        }

        public virtual int ResetUpdate()
        {
            return DataObject.ResetUpdate();
        }

        public virtual int Retrieve()
        {
            return DataObject.Retrieve();
        }

        public void Sort<T>() where T : IEntity
        {
            DataObject.Sort<T>();
        }

        public override T InsertItem<T>(int idx)
        {
            if (idx == -1)
                idx = this.DataObject.RowCount;
            return DataObject.InsertItem<T>(idx);
        }

        public override void InsertItem<T>(int idx, T entity)
        {
            DataObject.InsertItem<T>(idx, entity);
        }

        public virtual bool AcceptText()
        {
            if (DataObject != null)
            {
                return DataObject.AcceptText();
            }
            else
            {
                return false;
            }
        }

        public DataUserControl GetChild(string name)
        {
            if (DataObject != null)
            {
                return DataObject.GetChild(name);
            }
            else
            {
                return null;
            }
        }

        public void DeleteItemAt(int idx)
        {
            DataObject.DeleteItemAt(idx);
        }

        private string _sql_select = "";

        public string GetSqlSelect()
        {
            return _sql_select;
        }

        public void SetSqlSelect(string as_sql)
        {
            this._sql_select = as_sql;
        }

        private Type EntityType;
        private System.Collections.Generic.List<string> column_name_list = new System.Collections.Generic.List<string>();

        protected virtual void URdsDw_DataObjectChanged(object sender, EventArgs e)
        {
            this.DataObject.Dock = DockStyle.Fill;
            string name = this.DataObject.GetType().AssemblyQualifiedName;
            this.column_name_list.Clear();
            try
            {
                string entity_typename = name.Replace("DataControls", "Entity");
                char[] test_array = entity_typename.ToCharArray();
                int pos_dot = -1;
                for (int i = 0; i < test_array.Length; i++)
                {
                    if (test_array[i] == '.')
                        pos_dot = i;
                    else if (test_array[i] == ',')
                        break;
                }
                if (char.IsLower(test_array[pos_dot + 2]))
                    entity_typename = entity_typename.Substring(0, pos_dot + 1) + entity_typename.Substring(pos_dot + 3);
                else
                    entity_typename = entity_typename.Substring(0, pos_dot + 1) + entity_typename.Substring(pos_dot + 2);
                this.EntityType = Type.GetType(entity_typename);
                NZPostOffice.Shared.LogicUnits.MapInfoIndex[] map_info_indexes = (NZPostOffice.Shared.LogicUnits.MapInfoIndex[])this.EntityType.GetCustomAttributes(typeof(NZPostOffice.Shared.LogicUnits.MapInfoIndex), false);

                if (map_info_indexes.Length > 0)
                    column_name_list.AddRange(map_info_indexes[0].GetIndex());
            }
            catch (Exception)
            {
                this.EntityType = null;
            }
        }

        public int InsertRow(int row)
        {
            if (row < 0)
                row = this.RowCount;

            //string name = this.DataObject.GetType().AssemblyQualifiedName;
            //this.column_name_list.Clear();
            //try
            //{
            //    string entity_typename = name.Replace("DataControls", "Entity");
            //    char[] test_array = entity_typename.ToCharArray();
            //    int pos_dot = -1;
            //    for (int i = 0; i < test_array.Length; i++)
            //    {
            //        if (test_array[i] == '.')
            //            pos_dot = i;
            //        else if (test_array[i] == ',')
            //            break;
            //    }
            //    if (char.IsLower(test_array[pos_dot + 2]))
            //        entity_typename = entity_typename.Substring(0, pos_dot + 1) + entity_typename.Substring(pos_dot + 3);
            //    else
            //        entity_typename = entity_typename.Substring(0, pos_dot + 1) + entity_typename.Substring(pos_dot + 2);
            //    this.EntityType = Type.GetType(entity_typename);
            //    NZPostOffice.Shared.LogicUnits.MapInfoIndex[] map_info_indexes = (NZPostOffice.Shared.LogicUnits.MapInfoIndex[])this.EntityType.GetCustomAttributes(typeof(NZPostOffice.Shared.LogicUnits.MapInfoIndex), false);
            //    if (map_info_indexes.Length > 0)
            //        column_name_list.AddRange(map_info_indexes[0].GetIndex());
            //}
            //catch (Exception)
            //{
            //    this.EntityType = null;
            //}

            if (this.EntityType != null)
            {
                return InsertRow(row, (EntityBase)Activator.CreateInstance(EntityType));
            }
            else
                throw new NotSupportedException("Can not determine the entity type of this data control");
        }

        private int InsertRow(int row, EntityBase entity)
        {
            if (row < 0)
                row = this.RowCount;
            if (this.DataObject.BindingSource.List == null)
            {
                this.DataObject.BindingSource.DataSource = Activator.CreateInstance(typeof(Metex.Core.EntityBindingList<>).MakeGenericType(EntityType));
                this.DataObject.BindingSource.Add(entity);
                row = 0;
            }
            else
            {
                this.DataObject.BindingSource.List.Insert(row, entity);
            }
            entity.MarkClean();
            return row;
        }

        public virtual int Save()
        {
            this.ProcessDialogKey(Keys.Tab); //added by jlwang:for fix the focus bug
            if (this.ModifiedCount() > 0 || this.DataObject.DeletedCount > 0)//? ||this.NewCount() > 0)
            {
                try
                {
                    this.DataObject.Save();
                    return 1;
                }
                catch
                {
                    return -1;
                }
            }
            return 1;
        }

        public int GetSelectedRow(int row)
        {
            if (GetControlByName("grid") == null || row < 0 || row > DataObject.RowCount || ((DataEntityGrid)GetControlByName("grid")).RowCount <= 0)
            {
                return -1;
            }

            for (int i = row; i < DataObject.RowCount; i++)
            {
                if (((DataEntityGrid)GetControlByName("grid")).Rows[i].Selected)
                    return i;
            }
            return -1;
        }

        public int SelectRow(int row, bool isSelected)
        {
            if (GetControlByName("grid") == null || row < 0 || row > DataObject.RowCount || ((DataEntityGrid)GetControlByName("grid")).RowCount <= 0)
            {
                return -1;
            }
            if (row == 0)
            {
                for (int i = 0; i < DataObject.RowCount; i++)
                {
                    ((DataEntityGrid)GetControlByName("grid")).Rows[i].Selected = isSelected;
                }
            }
            else
            {
                ((DataEntityGrid)GetControlByName("grid")).Rows[row - 1].Selected = isSelected;
            }
            return 1;
        }

        #endregion

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Height = 139;
            this.Width = 162;
            this.ResumeLayout();
        }

        public struct us_instance
        {
            public int first_column;

            public DateTime last_updated;

            public int security_access_level;

            public int security_group;
        }

        // Data Export
        public virtual int ImportFile(string path)
        {
            int ret_value = 0;
            int input_type = path.ToLower().EndsWith(".csv") ? 1 : (path.ToLower().EndsWith(".txt") ? 2 : 0);
            if (input_type != 0)
            {
                try
                {
                    // get field info from entity type
                    System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                    for (int i = 0; i < column_name_list.Count; i++)
                    {
                        column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    }
                    // read and parse csv file

                    //get the rowcount of file
                    int rowCount = 0;
                    using (StreamReader str = new StreamReader(path))
                    {
                        while (str.Read() > 0)
                        {
                            str.ReadLine();
                            rowCount++;
                        }
                    }
                    GC.Collect();

                    StreamReader sr = new StreamReader(path);

                    string line;
                    if (sr.Peek() == 0)
                        ret_value = -2;
                    if (sr.Peek() > 0)
                    {
                        char sep = (input_type == 1) ? ',' : '\t';
                        System.Collections.Generic.IEnumerator<string[]> iterator = this.ParseStringAsCSV(sr, sep);
                        int currRow = 0;
                        while (iterator.MoveNext())
                        {
                            currRow++;

                            string[] fields = iterator.Current;
                            // create the new object
                            EntityBase entity = (EntityBase)Activator.CreateInstance(EntityType);
                            for (int i = 0; i < fields.Length; i++)
                            {
                                object real_value;
                                if (column_fields[i].FieldType == typeof(int?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        int result = 0;
                                        int.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(decimal?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        decimal result = 0;
                                        decimal.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(double?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        double result = 0;
                                        double.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(DateTime?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        DateTime result = DateTime.MinValue;

                                        if (!DateTime.TryParse(fields[i].Trim(), out result))
                                        {
                                            MessageBox.Show("Item " + "'" + fields[i].Trim() + "'" + " does not pass validation test.", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            if (MessageBox.Show("Item validation error on IMPORT.Continue IMPORT?", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                            {
                                                return ret_value;
                                            }
                                        }
                                        real_value = result;
                                    }
                                }
                                else
                                    real_value = fields[i];
                                column_fields[i].SetValue(entity, real_value);
                            }
                            // append the new object
                            this.InsertRow(-1, entity);
                            ret_value++;

                            ((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Processing row " + ret_value + " of " + rowCount.ToString();
                            ((WOdpsMdiframe)StaticVariables.MainMDI).Refresh();
                        }
                    }
                    sr.Close();
                    ((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Ready";
                }
                catch (ArgumentException)
                {
                    ret_value = -3;
                }
                catch (FileNotFoundException)
                {
                    ret_value = -5;
                }
                catch (IOException)
                {
                    ret_value = -7;
                }
                catch (Exception)
                {
                    ret_value = -4;
                }
            }
            else
                ret_value = -8;

            return ret_value;
        }

        public virtual int ImportFile(string path, int startrow)
        {
            int ret_value = 0;
            int input_type = path.ToLower().EndsWith(".csv") ? 1 : (path.ToLower().EndsWith(".txt") ? 2 : 0);
            if (input_type != 0)
            {
                try
                {
                    // get field info from entity type
                    System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                    for (int i = 0; i < column_name_list.Count; i++)
                    {
                        column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    }
                    // read and parse csv file

                    //get the rowcount of file
                    int rowCount = 0;
                    using (StreamReader str = new StreamReader(path))
                    {
                        while (str.Read() > 0)
                        {
                            str.ReadLine();
                            rowCount++;
                        }
                    }
                    GC.Collect();

                    if (rowCount == 0)
                    {
                        ret_value = -1;
                    }
                    if (startrow >= rowCount)
                    {
                        ret_value = -1;
                    }

                    StreamReader sr = new StreamReader(path);

                    for (int i = 0; i < startrow; i++)//added by ylwang
                    {
                        sr.ReadLine();
                    }

                    string line;
                    if (sr.Peek() == 0)
                        ret_value = -2;
                    if (sr.Peek() > 0)
                    {
                        char sep = (input_type == 1) ? ',' : '\t';
                        System.Collections.Generic.IEnumerator<string[]> iterator = this.ParseStringAsCSV(sr, sep);
                        int currRow = 0;
                        while (iterator.MoveNext())
                        {
                            currRow++;

                            string[] fields = iterator.Current;
                            // create the new object
                            EntityBase entity = (EntityBase)Activator.CreateInstance(EntityType);
                            for (int i = 0; i <column_fields.Length ;i++)// fields.Length; i++)
                            {
                                object real_value;
                                if (column_fields[i].FieldType == typeof(int?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        int result = 0;
                                        int.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(decimal?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        decimal result = 0;
                                        decimal.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(double?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        double result = 0;
                                        double.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(DateTime?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        DateTime result = DateTime.MinValue;

                                        if (!DateTime.TryParse(fields[i].Trim(), out result))
                                        {
                                            MessageBox.Show("Item " + "'" + fields[i].Trim() + "'" + " does not pass validation test.", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            if (MessageBox.Show("Item validation error on IMPORT.Continue IMPORT?", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                            {
                                                return ret_value;
                                            }
                                        }
                                        real_value = result;
                                    }
                                }
                                else
                                {
                                    real_value = fields[i];
                                }

                                column_fields[i].SetValue(entity, real_value);
                            }
                            // append the new object
                            this.InsertRow(-1, entity);
                            ret_value++;

                            //?((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Processing row " + ret_value + " of " + rowCount.ToString();
                            //?((WOdpsMdiframe)StaticVariables.MainMDI).Refresh();
                        }
                    }
                    sr.Close();
                    //?this.DataObject.BindingSource.CurrencyManager.Refresh(); //jlwang 10082007

                    //?((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Ready";
                }
                catch (ArgumentException)
                {
                    ret_value = -3;
                }
                catch (FileNotFoundException)
                {
                    ret_value = -5;
                }
                catch (IOException)
                {
                    ret_value = -7;
                }
                catch (Exception e)
                {
                    string str = e.Message.ToString();
                    ret_value = -4;
                }
            }
            else
                ret_value = -8;

            return ret_value;
        }

        private System.Collections.Generic.IEnumerator<string[]> ParseStringAsCSV(StreamReader sr, char separator)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            bool dquote_state = false;
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            bool skip_read = false;
            char current = ' ';
            while (sr.Peek() > 0)
            {
                if (skip_read)
                    skip_read = false;
                else
                    current = (char)sr.Read();
                if (current == '"')
                {
                    if (!dquote_state)
                        dquote_state = true;
                    else
                    {
                        current = (char)sr.Read();
                        if (current == '"')
                            builder.Append('"');
                        else
                        {
                            skip_read = true;
                            dquote_state = false;
                        }
                    }
                }
                else if (current == separator)
                {
                    if (!dquote_state)
                    {
                        result.Add(builder.ToString());
                        builder.Remove(0, builder.Length);
                    }
                    else
                        builder.Append(separator);
                }
                else if (current == '\r' || current == '\n')
                {
                    if (builder.Length > 0)
                    {
                        result.Add(builder.ToString());
                        builder.Remove(0, builder.Length);
                    }
                    if (result.Count > 0)
                    {
                        yield return result.ToArray();
                        result.Clear();
                    }
                }
                else
                {
                    builder.Append(current);
                }
            }
            if (builder.Length > 0)
                result.Add(builder.ToString());
            if (result.Count > 0)
                yield return result.ToArray();
        }

        public int SaveAs(string filename, string saveastype)
        {
            return this.SaveAs(filename, saveastype, true);
            //try
            //{
            //    if (filename.Length > 0)
            //    {
            //    }
            //    else
            //    {
            //        SaveFileDialog savedlg = new SaveFileDialog();
            //        savedlg.Title = "Export to file...";
            //        savedlg.Filter = "Excel files  ( *.xls)| *.xls |CSV files  ( *.csv)| *.csv";
            //        if (savedlg.ShowDialog() == DialogResult.OK)
            //        {
            //            filename = savedlg.FileName;
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //    if (filename.Substring(filename.Length - 3) == "xls")
            //    {
            //        //Microsoft.Office.Interop.Excel.Application m_Excel = new Microsoft.Office.Interop.Excel.Application();
            //        //m_Excel.SheetsInNewWorkbook = 1;
            //        //Microsoft.Office.Interop.Excel._Workbook m_Book = (Microsoft.Office.Interop.Excel._Workbook)(m_Excel.Workbooks.Add(Missing.Value));
            //        //Microsoft.Office.Interop.Excel._Worksheet m_Sheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_Book.Worksheets.get_Item(1));
            //        //m_Sheet.Name = EntityType.Name;
            //        //int j = 0;
            //        //foreach (PropertyInfo p in this.EntityType.GetProperties())
            //        //{
            //        //    j++;
            //        //    if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
            //        //    {
            //        //    }
            //        //    else
            //        //    {
            //        //        m_Sheet.Cells[1, j] = reversemigrateName(p.Name);
            //        //    }
            //        //}

            //        //for (int i = 0; i < this.RowCount; i++)
            //        //{
            //        //    j = 0;
            //        //    EntityBase sResult = this.GetItem<EntityBase>(i);
            //        //    foreach (PropertyInfo p in sResult.GetType().GetProperties())
            //        //    {
            //        //        if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
            //        //        {
            //        //        }
            //        //        else
            //        //        {
            //        //            j++;
            //        //            if (p.PropertyType == typeof(string))
            //        //            {
            //        //                m_Sheet.Cells[2 + i, j] = "'" + p.GetValue(sResult, null);
            //        //            }
            //        //            else
            //        //            {
            //        //                m_Sheet.Cells[2 + i, j] = p.GetValue(sResult, null);
            //        //            }
            //        //        }
            //        //    }
            //        //    m_Sheet.Cells.WrapText = false;
            //        //    m_Book.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //        //    m_Book.Close(false, Missing.Value, Missing.Value);
            //        //    m_Excel.Quit();
            //        //    m_Book = null;
            //        //    m_Sheet = null;
            //        //    m_Excel = null;
            //        //}
            //    }
            //    else
            //    {
            //        StreamWriter sw = null;
            //        try
            //        {
            //            // set separator charatcer
            //            char sep;
            //            if (saveastype.ToLower() == "text")
            //                sep = '\t';
            //            else if (saveastype.ToLower() == "csv")
            //                sep = ',';
            //            else
            //                throw new Exception("Unsupported save as type.");

            //            // get field info from entity type
            //            System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
            //            for (int i = 0; i < column_name_list.Count; i++)
            //            {
            //                column_fields[i] = EntityType.GetField("_" + column_name_list[i],
            //                    System.Reflection.BindingFlags.GetField |
            //                    System.Reflection.BindingFlags.SetField |
            //                    System.Reflection.BindingFlags.Instance |
            //                    System.Reflection.BindingFlags.NonPublic);
            //            }

            //            sw = new StreamWriter(filename);
            //            for (int i = 0; i < column_name_list.Count; i++)
            //            {
            //                sw.Write(column_name_list[i] + sep);
            //            }
            //            sw.Write("\r\n");
            //            for (int r = 0; r < DataObject.RowCount; r++)
            //            {
            //                for (int i = 0; i < column_fields.Length; i++)
            //                {
            //                    sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
            //                    if (i != column_fields.Length - 1)
            //                        sw.Write(sep);
            //                }
            //                if (r != DataObject.RowCount - 1)
            //                    sw.Write("\r\n");
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            GC.Collect();
            //            return -1;
            //        }
            //        finally
            //        {
            //            if (sw != null)
            //            {
            //                sw.Close();
            //            }
            //        }
            //        GC.Collect();
            //        return DataObject.RowCount;
            //    }
            //    return 1;
            //}
            //catch
            //{
            //    return -1;
            //}
            //GC.Collect();
            //return 0;
            ////if (filename == null || filename == "")
            ////{
            ////    DialogResult i_return;
            ////    SaveFileDialog file_dia = new SaveFileDialog();
            ////    file_dia.Title = "Save As";
            ////    file_dia.DefaultExt = "txt";
            ////    file_dia.Filter = "Text|*.txt|CSV|*.csv";
            ////    i_return = file_dia.ShowDialog();
            ////    if (i_return == DialogResult.Cancel)
            ////        return 0;
            ////    filename = file_dia.FileName;
            ////}
            ////StreamWriter sw = null;
            ////try
            ////{
            ////    // set separator charatcer
            ////    char sep;
            ////    if (saveastype.ToLower() == "text")
            ////        sep = '\t';
            ////    else if (saveastype.ToLower() == "csv")
            ////        sep = ',';
            ////    else
            ////        throw new Exception("Unsupported save as type.");
            ////    // get field info from entity type
            ////    System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
            ////    for (int i = 0; i < column_name_list.Count; i++)
            ////    {
            ////        column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            ////    }

            ////    sw = new StreamWriter(filename);
            ////    for (int r = 0; r < DataObject.RowCount; r++)
            ////    {

            ////        for (int i = 0; i < column_fields.Length; i++)
            ////        {
            ////            sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
            ////            if (i != column_fields.Length - 1)
            ////                sw.Write(sep);
            ////        }
            ////        if (r != DataObject.RowCount - 1)
            ////            sw.Write("\r\n");
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    return -1;
            ////}
            ////finally
            ////{
            ////    if (sw != null)
            ////    {
            ////        sw.Close();
            ////    }
            ////}
            ////GC.Collect();
            ////return DataObject.RowCount;
        }

        public int SaveAs(string filename, string saveastype, bool headline)
        {
            try
            {
                if (filename.Length > 0)
                {
                }
                else
                {
                    SaveFileDialog savedlg = new SaveFileDialog();
                    savedlg.Title = "Export to file...";
                    savedlg.Filter = "Excel files  ( *.xls)| *.xls |CSV files  ( *.csv)| *.csv";
                    if (savedlg.ShowDialog() == DialogResult.OK)
                    {
                        filename = savedlg.FileName;
                    }
                    else
                    {
                        return -1;
                    }
                }
                if (filename.Substring(filename.Length - 3) == "xls")
                {
                    //Microsoft.Office.Interop.Excel.Application m_Excel = new Microsoft.Office.Interop.Excel.Application();
                    //m_Excel.SheetsInNewWorkbook = 1;
                    //Microsoft.Office.Interop.Excel._Workbook m_Book = (Microsoft.Office.Interop.Excel._Workbook)(m_Excel.Workbooks.Add(Missing.Value));
                    //Microsoft.Office.Interop.Excel._Worksheet m_Sheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_Book.Worksheets.get_Item(1));
                    //m_Sheet.Name = EntityType.Name;
                    //int j = 0;
                    //foreach (PropertyInfo p in this.EntityType.GetProperties())
                    //{
                    //    j++;
                    //    if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
                    //    {
                    //    }
                    //    else
                    //    {
                    //        m_Sheet.Cells[1, j] = reversemigrateName(p.Name);
                    //    }
                    //}

                    //for (int i = 0; i < this.RowCount; i++)
                    //{
                    //    j = 0;
                    //    EntityBase sResult = this.GetItem<EntityBase>(i);
                    //    foreach (PropertyInfo p in sResult.GetType().GetProperties())
                    //    {
                    //        if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
                    //        {
                    //        }
                    //        else
                    //        {
                    //            j++;
                    //            if (p.PropertyType == typeof(string))
                    //            {
                    //                m_Sheet.Cells[2 + i, j] = "'" + p.GetValue(sResult, null);
                    //            }
                    //            else
                    //            {
                    //                m_Sheet.Cells[2 + i, j] = p.GetValue(sResult, null);
                    //            }
                    //        }
                    //    }
                    //    m_Sheet.Cells.WrapText = false;
                    //    m_Book.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    //    m_Book.Close(false, Missing.Value, Missing.Value);
                    //    m_Excel.Quit();
                    //    m_Book = null;
                    //    m_Sheet = null;
                    //    m_Excel = null;
                    //}
                }
                else
                {
                    StreamWriter sw = null;
                    try
                    {
                        // set separator charatcer
                        char sep;
                        if (saveastype.ToLower() == "text")
                            sep = '\t';
                        else if (saveastype.ToLower() == "csv")
                            sep = ',';
                        else
                            throw new Exception("Unsupported save as type.");

                        // get field info from entity type
                        System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                        for (int i = 0; i < column_name_list.Count; i++)
                        {
                            column_fields[i] = EntityType.GetField("_" + column_name_list[i],
                                System.Reflection.BindingFlags.GetField |
                                System.Reflection.BindingFlags.SetField |
                                System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic);
                        }


                        sw = new StreamWriter(filename);
                        if (headline)
                        {
                            for (int i = 0; i < column_name_list.Count; i++)
                            {
                                sw.Write(column_name_list[i] + sep);
                            }
                            sw.Write("\r\n");
                        }
                        for (int r = 0; r < DataObject.RowCount; r++)
                        {
                            for (int i = 0; i < column_fields.Length; i++)
                            {
                                sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
                                if (i != column_fields.Length - 1)
                                    sw.Write(sep);
                            }
                            if (r != DataObject.RowCount - 1)
                                sw.Write("\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        GC.Collect();
                        return -1;
                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                    GC.Collect();
                    return DataObject.RowCount;
                }
                return 1;
            }
            catch
            {
                return -1;
            }
            GC.Collect();
            return 0;
            //if (filename == null || filename == "")
            //{
            //    DialogResult i_return;
            //    SaveFileDialog file_dia = new SaveFileDialog();
            //    file_dia.Title = "Save As";
            //    file_dia.DefaultExt = "txt";
            //    file_dia.Filter = "Text|*.txt|CSV|*.csv";
            //    i_return = file_dia.ShowDialog();
            //    if (i_return == DialogResult.Cancel)
            //        return 0;
            //    filename = file_dia.FileName;
            //}
            //StreamWriter sw = null;
            //try
            //{
            //    // set separator charatcer
            //    char sep;
            //    if (saveastype.ToLower() == "text")
            //        sep = '\t';
            //    else if (saveastype.ToLower() == "csv")
            //        sep = ',';
            //    else
            //        throw new Exception("Unsupported save as type.");
            //    // get field info from entity type
            //    System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
            //    for (int i = 0; i < column_name_list.Count; i++)
            //    {
            //        column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //    }

            //    sw = new StreamWriter(filename);
            //    for (int r = 0; r < DataObject.RowCount; r++)
            //    {

            //        for (int i = 0; i < column_fields.Length; i++)
            //        {
            //            sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
            //            if (i != column_fields.Length - 1)
            //                sw.Write(sep);
            //        }
            //        if (r != DataObject.RowCount - 1)
            //            sw.Write("\r\n");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return -1;
            //}
            //finally
            //{
            //    if (sw != null)
            //    {
            //        sw.Close();
            //    }
            //}
            //GC.Collect();
            //return DataObject.RowCount;
        }

        private string ValidateExportValue(object value)
        {
            // TJB  RPI_005  June 2010
            // Changed to allow " " strings to pass untrimmed

            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("[,\"\\t\\r\\n]");
            if (value == null)
            {
                return "";
            }
            else if (value is DateTime)
            {
                return ((DateTime)value).ToShortDateString();
            }
            else if (value is decimal)  //format 2 decimal
            {
                return string.Format("{0:F2}", value);
            }
            else if (!(value is string))
            {
                return value.ToString();
            }
            else
            {
                if (rx.Match((string)value).Success)
                    return '"' + ((string)value).Replace("\"", "\"\"") + '"';
                else
                    // TJB RPI_005 June-2010: Added length condition so " " would be untrimmed
                    if (((string)value).Length > 1)
                        return ((string)value).Trim();
                    else
                        return ((string)value);
            }
        }
    }
}
