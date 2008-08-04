using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Office.Interop;

using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

using System.Threading;
using System.IO;
//!using Microsoft.Office.Interop;
using System.Reflection;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustomerCounterDelDays : WGenericReportSearch
    {
        #region Define
        public string is_SQLWhere = "";

        public int ilMax = 2000;
        #endregion

        public WCustomerCounterDelDays()
        {
            InitializeComponent();

            //jlwang:moved from IC
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new EventHandler(dw_criteria_clicked);
            ((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("use_printedon"))).CheckedChanged += new EventHandler(dw_criteria_CheckBoxCheckedChanged);
            ((System.Windows.Forms.RadioButton)(dw_criteria.GetControlByName("detailed_report3"))).CheckedChanged += new EventHandler(dw_criteria_RadioButtonCheckedChanged);

            //jlwang:end
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            /*? Environment env;
             GetEnvironment(env);
            if (env.ScreenWidth < 800) {
                this.move(0, 0);
            }*/
            st_max.Text = "No more than " + ilMax.ToString() + " customers may be targeted at once.";
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            DataUserControl dwChild;
            int lNull;
            bool? lb_privacy_override = false;
            dw_criteria.GetControlByName("st_recipient_count").Visible = false;
            dw_criteria.GetControlByName("st_counter").Visible = false;
            lb_privacy_override = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_privacyoverride();
            if (lb_privacy_override == null || lb_privacy_override == false)
            {
                //  set the privacy flag to 'Yes' and disable the field
                dw_criteria.GetItem<CustCriteriaDeldays>(0).DirectoryListing = "N";
                dw_criteria.GetControlByName("directory_listing").Enabled = false; //.Protect=1");
            }
            else
            {
                //  allow user to choose the privacy settings
            }
            dw_criteria.GetControlByName("printedon_todate").BackColor = System.Drawing.SystemColors.Control;//System.Drawing.Color.FromArgb(184, 192, 136);//dw_criteria.DataControl["printedon_todate"].BackColor ="'79216776\'";
            dw_criteria.GetControlByName("printedon_fromdate").BackColor = System.Drawing.SystemColors.Control;//System.Drawing.Color.FromArgb(184, 192, 136);//dw_criteria.DataControl["printedon_fromdate"].BackColor ="'79216776\'";
            // pb_open.Visible = FALSE
            // cb_export.Visible = FALSE
            pb_open.Hide();
            cb_export.Hide();
        }

        public virtual string wf_getparms()
        {
            // Get all parameters - used to build the header string on the report
            string sRegion;
            string sOutlet;
            string sRenGroup;
            string sContract;
            string sParm;
            string sTemp;
            string sdirectory_listing;
            string sDel_mon = string.Empty;
            string sDel_tue = string.Empty;
            string sDel_wed = string.Empty;
            string sDel_thu = string.Empty;
            string sDel_fri = string.Empty;
            string sDel_sat = string.Empty;
            string sDel_sun = string.Empty;
            int? lRegion;
            int? lOutlet;
            int lRenGroup;
            int lContract;
            int lRow;
            int lcount;
            // get region, outlet codes
            lRegion = dw_criteria.GetItem<CustCriteriaDeldays>(0).RegionId;
            lOutlet = dw_criteria.GetItem<CustCriteriaDeldays>(0).OutletId;
            sdirectory_listing = dw_criteria.GetItem<CustCriteriaDeldays>(0).DirectoryListing;
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DelMon != null)
            {
                sDel_mon = dw_criteria.GetItem<CustCriteriaDeldays>(0).DelMon.ToString();
            }
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DelTue != null)
            {
                sDel_tue = dw_criteria.GetItem<CustCriteriaDeldays>(0).DelTue.ToString();
            }
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DeWed != null)
            {
                sDel_wed = dw_criteria.GetItem<CustCriteriaDeldays>(0).DeWed.ToString();
            }
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DelThur != null)
            {
                sDel_thu = dw_criteria.GetItem<CustCriteriaDeldays>(0).DelThur.ToString();
            }
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DelFri != null)
            {
                sDel_fri = dw_criteria.GetItem<CustCriteriaDeldays>(0).DelFri.ToString();
            }
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DelSat != null)
            {
                sDel_sat = dw_criteria.GetItem<CustCriteriaDeldays>(0).DelSat.ToString();
            }
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DelSun != null)
            {
                sDel_sun = dw_criteria.GetItem<CustCriteriaDeldays>(0).DelSun.ToString();
            }
            // get region, outlet description
            if (lRegion == null)
            {
                sParm = "All Regions";
            }
            else
            {
                // SELECT region.rgn_name INTO :sParm FROM region WHERE region.region_id = :lRegion;
                sParm = RDSDataService.GetRegion(lRegion);
            }
            if (lOutlet == null)
            {
                sParm += "\r\nAll Outlets";
            }
            else
            {
                // SELECT outlet.o_name  INTO :sTemp  FROM outlet  WHERE outlet.outlet_id = :lOutlet;
                sTemp = RDSDataService.GetOutletId(lOutlet);
                sParm += "\r\n" + sTemp;
            }
            if (sdirectory_listing == "_")
            {
                sParm += "\r\nPrivacy - All";
            }
            if (sdirectory_listing == "Y")
            {
                sParm += "\r\nPrivacy - No  ( Allow directory listing)";
            }
            if (sdirectory_listing == "N")
            {
                sParm += "\r\nPrivacy - Yes  ( Do not allow directory listing)";
            }
            if (sDel_mon == "Y" || sDel_tue == "Y" || sDel_wed == "Y" || sDel_thu == "Y" || sDel_fri == "Y" || sDel_sat == "Y" || sDel_sun == "Y")
            {
                sParm += "\r\n";
                if (sDel_mon == "Y")
                {
                    sParm += "Monday ";
                }
                if (sDel_tue == "Y")
                {
                    sParm += "Tuesday ";
                }
                if (sDel_wed == "Y")
                {
                    sParm += "Wednesday ";
                }
                if (sDel_thu == "Y")
                {
                    sParm += "Thursday ";
                }
                if (sDel_fri == "Y")
                {
                    sParm += "Friday ";
                }
                if (sDel_sat == "Y")
                {
                    sParm += "Saturday ";
                }
                if (sDel_sun == "Y")
                {
                    sParm += "Sundday ";
                }
                sParm += "Deliveries";
            }
            return sParm;
        }

        public override int wf_gosearch()
        {
            string sSQLSelect;
            string sSQLSelectRecipients;
            string sCondition;
            string sCondition2;
            int? lCount;
            int? lRecipientCount;
            int? lRand;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            DateTime? dpo_fromdate;
            DateTime? dpo_todate;
            DateTime? dloaded_fromdate;
            DateTime? dloaded_todate;
            //  TJB SR4613 31 May 2004
            //  Temporary variables
            string ls_msg;
            DialogResult li_ans;
            bool lb_continue;
            is_SQLWhere = "";
            Cursor.Current = Cursors.WaitCursor;
            lRecipientCount = null;
            lCount = null;
            dw_criteria.GetItem<CustCriteriaDeldays>(0).RecipientCount = lRecipientCount;
            //  dw_criteria.Modify("st_recipient.visible=0");
            //?dw_criteria.GetControlByName("st_recipient").Visible = false;
            dw_criteria.GetItem<CustCriteriaDeldays>(0).CustomerCount = lCount;
            //dw_criteria.Modify("st_counter.visible=0");
            dw_criteria.GetControlByName("st_counter").Visible = false;
            dw_criteria.AcceptText();
            // **Main Select**
            sSQLSelect = @"SELECT count ( distinct rds_customer.cust_id)  FROM address,   customer_address_moves,   outlet,   rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and   (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id is null ) and   (  customer_address_moves.move_out_date is null ) )";
            // **Recipients Select**
            sSQLSelectRecipients = @"SELECT count ( distinct rds_customer.cust_id)  FROM address,   customer_address_moves,   outlet,   rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and   (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id > 0 ) and   (  customer_address_moves.move_out_date is null ) )";
            // **Region**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDeldays>(0).RegionId)))
            {
                is_SQLWhere = is_SQLWhere + " and outlet.region_id = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDeldays>(0).RegionId);
            }
            // **Base Office**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDeldays>(0).OutletId)))
            {
                is_SQLWhere = is_SQLWhere + " and outlet.outlet_id = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDeldays>(0).OutletId);
            }
            // **Mail Category**
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = dw_criteria.GetItem<CustCriteriaDeldays>(0).MailCategory;
            if (TestExpr == "B")
            {
                is_SQLWhere = is_SQLWhere + " and rds_customer.cust_business = \'Y\'";
            }
            else if (TestExpr == "R")
            {
                is_SQLWhere = is_SQLWhere + " and rds_customer.cust_rural_resident = \'Y\'";
            }
            else if (TestExpr == "F")
            {
                is_SQLWhere = is_SQLWhere + " and rds_customer.cust_rural_farmer = \'Y\'";
            }
            // **Contract Type**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDeldays>(0).CtKey)))
            {
                is_SQLWhere += " and contract.con_base_cont_type =  " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDeldays>(0).CtKey) + "";
            }
            // **Renewal Group**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDeldays>(0).RgCode)))
            {
                is_SQLWhere += " and  ( contract.rg_code = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDeldays>(0).RgCode) + ")";
            }
            // **Date Commenced**
            dloaded_fromdate = dw_criteria.GetItem<CustCriteriaDeldays>(0).LoadedFromdate;
            dloaded_todate = dw_criteria.GetItem<CustCriteriaDeldays>(0).LoadedTodate;
            
            //!if (dloaded_todate == null && dloaded_fromdate == null || dloaded_todate != null && dloaded_fromdate != null)
            if ((!dloaded_todate.HasValue && !dloaded_fromdate.HasValue) || (dloaded_todate.HasValue && dloaded_fromdate.HasValue))
            {
                if (((TimeSpan)(dloaded_todate.GetValueOrDefault() - dloaded_fromdate.GetValueOrDefault())).Days < 0)
                {
                    MessageBox.Show("The date loaded FROM date must be earlier than the TO date", "Date Loaded", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("You must specify date loaded FROM date and TO date", "Date Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            
            //!if (dloaded_fromdate != null && dloaded_fromdate != DateTime.MinValue)
            if (dloaded_fromdate.HasValue)
            {
                is_SQLWhere += " and\trds_customer.cust_date_commenced between \'" + 
                    dloaded_fromdate.GetValueOrDefault().ToString("yyyy/MM/dd") + "\' and \'" + 
                    dloaded_todate.GetValueOrDefault().ToString("yyyy/MM/dd") + '\'';
            }
            // **Contract Number**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDeldays>(0).ContractNo)))
            {
                is_SQLWhere = is_SQLWhere + " and contract.contract_no = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDeldays>(0).ContractNo);
            }
            // **Date Printed**
            dpo_fromdate = dw_criteria.GetItem<CustCriteriaDeldays>(0).PrintedonFromdate;
            dpo_todate = dw_criteria.GetItem<CustCriteriaDeldays>(0).PrintedonTodate;
            
            //!if (dpo_todate == null && dpo_fromdate == null || dpo_todate != null && dpo_fromdate != null)
            if ((!dpo_todate.HasValue && !dpo_fromdate.HasValue) || (dpo_todate.HasValue && dpo_fromdate.HasValue))
            {
                if (((TimeSpan)(dpo_todate.GetValueOrDefault() - dpo_fromdate.GetValueOrDefault())).Days < 0)
                {
                    MessageBox.Show("The date last printed FROM date must be earlier than the TO date", "Date Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("You must specify date last printed FROM date and TO date", "Date Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            string sUsePrintedOn = string.Empty;
            //!if (dw_criteria.GetItem<CustCriteriaDeldays>(0).UsePrintedon != null)
            if (!string.IsNullOrEmpty(dw_criteria.GetItem<CustCriteriaDeldays>(0).UsePrintedon))
            {
                sUsePrintedOn = dw_criteria.GetItem<CustCriteriaDeldays>(0).UsePrintedon.ToString();
            }
            if (sUsePrintedOn == "Y")
            {
                //!if (dpo_fromdate == null)
                if (!dpo_fromdate.HasValue)
                {
                    is_SQLWhere += " AND rds_customer.printedon is null ";
                }
                else
                {
                    is_SQLWhere += " AND  ( rds_customer.printedon between \'" + dpo_fromdate.GetValueOrDefault().ToString("yyyy/MM/dd") + 
                        "\' and \'" + dpo_todate.GetValueOrDefault().ToString("yyyy/MM/dd") + "\')";
                }
            }
            // **Delivery Days**
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).OnlyDays != "NNNNNNN") 
            {
                if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DelDaysCondition == "A")
                {
                    sCondition2 = " and exists  (  select 1 from address_frequency_sequence where address.adr_id = a" +
                    "ddress_frequency_sequence.adr_id and ";
                    sCondition = dw_criteria.GetItem<CustCriteriaDeldays>(0).AnyDays;
                    sCondition = " ( " +  sCondition.Substring(4) + ')';
                    is_SQLWhere = is_SQLWhere + sCondition2 + sCondition + ')';
                }
                else {
                    is_SQLWhere = is_SQLWhere + "and exists  ( Select rf_delivery_days from address_frequency_sequence where addre" +
                "ss_frequency_sequence.adr_id = address.adr_id and address_frequency_sequence.rf_" +
                "delivery_days =\'" + dw_criteria.GetItem<CustCriteriaDeldays>(0).OnlyDays + "\')";
                }
            }
            // **Privacy**
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DirectoryListing != "_")
            {
                is_SQLWhere = is_SQLWhere + " and rds_customer.cust_dir_listing_ind = \'" + dw_criteria.GetItem<CustCriteriaDeldays>(0).DirectoryListing + '\'';
            }
            // *********REX's ADDITIONS END***********
            sSQLSelect = sSQLSelect + is_SQLWhere;

            //pp! added bacause 'substr' - is 'subtring' function in SQLServer
            sSQLSelect = sSQLSelect.Replace("substr", "substring");


            /* DECLARE my_cursor DYNAMIC CURSOR FOR SQLSA ;
             PREPARE SQLSA FROM :sSQLSelect;
             OPEN my_cursor
             FETCH my_cursor INTO :lCount ;
             CLOSE my_cursor*/
            lCount = RDSDataService.ExecuteSqlStringLcount(sSQLSelect, ref SQLCode, ref SQLErrText);
            dw_criteria.GetItem<CustCriteriaDeldays>(0).CustomerCount = lCount;
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_criteria.GetControlByName("st_counter").Visible = true;//.visible=1");
            lb_continue = false;
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DetailedReport == "R")
            {
                lRand = dw_criteria.GetItem<CustCriteriaDeldays>(0).RandomNumber;
                //  TJB SR4613 31 May 2004
                //  Ask whether to keep going or not
                if (lCount == 0)
                {
                    lb_continue = false;
                }
                else if (lRand > ilMax)
                {
                    ls_msg = lCount.ToString() + " customers found; Do you want to continue?";
                    li_ans = MessageBox.Show(ls_msg,"Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (li_ans == DialogResult.Yes)
                    {
                        lb_continue = true;
                    }
                    else
                    {
                        lb_continue = false;
                    }
                }
                else
                {
                    lb_continue = true;
                }
            }
            else if (lCount == 0)
            {
                lb_continue = false;
            }
            else if (lCount > ilMax)
            {
                ls_msg = lCount.ToString() + " customers found; Do you want to continue?";
                li_ans = MessageBox.Show(ls_msg,"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (li_ans == DialogResult.Yes)
                {
                    lb_continue = true;
                }
                else
                {
                    lb_continue = false;
                }
            }
            else
            {
                lb_continue = true;
            }
            if (lb_continue == true)
            {
                sSQLSelectRecipients = sSQLSelectRecipients + is_SQLWhere;
                sSQLSelectRecipients = sSQLSelectRecipients.Replace("substr", "substring");
                /*DECLARE Recip_cursor DYNAMIC CURSOR FOR SQLSA ;
                 PREPARE SQLSA FROM :sSQLSelectRecipients;
                 OPEN Recip_cursor
                 FETCH Recip_cursor INTO :lRecipientCount ;
                 CLOSE Recip_cursor*/
                lRecipientCount = RDSDataService.ExecuteSqlStringlRecipientCount(sSQLSelectRecipients, ref SQLCode, ref SQLErrText);
                dw_criteria.GetItem<CustCriteriaDeldays>(0).RecipientCount = lRecipientCount;
                dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
                dw_criteria.GetControlByName("st_recipient_count").Visible = true;
                pb_open.Show();
                cb_export.Show();
            }
            else
            {
                pb_open.Hide();
                cb_export.Hide();
            }
            StaticVariables.gnv_app.of_get_parameters().doubleparm = lCount;
            return 1;
        }
      
        public virtual void dw_criteria_ue_postclicked()
        {
            dw_criteria.AcceptText();
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).UsePrintedon != null)
            {
                if (((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("use_printedon"))).Checked)//if (dw_criteria.GetItem<CustCriteriaDeldays>(0).UsePrintedon.ToString() == "Y")
                {
                    dw_criteria.GetControlByName("printedon_fromdate").Enabled = true;
                    dw_criteria.GetControlByName("printedon_todate").Enabled = true;
                    dw_criteria.GetControlByName("printedon_fromdate").BackColor = Color.FromArgb(255, 255, 255);
                    dw_criteria.GetControlByName("printedon_todate").BackColor = Color.FromArgb(255, 255, 255);
                }
                else
                {
                    dw_criteria.GetItem<CustCriteriaDeldays>(0).Updateafterprint = "N";
                    dw_criteria.GetControlByName("printedon_fromdate").Enabled = false;
                    dw_criteria.GetControlByName("printedon_todate").Enabled = false;
                    dw_criteria.GetControlByName("printedon_todate").BackColor = System.Drawing.SystemColors.Control;
                    dw_criteria.GetControlByName("printedon_fromdate").BackColor = System.Drawing.SystemColors.Control;
                }
            }
            return;//? 1;
        }
       
        //this function just only support office2003
        private void ExportToExcel()
        {
            try
            {                 

                SaveFileDialog savedlg = new SaveFileDialog();
                savedlg.Title = "Export to file...";
                savedlg.Filter = "Excel files  ( *.xls)| *.xls |CSV files  ( *.csv)| *.csv";
                if (savedlg.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application m_Excel = new Microsoft.Office.Interop.Excel.Application();
                    m_Excel.SheetsInNewWorkbook = 1;//set 1 workbook
                    Microsoft.Office.Interop.Excel._Workbook m_Book = (Microsoft.Office.Interop.Excel._Workbook)(m_Excel.Workbooks.Add(Missing.Value));
                    Microsoft.Office.Interop.Excel._Worksheet m_Sheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_Book.Worksheets.get_Item(1));

                    m_Sheet.Name = "result";      //set name

                    int j = 0;

                    for (int i = 0; i < dw_export.RowCount; i++)
                    {                        
                        CustDetailsExport sResult = dw_export.GetItem<CustDetailsExport>(i);

                        m_Sheet.Cells[1 + i, 1] = sResult.CustId;
                        m_Sheet.Cells[1 + i, 2] = sResult.CustTitle;
                        m_Sheet.Cells[1 + i, 3] = sResult.CustInitials;
                        m_Sheet.Cells[1 + i, 4] = sResult.CustSurnameCompany;
                        m_Sheet.Cells[1 + i, 5] = sResult.CustPhoneDay;
                        m_Sheet.Cells[1 + i, 6] = sResult.CustPhoneNight;
                        m_Sheet.Cells[1 + i, 7] = sResult.CustPhoneMobile;
                        m_Sheet.Cells[1 + i, 8] = sResult.CustAddress;
                        m_Sheet.Cells[1 + i, 9] = sResult.CustMailCategory;
                        m_Sheet.Cells[1 + i, 10] = sResult.CustRecipients;
                        m_Sheet.Cells[1 + i, 11] = sResult.CustContract; 
                    }

                    // if need support office2000 pls check here
                    m_Book.SaveAs(savedlg.FileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value, Missing.Value);
                    m_Book.Close(false, Missing.Value, Missing.Value);
                    m_Excel.Quit();
                    m_Book = null;
                    m_Sheet = null;
                    m_Excel = null;
                }              
            }
            catch
            {
                MessageBox.Show("Export to excel failed", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //!GC.Collect();
        }

        #region Events
        public override void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            if (dw_criteria.GetColumnName() != "random_number")
            {
                //? base.dw_criteria_itemchanged();
            }
           //? dw_criteria_ue_postclicked();// dw_criteria.ue_PostClicked(0, 0, row, dwo);
        }

        public virtual void dw_criteria_editchanged(object sender, EventArgs e)
        {
            dw_criteria.URdsDw_EditChanged(sender, e);// base.editchanged();
            //  TJB 30_Sept-2004 SR4637
            //  Comment this out - hides open switch if user hasn't
            //  put in a number for the random option.
            //  pb_open.hide ( )
        }

        public void dw_criteria_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            this.dw_criteria_ue_postclicked();
        }

        public void dw_criteria_RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DetailedReport != null)
            {
                if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DetailedReport.ToString() == "Y")
                {
                    dw_criteria.GetControlByName("random_number").Visible = true;
                    dw_criteria.GetControlByName("random_number").Enabled = true;
                }
                else
                {
                    dw_criteria.GetControlByName("random_number").Visible = false;
                }
            }
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            int? ll_target;
            string ls_select;
            string ls_sqlDelete;
            string ls_tmpTable;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            //?WDetailedCustomerListing wCustList;
            WCustomerLabels wCustLabels;
            WCustlistSelect wCustSelect;
            Cursor.Current = Cursors.WaitCursor;
            dw_criteria.AcceptText();
            // 	ll_target used to identify the type of report/labels
            //  - passed in gnv_App.of_Get_Parameters ( ).LongParm
            //  TJB  Release 6.8.7 fixup: add -3 value to distinguish report title
            // 			-3			detailed report: Delivery Frequency
            // 			-2			detailed report: Days of Week
            // 			-1			Address labels
            // 			>0			Random labels
            //  Base select - stored into global struct g_aprameters.stringparm
            //  used by detailed report and [normal] address labels
            ls_select = @" SELECT Distinct rds_customer.cust_id  FROM address,   customer_address_moves,   outlet,   rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) AND	 (  rds_customer.cust_id = customer_address_moves.cust_id ) AND	 (  contract.contract_no = address.contract_no ) AND	 (  contract.con_base_office = outlet.outlet_id ) AND	 (   (  rds_customer.master_cust_id is null ) AND  (  customer_address_moves.move_out_date is null ) )   " + is_SQLWhere;
            // Set print_recipients flag 
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).PrintRecipients.ToString() == "Y") {
                StaticVariables.gnv_app.of_get_parameters().integerparm = 1;
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().integerparm = -(1);
            }
            // Set updateafterprint flag 
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).Updateafterprint != null)
            {
                if (dw_criteria.GetItem<CustCriteriaDeldays>(0).Updateafterprint.ToString() == "Y")
                {
                    StaticVariables.gnv_app.of_get_parameters().printedonparm = true;
                }
                else
                {
                    StaticVariables.gnv_app.of_get_parameters().printedonparm = false;
                }
            }
            // Determine type of report to run
            if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DetailedReport == "Y")
            {
                // Detailed report
                ll_target = -(2);
                StaticVariables.gnv_app.of_get_parameters().longparm = ll_target;
                StaticVariables.gnv_app.of_get_parameters().stringparm = ls_select;
                // Get parameters for detailed report
                StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
                // Run w_detailed_customer_listing
                //  OpenSheet(wCustList, w_main_mdi, 0, original);
                 OpenSheet<WDetailedCustomerListing>(StaticVariables.MainMDI);
            }
            else
            {
                if (dw_criteria.GetItem<CustCriteriaDeldays>(0).DetailedReport == "R")
                {
                    //  Random address labels
                    ll_target = dw_criteria.GetItem<CustCriteriaDeldays>(0).RandomNumber;
                    if (StaticFunctions.f_nempty(ll_target))
                    {
                        MessageBox.Show("You must select the number of labels to be randomly generated", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        dw_criteria.GetControlByName("random_number").Focus();
                        return;
                    }
                    else if (ll_target > StaticVariables.gnv_app.of_get_parameters().doubleparm)
                    {
                        MessageBox.Show("You can not select a random number of labels greater than the number of labels av" + "ailable", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        dw_criteria.GetControlByName("random_number").Focus();
                        return;
                    }
                    ls_select = @" SELECT rds_customer.cust_id, number ( *), address.adr_id  FROM address, customer_address_moves, outlet, rds_customer, contract WHERE  (  customer_address_moves.adr_id = address.adr_id ) AND	 (  rds_customer.cust_id = customer_address_moves.cust_id ) AND	 (  contract.contract_no = address.contract_no ) AND	 (  contract.con_base_office = outlet.outlet_id ) AND	 (   (  rds_customer.master_cust_id is null ) AND  (  customer_address_moves.move_out_date is null ) ) " + is_SQLWhere;
                    ls_tmpTable = "tmp_rand_cust_list";
                    ls_select = "Insert Into tmp_rand_cust_list  ( cust_id,sequence, adr_id) " + ls_select;
                }
                else
                {
                    ll_target = -(1);
                    ls_tmpTable = "report_temp";
                    ls_select = "Insert Into report_temp " + ls_select;
                }
                StaticVariables.gnv_app.of_get_parameters().stringparm = ls_select;
                StaticVariables.gnv_app.of_get_parameters().longparm = ll_target;
                //  TJB  SR4646  Jan 2005
                //  Select the customers for the labels
                //   ( moved from w_customer_labels)
                ls_sqlDelete = "delete from " + ls_tmpTable;
                //  Clear out the temporary table
                //? EXECUTE IMMEDIATE :ls_sqlDelete;
                if (ls_tmpTable == "tmp_rand_cust_list")
                {
                    RDSDataService.DeleteTmpRandCustList(ref SQLCode, ref SQLErrText);
                }
                if (ls_tmpTable == "report_temp")
                {
                    RDSDataService.DeleteReportTemp(ref SQLCode, ref SQLErrText);
                }
                if (SQLCode == -(1))
                {
                    //? ROLLBACK;
                    MessageBox.Show("WARNING: Unable to delete from temporary table " + ls_tmpTable + "~r~r" + SQLErrText, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //  Insert the selected customers into the temporary table
                //? EXECUTE IMMEDIATE :ls_select;
                
                //add by hh on 2007/08/27
                RDSDataService.InsertReportTemp(ls_select);
                if (SQLCode == -(1))
                {
                    //? ROLLBACK;
                    MessageBox.Show("WARNING: Unable to select customers into temporary table " + ls_tmpTable + "~r~r" + SQLErrText, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //  Commit the changes
                //? COMMIT;
                //  Generate the labels     ( the StringParm is now redundant - TJB)
                //  If generating normal labels, go through w_custlist_select to 
                //  give the user the chance to further select addresses to print.
                if (ll_target == -(1))
                {
                    // OpenSheet(wCustSelect, w_main_mdi, 0, original);
                    OpenSheet<WCustlistSelect>(StaticVariables.MainMDI);
                }
                else
                {
                    // OpenSheet(wCustLabels, w_main_mdi, 0, original);
                    OpenSheet<WCustomerLabels>(StaticVariables.MainMDI);
                }
                // 	OpenSheet ( wCustLabels, w_main_mdi, 0, original!)
            }
        }

        public virtual void cb_export_clicked(object sender, EventArgs e)
        {
            string sSQLStatement;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            // datastore ds_Report
            // dw_Export = CREATE n_ds
            // ds_Report.DataObject = "d_cust_details_export"
            // execute immediate "delete from report_temp";
            RDSDataService.DeleteReportTemp(ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //? ROLLBACK;
                MessageBox.Show("Warning: Unable to delete from temporary table", "Export Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sSQLStatement = @"  SELECT Distinct rds_customer.cust_id  FROM address,   customer_address_moves,   outlet, " + 
                "rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   " + 
                " (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and  " +
                " (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id is null ) AND " + 
                "(  customer_address_moves.move_out_date is null ) )   " + is_SQLWhere;
            sSQLStatement = "insert into report_temp " + sSQLStatement;
            // clipboard ( sSQLStatement )
            //execute immediate :sSQLStatement ;
            RDSDataService.ExecuteSqlRecipients(sSQLStatement, ref SQLCode, ref SQLErrText);
            
            if (SQLCode == -(1))
            {
                //? ROLLBACK;
                MessageBox.Show("Warning: Unable to insert into temporary table", "Export Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //? COMMIT;
            ((DCustDetailsExport)dw_export.DataObject).Retrieve();
            dw_export.InsertItem<CustDetailsExport>(0);
            dw_export.GetItem<CustDetailsExport>(0).CustId = "Id";
            dw_export.GetItem<CustDetailsExport>(0).CustTitle = "Title";
            dw_export.GetItem<CustDetailsExport>(0).CustInitials = "Initials";
            dw_export.GetItem<CustDetailsExport>(0).CustSurnameCompany = "Surname / Company";
            dw_export.GetItem<CustDetailsExport>(0).CustPhoneDay = "Day Phone";
            dw_export.GetItem<CustDetailsExport>(0).CustPhoneNight = "Night Phone";
            dw_export.GetItem<CustDetailsExport>(0).CustPhoneMobile = "Mobile Phone";
            dw_export.GetItem<CustDetailsExport>(0).CustAddress = "Address";
            dw_export.GetItem<CustDetailsExport>(0).CustMailCategory = "Category";
            dw_export.GetItem<CustDetailsExport>(0).CustRecipients = "Recipients";
            dw_export.GetItem<CustDetailsExport>(0).CustContract = "Contract";
            dw_export.of_SetUpdateable(false);


            dw_export.SaveAs("", "excel5");//dw_export.SaveAs("", excel5, false);            
            //ExportToExcel();
        }
        #endregion
    }
}
