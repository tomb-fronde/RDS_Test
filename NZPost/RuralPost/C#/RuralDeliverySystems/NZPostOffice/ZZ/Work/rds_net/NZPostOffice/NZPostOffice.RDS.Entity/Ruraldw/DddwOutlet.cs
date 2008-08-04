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
	[MapInfo("outlet_id", "_outlet_id", "outlet")]
	[MapInfo("o_name", "_o_name", "outlet")]
	[System.Serializable()]

	public class DddwOutlet : Entity<DddwOutlet>
	{
		#region Business Methods
		[DBField()]
		private int?  _outlet_id;

		[DBField()]
		private string  _o_name;


		public virtual int? OutletId
		{
			get
			{
                CanReadProperty("OutletId", true);
				return _outlet_id;
			}
			set
			{
                CanWriteProperty("OutletId", true);
				if ( _outlet_id != value )
				{
					_outlet_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OName
		{
			get
			{
                CanReadProperty("OName", true);
				return _o_name;
			}
			set
			{
                CanWriteProperty("OName", true);
				if ( _o_name != value )
				{
					_o_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _outlet_id );
		}
		#endregion

		#region Factory Methods
		public static DddwOutlet NewDddwOutlet(  )
		{
			return Create();
		}

		public static DddwOutlet[] GetAllDddwOutlet(  )
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
                    cm.CommandText = "  SELECT outlet.outlet_id,   outlet.o_name  FROM outlet";

					List<DddwOutlet> _list = new List<DddwOutlet>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwOutlet instance = new DddwOutlet();
                            instance._outlet_id = GetValueFromReader<Int32?>(dr,0);
                            instance._o_name = GetValueFromReader<String>(dr,1);
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
				if (GenerateUpdateCommandText(cm, "outlet", ref pList))
				{
					cm.CommandText += " WHERE  outlet.outlet_id = @outlet_id ";

					pList.Add(cm, "outlet_id", GetInitialValue("_outlet_id"));
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
				if (GenerateInsertCommandText(cm, "outlet", pList))
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
					pList.Add(cm,"outlet_id", GetInitialValue("_outlet_id"));
						cm.CommandText = "DELETE FROM outlet WHERE " +
						"outlet.outlet_id = @outlet_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? outlet_id )
		{
			_outlet_id = outlet_id;
		}
	}
}
