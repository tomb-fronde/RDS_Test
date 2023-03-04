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
	[MapInfo("proc_id", "_proc_id", "procurement")]
	[MapInfo("proc_name", "_proc_name", "procurement")]
	[System.Serializable()]

	public class Procurement : Entity<Procurement>
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
				CanReadProperty(true);
				return _proc_id;
			}
			set
			{
				CanWriteProperty(true);
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
				CanReadProperty(true);
				return _proc_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _proc_name != value )
				{
					_proc_name = value;
					PropertyHasChanged();
				}
			}
		}
		private Procurement[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _proc_id );
		}
		#endregion

		#region Factory Methods
        public static Procurement NewProcurement(int? proc_id)
		{
            return Create(proc_id);
		}

		public static Procurement[] GetAllProcurement(  )
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
					GenerateSelectCommandText(cm, "procurement");
					cm.CommandText += "ORDER BY procurement.proc_id ASC";

					List<Procurement> list = new List<Procurement>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Procurement instance = new Procurement();
							instance.StoreFieldValues(dr, "procurement");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new Procurement[list.Count];
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
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
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
