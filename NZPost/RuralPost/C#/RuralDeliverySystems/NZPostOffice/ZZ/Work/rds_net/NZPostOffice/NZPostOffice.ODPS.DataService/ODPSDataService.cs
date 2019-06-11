using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.DataService
{
    // TJB  RPCR_140  June-2019
    // GetOdBlfMainrun and _GetOdBlfMainrun: New 
    // - copied from GetOdBlfMainrunFromDummy with RgCode parameter added
    // ValidateContract and _ValidateContract: new
    // GetRgDescription and _GetRgDescription: new
    //
    // TJB  RPCR_098  Jan-2016
    // Created InsertPTDs()
    //
    // TJB  RPCR_094  Mar-2015
    // Changed 'Telecom' to 'Mobile Phone' and 'Shell' to 'Fuel Card' 
    // in ded_description and ded_reference in InsertTelecomPostTaxDeductions
    // and InsertShellPostTaxAdjustments
    // Changed InsertPostTaxDeductions to InsertTelecomPostTaxDeductions
    // and InsertPostTaxAdjustments to InsertShellPostTaxAdjustments
    // Added Billdate parameter to InsertShellPostTaxAdjustments
    // Changed SelectTShellImport to CountTShellImport
    // Change SelectTelecomImport to CountTelecomImport
    //
    // TJB  RPCR_057  Dec-2013  [Drop audit triggers]
    // Disable InserIntoRdsAudit and GetAkeyFromRdsAudit
    //
    // TJB  23-Oct-2013  AP Export File Reformat
    // New: [_]GetMaxBatchNo
    // New: [_]UpdatePaymentBatchNo
    //
    // TJB  RPCR_054 June-2013
    // Add optional ExportFlag to [_]GetODRPFInvoicePayPiecerateDetail
    //
    // TJB  RPCR_056  June-2013
    // New: [_]GetODDWSInvoiceAllowanceDetail
    //
    // TJB RPCR_020 Sept-2010
    // Added 'Contract <no>' to ded_reference

    [Serializable()]
    public class ODPSDataService : CommandEntity<ODPSDataService>
    {
        #region Factory Methods
        public bool ret = false;

        private string dataObject;
        public string DataObject
        {
            get 
            { 
                return dataObject; 
            }
        }

        private int _sqlcode = -1;
        public int SQLCode
        {
            get
            {
                return _sqlcode;
            }
        }

        private int _sqldbcode = -1;
        public int SQLDBCode
        {
            get
            {
                return _sqldbcode;
            }
        }

        private string _sqlerrtext = "";
        public string SQLErrText
        {
            get
            {
                return _sqlerrtext;
            }
        }

        private int _rowCount = 0;
        public int RowCount
        {
            get 
            { 
                return _rowCount; 
            }

        }

        private int _count = 0;
        public int Count
        {
            get 
            { 
                return _count; 
            }
        }

        private int _batch_no = 0;
        public int BatchNo
        {
            get
            {
                return _batch_no;
            }
        }

        private DateTime ld_invoice_date;
        public DateTime LdInvoiceDate
        {
            get
            {
                return ld_invoice_date;
            }
        }

        private int lreturn;
        public int LReturn
        {
            get
            {
                return lreturn;
            }
        }

        private int lAcceptResults;
        public int LAcceptResults
        {
            get
            {
                return lAcceptResults;
            }
        }
        private int ll_aKey;
        public int Ll_aKey
        {
            get
            {
                return ll_aKey;
            }
        }

        private int li_imported;
        public int LiImported
        {
            get
            {
                return li_imported;
            }
        }

        private decimal dc_hashtotal;
        public decimal DcHashtotal
        {
            get
            {
                return dc_hashtotal;
            }
        }

        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
        }

        public ShellImport shellImport;
        public TelecomImport telecomImport;
        public PostTaxDeductions postTaxDeductions;
        public ContractType contractType;
        public RdsUserId rdsUserId;
        public UsedPassword usedPassword;

        //  TJB  RPCR_098  Jan-2016: NEW
        //  Load PTDs using insertPTDs stored procedure
        /// <summary>
        /// [execute] rd.insert_PTDs contract_no, amount, description, reference
        /// </summary>
        public static ODPSDataService InsertPTDs(int contract_no, decimal amount, string description, string reference )
        {
            ODPSDataService obj = Execute("_InsertPTDs", contract_no, amount, description, reference);
            return obj;
        }

        public static ODPSDataService NewPots(string ls_name, string ls_ird, int ll_contract_no, string ls_vendor, int ll_supplier, Decimal ld_gross, Decimal ld_tax, Decimal ld_gst, Decimal ld_net, int ll_invoice_no, DateTime ld_input_date)
        {
            ODPSDataService obj = Execute("_NewPots", ls_name, ls_ird, ll_contract_no, ls_vendor, ll_supplier, ld_gross, ld_tax, ld_gst, ld_net, ll_invoice_no, ld_input_date);
            return obj;
        }

        /// <summary>
        /// select up_password into :OldPass 
        ///   from rd.used_password 
        ///  where up_code = :u_usercode 
        ///    and up_password = :sNewPassword 
        /// </summary>
        public static String SelectUpPassword(string up_code, string up_password)
        {
            ODPSDataService obj = Execute("_SelectUpPassword", up_code, up_password);
            return obj.dataObject;
        }

        public static ODPSDataService GetCountFromTPosttaxDeductionsNotApplied()
        {
            ODPSDataService obj = Execute("_GetCountFromTPosttaxDeductionsNotApplied");
            return obj;
        }

        /// <summary>
        /// insert into rd.used_password(up_code,up_password) 
        /// values(:g_security.u_usercode,:sOldPassword)
        /// </summary>
        public static int InsertUpPassword(string up_code, string up_password)
        {
            ODPSDataService obj = Execute("_InsertUpPassword", up_code, up_password);
            return obj._sqlcode;
        }

        ///<summary>
        ///delete from odps.t_shell_import
        ///</summary>
        public static int DeleteTShellImport()
        {
            ODPSDataService obj = Execute("_DeleteTShellImport");
            return obj._sqlcode;
        }

        /// <summary>
        /// insert into odps.t_shell_import (contract_no,contractor,total_deduction) 
        /// values (:ls_contract_no,:ls_contractor,:dc_total_deduction)
        /// </summary>
        public static ODPSDataService InsertTShellImport(string ls_contract_no, string ls_contractor, Decimal? dc_total_deduction)
        {
            ODPSDataService obj = Execute("_InsertTShellImport", ls_contract_no, ls_contractor, dc_total_deduction);
            return obj;
        }

        // TJB  RPCR_094  Mar-2015
        // Changed name from SelectTShellImport to CountTShellImport
        //
        /// <summary>
        /// select count(distinct(contract_no)), sum(total_deduction) 
        ///   into :ls_total_contracts, :ls_import_total 
        ///   from odps.t_shell_import
        /// </summary>
        public static ODPSDataService CountTShellImport()
        {
            ODPSDataService obj = Execute("_CountTShellImport");
            return obj;
        }

        // TJB  RPCR_094  Mar-2015
        // Changed InsertPostTaxAdjustments to InsertShellPostTaxAdjustments
        // Added Billdate parameter
        /// <summary>
        /// insert shell data into post_tax_adjustments
        /// </summary>
        public static ODPSDataService InsertShellPostTaxAdjustments(string sBilldate)
        {
            ODPSDataService obj = Execute("_InsertShellPostTaxAdjustments", sBilldate);
            return obj;
        }

        /// <summary>
        /// select max(invoice_date) from odps.payment
        /// </summary>
        public static ODPSDataService GetMaxPayment()
        {
            ODPSDataService obj = Execute("_GetMaxPayment");
            return obj;
        }

        // TJB 23-Oct-2013  AP Export File Reformat: New
        /// <summary>
        /// select max(isnull(batch_no,0)) from odps.payment
        /// </summary>
        public static ODPSDataService GetMaxBatchNo()
        {
            ODPSDataService obj = Execute("_GetMaxBatchNo");
            return obj;
        }

        // TJB 23-Oct-2013  AP Export File Reformat: New
        /// <summary>
        /// update odps.payment set batch_no = BatchNo where invoice_date = InvoiceDate
        /// </summary>
        public static ODPSDataService UpdatePaymentBatchNo(int BatchNo, DateTime InvoiceDate)
        {
            ODPSDataService obj = Execute("_UpdatePaymentBatchNo", BatchNo, InvoiceDate);
            return obj;
        }

        //  TJB  RPCR_054 June-2013
        //  Add optional ExportFlag
        /// <summary>
        /// select odps.OD_RPF_Invoice_pay_piecerate_detail(:alcontractor,:alcontract,:edate,:alregion,:li_ctKey) 
        ///   into :lreturn from sys.dummy
        /// </summary>
        public static ODPSDataService GetODRPFInvoicePayPiecerateDetail(int? alcontractor, DateTime? edate, int? alcontract, int? alregion, string sname, int? li_ctKey)
        {
            ODPSDataService obj = Execute("_GetODRPFInvoicePayPiecerateDetail", alcontractor, edate, alcontract, alregion, sname, li_ctKey, 0);
            return obj;
        }

        public static ODPSDataService GetODRPFInvoicePayPiecerateDetail(int? alcontractor, DateTime? edate, int? alcontract, int? alregion, string sname, int? li_ctKey, int? nExportFlag)
        {
            ODPSDataService obj = Execute("_GetODRPFInvoicePayPiecerateDetail", alcontractor, edate, alcontract, alregion, sname, li_ctKey, nExportFlag);
            return obj;
        }

        // TJB  RPCR_056  Jun-2018: New
        /// <summary>
        /// Populate the t_invoice_allowances table for generated invoices (REDInvoiceDetailAllowances)
        /// Called from WInvoiceSearch
        /// </summary>
        public static ODPSDataService GetODDWSInvoiceAllowanceDetail(int? alcontractor, int? alcontract, DateTime? edate, int? alregion, int? li_ctKey)
        {
            ODPSDataService obj = Execute("_GetODDWSInvoiceAllowanceDetail", alcontractor, alcontract, edate, alregion, li_ctKey);
            return obj;
        }

        /// <summary>
        /// select count(*) into :li_exists 
        ///   from rd.contractor_renewals 
        ///  where contractor_supplier_no = :ll_supplier 
        ///    and contract_no = :ll_contract
        /// </summary>
        public static ODPSDataService SelectCountContractorRenewals(int ll_supplier, int ll_contract)
        {
            ODPSDataService obj = Execute("_SelectCountContractorRenewals", ll_supplier,ll_contract );
            return obj;
        }

        /// <summary>
        /// SELECT string(today()) INTO :ls_today FROM dummy
        /// </summary>
        public static ODPSDataService SelectDateDummy()
        {
            ODPSDataService obj = Execute("_SelectDateDummy");
            return obj;
        }
        // TJB  RPCR_094  Mar-2015
        // Changed name from InsertPostTaxDeductions to InsertTelecomPostTaxDeductions

        /// <summary>
        /// INSERT INTO odps.post_tax_deductions (ded_id,ded_description,ded_priority,...
        /// </summary>
        public static ODPSDataService InsertTelecomPostTaxDeductions(string ls_today)
        {
            ODPSDataService obj = Execute("_InsertTelecomPostTaxDeductions", ls_today);
            return obj;
        }

        /// <summary>
        /// SELECT count(*), sum(ded_fixed_amount) 
        ///   INTO :li_imported, :dc_hashtotal 
        ///   FROM odps.post_tax_deductions 
        ///  WHERE ded_reference like :ls_select
        /// </summary>
        public static ODPSDataService SelectPostTaxDeductions(string ls_select1, string ls_select2)
        {
            ODPSDataService obj = Execute("_SelectPostTaxDeductions", ls_select1, ls_select2);
            return obj;
        }

        /// <summary>
        /// select count(*) into :ll_import 
        ///   from odps.post_tax_deductions 
        ///  where ded_description like :ls_temp
        /// </summary>
        public static ODPSDataService SelectPostTaxDeductions2(string ls_temp1, string ls_temp2)
        {
            ODPSDataService obj = Execute("_SelectPostTaxDeductions2", ls_temp1, ls_temp2);
            return obj;
        }

        /// <summary>
        /// delete from odps.t_telecom_import
        /// </summary>
        public static ODPSDataService DeleteTelecomImport()
        {
            ODPSDataService obj = Execute("_DeleteTelecomImport");
            return obj;
        }

        [ServerMethod]
        private void _DeleteTelecomImport()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "delete from odps.t_telecom_import";

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, null);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }





        /// <summary>
        /// insert into odps.t_telecom_import (bill_month, bill_cycle, customer_no, account_no, account_name, open_bal, payments, adj_tran, bal_bf, curr_chg, total_due, supplier_no, contract_no) 
        /// values (:ls_bill_month, :li_bill_cycle, :ll_customer_no, :ll_account_no, :ls_account_name, :dc_open_bal, :dc_payments, :dc_adj_tran, :dc_bal_bf, :dc_curr_chg, :dc_total_due, :il_supplier, :il_contract)
        /// </summary>
        public static ODPSDataService InsertTelecomImport(
            string ls_bill_month, 
            int? li_bill_cycle,
            int? ll_customer_no, 
            int? ll_account_no,
            string ls_account_name,
            decimal? dc_open_bal,
            decimal? dc_payments, 
            decimal? dc_adj_tran, 
            decimal? dc_bal_bf, 
            decimal? dc_curr_chg, 
            decimal? dc_total_due, 
            int il_supplier,
            int il_contract)
        {
            ODPSDataService obj = Execute("_InsertTelecomImport",
                ls_bill_month, 
                li_bill_cycle, 
                ll_customer_no, 
                ll_account_no, 
                ls_account_name,
                dc_open_bal, 
                dc_payments, 
                dc_adj_tran, 
                dc_bal_bf, 
                dc_curr_chg, 
                dc_total_due, 
                il_supplier, 
                il_contract);
            return obj;
        }

        // TJB  RPCR_094  Mar-2015
        // Change name from SelectTelecomImport to CountTelecomImport
        //
        /// <summary>
        /// select count(*), sum(curr_chg) 
        ///   into :ll_rowcount, :dc_hashtotal 
        /// from odps.t_telecom_import
        /// </summary>
        public static ODPSDataService CountTelecomImport()
        {
            ODPSDataService obj = Execute("_CountTelecomImport");
            return obj;
        }

        public static int GetDbPropertyFromDummy()
        {
            ODPSDataService obj = Execute("_GetDbPropertyFromDummy");
            return obj._rowCount;
        }

        public static int GetOdBlfMainrunCheckrunFromDummy(int? lcontract, int? lcontractor, DateTime? dstart, DateTime? dend)
        {
            ODPSDataService obj = Execute("_GetOdBlfMainrunCheckrunFromDummy", lcontract, lcontractor, dstart, dend);
            return obj._rowCount;
        }

        // TJB  RPCR_140 June-2019: New
        // Copied from GetOdBlfMainrunFromDummy
        // Added nRgCode to stored proc call (and simplified the name)
        public static ODPSDataService GetOdBlfMainrun(int? lcontract, int? lcontractor, DateTime? dstart, DateTime? dend, int? nRgCode)
        {
            ODPSDataService obj = Execute("_GetOdBlfMainrun", lcontract, lcontractor, dstart, dend, nRgCode);
            return obj;
        }

        public static ODPSDataService GetOdBlfMainrunFromDummy(int? lcontract, int? lcontractor, DateTime? dstart, DateTime? dend)
        {
            ODPSDataService obj = Execute("_GetOdBlfMainrunFromDummy", lcontract, lcontractor, dstart, dend);
            return obj;
        }

        public static ODPSDataService GetOdBlfMainrunAcceptFromDummy(DateTime? id_Enddate)
        {
            ODPSDataService obj = Execute("_GetOdBlfMainrunAcceptFromDummy", id_Enddate);
            return obj;
        }

        public static ODPSDataService DeleteFromTPosttaxDeductionsNotApplied()
        {
            ODPSDataService obj = Execute("_DeleteFromTPosttaxDeductionsNotApplied");
            return obj;
        }

        // TJB  RPCR_057  Dec-2013  [Drop audit triggers]
        // Disable InserIntoRdsAudit and GetAkeyFromRdsAudit
        //
//        public static ODPSDataService InserIntoRdsAudit(DateTime? tStart, String gs_UserID, int? lcontract, int? lcontractor, string ls_RunMSG)
//        {
//            ODPSDataService obj = Execute("_InserIntoRdsAudit", tStart, gs_UserID, lcontract, lcontractor, ls_RunMSG);
//            return obj;
//        }
//
//        public static ODPSDataService GetAkeyFromRdsAudit(DateTime? tStart, String gs_UserID, int? lcontract, int? lcontractor)
//        {
//            ODPSDataService obj = Execute("_GetAkeyFromRdsAudit", tStart, gs_UserID, lcontract, lcontractor);
//            return obj;
//        }

        // TJB  RPCR_140  June-2019
        // Validate the contract number
        /// Validate the contract number
        public static ODPSDataService ValidateContract(int? nContractNo)
        {
            ODPSDataService obj = Execute("_ValidateContract", nContractNo);
            return obj;
        }

        // TJB  RPCR_140  June-2019
        // Look up the renewal group description
        public static ODPSDataService GetRgDescription(int? nRgCode)
        {
            ODPSDataService obj = Execute("_GetRgDescription", nRgCode);
            return obj;
        }

        /// <summary>
        /// select count(*) into :li_contract_types from rd.contract_type
        /// </summary>
        public static ODPSDataService SelectContractType()
        {
            ODPSDataService obj = Execute("_SelectContractType");
            return obj;
        }

        /// <summary>
        /// select contract_type  from rd.contract_type where ct_key = :li_ct_key
        /// </summary>
        public static ODPSDataService SelectContractType2(Int32 ct_key)
        {
            ODPSDataService obj = Execute("_SelectContractType2", ct_key);
            return obj;
        }

        /// <summary>
        /// SELECT	ui_id0 INTO	:ll_ui_id 
        ///   FROM rd.rds_user_id 
        ///  WHERE ui_userid = :ls_ui_userid
        /// </summary>
        public static ODPSDataService SelectRdsUserId(String ui_userid)
        {
            ODPSDataService obj = Execute("_SelectRdsUserId", ui_userid);
            return obj;
        }

        /// <summary>
        /// SELECT up_password INTO :OldPass 
        ///   FROM rd.used_password 
        ///  WHERE ui_id = :ll_ui_id 
        ///    AND up_password = :sNewPassword
        /// </summary>
        public static ODPSDataService SelectUsedPassword(Int32 ui_id, String up_password)
        {
            ODPSDataService obj = Execute("_SelectUsedPassword", ui_id, up_password);
            return obj;
        }

        /// <summary>
        /// UPDATE rd.rds_user_id 
        ///    SET ui_password = :sNewPassword
        ///      , ui_password_expiry = :dExpiry
        ///      , ui_grace_logins = 4 
        ///  WHERE ui_userid = :ls_ui_userid
        /// </summary>
        public static ODPSDataService UpdateRdsUserId(String ui_password, DateTime ui_password_expiry, String ui_userid)
        {
            ODPSDataService obj = Execute("_UpdateRdsUserId", ui_password, ui_password_expiry, ui_userid);
            return obj;
        }

        /// <summary>
        /// INSERT INTO	rd.used_password (ui_id,up_password) 
        /// VALUES (:ll_ui_id, :sOldPassword)
        /// </summary>
        public static ODPSDataService InserIntoUsedPassword(Int32 ui_id, String up_password)
        {
            ODPSDataService obj = Execute("_InserIntoUsedPassword", ui_id, up_password);
            return obj;
        }
        #endregion

        #region Server-side Code

        // TJB  RPCR_098  Jan-2016: NEW
        
        [ServerMethod]
        private void _InsertPTDs(int contract_no, decimal amount, string description, string reference )
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.insert_PTDs";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "con_no", contract_no);
                    pList.Add(cm, "amount", amount);
                    pList.Add(cm, "in_description", description);
                    pList.Add(cm, "in_reference", reference);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                lreturn = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                               //_sqlcode = 100;
                                lreturn = 1;
                                _sqlcode = 0;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }


        [ServerMethod]
        private void _NewPots(string ls_name, string ls_ird, int ll_contract_no, string ls_vendor, int ll_supplier, Decimal ld_gross, Decimal ld_tax, Decimal ld_gst, Decimal ld_net, int ll_invoice_no, DateTime ld_input_date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = cm.CommandText = "odps.new_pots";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "name", ls_name);
                    pList.Add(cm, "ird_no", ls_ird);
                    pList.Add(cm, "con_no", ll_contract_no);
                    pList.Add(cm, "vendor_id", ls_vendor);
                    pList.Add(cm, "supplier_no", ll_supplier);
                    pList.Add(cm, "gross", ld_gross);
                    pList.Add(cm, "tax", ld_tax);
                    pList.Add(cm, "gst", ld_gst);
                    pList.Add(cm, "net", ld_net);
                    pList.Add(cm, "invoice_number", ll_invoice_no);
                    pList.Add(cm, "input_date", ld_input_date);
                    _sqlcode = -1;
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            ret = true;
                            if (dr.Read())
                            {

                                _sqlcode = 0;
                            }
                            else
                                _sqlcode = 100;
                        }
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectUpPassword(string up_code, string up_password)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string upPassword = "";

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select up_password from rd.used_password "
                                   + " where up_code = :u_usercode " 
                                   + "   and up_password = :sNewPassword ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "u_usercode", up_code);
                    pList.Add(cm, "sNewPassword", up_password);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                upPassword = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    dataObject = upPassword;
                }
            }
        }

        [ServerMethod]
        private void _InsertUpPassword(string up_code, string up_password)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into rd.used_password (up_code,up_password) "
                                   + "values (:u_usercode,:sOldPassword) ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "u_usercode", up_code);
                    pList.Add(cm, "sOldPassword", up_password);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteTShellImport()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "delete from odps.t_shell_import";

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, null);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertTShellImport(string ls_contract_no, string ls_contractor, Decimal? dc_total_deduction)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into odps.t_shell_import " 
                                     + "   (contract_no, contractor, total_deduction) " 
                                     + " values" 
                                     + "   (:ls_contract_no, :ls_contractor, :dc_total_deduction)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_contract_no", ls_contract_no);
                    pList.Add(cm, "ls_contractor", ls_contractor);
                    pList.Add(cm, "dc_total_deduction", dc_total_deduction);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _CountTShellImport()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    shellImport = new ShellImport();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(distinct(contract_no)), sum(total_deduction) " +
                        " from odps.t_shell_import";
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                        {
                            if (dr.Read())
                            {
                                shellImport._contract_no = dr.GetInt32(0).ToString();
                                shellImport._total_deduction = dr.GetDecimal(1);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        // TJB  RPCR_094  Mar-2015
        // Changed InsertShellPostTaxAdjustments to InsertShellPostTaxAdjustments
        // Added Billdate parameter
        [ServerMethod]
        private void _InsertShellPostTaxAdjustments(string sBilldate)
        {
            // TJB  RPCR_094  Mar-2015
            // Changed 'Shell' to 'Fuel Card' in ded_description and ded_reference
            //
            // TJB RPCR_020 Sept-2010
            // Added 'Contract <no>' to ded_reference

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string cmdText =
                    " INSERT INTO odps.post_tax_deductions  " +
                    " (" +
                       " ded_description," +
                       " ded_priority," +
                       " pct_id," +
                       " ded_reference," +
                       " ded_type_period," +
                       " ded_percent_gross," +
                       " ded_percent_net," +
                       " ded_percent_start_balance," +
                       " ded_fixed_amount," +
                       " ded_min_threshold_gross," +
                       " ded_max_threshold_net_pct," +
                       " ded_default_minimum," +
                       " ded_start_balance," +
                       " ded_end_balance," +
                       " contractor_supplier_no," +
                       " ded_pay_highest_value)" +
                    " select " +
                       " 'Fuel Card Deduction Month " + sBilldate + "'," + // convert (varchar,Month(getdate()-30))," +
                       " 1," +
                       " 6," +
                       " 'Fuel Card Deduction Contract '+cast(contract_no as varchar)+' imported on ' + convert(varchar(10),getdate(),20)," +
                       " 'M'," +
                       " null," +
                       " null," +
                       " null," +
                       " sum(total_deduction), " +
                       " null," +
                       " null," +
                       " sum(total_deduction)," +
                       " sum(total_deduction)," +
                       " sum(total_deduction)," +
                       " (SELECT rd.contractor_renewals.contractor_supplier_no" +
                          " FROM rd.contract," +
                               " rd.contract_renewals," +
                               " rd.contractor_renewals " +
                         " WHERE rd.contract_renewals.contract_no = rd.contract.contract_no and" +
                               " rd.contract.con_active_sequence = rd.contract_renewals.contract_seq_number and" +
                               " rd.contractor_renewals.contract_no = rd.contract_renewals.contract_no and" +
                               " rd.contractor_renewals.contract_seq_number = rd.contract_renewals.contract_seq_number and" +
                               " rd.contractor_renewals.cr_effective_date =" +
                                      " (select max(cr_effective_date)" +
                                         " from rd.contractor_renewals cr" +
                                        " where cr.contract_no = contract_renewals.contract_no" +
                                          " and cr.contract_seq_number = contract_renewals.contract_seq_number" +
                                          " and cr_effective_date <= getdate()) and" +
                               " rd.contract.contract_no = t_shell_import.contract_no) as contractor," +
                       " 0" +
                    " from odps.t_shell_import" +
                    " group by contract_no, contractor";

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = cmdText;

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, null);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetMaxPayment()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    shellImport = new ShellImport();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select max(invoice_date) from odps.payment";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                        {
                            if (dr.Read())
                            {
                                ld_invoice_date = dr.GetDateTime(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        // TJB 23-Oct-2013  AP Export File Reformat: New
        [ServerMethod]
        private void _GetMaxBatchNo()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    shellImport = new ShellImport();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select max(isnull(batch_no,0)) from odps.payment";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                        {
                            if (dr.Read())
                            {
                                _batch_no = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _batch_no = 0;
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        // TJB 31-Oct-2013  AP Export File Reformat: New
        [ServerMethod]
        private void _UpdatePaymentBatchNo(int BatchNo, DateTime InvoiceDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "update odps.payment "
                                   + "   set batch_no = :batch_no "
                                   + " where invoice_date = :invoice_date ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "batch_no", BatchNo);
                    pList.Add(cm, "invoice_date", InvoiceDate);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        // TJB  RPCR_054  June-2013
        // Added nExportFlag
        //   = 0   OD_RPF_Invoice_pay_piecerate_detail behaves normally
        //              t_invoice_piecerates, t_invoice_piecerates2 populated for invoice
        //   = 1   OD_RPF_Invoice_pay_piecerate_detail modified
        //              t_invoice_piecerates (only) populated for export file

        [ServerMethod]
        private void _GetODRPFInvoicePayPiecerateDetail(int? alcontractor, DateTime? edate, int? alcontract, int? alregion, string sname, int? li_ctKey, int? nExportFlag)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    // TJB  RPCR_054  July-2013
                    // Set the timeout longer if getting data for many contracts
                    cm.CommandTimeout = (alcontract == null || alcontract == 0) ? 20 : 300;

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.OD_RPF_Invoice_pay_piecerate_detail ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContractor", alcontractor);
                    pList.Add(cm, "inDate", edate);
                    pList.Add(cm, "inContract", alcontract);
                    pList.Add(cm, "inRegion", alregion);
                    pList.Add(cm, "inCname", sname);
                    pList.Add(cm, "inCtKey", li_ctKey);
                    pList.Add(cm, "inExportFlag", nExportFlag);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                lreturn = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        // TJB  RPCR_056  Jun-2018: New
        // Populate the t_invoice_allowances table for generated invoices (REDInvoiceDetailAllowances)
        [ServerMethod]
        private void _GetODDWSInvoiceAllowanceDetail(int? alcontractor, int? alcontract, DateTime? edate, int? alregion, int? li_ctKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.OD_DWS_Invoice_Allowance_Detail ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContractorNo", alcontractor);
                    pList.Add(cm, "inContractNo", alcontract);
                    pList.Add(cm, "inEdate", edate);
                    pList.Add(cm, "inRegion", alregion);
                    pList.Add(cm, "inCtKey", li_ctKey);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                lreturn = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectCountContractorRenewals(int ll_supplier, int ll_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(*) from rd.contractor_renewals " 
                                   + " where contractor_supplier_no = :ll_supplier " 
                                   + "   and contract_no = :ll_contract";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_supplier", ll_supplier);
                    pList.Add(cm, "ll_contract", ll_contract);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _rowCount = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectDateDummy()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string date = "";

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT  rd.today()";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                        {
                            if (dr.Read())
                            {
                                date = dr.GetDateTime(0).ToShortDateString();
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    dataObject = date;
                }
            }
        }

        // TJB  RPCR_094  Mar-2015
        // Changed 'Telecom' to 'Mobile Phone' in ded_description and ded_reference

        [ServerMethod]
        private void _InsertTelecomPostTaxDeductions(string ls_today)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string sql = " INSERT INTO odps.post_tax_deductions "
                                    + "(ded_description,"
                                    + " ded_priority,"
                                    + " pct_id,"
                                    + " ded_reference,"
                                    + " ded_type_period,"
                                    + " ded_percent_gross,"
                                    + " ded_percent_net,"
                                    + " ded_percent_start_balance,"
                                    + " ded_fixed_amount,"
                                    + " ded_min_threshold_gross,"
                                    + " ded_max_threshold_net_pct,"
                                    + " ded_default_minimum,"
                                    + " ded_start_balance,"
                                    + " ded_end_balance,"
                                    + " contractor_supplier_no,"
                                    + " ded_pay_highest_value)"
                               + " SELECT"
                                    + " 'Mobile Phone Deduction Month '+bill_month,"
                                    + " 1,"
                                    + " 6,"
                                    + " 'Mobile Phone Deduction Contract '+cast(contract_no as varchar)+' imported on '+:ls_today,"
                                    + " 'M',"
                                    + " null,"
                                    + " null,"
                                    + " null,"
                                    + " sum(curr_chg),"
                                    + " null,"
                                    + " null,"
                                    + " sum(curr_chg),"
                                    + " sum(curr_chg),"
                                    + " sum(curr_chg),"
                                    + " supplier_no,"
                                    + " 0"
                               + " FROM odps.t_telecom_import"
                               + " GROUP BY bill_month, contract_no, supplier_no";

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = sql;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_today", ls_today);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectPostTaxDeductions(string ls_select1, string ls_select2)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    postTaxDeductions = new PostTaxDeductions();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT count(*), sum(ded_fixed_amount)" 
                                   + "  FROM odps.post_tax_deductions " 
                                   + " WHERE ded_reference like :ls_select1"
                                   + "    or ded_reference like :ls_select2";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_select1", ls_select1);
                    pList.Add(cm, "ls_select2", ls_select2);
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                li_imported = dr.GetInt32(0);
                                dc_hashtotal = dr.GetDecimal(1);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectPostTaxDeductions2(string ls_temp1, string ls_temp2)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(*) from odps.post_tax_deductions "
                                   + " where ded_description like :ls_temp1"
                                   + "    or ded_description like :ls_temp2";

                    try
                    {
                        ParameterCollection pList = new ParameterCollection();
                        pList.Add(cm, "ls_temp1", ls_temp1);
                        pList.Add(cm, "ls_temp2", ls_temp2);

                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                _rowCount = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _DeleteTTelecomImport()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "delete from odps.t_telecom_import";

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, null);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _InsertTelecomImport(
            string ls_bill_month,
            int? li_bill_cycle,
            int? ll_customer_no, 
            int? ll_account_no, 
            string ls_account_name,
            decimal? dc_open_bal,
            decimal? dc_payments, 
            decimal? dc_adj_tran,
            decimal? dc_bal_bf,
            decimal? dc_curr_chg,
            decimal? dc_total_due,
            int il_supplier, 
            int il_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into odps.t_telecom_import( " +
                        " bill_month, " +
                        " bill_cycle, " +
                        " customer_no, " +
                        " account_no, " +
                        " account_name, " +
                        " open_bal, " +
                        " payments, " +
                        " adj_tran, " +
                        " bal_bf, " +
                        " curr_chg, " +
                        " total_due, " +
                        " supplier_no, " +
                        " contract_no ) " +
                        " values ( " +
                        " :ls_bill_month, " +
                        " :li_bill_cycle, " +
                        " :ll_customer_no, " +
                        " :ll_account_no, " +
                        " :ls_account_name, " +
                        " :dc_open_bal, " +
                        " :dc_payments, " +
                        " :dc_adj_tran, " +
                        " :dc_bal_bf, " +
                        " :dc_curr_chg, " +
                        " :dc_total_due, " +
                        " :il_supplier, " +
                        " :il_contract )";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_bill_month", ls_bill_month);
                    pList.Add(cm, "li_bill_cycle", li_bill_cycle);
                    pList.Add(cm, "ll_customer_no", ll_customer_no);
                    pList.Add(cm, "ll_account_no", ll_account_no);
                    pList.Add(cm, "ls_account_name", ls_account_name.Length >= 16 ? ls_account_name.Substring(0, 16) : ls_account_name);
                    pList.Add(cm, "dc_open_bal", dc_open_bal);
                    pList.Add(cm, "dc_payments", dc_payments);
                    pList.Add(cm, "dc_adj_tran", dc_adj_tran);
                    pList.Add(cm, "dc_bal_bf", dc_bal_bf);
                    pList.Add(cm, "dc_curr_chg", dc_curr_chg);
                    pList.Add(cm, "dc_total_due", dc_total_due);
                    pList.Add(cm, "il_supplier", il_supplier);
                    pList.Add(cm, "il_contract", il_contract);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        [ServerMethod]
        private void _CountTelecomImport()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    telecomImport = new TelecomImport();

                    cm.CommandType = CommandType.Text;
                    //?  cm.CommandText = "select count( distinct(contract_no)), sum(total_deduction) from odps.t_shell_import";
                    cm.CommandText = "select count(*), sum(curr_chg) " 
                                     + "from odps.t_telecom_import";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                        {
                            if (dr.Read())
                            {
                                telecomImport.ll_rowcount = dr.GetInt32(0);
                                telecomImport.dc_hashtotal = dr.GetDecimal(1);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetDbPropertyFromDummy()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int db_property = 0;

                    cm.CommandType = CommandType.Text;
                    //?cm.CommandText = "select db_property ( 'conncount') from sys.dummy ";
                    cm.CommandText = "select count(*) from sys.sysprocesses ";

                    ParameterCollection pList = new ParameterCollection();


                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                db_property = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    _rowCount = db_property;
                }
            }
        }

        [ServerMethod]
        private void _GetOdBlfMainrunCheckrunFromDummy(int? lcontract, int? lcontractor, DateTime? dstart, DateTime? dend)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int db_property = 0;

                    cm.CommandType = CommandType.Text;
                    cm.CommandTimeout = 1500;                    
                    cm.CommandText = "select odps.od_blf_mainrun_checkrun(:lcontract,:lcontractor, :dstart,:dend)";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lcontract", lcontract);
                    pList.Add(cm, "lcontractor", lcontractor);
                    pList.Add(cm, "dstart", dstart);
                    pList.Add(cm, "dend", dend);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                db_property = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    _rowCount = db_property;
                }
            }
        }

        // TJB  RPCR_140  June-2019: New
        [ServerMethod]
        private void _GetOdBlfMainrun(int? lcontract, int? lcontractor, DateTime? dstart, DateTime? dend, int? nRgCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_blf_mainrun";
                    cm.CommandTimeout = 1500;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "incontract_no", lcontract);
                    pList.Add(cm, "inContractor_No", lcontractor);
                    pList.Add(cm, "inPayPeriod_Start", dstart);
                    pList.Add(cm, "inPayPeriod_End", dend);
                    pList.Add(cm, "inRenewalGroup", nRgCode);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                dataObject = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetOdBlfMainrunFromDummy(int? lcontract, int? lcontractor, DateTime? dstart, DateTime? dend)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_blf_mainrun";
                    cm.CommandTimeout = 1500;                    
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "incontract_no", lcontract);
                    pList.Add(cm, "inContractor_No", lcontractor);
                    pList.Add(cm, "inPayPeriod_Start", dstart);
                    pList.Add(cm, "inPayPeriod_End", dend);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                dataObject = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _GetCountFromTPosttaxDeductionsNotApplied()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int count = 0;

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT count(odps.t_posttax_deductions_not_applied.ded_id) " +
                        "FROM odps.t_posttax_deductions_not_applied";
                    ParameterCollection pList = new ParameterCollection();


                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                count = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    _count = count;
                }
            }
        }

        [ServerMethod]
        private void _GetOdBlfMainrunAcceptFromDummy(DateTime? id_Enddate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int SWP_Re = 0;

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_blf_mainrun_accept";
                    cm.CommandTimeout = 1500;

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "enddat", id_Enddate);
                    pList.Add(cm, "SWP_Re", SWP_Re);
              
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                SWP_Re = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    lAcceptResults = SWP_Re;
                }
            }
        }

        [ServerMethod]
        private void _DeleteFromTPosttaxDeductionsNotApplied()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " DELETE FROM odps.t_posttax_deductions_not_applied";

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, null);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        // TJB  RPCR_057  Dec-2013  [Drop audit triggers]
        // Disabled InserIntoRdsAudit and GetAkeyFromRdsAudit
        [ServerMethod]
        private void _InserIntoRdsAudit(DateTime? tStart, String gs_UserID, int? lcontract, int? lcontractor, string ls_RunMSG)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " INSERT INTO rd.rds_audit( " +
                        " a_datetime, a_userid, a_contract, a_contractor, a_comment, a_oldvalue, a_newvalue ) " +
                        " VALUES ( :tStart,:gs_UserID,  :lcontract, :lcontractor, :ls_RunMSG, null,  null )  ";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "tStart", tStart);
                    pList.Add(cm, "gs_UserID", gs_UserID);
                    pList.Add(cm, "lcontract", lcontract);
                    pList.Add(cm, "lcontractor", lcontractor);
                    pList.Add(cm, "ls_RunMSG", ls_RunMSG);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        ret = true;
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        ret = false;
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }

        // TJB  RPCR_057  Dec-2013  [Drop audit triggers]
        // Disabled InserIntoRdsAudit and GetAkeyFromRdsAudit
        [ServerMethod]
        private void _GetAkeyFromRdsAudit(DateTime? tStart, String gs_UserID, int? lcontract, int? lcontractor)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int ll_aKey_temp = 0;

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select a_key into :ll_aKey"
                                      + " from rd.rds_audit "
                                      + " where a_datetime = :tstart"
                                      + " and a_userid   = :gs_userID"
                                      + " and a_contract = :lcontract"
                                      + " and a_contractor = :lcontractor";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "tStart", tStart);
                    pList.Add(cm, "gs_UserID", gs_UserID);
                    pList.Add(cm, "lcontract", lcontract);
                    pList.Add(cm, "lcontractor", lcontractor);


                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                ll_aKey_temp = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    ll_aKey = ll_aKey_temp;
                }
            }
        }

        // TJB  RPCR_140  June-2019
        // Validate the contract number
        [ServerMethod]
        private void _ValidateContract(int? nContractNo)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    int count = 0;

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(*) from rd.contract"
                                   + " where contract_no = @nContractNo"
                                   + "   and con_date_terminated is null";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "nContractNo", nContractNo);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                count = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    _count = count;
                }
            }
        }

        // TJB  RPCR_140  June-2019
        // Look up the renewal group description
        [ServerMethod]
        private void _GetRgDescription(int? nRgCode)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    string description = "";

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select rg_description from rd.renewal_group"
                                   + " where rg_code = @nRgCode";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "nRgCode", nRgCode);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                description = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                    _text = description;
                }
            }
        }

        [ServerMethod]
        private void _SelectContractType()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    contractType = new ContractType();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " select count(*) from rd.contract_type";

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, null))
                        {
                            if (dr.Read())
                            {
                                contractType._count = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectContractType2(Int32 ct_key)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    contractType = new ContractType();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select contract_type from rd.contract_type " 
                                   + " where ct_key = @li_ct_key";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "li_ct_key", ct_key);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                contractType._contract_type = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectRdsUserId(String ui_userid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    rdsUserId = new RdsUserId();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT ui_id FROM rd.rds_user_id WHERE ui_userid = @ls_ui_userid";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ls_ui_userid", ui_userid);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                rdsUserId._ui_id = dr.GetInt32(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _SelectUsedPassword(Int32 ui_id, String up_password)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    usedPassword = new UsedPassword();

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT up_password FROM rd.used_password " +
                        "WHERE ui_id = @ll_ui_id AND up_password = @sNewPassword";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_ui_id", ui_id);
                    pList.Add(cm, "sNewPassword", up_password);

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            if (dr.Read())
                            {
                                usedPassword.up_password = dr.GetString(0);
                                _sqlcode = 0;
                            }
                            else
                            {
                                _sqlcode = 100;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        _sqlerrtext = e.Message;
                        _sqlcode = -1;
                    }
                }
            }
        }

        [ServerMethod]
        private void _UpdateRdsUserId(String ui_password, DateTime ui_password_expiry, String ui_userid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "UPDATE rd.rds_user_id " +
                        "SET	ui_password = @sNewPassword,ui_password_expiry = @dExpiry,ui_grace_logins = 4 " +
                        "WHERE	ui_userid = @ls_ui_userid";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sNewPassword", ui_password);
                    pList.Add(cm, "dExpiry", ui_password_expiry);
                    pList.Add(cm, "ls_ui_userid", ui_userid);
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        dataObject = e.Message.ToString();
                    }
                }
            }
        }

        [ServerMethod]
        private void _InserIntoUsedPassword(Int32 ui_id, String up_password)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "INSERT INTO rd.used_password (ui_id,up_password) VALUES (@ll_ui_id,@sOldPassword)";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ll_ui_id", ui_id);
                    pList.Add(cm, "sOldPassword", up_password);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        _sqlcode = 0;
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
            }
        }
        #endregion

        #region
        [Serializable()]
        public class ShellImport
        {
            internal string _contract_no;
            internal Decimal? _total_deduction;

            public string ContractNo
            {
                get { return _contract_no; }
            }
            public Decimal? TotalDeduction
            {
                get { return _total_deduction; }
            }
        }

        [Serializable()]
        public class TelecomImport
        {
            internal int ll_rowcount;
            internal Decimal dc_hashtotal;

            public int LlRowCount
            {
                get { return ll_rowcount; }
            }
            public Decimal DcHashtotal
            {
                get { return dc_hashtotal; }
            }
        }

        [Serializable()]
        public class PostTaxDeductions
        {
            internal int li_imported;
            internal Decimal dc_hashtotal;

            public int LiImported
            {
                get { return li_imported; }
            }
            public Decimal DcHashtotal
            {
                get { return dc_hashtotal; }
            }
        }

        [Serializable()]
        public class ContractType
        {
            internal Int32 _count;
            internal String _contract_type;

            public Int32 Count
            {
                get { return _count; }
            }

            public String ContractTypeCol
            {
                get { return _contract_type; }
            }
        }

        [Serializable()]
        public class RdsUserId
        {
            internal Int32 _ui_id;

            public Int32 UiId
            {
                get { return _ui_id; }
            }
        }

        [Serializable()]
        public class UsedPassword
        {
            internal String up_password;

            public String UpPassword
            {
                get { return up_password; }
            }
        }
        #endregion
    }
}
