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
	[MapInfo("rg_code", "_rg_code", "renewal_group")]
	[MapInfo("ct_key", "_ct_key", "renewal_group")]
	[MapInfo("region_id", "_region_id", "renewal_group")]
	[MapInfo("sf_key", "_sf_key", "renewal_group")]
	[MapInfo("outlet_id", "_outlet_id", "renewal_group")]
	[System.Serializable()]

	public class ReportAllowanceCriteria : Entity<ReportAllowanceCriteria>
	{
		#region Business Methods
		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private int?  _region_id;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private int?  _outlet_id;


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

		public virtual int? CtKey
		{
			get
			{
                CanReadProperty("CtKey", true);
				return _ct_key;
			}
			set
			{
                CanWriteProperty("CtKey", true);
				if ( _ct_key != value )
				{
					_ct_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionId
		{
			get
			{
                CanReadProperty("RegionId", true);
				return _region_id;
			}
			set
			{
                CanWriteProperty("RegionId", true);
				if ( _region_id != value )
				{
					_region_id = value;
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

		public virtual int? OutletId
		{
			get
			{
                CanReadProperty("OutletId", true);
				return _outlet_id;
			}
			set
			{
                CanWriteProperty("OutletId", true);
				if ( _outlet_id != value )
				{
					_outlet_id = value;
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
		public static ReportAllowanceCriteria NewReportAllowanceCriteria(  )
		{
			return Create();
		}

		public static ReportAllowanceCriteria[] GetAllReportAllowanceCriteria(  )
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
                    cm.CommandText = " SELECT  0 as rg_code,"
                        + " 0 as ct_key,"
                        + " 1 as region_id,"
                        + " 0 as sf_key,"
                        + " 0 as outlet_id"
                        + " FROM renewal_group";

					ParameterCollection pList = new ParameterCollection();

					List<ReportAllowanceCriteria> _list = new List<ReportAllowanceCriteria>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ReportAllowanceCriteria instance = new ReportAllowanceCriteria();
                            instance._rg_code = GetValueFromReader<int?>(dr,0);
                            instance._ct_key = GetValueFromReader<int?>(dr,1);
                            instance._region_id = GetValueFromReader<int?>(dr,2);
                            instance._sf_key = GetValueFromReader<int?>(dr,3);
                            instance._outlet_id = GetValueFromReader<int?>(dr,4);
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
