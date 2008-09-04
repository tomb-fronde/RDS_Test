using System;
using System.Windows.Forms;
using System.Text;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Windows.Ruralwin2;
using System.Collections.Generic;
using System.Drawing;
using Metex.Windows;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WAddressSearch : WAncestorWindow
    {
        #region Define
        private NRoad inv_road;

        public bool ib_action_button_clicked = false;

        public int il_contract_id;

        public int? il_contract_search_type;

        public string is_addr_perms = String.Empty;

        public URdsDw idw_results;

        private System.ComponentModel.IContainer components = null;

        public UTabAddressSearch tab_criteria;

        public UCb cb_search;


        public UCb cb_clear;

        public UCb cb_open;

        public UCb cb_new;

        public URdsDw dw_results;

        public UCb cb_select;

        public UCb cb_cancel;

        public USt st_count;

        public Button cb_print;

        #endregion

        public WAddressSearch()
        {
            this.InitializeComponent();
            idw_results = dw_results;
            foreach (Control ctr in this.Controls)
            {
                if (ctr is ToolStrip)
                {
                    ctr.Visible = false;
                }
            }

            //p! same code is in in InitComp
            this.cb_cancel.Visible = false;
            this.cb_select.Visible = false;

//!?            this.dw_results.DataObject = new DSearchAddressResultsV2b();
            dw_results.RowFocusChanged += new EventHandler(dw_results_rowfocuschanged);
            //jlwang:moved from InitializeComponent
//!?            ((DSearchAddressResultsV2b)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
//!?            ((DSearchAddressResultsV2b)dw_results.DataObject).CellClick += new EventHandler(dw_results_clicked);
//!?            dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
            //jlwang:end

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                this.dw_results.DataObject = new DSearchAddressResultsV2b();

                //jlwang:moved from InitializeComponent
                ((DSearchAddressResultsV2b)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
                ((DSearchAddressResultsV2b)dw_results.DataObject).CellClick += new EventHandler(dw_results_clicked);
                dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
                //jlwang:end
            }
            
            base.OnHandleCreated(e);
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.tab_criteria = new UTabAddressSearch();
            this.cb_search = new UCb();
            this.cb_clear = new UCb();
            this.cb_open = new UCb();
            this.cb_new = new UCb();
            this.dw_results = new URdsDw();
        
            this.cb_select = new UCb();
            this.cb_cancel = new UCb();
            this.st_count = new USt();
            this.cb_print = new Button();
            Controls.Add(tab_criteria);
            Controls.Add(cb_search);
            Controls.Add(cb_clear);
            Controls.Add(cb_open);
            Controls.Add(cb_new);
            Controls.Add(dw_results);
            //!Controls.Add(cb_select);
            //!Controls.Add(cb_cancel);
            Controls.Add(st_count);
            Controls.Add(cb_print);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.Text = "Address Search";
            this.Location = new System.Drawing.Point(1, 1);
            this.Size = new System.Drawing.Size(665, 439);
            //!            this.KeyPress += new KeyPressEventHandler(key);
            // 
            // st_label
            // 
            st_label.Text = "w_address_search";
            st_label.Location = new System.Drawing.Point(8, 376);

            // 
            // tab_criteria
            // 
            tab_criteria.SizeMode = TabSizeMode.FillToRight;
            tab_criteria.BackColor = System.Drawing.Color.FromArgb(192, 192, 192);
            tab_criteria.TabIndex = 1;
            tab_criteria.Size = new System.Drawing.Size(545, 136);
            tab_criteria.Left = 8;
            // 
            // cb_search
            // 
            this.AcceptButton = cb_search;
            cb_search.Text = "&Search";
            cb_search.TabIndex = 2;
            cb_search.Location = new System.Drawing.Point(576, 5);
            cb_search.Click += new EventHandler(cb_search_clicked);
            // 
            // cb_clear
            // 
            cb_clear.Text = "&Clear";
            cb_clear.TabIndex = 3;
            cb_clear.Location = new System.Drawing.Point(576, 32);
            cb_clear.Click += new EventHandler(cb_clear_clicked);
            // 
            // cb_open
            // 
            cb_open.Text = "&Open";
            cb_open.TabIndex = 5;
            cb_open.Location = new System.Drawing.Point(576, 137);
            cb_open.Tag = "ComponentPrivilege=C;ComponentPrivilege=R;ComponentPrivilege=M;ComponentPrivilege=R;";
            cb_open.Click += new EventHandler(cb_open_clicked);
            // 
            // cb_new
            // 
            cb_new.Text = "&New";
            cb_new.Enabled = false;
            cb_new.TabIndex = 6;
            cb_new.Location = new System.Drawing.Point(576, 164);
            cb_new.Tag = "ComponentPrivilege=C;";
            cb_new.Click += new EventHandler(cb_new_clicked);
            // 
            // dw_results
            // 
            //this.dw_results.HorizontalScroll.Visible = true;//dw_results.hscrollbar = true;
            dw_results.TabIndex = 4;
            dw_results.Location = new System.Drawing.Point(8, 136);
            dw_results.Size = new System.Drawing.Size(545, 224);
           

            //((DSearchAddressResultsV2b)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
            //((DSearchAddressResultsV2b)dw_results.DataObject).CellClick += new EventHandler(dw_results_clicked);
            //dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);

            // 
            // cb_select
            // 
            cb_select.Text = "Select";
            cb_select.Enabled = false;
            cb_select.TabIndex = 0;
            cb_select.Location = new System.Drawing.Point(695, 100);
            cb_select.Visible = false;
            cb_select.Click += new EventHandler(cb_select_clicked);
            // 
            // cb_cancel
            // 
            this.CancelButton = cb_cancel;
            cb_cancel.Visible = false;
            cb_cancel.Text = "Cancel";
            cb_cancel.TabIndex = 7;
            cb_cancel.Location = new System.Drawing.Point(692, 140);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);
            // 
            // st_count
            // 
            st_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            st_count.Text = "";
            st_count.Width = 275;
            st_count.Location = new System.Drawing.Point(269, 376);
            st_count.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            // 
            // cb_print
            // 
            cb_print.Text = "Print";
            cb_print.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            cb_print.TabIndex = 7;
            cb_print.Location = new System.Drawing.Point(575, 336);
            cb_print.Size = new System.Drawing.Size(77, 23);
            cb_print.Click += new EventHandler(cb_print_clicked);
            this.Name = "w_address_search";
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

        //added by ygu
        private void titleText()
        {
            string sl = "";
            string st_no = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[dw_results.GetRow()].Cells[2].Value.ToString().ToLower();
            string sr = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[dw_results.GetRow()].Cells[3].Value.ToString();
            if (((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[dw_results.GetRow()].Cells[4].Value != null && ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[dw_results.GetRow()].Cells[4].Value != "")
            {
                sl = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[dw_results.GetRow()].Cells[4].Value.ToString();
            }
            string tc = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[dw_results.GetRow()].Cells[6].FormattedValue.ToString();
            if (sl != "")
            {
                StaticMessage.stringTitle = st_no + " " + sr + "," + sl + "," + tc;
            }
            else
            {
                StaticMessage.stringTitle = st_no + " " + sr + "," + tc;
            }
        }

        public override void close()
        {
            base.close();
            if (!ib_action_button_clicked)
            {
                StaticMessage.PowerObjectParm = null;
            }
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            int ll_contract_id = 0;
            string ls_classname;
            WFrequencies2001 lw_parent = null;
            of_set_componentname("Address");
            is_addr_perms = of_getpermissions("Address");
            if ((is_addr_perms == null) || !(is_addr_perms.IndexOf('R') >= 0))
            {
                MessageBox.Show("You do not have sufficient permission to search for  \n" + "or view addresses", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //?of_setupdateable(false);
                //?of_setresize(true);
                //?this.inv_resize.of_setminsize(this.Width - 50, this.Height - 165);
                //?this.inv_resize.of_register(cb_search, this.inv_resize.FIXEDRIGHT);
                //?this.inv_resize.of_register(cb_clear, this.inv_resize.FIXEDRIGHT);
                //?this.inv_resize.of_register(cb_select, this.inv_resize.FIXEDRIGHT);
                //?this.inv_resize.of_register(cb_open, this.inv_resize.FIXEDRIGHT);
                //?this.inv_resize.of_register(cb_new, this.inv_resize.FIXEDRIGHT);
                //?this.inv_resize.of_register(cb_cancel, this.inv_resize.FIXEDRIGHT);
                //?this.inv_resize.of_register(cb_print, this.inv_resize.FIXEDRIGHT);
                inv_road = (NRoad)(StaticVariables.gnv_app.of_get_road_map());//inv_road = StaticVariables.gnv_app.of_get_road_map();
                if (!((StaticMessage.PowerObjectParm == null)) && (StaticMessage.PowerObjectParm != null))
                {
                    //ls_classname = ClassName(StaticMessage.PowerObjectParm);
                    //if (ls_classname == "w_frequencies2001")
                    //{
                    //    lw_parent = StaticMessage.PowerObjectParm;
                    //}
                    if (StaticMessage.PowerObjectParm is WFrequencies2001)
                    {
                        lw_parent = (WFrequencies2001)StaticMessage.PowerObjectParm;
                    }
                }
                if ((lw_parent != null)) //if (IsValid(lw_parent))
                {
                    ll_contract_id = lw_parent.of_get_contract_id();
                }
                if (ll_contract_id > 0)
                {
                    il_contract_id = ll_contract_id;
                    tab_criteria.il_contract_no = il_contract_id;
                }
                tab_criteria.of_clear_fields();
            }
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            if (StaticVariables.gnv_app.of_get_npadenabled() && tab_criteria.of_getrdflag() == 1)
            {
                cb_new.Enabled = false;
            }
            else
            {
                cb_new.Enabled = true;
            }
            if (!(is_addr_perms.IndexOf('C') >= 0)) //if (!(Match(is_addr_perms, 'C')))
            {
                cb_new.Enabled = false;
            }
            cb_open.Enabled = false;
            il_contract_search_type = tab_criteria.of_getrdflag();
        }

        public override void open()
        {
            base.open();
            if ((is_addr_perms == null) || !(is_addr_perms.IndexOf('R') >= 0)) //if (IsNull(is_addr_perms) || !(Match(is_addr_perms, 'R')))
            {
                this.Close();
            }
        }

        #region Methods
        public virtual string of_getpermissions(string as_name)
        {
            int ll_componentID = 0;
            int? ll_regionID;
            string ls_perms;
            ll_regionID = this.of_get_regionid();
            ll_componentID = StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid(as_name);
            ls_perms = "";
            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "C", false))
            {
                ls_perms += "C";
            }
            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "R", false))
            {
                ls_perms += "R";
            }
            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "M", false))
            {
                ls_perms += "M";
            }
            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "D", false))
            {
                ls_perms += "D";
            }
            if (ls_perms == "")
            {
                ls_perms = null;
            }
            return ls_perms;
        }

        public virtual void of_set_open(bool ab_on)
        {
            if (ab_on)
            {
                cb_open.Enabled = true;
            }
            else
            {
                cb_open.Enabled = false;
            }
        }

        public virtual void ue_row_selected()
        {
        }

        public virtual void dw_results_ue_process_duplication()
        {
            string ls_prime_contact;
            int li_rc;
            int al_row = dw_results.GetRow();
            ls_prime_contact = dw_results.GetItem<SearchAddressResultsV2b>(al_row).PrimaryContract;
            if ((ls_prime_contact == null) || ls_prime_contact.Length <= 0)
            {
                li_rc = (MessageBox.Show("This address is recorded in the system multiple number of times.\n" + "It is recommended that this duplicated entry be removed from \n" + "the system immediately. \n\n" + "Do you wish to delete this duplicated entry now?", "Duplicated Address", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes ? 1 : 2);//li_rc = MessageBox("Duplicated Address", "This address is recorded in the system multiple number of times.\n" + "It is recommended that this duplicated entry be removed from \n" + "the system immediately. \n\n" + "Do you wish to delete this duplicated entry now?", question!, yesno!, 1);
                if (li_rc == 1)
                {
                    dw_results.DataObject.DeleteItemAt(al_row);
                    dw_results.Save(); //li_rc = dw_results.Update();
                    //if (li_rc == 1)
                    //{
                    //    Commit;
                    //}
                    //else
                    //{
                    //    Rollback;
                    //}
                }
            }
            else
            {
                MessageBox.Show("This address is recorded in the system multiple number of times.\n" + "Please transfer out/remove the primary contact residing on this record to\n" + "before this duplicated address can be removed from the system.", "Duplicated Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public virtual void dw_results_constructor()
        {
            //?base.constructor();
            dw_results.of_SetUpdateable(false);
            dw_results.of_SetRowSelect(true);
            dw_results.of_SetResize(true);
            //?dw_results.inv_Resize.of_register("adr_no", 0, 0, 10, 0);
            //?dw_results.inv_Resize.of_register("road_name", 10, 0, 30, 0);
            //?dw_results.inv_Resize.of_register("address_sl_id", 40, 0, 20, 0);
            //?dw_results.inv_Resize.of_register("adr_rd_no", 60, 0, 0, 0);
            //?dw_results.inv_Resize.of_register("address_tc_id", 60, 0, 20, 0);
            //?dw_results.inv_Resize.of_register("primary_contact", 80, 0, 20, 0);
            idw_results = dw_results;
        }

        public virtual void dw_results_ue_deleteitem()
        {
            //?parent.key(key, keyflags);
        }

        public virtual void ue_click_new()
        {
            int ll_row;
            int ll_adr_id;
            int? ll_RDcontract;
            NRdsMsg lnv_msg;
            NCriteria lnv_Criteria;
            WMaintainAddress lw_maintain;
            Cursor.Current = Cursors.WaitCursor;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("adr_id", 0);
            lnv_Criteria.of_addcriteria("cust_id", 0);
            ll_row = tab_criteria.idw_address.GetRow();
            ll_RDcontract = tab_criteria.idw_address.GetItem<SearchAddress>(ll_row).RdContractSelect;
            if (!((ll_RDcontract == null)))
            {
                lnv_Criteria.of_addcriteria("rd_Contract_Select", ll_RDcontract);
            }
            else
            {
                lnv_Criteria.of_addcriteria("rd_Contract_Select", 0);
            }
            lnv_msg.of_addcriteria(lnv_Criteria);
            ib_action_button_clicked = true;
            if (!(this.IsMdiChild) && !(this.IsMdiContainer)) //if (this.WindowType == response!) {
            {
                //OpenWithParm(lw_maintain, lnv_msg, "w_maintain_address_only");
                StaticMessage.PowerObjectParm = lnv_msg;
                lw_maintain = OpenSheet<WMaintainAddress>(StaticVariables.MainMDI);
                ll_adr_id = System.Convert.ToInt32(StaticMessage.DoubleParm);
                if ((ll_adr_id == null) || ll_adr_id <= 0)
                {
                    //  User cancelled out of the screen
                    return;
                }
                else
                {
                    // Create criteria
                    lnv_Criteria = new NCriteria();
                    lnv_msg = new NRdsMsg();
                    lnv_Criteria.of_addcriteria("adr_id", ll_adr_id);
                    lnv_msg.of_addcriteria(lnv_Criteria);
                    ib_action_button_clicked = true;
                    //CloseWithReturn(this, lnv_msg);
                    StaticMessage.PowerObjectParm = lnv_msg;
                    this.Close();
                }
            }
            else
            {
                //OpenSheetWithParm(lw_maintain, lnv_msg, this, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                lw_maintain = OpenSheet<WMaintainAddress>(StaticVariables.MainMDI);
            }
        }

        public virtual void ue_click_search()
        {
            int ll_rowCount;
            il_contract_search_type = tab_criteria.of_getrdflag();
            tab_criteria.of_search_v2(ref idw_results);
            ll_rowCount = idw_results.RowCount;
            if (ll_rowCount > 0)
            {
                if (cb_open.Visible)
                {
                    this.AcceptButton = cb_open;
                }
                else
                {
                    this.AcceptButton = cb_select;
                }
                cb_open.Enabled = true;

                //! added to refresh symbols in first two columns of the grid that are assigned in CellFormatting event handler of grid                
                ((Metex.Windows.DataEntityGrid)(dw_results.GetControlByName("grid"))).Refresh();
                dw_results.DataObject.BindingSource.CurrencyManager.Refresh();

                ((DSearchAddressResultsV2b)idw_results.DataObject).Focus();
                dw_results.Focus();
                //idw_results.ue_row_selected(1);the user event do noting -- by ybfan                
            }
            else
            {
                cb_open.Enabled = false;
                this.AcceptButton = null;
            }
            st_count.Text = ll_rowCount.ToString() + " rows retrieved";
        }

        public virtual void ue_click_clear()
        {
            tab_criteria.of_clear_fields();
            dw_results.of_Reset();
            st_count.Text = "";
            of_set_open(false);
        }

        public virtual void ue_criteria_gainfocus()
        {
            this.AcceptButton = null;
            this.AcceptButton = null; ;
            this.AcceptButton = cb_search;
        }

        public virtual void ue_set_new()
        {
            int ll_rows;
            int? ll_rd_flag;
            int? ll_contract_type;
            if (StaticVariables.gnv_app.of_get_npadenabled() && tab_criteria.of_getrdflag() == 1)
            {
                cb_new.Enabled = false;
            }
            else
            {
                cb_new.Enabled = true;
            }
            if (!(is_addr_perms.IndexOf('C') >= 0)) //if (!(Match(is_addr_perms, 'C')))
            {
                cb_new.Enabled = false;
            }
            ll_rows = idw_results.RowCount;
            if (ll_rows <= 0)
            {
                cb_open.Enabled = false;
            }
            else
            {
                ll_rd_flag = tab_criteria.of_getrdflag();
                ll_contract_type = il_contract_search_type;
                if (ll_rd_flag == ll_contract_type)
                {
                    cb_open.Enabled = true;
                }
                else
                {
                    cb_open.Enabled = false;
                }
            }
        }     
        
        public virtual void ue_click_select()
        {
            int ll_Row;
            int? ll_AddressId;
            int? ll_custId;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            string ls_address;
            ll_Row = dw_results.GetSelectedRow(0);
            if (ll_Row == -1)
            {
                MessageBox.Show("Please search for an address before trying to select one.", "Address Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ll_AddressId = dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).AdrId;
            //  Get address
            ls_address = dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).AdrNo;
            if ((ls_address == null))
            {
                ls_address = "";
            }
            ls_address = ls_address + " " + dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).RoadName;
            ls_address = ls_address.TrimStart();// LeftTrim(ls_address);
            ls_address = ls_address.Trim();
            ll_custId = dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).CustId;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("adr_id", ll_AddressId);
            lnv_Criteria.of_addcriteria("address", ls_address);
            lnv_Criteria.of_addcriteria("cust_id", ll_custId);
            lnv_msg.of_addcriteria(lnv_Criteria);
            ib_action_button_clicked = true;
            //CloseWithReturn(this, lnv_msg);
            StaticMessage.PowerObjectParm = lnv_msg;
            this.Close();
        }

        public virtual void ue_click_open()
        {
            int ll_Row;
            int? ll_AddressID;
            int? ll_custNo;
            int ll_temp;
            int? ll_rdContractSelect;
            ll_Row = dw_results.GetSelectedRow(0);
            if (ll_Row < 0)
            {
                MessageBox.Show("Please search for an address before trying to open one.", "Address Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ll_AddressID = dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).AdrId;
            ll_custNo = dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).CustId;
            ll_rdContractSelect = tab_criteria.of_getrdflag();
            /*select count ( *) into :ll_temp from address where adr_id = :ll_addressID using SQLCA;*/
            ll_temp = RDSDataService.SelectAddressCount(ll_AddressID);
            if (ll_temp < 1)
            {
                MessageBox.Show("The selected address has been removed.  \n" + "Please refresh the search results.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ib_action_button_clicked = true;
            inv_road.of_open_address(ll_AddressID, ll_custNo, ll_rdContractSelect);
            this.titleText();
        }

        #endregion

        #region Events
      
        public virtual void key(object sender, KeyPressEventArgs e)
        {
            //?base.key();
            //?if (keyflags == 2)
            //{
            if (e.KeyChar == 'I') //if (key == keyi!) {
            {
                this.ue_click_new();
            }
            //}
        }

        public virtual void cb_search_clicked(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.ue_click_search();
            this.Cursor = Cursors.Default;
        }

        public virtual void cb_clear_clicked(object sender, EventArgs e)
        {
            this.ue_click_clear();
        }

        public virtual void cb_open_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.ue_click_open();
        }

        public virtual void cb_new_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.ue_click_new();
        }

        public virtual void dw_results_rowfocuschanged(object sender, EventArgs e)
        {
            dw_results.SelectRow(0, false);
            dw_results.SelectRow(dw_results.GetRow() + 1, true); //dw_results.SelectRow(currentrow, true);
        }

        public virtual void dw_results_doubleclicked(object sender, EventArgs e)
        {
            dw_results.URdsDw_DoubleClick(sender, e);
            Cursor.Current = Cursors.WaitCursor;
            if (!(this.IsMdiChild) && !(this.IsMdiContainer))//if (parent.WindowType == response!) {
            {
                this.ue_click_select();
            }
            else
            {
                this.ue_click_open();
            }
        }

        public virtual void dw_results_clicked(object sender, EventArgs e)
        {
            dw_results.URdsDw_Clicked(sender, e);
            string sObjectAtPointer;
            string sDeliveryDays;
            int ll_contract_id;
            int row = dw_results.GetRow();
            sObjectAtPointer = dw_results.DataObject.GetColumnName(); //sObjectAtPointer = dw_results.GetObjectAtPointer();
            if (sObjectAtPointer.Length > 9 && sObjectAtPointer.Substring(0, 9) == "indicator") //if (Left(sObjectAtPointer, 9) == "indicator")
            {
                //?if (dw_results.GetItem<SearchAddressResultsV2b>(row).Indicator != "")
                //{
                //    dw_results_ue_process_duplication();// (row);
                //}
            }
            if (sObjectAtPointer.Length > 14 && sObjectAtPointer.Substring(0, 14) == "multiple_prime") //if (Left(sObjectAtPointer, 14) == "multiple_prime")
            {
                if (dw_results.GetValue<string>(row, "multiple_prime") != "")
                {
                    MessageBox.Show("This is NOT a duplicate record but there is more than\n" + "one primary customer attached to this address.", "Multiple Primary Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public virtual void cb_select_clicked(object sender, EventArgs e)
        {
            this.ue_click_select();
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Printing the DataGridView

        System.Drawing.StringFormat oStringFormat;

        System.Drawing.StringFormat  oStringFormatComboBox;

        Button oButton;
        CheckBox oCheckbox;

        ComboBox oComboBox;
        int nTotalWidth;
        int nRowPos;
        bool NewPage;
        int nPageNo;
        string Header = "Header Test";
        string sUserName = "Will";

        public virtual void cb_print_clicked(object sender, EventArgs e)
        {
            PrintDialog lw = new PrintDialog();//PrintSetup();            
            if (lw.ShowDialog() != DialogResult.OK)
            {
                return;
            }         
  
            //! Render lines to printer here            
            try
            {               
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                pd.BeginPrint += new System.Drawing.Printing.PrintEventHandler(PrintDocument1_BeginPrint);
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler
                   (this.PrintDocument1_PrintPage);
                pd.Print();                
            }           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                    
        }

        private void PrintDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            oStringFormat = new StringFormat();

            oStringFormat.Alignment = StringAlignment.Near;

            oStringFormat.LineAlignment = StringAlignment.Center;

            oStringFormat.Trimming = StringTrimming.EllipsisCharacter;

            oStringFormatComboBox = new StringFormat();

            oStringFormatComboBox.LineAlignment = StringAlignment.Center;

            oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap;

            oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter;

            oButton = new Button();

            oCheckbox = new CheckBox();

            oComboBox = new ComboBox();

            nTotalWidth = 0;

            DataGridView DataGridView1 = dw_results.DataObject.GetControlByName("grid") as DataGridView;

            foreach (DataGridViewColumn oColumn in DataGridView1.Columns)
            {

                nTotalWidth = (nTotalWidth + oColumn.Width);

            }

            nPageNo = 1;

            NewPage = true;

            nRowPos = 0;

        }


        
        private void DrawFooter(System.Drawing.Printing.PrintPageEventArgs e, int RowsPerPage)        
        {
            DataGridView DataGridView1 = dw_results.DataObject.GetControlByName("grid") as DataGridView;

            //string sPageNo = nPageNo.ToString() + " of " + Math.Ceiling((double)(DataGridView1.Rows.Count / RowsPerPage));     

            //! Right Align - User Name

            //!e.Graphics.DrawString(sUserName, DataGridView1.Font, System.Drawing.Brushes.Black, e.MarginBounds.Left + 
            //!    (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridView1.Font, e.MarginBounds.Width).Width), 
            //!    e.MarginBounds.Top + e.MarginBounds.Height + 7);

            //e.Graphics.DrawString(sPageNo, DataGridView1.Font, System.Drawing.Brushes.Black, e.MarginBounds.Left + 
            //    (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridView1.Font, e.MarginBounds.Width).Width) / 2, 
            //    e.MarginBounds.Top + e.MarginBounds.Height + 31);    

        }

        System.Collections.ArrayList oColumnLefts = new System.Collections.ArrayList();
        System.Collections.ArrayList oColumnWidths = new System.Collections.ArrayList();
        System.Collections.ArrayList oColumnTypes = new System.Collections.ArrayList();
        int nHeight = 0;
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {                      
            //!int nHeight = 0;

 

            int nWidth = 0, i = 0, nRowsPerPage = 0;
            int nTop = e.MarginBounds.Top;
            int nLeft = e.MarginBounds.Left;

            DataGridView DataGridView1 = dw_results.DataObject.GetControlByName("grid") as DataGridView;

            if(nPageNo == 1)
            {
                foreach (DataGridViewColumn oColumn in DataGridView1.Columns)
                {
                    nWidth = Convert.ToInt16(Math.Floor((double)(oColumn.Width / (nTotalWidth * (nTotalWidth * (e.MarginBounds.Width / nTotalWidth))))));
                    nHeight = (int)(e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height) + 11;

                    oColumnLefts.Add(nLeft);

                    oColumnWidths.Add(oColumn.Width);

                    oColumnTypes.Add(oColumn.GetType());

                    nLeft += oColumn.Width;
                }
            }

            
             while(nRowPos <= dw_results.DataObject.RowCount - 1)
             {
                DataGridViewRow oRow = DataGridView1.Rows[nRowPos]; 

                if(nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                {
                    DrawFooter(e, nRowsPerPage);                    
                    NewPage = true;
                    nPageNo += 1;
                    e.HasMorePages = true;
                    return;
                }
                else
                {
                    if(NewPage)
                    {                                      
                        //!Draw Columns
                        nTop = e.MarginBounds.Top;
                        
                        i = 0;

                        Font fontToUse = DataGridView1.Columns[3].InheritedStyle.Font;
                        foreach(DataGridViewColumn oColumn in DataGridView1.Columns)
                        {
                            e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.LightGray), 
                                new System.Drawing.Rectangle((int)oColumnLefts[i], nTop, (int)oColumnWidths[i], nHeight));

                            e.Graphics.DrawRectangle(System.Drawing.Pens.Black, new System.Drawing.Rectangle((int)oColumnLefts[i], nTop, (int)oColumnWidths[i], nHeight));

                            e.Graphics.DrawString(oColumn.HeaderText, 
                                fontToUse, new System.Drawing.SolidBrush(oColumn.InheritedStyle.ForeColor), 
                                new System.Drawing.RectangleF(Convert.ToSingle(oColumnLefts[i]), nTop, Convert.ToSingle(oColumnWidths[i]), nHeight), oStringFormat);

                            i += 1;
                        }

                        NewPage = false;
                    }                    

                    nTop += nHeight;

                    i = 0;

                    foreach(DataGridViewCell oCell in oRow.Cells)
                    {                        

                        //!if(oColumnTypes[i] is DataGridViewTextBoxColumn || oColumnTypes[i] is DataGridViewLinkColumn)
                       //! if (oCell.ColumnIndex != 4 && oCell.ColumnIndex != 4)//! 4 and 6 are ComboCells
                        {
                            e.Graphics.DrawString(oCell.EditedFormattedValue + "", oCell.InheritedStyle.Font, 
                                new System.Drawing.SolidBrush(oCell.InheritedStyle.ForeColor), 
                                new System.Drawing.RectangleF(Convert.ToSingle(oColumnLefts[i]), nTop, Convert.ToSingle(oColumnWidths[i]), nHeight), oStringFormat);
 
                        }                   
                       
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(Convert.ToInt32(oColumnLefts[i]), nTop, Convert.ToInt32(oColumnWidths[i]), nHeight));                       

                        i += 1;

                    }

                } 
                nRowPos += 1;
                nRowsPerPage += 1; 
             } 

            DrawFooter(e, nRowsPerPage); 

            e.HasMorePages = false;
        
        }
        #endregion 


        private System.Drawing.Font printFont;        
        List<string> lines = new List<string>();

        public virtual void cb_print1_clicked(object sender, EventArgs e)
        {
            PrintDialog lw = new PrintDialog();//PrintSetup();            
            if(lw.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            //?dw_results.Print(true);
            string rowBorder = string.Empty;
            //!for (int i = 0; i < 98; i++)
            //{
            //    rowBorder += "-";
            //!}

            //! header row and one underline row moved to print function for every page in order
            //!lines.Add("__________________________________________________________________________________________________________");
            //!lines.Add("|Cus_|Adr_|St No__|Street/Road__________|Suburb/Locality_|RD__|Town/City________|Primary Customer_________|");
            
            //!lines.Add(rowBorder);
            this.Cursor = Cursors.WaitCursor;

            DataGridView records = dw_results.DataObject.GetControlByName("grid") as DataGridView;
            foreach (DataGridViewRow row in records.Rows)
            {
                string line = String.Empty;
               
                foreach(DataGridViewCell cell in row.Cells)
                {                   
                    line += "|";
                    //! used to fix spacing
                    switch(cell.ColumnIndex)
                    {
                        //! columns Customer, Adr, St No, RD - length 6 character
                        case 0:
                            if (cell.EditedFormattedValue != null)
                            {
                                if (!string.IsNullOrEmpty(cell.EditedFormattedValue.ToString()))
                                {
                                    line += "PB._";//!cell.EditedFormattedValue.ToString();
                                }
                                else {
                                    line += "" + "____";
                                }                                
                            }
                            else
                            {
                                line += "" + "____";
                            }
                            break;
                        case 1:
                        case 5:
                            if (cell.EditedFormattedValue != null)
                            {
                                if (cell.EditedFormattedValue.ToString().Length > 3)
                                {
                                    line += cell.EditedFormattedValue.ToString().Substring(0, 4);
                                }
                                else
                                {
                                    line += cell.EditedFormattedValue.ToString();
                                    for (int i = 0; i <= 3 - cell.EditedFormattedValue.ToString().Length; i++)
                                    {
                                        line += "_";
                                    }
                                }
                            }
                            else
                            {
                                line += "" + "___";
                            }
                            break;
                        case 2:
                            if (cell.EditedFormattedValue != null)
                            {
                                if (cell.EditedFormattedValue.ToString().Length > 6)
                                {
                                    line += cell.EditedFormattedValue.ToString().Substring(0, 7);
                                }
                                else
                                {
                                    line += cell.EditedFormattedValue.ToString();
                                    for (int i = 0; i <= 6 - cell.EditedFormattedValue.ToString().Length; i++)
                                    {
                                        line += "_";
                                    }
                                }
                            }
                            else
                            {
                                line += "" + "______";
                            }
                            break;
                        //! columns Street, Road, Suburb/Locality, Town/City, Primary Customer - length 20
                        case 3:
                            if (cell.EditedFormattedValue != null)
                            {
                                if (cell.EditedFormattedValue.ToString().Length > 20)
                                {
                                    line += cell.EditedFormattedValue.ToString().Substring(0, 21);
                                }
                                else
                                {
                                    line += cell.EditedFormattedValue.ToString();
                                    for (int i = 0; i <= 20 - cell.EditedFormattedValue.ToString().Length; i++)
                                    {
                                        line += "_";
                                    }
                                }
                            }
                            else
                            {
                                line += "" + "____________________";
                            }
                            break;
                        case 4:
                        case 6:
                            if (cell.EditedFormattedValue != null)
                            {
                                if (cell.EditedFormattedValue.ToString().Length > 16)
                                {
                                    line += cell.EditedFormattedValue.ToString().Substring(0, 17);
                                }
                                else
                                {
                                    line += cell.EditedFormattedValue.ToString();
                                    for (int i = 0; i <= 16 - cell.EditedFormattedValue.ToString().Length; i++)
                                    {
                                        line += "_";
                                    }
                                }
                            }
                            else
                            {
                                line += "" + "________________";
                            }
                            break;
                        case 7:
                            if (cell.EditedFormattedValue != null)
                            {                                
                                if (cell.EditedFormattedValue.ToString().Length > 23)
                                {
                                    line += cell.EditedFormattedValue.ToString().Substring(0, 24);
                                }
                                else
                                {
                                    line += cell.EditedFormattedValue.ToString();
                                    for (int i = 0; i <= 23 - cell.EditedFormattedValue.ToString().Length; i++)
                                    {
                                        line += "_";
                                    }
                                }
                            }
                            else
                            {
                                line += "" + "____________________";
                            }
                            break;
                        default:
                            break;
                    }
                }
                lines.Add(line + "|");               
                //!lines.Add(rowBorder);
            }
            //! Render lines to printer here            
            try
            {
                //!printFont = new System.Drawing.Font("Courier New", 8f, System.Drawing.FontStyle.Underline);
                //!printFont = new System.Drawing.Font("Courier", 8f, System.Drawing.FontStyle.Underline);
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler
                   (this.pd_PrintPage);
                pd.Print();                
            }           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lines.Clear();            
            linesPrinted = 0;
            this.Cursor = Cursors.Default;
        }

        // The PrintPage event is raised for each page to be printed.
        int linesPrinted = 0;       
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = 10;//!ev.MarginBounds.Left - 10;
            float topMargin = ev.MarginBounds.Top - 30;
            printFont = new System.Drawing.Font("Courier New", 8f, System.Drawing.FontStyle.Underline);      

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);
                              
            //! print header per page            
            //!lines.Add("__________________________________________________________________________________________________________");
            string header1 = "___________________________________________________________________________________________________________";
            yPos = topMargin + (-2 *
                 printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(header1, printFont, System.Drawing.Brushes.Black,
            leftMargin, yPos, new System.Drawing.StringFormat());
            ev.Graphics.DrawString(header1, printFont, System.Drawing.Brushes.Black,
            leftMargin, yPos, new System.Drawing.StringFormat());
            ///!lines.Add("|Cus_|Adr_|St No__|Street/Road__________|Suburb/Locality_|RD__|Town/City________|Primary Customer_________|");
            string header2 = "|Cus_|Adr_|St No__|Street/Road__________|Suburb/Locality__|RD__|Town/City________|Primary Customer________|";
            yPos = topMargin + (-1 *
                 printFont.GetHeight(ev.Graphics));
            ev.Graphics.DrawString(header1, printFont, System.Drawing.Brushes.Black,
            leftMargin, yPos, new System.Drawing.StringFormat());
            ev.Graphics.DrawString(header2, printFont, System.Drawing.Brushes.Black,
            leftMargin, yPos, new System.Drawing.StringFormat());
            //! EOF header per page

           
            
            // Print each line of the file.            
            while (count < linesPerPage && linesPrinted < lines.Count)
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));                    
                                
                ev.Graphics.DrawString(lines[linesPrinted], printFont, System.Drawing.Brushes.Black,
                   leftMargin, yPos, new System.Drawing.StringFormat());
                count++;
                linesPrinted++;
            }
            

            // If more lines exist, print another page.
            if (linesPrinted < lines.Count)
                ev.HasMorePages = true;
            else
            {
                ev.HasMorePages = false;                
            }
        }


        #endregion
    }
}