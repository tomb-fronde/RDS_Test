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
using NZPostOffice.RDS.DataControls.Ruralrpt;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Windows.Ruralwin2;
using NZPostOffice.RDS.DataService;
using NZPostOffice.RDS.DataControls.Ruralsec;

namespace NZPostOffice.RDS.Windows.Ruralrpt
{
    public partial class WCustomerCounterDelFreq : WGenericReportSearch
    {
        #region Define
        public string is_SQLWhere = "";

        public int ilMax = 2000;

        #endregion

        public WCustomerCounterDelFreq()
        {
            InitializeComponent();

            //p! need to see the designer
            dw_criteria.DataObject = new DCustCriteriaDelfreq();
            dw_criteria.DataObject.BorderStyle = BorderStyle.Fixed3D;
            st_max.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;



            //jlwang:moved from IC
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("outlet_bmp"))).Click += new EventHandler(dw_criteria_clicked);
            ((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("use_printedon"))).CheckedChanged += new EventHandler(dw_criteria_CheckBoxCheckedChanged);
            //((System.Windows.Forms.RadioButton)(dw_criteria.GetControlByName("detailed_report3"))).CheckedChanged += new EventHandler(dw_criteria_RadioButtonCheckedChanged);
            ((System.Windows.Forms.RadioButton)(dw_criteria.GetControlByName("detailed_report3"))).CheckedChanged += new EventHandler(dw_criteria_RadioButtonCheckedChanged);
            ((System.Windows.Forms.RadioButton)(dw_criteria.GetControlByName("cust_de_type2"))).CheckedChanged += new EventHandler(dw_criteria_RadioButtonCheckedchanged);
            //jlwang:end
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            DataUserControl dwChild;
            int lNull;
            bool? lb_privacy_override = false;
            dw_criteria.GetControlByName("st_recipient").Visible = false;
            dw_criteria.GetControlByName("st_counter").Visible = false;
            lb_privacy_override = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_privacyoverride();
            if (lb_privacy_override == null || lb_privacy_override == false)
            {
                //  set the privacy flag to 'Yes' and disable the field
                dw_criteria.GetItem<CustCriteriaDelfreq>(0).DirectoryListing = "N";
                dw_criteria.GetControlByName("directory_listing").Enabled = false;
            }
            else
            {
                //  allow user to choose the privacy settings
            }
            dw_criteria.GetControlByName("printedon_todate").BackColor = System.Drawing.SystemColors.Control;
            dw_criteria.GetControlByName("printedon_fromdate").BackColor = System.Drawing.SystemColors.Control;
            pb_open.Hide();
            cb_export.Hide();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            st_max.Text = "No more than " + ilMax.ToString() + " customers may be targeted at once.";
        }

        public virtual string wf_getparms()
        {
            string sRegion;
            string sOutlet;
            string sRenGroup;
            string sContract;
            string sParm;
            string sTemp;
            string sdirectory_listing;
            int? ldel_days_week;
            int? lRegion;
            int? lOutlet;
            int lRenGroup;
            int lContract;
            int lRow;
            int lcount;
            // get region, outlet codes
            lRegion = dw_criteria.GetItem<CustCriteriaDelfreq>(0).RegionIdRo;
            lOutlet = dw_criteria.GetItem<CustCriteriaDelfreq>(0).OutletId;
            ldel_days_week = dw_criteria.GetItem<CustCriteriaDelfreq>(0).DelDaysWeek;
            sdirectory_listing = dw_criteria.GetItem<CustCriteriaDelfreq>(0).DirectoryListing;
            // get region, outlet description
            if (lRegion == null)
            {
                sParm = "All Regions";
            }
            else
            {
                // SELECT region.rgn_name  INTO :sParm  FROM region  WHERE region.region_id = :lRegion;
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
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            int? TestExpr = ldel_days_week;
            if (TestExpr == 0)
            {
                sParm += "\r\nAny day of week";
            }
            else if (TestExpr == 1)
            {
                sParm += "\r\n1 day/week";
            }
            else if (TestExpr == 2)
            {
                sParm += "\r\n2 days/week";
            }
            else if (TestExpr == 3)
            {
                sParm += "\r\n3 days/week";
            }
            else if (TestExpr == 4)
            {
                sParm += "\r\n4 days/week";
            }
            else if (TestExpr == 5)
            {
                sParm += "\r\n5 days/week";
            }
            else if (TestExpr == 6)
            {
                sParm += "\r\n6 days/week";
            }
            else if (TestExpr == 7)
            {
                sParm += "\r\n7 days/week";
            }
            return sParm;
        }

        public override int wf_getoutlet()
        {
            string sOutlet;
            int? lregionx;
            //?dw_criteria.Modify("outlet_bmp.filename=\'..\\bitmaps\\pcklstdn.bmp\'");
            dw_criteria.GetControlByName("outlet_picklist").Focus();
            dw_criteria.GetControlByName("outlet_bmp").Focus();
            sOutlet = dw_criteria.GetValue<string>(0, "o_name");
            if (sOutlet == "<All Outlets>")
            {
                sOutlet = "";
            }
            lregionx = dw_criteria.DataObject.GetItem<NZPostOffice.RDS.Entity.Ruralrpt.CustCriteriaDelfreq>(0).RegionIdRo;
            //lregionx = dw_criteria.GetItem<int?>(0, "_region_id");
            StaticVariables.gnv_app.of_get_parameters().integerparm = null;
            StaticVariables.gnv_app.of_get_parameters().longparm = null;
            StaticVariables.gnv_app.of_get_parameters().integerparm = lregionx;
            StaticVariables.gnv_app.of_set_componenttoopen(this.of_get_componentname());
            Cursor.Current = Cursors.WaitCursor;
            //OpenWithParm(w_qs_outlet, sOutlet);
            StaticMessage.StringParm = sOutlet;
            WQsOutlet w_qs_outlet = new WQsOutlet();
            w_qs_outlet.ShowDialog();
            // opensheetwithParm ( w_qs_outlet,sOutlet, w_main_mdi, 0, originaL!)
            if (StaticVariables.gnv_app.of_get_parameters().longparm > 0)
            {
                dw_criteria.SetValue(0, "outlet_id", StaticVariables.gnv_app.of_get_parameters().longparm);
                dw_criteria.SetValue(0, "region_id_ro", StaticVariables.gnv_app.of_get_parameters().integerparm);
                dw_criteria.SetValue(0, "o_name", StaticVariables.gnv_app.of_get_parameters().stringparm);
                dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();

            }
            //? dw_criteria.Modify("outlet_bmp.filename=\'..\\bitmaps\\pcklstup.bmp\'");
            return 0;
        }

        #region Events
        public override void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            // ? base.dw_criteria_itemchanged();
            //  TJB SR4613 1 June 2004
            //  Commented out: user queried about continuing in pb_search.clicked
            // 
            // if this.GetColumnName ( ) = "random_number" then
            // 	if Metex.Common.Convert.ToInt32( Gettext ( )) > ilMax then
            // 		MessageBox ( Parent.Title,"Number of random labels exceeds the maximum number allowed.", StopSign!)
            // 		This.SetText ( "")
            // 	end if
            // end if
            //? dw_criteria_ue_postclicked();//dw_criteria.ue_PostClicked(0, 0, row, dwo);
        }

        public void dw_criteria_RadioButtonCheckedchanged(object sender, EventArgs e)
        {
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).CustDeType != null)
            {
                if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).CustDeType.ToString() == "A")
                {
                    dw_criteria.GetControlByName("date_start").Enabled = true;
                    dw_criteria.GetControlByName("date_end").Enabled = true;
                }
                else
                {
                    dw_criteria.GetControlByName("date_start").Enabled = false;
                    dw_criteria.GetControlByName("date_end").Enabled = false;
                }
            }
        }

        public void dw_criteria_RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).DetailedReport != null)
            {
                if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).DetailedReport.ToString() == "Y" || 
                    //p! added
                    dw_criteria.GetItem<CustCriteriaDelfreq>(0).DetailedReport.ToString() == "N")
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

        public void dw_criteria_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            this.dw_criteria_ue_postclicked();
        }

        public virtual void dw_criteria_editchanged(object sender, EventArgs e)
        {
            dw_criteria.URdsDw_EditChanged(sender, e);//base.editchanged();
            //  TJB 30-Sept-2004 SR4637
            //  Comment this out - hides open switch if user hasn't
            //  put in a number for the random option.
            //  pb_open.hide ( )
        }

        public virtual void dw_criteria_ue_postclicked()
        {
            dw_criteria.AcceptText();
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).UsePrintedon != null)
            {
                if (((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("use_printedon"))).Checked)//if (dw_criteria.GetItem<CustCriteriaDeldays>(0).UsePrintedon.ToString() == "Y")
                {
                    dw_criteria.GetControlByName("printedon_fromdate").Enabled = true;
                    dw_criteria.GetControlByName("printedon_todate").Enabled = true;
                    dw_criteria.GetControlByName("printedon_fromdate").BackColor = Color.FromArgb(255, 255, 255);
                    dw_criteria.GetControlByName("printedon_todate").BackColor = Color.FromArgb(255, 255, 255);
                    dw_criteria.GetControlByName("updateafterprint").Enabled = true;//added by ylwang
                }
                else
                {
                    dw_criteria.GetItem<CustCriteriaDelfreq>(0).Updateafterprint = "N";
                    dw_criteria.GetControlByName("printedon_fromdate").Enabled = false;
                    dw_criteria.GetControlByName("printedon_todate").Enabled = false;
                    dw_criteria.GetControlByName("printedon_todate").BackColor = System.Drawing.SystemColors.Control;
                    dw_criteria.GetControlByName("printedon_fromdate").BackColor = System.Drawing.SystemColors.Control;
                    dw_criteria.GetControlByName("updateafterprint").Enabled = false;//added by ylwang
                }
            }
            return;//? 1;
        }

        public virtual void dw_criteria_losefocus(object sender, EventArgs e)
        {
            dw_criteria.AcceptText();
        }

        public override void pb_search_clicked(object sender, EventArgs e)
        {
            string sSQLSelect;
            string sSQLSelectRecipients;
            string sCondition;
            int? lCount;
            int? lRecipientCount;
            DateTime dStart;
            DateTime dEnd;
            int? lRand;
            DateTime dpo_fromdate;
            DateTime dpo_todate;
            DateTime dloaded_fromdate;
            DateTime dloaded_todate;
            //  TJB SR4613 31 May 2004
            //  Temporary variables
            string ls_msg;
            DialogResult li_ans;
            bool lb_continue;
            Cursor.Current = Cursors.WaitCursor;
            lRecipientCount = null;
            lCount = null;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            dw_criteria.GetItem<CustCriteriaDelfreq>(0).RecipientCount = lRecipientCount;
            dw_criteria.GetControlByName("st_recipient").Visible = false;//.visible=0");
            dw_criteria.GetItem<CustCriteriaDelfreq>(0).CustomerCount = lCount;
            dw_criteria.GetControlByName("st_counter").Visible = false;//.visible=0");
            dw_criteria.AcceptText();
            // **Main Select**
            sSQLSelect = @"SELECT count ( distinct rds_customer.cust_id) as custidCount FROM address, customer_address_moves, outlet, rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and   (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id is null ) and   (  customer_address_moves.move_out_date is null ) )";
            // **Recipients Select**
            sSQLSelectRecipients = @"SELECT count ( distinct rds_customer.cust_id)  FROM address, customer_address_moves, outlet, rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and   (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id > 0 ) and   (  customer_address_moves.move_out_date is null ) )";
            is_SQLWhere = "";
            // **Contract Number**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDelfreq>(0).ContractNo)))
            {
                is_SQLWhere = is_SQLWhere + " and contract.contract_no = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDelfreq>(0).ContractNo);
            }
            // **Region**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDelfreq>(0).RegionIdRo)))
            {
                is_SQLWhere = is_SQLWhere + " and outlet.region_id = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDelfreq>(0).RegionIdRo);
            }
            // **Base Office**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDelfreq>(0).OutletId)))
            {
                is_SQLWhere = is_SQLWhere + " and outlet.outlet_id = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDelfreq>(0).OutletId);
            }
            // **Mail Category**
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = dw_criteria.GetItem<CustCriteriaDelfreq>(0).MailCategory;
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
            // **Frequency**
            if (!(StaticFunctions.f_nempty(((Metex.Windows.DataEntityCombo)dw_criteria.GetControlByName("del_days_week")).SelectedIndex)))
            {
                is_SQLWhere = is_SQLWhere + @"and exists  ( Select standard_frequency.sf_days_week from address_frequency_sequence, standard_frequency where address_frequency_sequence.adr_id = address.adr_id and address_frequency_sequence.sf_key = standard_frequency.sf_key and standard_frequency.sf_days_week ='" + Convert.ToString(((Metex.Windows.DataEntityCombo)dw_criteria.GetControlByName("del_days_week")).SelectedIndex) + "\')";
            }
            // **Privacy**
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).DirectoryListing != "_")
            {
                is_SQLWhere = is_SQLWhere + " and rds_customer.cust_dir_listing_ind = \'" + dw_criteria.GetItem<CustCriteriaDelfreq>(0).DirectoryListing + '\'';
            }
            // **Date Commenced**
            dStart = Convert.ToDateTime(dw_criteria.GetItem<CustCriteriaDelfreq>(0).DateStart);
            dEnd = Convert.ToDateTime(dw_criteria.GetItem<CustCriteriaDelfreq>(0).DateEnd);
            if (dEnd == DateTime.MaxValue)
            {
                dEnd = DateTime.Today;
            }
            if (dStart != null)
            {
                // PowerBuilder 'Choose Case' statement converted into 'if' statement
                string TestExpr1 = dw_criteria.GetItem<CustCriteriaDelfreq>(0).CustDeType;
                if (TestExpr == "N")
                {
                    is_SQLWhere = is_SQLWhere + " and rds_customer.cust_date_commenced between \'" + dStart.ToString("YYYY-MM-DD") + "\' and \'" + dEnd.ToString("YYYY-MM-DD") + '\'';
                    // Case "T"
                    // 	is_SQLWhere = is_SQLWhere + " and rds_customer.cust_date_commenced between '" + string ( dStart, "YYYY-MM-DD") + "' and '" + string ( dEnd, "YYYY-MM-DD") + "'"
                    // Case "R"
                    // 	is_SQLWhere = is_SQLWhere + " and rds_customer.cust_date_commenced between '" + string ( dStart, "YYYY-MM-DD") + "' and '" + string ( dEnd, "YYYY-MM-DD") + "'"
                }
            }
            // **date printed**
            dpo_fromdate = Convert.ToDateTime(dw_criteria.GetItem<CustCriteriaDelfreq>(0).PrintedonFromdate);
            dpo_todate = Convert.ToDateTime(dw_criteria.GetItem<CustCriteriaDelfreq>(0).PrintedonTodate);
            if (dpo_todate == null && dpo_fromdate == null || dpo_todate != null && dpo_fromdate != null)
            {
                if (((TimeSpan)(dpo_todate - dpo_fromdate)).Days < 0)//DaysAfter(dpo_fromdate, dpo_todate) < 0) 
                {
                    MessageBox.Show("The date last printed FROM date must be earlier than the TO date", "Date Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("You must specify date last printed FROM date and TO date", "Date Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sUsePrintedOn = string.Empty;
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).UsePrintedon != null)
            {
                sUsePrintedOn = dw_criteria.GetItem<CustCriteriaDelfreq>(0).UsePrintedon.ToString();
            }
            if (sUsePrintedOn == "Y")
            {
                if (dpo_fromdate == null)
                {
                    is_SQLWhere += " AND rds_customer.printedon is null ";
                }
                else
                {
                    is_SQLWhere += " AND  ( rds_customer.printedon between \'" + dpo_fromdate.ToString("yyyy/MM/dd") + "\' and \'" + dpo_todate.ToString("yyyy/MM/dd") + "\')";
                }
            }
            // **date loaded**
            dloaded_fromdate = Convert.ToDateTime(dw_criteria.GetItem<CustCriteriaDelfreq>(0).LoadedFromdate);
            dloaded_todate = Convert.ToDateTime(dw_criteria.GetItem<CustCriteriaDelfreq>(0).LoadedTodate);
            if (dloaded_todate == null && dloaded_fromdate == null || dloaded_todate != null && dloaded_fromdate != null)
            {
                if (((TimeSpan)(dloaded_todate - dloaded_fromdate)).Days < 0)//DaysAfter(dloaded_fromdate, dloaded_todate) < 0) 
                {
                    MessageBox.Show("The date loaded FROM date must be earlier than the TO date", "Date Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("You must specify date loaded FROM date and TO date", "Date Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dloaded_fromdate != null && dloaded_fromdate != DateTime.MinValue)
            {
                is_SQLWhere += " AND rds_customer.cust_date_commenced between \'" + dloaded_fromdate.ToString("yyyy/MM/dd") + "\' and \'" + dloaded_todate.ToString("yyyy/MM/dd") + '\'';
            }
            // **Contract Type**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDelfreq>(0).CtKey)))
            {
                is_SQLWhere += " and contract.con_base_cont_type =  " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDelfreq>(0).CtKey) + "";
            }
            // **Renewal Group**
            if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustCriteriaDelfreq>(0).RgCode)))
            {
                is_SQLWhere += " and  ( contract.rg_code = " + Convert.ToString(dw_criteria.GetItem<CustCriteriaDelfreq>(0).RgCode) + ')';
            }
            // ******ADDITIONS END*******************
            sSQLSelect = sSQLSelect + is_SQLWhere;
            /*DECLARE my_cursor DYNAMIC CURSOR FOR SQLSA ;
             PREPARE SQLSA FROM :sSQLSelect;
             OPEN my_cursor
             FETCH my_cursor INTO :lCount ;
             CLOSE my_cursor*/
            lCount = RDSDataService.ExecuteSqlStringLcount(sSQLSelect, ref SQLCode, ref SQLErrText);
            dw_criteria.GetItem<CustCriteriaDelfreq>(0).CustomerCount = lCount;
            dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
            dw_criteria.GetControlByName("st_counter").Visible = true; //.visible=1");
            //  TJB SR4613 31 May 2004
            lb_continue = false;
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).DetailedReport == "R")
            {
                lRand = dw_criteria.GetItem<CustCriteriaDelfreq>(0).RandomNumber;
                // 	if lCount = 0 or lRand > ilMax then
                // 		pb_open.hide ( )
                // 		cb_export.hide ( )
                // 	else
                // 		pb_open.show ( )
                // 		cb_export.show ( )
                // 	end if
                // else
                // 
                // 	if lCount = 0 or lCount > ilMax then
                // 		pb_open.hide ( )
                // 		cb_export.hide ( )
                // 	else
                // 		pb_open.show ( )
                // 		cb_export.show ( )
                // 	end if
                //  Ask whether to keep going or not
                if (lCount == 0)
                {
                    lb_continue = false;
                }
                else if (lRand > ilMax)
                {
                    ls_msg = lCount.ToString() + " customers found; Do you want to continue?";
                    li_ans = MessageBox.Show(ls_msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                li_ans = MessageBox.Show(ls_msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                /*DECLARE Recip_cursor DYNAMIC CURSOR FOR SQLSA ;
                 PREPARE SQLSA FROM :sSQLSelectRecipients;
                 OPEN Recip_cursor
                 FETCH Recip_cursor INTO :lRecipientCount ;
                 CLOSE Recip_cursor*/
                lRecipientCount = RDSDataService.ExecuteSqlStringlRecipientCount(sSQLSelectRecipients, ref SQLCode, ref SQLErrText);
                dw_criteria.GetItem<CustCriteriaDelfreq>(0).RecipientCount = lRecipientCount;
                dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh();
                dw_criteria.GetControlByName("st_recipient").Visible = true;
                pb_open.Show();
                cb_export.Show();
            }
            else
            {
                pb_open.Hide();
                cb_export.Hide();
            }
            StaticVariables.gnv_app.of_get_parameters().doubleparm = lCount;
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            //? base.clicked();
            //  TJB  SR4646  Jan 2005
            //  Changed to do customer lookups
            int? ll_target;
            string ls_select;
            string ls_sqlDelete;
            string ls_tmpTable;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            WDetailedCustomerListing wCustList;
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
            //  Basic select - stored into global struct g_aprameters.stringparm
            //  used by detailed report and [normal] address labels
            ls_select = @" SELECT distinct rds_customer.cust_id  FROM address, customer_address_moves, outlet, rds_customer, contract  WHERE ( customer_address_moves.adr_id = address.adr_id ) AND	 (  rds_customer.cust_id = customer_address_moves.cust_id ) AND	 (  contract.contract_no = address.contract_no ) AND ( contract.con_base_office = outlet.outlet_id ) AND ( ( rds_customer.master_cust_id is null ) AND  (  customer_address_moves.move_out_date is null ) ) " + is_SQLWhere;
            // Set print_recipients flag 
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).PrintRecipients != null)
            {
                if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).PrintRecipients.ToString() == "Y")
                {
                    StaticVariables.gnv_app.of_get_parameters().integerparm = 1;
                }
                else
                {
                    StaticVariables.gnv_app.of_get_parameters().integerparm = -(1);
                }
            }
            // Set updateafterprint flag 
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).Updateafterprint != null)
            {
                if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).Updateafterprint.ToString() == "Y")
                {
                    StaticVariables.gnv_app.of_get_parameters().printedonparm = true;
                }
                else
                {
                    StaticVariables.gnv_app.of_get_parameters().printedonparm = false;
                }
            }
            // Determine type of report to run
            if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).DetailedReport == "Y")
            {
                //  TJB  Release 6.8.7 fixup
                //  Change value from -2 to -3
                ll_target = -(3);
                StaticVariables.gnv_app.of_get_parameters().longparm = ll_target;
                StaticVariables.gnv_app.of_get_parameters().stringparm = ls_select;
                StaticVariables.gnv_app.of_get_parameters().miscstringparm = wf_getparms();
                OpenSheet<WDetailedCustomerListing>(StaticVariables.MainMDI);
            }
            else
            {
                if (dw_criteria.GetItem<CustCriteriaDelfreq>(0).DetailedReport == "R")
                {
                    ll_target = dw_criteria.GetItem<CustCriteriaDelfreq>(0).RandomNumber;
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
                    //ls_select = @" SELECT rds_customer.cust_id, number ( *), address.adr_id  FROM address,   customer_address_moves, outlet, rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) AND	 (  rds_customer.cust_id = customer_address_moves.cust_id ) AND	 (  contract.contract_no = address.contract_no ) AND	 (  contract.con_base_office = outlet.outlet_id ) AND  (   (  rds_customer.master_cust_id is null ) AND	 (  customer_address_moves.move_out_date is null ) ) " + is_SQLWhere;
                    ls_select = @" SELECT rds_customer.cust_id, ROW_NUMBER() OVER (ORDER BY rds_customer.cust_id) AS RowNo, address.adr_id  FROM address,   customer_address_moves, outlet, rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) AND	 (  rds_customer.cust_id = customer_address_moves.cust_id ) AND	 (  contract.contract_no = address.contract_no ) AND	 (  contract.con_base_office = outlet.outlet_id ) AND  (   (  rds_customer.master_cust_id is null ) AND	 (  customer_address_moves.move_out_date is null ) ) " + is_SQLWhere;
                    ls_tmpTable = "tmp_rand_cust_list";
                    ls_select = "Insert into tmp_rand_cust_list  ( cust_id,sequence, adr_id) " + ls_select;
                }
                else
                {
                    ll_target = -(1);
                    ls_tmpTable = "report_temp";
                    ls_select = "Insert Into report_temp " + ls_select;
                }
                StaticVariables.gnv_app.of_get_parameters().longparm = ll_target;
                StaticVariables.gnv_app.of_get_parameters().stringparm = ls_select;
                //  TJB  SR4646  Jan 2005
                //  Select the customers for the labels
                //   ( moved from w_customer_labels)
                //  Clear out the old temporary file
                ls_sqlDelete = "delete from " + ls_tmpTable;
                // EXECUTE IMMEDIATE :ls_sqlDelete;
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
                    //?  ROLLBACK;
                    MessageBox.Show("WARNING: Unable to delete from temporary table " + ls_tmpTable + "~r~r" + SQLErrText, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //  Insert the selected customers into the temporary table
                //? EXECUTE IMMEDIATE :ls_select;
                RDSDataService.InsertReportTemp(ls_select);
                if (SQLCode == -(1))
                {
                    //? ROLLBACK;
                    MessageBox.Show("WARNING: Unable to select customers into temporary table " + ls_tmpTable + "~r~r" + SQLErrText, "SQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //  Commit the changes.
                //? COMMIT;
                //  Generate the labels   ( the StringParm is now redundant - TJB)
                //  If generating normal labels, go through w_custlist_select to 
                //  give the user the chance to further select addresses to print.
                if (ll_target == -(1))
                {
                    //  OpenSheet(wCustSelect, w_main_mdi, 0, original);
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
            //execute immediate "delete from report_temp";
            RDSDataService.DeleteReportTemp(ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //?   ROLLBACK;
                MessageBox.Show("Warning: Unable to delete from temporary table", "Export Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sSQLStatement = @"SELECT distinct rds_customer.cust_id  FROM address,   customer_address_moves,   outlet,   rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and   (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id is null ) and   (  customer_address_moves.move_out_date is null ) )" + is_SQLWhere;
            sSQLStatement = "insert into report_temp " + sSQLStatement;
            //execute immediate :sSQLStatement ;
            RDSDataService.ExecuteSqlString(sSQLStatement, ref SQLCode, ref SQLErrText);
            if (SQLCode == -(1))
            {
                //?    ROLLBACK;
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
            dw_export.SaveAs("", "excel5");// dw_export.SaveAs("", excel5, false);
        }
        #endregion
    }
}
