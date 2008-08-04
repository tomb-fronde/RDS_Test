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
using System.IO;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralmailmerge;
using NZPostOffice.RDS.Entity.Ruralmailmerge;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.Windows.Ruralrpt;

namespace NZPostOffice.RDS.Windows.Ruralmailmerge
{
    public partial class WMailmergeOwnerdriverDownloadSearch : WGenericReportSearch
    {
        #region Define

        public int? il_procs;

        public string is_proc_select_list = String.Empty;

        public Dictionary<int, string> is_procNames = new Dictionary<int, string>();

        public Dictionary<int, int> il_procIDs = new Dictionary<int, int>();

        private System.ComponentModel.IContainer components = null;

        public URdsDw dw_syntax;

        #endregion

        public WMailmergeOwnerdriverDownloadSearch()
        {
            this.InitializeComponent();

            //jlwang:moved from IC
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("procur_bmp"))).Click += new System.EventHandler(dw_criteria_Clicked);
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
            this.dw_syntax.DataObject = new DMailmergeOdDownloadData();
            this.dw_criteria.DataObject = new DMailmergeOwnerdriverDownloadSearch();
            this.dw_results.DataObject = new DMailmergeDownloadSearchResults();
            Controls.Add(dw_syntax);
            //?Controls.Add(dw_results);
            this.Height = 468;
            this.Width = 369;
            this.Top = 47;
            this.Left = 55;
            // 
            // st_label
            st_label.Top = 420;
            st_label.Left = 0;
            st_label.Width = 250;
            // 
            // 
            // dw_criteria
            // 
            dw_criteria.Height = 260;
            dw_criteria.Width = 300;
            dw_criteria.Top = -2;
            dw_criteria.Left = 0;
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            //((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("procur_bmp"))).Click += new System.EventHandler(dw_criteria_Clicked);
            //
            // dw_results
            // 
            dw_results.Height = 160;
            dw_results.Width = 300;
            dw_results.Top = 260;
            dw_results.Left = 3;
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;
            //((DMailmergeDownloadSearchResults)dw_results.DataObject).DoubleClick += new EventHandler(dw_results_doubleclicked);
            // pb_search
            // 
            // 
            // pb_open
            // 
            pb_open.Height = 31;
            pb_open.Width = 59;
            pb_open.Top = 265;
            pb_open.Left = 302;
            // 
            // dw_syntax
            // 
            // 
            this.Name = "w_mailmerge_ownerdriver_download_search";
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

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            dw_criteria.of_filter_contracttypes();
        }

        public virtual string uf_get_where_clause()
        {
            // 
            // My Editor is using MS Sans Serif, 10 pts so that indention could be wrong on your machine...Rex
            // 
            int? lRegionID;
            int? lOutletID;
            int? lRenewalGroup;
            int? lContractType;
            string s_BaseWhere1;
            string s_BaseWhere2;
            string sRenewalGroup;
            string sContractType;
            Cursor.Current = Cursors.WaitCursor;
            dw_criteria.DataObject.AcceptText();
            // get criteria
            lRegionID = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).RegionId;
            lOutletID = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).OutletId;
            lRenewalGroup = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).RgCode;
            lContractType = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).CtKey;
            // *******convert all data types to string for SQL use*******
            string sRegionID;
            string sOutletID;
            if (lRegionID == null)
            {
                sRegionID = "null";
            }
            else
            {
                sRegionID = lRegionID.ToString();
            }
            if (lOutletID == null)
            {
                sOutletID = "null";
            }
            else
            {
                sOutletID = lOutletID.ToString();
            }
            if (lRenewalGroup == null)
            {
                sRenewalGroup = "null";
            }
            else
            {
                sRenewalGroup = lRenewalGroup.ToString();
            }
            if (lContractType == null)
            {
                sContractType = "null";
            }
            else
            {
                sContractType = lContractType.ToString();
            }
            // *******************create the syntax**********************
            // No, you can't assign very long strings
            //  TJB  SR4692  Aug 2006
            //  Added "and c2.cr_effective_date <= today ( )" clause to s_BaseWhere1
            //  to select the current contractor  ( exclude any who have been
            //  entered but with a future effective date.
            //  Note:  This clause is used for selecting contracts and when 
            //  generating the mailmerge file.  It isn't used when generating
            //  the print labels.
            s_BaseWhere1 = @"WHERE  (  region.region_id = outlet.region_id ) and   (  outlet.outlet_id = contract.con_base_office ) and   (  contract_renewals.contract_no = contractor_renewals.contract_no ) and   (  contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number ) and   (  contract.contract_no = contract_renewals.contract_no ) and   (  contract.con_active_sequence = contract_renewals.contract_seq_number ) and   (  contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no ) and   (  contract.contract_no = types_for_contract.contract_no ) and   (  contractor.contractor_supplier_no =  ( select c.contractor_supplier_no from contractor_renewals as c where c.contract_no =  contractor_renewals.contract_no and c.contract_seq_number = contractor_renewals.contract_seq_number and c.cr_effective_date =  ( select max ( c2.cr_effective_date) from  contractor_renewals as c2 where c.contract_no = c2.contract_no and  c.contract_seq_number = c2.contract_seq_number  and c2.cr_effective_date <= getdate() ) )       ) and  ( contract.con_date_terminated is  null) and  (   (  contractor_renewals.cr_effective_date = contractor_renewals.cr_effective_date ) AND  ";
            s_BaseWhere2 = " (  ( region.region_id = " + sRegionID + "  AND  " + sRegionID + " is not null) OR   ( " + sRegionID + " is null)) AND   (  ( outlet.outlet_id = " + sOutletID + " AND  " + sOutletID + " is not null) OR   ( " + sOutletID + " is null)) AND   (  ( contract.rg_code = " + sRenewalGroup + " AND  " + sRenewalGroup + " is not null) OR   ( " + sRenewalGroup + " is null)) AND   (  ( types_for_contract.ct_key = " + sContractType + " AND  " + sContractType + " is not null) OR   ( " + sContractType + " is null)) )    ";
            return s_BaseWhere1 + s_BaseWhere2;
        }

        public virtual string uf_get_contract_list()
        {
            int ll_selectedRow;
            string ls_contractList;
            int ll_row;
            int ll_rows;
            int? ll_contract;
            //  TJB  SR4692  Aug 2006
            //  Rewrote function since 'all contracts' may now include some 
            //  contracts selected on procurement.
            ll_selectedRow = dw_results.GetSelectedRow(0);
            if (ll_selectedRow <= 0)
            {
                return "";
            }
            ll_contract = dw_results.GetItem<MailmergeDownloadSearchResults>(ll_selectedRow).ContractNo;
            if (ll_contract == null)
            {
                ll_rows = dw_results.RowCount;
                //  Note: row 1 is the <all contracts>  ( contract_no = null) row
                ll_contract = dw_results.GetItem<MailmergeDownloadSearchResults>(2).ContractNo;
                ls_contractList = ll_contract.ToString();
                for (ll_row = 2; ll_row < ll_rows; ll_row++)  //for ll_row = 3 to ll_rows
                {
                    ll_contract = dw_results.GetItem<MailmergeDownloadSearchResults>(ll_row).ContractNo;
                    ls_contractList = ls_contractList + ',' + ll_contract.ToString();
                }
            }
            else
            {
                ls_contractList = ll_contract.ToString();
                ll_selectedRow = dw_results.GetSelectedRow(ll_selectedRow);
                while (ll_selectedRow > 0)
                {
                    ll_contract = dw_results.GetItem<MailmergeDownloadSearchResults>(ll_selectedRow).ContractNo;
                    ls_contractList = ls_contractList + ',' + ll_contract.ToString();
                    ll_selectedRow = dw_results.GetSelectedRow(ll_selectedRow + 1);
                }
            }
            return ls_contractList;
        }

        public virtual void uf_mailmerge()
        {
            string ls_contractList;
            string ls_sqlSelect;
            string ls_baseSelect = string.Empty;
            string ls_baseWhere;
            WMailmergeDownloadOwnerdriver wDownLoadWindow;
            ls_contractList = uf_get_contract_list();
            //  if ls_contractList = "" then
            //  	messagebox ( "Open Contractors","Please select contract ( s)")
            //  	return
            //  end if
            //  TJB  SR4692  Aug 2006
            //  Rewrote construction of call to w_mailmerge_download_ownerdriver
            //  since the contract list may now include some contracts selected 
            //  on procurement 
            /*  -------------------------- Debugging -------------------------- //
            MessageBox.Show (  & 'Contract list:\n' + ls_contractList ,  'w_mailmerge_ownerdriver_download_search.uf_mailmerge' )
            // ---------------------------------------------------------------  */
            Cursor.Current = Cursors.WaitCursor;
            // Get generic where clause
            ls_baseWhere = uf_get_where_clause();
            ls_sqlSelect = " SELECT contractor.contractor_supplier_no, " +
                                    " contractor.c_title,   " +
                                    " contractor.c_initials,   " +
                                    " contractor.c_first_names,   " +
                                    " contractor.c_surname_company,   " +
                                    " isnull(contractor.c_title+' ','') " +
                                  " + isnull(contractor.c_first_names+' ','') " +
                                  " + isnull(contractor.c_surname_company,'')     as driver_name,  " +
                                   "  contractor.c_address,    " +
                                   "  case isnull(contractor.c_phone_day,'') " +
                                   "  when '' then ''  " +
                                   "  else " +
                                   "  case left(contractor.c_phone_day,2)when '02' then  " +
                                    "            substring(contractor.c_phone_day,1,3)+'-' " +
                                     "          +substring(contractor.c_phone_day,4,3)+'-' " +
                                      "         +substring(contractor.c_phone_day,7,len(contractor.c_phone_day) - 7) " +
                                       "    else " +
                                        "        substring(contractor.c_phone_day,1,2)+'-' " +
                                         "      +substring(contractor.c_phone_day,3,3)+'-' " +
                                          "     +substring(contractor.c_phone_day,6,len(contractor.c_phone_day) - 6)  " +
                                          " end " +
                                        " end  as c_phone_day, " +
                                   "  case isnull(contractor.c_phone_night,'') " +
                                    " when '' then '' " +
                                    " else " +
                                    " case left(contractor.c_phone_night,2)when '02' then " +
                                        "        substring(contractor.c_phone_night,1,3)+'-' " +
                                         "      +substring(contractor.c_phone_night,4,3)+'-' " +
                                        "       +substring(contractor.c_phone_night,7,len(contractor.c_phone_night) -7) " +
                                        "   else " +
                                         "       substring(contractor.c_phone_night,1,2)+'-' " +
                                         "      +substring(contractor.c_phone_night,3,3)+'-' " +
                                         "      +substring(contractor.c_phone_night,6,len(contractor.c_phone_night)-6) " +
                                        "   end " +
                                       "  end   as c_phone_night, " +
                                   "  case isnull(contractor.c_mobile,'') " +
                                  "   when '' then '' " +
                                   "  else " +
                                   "         substring(contractor.c_mobile,1,3)+'-' " +
                                   "        +substring(contractor.c_mobile,4,3)+'-' " +
                                   "        +substring(contractor.c_mobile,7,len(contractor.c_mobile)-7)  " +
                                  "   end   as c_mobile, " +
                                  "   case isnull(contractor.c_mobile2,'') " +
                                   "  when '' then '' " +
                                  "   else " +
                                   "        substring(contractor.c_mobile2,1,3)+'-' " +
                                  "         +substring(contractor.c_mobile2,4,3)+'-' " +
                                  "         +substring(contractor.c_mobile2,7,len(contractor.c_mobile2)-7) " +
                                  "   end   as c_mobile2, " +
                                  "   case contractor.c_prime_contact when 1      then c_phone_day " +
                                  "   end, " +
                                  "   case contractor.c_prime_contact when 2 then c_phone_night " +
                                  "   end, " +
                                 "    case contractor.c_prime_contact when 3 then c_mobile " +
                                 "    end as primary_contact," +
                                 "    contractor.c_email_address,  " +
                                 "    contractor.c_bank_account_no,  " +
                                 "    contractor.c_gst_number,   " +
                                 "    contractor.c_tax_rate,   " +
                                 "    contractor.c_ird_no,   " +
                                 "    contract.con_title,   " +
                                 "    contractor_renewals.cr_effective_date, " +
                                   "   contract_renewals.con_start_date, " +
                                   "   contract_renewals.con_expiry_date,   " +
                                   "   outlet.o_name,   " +
                                   "   outlet.o_address,   " +
                                   "   outlet.o_telephone,   " +
                                   "   outlet.o_fax,   " +
                                   "   outlet.o_manager,   " +
                                   "   region.rgn_name,   " +
                                   "   region.rgn_rcm_manager,   " +
                                    "  region.rgn_fax,   " +
                                    "  region.rgn_telephone,   " +
                                    "  region.rgn_address,   " +
                                    "  contractor.c_salutation,   " +
                                    "  case isnull(contractor.c_salutation,'')" +
                                    "  when '' then isnull(contractor.c_title+' ','') " +
                                    "                 + isnull(contractor.c_first_names+' ','') " +
                                    "                 + isnull(contractor.c_surname_company,'') " +
                                    "  else contractor.c_salutation end    as c_salutation,   " +
                                     " contract.contract_no  " +
                                     " FROM contract,    " +
                                     " contractor_renewals,   " +
                                     " outlet,    " +
                                     " region,    " +
                                     " contract_renewals,    " +
                                     " contractor,    " +
                                     " types_for_contract   " +
                                     " WHERE region.region_id = outlet.region_id and   " +
                                     " outlet.outlet_id = contract.con_base_office and   " +
                                     " contract_renewals.contract_no = contractor_renewals.contract_no and   " +
                                     " contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number and   " +
                                     " contract.contract_no = contract_renewals.contract_no and   " +
                                     " contract.con_active_sequence = contract_renewals.contract_seq_number and   " +
                                     " contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no and   " +
                                     " contract.contract_no = types_for_contract.contract_no and   " +
                                     " contractor_renewals.cr_effective_date =  " +
                                     " (select max(cr.cr_effective_date)  " +
                                     " from contractor_renewals cr     " +
                                     " where cr.contract_no = contract_renewals.contract_no  " +
                                    "  and cr.contract_seq_number = contract_renewals.contract_seq_number )";
            // ls_baseSelect = TextUtil.Left(ls_sqlSelect, TextUtil.Pos(ls_sqlSelect, "WHERE") - 1);
            ls_baseSelect = ls_sqlSelect.Substring(0, ls_sqlSelect.IndexOf("WHERE"));
            StaticVariables.gnv_app.of_get_parameters().longparm = -(1);
            StaticVariables.gnv_app.of_get_parameters().stringparm = ls_baseSelect + ls_baseWhere + " AND contract.contract_no in  ( " + ls_contractList + ") " + " order by contractor.c_surname_company ";
            //open(wDownLoadWindow);
            wDownLoadWindow = new WMailmergeDownloadOwnerdriver();
            wDownLoadWindow.ShowDialog();
        }

        public virtual void uf_printlabels()
        {
            string sTitle = string.Empty;
            string ls_contractList;
            int ll_row;
            int ll_rows;
            int ll_contract;
            WOwnerDriverReportPreview wNewReport;
            dw_criteria.DataObject.AcceptText();
            ls_contractList = uf_get_contract_list();
            //  if ls_contractList = "" then
            //  	messagebox ( "Open Contractors","Please select contract ( s)")
            //  	return
            //  end if
            //  TJB  SR4692  Aug 2006
            //  Rewrote call to w_owner_driver_report_preview since 'all'
            //  may now include some contracts selected on procurement 
            //   ( which w_owner_driver_report_preview doesn't cater for).
            StaticVariables.gnv_app.of_get_parameters().booleanparm = false;
            StaticVariables.gnv_app.of_get_parameters().miscstringparm = ls_contractList;
            StaticVariables.gnv_app.of_get_parameters().regionparm = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).RegionId;
            StaticVariables.gnv_app.of_get_parameters().contracttypeparm = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).CtKey;
            StaticVariables.gnv_app.of_get_parameters().renewalgroupparm = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).RgCode;
            StaticVariables.gnv_app.of_get_parameters().outletparm = dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).OutletId;
            StaticVariables.gnv_app.of_get_parameters().contractorparm = null;
            Cursor.Current = Cursors.WaitCursor;
            // OpenSheetWithParm(wNewReport, sTitle, w_main_mdi, 0, original);
            StaticMessage.StringParm = sTitle;
            wNewReport = new WOwnerDriverReportPreview();
            wNewReport.MdiParent = StaticVariables.MainMDI;
            wNewReport.Show();
        }

        public virtual void ue_afterchange()
        {
            //?  base.dw_criteria_ue_afterchange();
            // if dw_criteria.getitemstring ( 1,"printlabels") = "Y" then
            // 	pb_search.visible=false
            // 	pb_open.y=33
            // 	dw_results.enabled=false
            // else
            // 	pb_search.visible=true
            // 	pb_open.y=537
            // 	dw_results.enabled=true
            // end if
        }

        public virtual void constructor()
        {
            //?  base.constructor();
            //?  dw_syntax.settransobject(StaticVariables.sqlca);
        }

        #region Events
        public override void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            // base.itemchanged();
            this.ue_afterchange();
            //dw_criteria.postevent("ue_afterchange");
        }

        public override void dw_criteria_clicked(object sender, EventArgs e)
        {
            base.dw_criteria_clicked(sender, e);
        }

        public virtual void dw_criteria_Clicked(object sender, EventArgs e)
        {
            // base.dw_criteria_clicked(sender,e);
            //dw_criteria.URdsDw_Clicked(sender, e);
            string ls_dwoname;
            string ls_procurements;
            string ls_selected;
            string ls_selectList;
            int ll_value;
            string ls_procID;
            string ls_procName;
            string ls_msg;
            int ll_i;
            int ll_j;
            int ll_k;
            int ll_procID;
            ls_selectList = "";
            ls_procurements = "";
            ls_dwoname = "procur_bmp";//= dw_criteria.GetColumnName();
            if (ls_dwoname == "procur_bmp")
            {
                //  TJB  SR4692  Aug 2006
                //  Add procurements selection
                //  Pop up a window with the list of procurement types
                //  and let the user select 0 or more of them  ( see w_select_procurements).
                //  That window returns the number of procurements selected and a string
                //  with the format "<id>,<name>,<id>,<name>,...".
                //? dw_criteria.Modify("procur_bmp.filename=\'..\\bitmaps\\pcklstdn.bmp\'");
                Cursor.Current = Cursors.WaitCursor;
                // OpenWithParm(w_select_procurements, ls_procurements);
                StaticMessage.PowerObjectParm = ls_procurements;
                WSelectProcurements w_select_procurements = new WSelectProcurements();
                w_select_procurements.ShowDialog();
                il_procs = StaticVariables.gnv_app.of_get_parameters().longparm;
                ls_selected = StaticVariables.gnv_app.of_get_parameters().stringparm;
                is_proc_select_list = "";
                //  If any procurements were selected, parse the returned
                //  string, picking out the ID numbers and names.
                //  Build a list of names for the proclist test object on this 
                //  window  ( to show the selection criteria in human-readable 
                //  form) and a list of ID numbers to be added to the select 
                //  query  ( see pb_search.clicked).
                if (il_procs > 0)
                {
                    ls_msg = il_procs.ToString() + " procurements returned\n";
                    ll_k = 0;
                    for (ll_value = 1; ll_value <= il_procs; ll_value++)
                    {
                        ll_i = ls_selected.IndexOf(',', ll_k);
                        ll_j = ls_selected.IndexOf(',', ll_i + 1);
                        ls_procID = ls_selected.Substring(ll_k, ll_i - ll_k);
                        ls_procName = ls_selected.Substring(ll_i + 1, ll_j - ll_i - 1);
                        ll_k = ll_j + 1;
                        ls_msg = ls_msg + "~" + ls_procID.Trim() + "  " + ls_procName.Trim();
                        ls_selectList = ls_selectList + ls_procName.Trim() + "\r\n";
                        if (is_proc_select_list == "")
                        {
                            is_proc_select_list = ls_procID.Trim();
                        }
                        else
                        {
                            is_proc_select_list = is_proc_select_list + "," + ls_procID.Trim();
                        }
                    }
                    /*  ----------------------- Debugging ----------------------- //
                    MessageBox.Show (  & ls_msg+'\n\n'       & +is_proc_select_list ,  'w_mailmerge_ownerdriver_download_search.dw_criteria.clicked' )
                    else
                    MessageBox.Show (  & 'No procurements returned' ,  'w_mailmerge_ownerdriver_download_search.dw_criteria.clicked' )
                    // ---------------------------------------------------------  */
                }
                //dw_criteria.DataObject.GetControlByName("proclist").Text = "\'" + ls_selectList + "'\'";
                dw_criteria.DataObject.GetControlByName("proclist").Text = ls_selectList;
                //? dw_criteria.Modify("procur_bmp.filename=\'..\\bitmaps\\pcklstup.bmp\'");
            }
        }

        public override void pb_search_clicked(object sender, EventArgs e)
        {
            string s_BaseSelect;
            string s_BaseWhere;
            int? lnull;
            lnull = null;
            /* 	specify base select
            * Don't be too smart trying to get SQL syntax from dw_results 
            * because we will generate a complex query and apply it to 
            * dw_results  */
            s_BaseSelect = "SELECT distinct contract.contract_no, contract.con_title, contract.con_active_sequence " +
                "FROM contract, contractor_renewals, outlet, region, contract_renewals, contractor, types_for_contract ";
            // get the rest of the where clause
            s_BaseWhere = uf_get_where_clause();
            //  TJB  SR4692  Aug 2006
            //  If the user selected any procurements as part of the 
            //  selection criteria, add the contractor_procurement 
            //  table to the 'From' clause of the select query 
            //   ( s_BaseSelect), and the 'Where' elements to the 
            //  where clause  ( s_BaseWhere).
            if (il_procs > 0)
            {
                s_BaseSelect = s_BaseSelect + ", contractor_procurement ";
                s_BaseWhere = s_BaseWhere + " and ( contractor_procurement.contractor_supplier_no = contractor.contractor_s" +
                "upplier_no ) " + " and ( contractor_procurement.proc_id in ( " + is_proc_select_list + ") ) ";
            }
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show (  & 'Select statement:\n\n'  & + s_BaseSelect + s_BaseWhere ,  'w_mailmerge_ownerdriver_download_search.dw_criteria.clicked' )
            integer	fileno
            fileno = FileOpen ( 'C:\tmp\mailmerge_query.txt', linemode!, write!, shared!, replace!)
            FileWrite ( fileno,s_BaseSelect + s_BaseWhere)
            fileClose ( fileno)
            // ---------------------------------------------------------  */
            // dw_results.SetSqlSelect(s_BaseSelect + s_BaseWhere);
            string sql = s_BaseSelect + s_BaseWhere;
            ((DMailmergeDownloadSearchResults)dw_results.DataObject).Retrieve(sql);
            if (dw_results.RowCount > 1)
            {
                dw_results.InsertRow(0);
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ConTitle = "<All Contracts>";
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ContractNo = lnull;
                dw_results.GetItem<MailmergeDownloadSearchResults>(0).ConActiveSequence = lnull;
            }
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            //!if (dw_results.GetSelectedRow(0) == 0)
            if (dw_results.GetSelectedRow(0) < 0)
            {
                MessageBox.Show("Please select contract ( s)", "Open Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dw_criteria.GetItem<MailmergeOwnerdriverDownloadSearch>(0).Printlabels == "Y")
            {
                uf_printlabels();
            }
            else
            {
                uf_mailmerge();
            }
        }
        #endregion

    }
}
