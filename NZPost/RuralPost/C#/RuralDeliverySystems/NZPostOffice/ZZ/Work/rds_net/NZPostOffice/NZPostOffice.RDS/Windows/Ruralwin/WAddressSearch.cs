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
    // TJB  RPCR_026 Aug-2011: Fixups
    // Moved Sequence# column to right-most position (see DSearchAddressResultsV2b)
    // Changed indexes (-1) of columns to reflect moved seq column (see TitleText)
    //
    // TJB  RPCR_026  July-2011: Fixup
    // Moved Sequence number to 2nd column (old duplicate address indicator) and
    // re-instated 'MultiplePrime" indicator.
    // Moved code that sets the "MultiplePrime" indicator heer from the grid_CellFormatting
    // event handler to cb_search_clicked because the grid_CellFormatting handler didn't 
    // catch all the rows that should have been marked (not called for some??).
    //
    // TJB  RPCR_026  July-2011
    // Changed address results to display address sequence number
    // Added sort buttons cb_sortseq, cb_sortaddr

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

        // TJB  RPCR_026  July-2011
        private Button cb_sortseq;
        private Button cb_sortaddr;

        // TJB  RPCR_026  July-2011
        // Specify alternate ways to sort the addresses and set the default 
        // to sort by address.  See cb_sortseq_Click, cb_sortaddr_Click, 
        // dw_results_sort and cb_search_Click.  Done like this so sort order 
        // survives changes in search criteria.
        private string sortaddr_sortstring = "RoadName A, AdrNo A, AdrAlpha A, AdrUnit A";
        private string sortseq_sortstring = "SeqNum A, CustSurnameCompany A, CustInitials A";
        private string dw_results_sortstring = "";

        #endregion

        public WAddressSearch()
        {
            this.InitializeComponent();
            idw_results = dw_results;
            foreach (Control ctr in this.Controls)
                if (ctr is ToolStrip)
                    ctr.Visible = false;

            this.cb_cancel.Visible = false;
            this.cb_select.Visible = false;
            this.AcceptButton = this.cb_search;

            dw_results.RowFocusChanged += new EventHandler(dw_results_rowfocuschanged);
            // TJB  RD7_0042  Jan-2010: Added
            this.tab_criteria.GotFocus += new System.EventHandler(tab_criteria_gainfocus);

            dw_results_sortstring = sortaddr_sortstring;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                this.dw_results.DataObject = new DSearchAddressResultsV2b();

                ((DSearchAddressResultsV2b)dw_results.DataObject).CellDoubleClick += new EventHandler(dw_results_doubleclicked);
                ((DSearchAddressResultsV2b)dw_results.DataObject).CellClick += new EventHandler(dw_results_clicked);
                dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
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
            this.tab_criteria = new NZPostOffice.RDS.Windows.Ruralwin.UTabAddressSearch();
            this.cb_search = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_clear = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_open = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_new = new NZPostOffice.Shared.VisualComponents.UCb();
            this.dw_results = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_select = new NZPostOffice.Shared.VisualComponents.UCb();
            this.cb_cancel = new NZPostOffice.Shared.VisualComponents.UCb();
            this.st_count = new NZPostOffice.Shared.VisualComponents.USt();
            this.cb_print = new System.Windows.Forms.Button();
            this.cb_sortseq = new System.Windows.Forms.Button();
            this.cb_sortaddr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(8, 387);
            this.st_label.Size = new System.Drawing.Size(171, 16);
            this.st_label.Text = "w_address_search";
            // 
            // tab_criteria
            // 
            this.tab_criteria.Location = new System.Drawing.Point(8, 0);
            this.tab_criteria.Name = "tab_criteria";
            this.tab_criteria.SelectedIndex = 0;
            this.tab_criteria.Size = new System.Drawing.Size(588, 128);
            this.tab_criteria.TabIndex = 1;
            // 
            // cb_search
            // 
            this.cb_search.Location = new System.Drawing.Point(605, 19);
            this.cb_search.Name = "cb_search";
            this.cb_search.Size = new System.Drawing.Size(75, 23);
            this.cb_search.TabIndex = 2;
            this.cb_search.Text = "&Search";
            this.cb_search.Click += new System.EventHandler(this.cb_search_clicked);
            // 
            // cb_clear
            // 
            this.cb_clear.Location = new System.Drawing.Point(605, 46);
            this.cb_clear.Name = "cb_clear";
            this.cb_clear.Size = new System.Drawing.Size(75, 23);
            this.cb_clear.TabIndex = 3;
            this.cb_clear.Text = "&Clear";
            this.cb_clear.Click += new System.EventHandler(this.cb_clear_clicked);
            // 
            // cb_open
            // 
            this.cb_open.Location = new System.Drawing.Point(605, 131);
            this.cb_open.Name = "cb_open";
            this.cb_open.Size = new System.Drawing.Size(75, 23);
            this.cb_open.TabIndex = 5;
            this.cb_open.Tag = "ComponentPrivilege=C;ComponentPrivilege=R;ComponentPrivilege=M;ComponentPrivilege=R;";
            this.cb_open.Text = "&Open";
            this.cb_open.Click += new System.EventHandler(this.cb_open_clicked);
            // 
            // cb_new
            // 
            this.cb_new.Enabled = false;
            this.cb_new.Location = new System.Drawing.Point(605, 158);
            this.cb_new.Name = "cb_new";
            this.cb_new.Size = new System.Drawing.Size(75, 23);
            this.cb_new.TabIndex = 6;
            this.cb_new.Tag = "ComponentPrivilege=C;";
            this.cb_new.Text = "&New";
            this.cb_new.Click += new System.EventHandler(this.cb_new_clicked);
            // 
            // dw_results
            // 
            this.dw_results.DataObject = null;
            this.dw_results.FireConstructor = false;
            this.dw_results.Location = new System.Drawing.Point(8, 134);
            this.dw_results.Name = "dw_results";
            this.dw_results.Size = new System.Drawing.Size(588, 250);
            this.dw_results.TabIndex = 4;
            // 
            // cb_select
            // 
            this.cb_select.Enabled = false;
            this.cb_select.Location = new System.Drawing.Point(721, 194);
            this.cb_select.Name = "cb_select";
            this.cb_select.Size = new System.Drawing.Size(75, 23);
            this.cb_select.TabIndex = 0;
            this.cb_select.Text = "Select";
            this.cb_select.Visible = false;
            this.cb_select.Click += new System.EventHandler(this.cb_select_clicked);
            // 
            // cb_cancel
            // 
            this.cb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cb_cancel.Location = new System.Drawing.Point(692, 140);
            this.cb_cancel.Name = "cb_cancel";
            this.cb_cancel.Size = new System.Drawing.Size(75, 23);
            this.cb_cancel.TabIndex = 7;
            this.cb_cancel.Text = "Cancel";
            this.cb_cancel.Visible = false;
            this.cb_cancel.Click += new System.EventHandler(this.cb_cancel_clicked);
            // 
            // st_count
            // 
            this.st_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.st_count.Location = new System.Drawing.Point(388, 387);
            this.st_count.Name = "st_count";
            this.st_count.Size = new System.Drawing.Size(208, 16);
            this.st_count.TabIndex = 0;
            this.st_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_print
            // 
            this.cb_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_print.Location = new System.Drawing.Point(605, 362);
            this.cb_print.Name = "cb_print";
            this.cb_print.Size = new System.Drawing.Size(77, 23);
            this.cb_print.TabIndex = 7;
            this.cb_print.Text = "Print";
            this.cb_print.Click += new System.EventHandler(this.cb_print_clicked);
            // 
            // cb_sortseq
            // 
            this.cb_sortseq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_sortseq.Location = new System.Drawing.Point(605, 210);
            this.cb_sortseq.Name = "cb_sortseq";
            this.cb_sortseq.Size = new System.Drawing.Size(75, 23);
            this.cb_sortseq.TabIndex = 8;
            this.cb_sortseq.Text = "Sort Seq";
            this.cb_sortseq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_sortseq.UseVisualStyleBackColor = true;
            this.cb_sortseq.Click += new System.EventHandler(this.cb_sortseq_Click);
            // 
            // cb_sortaddr
            // 
            this.cb_sortaddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cb_sortaddr.Location = new System.Drawing.Point(607, 239);
            this.cb_sortaddr.Name = "cb_sortaddr";
            this.cb_sortaddr.Size = new System.Drawing.Size(75, 23);
            this.cb_sortaddr.TabIndex = 9;
            this.cb_sortaddr.Text = "Sort Address";
            this.cb_sortaddr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_sortaddr.UseVisualStyleBackColor = true;
            this.cb_sortaddr.Click += new System.EventHandler(this.cb_sortaddr_Click);
            // 
            // WAddressSearch
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cb_cancel;
            this.ClientSize = new System.Drawing.Size(690, 406);
            this.Controls.Add(this.cb_sortaddr);
            this.Controls.Add(this.cb_sortseq);
            this.Controls.Add(this.tab_criteria);
            this.Controls.Add(this.cb_search);
            this.Controls.Add(this.cb_clear);
            this.Controls.Add(this.cb_open);
            this.Controls.Add(this.cb_new);
            this.Controls.Add(this.st_count);
            this.Controls.Add(this.dw_results);
            this.Controls.Add(this.cb_print);
            this.Controls.Add(this.cb_select);
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "WAddressSearch";
            this.Text = "Address Search";
            this.Controls.SetChildIndex(this.cb_select, 0);
            this.Controls.SetChildIndex(this.cb_print, 0);
            this.Controls.SetChildIndex(this.dw_results, 0);
            this.Controls.SetChildIndex(this.st_count, 0);
            this.Controls.SetChildIndex(this.cb_new, 0);
            this.Controls.SetChildIndex(this.cb_open, 0);
            this.Controls.SetChildIndex(this.cb_clear, 0);
            this.Controls.SetChildIndex(this.cb_search, 0);
            this.Controls.SetChildIndex(this.tab_criteria, 0);
            this.Controls.SetChildIndex(this.cb_sortseq, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.Controls.SetChildIndex(this.cb_sortaddr, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

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
            // TJB  RPCR_026 Aug-2011: Fixups
            // Changed indexes (-1) of columns to reflect moved seq column
            int resultsRow = dw_results.GetRow();
            string sl = "";
            string st_no = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[resultsRow].Cells[1].Value.ToString().ToLower();
            string sr = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[resultsRow].Cells[2].Value.ToString();
            if (((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[resultsRow].Cells[3].Value != null 
                && ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[resultsRow].Cells[3].Value != "")
            {
                sl = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[resultsRow].Cells[3].Value.ToString();
            }
            string tc = ((DataEntityGrid)this.dw_results.GetControlByName("grid")).Rows[resultsRow].Cells[5].FormattedValue.ToString();
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
                MessageBox.Show("You do not have sufficient permission to search for  \n" 
                                 + "or view addresses"
                               , "Warning"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Exclamation);
            }
            else
            {
                inv_road = (NRoad)(StaticVariables.gnv_app.of_get_road_map());
                if (!((StaticMessage.PowerObjectParm == null)) 
                       && (StaticMessage.PowerObjectParm != null))
                {
                    if (StaticMessage.PowerObjectParm is WFrequencies2001)
                    {
                        lw_parent = (WFrequencies2001)StaticMessage.PowerObjectParm;
                    }
                }
                if ((lw_parent != null))
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
            if (StaticVariables.gnv_app.of_get_npadenabled() 
                && tab_criteria.of_getrdflag() == 1)
            {
                cb_new.Enabled = false;
            }
            else
            {
                cb_new.Enabled = true;
            }
            if (!(is_addr_perms.IndexOf('C') >= 0))
            {
                cb_new.Enabled = false;
            }
            cb_open.Enabled = false;
            il_contract_search_type = tab_criteria.of_getrdflag();
        }

        public override void open()
        {
            base.open();
            if ((is_addr_perms == null) 
                || !(is_addr_perms.IndexOf('R') >= 0))
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
                ls_perms += "C";

            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "R", false))
                ls_perms += "R";

            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "M", false))
                ls_perms += "M";

            if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_hasprivilege(ll_componentID, ll_regionID, "D", false))
                ls_perms += "D";
            
            if (ls_perms == "")
                ls_perms = null;
            return ls_perms;
        }

        public virtual void of_set_open(bool ab_on)
        {
            if (ab_on)
                cb_open.Enabled = true;
            else
                cb_open.Enabled = false;
        }

        public virtual void dw_results_ue_process_duplication()
        {
            string ls_prime_contact;
            int li_rc;
            int al_row = dw_results.GetRow();
            ls_prime_contact = dw_results.GetItem<SearchAddressResultsV2b>(al_row).PrimaryContract;
            if ((ls_prime_contact == null) || ls_prime_contact.Length <= 0)
            {
                li_rc = (MessageBox.Show("This address is recorded in the system multiple number of times.\n" 
                                           + "It is recommended that this duplicated entry be removed from \n" 
                                           + "the system immediately. \n\n" 
                                           + "Do you wish to delete this duplicated entry now?"
                                        , "Duplicated Address"
                                        , MessageBoxButtons.YesNo
                                        , MessageBoxIcon.Question
                                        , MessageBoxDefaultButton.Button1) 
                         == DialogResult.Yes ? 1 : 2);
                if (li_rc == 1)
                {
                    dw_results.DataObject.DeleteItemAt(al_row);
                    dw_results.Save();
                }
            }
            else
            {
                MessageBox.Show("This address is recorded in the system multiple number of times.\n" 
                                  + "Please transfer out/remove the primary contact residing on this record to\n" 
                                  + "before this duplicated address can be removed from the system."
                               , "Duplicated Address"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public virtual void dw_results_constructor()
        {
            //?base.constructor();
            dw_results.of_SetUpdateable(false);
            dw_results.of_SetRowSelect(true);
            dw_results.of_SetResize(true);
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
            if (!(this.IsMdiChild) && !(this.IsMdiContainer))
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
                //! added to refresh symbols in first two columns of the grid that are assigned in CellFormatting event handler of grid                
                ((Metex.Windows.DataEntityGrid)(dw_results.GetControlByName("grid"))).Refresh();
                dw_results.DataObject.BindingSource.CurrencyManager.Refresh();

                //((DSearchAddressResultsV2b)idw_results.DataObject).Focus();
                idw_results.Focus();
                idw_results.SelectRow(1, true);

                cb_open.Enabled = true;
                if (cb_open.Visible)
                {
                    this.cb_open.TabIndex = 5;
                    this.cb_select.TabIndex = 0;
                    this.AcceptButton = cb_open;
                }
                else
                {
                    this.cb_open.TabIndex = 0;
                    this.cb_select.TabIndex = 5;
                    this.AcceptButton = cb_select;
                }
            }
            else
            {
                cb_open.Enabled = false;
                this.cb_open.TabIndex = 0;
                this.cb_select.TabIndex = 5;
                this.AcceptButton = cb_search;
            }
            string rows_retrieved = (ll_rowCount == 1) ? " row retrieved" : " rows retrieved";
            st_count.Text = ll_rowCount.ToString() + rows_retrieved;
        }

        public virtual void ue_click_clear()
        {
            tab_criteria.of_clear_fields();
            dw_results.of_Reset();
            // TJB  RD7_0042 Jan-2010: Added inv_road.of_clear_fields
            inv_road.of_clear_fields();
            st_count.Text = "";
            of_set_open(false);
            this.AcceptButton = cb_search;
        }

        public virtual void tab_criteria_gainfocus(object sender, EventArgs e)
        {
            ue_criteria_gainfocus();
        }

        public virtual void ue_criteria_gainfocus()
        {
            this.AcceptButton = null;
            this.AcceptButton = cb_search;
        }

        public virtual void ue_set_new()
        {
            int ll_rows;
            int? ll_rd_flag;
            int? ll_contract_type;
            if (StaticVariables.gnv_app.of_get_npadenabled() 
                && tab_criteria.of_getrdflag() == 1)
            {
                cb_new.Enabled = false;
            }
            else
            {
                cb_new.Enabled = true;
            }
            if (!(is_addr_perms.IndexOf('C') >= 0))
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
                MessageBox.Show("Please search for an address before trying to select one."
                               , "Address Search"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ls_address = ls_address.TrimStart();
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
                MessageBox.Show("Please search for an address before trying to open one."
                               , "Address Search"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ll_AddressID = dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).AdrId;
            ll_custNo = dw_results.GetItem<SearchAddressResultsV2b>(ll_Row).CustId;
            ll_rdContractSelect = tab_criteria.of_getrdflag();
            ll_temp = RDSDataService.SelectAddressCount(ll_AddressID);
            if (ll_temp < 1)
            {
                MessageBox.Show("The selected address has been removed.  \n" 
                                  + "Please refresh the search results."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (e.KeyChar == 'I') //if (key == keyi!) {
            {
                this.ue_click_new();
            }
        }

        public virtual void cb_search_clicked(object sender, EventArgs e)
        {
            string multiplePrimeSymbol = new string(new char[] { (char)(byte)(0x2E) });

            this.Cursor = Cursors.WaitCursor;
            this.ue_click_search();
            dw_results_sort();
            // TJB  RPCR_026  July-2011: Fixup
            // Moved Sequence number to 2nd column (old duplicate address indicator) and
            // re-instated 'MultiplePrime" indicator.
            // Moved code that sets the "MultiplePrime" indicator heer from the grid_CellFormatting
            // event handler because it didn't catch all the rows (not called for some??).
            for (int nRow = 1; nRow < dw_results.RowCount; nRow++)
            {
                if (dw_results.GetItem<SearchAddressResultsV2b>(nRow - 1).RoadId == dw_results.GetItem<SearchAddressResultsV2b>(nRow).RoadId &&
                    dw_results.GetItem<SearchAddressResultsV2b>(nRow - 1).AdrNum == dw_results.GetItem<SearchAddressResultsV2b>(nRow).AdrNum &&
                    dw_results.GetItem<SearchAddressResultsV2b>(nRow - 1).TcId == dw_results.GetItem<SearchAddressResultsV2b>(nRow).TcId &&
                    dw_results.GetItem<SearchAddressResultsV2b>(nRow - 1).AdrRdNo == dw_results.GetItem<SearchAddressResultsV2b>(nRow).AdrRdNo &&
                    dw_results.GetItem<SearchAddressResultsV2b>(nRow - 1).AdrId == dw_results.GetItem<SearchAddressResultsV2b>(nRow).AdrId
                    )
                {
                    dw_results.GetItem<SearchAddressResultsV2b>(nRow).MultiplePrime = multiplePrimeSymbol;
                }
                else
                {
                    dw_results.GetItem<SearchAddressResultsV2b>(nRow).MultiplePrime = "";
                }                

            }
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
            dw_results.SelectRow(dw_results.GetRow() + 1, true);
            // TJB RD7_0042 Jan-2010: added
            if (cb_open.Enabled && cb_open.Visible)
            {
                this.cb_open.TabIndex = 5;
                this.cb_select.TabIndex = 0;
                this.AcceptButton = cb_open;
            }
            else
            {
                this.cb_open.TabIndex = 0;
                this.cb_select.TabIndex = 5;
                this.AcceptButton = cb_select;
            }
        }

        public virtual void dw_results_doubleclicked(object sender, EventArgs e)
        {
            dw_results.URdsDw_DoubleClick(sender, e);
            Cursor.Current = Cursors.WaitCursor;
            if (!(this.IsMdiChild) && !(this.IsMdiContainer))
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
            //sObjectAtPointer = dw_results.GetObjectAtPointer();
            sObjectAtPointer = dw_results.DataObject.GetColumnName(); 
             //if (Left(sObjectAtPointer, 9) == "indicator")
            if (sObjectAtPointer.Length > 9 
                && sObjectAtPointer.Substring(0, 9) 
                == "indicator")
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
                    MessageBox.Show("This is NOT a duplicate record but there is more than\n" 
                                      + "one primary customer attached to this address."
                                   , "Multiple Primary Customers"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // TJB  RPCR_026  July-2011: Added
        private void cb_sortseq_Click(object sender, EventArgs e)
        {
            dw_results_sortstring = sortseq_sortstring;
            dw_results_sort();
        }

        // TJB  RPCR_026  July-2011: Added
        private void cb_sortaddr_Click(object sender, EventArgs e)
        {
            dw_results_sortstring = sortaddr_sortstring;
            dw_results_sort();
        }

        // TJB  RPCR_026  July-2011: Added
        private void dw_results_sort()
        {
            dw_results.SuspendLayout();
            dw_results.DataObject.SortString = dw_results_sortstring;
            dw_results.DataObject.Sort<SearchAddressResultsV2b>();
            dw_results.ResumeLayout();
        }
        #endregion
    }
}