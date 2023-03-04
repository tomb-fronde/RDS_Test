using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralmailmerge
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("select_ind", "_select_ind", "")]
	[MapInfo("proc_name", "_proc_name", "procurement")]
	[MapInfo("proc_id", "_proc_id", "procurement")]
	[System.Serializable()]

	public class SelectProcurements : Entity<SelectProcurements>
	{
		#region Business Methods
		[DBField()]
		private string  _select_ind;

		[DBField()]
		private string  _proc_name;

		[DBField()]
		private int?  _proc_id;


		public virtual string SelectInd
		{
			get
			{
                CanReadProperty("SelectInd", true);
				return _select_ind;
			}
			set
			{
                CanWriteProperty("SelectInd", true);
				if ( _select_ind != value )
				{
					_select_ind = value;
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

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _proc_id );
		}
		#endregion

		#region Factory Methods
		public static SelectProcurements NewSelectProcurements(  )
		{
			return Create();
		}

		public static SelectProcurements[] GetAllSelectProcurements(  )
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
					cm.CommandText = "SELECT 'N' as select_ind,  proc_name,  proc_id  FROM procurement  ";
					ParameterCollection pList = new ParameterCollection();

					List<SelectProcurements> _list = new List<SelectProcurements>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							SelectProcurements instance = new SelectProcurements();
                            instance._select_ind = GetValueFromReader<String>(dr,0);
                            instance._proc_name = GetValueFromReader<String>(dr,1);
                            instance._proc_id = GetValueFromReader<Int32?>(dr,2);

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
