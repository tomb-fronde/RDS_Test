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
	[MapInfo("vs_key", "_vs_key", "vehicle_style", true)]
	[MapInfo("vs_description", "_vs_description", "vehicle_style")]
	[System.Serializable()]

	public class VehicalClass : Entity<VehicalClass>
	{
		#region Business Methods
		[DBField()]
		private int?  _vs_key;

		[DBField()]
		private string  _vs_description;


		public virtual int? VsKey
		{
			get
			{
				CanReadProperty(true);
				return _vs_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _vs_key != value )
				{
					_vs_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string VsDescription
		{
			get
			{
				CanReadProperty(true);
				return _vs_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _vs_description != value )
				{
					_vs_description = value;
					PropertyHasChanged();
				}
			}
		}
		private VehicalClass[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _vs_key );
		}
		#endregion

		#region Factory Methods
        public static VehicalClass NewVehicalClass(int? vs_key)
		{
            return Create(vs_key);
		}

		public static VehicalClass[] GetAllVehicalClass(  )
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
					GenerateSelectCommandText(cm, "vehicle_style");

					List<VehicalClass> list = new List<VehicalClass>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VehicalClass instance = new VehicalClass();
							instance.StoreFieldValues(dr, "vehicle_style");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new VehicalClass[list.Count];
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
				if (GenerateUpdateCommandText(cm, "vehicle_style", ref pList))
				{
					cm.CommandText += " WHERE  vehicle_style.vs_key = @vs_key ";

					pList.Add(cm, "vs_key", GetInitialValue("_vs_key"));
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
				if (GenerateInsertCommandText(cm, "vehicle_style", pList))
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
					pList.Add(cm,"vs_key", GetInitialValue("_vs_key"));
						cm.CommandText = "DELETE FROM vehicle_style WHERE " +
						"vehicle_style.vs_key = @vs_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? vs_key )
		{
			_vs_key = vs_key;
		}
	}
}
