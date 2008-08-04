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
    [MapInfo("in_date", "_in_date", "")]
    [MapInfo("prs_description", "_prs_description", "")]
    [MapInfo("pvolume", "_pvolume", "")]
    [MapInfo("pvalue", "_pvalue", "")]
    [System.Serializable()]

    public class InvoiceDetailPaymentPr : Entity<InvoiceDetailPaymentPr>
    {
        #region Business Methods
        [DBField()]
        private DateTime? _in_date;

        [DBField()]
        private string _prs_description;

        [DBField()]
        private int? _pvolume;

        [DBField()]
        private decimal? _pvalue;

        public virtual DateTime? InDate
        {
            get
            {
                CanReadProperty("InDate",true);
                return _in_date;
            }
            set
            {
                CanWriteProperty("InDate",true);
                if (_in_date != value)
                {
                    _in_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime? REInDate
        {
            get
            {
                return _in_date;
            }
        }

        public virtual string PrsDescription
        {
            get
            {
                CanReadProperty("PrsDescription",true);
                return _prs_description;
            }
            set
            {
                CanWriteProperty("PrsDescription",true);
                if (_prs_description != value)
                {
                    _prs_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Pvolume
        {
            get
            {
                CanReadProperty("Pvolume",true);
                return _pvolume;
            }
            set
            {
                CanWriteProperty("Pvolume",true);
                if (_pvolume != value)
                {
                    _pvolume = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REPvolume
        {
            get
            {
                return _pvolume;
            }
        }
        
        public virtual decimal? Pvalue
        {
            get
            {
                CanReadProperty("Pvalue",true);
                return _pvalue;
            }
            set
            {
                CanWriteProperty("Pvalue",true);
                if (_pvalue != value)
                {
                    _pvalue = value;
                    PropertyHasChanged();
                }
            }
        }
        
        public decimal? REPvalue
        {
            get
            {
                return _pvalue;
            }
        }
    
        // needs to implement compute expression manually:
        // compute control name=[rowcount]
        //?rowcount()
        private int? _invoiceId;

        public int? InvoiceId
        {
            get { return _invoiceId; }
            set { _invoiceId = value; }
        }
	
        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static InvoiceDetailPaymentPr NewInvoiceDetailPaymentPr(int? invoiceid, DateTime? in_date)
        {
            return Create(invoiceid, in_date);
        }

        public static InvoiceDetailPaymentPr[] GetAllInvoiceDetailPaymentPr(int? invoiceid, DateTime? in_date)
        {
            return Fetch(invoiceid, in_date).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? invoiceid, DateTime? in_date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoice_pay_adjustments";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "invoiceid", invoiceid);
                    pList.Add(cm, "in_date", in_date);

                    List<InvoiceDetailPaymentPr> _list = new List<InvoiceDetailPaymentPr>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceDetailPaymentPr instance = new InvoiceDetailPaymentPr();
                            instance.InDate = GetValueFromReader<DateTime?>(dr,0);
                            instance.PrsDescription = GetValueFromReader<string>(dr,1);
                            instance.Pvolume = GetValueFromReader<Int32?>(dr,2);
                            instance.Pvalue = GetValueFromReader<decimal?>(dr,3);

                            instance._invoiceId = invoiceid;

                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        //if (_list.Count == 0)
                        //{
                        //    InvoiceDetailPaymentPr item = new InvoiceDetailPaymentPr();
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
