using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin2
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("fd_effective_date", "_fd_effective_date", "frequency_distances")]
	[MapInfo("contract_no", "_contract_no", "frequency_distances")]
	[MapInfo("sf_key", "_sf_key", "frequency_distances")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "frequency_distances")]
	[MapInfo("fd_distance", "_fd_distance", "frequency_distances")]
	[MapInfo("fd_no_of_boxes", "_fd_no_of_boxes", "frequency_distances")]
	[MapInfo("fd_no_rural_bags", "_fd_no_rural_bags", "frequency_distances")]
	[MapInfo("fd_no_other_bags", "_fd_no_other_bags", "frequency_distances")]
	[MapInfo("fd_no_private_bags", "_fd_no_private_bags", "frequency_distances")]
	[MapInfo("fd_no_post_offices", "_fd_no_post_offices", "frequency_distances")]
	[MapInfo("fd_no_cmbs", "_fd_no_cmbs", "frequency_distances")]
	[MapInfo("fd_no_cmb_customers", "_fd_no_cmb_customers", "frequency_distances")]
	[MapInfo("fd_change_reason", "_fd_change_reason", "frequency_distances")]
	[MapInfo("fd_delivery_hrs_per_week", "_fd_delivery_hrs_per_week", "frequency_distances")]
	[MapInfo("fd_processing_hrs_week", "_fd_processing_hrs_week", "frequency_distances")]
	[MapInfo("fd_volume", "_fd_volume", "frequency_distances")]
	[System.Serializable()]

	public class FrequencyDistances : Entity<FrequencyDistances>
	{
		#region Business Methods
		[DBField()]
		private DateTime?  _fd_effective_date;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private decimal?  _fd_distance;

		[DBField()]
		private int?  _fd_no_of_boxes;

		[DBField()]
		private int?  _fd_no_rural_bags;

		[DBField()]
		private int?  _fd_no_other_bags;

		[DBField()]
		private int?  _fd_no_private_bags;

		[DBField()]
		private int?  _fd_no_post_offices;

		[DBField()]
		private int?  _fd_no_cmbs;

		[DBField()]
		private int?  _fd_no_cmb_customers;

		[DBField()]
		private string  _fd_change_reason;

		[DBField()]
		private decimal?  _fd_delivery_hrs_per_week;

		[DBField()]
		private decimal?  _fd_processing_hrs_week;

		[DBField()]
		private decimal?  _fd_volume;


		public virtual DateTime? FdEffectiveDate
		{
			get
			{
                CanReadProperty("FdEffectiveDate", true);
				return _fd_effective_date;
			}
			set
			{
                CanWriteProperty("FdEffectiveDate", true);
				if ( _fd_effective_date != value )
				{
					_fd_effective_date = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual int? SfKey
		{
			get
			{
                CanReadProperty("SfKey", true);
				return _sf_key;
			}
			set
			{
                CanWriteProperty("SfKey", true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfDeliveryDays
		{
			get
			{
                CanReadProperty("RfDeliveryDays", true);
				return _rf_delivery_days;
			}
			set
			{
                CanWriteProperty("RfDeliveryDays", true);
				if ( _rf_delivery_days != value )
				{
					_rf_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FdDistance
		{
			get
			{
                CanReadProperty("FdDistance", true);
				return _fd_distance;
			}
			set
			{
                CanWriteProperty("FdDistance", true);
				if ( _fd_distance != value )
				{
					_fd_distance = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdNoOfBoxes
		{
			get
			{
                CanReadProperty("FdNoOfBoxes", true);
				return _fd_no_of_boxes;
			}
			set
			{
                CanWriteProperty("FdNoOfBoxes", true);
				if ( _fd_no_of_boxes != value )
				{
					_fd_no_of_boxes = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdNoRuralBags
		{
			get
			{
                CanReadProperty("FdNoRuralBags", true);
				return _fd_no_rural_bags;
			}
			set
			{
                CanWriteProperty("FdNoRuralBags", true);
				if ( _fd_no_rural_bags != value )
				{
					_fd_no_rural_bags = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdNoOtherBags
		{
			get
			{
                CanReadProperty("FdNoOtherBags", true);
				return _fd_no_other_bags;
			}
			set
			{
                CanWriteProperty("FdNoOtherBags", true);
				if ( _fd_no_other_bags != value )
				{
					_fd_no_other_bags = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdNoPrivateBags
		{
			get
			{
                CanReadProperty("FdNoPrivateBags", true);
				return _fd_no_private_bags;
			}
			set
			{
                CanWriteProperty("FdNoPrivateBags", true);
				if ( _fd_no_private_bags != value )
				{
					_fd_no_private_bags = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdNoPostOffices
		{
			get
			{
                CanReadProperty("FdNoPostOffices", true);
				return _fd_no_post_offices;
			}
			set
			{
                CanWriteProperty("FdNoPostOffices", true);
				if ( _fd_no_post_offices != value )
				{
					_fd_no_post_offices = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdNoCmbs
		{
			get
			{
                CanReadProperty("FdNoCmbs", true);
				return _fd_no_cmbs;
			}
			set
			{
                CanWriteProperty("FdNoCmbs", true);
				if ( _fd_no_cmbs != value )
				{
					_fd_no_cmbs = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? FdNoCmbCustomers
		{
			get
			{
                CanReadProperty("FdNoCmbCustomers", true);
				return _fd_no_cmb_customers;
			}
			set
			{
                CanWriteProperty("FdNoCmbCustomers", true);
				if ( _fd_no_cmb_customers != value )
				{
					_fd_no_cmb_customers = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FdChangeReason
		{
			get
			{
                CanReadProperty("FdChangeReason", true);
				return _fd_change_reason;
			}
			set
			{
                CanWriteProperty("FdChangeReason", true);
				if ( _fd_change_reason != value )
				{
					_fd_change_reason = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FdDeliveryHrsPerWeek
		{
			get
			{
                CanReadProperty("FdDeliveryHrsPerWeek", true);
				return _fd_delivery_hrs_per_week;
			}
			set
			{
                CanWriteProperty("FdDeliveryHrsPerWeek", true);
				if ( _fd_delivery_hrs_per_week != value )
				{
					_fd_delivery_hrs_per_week = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FdProcessingHrsWeek
		{
			get
			{
                CanReadProperty("FdProcessingHrsWeek", true);
				return _fd_processing_hrs_week;
			}
			set
			{
                CanWriteProperty("FdProcessingHrsWeek", true);
				if ( _fd_processing_hrs_week != value )
				{
					_fd_processing_hrs_week = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? FdVolume
		{
			get
			{
                CanReadProperty("FdVolume", true);
				return _fd_volume;
			}
			set
			{
                CanWriteProperty("FdVolume", true);
				if ( _fd_volume != value )
				{
					_fd_volume = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}/{3}", _fd_effective_date,_contract_no,_sf_key,_rf_delivery_days );
		}
		#endregion

		#region Factory Methods
		public static FrequencyDistances NewFrequencyDistances( int? al_contractNo, DateTime? ad_renewal_start )
		{
			return Create(al_contractNo, ad_renewal_start);
		}

		public static FrequencyDistances[] GetAllFrequencyDistances( int? al_contractNo, DateTime? ad_renewal_start )
		{
			return Fetch(al_contractNo, ad_renewal_start).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_contractNo, DateTime? ad_renewal_start )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_contractNo", al_contractNo);
					pList.Add(cm, "ad_renewal_start", ad_renewal_start);
					cm.CommandText=" SELECT frequency_distances.fd_effective_date,frequency_distances.contract_no,"+
                        "frequency_distances.sf_key,frequency_distances.rf_delivery_days,frequency_distances.fd_distance,"+
                        "frequency_distances.fd_no_of_boxes,frequency_distances.fd_no_rural_bags,frequency_distances.fd_no_other_bags,"+
                        "frequency_distances.fd_no_private_bags,frequency_distances.fd_no_post_offices,frequency_distances.fd_no_cmbs,"+
                        "frequency_distances.fd_no_cmb_customers,frequency_distances.fd_change_reason,frequency_distances.fd_delivery_hrs_per_week,"+
                        "frequency_distances.fd_processing_hrs_week,frequency_distances.fd_volume "+
                        " FROM frequency_distances  "+
                        " WHERE (frequency_distances.contract_no = @al_contractNo ) AND "+
                        "(frequency_distances.fd_effective_date >= @ad_renewal_start )";

					List<FrequencyDistances> _list = new List<FrequencyDistances>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							FrequencyDistances instance = new FrequencyDistances();
                            instance._fd_effective_date = GetValueFromReader<DateTime?>(dr,0);
                            instance._contract_no = GetValueFromReader<int?>(dr,1);
                            instance._sf_key = GetValueFromReader<int?>(dr,2);
                            instance._rf_delivery_days = GetValueFromReader<string>(dr,3);
                            instance._fd_distance = GetValueFromReader<decimal?>(dr,4);
                            instance._fd_no_of_boxes = GetValueFromReader<int?>(dr,5);
                            instance._fd_no_rural_bags = GetValueFromReader<int?>(dr,6);
                            instance._fd_no_other_bags = GetValueFromReader<int?>(dr,7);
                            instance._fd_no_private_bags = GetValueFromReader<int?>(dr,8);
                            instance._fd_no_post_offices = GetValueFromReader<int?>(dr,9);
                            instance._fd_no_cmbs = GetValueFromReader<int?>(dr,10);
                            instance._fd_no_cmb_customers = GetValueFromReader<int?>(dr,11);
                            instance._fd_change_reason = GetValueFromReader<string>(dr,12);
                            instance._fd_delivery_hrs_per_week = GetValueFromReader<decimal?>(dr,13);
                            instance._fd_processing_hrs_week = GetValueFromReader<decimal?>(dr,14);
                            instance._fd_volume = GetValueFromReader<decimal?>(dr,15);
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
				if (GenerateUpdateCommandText(cm, "frequency_distances", ref pList))
				{
					cm.CommandText += " WHERE  frequency_distances.fd_effective_date = @fd_effective_date AND " + 
						"frequency_distances.contract_no = @contract_no AND " + 
						"frequency_distances.sf_key = @sf_key AND " + 
						"frequency_distances.rf_delivery_days = @rf_delivery_days ";

					pList.Add(cm, "fd_effective_date", GetInitialValue("_fd_effective_date"));
					pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
					pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));
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
				if (GenerateInsertCommandText(cm, "frequency_distances", pList))
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
					pList.Add(cm,"fd_effective_date", GetInitialValue("_fd_effective_date"));
					pList.Add(cm,"contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm,"sf_key", GetInitialValue("_sf_key"));
					pList.Add(cm,"rf_delivery_days", GetInitialValue("_rf_delivery_days"));
						cm.CommandText = "DELETE FROM frequency_distances WHERE " +
						"frequency_distances.fd_effective_date = @fd_effective_date AND " + 
						"frequency_distances.contract_no = @contract_no AND " + 
						"frequency_distances.sf_key = @sf_key AND " + 
						"frequency_distances.rf_delivery_days = @rf_delivery_days ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( DateTime? fd_effective_date, int? contract_no, int? sf_key, string rf_delivery_days )
		{
			_fd_effective_date = fd_effective_date;
			_contract_no = contract_no;
			_sf_key = sf_key;
			_rf_delivery_days = rf_delivery_days;
		}
	}
}
