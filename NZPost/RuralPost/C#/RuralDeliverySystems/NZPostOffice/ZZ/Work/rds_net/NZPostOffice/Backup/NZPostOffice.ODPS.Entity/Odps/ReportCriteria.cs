using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("sdate", "_sdate", "")]
	[MapInfo("edate", "_edate", "")]
	[MapInfo("fsdate", "_fsdate", "")]
	[MapInfo("fedate", "_fedate", "")]
	[MapInfo("region_id", "_region_id", "")]
	[System.Serializable()]

	public class ReportCriteria : Entity<ReportCriteria>
	{
		#region Business Methods
		[DBField()]
		private DateTime?  _sdate;

		[DBField()]
		private DateTime?  _edate;

		[DBField()]
		private DateTime?  _fsdate;

		[DBField()]
		private DateTime?  _fedate;

		[DBField()]
		private int?  _region_id;

		public virtual DateTime? Sdate
		{
			get
			{
				CanReadProperty("Sdate",true);
				return _sdate;
			}
			set
			{
                CanWriteProperty("Sdate", true);
				if ( _sdate != value )
				{
					_sdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Edate
		{
			get
			{
				CanReadProperty("Edate",true);
				return _edate;
			}
			set
			{
				CanWriteProperty("Edate",true);
				if ( _edate != value )
				{
					_edate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Fsdate
		{
			get
			{
				CanReadProperty("Fsdate",true);
				return _fsdate;
			}
			set
			{
				CanWriteProperty("Fsdate",true);
				if ( _fsdate != value )
				{
					_fsdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Fedate
		{
			get
			{
				CanReadProperty("Fedate",true);
				return _fedate;
			}
			set
			{
                CanWriteProperty("Fedate", true);
				if ( _fedate != value )
				{
					_fedate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RegionId
		{
			get
			{
				CanReadProperty("RegionId",true);
				return _region_id;
			}
			set
			{
				CanWriteProperty("RegionId",true);
				if ( _region_id != value )
				{
					_region_id = value;
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
		public static ReportCriteria NewReportCriteria(  )
		{
			return Create();
		}

		public static ReportCriteria[] GetAllReportCriteria(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();

					List<ReportCriteria> _list = new List<ReportCriteria>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ReportCriteria instance = new ReportCriteria();
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
