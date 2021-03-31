using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  Allowances  28-Mar-2021:  New
    // Data entity for vehicle allowance calculations
    // [31-Mar-2021] Changed repairs_pa to repairs_pk

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("var_id", "_var_id", "vehicle_allowance_rates")]
    [MapInfo("var_description", "_var_description", "vehicle_allowance_rates")]
    [MapInfo("var_carrier_pa", "_var_carrier_pa", "vehicle_allowance_rates")]
    [MapInfo("var_repairs_pk", "_var_repairs_pk", "vehicle_allowance_rates")]
    [MapInfo("var_licence_pa", "_var_licence_pa", "vehicle_allowance_rates")]
    [MapInfo("var_tyres_pk", "_var_tyres_pk", "vehicle_allowance_rates")]
    [MapInfo("var_allowance_pa", "_var_allowance_pa", "vehicle_allowance_rates")]
    [MapInfo("var_ror_pa", "_var_ror_pa", "vehicle_allowance_rates")]
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

		public static VehicleAllowanceRates[] GetAllVehicleAllowanceRates( int? in_var_id )
		{
            return Fetch(in_var_id).list;
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
        private void FetchEntity(int? in_var_id)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    cm.CommandType = CommandType.Text;
                    cm.CommandText =
                        " SELECT var_id"
                        + "      var_description "
                        + "      var_carrier_pa "
                        + "      var_repairs_pk "
                        + "      var_licemce_pa "
                        + "      var_tyres_pk "
                        + "      var_allowance_pk "
                        + "      var_insurance_pa "
                        + "      var_ror_pa "
                        + " FROM rd.vehicle_allowance_rates "
                        + "WHERE var_id = @in_var_id ";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_var_id", in_var_id);

                    try
                    {
                        SqlErrCode = 0;
                        List<VehicleAllowanceRates> _list = new List<VehicleAllowanceRates>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                VehicleAllowanceRates instance = new VehicleAllowanceRates();
                                instance._var_id           = GetValueFromReader<int?>(dr, 0);
                                instance._var_description  = GetValueFromReader<string>(dr, 1);
                                instance._var_carrier_pa   = GetValueFromReader<decimal?>(dr, 2);
                                instance._var_repairs_pk   = GetValueFromReader<decimal?>(dr, 3);
                                instance._var_licence_pa   = GetValueFromReader<decimal?>(dr, 4);
                                instance._var_tyres_pk     = GetValueFromReader<decimal?>(dr, 5);
                                instance._var_allowance_pk = GetValueFromReader<decimal?>(dr, 6);
                                instance._var_insurance_pa = GetValueFromReader<decimal?>(dr, 7);
                                instance._var_ror_pa       = GetValueFromReader<decimal?>(dr, 8);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
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
		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
