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
	[MapInfo("cust_id", "_customer_cust_id", "customer")]
	[MapInfo("cust_name", "_ccust_name", "customer")]
	[System.Serializable()]

	public class QsRouteTerminationList : Entity<QsRouteTerminationList>
	{
		#region Business Methods
		[DBField()]
		private int?  _customer_cust_id;

		[DBField()]
		private string  _ccust_name;


		public virtual int? CustomerCustId
		{
			get
			{
                CanReadProperty("CustomerCustId", true);
				return _customer_cust_id;
			}
			set
			{
                CanWriteProperty("CustomerCustId", true);
				if ( _customer_cust_id != value )
				{
					_customer_cust_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CcustName
		{
			get
			{
                CanReadProperty("CcustName", true);
				return _ccust_name;
			}
			set
			{
                CanWriteProperty("CcustName", true);
				if ( _ccust_name != value )
				{
					_ccust_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _customer_cust_id );
		}
		#endregion

		#region Factory Methods
		public static QsRouteTerminationList NewQsRouteTerminationList( int? contract, string street_name )
		{
			return Create(contract, street_name);
		}

		public static QsRouteTerminationList[] GetAllQsRouteTerminationList( int? contract, string street_name )
		{
			return Fetch(contract, street_name).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract, string street_name )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT customer.cust_id, customer.cust_surname_company ||' '|| customer.cust_initials cust_name  FROM customer  WHERE ( customer.contract_no = @contract )  AND (customer.cust_mailing_address_road like '%'||@street_name||'%' )   UNION SELECT customer.cust_id, customer.cust_surname_company ||' '|| customer.cust_initials cust_name  FROM customer  WHERE ( customer.contract_no = @contract )  AND ( soundex(left(customer.cust_mailing_address_road,length(@street_name))) = soundex(@street_name) ) ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contract", contract);
					pList.Add(cm, "street_name", street_name);

					List<QsRouteTerminationList> _list = new List<QsRouteTerminationList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							QsRouteTerminationList instance = new QsRouteTerminationList();
                            instance._customer_cust_id = GetValueFromReader<Int32?>(dr,0);
                            instance._ccust_name = GetValueFromReader<String>(dr,1);

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
				if (GenerateInsertCommandText(cm, "customer", pList))
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
					pList.Add(cm,"cust_id", GetInitialValue("_customer_cust_id"));
						cm.CommandText = "DELETE FROM customer WHERE " +
						"customer.cust_id = @cust_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? customer_cust_id )
		{
			_customer_cust_id = customer_cust_id;
		}
	}
}
