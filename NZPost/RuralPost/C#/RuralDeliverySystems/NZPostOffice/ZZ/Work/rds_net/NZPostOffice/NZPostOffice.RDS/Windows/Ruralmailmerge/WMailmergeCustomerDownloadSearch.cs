using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralmailmerge;
using NZPostOffice.RDS.Entity.Ruralmailmerge;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.Windows.Ruralrpt;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Windows.Ruralmailmerge
{
    public partial class WMailmergeCustomerDownloadSearch : WGenericReportSearch
    {
        #region Define

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_syntax;
        #endregion

        public WMailmergeCustomerDownloadSearch()
        {
            this.InitializeComponent();

            this.dw_syntax.DataObject = new DMailmergeCustDownloadData();           
            this.dw_criteria.DataObject = new DMailmergeCustomerDownloadSearch();            
            this.dw_results.DataObject = new DMailmergeDownloadSearchResults();

            dw_syntax.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //jlwang:moved from IC
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            ((DMailmergeDownloadSearchResults)dw_results.DataObject).DoubleClick += new EventHandler(dw_results_doubleclicked);
            //jlwang:end
        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_syntax = new URdsDw();
            this.Controls.Add(dw_syntax);
            this.Name = "w_mailmerge_customer_download_search";
            this.Height = 390;
            this.Width = 369;
            this.Text = "Customer Search";
            // 
            // st_label
            // 
            st_label.Text = "RDRPT_MMC";
            st_label.Size = new Size(293, 16);
            st_label.Location = new Point(3, 344);
            // 
            // dw_criteria
            // 
            dw_criteria.Height = 177;
            dw_criteria.Top = 4;
            //dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            // 
            // dw_results
            // 
            dw_results.Height = 160;
            dw_results.Top = 185;
            //dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //((DMailmergeDownloadSearchResults)dw_results.DataObject).DoubleClick += new EventHandler(dw_results_doubleclicked);
            // 
            // pb_search
            // 
            pb_search.Top = 5;
            // 
            // pb_open
            // 
            pb_open.Top = 183;
            pb_open.Visible = false;
            pb_open.Tag = "ComponentName=Disabled;";
            // 
            // dw_syntax
            // 
            //dw_syntax.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dw_syntax.HorizontalScroll.Visible = true;
            dw_syntax.TabIndex = 5;
            dw_syntax.Size = new Size(70, 56);
            dw_syntax.Location = new Point(312, 267);
            dw_syntax.Visible = false;
            dw_syntax.Tag = "ComponentName=Disabled;";
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
        public override void open()
        {
            base.open();
            //?dw_syntax.settransobject(StaticVariables.sqlca);
            //?dw_results.settransobject(StaticVariables.sqlca);
        }

        public virtual string uf_get_where_clause()
        {
            int? lRegionID = 0;
            int? lOutletID = 0;
            DateTime dl_fromdate;
            DateTime dl_todate;
            DateTime dpo_fromdate;
            DateTime dpo_todate;
            string sFirstLetter;
            string s_BaseWhere1;
            string s_BaseWhere2;
            string sUsePrintedOn;
            string sPrintedOnString;
            Cursor.Current = Cursors.WaitCursor;

            dw_criteria.DataObject.AcceptText();
            // get criteria
            lRegionID = dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).RegionIdRo;
            lOutletID = dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).OutletId;
            dl_fromdate = Convert.ToDateTime(dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).LoadFromdate);
            dl_todate = Convert.ToDateTime(dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).LoadTodate);
            dpo_fromdate = Convert.ToDateTime(dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).PrintedonFromdate);
            dpo_todate = Convert.ToDateTime(dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).PrintedonTodate);
            sFirstLetter = dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).Firstletter;
            sUsePrintedOn = dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).UsePrintedon;
            // date loaded
            if (dl_todate == null && dl_fromdate == null || dl_todate != null && dl_fromdate != null)
            {
                //if (DaysAfter(dl_fromdate, dl_todate) < 0) 
                if (((TimeSpan)(dl_todate - dl_fromdate)).Days < 0) 
                {
                    MessageBox.Show("The date first loaded FROM date must be earlier than the TO date"
                                   , "Date Loaded"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You must specify date first loaded FROM date and TO date"
                               , "Date Loaded"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // date printed
            if (dpo_todate == null && dpo_fromdate == null || dpo_todate != null && dpo_fromdate != null)
            {
                //if (DaysAfter(dpo_fromdate, dpo_todate) < 0)
                if (((TimeSpan)(dpo_todate - dpo_fromdate)).Days < 0)
                {
                    MessageBox.Show("The date last printed FROM date must be earlier than the TO date"
                                   , "Date Loaded"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You must specify date last printed FROM date and TO date"
                               , "Date Loaded"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // *******************create the syntax**********************
            //  sBaseSelect2  be passed to the customer dump window which which
            //  	will use it to modify the where clause for retrieve and update of printedon
            //  	In this script it is used to retrieve the appropriate contracts
            // removed from s_BaseWhere1(after (contract.con_date_terminated is null) and & ) so that all customers 
            // are retrieved and not just the customers with a privacy flag of Y
            // (customer.cust_dir_listing_ind='Y') and &
            // s_BaseWhere1=  "&
            // WHERE 	(contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no ) and  &
            //          	 (  contract.contract_no = customer.contract_no ) and  &
            //          	 (  region.region_id = outlet.region_id ) and  &
            //          	 (  outlet.outlet_id = contract.con_base_office ) and  &
            // 				 (  outlet_type.ot_code = outlet.ot_code ) and &
            // 				 (  contract.con_date_terminated is null) and &
            // 		         (  contract_renewals.contract_no = contractor_renewals.contract_no ) and  &
            //          	 (  contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number ) and  &
            //          	 (  contract.contract_no = contract_renewals.contract_no ) and  &
            //          	 (  contract.con_active_sequence = contract_renewals.contract_seq_number ) and  &
            //          	 (   (  contractor_renewals.cr_effective_date =  (   select max ( cr.cr_effective_date)  from contractor_renewals as cr where cr.contractor_supplier_no = contractor_renewals.contractor_supplier_no and cr.contract_no = contract.contract_no )) AND  "
            //  TJB SR4652 Feb 2005
            //  Changed the clause definition to a series of string concatenations
            //  (largely for cosmetic reasons, but I found it easier to debug).
            // s_BaseWhere1 = "&
            //    WHERE  (  contract.contract_no = address.contract_no ) and  &
            //           (  contract_renewals.contract_no = contract.contract_no ) and  &
            //           (  contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no ) and  &
            //           (  contractor_renewals.contract_no = contract_renewals.contract_no ) and  &
            //           (  contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number ) and  &
            //           (  customer_address_moves.adr_id = address.adr_id ) and  &
            //           (  outlet_type.ot_code = outlet.ot_code ) and  &
            //           (  rds_customer.cust_id = customer_address_moves.cust_id ) and  &
            //           (  region.region_id = outlet.region_id ) and  &
            //           (  contract.con_base_office = outlet.outlet_id ) and  &
            //           (  contract.con_active_sequence = contract_renewals.contract_seq_number ) and  &
            //           (  ( contract.con_date_terminated is null ) AND  &
            //           (  rds_customer.master_cust_id is null ) AND  &
            //           (  customer_address_moves.move_out_date is null ) AND  &
            //           (  contractor_renewals.cr_effective_date = (select max(cr.cr_effective_date)  from contractor_renewals as cr where cr.contractor_supplier_no = contractor_renewals.contractor_supplier_no and cr.contract_no = contract.contract_no) ) ) AND"
            //  TJB SR4652 Feb 2005
            //  Changed the 'where' conditions in the final subselect to fix a 
            //  problem where duplicate records were being selected when a contract
            //  changed hands during the current month.
            s_BaseWhere1 = "WHERE contract.contract_no = address.contract_no AND " 
                              + "contract_renewals.contract_no = contract.contract_no AND " 
                              + "contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no AND " 
                              + "contractor_renewals.contract_no = contract_renewals.contract_no AND " 
                              + "contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number AND " 
                              + "customer_address_moves.adr_id = address.adr_id AND " 
                              + "outlet_type.ot_code = outlet.ot_code AND " 
                              + "rds_customer.cust_id = customer_address_moves.cust_id AND " 
                              + "region.region_id = outlet.region_id AND " 
                              + "contract.con_base_office = outlet.outlet_id AND " 
                              + "contract.con_active_sequence = contract_renewals.contract_seq_number AND " 
                              + "contract.con_date_terminated is null AND " 
                              + "rds_customer.master_cust_id is null AND " 
                              + "customer_address_moves.move_out_date is null AND " 
                              + "contractor_renewals.cr_effective_date " 
                                        + "= (select max(cr.cr_effective_date) from contractor_renewals as cr " 
                                            + "where cr.contract_seq_number = contract_renewals.contract_seq_number " 
                                            + "  and cr.contract_no = contract_renewals.contract_no)";
            // *******convert all data types to string for SQL use*******
            string sRegionID;
            string sOutletID;
            string sl_fromdate;
            string sl_todate;
            string spo_fromdate;
            string spo_todate;
            // First letter of surname
            if (sFirstLetter != null)
            {
                sFirstLetter += "%";
            }
            else
            {
                sFirstLetter = "%";
            }
            if (lRegionID == 0)
            {
                sRegionID = "null";
            }
            else
            {
                sRegionID = lRegionID.ToString();
            }
            if (lOutletID == 0)
            {
                sOutletID = "null";
            }
            else
            {
                sOutletID = lOutletID.ToString();
            }
            if (dl_fromdate == null || dl_fromdate == DateTime.MinValue)
            {
                sl_fromdate = "null";
            }
            else
            {
                // TJB  RD7_0043  Aug2009
                // Changed format: yyyy/mm/dd --> yyyy/MM/dd
                sl_fromdate = '\'' + dl_fromdate.ToString("yyyy/MM/dd") + '\'';
            }
            if (dl_todate == null || dl_todate == DateTime.MinValue)
            {
                sl_todate = "null";
            }
            else
            {
                // TJB  RD7_0043  Aug2009
                // Changed format: yyyy/mm/dd --> yyyy/MM/dd
                sl_todate = '\'' + dl_todate.ToString("yyyy/MM/dd") + '\'';
            }
            if (dpo_fromdate == null || dpo_fromdate == DateTime.MinValue)
            {
                spo_fromdate = "null";
            }
            else
            {
                // TJB  RD7_0043  Aug2009
                // Changed format: yyyy/mm/dd --> yyyy/MM/dd
                spo_fromdate = '\'' + dpo_fromdate.ToString("yyyy/MM/dd") + '\'';
            }
            if (dpo_todate == null || dpo_todate == DateTime.MinValue)
            {
                spo_todate = "null";
            }
            else
            {
                // TJB  RD7_0043  Aug2009
                // Changed format: yyyy/mm/dd --> yyyy/MM/dd
                spo_todate = '\'' + dpo_todate.ToString("yyyy/MM/dd") + '\'';
            }
            // *******Evaluate sUsePrintedOn ***********
            if (sUsePrintedOn == "Y")
            {
                if (spo_fromdate == "null")
                {
                    sPrintedOnString = " AND rds_customer.printedon is null";
                }
                else
                {
                    sPrintedOnString = " AND rds_customer.printedon between " + spo_fromdate + " and " + spo_todate;
                }
            }
            else
            {
                sPrintedOnString = "";
            }
            //  TJB SR4652 Feb 2005
            //  Changed how this clause is formed, to avoid selection clauses 
            //  like
            //      ((region.region_id = <sRegionID> AND null is not null) 
            //        OR (null is null)) AND 
            //   (where lRegionID is null)
            // 
            // s_BaseWhere2 =   &
            // 				"( (region.region_id = " + sRegionID + " AND " + &
            //                   sRegionID+ " is not null) OR   &
            //          	 ( " + sRegionID+ " is null)) AND  &
            //          	 ( (outlet.outlet_id = " + sOutletID +" AND  "&
            //          	+ sOutletID + "  is not null) OR  &
            //          	 ( " + sOutletID + " is null)) AND  &
            //          	 ( (rds_customer.cust_surname_company like '" +sfirstletter + "')) AND  &
            //          	 ( (rds_customer.cust_date_commenced between "+ sl_fromdate + " and "+ sl_todate + " AND  &
            //          	 ( " + sl_fromdate + " is not null AND  "&
            //          	+ sl_todate + " is not null)) OR  &
            //          	 ( " + sl_fromdate + " is null OR  "&
            //          	+ sl_todate  + " is null)) " +&
            // 				sPrintedOnString 
            s_BaseWhere2 = "";
            if (lRegionID != 0 && lRegionID != null)
            {
                s_BaseWhere2 = " AND region.region_id = " + sRegionID;
            }
            if (lOutletID != 0 && lOutletID != null)
            {
                s_BaseWhere2 = s_BaseWhere2 + " AND outlet.outlet_id = " + sOutletID;
            }
            if (!(sFirstLetter == "%"))
            {
                s_BaseWhere2 = s_BaseWhere2 + " AND rds_customer.cust_surname_company like \'" + sFirstLetter + "%\'";
            }
            if (!StaticFunctions.IsNull(dl_fromdate) && !StaticFunctions.IsNull(dl_todate))
            {
                s_BaseWhere2 = s_BaseWhere2 + " AND rds_customer.cust_date_commenced between " + sl_fromdate + " and " + sl_todate;
            }
            return s_BaseWhere1 + s_BaseWhere2 + ' ' + sPrintedOnString;
        }

        public virtual string uf_get_contract_list()
        {
            int i;
            int? lContractNo;
            int lselectedrow;
            string sContractList = string.Empty;
            lselectedrow = dw_results.GetSelectedRow(0);
            while (lselectedrow >= 0)
            {
                lContractNo = dw_results.GetItem<MailmergeDownloadSearchResults>(lselectedrow).ContractNo;
                if (lContractNo == 0)
                {
                    sContractList = ",null";
                    break;
                }
                else
                {
                    sContractList += ',' + lContractNo.ToString();
                }
                lselectedrow = dw_results.GetSelectedRow(lselectedrow + 1);
            }
            if (sContractList.Length == 0)
            {
                sContractList = "-9999";
            }
            else
            {
                sContractList = sContractList.Substring(1);
            }
            return sContractList;
        }

        public override int wf_getoutlet()
        {
            string sOutlet;
            int? lregionx;
            //?dw_criteria.Modify("outlet_bmp.filename=\'..\\bitmaps\\pcklstdn.bmp\'");
            //?dw_criteria.DataObject.GetControlByName("outlet_picklist").Focus();
            dw_criteria.GetControlByName("outlet_bmp").Focus();
            sOutlet = dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).OName;
            if (sOutlet == "<All Outlets>")
            {
                sOutlet = "";
            }
            lregionx = dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).RegionIdRo;
            StaticVariables.gnv_app.of_get_parameters().integerparm = null;
            StaticVariables.gnv_app.of_get_parameters().longparm = null;
            StaticVariables.gnv_app.of_get_parameters().integerparm = lregionx;
            StaticVariables.gnv_app.of_set_componenttoopen(this.of_get_componentname());
            Cursor.Current = Cursors.WaitCursor;
            // testing twc
            //  OpenWithParm(w_qs_outlet, sOutlet)
            StaticMessage.StringParm = sOutlet;
            WQsOutlet w_qs_outlet = new WQsOutlet();
            w_qs_outlet.ShowDialog();
            // opensheetwithParm(w_qs_outlet,sOutlet, w_main_mdi, 0, originaL!)
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                dw_criteria.SetValue(0, "outlet_id", StaticVariables.gnv_app.of_get_parameters().longparm);
                dw_criteria.SetValue(0, "o_name", StaticVariables.gnv_app.of_get_parameters().stringparm);
                dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();

            }
            return 0;
        }

        public virtual void uf_printlabels()
        {
            bool lb_privacy_override = false;
            string sContractList;
            string sBaseSelect;
            string sBaseWhere;
            string sAdditionalBaseWhere = string.Empty;
            //  TJB SR4646  Jan 2005
            // w_customer_labels wLabelWindow
            WCustlistSelect wLabelWindow;
            int SQLCode = 0;
            String SQLErrText = string.Empty;
            if (dw_results.GetSelectedRow(0) < 0)
            {
                MessageBox.Show("Please select contract(s)"
                               , "Open Customers"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            // Get generic where clause
            sBaseWhere = uf_get_where_clause();
            // Print the labels
            // sBaseSelect =  	"  	SELECT 	DISTINCT customer.cust_id &
            // 		 						FROM 		contract,   &
            // 							   			contractor,   &
            // 	       								contractor_renewals,   &
            // 	      								customer,   &
            // 							   			outlet,   &
            // 							   			region,   &
            // 							   			contract_renewals, &
            // 											outlet_type  "
            sBaseSelect = "SELECT Distinct rds_customer.cust_id" 
                         + " FROM address, contract, contract_renewals, "
                                + "contractor, contractor_renewals, "
                                + "customer_address_moves, outlet, outlet_type, "
                                + "rds_customer, region ";
            // Get list of contracts
            sContractList = uf_get_contract_list();
            // TJB  RD7_0043  Aug2009
            // Added 'sContractList == ""' condition
            if (sContractList == "" || sContractList == "null")
            {
                sAdditionalBaseWhere = "";
            }
            else
            {
                sAdditionalBaseWhere += " AND contract.contract_no in (" + sContractList + ")";
            }
            //  Added the Privacy Protection check
            //  Check if user has the ability to override privacy flag
            lb_privacy_override = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_privacyoverride();
            if ((lb_privacy_override == null) || lb_privacy_override == false)
            {
                //  have to hide the customers with privacy preference set
                sAdditionalBaseWhere += " AND rds_customer.cust_dir_listing_ind = \'Y\'";
            }
            sBaseWhere += sAdditionalBaseWhere;
            //  gnv_App.of_Get_Parameters().StringParm = sBaseSelect + sBaseWhere	//pass SQL
            StaticVariables.gnv_app.of_get_parameters().longparm = -(1);
            //  TJB  SR4646  Jan 2005
            //  Select the customers for the labels
            //  (moved from w_customer_labels)
            string ls_tmpTable;
            string ls_select;
            string ls_sqlDelete;
            ls_select = sBaseSelect + sBaseWhere;
            ls_tmpTable = "report_temp";
            ls_select = "Insert Into report_temp " + ls_select;
            StaticMessage.StringParm = ls_select;
            ls_sqlDelete = "delete from " + ls_tmpTable;
            //  Clear out the temporary table
            // EXECUTE IMMEDIATE :ls_sqlDelete;
            RDSDataService.DeleteReportTemp(ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //?ROLLBACK;
                MessageBox.Show("WARNING: Unable to delete from temporary table " + ls_tmpTable + "\n\n" 
                                 + SQLErrText
                               , "SQL ERROR"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //  Insert the selected customers into the temporary table
            // EXECUTE IMMEDIATE :ls_select;
            RDSDataService.ExecuteSqlString(ls_select, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //?ROLLBACK;
                MessageBox.Show("WARNING: Unable to select customers into temporary table " + ls_tmpTable + "\n\n" 
                                 + SQLErrText
                               , "SQL ERROR"
                               , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //  Commit the changes
            //?  COMMIT;
            // OpenSheetWithParm(wLabelWindow, 0, w_main_mdi, 0, original!);
            StaticMessage.IntegerParm = 0;
            wLabelWindow = new WCustlistSelect();
            wLabelWindow.MdiParent = StaticVariables.MainMDI;
            wLabelWindow.Show();
        }

        public virtual void uf_mailmerge()
        {
            string sContractList;
            string sBaseSelect = string.Empty;
            string sBaseWhere = string.Empty;
            string sAdditionalWhere = string.Empty;
            WMailmergeDownloadCustomer wDownLoadWindow;
            bool lb_privacy_override = false;

            //!if (dw_results.GetSelectedRow(0) == 0)
            if (dw_results.GetSelectedRow(0) < 0)
            {
                MessageBox.Show("Please select contract(s)"
                               , "Open Customers"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            // Get select
            // sBaseSelect =  	left(dw_syntax.describe("datawindow.table.select"), pos(dw_syntax.describe("datawindow.table.select"),'WHERE') - 1)
            // sBaseSelect =  	left(dw_syntax.GETSQLSelect(), pos(dw_syntax.GETSQLSelect(),'WHERE') - 1)
                //p! changed the substring function - diferent in ASA and SQLServer, if length < 0 exception in SQLServer
            /*string dw_syntax_sqlselect =
            "SELECT rds_customer.cust_id               as cust_id, " +
            " rds_customer.cust_surname_company  as cust_surname_company, " +
            " rds_customer.cust_initials         as cust_initials, " +
            " rtrim(ltrim(isnull(rds_customer.cust_title,'') + ' ' " +
            "        + isnull(rds_customer.cust_initials,'') + ' ' " +
            "        + isnull(rds_customer.cust_surname_company,''))) " +
            "                                    as cust_name, " +
            " rtrim(ltrim(road.road_name " +
            " +case isnull(road_type.rt_name,'') " +
            " when '' then '' " +
            " else " +
            " ' '+road_type.rt_name " +
            " end " +
            " +case isnull(road_suffix.rs_name,'') " +
            " when '' then '' " +
            " else ' '+road_suffix.rs_name end)) " +
            "                                    as cust_mailing_address_road, " +
            " suburblocality.sl_name             as cust_mailing_address_locality,  " +
            " towncity.tc_name                   as cust_mail_town,  " +
            " rds_customer.cust_date_commenced   as cust_date_first_loaded," +
            " null                               as cust_date_left,  " +
            " rds_customer.cust_dir_listing_ind  as cust_dir_listing_ind, " +
            " rds_customer.cust_dir_listing_text as cust_dir_listing_text," +
            " contractor.c_title                 as c_title,  " +
            " contractor.c_first_names           as c_first_names,  " +
            " contractor.c_surname_company       as c_surname_company,  " +
            " rtrim(ltrim(case isnull(contractor.c_title,'') " +
            " when '' then '' " +
            " else contractor.c_title+' ' end " +
            "        + case isnull(contractor.c_first_names,'') " +
            " when '' then '' " +
            " else contractor.c_first_names+' ' end " +
            "        + isnull(contractor.c_surname_company,'') )) " +
            "                                    as ownerdriver_name, " +
            " case isnull(contractor.c_phone_day,'') " +
            " when '' then ''  " +
            " else " +
            "  case left(contractor.c_phone_day,2)when '02' then " +
            "            substring(contractor.c_phone_day,1,3)+'-' " +
            "           +substring(contractor.c_phone_day,4,3)+'-' " +
            "           +substring(contractor.c_phone_day,7,len(contractor.c_phone_day)-7)  " +
            "       else " +
            "            substring(contractor.c_phone_day,1,2)+'-' " +
            "           +substring(contractor.c_phone_day,3,3)+'-' " +
            "           +substring(contractor.c_phone_day,6,len(contractor.c_phone_day)-6) " +
            "       end " +
            "     end  as c_phone_day, " +
            " case isnull(contractor.c_phone_night,'') " +
            " when '' then '' " +
            " else " +
            " case left(contractor.c_phone_night,2)when '02' then " +
            "            substring(contractor.c_phone_night,1,3)+'-' " +
            "           +substring(contractor.c_phone_night,4,3)+'-' " +
            "           +substring(contractor.c_phone_night,7,len(contractor.c_phone_night)-7)  " +
            "       else " +
            "            substring(contractor.c_phone_night,1,2)+'-' " +
            "           +substring(contractor.c_phone_night,3,3)+'-' " +
            "           +substring(contractor.c_phone_night,6,len(contractor.c_phone_night)-6)  " +
            "       end " +
            "     end  as c_phone_night, " +
            " case isnull(contractor.c_mobile,'') " +
            " when '' then '' " +
            " else " +
            "     substring(contractor.c_mobile,1,3)+'-' " +
            "       +substring(contractor.c_mobile,4,3)+'-' " +
            "       +substring(contractor.c_mobile,7,len(contractor.c_mobile)-7) end as c_mobile, " +
            " case isnull(contractor.c_mobile2,'') " +
            "  when '' then '' " +
            "  else " +
            "     substring(contractor.c_mobile2,1,3)+'-' " +
            "       +substring(contractor.c_mobile2,4,3)+'-' " +
            "       +substring(contractor.c_mobile2,7,len(contractor.c_mobile2)-7) end as c_mobile2," +
            " case contractor.c_prime_contact when  1  then c_phone_day end," +
            " case contractor.c_prime_contact when 2 then c_phone_night end," +
            " case contractor.c_prime_contact when 3 then c_mobile end as primary_contact, " +
            " contractor.c_email_address         as c_email_address, " +
            " contractor.c_salutation            as c_salutation, " +
            " outlet.o_name                      as o_name, " +
            " outlet.o_address                   as o_address, " +
            " outlet.o_telephone                 as o_telephone, " +
            " outlet.o_fax                       as o_fax, " +
            " outlet.o_manager                   as o_manager, " +
            " region.rgn_name                    as rgn_name, " +
            " region.rgn_rcm_manager             as rgn_rcm_manager, " +
            " region.rgn_fax                     as rgn_fax, " +
            " region.rgn_telephone               as rgn_telephone, " +
            " region.rgn_address                 as rgn_address, " +
            " str(contract.contract_no) +'/' + str(contract.con_active_sequence) " +
            "                                    as contract_no, " +
            " address.adr_rd_no                  as cust_rd_number, " +
            " rd.f_GetDeliveryDays(rds_customer.cust_id) " +
            "                                    as cust_delivery_days, " +
            " substring(case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),1,1) when 'Y' then ',Monday'    else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),2,1) when 'Y'   then ',Tuesday'   else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),3,1) when 'Y'   then ',Wednesday' else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),4,1) when 'Y'   then ',Thursday'  else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),5,1) when 'Y'   then ',Friday'    else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),6,1) when 'Y'   then ',Saturday'  else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),7,1) when 'Y'   then ',Sunday'    else '' end,2," +
            "    len(case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),1,1) when 'Y' then ',Monday'    else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),2,1) when 'Y'   then ',Tuesday'   else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),3,1) when 'Y'   then ',Wednesday' else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),4,1) when 'Y'   then ',Thursday'  else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),5,1) when 'Y'   then ',Friday'    else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),6,1) when 'Y'   then ',Saturday'  else '' end " +
            "    + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),7,1) when 'Y'   then ',Sunday'    else '' end)-2)   " +
            "    as cust_deliverydays,    " +
            " substring(case rds_customer.cust_business when 'Y'      then ',Business'       else '' end " +
            "    + case rds_customer.cust_rural_resident when 'Y'  then ',Rural Resident' else '' end  " +
            "    + case rds_customer.cust_rural_farmer when 'Y'    then ',Rural Farmer'   else '' end,2, " +
            " len(case rds_customer.cust_business when 'Y'      then ',Business'       else '' end " +
            "    + case rds_customer.cust_rural_resident when 'Y'  then ',Rural Resident' else '' end  " +
            "    + case rds_customer.cust_rural_farmer when 'Y'    then ',Rural Farmer'   else '' end)-2)  " +
            "    as cust_category,  " +
            " contractor.c_initials              as c_initials,  " +
            " outlet_type.ot_outlet_type         as ot_outlet_type,  " +
            " rds_customer.cust_title            as cust_title,  " +
            " case isnull(address.adr_unit,'') " +
            " when '' then '' " +
            " else address.adr_unit+'/' end " +
            " +address.adr_no                 as adr_no, " +
            " post_code.post_code                as adr_post_code, " +
            " address.adr_alpha                  as adr_alpha, " +
            " isnull(adr_no,'')+isnull(adr_alpha,' ') " +
            "                                    as cust_mailing_address_no," +
            " address.dp_id " +
            " FROM contract,   " +
            " contractor,    " +
            " contractor_renewals,    " +
            " rds_customer,   " +
            " address left outer join road on address.road_id = road.road_id " +
            " LEFT OUTER JOIN road_type on road.rt_id = road_type.rt_id " +
            " LEFT OUTER JOIN road_suffix on road.rs_id = road_suffix.rs_id " +
            " left outer join suburblocality on address.sl_id = suburblocality.sl_id " +
            " left outer join towncity on address.tc_id = towncity.tc_id " +
            " left outer join post_code on address.post_code_id = post_code.post_code_id, " +
            " customer_address_moves, " +
            " outlet ,  " +
            " region ,  " +
            " contract_renewals , " +
            " outlet_type  ";
            */

            /* optimized further - Nov, 20 2007
                " SELECT rds_customer.cust_id              as cust_id, " +
                "rds_customer.cust_surname_company  as cust_surname_company,  " +
                " rds_customer.cust_initials         as cust_initials,  " +
                " rtrim(ltrim(isnull(rds_customer.cust_title,'') + ' '  + isnull(rds_customer.cust_initials,'') + ' ' + " +
                " isnull(rds_customer.cust_surname_company,''))) " +
                " as cust_name,  " +
                " rtrim(ltrim(road.road_name  +case isnull(road_type.rt_name,'')  when '' then ''  else  ' '+road_type.rt_name  end  +case " + 
                " isnull(road_suffix.rs_name,'')  when '' then ''  else ' '+road_suffix.rs_name end))" +
                " as cust_mailing_address_road,  " +
                " suburblocality.sl_name             as cust_mailing_address_locality,   towncity.tc_name                   as cust_mail_town,   " +
                " rds_customer.cust_date_commenced  as cust_date_first_loaded, null                               as cust_date_left,   " +
                " rds_customer.cust_dir_listing_ind as cust_dir_listing_ind,  " +
                " rds_customer.cust_dir_listing_text as cust_dir_listing_text, contractor.c_title                as c_title,   " +
                " contractor.c_first_names          as c_first_names,   " +
                " contractor.c_surname_company      as c_surname_company,   " +
                " rtrim(ltrim(case isnull(contractor.c_title,'')  when '' then ''  else contractor.c_title+' ' end         + case " + 
                " isnull(contractor.c_first_names,'')  when '' then ''  else contractor.c_first_names+' ' end         + " + 
                " isnull(contractor.c_surname_company,'') )) " +
                " as ownerdriver_name,  " +
                " case isnull(contractor.c_phone_day,'')  when '' then ''   else   case left(contractor.c_phone_day,2)when '02' then " +
                " substring(contractor.c_phone_day,1,3)+'-' " +
                " +substring(contractor.c_phone_day,4,3)+'-' " +
                " +substring(contractor.c_phone_day,7,case when len(contractor.c_phone_day)<=7 then 0 else len(contractor.c_phone_day)-7 end )        else " +
                " substring(contractor.c_phone_day,1,2)+'-' " +
                " +substring(contractor.c_phone_day,3,3)+'-' " +
                " +substring(contractor.c_phone_day,6,case when len(contractor.c_phone_day)<= 6 then 0 else len(contractor.c_phone_day)- 6 end)       " + 
                " end      end  " +
                " as c_phone_day,  " +
                " case isnull(contractor.c_phone_night,'')  when '' then ''  else  case left(contractor.c_phone_night,2)when '02' then             " + 
                " substring(contractor.c_phone_night,1,3)+'-'            +substring(contractor.c_phone_night,4,3)+'-'            +" + 
                " substring(contractor.c_phone_night,7,case when len(contractor.c_phone_night)<=7 then 0 else len(contractor.c_phone_night)-7 end )         " + 
                " else             substring(contractor.c_phone_night,1,2)+'-'            +substring(contractor.c_phone_night,3,3)+'-' " + 
                " +substring(contractor.c_phone_night,6,case when len(contractor.c_phone_night)<=6 then 0 else len(contractor.c_phone_night)-6 end)         " + 
                " end      end  " +
                " as c_phone_night,  " +
                " case isnull(contractor.c_mobile,'')  when '' then ''  else      substring(contractor.c_mobile,1,3)+'-'        " + 
                " +substring(contractor.c_mobile,4,3)+'-'        +substring(contractor.c_mobile,7,case when len(contractor.c_mobile)<=7 then 0 " + 
                " else len(contractor.c_mobile)-7  end ) end " +
                " as c_mobile,  " +
                " case isnull(contractor.c_mobile2,'')   when '' then ''   else      substring(contractor.c_mobile2,1,3)+'-'        " + 
                " +substring(contractor.c_mobile2,4,3)+'-'        +substring(contractor.c_mobile2,7,case when len(contractor.c_mobile2)<=7 then 0 " + 
                " else len(contractor.c_mobile2)-7 end) end " +
                " as c_mobile2, " +
                " case contractor.c_prime_contact when  1  then c_phone_day end, " +
                " case contractor.c_prime_contact when 2 then c_phone_night end, " +
                " case contractor.c_prime_contact when 3 then c_mobile end " +
                " as primary_contact, " +
                " contractor.c_email_address        as c_email_address,  " +
                " contractor.c_salutation           as c_salutation,  " +
                " outlet.o_name                     as o_name,  " +
                " outlet.o_address                  as o_address,  " +
                " outlet.o_telephone                as o_telephone,  " +
                " outlet.o_fax                      as o_fax,  " +
                " outlet.o_manager                  as o_manager,  region.rgn_name                    as rgn_name,  region.rgn_rcm_manager             " +
                " as rgn_rcm_manager,  region.rgn_fax                     as rgn_fax,  " +
                " region.rgn_telephone              as rgn_telephone,  " +
                " region.rgn_address                as rgn_address,  " +
                " str(contract.contract_no) +'/' + str(contract.con_active_sequence)                                    as contract_no,  " +
                " address.adr_rd_no                 as cust_rd_number,  " +
                " rd.f_GetDeliveryDays(rds_customer.cust_id)                                    as cust_delivery_days," +
                " substring(case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),1,1) when 'Y' then ',Monday'   else '' end     " + 
                " + case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),2,1) when 'Y'   then ',Tuesday'   else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),3,1) when 'Y'   then ',Wednesday' else '' end     + " + 
                " case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),4,1) when 'Y'   then ',Thursday'  else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),5,1) when 'Y'   then ',Friday'    else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),6,1) when 'Y'   then ',Saturday'  else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),7,1) when 'Y'   then ',Sunday'    else '' end,2,  case when   " + 
                " len(case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),1,1) when 'Y' then ',Monday'    else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),2,1) when 'Y'   then ',Tuesday'   else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),3,1) when 'Y'   then ',Wednesday' else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),4,1) when 'Y'   then ',Thursday'  else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),5,1) when 'Y'   then ',Friday'    else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),6,1) when 'Y'   then ',Saturday'  else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),7,1) when 'Y'   then ',Sunday'    else '' end) <=2 then 0 else " + 
                " len(case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),1,1) when 'Y' then ',Monday'    else '' end     + " + 
                " case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),2,1) when 'Y'   then ',Tuesday'   else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),3,1) when 'Y'   then ',Wednesday' else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),4,1) when 'Y'   then ',Thursday'  else '' end     + " + 
                " case substring(rd.f_GetDeliveryDays(rds_customer.cust_id),5,1) when 'Y'   then ',Friday'    else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),6,1) when 'Y'   then ',Saturday'  else '' end     + case " + 
                " substring(rd.f_GetDeliveryDays(rds_customer.cust_id),7,1) when 'Y'   then ',Sunday'    else '' end) end)       as cust_deliverydays,    " +
                " substring(case rds_customer.cust_business when 'Y'      then ',Business'       else '' end     + " + 
                " case rds_customer.cust_rural_resident when 'Y'  then ',Rural Resident' else '' end      + case rds_customer.cust_rural_farmer " + 
                " when 'Y'    then ',Rural Farmer'   else '' end,2, case when len(case rds_customer.cust_business when 'Y'      then ',Business'       " + 
                " else '' end     + case rds_customer.cust_rural_resident when 'Y'  then ',Rural Resident' else '' end      + " + 
                " case rds_customer.cust_rural_farmer when 'Y'    then ',Rural Farmer'   else '' end) <=2 then 0 else len(case rds_customer.cust_business " + 
                " when 'Y'      then ',Business'       else '' end     + case rds_customer.cust_rural_resident when 'Y'  then ',Rural Resident' else '' " + 
                " end      + case rds_customer.cust_rural_farmer when 'Y'    then ',Rural Farmer'   else '' end) -2 end)      as cust_category,   " +
                " contractor.c_initials              as c_initials,   outlet_type.ot_outlet_type         as ot_outlet_type,             " +
                " rds_customer.cust_title           as cust_title,   " +
                " case isnull(address.adr_unit,'')  when '' then ''  else address.adr_unit+'/' end  +address.adr_no               as adr_no,   " +
                " post_code.post_code               as adr_post_code,  address.adr_alpha                  as adr_alpha,  " + 
                " isnull(adr_no,'')+isnull(adr_alpha,' ')                                     as cust_mailing_address_no, address.dp_id   " +
                " FROM contract,   contractor,     contractor_renewals,     rds_customer,    address left outer join road on address.road_id = road.road_id   " +
                " LEFT OUTER JOIN road_type on road.rt_id = road_type.rt_id LEFT OUTER JOIN road_suffix on road.rs_id = road_suffix.rs_id   " +
                " left outer join suburblocality on address.sl_id = suburblocality.sl_id left outer join towncity on address.tc_id = towncity.tc_id   " +
                " left outer join post_code on address.post_code_id = post_code.post_code_id, customer_address_moves,  outlet ,   region ,   " +
                " contract_renewals ,  outlet_type  ";
             */

            string dw_syntax_sqlselect =
                      "SELECT rds_customer.cust_id as cust_id, " 
                         +"  rds_customer.cust_surname_company as cust_surname_company, " 
                         +"  rds_customer.cust_initials as cust_initials, " 
                         +"  rtrim(ltrim(isnull(rds_customer.cust_title,'') + ' ' + isnull(rds_customer.cust_initials,'') + ' ' + isnull(rds_customer.cust_surname_company,''))) " 
                                           +" as cust_name, " 
                         +"  rtrim(ltrim(road.road_name + case when road_type.rt_name is null then '' else ' '+road_type.rt_name end + case when road_suffix.rs_name is null then '' else ' '+road_suffix.rs_name end)) " 
                         +"  as cust_mailing_address_road, " 
                         +"  suburblocality.sl_name as cust_mailing_address_locality, towncity.tc_name as cust_mail_town, " 
                         +"  rds_customer.cust_date_commenced as cust_date_first_loaded, null as cust_date_left, " 
                         +"  rds_customer.cust_dir_listing_ind as cust_dir_listing_ind, " 
                         +"  rds_customer.cust_dir_listing_text as cust_dir_listing_text, contractor.c_title as c_title, " 
                         +"  contractor.c_first_names as c_first_names, " 
                         +"  contractor.c_surname_company as c_surname_company, " 
                         +"  rtrim(ltrim(case when contractor.c_title is null then '' else contractor.c_title+' ' end + case when contractor.c_first_names is null then '' else contractor.c_first_names+' ' end + isnull(contractor.c_surname_company,'') )) " 
                                           +" as ownerdriver_name, " 
                         +"  case when contractor.c_phone_day is null then '' else case left(contractor.c_phone_day,2)when '02' then " 
                         +"  substring(contractor.c_phone_day,1,3)+'-' " 
                         +"  +substring(contractor.c_phone_day,4,3)+'-' " 
                         +"  +substring(contractor.c_phone_day,7,case when len(contractor.c_phone_day)<=7 then 0 else len(contractor.c_phone_day)-7 end ) else " 
                         +"  substring(contractor.c_phone_day,1,2)+'-' " 
                         +"  +substring(contractor.c_phone_day,3,3)+'-' " 
                         +"  +substring(contractor.c_phone_day,6,case when len(contractor.c_phone_day)<= 6 then 0 else len(contractor.c_phone_day)- 6 end) end end "
                                           + " as c_phone_day, " 
                         +"  case when contractor.c_phone_night is null then '' else case left(contractor.c_phone_night,2)when '02' then substring(contractor.c_phone_night,1,3)+'-' +substring(contractor.c_phone_night,4,3)+'-' +substring(contractor.c_phone_night,7,case when len(contractor.c_phone_night)<=7 then 0 else len(contractor.c_phone_night)-7 end ) else substring(contractor.c_phone_night,1,2)+'-' +substring(contractor.c_phone_night,3,3)+'-' +substring(contractor.c_phone_night,6,case when len(contractor.c_phone_night)<=6 then 0 else len(contractor.c_phone_night)-6 end) end end "
                                           + " as c_phone_night, " 
                         +"  case when contractor.c_mobile is null then '' else substring(contractor.c_mobile,1,3)+'-' +substring(contractor.c_mobile,4,3)+'-' +substring(contractor.c_mobile,7,case when len(contractor.c_mobile)<=7 then 0 else len(contractor.c_mobile)-7 end ) end "
                                           + " as c_mobile, " 
                         +"  case when contractor.c_mobile2 is null then '' else substring(contractor.c_mobile2,1,3)+'-' +substring(contractor.c_mobile2,4,3)+'-' +substring(contractor.c_mobile2,7,case when len(contractor.c_mobile2)<=7 then 0 else len(contractor.c_mobile2)-7 end) end "
                                           + " as c_mobile2," 
                         +"  case contractor.c_prime_contact when 1 then c_phone_day end, " 
                         +"  case contractor.c_prime_contact when 2 then c_phone_night end, " 
                         +"  case contractor.c_prime_contact when 3 then c_mobile end "
                                           + " as primary_contact, " 
                         +"  contractor.c_email_address as c_email_address, " 
                         +"  contractor.c_salutation as c_salutation, " 
                         +"  outlet.o_name as o_name, " 
                         +"  outlet.o_address as o_address, " 
                         +"  outlet.o_telephone as o_telephone, " 
                         +"  outlet.o_fax as o_fax, " 
                         +"  outlet.o_manager as o_manager, region.rgn_name as rgn_name, region.rgn_rcm_manager as rgn_rcm_manager, region.rgn_fax as rgn_fax, " 
                         +"  region.rgn_telephone as rgn_telephone, " 
                         +"  region.rgn_address as rgn_address, " 
                         +"  str(contract.contract_no) +'/' + str(contract.con_active_sequence) as contract_no, " 
                         +"  address.adr_rd_no as cust_rd_number, " 
                         +"  rd.f_GetDeliveryDays(rds_customer.cust_id) as cust_delivery_days," 
                         +"  rd.f_GetDeliveryDays_names(rds_customer.cust_id) as cust_deliverydays, " 
                         +"  substring(case rds_customer.cust_business when 'Y' then ',Business' else '' end + case rds_customer.cust_rural_resident when 'Y' then ',Rural Resident' else '' end + case rds_customer.cust_rural_farmer when 'Y' then ',Rural Farmer' else '' end,2, case when len(case rds_customer.cust_business when 'Y' then ',Business' else '' end + case rds_customer.cust_rural_resident when 'Y' then ',Rural Resident' else '' end + case rds_customer.cust_rural_farmer when 'Y' then ',Rural Farmer' else '' end) <=2 then 0 else len(case rds_customer.cust_business when 'Y' then ',Business' else '' end + case rds_customer.cust_rural_resident when 'Y' then ',Rural Resident' else '' end + case rds_customer.cust_rural_farmer when 'Y' then ',Rural Farmer' else '' end) -2 end) as cust_category, " 
                         +"  contractor.c_initials as c_initials, outlet_type.ot_outlet_type as ot_outlet_type, " 
                         +"  rds_customer.cust_title as cust_title, " 
                         +"  case when address.adr_unit is null then '' else address.adr_unit+'/' end +address.adr_no as adr_no, " 
                         +"  post_code.post_code as adr_post_code, address.adr_alpha as adr_alpha, isnull(adr_no,'') + isnull(adr_alpha,' ') as cust_mailing_address_no, address.dp_id "
                   + "  FROM contract, contractor, contractor_renewals, rds_customer," 
                         + " address left outer join road on address.road_id = road.road_id " 
                                 + " LEFT OUTER JOIN road_type on road.rt_id = road_type.rt_id LEFT OUTER JOIN road_suffix on road.rs_id = road_suffix.rs_id " 
                                 + " left outer join suburblocality on address.sl_id = suburblocality.sl_id left outer join towncity on address.tc_id = towncity.tc_id " 
                                 + " left outer join post_code on address.post_code_id = post_code.post_code_id, customer_address_moves, outlet , region , contract_renewals , outlet_type ";

//!###############################################

            sBaseSelect = dw_syntax_sqlselect;
            // Get generic where clause
            sBaseWhere = uf_get_where_clause();
            // Get list of contracts
            sContractList = uf_get_contract_list();
            // TJB  RD7_0043  Aug2009
            // Added 'sContractList == ""' condition
            if (sContractList == "" || sContractList == "null")
            {
                sAdditionalWhere = "";
            }
            else
            {
                sAdditionalWhere += " AND contract.contract_no in (" + sContractList + ") ";
            }
            //  Added the Privacy Protection check
            //  Check if user has the ability to override privacy flag
            lb_privacy_override = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_privacyoverride();
            if ((lb_privacy_override == null) || lb_privacy_override == false)
            {
                //  have to hide the customers with privacy preference set
                sAdditionalWhere += " AND rds_customer.cust_dir_listing_ind = \'Y\'";
            }
            StaticVariables.gnv_app.of_get_parameters().stringparm = sBaseSelect + sBaseWhere + sAdditionalWhere;
            //open(wDownLoadWindow);
            wDownLoadWindow = new WMailmergeDownloadCustomer();
            wDownLoadWindow.ShowDialog();
        }

        public virtual void ue_afterclicked()
        {
            dw_criteria.DataObject.AcceptText();
            if (dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).UsePrintedon == "Y")
            {
                dw_criteria.DataObject.GetControlByName("printedon_fromdate").BackColor = Color.White;
                dw_criteria.DataObject.GetControlByName("printedon_todate").BackColor = Color.White;
                dw_criteria.DataObject.GetControlByName("printedon_fromdate").Enabled = true;
                dw_criteria.DataObject.GetControlByName("printedon_todate").Enabled = true;
            }
            else
            {
                dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).Updateafterprint = "N";
                dw_criteria.DataObject.GetControlByName("printedon_fromdate").BackColor = System.Drawing.SystemColors.Control;
                dw_criteria.DataObject.GetControlByName("printedon_todate").BackColor = System.Drawing.SystemColors.Control;
                dw_criteria.DataObject.GetControlByName("printedon_fromdate").Enabled = false;
                dw_criteria.DataObject.GetControlByName("printedon_todate").Enabled = false;
            }
        }

        public virtual void ue_afterchange()
        {
            //dw_criteria.postevent("ue_afterclicked");
            this.ue_afterclicked();
        }
        #endregion

        #region Events
        public override void dw_criteria_clicked(object sender, EventArgs e)
        {
            base.dw_criteria_clicked(sender, e);
            //  this will be triggered regardless
            //  this.postevent("ue_afterclicked")
        }

        public override void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            base.dw_criteria_itemchanged(sender, e);
            // dw_criteria.postevent("ue_afterchange");
            this.ue_afterchange();
        }

        public override void pb_search_clicked(object sender, EventArgs e)
        {
            string s_BaseSelect;
            string s_BaseWhere;
            //  TJB SR4652 Feb 2005
            //  Changed s_BaseSelect definition to a series of string 
            //  concatenations, to aid debugging.
            // 
            // s_BaseSelect = "SELECT distinct contract.contract_no, &
            // 			      		  contract.con_title,  &
            // 		  			 		  contract.con_active_sequence   &
            // 					 FROM   contract,    &
            //         				  contractor,  &
            //         				  contractor_renewals,   &
            // 						  	  customer,    &
            // 						  	  outlet,      &
            // 						     outlet_type, &
            // 						     region,      &
            //   						  contract_renewals"
            s_BaseSelect = "SELECT Distinct contract.contract_no, " + " contract.con_title, " + " contract.con_active_sequence " + "\tFROM address, " + " contract, " + " contract_renewals, " + " contractor, " + " contractor_renewals, " + " customer_address_moves, " + " outlet, " + " outlet_type, " + " rds_customer, " + " region ";
            s_BaseWhere = uf_get_where_clause();
            // This is for debugging
            dw_results.SetSqlSelect(s_BaseSelect + s_BaseWhere);
            ((DMailmergeDownloadSearchResults)dw_results.DataObject).Retrieve(dw_results.GetSqlSelect());
            int? lnull;
            lnull = null;
            //  TJB SR4652 Feb 2005
            //  Added the <no Contracts Found> message
            //  Moved the setting of the pb_open visibility
            pb_open.Visible = true;
            if (dw_results.RowCount == 0)
            {
                //dw_results.InsertRow(1);
                dw_results.InsertItem<MailmergeDownloadSearchResults>(0, MailmergeDownloadSearchResults.NewMailmergeDownloadSearchResults());
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ConTitle = "<No Contracts Found>";
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ContractNo = lnull;
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ConActiveSequence = lnull;
                MessageBox.Show("Search Unsuccessful"
                               , ""
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                pb_open.Visible = false;
            }
            else if (dw_results.RowCount > 1)
            {
                // dw_results.InsertRow(1);
                dw_results.InsertItem<MailmergeDownloadSearchResults>(0, MailmergeDownloadSearchResults.NewMailmergeDownloadSearchResults());
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ConTitle = "<All Contracts>";
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ContractNo = lnull;
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ConActiveSequence = lnull;
            }
            // if dw_results.RowCount>0 then pb_open.visible=true else pb_open.visible=false 
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            //!if (dw_results.GetSelectedRow(0) == 0)
            if (dw_results.GetSelectedRow(0) < 0)
            {
                MessageBox.Show("Please select contract(s)"
                               , "Open Customers"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).Updateafterprint == "Y")
            {
                StaticVariables.gnv_app.of_get_parameters().printedonparm = true;
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().printedonparm = false;
            }
            if (dw_criteria.GetItem<MailmergeCustomerDownloadSearch>(0).Printlabels == "Y")
            {
                pb_open.Hide();
                uf_printlabels();
                pb_open.Show();
            }
            else
            {
                uf_mailmerge();
            }
        }
        #endregion
    }
}