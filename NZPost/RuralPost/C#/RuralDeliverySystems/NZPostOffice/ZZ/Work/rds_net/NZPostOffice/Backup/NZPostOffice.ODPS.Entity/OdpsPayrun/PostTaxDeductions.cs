//qtdong
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
    [MapInfo("ded_id", "_ded_id", "post_tax_deductions")]
    [MapInfo("ded_description", "_ded_description", "post_tax_deductions")]
    [MapInfo("ded_priority", "_ded_priority", "post_tax_deductions")]
    [MapInfo("pct_id", "_pct_id", "post_tax_deductions")]
    [MapInfo("ded_reference", "_ded_reference", "post_tax_deductions")]
    [MapInfo("ded_type_period", "_ded_type_period", "post_tax_deductions")]
    [MapInfo("ded_percent_gross", "_ded_percent_gross", "post_tax_deductions")]
    [MapInfo("ded_percent_net", "_ded_percent_net", "post_tax_deductions")]
    [MapInfo("ded_percent_start_balance", "_ded_percent_start_balance", "post_tax_deductions")]
    [MapInfo("ded_fixed_amount", "_ded_fixed_amount", "post_tax_deductions")]
    [MapInfo("ded_min_threshold_gross", "_ded_min_threshold_gross", "post_tax_deductions")]
    [MapInfo("ded_max_threshold_net_pct", "_ded_max_threshold_net_pct", "post_tax_deductions")]
    [MapInfo("ded_default_minimum", "_ded_default_minimum", "post_tax_deductions")]
    [MapInfo("ded_start_balance", "_ded_start_balance", "post_tax_deductions")]
    [MapInfo("ded_end_balance", "_ded_end_balance", "post_tax_deductions")]
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "post_tax_deductions")]
    [MapInfo("startbal_flag", "_startbal_flag", "post_tax_deductions")]
    [MapInfo("ded_pay_highest_value", "_ded_pay_highest_value", "post_tax_deductions")]
    [MapInfo("contractor_supplier_no", "_contractor_supplier_no", "t_posttax_deductions_not_applied")]
    [MapInfo("comments", "_t_posttax_deductions_not_applied_comment", "t_posttax_deductions_not_applied")]
    [MapInfo("invoice_id", "_t_posttax_deductions_not_applied_invoice", "t_posttax_deductions_not_applied")]
    [System.Serializable()]

    public class PostTaxDeductions : Entity<PostTaxDeductions>
    {

        #region Business Methods
        [DBField()]
        private int? _ded_id;

        [DBField()]
        private string _ded_description;

        [DBField()]
        private int? _ded_priority;

        [DBField()]
        private int? _pct_id;

        [DBField()]
        private string _ded_reference;

        [DBField()]
        private string _ded_type_period;

        [DBField()]
        private decimal? _ded_percent_gross;

        [DBField()]
        private decimal? _ded_percent_net;

        [DBField()]
        private decimal? _ded_percent_start_balance;

        [DBField()]
        private decimal? _ded_fixed_amount;

        [DBField()]
        private decimal? _ded_min_threshold_gross;

        [DBField()]
        private decimal? _ded_max_threshold_net_pct;

        [DBField()]
        private decimal? _ded_default_minimum;

        [DBField()]
        private decimal? _ded_start_balance;

        [DBField()]
        private decimal? _ded_end_balance;

        [DBField()]
        private int? _contractor_supplier_no;

        [DBField()]
        private int? _startbal_flag;

        [DBField()]
        private int? _ded_pay_highest_value;

        [DBField()]
        private int? _t_posttax_deductions_not_applied_contractor_supplier_no;

        [DBField()]
        private string _t_posttax_deductions_not_applied_comment;

        [DBField()]
        private int? _t_posttax_deductions_not_applied_invoice;

        public virtual int? DedId
        {
            get
            {
                CanReadProperty("DedId", true);
                return _ded_id;
            }
            set
            {
                CanWriteProperty("DedId", true);
                if (_ded_id != value)
                {
                    _ded_id = value;
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

        public virtual int? DedPriority
        {
            get
            {
                CanReadProperty("DedPriority", true);
                return _ded_priority;
            }
            set
            {
                CanWriteProperty("DedPriority", true);
                if (_ded_priority != value)
                {
                    _ded_priority = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PctId
        {
            get
            {
                CanReadProperty("PctId", true);
                return _pct_id;
            }
            set
            {
                CanWriteProperty("PctId", true);
                if (_pct_id != value)
                {
                    _pct_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DedReference
        {
            get
            {
                CanReadProperty("DedReference", true);
                return _ded_reference;
            }
            set
            {
                CanWriteProperty("DedReference", true);
                if (_ded_reference != value)
                {
                    _ded_reference = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DedTypePeriod
        {
            get
            {
                CanReadProperty("DedTypePeriod", true);
                return _ded_type_period;
            }
            set
            {
                CanWriteProperty("DedTypePeriod", true);
                if (_ded_type_period != value)
                {
                    _ded_type_period = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedPercentGross
        {
            get
            {
                CanReadProperty("DedPercentGross", true);
                return _ded_percent_gross;
            }
            set
            {
                CanWriteProperty("DedPercentGross", true);
                if (_ded_percent_gross != value)
                {
                    _ded_percent_gross = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedPercentNet
        {
            get
            {
                CanReadProperty("DedPercentNet", true);
                return _ded_percent_net;
            }
            set
            {
                CanWriteProperty("DedPercentNet", true);
                if (_ded_percent_net != value)
                {
                    _ded_percent_net = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedPercentStartBalance
        {
            get
            {
                CanReadProperty("DedPercentStartBalance", true);
                return _ded_percent_start_balance;
            }
            set
            {
                CanWriteProperty("DedPercentStartBalance", true);
                if (_ded_percent_start_balance != value)
                {
                    _ded_percent_start_balance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedFixedAmount
        {
            get
            {
                CanReadProperty("DedFixedAmount", true);
                return _ded_fixed_amount;
            }
            set
            {
                CanWriteProperty("DedFixedAmount", true);
                if (_ded_fixed_amount != value)
                {
                    _ded_fixed_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedMinThresholdGross
        {
            get
            {
                CanReadProperty("DedMinThresholdGross", true);
                return _ded_min_threshold_gross;
            }
            set
            {
                CanWriteProperty("DedMinThresholdGross", true);
                if (_ded_min_threshold_gross != value)
                {
                    _ded_min_threshold_gross = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedMaxThresholdNetPct
        {
            get
            {
                CanReadProperty("DedMaxThresholdNetPct", true);
                return _ded_max_threshold_net_pct;
            }
            set
            {
                CanWriteProperty("DedMaxThresholdNetPct", true);
                if (_ded_max_threshold_net_pct != value)
                {
                    _ded_max_threshold_net_pct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedDefaultMinimum
        {
            get
            {
                CanReadProperty("DedDefaultMinimum", true);
                return _ded_default_minimum;
            }
            set
            {
                CanWriteProperty("DedDefaultMinimum", true);
                if (_ded_default_minimum != value)
                {
                    _ded_default_minimum = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedStartBalance
        {
            get
            {
                CanReadProperty("DedStartBalance", true);
                return _ded_start_balance;
            }
            set
            {
                CanWriteProperty("DedStartBalance", true);
                if (_ded_start_balance != value)
                {
                    _ded_start_balance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DedEndBalance
        {
            get
            {
                CanReadProperty("DedEndBalance", true);
                return _ded_end_balance;
            }
            set
            {
                CanWriteProperty("DedEndBalance", true);
                if (_ded_end_balance != value)
                {
                    _ded_end_balance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ContractorSupplierNo
        {
            get
            {
                CanReadProperty("ContractorSupplierNo", true);
                return _contractor_supplier_no;
            }
            set
            {
                CanWriteProperty("ContractorSupplierNo", true);
                if (_contractor_supplier_no != value)
                {
                    _contractor_supplier_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? StartbalFlag
        {
            get
            {
                CanReadProperty("StartbalFlag", true);
                return _startbal_flag;
            }
            set
            {
                CanWriteProperty("StartbalFlag", true);
                if (_startbal_flag != value)
                {
                    _startbal_flag = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? DedPayHighestValue
        {
            get
            {
                CanReadProperty("DedPayHighestValue", true);
                return _ded_pay_highest_value;
            }
            set
            {
                CanWriteProperty("DedPayHighestValue", true);
                if (_ded_pay_highest_value != value)
                {
                    _ded_pay_highest_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? TPosttaxDeductionsNotAppliedContractorSupplierNo
        {
            get
            {
                CanReadProperty(true);
                return _t_posttax_deductions_not_applied_contractor_supplier_no;
            }
            set
            {
                CanWriteProperty(true);
                if (_t_posttax_deductions_not_applied_contractor_supplier_no != value)
                {
                    _t_posttax_deductions_not_applied_contractor_supplier_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TPosttaxDeductionsNotAppliedComment
        {
            get
            {
                CanReadProperty("TPosttaxDeductionsNotAppliedComment", true);
                return _t_posttax_deductions_not_applied_comment;
            }
            set
            {
                CanWriteProperty("TPosttaxDeductionsNotAppliedComment", true);
                if (_t_posttax_deductions_not_applied_comment != value)
                {
                    _t_posttax_deductions_not_applied_comment = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? TPosttaxDeductionsNotAppliedInvoice
        {
            get
            {
                CanReadProperty("TPosttaxDeductionsNotAppliedInvoice", true);
                return _t_posttax_deductions_not_applied_invoice;
            }
            set
            {
                CanWriteProperty("TPosttaxDeductionsNotAppliedInvoice", true);
                if (_t_posttax_deductions_not_applied_invoice != value)
                {
                    _t_posttax_deductions_not_applied_invoice = value;
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
        public static PostTaxDeductions NewPostTaxDeductions()
        {
            return Create();
        }

        public static PostTaxDeductions[] GetAllPostTaxDeductions()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT post_tax_deductions.ded_id," +
                                     "post_tax_deductions.ded_description," +
                                     "post_tax_deductions.ded_priority," +
                                     "post_tax_deductions.pct_id," +
                                     "post_tax_deductions.ded_reference," +
                                     "post_tax_deductions.ded_type_period," +
                                     "post_tax_deductions.ded_percent_gross," +
                                     "post_tax_deductions.ded_percent_net," +
                                     "post_tax_deductions.ded_percent_start_balance," +
                                     "post_tax_deductions.ded_fixed_amount," +
                                     "post_tax_deductions.ded_min_threshold_gross," +
                                     "post_tax_deductions.ded_max_threshold_net_pct," +
                                     "post_tax_deductions.ded_default_minimum," +
                                     "post_tax_deductions.ded_start_balance," +
                                     "post_tax_deductions.ded_end_balance," +
                                     "post_tax_deductions.contractor_supplier_no," +
                                     "case when ded_start_balance>0 then 1 else 0 end startbal_flag," +
                                     "post_tax_deductions.ded_pay_highest_value," +
                                     "t_posttax_deductions_not_applied.contractor_supplier_no," +
                                     "t_posttax_deductions_not_applied.comments," +
                                     "t_posttax_deductions_not_applied.invoice_id " +
                                      "FROM odps.post_tax_deductions," +
                                             "odps.t_posttax_deductions_not_applied " +
                                      "WHERE ( post_tax_deductions.ded_id = t_posttax_deductions_not_applied.ded_id )";
                    ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "post_tax_deductions");
                    //GenerateSelectCommandText(cm, "t_posttax_deductions_not_applied");

                    List<PostTaxDeductions> _list = new List<PostTaxDeductions>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PostTaxDeductions instance = new PostTaxDeductions();
                            //instance.StoreFieldValues(dr, "post_tax_deductions");
                            //instance.StoreFieldValues(dr, "t_posttax_deductions_not_applied");
                            instance._ded_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._ded_description = GetValueFromReader<string>(dr, 1);
                            instance._ded_priority = GetValueFromReader<Int32?>(dr, 2);
                            instance._pct_id = GetValueFromReader<Int32?>(dr, 3);
                            instance._ded_reference = GetValueFromReader<string>(dr, 4);
                            instance._ded_type_period = GetValueFromReader<string>(dr, 5);
                            instance._ded_percent_gross = GetValueFromReader<decimal?>(dr, 6);
                            instance._ded_percent_net = GetValueFromReader<decimal?>(dr, 7);
                            instance._ded_percent_start_balance = GetValueFromReader<decimal?>(dr, 8);
                            instance._ded_fixed_amount = GetValueFromReader<decimal?>(dr, 9);
                            instance._ded_min_threshold_gross = GetValueFromReader<decimal?>(dr, 10);
                            instance._ded_max_threshold_net_pct = GetValueFromReader<decimal?>(dr, 11);
                            instance._ded_default_minimum = GetValueFromReader<decimal?>(dr, 12);
                            instance._ded_start_balance = GetValueFromReader<decimal?>(dr, 13);
                            instance._ded_end_balance = GetValueFromReader<decimal?>(dr, 14);
                            instance._contractor_supplier_no = GetValueFromReader<Int32?>(dr, 15);
                            instance._startbal_flag = GetValueFromReader<Int32?>(dr, 16);
                            instance._ded_pay_highest_value = GetValueFromReader<Int32?>(dr, 17);
                            instance._t_posttax_deductions_not_applied_contractor_supplier_no = GetValueFromReader<Int32?>(dr, 18);
                            instance._t_posttax_deductions_not_applied_comment = GetValueFromReader<string>(dr, 19);
                            instance._t_posttax_deductions_not_applied_invoice = GetValueFromReader<Int32?>(dr, 20);

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
