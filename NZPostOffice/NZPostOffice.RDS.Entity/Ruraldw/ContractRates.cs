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
    [MapInfo("contract_no", "_contract_no", "contract_rates")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "contract_rates")]
    [MapInfo("rr_nominal_vehical_value", "_rr_nominal_vehical_value", "contract_rates")]
    [MapInfo("rr_wage_hourly_rate", "_rr_wage_hourly_rate", "contract_rates")]
    [MapInfo("rr_repairs_maintenance_rate", "_rr_repairs_maintenance_rate", "contract_rates")]
    [MapInfo("rr_tyre_tubes_rate", "_rr_tyre_tubes_rate", "contract_rates")]
    [MapInfo("rr_vehical_allowance_rate", "_rr_vehical_allowance_rate", "contract_rates")]
    [MapInfo("rr_vehical_insurance_premium", "_rr_vehical_insurance_premium", "contract_rates")]
    [MapInfo("rr_public_liability_rate_2", "_rr_public_liability_rate_2", "contract_rates")]
    [MapInfo("rr_carrier_risk_rate", "_rr_carrier_risk_rate", "contract_rates")]
    [MapInfo("rr_acc_rate", "_rr_acc_rate", "contract_rates")]
    [MapInfo("rr_licence_rate", "_rr_licence_rate", "contract_rates")]
    [MapInfo("rr_vehical_rate_of_return_pct", "_rr_vehical_rate_of_return_pct", "contract_rates")]
    [MapInfo("rr_salvage_ratio", "_rr_salvage_ratio", "contract_rates")]
    [MapInfo("rr_fuel_rate", "_rr_fuel_rate", "contract_rates")]
    [MapInfo("rr_consumption_rate", "_rr_consumption_rate", "contract_rates")]
    [MapInfo("rr_frozen", "_rr_frozen", "contract_rates")]
    [MapInfo("rr_item_proc_rate_per_hour", "_rr_item_proc_rate_per_hour", "contract_rates")]
    [MapInfo("rr_ruc", "_rr_ruc", "contract_rates")]
    [MapInfo("rr_accounting", "_rr_accounting", "contract_rates")]
    [MapInfo("rr_telephone", "_rr_telephone", "contract_rates")]
    [MapInfo("rr_sundries", "_rr_sundries", "contract_rates")]
    [MapInfo("rr_sundries_k", "_rr_sundries_k", "contract_rates")]
    [System.Serializable()]

    public class ContractRates : Entity<ContractRates>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private decimal? _rr_nominal_vehical_value;

        [DBField()]
        private decimal? _rr_wage_hourly_rate;

        [DBField()]
        private decimal? _rr_repairs_maintenance_rate;

        [DBField()]
        private decimal? _rr_tyre_tubes_rate;

        [DBField()]
        private decimal? _rr_vehical_allowance_rate;

        [DBField()]
        private decimal? _rr_vehical_insurance_premium;

        [DBField()]
        private decimal? _rr_public_liability_rate_2;

        [DBField()]
        private decimal? _rr_carrier_risk_rate;

        [DBField()]
        private decimal? _rr_acc_rate;

        [DBField()]
        private decimal? _rr_licence_rate;

        [DBField()]
        private decimal? _rr_vehical_rate_of_return_pct;

        [DBField()]
        private decimal? _rr_salvage_ratio;

        [DBField()]
        private decimal? _rr_fuel_rate;

        [DBField()]
        private decimal? _rr_consumption_rate;

        [DBField()]
        private string _rr_frozen;

        [DBField()]
        private int? _rr_item_proc_rate_per_hour;

        [DBField()]
        private decimal? _rr_ruc;

        [DBField()]
        private decimal? _rr_accounting;

        [DBField()]
        private decimal? _rr_telephone;

        [DBField()]
        private decimal? _rr_sundries;

        [DBField()]
        private decimal? _rr_sundries_k;

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

        public virtual int? ContractSeqNumber
        {
            get
            {
                CanReadProperty("ContractSeqNumber", true);
                return _contract_seq_number;
            }
            set
            {
                CanWriteProperty("ContractSeqNumber", true);
                if (_contract_seq_number != value)
                {
                    _contract_seq_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrNominalVehicalValue
        {
            get
            {
                CanReadProperty("RrNominalVehicalValue", true);
                return _rr_nominal_vehical_value;
            }
            set
            {
                CanWriteProperty("RrNominalVehicalValue", true);
                if (_rr_nominal_vehical_value != value)
                {
                    _rr_nominal_vehical_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrWageHourlyRate
        {
            get
            {
                CanReadProperty("RrWageHourlyRate", true);
                return _rr_wage_hourly_rate;
            }
            set
            {
                CanWriteProperty("RrWageHourlyRate", true);
                if (_rr_wage_hourly_rate != value)
                {
                    _rr_wage_hourly_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrRepairsMaintenanceRate
        {
            get
            {
                CanReadProperty("RrRepairsMaintenanceRate", true);
                return _rr_repairs_maintenance_rate;
            }
            set
            {
                CanWriteProperty("RrRepairsMaintenanceRate", true);
                if (_rr_repairs_maintenance_rate != value)
                {
                    _rr_repairs_maintenance_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrTyreTubesRate
        {
            get
            {
                CanReadProperty("RrTyreTubesRate", true);
                return _rr_tyre_tubes_rate;
            }
            set
            {
                CanWriteProperty("RrTyreTubesRate", true);
                if (_rr_tyre_tubes_rate != value)
                {
                    _rr_tyre_tubes_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrVehicalAllowanceRate
        {
            get
            {
                CanReadProperty("RrVehicalAllowanceRate", true);
                return _rr_vehical_allowance_rate;
            }
            set
            {
                CanWriteProperty("RrVehicalAllowanceRate", true);
                if (_rr_vehical_allowance_rate != value)
                {
                    _rr_vehical_allowance_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrVehicalInsurancePremium
        {
            get
            {
                CanReadProperty("RrVehicalInsurancePremium", true);
                return _rr_vehical_insurance_premium;
            }
            set
            {
                CanWriteProperty("RrVehicalInsurancePremium", true);
                if (_rr_vehical_insurance_premium != value)
                {
                    _rr_vehical_insurance_premium = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrPublicLiabilityRate2
        {
            get
            {
                CanReadProperty("RrPublicLiabilityRate2", true);
                return _rr_public_liability_rate_2;
            }
            set
            {
                CanWriteProperty("RrPublicLiabilityRate2", true);
                if (_rr_public_liability_rate_2 != value)
                {
                    _rr_public_liability_rate_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrCarrierRiskRate
        {
            get
            {
                CanReadProperty("RrCarrierRiskRate", true);
                return _rr_carrier_risk_rate;
            }
            set
            {
                CanWriteProperty("RrCarrierRiskRate", true);
                if (_rr_carrier_risk_rate != value)
                {
                    _rr_carrier_risk_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrAccRate
        {
            get
            {
                CanReadProperty("RrAccRate", true);
                return _rr_acc_rate;
            }
            set
            {
                CanWriteProperty("RrAccRate", true);
                if (_rr_acc_rate != value)
                {
                    _rr_acc_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrLicenceRate
        {
            get
            {
                CanReadProperty("RrLicenceRate", true);
                return _rr_licence_rate;
            }
            set
            {
                CanWriteProperty("RrLicenceRate", true);
                if (_rr_licence_rate != value)
                {
                    _rr_licence_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrVehicalRateOfReturnPct
        {
            get
            {
                CanReadProperty("RrVehicalRateOfReturnPct", true);
                return _rr_vehical_rate_of_return_pct;
            }
            set
            {
                CanWriteProperty("RrVehicalRateOfReturnPct", true);
                if (_rr_vehical_rate_of_return_pct != value)
                {
                    _rr_vehical_rate_of_return_pct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrSalvageRatio
        {
            get
            {
                CanReadProperty("RrSalvageRatio", true);
                return _rr_salvage_ratio;
            }
            set
            {
                CanWriteProperty("RrSalvageRatio", true);
                if (_rr_salvage_ratio != value)
                {
                    _rr_salvage_ratio = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrFuelRate
        {
            get
            {
                CanReadProperty("RrFuelRate", true);
                return _rr_fuel_rate;
            }
            set
            {
                CanWriteProperty("RrFuelRate", true);
                if (_rr_fuel_rate != value)
                {
                    _rr_fuel_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrConsumptionRate
        {
            get
            {
                CanReadProperty("RrConsumptionRate", true);
                return _rr_consumption_rate;
            }
            set
            {
                CanWriteProperty("RrConsumptionRate", true);
                if (_rr_consumption_rate != value)
                {
                    _rr_consumption_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RrFrozen
        {
            get
            {
                CanReadProperty("RrFrozen", true);
                return _rr_frozen;
            }
            set
            {
                CanWriteProperty("RrFrozen", true);
                if (_rr_frozen != value)
                {
                    _rr_frozen = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RrItemProcRatePerHour
        {
            get
            {
                CanReadProperty("RrItemProcRatePerHour", true);
                return _rr_item_proc_rate_per_hour;
            }
            set
            {
                CanWriteProperty("RrItemProcRatePerHour", true);
                if (_rr_item_proc_rate_per_hour != value)
                {
                    _rr_item_proc_rate_per_hour = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrRuc
        {
            get
            {
                CanReadProperty("RrRuc", true);
                return _rr_ruc;
            }
            set
            {
                CanWriteProperty("RrRuc", true);
                if (_rr_ruc != value)
                {
                    _rr_ruc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrAccounting
        {
            get
            {
                CanReadProperty("RrAccounting", true);
                return _rr_accounting;
            }
            set
            {
                CanWriteProperty("RrAccounting", true);
                if (_rr_accounting != value)
                {
                    _rr_accounting = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrTelephone
        {
            get
            {
                CanReadProperty("RrTelephone", true);
                return _rr_telephone;
            }
            set
            {
                CanWriteProperty("RrTelephone", true);
                if (_rr_telephone != value)
                {
                    _rr_telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrSundries
        {
            get
            {
                CanReadProperty("RrSundries", true);
                return _rr_sundries;
            }
            set
            {
                CanWriteProperty("RrSundries", true);
                if (_rr_sundries != value)
                {
                    _rr_sundries = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrSundriesK
        {
            get
            {
                CanReadProperty("RrSundriesK", true);
                return _rr_sundries_k;
            }
            set
            {
                CanWriteProperty("RrSundriesK", true);
                if (_rr_sundries_k != value)
                {
                    _rr_sundries_k = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _contract_seq_number);
        }
        #endregion

        #region Factory Methods
        public static ContractRates NewContractRates(int? contract_no, int? contract_seq_number)
        {
            return Create(contract_no, contract_seq_number);
        }

        public static ContractRates[] GetAllContractRates(int? contract_no, int? contract_seq_number)
        {
            return Fetch(contract_no, contract_seq_number).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? contract_no, int? contract_seq_number)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "contract_no", contract_no);
                    pList.Add(cm, "contract_seq_number", contract_seq_number);
                    cm.CommandText = @"SELECT contract_rates.contract_no,   
                                         contract_rates.contract_seq_number,   
                                         contract_rates.rr_nominal_vehical_value,   
                                         contract_rates.rr_wage_hourly_rate,   
                                         contract_rates.rr_repairs_maintenance_rate,   
                                         contract_rates.rr_tyre_tubes_rate,   
                                         contract_rates.rr_vehical_allowance_rate,   
                                         contract_rates.rr_vehical_insurance_premium,   
                                         contract_rates.rr_public_liability_rate_2,   
                                         contract_rates.rr_carrier_risk_rate,   
                                         contract_rates.rr_acc_rate,   
                                         contract_rates.rr_licence_rate,   
                                         contract_rates.rr_vehical_rate_of_return_pct,   
                                         contract_rates.rr_salvage_ratio,   
                                         contract_rates.rr_fuel_rate,   
                                         contract_rates.rr_consumption_rate,   
                                         contract_rates.rr_frozen,   
                                         contract_rates.rr_item_proc_rate_per_hour,   
                                         contract_rates.rr_ruc,   
                                         contract_rates.rr_accounting,   
                                         contract_rates.rr_telephone,   
                                         contract_rates.rr_sundries,   
                                         contract_rates.rr_sundries_k  
                                    FROM contract_rates  
                                   WHERE ( contract_rates.contract_no = @contract_no ) AND  
                                         ( contract_rates.contract_seq_number = @contract_seq_number )";

                    List<ContractRates> _list = new List<ContractRates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ContractRates instance = new ContractRates();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr, 1);
                            instance._rr_nominal_vehical_value = GetValueFromReader<Decimal?>(dr, 2);
                            instance._rr_wage_hourly_rate = GetValueFromReader<Decimal?>(dr, 3);
                            instance._rr_repairs_maintenance_rate = GetValueFromReader<Decimal?>(dr, 4);

                            instance._rr_tyre_tubes_rate = GetValueFromReader<Decimal?>(dr, 5);
                            instance._rr_vehical_allowance_rate = GetValueFromReader<Decimal?>(dr, 6);
                            instance._rr_vehical_insurance_premium = GetValueFromReader<Decimal?>(dr, 7);
                            instance._rr_public_liability_rate_2 = GetValueFromReader<Decimal?>(dr, 8);
                            instance._rr_carrier_risk_rate = GetValueFromReader<Decimal?>(dr, 9);

                            instance._rr_acc_rate = GetValueFromReader<Decimal?>(dr, 10);
                            instance._rr_licence_rate = GetValueFromReader<Decimal?>(dr, 11);
                            instance._rr_vehical_rate_of_return_pct = GetValueFromReader<Decimal?>(dr, 12);
                            instance._rr_salvage_ratio = GetValueFromReader<Decimal?>(dr, 13);
                            instance._rr_fuel_rate = GetValueFromReader<Decimal?>(dr, 14);

                            instance._rr_consumption_rate = GetValueFromReader<Decimal?>(dr, 15);
                            instance._rr_frozen = GetValueFromReader<String>(dr, 16);
                            instance._rr_item_proc_rate_per_hour = GetValueFromReader<Int32?>(dr, 17);
                            instance._rr_ruc = GetValueFromReader<Decimal?>(dr, 18);
                            instance._rr_accounting = GetValueFromReader<Decimal?>(dr, 19);

                            instance._rr_telephone = GetValueFromReader<Decimal?>(dr, 20);
                            instance._rr_sundries = GetValueFromReader<Decimal?>(dr, 21);
                            instance._rr_sundries_k = GetValueFromReader<Decimal?>(dr, 22);

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
                if (GenerateUpdateCommandText(cm, "contract_rates", ref pList))
                {
                    cm.CommandText += " WHERE  contract_rates.contract_no = @contract_no AND " +
                        "contract_rates.contract_seq_number = @contract_seq_number ";

                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
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
                if (GenerateInsertCommandText(cm, "contract_rates", pList))
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
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    cm.CommandText = "DELETE FROM contract_rates WHERE " +
                    "contract_rates.contract_no = @contract_no AND " +
                    "contract_rates.contract_seq_number = @contract_seq_number ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no, int? contract_seq_number)
        {
            _contract_no = contract_no;
            _contract_seq_number = contract_seq_number;
        }
    }
}
