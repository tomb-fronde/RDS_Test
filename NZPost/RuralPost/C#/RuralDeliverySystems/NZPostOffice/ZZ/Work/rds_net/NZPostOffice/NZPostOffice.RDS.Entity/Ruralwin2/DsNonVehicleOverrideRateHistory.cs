using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin2
{
    // TJB  RPCR_099  Jan_2016: OBSOLETE
    // non_vehicle_override_rate_history table no longer used
    //
    // TJB  RPCR_099  Dec-2015
    // Added nvorh_change_effective_date
    //
    // TJB  RPCR_041  Nov-2012
    // Added nvor_relief_weeks
    //
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "non_vehicle_override_rate_history")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_effective_date", "_nvor_effective_date", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_wage_hourly_rate", "_nvor_wage_hourly_rate", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_public_liability_rate_2", "_nvor_public_liability_rate_2", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_carrier_risk_rate", "_nvor_carrier_risk_rate", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_acc_rate", "_nvor_acc_rate", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_item_proc_rate_per_hour", "_nvor_item_proc_rate_per_hour", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_frozen", "_nvor_frozen", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_accounting", "_nvor_accounting", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_telephone", "_nvor_telephone", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_sundries", "_nvor_sundries", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_acc_rate_amount", "_nvor_acc_rate_amount", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_uniform", "_nvor_uniform", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_delivery_wage_rate", "_nvor_delivery_wage_rate", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_processing_wage_rate", "_nvor_processing_wage_rate", "non_vehicle_override_rate_history")]
    [MapInfo("nvor_relief_weeks", "_nvor_relief_weeks", "non_vehicle_override_rate_history")]
    [MapInfo("nvorh_change_effective_date", "_nvorh_change_effective_date", "non_vehicle_override_rate_history")]
    [System.Serializable()]

    public class NonVehicleOverrideRateHistory : Entity<NonVehicleOverrideRateHistory>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private DateTime? _nvor_effective_date;

        [DBField()]
        private decimal? _nvor_wage_hourly_rate;

        [DBField()]
        private decimal? _nvor_public_liability_rate_2;

        [DBField()]
        private decimal? _nvor_carrier_risk_rate;

        [DBField()]
        private decimal? _nvor_acc_rate;

        [DBField()]
        private int? _nvor_item_proc_rate_per_hour;

        [DBField()]
        private string _nvor_frozen;

        [DBField()]
        private decimal? _nvor_accounting;

        [DBField()]
        private decimal? _nvor_telephone;

        [DBField()]
        private decimal? _nvor_sundries;

        [DBField()]
        private decimal? _nvor_acc_rate_amount;

        [DBField()]
        private decimal? _nvor_uniform;

        [DBField()]
        private decimal? _nvor_delivery_wage_rate;

        [DBField()]
        private decimal? _nvor_processing_wage_rate;

        [DBField()]
        private decimal? _nvor_relief_weeks;

        [DBField()]
        private DateTime? _nvorh_change_effective_date;

        //----------------------------------------------------------------------------------------
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

        public virtual DateTime? NvorEffectiveDate
        {
            get
            {
                CanReadProperty("NvorEffectiveDate", true);
                return _nvor_effective_date;
            }
            set
            {
                CanWriteProperty("NvorEffectiveDate", true);
                if (_nvor_effective_date != value)
                {
                    _nvor_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorWageHourlyRate
        {
            get
            {
                CanReadProperty("NvorWageHourlyRate", true);
                return _nvor_wage_hourly_rate;
            }
            set
            {
                CanWriteProperty("NvorWageHourlyRate", true);
                if (_nvor_wage_hourly_rate != value)
                {
                    _nvor_wage_hourly_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorPublicLiabilityRate2
        {
            get
            {
                CanReadProperty("NvorPublicLiabilityRate2", true);
                return _nvor_public_liability_rate_2;
            }
            set
            {
                CanWriteProperty("NvorPublicLiabilityRate2", true);
                if (_nvor_public_liability_rate_2 != value)
                {
                    _nvor_public_liability_rate_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorCarrierRiskRate
        {
            get
            {
                CanReadProperty("NvorCarrierRiskRate", true);
                return _nvor_carrier_risk_rate;
            }
            set
            {
                CanWriteProperty("NvorCarrierRiskRate", true);
                if (_nvor_carrier_risk_rate != value)
                {
                    _nvor_carrier_risk_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorAccRate
        {
            get
            {
                CanReadProperty("NvorAccRate", true);
                return _nvor_acc_rate;
            }
            set
            {
                CanWriteProperty("NvorAccRate", true);
                if (_nvor_acc_rate != value)
                {
                    _nvor_acc_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? NvorItemProcRatePerHour
        {
            get
            {
                CanReadProperty("NvorItemProcRatePerHour", true);
                return _nvor_item_proc_rate_per_hour;
            }
            set
            {
                CanWriteProperty("NvorItemProcRatePerHour", true);
                if (_nvor_item_proc_rate_per_hour != value)
                {
                    _nvor_item_proc_rate_per_hour = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NvorFrozen
        {
            get
            {
                CanReadProperty("NvorFrozen", true);
                return _nvor_frozen;
            }
            set
            {
                CanWriteProperty("NvorFrozen", true);
                if (_nvor_frozen != value)
                {
                    _nvor_frozen = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorAccounting
        {
            get
            {
                CanReadProperty("NvorAccounting", true);
                return _nvor_accounting;
            }
            set
            {
                CanWriteProperty("NvorAccounting", true);
                if (_nvor_accounting != value)
                {
                    _nvor_accounting = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorTelephone
        {
            get
            {
                CanReadProperty("NvorTelephone", true);
                return _nvor_telephone;
            }
            set
            {
                CanWriteProperty("NvorTelephone", true);
                if (_nvor_telephone != value)
                {
                    _nvor_telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorSundries
        {
            get
            {
                CanReadProperty("NvorSundries", true);
                return _nvor_sundries;
            }
            set
            {
                CanWriteProperty("NvorSundries", true);
                if (_nvor_sundries != value)
                {
                    _nvor_sundries = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorAccRateAmount
        {
            get
            {
                CanReadProperty("NvorAccRateAmount", true);
                return _nvor_acc_rate_amount;
            }
            set
            {
                CanWriteProperty("NvorAccRateAmount", true);
                if (_nvor_acc_rate_amount != value)
                {
                    _nvor_acc_rate_amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorUniform
        {
            get
            {
                CanReadProperty("NvorUniform", true);
                return _nvor_uniform;
            }
            set
            {
                CanWriteProperty("NvorUniform", true);
                if (_nvor_uniform != value)
                {
                    _nvor_uniform = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorDeliveryWageRate
        {
            get
            {
                CanReadProperty("NvorDeliveryWageRate", true);
                return _nvor_delivery_wage_rate;
            }
            set
            {
                CanWriteProperty("NvorDeliveryWageRate", true);
                if (_nvor_delivery_wage_rate != value)
                {
                    _nvor_delivery_wage_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorProcessingWageRate
        {
            get
            {
                CanReadProperty("NvorProcessingWageRate", true);
                return _nvor_processing_wage_rate;
            }
            set
            {
                CanWriteProperty("NvorProcessingWageRate", true);
                if (_nvor_processing_wage_rate != value)
                {
                    _nvor_processing_wage_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NvorReliefWeeks
        {
            get
            {
                CanReadProperty("NvorReliefWeeks", true);
                return _nvor_relief_weeks;
            }
            set
            {
                CanWriteProperty("NvorReliefWeeks", true);
                if (_nvor_relief_weeks != value)
                {
                    _nvor_relief_weeks = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? NvorhChangeEffectiveDate
        {
            get
            {
                CanReadProperty("NvorhChangeEffectiveDate", true);
                return _nvorh_change_effective_date;
            }
            set
            {
                CanWriteProperty("NvorhChangeEffectiveDate", true);
                if (_nvorh_change_effective_date != value)
                {
                    _nvorh_change_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        //--------------------------------------------------------------------
        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}", _contract_no, _contract_seq_number, _nvor_effective_date);
        }
        #endregion

        #region Factory Methods
        public static NonVehicleOverrideRateHistory NewNonVehicleOverrideRateHistory(int? al_contract, int? al_sequence)
        {
            return Create(al_contract, al_sequence);
        }

        public static NonVehicleOverrideRateHistory[] GetAllNonVehicleOverrideRateHistory(int? al_contract, int? al_sequence)
        {
            return Fetch(al_contract, al_sequence).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? al_contract, int? al_sequence)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "al_contract", al_contract);
                    pList.Add(cm, "al_sequence", al_sequence);
                    cm.CommandText = "SELECT non_vehicle_override_rate_history.contract_no," +
                           "non_vehicle_override_rate_history.contract_seq_number," +
                           "non_vehicle_override_rate_history.nvor_effective_date," +
                           "non_vehicle_override_rate_history.nvor_wage_hourly_rate," +
                           "non_vehicle_override_rate_history.nvor_public_liability_rate_2," +
                           "non_vehicle_override_rate_history.nvor_carrier_risk_rate," +
                           "non_vehicle_override_rate_history.nvor_acc_rate," +
                           "non_vehicle_override_rate_history.nvor_item_proc_rate_per_hour," +
                           "non_vehicle_override_rate_history.nvor_frozen," +
                           "non_vehicle_override_rate_history.nvor_accounting," +
                           "non_vehicle_override_rate_history.nvor_telephone," +
                           "non_vehicle_override_rate_history.nvor_sundries," +
                           "non_vehicle_override_rate_history.nvor_acc_rate_amount," +
                           "non_vehicle_override_rate_history.nvor_uniform," +
                           "non_vehicle_override_rate_history.nvor_delivery_wage_rate," +
                           "non_vehicle_override_rate_history.nvor_processing_wage_rate," +
                           "non_vehicle_override_rate_history.nvor_relief_weeks," +
                           "non_vehicle_override_rate_history.nvorh_change_effective_date" +
                           " FROM non_vehicle_override_rate_history " +
                           " WHERE non_vehicle_override_rate_history.contract_no = @al_contract " +
                           "   AND non_vehicle_override_rate_history.contract_seq_number = @al_sequence";

                    List<NonVehicleOverrideRateHistory> _list = new List<NonVehicleOverrideRateHistory>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            NonVehicleOverrideRateHistory instance = new NonVehicleOverrideRateHistory();
                            instance._contract_no = GetValueFromReader<int?>(dr, 0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr, 1);
                            instance._nvor_effective_date = GetValueFromReader<DateTime?>(dr, 2);
                            instance._nvor_wage_hourly_rate = GetValueFromReader<decimal?>(dr, 3);
                            instance._nvor_public_liability_rate_2 = GetValueFromReader<decimal?>(dr, 4);
                            instance._nvor_carrier_risk_rate = GetValueFromReader<decimal?>(dr, 5);
                            instance._nvor_acc_rate = GetValueFromReader<decimal?>(dr, 6);
                            instance._nvor_item_proc_rate_per_hour = GetValueFromReader<int?>(dr, 7);
                            instance._nvor_frozen = GetValueFromReader<string>(dr, 8);
                            instance._nvor_accounting = GetValueFromReader<decimal?>(dr, 9);
                            instance._nvor_telephone = GetValueFromReader<decimal?>(dr, 10);
                            instance._nvor_sundries = GetValueFromReader<decimal?>(dr, 11);
                            instance._nvor_acc_rate_amount = GetValueFromReader<decimal?>(dr, 12);
                            instance._nvor_uniform = GetValueFromReader<decimal?>(dr, 13);
                            instance._nvor_delivery_wage_rate = GetValueFromReader<decimal?>(dr, 14);
                            instance._nvor_processing_wage_rate = GetValueFromReader<decimal?>(dr, 15);
                            instance._nvor_relief_weeks = GetValueFromReader<decimal?>(dr, 16);
                            instance._nvorh_change_effective_date = GetValueFromReader<DateTime?>(dr, 17);
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
                if (GenerateUpdateCommandText(cm, "non_vehicle_override_rate_history", ref pList))
                {
                    cm.CommandText += " WHERE  non_vehicle_override_rate_history.contract_no = @contract_no AND " +
                        "non_vehicle_override_rate_history.contract_seq_number = @contract_seq_number AND " +
                        "non_vehicle_override_rate_history.nvor_effective_date = @nvor_effective_date ";

                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    pList.Add(cm, "nvor_effective_date", GetInitialValue("_nvor_effective_date"));
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
                if (GenerateInsertCommandText(cm, "non_vehicle_override_rate_history", pList))
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
                    pList.Add(cm, "nvor_effective_date", GetInitialValue("_nvor_effective_date"));
                    cm.CommandText = "DELETE FROM non_vehicle_override_rate_history WHERE " +
                    "non_vehicle_override_rate_history.contract_no = @contract_no AND " +
                    "non_vehicle_override_rate_history.contract_seq_number = @contract_seq_number AND " +
                    "non_vehicle_override_rate_history.nvor_effective_date = @nvor_effective_date ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? contract_no, int? contract_seq_number, DateTime? nvor_effective_date)
        {
            _contract_no = contract_no;
            _contract_seq_number = contract_seq_number;
            _nvor_effective_date = nvor_effective_date;
        }
    }
}
