using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataService;
using System.IO;
using System.Collections.Generic;

using System.Drawing;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public partial class WMaintainAddress : WAncestorWindow
    {
        #region Define
        private NRoad inv_road;

        public const int ii_success = 1;

        public const int ii_failure = -(1);

        public int? il_adr_id = 0;

        public int? il_cust_id = 0;

        public URdsDw idw_movement;

        public URdsDw idw_header;

        public URdsDw idw_details;

        public int? il_road_id = 0;

        public bool ib_town_filtered = false;

        public bool ib_sub_filtered = false;

        public bool ib_town_selected = false;

        public bool ib_sub_selected = false;

        public int il_selected_town = 0;

        public int? il_selected_sub = 0;

        public bool ib_town_sent = false;

        public bool ib_sub_sent = false;
        public int? il_contract_no = 0;

        public string is_addr_perms = String.Empty;

        public string is_cust_perms = String.Empty;

        //  TJB  NPAD2  Jan 2006 
        public int il_deleted_dpids = -1;

        //  TJB  NPAD2  Jan 2006 
        public int il_deleted_master_dpid = -1;

        public List<int?> il_deleted_dpid = new List<int?>();

        public int il_dummy_dpid_row = -1;

        public List<int?> il_dummy_dpid = new List<int?>();

        public List<int?> il_dummy_cust = new List<int?>();

        public List<int?> il_dummy_status = new List<int?>();

        public int? il_dummy_master_dpid = 0;

        public int? il_dummy_master_cust = 0;

        public int? il_dummy_master_status = 0;

        public int? il_dummy_masters = 0;

        public int? il_dummy_recipients = 0;

        public int? il_dummy_custs = 0;

        public int? il_adpost_quantity = 0;

        public int il_oldsuburbtab;

        public int? il_cust_promoted = 0;

        public int? il_cust_demoted = 0;

        public int? il_promoted_dpid = 0;

        public int? il_demoted_dpid = 0;

        public string is_cust_business = String.Empty;

        public string is_rural_resident = String.Empty;

        public string is_rural_farmer = String.Empty;

        public bool ib_saved_master_values;

        public bool ib_npad_enabled = false;

        public bool ib_unnumbered;

        public bool ib_RDcontract;

        public DataUserControl ids_results;

        public string is_userid = String.Empty;

        public string is_npadoutfile = String.Empty;

        public string is_npadoutdir = String.Empty;

        public string is_npadfilename = String.Empty;

        public int il_contract_ok = -(1);

        #endregion

        public WMaintainAddress()
        {
            this.InitializeComponent();
            this.AttachDwEvents();

            //jlwang:moved from IC
            dw_header.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_header_constructor);
            ((PictureBox)dw_header.GetControlByName("contract_button")).Click += new EventHandler(dw_header_clicked);
            ((DataEntityCombo)dw_header.GetControlByName("tc_id")).SelectedValueChanged += new EventHandler(dw_header_itemchanged);
            ((TextBox)dw_header.GetControlByName("road_name")).Leave += new EventHandler(dw_header_itemchanged);
            //jlwang:end

            //! ItemChanged of dw_detail return wrong columnName - "grid"
            ((DAddressOccupants)(dw_details.DataObject)).Grid.CellValidated += new DataGridViewCellEventHandler(Grid_CellValidated);
            ((DAddressOccupants)(dw_details.DataObject)).Grid.CellValueChanged +=
                new DataGridViewCellEventHandler(this.dw_details_itemchanged);
            //((DAddressOccupants)(dw_details.DataObject)).Grid.CurrentCellDirtyStateChanged +=
            //    new EventHandler(this.dw_details_itemchanged);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            int? ll_temp = 0;
            int? ll_tcid = 0;
            string ls_temp;
            NRdsMsg lnv_msg;
            NCriteria lvNCriteria;
            DataUserControl ldwc_child;
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Add road suffix processing
            //  ------------------------------------------------------------------------
            //  Processing note:
            //  For address maintenance, if the address exists, the adr_id will be passed
            //  and used to populate the datawindow initially.  If the address is new,
            //  the adr_id will be 0 and the address will start empty.
            // 
            //  The road_type, and road-suffix dropdowns work in the same way as in the 
            //  address search screen.  The towncity dropdown always contains all towns.
            //  The suburb dropdown is populated depending only on the town  ( not the road) 
            //  and is empty of there is no town selected.
            // 
            //  Suburb and town selection is done by name  ( not ID).  The relevant IDs are
            //  determined when the record is being saved.
            // 
            //  The post code for non-RD contracts is the "old" post code - the post code 
            //  for a town that doesn't have an associated RD number.  The RD number is
            //  arbitrary text.
            // 
            //  Address maintenance is only available for non-RD contracts.
            //  ------------------------------------------------------------------------
            //  PBY 06/09/2002 SR#4454
            //? this.of_setpreference(true);
            of_set_componentname("Address");
            // of_Set_ComponentName ( 'Customer')
            // of_Bypass_Security ( TRUE)
            lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            lvNCriteria = lnv_msg.of_getcriteria();

            //! added checking for null or exception appears sometimes
            if (lvNCriteria.of_getcriteria("adr_id") != null)
            {
                il_adr_id = (int)lvNCriteria.of_getcriteria("adr_id");
            }
            if (lvNCriteria.of_getcriteria("cust_id") != null)
            {
                il_cust_id = (int)lvNCriteria.of_getcriteria("cust_id");
            }
            if (lvNCriteria.of_getcriteria("rd_Contract_Select") != null)
            {
                ll_temp = (int)lvNCriteria.of_getcriteria("rd_Contract_Select");
            }

            if (ll_temp == 1)
            {
                ib_RDcontract = true;
            }
            else
            {
                ib_RDcontract = false;
            }
            //  TJB  SR4686  June 2006
            //  Get the User's Address and Customer privileges
            //  The user needs Address:Modify to be able to modify the address 
            //  if it is a non-RD address and Customer privileges to do customer
            //  maintenance.
            is_addr_perms = of_getpermissions("Address");
            if (is_addr_perms == null)
            {
                is_addr_perms = "";
            }
            is_cust_perms = of_getpermissions("Customer");
            if (is_cust_perms == null)
            {
                is_cust_perms = "";
            }
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_adrid
                string	ds_rdflag
                string	ds_addr_perms, ds_cust_perms
                ds_addr_perms = is_addr_perms
                if is_addr_perms = '' then ds_addr_perms = 'NONE'
                ds_cust_perms = is_cust_perms
                if is_cust_perms = '' then ds_cust_perms = 'NONE'
                ds_adrid  = il_adr_id.ToString()
                if isnull ( il_adr_id)     then ds_adrid  = 'null' 
                ds_rdflag = ib_rdContract.ToString()
                if isnull ( ib_rdContract) then ds_rdflag = 'null' 
                MessageBox.Show (    & 'Adr ID         = '+ds_adrid  +'\r\n' & +'ib_rdContract = '+ds_rdflag +'\r\n' & +'Address permissions  = <'+ds_addr_perms +'>\r\n' & +'Customer permissions = <'+ds_cust_perms +'>\r\n' ,  'w_maintain_address.pfc_preopen' )
            // --------------------------------------------------------------------  */
            inv_road = (NRoad)StaticVariables.gnv_app.of_get_road_map();
            ldwc_child = idw_header.GetChild("rt_id");
            //!            inv_road.ids_dwc_road_type.ShareData(ldwc_child);
            //?ldwc_child.FilterString = "";
            //?ldwc_child.Filter<DddwRoadType>();
            ldwc_child.SortString = "rt_name A";
            ldwc_child.Sort<DddwRoadType>();
            ldwc_child = idw_header.GetChild("rs_id");
            //? inv_road.ids_dwc_road_type.ShareData(ldwc_child);
            //?ldwc_child.FilterString = "";
            //?ldwc_child.Filter<DddwRoadSuffix>();
            ldwc_child.SortString = "rs_name A";
            ldwc_child.Sort<DddwRoadSuffix>();
            //  TJB  NPAD2 Apr 2006  pre-GoLive:  Disable suburb stuff
            //  TJB  NPAD2 Apr 2006  :  Enable suburb stuff
            //  NOTE: changed sl_id from dropdown to edit field; added sl_name dropdown
            //  dw_header.GetChild ( 'sl_id', ldwc_child)
            //  inv_road.ids_dwc_suburb.ShareData ( ldwc_child)
            ldwc_child = dw_header.GetChild("sl_name");
            //?ldwc_child.FilterString = "";
            //?ldwc_child.Filter<DddwSuburbNames>();
            ldwc_child.SortString = "sl_name A";
            ldwc_child.Sort<DddwSuburbNames>();
            ldwc_child = idw_header.GetChild("tc_id");
            //!            inv_road.ids_dwc_town.ShareData ( ldwc_child);
            //?ldwc_child.FilterString = "";
            //?ldwc_child.Filter<DddwTownOnly>();
            ldwc_child.SortString = "tc_name A";
            ldwc_child.Sort<DddwTownOnly>();
            if (il_adr_id > 0)
            {
                //  opening an existing address
                dw_header.Retrieve(new object[] { il_adr_id });
                of_refresh_occupants();
                // Build title
                if (dw_header.RowCount > 0)
                {
                    this.Text = "Address  ( " + il_adr_id.ToString() + "): " + idw_header.GetItem<AddressDetails>(0).TitleAddress;
                }
                else
                {
                    this.Text = "Address  ( " + il_adr_id.ToString() + "): ";
                }
                //this.Text = "Address  ( " + il_adr_id.ToString() + "): " + StaticMessage.stringTitle;
                //  Set up the suburb dropdown, depending on the town value
                ll_tcid = idw_header.GetItem<AddressDetails>(0).TcId;
                of_filter_suburb_dddw(ll_tcid);
            }
            else
            {
                //  TJB  Oct 2005
                //  Disable the dropdown filtering to leave the
                //  dropdowns with all available values: they'll 
                //  be filtered as the values are changed.
                dw_header.InsertItem<AddressDetails>(dw_header.RowCount);
                dw_header.GetItem<AddressDetails>(dw_header.RowCount - 1).MarkClean();
                of_refresh_occupants();
                this.Text = "Address: <New Address>";
                //  Set up the suburb dropdown, depending on the town value
                ll_tcid = null;
                of_filter_suburb_dddw(ll_tcid);
            }
            //  Save the tab order number of the suburb dropdown.
            //  Used when the dropdown is re-enabled after being disabled.
            il_oldsuburbtab = idw_header.DataObject.Controls["sl_name"].TabIndex;
            /* 		TJB  OCT 2005
                Disabled resize function to overcome problem with window
                being displayed smaller than defined.
                of_SetResize ( TRUE)
                this.inv_resize.of_SetMinSize ( this.width - 50, this.height - 100)
                this.inv_resize.of_Register ( dw_header,  this.inv_resize.SCALERIGHT)
                this.inv_resize.of_Register ( gb_details, this.inv_resize.SCALERIGHTBOTTOM)
                this.inv_resize.of_Register ( dw_details, this.inv_resize.SCALERIGHTBOTTOM)
                this.inv_resize.of_Register ( cb_new,     this.inv_resize.FIXEDRIGHT)
                this.inv_resize.of_Register ( cb_open,    this.inv_resize.FIXEDRIGHT)
                this.inv_resize.of_Register ( cb_remove,  this.inv_resize.FIXEDRIGHT)
                this.inv_resize.of_Register ( cb_transfer,this.inv_resize.FIXEDRIGHT)
                this.inv_resize.of_Register ( cb_save,    this.inv_resize.FIXEDRIGHTBOTTOM)
                this.inv_resize.of_Register ( cb_close,   this.inv_resize.FIXEDRIGHTBOTTOM)
             */

            this.st_label.Text = "w_maintain_address";
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int ll_row;
            int ll_rows;
            int ll_master_row;
            int? ll_tcid = 0;
            Color ll_button_face = System.Drawing.SystemColors.ButtonFace;
            Color ll_win_background = System.Drawing.SystemColors.Window;
            string ls_temp;
            //  TJB  NPAD2  December 2005
            //  If NPAD processing is enabled, disable the fields in the
            //  address that cannot be updated.
            //  Determine if NPAD is enabled
            ib_npad_enabled = StaticVariables.gnv_app.of_get_npadenabled();
            if (ib_npad_enabled == null)
            {
                ib_npad_enabled = false;
            }
            //  Get some values to be used when communicating with NPAD
            is_npadoutdir = StaticVariables.gnv_app.of_get_npaddirectory();
            is_userid = StaticVariables.LoginId;
            if (is_npadoutdir == null)
            {
                is_npadoutdir = "";
            }
            if (is_userid == null)
            {
                is_userid = "";
            }
            //  Determine if the address is unnumbered
            ll_row = idw_header.GetRow();
            ls_temp = idw_header.GetItem<AddressDetails>(ll_row).AdrNum;
            if (ls_temp != null) ls_temp = ls_temp.Trim();
            ib_unnumbered = false;
            if (ls_temp == null || ls_temp == "")
            {
                ib_unnumbered = true;
            }
            //  TJB  SR46xx  Dec 2006
            //  If this user has sufficient privileges to restore deleted 
            //  customers, enable the "Restore custs" button; otherwise 
            //  disable it.
            if (true)
            {
                cb_restore.Visible = true;
                cb_restore.Enabled = true;
            }
            else
            {
                cb_restore.Visible = false;
                cb_restore.Enabled = false;
            }
            //  TJB  SR4686  June 2006
            //  Determine the address' contract_no and type
            il_contract_no = idw_header.GetItem<AddressDetails>(ll_row).ContractNo;
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_npad_enabled, ds_rdcontract, ds_adrnum, ds_contract_no, ds_isrdcontract
                if isnull ( ib_npad_enabled) then ds_npad_enabled = 'null' else ds_npad_enabled = ib_npad_enabled.ToString()
                if isnull ( ib_RDcontract)   then ds_rdcontract   = 'null' else ds_rdcontract   = ib_RDcontract.ToString()
                if isnull ( ls_temp)         then ds_adrnum       = 'null' else ds_adrnum       = ls_temp.ToString()
                if isnull ( il_contract_no)  then ds_contract_no  = 'null' else ds_contract_no  = il_contract_no.ToString()
                MessageBox.Show ( & 'NPAD enabled = '+ds_npad_enabled+'\r\n'  & +'RD contract = '+ds_rdcontract+'\r\n'    & +'Unnumbered  = '+string ( ib_unnumbered)+'\r\n'  & +'Adr num     = <'+ds_adrnum+'>'+'\r\n'   & +'Contract No = '+ds_contract_no+'\r\n'   ,  'w_maintain_address.pfc_postopen' )
            // --------------------------------------------------------------------  */
            //  TJB  SR4686  June 2006
            //  ******************************************************
            //  Set up customer maintenance
            //  ******************************************************
            /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show ( & 'idw_details.Enabled  = '+string ( idw_details.Enabled)+'\r\n'  & +'cb_open.Enabled     = '+string ( cb_open.Enabled)+'\r\n'      & +'cb_new.Enabled      = '+string ( cb_new.Enabled)+'\r\n'       & +'cb_transfer.Enabled = '+string ( cb_transfer.Enabled)+'\r\n'  & +'cb_remove.Enabled   = '+string ( cb_remove.Enabled)+'\r\n\r\n'  & +'is_cust_perms       = '+is_cust_perms		,  'w_maintain_address.pfc_postopen' )
            // --------------------------------------------------------------------  */
            idw_details.SuspendLayout();
            //  If the user doesn't have Customer:read privilege, they can't do anything
            //  with customers.
            idw_details.Enabled = false;
            cb_open.Enabled = false;
            cb_new.Enabled = false;
            cb_transfer.Enabled = false;
            cb_remove.Enabled = false;
            ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["primary_ind"].ReadOnly = true;
            if (!(is_cust_perms.IndexOf('R') >= 0))
            {
                ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["primary_ind"].DefaultCellStyle.BackColor = ll_button_face;
                ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["master_cust_id"].DefaultCellStyle.BackColor = ll_button_face;
                ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["contact"].DefaultCellStyle.BackColor = ll_button_face;
                //? idw_details.Object.Datawindow.detail.color = ll_button_face;
            }
            else
            {
                idw_details.Enabled = true;
                ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["primary_ind"].DefaultCellStyle.BackColor = ll_win_background;
                ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["master_cust_id"].DefaultCellStyle.BackColor = ll_win_background;
                ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["contact"].DefaultCellStyle.BackColor = ll_win_background;
                //? idw_details.Object.Datawindow.detail.color = ll_win_background;

                //  Unprotect the primary indicator even if the user doesn't have
                //  privilege to change it; the itemchanged event will display a 
                //  warning message if the user doesn't have the right privilege 
                //   ( Customer:Modify)
                ((DataGridView)idw_details.DataObject.Controls["grid"]).Columns["primary_ind"].ReadOnly = false;
                cb_open.Enabled = true;
                //  The user must have CUSTOMER:Create privilege in order
                //  to create new customers
                if (is_cust_perms.IndexOf('C') >= 0)
                {
                    cb_new.Enabled = true;
                }
                //  The user must have CUSTOMER:Modify privilege in order
                //  to transfer customers
                if (is_cust_perms.IndexOf('M') >= 0)
                {
                    cb_transfer.Enabled = true;
                }
                //  The user must have CUSTOMER:Modify or CUSTOMER:Delete privilege 
                //  in order to remove new customers
                if (is_cust_perms.IndexOf('M') >= 0 || is_cust_perms.IndexOf('D') >= 0)
                {
                    cb_remove.Enabled = true;
                }
            }
            //  If this is an unnumbered address and NPAD is enabled 
            //  and an RD contract ...
            if (ib_npad_enabled && ib_unnumbered && ib_RDcontract)
            {
                //  The user is not allowed to create new customers at unnumbered 
                //  addresses in RDS  ( must use NPAD to create new customers).
                cb_new.Enabled = false;
            }
            //  ******************************************************
            //  Set up address maintenance
            //  ******************************************************
            //  If NPAD is enabled ...
            if (ib_npad_enabled && ib_RDcontract)
            {
                //  disable the ability of the user to create new addresses.
                of_disable_header_maint();
            }
            else
            {
                //  If the user is able to maintain the address, hide the DP_ID if
                //  this is a non-rural-delivery address
                if (!ib_RDcontract)
                {
                    idw_header.GetControlByName("dp_id_t").Visible = false;
                    idw_header.GetControlByName("dp_id").Visible = false;
                }
                //  If no tc_id is yet specified, disable suburb selection
                //   ( it starts enabled).
                ll_tcid = idw_header.GetItem<AddressDetails>(0).TcId;
                if (ll_tcid == null || ll_tcid <= 0)
                {
                    of_enablesuburb(false);
                }
            }
            //  If this is a new address ...
            if (il_adr_id == null || il_adr_id <= 0)
            {
                //  set the focus to the header
                idw_header.Focus();
                idw_header.DataObject.Controls["adr_num"].Focus();
            }
            else
            {
                //  set the focus to the occupants list
                idw_details.Focus();
                of_findmaster();
                // 	idw_details.Post SetFocus ( )
            }
            //  TJB  SR4697  Dec-2006
            //  Disable the Cust Restore button if the user doesn't have 
            //  modify permission
            int? ll_temp = 0;
            string ls_custrestore;
            ls_custrestore = of_getpermissions("Customer Restore");
            if (ls_custrestore == null)
            {
                ls_custrestore = "";
            }
            ll_temp = ls_custrestore.IndexOf("M");
            /*  ------------------------ Debugging ------------------------- //
                string ds_custrestore, ds_temp
                ds_custrestore = ls_custrestore
                ds_temp = ll_temp.ToString()
                if isnull ( ls_custrestore) then ds_custrestore = 'Null'
                ds_temp = ll_temp.ToString()
                if isnull ( ll_temp) then ds_temp = 'Null'
                MessageBox.Show (  & 'Cust Restore permissions = '+ds_custrestore+'\r\n'  & +'Permission M at '+ds_temp,  'w_maintain_address.pfc_preopen' )
            // ------------------------------------------------------------  */
            if (ll_temp < 0)
            {
                cb_restore.Enabled = false;
                cb_restore.Visible = false;
            }

            idw_details.ResumeLayout(false);
            // long ll_town
            // ll_town = dw_header.getitemnumber ( dw_header.GetRow ( ), "tc_id")
            // 
            // datawindowchild ldwc_child
            // datawindowchild ldwc_child_post
            // dw_header.GetChild ( 'tc_id', ldwc_child)
            // dw_header.SetItem ( 1, 'post_code', ldwc_child.GetItemString ( ldwc_child.GetRow ( ), 'post_code'))
            // dw_header.SetItem ( 1, 'post_code_id', ldwc_child.GetItemNumber ( ldwc_child.GetRow ( ), 'post_code_id'))
            // 
            idw_header.GetItem<AddressDetails>().SetEntityClean();
        }

        public override void close()
        {
            base.close();
            //? commit;
            StaticMessage.DoubleParm = (double)il_adr_id;
        }

        #region Methods

        public virtual void ue_clicked_ok()
        {
            int li_rc;
            int ll_row;
            int ll_header_rows_modified;
            string ls_userid;
            li_rc = 1;
            if (StaticFunctions.IsDirty(dw_header))
            {
                li_rc = dw_header.Save();
            }
            if (StaticFunctions.IsDirty(idw_details))
            {
                //li_rc = dw_header.Save();//li_rc = this.pfc_save();
                li_rc = dw_details.Save();
            }
            if (li_rc == 1)
            {
                this.Close();
            }
        }

        public virtual int of_checkandsave()
        {
            DialogResult li_choice;
            int li_rc;
            if (il_adr_id <= 0)
            {
                //  No address id allocated yet.  Must save to proceed 
                li_choice = MessageBox.Show("The new address must be saved before any occupants \r\n" + "can be created for the address. Do you wish to \r\n" + "continue and save the address now?", "Save Address", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (li_choice == DialogResult.Yes)
                {
                    //li_rc = dw_header.Save();//li_rc = this.pfc_save();
                    //if (li_rc == 0)
                    //{
                    //    MessageBox.Show("You must supply address header before an address can be saved.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return ii_failure;
                    //}
                    //else if (li_rc < 0)
                    //{
                    //    return ii_failure;
                    //}

                    //li_rc = dw_details.Save();//li_rc = this.pfc_save();
                    if (!dw_header.GetItem<AddressDetails>(0).IsDirty && dw_header.GetItem<AddressDetails>(0).IsNew)
                    {
                        MessageBox.Show("You must supply address details before an address can be saved.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return ii_failure;
                    }
                    li_rc = dw_header.Save();//li_rc = this.pfc_save();
                    if (li_rc < 0)
                    {
                        return ii_failure;
                    }

                }
                else
                {
                    return ii_failure;
                }
            }
            else if (of_updatechecks() > 0)
            {
                li_choice = MessageBox.Show("You must save the changes before continuing. \r\n" + "Do you wish to save the changes now?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (li_choice == DialogResult.Yes)
                {
                    li_rc = dw_details.Save();// li_rc = this.pfc_save();
                    if (li_rc < 0)
                    {
                        return ii_failure;
                    }
                }
                else
                {
                    return ii_failure;
                }
            }
            return ii_success;
        }

        public virtual int of_refresh_occupants()
        {
            //DDddwPrimContactsForAnAddress dwChild;
            int ll_row;
            int ll_rows;
            int ll_master_cust_row;
            ll_rows = 0;
            idw_details.SuspendLayout();
            //dwChild = (DDddwPrimContactsForAnAddress)idw_details.GetChild("master_cust_id");
            //if (il_adr_id > 0)
            //{
            //    ll_rows = dwChild.Retrieve(il_adr_id);
            //}
            //if (ll_rows <= 0)
            //{
            //    dwChild.InsertItem<DddwPrimContactsForAnAddress>(0);
            //}
            #region added by ylwang
            List<NZPostOffice.RDS.Entity.Ruraldw.DddwPrimContactsForAnAddress> bindingSource = new List<DddwPrimContactsForAnAddress>();
            NZPostOffice.RDS.Entity.Ruraldw.DddwPrimContactsForAnAddress[] anAddressArray = DddwPrimContactsForAnAddress.GetAllDddwPrimContactsForAnAddress(il_adr_id);
            foreach (NZPostOffice.RDS.Entity.Ruraldw.DddwPrimContactsForAnAddress anAddress in anAddressArray)
            {
                bindingSource.Add(anAddress);
            }
            ((Metex.Windows.DataGridViewEntityComboColumn)((Metex.Windows.DataEntityGrid)idw_details.DataObject.GetControlByName("grid")).Columns["master_cust_id"]).DataSource = bindingSource;
            #endregion
            
            idw_details.Retrieve(new object[] { il_adr_id.GetValueOrDefault() });
            idw_movement.Retrieve(new object[] { il_adr_id.GetValueOrDefault() });
            idw_details.DataObject.SortString = "master_cust_id, cust_id";
            idw_details.DataObject.Sort<AddressOccupants>();
            idw_details.Focus();
            of_findmaster();
            /* 
                ll_master_cust_row = dw_details.FIND ( 'isnull ( master_cust_id)',  &
                1,dw_details.RowCount)
                dw_details.Post SetFocus ( )
                //this.Post SetRow ( 1)
                //this.Post SetFocus ( )
                //dw_details.Post SelectRow ( 1, TRUE)
                dw_details.Post SelectRow ( 0, FALSE)
                dw_details.Post SelectRow ( ll_master_cust_row, TRUE)
             */
            idw_details.ResumeLayout(false);
            return ii_success;
        }

        public virtual int of_refresh_occupants(int al_row)
        {
            int ll_return;
            // Refresh the occupants
            ll_return = of_refresh_occupants();

            dw_details.DataObject.BindingSource.CurrencyManager.Refresh();
            // Select the clicked row
            dw_details.SelectRow(0, false);
            dw_details.SelectRow(al_row + 1, true);
            return ll_return;
        }

        public virtual bool of_iscontractoftyperd(int? al_contract_no)
        {
            bool lb_return;
            int ll_match_count = 0;
            int ll_contract_type_rd = 1;
            lb_return = false;
            //  Select the contract type for the given contract
            //  Validate that the contract # is valid 
            /* SELECT 	count ( *)
                INTO		:ll_match_count
                FROM		types_for_contract
                WHERE		contract_no = :al_contract_no
                AND		ct_key = :ll_contract_type_rd
                USING		SQLCA; */
            RDSDataService dataService = RDSDataService.GetTypesForContractCount(al_contract_no, ll_contract_type_rd);
            ll_match_count = dataService.intVal;
            if (dataService.SQLCode != 0)
            {
                //  DB Error
                if (!ib_closestatus)
                {
                    MessageBox.Show("A database error has occurred. \r\n\r\n" + "Database error code:  " + dataService.SQLDBCode + '~' + "Database error message:\r\n" + "    " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (ll_match_count > 0)
            {
                //  this is RD type
                lb_return = true;
            }
            return lb_return;
        }

        public virtual int? of_get_tcid(string as_tcname)
        {
            //  tjb SR4584
            //  If the user enters a town name that doesn't match an entry in 
            //  the town dropdown list, the postcode looked up is incorrect.
            //  This function looks up the town's tc_id directly from the 
            //  database to be passed to of_set_postcode so that the correct 
            //  postcode can be used.  
            // 
            //  Note: Although the town name will already have been validated
            //  by the itemerror event, this routine returns 0 if the town 
            //  name isn't found.
            int? li_tcid = null;
            /* SELECT tc_id
                INTO :li_tcid
                FROM towncity
                WHERE tc_name = :as_tcname
                USING SQLCA; */
            RDSDataService dataService = RDSDataService.GetTownCityTcId(as_tcname);
            li_tcid = dataService.intVal;
            if (!(li_tcid == null))
            {
                return li_tcid;
            }
            return 0;
        }

        public virtual int? of_get_dpid(int? al_custid)
        {
            //  TJB  NPAD2  Jan 2006  - NEW -
            //  Get the DP_ID for a customer
            // 
            //  Returns the dp_id, or 0 if none.
            int? ll_dpid = null;
            /* SELECT dp_id
                INTO :ll_dpid
                FROM customer_address_moves
                WHERE cust_id = :al_custID
                AND move_out_date is null
                USING SQLCA; */
            RDSDataService dataService = RDSDataService.GetCustomerAddressMovesByCustId(al_custid);
            ll_dpid = dataService.intVal;
            if (ll_dpid == null)
            {
                ll_dpid = 0;
            }
            return ll_dpid;
        }

        public virtual bool of_isunnumbered(int? al_adr_id)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            //  Determine whether an address is numbered or not.
            //  Returns
            // 		TRUE	is not numbered  ( adr_no is null)
            // 		FALSE	is numbered  ( adr_no is not null)
            string ls_adr_no = null;
            bool lb_unnumbered;
            lb_unnumbered = false;
            /* select adr_no into :ls_adr_no from address  where adr_id = :al_adr_id  using SQLCA; */
            RDSDataService dataService = RDSDataService.GetAddressAdrNo(al_adr_id);
            ls_adr_no = dataService.strVal;
            if (ls_adr_no == null)
            {
                lb_unnumbered = true;
            }
            return lb_unnumbered;
        }

        public virtual int? of_get_adrid(int? al_custid)
        {
            //  TJB  NPAD2  Jan 2006  - NEW -
            //  Get the adr_id for a customer
            // 
            //  Returns the adr_id, or 0 if none.
            int? ll_adrid = null;
            /* SELECT adr_id
                INTO :ll_adrid
                FROM customer_address_moves
                WHERE cust_id = :al_custID
                AND move_out_date is null
                USING SQLCA; */
            RDSDataService dataService = RDSDataService.GetCustomerAddressMovesAdrIdByCustId(al_custid);
            ll_adrid = dataService.intVal;
            if (ll_adrid == null)
            {
                ll_adrid = 0;
            }
            return ll_adrid;
        }

        public virtual bool of_isunoccupied(int? al_adr_id)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            //  Determine whether an address is occupied or not.
            //  Returns
            // 		TRUE	is unoccupied
            // 		FALSE	is occupied
            int? ll_at_adr = null;
            bool lb_unoccupied;
            lb_unoccupied = false;
            /* select count ( *) 
                into :ll_at_adr
                from customer_address_moves
                where adr_id = :al_adr_id
                and move_out_date is null
                using SQLCA; */
            ll_at_adr = RDSDataService.GetRdsCustomerAddressMoves(al_adr_id);
            if (ll_at_adr == null || ll_at_adr <= 0)
            {
                lb_unoccupied = true;
            }
            return lb_unoccupied;
        }

        public virtual int of_npad_xferone(int? al_old_dpid, int? al_new_dpid, string as_description)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            //  Send NPAD a transfer_customer message to NPAD
            // 
            //  13 Feb 2006  TJB  
            // 	Changed filename to include 1/1000ths of a second.
            // 
            //  10 Apr 2006  TJB  NPAD2 fixups
            //  Changed filename to remove 1/1000ths of a second 
            //  and add sequence number.
            // 
            //  20 June 2006  TJB  NPAD2 fixups
            //  Added check for SQL error when writing XML output file.
            int li_rc;
            int ll_row;
            int? ll_npadfileseq = null;
            string ls_npadfileseq;
            string ds_msg;
            string ds_dpid;
            string ds_dpid1;
            string ds_dpid2;
            li_rc = 0;
            //  XML message file info
            /* select f_getNextSequence ( 'NPADFileSeq',1,10000)
                into :ll_npadfileseq
                from dummy
                using SQLCA; */
            RDSDataService dataService = RDSDataService.GetNextSequence("NPADFileSeq");
            ll_npadfileseq = dataService.intVal;
            if (ll_npadfileseq == null || ll_npadfileseq <= 0)
            {
                MessageBox.Show("Failed to obtain sequence number for NPAD XML message filename.  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ls_npadfileseq = DateTime.Now.ToShortTimeString();
            }
            else
            {
                ls_npadfileseq = string.Format("{0:0000}", ll_npadfileseq);
            }
            is_npadfilename = "RDS_NPAD_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + ls_npadfileseq + ".xml";
            is_npadoutfile = is_npadoutdir + "\\" + is_npadfilename;
            ds_dpid1 = al_old_dpid.ToString();
            if (al_old_dpid == null)
            {
                ds_dpid1 = "null";
            }
            ds_dpid2 = al_new_dpid.ToString();
            if (al_new_dpid == null)
            {
                ds_dpid2 = "null";
            }
            /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show (  & 'NPAD interface message\r\n\r\n'  & +'Send transfer_customer XML message\r\n'	& +'   Old DPID = '+ds_dpid1+'\r\n'	   & +'   New DPID = '+ds_dpid2+'\r\n\r\n'	& +as_description+'\r\n'  & +is_npadoutfile+'\r\n'  & +is_userid            ,  'w_maintain_address.of_npad_xferOne' )
            // --------------------------------------------------------------------  */
            if (al_old_dpid == null || al_old_dpid < 1 || al_new_dpid == null || al_new_dpid < 1)
            {
                MessageBox.Show("One or both customer DPIDs are null.  \r\n" + "This may indicate an inconsistency in the database. \r\n\r\n" + "Old Master DPID = " + ds_dpid1 + '~' + "New Master DPID = " + ds_dpid2 + '~', "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                /* select f_rds_npad_transfer_customer (  :al_old_dpid, :al_new_dpid,
                    :is_userid, :as_description, :is_npadoutfile)
                    into :li_rc
                    from dummy
                    using SQLCA; */
                dataService = RDSDataService.GetRdsNpadTransferCustomer(is_userid, is_npadoutfile, al_old_dpid, as_description, al_new_dpid);
                li_rc = dataService.intVal;
                //!li_rc = this.WriteXMLFileTransferCustomer(is_userid, is_npadoutfile, al_old_dpid, as_description, al_new_dpid);
                if (li_rc > 0)
                {
                    if (li_rc == 1)
                    {
                        ds_msg = "Invalid old DPID";
                        ds_dpid = ds_dpid1;
                    }
                    else
                    {
                        ds_msg = "Invalid new DPID";
                        ds_dpid = ds_dpid2;
                    }
                    MessageBox.Show("Error sending transfer_customer message.\r\n" + "Return code = " + li_rc + "   ( " + ds_msg + ", \"Error\" )" + "\r\n\r\nDPID = " + ds_dpid, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (li_rc < 0)
                {
                    MessageBox.Show("Error writing XML message file  ( RC=" + li_rc + ").\r\n" + "    " + is_npadoutfile + "\r\n\r\n" + "Possible cause: the output directory may not exist.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return li_rc;
        }

        public virtual int of_deletedummycust(int? al_cust)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            // 
            //  Delete a dummy customer from the rd_customer and 
            //  customer_address_moves tables.  No messing about
            //  with master/recipient chains or moved_in/out dates
            //  since the dummies are temporary and  ( usually) are 
            //  all replaced at the same time.
            // 
            //  Returns the status
            // 		0	OK
            // 	 100	Not found
            // 	  >0	Error
            int ll_rc;
            /*   This is the real code:
                delete from rd_customer
                where cust_id = :al_cust
                using SQLCA;
                ll_rc = SQLCA.sqlcode
                if ll_rc = 0 then
                delete customer_address_moves
                where cust_id = :al_cust
                using SQLCA;
                ll_rc = SQLCA.sqlcode
                end if
            */
            //  This is for testing
            /* UPDATE customer_address_moves set move_out_date = today ( )
                where cust_id = :al_cust
                and move_out_date is null
                using SQLCA; */
            RDSDataService dataService = RDSDataService.UpdateCustomerAddressMovesByCustId(al_cust);
            ll_rc = dataService.SQLCode;
            return ll_rc;
        }

        public virtual int of_getdummycustdpids(int? al_adrid)
        {
            //  TJB  NPAD2  Jan 2006 - New -
            //  Get the DBIDs of dummy recipients at an address
            // 
            //  Returns
            // 	  >0		The number of DPIDs being returned
            // 	  <0		An error occurred
            // 		0		No recipient DPIDs found
            int ll_count;
            int? ll_dpid = 0;
            int? ll_cust = 0;
            ll_count = 0;
            /* declare cust_dpid cursor for
            select cam.dp_id, cam.cust_id
            from rds_customer c,
            customer_address_moves cam
            where c.cust_id    = cam.cust_id
            and cam.adr_id   = :al_adrid
            and cam.move_out_date is null
            and c.master_cust_id is not null
            and c.cust_surname_company like 'Dummy%'
            using SQLCA;
            OPEN cust_dpid
            fetch cust_dpid into :ll_dpid, :ll_cust;
            while (dataService.SQLCode == 0) {
                ll_count++;
                il_dummy_dpid[ll_count] = ll_dpid;
                il_dummy_cust[ll_count] = ll_cust;
                fetch cust_dpid into :ll_dpid, :ll_cust;
            }
            CLOSE cust_dpid */
            RDSDataService dataService = RDSDataService.GetManyRdsCustomInfo(al_adrid);
            ll_count = dataService.RdsCustomInfoList.Count;
            if (ll_count > 0)
            {
                for (int i = 0; i < ll_count; i++)
                {
                    RdsCustomInfoItem item = dataService.RdsCustomInfoList[i];
                    //!il_dummy_dpid[i] = item.DpId;
                    il_dummy_dpid.Add(item.DpId);
                    //!il_dummy_cust[i] = item.CustId;
                    il_dummy_cust.Add(item.CustId);
                }
            }
            return ll_count;
        }

        public virtual int of_getdummymasterdpid(int? al_adrid)
        {
            //  TJB  NPAD2  Jan 2006 - New -
            //  Get the DBID of the dummy master at an address
            // 
            //  Returns
            // 		1		The DPID was found
            // 	  <0		An error occurred
            // 		0		No DPID found
            int ll_rc;
            int? ll_dpid = null;
            int? ll_cust = null;
            string ds_dpid;
            string ds_cust;
            string ds_msg;
            /* select cam.dp_id, cam.cust_id
                into :ll_dpid, :ll_cust
                from rds_customer c,
                customer_address_moves cam
                where c.cust_id    = cam.cust_id
                and cam.adr_id   = :al_adrid
                and cam.move_out_date is null
                and c.master_cust_id  is null
                and c.cust_surname_company like 'Dummy%'
                using SQLCA; */
            RDSDataService dataService = RDSDataService.GetCustomerAddressMovesDpIdCustId(al_adrid);
            if (dataService.CustomerAddressMovesDpIdCustIdList.Count > 0)
            {
                CustomerAddressMovesDpIdCustIdItem item = dataService.CustomerAddressMovesDpIdCustIdList[0];
                ll_dpid = item.DpId;
                ll_cust = item.CustId;
            }
            ll_rc = 1;
            if (dataService.SQLCode == 100)
            {
                ll_rc = 0;
                il_dummy_master_dpid = null;
                il_dummy_master_cust = null;
            }
            else if (dataService.SQLCode < 0)
            {
                ll_rc = dataService.SQLCode;
                if (ll_dpid == null)
                {
                    ds_dpid = "null";
                }
                else
                {
                    ds_dpid = ll_dpid.ToString();
                }
                if (ll_cust == null)
                {
                    ds_cust = "null";
                }
                else
                {
                    ds_cust = ll_cust.ToString();
                }
                MessageBox.Show("Determining dummy primary\'s DPID\r\n" + "ll_dpid = " + ds_dpid + '~' + "ll_cust = " + ds_cust + '~' + "SQLCA.SQLErrText = " + dataService.SQLErrText, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                il_dummy_master_dpid = ll_dpid;
                il_dummy_master_cust = ll_cust;
            }
            return ll_rc;
        }

        public virtual int of_promote_recipient()
        {
            //  TJB  NPAD2  Feb 06  - New -
            //  ---------------------------------------
            //  "Promote" the 1st transferring recipient 
            //  ---------------------------------------
            //  "Promote" the 1st transferring recipient to be the master of all 
            //  the transferring customers  ( there won't already be one).
            // 
            //  Returns the row number of the promoted customer.
            int ll_row;
            int ll_this_cust_row = -1;
            int ll_new_master_row = -1;
            int? ll_this_cust_id = 0;
            int? ll_new_master = null;
            int? ll_null = 0;
            ll_new_master = 0;
            ll_null = null;
            //  Work through all the transferring customers
            for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
            {
                //  If this entry is the current active one
                if (ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null)
                {
                    //  For each transferring customer, get some relevant details
                    ll_this_cust_id = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustId;
                    ll_this_cust_row = idw_details.Find("cust_id", ll_this_cust_id);
                    if (ll_new_master == 0)
                    {
                        //  This is the first transferring customer.
                        //  Make it the master of the transferring customers.
                        ll_new_master = ll_this_cust_id;
                        ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId = ll_null;
                        idw_details.GetItem<AddressOccupants>(ll_this_cust_row).MasterCustId = ll_null;
                        ll_new_master_row = ll_row;
                        //  Pass on the old master's attributes to the promoted recipient
                        if (ib_saved_master_values)
                        {
                            idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustBusiness = is_cust_business;
                            idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustRuralResident = is_rural_resident;
                            idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustRuralFarmer = is_rural_farmer;
                            idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustAdpostQuantity = il_adpost_quantity;
                        }
                    }
                    else
                    {
                        //  This is a subsequent transferring customer.
                        //  Make it a recipient of the new master.
                        ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId = ll_new_master;
                        idw_details.GetItem<AddressOccupants>(ll_this_cust_row).MasterCustId = ll_new_master;
                    }
                }
            }
            /*  ---------------------------- Debugging ----------------------------- //
            MessageBox.Show ( & 'ids_results.rowcount = '+string ( ids_results.rowcount ( ))+'\r\n' & +'Promoted customer = '+string ( ll_new_master)+'\r\n'  & +ids_results.getItemString ( ll_new_master_row, 'w_maintain_address.of_promote_recipient', 'cust_initials') & +" "+ids_results.getItemString ( ll_new_master_row, 'cust_surname_company') &  )
            // --------------------------------------------------------------------  */
            //  Return the row number of the promoted recipient
            return ll_new_master_row;
        }

        public virtual int of_promote_old_recipient(int? al_transferring_master_id, int? al_transferring_master_dpid)
        {
            int ll_row = -1;
            int ll_this_cust_row;
            int ll_new_old_master_row;
            int? ll_null = 0;
            int? ll_this_cust_id = 0;
            int? ll_this_cust_master = 0;
            int? ll_new_old_master_id = 0;
            ll_null = null;
            ll_new_old_master_id = 0;
            ll_new_old_master_row = 0;
            //  Make the first of the recipients left behind the "new_old_master",
            //  and link any others who also are not transferring to it.
            //  - Step through the dw_details  ( customer) data window, since the
            //    customers who aren't transferring aren't in the 'results' list.
            for (ll_this_cust_row = 0; ll_this_cust_row < idw_details.RowCount; ll_this_cust_row++)
            {
                //DAddressSelectOccupants
                //AddressSelectOccupants ids_resultsRecord = ids_results.GetItem<AddressSelectOccupants>(ll_this_cust_row);

                ll_this_cust_id = idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustId;

                //p! find null value replaced by the loop
                //!ll_row = ids_results.Find(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("cust_id", ll_this_cust_id), 
                //! new KeyValuePair<string, object>("move_out_date", null) }); 
                ll_row = -1;
                for (int i = 0; i < ids_results.RowCount; i++)
                {
                    AddressSelectOccupants ids_resultsRecord = ids_results.GetItem<AddressSelectOccupants>(i);
                    if (ids_resultsRecord.CustId == ll_this_cust_id && !ids_resultsRecord.MoveOutDate.HasValue)
                    {
                        ll_row = i;
                        break;
                    }
                }

                if (ll_row < 0)
                {
                    //  This customer isn't transferring
                    ll_this_cust_master = idw_details.GetItem<AddressOccupants>(ll_this_cust_row).MasterCustId;
                    if (!(ll_this_cust_master == null) && ll_this_cust_master == al_transferring_master_id)
                    {
                        //  This customer is not a master and is linked to the master 
                        //  who is transferring.  
                        //  Link this customer to the new 'old' master.
                        if (ll_new_old_master_id == 0)
                        {
                            //  If there isn't a new 'old' master yet, promote this 
                            //  customer to be the new one.
                            il_cust_promoted = ll_this_cust_id;
                            il_cust_demoted = al_transferring_master_id;
                            il_promoted_dpid = idw_details.GetItem<AddressOccupants>(ll_this_cust_row).DpId;
                            il_demoted_dpid = al_transferring_master_dpid;
                            ll_new_old_master_id = ll_this_cust_id;
                            ll_new_old_master_row = ll_this_cust_row;
                            idw_details.GetItem<AddressOccupants>(ll_this_cust_row).MasterCustId = ll_null;
                            //  TJB  SR4656  May 2005
                            //  This new 'old' master inherits the old master's
                            //  category and Kiwimail count
                            if (ib_saved_master_values)
                            {
                                idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustBusiness = is_cust_business;
                                idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustRuralResident = is_rural_resident;
                                idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustRuralFarmer = is_rural_farmer;
                                idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustAdpostQuantity = il_adpost_quantity;
                            }
                        }
                        else
                        {
                            idw_details.GetItem<AddressOccupants>(ll_this_cust_row).MasterCustId = ll_new_old_master_id;
                        }
                    }
                }
            }
            /*  ---------------------------- Debugging ----------------------------- //
                if ll_new_old_master_row = 0 then
                MessageBox.Show (   & 'Old Recipient to promote not found!' ,  'w_maintain_address.of_promote_old_recipient' )
                else
                string	ds_cust, ds_initials, ds_surname, ds_name
                ds_cust = ll_new_old_master_id.ToString()
                ds_initials = idw_details.getItemString ( ll_new_old_master_row, 'cust_initials')
                ds_surname  = idw_details.getItemString ( ll_new_old_master_row, 'cust_surname_company')
                setnull ( ds_name)
                if isnull ( ds_cust)     then ds_cust = 'null'
                if isnull ( ds_name)     then ds_name = 'null'
                if not isnull ( ds_initials) then ds_name = ds_initials
                if not isnull ( ds_surname)  then ds_name += " "+ds_surname
                MessageBox.Show ( & 'RDS internal operation\r\n\r\n'  & +'Old Recipient promoted.  \r\n'  & +'cust_id = '+ds_cust+'  ( '+ds_name+') \r\n'  ,  'w_maintain_address.of_promote_old_recipient' )
                end if
            // --------------------------------------------------------------------  */
            return ll_new_old_master_row;
        }

        public virtual int of_npad_deleteall(string as_description)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            //  Send NPAD delete_customer messages for each of the
            //  moved-out customers in the lds_results datastore
            // 
            //  13 Feb 2006  TJB  
            //  Changed filename to include 1/1000ths of a second 
            //  and removed sequence number.
            // 
            //  10 Apr 2006  TJB  NPAD2 fixups
            //  Changed filename to remove 1/1000ths of a second 
            //  and add sequence number.
            // 
            //  20 June 2006  TJB  NPAD2 fixups
            //  Added check for SQL error when writing XML output file.
            int li_rc;
            int ll_row;
            int? ll_cust = null;
            int? ll_dpid = 0;
            int? ll_npadfileseq = null;
            string ls_npadfileseq = "";
            string ds_name;
            string ds_dpid;
            string ds_cust;
            li_rc = 0;
            for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
            {
                //  Use only the rows with a non-null move_out_date
                //  since there are now two entries for each customer
                //   ( a moved-out entry and a moved-in entry).
                if (!(ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null))
                {
                    ll_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                    ds_dpid = ll_dpid.ToString();
                    if (ll_dpid == null)
                    {
                        ds_dpid = "null";
                    }
                    if (ll_cust == null)
                    {
                        ds_cust = "null";
                    }
                    else
                        ds_cust = ll_cust.ToString();
                    /*  ---------------------------- Debugging ----------------------------- //
                        ds_name = ids_results.getItemstring ( ll_row,'cust_initials')  &
                        +" "+ids_results.getItemstring ( ll_row,'cust_surname_company')
                        if isnull ( ds_name) then ds_name = 'null'
                        MessageBox.Show (  & 'NPAD interface message\r\n\r\n'  & +'Send delete_customer XML message for all recipients\r\n'		& +'   DPID = '+ds_dpid+'\r\n\r\n' & +'   Cust = '+ds_cust+'\r\n'   & +'   Name = '+ls_name+'\r\n\r\n' & +as_description              ,  'w_maintain_address.of_npad_deleteall' )
                    // --------------------------------------------------------------------  */
                    if (ll_dpid == null || ll_dpid < 1)
                    {
                        MessageBox.Show("The customer DPID is null.  \r\n" + "This may indicate an inconsistency in the database. \r\n\r\n" + "Cust ID = " + ds_cust + '~' + "DPID    = " + ds_dpid + '~', "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //  XML message file info
                        /* select f_getNextSequence ( 'NPADFileSeq',1,10000)
                            into :ll_npadfileseq
                            from dummy
                            using SQLCA; */
                        RDSDataService dataService = RDSDataService.GetNextSequence("NPADFileSeq");
                        ll_npadfileseq = dataService.intVal;
                        if (ll_npadfileseq == null || ll_npadfileseq <= 0)
                        {
                            MessageBox.Show("Failed to obtain sequence number for NPAD XML message filename.  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ls_npadfileseq = DateTime.Now.ToString("fff");
                        }
                        else
                        {
                            ls_npadfileseq = string.Format("{0:0000}", ll_npadfileseq);
                        }
                        is_npadfilename = "RDS_NPAD_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + ls_npadfileseq + ".xml";
                        is_npadoutfile = is_npadoutdir + "\\" + is_npadfilename;
                        /* select f_rds_npad_delete_customer (  :ll_dpid, 
                            :is_userid, :as_description, :is_npadoutfile)
                            into :li_rc
                            from dummy
                            using SQLCA; */
                        dataService = RDSDataService.GetRdsNpadDeleteCustomer(is_npadoutfile, ll_dpid, is_userid, as_description);
                        li_rc = dataService.intVal;
                        //!li_rc = this.WriteXMLFileDeleteCustomer(is_npadoutfile, ll_dpid, is_userid, as_description);
                        if (li_rc > 0)
                        {
                            MessageBox.Show("Error sending delete_customer message.\r\n" + "Return code = " + li_rc + "   ( Invalid DPID) \r\n\r\n" + "DPID    = " + ds_dpid + " ( CustID = " + ds_cust + ", \"Error\" )", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return li_rc;
                        }
                        else if (li_rc < 0)
                        {
                            MessageBox.Show("Error writing XML message file  ( RC=" + li_rc + ").\r\n" + "    " + is_npadoutfile + "\r\n\r\n" + "Possible cause: the output directory may not exist.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return li_rc;
                        }
                    }
                }
            }
            return li_rc;
        }

        public virtual int of_npad_deleteone(int? al_dpid, string as_description)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            //  Send NPAD delete_customer messages for the moved-out customer
            // 
            //  13 Feb 2006  TJB  
            //  Changed filename to include 1/1000ths of a second.
            // 
            //  10 Apr 2006  TJB  NPAD2 fixups
            //  Changed filename to remove 1/1000ths of a second 
            //  and add sequence number.
            // 
            //  20 June 2006  TJB  NPAD2 fixups
            //  Added check for SQL error when writing XML output file.
            int li_rc;
            int? ll_npadfileseq = null;
            string ls_npadfileseq;
            string ds_dpid;
            li_rc = 0;
            RDSDataService dataService;
            //  XML message file info
            /* select f_getNextSequence ( 'NPADFileSeq',1,10000)
                into :ll_npadfileseq
                from dummy
                using SQLCA; */
            dataService = RDSDataService.GetRdsFGetNextSequence();
            ll_npadfileseq = dataService.intVal;
            if (ll_npadfileseq == null || ll_npadfileseq <= 0)
            {
                MessageBox.Show("Failed to obtain sequence number for NPAD XML message filename.  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ls_npadfileseq = DateTime.Now.ToString("fff");
            }
            else
            {
                ls_npadfileseq = string.Format("{0:0000}", ll_npadfileseq);
            }
            is_npadfilename = "RDS_NPAD_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + ls_npadfileseq + ".xml";
            is_npadoutfile = is_npadoutdir + "\\" + is_npadfilename;
            ds_dpid = al_dpid.ToString();
            if (al_dpid == null)
            {
                ds_dpid = "null";
            }
            /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show (  & 'NPAD interface message\r\n\r\n'  & +'Send delete_customer XML message\r\n' & +'   DPID = '+ds_dpid+'\r\n\r\n' & +as_description+'\r\n'   & +is_npadoutfile        ,  'w_maintain_address.of_npad_deleteone' )
            // --------------------------------------------------------------------  */
            if (al_dpid == null || al_dpid < 1)
            {
                MessageBox.Show("The customer DPID is null.  \r\n" + "This may indicate an inconsistency in the database. \r\n\r\n" + "DPID    = " + ds_dpid + '~', "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                /* select f_rds_npad_delete_customer (  :al_dpid, 
                    :is_userid, :as_description, :is_npadoutfile)
                    into :li_rc
                    from dummy
                    using SQLCA; */
                dataService = RDSDataService.GetRdsNpadDeleteCustomer(is_npadoutfile, al_dpid, is_userid, as_description);
                li_rc = dataService.intVal;
                //!li_rc = this.WriteXMLFileDeleteCustomer(is_npadoutfile, al_dpid, is_userid, as_description);
                if (li_rc > 0)
                {
                    ds_dpid = al_dpid.ToString();
                    if (al_dpid == null)
                    {
                        ds_dpid = "null";
                    }
                    MessageBox.Show("Error sending delete_customer message.\r\n" + "Return code = " + li_rc + "   ( Invalid DPID)" + "\r\n\r\nDPID    = " + ds_dpid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (li_rc < 0)
                {
                    MessageBox.Show("Error writing XML message file  ( RC=" + li_rc + ").\r\n" + "    " + is_npadoutfile + "\r\n\r\n" + "Possible cause: the output directory may not exist.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return li_rc;
        }

        public virtual int of_deleteaddress(int? al_adrid)
        {
            //  TJB  NPAD2  Feb 2006  - New -
            //  Delete an address.  Usually an unnumbered, unoccupied address.
            //  Returns
            // 		 0	if successful
            // 		-1	if an error occurs
            int li_rc;
            string ds_adrid;
            /*  ---------------------------- Debugging ----------------------------- //
                if isnull ( al_adrID) then ds_adrid = 'null' else ds_adrid = al_adrID.ToString()
                MessageBox.Show (  & 'Delete the old address.\r\n'  & +'\r\n\r\nAdr_id = '+ds_adrid    ,  'w_maintain_address.of_deleteAddress' )
            // --------------------------------------------------------------------  */
            li_rc = 0;
            /* delete from address
                where adr_id = :al_adrID
                using SQLCA; */
            RDSDataService dataService = RDSDataService.DeleteAdressByAdrId(al_adrid);
            if (dataService.SQLCode < 0)
            {
                if (al_adrid == null)
                {
                    ds_adrid = "null";
                }
                else
                {
                    ds_adrid = al_adrid.ToString();
                }
                MessageBox.Show("A database error has occurred deleting the unoccupied address.\r\n\r\n" + "Address ID = " + ds_adrid + "\r\n\r\n" + "Error code:  " + dataService.SQLDBCode + '~' + "Error message:\r\n    " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //? rollback;
                li_rc = -(1);
            }
            else
            {
                //? commit;
            }
            return li_rc;
        }

        public virtual int of_count_recipients(int? al_master_id)
        {
            int ll_row = -1;
            int ll_from_row;
            int ll_count;
            int ll_rows;
            string ls_condition;
            ll_count = 0;
            //  TJB  NPAD2  Feb 2006  - New -
            //  Count the number of recipients for the specified master, 
            //  in the idw_details data window. 
            if (al_master_id == null)
            {
                al_master_id = 0;
            }
            ll_from_row = 0;
            ll_rows = idw_details.RowCount;
            ls_condition = "master_cust_id = " + al_master_id.ToString();
            while (ll_from_row < idw_details.RowCount)
            {
                //pp! PB line was: ll_row = idw_details.FIND(ls_condition,   &
							//!ll_from_row, idw_details.rowCount())
                //!ll_row = idw_details.Find("master_cust_id", al_master_id);
                ll_row = -1;
                for (int i = ll_from_row; i < idw_details.RowCount; i++)
                {
                    if (idw_details.GetItem<AddressOccupants>(i).MasterCustId == al_master_id)
                    {
                        ll_row = i;
                        break;
                    }
                }

                if (ll_row >= 0)
                {
                    ll_count++;
                    ll_from_row = ll_row + 1;
                }
                else
                {
                    ll_from_row = idw_details.RowCount;
                }
            }
            /*  ---------------------------- Debugging ----------------------------- //
            MessageBox.Show ( & 'Master '+string ( al_master_id)  & +' has '+string ( ll_count)+' recipients. ' ,  'w_maintain_address.of_count_recipients' )
            // --------------------------------------------------------------------  */
            return ll_count;
        }

        public virtual int of_update_to_address_dpid(int? al_new_adr_id, int? al_new_master_dpid)
        {
            //  TJB  NPAD2  March 2006  - New -
            //  Update the DPID of the 'To' address
            /* UPDATE address set dp_id = :al_new_master_dpid
                where adr_id = :al_new_adr_id
                using SQLCA; */
            RDSDataService dataService = RDSDataService.UpdateAddressDpIdByAdrId(al_new_master_dpid, al_new_adr_id);
            if (dataService.SQLCode != 0)
            {
                MessageBox.Show("An error has occurred when updating the record \r\n" + "of the address the customers are transferring to. \r\n\r\n" + "Error code: " + dataService.SQLDBCode + '~' + "Error text: " + dataService.SQLErrText, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dataService.SQLCode;
        }

        public virtual int of_npad_modifyone(int? al_dpid, string as_surname, string as_initials, string as_title)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            //  Send NPAD delete_customer messages for each of the
            //  moved-out customers in the lds_results datastore
            // 
            //  13 Feb 2006  TJB  
            //  Changed filename to include 1/1000ths of a second.
            // 
            //  10 Apr 2006  TJB  NPAD2 fixups
            //  Changed filename to remove 1/1000ths of a second 
            //  and add sequence number.
            // 
            //  20 June 2006  TJB  NPAD2 fixups
            //  Added check for SQL error when writing XML output file.
            int li_rc;
            int? ll_npadfileseq = null;
            string ls_npadfileseq = null;
            string ds_dpid;
            string ls_description;
            li_rc = 0;
            ls_description = "RDS Modify customer name";
            //  XML message file info
            /* select f_getNextSequence ( 'NPADFileSeq',1,10000)
                into :ll_npadfileseq
                from dummy
                using SQLCA; */
            RDSDataService dataService = RDSDataService.GetNextSequence("NPADFileSeq");
            ll_npadfileseq = dataService.intVal;
            if (ll_npadfileseq == null || ll_npadfileseq <= 0)
            {
                MessageBox.Show("Failed to obtain sequence number for NPAD XML message filename.  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ls_npadfileseq = DateTime.Now.ToString("fff");
            }
            else
            {
                ls_npadfileseq = string.Format("{0:0000}", ll_npadfileseq);
            }
            is_npadfilename = "RDS_NPAD_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + ls_npadfileseq + ".xml";
            is_npadoutfile = is_npadoutdir + "\\" + is_npadfilename;
            ds_dpid = al_dpid.ToString();
            if (al_dpid == null)
            {
                ds_dpid = "null";
            }
            /*  ---------------------------- Debugging ----------------------------- //
            string	ds_name
            if not isnull ( as_title) then
            ds_name = as_title
            else
            ds_name = ''
            end if
            if not isnull ( as_initials) then
            if ds_name = '' then
            ds_name = as_initials
            else 
            ds_name = ds_name + " " + as_initials
            end if
            end if
            if not isnull ( as_surname) then
            if ds_name = '' then
            ds_name = as_surname
            else 
            ds_name = ds_name + " " + as_surname
            end if
            end if
            if ds_name = '' then ds_name = 'NULL'
            MessageBox.Show (  & 'NPAD interface message\r\n\r\n'  & +'Send modify_customer XML message\r\n' & +'DPID = '+ds_dpid+'\r\n'       & +ls_description + '\r\n\r\n'      & +'Name = '+ds_name+'\r\n'       & +is_npadoutfile               ,  'w_maintain_address.of_npad_modifyone' )
            // --------------------------------------------------------------------  */
            if (al_dpid == null || al_dpid < 1)
            {
                MessageBox.Show("The customer DPID is null.  \r\n" + "This may indicate an inconsistency in the database. \r\n\r\n" + "DPID    = " + ds_dpid + '~', "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                /* select f_rds_npad_modify_customer (  :al_dpid, 
                    :is_userid, :ls_description, :is_npadoutfile)
                    into :li_rc
                    from dummy
                    using SQLCA; */
                dataService = RDSDataService.GetRdsNpadModifyCustomer(al_dpid, is_userid, is_npadoutfile, ls_description);
                li_rc = dataService.intVal;
                //!li_rc = this.WriteXMLFileModifyCustomer(al_dpid, is_userid, is_npadoutfile, ls_description);
                if (li_rc > 0)
                {
                    MessageBox.Show("Error sending modify_customer message.\r\n" + "Return code = " + li_rc + "\r\n\r\n" + " ( see npad_msg_log table for more detail)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (li_rc < 0)
                {
                    MessageBox.Show("Error writing XML message file  ( RC=" + li_rc + ").\r\n" + "    " + is_npadoutfile + "\r\n\r\n" + "Possible cause: the output directory may not exist.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return li_rc;
        }

        System.Collections.Generic.Dictionary<string, int> ls_filter;

        private bool PredFilterSlName(DddwSuburbNames entity)
        {
            return ls_filter.ContainsKey(entity.SlName);
        }

        public virtual int of_filter_suburb_dddw(string as_roadname, int? al_rtid, int? al_rsid, int? al_tcid)
        {
            //  TJB  NPAD2 Apr 2006  BF016  - New -
            //  Filter suburb dropdown
            int ll_row;
            int ll_rc;
            DDddwSuburbNames ldwc_child;
            //  Get a list of suburbs associated with the road and/or town
            ls_filter = inv_road.of_getsuburblist_asdict1(as_roadname, al_rtid, al_rsid, al_tcid);
            /*  -------------------------- Debugging ----------------------- //
                string	ds_roadname, ds_rtid, ds_rsid, ds_tcid
                ds_roadname = as_roadname
                if isnull ( as_roadname) then ds_roadname = 'NULL'
                ds_rtid = al_rtid.ToString()
                if isnull ( al_rtid) then ds_rtid = 'NULL'
                ds_rsid = al_rsid.ToString()
                if isnull ( al_rsid) then ds_rsid = 'NULL'
                ds_tcid = al_tcid.ToString()
                if isnull ( al_tcid) then ds_tcid = 'NULL'
                MessageBox.Show (   & 'Road name = '+ds_roadname+'\r\n'  & +'Road type = '+ds_rtid+'\r\n'  & +'Road suffix = '+ds_rsid+'\r\n'  & +'Town = '+ds_tcid+'\r\n\r\n'  & +'Filter = '+ls_filter+'\r\n'  & ,  'w_maintain_address.of_filter_suburb_dddw' )
            // ------------------------------------------------------------  */
            ldwc_child = (DDddwSuburbNames)idw_header.GetChild("sl_name");
            ldwc_child.FilterString = "sl_name = \"xxxx\"";
            ldwc_child.Filter<DddwSuburbNames>();
            if (ls_filter.Count != 0)
            {
                //! ldwc_child.FilterString = "sl_name in  ( " + ls_filter + ")";
                ldwc_child.FilterOnce<DddwSuburbNames>(new Predicate<DddwSuburbNames>(PredFilterSlName));
                ls_filter = null;
                ldwc_child.Sort<DddwSuburbNames>();
            }
            return 0;
        }

        Dictionary<int, int> ls_filter2;

        private bool PredFilterTcId(DddwTownOnly entity)
        {
            return (entity.TcId != null) ? ls_filter2.ContainsKey((int)entity.TcId) : false;
        }

        public virtual int of_filter_town_dddw(string as_road_name, int? al_rt_id, int? al_rs_id, string as_sl_name)
        {
            //  TJB  NPAD2 Apr 2006  BF016  - New -
            //  Filter town dropdown
            int ll_row;
            int ll_rc;
            int? ll_rt_id = null;
            int? ll_rs_id = null;
            string ls_road_name = null;
            string ls_sl_name = null;
            DDddwTownOnly ldwc_child;
            //  Get a list of towns associated with the road and/or suburb
            ls_filter2 = inv_road.of_gettownlist_asdict1(ls_road_name, ll_rt_id, ll_rs_id, ls_sl_name);
            /*  -------------------------- Debugging ----------------------- //
                string	ds_road_name, ds_rt_id, ds_rs_id, ds_sl_name
                ds_road_name = ls_road_name
                if isnull ( ls_road_name) then ds_road_name = 'NULL'
                ds_rt_id = ll_rt_id.ToString()
                if isnull ( ll_rt_id) then ds_rt_id = 'NULL'
                ds_rs_id = ll_rs_id.ToString()
                if isnull ( ll_rs_id) then ds_rs_id = 'NULL'
                ds_sl_name = ls_sl_name.ToString()
                if isnull ( ls_sl_name) then ds_sl_name = 'NULL'
                MessageBox.Show (   & 'Road name = '+ds_road_name+'\r\n'  & +'Road type = '+ds_rt_id+'\r\n'  & +'Road suffix = '+ds_rs_id+'\r\n'  & +'Suburb = '+ds_sl_name+'\r\n\r\n'  & +'Filter = '+ls_filter+'\r\n'  & ,  'u_tab_address_search.of_filter_town_dddw' )
            // ------------------------------------------------------------  */
            ldwc_child = (DDddwTownOnly)idw_header.GetChild("tc_id");
            ldwc_child.FilterString = "";
            ldwc_child.Filter<DddwTownOnly>();
            if (ls_filter.Count != 0)
            {
                //! ldwc_child.FilterString = "tc_id in  ( " + ls_filter + ")";
                ldwc_child.FilterOnce<DddwTownOnly>(new Predicate<DddwTownOnly>(PredFilterTcId));
                ls_filter = null;
            }
            ldwc_child.Sort<DddwTownOnly>();
            return 0;
        }

        public virtual int of_filter_suburb_dddw(int? al_tcid)
        {
            //  TJB  NPAD2 Apr 2006  BF016  - New -
            //  Filter suburb dropdown
            //  Find all suburbs associated with the town
            int ll_row;
            int ll_rc;
            int? ll_null = 0;
            string ls_null;
            DDddwSuburbNames ldwc_child;
            ll_null = null;
            ls_null = null;
            //  Get a list of suburbs associated with the road and/or town
            ls_filter = inv_road.of_getsuburblist_asdict1(ls_null, ll_null, ll_null, al_tcid);
            /*  -------------------------- Debugging ----------------------- //
            string	ds_roadname, ds_rtid, ds_rsid, ds_tcid
            ds_roadname = 'NULL'
            ds_rtid = 'NULL'
            ds_rsid = 'NULL'
            ds_tcid = al_tcid.ToString()
            if isnull ( al_tcid) then ds_tcid = 'NULL'
            MessageBox.Show (   & 'Road name    = '+ds_roadname+'\r\n'  & +'Road type   = '+ds_rtid+'\r\n'  & +'Road suffix = '+ds_rsid+'\r\n'  & +'Town        = '+ds_tcid+'\r\n\r\n'  & +'Filter = '+ls_filter+'\r\n'  & ,  'w_maintain_address.of_filter_suburb_dddw' )
            // ------------------------------------------------------------  */
            ldwc_child = (DDddwSuburbNames)idw_header.GetChild("sl_name");
            ldwc_child.FilterString = "sl_name = \"xxxx\"";
            ldwc_child.Filter<DddwSuburbNames>();
            if (ls_filter.Count != 0)
            {
                //! ldwc_child.FilterString = "sl_name in  ( " + ls_filter + ")";
                ldwc_child.FilterOnce<DddwSuburbNames>(new Predicate<DddwSuburbNames>(PredFilterSlName));
                ldwc_child.Sort<DddwSuburbNames>();
            }
            return 0;
        }

        public virtual int? of_get_slid(string as_slname, int? al_tcid)
        {
            //  TJB  NPAD2  Apr 2006   - New -
            //  Get the suburb ID given the suburb's name and mailtown
            //  Returns 0 if no sl_id found  ( suburb not in town).
            int? ll_slid = null;
            /* SELECT sl.sl_id
                INTO :ll_slid
                FROM town_suburb join suburblocality sl
                WHERE sl_name = :as_slname
                AND tc_id   = :al_tcid
                ORDER BY sl_name
                USING SQLCA; */
            RDSDataService dataService = RDSDataService.GetTownSuburSlIdBySlName(al_tcid, as_slname);
            ll_slid = dataService.intVal;
            if (ll_slid == null || ll_slid < 0)
            {
                ll_slid = 0;
            }
            return ll_slid;
        }

        public virtual int of_set_postcode(int? al_tcid, string as_rdno)
        {
            //  TJB  NPAD2  Apr 2006
            //  Modified to set the postcode in the dw_header record given
            //  the tc_id and RD_number
            //  TJB SR4584 13-Oct-2004
            //  Fix bug with postcode when a new address is created.
            //  The post_code itself is only for display.  Need to get 
            //  and set its ID to be saved with the address record.
            // 
            //  Returns
            // 	  1	Success  ( including setting post code to null if there's no town)
            // 	 -1	Failed to determine the post code  ( when the town was known)
            int? ll_null = 0;
            int ll_row;
            int? ll_postcode_id = null;
            string ls_null;
            string ls_rdno;
            string ls_postcode = null;
            string ls_tcname;
            ll_null = null;
            ls_null = null;
            //  Check for an Oamaru RD "number".  If the last character
            //  is not numeric, assume its an Oamaru RD number and use 
            //  last character as the RD number.  Otherwise use the whole
            //  value.
            ls_rdno = as_rdno.Substring(as_rdno.Length - 1, 1);
            if (!(ls_rdno == null) && StaticFunctions.ToInt32(ls_rdno) != null)
            {
                ls_rdno = as_rdno;
            }
            ll_row = idw_header.GetRow();
            if (al_tcid == null || al_tcid <= 0)
            {
                idw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_null;
                idw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_null;
                return 1;
            }
            else
            {
                ls_tcname = idw_header.GetItem<AddressDetails>(ll_row).TownName;
                if (ls_rdno == null)
                {
                    /* SELECT first post_code_id, post_code
                        INTO :ll_postcode_id, :ls_postcode
                        FROM post_code pc, towncity tc
                        WHERE post_mail_town = tc_name
                        AND tc_id  = :al_tcid
                        AND rd_no  is null
                        USING SQLCA; */
                    RDSDataService dataService = RDSDataService.GetFirstPostCodeIdCode(al_tcid);
                    if (dataService.FirstPostCodeIdCodeList.Count > 0)
                    {
                        FirstPostCodeIdCodeItem item = dataService.FirstPostCodeIdCodeList[0];
                        ll_postcode_id = item.PostCodeId;
                        ls_postcode = item.PostCode;
                    }
                }
                else
                {
                    /* SELECT first post_code_id, post_code
                        INTO :ll_postcode_id, :ls_postcode
                        FROM post_code pc, towncity tc
                        WHERE post_mail_town = tc_name
                        AND tc_id  = :al_tcid
                        AND rd_no  = :ls_rdno
                        USING SQLCA; */
                    RDSDataService dataService = RDSDataService.GetFirstPostCodeIdCode(al_tcid, ls_rdno);
                    if (dataService.FirstPostCodeIdCodeList.Count > 0)
                    {
                        FirstPostCodeIdCodeItem item = dataService.FirstPostCodeIdCodeList[0];
                        ll_postcode_id = item.PostCodeId;
                        ls_postcode = item.PostCode;
                    }
                }
            }
            if (ll_postcode_id == null || ll_postcode_id <= 0)
            {
                idw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_null;
                idw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_null;
            }
            else
            {
                idw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_postcode;
                idw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_postcode_id;
                return 1;
            }
            return -(1);
        }

        public virtual int of_set_postcode(int? al_tc_id)
        {
            //  TJB SR4584 13-Oct-2004
            //  Fix bug with postcode when a new address is created.
            //  The post_code itself is only for display.  Need to get
            //  and set its ID to be saved with the address record.
            // 
            //  Returns
            // 	  1	Success  ( including setting post code to null if there's no town)
            // 	 -1	Failed to determine the post code  ( when the town was known)
            int? ll_null = 0;
            int ll_row;
            int? ll_postcode_id = null;
            string ls_null;
            string ls_postcode = null;
            string ls_tcname;
            ll_null = null;
            ls_null = null;
            ll_row = idw_header.GetRow();
            if (al_tc_id == null || al_tc_id < 1)
            {
                idw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_null;
                idw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_null;
                return 1;
            }
            else
            {
                ls_tcname = idw_header.GetItem<AddressDetails>(ll_row).TownName;
                /* SELECT post_code, post_code_id
                    INTO :ls_postcode, :ll_postcode_id
                    FROM post_code pc, towncity tc
                    WHERE post_code =  ( SELECT max ( pc.post_code)
                    FROM post_code pc, towncity tc
                    WHERE tc.tc_id = :al_tc_id
                    AND pc.post_mail_town = tc.tc_name)
                    USING SQLCA; */
                RDSDataService dataService = RDSDataService.GetPostCodeIdCode(al_tc_id);
                if (dataService.PostCodeIdCodeList.Count > 0)
                {
                    PostCodeIdCodeItem item = dataService.PostCodeIdCodeList[0];
                    ls_postcode = item.PostCode;
                    ll_postcode_id = item.PostCodeId;
                }
            }
            if (ll_postcode_id == null || ll_postcode_id <= 0)
            {
                idw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_null;
                idw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_null;
            }
            else
            {
                idw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_postcode_id;
                idw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_postcode;
                return 1;
            }
            return -(1);
        }

        public virtual string of_getpermissions(string as_name)
        {
            //   TJB  NPAD2  May 2006  - New -
            //  Get a string of the user's permissions given a component name
            //  Returns some or all of "CRMD" or null
            int? ll_componentid = 0;
            int? ll_regionid = 0;
            string ls_perms;
            ll_regionid = this.of_get_regionid();
            ll_componentid = StaticVariables.securitymanager.of_get_componentid(as_name);
            ls_perms = "";
            if (StaticVariables.securitymanager.of_get_user().of_hasprivilege(ll_componentid, ll_regionid, "C", false))
            {
                ls_perms += "C";
            }
            if (StaticVariables.securitymanager.of_get_user().of_hasprivilege(ll_componentid, ll_regionid, "R", false))
            {
                ls_perms += "R";
            }
            if (StaticVariables.securitymanager.of_get_user().of_hasprivilege(ll_componentid, ll_regionid, "M", false))
            {
                ls_perms += "M";
            }
            if (StaticVariables.securitymanager.of_get_user().of_hasprivilege(ll_componentid, ll_regionid, "D", false))
            {
                ls_perms += "D";
            }
            if (ls_perms == "")
            {
                ls_perms = null;
            }
            return ls_perms;
        }

        public virtual int of_validcontract(int? al_contractno)
        {
            //  TJB  SR4688  July 2006   - New -
            //  Check thatn the contract number entered is valid
            //   ( ie not terminated or expired).
            //  Returns:
            // 		0		Contract exists and is current
            // 		1		Contract does not exist
            // 		2		Contract is terminated
            // 		3		Contract is not current
            int? ll_exists = 0;
            DateTime? ld_terminated = null;
            DateTime? ld_today;
            ll_exists = null;
            /* select contract_no, con_date_terminated
                into :ll_exists, :ld_terminated
                from contract
                where contract.contract_no = :al_contractNo
                using SQLCA; */
            RDSDataService dataService = RDSDataService.GetContractNoConDateTerminated(al_contractno);
            if (dataService.ContractNoConDateTerminatedList.Count > 0)
            {
                ContractNoConDateTerminatedItem item = dataService.ContractNoConDateTerminatedList[0];
                ll_exists = item.ContractNo;
                ld_terminated = item.ConDateTerminated;
            }
            ld_today = System.DateTime.Today;
            if (ll_exists == null || ll_exists < 1)
            {
                return 1;
            }
            else if (!(ld_terminated == null) && ld_terminated < ld_today)
            {
                return 2;
            }
            ll_exists = null;
            /* select 1
                into :ll_exists
                from contract_renewals
                where contract_renewals.contract_no = :al_contractNo
                and today ( ) between contract_renewals.con_start_date 
                and contract_renewals.con_expiry_date
                using SQLCA; */
            dataService = RDSDataService.GetContractRenewalsExists(al_contractno);
            ll_exists = dataService.intVal;
            if (ll_exists == null || ll_exists < 1)
            {
                return 3;
            }
            return 0;
        }

        public virtual int? of_get_addr_dpid(int? al_adrid)
        {
            //  TJB  NPAD 2.1  May 2007
            //  Get the DPID of an address given its adr_id
            // 
            //  Returns the dp_id, or 0 if none.
            int? ll_dpid = null;
            /* SELECT dp_id
                INTO :ll_dpid
                FROM address
                WHERE adr_id = :al_adrid
                USING SQLCA; */
            RDSDataService dataService = RDSDataService.GetAddressDpIdByAdrId(al_adrid);
            ll_dpid = dataService.intVal;
            if (ll_dpid == null)
            {
                ll_dpid = 0;
            }
            return ll_dpid;
        }

        public virtual int of_npad_addr_occupied(int? al_dpid, string as_occupied, string as_description)
        {
            //  TJB  NPAD2.1  May 2007  - New -
            //  Send NPAD address_occupied message
            int li_rc;
            int? ll_npadfileseq = null;
            string ls_npadfileseq;
            string ds_name;
            string ds_dpid = "";
            string ds_cust;
            li_rc = 0;
            if (al_dpid == null || al_dpid < 1)
            {
                if (al_dpid == null)
                {
                    ds_dpid = "NULL";
                }
                else
                {
                    ds_dpid = al_dpid.ToString();
                }
                MessageBox.Show("The address DPID is invalid.  \r\n" + "This may indicate an inconsistency in the database. \r\n\r\n" + "DPID    = " + ds_dpid, "Warning");
            }
            else
            {
                //  XML message file info
                /* select f_getNextSequence ( 'NPADFileSeq',1,10000)
                    into :ll_npadfileseq
                    from dummy
                    using SQLCA; */
                RDSDataService dataService = RDSDataService.GetNextSequence("NPADFileSeq");
                ll_npadfileseq = dataService.intVal;
                if (ll_npadfileseq == null || ll_npadfileseq <= 0)
                {
                    MessageBox.Show("Failed to obtain sequence number for NPAD XML message filename.  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ls_npadfileseq = DateTime.Now.ToString("fff");
                }
                else
                {
                    ls_npadfileseq = string.Format("{0:0000}", ll_npadfileseq);
                }
                is_npadfilename = "RDS_NPAD_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + ls_npadfileseq + ".xml";
                is_npadoutfile = is_npadoutdir + "\\" + is_npadfilename;
                /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show ( & "Message file = "+is_npadoutfile       + "\r\n" & +"DPID = " + string ( al_dpid)           + "\r\n" & +"Occupied = "+as_occupied ,  'w_maintain_address.of_npad_addr_occupied' )
                // --------------------------------------------------------------------  */
                /* select f_rds_npad_addr_occupied (  :al_dpid, :as_occupied, 
                    :is_userid, :as_description, :is_npadoutfile)
                    into :li_rc
                    from dummy
                    using SQLCA; */
                dataService = RDSDataService.GetRdsNpadAddrOccupied(as_occupied, is_npadoutfile, al_dpid, is_userid, as_description);
                li_rc = dataService.intVal;
                //!li_rc = this.WriteXMLFileAddressOccupied(as_occupied, is_npadoutfile, al_dpid, is_userid, as_description);

                if (li_rc > 0)
                {
                    MessageBox.Show("Error sending delete_customer message.\r\n" + "Return code = " + li_rc + "   ( Invalid DPID) \r\n\r\n" + "DPID    = " + ds_dpid, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return li_rc;
                }
                else if (li_rc < 0)
                {
                    MessageBox.Show("Error writing XML message file  ( RC=" + li_rc + ").\r\n" + "    " + is_npadoutfile + "\r\n\r\n" + "Possible cause: the output directory may not exist.", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return li_rc;
                }
            }
            return li_rc;
        }

      

        public virtual bool of_iscontractrd(int? al_adrid)
        {
            //  TJB  NPAD2.1  May 2007  - New -
            //  Determine if the address is associated with a Rural Delivery contract
            // 
            //  Returns TRUE or FALSE
            bool lb_return;
            int ll_match_count = 0;
            int ll_contract_type_rd = 1;
            lb_return = false;
            //  Select the contract type for the given contract
            //  Validate that the contract # is valid 
            /* SELECT 	count ( *) INTO :ll_match_count
                FROM	address a, types_for_contract tfc
                WHERE	a.adr_id = :al_adrID
                AND	tfc.contract_no = a.contract_no
                AND	ct_key = :ll_contract_type_rd
                USING	SQLCA; */
            RDSDataService dataService = RDSDataService.GetAddressCountByAdrId(al_adrid, ll_contract_type_rd);
            ll_match_count = dataService.intVal;
            if (dataService.SQLCode != 0)
            {
                //  DB Error
                if (!ib_closestatus)
                {
                    MessageBox.Show("A database error has occurred. \r\n\r\n" + "Database error code:  " + dataService.SQLDBCode + '~' + "Database error message:\r\n" + "    " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (ll_match_count > 0)
            {
                //  this is RD type
                lb_return = true;
            }
            /*  ---------------------------- Debugging ----------------------------- //
            MessageBox.Show ( & "Adr ID  " + string ( al_adrID)   + "\r\n" & +"RD Contract? "+string ( lb_return,  'w_maintain_address.of_iscontractRD' )
            // --------------------------------------------------------------------  */
            return lb_return;
        }

        public virtual void of_display_ldsresults()
        {
            //  TJB  NPAD2  *** for debugging only ***
            int ll_row;
            int ll_rows;
            int? ll_custid = 0;
            int? ll_master = 0;
            int? ll_dpid = 0;
            DateTime? ldt_mod;
            string ls_surname;
            string ls_initials;
            string ls_msg;
            ll_rows = ids_results.RowCount;
            ls_msg = "Rows = " + ll_rows.ToString() + '~';
            ls_msg += "row, cust, dpid, master, mod, name\r\n";
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                ll_custid = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustId;
                ll_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                ll_master = ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId;
                ldt_mod = ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate;
                ls_surname = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustSurnameCompany;
                ls_initials = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustInitials;
                ls_msg += ll_row.ToString() + ", ";
                if (ll_custid == null)
                {
                    ls_msg += "null";
                }
                else
                {
                    ls_msg += ll_custid.ToString();
                }
                ls_msg += ", ";
                if (ll_dpid == null)
                {
                    ls_msg += "null";
                }
                else
                {
                    ls_msg += ll_dpid.ToString();
                }
                ls_msg += ", ";
                if (ll_master == null)
                {
                    ls_msg += "null";
                }
                else
                {
                    ls_msg += ll_master.ToString();
                }
                ls_msg += ", ";
                if (ldt_mod == null)
                {
                    ls_msg += "null";
                }
                else
                {
                    ls_msg += ldt_mod.ToString();
                }
                ls_msg += ", ";
                if (!(ls_initials == null))
                {
                    ls_msg += ls_initials.ToString() + " ";
                }
                if (ls_surname == null)
                {
                    ls_msg += "null";
                }
                else
                {
                    ls_msg += ls_surname;
                }
                ls_msg += '~';
            }
            MessageBox.Show("***** lds_results ***** \r\n\r\n" + ls_msg, "w_maintain_address.of_display_ldsresults", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public virtual void of_transfer_custs(int? al_new_master_id)
        {
            //  TJB  NPAD2  Feb 06  - New -
            //  ---------------------------------------
            //  Transfer the customers as recipients
            //  ---------------------------------------
            //  Mark all the customers who are transferring as recipients 
            //  of the master at the new address  ( including the transferring 
            //  master).
            int ll_row;
            int ll_this_cust_row;
            int? ll_this_cust_id = 0;
            int? ll_this_cust_master = null;
            int? ll_null = 0;
            string ls_null;
            ll_null = null;
            ls_null = null;
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_new_master
                ds_new_master = al_new_master_id.ToString()
                if isnull ( al_new_master_id) then ds_new_master = 'null'
                MessageBox.Show ( & 'ids_results.rowcount = '+string ( ids_results.rowcount ( ))+'\r\n'  & +'New master = '+ds_new_master ,  'w_maintain_address.of_transfer_custs' )
            // --------------------------------------------------------------------  */
            //  Work through all the transferring customers
            for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
            {
                //  If this entry is the current active one
                if (ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null)
                {
                    //  For each transferring customer, get some relevant details
                    ll_this_cust_id = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustId;
                    ll_this_cust_master = ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId;
                    ll_this_cust_row = idw_details.Find("cust_id", ll_this_cust_id);
                    //  Set the new master ID in both the results datastore 
                    //  and details datawindow.
                    ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId = al_new_master_id;
                    idw_details.GetItem<AddressOccupants>(ll_this_cust_row).MasterCustId = al_new_master_id;
                    //  If this is the master who is transferring ...
                    if (ll_this_cust_master == null)
                    {
                        //  Demote him/her to a recipient.
                        idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustBusiness = ls_null;
                        idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustRuralResident = ls_null;
                        idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustRuralFarmer = ls_null;
                        idw_details.GetItem<AddressOccupants>(ll_this_cust_row).CustAdpostQuantity = ll_null;
                    }
                }
            }
        }

        public virtual void of_copy_dpids()
        {
            //  TJB  NPAD2  Feb 06  - New -
            //  ---------------------------------------
            //  Copy the dummy's DPIDs
            //  ---------------------------------------
            //  Copy the DPIDs from the dummy customers to the transferring customers
            int ll_row;
            int ll_this_cust_row;
            int? ll_this_cust_id = 0;
            int? ll_this_cust_dpid = 0;
            int? ll_this_cust_master = 0;
            /*  ---------------------------- Debugging ----------------------------- //
            MessageBox.Show ( & 'ids_results.rowcount = '+string ( ids_results.rowcount ( ),  'w_maintain_address.of_copy_dpids' )
            // --------------------------------------------------------------------  */
            //  Work through all the transferring customers
            for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
            {
                //  If this entry is the current active one
                if (ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null)
                {
                    //  For each transferring customer, get some relevant details
                    ll_this_cust_id = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustId;
                    ll_this_cust_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                    ll_this_cust_master = ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId;
                    ll_this_cust_row = idw_details.Find("cust_id", ll_this_cust_id);
                    if (ll_this_cust_master == null)
                    {
                        //  This customer is the master.  
                        //  Copy the dummy master's DPID, 
                        //  otherwise copy a dummy recipient's.
                        ll_this_cust_dpid = il_dummy_master_dpid;
                        il_dummy_master_status = 1;
                    }
                    else
                    {
                        //  Copy a dummy recipient's DPID.
                        //  NOTE: we shouldn't run off the end of the 
                        //  il_dummy_dpid[] array because we already checked 
                        //  that there would be enough dummy values.
                        il_dummy_dpid_row++;
                        ll_this_cust_dpid = il_dummy_dpid[il_dummy_dpid_row];
                        il_dummy_status[il_dummy_dpid_row] = 1;
                    }
                    ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId = ll_this_cust_dpid;
                    idw_details.GetItem<AddressOccupants>(ll_this_cust_row).DpId = ll_this_cust_dpid;
                }
            }
        }

        public virtual void of_delete_recipient(int? al_custid)
        {
            //  TJB  NPAD2  Mar 2006  - New
            //  Delete a customer from the customer_address_moves 
            //  and rds_customer tables.
            int ll_row;
            //  Delete a customer from the customer_address_moves 
            ll_row = ids_results.Find("cust_id", al_custid);
            ids_results.DeleteItemAt(ll_row);
            //  and from the rds_customer tables
            ll_row = idw_details.Find("cust_id", al_custid);
            if (!(ll_row == -1) && ll_row >= 0)
            {
                idw_details.DeleteItemAt(ll_row);
            }
        }

        public virtual void of_disable_header_maint()
        {
            //  TJB  NPAD2  Mar 2006   - New -
            //  Disable access to the address area of the window  ( dw_header)
            //  Called when NPAD is enabled and we're processing a Rural Delivery 
            //  contract.
            //  Set the taborder for the fields to 0 
            //  so the user can't access them.
            ((TextBox)(idw_header.DataObject.Controls["dp_id"])).ReadOnly = true;//idw_header.DataObject.Controls["dp_id"].Enabled = false;

            ((TextBox)(idw_header.DataObject.Controls["adr_num"])).ReadOnly = true;//idw_header.DataObject.Controls["adr_num"].Enabled = false;

            ((TextBox)(idw_header.DataObject.Controls["road_name"])).ReadOnly = true;//idw_header.DataObject.Controls["road_name"].Enabled = false;

            ((Metex.Windows.DataEntityCombo)(idw_header.DataObject.Controls["rt_id"])).Enabled = false; ;//idw_header.DataObject.Controls["rt_id"].Enabled = false;

            ((Metex.Windows.DataEntityCombo)(idw_header.DataObject.Controls["rs_id"])).Enabled = false;//idw_header.DataObject.Controls["rs_id"].Enabled = false;

            // idw_header.setTabOrder ( 'sl_id',0)
            ((Metex.Windows.DataEntityCombo)(idw_header.DataObject.Controls["sl_name"])).Enabled = false;//idw_header.DataObject.Controls["sl_name"].Enabled = false;

            ((Metex.Windows.DataEntityCombo)(idw_header.DataObject.Controls["tc_id"])).Enabled = false;//idw_header.DataObject.Controls["tc_id"].Enabled = false;

            ((TextBox)(idw_header.DataObject.Controls["adr_rd_no"])).ReadOnly = true;//idw_header.DataObject.Controls["adr_rd_no"].Enabled = false;

            ((TextBox)(idw_header.DataObject.Controls["post_code"])).ReadOnly = true;//idw_header.DataObject.Controls["post_code"].Enabled = false;

            ((TextBox)(idw_header.DataObject.Controls["adr_property_identification"])).ReadOnly = true;//idw_header.DataObject.Controls["adr_property_identification"].Enabled = false;

            ((PictureBox)dw_header.GetControlByName("contract_button")).Enabled = true;

            if (!(StaticVariables.LoginId == "sysadmin"))
            {
                ((System.Windows.Forms.MaskedTextBox)(idw_header.DataObject.Controls["contract_no"])).BackColor = System.Drawing.SystemColors.Control;
            }

            //  Set the background for each field to transparent,
            //  to provide a visual cue that the fields aren't 
            //  updateable.
            ((System.Windows.Forms.TextBox)idw_header.GetControlByName("road_name")).BackColor = System.Drawing.SystemColors.Control;
            ((System.Windows.Forms.TextBox)idw_header.GetControlByName("adr_rd_no")).BackColor = System.Drawing.SystemColors.Control;
            ((Metex.Windows.DataEntityCombo)idw_header.GetControlByName("tc_id")).BackColor = System.Drawing.SystemColors.Control;

            /*? idw_header.GetControlByName("dp_id").Background.mode = 1;
            idw_header.GetControlByName("adr_num").Background.mode = 1;
            idw_header.GetControlByName("road_name").Background.mode = 1;
            idw_header.GetControlByName("rt_id").Background.mode = 1;
            idw_header.GetControlByName("rs_id").Background.mode = 1;
            // idw_header.GetControlByName("sl_id").Background.mode = 1
            idw_header.GetControlByName("sl_name").Background.mode = 1;
            idw_header.GetControlByName("tc_id").Background.mode = 1;
            idw_header.GetControlByName("adr_rd_no").Background.mode = 1;
            idw_header.GetControlByName("post_code").Background.mode = 1;
            idw_header.GetControlByName("adr_property_identification").Background.mode = 1;
            idw_header.GetControlByName("dp_id").Border = 0; */
            return;
        }

        private object LogonAttrib(MaskedTextBox maskedTextBox)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void of_get_addr_criteria(NCriteria lvNCriteria)
        {
            int? ll_rtid = 0;
            int? ll_rsid = 0;
            int? ll_tcid = 0;
            int? ll_slid = 0;
            string ls_adrnum;
            string ls_roadname;
            string ls_rdno;
            ls_adrnum = (string)lvNCriteria.of_getcriteria("adr_no");
            if (!(ls_adrnum == null))
            {
                idw_header.GetItem<AddressDetails>(0).AdrNum = ls_adrnum;
            }
            ls_roadname = (string)lvNCriteria.of_getcriteria("road_name");
            if (!(ls_roadname == null))
            {
                idw_header.GetItem<AddressDetails>(0).RoadName = ls_roadname;
                // 		idw_header.Event ue_filter_dropdowns ( 1, 'road_name', ls_temp)
            }
            ll_rtid = (int)lvNCriteria.of_getcriteria("rt_id");
            if (!(ll_rtid == null))
            {
                idw_header.GetItem<AddressDetails>(0).RtId = ll_rtid;
                // 		idw_header.Event ue_filter_dropdowns ( 1, 'rt_id', ll_temp).ToString()
            }
            ll_rsid = (int)lvNCriteria.of_getcriteria("rs_id");
            if (!(ll_rsid == null))
            {
                idw_header.GetItem<AddressDetails>(0).RsId = ll_rsid;
                // 		idw_header.Event ue_filter_dropdowns ( 1, 'rs_id', ll_temp).ToString()
            }
            ll_slid = (int)lvNCriteria.of_getcriteria("sl_id");
            if (!(ll_slid == null))
            {
                idw_header.GetItem<AddressDetails>(0).SlId = ll_slid;
                ib_sub_selected = true;
                ib_sub_sent = true;
                il_selected_sub = (int)ll_slid;
                // 		idw_header.Event ue_filter_dropdowns ( 1, 'sl_id', ll_temp).ToString()
            }
            ll_tcid = (int)lvNCriteria.of_getcriteria("tc_id");
            if (!(ll_tcid == null))
            {
                idw_header.GetItem<AddressDetails>(0).TcId = ll_tcid;
                ib_town_selected = true;
                ib_town_sent = true;
                il_selected_town = (int)ll_tcid;
                // 		idw_header.Event ue_filter_dropdowns ( 1, 'tc_id', il_selected_town).ToString()
                //  TWC - make call to populate the postcode with the correct info
                this.of_set_postcode(ll_tcid);
            }
            ls_rdno = (string)lvNCriteria.of_getcriteria("adr_rd_no");
            if (!(ls_rdno == null))
            {
                idw_header.GetItem<AddressDetails>(0).AdrRdNo = ls_rdno;
            }
        }

        public virtual void of_enablesuburb(bool ab_flag)
        {
            //  TJB  NPAD2  Apr/May 2006   - New -
            //  Enable or disable suburb entry
            // 
            //   ( Note: il_oldsuburbtab is set in the pfc_preopen event)
            if (ab_flag)
            {
                idw_header.DataObject.Controls["sl_name"].Enabled = true; //added by jlwang
                idw_header.DataObject.Controls["sl_name"].TabIndex = il_oldsuburbtab;
                //? idw_header.GetControlByName("sl_name").Background.mode = 0;
            }
            else
            {
                idw_header.DataObject.Controls["sl_name"].Enabled = false;//.TabStop = false;
                //? idw_header.GetControlByName("sl_name").Background.mode = 1;
            }
        }

        private bool FindNullMasterCustId(AddressOccupants entity)
        {
            return entity.MasterCustId == null;
        }

        public virtual void of_findmaster()
        {
            //  TJB  SR4686  June 2006   - New -
            //  Find a master customer in the dw_details datawindow
            //  and set focus on it.
            int ll_master_cust_row;
            ll_master_cust_row = idw_details.FindIf<AddressOccupants>(FindNullMasterCustId);

            //?if (ll_master_cust_row == null)
            //{
            //    ll_master_cust_row = -1;
            //}

            if (ll_master_cust_row >= 0)
            {
                idw_details.SetCurrent(ll_master_cust_row);
                idw_details.SelectRow(0, false);
                idw_details.SelectRow(ll_master_cust_row + 1, true);
            }
        }

        public virtual void dw_header_ue_filter_dropdowns(int row, string col_name, string data)
        {
            int ll_row;
            int? ll_road_id = 0;
            int? ll_rt_id = 0;
            int? ll_rs_id = 0;
            int? ll_sl_id = 0;
            int? ll_tc_id = 0;
            int ll_currentrow;
            int? ll_null = 0;
            int? ll_temp = 0;
            string ls_null;
            string ls_temp;
            string ls_road_name;
            string ls_sl_name = null;
            string ls_rdno;
            bool lb_suburb_filtered;
            bool lb_town_filtered;
            DataUserControl ldwc_child;
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Add road suffix processing
            ll_null = null;
            ls_null = null;
            ll_row = dw_header.GetRow();
            /*  ---------------------------- Debugging ----------------------------- //
                ls_temp = data
                if isnull ( ls_temp) then ls_temp = 'NULL'
                MessageBox.Show ( & 'Row = '+string ( row)+'\r\n'  & +'Column = '+col_name+'\r\n'  & +'Data   = '+ls_temp  ,  'w_maintain_address.dw_header.ue_filter_dropdowns' )
                // --------------------------------------------------------------------  */
            /* *************************************************************
            * Road name changed
            ************************************************************* */
            if (col_name == "road_name")
            {
                ls_road_name = data;
                ll_rs_id = null;
                dw_header.GetItem<AddressDetails>(ll_row).RsId = ll_null;
                ll_rt_id = null;
                dw_header.GetItem<AddressDetails>(ll_row).RtId = ll_null;
                //  Filter Road Type
                ldwc_child = dw_header.GetChild("rt_id");
                //if (inv_road.of_filterroadtype(ls_road_name, ref ldwc_child))
                if (inv_road.of_filterroadtype1(ls_road_name, ref ldwc_child))
                {
                    if (((DataEntityCombo)dw_header.GetControlByName("rt_id")).Items.Count > 0)//! if no rows do not assign index
                    {
                        ((DataEntityCombo)dw_header.GetControlByName("rt_id")).SelectedIndex = 0;// ldwc_child.SetCurrent(0);
                    }
                    ll_currentrow = ldwc_child.GetRow();
                    if (ll_currentrow >= 0)
                    {
                        ll_rt_id = ldwc_child.GetItem<DddwRoadType>(ll_currentrow).RtId;
                        dw_header.GetItem<AddressDetails>(ll_row).RtId = ll_rt_id;
                    }
                }
                else
                {
                    //  drop list and clear the selected type.
                    //?ldwc_child.FilterString = "";
                    //?ldwc_child.Filter<DddwRoadType>();
                    dw_header.GetItem<AddressDetails>(ll_row).RtId = ll_null;
                }
                //  Filter Road Suffix
                ldwc_child = dw_header.GetChild("rs_id");
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentrow = ldwc_child.GetRow();
                    if (ll_currentrow > 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentrow).RsId;
                        dw_header.GetItem<AddressDetails>(ll_row).RsId = ll_rs_id;
                    }
                }
                else
                {
                    //  drop list and clear the selected type.
                    //?ldwc_child.FilterString = "";
                    //?ldwc_child.Filter<DddwRoadSuffix>();
                    ldwc_child.Retrieve();
                    dw_header.GetItem<AddressDetails>(ll_row).RsId = ll_null;
                }
            }
            /* *************************************************************
            * Road type changed
            * Change the road suffix dropdown as appropriate.
            ************************************************************* */
            if (col_name == "rt_id")
            {
                ls_road_name = dw_header.GetItem<AddressDetails>(row).RoadName;
                ll_rt_id = StaticFunctions.ToInt32(data);
                ll_rs_id = null;
                dw_header.GetItem<AddressDetails>(ll_row).RsId = ll_null;
                //  Filter Road Suffix
                ldwc_child = dw_header.GetChild("rs_id");
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentrow = ldwc_child.GetRow();
                    if (ll_currentrow >= 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentrow).RsId;
                        dw_header.GetItem<AddressDetails>(ll_row).RsId = ll_rs_id;
                    }
                }
                else
                {
                    //  drop list and clear the selected type.
                    ldwc_child.FilterString = "";
                    ldwc_child.Filter<DddwRoadSuffix>();
                    dw_header.GetItem<AddressDetails>(ll_row).RsId = ll_null;
                }
            }
            /* *************************************************************
            * Town changed
            ************************************************************* */
            if (col_name == "tc_id")
            {
                int ll_tc_id_temp;
                ll_tc_id = StaticFunctions.ToInt32(data);
                //  TJB  NPAD2  Apr/May 2006
                //  The town dropdown list won't be filtered for address 
                //  maintenance since the user may be creating a new address
                //  and we don't want to restrict where that is.  If the 
                //  road/suburb/town is new, the user will be asked to confirm
                //  the details when saving the new or modified address.
                //  		// Filter town dropdown list
                //  	of_filter_town_dddw (  ls_road_name, ll_rt_id, ll_rs_id, ls_sl_name )
                //  Check to see if a town had already been selected.
                //  If so, try to keep that selection
                lb_town_filtered = false;
                if (!(ll_tc_id == null) && ll_tc_id > 0)
                {
                    ldwc_child = dw_header.GetChild("tc_id");
                    ll_temp = ldwc_child.Find("tc_id", ll_tc_id);
                    if (ll_temp >= 0)
                    {
                        lb_town_filtered = true;
                    }
                }
                if (lb_town_filtered)
                {
                    dw_header.GetItem<AddressDetails>(ll_row).TcId = ll_tc_id;
                }
                else
                {
                    dw_header.GetItem<AddressDetails>(ll_row).TcId = ll_null;
                }
                //  If there is a selected town, 
                if (lb_town_filtered)
                {
                    //  Enable suburb selection
                    of_enablesuburb(true);
                    //  filter the suburb dropdown list
                    of_filter_suburb_dddw(ll_tc_id);
                    //  Check to see if a suburb had already been selected.
                    //  If so, try to keep that selection
                    lb_suburb_filtered = false;
                    if (!(ls_sl_name == null) && !(ls_sl_name == ""))
                    {
                        ldwc_child = dw_header.GetChild("sl_name");
                        ll_temp = ldwc_child.Find("sl_name", ls_sl_name);
                        if (ll_temp >= 0)
                        {
                            lb_suburb_filtered = true;
                        }
                    }
                    if (lb_suburb_filtered)
                    {
                        dw_header.GetItem<AddressDetails>(ll_row).SlName = ls_sl_name;
                    }
                    else
                    {
                        dw_header.GetItem<AddressDetails>(ll_row).SlName = ls_null;
                        dw_header.GetItem<AddressDetails>(ll_row).SlId = ll_null;
                    }
                }
                else
                {
                    //  in the dropdown list
                    ldwc_child = dw_header.GetChild("sl_name");
                    ldwc_child.FilterString = "sl_name = \"xxxx\"";
                    ldwc_child.Filter<DddwSuburbNames>();
                    dw_header.GetItem<AddressDetails>(ll_row).SlName = ls_null;
                    dw_header.GetItem<AddressDetails>(ll_row).SlId = ll_null;
                    //  Disable the suburb selection until a town
                    //  has been selected.
                    of_enablesuburb(false);
                }
                //  Update the post code
                if (!(ll_tc_id == null) && ll_tc_id > 0)
                {
                    //  If a town has been specified, we need to look up the post code
                    if (ib_RDcontract)
                    {
                        //  If this is a RD contract, we need both the mailtown and RD number
                        ls_rdno = dw_header.GetItem<AddressDetails>(ll_row).AdrRdNo;
                        if (!(ls_rdno == null) && !(ls_rdno == ""))
                        {
                            of_set_postcode(ll_tc_id, ls_rdno);
                        }
                        else
                        {
                            //  If we don't have an RD number yet, clear the post code
                            //  We'll fill it in when we validate the address  ( see pfc_validation)
                            dw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_null;
                            dw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_null;
                        }
                    }
                    else
                    {
                        //  This is a non-RD contract.  Look up the post code
                        //  by mailtown only  ( RD number null).
                        of_set_postcode(ll_tc_id);
                    }
                    /*  ---------------------------- Debugging ----------------------------- //
                    string	ls_postcode
                    ls_postcode = this.getItemString ( ll_row,'post_code')
                    if isnull ( ls_postcode) or ls_postcode = '' then
                    MessageBox.Show (   & 'Unable to determine post code for mailtown.',  'w_maintain_address.dw_header.ue_filter_dropdowns' )
                    end if
                    // --------------------------------------------------------------------  */
                }
                else
                {
                    //  No town specified; clear the post code
                    dw_header.GetItem<AddressDetails>(ll_row).PostCode = ls_null;
                    dw_header.GetItem<AddressDetails>(ll_row).PostCodeId = ll_null;
                }
            }
            /* *************************************************************
            * Suburb changed
            ************************************************************* */
            //  TJB  NPAD2  Apr/May 2006
            //  Since the suburb can only have a value related to the selected 
            //  town, any suburb changes are allowed and don't affect anything 
            //  else.
            if (col_name == "sl_name")
            {
                ls_sl_name = data;
                ll_tc_id = dw_header.GetItem<AddressDetails>(0).TcId;
                if (ll_tc_id == null && ll_tc_id <= 0)
                {
                    MessageBox.Show("Please select a town before selecting a suburb.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ll_sl_id = of_get_slid(data, ll_tc_id);
                    if (ll_sl_id > 0)
                    {
                        dw_header.GetItem<AddressDetails>(0).SlId = ll_sl_id;
                    }
                    else
                    {
                        dw_header.GetItem<AddressDetails>(0).SlId = ll_null;
                        dw_header.GetItem<AddressDetails>(0).SlName = ls_null;
                    }
                }
            }
            //? dw_header.SelectText(1, 500);
        }

        public virtual void dw_header_ue_add_to_dropdown(DataUserControl adwc_child, string as_dbname, int al_row)
        {
            int? ll_id = 0;
            //  move from Filtered! buffer back to Primary! buffer
            //? adwc_child.RowsMove(al_row, al_row, filter!, adwc_child, 1, primary!);
            // ll_row = adwc_child.InsertRow ( 0)
            // adwc_child.SetItem ( ll_row, as_id_dbname, al_id)
            // adwc_child.SetItem ( ll_row, as_name_dbname, as_name)
            adwc_child.SetCurrent(1);
            ll_id = adwc_child.GetValue<int>(1, as_dbname);
            dw_header.SetValue(1, as_dbname, ll_id);
        }

        public virtual int dw_header_ue_validate_dropdown(long row, string dwo, string data)
        {
            List<int?> ll_idarray = new List<int?>();
            int ll_x;
            int? ll_null = 0;
            int? ll_id = 0;
            int? ll_temp = 0;
            string ls_id;
            string ls_temp;
            bool lb_matched = false;
            DataUserControl lds_temp;
            DataUserControl ldwc_child;
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Add road suffix validation
            //       Oct 2005:  Added test for rt_id and rs_id = null 
            //                  matching road type and suffix respectively
            ll_null = null;
            //  Only need to validate if data is a numeric value
            //  otherwise the normal ItemError event would
            //  have kicked in validating string entries
            //  If the numeric value entered is not an exisitng
            //  value in the drop list, reject the entry
            if (StaticFunctions.ToInt32(data) == null)
            {
                return 0;
            }
            if (ll_id == null)
            {
                ls_id = "NULL";
            }
            else
            {
                ls_id = ll_id.ToString();
            }
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_col_name
                ls_temp = data
                ds_col_name = column
                if isnull ( ls_temp) then ls_temp = 'NULL'
                MessageBox.Show ( & 'Row = '+string ( row)+'\r\n'      & +'Column = '+ds_col_name+'\r\n'  & +'Data   = '+ls_temp  ,  'w_maintain_address.dw_header.ue_validate_dropdown' )
            // --------------------------------------------------------------------  */
            if (dwo == "rt_id")
            {
                lds_temp = new DDddwRoadType();
                ldwc_child = dw_header.GetChild("rt_id");
                ldwc_child.ShareData(lds_temp);
                if (lds_temp.RowCount > 0)
                {
                    //? ll_idarray = lds_temp.GetControlByName("rt_id").Primary;
                    for (ll_x = 0; ll_x < ll_idarray.Count; ll_x++)
                    {
                        ll_temp = ll_idarray[ll_x];
                        if (ll_temp == ll_id)
                        {
                            lb_matched = true;
                            break;
                        }
                        else if (ll_temp == null && ll_id == null)
                        {
                            lb_matched = true;
                            break;
                        }
                    }
                }
                if (lb_matched)
                {
                    return 0;
                }
                else
                {
                    //  Not a valid road type
                    MessageBox.Show('\'' + ls_id + "\' is not a valid road type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).RtId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).RsId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).SlId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).TcId = ll_null;
                    return 2;
                }
            }
            else if (dwo == "rs_id")
            {
                lds_temp = new DDddwRoadSuffix();
                ldwc_child = dw_header.GetChild("rs_id");
                ldwc_child.ShareData(lds_temp);
                if (lds_temp.RowCount > 0)
                {
                    //? ll_idarray = lds_temp.GetControlByName("rs_id").Primary;
                    for (ll_x = 0; ll_x < ll_idarray.Count; ll_x++)
                    {
                        ll_temp = ll_idarray[ll_x];
                        if (ll_temp == ll_id)
                        {
                            lb_matched = true;
                            break;
                        }
                        else if (ll_temp == null && ll_id == null)
                        {
                            lb_matched = true;
                            break;
                        }
                    }
                }
                if (lb_matched)
                {
                    return 0;
                }
                else
                {
                    //  Not a valid road type
                    MessageBox.Show('\'' + ls_id + "\' is not a valid road suffix.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).RtId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).RsId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).SlId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).TcId = ll_null;
                    return 2;
                }
            }
            else if (dwo == "sl_id")
            {
                lds_temp = new DDddwSuburb();
                ldwc_child = dw_header.GetChild("sl_id");
                ldwc_child.ShareData(lds_temp);
                if (lds_temp.RowCount > 0)
                {
                    //? ll_idarray = lds_temp.GetControlByName("sl_id").Primary;
                    for (ll_x = 1; ll_x <= ll_idarray.Count; ll_x++)
                    {
                        if (ll_idarray[ll_x] == ll_id)
                        {
                            lb_matched = true;
                            break;
                        }
                    }
                }
                if (lb_matched)
                {
                    return 0;
                }
                else
                {
                    //  Not a valid suburb
                    MessageBox.Show('\'' + ls_id + "\' is not a valid suburb.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).SlId = ll_null;
                    return 2;
                }
            }
            else if (dwo == "tc_id")
            {
                lds_temp = new DDddwTown();
                ldwc_child = dw_header.GetChild("tc_id");
                ldwc_child.ShareData(lds_temp);
                if (lds_temp.RowCount > 0)
                {
                    //? ll_idarray = lds_temp.GetControlByName("tc_id").Primary;
                    for (ll_x = 0; ll_x < ll_idarray.Count; ll_x++)
                    {
                        if (ll_idarray[ll_x] == ll_id)
                        {
                            lb_matched = true;
                            break;
                        }
                    }
                }
                if (lb_matched)
                {
                    return 0;
                }
                else
                {
                    //  Not a valid town
                    MessageBox.Show('\'' + ls_id + "\' is not a valid town.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).TcId = ll_null;
                    return 2;
                }
            }
            // PB 'Destroy' Statement
            lds_temp = null;
            return 0;
        }

        public virtual int dw_header_ue_validate_contract(bool ab_save)
        {
            int? ll_contract_no = 0;
            int? ll_default_contract_no = 0;
            int? ll_null = 0;
            int ll_match_count = 0;
            string ls_rd_no;
            string ls_town_name;
            string ls_comma = ",";
            string ls_and = "&";
            string ls_space = " ";
            string ls_percent = "%";
            ll_null = null;
            Cursor.Current = Cursors.WaitCursor;
            ls_rd_no = dw_header.GetItem<AddressDetails>(0).AdrRdNo;
            ls_town_name = dw_header.GetItem<AddressDetails>(0).TownName;
            if (ls_rd_no == null || ls_town_name == null || ls_town_name.Length <= 0)
            {
                return -(1);
            }
            ll_contract_no = dw_header.GetItem<AddressDetails>(0).ContractNo;
            //  Before we proceed any of the following, make sure the contract type is RD
            if (!(ll_contract_no == null) && ll_contract_no > 0 && !(this.of_iscontractoftyperd(ll_contract_no)))
            {
                //  no need to do any of the following steps
                return 1;
            }
            //  Check that the contract # is valid 
            /* SELECT	count ( *)
                INTO	:ll_match_count
                FROM	contract
                WHERE	con_date_terminated IS NULL
                AND 	con_rd_ref_text LIKE :ls_percent + :ls_town_name + :ls_percent
                AND	 ( con_rd_ref_text like :ls_rd_no + :ls_space + :ls_percent
                OR con_rd_ref_text like :ls_rd_no + :ls_comma + :ls_percent 
                OR con_rd_ref_text like :ls_rd_no + :ls_and   + :ls_percent 
                OR con_rd_ref_text like :ls_percent + :ls_space + :ls_rd_no + :ls_percent 
                OR con_rd_ref_text like :ls_percent + :ls_comma + :ls_rd_no + :ls_percent 
                OR con_rd_ref_text like :ls_percent + :ls_and   + :ls_rd_no + :ls_percent	)
                USING	SQLCA; */
            RDSDataService dataService = RDSDataService.GetContractComplex(ls_and, ls_town_name, ls_rd_no, ls_space, ls_percent, ls_comma);
            ll_match_count = dataService.intVal;
            if (dataService.SQLCode != 0)
            {
                //  DB Error
                if (!ib_closestatus)
                {
                    MessageBox.Show("A database error has occurred during validation of the contract number.\r\n\r\n" + "Database error code: " + dataService.SQLDBCode + '~' + "Database error message:\r\n    " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.DataObject.Controls["adr_rd_no"].Focus();
                    //? dw_header.SelectText(1, 500);
                    dw_header.Focus();
                    return -(1);
                }
            }
            else if (ll_match_count == 0)
            {
                //  cannot find a contract for this RD & town combination
                //  Do not display message if this is closing
                if (!ib_closestatus)
                {
                    MessageBox.Show("The system is unable to find a default contract \r\n" + "for the  RD number and the mail town specified.\r\n" + "Please check that the RD number and the mail town\r\n" + "specified are correct.  If so, contact your\r\n" + "System Administrators immediately.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dw_header.DataObject.Controls["adr_rd_no"].Focus();
                    //? dw_header.SelectText(1, 500);
                    dw_header.Focus();
                    return -(1);
                }
            }
            else if (ll_match_count > 1)
            {
                //  multiple matches found.  Only one is allowed.
                //  Check if contract number is entered
                if (ll_contract_no > 0)
                {
                    /* SELECT 	contract_no 
                        INTO	:ll_default_contract_no
                        FROM	contract
                        WHERE	con_date_terminated IS NULL
                        AND	contract_no = :ll_contract_no
                        AND	con_rd_ref_text LIKE :ls_percent + :ls_town_name + :ls_percent
                        AND	 ( con_rd_ref_text like :ls_rd_no + :ls_space + :ls_percent 
                        OR con_rd_ref_text like :ls_rd_no + :ls_comma + :ls_percent 
                        OR con_rd_ref_text like :ls_rd_no + :ls_and + :ls_percent 
                        OR con_rd_ref_text like :ls_percent + :ls_space + :ls_rd_no + :ls_percent 
                        OR con_rd_ref_text like :ls_percent + :ls_comma + :ls_rd_no + :ls_percent 
                        OR con_rd_ref_text like :ls_percent + :ls_and + :ls_rd_no + :ls_percent  )
                        USING	SQLCA; */
                    dataService = RDSDataService.GetContractComplex2(ls_and, ls_town_name, ls_rd_no, ls_space, ls_percent, ll_contract_no, ls_comma);
                    ll_default_contract_no = dataService.intVal;
                    if (dataService.SQLCode == 100)
                    {
                        //  not match
                        MessageBox.Show("The contract number specified is not a valid\r\n" + "contract for this address. ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dw_header.GetItem<AddressDetails>(0).ContractNo = ll_null;
                        dw_header.DataObject.Controls["contract_no"].Focus();
                        //? dw_header.SelectText(1, 500);
                        dw_header.Focus();
                        return -(1);
                    }
                    else if (dataService.SQLCode < 0)
                    {
                        //  SQLError
                        if (!ib_closestatus)
                        {
                            MessageBox.Show("A database error has occurred during validation of the contract number.\r\n\r\n" + "Database error code: " + dataService.SQLDBCode + '~' + "Database error message:\r\n    " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dw_header.DataObject.Controls["adr_rd_no"].Focus();
                            //? dw_header.SelectText(1, 500);
                            dw_header.Focus();
                            return -(1);
                        }
                    }
                    else
                    {
                        //  Good match
                        return 1;
                    }
                }
            }
            else if (ll_match_count == 1)
            {
                /* SELECT	contract_no 
                    INTO	:ll_default_contract_no
                    FROM	contract
                    WHERE	con_date_terminated IS NULL
                    AND	con_rd_ref_text LIKE :ls_percent + :ls_town_name + :ls_percent
                    AND	 ( con_rd_ref_text like :ls_rd_no + :ls_space + :ls_percent 
                    OR con_rd_ref_text like :ls_rd_no + :ls_comma + :ls_percent 
                    OR con_rd_ref_text like :ls_rd_no + :ls_and + :ls_percent 
                    OR con_rd_ref_text like :ls_percent + :ls_space + :ls_rd_no + :ls_percent 
                    OR con_rd_ref_text like :ls_percent + :ls_comma + :ls_rd_no + :ls_percent 
                    OR con_rd_ref_text like :ls_percent + :ls_and + :ls_rd_no + :ls_percent  )
                    USING	SQLCA; */
                dataService = RDSDataService.GetContractComplex3(ls_and, ls_town_name, ls_rd_no, ls_space, ls_percent, ls_comma);
                ll_default_contract_no = dataService.intVal;
                if (dataService.SQLCode < 0)
                {
                    //  SQLError
                    if (!ib_closestatus)
                    {
                        MessageBox.Show("A database error has occurred during validation of the contract number.\r\n\r\n" + "Database error code:  " + dataService.SQLDBCode + '~' + "Database error message:\r\n    " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dw_header.DataObject.Controls["adr_rd_no"].Focus();
                        //? dw_header.SelectText(1, 500);
                        dw_header.Focus();
                        return -(1);
                    }
                }
                if (ll_contract_no == null || ll_contract_no != ll_default_contract_no)
                {
                    //  prompt a message
                    //  Do not display message if this is closing
                    if (!ib_closestatus)
                    {
                        if (ab_save)
                        {
                            //  this is part of validation process
                            if (MessageBox.Show("Validation Error", "The contract number specified is different from\r\n" + "the default contract for this address: \r\n\r\n" + "Default Contract: \t" + ll_default_contract_no.ToString() + '~' + "Specified Contract: \t" + ll_contract_no.ToString() + "\r\n\r\n" + "The default contract will overwrite the contract \r\n" + "specified.  Do you wish to continue saving this address?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                // continue saving
                                dw_header.GetItem<AddressDetails>(0).ContractNo = ll_default_contract_no;
                            }
                            else
                            {
                                dw_header.GetItem<AddressDetails>(0).ContractNo = ll_default_contract_no;
                                dw_header.DataObject.Controls["contract_no"].Focus();
                                //? dw_header.SelectText(1, 500);
                                dw_header.Focus();
                                return -(1);
                            }
                        }
                        else
                        {
                            //  this is part of itemchanged event
                            MessageBox.Show("The contract number specified is different from\r\n" + "the default contract for this address: \r\n\r\n" + "Default Contract: \t" + ll_default_contract_no + '~' + "Specified Contract: \t" + ll_contract_no + "\r\n\r\n" + "The default contract will overwrite the contract \r\n" + "specified. ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dw_header.GetItem<AddressDetails>(0).ContractNo = ll_default_contract_no;
                            dw_header.DataObject.Controls["contract_no"].Focus();
                            //? dw_header.SelectText(1, 500);
                            dw_header.Focus();
                            return -(1);
                        }
                    }
                }
            }
            return 1;
        }

        public virtual void dw_header_ue_filter_dropdowns_v1(int row, string col_name, string data)
        {
            int? ll_road_id = null;
            int? ll_rt_id = 0;
            int? ll_rs_id = 0;
            int? li_sl_id = 0;
            int? li_tc_id = 0;
            int? li_temp = 0;
            int ll_currentrow;
            int ll_row;
            int? ll_null = 0;
            string ls_null;
            string ls_temp;
            string ls_road_name;
            bool lb_continue;
            DataUserControl ldwc_child;
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Add road suffix processing
            ll_null = null;
            ls_null = null;
            /*  ---------------------------- Debugging ----------------------------- //
            ls_temp = data
            if isnull ( ls_temp) then ls_temp = 'NULL'
            MessageBox.Show ( & 'Row = '+string ( row)+'\r\n'  & +'Column = '+col_name+'\r\n'  & +'Data   = '+ls_temp  ,  'w_maintain_address.dw_header.ue_filter_dropdowns' )
            // --------------------------------------------------------------------  */
            /* *************************************************************
            * Road name changed
            ************************************************************* */
            if (col_name == "road_name")
            {
                ls_road_name = data;
                dw_header.GetItem<AddressDetails>(0).RtId = ll_null;
                dw_header.GetItem<AddressDetails>(0).RsId = ll_null;
                ll_rt_id = null;
                ll_rs_id = null;
                //  Filter Road Type
                ldwc_child = dw_header.GetChild("rt_id");
                if (inv_road.of_filterroadtype1(ls_road_name, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentrow = ldwc_child.GetRow();
                    if (ll_currentrow >= 0)
                    {
                        ll_rt_id = ldwc_child.GetItem<DddwRoadType>(ll_currentrow).RtId;
                    }
                }
                ldwc_child.FilterString = "";
                ldwc_child.Filter<DddwRoadType>();
                dw_header.GetItem<AddressDetails>(0).RtId = ll_rt_id;
                //  Filter Road Suffix
                ldwc_child = dw_header.GetChild("rs_id");
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentrow = ldwc_child.GetRow();
                    if (ll_currentrow > 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentrow).RsId;
                    }
                }
                ldwc_child.FilterString = "";
                ldwc_child.Filter<DddwRoadSuffix>();
                dw_header.GetItem<AddressDetails>(0).RsId = ll_rs_id;
            }
            /* *************************************************************
            * Road type changed
            ************************************************************* */
            if (col_name == "rt_id")
            {
                ls_road_name = dw_header.GetItem<AddressDetails>(row).RoadName;
                int result;
                int.TryParse(data, out result);
                ll_rt_id = result;
                ll_rs_id = ll_rt_id;
                dw_header.GetItem<AddressDetails>(0).RsId = ll_null;
                ll_rs_id = null;
                //  Filter Road Suffix
                ldwc_child = dw_header.GetChild("rs_id");
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentrow = ldwc_child.GetRow();
                    if (ll_currentrow >= 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentrow).RsId;
                    }
                }
                ldwc_child.FilterString = "";
                ldwc_child.Filter<DddwRoadSuffix>();
                dw_header.GetItem<AddressDetails>(0).RsId = ll_rs_id;
            }
            /* *************************************************************
            * Road suffix changed
            ************************************************************* */
            if (col_name == "rs_id")
            {
                ls_road_name = dw_header.GetItem<AddressDetails>(row).RoadName;
                ll_rt_id = dw_header.GetItem<AddressDetails>(row).RtId;
                ll_rs_id = StaticFunctions.ToInt32(data);
                dw_header.GetItem<AddressDetails>(0).RsId = ll_rs_id;
            }
            /* *************************************************************
            * Road name, type or suffix changed
            ************************************************************* */
            if (col_name == "road_name" || col_name == "rt_id" || col_name == "rs_id")
            {
                //  Get the road id first
                if (col_name == "road_name")
                {
                    ls_road_name = data;
                    ll_rt_id = dw_header.GetItem<AddressDetails>(row).RtId;
                    ll_rs_id = dw_header.GetItem<AddressDetails>(row).RsId;
                    ll_road_id = inv_road.of_getroadid(ls_road_name, ll_rt_id, ll_rs_id);
                }
                else if (col_name == "rt_id")
                {
                    ll_rs_id = StaticFunctions.ToInt32(data);
                    ll_rs_id = dw_header.GetItem<AddressDetails>(row).RsId;
                    ls_road_name = dw_header.GetItem<AddressDetails>(row).RoadName;
                    ll_road_id = inv_road.of_getroadid(ls_road_name, ll_rt_id, ll_rs_id);
                }
                else
                {
                    ll_rs_id = StaticFunctions.ToInt32(data);
                    ll_rt_id = dw_header.GetItem<AddressDetails>(row).RtId;
                    ls_road_name = dw_header.GetItem<AddressDetails>(row).RoadName;
                    ll_road_id = inv_road.of_getroadid(ls_road_name, ll_rt_id, ll_rs_id);
                }
                il_road_id = ll_road_id;
                li_sl_id = dw_header.GetItem<AddressDetails>(row).SlId;
                li_tc_id = dw_header.GetItem<AddressDetails>(row).TcId;
                //  TJB  NPAD2 Apr 2006  pre-GoLive
                //  Disable suburb stuff
                //  	// Filter suburb
                //  	ll_row = 0
                //  	this.GetChild ( 'sl_id', ldwc_child)
                //  	IF inv_road.of_FilterSuburbType ( ll_road_id, ldwc_child) THEN
                //  		if not isnull ( li_sl_id) and li_sl_id > 0 then
                //  				// If the current suburb is in the newly-filtered list
                //  				// scroll to it.
                //  			ll_row = ldwc_child.find ( 'sl_id = '+li_sl_id.ToString(),  &
                //  									1,ldwc_child.RowCount)
                //  			if ll_row > 0 then
                //  				this.SetItem ( 1, 'sl_id', li_sl_id)
                //  			end if
                //  		end if
                //  	END IF
                //  		// If we can't continue to use the 'old' suburb
                //  		// don't use any.
                //  	if ll_row <= 0 then
                //  		this.SetItem ( 1, 'sl_id', ll_null)
                //  		setnull ( li_sl_id)
                //  	END IF
                //  Filter town
                ll_row = 0;
                ldwc_child = dw_header.GetChild("tc_id");
                if (inv_road.of_filtertowntype(ll_road_id, ref ldwc_child))
                {
                    if (!(li_tc_id == null) && li_tc_id > 0)
                    {
                        //  If the current town is in the newly-filtered list
                        //  scroll to it.  The post code won't change.
                        ll_row = ldwc_child.Find("tc_id", li_tc_id);
                        if (ll_row >= 0)
                        {
                            dw_header.GetItem<AddressDetails>(0).TcId = li_tc_id;
                        }
                    }
                }
                //  If we can't continue to use the 'old' town
                //  don't use any, and clear the post code.
                if (ll_row <= 0)
                {
                    dw_header.GetItem<AddressDetails>(row).TcId = ll_null;
                    li_tc_id = null;
                    dw_header.GetItem<AddressDetails>(row).PostCode = ls_null;
                }
            }
            //  TJB  NPAD2 Apr 2006  pre-GoLive
            //  Disable suburb stuff
            //  /**************************************************************
            //   * Suburb changed
            //   **************************************************************/
            //  IF col_name = 'sl_id' THEN
            //  	li_sl_id = integer ( data)
            //  	this.SetItem ( row, 'sl_id', li_sl_id)
            // 
            //  	li_tc_id = this.getItemNumber ( row,'tc_id')
            // 
            //  	ll_rs_id     = GetItemNumber ( row, 'rs_id')
            //  	ll_rt_id     = GetItemNumber ( row, 'rt_id')
            //  	ls_road_name = this.GetItemString ( row, 'road_name')
            //  	ll_road_id   = inv_road.of_GetRoadId ( ls_road_name, ll_rt_id, ll_rs_id)
            // 
            //  	// Filter town
            //  	lb_continue = FALSE
            //  	this.GetChild ( 'tc_id', ldwc_child)
            // 
            //  	if not isnull ( ll_road_id) then	
            //   			// If there's a road selected, filter by suburb and road
            //  		lb_continue = inv_road.of_FilterTownBySuburbAndRoad (  li_sl_id, ll_road_id, ldwc_child)
            //  	else
            //  			// Otherwise, filter just by suburb  ( not road)
            //  		lb_continue = inv_road.of_FilterTownBySuburb (  li_sl_id, ldwc_child)
            //  	end if
            // 
            //  	ll_row = 0
            //  	if lb_continue then
            //  		if not isnull ( li_tc_id) and li_tc_id > 0 then
            //  				// If the current town is in the newly-filtered list
            //  				// scroll to it.  The post code won't change.
            //  			ll_row = ldwc_child.find ( 'tc_id = '+li_tc_id.ToString(),  &
            //  									1,ldwc_child.RowCount)
            //  			if ll_row > 0 then
            //  				this.SetItem ( 1, 'tc_id', li_tc_id)
            //  			end if
            //  		end if
            //  	end if
            //  			// If we can't continue to use the 'old' town
            //  			// don't use any, and clear the post code.
            //  	if ll_row <= 0 then
            //  		this.SetItem ( row, 'tc_id', ll_null)
            //  		setNull ( li_tc_id)
            //  		this.SetItem ( row, 'post_code', ls_null)
            //  	end if
            // 
            //  END IF  /* col_name = sl_id */
            /* *************************************************************
            * Town changed
            ************************************************************* */
            if (col_name == "tc_id")
            {
                string ls_tc_id;
                string ls_sl_id;
                string ls_road_id;
                string ls_rt_id;
                string ls_rs_id;
                li_tc_id = StaticFunctions.ToInt32(data);
                dw_header.GetItem<AddressDetails>(row).TcId = li_tc_id;
                li_sl_id = dw_header.GetItem<AddressDetails>(row).SlId;
                ll_rs_id = dw_header.GetItem<AddressDetails>(row).RsId;
                ll_rt_id = dw_header.GetItem<AddressDetails>(row).RtId;
                ls_road_name = dw_header.GetItem<AddressDetails>(row).RoadName;
                ll_road_id = inv_road.of_getroadid(ls_road_name, ll_rt_id, ll_rs_id);
                if (ll_rt_id == null)
                {
                    ls_rt_id = "NULL";
                }
                else
                {
                    ls_rt_id = ll_rt_id.ToString();
                }
                if (ll_rs_id == null)
                {
                    ls_rs_id = "NULL";
                }
                else
                {
                    ls_rs_id = ll_rs_id.ToString();
                }
                if (li_sl_id == null)
                {
                    ls_sl_id = "NULL";
                }
                else
                {
                    ls_sl_id = li_sl_id.ToString();
                }
                if (li_tc_id == null)
                {
                    ls_tc_id = "NULL";
                }
                else
                {
                    ls_tc_id = li_tc_id.ToString();
                }
                if (ll_road_id == null)
                {
                    ls_road_id = "NULL";
                }
                else
                {
                    ls_road_id = ll_road_id.ToString();
                }
                //  Filter suburb
                //  TJB  NPAD2 Apr 2006  pre-GoLive
                //  Disable suburb stuff
                //  	lb_continue = FALSE
                //  	this.GetChild ( 'sl_id', ldwc_child)
                // 
                //  	if not isnull ( ll_road_id) then	
                //   			// If there's a road selected, filter by suburb and road
                //  		lb_continue = inv_road.of_FilterSuburbByTownAndRoad ( il_road_id, li_tc_id, ldwc_child)
                //  	else
                //  			// Otherwise, filter just by suburb  ( not road)
                //  		lb_continue = inv_road.of_FilterSuburbByTown (  li_tc_id, ldwc_child)
                //  	end if
                // 
                //  	ll_row = 0
                //  	if lb_continue then
                //  		if not isnull ( li_sl_id) and li_sl_id > 0 then
                //  				// If the current suburb is in the newly-filtered list
                //  				// scroll to it.
                //  			ll_row = ldwc_child.find ( 'sl_id = '+li_sl_id.ToString(),  &
                //  									1,ldwc_child.RowCount)
                //  			if ll_row > 0 then
                //  				this.SetItem ( 1, 'sl_id', li_sl_id)
                /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show ( & 'Suburb filtered OK; saving old suburb ID'+'\r\n'  & +'ll_road_id = '+ls_road_id+'\r\n'  & +'ll_rt_id = '+ls_rt_id+'\r\n'  & +'ll_rs_id = '+ls_rs_id+'\r\n'  & +'li_tc_id = '+ls_tc_id+'\r\n'  & +'li_sl_id = '+ls_sl_id+'\r\n'  & +'ll_row   = '+string ( ll_row)+'\r\n'  ,  'w_maintain_address.dw_header.ue_filter_dropdowns' )
                // --------------------------------------------------------------------  */
                //  			end if
                //  		end if
                //  	end if
                //  			// If we can't continue to use the 'old' suburb
                //  			// don't use any.
                //  	if ll_row <= 0 then
                //  		this.SetItem ( row, 'sl_id', ll_null)
                //  		setNull ( li_sl_id)
                /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show ( & 'Suburb filter failed; clearing old suburb ID'+'\r\n'  & +'ll_road_id = '+ls_road_id+'\r\n'  & +'ll_rt_id = '+ls_rt_id+'\r\n'  & +'ll_rs_id = '+ls_rs_id+'\r\n'  & +'li_tc_id = '+ls_tc_id+'\r\n'  & +'li_sl_id = '+ls_sl_id+'\r\n'  & +'ll_row   = '+string ( ll_row)+'\r\n'  ,  'w_maintain_address.dw_header.ue_filter_dropdowns' )
                // --------------------------------------------------------------------  */
                //  	end if
            }
            //  Set the post code
            //  Doing it anyway is easier than trying to keep track of whether
            //  the town has changed and only doing it in that case.
            li_temp = dw_header.GetItem<AddressDetails>(row).TcId;
            of_set_postcode(li_temp);
            //? dw_header.SelectText(1, 500);
        }

        public virtual void dw_header_constructor()
        {
            //? base.constructor();
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Add road suffix processing
            //? dw_header.of_SetDropDownSearch(true);
            // This.of_SetReqColumn ( TRUE)
            // This.inv_reqcolumn.of_RegisterSkipColumn ( "contract_no")
            // This.inv_reqcolumn.of_RegisterSkipColumn ( "road_name")
            // This.inv_reqcolumn.of_RegisterSkipColumn ( "adr_rd_no")
            // This.inv_reqcolumn.of_RegisterSkipColumn ( "tc_id")
            //  Register editable columns with Dropdown Search Service
            /*? if (dw_header.inv_dropdownsearch != null)
            {
                dw_header.inv_DropDownSearch.of_register("rs_id");
                dw_header.inv_DropDownSearch.of_register("rt_id");
                dw_header.inv_DropDownSearch.of_register("rs_id");
                dw_header.inv_DropDownSearch.of_register("sl_name");
                dw_header.inv_DropDownSearch.of_register("tc_id");
            } */

            BeginInvoke(new constraDelegate(dw_header_invoke));
            //dw_header.of_set_deletepriv(false);
            //dw_header.of_set_createpriv(false);
            idw_header = dw_header;
        }

        private delegate void constraDelegate();

        public virtual void dw_header_invoke()
        {
            dw_header.of_set_deletepriv(false);
            dw_header.of_set_createpriv(false);
            dw_header.URdsDw_GetFocus(null, null); //added by jlwang
        }

        public virtual int dw_header_pfc_preupdate()
        {
            base.pfc_preupdate();
            if (il_adr_id == null || il_adr_id == 0)
            {
                il_adr_id = StaticFunctions.GetNextSequence("address");
                dw_header.GetItem<AddressDetails>(0).AdrId = il_adr_id;
            }
            return 1; //? return ancestorreturnvalue;
        }

        //call api for support keyPress
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vkKey);

        public enum KeyIndexes
        {
            Key0 = '0', Key1 = '1', Key2 = '2', Key3 = '3',
            Key4 = '4', Key5 = '5', Key6 = '6', Key7 = '7',
            Key8 = '8', Key9 = '9', KeyA = 'A', KeyB = 'B',
            KeyC = 'C', KeyD = 'D', KeyE = 'E', KeyF = 'F',
            KeyG = 'G', KeyH = 'H', KeyI = 'I', KeyJ = 'J',
            KeyK = 'K', KeyL = 'L', KeyM = 'M', KeyN = 'N',
            KeyO = 'O', KeyP = 'P', KeyQ = 'Q', KeyR = 'R',
            KeyS = 'S', KeyT = 'T', KeyU = 'U', KeyV = 'V',
            KeyW = 'W', KeyX = 'X', KeyY = 'Y', KeyZ = 'Z'
        };

        private bool KeyDown(KeyIndexes idx)
        {
            return GetAsyncKeyState((int)idx) < 0;
        }

        public virtual void dw_header_ue_editchanged(int row, string dwo, string data)
        {
            string sPartial = string.Empty;
            string sNextMatch = string.Empty;
            string ls_display;

            if (dwo == "road_name")
            {
                //?if (inv_road.of_validate_keypress) //IF inv_road.of_validate_keypress() THEN
                // jlwang:this API support XP,2000 ,Vista maybe have bug.
                if (GetAsyncKeyState((int)KeyIndexes.KeyA) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyB) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyC) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyD) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyE) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyF) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyG) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyH) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyI) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyJ) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyK) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyL) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyM) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyN) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyO) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyP) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyQ) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyR) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyS) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyT) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyU) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyV) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyW) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyX) < 0
                    || GetAsyncKeyState((int)KeyIndexes.KeyY) < 0 || GetAsyncKeyState((int)KeyIndexes.KeyZ) < 0
                    || GetAsyncKeyState((int)KeyIndexes.Key0) < 0 || GetAsyncKeyState((int)KeyIndexes.Key1) < 0
                    || GetAsyncKeyState((int)KeyIndexes.Key2) < 0 || GetAsyncKeyState((int)KeyIndexes.Key3) < 0
                    || GetAsyncKeyState((int)KeyIndexes.Key4) < 0 || GetAsyncKeyState((int)KeyIndexes.Key5) < 0
                    || GetAsyncKeyState((int)KeyIndexes.Key6) < 0 || GetAsyncKeyState((int)KeyIndexes.Key7) < 0
                    || GetAsyncKeyState((int)KeyIndexes.Key8) < 0 || GetAsyncKeyState((int)KeyIndexes.Key9) < 0)
                {
                    ls_display = data.Trim();//  Trim(GetText())
                    sPartial = ls_display;// Left(ls_display, SelectedStart() - 1);

                    if (sPartial.Length > 0) // IF Len(sPartial) > 0 THEN
                    {
                        sNextMatch = inv_road.of_getnextmatch1(sPartial);

                        if (sNextMatch.Length > 0) // IF Len(sNextMatch) > 0 THEN
                        {
                            //this.SetText(sNextMatch);
                            this.dw_header.DataObject.GetControlByName("road_name").Text = sNextMatch;
                            //this.SelectText(Len(sPartial) + 1, Len(sNextMatch)) ;
                            ((TextBox)this.dw_header.GetControlByName("road_name")).Select(sPartial.Length, sNextMatch.Length);
                        }
                    }
                }
            }
        }

        public virtual int dw_header_itemerror(int row, string column, string data)
        {
            DataUserControl ldwc_child;
            List<string> ls_namearray = new List<string>();
            bool lb_matched = false;
            int ll_x = 0;
            DataUserControl lds_temp;
            int? ll_null = 0;
            ll_null = null;
            //  Need to validate the new item entered
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Add road suffix validation
            //  If the new item entered is not an exisitng item,
            //  	reject the value
            //  Else if the road type is a valid item,
            // 		move the item row from filterd! buffer back to primary buffer!
            data = data.ToLower().Trim();
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_col_name, ds_data
                ds_data = data
                ds_col_name = column
                if isnull ( ds_data) then ds_data = 'NULL'
                MessageBox.Show ( & 'Row = '+string ( row)+'\r\n'      & +'Column = '+ds_col_name+'\r\n'  & +'Data   = '+ds_data  ,  'w_maintain_address.dw_header.itemerror' )
            // --------------------------------------------------------------------  */
            if (column == "rt_id")
            {
                lds_temp = new DDddwRoadType();
                ldwc_child = dw_header.GetChild("rt_id");
                ldwc_child.ShareData(lds_temp);
                /*? if (lds_temp.FilteredCount > 0)
                {
                    ls_namearray = lds_temp.GetControlByName("rt_name").Filter;
                    for (ll_x = 0; ll_x < ls_namearray.UpperBound; ll_x++)
                    {
                        if (ls_namearray[ll_x].ToLower() == data)
                        {
                            lb_matched = true;
                            data = ls_namearray[ll_x];
                            break;
                        }
                    }
                } */
                if (lb_matched)
                {
                    dw_header_ue_add_to_dropdown(ldwc_child, "rt_id", ll_x);
                    dw_header_ue_filter_dropdowns(row, column, ll_x.ToString());
                    return 2;
                }
                else
                {
                    //  Not a valid road type
                    MessageBox.Show("\'" + data + "\' is not a valid road type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).RtId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).SlId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).TcId = ll_null;
                    return 3;
                }
            }
            else if (column == "rs_id")
            {
                lds_temp = new DDddwRoadSuffix();
                ldwc_child = dw_header.GetChild("rs_id");
                ldwc_child.ShareData(lds_temp);
                /*? if (lds_temp.FilteredCount > 0)
                {
                    ls_namearray = lds_temp.GetControlByName("rs_name").Filter;
                    for (ll_x = 1; ll_x <= ls_namearray.UpperBound; ll_x++)
                    {
                        if (Lower(ls_namearray[ll_x]) == data)
                        {
                            lb_matched = true;
                            data = ls_namearray[ll_x];
                            break;
                        }
                    }
                } */
                if (lb_matched)
                {
                    dw_header_ue_add_to_dropdown(ldwc_child, "rs_id", ll_x);
                    dw_header_ue_filter_dropdowns(row, column, ll_x.ToString());
                    return 2;
                }
                else
                {
                    //  Not a valid road type
                    MessageBox.Show("\'" + data + "\' is not a valid road suffix.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).RsId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).RtId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).SlId = ll_null;
                    dw_header.GetItem<AddressDetails>(0).TcId = ll_null;
                    return 3;
                }
            }
            else if (column == "sl_id")
            {
                lds_temp = new DDddwSuburb();
                data = data.ToLower().Trim();
                ldwc_child = dw_header.GetChild("sl_id");
                ldwc_child.ShareData(lds_temp);
                /*? if (lds_temp.FilteredCount > 0)
                {
                    ls_namearray = lds_temp.GetControlByName("sl_name").Filter;
                    for (ll_x = 1; ll_x <= ls_namearray.UpperBound; ll_x++)
                    {
                        if (Lower(ls_namearray[ll_x]) == data)
                        {
                            lb_matched = true;
                            data = ls_namearray[ll_x];
                            break;
                        }
                    }
                } */
                if (lb_matched)
                {
                    dw_header_ue_add_to_dropdown(ldwc_child, "sl_id", ll_x);
                    return 2;
                }
                else
                {
                    //  Not a valid road type
                    MessageBox.Show("\'" + data + "\' is not a valid suburb.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).SlId = ll_null;
                    return 3;
                }
            }
            else if (column == "tc_id")
            {
                lds_temp = new DDddwTown();
                //  need to validate the new town entered
                //  If the town entered is not an exisitng town,
                //  	reject the value
                //  Else if the town is a valid town ,
                // 		move the town row from filterd! buffer back to primary buffer!
                data = data.ToLower().Trim();
                ldwc_child = dw_header.GetChild("tc_id");
                ldwc_child.ShareData(lds_temp);
                /*? if (lds_temp.FilteredCount > 0)
                {
                    ls_namearray = lds_temp.GetControlByName("tc_name").Filter;
                    for (ll_x = 1; ll_x <= ls_namearray.UpperBound; ll_x++)
                    {
                        if (ls_namearray[ll_x].ToLower() == data)
                        {
                            lb_matched = true;
                            data = ls_namearray[ll_x];
                            break;
                        }
                    }
                } */
                if (lb_matched)
                {
                    dw_header_ue_add_to_dropdown(ldwc_child, "tc_id", ll_x);
                    return 2;
                }
                else
                {
                    //  Not a valid road type
                    MessageBox.Show('\'' + data + "\' is not a valid town.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dw_header.GetItem<AddressDetails>(0).TcId = ll_null;
                    return 3;
                }
            }
            // PB 'Destroy' Statement
            lds_temp = null;
            return 1;
        }

        public virtual int dw_header_pfc_validation()
        {
            /* 
                Validate the Road Name and the following relationships:
                Road   - Road Type
                Road   - Suburb
                Road   - Town
                Suburb - Town
                If any of these do not exist, prompt for confirmation
                and then insert into DB
                TJB  Sept 2005  NPAD2 Address schema changes
                Add adr_unit and road_suffix to the address components
                TJB  NPAD2  Apr 2006
                Modified the road validation and creation if new
             */
            int? ll_road_id = 0;
            int? ll_rt_id = 0;
            int? ll_rs_id = 0;
            int? ll_sl_id = 0;
            int? ll_tc_id = 0;
            int? ll_contract_no = 0;
            int ll_row;
            int ll_rc = 0;
            int? ll_temp = 0;
            string ls_road_name;
            string ls_sl_name;
            string ls_rd_no = "";
            string ls_adr_num;
            string ls_no = string.Empty;
            string ls_alpha = string.Empty;
            string ls_unit = string.Empty;
            string ls_postcode = "";
            string ls_userid = "";
            bool lb_new_road = false;
            // dwItemStatus	ldwItemStatus
            /*? if (ancestorreturnvalue == -(1))
            {
                return ancestorreturnvalue;
            } */
            if (!StaticFunctions.IsDirty(idw_header))
            {
                //  Nothing has been modified; assume its all OK
                return 1;
            }
            dw_header.AcceptText();
            ll_row = dw_header.GetRow();
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_closestatus
                ds_closestatus = ib_closestatus.ToString()
                if isnull ( ib_closestatus) then ds_closestatus = 'NULL'
                MessageBox.Show (    & 'dw_header pfc_validation  \r\n'      & +'ib_closestatus = '+ds_closestatus ,  'w_maintain_address.dw_header.pfc_validation' )
            // --------------------------------------------------------------------  */
            //  Check that the contract #, road name, and town/city are specified.
            //  Check that a road name has been specified
            ls_road_name = dw_header.GetItem<AddressDetails>(ll_row).RoadName;
            if (ls_road_name == null || ls_road_name.Trim().Length <= 0)
            {
                //  Do not display message if this is closing
                if (!ib_closestatus)
                {
                    MessageBox.Show("A road name must be entered.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dw_header.DataObject.Controls["road_name"].Focus();
                //? dw_header.SelectText(1, 500);
                dw_header.Focus();
                return -(1);
            }
            //  Check that a town/city has been specified
            ll_tc_id = dw_header.GetItem<AddressDetails>(ll_row).TcId;
            if (ll_tc_id == null || ll_tc_id <= 0)
            {
                //  Do not display message if this is closing
                if (!ib_closestatus)
                {
                    MessageBox.Show("A town/city must be selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dw_header.DataObject.Controls["tc_id"].Focus();
                //? dw_header.SelectText(1, 500);
                dw_header.Focus();
                return -(1);
            }
            //  Check that a contract number has been specified
            ll_contract_no = dw_header.GetItem<AddressDetails>(ll_row).ContractNo;
            if (ll_contract_no == null || ll_contract_no <= 0)
            {
                //  Do not display message if this is closing
                if (!ib_closestatus)
                {
                    MessageBox.Show("A contract number must be specified for this address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                dw_header.DataObject.Controls["contract_no"].Focus();
                //? dw_header.SelectText(1, 500);
                dw_header.Focus();
                return -(1);
            }
            //  If this is an RD contract, check that an RD number has 
            //  been specified.
            // IF parent.of_IsContractOfTypeRD ( ll_contract_no) THEN
            if (ib_RDcontract)
            {
                ls_rd_no = dw_header.GetItem<AddressDetails>(ll_row).AdrRdNo.Trim();
                if (ls_rd_no == null || ls_rd_no.Length <= 0)
                {
                    //  Do not display message if this is closing
                    if (!ib_closestatus)
                    {
                        MessageBox.Show("A RD number must be entered.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dw_header.DataObject.Controls["adr_rd_no"].Focus();
                    //? dw_header.SelectText(1, 500);
                    dw_header.Focus();
                    return -(1);
                }
                //  Check that the contract is correct
                //  This depends on the RD number and mailtown, so is done
                //  after ensuring an RD number and mailtown have been specified.
                if (dw_header_ue_validate_contract(true) != 1)
                {
                    return -(1);
                }
            }
            //  Check that we have a post code.  The user doesn't enter it; it
            //  is derived from the mailtown and RD number
            if (ls_postcode == null || ls_postcode == "")
            {
                //  Update the post code
                if (ib_RDcontract)
                {
                    //  If this is a RD contract, we need both the mailtown and RD number
                    of_set_postcode(ll_tc_id, ls_rd_no);
                }
                else
                {
                    //  This is a non-RD contract.  Look up the post code
                    //  by mailtown only  ( RD number null).
                    of_set_postcode(ll_tc_id);
                }
            }
            ls_postcode = idw_header.GetItem<AddressDetails>(ll_row).PostCode;
            if (ls_postcode == null || ls_postcode == "")
            {
                MessageBox.Show("Unable to determine post code for address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -(1);
            }
            //  Need to split the adr_num field into adr_no and adr_alpha
            //  TJB  Sept 2005: Added number format check to of_split_string
            //  Check that the number is well-formed  ( <unit>/<number><alpha>)
            ls_adr_num = dw_header.GetItem<AddressDetails>(ll_row).AdrNum;
            if (inv_road.of_split_string(ls_adr_num, ref ls_no, ref ls_alpha, ref ls_unit))
            {
                dw_header.GetItem<AddressDetails>(0).AdrUnit = ls_unit;
                dw_header.GetItem<AddressDetails>(0).AdrAlpha = ls_alpha;
                dw_header.GetItem<AddressDetails>(0).AdrNo = ls_no;
            }
            else
            {
                return -(1);
            }
            /* *************************************************************
                * Now validate that the road exists in the suburb/town
                * If not, confirm with the user that a new road record 
                * is to be created.
            ************************************************************* */
            ll_rt_id = dw_header.GetItem<AddressDetails>(ll_row).RtId;
            ll_rs_id = dw_header.GetItem<AddressDetails>(ll_row).RsId;
            ls_sl_name = dw_header.GetItem<AddressDetails>(ll_row).SlName;
            // select f_validate_road ( :ls_road_name, :ll_rt_id, :ll_rs_id, :ls_sl_name, :ll_tc_id) into :ll_road_id from dummy; 
            RDSDataService dataService = RDSDataService.CheckValidateRoad(ll_tc_id, ls_sl_name, ls_road_name, ll_rt_id, ll_rs_id);
            ll_road_id = dataService.intVal;
            /*  ------------------------- Debugging ------------------------- //
            string	ds_reason = "Huh?"
            string	ds_road, ds_suburb, ds_town
            if ll_road_id >  0 then ds_reason = "Existing road"
            if ll_road_id = -1 then ds_reason = "Road doesn't already exist"
            if ll_road_id = -2 then ds_reason = "Road doesn't exist in the mailtown"
            if ll_road_id = -3 then ds_reason = "Road doesn't exist in the suburb"
            if ll_road_id = -4 then ds_reason = "Suburb doesn't exist in the mailtown"
            if isnull ( ls_road_name) then ds_road   = 'NULL' else ds_road   = ls_road_name
            if isnull ( ls_sl_name)   then ds_suburb = 'NULL' else ds_suburb = ls_sl_name
            if isnull ( ll_tc_id)     then ds_town   = 'NULL' else ds_town   = ll_tc_id.ToString()
            MessageBox.Show ( & 'f_validate_road returned '+string ( ll_road_id)& +'   ( '+ds_reason+')\r\n\r\n'     & +'Road   = '+ds_road+'\r\n'    & +'Suburb = '+ds_suburb+'\r\n'  & +'Town   = '+ds_town         ,  'w_maintain_address.dw_header.pfc_validation' )
            // -------------------------------------------------------------  */
            if (ll_road_id < 0)
            {
                //  If not OK, tell the user and ask if a new road should be created
                ll_rc = (int)MessageBox.Show("The road entered does not exist in the system currently.\r\n" + "Do you wish to continue using this new road?", "Road Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ll_rc == (int)DialogResult.Yes)
                {
                    ls_userid = StaticVariables.LoginId;
                    // select f_create_road (  :ls_road_name, :ll_rt_id, :ll_rs_id, :ls_sl_name, :ll_tc_id, :ls_userid) into :ll_road_id from dummy; 
                    dataService = RDSDataService.GetCreateRoadId(ls_userid, ll_rs_id, ll_tc_id, ls_sl_name, ls_road_name, ll_rt_id);
                    ll_road_id = dataService.intVal;
                    /*  --------------------- Debugging --------------------- //
                    MessageBox.Show ( & 'f_create_road returned '+string ( ll_road_id,  'w_maintain_address.ue_clicked_ok' )
                    // -----------------------------------------------------  */
                    //  TJB  Release 6.8.11 fixup
                    //  f_create_road returns 0 or -4 if it is unable to create 
                    //  the road or its links to suburb or town.  If this
                    //  happens, return FAILURE.
                    if (ll_road_id < 0)
                    {
                        MessageBox.Show("Error creating the new road.  New address not created. \r\n", "Road Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //? rollback;
                        ll_rc = -(1);
                    }
                }
                else
                {
                    //  The user doesn't want to create a new road
                    //  Clear the update flags but leave the  ( new) data intact
                    //  so the user can fix it.
                    idw_header.ResetUpdate();
                    ll_rc = -(1);
                }
            }
            //  If the user said 'no' to creating a new road ...
            if (ll_rc < 0)
            {
                return -(1);
            }
            //  The road name exists.  Set the address record's road_id.
            //  No need to check to see if the roadID should be changed;
            //  no harm done putting the same number back.
            dw_header.GetItem<AddressDetails>(ll_row).RoadId = ll_road_id;
            //  Set the address 'last amended' values
            dw_header.GetItem<AddressDetails>(ll_row).AdrLastAmendedUser = ls_userid;
            dw_header.GetItem<AddressDetails>(ll_row).AdrLastAmendedDate = System.DateTime.Today;
            /*   ( TJB NPAD2 Apr 2006: this is the pre-NPAD handling)
            ll_sl_id      = this.GetItemNumber ( 1, 'sl_id')
            ldwItemStatus = this.GetItemStatus ( 1, 'road_id', Primary!)
            ll_road_id    = this.GetItemNumber ( 1, 'road_id')
            IF IsNull ( ll_road_id) OR ll_road_id <= 0 OR ldwItemStatus = DataModified! THEN
            ll_rt_id = this.GetItemNumber ( 1, 'rt_id')
            ll_rs_id = this.GetItemNumber ( 1, 'rs_id')
            // TJB  Sept 2005:  Added rs_id to of_GetRoadId parameter list
            ll_road_id = inv_road.of_GetRoadId ( ls_road_name, ll_rt_id, ll_rs_id)
            IF IsNull ( ll_road_id) OR ll_road_id <= 0 THEN
            // Do not display message if this is closing
            IF ib_closestatus THEN
            RETURN -1
            ELSE
            ll_rc = MessageBox ( 'Road Creation',   &
            'The road entered does not exist in the system currently.\r\n' &
            +'Do you wish to continue using this new road?', &
            Question!, YesNo!, 2) 
            IF ll_rc = 1 THEN
            lb_new_road = TRUE
            ELSE
            // no do not continue
            RETURN -1
            END IF
            END IF
            END IF
            END IF
            // TJB  Sept 2005:  Added rs_id to of_CreateRoad parameter list
            IF lb_new_road THEN
            ll_road_id = inv_road.of_CreateRoad ( ls_road_name, ll_rt_id, ll_sl_id, ll_tc_id, ll_rs_id)
            IF IsNull ( ll_road_id) OR ll_road_id <=0 THEN
            RETURN -1
            END IF
            ELSE
            // Need to store mappings between suburb/town/road if necessary
            inv_road.of_UpdateMappings ( ll_road_id, ll_sl_id, ll_tc_id)
            END IF
            this.SetItem ( 1, 'road_id', ll_road_id)
             */
            return 1;//? ancestorreturnvalue;
        }

        public virtual void dw_details_ue_click_open()
        {
            int? ll_cust_id = 0;
            int? ll_dpid = 0;
            int ll_selected_row = 0;
            int ll_x;
            int? ll_temp = 0;
            int ll_row;
            int ll_rows;
            int? ll_tmp_dpid = 0;
            int? ll_contract_no = 0;
            string ls_syntax;
            URdsDw lds_cust;
            DateTime? ldt_timestamp = null;
            //  TJB  NPAD2  Jan 2006  
            //  Change open of w_customer window to pass parameters through message.
            NCriteria lnv_criteria;
            NRdsMsg lnv_msg;
            int? ll_unnumbered = 0;
            int? ll_npad_enabled = 0;
            string ls_adrnum;
            //  Don't allow any customer changes until this address has been 
            //  associated with a contract.
            ll_contract_no = idw_header.GetItem<AddressDetails>(idw_header.GetRow()).ContractNo;
            if (ll_contract_no == null || ll_contract_no < 1)
            {
                MessageBox.Show("Please enter a contract for this address and press \'save\'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //  ll_selected_row = this.GetRow ( )
            ll_rows = idw_details.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                if (idw_details.IsSelected(ll_row))
                {
                    ll_selected_row = ll_row;
                    break;
                }
            }
            if (ll_selected_row < 0)
            {
                MessageBox.Show("You must select a customer before opening the customer.", "Open Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            if (this.of_checkandsave() == ii_success)
            {
                // 	// Preserve the customer movement list prior to editing
                // 	idw_movement.Retrieve(new object[]{il_adr_id})
                //  TJB  NPAD2  Jan 2006  
                //  Change open of w_customer window to pass 
                //      parameters through message.
                //  Add address ID as a new parameter.
                //  Add address unnumbered flag as a new parameter.
                //  Add npad enabled flag as a new parameter.
                lnv_criteria = new NCriteria();
                lnv_msg = new NRdsMsg();
                if (dw_details.DataObject.RowCount > 0)
                {
                    ll_cust_id = dw_details.GetItem<AddressOccupants>(ll_selected_row).CustId;
                    ll_dpid = dw_details.GetItem<AddressOccupants>(ll_selected_row).DpId;
                }
                ls_adrnum = idw_header.GetItem<AddressDetails>(idw_header.GetRow()).AdrNum;
                if (ls_adrnum == null || ls_adrnum == "")
                {
                    ll_unnumbered = 1;
                }
                else
                {
                    ll_unnumbered = 0;
                }
                if (ib_npad_enabled)
                {
                    ll_npad_enabled = 1;
                }
                else
                {
                    ll_npad_enabled = 0;
                }
                lnv_criteria.of_addcriteria("cust_id", ll_cust_id);
                if (ll_dpid == null)
                {
                    lnv_criteria.of_addcriteria("dp_id", 0);
                }
                else
                {
                    lnv_criteria.of_addcriteria("dp_id", ll_dpid);
                }
                lnv_criteria.of_addcriteria("adr_id", il_adr_id);
                lnv_criteria.of_addcriteria("contract_no", ll_contract_no);
                lnv_criteria.of_addcriteria("unnumbered", ll_unnumbered);
                lnv_criteria.of_addcriteria("npad_enabled", ll_npad_enabled);
                if (ib_RDcontract)
                {
                    ll_temp = 1;
                }
                else
                {
                    ll_temp = 0;
                }
                lnv_criteria.of_addcriteria("rd_Contract_Select", ll_temp);
                lnv_msg.of_addcriteria(lnv_criteria);
                // OpenWithParm(w_customer, lnv_msg);
                WCustomer w_customer = new WCustomer();
                StaticMessage.PowerObjectParm = lnv_msg;
                w_customer.ShowDialog();
                /*  ---------------------------- Debugging ----------------------------- //
                ll_temp = message.doubleParm
                if isnull ( ll_temp) then
                MessageBox.Show (  & 'There were no changes' ,  'w_maintain_address.ue_click_open' )
                else
                MessageBox.Show (  & 'There were some changes' ,  'w_maintain_address.ue_click_open' )
                end if
                // --------------------------------------------------------------------  */
                //  Upon the closure of Customer maintenance window, we need
                //  to check for any recipients being added or removed from 
                //  the primary contact.
                //  New Recipient     - need to create an entry in the 
                // 	                    customer_address_moves table.
                //  Deleted Recipient - do not need to do anything because 
                //                      the records would have been deleted 
                //                      from the database.
                lds_cust = new URdsDw();
                lds_cust.DataObject = new DCustomerRecipients();
                //? lds_cust.of_settransobject(StaticVariables.sqlca);
                lds_cust.Retrieve(new object[] { ll_cust_id });
                idw_movement.Retrieve(new object[] { il_adr_id });
                ldt_timestamp = StaticVariables.gnv_app.of_gettimestamp();
                //  Loop thru all customers and check for any additions first
                for (ll_x = 0; ll_x < lds_cust.RowCount; ll_x++)
                {
                    ll_cust_id = lds_cust.GetItem<CustomerRecipients>(ll_x).CustId;
                    //? ls_syntax = "cust_id=" + ll_cust_id.ToString();
                    ll_row = idw_movement.Find("cust_id", ll_cust_id);
                    if (ll_row == -1)
                    {
                        //  This is a new customer
                        ll_row = idw_movement.RowCount;
                        idw_movement.InsertItem<AddressOccupantsMovement>(ll_row);
                        idw_movement.GetItem<AddressOccupantsMovement>(ll_row).CustId = ll_cust_id;
                        idw_movement.GetItem<AddressOccupantsMovement>(ll_row).AdrId = il_adr_id;
                        idw_movement.GetItem<AddressOccupantsMovement>(ll_row).MoveInDate = ldt_timestamp;
                    }
                }
                // 	// Loop thru all existing customers and check if any has been deleted
                // 	FOR ll_x = 1 TO idw_movement.RowCount 
                // 		ll_cust_id = idw_movement.GetItemNumber ( ll_x, 'cust_id')
                // 		ls_syntax = 'cust_id=' + ll_cust_id.ToString()
                // 
                // 		ll_row = lds_cust.Find(  ls_syntax ).Length)
                // 		IF ll_row = 0 THEN
                // 			// This customer has been deleted
                // 			idw_movement.SetItem ( ll_row, 'move_out_date', ldt_timestamp)
                // 		END IF			
                // 	NEXT
            }

            //!idw_movement.Update();
            idw_movement.Save();

            //? commit;
            this.of_refresh_occupants();
        }

        public virtual void dw_details_ue_click_new()
        {
            int? ll_cust_id = 0;
            int ll_x;
            int? ll_temp = 0;
            int ll_row;
            int? ll_master = 0;
            string ls_adrnum;
            URdsDw lds_cust;
            //  TJB  NPAD2  Jan 2006  
            //  Change open of w_customer window to pass parameters through message.
            NCriteria lnv_criteria;
            NRdsMsg lnv_msg;
            //  TJB  NPAD2.1  May 2007
            //  If the addition of a new customer to a numbered address is successful 
            //  and NPAD is enabled, we need to check whether the occupation status 
            //  of the address has changed. If so, we need to send a message to NPAD 
            //  indicating the current occupied status.
            bool lb_unoccupied;
            bool lb_unnumbered;
            int ll_addr_row;
            int? ll_addr_id = 0;
            int? ll_addr_dpid = 0;
            int? ll_contract = 0;
            Cursor.Current = Cursors.WaitCursor;
            if (this.of_checkandsave() == ii_success)
            {
                //  TJB  NPAD2  Jan 2006  
                //  Change open of w_customer window to pass 
                //      parameters through message.
                //  Add address ID as a new parameter.
                // 
                //  TJB  NPAD2.1  May 2007
                //  Don't allow any customer changes until this address has been 
                //  associated with a contract.
                ll_addr_row = idw_header.GetRow();
                ll_contract = idw_header.GetItem<AddressDetails>(ll_addr_row).ContractNo;
                if (ll_contract == null || ll_contract < 1)
                {
                    MessageBox.Show("Please enter a contract for this address and press \'save\'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ll_addr_id = idw_header.GetItem<AddressDetails>(ll_addr_row).AdrId;
                ll_addr_dpid = idw_header.GetItem<AddressDetails>(ll_addr_row).DpId;
                lb_unoccupied = of_isunoccupied(ll_addr_id);
                lb_unnumbered = of_isunnumbered(ll_addr_id);
                lnv_criteria = new NCriteria();
                lnv_msg = new NRdsMsg();
                //  Determine the master_cust_id for the new customer
                ll_row = idw_details.GetRow();
                ll_master = 0;
                if (ll_row >= 0)
                {
                    //  If the selected customer has a master, the new one
                    //  will have the same master.
                    ll_master = idw_details.GetItem<AddressOccupants>(ll_row).MasterCustId;
                    if (ll_master == null || ll_master <= 0)
                    {
                        //  If the selected customer is a master, the new one
                        //  will have it as its master.
                        ll_master = idw_details.GetItem<AddressOccupants>(ll_row).CustId;
                    }
                }
                lnv_criteria.of_addcriteria("cust_id", 0);
                lnv_criteria.of_addcriteria("dp_id", 0);
                lnv_criteria.of_addcriteria("adr_id", il_adr_id);
                lnv_criteria.of_addcriteria("master_cust_id", ll_master);
                if (ib_npad_enabled)
                {
                    ll_temp = 1;
                }
                else
                {
                    ll_temp = 0;
                }
                lnv_criteria.of_addcriteria("npad_enabled", ll_temp);
                ls_adrnum = idw_header.GetItem<AddressDetails>(idw_header.GetRow()).AdrNum;
                if (ls_adrnum == null || ls_adrnum == "")
                {
                    ll_temp = 1;
                }
                else
                {
                    ll_temp = 0;
                }
                lnv_criteria.of_addcriteria("unnumbered", ll_temp);
                if (ib_RDcontract)
                {
                    ll_temp = 1;
                }
                else
                {
                    ll_temp = 0;
                }
                lnv_criteria.of_addcriteria("rd_Contract_Select", ll_temp);
                lnv_msg.of_addcriteria(lnv_criteria);
                // 	OpenWithParm ( w_customer, 0, parent)
                WCustomer w_customer = new WCustomer();
                StaticMessage.PowerObjectParm = lnv_msg;
                w_customer.ShowDialog(this);
                //  Check if a customer is being created.
                ll_cust_id = (int?)StaticMessage.ReturnValue;
                if (ll_cust_id == null || ll_cust_id <= 0)
                {
                    //  no changes made
                    return;
                }
                lds_cust = new URdsDw();
                lds_cust.DataObject = new DCustomerRecipients();
                //? lds_cust.of_settransobject(StaticVariables.sqlca);
                lds_cust.Retrieve(new object[] { ll_cust_id });
                for (ll_x = 0; ll_x < lds_cust.RowCount; ll_x++)
                {
                    ll_row = idw_movement.RowCount;
                    idw_movement.InsertItem<AddressOccupantsMovement>(ll_row);
                    idw_movement.GetItem<AddressOccupantsMovement>(ll_row).CustId = lds_cust.GetItem<CustomerRecipients>(ll_x).CustId;
                    idw_movement.GetItem<AddressOccupantsMovement>(ll_row).AdrId = il_adr_id;
                    idw_movement.GetItem<AddressOccupantsMovement>(ll_row).MoveInDate = StaticVariables.gnv_app.of_gettimestamp();
                }
                if (StaticFunctions.IsDirty(idw_movement))
                {
                    idw_movement.Save();// idw_movement.Update();
                }
                this.of_refresh_occupants();
                //  If the update was successful and NPAD is enabled and the move-out
                //  is from a numbered address and this is a Rural Delivery contract
                if (ib_npad_enabled && !lb_unnumbered && of_iscontractrd(ll_addr_id))
                {
                    //  If the occupation status has changed
                    /*  ---------------------------- Debugging ----------------------------- //
                    boolean db_unoccupied
                    db_unoccupied = of_isunoccupied ( ll_addr_id)
                    MessageBox.Show ( & "Address DPID = "+string ( ll_addr_dpid)+"\r\n" & +"Occupied status:\r\n" & +"    old = "+string ( not lb_unoccupied)+"\r\n" & +"    now = "+string ( not db_unoccupied)+"\r\n" ,  'w_maintain_address.dw_details.ue_click_new' )
                    // --------------------------------------------------------------------  */
                    if (!(lb_unoccupied == of_isunoccupied(ll_addr_id)))
                    {
                        //  Send the new occupation status to NPAD.
                        //  NOTE: lb_unoccupied is the old status, which has changed, so what 
                        //        we send is the opposite of what lb_unoccupied indicates!
                        //  TJB 14May07: Changed "Y" to 'true', "N" to 'false'
                        if (lb_unoccupied)
                        {
                            of_npad_addr_occupied(ll_addr_dpid, "true", "Changed due to new customer");
                        }
                        else
                        {
                            of_npad_addr_occupied(ll_addr_dpid, "false", "Changed due to new customer");
                        }
                    }
                }
            }
            //? Commit;
        }

        public virtual void dw_details_ue_click_remove()
        {
            //  This event removes one or more customers
            int ll_selected_row;
            int ll_row;
            int? ll_selected_cust_id = 0;
            int ll_results_rows;
            DateTime? ldt_now;
            int li_rc;
            NRdsMsg lnv_msg;
            NCriteria lnv_Criteria;
            int? ll_null = 0;
            //  TJB  NPAD2  Jan 2006
            bool lb_isMaster;
            bool lb_all_moving;
            bool lb_master_moving;
            bool lb_unnumbered;
            int? ll_old_adr_id = 0;
            int? ll_old_master_id = 0;
            int? ll_old_master_dpid = 0;
            int ll_old_master_row = -1;
            bool lb_update_ok;
            int ll_moved_custs;
            int ll_deleted_custs = 0;
            List<int?> ll_deleted_cust_id = new List<int?>();
            List<int?> ll_moved_cust_dpid = new List<int?>();
            int? ll_this_custid = 0;
            int? ll_this_dpid = 0;
            int ll_promoted_row;
            int? ll_promoted_dpid = 0;
            int? ll_promoted_cust = 0;
            int ll_cust_row;
            int? ll_contract_no = 0;
            bool lb_delete_cust;
            string ds_temp;
            //  TJB  NPAD2.1  May 2007
            bool lb_unoccupied;
            int ll_addr_row;
            int? ll_addr_id = 0;
            int? ll_addr_dpid = 0;
            //  TJB  SR4697  Dec-2006
            DateTime? ldt_moveout;
            string ls_user;
            string ls_reason;
            //  Initialise some values
            ll_null = null;
            is_cust_business = null;
            is_rural_resident = null;
            is_rural_farmer = null;
            il_adpost_quantity = null;
            ll_old_master_id = null;
            il_promoted_dpid = 0;
            ldt_now = StaticVariables.gnv_app.of_gettimestamp();
            lb_master_moving = false;
            //  Don't allow any customer changes until this address has been 
            //  associated with a contract.
            ll_addr_row = idw_header.GetRow();
            ll_contract_no = idw_header.GetItem<AddressDetails>(ll_addr_row).ContractNo;
            if (ll_contract_no == null || ll_contract_no < 1)
            {
                MessageBox.Show("Please enter a contract for this address and press \'save\'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //  Get the cust ID of the selected customer
            //  Note: there's a subtlety here.  The selected customer may not actually 
            // 			be one of the ones moving out  ( but usually is).
            // 			A separate screen is used to select the customers who are moving out.
            // 			If the selected customer is a recipient, the selection screen contains
            // 			only the selected customer.  The user has an opportunity to de-select 
            // 			the customer leaving no-one moving out.
            // 			If the selected customer is a master, the selection screen lists the
            //  		master and all associated recipients.  The user then selects those 
            // 			who are moving out.  This can be all of them, some of them, or none,
            // 			and can include the master or not.
            ll_selected_row = idw_details.GetRow();
            if (ll_selected_row < 0)
            {
                MessageBox.Show("You must select a customer before moving the customer out.", "Move customer out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            SuspendLayout();
            if (this.of_checkandsave() != ii_success)
            {
                return;
            }
            //  Get the ID of the selected customer
            ll_selected_cust_id = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustId;
            //  TJB  NPAD2  Jan 2006
            //  Note whether this is a master or recipient
            //   ( A master has no master_cust_id)
            ll_old_master_id = idw_details.GetItem<AddressOccupants>(ll_selected_row).MasterCustId;
            lb_isMaster = ll_old_master_id == null;
            //  TJB  SR4656  May 2005
            //  If the selected customer is a master, 
            //     save the inheritable properties and set a flag that this has been done.
            //  If the selected customer is a recipient  ( not a master), 
            //     save the inheritable properties of the recipient's master and set flags
            //     to show that this has been done.
            if (lb_isMaster)
            {
                //  The customer moving is a primary.  Save values.
                is_cust_business = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustBusiness;
                is_rural_resident = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustRuralResident;
                is_rural_farmer = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustRuralFarmer;
                il_adpost_quantity = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustAdpostQuantity;
                ib_saved_master_values = true;
                ll_old_master_id = ll_selected_cust_id;
            }
            else
            {
                //  Save the values of the recipient's master.
                ib_saved_master_values = false;
                //  Look up the recipients' master
                ll_row = idw_details.Find("cust_id", ll_old_master_id);
                if (ll_row >= 0)
                {
                    //  Found  ( should never not be found)
                    is_cust_business = idw_details.GetItem<AddressOccupants>(ll_row).CustBusiness;
                    is_rural_resident = idw_details.GetItem<AddressOccupants>(ll_row).CustRuralResident;
                    is_rural_farmer = idw_details.GetItem<AddressOccupants>(ll_row).CustRuralFarmer;
                    il_adpost_quantity = idw_details.GetItem<AddressOccupants>(ll_row).CustAdpostQuantity;
                    ib_saved_master_values = true;
                }
            }
            //  Determine if the source address is numbered or not
            ll_old_adr_id = of_get_adrid(ll_old_master_id);
            if (ll_old_adr_id <= -1)
            {
                ds_temp = ll_old_master_id.ToString();
                if (ll_old_master_id == null)
                {
                    ds_temp = "null";
                }
                MessageBox.Show("Unable to determine address of moving customer ( s)\r\n" + "Primary customer ID is " + ds_temp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lb_unnumbered = of_isunnumbered(ll_old_adr_id);
            //  TJB  NPAD2.1  May 2007
            //  Remember the occupation state before doing the manipulations
            //   ( NOTE: ll_old_adr_id = ll_addr_id.  See use below))
            ll_addr_id = idw_header.GetItem<AddressDetails>(ll_addr_row).AdrId;
            ll_addr_dpid = idw_header.GetItem<AddressDetails>(ll_addr_row).DpId;
            lb_unoccupied = of_isunoccupied(ll_addr_id);
            /* ******************************************************************
            * Determine which customers are moving.
            *
            * NOTE: If the initially selected customer is a recipient, the list
            *			will only contain that customer.  If the initially selected 
            *			customer is a master, the list will contain the master and 
            *			all its recipients.  The user can choose at this stage to 
            *			exclude the originally-selected customer from the list of 
            *			customers to move.
            ******************************************************************* */
            ids_results = new DAddressSelectOccupants();
            //? ids_results.of_settransobject(StaticVariables.sqlca);
            ((DAddressSelectOccupants)ids_results).Retrieve(ll_selected_cust_id);
            //? ids_results.of_setupdateable(true);
            WAddressMoveoutOccupants w_address_moveout_occupants = new WAddressMoveoutOccupants();
            StaticMessage.PowerObjectParm = ids_results;
            w_address_moveout_occupants.ShowDialog();
            ids_results = (DAddressSelectOccupants)StaticMessage.PowerObjectParm;
            if (ids_results == null || !(ids_results != null))
            {
                //  User cancelled the select window
                return;
            }
            //  See how many have moved
            ll_results_rows = ids_results.RowCount;
            if (ll_results_rows <= 0)
            {
                //  No rows to action  ( nobody selected to move out)
                return;
            }
            //  TJB  NPAD2  Jan 2006
            //  Set flag if all customers at this address are moving out
            lb_all_moving = false;
            if (dw_details.RowCount == ids_results.RowCount)
            {
                lb_all_moving = true;
            }
            lb_master_moving = false;
            /*  ---------------------------- Debugging ----------------------------- //
            ds_temp = ll_old_master_id.ToString()
            if isnull ( ll_old_master_id) then ds_temp = 'null'
            MessageBox.Show ( & 'lb_isMaster        = '+string ( lb_ismaster)  +'\r\n'  & +'lb_all_moving      = '+string ( lb_all_moving)+'\r\n'  & +'old_master_id      = '+ds_temp              +'\r\n'  & +'old_adr_id         = '+string ( ll_old_adr_id)+'\r\n'  & +'old adr unnumbered = '+string ( lb_unnumbered)       & ,  'w_maintain_address.dw_details.ue_click_remove' )
            // --------------------------------------------------------------------  */
            /* ******************************************************************
            * ids_results now contains a list of occupants moving out 
            * If none of the customers moving is a primary customer
            *		We can simply mark them all 'moved_out'.
            * otherwise
            *		If any are remaining, we need to select one as the 
            *		master and link any others that aren't moving out
            *		as recipients of the new master.
            *	end if
            *
            * TJB NPAD2 16 Mar 2006  ** change **
            * When a recipient moves out, delete the recipient from both
            * the rds_customer and customer_address_moves tables.  Leave the
            * master behind with the 'move_out_date' set.
            ******************************************************************* */
            /*  ---------------------------- Debugging ----------------------------- //
            string	ds_surname, ds_initials, ds_id
            FOR ll_row = 1 TO ids_results.RowCount
            ds_id       = string ( ids_results.getitemNumber ( ll_row,'cust_id'))
            ds_surname  = ids_results.getitemstring ( ll_row,'cust_surname_company')
            ds_initials = ids_results.getitemstring ( ll_row,'cust_initials')
            if isnull ( ds_id)       then ds_id       = 'null'
            if isnull ( ds_surname)  then ds_surname  = 'null'
            if isnull ( ds_initials) then ds_initials = 'null'
            MessageBox.Show ( & 'Results: row '+string ( ll_row)+'\r\n'  & +'ID       = '+ds_id+'\r\n'  & +'Surname  = '+ds_surname+'\r\n'  & +'Initials = '+ds_initials ,  'w_maintain_address.dw_details.ue_click_remove' )
            NEXT	
            // --------------------------------------------------------------------  */
            //  See if the master is moving.
            //  Note: There can only ever be one master customer moving since 
            // 			the set to select from is either a single recipient or 
            // 			a master and its associated recipients  ( not all occupants 
            // 			at the 'from' address).
            ll_promoted_dpid = 0;
            ll_promoted_cust = 0;

            //! ll_old_master_row = ids_results.Find("master_cust_id", null);
            for (int i = 0; i < ids_results.RowCount; i++)
            {
                AddressSelectOccupants record = ids_results.GetItem<AddressSelectOccupants>(i);
                if (!record.MasterCustId.HasValue)
                {
                    ll_old_master_row = i;
                    break;
                }
            }

            //! if not found it would be -1
            if (ll_old_master_row >= 0)
            {
                //  A master and possibly some recipients is moving
                lb_master_moving = true;
                //  We need to determine who of those left behind will be the new master
                //  at the old address  ( the "new_old_master").
                //  "old_master_id" is the cust ID of the master that is moving
                //  "old_master_dpid" is the DPID of the master that is moving
                ll_old_master_id = ids_results.GetItem<AddressSelectOccupants>(ll_old_master_row).CustId;
                ll_old_master_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_old_master_row).DpId;
                //  Make the first of the recipients left behind the "new_old_master", and
                //  make it the master of any others who also are not moving out.
                //  Step through the dw_details  ( customer) data window, since the customers
                //  who aren't moving aren't in the 'results' list.
                if (!lb_all_moving)
                {
                    ll_promoted_row = of_promote_old_recipient(ll_old_master_id, ll_old_master_dpid);
                    if (ll_promoted_row >= 0)
                    {
                        ll_promoted_dpid = idw_details.GetItem<AddressOccupants>(ll_promoted_row).DpId;
                        ll_promoted_cust = idw_details.GetItem<AddressOccupants>(ll_promoted_row).CustId;
                    }
                }
            }
            //  If a recipient was promoted, we need to update the address record
            if (ll_promoted_dpid > 0)
            {
                dw_header.GetItem<AddressDetails>(dw_header.GetRow()).DpId = ll_promoted_dpid;
            }
            //  Now we can move everyone out
            ll_moved_custs = 0;
            for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
            {
                ll_this_custid = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustId;
                ll_this_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                lb_delete_cust = false;
                //  Set moved_out date
                //  TJB  SR4697  Dec-2006
                //  Fix bug: don't set the date/reason/user if already set 
                //           in w_address_moveout_occupants
                ldt_moveout = ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate;
                ls_reason = ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutSource;
                ls_user = ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutUser;
                /*  ---------------------------- Debugging ----------------------------- //
                string	ds_custid, ds_moveout, ds_reason, ds_user
                ds_custid = ll_this_custid.ToString()
                if isnull ( ll_this_custid) then ds_custid = 'null'
                ds_moveout = ldt_moveout.ToString()
                if isnull ( ds_moveout) then ds_moveout = 'null'
                ds_reason  = ls_reason
                if isnull ( ds_reason) then ds_reason = 'null'
                ds_user    = ls_user
                if isnull ( ds_user) then ds_user = 'null'
                MessageBox.Show (   & 'Cust       = '+ds_custid+'\r\n'  & +'Moveout   = '+ds_moveout+'\r\n' & +'Reason    = '+ds_reason+'\r\n'  & +'User      = '+ds_user,  'w_maintain_address.dw_details.ue_click_remove' )
                // --------------------------------------------------------------------  */
                if (ldt_moveout == null)
                {
                    ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate = ldt_now;
                }
                if (ls_reason == null)
                {
                    ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutSource = "move-out";
                }
                if (ls_user == null)
                {
                    ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutUser = is_userid;
                }
                //  If the master is no longer the master  ( a recipient 
                //  was promoted), delete the master  ( its now a recipient) 
                if (ll_this_custid == ll_old_master_id)
                {
                    if (ll_promoted_dpid > 0)
                    {
                        //  lb_delete_cust = TRUE
                        ll_deleted_custs++;

                        //!ll_deleted_cust_id[ll_deleted_custs] = ll_this_custid;
                        ll_deleted_cust_id.Add(ll_this_custid);

                        ll_moved_custs++;
                        //!ll_moved_cust_dpid[ll_moved_custs] = ll_this_dpid;
                        ll_moved_cust_dpid.Add(ll_this_dpid);
                    }
                }
                else
                {
                    //  	lb_delete_cust = TRUE
                    ll_deleted_custs++;

                    //!ll_deleted_cust_id[ll_deleted_custs] = ll_this_custid;
                    ll_deleted_cust_id.Add(ll_this_custid);
                    ll_moved_custs++;
                    //!ll_moved_cust_dpid[ll_moved_custs] = ll_this_dpid;
                    ll_moved_cust_dpid.Add(ll_this_dpid);

                    //  If a non-moving recipient was promoted, make that new master
                    //  this  ( moving) recipient's master  ( to avoid potential problems
                    //  deleting the moving recipient later.
                    //  Note
                    //  	Whatever the comments below say, what happens is this: if the 
                    //  	master and some recipients move out leaving a new master behind, 
                    // 		the master considered a recipient and deleted along with any 
                    // 		moving recipients. But the routine that promotes a recipient only 
                    // 		updates the master_cust_id of the non-moving recipients leaving 
                    // 		any moving recipients with the demoted master as their master.  
                    // 		When it comes to deleting the moving recipients, if the old master 
                    // 		is deleted first  ( and we can't be sure of the order of the customers 
                    // 		in the results list), the foreign key on the master_cust_id for the 
                    // 		not-yet-deleted recipients is broken and the delete fails.  We can't 
                    // 		change the promotion routing because it is used by the Transfer 
                    // 		function where the master isn't going to be deleted and the 
                    // 		relationship between the master and moving out recipients is to 
                    // 		be preserved.  Hence this hack.
                    if (ll_promoted_dpid > 0)
                    {
                        ll_cust_row = idw_details.Find("cust_id", ll_this_custid);
                        idw_details.GetItem<AddressOccupants>(ll_cust_row).MasterCustId = ll_promoted_cust;
                    }
                }
            }
            /* ******************************************************************
            *
            * Now we update the rds_customer and customer_address_moves tables
            * with the accumulated changes.
            *
            ****************************************************************** */
            lb_update_ok = false;
            //  This updates the changes to promoted/demoted masters
            //  and deleted recipients .
            li_rc = 1;
            ids_results.Save();        // Updates the customer_address_moves table
            if (li_rc == 1)
            {
                li_rc = 1;
                idw_details.Save();    // Updates the rds_customer table
                if (li_rc == 1)
                {
                    li_rc = 1;
                    idw_header.Save(); // Updates the address table
                }
            }
            //  Do it in this sequence so that, if a recipient is promoted, the 
            //  database reflects that before deleting the recipients. There was
            //  a problem deleting the old master due to a loop-back foreign key 
            //  on the master_cust_id that this fixes.
            if (li_rc == 1)
            {
                for (ll_row = 0; ll_row < ll_deleted_custs; ll_row++)
                {
                    ll_this_custid = ll_deleted_cust_id[ll_row];
                    /*  ---------------------------- Debugging ----------------------------- //
                    string ds_cust
                    ds_cust = ll_this_custid.ToString()
                    if isnull ( ll_this_custid) then ds_cust = 'null'
                    MessageBox.Show (   & 'Delete recipient '+ds_cust ,  'w_maintain_address.dw_details.ue_click_remove' )
                    // --------------------------------------------------------------------  */
                    of_delete_recipient(ll_this_custid);
                }
                li_rc = 1; ids_results.Save();
                if (li_rc == 1)
                {
                    li_rc = 1; idw_details.Save();
                }
            }
            //  If all the updates have worked, commit the changes
            //  otherwise advise there was an error and roll them back.
            if (li_rc == 1)
            {
                //? COMMIT;
                lb_update_ok = true;
            }
            else
            {
                //? ROLLBACK;
                lb_update_ok = false;
            }
            if (!lb_update_ok)
            {
                MessageBox.Show("Failed to update database", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*  ---------------------------- Debugging ----------------------------- //
                else
                MessageBox.Show (   & 'Updates successful',  'w_maintain_address.dw_details.ue_click_remove' )
                // --------------------------------------------------------------------  */
            }
            /* ******************************************************************
            *
            * If the update was successful and NPAD is enabled and the move-out
            * is from an unnumbered address, we need to tell NPAD to delete the
            * customers to keep the databases synchronised.
            *
            * TJB  NPAD2.1  May 2007: 
            * If the update was successful and NPAD is enabled and the move-out
            * is from a numbered address, we need to check whether this address 
            * is occupied or not, and whether its occupation status has changed.
            * If so, we need to send a message to NPAD indicating the current 
            * occupancy status.
            ****************************************************************** */
            bool lb_npad_enabled;
            lb_npad_enabled = ib_npad_enabled;
            if (lb_update_ok && ib_npad_enabled && lb_unnumbered)
            {
                /*  ---------------------------- Debugging ----------------------------- //
                string	ds_old_adr_id, ds_old_master
                string	ds_promoted
                if isnull ( ll_old_adr_id)		then ds_old_adr_id = 'null' else ds_old_adr_id = ll_old_adr_id.ToString()
                if isnull ( ll_old_master_id)	then ds_old_master = 'null' else ds_old_master = ll_old_master_id.ToString()
                if isnull ( ll_old_master_dpid)	then ds_old_master += '  ( null)' else ds_old_master += '  ( '+ll_old_master_dpid)+'.ToString()'
                if isnull ( il_cust_promoted)	then ds_promoted   = 'null' else ds_promoted   = il_cust_promoted.ToString()
                if isnull ( il_promoted_dpid)	then ds_promoted += '  ( null)' else ds_promoted += ' ( '+il_promoted_dpid)+'.ToString()'
                MessageBox.Show ( & 'Move-out from an unnumbered address.\r\n'  & +'Customers moved = '+string ( ll_results_rows)+'\r\n'  & +'Old address     = '+ds_old_adr_id+'\r\n'  & +'Old master      = '+ds_old_master+'\r\n'  & +'Old master moving = '+string ( lb_master_moving)+'\r\n'  &	 +'Cust promoted   = '+ds_promoted+'\r\n'				,  'w_maintain_address.dw_details.ue_click_remove' )
                // --------------------------------------------------------------------  */
                //  If the master is moving and at least one recipient isn't 
                //  and has been promoted to be the new master, send a transfer 
                //  message so the two swap roles in NPAD's eyes.
                if (lb_master_moving && ll_promoted_dpid > 0)
                {
                    /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show ( & 'Promote recipient '+string ( ll_promoted_dpid,  'w_maintain_address.dw_details.ue_click_remove' )
                    // --------------------------------------------------------------------  */
                    of_npad_xferone(ll_old_master_dpid, ll_promoted_dpid, "RDS swap master - recipient");
                }
                //  If the master and all recipients are moving,
                //  tell NPAD to delete the master.  NPAD will also delete 
                //  all the master's recipients.  We can tell that all
                //  recipients are moving because none will have been promoted
                //  to being the master at the old address.
                if (lb_master_moving && ll_promoted_dpid == 0)
                {
                    /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show ( & 'All moved out.  Move out master'+string ( ll_old_master_dpid,  'w_maintain_address.dw_details.ue_click_remove' )
                    // --------------------------------------------------------------------  */
                    of_npad_deleteone(ll_old_master_dpid, "RDS delete master");
                }
                else
                {
                    //   ( the master, if included, will be treated as a recipient
                    //  by NPAD because of the Transfer above).
                    //  of_npad_deleteAll (  'RDS delete recipients' )
                    for (ll_row = 0; ll_row < ll_moved_custs; ll_row++)
                    {
                        ll_this_dpid = ll_moved_cust_dpid[ll_row];
                        /*  ---------------------------- Debugging ----------------------------- //
                        MessageBox.Show ( & 'Move out recipient '+string ( ll_this_dpid,  'w_maintain_address.dw_details.ue_click_remove' )
                        // --------------------------------------------------------------------  */
                        of_npad_deleteone(ll_this_dpid, "RDS delete recipient");
                    }
                }
            }
            //  Check to see if the moved-out-of address is now unoccupied
            //  If so, and if it is an unnumbered address, delete it
            //   ( we can't have unoccupied unnumbered addresses in our database)
            if (lb_unnumbered)
            {
                if (of_isunoccupied(ll_old_adr_id))
                {
                    /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show ( & 'Address is now unoccupied - delete it.  \r\n'  & +string ( ll_old_adr_id,  'w_maintain_address.dw_details.ue_click_remove' )
                    // --------------------------------------------------------------------  */
                    /* delete from address  where adr_id = :ll_old_adr_id  using SQLCA; */
                    RDSDataService dataService = RDSDataService.DeleteAddressByAdrId(ll_old_adr_id);
                    if (dataService.SQLCode < 0)
                    {
                        MessageBox.Show("A database error has occurred deleting the unoccupied address.\r\n\r\n" + "Address ID = " + ll_old_adr_id + "\r\n\r\n" + "Database error code:  " + dataService.SQLDBCode + '~' + "Database error message:\r\n    " + dataService.SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //? rollback;
                    }
                    else
                    {
                        //? commit;
                    }
                }
            }
            //  TJB  NPAD2.1  May 2007: 
            //  If the update was successful and NPAD is enabled and the move-out
            //  is from a numbered address and this is a Rural Delivery contract
            if (lb_update_ok && ib_npad_enabled && !lb_unnumbered && of_iscontractrd(ll_addr_id))
            {
                //  If the occupation status has changed
                /*  ---------------------------- Debugging ----------------------------- //
                boolean db_unoccupied
                db_unoccupied = of_isunoccupied ( ll_addr_id)
                MessageBox.Show ( & "Address DPID = "+string ( ll_addr_dpid)+"\r\n" & +"Occupied status:\r\n" & +"    old = "+string ( not lb_unoccupied)+"\r\n" & +"    now = "+string ( not db_unoccupied)+"\r\n" ,  'w_maintain_address.dw_details.ue_click_remove' )
                // --------------------------------------------------------------------  */
                if (!(lb_unoccupied == of_isunoccupied(ll_addr_id)))
                {
                    //  Send the new occupation status to NPAD.
                    //  NOTE: lb_unoccupied is the old status, which has changed, so what 
                    //        we send is the opposite of what lb_unoccupied indicates!
                    //  TJB 14May07: Changed "Y" to 'true', "N" to 'false'
                    if (lb_unoccupied)
                    {
                        of_npad_addr_occupied(ll_addr_dpid, "true", "Changed due to customer move");
                    }
                    else
                    {
                        of_npad_addr_occupied(ll_addr_dpid, "false", "Changed due to customer move");
                    }
                }
            }
            //  Done
            ResumeLayout();
            this.of_refresh_occupants();
        }

        public virtual void dw_details_ue_click_transfer()
        {
            //  This event transfers one or more customers to a new address.
            int? ll_new_adr_id = 0;
            int? ll_new_master_id = 0;
            int? ll_this_cust_id = 0;
            int? ll_this_cust_dpid = 0;
            int? ll_this_cust_master = 0;
            int ll_this_cust_row = 0;
            int? ll_this_master = 0;
            int? ll_this_master_id = 0;
            int ll_this_master_row;
            int? ll_this_master_dpid = 0;
            int ll_selected_row;
            int ll_row;
            int? ll_selected_cust_id = 0;
            int ll_results_rows;
            int ll_new_row;
            int ll_found;
            int li_rc;
            int? li_temp = 0;
            DateTime? ldt_now;
            bool lb_new_master_exists;
            NRdsMsg lnv_msg;
            NCriteria lnv_Criteria;
            WAddressSearchSelect lw_search;
            int? ll_null = 0;
            string ls_null;
            //  TJB  NPAD2  Jan 2006
            int? ll_old_adr_id = 0;
            int? ll_old_master_id = 0;
            int? ll_old_master_dpid = 0;
            int? ll_old_dpid = 0;
            int? ll_cust_dpid = 0;
            int? ll_to_master_dpid = 0;
            int? ll_new_master_dpid = 0;
            int ll_new_master_row;
            int? ll_contract_no = 0;
            int ll_promoted_row;
            int? ll_promoted_dpid = 0;
            int? ll_promoted_recipient = 0;
            int? ll_temp = 0;
            int ll_dummy_row;
            string ds_cust;
            string ds_dpid;
            string ds_temp;
            string ds_adr;
            string ls_cust_title;
            string ls_cust_initials;
            string ls_cust_name;
            string ds_msg;
            bool lb_update_ok;
            bool lb_isMaster;
            bool lb_all_moving;
            bool lb_master_moving;
            bool lb_old_unnumbered;
            bool lb_new_unnumbered;
            bool lb_replace_custs;
            //  Initialise some values
            ll_null = null;
            ls_null = null;
            is_cust_business = null;
            is_rural_resident = null;
            is_rural_farmer = null;
            il_adpost_quantity = null;
            ll_old_master_id = null;
            ll_old_master_dpid = null;
            il_promoted_dpid = null;
            il_demoted_dpid = null;
            ll_promoted_recipient = null;
            ldt_now = StaticVariables.gnv_app.of_gettimestamp();
            lb_master_moving = false;
            lb_new_unnumbered = false;
            //  TJB  NPAD2.1  May 2007
            //  If the result of the transfer is that the occupied status of either
            //  or both the from and to addresses changes, and if NPAD is enabled, 
            //  message ( s) need to be sent to NPAD with the current status.
            bool lb_old_unoccupied;
            bool lb_new_unoccupied;
            int ll_addr_row;
            int? ll_old_dp_id = 0;
            int? ll_new_dp_id = 0;
            bool lb_RDcontract;
            //  Don't allow any customer changes until this address has been 
            //  associated with a contract.
            ll_addr_row = idw_header.GetRow();
            ll_contract_no = idw_header.GetItem<AddressDetails>(ll_addr_row).ContractNo;
            if (ll_contract_no == null || ll_contract_no < 1)
            {
                MessageBox.Show("Please enter a contract for this address and press \'save\'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //  Get the cust ID of the selected customer
            //  Note: there's a subtlety here.  The selected customer may not actually 
            // 			be one of the ones transferring  ( but usually is).
            // 			A separate screen is used to select the customers who are transferring.
            // 			If the selected customer is a recipient, the selection screen contains
            // 			only the selected customer.  The user has an opportunity to de-select 
            // 			the customer leaving no-one transferring.
            // 			If the selected customer is a master, the selection screen lists the
            //  		master and all associated recipients.  The user then selects those 
            // 			who are transferring.  This can be all of them, some of them, or none,
            // 			and can include the master or not.
            ll_selected_row = idw_details.GetRow();
            if (ll_selected_row < 0)
            {
                MessageBox.Show("You must select a customer before transferring the customer.", "Transfer Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            SuspendLayout();
            if (this.of_checkandsave() != ii_success)
            {
                return;
            }
            //  TJB  NPAD2.1  May 2007
            //  Save the DPID of the old address for use if we need to send 
            //  an address occupied status message to NPAD.
            ll_old_dp_id = idw_header.GetItem<AddressDetails>(ll_addr_row).DpId;
            //  Get the ID of the selected customer
            ll_selected_cust_id = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustId;
            //  TJB  NPAD2  Jan 2006
            //  Note whether this is a master or recipient
            //   ( A master has no master_cust_id)
            ll_old_master_id = idw_details.GetItem<AddressOccupants>(ll_selected_row).MasterCustId;
            lb_isMaster = ll_old_master_id == null;
            //  TJB  SR4656  May 2005
            //  If the selected customer is a primary, 
            //     save the inheritable properties and set a flag that this has been done.
            //  If the selected customer is not a primary, 
            //     save the inheritable properties of the recipient's primary and set flags
            //     to show that this has been done.
            if (lb_isMaster)
            {
                //  The customer transferring is a primary.  Save values.
                is_cust_business = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustBusiness;
                is_rural_resident = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustRuralResident;
                is_rural_farmer = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustRuralFarmer;
                il_adpost_quantity = idw_details.GetItem<AddressOccupants>(ll_selected_row).CustAdpostQuantity;
                ib_saved_master_values = true;
                ll_old_master_id = ll_selected_cust_id;
            }
            else
            {
                //  Save the values of the recipient's primary.
                ib_saved_master_values = false;
                //  Look up the recipients' primary
                ll_row = idw_details.Find("cust_id", ll_old_master_id);
                if (ll_row >= 0)
                {
                    //  Found  ( should never not be found)
                    is_cust_business = idw_details.GetItem<AddressOccupants>(ll_row).CustBusiness;
                    is_rural_resident = idw_details.GetItem<AddressOccupants>(ll_row).CustRuralResident;
                    is_rural_farmer = idw_details.GetItem<AddressOccupants>(ll_row).CustRuralFarmer;
                    il_adpost_quantity = idw_details.GetItem<AddressOccupants>(ll_row).CustAdpostQuantity;
                    ib_saved_master_values = true;
                }
            }
            //  Determine if the source address is numbered or not
            ll_old_adr_id = dw_details.GetItem<AddressOccupants>(ll_selected_row).AdrId;
            if (ll_old_adr_id <= 0)
            {
                if (ll_old_master_id == null)
                {
                    ds_temp = "null";
                }
                else
                {
                    ds_temp = ll_old_master_id.ToString();
                }
                MessageBox.Show("Unable to determine address of transferring customer ( s)\r\n" + "Primary customer ID is " + ds_temp, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lb_old_unnumbered = of_isunnumbered(ll_old_adr_id);
            //  TJB  NPAD2.1  May 2007
            //  Save the initial occupied status of the old address
            lb_old_unoccupied = of_isunoccupied(ll_old_adr_id);
            /* ******************************************************************
            * Determine which customers are transferring.
            *
            * NOTE: If the initially selected customer is a recipient, the list
            *			will only contain that customer.  If the initially selected 
            *			customer is a master, the list will contain the master and 
            *			all its recipients.  The user can choose at this stage to 
            *			exclude the originally-selected customer from the list of 
            *			customers to transfer.
            ******************************************************************* */
            ids_results = new DAddressSelectOccupants();
            //? ids_results.of_settransobject(StaticVariables.sqlca);
            ((DAddressSelectOccupants)ids_results).Retrieve(ll_selected_cust_id);
            //? ids_results.of_setupdateable(true);
            WAddressTransferOccupants w_address_transfer_occupants = new WAddressTransferOccupants();
            StaticMessage.PowerObjectParm = ids_results;
            w_address_transfer_occupants.ShowDialog();
            ids_results = (DAddressSelectOccupants)StaticMessage.PowerObjectParm;
            if (ids_results == null || !(ids_results != null))
            {
                //  If the user cancelled the select window
                return;
            }
            else if (ids_results.RowCount <= 0)
            {
                //  or no rows to action  ( no customers selected to transfer)
                return;
            }
            //  TJB  NPAD2  Jan 2006
            //  Set flag if all customers at this address are transferring
            lb_all_moving = false;
            if (idw_details.RowCount == ids_results.RowCount)
            {
                lb_all_moving = true;
            }
            else if (!lb_old_unnumbered)
            {
                //  If the 'from' address is numbered, it may have more than one master
                //  and one of the masters and all its recipients may be transferring.
                ll_row = ids_results.Find("cust_id", ll_selected_cust_id);
                if (ll_row >= 0)
                {
                    if (ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId == null)
                    {
                        //  The selected customer is a master.  Determine the number of 
                        //  recipients associated with it.
                        ll_temp = of_count_recipients(ll_selected_cust_id);
                        if (ll_temp + 1 == ids_results.RowCount)
                        {
                            //  The master and all its associated recipients are transferring.
                            lb_all_moving = true;
                        }
                    }
                }
            }
            //  Check to make sure we're not trying to transfer a dummy customer
            for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
            {
                ls_cust_name = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustSurnameCompany;
                if (ls_cust_name.Length > 4 && ls_cust_name.Substring(0, 5) == "Dummy")
                {
                    MessageBox.Show("Dummy customers cannot transfer to another address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResumeLayout();
                    return;
                }
            }
            /* ******************************************************************
            * Now, select the address the customer is transfering to.
            *
            * Note: If NPAD is enabled, the user will not be able to create a 
            *			new address to transfer to.  If NPAD isn't enabled, the user 
            *			can create new addresses.  The usual is to select an existing
            *			address to transfer to.
            ******************************************************************* */
            if (ib_RDcontract)
            {
                li_temp = 1;
            }
            else
            {
                li_temp = 0;
            }
            StaticVariables.gnv_app.of_get_parameters().longparm = li_temp;

            lw_search = new WAddressSearchSelect();
            StaticMessage.StringParm = "SELECT";
            lw_search.ShowDialog();
            lnv_msg = (StaticMessage.PowerObjectParm == null ? null : (NRdsMsg)StaticMessage.PowerObjectParm);//lnv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            if (lnv_msg == null || !(lnv_msg != null))
            {
                //  User cancelled out of the window
                ResumeLayout();
                return;
            }
            lnv_Criteria = lnv_msg.of_getcriteria();
            //  Get the selected values.
            // 		adr_id  of the selected address
            //  	cust_id of the master customer at the address
            if (!(lnv_Criteria.of_getcriteria("adr_id") == null))
            {
                ll_new_adr_id = (int)lnv_Criteria.of_getcriteria("adr_id");
            }
            else
            {
                //  No address selected
                //  User has cancelled out of the Select Address window
                return;
            }
            if (ll_old_adr_id == ll_new_adr_id)
            {
                MessageBox.Show("The old and new addresses cannot be the same. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //  TJB  NPAD2  Jan 2006
            //  Determine if the transfer is to an unnumbered address
            lb_new_unnumbered = of_isunnumbered(ll_new_adr_id);
            //  TJB  NPAD2.1  May 2007
            //  Save the initial occupied status of the new address
            lb_new_unoccupied = of_isunoccupied(ll_new_adr_id);
            //  Get the cust_id of the master at the new address
            if (!(lnv_Criteria.of_getcriteria("cust_id") == null))
            {
                ll_new_master_id = (int)lnv_Criteria.of_getcriteria("cust_id");
            }
            if (ll_new_master_id == null || ll_new_master_id <= 0)
            {
                //  The new address doesn't yet have a master customer 
                //   ( and by inference must be a numbered address since an 
                //   unnumbered address must have a master).
                ll_new_master_id = null;
                ll_new_master_dpid = null;
                lb_new_master_exists = false;
            }
            else
            {
                //  The address does have a master
                ll_new_master_dpid = of_get_dpid(ll_new_master_id);
                lb_new_master_exists = true;
            }
            Cursor.Current = Cursors.WaitCursor;
            SuspendLayout();
            /* *************************************************************************
            **************************************************************************
            **                                                                      **
            ** At about this point, if the 'to' address is unnumbered and NPAD is   **
            ** enabled, we need to determine if the address is new or not.  If it   **
            ** is, the occupants there will be dummys and the transferring custs    **
            ** will take on the dummy's roles  ( and their DPIDs). If not, the trans- **
            ** ferring customers will become recipients of the existing master.     **
            **                                                                      **
            **************************************************************************
            ************************************************************************* */
            lb_replace_custs = false;
            ds_msg = "Add custs to new address";
            il_dummy_custs = 0;
            il_dummy_recipients = 0;
            il_dummy_masters = 0;
            //  If NPAD is enabled and the new address is unnumbered, determine 
            //  whether any of the occupants are dummy occupants.
            if (ib_npad_enabled && lb_new_unnumbered)
            {
                /* select count ( cam.cust_id) 
                    into :il_dummy_custs
                    from rds_customer c,
                    customer_address_moves cam
                    where c.cust_id    = cam.cust_id
                    and cam.adr_id   = :ll_new_adr_id
                    and cam.move_out_date is null
                    and c.cust_surname_company like 'Dummy%'
                    using SQLCA; */
                RDSDataService dataService = RDSDataService.GetCustomerAddressMovesCountByIdMoveOutDate(ll_new_adr_id);
                il_dummy_custs = dataService.intVal;
                if (il_dummy_custs > 0)
                {
                    //  There are dummy occupants at the new address
                    //  Determine the number of masters  ( should only be 1) and recipients
                    il_dummy_masters = of_getdummymasterdpid(ll_new_adr_id);
                    il_dummy_recipients = of_getdummycustdpids(ll_new_adr_id);
                    for (ll_dummy_row = 0; ll_dummy_row < il_dummy_custs; ll_dummy_row++)
                    {
                        //!il_dummy_status[ll_dummy_row] = 0;
                        il_dummy_status.Add(0);
                    }
                    if (!lb_old_unnumbered)
                    {
                        //  The transfer is from a numbered address.
                        //  There must be the same number of dummy customers as 
                        //  those transferring.
                        if (il_dummy_custs == ids_results.RowCount)
                        {
                            lb_replace_custs = true;
                            ds_msg = "Replacing " + il_dummy_custs.ToString() + " dummy custs at new address";
                        }
                        else
                        {
                            MessageBox.Show("There is an incorrect number of dummy customers at the address \r\n" + "being moved to  ( there must be the same number of dummy customers \r\n" + "as are transferring when transferring from a numbered address).\r\n" + " ( customers transferring = " + ids_results.RowCount + "; dummy customers found = " + il_dummy_custs + ")\r\n\r\n" + "Cancelling transfer ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //  setRedraw ( TRUE)
                            //  RETURN
                            ds_msg = "Incorrect number of dummy customers for transfer";
                        }
                    }
                    else
                    {
                        //  The distinction here is that the transferring customers
                        //  already have DPIDs, so there only needs to be a dummy master 
                        //  at the new address  ( needed to create the address).  Any others
                        //  will be ignored.
                        if (il_dummy_custs > ids_results.RowCount)
                        {
                            MessageBox.Show("There are too many dummy customers at the address being moved to \r\n" + " ( customers transferring = " + ids_results.RowCount + "; dummy customers found = " + il_dummy_custs + ")\r\n\r\n" + "Cancelling transfer ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //  setRedraw ( TRUE)
                            //  RETURN
                            ds_msg = "Too many dummy customers for transfer";
                        }
                    }
                }
                else
                {
                    //  There are no dummy customers at the destination address
                    if (!lb_old_unnumbered)
                    {
                        //  The transfer is from a numbered address
                        if (ib_npad_enabled)
                        {
                            //  If NPAD is enabled, there must be dummy customers at the 
                            //  new address when the transfer is from a numbered address.
                            MessageBox.Show("The destination address must have dummy customers for \r\n" + "each customer transferring from a numbered address. \r\n" + " ( customers transferring = " + ids_results.RowCount + "; dummy customers found = " + il_dummy_custs + ")\r\n\r\n" + "Cancelling transfer ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //  setRedraw ( TRUE)
                            //  RETURN
                            ds_msg = "No dummy customers for transfer";
                        }
                    }
                }
            }
            /*  ---------------------------- Debugging ----------------------------- //
            string	ds_first_recipient, ds_dummy_master, ds_no_details, ds_no_results
            string	ds_msg2
            if isnull ( ll_old_master_id)  then ds_temp = 'null' else ds_temp = ll_old_master_id.ToString()
            if isnull ( ll_new_master_id)  then ds_cust = 'null' else ds_cust = ll_new_master_id.ToString()
            ds_no_details = string ( idw_details.RowCount)
            ds_no_results = string ( ids_results.RowCount)
            ds_dummy_master = ''
            if il_dummy_masters > 0 then
            ds_dummy_master = ' ( DPID ='+il_dummy_master_dpid.ToString()  &
            +', Cust ='+il_dummy_master_cust)+'.ToString()\r\n'
            end if
            ds_first_recipient = ''
            if il_dummy_recipients > 0 then
            ds_first_recipient = ' ( DPID ='+il_dummy_dpid[1].ToString()  &
            +', Cust ='+il_dummy_cust[1])+'.ToString()\r\n'
            end if
            ds_msg2 = 'Transfer '
            if lb_old_unnumbered then ds_msg2 += 'unnumbered' else ds_msg2 += 'numbered'	
            ds_msg2 += ' to '
            if lb_new_unnumbered then ds_msg2 += 'unnumbered' else ds_msg2 += 'numbered'	
            li_temp = messagebox ( 'w_maintain_address.idw_details.ue_click_transfer',  &
            'ib_npad_enabled     = '+ib_npad_enabled.ToString()+'\r\n\r\n'  &
            +'lb_isMaster        = '+lb_ismaster.ToString()  +'\r\n'  &
            +'lb_all_moving      = '+lb_all_moving.ToString()+'\r\n'  &
            +'old_master_id      = '+ds_temp              +'\r\n'  &
            +'old_adr_id         = '+ll_old_adr_id.ToString()+'\r\n'  &
            +'old adr unnumbered = '+lb_old_unnumbered.ToString()+'\r\n'  &
            +'new_adr_id         = '+ll_new_adr_id.ToString()+'\r\n'  &
            +'new adr unnumbered = '+lb_new_unnumbered.ToString()+'\r\n'  &
            +'new_master_id      = '+ds_cust              +'\r\n'  &
            +'new_master_exists  = '+lb_new_master_exists.ToString()+'\r\n'  &
            +'lb_replace_custs   = '+lb_replace_custs.ToString() +'\r\n'  &
            +'# details          = '+ds_no_details+'\r\n'  &
            +'# results          = '+ds_no_results+'\r\n'  &
            +'il_dummy_masters   = '+il_dummy_masters.ToString()+'\r\n'  &
            +ds_dummy_master &
            +'il_dummy_recipients = '+il_dummy_recipients.ToString()+'\r\n'  &
            +ds_first_recipient &
            +'\r\n'+ds_msg2+'\r\n'  &
            +'*** '+ds_msg+' ***'  &
            ,Exclamation!,OkCancel!)
            // --------------------------------------------------------------------  */
            if (li_temp == 2 || ds_msg.Substring(0, 10) == "Incorrect " || ds_msg.Substring(0, 9) == "Too many " || ds_msg.Substring(0, 9) == "No dummy ")
            {
                /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show (   & 'Cancelling transfer ...' ,  'w_maintain_address.idw_details.ue_click_transfer' )
                // --------------------------------------------------------------------  */
                ResumeLayout();
                return;
            }
            /* ******************************************************************
            * ids_results now contains a list of occupants transferring 
            * to the new address.
            * If none of the customers transferring is a primary customer, only
            * recipients are transferring.
            *		if the address being transferred to has a primary customer
            *		then
            *			make all the transferring customers recipients of the 
            *			new address' master
            *		else
            *			pick the first customer being transferred to be the new 
            *			primary contact and link the rest of the customers to it
            *		end if
            *	end if
            ******************************************************************* */
            /* ******************************************************************
            * This chunk of code updates the datastore for the 
            * customer_address_moves table: customer/address relationships.
            * It marks the customer's existing entry 'moved out' and creates
            * a new 'moved in' entry.
            *
            * A following chunk deals with the rds_customer table 
            * - the master/recipient relationships.
            *
            * Note:
            *		We do this first so that when we copy DPIDs  ( if we do), the
            *		original CAM record  ( with the move_out_date set) has the 
            *		DPID it had before the transfer  ( in particular, NULL for an 
            *		unnumbered address).
            ******************************************************************* */
            ll_results_rows = ids_results.RowCount;
            for (ll_row = 0; ll_row < ll_results_rows; ll_row++)
            {
                //  Create a new row for each transferring customer
                //  by copying the current row to the new one.
                ll_new_row = ids_results.RowCount + 1;
                //?ids_results.RowCopy<AddressSelectOccupants>(ll_row, ll_row, ids_results/*?, ll_new_row*/);
                AddressSelectOccupants l_source = ids_results.GetItem<AddressSelectOccupants>(ll_row);
                AddressSelectOccupants l_temp = new AddressSelectOccupants();
                l_temp.AdrId = l_source.AdrId;
                l_temp.CustId = l_source.CustId;
                l_temp.CustInitials = l_source.CustInitials;
                l_temp.CustSurnameCompany = l_source.CustSurnameCompany;
                l_temp.CustTitle = l_source.CustTitle;
                l_temp.DpId = l_source.DpId;
                l_temp.MasterCustId = l_source.MasterCustId;
                l_temp.MoveInd = l_source.MoveInd;
                l_temp.MoveInDate = l_source.MoveInDate;
                l_temp.MoveOutDate = l_source.MoveOutDate;
                l_temp.MoveOutSource = l_source.MoveOutSource;
                l_temp.MoveOutUser = l_source.MoveOutUser;
                ids_results.AddItem<AddressSelectOccupants>(l_temp);
                //  Set the new row's 'move in' date, and the new address
                ids_results.GetItem<AddressSelectOccupants>(ll_new_row - 1).MoveInDate = ldt_now;
                ids_results.GetItem<AddressSelectOccupants>(ll_new_row - 1).AdrId = ll_new_adr_id;
                //  Set the 'move out' date on the original row
                ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate = ldt_now;
                //  TJB  SR4559  15-Mar-2005
                //  Add the reason for the move and who did it
                ids_results.GetItem<AddressSelectOccupants>(ll_new_row - 1).MoveOutSource = "Transfer";
                ids_results.GetItem<AddressSelectOccupants>(ll_new_row - 1).MoveOutUser = is_userid;
                ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutSource = "Transfer";
                ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutUser = is_userid;
            }
            /* ******************************************************************
            *
            * Note: This chunk of code updates the datawindow for the 
            *			rds_customer table: master/recipient relationships. 
            *			If NPAD is enabled, it also copies the DPIDs from dummy 
            *			customers when transferring from numbered to unnumbered 
            *			addresses.
            ******************************************************************* */
            //  See if the master is transferring.
            //  Note: There can only ever be one master customer moving since 
            // 			the set to select from is either a single recipient or 
            // 			a master and its associated recipients  ( not necessarily 
            // 			all occupants at the 'from' address).
            ll_to_master_dpid = null;
            //?ll_this_master_row = ids_results.Find('IsNull(master_cust_id) and IsNull(move_out_date)',1, ids_results.RowCount())
            //?ll_this_master_row = ids_results.Find(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("master_cust_id", null), new KeyValuePair<string, object>("move_out_date", null) });
            //add by ybfan
            ll_this_master_row = -1;
            for (int i = 0; i < ids_results.RowCount; i++)
            {
                if (ids_results.GetItem<AddressSelectOccupants>(i).MasterCustId == null && ids_results.GetItem<AddressSelectOccupants>(i).MoveOutDate == null)
                {
                    ll_this_master_row = i;
                    break;
                }
            }
            if (ll_this_master_row < 0)
            {
                // *************************************************************
                // 
                //  Only recipients are transferring
                // 
                // *************************************************************
                lb_master_moving = false;
                //  For each customer that is transferring  ( all are recipients),
                //  link the customer to the new master.  Any that aren't transferring 
                //  will remain linked to the master who also isn't transferring.
                // 
                //  If there isn't a master at the new address, one of the recipients 
                //  who is transferring will be 'promoted' to be the master.  This should 
                //  only occur when the 'to' address is an unoccupied numbered address, 
                //  or when NPAD isn't enabled and a new address  ( numbered or not) has 
                //  just been created.
                // 
                //  While we're at it, we'll copy dummy DPIDs to the transferring 
                //  customers who don't already have DPIDs.
                //  If the master is a dummy customer, clear the lb_new_master_exists
                //  flag so that one of the recipients moving in will be promoted to 
                //  be the new master.
                if (il_dummy_masters > 0)
                {
                    lb_new_master_exists = false;
                }
                il_dummy_dpid_row = -1;
                if (!lb_new_unnumbered)
                {
                    //  The destination is a numbered address.
                    //  If there's no master at the destination, one of the transferring
                    //  recipients will become the master there.  If there is a master
                    //  there, the transferring customers will become recipients of 
                    //  that master.
                    if (!(ll_new_master_id == null) && ll_new_master_id > 0)
                    {
                        //  The address is occupied
                        //  Transfer the customers as recipients of the new master
                        of_transfer_custs(ll_new_master_id);
                    }
                    else
                    {
                        //  The new address is unoccupied
                        //  Promote one of the transferring recipients to be the master
                        ll_new_master_row = of_promote_recipient();
                        ll_new_master_id = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).CustId;
                        ll_promoted_recipient = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).DpId;
                    }
                }
                else if (!(ll_new_master_id == null) && ll_new_master_id > 0)
                {
                    //  There is a master at the new address.
                    if (ib_npad_enabled)
                    {
                        //  NPAD is enabled.
                        if (!(il_dummy_master_dpid == null) && il_dummy_master_dpid > 0)
                        {
                            //  The new master is a dummy therefore the address is new.
                            //  Promote the 1st recipient to be the master 
                            //  at the new address
                            ll_new_master_row = of_promote_recipient();
                            ll_new_master_id = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).CustId;
                            lb_new_master_exists = true;
                            //  Copy the dummy's DPIDs to the transferring customers
                            //  if the transfer is from a numbered address.
                            if (!lb_old_unnumbered)
                            {
                                of_copy_dpids();
                            }
                            ll_new_master_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).DpId;
                            ll_to_master_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).DpId;
                        }
                        else
                        {
                            //  occupied and we'll make the transferrees recipients.
                            of_transfer_custs(ll_new_master_id);
                            if (!lb_old_unnumbered)
                            {
                                //  If the transfer is from a numbered address
                                //  there must be dummy customers at the new
                                //  address; copy their DPIDs
                                of_copy_dpids();
                            }
                        }
                    }
                    else
                    {
                        //  at the new  ( unnumbered) address).
                        //  We'll make the transferrees recipients.
                        of_transfer_custs(ll_new_master_id);
                    }
                }
                else
                {
                    //  There is no master at the new  ( unnumbered) address.
                    //  Promote the 1st transferring recipient to be the master
                    //  at the new address.
                    ll_new_master_row = of_promote_recipient();
                    ll_new_master_id = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).CustId;
                    lb_new_master_exists = true;
                    if (ib_npad_enabled && !lb_old_unnumbered)
                    {
                        //  NPAD is enabled and the transfer is from a numbered address, 
                        //  copy the DPIDs of the dummy customers.
                        of_copy_dpids();
                    }
                    ll_new_master_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).DpId;
                    ll_to_master_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_new_master_row).DpId;
                }
            }
            else
            {
                // 
                //  A master and possibly some or all of the recipients are 
                //  transferring.
                // 
                // *************************************************************
                //  If the 'To' address is numbered, the master and any recipients 
                //  will retain their current relationship, so there's nothing to do
                //   ( except promote a recipient who isn't transferring, if any).
                // 
                //  This is also what happens if the 'To' address is a new unnumbered
                //  address  ( either has a dummy master or no master).
                // 
                //  If the 'To' address is unnumbered, the master and any recipients 
                //  become recipients of the master there  ( demoting the transferring 
                //  master).
                lb_master_moving = true;
                //  "this_master_id" is the cust ID of the master who is transferring
                ll_this_master_id = ids_results.GetItem<AddressSelectOccupants>(ll_this_master_row).CustId;
                ll_this_master_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_this_master_row).DpId;
                // ---------------------------------------------------------------
                //  First, we need to determine who of those left behind will be  
                //  the new master at the old address  ( the "new_old_master").     
                // ---------------------------------------------------------------
                if (!lb_all_moving)
                {
                    //  If not everyone is transferring, promote one of the
                    //  recipients who isn't.
                    ll_promoted_row = of_promote_old_recipient(ll_this_master_id, ll_this_master_dpid);
                    if (ll_promoted_row >= 0)
                    {
                        ll_promoted_dpid = idw_details.GetItem<AddressOccupants>(ll_promoted_row).DpId;
                    }
                }
                // ---------------------------------------------------------------
                //  Now, transfer the master and recipients.                      
                // ---------------------------------------------------------------
                //  1) If the destination is a numbered address, the master and
                //     all transferring recipients move in as master/recipients.
                //     Nothing needs to be done about the master/recipient 
                //     relationship, and the new address will be set up further
                //     down. Sort out the DPIDs, though.
                //  2) If the destination is unnumbered and has a dummy master 
                //     the transferring master moves in as the master with any 
                //     recipients. Nothing needs to be done about the 
                //     master/recipient relationship. If there is a dummy master, 
                //     there won't be any non-dummy recipients to mess with. 
                //     If the master and recipients don't have DPIDs, copy the 
                //     DPIDs from the dummy customers.
                //  3) If the destination is unnumbered and there is a non-dummy 
                //     master, the transferring master and any recipients will 
                //     become recipients of the new master.  If the master and 
                //     recipients don't have DPIDs, copy the DPIDs from the 
                //     dummy customers.
                if (!lb_new_unnumbered)
                {
                    //  The destination is a numbered address.
                    //  No need to do change the master/recipient relationship
                    //  because the master will be a master at the new address.
                }
                else if (!(ll_new_master_id == null) && ll_new_master_id > 0)
                {
                    //  There is a master at the new address.
                    //   ( it may or may not be a dummy)
                    if (ib_npad_enabled)
                    {
                        //  NPAD is enabled.
                        if (!(il_dummy_master_dpid == null) && il_dummy_master_dpid > 0)
                        {
                            //  The new master is a dummy: the address is new.
                            //  Retain the master/recipient relationships of those
                            //  who are transferring.
                            ll_to_master_dpid = ll_this_master_dpid;
                            //  Copy the dummy's DPIDs to the transferring customers
                            if (!lb_old_unnumbered)
                            {
                                of_copy_dpids();
                            }
                        }
                        else
                        {
                            //  occupied; we'll make the all the transferrees 
                            //  recipients.
                            of_transfer_custs(ll_new_master_id);
                            //  If the transfer is from a numbered address, copy the DPIDs
                            //  of the dummy customers to the transferring customers.
                            if (!lb_old_unnumbered)
                            {
                                of_copy_dpids();
                            }
                        }
                    }
                    else
                    {
                        //   ( and there is a master at the new  ( unnumbered) address).
                        //  We'll make the transferrees recipients.
                        of_transfer_custs(ll_new_master_id);
                    }
                }
            }
            //  End updating master/recipient relationships 
            /* ******************************************************************
            * Next:
            * If the transfer is from an unnumbered address to a numbered one
            * and NPAD is enabled,
            * we delete the DPIDs of the transferring customers since the DPID
            * would be invalid at the new numbered address
            *
            ****************************************************************** */
            if (lb_old_unnumbered && !lb_new_unnumbered && ib_npad_enabled)
            {
                il_deleted_dpids = -1;
                il_deleted_master_dpid = 0;
                //  Scan the list of transferring customers
                for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
                {
                    //  If this entry is the current active one
                    if (ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null)
                    {
                        //  Check that there actually is a DPID to delete
                        ll_this_cust_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                        if (!(ll_this_cust_dpid == null))
                        {
                            //  Check to see if this customer is the master and not a promoted recipient
                            ll_this_master_id = ids_results.GetItem<AddressSelectOccupants>(ll_row).MasterCustId;
                            if (ll_this_master_id == null && ll_promoted_recipient == null)
                            {
                                //  It is the master: save its DPID separately
                                il_deleted_master_dpid = (int)ll_this_cust_dpid;
                            }
                            else
                            {
                                //  It is a recipient: add the dpid to the list
                                il_deleted_dpids++;

                                //!il_deleted_dpid[il_deleted_dpids] = ll_this_cust_dpid;
                                il_deleted_dpid.Add(ll_this_cust_dpid);
                            }
                            //  Now delete the DPID from the lists of customers
                            //  in memory.
                            ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId = ll_null;
                            idw_details.GetItem<AddressOccupants>(ll_this_cust_row).DpId = ll_null;
                        }
                    }
                }
            }
            /*  ---------------------------- Debugging ----------------------------- //
            string	ds_addr_dpid, ds_to_master, ds_new_adr
            string	ds_promo_dpid
            ds_new_adr    = ll_new_adr_id.ToString()
            ds_to_master  = ll_to_master_dpid.ToString()
            ds_promo_dpid = ll_promoted_dpid.ToString()
            if isnull ( ds_new_adr)    then ds_new_adr    = 'NULL'
            if isnull ( ds_to_master)  then ds_to_master  = 'NULL'
            if isnull ( ds_promo_dpid) then ds_promo_dpid = 'NULL'
            MessageBox.Show ( & 'Update "to" address dpid?  \r\n'   & +'ll_promoted_dpid  = '+ds_promo_dpid +'\r\n'    & +'ll_new_adr_id     = '+ds_new_adr    +'\r\n'    & +'ll_to_master_dpid = '+ds_to_master  +'\r\n'    & ,  'w_maintain_address.idw_details.ue_click_transfer' )
            // --------------------------------------------------------------------  */
            //  If a recipient was promoted at the 'from' address, we need to 
            //  update the address' DPID.
            if (ll_promoted_dpid > 0)
            {
                dw_header.GetItem<AddressDetails>(dw_header.GetRow()).DpId = ll_promoted_dpid;
            }
            //  If one of the transferring customers becomes the master at the 
            //  'to' address, we need to update that address' DPID.
            li_rc = 0;
            if (!(ll_to_master_dpid == null) && ll_to_master_dpid > 0)
            {
                li_rc = of_update_to_address_dpid(ll_new_adr_id, ll_to_master_dpid);
            }
            /* ******************************************************************
            *
            * Now we delete all the dummy customers from the RDS database 
            * that have been involved in this transfer. We do it now so that
            * if the rds_customer and customer_address_moves updates fail and 
            * are rolled back, we also roll back the dummy customer deletes.
            * What we do to keep NPAD in sync is done after we know we've 
            * succeeded in the RDS database.
            *
            * In the RDS database, the dummy customers are temporary constructs
            * used either as place-holders or to provide DPIDs for "real" 
            * customers that don't have one, and never persist.  
            * In NPAD they serve the same function, but their management differs.
            * If the dummy's DPID is copied to a 'real' customer, the dummy's 
            * name is changed to the 'real' customer's.  Otherwise the dummy 
            * is deleted.
            ****************************************************************** */
            string ds_row;
            string ds_rows;
            if (!(il_dummy_master_cust == null) && il_dummy_master_cust > 0)
            {
                li_temp = of_deletedummycust(il_dummy_master_cust);
                if (il_dummy_master_cust == null)
                {
                    ds_cust = "null";
                }
                else
                {
                    ds_cust = il_dummy_master_cust.ToString();
                }
                if (li_temp == null)
                {
                    ds_temp = "null";
                }
                else
                {
                    ds_temp = li_temp.ToString();
                }
                /*  ---------------------------- Debugging ----------------------------- //
                MessageBox.Show ( & 'RDS internal operation\r\n\r\n'   & +'Delete dummy master\r\n\r\n'     & +'cust_id = '+ds_cust +'\r\n'    & +' ( rc = '+ds_temp+')'			,  'w_maintain_address.idw_details.ue_click_transfer' )
                // --------------------------------------------------------------------  */
            }
            if (il_dummy_custs > 0)
            {
                if (il_dummy_recipients == null)
                {
                    ds_rows = "null";
                }
                else
                {
                    ds_rows = il_dummy_recipients.ToString();
                }
                for (ll_dummy_row = 0; ll_dummy_row < il_dummy_recipients; ll_dummy_row++)
                {
                    if (ll_dummy_row == null)
                    {
                        ds_row = "null";
                    }
                    else
                    {
                        ds_row = ll_dummy_row.ToString();
                    }
                    li_temp = of_deletedummycust(il_dummy_cust[ll_dummy_row]);
                    if (il_dummy_cust[ll_dummy_row] == null)
                    {
                        ds_cust = "null";
                    }
                    else
                    {
                        ds_cust = il_dummy_cust[ll_dummy_row].ToString();
                    }
                    if (li_temp == null)
                    {
                        ds_temp = "null";
                    }
                    else
                    {
                        ds_temp = li_temp.ToString();
                    }
                    /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show ( & 'RDS internal operation\r\n\r\n'       & +'Delete dummy customer\r\n\r\n'       & +'cust_id = '+ds_cust +'\r\n'        & +'Row '+ds_row+' of '+ds_rows+'\r\n' & +' ( rc = '+ds_temp+')'					,  'w_maintain_address.idw_details.ue_click_transfer' )
                    // --------------------------------------------------------------------  */
                }
            }
            /* ******************************************************************
            *
            * Now we update the rds_customer and customer_address_moves tables
            * with the accumulated changes.
            *
            ****************************************************************** */
            lb_update_ok = false;
            if (li_rc == 0)
            {
                li_rc = 1; ids_results.Save();
                if (li_rc == 1)
                {
                    li_rc = 1; idw_details.Save();
                    if (li_rc == 1)
                    {
                        li_rc = 1; idw_header.Save();
                    }
                }
            }
            if (li_rc == 1)
            {
                //? COMMIT;
                lb_update_ok = true;
            }
            else
            {
                //? ROLLBACK;
                lb_update_ok = false;
            }
            /* ******************************************************************
            *
            * If the update was successful and NPAD is enabled, we need to tell 
            * NPAD what to change to keep the databases synchronised.
            *
            ****************************************************************** */
            if (lb_update_ok && ib_npad_enabled)
            {
                string ds_old_adr_id;
                string ds_old_master;
                string ds_old_dpid;
                string ds_new_adr_id;
                string ds_new_master;
                string ds_new_dpid;
                string ds_promoted;
                string ds_demoted;
                string ls_name1;
                string ls_name2;
                int? ll_dpid1 = 0;
                int? ll_dpid2 = 0;
                //  Debugging ...
                if (ll_old_adr_id == null)
                {
                    ds_old_adr_id = "null";
                }
                else
                {
                    ds_old_adr_id = ll_old_adr_id.ToString();
                }
                if (ll_old_master_id == null)
                {
                    ds_old_master = "null";
                }
                else
                {
                    ds_old_master = ll_old_master_id.ToString();
                }
                if (ll_old_master_dpid == null)
                {
                    ds_old_dpid = "null";
                }
                else
                {
                    ds_old_dpid = ll_old_master_dpid.ToString();
                }
                if (ll_new_adr_id == null)
                {
                    ds_new_adr_id = "null";
                }
                else
                {
                    ds_new_adr_id = ll_new_adr_id.ToString();
                }
                if (ll_new_master_id == null)
                {
                    ds_new_master = "null";
                }
                else
                {
                    ds_new_master = ll_new_master_id.ToString();
                }
                if (ll_new_master_dpid == null)
                {
                    ds_new_dpid = "null";
                }
                else
                {
                    ds_new_dpid = ll_new_master_dpid.ToString();
                }
                if (il_cust_promoted == null)
                {
                    ds_promoted = "null";
                }
                else
                {
                    ds_promoted = il_cust_promoted.ToString();
                }
                if (!lb_old_unnumbered && !lb_new_unnumbered)
                {
                    // ****************************************************
                    // 
                    //  Transfer from numbered to numbered address         
                    // 
                    // ****************************************************
                    //  Nothing to tell NPAD; it doesn't care.
                    /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show ( & 'NPAD interface operation\r\n\r\n'  & +'Transfer from numbered to numbered address.\r\n'         & +'Customers transferred = '+string ( ll_results_rows)+'\r\n' & +'Old address     = '+ds_old_adr_id+'\r\n'  & +'Old master      = '+ds_old_master+'\r\n'  & +'Old master dpid = '+ds_old_dpid+'\r\n'    & +'Old master moving = '+string ( lb_master_moving)+'\r\n'  & +'New address     = '+ds_new_adr_id+'\r\n'  & +'New master      = '+ds_new_master+'\r\n'  & +'New master dpid = '+ds_new_dpid+'\r\n'    & +'Cust promoted   = '+ds_promoted+'\r\n'    & +'***********\r\n'  & +"Nothing to tell NPAD; it doesn't care."		,  'w_maintain_address.idw_details.ue_click_tansfer' )
                    // --------------------------------------------------------------------  */
                }
                else if (!lb_old_unnumbered && lb_new_unnumbered)
                {
                    // ****************************************************
                    // 
                    //  Transfer from numbered to unnumbered address       
                    // 
                    // ****************************************************
                    //  Send 'modify_customer' messages to NPAD to change the 
                    //  'Dummy' names to the transferring customers' names.
                    /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show ( & 'NPAD interface operation\r\n\r\n'  & +'Transfer from numbered to unnumbered address.\r\n'       & +'Customers transferred = '+string ( ll_results_rows)+'\r\n' & +'Old address     = '+ds_old_adr_id+'\r\n'  & +'Old master      = '+ds_old_master+'\r\n'  & +'Old master dpid = '+ds_old_dpid+'\r\n'    & +'Old master moving = '+string ( lb_master_moving)+'\r\n'  & +'New address     = '+ds_new_adr_id+'\r\n'  & +'New master      = '+ds_new_master+'\r\n'  & +'New master dpid = '+ds_new_dpid+'\r\n'    & +'Cust promoted   = '+ds_promoted+'\r\n'    & +'\r\n' & +'il_dummy_masters    = '+string ( il_dummy_masters)+'\r\n'		& +'il_dummy_recipients = '+string ( il_dummy_recipients)+'\r\n'	,  'w_maintain_address.idw_details.ue_click_tansfer' )
                    // --------------------------------------------------------------------  */
                    for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
                    {
                        if (ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null)
                        {
                            ll_cust_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                            ls_cust_name = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustSurnameCompany;
                            ls_cust_initials = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustInitials;
                            ls_cust_title = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustTitle;
                            li_rc = of_npad_modifyone(ll_cust_dpid, ls_cust_name, ls_cust_initials, ls_cust_title);
                        }
                    }
                }
                else if (lb_old_unnumbered && !lb_new_unnumbered)
                {
                    // ****************************************************
                    // 
                    //  Transfer from unnumbered to numbered address       
                    // 
                    // ****************************************************
                    /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show ( & 'NPAD interface operation\r\n\r\n'  & +'Transfer from unnumbered to numbered address.\r\n'       & +'Customers transferred = '+string ( ll_results_rows)+'\r\n' & +'Old address     = '+ds_old_adr_id+'\r\n'  & +'Old master      = '+ds_old_master+'\r\n'  & +'Old master dpid = '+ds_old_dpid+'\r\n'    & +'Old master moving = '+string ( lb_master_moving)+'\r\n'  & +'New address     = '+ds_new_adr_id+'\r\n'  & +'New master      = '+ds_new_master+'\r\n'  & +'New master dpid = '+ds_new_dpid+'\r\n'		& +'Cust promoted   = '+ds_promoted+'\r\n'		,  'w_maintain_address.idw_details.ue_click_tansfer' )
                    // --------------------------------------------------------------------  */
                    //  If only recipients have transferred, send delete_customer 
                    //  messages to NPAD for all those who have transferred.
                    if (!lb_master_moving)
                    {
                        for (ll_row = 0; ll_row <= il_deleted_dpids; ll_row++)
                        {
                            ll_cust_dpid = il_deleted_dpid[ll_row];
                            li_rc = of_npad_deleteone(ll_cust_dpid, "RDS delete recipient");
                        }
                    }
                    else
                    {
                        //  If everyone at the old address transferred, send the 
                        //  delete_customer message with the master's DPID. 
                        //  NPAD will delete the master and all recipients.
                        if (lb_all_moving)
                        {
                            li_rc = of_npad_deleteone(il_deleted_master_dpid, "RDS delete master");
                        }
                        else
                        {
                            //  There's someone back at the ranch.
                            //  Send a transfer_customer message to swap the roles of 
                            //  the original master and the new master  ( at the old 
                            //  address), then send delete_customer messages for all 
                            //  the customers transferring since at this point NPAD 
                            //  will think they're all recipients.
                            of_npad_xferone(il_demoted_dpid, il_promoted_dpid, "RDS swap source masters");
                            //  Now delete the master and all the customers who 
                            //  transferred. The master will be treated as a 
                            //  recipient by NPAD.
                            li_rc = of_npad_deleteone(il_deleted_master_dpid, "RDS delete recipient");
                            for (ll_row = 0; ll_row < il_deleted_dpids; ll_row++)
                            {
                                ll_cust_dpid = il_deleted_dpid[ll_row];
                                li_rc = of_npad_deleteone(ll_cust_dpid, "RDS delete recipient");
                            }
                        }
                    }
                }
                else
                {
                    // 
                    //  Transfer from unnumbered to unnumbered address     
                    // 
                    // ****************************************************

                    //! find for null value replaced by the loop
                    //!ll_row = ids_results.Find(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("master_cust_id", null), 
                    //!new KeyValuePair<string, object>("move_out_date", null) });
                    ll_row = -1;
                    for (int i = 0; i < ids_results.RowCount; i++)
                    {
                        AddressSelectOccupants ids_resultsRecord = ids_results.GetItem<AddressSelectOccupants>(i);
                        if (!ids_resultsRecord.MasterCustId.HasValue && !ids_resultsRecord.MoveOutDate.HasValue)
                        {
                            ll_row = i;
                            break;
                        }
                    }

                    if (ll_row >= 0)
                    {
                        ll_new_master_id = ids_results.GetItem<AddressSelectOccupants>(ll_row).CustId;
                        ll_new_master_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                    }
                    if (ll_new_master_id == null)
                    {
                        ll_new_master_id = 0;
                    }
                    if (ll_new_master_dpid == null)
                    {
                        ll_new_master_dpid = 0;
                    }
                    if (il_dummy_master_cust == null)
                    {
                        il_dummy_master_cust = 0;
                    }
                    if (il_dummy_master_dpid == null)
                    {
                        il_dummy_master_dpid = 0;
                    }
                    /*  ---------------------------- Debugging ----------------------------- //
                        ds_new_master = ll_new_master_id.ToString()
                        ds_new_dpid = ll_new_master_dpid.ToString()
                        MessageBox.Show ( & 'NPAD interface operation\r\n\r\n'  & +'Transfer from unnumbered to unnumbered address.\r\n'     & +'Customers transferred = '+string ( ll_results_rows)+'\r\n' & +'Old address     = '+ds_old_adr_id+'\r\n'  & +'Old master      = '+ds_old_master+'\r\n'  & +'Old master dpid = '+ds_old_dpid+'\r\n'  	& +'Old master moving = '+string ( lb_master_moving)+'\r\n'  & +'New address     = '+ds_new_adr_id+'\r\n'  & +'New master      = '+ds_new_master+'\r\n'  & +'New master dpid = '+ds_new_dpid+'\r\n'  	& +'Cust promoted   = '+ds_promoted+'\r\n'  	& +'\r\n' & +'il_dummy_masters    = '+string ( il_dummy_masters)+'\r\n'		& +'il_dummy_recipients = '+string ( il_dummy_recipients)+'\r\n'	& +'Dummy master        = '+string ( il_dummy_master_cust)+'\r\n' & +'Dummy master DPID   = '+string ( il_dummy_master_dpid)+'\r\n'	,  'w_maintain_address.idw_details.ue_click_tansfer' )
                    // --------------------------------------------------------------------  */
                    int? ll_master_dpid = 0;
                    if (!lb_master_moving)
                    {
                        // --------------------------------------------
                        //  Only recipients have transferred.          
                        // --------------------------------------------
                        ll_master_dpid = il_dummy_master_dpid;
                        if (il_dummy_master_dpid == null || il_dummy_master_dpid < 1)
                        {
                            ll_master_dpid = ll_new_master_dpid;
                        }
                        //  Transfer all recipients to the new master  ( as recipients).
                        for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
                        {
                            ll_cust_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                            if (!(ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null))
                            {
                                li_rc = of_npad_xferone(ll_cust_dpid, ll_master_dpid, "RDS transfer recipient  ( 1)");
                            }
                        }
                        if (il_dummy_masters == 1)
                        {
                            //  The new master was a dummy customer. 
                            //  One of the transferring recipients has been promoted 
                            //  Swap the dummy master and the promoted recipient.
                            li_rc = of_npad_xferone(il_dummy_master_dpid, ll_new_master_dpid, "RDS swap destination masters");
                        }
                    }
                    else
                    {
                        //  The master and some or all of the recipients  ( if 
                        //  any) have transferred.                           
                        // --------------------------------------------------
                        //  If the master and all recipients have transferred and 
                        //  the new master was a "real" customer  ( not a dummy).
                        //  We send a transfer message for the master only.
                        //  Look up the DPID of the transferring master
                        //  Look for the transferring master as a master  ( ie replacing the
                        //  dummy master at the new address) or as a recipient  ( ie 
                        //  becoming a recipient of the existing master at the new address).

                        //pp! find for null values replaced by loop
                        //!ll_row = ids_results.Find(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("master_cust_id", null), 
                        //!    new KeyValuePair<string, object>("move_out_date", null) });
                        ll_row = -1;
                        for (int i = 0; i < ids_results.RowCount; i++)
                        {
                            AddressSelectOccupants ids_resultsRecord = ids_results.GetItem<AddressSelectOccupants>(i);
                            if (!ids_resultsRecord.MasterCustId.HasValue && !ids_resultsRecord.MoveOutDate.HasValue)
                            {
                                ll_row = i;
                                break;
                            }
                        }


                        if (ll_row < 0)
                        {
                            for (int i = 0; i < ids_results.RowCount; i++)
                                // ll_row = ids_results.Find("isnull ( master_cust_id) and not isNull ( move_out_date)").Length) ;
                                if (ids_results.GetValue<object>(i, "master_cust_id") == null && ids_results.GetValue<object>(i, "move_out_date") != null)
                                {
                                    ll_row = i;
                                    break;
                                }
                        }
                        ll_old_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                        if (lb_all_moving)
                        {
                            // ------------------------------------------------
                            //  The master and all recipients have transferred 
                            // ------------------------------------------------
                            if (il_dummy_masters < 1)
                            {
                                //  The new master is a "real" customer  ( not a dummy). 
                                //  We send a transfer message for the master only.
                                li_rc = of_npad_xferone(ll_old_dpid, ll_new_master_dpid, "RDS transfer master  ( 1)");
                            }
                            else
                            {
                                //  The new master was a dummy customer. 
                                //  We send a transfer message for the master only 
                                //  making the master and recipients recipients of
                                //  the dummy master,
                                li_rc = of_npad_xferone(ll_new_master_dpid, il_dummy_master_dpid, "RDS transfer master  ( 2)");
                                //  then we swap the transferring master and dummy
                                li_rc = of_npad_xferone(il_dummy_master_dpid, ll_new_master_dpid, "RDS swap dummy master");
                            }
                        }
                        else
                        {
                            //  The master and  ( possibly) some recipients have 
                            //  transferred.                                   
                            // ------------------------------------------------
                            ll_master_dpid = il_dummy_master_dpid;
                            if (il_dummy_master_dpid == null || il_dummy_master_dpid < 1)
                            {
                                ll_master_dpid = ll_new_master_dpid;
                            }
                            //  First we need to swap the master who is 
                            //  transferring with the recipient at the old 
                            //  address who has been promoted. 
                            li_rc = of_npad_xferone(il_demoted_dpid, il_promoted_dpid, "RDS swap source masters");
                            //  NOTE: at this point, NPAD thinks the master
                            //        who is transferring is a recipient of
                            //        the  ( new-old) master at the 'from' address.
                            //  Now we transfer those who are transferring 
                            //  to the new master. They will all be recipients.
                            for (ll_row = 0; ll_row < ids_results.RowCount; ll_row++)
                            {
                                ll_cust_dpid = ids_results.GetItem<AddressSelectOccupants>(ll_row).DpId;
                                if (!(ids_results.GetItem<AddressSelectOccupants>(ll_row).MoveOutDate == null))
                                {
                                    li_rc = of_npad_xferone(ll_cust_dpid, ll_master_dpid, "RDS transfer recipient  ( 2)");
                                }
                            }
                            if (il_dummy_masters >= 1)
                            {
                                //  The new master was a dummy customer. 
                                //  We swap the master-who-has-transferred
                                //  and the dummy master.
                                li_rc = of_npad_xferone(il_dummy_master_dpid, ll_new_master_dpid, "RDS swap dummy master");
                                //  If the master at the new address isn't a dummy, 
                                //  the master who is transferring will remain a 
                                //  recipient of the master at the new address.
                            }
                        }
                    }
                    //  Now delete all the dummy customers from NPAD because the 
                    //  customers who have transferred already had their own DPIDs
                    //  and haven't 'replaced' the dummys.
                    //  We do all of them at this address whether or not all were
                    //  actually matched with a transferring customer.
                    if (il_dummy_masters > 0)
                    {
                        //  If there is a dummy master customer, delete it
                        li_rc = of_npad_deleteone(il_dummy_master_dpid, "RDS Delete dummy master");
                    }
                    if (il_dummy_recipients > 0)
                    {
                        //  If there are any dummy recipients, delete them 
                        for (ll_row = 0; ll_row <= il_dummy_recipients; ll_row++)
                        {
                            li_rc = of_npad_deleteone(il_dummy_dpid[ll_row], "RDS Delete dummy recipient");
                        }
                    }
                }
                //  TJB  NPAD2.1  May 2007
                //  Now we check to see if the occupied status of either the old or
                //  new addresses has changed, and send a message to NPAD if so  ( but 
                //  only for numbered addresses).  
                //  Note: do this only for Rural Delivery contracts
                lb_RDcontract = of_iscontractrd(ll_old_adr_id);
                if (!lb_old_unnumbered && lb_RDcontract)
                {
                    /*  ---------------------------- Debugging ----------------------------- //
                    boolean db_old_unoccupied
                    db_old_unoccupied = of_isunoccupied ( ll_old_adr_id)
                    MessageBox.Show ( & "Old address DPID = "+string ( ll_old_dp_id)+"\r\n" & +"Occupied status:\r\n" & +"    old = "+string ( not lb_old_unoccupied)+"\r\n" & +"    now = "+string ( not db_old_unoccupied)+"\r\n" ,  'w_maintain_address.dw_details.ue_click_transfer' )
                    // --------------------------------------------------------------------  */
                    if (!(lb_old_unoccupied == of_isunoccupied(ll_old_adr_id)))
                    {
                        //  Send the new occupation status to NPAD.
                        //  NOTE: lb_unoccupied is the old status, which has changed, so what 
                        //        we send is the opposite of what lb_unoccupied indicates!
                        //  TJB 14May07: Changed "Y" to 'true', "N" to 'false'
                        if (lb_old_unoccupied)
                        {
                            of_npad_addr_occupied(ll_old_dp_id, "true", "Changed due to transfer out");
                        }
                        else
                        {
                            of_npad_addr_occupied(ll_old_dp_id, "false", "Changed due to transfer out");
                        }
                    }
                }
                if (!lb_new_unnumbered && lb_RDcontract)
                {
                    //  Note: although we probably "know" the new address' DPID
                    //        as the DPID of its new master customer, it's easier
                    //        to look it up here if we need it.
                    ll_new_dp_id = of_get_addr_dpid(ll_new_adr_id);
                    /*  ---------------------------- Debugging ----------------------------- //
                    boolean db_new_unoccupied
                    db_new_unoccupied = of_isunoccupied ( ll_new_adr_id)
                    MessageBox.Show ( & "New address DPID = "+string ( ll_new_dp_id)+"\r\n" & +"Occupied status:\r\n" & +"    old = "+string ( not lb_new_unoccupied)+"\r\n" & +"    now = "+string ( not db_new_unoccupied)+"\r\n" ,  'w_maintain_address.dw_details.ue_click_transfer' )
                    // --------------------------------------------------------------------  */
                    if (!(lb_new_unoccupied == of_isunoccupied(ll_new_adr_id)))
                    {
                        //  Send the new occupation status to NPAD.
                        if (lb_new_unoccupied)
                        {
                            of_npad_addr_occupied(ll_new_dp_id, "true", "Changed due to transfer in");
                        }
                        else
                        {
                            of_npad_addr_occupied(ll_new_dp_id, "false", "Changed due to transfer in");
                        }
                    }
                }
            }
            //  Check to see if the moved-out-of address is now unoccupied
            //  If so, and if it is an unnumbered address, delete it
            //   ( we can't have unoccupied unnumbered addresses in our database)
            if (lb_old_unnumbered && of_isunoccupied(ll_old_adr_id))
            {
                of_deleteaddress(ll_old_adr_id);
            }
            /* ***************************************************************
            * Open the address maintenance window for the newly-moved-into 
            * address to give the user an opportunity to update customer
            * details of the transferring customers  ( and to double-check 
            * that the 'right' things were done - especially to fix up 
            * the selection of the master customer).
            *************************************************************** */
            //  TJB  bugfix  Aug 2006
            //  Need to pass the RD_Contract flag  ( as a number)
            //  to the next invocation of the w_maintain_address 
            //   ( with the transferees at the new address).  Without it,
            //  the address was being opened with update capability when
            //  in most cases it shouldn't have.
            int? ll_rdcontract = 0;
            if (ib_RDcontract)
            {
                ll_rdcontract = 1;
            }
            else
            {
                ll_rdcontract = 0;
            }
            this.Close();
            inv_road.of_open_address(ll_new_adr_id, ll_new_master_id, ll_rdcontract);
            //  Done
            //this.Close();
        }

        public virtual void dw_details_constructor()
        {
            //? dw_details.of_setsort(true);
            //? dw_details.inv_Sort.of_setcolumnheader(true);
            dw_details.of_SetRowSelect(true);
            //dw_details.of_set_deletepriv(false);
            BeginInvoke(new constraDelegate(dw_details_invoke));
            idw_details = dw_details;
        }

        public virtual void dw_details_invoke()
        {
            dw_details.of_set_deletepriv(false);
        }

        private delegate void CallUePostchanged(int row, string column, string data);// add by mkwang

        public virtual void dw_details_ue_postitemchanged(int row, string column, string data)
        {
            //? base.ue_postitemchanged();
            //  This event is triggered by the dw_detail.itemchanged event when 
            //  the primary_ind is clicked by a user.  It implements the changes 
            //  necessary.
            // 
            //  TJB  NPAD2  Jan 2006
            //  Added business rule that, if a new customer is selected to be the  
            //  primary at an unnumbered address, the "old" primary is demoted to
            //  being a recipient of the new primary  ( only one primary is allowed 
            //  at an unnumbered address - more than one primary is allowed at 
            //  numbered addresses).
            //  NOTE: the address' DPID also must be changed to match that of the
            //        new master customer since in NPAD the customer DPID and 
            //        address DPID are the same thing  ( the customer is actually
            //        part of the address, not a separate entity).
            //  For NPAD, if a new primary is selected, a transfer_customer 
            //  message is generated to swap the primary customers.
            int? ll_new_master_id = 0;
            int ll_rc;
            int ll_row;
            int ll_adr_row;
            int? ll_null = 0;
            int ll_found;
            int? ll_this_adr_id = 0;
            int? ll_this_cust_id = 0;
            int? ll_this_cust_dpid = 0;
            int ll_master_row = -1;
            int? ll_master_cust_id = 0;
            int? ll_master_cust_dpid = 0;
            int? ll_master_id = 0;
            string ls_userid;
            DataUserControl dwChild;
            string ls_null;
            //  TJB  NPAD2  Jan 2006
            int li_rc;
            DateTime? ld_now = null;
            bool lb_update_ok = false;
            bool lb_update_address = false;
            //  NOTE:  'data' parameter
            // 				1   Primary indicator turned on
            // 				0   Primary indicator turned off
            Cursor.Current = Cursors.WaitCursor;
            dw_details.SuspendLayout();
            ll_null = null;
            ls_null = null;
            //? ld_now = StaticVariables.gnv_app.of_gettimestamp();
            //  TJB  SR4559  18-Mar-2005
            ls_userid = StaticVariables.LoginId;
            ll_this_cust_id = dw_details.GetItem<AddressOccupants>(row).CustId;
            ll_this_cust_dpid = dw_details.GetItem<AddressOccupants>(row).DpId;
            ll_master_cust_id = dw_details.GetItem<AddressOccupants>(row).MasterCustId;
            if (data == "1")
            {
                //  This customer has just been made a primary.
                //  Clear the master_cust_id field.
                //  TJB  SR4656  May 2005
                //  ... and inherit the master customer's category 
                //      and Kiwimail count  ( adpost quantity).
                dw_details.GetItem<AddressOccupants>(row).MasterCustId = ll_null;
                dwChild = new DDddwPrimContactsForAnAddress();
                dwChild.BindingSource.DataSource = ((Metex.Windows.DataGridViewEntityComboColumn)(((Metex.Windows.DataEntityGrid)(dw_details.GetControlByName("grid"))).Columns["master_cust_id"])).DataSource;

                //! if ll_master_cust_id is null exception
                //!ll_master_row = dw_details.Find("cust_id", ll_master_cust_id);
                for (int i = 0; i < dw_details.RowCount; i++)
                {
                    AddressOccupants record = dw_details.GetItem<AddressOccupants>(i);
                    if (record.CustId == ll_master_cust_id)
                    {
                        ll_master_row = i;
                        break;
                    }
                }


                if (ll_master_row >= 0)
                {
                    ll_master_cust_dpid = dw_details.GetItem<AddressOccupants>(ll_master_row).DpId;
                    is_cust_business = dw_details.GetItem<AddressOccupants>(ll_master_row).CustBusiness;
                    is_rural_resident = dw_details.GetItem<AddressOccupants>(ll_master_row).CustRuralResident;
                    is_rural_farmer = dw_details.GetItem<AddressOccupants>(ll_master_row).CustRuralFarmer;
                    il_adpost_quantity = dw_details.GetItem<AddressOccupants>(ll_master_row).CustAdpostQuantity;
                    dw_details.GetItem<AddressOccupants>(row).CustBusiness = is_cust_business;
                    dw_details.GetItem<AddressOccupants>(row).CustRuralResident = is_rural_resident;
                    dw_details.GetItem<AddressOccupants>(row).CustRuralFarmer = is_rural_farmer;
                    dw_details.GetItem<AddressOccupants>(row).CustAdpostQuantity = il_adpost_quantity;
                }
                else
                {
                    MessageBox.Show("Unable to find the old primary customer\'s record", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; //? return 1;
                }
                //  TJB  NPAD2  Jan 2006
                //  If this is an unnumbered address, there can only be 
                //  one master.  Make the original master a recipient of 
                //  the new master.
                if (ib_unnumbered)
                {
                    dw_details.GetItem<AddressOccupants>(ll_master_row).MasterCustId = ll_null;
                    dw_details.GetItem<AddressOccupants>(ll_master_row).PrimaryInd = 0;
                    dw_details.GetItem<AddressOccupants>(ll_master_row).CustBusiness = ls_null;
                    dw_details.GetItem<AddressOccupants>(ll_master_row).CustRuralResident = ls_null;
                    dw_details.GetItem<AddressOccupants>(ll_master_row).CustRuralFarmer = ls_null;
                    dw_details.GetItem<AddressOccupants>(ll_master_row).CustAdpostQuantity = ll_null;
                    //  Make all the recipients of the old master, recipients of the 
                    //  new one  ( the currently selected customer).
                    for (ll_row = 0; ll_row < dw_details.RowCount; ll_row++)
                    {
                        if (dw_details.GetItem<AddressOccupants>(ll_row).MasterCustId == ll_master_cust_id)
                        {
                            dw_details.GetItem<AddressOccupants>(ll_row).MasterCustId = ll_this_cust_id;
                            dw_details.GetItem<AddressOccupants>(ll_row).CustLastAmendedUser = ls_userid;
                            dw_details.GetItem<AddressOccupants>(ll_row).CustLastAmendedDate = ld_now;
                        }
                    }
                    //  ... also the old master becomes a recipient of the new master
                    dw_details.GetItem<AddressOccupants>(ll_master_row).MasterCustId = ll_this_cust_id;
                }
                //  If the new master has a dpid, change the DPID of the associated
                //  address  ( since in RDS we keep only one address for all customers 
                //  but that address' DPID must be that of the master customer and
                //  customers only have DPIDs if they are associated with unnumbered
                //  addresses).
                if (!(ll_this_cust_dpid == null) && ll_this_cust_dpid > 0)
                {
                    ll_this_adr_id = dw_details.GetItem<AddressOccupants>(row).AdrId;
                    ll_adr_row = idw_header.Find("adr_id", ll_this_adr_id);
                    if (!(ll_adr_row == null) && ll_adr_row >= 0)
                    {
                        idw_header.GetItem<AddressDetails>(ll_adr_row).DpId = ll_this_cust_dpid;
                        lb_update_address = true;
                    }
                }
                // -------------------------------------------------------------
            }
            else
            {
                //  have been more than one other).
                //  Set its master_cust_id to the first of the available  
                //  other masters.
                //  NOTE: This can only happen for numbered addresses.
                ll_this_cust_id = dw_details.GetItem<AddressOccupants>(row).CustId;
                //dwChild = dw_details.GetChild("master_cust_id");
                dwChild = new DDddwPrimContactsForAnAddress();
                dwChild.BindingSource.DataSource = ((Metex.Windows.DataGridViewEntityComboColumn)(((Metex.Windows.DataEntityGrid)(dw_details.GetControlByName("grid"))).Columns["master_cust_id"])).DataSource;
                //ll_found = dwChild.Find(new KeyValuePair<string,object>("cust_id", ll_this_cust_id));
                ll_found = FindDwChild(dwChild, ll_this_cust_id);
                if (ll_found >= 0)
                {
                    dwChild.RowsDiscard(ll_found, ll_found);
                }
                ll_new_master_id = dwChild.GetValue<int?>(0, "cust_id");
                //  TJB  SR4656  May 2005
                //  ... and set the old master customer's category and Kiwimail 
                //      count  ( adpost quantity) to NULL.
                dw_details.GetItem<AddressOccupants>(row).MasterCustId = ll_new_master_id;
                dw_details.GetItem<AddressOccupants>(row).CustBusiness = ls_null;
                dw_details.GetItem<AddressOccupants>(row).CustRuralResident = ls_null;
                dw_details.GetItem<AddressOccupants>(row).CustRuralFarmer = ls_null;
                dw_details.GetItem<AddressOccupants>(row).CustAdpostQuantity = ll_null;
                //  If this person was a primary contact before, need to remove
                //  the reference to this person for all other people
                for (ll_row = 0; ll_row < dw_details.RowCount; ll_row++)
                {
                    if (dw_details.GetItem<AddressOccupants>(ll_row).MasterCustId == ll_this_cust_id)
                    {
                        dw_details.GetItem<AddressOccupants>(ll_row).MasterCustId = ll_new_master_id;
                        dw_details.GetItem<AddressOccupants>(ll_row).CustLastAmendedUser = ls_userid;
                        dw_details.GetItem<AddressOccupants>(ll_row).CustLastAmendedDate = ld_now;
                    }
                }
            }
            //  TJB  SR4559  18-Mar-2005
            //  Changing the primary customer indicator, update the rds_customer table 
            //  with the user making the change and the date of the change.
            dw_details.GetItem<AddressOccupants>(row).CustLastAmendedUser = ls_userid;
            dw_details.GetItem<AddressOccupants>(row).CustLastAmendedDate = ld_now;
            //  TJB  NPAD2  Jan 2006
            //  Save the changes immediately
            // parent.EVENT pfc_save ( )
            lb_update_ok = false;
            li_rc = 1; dw_details.Save();
            if (li_rc == 1 && lb_update_address)
            {
                li_rc = 1; idw_header.Save();
                //  the address' DPID has been changed.
            }
            if (li_rc == 1)
            {
                //? commit;
                lb_update_ok = true;
            }
            else
            {
                //? Rollback;
            }
            //  If the local database updates were successful, and we've been 
            //  processing new primary indicator for an unnumbered address with 
            //  NPAD enabled,
            //  Generate the "transfer_customer" messages  ( XML file ( s)).
            if (lb_update_ok && ib_npad_enabled && ib_unnumbered && data == "1")
            {
                string ds_old_master_dpid;
                string ds_new_master_dpid;
                ds_old_master_dpid = ll_master_cust_dpid.ToString();
                ds_new_master_dpid = ll_this_cust_dpid.ToString();
                if (ll_master_cust_dpid == null)
                {
                    ds_old_master_dpid = "null";
                }
                if (ll_this_cust_dpid == null)
                {
                    ds_new_master_dpid = "null";
                }
                /*  ---------------------------- Debugging ----------------------------- //
                    MessageBox.Show (   & 'of_npad_xferOne\r\n'  & +'Old DPID = '+ds_old_master_dpid+'\r\n'  & +'New DPID = '+ds_new_master_dpid+'\r\n'  & +'RDS Swap unnumbered masters',  'w_maintain_address.dw_details.ue_postitemchanged' )
                // --------------------------------------------------------------------  */
                ll_rc = of_npad_xferone(ll_master_cust_dpid, ll_this_cust_dpid, "RDS Swap unnumbered masters");
                if (!(ll_rc == 0))
                {
                    MessageBox.Show("Error writing NPAD transfer_customer XML file\r\n" + "Error code    = " + ll_rc + '~' + "Old Master DPID = " + ds_old_master_dpid + '~' + "New Master DPID = " + ds_new_master_dpid + '~' + "XML filename    = " + is_npadoutfile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //  Refresh the display
            this.of_refresh_occupants(row);
            return; //? return 0;
        }

        private int FindDwChild(DataUserControl dw, int? cust_id)
        {
            int i_return = -1;
            if (dw is DDddwPrimContactsForAnAddress)
            {
                for (int i = 0; i < dw.RowCount; i++)
                {
                    if (dw.GetItem<DddwPrimContactsForAnAddress>(i).CustId == cust_id)
                    {
                        i_return = i;
                        break;
                    }
                }
            }
            return i_return;
        }

        public virtual void dw_details_pfc_insertrow()
        {
            //  TJB  NPAD2  Jan 2006
            if (ib_npad_enabled && ib_unnumbered && ib_RDcontract)
            {
                MessageBox.Show("Inserting new customers is not allowed for unnumbered \r\n" + "addresses using this screen.  Please use the NPAD    \r\n" + "address creation function.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; //? return FAILURE;
            }
            //  Override ancestor, trigger the ue_click_new ( ) event
            dw_details_ue_click_new();
            return; //? return SUCCESS;
        }

        private delegate void delegateInvoke();

        public virtual void clickInvoke()
        {
            this.ue_clicked_ok();
        }

        public virtual void dw_movement_constructor()
        {
            idw_movement = dw_movement;
        }
        //pp! XML files are written here as from database they can only been writen on the server side space
        #region WriteXMLFiles
        private int WriteXMLFileAddressOccupied(string as_occupied, string is_npadoutfile, int? al_dpid, string is_userid, string as_description)
        {
            int retVal = 0;
            string errorMessage = "";
            try
            {
                System.Xml.XmlTextWriter textWriter = new System.Xml.XmlTextWriter(is_npadoutfile, null);
                textWriter.WriteStartDocument();
                string rawText = "<NZPost xmlns=\"" + "http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD" + "\">"
                  + "<Header>"
                  + "  <ChannelType>RDSNPAD</ChannelType>"
                  + "  <Version>0.1</Version>"
                  + "  <Description>" + as_description + "</Description>"
                  + "  <Priority>1</Priority>"
                  + "  <ProduceDate>" + DateTime.Now.ToString("dd/MM/yyyy") + "T" + DateTime.Now.ToString("HH:mm:ss") + "</ProduceDate>"
                  + "</Header>"
                  + "<NPAD>"
                  + "  <DeliveryStatusUpdate>"
                  + "    <DPIDs>"
                  + "      <in>" + al_dpid + "</in>"
                  + "    </DPIDs>"
                  + "    <DeliveredTo>" + as_occupied + "</DeliveredTo>"
                  + "    <UserID>" + is_userid + "</UserID>"
                  + "  </DeliveryStatusUpdate>"
                  + "</NPAD>"
                  + "</NZPost>";
                textWriter.WriteRaw(rawText);

                // close writer

                textWriter.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                retVal = -1;
            }

            //          insert into NPAD_msg_log 
            //      (msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description)
            //values
            //      (@now, @username, 'address occupied', @dpid, @status, 'Occupied flag = '+@occupied);

            //return @status;
            RDSDataService.InsertIntoNPADMsgLog(DateTime.Now, is_userid, "address occupied", al_dpid, retVal, "Occupied flag = " + as_occupied);


            return retVal;
        }
        private int WriteXMLFileTransferCustomer(string is_userid, string is_npadoutfile, int? al_old_dpid, string as_description, int? al_new_dpid)
        {
            string errorMessage = "";
            int retVal = 0;
            try
            {
                System.Xml.XmlTextWriter textWriter = new System.Xml.XmlTextWriter(is_npadoutfile, null);
                textWriter.WriteStartDocument();

                if (!al_old_dpid.HasValue || al_old_dpid < 0)
                {
                    retVal = 1;
                    errorMessage = "Invalid old DPID: " + al_old_dpid;
                }
                else if (!al_new_dpid.HasValue || al_new_dpid < 0)
                {
                    retVal = 2;
                    errorMessage = "Invalid new DPID: " + al_new_dpid;
                }

                string al_old_dpid_S = al_old_dpid + "";
                if (!al_old_dpid.HasValue)
                {
                    al_old_dpid_S = "null";
                }
                string al_new_dpid_S = al_new_dpid + "";
                if (!al_new_dpid.HasValue)
                {
                    al_new_dpid_S = "null";
                }


                string rawText = "<NZPost xmlns=\"" + "http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD" + "\">"
                   + "<Header>"//!+@crlf
                   + "  <ChannelType>RDSNPAD</ChannelType>"
                   + "  <Version>0.1</Version>"
                   + "  <Description>" + as_description + "</Description>"
                   + "  <Priority>1</Priority>"
                   + "  <ProduceDate>" + DateTime.Now.ToString("dd/MM/yyyy") + "T" + DateTime.Now.ToString("HH:mm:ss") + "</ProduceDate>"
                   + "</Header>"
                   + "<RDSNPAD>"
                   + "  <MasterRecipientUpdate>"
                   + "    <OldDPID>"
                   + al_old_dpid_S
                   + "    </OldDPID>"
                   + "    <NewDPID>"
                   + al_new_dpid_S
                   + "    </NewDPID>"
                   + "    <UserID>" + is_userid + "</UserID>"
                   + "  </MasterRecipientUpdate>"
                   + "</RDSNPAD>"
                   + "</NZPost>";
                textWriter.WriteRaw(rawText);

                // close writer

                textWriter.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                retVal = -1;
            }
            if (retVal == 0)
            {
                //  -- If successful, "errmsg" contains details of the message
                errorMessage = "New DPID = " + al_new_dpid + "  Outfile = " + is_npadoutfile;
            }
            else
            {
                //  -- If not successful, "errmsg" contains the error code and output filename
                //  set @status=-1;
                errorMessage = "xp_write_file failed: rc = " + retVal + "; File = " + is_npadoutfile;
            }            

                //          insert into NPAD_msg_log(msg_date,
                //  msg_username,msg_type,msg_dpid,msg_status,msg_description) values(
                //  @now,@username,'transfer customer',@s_old_dpid,@status,@errmsg);
                //return @status
            RDSDataService.InsertIntoNPADMsgLog(DateTime.Now, is_userid, "transfer customer", al_old_dpid, retVal, errorMessage);

            

            return retVal;
        }
        private int WriteXMLFileModifyCustomer(int? al_dpid, string is_userid, string is_npadoutfile, string ls_description)
        {
            int retVal = 1;
            string errorMessage = "";
            string surname = "";
            string initials = "";
            string title = "";
            try
            {
                /*
                 * -- Look up the customer details
                        select cust_surname_company,cust_initials,cust_title into @surname,
                          @initials,
                          @title from customer_address_moves as cam,rds_customer as c where
                          cam.dp_id = @dpid and
                          cam.move_out_date is null and
                          c.cust_id = cam.cust_id;
                        if sqlcode <> 0 then
                          set @status=sqlcode;
                          select errormsg(@status) into @errmsg
                        end if
                 */                
                List <AddressOccupantsMovement> record = new List<AddressOccupantsMovement>(AddressOccupantsMovement.GetAllAddressOccupantsData(al_dpid, true));
                if(record != null && record.Count > 0)
                {
                    surname = record[0].RDSCustomerCustSurnameCompany;
                    initials = record[0].RDSCustomerCustInitials;
                    title = record[0].RDSCustTitle;
                }

                System.Xml.XmlTextWriter textWriter = new System.Xml.XmlTextWriter(is_npadoutfile, null);
                textWriter.WriteStartDocument();
                string rawText = "<NZPost xmlns=\"" + "http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD" + "\">"
                  + "<Header>"
                  + "  <ChannelType>RDSNPAD</ChannelType>"
                  + "  <Version>0.1</Version>"
                  + "  <Description>" + ls_description + "</Description>"
                  + "  <Priority>1</Priority>"
                  + "  <ProduceDate>" + DateTime.Now.ToString("dd/MM/yyyy") + "T" + DateTime.Now.ToString("HH:mm:ss") + "</ProduceDate>"
                  + "</Header>"
                  + "<RDSNPAD>"
                  + "  <DeliveryStatusUpdate>"
                  + "    <DPID>"
                  + al_dpid
                  + "    </DPID>"
                  + "    <Surname>" + surname + "</Surname>"
                  + "    <Initials>" + initials + "</Initials>"
                  + "    <Title>" + title + "</Title>"
                  + "    <UserID>" + is_userid + "</UserID>"
                  + "  </DeliveryStatusUpdate>"
                  + "</RDSNPAD>"
                  + "</NZPost>";
                textWriter.WriteRaw(rawText);

                // close writer

                textWriter.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                retVal = -1;
            }

            if (retVal == 0)
            {
                //!-- If successful, "errmsg" contains details of the message
                errorMessage = title + " " + initials + ' ' + surname + " File = " + is_npadoutfile;
            }
            else
            {
                //!-- If not successful, "errmsg" contains the error code and output filename
                retVal = -1;
                errorMessage = "xp_write_file failed: rc = " + retVal + "; File = " + is_npadoutfile;
            }
             //!-- Log the message
              //insert into NPAD_msg_log(msg_date,
              //  msg_username,msg_type,msg_dpid,msg_status,msg_description) values(
              //  @now,@username,'modify customer',@dpid,@status,@errmsg);
              //return @status     
            RDSDataService.InsertIntoNPADMsgLog(DateTime.Now, is_userid, "modify customer", al_dpid, retVal, errorMessage);
             

            return retVal;
        }
        private int WriteXMLFileDeleteCustomer(string is_npadoutfile, int? al_dpid, string is_userid, string as_description)
        {
            int retVal = 0;
            string errorMessage = "";

            if (!al_dpid.HasValue || al_dpid < 0)
            {
                retVal = 1;
                errorMessage = "Invalid DPID: " + al_dpid;
            }

            try
            {
                System.Xml.XmlTextWriter textWriter = new System.Xml.XmlTextWriter(is_npadoutfile, null);
                textWriter.WriteStartDocument();
                string rawText = "<NZPost xmlns=\"" + "http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD" + "\">"
                  + "<Header>"
                  + "  <ChannelType>RDSNPAD</ChannelType>"
                  + "  <Version>0.1</Version>"
                  + "  <Description>" + as_description + "</Description>"
                  + "  <Priority>1</Priority>"
                  + "  <ProduceDate>" + DateTime.Now.ToString("dd/MM/yyyy") + "T" + DateTime.Now.ToString("HH:mm:ss") + "</ProduceDate>"
                  + "</Header>"
                  + "<RDSNPAD>"
                  + "  <CustomerDelete>"
                  + "    <DPID>"
                  + al_dpid
                  + "    </DPID>"
                  + "    <UserID>" + is_userid + "</UserID>"
                  + "  </CustomerDelete>"
                  + "</RDSNPAD>"
                  + "</NZPost>";
                textWriter.WriteRaw(rawText);

                // close writer

                textWriter.Close();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                retVal = -1;
            }
            
             if(retVal == 0)
             {
                //!-- If successful, "errmsg" says so (the details are in other the columns)
                errorMessage = "succeeded";
             }else
             {
                //!-- If not successful, "errmsg" contains the error code and output filename
                retVal = -1;
                errorMessage = "xp_write_file failed: rc = " + retVal + "; File = " + is_npadoutfile;
             }
              //           * insert into NPAD_msg_log(msg_date,
              //  msg_username,msg_type,msg_dpid,msg_status,msg_description) values(
              //  @now,@username,'delete customer',@dpid,@status,@errmsg);
              //return @status
             RDSDataService.InsertIntoNPADMsgLog(DateTime.Now, is_userid, "delete customer", al_dpid, retVal, errorMessage);
             

            return retVal;
        }
        #endregion

        #endregion

        #region Events

        public void Grid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            column = ((DAddressOccupants)(dw_details.DataObject)).Grid.Columns[e.ColumnIndex].Name;
        }

        public virtual void dw_header_clicked(object sender, EventArgs e)
        {
            //  base.clicked();
            dw_header_Click(sender, e);//dw_header.URdsDw_Clicked(sender, e);
            string sObjectAtPointer;
            string sDeliveryDays;
            int? ll_contract_id = 0;
            int ll_rc;
            int row = dw_header.GetRow();
            sObjectAtPointer = "contract_button";//sObjectAtPointer = dw_header.GetColumnName();
            if (sObjectAtPointer.Length >= 15 && sObjectAtPointer.Substring(0, 15) == "contract_button")
            {
                ll_contract_id = dw_header.GetItem<AddressDetails>(row).ContractNo;
                //  TJB  SR4688  uly 2006
                //  Check whether the contract enterd is OK
                if (il_contract_ok < 0)
                {
                    //  If it hasn't been checked, do so and remember the result
                    il_contract_ok = of_validcontract(ll_contract_id);
                }
                if (ll_contract_id == null || ll_contract_id <= 0 || !(il_contract_ok == 0))
                {
                    MessageBox.Show("Please enter a current contract number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    WAddressContractInfo w_address_contract_info = new WAddressContractInfo();
                    StaticMessage.DoubleParm = (double)ll_contract_id;
                    w_address_contract_info.Show();

                }
            }
        }

        public virtual void dw_header_editchanged(object sender, EventArgs e)
        {
            //? base.editchanged();
            // Post 'dw_header_ue_editchanged' Event call
            int row = dw_header.GetRow();
            string dwo = dw_header.GetColumnName();
            string data = dw_header.GetControlByName(dwo).Text;
            dw_header_ue_editchanged(row, dwo, data);
            //? inv_dropdownsearch.pfc_EditChanged(row, dwo, data);
        }

        public virtual void dw_header_itemfocuschanged(object sender, EventArgs e)
        {
            //? inv_dropdownsearch.pfc_ItemFocusChanged(row, dwo);
            // this.Post event ue_validate_dropdown ( row, dwo)
        }

        public virtual void dw_header_itemchanged(object sender, EventArgs e)
        {
            dw_header.URdsDw_Itemchanged(sender, e);
            string ls_unit = string.Empty;
            string ls_no = string.Empty;
            string ls_alpha = string.Empty;
            string ls_adr_num;
            int? ll_null = 0;
            int? ll_old_contract = 0;
            int? ll_new_contract = 0;
            int ll_count;
            int ll_currentrow;
            int ll_rc;
            string ls_msg = "";
            DataUserControl ldwc_child;
            string column = dw_header.GetColumnName();
            int row = dw_header.GetRow();
            if (row == -1 || string.IsNullOrEmpty(column))
                return;
            dw_header.AcceptText();
            object value = dw_header.GetValue<object>(row, column);
            string data = value != null ? value.ToString() : null;
            //  TJB  Sept 2005  NPAD2 Address schema changes
            //  Split address number into components
            // 
            //  TJB  Apr/May 2006  NPAD2 fixups
            //  Change Suburb and Town dropdowns to name only
            //  Lookups for sl_id, RD-no and post_code handled separately
            ll_null = null;
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_col_name, ds_data
                ds_data = data
                ds_col_name = column
                if isnull ( ds_data) then ds_data = 'NULL'
                MessageBox.Show ( & 'Row = '+string ( row)+'\r\n'      & +'Column = '+ds_col_name+'\r\n'  & +'Data   = '+ds_data  ,  'w_maintain_address.dw_header.itemchanged' )
            // --------------------------------------------------------------------  */
            if (column == "adr_num")
            {
                ls_adr_num = data;
                if (inv_road.of_split_string(ls_adr_num, ref ls_no, ref ls_alpha, ref ls_unit))
                {
                    dw_header.GetItem<AddressDetails>(0).AdrUnit = ls_unit;
                    dw_header.GetItem<AddressDetails>(0).AdrAlpha = ls_alpha;
                    dw_header.GetItem<AddressDetails>(0).AdrNo = ls_no;
                }
                else
                {
                    MessageBox.Show("The road number format is incorrect.\r\n" + "Please use the format <unit>/<number><alpha>.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //  TJB  NPAD2  Apr/May 2006  
            //  "Anything goes" at this stage.  When the addtress is
            //  being saved, we'll validate the selected values and 
            //  let the user decide what's OK and what isn't.
            // 
            //  	// If one of the dropdowns has been changed, validate
            //  	// the change.  
            //  IF column = 'rt_id' OR column = 'rs_id' &
            //  OR column = 'tc_id' THEN
            //  	ll_rc = this.EVENT ue_validate_dropdown ( row, dwo, data) 
            //  	IF ll_rc <> 0 THEN
            //  		RETURN ll_rc
            //  	END IF
            //  END IF
            //  If one of the road name components or the town has 
            //  been changed. re-filter the dropdowns.  
            if (column == "road_name" || column == "rt_id" || column == "rs_id" || column == "tc_id" || column == "sl_name")
            {
                // 	This.POST  SetItem ( row, 'road_id', ll_null)
                dw_header_ue_filter_dropdowns(row, column, data);
                dw_header.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            //  IF column = 'adr_rd_no' OR column = 'tc_id' THEN
            //  	// Need to verify that the contract number specified does
            //  	// match the default contract for this
            //  	This.Post Event ue_validate_contract ( FALSE)
            //  END IF
            if (column == "contract_no")
            {
                ll_old_contract = idw_header.GetItem<AddressDetails>(row).GetInitialValue<int?>("ContractNo");
                ll_new_contract = (int?)value;
                if (ib_RDcontract)
                {
                    if (ll_new_contract < 5000 || ll_new_contract >= 6000)
                    {
                        MessageBox.Show("The contract number must be a Rural Delivery contract number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        idw_header.GetItem<AddressDetails>(row).ContractNo = ll_old_contract;
                        idw_header.DataObject.BindingSource.CurrencyManager.Refresh();
                        return; //? return 1;
                    }
                }
                else if (ll_new_contract >= 5000 && ll_new_contract < 6000)
                {
                    MessageBox.Show("The contract number must not be a Rural Delivery contract number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    idw_header.GetItem<AddressDetails>(row).ContractNo = ll_old_contract;
                    idw_header.DataObject.BindingSource.CurrencyManager.Refresh();
                    return; //? return 1;
                }
                //  TJB  SR4688  July 2006
                //  Added contract number validation  ( not terminated or expired)
                //  Then, if the user asks for the contractor details, the 
                //  contractor display doesn't have to deal with a possibly 
                //  invalid contract.
                il_contract_ok = of_validcontract(ll_new_contract);
                if (il_contract_ok == 1)
                {
                    ls_msg = "The contract number you have entered does not exist. \r\n";
                }
                else if (il_contract_ok == 2)
                {
                    ls_msg = "The contract number you have entered has terminated. \r\n";
                }
                else if (il_contract_ok == 3)
                {
                    ls_msg = "The contract number you have entered is not current. \r\n";
                }
                if (!(il_contract_ok == 0))
                {
                    MessageBox.Show(ls_msg + "Please enter a current contract number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //? return 1;
                }
            }
        }

        public virtual void dw_header_losefocus(object sender, EventArgs e)
        {
            dw_header.AcceptText();
        }

        public virtual void dw_details_rowfocuschanged(object sender, EventArgs e)
        {
            // This.SelectRow ( 0, FALSE)
            // This.SelectRow ( This.GetRow ( ), TRUE)
        }

        public virtual void dw_details_clicked(object sender, EventArgs e)
        {
            dw_details.URdsDw_Clicked(sender, e);
            dw_details.URdsDw_GetFocus(null, null);//added by jlwang
            int ll_row = -1;
            // This.SelectRow ( 0, FALSE)
            // This.SelectRow ( row, TRUE)
            // This.SetCurrent ( row)
            //  TJB  SR4686  June 2006
            //  If the selected row isn't the currently active row, change the
            //  active row.
            int row = dw_details.GetRow();
            //?if (row == null)
            //{
            //    row = -1;
            //}
            ll_row = dw_details.GetRow();
            if (row >= 0 && ll_row >= -1 && !(row == ll_row))
            {
                dw_details.SelectRow(0, false);
                dw_details.SelectRow(row + 1, true);
                dw_details.SetCurrent(row);
            }
        }

        string column = "";
        public virtual void dw_details_itemchanged(object sender, EventArgs e)
        {

            int? ll_null = 0;
            int ll_x;
            int? ll_current_cust_id = 0;
            int ll_found;
            string ls_userid;
            DataUserControl dwChild;
            ll_null = null;
            int row = dw_details.GetRow();

            //! assigned at Cell_Validated event of the grid in dw_deails datawindow otherwise dw_details.GetColumnName() 
            //! return "grid"
            string column = ((DAddressOccupants)(dw_details.DataObject)).Grid.CurrentColumnName;


            object value = dw_details.GetValue(row, column);
            string data = value != null ? value.ToString() : null;
            //  TJB  NPAD2  Jan 2006
            /*  ---------------------------- Debugging ----------------------------- //
                string	ds_dwoname, ds_data, ds_temp, ds_npad
                ds_dwoname = column
                ds_data    = data
                if isnull ( data) then ds_data = 'null'
                ds_temp = ib_unnumbered.ToString()
                if isnull ( ib_unnumbered) then ds_temp = 'null'
                ds_npad = ib_npad_enabled.ToString()
                if isnull ( ib_npad_enabled) then ds_npad = 'null'
                MessageBox.Show ( & 'column = '+ds_dwoname+'\r\n'    & +'row      = '+string ( row)+'\r\n'  & +'data     = '+ds_data+'\r\n'      & +'ib_unnumbered = '+ds_temp+'\r\n' & +'ib_npad_enabled = '+ds_npad 	,  'w_maintain_address.dw_details.itemchanged' )
            // --------------------------------------------------------------------  */
            //!if (column == "primary_ind")
            if (((DAddressOccupants)(dw_details.DataObject)).Grid.CurrentColumnName == "primary_ind")
            {

                if (!(is_cust_perms.IndexOf('M') >= 0))
                {
                    MessageBox.Show("You must have at customer modify privilege to change the primary customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return; //? return 2;
                }
                if (data == "0")
                {
                    // 			1 Turn indicator on
                    //  If turning the indicator off and this is the only primary 
                    //  customer left on the list, do not allow them to uncheck it
                    //!ll_found = 0;
                    ll_found = -1;


                    //p! for null value Find throws exception
                    //!ll_found = dw_details.Find("master_cust_id", null);
                    for (int i = 0; i < dw_details.RowCount; i++)
                    {
                        AddressOccupants record = dw_details.GetItem<AddressOccupants>(i);
                        if (!record.MasterCustId.HasValue)
                        {
                            ll_found = i;
                            break;
                        }
                    }

                    if (ll_found >= 0)
                    {
                        int ll_found2 = -1;
                        if (ll_found == dw_details.RowCount)
                        {
                            ll_found = -1;
                        }
                        else
                        {
                            //p! for null value Find throws exception
                            //!ll_found = dw_details.Find("master_cust_id", null);

                            for (int i = ll_found + 1; i < dw_details.RowCount; i++)
                            {
                                AddressOccupants record = dw_details.GetItem<AddressOccupants>(i);
                                if (!record.MasterCustId.HasValue)
                                {
                                    ll_found2 = i;
                                    break;
                                }
                            }
                        }
                        if (ll_found2 >= 0)
                        {
                            //  More than one primary contact available
                        }
                        else
                        {
                            //  This is the only primary contact
                            dw_details.GetItem<AddressOccupants>(row).PrimaryInd = Convert.ToInt32(dw_details.GetItem<AddressOccupants>(row).PrimaryInd) == 1 ? 0 : 1;
                            dw_details.DataObject.BindingSource.CurrencyManager.Refresh();
                            MessageBox.Show("You must have at least one primary contact associated with an address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return; //? return 2;
                        }
                    }
                    else
                    {
                        //  No primary contact available
                        //  This case "cannot happen"
                    }
                }
                //  If turning the indicator on, ue_PostItemChanged deals with it.
                BeginInvoke(new CallUePostchanged(dw_details_ue_postitemchanged), new object[] { row, column, data });// dw_details_ue_postitemchanged(row, column, data);// add by mkwang

            }
            //!else if (column == "master_cust_id")
            else if (((DAddressOccupants)(dw_details.DataObject)).Grid.CurrentColumnName == "master_cust_id")
            {
                //  TJB  SR4559  18-Mar-2005
                //  Changing the primary customer indicator, update the rds_customer table 
                //  with the user making the change and the date of the change.
                ls_userid = StaticVariables.LoginId;
                dw_details.GetItem<AddressOccupants>(row).CustLastAmendedUser = ls_userid;
                dw_details.GetItem<AddressOccupants>(row).CustLastAmendedDate = System.DateTime.Today;
                dw_details.Save();//this.pfc_save();
            }
        }

        public virtual void dw_details_doubleclicked(object sender, EventArgs e)
        {
            dw_details.URdsDw_DoubleClick(sender, e);
            dw_details_ue_click_open();
        }

        public virtual void cb_open_clicked(object sender, EventArgs e)
        {
            dw_details_ue_click_open();
        }

        public virtual void cb_transfer_clicked(object sender, EventArgs e)
        {
            dw_details_ue_click_transfer();
        }

        public virtual void cb_remove_clicked(object sender, EventArgs e)
        {
            dw_details_ue_click_remove();
        }

        public virtual void cb_new_clicked(object sender, EventArgs e)
        {
            dw_details_ue_click_new();
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            // this.ue_clicked_ok();
            BeginInvoke(new delegateInvoke(clickInvoke));
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            this.ib_disableclosequery = true;
            this.Close();
        }

        public virtual void cb_restore_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4697  Dec 2006  New
            //  If the "restore custs" button is pressed, open the 
            //  w_restore_custs window to allow the user to restore a 
            //  customer to the occupants list of this address.
            int ll_count;
            int? ll_updated = 0;
            int ll_rc;
            int? ll_master = 0;
            int ll_row;
            int ll_rows;
            NCriteria lnv_criteria;
            NRdsMsg lnv_msg;
            WRestoreCusts lw_restore_custs;
            //  Check whether this is a numbered or unnumbered address
            //  Disallow restoring occupants for unnumbered addresses
            if (ib_unnumbered)
            {
                MessageBox.Show("You may not restore customers for unnumbered addresses this way." + "\r\n\r\nPlease use NPAD to recreate the customer ( s).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //  TJB  NPAD2.1  May 2007
            //  If the result of the transfer is that the occupied status of either
            //  or both the from and to addresses changes, and if NPAD is enabled, 
            //  message ( s) need to be sent to NPAD with the current status.
            bool lb_unoccupied;
            int? ll_addr_id = 0;
            int? ll_addr_dpid = 0;
            bool lb_RDcontract;
            ll_addr_id = idw_header.GetItem<AddressDetails>(0).AdrId;
            ll_addr_dpid = idw_header.GetItem<AddressDetails>(0).DpId;
            lb_unoccupied = of_isunoccupied(ll_addr_id);
            //  Pass the address ID and master cust's ID to the w_restore_custs window
            lnv_criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            StaticVariables.gnv_app.of_get_parameters().dwparm = idw_details.DataObject;
            lnv_criteria.of_addcriteria("adr_id", il_adr_id);
            //  Loop through the customers and select the first master cust
            //   ( there may be more than one) as the master to be used for 
            //  any restored customers.
            ll_rows = idw_details.RowCount;
            ll_master = 0;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                ll_master = idw_details.GetItem<AddressOccupants>(ll_row).MasterCustId;
                if (ll_master == null)
                {
                    ll_master = idw_details.GetItem<AddressOccupants>(ll_row).CustId;
                    break;
                }
            }
            lnv_criteria.of_addcriteria("master_cust_id", ll_master);
            lnv_msg.of_addcriteria(lnv_criteria);
            StaticMessage.PowerObjectParm = lnv_msg;
            lw_restore_custs = new WRestoreCusts();
            lw_restore_custs.ShowDialog(this.ParentForm);

            //  When we return from the w_restore_*_cust screen, 
            //  check to see if any updates were made.
            ll_updated = (int)lnv_criteria.of_getcriteria("updated");
            //  TJB  NPAD2.1  May 2007: 
            //  After the restore, if any updates were made, and  if NPAD is enabled 
            //  and if this is a Rural Delivery contract
            if (ll_updated == 1 && ib_npad_enabled && of_iscontractrd(ll_addr_id))
            {
                //  If the occupation status has changed
                /*  ---------------------------- Debugging ----------------------------- //
                    boolean db_unoccupied
                    db_unoccupied = of_isunoccupied ( ll_addr_id)
                    MessageBox.Show ( & "Address DPID = "+string ( ll_addr_dpid)+"\r\n" & +"Occupied status:\r\n" & +"    old = "+string ( not lb_unoccupied)+"\r\n" & +"    now = "+string ( not db_unoccupied)+"\r\n" ,  'w_maintain_address.dw_details.ue_click_remove' )
                // --------------------------------------------------------------------  */
                if (!(lb_unoccupied == of_isunoccupied(ll_addr_id)))
                {
                    //  Send the new occupation status to NPAD.
                    //  NOTE: lb_unoccupied is the old status, which has changed, so what 
                    //        we send is the opposite of what lb_unoccupied indicates!
                    //  TJB 14May07: Changed "Y" to 'true', "N" to 'false'
                    if (lb_unoccupied)
                    {
                        of_npad_addr_occupied(ll_addr_dpid, "true", "Changed due to customer restore");
                    }
                    else
                    {
                        of_npad_addr_occupied(ll_addr_dpid, "false", "Changed due to customer restore");
                    }
                }
            }
            /*  ------------------- Debugging ------------------ //
                MessageBox.Show ( & "ll_updated = " + string ( ll_updated,  "w_maintain_address.cb_undelete.clicked" )
            // ------------------------------------------------  */
            //  If so, refresh the occupants list
            if (ll_updated == 1)
            {
                this.of_refresh_occupants();
            }
        }
        #endregion
    }
}
