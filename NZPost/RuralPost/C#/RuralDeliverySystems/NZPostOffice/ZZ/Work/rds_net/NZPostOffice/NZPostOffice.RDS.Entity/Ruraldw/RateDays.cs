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
	[MapInfo("rg_code", "_rate_days_rg_code", "standard_frequency")]
	[MapInfo("rr_rates_effective_date", "_rate_days_rr_rates_effective_date", "standard_frequency")]
	[MapInfo("sf_key", "_rate_days_sf_key", "standard_frequency")]
	[MapInfo("rtd_days_per_annum", "_rate_days_rtd_days_per_annum", "standard_frequency")]
	[MapInfo("sf_description", "_standard_frequency_sf_description", "standard_frequency")]
	[MapInfo("sf_days_week", "_standard_frequency_sf_days_week", "standard_frequency")]
	[System.Serializable()]

	public class RateDays : Entity<RateDays>
	{
		#region Business Methods
		[DBField()]
		private int?  _rate_days_rg_code;

		[DBField()]
		private DateTime?  _rate_days_rr_rates_effective_date;

		[DBField()]
		private int?  _rate_days_sf_key;

		[DBField()]
		private int?  _rate_days_rtd_days_per_annum;

		[DBField()]
		private string  _standard_frequency_sf_description;

		[DBField()]
		private int?  _standard_frequency_sf_days_week;


		public virtual int? RateDaysRgCode
		{
			get
			{
                CanReadProperty("RateDaysRgCode", true);
				return _rate_days_rg_code;
			}
			set
			{
                CanWriteProperty("RateDaysRgCode", true);
				if ( _rate_days_rg_code != value )
				{
					_rate_days_rg_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? RateDaysRrRatesEffectiveDate
		{
			get
			{
                CanReadProperty("RateDaysRrRatesEffectiveDate", true);
				return _rate_days_rr_rates_effective_date;
			}
			set
			{
                CanWriteProperty("RateDaysRrRatesEffectiveDate", true);
				if ( _rate_days_rr_rates_effective_date != value )
				{
					_rate_days_rr_rates_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RateDaysSfKey
		{
			get
			{
                CanReadProperty("RateDaysSfKey", true);
				return _rate_days_sf_key;
			}
			set
			{
                CanWriteProperty("RateDaysSfKey", true);
				if ( _rate_days_sf_key != value )
				{
					_rate_days_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RateDaysRtdDaysPerAnnum
		{
			get
			{
                CanReadProperty("RateDaysRtdDaysPerAnnum", true);
				return _rate_days_rtd_days_per_annum;
			}
			set
			{
                CanWriteProperty("RateDaysRtdDaysPerAnnum", true);
				if ( _rate_days_rtd_days_per_annum != value )
				{
					_rate_days_rtd_days_per_annum = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string StandardFrequencySfDescription
		{
			get
			{
                CanReadProperty("StandardFrequencySfDescription", true);
				return _standard_frequency_sf_description;
			}
			set
			{
                CanWriteProperty("StandardFrequencySfDescription", true);
				if ( _standard_frequency_sf_description != value )
				{
					_standard_frequency_sf_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? StandardFrequencySfDaysWeek
		{
			get
			{
                CanReadProperty("StandardFrequencySfDaysWeek", true);
				return _standard_frequency_sf_days_week;
			}
			set
			{
                CanWriteProperty("StandardFrequencySfDaysWeek", true);
				if ( _standard_frequency_sf_days_week != value )
				{
					_standard_frequency_sf_days_week = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}", _rate_days_rg_code,_rate_days_sf_key );
		}
		#endregion

		#region Factory Methods
		public static RateDays NewRateDays( DateTime? effectivedate )
		{
			return Create(effectivedate);
		}

		public static RateDays[] GetAllRateDays( DateTime? effectivedate )
		{
			return Fetch(effectivedate).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( DateTime? effectivedate )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rate_days.rg_code, rate_days.rr_rates_effective_date,standard_frequency.sf_key, rate_days.rtd_days_per_annum, standard_frequency.sf_description, standard_frequency.sf_days_week FROM standard_frequency left outer join rate_days on standard_frequency.sf_key = rate_days.sf_key and rate_days.rr_rates_effective_date = @effectivedate";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "effectivedate", effectivedate);

					List<RateDays> _list = new List<RateDays>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RateDays instance = new RateDays();
                            instance._rate_days_rg_code = GetValueFromReader<Int32?>(dr,0);
                            instance._rate_days_rr_rates_effective_date = GetValueFromReader<DateTime?>(dr,1);
                            instance._rate_days_sf_key = GetValueFromReader<Int32?>(dr,2);
                            instance._rate_days_rtd_days_per_annum = GetValueFromReader<Int32?>(dr,3);
                            instance._standard_frequency_sf_description = GetValueFromReader<String>(dr,4);
                            instance._standard_frequency_sf_days_week = GetValueFromReader<Int32?>(dr,5);

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
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "rate_days", pList))
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
					pList.Add(cm,"rg_code", GetInitialValue("_rate_days_rg_code"));
					pList.Add(cm,"sf_key", GetInitialValue("_rate_days_sf_key"));
						cm.CommandText = "DELETE FROM rate_days WHERE " +
						"rate_days.rg_code = @rg_code AND " + 
						"rate_days.sf_key = @sf_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rate_days_rg_code, int? rate_days_sf_key )
		{
			_rate_days_rg_code = rate_days_rg_code;
			_rate_days_sf_key = rate_days_sf_key;
		}
	}
}
