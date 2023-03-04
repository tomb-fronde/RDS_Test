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
	[MapInfo("at_key", "_at_key", "artical_type",true)]
	[MapInfo("at_description", "_at_description", "artical_type")]
	[System.Serializable()]

	public class ArticalType : Entity<ArticalType>
	{
		#region Business Methods
		[DBField()]
		private int?  _at_key;

		[DBField()]
		private string  _at_description;


		public virtual int? AtKey
		{
			get
			{
				CanReadProperty(true);
				return _at_key;
			}
			set
			{
				CanWriteProperty(true);
				if ( _at_key != value )
				{
					_at_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AtDescription
		{
			get
			{
				CanReadProperty(true);
				return _at_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _at_description != value )
				{
					_at_description = value;
					PropertyHasChanged();
				}
			}
		}
		private ArticalType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _at_key );
		}
		#endregion

		#region Factory Methods
        public static ArticalType NewArticalType(int? at_key)
		{
            return Create(at_key);
		}

		public static ArticalType[] GetAllArticalType(  )
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
					GenerateSelectCommandText(cm, "artical_type");

					List<ArticalType> list = new List<ArticalType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ArticalType instance = new ArticalType();
							instance.StoreFieldValues(dr, "artical_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new ArticalType[list.Count];
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
				if (GenerateUpdateCommandText(cm, "artical_type", ref pList))
				{
					cm.CommandText += " WHERE  artical_type.at_key = @at_key ";

					pList.Add(cm, "at_key", GetInitialValue("_at_key"));
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
				if (GenerateInsertCommandText(cm, "artical_type", pList))
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
					pList.Add(cm,"at_key", GetInitialValue("_at_key"));
						cm.CommandText = "DELETE FROM artical_type WHERE " +
						"artical_type.at_key = @at_key ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? at_key )
		{
			_at_key = at_key;
		}
	}
}
