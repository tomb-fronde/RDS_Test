using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("sl_id", "_sl_id", "suburblocality")]
	[MapInfo("sl_name", "_sl_name", "suburblocality")]
	[System.Serializable()]

	public class DddwSuburb : Entity<DddwSuburb>
	{
		#region Business Methods
		[DBField()]
		private int?  _sl_id;

		[DBField()]
		private string  _sl_name;


		public virtual int? SlId
		{
			get
			{
                CanReadProperty("SlId", true);
				return _sl_id;
			}
			set
			{
                CanWriteProperty("SlId", true);
				if ( _sl_id != value )
				{
					_sl_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SlName
		{
			get
			{
                CanReadProperty("SlName", true);
				return _sl_name;
			}
			set
			{
                CanWriteProperty("SlName", true);
				if ( _sl_name != value )
				{
					_sl_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _sl_id );
		}
		#endregion

		#region Factory Methods
		public static DddwSuburb NewDddwSuburb(  )
		{
			return Create();
		}

		public static DddwSuburb[] GetAllDddwSuburb(  )
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
                    /*PP! - changed CommandText as it was taken from DddwSuburbs by mistake
                    cm.CommandText = "select distinct sl_name" +
                        "  from rd.road  left outer join rd.road_suburb on road.road_id = road_suburb.road_id" +
                        "             left outer join rd.suburblocality on road_suburb.sl_id = suburblocality.sl_id" +
                        " where road.road_name like '%'";
                    */
                    cm.CommandText = "SELECT  suburblocality.sl_id , suburblocality.sl_name FROM suburblocality";

					ParameterCollection pList = new ParameterCollection();

					List<DddwSuburb> _list = new List<DddwSuburb>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwSuburb instance = new DddwSuburb();
                            instance._sl_name = GetValueFromReader<String>(dr,1);
                            instance.SlId = GetValueFromReader<int?>(dr, 0);
                            
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		[ServerMethod()]
		private void UpdateEntity()
		{
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "suburblocality", ref pList))
				{
					cm.CommandText += " WHERE  suburblocality.sl_id = @sl_id ";

					pList.Add(cm, "sl_id", GetInitialValue("_sl_id"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "suburblocality", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
			using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;
					cm.CommandType = CommandType.Text;
						ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"sl_id", GetInitialValue("_sl_id"));
						cm.CommandText = "DELETE FROM suburblocality WHERE " +
						"suburblocality.sl_id = @sl_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? sl_id )
		{
			_sl_id = sl_id;
		}
	}
}
