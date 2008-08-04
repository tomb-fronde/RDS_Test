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
	[MapInfo("tc_id", "_tc_id", "towncity",true)]
	[MapInfo("region_id", "_region_id", "towncity")]
	[MapInfo("tc_name", "_tc_name", "towncity")]
	[System.Serializable()]

	public class DTowncity : Entity<DTowncity>
	{
		#region Business Methods
		[DBField()]
		private int?  _tc_id;

		[DBField()]
		private int?  _region_id;

		[DBField()]
		private string  _tc_name;


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
		private DTowncity[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _tc_id );
		}
		#endregion

		#region Factory Methods
        public static DTowncity NewTowncity(int? tc_id)
		{
            return Create(tc_id);
		}

		public static DTowncity[] GetAllTowncity(  )
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
					GenerateSelectCommandText(cm, "towncity");

					List<DTowncity> list = new List<DTowncity>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DTowncity instance = new DTowncity();
							instance.StoreFieldValues(dr, "towncity");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new DTowncity[list.Count];
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
				if (GenerateUpdateCommandText(cm, "towncity", ref pList))
				{
					cm.CommandText += " WHERE  towncity.tc_id = @tc_id ";

					pList.Add(cm, "tc_id", GetInitialValue("_tc_id"));
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
				if (GenerateInsertCommandText(cm, "towncity", pList))
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
					pList.Add(cm,"tc_id", GetInitialValue("_tc_id"));
						cm.CommandText = "DELETE FROM towncity WHERE " +
						"towncity.tc_id = @tc_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? tc_id )
		{
			_tc_id = tc_id;
		}
	}
}
