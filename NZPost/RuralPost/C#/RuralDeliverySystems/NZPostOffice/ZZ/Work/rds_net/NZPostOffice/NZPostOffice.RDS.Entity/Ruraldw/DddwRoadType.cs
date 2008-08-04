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
	[MapInfo("rt_name", "_rt_name", "road_type")]
	[MapInfo("rt_id", "_rt_id", "road_type")]
	[System.Serializable()]

	public class DddwRoadType : Entity<DddwRoadType>
	{
		#region Business Methods
		[DBField()]
		private string  _rt_name;

		[DBField()]
		private int?  _rt_id;


		public virtual string RtName
		{
			get
			{
                CanReadProperty("RtName", true);
				return _rt_name;
			}
			set
			{
                CanWriteProperty("RtName", true);
				if ( _rt_name != value )
				{
					_rt_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RtId
		{
			get
			{
                CanReadProperty("RtId", true);
				return _rt_id;
			}
			set
			{
                CanWriteProperty("RtId", true);
				if ( _rt_id != value )
				{
					_rt_id = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rt_id );
		}
		#endregion

		#region Factory Methods
		public static DddwRoadType NewDddwRoadType(  )
		{
			return Create();
		}

		public static DddwRoadType[] GetAllDddwRoadType(  )
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
					cm.CommandText = "SELECT road_type.rt_name,  road_type.rt_id  FROM road_type  UNION ALL  SELECT '' as rt_name,  NULL as rt_id  FROM DUMMY  ";

                    //pp! added sorting - here so not to make performance worse
                    cm.CommandText = string.Format("{0} {1}", cm.CommandText, " order by rt_name");

					ParameterCollection pList = new ParameterCollection();

					List<DddwRoadType> _list = new List<DddwRoadType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwRoadType instance = new DddwRoadType();
                            instance._rt_name = dr.GetString(0);
                            instance._rt_id = dr.GetInt32(1);

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
				if (GenerateUpdateCommandText(cm, "road_type", ref pList))
				{
					cm.CommandText += " WHERE  road_type.rt_id = @rt_id ";

					pList.Add(cm, "rt_id", GetInitialValue("_rt_id"));
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
				if (GenerateInsertCommandText(cm, "road_type", pList))
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
					pList.Add(cm,"rt_id", GetInitialValue("_rt_id"));
						cm.CommandText = "DELETE FROM road_type WHERE " +
						"road_type.rt_id = @rt_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rt_id )
		{
			_rt_id = rt_id;
		}
	}
}
