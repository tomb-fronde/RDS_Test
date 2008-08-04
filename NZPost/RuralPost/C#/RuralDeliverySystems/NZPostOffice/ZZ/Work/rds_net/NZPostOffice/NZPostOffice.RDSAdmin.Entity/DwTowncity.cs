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
	[MapInfo("tc_name", "_tc_name", "towncity")]
	[MapInfo("tc_id", "_tc_id", "towncity")]
	[MapInfo("sl_id", "_sl_id", "town_suburb")]
	[System.Serializable()]

	public class Towncity : Entity<Towncity>
	{
		#region Business Methods
		[DBField()]
		private string  _tc_name;

		[DBField()]
		private int?  _tc_id;

		[DBField()]
		private int?  _sl_id;


		public virtual string TcName
		{
			get
			{
				CanReadProperty(true);
				return _tc_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _tc_name != value )
				{
					_tc_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? TcId
		{
			get
			{
				CanReadProperty(true);
				return _tc_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _tc_id != value )
				{
					_tc_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SlId
		{
			get
			{
				CanReadProperty(true);
				return _sl_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _sl_id != value )
				{
					_sl_id = value;
					PropertyHasChanged();
				}
			}
		}
		private Towncity[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static Towncity NewTowncity( int? al_tc_sl_id )
		{
			return Create(al_tc_sl_id);
		}

		public static Towncity[] GetAllTowncity( int? al_tc_sl_id )
		{
			return Fetch(al_tc_sl_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_tc_sl_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_tc_sl_id", al_tc_sl_id);
                    cm.CommandText = "SELECT  towncity.tc_name , " +
                      " towncity.tc_id ,town_suburb.sl_id     FROM towncity ," +
                       "town_suburb     " +
                      "WHERE ( town_suburb.tc_id = towncity.tc_id ) and          ( ( town_suburb.sl_id = @al_tc_sl_id ) ) " +
                      "ORDER BY towncity.tc_name          ASC";

					List<Towncity> list = new List<Towncity>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Towncity instance = new Towncity();
							instance.StoreFieldValues(dr, "towncity");
							instance.StoreFieldValues(dr, "town_suburb");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new Towncity[list.Count];
						list.CopyTo(dataList);
					}
				}
			}
		}

		#endregion

		[ServerMethod()]
        private void CreateEntity(int? al_tc_sl_id)
		{
            _sl_id = al_tc_sl_id;
		}
	}
}
