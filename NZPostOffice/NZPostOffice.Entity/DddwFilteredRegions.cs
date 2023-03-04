using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core.Security;using Metex.Core;

namespace NZPostOffice.Entity
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("region_id", "_region_id", "")]
	[MapInfo("rgn_name", "_rgn_name", "")]
	[System.Serializable()]

    public class FilteredRegions : Entity<FilteredRegions>
	{
		#region Business Methods
		[DBField()]
		private int?  _region_id;

		[DBField()]
		private string  _rgn_name;


		public virtual int? RegionId
		{
			get
			{
				CanReadProperty(true);
				return _region_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _region_id != value )
				{
					_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RgnName
		{
			get
			{
				CanReadProperty(true);
				return _rgn_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}
		private FilteredRegions[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static FilteredRegions NewDddwFilteredRegions(  )
		{
			return Create();
		}

		public static FilteredRegions[] GetAllDddwFilteredRegions(  )
		{
			return Fetch().dataList;
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

					List<FilteredRegions> list = new List<FilteredRegions>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							FilteredRegions instance = new FilteredRegions();
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new FilteredRegions[list.Count];
						list.CopyTo(dataList);
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
