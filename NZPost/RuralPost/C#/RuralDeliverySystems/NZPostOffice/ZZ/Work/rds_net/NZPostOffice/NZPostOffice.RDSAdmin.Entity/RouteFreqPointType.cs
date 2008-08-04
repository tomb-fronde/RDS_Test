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
	[MapInfo("rfpt_id", "_rfpt_id", "route_freq_point_type")]
	[MapInfo("rfpt_description", "_rfpt_description", "route_freq_point_type")]
	[System.Serializable()]

	public class RouteFreqPointType : Entity<RouteFreqPointType>
	{
		#region Business Methods
		[DBField()]
		private int?  _rfpt_id;

		[DBField()]
		private string  _rfpt_description;


		public virtual int? RfptId
		{
			get
			{
				CanReadProperty(true);
				return _rfpt_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rfpt_id != value )
				{
					_rfpt_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfptDescription
		{
			get
			{
				CanReadProperty(true);
				return _rfpt_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _rfpt_description != value )
				{
					_rfpt_description = value;
					PropertyHasChanged();
				}
			}
		}
		private RouteFreqPointType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _rfpt_id );
		}
		#endregion

		#region Factory Methods
        public static RouteFreqPointType NewRouteFreqPointType(int? rfpt_id)
		{
            return Create(rfpt_id);
		}

		public static RouteFreqPointType[] GetAllRouteFreqPointType(  )
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
					GenerateSelectCommandText(cm, "route_freq_point_type");

					List<RouteFreqPointType> list = new List<RouteFreqPointType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							RouteFreqPointType instance = new RouteFreqPointType();
							instance.StoreFieldValues(dr, "route_freq_point_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new RouteFreqPointType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "route_freq_point_type", ref pList))
				{
					cm.CommandText += " WHERE  route_freq_point_type.rfpt_id = @rfpt_id ";

					pList.Add(cm, "rfpt_id", GetInitialValue("_rfpt_id"));
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
				if (GenerateInsertCommandText(cm, "route_freq_point_type", pList))
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
					pList.Add(cm,"rfpt_id", GetInitialValue("_rfpt_id"));
						cm.CommandText = "DELETE FROM route_freq_point_type WHERE " +
						"route_freq_point_type.rfpt_id = @rfpt_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? rfpt_id )
		{
			_rfpt_id = rfpt_id;
		}
	}
}
