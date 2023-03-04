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
	[MapInfo("sl_id", "_sl_id", "suburblocality",true)]
	[MapInfo("sl_name", "_sl_name", "suburblocality")]
	[System.Serializable()]

	public class Suburblocality : Entity<Suburblocality>
	{
		#region Business Methods
		[DBField()]
		private int?  _sl_id;

		[DBField()]
		private string  _sl_name;


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

		public virtual string SlName
		{
			get
			{
				CanReadProperty(true);
				return _sl_name;
			}
			set
			{
				CanWriteProperty(true);
				if ( _sl_name != value )
				{
					_sl_name = value;
					PropertyHasChanged();
				}
			}
		}
		private Suburblocality[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _sl_id );
		}
		#endregion

		#region Factory Methods
        public static Suburblocality NewSuburblocality(int? sl_id)
		{
            return Create(sl_id);
		}

		public static Suburblocality[] GetAllSuburblocality(  )
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
					GenerateSelectCommandText(cm, "suburblocality");
                    cm.CommandText += " order by suburblocality.sl_name  ";
					List<Suburblocality> list = new List<Suburblocality>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Suburblocality instance = new Suburblocality();
							instance.StoreFieldValues(dr, "suburblocality");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new Suburblocality[list.Count];
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
				if (GenerateUpdateCommandText(cm, "suburblocality", ref pList))
				{
					cm.CommandText += " WHERE  suburblocality.sl_id = @sl_id ";

					pList.Add(cm, "sl_id", GetInitialValue("_sl_id"));
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
