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
	[MapInfo("cust_surname_company", "_rds_customer_cust_surname_company", "rds_customer")]
	[MapInfo("cust_initials", "_rds_customer_cust_initials", "rds_customer")]
	[MapInfo("cust_id", "_cust_id", "rds_customer")]
	[System.Serializable()]

	public class DddwPrimContactsForAnAddress : Entity<DddwPrimContactsForAnAddress>
	{
		#region Business Methods
		[DBField()]
		private string  _rds_customer_cust_surname_company;

		[DBField()]
		private string  _rds_customer_cust_initials;

		[DBField()]
		private int?  _cust_id;


		public virtual string RDSCustomerCustSurnameCompany
		{
			get
			{
                CanReadProperty("RDSCustomerCustSurnameCompany", true);
				return _rds_customer_cust_surname_company;
			}
			set
			{
                CanWriteProperty("RDSCustomerCustSurnameCompany", true);
				if ( _rds_customer_cust_surname_company != value )
				{
					_rds_customer_cust_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RDSCustomerCustInitials
		{
			get
			{
                CanReadProperty("RDSCustomerCustInitials", true);
				return _rds_customer_cust_initials;
			}
			set
			{
                CanWriteProperty("RDSCustomerCustInitials", true);
				if ( _rds_customer_cust_initials != value )
				{
					_rds_customer_cust_initials = value;
					PropertyHasChanged();
				}
			}
		}

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
			// needs to implement compute expression manually:
			// compute control name=[customer_name]
			//?if(isnull( rds_customer_cust_initials )  OR Len(Trim(rds_customer_cust_initials))<;=0,  rds_customer_cust_surname_company ,  rds_customer_cust_surname_company + ', ' + rds_customer_cust_initials )
        public virtual string CustomerName
        {
            get
            {
                CanReadProperty("CustomerName", true);
                return ( (_rds_customer_cust_initials == null || _rds_customer_cust_initials.Trim().Length <= 0) ? _rds_customer_cust_surname_company  : _rds_customer_cust_surname_company + ", " + _rds_customer_cust_initials );
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static DddwPrimContactsForAnAddress NewDddwPrimContactsForAnAddress( int? al_adr_id )
		{
			return Create(al_adr_id);
		}

		public static DddwPrimContactsForAnAddress[] GetAllDddwPrimContactsForAnAddress( int? al_adr_id )
		{
			return Fetch(al_adr_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_adr_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "al_adr_id", al_adr_id);
                    cm.CommandText = "  SELECT rds_customer.cust_surname_company,   " +
                        "rds_customer.cust_initials,   " +
                        "rds_customer.cust_id  " +
                        "FROM customer_address_moves,   " +
                        "rds_customer  " +
                        "WHERE ( rds_customer.cust_id = customer_address_moves.cust_id ) and  " +
                        "( ( customer_address_moves.adr_id = @al_adr_id ) AND  " +
                        "( customer_address_moves.move_out_date is null ) AND  " +
                        "( rds_customer.master_cust_id is null ) )    ";
					List<DddwPrimContactsForAnAddress> _list = new List<DddwPrimContactsForAnAddress>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwPrimContactsForAnAddress instance = new DddwPrimContactsForAnAddress();
                            instance._rds_customer_cust_surname_company = GetValueFromReader<String>(dr,0);
                            instance._rds_customer_cust_initials = GetValueFromReader<String>(dr,1);
                            instance._cust_id = GetValueFromReader<Int32?>(dr,2);
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
