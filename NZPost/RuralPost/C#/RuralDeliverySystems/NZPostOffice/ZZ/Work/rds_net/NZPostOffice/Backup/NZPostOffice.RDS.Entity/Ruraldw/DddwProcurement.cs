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
	[MapInfo("proc_id", "_proc_id", "procurement")]
	[MapInfo("proc_name", "_proc_name", "procurement")]
	[System.Serializable()]

	public class DddwProcurement : Entity<DddwProcurement>
	{
		#region Business Methods
		[DBField()]
		private int?  _proc_id;

		[DBField()]
		private string  _proc_name;


		public virtual int? ProcId
		{
			get
			{
                CanReadProperty("ProcId", true);
				return _proc_id;
			}
			set
			{
                CanWriteProperty("ProcId", true);
				if ( _proc_id != value )
				{
					_proc_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ProcName
		{
			get
			{
                CanReadProperty("ProcName", true);
				return _proc_name;
			}
			set
			{
                CanWriteProperty("ProcName", true);
				if ( _proc_name != value )
				{
					_proc_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _proc_id );
		}
		#endregion

		#region Factory Methods
		public static DddwProcurement NewDddwProcurement(  )
		{
			return Create();
		}

		public static DddwProcurement[] GetAllDddwProcurement(  )
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
                    cm.CommandText = "SELECT procurement.proc_id,   procurement.proc_name  FROM procurement  ORDER BY procurement.proc_id ASC";

					List<DddwProcurement> _list = new List<DddwProcurement>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwProcurement instance = new DddwProcurement();
                            instance._proc_id = GetValueFromReader<Int32?>(dr,0);
                            instance._proc_name = GetValueFromReader<String>(dr,1);

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
				if (GenerateUpdateCommandText(cm, "procurement", ref pList))
				{
					cm.CommandText += " WHERE  procurement.proc_id = @proc_id ";

					pList.Add(cm, "proc_id", GetInitialValue("_proc_id"));
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
				if (GenerateInsertCommandText(cm, "procurement", pList))
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
					pList.Add(cm,"proc_id", GetInitialValue("_proc_id"));
						cm.CommandText = "DELETE FROM procurement WHERE " +
						"procurement.proc_id = @proc_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? proc_id )
		{
			_proc_id = proc_id;
		}
	}
}
