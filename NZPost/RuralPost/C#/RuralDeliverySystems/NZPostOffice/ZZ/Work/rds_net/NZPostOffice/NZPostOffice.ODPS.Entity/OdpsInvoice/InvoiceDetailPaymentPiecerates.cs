using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsInvoice
{
    // TJB  RPCR_054 June-2013: NEW
    // Select piecerates for export
    // Adapted from InvoiceDetailPaymentPrKm

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("invoice_id", "_invoice_id", "")]
    [MapInfo("prd_date", "_prd_date", "")]
    [MapInfo("prt_code", "_prt_code", "")]
    [MapInfo("prd_quantity", "_prd_quantity", "")]
    [MapInfo("rate", "_rate", "")]
    [MapInfo("cost", "_cost", "")]
    [MapInfo("atype", "_atype", "")]
    [MapInfo("prs_key", "_prs_key", "")]
    [System.Serializable()]

    public class InvoiceDetailPaymentPiecerates : Entity<InvoiceDetailPaymentPiecerates>
    {
        // TJB RPCR_012 2-July-2010
        // Added 'atype' (piece rate supplier name) to values returned
        // Used in Invoice section headers
        #region Business Methods
        [DBField()]
        private int? _invoice_id;

        [DBField()]
        private DateTime? _prd_date;

        [DBField()]
        private string _prt_code;

        [DBField()]
        private int? _prd_quantity;

        [DBField()]
        private decimal? _rate;

        [DBField()]
        private decimal? _cost;

        [DBField()]
        private string _atype;

        [DBField()]
        private int? _prs_key;

        public virtual int? InvoiceId
        {
            get
            {
                CanReadProperty("InvoiceId",true);
                return _invoice_id;
            }
            set
            {
                CanWriteProperty("InvoiceId",true);
                if (_invoice_id != value)
                {
                    _invoice_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? PrdDate
        {
            get
            {
                CanReadProperty("PrdDate",true);
                return _prd_date;
            }
            set
            {
                CanWriteProperty("PrdDate",true);
                if (_prd_date != value)
                {
                    _prd_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrtCode
        {
            get
            {
                CanReadProperty("PrtCode",true);
                return _prt_code;
            }
            set
            {
                CanWriteProperty("PrtCode",true);
                if (_prt_code != value)
                {
                    _prt_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrdQuantity
        {
            get
            {
                CanReadProperty("PrdQuantity",true);
                return _prd_quantity;
            }
            set
            {
                CanWriteProperty("PrdQuantity",true);
                if (_prd_quantity != value)
                {
                    _prd_quantity = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Rate
        {
            get
            {
                CanReadProperty("Rate",true);
                return _rate;
            }
            set
            {
                CanWriteProperty("Rate",true);
                if (_rate != value)
                {
                    _rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Cost
        {
            get
            {
                CanReadProperty("Cost",true);
                return _cost;
            }
            set
            {
                CanWriteProperty("Cost",true);
                if (_cost != value)
                {
                    _cost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Atype
        {
            get
            {
                CanReadProperty("Atype", true);
                return _atype;
            }
            set
            {
                CanWriteProperty("Atype", true);
                if (_atype != value)
                {
                    _atype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrsKey
        {
            get
            {
                CanReadProperty("PrsKey", true);
                return _prs_key;
            }
            set
            {
                CanWriteProperty("PrsKey", true);
                if (_prs_key != value)
                {
                    _prs_key = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[rowcount]
        //?rowcount()

        private int? _contractNo;
        public int? ContractNo
        {
            get { return _contractNo; }
            set { _contractNo = value; }
        }

        private int? _contractorNo;
        public int? ContractorNo
        {
            get { return _contractorNo; }
            set { _contractorNo = value; }
        }
	
        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static InvoiceDetailPaymentPiecerates NewInvoiceDetailPaymentPiecerates(int? invoiceid)
        {
            return Create(invoiceid);
        }

        public static InvoiceDetailPaymentPiecerates[] GetAllInvoiceDetailPaymentPiecerates(int? invoiceid)
        {
            return Fetch(invoiceid).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? invoiceid)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoice_pay_piecerate_detail";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "invoiceid", invoiceid);

                    List<InvoiceDetailPaymentPiecerates> _list = new List<InvoiceDetailPaymentPiecerates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceDetailPaymentPiecerates instance = new InvoiceDetailPaymentPiecerates();
                            instance.InvoiceId = GetValueFromReader<Int32?>(dr,0);
                            instance.PrdDate = GetValueFromReader<DateTime?>(dr,1);
                            instance.PrtCode = GetValueFromReader<string>(dr,2);
                            instance.PrdQuantity = GetValueFromReader<Int32?>(dr,3);
                            instance.Rate = GetValueFromReader<decimal?>(dr,4);
                            instance.Cost = GetValueFromReader<decimal?>(dr, 5);
                            instance.Atype = GetValueFromReader<string>(dr, 6);
                            instance.PrsKey = GetValueFromReader<Int32?>(dr, 7);

                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity(int? invoiceid)
        {
        }
    }
}
