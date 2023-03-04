using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class UTabAddressSearch : UTab
    {
        #region Define
        private NRoad inv_road;
        public int il_contract_no;
        public Metex.Windows.DataUserControl idw_address;
        public Metex.Windows.DataUserControl idw_contact;
        public int? il_road_id;
        public bool ib_town_filtered = false;
        public bool ib_sub_filtered = false;
        public string is_rd_no = "";
        public string is_active_tab = "none";
        public TabPage tabpage_address;
        public URdsDw dw_address;
        public TabPage tabpage_occupant;
        public URdsDw dw_contact;
        public delegate void InvokeDelegate();
        bool itemReallyChanged = true;
        string column_name = null;
        bool roadNameChanged = false;
        string ls_filter;
        // TJB  RD7_0042 Jan-2010: Added
        // This holds the 'clean' list of suburbs (including an 'empty' one) to be reused 
        // when filtering the suburbs list. This avoids re-querying the database.
        // It is populated in dw_address_ue_postconstructed.
        private List<DddwSuburbNames> SuburbSource;
        #endregion

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                this.constructor();
                dw_address.DataObject = new DSearchAddress();
                dw_address.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dw_contact.DataObject = new DAddressSearchPrimContact();
                dw_contact.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.tabpage_address_constructor();

                dw_address.URdsDwEditChanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_address_editchanged);
                dw_address.URdsDwItemFocuschanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_address_itemfocuschanged);

                dw_contact.URdsDwItemFocuschanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_contact_itemfocuschanged);
                //!dw_address.ItemChanged += new EventHandler(dw_address_itemchanged);

                //! added to trigger edit changed for the Road name textbox
                // TJB  RD7_0042 Jan-2010: Disabled
                // dw_address_validating is only interested in road_name editing
                // No need to trigger it when the adr_rd_no changes (??)
                //((TextBox)(dw_address.GetControlByName("adr_rd_no"))).Validating += new CancelEventHandler(dw_address_validating);
                /* this event will unceasing touch off event dw_address_itemchanged :remarked by ygu*/
                // TJB  RD7_0042 Jan-2010: Disabled
                // dw_address_itemchanged is now called from dw_address_itemfocuschanged
                //((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("rt_id"))).SelectedIndexChanged +=
                //    new EventHandler(dw_address_itemchanged);
                //((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("rs_id"))).SelectedIndexChanged +=
                //    new EventHandler(dw_address_itemchanged);
                //((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("tc_id"))).SelectedIndexChanged +=
                //    new EventHandler(dw_address_itemchanged);
                //((ComboBox)(dw_address.GetControlByName("sl_name"))).SelectedIndexChanged +=
                //    new EventHandler(dw_address_itemchanged);
                //((CheckBox)dw_address.GetControlByName("rd_contract_select")).CheckedChanged += new EventHandler(dw_address_itemchanged);
                ((TextBox)(dw_address.GetControlByName("road_name"))).TextChanged += new EventHandler(dw_address_editchanged);
                ((TextBox)(dw_address.GetControlByName("road_name"))).Validating += new CancelEventHandler(dw_address_validating);

                dw_address.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_address_constructor);
                dw_contact.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_contact_constructor);

                //jlwang:end

                //pp! GetFocus for dw_address not working 
                //  !   - attaching the GetFocusEvent to all controls of the data window
                // TJB  RD7_0042 Jan-2010: Disabled
                // Not needed?
                //foreach (Control c in dw_address.DataObject.Controls)
                //{
                //    c.GotFocus += new EventHandler(dw_address_getfocus);
                //}
                // TJB  RD7_0042  Jan-2010: Removed
                // This pfc_EditChanged function doesn't seem to do anything useful
                //Control col = dw_address.GetControlByName("sl_name");
                //col.TextChanged += new EventHandler(this.dw_address_pfc_EditChanged);

                itemReallyChanged = false;  // tjb Jan 2010: added
            }
            base.OnHandleCreated(e);
        }

        public UTabAddressSearch()
        {
            InitializeComponent();
            // Additional initialising code moved to OnHandleCreated in order not to break the designer
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabpage_address = new System.Windows.Forms.TabPage();
            this.dw_address = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_occupant = new System.Windows.Forms.TabPage();
            this.dw_contact = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_address.SuspendLayout();
            this.tabpage_occupant.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabpage_address
            // 
            this.tabpage_address.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_address.Controls.Add(this.dw_address);
            this.tabpage_address.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_address.Location = new System.Drawing.Point(4, 22);
            this.tabpage_address.Name = "tabpage_address";
            this.tabpage_address.Size = new System.Drawing.Size(524, 104);
            this.tabpage_address.TabIndex = 0;
            this.tabpage_address.Text = "By Address";
            // 
            // dw_address
            // 
            this.dw_address.DataObject = null;
            this.dw_address.FireConstructor = false;
            this.dw_address.Location = new System.Drawing.Point(3, 7);
            this.dw_address.Name = "dw_address";
            this.dw_address.Size = new System.Drawing.Size(513, 100);
            this.dw_address.TabIndex = 1;
            // 
            // tabpage_occupant
            // 
            this.tabpage_occupant.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_occupant.Controls.Add(this.dw_contact);
            this.tabpage_occupant.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_occupant.Location = new System.Drawing.Point(4, 22);
            this.tabpage_occupant.Name = "tabpage_occupant";
            this.tabpage_occupant.Size = new System.Drawing.Size(524, 104);
            this.tabpage_address.TabIndex = 0;
            this.tabpage_occupant.Text = "By Primary Contact";
            // 
            // dw_contact
            // 
            this.dw_contact.DataObject = null;
            this.dw_contact.FireConstructor = false;
            this.dw_contact.Location = new System.Drawing.Point(1, 8);
            this.dw_contact.Name = "dw_contact";
            this.dw_contact.Size = new System.Drawing.Size(513, 100);
            this.dw_contact.TabIndex = 1;
            this.dw_contact.GotFocus += new System.EventHandler(this.dw_contact_getfocus);
            this.dw_contact.LostFocus += new System.EventHandler(this.dw_contact_losefocus);
            // 
            // UTabAddressSearch
            // 
            this.Controls.Add(this.tabpage_address);
            this.Controls.Add(this.tabpage_occupant);
            this.SelectedIndex = 0;
            this.Size = new System.Drawing.Size(532, 130);
            this.GotFocus += new System.EventHandler(this.u_tab_address_search_getfocus);
            this.tabpage_address.ResumeLayout(false);
            this.tabpage_occupant.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #region Methods

        public virtual void ue_post_constructor()
        {
            if (!DesignMode)
            {
                //inv_road = StaticVariables.gnv_app.of_get_road_map();
                if (StaticVariables.gnv_app.of_get_road_map() == null)
                {
                    //! NRoad uses only list of BEntities instead of data windows now, otherwise is very slow loading
                    inv_road = ((NRoad)StaticVariables.gnv_app.of_set_road_map(new NRoad("arraysUsed")));
                }
                else
                {
                    inv_road = ((NRoad)StaticVariables.gnv_app.of_get_road_map());
                }
            }
        }

        public virtual void constructor()
        {
            if (!DesignMode)
            {
                this.ue_post_constructor();
            }
        }

        public virtual bool of_search_v2(ref URdsDw adw_result)
        {
            int ll_row;
            //int ll_rc;
            int? ll_rt_id;
            int? ll_rs_id;
            int? ll_tc_id;
            int? ll_contract_no;
            int? ll_dpid;
            int? ll_rdSelect;
            string ls_adr_num;
            //string ls_adr_unit;
            //string ls_adr_no;
            //string ls_adr_alpha;
            string ls_road_name;
            string ls_sl_name;
            string ls_tc_name;
            string ls_rd_no;
            string ls_surname;
            string ls_initials;
            //string ls_empty = "";
            bool lb_criteria_specified;
            Metex.Windows.DataUserControl ldwc_child;
            lb_criteria_specified = false;
            ls_adr_num = idw_address.GetItem<SearchAddress>(0).AdrNum;

            //pp! changed the condition - dropdowns have an empty string added 
            //  ! - not null this is why the condition checks for empty string too
            //  ! do not change it back please
            if (string.IsNullOrEmpty(ls_adr_num))
            {
                ls_adr_num = "";
            }
            else
            {
                ls_adr_num = ls_adr_num.Trim();
                lb_criteria_specified = true;
            }

            //pp! changed the condition - dropdowns have an empty string added 
            //  ! - not null this is why the condition checks for empty string too
            //  ! do not change it back please
            ls_sl_name = idw_address.GetControlByName("sl_name").Text;
            if (string.IsNullOrEmpty(ls_sl_name))
            {
                ls_sl_name = "";
            }
            else
            {
                ls_sl_name = ls_sl_name.Trim();
                lb_criteria_specified = true;
            }

            ls_tc_name = "";
            ll_tc_id = idw_address.GetItem<SearchAddress>(0).TcId;
            if (!ll_tc_id.HasValue || ll_tc_id <= 0)
            {
                ll_tc_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
                ldwc_child = idw_address.GetChild("tc_id");
                ll_row = ldwc_child.Find("tc_id", ll_tc_id);
                if (ll_row > 0)
                {
                    ls_tc_name = ldwc_child.GetItem<DddwTownOnly>(ll_row).TcName;
                }
            }

            ls_road_name = idw_address.GetItem<SearchAddress>(0).RoadName;
            if ((ls_road_name == null))
            {
                ls_road_name = "";
            }
            else
            {
                ls_road_name = ls_road_name.Trim();
                lb_criteria_specified = true;
            }

            ll_rt_id = idw_address.GetItem<SearchAddress>(0).RtId;
            //pp! -100 is value for empty item inserted in dropdown
            if (!ll_rt_id.HasValue || ll_rt_id == -100)
            {
                ll_rt_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }

            ll_rs_id = idw_address.GetItem<SearchAddress>(0).RsId;
            //pp! -100 is value for empty item inserted in dropdown
            if (!ll_rs_id.HasValue || ll_rs_id == -100)
            {
                ll_rs_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }

            ll_contract_no = idw_address.GetItem<SearchAddress>(0).ContractNo;
            if (!ll_contract_no.HasValue || ll_contract_no <= 0)
            {
                ll_contract_no = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }

            ls_rd_no = idw_address.GetItem<SearchAddress>(0).AdrRdNo;
            if ((ls_rd_no == null))
            {
                ls_rd_no = "";
            }
            else
            {
                ls_rd_no = ls_rd_no.Trim();
                lb_criteria_specified = true;
            }

            ll_dpid = idw_address.GetItem<SearchAddress>(0).DpId;
            //! if ((ll_dpid == null))
            if (!ll_dpid.HasValue)
            {
                ll_dpid = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }

            ll_rdSelect = idw_address.GetItem<SearchAddress>(0).RdContractSelect;
            if (!ll_rdSelect.HasValue)
            {
                ll_rdSelect = 1;
            }
            ls_surname = idw_contact.GetItem<AddressSearchPrimContact>(0).CustSurnameCompany;
            if ((ls_surname == null))
            {
                ls_surname = "";
            }
            else
            {
                ls_surname = ls_surname.Trim();
                lb_criteria_specified = true;
            }

            ls_initials = idw_contact.GetItem<AddressSearchPrimContact>(0).CustInitials;
            if ((ls_initials == null))
            {
                ls_initials = "";
            }
            else
            {
                ls_initials = ls_initials.Trim();
                lb_criteria_specified = true;
            }

            ll_rdSelect = idw_address.GetItem<SearchAddress>(0).RdContractSelect;
            if (ll_rdSelect.HasValue && ll_rdSelect == 0)
            {
                lb_criteria_specified = true;
            }
            if (lb_criteria_specified == false)
            {
                MessageBox.Show("Please specify at least one search criteria"
                               , "Search Address"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                idw_address.Focus();
                return false;
            }
            adw_result.Retrieve(new object[] {ls_adr_num, ls_road_name, ll_rt_id, ll_rs_id, ls_sl_name 
                                             , ls_tc_name, ll_contract_no, ls_rd_no, ls_surname, ls_initials
                                             , StaticVariables.gnv_app.of_getuserid()
                                             , StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid("Address")
                                             , ll_rdSelect, ll_dpid });

            if (adw_result.RowCount <= 0)
            {
                MessageBox.Show("There are no addresses that satisfy the search criteria entered."
                                , "Unsuccessful Search"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }

        public virtual int? of_getrdflag()
        {
            return idw_address.GetItem<SearchAddress>(0).RdContractSelect;
        }

        public virtual int of_filter_suburb_dddw(string as_arg_name, string as_arg_value)
        {
            int ll_row;
            //int ll_rc;
            int? ll_rt_id;
            int? ll_rs_id;
            int? ll_tc_id;
            string ls_road_name;
            //!string ls_filter;
            //Metex.Windows.DataUserControl ldwc_child;

            ll_row = idw_address.GetRow();
            ls_road_name = idw_address.GetItem<SearchAddress>(ll_row).RoadName;
            ll_rt_id = (idw_address.GetItem<SearchAddress>(ll_row).RtId == -100) ? null : idw_address.GetItem<SearchAddress>(ll_row).RtId;
            ll_rs_id = (idw_address.GetItem<SearchAddress>(ll_row).RsId == -100) ? null : idw_address.GetItem<SearchAddress>(ll_row).RsId;
            ll_tc_id = idw_address.GetItem<SearchAddress>(ll_row).TcId;
            if (as_arg_name == "road_name")
            {
                ls_road_name = as_arg_value;
            }
            else if (as_arg_name == "rt_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value))
                    ll_rt_id = System.Convert.ToInt32(as_arg_value);
            }
            else if (as_arg_name == "rs_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value))
                    ll_rs_id = System.Convert.ToInt32(as_arg_value);
            }
            else if (as_arg_name == "tc_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value))
                    ll_tc_id = System.Convert.ToInt32(as_arg_value);
            }
            ls_filter = inv_road.of_getsuburblist1(ls_road_name, ll_rt_id, ll_rs_id, ll_tc_id);

            //itemReallyChanged = false;

            //!((NZPostOffice.RDS.DataControls.Ruralwin.DDddwSuburbNames)ldwc_child).FilterOnce<DddwSuburbNames>(NoFilterName);
            //! change the data source of the dropdown and looses selected value
            string currentSuburb = string.Format("{0}", ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Text);
            // TJB  RD7_0042 Jan-2010: Change
            // Populate the suburb list with SuburbSource rather than re-querying the database.
            // SuburbSource already has an 'emptyItem' added.
            //List<NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames> sourceClean = new List<NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames>
            //    (NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames.GetAllDddwSuburbNames());
            //NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames emptyItem = new DddwSuburbNames(); 
            //emptyItem.SlName = "";
            //sourceClean.Insert(0, emptyItem);
            //((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = sourceClean;

            // TJB:  SuburbsCombo appears to be a pointer to sl_name (or vice versa).
            // TJB  RD7_0042  Jan-2010: Changed
            // The SuburbsCombo is now populated in FilterSuburbsNamesIn
            // ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = SuburbSource;
            // ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Text = currentSuburb;
            // ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.SelectedValue = currentSuburb;
            // 
            // if (!string.IsNullOrEmpty(ls_filter))
            // {
                this.FilterSuburbsNamesIn(ls_filter);
                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Text = currentSuburb;
                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.SelectedValue = currentSuburb;
            // }

            //!if (!string.IsNullOrEmpty(ldwc_child.SortString))
            //!{
            //!    ldwc_child.Sort<DddwSuburbNames>();
            //!    (((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<string>).Sort();
            // TJB  RD7_0042 Jan-2010: Changed
            // No need to sort the suburb list - its already sorted (either directly by copying 
            // SuburbSource or by filtering from it.
            //    (((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<DddwSuburbNames>).Sort(new Comparison<DddwSuburbNames>(SuburbsSorter));
            //!}
            //itemReallyChanged = true;
            return 0;
        }

        private int SuburbsSorter(DddwSuburbNames item1, DddwSuburbNames item2)
        {
            return string.Compare(item1.SlName, item2.SlName);
        }

        private void FilterSuburbsNamesIn(string lsFilter)
        {
            bool found;
            // TJB  RD7_0042  Jan-2010: Changed
            // Use SuburbSource as the list of suburbs to filter, rather than
            // re-populating SuburbCombo (externally) and then changing it.
            // Also:  use FilterSuburbsNamesIn to populate SuburbCombo when lsFilter is empty
            //List<DddwSuburbNames> suburbList = ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<DddwSuburbNames>;

            // If the filter is empty, populate the Suburbs dropdown with
            // the unfiltered suburbs list
            if (string.IsNullOrEmpty(lsFilter))
            {
                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = SuburbSource;
                return;
            }

            List<DddwSuburbNames> filteredStringSource = new List<DddwSuburbNames>();
            string[] items = lsFilter.Split(new char[] { ',' });
            foreach (string s in items)
            {
                if (string.IsNullOrEmpty(s))
                    continue;

                //foreach (DddwSuburbNames item in suburbList)
                foreach (DddwSuburbNames item in SuburbSource)
                {
                    // Skip the empty suburb name
                    if (string.IsNullOrEmpty(item.SlName))
                        continue;

                    if (item.SlName.Trim() == s.Trim() 
                        && this.NotRepeatedItem(ref filteredStringSource, item.SlName))
                    {
                        filteredStringSource.Add(item);
                    }
                }
            }
            //! add an empty string at end of the list
            DddwSuburbNames emptyRow = new DddwSuburbNames();
            emptyRow.SlName = "";
            filteredStringSource.Insert(0, emptyRow);

            filteredStringSource.Sort(new Comparison<DddwSuburbNames>(SuburbsSorter));
            ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = filteredStringSource;
            return;
        }

        // TJB  RD7_0042  Jan-2010: Change
        // Made filteredStringSource a reference so that it needn't be copied each time
        // this routine is called.
        private bool NotRepeatedItem(ref List<DddwSuburbNames> filteredStringSource, string item)
        {
            foreach (DddwSuburbNames i in filteredStringSource)
            {
                if (i.SlName == item)
                    return false;
            }
            return true;
        }

        bool NoFilterName(DddwSuburbNames item)
        {
            return true;
        }

        bool FilterName(DddwSuburbNames item)
        {
            if (!string.IsNullOrEmpty(item.SlName) && ls_filter.IndexOf(item.SlName) >= 0)
            {
                return true;
            }
            return false;
        }

        bool FilterTcId(DddwTownOnly item)
        {
            if (item.TcId.HasValue && ls_filter.IndexOf(string.Format("{0}", item.TcId.Value)) >= 0 ||
                item.TcId == -100)//pp! allow empty value -100
            {
                return true;
            }
            return false;
        }

        bool FilterEmpty(DddwTownOnly item)
        {
            return true;
        }

        public virtual int of_filter_town_dddw(string as_arg_name, string as_arg_value)
        {
            int ll_row;
            //int ll_rc;
            int? ll_rt_id;
            int? ll_rs_id;
            int ll_datarows;
            //int ll_filteredrows;
            string ls_road_name;
            string ls_sl_name;

            //!string ls_filter;
            ls_filter = string.Empty;
            Metex.Windows.DataUserControl ldwc_child;
            ll_row = idw_address.GetRow();
            ls_road_name = idw_address.GetItem<SearchAddress>(ll_row).RoadName;

            //idw_address.GetItemNumber(ll_row, "rt_id");
            ll_rt_id = (idw_address.GetItem<SearchAddress>(ll_row).RtId == -100) ? null : idw_address.GetItem<SearchAddress>(ll_row).RtId;
            //idw_address.GetItemNumber(ll_row, "rs_id");
            ll_rs_id = (idw_address.GetItem<SearchAddress>(ll_row).RsId == -100) ? null : idw_address.GetItem<SearchAddress>(ll_row).RsId;

            ls_sl_name = idw_address.GetItem<SearchAddress>(ll_row).SlName;
            if (as_arg_name == "road_name")
            {
                ls_road_name = as_arg_value;
            }
            else if (as_arg_name == "rt_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value) && System.Convert.ToInt32(as_arg_value) != -100)
                    ll_rt_id = System.Convert.ToInt32(as_arg_value);
            }
            else if (as_arg_name == "rs_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value) && System.Convert.ToInt32(as_arg_value) != -100)
                    ll_rs_id = System.Convert.ToInt32(as_arg_value);
            }
            else if (as_arg_name == "sl_name")
            {
                ls_sl_name = as_arg_value;
            }
            ls_filter = inv_road.of_gettownlist1(ls_road_name, ll_rt_id, ll_rs_id, ls_sl_name);

            ldwc_child = idw_address.GetChild("tc_id");
            ldwc_child.FilterString = "";

            //itemReallyChanged = false;
            ldwc_child.FilterOnce<DddwTownOnly>(FilterEmpty);
            //itemReallyChanged = true;

            ll_datarows = ldwc_child.RowCount;
            if (!(ls_filter == ""))
            {
                ldwc_child.FilterString = "tc_id in (" + ls_filter + ")";
                //itemReallyChanged = false;
                ldwc_child.FilterOnce<DddwTownOnly>(FilterTcId);
                //itemReallyChanged = true;
            }
            //! ldwc_child.Sort<DddwTownOnly>();
            ll_datarows = ldwc_child.RowCount;
            //?ll_filteredrows = ldwc_child.FilteredCount();
            return 0;
        }

        public virtual void of_clear_fields()
        {
            tabpage_address_ue_clear();
            tabpage_occupant_ue_clear();
            ib_town_filtered = false;
            ib_sub_filtered = false;
            if (is_active_tab == "contact")
            {
                idw_contact.GetControlByName("cust_surname_company").Focus();
                idw_contact.Focus();
            }
            else if (is_active_tab == "address")
            {
                idw_address.GetControlByName("adr_num").Focus();
                idw_address.Focus();
            }
        }

        public virtual void of_populate(ref NCriteria anv_criteria)
        {
            if (this.SelectedIndex == 0)
            {
                tabpage_address_ue_populate(ref anv_criteria);
            }
        }

        public virtual void of_setrdflag(int? al_rdflag, int? al_hideflag)
        {
            idw_address.GetItem<SearchAddress>(0).RdContractSelect = al_rdflag;
            if (al_hideflag == 1)
            {
                idw_address.GetControlByName("rd_contract_select").Visible = false;
            }
            else
            {
                idw_address.GetControlByName("rd_contract_select").Visible = true;
            }
        }

        public virtual void tabpage_address_ue_clear()
        {
            dw_address_ue_clear_fields();
        }

        public virtual void tabpage_address_ue_populate(ref NCriteria anv_criteria)
        {
            string ls_temp;
            int? ll_temp;
            ls_temp = dw_address.GetItem<SearchAddress>(0).AdrNo;
            anv_criteria.of_addcriteria("adr_no", ls_temp);
            ls_temp = dw_address.GetItem<SearchAddress>(0).RoadName;
            anv_criteria.of_addcriteria("road_name", ls_temp);
            ll_temp = dw_address.GetItem<SearchAddress>(0).RtId;
            anv_criteria.of_addcriteria("rt_id", ll_temp);
            ll_temp = dw_address.GetItem<SearchAddress>(0).RsId;
            anv_criteria.of_addcriteria("rs_id", ll_temp);
            ls_temp = dw_address.GetItem<SearchAddress>(0).SlName;
            anv_criteria.of_addcriteria("sl_name", ls_temp);
            ll_temp = dw_address.GetItem<SearchAddress>(0).TcId;
            anv_criteria.of_addcriteria("tc_id", ll_temp);
            ls_temp = dw_address.GetItem<SearchAddress>(0).AdrRdNo;
            anv_criteria.of_addcriteria("adr_rd_no", ls_temp);
        }

        public virtual void tabpage_address_constructor()
        {
            dw_address.Focus();
            dw_address.DataObject.GetControlByName("road_name").Focus();
        }

        public virtual void dw_address_ue_postconstructed()
        {
            Metex.Windows.DataUserControl ldwc_child;

            //pp! added to send processing on background as it takes too long 
            //  ! especially when open form for the first time
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += (DoWorkEventHandler)(delegate(object sender1, DoWorkEventArgs e1)
            {
                Metex.Windows.DataUserControl ldwc_child1;

                //inv_road = StaticVariables.gnv_app.of_get_road_map();            
                if (StaticVariables.gnv_app.of_get_road_map() == null)
                {
                    inv_road = ((NRoad)StaticVariables.gnv_app.of_set_road_map(new NRoad("arraysUsed")));
                }
                else
                {
                    inv_road = ((NRoad)StaticVariables.gnv_app.of_get_road_map());
                }
                ldwc_child1 = dw_address.DataObject.GetChild("rt_id");
            });
            bgWorker.RunWorkerAsync();

            // TJB  RD7_0042 Jan-2001: Removed line below: redundant
            //ldwc_child = dw_address.DataObject.GetChild("sl_name");
            //?ldwc_child.FilterString = "";
            //?ldwc_child.Filter<DddwSuburbNames>();
            //ldwc_child.Filter();
            //@ldwc_child.SortString = "sl_name A";
            //@ldwc_child.Sort<DddwSuburbNames>();//ldwc_child.Sort();

            ldwc_child = dw_address.DataObject.GetChild("tc_id");
            ldwc_child.SortString = "tc_name A";
            //?ldwc_child.Sort<DddwTownOnly>();
            // ldwc_child.Sort();

            ((DSearchAddress)dw_address.DataObject).Retrieve();
            dw_address.InsertItem<SearchAddress>(0);

            //pp! added empty record in drop down to make possible null values to be selected on dropdowns                                           
            DddwTownOnly empty = new DddwTownOnly();
            empty.TcId = -100;
            empty.TcName = "";
            ldwc_child = dw_address.DataObject.GetChild("tc_id");
            ldwc_child.InsertItem<DddwTownOnly>(0, empty);

            // TJB  RD7_0042 Jan-2010: Added
            // Save initial suburb list
            SuburbSource = ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<DddwSuburbNames>;

            //.SetItem(dw_address.GetRow(), "rd_contract_select", 1);
            dw_address.GetItem<SearchAddress>(dw_address.GetRow()).RdContractSelect = 1;
        }
        
        // TJB RD7_0042 Jan-2010: Added
        //     The editchanged event seems to be triggered twice for each keystroke 
        //     - once for the keystroke, and once when the suggested roadname is
        //       put in the field.  This flag is used to ignore the second event.
        private bool editchanged_repeat_flag = false;

        public virtual void dw_address_ue_editchanged(string as_ColumnName)
        {
            if (editchanged_repeat_flag) return;

            if (as_ColumnName == "road_name")
            {
                int partial_size = 0;
                string sPartial = "";
                string sNextMatch = "";
                string ls_display = "";
                string ls_ColumnText;

                if ( ((DSearchAddress)dw_address.DataObject).Keypress 
                      || ((DSearchAddress)dw_address.DataObject).Keyback ) 
                {
                    ls_ColumnText = dw_address.GetControlByName(as_ColumnName).Text;
                    if (!string.IsNullOrEmpty(ls_ColumnText))
                    {
                        // TJB:  Trimming the roadname breaks the ability to handle embedded spaces
                        //       (for example, in "Waikawa Beach"
                        ls_display = ls_ColumnText;

                        partial_size = ((TextBox)(dw_address.GetControlByName(as_ColumnName))).SelectionStart;
                        // TJB  RD7_0042  Jan-2010: Changed 
                        //      If the user pressed keyback, reduce the length of the entered 
                        //      roadname by 1 character.  If there's only one character in the
                        //      roadname, replace with the empty string.
                        //if (((DSearchAddress)dw_address.DataObject).Keyback)
                        //{
                        //    if ((partial_size - 2) > 2)
                        //        sPartial = ls_display.Substring(0,(partial_size - 2));
                        //    else
                        //        sPartial = ls_display;
                        //}
                        //else
                        //{
                        //    if ((partial_size - 1) > 0)
                        //        sPartial = ls_display.Substring(0, partial_size /*- 1*/); 
                        //    else
                        //        sPartial = ls_display;
                        //}
                        sPartial = ls_display;
                        if (((DSearchAddress)dw_address.DataObject).Keyback)
                        {
                            if (partial_size > 1)
                            {
                                partial_size = partial_size - 1;
                                sPartial = ls_display.Substring(0, partial_size);
                            }
                            else
                                sPartial = "";
                        }
                        // If the partial roadname isn't empty, try to match it
                        if (sPartial.Length > 0)
                        {
                            sNextMatch = inv_road.of_getnextmatch1(sPartial);
                            if (sNextMatch.Length > 0)
                            {
                                editchanged_repeat_flag = true;
                                dw_address.GetControlByName(as_ColumnName).Text = sNextMatch;
                                ((TextBox)(dw_address.GetControlByName(as_ColumnName))).Select(sPartial.Length, sNextMatch.Length);
                                editchanged_repeat_flag = false;
                            }
                        }
                        // TJB RD7_0042 Jan-2010: Added
                        //     If the partial roadname is empty, return that (no suggested roadname)
                        else
                        {
                            editchanged_repeat_flag = true;
                            dw_address.GetControlByName(as_ColumnName).Text = "";
                            editchanged_repeat_flag = false;
                        }
                    }
                }
            }
        }

        private bool FilterRtId(DddwRoadType item)
        {
            //pp! empty record with value -100 is allowed too
            if (item.RtId < 0)
            {
                return true;
            }
            return false;
        }

        private bool FilterRsId(DddwRoadSuffix item)
        {
            //pp! empty record with value -100 is allowed too
            if (item.RsId < 0)
            {
                return true;
            }
            return false;
        }

        public virtual void dw_address_ue_filter_dropdown(string column_name)
        {
            int ll_row = -1;
            //int ll_road_id;
            int? ll_rt_id;
            int? ll_rs_id;
            int? ll_tc_id;
            int ll_currentRow;
            int? ll_null;
            string ls_null;
            string ls_road_name;
            string ls_sl_name;
            //string ls_tc_name;
            Metex.Windows.DataUserControl ldwc_child;
            ll_null = null;
            ls_null = null;

            itemReallyChanged = false;
            SearchAddress dw_address_current = dw_address.DataObject.Current as SearchAddress;

            // If the road name has changed, filter the road type and suffix
            if (column_name == "road_name")
            {
                //itemReallyChanged = false;
                ls_road_name = dw_address_current.RoadName;
                dw_address.GetItem<SearchAddress>(0).RtId = -100;
                dw_address.GetItem<SearchAddress>(0).RsId = -100;
                ll_rt_id = null;
                ll_rs_id = null;

                //  Filter the road type
                ldwc_child = dw_address.DataObject.GetChild("rt_id");
                if (inv_road.of_filterroadtype1(ls_road_name, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    //((Metex.Windows.DataEntityCombo)dw_address.GetControlByName("rt_id")).SelectedIndex = 0;
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rt_id = ldwc_child.GetItem<DddwRoadType>(ll_currentRow).RtId;
                        dw_address.GetItem<SearchAddress>(0).RtId = ll_rt_id;
                    }
                }
                else
                {
                    // TJB RD7_0042 Jan-2010: Changed
                    //     Changed filter so that if roadname cleared, rt dropdown reverts to all road types
                    //ldwc_child.FilterString = "rt_id < 0";
                    //ldwc_child.FilterOnce<DddwRoadType>(FilterRtId);
                    ldwc_child.FilterString = "";
                    ldwc_child.FilterOnce<DddwRoadType>(RoadTypeNoFilter);
                    dw_address.GetItem<SearchAddress>(0).RtId = -100;
                }

                //  Filter the road suffix
                ldwc_child = dw_address.DataObject.GetChild("rs_id");
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentRow).RsId;
                        dw_address.GetItem<SearchAddress>(0).RsId = ll_rs_id;
                    }
                }
                else
                {
                    // TJB RD7_0042 Jan-2010: Changed
                    //     Changed filter so that if roadname cleared, rt dropdown reverts to all road types
                    //ldwc_child.FilterString = "rs_id < 0";
                    //ldwc_child.FilterOnce<DddwRoadSuffix>(FilterRsId);
                    ldwc_child.FilterString = "";
                    ldwc_child.FilterOnce<DddwRoadSuffix>(RoadSuffixNoFilter);
                    dw_address.GetItem<SearchAddress>(0).RsId = -100;
                }
                //itemReallyChanged = true;
            }

            //If the road type has changed, filter the road suffix
            if (column_name == "rt_id")
            {
                //itemReallyChanged = false;
                ls_road_name = dw_address_current.RoadName;
                ll_rt_id = dw_address_current.RtId;
                dw_address.GetItem<SearchAddress>(0).RsId = -100;
                ll_rs_id = null;
                ldwc_child = dw_address.DataObject.GetChild("rs_id");
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentRow).RsId;
                        dw_address.GetItem<SearchAddress>(0).RsId = ll_rs_id;
                    }
                }
                else
                {
                    // TJB RD7_0042 Jan-2010: Changed
                    //     Changed filter so that if roadname cleared, rt dropdown reverts to all road types
                    //ldwc_child.FilterString = "rs_id < 0";
                    //ldwc_child.FilterOnce<DddwRoadSuffix>(FilterRsId);
                    ldwc_child.FilterString = "";
                    ldwc_child.FilterOnce<DddwRoadSuffix>(RoadSuffixNoFilter);
                    dw_address.GetItem<SearchAddress>(0).RsId = -100;
                }
                //itemReallyChanged = true;
            }

            //! if (dwo.Name == "road_name" || dwo.Name == "rt_id" || dwo.Name == "rs_id" || dwo.Name == "sl_name" || dwo.Name == "tc_id")
            //! if (dw_address.GetColumnName() == "road_name" || dw_address.GetColumnName() == "rt_id" || 
            //!    dw_address.GetColumnName() == "rs_id" || dw_address.GetColumnName() == "sl_name" || 
            //!    dw_address.GetColumnName() == "tc_id")             
            if (column_name == "road_name" 
                || column_name == "rt_id" 
                || column_name == "rs_id" 
                || column_name == "sl_name" 
                || column_name == "tc_id")
            {
                ls_road_name = dw_address_current.RoadName;  // dw_address.GetItemString(row, "road_name");
                ll_rt_id = dw_address_current.RtId;          //dw_address.GetItemNumber(row, "rt_id");
                ll_rs_id = dw_address_current.RsId;          //dw_address.GetItemNumber(row, "rs_id");
                ls_sl_name = dw_address_current.SlName;      //dw_address.GetItemString(row, "sl_name");
                ll_tc_id = dw_address_current.TcId;          //dw_address.GetItemNumber(row, "tc_id");

                string data = null;

                //!if (dw_address.GetColumnName() == "road_name")
                if (column_name == "road_name")
                {
                    ls_road_name = dw_address_current.RoadName;
                    data = ls_road_name;
                }
                else if (column_name == "rt_id")
                {
                    ll_rt_id = dw_address_current.RtId;
                    data = string.Format("{0}", ll_rt_id);
                }
                else if (column_name == "rs_id")
                {
                    ll_rs_id = dw_address_current.RsId;
                    data = string.Format("{0}", ll_rs_id);
                }
                else if (column_name == "sl_name")
                {
                    ls_sl_name = dw_address_current.SlName;
                    data = ls_sl_name;
                }
                else if (column_name == "tc_id")
                {
                    ll_tc_id = dw_address_current.TcId;
                    data = string.Format("{0}", ll_tc_id);
                }

                // TJB RD7_0042 Jan-2010: Removed: unused
                //SearchAddress CurrentAddress = (SearchAddress)(dw_address.DataObject.Current);

                //! of_filter_town_dddw(dw_address.GetColumnName(), data);
                of_filter_town_dddw(column_name, data);

                ib_town_filtered = false;
                if (!((ll_tc_id == null)) && ll_tc_id > 0)
                {
                    ldwc_child = dw_address.DataObject.GetChild("tc_id");
                    ll_row = ldwc_child.Find("tc_id", ll_tc_id);
                    if (ll_row > 0)
                        ib_town_filtered = true;
                }
                if (ib_town_filtered)
                    dw_address.GetItem<SearchAddress>(0).TcId = ll_tc_id;
                else
                    dw_address.GetItem<SearchAddress>(0).TcId = -100;

                //! of_filter_suburb_dddw(dw_address.GetColumnName(), data); 
                of_filter_suburb_dddw(column_name, data);

                ib_sub_filtered = false;
                if (!((ls_sl_name == null)) && !(ls_sl_name == ""))
                {
                    ldwc_child = dw_address.DataObject.GetChild("sl_name");

                    //! ll_row = ldwc_child.Find( "sl_name = \"" + ls_sl_name + '\"' ).Length);
                    //!for (int i = 0; i < ldwc_child.RowCount; i++)
                    for (int i = 0; i < ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Items.Count; i++)
                    {
                        //! DataSource of DDddwSuburbNames is made a list of strings for performance reasons
                        //!DddwSuburbNames item = ldwc_child.GetItem<DddwSuburbNames>(i);
                        string item = (((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<DddwSuburbNames>)[i].SlName;
                        //!if (item.SlName == ls_sl_name)
                        if (item == ls_sl_name)
                        {
                            ll_row = i;
                            break;
                        }
                    }

                    if (ll_row >= 0)
                        ib_sub_filtered = true;
                }
                if (ib_sub_filtered)
                    dw_address.GetItem<SearchAddress>(0).SlName = ls_sl_name;
                else
                    dw_address.GetItem<SearchAddress>(0).SlName = "";

                // TJB RD7_0042 Jan-2010: Added itemReallyChanged flip-flop
                // Refresh() was triggering itemChanged event which put program into a loop
                //itemReallyChanged = false;
                dw_address.DataObject.BindingSource.CurrencyManager.Refresh();
                //itemReallyChanged = true;
            }
            itemReallyChanged = true;
        }

        public virtual void dw_address_ue_clear_fields()
        {
            string ls_null;
            int? ll_null;
            Metex.Windows.DataUserControl ldwc_child;
            ls_null = null;
            ll_null = null;
            il_road_id = ll_null;
            // JB RD7_0042 Jan-2010: Added
            column_name = null;

            if (dw_address.RowCount > 0)
            {
                //! added code for itemReallyChanged flag so that ItemChanged is not triggered for dw_address 
                itemReallyChanged = false;

                dw_address.GetItem<SearchAddress>(0).AdrNum = ls_null;
                dw_address.GetItem<SearchAddress>(0).AdrNo = ls_null;
                dw_address.GetItem<SearchAddress>(0).AdrUnit = ls_null;
                dw_address.GetItem<SearchAddress>(0).AdrAlpha = ls_null;
                dw_address.GetItem<SearchAddress>(0).RoadName = ls_null;
                dw_address.GetItem<SearchAddress>(0).RtId = -100;
                dw_address.GetItem<SearchAddress>(0).RsId = -100;
                dw_address.GetItem<SearchAddress>(0).TcId = -100;
                dw_address.GetItem<SearchAddress>(0).SlName = "";
                dw_address.GetItem<SearchAddress>(0).AdrRdNo = ls_null;
                dw_address.GetItem<SearchAddress>(0).DpId = ll_null;

                if (il_contract_no > 0)
                {
                    dw_address.GetItem<SearchAddress>(0).ContractNo = il_contract_no;
                    dw_address.DataObject.GetControlByName("contract_no").TabStop = false;
                }
                else
                {
                    dw_address.GetItem<SearchAddress>(0).ContractNo = ll_null;
                }

                dw_address.DataObject.BindingSource.CurrencyManager.Refresh();

                // Clear the RD number
                is_rd_no = "";

                // Clear the road type
                ldwc_child = dw_address.DataObject.GetChild("rt_id");
                ldwc_child.FilterString = "";
                ldwc_child.FilterOnce<DddwRoadType>(RoadTypeNoFilter);
                if (!string.IsNullOrEmpty(ldwc_child.SortString))
                {
                    ldwc_child.Sort<DddwRoadType>();
                }
                //ldwc_child.SetCurrent(0);
                //dw_address.GetItem<SearchAddress>(0).RtId = -100;

                // Clear the road suffix
                ldwc_child = dw_address.DataObject.GetChild("rs_id");
                ldwc_child.FilterString = "";
                ldwc_child.FilterOnce<DddwRoadSuffix>(RoadSuffixNoFilter);
                if (!string.IsNullOrEmpty(ldwc_child.SortString))
                {
                    ldwc_child.Sort<DddwRoadSuffix>();
                }
                ldwc_child.SetCurrent(0);

                // TJB  RD7_0042  Jan-2010: Changed
                // Reset the suburb list by re-populating it from SuburbSource
                //List<DddwSuburbNames> source = new List<DddwSuburbNames>(
                //    NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames.GetAllDddwSuburbNames());
                //
                //NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames emptyRow = new NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames();
                //emptyRow.SlName = "";
                //source.Insert(0, emptyRow);
                //! need an empy entry as dropdown cannot show empty text otherwise
                //!                source.Sort();
                //((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = source;
                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = SuburbSource;

                // TJB  RD7_0042 Feb-2010: Bug fix
                //     Added to clear suburb name when clearing the search criteria
                idw_address.GetControlByName("sl_name").Text = "";

                // Clear the Town/City 
                ldwc_child = dw_address.DataObject.GetChild("tc_id");
                ldwc_child.FilterOnce<DddwTownOnly>(TownOnlyNoFilter);
                if (!string.IsNullOrEmpty(ldwc_child.SortString))
                {
                    ldwc_child.Sort<DddwTownOnly>();
                }
                ldwc_child.SetCurrent(0);

                dw_address.DataObject.BindingSource.CurrencyManager.Refresh();

                itemReallyChanged = true;
            }
        }

        private bool RoadTypeNoFilter(DddwRoadType item)
        {
            return true;
        }

        private bool RoadSuffixNoFilter(DddwRoadSuffix item)
        {
            return true;
        }

        private bool SuburbNamesNoFilter(DddwSuburbNames item)
        {
            return true;
        }

        private bool TownOnlyNoFilter(DddwTownOnly item)
        {
            return true;
        }

        public virtual void dw_address_constructor()
        {
            dw_address.of_SetUpdateable(false);
            //?dw_address.of_SetDropDownSearch(true);
            idw_address = dw_address.DataObject;

            //! dw_address.ue_postConstructed();                        
            dw_address_ue_postconstructed();
        }
    
        public void parent_ue_set_new()
        {
            ((WAddressSearch)Parent).ue_set_new();
        }

        public virtual void tabpage_occupant_ue_clear()
        {
            dw_contact_ue_clear_fields();
        }

        public virtual void dw_contact_ue_postconstructed()
        {
            dw_contact.InsertItem<AddressSearchPrimContact>(0);
        }

        public virtual void dw_contact_ue_clear_fields()
        {
            string ls_null;
            ls_null = null;

            if (dw_contact.RowCount > 0)
            {
                dw_contact.GetItem<AddressSearchPrimContact>(0).CustSurnameCompany = ls_null;
                dw_contact.GetItem<AddressSearchPrimContact>(0).CustInitials = ls_null;
            }
            dw_contact.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        public virtual void dw_contact_constructor()
        {
            dw_contact.of_SetUpdateable(false);
            idw_contact = dw_contact.DataObject;
            dw_contact_ue_postconstructed();
        }

        #endregion

        #region Events

        public virtual void u_tab_address_search_getfocus(object sender, EventArgs e)
        {
            tabpage_address.Focus();
        }

        public virtual void dw_address_editchanged(object sender, EventArgs e)
        {

            string ls_ColumnName;
            ls_ColumnName = dw_address.GetColumnName();
            if (ls_ColumnName == "road_name")
            {
                roadNameChanged = true;
                //dw_address.ue_editchanged(row, dwo, data);
                dw_address_ue_editchanged(ls_ColumnName);
                //?inv_dropdownsearch.pfc_EditChanged(row, dwo, data);
            }
        }

        public virtual void dw_address_pfc_EditChanged(object sender, EventArgs e)
        {
            // TJB  Jan 2010:  Revised (later: event trigger disabled so never called)
            // Exit before doing the ds_child stuff if appropriate
            // Called when the address window is loaded for each of the controls,
            // with the 'searchString' empty, so exiting first saves a bit of time.
            //
            // Doesn't seem to do anything useful since only the dw_child is changed
            // and that is purely local (unless its a pointer to the dw_address??).

            string searchString = ((Control)sender).Text.Trim();
            if (string.IsNullOrEmpty(searchString))
            {
                return;
            }
            string this_sl_name;
            string ls_ColumnName, t1;
            ls_ColumnName = dw_address.GetColumnName();
            t1 = ls_ColumnName;
            Metex.Windows.DataUserControl dw_child = dw_address.GetChild("sl_name");
            dw_child = new DDddwSuburbNames();
            searchString = searchString.ToUpper();
            for (int li_row = 0; li_row < dw_child.RowCount; li_row++)
            {
                this_sl_name = dw_child.GetValue<string>(li_row, "sl_name").Trim().ToUpper();
                if (this_sl_name.StartsWith(searchString))
                {
                    dw_child.SetCurrent(li_row);
                    break;
                }
            }
        }

        //! added in case ItemChanged is not triggered from "Street/Road Name"
        private void dw_address_validating(object sender, CancelEventArgs e)
        {
            if (roadNameChanged)
            {
                string ls_ColumnName, t1;
                ls_ColumnName = dw_address.GetColumnName();
                t1 = ls_ColumnName;

                dw_address_itemchanged(sender, new EventArgs());
                roadNameChanged = false;
            }
        }

        public virtual void dw_address_itemchanged(object sender, EventArgs e)
        {
            if (itemReallyChanged)
            {
                // TJB Jan 2009: RD7_0021 [Bugfix to earlier workaround (below)]
                //     Moved AcceptText() from inside if (column_name=sl_name block
                //     to fix issue with populating town, road type and road suffix
                //     dropdowns.
                this.dw_address.DataObject.AcceptText();

                // TJB Feb 2009 RD7_0021: Later change
                //     External column_name ignored.  Column_name used is the prev_columnName 
                //     being the name of the column we're moving out of (and hense which may have changed)
                //     we do this because the basic function of this routine is to call the 
                //     dw_address_ue_filter_dropdown routine.
                column_name = prev_columnName;

                // TJB Feb 2009 RD7_0021: subsequently commented out
                // The road_name's TextChanged event is taken up with code to anticipate 
                // the name being entered.  When the user exits the field, the 
                // dw_address_validating function is called which calls this routine 
                // (dw_address_itemchanged), but dw_address.GetColumnName returns the 
                // name of the column the user has tabbed to, not the column just exited. 
                // The statement below overrides this so that the road type filtering 
                // can be done when the road name is changed.
                // if (roadNameChanged)
                //     column_name = "road_name";
                // else
                // {
                //     column_name = dw_address.GetColumnName();
                //     column_name = prev_columnName;
                // }

                // TJB Jan 2009: Added column_name == "sl_name" condition to workaround/fix
                //               RDS Address screen startup unhandled exception (in debugging mode only!)
//                if (column_name == "sl_name")
//                {
//                    //! selection changed but binded property not yet until data window loses focus
//                    itemReallyChanged = false;
//                    // this.dw_address.DataObject.AcceptText();
//                    //! assign property for this simple combo box explicitly
//                    (this.dw_address.DataObject.Current as SearchAddress).SlName =
//                        string.Format("{0}", ((ComboBox)(dw_address.DataObject.GetControlByName("sl_name"))).Text);
//                    itemReallyChanged = true;
//                }
                if (column_name == "AdrRdNo")
                {
                    if ((dw_address.GetItem<SearchAddress>(dw_address.GetRow()).AdrRdNo == null) ||
                        dw_address.GetItem<SearchAddress>(dw_address.GetRow()).AdrRdNo == "")
                    {
                        is_rd_no = "";
                    }
                    else
                    {
                        is_rd_no = dw_address.GetItem<SearchAddress>(dw_address.GetRow()).AdrRdNo;
                    }
                }
                if (column_name == "road_name" 
                    || column_name == "rt_id" 
                    || column_name == "rs_id" 
                    || column_name == "tc_id" 
                    || column_name == "sl_name")
                {
                    //dw_address.ue_filter_dropdown(row, dwo, data);
                    dw_address_ue_filter_dropdown(column_name);
                }
                if (column_name == "rd_contract_select")
                {
                    //w_address_search.ue_set_new();
                    BeginInvoke(new InvokeDelegate(parent_ue_set_new));
                }
            }
        }

        public virtual void dw_address_losefocus(object sender, EventArgs e)
        {
            string ls_ColumnName, t1, t2;
            ls_ColumnName = dw_address.GetColumnName();
            t1 = ls_ColumnName;
            t2 = t1;
            dw_address.DataObject.AcceptText();
        }
        
        public virtual void dw_address_getfocus(object sender, EventArgs e)
        {
            FormBase lw_parent;
            if (this.Parent != null && this.Parent is WAddressSearch)
            {
                ((WAddressSearch)(this.Parent)).ue_criteria_gainfocus();
            }
            is_active_tab = "address";
        }

        // TJB  RD7_0042  Jan-2010: Added
        // These keep track of what column we're coming from and going to
        private string prev_columnName = "";
        private string this_columnName = "";

        public virtual void dw_address_itemfocuschanged(object sender, EventArgs e)
        {
            // TJB RD7_0042 Jan-2010: Changed
            //     Use a change in column as the trigger for dw_address_itemchanged
            //     instead of the selectedindexchanged event.
            //     If the prev_columnName is empty, we've just started and don't need 
            //     do the itemchanged procedure.

            // TJB The local variables are there to make it easier to see what's happening
            //     when debugging.  The variable 't' is needed to make the prev_prev_column 
            //     and prev_column's visible.
            // string this_column;
            // string prev_prev_column, prev_column, t;
            // prev_prev_column = prev_columnName;
            // prev_column = this_columnName;
            // this_column = dw_address.GetColumnName();
            // t = prev_prev_column; t = prev_column; t = this_column;
            prev_columnName = this_columnName;
            this_columnName = dw_address.GetColumnName();
            if (!(prev_columnName == "")
                 && !(prev_columnName == this_columnName)
               )
            {
                dw_address_itemchanged(sender, new EventArgs());
            }
            is_active_tab = "address";
            // TJB  Added this to try to ensure the search button is the default
            //      whenever the criteria has focus.
            ((WAddressSearch)(this.Parent)).ue_criteria_gainfocus();
        }

        public virtual void dw_contact_losefocus(object sender, EventArgs e)
        {
            dw_contact.DataObject.AcceptText();
        }

        public virtual void dw_contact_getfocus(object sender, EventArgs e)
        {
            FormBase lw_parent;
            is_active_tab = "contact";
        }

        public virtual void dw_contact_itemfocuschanged(object sender, EventArgs e)
        {
            // TJB  RD7_0042  Jan-2010: New from dw_address_itemfocuschanged
            // This just sets this_columnName and prev_columnName since
            // changes on the contact tab don't affect the dropdown lists.
            string this_column;
            string prev_prev_column, prev_column, t;
            prev_prev_column = prev_columnName;
            prev_column = this_columnName;
            this_column = dw_address.GetColumnName();
            t = prev_prev_column; t = prev_column; t = this_column;
            prev_columnName = this_columnName;
            this_columnName = dw_address.GetColumnName();
            is_active_tab = "contact";
            // TJB  Added this to try to ensure the search button is the default
            //      whenever the criteria has focus.
            ((WAddressSearch)(this.Parent)).ue_criteria_gainfocus();
        }
        #endregion
    }
}
