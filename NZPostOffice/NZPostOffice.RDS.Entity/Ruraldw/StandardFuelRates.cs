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
	[MapInfo("ft_key", "_ft_key", "fuel_rates")]
	[MapInfo("rg_code", "_rg_code", "fuel_rates")]
	[MapInfo("rr_rates_effective_date", "_rr_rates_effective_date", "fuel_rates")]
	[MapInfo("fr_fuel_rate", "_fr_fuel_rate", "fuel_rates")]
	[MapInfo("fr_fuel_consumtion_rate", "_fr_fuel_consumtion_rate", "fuel_rates")]
	[System.Serializable()]

	public class StandardFuelRates : Entity<StandardFuelRates>
	{
		#region Business Methods
		[DBField()]
		private int?  _ft_key;

		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private DateTime?  _rr_rates_effective_date;

		[DBField()]
		private decimal?  _fr_fuel_rate;

		[DBField()]
		private decimal?  _fr_fuel_consumtion_rate;


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

		public virtual decimal? FrFuelRate
		{
			get
			{
                CanReadProperty("FrFuelRate", true);
				return _fr_fuel_rate;
			}
			set
			{
                CanWriteProperty("FrFuelRate", true);
				if ( _fr_fuel_rate != value )
				{
					_fr_fuel_rate = value;
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

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _ft_key,_rg_code,_rr_rates_effective_date );
		}
		#endregion

		#region Factory Methods
		public static StandardFuelRates NewStandardFuelRates(  )
		{
			return Create();
		}

		public static StandardFuelRates[] GetAllStandardFuelRates(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = @"SELECT fuel_rates.ft_key,   
                                             fuel_rates.rg_code,   
                                             fuel_rates.rr_rates_effective_date,   
                                             fuel_rates.fr_fuel_rate,   
                                             fuel_rates.fr_fuel_consumtion_rate  
                                        FROM fuel_rates ";

					List<StandardFuelRates> _list = new List<StandardFuelRates>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							StandardFuelRates instance = new StandardFuelRates();
                            instance._ft_key = GetValueFromReader<Int32?>(dr,0);
                            instance._rg_code = GetValueFromReader<Int32?>(dr,1);
                            instance._rr_rates_effective_date = GetValueFromReader<DateTime?>(dr,2);
                            instance._fr_fuel_rate = GetValueFromReader<Decimal?>(dr,3);
                            instance._fr_fuel_consumtion_rate = GetValueFromReader<Decimal?>(dr,4);

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
				if (GenerateUpdateCommandText(cm, "fuel_rates", ref pList))
				{
					cm.CommandText += " WHERE  fuel_rates.ft_key = @ft_key AND " + 
						"fuel_rates.rg_code = @rg_code AND " + 
						"fuel_rates.rr_rates_effective_date = @rr_rates_effective_date ";

					pList.Add(cm, "ft_key", GetInitialValue("_ft_key"));
					pList.Add(cm, "rg_code", GetInitialValue("_rg_code"));
					pList.Add(cm, "rr_rates_effective_date", GetInitialValue("_rr_rates_effective_date"));
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
				if (GenerateInsertCommandText(cm, "fuel_rates", pList))
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
					cm.CommandType = CommandType.Text;
						ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"ft_key", GetInitialValue("_ft_key"));
					pList.Add(cm,"rg_code", GetInitialValue("_rg_code"));
					pList.Add(cm,"rr_rates_effective_date", GetInitialValue("_rr_rates_effective_date"));
						cm.CommandText = "DELETE FROM fuel_rates WHERE " +
						"fuel_rates.ft_key = @ft_key AND " + 
						"fuel_rates.rg_code = @rg_code AND " + 
						"fuel_rates.rr_rates_effective_date = @rr_rates_effective_date ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? ft_key, int? rg_code, DateTime? rr_rates_effective_date )
		{
			_ft_key = ft_key;
			_rg_code = rg_code;
			_rr_rates_effective_date = rr_rates_effective_date;
		}
	}
}
