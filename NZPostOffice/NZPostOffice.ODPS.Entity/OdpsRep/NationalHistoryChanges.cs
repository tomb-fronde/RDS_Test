using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("nat_ac_id_gst_gl", "_nat_ac_id_gst_gl", "")]
    [MapInfo("nat_ac_id_whtax_gl", "_nat_ac_id_whtax_gl", "")]
    [MapInfo("nat_ac_id_postax_adj_gl", "_nat_ac_id_postax_adj_gl", "")]
    [MapInfo("nat_rural_post_gst_no", "_nat_rural_post_gst_no", "")]
    [MapInfo("nat_gst_rate", "_nat_gst_rate", "")]
    [MapInfo("nat_ird_no", "_nat_ird_no", "")]
    [MapInfo("nat_rural_post_address", "_nat_rural_post_address", "")]
    [MapInfo("nat_rural_post_payer_name", "_nat_rural_post_payer_name", "")]
    [MapInfo("nat_acc_percentage", "_nat_acc_percentage", "")]
    [MapInfo("nat_standard_tax_rate", "_nat_standard_tax_rate", "")]
    [MapInfo("nat_day_of_month", "_nat_day_of_month", "")]
    [MapInfo("nat_message_for_invoice", "_nat_message_for_invoice", "")]
    [MapInfo("nat_net_pct_change_warn", "_nat_net_pct_change_warn", "")]
    [MapInfo("nat_seq_no_for_keys", "_nat_seq_no_for_keys", "")]
    [MapInfo("nat_od_standard_gst_rate", "_nat_od_standard_gst_rate", "")]
    [MapInfo("nat_od_tax_rate_ir13", "_nat_od_tax_rate_ir13", "")]
    [MapInfo("nat_od_tax_rate_no_ir13", "_nat_od_tax_rate_no_ir13", "")]
    [MapInfo("ap_net_pay_clearing_account", "_ap_net_pay_clearing_account", "")]
    [MapInfo("nat_effective_date", "_nat_effective_date", "")]
    [MapInfo("nat_ac_id_contprice_gl", "_nat_ac_id_contprice_gl", "")]
    [MapInfo("nat_ac_id_netpay_gl", "_nat_ac_id_netpay_gl", "")]
    [MapInfo("nat_ac_id_accrualbalance_gl", "_nat_ac_id_accrualbalance_gl", "")]
    [MapInfo("nat_pbu_code_postax_gl", "_nat_pbu_code_postax_gl", "")]
    [MapInfo("nat_pbu_code_whtax_gl", "_nat_pbu_code_whtax_gl", "")]
    [MapInfo("nat_pbu_code_gst_gl", "_nat_pbu_code_gst_gl", "")]
    [MapInfo("nat_pbu_code_netpay_gl", "_nat_pbu_code_netpay_gl", "")]
    [MapInfo("nat_invoice_number_prefix", "_nat_invoice_number_prefix", "")]
    [System.Serializable()]

    public class NationalHistoryChanges : Entity<NationalHistoryChanges>
    {
        #region Business Methods
        [DBField()]
        private int? _nat_ac_id_gst_gl;

        [DBField()]
        private int? _nat_ac_id_whtax_gl;

        [DBField()]
        private int? _nat_ac_id_postax_adj_gl;

        [DBField()]
        private string _nat_rural_post_gst_no;

        [DBField()]
        private decimal? _nat_gst_rate;

        [DBField()]
        private string _nat_ird_no;

        [DBField()]
        private string _nat_rural_post_address;

        [DBField()]
        private string _nat_rural_post_payer_name;

        [DBField()]
        private decimal? _nat_acc_percentage;

        [DBField()]
        private decimal? _nat_standard_tax_rate;

        [DBField()]
        private int? _nat_day_of_month;

        [DBField()]
        private string _nat_message_for_invoice;

        [DBField()]
        private decimal? _nat_net_pct_change_warn;

        [DBField()]
        private int? _nat_seq_no_for_keys;

        [DBField()]
        private decimal? _nat_od_standard_gst_rate;

        [DBField()]
        private decimal? _nat_od_tax_rate_ir13;

        [DBField()]
        private decimal? _nat_od_tax_rate_no_ir13;

        [DBField()]
        private int? _ap_net_pay_clearing_account;

        [DBField()]
        private DateTime? _nat_effective_date;

        [DBField()]
        private int? _nat_ac_id_contprice_gl;

        [DBField()]
        private int? _nat_ac_id_netpay_gl;

        [DBField()]
        private int? _nat_ac_id_accrualbalance_gl;

        [DBField()]
        private int? _nat_pbu_code_postax_gl;

        [DBField()]
        private int? _nat_pbu_code_whtax_gl;

        [DBField()]
        private int? _nat_pbu_code_gst_gl;

        [DBField()]
        private int? _nat_pbu_code_netpay_gl;

        [DBField()]
        private string _nat_invoice_number_prefix;


        public virtual int? NatAcIdGstGl
        {
            get
            {
                CanReadProperty("NatAcIdGstGl", true);
                return _nat_ac_id_gst_gl;
            }
            set
            {
                CanWriteProperty("NatAcIdGstGl", true);
                if (_nat_ac_id_gst_gl != value)
                {
                    _nat_ac_id_gst_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatAcIdGstGl
        {
            get
            {
                return (int)_nat_ac_id_gst_gl;
            }
        }

        public virtual int? NatAcIdWhtaxGl
        {
            get
            {
                CanReadProperty("NatAcIdWhtaxGl", true);
                return _nat_ac_id_whtax_gl;
            }
            set
            {
                CanWriteProperty("NatAcIdWhtaxGl", true);
                if (_nat_ac_id_whtax_gl != value)
                {
                    _nat_ac_id_whtax_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatAcIdWhtaxGl
        {
            get
            {
                return (int)_nat_ac_id_whtax_gl;
            }
        }

        public virtual int? NatAcIdPostaxAdjGl
        {
            get
            {
                CanReadProperty("NatAcIdPostaxAdjGl", true);
                return _nat_ac_id_postax_adj_gl;
            }
            set
            {
                CanWriteProperty("NatAcIdPostaxAdjGl", true);
                if (_nat_ac_id_postax_adj_gl != value)
                {
                    _nat_ac_id_postax_adj_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatAcIdPostaxAdjGl
        {
            get
            {
                return (int)_nat_ac_id_postax_adj_gl;
            }
        }

        public virtual string NatRuralPostGstNo
        {
            get
            {
                CanReadProperty("NatRuralPostGstNo", true);
                return _nat_rural_post_gst_no;
            }
            set
            {
                CanWriteProperty("NatRuralPostGstNo", true);
                if (_nat_rural_post_gst_no != value)
                {
                    _nat_rural_post_gst_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NatGstRate
        {
            get
            {
                CanReadProperty("NatGstRate", true);
                return _nat_gst_rate;
            }
            set
            {
                CanWriteProperty("NatGstRate", true);
                if (_nat_gst_rate != value)
                {
                    _nat_gst_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RENatGstRate
        {
            get
            {
                return (decimal)_nat_gst_rate;
            }
        }

        public virtual string NatIrdNo
        {
            get
            {
                CanReadProperty("NatIrdNo", true);
                return _nat_ird_no;
            }
            set
            {
                CanWriteProperty("NatIrdNo", true);
                if (_nat_ird_no != value)
                {
                    _nat_ird_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NatRuralPostAddress
        {
            get
            {
                CanReadProperty("NatRuralPostAddress", true);
                return _nat_rural_post_address;
            }
            set
            {
                CanWriteProperty("NatRuralPostAddress", true);
                if (_nat_rural_post_address != value)
                {
                    _nat_rural_post_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NatRuralPostPayerName
        {
            get
            {
                CanReadProperty("NatRuralPostPayerName", true);
                return _nat_rural_post_payer_name;
            }
            set
            {
                CanWriteProperty("NatRuralPostPayerName", true);
                if (_nat_rural_post_payer_name != value)
                {
                    _nat_rural_post_payer_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NatAccPercentage
        {
            get
            {
                CanReadProperty("NatAccPercentage", true);
                return _nat_acc_percentage;
            }
            set
            {
                CanWriteProperty("NatAccPercentage", true);
                if (_nat_acc_percentage != value)
                {
                    _nat_acc_percentage = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RENatAccPercentage
        {
            get
            {
                return (decimal)_nat_acc_percentage;
            }
        }

        public virtual decimal? NatStandardTaxRate
        {
            get
            {
                CanReadProperty("NatStandardTaxRate", true);
                return _nat_standard_tax_rate;
            }
            set
            {
                CanWriteProperty("NatStandardTaxRate", true);
                if (_nat_standard_tax_rate != value)
                {
                    _nat_standard_tax_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RENatStandardTaxRate
        {
            get
            {
                return (decimal)_nat_standard_tax_rate;
            }
        }

        public virtual int? NatDayOfMonth
        {
            get
            {
                CanReadProperty("NatDayOfMonth", true);
                return _nat_day_of_month;
            }
            set
            {
                CanWriteProperty("NatDayOfMonth", true);
                if (_nat_day_of_month != value)
                {
                    _nat_day_of_month = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatDayOfMonth
        {
            get
            {
                return (int)_nat_day_of_month;
            }
        }

        public virtual string NatMessageForInvoice
        {
            get
            {
                CanReadProperty("NatMessageForInvoice", true);
                return _nat_message_for_invoice;
            }
            set
            {
                CanWriteProperty("NatMessageForInvoice", true);
                if (_nat_message_for_invoice != value)
                {
                    _nat_message_for_invoice = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NatNetPctChangeWarn
        {
            get
            {
                CanReadProperty("NatNetPctChangeWarn", true);
                return _nat_net_pct_change_warn;
            }
            set
            {
                CanWriteProperty("NatNetPctChangeWarn", true);
                if (_nat_net_pct_change_warn != value)
                {
                    _nat_net_pct_change_warn = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RENatNetPctChangeWarn
        {
            get
            {
                return (decimal)_nat_net_pct_change_warn;
            }
        }

        public virtual int? NatSeqNoForKeys
        {
            get
            {
                CanReadProperty("NatSeqNoForKeys", true);
                return _nat_seq_no_for_keys;
            }
            set
            {
                CanWriteProperty("NatSeqNoForKeys", true);
                if (_nat_seq_no_for_keys != value)
                {
                    _nat_seq_no_for_keys = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatSeqNoForKeys
        {
            get
            {
                return (int)_nat_seq_no_for_keys;
            }
        }

        public virtual decimal? NatOdStandardGstRate
        {
            get
            {
                CanReadProperty("NatOdStandardGstRate", true);
                return _nat_od_standard_gst_rate;
            }
            set
            {
                CanWriteProperty("NatOdStandardGstRate", true);
                if (_nat_od_standard_gst_rate != value)
                {
                    _nat_od_standard_gst_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RENatOdStandardGstRate
        {
            get
            {
                return (decimal)_nat_od_standard_gst_rate;
            }
        }

        public virtual decimal? NatOdTaxRateIr13
        {
            get
            {
                CanReadProperty("NatOdTaxRateIr13", true);
                return _nat_od_tax_rate_ir13;
            }
            set
            {
                CanWriteProperty("NatOdTaxRateIr13", true);
                if (_nat_od_tax_rate_ir13 != value)
                {
                    _nat_od_tax_rate_ir13 = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RENatOdTaxRateIr13
        {
            get
            {
                return (decimal)_nat_od_tax_rate_ir13;
            }
        }

        public virtual decimal? NatOdTaxRateNoIr13
        {
            get
            {
                CanReadProperty("NatOdTaxRateNoIr13", true);
                return _nat_od_tax_rate_no_ir13;
            }
            set
            {
                CanWriteProperty("NatOdTaxRateNoIr13", true);
                if (_nat_od_tax_rate_no_ir13 != value)
                {
                    _nat_od_tax_rate_no_ir13 = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RENatOdTaxRateNoIr13
        {
            get
            {
                return (decimal)_nat_od_tax_rate_no_ir13;
            }
        }

        public virtual int? ApNetPayClearingAccount
        {
            get
            {
                CanReadProperty("ApNetPayClearingAccount", true);
                return _ap_net_pay_clearing_account;
            }
            set
            {
                CanWriteProperty("ApNetPayClearingAccount", true);
                if (_ap_net_pay_clearing_account != value)
                {
                    _ap_net_pay_clearing_account = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REApNetPayClearingAccount
        {
            get
            {
                return (int)_ap_net_pay_clearing_account;
            }
        }

        public virtual DateTime? NatEffectiveDate
        {
            get
            {
                CanReadProperty("NatEffectiveDate", true);
                return _nat_effective_date;
            }
            set
            {
                CanWriteProperty("NatEffectiveDate", true);
                if (_nat_effective_date != value)
                {
                    _nat_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime RENatEffectiveDate
        {
            get
            {
                return (DateTime)_nat_effective_date;
            }
        }

        public virtual int? NatAcIdContpriceGl
        {
            get
            {
                CanReadProperty("NatAcIdContpriceGl", true);
                return _nat_ac_id_contprice_gl;
            }
            set
            {
                CanWriteProperty("NatAcIdContpriceGl", true);
                if (_nat_ac_id_contprice_gl != value)
                {
                    _nat_ac_id_contprice_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatAcIdContpriceGl
        {
            get
            {
                return (int)_nat_ac_id_contprice_gl;
            }
        }

        public virtual int? NatAcIdNetpayGl
        {
            get
            {
                CanReadProperty("NatAcIdNetpayGl", true);
                return _nat_ac_id_netpay_gl;
            }
            set
            {
                CanWriteProperty("NatAcIdNetpayGl", true);
                if (_nat_ac_id_netpay_gl != value)
                {
                    _nat_ac_id_netpay_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatAcIdNetpayGl
        {
            get
            {
                return (int)_nat_ac_id_netpay_gl;
            }
        }

        public virtual int? NatAcIdAccrualbalanceGl
        {
            get
            {
                CanReadProperty("NatAcIdAccrualbalanceGl", true);
                return _nat_ac_id_accrualbalance_gl;
            }
            set
            {
                CanWriteProperty("NatAcIdAccrualbalanceGl", true);
                if (_nat_ac_id_accrualbalance_gl != value)
                {
                    _nat_ac_id_accrualbalance_gl = value;
                    PropertyHasChanged();
                }
            }

        }

        public int RENatAcIdAccrualbalanceGl
        {
            get
            {
                return (int)_nat_ac_id_accrualbalance_gl;
            }
        }

        public virtual int? NatPbuCodePostaxGl
        {
            get
            {
                CanReadProperty("NatPbuCodePostaxGl", true);
                return _nat_pbu_code_postax_gl;
            }
            set
            {
                CanWriteProperty("NatPbuCodePostaxGl", true);
                if (_nat_pbu_code_postax_gl != value)
                {
                    _nat_pbu_code_postax_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatPbuCodePostaxGl
        {
            get
            {
                return (int)_nat_pbu_code_postax_gl;
            }
        }

        public virtual int? NatPbuCodeWhtaxGl
        {
            get
            {
                CanReadProperty("NatPbuCodeWhtaxGl", true);
                return _nat_pbu_code_whtax_gl;
            }
            set
            {
                CanWriteProperty("NatPbuCodeWhtaxGl", true);
                if (_nat_pbu_code_whtax_gl != value)
                {
                    _nat_pbu_code_whtax_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatPbuCodeWhtaxGl
        {
            get
            {
                return (int)_nat_pbu_code_whtax_gl;
            }
        }

        public virtual int? NatPbuCodeGstGl
        {
            get
            {
                CanReadProperty("NatPbuCodeGstGl", true);
                return _nat_pbu_code_gst_gl;
            }
            set
            {
                CanWriteProperty("NatPbuCodeGstGl", true);
                if (_nat_pbu_code_gst_gl != value)
                {
                    _nat_pbu_code_gst_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatPbuCodeGstGl
        {
            get
            {
                return (int)_nat_pbu_code_gst_gl;
            }
        }

        public virtual int? NatPbuCodeNetpayGl
        {
            get
            {
                CanReadProperty("NatPbuCodeNetpayGl", true);
                return _nat_pbu_code_netpay_gl;
            }
            set
            {
                CanWriteProperty("NatPbuCodeNetpayGl", true);
                if (_nat_pbu_code_netpay_gl != value)
                {
                    _nat_pbu_code_netpay_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RENatPbuCodeNetpayGl
        {
            get
            {
                return (int)_nat_pbu_code_netpay_gl;
            }
        }

        public virtual string NatInvoiceNumberPrefix
        {
            get
            {
                CanReadProperty("NatInvoiceNumberPrefix", true);
                return _nat_invoice_number_prefix;
            }
            set
            {
                CanWriteProperty("NatInvoiceNumberPrefix", true);
                if (_nat_invoice_number_prefix != value)
                {
                    _nat_invoice_number_prefix = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        //if(nat_ac_id_whtax_gl [0] =  nat_ac_id_whtax_gl [1],'No Change',string(nat_ac_id_whtax_gl[1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_3]
        //if(nat_ac_id_postax_adj_gl [0] =  nat_ac_id_postax_adj_gl [1],'No Change',string(nat_ac_id_postax_adj_gl[1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_4]
        //if(nat_rural_post_gst_no [0] =  nat_rural_post_gst_no [1],'No Change',string(nat_rural_post_gst_no [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_5]
        //if(nat_gst_rate [0] =  nat_gst_rate [1],'No Change',string(nat_gst_rate [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_6]
        //if(nat_ird_no [0] =  nat_ird_no [1],'No Change',string(nat_ird_no [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_7]
        //if(nat_rural_post_address [0] =  nat_rural_post_address [1],'No Change',string(nat_rural_post_address [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_8]
        //if(nat_rural_post_payer_name [0] =  nat_rural_post_payer_name [1],'No Change',string(nat_rural_post_payer_name [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_9]
        //if(nat_acc_percentage [0] =  nat_acc_percentage [1],'No Change',string(nat_acc_percentage [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_10]
        //if(nat_standard_tax_rate [0] =  nat_standard_tax_rate[1],'No Change',string(nat_standard_tax_rate [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_11]
        //if(nat_day_of_month [0] =  nat_day_of_month[1],'No Change',string(nat_day_of_month [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_12]
        //if(nat_message_for_invoice [0] =  nat_message_for_invoice[1],'No Change',string(nat_message_for_invoice [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_13]
        //if(nat_net_pct_change_warn [0] =  nat_net_pct_change_warn[1],'No Change',string(nat_net_pct_change_warn [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_14]
        //if(nat_seq_no_for_keys [0] =  nat_seq_no_for_keys[1],'No Change',string(nat_seq_no_for_keys [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_15]
        //if(nat_od_standard_gst_rate [0] =  nat_od_standard_gst_rate[1],'No Change',string(nat_od_standard_gst_rate [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_16]
        //if(nat_ac_id_gst_gl [0] =  nat_ac_id_gst_gl [1],'No Change',string(nat_ac_id_gst_gl[1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_17]
        //if(nat_od_tax_rate_ir13 [0] =  nat_od_tax_rate_ir13[1],'No Change',string(nat_od_tax_rate_ir13 [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_18]
        //if(nat_od_tax_rate_no_ir13 [0] =  nat_od_tax_rate_no_ir13[1],'No Change',string(nat_od_tax_rate_no_ir13 [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_19]
        //if(ap_net_pay_clearing_account[0] =  ap_net_pay_clearing_account[1],'No Change',string(ap_net_pay_clearing_account [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_20]
        //if(nat_effective_date [0] =  nat_effective_date[1],'No Change',string(nat_effective_date [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_21]
        //if(nat_ac_id_contprice_gl [0] =  nat_ac_id_contprice_gl[1],'No Change',string(nat_ac_id_contprice_gl [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_22]
        //if(nat_ac_id_netpay_gl [0] =  nat_ac_id_netpay_gl[1],'No Change',string(nat_ac_id_netpay_gl [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_23]
        //if(nat_ac_id_accrualbalance_gl [0] =  nat_ac_id_accrualbalance_gl[1],'No Change',string(nat_ac_id_accrualbalance_gl [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_24]
        //if(nat_pbu_code_postax_gl [0] =  nat_pbu_code_postax_gl[1],'No Change',string(nat_pbu_code_postax_gl [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_25]
        //if(nat_pbu_code_whtax_gl [0] =  nat_pbu_code_whtax_gl[1],'No Change',string(nat_pbu_code_whtax_gl [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_26]
        //if(nat_pbu_code_gst_gl [0] =  nat_pbu_code_gst_gl[1],'No Change',string(nat_pbu_code_gst_gl[1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_27]
        //if(nat_pbu_code_netpay_gl [0] =  nat_pbu_code_netpay_gl[1],'No Change',string(nat_pbu_code_netpay_gl [1]) )

        // needs to implement compute expression manually:
        // compute control name=[compute_28]
        //if(nat_invoice_number_prefix [0] =  nat_invoice_number_prefix[1],'No Change',string(nat_invoice_number_prefix [1]) )

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static NationalHistoryChanges NewNationalHistoryChanges(DateTime? sdate, DateTime? edate)
        {
            return Create(sdate, edate);
        }

        public static NationalHistoryChanges[] GetAllNationalHistoryChanges(DateTime? sdate, DateTime? edate)
        {
            return Fetch(sdate, edate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? sdate, DateTime? edate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_nationalchangeshistory";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);

                    List<NationalHistoryChanges> _list = new List<NationalHistoryChanges>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            NationalHistoryChanges instance = new NationalHistoryChanges();
                            instance._nat_ac_id_gst_gl = GetValueFromReader<Int32?>(dr, 0);
                            instance._nat_ac_id_whtax_gl = GetValueFromReader<Int32?>(dr, 1);
                            instance._nat_ac_id_postax_adj_gl = GetValueFromReader<Int32?>(dr, 2);
                            instance._nat_rural_post_gst_no = GetValueFromReader<string>(dr, 3);
                            instance._nat_gst_rate = GetValueFromReader<decimal?>(dr, 4);
                            instance._nat_ird_no = GetValueFromReader<string>(dr, 5);
                            instance._nat_rural_post_address = GetValueFromReader<string>(dr, 6);
                            instance._nat_rural_post_payer_name = GetValueFromReader<string>(dr, 7);
                            instance._nat_acc_percentage = GetValueFromReader<decimal?>(dr, 8);
                            instance._nat_standard_tax_rate = GetValueFromReader<decimal?>(dr, 9);
                            instance._nat_day_of_month = GetValueFromReader<Int32?>(dr, 10);
                            instance._nat_message_for_invoice = GetValueFromReader<string>(dr, 11);
                            instance._nat_net_pct_change_warn = GetValueFromReader<decimal?>(dr, 12);
                            instance._nat_seq_no_for_keys = GetValueFromReader<Int32?>(dr, 13);
                            instance._nat_od_standard_gst_rate = GetValueFromReader<decimal?>(dr, 14);
                            instance._nat_od_tax_rate_ir13 = GetValueFromReader<decimal?>(dr, 15);
                            instance._nat_od_tax_rate_no_ir13 = GetValueFromReader<decimal?>(dr, 16);
                            instance._ap_net_pay_clearing_account = GetValueFromReader<Int32?>(dr, 17);
                            instance._nat_effective_date = GetValueFromReader<DateTime?>(dr, 18);
                            instance._nat_ac_id_contprice_gl = GetValueFromReader<Int32?>(dr, 19);
                            instance._nat_ac_id_netpay_gl = GetValueFromReader<Int32?>(dr, 20);
                            instance._nat_ac_id_accrualbalance_gl = GetValueFromReader<Int32?>(dr, 21);
                            instance._nat_pbu_code_postax_gl = GetValueFromReader<Int32?>(dr, 22);
                            instance._nat_pbu_code_whtax_gl = GetValueFromReader<Int32?>(dr, 23);
                            instance._nat_pbu_code_gst_gl = GetValueFromReader<Int32?>(dr, 24);
                            instance._nat_pbu_code_netpay_gl = GetValueFromReader<Int32?>(dr, 25);
                            instance._nat_invoice_number_prefix = GetValueFromReader<string>(dr, 26);
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
