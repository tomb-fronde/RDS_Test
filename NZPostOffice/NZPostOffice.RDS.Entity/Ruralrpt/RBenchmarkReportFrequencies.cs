using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("sf_description", "_standard_frequency_sf_description", "standard_frequency")]
	[MapInfo("rf_delivery_days", "_route_frequency_rf_delivery_days", "route_frequency")]
	[MapInfo("rf_distance", "_route_frequency_rf_distance", "route_frequency")]
	[System.Serializable()]

	public class BenchmarkReportFrequencies : Entity<BenchmarkReportFrequencies>
	{
		#region Business Methods
		[DBField()]
		private string  _standard_frequency_sf_description;

		[DBField()]
		private string  _route_frequency_rf_delivery_days;

		[DBField()]
		private decimal?  _route_frequency_rf_distance;


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

		public virtual string RouteFrequencyRfDeliveryDays
		{
			get
			{
                CanReadProperty("RouteFrequencyRfDeliveryDays", true);
				return _route_frequency_rf_delivery_days;
			}
			set
			{
                CanWriteProperty("RouteFrequencyRfDeliveryDays", true);
				if ( _route_frequency_rf_delivery_days != value )
				{
					_route_frequency_rf_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RouteFrequencyRfDistance
		{
			get
			{
                CanReadProperty("RouteFrequencyRfDistance", true);
				return _route_frequency_rf_distance;
			}
			set
			{
                CanWriteProperty("RouteFrequencyRfDistance", true);
				if ( _route_frequency_rf_distance != value )
				{
					_route_frequency_rf_distance = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_1]
		/*?	MID( route_frequency_rf_delivery_days,1,1)

			// needs to implement compute expression manually:
			// compute control name=[compute_2]
			MID( route_frequency_rf_delivery_days,2,1)

			// needs to implement compute expression manually:
			// compute control name=[compute_3]
			MID( route_frequency_rf_delivery_days,3,1)

			// needs to implement compute expression manually:
			// compute control name=[compute_4]
			MID( route_frequency_rf_delivery_days,4,1)

			// needs to implement compute expression manually:
			// compute control name=[compute_5]
			MID( route_frequency_rf_delivery_days,5,1)

			// needs to implement compute expression manually:
			// compute control name=[compute_6]
			MID( route_frequency_rf_delivery_days,6,1)

			// needs to implement compute expression manually:
			// compute control name=[compute_7]
			MID( route_frequency_rf_delivery_days,7,1)*/


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static BenchmarkReportFrequencies NewBenchmarkReportFrequencies( int? contract_no )
		{
			return Create(contract_no);
		}

		public static BenchmarkReportFrequencies[] GetAllBenchmarkReportFrequencies( int? contract_no )
		{
			return Fetch(contract_no).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract_no )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = 
                        " SELECT standard_frequency.sf_description ,"
                        + "      route_frequency.rf_delivery_days ,"
                        + "      route_frequency.rf_distance "
                        + " FROM standard_frequency ,"
                        + "      route_frequency "
                        + "WHERE standard_frequency.sf_key = route_frequency.sf_key " 
                        + "  AND route_frequency.contract_no = :contract_no " 
                        + "  AND route_frequency.rf_active = 'Y' " 
                        + "  AND route_frequency.rf_distance > 0 ";

					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contract_no", contract_no);

					List<BenchmarkReportFrequencies> _list = new List<BenchmarkReportFrequencies>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							BenchmarkReportFrequencies instance = new BenchmarkReportFrequencies();
                            instance._standard_frequency_sf_description = GetValueFromReader<string>(dr,0);
                            instance._route_frequency_rf_delivery_days = GetValueFromReader<string>(dr,1);
                            instance._route_frequency_rf_distance = GetValueFromReader<decimal?>(dr,2);
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
