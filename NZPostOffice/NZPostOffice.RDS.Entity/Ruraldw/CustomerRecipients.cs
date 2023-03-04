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
	[MapInfo("cust_id", "_cust_id", "rds_customer")]
	[System.Serializable()]

	public class CustomerRecipients : Entity<CustomerRecipients>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;


		public virtual int? CustId
		{
			get
			{
                CanReadProperty("CustId", true);
				return _cust_id;
			}
			set
			{
                CanWriteProperty("CustId", true);
				if ( _cust_id != value )
				{
					_cust_id = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _cust_id );
		}
		#endregion

		#region Factory Methods
		public static CustomerRecipients NewCustomerRecipients( int? al_cust_id )
		{
			return Create(al_cust_id);
		}

		public static CustomerRecipients[] GetAllCustomerRecipients( int? al_cust_id )
		{
			return Fetch(al_cust_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_cust_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT rds_customer.cust_id  FROM rds_customer  WHERE		rds_customer.cust_id = @al_cust_id  UNION  SELECT rds_customer.cust_id  FROM rds_customer  WHERE		rds_customer.master_cust_id = @al_cust_id    ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_cust_id", al_cust_id);

					List<CustomerRecipients> _list = new List<CustomerRecipients>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustomerRecipients instance = new CustomerRecipients();
                            instance._cust_id = GetValueFromReader<Int32?>(dr,0);
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
				if (GenerateUpdateCommandText(cm, "rds_customer", ref pList))
				{
					cm.CommandText += " WHERE  rds_customer.cust_id = @cust_id ";

					pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
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
				if (GenerateInsertCommandText(cm, "rds_customer", pList))
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
					pList.Add(cm,"cust_id", GetInitialValue("_cust_id"));
						cm.CommandText = "DELETE FROM rds_customer WHERE " +
						"rds_customer.cust_id = @cust_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? cust_id )
		{
			_cust_id = cust_id;
		}
	}
}
