using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_041  Nov-2012
    // Changed Reliefweeks to be obtained from database
    
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("num_rows", "_num_rows", "")]
    [MapInfo("distance", "_distance", "")]
    [MapInfo("boxes", "_boxes", "")]
    [MapInfo("rural_bags", "_rural_bags", "")]
    [MapInfo("other_bags", "_other_bags", "")]
    [MapInfo("private_bags", "_private_bags", "")]
    [MapInfo("post_offices", "_post_offices", "")]
    [MapInfo("no_cmbs", "_no_cmbs", "")]
    [MapInfo("no_cmb_customers", "_no_cmb_customers", "")]
    [MapInfo("del_hrs", "_del_hrs", "")]
    [MapInfo("proc_hrs", "_proc_hrs", "")]
    [MapInfo("mail_volume", "_mail_volume", "")]
    [MapInfo("extn_effective_date", "_extn_effective_date", "")]
    [MapInfo("extn_distance", "_extn_distance", "")]
    [MapInfo("extn_boxes", "_extn_boxes", "")]
    [MapInfo("extn_rural_bags", "_extn_rural_bags", "")]
    [MapInfo("extn_other_bags", "_extn_other_bags", "")]
    [MapInfo("extn_private_bags", "_extn_private_bags", "")]
    [MapInfo("extn_post_offices", "_extn_post_offices", "")]
    [MapInfo("extn_no_cmbs", "_extn_no_cmbs", "")]
    [MapInfo("extn_no_cmb_customers", "_extn_no_cmb_customers", "")]
    [MapInfo("extn_del_hrs", "_extn_del_hrs", "")]
    [MapInfo("extn_proc_hrs", "_extn_proc_hrs", "")]
    [MapInfo("extn_mail_volume", "_extn_mail_volume", "")]
    [MapInfo("extn_reason", "_extn_reason", "")]
    [MapInfo("no_del_days_year", "_no_del_days_year", "")]
    [MapInfo("delivery_wage_rate", "_delivery_wage_rate", "")]
    [MapInfo("repairsmaint", "_repairsmaint", "")]
    [MapInfo("typestube", "_typestube", "")]
    [MapInfo("vehicalallow", "_vehicalallow", "")]
    [MapInfo("accrate", "_accrate", "")]
    [MapInfo("rr_item_proc_rate_per_hr", "_rr_item_proc_rate_per_hr", "")]
    [MapInfo("fuelrate", "_fuelrate", "")]
    [MapInfo("consumptionrate", "_consumptionrate", "")]
    [MapInfo("extnamount", "_extnamount", "")]
    [MapInfo("nruc", "_nruc", "")]
    [MapInfo("nInsurancePct", "_ninsurancepct", "")]
    [MapInfo("nLivery", "_nlivery", "")]
    [MapInfo("nUniform", "_nuniform", "")]
    [MapInfo("nACCAmount", "_naccamounts", "")]
    [MapInfo("nDepreciation2", "_ndepreciation2", "")]
    [MapInfo("nUse_rucs", "_nuse_rucs", "")]
    [MapInfo("processing_wage_rate", "_processing_wage_rate", "")]
    [MapInfo("relief_weeks", "_relief_weeks", "")]
    [System.Serializable()]

    public class Extension2005 : Entity<Extension2005>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _con_title;

        [DBField()]
        private int? _num_rows;

        [DBField()]
        private decimal? _distance;

        [DBField()]
        private int? _boxes;

        [DBField()]
        private int? _rural_bags;

        [DBField()]
        private int? _other_bags;

        [DBField()]
        private int? _private_bags;

        [DBField()]
        private int? _post_offices;

        [DBField()]
        private int? _no_cmbs;

        [DBField()]
        private int? _no_cmb_customers;

        [DBField()]
        private decimal? _del_hrs;

        [DBField()]
        private decimal? _proc_hrs;

        [DBField()]
        private int? _mail_volume;

        [DBField()]
        private DateTime? _extn_effective_date;

        [DBField()]
        private decimal? _extn_distance;

        [DBField()]
        private int? _extn_boxes;

        [DBField()]
        private int? _extn_rural_bags;

        [DBField()]
        private int? _extn_other_bags;

        [DBField()]
        private int? _extn_private_bags;

        [DBField()]
        private int? _extn_post_offices;

        [DBField()]
        private int? _extn_no_cmbs;

        [DBField()]
        private int? _extn_no_cmb_customers;

        [DBField()]
        private decimal? _extn_del_hrs;

        [DBField()]
        private decimal? _extn_proc_hrs;

        [DBField()]
        private int? _extn_mail_volume;

        [DBField()]
        private string _extn_reason;

        [DBField()]
        private int? _no_del_days_year;

        [DBField()]
        private decimal? _delivery_wage_rate;

        [DBField()]
        private decimal? _repairsmaint;

        [DBField()]
        private decimal? _typestube;

        [DBField()]
        private decimal? _vehicalallow;

        [DBField()]
        private decimal? _accrate;

        [DBField()]
        private decimal? _rr_item_proc_rate_per_hr;

        [DBField()]
        private decimal? _fuelrate;

        [DBField()]
        private decimal? _consumptionrate;

        [DBField()]
        private decimal? _extnamount;

        [DBField()]
        private decimal? _nruc;

        [DBField()]
        private decimal? _ninsurancepct;

        [DBField()]
        private decimal? _nlivery;

        [DBField()]
        private decimal? _nuniform;

        [DBField()]
        private decimal? _naccamounts;

        [DBField()]
        private decimal? _ndepreciation2;

        [DBField()]
        private int? _nuse_rucs;

        [DBField()]
        private decimal? _processing_wage_rate;

        [DBField()]
        private decimal? _relief_weeks;


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

        public virtual string ConTitle
        {
            get
            {
                CanReadProperty("ConTitle", true);
                return _con_title;
            }
            set
            {
                CanWriteProperty("ConTitle", true);
                if (_con_title != value)
                {
                    _con_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NumRows
        {
            get
            {
                CanReadProperty("NumRows", true);
                return _num_rows;
            }
            set
            {
                CanWriteProperty("NumRows", true);
                if (_num_rows != value)
                {
                    _num_rows = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Distance
        {
            get
            {
                CanReadProperty("Distance", true);
                return _distance;
            }
            set
            {
                CanWriteProperty("Distance", true);
                if (_distance != value)
                {
                    _distance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Boxes
        {
            get
            {
                CanReadProperty("Boxes", true);
                return _boxes;
            }
            set
            {
                CanWriteProperty("Boxes", true);
                if (_boxes != value)
                {
                    _boxes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RuralBags
        {
            get
            {
                CanReadProperty("RuralBags", true);
                return _rural_bags;
            }
            set
            {
                CanWriteProperty("RuralBags", true);
                if (_rural_bags != value)
                {
                    _rural_bags = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? OtherBags
        {
            get
            {
                CanReadProperty("OtherBags", true);
                return _other_bags;
            }
            set
            {
                CanWriteProperty("OtherBags", true);
                if (_other_bags != value)
                {
                    _other_bags = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrivateBags
        {
            get
            {
                CanReadProperty("PrivateBags", true);
                return _private_bags;
            }
            set
            {
                CanWriteProperty("PrivateBags", true);
                if (_private_bags != value)
                {
                    _private_bags = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PostOffices
        {
            get
            {
                CanReadProperty("PostOffices", true);
                return _post_offices;
            }
            set
            {
                CanWriteProperty("PostOffices", true);
                if (_post_offices != value)
                {
                    _post_offices = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NoCmbs
        {
            get
            {
                CanReadProperty("NoCmbs", true);
                return _no_cmbs;
            }
            set
            {
                CanWriteProperty("NoCmbs", true);
                if (_no_cmbs != value)
                {
                    _no_cmbs = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NoCmbCustomers
        {
            get
            {
                CanReadProperty("NoCmbCustomers", true);
                return _no_cmb_customers;
            }
            set
            {
                CanWriteProperty("NoCmbCustomers", true);
                if (_no_cmb_customers != value)
                {
                    _no_cmb_customers = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DelHrs
        {
            get
            {
                CanReadProperty("DelHrs", true);
                return _del_hrs;
            }
            set
            {
                CanWriteProperty("DelHrs", true);
                if (_del_hrs != value)
                {
                    _del_hrs = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ProcHrs
        {
            get
            {
                CanReadProperty("ProcHrs", true);
                return _proc_hrs;
            }
            set
            {
                CanWriteProperty("ProcHrs", true);
                if (_proc_hrs != value)
                {
                    _proc_hrs = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? MailVolume
        {
            get
            {
                CanReadProperty("MailVolume", true);
                return _mail_volume;
            }
            set
            {
                CanWriteProperty("MailVolume", true);
                if (_mail_volume != value)
                {
                    _mail_volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ExtnEffectiveDate
        {
            get
            {
                CanReadProperty("ExtnEffectiveDate", true);
                return _extn_effective_date;
            }
            set
            {
                CanWriteProperty("ExtnEffectiveDate", true);
                if (_extn_effective_date != value)
                {
                    _extn_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ExtnDistance
        {
            get
            {
                CanReadProperty("ExtnDistance", true);
                return _extn_distance;
            }
            set
            {
                CanWriteProperty("ExtnDistance", true);
                if (_extn_distance != value)
                {
                    _extn_distance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnBoxes
        {
            get
            {
                CanReadProperty("ExtnBoxes", true);
                return _extn_boxes;
            }
            set
            {
                CanWriteProperty("ExtnBoxes", true);
                if (_extn_boxes != value)
                {
                    _extn_boxes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnRuralBags
        {
            get
            {
                CanReadProperty("ExtnRuralBags", true);
                return _extn_rural_bags;
            }
            set
            {
                CanWriteProperty("ExtnRuralBags", true);
                if (_extn_rural_bags != value)
                {
                    _extn_rural_bags = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnOtherBags
        {
            get
            {
                CanReadProperty("ExtnOtherBags", true);
                return _extn_other_bags;
            }
            set
            {
                CanWriteProperty("ExtnOtherBags", true);
                if (_extn_other_bags != value)
                {
                    _extn_other_bags = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnPrivateBags
        {
            get
            {
                CanReadProperty("ExtnPrivateBags", true);
                return _extn_private_bags;
            }
            set
            {
                CanWriteProperty("ExtnPrivateBags", true);
                if (_extn_private_bags != value)
                {
                    _extn_private_bags = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnPostOffices
        {
            get
            {
                CanReadProperty("ExtnPostOffices", true);
                return _extn_post_offices;
            }
            set
            {
                CanWriteProperty("ExtnPostOffices", true);
                if (_extn_post_offices != value)
                {
                    _extn_post_offices = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnNoCmbs
        {
            get
            {
                CanReadProperty("ExtnNoCmbs", true);
                return _extn_no_cmbs;
            }
            set
            {
                CanWriteProperty("ExtnNoCmbs", true);
                if (_extn_no_cmbs != value)
                {
                    _extn_no_cmbs = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnNoCmbCustomers
        {
            get
            {
                CanReadProperty("ExtnNoCmbCustomers", true);
                return _extn_no_cmb_customers;
            }
            set
            {
                CanWriteProperty("ExtnNoCmbCustomers", true);
                if (_extn_no_cmb_customers != value)
                {
                    _extn_no_cmb_customers = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ExtnDelHrs
        {
            get
            {
                CanReadProperty("ExtnDelHrs", true);
                return _extn_del_hrs;
            }
            set
            {
                CanWriteProperty("ExtnDelHrs", true);
                if (_extn_del_hrs != value)
                {
                    _extn_del_hrs = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ExtnProcHrs
        {
            get
            {
                CanReadProperty("ExtnProcHrs", true);
                return _extn_proc_hrs;
            }
            set
            {
                CanWriteProperty("ExtnProcHrs", true);
                if (_extn_proc_hrs != value)
                {
                    _extn_proc_hrs = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ExtnMailVolume
        {
            get
            {
                CanReadProperty("ExtnMailVolume", true);
                return _extn_mail_volume;
            }
            set
            {
                CanWriteProperty("ExtnMailVolume", true);
                if (_extn_mail_volume != value)
                {
                    _extn_mail_volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ExtnReason
        {
            get
            {
                CanReadProperty("ExtnReason", true);
                return _extn_reason;
            }
            set
            {
                CanWriteProperty("ExtnReason", true);
                if (_extn_reason != value)
                {
                    _extn_reason = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NoDelDaysYear
        {
            get
            {
                CanReadProperty("NoDelDaysYear", true);
                return _no_del_days_year;
            }
            set
            {
                CanWriteProperty("NoDelDaysYear", true);
                if (_no_del_days_year != value)
                {
                    _no_del_days_year = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? DeliveryWageRate
        {
            get
            {
                CanReadProperty("DeliveryWageRate", true);
                return _delivery_wage_rate;
            }
            set
            {
                CanWriteProperty("DeliveryWageRate", true);
                if (_delivery_wage_rate != value)
                {
                    _delivery_wage_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Repairsmaint
        {
            get
            {
                CanReadProperty("Repairsmaint", true);
                return _repairsmaint;
            }
            set
            {
                CanWriteProperty("Repairsmaint", true);
                if (_repairsmaint != value)
                {
                    _repairsmaint = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Typestube
        {
            get
            {
                CanReadProperty("Typestube", true);
                return _typestube;
            }
            set
            {
                CanWriteProperty("Typestube", true);
                if (_typestube != value)
                {
                    _typestube = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Vehicalallow
        {
            get
            {
                CanReadProperty("Vehicalallow", true);
                return _vehicalallow;
            }
            set
            {
                CanWriteProperty("Vehicalallow", true);
                if (_vehicalallow != value)
                {
                    _vehicalallow = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Accrate
        {
            get
            {
                CanReadProperty("Accrate", true);
                return _accrate;
            }
            set
            {
                CanWriteProperty("Accrate", true);
                if (_accrate != value)
                {
                    _accrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrItemProcRatePerHr
        {
            get
            {
                CanReadProperty("RrItemProcRatePerHr", true);
                return _rr_item_proc_rate_per_hr;
            }
            set
            {
                CanWriteProperty("RrItemProcRatePerHr", true);
                if (_rr_item_proc_rate_per_hr != value)
                {
                    _rr_item_proc_rate_per_hr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Fuelrate
        {
            get
            {
                CanReadProperty("Fuelrate", true);
                return _fuelrate;
            }
            set
            {
                CanWriteProperty("Fuelrate", true);
                if (_fuelrate != value)
                {
                    _fuelrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Consumptionrate
        {
            get
            {
                CanReadProperty("Consumptionrate", true);
                return _consumptionrate;
            }
            set
            {
                CanWriteProperty("Consumptionrate", true);
                if (_consumptionrate != value)
                {
                    _consumptionrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Extnamount
        {
            get
            {
                CanReadProperty("Extnamount", true);
                return _extnamount;
            }
            set
            {
                CanWriteProperty("Extnamount", true);
                if (_extnamount != value)
                {
                    _extnamount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Nruc
        {
            get
            {
                CanReadProperty("Nruc", true);
                return _nruc;
            }
            set
            {
                CanWriteProperty("Nruc", true);
                if (_nruc != value)
                {
                    _nruc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Ninsurancepct
        {
            get
            {
                CanReadProperty("Ninsurancepct", true);
                return _ninsurancepct;
            }
            set
            {
                CanWriteProperty("Ninsurancepct", true);
                if (_ninsurancepct != value)
                {
                    _ninsurancepct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Nlivery
        {
            get
            {
                CanReadProperty("Nlivery", true);
                return _nlivery;
            }
            set
            {
                CanWriteProperty("Nlivery", true);
                if (_nlivery != value)
                {
                    _nlivery = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Nuniform
        {
            get
            {
                CanReadProperty("Nuniform", true);
                return _nuniform;
            }
            set
            {
                CanWriteProperty("Nuniform", true);
                if (_nuniform != value)
                {
                    _nuniform = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Naccamounts
        {
            get
            {
                CanReadProperty("Naccamounts", true);
                return _naccamounts;
            }
            set
            {
                CanWriteProperty("Naccamounts", true);
                if (_naccamounts != value)
                {
                    _naccamounts = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Ndepreciation2
        {
            get
            {
                CanReadProperty("Ndepreciation2", true);
                return _ndepreciation2;
            }
            set
            {
                CanWriteProperty("Ndepreciation2", true);
                if (_ndepreciation2 != value)
                {
                    _ndepreciation2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NuseRucs
        {
            get
            {
                CanReadProperty("NuseRucs", true);
                return _nuse_rucs;
            }
            set
            {
                CanWriteProperty("NuseRucs", true);
                if (_nuse_rucs != value)
                {
                    _nuse_rucs = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ProcessingWageRate
        {
            get
            {
                CanReadProperty("ProcessingWageRate", true);
                return _processing_wage_rate;
            }
            set
            {
                CanWriteProperty("ProcessingWageRate", true);
                if (_processing_wage_rate != value)
                {
                    _processing_wage_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        // TJB  RPCR_041: Added
        public virtual decimal? Reliefweeks
        {
            get
            {
                CanReadProperty("Reliefweeks", true);
                return _relief_weeks;
            }
            set
            {
                CanWriteProperty("Reliefweeks", true);
                if (_relief_weeks != value)
                {
                    _relief_weeks = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cust_change]
        //if(isnull(extn_boxes),0,extn_boxes) + if(isnull(extn_no_cmb_customers),0,extn_no_cmb_customers)
        public virtual decimal? CustChange
        {
            get
            {
                CanReadProperty("CustChange", true);
                return (_extn_boxes == null ? 0 : _extn_boxes) + (_extn_no_cmb_customers == null ? 0 : _extn_no_cmb_customers);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[volume_customer]
        //if(isnull(mail_volume),0,mail_volume) / (if(isnull(boxes),0,boxes) + if(isnull(no_cmb_customers),0,no_cmb_customers))
        public virtual decimal? VolumeCustomer
        {
            get
            {
                CanReadProperty("VolumeCustomer", true);

                int? denominator = ((_boxes == null ? 0 : _boxes) +
                    (_no_cmb_customers == null ? 0 : _no_cmb_customers));

                //pp! may happen to divide by 0 if values are not checked
                if (denominator.HasValue && denominator != 0)
                {                    
                    return (decimal)(_mail_volume == null ? 0 : _mail_volume) / (decimal)((_boxes == null ? 0 : _boxes) +
                        (_no_cmb_customers == null ? 0 : _no_cmb_customers));
                }
                else {
                    return 0;
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_1]
        //extn_distance * no_del_days_year
        public virtual decimal? Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return _extn_distance * _no_del_days_year;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[volume_change]
        //cust_change * volume_customer
        public virtual decimal? VolumeChange
        {
            get
            {
                CanReadProperty("VolumeChange", true);
                return CustChange * VolumeCustomer;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[proc_hrs_change]
        //(cust_change * volume_customer) / rr_item_proc_rate_per_hr / 52.1429
        public virtual decimal? ProcHrsChange
        {
            get
            {
                CanReadProperty("ProcHrsChange", true);

                //pp! may happen to divide by 0 if values are not checked
                if (_rr_item_proc_rate_per_hr.HasValue && _rr_item_proc_rate_per_hr != 0)
                {
                    return (CustChange * VolumeCustomer) / _rr_item_proc_rate_per_hr / (52.1429M);
                }
                else {
                    return 0;
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[l1]
        //extn_distance/(50 / 60)
        public virtual decimal? L1
        {
            get
            {
                CanReadProperty("L1", true);
                return _extn_distance/(50M / 60M);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[l2]
        //if(isnull(cust_change),0,cust_change) * (25/60)
        public virtual decimal? L2
        {
            get
            {
                CanReadProperty("L2", true);
                return (CustChange== null?0:CustChange) * (25M/60M);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[l3]
        //l1+l2
        public virtual decimal? L3
        {
            get
            {
                CanReadProperty("L3", true);
                return L1+L2;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[del_days_per_week]
        //(l3 *  (no_del_days_year/50)) / 60
        public virtual decimal? DelDaysPerWeek
        {
            get
            {
                CanReadProperty("DelDaysPerWeek", true);
                return (L3 *  (_no_del_days_year/50M)) / 60M;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[tyretubecost]
        //extn_distance * no_del_days_year) * (typestube/1000
        public virtual decimal? Tyretubecost
        {
            get
            {
                CanReadProperty("Tyretubecost", true);
                return (_extn_distance *_no_del_days_year) * (_typestube/1000M);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[fuelcost]
        //consumptionrate / 100) * (extn_distance * no_del_days_year) * (fuelrate / 100
        public virtual decimal? Fuelcost
        {
            get
            {
                CanReadProperty("Fuelcost", true);
                return (_consumptionrate / 100M) * (_extn_distance *_no_del_days_year) * (_fuelrate / 100M);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[repmaintcost]
        //extn_distance * no_del_days_year) * (repairsmaint/1000
        public virtual decimal? Repmaintcost
        {
            get
            {
                CanReadProperty("Repmaintcost", true);
                return (_extn_distance *_no_del_days_year) * (_repairsmaint/1000M);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[vehicledep]
        //if(ndepreciation2 >; 0, ndepreciation2, (extn_distance * no_del_days_year) * (vehicalallow / 1000) )
        public virtual decimal? Vehicledep
        {
            get
            {
                CanReadProperty("Vehicledep", true);
                return (_ndepreciation2 > 0 ? _ndepreciation2 : (_extn_distance * _no_del_days_year) * (_vehicalallow / 1000M));
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        //tyretubecost + fuelcost + repmaintcost + vehicledep
        public virtual decimal? Compute2
        {
            get
            {
                CanReadProperty("Compute2", true);
                return  Tyretubecost + Fuelcost + Repmaintcost + Vehicledep;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[proccost]
        //(((volume_change / rr_item_proc_rate_per_hr) / 365) * 7 * 52) *  processing_wage_rate
        public virtual decimal? Proccost
        {
            get
            {
                CanReadProperty("Proccost", true);
                if (_rr_item_proc_rate_per_hr.HasValue && _rr_item_proc_rate_per_hr != 0)//! prevent dividing by 0
                {
                    return (((VolumeChange / _rr_item_proc_rate_per_hr) / 365) * 7 * 52) * _processing_wage_rate;
                }
                else 
                {
                    return 0;
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[delcost]
        //extn_del_hrs * 52 * delivery_wage_rate
        public virtual decimal? Delcost
        {
            get
            {
                CanReadProperty("Delcost", true);
                return _extn_del_hrs * 52M * _delivery_wage_rate;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[acccost]
        //accrate/100) * (delcost + proccost+reliefcost
        public virtual decimal? Acccost
        {
            get
            {
                CanReadProperty("Acccost", true);
                return (_accrate / 100) * (Delcost + Proccost + Reliefcost);
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_3]
        //proccost + delcost + reliefcost + acccost
        public virtual decimal? Compute3
        {
            get
            {
                CanReadProperty("Compute3", true);
                return Proccost + Delcost + Reliefcost + Acccost;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[ruccost]
        //((if(isnull(extn_distance),0,extn_distance) * if(isnull(no_del_days_year),0,no_del_days_year)) * (if(isnull( nruc),0,nruc)/1000)) * nuse_rucs
        public virtual decimal? Ruccost
        {
            get
            {
                CanReadProperty("Ruccost", true);
                return (((_extn_distance== null?0:_extn_distance) * (_no_del_days_year== null?0:_no_del_days_year)) * 
                    ((_nruc== null?0:_nruc)/1000)) * _nuse_rucs;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[extnamnt]
        //ceiling(	if(isNull(ruccost),0,ruccost)+ 	if(isNull(acccost ),0,acccost) +  	if(isNull(proccost ),0,proccost ) +  	if(isNull(delcost),0,delcost )  +  	if(isNull(reliefcost),0,reliefcost )  +  	if(isnull(tyretubecost),0,tyretubecost)  +  	if(isNull(repmaintcost),0,repmaintcost)  +  	if(isNull(fuelcost),0,fuelcost)  +  	if(isNull(vehicledep),0,vehicledep) )
        public virtual decimal? Extnamnt
        {
            get
            {
                // TJB  20-Jul-2009  RD7_0033:  Extentions fixes
                //    Intruduced temporary variable (tmpamnt) to assist debugging.
                decimal? tmpamt;
                CanReadProperty("Extnamnt", true);
                tmpamt =  (Ruccost == null ? 0 : Ruccost)
                        + (Acccost == null ? 0 : Acccost)
                        + (Proccost == null ? 0 : Proccost)
                        + (Delcost == null ? 0 : Delcost)
                        + (Reliefcost == null ? 0 : Reliefcost)
                        + (Tyretubecost == null ? 0 : Tyretubecost)
                        + (Repmaintcost == null ? 0 : Repmaintcost)
                        + (Fuelcost == null ? 0 : Fuelcost)
                        + (Vehicledep == null ? 0 : Vehicledep);
                return Math.Ceiling(tmpamt.GetValueOrDefault());
                // return Math.Ceiling((
                //      (Ruccost == null?0:Ruccost)
                //     +(Acccost == null?0:Acccost)
                //     +(Proccost == null?0:Proccost)
                //     +(Delcost == null?0:Delcost)
                //     +(Reliefcost == null?0:Reliefcost)
                //     +(Tyretubecost == null?0:Tyretubecost)
                //     +(Repmaintcost == null?0:Repmaintcost)
                //     +(Fuelcost == null?0:Fuelcost)
                //     +(Vehicledep == null?0:Vehicledep)
                //     ).GetValueOrDefault());
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_4]
        //extnamnt - extnamount
        public virtual string Compute4
        {
            get
            {
                CanReadProperty("Compute4", true);
                string str = string.Empty;
                if ((Extnamnt - _extnamount) >= 0)
                {
                    str = ((decimal?)(Extnamnt - _extnamount)).GetValueOrDefault().ToString("#,##0.00");
                }
                if ((Extnamnt - _extnamount) < 0)
                {
                    str = Math.Abs(((decimal?)(Extnamnt - _extnamount)).GetValueOrDefault()).ToString("(#,##0.00)");
                }
                return str;
            }
            
        }

        // needs to implement compute expression manually:
        // compute control name=[extnamnt1]
        //if (( if(isNull(ruccost),0,ruccost) + if(isNull(acccost),0,acccost) + if(isNull(proccost),0,proccost ) + if(isNull(delcost),0,delcost) + if(isNull(reliefcost),0,reliefcost) + if(isnull(tyretubecost),0,tyretubecost) + if(isNull(repmaintcost),0,repmaintcost) + if(isNull(fuelcost),0,fuelcost) + if(isNull(vehicledep),0,vehicledep) ) >; 0,round(if(isNull(ruccost),0,ruccost) + if(isNull(acccost ),0,acccost) + if(isNull(proccost),0,proccost) + if(isNull(delcost),0,delcost) + if(isnull(tyretubecost),0,tyretubecost) + if(isNull(repmaintcost),0,repmaintcost) + if(isNull(fuelcost),0,fuelcost) + if(isNull(vehicledep),0,vehicledep)+0.5,0) , round(if(isNull(ruccost),0,ruccost) + if(isNull(acccost),0,acccost) + if(isNull(proccost),0,proccost) + if(isNull(delcost),0,delcost) + if(isnull(tyretubecost),0,tyretubecost) + if(isNull(repmaintcost),0,repmaintcost) + if(isNull(fuelcost),0,fuelcost) + if(isNull(vehicledep),0,vehicledep),0))
        public virtual decimal? Extnamnt1
        {
            get
            {
                CanReadProperty("Extnamnt1", true);
                return (((Ruccost == null ? 0 : Ruccost) + (Acccost == null ? 0 : Acccost) + 
                    (Proccost == null ? 0 : Proccost) + (Delcost == null ? 0 : Delcost) + 
                    (Reliefcost == null ? 0 : Reliefcost) + (Tyretubecost == null ? 0 : Tyretubecost) + 
                    (Repmaintcost == null ? 0 : Repmaintcost) + (Fuelcost == null ? 0 : Fuelcost) + 
                    (Vehicledep == null ? 0 : Vehicledep)) > 0 ? Math.Round(((Ruccost == null ? 0 : Ruccost) + 
                    (Acccost == null ? 0 : Acccost) + (Proccost == null ? 0 : Proccost) + (Delcost == null ? 0 : Delcost) + 
                    (Tyretubecost == null ? 0 : Tyretubecost) + (Repmaintcost == null ? 0 : Repmaintcost) + 
                    (Fuelcost == null ? 0 : Fuelcost) + (Vehicledep == null ? 0 : Vehicledep) + 
                    ((decimal?)0.5)).GetValueOrDefault(), 0) : Math.Round(((Ruccost == null ? 0 : Ruccost) + 
                    (Acccost == null ? 0 : Acccost) + (Proccost == null ? 0 : Proccost) + 
                    (Delcost == null ? 0 : Delcost) + (Tyretubecost == null ? 0 : Tyretubecost) + 
                    (Repmaintcost == null ? 0 : Repmaintcost) + (Fuelcost == null ? 0 : Fuelcost) + 
                    (Vehicledep == null ? 0 : Vehicledep)).GetValueOrDefault(), 0));
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[extnamnt_original]
        //if (( if(isNull(ruccost),0,ruccost) + if(isNull(acccost ),0,acccost) +  if(isNull(proccost ),0,proccost ) +  if(isNull(delcost),0,delcost )  +  if(isnull(tyretubecost),0,tyretubecost)  +  if(isNull(repmaintcost),0,repmaintcost)  +  if(isNull(fuelcost),0,fuelcost)  +  if(isNull(vehicledep),0,vehicledep) )>;0,round(if(isNull(ruccost),0,ruccost) + if(isNull(acccost ),0,acccost) +  if(isNull(proccost ),0,proccost ) +  if(isNull(delcost),0,delcost )  +  if(isnull(tyretubecost),0,tyretubecost)  +  if(isNull(repmaintcost),0,repmaintcost)  +  if(isNull(fuelcost),0,fuelcost)  +  if(isNull(vehicledep),0,vehicledep) +0.5,0) , round(if(isNull(ruccost),0,ruccost) + if(isNull(acccost ),0,acccost) +  if(isNull(proccost ),0,proccost ) +  if(isNull(delcost),0,delcost )  +  if(isnull(tyretubecost),0,tyretubecost)  +  if(isNull(repmaintcost),0,repmaintcost)  +  if(isNull(fuelcost),0,fuelcost)  +  if(isNull(vehicledep),0,vehicledep) ,0))
        public virtual decimal? ExtnamntOriginal
        {
            get
            {
                CanReadProperty("ExtnamntOriginal", true);
                return (((Ruccost == null ? 0 : Ruccost) + (Acccost == null ? 0 : Acccost) + 
                    (Proccost == null ? 0 : Proccost) + (Delcost == null ? 0 : Delcost) + 
                    (Tyretubecost == null ? 0 : Tyretubecost) + (Repmaintcost == null ? 0 : Repmaintcost) + 
                    (Fuelcost == null ? 0 : Fuelcost) + 
                    (Vehicledep == null ? 0 : Vehicledep)) > 0 ? Math.Round(((Ruccost == null ? 0 : Ruccost) + 
                    (Acccost == null ? 0 : Acccost) + (Proccost == null ? 0 : Proccost) + (Delcost == null ? 0 : Delcost) + 
                    (Tyretubecost == null ? 0 : Tyretubecost) + (Repmaintcost == null ? 0 : Repmaintcost) + 
                    (Fuelcost == null ? 0 : Fuelcost) + (Vehicledep == null ? 0 : Vehicledep) + 
                    ((decimal?)0.5)).GetValueOrDefault(), 0) : Math.Round(((Ruccost == null ? 0 : Ruccost) + 
                    (Acccost == null ? 0 : Acccost) + (Proccost == null ? 0 : Proccost) + (Delcost == null ? 0 : Delcost) + 
                    (Tyretubecost == null ? 0 : Tyretubecost) + (Repmaintcost == null ? 0 : Repmaintcost) + 
                    (Fuelcost == null ? 0 : Fuelcost) + (Vehicledep == null ? 0 : Vehicledep)).GetValueOrDefault(), 0));
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[reliefcost]
        //extn_del_hrs * 4 * delivery_wage_rate) + ( (((volume_change / rr_item_proc_rate_per_hr) / 365) * 7 * 4) * processing_wage_rate
        public virtual decimal? Reliefcost
        {
            get
            {
                CanReadProperty("Reliefcost", true);
                if (_rr_item_proc_rate_per_hr.HasValue && _rr_item_proc_rate_per_hr != 0)//! prevent dividing by 0
                {
                    return (_extn_del_hrs * Reliefweeks * _delivery_wage_rate) 
                           + ((((VolumeChange / _rr_item_proc_rate_per_hr) / 365) 
                                * 7 * Reliefweeks) * _processing_wage_rate);
                }
                else 
                {
                    return 0;
                }
            }
        }

        // TJB RPCR_041: Replaced
            // added by wjtang for SR4703
            //compute column  :if( isnull(extn_effective_date), 5, if( (extn_effective_date) > date('31 October 2007'), 5, 4))
            //public virtual int? Reliefweeks
            //{
            //    get
            //    {
            //        CanReadProperty("Reliefweeks", true);
            //       
            //        return _extn_effective_date == null ? 5 : DateTime.Compare(_extn_effective_date == null ? DateTime.MinValue : _extn_effective_date.Value, new DateTime(2007, 10, 31)) > 0 ? 5 : 4;
            //    }
            //}
   
        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static Extension2005 NewExtension2005(int? in_contract)
        {
            return Create(in_contract);
        }

        public static Extension2005[] GetAllExtension2005(int? in_contract)
        {
            return Fetch(in_contract).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_contract)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_contract", in_contract);
                    cm.CommandText = "rd.sp_getextndata2005";
                    List<Extension2005> _list = new List<Extension2005>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Extension2005 instance = new Extension2005();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._con_title = GetValueFromReader<String>(dr,1);
                            instance._num_rows = GetValueFromReader<Int32?>(dr,2);
                            instance._distance = GetValueFromReader<Decimal?>(dr,3);
                            instance._boxes = GetValueFromReader<Int32?>(dr,4);
                            instance._rural_bags = GetValueFromReader<Int32?>(dr,5);
                            instance._other_bags = GetValueFromReader<Int32?>(dr,6);
                            instance._private_bags = GetValueFromReader<Int32?>(dr,7);
                            instance._post_offices = GetValueFromReader<Int32?>(dr,8);
                            instance._no_cmbs = GetValueFromReader<Int32?>(dr,9);
                            instance._no_cmb_customers = GetValueFromReader<Int32?>(dr,10);
                            instance._del_hrs = GetValueFromReader<Decimal?>(dr,11);
                            instance._proc_hrs = GetValueFromReader<Decimal?>(dr,12);
                            instance._mail_volume = (int?) GetValueFromReader<Decimal?>(dr,13);
                            instance._extn_effective_date = GetValueFromReader<DateTime?>(dr,14);
                            instance._extn_distance = GetValueFromReader<Int32?>(dr,15);
                            instance._extn_boxes = GetValueFromReader<Int32?>(dr,16);
                            instance._extn_rural_bags = GetValueFromReader<Int32?>(dr,17);
                            instance._extn_other_bags = GetValueFromReader<Int32?>(dr,18);
                            instance._extn_private_bags = GetValueFromReader<Int32?>(dr,19);
                            instance._extn_post_offices = GetValueFromReader<Int32?>(dr,20);
                            instance._extn_no_cmbs = GetValueFromReader<Int32?>(dr,21);
                            instance._extn_no_cmb_customers = GetValueFromReader<Int32?>(dr,22);
                            instance._extn_del_hrs = GetValueFromReader<Int32?>(dr,23);
                            instance._extn_proc_hrs = GetValueFromReader<Int32?>(dr,24);
                            instance._extn_mail_volume = GetValueFromReader<Int32?>(dr,25);
                            instance._extn_reason = GetValueFromReader<String>(dr,26).Trim();
                            instance._no_del_days_year = GetValueFromReader<Int32?>(dr,27);
                            instance._delivery_wage_rate = GetValueFromReader<Decimal?>(dr,28);
                            instance._repairsmaint = GetValueFromReader<Decimal?>(dr,29);
                            instance._typestube = GetValueFromReader<Decimal?>(dr,30);
                            instance._vehicalallow = GetValueFromReader<Decimal?>(dr,31);
                            instance._accrate = GetValueFromReader<Decimal?>(dr,32);
                            instance._rr_item_proc_rate_per_hr = GetValueFromReader<Decimal?>(dr,33);
                            instance._fuelrate = GetValueFromReader<Decimal?>(dr,34);
                            instance._consumptionrate = GetValueFromReader<Decimal?>(dr,35);
                            instance._extnamount = GetValueFromReader<Int32?>(dr,36);
                            instance._nruc = GetValueFromReader<Decimal?>(dr,37);
                            instance._ninsurancepct = GetValueFromReader<Decimal?>(dr,38);
                            instance._nlivery = GetValueFromReader<Decimal?>(dr,39);
                            instance._nuniform = GetValueFromReader<Decimal?>(dr,40);
                            instance._naccamounts = GetValueFromReader<Decimal?>(dr,41);
                            instance._ndepreciation2 = GetValueFromReader<Decimal?>(dr,42);
                            instance._nuse_rucs = GetValueFromReader<Int32?>(dr,43);
                            instance._processing_wage_rate = GetValueFromReader<Decimal?>(dr, 44);
                            instance._relief_weeks = GetValueFromReader<Decimal?>(dr, 45);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        private decimal? RoundDecimals(decimal? value)
        {
            decimal? retVal = value;
            if (value.HasValue)
            {
                retVal = Math.Round(value.Value);
            }
            return retVal;
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}
