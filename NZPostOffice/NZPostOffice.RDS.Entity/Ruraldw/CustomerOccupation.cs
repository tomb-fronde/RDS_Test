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
	[MapInfo("cust_id", "_cust_id", "customer_occupation")]
	[MapInfo("occupation_id", "_occupation_id", "customer_occupation")]
	[System.Serializable()]

	public class CustomerOccupation : Entity<CustomerOccupation>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;

		[DBField()]
		private int?  _occupation_id;


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

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}", _cust_id,_occupation_id );
		}
		#endregion

		#region Factory Methods
		public static CustomerOccupation NewCustomerOccupation( int? al_cust_id )
		{
			return Create(al_cust_id);
		}

		public static CustomerOccupation[] GetAllCustomerOccupation( int? al_cust_id )
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
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_cust_id", al_cust_id);
                    cm.CommandText = @"SELECT customer_occupation.cust_id,   
                                             customer_occupation.occupation_id  
                                        FROM customer_occupation  
                                       WHERE ( customer_occupation.cust_id = @al_cust_id ) AND  
                                             ( @al_cust_id > 0 )";

					List<CustomerOccupation> _list = new List<CustomerOccupation>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustomerOccupation instance = new CustomerOccupation();
                            instance._cust_id = GetValueFromReader<Int32?>(dr,0);
                            instance._occupation_id = GetValueFromReader<Int32?>(dr,1);
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
				if (GenerateUpdateCommandText(cm, "customer_occupation", ref pList))
				{
					cm.CommandText += " WHERE  customer_occupation.cust_id = @cust_id AND " + 
						"customer_occupation.occupation_id = @occupation_id ";

					pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
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
				if (GenerateInsertCommandText(cm, "customer_occupation", pList))
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
					pList.Add(cm,"occupation_id", GetInitialValue("_occupation_id"));
						cm.CommandText = "DELETE FROM customer_occupation WHERE " +
						"customer_occupation.cust_id = @cust_id AND " + 
						"customer_occupation.occupation_id = @occupation_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? cust_id, int? occupation_id )
		{
			_cust_id = cust_id;
			_occupation_id = occupation_id;
		}
	}
}
