using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using NZPostOffice.Shared;
using Metex.Core;
using Metex.Core.Security;


namespace NZPostOffice.ODPS.Entity.Odps
{

    // TJB  RPCR_128  July-2019: Added
    //    ird_contact_phone
    //    ird_contact_email
    //    ird_contact_name
    //    cp_courierpost_defaultcomptype
    //    cp_reachmedia_defaultcomptype
    //    cp_publishing_defaultcomptype

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("nat_id", "_nat_id", "odps.[national]")]
    [MapInfo("ac_id", "_ac_id", "odps.[national]")]
    [MapInfo("nat_ac_id_gst_gl", "_nat_ac_id_gst_gl", "odps.[national]")]

    [MapInfo("nat_ac_id_whtax_gl", "_nat_ac_id_whtax_gl", "odps.[national]")]
    [MapInfo("nat_ac_id_postax_adj_gl", "_nat_ac_id_postax_adj_gl", "odps.[national]")]
    [MapInfo("nat_rural_post_gst_no", "_nat_rural_post_gst_no", "odps.[national]")]

    [MapInfo("nat_gst_rate", "_nat_gst_rate", "odps.[national]")]
    [MapInfo("nat_ird_no", "_nat_ird_no", "odps.[national]")]
    [MapInfo("nat_rural_post_address", "_nat_rural_post_address", "odps.[national]")]

    [MapInfo("nat_rural_post_payer_name", "_nat_rural_post_payer_name", "odps.[national]")]
    [MapInfo("nat_acc_percentage", "_nat_acc_percentage", "odps.[national]")]
    [MapInfo("nat_standard_tax_rate", "_nat_standard_tax_rate", "odps.[national]")]

    [MapInfo("nat_day_of_month", "_nat_day_of_month", "odps.[national]")]
    [MapInfo("nat_message_for_invoice", "_nat_message_for_invoice", "odps.[national]")]
    [MapInfo("nat_net_pct_change_warn", "_nat_net_pct_change_warn", "odps.[national]")]

    [MapInfo("nat_seq_no_for_keys", "_nat_seq_no_for_keys", "odps.[national]")]
    [MapInfo("nat_od_standard_gst_rate", "_nat_od_standard_gst_rate", "odps.[national]")]
    [MapInfo("nat_od_tax_rate_ir13", "_nat_od_tax_rate_ir13", "odps.[national]")]

    [MapInfo("nat_od_tax_rate_no_ir13", "_nat_od_tax_rate_no_ir13", "odps.[national]")]
    [MapInfo("ap_net_pay_clearing_account", "_ap_net_pay_clearing_account", "odps.[national]")]
    [MapInfo("nat_effective_date", "_nat_effective_date", "odps.[national]")]

    [MapInfo("nat_ac_id_contprice_gl", "_nat_ac_id_contprice_gl", "odps.[national]")]
    [MapInfo("nat_ac_id_netpay_gl", "_nat_ac_id_netpay_gl", "odps.[national]")]
    [MapInfo("nat_ac_id_accrualbalance_gl", "_nat_ac_id_accrualbalance_gl", "odps.[national]")]

    [MapInfo("nat_pbu_code_postax_gl", "_nat_pbu_code_postax_gl", "odps.[national]")]
    [MapInfo("nat_pbu_code_whtax_gl", "_nat_pbu_code_whtax_gl", "odps.[national]")]
    [MapInfo("nat_pbu_code_gst_gl", "_nat_pbu_code_gst_gl", "odps.[national]")]

    [MapInfo("nat_pbu_code_netpay_gl", "_nat_pbu_code_netpay_gl", "odps.[national]")]
    [MapInfo("nat_invoice_number_prefix", "_nat_invoice_number_prefix", "odps.[national]")]
    [MapInfo("nat_pbu_code_accrualbalance_gl", "_nat_pbu_code_accrualbalance_gl", "odps.[national]")]

    [MapInfo("nat_freqadj_defaultcomptype", "_nat_freqadj_defaultcomptype", "odps.[national]")]
    [MapInfo("nat_adpost_defaultcomptype", "_nat_adpost_defaultcomptype", "odps.[national]")]
    [MapInfo("nat_contadj_defaultcomptype", "_nat_contadj_defaultcomptype", "odps.[national]")]

    [MapInfo("nat_contallow_defaultcomptype", "_nat_contallow_defaultcomptype", "odps.[national]")]
    [MapInfo("nat_deductions_defaultcomptype", "_nat_deductions_defaultcomptype", "odps.[national]")]
    
    [MapInfo("nat_courierpost_defaultcomptype", "_nat_courierpost_defaultcomptype", "odps.[national]")]
    [MapInfo("nat_xp_defaultcomptype", "_nat_xp_defaultcomptype", "odps.[national]")]
    [MapInfo("nat_pp_defaultcomptype", "_nat_pp_defaultcomptype", "odps.[national]")]

    [MapInfo("cp_courierpost_defaultcomptype", "_cp_courierpost_defaultcomptype", "odps.[national]")]
    [MapInfo("cp_reachmedia_defaultcomptype", "_cp_reachmedia_defaultcomptype", "odps.[national]")]
    [MapInfo("cp_publishing_defaultcomptype", "_cp_publishing_defaultcomptype", "odps.[national]")]

    // TJB  RPCR_128  June-2019: Added
    [MapInfo("ird_contact_phone", "_ird_contact_phone", "odps.[national]")]
    [MapInfo("ird_contact_email", "_ird_contact_email", "odps.[national]")]
    [MapInfo("ird_contact_name", "_ird_contact_name", "odps.[national]")]

    [System.Serializable()]

    public class NationalDetail : Entity<NationalDetail>
    {
        #region Business Methods
        [DBField()]
        private int? _nat_id;

        [DBField()]
        private int? _ac_id;

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

        //[DBField()]
        //private int? _nat_pbu_code_accrualbal;

        [DBField()]
        private int? _nat_freqadj_defaultcomptype;

        [DBField()]
        private int? _nat_adpost_defaultcomptype;

        [DBField()]
        private int? _nat_contadj_defaultcomptype;

        [DBField()]
        private int? _nat_contallow_defaultcomptype;

        [DBField()]
        private int? _nat_deductions_defaultcomptype;

        [DBField()]
        private int? _nat_courierpost_defaultcomptype;

        [DBField()]
        private int? _nat_xp_defaultcomptype;

        [DBField()]
        private int? _nat_pp_defaultcomptype;

        [DBField()]
        private int? _nat_pbu_code_accrualbalance_gl;

        [DBField()]
        private int? _cp_courierpost_defaultcomptype;

        [DBField()]
        private int? _cp_reachmedia_defaultcomptype;

        [DBField()]
        private int? _cp_publishing_defaultcomptype;

        [DBField()]
        private string _ird_contact_phone;

        [DBField()]
        private string _ird_contact_email;

        [DBField()]
        private string _ird_contact_name;

        //-----------------------------------------------------------------------//
        public virtual int? NatId
        {
            get
            {
                CanReadProperty("NatId", true);
                return _nat_id;
            }
            set
            {
                CanWriteProperty("NatId", true);
                if (_nat_id != value)
                {
                    _nat_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AcId
        {
            get
            {
                CanReadProperty("AcId", true);
                return _ac_id;
            }
            set
            {
                CanWriteProperty("AcId", true);
                if (_ac_id != value)
                {
                    _ac_id = value;
                    PropertyHasChanged();
                }
            }
        }

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

        //public virtual int? NatPbuCodeAccrualbal
        //{
        //    get
        //    {
        //        CanReadProperty("NatPbuCodeAccrualbal", true);
        //        return _nat_pbu_code_accrualbal;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NatPbuCodeAccrualbal", true);
        //        if (_nat_pbu_code_accrualbal != value)
        //        {
        //            _nat_pbu_code_accrualbal = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        public virtual int? NatFreqadjDefaultcomptype
        {
            get
            {
                CanReadProperty("NatFreqadjDefaultcomptype", true);
                return _nat_freqadj_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatFreqadjDefaultcomptype", true);
                if (_nat_freqadj_defaultcomptype != value)
                {
                    _nat_freqadj_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatAdpostDefaultcomptype
        {
            get
            {
                CanReadProperty("NatAdpostDefaultcomptype", true);
                return _nat_adpost_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatAdpostDefaultcomptype", true);
                if (_nat_adpost_defaultcomptype != value)
                {
                    _nat_adpost_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatContadjDefaultcomptype
        {
            get
            {
                CanReadProperty("NatContadjDefaultcomptype", true);
                return _nat_contadj_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatContadjDefaultcomptype", true);
                if (_nat_contadj_defaultcomptype != value)
                {
                    _nat_contadj_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatContallowDefaultcomptype
        {
            get
            {
                CanReadProperty("NatContallowDefaultcomptype", true);
                return _nat_contallow_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatContallowDefaultcomptype", true);
                if (_nat_contallow_defaultcomptype != value)
                {
                    _nat_contallow_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatDeductionsDefaultcomptype
        {
            get
            {
                CanReadProperty("NatDeductionsDefaultcomptype", true);
                return _nat_deductions_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatDeductionsDefaultcomptype", true);
                if (_nat_deductions_defaultcomptype != value)
                {
                    _nat_deductions_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatCourierpostDefaultcomptype
        {
            get
            {
                CanReadProperty("NatCourierpostDefaultcomptype", true);
                return _nat_courierpost_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatCourierpostDefaultcomptype", true);
                if (_nat_courierpost_defaultcomptype != value)
                {
                    _nat_courierpost_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatXpDefaultcomptype
        {
            get
            {
                CanReadProperty("NatXpDefaultcomptype", true);
                return _nat_xp_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatXpDefaultcomptype", true);
                if (_nat_xp_defaultcomptype != value)
                {
                    _nat_xp_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatPpDefaultcomptype
        {
            get
            {
                CanReadProperty("NatPpDefaultcomptype", true);
                return _nat_pp_defaultcomptype;
            }
            set
            {
                CanWriteProperty("NatPpDefaultcomptype", true);
                if (_nat_pp_defaultcomptype != value)
                {
                    _nat_pp_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NatPbuCodeAccrualbalanceGl
        {
            get
            {
                CanReadProperty("NatPbuCodeAccrualbalanceGl", true);
                return _nat_pbu_code_accrualbalance_gl;
            }
            set
            {
                CanWriteProperty("NatPbuCodeAccrualbalanceGl", true);
                if (_nat_pbu_code_accrualbalance_gl != value)
                {
                    _nat_pbu_code_accrualbalance_gl = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CpCourierpostDefaultcomptype
        {
            get
            {
                CanReadProperty("CpCourierpostDefaultcomptype", true);
                return _cp_courierpost_defaultcomptype;
            }
            set
            {
                CanWriteProperty("CpCourierpostDefaultcomptype", true);
                if (_cp_courierpost_defaultcomptype != value)
                {
                    _cp_courierpost_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CpReachmediaDefaultcomptype
        {
            get
            {
                CanReadProperty("CpReachmediaDefaultcomptype", true);
                return _cp_reachmedia_defaultcomptype;
            }
            set
            {
                CanWriteProperty("CpReachmediaDefaultcomptype", true);
                if (_cp_reachmedia_defaultcomptype != value)
                {
                    _cp_reachmedia_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CpPublishingDefaultcomptype
        {
            get
            {
                CanReadProperty("CpPublishingDefaultcomptype", true);
                return _cp_publishing_defaultcomptype;
            }
            set
            {
                CanWriteProperty("CpPublishingDefaultcomptype", true);
                if (_cp_publishing_defaultcomptype != value)
                {
                    _cp_publishing_defaultcomptype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string IrdContactPhone
        {
            get
            {
                CanReadProperty("IrdContactPhone", true);
                return _ird_contact_phone;
            }
            set
            {
                CanWriteProperty("IrdContactPhone", true);
                if (_ird_contact_phone != value)
                {
                    _ird_contact_phone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string IrdContactEmail
        {
            get
            {
                CanReadProperty("IrdContactEmail", true);
                return _ird_contact_email;
            }
            set
            {
                CanWriteProperty("IrdContactEmail", true);
                if (_ird_contact_email != value)
                {
                    _ird_contact_email = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string IrdContactName
        {
            get
            {
                CanReadProperty("IrdContactName", true);
                return _ird_contact_name;
            }
            set
            {
                CanWriteProperty("IrdContactName", true);
                if (_ird_contact_name != value)
                {
                    _ird_contact_name = value;
                    PropertyHasChanged();
                }
            }
        }

        /*****************************************************************************/
        protected override object GetIdValue()
        {
            return _nat_id + " ";
        }
        #endregion

        #region Factory Methods
        public static NationalDetail NewNationalDetail(int? a_national_id)
        {
            return Create(a_national_id);
        }

        public static NationalDetail[] GetAllNationalDetail(int? a_national_id)
        {
            return Fetch(a_national_id).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? a_national_id)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "a_national_id", a_national_id);
                    cm.CommandText = "SELECT nat_od_tax_rate_ir13 "
                                    + "    , ap_net_pay_clearing_account "
                                    + "    , nat_effective_date "
                                    + "    , nat_xp_defaultcomptype "
                                    + "    , nat_id "
                                    + "    , ac_id "
                                    + "    , nat_ac_id_gst_gl "
                                    + "    , nat_ac_id_whtax_gl "
                                    + "    , nat_ac_id_postax_adj_gl "
                                    + "    , nat_rural_post_gst_no "
                                    + "    , nat_gst_rate "
                                    + "    , nat_ird_no "
                                    + "    , nat_rural_post_address "
                                    + "    , nat_rural_post_payer_name "
                                    + "    , nat_acc_percentage "
                                    + "    , nat_standard_tax_rate "
                                    + "    , nat_day_of_month "
                                    + "    , nat_message_for_invoice "
                                    + "    , nat_net_pct_change_warn "
                                    + "    , nat_seq_no_for_keys "
                                    + "    , nat_od_standard_gst_rate "
                                    + "    , nat_od_tax_rate_no_ir13 "
                                    + "    , nat_ac_id_contprice_gl "
                                    + "    , nat_ac_id_netpay_gl "
                                    + "    , nat_ac_id_accrualbalance_gl "
                                    + "    , nat_pbu_code_postax_gl "
                                    + "    , nat_pbu_code_whtax_gl "
                                    + "    , nat_pbu_code_gst_gl "
                                    + "    , nat_pbu_code_netpay_gl "
                                    + "    , nat_invoice_number_prefix "
                                    + "    , nat_pbu_code_accrualbalance_gl "
                                    + "    , nat_freqadj_defaultcomptype "
                                    + "    , nat_adpost_defaultcomptype "
                                    + "    , nat_contadj_defaultcomptype "
                                    + "    , nat_contallow_defaultcomptype "
                                    + "    , nat_deductions_defaultcomptype "
                                    + "    , nat_courierpost_defaultcomptype "
                                    + "    , nat_pp_defaultcomptype "
                                    + "    , cp_courierpost_defaultcomptype "
                                    + "    , cp_reachmedia_defaultcomptype "
                                    + "    , cp_publishing_defaultcomptype "
                                    + "    , ird_contact_phone "
                                    + "    , ird_contact_email "
                                    + "    , ird_contact_name "
                                    + " FROM odps.[national] "
                                    + " WHERE nat_id = :a_national_id";
                    //GenerateSelectCommandText(cm, "national");

                    List<NationalDetail> _list = new List<NationalDetail>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            NationalDetail instance = new NationalDetail();
                            //instance.StoreFieldValues(dr, "odps.national");
                            instance._nat_od_tax_rate_ir13 = GetValueFromReader<decimal?>(dr, 0);
                            instance._ap_net_pay_clearing_account = GetValueFromReader<Int32?>(dr, 1);
                            instance._nat_effective_date = GetValueFromReader<DateTime?>(dr, 2);
                            instance._nat_xp_defaultcomptype = GetValueFromReader<Int32?>(dr, 3);
                            instance._nat_id = GetValueFromReader<Int32?>(dr, 4);
                            instance._ac_id = GetValueFromReader<Int32?>(dr, 5);
                            instance._nat_ac_id_gst_gl = GetValueFromReader<Int32?>(dr, 6);
                            instance._nat_ac_id_whtax_gl = GetValueFromReader<Int32?>(dr, 7);
                            instance._nat_ac_id_postax_adj_gl = GetValueFromReader<Int32?>(dr, 8);
                            instance._nat_rural_post_gst_no = GetValueFromReader<string>(dr, 9);
                            instance._nat_gst_rate = GetValueFromReader<decimal?>(dr, 10);
                            instance._nat_ird_no = GetValueFromReader<string>(dr, 11);
                            instance._nat_rural_post_address = GetValueFromReader<string>(dr, 12);
                            instance._nat_rural_post_payer_name = GetValueFromReader<string>(dr, 13);
                            instance._nat_acc_percentage = GetValueFromReader<decimal?>(dr, 14);
                            instance._nat_standard_tax_rate = GetValueFromReader<decimal?>(dr, 15);
                            instance._nat_day_of_month = GetValueFromReader<Int32?>(dr, 16);
                            instance._nat_message_for_invoice = GetValueFromReader<string>(dr, 17);
                            instance._nat_net_pct_change_warn = GetValueFromReader<decimal?>(dr, 18);
                            instance._nat_seq_no_for_keys = GetValueFromReader<Int32?>(dr, 19);
                            instance._nat_od_standard_gst_rate = GetValueFromReader<decimal?>(dr, 20);
                            instance._nat_od_tax_rate_no_ir13 = GetValueFromReader<decimal?>(dr, 21);
                            instance._nat_ac_id_contprice_gl = GetValueFromReader<Int32?>(dr, 22);
                            instance._nat_ac_id_netpay_gl = GetValueFromReader<Int32?>(dr, 23);
                            instance._nat_ac_id_accrualbalance_gl = GetValueFromReader<Int32?>(dr, 24);
                            instance._nat_pbu_code_postax_gl = GetValueFromReader<Int32?>(dr, 25);
                            instance._nat_pbu_code_whtax_gl = GetValueFromReader<Int32?>(dr, 26);
                            instance._nat_pbu_code_gst_gl = GetValueFromReader<Int32?>(dr, 27);
                            instance._nat_pbu_code_netpay_gl = GetValueFromReader<Int32?>(dr, 28);
                            instance._nat_invoice_number_prefix = GetValueFromReader<string>(dr, 29);
                            instance._nat_pbu_code_accrualbalance_gl = GetValueFromReader<Int32?>(dr, 30);
                            instance._nat_freqadj_defaultcomptype = GetValueFromReader<Int32?>(dr, 31);
                            instance._nat_adpost_defaultcomptype = GetValueFromReader<Int32?>(dr, 32);
                            instance._nat_contadj_defaultcomptype = GetValueFromReader<Int32?>(dr, 33);
                            instance._nat_contallow_defaultcomptype = GetValueFromReader<Int32?>(dr, 34);
                            instance._nat_deductions_defaultcomptype = GetValueFromReader<Int32?>(dr, 35);
                            instance._nat_courierpost_defaultcomptype = GetValueFromReader<Int32?>(dr, 36);
                            instance._nat_pp_defaultcomptype = GetValueFromReader<Int32?>(dr, 37);
                            instance._cp_courierpost_defaultcomptype = GetValueFromReader<Int32?>(dr, 38);
                            instance._cp_reachmedia_defaultcomptype = GetValueFromReader<Int32?>(dr, 39);
                            instance._cp_publishing_defaultcomptype = GetValueFromReader<Int32?>(dr, 40);
                            instance._ird_contact_phone = GetValueFromReader<string>(dr, 41);
                            instance._ird_contact_email = GetValueFromReader<string>(dr, 42);
                            instance._ird_contact_name = GetValueFromReader<string>(dr, 43);
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
            if (string.Compare(StaticMessage.StringParm, "New") != 0)
            {
                using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
                {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "odps.[national]", ref pList))
                {
                    cm.CommandText += "Where [national].nat_id = @nat_id ";
                    pList.Add(cm, "nat_id", GetInitialValue("_nat_id"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
                }
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
                if (GenerateInsertCommandText(cm, "odps.[national]", pList))
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
                    cm.CommandText = "DELETE FROM [national] "
                                      + "WHERE " + "[national].nat_id = @nat_id ";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "nat_id", GetInitialValue("_nat_id"));

                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? nat_id)
        {
            _nat_id = nat_id;
        }
    }
}
