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
	[MapInfo("sl_name", "_suburb_name", "suburblocality")]
	[MapInfo("sl_id", "_sl_id", "suburblocality")]
	[System.Serializable()]

	public class Suburb : Entity<Suburb>
	{
		#region Business Methods
		[DBField()]
		private string  _suburb_name;

		[DBField()]
		private int?  _sl_id;


		public virtual string SuburbName
		{
			get
			{
				CanReadProperty(true);
				return _suburb_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _suburb_name != value )
				{
					_suburb_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SlId
		{
			get
			{
				CanReadProperty(true);
				return _sl_id;
			}
			set
			{
				CanWriteProperty(true);
				if ( _sl_id != value )
				{
					_sl_id = value;
					PropertyHasChanged();
				}
			}
		}
		private Suburb[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _sl_id );
		}
		#endregion

		#region Factory Methods
		public static Suburb NewSuburb( int? al_suburb_id )
		{
			return Create(al_suburb_id);
		}

		public static Suburb[] GetAllSuburb( int? al_suburb_id )
		{
			return Fetch(al_suburb_id).dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_suburb_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_suburb_id", al_suburb_id);
					GenerateSelectCommandText(cm, "suburblocality");
                    cm.CommandText += " where sl_id = @al_suburb_id";

					List<Suburb> list = new List<Suburb>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Suburb instance = new Suburb();
							instance.StoreFieldValues(dr, "suburblocality");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new Suburb[list.Count];
						list.CopyTo(dataList);
					}
				}
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
				if (GenerateInsertCommandText(cm, "suburblocality", pList))
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
					pList.Add(cm,"sl_id", GetInitialValue("_sl_id"));
						cm.CommandText = "DELETE FROM suburblocality WHERE " +
						"suburblocality.sl_id = @sl_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? sl_id )
		{
			_sl_id = sl_id;
		}
	}
}
