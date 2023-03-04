using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using NZPostOffice.ODPS.Windows.OdpsLib;
using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using NZPostOffice.ODPS.DataControls.OdpsCodes;
using NZPostOffice.ODPS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    // TJB RPCR_139 Bugfix July-2019
    // Moved search logic from pb1_clicked to of_search
    // Enabled <Search> button and disabled <?> (PB1) button
    // Disabled ue_search() - function duplicated in of_search()
    //
    // TJB  RPCR_141  June-2019
    // Added Contract_no and rg_code dropdown to DwPaymentRunPeriod, and
    // associated changes here and in OD_BLF_Mainrun to allow a user to 
    // specify a contract or renewal group for the payment run.  Also 
    // associated changes in OD_DWS_OwnerDriver_Search.
    // See mostly cb_open_clicked and pb_1_clicked
    // Also added a <Clear> button to reset the search parameters.
    // See cb_clear_clicked and of_clear
    //
    // TJB  RPCR_057  Dec-2013  [Drop audit triggers]
    // Disable calls to InserIntoRdsAudit and GetAkeyFromRdsAudit

    public partial class WPaymentRunSearch : WCriteriaSearch
    {
        //? public n_cst_selection inv_Selection;
        public DateTime? id_EndDate = DateTime.MinValue;

        public WPaymentRunSearch()
        {
            this.InitializeComponent();
            this.dw_search.DataObject = new DwPaymentRunPeriod();
            dw_search.DataObject.BorderStyle = BorderStyle.Fixed3D;
            this.dw_results.DataObject = new DwPaymentRunContractors();
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;

            //? dw_results.Constructor += new NZPostOffice.RDS.Controls.UserEventDelegate(dw_results_constructor);
            ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("start_date")).KeyPress += new KeyPressEventHandler(WPaymentRunSearch_KeyPress);
            ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).KeyPress += new KeyPressEventHandler(WPaymentRunSearch_KeyPress1);
        }

        // TJB RPCR_139 Bugfix July-2019
        // Disabled.  Duplicated in of_search
/*        public override void ue_search()
        {
            //?base.ue_search();
            DateTime? ldt_sdate;
            DateTime? ldt_edate;
            string ls_name;
            int? nRgCode;
            int? nContractNo;
            string sContractNo;
            int n;

            ldt_sdate = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate;
            ldt_edate = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;
            ls_name = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).OwnerDriver;

            // TJB  RPCR_141  June-2019 
            // Added nRgCode and nContractNo to parameter lists
            nRgCode = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).RgCode;
            //nContractNo = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).ContractNo;
            sContractNo = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).ContractNo;
            Int32.TryParse(sContractNo, out n);
            nContractNo = (int?)n;
            ((DwPaymentRunContractors)dw_results.DataObject).Retrieve(ls_name, ldt_sdate, ldt_edate
                                                                      , nRgCode, nContractNo);
        }
*/
        public override void pfc_preopen()
        {
            base.pfc_preopen();
            of_setaccess("Regional");
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            DateTime dstart;
            DateTime dEnd;
            string sStartMonth;
            string sStartYear;

            if (DateTime.Today.Month == 1)
            {
                sStartMonth = "12";
                sStartYear = Convert.ToString(DateTime.Today.Year - 1);//sStartYear = Year(Today().ToString() - 1);
            }
            else
            {
                sStartMonth = Convert.ToString(DateTime.Today.Month - 1); // sStartMonth = Month(Today().ToString() - 1);
                sStartYear = DateTime.Today.Year.ToString();
            }
            dstart = System.Convert.ToDateTime(sStartYear + '/' + sStartMonth + "/21");
            dEnd = System.Convert.ToDateTime(Convert.ToString(DateTime.Today.Year) + '/' + DateTime.Today.Month.ToString() + "/20");
            dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate = dstart;
            dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate = dEnd;
            dw_search.DataObject.BindingSource.CurrencyManager.Refresh();//added by jlwang
            /*?
            if (g_security.access_groups[11] == -(1))
            {
                MessageBox.Show("Sorry, you have no access to the payment run", base.Text);
                ib_close = true;
            }
            if (of_close())
            {
                this.Close();
            }*/
        }

        #region Methods
        public void mousemove()
        {
            // 
        }

        public virtual DateTime? wf_setenddate(DateTime? ded)
        {
            id_EndDate = ded;
            return id_EndDate;
        }

        public virtual DateTime? wf_getenddate()
        {
            return id_EndDate;
        }

        public virtual DateTime? of_calcStartDate(DateTime? pEnd)
        {
            int iday = pEnd.Value.Day + 1;
            int iMonth = pEnd.Value.Month - 1;
            int iYear = pEnd.Value.Year;
            if (iMonth <= 0)
            {
                iMonth = 12;
                iYear -= 1;
            }
            return new DateTime(iYear, iMonth, iday);
        }

        public virtual void ue_afterchanged()
        {
            DateTime? dStart;
            DateTime? dEnd;

            dEnd = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;
            //dstart = System.Convert.ToDateTime(String(Year(StaticMethods.RelativeDate(dEnd, -(28)))) + '/' + String(Month(StaticMethods.RelativeDate(dEnd, -(28)))) + "/21");
            if (dEnd == null)
                dStart = null;
            else
            {
                dStart = of_calcStartDate( dEnd );
                //dstart = Convert.ToDateTime(Convert.ToString(((DateTime)(((DateTime)dEnd).AddDays(-28))).Year)
                //    + "/"
                //    + Convert.ToString(((DateTime)(((DateTime)dEnd).AddDays(-28))).Month) + "/21");
            }
            dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate = dStart;

            dw_search.DataObject.BindingSource.CurrencyManager.Refresh(); //added by jlwang
        }

        private delegate void delegateInvoke();

        public virtual void CallUeAfterchanged()
        {
            ue_afterchanged();
        }

        //public override void dw_results_constructor()
        //{
        //    base.constructor();
        //    //? dw_results.of_setsort(true);
        //    dw_results.SelectAllRows(false);
        //}     
        #endregion

        #region Events
        //jlwang:
        private void WPaymentRunSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((DateTimeMaskedTextBox)this.dw_search.GetControlByName("start_date")).SelectionStart == 10)
            {
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("start_date")).Focus();
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("start_date")).SelectionStart = 0;
            }
        }

        //jlwang:
        private void WPaymentRunSearch_KeyPress1(object sender, KeyPressEventArgs e)
        {
            // TJB  RD7_0041 Feb-2010: Removed
            //    Don't know what this was supposed to do, but it stuffed up entry of the end date royally.
            //    I suspect the "substring(3)" should have been "substring(2)".
            //if (((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart == 4)
            //{
            //    //string str = ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text;
            //    str = ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text;
            //    //((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text = "20" + str.Substring(3);
            //    ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart = 4;
            //}

            // TJB  RD7_0041 Feb-2010: Added
            //    Check the day and month for valid values.  Warn the user if they're wrong
            //    and substitute appropriate vaulus.  Note: the year isn't checked here,
            //    but the date is checked for appropriatness elsewhere.
            int this_selectionstart = ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart;
            string str = ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text;
            string mth = str.Substring(3, 2);
            int month = Int32.Parse(mth);
            if (month < 1 || month > 12)
            {
                MessageBox.Show("Invalid month; please enter the end date in dd/mm/yyyy format.",
                                 "Warning");
                if (month < 1) mth = "01";
                if (month > 12) mth = "12";
                str = str.Substring(0, 3) + mth + str.Substring(5);
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text = str;
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart = 3;
            }
            string day = str.Substring(0, 2);
            int dayno = Int32.Parse(day);
            if (dayno != 20)
            {
                MessageBox.Show("Invalid day; the end date must be the 20th of the month.",
                                 "Warning");
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text = "20" + str.Substring(2);
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart = 3;
            }

            // If we're at the end of the date, treat as a tab.
            if (((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart == 10)
            {
                this.ProcessDialogKey(Keys.Tab);
                ue_afterchanged();
            }
        }

        public virtual void dw_search_itemchanged(object sender, EventArgs e)
        {
            BeginInvoke(new delegateInvoke(CallUeAfterchanged));
        }

        public virtual void dw_search_losefocus(object sender, EventArgs e)
        {
            dw_search.DataObject.AcceptText();
        }

        public override void cb_open_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int? lcontract;
            int? lcontractor;
            int? lLoggedOnUsers;
            DateTime? dStart;
            DateTime? dEnd;
            DateTime? tStart;
            int lPastRuns;
            int lRunResult;
            string sRunResult;
            //  TJB  SR4649  Dec 2004  
            //   ( see below around call to OD_BLF_Mainrun)
            string sErrMsg;
            int t_pos1;
            int t_pos2;
            string t_contractorNo = null;
            string t_dedID = null;
            string t_ded_description = null;

            // TJB  RPCR_141  June-2019:  Added
            // See various references to these below.
            // Added messages about what pay runs specified
            // nRgCode and nContractNo values would produce.
            int? nRgCode;
            int? nContractNo;
            int lRow, nContracts, n;
            string sContractNo;

            dw_search.DataObject.AcceptText();
            lRow = dw_results.GetSelectedRow(0);

            //  Get start and end dates
            dEnd = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;
            dStart = of_calcStartDate(dEnd);
            dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate = dStart;
            wf_setenddate(dEnd);
            dw_search.DataObject.BindingSource.CurrencyManager.Refresh();

            // TJB RPCR_141 June-2016
            // Note:  nRgCode and nContractNo are the relevant values
            // specified in dw_search.  lcontract and lcontractor
            // are values found in dw_results after a search.

            // First get the contract and renewal group from the selection
            // criteria (if any).
            sContractNo = dw_search.GetItem<PaymentRunPeriod>(0).ContractNo;
            nRgCode = dw_search.GetItem<PaymentRunPeriod>(0).RgCode;

            // If neither a contract or renewal group were specified for
            // a search, and no search result was selected, tell the user.
            if (nRgCode == null && sContractNo == null && lRow == -1)
            {
                MessageBox.Show("You must select a contract from the search results\n" 
                                + "or specify a contract or renewal group"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Look next to see if a search result has been selected
            // (lRow will be < 0 if nothing is selected from in dw_results)
            lcontract = null;
            lcontractor = null;
            if (lRow >= 0)
            {
                lcontract = dw_results.DataObject.GetItem<PaymentRunContractors>(lRow).ContractNo.GetValueOrDefault();
                lcontractor = dw_results.DataObject.GetItem<PaymentRunContractors>(lRow).ContractorNo;
            }

            // Next, get the contract and renewal group from the selection criteria
            // (a 0 for either or both will now mean nothing was specified)
            Int32.TryParse(sContractNo, out n);  // If sContractNo = ""
            nContractNo = (int?)n;               // TryParse will return 0
            if (nRgCode == null) nRgCode = 0;

            // If a contract was specified in the selection criteria and the user 
            // selected the 'all contracts/contractors' option (lcontract will == 0), 
            // use the specified contract for lcontract.
            if (nContractNo > 0 && (lRow < 0 || (lRow >=0 && lcontract == 0)))
            {
                // First check that the contract is valid
                ODPSDataService service = ODPSDataService.ValidateContract(nContractNo);
                nContracts = service.Count;
                if (nContracts == 0)
                {
                    MessageBox.Show("Invalid contract number specified"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Save the specified contract number as lcontract (which is what 
                // is used in the stored procedure doing the real work :-)
                lcontract = nContractNo;
                // Clear the selection values; lcontract will be used.
                nContractNo = 0;
                nRgCode = 0;

                // Tell the user what we're going to do
                if (MessageBox.Show("This payrun will be for all contractors holding "
                                  + "contract " + sContractNo + " in this pay period."
                                  , this.Text
                                  , MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                     == DialogResult.Cancel)
                {
                    return;
                }
            }

            // If no contract has been selected or specified, and no search result 
            // was selected, and a renewal group was specified we'll do a payrun
            // for the whole renewal group.  Tell the user.
            if (lRow < 0 && nRgCode > 0)
            {
                // Lookup renewal group description for the MessageBox
                string rgDescription;
                ODPSDataService service = ODPSDataService.GetRgDescription(nRgCode);
                rgDescription = service.Text;

                if (MessageBox.Show("This payrun will be for all contracts in renewal group "
                                   + rgDescription
                                   , this.Text
                                   , MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                    == DialogResult.Cancel)
                    return;
            }
            

            //  Validate start and end dates 
            if (((TimeSpan)(dStart - dEnd)).Days > 0)
            {
                MessageBox.Show("Start date must be earlier than end date"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //  Warn
            if (((TimeSpan)(dStart - dEnd)).Days > 31)
            {
                if (MessageBox.Show("Warning: the end date is too far into the future. Continue?"
                                    , "Invoice"
                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                    == DialogResult.No)
                {
                    return;
                }
            }

            // Get number of other users logged on
            //select db_property('conncount') into :lLoggedOnUsers from sys.dummy;
            lLoggedOnUsers = ODPSDataService.GetDbPropertyFromDummy(); ;
            if (lLoggedOnUsers > 1)
            {
                if (MessageBox.Show("Warning: There are " + Convert.ToString(lLoggedOnUsers - 1) 
                                        + " other users connected. Ignore?"
                                    , this.Text
                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                   != DialogResult.Yes)
                {
                    return;
                }
            }

            //  Detect past payment runs
            //select odps.od_blf_mainrun_checkrun(:lcontract, :lcontractor, :dstart,:dend) into :lPastRuns from sys.dummy;
            lPastRuns = ODPSDataService.GetOdBlfMainrunCheckrunFromDummy(lcontract, lcontractor, dStart, dEnd);

            if (lPastRuns > 0)
            {
                MessageBox.Show("Payment run already made for the contract(s) selected"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            /* -------------------------------- Debugging -------------------------------- /
            string sContract = (lcontract == null) ? "null" : lcontract.ToString();
            string sContractor = (lcontractor == null) ? "null" : lcontractor.ToString();
            string sContractNo = (nContractNo == null) ? "null" : nContractNo.ToString();
            string sRgCode = (nRgCode == null) ? "null" : nRgCode.ToString();

            if (MessageBox.Show( "Parameters for OD_BLF_Mainrun \n"
                          + "Contract    " + sContract + "\n"
                          + "Contractor  " + sContractor + "\n"
                          + "nContractNo " + sContractNo + "\n"
                          + "nRgCode     " + sRgCode + "\n"
                          , "Debugging"
                          , MessageBoxButtons.OKCancel)
                == DialogResult.Cancel)
                return;
            / --------------------------------------------------------------------------- */

            // If either the contract or contractor are null at this point,
            // set their values to 0 (all)
            lcontract = (lcontract == null ? 0 : lcontract);
            lcontractor = (lcontractor == null ? 0 : lcontractor);

            // Run! Call stored procedures!
            Cursor.Current = Cursors.WaitCursor;
            tStart = System.DateTime.Now;

            //  TJB  RPCR_141  June-2019
            // Added GetOdBlfMainrun to include nRgCode parameter
            ODPSDataService dataservice;
            if (nRgCode > 0)
                dataservice = ODPSDataService.GetOdBlfMainrun(lcontract, lcontractor, dStart, dEnd, nRgCode);
            else
                dataservice = ODPSDataService.GetOdBlfMainrunFromDummy(lcontract, lcontractor, dStart, dEnd);
            //? lRunResult = dataservice.RowCount;

            sRunResult = dataservice.DataObject;
            sRunResult = sRunResult == null ? "" : sRunResult;  //added by jlwang

            /* -------------------------------- Debugging -------------------------------- //
            MessageBox.Show("od_blf_mainrun returned " + sRunResult
                            ,"ODPS.Windows.OdpsPayrun.wPaymentRunSearch.cb_open_clicked");
            /* --------------------------------------------------------------------------- */

            //  TJB  SR4649  Dec 2004
            //  Changed return value to string to return error information from OD_BLF_Mainrun_PostTaxAdj
            //  Caught and parsed by Powerbuilder Payrun code (w_payrun_search)
            //  When there's an error, the string is a comma-separated list of values:
            //       <return code>, <contractor no>, <deduction ID>, <deduction description>
            //  otherwise its just a single value (the return code).

            t_pos1 = sRunResult.IndexOf(",");
            if (t_pos1 >= 0)
            {
                lRunResult = Convert.ToInt32(sRunResult.Substring(0, t_pos1));
            }
            else
            {
                //lRunResult = Convert.ToInt32(sRunResult);
                int.TryParse(sRunResult, out lRunResult);
            }

            //  If there is more to the return code than just the code itself
            //  Split off the other values.
            if (lRunResult == -(1) && t_pos1 >= 0)
            {
                // t_pos2 = TextUtil.Pos(sRunResult, ',', t_pos1 + 1);
                t_pos1 = t_pos1 + 1;
                t_pos2 = sRunResult.IndexOf(",", t_pos1);
                if (t_pos2 > 0)
                {
                    //t_contractorNo = TextUtil.Mid(sRunResult, t_pos1 + 1, t_pos2 - t_pos1 - 1);
                    t_contractorNo = sRunResult.Substring(t_pos1, t_pos2 - t_pos1);
                    t_pos1 = t_pos2 + 1;
                }
                //t_pos2 = TextUtil.Pos(sRunResult, ',', t_pos1 + 1);
                t_pos2 = sRunResult.IndexOf(",", t_pos1);
                if (t_pos2 > 0)
                {
                    // t_dedID = TextUtil.Mid(sRunResult, t_pos1 + 1, t_pos2 - t_pos1 - 1);
                    t_dedID = sRunResult.Substring(t_pos1, t_pos2 - t_pos1); 
                    t_pos1 = t_pos2 + 1;
                }
                //t_ded_description =  Mid(sRunResult, t_pos1 + 1);
                t_ded_description = sRunResult.Substring(t_pos1); 
                t_ded_description = t_ded_description == null ? "" : t_ded_description;

                //  Tell the user about the error and abort run
                MessageBox.Show("NULL deduction in OD_BLF_Mainrun_PostTaxAdj\r\r"
                                + "Contractor:   " + t_contractorNo + "\r"
                                + "  " + "Deduction ID: " + t_dedID + "\r"
                                + "  " + "Deduction:    " + t_ded_description + "\r\r"
                                + "Aborting run"
                                , "ERROR"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Stop);
                //? ROLLBACK;
                return;
            }

            if (lRunResult < 0 || dataservice.SQLCode < 0)
            {
                sErrMsg = "";
                if (dataservice.SQLCode != 0)
                {
                    sErrMsg = "SQLCODE = " + Convert.ToString(dataservice.SQLCode) + "\r"
                              + "   - " + dataservice.SQLErrText + "\r";
                }
                sErrMsg = sErrMsg + "Return code   = " + sRunResult + "\r";
                MessageBox.Show("Payment Run Failed!                    \r" 
                                + sErrMsg + "\r"
                                + "Aborting run"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //  PBY 26/04/2002 added ROLLBACK to avoid table locking problem.
                //? ROLLBACK;
                return;
            }

            //  PBY 26/04/2002 added COMMIT to avoid table locking problem.
            //COMMIT;
            if (lRunResult == 0)
            {
                MessageBox.Show("Payment run produced nothing!"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ls_RunMSG;

            //StaticVariables.gs_userid = Upper(StaticVariables.gs_userid);
            StaticVariables.LoginId = StaticVariables.LoginId.ToUpper();
            if (lRunResult > 0)
            {
                // OpenWithParm(WPaymentRunResults, SecondsAfter(tStart, System.DateTime.Now));
                StaticMessage.DoubleParm = ((TimeSpan)(System.DateTime.Now - tStart)).TotalSeconds;
                WPaymentRunResults w_payment_run_results = new WPaymentRunResults();
                StaticMessage.PowerObject = this;
                w_payment_run_results.ShowDialog();
                StaticMessage.PowerObject = w_payment_run_results;
                // TJB  RPCR_057  Dec-2013  [Drop audit triggers]
                // Disable calls to InserIntoRdsAudit and GetAkeyFromRdsAudit
//                int ll_aKey = 0;
//                if (StaticMessage.DoubleParm != -(1))
//                {
//                    ls_RunMSG = "Successful payment run for " + dEnd.ToString() + " Start time: " + tStart.ToString() + " End time: " + System.DateTime.Now.ToString();
//                    // INSERT INTO rd.rds_audit (  "a_key", "a_datetime", "a_userid", "a_contract", "a_contractor", "a_comment", "a_oldvalue", "a_newvalue" )  
//                    // VALUES  ( null,:tStart,:gs_UserID,:lcontract,:lcontractor,:ls_RunMSG,null,null )
//
//                    //  PBY 26/04/2002 added COMMIT to avoid table locking problem.
//                    //COMMIT;
//                    ODPSDataService dataservice1 = ODPSDataService.InserIntoRdsAudit(tStart, StaticVariables.LoginId, lcontract, lcontractor, ls_RunMSG);
//                }
//                else
//                {
//                    ls_RunMSG = "Unuccessful payment run for " + dEnd.ToString() + "  Reference#" + lRunResult.ToString();
//                    //INSERT INTO rd.rds_audit( "a_key", "a_datetime", "a_userid", "a_contract", "a_contractor", "a_comment", "a_oldvalue", "a_newvalue" )  
//                    // VALUES ( null, :tStart, :gs_UserID, :lcontract, :lcontractor, :ls_RunMSG , null, null );
//
//                    ODPSDataService dataservice2 = ODPSDataService.InserIntoRdsAudit(tStart, StaticVariables.LoginId, lcontract, lcontractor, ls_RunMSG);
//
//                    //select a_key into :ll_aKey from rd.rds_audit where a_datetime = :tstart and a_userid   = :gs_userID and a_contract = :lcontract and a_contractor = :lcontractor;
//                    ODPSDataService dataservice3 = ODPSDataService.GetAkeyFromRdsAudit(tStart, StaticVariables.LoginId, lcontract, lcontractor);
//                    ll_aKey = dataservice3.Ll_aKey;
//                    MessageBox.Show("Payment Run Failed! - Ref# " + Convert.ToString(lRunResult) + "\r\r"
//                                    + "rds_audit key " + Convert.ToString(ll_aKey)
//                                    , this.Text
//                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//                }
//                    MessageBox.Show("Payment Run Failed! - Ref# " + Convert.ToString(lRunResult) + "\r\r"
//                                    + "rds_audit key " + Convert.ToString(ll_aKey)
//                                    , this.Text
//                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // TJB  RPCR_057  Dec-2013  [Drop audit triggers]
                // If payment run failed: tell user (removed reference to rds_audit)
                if (StaticMessage.DoubleParm == -(1))
                {
                    MessageBox.Show("Payment Run Failed! - Ref# " + Convert.ToString(lRunResult) + "\n"
                                    , this.Text
                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public virtual void dw_results_doubleclicked(object sender, EventArgs e)
        {
            cb_open_clicked(this, null);
        }

        public virtual void pb_1_clicked(object sender, EventArgs e)
        {
            of_search();
/*
            DateTime? ldt_sdate = null;
            DateTime? ldt_edate = null;
            string ls_name;

            // TJB  RPCR_141  June-2019
            // Added nContractNo and nRgCode here and associated 
            // logic in OD_DWS_OwnerDriver_Search
            int? nContractNo;
            int? nRgCode;

            dw_search.DataObject.AcceptText();
            dw_search.DataObject.BindingSource.CurrencyManager.Refresh();

            ldt_sdate = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate;
            //ldt_edate = StaticMethods.RelativeDate(dw_search.GetItemDateTime(1, "end_date").Date, 19);
            if (dw_search.GetItem<PaymentRunPeriod>(0).EndDate != null)
                ldt_edate = ((DateTime)dw_search.GetItem<PaymentRunPeriod>(0).EndDate).AddDays(19);
            ls_name = dw_search.GetItem<PaymentRunPeriod>(0).OwnerDriver;
            // TJB  RPCR_141  June-2019:  Get rg_code and contract_no and add to parameter list
            nRgCode = dw_search.GetItem<PaymentRunPeriod>(0).RgCode;
            nContractNo = dw_search.GetItem<PaymentRunPeriod>(0).ContractNo;

            // TJB  RPCR_141  June-2019
            // If both a contract number and renewal group have been specified
            // make sure the renewal group is correct for the contract.
            if (nContractNo != null && nContractNo > 0 
                && nRgCode != null && nRgCode > 0)
            {
                ODPSDataService service = ODPSDataService.GetContractRenewalGroup(nContractNo);
                int? cRgCode = service.Number;
                if (cRgCode != nRgCode)
                {
                    dw_search.GetItem<PaymentRunPeriod>(0).RgCode = cRgCode;

                    dw_search.DataObject.AcceptText();
                    dw_search.DataObject.BindingSource.CurrencyManager.Refresh();
                }
            }

            //((DwPaymentRunContractors)dw_results.DataObject).Retrieve(ls_name, ldt_sdate, ldt_edate);
            ((DwPaymentRunContractors)dw_results.DataObject).Retrieve(ls_name, ldt_sdate, ldt_edate, nRgCode, nContractNo);
*/
        }
        #endregion

        // TJB RPCR_139 July-2019 Bugfix
        // Moved search logic from pb1_clicked to of_search
        // Enabled <Search> button and disabled <?> (PB1) button

        private void cb_search_Click(object sender, EventArgs e)
        {
            of_search();
        }

        public virtual void of_search()
        {
            DateTime? dStart = null;
            DateTime? dEnd = null;
            string ls_name;

            // TJB  RPCR_141  June-2019
            // Added nContractNo and nRgCode here and associated 
            // logic in OD_DWS_OwnerDriver_Search
            int? nContractNo;
            string sContractNo;
            int? nRgCode;
            int n;

            dw_search.DataObject.AcceptText();
            dw_search.DataObject.BindingSource.CurrencyManager.Refresh();

            dEnd = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;
            dStart = of_calcStartDate(dEnd);
            dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate = dStart;
            wf_setenddate(dEnd);

            ls_name = dw_search.GetItem<PaymentRunPeriod>(0).OwnerDriver;
            // TJB  RPCR_141  June-2019:  Get rg_code and contract_no and add to parameter list
            nRgCode = dw_search.GetItem<PaymentRunPeriod>(0).RgCode;
            sContractNo = dw_search.GetItem<PaymentRunPeriod>(0).ContractNo;
            Int32.TryParse(sContractNo, out n);
            nContractNo = (int?)n;

            // TJB  RPCR_141  June-2019
            // If both a contract number and renewal group have been specified
            // make sure the renewal group is correct for the contract.
            if (nContractNo != null && nContractNo > 0 
                && nRgCode != null && nRgCode > 0)
            {
                ODPSDataService service = ODPSDataService.GetContractRenewalGroup(nContractNo);
                int? cRgCode = service.Number;
                if (cRgCode != nRgCode)
                {
                    dw_search.GetItem<PaymentRunPeriod>(0).RgCode = cRgCode;

                    dw_search.DataObject.AcceptText();
                    dw_search.DataObject.BindingSource.CurrencyManager.Refresh();
                }
            }

            //((DwPaymentRunContractors)dw_results.DataObject).Retrieve(ls_name, ldt_sdate, ldt_edate);
            ((DwPaymentRunContractors)dw_results.DataObject).Retrieve(ls_name, dStart, dEnd, nRgCode, nContractNo);
        }
        
        // TJB  RPCR_141  June-2019
        // Added cb_clear_click and of_clear
        private void cb_clear_Click(object sender, EventArgs e)
        {
            this.of_clear();
        }

        public virtual int of_clear()
        {
            //  This function will clear the search criteria 
            //  and search results boxes
            DateTime? dStart, dEnd;

            dStart = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate;
            dEnd = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;

            dw_search.GetItem<PaymentRunPeriod>(0).ContractNo = null;
            DataUserControl dwChild;
            dwChild = dw_search.GetChild("rg_code");
            dwChild.Reset();
            dw_search.GetItem<PaymentRunPeriod>(0).RgCode = null;
            dwChild.Retrieve();
            dw_search.DataObject.BindingSource.CurrencyManager.Refresh();

            //  clear the results box
            dw_results.of_Reset();
            return 1;
        }

    }
}