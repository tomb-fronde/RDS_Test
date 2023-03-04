using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.Odps.Entity.OdpsInvoice
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("pcd_date", "_pcd_date", "")]
    [MapInfo("ded_description", "_ded_description", "")]
    [MapInfo("pcd_amount", "_pcd_amount", "")]
    [System.Serializable()]

    public class InvoiceDetailPaymentDed : Entity<InvoiceDetailPaymentDed>
    {
        #region Business Methods
        [DBField()]
        private DateTime? _pcd_date;

        [DBField()]
        private string _ded_description;

        [DBField()]
        private decimal? _pcd_amount;

        public virtual DateTime? PcdDate
        {
            get
            {
                CanReadProperty("PcdDate", true);
                return _pcd_date;
            }
            set
            {
                CanWriteProperty("PcdDate", true);
                if (_pcd_date != value)
                {
                    _pcd_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DedDescription
        {
            get
            {
                CanReadProperty("DedDescription", true);
                return _ded_description;
            }
            set
            {
                CanWriteProperty("DedDescription", true);
                if (_ded_description != value)
                {
                    _ded_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? PcdAmount
        {
            get
            {
                CanReadProperty("PcdAmount", true);
                return _pcd_amount;
            }
            set
            {
                CanWriteProperty("PcdAmount", true);
                if (_pcd_amount != value)
                {
                    _pcd_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[rowcount]
        //?rowcount()

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static InvoiceDetailPaymentDed NewInvoiceDetailPaymentDed(int? invoiceid)
        {
            return Create(invoiceid);
        }

        public static InvoiceDetailPaymentDed[] GetAllInvoiceDetailPaymentDed(int? invoiceid)
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
                    cm.CommandText = "odps.od_rps_invoice_deductions";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "invoiceid", invoiceid);

                    List<InvoiceDetailPaymentDed> _list = new List<InvoiceDetailPaymentDed>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceDetailPaymentDed instance = new InvoiceDetailPaymentDed();
                            instance.PcdDate = GetValueFromReader<DateTime?>(dr, 0);
                            instance.DedDescription = GetValueFromReader<string>(dr, 1); ;
                            instance.PcdAmount = GetValueFromReader<decimal?>(dr, 2);
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
        private void CreateEntity()
        {
        }
    }
}
