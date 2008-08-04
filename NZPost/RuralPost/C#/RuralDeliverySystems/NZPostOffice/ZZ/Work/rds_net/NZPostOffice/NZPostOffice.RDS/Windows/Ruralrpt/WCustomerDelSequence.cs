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
    public partial class WCustomerDelSequence : WGenericReportSearch
    {
        public int iCount;

        public string is_SQLWhere = "";

        public WCustomerDelSequence()
        {
            InitializeComponent();

            //jlwang:moved from IC
            ((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("summaryreport"))).CheckedChanged += new System.EventHandler(dw_criteria_CheckedChanged);
            ((System.Windows.Forms.PictureBox)(dw_criteria.GetControlByName("freq_bmp"))).Click += new System.EventHandler(dw_criteria_clicked);
            //jlwang:end
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            DataUserControl dwChild;
            int? lNull;
            lNull = null;
            /*?dwChild= dw_criteria.GetChild("region_id");
            ((DCustSequenceSearch)dwChild).Retrieve();
            dwChild.InsertItem<CustSequenceSearch>(0);
            dwChild.GetItem<CustSequenceSearch>(0).RegionIdRo = lNull;
            dwChild.SetItem(1, "rgn_name", "<All Regions>");*/
            /*?dwChild =  dw_criteria.GetChild("region_id_ro");
            dwChild.Retrieve();
            dwChild.InsertItem<CustSequenceSearch>(0);
            dwChild.GetItem<CustSequenceSearch>(0).RegionIdRo = lNull;
            dwChild.SetItem(1, "rgn_name", "<All Regions>");*/
            lNull = null;
            dwChild = dw_criteria.GetChild("sf_key");
            dwChild.Retrieve();
            //? dw_criteria.InsertItem<CustSequenceSearch>(0);
            //?  dw_results.SetRowFocusIndicator(focusrect);
        }

        public virtual int wf_sel_freq()
        {
            int? lContract;
            int SQLCode = 0;
            string SQLErrText = string.Empty;
            // dw_Criteria.DataControl["freq_picklist"].Focus()
            //  dw_criteria.modify ( "freq_bmp.filename='..\bitmaps\pcklstdn.bmp'")
            //  TJB SR4618  4-Aug-2004
            //  Uncommented 'accepttext' line.  Why was it commented out?
            dw_criteria.AcceptText();
            lContract = dw_criteria.GetItem<CustSequenceSearch>(0).ContractNo;

            /* select count(*) into :iCount from contract where contract_no = :lContract;*/
            iCount = RDSDataService.GetContractICount(lContract, ref SQLCode, ref SQLErrText);
            if (SQLCode != 0 && SQLCode != 100)
            {
                //? rollback;
                MessageBox.Show("There was an error checking the contract number.~r~r" + SQLErrText, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //? commit;
            }
            if (iCount == 0)
            {
                MessageBox.Show("The entered contract number does not exist on the database.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                dw_criteria.GetControlByName("contract_no").Focus();
            }
            else
            {
                StaticVariables.gnv_app.of_get_parameters().longparm = lContract;
                // open(w_select_frequency);
                WSelectFrequency w_select_frequency = new WSelectFrequency();
                w_select_frequency.ShowDialog();
                if (StaticVariables.gnv_app.of_get_parameters().stringparm != "NotFound")
                {
                    dw_criteria.GetItem<CustSequenceSearch>(0).SfKey = StaticVariables.gnv_app.of_get_parameters().integerparm;
                    dw_criteria.GetItem<CustSequenceSearch>(0).DeliveryDays = StaticVariables.gnv_app.of_get_parameters().stringparm;
                    dw_criteria.GetControlByName("compute_1").Visible = true; //added by mkwang
                    dw_criteria.DataObject.BindingSource.CurrencyManager.Refresh(); //added by mkwang
                    dw_criteria.SetCurrent(0);
                }
            }
            //  dw_criteria.modify ( "freq_bmp.filename='..\bitmaps\pcklstup.bmp'")
            return 0;
        }

        #region Events
        public override void dw_criteria_clicked(object sender, EventArgs e)
        {
            //? base.clicked();
            string sObjectAtPointer = string.Empty;
            // sObjectAtPointer = dw_criteria.getobjectatpointer();
            sObjectAtPointer = "freq_bmp";//dw_criteria.DataObject.ActiveControl.Name;//sObjectAtPointer = dw_criteria.DataObject.GetColumnName();
            // if (Left(sObjectAtPointer, 8) == "freq_bmp") {
            // if (sObjectAtPointer.Substring(0,8) == "freq_bmp")
            if ((sObjectAtPointer != null) && (sObjectAtPointer.Length >= 8) && sObjectAtPointer.Substring(0, 8) == "freq_bmp")
            {
                wf_sel_freq();
            }
        }

        public void dw_criteria_CheckedChanged(object sender, EventArgs e)
        {
            if (((System.Windows.Forms.CheckBox)(dw_criteria.GetControlByName("summaryreport"))).Checked)
            {
                dw_criteria.GetControlByName("n_9993078").Visible = true;
                dw_criteria.GetControlByName("sortorder1").Visible = true;
                dw_criteria.GetControlByName("sortorder2").Visible = true;
            }
            else
            {
                dw_criteria.GetControlByName("n_9993078").Visible = false;
                dw_criteria.GetControlByName("sortorder1").Visible = false;
                dw_criteria.GetControlByName("sortorder2").Visible = false;
            }
        }

        public override void dw_criteria_itemchanged(object sender, EventArgs e)
        {
            //? base.dw_criteria_itemchanged();
            if (dw_criteria.GetColumnName() == "freq_picklist")
            {
                wf_sel_freq();
            }
        }

        public override void dw_criteria_itemfocuschanged(object sender, EventArgs e)
        {
            //?base.dw_criteria_itemfocuschanged();
            if (dw_criteria.GetColumnName() == "freq_picklist")
            {
                //?dw_criteria.modify("freq_rect.pen.color=0");
            }
            else
            {
                //?dw_criteria.modify("freq_rect.pen.color=8421504");
            }
        }

        public override void pb_search_clicked(object sender, EventArgs e)
        {
            string sSQLSelect;
            string sSQLSelectRecipients;
            string sCondition;
            string sCondition2;
            int lCount;
            int lRecipientCount;
            dw_criteria.AcceptText();
            // sSQLSelect = " &
            // select count ( distinct customer.cust_id) &
            // from customer key join contract key join customer_mail_category, &
            //  contract join outlet on contract.con_base_office = outlet.outlet_id "
            sSQLSelect = @"SELECT count ( distinct rds_customer.cust_id)  FROM address,   customer_address_moves,   outlet,   rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and   (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id is null ) and   (  customer_address_moves.move_out_date is null ) )";
            // sSQLSelectRecipients = " &
            // select count ( distinct recipient.recipient_id) &
            // from customer key join contract key join customer_mail_category key join recipient, &
            //  contract join outlet on contract.con_base_office = outlet.outlet_id "
            // **Recipients Select**
            sSQLSelectRecipients = @"SELECT count ( distinct rds_customer.cust_id)  FROM address,   customer_address_moves,   outlet,   rds_customer,  contract  WHERE  (  customer_address_moves.adr_id = address.adr_id ) and   (  rds_customer.cust_id = customer_address_moves.cust_id ) and   (  contract.contract_no = address.contract_no ) and   (  contract.con_base_office = outlet.outlet_id ) and   (   (  rds_customer.master_cust_id > 0 ) and   (  customer_address_moves.move_out_date is null ) )";
            // **Region**
            /*? if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustSequenceSearch>(0).RegionId)))
             {
                 is_SQLWhere = is_SQLWhere + " and outlet.region_id = " + Convert.ToString(dw_criteria.GetItem<CustSequenceSearch>(0).RegionId);
             }
             // **Base Office**
             if (!(StaticFunctions.f_nempty(dw_criteria.GetItem<CustSequenceSearch>(0).OutletId)))
             {
                 is_SQLWhere = is_SQLWhere + " and outlet.outlet_id = " + Convert.ToString(dw_criteria.GetItem<CustSequenceSearch>(0).OutletId);
             }
             // **Customer Category**
             // PowerBuilder 'Choose Case' statement converted into 'if' statement
             string TestExpr = dw_criteria.GetItemString(1, "mail_category");
             if (TestExpr == 'B') {
                 is_SQLWhere = is_SQLWhere + " and rds_customer.cust_business = \'Y\'";
             }
             else if (TestExpr == 'R') {
                 is_SQLWhere = is_SQLWhere + " and rds_customer.cust_rural_residential = \'Y\'";
             }
             else if (TestExpr == 'F') {
                 is_SQLWhere = is_SQLWhere + " and rds_customer.cust_rural_farmer = \'Y\'";
             }
             // **Delivery Days**
            if (dw_criteria.GetItemString(1, "onlydays") != "NNNNNNN") 
            {
                 if (dw_criteria.GetItemString(1, "del_days_condition") == 'A') {
                     sCondition2 = " and exists  (  select 1 from address_frequency_sequence where address.adr_id = a" +
                 "ddress_frequency_sequence.adr_id and ";
                     sCondition = dw_criteria.GetItemString(1, "anydays");
                     sCondition = " ( " +  TextUtil.Mid (sCondition, 4) + ')';
                     is_SQLWhere = is_SQLWhere + sCondition2 + sCondition + ')';
                 }
                 else {
                     is_SQLWhere = is_SQLWhere + "and exists  ( Select rf_delivery_days from address_frequency_sequence where addre" +
                 "ss_frequency_sequence.adr_id = address.adr_id and address_frequency_sequence.rf_" +
                 "delivery_days =\'" + dw_criteria.GetItemString(1, "onlydays") + "\')";
                 }
             }
             // if dw_Criteria.GetItemString ( 1, "onlydays") <> "NNNNNNN" then
             // 	if dw_Criteria.GetItemString ( 1, "del_days_condition") = "A" then
             // 		sCondition = dw_Criteria.GetItemString ( 1, "anydays")
             // 		sCondition = " ( " + mid ( sCondition, 4) + ")"
             // 		is_SQLWhere = is_SQLWhere + " and " + sCondition
             // 	else
             // 		is_SQLWhere = is_SQLWhere + " and customer.cust_delivery_days = '" + dw_Criteria.GetItemString ( 1, "onlydays") + "'"
             // 	end if
             // end if
             // **Privacy**
             if (dw_criteria.GetItemString(1, "directory_listing") != '_') 
             {
                 is_SQLWhere = is_SQLWhere + " and rds_customer.cust_dir_listing_ind = \'" + dw_criteria.GetItem<CustSequenceSearch>(0) "directory_listing") + '\'';
             }*/
            // if is_SQLWhere <> "" then
            // 	is_SQLWhere = " where " + mid ( is_SQLWhere, 5)
            // end if
            sSQLSelect = sSQLSelect + is_SQLWhere;
            /*? DECLARE my_cursor DYNAMIC CURSOR FOR SQLSA ;
             PREPARE SQLSA FROM :sSQLSelect;
             OPEN my_cursor
             FETCH my_cursor INTO :lCount ;
             CLOSE my_cursor*/
            /*? if (dw_criteria.GetItemString(1, "print_recipients") == 'Y') 
             {
                 sSQLSelectRecipients = sSQLSelectRecipients + is_SQLWhere;
                 DECLARE Recip_cursor DYNAMIC CURSOR FOR SQLSA ;
                 PREPARE SQLSA FROM :sSQLSelectRecipients;
                 OPEN Recip_cursor
                 FETCH Recip_cursor INTO :lRecipientCount ;
                 CLOSE Recip_cursor
                 lCount = lCount + lRecipientCount;
             }*/
            //?dw_criteria.GetItem<CustSequenceSearch>(0).CustomerCount = lCount;
            dw_criteria.GetControlByName("st_counter").Visible = true;//visible=1");
        }

        public override void pb_open_clicked(object sender, EventArgs e)
        {
            string sSQLSelect;
            int? lContractNo;
            int lregion;
            int? ll_sf_key;
            string ls_delDays = string.Empty;
            dw_criteria.AcceptText();
            lContractNo = dw_criteria.GetItem<CustSequenceSearch>(0).ContractNo;
            if (lContractNo == null || lContractNo <= 0)
            {
                MessageBox.Show("A contract number must be specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ll_sf_key = dw_criteria.GetItem<CustSequenceSearch>(0).SfKey;
            if (ll_sf_key == null || ll_sf_key == 0)
            {
                MessageBox.Show("The delivery days for the contract must be specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ls_delDays = dw_criteria.GetItem<CustSequenceSearch>(0).DeliveryDays;
            if (ls_delDays == null)
            {
                ls_delDays = "NULL";
            }
            if (iCount == 0)
            {
                MessageBox.Show("The entered contract number does not exist on the database~r" + "or it is from another region where you have no access", this.Text);
                return;
            }
            if (dw_criteria.GetItem<CustSequenceSearch>(0).Summaryreport.ToString() == "True")
            {
                StaticVariables.gnv_app.of_get_parameters().dwparm = dw_criteria.DataObject;
                Cursor.Current = Cursors.WaitCursor;
                // OpenSheet(w_customer_sequence_report, w_main_mdi, 0, original);
                OpenSheet<WCustomerSequenceReport>(StaticVariables.MainMDI);
            }
            else
            {
                // 	gnv_App.of_Get_Parameters ( ).stringparm =  &
                // 				 "select cust_id from customer"  &
                // 				+" where contract_no = "         &
                // 						+ string ( dw_Criteria.GetItemNumber ( 1, "contract_no"))  
                StaticVariables.gnv_app.of_get_parameters().stringparm = "select rds_customer.cust_id" + "  from rds_customer, customer_address_moves, address" + " where rds_customer.cust_id = customer_address_moves.cust_id" + "   and customer_address_moves.adr_id = address.adr_id" + "   and customer_address_moves.move_out_date is null" + "   and rds_customer.master_cust_id is null" + "   and address.contract_no = " + lContractNo.ToString();
                // 				+"   and address.contract_no = " + string ( dw_Criteria.GetItemNumber ( 1, "contract_no"))  
                StaticVariables.gnv_app.of_get_parameters().integerparm = 1;
                Cursor.Current = Cursors.WaitCursor;
                OpenSheet<WDetailedCustomerListing>(StaticVariables.MainMDI);
            }
        }
        #endregion
    }
}
