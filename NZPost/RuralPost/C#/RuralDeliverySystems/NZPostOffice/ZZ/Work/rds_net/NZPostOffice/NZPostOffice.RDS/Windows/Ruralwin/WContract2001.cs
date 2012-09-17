using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.Shared.Managers;
using System.Collections.Generic;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.RDS.Entity.Ruralwin;
using NZPostOffice.RDS.Windows.Ruralwin2;
using Metex.Core;
using Metex.Windows;
using NZPostOffice.Entity;


namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB 18-Sep-2012 Release fixup
    // Undid 'terminated contracts' bug fix as requested.
    // - it is now showing incorrectly for active (contracts that have not gone through a renewal)
    //
    // TJB  12-Apr-2012 RPI_032 Bug fix 
    // Fixed bug where terminated contracts shown as 'Active'
    //
    // TJB  12-Apr-2012 RPI_032
    // Fixed save of con_active_status value to fix displayed renewal status
    // when con_active_sequence is 1.  See tab_contract_selectionchanged.
    //
    // TJB  RPCR_026  July-2011
    // Major changes to the Fixed_assets tab.
    // Added sh_id and related functions to Fixed_assets tabpage.
    // Added/modified most fixed assets event handlers.
    // Changes idw_fixed_assets to dw_fixed_assets and removed idw_fixed_assets.
    //
    // TJB  RPCR_025  8-June-2011
    // Added Freight Allocations tab page and associated components
    // See also  DataControls/Ruraldw/DFreightAllocations
    //      and  Entity/Ruraldw/FreightAllocations
    //
    // TJB  Feb-2011 Special request
    // "Removed" Cust list last updated/printed fields from display
    // (Actually disabled and made not visible)
    //
    // TJB  Jan-2011  Sequencing Review
    // Add cb_seq button to address tab, and cb_seq_clicked event handler
    // - calls address sequencer
    //
    // TJB 13-Oct-2010: unimplemented fix for unhandled exception
    // when attempting to add allowances to an unactivated new contract
    // (see openAddAllowance)
    //
    // TJB RPCR_017 July-2010
    // Changed WAddAllowance significantly.  Obsolete version now WAddAllowance0.cs.
    // Added lookup of copntract effective date and pass to WAddAllowance.

    public class WContract2001 : WAncestorWindow
    {
        #region Define

        public int il_Contract_no;

        public int il_con_active_seq;

        public int il_count;

        public string is_tmp_rdno = String.Empty;

        public WContract2001 iw_Parent;

        public MSheet im_menu;

        public URdsDw idw_freight_allocations;

        public URdsDw idw_piece_rates;

        public URdsDw idw_article_count;

        public URdsDw idw_allowances;

        public URdsDw idw_types;

        public URdsDw idw_route_audit;

        public URdsDw idw_frequencies;

        public URdsDw idw_renewals;

        public URdsDw idw_addresses;

        public URdsDw idw_contract;

        public URdsDw idw_cmb;

        public bool ib_terminated;

        public bool ib_FromOwnRegion = false;

        public int il_TabAccess;

        public string is_Current_Tab = "Contract";

        public bool ib_Renewals = false;

        public bool ib_switchtab = true;

        public bool ib_startup = true;

        public bool ib_PieceRates = false;

        public bool ib_Customers = false;

        public bool ib_ArticalCounts = false;

        public bool ib_Frequencies = false;

        public bool ib_HighLiteRows;

        public string is_ErrorColumn = String.Empty;

        public int il_Row;

        public string is_OtherValEvent = String.Empty;

        public int il_Region;

        public int ilClickedRow;

        public string is_con_rd_ref = String.Empty;

        public int il_PrevRow = 0;

        public bool ib_Opening = true;

        public bool ib_custlist_changed = false;

        public DateTime? id_custlist_updated = null;

        private System.ComponentModel.IContainer components = null;

        public TabControl tab_contract;

        public TabPage tabpage_contract;

        public URdsDw dw_contract;

        public TabPage tabpage_customers;

        public URdsDw dw_contract_address;

        public Label st_custlist_print;

        public Label st_custlist_updated;

        public NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox em_custlist_printed;

        public NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox em_custlist_updated;

        public TabPage tabpage_renewals;

        public URdsDw dw_renewals;

        public TabPage tabpage_frequencies;

        public URdsDw dw_route_frequency;

        public TabPage tabpage_route_audit;

        public URdsDw dw_route_audit;

        public TabPage tabpage_types;

        public URdsDw dw_types;

        public TabPage tabpage_allowances;

        public URdsDw dw_contract_allowances;

        public TabPage tabpage_article_count;

        public URdsDw dw_artical_counts;

        public TabPage tabpage_piece_rates;

        public URdsDw dw_piece_rates;

        public TabPage tabpage_fixed_assets;

        public URdsDw dw_fixed_assets;

        public TabPage tabpage_cmb;

        public URdsDw dw_cmbs;

        public TabPage tabpage_freight_allocations;

        public URdsDw dw_freight_allocations;

        private Button SeqAddresses;

        private Label sh_id_t;

        private Metex.Windows.DataEntityCombo sh_id;

        private Label current_asset;

        #endregion
        private Button cb_fixed_assets_save;
        private Button cb_fixed_assets_delete;
        private Button cb_fixed_assets_add;
        private Label new_contract;
        private Label new_asset;
        private Button cb_add_old;

        // Remembers which tab page we were last on
        int oldTabIndex = -1;

        public WContract2001()
        {
            this.InitializeComponent();

            dw_contract.DataObject = new DContract();
            dw_contract.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            dw_contract_address.DataObject = new DAddressList();
            dw_contract_address.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_renewals.DataObject = new DRenewals();
            dw_renewals.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_route_audit.DataObject = new DRouteAuditListing();
            dw_route_audit.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_contract_allowances.DataObject = new DContractAllowancesV2();
            dw_contract_allowances.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_artical_counts.DataObject = new DContractArticalCounts();
            dw_artical_counts.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_fixed_assets.DataObject = new DContractFixedAssets();
            dw_fixed_assets.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_freight_allocations.DataObject = new DContractFreightAllocations();
            dw_freight_allocations.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_cmbs.DataObject = new DCmbAddressList();
            dw_cmbs.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_route_frequency.DataObject = new DRouteFrequency();
            dw_route_frequency.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_types.DataObject = new DTypesForContract();
            dw_types.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_piece_rates.DataObject = new DContractPieceRates();
            dw_piece_rates.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //Moved from InitializeComponent

            this.tab_contract.GotFocus += new System.EventHandler(this.tab_contract_GotFocus);
            this.tab_contract.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tab_contract_selectionchanging);
            this.tab_contract.SelectedIndexChanged += new System.EventHandler(this.tab_contract_selectionchanged);

            this.dw_contract.Constructor += new UserEventDelegate(dw_contract_constructor);
            this.dw_contract.URdsDwItemFocuschanged += new EventDelegate(dw_contract_itemfocuschanged);
            this.dw_contract.PfcPostUpdate += new UserEventDelegate(dw_contract_pfc_postupdate);
            this.dw_contract.WinValidate += new UserEventDelegate2(of_validate);
            this.dw_contract.DataObject.RetrieveEnd += new EventHandler(dw_contract_retrieveend);
            this.dw_contract.GotFocus += new System.EventHandler(this.dw_contract_getfocus);
            this.dw_contract.LostFocus += new System.EventHandler(this.dw_contract_losefocus);
            ((Button)(dw_contract.GetControlByName("bo_button"))).Click += new EventHandler(dw_contract_clicked);
            ((Button)(dw_contract.GetControlByName("lo_button"))).Click += new EventHandler(dw_contract_clicked);

            this.dw_contract_address.Constructor += new UserEventDelegate(dw_contract_address_constructor);
            this.dw_contract_address.PfcPreInsertRow += new UserEventDelegate1(dw_contract_address_pfc_preinsertrow);
            this.dw_contract_address.WinValidate += new UserEventDelegate2(of_validate);
            ((DAddressList)dw_contract_address.DataObject).CellDoubleClick += new EventHandler(dw_contract_address_doubleclicked);
            SeqAddresses.Click += new System.EventHandler(this.cb_seq_clicked);

            this.dw_renewals.Constructor += new UserEventDelegate(dw_renewals_constructor);
            this.dw_renewals.PfcPreInsertRow += new UserEventDelegate1(dw_renewals_pfc_preinsertrow);
            this.dw_renewals.PfcPreDeleteRow += new UserEventDelegate1(dw_renewals_pfc_predeleterow);
            this.dw_renewals.WinValidate += new UserEventDelegate2(of_validate);
            ((DRenewals)dw_renewals.DataObject).CellClick += new EventHandler(dw_renewals_clicked);
            ((DRenewals)dw_renewals.DataObject).CellDoubleClick += new EventHandler(dw_renewals_doubleclicked);

            this.dw_route_frequency.Constructor += new UserEventDelegate(dw_route_frequency_constructor);
            this.dw_route_frequency.PfcValidation += new UserEventDelegate1(dw_route_frequency_pfc_validation);
            this.dw_route_frequency.GotFocus += new System.EventHandler(this.dw_route_frequency_getfocus);
            ((DRouteFrequency)dw_route_frequency.DataObject).CellDoubleClick += new EventHandler(dw_route_frequency_doubleclicked);
            ((DRouteFrequency)dw_route_frequency.DataObject).CellClick += new EventHandler(dw_route_frequency_clicked);

            this.dw_route_audit.Constructor += new UserEventDelegate(dw_route_audit_constructor);
            ((DRouteAuditListing)dw_route_audit.DataObject).CellDoubleClick += new EventHandler(dw_route_audit_doubleclicked);
            ((DRouteAuditListing)dw_route_audit.DataObject).CellClick += new EventHandler(dw_route_audit_clicked);
            this.dw_route_audit.PfcInsertRow += new UserEventDelegate(dw_route_audit_pfc_preinsertrow);

            this.dw_types.Constructor += new UserEventDelegate(dw_types_constructor);
            this.dw_types.PfcValidation += new UserEventDelegate1(dw_types_pfc_validation);
            this.dw_types.WinValidate += new UserEventDelegate2(of_validate);

            this.dw_contract_allowances.Constructor += new UserEventDelegate(dw_contract_allowances_constructor);
            ((DContractAllowancesV2)dw_contract_allowances.DataObject).CellDoubleClick += new EventHandler(dw_contract_allowances_doubleclicked);
            this.dw_contract_allowances.PfcInsertRow = new UserEventDelegate(dw_contract_allowances_pfc_preinsertrow);
            this.dw_contract_allowances.PfcPreUpdate += new UserEventDelegate1(dw_contract_allowances_pfc_preupdate);
            this.dw_contract_allowances.WinValidate += new UserEventDelegate2(of_validate);

            // TJB  Release 7.1.3 fixups Aug 2010: Added
            this.dw_contract_allowances.PfcModify = new UserEventDelegate(dw_contract_allowances_pfc_modify);

            this.dw_artical_counts.Constructor += new UserEventDelegate(dw_artical_counts_constructor);
            this.dw_artical_counts.PfcPreInsertRow += new UserEventDelegate1(dw_artical_counts_pfc_preinsertrow);
            this.dw_artical_counts.WinValidate += new UserEventDelegate2(of_validate);
            this.dw_artical_counts.DoubleClick += new System.EventHandler(this.dw_artical_counts_doubleclicked);
            this.dw_artical_counts.Click += new System.EventHandler(this.dw_artical_counts_clicked);
            this.dw_artical_counts.LostFocus += new System.EventHandler(this.dw_artical_counts_losefocus);

            this.dw_piece_rates.Constructor += new UserEventDelegate(dw_piece_rates_constructor);
            this.dw_piece_rates.WinValidate += new UserEventDelegate2(of_validate);
            ((DContractPieceRates)dw_piece_rates.DataObject).CellDoubleClick += new EventHandler(dw_piece_rates_doubleclicked);
            ((DContractPieceRates)dw_piece_rates.DataObject).CellClick += new EventHandler(dw_piece_rates_clicked);

            this.dw_fixed_assets.Constructor += new UserEventDelegate(dw_fixed_assets_Constructor);
            this.dw_fixed_assets.PfcValidation += new UserEventDelegate1(dw_fixed_assets_PfcValidation);
            this.dw_fixed_assets.PfcInsertRow += new UserEventDelegate(dw_fixed_assets_PfcInsertRow);
            this.dw_fixed_assets.PfcUpdate += new UserEventDelegate1(dw_fixed_assets_PfcUpdate);
            this.dw_fixed_assets.PfcPreDeleteRow += new UserEventDelegate1(dw_fixed_assets_PfcPreDeleteRow);
            this.dw_fixed_assets.PfcPreUpdate += new UserEventDelegate1(dw_fixed_assets_PfcPreUpdate);
            this.dw_fixed_assets.PfcPostUpdate += new UserEventDelegate(dw_fixed_assets_PfcPostUpdate);

            this.dw_fixed_assets.PfcPreInsertRow += new UserEventDelegate1(dw_fixed_assets_PfcPreInsertRow);

            this.cb_fixed_assets_add.Click += new System.EventHandler(this.cb_fixed_assets_add_Click);
            this.cb_fixed_assets_delete.Click += new System.EventHandler(this.cb_fixed_assets_delete_Click);
            this.cb_fixed_assets_save.Click += new System.EventHandler(this.cb_fixed_assets_save_Click);

            this.dw_cmbs.Constructor += new UserEventDelegate(dw_cmbs_constructor);
            ((DCmbAddressList)dw_cmbs.DataObject).CellDoubleClick += new EventHandler(dw_cmbs_doubleclicked);
            this.dw_cmbs.PfcDeleteRow += new UserEventDelegate(dw_cmbs_pfc_deleterow);
            this.dw_cmbs.PfcInsertRow = new UserEventDelegate(dw_cmbs_pfc_preinsertrow);
            this.dw_cmbs.PfcPreDeleteRow += new UserEventDelegate1(dw_cmbs_pfc_predeleterow);
            this.dw_cmbs.WinValidate += new UserEventDelegate2(of_validate);
            this.dw_cmbs.GotFocus += new System.EventHandler(this.dw_cmbs_getfocus);
            ((DCmbAddressList)dw_cmbs.DataObject).CellClick += new EventHandler(dw_cmbs_clicked);

            // TJB  RPCR_025  June-2011
            this.dw_freight_allocations.Constructor += new UserEventDelegate(dw_freight_allocations_constructor);
            this.dw_freight_allocations.Validating += new System.ComponentModel.CancelEventHandler(this.dw_freight_allocations_validating);

            this.em_custlist_updated.TextChanged += new System.EventHandler(this.em_custlist_updated_modified);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            base.OnHandleCreated(e);
        }

        private void InitializeDropdown()
        {
            sh_id.AssignDropdownType<DDddwStripHeight>();
        }

        #region Form Events & Methods
        public override void pfc_preopen()
        {
            //  TJB  SR4659  July 2005
            //  Added references to CMB datawindow
            int? li_Region;
            string ls_Title;
            NRdsMsg lnv_msg;
            NCriteria lvNCriteria;
            this.of_set_componentname("Contract");
            iw_Parent = this;
            im_menu = this.m_sheet;
            lnv_msg = StaticMessage.PowerObjectParm as NRdsMsg;
            lvNCriteria = lnv_msg.of_getcriteria();
            il_Contract_no = System.Convert.ToInt32(lvNCriteria.of_getcriteria("contract_no"));
            if (il_Contract_no > -(1))
            {
                idw_contract.Retrieve(new object[] { il_Contract_no });
                ls_Title = "Contract: (" + il_Contract_no.ToString() + ") " + idw_contract.GetItem<Contract>(0).ConTitle;
                li_Region = idw_contract.GetItem<Contract>(0).RegionId;
                int? tmp_seq = idw_contract.GetItem<Contract>(0).ConActiveSequence;
                il_con_active_seq = (tmp_seq == null) ? 0 : (int)tmp_seq;
                this.of_set_regionid(li_Region);
                dw_fixed_assets.of_set_regionid(li_Region);
                idw_piece_rates.of_set_regionid(li_Region);
                idw_article_count.of_set_regionid(li_Region);
                idw_allowances.of_set_regionid(li_Region);
                idw_types.of_set_regionid(li_Region);
                idw_route_audit.of_set_regionid(li_Region);
                idw_frequencies.of_set_regionid(li_Region);
                idw_renewals.of_set_regionid(li_Region);
                idw_addresses.of_set_regionid(li_Region);
                idw_contract.of_set_regionid(li_Region);
                idw_cmb.of_set_regionid(li_Region);
                idw_freight_allocations.of_set_regionid(li_Region);

                this.Text = ls_Title;
                if (!string.IsNullOrEmpty(this.Text))
                {
                    this.Text = this.Text.Replace("\r\n", "");
                }
            }
            else
            {
                ls_Title = "Contract: <New Contract>";
                idw_contract.InsertRow(0);
                //?idw_contract.Modify("ct_key.dddw.useasborder=yes");
                DataUserControl lds_user_Contract_Types;
                DataUserControl dwc_contract_type;
                lds_user_Contract_Types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
                lds_user_Contract_Types.SortString = "ct_key A";
                lds_user_Contract_Types.Sort<FilteredContractTypes>();
                dwc_contract_type = idw_contract.GetChild("ct_key");
                dwc_contract_type.Reset();
                for (int i = 0; i < lds_user_Contract_Types.RowCount; i++)
                {
                    DddwContractTypes l_temprow = new DddwContractTypes();
                    l_temprow.CtKey = lds_user_Contract_Types.GetItem<FilteredContractTypes>(i).CtKey;
                    l_temprow.ContractType = lds_user_Contract_Types.GetItem<FilteredContractTypes>(i).ContractType;
                    l_temprow.CtRdRefMandatory = lds_user_Contract_Types.GetItem<FilteredContractTypes>(i).CtRdRefMandatory;
                    l_temprow.MarkClean();
                    dwc_contract_type.AddItem<DddwContractTypes>(l_temprow);
                }
                idw_contract.GetItem<Contract>(0).CtKey = 1;
                ((Metex.Windows.DataEntityCombo)idw_contract.GetControlByName("ct_key")).DropDownStyle = ComboBoxStyle.DropDownList;
                this.Text = ls_Title;
                if (!string.IsNullOrEmpty(this.Text))
                {
                    this.Text = this.Text.Replace("\r\n", "");
                }
            }
            this.of_set_custlist_data();
            idw_contract.URdsDw_GetFocus(null, null);
            idw_contract.GetControlByName("con_title").Focus();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // Disable standard CRUD RMB menuitems, regardless of access rights
            // This is driven by business requirements
            idw_addresses.of_set_deletepriv(false);
            idw_frequencies.of_set_deletepriv(false);
            idw_route_audit.of_set_deletepriv(false);
            idw_renewals.of_set_createpriv(false);
            idw_article_count.of_set_deletepriv(false);
            idw_article_count.of_set_createpriv(false);
            idw_piece_rates.of_set_deletepriv(false);
            idw_piece_rates.of_set_createpriv(false);
            idw_contract.of_set_createpriv(false);
            idw_contract.of_set_deletepriv(false);
            idw_allowances.of_set_deletepriv(false);
            idw_allowances.of_set_modifypriv(false);
            idw_cmb.of_set_createpriv(true);
            idw_cmb.of_set_deletepriv(true);
            idw_cmb.of_set_modifypriv(true);
            //  TJB June-2011
            //  This was an attempt to have the 'Save' toolbar button displayed
            //  automatically (didn't work), but when enabled, caused the fetch to
            //  fail (in URdsDw) with an 'unknown entity type' error when nothing 
            //  was returned from the SQL select query?????
            //idw_freight_allocations.of_set_createpriv(true);

            BeginInvoke(new delegateInvoke(idw_contractInvoke));
            this.tab_contract_selectionchanging(new object(), new EventArgs());
            this.tab_contract_selectionchanged(new object(), new EventArgs());
        }

        private delegate void delegateInvoke();

        public virtual void idw_contractInvoke()
        {
            idw_contract.URdsDw_GetFocus(null, null);
            this.ue_set_security();
        }

        public virtual void ue_set_security()
        {
            ib_Opening = false;
        }

        public override int pfc_save()
        {
            base.pfc_save();
            //  TJB  SR4657  June05
            //  Fixed detection of changed updated date (it failed 
            //    if the original was NULL and the user closed the 
            //    window without moving out of the field first).

            if (of_custlist_changed())
            {
                int li_reply = (MessageBox.Show("Do you wish to save the new customer list updated date?"
                                           , "Question"
                                           , MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                            == DialogResult.Yes ? 1 : 2);
                if (li_reply == 1)
                {
                    of_update_custlist();
                }
                else
                {
                    this.em_custlist_updated.Text = id_custlist_updated.ToString();
                }
            }
            ib_custlist_changed = false;
            return 1;
        }

        public override void close()
        {
            int thisIndex = tab_contract.SelectedIndex;

            string thisTabName = tab_contract.TabPages[thisIndex].Text.ToLower().Trim();
            string oldTabName = tab_contract.TabPages[oldTabIndex].Text.ToLower().Trim();

            base.close();
            //  TJB  SR4657  June05
            //  Fixed detection of changed updated date (it failed 
            //    if the original was NULL and the user closed the 
            //    window without moving out of the field first).

            if (of_custlist_changed())
            {
                int li_reply = (MessageBox.Show("Do you wish to save the new customer list updated date?"
                                           , "Customer List"
                                           , MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                             == DialogResult.Yes ? 1 : 2);
                if (li_reply == 1)
                {
                    of_update_custlist();
                }
            }
        }

        public override int closequery()
        {
            return base.closequery();
        }

        #endregion

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_contract = new System.Windows.Forms.TabControl();
            this.tabpage_contract = new System.Windows.Forms.TabPage();
            this.dw_contract = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_customers = new System.Windows.Forms.TabPage();
            this.SeqAddresses = new System.Windows.Forms.Button();
            this.dw_contract_address = new NZPostOffice.RDS.Controls.URdsDw();
            this.st_custlist_print = new System.Windows.Forms.Label();
            this.st_custlist_updated = new System.Windows.Forms.Label();
            this.em_custlist_printed = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.em_custlist_updated = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();
            this.tabpage_renewals = new System.Windows.Forms.TabPage();
            this.dw_renewals = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_frequencies = new System.Windows.Forms.TabPage();
            this.dw_route_frequency = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_route_audit = new System.Windows.Forms.TabPage();
            this.dw_route_audit = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_types = new System.Windows.Forms.TabPage();
            this.dw_types = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_allowances = new System.Windows.Forms.TabPage();
            this.dw_contract_allowances = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_article_count = new System.Windows.Forms.TabPage();
            this.dw_artical_counts = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_piece_rates = new System.Windows.Forms.TabPage();
            this.dw_piece_rates = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_fixed_assets = new System.Windows.Forms.TabPage();
            this.sh_id_t = new System.Windows.Forms.Label();
            this.sh_id = new Metex.Windows.DataEntityCombo();
            this.dw_fixed_assets = new NZPostOffice.RDS.Controls.URdsDw();
            this.current_asset = new System.Windows.Forms.Label();
            this.new_asset = new System.Windows.Forms.Label();
            this.new_contract = new System.Windows.Forms.Label();
            this.cb_fixed_assets_save = new System.Windows.Forms.Button();
            this.cb_fixed_assets_delete = new System.Windows.Forms.Button();
            this.cb_fixed_assets_add = new System.Windows.Forms.Button();
            this.tabpage_cmb = new System.Windows.Forms.TabPage();
            this.dw_cmbs = new NZPostOffice.RDS.Controls.URdsDw();
            this.tabpage_freight_allocations = new System.Windows.Forms.TabPage();
            this.dw_freight_allocations = new NZPostOffice.RDS.Controls.URdsDw();
            this.cb_add_old = new System.Windows.Forms.Button();
            this.tab_contract.SuspendLayout();
            this.tabpage_contract.SuspendLayout();
            this.tabpage_customers.SuspendLayout();
            this.tabpage_renewals.SuspendLayout();
            this.tabpage_frequencies.SuspendLayout();
            this.tabpage_route_audit.SuspendLayout();
            this.tabpage_types.SuspendLayout();
            this.tabpage_allowances.SuspendLayout();
            this.tabpage_article_count.SuspendLayout();
            this.tabpage_piece_rates.SuspendLayout();
            this.tabpage_fixed_assets.SuspendLayout();
            this.dw_fixed_assets.SuspendLayout();
            this.tabpage_cmb.SuspendLayout();
            this.tabpage_freight_allocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // st_label
            // 
            this.st_label.Location = new System.Drawing.Point(3, 352);
            this.st_label.Text = "w_contract2001";
            // 
            // tab_contract
            // 
            this.tab_contract.Controls.Add(this.tabpage_contract);
            this.tab_contract.Controls.Add(this.tabpage_customers);
            this.tab_contract.Controls.Add(this.tabpage_renewals);
            this.tab_contract.Controls.Add(this.tabpage_frequencies);
            this.tab_contract.Controls.Add(this.tabpage_route_audit);
            this.tab_contract.Controls.Add(this.tabpage_types);
            this.tab_contract.Controls.Add(this.tabpage_allowances);
            this.tab_contract.Controls.Add(this.tabpage_article_count);
            this.tab_contract.Controls.Add(this.tabpage_piece_rates);
            this.tab_contract.Controls.Add(this.tabpage_fixed_assets);
            this.tab_contract.Controls.Add(this.tabpage_cmb);
            this.tab_contract.Controls.Add(this.tabpage_freight_allocations);
            this.tab_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tab_contract.Location = new System.Drawing.Point(3, 4);
            this.tab_contract.Multiline = true;
            this.tab_contract.Name = "tab_contract";
            this.tab_contract.SelectedIndex = 0;
            this.tab_contract.Size = new System.Drawing.Size(558, 344);
            this.tab_contract.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tab_contract.TabIndex = 1;
            this.tab_contract.Tag = "ComponentName=Contract;";
            // 
            // tabpage_contract
            // 
            this.tabpage_contract.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_contract.Controls.Add(this.dw_contract);
            this.tabpage_contract.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_contract.Location = new System.Drawing.Point(4, 40);
            this.tabpage_contract.Name = "tabpage_contract";
            this.tabpage_contract.Size = new System.Drawing.Size(550, 300);
            this.tabpage_contract.TabIndex = 0;
            this.tabpage_contract.Tag = "ComponentName=Contract;";
            this.tabpage_contract.Text = "Contract";
            this.tabpage_contract.Visible = false;
            // 
            // dw_contract
            // 
            this.dw_contract.DataObject = null;
            this.dw_contract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_contract.FireConstructor = false;
            this.dw_contract.Location = new System.Drawing.Point(0, 0);
            this.dw_contract.Name = "dw_contract";
            this.dw_contract.Size = new System.Drawing.Size(550, 300);
            this.dw_contract.TabIndex = 2;
            // 
            // tabpage_customers
            // 
            this.tabpage_customers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_customers.Controls.Add(this.SeqAddresses);
            this.tabpage_customers.Controls.Add(this.dw_contract_address);
            this.tabpage_customers.Controls.Add(this.st_custlist_print);
            this.tabpage_customers.Controls.Add(this.st_custlist_updated);
            this.tabpage_customers.Controls.Add(this.em_custlist_printed);
            this.tabpage_customers.Controls.Add(this.em_custlist_updated);
            this.tabpage_customers.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_customers.Location = new System.Drawing.Point(4, 40);
            this.tabpage_customers.Name = "tabpage_customers";
            this.tabpage_customers.Size = new System.Drawing.Size(550, 300);
            this.tabpage_customers.TabIndex = 1;
            this.tabpage_customers.Tag = "ComponentName=Address;";
            this.tabpage_customers.Text = "Addresses";
            this.tabpage_customers.Visible = false;
            // 
            // SeqAddresses
            // 
            this.SeqAddresses.Location = new System.Drawing.Point(429, 273);
            this.SeqAddresses.Name = "SeqAddresses";
            this.SeqAddresses.Size = new System.Drawing.Size(116, 23);
            this.SeqAddresses.TabIndex = 5;
            this.SeqAddresses.Text = "Sequence Addresses";
            this.SeqAddresses.UseVisualStyleBackColor = true;
            // 
            // dw_contract_address
            // 
            this.dw_contract_address.DataObject = null;
            this.dw_contract_address.FireConstructor = false;
            this.dw_contract_address.Location = new System.Drawing.Point(3, 7);
            this.dw_contract_address.Name = "dw_contract_address";
            this.dw_contract_address.Size = new System.Drawing.Size(539, 263);
            this.dw_contract_address.TabIndex = 1;
            // 
            // st_custlist_print
            // 
            this.st_custlist_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_custlist_print.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_custlist_print.Location = new System.Drawing.Point(10, 252);
            this.st_custlist_print.Name = "st_custlist_print";
            this.st_custlist_print.Size = new System.Drawing.Size(149, 19);
            this.st_custlist_print.TabIndex = 2;
            this.st_custlist_print.Text = "Customer list last printed";
            this.st_custlist_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st_custlist_print.Visible = false;
            // 
            // st_custlist_updated
            // 
            this.st_custlist_updated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.st_custlist_updated.ForeColor = System.Drawing.SystemColors.WindowText;
            this.st_custlist_updated.Location = new System.Drawing.Point(5, 276);
            this.st_custlist_updated.Name = "st_custlist_updated";
            this.st_custlist_updated.Size = new System.Drawing.Size(165, 19);
            this.st_custlist_updated.TabIndex = 3;
            this.st_custlist_updated.Text = "Customer list last updated";
            this.st_custlist_updated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.st_custlist_updated.Visible = false;
            // 
            // em_custlist_printed
            // 
            this.em_custlist_printed.EditMask = "";
            this.em_custlist_printed.Enabled = false;
            this.em_custlist_printed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.em_custlist_printed.ForeColor = System.Drawing.SystemColors.WindowText;
            this.em_custlist_printed.Location = new System.Drawing.Point(178, 252);
            this.em_custlist_printed.Mask = "00/00/0000";
            this.em_custlist_printed.Name = "em_custlist_printed";
            this.em_custlist_printed.Size = new System.Drawing.Size(66, 20);
            this.em_custlist_printed.TabIndex = 3;
            this.em_custlist_printed.Text = "00000000";
            this.em_custlist_printed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.em_custlist_printed.Value = null;
            this.em_custlist_printed.Visible = false;
            // 
            // em_custlist_updated
            // 
            this.em_custlist_updated.EditMask = "";
            this.em_custlist_updated.Enabled = false;
            this.em_custlist_updated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.em_custlist_updated.ForeColor = System.Drawing.SystemColors.WindowText;
            this.em_custlist_updated.Location = new System.Drawing.Point(178, 276);
            this.em_custlist_updated.Mask = "00/00/0000";
            this.em_custlist_updated.Name = "em_custlist_updated";
            this.em_custlist_updated.Size = new System.Drawing.Size(66, 20);
            this.em_custlist_updated.TabIndex = 4;
            this.em_custlist_updated.Text = "00000000";
            this.em_custlist_updated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.em_custlist_updated.Value = null;
            this.em_custlist_updated.Visible = false;
            // 
            // tabpage_renewals
            // 
            this.tabpage_renewals.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_renewals.Controls.Add(this.dw_renewals);
            this.tabpage_renewals.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_renewals.Location = new System.Drawing.Point(4, 40);
            this.tabpage_renewals.Name = "tabpage_renewals";
            this.tabpage_renewals.Size = new System.Drawing.Size(550, 300);
            this.tabpage_renewals.TabIndex = 2;
            this.tabpage_renewals.Tag = "ComponentName=Renewal;";
            this.tabpage_renewals.Text = "Renewals";
            this.tabpage_renewals.Visible = false;
            // 
            // dw_renewals
            // 
            this.dw_renewals.DataObject = null;
            this.dw_renewals.FireConstructor = false;
            this.dw_renewals.Location = new System.Drawing.Point(3, 7);
            this.dw_renewals.Name = "dw_renewals";
            this.dw_renewals.Size = new System.Drawing.Size(542, 276);
            this.dw_renewals.TabIndex = 1;
            // 
            // tabpage_frequencies
            // 
            this.tabpage_frequencies.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_frequencies.Controls.Add(this.dw_route_frequency);
            this.tabpage_frequencies.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_frequencies.Location = new System.Drawing.Point(4, 40);
            this.tabpage_frequencies.Name = "tabpage_frequencies";
            this.tabpage_frequencies.Size = new System.Drawing.Size(550, 300);
            this.tabpage_frequencies.TabIndex = 3;
            this.tabpage_frequencies.Tag = "ComponentName=Frequency;";
            this.tabpage_frequencies.Text = "Frequencies";
            this.tabpage_frequencies.Visible = false;
            // 
            // dw_route_frequency
            // 
            this.dw_route_frequency.DataObject = null;
            this.dw_route_frequency.FireConstructor = false;
            this.dw_route_frequency.Location = new System.Drawing.Point(5, 7);
            this.dw_route_frequency.Name = "dw_route_frequency";
            this.dw_route_frequency.Size = new System.Drawing.Size(539, 274);
            this.dw_route_frequency.TabIndex = 1;
            // 
            // tabpage_route_audit
            // 
            this.tabpage_route_audit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_route_audit.Controls.Add(this.dw_route_audit);
            this.tabpage_route_audit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_route_audit.Location = new System.Drawing.Point(4, 40);
            this.tabpage_route_audit.Name = "tabpage_route_audit";
            this.tabpage_route_audit.Size = new System.Drawing.Size(550, 300);
            this.tabpage_route_audit.TabIndex = 4;
            this.tabpage_route_audit.Tag = "ComponentName=Route Audit;";
            this.tabpage_route_audit.Text = "Route Audit";
            this.tabpage_route_audit.Visible = false;
            // 
            // dw_route_audit
            // 
            this.dw_route_audit.DataObject = null;
            this.dw_route_audit.FireConstructor = false;
            this.dw_route_audit.Location = new System.Drawing.Point(5, 7);
            this.dw_route_audit.Name = "dw_route_audit";
            this.dw_route_audit.Size = new System.Drawing.Size(539, 274);
            this.dw_route_audit.TabIndex = 1;
            // 
            // tabpage_types
            // 
            this.tabpage_types.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_types.Controls.Add(this.dw_types);
            this.tabpage_types.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_types.Location = new System.Drawing.Point(4, 40);
            this.tabpage_types.Name = "tabpage_types";
            this.tabpage_types.Size = new System.Drawing.Size(550, 300);
            this.tabpage_types.TabIndex = 5;
            this.tabpage_types.Tag = "ComponentName=Contract Type;";
            this.tabpage_types.Text = "Types";
            this.tabpage_types.Visible = false;
            // 
            // dw_types
            // 
            this.dw_types.DataObject = null;
            this.dw_types.FireConstructor = false;
            this.dw_types.Location = new System.Drawing.Point(5, 7);
            this.dw_types.Name = "dw_types";
            this.dw_types.Size = new System.Drawing.Size(539, 274);
            this.dw_types.TabIndex = 1;
            // 
            // tabpage_allowances
            // 
            this.tabpage_allowances.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_allowances.Controls.Add(this.dw_contract_allowances);
            this.tabpage_allowances.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_allowances.Location = new System.Drawing.Point(4, 40);
            this.tabpage_allowances.Name = "tabpage_allowances";
            this.tabpage_allowances.Size = new System.Drawing.Size(550, 300);
            this.tabpage_allowances.TabIndex = 6;
            this.tabpage_allowances.Tag = "ComponentName=Allowance;";
            this.tabpage_allowances.Text = "Allowances";
            this.tabpage_allowances.Visible = false;
            // 
            // dw_contract_allowances
            // 
            this.dw_contract_allowances.AutoScroll = true;
            this.dw_contract_allowances.DataObject = null;
            this.dw_contract_allowances.FireConstructor = false;
            this.dw_contract_allowances.Location = new System.Drawing.Point(5, 7);
            this.dw_contract_allowances.Name = "dw_contract_allowances";
            this.dw_contract_allowances.Size = new System.Drawing.Size(539, 274);
            this.dw_contract_allowances.TabIndex = 1;
            // 
            // tabpage_article_count
            // 
            this.tabpage_article_count.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_article_count.Controls.Add(this.dw_artical_counts);
            this.tabpage_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_article_count.Location = new System.Drawing.Point(4, 40);
            this.tabpage_article_count.Name = "tabpage_article_count";
            this.tabpage_article_count.Size = new System.Drawing.Size(550, 300);
            this.tabpage_article_count.TabIndex = 7;
            this.tabpage_article_count.Tag = "ComponentName=Article Count;";
            this.tabpage_article_count.Text = "Article Count";
            this.tabpage_article_count.Visible = false;
            // 
            // dw_artical_counts
            // 
            this.dw_artical_counts.DataObject = null;
            this.dw_artical_counts.FireConstructor = false;
            this.dw_artical_counts.Location = new System.Drawing.Point(5, 7);
            this.dw_artical_counts.Name = "dw_artical_counts";
            this.dw_artical_counts.Size = new System.Drawing.Size(540, 290);
            this.dw_artical_counts.TabIndex = 1;
            // 
            // tabpage_piece_rates
            // 
            this.tabpage_piece_rates.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_piece_rates.Controls.Add(this.dw_piece_rates);
            this.tabpage_piece_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_piece_rates.Location = new System.Drawing.Point(4, 40);
            this.tabpage_piece_rates.Name = "tabpage_piece_rates";
            this.tabpage_piece_rates.Size = new System.Drawing.Size(550, 300);
            this.tabpage_piece_rates.TabIndex = 8;
            this.tabpage_piece_rates.Tag = "ComponentName=Piece Rate;";
            this.tabpage_piece_rates.Text = "Piece Rates";
            this.tabpage_piece_rates.Visible = false;
            // 
            // dw_piece_rates
            // 
            this.dw_piece_rates.DataObject = null;
            this.dw_piece_rates.FireConstructor = false;
            this.dw_piece_rates.Location = new System.Drawing.Point(5, 7);
            this.dw_piece_rates.Name = "dw_piece_rates";
            this.dw_piece_rates.Size = new System.Drawing.Size(539, 274);
            this.dw_piece_rates.TabIndex = 1;
            // 
            // tabpage_fixed_assets
            // 
            this.tabpage_fixed_assets.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_fixed_assets.Controls.Add(this.sh_id_t);
            this.tabpage_fixed_assets.Controls.Add(this.sh_id);
            this.tabpage_fixed_assets.Controls.Add(this.dw_fixed_assets);
            this.tabpage_fixed_assets.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_fixed_assets.Location = new System.Drawing.Point(4, 40);
            this.tabpage_fixed_assets.Name = "tabpage_fixed_assets";
            this.tabpage_fixed_assets.Size = new System.Drawing.Size(550, 300);
            this.tabpage_fixed_assets.TabIndex = 9;
            this.tabpage_fixed_assets.Tag = "ComponentName=Fixed Asset;";
            this.tabpage_fixed_assets.Text = "Fixed Assets";
            // 
            // sh_id_t
            // 
            this.sh_id_t.Location = new System.Drawing.Point(351, 16);
            this.sh_id_t.Name = "sh_id_t";
            this.sh_id_t.Size = new System.Drawing.Size(62, 18);
            this.sh_id_t.TabIndex = 2;
            this.sh_id_t.Text = "Strip Height";
            this.sh_id_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sh_id
            // 
            this.sh_id.AutoRetrieve = true;
            this.sh_id.Cursor = System.Windows.Forms.Cursors.Default;
            this.sh_id.DisplayMember = "ShHeight";
            this.sh_id.DropDownWidth = 240;
            this.sh_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.sh_id.Location = new System.Drawing.Point(420, 16);
            this.sh_id.Name = "sh_id";
            this.sh_id.Size = new System.Drawing.Size(67, 21);
            this.sh_id.TabIndex = 4;
            this.sh_id.Value = null;
            this.sh_id.ValueMember = "ShHeight";
            this.sh_id.LostFocus += new System.EventHandler(this.sh_id_LostFocus);
            this.sh_id.SelectedIndexChanged += new System.EventHandler(this.sh_id_SelectedIndexChanged);
            this.sh_id.Click += new System.EventHandler(this.sh_id_Click);
            // 
            // dw_fixed_assets
            // 
            this.dw_fixed_assets.Controls.Add(this.cb_add_old);
            this.dw_fixed_assets.Controls.Add(this.current_asset);
            this.dw_fixed_assets.Controls.Add(this.new_asset);
            this.dw_fixed_assets.Controls.Add(this.new_contract);
            this.dw_fixed_assets.Controls.Add(this.cb_fixed_assets_save);
            this.dw_fixed_assets.Controls.Add(this.cb_fixed_assets_delete);
            this.dw_fixed_assets.Controls.Add(this.cb_fixed_assets_add);
            this.dw_fixed_assets.DataObject = null;
            this.dw_fixed_assets.FireConstructor = false;
            this.dw_fixed_assets.Location = new System.Drawing.Point(5, 7);
            this.dw_fixed_assets.Name = "dw_fixed_assets";
            this.dw_fixed_assets.Size = new System.Drawing.Size(539, 280);
            this.dw_fixed_assets.TabIndex = 1;
            // 
            // current_asset
            // 
            this.current_asset.Location = new System.Drawing.Point(476, 204);
            this.current_asset.Name = "current_asset";
            this.current_asset.Size = new System.Drawing.Size(57, 20);
            this.current_asset.TabIndex = 0;
            this.current_asset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.current_asset.Visible = false;
            // 
            // new_asset
            // 
            this.new_asset.Location = new System.Drawing.Point(476, 230);
            this.new_asset.Name = "new_asset";
            this.new_asset.Size = new System.Drawing.Size(57, 20);
            this.new_asset.TabIndex = 4;
            this.new_asset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.new_asset.Visible = false;
            // 
            // new_contract
            // 
            this.new_contract.Location = new System.Drawing.Point(476, 258);
            this.new_contract.Name = "new_contract";
            this.new_contract.Size = new System.Drawing.Size(40, 20);
            this.new_contract.TabIndex = 5;
            this.new_contract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.new_contract.Visible = false;
            // 
            // cb_fixed_assets_save
            // 
            this.cb_fixed_assets_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.cb_fixed_assets_save.Location = new System.Drawing.Point(272, 54);
            this.cb_fixed_assets_save.Name = "cb_fixed_assets_save";
            this.cb_fixed_assets_save.Size = new System.Drawing.Size(47, 20);
            this.cb_fixed_assets_save.TabIndex = 3;
            this.cb_fixed_assets_save.Text = "Save";
            this.cb_fixed_assets_save.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cb_fixed_assets_save.UseVisualStyleBackColor = true;
            this.cb_fixed_assets_save.Visible = false;
            // 
            // cb_fixed_assets_delete
            // 
            this.cb_fixed_assets_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.cb_fixed_assets_delete.Location = new System.Drawing.Point(219, 54);
            this.cb_fixed_assets_delete.Name = "cb_fixed_assets_delete";
            this.cb_fixed_assets_delete.Size = new System.Drawing.Size(47, 20);
            this.cb_fixed_assets_delete.TabIndex = 2;
            this.cb_fixed_assets_delete.Text = "Delete";
            this.cb_fixed_assets_delete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cb_fixed_assets_delete.UseVisualStyleBackColor = true;
            this.cb_fixed_assets_delete.Visible = false;
            // 
            // cb_fixed_assets_add
            // 
            this.cb_fixed_assets_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.cb_fixed_assets_add.Location = new System.Drawing.Point(166, 54);
            this.cb_fixed_assets_add.Name = "cb_fixed_assets_add";
            this.cb_fixed_assets_add.Size = new System.Drawing.Size(47, 20);
            this.cb_fixed_assets_add.TabIndex = 1;
            this.cb_fixed_assets_add.Text = "Add";
            this.cb_fixed_assets_add.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cb_fixed_assets_add.UseVisualStyleBackColor = true;
            this.cb_fixed_assets_add.Visible = false;
            // 
            // tabpage_cmb
            // 
            this.tabpage_cmb.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_cmb.Controls.Add(this.dw_cmbs);
            this.tabpage_cmb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_cmb.Location = new System.Drawing.Point(4, 40);
            this.tabpage_cmb.Name = "tabpage_cmb";
            this.tabpage_cmb.Size = new System.Drawing.Size(550, 300);
            this.tabpage_cmb.TabIndex = 10;
            this.tabpage_cmb.Tag = "ComponentName=Contract;";
            this.tabpage_cmb.Text = "CMBs";
            this.tabpage_cmb.Visible = false;
            // 
            // dw_cmbs
            // 
            this.dw_cmbs.DataObject = null;
            this.dw_cmbs.FireConstructor = false;
            this.dw_cmbs.Location = new System.Drawing.Point(8, 8);
            this.dw_cmbs.Name = "dw_cmbs";
            this.dw_cmbs.Size = new System.Drawing.Size(529, 280);
            this.dw_cmbs.TabIndex = 1;
            this.dw_cmbs.Text = "CMBs";
            // 
            // tabpage_freight_allocations
            // 
            this.tabpage_freight_allocations.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabpage_freight_allocations.Controls.Add(this.dw_freight_allocations);
            this.tabpage_freight_allocations.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tabpage_freight_allocations.Location = new System.Drawing.Point(4, 40);
            this.tabpage_freight_allocations.Name = "tabpage_freight_allocations";
            this.tabpage_freight_allocations.Size = new System.Drawing.Size(550, 300);
            this.tabpage_freight_allocations.TabIndex = 11;
            this.tabpage_freight_allocations.Tag = "ComponentName=Freight Allocations;";
            this.tabpage_freight_allocations.Text = "Freight Allocations";
            this.tabpage_freight_allocations.Visible = false;
            // 
            // dw_freight_allocations
            // 
            this.dw_freight_allocations.DataObject = null;
            this.dw_freight_allocations.FireConstructor = false;
            this.dw_freight_allocations.Location = new System.Drawing.Point(5, 7);
            this.dw_freight_allocations.Name = "dw_freight_allocations";
            this.dw_freight_allocations.Size = new System.Drawing.Size(539, 274);
            this.dw_freight_allocations.TabIndex = 1;
            this.dw_freight_allocations.Text = "Freight";
            // 
            // cb_add_old
            // 
            this.cb_add_old.Location = new System.Drawing.Point(170, 9);
            this.cb_add_old.Name = "cb_add_old";
            this.cb_add_old.Size = new System.Drawing.Size(144, 20);
            this.cb_add_old.TabIndex = 6;
            this.cb_add_old.Text = "Add Unassigned Asset";
            this.cb_add_old.UseVisualStyleBackColor = true;
            this.cb_add_old.Click += new System.EventHandler(this.cb_add_old_Click);
            // 
            // WContract2001
            // 
            this.ClientSize = new System.Drawing.Size(567, 368);
            this.Controls.Add(this.tab_contract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(1, 6);
            this.MaximizeBox = false;
            this.Name = "WContract2001";
            this.Controls.SetChildIndex(this.tab_contract, 0);
            this.Controls.SetChildIndex(this.st_label, 0);
            this.tab_contract.ResumeLayout(false);
            this.tabpage_contract.ResumeLayout(false);
            this.tabpage_customers.ResumeLayout(false);
            this.tabpage_customers.PerformLayout();
            this.tabpage_renewals.ResumeLayout(false);
            this.tabpage_frequencies.ResumeLayout(false);
            this.tabpage_route_audit.ResumeLayout(false);
            this.tabpage_types.ResumeLayout(false);
            this.tabpage_allowances.ResumeLayout(false);
            this.tabpage_article_count.ResumeLayout(false);
            this.tabpage_piece_rates.ResumeLayout(false);
            this.tabpage_fixed_assets.ResumeLayout(false);
            this.dw_fixed_assets.ResumeLayout(false);
            this.tabpage_cmb.ResumeLayout(false);
            this.tabpage_freight_allocations.ResumeLayout(false);
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

        #region Methods
        public virtual WContract2001 of_getparent()
        {
            return this;
        }

        public virtual bool of_frequency_unique(int arow)
        {
            bool bReturn = true;
            int? lFrequency;
            int lRow;
            string sDeliveryDays;
            if (idw_frequencies.RowCount > 1)
            {
                lFrequency = idw_frequencies.GetItem<RouteFrequency>(arow).SfKey.GetValueOrDefault();
                sDeliveryDays = idw_frequencies.GetItem<RouteFrequency>(arow).RfDeliveryDays;
                lRow = idw_frequencies.Find(new KeyValuePair<string, object>("sf_key", lFrequency.ToString()), new KeyValuePair<string, object>("rf_delivery_days", sDeliveryDays));//lRow = idw_frequencies.Find( "sf_key = " + lFrequency.ToString() + " and rf_delivery_days = \'" + sDeliveryDays + '\'' ).Length);
                if (lRow == arow)
                {
                    if (lRow == idw_frequencies.RowCount - 1)
                    {
                        lRow = 0;
                    }
                    else
                    {
                        for (int i = arow + 1; i < idw_frequencies.RowCount; i++)
                        {
                            lRow = -1;
                            if (idw_frequencies.GetItem<RouteFrequency>(i).SfKey == lFrequency && idw_frequencies.GetItem<RouteFrequency>(i).RfDeliveryDays == sDeliveryDays)
                            {
                                lRow = i;
                                break;
                            }
                        }
                    }
                }
                if (lRow > 0)
                {
                    MessageBox.Show("This frequency has already been defined"
                                    , this.Text
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bReturn = false;
                }
            }
            return bReturn;
        }

        public virtual int of_get_outlet(string aoutlet, string acode)
        {
            string sOutlet;
            int? lRegionId;
            int? ll_Outlet;
            ((Button)(idw_contract.GetControlByName(acode + "_button"))).Image 
                                  = global::NZPostOffice.Shared.Properties.Resources.PCKLSTDN;

            sOutlet = idw_contract.GetValue<string>(0, "con_" + aoutlet + "_office_name");
            StaticVariables.gnv_app.of_set_componenttoopen(this.of_get_componentname());
            StaticVariables.gnv_app.of_get_parameters().integerparm = this.of_get_regionid();
            Cursor.Current = Cursors.WaitCursor;

            StaticMessage.StringParm = sOutlet;
            WQsOutlet w_qs_outlet = new WQsOutlet();
            w_qs_outlet.ShowDialog();
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                ((DContract)idw_contract.DataObject).SetValue(0, "con_" + aoutlet + "_office", 
                                                         StaticVariables.gnv_app.of_get_parameters().longparm);
                ((DContract)idw_contract.DataObject).SetValue(0, "con_" + aoutlet + "_office_name", 
                                                         StaticVariables.gnv_app.of_get_parameters().stringparm);
                ((DContract)idw_contract.DataObject).SetValue(0, "con_" + aoutlet + "_office_type", 
                                                         StaticVariables.gnv_app.of_get_parameters().miscstringparm);
                ll_Outlet = StaticVariables.gnv_app.of_get_parameters().longparm;
                if (aoutlet.ToLower() == "base")
                {
                    /*select region_id into :lRegionId from outlet where outlet_id = :ll_Outlet;*/
                    lRegionId = RDSDataService.GetOutletRegionId(ll_Outlet);
                    idw_contract.GetItem<Contract>(0).RegionId = lRegionId;
                    this.of_set_regionid(lRegionId);
                }
                ((DContract)dw_contract.DataObject).BindingSource.CurrencyManager.Refresh();
            }
            ((Button)(idw_contract.GetControlByName(acode + "_button"))).Image 
                                    = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;

            return 0;
        }

        public virtual bool of_validate_frequencies()
        {
            int ll_RowCount;
            int ll_Row;
            int lNumDays;
            int lSFKey;
            int lrow;
            string sDaysDelivery;
            string ls_ErrorColumn = "";
            Metex.Windows.DataUserControl dwChild;
            ll_RowCount = idw_frequencies.RowCount;
            for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
            {
                if ((idw_frequencies.GetItem<RouteFrequency>(ll_Row).ContractNo == null))
                {
                    idw_frequencies.GetItem<RouteFrequency>(ll_Row).ContractNo = il_Contract_no;
                }
                if (!((idw_frequencies.GetItem<RouteFrequency>(ll_Row).SfKey) == null) 
                    && idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays == "NNNNNNN")
                {
                    MessageBox.Show("Please select the days that this frequency is delivered"
                                    , this.Text
                                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ls_ErrorColumn = "rf_monday";
                }
                else
                {
                    idw_frequencies.GetItem<RouteFrequency>(ll_Row).RfDeliveryDays 
                                   = idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays;
                }
                if ((idw_frequencies.GetItem<RouteFrequency>(ll_Row).SfKey == null) 
                    && idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays != "NNNNNNN")
                {
                    MessageBox.Show("Please select a frequency"
                                    , this.Text
                                    , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ls_ErrorColumn = "sf_key";
                }
                sDaysDelivery = idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays;
                idw_frequencies.GetItem<RouteFrequency>(ll_Row).RfDeliveryDays = sDaysDelivery;
                if (of_frequency_unique(ll_Row))
                {
                    lNumDays = idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcNumdeldays.GetValueOrDefault();
                    lSFKey = idw_frequencies.GetItem<RouteFrequency>(ll_Row).SfKey.GetValueOrDefault();

                    dwChild = new DDddwStandardFrequency();
                    dwChild.BindingSource.DataSource = ((Metex.Windows.DataGridViewEntityComboColumn)(((Metex.Windows.DataEntityGrid)(idw_frequencies.GetControlByName("grid"))).Columns["sf_key"])).DataSource;
                    lrow = dwChild.Find("sf_key", lSFKey);//lrow = dwChild.Find( "sf_key=" + lSFKey).ToString().Length);
                    if (lrow > 0)
                    {
                        if (dwChild.GetItem<DddwStandardFrequency>(lrow).SfDaysWeek.GetValueOrDefault() != lNumDays)
                        {
                            MessageBox.Show("The delivery days selected does not equal the number of days \n" 
                                            + "specified for this frequency"
                                            , this.Text
                                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ls_ErrorColumn = "rf_monday";
                        }
                    }
                }
                else
                {
                    ls_ErrorColumn = "rf_monday";
                }
                if ((idw_frequencies.GetItem<RouteFrequency>(ll_Row).Distance == null))
                {
                    idw_frequencies.GetItem<RouteFrequency>(ll_Row).Distance = 0;
                }
            }
            idw_frequencies.AcceptText();
            return ls_ErrorColumn.Length == 0;
        }

        public virtual bool of_validate_fixed_assets()
        {
            int nRow;
            int nRows;
            string sReturn = "";

            nRows = dw_fixed_assets.RowCount;
            for (nRow = 0; nRow < nRows; nRow++)
            {
                if ((dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo == null))
                {
                    dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo = il_Contract_no;
                }
                if (dw_fixed_assets.uf_not_entered(nRow, "FaFixedAssetNo", "fixed asset number"))
                {
                    sReturn = "fa_fixed_asset_num";
                    break;
                }
                if (dw_fixed_assets.uf_not_unique(nRow, "FaFixedAssetNo", "fixed asset number"))
                {
                    sReturn = "fa_fixed_asset_num";
                    break;
                }
                if (dw_fixed_assets.uf_not_entered(nRow, "FatId", "fixed asset type"))
                {
                    sReturn = "fat_id";
                    break;
                }
                // TJB  RPCR_026 July-2011
                // Fixed asset types no longer need to be unique
                //if (dw_fixed_assets.uf_not_unique(nRow, "FatId", "fixed asset type"))
                //{
                //    sReturn = "fat_id";
                //    break;
                //}
                dw_fixed_assets.uf_setrowsecurity();
            }

            is_ErrorColumn = sReturn;
            return is_ErrorColumn.Length == 0;
        }

        public override bool of_validate()
        {
            if (!(of_validate_contract(0)))
            {
                return false;
            }
            if (!(of_validate_frequencies()))
            {
                return false;
            }
            if (!(of_validate_fixed_assets()))
            {
                return false;
            }
            if (!(of_validate_types()))
            {
                return false;
            }
            if (!(of_validate_articlecounts()))
            {
                return false;
            }
            return true;
        }

        public virtual bool of_validate_types()
        {
            string sReturn = "";
            int lActionCode = 0;
            int ll_Row;
            ll_Row = idw_types.GetNextModified(-1);
            while (ll_Row > -1)
            {
                if ((idw_types.GetItem<TypesForContract>(ll_Row).ContractNo == null))
                {
                    idw_types.GetItem<TypesForContract>(ll_Row).ContractNo = il_Contract_no;
                }
                if (idw_types.uf_not_entered(ll_Row, "ct_key", "contract type"))
                {
                    sReturn = "ct_key";
                    idw_types.SetCurrent(ll_Row);
                    idw_types.SetColumn(sReturn);
                    return false;
                }
                if (idw_types.uf_not_unique(ll_Row, "ct_key", "contract type"))
                {
                    sReturn = "ct_key";
                    idw_types.SetCurrent(ll_Row);
                    idw_types.SetColumn(sReturn);
                }
                ll_Row = idw_types.GetNextModified(ll_Row);
                if (sReturn.Length > 0)
                {
                    return false;
                }
            }
            return sReturn.Length == 0;
        }

        public virtual bool of_validate_articlecounts()
        {
            int ll_Row;
            int ll_RowCount;
            ll_RowCount = idw_article_count.RowCount;
            for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
            {
                if ((idw_article_count.GetItem<ContractArticalCounts>(ll_Row).ContractNo == null))
                {
                    idw_article_count.GetItem<ContractArticalCounts>(ll_Row).ContractNo = il_Contract_no;
                }
            }
            idw_article_count.AcceptText();
            return true;
        }

        // TJB  RPCR_025  June-2011: Added
        public virtual bool of_validate_freight_allocations()
        {
            if (idw_freight_allocations.RowCount < 0)
                return true;

            int nRow = idw_freight_allocations.GetRow();

            // If the active indicator is not set, there's no need to validate.
            int? nActiveInd = idw_freight_allocations.GetItem<FreightAllocations>(nRow).FrActiveInd;
            if ((nActiveInd == null) || (nActiveInd == 0))
                return true;

            int? nContract = idw_freight_allocations.GetItem<FreightAllocations>(nRow).ContractNo;
            if (nContract == null || (int)nContract != il_Contract_no)
            {
                MessageBox.Show("Incorrect contract number.  Please close without saving, re-open \n"
                                + "the contract, and re-enter the freight allocation details.\n"
                                , "Freight allocations processing error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int? nTotalPct = idw_freight_allocations.GetItem<FreightAllocations>(nRow).TotalAlloc;
            if (nTotalPct == null || nTotalPct != 100)
            {
                MessageBox.Show("The total allocation must equal 100%.   \n"
                                + "Please correct. \n"
                                , "Error"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            idw_freight_allocations.AcceptText();
            return true;
        }
        
        public virtual int of_display_breakdown(int al_row)
        {
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            if (idw_piece_rates.RowCount != 0)
            {
                if (al_row != -1)
                {
                    lnv_Criteria.of_addcriteria("Contract_no", il_Contract_no);
                    lnv_Criteria.of_addcriteria("prs_key", idw_piece_rates.GetItem<ContractPieceRates>(al_row).PrsKey.GetValueOrDefault());
                    lnv_Criteria.of_addcriteria("prd_date", idw_piece_rates.GetItem<ContractPieceRates>(al_row).PrdDate.GetValueOrDefault().Date);
                    lnv_msg.of_addcriteria(lnv_Criteria);

                    StaticMessage.PowerObjectParm = lnv_msg;
                    WPieceRateBreakdown w_piece_rate_breakdown = new WPieceRateBreakdown();
                    w_piece_rate_breakdown.MdiParent = StaticVariables.MainMDI;
                    w_piece_rate_breakdown.Show();
                }
            }
            return 1;
        }

        public virtual int of_set_custlist_data()
        {
            //  TWC - 10/09/2003 
            //  Populate with the date in the contract table for cust_list_printed 
            //  and cust_list_updated
            // 
            //  TJB  SR4596
            //  This appears to be an unimplemented change Tin Chan 
            //  started.  The columns cust_list_printed and cust_list_updated
            //  don't exist in the contract table! 
            //  [Note: Related to SR4657]
            DateTime? ld_cust_printed;
            DateTime? ld_cust_updated;
            /*select cust_list_printed from contract 
             * where contract_no = :il_Contract_no  */
            ld_cust_printed = RDSDataService.GetContractCustListPrinted(il_Contract_no);
            if (!((ld_cust_printed == null)))
            {
                this.em_custlist_printed.Text = string.Format("{0:dd/MM/yyyy}", ld_cust_printed);
            }
            else
            {
                this.em_custlist_printed.Text = "00/00/0000";
            }
            /*select cust_list_updated from contract 
             * where contract_no = :il_Contract_no  */
            ld_cust_updated = RDSDataService.GetContractCustListUpdated(il_Contract_no);
            if (!((ld_cust_updated == null)))
            {
                this.em_custlist_updated.Text = string.Format("{0:dd/MM/yyyy}", ld_cust_updated);
            }
            else
            {
                this.em_custlist_updated.Text = "00/00/0000";
            }
            id_custlist_updated = ld_cust_updated;
            return 1;
        }

        public virtual int of_update_custlist()
        {
            DateTime ld_custlist_updated;
            ld_custlist_updated = System.Convert.ToDateTime(this.em_custlist_updated.Text);
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            //  TJB  SR4657  June05
            //  Enable update (uncomment) do update
            //UPDATE contract 
            //   set cust_list_updated = :ld_custlist_updated 
            // where contract_no = :il_contract_no using SQLCA;
            RDSDataService.UpdateContractCustListUpdated(ld_custlist_updated, il_Contract_no, ref SQLCode, ref SQLErrText);
            if (SQLCode != 0)
            {
                //?rollback;
                MessageBox.Show("There was a problem updating the Customer List Updated date"
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //?commit;
                id_custlist_updated = ld_custlist_updated;
            }
            return 1;
        }

        public virtual int of_terminate(int? al_con_no, bool ab_result)
        {
            DateTime? dtNull;
            int lContractNo;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            lContractNo = idw_contract.GetItem<Contract>(0).ContractNo.GetValueOrDefault();
            if (!ab_result)
            {
                dtNull = null;
                idw_contract.GetItem<Contract>(0).ConDateTerminated = dtNull;
                ib_terminated = false;
            }
            else
            {
                ib_terminated = true;
                idw_contract.GetControlByName("con_date_terminated").BackColor = System.Drawing.SystemColors.Control;
                //idw_contract.(7)DataControl["con_date_terminated"].BackColor =\'76585128\'");
                //?idw_contract.Modify("con_date_terminated.Border=\'0\'");
                idw_contract.GetControlByName("con_date_terminated").Enabled = false;
                //idw_contract.Modify("con_date_terminated.Protect=\'1\'");
                //?idw_contract.Modify("con_date_terminated.Pointer=\'Arrow!\'");
                DateTime tod;
                tod = DateTime.Today;
                int? ln;
                ln = al_con_no;
                //INSERT INTO contract_cust_transfer 
                //      (from_contract_no, to_contract_no, transfer_date)
                //VALUES
                //      ( :lContractNo, :ln, :tod );
                RDSDataService.InsertContractCustTransfer(lContractNo, ln, tod, ref SQLCode, ref SQLErrText);
                if (SQLCode < -(1))
                {
                    MessageBox.Show(SQLErrText
                                   , "Failure logging transfers"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return 1;
        }

        public virtual int of_display_allowance(int al_row)
        {
            //  TJB  SR4596  Apr-2005   NEW
            //  Display detail for selected allowance
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            if (idw_allowances.RowCount != 0)
            {
                if (al_row != -1)
                {
                    if (StaticVariables.window is WAllowanceBreakdown)
                    {
                        ((WAllowanceBreakdown)StaticVariables.window).Close();
                        StaticVariables.window = null;
                    }
                    lnv_Criteria.of_addcriteria("Contract_no", il_Contract_no);
                    lnv_Criteria.of_addcriteria("alt_key", idw_allowances.GetItem<ContractAllowancesV2>(al_row).AltKey);
                    lnv_Criteria.of_addcriteria("allowance_row", al_row);
                    lnv_msg.of_addcriteria(lnv_Criteria);
                    StaticMessage.PowerObjectParm = lnv_msg;
                    WAllowanceBreakdown w_allowance_breakdown = new WAllowanceBreakdown();

                    // TJB  RPCR_017 July-2010: Bug fix 
                    // Set StaticVariables.window to this window so WAllowanceBreakdown
                    // can tell its parent to reset.
                    //StaticVariables.window = w_allowance_breakdown;
                    StaticVariables.window = this;
                    w_allowance_breakdown.MdiParent = StaticVariables.MainMDI;
                    w_allowance_breakdown.Show();
                }
            }
            return SUCCESS;
        }

        public virtual bool of_custlist_changed()
        {
            //  TJB  SR4657  June05     - New -
            //  Test to see if the customer list updated field
            //  has changed.
            //  Return
            //     TRUE   if it has
            //     FLASE  if it hasn't
            int li_reply;
            DateTime ld_check_update = DateTime.MinValue;
            if (this.em_custlist_updated.Text != null)
            {
                DateTime.TryParse(this.em_custlist_updated.Text, out ld_check_update);
                if (ld_check_update == DateTime.MinValue)
                {
                    ld_check_update = new DateTime(1900, 1, 1);
                }
            }
            if ((id_custlist_updated == null))
            {
                id_custlist_updated = new DateTime(1900, 1, 1);
            }
            if (id_custlist_updated != ld_check_update)
                return true;
            else
                return false;
        }

        // TJB  RPCR_026  June-2011: Added
        public virtual int of_get_nextsequence(string sequencename)
        {
            int nReturn;
            int nNextValue;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            if (StaticVariables.gnv_app.of_isempty(sequencename))
            {
                nReturn = -(1);
            }
            else
            {
                /*select next_value into :nNextValue from id_codes where sequence_name = :sequencename ;*/
                nNextValue = RDSDataService.GetIdCodesNextValue(sequencename, ref SQLCode, ref SQLErrText);
                if (SQLCode != 0)
                {
                    /*insert into id_codes(sequence_name, next_value) values (:sequencename, 2) ;*/
                    RDSDataService.InsertIdCodes(sequencename);
                    nReturn = 1;
                }
                else
                {
                    nReturn = nNextValue;
                    /*UPDATE id_codes set next_value = :nNextValue + 1 where sequence_name = :sequencename ;*/
                    RDSDataService.UpdateIdCodes(nNextValue, sequencename);
                }
            }
            //commit;
            return nReturn;
        }

        public virtual int wf_contract_town(int ai_contract_no)
        {
            //  TJB  SR4659  July 2005
            int li_tc_id;
            //select first(tc_id) into :li_tc_id from address 
            // where contract_no = :ai_contract_no;
            li_tc_id = RDSDataService.GetAddressTcIdFirst(ai_contract_no);
            return li_tc_id;
        }

        public virtual int wf_town_postcode(int ai_tc_id)
        {
            //  TJB  SR4659  July 2005
            int li_postcode_id;
            //SELECT max(pc.post_code_id) INTO :li_postcode_id 
            //  FROM post_code pc, towncity tc 
            // WHERE tc.tc_id = :ai_tc_id 
            //   AND pc.post_mail_town = tc.tc_name;
            li_postcode_id = RDSDataService.GetPostCodePostCodeIdMax(ai_tc_id);
            return li_postcode_id;
        }

        public virtual string wf_town_rd(int al_tcid, int al_pcid)
        {
            //  TJB  SR4659  July 2005
            string ls_tmp_rdno;
            //SELECT first address.adr_rd_no INTO :ls_tmp_rdno FROM address 
            // WHERE tc_id = :al_tcid AND post_code_id = :al_pcid;
            ls_tmp_rdno = RDSDataService.GetAddressAdrRdNoFirst1(al_tcid, al_pcid);
            return ls_tmp_rdno;
        }

        public virtual int wf_set_cmb_privs()
        {
            //  TJB  Release 6.8.9 fixup  Nov 2005  NEW
            //  Modified from wf_set_cmb_toolbar: set the relevant
            //  privileges rather than manipulating the toolbar items
            //  directly.  u_rds_dw.uf_setToolbar will set the toolbar
            //  items on or off according to the privileges set.
            //  Modified from wf_set_cmb_toolbar: set the relevant
            //  privileges rather than manipulating the toolbar items
            //  directly.  u_rds_dw.uf_setToolbar will set the toolbar
            //  items on or off according to the privileges set.
            // 
            //  Changed button semantics.  Turn the 'save' button on 
            //  if there are any rows as well as if there are any 
            //  deleted rows. It wasn't being turned on if the user 
            //  inserted a row, only if one (or more) was deleted.
            int ll_rows;
            int ll_dels;
            int? ll_cmbid;
            ll_rows = idw_cmb.RowCount;
            ll_dels = idw_cmb.DataObject.DeletedCount;

            if (ll_rows == 1)
            {
                ll_cmbid = idw_cmb.GetItem<CmbAddressList>(0).CmbId;
                if ((ll_cmbid == null) || ll_cmbid == 0)
                    ll_rows = 0;
            }
            if (ll_rows > 0)
                idw_cmb.of_set_deletepriv(true);
            else
                idw_cmb.of_set_deletepriv(false);

            if (ll_dels > 0 || ll_rows > 0)
                idw_cmb.of_set_modifypriv(true);
            else
                idw_cmb.of_set_modifypriv(false);

            idw_cmb.of_set_createpriv(true);

            return SUCCESS;
        }

        public virtual void wf_set_freight_allocations_toolbar()
        {
            MSheet lm_menu;
            lm_menu = this.m_sheet;

            lm_menu._m_updatedatabase.Visible = true;
            lm_menu.m_updatedatabase.Visible = true;
            lm_menu.m_updatedatabase.Enabled = true;
        }

        public virtual bool of_validate_contract(int arow)
        {
            string sReturn = "";
            string sContractType;
            string sTitle = "Contract: <New Contract>";
            int lContractType;
            Metex.Windows.DataUserControl dwChild;
            string sManRDRef = "";
            int lCount;
            int lRGCode;
            string sFrozenInd;
            int lContractNo;
            int lCustCount = 0;
            DateTime? dtNull;
            int ll_ct_key;
            int ll_found;
            int ll_rc;
            string ls_custCount;

            int SQLCode = 0;
            string SQLErrText = string.Empty;
            WCustomerTransfer wTransfer;
            if (idw_contract.GetControlByName("rg_code").Focused)
            {
                idw_contract.GetControlByName("con_title").Focus();
            }
            dwChild = idw_contract.GetChild("ct_key");
            ll_ct_key = idw_contract.GetItem<Contract>(0).CtKey.GetValueOrDefault();
            if (ll_ct_key > 0)
            {
                ll_found = dwChild.Find("ct_key", ll_ct_key);
                if (ll_found > 0)
                {
                    sManRDRef = dwChild.GetItem<DddwContractTypes>(ll_found).CtRdRefMandatory;
                }
            }
            if (idw_contract.uf_not_entered(arow, "ConTitle", "contract title"))
            {
                sReturn = "con_title";
            }
            else if (idw_contract.uf_not_unique(arow, "ConTitle", "contract title"))
            {
                sReturn = "con_title";
            }
            else if (idw_contract.uf_not_entered(arow, "RgCode", "renewal group"))
            {
                sReturn = "rg_code";
            }
            else if (StaticFunctions.f_nempty(idw_contract.GetItem<Contract>(arow).ConBaseOffice) 
                 && !(StaticVariables.gnv_app.of_isempty(idw_contract.GetItem<Contract>(arow).ConBaseOfficeName)))
            {
                MessageBox.Show("The base office entered does not exist on the database"
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sReturn = "con_base_office_name";
            }
            else if (idw_contract.uf_not_entered(arow, "ConBaseOfficeName", "base office"))
            {
                sReturn = "con_base_office_name";
            }
            else if (StaticFunctions.f_nempty(idw_contract.GetItem<Contract>(arow).ConLodgementOffice) 
                    && !(StaticVariables.gnv_app.of_isempty(idw_contract.GetItem<Contract>(arow).ConLodgementOfficeName)))
            {
                MessageBox.Show("The lodgment office entered does not exist on the database"
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sReturn = "con_lodgement_office_name";
            }
            else if ((idw_contract.GetItem<Contract>(arow).ConBaseOffice == null))
            {
                MessageBox.Show("The base office entered does not exist on the database"
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sReturn = "con_base_office_name";
            }
            else if (idw_contract.uf_not_entered(arow, "CtKey", "def. contract type"))
            {
                sReturn = "ct_key";
            }
            else if (sManRDRef == "Y" 
                 && StaticVariables.gnv_app.of_isempty(idw_contract.GetItem<Contract>(arow).ConRdRefText))
            {
                MessageBox.Show("The rd reference text is mandatory for this type of base contract."
                               , this.Text
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                sReturn = "con_rd_ref_text";
            }
            else if (!((idw_contract.GetItem<Contract>(arow).ConDateTerminated == null)))
            {
                lContractNo = idw_contract.GetItem<Contract>(arow).ContractNo.GetValueOrDefault();
                // count addresses for the contract
                //SELECT Count(*) INTO :lCustCount FROM address 
                // WHERE contract_no = :lContractNo;
                lCustCount = RDSDataService.GetAddressCount(lContractNo, ref SQLCode, ref SQLErrText);
                // Any errors? 
                if (SQLCode != 0)
                {
                    MessageBox.Show("Unable to obtain customer details for this contract"
                                   , "Database Error" 
                                   , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    //  Any addresses?
                    if (lCustCount > 0)
                    {
                        if (lCustCount == 1)
                            ls_custCount = " address exists";
                        else
                            ls_custCount = " addresses exist";

                        ll_rc = MessageBox.Show(lCustCount.ToString() + ls_custCount + " for this contract.\n" 
                                        + "You can not terminate a contract which has active Addresses.\n\n" 
                                        + "Do you wish to transfer all Addresses to an \n" 
                                        + "alternative contract?"
                                        , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                                == DialogResult.Yes ? 1 : 2;
                        if (ll_rc == 1)
                        {
                            StaticVariables.gnv_app.of_get_parameters().integerparm = lCustCount;
                            StaticVariables.gnv_app.of_get_parameters().longparm = lContractNo;
                            //OpenWithParm(wTransfer, this);
                            StaticMessage.PowerObjectParm = this;
                            wTransfer = new WCustomerTransfer();
                            wTransfer.ShowDialog();
                        }
                        else
                        {
                            ib_terminated = false;
                        }
                        if (!ib_terminated)
                        {
                            //  User does not want to transfer to alternate contract
                            //  or canmcelled the transfer.
                            dtNull = null;
                            //  Reverse the change
                            idw_contract.GetItem<Contract>(arow).ConDateTerminated = dtNull;
                        }
                    }
                }
            }
            //else if (idw_contract.GetItemStatus(arow, "rg_code", primary!) == datamodified!) 
            else if (idw_contract.GetItem<Contract>(arow).RgCode != idw_contract.GetItem<Contract>(arow).GetInitialValue<int?>("RgCode")) 
            {
                lRGCode = idw_contract.GetItem<Contract>(arow).RgCode.GetValueOrDefault();
                // select rr_frozen_indicator into :sFrozenInd 
                //   from renewal_rate 
                //  where rg_code = :lRGCode 
                //    and rr_rates_effective_date 
                //             = (select max(rr_rates_effective_date) 
                //                  from renewal_rate 
                //                 where rg_code = :lRGCode);
                sFrozenInd = RDSDataService.GetRenewalRateRrFrozenIndicator(lRGCode);
                if (sFrozenInd != "Y")
                {
                    MessageBox.Show("This renewal group cannot be selected because the\n" 
                                      + "latest renewal rates have not been frozen yet."
                                   , this.Text
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sReturn = "rg_code";
                }
            }
            if (StaticVariables.gnv_app.of_isempty(sReturn))
            {
                if (idw_contract.GetItem<Contract>(arow).IsNew 
                    && idw_contract.GetItem<Contract>(arow).IsDirty)
                {
                    lContractType = idw_contract.GetItem<Contract>(arow).CtKey.GetValueOrDefault();
                    sContractType = "Contract: " + lContractType.ToString();
                    il_Contract_no = StaticVariables.gnv_app.of_get_nextcontract(lContractType);
                    idw_contract.GetItem<Contract>(arow).ContractNo = il_Contract_no;
                    sTitle = "Contract: (" + idw_contract.GetItem<Contract>(arow).ContractNo.GetValueOrDefault().ToString() + ") " 
                             + idw_contract.GetItem<Contract>(arow).ConTitle;
                    this.Text = sTitle;
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        this.Text = this.Text.Replace("\n", "");
                    }
                    idw_contract.GetControlByName("ct_key").Enabled = false;
                    idw_contract.Left = idw_contract.Left;
                }
                else
                {
                    sTitle = "Contract: (" + idw_contract.GetItem<Contract>(arow).ContractNo.GetValueOrDefault().ToString() + ") " 
                            + idw_contract.GetItem<Contract>(arow).ConTitle;
                    this.Text = sTitle;
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        this.Text = this.Text.Replace("\r\n", "");
                    }
                }
                idw_contract.DataObject.BindingSource.CurrencyManager.Refresh();
            }
            return sReturn.Length == 0;
        }

        public virtual void of_set_security(string ainsert, string adelete, string aupdate)
        {
            MMainMenu mCurrent;
            mCurrent = this.m_sheet;
            if (ainsert == "insert")
            {
                mCurrent.m_insertrow.Enabled = true;
            }
            else
            {
                mCurrent.m_insertrow.Enabled = false;
            }
            if (adelete == "delete")
            {
                mCurrent.m_deleterow.Enabled = true;
            }
            else
            {
                mCurrent.m_deleterow.Enabled = false;
            }
            if (aupdate == "update")
            {
                mCurrent.m_updatedatabase.Enabled = true;
            }
            else
            {
                mCurrent.m_updatedatabase.Enabled = false;
            }
        }

        public virtual void dw_contract_constructor()
        {
            dw_contract.of_setautoinsert(true);
            idw_contract = dw_contract;
            dw_contract.uf_setaudit(true);
            dw_contract.uf_settag("Contract");
            dw_contract.uf_setauditcolumns("con_base_office");
            dw_contract.uf_setauditcolumns("con_date_terminated");
            dw_contract.uf_setauditcolumns("message_for_invoice");
        }

        public virtual void dw_contract_pfc_postupdate()
        {
            RDSDataService.ProcesureSpCreatetfc();
            return;
        }

        public virtual void dw_contract_address_constructor()
        {
            dw_contract_address.of_setautoinsert(false);
            dw_contract_address.of_SetUpdateable(false);
            dw_contract_address.of_SetRowSelect(true);
            dw_contract.of_SetStyle(0);
            idw_addresses = dw_contract_address;
        }

        public virtual int dw_contract_address_pfc_preinsertrow()
        {
            return 1;
        }

        public virtual void dw_renewals_constructor()
        {
            dw_renewals.of_setautoinsert(true);
            dw_renewals.of_SetRowSelect(true);
            idw_renewals = dw_renewals;
        }

        public virtual int dw_fixed_assets_PfcPreDeleteRow()
        {
            // TJB  RPCR_026  June-2011: New
            // NOTE: Probably due to the complicated nature of how the fixed assets tab 
            // is set up (it REALLY needs to be fixed!) the row the user thinks has been 
            // selected hasn't, hence this code.
            // The Enter event in DContractFixedAsset puts the asset number of the 
            // row the user is currently focussed on in a hidden control beside the
            // strip height.  The code here uses that to find the row the user is 
            // focussed on to set it so that a getRow() returns that row.  This 
            // enables the Delete to find and delete the correct row.

            // If no row has been selected, ask 
            string sCurrentAsset = this.current_asset.Text;
            if (sCurrentAsset == "")
            {
                MessageBox.Show("Please select an asset to delete.");
                return 0;
            }

            // Find the row containing the current asset
            int nRow = 0;
            int nRows = dw_fixed_assets.RowCount;
            string sThisAsset = "";
            for (nRow = 0; nRow < nRows; nRow++)
            {
                sThisAsset = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                if (sCurrentAsset == sThisAsset)
                    break;                   
            }

            // See if we found something, set the selected row.
            if (nRow >= 0 && nRow < nRows)
            {
                // NOTE: Probably due to the complicated nature of how this tab is set up
                // (it REALLY needs to be fixed!), selectrow doesn't work.  SetCurrent was
                // found to work.
                dw_fixed_assets.DataObject.SetCurrent(nRow);
            }
            int nSelectedRow = dw_fixed_assets.GetRow();
            if (nSelectedRow >= 0 && nSelectedRow < dw_fixed_assets.RowCount)
            {
                string sSelectedAsset = dw_fixed_assets.GetItem<ContractFixedAssets>(nSelectedRow).FaFixedAssetNo;

                //MessageBox.Show("Current asset = " + sCurrentAsset + "\n"
                //              + "\n"
                //                + "Found row = " + nRow.ToString() + "\n"
                //                + "Selected row = " + nSelectedRow.ToString() + "\n"
                //                + "Selected asset = " + sSelectedAsset + "\n"           
                //                , "dw_fixed_assets_PfcPreDeleteRow");

                DialogResult ans = MessageBox.Show("Are you sure you want to delete asset " + sSelectedAsset + "?\n\n"
                                    + "The asset will be deleted from the asset register."
                                    , ""
                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                    , MessageBoxDefaultButton.Button1);
                if (ans == DialogResult.Yes)
                    return 1;
            }
            return 0;    // No
        }

        public virtual int dw_renewals_pfc_predeleterow()
        {
            string sstat = string.Empty;
            int lcontract;
            int lsequence;
            int lReturnValue;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            if (dw_renewals.GetSelectedRow(0) < 0)
            {
                return -(1);
            }
            sstat = dw_renewals.GetItem<Renewals>(dw_renewals.GetSelectedRow(0)).Status;
            if (sstat == "")
            {
                return -(1);
            }
            if (sstat != "Pending")
            {
                MessageBox.Show("You can only delete a pending renewal"
                               , "Delete Row"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -(1);
            }
            else
            {
                if (dw_renewals.RowCount == 1)
                {
                    MessageBox.Show("Delete not allowed because this is the only renewal for the contract"
                                   , "Delete Row"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -(1);
                }
                if (MessageBox.Show("Are you REALLY sure you want to delete this renewal?"
                                   , "Delete Row"
                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == DialogResult.No)
                {
                    return -(1);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    lcontract = dw_renewals.GetItem<Renewals>(dw_renewals.GetSelectedRow(0)).ContractNo.GetValueOrDefault();
                    lsequence = dw_renewals.GetItem<Renewals>(dw_renewals.GetSelectedRow(0)).ContractSeqNumber.GetValueOrDefault();
                    //  TWC 04/07/2003 - call 4532 - ensure the artical count doesn't get deleted on cascade
                    //UPDATE artical_count set contract_seq_number = null 
                    // where contract_no = lcontract and contract_seq_number = lsequence;
                    RDSDataService.ClearArticalCountContractSeqNumber(lcontract, lsequence, ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show("SQL Error clearing artical_count contract sequence number \n\n"
                                       + SQLErrText
                                       , "Delete Row"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                    // delete from contract_renewals 
                    //  where contract_no=lcontract and contract_seq_number=lsequence;
                    RDSDataService.DeleteContractRenewals(lcontract, lsequence, ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show("SQL error deleting contract renewal \n\n"
                                       + SQLErrText
                                       , "Delete Row"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                    //  force the article_count tab to retrieve again
                    idw_article_count.Retrieve(new object[]{lcontract});
                }
            }
            return 1;
        }

        public virtual int dw_renewals_pfc_preinsertrow()
        {
            // Prevent a row from being inserted
            return 0;
        }

        public virtual void dw_route_frequency_ue_enabledistance()
        {
            int ll_count;
            //select count(*) into :ll_count from contract, contract_renewals 
            // where contract.contract_no = :il_Contract_no 
            //   and contract.contract_no = contract_renewals.contract_no 
            //   and (contract.con_active_sequence is null 
            //        or contract.con_active_sequence < contract_renewals.contract_seq_number);
            ll_count = RDSDataService.GetContractCount(il_Contract_no);
            if (ll_count != 1)
            {
                ((Metex.Windows.DataEntityGrid)(dw_route_frequency.GetControlByName("grid"))).Columns["distance"].ReadOnly = true;
            }
        }

        public virtual void dw_route_frequency_constructor()
        {
            dw_route_frequency.of_setautoinsert(true);
            dw_route_frequency.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(0);
            idw_frequencies = dw_route_frequency;
        }

        public virtual int dw_route_frequency_pfc_validation()
        {
            bool lb_result;
            lb_result = of_validate_frequencies();
            if (lb_result == true)
            {
                return SUCCESS;
            }
            else
            {
                return FAILURE;
            }
        }

        public virtual void dw_route_audit_constructor()
        {
            dw_route_audit.of_setautoinsert(true);
            dw_route_audit.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(0);
            idw_route_audit = dw_route_audit;
        }

        public virtual void dw_route_audit_pfc_preinsertrow()
        {
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            // create uo
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            Cursor.Current = Cursors.WaitCursor;
            lnv_Criteria.of_addcriteria("contract_no", il_Contract_no);
            lnv_Criteria.of_addcriteria("contract_title", idw_contract.GetItem<Contract>(0).ConTitle);
            //?lnv_Criteria.of_addcriteria("ra_date_of_check", System.Convert.ToDateTime("00/00/0000"));
            lnv_Criteria.of_addcriteria("ra_date_of_check", (DateTime?)null);
            lnv_msg.of_addcriteria(lnv_Criteria);
            //  TWC - replacing this with open sheet
            //  OpenWithParm ( w_route_audit, lnv_Msg)
            //OpenSheetWithParm(w_route_audit, lnv_msg, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = lnv_msg;
            WRouteAudit w_route_audit = new WRouteAudit();
            w_route_audit.MdiParent = StaticVariables.MainMDI;
            w_route_audit.Show();
            dw_route_audit.Retrieve(new object[] { il_Contract_no });
            dw_route_audit.DataObject.SortString = "ra_date_of_check D";
            dw_route_audit.DataObject.Sort<RouteAuditListing>();
            // No row inserted
            return;//return 0;
        }

        public virtual void dw_types_constructor()
        {
            dw_types.of_setautoinsert(true);
            idw_types = dw_types;
        }

        public virtual int dw_types_pfc_validation()
        {
            bool lb_result;
            lb_result = of_validate_types();
            if (lb_result == true)
            {
                return SUCCESS;
            }
            else
            {
                return FAILURE;
            }
        }

        public virtual void dw_contract_allowances_constructor()
        {
            dw_contract_allowances.of_setautoinsert(true);
            dw_contract_allowances.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(0);
            idw_allowances = dw_contract_allowances;
        }

        public virtual void dw_contract_allowances_updatestart()
        {
            return;//return 0;
        }

        public virtual int dw_contract_allowances_pfc_preupdate()
        {
            base.pfc_preupdate();
            int ll_Row;
            int ll_RowCount;
            int lMasterRow;
            int lChildRow;
            int lRowCount;
            int lAltKey;
            string sDescrip = string.Empty;
            string sReturn = "";
            string sDaysDelivery = "";
            DateTime dtEfDate = DateTime.MinValue;
            Metex.Windows.DataUserControl dwcAltKey;
            dw_contract_allowances.AcceptText();
            for (ll_Row = 0; ll_Row < dw_contract_allowances.RowCount; ll_Row++)
            {
                dw_contract_allowances.GetItem<ContractAllowancesV2>(ll_Row).ContractNo = il_Contract_no;
                if (dw_contract_allowances.uf_not_entered(ll_Row, "alt_key", "allowance type"))
                {
                    sReturn = "alt_key";
                }
                else if (dw_contract_allowances.uf_not_entered(ll_Row, "ca_annual_amount", "annual amount"))
                {
                    sReturn = "ca_annual_amount";
                }
                else if (dw_contract_allowances.uf_not_entered(ll_Row, "ca_effective_date", "effective date"))
                {
                    sReturn = "ca_effective_date";
                }
                else
                {
                    lRowCount = dw_contract_allowances.RowCount;
                    if (lRowCount > 1)
                    {
                        for (lMasterRow = 1; lMasterRow <= lRowCount - 1; lMasterRow += 1)
                        {
                            lAltKey = dw_contract_allowances.GetItem<ContractAllowancesV2>(lMasterRow).AltKey.GetValueOrDefault();
                            //?dtEfDate = dw_contract_allowances.GetItem<ContractAllowancesV2>(lMasterRow).CaEffectiveDate.GetValueOrDefault().Date;
                            for (lChildRow = 1; lChildRow <= lRowCount; lChildRow++)
                            {
                                if (lMasterRow != lChildRow)
                                {
                                    if (lAltKey == dw_contract_allowances.GetItem<ContractAllowancesV2>(lChildRow).AltKey.GetValueOrDefault())
                                    {
                                        //?if (dtEfDate == dw_contract_allowances.GetItem<ContractAllowancesV2>(lChildRow).CaEffectiveDate.GetValueOrDefault().Date)
                                        {
                                            dw_contract_allowances.SetCurrent(lChildRow);
                                            dw_contract_allowances.SetCurrent(lChildRow);
                                            dw_contract_allowances.SelectRow(0, false);
                                            dw_contract_allowances.SelectRow(lChildRow, true);
                                            //?dwcAltKey = dw_contract_allowances.GetChild("alt_key");
                                            //?sDescrip = dwcAltKey.GetItemString(dwcAltKey.GetRow(), "alt_description");
                                            MessageBox.Show("The Allowance Type \'" + sDescrip + "\'" 
                                                            + " and Effective Date \'" + dtEfDate.ToString("dd/MM/yy") + "\'" 
                                                            + " are not unique.\n" 
                                                            + "You may not have the same Allowance Types " 
                                                            + "with the same Effective Dates."
                                                            , "Contract"
                                                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            sReturn = "ca_effective_date";
                                            break;
                                        }
                                    }
                                }
                            }
                            if (sReturn != "")
                            {
                                break;
                            }
                        }
                    }
                }
            }
            is_ErrorColumn = sReturn;
            if (sReturn.Length == 0)
                return 1;
            else
                return -(1);
        }

        // TJB Release 7.1.3 fixups Aug-2010
        // Added dw_contract_allowances_pfc_modify and changed how 
        // WAddAllowance is called.  The original (dw_contract_allowances_pfc_preinsertrow1)
        // was replaced with openAddAllowance
        public virtual void dw_contract_allowances_pfc_preinsertrow()
        {
            openAddAllowance("Insert");
        }

        public virtual void dw_contract_allowances_pfc_modify()
        {
            openAddAllowance("Update");
        }

        public virtual void openAddAllowance(string sOptype)
        {
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;

            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();

            Cursor.Current = Cursors.WaitCursor;
            lnv_Criteria.of_addcriteria("contract_no", il_Contract_no);
            lnv_Criteria.of_addcriteria("con_active_seq", il_con_active_seq);
            lnv_Criteria.of_addcriteria("contract_title", idw_contract.GetItem<Contract>(0).ConTitle);
            lnv_Criteria.of_addcriteria("alt_key", dw_contract_allowances.GetItem<ContractAllowancesV2>(dw_contract_allowances.GetRow()).AltKey);
            lnv_Criteria.of_addcriteria("allowance_row", dw_contract_allowances.GetRow());
            lnv_Criteria.of_addcriteria("optype", sOptype);
            lnv_msg.of_addcriteria(lnv_Criteria);

            // TJB Oct-2010
            // If the user attempts to add allowances to a new contract before it has 
            // been made active, there will be no 'con_active_seq' and WAddAllowance
            // will crash when it attempts to find the effective date for the contract.
            // This code allows allowances to be added to the pending contract.
            // Mark (Rural Post) declined using this in favour of a rule for operators 
            // to NOT attempt to add allowances until the new contract has become active.
            // if (il_con_active_seq < 1 )
            //    lnv_Criteria.of_addcriteria("con_active_seq", 1);
            
            // TJB  RPCR_017 July-2010
            // Changed WAddAllowance significantly
            // (See WAddAllowance0 for previous version)
            StaticMessage.PowerObjectParm = lnv_msg;
            StaticVariables.window = this;
            WAddAllowance w_add_allowance = new WAddAllowance();

            w_add_allowance.MdiParent = StaticVariables.MainMDI;
            w_add_allowance.Show();
            // This.retrieve(il_Contract_no)
            // No row inserted
            return;
        }

        public virtual void dw_artical_counts_constructor()
        {
            dw_artical_counts.of_setautoinsert(true);
            dw_artical_counts.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(0);
            idw_article_count = dw_artical_counts;
            //idw_article_count.DataObject.RetrieveEnd += new EventHandler(DataObject_RetrieveEnd);
        }

        public virtual void dw_artical_counts_ue_validate()
        {
        }

        public virtual int dw_artical_counts_pfc_preinsertrow()
        {
            // Prevent a row from being inserted
            return 0;
        }

        public virtual void dw_piece_rates_constructor()
        {
            dw_piece_rates.of_setautoinsert(true);
            dw_piece_rates.of_SetRowSelect(true);
            //?inv_rowselect.of_SetStyle(0);
            idw_piece_rates = dw_piece_rates;
        }

        public virtual void dw_fixed_assets_Constructor()
        {
            dw_fixed_assets.of_setautoinsert(true);
        }

        // TJB  RPCR_026  July-2011
        // This is used to pass the new asset number between the PfcPreInsertRow 
        // (where it is created and used to populate the display) and the PfcInsertRow 
        // event handlers (where it is used to populate the record).
        private string sNewAssetNo = "";

        public virtual int dw_fixed_assets_PfcPreInsertRow()
        {
            // TJB  RPCR_026  July-2011
            // Determine the new asset's number
            int nFixedAssetNo = of_get_nextsequence("FixedAssetNo");
            string sFixedAssetNo = "RP" + nFixedAssetNo.ToString();

            // Load the new asset's number and current contract number into the 
            // hidden objects.  Code in DContractFixedAssets load event handler
            // (fa_load) uses these to populate the initial display (somewhat 
            // of a hack :-).
            this.new_asset.Text = sFixedAssetNo;
            this.new_contract.Text = il_Contract_no.ToString();

            sNewAssetNo = sFixedAssetNo;

            return 1;
        }

        public virtual void dw_fixed_assets_PfcInsertRow()
        {
            // TJB  RPCR_026  July-2011
            // Called after a new row has been inserted
            // Populate the record's asset number, contract number, and sh_id (strip height)
            // NOTE: These values populate the record, but in some cases, not the displayed 
            //       form.   See dw_fixed_assets_PfcPreInsertRow().

            //int nFixedAssetNo = of_get_nextsequence("FixedAssetNo");
            //string sFixedAssetNo = "RP" + nFixedAssetNo.ToString();
            string sFixedAssetNo = sNewAssetNo;
            this.new_asset.Text = "";
            this.new_contract.Text = "";

            int nRow = dw_fixed_assets.GetRow();

            dw_fixed_assets.SelectRow(nRow, true);
            dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo = sFixedAssetNo;
            dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo = il_Contract_no;
            int default_ShId = of_getDefaultStripHeightId();
            dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ShId = default_ShId;
            this.sh_id.SelectedIndex = default_ShId - 1;
            dw_fixed_assets.AcceptText();
            dw_fixed_assets.URdsDw_GetFocus(null,null);

            /* -------------------- Debugging  ------------------------ //
            bool nRow_isDirty = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).IsDirty;
            bool nRow_isNew = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).IsNew;
            MessageBox.Show("Row = " + nRow.ToString() + "\n"
                            + "isDirty = " + nRow_isDirty.ToString() + "\n"
                            + "isNew = " + nRow_isNew.ToString() + "\n"
                            , "dw_fixed_assets_PfcInsertRow");

            string sControlList;
            System.Windows.Forms.Control.ControlCollection dw_controls = dw_fixed_assets.DataObject.Controls;
            sControlList = listControls(dw_controls);
            MessageBox.Show("dw_fixed_assets.DataObject.Controls \n"
                            + sControlList
                            , "dw_fixed_assets_PfcInsertRow");
            System.Windows.Forms.Control.ControlCollection tbpanel_controls = dw_controls[1].Controls;
            sControlList = listControls(tbpanel_controls);
            MessageBox.Show("TbPanel controls \n"
                            + sControlList
                            , "dw_fixed_assets_PfcInsertRow");
            System.Windows.Forms.Control.ControlCollection panel0_controls = tbpanel_controls[0].Controls;
            sControlList = listControls(panel0_controls);
            MessageBox.Show("Panel0 controls \n"
                            + sControlList
                            , "dw_fixed_assets_PfcInsertRow");
            string s_contractNo = panel0_controls["contract_no"].Text;
            string s_assetNo = panel0_controls["fa_fixed_asset_no"].Text;
            MessageBox.Show("Panel0 control values \n"
                            + "Contract no" + s_contractNo + "\n"
                            + "Asset no" + s_assetNo + "\n"
                            , "dw_fixed_assets_PfcInsertRow");
            // -------------------- Debugging  ------------------------ */
            return;
        }

        private string listControls(System.Windows.Forms.Control.ControlCollection theseControls)
        {
            // TJB  RPCR_026  July-2011: debugging function
            string controlList = "";
            string itemName = "";
            bool itemHasChildren;
            for (int nRow = 0; nRow < theseControls.Count; nRow++)
            {
                itemName = theseControls[nRow].Name;
                itemHasChildren = theseControls[nRow].HasChildren;
                controlList += nRow.ToString() + " " + itemName + " " + itemHasChildren.ToString() + "\n";
            }
            return controlList;
        }

        public virtual int dw_fixed_assets_PfcUpdate()
        {
            // TJB  RPCR_026  July-2011
            // This is called after the update has completed.
            // It checks for any errors and returns FAILURE if any are found.
            // This prevents PfcPostUpdate from being run.
            int nRow, nSqlCode, rc;
            int nRows = dw_fixed_assets.RowCount;
            rc = SUCCESS;

            for (nRow = 0; nRow < nRows; nRow++)
            {
                nSqlCode = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).SqlCode;
                if (nSqlCode != 0)
                {
                    int? nContractNo;
                    string sContractNo;
                    string sSqlErrMsg, sAssetNo;
                    sSqlErrMsg = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).SqlErrText;
                    sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                    nContractNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo;
                    sContractNo = (nContractNo == null) ? "null" : nContractNo.ToString();

                    MessageBox.Show("Error saving asset " + sAssetNo + " for contract " + sContractNo + "\n\n"
                                    + "SQL Error: " + sSqlErrMsg + "\n"
                                    , "Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rc = FAILURE;
                }
            }
            return rc;
        }

        public virtual int dw_fixed_assets_PfcPreUpdate()
        {
            // TJB  RPCR_026  July-2011
            // This checks for changes in the contract number, and check that the user
            // intended to change it.
            int nRow = dw_fixed_assets.GetRow();
            //if (nRow < 0)
            //    return FAILURE;
            if (nRow >= 0)
            {
                int? nContractNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo;
                if (nContractNo == 0) nContractNo = null;
                if (nContractNo == null || nContractNo != il_Contract_no)
                {
                    string msg;
                    string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                    if (nContractNo != null)
                    {
                        msg = "Please confirm that you want to assign fixed asset " + sAssetNo + "\n"
                              + "to contract " + nContractNo.ToString() + ".\n";
                    }
                    else
                    {
                        msg = "Please confirm that you want to remove fixed asset " + sAssetNo + " \n"
                              + "from this contract and not assign it to another contract. \n\n"
                              + "The asset will remain on the asset register.\n";
                    }
                    DialogResult ans = MessageBox.Show(msg
                                        , "Fixed Assets"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                        , MessageBoxDefaultButton.Button1);
                    if (ans == DialogResult.No)
                    {
                        return FAILURE;
                    }
                    // TJB  RPCR_026  July-2011
                    // There's no longer a restriction on having duplicate asset types 
                    // on the same contract
                    //int? nFatId = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FatId;
                    //int nFatIdCount = RDSDataService.GetFatIdCount(nContractNo, nFatId);
                    //if (nFatIdCount > 0)
                    //{
                    //    MessageBox.Show("Contract " + sContractNo + " already has an of that type.\n"
                    //                    + "Asset not reassigned."
                    //                    , "Warning"
                    //                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return FAILURE;
                    //}
                    //else if (nFatIdCount < 0)
                    //{
                    //    MessageBox.Show("An error was encountered when checking for a duplicate asset \n"
                    //                    + "type for contract " + sContractNo + ".\n\n"
                    //                    + "Check that you've specified the correct contract number."
                    //                    , "Error"
                    //                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return FAILURE;
                    //}
                }
            }
            return SUCCESS;
        }

        public virtual void dw_fixed_assets_PfcPostUpdate()
        {
            // TJB  RPCR_026  July-2011
            // Check for errors saving new/updated records
            for (int nRow = 0; nRow < dw_fixed_assets.RowCount; nRow++)
            {
                int SQLCode = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).SQLCode;
                if (SQLCode != 0)
                {
                    string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                    string SQLErrText = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).SQLErrText;
                    MessageBox.Show("Error saving asset " + sAssetNo + "\n\n"
                                    + "SQL Code = " + SQLCode.ToString() + "\n"
                                    + "Error text: " + SQLErrText + "\n"
                                    , "ERROR"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // This is called after a successful update
            // If an asset has been moved to a different contract, this ensures that only
            // the assets for the current contract are left on the user's screen.
            dw_fixed_assets.Reset();

            dw_fixed_assets.URdsDw_GetFocus(null, null);
            if (dw_fixed_assets.RowCount == 0)
            {
                dw_fixed_assets.Retrieve(new object[] { il_Contract_no });
            }
            if (dw_fixed_assets.RowCount > 0)
            {
                int nRow = dw_fixed_assets.GetRow();
                string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                if (sAssetNo == null || sAssetNo.Trim() == "")
                {
                    dw_fixed_assets.DeleteItemAt(nRow);
                }
            }
        }

        public virtual int dw_fixed_assets_PfcValidation()
        {
            bool bValidated = of_validate_fixed_assets();
            if (bValidated)
            {
                return SUCCESS;
            }
            return FAILURE;
        }

        public virtual void dw_cmbs_constructor()
        {
            // TJB  SR4659  July 2005
            idw_cmb = dw_cmbs;
            // uf_settag("CMBs")
        }

        public virtual void dw_freight_allocations_constructor()
        {
            dw_freight_allocations.of_setautoinsert(true);
            idw_freight_allocations = dw_freight_allocations;
        }

        public virtual void dw_cmbs_pfc_preinsertrow()
        {
            //  TJB  SR4659  July 2005
            int? ll_tc_id;
            int? ll_postcode_id = 0;
            int ll_del;
            int ll_row;
            string ls_con_title;
            string ls_rdno = string.Empty;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            //  Check to see if any rows have been marked as deleted.
            //  If there are, ask whether the user wants to do the deletion.
            //  The deletion will be lost after the insert (it refreshes 
            //  the display from the database to include the new CMBs).
            ll_del = idw_cmb.DataObject.DeletedCount;
            if (ll_del > 0)
            {
                string ls_temp1;
                string ls_temp2;
                if (ll_del == 1)
                {
                    ls_temp1 = "There is 1 row ";
                    ls_temp2 = "it";
                }
                else
                {
                    ls_temp1 = "There are " + ll_del.ToString() + " rows ";
                    ls_temp2 = "them";
                }
                if (MessageBox.Show(ls_temp1 + " marked for deletion.\n" 
                                   + "Delete " + ls_temp2 + " now?"
                                   , "Warning"
                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                   , MessageBoxDefaultButton.Button2) 
                    == DialogResult.Yes)
                {
                    //!idw_cmb.Update();
                    idw_cmb.Save();
                }
            }
            Cursor.Current = Cursors.WaitCursor;
            // create uo
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            ls_con_title = idw_contract.GetItem<Contract>(0).ConTitle;
            lnv_Criteria.of_addcriteria("cmb_id", 0);
            lnv_Criteria.of_addcriteria("contract_no", il_Contract_no);
            lnv_Criteria.of_addcriteria("contract_title", ls_con_title);
            if (idw_cmb.RowCount > 0)
            {
                ll_row = idw_cmb.GetRow();
                ll_tc_id = idw_cmb.GetItem<CmbAddressList>(ll_row).TcId;
                ll_postcode_id = idw_cmb.GetItem<CmbAddressList>(ll_row).PostCodeId;
                ls_rdno = idw_cmb.GetItem<CmbAddressList>(ll_row).AdrRdNo;
            }
            else
            {
                ll_tc_id = 0;
            }
            if ((ll_tc_id == null) || ll_tc_id < 1)
            {
                /*select first a.adr_rd_no, p.post_code_id, t.tc_id 
                 *  from address a, post_code p, towncity t 
                 * where a.post_code_id = p.post_code_id 
                 *   and t.tc_name = p.post_mail_town 
                 *   and a.contract_no = :il_contract_no;*/
                AddressPostCodeTowncityItem l_temp = RDSDataService.GetAddressInfoFirst(il_Contract_no).AddressPostCodeTowncityItem;
                ls_rdno = l_temp.AdrRdNo;
                ll_postcode_id = l_temp.PostCodeId;
                ll_tc_id = l_temp.TcId;
            }
            lnv_Criteria.of_addcriteria("tc_id", ll_tc_id);
            lnv_Criteria.of_addcriteria("post_code_id", ll_postcode_id);
            lnv_Criteria.of_addcriteria("adr_rd_no", ls_rdno);
            lnv_msg.of_addcriteria(lnv_Criteria);
            //OpenSheetWithParm(w_cmb_address_detail, lnv_msg, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = lnv_msg;
            WCmbAddressDetail w_cmb_address_detail = new WCmbAddressDetail();
            w_cmb_address_detail.MdiParent = StaticVariables.MainMDI;
            w_cmb_address_detail.Show();
            //idw_cmb.Retrieve(new object[]{il_Contract_no });
            return;//return 0;
        }

        public virtual void dw_cmbs_pfc_deleterow()
        {
            //  TJB  SR4659  July 2005
            //  ----------------------------------
            //  TJB  Release 6.8.9 fixup  Nov 2005
            //  Changed to use wf_set_cmb_privs and u_rds_dw.uf_setToolbar
            //  Long ll_del
            //  ll_del  = idw_cmb.deletedCount()
            wf_set_cmb_privs();

            //?idw_cmb.uf_settoolbar();
            return;//return SUCCESS;
        }

        public virtual int dw_cmbs_pfc_predeleterow()
        {
            //  TJB  SR4659  July 2005
            //  Check that a row has been selected for deletion
            //   ( If nothing's selected, the row = 1 but it isn't marked as being selected)
            int ll_row;
            ll_row = idw_cmb.GetRow();

            if (ll_row >= 0 && idw_cmb.IsSelected(ll_row))
            {
                return SUCCESS;
            }
            else
            {
                MessageBox.Show("Please select a row to delete"
                               , "CMB"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return FAILURE;
            }
        }
        #endregion

        #region Events
        //jlwang:
        public void tab_contract_GotFocus(object sender, EventArgs e)
        {
            string str = tab_contract.TabPages[tab_contract.SelectedIndex].Text.ToLower().Trim();
            if (str == "allowances")
            {
                idw_allowances.showUpdateToolButton = true;
                dw_contract_allowances.URdsDw_GetFocus(null, null);
                idw_allowances.showUpdateToolButton = false;
            }
            if (str == "cmbs")//(tab_contract.SelectedIndex + 1 == 11)
            {
                idw_cmb.Retrieve(new object[]{il_Contract_no });
                dw_cmbs_getfocus(null, null);
            }
        }

        public virtual void tab_contract_selectionchanging(object sender, EventArgs e)
        {
            //  TJB  SR4659  July 2005
            //  Added references to CMB datawindow
            if (oldTabIndex == tab_contract.SelectedIndex)
                return;

            DialogResult ans;
            int ll_ret;
            int ll_Row;
            Cursor.Current = Cursors.WaitCursor;
            if (ib_Opening)
            {
                dw_fixed_assets.ResetUpdate();
                idw_piece_rates.ResetUpdate();
                idw_article_count.ResetUpdate();
                idw_allowances.ResetUpdate();
                idw_types.ResetUpdate();
                idw_route_audit.ResetUpdate();
                idw_frequencies.ResetUpdate();
                idw_renewals.ResetUpdate();
                idw_addresses.ResetUpdate();
                idw_cmb.ResetUpdate();
                idw_freight_allocations.ResetUpdate();
                if (il_Contract_no > 0)
                {
                    idw_contract.ResetUpdate();
                }
                return;
            }
            // Check for new contract
            if (il_Contract_no == -(1))
            {
                tab_contract.SelectTab(oldTabIndex);
                MessageBox.Show("The current contract has to be saved before you can change tabs."
                               , "New Contract"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Check for any changes to idw_contract
            idw_contract.AcceptText();
            if (idw_contract.DataObject.DeletedCount > 0 || idw_contract.ModifiedCount() > 0)
            {
                ans = MessageBox.Show("Do you want to update database?"
                                         , "Contract"
                                         , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_contract.GetRow();
                if (ans == DialogResult.Yes)
                {
                    ll_ret = idw_contract.Save();
                    if (ll_ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    idw_contract.Reset();
                    //  TJB  SR4679  July 2006
                    //  Bug fix (nothing to do with SR4679, just found and fixed at the same time)
                    //  The other tabs refer to the contract details to get the contract
                    //  title.  If the save is declined, the reset leaves the contract 
                    //  details empty and the other tabs fail with an invalid column/row 
                    //  message when they access row 1 (after reset the rowcount is 0).
                    //  Thus we need to retrieve the contract details again (to get the 
                    //  unmodified details).
                    idw_contract.Retrieve(new object[] { il_Contract_no });
                }
            }
            // Check for any changes to idw_frequencies
            idw_frequencies.AcceptText();
            if (idw_frequencies.DataObject.DeletedCount > 0 || idw_frequencies.ModifiedCount() > 0)
            {
                ans = MessageBox.Show("Do you want to update database?"
                                        , "Frequencies"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_frequencies.GetRow();
                if (ans == DialogResult.Yes)
                {
                    ll_ret = idw_frequencies.Save();
                    if (ll_ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    idw_frequencies.Reset();
                }
            }
            // Check for any changes to idw_types
            idw_types.AcceptText();
            if (idw_types.DataObject.DeletedCount > 0 || idw_types.ModifiedCount() > 0)
            {
                ans = MessageBox.Show("Do you want to update database?"
                                        , "Contract Types"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_types.GetRow();
                if (ans == DialogResult.Yes)
                {
                    ll_ret = idw_types.Save();
                    if (ll_ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    idw_types.Reset();
                }
            }
            // Check for any changes to idw_allowances
            idw_allowances.AcceptText();
            if (idw_allowances.DataObject.DeletedCount > 0 || idw_allowances.ModifiedCount() > 0)
            {
                ans = MessageBox.Show("Do you want to update database?"
                                        , "Allowances"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_allowances.GetRow();
                if (ans == DialogResult.Yes)
                {
                    ll_ret = idw_allowances.Save(); 
                    if (ll_ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    idw_allowances.Reset();
                }
            }
            // Check for any changes to dw_fixed_assets
            dw_fixed_assets.AcceptText();
            if (dw_fixed_assets.DataObject.DeletedCount > 0 || dw_fixed_assets.ModifiedCount() > 0)
            {
                ans = MessageBox.Show("Do you want to update database?"
                                        , "Fixed Assets"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = dw_fixed_assets.GetRow();
                if (ans == DialogResult.Yes)
                {
                    ll_ret = dw_fixed_assets.Save();
                    if (ll_ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    dw_fixed_assets.Reset();
                }
            }
        }

        //jlwang:change selectindex to name 
        // log in app with different user ,the tabpage should be invisible or visible
        // if we use select index to get tagepage it will throw exception. 
        public virtual void tab_contract_selectionchanged(object sender, EventArgs e)
        {
            if (oldTabIndex == tab_contract.SelectedIndex)
            {
                return;
            }

            //  TJB  SR4659  July 2005
            //  Added references to CMB datawindow (index 11)
            // -----------------------------------
            //  TJB  Release 6.8.9 fixup  Nov 2005
            //  Added calls to uf_setToolbar() to fix problem with
            //  toolbar not updating correctly.
            int ll_Active;
            MSheet lm_menu;
            lm_menu = this.m_sheet;

            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();
            //  TJB  SR4657  June05
            //  Changed detection of changed custlist_updated field
            // 
            //  Check that we save custlist data
            if (of_custlist_changed())
            {
                if (MessageBox.Show("Do you wish to save the new customer list information?"
                                   , "Customer List"
                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                   == DialogResult.Yes)
                {
                    of_update_custlist();
                }
                else
                {
                    // Revert the date back to the saved date
                    if (id_custlist_updated.GetValueOrDefault() == DateTime.MinValue)
                    {
                        em_custlist_updated.Text = "01/01/1900";
                    }
                    else
                    {
                        em_custlist_updated.Text = id_custlist_updated.ToString();
                    }
                }
                ib_custlist_changed = false;
            }
            //  If we're switching away from the Address tab
            //  make sure the 'save' toolbar button is off
            if (oldTabIndex == 2 - 1)
            {
                if ((lm_menu != null))
                {
                    lm_menu._m_updatedatabase.Visible = false;
                    lm_menu.m_updatedatabase.Visible = false;
                    lm_menu.m_updatedatabase.Enabled = false;
                }
            }

            // ToTabName is the name of the tab we've changed TO.
            string ToTabName = tab_contract.TabPages[tab_contract.SelectedIndex].Text.ToLower().Trim();

            if (ToTabName == "contract")
            {
                dw_contract_getfocus(null, null);

                idw_contract.uf_toggle_audit(true);
                if (idw_contract.RowCount == 0)
                {
                    idw_contract.Retrieve(new object[]{il_Contract_no});
                }
                idw_contract.uf_settoolbar();
            }
            else if (ToTabName == "addresses")
            {
                idw_addresses.URdsDw_GetFocus(null, null);

                if (idw_addresses.RowCount == 0)
                {
                    idw_addresses.Retrieve(new object[]{il_Contract_no});
                }
                idw_addresses.uf_settoolbar();
                this.of_set_custlist_data();
            }
            else if (ToTabName == "renewals")
            {
                DateTime? Con_Date_Terminated;

                idw_renewals.URdsDw_GetFocus(null, null);

                idw_contract.uf_toggle_audit(false);
                if (idw_renewals.RowCount == 0)
                {
                    idw_renewals.Retrieve(new object[]{il_Contract_no});
                }
                idw_renewals.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;
                ll_Active = idw_contract.GetItem<Contract>(0).ConActiveSequence.GetValueOrDefault();
                Con_Date_Terminated = idw_contract.GetItem<Contract>(0).ConDateTerminated;
                string st_active, t;
                st_active = idw_renewals.GetControlByName("st_active").Text;
                t = st_active;
                if (ll_Active == 1)
                {
                    idw_renewals.GetControlByName("st_active").Text = "0";
                }
                if (StaticFunctions.f_nempty(ll_Active))
                {
                    idw_renewals.GetControlByName("st_active").Text = "0";
                }
                else
                {
                    // TJB  12-Apr-2012 RPI_032
                    // ...("st_active").Text isn't updated if its current value is the same
                    // as the value being assigned (ll_active in this case).  ...("st_active").Text's
                    // default value is 1, so isn't updated when ll_active is 1.  The problem is, 
                    // there's a trigger on the update event for ...("st_active").Text, and this 
                    // isn't triggered.  The event updates the value st_active_text in Entity.Renewals.cs 
                    // (via assignment to the Status object), which remains as NULL, and causes the
                    // Status value to be returned as "Expired" instead of "Active".
                    // This fiddle ensures the actual value of ll_active is saved, causing the event 
                    // to trigger and the correct value to be saved in st_active_text, and thus the
                    // correct Status to be returned.
                    //
                    // TJB 4-Sep-2012 RPI_032 bug fix
                    // Terminated contracts were also shown as active.  Add check of 
                    // terminated date.
                    //
                    // TJB 18-Sep-2012 Release fixup
                    // Undid 'terminated contracts' bug fix as requested.
                    
                    //if (Con_Date_Terminated == null)
                    //{
                        if (ll_Active == 1)
                        {
                            idw_renewals.GetControlByName("st_active").Text = "0";
                        }
                        idw_renewals.GetControlByName("st_active").Text = ll_Active.ToString();
                    //}
                }
                idw_renewals.uf_settoolbar();
            }
            else if (ToTabName == "frequencies")
            {
                dw_route_frequency_getfocus(null, null);
                idw_frequencies.uf_toggle_audit(false);
                if (idw_frequencies.RowCount == 0)
                {
                    idw_frequencies.Retrieve(new object[]{il_Contract_no});
                }
                idw_frequencies.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;
                idw_frequencies.uf_settoolbar();
                idw_frequencies.URdsDw_Clicked(null, null);
            }
            else if (ToTabName == "route audit")
            {
                idw_route_audit.URdsDw_GetFocus(null, null);

                idw_contract.uf_toggle_audit(false);
                if (idw_route_audit.RowCount == 0)
                {
                    idw_route_audit.Retrieve(new object[]{il_Contract_no});
                    idw_route_audit.DataObject.SortString = "ra_date_of_check D";
                    idw_route_audit.DataObject.Sort<RouteAuditListing>();
                }
                if (idw_route_audit.GetControlByName("st_contract") != null)
                    idw_route_audit.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;

                idw_route_audit.uf_settoolbar();
            }
            else if (ToTabName == "types")
            {
                idw_types.URdsDw_GetFocus(null, null);

                //added by ylwang
                DataUserControl lds_user_contract_types;
                lds_user_contract_types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
                List<DddwContractTypes> bindingSource = (List<DddwContractTypes>)((Metex.Windows.DataGridViewEntityComboColumn)((Metex.Windows.DataEntityGrid)idw_types.DataObject.GetControlByName("grid")).Columns["ct_key"]).DataSource;
                lds_user_contract_types.SortString = "ct_key A";
                lds_user_contract_types.Sort<FilteredContractTypes>();
                bindingSource.Clear();

                for (int i = 0; i < lds_user_contract_types.RowCount; i++)
                {
                    DddwContractTypes obj = (DddwContractTypes)Activator.CreateInstance(typeof(DddwContractTypes));

                    obj.CtKey = (Int32?)lds_user_contract_types.GetValue(i, "ct_key");
                    obj.ContractType = (String)lds_user_contract_types.GetValue(i, "contract_type");
                    obj.CtRdRefMandatory = (String)lds_user_contract_types.GetValue(i, "ct_rd_ref_mandatory");
                    bindingSource.Insert(i, obj);
                }
                if (idw_types.RowCount == 0)
                {
                    idw_types.Retrieve(new object[]{il_Contract_no});
                }

                idw_types.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;
                idw_types.uf_settoolbar();
            }
            else if (ToTabName == "allowances")
            {
                idw_allowances.showUpdateToolButton = true;
                idw_allowances.URdsDw_GetFocus(null, null);
                idw_allowances.showUpdateToolButton = false;

                if (idw_allowances.RowCount == 0)
                {
                    idw_allowances.Retrieve(new object[]{il_Contract_no});
                }
                idw_allowances.uf_settoolbar();
            }
            else if (ToTabName == "article count")
            {
                idw_article_count.URdsDw_GetFocus(null, null);

                if (idw_article_count.RowCount == 0)
                {
                    idw_article_count.Retrieve(new object[] { il_Contract_no });
                }
                idw_article_count.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;
                idw_article_count.uf_settoolbar();
            }
            else if (ToTabName == "piece rates")
            {
                idw_piece_rates.URdsDw_GetFocus(null, null);

                if (idw_piece_rates.RowCount == 0)
                {
                    idw_piece_rates.Retrieve(new object[]{il_Contract_no});
                }
                idw_piece_rates.uf_settoolbar();
            }
            else if (ToTabName == "fixed assets")
            {
                int nRow;
                dw_fixed_assets.URdsDw_GetFocus(null, null);

                //if there are no records, see if there are any to get
                if (dw_fixed_assets.RowCount == 0)
                {
                    dw_fixed_assets.Retrieve(new object[]{il_Contract_no });
                }
                // TJB  RPCR_026  July-2011
                // If there now are records, see if the current one is empty
                // If so, get rid of it.  If the contract has no assets assigned, we want the user to 
                // explicitly add one if that's when the user is trying to do.  Otherwise they may
                // just be skipping over the tab.
                if (dw_fixed_assets.RowCount > 0)
                {
                    nRow = dw_fixed_assets.GetRow();
                    string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                    if (sAssetNo == null || sAssetNo.Trim() == "")
                    {
                        dw_fixed_assets.DeleteItemAt(nRow);
                    }
                }

                // If there are still records, they must be real
                if (dw_fixed_assets.RowCount > 0)
                {
                    // TJB  RPCR_026  June-2011
                    // Wait to set the binding for the strip height dropdown 
                    // until after the fixed assets tab has been opened
                    if (this.sh_id.DataBindings.Count == 0)
                        this.sh_id.DataBindings.Add(
                                new System.Windows.Forms.Binding("Value"
                                         , dw_fixed_assets.DataObject.BindingSource
                                         , "ShHeight"
                                         , true
                                         , System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                }
                else
                {   // Nasty hack: the default strip height is 40; this is ID = 4, item 3
                    // I really shouldn't rely on the ID being 1 more than the index ...
                    int nDefaultShId = of_getDefaultStripHeightId();

                    this.sh_id.SelectedIndex = nDefaultShId - 1;
                }
                dw_fixed_assets.uf_settoolbar();
            }

            else if (ToTabName == "cmbs")
            {
                if (idw_cmb.RowCount == 0)
                {
                    idw_cmb.Reset();
                    idw_cmb.Retrieve(new object[] { il_Contract_no });
                }
                wf_set_cmb_privs();
                idw_cmb.uf_settoolbar();
                dw_cmbs_getfocus(null, null);
            }
            // TJB  RPCR_025  June-2011
            //      Added freight allocations handling
            else if (ToTabName == "freight allocations")
            {
                idw_freight_allocations.URdsDw_GetFocus(null, null);

                // If we don't have a row to work with, get it now
                if (idw_freight_allocations.RowCount == 0)
                {
                    idw_freight_allocations.Reset();
                    idw_freight_allocations.Retrieve(new object[] { il_Contract_no });

                    // If there wasn't one to get, create a new one
                    int nRows = idw_freight_allocations.RowCount;
                    if (nRows == 0)
                    {
                        int? pbuId = dw_contract.GetItem<Contract>(0).PbuId;
                        idw_freight_allocations.InsertItem<FreightAllocations>(0);
                        idw_freight_allocations.GetItem<FreightAllocations>(0).ContractNo = il_Contract_no;
                        //idw_freight_allocations.GetItem<FreightAllocations>(0).PbuId = pbuId;

                        ((DContractFreightAllocations)(idw_freight_allocations.DataObject)).set_selected_pbu(pbuId);
                        idw_freight_allocations.AcceptText();
                    }
                }
                idw_freight_allocations.GetControlByName("active_ind").Focus();
                wf_set_freight_allocations_toolbar();
            }
            oldTabIndex = tab_contract.SelectedIndex;
            this.ResumeLayout(true);
        }

        public virtual void dw_contract_clicked(object sender, EventArgs e)
        {
            dw_contract.URdsDw_Clicked(sender, e);
            string sObjectAtPointer;
            string sOutlet;
            sObjectAtPointer = ((Button)sender).Name;

            if ((sObjectAtPointer.Length <= 9 ? sObjectAtPointer : sObjectAtPointer.Substring(0, 9)) == "bo_button")
            {
                of_get_outlet("base", "bo");
            }
            else if ((sObjectAtPointer.Length <= 9 ? sObjectAtPointer : sObjectAtPointer.Substring(0, 9)) == "lo_button")// (sObjectAtPointer.Substring(0, 9) == "lo_button")
            {
                of_get_outlet("lodgement", "lo");
            }
        }

        public virtual void dw_contract_itemchanged(object sender, EventArgs e)
        {
            dw_contract.URdsDw_Itemchanged(sender, e);
            string sOutlet;
            string Snull;
            int? lOutletCode;
            int? lRegionId;
            int lCustCount;
            int lContractNo;
            Metex.Windows.DataUserControl dwc;

            int SQLCode = 0;
            string SQLErrText = string.Empty;
            lContractNo = dw_contract.GetItem<Contract>(0).ContractNo.GetValueOrDefault();
            if (dw_contract.GetColumnName() == null)
            {
                return;
            }
            if (dw_contract.GetColumnName().Substring(2) == "_picklist")
            {
                if (dw_contract.GetColumnName().Substring(0, 2) == "bo")
                {
                    of_get_outlet("base", "bo");
                }
                else
                {
                    of_get_outlet("lodgement", "lo");
                }
            }
            else if (dw_contract.GetColumnName() == "con_base_office_name")
            {
                sOutlet = dw_contract.GetControlByName(dw_contract.GetColumnName()).Text;//dw_contract.GetText();
                if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
                {
                    /*Select outlet_id, region_id Into :lOutletCode, :lRegionId From outlet Where o_name = :sOutlet;*/
                    OutletItem l_OutletItem = RDSDataService.GetOutletInfo(sOutlet).OutletItem;
                    lOutletCode = l_OutletItem.OutletId;
                    lRegionId = l_OutletItem.RegionId;
                }
                else
                {
                    lOutletCode = null;
                    lRegionId = null;
                }
                dw_contract.GetItem<Contract>(dw_contract.GetRow()).ConBaseOffice = lOutletCode;
                dw_contract.GetItem<Contract>(dw_contract.GetRow()).RegionId = lRegionId;
            }
            else if (dw_contract.GetColumnName() == "con_lodgement_office_name")
            {
                sOutlet = dw_contract.GetControlByName(dw_contract.GetColumnName()).Text;//dw_contract.GetText();
                if (!(StaticVariables.gnv_app.of_isempty(sOutlet)))
                {
                    /*Select outlet_id Into :lOutletCode From outlet Where o_name = :sOutlet;*/
                    lOutletCode = RDSDataService.GetOutletOutletId(sOutlet, ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        lOutletCode = null;
                    }
                }
                else
                {
                    lOutletCode = null;
                }
                dw_contract.GetItem<Contract>(dw_contract.GetRow()).ConLodgementOffice = lOutletCode;
            }
            else if (dw_contract.GetColumnName() == "ct_key")
            {
                dwc = idw_contract.GetChild("ct_key");//idw_contract.GetChild("ct_key", dwc);
                if (dwc.GetRow() >= 0)
                {
                    if (dwc.GetItem<DddwContractTypes>(dwc.GetRow()).CtRdRefMandatory == "Y")
                    {
                        dw_contract.GetControlByName("con_rd_ref_text").BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                    }
                    else
                    {
                        dw_contract.GetControlByName("con_rd_ref_text").BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    }
                }
                // ElseIf This.GetColumnName ( ) = "con_date_terminated" Then
                // 	Openwithparm ( w_customer_transfer, lContractNo)
            }
        }

        public virtual void dw_contract_itemfocuschanged(object sender, EventArgs e)
        {
            Metex.Windows.DataUserControl dwChild;
            if (dw_contract.GetColumnName() == "bo_picklist")
            {
                //?dw_contract.Modify("bo_rectangle.pen.color=0");
            }
            else
            {
                //?dw_contract.Modify("bo_rectangle.pen.color=8421504");
            }
            if (dw_contract.GetColumnName() == "lo_picklist")
            {
                //?dw_contract.Modify("lo_rectangle.pen.color=0");
            }
            else
            {
                //?dw_contract.Modify("lo_rectangle.pen.color=8421504");
            }
            if (dw_contract.GetColumnName() == "ct_key")
            {
                dwChild = idw_contract.GetChild("ct_key");
                if (dwChild.GetRow() >= 0)
                {
                    if (dwChild.GetItem<DddwContractTypes>(dwChild.GetRow()).CtRdRefMandatory == "Y")
                    {
                        dw_contract.GetControlByName("con_rd_ref_text").BackColor 
                                                  = StaticVariables.gnv_app.of_getcolorcode("CYAN");
                    }
                    else
                    {
                        dw_contract.GetControlByName("con_rd_ref_text").BackColor 
                                                  = StaticVariables.gnv_app.of_getcolorcode("WHITE");
                    }
                }
            }
        }

        public virtual void dw_contract_losefocus(object sender, EventArgs e)
        {
            int ll_row;
            dw_contract.AcceptText();
            ll_row = dw_contract.GetRow();
            if (ll_row >= 0)
            {
                is_con_rd_ref = dw_contract.GetItem<Contract>(0).ConRdRefText;
            }
            if (il_Contract_no == -(1))
            {
                MSheet lm_Menu;
                lm_Menu = this.m_sheet;
                if ((lm_Menu != null))
                {
                    //?lm_Menu.m_updatedatabase.ToolbarItemVisible = true;
                    lm_Menu.m_updatedatabase.Visible = true;
                    lm_Menu.m_updatedatabase.Enabled = true;
                }
            }
        }

        public virtual void dw_contract_retrieveend(object sender, EventArgs e)
        {
            if (!((dw_contract.GetItem<Contract>(0).ConDateTerminated == null)))
            {
                dw_contract.GetControlByName("con_date_terminated").BackColor = System.Drawing.SystemColors.Control;
                dw_contract.GetControlByName("con_date_terminated").Enabled = true;
            }
            if (!((idw_contract.GetItem<Contract>(0).ConDateTerminated == null)))
            {
                ib_terminated = true;
            }
            else
            {
                ib_terminated = false;
            }
        }

        public virtual void dw_contract_getfocus(object sender, EventArgs e)
        {
            dw_contract.URdsDw_GetFocus(sender, e);
            if (il_Contract_no == -(1))
            {
                MSheet lm_Menu;
                lm_Menu = this.m_sheet;
                if ((lm_Menu != null))
                {
                    //lm_Menu.m_updatedatabase.ToolbarItemVisible = true;
                    lm_Menu.m_updatedatabase.Visible = true;
                    lm_Menu.m_updatedatabase.Enabled = true;
                }
            }
        }

        public virtual void dw_contract_address_doubleclicked(object sender, EventArgs e)
        {
            dw_contract_address.URdsDw_DoubleClick(sender, e);
            int row = dw_contract_address.GetRow();
            NRoad lnv_road;
            int ll_adr_id;
            int? ll_cust_id;
            if (dw_contract_address.GetRow() < 0)
            {
                return;
            }
            dw_contract_address.SelectRow(0, false);
            dw_contract_address.SelectRow(dw_contract_address.GetRow() + 1, true);
            ll_adr_id = dw_contract_address.GetItem<AddressList>(row).AdrId.GetValueOrDefault();
            ll_cust_id = null;
            //lnv_road = StaticVariables.gnv_app.of_get_road_map();

            this.Cursor = Cursors.WaitCursor;
            if (StaticVariables.gnv_app.of_get_road_map() == null)
            {
                //p: changed the user object NRoad to use lists of business entities instead of data windows 
                //   otherwise loads very slow
                lnv_road = ((NRoad)StaticVariables.gnv_app.of_set_road_map(new NRoad("arraysUsed")));
            }
            else
            {
                lnv_road = ((NRoad)StaticVariables.gnv_app.of_get_road_map());
            }
            //  lnv_road.of_open_address ( ll_adr_id, ll_cust_id)
            lnv_road.of_open_address(ll_adr_id, ll_cust_id.GetValueOrDefault(), 1);

            this.Cursor = Cursors.Default;
        }

        public virtual void em_custlist_updated_modified(object sender, EventArgs e)
        {
            //  TJB  SR4657  June05
            //  Set the ib_custlist_changed flag as appropriate.
            //  If the value has changed, turn the 'save' toolbar  button on
            MSheet lm_Menu;
            lm_Menu = this.m_sheet;
            if ((lm_Menu != null))
            {
                if (of_custlist_changed())
                {
                    ib_custlist_changed = true;
                    //?lm_Menu.m_updatedatabase.ToolbarItemVisible = true;
                    lm_Menu.m_updatedatabase.Visible = true;
                    lm_Menu.m_updatedatabase.Enabled = true;
                }
                else
                {
                    ib_custlist_changed = false;
                    //?lm_Menu.m_updatedatabase.ToolbarItemVisible = false;
                    lm_Menu.m_updatedatabase.Visible = false;
                    lm_Menu.m_updatedatabase.Enabled = false;
                }
            }
            return;//return 0;
        }

        public virtual void dw_renewals_clicked(object sender, EventArgs e)
        {
            dw_renewals.URdsDw_Clicked(sender, e);
        }

        public virtual void dw_renewals_doubleclicked(object sender, EventArgs e)
        {
            dw_renewals.URdsDw_DoubleClick(sender, e);
            WRenewal2001 lw_Renewal2001;
            string ls_Title;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            int row = dw_renewals.GetRow();
            if (row < 0)
            {
                return;
            }
            // create message area for passing parameters
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("Contract_no", dw_renewals.GetItem<Renewals>(row).ContractNo.GetValueOrDefault());
            lnv_Criteria.of_addcriteria("Contract_seq_number", dw_renewals.GetItem<Renewals>(row).ContractSeqNumber.GetValueOrDefault());
            lnv_msg.of_addcriteria(lnv_Criteria);
            ls_Title = "Renewal: " + dw_renewals.GetItem<Renewals>(row).ContractNo.GetValueOrDefault().ToString() 
                                   + "/" + idw_renewals.GetItem<Renewals>(row).ContractSeqNumber.GetValueOrDefault().ToString() 
                                   + " " + idw_contract.GetItem<Contract>(0).ConTitle;
            if (!((StaticVariables.gnv_app.of_findwindow(ls_Title, "w_Renewal2001") != null)))
            {
                //OpenSheetWithParm(lw_Renewal2001, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                lw_Renewal2001 = new WRenewal2001();
                lw_Renewal2001.MdiParent = StaticVariables.MainMDI;
                lw_Renewal2001.Show();
            }
        }

        public virtual void dw_route_frequency_doubleclicked(object sender, EventArgs e)
        {
            dw_route_frequency.URdsDw_DoubleClick(sender, e);
            WFrequencies2001 lw_Frequencies2001;
            int Contract_no;
            string ls_Title;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            int row = dw_route_frequency.GetRow();
            // create uo
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            if (row < 0)
            {
                return;
            }
            if (dw_route_frequency.GetItem<RouteFrequency>(row).RfActive == "N")
            {
                MessageBox.Show("The Frequency you have selected is not Active. \n" 
                                + "You will not be able to sequence customers for this frequency."
                                , "Contract"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//return 1;
            }
            if (dw_route_frequency.GetItem<RouteFrequency>(row).IsNew 
                || (dw_route_frequency.GetItem<RouteFrequency>(row).IsNew 
                    && dw_route_frequency.GetItem<RouteFrequency>(row).IsDirty))
            {
                MessageBox.Show("The current frequency has not been saved to the database.  \n" 
                                + "Please save before opening."
                                , "Contract"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lnv_Criteria.of_addcriteria("Contract_no", dw_route_frequency.GetItem<RouteFrequency>(row).ContractNo.GetValueOrDefault());
            lnv_Criteria.of_addcriteria("Sf_key", dw_route_frequency.GetItem<RouteFrequency>(row).SfKey.GetValueOrDefault());
            lnv_Criteria.of_addcriteria("Rf_delivery_days", dw_route_frequency.GetItem<RouteFrequency>(row).RfDeliveryDays);
            lnv_Criteria.of_addcriteria("Dw_route_freq", dw_route_frequency);
            lnv_msg.of_addcriteria(lnv_Criteria);
            ls_Title = " (" + dw_route_frequency.GetItem<RouteFrequency>(row).ContractNo.GetValueOrDefault().ToString() + ") ";
            if (((StaticVariables.gnv_app.of_findwindow(ls_Title, "w_Frequencies2001") == null)))
            {
                //OpenSheetWithParm(lw_Frequencies2001, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                lw_Frequencies2001 = new WFrequencies2001();
                lw_Frequencies2001.MdiParent = StaticVariables.MainMDI;
                lw_Frequencies2001.Show();
            }
        }

        public virtual void dw_route_frequency_clicked(object sender, EventArgs e)
        {
            dw_route_frequency.URdsDw_Clicked(sender, e);
        }

        public virtual void dw_route_frequency_getfocus(object sender, EventArgs e)
        {
            dw_route_frequency.URdsDw_GetFocus(sender, e);
            dw_route_frequency_ue_enabledistance();//PostEvent("ue_enabledistance");
        }

        public virtual void dw_route_audit_doubleclicked(object sender, EventArgs e)
        {
            dw_route_audit.URdsDw_DoubleClick(sender, e);
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            int row = dw_route_audit.GetRow();
            //  TJB 6-Aug-2004 SR4577
            //  Added test for presence of anything to display  ( outer if-then-else)
            if (dw_route_audit.RowCount == 0 || (dw_route_audit.GetItem<RouteAuditListing>(row).ContractNo == null))
            {
                MessageBox.Show("There is nothing to display"
                                , "Route Audit"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // create uo
                lnv_Criteria = new NCriteria();
                lnv_msg = new NRdsMsg();
                Cursor.Current = Cursors.WaitCursor;
                if (dw_route_audit.RowCount != 0)
                {
                    if (row >= 0)
                    {
                        lnv_Criteria.of_addcriteria("contract_no", dw_route_audit.GetItem<RouteAuditListing>(row).ContractNo.GetValueOrDefault());
                        lnv_Criteria.of_addcriteria("contract_title", idw_contract.GetItem<Contract>(0).ConTitle);
                        lnv_Criteria.of_addcriteria("ra_date_of_check", dw_route_audit.GetItem<RouteAuditListing>(row).RaDateOfCheck.GetValueOrDefault().Date);
                        lnv_msg.of_addcriteria(lnv_Criteria);
                        //OpenSheetWithParm(w_route_audit, lnv_msg, w_main_mdi, 0, original!);
                        StaticMessage.PowerObjectParm = lnv_msg;
                        WRouteAudit w_route_audit = new WRouteAudit();
                        w_route_audit.MdiParent = StaticVariables.MainMDI;
                        w_route_audit.Show();
                    }
                }
            }
        }

        public virtual void dw_route_audit_clicked(object sender, EventArgs e)
        {
            dw_route_audit.URdsDw_Clicked(sender, e);
        }

        public virtual void dw_contract_allowances_doubleclicked(object sender, EventArgs e)
        {
            dw_contract_allowances.URdsDw_DoubleClick(sender, e);
            of_display_allowance(dw_contract_allowances.GetRow());
        }

        public virtual void dw_artical_counts_clicked(object sender, EventArgs e)
        {
            dw_artical_counts.URdsDw_Clicked(sender, e);
        }

        public virtual void dw_artical_counts_doubleclicked(object sender, EventArgs e)
        {
            dw_artical_counts.URdsDw_DoubleClick(sender, e);
            if (dw_artical_counts.RowCount > 0)
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!((dw_artical_counts.GetItem<ContractArticalCounts>(1).AcStartWeekPeriod.GetValueOrDefault().Date == null)))
                {
                    //OpenWithParm(w_full_artical_count_form, dw_artical_counts);
                    StaticMessage.PowerObjectParm = ((URdsDw)this.GetContainerControl().ActiveControl).DataObject;
                    WFullArticalCountForm w_full_artical_count_form = new WFullArticalCountForm();
                    w_full_artical_count_form.ShowDialog();

                    for (int i = 0; i < dw_artical_counts.DataObject.RowCount; i++)
                    {
                        ((DContractArticalCountsTest)(((TableLayoutPanel)dw_artical_counts.GetControlByName("tbPanel")).Controls[i])).BindingSource.CurrencyManager.Refresh();
                    }
                }
                else
                {
                    //OpenSheet(wNewArt, w_main_mdi, 0, original!);
                    WAddArticleCounts wNewArt = new WAddArticleCounts();
                    wNewArt.MdiParent = StaticVariables.MainMDI;
                    wNewArt.Show();
                }
            }
        }

        public virtual void dw_artical_counts_losefocus(object sender, EventArgs e)
        {
            // Force update so that the article count on the renewal window is accurate
            //! dw_artical_counts.Update();
            dw_artical_counts.Save();
            //?Commit;
        }

        public virtual void dw_piece_rates_doubleclicked(object sender, EventArgs e)
        {
            of_display_breakdown(dw_piece_rates.GetRow());
        }

        public virtual void dw_piece_rates_clicked(object sender, EventArgs e)
        {
            dw_piece_rates.URdsDw_Clicked(sender, e);
        }

        public virtual void dw_cmbs_doubleclicked(object sender, EventArgs e)
        {
            dw_cmbs.URdsDw_DoubleClick(sender, e);
            //  TJB  SR4659  July 2005
            int ll_rows;
            int ll_del;
            int ll_cmb_id;
            int ll_tc_id;
            int ll_postcode_id;
            int ll_contract_no;
            string ls_con_title;
            string ls_rdno;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            int row = dw_cmbs.GetRow();
            idw_cmb.SelectRow(row + 1, true);
            //  Check to see if any rows have been marked as deleted.
            //  If there are, ask whether the user wants to do the deletion.
            //  The deletion will be lost after the insert  ( it refreshes 
            //  the display from the database to include the new CMBs).
            ll_del = idw_cmb.DataObject.DeletedCount;
            if (ll_del > 0)
            {
                string ls_temp1;
                string ls_temp2;
                if (ll_del == 1)
                {
                    ls_temp1 = "There is 1 row ";
                    ls_temp2 = "it";
                }
                else
                {
                    ls_temp1 = "There are " + ll_del.ToString() + " rows ";
                    ls_temp2 = "them";
                }
                if (MessageBox.Show(ls_temp1 + " marked for deletion.\n" 
                                    + "Delete " + ls_temp2 + " now?"
                                    , "Warning"
                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                    , MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    //! idw_cmb.Update();
                    idw_cmb.Save();
                }
            }
            ll_rows = idw_cmb.RowCount;
            if (ll_rows == 0 || row < 0)
            {
                MessageBox.Show("There is nothing to display"
                                ,"Warning"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // create uo
                lnv_Criteria = new NCriteria();
                lnv_msg = new NRdsMsg();
                Cursor.Current = Cursors.WaitCursor;
                ll_cmb_id = idw_cmb.GetItem<CmbAddressList>(row).CmbId.GetValueOrDefault();
                ll_contract_no = idw_cmb.GetItem<CmbAddressList>(row).ContractNo.GetValueOrDefault();
                ls_con_title = idw_contract.GetItem<Contract>(0).ConTitle;
                ll_tc_id = idw_cmb.GetItem<CmbAddressList>(row).TcId.GetValueOrDefault();
                ll_postcode_id = idw_cmb.GetItem<CmbAddressList>(row).PostCodeId.GetValueOrDefault();
                ls_rdno = idw_cmb.GetItem<CmbAddressList>(row).AdrRdNo;
                lnv_Criteria.of_addcriteria("cmb_id", ll_cmb_id);
                lnv_Criteria.of_addcriteria("contract_no", ll_contract_no);
                lnv_Criteria.of_addcriteria("contract_title", ls_con_title);
                lnv_Criteria.of_addcriteria("tc_id", ll_tc_id);
                lnv_Criteria.of_addcriteria("post_code_id", ll_postcode_id);
                lnv_Criteria.of_addcriteria("adr_rd_no", ls_rdno);
                lnv_msg.of_addcriteria(lnv_Criteria);
                //OpenSheetWithParm(w_cmb_address_detail, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                WCmbAddressDetail w_cmb_address_detail = new WCmbAddressDetail();
                w_cmb_address_detail.MdiParent = StaticVariables.MainMDI;
                w_cmb_address_detail.Show();
            }
        }

        public virtual void dw_cmbs_getfocus(object sender, EventArgs e)
        {
            //  TJB  SR4659  July 2005
            //  If this window gets focus, reset the toolbar icons
            // ---------------------------------------------------
            //  TJB  Release 6.8.9 fixup  Nov 2005
            //  Changed to use wf_set_cmb_privs and u_rds_dw.uf_setToolbar
            dw_cmbs.URdsDw_GetFocus(sender, e);
            wf_set_cmb_privs();
            idw_cmb.uf_settoolbar();
        }

        public virtual void dw_cmbs_clicked(object sender, EventArgs e)
        {
            dw_cmbs.URdsDw_Clicked(sender, e);
            int row = idw_cmb.GetRow();
        }

        private void cb_seq_clicked(object sender, EventArgs e)
        {   // TJB  Sequencing Review  Jan-2011
            // Added cb_seq button to Address tab, and cb_seq_clicked event

            NParameters lnv_Parameters;
            Cursor.Current = Cursors.WaitCursor;
            lnv_Parameters = new NParameters();
            lnv_Parameters.longparm = il_Contract_no;
            lnv_Parameters.integerparm = 1;         // Dummy value; was il_sf_key from WFrequencies2001
            lnv_Parameters.stringparm = "YYYYYYN";  // Dummy value; was is_delivery_days from WFrequencies2001;
            StaticMessage.PowerObjectParm = lnv_Parameters;
            WCustomerSequencer w_customer_sequencer = OpenSheet<WCustomerSequencer>(StaticVariables.MainMDI);
        }

        #endregion

        private void tab_contract_selectionchanging(object sender, TabControlCancelEventArgs e)
        {
            int thisTabIndex = tab_contract.SelectedIndex;
            if (oldTabIndex == thisTabIndex)
                return;
            
            Cursor.Current = Cursors.WaitCursor;
            this.SuspendLayout();
            string thisTabName = tab_contract.TabPages[thisTabIndex].Text.ToLower().Trim();
            string oldTabName = tab_contract.TabPages[oldTabIndex].Text.ToLower().Trim();
            //if (tabName == "freight allocations")
            //{
            //    idw_freight_allocations.uf_settoolbar();
            //}
            string t; ;
            t = thisTabName;
            t = oldTabName;
            if (oldTabName == "fixed assets")
            {
                int nRow = dw_fixed_assets.GetRow();
                /* -------------------- Debugging  ------------------------ //
                for (nRow = 0; nRow < dw_fixed_assets.RowCount; nRow++)
                {
                    int? nContractNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo;
                    string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                    int? nStripHeight = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ShHeight;
                    int? nShId = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ShId;
                    int nShIdIndex = this.sh_id.SelectedIndex;
                    sAssetNo = (sAssetNo == null) ? "null" : sAssetNo.ToString();
                    string sContractNo = (nContractNo == null) ? "null" : nContractNo.ToString();
                    string sStripHeight = (nStripHeight == null) ? "null" : nStripHeight.ToString();
                    string sShId = (nShId == null) ? "null" : nShId.ToString();

                    MessageBox.Show("Fixed Assets Selection Changing \n\n"
                                    + "thisTabName = " + thisTabName + ", oldTabName = " + oldTabName + "\n"
                                    + "nRow = " + nRow.ToString() + "\n"
                                    + "nModified = " + nModified.ToString() + "\n"
                                    + "nContractNo = " + sContractNo + "\n"
                                    + "sAssetNo = " + sAssetNo + "\n"
                                    + "nStripHeight = " + sStripHeight + "\n"
                                    + "nShId = " + sShId + "\n"
                                    + "nShIdIndex = " + nShIdIndex.ToString() + "\n"
                                    , "tab_contract_selectionchanging");
                }
                // -------------------- Debugging  ------------------------ */

                // TJB  RPCR_026  July-2011: added
                // Ask whether the uesr wants to save now
                fixed_asset_save(MessageBoxButtons.YesNoCancel);
                
/*
                bool bSaveChanges = true;
                int nModified = dw_fixed_assets.ModifiedCount();
                int nDeleted = dw_fixed_assets.DataObject.DeletedCount;
                if (nModified > 0 || nDeleted > 0)
                {
                    DialogResult ans;
                    ans = MessageBox.Show("Do you want to save changes? \n"
                                    , "Fixed Assets"
                                    , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                    , MessageBoxDefaultButton.Button1);
                    if (ans == DialogResult.Yes)
                    {
                        bSaveChanges = true;
/*
                        nRow = dw_fixed_assets.GetRow();
                        int? nContractNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo;
                        string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
                        string sContractNo = (nContractNo == null) ? "null" : nContractNo.ToString();

                        if (nContractNo != il_Contract_no)
                        {
                            ans = MessageBox.Show("Please confirm that you want to assign fixed asset \n"
                                                + sAssetNo + " to contract " + sContractNo + ".\n"
                                                , "Fixed Assets"
                                                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                                                , MessageBoxDefaultButton.Button1 );
                        }
*/
/*                    }
                    else if (ans == DialogResult.No)
                    {
                        dw_fixed_assets.AcceptText();
                        //dw_fixed_assets.ResetUpdate();
                        bSaveChanges = false;
                    }
                    else  // DialogResult = Cancel //
                    {
                        tab_contract.SelectedIndex = oldTabIndex;
                        dw_fixed_assets.URdsDw_GetFocus(null, null);
                        bSaveChanges = false;
                    }
                    if (bSaveChanges)
                    {
                        dw_fixed_assets.Save();
                    }
                }
*/
            }
            this.ResumeLayout(true);
        }

        private void dw_freight_allocations_validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int thisTabIndex = this.tabpage_freight_allocations.TabIndex;

             // Check for any changes to idw_freight_allocations
            idw_freight_allocations.AcceptText();

            int? nTotPct = idw_freight_allocations.GetItem<FreightAllocations>(0).TotalAlloc;
            if (nTotPct == null || nTotPct == 0)
            {
                // If the total % == 0, assume the record is new and the user hasn't entered
                // anything.  Treat this case as though the user had answered 'No' to the 
                // 'Do you want to save changes' question.  This allows the user to visit the 
                // Freight allocations tab without being forced to create a new record.
                idw_freight_allocations.ResetUpdate();
                wf_set_freight_allocations_toolbar();
                return;
            }

            int nDeleted = idw_freight_allocations.DataObject.DeletedCount;
            int nModified = idw_freight_allocations.ModifiedCount();
            if (nDeleted > 0 || nModified > 0)
            {
                DialogResult ans;
                ans = MessageBox.Show("Do you want to save changes?"
                                        , "Freight Allocations"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    if (of_validate_freight_allocations())
                    {
                        int rc = idw_freight_allocations.Save();
                        if (rc < 0)
                        {
                            // The save should never fail ... but if it does, tell the user 
                            // and stay on the Freight allocations tab.
                            MessageBox.Show("Save failed!", "Freight Allocations" );
                            e.Cancel = true;
                            oldTabIndex = tab_contract.SelectedIndex = thisTabIndex;
                            idw_freight_allocations.URdsDw_GetFocus(null, null);
                        }
                        wf_set_freight_allocations_toolbar();
                    }
                    else
                    {
                        // If validation fails, don't let the change in tabs proceed.
                        e.Cancel = true;
                        oldTabIndex = tab_contract.SelectedIndex = thisTabIndex;
                        idw_freight_allocations.URdsDw_GetFocus(null, null);
                        wf_set_freight_allocations_toolbar();
                    }
                }
                else
                {
                    // If the user says 'No' to saving the changes, this changes the 'modified' status
                    // of anything that had been changed.
                    idw_freight_allocations.ResetUpdate();
                    wf_set_freight_allocations_toolbar();
                }
            }
        }

        void sh_id_LostFocus(object sender, System.EventArgs e)
        {
            // TJB  RPCR_026  July-2011: Added
            this.sh_id.DisplayMember = "ShHeight";
        }

        void sh_id_Click(object sender, System.EventArgs e)
        {
            // TJB  RPCR_026  July-2011: Added
            if (this.sh_id.DroppedDown)
                this.sh_id.DisplayMember = "";
            else
                this.sh_id.DisplayMember = "ShHeight";
        }

        void sh_id_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // TJB  RPCR_026  July-2011: Added
            int selectedIndex = this.sh_id.SelectedIndex;
            int nRow = this.dw_fixed_assets.GetRow();
            if (nRow >= 0)
            {
                // Where there are multiple records, update all with the new ShId value
                int nRows = this.dw_fixed_assets.RowCount;
                for (int i = 0; i < nRows; i++)
                {
                    int? currentShId = dw_fixed_assets.GetItem<ContractFixedAssets>(i).ShId;
                    int nShId = (currentShId == null) ? 0 : (int)currentShId;
                    if ((selectedIndex >= 0) && (nShId > 0) && ((selectedIndex + 1) != nShId))
                    {
                        dw_fixed_assets.GetItem<ContractFixedAssets>(i).ShId = selectedIndex + 1;
                    }
                }
            }
        }

        private int of_getDefaultStripHeightId()
        {
            // TJB  RPCR_026  July-2011: Added
            int _DefaultStripHeightId = 4;

            _DefaultStripHeightId = RDSDataService.GetDefaultStripHeightId();
            if (_DefaultStripHeightId < 0)
            {
                MessageBox.Show("Default strip height not found.  \n"
                                + "Using 40."
                                , "Error");
                _DefaultStripHeightId = 3;
            }
            return _DefaultStripHeightId;
        }

        private void cb_fixed_assets_add_Click(object sender, EventArgs e)
        {
            // TJB  RPCR_026  July-2011
            // Replaced the 'Insert' toolbar button with the 'add' button
            // because I couldn't get the generated asset number to display 
            // initially.
            
            // Determine the new asset's number
            int nFixedAssetNo = of_get_nextsequence("FixedAssetNo");
            string sFixedAssetNo = "RP" + nFixedAssetNo.ToString();

            // Determine the Contract's strip height (here the strip height 's ID)
            // If there are existing assets, it has one; use that.
            // Otherwise, determine the default strip height and use that.
            int nDefaultShId = 4;
            if (dw_fixed_assets.RowCount > 0)
                nDefaultShId = (int)dw_fixed_assets.GetItem<ContractFixedAssets>(0).ShId;
            else
            {
                nDefaultShId = of_getDefaultStripHeightId();
            }
            // Update the strip height displayed
            this.sh_id.SelectedIndex = nDefaultShId - 1;

            // Load the new asset's number and current contract number into the 
            // hidden objects.  Code in DContractFixedAssets load event handler
            // (fa_load) uses these to populate the initial display (somewhat 
            // of a hack :-).
            this.new_asset.Text = sFixedAssetNo;
            this.new_contract.Text = il_Contract_no.ToString();

            // Now insert the new record
            dw_fixed_assets.InsertItem<ContractFixedAssets>(0);

            // Clear these values so that the load event handler can distinguish 
            // between newly-inserted assets and dummy ones.
            this.new_asset.Text = "";
            this.new_contract.Text = "";

            int nRow = 0;
            /* ------------------ Debugging  ------------------------ //
            int nRow = dw_fixed_assets.GetRow();

            string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
            int?  nContract = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo;
            int? nShId = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ShId;

            MessageBox.Show("InsertItem: Immediately after ... \n"
                            + "nRow = " + nRow.ToString() + "\n"
                            + "Asset " + sAssetNo + "\n"
                            + "Contract = " + nContract.ToString() + "\n"
                            + "ShID = " + nShId.ToString() + "\n"
                            , "cb_fixed_assets_add_Click");
            // ------------------ Debugging  ------------------------ */

            // The new asset has been inserted at Row = 0, but getRow() doesn't return that.
            // Set nRow to the inserted row so we can use it to populate the row with some
            // initial values.
            nRow = 0;
            dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo = sFixedAssetNo;
            dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ContractNo = il_Contract_no;
            dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).ShId = nDefaultShId;
            dw_fixed_assets.AcceptText();

            // This SelectRow was an attempts to get the asset number to display on 
            // new asset but to no avail (see hack above)
            dw_fixed_assets.SelectRow(nRow, true);
        }

        private void cb_fixed_assets_delete_Click(object sender, EventArgs e)
        {
            // TJB  RPCR_026  July-2011
            // Replaced the 'Delete' toolbar button with the 'delete' button
            // to give me a chance to abort the delete.

            if (dw_fixed_assets.RowCount == 0)
            {
                MessageBox.Show("Nothing to delete?", "Warning"
                                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nRow = dw_fixed_assets.GetRow();

            string sAssetNo = dw_fixed_assets.GetItem<ContractFixedAssets>(nRow).FaFixedAssetNo;
            string msg = "Are you sure you want to delete asset " + sAssetNo + "?";
            DialogResult ans = MessageBox.Show(msg, "Delete Asset"
                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question
                                    , MessageBoxDefaultButton.Button1);
            if (ans == DialogResult.Yes)
            {
                dw_fixed_assets.DeleteItemAt(nRow);
                fixed_asset_save(MessageBoxButtons.YesNo);
            }
            return;
        }

        private void cb_fixed_assets_save_Click(object sender, EventArgs e)
        {
            // TJB  RPCR_026  July-2011
            // Replaced the 'Save' toolbar button with a 'Save' button on the Fixed
            // Assets tab.  Mostly for consistency and better control of the dialog.

            // Don't ask if the user wants to save since they've chosen to by clicking
            // the "Save" button.
            fixed_asset_save();
        }

        private void fixed_asset_save(MessageBoxButtons MessageBox_Buttons)
        {
            // TJB  RPCR_026  July-2011
            // Two variants of the Fixed Asset Save function.  This one asks 
            // for confirmation, assuming the user is going to pass either 
            // the 'YesNo' or 'YesNoCancel' buttons.
            //
            bool bSaveChanges = true;
            int nModified = dw_fixed_assets.ModifiedCount();
            int nDeleted = dw_fixed_assets.DataObject.DeletedCount;
            if (nModified > 0 || nDeleted > 0)
            {
                DialogResult ans;
                ans = MessageBox.Show("Do you want to save changes? \n"
                                , "Fixed Assets"
                                , MessageBox_Buttons, MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button1);
                if (ans == DialogResult.Yes)
                {
                    bSaveChanges = true;
                }
                else if (ans == DialogResult.No)
                {
                    dw_fixed_assets.AcceptText();
                    bSaveChanges = false;
                }
                else  // DialogResult = Cancel //
                {
                    dw_fixed_assets.URdsDw_GetFocus(null, null);
                    bSaveChanges = false;
                }
                if (bSaveChanges)
                    fixed_asset_save();
            }
        }

        private void fixed_asset_save()
        {
            // TJB  RPCR_026  July-2011
            // Two variants of the Fixed Asset Save function.  This one 
            // doesn't ask - it goes ahead and does it.
            this.SuspendLayout();

            dw_fixed_assets.Save();

            this.ResumeLayout(true);
            //int nModified = dw_fixed_assets.ModifiedCount();
            //int nDeleted = dw_fixed_assets.DataObject.DeletedCount;
            //if (nModified > 0 || nDeleted > 0)
            //{
            //    MessageBox.Show("After save/nosave \n"
            //                    + "nModified = " + nModified.ToString() + "\n"
            //                    + "nDeleted = " + nDeleted.ToString() + "\n"
            //                    , "fixed_asset_save");
            //}
        }

        private void cb_add_old_Click(object sender, EventArgs e)
        {
            // TJB  RPCR_026  July-2011
            StaticVariables.gnv_app.of_get_parameters().integerparm = il_Contract_no;
            StaticVariables.gnv_app.of_get_parameters().stringparm = idw_contract.GetItem<Contract>(0).ConTitle;
            Cursor.Current = Cursors.WaitCursor;

            WAddFixedAsset w_add_fixed_asset = new WAddFixedAsset();
            w_add_fixed_asset.ShowDialog();

            bool result = StaticVariables.gnv_app.of_get_parameters().booleanparm;
            if (result)
            {
                dw_fixed_assets.Reset();
                dw_fixed_assets.Retrieve(new object[] { il_Contract_no });
            }
        }
    }
}
