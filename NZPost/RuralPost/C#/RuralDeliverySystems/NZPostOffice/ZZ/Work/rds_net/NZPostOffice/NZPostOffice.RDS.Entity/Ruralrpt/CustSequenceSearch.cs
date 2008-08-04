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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("frequency", "_frequency", "")]
	[MapInfo("sortorder", "_sortorder", "")]
	[MapInfo("summaryreport", "_summaryreport", "")]
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("delivery_days", "_delivery_days", "")]
	[MapInfo("freq_picklist", "_freq_picklist", "")]
	[MapInfo("region_id", "_region_id_ro", "")]
	[System.Serializable()]

	public class CustSequenceSearch : Entity<CustSequenceSearch>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _frequency ="Y";

		[DBField()]
		private string  _sortorder = "S";

		[DBField()]
        private string _summaryreport = "Y";

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _delivery_days;

		[DBField()]
		private string  _freq_picklist;

		[DBField()]
		private int?  _region_id_ro;


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

		public virtual string Frequency
		{
			get
			{
                CanReadProperty("Frequency", true);
				return _frequency;
			}
			set
			{
                CanWriteProperty("Frequency", true);
				if ( _frequency != value )
				{
					_frequency = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Sortorder
		{
			get
			{
                CanReadProperty("Sortorder", true);
				return _sortorder;
			}
			set
			{
                CanWriteProperty("Sortorder", true);
				if ( _sortorder != value )
				{
					_sortorder = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual bool Sortorder1
        {
            get
            {
                CanReadProperty("Sortorder1", true);
                return _sortorder == "S";
            }
            set
            {
                CanWriteProperty("Sortorder1", true);
                string new_sortorder = value ? "S" : "N";
                if (_sortorder != new_sortorder)
                {
                    _sortorder = new_sortorder;
                    PropertyHasChanged("Sortorder");
                }
            }
        }

        public virtual bool Sortorder2
        {
            get
            {
                CanReadProperty("Sortorder2", true);
                return _sortorder == "N";
            }
            set
            {
                CanWriteProperty("Sortorder2", true);
                string new_sortorder = value ? "S" : "N";
                if (_sortorder != new_sortorder)
                {
                    _sortorder = new_sortorder;
                    PropertyHasChanged("Sortorder");
                }
            }
        }

        public virtual bool? Summaryreport
        {
            get
            {
                CanReadProperty("Summaryreport", true);
                return GetBoolean(_summaryreport, "Y", "N", false);
            }
            set
            {
                CanReadProperty("Summaryreport", true);
                SetFromBoolean(ref _summaryreport, value, "Y", "N");
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

		public virtual string DeliveryDays
		{
			get
			{
                CanReadProperty("DeliveryDays", true);
				return _delivery_days;
			}
			set
			{
                CanWriteProperty("DeliveryDays", true);
				if ( _delivery_days != value )
				{
					_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string FreqPicklist
		{
			get
			{
                CanReadProperty("FreqPicklist", true);
				return _freq_picklist;
			}
			set
			{
                CanWriteProperty("FreqPicklist", true);
				if ( _freq_picklist != value )
				{
					_freq_picklist = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionIdRo
		{
			get
			{
                CanReadProperty("RegionIdRo", true);
				return _region_id_ro;
			}
			set
			{
                CanWriteProperty("RegionIdRo", true);
				if ( _region_id_ro != value )
				{
					_region_id_ro = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual string Compute1
        {
            get
            {
                string str = string.Empty;
                CanReadProperty("Compute1", true);
                if (_delivery_days != null)
                {
                    str = _delivery_days.Substring(0, 1) == "Y" ? "Mon " : "";
                    str += _delivery_days.Substring(1, 1) == "Y" ? "Tue " : "";
                    str += _delivery_days.Substring(2, 1) == "Y" ? "Wed " : "";
                    str += _delivery_days.Substring(3, 1) == "Y" ? "Thu " : "";
                    str += _delivery_days.Substring(4, 1) == "Y" ? "Fri " : "";
                    str += _delivery_days.Substring(5, 1) == "Y" ? "Sat " : "";
                    str += _delivery_days.Substring(6, 1) == "Y" ? "Sun " : "";
                }
                return str;
                //if(mid(delivery_days,1,1)='Y',"Mon ", "") + if(mid(delivery_days,2,1)='Y',"Tue ", "") + if(mid(delivery_days,3,1)='Y',"Wed ", "") + if(mid(delivery_days,4,1)='Y',"Thu ", "") + if(mid(delivery_days,5,1)='Y',"Fri ", "") + if(mid(delivery_days,6,1)='Y',"Sat ", "") + if(mid(delivery_days,7,1)='Y',"Sun ", "")
            }
        }
		protected override object GetIdValue()
		{
			return _contract_no + "";
		}
		#endregion

		#region Factory Methods
		public static CustSequenceSearch NewCustSequenceSearch(  )
		{
			return Create();
		}

		public static CustSequenceSearch[] GetAllCustSequenceSearch(  )
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

					List<CustSequenceSearch> _list = new List<CustSequenceSearch>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustSequenceSearch instance = new CustSequenceSearch();
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
