using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("search", "_search", "")]
	[System.Serializable()]

	public class SearchComponent : Entity<SearchComponent>
	{
		#region Business Methods
		[DBField()]
		private string  _search;


		public virtual string Search
		{
			get
			{
				CanReadProperty(true);
				return _search;
			}
			set
			{
				CanWriteProperty(true);
				if ( _search != value )
				{
					_search = value;
					PropertyHasChanged();
				}
			}
		}
		private SearchComponent[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static SearchComponent NewSearchComponent(  )
		{
			return Create();
		}

		public static SearchComponent[] GetAllSearchComponent(  )
		{
			return Fetch().dataList;
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

					List<SearchComponent> list = new List<SearchComponent>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							SearchComponent instance = new SearchComponent();
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new SearchComponent[list.Count];
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
