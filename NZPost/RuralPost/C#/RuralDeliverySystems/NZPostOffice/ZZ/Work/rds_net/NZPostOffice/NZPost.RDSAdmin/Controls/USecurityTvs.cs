namespace NZPostOffice.RDSAdmin.Controls 
{
    using System;
    using System.Data;
    using System.Windows.Forms;

    using Metex.Windows;

    using NZPostOffice.Shared;
    using NZPostOffice.Shared.VisualComponents;
    using NZPostOffice.RDSAdmin.DataControls.Security;
    using NZPostOffice.RDSAdmin.Entity.Security;  
    
    public class USecurityTvs : UTvs
    {
        
        //private MSecurityTvs im_SecTvs;
        
        //public int il_from_handle  ;
        
        //public int il_to_handle  ;
        
        //public int il_DraggedFrom;
        public new bool DesignMode
        {
            get
            {
                return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            }
        }

        public USecurityTvs()
        {
            if (DesignMode)
            {
                return;
            }
            //!    this.of_setbase(true);
            of_setup_level_source();
            // m_security_tvs m_SecTvs
            // We create our own rmb menu inherited from m_tvs
            // m_SecTvs = create m_security_tvs 
            // im_view = m_SecTvs
            //super::event pfc_prermbmenu ( im_view)
        }
        
        //public virtual void ue_additem() {
        //    MessageBox("", "add fuckoff");
        //}

        public override int Retrieve(TreeNode al_parent, DataUserControlContainer ads_data)
        {
            /*
            base.pfc_retrieve();
            // Source args
            Cl_AnyArray la_args = new Cl_AnyArray(20);
            int li_level;
            int li_Ret;
            TreeViewItem ltvi_item;
            if (IsValid(this.inv_levelsource))
            {
                li_level = of_getnextlevel(al_parent);
                // PowerBuilder 'Choose Case' statement converted into 'if' statement
                Long TestExpr = li_level;
                if (TestExpr == 1)
                {
                    // level1 has no args
                }
                else if (TestExpr == 2)
                {
                    // level2 requires one arg
                    this.inv_levelsource.of_getargs(al_parent, li_level, la_args);
                }
                else if (TestExpr == 3)
                {
                    // level3 requires two args
                    this.inv_levelsource.of_getargs(al_parent, li_level, la_args);
                }
            }
            // Retrieve
            li_Ret = this.of_retrieve(al_parent, la_args, ads_data);
            // If you don't do the next two, you don't see the icons
            // if there is only one
            this.setFocus();
             * */
            if (al_parent == null)
            {
                ads_data.DataObject = new DwGroupsAndUsersLevel1();
                ads_data.Retrieve(new object[] { });
                if (ads_data.RowCount > 0)
                {
                    ads_data.DataObject.SortString = "id ASC";
                }
            }
            else if (al_parent.Level == 0)
            {
                GroupsAndUsersLevel1 be = al_parent.Tag as GroupsAndUsersLevel1; 
                
                ads_data.DataObject = new DwGroupsAndUsersLevel2();
                ads_data.Retrieve(new object[] { be.Id });
            }
            else if (al_parent.Level == 1)
            {
                GroupsAndUsersLevel1 be2 = al_parent.Parent.Tag as GroupsAndUsersLevel1;
                GroupsAndUsersLevel2 be1 = al_parent.Tag as GroupsAndUsersLevel2;

                ads_data.DataObject = new DwGroupsAndUsersLevel3();
                ads_data.Retrieve(new object[] { be1.Id, be2.Id });
            }
            return 1;
        }
        
        //public virtual void u_security_tvs_selectionchanged(object sender, EventArgs e) {
        //    base.selectionchanged();
        //    TreeViewItem ltvi_Temp;
        //    // Store the old handle and new handle
        //    il_from_handle = oldhandle;
        //    il_to_handle = newhandle;
        //    // get reference to tv item
        //    this.GetItem(il_to_handle, ltvi_Temp);
        //    // Delegate processing
        //    this.of_navigated();
        //}
        
       
        
        //public virtual void begindrag() {
        //    base.begindrag();
        //    il_DraggedFrom = Handle;
        //}
        
        //public virtual int of_get_id(int al_handle) {
        //    int ll_Id;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0) {
        //        // What level?
        //        ll_Level = this.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (this.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1) {
        //            // Get the id
        //            ll_Id = Long(lds_datasource.Object.id[ll_datarow]);
        //        }
        //    }
        //    return ll_Id;
        //}
        
        //public virtual int of_display_level_source_error(int al_level_source_error) {
        //    int li_Ret;
        //    if (IsValid(gnv_app.inv_Error)) {
        //        // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //        integer TestExpr = al_level_source_error;
        //        if (TestExpr == -(1)) {
        //            li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Argument validation error");
        //        }
        //        else if (TestExpr == -(2)) {
        //            li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Dwobject had no key columns assigned");
        //        }
        //        else if (TestExpr == -(3)) {
        //            li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "A previous level was marked as recursive");
        //        }
        //        else if (TestExpr == -(4)) {
        //            li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Column level datatype was not in the data source");
        //        }
        //        else if (TestExpr == -(5)) {
        //            li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "SetTransObject failed for the data source");
        //        }
        //        else if (TestExpr == -(7)) {
        //            li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Cache registration error");
        //        }
        //    }
        //    return 1;
        //}
        
        //public virtual string of_get_label(int al_handle) {
        //    string ls_Label;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0) {
        //        // What level?
        //        ll_Level = this.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (this.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1) {
        //            // Get the label
        //            ls_Label = String(lds_datasource.Object.label[ll_datarow]);
        //        }
        //    }
        //    return ls_Label;
        //}
        
        //public virtual int of_get_parent_id1(int al_handle) {
        //    int ll_Id;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0) {
        //        // What level?
        //        ll_Level = this.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (this.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1) {
        //            // Get the id
        //            ll_Id = Long(lds_datasource.Object.parent_id1[ll_datarow]);
        //        }
        //    }
        //    return ll_Id;
        //}
        
        //public virtual int of_get_parent_id2(int al_handle) {
        //    int ll_Id;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0) {
        //        // What level?
        //        ll_Level = this.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (this.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1) {
        //            // Get the id only if we are at level 3
        //            if (ll_Level == 3) {
        //                ll_Id = Long(lds_datasource.Object.parent_id2[ll_datarow]);
        //            }
        //        }
        //    }
        //    return ll_Id;
        //}

        public virtual int of_refresh()
        {
            int ll_Row;
            int ll_Handle;
            string ls_Node_Type;
            string ls_Node_Id;
            int li_ret;
            // Clear the tree then load first level
            /*!
            this.inv_levelsource.of_resettree();
            this.of_reset();
             * */
            this.Nodes.Clear();
            // Populate level 1 
            // 	- will trigger selectionchanged. ib_Refreshing will stop code from selectionchanged
            Populate(null,true);
            return 1;
        }

        public virtual int of_setup_level_source()
        {
            int li_Ret;
            // Set up base services
            /*!
            this.of_setbase(true);
            // Enable level source service
            this.of_setlevelsource(true);
            // Set up level source, catching any errors
            li_Ret = this.inv_levelsource.of_register(1, "label", "", "dw_groups_and_users_level1", sqlca, "");
            of_display_level_source_error(li_Ret);
            li_Ret = this.inv_levelsource.of_register(2, "label", "parent.1.id", "dw_groups_and_users_level2", sqlca, "");
            of_display_level_source_error(li_Ret);
            li_Ret = this.inv_levelsource.of_register(3, "label", "parent.1.id, parent.1.parent_id1", "dw_groups_and_users_level3", sqlca, "");
            of_display_level_source_error(li_Ret);
            // set default pics from TV picture array
            li_Ret = this.inv_levelsource.of_setpicturecolumn(1, "pictindex");
            li_Ret = this.inv_levelsource.of_setpicturecolumn(2, "pictindex");
            li_Ret = this.inv_levelsource.of_setpicturecolumn(3, "pictindex");
            // specify column that references selected pictures when selected
            li_Ret = this.inv_levelsource.of_setselectedpicturecolumn(1, "pictindex");
            li_Ret = this.inv_levelsource.of_setselectedpicturecolumn(2, "pictindex");
            li_Ret = this.inv_levelsource.of_setselectedpicturecolumn(3, "pictindex");
             * */
            of_refresh();
            return 1;
        }
        
        //public virtual int of_navigated() {
        //    int ll_Level;
        //    int ll_Parent_Id1;
        //    int ll_Parent_Id2;
        //    int ll_ID;
        //    string ls_label;
        //    // We need to get some info off the treeview
        //    // because the user has navigated it ie clicked, 
        //    // up/down arrow pressed, double-clicked
        //    // level
        //    ll_Level = this.inv_levelsource.of_getlevel(il_to_handle);
        //    // Get the label
        //    ls_label = this.of_get_label(il_to_handle);
        //    // Get the ID
        //    ll_ID = this.of_get_id(il_to_handle);
        //    // get parent id1
        //    ll_Parent_Id1 = this.of_get_parent_id1(il_to_handle);
        //    // get parent id2
        //    ll_Parent_Id2 = this.of_get_parent_id2(il_to_handle);
        //    // Delegate navigation to ue_navigated
        //    this.ue_Navigated(ll_Level, ll_ID, ls_label, ll_Parent_Id1, ll_Parent_Id2);
        //    return 0;
        //}
        
        //public virtual int of_get_level() {
        //    // Get level
        //    int tjb_long;
        //    tjb_long = il_to_handle;
        //    return this.inv_levelsource.of_getlevel(il_to_handle);
        //}
        
        //public virtual int of_get_account_id(int al_handle) {
        //    int ll_Id;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0) {
        //        // What level?
        //        ll_Level = this.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (this.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1) {
        //            // Get the id
        //            ll_Id = Long(lds_datasource.Object.account[ll_datarow]);
        //        }
        //    }
        //    return ll_Id;
        //}
    }
}
