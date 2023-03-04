using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("tc_name", "_town", "towncity")]
	[MapInfo("tc_id", "_contract", "towncity")]
	[System.Serializable()]

	public class TownSelect : Entity<TownSelect>
	{
		#region Business Methods
		[DBField()]
		private string  _town;

		[DBField()]
		private int?  _contract;


		public virtual string Town
		{
			get
			{
                CanReadProperty("Town", true);
				return _town;
			}
			set
			{
                CanWriteProperty("Town", true);
				if ( _town != value )
				{
					_town = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Contract
		{
			get
			{
                CanReadProperty("Contract", true);
				return _contract;
			}
			set
			{
                CanWriteProperty("Contract", true);
				if ( _contract != value )
				{
					_contract = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _contract );
		}
		#endregion

		#region Factory Methods
		public static TownSelect NewTownSelect(  )
		{
			return Create();
		}

		public static TownSelect[] GetAllTownSelect(  )
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
                    cm.CommandText = " SELECT towncity.tc_name, "
                                   + " towncity.tc_id" 
                                   + " FROM towncity"
                                   + " ORDER BY towncity.tc_name ASC ";
					List<TownSelect> _list = new List<TownSelect>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							TownSelect instance = new TownSelect();
                            instance._town = GetValueFromReader<string>(dr,0);
                            instance._contract = GetValueFromReader<int?>(dr,1);
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
				if (GenerateUpdateCommandText(cm, "towncity", ref pList))
				{
					cm.CommandText += " WHERE  towncity.tc_id = @tc_id ";

					pList.Add(cm, "tc_id", GetInitialValue("_contract"));
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
					pList.Add(cm,"tc_id", GetInitialValue("_contract"));
						cm.CommandText = "DELETE FROM towncity WHERE " +
						"towncity.tc_id = @tc_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract )
		{
			_contract = contract;
		}
	}
}
