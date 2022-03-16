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
	[MapInfo("ft_key", "_ft_key", "fuel_type")]
	[MapInfo("rg_code", "_rg_code", "fuel_rates")]
	[MapInfo("rr_rates_effective_date", "_rr_rates_effective_date", "fuel_rates")]
	[MapInfo("fr_fuel_rate", "_fuel_rate", "fuel_rates")]
	[MapInfo("fr_fuel_consumtion_rate", "_fr_fuel_consumtion_rate", "fuel_rates")]
	[MapInfo("ft_description", "_description", "fuel_type")]
	[System.Serializable()]

	public class NationalFuelOverride : Entity<NationalFuelOverride>
	{
		#region Business Methods
		[DBField()]
		private int?  _ft_key;

		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private DateTime?  _rr_rates_effective_date;

		[DBField()]
		private decimal?  _fuel_rate;

		[DBField()]
		private decimal?  _fr_fuel_consumtion_rate;

		[DBField()]
		private string  _description;


		public virtual int? FtKey
		{
			get
			{
                CanReadProperty("FtKey", true);
				return _ft_key;
			}
			set
			{
                CanWriteProperty("FtKey", true);
				if ( _ft_key != value )
				{
					_ft_key = value;
					PropertyHasChanged();
				}
			}
		}

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
				if ( _rg_code != value )
				{
					_rg_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RrRatesEffectiveDate
		{
			get
			{
                CanReadProperty("RrRatesEffectiveDate", true);
				return _rr_rates_effective_date;
			}
			set
			{
                CanWriteProperty("RrRatesEffectiveDate", true);
				if ( _rr_rates_effective_date != value )
				{
					_rr_rates_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FuelRate
		{
			get
			{
                CanReadProperty("FuelRate", true);
				return _fuel_rate;
			}
			set
			{
                CanWriteProperty("FuelRate", true);
				if ( _fuel_rate != value )
				{
					_fuel_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FrFuelConsumtionRate
		{
			get
			{
                CanReadProperty("FrFuelConsumtionRate", true);
				return _fr_fuel_consumtion_rate;
			}
			set
			{
                CanWriteProperty("FrFuelConsumtionRate", true);
				if ( _fr_fuel_consumtion_rate != value )
				{
					_fr_fuel_consumtion_rate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Description
		{
			get
			{
                CanReadProperty("Description", true);
				return _description;
			}
			set
			{
                CanWriteProperty("Description", true);
				if ( _description != value )
				{
					_description = value;
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
		public static NationalFuelOverride NewNationalFuelOverride( int? al_region_id )
		{
			return Create(al_region_id);
		}

		public static NationalFuelOverride[] GetAllNationalFuelOverride( int? al_region_id )
		{
			return Fetch(al_region_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_region_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT"
                                + " fuel_type.ft_key,"
                                + " fr1.rg_code,"
                                + " fr1.rr_rates_effective_date,"
                                + " fr1.fr_fuel_rate,"
                                + " fr1.fr_fuel_consumtion_rate,"
                                + " fuel_type.ft_description"
                                + " FROM"
                                + " fuel_type left outer join fuel_rates fr1"
                                + " on fuel_type.ft_key = fr1.ft_key"
                                + " WHERE fr1.rg_code = @al_region_id"
                                + " AND	fr1.rr_rates_effective_Date ="
                                + " (select max(fr2.rr_rates_effective_date)"
                                + " from fuel_rates	fr2"
                                + " where fr2.rg_code = fr1.rg_code)"
                                + " "
                                + " UNION"
                                + " "
                                + " SELECT"
                                + " ft_key,"
                                + " @al_region_id,"
                                + " getdate(),"
                                + " 0,"
                                + " 0,"
                                + " ft_description"
                                + " FROM fuel_type"
                                + " WHERE @al_region_id = 0"
                                + " AND ft_description <> ''";

					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_region_id", al_region_id);

					List<NationalFuelOverride> _list = new List<NationalFuelOverride>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							NationalFuelOverride instance = new NationalFuelOverride();
                            instance._ft_key = GetValueFromReader<Int32?>(dr,0);
                            instance._rg_code = GetValueFromReader<Int32?>(dr,1);
                            instance._rr_rates_effective_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._fuel_rate = GetValueFromReader<Decimal?>(dr,3);
                            instance._fr_fuel_consumtion_rate = GetValueFromReader<Decimal?>(dr,4);
                            instance._description = GetValueFromReader<String>(dr,5);
                           
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
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
