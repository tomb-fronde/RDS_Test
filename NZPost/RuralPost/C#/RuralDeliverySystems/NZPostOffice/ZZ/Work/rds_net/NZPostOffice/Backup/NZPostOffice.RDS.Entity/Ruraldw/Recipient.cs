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
	[MapInfo("cust_surname_company", "_cust_surname_company", "rds_customer")]
	[MapInfo("cust_initials", "_cust_initials", "rds_customer")]
	[MapInfo("master_cust_id", "_master_cust_id", "rds_customer")]
	[MapInfo("cust_dir_listing_ind", "_cust_dir_listing_ind", "rds_customer")]
	[MapInfo("cust_date_commenced", "_cust_date_commenced", "rds_customer")]
	[System.Serializable()]

	public class Recipient : Entity<Recipient>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;

		[DBField()]
		private string  _cust_surname_company;

		[DBField()]
		private string  _cust_initials;

		[DBField()]
		private int?  _master_cust_id;

		[DBField()]
		private string  _cust_dir_listing_ind;

		[DBField()]
		private DateTime?  _cust_date_commenced;


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

		public virtual string CustSurnameCompany
		{
			get
			{
                CanReadProperty("CustSurnameCompany", true);
				return _cust_surname_company;
			}
			set
			{
                CanWriteProperty("CustSurnameCompany", true);
				if ( _cust_surname_company != value )
				{
					_cust_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustInitials
		{
			get
			{
                CanReadProperty("CustInitials", true);
				return _cust_initials;
			}
			set
			{
                CanWriteProperty("CustInitials", true);
				if ( _cust_initials != value )
				{
					_cust_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? MasterCustId
		{
			get
			{
                CanReadProperty("MasterCustId", true);
				return _master_cust_id;
			}
			set
			{
                CanWriteProperty("MasterCustId", true);
				if ( _master_cust_id != value )
				{
					_master_cust_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustDirListingInd
		{
			get
			{
                CanReadProperty("CustDirListingInd", true);
				return _cust_dir_listing_ind;
			}
			set
			{
                CanWriteProperty("CustDirListingInd", true);
				if ( _cust_dir_listing_ind != value )
				{
					_cust_dir_listing_ind = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CustDateCommenced
		{
			get
			{
                CanReadProperty("CustDateCommenced", true);
				return _cust_date_commenced;
			}
			set
			{
                CanWriteProperty("CustDateCommenced", true);
				if ( _cust_date_commenced != value )
				{
					_cust_date_commenced = value;
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
		public static Recipient NewRecipient( int? al_cust_id )
		{
			return Create(al_cust_id);
		}

		public static Recipient[] GetAllRecipient( int? al_cust_id )
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
                    cm.CommandText = @"SELECT rds_customer.cust_id,   
                                             rds_customer.cust_surname_company,   
                                             rds_customer.cust_initials,   
                                             rds_customer.master_cust_id,   
                                             rds_customer.cust_dir_listing_ind,   
                                             rds_customer.cust_date_commenced  
                                        FROM rds_customer  
                                       WHERE ( rds_customer.master_cust_id = @al_cust_id ) AND  
                                             ( @al_cust_id > 0 ) ";

					List<Recipient> _list = new List<Recipient>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Recipient instance = new Recipient();
                            instance._cust_id = GetValueFromReader<Int32?>(dr,0);
                            instance._cust_surname_company = GetValueFromReader<String>(dr,1);
                            instance._cust_initials = GetValueFromReader<String>(dr,2);
                            instance._master_cust_id = GetValueFromReader<Int32?>(dr,3);
                            instance._cust_dir_listing_ind = GetValueFromReader<String>(dr,4);
                            instance._cust_date_commenced = GetValueFromReader<DateTime?>(dr,5);

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
