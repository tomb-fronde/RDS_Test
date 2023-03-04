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
	[MapInfo("rfv_id", "_rfv_id", "route_freq_verbs")]
	[MapInfo("rfv_description", "_rfv_description", "route_freq_verbs")]
	[System.Serializable()]

	public class RouteFreqVerbs : Entity<RouteFreqVerbs>
	{
		#region Business Methods
		[DBField()]
		private int?  _rfv_id;

		[DBField()]
		private string  _rfv_description;


		public virtual int? RfvId
		{
			get
			{
				CanReadProperty(true);
				return _rfv_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rfv_id != value )
				{
					_rfv_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfvDescription
		{
			get
			{
				CanReadProperty(true);
				return _rfv_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rfv_description != value )
				{
					_rfv_description = value;
					PropertyHasChanged();
				}
			}
		}
		private RouteFreqVerbs[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rfv_id );
		}
		#endregion

		#region Factory Methods
        public static RouteFreqVerbs NewRouteFreqVerbs(int? rfv_id)
		{
            return Create(rfv_id);
		}

		public static RouteFreqVerbs[] GetAllRouteFreqVerbs(  )
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
					GenerateSelectCommandText(cm, "route_freq_verbs");

					List<RouteFreqVerbs> list = new List<RouteFreqVerbs>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RouteFreqVerbs instance = new RouteFreqVerbs();
							instance.StoreFieldValues(dr, "route_freq_verbs");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new RouteFreqVerbs[list.Count];
						list.CopyTo(dataList);
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
				if (GenerateUpdateCommandText(cm, "route_freq_verbs", ref pList))
				{
					cm.CommandText += " WHERE  route_freq_verbs.rfv_id = @rfv_id ";

					pList.Add(cm, "rfv_id", GetInitialValue("_rfv_id"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "route_freq_verbs", pList))
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
					pList.Add(cm,"rfv_id", GetInitialValue("_rfv_id"));
						cm.CommandText = "DELETE FROM route_freq_verbs WHERE " +
						"route_freq_verbs.rfv_id = @rfv_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rfv_id )
		{
			_rfv_id = rfv_id;
		}
	}
}
