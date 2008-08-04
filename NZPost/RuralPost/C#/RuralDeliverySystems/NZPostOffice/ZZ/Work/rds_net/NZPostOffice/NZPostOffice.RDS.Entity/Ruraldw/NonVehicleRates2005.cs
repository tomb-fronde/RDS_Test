using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("rg_code", "_rg_code", "non_vehicle_rate")]
    [MapInfo("nvr_rates_effective_date", "_nvr_rates_effective_date", "non_vehicle_rate")]
    [MapInfo("nvr_wage_hourly_rate", "_nvr_wage_hourly_rate", "non_vehicle_rate")]
    [MapInfo("nvr_vehicle_insurance_base_premium", "_nvr_vehicle_insurance_base_premium", "non_vehicle_rate")]
    [MapInfo("nvr_public_liability_rate", "_nvr_public_liability_rate", "non_vehicle_rate")]
    [MapInfo("nvr_carrier_risk_rate", "_nvr_carrier_risk_rate", "non_vehicle_rate")]
    [MapInfo("nvr_acc_rate", "_nvr_acc_rate", "non_vehicle_rate")]
    [MapInfo("nvr_item_proc_rate_per_hr", "_nvr_item_proc_rate_per_hr", "non_vehicle_rate")]
    [MapInfo("nvr_frozen_indicator", "_nvr_frozen_indicator", "non_vehicle_rate")]
    [MapInfo("nvr_contract_start", "_nvr_contract_start", "non_vehicle_rate")]
    [MapInfo("nvr_contract_end", "_nvr_contract_endnon_vehicle_rate", "non_vehicle_rate")]
    [MapInfo("nvr_accounting", "_nvr_accounting", "non_vehicle_rate")]
    [MapInfo("nvr_telephone", "_nvr_telephone", "non_vehicle_rate")]
    [MapInfo("nvr_sundries", "_nvr_sundries", "non_vehicle_rate")]
    [MapInfo("nvr_acc_rate_amount", "_nvr_acc_rate_amount", "non_vehicle_rate")]
    [MapInfo("nvr_uniform", "_nvr_uniform", "non_vehicle_rate")]
    [MapInfo("nvr_delivery_wage_rate", "_nvr_delivery_wage_rate", "non_vehicle_rate")]
    [MapInfo("nvr_processing_wage_rate", "_nvr_processing_wage_rate", "non_vehicle_rate")]
    [System.Serializable()]

    public class NonVehicleRates2005 : Entity<NonVehicleRates2005>
    {
        #region Business Methods
        [DBField()]
        private int? _rg_code;

        [DBField()]
        private DateTime? _nvr_rates_effective_date;

        [DBField()]
        private decimal? _nvr_wage_hourly_rate;

        [DBField()]
        private decimal? _nvr_vehicle_insurance_base_premium;

        [DBField()]
        private decimal? _nvr_public_liability_rate;

        [DBField()]
        private decimal? _nvr_carrier_risk_rate;

        [DBField()]
        private decimal? _nvr_acc_rate;

        [DBField()]
        private int? _nvr_item_proc_rate_per_hr;

        [DBField()]
        private string _nvr_frozen_indicator;

        [DBField()]
        private DateTime? _nvr_contract_start;

        [DBField()]
        private DateTime? _nvr_contract_end;

        [DBField()]
        private decimal? _nvr_accounting;

        [DBField()]
        private decimal? _nvr_telephone;

        [DBField()]
        private decimal? _nvr_sundries;

        [DBField()]
        private decimal? _nvr_acc_rate_amount;

        [DBField()]
        private decimal? _nvr_uniform;

        [DBField()]
        private decimal? _nvr_delivery_wage_rate;

        [DBField()]
        private decimal? _nvr_processing_wage_rate;


        public virtual int? RgCode
        {
            get
            {
                CanReadProperty("RgCode", true);
                return _rg_code;
            }
            set
            {
                CanWriteProperty("RgCode", true);
                if (_rg_code != value)
                {
                    _rg_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? NvrRatesEffectiveDate
        {
            get
            {
                CanReadProperty("NvrRatesEffectiveDate", true);
                return _nvr_rates_effective_date;
            }
            set
            {
                CanWriteProperty("NvrRatesEffectiveDate", true);
                if (_nvr_rates_effective_date != value)
                {
                    _nvr_rates_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrWageHourlyRate
        {
            get
            {
                CanReadProperty("NvrWageHourlyRate", true);
                return _nvr_wage_hourly_rate;
            }
            set
            {
                CanWriteProperty("NvrWageHourlyRate", true);
                if (_nvr_wage_hourly_rate != value)
                {
                    _nvr_wage_hourly_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrVehicleInsuranceBasePremium
        {
            get
            {
                CanReadProperty("NvrVehicleInsuranceBasePremium", true);
                return _nvr_vehicle_insurance_base_premium;
            }
            set
            {
                CanWriteProperty("NvrVehicleInsuranceBasePremium", true);
                if (_nvr_vehicle_insurance_base_premium != value)
                {
                    _nvr_vehicle_insurance_base_premium = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrPublicLiabilityRate
        {
            get
            {
                CanReadProperty("NvrPublicLiabilityRate", true);
                return _nvr_public_liability_rate;
            }
            set
            {
                CanWriteProperty("NvrPublicLiabilityRate", true);
                if (_nvr_public_liability_rate != value)
                {
                    _nvr_public_liability_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrCarrierRiskRate
        {
            get
            {
                CanReadProperty("NvrCarrierRiskRate", true);
                return _nvr_carrier_risk_rate;
            }
            set
            {
                CanWriteProperty("NvrCarrierRiskRate", true);
                if (_nvr_carrier_risk_rate != value)
                {
                    _nvr_carrier_risk_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrAccRate
        {
            get
            {
                CanReadProperty("NvrAccRate", true);
                return _nvr_acc_rate;
            }
            set
            {
                CanWriteProperty("NvrAccRate", true);
                if (_nvr_acc_rate != value)
                {
                    _nvr_acc_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NvrItemProcRatePerHr
        {
            get
            {
                CanReadProperty("NvrItemProcRatePerHr", true);
                return _nvr_item_proc_rate_per_hr;
            }
            set
            {
                CanWriteProperty("NvrItemProcRatePerHr", true);
                if (_nvr_item_proc_rate_per_hr != value)
                {
                    _nvr_item_proc_rate_per_hr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool NvrFrozenIndicator
        {
            get
            {
                CanReadProperty("NvrFrozenIndicator", true);
                return (_nvr_frozen_indicator == "Y") ? true:false;
            }
            set
            {
                CanWriteProperty("NvrFrozenIndicator", true);
                if (((_nvr_frozen_indicator == "Y") ? true : false) != value)
                {
                    _nvr_frozen_indicator = ((value == true)?"Y":"N");
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? NvrContractStart
        {
            get
            {
                CanReadProperty("NvrContractStart", true);
                return _nvr_contract_start;
            }
            set
            {
                CanWriteProperty("NvrContractStart", true);
                if (_nvr_contract_start != value)
                {
                    _nvr_contract_start = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? NvrContractEnd
        {
            get
            {
                CanReadProperty("NvrContractEnd", true);
                return _nvr_contract_end;
            }
            set
            {
                CanWriteProperty("NvrContractEnd", true);
                if (_nvr_contract_end != value)
                {
                    _nvr_contract_end = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrAccounting
        {
            get
            {
                CanReadProperty("NvrAccounting", true);
                return _nvr_accounting;
            }
            set
            {
                CanWriteProperty("NvrAccounting", true);
                if (_nvr_accounting != value)
                {
                    _nvr_accounting = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrTelephone
        {
            get
            {
                CanReadProperty("NvrTelephone", true);
                return _nvr_telephone;
            }
            set
            {
                CanWriteProperty("NvrTelephone", true);
                if (_nvr_telephone != value)
                {
                    _nvr_telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrSundries
        {
            get
            {
                CanReadProperty("NvrSundries", true);
                return _nvr_sundries;
            }
            set
            {
                CanWriteProperty("NvrSundries", true);
                if (_nvr_sundries != value)
                {
                    _nvr_sundries = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrAccRateAmount
        {
            get
            {
                CanReadProperty("NvrAccRateAmount", true);
                return _nvr_acc_rate_amount;
            }
            set
            {
                CanWriteProperty("NvrAccRateAmount", true);
                if (_nvr_acc_rate_amount != value)
                {
                    _nvr_acc_rate_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrUniform
        {
            get
            {
                CanReadProperty("NvrUniform", true);
                return _nvr_uniform;
            }
            set
            {
                CanWriteProperty("NvrUniform", true);
                if (_nvr_uniform != value)
                {
                    _nvr_uniform = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrDeliveryWageRate
        {
            get
            {
                CanReadProperty("NvrDeliveryWageRate", true);
                return _nvr_delivery_wage_rate;
            }
            set
            {
                CanWriteProperty("NvrDeliveryWageRate", true);
                if (_nvr_delivery_wage_rate != value)
                {
                    _nvr_delivery_wage_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvrProcessingWageRate
        {
            get
            {
                CanReadProperty("NvrProcessingWageRate", true);
                return _nvr_processing_wage_rate;
            }
            set
            {
                CanWriteProperty("NvrProcessingWageRate", true);
                if (_nvr_processing_wage_rate != value)
                {
                    _nvr_processing_wage_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _rg_code, _nvr_rates_effective_date);
        }

        #endregion

  
        public void MarkNewEntity()
        {
            base.MarkNew();
        }

        public void MarkNotModifiedEntity()
        {
            base.MarkClean();
        }

        public void SetMarkDirty()
        {
            base.MarkDirty();
        }

        #region Factory Methods
        public static NonVehicleRates2005 NewNonVehicleRates2005(int? inRGCode, DateTime? in_EffectDate)
        {
            return Create(inRGCode, in_EffectDate);
        }

        public static NonVehicleRates2005[] GetAllNonVehicleRates2005(int? inRGCode, DateTime? in_EffectDate)
        {
            return Fetch(inRGCode, in_EffectDate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inRGCode, DateTime? in_EffectDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inRGCode", inRGCode);
                    pList.Add(cm, "in_EffectDate", in_EffectDate);
                    cm.CommandText = "rd.sp_getnonvehiclerenewalrates";
                    List<NonVehicleRates2005> _list = new List<NonVehicleRates2005>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            NonVehicleRates2005 instance = new NonVehicleRates2005();
                            instance._rg_code = GetValueFromReader<Int32?>(dr,0);
                            instance._nvr_rates_effective_date = GetValueFromReader<DateTime?>(dr,1);
                            instance._nvr_wage_hourly_rate = GetValueFromReader<Decimal?>(dr,2);
                            instance._nvr_vehicle_insurance_base_premium = GetValueFromReader<Decimal?>(dr,3);
                            instance._nvr_public_liability_rate = GetValueFromReader<Decimal?>(dr,4);
                            instance._nvr_carrier_risk_rate = GetValueFromReader<Decimal?>(dr,5);
                            instance._nvr_acc_rate = GetValueFromReader<Decimal?>(dr,6);
                            instance._nvr_item_proc_rate_per_hr = GetValueFromReader<Int32?>(dr,7);
                            instance._nvr_frozen_indicator = GetValueFromReader<String>(dr,8);
                            instance._nvr_contract_start = GetValueFromReader<DateTime?>(dr,9);
                            instance._nvr_contract_end = GetValueFromReader<DateTime?>(dr,10);
                            instance._nvr_accounting = GetValueFromReader<Decimal?>(dr,11);
                            instance._nvr_telephone = GetValueFromReader<Decimal?>(dr,12);
                            instance._nvr_sundries = GetValueFromReader<Decimal?>(dr,13);
                            instance._nvr_acc_rate_amount = GetValueFromReader<Decimal?>(dr,14);
                            instance._nvr_uniform = GetValueFromReader<Decimal?>(dr,15);
                            instance._nvr_delivery_wage_rate = GetValueFromReader<Decimal?>(dr,16);
                            instance._nvr_processing_wage_rate = GetValueFromReader<Decimal?>(dr,17);
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
                if (GenerateUpdateCommandText(cm, "non_vehicle_rate", ref pList))
                {
                    cm.CommandText += " WHERE  non_vehicle_rate.rg_code = @rg_code and non_vehicle_rate.nvr_rates_effective_date = @nvr_rates_effective_date";

                    pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
                    pList.Add(cm, "nvr_rates_effective_date", GetInitialValue("_nvr_rates_effective_date"));
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
                using (DbCommand cm = cn.CreateCommand())
                {
                    ParameterCollection pList = new ParameterCollection();
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "insert into non_vehicle_rate (rg_code," +
                                     "   nvr_rates_effective_date," +
                                      "  nvr_wage_hourly_rate," +
                                     "   nvr_vehicle_insurance_base_premium," +
                                     "   nvr_public_liability_rate," +
                                     "   nvr_carrier_risk_rate," +
                                     "   nvr_acc_rate," +
                                     "   nvr_item_proc_rate_per_hr," +
                                     "   nvr_frozen_indicator," +
                                     "   nvr_contract_start," +
                                     "   nvr_contract_end," +
                                     "   nvr_accounting," +
                                     "   nvr_telephone," +
                                     "   nvr_sundries," +
                                     "   nvr_acc_rate_amount," +
                                     "   nvr_uniform," +
                                      "  nvr_delivery_wage_rate," +
                                     "   nvr_processing_wage_rate) values(" +
                                     "   @rg_code," +
                                     "   @nvr_rates_effective_date," +
                                      "  @nvr_wage_hourly_rate," +
                                     "   @nvr_vehicle_insurance_base_premium," +
                                     "   @nvr_public_liability_rate," +
                                     "   @nvr_carrier_risk_rate," +
                                     "   @nvr_acc_rate," +
                                     "   @nvr_item_proc_rate_per_hr," +
                                     "   @nvr_frozen_indicator," +
                                     "   @nvr_contract_start," +
                                     "   @nvr_contract_end," +
                                     "   @nvr_accounting," +
                                     "   @nvr_telephone," +
                                     "   @nvr_sundries," +
                                     "   @nvr_acc_rate_amount," +
                                     "   @nvr_uniform," +
                                      "  @nvr_delivery_wage_rate," +
                                     "   @nvr_processing_wage_rate)";
                    pList.Add(cm, "rg_code", _rg_code);
                    pList.Add(cm, "nvr_rates_effective_date", _nvr_rates_effective_date);
                    pList.Add(cm, "nvr_wage_hourly_rate", _nvr_wage_hourly_rate);
                    pList.Add(cm, "nvr_vehicle_insurance_base_premium", _nvr_vehicle_insurance_base_premium);
                    pList.Add(cm, "nvr_public_liability_rate", _nvr_public_liability_rate);
                    pList.Add(cm, "nvr_carrier_risk_rate", _nvr_carrier_risk_rate);
                    pList.Add(cm, "nvr_acc_rate", _nvr_acc_rate);
                    pList.Add(cm, "nvr_item_proc_rate_per_hr", _nvr_item_proc_rate_per_hr);
                    pList.Add(cm, "nvr_frozen_indicator", _nvr_frozen_indicator);
                    pList.Add(cm, "nvr_contract_start", _nvr_contract_start);
                    pList.Add(cm, "nvr_contract_end", _nvr_contract_end);
                    pList.Add(cm, "nvr_accounting", _nvr_accounting);
                    pList.Add(cm, "nvr_telephone", _nvr_telephone);
                    pList.Add(cm, "nvr_sundries", _nvr_sundries);
                    pList.Add(cm, "nvr_acc_rate_amount", _nvr_acc_rate_amount);
                    pList.Add(cm, "nvr_uniform", _nvr_uniform);
                    pList.Add(cm, "nvr_delivery_wage_rate", _nvr_delivery_wage_rate);
                    pList.Add(cm, "nvr_processing_wage_rate", _nvr_processing_wage_rate);
                    //if (GenerateInsertCommandText(cm, "non_vehicle_rate", pList))
                    //{
                        DBHelper.ExecuteNonQuery(cm, pList);
                    //}
                    StoreInitialValues();
                }
            }
            StoreInitialValues();
        }

        #endregion

        [ServerMethod()]
        private void CreateEntity(int? rg_code, DateTime? nvr_rates_effective_date)
        {
            _rg_code = rg_code;
            _nvr_rates_effective_date = nvr_rates_effective_date;
        }
    }
}
