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
	[MapInfo("start_date", "_start_date", "")]
	[System.Serializable()]

	public class YearSearch : Entity<YearSearch>
	{
		#region Business Methods
		[DBField()]
		private DateTime?  _start_date;

		public virtual DateTime? StartDate
		{
			get
			{
				CanReadProperty("StartDate",true);
				return _start_date;
			}
			set
			{
				CanWriteProperty("CanWriteProperty",true);
				if ( _start_date != value )
				{
					_start_date = value;
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
		public static YearSearch NewYearSearch(  )
		{
			return Create();
		}

		public static YearSearch[] GetAllYearSearch(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();

					List<YearSearch> _list = new List<YearSearch>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							YearSearch instance = new YearSearch();
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
