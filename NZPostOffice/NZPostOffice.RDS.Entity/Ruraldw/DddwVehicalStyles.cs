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
	[MapInfo("vs_key", "_vs_key", "vehicle_style")]
	[MapInfo("vs_description", "_vs_description", "vehicle_style")]
	[System.Serializable()]

	public class DddwVehicalStyles : Entity<DddwVehicalStyles>
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
                CanReadProperty("VsKey", true);
				return _vs_key;
			}
			set
			{
                CanWriteProperty("VsKey", true);
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
                CanReadProperty("VsDescription", true);
				return _vs_description;
			}
			set
			{
                CanWriteProperty("VsDescription", true);
				if ( _vs_description != value )
				{
					_vs_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _vs_key );
		}
		#endregion

		#region Factory Methods
		public static DddwVehicalStyles NewDddwVehicalStyles(  )
		{
			return Create();
		}

		public static DddwVehicalStyles[] GetAllDddwVehicalStyles(  )
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
                    cm.CommandText = "SELECT vehicle_style.vs_key,   vehicle_style.vs_description  FROM vehicle_style";

					List<DddwVehicalStyles> _list = new List<DddwVehicalStyles>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwVehicalStyles instance = new DddwVehicalStyles();
                            instance._vs_key = GetValueFromReader<Int32?>(dr,0);
                            instance._vs_description = GetValueFromReader<String>(dr,1);

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
