using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;
using NZPostOffice.RDS.DataService;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB ECL Data Import  June 2010:  New

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE

    [MapInfo("ecl_batch_no", "_ecl_batch_no", "ECL_upload_data")]
    [MapInfo("ecl_ticket_no", "_ecl_ticket_no", "ECL_upload_data")]
    [MapInfo("ecl_ticket_part", "_ecl_ticket_part", "ECL_upload_data")]
    [MapInfo("ecl_customer_name", "_ecl_customer_name", "ECL_upload_data")]
    [MapInfo("ecl_customer_code", "_ecl_customer_code", "ECL_upload_data")]
    [MapInfo("ecl_seq", "_ecl_seq", "ECL_upload_data")]
    [MapInfo("ecl_driver_id", "_ecl_driver_id", "ECL_upload_data")]
    [MapInfo("ecl_rate_code", "_ecl_rate_code", "ECL_upload_data")]
    [MapInfo("ecl_rate_descr", "_ecl_rate_descr", "ECL_upload_data")]
    [MapInfo("ecl_pkg_descr", "_ecl_pkg_descr", "ECL_upload_data")]
    [MapInfo("ecl_batch_id", "_ecl_batch_id", "ECL_upload_data")]
    [MapInfo("ecl_run_id", "_ecl_run_id", "ECL_upload_data")]
    [MapInfo("ecl_run_no", "_ecl_run_no", "ECL_upload_data")]
    [MapInfo("ecl_driver_date", "_ecl_driver_date", "ECL_upload_data")]
    [MapInfo("ecl_date_entered", "_ecl_date_entered", "ECL_upload_data")]
    [MapInfo("ecl_ticket_payable", "_ecl_ticket_payable", "ECL_upload_data")]
    [MapInfo("ecl_rural_payable", "_ecl_rural_payable", "ECL_upload_data")]
    [MapInfo("ecl_scan_count", "_ecl_scan_count", "ECL_upload_data")]
    [MapInfo("ecl_sig_req_flag", "_ecl_sig_req_flag", "ECL_upload_data")]
    [MapInfo("ecl_sig_captured", "_ecl_sig_captured", "ECL_upload_data")]
    [MapInfo("ecl_sig_name", "_ecl_sig_name", "ECL_upload_data")]
    [MapInfo("ecl_pr_code", "_ecl_pr_code", "ECL_upload_data")]
    [MapInfo("ecl_ro5_flag", "_ecl_ro5_flag", "ECL_upload_data")]
    [MapInfo("ecl_effective_date", "_ecl_effective_date", "ECL_upload_data")]
    [MapInfoIndex(new string[] { "ecl_batch_no",      "ecl_ticket_no",   "ecl_ticket_part",  "ecl_customer_name", 
                                 "ecl_customer_code", "ecl_seq",         "ecl_driver_id",    "ecl_rate_code", 
                                 "ecl_rate_descr",    "ecl_pkg_descr",   "ecl_batch_id",     "ecl_run_id", 
                                 "ecl_run_no",        "ecl_driver_date", "ecl_date_entered", "ecl_ticket_payable", 
                                 "ecl_rural_payable", "ecl_scan_count",  "ecl_sig_req_flag", "ecl_sig_captured", 
                                 "ecl_sig_name",      "ecl_pr_code",     "ecl_ro5_flag",     "ecl_effective_date" })]
    [System.Serializable()]

    public class EclDataImport : Entity<EclDataImport>
    {
        #region Business Methods
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
        
        [DBField()]
        private int     _ecl_batch_no;

        [DBField()]
        private string  _ecl_ticket_no;

        [DBField()]
        private string  _ecl_ticket_part;

        [DBField()]
        private string  _ecl_customer_name;

        [DBField()]
        private string  _ecl_customer_code;

        [DBField()]
        private string  _ecl_seq;

        [DBField()]
        private string  _ecl_driver_id;

        [DBField()]
        private string  _ecl_rate_code;

        [DBField()]
        private string  _ecl_rate_descr;

        [DBField()]
        private string  _ecl_pkg_descr;

        [DBField()]
        private string  _ecl_batch_id;

        [DBField()]
        private string  _ecl_run_id;

        [DBField()]
        private string  _ecl_run_no;

        [DBField()]
        private DateTime?  _ecl_driver_date;

        [DBField()]
        private string  _ecl_date_entered;

        [DBField()]
        private string  _ecl_ticket_payable;

        [DBField()]
        private string  _ecl_rural_payable;

        [DBField()]
        private string  _ecl_scan_count;

        [DBField()]
        private string  _ecl_sig_req_flag;

        [DBField()]
        private string  _ecl_sig_captured;

        [DBField()]
        private string  _ecl_sig_name;

        [DBField()]
        private string _ecl_pr_code;

        [DBField()]
        private string _ecl_ro5_flag;

        [DBField()]
        private DateTime? _ecl_effective_date;


        public virtual int EclBatchNo
        {
            get
            {
                CanReadProperty("EclBatchNo", true);
                return _ecl_batch_no;
            }
            set
            {
                CanWriteProperty("EclBatchNo", true);
                if (_ecl_batch_no != value)
                {
                    _ecl_batch_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclTicketNo
        {
            get
            {
                CanReadProperty("EclTicketNo", true);
                return _ecl_ticket_no;
            }
            set
            {
                CanWriteProperty("EclTicketNo", true);
                if (_ecl_ticket_no != value)
                {
                    _ecl_ticket_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclTicketPart
        {
            get
            {
                CanReadProperty("EclTicketPart", true);
                return _ecl_ticket_part;
            }
            set
            {
                CanWriteProperty("EclTicketPart", true);
                if (_ecl_ticket_part != value)
                {
                    _ecl_ticket_part = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclCustomerName
        {
            get
            {
                CanReadProperty("EclCustomerName", true);
                return _ecl_customer_name;
            }
            set
            {
                CanWriteProperty("EclCustomerName", true);
                if (_ecl_customer_name != value)
                {
                    _ecl_customer_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclCustomerCode
        {
            get
            {
                CanReadProperty("EclCustomerCode", true);
                return _ecl_customer_code;
            }
            set
            {
                CanWriteProperty("EclCustomerCode", true);
                if (_ecl_customer_code != value)
                {
                    _ecl_customer_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclSeq
        {
            get
            {
                CanReadProperty("EclSeq", true);
                return _ecl_seq;
            }
            set
            {
                CanWriteProperty("EclSeq", true);
                if (_ecl_seq != value)
                {
                    _ecl_seq = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclDriverId
        {
            get
            {
                CanReadProperty("EclDriverId", true);
                return _ecl_driver_id;
            }
            set
            {
                CanWriteProperty("EclDriverId", true);
                if (_ecl_driver_id != value)
                {
                    _ecl_driver_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclRateCode
        {
            get
            {
                CanReadProperty("EclRateCode", true);
                return _ecl_rate_code;
            }
            set
            {
                CanWriteProperty("EclRateCode", true);
                if (_ecl_rate_code != value)
                {
                    _ecl_rate_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclRateDescr
        {
            get
            {
                CanReadProperty("EclRateDescr", true);
                return _ecl_rate_descr;
            }
            set
            {
                CanWriteProperty("EclRateDescr", true);
                if (_ecl_rate_descr != value)
                {
                    _ecl_rate_descr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclPkgDescr
        {
            get
            {
                CanReadProperty("EclPkgDescr", true);
                return _ecl_pkg_descr;
            }
            set
            {
                CanWriteProperty("EclPkgDescr", true);
                if (_ecl_pkg_descr != value)
                {
                    _ecl_pkg_descr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclBatchId
        {
            get
            {
                CanReadProperty("EclBatchId", true);
                return _ecl_batch_id;
            }
            set
            {
                CanWriteProperty("EclBatchId", true);
                if (_ecl_batch_id != value)
                {
                    _ecl_batch_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclRunID
        {
            get
            {
                CanReadProperty("EclRunID", true);
                return _ecl_run_id;
            }
            set
            {
                CanWriteProperty("EclRunID", true);
                if (_ecl_run_id != value)
                {
                    _ecl_run_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclRunNo
        {
            get
            {
                CanReadProperty("EclRunNo", true);
                return _ecl_run_no;
            }
            set
            {
                CanWriteProperty("EclRunNo", true);
                if (_ecl_run_no != value)
                {
                    _ecl_run_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? EclDriverDate
        {
            get
            {
                CanReadProperty("EclDriverDate", true);
                return _ecl_driver_date;
            }
            set
            {
                CanWriteProperty("EclDriverDate", true);
                if (_ecl_driver_date != value)
                {
                    _ecl_driver_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclDateEntered
        {
            get
            {
                CanReadProperty("EclDateEntered", true);
                return _ecl_date_entered;
            }
            set
            {
                CanWriteProperty("EclDateEntered", true);
                if (_ecl_date_entered != value)
                {
                    _ecl_date_entered = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclTicketPayable
        {
            get
            {
                CanReadProperty("EclTicketPayable", true);
                return _ecl_ticket_payable;
            }
            set
            {
                CanWriteProperty("EclTicketPayable", true);
                if (_ecl_ticket_payable != value)
                {
                    _ecl_ticket_payable = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclRuralPayable
        {
            get
            {
                CanReadProperty("EclRuralPayable", true);
                return _ecl_rural_payable;
            }
            set
            {
                CanWriteProperty("EclRuralPayable", true);
                if (_ecl_rural_payable != value)
                {
                    _ecl_rural_payable = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclScanCount
        {
            get
            {
                CanReadProperty("EclScanCount", true);
                return _ecl_scan_count;
            }
            set
            {
                CanWriteProperty("EclScanCount", true);
                if (_ecl_scan_count != value)
                {
                    _ecl_scan_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclSigReqFlag
        {
            get
            {
                CanReadProperty("EclSigReqFlag", true);
                return _ecl_sig_req_flag;
            }
            set
            {
                CanWriteProperty("EclSigReqFlag", true);
                if (_ecl_sig_req_flag != value)
                {
                    _ecl_sig_req_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclSigCaptured
        {
            get
            {
                CanReadProperty("EclSigCaptured", true);
                return _ecl_sig_captured;
            }
            set
            {
                CanWriteProperty("EclSigCaptured", true);
                if (_ecl_sig_captured != value)
                {
                    _ecl_sig_captured = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclSigName
        {
            get
            {
                CanReadProperty("EclSigName", true);
                return _ecl_sig_name;
            }
            set
            {
                CanWriteProperty("EclSigName", true);
                if (_ecl_sig_name != value)
                {
                    _ecl_sig_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclPrCode
        {
            get
            {
                CanReadProperty("EclPrCode", true);
                return _ecl_pr_code;
            }
            set
            {
                CanWriteProperty("EclPrCode", true);
                if (_ecl_pr_code != value)
                {
                    _ecl_pr_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EclRo5Flag
        {
            get
            {
                CanReadProperty("EclRo5Flag", true);
                return _ecl_ro5_flag;
            }
            set
            {
                CanWriteProperty("EclRo5Flag", true);
                if (_ecl_ro5_flag != value)
                {
                    _ecl_ro5_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? EclEffectiveDate
        {
            get
            {
                CanReadProperty("EclEffectiveDate", true);
                return _ecl_effective_date;
            }
            set
            {
                CanWriteProperty("EclEffectiveDate", true);
                if (_ecl_effective_date != value)
                {
                    _ecl_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _ecl_batch_no, _ecl_ticket_no, _ecl_ticket_part );
		}

        #endregion

        #region Factory Methods
        public static EclDataImport NewEclDataImport(  )
        {
            return Create();
        }

        public static EclDataImport[] GetAllEclDataImport(  )
        {
            return Fetch().list;
        }     

        #endregion

        #region Data Access
        //Exterior Data
        [ServerMethod()]
        private void InsertEntity()
        {
            _sqlcode = 0;
            _sqlerrtext = "";

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "ECL_upload_data", pList))
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        _sqlcode = -1;
                        _sqlerrtext = e.Message;
                    }
                }
                StoreInitialValues();
                MarkClean();
            }
        }
/*  These are sample code!
        [ServerMethod]
        private void FetchEntity(  )
        {
            using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();

                    List<EclDataImport> _list = new List<EclDataImport>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            EclDataImport instance = new EclDataImport();
                            instance.MarkOld();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "piece_rate_delivery", ref pList))
                {
                    cm.CommandText += " WHERE  piece_rate_delivery.prd_date = @prd_date and " 
                                      + " piece_rate_delivery.prt_key = @prt_key and " 
                                      + " piece_rate_delivery.contract_no = @contract_no";

                    pList.Add(cm, "prd_date", GetInitialValue("_prd_date"));
                    pList.Add(cm, "prt_key", GetInitialValue("_prt_key"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
                MarkClean();
            }
        }

        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "piece_rate_delivery", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
                MarkClean();
            }
        }

        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    cm.CommandText = "DELETE FROM piece_rate_delivery "
                                     + " WHERE piece_rate_delivery.prd_date = @prd_date and " 
                                     +   " and piece_rate_delivery.prt_key = @prt_key and " 
                                     +   " and piece_rate_delivery.contract_no = @contract_no";
                    pList.Add(cm, "prd_date", GetInitialValue("_prd_date"));
                    pList.Add(cm, "prt_key", GetInitialValue("_prt_key"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
*/
        #endregion

        [ServerMethod()]
        private void CreateEntity(int ecl_batch_no, string ecl_ticket_no, string ecl_ticket_part)
        {
            _ecl_batch_no = ecl_batch_no;
            _ecl_ticket_no = ecl_ticket_no;
            _ecl_ticket_part = ecl_ticket_part;
        }
    }
}
