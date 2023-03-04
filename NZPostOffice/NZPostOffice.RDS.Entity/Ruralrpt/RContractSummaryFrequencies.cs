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
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("sf_description", "_sf_description", "")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
	[MapInfo("rf_distance", "_rf_distance", "")]
	[MapInfo("fd_effective_date", "_fd_effective_date", "")]
	[MapInfo("fd_distance", "_fd_distance", "")]
	[MapInfo("fd_no_of_boxes", "_fd_no_of_boxes", "")]
	[MapInfo("fd_no_rural_bags", "_fd_no_rural_bags", "")]
	[MapInfo("fd_no_other_bags", "_fd_no_other_bags", "")]
	[MapInfo("fd_no_private_bags", "_fd_no_private_bags", "")]
	[MapInfo("fd_no_post_offices", "_fd_no_post_offices", "")]
	[MapInfo("fd_no_cmbs", "_fd_no_cmbs", "")]
	[MapInfo("fd_no_cmb_customers", "_fd_no_cmb_customers", "")]
	[MapInfo("fd_volume", "_fd_volume", "")]
	[MapInfo("fd_delivery_hrs_per_week", "_fd_delivery_hrs_per_week", "")]
	[MapInfo("fd_processing_hrs_week", "_fd_processing_hrs_week", "")]
	[MapInfo("rtd_days_per_annum", "_rtd_days_per_annum", "")]
	[System.Serializable()]

	public class ContractSummaryFrequencies : Entity<ContractSummaryFrequencies>
	{
		#region Business Methods
		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _sf_description;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private decimal?  _rf_distance;

		[DBField()]
		private DateTime?  _fd_effective_date;

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
		private int?  _fd_volume;

		[DBField()]
		private decimal?  _fd_delivery_hrs_per_week;

		[DBField()]
		private decimal?  _fd_processing_hrs_week;

		[DBField()]
		private int?  _rtd_days_per_annum;


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

		public virtual string SfDescription
		{
			get
			{
                CanReadProperty("SfDescription", true);
				return _sf_description;
			}
			set
			{
                CanWriteProperty("SfDescription", true);
				if ( _sf_description != value )
				{
					_sf_description = value;
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

		public virtual decimal? RfDistance
		{
			get
			{
                CanReadProperty("RfDistance", true);
				return _rf_distance;
			}
			set
			{
                CanWriteProperty("RfDistance", true);
				if ( _rf_distance != value )
				{
					_rf_distance = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual int? FdVolume
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

		public virtual int? RtdDaysPerAnnum
		{
			get
			{
                CanReadProperty("RtdDaysPerAnnum", true);
				return _rtd_days_per_annum;
			}
			set
			{
                CanWriteProperty("RtdDaysPerAnnum", true);
				if ( _rtd_days_per_annum != value )
				{
					_rtd_days_per_annum = value;
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
		public static ContractSummaryFrequencies NewContractSummaryFrequencies( int? inContract, int? inSequence )
		{
			return Create(inContract, inSequence);
		}

		public static ContractSummaryFrequencies[] GetAllContractSummaryFrequencies( int? inContract, int? inSequence )
		{
			return Fetch(inContract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_GetSummaryFrequencies";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);

					List<ContractSummaryFrequencies> _list = new List<ContractSummaryFrequencies>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummaryFrequencies instance = new ContractSummaryFrequencies();
                            instance._sf_key = GetValueFromReader<int?>(dr,0);
                            instance._sf_description = GetValueFromReader<string>(dr,1);
                            instance._rf_delivery_days = GetValueFromReader<string>(dr,2);
                            instance._rf_distance = GetValueFromReader<decimal?>(dr,3);
                            instance._fd_effective_date = GetValueFromReader<DateTime?>(dr,4);
                            instance._fd_distance = GetValueFromReader<decimal?>(dr,5);
                            instance._fd_no_of_boxes = GetValueFromReader<int?>(dr,6);
                            instance._fd_no_rural_bags = GetValueFromReader<int?>(dr,7);
                            instance._fd_no_other_bags = GetValueFromReader<int?>(dr,8);
                            instance._fd_no_private_bags = GetValueFromReader<int?>(dr,9);
                            instance._fd_no_post_offices = GetValueFromReader<int?>(dr,10);
                            instance._fd_no_cmbs = GetValueFromReader<int?>(dr,11);
                            instance._fd_no_cmb_customers = GetValueFromReader<int?>(dr,12);
                            instance._fd_volume = GetValueFromReader<int?>(dr,13);
                            instance._fd_delivery_hrs_per_week = GetValueFromReader<decimal?>(dr,14);
                            instance._fd_processing_hrs_week = GetValueFromReader<decimal?>(dr,15);
                            instance._rtd_days_per_annum = GetValueFromReader<int?>(dr,16);
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
