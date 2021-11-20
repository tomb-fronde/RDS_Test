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
	[MapInfo("vt_key", "_vt_key", "vehicle_type", true)]
	[MapInfo("vt_description", "_vt_description", "vehicle_type")]
	[System.Serializable()]

	public class VehicalType : Entity<VehicalType>
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
				CanReadProperty(true);
				return _vt_key;
			}
			set
			{
				CanWriteProperty(true);
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
				CanReadProperty(true);
				return _vt_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _vt_description != value )
				{
					_vt_description = value;
					PropertyHasChanged();
				}
			}
		}
		private VehicalType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _vt_key );
		}
		#endregion

		#region Factory Methods
        public static VehicalType NewVehicalType(int? vt_key)
		{
            return Create(vt_key);
		}

		public static VehicalType[] GetAllVehicalType(  )
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
					GenerateSelectCommandText(cm, "vehicle_type");

					List<VehicalType> list = new List<VehicalType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehicalType instance = new VehicalType();
							instance.StoreFieldValues(dr, "vehicle_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new VehicalType[list.Count];
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
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
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
