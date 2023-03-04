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
	[MapInfo("d_ext_region_id", "_d_ext_region_id", "")]
	[System.Serializable()]

	public class ExtRegion : Entity<ExtRegion>
	{
		#region Business Methods
		[DBField()]
		private int?  _d_ext_region_id;


		public virtual int? DExtRegionId
		{
			get
			{
                CanReadProperty("DExtRegionId", true);
				return _d_ext_region_id;
			}
			set
			{
                CanWriteProperty("DExtRegionId", true);
				if ( _d_ext_region_id != value )
				{
					_d_ext_region_id = value;
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
		public static ExtRegion NewExtRegion(  )
		{
			return Create();
		}

		public static ExtRegion[] GetAllExtRegion(  )
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

					List<ExtRegion> _list = new List<ExtRegion>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ExtRegion instance = new ExtRegion();
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
