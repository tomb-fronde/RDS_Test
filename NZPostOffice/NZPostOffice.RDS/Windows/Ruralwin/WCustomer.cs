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
using System.Collections.Generic;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    // TJB  RPCR_103  May-2016
    // Added VR_Number to Customer window
    // Hide when customer isn't the Primary
    //
    // TJB  Dec-2014  RPCR_091
    // Resized window to fit all occupations
    //
    // TJB  Feb-2011  RPCR_023
    // Changed Occupations and Interests datawindows 
    //    from DCustomerOccupation to DCustomerOccupations
    //     and DCustomerInterest   to DCustomerInterests
    // Added cb_allInterests, cb_clearInterests, cb_allOccupations 
    // and cb_clearOccupations buttons and their click events

    // TJB  Jan-2011  Sequencing Review
    // Resized screen to make room
    // Added Case name and Slot allocation fields (see DCustomerDetails)

    public partial class WCustomer : WMaster
    {
        #region Define
        public USt st_label;

        public int? il_customer;

        public URdsDw idw_recipients;

        public URdsDw idw_mail_categories;

        public URdsDw idw_occupations;

        public URdsDw idw_interests;

        public bool ib_Opening = true;

        public int? ii_original_kiwi;

        public int ii_kiwi_ok = 1;

        //  TJB  NPAD2  Jan 2006 
        public int? il_adrid;

        //  TJB  NPAD2  Jan 2006 
        public int? il_contract_no;

        //  TJB  NPAD2  Jan 2006 
        public int? il_rdcontractselect;

        public int? il_cust_dpid;

        public int? il_cust_id;

        public int? il_master;

        public string is_old_surname = String.Empty;

        public string is_old_initials = String.Empty;

        public string is_old_title = String.Empty;

        public string is_npadfilename = String.Empty;

        public string is_npadoutfile = String.Empty;

        public string is_npadoutdir = String.Empty;

        public string is_userid = String.Empty;

        public bool ib_unnumbered;

        public bool? ib_npad_enabled;

        public bool ib_new;

        public bool ib_customers_modified;

        public bool ib_recipients_modified;

        public NCriteria inv_criteria;

        public NRdsMsg inv_msg;

        // TJB  RD7_0042  Jan-2010: Added
        // These keep track of what column we're coming from and going to
        private string prev_column = "";
        private string this_column = "";

        #endregion

        public WCustomer()
        {
            this.InitializeComponent();

            dw_generic.DataObject = new DCustomerDetails();
            this.dw_recipients2.DataObject = new DRecipient();
            dw_occupations.DataObject = new DCustomerOccupations();
            dw_interests.DataObject = new DCustomerInterests();

            dw_generic.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_recipients2.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_occupations.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_interests.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            ((CheckBox)(((DCustomerDetails)dw_generic.DataObject).GetControlByName("cust_business"))).CheckedChanged +=
                new EventHandler(dw_generic_ValidateCheckBoxes);
            ((CheckBox)(((DCustomerDetails)dw_generic.DataObject).GetControlByName("cust_rural_resident"))).CheckedChanged +=
                new EventHandler(dw_generic_ValidateCheckBoxes);
            ((CheckBox)(((DCustomerDetails)dw_generic.DataObject).GetControlByName("cust_rural_farmer"))).CheckedChanged +=
                new EventHandler(dw_generic_ValidateCheckBoxes);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormClosing -= new FormClosingEventHandler(FormBase_FormClosing);
            this.FormClosed -= new FormClosedEventHandler(this.FormBase_FormClosed);

            dw_generic.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_generic_constructor);
            dw_generic.PfcPreDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_generic_pfc_predeleterow);
            dw_generic.PfcPreInsertRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_generic_pfc_preinsertrow);
            dw_generic.PfcValidation += new UserEventDelegate1(dw_generic_pfc_validation);
            dw_generic.PfcPostUpdate += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_generic_pfc_postupdate);
            dw_generic.PfcPreUpdate += new UserEventDelegate1(dw_generic_pfc_preupdate);

            // TJB RD7_0042 jan-2010: Changed
            // Changed to use Itemfocuschanged event to trigger
            //dw_generic.ItemChanged += new EventHandler(dw_generic_itemchanged);
            dw_generic.URdsDwItemFocuschanged += new NZPostOffice.RDS.Controls.EventDelegate(dw_generic_itemfocuschanged);

            dw_recipients2.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_recipients2_constructor);
            dw_recipients2.PfcPreDeleteRow += new NZPostOffice.RDS.Controls.UserEventDelegate1(dw_recipients2_pfc_predeleterow);
            dw_recipients2.PfcPreUpdate += new UserEventDelegate1(dw_recipients2_pfc_preupdate);
            dw_recipients2.PfcValidation += new UserEventDelegate1(dw_recipients2_pfc_validation);
            dw_recipients2.PfcPreInsertRow += new UserEventDelegate1(dw_recipients2_pfc_preinsertrow);

            dw_occupations.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_occupations_constructor);
            dw_occupations.PfcPreUpdate += new UserEventDelegate1(dw_occupations_pfc_preupdate);
            dw_occupations.PfcValidation += new UserEventDelegate1(dw_occupations_pfc_validation);

            dw_interests.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_interests_constructor);
            dw_interests.PfcPreUpdate += new UserEventDelegate1(dw_interests_pfc_preupdate);
            dw_interests.PfcValidation += new UserEventDelegate1(dw_interests_pfc_validation);

            // TJB  Feb-2011  RPCR_023
            // Added buttons and their click events
            this.cb_allInterests.Click += new System.EventHandler(this.cb_allInterests_Click);
            this.cb_clearInterests.Click += new System.EventHandler(this.cb_clearInterests_Click);
            this.cb_allOccupations.Click += new System.EventHandler(this.cb_allOccupations_Click);
            this.cb_clearOccupations.Click += new System.EventHandler(this.cb_clearOccupations_Click);

            this.ShowInTaskbar = false;
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            int? ll_recipient_found;
            int ll_row;
            int? ll_master;
            string ls_phone;
            string ls_form_title;
            int? ll_unnumbered;
            int? ll_npad_enabled;
            int ll_rc;
            this.of_set_componentname("Customer");
            // Get the cust_id passed in from w_maintain_addresses
            // il_customer = message.Doubleparm
            //  TJB  NPAD2  Jan 2006  
            //  Change open of w_customer window to pass parameters through message.
            inv_msg = (NRdsMsg)StaticMessage.PowerObjectParm;
            inv_criteria = inv_msg.of_getcriteria();
            il_customer = (int?)inv_criteria.of_getcriteria("cust_id");
            il_master = (int?)inv_criteria.of_getcriteria("master_cust_id");
            il_adrid = (int?)inv_criteria.of_getcriteria("adr_id");
            ll_unnumbered = (int?)inv_criteria.of_getcriteria("unnumbered");
            ll_npad_enabled = (int?)inv_criteria.of_getcriteria("npad_enabled");
            il_cust_dpid = (int?)inv_criteria.of_getcriteria("dp_id");
            il_contract_no = (int?)inv_criteria.of_getcriteria("contract_no");
            il_rdcontractselect = (int?)inv_criteria.of_getcriteria("rd_Contract_Select");
            if (il_adrid == 0)
            {
                il_adrid = null;
            }
            if (il_cust_dpid == 0)
            {
                il_cust_dpid = null;
            }
            if (il_master == 0)
            {
                il_master = null;
            }
            ib_unnumbered = true;
            if (ll_unnumbered == null || ll_unnumbered == 0)
            {
                ib_unnumbered = false;
            }
            ib_npad_enabled = true;
            if (ll_npad_enabled == null || ll_npad_enabled == 0)
            {
                ib_npad_enabled = false;
            }
            //  Set default values
            ib_customers_modified = false;
            ib_recipients_modified = false;
            ib_new = true;

            // If we've got an existing customer, retrieve his/her info
            if (il_customer > 0)
            {
                ib_new = false;
                // Retrieve
                dw_generic.Retrieve(new object[]{il_customer});
                ll_row = dw_generic.GetRow();
                //  Display the DPID
                // *	idw_customer.setItem(ll_row,'cust_dpid',il_cust_dpid)
                // Set Title
                ls_form_title = "Customer: (" + il_customer.ToString() + ") " + dw_generic.GetItem<CustomerDetails>(ll_row).CustSurnameCompany;
                if (!(StaticFunctions.f_isempty(dw_generic.GetItem<CustomerDetails>(ll_row).CustInitials)))
                {
                    ls_form_title = ls_form_title + ", " + dw_generic.GetItem<CustomerDetails>(ll_row).CustInitials;
                }
                this.Text = ls_form_title;
                //  TWC - check that this is a primary customer - if not disable category boxes.
                ll_master = dw_generic.GetItem<CustomerDetails>(ll_row).MasterCustId;
                //  TJB  NPAD2  Jan 06
                //  Save the original customer name so we can tell if its changed
                is_old_surname  = dw_generic.GetItem<CustomerDetails>(ll_row).CustSurnameCompany;
                is_old_initials = dw_generic.GetItem<CustomerDetails>(ll_row).CustInitials;
                is_old_title    = dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle;
                // TJB  RD7_0042 Jan-2010: Changed
                //      Fixed bug: values trimmed before checking for null
                is_old_surname  = (is_old_surname == null) ? "" : is_old_surname.Trim();
                is_old_initials = (is_old_initials == null) ? "" : is_old_initials.Trim();
                is_old_title    = (is_old_title == null) ? "" : is_old_title.Trim();
            }
            else if (il_customer == 0)
            {
                //  This is a new customer, set up a blank screen
                ib_new = true;
                
                ll_row = dw_generic.RowCount;
                dw_generic.InsertItem<CustomerDetails>(ll_row);
                ls_form_title = "Customer: <New Customer>";
                this.Text = ls_form_title;

                //  TJB  NPAD2  Jan 06
                //  For a new customer, initialise the original customer name to <empty>
                is_old_surname = "";
                is_old_initials = "";
                is_old_title = "";
                // Allocate a cust_id
                il_customer = StaticFunctions.GetNextSequence("Customer");
                dw_generic.GetItem<CustomerDetails>(ll_row).CustId = il_customer;
                // TJB  RD7_CR002  Feb-2010: Changed
                // Changed to set only the date, not date + time
                //dw_generic.GetItem<CustomerDetails>(ll_row).CustDateCommenced = System.DateTime.Today;
                dw_generic.GetItem<CustomerDetails>(ll_row).CustDateCommenced = System.DateTime.Today.Date;
                dw_generic.DataObject.BindingSource.CurrencyManager.Refresh();
                // 	idw_customer.setitem(ll_row,"cust_dir_listing_ind","Y")
                // 	idw_customer.setitem(ll_row,"cust_business","N")
                // 	idw_customer.setitem(ll_row,"cust_rural_resident","N")
                // 	idw_customer.setitem(ll_row,"cust_rural_farmer","Y")
            }
            if ((bool)ib_npad_enabled)
            {
                //  If NPAD is enabled, we disable the user's ability to update
                //  the DPID.
                dw_generic.GetControlByName("cust_dpid").TabStop = false;

                if (ib_unnumbered)
                {
                    //  If the address is unnumbered, display the customer's DPID 
                    //  but only as a bit of unmodifiable information.
                    //? idw_customer.Object.cust_dpid.Background.mode = 1;
                    //? idw_customer.Object.cust_dpid.Border = 0;
                }
                else
                {
                    //  If the address is numbered, the user won't have a DPID 
                    //  so don't display either the (empty) DPID or its caption.
                    dw_generic.GetControlByName("t_cust_dpid").Visible = false;
                    dw_generic.GetControlByName("cust_dpid").Visible = false;
                }
            }
            //  If we're processing a non-RD contract
            //  hide the DPID.
            if (il_rdcontractselect == 0)
            {
                dw_generic.GetControlByName("cust_dpid").TabStop = false;
                dw_generic.GetControlByName("t_cust_dpid").Visible = false;
                dw_generic.GetControlByName("cust_dpid").Visible = false;
            }
            idw_recipients.Retrieve(new object[]{il_customer });
            idw_occupations.Retrieve(new object[]{il_customer });
            idw_interests.Retrieve(new object[]{il_customer });
            // If IsNull(idw_customer.GetItemDateTime(ll_row, 'cust_date_commenced').Date) Then
            // 	idw_customer.setitem(ll_row,"cust_date_commenced",today())
            // END IF
            dw_generic.GetControlByName("cust_surname_company").Focus();
            dw_generic.Focus();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            //  TJB  SR4678  Feb 2006
            int ll_row;
            string ls_phone;
            string ls_CustTitle;

            //  Determine if NPAD is enabled
            ib_npad_enabled = StaticVariables.gnv_app.of_get_npadenabled();
            is_npadoutdir = StaticVariables.gnv_app.of_get_npaddirectory();
            is_userid = StaticVariables.LoginId;
            if (ib_npad_enabled == null)
            {
                ib_npad_enabled = false;
            }
            if (is_npadoutdir == null)
            {
                is_npadoutdir = "";
            }
            if (is_userid == null)
            {
                is_userid = "";
            }
            //  Set the editmasks for the phone numbers
            bool change = false;

            ll_row = dw_generic.GetRow();
            if (NZPostOffice.Shared.StaticFunctions.IsDirty(dw_generic.DataObject))
            {
                change = true;
            }
            ls_phone = dw_generic.GetItem<CustomerDetails>(ll_row).CustPhoneDay;
            if (!(ls_phone == null))
            {
                if (ls_phone.Length >= 2 && ls_phone.Substring(0, 2) == "02")
                {
                    ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_day")).Mask = "(###) ###-#####";//!"(###) ### #####";
                }
                else
                {
                    ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_day")).Mask = "(##) ###-######";//!"(##) ### ######";
                }
            }
            ls_phone = dw_generic.GetItem<CustomerDetails>(ll_row).CustPhoneNight;
            if (!(ls_phone == null))
            {
                if (ls_phone.Length >= 2 && ls_phone.Substring(0, 2) == "02")
                {
                    ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_night")).Mask = "(###) ###-#####";//!"(###) ###-#####";
                }
                else
                {
                    ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_night")).Mask = "(##) ###-######";//!"(##) ###-######";
                }
            }
            if (change == false )
            {
                dw_generic.GetItem<CustomerDetails>(ll_row).MarkClean();
            }
            ls_CustTitle = dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle;
            ls_CustTitle = (ls_CustTitle == null) ? "" : ls_CustTitle.Trim();
            ((DCustomerDetails)(dw_generic.DataObject)).CustTitleCombo.Text = ls_CustTitle;
            ((DCustomerDetails)(dw_generic.DataObject)).CustTitleCombo.SelectedValue = ls_CustTitle;

            if (dw_generic.GetItem<CustomerDetails>(ll_row).MasterCustId == null)
            {
                dw_generic.GetControlByName("VR_number_t").Visible = true;
                dw_generic.GetControlByName("VR_number").Visible = true;
            }
            else
            {
                dw_generic.GetControlByName("VR_number_t").Visible = false;
                dw_generic.GetControlByName("VR_number").Visible = false;
            }

            //  Clear any update flags that may have been applied to fields
            //  - the system thinks it may have to (and asks for permission 
            //    to) save changes even when the user hasn't made any
            // Post to unused event
            this.ue_set_security();
        }

        public override void show()
        {
            base.show();
            // Hide the recipients, occupations and interest tabs if displaying a recipients 
            // details in the customer window

            //! in case of non primary recipient remove 3 tab pages consecutively 
            if (dw_generic.GetItem<CustomerDetails>(0).MasterCustId > 0)
                {
                //!tabpage_2.Enabled = false;                
                //!tabpage_2.Visible = false;                
                this.tab_1.TabPages.RemoveAt(1);

                //!tabpage_4.Enabled = false;
                //!tabpage_4.Visible = false;
                this.tab_1.TabPages.RemoveAt(1);

                //!tabpage_5.Enabled = false;
                //!tabpage_5.Visible = false;
                this.tab_1.TabPages.RemoveAt(1);
            }
        }

        #region Methods
        public int FindWithNull(DataUserControl dw, string propName, string value)
        {
            int find_row = -1;
            for (int i = 0; i < dw.RowCount; i++)
            {
                if (Convert.ToString(dw.GetValue(i, propName)) == value)
                {
                    find_row = i;
                    break;
                }
            }
            return find_row;
        }

        public virtual void ue_set_security()
        {
            ib_Opening = false;
        }

        public override void close()
        {
            base.close();
            //? Commit;
        }

        public virtual bool of_validate()
        {
            int? lNull;
            string sReturn = "";
            string sTitle;
            int lCount;
            int lContract;
            string stemp;
            lNull = null;
            if (sReturn == "")
            {
                if (dw_generic.uf_not_entered(1, "cust_surname_company", "surname/ company"))
                {
                    sReturn = "cust_surname_company";
                }
                else if (dw_generic.uf_not_entered(1, "cust_mail_town", "Town / City"))
                {
                    sReturn = "cust_mail_town";
                }
                else if (dw_generic.uf_not_entered(1, "cust_mailing_address_road", "mailing address"))
                {
                    sReturn = "cust_mailing_address_road";
                }
                else if (dw_generic.GetItem<CustomerDetails>(0).IsNew && dw_generic.GetItem<CustomerDetails>(0).IsDirty)
                {
                    il_customer = StaticFunctions.GetNextSequence("customer");
                    dw_generic.GetItem<CustomerDetails>(0).CustId = il_customer;
                    sTitle = "Customer: (" + il_customer.ToString() + ") "
                              + dw_generic.GetItem<CustomerDetails>(0).CustSurnameCompany;
                    if (!(StaticFunctions.f_isempty(dw_generic.GetItem<CustomerDetails>(0).CustInitials)))
                    {
                        sTitle = sTitle + ", " + dw_generic.GetItem<CustomerDetails>(0).CustInitials;
                    }
                    this.Text = sTitle;
                }
                else if (sReturn == "")
                {
                    sTitle = "Customer: (" + il_customer.ToString() + ") "
                              + dw_generic.GetItem<CustomerDetails>(0).CustSurnameCompany;
                    if (!(StaticFunctions.f_isempty(dw_generic.GetItem<CustomerDetails>(0).CustInitials)))
                    {
                        sTitle = sTitle + ", " + dw_generic.GetItem<CustomerDetails>(0).CustInitials;
                    }
                    this.Text = sTitle;
                }
            }
            return sReturn.Length == 0;
        }

        public virtual int uf_new_custid()
        {
            //  TJB  SR4559  15-Mar-2005
            //  Insert a new custID in the customer record if there isn't one
            //  there already  ( new customerID).
            //  Returns
            // 	   1	Succeeded - new custID created
            // 	   0	Succeeded - no new ID created - not needed
            // 	  -1	Failed  ( setItem failed)
            int ll_row;
            int li_rc = 0;
            if (il_customer == null || il_customer <= 0)
            {
                ll_row = dw_generic.GetRow();
                il_customer = StaticFunctions.GetNextSequence("customer");
                li_rc = 0; dw_generic.GetItem<CustomerDetails>(ll_row).CustId = il_customer;
            }
            return li_rc;
        }

        public virtual int uf_flag_customer()
        {
            //  TJB  SR4559  14-Mar-2005
            //  Called to insert the user's ID and the current date
            //  in the customer record, when a change is made to it
            //  or related information on the w_customer tabs.
            //  Returns
            // 	   1	Succeeded - new custID created
            // 	   0	Succeeded - no new ID created - not needed
            // 	  -1	Failed (update failed)
            int ll_row;
            int li_rc = 0;
            string ls_userid;
            ll_row = dw_generic.GetRow();
            ls_userid = StaticVariables.LoginId;
            dw_generic.GetItem<CustomerDetails>(ll_row).CustLastAmendedUser = ls_userid;
            dw_generic.GetItem<CustomerDetails>(ll_row).CustLastAmendedDate = System.DateTime.Today;
            li_rc = 1; dw_generic.Save();
            return li_rc;
        }

        public virtual int? of_getdpid(int? al_custid)
        {
            //  TJB  NPAD2  Jan 2006
            //  Look up the DPID of the customer
            int? ll_dpid = null;
            /* select dp_id 
                into :ll_dpid
                from customer_address_moves
                where cust_id = :al_custId
                and move_out_date is null
                using SQLCA; */
            RDSDataService dataService = RDSDataService.GetCustomerAddressMovesDpId(al_custid);
            ll_dpid = dataService.intVal;
            return ll_dpid;
        }

        public virtual int uf_savechanges()
        {
            //  TJB  NPAD2  Jan 2006  - New
            //  Returns idw_customer.update() status
            // 		 1		Success
            // 		-1		Error
            // 
            //  10 Apr 2006  TJB  NPAD2 fixups
            //  Changed output of NPAD message file to use function
            int ll_row;
            int ll_rc;
            int? ll_cust;
            int? ll_custdpid;
            string ls_userid;
            string ls_null;
            string ls_surname;
            string ls_initials;
            string ls_title;
            string ds_cust;
            string ds_msg;
            bool lb_name_changed;
            ls_null = null;
            ll_row = dw_generic.GetRow();
            if (dw_generic.GetItem<CustomerDetails>(ll_row).CustDateCommenced == null)
            {
                // TJB  RD7_CR002  Feb-2010: Changed
                // Changed to set only the date, not date + time
                //dw_generic.GetItem<CustomerDetails>(ll_row).CustDateCommenced = System.DateTime.Today;
                dw_generic.GetItem<CustomerDetails>(ll_row).CustDateCommenced = System.DateTime.Today.Date;
            }
            //  If this is a new customer, it will be a new master.
            if (ib_new)
            {
                //  Set defaults where not defined by the user
                if (dw_generic.GetItem<CustomerDetails>(ll_row).CustBusiness == null)
                {
                    dw_generic.GetItem<CustomerDetails>(ll_row).CustBusiness = false;
                }
                if (dw_generic.GetItem<CustomerDetails>(ll_row).CustRuralResident == null)
                {
                    dw_generic.GetItem<CustomerDetails>(ll_row).CustRuralResident = false;
                }
                if (dw_generic.GetItem<CustomerDetails>(ll_row).CustRuralFarmer == null)
                {
                    dw_generic.GetItem<CustomerDetails>(ll_row).CustRuralFarmer = true;
                }
                if (dw_generic.GetItem<CustomerDetails>(ll_row).CustDirListingInd == null)
                {
                    dw_generic.GetItem<CustomerDetails>(ll_row).CustDirListingInd = "Y";
                }
            }
            //  Update the last_amended values
            ls_userid = StaticVariables.LoginId;
            dw_generic.GetItem<CustomerDetails>(ll_row).CustLastAmendedUser = ls_userid;
            dw_generic.GetItem<CustomerDetails>(ll_row).CustLastAmendedDate = System.DateTime.Today;
            ll_rc = 1; 
            dw_generic.Save();
            if (!(ll_rc == 1))
            {
                //  If there's a problem, tell the user about it
                ll_cust = dw_generic.GetItem<CustomerDetails>(ll_row).CustId;
                if (ll_cust == null)
                    ds_cust = "null";
                else
                    ds_cust = ll_cust.ToString();

                if (ib_new)
                    ds_msg = "Error creating new customer.\n ";
                else
                    ds_msg = "Error updating customer record.\n ";

                MessageBox.Show(ds_msg + "(cust_id = '" + ds_cust + "')"
                               , "ERROR"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ii_kiwi_ok == 1 && !ib_new)
            {
                //  If the update was successful and we're modifying
                //  an existing customer (not creating a new one) ...
                //  TJB  NPAD  Jan 2006
                //  Check to see if the customer's name was changed
                ll_row = dw_generic.GetRow();
                ls_surname  = dw_generic.GetItem<CustomerDetails>(ll_row).CustSurnameCompany;
                ls_initials = dw_generic.GetItem<CustomerDetails>(ll_row).CustInitials;
                ls_title    = dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle;
                ls_surname  = (ls_surname == null)  ? "" : ls_surname.Trim();
                ls_initials = (ls_initials == null) ? "" : ls_initials.Trim();
                ls_title    = (ls_title == null)    ? "" : ls_title.Trim();

                lb_name_changed = false;
                if (!(ls_surname == is_old_surname) 
                    || !(ls_initials == is_old_initials) 
                    || !(ls_title == is_old_title))
                {
                    lb_name_changed = true;
                }
                //  If the customer's name has been changed and NPAD is enabled
                //  and this is a customer at an unnumbered address, we need to 
                //  tell NPAD the customer's new name.
                if (lb_name_changed && ib_unnumbered && (bool)ib_npad_enabled && il_rdcontractselect == 1)
                {
                    ll_custdpid = of_getdpid(il_customer);
                    /* ***********************************************************************
                    *		string	ls_npadoutdir, ls_npadoutfile, ls_npadfilename
                    *		string	ls_description
                    *		
                    *		ls_userid       = gnv_app.of_getuserid()
                    *		ls_npadoutdir   = gnv_app.of_get_npadDirectory()
                    *		ls_npadfilename = 'RDS_NPAD_'+string(now(),'yyyymmdd_hhmmssfff')+'.xml'
                    *		ls_npadoutfile  = ls_npadoutdir + '\\' + ls_npadfilename
                    *		ls_description  = 'Customer name change'
                    *********************************************************************** */
                    ll_rc = of_npad_modifyone(ll_custdpid, ls_surname, ls_initials, ls_title);
                    /* ***********************************************************************
                    *		select f_rds_npad_modify_customer(  
                    *							:ll_custdpid, 
                    *							:ls_userid,
                    *							:ls_description,
                    *							:ls_npadoutfile)
                    *		  into :ll_rc
                    *		  from dummy
                    *		 using SQLCA;
                    *		 
                    *		if not ll_rc = 0 then
                    *			messagebox('Error',
                    *					 'Error writing NPAD modify_customer XML file\n'
                    *					+'Error code    = '+ll_rc.ToString()+'\r\n'
                    *					+'Customer DPID = '+ds_custdpid+'\r\n'
                    *					+'XML filename  = '+ls_npadoutfile)
                    *		end if		
                    *********************************************************************** */
                }
            }
            return ll_rc;
        }

        public virtual int uf_addcam()
        {
            //  TJB  NPAD2  - New -
            //  Add a record to the customer_address_moves table
            //  Called when a new customer is created.
            // 
            //  Returns	(compatible with uf_savechanges)
            // 	   1    Success
            // 	  -1    Error
            int? ll_temp = null;
            int ll_rc;
            int ll_row;
            int? ll_cust;
            int? ll_dpid;
            string ds_msg = "";
            ll_rc = 0;
            //  First, check that we have an address for the customer
            if (il_adrid == null || il_adrid <= 0)
            {
                ll_rc = -(1);
                ds_msg = "No address for customer?";
            }
            else
            {
                //  Next, does the customer already have an entry
                //  in the customer_address_moves table?  If so,
                //  its an error.
                /* select 1 into :ll_temp
                    from customer_address_moves cam
                    where cust_id = :il_cust_id
                    and move_out_date is null
                    using SQLCA; */
                RDSDataService dataService = RDSDataService.GetCustomerAddressMovesTemp(il_cust_id);
                ll_temp = dataService.intVal;
                if (!(ll_temp == null) && ll_temp == 1)
                {
                    ll_rc = -(1);
                    ds_msg = "Customer exists in customer_address_moves!";
                }
            }
            //  If there was an error, tell the user about it.
            if (ll_rc == -(1))
            {
                ds_msg = "Error adding record to customer_address_moves.\n " 
                         + ds_msg + '\n';
            }
            if (ll_rc == 0)
            {
                ll_rc = 1;
                //  Get the new customer's ID and insert the new record
                ll_row = dw_generic.GetRow();
                ll_cust = dw_generic.GetItem<CustomerDetails>(ll_row).CustId;
                ll_dpid = dw_generic.GetItem<CustomerDetails>(ll_row).CustDpid;
                /* insert into customer_address_moves
                    ( adr_id, cust_id, dp_id, move_in_date, 
                      move_out_date, move_out_source, move_out_user )
                values
                    ( :il_adrid, :ll_cust, :ll_dpid, today(), 
                      NULL, NULL, NULL )
                using SQLCA; */
                RDSDataService dataService = RDSDataService.InsertCustomerAddressMoves3(ll_cust, il_adrid, ll_dpid);
                if (!(dataService.SQLCode == 0))
                {
                    MessageBox.Show("Error inserting new record into customer_address_moves table.\n\n" 
                                      + "Error = " + dataService.SQLErrText
                                    , "Database Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ll_rc = -(1);
                }
            }
            return ll_rc;
        }

        public virtual int of_npad_modifyone(int? al_dpid, string as_surname, string as_initials, string as_title)
        {
            //  TJB  NPAD2  Jan 2006  - New -
            //  Send NPAD modify_customer message
            // 
            //  Returns
            // 		0		Success
            // 		1		(or other non-zero) Error
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
            string ls_description;
            li_rc = 0;
            ls_description = "RDS Modify customer name";
            ds_dpid = al_dpid.ToString();
            if (al_dpid == null)
            {
                ds_dpid = "null";
            }
            //  XML message file info

            // select f_getNextSequence('NPADFileSeq',1,10000) into :ll_npadfileseq from dummy using SQLCA; 
            RDSDataService dataService = RDSDataService.GetNextSequence("NPADFileSeq");
            ll_npadfileseq = dataService.intVal;
            if (ll_npadfileseq == null || ll_npadfileseq <= 0)
            {
                MessageBox.Show("Failed to obtain sequence number for NPAD XML message filename. "
                               , "ERROR"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                ls_npadfileseq = DateTime.Now.ToString("fff");
            }
            else
            {
                ls_npadfileseq = string.Format("0000", ll_npadfileseq);
            }
            is_npadfilename = "RDS_NPAD_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") 
                              + "_" + ls_npadfileseq 
                              + ".xml";
            is_npadoutfile = is_npadoutdir + "\\" + is_npadfilename;
            if (al_dpid == null || al_dpid < 1)
            {
                MessageBox.Show("The customer DPID is null. \n" 
                                 + "This may indicate an inconsistency in the database. \n\n" 
                                 + "DPID    = " + ds_dpid
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // select f_rds_npad_modify_customer(:al_dpid, :is_userid, :ls_description, :is_npadoutfile) into :li_rc from dummy using SQLCA;
                dataService = RDSDataService.GetRdsNpadModifyCustomer(al_dpid, is_userid, is_npadoutfile, ls_description);
                li_rc = dataService.intVal;
                if (li_rc > 0)
                {
                    MessageBox.Show("Error sending modify_customer message.\n" 
                                     + "Return code = " + li_rc + "\n\n" 
                                     + "(see npad_msg_log table for more detail)"
                                   , "Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (li_rc < 0)
                {
                    MessageBox.Show("Error writing XML message file (RC=" + li_rc + ").\n" 
                                     + "    " + is_npadoutfile + "\n\n" 
                                     + "Possible cause: the output directory may not exist."
                                   , "SQL Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return li_rc;
        }

        public virtual bool of_samename(string as_old_surname, string as_old_initials, string as_old_title, string as_new_surname, string as_new_initials, string as_new_title)
        {
            //  TJB  NPAD2  March 2006  - new
            //  Compare two names, components of which may be null
            string ls_old_surname;
            string ls_old_initials;
            string ls_old_title;
            string ls_new_surname;
            string ls_new_initials;
            string ls_new_title;
            ls_old_surname = as_old_surname;
            ls_old_initials = as_old_initials;
            ls_old_title = as_old_title;
            ls_new_surname = as_new_surname;
            ls_new_initials = as_new_initials;
            ls_new_title = as_new_title;
            if (ls_old_surname == null)
                ls_old_surname = "";
            if (ls_old_initials == null)
                ls_old_initials = "";
            if (ls_old_title == null)
                ls_old_title = "";
            if (ls_new_surname == null)
                ls_new_surname = "";
            if (ls_new_initials == null)
                ls_new_initials = "";
            if (ls_new_title == null)
                ls_new_title = "";
            if (ls_old_surname == ls_new_surname 
                && ls_old_initials == ls_new_initials 
                && ls_old_title == ls_new_title)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual int uf_save_cust()
        {
            //  TJB  NPAD2  Apr 2006   - New -
            //  Check that customer details are OK then save
            //  (taken from cb_save.clicked so it can be called from the
            //   selectionchanging event when the user switches tabs).
            // 
            //  Returns
            // 	  0		OK
            // 	 -1		Failed update
            // 	 -2		Failed validation

            int ll_row;
            int ll_rc;
            int? ll_tmp_dpid;
            string ls_surname;
            string ls_initials;
            string ls_CustTitle;
            //  TJB  NPAD2 CR32  Feb 2006
            //  Don't allow the user to save the changes if the 
            //  customer's title hasn't been fixed.
            //  NOTE: the idw_customer.accepttext() triggers the
            //        itemchanged event that checks the customer's 
            //        title, so this test must come after it.
            ll_rc = 0;
            ll_row = dw_generic.GetRow();
            ls_CustTitle = dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle;
            ls_CustTitle = (ls_CustTitle == null) ? "" : ls_CustTitle.Trim();

            if (!uf_validate_cust_title(ls_CustTitle))
            {
                MessageBox.Show("Please select a valid customer title before saving. "
                               , "WARNING"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -(2);
            }
            ls_surname = dw_generic.GetItem<CustomerDetails>(ll_row).CustSurnameCompany;
            if (ls_surname == null || ls_surname == "")
            {
                MessageBox.Show("A customer must have a name.\n "
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(2);
            }
            else
            {
                ll_rc = uf_savechanges();
            }
            if (ll_rc == 1 && ib_new)
            {
                ll_rc = uf_addcam();
            }
            else
            {
                //  If the DPID has been changed, update it in the 
                //  customer_address_moves table.
                //  (NOTE: it may be null either before or after)
                ll_row = dw_generic.GetRow();
                ll_tmp_dpid = dw_generic.GetItem<CustomerDetails>(ll_row).CustDpid;
                ll_tmp_dpid  = (ll_tmp_dpid == null)  ? 0 : ll_tmp_dpid;
                il_cust_dpid = (il_cust_dpid == null) ? 0 : il_cust_dpid;
                if (!(ll_tmp_dpid == il_cust_dpid))
                {
                    uf_savedpid(ll_tmp_dpid);
                }
            }
            //  TJB  NPAD2  March 2006
            //  If NPAD is enabled and the customer has a DPID and we're 
            //  working on an RD contract, send a 'modified_customer' 
            //  message to NPAD.
            if ((bool)ib_npad_enabled && ll_rc == 1 && il_rdcontractselect == 1)
            {
                ll_row = dw_generic.GetRow();
                ll_tmp_dpid = dw_generic.GetItem<CustomerDetails>(ll_row).CustDpid;
                if (!(ll_tmp_dpid == null) && ll_tmp_dpid > 0)
                {
                    ls_surname   = dw_generic.GetItem<CustomerDetails>(ll_row).CustSurnameCompany;
                    ls_initials  = dw_generic.GetItem<CustomerDetails>(ll_row).CustInitials;
                    ls_CustTitle = dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle;
                    ls_surname   = (ls_surname == null) ? "" : ls_surname.Trim();
                    ls_initials  = (ls_initials == null) ? "" : ls_initials.Trim();
                    ls_CustTitle = (ls_CustTitle == null) ? "" : ls_CustTitle.Trim();

                    //  If the customer's name hasn't changed, there's no need to tell NPAD
                    if (!(of_samename(is_old_surname, is_old_initials, is_old_title, ls_surname, ls_initials, ls_CustTitle)))
                    {
                        of_npad_modifyone(ll_tmp_dpid, ls_surname, ls_initials, ls_CustTitle);
                    }
                }
            }
            // The functions uf_savechanges and uf_addcam return 1 for success
            // and -1 for failure.  Change the (+)1 to 0 to return success.
            ll_rc = (ll_rc == 1) ? 0 : ll_rc;
            return ll_rc;
        }

        public virtual int uf_addcam_recipients()
        {
            //  TJB  NPAD2  - New -
            //  Add customer_address_moves table records for the recipients.  
            // 
            //  Called when the recipients tab is being saved after the 
            //  recipients changes have been saved (so that new recipients'
            //  cust_id's will have been created).
            // 
            //  NOTE:  Don't need to worry about deleting recipients; if a 
            //         recipient is deleted, the system automatically deletes 
            //         the CAM record via the foreign key to preserve 
            //         consistency.
            // 
            //  Returns	(compatible with uf_savechanges)
            // 	   1		Success
            // 	  -1		Error
            // 	  -2		Error: no address
            int ll_row;
            int ll_rows;
            int? ll_temp;
            int? ll_cust;
            //  First, check that we have an address for the customer
            if (il_adrid == null || il_adrid <= 0)
            {
                return -(2);
            }
            //  Save new records for any new recipients
            //  We scan the whole recipients primary buffer since the update
            //  has completed thus any new or deleted recipients changes will
            //  have already been committed.
            ll_rows = idw_recipients.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //  Get the recipient's cust ID
                ll_cust = idw_recipients.GetItem<Recipient>(ll_row).CustId;
                //  Next, does the recipient already have an entry
                //  in the customer_address_moves table?
                ll_temp = 0;
                /* select 1 into :ll_temp
                    from customer_address_moves cam
                    where cust_id = :ll_cust
                    and move_out_date is null
                    using SQLCA; */
                RDSDataService dataService = RDSDataService.GetCustomerAddressMovesTemp(ll_cust);
                ll_temp = dataService.intVal;
                if (!(dataService.SQLCode == 0 || dataService.SQLCode == 100))
                {
                    MessageBox.Show("Error checking for recipient record in customer_address_moves table. \n\n" 
                                     + "Error = " + dataService.SQLErrText
                                   , "Database Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return -(1);
                }
                if (ll_temp == null || ll_temp <= 0)
                {
                    //  There's no record for the recipient
                    //  Add the recipient record to the CAM table
                    /* insert into customer_address_moves
                     *  ( adr_id, cust_id, dp_id, move_in_date, move_out_date, move_out_source, move_out_user )
                     *  values
                     *   ( :il_adrid, :ll_cust, NULL, today(), NULL, NULL, NULL )
                     *  using SQLCA; */
                    dataService = RDSDataService.InsertCustomerAddressMoves2(ll_cust, il_adrid);
                    if (!(dataService.SQLCode == 0))
                    {
                        MessageBox.Show("Error inserting new recipient record into customer_address_moves table. \n\n" 
                                          + "Error = " + dataService.SQLErrText
                                       , "Database Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                }
            }
            return 1;
        }

        public virtual void wf_closethis()
        {
            this.Close();
        }

        public virtual void uf_savedpid(int? al_dpid)
        {
            //  TJB  NPAD2  - New -
            //  Save the customer's new DPID

            //  Update the DPID in the customer_address_moves table.
            // UPDATE customer_address_moves set dp_id = :al_dpid where cust_id = :il_customer and move_out_date is null using SQLCA; 
            RDSDataService dataService = RDSDataService.UpdateCustomerAddressMovesDpId(il_customer, al_dpid);
        }

        public virtual void of_setcustattributes(int al_row)
        {
            //  TJB  NPAD2  pre-GoLive    - new -
            //  Split out of the pfc_preopen event so it can be called from 
            //  other events (see selectionchanging)

            // IF IsNull(idw_customer.GetItemString(ll_row, 'cust_dir_listing_ind')) THEN
            // 	idw_customer.SetItem(ll_row, "cust_dir_listing_ind", "Y")
            // END IF
            //  set the kiwimail variable

            ii_original_kiwi = dw_generic.GetItem<CustomerDetails>(al_row).CustAdpostQuantity;
            if (ii_original_kiwi == null)
            {
                ii_original_kiwi = 0;
            }
        }

        // TJB RD7_0042 Jan-2010: Added
        // Check that the entered customer title is one of those in the dropdown list
        public virtual bool uf_validate_cust_title(string as_CustTitle)
        {
            string this_CustTitle;

            // Get a reference to the customer title list
            List<DddwCustTitle> CustTitleList
                = ((DCustomerDetails)(dw_generic.DataObject)).CustTitleCombo.DataSource
                               as List<DddwCustTitle>;

            // Normalise the customer title to search for
            as_CustTitle = as_CustTitle.Trim();

            // Scan the customer title list looking for a match
            // If a match is found, return TRUE (yes we found it)
            // If no match is found, return FALSE
            foreach (DddwCustTitle item in CustTitleList)
            {
                this_CustTitle = item.CustomerTitle.Trim();
                if (this_CustTitle == as_CustTitle)
                    return true;
            }
            return false;
        }

        public virtual void dw_generic_ue_validate(int al_row, string as_colname)
        {
            int? ll_kiwi;
            DialogResult ll_response;
            string ls_phone;
            string column_lower;

            //  TJB  SR4678  Feb 2006
            //  Set the editmasks for the phone numbers
            column_lower = as_colname.ToLower();
            if (column_lower == "cust_phone_day")
            {
                ls_phone = dw_generic.GetItem<CustomerDetails>(al_row).CustPhoneDay;
                if (!(ls_phone == null))
                {
                    if (ls_phone.Substring(0, 2) == "02")
                    {
                        ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_day")).Mask = "(###) ###-#####";
                    }
                    else
                    {
                        ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_day")).Mask = "(##) ###-######";
                    }
                }
            }
            else if (column_lower == "cust_phone_night")
            {
                ls_phone = dw_generic.GetItem<CustomerDetails>(al_row).CustPhoneNight;
                if (!(ls_phone == null))
                {
                    if (ls_phone.Substring(0, 2) == "02")
                    {
                        ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_night")).Mask = "(###) ###-#####";//!" ( ###) ###-#####";
                    }
                    else
                    {
                        ((MaskedTextBox)dw_generic.GetControlByName("cust_phone_night")).Mask = "(##) ###-######";//!" ( ##) ###-######";
                    }
                }
            }
            else if (column_lower == "cust_adpost_quantity")
            {
                //  Code to validate the kiwimail field
                //  get the value of kiwimail :
                ll_kiwi = dw_generic.GetItem<CustomerDetails>(0).CustAdpostQuantity;
                if (ll_kiwi == null)
                {
                    ll_kiwi = 0;
                }
                if (ll_kiwi > 3 && ll_kiwi != ii_original_kiwi)
                {
                    if (ll_kiwi > 99)
                    {
                        MessageBox.Show("Input quantity must be less than 100! Please reinput"
                                       , "Warning"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ll_response = DialogResult.None;
                    }
                    else
                    {
                        ll_response = MessageBox.Show("Have you entered the correct quantity required for Kiwimail?"
                                                     , "Warning"
                                                     , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    if (ll_response != DialogResult.Yes)
                    {
                        dw_generic.GetItem<CustomerDetails>(al_row).CustAdpostQuantity = ii_original_kiwi;
                        //  Set focus back to the cust_adpost_quantity
                        dw_generic.GetControlByName("cust_adpost_quantity").TabIndex = 5;
                        dw_generic.Retrieve(new object[] { il_customer });
                        dw_generic.Focus();
                        ii_kiwi_ok = -(1);
                    }
                    else
                    {
                        ii_original_kiwi = ll_kiwi;
                        ii_kiwi_ok = 1;
                    }
                }
                else
                {
                    dw_generic.GetControlByName("cust_adpost_quantity").TabIndex = 70;
                    ii_kiwi_ok = 1;
                }
            }
        }

        private delegate void delegateInvoke();

        public virtual void dw_generic_constructor()
        {
            //? base.constructor();
            dw_generic = dw_generic;
            BeginInvoke(new delegateInvoke(conInvoke));
        }

        //added by jlwang
        public virtual void conInvoke()
        {
            dw_generic.of_set_deletepriv(false);
            dw_generic.of_set_createpriv(false);
            dw_generic.URdsDw_GetFocus(null, null);
        }

        // TJB RD7_0042 Jan-2010: New
        //     Use a change in column as the trigger for dw_generic_ue_itemchanged
        //     If the prev_columnName is empty, we've just started and don't need 
        //     do the itemchanged procedure.

        public virtual void dw_generic_itemfocuschanged(object sender, EventArgs e)
        {
            // TJB The local variables are there to make it easier to see what's happening
            //     when debugging.  The variable 't' is needed to make the prev_prev_column 
            //     and prev_column's visible.
            // string this_column;
            // string prev_prev_column, prev_column, t;
            // prev_prev_column = prev_columnName;
            // prev_column = this_columnName;
            // this_column = dw_address.GetColumnName();
            // t = prev_prev_column; t = prev_column; t = this_column;
            prev_column = this_column;
            this_column = dw_generic.GetColumnName();
            if (!(prev_column == "") && !(prev_column == this_column) )
                dw_generic_ue_itemchanged(sender, e, prev_column);
        }

        // TJB RD7_0042 Jan-2010: Changed
        // Changed name to ue_itemchanged
        // Changed parameters: added name of column that may have just changed
        public virtual void dw_generic_ue_itemchanged(object sender, EventArgs e, string column)
        {
            //  base.itemchanged();
            dw_generic.URdsDw_Itemchanged(sender, e);
            //  TJB  NPAD2  CR32  Feb 2006
            //  Add dropdown list of valid titles
            //  If user enters an invalid title, issue a message
            //  advising them to request the new title be added
            //  to the list (and disallow the new title).
            int ll_row;
            int? ll_titleId;
            string ls_CustTitle, dddw_CustTitle;
            string ls_null;
            
            dw_generic.AcceptText();
            ll_row = dw_generic.GetRow();
            CustomerDetails currentRecord = dw_generic.DataObject.Current as CustomerDetails;

            if (column == "cust_title")
            {
                // TJB RD7_0042 Jan-2010: Changed
                // Changed handling of customer title to use a list for the dropdown
                // separate from the data record.
                // Lots of commented-out code removed for clarity.

                // ls_CustTitle is the data record value while dddw_CustTitle is the dropdown value
                ls_CustTitle = dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle;
                ls_CustTitle = (ls_CustTitle == null) ? "" : ls_CustTitle.Trim();
                dddw_CustTitle = ((DCustomerDetails)(dw_generic.DataObject)).CustTitleCombo.Text;
                dddw_CustTitle = (dddw_CustTitle == null) ? "" : dddw_CustTitle.Trim();

                // Validate the entered customer title (the user can type in anything
                // and not select one of the dddw values).  If it is invalid, leave it 
                // as is; attempting to save with an invalid customer title will fail.
                if (!uf_validate_cust_title(dddw_CustTitle))
                {
                   //  The title is wrong
                   MessageBox.Show("The only valid titles are those in the dropdown list. \n" 
                                    + "If you wish to add a new title to the list, please \n" 
                                    + "contact the Rural Delivery System support person at \n" 
                                    + "Head Office."
                                  , "WARNING"
                                  , MessageBoxButtons.OK, MessageBoxIcon.Information);
                   //((DCustomerDetails2)(dw_generic.DataObject)).CustTitleCombo.SelectedValue = ls_CustTitle;
                   return; //? return 2;
                }
                // If the customer's title has changed (in the dddw), change it in the record
                if (!(ls_CustTitle == dddw_CustTitle))
                {
                    dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle = dddw_CustTitle;
                    //((DCustomerDetails2)(dw_generic.DataObject)).CustTitleCombo.Text = dddw_CustTitle;
                    ((DCustomerDetails)(dw_generic.DataObject)).CustTitleCombo.SelectedValue = dddw_CustTitle;
                }
            }
            else  // Its a non-customer title column that has changed
            {
                // Validate the column
                dw_generic_ue_validate(ll_row, column);
            }
        }

        public virtual int dw_generic_pfc_validation()
        {
            DateTime? ld_cust_date_commenced;
            string ls_cust_surname_company;
            int ll_row = dw_generic.GetRow();

            dw_generic.AcceptText();

            // Validate Data
            ld_cust_date_commenced = dw_generic.GetItem<CustomerDetails>(ll_row).CustDateCommenced;
            if (ld_cust_date_commenced == null 
                || ld_cust_date_commenced == DateTime.MinValue  /*System.Convert.ToDateTime("00/00/0000")*/)
            {
                MessageBox.Show("A commencment date must be specified."
                               , "Validation Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -(1);
            }
            ls_cust_surname_company = dw_generic.GetItem<CustomerDetails>(ll_row).CustSurnameCompany;
            if (ls_cust_surname_company == null || ls_cust_surname_company == "")
            {
                MessageBox.Show("A Surname/Company must be specified."
                               , "Validation Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_generic.GetControlByName("cust_surname_company").Focus();
                dw_generic.Focus();
                return -(1);
            }
            return 1;
        }

        public virtual int dw_generic_pfc_preupdate()
        {
            int ll_row;
            if (il_customer == null || il_customer <= 0)
            {
                ll_row = dw_generic.GetRow();
                il_customer = StaticFunctions.GetNextSequence("customer");
                dw_generic.GetItem<CustomerDetails>(ll_row).CustId = il_customer;
            }
            return 1;// ancestorreturnvalue;
        }

        public virtual void dw_generic_pfc_postupdate()
        {
            string ls_form_title;
            if (true)   /*? ancestorreturnvalue == SUCCESS*/
            {
                // Set Form Title
                if (il_customer > 0)
                {
                    ls_form_title = "Customer: (" + il_customer.ToString() + ") " 
                             + dw_generic.GetItem<CustomerDetails>(0).CustSurnameCompany;
                    if (!(StaticFunctions.f_isempty(dw_generic.GetItem<CustomerDetails>(0).CustInitials)))
                    {
                        ls_form_title = ls_form_title + ", " + dw_generic.GetItem<CustomerDetails>(0).CustInitials;
                    }
                    this.Text = ls_form_title;
                }
            }
            return;
        }

        public virtual int dw_generic_pfc_preinsertrow()
        {
            //  TJB  NPAD2  Jan 2006
            if ((bool)ib_npad_enabled && ib_unnumbered)
            {
                MessageBox.Show("Inserting new customers is not allowed for unnumbered addresses.\n" 
                                 + "Please use the NPAD address creation function."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            return 1;
        }

        public virtual int dw_generic_pfc_predeleterow()
        {
            //  TJB  NPAD2  Jan 2006
            if ((bool)ib_npad_enabled && ib_unnumbered)
            {
                MessageBox.Show("Deleting customers is not allowed for unnumbered addresses \n" 
                                   + "using this screen.  Please use the \"Move Out\" function on \n" 
                                   + "the address maintenance screen."
                                , "Warning"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            return 1;
        }

        public virtual void dw_recipients2_constructor()
        {
            dw_recipients2.of_setautoinsert(true);
            idw_recipients = dw_recipients2;
        }

        public virtual int dw_recipients2_pfc_preupdate()
        {
            int ll_row;
            int? ll_rowcount;
            int? ll_getsequence;
            //  TJB  NPAD2  Jan 2006
            if (!StaticFunctions.IsDirty(dw_recipients2))
            {
                MessageBox.Show("No changes to save"
                               , "Information"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            ll_rowcount = dw_recipients2.RowCount;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                if (dw_recipients2.GetItem<Recipient>(ll_row).CustId == null)
                {
                    ll_getsequence = StaticFunctions.GetNextSequence("customer");
                    dw_recipients2.GetItem<Recipient>(ll_row).CustId = ll_getsequence;
                    dw_recipients2.GetItem<Recipient>(ll_row).MasterCustId = il_customer;
                    dw_recipients2.GetItem<Recipient>(ll_row).CustDirListingInd = "N";
                    // TJB  RD7_CR002  Feb-2010: Changed
                    // Changed to set only the date, not date + time
                    //dw_recipients2.GetItem<Recipient>(ll_row).CustDateCommenced = System.DateTime.Today;
                    dw_recipients2.GetItem<Recipient>(ll_row).CustDateCommenced = System.DateTime.Today.Date;
                }
            }
            dw_recipients2.AcceptText();
            return 1;
        }

        public virtual int dw_recipients2_pfc_validation()
        {
            string ls_cust_initials;
            string ls_cust_company;
            int ll_row;
            int ll_rowcount;
            // Validate Data
            ll_rowcount = dw_recipients2.RowCount;
            for (ll_row = ll_rowcount - 1; ll_row >= 0; ll_row -= 1)
            {
                ls_cust_initials = dw_recipients2.GetItem<Recipient>(ll_row).CustInitials;
                ls_cust_company = dw_recipients2.GetItem<Recipient>(ll_row).CustSurnameCompany;
                if (ls_cust_company == null || ls_cust_company == "")
                {
                    if (ls_cust_initials == null)
                    {
                        // if this is blank row, delete it
                        dw_recipients2.RowsDiscard(ll_row, ll_row);
                    }
                    else
                    {
                        MessageBox.Show("A recipient surname must be specified."
                                       , "Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -1;
                    }
                }
            }
            return 1;
        }

        public virtual void dw_recipients2_ue_deleteitem()
        {
            //  Ctrl+Insert = insert row = create new customer
            /*? if (keyflags == 2) {
                if (Key == keyinsert! && dw_recipients2.of_get_createpriv()) {
                    dw_recipients2.pfc_insertrow();
                }
                if (Key == keydelete! && dw_recipients2.of_get_deletepriv()) {
                    dw_recipients2.pfc_deleterow();
                }
            } */
        }

        public virtual int dw_recipients2_pfc_preinsertrow()
        {
            //  TJB  NPAD2  Jan 2006
            ((DataEntityGrid)(dw_recipients2.GetControlByName("grid"))).CurrentCell = null;//! deactivate the column in order to 
                                                                                           //!keep the value ther if other row is inserted
            if ((bool)ib_npad_enabled && ib_unnumbered && il_contract_no >= 5000 && il_contract_no <= 5999)
            {
                MessageBox.Show("New recipients may not be created for unnumbered addresses \n" 
                                  + "using this screen.  Please use NPAD to create new recipients. \n"
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            return 1;
        }

        public virtual int dw_recipients2_pfc_predeleterow()
        {
            //  TJB  NPAD2  Jan 2006
            if ((bool)ib_npad_enabled && ib_unnumbered && il_contract_no >= 5000 && il_contract_no <= 5999)
            {
                MessageBox.Show("Recipients may not be deleted for unnumbered addresses \n" 
                                   + "using this screen.  Please use the \"Move Out\" function \n" 
                                   + "on the address maintenance screen."
                                , "Warning"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            return 1;
        }

        public virtual void dw_occupations_constructor()
        {
            dw_occupations.of_setautoinsert(true);
            idw_occupations = dw_occupations;
        }

        public virtual int dw_occupations_pfc_preupdate()
        {
            int ll_row;
            int ll_rowcount;
            ll_rowcount = dw_occupations.RowCount;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                if (dw_occupations.GetItem<CustomerOccupations>(ll_row).CustId == null)
                {
                    dw_occupations.GetItem<CustomerOccupations>(ll_row).CustId = il_customer;
                }
            }
            dw_occupations.AcceptText();
            return 1;
        }

        public virtual int dw_occupations_pfc_validation()
        {
            int ll_row;
            int ll_rowcount;
            int? ll_found = -1;
            int? ll_occupation_id;
            ll_rowcount = dw_occupations.RowCount;
            for (ll_row = ll_rowcount - 1; ll_row >= 0; ll_row -= 1)
            {
                ll_occupation_id = dw_occupations.GetItem<CustomerOccupations>(ll_row).OccupationId;
                //  if occupation id is null, user hasn't selected an entry.
                //  delete that row from the list
                if (ll_occupation_id == null)
                {
                    dw_occupations.RowsDiscard(ll_row, ll_row);
                }
                else
                {
                    // ll_found = dw_occupations.Find( "occupation_id = " + ll_occupation_id.ToString() + " and getrow ( )<>" + ll_row).ToString().Length);
                    ll_found = dw_occupations.Find("occupation_id", ll_occupation_id);
                    if (ll_found == ll_row)
                        ll_found = -1;
                    //if (dw_occupations.GetItem<CustomerOccupations>(ll_row).OccupationId == ll_occupation_id)
                    //    ll_found = ll_row;
                    if (ll_found >= 0)
                    {
                        MessageBox.Show("The occupation you have selected already exsists. Please select another."
                                       , "Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                }
            }
            return 1;
        }

        public virtual void dw_occupations_ue_deleteitem()
        {
            //  Ctrl+Insert = insert row = create new customer
            /*? if (keyflags == 2) {
                if (Key == keyinsert! && dw_occupations.of_get_createpriv()) {
                    dw_occupations.pfc_insertrow();
                }
                if (Key == keydelete! && dw_occupations.of_get_deletepriv()) {
                    dw_occupations.pfc_deleterow();
                }
            } */
        }

        public virtual void dw_interests_constructor()
        {
            dw_interests.of_setautoinsert(true);
            idw_interests = dw_interests;
        }

        public virtual int dw_interests_pfc_preupdate()
        {
            int ll_row;
            int? ll_rowcount;
            ll_rowcount = dw_interests.RowCount;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                if (dw_interests.GetItem<CustomerInterests>(ll_row).CustId == null)
                {
                    dw_interests.GetItem<CustomerInterests>(ll_row).CustId = il_customer;
                }
            }
            dw_interests.AcceptText();
            return 1;
        }

        public virtual int dw_interests_pfc_validation()
        {
            int ll_row;
            int ll_rowcount;
            int ll_found = 0;
            int? ll_interest_id;
            ll_rowcount = dw_interests.RowCount;
            for (ll_row = ll_rowcount - 1; ll_row >= 0; ll_row -= 1)
            {
                ll_interest_id = dw_interests.GetItem<CustomerInterests>(ll_row).InterestId;
                //  if interset id is null, user hasn't selected an entry.
                //  delete that row from the list
                if (ll_interest_id == null)
                {
                    dw_interests.RowsDiscard(ll_row, ll_row);
                }
                else
                {
                    // ll_found = dw_interests.Find("interest_id = " + ll_interest_id.ToString() + " and getrow()<>" + ll_row).ToString().Length);
                    ll_found = dw_interests.Find("interest_id", ll_interest_id);
                    if (ll_found == ll_row)
                        ll_found = -1;

                    //if (dw_interests.GetItem<CustomerInterests>(ll_row).InterestId == ll_interest_id)
                    //    ll_found = ll_row;
                    if (ll_found >= 0)
                    {
                        MessageBox.Show("The interest you have selected already exsists. Please select another."
                                       , "Validation Error"
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return -(1);
                    }
                }
            }
            return 1;
        }

        public virtual void dw_interests_ue_deleteitem()
        {
            //  Ctrl+Insert = insert row = create new customer
            /*? if (keyflags == 2) {
                if (Key == keyinsert! && dw_interests.of_get_createpriv()) {
                    dw_interests.pfc_insertrow();
                }
                if (Key == keydelete! && dw_interests.of_get_deletepriv()) {
                    dw_interests.pfc_deleterow();
                }
            } */
        }

        #endregion

        #region Events

        int oldindex = 0;
        public virtual void tab1_selectionchanging(object sender, TabControlCancelEventArgs e)
        {
            DialogResult ll_ret;
            int ll_rc;

            //  TJB SR4559  14-Mar-2005
            //  Added calls to uf_flag_customer when user saves changes
            if (ib_Opening)
            {
                return;
            }

            // Check for new customer
            if (oldindex == 0)
            {
                //?  idw_customer.AcceptText();
                if (StaticFunctions.IsDirty(dw_generic.DataObject))
                {
                    ll_ret = MessageBox.Show("Do you want to save changes to the database?"
                                            , "Update Customer"
                                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ll_ret == DialogResult.Yes)
                    {
                        ll_rc = uf_save_cust();
                    }
                    else
                    {
                        e.Cancel = true;
                        return; //? return 1;
                        //  so don't let them change tabs.
                    }
                    if (ll_rc == 0)
                    {
                        ib_customers_modified = true;
                        oldindex = tab_1.SelectedIndex;
                        return; //? return 0;
                    }
                    else
                    {
                        e.Cancel = true;
                        return; //? return 1;
                    }
                }
            }
            //  Check recipients tab
            if (oldindex == 1)
            {
                //?idw_recipients.AcceptText();
                if (StaticFunctions.IsDirty(idw_recipients))
                {
                    ll_ret = MessageBox.Show("Do you want to save changes to the database?"
                                            , "Update Recipients"
                                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ll_ret == DialogResult.Yes)
                    {
                        uf_flag_customer();
                        //? lnv_luw = new NCstLuw();
                        //? ll_ret = lnv_luw.of_save(idw_recipients, StaticVariables.sqlca);
                        idw_recipients.Save();
                        ll_ret = DialogResult.OK;
                        // PB 'Destroy' Statement
                        //? lnv_luw = null;
                        if (ll_ret < 0)
                        {
                            MessageBox.Show("Error saving changes.  \n"
                                           , "ERROR"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                            return;
                            // return 1;
                        }
                        ll_ret = (DialogResult)uf_addcam_recipients();
                        if (ll_ret < 0)
                        {
                            MessageBox.Show("Error saving recipients customer_address_moves records. \n" 
                                             + "Error code = " + ll_ret
                                           , "Warning"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        ib_recipients_modified = true;
                        //? return 0;
                    }
                    else
                    {
                        idw_recipients.Retrieve(new object[]{il_customer });
                    }
                }
            }
            //  Check occupations tab
            if (oldindex == 2)
            {
                //?idw_occupations.AcceptText();
                if (StaticFunctions.IsDirty(idw_occupations))
                {
                    ll_ret = MessageBox.Show("Do you want to save changes to the database?"
                                            , "Update Occupations"
                                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ll_ret == DialogResult.Yes)
                    {
                        uf_flag_customer();
                        //? lnv_luw = new n_cst_luw();
                        //? ll_ret = lnv_luw.of_save(idw_occupations, StaticVariables.sqlca);
                        ll_ret = DialogResult.Yes; idw_occupations.Save();
                        // PB 'Destroy' Statement
                        //? lnv_luw = null;
                        if (ll_ret < 0)
                        {
                            MessageBox.Show("Error saving changes.  \n"
                                           , "ERROR"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                            return; // return 1;
                        }
                    }
                    else
                    {
                        idw_occupations.Retrieve(new object[]{il_customer });
                    }
                }
            }
            //  Check interests tab
            if (oldindex == 3)
            {
                //?idw_interests.AcceptText();
                if (StaticFunctions.IsDirty(idw_interests))
                {
                    ll_ret = MessageBox.Show("Do you want to save changes to the database?"
                                            , "Update Interests"
                                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ll_ret == DialogResult.Yes)
                    {
                        uf_flag_customer();
                        //? lnv_luw = new NCstLuw();
                        //? ll_ret = lnv_luw.of_save(idw_interests, StaticVariables.sqlca);
                        idw_interests.Save();
                        ll_ret = DialogResult.Yes;
                        // PB 'Destroy' Statement
                        //? lnv_luw = null;
                        if (ll_ret < 0)
                        {
                            MessageBox.Show("Error saving changes.  \n"
                                           , "ERROR"
                                           , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                            return; //? return 1;
                        }
                    }
                    else
                    {
                        idw_interests.Retrieve(new object[]{il_customer });
                    }
                }
            }
            oldindex = tab_1.SelectedIndex;
        }

        //added by jlwang
        public virtual void tab_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = tab_1.TabPages[tab_1.SelectedIndex].Text.ToLower().Trim();

            if (str == "recipients")         //(tab_1.SelectedIndex == 1)
            {
                dw_recipients2.URdsDw_GetFocus(null, null);
            }
            if (str == "occupations")        //(tab_1.SelectedIndex == 2)
            {
                idw_occupations.URdsDw_GetFocus(null, null);
            }
            if (str == "interests")          //(tab_1.SelectedIndex == 3)
            {
                dw_interests.URdsDw_GetFocus(null, null);
            }
        }

        //! added separated even handler for checkboxes
        private void dw_generic_ValidateCheckBoxes(object sender, EventArgs e)
        {
            //! assigning checked/unchecked value dirsctly on property otherwise property is not updated
            if (((Control)sender).Name == "cust_business")
            {
                dw_generic.GetItem<CustomerDetails>(0).CustBusiness = ((CheckBox)sender).Checked;
                if ((bool)dw_generic.GetItem<CustomerDetails>(0).CustBusiness)
                {
                    dw_generic.GetItem<CustomerDetails>(0).CustRuralFarmer = false;
                    dw_generic.GetItem<CustomerDetails>(0).CustRuralResident = false;
                }
            }
            else if (((Control)sender).Name == "cust_rural_farmer")
            {
                dw_generic.GetItem<CustomerDetails>(0).CustRuralFarmer = ((CheckBox)sender).Checked;
                if ((bool)dw_generic.GetItem<CustomerDetails>(0).CustRuralFarmer)
                {
                    dw_generic.GetItem<CustomerDetails>(0).CustBusiness = false;
                    dw_generic.GetItem<CustomerDetails>(0).CustRuralResident = false;
                }
            }
            else if (((Control)sender).Name == "cust_rural_resident")
            {
                dw_generic.GetItem<CustomerDetails>(0).CustRuralResident = ((CheckBox)sender).Checked;
                if ((bool)dw_generic.GetItem<CustomerDetails>(0).CustRuralResident)
                {
                    dw_generic.GetItem<CustomerDetails>(0).CustBusiness = false;
                    dw_generic.GetItem<CustomerDetails>(0).CustRuralFarmer = false;
                }
            }

            //! other code from dw_generic_ue_validate left out for now
        }

        public virtual void dw_recipients2_itemchanged(object sender, EventArgs e)
        {
            dw_recipients2.URdsDw_Itemchanged(sender, e);
            //  TJB  NPAD2  Jan 2006
            string ds_dwo_name;
            ds_dwo_name = dw_recipients2.GetColumnName();
            if ((bool)ib_npad_enabled && ib_unnumbered && il_rdcontractselect == 1)
            {
                MessageBox.Show("Changing recipient details unnumbered addresses is not \n" 
                                 + "allowed using this screen.  Please use the \"Open\" \n" 
                                 + "function on the address maintenance screen."
                               , "Warning"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*? if (dw_recipients2.CanUndo())
                {
                    dw_recipients2.Undo();
                } */
                return; //? return 2;
            }
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            int ll_rc;
            int? ll_ret;
            int? ll_temp;
            int ll_row;
            int? ll_tmp_dpid;
            int ll_customers_modified;
            int ll_recipients_modified;
            int ll_occupations_modified;
            int ll_interests_modified;
            string ls_userid;
            bool lb_name_changed;
            string ls_surname;
            string ls_initials;
            string ls_CustTitle;
            NCriteria lnv_criteria;
            NRdsMsg lnv_msg;
            //? NCstLuw lnv_luw;
            //  TJB SR4559  14-Mar-2005
            //  Check for changes to any of the tab pages.
            dw_generic.AcceptText();
            idw_recipients.AcceptText();
            idw_occupations.AcceptText();
            idw_interests.AcceptText();

            //! GetNextModified reports rows with the status NewModified! and DataModified!.
            ll_customers_modified = dw_generic.GetNextModified(-1);
            ll_recipients_modified = idw_recipients.GetNextModified(-1);
            ll_occupations_modified = idw_occupations.GetNextModified(-1);
            ll_interests_modified = idw_interests.GetNextModified(-1);

            // TJB  RD7_0042  Jan-2010: Added
            //    Changes to the cust_title don't change the modified state of dw_generic
            //    if the save button is clicked without tabbing out of the cust title
            //    field.  Here we check to see if the cust_title has been changed.
            //if (ll_customers_modified < 0)
            {
                //    Compare the data record value (ls_CustTitle) with the dddw value
                //    If different, save the dddw value as the data record value
                //    ... it will be verified below
                ll_row = dw_generic.GetRow();
                ls_CustTitle = dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle;
                ls_CustTitle = (ls_CustTitle == null) ? "" : ls_CustTitle.Trim();
                string dddw_CustTitle = ((DCustomerDetails)(dw_generic.DataObject)).CustTitleCombo.Text;
                dddw_CustTitle = (dddw_CustTitle == null) ? "" : dddw_CustTitle.Trim();
                if (!(ls_CustTitle == dddw_CustTitle))
                {
                    dw_generic.GetItem<CustomerDetails>(ll_row).CustTitle = dddw_CustTitle;
                    //((DCustomerDetails2)(dw_generic.DataObject)).CustTitleCombo.Text = dddw_CustTitle;
                    ((DCustomerDetails)(dw_generic.DataObject)).CustTitleCombo.SelectedValue = dddw_CustTitle;
                    // Flag that the customer title has been changed
                    ll_customers_modified = ll_row;
                }
            }
            //  TJB  NPAD2  April 2006  pre-GoLive
            //  Changed to process the appropriate changed tab
            //  NOTE:  only one of the tabs will be modified when cb_save is pressed.
            //  ll_temp = ll_customers_modified + ll_recipients_modified + ll_occupations_modified + ll_interests_modified
            //  if ll_temp > 0 then
            ll_rc = 0;
            //  If there are any changes on the customer tab, add the userID 
            //  and date to the customer record showing who made the most 
            //  recent change, and when.
            if (ll_customers_modified >= 0)
            {
                ll_rc = uf_save_cust();
                if (ll_rc < 0)
                {
                    //  (the user was told) or one of the updates failed.  
                    //  Don't exit.
                    return;
                }
            }
            if (ll_recipients_modified >= 0)
            {
                //  If the recipients have changed
                //  Save the changes in the rds_customers table first
                uf_flag_customer();
                //? lnv_luw = new NCstLuw();
                //? ll_ret = lnv_luw.of_save(idw_recipients);
                ll_ret = 1;
                idw_recipients.Save();
                if (ll_ret < 0)
                {
                    ll_rc = -(1);
                }
                // PB 'Destroy' Statement
                //? lnv_luw = null;
                //  Now save any changes in the customer_address_moves table
                ll_ret = uf_addcam_recipients();
                if (ll_ret < 0)
                {
                    MessageBox.Show("Error saving recipients customer_address_moves records. \n" 
                                     + "Error code = " + ll_ret
                                   , "Warning"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (ll_occupations_modified >= 0)
            {
                uf_flag_customer();
                //? lnv_luw = new NCstLuw();
                //? ll_ret = lnv_luw.of_save(idw_occupations);
                ll_ret = 1; idw_occupations.Save();
                // PB 'Destroy' Statement
                //? lnv_luw = null;
                if (ll_ret < 0)
                {
                    ll_rc = -(1);
                }
            }
            if (ll_interests_modified >= 0)
            {
                uf_flag_customer();
                //? lnv_luw = new NCstLuw();
                //? ll_ret = lnv_luw.of_save(idw_interests);
                ll_ret = 1;
                idw_interests.Save();
                // PB 'Destroy' Statement
                //? lnv_luw = null;
                if (ll_ret < 0)
                {
                    ll_rc = -(1);
                }
            }
            ll_temp = ll_recipients_modified + ll_occupations_modified + ll_interests_modified;
            if (ll_rc < 0 && ll_temp > 1)
            {
                MessageBox.Show("Error saving changes.  \n"
                               , "ERROR"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; //? return 1;
            }
            // CloseWithReturn ( Parent, il_customer)
            //  Return the flag that there were or weren't changes
            //  We're only interested in changes to the customers or recipients
            //  to tell whether the customer list on the address maintenance 
            //  screen should be updated.
            // ll_temp = ll_customers_modified + ll_recipients_modified  &
            //           + ll_occupations_modified + ll_interests_modified
            ll_temp = ll_customers_modified + ll_recipients_modified;
            if (ll_temp >= -2)
            {
                ll_temp = 1;
            }
            else
            {
                ll_temp = null;
            }
            //  The ib...modified flags are set if the user saved changes
            //  by changing tabs.
            if (ib_customers_modified || ib_recipients_modified)
            {
                ll_temp = 1;
            }
            StaticMessage.ReturnValue = ll_temp;
            int i = this.closequery();//add by ybfan
            if (i == 0)
            {
                this.Close();
            }
            if (i == 1)
            {
                this.close();
            }
            if (i == -1)
            {
                this.Close();
            }
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            int? ll_temp;
            ll_temp = null;
            //  The ib...modified flags are set if the user saved changes
            //  by changing tabs.
            if (ib_customers_modified || ib_recipients_modified)
            {
                ll_temp = 1;
            }
            this.ib_disableclosequery = true;
            //?StaticMessage.ReturnValue = ll_temp;ReturnValue???
            StaticMessage.ReturnValue = ll_temp;
            this.Close();
        }

        #endregion

        private void cb_allInterests_Click(object sender, EventArgs e)
        {
            int nRows = dw_interests.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                if (dw_interests.GetItem<CustomerInterests>(nRow).CiSelected == 0)
                {
                    dw_interests.GetItem<CustomerInterests>(nRow).CiSelected = 1;
                }
            }
            dw_interests.AcceptText();
            dw_interests.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        private void cb_clearInterests_Click(object sender, EventArgs e)
        {
            int nRows = dw_interests.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                if (dw_interests.GetItem<CustomerInterests>(nRow).CiSelected == 1)
                {
                    dw_interests.GetItem<CustomerInterests>(nRow).CiSelected = 0;
                }
            }
            dw_interests.AcceptText();
            dw_interests.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        private void cb_allOccupations_Click(object sender, EventArgs e)
        {
            int nRows = dw_occupations.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                if (dw_occupations.GetItem<CustomerOccupations>(nRow).CoSelected == 0)
                {
                    dw_occupations.GetItem<CustomerOccupations>(nRow).CoSelected = 1;
                }
            }
            dw_occupations.AcceptText();
            dw_occupations.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        private void cb_clearOccupations_Click(object sender, EventArgs e)
        {
            int nRows = dw_occupations.RowCount;
            for (int nRow = 0; nRow < nRows; nRow++)
            {
                if (dw_occupations.GetItem<CustomerOccupations>(nRow).CoSelected == 1)
                {
                    dw_occupations.GetItem<CustomerOccupations>(nRow).CoSelected = 0;
                }
            }
            dw_occupations.AcceptText();
            dw_occupations.DataObject.BindingSource.CurrencyManager.Refresh();
        }
    }
}