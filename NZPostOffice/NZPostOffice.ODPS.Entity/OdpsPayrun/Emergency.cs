using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsPayrun
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contractor_supplier_no", "_payment_contractor_supplier_no", "payment")]
    [MapInfo("contract_no", "_payment_contract_no", "payment")]
    [MapInfo("invoice_date", "_payment_invoice_date", "payment")]
    [MapInfo("witholding_tax_rate_applied", "_payment_witholding_tax_rate_applied", "payment")]
    [MapInfo("invoice_no", "_payment_invoice_no", "payment")]
    [MapInfo("pc_amount", "_payment_component_pc_amount", "payment_component")]
    [MapInfo("comments", "_payment_component_comments", "payment_component")]
    [MapInfo("pct_description", "_payment_component_type_pct_description", "payment_component_type")]
    [MapInfo("pc_id", "_payment_component_pc_id", "payment_component")]
    [MapInfo("pct_id", "_payment_component_pct_id", "payment_component")]
    [System.Serializable()]

    public class Emergency : Entity<Emergency>
    {

        #region Business Methods
        [DBField()]
        private int? _payment_contractor_supplier_no;

        [DBField()]
        private int? _payment_contract_no;

        [DBField()]
        private DateTime? _payment_invoice_date;

        [DBField()]
        private decimal? _payment_witholding_tax_rate_applied;

        [DBField()]
        private int? _payment_invoice_no;

        [DBField()]
        private decimal? _payment_component_pc_amount;

        [DBField()]
        private string _payment_component_comments;

        [DBField()]
        private string _payment_component_type_pct_description;

        [DBField()]
        private int? _payment_component_pc_id;

        [DBField()]
        private int? _payment_component_pct_id;

        public virtual int? PaymentContractorSupplierNo
        {
            get
            {
                CanReadProperty("PaymentContractorSupplierNo", true);
                return _payment_contractor_supplier_no;
            }
            set
            {
                CanWriteProperty("PaymentContractorSupplierNo", true);
                if (_payment_contractor_supplier_no != value)
                {
                    _payment_contractor_supplier_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PaymentContractNo
        {
            get
            {
                CanReadProperty("PaymentContractNo", true);
                return _payment_contract_no;
            }
            set
            {
                CanWriteProperty("PaymentContractNo", true);
                if (_payment_contract_no != value)
                {
                    _payment_contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? PaymentInvoiceDate
        {
            get
            {
                CanReadProperty("PaymentInvoiceDate", true);
                return _payment_invoice_date;
            }
            set
            {
                CanWriteProperty("PaymentInvoiceDate", true);
                if (_payment_invoice_date != value)
                {
                    _payment_invoice_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? PaymentWitholdingTaxRateApplied
        {
            get
            {
                CanReadProperty("PaymentWitholdingTaxRateApplied", true);
                return _payment_witholding_tax_rate_applied;
            }
            set
            {
                CanWriteProperty("PaymentWitholdingTaxRateApplied", true);
                if (_payment_witholding_tax_rate_applied != value)
                {
                    _payment_witholding_tax_rate_applied = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PaymentInvoiceNo
        {
            get
            {
                CanReadProperty("PaymentInvoiceNo", true);
                return _payment_invoice_no;
            }
            set
            {
                CanWriteProperty("PaymentInvoiceNo", true);
                if (_payment_invoice_no != value)
                {
                    _payment_invoice_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? PaymentComponentPcAmount
        {
            get
            {
                CanReadProperty("PaymentComponentPcAmount", true);
                return _payment_component_pc_amount;
            }
            set
            {
                CanWriteProperty("PaymentComponentPcAmount", true);
                if (_payment_component_pc_amount != value)
                {
                    _payment_component_pc_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PaymentComponentComments
        {
            get
            {
                CanReadProperty("PaymentComponentComments", true);
                return _payment_component_comments;
            }
            set
            {
                CanWriteProperty("PaymentComponentComments", true);
                if (_payment_component_comments != value)
                {
                    _payment_component_comments = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PaymentComponentTypePctDescription
        {
            get
            {
                CanReadProperty("PaymentComponentTypePctDescription", true);
                return _payment_component_type_pct_description;
            }
            set
            {
                CanWriteProperty("PaymentComponentTypePctDescription", true);
                if (_payment_component_type_pct_description != value)
                {
                    _payment_component_type_pct_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PaymentComponentPcId
        {
            get
            {
                CanReadProperty("PaymentComponentPcId", true);
                return _payment_component_pc_id;
            }
            set
            {
                CanWriteProperty("PaymentComponentPcId", true);
                if (_payment_component_pc_id != value)
                {
                    _payment_component_pc_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PaymentComponentPctId
        {
            get
            {
                CanReadProperty("PaymentComponentPctId", true);
                return _payment_component_pct_id;
            }
            set
            {
                CanWriteProperty("PaymentComponentPctId", true);
                if (_payment_component_pct_id != value)
                {
                    _payment_component_pct_id = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _payment_component_pc_id);
        }
        #endregion

        #region Factory Methods
        public static Emergency NewEmergency(DateTime? edate, int? lcontract)
        {
            return Create(edate, lcontract);
        }

        public static Emergency[] GetAllEmergency(DateTime? edate, int? lcontract)
        {
            return Fetch(edate, lcontract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? edate, int? lcontract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT  payment.contractor_supplier_no ," +
                    "payment.contract_no ," +
                    "payment.invoice_date ," +
                    "payment.witholding_tax_rate_applied ," +
                    "payment.invoice_no ," +
                    "payment_component.pc_amount ," +
                    "payment_component.comments ," +
                    "payment_component_type.pct_description ," +
                    "payment_component.pc_id ," +
                    "payment_component.pct_id" +
                    "FROM odps.payment ," +
                    "odps.payment_component ," +
                    "odps.payment_component_type " +
                    " WHERE ( payment_component.invoice_id = payment.invoice_id ) and " +
                    " ( payment_component_type.pct_id = payment_component.pct_id ) and " +
                    " (( payment.invoice_date = @edate ) and" +
                    " ( payment.contract_no = @lcontract ))";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "edate", edate);
                    pList.Add(cm, "lcontract", lcontract);
                    //GenerateSelectCommandText(cm, "payment");
                    //GenerateSelectCommandText(cm, "payment_component");
                    //GenerateSelectCommandText(cm, "payment_component_type");

                    List<Emergency> _list = new List<Emergency>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Emergency instance = new Emergency();
                            //instance.StoreFieldValues(dr, "payment");
                            //instance.StoreFieldValues(dr, "payment_component");
                            //instance.StoreFieldValues(dr, "payment_component_type");
                            instance._payment_contractor_supplier_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._payment_contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._payment_invoice_date = GetValueFromReader<DateTime?>(dr, 2);
                            instance._payment_witholding_tax_rate_applied = GetValueFromReader<decimal?>(dr, 3);
                            instance._payment_invoice_no = GetValueFromReader<Int32?>(dr, 4);
                            instance._payment_component_pc_amount = GetValueFromReader<decimal?>(dr, 5);
                            instance._payment_component_comments = GetValueFromReader<string>(dr, 6);
                            instance._payment_component_type_pct_description = GetValueFromReader<string>(dr, 7);
                            instance._payment_component_pc_id = GetValueFromReader<Int32?>(dr, 8);
                            instance._payment_component_pct_id = GetValueFromReader<Int32?>(dr, 9);
                            instance.MarkOld();
                            instance.StoreInitialValues();
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
                if (GenerateUpdateCommandText(cm, "payment_component", ref pList))
                {
                    cm.CommandText += " WHERE  payment_component.pc_amount = @pc_amount AND " +
                        "payment_component.pct_id = @pct_id ";

                    pList.Add(cm, "pc_amount", GetInitialValue("_payment_component_pc_amount"));
                    pList.Add(cm, "pct_id", GetInitialValue("_payment_component_pct_id"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
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
                if (GenerateInsertCommandText(cm, "payment_component", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
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
                    pList.Add(cm, "pc_id", GetInitialValue("_payment_component_pc_id"));
                    cm.CommandText = "DELETE FROM payment_component WHERE " +
                    "payment_component.pc_id = @pc_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? payment_component_pc_id)
        {
            _payment_component_pc_id = payment_component_pc_id;
        }
    }
}
