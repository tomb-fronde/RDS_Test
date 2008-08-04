//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsInvoice
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("invoice_id", "_invoice_id", "")]
    [MapInfo("prd_date", "_prd_date", "")]
    [MapInfo("prt_code", "_prt_code", "")]
    [MapInfo("prd_quantity", "_prd_quantity", "")]
    [MapInfo("rate", "_rate", "")]
    [MapInfo("cost", "_cost", "")]
    [System.Serializable()]

    public class InvoiceDetailPaymentPrDetailxp : Entity<InvoiceDetailPaymentPrDetailxp>
    {
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
        public static InvoiceDetailPaymentPrDetailxp NewInvoiceDetailPaymentPrDetailxp(int? invoiceid, int? contractno, int? contractorno, DateTime? payperiod_start, DateTime? payperiod_end)
        {
            return Create(invoiceid, contractno, contractorno, payperiod_start, payperiod_end);
        }

        public static InvoiceDetailPaymentPrDetailxp[] GetAllInvoiceDetailPaymentPrDetailxp(int? invoiceid, int? contractno, int? contractorno, DateTime? payperiod_start, DateTime? payperiod_end)
        {
            return Fetch(invoiceid, contractno, contractorno, payperiod_start, payperiod_end).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? invoiceid, int? contractno, int? contractorno, DateTime? payperiod_start, DateTime? payperiod_end)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoice_pay_piecerate_detailxp";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "invoiceid", invoiceid);
                    pList.Add(cm, "contractno", contractno);
                    pList.Add(cm, "contractorno", contractorno);
                    pList.Add(cm, "payperiod_start", payperiod_start);
                    pList.Add(cm, "payperiod_end", payperiod_end);

                    List<InvoiceDetailPaymentPrDetailxp> _list = new List<InvoiceDetailPaymentPrDetailxp>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceDetailPaymentPrDetailxp instance = new InvoiceDetailPaymentPrDetailxp();
                            instance.InvoiceId = GetValueFromReader<Int32?>(dr,0);
                            instance.PrdDate = GetValueFromReader<DateTime?>(dr,1);
                            instance.PrtCode = GetValueFromReader<string>(dr,2);
                            instance.PrdQuantity = GetValueFromReader<Int32?>(dr,3);
                            instance.Rate = GetValueFromReader<decimal?>(dr,4);
                            instance.Cost = GetValueFromReader<decimal?>(dr,5);

                            instance._contractNo = contractno;
                            instance._contractorNo = contractorno;

                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        //if (dr.Read())
                        //{
                        //    InvoiceDetailPaymentPrDetailxp item = new InvoiceDetailPaymentPrDetailxp();
                        //    _list.Add(item);
                        //}
                        list = _list.ToArray();
                    }
                }
            }
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}
