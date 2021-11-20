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
	[MapInfo("detailtype", "_detailtype", "")]
	[MapInfo("datagroup", "_datagroup", "")]
	[MapInfo("sortorder", "_sortorder", "")]
	[MapInfo("monthact", "_monthact", "")]
	[MapInfo("monthbud", "_monthbud", "")]
	[MapInfo("description", "_description", "")]
	[MapInfo("ytdact", "_ytdact", "")]
	[MapInfo("ytdbud", "_ytdbud", "")]
	[System.Serializable()]

	public class PerformanceSummary : Entity<PerformanceSummary>
	{
		#region Business Methods
		[DBField()]
		private string  _detailtype;

		[DBField()]
		private string  _datagroup;

		[DBField()]
		private int?  _sortorder;

		[DBField()]
		private int?  _monthact;

		[DBField()]
		private int?  _monthbud;

		[DBField()]
		private string  _description;

		[DBField()]
		private int?  _ytdact;

		[DBField()]
		private int?  _ytdbud;


		public virtual string Detailtype
		{
			get
			{
                CanReadProperty("Detailtype", true);
				return _detailtype;
			}
			set
			{
                CanWriteProperty("Detailtype", true);
				if ( _detailtype != value )
				{
					_detailtype = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Datagroup
		{
			get
			{
                CanReadProperty("Datagroup", true);
				return _datagroup;
			}
			set
			{
                CanWriteProperty("Datagroup", true);
				if ( _datagroup != value )
				{
					_datagroup = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Sortorder
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

		public virtual int? Monthact
		{
			get
			{
                CanReadProperty("Monthact", true);
				return _monthact;
			}
			set
			{
                CanWriteProperty("Monthact", true);
				if ( _monthact != value )
				{
					_monthact = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Monthbud
		{
			get
			{
                CanReadProperty("Monthbud", true);
				return _monthbud;
			}
			set
			{
                CanWriteProperty("Monthbud", true);
				if ( _monthbud != value )
				{
					_monthbud = value;
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

		public virtual int? Ytdact
		{
			get
			{
                CanReadProperty("Ytdact", true);
				return _ytdact;
			}
			set
			{
                CanWriteProperty("Ytdact", true);
				if ( _ytdact != value )
				{
					_ytdact = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Ytdbud
		{
			get
			{
                CanReadProperty("Ytdbud", true);
				return _ytdbud;
			}
			set
			{
                CanWriteProperty("Ytdbud", true);
				if ( _ytdbud != value )
				{
					_ytdbud = value;
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
		public static PerformanceSummary NewPerformanceSummary( int? inRegion, DateTime? inMonth )
		{
			return Create(inRegion, inMonth);
		}

		public static PerformanceSummary[] GetAllPerformanceSummary( int? inRegion, DateTime? inMonth )
		{
			return Fetch(inRegion, inMonth).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegion, DateTime? inMonth )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_GetPerformanceSummary";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegion", inRegion);
					pList.Add(cm, "inMonth", inMonth);

					List<PerformanceSummary> _list = new List<PerformanceSummary>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PerformanceSummary instance = new PerformanceSummary();
                            instance._detailtype = GetValueFromReader<string>(dr,0);
                            instance._datagroup = GetValueFromReader<string>(dr,1);
                            instance._sortorder = GetValueFromReader<int?>(dr,2);
                            instance._monthact = GetValueFromReader<int?>(dr,3);
                            instance._monthbud = GetValueFromReader<int?>(dr,4);
                            instance._description = GetValueFromReader<string>(dr,5);
                            instance._ytdact = GetValueFromReader<int?>(dr,6);
                            instance._ytdbud = GetValueFromReader<int?>(dr,7);
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
