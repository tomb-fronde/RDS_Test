using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("alt_key", "_alt_key", "allowance_type", true)]
	[MapInfo("alt_description", "_alt_description", "allowance_type")]
	[System.Serializable()]

	public class AllowanceType : Entity<AllowanceType>
	{
		#region Business Methods
		[DBField()]
		private int?  _alt_key;

		[DBField()]
		private string  _alt_description;


		public virtual int? AltKey
		{
			get
			{
				CanReadProperty(true);
				return _alt_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _alt_key != value )
				{
					_alt_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AltDescription
		{
			get
			{
				CanReadProperty(true);
				return _alt_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _alt_description != value )
				{
					_alt_description = value;
					PropertyHasChanged();
				}
			}
		}
		private AllowanceType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _alt_key );
		}
		#endregion

		#region Factory Methods
        public static AllowanceType NewAllowanceType(int? alt_key)
		{
            return Create(alt_key);
		}

		public static AllowanceType[] GetAllAllowanceType(  )
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
					GenerateSelectCommandText(cm, "allowance_type");

					List<AllowanceType> list = new List<AllowanceType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							AllowanceType instance = new AllowanceType();
							instance.StoreFieldValues(dr, "allowance_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new AllowanceType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "allowance_type", ref pList))
				{
					cm.CommandText += " WHERE  allowance_type.alt_key = @alt_key ";

					pList.Add(cm, "alt_key", GetInitialValue("_alt_key"));
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
				if (GenerateInsertCommandText(cm, "allowance_type", pList))
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
					pList.Add(cm,"alt_key", GetInitialValue("_alt_key"));
						cm.CommandText = "DELETE FROM allowance_type WHERE " +
						"allowance_type.alt_key = @alt_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? alt_key )
		{
			_alt_key = alt_key;
		}
	}
}
