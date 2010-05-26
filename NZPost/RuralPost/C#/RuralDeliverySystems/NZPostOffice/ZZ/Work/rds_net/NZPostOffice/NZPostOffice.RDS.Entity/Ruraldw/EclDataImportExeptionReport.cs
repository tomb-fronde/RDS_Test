using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("ecl_batch_no", "_ecl_batch_no", "")]
    [MapInfo("ecl_ticket_no", "_ecl_ticket_no", "")]
    [MapInfo("ecl_ticket_part", "_ecl_ticket_part", "")]
    [MapInfo("ecl_customer_name", "_ecl_customer_name", "")]
    [MapInfo("ecl_customer_code", "_ecl_customer_code", "")]
    [MapInfo("ecl_seq", "_ecl_seq", "")]
    [MapInfo("ecl_driver_id", "_ecl_driver_id", "")]
    [MapInfo("ecl_rate_code", "_ecl_rate_code", "")]
    [MapInfo("ecl_rate_descr", "_ecl_rate_descr", "")]
    [MapInfo("ecl_pkg_descr", "_ecl_pkg_descr", "")]
    [MapInfo("ecl_batch_id", "_ecl_batch_id", "")]
    [MapInfo("ecl_run_id", "_ecl_run_id", "")]
    [MapInfo("ecl_run_no", "_ecl_run_no", "")]
    [MapInfo("ecl_driver_date", "_ecl_driver_date", "")]
    [MapInfo("ecl_date_entered", "_ecl_date_entered", "")]
    [MapInfo("ecl_ticket_payable", "_ecl_ticket_payable", "")]
    [MapInfo("ecl_rural_payable", "_ecl_rural_payable", "")]
    [MapInfo("ecl_scan_count", "_ecl_scan_count", "")]
    [MapInfo("ecl_sig_req_flag", "_ecl_sig_req_flag", "")]
    [MapInfo("ecl_sig_captured", "_ecl_sig_captured", "")]
    [MapInfo("ecl_sig_name", "_ecl_sig_name", "")]
    [MapInfo("ecl_pr_code", "_ecl_pr_code", "")]
    [MapInfo("error_msg_text", "_error_msg_text", "")]
    [System.Serializable()]

    public class EclDataImportExeptionReport : Entity<EclDataImportExeptionReport>
    {
        #region Business Methods
        private int _sqlcode = -1;

        private int _sqldbcode = -1;

        private string _sqlerrtext = "";

        [DBField()]
        private int _ecl_batch_no;

        [DBField()]
        private string _ecl_ticket_no;

        [DBField()]
        private string _ecl_ticket_part;

        [DBField()]
        private string _ecl_customer_name;

        [DBField()]
        private int? _ecl_customer_code;

        [DBField()]
        private int? _ecl_seq;

        [DBField()]
        private int? _ecl_driver_id;

        [DBField()]
        private int? _ecl_rate_code;

        [DBField()]
        private string _ecl_rate_descr;

        [DBField()]
        private string _ecl_pkg_descr;

        [DBField()]
        private int? _ecl_batch_id;

        [DBField()]
        private int? _ecl_run_id;

        [DBField()]
        private string _ecl_run_no;

        [DBField()]
        private DateTime? _ecl_driver_date;

        [DBField()]
        private DateTime? _ecl_date_entered;

        [DBField()]
        private string _ecl_ticket_payable;

        [DBField()]
        private string _ecl_rural_payable;

        [DBField()]
        private int? _ecl_scan_count;

        [DBField()]
        private string _ecl_sig_req_flag;

        [DBField()]
        private string _ecl_sig_captured;

        [DBField()]
        private string _ecl_sig_name;

        [DBField()]
        private string _ecl_pr_code;

        [DBField()]
        private string _error_msg_text;

        public int SQLCode
        {
            get
            {
                return _sqlcode;
            }
        }

        public int SQLDBCode
        {
            get
            {
                return _sqldbcode;
            }
        }

        public string SQLErrText
        {
            get
            {
                return _sqlerrtext;
            }
        }

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

        public virtual int? EclCustomerCode
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

        public virtual int? EclSeq
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

        public virtual int? EclDriverId
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

        public virtual int? EclRateCode
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

        public virtual int? EclBatchId
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

        public virtual int? EclRunID
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

        public virtual DateTime? EclDateEntered
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

        public virtual int? EclScanCount
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

        public virtual string ErrorMsgText
        {
            get
            {
                CanReadProperty("ErrorMsgText", true);
                return _error_msg_text;
            }
            set
            {
                CanWriteProperty("ErrorMsgText", true);
                if (_error_msg_text != value)
                {
                    _error_msg_text = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _ecl_batch_no, _ecl_ticket_no, _ecl_ticket_part);
        }

        #endregion

        #region Factory Methods
        public static EclDataImportExeptionReport NewEclDataImportExeptionReport()
        {
            return Create();
        }

        public static EclDataImportExeptionReport[] GetAllEclDataImportExeptionReport()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<EclDataImportExeptionReport> _list = new List<EclDataImportExeptionReport>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    EclDataImportExeptionReport instance = new EclDataImportExeptionReport();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

        #endregion

        [ServerMethod()]
        private void CreateEntity(int ecl_batch_no, string ecl_ticket_no, string ecl_ticket_part, string error_msg_text)
        {
            _ecl_batch_no = ecl_batch_no;
            _ecl_ticket_no = ecl_ticket_no;
            _ecl_ticket_part = ecl_ticket_part;
            _error_msg_text = error_msg_text;
        }
    }
}
