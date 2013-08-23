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
    // TJB  RPCR_056  June-2013: New
    // Gets allowance breakdown information from t_invoice_allowances 
    // for invoice.
    
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("invoice_id", "_invoice_id", "")]
    [MapInfo("alt_key", "_alt_key", "")]
    [MapInfo("alt_description", "_alt_description", "")]
    [MapInfo("alt_value", "_alt_value", "")]
    [System.Serializable()]

    public class InvoiceDetailAllowanceBreakdown : Entity<InvoiceDetailAllowanceBreakdown>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _invoice_id;

        [DBField()]
        private int? _alt_key;

        [DBField()]
        private string _alt_description;

        [DBField()]
        private decimal? _alt_value;

        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty("ContractNo", true);
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

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

        public virtual int? AltKey
        {
            get
            {
                CanReadProperty("AltKey", true);
                return _alt_key;
            }
            set
            {
                CanWriteProperty("AltKey", true);
                if (_alt_key != value)
                {
                    _alt_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AltDescription
        {
            get
            {
                CanReadProperty("AltDescription", true);
                return _alt_description;
            }
            set
            {
                CanWriteProperty("AltDescription", true);
                if (_alt_description != value)
                {
                    _alt_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? AltValue
        {
            get
            {
                CanReadProperty("AltValue", true);
                return _alt_value;
            }
            set
            {
                CanWriteProperty("AltValue", true);
                if (_alt_value != value)
                {
                    _alt_value = value;
                    PropertyHasChanged();
                }
            }
        }

	
        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static InvoiceDetailAllowanceBreakdown NewInvoiceDetailAllowanceBreakdown(int? inInvoiceId)
        {
            return Create(inInvoiceId);
        }

        public static InvoiceDetailAllowanceBreakdown[] GetAllInvoiceDetailAllowanceBreakdown(int? inInvoiceId)
        {
            return Fetch(inInvoiceId).list;
        }
        #endregion

        #region Data Access

        [ServerMethod]
        private void FetchEntity(int? inInvoiceId)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoice_pay_allowance_breakdown";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inInvoiceId", inInvoiceId);
                    
                    List<InvoiceDetailAllowanceBreakdown> _list = new List<InvoiceDetailAllowanceBreakdown>();
                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                InvoiceDetailAllowanceBreakdown instance = new InvoiceDetailAllowanceBreakdown();
                                instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                                instance._invoice_id = GetValueFromReader<Int32?>(dr, 1);
                                instance._alt_key = GetValueFromReader<Int32?>(dr, 2);
                                instance._alt_description = GetValueFromReader<string>(dr, 3);
                                instance._alt_value = GetValueFromReader<decimal?>(dr, 4);

                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        this.sqlCode = -1;
                        this.sqlErrText = e.Message;
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
