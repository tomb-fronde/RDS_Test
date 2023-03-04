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
    [MapInfo("vt_key", "_vt_key", "vehicle_rate")]
    [MapInfo("vr_rates_effective_date", "_vr_rates_effective_date", "vehicle_rate")]
    [MapInfo("vr_nominal_vehicle_value", "_vr_nominal_vehicle_value", "vehicle_rate")]
    [MapInfo("vr_repairs_maintenance_rate", "_vr_repairs_maintenance_rate", "vehicle_rate")]
    [MapInfo("vr_tyre_tubes_rate", "_vr_tyre_tubes_rate", "vehicle_rate")]
    [MapInfo("vr_vehicle_allowance_rate", "_vr_vehicle_allowance_rate", "vehicle_rate")]
    [MapInfo("vr_licence_rate", "_vr_licence_rate", "vehicle_rate")]
    [MapInfo("vr_vehicle_rate_of_return_pct", "_vr_vehicle_rate_of_return_pct", "vehicle_rate")]
    [MapInfo("vr_salvage_ratio", "_vr_salvage_ratio", "vehicle_rate")]
    [MapInfo("vr_ruc", "_vr_ruc", "vehicle_rate")]
    [MapInfo("vr_sundries_k", "_vr_sundries_k", "vehicle_rate")]
    [MapInfo("vr_vehicle_value_insurance_pct", "_vr_vehicle_value_insurance_pct", "vehicle_rate")]
    [MapInfo("vr_livery", "_vr_livery", "vehicle_rate")]
    [System.Serializable()]

    public class VehicleRates2001 : Entity<VehicleRates2001>
    {
        #region Business Methods
        [DBField()]
        private int? _vt_key;

        [DBField()]
        private DateTime? _vr_rates_effective_date;

        [DBField()]
        private decimal? _vr_nominal_vehicle_value;

        [DBField()]
        private decimal? _vr_repairs_maintenance_rate;

        [DBField()]
        private decimal? _vr_tyre_tubes_rate;

        [DBField()]
        private decimal? _vr_vehicle_allowance_rate;

        [DBField()]
        private decimal? _vr_licence_rate;

        [DBField()]
        private decimal? _vr_vehicle_rate_of_return_pct;

        [DBField()]
        private decimal? _vr_salvage_ratio;

        [DBField()]
        private decimal? _vr_ruc;

        [DBField()]
        private decimal? _vr_sundries_k;

        [DBField()]
        private decimal? _vr_vehicle_value_insurance_pct;

        [DBField()]
        private decimal? _vr_livery;


        public virtual int? VtKey
        {
            get
            {
                CanReadProperty("VtKey", true);
                return _vt_key;
            }
            set
            {
                CanWriteProperty("VtKey", true);
                if (_vt_key != value)
                {
                    _vt_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? VrRatesEffectiveDate
        {
            get
            {
                CanReadProperty("VrRatesEffectiveDate", true);
                return _vr_rates_effective_date;
            }
            set
            {
                CanWriteProperty("VrRatesEffectiveDate", true);
                if (_vr_rates_effective_date != value)
                {
                    _vr_rates_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrNominalVehicleValue
        {
            get
            {
                CanReadProperty("VrNominalVehicleValue", true);
                return _vr_nominal_vehicle_value;
            }
            set
            {
                CanWriteProperty("VrNominalVehicleValue", true);
                if (_vr_nominal_vehicle_value != value)
                {
                    _vr_nominal_vehicle_value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrRepairsMaintenanceRate
        {
            get
            {
                CanReadProperty("VrRepairsMaintenanceRate", true);
                return _vr_repairs_maintenance_rate;
            }
            set
            {
                CanWriteProperty("VrRepairsMaintenanceRate", true);
                if (_vr_repairs_maintenance_rate != value)
                {
                    _vr_repairs_maintenance_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrTyreTubesRate
        {
            get
            {
                CanReadProperty("VrTyreTubesRate", true);
                return _vr_tyre_tubes_rate;
            }
            set
            {
                CanWriteProperty("VrTyreTubesRate", true);
                if (_vr_tyre_tubes_rate != value)
                {
                    _vr_tyre_tubes_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrVehicleAllowanceRate
        {
            get
            {
                CanReadProperty("VrVehicleAllowanceRate", true);
                return _vr_vehicle_allowance_rate;
            }
            set
            {
                CanWriteProperty("VrVehicleAllowanceRate", true);
                if (_vr_vehicle_allowance_rate != value)
                {
                    _vr_vehicle_allowance_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrLicenceRate
        {
            get
            {
                CanReadProperty("VrLicenceRate", true);
                return _vr_licence_rate;
            }
            set
            {
                CanWriteProperty("VrLicenceRate", true);
                if (_vr_licence_rate != value)
                {
                    _vr_licence_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrVehicleRateOfReturnPct
        {
            get
            {
                CanReadProperty("VrVehicleRateOfReturnPct", true);
                return _vr_vehicle_rate_of_return_pct;
            }
            set
            {
                CanWriteProperty("VrVehicleRateOfReturnPct", true);
                if (_vr_vehicle_rate_of_return_pct != value)
                {
                    _vr_vehicle_rate_of_return_pct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrSalvageRatio
        {
            get
            {
                CanReadProperty("VrSalvageRatio", true);
                return _vr_salvage_ratio;
            }
            set
            {
                CanWriteProperty("VrSalvageRatio", true);
                if (_vr_salvage_ratio != value)
                {
                    _vr_salvage_ratio = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrRuc
        {
            get
            {
                CanReadProperty("VrRuc", true);
                return _vr_ruc;
            }
            set
            {
                CanWriteProperty("VrRuc", true);
                if (_vr_ruc != value)
                {
                    _vr_ruc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrSundriesK
        {
            get
            {
                CanReadProperty("VrSundriesK", true);
                return _vr_sundries_k;
            }
            set
            {
                CanWriteProperty("VrSundriesK", true);
                if (_vr_sundries_k != value)
                {
                    _vr_sundries_k = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrVehicleValueInsurancePct
        {
            get
            {
                CanReadProperty("VrVehicleValueInsurancePct", true);
                return _vr_vehicle_value_insurance_pct;
            }
            set
            {
                CanWriteProperty("VrVehicleValueInsurancePct", true);
                if (_vr_vehicle_value_insurance_pct != value)
                {
                    _vr_vehicle_value_insurance_pct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VrLivery
        {
            get
            {
                CanReadProperty("VrLivery", true);
                return _vr_livery;
            }
            set
            {
                CanWriteProperty("VrLivery", true);
                if (_vr_livery != value)
                {
                    _vr_livery = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}", _vt_key, _vr_rates_effective_date);
        }
        #endregion

        public void MarkNewEntity()
        {
            base.MarkNew();
        }

        #region Factory Methods
        public static VehicleRates2001 NewVehicleRates2001(int? in_vt_key, DateTime? in_effective_date)
        {
            return Create(in_vt_key, in_effective_date);
        }

        public static VehicleRates2001[] GetAllVehicleRates2001(int? in_vt_key, DateTime? in_effective_date)
        {
            return Fetch(in_vt_key, in_effective_date).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? in_vt_key, DateTime? in_effective_date)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_vt_key", in_vt_key);
                    pList.Add(cm, "in_effective_date", in_effective_date);
                    cm.CommandText = "rd.sp_GetVehicleRate";
                    List<VehicleRates2001> _list = new List<VehicleRates2001>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            VehicleRates2001 instance = new VehicleRates2001();
                            instance._vt_key = GetValueFromReader<Int32?>(dr,0);
                            instance._vr_rates_effective_date = GetValueFromReader<DateTime?>(dr,1);
                            instance._vr_nominal_vehicle_value = GetValueFromReader<Decimal?>(dr,2);
                            instance._vr_repairs_maintenance_rate = GetValueFromReader<Decimal?>(dr,3);
                            instance._vr_tyre_tubes_rate = GetValueFromReader<Decimal?>(dr,4);
                            instance._vr_vehicle_allowance_rate = GetValueFromReader<Decimal?>(dr,5);
                            instance._vr_licence_rate = GetValueFromReader<Decimal?>(dr,6);
                            instance._vr_vehicle_rate_of_return_pct = GetValueFromReader<Decimal?>(dr,7);
                            instance._vr_salvage_ratio = GetValueFromReader<Decimal?>(dr,8);
                            instance._vr_ruc = GetValueFromReader<Decimal?>(dr,9);
                            instance._vr_sundries_k = GetValueFromReader<Decimal?>(dr,10);
                            instance._vr_vehicle_value_insurance_pct = GetValueFromReader<Decimal?>(dr,11);
                            instance._vr_livery = GetValueFromReader<Decimal?>(dr,12);
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
                if (GenerateUpdateCommandText(cm, "vehicle_rate", ref pList))
                {
                    cm.CommandText += " WHERE  vehicle_rate.vt_key = @vt_key " 
                                    + "   AND vehicle_rate.vr_rates_effective_date = @vr_rates_effective_date ";

                    pList.Add(cm, "vt_key", GetInitialValue("_vt_key"));
                    pList.Add(cm, "vr_rates_effective_date", GetInitialValue("_vr_rates_effective_date"));
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
                if (GenerateInsertCommandText(cm, "vehicle_rate", pList))
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

                    pList.Add(cm, "vt_key", GetInitialValue("_vt_key"));
                    pList.Add(cm, "vr_rates_effective_date", GetInitialValue("_vr_rates_effective_date"));
                    cm.CommandText = "DELETE FROM vehicle_rate " 
                                   + " WHERE vehicle_rate.vt_key = @vt_key " 
                                   + "   AND vehicle_rate.vr_rates_effective_date = @vr_rates_effective_date ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? vt_key, DateTime? vr_rates_effective_date)
        {
            _vt_key = vt_key;
            _vr_rates_effective_date = vr_rates_effective_date;
        }
    }
}
