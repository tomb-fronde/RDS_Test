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
	[MapInfo("cust_id", "_cust_id", "")]
	[MapInfo("mc_key", "_mc_key", "")]
	[System.Serializable()]

	public class CustomerMailCategoryall : Entity<CustomerMailCategoryall>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;

		[DBField()]
		private int?  _mc_key;


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

		public virtual int? McKey
		{
			get
			{
                CanReadProperty("McKey", true);
				return _mc_key;
			}
			set
			{
                CanWriteProperty("McKey", true);
				if ( _mc_key != value )
				{
					_mc_key = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}", _cust_id,_mc_key );
		}
		#endregion

		#region Factory Methods
		public static CustomerMailCategoryall NewCustomerMailCategoryall( int? in_Cust_Id )
		{
			return Create(in_Cust_Id);
		}

		public static CustomerMailCategoryall[] GetAllCustomerMailCategoryall( int? in_Cust_Id )
		{
			return Fetch(in_Cust_Id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Cust_Id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Cust_Id", in_Cust_Id);
                    cm.CommandText = "rd.sp_getcustmailcat";
					List<CustomerMailCategoryall> _list = new List<CustomerMailCategoryall>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustomerMailCategoryall instance = new CustomerMailCategoryall();
                            instance._cust_id = GetValueFromReader<Int32?>(dr,0);
                            instance._mc_key = GetValueFromReader<Int32?>(dr,1);
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
		private void CreateEntity( int? cust_id, int? mc_key )
		{
			_cust_id = cust_id;
			_mc_key = mc_key;
		}
	}
}
