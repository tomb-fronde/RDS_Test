using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin2
{
    // TJB  RPCR_099  Dec-2015
    // Modified select statement: Added ORDER BY clause
    // Cosmetic changes to UpdateEntity and DeleteEntity
    
    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "vehicle_override_rate")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "vehicle_override_rate")]
	[MapInfo("vor_nominal_vehicle_value", "_vor_nominal_vehicle_value", "vehicle_override_rate")]
	[MapInfo("vor_repairs_maintenance_rate", "_vor_repairs_maintenance_rate", "vehicle_override_rate")]
	[MapInfo("vor_tyre_tubes_rate", "_vor_tyre_tubes_rate", "vehicle_override_rate")]
	[MapInfo("vor_vehical_allowance_rate", "_vor_vehical_allowance_rate", "vehicle_override_rate")]
	[MapInfo("vor_licence_rate", "_vor_licence_rate", "vehicle_override_rate")]
	[MapInfo("vor_vehicle_rate_of_return_pct", "_vor_vehicle_rate_of_return_pct", "vehicle_override_rate")]
	[MapInfo("vor_salvage_ratio", "_vor_salvage_ratio", "vehicle_override_rate")]
	[MapInfo("vor_ruc", "_vor_ruc", "vehicle_override_rate")]
	[MapInfo("vor_sundries_k", "_vor_sundries_k", "vehicle_override_rate")]
	[MapInfo("vor_vehicle_insurance_premium", "_vor_vehicle_insurance_premium", "vehicle_override_rate")]
	[MapInfo("vor_fuel_rate", "_vor_fuel_rate", "vehicle_override_rate")]
	[MapInfo("vor_consumption_rate", "_vor_consumption_rate", "vehicle_override_rate")]
	[MapInfo("vor_livery", "_vor_livery", "vehicle_override_rate")]
	[MapInfo("vor_effective_date", "_vor_effective_date", "vehicle_override_rate")]
	[System.Serializable()]

	public class VehicleOverrideRate : Entity<VehicleOverrideRate>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private decimal?  _vor_nominal_vehicle_value;

		[DBField()]
		private decimal?  _vor_repairs_maintenance_rate;

		[DBField()]
		private decimal?  _vor_tyre_tubes_rate;

		[DBField()]
		private decimal?  _vor_vehical_allowance_rate;

		[DBField()]
		private decimal?  _vor_licence_rate;

		[DBField()]
		private decimal?  _vor_vehicle_rate_of_return_pct;

		[DBField()]
		private decimal?  _vor_salvage_ratio;

		[DBField()]
		private decimal?  _vor_ruc;

		[DBField()]
		private decimal?  _vor_sundries_k;

		[DBField()]
		private decimal?  _vor_vehicle_insurance_premium;

		[DBField()]
		private decimal?  _vor_fuel_rate;

		[DBField()]
		private decimal?  _vor_consumption_rate;

		[DBField()]
		private decimal?  _vor_livery;

		[DBField()]
		private DateTime?  _vor_effective_date;


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
				if ( _contract_no != value )
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
				if ( _contract_seq_number != value )
				{
					_contract_seq_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorNominalVehicleValue
		{
			get
			{
                CanReadProperty("VorNominalVehicleValue", true);
				return _vor_nominal_vehicle_value;
			}
			set
			{
                CanWriteProperty("VorNominalVehicleValue", true);
				if ( _vor_nominal_vehicle_value != value )
				{
					_vor_nominal_vehicle_value = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorRepairsMaintenanceRate
		{
			get
			{
                CanReadProperty("VorRepairsMaintenanceRate", true);
				return _vor_repairs_maintenance_rate;
			}
			set
			{
                CanWriteProperty("VorRepairsMaintenanceRate", true);
				if ( _vor_repairs_maintenance_rate != value )
				{
					_vor_repairs_maintenance_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorTyreTubesRate
		{
			get
			{
                CanReadProperty("VorTyreTubesRate", true);
				return _vor_tyre_tubes_rate;
			}
			set
			{
                CanWriteProperty("VorTyreTubesRate", true);
				if ( _vor_tyre_tubes_rate != value )
				{
					_vor_tyre_tubes_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorVehicalAllowanceRate
		{
			get
			{
                CanReadProperty("VorVehicalAllowanceRate", true);
				return _vor_vehical_allowance_rate;
			}
			set
			{
                CanWriteProperty("VorVehicalAllowanceRate", true);
				if ( _vor_vehical_allowance_rate != value )
				{
					_vor_vehical_allowance_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorLicenceRate
		{
			get
			{
                CanReadProperty("VorLicenceRate", true);
				return _vor_licence_rate;
			}
			set
			{
                CanWriteProperty("VorLicenceRate", true);
				if ( _vor_licence_rate != value )
				{
					_vor_licence_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorVehicleRateOfReturnPct
		{
			get
			{
                CanReadProperty("VorVehicleRateOfReturnPct", true);
				return _vor_vehicle_rate_of_return_pct;
			}
			set
			{
                CanWriteProperty("VorVehicleRateOfReturnPct", true);
				if ( _vor_vehicle_rate_of_return_pct != value )
				{
					_vor_vehicle_rate_of_return_pct = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorSalvageRatio
		{
			get
			{
                CanReadProperty("VorSalvageRatio", true);
				return _vor_salvage_ratio;
			}
			set
			{
                CanWriteProperty("VorSalvageRatio", true);
				if ( _vor_salvage_ratio != value )
				{
					_vor_salvage_ratio = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorRuc
		{
			get
			{
                CanReadProperty("VorRuc", true);
				return _vor_ruc;
			}
			set
			{
                CanWriteProperty("VorRuc", true);
				if ( _vor_ruc != value )
				{
					_vor_ruc = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorSundriesK
		{
			get
			{
                CanReadProperty("VorSundriesK", true);
				return _vor_sundries_k;
			}
			set
			{
                CanWriteProperty("VorSundriesK", true);
				if ( _vor_sundries_k != value )
				{
					_vor_sundries_k = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorVehicleInsurancePremium
		{
			get
			{
                CanReadProperty("VorVehicleInsurancePremium", true);
				return _vor_vehicle_insurance_premium;
			}
			set
			{
                CanWriteProperty("VorVehicleInsurancePremium", true);
				if ( _vor_vehicle_insurance_premium != value )
				{
					_vor_vehicle_insurance_premium = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorFuelRate
		{
			get
			{
                CanReadProperty("VorFuelRate", true);
				return _vor_fuel_rate;
			}
			set
			{
                CanWriteProperty("VorFuelRate", true);
				if ( _vor_fuel_rate != value )
				{
					_vor_fuel_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorConsumptionRate
		{
			get
			{
                CanReadProperty("VorConsumptionRate", true);
				return _vor_consumption_rate;
			}
			set
			{
                CanWriteProperty("VorConsumptionRate", true);
				if ( _vor_consumption_rate != value )
				{
					_vor_consumption_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? VorLivery
		{
			get
			{
                CanReadProperty("VorLivery", true);
				return _vor_livery;
			}
			set
			{
                CanWriteProperty("VorLivery", true);
				if ( _vor_livery != value )
				{
					_vor_livery = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? VorEffectiveDate
		{
			get
			{
                CanReadProperty("VorEffectiveDate", true);
				return _vor_effective_date;
			}
			set
			{
                CanWriteProperty("VorEffectiveDate", true);
				if ( _vor_effective_date != value )
				{
					_vor_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _contract_no,_contract_seq_number,_vor_effective_date );
		}
		#endregion

		#region Factory Methods
		public static VehicleOverrideRate NewVehicleOverrideRate( int? contract, int? sequence )
		{
			return Create(contract, sequence);
		}

		public static VehicleOverrideRate[] GetAllVehicleOverrideRate( int? contract, int? sequence )
		{
			return Fetch(contract, sequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract, int? sequence )
		{
            // TJB  RPCR_099  Dec 2015
            // Modified select statement: Added ORDER BY clause
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contract", contract);
					pList.Add(cm, "sequence", sequence);
					cm.CommandText="  SELECT vehicle_override_rate.contract_no, "+
                        "vehicle_override_rate.contract_seq_number,"+   
                        "vehicle_override_rate.vor_nominal_vehicle_value,"+   
                        "vehicle_override_rate.vor_repairs_maintenance_rate,"+   
                        "vehicle_override_rate.vor_tyre_tubes_rate,"+   
                        "vehicle_override_rate.vor_vehical_allowance_rate,"+   
                        "vehicle_override_rate.vor_licence_rate,"+   
                        "vehicle_override_rate.vor_vehicle_rate_of_return_pct,"+   
                        "vehicle_override_rate.vor_salvage_ratio,"+   
                        "vehicle_override_rate.vor_ruc,"+   
                        "vehicle_override_rate.vor_sundries_k,"+   
                        "vehicle_override_rate.vor_vehicle_insurance_premium,"+   
                        "vehicle_override_rate.vor_fuel_rate,"+   
                        "vehicle_override_rate.vor_consumption_rate,"+   
                        "vehicle_override_rate.vor_livery,"+   
                        "vehicle_override_rate.vor_effective_date "+
                        "  FROM vehicle_override_rate "+
                        " WHERE vehicle_override_rate.contract_no = @contract "+
                        "   AND vehicle_override_rate.contract_seq_number = @sequence"+
                        " ORDER BY vehicle_override_rate.vor_effective_date";

					List<VehicleOverrideRate> _list = new List<VehicleOverrideRate>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehicleOverrideRate instance = new VehicleOverrideRate();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,1);
                            instance._vor_nominal_vehicle_value = GetValueFromReader<decimal?>(dr,2);
                            instance._vor_repairs_maintenance_rate = GetValueFromReader<decimal?>(dr,3);
                            instance._vor_tyre_tubes_rate = GetValueFromReader<decimal?>(dr,4);
                            instance._vor_vehical_allowance_rate = GetValueFromReader<decimal?>(dr,5);
                            instance._vor_licence_rate = GetValueFromReader<decimal?>(dr,6);
                            instance._vor_vehicle_rate_of_return_pct = GetValueFromReader<decimal?>(dr,7);
                            instance._vor_salvage_ratio = GetValueFromReader<decimal?>(dr,8);
                            instance._vor_ruc = GetValueFromReader<decimal?>(dr,9);
                            instance._vor_sundries_k = GetValueFromReader<decimal?>(dr,10);
                            instance._vor_vehicle_insurance_premium = GetValueFromReader<decimal?>(dr,11);
                            instance._vor_fuel_rate = GetValueFromReader<decimal?>(dr,12);
                            instance._vor_consumption_rate = GetValueFromReader<decimal?>(dr,13);
                            instance._vor_livery = GetValueFromReader<decimal?>(dr,14);
                            instance._vor_effective_date = GetValueFromReader<DateTime?>(dr,15);
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
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
				ParameterCollection pList = new ParameterCollection();

				if (GenerateUpdateCommandText(cm, "vehicle_override_rate", ref pList))
				{
					cm.CommandText += " WHERE  vehicle_override_rate.contract_no = @contract_no " +
                                      "   AND vehicle_override_rate.contract_seq_number = @contract_seq_number " +
                                      "   AND vehicle_override_rate.vor_effective_date = @vor_effective_date ";

					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "contract_seq_number", GetInitialValue("_contract_seq_number"));
					pList.Add(cm, "vor_effective_date", GetInitialValue("_vor_effective_date"));

					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "vehicle_override_rate", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
			using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;

                    ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm,"contract_seq_number", GetInitialValue("_contract_seq_number"));
					pList.Add(cm,"vor_effective_date", GetInitialValue("_vor_effective_date"));

                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "DELETE FROM vehicle_override_rate " 
                                    + "WHERE vehicle_override_rate.contract_no = @contract_no "
                                    + "  AND vehicle_override_rate.contract_seq_number = @contract_seq_number "
                                    + "  AND vehicle_override_rate.vor_effective_date = @vor_effective_date ";
					
                    DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract_no, int? contract_seq_number, DateTime? vor_effective_date )
		{
			_contract_no = contract_no;
			_contract_seq_number = contract_seq_number;
			_vor_effective_date = vor_effective_date;
		}
	}
}
