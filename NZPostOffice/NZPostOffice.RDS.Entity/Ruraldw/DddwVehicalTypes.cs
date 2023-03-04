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
	[MapInfo("vt_key", "_vt_key", "vehicle_type")]
	[MapInfo("vt_description", "_vt_description", "vehicle_type")]
	[System.Serializable()]

	public class DddwVehicalTypes : Entity<DddwVehicalTypes>
	{
		#region Business Methods
		[DBField()]
		private int?  _vt_key;

		[DBField()]
		private string  _vt_description;


		public virtual int? VtKey
		{
			get
			{
                CanReadProperty("VtKey", true);
				return _vt_key;
			}
			set
			{
                CanWriteProperty("VtKey", true);
				if ( _vt_key != value )
				{
					_vt_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VtDescription
		{
			get
			{
                CanReadProperty("VtDescription", true);
				return _vt_description;
			}
			set
			{
                CanWriteProperty("VtDescription", true);
				if ( _vt_description != value )
				{
					_vt_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _vt_key );
		}
		#endregion

		#region Factory Methods
		public static DddwVehicalTypes NewDddwVehicalTypes(  )
		{
			return Create();
		}

		public static DddwVehicalTypes[] GetAllDddwVehicalTypes(  )
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
                    cm.CommandText = "SELECT vehicle_type.vt_key,   vehicle_type.vt_description  FROM vehicle_type";

					List<DddwVehicalTypes> _list = new List<DddwVehicalTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwVehicalTypes instance = new DddwVehicalTypes();
                            instance._vt_key = GetValueFromReader<Int32?>(dr,0);
                            instance._vt_description = GetValueFromReader<String>(dr,1);

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
				if (GenerateUpdateCommandText(cm, "vehicle_type", ref pList))
				{
					cm.CommandText += " WHERE  vehicle_type.vt_key = @vt_key ";

					pList.Add(cm, "vt_key", GetInitialValue("_vt_key"));
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
				if (GenerateInsertCommandText(cm, "vehicle_type", pList))
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
					pList.Add(cm,"vt_key", GetInitialValue("_vt_key"));
						cm.CommandText = "DELETE FROM vehicle_type WHERE " +
						"vehicle_type.vt_key = @vt_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? vt_key )
		{
			_vt_key = vt_key;
		}
	}
}
