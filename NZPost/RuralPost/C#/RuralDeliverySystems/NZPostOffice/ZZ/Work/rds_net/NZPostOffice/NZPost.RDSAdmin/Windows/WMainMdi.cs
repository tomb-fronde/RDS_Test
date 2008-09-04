namespace NZPostOffice.RDSAdmin
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections;
    using System.Collections.Generic;
    using Metex.Windows;
    using NZPostOffice.Shared;
    using NZPostOffice.Shared.VisualComponents;
    using NZPostOffice.RDSAdmin.DataService;
    using NZPostOffice.RDSAdmin.Menus;
    using NZPostOffice.RDSAdmin.DataControls.Security;
    using NZPostOffice.RDSAdmin.Entity.Security;

    public class WMainMdi : FormBase
    {
        private int il_drop_success = 0;

        private int il_group_id = 0;

        private int il_region_id = 0;
        int id = 0;

        private const string is_LABEL_GROUPS = "Groups";

        private const string is_LABEL_USERS = "Users";

        // TJB 18-Oct-2004 SR4642 

        private string is_oldLabel = String.Empty;

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        /// Methods of the PowerBuilder menu
        private MMainMenu m_main_menu;

        private DwUserRegion dw_user_region;

        private DataUserControlContainer dw_detail;

        private USt st_1;

        private Controls.USecurityTvs tv_1;

        public DataUserControlContainer dw_header;

        private DwContractTypes dw_contract_type;

        private GroupBox gb_details;

        private DUiIdDetails dw_user_details;

        private DwGroupDetails dw_1;

        private ImageList MainMdiImageList;

        private MSecurityTvs m_SecTvs;

        private MRdsDw mRdsDw;

        public WMainMdi()
        {
            this.InitializeComponent();

            this.dw_detail.DataObject = new DwGroupDetails();

            dw_detail.DoubleClick += new EventHandler(dw_detail_DoubleClick);
            dw_detail.DataObjectChanged += new EventHandler(dw_detail_DataObjectChanged);
            dw_detail_DataObjectChanged(this, new EventArgs());
            //!  dw_detail.DataObject.RetrieveEnd += new RetrieveEventHandler(dw_detail_retrieveend);
            m_main_menu = new MMainMenu(this);
            m_main_menu.BuildMenu(this);
            m_SecTvs = new MSecurityTvs(this);
            m_SecTvs.Opening += new System.ComponentModel.CancelEventHandler(m_SecTvs_Opening);
            this.tv_1.NodeMouseClick += new TreeNodeMouseClickEventHandler(tv_1_NodeMouseClick);
            this.tv_1.ContextMenuStrip = m_SecTvs;
        }

        #region DragDrop
        private System.Drawing.Rectangle dragBoxFromMouseDown;
        private TreeNode dragedNode;

        private void tv_1_DragOver(object sender, DragEventArgs e)
        {
            //TreeNode node = tv_1.GetNodeAt(e.X - tv_1.Location.X, e.Y - tv_1.Location.Y);
            TreeView tv = sender as TreeView;
            Point pt = tv.PointToClient(new Point(e.X, e.Y));
            TreeNode node = tv_1.GetNodeAt(pt.X , pt.Y);
            if (node != null && tv_1.SelectedNode != node
                && node.Level == 1 && node.Parent.Text == "Groups")
            {
                tv_1.SelectedNode.Collapse();
                tv_1.SelectedNode = node;
                node.Expand();
            }

            // ! added by wjtang for synchronization treeview scroll bar
            int delta = tv.Height - pt.Y;
            if ((delta < tv.Height / 2) && (delta > 0))
            {
                TreeNode tn = tv.GetNodeAt(pt.X, pt.Y);
                if (tn.NextVisibleNode != null)
                    tn.NextVisibleNode.EnsureVisible();

            }

            if ((delta > tv.Height / 2) && (delta < tv.Height))
            {
                TreeNode tn = tv.GetNodeAt(pt.X, pt.Y);
                if (tn.PrevVisibleNode != null)
                    tn.PrevVisibleNode.EnsureVisible();
            }


        }
        private void tv_1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = tv_1.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                GroupsAndUsersLevel2 BE = node.Tag as GroupsAndUsersLevel2;
                if (node.Level == 1
                    && BE != null
                    && node.Parent.Text == "Users")
                {
                    Size dragSize = SystemInformation.DragSize;
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                 e.Y - (dragSize.Height / 2)), dragSize);
                    dragedNode = node;
                }
                else
                {
                    dragBoxFromMouseDown = Rectangle.Empty;
                }
            }
        }
        private void tv_1_MouseUp(object sender, MouseEventArgs e)
        {
            dragBoxFromMouseDown = Rectangle.Empty;
        }
        private void tv_1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y)
                    && dragedNode != null)
                {
                    ((Control)sender).DoDragDrop(dragedNode, DragDropEffects.All | DragDropEffects.Link);
                }
            }
        }
        private void tv_1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void tv_1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode parentNode = tv_1.GetNodeAt(tv_1.PointToClient(new Point(e.X, e.Y)));
                TreeNode userNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
                GroupsAndUsersLevel2 groupBE = parentNode.Tag as GroupsAndUsersLevel2;
                GroupsAndUsersLevel2 userBE = userNode.Tag as GroupsAndUsersLevel2;
                if (userNode == null || userBE == null || parentNode.Level != 1 || groupBE == null)
                {
                    return;
                }
                foreach (TreeNode node in parentNode.Nodes)
                {
                    GroupsAndUsersLevel3 BE = node.Tag as GroupsAndUsersLevel3;
                    if (BE != null && BE.Id == userBE.Id)
                    {
                        MessageBox.Show(BE.Label + " is already a member of this group.", "User Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                // insert into rds_user_id_group
                /*  Insert into rds_user_id_group ( ug_id, ui_id) values ( :ll_dropped_group_id, :ll_dragged_logon_id)*/
                MainMdiService.InsertUserGroup(groupBE.Id.GetValueOrDefault(), userBE.Id.GetValueOrDefault());
                // Refresh
                RefreshNode(parentNode);
                parentNode.Expand();
                RefreshNode(userNode);
                this.tv_1.SelectedNode = parentNode;
            }
        }
        #endregion

        private void dw_detail_DataObjectChanged(object sender, EventArgs e)
        {
            if (dw_detail.DataObject is DwGroupDetails || dw_detail.DataObject is DProcurement)
            {
                ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")).CellMouseClick += new DataGridViewCellMouseEventHandler(Grid_CellMouseClick);
                mRdsDw = new MRdsDw(this);
                mRdsDw.Opening += new System.ComponentModel.CancelEventHandler(mRdsDw_Opening);
                mRdsDw.m_insert.Click += new EventHandler(m_insert_Click);
                mRdsDw.m_delete.Click += new EventHandler(m_delete_Click);
                ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")).ContextMenuStrip = mRdsDw;
            }
            else if (((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")) != null)
            {
                ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")).CellMouseClick += new DataGridViewCellMouseEventHandler(Grid_CellMouseClick);
                mRdsDw = new MRdsDw(this);
                mRdsDw.Opening += new System.ComponentModel.CancelEventHandler(mRdsDw_Opening);
                mRdsDw.m_insert.Click += new EventHandler(m_insert_Click);
                ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")).ContextMenuStrip = mRdsDw;
            }
            // attach events
            dw_detail.DataObject.ItemChanged += new EventHandler(dw_detail_ItemChanged);
            dw_detail.DataObject.BindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(dw_detail_ListChanged);
        }

        private bool inDw_detail_ListChanged = false;
        private void dw_detail_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs args)
        {
            if (inDw_detail_ListChanged)
                return;
            inDw_detail_ListChanged = true;
            if (dw_detail.DataObject is DwGroupDetails)
            {
                DwGroupDetails dataobject = (DwGroupDetails)dw_detail.DataObject;
                if (args.ListChangedType == System.ComponentModel.ListChangedType.ItemChanged ||
                    args.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
                { 
                    //? added by jlwang  
                    DGVCheckBoxCell checkCell = (DGVCheckBoxCell)dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_create"];
                    if (dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowcreate"].Value != null)
                    {
                        string createValue = dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowcreate"].Value.ToString();
                        checkCell.Enabled = createValue == "Y" ? true : false;
                    }
                    else
                    {
                        checkCell.Enabled = false;
                    }

                    DGVCheckBoxCell checkCell2 = (DGVCheckBoxCell)dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_read"];
                    if (dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowread"].Value != null)
                    {

                        string readValue = dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowread"].Value.ToString();
                        checkCell2.Enabled = readValue == "Y" ? true : false;
                    }
                    else
                    {
                        checkCell2.Enabled = false;
                    }

                    DGVCheckBoxCell checkCell3 = (DGVCheckBoxCell)dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_modify"];
                    if (dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowmodify"].Value != null)
                    {
                        string modifyValue = dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowmodify"].Value.ToString();
                        checkCell3.Enabled = modifyValue == "Y" ? true : false;
                    }
                    else
                    {
                        checkCell3.Enabled = false;
                    }

                    DGVCheckBoxCell checkCell4 = (DGVCheckBoxCell)dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_delete"];
                    if (dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowdelete"].Value != null)
                    {
                        string deleteValue = dataobject.Grid.Rows[args.NewIndex].Cells["rds_component_rc_allowdelete"].Value.ToString();
                        checkCell4.Enabled = deleteValue == "Y" ? true : false;
                    }
                    else
                    {
                        checkCell4.Enabled = false;
                    }
                    dataobject.Grid.Invalidate();


                    dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_create"].ReadOnly =
                        dataobject.GetItem<GroupDetails>(args.NewIndex).RdsComponentRcAllowcreate != "Y";
                    dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_read"].ReadOnly =
                        dataobject.GetItem<GroupDetails>(args.NewIndex).RdsComponentRcAllowread != "Y";
                    dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_modify"].ReadOnly =
                        dataobject.GetItem<GroupDetails>(args.NewIndex).RdsComponentRcAllowmodify != "Y";
                    dataobject.Grid.Rows[args.NewIndex].Cells["rds_user_rights_rur_delete"].ReadOnly =
                        dataobject.GetItem<GroupDetails>(args.NewIndex).RdsComponentRcAllowdelete != "Y";
                }
            }
            inDw_detail_ListChanged = false;
        }

        private void m_delete_Click(object sender, EventArgs e)
        {
            //((DwGroupDetails)dw_detail.DataObject).DeleteItem<GroupDetails>((GroupDetails)dw_detail.DataObject.Current);
            try
            {
                dw_detail.DataObject.DeleteItemAt(dw_detail.DataObject.GetRow());
            }
            catch (Exception ex)
            { }
        }

        private void m_insert_Click(object sender, EventArgs e)
        {
            int row = dw_detail.GetRow();
            if (row < 0)
            {
                row = 0;
            }
            if (dw_detail.DataObject is DwGroupDetails)
            {
                ((DwGroupDetails)dw_detail.DataObject).InsertItem<GroupDetails>(row, GroupDetails.NewGroupDetails(null));
                ((DwGroupDetails)dw_detail.DataObject).Grid.ClearSelection();
                ((DwGroupDetails)dw_detail.DataObject).Grid.Rows[dw_detail.GetRow()].Selected = true;
            }
            else if (dw_detail.DataObject is DAllowanceType)
            {
                ((DAllowanceType)dw_detail.DataObject).InsertItem<AllowanceType>(row, AllowanceType.NewAllowanceType(null));
                ((DAllowanceType)dw_detail.DataObject).Grid.ClearSelection();
                ((DAllowanceType)dw_detail.DataObject).Grid.Rows[dw_detail.GetRow()].Selected = true;
            }
            else if (dw_detail.DataObject is DArticalType)
            {
                ((DArticalType)dw_detail.DataObject).InsertItem<ArticalType>(row, ArticalType.NewArticalType(null));
                ((DArticalType)dw_detail.DataObject).Grid.ClearSelection();
                ((DArticalType)dw_detail.DataObject).Grid.Rows[dw_detail.GetRow()].Selected = true;
            }
            else if (dw_detail.DataObject is DContractType)
            {
                ((DContractType)dw_detail.DataObject).InsertItem<ContractTypeBE>(row, ContractTypeBE.NewContractType(null));
                ((DContractType)dw_detail.DataObject).Grid.ClearSelection();
                ((DContractType)dw_detail.DataObject).Grid.Rows[dw_detail.GetRow()].Selected = true;
            }
            else if (dw_detail.DataObject is DFixedAssetType)
            {
                ((DFixedAssetType)dw_detail.DataObject).InsertItem<FixedAssetType>(row, FixedAssetType.NewFixedAssetType(null));
            }
            else if (dw_detail.DataObject is DFuelType)
            {
                ((DFuelType)dw_detail.DataObject).InsertItem<FuelType>(row, FuelType.NewFuelType(null));
            }
            else if (dw_detail.DataObject is DOutletType)
            {
                ((DOutletType)dw_detail.DataObject).InsertItem<OutletType>(row, OutletType.NewOutletType(null));
            }
            else if (dw_detail.DataObject is DPieceRateSupplier)
            {
                ((DPieceRateSupplier)dw_detail.DataObject).InsertItem<PieceRateSupplier>(row, PieceRateSupplier.NewPieceRateSupplier(null));
            }
            else if (dw_detail.DataObject is DPieceRateType)
            {
                ((DPieceRateType)dw_detail.DataObject).InsertItem<PieceRateType>(row, PieceRateType.NewPieceRateType(null));
            }
            else if (dw_detail.DataObject is DRouteFreqPointType)
            {
                ((DRouteFreqPointType)dw_detail.DataObject).InsertItem<RouteFreqPointType>(row, RouteFreqPointType.NewRouteFreqPointType(null));
            }
            else if (dw_detail.DataObject is DPostCodeType)
            {
                ((DPostCodeType)dw_detail.DataObject).InsertItem<PostCodeType>(row, PostCodeType.NewPostCodeType(null));
            }
            else if (dw_detail.DataObject is DProcurement)
            {
                ((DProcurement)dw_detail.DataObject).InsertItem<Procurement>(row, Procurement.NewProcurement(null));
            }
            else if (dw_detail.DataObject is DRenewalGroup)
            {
                ((DRenewalGroup)dw_detail.DataObject).InsertItem<RenewalGroup>(row, RenewalGroup.NewRenewalGroup(null));
            }
            else if (dw_detail.DataObject is DRoadSuffix)
            {
                ((DRoadSuffix)dw_detail.DataObject).InsertItem<RoadSuffix>(row, RoadSuffix.NewRoadSuffix(null));
            }
            else if (dw_detail.DataObject is DRoadType)
            {
                ((DRoadType)dw_detail.DataObject).InsertItem<RoadType>(row, RoadType.NewRoadType(null));
            }
            else if (dw_detail.DataObject is DRouteFreqVerbs)
            {
                ((DRouteFreqVerbs)dw_detail.DataObject).InsertItem<RouteFreqVerbs>(row, RouteFreqVerbs.NewRouteFreqVerbs(null));
            }
            else if (dw_detail.DataObject is DStandardFrequency)
            {
                ((DStandardFrequency)dw_detail.DataObject).InsertItem<StandardFrequency>(row, StandardFrequency.NewStandardFrequency(null));
            }
            else if (dw_detail.DataObject is DSuburblocality)
            {
                ((DSuburblocality)dw_detail.DataObject).InsertItem<Suburblocality>(row, Suburblocality.NewSuburblocality(null));
            }
            else if (dw_detail.DataObject is NZPostOffice.RDSAdmin.DataControls.Security.DTowncity)
            {
                ((NZPostOffice.RDSAdmin.DataControls.Security.DTowncity)dw_detail.DataObject).InsertItem<NZPostOffice.RDSAdmin.Entity.Security.DTowncity>(row, NZPostOffice.RDSAdmin.Entity.Security.DTowncity.NewTowncity(null));
            }
            else if (dw_detail.DataObject is DVehicalClass)
            {
                ((DVehicalClass)dw_detail.DataObject).InsertItem<VehicalClass>(row, VehicalClass.NewVehicalClass(null));
            }
            else if (dw_detail.DataObject is DVehicalType)
            {
                ((DVehicalType)dw_detail.DataObject).InsertItem<VehicalType>(row, VehicalType.NewVehicalType(null));
            }
            else if (dw_detail.DataObject is DNpadParameters)
            {
                ((DNpadParameters)dw_detail.DataObject).InsertItem<NpadParameters>(row, NpadParameters.NewNpadParameters(null));
            }
            ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")).ClearSelection();
            ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")).Rows[dw_detail.GetRow()].Selected = true;
        }

        private void mRdsDw_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mRdsDw.m_delete.Visible = false;
            mRdsDw.m_insert.Visible = false;
            // Enable insert and Delete 
            if (dw_detail.DataObject is DwGroupDetails || dw_detail.DataObject is DProcurement)
            {
                mRdsDw.m_insert.Visible = true;
                mRdsDw.m_delete.Visible = true;
                //! add temp
                mRdsDw.m_insert.Enabled = true;
                mRdsDw.m_delete.Enabled = true;
            }
            else if (dw_detail.DataObject is DwUserDetails)
            {
                mRdsDw.m_insert.Visible = false;
                mRdsDw.m_delete.Visible = false;
            }
            else if (dw_detail.DataObject is DOutletList)
            {
                // Region insert
                mRdsDw.m_insert.Visible = false;
            }
            else
            {
                // System table right click
                mRdsDw.m_insert.Visible = true;
            }
        }

        private void Grid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string ls_component_name;
            int ll_component_id;
            int ll_Ctr;
            if (e.Button == MouseButtons.Left && ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.GetControlByName("grid")).Columns[e.ColumnIndex].Name == "component_list")
            {
                WSecurityComponent w = new WSecurityComponent();
                w.ShowDialog(this);

                // Capture the return value from the component_serach window
                Structures.StrInfo lstr_info = (Structures.StrInfo)StaticMessage.PowerObjectParm;
                if (lstr_info.p_id == null || lstr_info.p_id.Count == 0)
                {
                    return;
                }
                if (lstr_info.p_id.Count == 1)
                {
                    // Ony 1 selected
                    GroupDetails BE = dw_detail.DataObject.Current as GroupDetails;
                    ls_component_name = lstr_info.p_name[0].Trim();
                    ll_component_id = lstr_info.p_id[0];
                    BE.RdsComponentRcDescription = ls_component_name;
                    BE.RdsUserRightsRcId = ll_component_id;
                    BE.RdsComponentRcAllowcreate = lstr_info.p_create[0];
                    BE.RdsComponentRcAllowread = lstr_info.p_read[0];
                    BE.RdsComponentRcAllowmodify = lstr_info.p_modify[0];
                    BE.RdsComponentRcAllowdelete = lstr_info.p_delete[0];
                    this.dw_detail_ListChanged(this, new System.ComponentModel.ListChangedEventArgs(System.ComponentModel.ListChangedType.ItemChanged, dw_detail.DataObject.GetRow()));
                    if (BE.RdsUserRightsRegionId == null)
                    {
                        BE.RdsUserRightsRegionId = 0;
                    }
                    dw_detail.DataObject.AcceptText();
                    dw_detail.Refresh();
                }
                else
                {
                    // More than 1 selected
                    GroupDetails BE = null;
                    for (ll_Ctr = 0; ll_Ctr < lstr_info.p_id.Count; ll_Ctr++)
                    {
                        ls_component_name = lstr_info.p_name[ll_Ctr].Trim();
                        ll_component_id = lstr_info.p_id[ll_Ctr];
                        // if ls_component = "" then the uses has clicked close or double clicked on nothing
                        if (ls_component_name != "")
                        {
                            BE = GroupDetails.NewGroupDetails(null);
                            BE.RdsComponentRcDescription = ls_component_name;
                            BE.RdsUserRightsRcId = ll_component_id;
                            BE.RdsComponentRcAllowcreate = lstr_info.p_create[ll_Ctr];
                            BE.RdsComponentRcAllowread = lstr_info.p_read[ll_Ctr];
                            BE.RdsComponentRcAllowmodify = lstr_info.p_modify[ll_Ctr];
                            BE.RdsComponentRcAllowdelete = lstr_info.p_delete[ll_Ctr];
                            if (lstr_info.p_read[ll_Ctr] == "Y")
                            {
                                BE.RdsUserRightsRurRead = "Y";
                            }
                            BE.RdsUserRightsRegionId = 0;
                            dw_detail.DataObject.InsertItem<GroupDetails>(ll_Ctr, BE);
                        }
                    }
                    //if (!(dw_detail.GetItemNumber(ll_Row, "rds_user_rights_rc_id") > 0))
                    //{
                    //    dw_detail.DeleteRow(ll_Row);
                    //}
                    if (!(BE.RdsUserRightsRcId > 0))
                    {
                        dw_detail.DataObject.DeleteItem<GroupDetails>(BE);
                    }
                    dw_detail.DataObject.AcceptText();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ((DataEntityGrid)dw_detail.DataObject.Controls["grid"]).Rows[e.RowIndex].Selected = true;
            }
        }

        private void tv_1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tv_1.SelectedNode = e.Node;
                if (!tv_1.SelectedNode.IsExpanded)
                {
                    tv_1.SelectedNode.Expand();
                }
            }
        }

        private void m_SecTvs_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //!TreeViewItem ltvi_this;

            bool lb_ChildrenFound = false;

            m_SecTvs.m_delete.Visible = true;
            m_SecTvs.m_add.Visible = true;
            m_SecTvs.m_delete.Enabled = true;
            m_SecTvs.m_add.Enabled = true;
            //  tjb SR4622 - The rightclicked event that sets the il_rightclicked
            //      value seems to be triggered AFTER this event  ( changed since 
            //      the code was originally written).  This hack sets it so the 
            //      code here can work.
            //      The calling event  ( pfc_u_tvs.rightclicked) sets the 'visible'
            //      value to TRUE if there was a rightclicked event, and the 
            //      'il_to_handle' contains the value that the il_rightclicked 
            //      variable should contain.
            //!if (m_SecTvs.m_delete.Visible) {
            //    il_rightclicked = il_to_handle;
            //}
            //// Get the item that was rightclicked on
            //tv_1.selectItem(il_rightclicked);
            //// Expand the branch so the find will work correctly
            //if (!ltvi_this.Expanded) {
            //    tv_1.ExpandItem(il_rightclicked);
            //}
            //// Find out if a branch of the tree has children, if so disable delete.
            //lb_ChildrenFound = tv_1.FindItem(childtreeitem!, il_rightclicked) != -(1);
            // We create our own rmb menu inherited from m_tvs
            // Disable delete and add if no level
            if (tv_1.SelectedNode == null)
            {
                m_SecTvs.m_delete.Visible = false;
                m_SecTvs.m_add.Visible = false;
            }
            else
            {
                lb_ChildrenFound = tv_1.SelectedNode.Nodes.Count > 0;
                // Control right clicks 
                // PowerBuilder 'Choose Case' statement converted into 'if' statement
                int id = 0;
                int parent_id1 = 0;
                int parent_id2 = 0;
                switch (tv_1.SelectedNode.Level)
                {
                    case 0:
                        // Check Level 1
                        // PowerBuilder 'Choose Case' statement converted into 'if' statement
                        GroupsAndUsersLevel1 Entity1 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel1;
                        id = Entity1.Id.GetValueOrDefault();
                        switch (id)
                        {
                            case 1:
                                m_SecTvs.m_delete.Visible = false;
                                m_SecTvs.m_add.Visible = true;
                                break;
                            // 'Users'
                            case 2:
                                m_SecTvs.m_delete.Visible = false;
                                m_SecTvs.m_add.Visible = true;
                                // 'System Tables'	
                                break;
                            case 3:
                                m_SecTvs.m_delete.Visible = false;
                                m_SecTvs.m_add.Visible = false;
                                break;
                        }
                        // Level 2	
                        break;
                    case 1:
                        // Check the immediate parent
                        // PowerBuilder 'Choose Case' statement converted into 'if' statement
                        GroupsAndUsersLevel2 Entity2 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel2;
                        parent_id1 = Entity2.ParentId1.GetValueOrDefault();
                        switch (parent_id1)
                        {
                            case 1:
                                if (lb_ChildrenFound)
                                {
                                    m_SecTvs.m_delete.Enabled = false;
                                    m_SecTvs.m_delete.Visible = true;
                                    m_SecTvs.m_add.Visible = false;
                                }
                                else
                                {
                                    m_SecTvs.m_delete.Enabled = true;
                                    m_SecTvs.m_delete.Visible = true;
                                    m_SecTvs.m_add.Visible = false;
                                }
                                // Parent is a user
                                break;
                            case 2:
                                if (lb_ChildrenFound)
                                {
                                    m_SecTvs.m_delete.Enabled = false;
                                    m_SecTvs.m_delete.Visible = true;
                                    m_SecTvs.m_add.Visible = false;
                                }
                                else
                                {
                                    m_SecTvs.m_delete.Enabled = true;
                                    m_SecTvs.m_delete.Visible = true;
                                    m_SecTvs.m_add.Visible = false;
                                }
                                // Parent is a system table
                                break;
                            case 3:
                                m_SecTvs.m_delete.Visible = false;
                                m_SecTvs.m_add.Visible = false;
                                break;
                            // Reserved	
                        }
                        // Level 3
                        break;
                    case 2:
                        // Check parent2  ( Level 1 grandparent)
                        // PowerBuilder 'Choose Case' statement converted into 'if' statement
                        GroupsAndUsersLevel3 Entity3 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel3;
                        parent_id2 = Entity3.ParentId2.GetValueOrDefault();
                        switch (parent_id2)
                        {
                            case 1:
                                m_SecTvs.m_delete.Visible = true;
                                m_SecTvs.m_add.Visible = false;
                                // Grandpa is a User
                                break;
                            case 2:
                                m_SecTvs.m_delete.Visible = true;
                                m_SecTvs.m_add.Visible = false;
                                // Grandpa is a System Table  ( only applies to Regions for now)
                                break;
                            case 3:
                                m_SecTvs.m_delete.Visible = false;
                                m_SecTvs.m_add.Visible = false;
                                break;
                        }
                        break;
                }
            }
            // Assign a parent because assignment below resets the parent
            //// Assign our own menu 
            //am_view = m_SecTvs;
            // Let ancestor do its normal processing
        }

        private void dw_detail_DoubleClick(object sender, EventArgs e)
        {
            int ll_outlet_id = 0;
            int ll_suburb_id = 0;
            int ll_rc = 0;

            //  TJB SR4616 29-Oct-2004
            //  Added d_suburblocality section
            if (dw_detail.DataObject is DSuburblocality)
            {
                if (dw_detail.GetRow() >= 0)
                {
                    ll_suburb_id = dw_detail.DataObject.GetValue<int>(dw_detail.GetRow(), "sl_id");
                }
                if (ll_suburb_id > 0)
                {
                    //OpenWithParm(w_add_suburb, ll_suburb_id);
                    WAddSuburb w = new WAddSuburb(ll_suburb_id);
                    w.ShowDialog(this);
                }
            }
            if (dw_detail.DataObject is DOutletList)
            {
                if (dw_detail.DataObject.Current != null)
                {
                    ll_outlet_id = ((OutletList)dw_detail.DataObject.Current).OutletId.GetValueOrDefault();
                }
                if (ll_outlet_id > 0)
                {
                    //OpenWithParm(w_security_outlet_details, ll_outlet_id);
                    WSecurityOutletDetails w_security_outlet_details = new WSecurityOutletDetails(ll_outlet_id);
                    w_security_outlet_details.ShowDialog(this);
                    ll_rc = (int)StaticMessage.DoubleParm;
                    if (ll_rc != 0)
                    {
                        dw_detail.Retrieve(new object[] { ll_rc });
                        dw_detail_retrieveend();
                    }
                }
                //  insert new entry into outlet
                if (ll_outlet_id == 0)
                {
                    /*  select max ( outlet_id) into :ll_outlet_id  from outlet;*/
                    MainMdiService.GetMaxOutletId(ref ll_outlet_id);
                    ll_outlet_id++;
                    /* insert into outlet(outlet_id, region_id) values ( :ll_outlet_id, :il_region_id);*/
                    MainMdiService.InsertOutlet(il_region_id);
                    //OpenWithParm(w_security_outlet_details, ll_outlet_id);
                    WSecurityOutletDetails w_security_outlet_details = new WSecurityOutletDetails(ll_outlet_id);
                    w_security_outlet_details.ShowDialog(this);
                    ll_rc = (int)StaticMessage.DoubleParm;
                    if (ll_rc != 0)
                    {
                        dw_detail.Retrieve(new object[] { ll_rc });
                        dw_detail_retrieveend();
                    }
                    else
                    {
                        //  delete the newly written
                        /* delete from outlet  where outlet_id = :ll_outlet_id;*/
                        MainMdiService.DeleteOutlet(ll_outlet_id);
                    }
                }
            }
            if (dw_detail.DataObject is DwUserDetails)
            {
                /*!if (KeyDown(keycontrol!) && KeyDown(keyshift!)) 
                //{
                //    MessageBox("Password", gnv_app.of_Decrypt(GetItemString(1, "rds_user_id_ui_password")));
                //}*/
            }
        }

        public override void ue_refresh()
        {
            //!tv_1.of_Refresh();
            tv_1.of_refresh();
            dw_header.Visible = false;
            dw_detail.Visible = false;
            dw_user_region.Visible = false;
            dw_1.Visible = false;
            dw_contract_type.Visible = false;
            dw_user_details.Visible = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            //  Register the controls with the Vertical SplitBar
            /*! st_1.of_Register(tv_1, st_1.Left);
             st_1.of_Register(dw_detail, st_1.Right);
             st_1.of_Register(dw_header, st_1.Right);
             st_1.of_Register(gb_details, st_1.Right);
             st_1.of_Register(dw_contract_type, st_1.Right);
             st_1.of_Register(dw_user_region, st_1.Right);
             //  Window Resize Behavior
             of_setresize(true);
             inv_resize.of_register(tv_1, 0, 0, 0, 100);
             inv_resize.of_register(st_1, 0, 0, 0, 100);
             // inv_resize.of_Register ( dw_detail				, 0, 0, 100	, 100)
             inv_resize.of_register(dw_header, this.inv_resize.SCALERIGHT);
             inv_resize.of_register(gb_details, 0, 0, 100, 100);
             inv_resize.of_register(dw_detail, this.inv_resize.SCALERIGHTBOTTOM);
             inv_resize.of_register(dw_contract_type, this.inv_resize.SCALERIGHTBOTTOM);
             inv_resize.of_register(dw_user_region, this.inv_resize.SCALERIGHTBOTTOM);*/
            //!of_setlogicalunitofwork(true);
        }

        private int? rds_user_id_ui_id = 0;
        public override int pfc_save()
        {
            base.pfc_save();
            tv_1.Focus();
            int ll_current_item;
            int ll_rc;
            if (dw_detail.DataObject.RowCount > 0 && dw_detail.DataObject is DwUserDetails)
            {
                 rds_user_id_ui_id = dw_detail.DataObject.GetItem<UserDetails>(0).RdsUserIdUiId;
                //rds_user_id_ui_id = (int?) StaticFunctions.GetValueUsingReflection(dw_detail.DataObject, 0, "RdsUserIdUiId");
            }
            int of_save_falg = this.of_save(false);
            if (of_save_falg == SUCCESS)
            {
                //ll_rc = tv_1.FindItem(currenttreeitem!, ll_current_item);
                //of_refreshbranch(ll_rc);
                pfc_update();
                // pfc_postupdate
                dw_detail.DataObject.ResetUpdate();
                RefreshNode(tv_1.SelectedNode);

            }
            return SUCCESS;
        }

        public override void pfc_exit()
        {
            if (MessageBox.Show("Are you sure you want to exit?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                base.pfc_exit();
            }
        }

        private void RefreshNode(TreeNode node)
        {
            if (node != null)
            {
                node.Nodes.Clear();
                tv_1.Populate(node, true);
            }
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMainMdi));
            this.dw_user_region = new NZPostOffice.RDSAdmin.DataControls.Security.DwUserRegion();
            this.dw_detail = new Metex.Windows.DataUserControlContainer();
            //!this.dw_detail.DataObject = new DwGroupDetails();
            this.dw_1 = new NZPostOffice.RDSAdmin.DataControls.Security.DwGroupDetails();
            this.st_1 = new NZPostOffice.Shared.VisualComponents.USt();
            this.tv_1 = new NZPostOffice.RDSAdmin.Controls.USecurityTvs();
            this.MainMdiImageList = new System.Windows.Forms.ImageList(this.components);
            this.dw_header = new Metex.Windows.DataUserControlContainer();
            this.dw_contract_type = new NZPostOffice.RDSAdmin.DataControls.Security.DwContractTypes();
            //this.dw_contract_type.ItemChanged+=new EventHandler(dw_contract_type_ItemChanged);
            this.dw_contract_type.CellClick += new EventHandler(dw_contract_type_ItemChanged);
            this.gb_details = new System.Windows.Forms.GroupBox();
            this.dw_user_details = new NZPostOffice.RDSAdmin.DataControls.Security.DUiIdDetails();
            this.dw_user_details.lockClick += new EventHandler(dw_user_details_lockClick);
            this.dw_detail.SuspendLayout();
            this.SuspendLayout();
            // 
            // dw_user_region
            // 
            this.dw_user_region.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dw_user_region.FilterString = "";
            this.dw_user_region.Location = new System.Drawing.Point(456, 260);
            this.dw_user_region.Name = "dw_user_region";
            this.dw_user_region.Size = new System.Drawing.Size(175, 180);
            this.dw_user_region.SortString = "";
            this.dw_user_region.TabIndex = 5;
            this.dw_user_region.Visible = false;
            this.dw_user_region.LostFocus += new System.EventHandler(this.dw_user_region_losefocus);
            //this.dw_user_region.CellClick += new EventHandler(dw_user_region_ItemChanged);
            // 
            // dw_detail
            // 
            this.dw_detail.Controls.Add(this.dw_1);
            this.dw_detail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)));
            this.dw_detail.Location = new System.Drawing.Point(212, 160);
            this.dw_detail.Name = "dw_detail";
            this.dw_detail.Size = new System.Drawing.Size(552, 320);
            this.dw_detail.TabIndex = 5;
            this.dw_detail.Visible = false;
            // 
            // dw_1
            // 
            this.dw_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dw_1.FilterString = "";
            this.dw_1.Location = new System.Drawing.Point(-3, -500);
            this.dw_1.Name = "dw_1";
            this.dw_1.Size = new System.Drawing.Size(552, 356);
            this.dw_1.SortString = "rds_component_rc_description ASC";
            this.dw_1.TabIndex = 1;
            this.dw_1.Visible = false;
            // 
            // st_1
            // 
            this.st_1.Location = new System.Drawing.Point(200, 35);
            this.st_1.Name = "st_1";
            this.st_1.Size = new System.Drawing.Size(3, 504);
            this.st_1.TabIndex = 1;
            // 
            // tv_1
            // 
            this.tv_1.AllowDrop = true;
            this.tv_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tv_1.ImageIndex = 0;
            this.tv_1.ImageList = this.MainMdiImageList;
            this.tv_1.Location = new System.Drawing.Point(5, 35);
            this.tv_1.Name = "tv_1";
            this.tv_1.SelectedImageIndex = 0;
            this.tv_1.Size = new System.Drawing.Size(192, 504);
            this.tv_1.TabIndex = 6;
            this.tv_1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv_1_DragDrop);
            this.tv_1.DragOver += new System.Windows.Forms.DragEventHandler(this.tv_1_DragOver);
            this.tv_1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_1_AfterSelect);
            this.tv_1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tv_1_MouseUp);
            this.tv_1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tv_1_MouseMove);
            this.tv_1.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv_1_DragEnter);
            this.tv_1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_1_BeforeSelect);
            this.tv_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_1_MouseDown);
            this.tv_1.ItemDrag += new ItemDragEventHandler(tv_1_ItemDrag);
            // 
            // MainMdiImageList
            // 
            this.MainMdiImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MainMdiImageList.ImageStream")));
            this.MainMdiImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.MainMdiImageList.Images.SetKeyName(0, "Icon3.ico");
            this.MainMdiImageList.Images.SetKeyName(1, "Icon1.ico");
            this.MainMdiImageList.Images.SetKeyName(2, "Icon5.ico");
            this.MainMdiImageList.Images.SetKeyName(3, "Icon2.ico");
            this.MainMdiImageList.Images.SetKeyName(4, "Icon4.ico");
            // 
            // dw_header
            // 
            this.dw_header.DataObject = null;
            this.dw_header.Location = new System.Drawing.Point(213, 37);
            this.dw_header.Name = "dw_header";
            this.dw_header.Size = new System.Drawing.Size(552, 174);
            this.dw_header.TabIndex = 3;
            this.dw_header.Visible = false;
            // 
            // dw_contract_type
            // 
            this.dw_contract_type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.dw_contract_type.FilterString = "";
            this.dw_contract_type.Location = new System.Drawing.Point(456, 37);
            this.dw_contract_type.Name = "dw_contract_type";
            this.dw_contract_type.Size = new System.Drawing.Size(175, 228);
            //this.dw_contract_type.SortString = "";
            this.dw_contract_type.TabIndex = 2;
            this.dw_contract_type.Visible = false;
            // 
            // gb_details
            // 
            this.gb_details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_details.Location = new System.Drawing.Point(205, 27);
            this.gb_details.Name = "gb_details";
            this.gb_details.Size = new System.Drawing.Size(571, 516);
            this.gb_details.TabIndex = 0;
            this.gb_details.TabStop = false;
            this.gb_details.Text = "Details";
            // 
            // dw_user_details
            // 
            this.dw_user_details.BackColor = System.Drawing.SystemColors.Control;
            this.dw_user_details.FilterString = "";
            this.dw_user_details.Location = new System.Drawing.Point(212, 253);
            this.dw_user_details.Name = "dw_user_details";
            this.dw_user_details.Size = new System.Drawing.Size(235, 256);
            this.dw_user_details.SortString = "";
            this.dw_user_details.TabIndex = 4;
            this.dw_user_details.Visible = false;
            // 
            // WMainMdi
            // 
            this.ClientSize = new System.Drawing.Size(788, 568);
            this.Controls.Add(this.dw_detail);
            this.Controls.Add(this.st_1);
            this.Controls.Add(this.tv_1);
            this.Controls.Add(this.dw_header);
            this.Controls.Add(this.gb_details);
            this.Controls.Add(this.dw_user_details);
            this.Controls.Add(this.dw_user_region);
            this.Controls.Add(this.dw_contract_type);
            this.Name = "WMainMdi";
            this.Text = "Rural Delivery System Administration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WMainMdi_FormClosed);
            this.dw_detail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void dw_user_region_ItemChanged(object sender, EventArgs e)
        {
        }

        void tv_1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tv_1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            this.selectionchanging(e);
        }

        private void tv_1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.ue_navigated();
        }

        public int of_display_level_source_error(int al_level_source_error)
        {
            int li_Ret;
            /*!if (MObject.IsValid(gnv_app.inv_Error))
            //{
            //    // PowerBuilder 'Choose Case' statement converted into 'if' statement
            //    int TestExpr = al_level_source_error;
            //    if (TestExpr == -(1))
            //    {
            //        li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Argument validation error");
            //    }
            //    else if (TestExpr == -(2))
            //    {
            //        li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Dwobject had no key columns assigned");
            //    }
            //    else if (TestExpr == -(3))
            //    {
            //        li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "A previous level was marked as recursive");
            //    }
            //    else if (TestExpr == -(4))
            //    {
            //        li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Column level datatype was not in the data source");
            //    }
            //    else if (TestExpr == -(5))
            //    {
            //        li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "SetTransObject failed for the data source");
            //    }
            //    else if (TestExpr == -(7))
            //    {
            //        li_Ret = gnv_app.inv_Error.of_Message("RDS System Security treeview", "Cache registration error");
            //    }
            }*/
            return 1;
        }

        public int of_setup_level_source()
        {
            int li_Ret;
            // Set up base services
            /*!   tv_1.of_SetBase(true);
               // Enable level source service
               tv_1.of_SetLevelSource(true);
               // Set up level source, catching any errors
               li_Ret = tv_1.inv_levelsource.of_Register(1, "label", "", "dw_groups_and_users_level1", sqlca, "");
               of_display_level_source_error(li_Ret);
               li_Ret = tv_1.inv_levelsource.of_Register(2, "label", "parent.1.id", "dw_groups_and_users_level2", sqlca, "");
               of_display_level_source_error(li_Ret);
               li_Ret = tv_1.inv_levelsource.of_Register(3, "label", "parent.1.id, parent.1.parent_id1", "dw_groups_and_users_level3", sqlca, "");
               of_display_level_source_error(li_Ret);
               // set default pics from TV picture array
               li_Ret = tv_1.inv_levelsource.of_SetPictureColumn(1, "pictindex");
               li_Ret = tv_1.inv_levelsource.of_SetPictureColumn(2, "pictindex");
               li_Ret = tv_1.inv_levelsource.of_SetPictureColumn(3, "pictindex");
               // specify column that references selected pictures when selected
               li_Ret = tv_1.inv_levelsource.of_SetSelectedPictureColumn(1, "pictindex");
               li_Ret = tv_1.inv_levelsource.of_SetSelectedPictureColumn(2, "pictindex");
               li_Ret = tv_1.inv_levelsource.of_SetSelectedPictureColumn(3, "pictindex");
               of_refresh();*/
            return 1;
        }

        public int of_refresh()
        {
            int ll_Row;
            int ll_Handle;
            string ls_Node_Type;
            string ls_Node_Id;
            int li_ret;
            /*!  this.SetRedraw(false);
              // Clear the tree then load first level
              tv_1.inv_levelsource.of_ResetTree();
              tv_1.of_Reset();
              // Populate level 1 
              // 	- will trigger selectionchanged. ib_Refreshing will stop code from selectionchanged
              tv_1.pfc_Populate(0);
              this.SetRedraw(true);*/
            return 1;
        }

        public int of_process()
        {
            //int ll_Level;
            //int ll_Parent_Id1;
            //int ll_Parent_Id2;
            //int ll_ID;
            //string ls_label;
            //// We need to get some info off the treeview
            //// because the user has navigated it ie clicked, 
            //// up/down arrow pressed, double-clicked
            //// level
            //ll_Level = tv_1.inv_levelsource.of_getlevel(tv_1.il_to_handle);
            //// Get the label
            //ls_label = this.of_get_label(tv_1.il_to_handle);
            //// Get the ID
            //ll_ID = this.of_get_id(tv_1.il_to_handle);
            //// get parent id1
            //ll_Parent_Id1 = this.of_get_parent_id1(tv_1.il_to_handle);
            //// get parent id2
            //ll_Parent_Id2 = this.of_get_parent_id2(tv_1.il_to_handle);
            //// Now you have info, retrieve stuff into dw,
            //// depending on what has been clicked on
            //// PowerBuilder 'Choose Case' statement converted into 'if' statement
            //long TestExpr = ll_Level;
            //if (TestExpr == 1)
            //{
            //    // ignore - maybe reset the dw
            //    dw_detail.Visible = false;
            //}
            //else if (TestExpr == 2)
            //{
            //    // either a group or a user
            //    if (ll_Parent_Id1 == 1)
            //    {
            //        // the parent is the group string
            //        // tv_1.im_view.m_add.Visible = False
            //        dw_detail.Visible = true;
            //        dw_detail.dataobject = "dw_group_details";
            //        dw_detail.SetTransObject(sqlca);
            //        dw_detail.retrieve(ll_ID);
            //    }
            //    else
            //    {
            //        // the parent is the user string
            //        dw_detail.Visible = true;
            //        dw_detail.dataobject = "dw_user_details";
            //        dw_detail.SetTransObject(sqlca);
            //        dw_detail.retrieve(ll_ID);
            //    }
            //}
            //else if (TestExpr == 3)
            //{
            //    // memberships
            //    if (ll_Parent_Id2 == 1)
            //    {
            //        // we are looking at user id ( ll_id) who is a member of group ( ll_Parent_Id1)
            //        dw_detail.Visible = true;
            //        dw_detail.dataobject = "dw_user_details";
            //        dw_detail.SetTransObject(sqlca);
            //        dw_detail.retrieve(ll_ID);
            //    }
            //    else
            //    {
            //        // we are looking at group ( ll_id) who is assigned to user  ( ll_Parent_Id1)
            //        dw_detail.Visible = true;
            //        dw_detail.dataobject = "dw_group_details";
            //        dw_detail.SetTransObject(sqlca);
            //        dw_detail.retrieve(ll_ID);
            //    }
            //}
            return 0;
        }

        //public string of_get_label(int al_handle)
        //{
        //    string ls_Label;
        //    int ll_Level;
        //    string ls_Id;
        //    int ll_datarow;
        //    NDs lds_datasource;
        //    // Get node data from the level source
        //    if (al_handle > 0)
        //    {
        //        // What level?
        //        ll_Level = tv_1.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (tv_1.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1)
        //        {
        //            // Get the label
        //            ls_Label = String(lds_datasource.Object.label[ll_datarow]);
        //        }
        //    }
        //    return ls_Label;
        //}

        //public  int of_get_id(int al_handle)
        //{
        //    int ll_Id;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0)
        //    {
        //        // What level?
        //        ll_Level = tv_1.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (tv_1.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1)
        //        {
        //            // Get the id
        //            ll_Id = Long(lds_datasource.Object.id[ll_datarow]);
        //        }
        //    }
        //    return ll_Id;
        //}

        //public  int of_get_parent_id1(int al_handle)
        //{
        //    int ll_Id;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0)
        //    {
        //        // What level?
        //        ll_Level = tv_1.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (tv_1.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1)
        //        {
        //            // Get the id
        //            ll_Id = Long(lds_datasource.Object.parent_id1[ll_datarow]);
        //        }
        //    }
        //    return ll_Id;
        //}

        //public  int of_get_parent_id2(int al_handle)
        //{
        //    int ll_Id;
        //    int ll_Level;
        //    string ls_Id;
        //    NDs lds_datasource;
        //    int ll_datarow;
        //    // Get node data from the level source
        //    if (al_handle > 0)
        //    {
        //        // What level?
        //        ll_Level = tv_1.inv_levelsource.of_getlevel(al_handle);
        //        // Find the DataStore which contains information for this item
        //        if (tv_1.inv_levelsource.of_getdatarow(al_handle, lds_datasource, ll_datarow) == 1)
        //        {
        //            // Get the id only if we are at level 3
        //            if (ll_Level == 3)
        //            {
        //                ll_Id = Long(lds_datasource.Object.parent_id2[ll_datarow]);
        //            }
        //        }
        //    }
        //    return ll_Id;
        //}

        public int of_save()
        {
            // Overloaded - save with user prompt
            return this.of_save(true);
        }

        public int of_deletegroup(int al_group_id)
        {
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            /* Delete rd.rds_user_group Where ug_id = :al_group_id   */
            if (!MainMdiService.DeleteUserGroup(al_group_id))
            {
                MessageBox.Show("Database Error", "Unable to delete group.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
            }
            return SUCCESS;
        }

        public int of_deleteuser(int al_user_id)
        {
            int li_rc;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            if (al_user_id == 1)
            {
                //  user is trying to delete the SysAdmin account
                //  prompt for confirmation
                //  li_rc = MessageBox.Show(this.Text, "Are you sure you want to delete the system administrator account?", question!, yesno!, 2);
                li_rc = MessageBox.Show(this.Text, "Are you sure you want to delete the system administrator account?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes ? 1 : 2;
                if (li_rc == 2)
                {
                    return SUCCESS;
                }
            }
            /* Delete rd.rds_user Where u_id = :al_user_id*/
            if (!MainMdiService.DeleteUser(al_user_id))
            {
                MessageBox.Show("Database Error", "Unable to delete user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
            }
            //  TJB  SR4598  April 2005
            //  If the user's record is deleted, clear out any 
            //  user_region records too.
            /*  Delete rd.rds_user_region Where u_id = :al_user_id*/
            if (!MainMdiService.DeleteUserRegion(al_user_id))
            {
                MessageBox.Show("Database Error", "Unable to delete user_region records.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
            }
            return SUCCESS;
        }

        public int of_removeusergroup(int al_group_id, int al_ui_id)
        {
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            /* Delete rds_user_id_group where ug_id = :al_group_id and ui_id = :al_ui_id*/
            if (!MainMdiService.DeleteUserGroup(al_group_id, al_ui_id))
            {
                MessageBox.Show("Database Error", "Unable to delete.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
                //  Rollback;
            }
            return SUCCESS;
        }

        public string of_get_dataobject(int ai_mt_id)
        {
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            string ls_dataobject = "";
            /*
            Select mt_dataobject Into :ls_dataobject From rds_maintenance_table Where mt_id = :ai_mt_id Using SQLCA;*/

            if (!MainMdiService.GetMtDataObject(ai_mt_id, ref ls_dataobject))
            {
                MessageBox.Show("Database Error", "Unable to create user id.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\n" + "Error Text: " + SQLErrText);
            }

            //these code added by someone, why?   --modified by jlwang
            //DataSet ds = null;
            //string msg = "";
            //new CommonService().ExecuteSQLQueryWithReturn(
            //    "Select mt_dataobject From rds_maintenance_table Where mt_id = ?",
            //    new object[] { new object[] { "ai_mt_id", ai_mt_id } }, ref ds, ref msg);

            //if (ds == null || ds.Tables.Count == 0)
            //{
            //    MessageBox.Show("Unable to create user id.  \n\n" + "Error Code: -1" + "\n\n" + "Error Text: " + msg, "Database Error");
            //}
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    ls_dataobject = ds.Tables[0].Rows[0][0].ToString();
            //}
            return ls_dataobject;
        }

        public int of_save(bool ab_prompt)
        {
            int li_rc = 0;
            DialogResult li_response = DialogResult.None;
            string ls_msg;
            string ls_title;
            int li_YES = 1;
            int li_NO = 2;
            DataUserControl idw;
            //  Checks if datawindows are modified
            dw_detail.DataObject.AcceptText();
            if (ab_prompt)
            {
                if (StaticFunctions.IsDirty(dw_header.DataObject)
                    || StaticFunctions.IsDirty(dw_detail.DataObject)
                    || dw_detail.DataObject.DeletedCount > 0
                    || StaticFunctions.IsDirty(dw_user_region)
                    || StaticFunctions.IsDirty(dw_contract_type)
                    || StaticFunctions.IsDirty(dw_user_region))
                {                    
                    //  TJB  Oct 2005
                    //  Changed the messages to reflect what has actually 
                    //  changed  ( used to say everything other than a group
                    //  change was a user change).
                    ls_title = "";                    
                    if (dw_detail.DataObject is DwGroupDetails)
                    {
                        ls_title = "Save Group Details?";
                        ls_msg = "The group information has been modified.";
                    }
                    else if (dw_detail.DataObject is DwUserDetails)
                    {
                        ls_title = "Save User Details?";
                        ls_msg = "The user information has been modified.";
                    }
                    else
                    {
                        ls_title = "Save Details?";
                        ls_msg = "Some information has been modified.";
                    }
                    if (ls_title.Length > 0)
                    {
                        li_response = MessageBox.Show(ls_msg + "  \n" + "Do you want to save the new details?", ls_title,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    }
                }
                if (li_response == DialogResult.No)
                {
                    //?return SUCCESS;
                    return 1;

                }
            }
            //  Saves the header dw if modified
            if (StaticFunctions.IsDirty(dw_header.DataObject))
            {
                // 	dw_header.Event Pfc_Update ( True, True)
                //li_rc = inv_luw.of_save(dw_header, sqlca);
                if (dw_header.DataObject is DwGroupHeader)
                {
                    GroupHeader header = dw_header.DataObject.Current as GroupHeader;
                    //if(header!=null &&( header.UgName==null||header.UgName.Length<=0))
                    //{
                    //    MessageBox.Show("A group name must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return FAILURE;
                    //}
                    if (header != null && !header.IsNew)
                    {
                        header.UgModifiedBy = StaticVariables.LoginId;
                    }
                    if (header.UgId == null)
                    {
                        header.UgId = MainMdiService.GetNextSequence("rdsUserGroup").GetValueOrDefault();
                    }
                }
                //idw = new DwGroupHeader();
                idw = dw_header.DataObject;  //? as code logic needs change idw to dw_header.DataObject (maybe with some bugs for other DW)
                if (this.pfc_validation(idw) == SUCCESS)
                {
                    dw_header.DataObject.Save();
                }
            }
            if (li_rc < 0)
            {
                return li_rc;
            }
            /* ***********************************
                Checks the save result
                1  Success
                0  No pending updates
                -1  Accept text error
                -2  Updates pending error
                -3  Validation error
                -4  Pre-update error
                -5  Begin transaction error
                -6  Update error
                -7  End transaction error
                -8  Post save error
                -9  Update prep error
                *********************************** */
            //  Saves the detail dw if modified
            if (StaticFunctions.IsDirty(dw_detail.DataObject) || dw_detail.DataObject.DeletedCount > 0)
            {               
                //li_rc = inv_luw.of_save(dw_detail, sqlca);
                if (dw_detail.DataObject is DwGroupDetails)
                { 
                    //?support validate added by jlwang
                    int ll_currentRow = dw_detail.DataObject.GetRow();

                    if (ll_currentRow >= 0)
                    {
                        if (dw_detail.RowCount > 0) //(this.PBName == "dw_group_details" && RowCount > 0)
                        {
                            int? ll_rc_id = dw_detail.DataObject.GetItem<GroupDetails>(ll_currentRow).RdsUserRightsRcId;

                            if (ll_rc_id == null || ll_rc_id <= 0)
                            {
                                MessageBox.Show("A component must be specified", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                if(((Metex.Windows.DataEntityGrid)dw_detail.DataObject.Controls["grid"]).Rows[ll_currentRow].Cells["rds_user_rights_rc_id"].Visible)
                                    ((Metex.Windows.DataEntityGrid)dw_detail.DataObject.Controls["grid"]).Rows[ll_currentRow].Cells["rds_user_rights_rc_id"].Selected = true;
                                return FAILURE;
                            }
                            int? ll_region_id = dw_detail.DataObject.GetItem<GroupDetails>(ll_currentRow).RdsUserRightsRegionId;

                            if (ll_region_id == null || ll_region_id < 0)
                            {
                                MessageBox.Show("A region must be selected", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                //dw_detail.DataObject.GetControlByName("rds_user_rights_region_id").Focus();
                                return FAILURE;
                            }
                        }
                    }
                    for (int i = 0; i < dw_detail.RowCount; i++)
                    {
                        dw_detail.DataObject.GetItem<GroupDetails>(i).UgId = dw_header.DataObject.GetItem<GroupHeader>(0).UgId;
                    }
                }
                if (dw_detail.DataObject is DwUserDetails)
                {
                    dw_detail.DataObject.GetItem<UserDetails>(0).RdsUserIdUiId = MainMdiService.GetNextSequence("rdsUser");
                    dw_detail.DataObject.GetItem<UserDetails>(0).RdsUserUId = dw_detail.DataObject.GetItem<UserDetails>(0).RdsUserIdUiId;
                }
                if (this.pfc_validation(dw_detail.DataObject) == SUCCESS)
                {
                    dw_detail.DataObject.Save();
                }
                else
                {
                    return FAILURE;
                }
            }
            //  TJB  SR4598  April 2005
            //  Save the alternate regions if changed
            li_rc = 1;
            if (StaticFunctions.IsDirty(dw_user_region))
            {
                li_rc = of_save_altregions();
            }

            //  Saves the header dw if modified
            if (StaticFunctions.IsDirty(dw_contract_type))
            {
                dw_contract_type_save();
            }
            if (li_rc < 0)
            {
                return li_rc;
            }
            return li_rc;
        }

        private DataUserControl DwGroupHeader()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void dw_contract_type_save()
        {
            int? ui_id = id;
            int? ct_key;
            string ErrorMessage = "";
            if (!MainMdiService.DeleteRdsUserContractType(ui_id, ref ErrorMessage))
            {
                MessageBox.Show("Unable to create contract types for the user.  \nError Text:" + ErrorMessage, "Database Error");
            }
            int rowcount = dw_contract_type.RowCount;
            for (int i = 0; i < rowcount; i++)
            {
                if (dw_contract_type.GetItem<ContractTypes>(i).Dummy1 == "Y")
                {
                    ct_key = dw_contract_type.GetItem<ContractTypes>(i).ContractTypeCtKey;
                    if (!MainMdiService.InsertRdsUserContractType(ct_key, ui_id, ref ErrorMessage))
                    {
                        MessageBox.Show("Unable to create contract types for the user.  \nError Text:" + ErrorMessage, "Database Error");
                        break;
                    }
                }
                dw_contract_type.GetItem<ContractTypes>(i).MarkClean();
            }


            //            //Remove all before inserting
            //Delete rds_user_contract_type
            //Where ui_id = :ll_ui_id
            //Using SQLCA;

            //IF SQLCA.SQLCODE <> 0 THEN
            //    MessageBox("Database Error",  &
            //                "Unable to create contract types for the user.  " + &
            //                "~n~nError Code: " + String(sqlca.sqlcode)        + &
            //                "~n~nError Text: " + SQLCA.sqlerrtext)
            //    RollBack;
            //    RETURN FAILURE
            //End If

            ////If the save was successful save the contract_types selected using the ll_ui_id
            //For ll_Row = 1 to ll_RowCount

            //    ll_ct_key = dw_contract_type.GetItemNumber(ll_row,"contract_type_ct_key")
            //    ls_Selected	= dw_contract_type.GetItemString(ll_Row,"dummy1")

            //    If ls_Selected = 'Y' Then
            //        INSERT INTO rds_user_contract_type ("ct_key", "ui_id")
            //        VALUES (:ll_ct_key, :ll_ui_id)
            //        USING SQLCA;

            //        IF SQLCA.SQLCODE <> 0 THEN
            //            MessageBox("Database Error",  &
            //                        "Unable to create contract types for the user.  " + &
            //                        "~n~nError Code: " + String(sqlca.sqlcode)        + &
            //                        "~n~nError Text: " + SQLCA.sqlerrtext)
            //            RollBack;
            //            RETURN FAILURE
            //        End If
            //    End If
            //Next
        }

        public int of_get_altregions(int al_id)
        {
            //TJB  SR4598  April 2005
            //Set selected region check boxes
            int ll_row;
            int ll_rows;
            int ll_regionId;
            int ll_ui_id;
            int? li_alt;

            int SQLCode = 0;
            string SQLErrText = string.Empty;

            ll_ui_id = dw_user_details.GetValue<int>(0, "UiId");
            ll_rows = dw_user_region.RowCount;
            for (ll_row = 0; ll_row < dw_user_region.RowCount; ll_row++)
            {
                ll_regionId = dw_user_region.GetValue<int>(ll_row, "RegionId");
                li_alt = 0;
                /*   select 1 into :li_alt  from rds_user_region  where u_id= :ll_ui_id  and region_id = :ll_regionId;*/
                if (!MainMdiService.CheckUserExisting(ll_ui_id, ll_regionId, ref li_alt))
                {
                    MessageBox.Show("Database Error", "Unable to query rds_user_region table.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
                    return -(1);
                }
                if (li_alt == null)
                {
                    li_alt = 0;
                }
                dw_user_region.SetValue(ll_row, "SelInd", li_alt);
                dw_user_region.GetItem<UserRegion>(ll_row).MarkAsOld();
                //dw_user_region.SetItemStatus(ll_row, 0, primary!, notmodified!);
            }
            return 0;
        }

        public int of_save_altregions()
        {
            //  TJB  SR4598  April 2005
            //  Update the rds_user_region table
            int ll_row = 0;
            int ll_rows = 0;
            int ll_regionId = 0;
            int ll_ui_id = 0;
            int li_alt = 0;

            int SQLCode = 0;
            string SQLErrText = string.Empty;

            ll_ui_id = dw_user_details.GetValue<int>(0, "UiId");
            /*  delete from rds_user_region  where u_id = :ll_ui_id;*/
            if (!MainMdiService.DeleteUserRegion(ll_ui_id))
            {
                MessageBox.Show("Unable to clear rds_user_region table for user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                // rollback;
                return -(1);
            }
            //  commit;

            //DataSet ds = new DataSet();
            //ds.Tables.Add(dw_user_region.Table.Copy());

            List<int[]> useRegionList = new List<int[]>();
            for (ll_row = 0; ll_row < dw_user_region.RowCount; ll_row++)
            {
                UserRegion ur = dw_user_region.GetItem<UserRegion>(ll_row);
                ll_regionId = ur.RegionId.GetValueOrDefault();
                li_alt = ur.SelInd.GetValueOrDefault();
                if (ur.SelInd == 1)
                {
                    int[] iList = new int[2];
                    iList[0] = ll_regionId;
                    iList[1] = li_alt;
                    useRegionList.Add(iList);
                    /* insert into rds_user_region (u_id,region_id ) values(:ll_ui_id, :ll_regionId );*/
                    //if (SQLCode != 0 && SQLCode != 100) 
                    //{
                    //    MessageBox.Show("Database Error", "Unable to update rds_user_region table.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
                    //    //rollback;
                    //    return -(1);
                    //}
                    //ur.MarkAsOld();
                    //dw_user_region.SetItemStatus(ll_row, 0, primary, notmodified);
                    if (!MainMdiService.InsertUserRegionList(ll_ui_id, ll_regionId))
                    {
                        MessageBox.Show("Unable to update rds_user_region table.", "Database Error");

                        return -1;
                    }
                    
                    ur.MarkAsOld();                  

                }
                //else
                //{
                //    if (!MainMdiService.UpdateUserRegionList(ll_regionId ,ll_ui_id))
                //    {
                //        MessageBox.Show("Unable to update rds_user_region table.", "Database Error");
                //    }
                //}
            }
            //if (!MainMdiService.InsertUserRegionList(useRegionList.ToArray()))
            //{
            //    MessageBox.Show("Unable to update rds_user_region table.","Database Error");
            //}
            //else
            //{
            //    for (ll_row = 0; ll_row < dw_user_region.RowCount; ll_row++)
            //    {
            //        UserRegion ur = dw_user_region.GetItem<UserRegion>(ll_row);
            //        if (ur.SelInd == 1)
            //        {
            //            ur.MarkAsOld();
            //        }
            //    }
            //}

            //dw_user_region.Table.Clear();
            //for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
            //{
            //    DataRow drow = ds.Tables[0].Rows[i];
            //    dw_user_region.Table.ImportRow(drow);
            //}
            //commit;
            return 0;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// 
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

        public virtual void dw_user_region_losefocus(object sender, EventArgs e)
        {
            //base.losefocus();
            dw_user_region.AcceptText();
        }

        private void dw_detail_constructor()
        {
        }

        private void dw_detail_ue_validate(int al_row)
        {
            // if create modify or delete have been check, check read.
            if (dw_detail.DataObject is DwGroupDetails)
            {
                if (dw_detail.DataObject.GetItem<GroupDetails>(al_row).RdsUserRightsRurCreate == "Y" ||
                    dw_detail.DataObject.GetItem<GroupDetails>(al_row).RdsUserRightsRurModify == "Y" ||
                    dw_detail.DataObject.GetItem<GroupDetails>(al_row).RdsUserRightsRurDelete == "Y")
                {
                    dw_detail.DataObject.GetItem<GroupDetails>(al_row).RdsUserRightsRurRead = "Y";
                    (((System.Windows.Forms.DataGridViewCheckBoxCell)((Metex.Windows.DataEntityGrid)dw_detail.DataObject.Controls["grid"]).Rows[al_row].Cells[5])).Value = "Y";
                }
            }
            //  TJB  Oct 2005  NPAD2 Address schema changes
            //  If the user creates a new road suffix, the rs_id won't be defined.
            //  Look up the current max ( rs_id) and assign the next value to the new record.
            //  Do it by scanning the datawindow rather than a "select max ( rs_id)"
            //  because the user may add several suffixes before saving them.
            //  The alternative is to make the rs_id column an identity column
            //  but that may conflict with the assignments made in NPAD.
            if (dw_detail.DataObject is DRoadSuffix)
            {
                int? ll_rs_id;
                int? ll_rs_max;
                int ll_row;
                int ll_rows;
                string ls_rs_id;
                ll_rs_id = dw_detail.DataObject.GetItem<RoadSuffix>(al_row).RsId;
                if (ll_rs_id == null || ll_rs_id <= 0)
                {
                    ll_rs_max = 0;
                    ll_rows = dw_detail.DataObject.RowCount;
                    for (ll_row = 0; ll_row < ll_rows; ll_row++)
                    {
                        ll_rs_id = dw_detail.DataObject.GetItem<RoadSuffix>(ll_row).RsId;
                        if (ll_rs_id > ll_rs_max)
                        {
                            ll_rs_max = ll_rs_id;
                        }
                    }
                    if (ll_rs_max > 0)
                    {
                        ll_rs_max = ll_rs_max + 1;
                        dw_detail.DataObject.GetItem<RoadSuffix>(al_row).RsId = ll_rs_max;
                    }
                    else
                    {
                        MessageBox.Show(this, "Error determining new road suffix ID " + "(max(rs_id)=" + ll_rs_max + ')', "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void dw_detail_clicked(int row, DataColumn dwo)
        {
            string ls_component_name;
            int ll_component_id;
            int ll_Ctr;
            int ll_Row;
            string ls_Create;
            string ls_Read;
            string ls_Modify;
            string ls_Delete;
            ll_Row = row;
            NZPostOffice.RDSAdmin.Structures.StrInfo lstr_info;
            if (dw_detail.DataObject is DwGroupDetails)
            {
                /*?if (dwo.name == "component_list")
                {
                } */
            }
            if (row > 0)
            {
                if (dw_detail.DataObject is DOutletList)
                {
                    dw_detail.SelectRow(0, false);
                    dw_detail.SelectRow(row, true);
                }
            }
        }

        private void dw_detail_losefocus(object sender, EventArgs e)
        {
            //!base.losefocus();
            dw_detail.DataObject.AcceptText();
        }

        //public override int pfc_preupdate()
        //{
        //    base.pfc_preupdate();
        //    DateTime ldt_current;
        //    int? ll_rur_id;
        //    int? ll_ug_id;
        //    int? ll_u_id;
        //    int ll_rc_id;
        //    int ll_currentRow = 0;
        //    string ls_rc_name;
        //    int SQLCode=0;
        //    string SQLErrText=string.Empty;

        //    //  Setup the identity column
        //    if (this.PBName == "dw_group_details")
        //    {
        //        for (ll_currentRow = 1; ll_currentRow <= this.RowCount; ll_currentRow++)
        //        {
        //            ll_rur_id = this.GetItemInt(ll_currentRow, "rur_id");
        //            if (ll_rur_id == null || ll_rur_id <= 0)
        //            {
        //                // 			this.SetItem ( ll_currentRow, "rur_id", gnv_app.of_Get_NextSequence ( "rdsUserRights"))
        //                ll_rur_id = StaticFunctions.GetNextSequence("rdsUserRights");
        //                this.SetItem(ll_currentRow, "rur_id", ll_rur_id);
        //                ll_ug_id = window.dw_header.GetItemInt(1, "ug_id");
        //                this.SetItem(ll_currentRow, "ug_id", ll_ug_id);
        //            }
        //            //  TJB  SR4642  3 Nov 2004
        //            //  When a new row is added, the rds_component_rc_id and rds_component_rc_name
        //            //  fields aren't populated and the save failed.  Added this code to fix.
        //            ll_rc_id = this.GetItemInt(ll_currentRow, "rds_component_rc_id").Value ;
        //            if (ll_rc_id == null || ll_rc_id <= 0)
        //            {
        //                ll_rc_id = this.GetItemInt(ll_currentRow, "rds_user_rights_rc_id").Value ;
        //                if (!(ll_rc_id == null || ll_rc_id <= 0))
        //                {
        //                    this.SetItem(ll_currentRow, "rds_component_rc_id", ll_rc_id);
        //                    ls_rc_name = this.GetItemString(ll_currentRow, "rds_component_rc_name");
        //                    if (ls_rc_name == null || ls_rc_name == "")
        //                    {
        //                        /*select rc_name into :ls_rc_name from rds_component where rc_id = :ll_rc_id;*/
        //                        StaticVariables.ServiceInterface.WMainMdi_DwDetail_pfc_preupdate_1( ref ls_rc_name, ref ll_rc_id,ref SQLErrText,ref SQLCode);
        //                        this.SetItem(ll_currentRow, "rds_component_rc_name", ls_rc_name);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else if (this.PBName == "dw_user_details")
        //    {
        //        ll_currentRow = this.GetRow();
        //        ll_u_id = this.GetItemInt(ll_currentRow, "rds_user_u_id");
        //        if (ll_u_id == null || ll_u_id <= 0)
        //        {
        //            this.SetItem(ll_currentRow, "rds_user_u_id", StaticFunctions.GetNextSequence("rdsUser"));
        //        }
        //    }
        //    this.AcceptText();
        //    return 1;
        //}

        public int pfc_update(/*?bool ab_accepttext, bool ab_resetflag*/)
        {
            //?base.pfc_update(ab_accepttext, ab_resetflag);
            //?int ancestorreturnvalue = base.pfc_update(ab_accepttext, ab_resetflag);
            int ll_currentRow;
            int? ll_u_id = 0;
            int? ll_ui_id = 0;
            int ll_RowCount = 0;
            int ll_Row =0;
            int? ll_ct_key = 0;
            string ls_ui_userid = string.Empty;
            string ls_ui_password = string.Empty;
            string ls_Selected;
            string ls_encrypted = string.Empty;
            string ls_created_by = string.Empty;

            int SQLCode = 0;
            string SQLErrText = string.Empty;
            int ret = -1;

            //  If this is not user details, no need to proceed
            if (dw_detail.DataObject is DwGroupDetails)
            {
                return 1;
            }
            //  Only proceed if a user is inserted successfully first

            //!ls_created_by = gnv_app.of_getUserId(); //moved from line:1183
            DataSet ds = new DataSet();
            //?ds.Tables.Add(window.dw_contract_type.Table.Copy());

            if (/*?ancestorreturnvalue == SUCCESS && */dw_detail.DataObject is DwUserDetails)
            {
                    ll_currentRow = dw_detail.DataObject.GetRow();

                    //ll_ui_id = dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiId;
                    ll_ui_id = rds_user_id_ui_id;
                    //  Check to see if a userid has been created for this user or not
                    if (ll_ui_id == null || ll_ui_id <= 0)
                    {
                        //ll_ui_id = gnv_app.of_Get_NextSequence("rdsUserId");
                        ll_ui_id  = MainMdiService.GetNextSequence("rdsUserId");                     

                        dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiId = ll_ui_id;
                        // Also retrieve the password, user and user id entered
                        ls_ui_userid = dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiUserid;
                        ls_ui_password = dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiPassword;//"rds_user_id_ui_password").Trim().ToUpper();
                        ll_u_id = dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserUId;// "rds_user_u_id").Value;
                        // Encrypt the password before inserting new user
                        ls_encrypted = StaticFunctions.f_encrypt(ls_ui_password.ToUpper().Trim());
                        ls_created_by = StaticVariables.LoginId;// of_getUserId();


                        //INSERT INTO rds_user_id("ui_id","u_id","ui_userid","ui_password","ui_created_date","ui_created_by")
                        //VALUES  (:ll_ui_id,:ll_u_id,:ls_ui_userid,:ls_encrypted,today(*),:ls_created_by)
                        //USING SQLCA;
                        MainMdiService.InsertIntoRdsUserId(ll_ui_id, ll_u_id, ls_ui_userid, ls_encrypted, DateTime.Today, ls_created_by);
                        //if (SQLCode != 0)
                        //{
                        //    MessageBox.Show("Unable to create user id.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                        //    RollBack;
                        //    return FAILURE;
                        //}
                        // Insert into the used_password table
                        //INSERT INTO used_password("up_password", "ui_id") VALUES  (:ls_ui_password, :ll_ui_id)
                        //USING SQLCA;
                        MainMdiService.InsertIntoUsedPassword(ls_ui_password, ll_ui_id);
                        //if (SQLCode != 0)
                        //{
                        //    MessageBox.Show("Unable to create user id.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                        //    RollBack;
                        //    return FAILURE;
                        //}

                        //ret = StaticVariables.ServiceInterface.WMainMdi_DwDetail_pfc_update_1(
                        //    ref  ll_ui_id,
                        //    ref  ll_u_id,
                        //    ref  ls_ui_userid,
                        //    ref  ls_encrypted,
                        //    ref  ls_created_by,
                        //    ref  ls_ui_password,
                        //    ref  ll_RowCount,
                        //    ref  ds,
                        //    ref  ll_ct_key,
                        //    ref  SQLErrText,
                        //    ref  SQLCode);
                        //if (ret != 0)
                        //{
                        //    if (ret == 1)
                        //    {
                        //        MessageBox.Show("Unable to create user id.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                        //        return FAILURE;
                        //    }
                        //    else if (ret == 2)
                        //    {
                        //        MessageBox.Show("Unable to create user id.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                        //        return FAILURE;
                        //    }
                        //    else if (ret == 3)
                        //    {
                        //        MessageBox.Show("Unable to modify user id attributes.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                        //        return FAILURE;
                        //    }
                        //    else if (ret == 4)
                        //    {
                        //        MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                        //        return FAILURE;
                        //    }
                        //    else if (ret == 5)
                        //    {
                        //        MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                        //        return FAILURE;
                        //    }
                        //}
                    }
                    //else if (this.Table.Rows[ll_currentRow].RowState == DataRowState.Modified/*this.GetItemStatus(ll_currentRow, "rds_user_id_ui_password", primary!) == datamodified!*/)
                    else
                    {
                    //    ls_ui_password = GetItemString(ll_currentRow, "rds_user_id_ui_password");
                    //    //!ls_encrypted = gnv_app.of_encrypt(Upper(Trim(ls_ui_password)));
                        
                          ls_ui_password = dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiPassword.Trim().ToUpper();
                          ls_encrypted = StaticFunctions.f_encrypt(ls_ui_password.ToUpper().Trim());
                          dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiPassword = ls_encrypted;
                          dw_detail.DataObject.BindingSource.CurrencyManager.Refresh();

                           ls_ui_userid = dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiUserid;
                    //    //UPDATE rds_user_id set 	ui_password = :ls_encrypted Where ui_id = :ll_ui_id
                           bool update_flag = MainMdiService.UpdateUIPassword(ls_encrypted, ls_ui_userid, ll_ui_id);
                    //    //Using SQLCA;
                    //    //if (SQLCode!= 0) {
                          if(!update_flag){
                          //      MessageBox.Show( "Unable to update user password.  " + "\n\nError Code: " +SQLCode.ToString() + "\n\nError Text: " +SQLErrText,"Database Error");
                              MessageBox.Show( "Unable to update user password.  " + "\n\nError Code: " + "\n\nError Text: " +"Database Error");
                    //    //    //1RollBack;
                               return FAILURE;
                    //    //}
                          }
                    //    ////  If the password was updated add the new password to the used_password table
                    //    //INSERT INTO used_password("up_password", "ui_id")  VALUES  ( :ls_ui_password, :ll_ui_id)
                          bool insert_flag = MainMdiService.InsertIntoUsedPassword(ls_ui_password, ll_ui_id);
                    //    //USING SQLCA;
                    //    //if (SQLCode!= 0) {
                          if(!insert_flag){
                          //      MessageBox.Show( "Unable to update user password.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText,"Database Error");
                                    MessageBox.Show( "Unable to update user password.  " + "\n\nError Code: " + "\n\nError Text: " ,"Database Error");
                    //    //    //!RollBack;
                                return FAILURE;
                          }
                    }

                    //else if (this.Table.Rows[ll_currentRow].RowState == DataRowState.Modified /*!dw_detail.GetItemStatus(ll_currentRow, "rds_user_id_ui_userid", primary!) == datamodified!*/)
                    //{
                          //ls_ui_userid = GetItemString(ll_currentRow, "rds_user_id_ui_userid");
                    ls_ui_userid = dw_detail.DataObject.GetItem<UserDetails>(ll_currentRow).RdsUserIdUiUserid;

                    //    //UPDATE rds_user_id set ui_userid = :ls_ui_userid  Where ui_id = :ll_ui_id  
                    bool update_uid = MainMdiService.UpdateUIUserid(ls_ui_userid,ll_ui_id);
                    //    //Using SQLCA;
                    //    //if (SQLCode != 0)    
                   if(!update_uid)
                   {
                       MessageBox.Show("Unable to update user id.  " + "\n\nError Code: " + "\n\nError Text: ", "Database Error");
                      //? RollBack;
                       return FAILURE;
                   }
                    //    ret = StaticVariables.ServiceInterface.WMainMdi_DwDetail_pfc_update_3(
                    //        ref  ls_ui_userid,
                    //       ref  ll_ui_id,
                    //        ref  ls_ui_password,
                    //        ref  ls_created_by,
                    //        ref  ll_RowCount,
                    //        ref  ds,
                    //        ref  ll_ct_key,
                    //        ref  SQLErrText,
                    //        ref  SQLCode);
                    //    if (ret != 0)
                    //    {
                    //        if (ret == 1)
                    //        {
                    //            MessageBox.Show("Unable to update user id.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                    //            return FAILURE;
                    //        }
                    //        else if (ret == 2)
                    //        {
                    //            MessageBox.Show("Unable to modify user id attributes.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                    //            return FAILURE;
                    //        }
                    //        else if (ret == 3)
                    //        {
                    //            MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                    //            return FAILURE;
                    //        }
                    //        else if (ret == 4)
                    //        {
                    //            MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                    //            return FAILURE;
                    //        }
                    //    }
                    //}

                    //#region merged  to server 08/11/2006
                    ////ls_created_by = gnv_app.of_getUserId();
                    ////UPDATE rds_user_id set 	ui_modified_date = today(*),ui_modified_by = :ls_created_by Where ui_id = :ll_ui_id
                    ////Using SQLCA;
                        ls_created_by =StaticVariables.LoginId;
                        bool up_flag =MainMdiService.UpdateDateAndUser(ls_created_by,ll_ui_id);
                    ////if (SQLCode != 0)
                        if (!up_flag)
                        {
                    ////{
                    ////    MessageBox.Show("Unable to modify user id attributes.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                    ////    //!RollBack;
                    ////    return FAILURE;

                            MessageBox.Show("Unable to modify user id attributes.  " + "\n\nError Code: " + "\n\nError Text: " , "Database Error");
                            return FAILURE;
                    ////}
                        }
                    ////// save the contract types selected
                    ////ll_RowCount = window.dw_contract_type.RowCount;
                    ////// Remove all before inserting
                        ll_RowCount = dw_contract_type.RowCount;
                    ////Delete rds_user_contract_type Where ui_id = :ll_ui_id
                        string temp = "";
                        up_flag = MainMdiService.DeleteRdsUserContractType(ll_ui_id, ref temp);
                    ////Using SQLCA; 

                    ////if (SQLCode != 0)
                        if (!up_flag)
                        {
                    ////{
                    ////    MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                    ////    RollBack;
                    ////    return FAILURE;
                            MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + "\n\nError Text: ", "Database Error");
                            return FAILURE;
                    ////}
                        }

                    ////// If the save was successful save the contract_types selected using the ll_ui_id
                    bool ins_flag =false;
                    for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
                    {
                        //ll_ct_key = window.dw_contract_type.GetItemInt(ll_Row, "contract_type_ct_key").Value;
                        ll_ct_key = dw_contract_type.GetItem<ContractTypes>(ll_Row).ContractTypeCtKey;
                        //ls_Selected = window.dw_contract_type.GetItemString(ll_Row, "dummy1");
                        ls_Selected =dw_contract_type.GetItem<ContractTypes>(ll_Row).Dummy1;
                        if (ls_Selected == "Y")
                        {
                    ////         INSERT INTO rds_user_contract_type( "ct_key", "ui_id")  VALUES ( :ll_ct_key, :ll_ui_id)
                    ////         USING SQLCA; 
                                temp = "";
                                ins_flag = MainMdiService.InsertRdsUserContractType(ll_ct_key, ll_ui_id, ref temp);
                    ////        if (SQLCode != 0)
                                if (!ins_flag)
                                {
                    ////            MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText, "Database Error");
                    ////            RollBack;
                    ////            return FAILURE;
                                    MessageBox.Show("Unable to create contract types for the user.  " + "\n\nError Code: " + "\n\nError Text: ", "Database Error");
                                    return FAILURE;
                                 }
                            
                         }
                     }
                    //# endregion
                }
                //!Commit;
                //return ancestorreturnvalue;    
            return 1;
        }
       
        public void dw_detail_ItemChanged(object sender, EventArgs args)
        {
            //!base.itemchanged(row, dwo, data);            
            int row = dw_detail.DataObject.GetRow();
            if(row >= 0)
                dw_detail_ue_validate(row);
            //? return 1;
        }

        private void dw_contract_type_ItemChanged(object sender, EventArgs args)
        {
            if (dw_contract_type.GetItem<ContractTypes>(dw_contract_type.GetRow()).Dummy1 == "Y")
            {
                dw_contract_type.GetItem<ContractTypes>(dw_contract_type.GetRow()).Dummy1 = "N";
            }
            else
            {
                dw_contract_type.GetItem<ContractTypes>(dw_contract_type.GetRow()).Dummy1 = "Y";
            }
            if (!dw_detail.DataObject.GetItem<UserDetails>(0).IsDirty)
            {
                dw_detail.DataObject.GetItem<UserDetails>(0).MarkDirty();
            }
            dw_contract_type.AcceptText();

        }

        private void dw_user_details_lockClick(object sender, EventArgs args)
        {
            string sDeliveryDays;
            double ll_contract_id;
            int? ll_ui_id;
            ll_ui_id = dw_user_details.GetItem<UiIdDetails>(0).UiId;
            if (ll_ui_id > 0)
            {
                if (MainMdiService.UpdateRdsUserIdUILockedDate(ll_ui_id))
                {
                    this.dw_user_details.Retrieve(ll_ui_id);
                }
            }
        }

        // public override int pfc_validation()
        //    {
        //        base.pfc_validation();
        //        int ancestorreturnvalue = base.pfc_validation();
        //        int ll_currentRow = 0;
        //        int? ll_rc_id = 0;
        //        int? ll_region_id = 0;
        //        int ll_id;
        //        string ls_route_freq;
        //        string ls_group_name;
        //        string ls_group_description;
        //        string ls_name = "";
        //        string ls_user_id = "";
        //        string ls_password = "";
        //        string ls_used_password = "";
        //        int ll_count = 0;
        //        ll_currentRow = GetRow();

        //        int SQLCode = 0;
        //        string SQLErrText = string.Empty;

        //        if (ll_currentRow > 0)
        //        {
        //            if (this.PBName == "dw_group_details" && RowCount > 0)
        //            {
        //                ll_rc_id = GetItemInt(ll_currentRow, "rds_user_rights_rc_id");
        //                if (MObject.IsNull(ll_rc_id) || ll_rc_id <= 0)
        //                {
        //                    MessageBox.Show("Validation Error", "A component must be specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    // 			IF ab_focusonerror THEN 
        //                    //! dw_detail.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //                ll_region_id = GetItemInt(ll_currentRow, "rds_user_rights_region_id");
        //                if (MObject.IsNull(ll_region_id) || ll_region_id < 0)
        //                {
        //                    MessageBox.Show("Validation Error", "A region must be selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    // 			IF ab_focusonerror THEN 
        //                    this.SetColumn("rds_user_rights_region_id");
        //                    //! this.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //            }
        //            else if (PBName == "dw_user_details" && RowCount > 0)
        //            {
        //                ls_name = GetItemString(ll_currentRow, "rds_user_u_name");
        //                if (MObject.IsNull(ls_name) || ls_name == "")
        //                {
        //                    MessageBox.Show("Validation Error", "A user name must be specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    // 			IF ab_focusonerror THEN 
        //                    this.SetColumn("rds_user_u_name");
        //                    //!this.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //                //  If user name is entered or modified, need to make sure the name does not
        //                //  duplicate in the system
        //                // if (dw_detail.GetItemStatus(ll_currentRow, "rds_user_u_name", primary) == newmodified || dw_detail.GetItemStatus(ll_currentRow, "rds_user_u_name", primary) == datamodified) 
        //                if (this.Table.DefaultView[ll_currentRow - 1].Row.RowState == DataRowState.Added || this.Table.DefaultView[ll_currentRow - 1].Row.RowState == DataRowState.Modified)
        //                {
        //                    /*  SELECT	count(*) INTO :ll_count  FROM rds_user  WHERE u_name = :ls_name*/

        //                    StaticVariables.ServiceInterface.WMainMdi_DwDetail_pfc_validation_1(ref ll_count, ref ls_name, ref SQLErrText, ref SQLCode);

        //                    if (SQLCode != 0)
        //                    {
        //                        MessageBox.Show("Database Error", "Unable to validate user name.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
        //                        return FAILURE;
        //                    }
        //                    if (ll_count > 0)
        //                    {
        //                        MessageBox.Show("Validation Error", "The user name specified already exists in the database.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                        this.SetColumn("rds_user_u_name");
        //                        //!this.SetFocus();
        //                        return FAILURE;
        //                    }
        //                }
        //                ls_user_id = GetItemString(ll_currentRow, "rds_user_id_ui_userid");
        //                if (MObject.IsNull(ls_user_id) || ls_user_id == "")
        //                {
        //                    MessageBox.Show("Validation Error", "A userid must be specified");
        //                    // 			IF ab_focusonerror THEN 
        //                    this.SetColumn("rds_user_id_ui_userid");
        //                    //! this.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //                //  If user id is entered or modified, need to make sure the id does not
        //                //  duplicate in the system
        //                //  if (dw_detail.GetItemStatus(ll_currentRow, "rds_user_id_ui_userid", primary!) == newmodified! || dw_detail.GetItemStatus(ll_currentRow, "rds_user_id_ui_userid", primary!) == datamodified!) {
        //                if (this.Table.DefaultView[ll_currentRow - 1].Row.RowState == DataRowState.Added || this.Table.DefaultView[ll_currentRow - 1].Row.RowState == DataRowState.Modified)
        //                {
        //                    /*  SELECT	count(*)  INTO  :ll_count  FROM  rds_user_id  WHERE	ui_userid = :ls_user_id*/

        //                    StaticVariables.ServiceInterface.WMainMdi_DwDetail_pfc_validation_2(ref ll_count, ref ls_user_id, ref SQLErrText, ref SQLCode);

        //                    if (SQLCode != 0)
        //                    {
        //                        MessageBox.Show("Database Error", "Unable to validate user id.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
        //                        return FAILURE;
        //                    }
        //                    if (ll_count > 0)
        //                    {
        //                        MessageBox.Show("Validation Error", "The user id specified already exists in the database.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                        this.SetColumn("rds_user_id_ui_userid");
        //                        //!this.SetFocus();
        //                        return FAILURE;
        //                    }
        //                }
        //                ls_password = GetItemString(ll_currentRow, "rds_user_id_ui_password");
        //                if (MObject.IsNull(ls_password) || ls_password == "")
        //                {
        //                    MessageBox.Show("Validation Error", "A password must be specified");
        //                    // 			IF ab_focusonerror THEN 
        //                    this.SetColumn("rds_user_id_ui_password");
        //                    //! this.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //                // If the password is changed
        //                // if (dw_detail.GetItemStatus(ll_currentRow, "rds_user_id_ui_password", primary!) == datamodified!) 
        //                if (this.Table.DefaultView[ll_currentRow].Row.RowState == DataRowState.Modified)
        //                {
        //                    ll_id = GetItemInt(ll_currentRow, "rds_user_id_ui_id").Value;
        //                    // Check that the password has not already been used
        //                    /*  Select up_password  Into :ls_used_password   From used_password  Where ui_id = :ll_id  and up_password = :ls_password*/

        //                    StaticVariables.ServiceInterface.WMainMdi_DwDetail_pfc_validation_3(ref ls_used_password, ref ll_id, ref ls_password, ref SQLErrText, ref SQLCode);

        //                    if (SQLCode != 100 && SQLCode != 0)
        //                    {
        //                        MessageBox.Show("Database Error", "Unable to create user id.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
        //                    }
        //                    if (SQLCode == 0)
        //                    {
        //                        MessageBox.Show("Validation Error", "The password specified has already been used, Please select another.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                        // 				IF ab_focusonerror THEN 
        //                        this.SetColumn("rds_user_id_ui_password");
        //                        //! this.SetFocus();
        //                        // 				END IF
        //                        return FAILURE;
        //                    }
        //                }
        //                ll_region_id = GetItemInt(ll_currentRow, "rds_user_region_id");
        //                if (MObject.IsNull(ll_region_id) || ll_region_id < -(1))
        //                {
        //                    MessageBox.Show("Validation Error", "A region must be specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    // 			IF ab_focusonerror THEN 
        //                    this.SetColumn("rds_user_region_id");
        //                    //! this.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //            }
        //            else if (PBName == "d_route_freq_verbs")
        //            {
        //                ls_route_freq = GetItemString(ll_currentRow, "rfv_description");
        //                if (MObject.IsNull(ls_route_freq) || ls_route_freq == "")
        //                {
        //                    MessageBox.Show("Validation Error", "A description must be specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    // 				IF ab_focusonerror THEN 
        //                    this.SetColumn("rfv_description");
        //                    //! this.SetFocus();
        //                    // 				END IF
        //                    return FAILURE;
        //                }
        //            }
        //            if (window.dw_header.PBName == "dw_group_header" && window.dw_header.DataControl.Visible == true)
        //            {
        //                ls_group_name = window.dw_header.GetItemString(1, "ug_name");
        //                if (MObject.IsNull(ls_group_name) || ls_group_name == "")
        //                {
        //                    MessageBox.Show("Validation Error", "A group name must be specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    // 			IF ab_focusonerror THEN 
        //                    this.SetColumn("ug_name");
        //                    //! this.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //                ls_group_description = window.dw_header.GetItemString(1, "ug_description");
        //                if (MObject.IsNull(ls_group_description) || ls_group_description == "")
        //                {
        //                    MessageBox.Show("Validation Error", "A group description must be specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    // 			IF ab_focusonerror THEN 
        //                    this.SetColumn("ug_description");
        //                    //! this.SetFocus();
        //                    // 			END IF
        //                    return FAILURE;
        //                }
        //            }
        //        }
        //        return ancestorreturnvalue;
        //    }

        //    public override void constructor()
        //    {
        //        base.constructor();
        //        //!  dw_detail.of_SetSort(true);
        //        //! inv_sort.of_SetColumnHeader(true);
        //    }

        public void dw_detail_retrieveend()
        {
            //?base.retrieveend();            
            if (dw_detail.DataObject is DOutletList)
            {
                dw_detail.DataObject.InsertItem<OutletList>(0);
                dw_detail.DataObject.GetItem<OutletList>(0).OName = "<Enter New Outlet>";
                dw_detail.DataObject.GetItem<OutletList>(0).OutletId = 0;
                dw_detail.DataObject.SetCurrent(0);
            }
        }

        public virtual void ue_additem()
        {
            string ls_label = "";
            // Find out what is being added, a group or a user?
            switch (tv_1.SelectedNode.Level)
            {
                case 0:
                    ls_label = ((GroupsAndUsersLevel1)tv_1.SelectedNode.Tag).Label;
                    break;
                case 1:
                    ls_label = ((GroupsAndUsersLevel2)tv_1.SelectedNode.Tag).Label;
                    break;
                case 2:
                    ls_label = ((GroupsAndUsersLevel3)tv_1.SelectedNode.Tag).Label;
                    break;
            }
            if (ls_label == is_LABEL_GROUPS)
            {
                if (!(dw_detail.DataObject is DwGroupDetails))
                {
                    dw_detail.DataObject = new DwGroupDetails();
                }
                dw_detail.DataObject.Reset();
                dw_header.DataObject = new DwGroupHeader();
                GroupHeader header = GroupHeader.NewGroupHeader(null, StaticVariables.LoginId);
                header.MarkClean();
                dw_header.DataObject.InsertItem<GroupHeader>(0, header);
                dw_header.Visible = true;
                dw_detail.Visible = true;
                dw_header.BringToFront();
                dw_header.Focus();
            }
            else
            {
                if (!(dw_detail.DataObject is DwUserDetails))
                {
                    dw_detail.DataObject = new DwUserDetails();
                }
                dw_detail.Top = 40;
                //dw_detail.Height = 400;
                dw_user_details.Top = 500;
                dw_detail.Visible = true;
                dw_contract_type.Visible = true;
                if (dw_header.DataObject != null)
                {
                    dw_header.DataObject.Reset();
                }
                dw_detail.DataObject.Reset();
                dw_contract_type.Reset();
             // dw_detail.DataObject.InsertItem<UserDetails>(dw_detail.RowCount);
                UserDetails user = UserDetails.NewUserDetails(StaticVariables.userId);
                user.MarkClean();
                dw_detail.DataObject.InsertItem<UserDetails>(0, user);
                dw_contract_type.Retrieve(0);
                dw_contract_type.BringToFront();
                dw_detail.Focus();
            }
        }

        public virtual void ue_navigated()
        {
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int level = tv_1.SelectedNode.Level;

            int parent_id1 = 0;
            int parent_id2 = 0;
            switch (level)
            {
                case 0:
                    // ignore - maybe reset the dw
                    GroupsAndUsersLevel1 Entity1 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel1;
                    id = Entity1.Id.GetValueOrDefault();
                    dw_header.Visible = false;
                    dw_detail.Visible = false;
                    dw_contract_type.Visible = false;
                    dw_user_details.Visible = false;
                    dw_user_region.Visible = false;
                    if (dw_header.DataObject != null)
                    {
                        dw_header.DataObject.Reset();
                    }
                    if (dw_detail.DataObject != null)
                    {
                        dw_detail.DataObject.Reset();
                    }
                    dw_contract_type.Reset();
                    dw_user_details.Reset();
                    dw_user_region.Reset();
                    dw_user_region.Reset();
                    // Disable add for system tables
                    if (id == 3)
                    {
                        //m_SecTvs = new MSecurityTvs();
                        m_SecTvs.m_add.Visible = false;
                    }
                    dw_detail.Top = dw_header.Top + dw_header.Height;
                    break;
                case 1:
                    // either a group or a user
                    GroupsAndUsersLevel2 Entity2 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel2;
                    id = Entity2.Id.GetValueOrDefault();
                    parent_id1 = Entity2.ParentId1.GetValueOrDefault();
                    if (parent_id1 == 1)
                    {
                        // Store the group id for when we delete components
                        //! il_group_id = id;
                        // the parent is the group string
                        // Only load the dataobject if it is not the correct one
                        if (!(dw_detail.DataObject is DwGroupDetails))
                        {
                            dw_detail.DataObject = new DwGroupDetails();
                        }
                        if (!(dw_header.DataObject is DwGroupHeader))
                        {
                            dw_header.DataObject = new DwGroupHeader();
                        }
                        dw_header.Retrieve(new object[] { id });
                        dw_detail.Retrieve(new object[] { id });
                        dw_detail.DataObject.SortString = "rds_component_rc_description ASC";
                        dw_detail.DataObject.Sort<GroupDetails>();
                        if (dw_detail.RowCount == 0)
                        {
                            dw_detail.DataObject.InsertItem<GroupDetails>(dw_detail.RowCount);
                            dw_detail.DataObject.GetItem<GroupDetails>(0).MarkClean();
                        }
                        dw_header.Visible = true;
                        dw_detail.Visible = true;

                        dw_contract_type.Visible = false;
                        dw_user_details.Visible = false;
                        dw_user_region.Visible = false;

                        dw_header.BringToFront();
                        dw_detail.BringToFront();
                        this.dw_header.Top = 50;
                        dw_detail.Top = dw_header.Top + dw_header.Height - 10;
                    }
                    else if (parent_id1 == 2)
                    {
                        // the parent is the user string
                        // Only load the dataobject if it is not the correct one
                        if (!(dw_detail.DataObject is DwUserDetails))
                        {
                            dw_detail.DataObject = new DwUserDetails();
                        }
                        dw_detail.Top = 40;
                        dw_user_details.Top = 215;
                        dw_user_details.Retrieve(id);
                        dw_contract_type.Retrieve(id);
                        dw_detail.Retrieve(new object[] { id });
                        dw_header.Visible = false;
                        dw_detail.Visible = true;
                        dw_contract_type.Visible = true;
                        dw_user_details.Visible = true;
                        dw_contract_type.BringToFront();
                        dw_user_details.BringToFront();
                        //  TJB  SR4598  April 2005
                        //  If the user has a default region  ( isn't a 'national' user)
                        //  display the alternate regions list.
                        int? ll_regionId = null;
                        if(dw_detail.DataObject.RowCount > 0)
                            ll_regionId = dw_detail.DataObject.GetItem<UserDetails>(0).RdsUserRegionId;
                        if (ll_regionId == null || ll_regionId <= 0)
                        {
                            dw_user_region.Visible = false;
                        }
                        else
                        {
                            //?dw_user_region.Retrieve(id);
                            dw_user_region.Retrieve(Entity2.Account.GetValueOrDefault());
                            of_get_altregions(id);
                            dw_user_region.Top = 277;
                            dw_user_region.Visible = true;
                            dw_user_region.BringToFront();
                        }
                        // System tables 
                    }
                    else if (parent_id1 == 3)
                    {
                        dw_detail.Top = 80;
                        dw_user_region.Visible = false;
                        if (id == 1)
                        {
                            dw_header.Visible = false;
                            dw_detail.Visible = false;
                            dw_contract_type.Visible = false;
                            dw_user_details.Visible = false;
                        }
                        else
                        {
                            string PBName = of_get_dataobject(id);
                            this.Cursor = Cursors.WaitCursor;
                            dw_detail.SetDataObject("NZPostOffice.RDSAdmin.DataControls", Constants.ApplicationVersion, /*"NZPostOffice.RDSAdmin.DataControls.Security." + */StaticFunctions.GetPBName(PBName));
                            dw_detail.Retrieve(new object[] { });
                            //if (dw_detail.DataObject is DNpadParameters)
                            //{
                            //    //dw_detail.DataObject.GetItem<NpadParameters>(0).NpadUserid;
                            //    DataUserControl dwChild;
                            //    dwChild = new DDddwUsername();
                            //    dwChild.BindingSource.DataSource = ((Metex.Windows.DataGridViewEntityComboColumn)(((Metex.Windows.DataEntityGrid)(dw_detail.DataObject.GetControlByName("grid"))).Columns["npad_userid"])).DataSource;
                            //}
                            dw_header.Visible = false;
                            dw_detail.Visible = true;
                            dw_contract_type.Visible = false;
                            dw_user_details.Visible = false;
                            this.Cursor = Cursors.Arrow;
                        }
                    }
                    break;
                case 2:
                    // memberships
                    GroupsAndUsersLevel3 Entity3 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel3;
                    id = Entity3.Id.GetValueOrDefault();
                    parent_id1 = Entity3.ParentId1.GetValueOrDefault();
                    parent_id2 = Entity3.ParentId2.GetValueOrDefault();
                    if (parent_id2 == 1)
                    {
                        // we are looking at user id ( ll_id) who is a member of group ( ll_Parent_Id1)
                        // Only load the dataobject if it is not the correct one
                        if (!(dw_detail.DataObject is DwUserDetails))
                        {
                            dw_detail.DataObject = new DwUserDetails();
                        }
                        // parent.inv_resize.of_UnRegister ( dw_detail)
                        dw_detail.Top = 40;
                        dw_user_details.Retrieve(id);
                        dw_contract_type.Retrieve(id);
                        dw_contract_type.SortString = "contract_type_contract_type ASC";
                        dw_contract_type.Sort<ContractTypes>();
                        dw_detail.Retrieve(new object[] { id });
                        dw_header.Visible = false;
                        dw_user_region.Visible = false;
                        dw_detail.Visible = true;
                        dw_contract_type.Visible = true;
                        dw_user_details.Visible = true;
                        dw_contract_type.BringToFront();
                        dw_user_details.BringToFront();
                    }
                    else if (parent_id2 == 2)
                    {
                        // we are looking at group ( ll_id) who is assigned to user  ( ll_Parent_Id1)
                        // Only load the dataobject if it is not the correct one
                        if (!(dw_detail.DataObject is DwGroupDetails))
                        {
                            dw_detail.DataObject = new DwGroupDetails();
                        }
                        if (!(dw_header.DataObject is DwGroupHeader))
                        {
                            dw_header.DataObject = new DwGroupHeader();
                        }
                        dw_header.Retrieve(new object[] { id });
                        dw_detail.Retrieve(new object[] { id });
                        //dw_detail.DataObject.SortString = "rds_component_rc_description ASC";
                        //dw_detail.DataObject.Sort<GroupDetails>();
                        if (dw_detail.RowCount == 0)
                        {
                            dw_detail.DataObject.InsertItem<GroupDetails>(0);
                            dw_detail.DataObject.GetItem<GroupDetails>(0).MarkClean();
                        }
                        dw_header.Top = 40;
                        dw_header.Visible = true;
                        dw_detail.Visible = true;
                        dw_contract_type.Visible = false;
                        dw_detail.Top = dw_header.Top + dw_header.Height;
                        dw_header.BringToFront();
                        dw_detail.BringToFront();
                    }
                    else if (parent_id2 == 3)
                    {
                        if (!(dw_detail.DataObject is DOutletList))
                        {
                            dw_detail.DataObject = new DOutletList();
                        }
                        if (!(dw_header.DataObject is DRegion))
                        {
                            dw_header.DataObject = new DRegion();
                        }
                        dw_header.Retrieve(new object[] { id });
                        dw_detail.Retrieve(new object[] { id });
                        dw_detail_retrieveend();
                        //  save the region_id
                        il_region_id = id;
                        dw_header.Top = 40;
                        dw_header.Visible = true;
                        dw_detail.Visible = true;
                        dw_detail.Top = dw_header.Top + dw_header.Height;
                        dw_detail.BringToFront();
                        dw_header.BringToFront();
                        dw_contract_type.Visible = false;
                    }
                    break;
            }
            return;
        }

        public virtual void pfc_deleteitem()
        {
            //!NDs l_ds;
            string ls_label = string.Empty;
            int ll_group_id;
            int ll_id = 0;
            int ll_account_id = 0;
            int ll_level = 0;
            int parent_id1 = 0;
            int parent_id2 = 0;
            int ll_return_result = FAILURE;
            int ll_row = 0;
            /*int*/
            DialogResult li_response;
            int li_YES = 1;
            int li_NO = 2;
            int ll_parent_handle;
            TreeNode parentNode = tv_1.SelectedNode.Parent;

            // Gather info on the item which is going to be deleted
            ll_level = tv_1.SelectedNode.Level + 1;
            ls_label = tv_1.SelectedNode.Text;
            /*
            ls_label = tv_1.of_get_label(il_rightclicked);
            ll_id = tv_1.of_get_id(il_rightclicked);
            ll_account_id = tv_1.of_get_account_id(il_rightclicked);
            parent_id1 = tv_1.of_get_parent_id1(il_rightclicked);
            parent_id2 = tv_1.of_get_parent_id2(il_rightclicked);
            */

            // Trying to delete from level 2
            if (ll_level == 2)
            {
                // if the parent_id1 = 1, you are deleting groups
                //   if the parent_id1 = 2, you are deleting users
                GroupsAndUsersLevel2 Entity2 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel2;
                ll_id = Entity2.Id.GetValueOrDefault();
                parent_id1 = Entity2.ParentId1.GetValueOrDefault();
                ll_account_id = Entity2.Account.GetValueOrDefault();
                if (parent_id1 == 1)
                {
                    li_response = MessageBox.Show("Are you sure you want to delete the entire " + ls_label + " group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (li_response == DialogResult.Yes)
                    {
                        ll_return_result = of_deletegroup(ll_id);
                    }
                }
                else
                {
                    li_response = MessageBox.Show("Are you sure you want to delete the user, " + ls_label + '?', "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (li_response == DialogResult.Yes)
                    {
                        ll_return_result = of_deleteuser(ll_account_id);
                    }
                }
            }
            // Trying to delete from level 3
            if (ll_level == 3)
            {
                GroupsAndUsersLevel3 Entity3 = tv_1.SelectedNode.Tag as GroupsAndUsersLevel3;
                ll_id = Entity3.Id.GetValueOrDefault();
                parent_id1 = Entity3.ParentId1.GetValueOrDefault();
                parent_id2 = Entity3.ParentId2.GetValueOrDefault();
                // if the parent_id2 = 1 then
                //  	you are deleting a user from a group
                // 		parent_id1 = group_id
                // 		id = user_id
                // 
                // if the parent_id2 = 2 then 
                // 		you are deleting a group from a user
                // 		parent_id1 = user_id
                // 		id = group_id
                // 
                //!tv_1.inv_levelsource.of_getdatasource(2, l_ds);
                if (parent_id2 == 1)
                {
                    li_response = MessageBox.Show("Are you sure you want to remove " + ls_label + " from this group?", "Remove User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (li_response == DialogResult.Yes)
                    {
                        ll_return_result = of_removeusergroup(parent_id1, ll_id);
                        if (ll_return_result == SUCCESS)
                        {
                            //  Need to find and refresh the User branch under the Users folder  ( ui_id = ll_id)
                            //ll_parent_handle = FindItem(roottreeitem!, 0);
                            //ll_parent_handle = FindItem(nexttreeitem!, ll_parent_handle);
                            //ll_row = inv_base.of_FindItem("label", ls_label, ll_parent_handle, 2);
                            //if (ll_row > 0)
                            //{
                            //    of_refreshbranch(ll_row);
                            //}
                            RefreshNode(parentNode);
                        }
                    }
                }
                else
                {
                    li_response = MessageBox.Show("Are you sure you want to remove the user from the " + ls_label + " group?", "Remove Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (li_response == DialogResult.Yes)
                    {
                        ll_return_result = of_removeusergroup(ll_id, parent_id1);
                        if (ll_return_result == SUCCESS)
                        {
                            //  Need to find and refresh the Group branch under the Group folder  ( group_id = ll_id)
                            //ll_parent_handle = FindItem(roottreeitem!, 0);
                            //ll_row = inv_base.of_FindItem("label", ls_label, ll_parent_handle, 2);
                            //if (ll_row > 0)
                            //{
                            //    of_refreshbranch(ll_row);
                            //}
                            RefreshNode(parentNode);
                        }
                    }
                }
            }
            if (ll_return_result == SUCCESS)
            {
                //!return base.tv_1_pfc_deleteitem();
                RefreshNode(parentNode);
                return;
            }
            else
            {
                return;//! ll_return_result;
            }
        }

        public virtual void selectionchanging(TreeViewCancelEventArgs e)
        {
            //base.selectionchanging();
            int li_retain_focus = 1;
            int li_LOOSE_FOCUS = 0;
            int li_rc = 100;
            int li_return_result = 0;//! ancestorreturnvalue;
            //  TJB SR4642 1 Nov 2004
            //  Added if condition around save.
            //  Prevents confirmation messagebox re user detail changes
            //  when looking at/changing outlets.
            if (!(dw_detail.DataObject is DOutletList))
            {
                li_rc = of_save();
            }
            if (li_rc < 0)
            {
                li_return_result = li_retain_focus;
            }
            else if (li_rc == 1)
            {
                //!of_refreshbranch(oldhandle);
            }
            return;
        }

        public virtual void itemcollapsing()
        {
            /*! base.itemcollapsing();
             TreeViewItem tvi_temp;
             GetItem(Handle, tvi_temp);
             if (tvi_temp.Level == 1)
             {
                 tvi_temp.SelectedPictureIndex = 1;
                 tvi_temp.PictureIndex = 1;
                 SetItem(Handle, tvi_temp);
             }*/
        }

        public virtual void itemexpanding()
        {
            /*! base.itemexpanding();
             TreeViewItem tvi_temp;
             // Get all the info from the tree
             GetItem(Handle, tvi_temp);
             if (tvi_temp.Level == 1)
             {
                 tvi_temp.SelectedPictureIndex = 4;
                 tvi_temp.PictureIndex = 4;
                 SetItem(Handle, tvi_temp);
             }*/
        }

        public virtual void pfc_preinsertitem()
        {
            /*! base.pfc_preinsertitem();
             if (al_parent == 3)
             {
                 if (ads_obj.GetItemNumber(al_row, "id") != 1)
                 {
                     atvi_item.Children = false;
                 }
             }*/
        }

        //protected class DwHeader : URadDW
        //{
        //    WMainMdi window;

        //    public DwHeader(DataControlPanel dcp)
        //        : base(dcp)
        //    {
        //        window = dcp.FindForm() as WMainMdi;
        //    }
        //    public override void constructor()
        //    {
        //        base.constructor();
        //        //! dw_header.SetTransObject(sqlca);
        //    }

        //    public override int pfc_preupdate()
        //    {
        //        base.pfc_preupdate();
        //        int ancestorreturnvalue = base.pfc_preupdate();
        //        DateTime ldt_current = DateTime.MaxValue;
        //        int? ll_group_id;

        //        int SQLCode = 0;
        //        string SQLErrText = string.Empty;

        //        //  Setup the Created_By and Created_Date column as well as the identity column
        //        if (this.PBName == "dw_group_header")
        //        {
        //            /*SELECT getDate()  INTO :ldt_current  FROM dummy;*/
        //            StaticVariables.ServiceInterface.WMainMdi_DwHeader_pfc_preupdate_1(ref ldt_current, ref SQLErrText, ref SQLCode);

        //            ll_group_id = GetItemInt(1, "ug_id");
        //            if (MObject.IsNull(ll_group_id) || ll_group_id <= 0)
        //            {
        //                this.SetItem(1, "ug_created_date", ldt_current);
        //                //!  this.SetItem(1, "ug_created_by", gnv_app.of_GetUserId());
        //                //!  this.SetItem(1, "ug_id", gnv_app.of_Get_NextSequence("rdsUserGroup"));
        //            }
        //            this.SetItem(1, "ug_modified_date", ldt_current);
        //            //!  this.SetItem(1, "ug_modified_by", gnv_app.of_GetUserId());
        //            this.AcceptText();
        //        }
        //        return ancestorreturnvalue;
        //    }

        //    public virtual void losefocus(object sender, EventArgs e)
        //    {
        //        //!base.losefocus();
        //        this.AcceptText();
        //    }

        //    public virtual void pfc_prermbmenu()
        //    {
        //        /*! base.pfc_prermbmenu();
        //         MRdsDw m_SecDw;
        //         // We create our own rmb menu inherited from m_tvs
        //         m_SecDw = new MRdsDw();
        //         m_SecDw.m_table.m_delete.Visible = false;
        //         m_SecDw.m_table.m_Insert.Visible = false;
        //         if (dw_header.DataObject == "dw_group_header")
        //         {
        //             m_SecDw.m_table.m_insert.Visible = false;
        //             m_SecDw.m_table.m_delete.Visible = false;
        //         }
        //         // Assign our own menu 
        //         am_dw = m_SecDw;
        //         // Let ancestor do its normal processing
        //         base.dw_header_pfc_prermbmenu(am_dw);*/
        //    }

        public virtual int pfc_validation(DataUserControl adw)
        {
            //  base.pfc_validation();
            string ls_ug_id;
            int ll_c = SUCCESS;
            int ll_count = 0;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            // pfc_u_dw.pfc_validation
            if (adw is DNpadParameters)
            {
                for (int i = 0; i < adw.RowCount; i++)
                {
                    if (adw.GetItem<NpadParameters>(i).IsNew && adw.GetItem<NpadParameters>(i).NpadEnabled == null)
                    {
                        MessageBox.Show("Required value missing for npad_enabled on row "  + (i + 1) + ".  Please enter a value.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ll_c = FAILURE;
                        break;
                    }
                }
            }
            // if (this.PBName == "dw_group_header")
            if (adw is DwGroupHeader)
            {
                // ls_ug_id = this.GetItemString(1, "ug_name");
                ls_ug_id = dw_header.GetValue<string>(0, "ug_name");
                if (ls_ug_id == null)
                {
                    //  MessageBox("Validation Error", "A group name must be specified.", exclamation);
                    MessageBox.Show( "A group name must be specified.", "Validation Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    // this.SetColumn("ug_name");
                    dw_header.DataObject.GetControlByName("ug_name").Focus();
                    //this.SetFocus();
                    dw_header.Focus();
                    ll_c = FAILURE;
                }
                //////  If user group is entered or modified, need to make sure the name does not
                //////  duplicate in the system
                ////// if (dw_header.GetItemStatus(1, "ug_name", primary) == newmodified || dw_header.GetItemStatus(1, "ug_name", primary) == datamodified)
                ////// !if (dw_header.DataObject.GetItem<GroupHeader>(0).IsNew || dw_header.DataObject.GetItem<GroupHeader>(0).IsDirty)
                //////! {
                /////* SELECT count(*)  INTO :ll_count  FROM rds_user_group  WHERE ug_name = :ls_ug_id*/
                ////if (!MainMdiService.GetRdsUserGroupDataObject(ls_ug_id, ref ll_count))
                ////{
                ////    MessageBox.Show("Database Error", "Unable to validate group name.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
                ////    ll_c = FAILURE;
                ////}
                ////if (ll_count > 0)
                ////{
                ////    // ls_ug_id = this.GetItemString(1, "ug_name");
                ////    ls_ug_id = dw_header.GetValue<string>(0, "ug_name");
                ////    if (ls_ug_id == null)
                ////    {
                ////        //  MessageBox("Validation Error", "A group name must be specified.", exclamation);
                ////        MessageBox.Show("Validation Error", "A group name must be specified.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ////        // this.SetColumn("ug_name");
                ////        dw_header.DataObject.GetControlByName("ug_name").Focus();
                ////        //this.SetFocus();
                ////        dw_header.Focus();
                ////        ll_c = FAILURE;
                ////    }
                ////}
                    //  If user group is entered or modified, need to make sure the name does not
                    //  duplicate in the system
                    // if (dw_header.GetItemStatus(1, "ug_name", primary) == newmodified || dw_header.GetItemStatus(1, "ug_name", primary) == datamodified)
                   
                    //if (dw_header.DataObject.GetItem<GroupHeader>(0).IsNew || dw_header.DataObject.GetItem<GroupHeader>(0).IsDirty)
                if (dw_header.DataObject.GetItem<GroupHeader>(0).UgName != dw_header.DataObject.GetItem<GroupHeader>(0).GetInitialValue<string>("_ug_name"))
                {
                    /* SELECT count(*)  INTO :ll_count  FROM rds_user_group  WHERE ug_name = :ls_ug_id*/
                    if (!MainMdiService.GetRdsUserGroupDataObject(ls_ug_id, ref ll_count))
                    {
                        MessageBox.Show("Database Error", "Unable to validate group name.  \n\n" + "Error Code: " + SQLCode.ToString() + "\n\nError Text: " + SQLErrText);
                        ll_c = FAILURE;
                    }
                    if (ll_count > 0)
                    {
                        MessageBox.Show("The group name specified already exists in the database.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dw_header.DataObject.GetControlByName("ug_name").Focus();
                        //this.SetFocus();
                        dw_header.Focus();
                        ll_c = FAILURE;
                    }
                   }
               }        
               if(adw is DwUserDetails)
                {  
                    UserDetails userdetails = dw_detail.DataObject.Current as UserDetails;
                    if (userdetails == null) return ll_c;
                    if (userdetails.RdsUserUName == null || userdetails.RdsUserUName.Length <= 0)
                    {
                        MessageBox.Show("A user name must be specified", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dw_detail.DataObject.GetControlByName("rds_user_u_name").Focus();
                        return FAILURE;
                    }
                    if (userdetails.RdsUserUName != dw_detail.DataObject.GetItem<UserDetails>(dw_detail.DataObject.GetRow()).GetInitialValue<string>("_rds_user_u_name"))
                    {
                        
                        MainMdiService.GetCountFormRdsUser(userdetails.RdsUserUName, ref ll_count);
                        if (ll_count > 0)
                        {
                            MessageBox.Show("The user name specified already exists in the database.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dw_detail.DataObject.GetControlByName("rds_user_u_name").Focus();
                            return FAILURE;
                        }
                    }
                    if (userdetails.RdsUserIdUiUserid == null || userdetails.RdsUserIdUiUserid.Length<=0)
                    {
                        MessageBox.Show("A userid must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dw_detail.DataObject.GetControlByName("rds_user_id_ui_userid").Focus();
                        return FAILURE;
                    }
                    if (userdetails.RdsUserIdUiUserid != userdetails.GetInitialValue<string>("_rds_user_id_ui_userid"))
                    {
                        MainMdiService.GetUiUseridCountFormRdsUser(userdetails.RdsUserIdUiUserid, ref ll_count);
                        if (ll_count > 0)
                        {
                            MessageBox.Show("The user id specified already exists in the database.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dw_detail.DataObject.GetControlByName("rds_user_id_ui_userid").Focus();
                            return FAILURE;
                        }
                    }
                    if (userdetails.RdsUserIdUiPassword == null || userdetails.RdsUserIdUiPassword.Length <= 0)
                    {
                        MessageBox.Show("A password must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dw_detail.DataObject.GetControlByName("rds_user_id_ui_password").Focus();
                        return FAILURE;
                    }
                    if (userdetails.RdsUserIdUiPassword != userdetails.GetInitialValue<string>("_rds_user_id_ui_password"))
                    {
                        string returnMessage = string.Empty;
                        MainMdiService.GetUpPasswordFormRdsUser(userdetails.RdsUserIdUiId, userdetails.RdsUserIdUiPassword, ref returnMessage);
                        if (returnMessage != null && returnMessage != "")
                        {
                            MessageBox.Show("The password specified has already been used, Please select another.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dw_detail.DataObject.GetControlByName("rds_user_id_ui_password").Focus();
                            return FAILURE;
                        }
                    }
                    if (userdetails.RdsUserRegionId == null)
                    {
                        MessageBox.Show("A region must be specified.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dw_detail.DataObject.GetControlByName("rds_user_region_id").Focus();
                        return FAILURE;
                    }

                }            
            return ll_c;
        }

        //protected class DwContractType : URadDW
        //{
        //    WMainMdi window;

        //    public DwContractType(DataControlPanel dcp)
        //        : base(dcp)
        //    {
        //        window = dcp.FindForm() as WMainMdi;
        //    }
        //    public virtual void losefocus(object sender, EventArgs e)
        //    {
        //        //!base.losefocus();
        //        this.AcceptText();
        //    }

        //    public override int itemchanged(int row, DataColumn dwo, string data)
        //    {
        //        base.itemchanged(row, dwo, data);
        //        /*!  dwItemStatus l_status;
        //         l_status = dw_detail.GetItemStatus(1, 0, primary!);
        //          if (l_status == notmodified) 
        //          {
        //             // window.dw_detail.SetItemStatus(1, 0, primary!, datamodified!);
        //              window.dw_detail.Table.DefaultView[1].Row.RowState == System.Data.DataRowState.Modified;
        //          }
        //          else if (l_status == new) 
        //          {
        //             // window.dw_detail.SetItemStatus(1, 0, primary!, newmodified!);
        //              window.dw_detail.Table.DefaultView[1].Row.RowState == System.Data.DataRowState.Modified;
        //          }

        //          DataRow row = window.dw_detail.Table.DefaultView[0].Row;
        //          if (row.RowState == DataRowState.Unchanged)
        //          {
        //              row.SetModified();
        //          }*/
        //        return 1;
        //    }

        //    public virtual void pfc_prermbmenu()
        //    {
        //        /* base.pfc_prermbmenu();
        //         MRdsDw m_SecDw;
        //         // We create our own rmb menu inherited from m_tvs
        //         m_SecDw = new MRdsDw();
        //         m_SecDw.m_table.m_delete.Visible = false;
        //         m_SecDw.m_table.m_Insert.Visible = false;
        //         if (dw_contract_type.DataObject == "dw_contract_types")
        //         {
        //             m_SecDw.m_table.m_insert.Visible = false;
        //             m_SecDw.m_table.m_delete.Visible = false;
        //         }
        //         // Assign our own menu 
        //         am_dw = m_SecDw;
        //         // Let ancestor do its normal processing
        //         base.dw_contract_type_pfc_prermbmenu(am_dw);*/
        //    }
        //}

        //protected class DwUserDetails : URadDW
        //{
        //    WMainMdi window;

        //    public DwUserDetails(DataControlPanel dcp)
        //        : base(dcp)
        //    {
        //        window = dcp.FindForm() as WMainMdi;
        //    }
        //    public override int itemchanged(int row, DataColumn dwo, string data)
        //    {
        //        base.itemchanged(row, dwo, data);
        //        /*!
        //        dwItemStatus l_status;
        //        l_status = dw_detail.GetItemStatus(1, 0, primary!);
        //        if (l_status == notmodified!) {
        //            dw_detail.SetItemStatus(1, 0, primary!, datamodified!);
        //        }
        //        else if (l_status == new!) {
        //            dw_detail.SetItemStatus(1, 0, primary!, newmodified!);
        //        }
        //        DataRow row = dw_detail.Table.DefaultView[0].Row;
        //        if (row.RowState == DataRowState.Unchanged)
        //        {
        //            row.SetModified();
        //        }*/
        //        return 1;
        //    }

        //    public virtual void losefocus(object sender, EventArgs e)
        //    {
        //        //!base.losefocus();
        //        this.AcceptText();
        //    }

        //    public virtual void pfc_prermbmenu()
        //    {
        //        /*! base.pfc_prermbmenu();
        //         MRdsDw m_SecDw;
        //         // We create our own rmb menu inherited from m_tvs
        //         m_SecDw = new MRdsDw();
        //         m_SecDw.m_table.m_delete.Visible = false;
        //         m_SecDw.m_table.m_Insert.Visible = false;
        //         // Assign our own menu 
        //         am_dw = m_SecDw;
        //         // Let ancestor do its normal processing
        //         base.dw_user_details_pfc_prermbmenu(am_dw);*/
        //    }

        //    public override void clicked(int xpos, int ypos, int row, DataColumn dwo)
        //    {
        //        base.clicked(xpos, ypos, row, dwo);
        //        string sObjectAtPointer = string.Empty;
        //        string sDeliveryDays;
        //        int ll_contract_id;
        //        int ll_ui_id;

        //        int SQLCode = 0;
        //        string SQLErrText = string.Empty;

        //        //!  sObjectAtPointer = dw_user_details.GetObjectAtPointer();
        //        if (TextUtil.Left(sObjectAtPointer, 13) == "unlock_button")
        //        {
        //            ll_ui_id = this.GetItemInt(1, "ui_id").Value;
        //            if (ll_ui_id > 0)
        //            {
        //                /* UPDATE rds_user_id SET ui_locked_date = NULL WHERE	ui_id = :ll_ui_id*/
        //                StaticVariables.ServiceInterface.WMainMdi_DwUserDetails_clicked_1(ref ll_ui_id, ref SQLErrText, ref SQLCode);
        //                // Commit;
        //                this.Retrieve(new object[] { ll_ui_id });
        //            }
        //        }
        //    }
        //}

        private void WMainMdi_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // helper methods
        /* struct GridPropertyChangeInfo
        {
            int row;
            string column;
            int prop;
            bool value;

            public GridPropertyChangeInfo(int row, string column, int value)
            {
                this.row = row;
                this.column = column;
                this.value = value;
                this.prop = 0;
            }
        };
        List<GridPropertyChangeInfo> propertyChangeList;

        void AddPropertyChangeInfo(int row, string column, bool value)
        {
            if(propertyChangeList == null)
            {
                propertyChangeList = new List<GridPropertyChangeInfo>();
            }
            
            propertyChangeList.Add(new GridPropertyChangeInfo(row, column, value);
        }

        void DeferedUpdate(object param)
        {
            System.Threading.Thread.Sleep(500);
        } */
    }
}
