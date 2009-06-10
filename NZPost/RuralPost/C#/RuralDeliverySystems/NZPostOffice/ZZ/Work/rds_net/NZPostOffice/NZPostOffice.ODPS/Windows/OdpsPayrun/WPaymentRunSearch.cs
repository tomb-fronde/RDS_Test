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
using NZPostOffice.ODPS.DataService;
using NZPostOffice.Shared;
using NZPostOffice.Shared.VisualComponents;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
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

        public override void ue_search()
        {
            //?base.ue_search();
            DateTime? ldt_sdate;
            DateTime? ldt_edate;
            string ls_name;

            ldt_sdate = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate;
            ldt_edate = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;
            ls_name = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).OwnerDriver;
            ((DwPaymentRunContractors)dw_results.DataObject).Retrieve(ls_name, ldt_sdate, ldt_edate);
        }

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

        public virtual void ue_afterchanged()
        {
            DateTime? dstart;
            DateTime? dEnd;
            string sStartMonth;
            string sStartYear;
            dEnd = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;
            //dstart = System.Convert.ToDateTime(String(Year(StaticMethods.RelativeDate(dEnd, -(28)))) + '/' + String(Month(StaticMethods.RelativeDate(dEnd, -(28)))) + "/21");
            if (dEnd == null)
                dstart = null;
            else
            {
                dstart = Convert.ToDateTime(Convert.ToString(((DateTime)(((DateTime)dEnd).AddDays(-28))).Year)
                    + "/"
                    + Convert.ToString(((DateTime)(((DateTime)dEnd).AddDays(-28))).Month) + "/21");
            }
            dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate = dstart;

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
            if (((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart == 4)
            {
                string str = ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text;
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).Text = "20" + str.Substring(3);
                ((DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart = 4;
            }

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
            int ll_aKey = 0;
            string sErrMsg;
            int t_pos1;
            int t_pos2;
            string t_contractNo = null;
            string t_contractorNo = null;
            string t_dedID = null;
            string t_ded_description = null;

            dw_search.DataObject.AcceptText();
            //  Validate contract
            if (dw_results.GetSelectedRow(0) == -1)
            {
                MessageBox.Show("You must select a contract"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //  Get contract details
            lcontract = dw_results.DataObject.GetItem<PaymentRunContractors>(dw_results.GetSelectedRow(0)).ContractNo.GetValueOrDefault();
            lcontractor = dw_results.DataObject.GetItem<PaymentRunContractors>(dw_results.GetSelectedRow(0)).ContractorNo;
            //  Get start and end dates
            dStart = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate;
            dEnd = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).EndDate;
            dEnd = System.Convert.ToDateTime(((DateTime)dEnd).Year.ToString() + '/' + ((DateTime)(dEnd)).Month.ToString() + "/20");
            wf_setenddate(dEnd);
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
            // Messagebox.Show("",string(daysafter(today(),dend)))
            //  Detect other users
            //select db_property('conncount') into  :lLoggedOnUsers from sys.dummy;
            lLoggedOnUsers = ODPSDataService.GetDbPropertyFromDummy(); ;
            if (lLoggedOnUsers > 1)
            {
                if (MessageBox.Show("Warning: There are " + Convert.ToString(lLoggedOnUsers - 1) + " other users connected. Ignore?"
                                    , this.Text
                                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) 
                   != DialogResult.Yes)
                {
                    return;
                }
            }
            //  Detect past payment runs

            //select odps.od_blf_mainrun_checkrun ( :lcontract,:lcontractor, :dstart,:dend) into :lPastRuns from sys.dummy;
            lPastRuns = ODPSDataService.GetOdBlfMainrunCheckrunFromDummy(lcontract, lcontractor, dStart, dEnd);

            if (lPastRuns > 0)
            {
                MessageBox.Show("Payment run already made for the contract(s) selected"
                                , this.Text
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Run! Call stored procedures!
            Cursor.Current = Cursors.WaitCursor;
            tStart = System.DateTime.Now;

            // select odps.od_blf_mainrun( :lcontract, :lcontractor, :dstart, :dend ) into :lRunResult from sys.dummy;

            ODPSDataService dataservice = ODPSDataService.GetOdBlfMainrunFromDummy(lcontract, lcontractor, dStart, dEnd);
            //? lRunResult = dataservice.RowCount;

            sRunResult = dataservice.DataObject;
            sRunResult = sRunResult == null ? "" : sRunResult;  //added by jlwang

            /* -------------------------------- Debugging -------------------------------- //
            MessageBox.Show("od_blf_mainrun returned " + sRunResult
                            ,"ODPS.Windows.OdpsPayrun.wPaymentRunSearch.cb_open_clicked");
            /* --------------------------------------------------------------------------- */

            //  TJB  SR4649  Dec 2004
            //  Changed return value to string to return error information from OD_BLF_Mainrun_PostTaxAdj
            //  Caught and parsed by Powerbuilder Payrun code  ( w_payrun_search)
            //  When there's an error, the string is a comma-separated list of values:
            //       <return code>, <contractor no>, <deduction ID>, <deduction description>
            //  otherwise its just a single value  ( the return code).

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
                if (StaticMessage.DoubleParm != -(1))
                {
                    ls_RunMSG = "Successful payment run for " + dEnd.ToString() + " Start time: " + tStart.ToString() + " End time: " + System.DateTime.Now.ToString();
                    // INSERT INTO rd.rds_audit (  "a_key", "a_datetime", "a_userid", "a_contract", "a_contractor", "a_comment", "a_oldvalue", "a_newvalue" )  
                    // VALUES  ( null,:tStart,:gs_UserID,:lcontract,:lcontractor,:ls_RunMSG,null,null )  ;

                    //  PBY 26/04/2002 added COMMIT to avoid table locking problem.
                    //COMMIT;
                    ODPSDataService dataservice1 = ODPSDataService.InserIntoRdsAudit(tStart, StaticVariables.LoginId, lcontract, lcontractor, ls_RunMSG);
                }
                else
                {
                    ls_RunMSG = "Unuccessful payment run for " + dEnd.ToString() + "  Reference#" + lRunResult.ToString();
                    //INSERT INTO rd.rds_audit( "a_key", "a_datetime", "a_userid", "a_contract", "a_contractor", "a_comment", "a_oldvalue", "a_newvalue" )  
                    // VALUES ( null, :tStart, :gs_UserID, :lcontract, :lcontractor, :ls_RunMSG , null, null );

                    //  PBY 26/04/2002 added COMMIT to avoid table locking problem.
                    //COMMIT;

                    ODPSDataService dataservice2 = ODPSDataService.InserIntoRdsAudit(tStart, StaticVariables.LoginId, lcontract, lcontractor, ls_RunMSG);

                    //select a_key into :ll_aKey from rd.rds_audit where a_datetime = :tstart and a_userid   = :gs_userID and a_contract = :lcontract and a_contractor = :lcontractor;
                    ODPSDataService dataservice3 = ODPSDataService.GetAkeyFromRdsAudit(tStart, StaticVariables.LoginId, lcontract, lcontractor);
                    ll_aKey = dataservice3.Ll_aKey;
                    // 	messagebox ( parent.title,"Payment Run Failed! - Ref#"+lRunResult).ToString()
                    // MessageBox(parent.Title, "Payment Run Failed!  - Ref# " + String(lRunResult) + "\r~rrds_audit key " + String(ll_aKey), exclamation!, ok!, 1);
                    MessageBox.Show("Payment Run Failed!  - Ref# " + Convert.ToString(lRunResult) + "\r\r"
                                    + "rds_audit key " + Convert.ToString(ll_aKey)
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
            DateTime? ldt_sdate = null;
            DateTime? ldt_edate = null;
            string ls_name;
            dw_search.DataObject.AcceptText();
            ldt_sdate = dw_search.DataObject.GetItem<PaymentRunPeriod>(0).StartDate;
            //ldt_edate = StaticMethods.RelativeDate(dw_search.GetItemDateTime(1, "end_date").Date, 19);
            if (dw_search.GetItem<PaymentRunPeriod>(0).EndDate != null)
                ldt_edate = ((DateTime)dw_search.GetItem<PaymentRunPeriod>(0).EndDate).AddDays(19);
            ls_name = dw_search.GetItem<PaymentRunPeriod>(0).OwnerDriver;
            ((DwPaymentRunContractors)dw_results.DataObject).Retrieve(ls_name, ldt_sdate, ldt_edate);
        }
        #endregion
    }
}