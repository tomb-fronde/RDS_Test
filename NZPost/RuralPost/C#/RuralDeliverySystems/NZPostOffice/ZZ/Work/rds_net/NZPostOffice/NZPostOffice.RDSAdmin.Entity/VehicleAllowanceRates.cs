using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB  Allowances  28-Mar-2021:  New
    // Data entity for vehicle allowance calculations
    // [28-Apr-2021] Add columns var_effective_date, var_notes

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("var_id", "_var_id", "vehicle_allowance_rates")]
    [MapInfo("var_description", "_var_description", "vehicle_allowance_rates")]
    [MapInfo("var_carrier_pa", "_var_carrier_pa", "vehicle_allowance_rates")]
    [MapInfo("var_repairs_pk", "_var_repairs_pk", "vehicle_allowance_rates")]
    [MapInfo("var_licence_pa", "_var_licence_pa", "vehicle_allowance_rates")]
    [MapInfo("var_tyres_pk", "_var_tyres_pk", "vehicle_allowance_rates")]
    [MapInfo("var_allowance_pk", "_var_allowance_pk", "vehicle_allowance_rates")]
    [MapInfo("var_insurance_pa", "_var_insurance_pa", "vehicle_allowance_rates")]
    [MapInfo("var_ror_pa", "_var_ror_pa", "vehicle_allowance_rates")]
    [MapInfo("var_fuel_use_pk","_var_fuel_use_pk", "vehicle_allowance_rates")]
    [MapInfo("var_fuel_rate","_var_fuel_rate", "vehicle_allowance_rates")]
    [MapInfo("var_ruc_rate_pk", "_var_ruc_rate_pk", "vehicle_allowance_rates")]
    [MapInfo("var_effective_date", "_var_effective_date", "vehicle_allowance_rates")]
    [MapInfo("var_notes", "_var_notes", "vehicle_allowance_rates")]
    [System.Serializable()]

    public class VehicleAllowanceRates : Entity<VehicleAllowanceRates>
	{
		#region Business Methods
		[DBField()]
		private int?  _var_id;

        [DBField()]
        private string _var_description;

        [DBField()]
        private decimal? _var_carrier_pa;

        [DBField()]
        private decimal? _var_repairs_pk;

        [DBField()]
        private decimal? _var_licence_pa;

        [DBField()]
        private decimal? _var_tyres_pk;

        [DBField()]
        private decimal? _var_allowance_pk;

        [DBField()]
        private decimal? _var_insurance_pa;

        [DBField()]
        private decimal? _var_ror_pa;

        [DBField()]
        private decimal? _var_fuel_use_pk;

        [DBField()]
        private decimal? _var_fuel_rate;

        [DBField()]
        private decimal? _var_ruc_rate_pk;

         [DBField()]
        private DateTime? _var_effective_date;

        [DBField()]
        private string _var_notes;


		public virtual int? VarId
		{
			get
			{
                CanReadProperty("VarId", true);
                return _var_id;
			}
			set
			{
                CanWriteProperty("VarId", true);
                if (_var_id != value)
				{
                    _var_id = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string VarDescription
        {
            get
            {
                CanReadProperty("VarDescription", true);
                return _var_description;
            }
            set
            {
                CanWriteProperty("VarDescription", true);
                if (_var_description != value)
                {
                    _var_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarCarrierPa
        {
            get
            {
                CanReadProperty("VarCarrierPa", true);
                return _var_carrier_pa;
            }
            set
            {
                CanWriteProperty("VarCarrierPa", true);
                if (_var_carrier_pa != value)
                {
                    _var_carrier_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarRepairsPk
        {
            get
            {
                CanReadProperty("VarRepairsPk", true);
                return _var_repairs_pk;
            }
            set
            {
                CanWriteProperty("VarRepairsPk", true);
                if (_var_repairs_pk != value)
                {
                    _var_repairs_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarLicencePa
        {
            get
            {
                CanReadProperty("VarLicencePa", true);
                return _var_licence_pa;
            }
            set
            {
                CanWriteProperty("VarLicencePa", true);
                if (_var_licence_pa != value)
                {
                    _var_licence_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarTyresPk
        {
            get
            {
                CanReadProperty("VarTyresPk", true);
                return _var_tyres_pk;
            }
            set
            {
                CanWriteProperty("VarTyresPk", true);
                if (_var_tyres_pk != value)
                {
                    _var_tyres_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarAllowancePk
        {
            get
            {
                CanReadProperty("VarAllowancePk", true);
                return _var_allowance_pk;
            }
            set
            {
                CanWriteProperty("VarAllowancePk", true);
                if (_var_allowance_pk != value)
                {
                    _var_allowance_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarInsurancePa
        {
            get
            {
                CanReadProperty("VarInsurancePa", true);
                return _var_insurance_pa;
            }
            set
            {
                CanWriteProperty("VarInsurancePa", true);
                if (_var_insurance_pa != value)
                {
                    _var_insurance_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarRorPa
        {
            get
            {
                CanReadProperty("VarRorPa", true);
                return _var_ror_pa;
            }
            set
            {
                CanWriteProperty("VarRorPa", true);
                if (_var_ror_pa != value)
                {
                    _var_ror_pa = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarFuelUsePk
        {
            get
            {
                CanReadProperty("VarFuelUsePk", true);
                return _var_fuel_use_pk;
            }
            set
            {
                CanWriteProperty("VarFuelUsePk", true);
                if (_var_fuel_use_pk != value)
                {
                    _var_fuel_use_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarFuelRate
        {
            get
            {
                CanReadProperty("VarFuelRate", true);
                return _var_fuel_rate;
            }
            set
            {
                CanWriteProperty("VarFuelRate", true);
                if (_var_fuel_rate != value)
                {
                    _var_fuel_rate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? VarRucRatePk
        {
            get
            {
                CanReadProperty("VarRucRatePk", true);
                return _var_ruc_rate_pk;
            }
            set
            {
                CanWriteProperty("VarRucRatePk", true);
                if (_var_ruc_rate_pk != value)
                {
                    _var_ruc_rate_pk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VarNotes
        {
            get
            {
                CanReadProperty("VarNotes", true);
                return _var_notes;
            }
            set
            {
                CanWriteProperty("VarNotes", true);
                if (_var_notes != value)
                {
                    _var_notes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? VarEffectiveDate
        {
            get
            {
                CanReadProperty("VarEffectiveDate", true);
                return _var_effective_date;
            }
            set
            {
                CanWriteProperty("VarEffectiveDate", true);
                if (_var_effective_date != value)
                {
                    _var_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        private VehicleAllowanceRates[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static VehicleAllowanceRates NewVehicleAllowanceRates()
		{
			return Create();
		}

		public static VehicleAllowanceRates[] GetAllVehicleAllowanceRates()
		{
            //return Fetch().list;
            return Fetch().dataList;
		}
		#endregion

		#region Data Access

        public virtual void marknew()
        {
            base.MarkClean();
            base.MarkNew();
        }

        public int SqlErrCode = 0;
        public string SqlErrMsg = "";

		[ServerMethod]
        private void FetchEntity()
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();

                    GenerateSelectCommandText(cm, "vehicle_allowance_rates");
                    cm.CommandText += " WHERE vehicle_allowance_rates.var_id > 0";
                    List<VehicleAllowanceRates> list = new List<VehicleAllowanceRates>();

                    try
                    {
                        SqlErrCode = 0;
                        List<VehicleAllowanceRates> _list = new List<VehicleAllowanceRates>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                VehicleAllowanceRates instance = new VehicleAllowanceRates();
                                instance.StoreFieldValues(dr, "vehicle_allowance_rates");
                                instance.MarkOld();
                                list.Add(instance);
                            }
                            dataList = new VehicleAllowanceRates[list.Count];
                            list.CopyTo(dataList);
                            //list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        SqlErrCode = -1;
                        SqlErrMsg  = e.Message;
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
                if (GenerateUpdateCommandText(cm, "vehicle_allowance_rates", ref pList))
                {
                    cm.CommandText += " WHERE  vehicle_allowance_rates.var_id = @var_id ";

                    pList.Add(cm, "var_id", GetInitialValue("_var_id"));
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

                if (GenerateInsertCommandText(cm, "vehicle_allowance_rates", pList))
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
                    pList.Add(cm, "var_id", GetInitialValue("_var_id"));
                    cm.CommandText = "DELETE FROM vehicle_allowance_rates " 
                                   + " WHERE vehicle_allowance_rates.var_id = @var_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
