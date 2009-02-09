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

        #endregion

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                this.constructor();
                dw_address.DataObject = new DSearchAddress();
                dw_contact.DataObject = new DAddressSearchPrimContact();
                dw_address.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dw_contact.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.tabpage_address_constructor();


                dw_address.URdsDwItemFocuschanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_address_itemfocuschanged);
                dw_address.URdsDwEditChanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_address_editchanged);

                //!dw_address.ItemChanged += new EventHandler(dw_address_itemchanged);

                //! added to trigger edit changed for the Road name textbox
                ((TextBox)(dw_address.GetControlByName("adr_rd_no"))).Validating += new CancelEventHandler(dw_address_validating);
                /* this event will unceasing touch off event dw_address_itemchanged :remarked by ygu*/
                ((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("rt_id"))).SelectedIndexChanged +=
                    new EventHandler(dw_address_itemchanged);
                ((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("rs_id"))).SelectedIndexChanged +=
                    new EventHandler(dw_address_itemchanged);
                ((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("tc_id"))).SelectedIndexChanged +=
                  new EventHandler(dw_address_itemchanged);
                ((ComboBox)(dw_address.GetControlByName("sl_name"))).SelectedIndexChanged +=
                    new EventHandler(dw_address_itemchanged);

                ((CheckBox)dw_address.GetControlByName("rd_contract_select")).CheckedChanged += new EventHandler(dw_address_itemchanged);
                ((TextBox)(dw_address.GetControlByName("road_name"))).TextChanged += new EventHandler(dw_address_editchanged);
                ((TextBox)(dw_address.GetControlByName("road_name"))).Validating += new CancelEventHandler(dw_address_validating);

                dw_address.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_address_constructor);
                dw_contact.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_contact_constructor);

                //jlwang:end

                //pp! GetFocus for dw_address not working - attaching the GetFocusEvent to controls of the data window
                foreach (Control c in dw_address.DataObject.Controls)
                {
                    c.GotFocus += new EventHandler(dw_address_getfocus);
                }

                Control col = dw_address.GetControlByName("sl_name");
                col.TextChanged += new EventHandler(this.dw_address_pfc_EditChanged);         

            }
            
            base.OnHandleCreated(e);
        }

        public UTabAddressSearch()
        {
            InitializeComponent();


            //! code below moved to OnHandleCreated in order not to break the designer

            //if (!DesignMode)
            //{
            //    this.constructor();
            //    dw_address.DataObject = new DSearchAddress();
            //    dw_contact.DataObject = new DAddressSearchPrimContact();
            //    dw_address.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //    dw_contact.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //    this.tabpage_address_constructor();
            //}
            ////this.dw_address_constructor();
            ////this.dw_contact_constructor();   

            ////jlwang:moved from IC
           
            //    dw_address.URdsDwItemFocuschanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_address_itemfocuschanged);
            //    dw_address.URdsDwEditChanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_address_editchanged);

            //    //!dw_address.ItemChanged += new EventHandler(dw_address_itemchanged);

            //    //! added to trigger edit changed for the Road name textbox
            //    ((TextBox)(dw_address.GetControlByName("adr_rd_no"))).Validating += new CancelEventHandler(dw_address_validating);
            //    /* this event will unceasing touch off event dw_address_itemchanged :remarked by ygu*/
            //    ((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("rt_id"))).SelectedIndexChanged +=
            //        new EventHandler(dw_address_itemchanged);
            //    ((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("rs_id"))).SelectedIndexChanged +=
            //        new EventHandler(dw_address_itemchanged);
            //    ((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName("tc_id"))).SelectedIndexChanged +=
            //      new EventHandler(dw_address_itemchanged);
            //    ((ComboBox)(dw_address.GetControlByName("sl_name"))).SelectedIndexChanged +=
            //        new EventHandler(dw_address_itemchanged);

            //    ((CheckBox)dw_address.GetControlByName("rd_contract_select")).CheckedChanged += new EventHandler(dw_address_itemchanged);
            //    ((TextBox)(dw_address.GetControlByName("road_name"))).TextChanged += new EventHandler(dw_address_editchanged);
            //    ((TextBox)(dw_address.GetControlByName("road_name"))).Validating += new CancelEventHandler(dw_address_validating);

            //    dw_address.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_address_constructor);
            //    dw_contact.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_contact_constructor);

            //    //jlwang:end

            //    //pp! GetFocus for dw_address not working - attaching the GetFocusEvent to controls of the data window
            //    foreach (Control c in dw_address.DataObject.Controls)
            //    {
            //        c.GotFocus += new EventHandler(dw_address_getfocus);
            //    }

            //    Control col = dw_address.GetControlByName("sl_name");
            //    col.TextChanged += new EventHandler(this.dw_address_pfc_EditChanged);         

        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.tabpage_address = new TabPage();
            this.tabpage_occupant = new TabPage();
            Controls.Add(tabpage_address);
            Controls.Add(tabpage_occupant);
            this.Size = new System.Drawing.Size(532, 130);
            this.GotFocus += new EventHandler(u_tab_address_search_getfocus);
            
            // 
            // tabpage_address
            // 
            dw_address = new URdsDw();
            //!dw_address.DataObject = new DSearchAddress();
            tabpage_address.Controls.Add(dw_address);
            tabpage_address.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_address.Text = "By Address";
            tabpage_address.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_address.Size = new System.Drawing.Size(524, 101);
            tabpage_address.Top = 25;
            tabpage_address.Left = 3;
        
            // 
            // dw_address
            // 
            //dw_address.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_address.VerticalScroll.Visible = false;
            dw_address.TabIndex = 1;
            dw_address.Location = new System.Drawing.Point(3, 7);
            dw_address.Size = new System.Drawing.Size(513, 88);
            //!dw_address.DataObject.GotFocus += new EventHandler(dw_address_getfocus);            
            dw_address.LostFocus += new EventHandler(dw_address_losefocus);

            // 
            // tabpage_occupant
            // 
            dw_contact = new URdsDw();
            //!dw_contact.DataObject = new DAddressSearchPrimContact();
            tabpage_occupant.Controls.Add(dw_contact);
            tabpage_occupant.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_occupant.Text = "By Primary Contact";
            tabpage_occupant.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_occupant.Size = new System.Drawing.Size(524, 101);
            tabpage_occupant.Top = 25;
            tabpage_occupant.Left = 3;
           
            // 
            // dw_contact
            // 
            //!dw_contact.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_contact.VerticalScroll.Visible = false;
            dw_contact.TabIndex = 1;
            dw_contact.Location = new System.Drawing.Point(1, 8);
            dw_contact.Size = new System.Drawing.Size(352, 89);
            dw_contact.LostFocus += new EventHandler(dw_contact_losefocus);
            dw_contact.GotFocus += new EventHandler(dw_contact_getfocus);
            //dw_contact.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_contact_constructor);
            this.ResumeLayout();
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

            //pp! changed the condition - dropdowns have an empty string added - not null this is why the condition checks for empty string too
            //! do not change it back please
            //!if ((ls_adr_num == null))
            if (string.IsNullOrEmpty(ls_adr_num))
            {
                ls_adr_num = "";
            }
            else
            {
                ls_adr_num = ls_adr_num.Trim();
                lb_criteria_specified = true;
            }

            //!ls_sl_name = idw_address.GetItemString(1, "sl_name");
            ls_sl_name = idw_address.GetControlByName("sl_name").Text;

            //pp! changed the condition - dropdowns have an empty string added - not null this is why the condition checks for empty string too
            //! do not change it back please
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
            //!if ((ll_tc_id == null) || ll_tc_id <= 0)
            if (!ll_tc_id.HasValue || ll_tc_id <= 0)
            {
                ll_tc_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
                ldwc_child = idw_address.GetChild("tc_id");
                ll_row = ldwc_child.Find("tc_id", ll_tc_id);//ll_row = ldwc_child.Find( "tc_id = " + ll_tc_id).ToString().Length);
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
            //!if ((ll_rt_id == null) || ll_rt_id == -100)
            if (!ll_rt_id.HasValue || ll_rt_id == -100)//pp! -100 is value for empty item inserted in dropdown
            {
                ll_rt_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }

            ll_rs_id = idw_address.GetItem<SearchAddress>(0).RsId;
            //!if ((ll_rs_id == null) || ll_rs_id == -100)
            if (!ll_rs_id.HasValue || ll_rs_id == -100)//pp! -100 is value for empty item inserted in dropdown
            {
                ll_rs_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }

            ll_contract_no = idw_address.GetItem<SearchAddress>(0).ContractNo;
            //!if ((ll_contract_no == null) || ll_contract_no <= 0)
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
            //!if ((ll_rdSelect == null))
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
            //!if (!((ll_rdSelect == null)) && ll_rdSelect == 0)
            if (ll_rdSelect.HasValue && ll_rdSelect == 0)
            {
                lb_criteria_specified = true;
            }
            if (lb_criteria_specified == false)
            {
                MessageBox.Show("Please specify at least one search criteria", "Search Address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //idw_address.GetControlByName("adr_no").Focus();//idw_address.DataControl["adr_no"].Focus();not have then control "adr_no"
                //idw_contact.GetControlByName("cust_id").Focus();//idw_contact.DataControl["cust_id"].Focus();not have then control "cust_id"
                idw_address.Focus();
                return false;
            }
            adw_result.Retrieve(new object[] { ls_adr_num, ls_road_name, ll_rt_id, ll_rs_id, ls_sl_name, 
                ls_tc_name, ll_contract_no, ls_rd_no, ls_surname, ls_initials, StaticVariables.gnv_app.of_getuserid(), 
                StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid("Address"), ll_rdSelect, ll_dpid });

            if (adw_result.RowCount <= 0)
            {
                MessageBox.Show("There are no addresses that satisfy the search criteria entered.", "Unsuccessful Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int ll_datarows;
            int ll_filteredrows;
            string ls_road_name;
            //!string ls_filter;
            Metex.Windows.DataUserControl ldwc_child;
            ll_row = idw_address.GetRow();
            ls_road_name = idw_address.GetItem<SearchAddress>(ll_row).RoadName;

            //idw_address.GetItemNumber(ll_row, "rt_id");
            ll_rt_id = (idw_address.GetItem<SearchAddress>(ll_row).RtId == -100) ? null : idw_address.GetItem<SearchAddress>(ll_row).RtId;

            //idw_address.GetItemNumber(ll_row, "rs_id");
            ll_rs_id = (idw_address.GetItem<SearchAddress>(ll_row).RsId == -100) ? null : idw_address.GetItem<SearchAddress>(ll_row).RsId;

            ll_tc_id = idw_address.GetItem<SearchAddress>(ll_row).TcId;
            if (as_arg_name == "road_name")
            {
                ls_road_name = as_arg_value;
            }
            else if (as_arg_name == "rt_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value))
                {
                    ll_rt_id = System.Convert.ToInt32(as_arg_value);
                }
            }
            else if (as_arg_name == "rs_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value))
                {
                    ll_rs_id = System.Convert.ToInt32(as_arg_value);
                }
            }
            else if (as_arg_name == "tc_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value))
                {
                    ll_tc_id = System.Convert.ToInt32(as_arg_value);
                }
            }
            ls_filter = inv_road.of_getsuburblist1(ls_road_name, ll_rt_id, ll_rs_id, ll_tc_id);


            //!ldwc_child = idw_address.GetChild("sl_name");//ll_rc = idw_address.GetChild("sl_name", ldwc_child);           
            //! ll_rc = ldwc_child.FilterString = "";
            //! ll_rc = ldwc_child.Filter();            
            itemReallyChanged = false;

            //!((NZPostOffice.RDS.DataControls.Ruralwin.DDddwSuburbNames)ldwc_child).FilterOnce<DddwSuburbNames>(NoFilterName);
            //! change the data source of the dropdown and looses selected value
            string currentSuburb = string.Format("{0}", ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Text);
            List<NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames> sourceClean = new List<NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames>
                (NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames.GetAllDddwSuburbNames());
            NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames emptyItem = new DddwSuburbNames(); emptyItem.SlName = "";
            sourceClean.Insert(0, emptyItem);
            ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = sourceClean;

            ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Text = currentSuburb;
            ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.SelectedValue = currentSuburb;

            itemReallyChanged = true;

            ll_datarows = ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Items.Count;//!ldwc_child.RowCount;

            //!ldwc_child.RowCount;//! added to keep track of original count
            int ll_datarows1 = ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Items.Count;

            if (!string.IsNullOrEmpty(ls_filter))
            {
                //!ldwc_child.FilterString = "sl_name in  ( " + ls_filter + ")";//ll_rc = ldwc_child.SetFilter("sl_name in  ( " + ls_filter + ')');

                //! do not add sl_name in etc.. - different approach for filtering
                string filter = /*!"sl_name in  ( " + !*/ ls_filter /*! + ")" ! */;

                //! ll_rc = ldwc_child.Filter();
                //! added another method in data window to filter as DataSource is List<string> for performance reasons

                itemReallyChanged = false;

                //!((NZPostOffice.RDS.DataControls.Ruralwin.DDddwSuburbNames)ldwc_child).FilterOnce<DddwSuburbNames>(FilterName);
                //! change the data source of the dropdown and looses selected value
                currentSuburb = string.Format("{0}", ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Text);
                this.FilterSuburbsNamesIn(filter);
                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Text = currentSuburb;
                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.SelectedValue = currentSuburb;

                itemReallyChanged = true;
            }

            //! ll_rc = ldwc_child.Sort();
            itemReallyChanged = false;

            //!if (!string.IsNullOrEmpty(ldwc_child.SortString))
            {
                //!ldwc_child.Sort<DddwSuburbNames>();
                //!(((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<string>).Sort();
                (((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<DddwSuburbNames>).Sort(
                    new Comparison<DddwSuburbNames>(SuburbsSorter)
                    );
            }
            itemReallyChanged = true;

            ll_datarows = ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.Items.Count;//!ldwc_child.RowCount;

            //!ll_filteredrows = ldwc_child.FilteredCount();
            ll_filteredrows = ll_datarows1 - ll_datarows;

            return 0;
        }

        private int SuburbsSorter(DddwSuburbNames item1, DddwSuburbNames item2)
        {
            return string.Compare(item1.SlName, item2.SlName);
        }

        private void FilterSuburbsNamesIn(string lsFilter)
        {
            List<DddwSuburbNames> entitySource = ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource as List<DddwSuburbNames>;

            if (!string.IsNullOrEmpty(lsFilter))
            {
                List<DddwSuburbNames> filteredStringSource = new List<DddwSuburbNames>();

                string[] items = lsFilter.Split(new char[] { ',' });

                foreach (string s in items)
                {
                    foreach (DddwSuburbNames item in entitySource)
                    {

                        if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(item.SlName) && item.SlName.Trim() == s.Trim() &&
                                this.NotRepeatedItem(filteredStringSource, item.SlName))//! do not add one item more than once
                        {
                            filteredStringSource.Add(item);
                        }

                    }
                }
                DddwSuburbNames emptyRow = new DddwSuburbNames();
                emptyRow.SlName = "";
                filteredStringSource.Insert(0, emptyRow);//! add an empty string at end of the list

                filteredStringSource.Sort(new Comparison<DddwSuburbNames>(SuburbsSorter)
              );

                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = filteredStringSource;
            }
        }

        private bool NotRepeatedItem(List<DddwSuburbNames> filteredStringSource, string item)
        {
            foreach (DddwSuburbNames i in filteredStringSource)
            {
                if (i.SlName == item)
                {
                    return false;
                }
            }
            return true;
        }

        bool NoFilterName(DddwSuburbNames item)
        {
            return true;
        }

        //! ldwc_child.FilterString = "sl_name in  ( " + ls_filter + ")";
        bool FilterName(DddwSuburbNames item)
        {
            if (!string.IsNullOrEmpty(item.SlName) && ls_filter.IndexOf(item.SlName) >= 0)
            {
                return true;
            }
            return false;
        }

        //! ldwc_child.FilterString = "tc_id in  ( " + ls_filter + ")"; 
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
                {
                    ll_rt_id = System.Convert.ToInt32(as_arg_value);
                }
            }
            else if (as_arg_name == "rs_id")
            {
                if (!string.IsNullOrEmpty(as_arg_value) && System.Convert.ToInt32(as_arg_value) != -100)
                {
                    ll_rs_id = System.Convert.ToInt32(as_arg_value);
                }
            }
            else if (as_arg_name == "sl_name")
            {
                ls_sl_name = as_arg_value;
            }
            ls_filter = inv_road.of_gettownlist1(ls_road_name, ll_rt_id, ll_rs_id, ls_sl_name);

            ldwc_child = idw_address.GetChild("tc_id");//ll_rc = idw_address.GetChild("tc_id", ldwc_child);

            ldwc_child.FilterString = "";//ll_rc = ldwc_child.FilterString = "";

            itemReallyChanged = false;
            ldwc_child.FilterOnce<DddwTownOnly>(FilterEmpty);//ll_rc = ldwc_child.Filter();            
            itemReallyChanged = true;

            ll_datarows = ldwc_child.RowCount;
            if (!(ls_filter == ""))
            {
                ldwc_child.FilterString = "tc_id in  ( " + ls_filter + ")"; ;//ll_rc = ldwc_child.SetFilter("tc_id in  ( " + ls_filter + ')');                                
                itemReallyChanged = false;
                ldwc_child.FilterOnce<DddwTownOnly>(FilterTcId);//ll_rc = ldwc_child.Filter();                
                itemReallyChanged = true;
            }
            //!            ldwc_child.Sort<DddwTownOnly>();//ll_rc = ldwc_child.Sort();
            ll_datarows = ldwc_child.RowCount;
            //?ll_filteredrows = ldwc_child.FilteredCount();
            return 0;
        }

        public virtual void of_clear_fields()
        {
            tabpage_address_ue_clear();//tabpage_address.ue_clear();
            tabpage_occupant_ue_clear();//tabpage_occupant.ue_clear();
            ib_town_filtered = false;
            ib_sub_filtered = false;
            if (is_active_tab == "contact")
            {
                idw_contact.GetControlByName("cust_surname_company").Focus();//idw_contact.DataControl["cust_surname_company"].Focus();
                idw_contact.Focus();
            }
            else if (is_active_tab == "address")
            {
                idw_address.GetControlByName("adr_num").Focus();//idw_address.DataControl["adr_num"].Focus();
                idw_address.Focus();
            }
        }

        public virtual void of_populate(ref NCriteria anv_criteria)
        {
            if (this.SelectedIndex == 0)//if (this.SelectedTab == 1)
            {
                tabpage_address_ue_populate(ref anv_criteria);//tabpage_address.ue_populate(anv_criteria);
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
            dw_address.DataObject.GetControlByName("road_name").Focus();
            dw_address.Focus();
        }

        public virtual void dw_address_ue_postconstructed()
        {
            Metex.Windows.DataUserControl ldwc_child;

            //pp! added to send processing on background as it takes too long especially when open form for the first time
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
                ldwc_child1 = dw_address.DataObject.GetChild("rt_id");//dw_address.GetChild("rt_id", ldwc_child);
                //!                inv_road.ids_dwc_road_type.ShareData(ldwc_child1);//inv_road.ids_dwc_road_type.ShareData(ldwc_child);
                //?ldwc_child.FilterString = "";
                //?ldwc_child.Filter<DddwRoadType>();//ldwc_child.Filter();
                //!                ldwc_child1.SortString = "RtName A";
                //!                ldwc_child1.Sort<DddwRoadType>();//ldwc_child.Sort();
                //!                ldwc_child1 = dw_address.DataObject.GetChild("rs_id");//dw_address.GetChild("rs_id", ldwc_child);
                //!                inv_road.ids_dwc_road_suffix.ShareData(ldwc_child1);            

                //?ldwc_child.FilterString = "";
                //?ldwc_child.Filter<DddwRoadSuffix>();//ldwc_child.Filter();
                //!                ldwc_child1.SortString = "RsName A";
                //!                ldwc_child1.Sort<DddwRoadSuffix>();//ldwc_child.Sort();
            });
            bgWorker.RunWorkerAsync();
            //pp! end of added code            

            ldwc_child = dw_address.DataObject.GetChild("sl_name");//dw_address.GetChild("sl_name", ldwc_child);
            //?ldwc_child.FilterString = "";
            //?ldwc_child.Filter<DddwSuburbNames>();//ldwc_child.Filter();
            //@            ldwc_child.SortString = "sl_name A";
            //@            ldwc_child.Sort<DddwSuburbNames>();//ldwc_child.Sort();
            ldwc_child = dw_address.DataObject.GetChild("tc_id");// dw_address.GetChild("tc_id", ldwc_child);
            //?ldwc_child.FilterString = "";
            //?ldwc_child.Filter<DddwTownOnly>();//ldwc_child.Filter();
            ldwc_child.SortString = "tc_name A";
            //?ldwc_child.Sort<DddwTownOnly>();// ldwc_child.Sort();
            ((DSearchAddress)dw_address.DataObject).Retrieve();
            dw_address.InsertItem<SearchAddress>(0);


            //pp! added empty record in drop down to make possible null values to be selected on dropdowns                                           
            DddwTownOnly empty = new DddwTownOnly();
            empty.TcId = -100;
            empty.TcName = "";
            dw_address.DataObject.GetChild("tc_id").InsertItem<DddwTownOnly>(0, empty);


            dw_address.GetItem<SearchAddress>(dw_address.GetRow()).RdContractSelect = 1;//.SetItem(dw_address.GetRow(), "rd_contract_select", 1);

            //?if (IsValid(dw_address.inv_dropdownsearch))
            //{
            //    dw_address.inv_DropDownSearch.of_register("rt_id");
            //    dw_address.inv_DropDownSearch.of_register("rs_id");
            //    dw_address.inv_DropDownSearch.of_register("tc_id");
            //    dw_address.inv_DropDownSearch.of_register("sl_name");
            //}
        }

        public virtual void dw_address_ue_editchanged()
        {
            string sPartial = "";
            string sNextMatch = "";
            string ls_display = "";

            int size = 0;

            if (dw_address.GetColumnName() == "road_name")
            {

                if (((DSearchAddress)dw_address.DataObject).Keypress || ((DSearchAddress)dw_address.DataObject).Keyback) //if (inv_road.of_validate_keypress() || KeyDown(keyback!)) {
                {
                    if (!string.IsNullOrEmpty(dw_address.GetControlByName(dw_address.GetColumnName()).Text))
                    {
                        ls_display = dw_address.GetControlByName(dw_address.GetColumnName()).Text.Trim();//ls_display =  GetText().Trim();

                        size = ((TextBox)(dw_address.GetControlByName(dw_address.GetColumnName()))).SelectionStart;

                        if (((DSearchAddress)dw_address.DataObject).Keyback) //if (KeyDown(keyback!)) {
                        {
                            if (size - 2 > 0)
                            {
                                sPartial = ls_display.Substring(0,
                                    ((TextBox)(dw_address.GetControlByName(dw_address.GetColumnName()))).SelectionStart - 2); //sPartial = TextUtil.Left(ls_display, SelectedStart() - 2);
                            }
                            else
                            {
                                sPartial = ls_display;
                            }
                        }
                        else
                        {
                            if (size - 1 > 0)
                            {
                                sPartial = ls_display.Substring(0, ((TextBox)(dw_address.GetControlByName(dw_address.GetColumnName()))).SelectionStart /*- 1*/); //sPartial = TextUtil.Left(ls_display, SelectedStart() - 1);
                            }
                            else
                            {
                                sPartial = ls_display;
                            }
                        }
                        if (sPartial.Length > 0)
                        {
                            sNextMatch = inv_road.of_getnextmatch1(sPartial);
                            if (sNextMatch.Length > 0)
                            {
                                dw_address.GetControlByName(dw_address.GetColumnName()).Text = sNextMatch;//dw_address.SetText(sNextMatch);
                                ((TextBox)(dw_address.GetControlByName(dw_address.GetColumnName()))).Select(sPartial.Length, sNextMatch.Length);//dw_address.SelectText( sPartial.Len() + 1,  sNextMatch).Len();
                            }
                        }
                    }
                }
            }
        }

        // ldwc_child.FilterString = "rt_id < 0";
        private bool FilterRtId(DddwRoadType item)
        {
            if (item.RtId < 0)//pp! empty record with value -100 is allowed too
            {
                return true;
            }
            return false;
        }

        // ldwc_child.FilterString = "rs_id < 0";
        private bool FilterRsId(DddwRoadSuffix item)
        {
            if (item.RsId < 0)//pp! empty record with value -100 is allowed too
            {
                return true;
            }
            return false;
        }

        public virtual void dw_address_ue_filter_dropdown()
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

            SearchAddress dw_address_current = dw_address.DataObject.Current as SearchAddress;

            //!if (dw_address.GetColumnName() == "road_name")//if (dwo.Name == "road_name")
            if (column_name == "road_name")
            {
                ls_road_name = dw_address_current.RoadName;//ls_road_name = data.ToString();
                dw_address.GetItem<SearchAddress>(0).RtId = -100;//dw_address.SetItem(1, "rt_id", ll_null);
                dw_address.GetItem<SearchAddress>(0).RsId = -100;//dw_address.SetItem(1, "rs_id", ll_null);
                ll_rt_id = null;
                ll_rs_id = 0;
                ldwc_child = dw_address.DataObject.GetChild("rt_id");//dw_address.GetChild("rt_id", ldwc_child);

                itemReallyChanged = false;
                if (inv_road.of_filterroadtype1(ls_road_name, ref ldwc_child))
                {
                    itemReallyChanged = true;

                    ldwc_child.SetCurrent(0);//ldwc_child.ScrollToRow(0);
                    //((Metex.Windows.DataEntityCombo)dw_address.GetControlByName("rt_id")).SelectedIndex = 0;
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rt_id = ldwc_child.GetItem<DddwRoadType>(ll_currentRow).RtId;//.GetItemNumber(ll_currentRow, "rt_id");
                        dw_address.GetItem<SearchAddress>(0).RtId = ll_rt_id;//dw_address.SetItem(1, "rt_id", ll_rt_id);
                    }
                }
                else
                {
                    ldwc_child.FilterString = "rt_id < 0";
                    itemReallyChanged = false;
                    ldwc_child.FilterOnce<DddwRoadType>(FilterRtId);//ldwc_child.Filter();
                    itemReallyChanged = true;
                    dw_address.GetItem<SearchAddress>(0).RtId = -100;//dw_address.SetItem(1, "rt_id", ll_null);
                }
                //  Filter the road suffix
                ldwc_child = dw_address.DataObject.GetChild("rs_id");//dw_address.GetChild("rs_id", ldwc_child);

                itemReallyChanged = false;
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    itemReallyChanged = true;

                    ldwc_child.SetCurrent(0);//ldwc_child.ScrollToRow(0);
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentRow).RsId;//ll_rs_id = ldwc_child.GetItemNumber(ll_currentRow, "rs_id");
                        dw_address.GetItem<SearchAddress>(0).RsId = ll_rs_id;// dw_address.SetItem(1, "rs_id", ll_rs_id);
                    }
                }
                else
                {
                    ldwc_child.FilterString = "rs_id < 0";
                    itemReallyChanged = false;
                    ldwc_child.FilterOnce<DddwRoadSuffix>(FilterRsId);//ldwc_child.Filter();
                    itemReallyChanged = true;
                    dw_address.GetItem<SearchAddress>(0).RsId = -100;//dw_address.SetItem(1, "rs_id", ll_null);
                }
            }

            //!if (dw_address.GetColumnName() == "rt_id") //if (dwo.Name == "rt_id")
            if (column_name == "rt_id")
            {
                ls_road_name = dw_address_current.RoadName;// dw_address.GetItemString(row, "road_name");
                ll_rt_id = dw_address_current.RtId;//Metex.Common.Convert.ToInt32(data);
                dw_address.GetItem<SearchAddress>(0).RsId = -100;// dw_address.SetItem(1, "rs_id", ll_null);
                ll_rs_id = null;
                ldwc_child = dw_address.DataObject.GetChild("rs_id");//dw_address.GetChild("rs_id", ldwc_child);
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);//ldwc_child.ScrollToRow(0);
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentRow).RsId;
                        dw_address.GetItem<SearchAddress>(0).RsId = ll_rs_id;
                    }
                }
                else
                {
                    ldwc_child.FilterString = "rs_id < 0";

                    itemReallyChanged = false;
                    ldwc_child.FilterOnce<DddwRoadSuffix>(FilterRsId);//ldwc_child.Filter();
                    itemReallyChanged = true;

                    dw_address.GetItem<SearchAddress>(0).RsId = -100;// dw_address.SetItem(1, "rs_id", ll_null);
                }
            }

            //! if (dwo.Name == "road_name" || dwo.Name == "rt_id" || dwo.Name == "rs_id" || dwo.Name == "sl_name" || dwo.Name == "tc_id")
            //! if (dw_address.GetColumnName() == "road_name" || dw_address.GetColumnName() == "rt_id" || 
            //!    dw_address.GetColumnName() == "rs_id" || dw_address.GetColumnName() == "sl_name" || 
            //!    dw_address.GetColumnName() == "tc_id")             
            if (column_name == "road_name" || column_name == "rt_id" || column_name == "rs_id" || column_name == "sl_name" ||
                column_name == "tc_id")
            {
                ls_road_name = dw_address_current.RoadName;// dw_address.GetItemString(row, "road_name");
                ll_rt_id = dw_address_current.RtId;//dw_address.GetItemNumber(row, "rt_id");
                ll_rs_id = dw_address_current.RsId;//dw_address.GetItemNumber(row, "rs_id");
                ls_sl_name = dw_address_current.SlName;//dw_address.GetItemString(row, "sl_name");
                ll_tc_id = dw_address_current.TcId;//dw_address.GetItemNumber(row, "tc_id");

                string data = null;

                //!if (dw_address.GetColumnName() == "road_name")
                if (column_name == "road_name")
                {
                    ls_road_name = dw_address_current.RoadName;// data.ToString();
                    data = ls_road_name;
                }
                else if (column_name == "rt_id")//!(dw_address.GetColumnName() == "rt_id")
                {
                    ll_rt_id = dw_address_current.RtId;// Metex.Common.Convert.ToInt32(data);
                    data = string.Format("{0}", ll_rt_id);
                }
                else if (column_name == "rs_id")//!(dw_address.GetColumnName() == "rs_id")
                {
                    ll_rs_id = dw_address_current.RsId;// Metex.Common.Convert.ToInt32(data);
                    data = string.Format("{0}", ll_rs_id);
                }
                else if (column_name == "sl_name")//!(dw_address.GetColumnName() == "sl_name")
                {
                    ls_sl_name = dw_address_current.SlName;// data.ToString();                   
                    data = ls_sl_name;
                }
                else if (column_name == "tc_id")//!(dw_address.GetColumnName() == "tc_id")
                {
                    ll_tc_id = dw_address_current.TcId;// Metex.Common.Convert.ToInt32(data);
                    data = string.Format("{0}", ll_tc_id);
                }

                SearchAddress CurrentAddress = (SearchAddress)(dw_address.DataObject.Current);


                //!                of_filter_town_dddw(dw_address.GetColumnName(), data);//of_filter_town_dddw(dwo.Name, data);
                of_filter_town_dddw(column_name, data);

                ib_town_filtered = false;
                if (!((ll_tc_id == null)) && ll_tc_id > 0)
                {
                    ldwc_child = dw_address.DataObject.GetChild("tc_id");
                    ll_row = ldwc_child.Find("tc_id", ll_tc_id);//ll_row = ldwc_child.Find( "tc_id = " + ll_tc_id).ToString().Length);
                    if (ll_row > 0)
                    {
                        ib_town_filtered = true;
                    }
                }
                if (ib_town_filtered)
                {
                    dw_address.GetItem<SearchAddress>(0).TcId = ll_tc_id;//dw_address.SetItem(1, "tc_id", ll_tc_id);
                }
                else
                {
                    dw_address.GetItem<SearchAddress>(0).TcId = -100;// dw_address.SetItem(1, "tc_id", ll_null);
                }


                //!                of_filter_suburb_dddw(dw_address.GetColumnName(), data); //of_filter_suburb_dddw(dwo.Name, data);
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
                    {
                        ib_sub_filtered = true;
                    }
                }
                if (ib_sub_filtered)
                {
                    dw_address.GetItem<SearchAddress>(0).SlName = ls_sl_name;
                }
                else
                {
                    dw_address.GetItem<SearchAddress>(0).SlName = "";
                }
                dw_address.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            //!((Metex.Windows.DataEntityCombo)(dw_address.GetControlByName(dw_address.GetColumnName()))).SelectAll();//dw_address.SelectText(1, 500);
        }

        public virtual void dw_address_ue_clear_fields()
        {
            string ls_null;
            int? ll_null;
            Metex.Windows.DataUserControl ldwc_child;
            ls_null = null;
            ll_null = null;
            il_road_id = ll_null;

            if (dw_address.RowCount > 0)
            {
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

                //! added code for itemReallyChanged flag so that ItemChanged is not triggered for dw_address 
                itemReallyChanged = false;

                dw_address.DataObject.BindingSource.CurrencyManager.Refresh();

                is_rd_no = "";

                ldwc_child = dw_address.DataObject.GetChild("rt_id");
                ldwc_child.FilterString = "";
                //! ldwc_child.Filter();               
                ldwc_child.FilterOnce<DddwRoadType>(RoadTypeNoFilter);
                if (!string.IsNullOrEmpty(ldwc_child.SortString))
                {
                    ldwc_child.Sort<DddwRoadType>();//ldwc_child.Sort();
                }


                ldwc_child = dw_address.DataObject.GetChild("rs_id");//dw_address.GetChild("rs_id", ldwc_child);                
                ldwc_child.FilterString = "";
                ldwc_child.FilterOnce<DddwRoadSuffix>(RoadSuffixNoFilter);
                if (!string.IsNullOrEmpty(ldwc_child.SortString))
                {
                    ldwc_child.Sort<DddwRoadSuffix>();//ldwc_child.Sort();
                }


                //!ldwc_child = dw_address.DataObject.GetChild("sl_name");//dw_address.GetChild("sl_name", ldwc_child);                
                //!ldwc_child.FilterString = "";
                //! ldwc_child.Filter<DddwSuburbNames>();
                //!ldwc_child.FilterOnce<DddwSuburbNames>(SuburbNamesNoFilter);              
                //!ldwc_child.Sort<DddwSuburbNames>();//ldwc_child.Sort();              
                List<DddwSuburbNames> source = new List<DddwSuburbNames>(
                    NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames.GetAllDddwSuburbNames());

                NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames emptyRow = new NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames();
                emptyRow.SlName = "";
                source.Insert(0, emptyRow);//! need an empy entry as dropdown cannot show empty text otherwise
                //!                source.Sort();
                ((DSearchAddress)(dw_address.DataObject)).SuburbsCombo.DataSource = source;


                ldwc_child = dw_address.DataObject.GetChild("tc_id");
                //?ldwc_child.FilterString = "";
                //?ldwc_child.Filter<DddwTownOnly>();
                ldwc_child.FilterOnce<DddwTownOnly>(TownOnlyNoFilter);
                if (!string.IsNullOrEmpty(ldwc_child.SortString))
                {
                    ldwc_child.Sort<DddwTownOnly>();
                }

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

        public virtual void dw_address_ue_filter_dropdown_v1()
        {
            //  TJB  NPAD2  Apr 2006  BF016
            //  This is now obsolete
            int? ll_road_id;
            int? ll_rt_id;
            int? ll_rs_id = 0;
            int? ll_tc_id = 0;
            //int ll_sl_id;
            int ll_currentRow;
            int? ll_null;
            string ls_road_name;
            //string ls_sl_name;
            //string ls_tc_name;
            Metex.Windows.DataUserControl ldwc_child;
            ll_null = null;

            SearchAddress dw_address_Current = dw_address.DataObject.Current as SearchAddress;

            if (dw_address.GetColumnName() == "road_name")
            {
                ls_road_name = dw_address_Current.RoadName;// data.ToString();
                dw_address.GetItem<SearchAddress>(0).RtId = -100;//dw_address.SetItem(1, "rt_id", ll_null);
                dw_address.GetItem<SearchAddress>(0).RsId = -100;//dw_address.SetItem(1, "rs_id", ll_null);
                ll_rt_id = null;
                ll_rs_id = null;
                ldwc_child = dw_address.DataObject.GetChild("rt_id");

                if (inv_road.of_filterroadtype1(ls_road_name, ref ldwc_child))
                {

                    ldwc_child.SetCurrent(0);
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rt_id = ldwc_child.GetItem<DddwRoadType>(ll_currentRow).RtId;
                        dw_address.GetItem<SearchAddress>(0).RtId = ll_rt_id;
                    }
                }
                else
                {
                    ldwc_child.FilterString = "rt_id < 0";
                    ldwc_child.Filter<DddwRoadType>();//ldwc_child.Filter();
                    dw_address.GetItem<SearchAddress>(0).RtId = ll_null;
                }
                ldwc_child = dw_address.DataObject.GetChild("rs_id"); ;
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
                    ldwc_child.FilterString = "rs_id < 0";
                    ldwc_child.Filter<DddwRoadSuffix>();//ldwc_child.Filter();
                    dw_address.GetItem<SearchAddress>(0).RsId = ll_null;
                }
            }
            if (dw_address.GetColumnName() == "rt_id")
            {
                ls_road_name = dw_address_Current.RoadName; ;
                ll_rt_id = dw_address_Current.RtId;//Metex.Common.Convert.ToInt32(data);
                dw_address.GetItem<SearchAddress>(0).RsId = ll_null;
                ll_rs_id = null;
                ldwc_child = dw_address.DataObject.GetChild("rs_id");
                if (inv_road.of_filterroadsuffix1(ls_road_name, ll_rt_id, ref ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                    ll_currentRow = ldwc_child.GetRow();
                    if (ll_currentRow >= 0)
                    {
                        ll_rs_id = ldwc_child.GetItem<DddwRoadSuffix>(ll_currentRow).RsId;//ldwc_child.GetItemNumber(ll_currentRow, "rs_id");
                        dw_address.GetItem<SearchAddress>(0).RsId = ll_rs_id;//dw_address.SetItem(1, "rs_id", ll_rs_id);
                    }
                }
                else
                {
                    ldwc_child.FilterString = "rs_id < 0";
                    ldwc_child.Filter<DddwRoadSuffix>();//ldwc_child.Filter();
                    dw_address.GetItem<SearchAddress>(0).RsId = ll_null;//dw_address.SetItem(1, "rs_id", ll_null);
                }
            }
            if (dw_address.GetColumnName() == "road_name" || dw_address.GetColumnName() == "rt_id" ||
                dw_address.GetColumnName() == "rs_id") //if (dwo.Name == "road_name" || dwo.Name == "rt_id" || dwo.Name == "rs_id")
            {
                ls_road_name = dw_address_Current.RoadName;
                ll_rt_id = dw_address_Current.RtId;
                if (dw_address.GetColumnName() == "road_name")
                {
                    ls_road_name = dw_address_Current.RoadName; //data.ToString();
                }
                else if (dw_address.GetColumnName() == "rt_id")
                {
                    ll_rt_id = dw_address_Current.RtId;// Metex.Common.Convert.ToInt32(data);
                }
                ldwc_child = dw_address.DataObject.GetChild("tc_id");
                if (inv_road.of_filtertowntype(ls_road_name, ll_rt_id, ll_rs_id, ldwc_child))
                {
                    ldwc_child.SetCurrent(0);
                }
                dw_address.GetItem<SearchAddress>(0).TcId = ll_null;

                string data = string.Empty;
                if (dw_address.GetColumnName() == "road_name")
                {
                    data = dw_address_Current.RoadName;
                }
                else if (dw_address.GetColumnName() == "rt_id")
                {
                    data = string.Format("{0}", dw_address_Current.RtId);
                }
                else if (dw_address.GetColumnName() == "rs_id")
                {
                    data = string.Format("{0}", dw_address_Current.RsId);
                }

                of_filter_suburb_dddw(dw_address.GetColumnName(), data);//of_filter_suburb_dddw(dwo.Name, data);

                ib_sub_filtered = false;
                ib_town_filtered = false;
            }
            if (dw_address.GetColumnName() == "sl_id")
            {
            }
            if (dw_address.GetColumnName() == "tc_id")
            {
                ldwc_child = dw_address.DataObject.GetChild("tc_id");
                if (dw_address_Current.TcId == null)
                {
                    dw_address.GetItem<SearchAddress>(0).TcId = ll_null;
                    ib_town_filtered = true;
                }
                else
                {
                    ll_tc_id = dw_address_Current.TcId;
                }
                ls_road_name = dw_address_Current.RoadName;
                ll_rt_id = dw_address_Current.RtId; ;
                ll_rs_id = dw_address_Current.RsId;
                ll_road_id = inv_road.of_getroadid(ls_road_name, ll_rt_id, ll_rs_id, ll_tc_id);
                of_filter_suburb_dddw(dw_address.GetColumnName(), string.Format("{0}", dw_address_Current.TcId));////of_filter_suburb_dddw(dwo.Name, data);
            }
            ((TextBox)(dw_address.GetControlByName(dw_address.GetColumnName()))).SelectAll();//dw_address.SelectText(1, 500);
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

        public virtual void dw_address_itemerror()
        {
            //?return 1;
        }

        public virtual void dw_address_ue_deleteitem()
        {
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

        public virtual void dw_contact_ue_deleteitem()
        {
            //?base.ue_deleteitem();
        }

        //################### Unused  of_search method ############################
        public virtual bool of_search(ref URdsDw adw_result)
        {
            //int ll_zero = 0;
            int? ll_road_id;
            int? ll_rt_id;
            int? ll_rs_id;
            int? ll_sl_id;
            int? ll_tc_id;
            int? ll_contract_no;
            int? ll_dpid;
            int? ll_rdSelect;
            string ls_rd_no;
            string ls_adr_num;
            string ls_surname;
            string ls_firstname;
            //string ls_adr_unit;
            //string ls_adr_no;
            //string ls_adr_alpha;
            string ls_road_name;
            string ls_empty = "";
            //int li_rc;
            bool lb_criteria_specified;
            lb_criteria_specified = false;
            ls_adr_num = idw_address.GetItem<SearchAddress>(0).AdrNum;
            ls_adr_num = (ls_adr_num == null ? null : ls_adr_num.Trim());
            if ((ls_adr_num == null))
            {
                ls_adr_num = ls_empty;
            }
            else
            {
                lb_criteria_specified = true;
            }
            ll_sl_id = idw_address.GetItem<SearchAddress>(0).SlId;
            if ((ll_sl_id == null))
            {
                ll_sl_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }
            ll_tc_id = idw_address.GetItem<SearchAddress>(0).TcId;
            if ((ll_tc_id == null))
            {
                ll_tc_id = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }
            ls_road_name = idw_address.GetItem<SearchAddress>(0).RoadName.Trim();
            ls_road_name = (ls_road_name == null ? null : ls_road_name.Trim());

            // idw_address.GetItemNumber(1, "rt_id");
            ll_rt_id = (idw_address.GetItem<SearchAddress>(0).RtId == -100) ? null : idw_address.GetItem<SearchAddress>(0).RtId;
            // idw_address.GetItemNumber(1, "rs_id");
            ll_rs_id = (idw_address.GetItem<SearchAddress>(0).RsId == -100) ? null : idw_address.GetItem<SearchAddress>(0).RsId;
            if ((ls_road_name == null))
            {
                ll_road_id = 0;
            }
            else
            {
                ll_road_id = inv_road.of_getroadid(ls_road_name, ll_rt_id, ll_rs_id, ll_tc_id);
                if (ll_road_id > 0)
                {
                    lb_criteria_specified = true;
                }
                else
                {
                    ll_road_id = 0;
                }
            }
            ll_contract_no = idw_address.GetItem<SearchAddress>(0).ContractNo;
            if ((ll_contract_no == null) || ll_contract_no <= 0)
            {
                ll_contract_no = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }
            ls_rd_no = idw_address.GetItem<SearchAddress>(0).AdrRdNo.Trim();
            ls_rd_no = (ls_rd_no == null ? null : ls_rd_no.Trim());

            if ((ls_rd_no == null))
            {
                ls_rd_no = "";
            }
            else
            {
                lb_criteria_specified = true;
            }
            ll_dpid = idw_address.GetItem<SearchAddress>(0).DpId;
            if ((ll_dpid == null))
            {
                ll_dpid = 0;
            }
            else
            {
                lb_criteria_specified = true;
            }
            ll_rdSelect = idw_address.GetItem<SearchAddress>(0).RdContractSelect;
            if ((ll_rdSelect == null))
            {
                ll_rdSelect = 1;
            }
            else
            {
                lb_criteria_specified = true;
            }
            ls_surname = idw_contact.GetItem<AddressSearchPrimContact>(0).CustSurnameCompany;
            ls_surname = (ls_surname == null ? null : ls_surname.Trim());
            if ((ls_surname == null))
            {
                ls_surname = "";
            }
            else
            {
                lb_criteria_specified = true;
            }
            ls_firstname = idw_contact.GetItem<AddressSearchPrimContact>(0).CustInitials;// Trim(idw_contact.GetItemString(1, "cust_initials"));
            ls_firstname = (ls_firstname == null ? null : ls_firstname.Trim());
            if ((ls_firstname == null))
            {
                ls_firstname = "";
            }
            else
            {
                lb_criteria_specified = true;
            }
            if (lb_criteria_specified == false)
            {
                MessageBox.Show("Please specify at least one search criteria", "Search Address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idw_address.GetControlByName("adr_no").Focus();
                idw_contact.GetControlByName("cust_id").Focus();
                idw_address.Focus();
                return false;
            }
            adw_result.Retrieve(new object[] { ls_adr_num, ll_road_id, ll_sl_id, ll_tc_id, ll_contract_no, ls_rd_no, 
                ls_surname, ls_firstname, StaticVariables.gnv_app.of_getuserid(), 
                StaticVariables.gnv_app.of_get_securitymanager().of_get_componentid("Address"), ll_rdSelect, ll_dpid });
            if (adw_result.RowCount <= 0)
            {
                MessageBox.Show("There are no addresses that satisfy the search criteria entered.", "Unsuccessful Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }

        #endregion

        #region Events

        public void UTabAddressSearch_Enter(object sender, EventArgs e)
        {
            //!            itemReallyChanged = true;
        }

        public virtual void u_tab_address_search_getfocus(object sender, EventArgs e)
        {
            //?base.getfocus();
            tabpage_address.Focus();
        }

        public virtual void dw_address_itemfocuschanged(object sender, EventArgs e)
        {
            //?inv_dropdownsearch.pfc_ItemFocusChanged(row, dwo);
        }


        public virtual void dw_address_editchanged(object sender, EventArgs e)
        {
            roadNameChanged = true;
            dw_address_ue_editchanged();//dw_address.ue_editchanged(row, dwo, data);
            //?inv_dropdownsearch.pfc_EditChanged(row, dwo, data);
        }

        public virtual void dw_address_pfc_EditChanged(object sender, EventArgs e)
        {
            int ll_Found = -1;
            Metex.Windows.DataUserControl dw_child = dw_address.GetChild("sl_name");
            dw_child = new DDddwSuburbNames();
            string searchString = ((Control)sender).Text;
            if (string.IsNullOrEmpty(searchString))
            {
                return;
            }
            for (int i = 0; i < dw_child.RowCount; i++)
            {
                if (dw_child.GetValue<string>(i, "sl_name").Trim().ToUpper().StartsWith(searchString.ToUpper().Trim()))
                {
                    ll_Found = i;
                    break;
                }
            }
            if (ll_Found >= 0)
            {
                dw_child.SetCurrent(ll_Found);
            }
        }

        //! added in case ItemChanged is not triggered from "Street/Road Name"
        private void dw_address_validating(object sender, CancelEventArgs e)
        {
            if (roadNameChanged)
            {
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

                // TJB Feb 2009 RD7_0021
                // The road_name's TextChanged event is taken up with code to anticipate 
                // the name being entered.  When the user exits the field, the 
                // dw_address_validating function is called which calls this routine 
                // (dw_address_itemchanged), but dw_address.GetColumnName returns the 
                // name of the column the user has tabbed to, not the column just exited. 
                // The statement below overrides this so that the road type filtering 
                // can be done when the road name is changed.
                if (roadNameChanged)
                    column_name = "road_name";
                else
                    column_name = dw_address.GetColumnName();

                // TJB Jan 2009: Added column_name == "sl_name" condition to workaround/fix
                //               RDS Address screen startup unhandled exception (in debugging mode only!)
                if (column_name == "sl_name")
                {
                    //! selection changed but binded property not yet until data window loses focus
                    itemReallyChanged = false;
                    // this.dw_address.DataObject.AcceptText();
                    //! assign property for this simple combo box explicitly
                    (this.dw_address.DataObject.Current as SearchAddress).SlName =
                        string.Format("{0}", ((ComboBox)(dw_address.DataObject.GetControlByName("sl_name"))).Text);
                    itemReallyChanged = true;
                }
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
                if (column_name == "road_name" || column_name == "rt_id" ||
                    column_name == "rs_id" || column_name == "tc_id" || column_name == "sl_name")
                {
                    dw_address_ue_filter_dropdown();//dw_address.ue_filter_dropdown(row, dwo, data);
                }
                if (column_name == "rd_contract_select")
                {
                    BeginInvoke(new InvokeDelegate(parent_ue_set_new));//w_address_search.ue_set_new();
                }
            }
        }

        public virtual void dw_address_losefocus(object sender, EventArgs e)
        {
            dw_address.DataObject.AcceptText();
        }
        
        public virtual void dw_address_getfocus(object sender, EventArgs e)
        {
            FormBase lw_parent;
            //?dw_address.of_GetParentWindow(lw_parent);
            //!if (IsValid(lw_parent))
            if (this.Parent != null && this.Parent is WAddressSearch)
            {
                //!lw_parent.ue_criteria_gainfocus();
                ((WAddressSearch)(this.Parent)).ue_criteria_gainfocus();
            }
            is_active_tab = "address";
        }

        public virtual void dw_contact_losefocus(object sender, EventArgs e)
        {
            //?base.losefocus();
            dw_contact.DataObject.AcceptText();
        }

        public virtual void dw_contact_getfocus(object sender, EventArgs e)
        {
            FormBase lw_parent;
            //?dw_contact.of_GetParentWindow(lw_parent);
            //if (IsValid(lw_parent))
            //{
            //    lw_parent.ue_criteria_gainfocus();
            //}
            is_active_tab = "contact";
        }
        
        #endregion
    }
}
