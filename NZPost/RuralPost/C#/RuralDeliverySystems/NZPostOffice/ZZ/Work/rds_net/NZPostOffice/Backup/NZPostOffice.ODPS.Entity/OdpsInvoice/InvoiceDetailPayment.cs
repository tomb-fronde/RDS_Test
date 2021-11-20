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
    [MapInfo("m_standard", "_m_standard", "")]
    [MapInfo("m_allowance", "_m_allowance", "")]
    [MapInfo("m_taxable_adjustments", "_m_taxable_adjustments", "")]
    [MapInfo("m_gst_rate", "_m_gst_rate", "")]
    [MapInfo("m_gst_value", "_m_gst_value", "")]
    [MapInfo("m_wtax_rate", "_m_wtax_rate", "")]
    [MapInfo("m_wtax_value", "_m_wtax_value", "")]
    [MapInfo("m_adj_notax", "_m_adj_notax", "")]
    [MapInfo("y_standard", "_y_standard", "")]
    [MapInfo("y_allowance", "_y_allowance", "")]
    [MapInfo("y_taxable_adjustments", "_y_taxable_adjustments", "")]
    [MapInfo("y_gst_value", "_y_gst_value", "")]
    [MapInfo("y_wtax_value", "_y_wtax_value", "")]
    [MapInfo("y_adj_notax", "_y_adj_notax", "")]
    [System.Serializable()]

    public class InvoiceDetailPayment : Entity<InvoiceDetailPayment>
    {
        #region Business Methods
        [DBField()]
        private decimal? _m_standard;

        [DBField()]
        private decimal? _m_allowance;

        [DBField()]
        private decimal? _m_taxable_adjustments;

        [DBField()]
        private decimal? _m_gst_rate;

        [DBField()]
        private decimal? _m_gst_value;

        [DBField()]
        private decimal? _m_wtax_rate;

        [DBField()]
        private decimal? _m_wtax_value;

        [DBField()]
        private decimal? _m_adj_notax;

        [DBField()]
        private decimal? _y_standard;

        [DBField()]
        private decimal? _y_allowance;

        [DBField()]
        private decimal? _y_taxable_adjustments;

        [DBField()]
        private decimal? _y_gst_value;

        [DBField()]
        private decimal? _y_wtax_value;

        [DBField()]
        private decimal? _y_adj_notax;

        public virtual decimal? MStandard
        {
            get
            {
                CanReadProperty("MStandard", true);
                return _m_standard;
            }
            set
            {
                CanWriteProperty("MStandard", true);
                if (_m_standard != value)
                {
                    _m_standard = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMStandard
        {
            get
            {
                return (decimal)_m_standard;
            }
        }

        public virtual decimal? MAllowance
        {
            get
            {
                CanReadProperty("MAllowance", true);
                return _m_allowance;
            }
            set
            {
                CanWriteProperty("MAllowance", true);
                if (_m_allowance != value)
                {
                    _m_allowance = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMAllowance
        {
            get
            {
                return (decimal)_m_allowance;
            }
        }

        public virtual decimal? MTaxableAdjustments
        {
            get
            {
                CanReadProperty("MTaxableAdjustments", true);
                return _m_taxable_adjustments;
            }
            set
            {
                CanWriteProperty("MTaxableAdjustments", true);
                if (_m_taxable_adjustments != value)
                {
                    _m_taxable_adjustments = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMTaxableAdjustments
        {
            get
            {
                return (decimal)_m_taxable_adjustments;
            }
        }

        public virtual decimal? MGstRate
        {
            get
            {
                CanReadProperty("MGstRate", true);
                return _m_gst_rate;
            }
            set
            {
                CanWriteProperty("MGstRate", true);
                if (_m_gst_rate != value)
                {
                    _m_gst_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMGstRate
        {
            get
            {
                return (decimal)_m_gst_rate;
            }
        }

        public virtual decimal? MGstValue
        {
            get
            {
                CanReadProperty("MGstValue", true);
                return _m_gst_value;
            }
            set
            {
                CanWriteProperty("MGstValue", true);
                if (_m_gst_value != value)
                {
                    _m_gst_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMGstValue
        {
            get
            {
                return (decimal)_m_gst_value;
            }
        }

        public virtual decimal? MWtaxRate
        {
            get
            {
                CanReadProperty("MWtaxRate", true);
                return _m_wtax_rate;
            }
            set
            {
                CanWriteProperty("MWtaxRate", true);
                if (_m_wtax_rate != value)
                {
                    _m_wtax_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMWtaxRate
        {
            get
            {
                return (decimal)_m_wtax_rate;
            }
        }

        public virtual decimal? MWtaxValue
        {
            get
            {
                CanReadProperty("MWtaxValue", true);
                return _m_wtax_value;
            }
            set
            {
                CanWriteProperty("MWtaxValue", true);
                if (_m_wtax_value != value)
                {
                    _m_wtax_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMWtaxValue
        {
            get
            {
                return (decimal)_m_wtax_value;
            }
        }

        public virtual decimal? MAdjNotax
        {
            get
            {
                CanReadProperty("MAdjNotax", true);
                return _m_adj_notax;
            }
            set
            {
                CanWriteProperty("MAdjNotax", true);
                if (_m_adj_notax != value)
                {
                    _m_adj_notax = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REMAdjNotax
        {
            get
            {
                return (decimal)_m_adj_notax;
            }
        }

        public virtual decimal? YStandard
        {
            get
            {
                CanReadProperty("YStandard", true);
                return _y_standard;
            }
            set
            {
                CanWriteProperty("YStandard", true);
                if (_y_standard != value)
                {
                    _y_standard = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REYStandard
        {
            get
            {
                return (decimal)_y_standard;
            }
        }

        public virtual decimal? YAllowance
        {
            get
            {
                CanReadProperty("YAllowance", true);
                return _y_allowance;
            }
            set
            {
                CanWriteProperty("YAllowance", true);
                if (_y_allowance != value)
                {
                    _y_allowance = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REYAllowance
        {
            get
            {
                return (decimal)_y_allowance;
            }
        }

        public virtual decimal? YTaxableAdjustments
        {
            get
            {
                CanReadProperty("YTaxableAdjustments", true);
                return _y_taxable_adjustments;
            }
            set
            {
                CanWriteProperty("YTaxableAdjustments", true);
                if (_y_taxable_adjustments != value)
                {
                    _y_taxable_adjustments = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REYTaxableAdjustments
        {
            get
            {
                return (decimal)_y_taxable_adjustments;
            }
        }

        public virtual decimal? YGstValue
        {
            get
            {
                CanReadProperty("YGstValue", true);
                return _y_gst_value;
            }
            set
            {
                CanWriteProperty("YGstValue", true);
                if (_y_gst_value != value)
                {
                    _y_gst_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REYGstValue
        {
            get
            {
                return (decimal)_y_gst_value;
            }
        }

        public virtual decimal? YWtaxValue
        {
            get
            {
                CanReadProperty("YWtaxValue", true);
                return _y_wtax_value;
            }
            set
            {
                CanWriteProperty("YWtaxValue", true);
                if (_y_wtax_value != value)
                {
                    _y_wtax_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REYWtaxValue
        {
            get
            {
                return (decimal)_y_wtax_value;
            }
        }

        public virtual decimal? YAdjNotax
        {
            get
            {
                CanReadProperty("YAdjNotax", true);
                return _y_adj_notax;
            }
            set
            {
                CanWriteProperty("YAdjNotax", true);
                if (_y_adj_notax != value)
                {
                    _y_adj_notax = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REYAdjNotax
        {
            get
            {
                return (decimal)_y_adj_notax;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[m_total_before_tax]
        private decimal? _m_total_before_tax;

        public decimal? MTotalBeforeTax
        {
            get
            {
                _m_total_before_tax = _m_standard + _m_allowance + _m_taxable_adjustments;
                return _m_total_before_tax;
            }
        }

        public decimal REMTotalBeforeTax
        {
            get
            {
                _m_total_before_tax = _m_standard + _m_allowance + _m_taxable_adjustments;
                return (decimal)_m_total_before_tax;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[y_total_before_tax]
        private decimal? _y_total_before_tax;

        public decimal? YTotalBeforeTax
        {
            get
            {
                _y_total_before_tax = _y_standard + _y_allowance + _y_taxable_adjustments;
                return _y_total_before_tax;
            }
        }

        public decimal REYTotalBeforeTax
        {
            get
            {
                _y_total_before_tax = _y_standard + _y_allowance + _y_taxable_adjustments;
                return (decimal)_y_total_before_tax;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_1]
        private decimal? _compute_1;

        public decimal? Compute1
        {
            get
            {
                //!return (_m_total_before_tax == null ? 0 : _m_total_before_tax) + _m_gst_value - _m_wtax_value - _m_adj_notax;
                return (MTotalBeforeTax == null ? 0 : MTotalBeforeTax) + _m_gst_value - _m_wtax_value - _m_adj_notax;
            }
        }

        public decimal RECompute1
        {
            get
            {
                //!return (decimal)(_m_total_before_tax + _m_gst_value - _m_wtax_value - _m_adj_notax);
                return (decimal)(MTotalBeforeTax.GetValueOrDefault() + _m_gst_value - _m_wtax_value - _m_adj_notax);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        private decimal? _compute_2;

        public decimal? Compute2
        {
            get
            {
                //!return (_y_total_before_tax == null ? 0 : _y_total_before_tax) + _y_gst_value - _y_wtax_value - _y_adj_notax;
                return (YTotalBeforeTax == null ? 0 : YTotalBeforeTax) + _y_gst_value - _y_wtax_value - _y_adj_notax;
            }
        }

        public decimal RECompute2
        {
            get
            {
                return (decimal)(YTotalBeforeTax.GetValueOrDefault() + _y_gst_value - _y_wtax_value - _y_adj_notax);
            }
        }

        private int? _invoiceId;
        public int? InvoiceId
        {
            get { return _invoiceId; }
            set { _invoiceId = value; }
        }
	
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
        public static InvoiceDetailPayment NewInvoiceDetailPayment(int? invoiceid, DateTime? enddate, int? insupplier, int? incontract_no)
        {
            return Create(invoiceid, enddate, insupplier, incontract_no);
        }

        public static InvoiceDetailPayment[] GetAllInvoiceDetailPayment(int? invoiceid, DateTime? enddate, int? insupplier, int? incontract_no)
        {
            return Fetch(invoiceid, enddate, insupplier, incontract_no).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? invoiceid, DateTime? enddate, int? insupplier, int? incontract_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoice_pay";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "invoiceid", invoiceid);
                    pList.Add(cm, "enddate", enddate);
                    pList.Add(cm, "insupplier", insupplier);
                    pList.Add(cm, "incontract_no", incontract_no);

                    List<InvoiceDetailPayment> _list = new List<InvoiceDetailPayment>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceDetailPayment instance = new InvoiceDetailPayment();
                            instance.MStandard = GetValueFromReader<decimal?>(dr, 0);
                            instance.MAllowance = GetValueFromReader<decimal?>(dr, 1);
                            instance.MTaxableAdjustments = GetValueFromReader<decimal?>(dr, 2);
                            instance.MGstRate = GetValueFromReader<decimal?>(dr, 3);
                            instance.MGstValue = GetValueFromReader<decimal?>(dr, 4);
                            instance.MWtaxRate = GetValueFromReader<decimal?>(dr, 5);
                            instance.MWtaxValue = GetValueFromReader<decimal?>(dr, 6);
                            instance.MAdjNotax = GetValueFromReader<decimal?>(dr, 7);
                            instance.YStandard = GetValueFromReader<decimal?>(dr, 8);
                            instance.YAllowance = GetValueFromReader<decimal?>(dr, 9);
                            instance.YTaxableAdjustments = GetValueFromReader<decimal?>(dr, 10);
                            instance.YGstValue = GetValueFromReader<decimal?>(dr, 11);
                            instance.YWtaxValue = GetValueFromReader<decimal?>(dr, 12);
                            instance.YAdjNotax = GetValueFromReader<decimal?>(dr, 13);

                            instance._contractNo = incontract_no;
                            instance._contractorNo = insupplier;
                            instance._invoiceId = invoiceid;

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
