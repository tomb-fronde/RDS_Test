using System;
using System.Windows.Forms;
using System.Collections.Generic;
using NZPostOffice.RDS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Windows.Ruralwin2;
using System.Text.RegularExpressions;

namespace NZPostOffice.RDS.Windows.Ruralwin
{
    public class WContractor2001 : WAncestorWindow
    {
        #region Define
        public URdsDw idw_owner_driver;

        public URdsDw idw_contract_types;

        public URdsDw idw_contracts_held;

        public URdsDw idw_ds_number;

        public URdsDw idw_post_tax_deductions;

        public URdsDw idw_procurement;

        public WContractor2001 iw_Parent;

        public int ii_contractor;

        public string is_ErrorColumn = String.Empty;

        public bool ib_ContinueEdit = false;

        public bool ib_FromOwnRegion;

        public bool ib_AutoExit;

        public bool ib_Refresh = false;

        public bool ib_Opening = true;

        public bool ib_IS_NEW = false;

        private string checkString = "";

        private System.ComponentModel.IContainer components = null;

        public TabControl tab_contractor;

        public TabPage tabpage_owner_driver;

        public URdsDw dw_owner_driver;

        public TabPage tabpage_contract_types;

        public URdsDw dw_contract_types;

        public TabPage tabpage_contracts_held;

        public URdsDw dw_contracts_held;

        public TabPage tabpage_ds_numbers;

        public URdsDw dw_ds_numbers;

        public TabPage tabpage_post_tax_deductions;

        public URdsDw dw_post_tax_deductions;

        public TabPage tabpage_procurement;

        public URdsDw dw_procurement;

        #endregion

        private delegate void delegateInvoke();

        public WContractor2001()
        {
            this.InitializeComponent();

            dw_owner_driver.DataObject = new DContractorFull();
            dw_owner_driver.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            dw_contract_types.DataObject = new DTypesForContractor();
            dw_contract_types.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_contracts_held.DataObject = new DContractorsContracts();
            dw_contracts_held.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_ds_numbers.DataObject = new DContractorDs();
            dw_ds_numbers.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_post_tax_deductions.DataObject = new DwAllPostTaxDeductions();
            dw_post_tax_deductions.DataObject.BorderStyle = BorderStyle.Fixed3D;

            dw_procurement.DataObject = new DContractorProcurement();
            dw_procurement.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            dw_owner_driver.Constructor += new UserEventDelegate(dw_owner_driver_constructor);
            dw_owner_driver.URdsDwEditChanged += new EventDelegate(dw_owner_driver_editchanged);
            dw_owner_driver.PfcInsertRow += new UserEventDelegate(dw_owner_driver_pfc_insertrow);
            dw_owner_driver.PfcValidation += new UserEventDelegate1(dw_owner_driver_pfc_validation);


            dw_contract_types.Constructor += new UserEventDelegate(dw_contract_types_constructor);
            dw_contract_types.PfcValidation += new UserEventDelegate1(dw_contract_types_pfc_validation);

            dw_contracts_held.Constructor += new UserEventDelegate(dw_contracts_held_constructor);
            ((DContractorsContracts)dw_contracts_held.DataObject).CellDoubleClick += new EventHandler(dw_contracts_held_doubleclicked);

            dw_ds_numbers.Constructor += new UserEventDelegate(dw_ds_numbers_constructor);
            dw_ds_numbers.UpdateEnd += new UserEventDelegate(dw_ds_numbers_updateend);
            dw_ds_numbers.PfcPreUpdate += new UserEventDelegate1(dw_ds_numbers_ue_validate);

            dw_post_tax_deductions.Constructor += new UserEventDelegate(dw_post_tax_deductions_constructor);
            ((DwAllPostTaxDeductions)dw_post_tax_deductions.DataObject).CellDoubleClick += new EventHandler(dw_post_tax_deductions_doubleclicked);
            dw_post_tax_deductions.PfcInsertRow = new UserEventDelegate(dw_post_tax_deductions_pfc_insertrow);

            dw_procurement.Constructor += new UserEventDelegate(dw_procurement_constructor);
            dw_procurement.PfcPreUpdate += new UserEventDelegate1(dw_procurement_pfc_preupdate);

            //jlwang:end

            //((DContractorFull)dw_owner_driver.DataObject).TextBoxLostFocus += new EventHandler(dw_owner_driver_itemchanged);
            dw_contract_types.LostFocus += new EventHandler(dw_contract_types_losefocus);
            dw_contracts_held.RowFocusChanged += new EventHandler(dw_contracts_held_rowfocuschanged);
            dw_post_tax_deductions.GotFocus += new EventHandler(dw_post_tax_deductions_getfocus);
            dw_post_tax_deductions.RowFocusChanged += new EventHandler(dw_post_tax_deductions_rowfocuschanged);
            dw_procurement.LostFocus += new EventHandler(dw_procurement_losefocus);
            dw_owner_driver.GotFocus += new EventHandler(dw_owner_driver_getfocus);
            dw_owner_driver.LostFocus += new EventHandler(dw_owner_driver_losefocus);
        }

        #region Form Design

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.tab_contractor = new TabControl();
            Controls.Add(tab_contractor);

            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "w_contractor2001";
            this.MaximizeBox = false;
            this.Location = new System.Drawing.Point(46, 55);
            this.Size = new System.Drawing.Size(599, 376);
            // 
            // st_label
            // 
            st_label.Text = "w_contractor2001";
            st_label.Location = new System.Drawing.Point(8, 329);
            st_label.Size = new System.Drawing.Size(94, 15);
            // 
            // tab_contractor
            // 
            tabpage_owner_driver = new TabPage();
            tabpage_contract_types = new TabPage();
            tabpage_contracts_held = new TabPage();

            tabpage_ds_numbers = new TabPage();
            tabpage_post_tax_deductions = new TabPage();
            tabpage_procurement = new TabPage();


            tab_contractor.Controls.Add(tabpage_owner_driver);
            tab_contractor.Controls.Add(tabpage_contract_types);
            tab_contractor.Controls.Add(tabpage_contracts_held);
            tab_contractor.Controls.Add(tabpage_ds_numbers);
            tab_contractor.Controls.Add(tabpage_post_tax_deductions);
            tab_contractor.Controls.Add(tabpage_procurement);
            tab_contractor.SelectTab(0);//tab_contractor.selectedtab = 1;
            tab_contractor.Multiline = true;
            tab_contractor.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
            tab_contractor.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Regular);
            tab_contractor.TabIndex = 1;
            tab_contractor.Size = new System.Drawing.Size(577, 328);
            tab_contractor.Left = 8;
            tab_contractor.Selecting +=new TabControlCancelEventHandler(tab_contractor_selectionchanging);
            tab_contractor.SelectedIndexChanged += new EventHandler(tab_contractor_selectionchanged);
            tab_contractor.GotFocus += new EventHandler(tab_contractor_getfocus);
            // 
            // tabpage_owner_driver
            // 
            dw_owner_driver = new URdsDw();
            //!dw_owner_driver.DataObject = new DContractorFull();
            tabpage_owner_driver.Controls.Add(dw_owner_driver);
            tabpage_owner_driver.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_owner_driver.Text = "Owner Driver";
            tabpage_owner_driver.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_owner_driver.Size = new System.Drawing.Size(569, 299);
            tabpage_owner_driver.Top = 25;
            tabpage_owner_driver.Left = 3;
            tabpage_owner_driver.Visible = false;
            tabpage_owner_driver.Tag = "ComponentName=Owner Driver;";
            // 
            // dw_owner_driver
            // 
            //!dw_owner_driver.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_owner_driver.VerticalScroll.Visible = false;
            dw_owner_driver.TabIndex = 2;
            dw_owner_driver.Location = new System.Drawing.Point(3, 4);
            dw_owner_driver.Size = new System.Drawing.Size(521, 280);
            dw_owner_driver.Tag = "ComponentName=Owner Driver;";
//!            dw_owner_driver.GotFocus += new EventHandler(dw_owner_driver_getfocus);
//!            dw_owner_driver.LostFocus += new EventHandler(dw_owner_driver_losefocus);
//!            ((DContractorFull)dw_owner_driver.DataObject).TextBoxLostFocus += new EventHandler(dw_owner_driver_itemchanged);

            // 
            // tabpage_contract_types
            // 
            dw_contract_types = new URdsDw();
            //!dw_contract_types.DataObject = new DTypesForContractor();
            tabpage_contract_types.Controls.Add(dw_contract_types);
            tabpage_contract_types.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_contract_types.Text = "Contract Types";
            tabpage_contract_types.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_contract_types.Size = new System.Drawing.Size(569, 299);
            tabpage_contract_types.Top = 25;
            tabpage_contract_types.Left = 3;
            tabpage_contract_types.Name = tabpage_contract_types.Text;
            tabpage_contract_types.Tag = "ComponentName=OD Contract Type;";
            // 
            // dw_contract_types
            // 
            dw_contract_types.TabIndex = 2;
            dw_contract_types.Location = new System.Drawing.Point(5, 7);
            dw_contract_types.Size = new System.Drawing.Size(500, 260);
            //!dw_contract_types.DataObject.BorderStyle = BorderStyle.Fixed3D;
//!            dw_contract_types.LostFocus += new EventHandler(dw_contract_types_losefocus);            

            // 
            // tabpage_contracts_held
            // 
            dw_contracts_held = new URdsDw();
            //!dw_contracts_held.DataObject = new DContractorsContracts();
            tabpage_contracts_held.Controls.Add(dw_contracts_held);
            tabpage_contracts_held.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_contracts_held.Text = "Contracts Held";
            tabpage_contracts_held.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_contracts_held.Size = new System.Drawing.Size(569, 299);
            tabpage_contracts_held.Top = 25;
            tabpage_contracts_held.Left = 3;
            tabpage_contracts_held.Visible = false;
            tabpage_contracts_held.Tag = "ComponentName=Contracts Held;";
            // 
            // dw_contracts_held
            // 
            dw_contracts_held.TabIndex = 2;
            //!dw_contracts_held.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_contracts_held.Location = new System.Drawing.Point(5, 7);
            dw_contracts_held.Size = new System.Drawing.Size(500, 260);
//!            dw_contracts_held.RowFocusChanged += new EventHandler(dw_contracts_held_rowfocuschanged);            

            // 
            // tabpage_ds_numbers
            // 
            dw_ds_numbers = new URdsDw();
            //!dw_ds_numbers.DataObject = new DContractorDs();
            tabpage_ds_numbers.Controls.Add(dw_ds_numbers);
            tabpage_ds_numbers.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_ds_numbers.Text = "DS Numbers";
            tabpage_ds_numbers.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_ds_numbers.Size = new System.Drawing.Size(569, 299);
            tabpage_ds_numbers.Top = 25;
            tabpage_ds_numbers.Left = 3;
            tabpage_ds_numbers.Tag = "ComponentName=DS Number;";

            // 
            // dw_ds_numbers
            // 
            dw_ds_numbers.TabIndex = 2;
            //!dw_ds_numbers.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_ds_numbers.Location = new System.Drawing.Point(5, 7);
            dw_ds_numbers.Size = new System.Drawing.Size(500, 260);
            
            // 
            // tabpage_post_tax_deductions
            // 
            dw_post_tax_deductions = new URdsDw();
            //!dw_post_tax_deductions.DataObject = new DwAllPostTaxDeductions();
            tabpage_post_tax_deductions.Controls.Add(dw_post_tax_deductions);
            tabpage_post_tax_deductions.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_post_tax_deductions.Text = "Post Tax Deductions";
            tabpage_post_tax_deductions.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_post_tax_deductions.Size = new System.Drawing.Size(569, 299);
            tabpage_post_tax_deductions.Top = 25;
            tabpage_post_tax_deductions.Left = 3;
            tabpage_post_tax_deductions.Visible = false;
            tabpage_post_tax_deductions.Tag = "ComponentName=Post-Tax Deduction;";
            // 
            // dw_post_tax_deductions
            // 
            dw_post_tax_deductions.TabIndex = 1;
            //!dw_post_tax_deductions.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_post_tax_deductions.Location = new System.Drawing.Point(3, 5);
            dw_post_tax_deductions.Size = new System.Drawing.Size(530, 260);
//!            dw_post_tax_deductions.GotFocus += new EventHandler(dw_post_tax_deductions_getfocus);
//!            dw_post_tax_deductions.RowFocusChanged += new EventHandler(dw_post_tax_deductions_rowfocuschanged);
            
            // 
            // tabpage_procurement
            // 
            dw_procurement = new URdsDw();
            //!dw_procurement.DataObject = new DContractorProcurement();
            tabpage_procurement.Controls.Add(dw_procurement);
            tabpage_procurement.ForeColor = System.Drawing.SystemColors.WindowText;
            tabpage_procurement.Text = "Procurement";
            tabpage_procurement.BackColor = System.Drawing.SystemColors.ButtonFace;
            tabpage_procurement.Top = 25;
            tabpage_procurement.Left = 3;
            tabpage_procurement.Size = new System.Drawing.Size(569, 299);
            tabpage_procurement.Visible = false;
            tabpage_procurement.Tag = "ComponentName=Procurements;";
            // 
            // dw_procurement
            // 
            dw_procurement.ib_Filter_ContractTypes = false;
            dw_procurement.TabIndex = 2;
            //!dw_procurement.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_procurement.Location = new System.Drawing.Point(5, 7);
            dw_procurement.Size = new System.Drawing.Size(500, 260);
//!            dw_procurement.LostFocus += new EventHandler(dw_procurement_losefocus);
            
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

        public virtual void ue_posttax()
        {
            //OpenSheetWithParm(w_post_tax_deduction, ii_contractor, w_main_mdi, 0, original!);
            StaticMessage.IntegerParm = ii_contractor;
            WPostTaxDeduction w_post_tax_deduction = new WPostTaxDeduction();
            w_post_tax_deduction.MdiParent = this.MdiParent;
            w_post_tax_deduction.Show();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            this.of_set_componentname("Owner Driver");
            iw_Parent = this;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            string ls_Title;
            string ls_phone_day, ls_phone_night;
            int? ll_RegionId;
            int? ll_UserRegionID;
            NRdsMsg lnv_msg;
            NCriteria lvNCriteria;
            lnv_msg = StaticMessage.PowerObjectParm as NRdsMsg;
            lvNCriteria = lnv_msg.of_getcriteria();
            ii_contractor = System.Convert.ToInt32(lvNCriteria.of_getcriteria("contractor_supplier_no"));
            if (ii_contractor != -(1))
            {
                idw_owner_driver.Retrieve(new object[] { ii_contractor });
                ls_Title = "Owner Driver: " + idw_owner_driver.GetItem<ContractorFull>(0).CSurnameCompany;
                if (!(StaticVariables.gnv_app.of_isempty(idw_owner_driver.GetItem<ContractorFull>(0).CFirstNames)))
                {
                    ls_Title = ls_Title + ", " + idw_owner_driver.GetItem<ContractorFull>(0).CFirstNames;
                }
                else if (!(StaticVariables.gnv_app.of_isempty(idw_owner_driver.GetItem<ContractorFull>(0).CInitials)))
                {
                    ls_Title = ls_Title + ", " + idw_owner_driver.GetItem<ContractorFull>(0).CInitials;
                }
                ls_phone_day = idw_owner_driver.GetItem<ContractorFull>(0).CPhoneDay;
                if (ls_phone_day != null && ls_phone_day.Length > 1 && (ls_phone_day.Substring(0, 2) == "02"))
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_day")).Mask = "(000) 000-0009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                else
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_day")).Mask = "(00) 000-00009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                ls_phone_night = idw_owner_driver.GetItem<ContractorFull>(0).CPhoneNight;
                if (ls_phone_night != null && ls_phone_night.Length > 1 && (ls_phone_night.Substring(0, 2) == "02"))
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_night")).Mask = "(000) 000-0009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                else
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_night")).Mask = "(00) 000-00009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                //+++++ TJB  RD7_0007  Sept 2008 ++++++
                string ls_IrdNo, ls_GstNo;
                string ls_IrdNo_Mask, ls_GstNo_Mask;
                ls_IrdNo = idw_owner_driver.GetItem<ContractorFull>(0).CIrdNo;
                ls_GstNo = idw_owner_driver.GetItem<ContractorFull>(0).CGstNumber;
                ls_IrdNo_Mask = ((MaskedTextBox)idw_owner_driver.GetControlByName("c_ird_no")).Mask;
                ls_GstNo_Mask = ((MaskedTextBox)idw_owner_driver.GetControlByName("c_gst_number")).Mask;

                //MessageBox.Show(  "CIrdNo = <" + ls_IrdNo + ">, Length = " + ls_IrdNo.Length.ToString() + ", Mask = <" + ls_IrdNo_Mask + ">\r"
                //                + "CGstNo = <" + ls_GstNo + ">, Length = " + ls_GstNo.Length.ToString() + ", Mask = <" + ls_GstNo_Mask + ">\r"
                //                , "WContractor2001.pfc_postopen"
                //               );
                if (ls_IrdNo != null && ls_IrdNo.Length > 8)
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_ird_no")).Mask = "000-000-009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                else
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_ird_no")).Mask = "00-000-0009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                if (ls_GstNo != null && ls_GstNo.Length > 8)
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_gst_number")).Mask = "000-000-009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                else
                {
                    ((MaskedTextBox)idw_owner_driver.GetControlByName("c_gst_number")).Mask = "00-000-0009";
                    idw_owner_driver.GetItem<ContractorFull>(idw_owner_driver.GetRow()).MarkClean();
                }
                //++++++++++++++++++++++++++++++++++++++++++
            }
            else
            {
                ib_IS_NEW = true;
                idw_owner_driver.InsertRow(0);
                ls_Title = "Owner Driver: <New Owner Driver>";
                idw_owner_driver.GetItem<ContractorFull>(0).NzPostEmployee = "N";
                idw_owner_driver.AcceptText();
            }
            //?idw_contracts_held.SetRowFocusIndicator(focusrect!);
            this.Text = ls_Title;
            ll_UserRegionID = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
            //?if ((w_contractor_search != null))
            //?{
            ll_RegionId = ((WContractorSearch)StaticVariables.window).dw_criteria.GetValue<int?>(0, "region_id");
            if (ll_UserRegionID != ll_RegionId)
            {
                if ((ll_UserRegionID != null) && (ll_RegionId != null))
                {
                    idw_owner_driver.DataObject.Enabled = false;//idw_owner_driver.Object.DataWindow.ReadOnly = "Yes";
                }
            }
            //?}

            BeginInvoke(new delegateInvoke(ue_set_security_Invoke)); //PostEvent("ue_set_security");
        }

        public override int closequery()
        {
            int ll_row;
            int ll_rows;
            int? ll_ctkey;
            int ALLOW_CLOSE = 0;
            int PREVENT_CLOSE = 1;

            if (base.closequery() == 1)//if (/*ancestorreturnvalue == allow_close && */!ib_disableclosequery)
                return 1;
            else
            {
                if (ii_contractor > 0)
                {
                    idw_contract_types.Retrieve(new object[] { ii_contractor });
                    //  Loop through the idw_contract_types and remove any empty entries
                    ll_rows = idw_contract_types.RowCount;
                    for (ll_row = ll_rows - 1; ll_row >= 0; ll_row -= 1)
                    {
                        ll_ctkey = idw_contract_types.GetItem<TypesForContractor>(ll_row).CtKey;
                        if ((ll_ctkey == null))
                        {
                            idw_contract_types.RowsDiscard(ll_row, ll_row);//idw_contract_types.RowsDiscard(ll_row, ll_row, primary!);
                        }
                    }
                    if (idw_contract_types.RowCount <= 0)
                    {
                        MessageBox.Show("You must specify a contract type for this Owner Driver", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return PREVENT_CLOSE;
                    }
                }
            }
            //return ancestorreturnvalue;
            return 0;
        }

        #region Methods
        public virtual void ue_set_security_Invoke()
        {
            this.ue_set_security();
            dw_owner_driver_getfocus(null, null);//added by jlwang
        }

        public virtual void ue_set_security()
        {
            ib_Opening = false;
        }

        public virtual string of_validate(int arow)
        {
            string sTitle = "";
            string sReturn = "";
            string sBankAccount;
            string sSurname;
            string sFirstname;
            string sInitials;
            int ll_dup;
            int ll_prime;
            string ls_prime;
            int SQLCode = 0;
            string SQLErrText = string.Empty;

            of_validate_phone(arow, "c_phone_day");
            of_validate_phone(arow, "c_phone_night");
            of_validate_phone(arow, "c_mobile");
            of_validate_phone(arow, "c_mobile2");
            if (!(of_validate_prime_contact(arow)))
            {
                sReturn = "c_prime_contact";
            }
            //  Validate the email address
            string ls_email_address;
            ls_email_address = idw_owner_driver.GetItem<ContractorFull>(arow).CEmailAddress;
            //!if (!((ls_email_address == null)) && !(ls_email_address == ""))
            if (!string.IsNullOrEmpty(ls_email_address) && !string.IsNullOrEmpty(ls_email_address.Trim()))
            {
                if (!(ls_email_address.IndexOfAny("^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$".ToCharArray()) > 0))//if not match(ls_email_address,'^[A-Za-z0-9_\-\.]+@[A-Za-z0-9_\-\.]+$') then
                {
                    MessageBox.Show("Incorrect format for email address.\n" + "Format should be name@address with no spaces" + "\n\n" + ls_email_address, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    sReturn = "c_email_address";
                }
            }
            if (idw_owner_driver.uf_not_entered(arow, "c_surname_company", "surname/ company"))
            {
                sReturn = "c_surname_company";
            }
            else if (idw_owner_driver.uf_not_entered(arow, "c_address", "address"))
            {
                sReturn = "c_address";
            }
            else if (idw_owner_driver.DataObject is DContractorFull)// == "d_contractor_full")
            {
                string str = "";
                sBankAccount = idw_owner_driver.GetItem<ContractorFull>(0).CBankAccountNo;
                if (!(StaticVariables.gnv_app.of_isempty(sBankAccount)))
                {
                    if (sBankAccount.Length >= 6)
                    {
                        str = sBankAccount.Substring(0, 6);
                        if (sBankAccount.Length >= 15)
                        {
                            str += sBankAccount.Substring(8, 7);
                            if (sBankAccount.Length >= 16)
                            {
                                str += sBankAccount.Substring(16, 3 - (19 - sBankAccount.Length));
                            }
                        }
                    }
                    //   sBankAccount = str;
                    //+sBankAccount.Substring(8, 14) + sBankAccount.Substring(16, 18);
                    // if (StaticVariables.gnv_app.of_checkdigit(str) != 0)
                    if (StaticVariables.gnv_app.of_checkdigit(sBankAccount) != 0)
                        {
                        if (MessageBox.Show("Warning:  The bank account entered does not pass the modulus 11 check.\r"
                                            + "          (" + sBankAccount + ")\r"
                                            + "Do you want to keep the bank account entered?"
                                            , this.Text
                                            , MessageBoxButtons.YesNo
                                            , MessageBoxIcon.Question) 
                           == DialogResult.No) 
                        {
                            sReturn = "c_bank_account_no";
                        }
                    }
                }
            }
            if (StaticVariables.gnv_app.of_isempty(sReturn))
            {
                sSurname = idw_owner_driver.GetItem<ContractorFull>(0).CSurnameCompany;
                sTitle = "Owner Driver: " + sSurname;
                sFirstname = idw_owner_driver.GetItem<ContractorFull>(0).CFirstNames;
                if (!(StaticVariables.gnv_app.of_isempty(sFirstname)))
                {
                    sTitle = sTitle + ". " + sFirstname;
                }
                sInitials = idw_owner_driver.GetItem<ContractorFull>(0).CInitials;
                if (!(StaticVariables.gnv_app.of_isempty(sInitials)))
                {
                    sTitle = sTitle + ' ' + sInitials;
                }
                if (idw_owner_driver.GetItem<ContractorFull>(arow).IsNew && idw_owner_driver.GetItem<ContractorFull>(arow).IsDirty) //if (idw_owner_driver.GetItemStatus(arow, 0, primary!) == newmodified!) 
                {
                    if (sSurname != null)
                    {
                        sSurname = sSurname.ToUpper().Trim();
                    }
                    if (sFirstname != null)
                    {
                        sFirstname = sFirstname.ToUpper().Trim();
                    }
                    /*SELECT count ( *) INTO :ll_dup FROM contractor WHERE	Upper( c_surname_company).Trim() = :sSurname AND ( :sFirstName IS NULL OR Upper ( c_first_names).Trim() = :sFirstName) USING	SQLCA;*/
                    ll_dup = RDSDataService.GetContractorCount(sSurname, sFirstname, ref SQLCode, ref SQLErrText).GetValueOrDefault();
                    if (SQLCode < 0)
                    {
                        MessageBox.Show("Error Text: " + SQLErrText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return "c_surname_company";
                    }
                    if (ll_dup > 0)
                    {
                        //  yes there are other records matching the entered one
                        MessageBox.Show("This contractor already exists in the database.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        sReturn = "c_surname_company";
                    }
                    else
                    {
                        ii_contractor = of_get_nextsequence("Contractor");// StaticVariables.gnv_app.of_get_nextsequence("Contractor");
                        idw_owner_driver.GetItem<ContractorFull>(arow).ContractorSupplierNo = ii_contractor;//idw_owner_driver.SetItem(arow, "contractor_supplier_no", ii_contractor);
                        idw_owner_driver.DataObject.BindingSource.CurrencyManager.Refresh();//added by ylwang
                    }
                }
            }
            if (StaticVariables.gnv_app.of_isempty(sReturn))
            {
                if (!(StaticVariables.gnv_app.of_isempty(sTitle)))
                {
                    this.Text = sTitle;
                }
            }
            return sReturn;
        }

        public virtual string of_validate_ds(int arow)
        {
            string sReturn = "";
            if (idw_ds_number.uf_not_entered(arow, "cd_old_ds_no", "ds number"))
            {
                sReturn = "cd_old_ds_no";
            }
            else if (dw_ds_numbers.uf_not_unique(arow, "cd_old_ds_no", "ds number"))
            {
                sReturn = "cd_old_ds_no";
            }
            return sReturn;
        }

        public virtual int of_get_region()
        {
            int lCount;
            int ll_Region;
            ll_Region = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid().GetValueOrDefault();
            /*Select count ( *) Into :lCount  From contractor_renewals cr, contract c, outlet o Where cr.contract_no=c.contract_no And c.con_base_office=o.outlet_id And o.region_id=:ll_Region And cr.contractor_supplier_no = :ii_contractor;*/
            lCount = RDSDataService.GetContractorRenewalsCount(ll_Region, ii_contractor).GetValueOrDefault();
            return lCount;
        }

        public virtual bool of_validate_prime_contact(int al_row)
        {
            int? ll_prime;
            string ls_prime;
            ll_prime = idw_owner_driver.GetItem<ContractorFull>(al_row).CPrimeContact;
            ls_prime = null;

            if (!((ll_prime == null)))
            {
                if (ll_prime == 1)
                {
                    ls_prime = "c_phone_day";
                }
                else if (ll_prime == 2)
                {
                    ls_prime = "c_phone_night";
                }
                else if (ll_prime == 3)
                {
                    ls_prime = "c_mobile";
                }
            }
            //if (ls_prime == null)
            //{
            //    MessageBox.Show("Required value missing for c_prime_contact on row 1 " + ".  Please enter a value.", "Rural Delivery System with NPAD Extensions(enabled)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            if (!((ls_prime == null)))
            {
                if ((idw_owner_driver.GetValue(al_row, ls_prime) == null))
                {
                    MessageBox.Show("There must be a number for the primary contact.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    return true;
                }
            }
            if (!((idw_owner_driver.GetItem<ContractorFull>(al_row).CMobile == null)))
            {
                ll_prime = 3;
            }
            else if (!((idw_owner_driver.GetItem<ContractorFull>(al_row).CPhoneDay == null)))
            {
                ll_prime = 1;
            }
            else if (!((idw_owner_driver.GetItem<ContractorFull>(al_row).CPhoneNight == null)))
            {
                ll_prime = 2;
            }
            else
            {
                MessageBox.Show("A daytime, after hours, or mobile number must be entered for the primary contact." + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            idw_owner_driver.GetItem<ContractorFull>(al_row).CPrimeContact = ll_prime;
            return true;
        }

        public virtual void of_validate_phone(int al_row, string as_field)
        {
            string ls_phone_no;
            ls_phone_no = idw_owner_driver.GetValue<string>(al_row, as_field);
            if (ls_phone_no != null && ls_phone_no.IndexOfAny("^*$".ToCharArray()) >= 0)
            {
                ls_phone_no = null;
                idw_owner_driver.SetValue(al_row, as_field, ls_phone_no);
            }
        }

        public virtual void dw_owner_driver_constructor()
        {
            idw_owner_driver = dw_owner_driver;
            dw_owner_driver.uf_setaudit(true);
            dw_owner_driver.uf_settag("Contractor");
            dw_owner_driver.uf_setauditcolumns("contractor_supplier_no");
            dw_owner_driver.uf_setauditcolumns("c_surname_company");
            dw_owner_driver.uf_setauditcolumns("c_address");
            dw_owner_driver.uf_setauditcolumns("c_initials");
            dw_owner_driver.uf_setauditcolumns("c_bank_account_no");
            dw_owner_driver.uf_setauditcolumns("c_ird_no");
            dw_owner_driver.uf_setauditcolumns("c_tax_rate");
            dw_owner_driver.uf_setauditcolumns("c_witholding_tax_certificate");
            dw_owner_driver.uf_setauditcolumns("c_gst_number");
            // dw_owner_driver.of_set_createpriv(false);
            // dw_owner_driver.of_set_deletepriv(false);
            BeginInvoke(new delegateInvoke(dw_owner_driver_Invoke));
        }

        public virtual void dw_owner_driver_Invoke()
        {
            dw_owner_driver.of_set_createpriv(false);
            dw_owner_driver.of_set_deletepriv(false);
        }

        public virtual void dw_owner_driver_pfc_insertrow()
        {
            dw_owner_driver.PfcInsertRow();
            //?dw_owner_driver.GetItem<ContractorFull>(ancestorreturnvalue).NzPostEmployee = "N";
            dw_owner_driver.AcceptText();
            //?return ancestorreturnvalue;
        }

        public virtual int dw_owner_driver_pfc_validation()
        {
            is_ErrorColumn = of_validate(dw_owner_driver.GetRow());
            checkString = getReadioButton();
            if (is_ErrorColumn.Length > 0)
            {
                return FAILURE;
            }
            else
            {
                return SUCCESS;
            }
        }

        public virtual void dw_owner_driver_updateend()
        {
            ii_contractor = dw_owner_driver.GetItem<ContractorFull>(0).ContractorSupplierNo.GetValueOrDefault();// GetItemNumber(1, "contractor_supplier_no");        }
        }

        private string getReadioButton()
        {
            if (((RadioButton)dw_owner_driver.GetControlByName("c_prime_contact_1")).Checked)
            {
                return "c_prime_contact_1";
            }
            if (((RadioButton)dw_owner_driver.GetControlByName("c_prime_contact_2")).Checked)
            {
                return "c_prime_contact_2";
            }
            if (((RadioButton)dw_owner_driver.GetControlByName("c_prime_contact_3")).Checked)
            {
                return "c_prime_contact_3";
            }
            return "";
        }

        public virtual void dw_contract_types_constructor()
        {
            idw_contract_types = dw_contract_types;
            dw_contract_types.of_bypasscontracttypefilter(true);
        }

        public virtual void dw_contract_types_ue_setuprow()
        {
            int regionId;
            //?regionId = w_contractor_search.dw_criteria.GetItemNumber(1, "region_id");
        }

        public virtual int dw_contract_types_pfc_validation()
        {
            int ll_Row;
            for (ll_Row = 0; ll_Row < dw_contract_types.RowCount; ll_Row++)
            {
                if ((dw_contract_types.GetItem<TypesForContractor>(ll_Row).ContractorSupplierNo == null))
                {
                    dw_contract_types.GetItem<TypesForContractor>(ll_Row).ContractorSupplierNo = ii_contractor;
                }
                if (dw_contract_types.uf_not_entered(ll_Row, "ct_key", "contract type"))
                {
                    dw_contract_types.isErrorColumn = "ct_key";
                    return FAILURE;
                }
                else if (dw_contract_types.uf_not_unique(ll_Row, "ct_key", "contract type"))
                {
                    dw_contract_types.isErrorColumn = "ct_key";
                    return FAILURE;
                }
            }
            return SUCCESS;
        }

        public virtual void dw_contracts_held_ue_setuprow()
        {
            int regionId;
            //?regionId = w_contractor_search.dw_criteria.GetItemNumber(1, "region_id");
        }

        public virtual void dw_ds_numbers_constructor()
        {
            idw_ds_number = dw_ds_numbers;
        }

        public virtual void dw_ds_numbers_ue_setuprow()
        {
            int regionId;
            //?regionId = w_contractor_search.dw_criteria.GetItemNumber(1, "region_id");
        }

        public virtual void dw_ds_numbers_updateend()
        {
            int lRow;
            int lActionCode = 0;
            ((URdsDw)dw_ds_numbers).updatestart();//u_rds_dw.updatestart();
            string sErrorColumn = "";
            lRow = dw_ds_numbers.GetNextModified(0);
            while (lRow > 0)
            {
                sErrorColumn = of_validate_ds(lRow);
                if (!(StaticVariables.gnv_app.of_isempty(sErrorColumn)))
                {
                    dw_ds_numbers.SetCurrent(lRow);
                    dw_ds_numbers.SetColumn(sErrorColumn);
                    lActionCode = 1;
                    lRow = 0;
                }
                else
                {
                    lRow = dw_ds_numbers.GetNextModified(lRow);
                }
            }
            return;//return lActionCode;
        }

        public virtual int dw_ds_numbers_ue_validate()
        {
            int ll_Row;
            int il_row = -1;
            il_row = dw_ds_numbers.GetNextModified(-1);

            while (il_row > -1)
            {
                for (ll_Row = 0; ll_Row < dw_ds_numbers.RowCount; ll_Row++)
                {
                    if ((dw_ds_numbers.GetItem<ContractorDs>(ll_Row).ContractorSupplierNo == null))
                    {
                        dw_ds_numbers.GetItem<ContractorDs>(ll_Row).ContractorSupplierNo = ii_contractor;
                    }
                    if (dw_ds_numbers.uf_not_entered(il_row, "cd_old_ds_no", "DS Number"))
                    {
                        dw_ds_numbers.isErrorColumn = "cd_old_ds_no";
                    }
                    else if (dw_ds_numbers.uf_not_unique(il_row, "cd_old_ds_no", "DS Number"))
                    {
                        dw_ds_numbers.isErrorColumn = "cd_old_ds_no";
                        break;
                    }
                }
                dw_ds_numbers.AcceptText();
                il_row = dw_ds_numbers.GetNextModified(il_row);
            }
            return 1;
        }

        public virtual void dw_post_tax_deductions_ue_open(int al_ded_id)
        {
            string ls_Title;
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("ded_id", al_ded_id);
            lnv_Criteria.of_addcriteria("contractor_id", ii_contractor);
            lnv_msg.of_addcriteria(lnv_Criteria);
            Cursor.Current = Cursors.WaitCursor;
            if ((al_ded_id == null) || al_ded_id <= 0)
            {
                ls_Title = "Post Tax Deduction: <New Post Tax Deduction> ";
            }
            else
            {
                ls_Title = "Post Tax Deduction:  ( " + al_ded_id.ToString() + ") ";
            }
            if (!((StaticVariables.gnv_app.of_findwindow(ls_Title, "w_post_tax_deduction") != null)))
            {
                //OpenSheetWithParm(lw_ptd, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                WPostTaxDeduction lw_ptd = new WPostTaxDeduction();
                lw_ptd.MdiParent = StaticVariables.MainMDI;
                lw_ptd.Show();
            }
            ib_Refresh = true;
        }

        public virtual void dw_post_tax_deductions_constructor()
        {
            idw_post_tax_deductions = dw_post_tax_deductions;
            dw_post_tax_deductions.of_SetRowSelect(true);
            //?dw_post_tax_deductions.inv_RowSelect.of_SetStyle(dw_post_tax_deductions.inv_RowSelect.SINGLE);
        }

        public virtual void dw_post_tax_deductions_pfc_insertrow()
        {
            dw_post_tax_deductions_ue_open(0);
            return;//return SUCCESS;
        }

        public virtual void dw_procurement_constructor()
        {
            idw_procurement = dw_procurement;
            dw_procurement.of_bypasscontracttypefilter(true);
        }

        public virtual int dw_procurement_pfc_preupdate()
        {
            base.pfc_preupdate();
            //  TJB  SR4672  Dec 2005  New
            //  When saving procurements, find any NewModified rows and 
            //  insert the contractor's ID if there isn't one there already.
            int ll_rows;
            int ll_row;
            int? ll_procID;
            int? ll_contractor;
            int ll_ans = 0;
            int ll_result;
            //?dwitemstatus ll_status;
            ll_result = SUCCESS;
            ll_row = dw_procurement.GetRow();
            if ((ll_row == null))
            {
                ll_procID = null;
                ll_contractor = null;
            }
            else if (ll_row >= 0)
            {
                ll_procID = dw_procurement.GetItem<ContractorProcurement>(ll_row).ProcId.GetValueOrDefault();
                ll_contractor = dw_procurement.GetItem<ContractorProcurement>(ll_row).ContractorSupplierNo.GetValueOrDefault();
            }
            else
            {
                ll_procID = null;
                ll_contractor = null;
            }
            ll_rows = dw_procurement.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                ll_procID = dw_procurement.GetItem<ContractorProcurement>(ll_row).ProcId;
                ll_contractor = dw_procurement.GetItem<ContractorProcurement>(ll_row).ContractorSupplierNo;
                if (dw_procurement.GetItem<ContractorProcurement>(ll_row).IsNew && dw_procurement.GetItem<ContractorProcurement>(ll_row).IsDirty) //if (ll_status == newmodified!) 
                {
                    if ((ll_contractor == null))
                    {
                        ll_contractor = ii_contractor;
                        try
                        {
                            dw_procurement.GetItem<ContractorProcurement>(ll_row).ContractorSupplierNo = ll_contractor;
                            ll_ans = 1;
                        }
                        catch
                        {
                            ll_ans = -1;
                        }
                        if ((ll_ans == null))
                        {
                            ll_result = FAILURE;
                        }
                        else if (ll_ans != 1)
                        {
                            ll_result = FAILURE;
                        }
                    }
                }
            }
            return ll_result;
        }

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
                    /*insert into id_codes ( sequence_name, next_value) values  ( :sequencename, 2) ;*/
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

        public virtual void dw_contracts_held_constructor()
        {
            idw_contracts_held = dw_contracts_held;
            dw_contracts_held.of_SetUpdateable(false);
        }

        #endregion

        #region Events
        int oldindex = -1;

        // jlwang:change selectindex to name 
        // log in app with different user ,the tabpage should be invisible or visible
        // if we use select index to get tagepage it will throw exception. 
        public virtual void tab_contractor_selectionchanged(object sender, EventArgs e)
        {
            if (oldindex == tab_contractor.SelectedIndex)
            {
                return;
            }

            string ls_Region;
            MMainMenu mCurrent;
            mCurrent = this.m_sheet;
            int TestExpr = tab_contractor.SelectedIndex + 1;

            string str = tab_contractor.TabPages[tab_contractor.SelectedIndex].Text.ToLower().Trim();
            if (str == "owner driver")//(TestExpr == 1)
            {
                this.dw_owner_driver_getfocus(null, null);//added by jlwang
                if (idw_owner_driver.RowCount == 0)
                {
                    idw_owner_driver.Retrieve(new object[] { ii_contractor });
                }
            }
            else if (str == "contract types")//(TestExpr == 2)
            {
                idw_contract_types.URdsDw_GetFocus(null, null); //added by jlwang
                if (idw_contract_types.RowCount == 0)
                {
                    idw_contract_types.Retrieve(new object[] { ii_contractor });
                    if (idw_contract_types.RowCount == 0)
                    {
                        idw_contract_types.InsertRow(0);
                    }
                }
            }
            else if (str == "contracts held")//(TestExpr == 3)
            {
                idw_contracts_held.URdsDw_GetFocus(null, null); //added by jlwang
                if (idw_contracts_held.RowCount == 0)
                {
                    idw_contracts_held.Retrieve(new object[] { ii_contractor });
                }
            }
            else if (str == "ds numbers")//(TestExpr == 4)
            {
                idw_ds_number.URdsDw_GetFocus(null, null);// added by jlwang
                if (idw_ds_number.RowCount == 0)
                {
                    idw_ds_number.Retrieve(new object[] { ii_contractor });
                    if (idw_ds_number.RowCount == 0)
                    {
                        idw_ds_number.InsertRow(0);
                    }
                }
            }
            else if (str == "post tax deductions")//(TestExpr == 5)
            {
                dw_post_tax_deductions_getfocus(null, null);//added by jlwang

                if (idw_post_tax_deductions.RowCount == 0)
                {
                    idw_post_tax_deductions.Retrieve(new object[] { ii_contractor });
                }
            }
            else if (str == "procurement")//(TestExpr == 6)
            {
                idw_procurement.URdsDw_GetFocus(null, null); //added by jlwang
                if (idw_procurement.RowCount == 0)
                {
                    idw_procurement.Retrieve(new object[] { ii_contractor });
                }
            }
            oldindex = this.tab_contractor.SelectedIndex;
        }

        public virtual void tab_contractor_selectionchanging(object sender, TabControlCancelEventArgs e)
        {
            if (oldindex == tab_contractor.SelectedIndex)
            {
                return;
            }            

            int ll_Ret;
            int ll_Row;
            if (ib_Opening)
            {
                return;//return 0;
            }
            if (ii_contractor == -(1))
            {
                //!tab_contractor.SelectTab(oldindex);
                MessageBox.Show("The current owner driver has to be saved " + "before you can change tabs.", "New Owner Driver", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                return;//return 1;
            }
            // Check for any changes to idw_owner_driver
            //?idw_owner_driver.AcceptText();
            if (idw_owner_driver.DataObject.DeletedCount > 0 || idw_owner_driver.ModifiedCount() > 0)
            {
                ll_Ret = (MessageBox.Show("Do you want to update database?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);//ll_Ret = MessageBox("Update", "Do you want to update database?", question!, yesno!);
                ll_Row = idw_owner_driver.GetRow();
                if (ll_Ret == 1)
                {
                    ll_Ret = idw_owner_driver.Save(); //parent.pfc_save();
                    if (ll_Ret < 0)
                    {
                        return;//return 1;
                    }
                }
                else
                {
                    idw_owner_driver.Reset();
                }
            }
            //?idw_contract_types.AcceptText();
            if (idw_contract_types.DataObject.DeletedCount > 0 || idw_contract_types.ModifiedCount() > 0)
            {
                ll_Ret = (MessageBox.Show("Do you want to update database?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);//ll_Ret = MessageBox("Update", "Do you want to update database?", question!, yesno!);
                ll_Row = idw_contract_types.GetRow();
                if (ll_Ret == 1)
                {
                    ll_Ret = idw_contract_types.Save(); //parent.pfc_save();
                    if (ll_Ret < 0)
                    {
                        return;//return 1;
                    }
                }
                else
                {
                    idw_contract_types.Reset();
                }
            }
            //?idw_contracts_held.AcceptText();
            if (idw_contracts_held.DataObject.DeletedCount > 0 || idw_contracts_held.ModifiedCount() > 0)
            {
                ll_Ret = (MessageBox.Show("Do you want to update database?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);// ll_Ret = MessageBox("Update", "Do you want to update database?", question!, yesno!);
                ll_Row = idw_contracts_held.GetRow();
                if (ll_Ret == 1)
                {
                    ll_Ret = idw_contracts_held.Save();//parent.pfc_save();
                    if (ll_Ret < 0)
                    {
                        return;//return 1;
                    }
                }
                else
                {
                    idw_contracts_held.Reset();
                }
            }
            //?idw_ds_number.AcceptText();
            if (idw_ds_number.DataObject.DeletedCount > 0 || idw_ds_number.ModifiedCount() > 0)
            {
                ll_Ret = (MessageBox.Show("Do you want to update database?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);//ll_Ret = MessageBox("Update", "Do you want to update database?", question!, yesno!);
                ll_Row = idw_ds_number.GetRow();
                if (ll_Ret == 1)
                {
                    ll_Ret = idw_ds_number.Save(); //parent.pfc_save();
                    if (ll_Ret < 0)
                    {
                        return;//return 1;
                    }
                }
                else
                {
                    idw_ds_number.DataObject.Reset();

                }
            }
            //?idw_procurement.AcceptText();
            if (idw_procurement.DataObject.DeletedCount > 0 || idw_procurement.ModifiedCount() > 0)
            {
                ll_Row = idw_procurement.GetRow();
                ll_Ret = (MessageBox.Show("Do you want to update database?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 2);//ll_Ret = MessageBox("Update Procurement", "Do you want to update database?", question!, yesno!);
                if (ll_Ret == 1)
                {
                    ll_Ret = idw_procurement.Save(); //parent.pfc_save();
                    if (ll_Ret < 0)
                    {
                        return;//return 1;
                    }
                }
                else
                {
                    idw_ds_number.Reset();
                }
            }
        }

        public virtual void tab_contractor_getfocus(object sender, EventArgs e)
        {
            string str = tab_contractor.TabPages[tab_contractor.SelectedIndex].Text.ToLower().Trim();
            if (str == "post tax deductions")//(tab_contractor.SelectedIndex == 4)
            {
                if (ib_Refresh == true)
                {
                    idw_post_tax_deductions.Retrieve(new object[] { ii_contractor });
                }
                idw_post_tax_deductions.URdsDw_GetFocus(null, null);// idw_post_tax_deductions.TriggerEvent("getfocus");
            }
        }

        public virtual void dw_owner_driver_editchanged(object sender, EventArgs e)
        {
            //?base.editchanged();
            string sText;
            string scolname;
            scolname = dw_owner_driver.GetColumnName();
            if (ib_ContinueEdit == false && (scolname == "c_surname_company" || scolname == "c_first_names") && ib_AutoExit == false)
            {
                if (!(dw_owner_driver.GetItem<ContractorFull>().IsNew) && !(dw_owner_driver.GetItem<ContractorFull>().IsNew && dw_owner_driver.GetItem<ContractorFull>().IsDirty)) //if (GetItemStatus(row, 0, primary!) != new! && GetItemStatus(row, 0, primary!) != newmodified!) 
                {
                    sText = dw_owner_driver.GetControlByName(dw_owner_driver.GetColumnName()).Text;//dw_owner_driver.GetText();
                    System.Console.Beep();
                    if (MessageBox.Show("Do not modify this if this is an assignment.\r\n" 
                                       + "Contact your system administrator if in doubt.\r\n" 
                                       + "Do you still want to continue editing?"
                                       , "Warning!!!"
                                       , MessageBoxButtons.YesNo
                                       , MessageBoxIcon.Stop
                                       , MessageBoxDefaultButton.Button2) 
                          == DialogResult.Yes)
                    {
                        ib_ContinueEdit = true;
                    }
                    else
                    {
                        ib_AutoExit = true;
                        idw_owner_driver.GetItem<ContractorFull>(0).MarkNotModified();
                        //idw_owner_driver.SetItemStatus(1, 0, primary!, notmodified!);
                        //PostEvent("ue_close");-- there are no then event ue_close
                        return;
                    }
                }
            }
        }

        public virtual void dw_owner_driver_getfocus(object sender, EventArgs e)
        {
            dw_owner_driver.URdsDw_GetFocus(sender, e);
            if (ii_contractor == -(1))
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

        public virtual void dw_owner_driver_losefocus(object sender, EventArgs e)
        {
            if (ii_contractor == -(1))
            {
                MSheet lm_Menu;
                lm_Menu = this.m_sheet;
                if ((lm_Menu != null))
                {
                    //?lm_Menu.m_Edit.m_updatedatabase.ToolbarItemVisible = true;
                    lm_Menu.m_updatedatabase.Visible = true;
                    lm_Menu.m_updatedatabase.Enabled = true;
                }
            }
        }

        //++++++++++++++++++ tjb +++++++++++++++++++++
        public virtual void WContractor2001_TextBoxLostFocus(object sender, EventArgs e)
        {
            string ls_temp = dw_owner_driver.GetColumnName();
            if (!string.IsNullOrEmpty(ls_temp))
            {
                ls_temp = "null";
            }
            MessageBox.Show("ls_dwoName = <" + ls_temp + ">", "WContractor2001_TextBoxLostFocus");
        }
        //++++++++++++++++++++++++++++++++++++++++++++

        public virtual void dw_owner_driver_itemchanged(object sender, EventArgs e)
        {
        /*++++++++++++++++++ tjb Sept 2008 +++++++++++++++++++//
            // NOTE:  This code does not appear to be called
            
            string ls_temp = dw_owner_driver.GetColumnName();
            if (!string.IsNullOrEmpty(ls_temp))
            {
                ls_temp = "null";
            }
            MessageBox.Show("ls_dwoName = <" + ls_temp + ">"
                            , "WContractor2001.dw_owner_driver_itemchanged");
        //++++++++++++++++++++++++++++++++++++++++++++++++++++*/

            dw_owner_driver.URdsDw_Itemchanged(sender, e);
            int ll_return;
            int? ll_prime;
            string ls_email_address;
            //StringArray ls_phone = new StringArray();
            Dictionary<int, string> ls_phone = new Dictionary<int, string>(); 
            string ls_phoneNo;
            string ls_dwoName;

            ll_return = 0;
            ls_dwoName = dw_owner_driver.GetColumnName();

            if (!string.IsNullOrEmpty(ls_dwoName))
                {
                string TestExpr = ls_dwoName.ToLower();

                if (TestExpr == "cust_phone_day")
                {
                    ls_phoneNo = dw_owner_driver.GetItem<ContractorFull>(dw_owner_driver.GetRow()).CPhoneDay;
                    if (!((ls_phoneNo == null)))
                    {
                        if (ls_phoneNo.Substring(0, 2) == "02")
                        {
                            ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_day")).Mask = "(###) ###-#####";
                        }
                        else
                        {
                            ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_day")).Mask = "(##) ###-#####";
                        }
                    }
                }
                else if (TestExpr == "cust_phone_night")
                {
                    ls_phoneNo = dw_owner_driver.GetItem<ContractorFull>(dw_owner_driver.GetRow()).CPhoneNight;
                    if (!((ls_phoneNo == null)))
                    {
                        if (ls_phoneNo.Substring(0, 2) == "02")
                        {
                            ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_night")).Mask = "(###) ###-#####";
                        }
                        else
                        {
                            ((MaskedTextBox)idw_owner_driver.GetControlByName("c_phone_night")).Mask = "(##) ###-#####";
                        }
                    }
                }
                // if (ls_dwoName == "c_email_address")
                else if (TestExpr == "c_email_address")
                {
                    ls_email_address = dw_owner_driver.GetItem<ContractorFull>(dw_owner_driver.GetRow()).CEmailAddress;//data;
                    if (!((ls_email_address == null)) && !(ls_email_address == ""))
                    {
                        // add by mkwang
                        string strInput = ls_email_address;
                        string strExp = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                        Regex r = new Regex(strExp);
                        Match m = r.Match(strInput);
                        // if (!(ls_email_address.IndexOfAny("^[\\w-]+(\\.[\\w-]+)*@[\\w-]+(\\.[\\w-]+)+$".ToCharArray()) >= 0))
                        if (!(m.Success))
                        {
                            MessageBox.Show("Incorrect format for email address.\n" 
                                            + "Format should be name@address with no spaces" + "\n\n" 
                                            + ls_email_address
                                            , "ERROR"
                                            , MessageBoxButtons.OK
                                            , MessageBoxIcon.Exclamation);
                            ll_return = 2;
                        }
                    }
                }
                ls_phone[1] = "c_phone_day";
                ls_phone[2] = "c_phone_night";
                ls_phone[3] = "c_mobile";
                ls_phone[4] = "c_mobile2";
                if (ls_dwoName.StartsWith("c_prime_contact"))// == "c_prime_contact")
                {
                    ll_prime = dw_owner_driver.GetItem<ContractorFull>(dw_owner_driver.GetRow()).CPrimeContact;
                    if (!((ll_prime == null)))
                    {
                        ls_phoneNo = dw_owner_driver.GetValue(dw_owner_driver.GetRow(), ls_phone[ll_prime.GetValueOrDefault()]) as string;//Trim(dw_owner_driver.GetItemString(row, ls_phone[ll_prime]));
                        if ((ls_phoneNo == null) || ls_phoneNo == "")
                        {
                            MessageBox.Show("There must be a number for the primary contact.\n\n"
                                            + "Please select a valid number or enter one."
                                            , "Error"
                                            , MessageBoxButtons.OK
                                            , MessageBoxIcon.Exclamation);
                            dw_owner_driver.GetItem<ContractorFull>(dw_owner_driver.GetRow()).CPrimeContact = dw_owner_driver.GetItem<ContractorFull>(dw_owner_driver.GetRow()).GetInitialValue<int?>("CPrimeContact");//ll_return = 2;
                            dw_owner_driver.DataObject.BindingSource.CurrencyManager.Refresh();
                            if (checkString != "")
                            {
                                ((RadioButton)dw_owner_driver.GetControlByName(checkString)).Checked = true;
                            }
                        }
                    }
                }
            }
            //?return ll_return;
        }

        public virtual void dw_contract_types_losefocus(object sender, EventArgs e)
        {
            dw_contract_types.AcceptText();
        }

        public virtual void dw_contracts_held_doubleclicked(object sender, EventArgs e)
        {
            dw_contracts_held.URdsDw_DoubleClick(sender, e);
            int ll_Row;
            int ll_ContractNo;
            string ls_Title;
            WContract2001 lw_contract2001 = new WContract2001();
            NCriteria lnv_Criteria;
            NRdsMsg lnv_msg;
            ll_Row = ((Metex.Windows.DataEntityGrid)(dw_contracts_held.GetControlByName("grid"))).SelectedRows[0].Index;
            if (ll_Row < 0)
            {
                return;
            }
            ll_ContractNo = dw_contracts_held.GetItem<ContractorsContracts>(ll_Row).ContractNo.GetValueOrDefault();
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            lnv_Criteria.of_addcriteria("contract_no", ll_ContractNo);
            lnv_msg.of_addcriteria(lnv_Criteria);
            Cursor.Current = Cursors.WaitCursor;
            ls_Title = "Contract:  ( " + ll_ContractNo.ToString() + ") " + dw_contracts_held.GetItem<ContractorsContracts>(ll_Row/*dw_contracts_held.GetSelectedRow(0)*/).ConTitle;
            if (!((StaticVariables.gnv_app.of_findwindow(ls_Title, "w_contract2001") != null)))
            {
                //OpenSheetWithParm(lw_contract2001, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                lw_contract2001.MdiParent = StaticVariables.MainMDI;
                lw_contract2001.Show();
            }
        }

        public virtual void dw_contracts_held_rowfocuschanged(object sender, EventArgs e)
        {
            dw_contracts_held.SelectRow(0, false);
            dw_contracts_held.SelectRow(dw_contracts_held.GetRow() + 1, true);
        }

        public virtual void dw_post_tax_deductions_rowfocuschanged(object sender, EventArgs e)
        {
            //?base.rowfocuschanged();
        }

        public virtual void dw_post_tax_deductions_doubleclicked(object sender, EventArgs e)
        {
            dw_post_tax_deductions.URdsDw_DoubleClick(sender, e);
            if (dw_post_tax_deductions.GetRow() >= 0)
            {
                dw_post_tax_deductions_ue_open(dw_post_tax_deductions.GetItem<AllPostTaxDeductions>(dw_post_tax_deductions.GetRow()).DedId.GetValueOrDefault());
            }
        }

        public virtual void dw_post_tax_deductions_getfocus(object sender, EventArgs e)
        {
            dw_post_tax_deductions.URdsDw_GetFocus(sender, e);
            if (ib_Refresh)
            {
                dw_post_tax_deductions.Retrieve(new object[] { ii_contractor });
                dw_post_tax_deductions.SetCurrent(1);
                ib_Refresh = false;
            }
        }

        public virtual void dw_procurement_losefocus(object sender, EventArgs e)
        {
            dw_procurement.AcceptText();
        }
        #endregion
    }
}