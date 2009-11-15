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
    // TJB  RD7_0038:  Added tablename (non_vehicle_override_rate)
    [MapInfo("contract_no", "_contract_no", "non_vehicle_override_rate")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "non_vehicle_override_rate")]
    [MapInfo("nvor_wage_hourly_rate", "_nvor_wage_hourly_rate", "non_vehicle_override_rate")]
    [MapInfo("nvor_public_liability_rate_2", "_nvor_public_liability_rate_2", "non_vehicle_override_rate")]
    [MapInfo("nvor_carrier_risk_rate", "_nvor_carrier_risk_rate", "non_vehicle_override_rate")]
    [MapInfo("nvor_acc_rate", "_nvor_acc_rate", "non_vehicle_override_rate")]
    [MapInfo("nvor_item_proc_rate_per_hour", "_nvor_item_proc_rate_per_hour", "non_vehicle_override_rate")]
    [MapInfo("nvor_frozen", "_nvor_frozen", "non_vehicle_override_rate")]
    [MapInfo("nvor_accounting", "_nvor_accounting", "non_vehicle_override_rate")]
    [MapInfo("nvor_telephone", "_nvor_telephone", "non_vehicle_override_rate")]
    [MapInfo("nvor_sundries", "_nvor_sundries", "non_vehicle_override_rate")]
    [MapInfo("nvor_acc_rate_amount", "_nvor_acc_rate_amount", "non_vehicle_override_rate")]
    [MapInfo("nvor_uniform", "_nvor_uniform", "non_vehicle_override_rate")]
    [MapInfo("nvor_delivery_wage_rate", "_nvor_delivery_wage_rate", "non_vehicle_override_rate")]
    [MapInfo("nvor_processing_wage_rate", "_nvor_processing_wage_rate", "non_vehicle_override_rate")]
    [System.Serializable()]

    public class NonVehicleOverrideRates : Entity<NonVehicleOverrideRates>
    {
        private string SQLErrText;

        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

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

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _contract_no, _contract_seq_number);
        }
        #endregion

        #region Factory Methods
        public static NonVehicleOverrideRates NewNonVehicleOverrideRates(int? incontract_no, int? incontract_seq_no)
        {
            return Create(incontract_no, incontract_seq_no);
        }

        public static NonVehicleOverrideRates[] GetAllNonVehicleOverrideRates(int? incontract_no, int? incontract_seq_no)
        {
            return Fetch(incontract_no, incontract_seq_no).list;
        }

        // TJB  RD7_0038  Nov-2009: Added (it wasn't included originally!)
        public virtual void marknew()
        {
            base.MarkClean();
            base.MarkNew();
        }
        #endregion

        #region Data Access
        [ServerMethod()]
        private void FetchEntity(int? incontract_no, int? incontract_seq_no)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "incontract_no", incontract_no);
                    pList.Add(cm, "incontract_seq_no", incontract_seq_no);
                    cm.CommandText = "rd.sp_get_non_vehicle_override_rates";
                    List<NonVehicleOverrideRates> _list = new List<NonVehicleOverrideRates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            NonVehicleOverrideRates instance = new NonVehicleOverrideRates();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr,1);
                            instance._nvor_wage_hourly_rate = GetValueFromReader<Decimal?>(dr,2);
                            instance._nvor_public_liability_rate_2 = GetValueFromReader<Decimal?>(dr,3);
                            instance._nvor_carrier_risk_rate = GetValueFromReader<Decimal?>(dr,4);
                            instance._nvor_acc_rate = GetValueFromReader<Decimal?>(dr,5);
                            instance._nvor_item_proc_rate_per_hour = GetValueFromReader<Int32?>(dr,6);
                            instance._nvor_frozen = GetValueFromReader<String>(dr,7);
                            instance._nvor_accounting = GetValueFromReader<Decimal?>(dr,8);
                            instance._nvor_telephone = GetValueFromReader<Decimal?>(dr,9);
                            instance._nvor_sundries = GetValueFromReader<Decimal?>(dr,10);
                            instance._nvor_acc_rate_amount = GetValueFromReader<Decimal?>(dr,11);
                            instance._nvor_uniform = GetValueFromReader<Decimal?>(dr,12);
                            instance._nvor_delivery_wage_rate = GetValueFromReader<Decimal?>(dr,13);
                            instance._nvor_processing_wage_rate = GetValueFromReader<Decimal?>(dr,14);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }
        
        // TJB  RD7_0038  Nov-2009: Added (it wasn't included originally!)
        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "non_vehicle_override_rate", pList))
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        SQLErrText = e.Message;
                    }
                }
                StoreInitialValues();
            }
        }

        // TJB  RD7_0038  Nov-2009: Added (it wasn't included originally!)
        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "non_vehicle_override_rate", ref pList))
                {
                    cm.CommandText += " WHERE contract_no = @contract_no"
                                      + " AND contract_seq_number = @contract_seq_number";
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception e)
                    {
                        SQLErrText = e.Message;
                    }
                }
                StoreInitialValues();
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
