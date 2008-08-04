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
	[MapInfo("occupation_id", "_occupation_id", "occupation")]
	[MapInfo("occupation_description", "_occupation_description", "occupation")]
	[System.Serializable()]

	public class DddwCustomerOccupation : Entity<DddwCustomerOccupation>
	{
		#region Business Methods
		[DBField()]
		private int?  _occupation_id;

		[DBField()]
		private string  _occupation_description;


		public virtual int? OccupationId
		{
			get
			{
                CanReadProperty("OccupationId", true);
				return _occupation_id;
			}
			set
			{
                CanWriteProperty("OccupationId", true);
				if ( _occupation_id != value )
				{
					_occupation_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OccupationDescription
		{
			get
			{
                CanReadProperty("OccupationDescription", true);
				return _occupation_description;
			}
			set
			{
                CanWriteProperty("OccupationDescription", true);
				if ( _occupation_description != value )
				{
					_occupation_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _occupation_id );
		}
		#endregion

		#region Factory Methods
		public static DddwCustomerOccupation NewDddwCustomerOccupation(  )
		{
			return Create();
		}

		public static DddwCustomerOccupation[] GetAllDddwCustomerOccupation(  )
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
                    cm.CommandText = "SELECT occupation.occupation_id,   occupation.occupation_description  FROM occupation order by occupation_description ASC";

					List<DddwCustomerOccupation> _list = new List<DddwCustomerOccupation>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwCustomerOccupation instance = new DddwCustomerOccupation();
                            instance._occupation_id = GetValueFromReader<Int32?>(dr,0);
                            instance._occupation_description = GetValueFromReader<String>(dr,1);
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
				if (GenerateUpdateCommandText(cm, "occupation", ref pList))
				{
					cm.CommandText += " WHERE  occupation.occupation_id = @occupation_id ";

					pList.Add(cm, "occupation_id", GetInitialValue("_occupation_id"));
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
				if (GenerateInsertCommandText(cm, "occupation", pList))
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
					pList.Add(cm,"occupation_id", GetInitialValue("_occupation_id"));
						cm.CommandText = "DELETE FROM occupation WHERE " +
						"occupation.occupation_id = @occupation_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? occupation_id )
		{
			_occupation_id = occupation_id;
		}
	}
}
