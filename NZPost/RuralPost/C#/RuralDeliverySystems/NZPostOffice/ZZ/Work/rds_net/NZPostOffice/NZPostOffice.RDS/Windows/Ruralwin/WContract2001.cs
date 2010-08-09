using System;
using System.Windows.Forms;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.DataService;
using NZPostOffice.Shared;
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
    public class WContract2001 : WAncestorWindow
    {
        // TJB RPCR_017 July-2010
        // Changed WAddAllowance significantly.  Obsolete version now WAddAllowance0.cs.
        // Added lookup of copntract effective date and pass to WAddAllowance.

        #region Define
        public int il_Contract_no;
        public int il_con_active_seq;

        public int il_count;

        public string is_tmp_rdno = String.Empty;

        public WContract2001 iw_Parent;

        public MSheet im_menu;

        public URdsDw idw_fixed_assets;

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

        public int il_Contract = 1;

        public bool ib_HighLiteRows;

        public string is_ErrorColumn = String.Empty;

        public int il_Row;

        public string is_OtherValEvent = String.Empty;

        public int il_Region;

        public bool ibEditingCustList;

        public int ilClickedRow;

        public int ilCustHandle;

        public bool ibAddArt;

        public int ilArtHandle;

        public bool ibAudit;

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

        #endregion

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

            dw_cmbs.DataObject = new DCmbAddressList();
            dw_cmbs.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_route_frequency.DataObject = new DRouteFrequency();
            dw_route_frequency.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_types.DataObject = new DTypesForContract();
            dw_types.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_piece_rates.DataObject = new DContractPieceRates();
            dw_piece_rates.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from InitializeComponent
            dw_contract.Constructor += new UserEventDelegate(dw_contract_constructor);
            dw_contract.URdsDwItemFocuschanged += new EventDelegate(dw_contract_itemfocuschanged);
            dw_contract.PfcPostUpdate += new UserEventDelegate(dw_contract_pfc_postupdate);
            dw_contract.WinValidate += new UserEventDelegate2(of_validate); //added by jlwangd
            dw_contract.DataObject.RetrieveEnd += new EventHandler(dw_contract_retrieveend);
            ((Button)(dw_contract.GetControlByName("bo_button"))).Click += new EventHandler(dw_contract_clicked);
            ((Button)(dw_contract.GetControlByName("lo_button"))).Click += new EventHandler(dw_contract_clicked);

            dw_contract_address.Constructor += new UserEventDelegate(dw_contract_address_constructor);
            dw_contract_address.PfcPreInsertRow += new UserEventDelegate1(dw_contract_address_pfc_preinsertrow);
            dw_contract_address.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
            ((DAddressList)dw_contract_address.DataObject).CellDoubleClick += new EventHandler(dw_contract_address_doubleclicked);

            dw_renewals.Constructor += new UserEventDelegate(dw_renewals_constructor);
            dw_renewals.PfcPreInsertRow += new UserEventDelegate1(dw_renewals_pfc_preinsertrow);
            dw_renewals.PfcPreDeleteRow += new UserEventDelegate1(dw_renewals_pfc_predeleterow);
            dw_renewals.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
            ((DRenewals)dw_renewals.DataObject).CellClick += new EventHandler(dw_renewals_clicked);
            ((DRenewals)dw_renewals.DataObject).CellDoubleClick += new EventHandler(dw_renewals_doubleclicked);

            dw_route_frequency.Constructor += new UserEventDelegate(dw_route_frequency_constructor);
            ((DRouteFrequency)dw_route_frequency.DataObject).CellDoubleClick += new EventHandler(dw_route_frequency_doubleclicked);
            ((DRouteFrequency)dw_route_frequency.DataObject).CellClick += new EventHandler(dw_route_frequency_clicked);
            dw_route_frequency.PfcValidation += new UserEventDelegate1(dw_route_frequency_pfc_validation);

            dw_route_audit.Constructor += new UserEventDelegate(dw_route_audit_constructor);
            ((DRouteAuditListing)dw_route_audit.DataObject).CellDoubleClick += new EventHandler(dw_route_audit_doubleclicked);
            ((DRouteAuditListing)dw_route_audit.DataObject).CellClick += new EventHandler(dw_route_audit_clicked);
            dw_route_audit.PfcInsertRow += new UserEventDelegate(dw_route_audit_pfc_preinsertrow);

            dw_types.Constructor += new UserEventDelegate(dw_types_constructor);
            dw_types.PfcValidation += new UserEventDelegate1(dw_types_pfc_validation);
            dw_types.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang

            dw_contract_allowances.Constructor += new UserEventDelegate(dw_contract_allowances_constructor);
            ((DContractAllowancesV2)dw_contract_allowances.DataObject).CellDoubleClick += new EventHandler(dw_contract_allowances_doubleclicked);
            dw_contract_allowances.PfcInsertRow = new UserEventDelegate(dw_contract_allowances_pfc_preinsertrow);
            dw_contract_allowances.PfcPreUpdate += new UserEventDelegate1(dw_contract_allowances_pfc_preupdate);
            //dw_contract_allowances.UpdateStart = new UserEventDelegate(dw_contract_allowances_updatestart);
            dw_contract_allowances.WinValidate += new UserEventDelegate2(of_validate);

            // TJB  Release 7.1.3 fixups Aug 2010: Added
            dw_contract_allowances.PfcModify = new UserEventDelegate(dw_contract_allowances_pfc_modify);

            dw_artical_counts.Constructor += new UserEventDelegate(dw_artical_counts_constructor);
            dw_artical_counts.PfcPreInsertRow += new UserEventDelegate1(dw_artical_counts_pfc_preinsertrow);
            dw_artical_counts.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang

            dw_piece_rates.Constructor += new UserEventDelegate(dw_piece_rates_constructor);
            dw_piece_rates.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
            ((DContractPieceRates)dw_piece_rates.DataObject).CellDoubleClick += new EventHandler(dw_piece_rates_doubleclicked);
            ((DContractPieceRates)dw_piece_rates.DataObject).CellClick += new EventHandler(dw_piece_rates_clicked);
            dw_fixed_assets.Constructor += new UserEventDelegate(dw_fixed_assets_constructor);
            //Metex.Windows.DataUserControl idw_fixed_assets;
            //idw_fixed_assets = new DContractFixedAssetsTest();
            //((DContractFixedAssetsTest)idw_fixed_assets).TextBoxLostFocus += new EventHandler(this.idw_fixed_assets_itemchanged);
            ((DContractFixedAssets)dw_fixed_assets.DataObject).TextBoxLostFocus += new EventHandler(dw_fixed_assets_ItemChanged);
            dw_fixed_assets.PfcValidation += new UserEventDelegate1(dw_fixed_assets_pfc_validation);
            //dw_fixed_assets.UpdateStart = new UserEventDelegate(dw_fixed_assets_updatestart);
            dw_fixed_assets.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
            dw_fixed_assets.UpdateEnd += new UserEventDelegate(dw_fix_winpfcsave);
            dw_cmbs.Constructor += new UserEventDelegate(dw_cmbs_constructor);
            ((DCmbAddressList)dw_cmbs.DataObject).CellDoubleClick += new EventHandler(dw_cmbs_doubleclicked);
            dw_cmbs.PfcDeleteRow += new UserEventDelegate(dw_cmbs_pfc_deleterow);
            dw_cmbs.PfcInsertRow = new UserEventDelegate(dw_cmbs_pfc_preinsertrow);
            dw_cmbs.PfcPreDeleteRow += new UserEventDelegate1(dw_cmbs_pfc_predeleterow);
            dw_cmbs.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
            ((DCmbAddressList)dw_cmbs.DataObject).CellClick += new EventHandler(dw_cmbs_clicked);
            //jlwang:end

            //?dw_artical_counts_constructor();
        }

        #region Form Events & Methods
        public virtual void timer()
        {
            string ls = string.Empty;
            string ls_Row;
            int ll_Row;
            //?ls = idw_piece_rates.GetObjectAtPointer();
            if (ls.Length > 0)
            {
                ls_Row = ls.Substring(ls.Length - ls.IndexOf('~'));// TextUtil.Right(ls,  ls.Len() - TextUtil.Pos (ls, '~'));
                int l_temp;
                if (int.TryParse(ls_Row, out l_temp))//if (IsNumber(ls_Row)) {
                {
                    if (System.Convert.ToInt32(ls_Row) == il_PrevRow)
                    {
                        return;
                    }
                    else
                    {
                        il_PrevRow = System.Convert.ToInt32(ls_Row);
                    }
                    idw_piece_rates.SelectRow(0, false);
                    idw_piece_rates.SelectRow(il_PrevRow, true);
                    of_display_breakdown(il_PrevRow);
                }
            }
        }

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
                idw_fixed_assets.of_set_regionid(li_Region);
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
            //idw_contract.PostEvent("getfocus");
            //PostEvent("ue_set_security");
            //if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user() == "dbond")
            //{

            //}
            BeginInvoke(new delegateInvoke(idw_contractInvoke));
            this.tab_contract_selectionchanging(new object(), new EventArgs());
            this.tab_contract_selectionchanged(new object(), new EventArgs());
        }

        private delegate void delegateInvoke();

        public virtual void idw_contractInvoke()
        {
            idw_contract.URdsDw_GetFocus(null, null);
            this.ue_set_security();//PostEvent("ue_set_security");
        }

        public virtual void ue_set_security()
        {
            ib_Opening = false;
        }

        public override int pfc_save()
        {
            base.pfc_save();
            //  TJB  SR4657  June05
            //  Fixed detection of changed updated date  ( it failed 
            //    if the original was NULL and the user closed the 
            //    window without moving out of the field first).
            int li_reply;
            MSheet lm_Menu;
            //?of_validate();
            if (of_custlist_changed())
            {
                li_reply = (MessageBox.Show("Do you wish to save the new customer list updated date?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);//MessageBox("Question", "Do you wish to save the new customer list updated date?", question!, yesno!);
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
            base.close();
            //  TJB  SR4657  June05
            //  Fixed detection of changed updated date  ( it failed 
            //    if the original was NULL and the user closed the 
            //    window without moving out of the field first).
            int li_reply;
            if (of_custlist_changed())
            {
                li_reply = (MessageBox.Show("Do you wish to save the new customer list updated date?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);// MessageBox("Question", "Do you wish to save the new customer list updated date?", question!, yesno!);
                if (li_reply == 1)
                {
                    of_update_custlist();
                }
            }
        }

        public override int closequery()
        {
            return base.closequery();//in PB it is not extend
            //DialogResult li_return = DialogResult.No;
            //if (dw_contract.ModifiedCount() > 0 || dw_contract.DataObject.DeletedCount > 0)
            //{
            //    li_return = MessageBox.Show("Do you want to save changes?", "Rural Deliver System with NPAD Extensions (enabled)", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //}
            //if (li_return == DialogResult.Yes)
            //{
            //    if (this.pfc_save() >= 1)
            //    {
            //        ib_closestatus = false;
            //        return 0;//Return ALLOW_CLOSE
            //    }
            //}
            //else if (li_return == DialogResult.No)
            //{
            //    ib_closestatus = false;
            //    return 0;//Return ALLOW_CLOSE
            //}
            //else
            //{
            //    return 1;//e.Cancel = true;
            //}
            // return 0;
        }

        #endregion

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.tab_contract = new TabControl();
            Controls.Add(tab_contract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Location = new System.Drawing.Point(1, 6);
            this.Size = new System.Drawing.Size(573, 400);

            // 
            // st_label
            // 
            st_label.Text = "w_contract2001";
            st_label.Location = new System.Drawing.Point(3, 352);

            // 
            // tab_contract
            // 
            tabpage_contract = new TabPage();
            tabpage_customers = new TabPage();
            tabpage_renewals = new TabPage();
            tabpage_frequencies = new TabPage();
            tabpage_route_audit = new TabPage();
            tabpage_types = new TabPage();
            tabpage_allowances = new TabPage();
            tabpage_article_count = new TabPage();
            tabpage_piece_rates = new TabPage();
            tabpage_fixed_assets = new TabPage();
            tabpage_cmb = new TabPage();

            tab_contract.Controls.Add(tabpage_contract);
            tab_contract.Controls.Add(tabpage_customers);
            tab_contract.Controls.Add(tabpage_renewals);
            tab_contract.Controls.Add(tabpage_frequencies);
            tab_contract.Controls.Add(tabpage_route_audit);
            tab_contract.Controls.Add(tabpage_types);
            tab_contract.Controls.Add(tabpage_allowances);
            tab_contract.Controls.Add(tabpage_article_count);
            tab_contract.Controls.Add(tabpage_piece_rates);
            tab_contract.Controls.Add(tabpage_fixed_assets);
            tab_contract.Controls.Add(tabpage_cmb);
            tab_contract.GotFocus += new EventHandler(tab_contract_GotFocus);
            tab_contract.SelectedIndex = 0;//tab_contract.selectedtab = 1;
            tab_contract.Multiline = true;
            tab_contract.BackColor = System.Drawing.SystemColors.ButtonFace;
            tab_contract.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_contract.TabIndex = 1;
            tab_contract.Height = 344;
            tab_contract.Width = 558;
            tab_contract.Top = 4;
            tab_contract.Left = 3;
            tab_contract.Tag = "ComponentName=Contract;";
            tab_contract.SizeMode = TabSizeMode.FillToRight;
            tab_contract.SelectedIndexChanged += new EventHandler(tab_contract_selectionchanging);
            tab_contract.SelectedIndexChanged += new EventHandler(tab_contract_selectionchanged);
            // 
            // tabpage_contract
            // 
            dw_contract = new URdsDw();
            //!dw_contract.DataObject = new DContract();
            tabpage_contract.Controls.Add(dw_contract);
            tabpage_contract.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_contract.Text = "Contract";
            tabpage_contract.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_contract.Size = new System.Drawing.Size(550, 315);
            tabpage_contract.Top = 25;
            tabpage_contract.Left = 3;
            tabpage_contract.Visible = false;
            tabpage_contract.Tag = "ComponentName=Contract;";
            // 
            // dw_contract
            // 
            //!dw_contract.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_contract.VerticalScroll.Visible = false;
            dw_contract.TabIndex = 2;
            dw_contract.Top = 1;
            dw_contract.Dock = DockStyle.Fill;
            dw_contract.Size = new System.Drawing.Size(521, 288);

            dw_contract.GotFocus += new EventHandler(dw_contract_getfocus);
            dw_contract.LostFocus += new EventHandler(dw_contract_losefocus);
            //?dw_contract.ItemChanged += new EventHandler(dw_contract_itemchanged);

            //dw_contract.Constructor += new UserEventDelegate(dw_contract_constructor);
            //dw_contract.URdsDwItemFocuschanged += new EventDelegate(dw_contract_itemfocuschanged);
            //dw_contract.PfcPostUpdate += new UserEventDelegate(dw_contract_pfc_postupdate);
            //dw_contract.WinValidate += new UserEventDelegate2(of_validate); //added by jlwangd
            //dw_contract.DataObject.RetrieveEnd += new EventHandler(dw_contract_retrieveend);
            //((Button)(dw_contract.GetControlByName("bo_button"))).Click += new EventHandler(dw_contract_clicked);
            //((Button)(dw_contract.GetControlByName("lo_button"))).Click += new EventHandler(dw_contract_clicked);

            // 
            // tabpage_customers
            // 
            dw_contract_address = new URdsDw();
            //!dw_contract_address.DataObject = new DAddressList();
            //!dw_contract_address.DataObject.BorderStyle = BorderStyle.Fixed3D;
            st_custlist_print = new Label();
            st_custlist_updated = new Label();
            em_custlist_printed = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();// MaskedTextBox();
            em_custlist_updated = new NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox();// MaskedTextBox();
            tabpage_customers.Controls.Add(dw_contract_address);
            tabpage_customers.Controls.Add(st_custlist_print);
            tabpage_customers.Controls.Add(st_custlist_updated);
            tabpage_customers.Controls.Add(em_custlist_printed);
            tabpage_customers.Controls.Add(em_custlist_updated);
            tabpage_customers.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_customers.Text = "Addresses";
            tabpage_customers.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_customers.Size = new System.Drawing.Size(550, 315);
            tabpage_customers.Top = 25;
            tabpage_customers.Left = 3;
            tabpage_customers.Visible = false;
            tabpage_customers.Tag = "ComponentName=Address;";
            // 
            // dw_contract_address
            // 
            dw_contract_address.TabIndex = 1;
            dw_contract_address.Size = new System.Drawing.Size(539, 240);
            dw_contract_address.Location = new System.Drawing.Point(3, 7);

            //((DAddressList)dw_contract_address.DataObject).CellDoubleClick += new EventHandler(dw_contract_address_doubleclicked);
            //dw_contract_address.Constructor += new UserEventDelegate(dw_contract_address_constructor);
            //dw_contract_address.PfcPreInsertRow += new UserEventDelegate1(dw_contract_address_pfc_preinsertrow);
            //dw_contract_address.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang

            // 
            // st_custlist_print
            // 
            st_custlist_print.TabStop = false;
            st_custlist_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_custlist_print.Text = "Customer list last printed";
            st_custlist_print.ForeColor = System.Drawing.SystemColors.WindowText;
            st_custlist_print.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_custlist_print.Location = new System.Drawing.Point(10, 258);
            st_custlist_print.Size = new System.Drawing.Size(149, 19);
            // 
            // st_custlist_updated
            // 
            st_custlist_updated.TabStop = false;
            st_custlist_updated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            st_custlist_updated.Text = "Customer list last updated";
            st_custlist_updated.ForeColor = System.Drawing.SystemColors.WindowText;
            st_custlist_updated.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            st_custlist_updated.Location = new System.Drawing.Point(267, 258);
            st_custlist_updated.Size = new System.Drawing.Size(165, 19);
            // 
            // em_custlist_printed
            // 
            em_custlist_printed.Mask = "00/00/0000";
            em_custlist_printed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            em_custlist_printed.TextAlign = HorizontalAlignment.Center;
            em_custlist_printed.Enabled = false;
            em_custlist_printed.ForeColor = System.Drawing.SystemColors.WindowText;
            em_custlist_printed.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            em_custlist_printed.TabIndex = 3;
            em_custlist_printed.Location = new System.Drawing.Point(178, 258);
            em_custlist_printed.Size = new System.Drawing.Size(66, 20);
            //em_custlist_printed.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //em_custlist_printed.PromptChar = '0';
            //em_custlist_printed.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            //em_custlist_printed.ValidatingType = typeof(System.DateTime?);
            // 
            // em_custlist_updated
            // 
            em_custlist_updated.Mask = "00/00/0000";
            em_custlist_updated.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            em_custlist_updated.TextAlign = HorizontalAlignment.Center;
            em_custlist_updated.ForeColor = System.Drawing.SystemColors.WindowText;
            em_custlist_updated.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            em_custlist_updated.TabIndex = 4;
            em_custlist_updated.Location = new System.Drawing.Point(440, 258);
            em_custlist_updated.Size = new System.Drawing.Size(66, 20);
            em_custlist_updated.TextChanged += new EventHandler(em_custlist_updated_modified);
            //this.em_custlist_updated.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            //this.em_custlist_updated.PromptChar = '0';
            //this.em_custlist_updated.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            //this.em_custlist_updated.ValidatingType = typeof(System.DateTime?);
            // 
            // tabpage_renewals
            // 
            dw_renewals = new URdsDw();
            //!dw_renewals.DataObject = new DRenewals();
            //!dw_renewals.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_renewals.Controls.Add(dw_renewals);
            tabpage_renewals.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_renewals.Text = "Renewals";
            tabpage_renewals.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_renewals.Size = new System.Drawing.Size(550, 315);
            tabpage_renewals.Top = 25;
            tabpage_renewals.Left = 3;
            tabpage_renewals.Visible = false;
            tabpage_renewals.Tag = "ComponentName=Renewal;";
            // 
            // dw_renewals
            // 
            dw_renewals.TabIndex = 1;
            dw_renewals.Location = new System.Drawing.Point(3, 7);
            dw_renewals.Size = new System.Drawing.Size(542, 276);

            //dw_renewals.Constructor += new UserEventDelegate(dw_renewals_constructor);
            //((DRenewals)dw_renewals.DataObject).CellClick += new EventHandler(dw_renewals_clicked);
            //((DRenewals)dw_renewals.DataObject).CellDoubleClick += new EventHandler(dw_renewals_doubleclicked);
            //dw_renewals.PfcPreInsertRow += new UserEventDelegate1(dw_renewals_pfc_preinsertrow);
            //dw_renewals.PfcPreDeleteRow += new UserEventDelegate1(dw_renewals_pfc_predeleterow);
            //dw_renewals.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
            // 
            // tabpage_frequencies
            // 
            dw_route_frequency = new URdsDw();
//!            dw_route_frequency.DataObject = new DRouteFrequency();
//!            dw_route_frequency.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_frequencies.Controls.Add(dw_route_frequency);
            tabpage_frequencies.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_frequencies.Text = "Frequencies";
            tabpage_frequencies.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_frequencies.Size = new System.Drawing.Size(550, 315);
            tabpage_frequencies.Top = 25;
            tabpage_frequencies.Left = 3;
            tabpage_frequencies.Visible = false;
            tabpage_frequencies.Tag = "ComponentName=Frequency;";
            // 
            // dw_route_frequency
            // 
            dw_route_frequency.TabIndex = 1;
            dw_route_frequency.Location = new System.Drawing.Point(5, 7);
            dw_route_frequency.Size = new System.Drawing.Size(539, 274);
            dw_route_frequency.GotFocus += new EventHandler(dw_route_frequency_getfocus);

            //dw_route_frequency.Constructor += new UserEventDelegate(dw_route_frequency_constructor);
            //((DRouteFrequency)dw_route_frequency.DataObject).CellDoubleClick += new EventHandler(dw_route_frequency_doubleclicked);
            //((DRouteFrequency)dw_route_frequency.DataObject).CellClick += new EventHandler(dw_route_frequency_clicked);
            //dw_route_frequency.PfcValidation += new UserEventDelegate1(dw_route_frequency_pfc_validation);// UserEventDelegate(dw_route_frequency_pfc_validation);

            // 
            // tabpage_route_audit
            // 
            dw_route_audit = new URdsDw();
            //!dw_route_audit.DataObject = new DRouteAuditListing();
            //!dw_route_audit.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_route_audit.Controls.Add(dw_route_audit);
            tabpage_route_audit.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_route_audit.Text = "Route Audit";
            tabpage_route_audit.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_route_audit.Size = new System.Drawing.Size(550, 315);
            tabpage_route_audit.Top = 25;
            tabpage_route_audit.Left = 3;
            tabpage_route_audit.Visible = false;
            tabpage_route_audit.Tag = "ComponentName=Route Audit;";

            // 
            // dw_route_audit
            // 
            dw_route_audit.TabIndex = 1;
            dw_route_audit.Location = new System.Drawing.Point(5, 7);
            dw_route_audit.Size = new System.Drawing.Size(539, 274);

            //dw_route_audit.Constructor += new UserEventDelegate(dw_route_audit_constructor);
            //((DRouteAuditListing)dw_route_audit.DataObject).CellDoubleClick += new EventHandler(dw_route_audit_doubleclicked);
            //((DRouteAuditListing)dw_route_audit.DataObject).CellClick += new EventHandler(dw_route_audit_clicked);
            //dw_route_audit.PfcInsertRow += new UserEventDelegate(dw_route_audit_pfc_preinsertrow);

            // 
            // tabpage_types
            // 
            dw_types = new URdsDw();
//!            dw_types.DataObject = new DTypesForContract();
//!            dw_types.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_types.Controls.Add(dw_types);
            tabpage_types.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_types.Text = "Types";
            tabpage_types.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_types.Size = new System.Drawing.Size(550, 315);
            tabpage_types.Top = 25;
            tabpage_types.Left = 3;
            tabpage_types.Visible = false;
            tabpage_types.Tag = "ComponentName=Contract Type;";

            // 
            // dw_types
            // 
            dw_types.TabIndex = 1;
            dw_types.Location = new System.Drawing.Point(5, 7);
            dw_types.Size = new System.Drawing.Size(539, 274);

            //dw_types.Constructor += new UserEventDelegate(dw_types_constructor);
            //dw_types.PfcValidation += new UserEventDelegate1(dw_types_pfc_validation);// UserEventDelegate(dw_types_pfc_validation);
            //dw_types.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang

            // 
            // tabpage_allowances
            // 
            dw_contract_allowances = new URdsDw();
            //!dw_contract_allowances.DataObject = new DContractAllowancesV2();
            tabpage_allowances.Controls.Add(dw_contract_allowances);
            tabpage_allowances.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_allowances.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_allowances.Text = "Allowances";
            tabpage_allowances.BackColor = System.Drawing.SystemColors.ButtonFace;

            tabpage_allowances.Size = new System.Drawing.Size(550, 315);
            tabpage_allowances.Top = 25;
            tabpage_allowances.Left = 3;
            tabpage_allowances.Visible = false;
            tabpage_allowances.Tag = "ComponentName=Allowance;";
            // 
            // dw_contract_allowances
            // 
            //!dw_contract_allowances.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_contract_allowances.AutoScroll = true;
            dw_contract_allowances.TabIndex = 1;
            dw_contract_allowances.Location = new System.Drawing.Point(5, 7);
            dw_contract_allowances.Size = new System.Drawing.Size(539, 274);

            //dw_contract_allowances.Constructor += new UserEventDelegate(dw_contract_allowances_constructor);
            //((DContractAllowancesV2)dw_contract_allowances.DataObject).CellDoubleClick += new EventHandler(dw_contract_allowances_doubleclicked);
            //dw_contract_allowances.PfcInsertRow = new UserEventDelegate(dw_contract_allowances_pfc_preinsertrow);
            //dw_contract_allowances.PfcPreUpdate += new UserEventDelegate1(dw_contract_allowances_pfc_preupdate);// UserEventDelegate(dw_contract_allowances_pfc_preupdate);
            //dw_contract_allowances.UpdateStart = new UserEventDelegate(dw_contract_allowances_updatestart);
            //dw_contract_allowances.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang

            // 
            // tabpage_article_count
            // 
            dw_artical_counts = new URdsDw();
            //!dw_artical_counts.DataObject = new DContractArticalCounts();
            //!dw_artical_counts.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_article_count.Controls.Add(dw_artical_counts);
            tabpage_article_count.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_article_count.Text = "Article Count";
            tabpage_article_count.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_article_count.Size = new System.Drawing.Size(550, 315);
            tabpage_article_count.Top = 25;
            tabpage_article_count.Left = 3;
            tabpage_article_count.Visible = false;
            tabpage_article_count.Tag = "ComponentName=Article Count;";
            // 
            // dw_artical_counts
            // 
            dw_artical_counts.TabIndex = 1;
            dw_artical_counts.Location = new System.Drawing.Point(5, 7);
            dw_artical_counts.Size = new System.Drawing.Size(540, 290);
            dw_artical_counts.Click += new EventHandler(dw_artical_counts_clicked);
            dw_artical_counts.DoubleClick += new EventHandler(dw_artical_counts_doubleclicked);
            dw_artical_counts.LostFocus += new EventHandler(dw_artical_counts_losefocus);

            // 
            // tabpage_piece_rates
            // 
            dw_piece_rates = new URdsDw();
//!            dw_piece_rates.DataObject = new DContractPieceRates();
//!            dw_piece_rates.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_piece_rates.Controls.Add(dw_piece_rates);
            tabpage_piece_rates.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_piece_rates.Text = "Piece Rates";
            tabpage_piece_rates.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_piece_rates.Size = new System.Drawing.Size(550, 315);
            tabpage_piece_rates.Top = 25;
            tabpage_piece_rates.Left = 3;
            tabpage_piece_rates.Visible = false;
            tabpage_piece_rates.Tag = "ComponentName=Piece Rate;";
            // 
            // dw_piece_rates
            // 
            dw_piece_rates.TabIndex = 1;
            dw_piece_rates.Location = new System.Drawing.Point(5, 7);
            dw_piece_rates.Size = new System.Drawing.Size(539, 274);

            //dw_piece_rates.Constructor += new UserEventDelegate(dw_piece_rates_constructor);
            //((DContractPieceRates)dw_piece_rates.DataObject).CellDoubleClick += new EventHandler(dw_piece_rates_doubleclicked);
            //((DContractPieceRates)dw_piece_rates.DataObject).CellClick += new EventHandler(dw_piece_rates_clicked);
            //dw_piece_rates.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
            // 
            // tabpage_fixed_assets
            // 
            dw_fixed_assets = new URdsDw();
            //!dw_fixed_assets.DataObject = new DContractFixedAssets();
            //!dw_fixed_assets.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_fixed_assets.Controls.Add(dw_fixed_assets);
            tabpage_fixed_assets.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_fixed_assets.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_fixed_assets.Text = "Fixed Assets";

            tabpage_fixed_assets.Height = 315;
            tabpage_fixed_assets.Top = 25;
            tabpage_fixed_assets.Left = 3;
            tabpage_fixed_assets.Visible = false;
            tabpage_fixed_assets.Tag = "ComponentName=Fixed Asset;";

            //dw_fixed_assets.UpdateEnd += new UserEventDelegate(dw_fix_winpfcsave);

            // 
            // dw_fixed_assets
            // 
            dw_fixed_assets.TabIndex = 1;
            dw_fixed_assets.Location = new System.Drawing.Point(5, 7);
            dw_fixed_assets.Size = new System.Drawing.Size(539, 274);
            //?dw_fixed_assets.ItemChanged += new EventHandler(dw_fixed_assets_itemchanged);

            //dw_fixed_assets.Constructor += new UserEventDelegate(dw_fixed_assets_constructor);
            //dw_fixed_assets.PfcValidation += new UserEventDelegate1(dw_fixed_assets_pfc_validation);// UserEventDelegate(dw_fixed_assets_pfc_validation);
            //dw_fixed_assets.UpdateStart = new UserEventDelegate(dw_fixed_assets_updatestart);
            //dw_fixed_assets.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang

            // 
            // tabpage_cmb
            // 
            dw_cmbs = new URdsDw();
            //!dw_cmbs.DataObject = new DCmbAddressList();
            //!dw_cmbs.DataObject.BorderStyle = BorderStyle.Fixed3D;
            tabpage_cmb.Controls.Add(dw_cmbs);
            tabpage_cmb.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_cmb.Text = "CMBs";
            tabpage_cmb.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_cmb.Size = new System.Drawing.Size(550, 315);
            tabpage_cmb.Top = 25;
            tabpage_cmb.Left = 3;
            tabpage_cmb.Visible = false;
            tabpage_cmb.Tag = "ComponentName=Contract;";
            // 
            // dw_cmbs
            // 
            dw_cmbs.Text = "CMBs";
            dw_cmbs.TabIndex = 1;
            dw_cmbs.Location = new System.Drawing.Point(8, 8);
            dw_cmbs.Size = new System.Drawing.Size(529, 280);
            dw_cmbs.GotFocus += new EventHandler(dw_cmbs_getfocus);

            //dw_cmbs.Constructor += new UserEventDelegate(dw_cmbs_constructor);
            //((DCmbAddressList)dw_cmbs.DataObject).CellDoubleClick += new EventHandler(dw_cmbs_doubleclicked);
            //((DCmbAddressList)dw_cmbs.DataObject).CellClick += new EventHandler(dw_cmbs_clicked);
            //dw_cmbs.PfcDeleteRow += new UserEventDelegate(dw_cmbs_pfc_deleterow);
            //dw_cmbs.PfcInsertRow = new UserEventDelegate(dw_cmbs_pfc_preinsertrow);
            //dw_cmbs.PfcPreDeleteRow += new UserEventDelegate1(dw_cmbs_pfc_predeleterow);
            //dw_cmbs.WinValidate += new UserEventDelegate2(of_validate); //added by jlwang
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

        #region Methods
        //added by jlwang
        private void dw_fix_winpfcsave()
        {
            int rowCount = idw_fixed_assets.DataObject.BindingSource.List.Count;
            for (int i = 0; i < rowCount; i++)
            {
                ((TextBox)(((DContractFixedAssetsTest)(idw_fixed_assets.DataObject.GetControlByName("tableLayoutPanel1").Controls[i])).GetControlByName("fa_fixed_asset_no"))).ReadOnly = true;
            }
        }

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
                        //lRow = idw_frequencies.Find(new KeyValuePair<string, object>("sf_key", lFrequency), new KeyValuePair<string, object>("rf_delivery_days", sDeliveryDays));//lRow = idw_frequencies.Find( "sf_key = " + lFrequency.ToString() + " and rf_delivery_days = \'" + sDeliveryDays + '\'' ).Length);
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
                    MessageBox.Show("This frequency has already been defined", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ((Button)(idw_contract.GetControlByName(acode + "_button"))).Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTDN;//idw_contract.Modify(acode + "_button.filename=\'..\\bitmaps\\pcklstdn.bmp\'");
            //?idw_contract.SetColumn(acode + "_picklist");
            sOutlet = idw_contract.GetValue<string>(0, "con_" + aoutlet + "_office_name");
            StaticVariables.gnv_app.of_set_componenttoopen(this.of_get_componentname());
            StaticVariables.gnv_app.of_get_parameters().integerparm = this.of_get_regionid();
            Cursor.Current = Cursors.WaitCursor;
            //OpenWithParm(w_qs_outlet, sOutlet);
            StaticMessage.StringParm = sOutlet;
            WQsOutlet w_qs_outlet = new WQsOutlet();
            w_qs_outlet.ShowDialog();
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                ((DContract)idw_contract.DataObject).SetValue(0, "con_" + aoutlet + "_office", StaticVariables.gnv_app.of_get_parameters().longparm);
                ((DContract)idw_contract.DataObject).SetValue(0, "con_" + aoutlet + "_office_name", StaticVariables.gnv_app.of_get_parameters().stringparm);
                ((DContract)idw_contract.DataObject).SetValue(0, "con_" + aoutlet + "_office_type", StaticVariables.gnv_app.of_get_parameters().miscstringparm);
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
            ((Button)(idw_contract.GetControlByName(acode + "_button"))).Image = global::NZPostOffice.Shared.Properties.Resources.PCKLSTUP;//idw_contract.Modify(acode + "_button.filename=\'..\\bitmaps\\pcklstup.bmp\'");

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
                if (!((idw_frequencies.GetItem<RouteFrequency>(ll_Row).SfKey) == null) && idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays == "NNNNNNN")
                {
                    MessageBox.Show("Please select the days that this frequency is delivered", "Contract", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ls_ErrorColumn = "rf_monday";
                }
                else
                {
                    idw_frequencies.GetItem<RouteFrequency>(ll_Row).RfDeliveryDays = idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays;
                }
                if ((idw_frequencies.GetItem<RouteFrequency>(ll_Row).SfKey == null) && idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays != "NNNNNNN")
                {
                    MessageBox.Show("Please select a frequency", "Contract", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    ls_ErrorColumn = "sf_key";
                }
                sDaysDelivery = idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcDeldays;
                idw_frequencies.GetItem<RouteFrequency>(ll_Row).RfDeliveryDays = sDaysDelivery;
                if (of_frequency_unique(ll_Row))
                {
                    lNumDays = idw_frequencies.GetItem<RouteFrequency>(ll_Row).CalcNumdeldays.GetValueOrDefault();
                    lSFKey = idw_frequencies.GetItem<RouteFrequency>(ll_Row).SfKey.GetValueOrDefault();
                    //?dwChild = idw_frequencies.GetChild("sf_key");//idw_frequencies.GetChild("sf_key", dwChild);
                    dwChild = new DDddwStandardFrequency();
                    dwChild.BindingSource.DataSource = ((Metex.Windows.DataGridViewEntityComboColumn)(((Metex.Windows.DataEntityGrid)(idw_frequencies.GetControlByName("grid"))).Columns["sf_key"])).DataSource;
                    lrow = dwChild.Find("sf_key", lSFKey);//lrow = dwChild.Find( "sf_key=" + lSFKey).ToString().Length);
                    if (lrow > 0)
                    {
                        if (dwChild.GetItem<DddwStandardFrequency>(lrow).SfDaysWeek.GetValueOrDefault() != lNumDays)
                        {
                            MessageBox.Show("The delivery days selected does not equal the number of days specified for this f" + "requency", "Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int ll_Row;
            int ll_RowCount;
            int lFatID;
            string sReturn = "";
            string sDaysDelivery = "";
            string sFixedAssetKey = "";
            string sFAOwner;
            DateTime dFAPurchaseDate;
            System.Decimal decFAPurchasePrice;
            ll_RowCount = idw_fixed_assets.RowCount;
            for (ll_Row = 0; ll_Row < ll_RowCount; ll_Row++)
            {
                sFixedAssetKey = idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).FaFixedAssetNo;
                lFatID = idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).FatId.GetValueOrDefault();
                sFAOwner = idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).FaOwner;
                dFAPurchaseDate = idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).FaPurchaseDate.GetValueOrDefault().Date;
                decFAPurchasePrice = idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).FaPurchasePrice.GetValueOrDefault();
                if ((idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).ContractNo == null))
                {
                    idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).ContractNo = il_Contract_no;
                }
                if (idw_fixed_assets.uf_not_entered(ll_Row, "FaFixedAssetNo", "fixed asset number"))
                {
                    sReturn = "fa_fixed_asset_no";
                }
                if (idw_fixed_assets.uf_not_unique(ll_Row, "FaFixedAssetNo", "fixed asset number"))
                {
                    sReturn = "fa_fixed_asset_no";
                }
                if (idw_fixed_assets.uf_not_entered(ll_Row, "FatId", "fixed asset type"))
                {
                    sReturn = "fat_id";
                }
                if (idw_fixed_assets.uf_not_unique(ll_Row, "FatId", "fixed asset type"))
                {
                    sReturn = "fat_id";
                }
                if (StaticFunctions.f_seekkey("fixed_asset_register", "fa_fixed_asset_no=\'" + idw_fixed_assets.GetItem<ContractFixedAssets>(ll_Row).FaFixedAssetNo + "\'") == 0)
                {
                    /*Insert into fixed_asset_register  ( fa_fixed_asset_no,fat_id,fa_owner,fa_purchase_date,fa_purchase_price) Values ( :sFixedAssetKey,:lFatId, :sFAOwner,:dFAPurchaseDate,:decFAPurchasePrice);*/
                    RDSDataService.InsertFixedAssetRegister(sFixedAssetKey, lFatID, sFAOwner, dFAPurchaseDate, decFAPurchasePrice);
                }
                else
                {
                    /*UPDATE fixed_asset_register set 		fat_id = :lFatId,fa_owner = :sFAOwner,fa_purchase_date = :dFAPurchaseDate,fa_purchase_price = :decFAPurchasePrice where 	fa_fixed_asset_no = :sFixedAssetKey;*/
                    RDSDataService.UpdateFixedAssetRegister(lFatID, sFAOwner, dFAPurchaseDate, decFAPurchasePrice, sFixedAssetKey);
                }
            }
            //?idw_fixed_assets.AcceptText();
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
            ll_Row = idw_types.GetNextModified(-1);//ll_Row = idw_types.GetNextModified(0, primary!);
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
                    //?if ((w_piece_rate_breakdown != null))
                    //{
                    //    close(w_piece_rate_breakdown);
                    //}
                    lnv_Criteria.of_addcriteria("Contract_no", il_Contract_no);
                    lnv_Criteria.of_addcriteria("prs_key", idw_piece_rates.GetItem<ContractPieceRates>(al_row).PrsKey.GetValueOrDefault());
                    lnv_Criteria.of_addcriteria("prd_date", idw_piece_rates.GetItem<ContractPieceRates>(al_row).PrdDate.GetValueOrDefault().Date);
                    lnv_msg.of_addcriteria(lnv_Criteria);
                    //OpenSheetWithParm(w_piece_rate_breakdown, lnv_msg, w_main_mdi, 0, original!);
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
            //select cust_list_printed into :ld_cust_printed 
            //  from contract 
            // where contract_no = :il_Contract_no 
            // using SQLCA;*/
            ld_cust_printed = RDSDataService.GetContractCustListPrinted(il_Contract_no);
            if (!((ld_cust_printed == null)))
            {
                this.em_custlist_printed.Text = string.Format("{0:dd/MM/yyyy}", ld_cust_printed);
            }
            else
            {
                this.em_custlist_printed.Text = "00/00/0000";
            }
            //select cust_list_updated into :ld_cust_updated 
            //  from contract 
            // where contract_no = :il_Contract_no 
            // using SQLCA;*/
            ld_cust_updated = RDSDataService.GetContractCustListUpdated(il_Contract_no);
            if (!((ld_cust_updated == null)))
            {
                this.em_custlist_updated.Text = string.Format("{0:dd/MM/yyyy}", ld_cust_updated);//!Convert.ToString(ld_cust_updated);//.ToString("dd/MM/yyyy");
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
                    //?if ((w_allowance_breakdown == null))
                    //{
                    //    close(w_allowance_breakdown);
                    //}
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
                // System.Convert.ToDateTime(0);
            }
            if (id_custlist_updated != ld_check_update)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            //  inserted a row, only if one  ( or more) was deleted.
            int ll_rows;
            int ll_dels;
            int? ll_cmbid;
            ll_rows = idw_cmb.RowCount;
            ll_dels = idw_cmb.DataObject.DeletedCount;
            //ll_dels = idw_cmb.DeletedCount();
            if (ll_rows == 1)
            {
                ll_cmbid = idw_cmb.GetItem<CmbAddressList>(0).CmbId;
                if ((ll_cmbid == null) || ll_cmbid == 0)
                {
                    ll_rows = 0;
                }
            }
            if (ll_rows > 0)
            {
                idw_cmb.of_set_deletepriv(true);
            }
            else
            {
                idw_cmb.of_set_deletepriv(false);
            }
            if (ll_dels > 0 || ll_rows > 0)
            {
                idw_cmb.of_set_modifypriv(true);
            }
            else
            {
                idw_cmb.of_set_modifypriv(false);
            }
            idw_cmb.of_set_createpriv(true);

            return SUCCESS;
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
            //idw_contract.GetChild("ct_key", dwChild);
            dwChild = idw_contract.GetChild("ct_key");
            ll_ct_key = idw_contract.GetItem<Contract>(0).CtKey.GetValueOrDefault();
            if (ll_ct_key > 0)
            {
                //ll_found = dwChild.Find( "ct_key = " + ll_ct_key).ToString().Length);
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
            else if (StaticFunctions.f_nempty(idw_contract.GetItem<Contract>(arow).ConLodgementOffice) && !(StaticVariables.gnv_app.of_isempty(idw_contract.GetItem<Contract>(arow).ConLodgementOfficeName)))
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
                        {
                            ls_custCount = " address exists";
                        }
                        else
                        {
                            ls_custCount = " addresses exist";
                        }
                        ll_rc = MessageBox.Show(lCustCount.ToString() + ls_custCount + " for this contract.\n" + "You can not terminate a contract which has active Addresses.\n\n" + "Do you wish to transfer all Addresses to an \n" + "alternative contract?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2;//MessageBox(this.Text, lCustCount.ToString() + ls_custCount + " for this contract.\n" + "You can not terminate a contract which has active Addresses.\n\n" + "Do you wish to transfer all Addresses to an \n" + "alternative contract?", question!, yesno!);
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
                if (idw_contract.GetItem<Contract>(arow).IsNew && idw_contract.GetItem<Contract>(arow).IsDirty) //if (idw_contract.GetItemStatus(arow, 0, primary!) == newmodified!) 
                {
                    lContractType = idw_contract.GetItem<Contract>(arow).CtKey.GetValueOrDefault();
                    sContractType = "Contract: " + lContractType.ToString();
                    il_Contract_no = StaticVariables.gnv_app.of_get_nextcontract(lContractType);
                    idw_contract.GetItem<Contract>(arow).ContractNo = il_Contract_no;
                    sTitle = "Contract: (" + idw_contract.GetItem<Contract>(arow).ContractNo.GetValueOrDefault().ToString() + ") " + idw_contract.GetItem<Contract>(arow).ConTitle;
                    this.Text = sTitle;
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        this.Text = this.Text.Replace("\n", "");
                    }
                    idw_contract.GetControlByName("ct_key").Enabled = false;
                    //idw_contract.Modify("ct_key.dddw.useasborder=no ct_key.border=0 ct_key.background.color=76585128 ct_key.protect=1");
                    idw_contract.Left = idw_contract.Left;
                }
                else
                {
                    sTitle = "Contract: (" + idw_contract.GetItem<Contract>(arow).ContractNo.GetValueOrDefault().ToString() + ") " + idw_contract.GetItem<Contract>(arow).ConTitle;
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
            //DECLARE CreateTFC PROCEDURE FOR sp_CreateTFC  ;
            //EXECUTE CreateTFC;
            RDSDataService.ProcesureSpCreatetfc();
            return;//return 1;
        }

        public virtual void dw_contract_address_constructor()
        {
            dw_contract_address.of_setautoinsert(false);
            dw_contract_address.of_SetUpdateable(false);
            // This.Post of_Set_DeletePriv(FALSE)
            // This.Post of_Set_CreatePriv(FALSE)
            dw_contract_address.of_SetRowSelect(true);
            dw_contract.of_SetStyle(0);// dw_contract_address.inv_rowselect.of_SetStyle(0);
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
            //idw_renewals.of_SetStyle(0); //inv_rowselect.of_SetStyle(0);
            idw_renewals = dw_renewals;
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
                    //  TWC 04/07/2003 - call 4532 - ensure the artical count doesn't get deleted 
                    //                   on cascade
                    //UPDATE artical_count set contract_seq_number = null 
                    // where contract_no = :lcontract 
                    //   and contract_seq_number = :lsequence;
                    RDSDataService.UpdateArticalCountContractSeqNumber(lcontract, lsequence, ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show(SQLErrText, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                    /*delete from contract_renewals where contract_no=:lcontract and contract_seq_number=:lsequence;*/
                    RDSDataService.DeleteContractRenewals(lcontract, lsequence, ref SQLCode, ref SQLErrText);
                    if (SQLCode != 0)
                    {
                        MessageBox.Show(SQLErrText, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                    //?commit;
                    if (SQLCode != 0)
                    {
                        MessageBox.Show(SQLErrText, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //dw_route_frequency.Modify("distance.TabIndex = 0");
                ((Metex.Windows.DataEntityGrid)(dw_route_frequency.GetControlByName("grid"))).Columns["distance"].ReadOnly = true;
                //?dw_route_frequency.Modify("distance.Border=\'0\'");
                //?((Metex.Windows.DataEntityGrid)(dw_route_frequency.GetControlByName("grid"))).Columns["distance"].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;//dw_route_frequency.GetControlByName("distance").BackColor = System.Drawing.Color.FromArgb(128, 208, 212);//dw_route_frequency.(7)DataControl["distance"].BackColor =2726351060");
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
            {
                return 1;
            }
            else
            {
                return -(1);
            }
        }

        // TJB Release 7.1.3 fixups Aug-2010
        // Added dw_contract_allowances_pfc_modify and changed how 
        // WAddAllowance is called.  This (dw_contract_allowances_pfc_preinsertrow1)
        // is the original, replaced with openAddAllowance
      /*
        public virtual void dw_contract_allowances_pfc_preinsertrow()
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
            lnv_Criteria.of_addcriteria("optype", "Insert");
            lnv_msg.of_addcriteria(lnv_Criteria);

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
      */
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

        public virtual void dw_fixed_assets_constructor()
        {
            dw_fixed_assets.of_setautoinsert(true);
            idw_fixed_assets = dw_fixed_assets;
        }

        public virtual void dw_fixed_assets_updatestart()
        {
            return;
        }

        public virtual int dw_fixed_assets_pfc_validation()
        {
            bool lb_result;
            lb_result = of_validate_fixed_assets();
            if (lb_result == true)
            {
                return SUCCESS;
            }
            else
            {
                return FAILURE;
            }
        }

        public virtual void dw_cmbs_constructor()
        {
            // TJB  SR4659  July 2005
            idw_cmb = dw_cmbs;
            // uf_settag("CMBs")
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
                /*select first a.adr_rd_no, p.post_code_id, t.tc_id into :ls_rdno, :ll_postcode_id, :ll_tc_id from address a, post_code p, towncity t where a.post_code_id = p.post_code_id and t.tc_name = p.post_mail_town and a.contract_no = :il_contract_no;*/
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
                               , ""
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
            if (oldindex == tab_contract.SelectedIndex)
            {
                return;
            }

            DialogResult ll_Ret;
            int ll_ret;
            int ll_Row;
            Cursor.Current = Cursors.WaitCursor;
            if (ib_Opening)
            {
                idw_fixed_assets.ResetUpdate();
                idw_piece_rates.ResetUpdate();
                idw_article_count.ResetUpdate();
                idw_allowances.ResetUpdate();
                idw_types.ResetUpdate();
                idw_route_audit.ResetUpdate();
                idw_frequencies.ResetUpdate();
                idw_renewals.ResetUpdate();
                idw_addresses.ResetUpdate();
                idw_cmb.ResetUpdate();
                if (il_Contract_no > 0)
                {
                    idw_contract.ResetUpdate();
                }
                return;//return 0;
            }
            // Check for new contract
            if (il_Contract_no == -(1))
            {
                tab_contract.SelectTab(oldindex);
                MessageBox.Show("The current contract has to be saved before you can change tabs."
                               , "New Contract"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Check for any changes to idw_contract
            idw_contract.AcceptText();
            if (idw_contract.DataObject.DeletedCount > 0 || idw_contract.ModifiedCount() > 0)
            {
                ll_Ret = MessageBox.Show("Do you want to update database?"
                                         , "Update"
                                         , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_contract.GetRow();
                if (ll_Ret == DialogResult.Yes)
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
                ll_Ret = MessageBox.Show("Do you want to update database?"
                                        , "Update Frequencies"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_frequencies.GetRow();
                if (ll_Ret == DialogResult.Yes)
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
                ll_Ret = MessageBox.Show("Do you want to update database?"
                                        , "Update Contract Types"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_types.GetRow();
                if (ll_Ret == DialogResult.Yes)
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
                ll_Ret = MessageBox.Show("Do you want to update database?"
                                        , "Update Allowances"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_allowances.GetRow();
                if (ll_Ret == DialogResult.Yes)
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
            // Check for any changes to idw_fixed_assets
            idw_fixed_assets.AcceptText();
            if (idw_fixed_assets.DataObject.DeletedCount > 0 || idw_fixed_assets.ModifiedCount() > 0)
            {
                ll_Ret = MessageBox.Show("Do you want to update database?"
                                        , "Update Fuxed Assets"
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ll_Row = idw_fixed_assets.GetRow();
                if (ll_Ret == DialogResult.Yes)
                {
                    ll_ret = idw_fixed_assets.Save();
                    if (ll_ret < 0)
                    {
                        return;
                    }
                }
                else
                {
                    idw_fixed_assets.Reset();
                }
            }
        }

        int oldindex = -1;

        //jlwang:change selectindex to name 
        // log in app with different user ,the tabpage should be invisible or visible
        // if we use select index to get tagepage it will throw exception. 
        public virtual void tab_contract_selectionchanged(object sender, EventArgs e)
        {
            if (oldindex == tab_contract.SelectedIndex)
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
            int ll_count;
            int ll_toContract;
            int llcount;
            DateTime ld_transferDate;
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
                                   , "Question"
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
            if (oldindex == 2 - 1)
            {
                if ((lm_menu != null))
                {
                    lm_menu._m_updatedatabase.Visible = false;
                    lm_menu.m_updatedatabase.Visible = false;
                    lm_menu.m_updatedatabase.Enabled = false;
                }
            }
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            //int TestExpr = tab_contract.SelectedIndex + 1;//newindex;
            string str = tab_contract.TabPages[tab_contract.SelectedIndex].Text.ToLower().Trim();

            if (str == "contract")
            {
                dw_contract_getfocus(null, null);

                idw_contract.uf_toggle_audit(true);
                if (idw_contract.RowCount == 0)
                {
                    idw_contract.Retrieve(new object[]{il_Contract_no});
                }
                idw_contract.uf_settoolbar();
            }
            else if (str == "addresses")
            {
                idw_addresses.URdsDw_GetFocus(null, null);

                if (idw_addresses.RowCount == 0)
                {
                    idw_addresses.Retrieve(new object[]{il_Contract_no});
                }
                idw_addresses.uf_settoolbar();
                this.of_set_custlist_data();
            }
            else if (str == "renewals")
            {
                idw_renewals.URdsDw_GetFocus(null, null);

                idw_contract.uf_toggle_audit(false);
                if (idw_renewals.RowCount == 0)
                {
                    idw_renewals.Retrieve(new object[]{il_Contract_no});
                }
                idw_renewals.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;
                ll_Active = idw_contract.GetItem<Contract>(0).ConActiveSequence.GetValueOrDefault();
                if (StaticFunctions.f_nempty(ll_Active))
                {
                    idw_renewals.GetControlByName("st_active").Text = "0";
                }
                else
                {
                    idw_renewals.GetControlByName("st_active").Text = ll_Active.ToString();
                }
                idw_renewals.uf_settoolbar();
            }
            else if (str == "frequencies")
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
            else if (str == "route audit")
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
            else if (str == "types")
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
            else if (str == "allowances")
            {
                idw_allowances.showUpdateToolButton = true;
                idw_allowances.URdsDw_GetFocus(null, null);
                idw_allowances.showUpdateToolButton = false;

                if (idw_allowances.RowCount == 0)
                {
                    idw_allowances.Retrieve(new object[]{il_Contract_no});
                }
                //?idw_allowances.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;
                //idw_allowances.DataControl["st_contract"].Text = "\'" + idw_contract.GetItemString(1, "con_title") + '\'');
                //?idw_allowances.GetControlByName("st_access").Text = "Y";
                //idw_allowances.DataControl["st_access"].Text = "\'Y\'";

                idw_allowances.uf_settoolbar();
            }
            else if (str == "article count")
            {
                idw_article_count.URdsDw_GetFocus(null, null);

                if (idw_article_count.RowCount == 0)
                {
                    idw_article_count.Retrieve(new object[]{il_Contract_no});
                }
                idw_article_count.GetControlByName("st_contract").Text = idw_contract.GetItem<Contract>(0).ConTitle;
                idw_article_count.uf_settoolbar();
            }
            else if (str == "piece rates")
            {
                idw_piece_rates.URdsDw_GetFocus(null, null);

                if (idw_piece_rates.RowCount == 0)
                {
                    idw_piece_rates.Retrieve(new object[]{il_Contract_no});
                }
                idw_piece_rates.uf_settoolbar();
            }
            else if (str == "fixed assets")
            {
                idw_fixed_assets.URdsDw_GetFocus(null, null);

                if (idw_fixed_assets.RowCount == 0)
                {
                    idw_fixed_assets.Retrieve(new object[]{il_Contract_no});
                }
                idw_fixed_assets.uf_settoolbar();
            }
            else if (str == "cmbs")
            {
                //?dw_cmbs_getfocus(null, null);
                int ll_rows;
                int ll_dels;
                ll_rows = idw_cmb.RowCount;
                if (ll_rows == 0)
                {
                    idw_cmb.Reset();
                    idw_cmb.Retrieve(new object[]{il_Contract_no});
                }
                wf_set_cmb_privs();
                idw_cmb.uf_settoolbar();
                dw_cmbs_getfocus(null, null);
            }
            oldindex = tab_contract.SelectedIndex;
            this.ResumeLayout(true);
        }

        public virtual void dw_contract_clicked(object sender, EventArgs e)
        {
            dw_contract.URdsDw_Clicked(sender, e);
            string sObjectAtPointer;
            string sOutlet;
            sObjectAtPointer = ((Button)sender).Name;
            //dw_contract.DataObject.ActiveControl.Name;
            //sObjectAtPointer = dw_contract.GetObjectAtPointer();
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
                        dw_contract.GetControlByName("con_rd_ref_text").BackColor = StaticVariables.gnv_app.of_getcolorcode("CYAN");
                    }
                    else
                    {
                        dw_contract.GetControlByName("con_rd_ref_text").BackColor = StaticVariables.gnv_app.of_getcolorcode("WHITE");
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
                dw_contract.GetControlByName("con_date_terminated").BackColor = System.Drawing.SystemColors.Control;//?System.Drawing.Color.FromArgb(144, 152, 168);//dw_contract.(7)DataControl["con_date_terminated"].BackColor =\'76585128\'");
                //?dw_contract.Modify("con_date_terminated.Border=\'0\'");
                dw_contract.GetControlByName("con_date_terminated").Enabled = true;//? dw_contract.Modify("con_date_terminated.Protect=\'1\'");
                //?dw_contract.Modify("con_date_terminated.Pointer=\'Arrow!\'");
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
                //p! changed the user object NRoad to use lists of business entities instead of data windows otherwise loads very slow
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
            ls_Title = "Renewal: " + dw_renewals.GetItem<Renewals>(row).ContractNo.GetValueOrDefault().ToString() + "/" + idw_renewals.GetItem<Renewals>(row).ContractSeqNumber.GetValueOrDefault().ToString() + " " + idw_contract.GetItem<Contract>(0).ConTitle;
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
                MessageBox.Show("The Frequency you have selected is not Active, You will not be able to sequence c" + "ustomers for this frequency", "Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//return 1;
            }
            if (dw_route_frequency.GetItem<RouteFrequency>(row).IsNew || (dw_route_frequency.GetItem<RouteFrequency>(row).IsNew && dw_route_frequency.GetItem<RouteFrequency>(row).IsDirty)) //if (dw_route_frequency.GetItemStatus(row, 0, primary!) == new! || dw_route_frequency.GetItemStatus(row, 0, primary!) == newmodified!) 
            {
                MessageBox.Show("The current frequency has not been saved to the database.  Please save before ope" + "ning.", "Contract", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lnv_Criteria.of_addcriteria("Contract_no", dw_route_frequency.GetItem<RouteFrequency>(row).ContractNo.GetValueOrDefault());
            lnv_Criteria.of_addcriteria("Sf_key", dw_route_frequency.GetItem<RouteFrequency>(row).SfKey.GetValueOrDefault());
            lnv_Criteria.of_addcriteria("Rf_delivery_days", dw_route_frequency.GetItem<RouteFrequency>(row).RfDeliveryDays);
            lnv_Criteria.of_addcriteria("Dw_route_freq", dw_route_frequency);
            lnv_msg.of_addcriteria(lnv_Criteria);
            ls_Title = " ( " + dw_route_frequency.GetItem<RouteFrequency>(row).ContractNo.GetValueOrDefault().ToString() + ") " /*?+ idw_frequencies.Describe("Evaluate ( \'LookupDisplay ( sf_key)\'," + row.ToString() + ')')*/;
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
                MessageBox.Show("There is nothing to display", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            WAddArticleCounts wNewArt;
            if (dw_artical_counts.RowCount > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!((dw_artical_counts.GetItem<ContractArticalCounts>(1).AcStartWeekPeriod.GetValueOrDefault().Date == null)))
                {
                    //OpenWithParm(w_full_artical_count_form, dw_artical_counts);
                    StaticMessage.PowerObjectParm = ((URdsDw)this.GetContainerControl().ActiveControl).DataObject;// dw_artical_counts;//.DataObject.BindingSource.CurrencyManager.  ; 
                    WFullArticalCountForm w_full_artical_count_form = new WFullArticalCountForm();
                    w_full_artical_count_form.ShowDialog();
                    //add by mkwang
                    for (int i = 0; i < dw_artical_counts.DataObject.RowCount; i++)
                    {
                        ((DContractArticalCountsTest)(((TableLayoutPanel)dw_artical_counts.GetControlByName("tbPanel")).Controls[i])).BindingSource.CurrencyManager.Refresh();
                    }
                }
                else
                {
                    ibAddArt = true;
                    //OpenSheet(wNewArt, w_main_mdi, 0, original!);
                    wNewArt = new WAddArticleCounts();
                    wNewArt.MdiParent = StaticVariables.MainMDI;
                    wNewArt.Show();
                    //?ilArtHandle = Handle(wNewArt);
                }
            }
        }

        public virtual void dw_artical_counts_losefocus(object sender, EventArgs e)
        {
            // force update so that the article count on the renewal window is accurate
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

        public virtual void dw_fixed_assets_ItemChanged(object sender, EventArgs e)
        {
            dw_fixed_assets.URdsDw_Itemchanged(sender, e);
            string sOwner;
            string sFixedAssetNo;
            int lFatId;
            DateTime dFAPurchaseDate;
            System.Decimal decFAPurchaseprice;
            int iCount;
            string sNull;
            int lContract;
            // if (dw_fixed_assets.GetColumnName() == "fa_fixed_asset_no")
            if (((TextBox)sender).Name == "fa_fixed_asset_no")
            {
                sFixedAssetNo = Convert.ToString(dw_fixed_assets.GetValue(dw_fixed_assets.GetRow(), "fa_fixed_asset_no"));// dw_fixed_assets.GetControlByName(dw_fixed_assets.GetColumnName()).Text; //dw_fixed_assets.GetText();
                // ! Defect164. PaulA. 13June.
                if (dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).IsNew || (dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).IsNew && dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).IsDirty)) //if (dw_fixed_assets.GetItemStatus(dw_fixed_assets.GetRow(), 0, primary!) == new! || dw_fixed_assets.GetItemStatus(dw_fixed_assets.GetRow(), 0, primary!) == newmodified!) 
                {
                    lContract = -(1);
                }
                else
                {
                    lContract = il_Contract_no;
                }
                /*select count ( *) into :icount from contract_fixed_assets where fa_fixed_asset_no = :sFixedAssetno and contract_no <> :il_Contract_no;*/
                iCount = RDSDataService.GetContractFixedAssetsCount(sFixedAssetNo, il_Contract_no);
                if (iCount > 0)
                {
                    if (MessageBox.Show(@"The asset number you have chosen is already is use. If you chose to continue asset information will default to that which has already been defined. Changing this asset information should be performed with caution as other references to it will also be updated." + "\n" + "\n" + "Do you wish to use this asset number?", "Fixed Assets", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.No) //if (MessageBox("Fixed Assets", @"The asset number you have chosen is already is use. If you chose to continue asset information will default to that which has already been defined. Changing this asset information should be performed with caution as other references to it will also be updated.\r\rDo you wish to use this asset number?", stopsign!, yesno!, 2) == 2) 
                    {
                        sNull = string.Empty;
                        dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).FaFixedAssetNo = sNull;
                        dw_fixed_assets.GetControlByName(dw_fixed_assets.GetColumnName()).Text = sNull;
                        for (int i = 0; i < dw_fixed_assets.DataObject.RowCount; i++)
                        {
                            ((DContractFixedAssetsTest)(((TableLayoutPanel)dw_fixed_assets.GetControlByName("tableLayoutPanel1")).Controls[i])).BindingSource.CurrencyManager.Refresh();
                        }
                        // This.SetActionCode ( 2)
                        // This.SetColumn ( This.GetColumnName ( ))
                        return;//return 2;
                    }
                }
                if (!(StaticVariables.gnv_app.of_isempty(sFixedAssetNo)))
                {
                    int SQLCode = 0;
                    string SQLErrText = string.Empty;
                    /*select fat_id, fa_owner,fa_purchase_date,fa_purchase_price into :lFatId, :sOwner,:dFAPurchaseDate,:decFAPurchaseprice from fixed_asset_register where fa_fixed_asset_no = :sFixedAssetno;*/
                    FixedAssetRegisterItem l_temp = RDSDataService.GetFixedAssetRegisterInfo(sFixedAssetNo, ref SQLCode, ref SQLErrText).FixedAssetRegisterItem;
                    lFatId = l_temp.FatId;
                    sOwner = l_temp.FaOwner;
                    dFAPurchaseDate = l_temp.FaPurchaseDate;
                    decFAPurchaseprice = l_temp.FaPurchasePrice;
                    if (SQLCode != 0)
                    {
                    }
                    else
                    {
                        dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).FatId = lFatId;
                        dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).FaOwner = sOwner;
                        dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).FaPurchaseDate = dFAPurchaseDate;
                        dw_fixed_assets.GetItem<ContractFixedAssets>(dw_fixed_assets.GetRow()).FaPurchasePrice = decFAPurchaseprice;
                    }
                }
            }
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
                if (MessageBox.Show(ls_temp1 + " marked for deletion.\r" + "Delete " + ls_temp2 + " now?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) //if (MessageBox("Warning", ls_temp1 + " marked for deletion.\r" + "Delete " + ls_temp2 + " now?", question!, yesno!, 2) == 1) 
                {
                    //! idw_cmb.Update();
                    idw_cmb.Save();
                }
            }
            ll_rows = idw_cmb.RowCount;
            if (ll_rows == 0 || row < 0)
            {
                MessageBox.Show("There is nothing to display", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Console.WriteLine("{0}½øÀ´ dw_cmbs_getfocus", System.DateTime.Now);
            dw_cmbs.URdsDw_GetFocus(sender, e);
            wf_set_cmb_privs();
            idw_cmb.uf_settoolbar();
        }

        public virtual void dw_cmbs_clicked(object sender, EventArgs e)
        {
            dw_cmbs.URdsDw_Clicked(sender, e);
            int row = idw_cmb.GetRow();
            //if (row >= 0)
            //{
            //    if (idw_cmb.IsSelected(row))
            //    {
            //        idw_cmb.SelectRow(row + 1, false);
            //    }
            //    else
            //    {
            //        idw_cmb.SelectRow(row + 1, true);
            //    }
            //}
        }

        #endregion
    }
}
