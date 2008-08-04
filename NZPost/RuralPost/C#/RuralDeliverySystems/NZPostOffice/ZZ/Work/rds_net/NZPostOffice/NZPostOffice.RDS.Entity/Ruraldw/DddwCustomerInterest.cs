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
	[MapInfo("interest_id", "_interest_id", "interest")]
	[MapInfo("interest_description", "_interest_description", "interest")]
	[System.Serializable()]

	public class DddwCustomerInterest : Entity<DddwCustomerInterest>
	{
		#region Business Methods
		[DBField()]
		private int?  _interest_id;

		[DBField()]
		private string  _interest_description;


		public virtual int? InterestId
		{
			get
			{
                CanReadProperty("InterestId", true);
				return _interest_id;
			}
			set
			{
                CanWriteProperty("InterestId", true);
				if ( _interest_id != value )
				{
					_interest_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string InterestDescription
		{
			get
			{
                CanReadProperty("InterestDescription", true);
				return _interest_description;
			}
			set
			{
                CanWriteProperty("InterestDescription", true);
				if ( _interest_description != value )
				{
					_interest_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _interest_id );
		}
		#endregion

		#region Factory Methods
		public static DddwCustomerInterest NewDddwCustomerInterest(  )
		{
			return Create();
		}

		public static DddwCustomerInterest[] GetAllDddwCustomerInterest(  )
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
                    cm.CommandText = "SELECT interest.interest_id,   interest.interest_description  FROM interest ";

					List<DddwCustomerInterest> _list = new List<DddwCustomerInterest>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwCustomerInterest instance = new DddwCustomerInterest();
                            instance._interest_id = GetValueFromReader<Int32?>(dr,0);
                            instance._interest_description = GetValueFromReader<String>(dr,1);
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
				if (GenerateUpdateCommandText(cm, "interest", ref pList))
				{
					cm.CommandText += " WHERE  interest.interest_id = @interest_id ";

					pList.Add(cm, "interest_id", GetInitialValue("_interest_id"));
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
				if (GenerateInsertCommandText(cm, "interest", pList))
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
					pList.Add(cm,"interest_id", GetInitialValue("_interest_id"));
						cm.CommandText = "DELETE FROM interest WHERE " +
						"interest.interest_id = @interest_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? interest_id )
		{
			_interest_id = interest_id;
		}
	}
}
