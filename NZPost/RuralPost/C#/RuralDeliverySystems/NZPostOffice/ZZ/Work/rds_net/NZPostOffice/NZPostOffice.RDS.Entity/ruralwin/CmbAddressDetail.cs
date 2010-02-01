using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("cmb_id", "_cmb_id", "cmb_address")]
	[MapInfo("contract_no", "_contract_no", "cmb_address")]
	[MapInfo("cmb_box_no", "_cmb_box_no", "cmb_address")]
	[MapInfo("tc_id", "_tc_id", "cmb_address")]
	[MapInfo("post_code_id", "_post_code_id", "cmb_address")]
	[MapInfo("cmb_cust_surname", "_cmb_cust_surname", "cmb_address")]
	[MapInfo("cmb_cust_initials", "_cmb_cust_initials", "cmb_address")]
	[MapInfo("cmb_date_added", "_cmb_date_added", "cmb_address")]
	[MapInfo("cmb_last_amended_date", "_cmb_last_amended_date", "cmb_address")]
	[MapInfo("cmb_last_amended_user", "_cmb_last_amended_user", "cmb_address")]
	[MapInfo("post_code", "_post_code", "cmb_address")]
	[MapInfo("adr_rd_no", "_rd_no", "cmb_address")]
	[System.Serializable()]

	public class CmbAddressDetail : Entity<CmbAddressDetail>
	{
		#region Business Methods
		[DBField()]
		private int?  _cmb_id;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _cmb_box_no;

		[DBField()]
		private int?  _tc_id;

		[DBField()]
		private int?  _post_code_id;

		[DBField()]
		private string  _cmb_cust_surname;

		[DBField()]
		private string  _cmb_cust_initials;

		[DBField()]
		private DateTime?  _cmb_date_added;

		[DBField()]
		private DateTime?  _cmb_last_amended_date;

		[DBField()]
		private string  _cmb_last_amended_user;

		[DBField()]
		private string  _post_code;

		[DBField()]
		private string  _rd_no;


		public virtual int? CmbId
		{
			get
			{
                CanReadProperty("CmbId", true);
				return _cmb_id;
			}
			set
			{
                CanWriteProperty("CmbId", true);
				if ( _cmb_id != value )
				{
					_cmb_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractNo
		{
			get
			{
                CanReadProperty("ContractNo", true);
				return _contract_no;
			}
			set
			{
                CanWriteProperty("ContractNo", true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CmbBoxNo
		{
			get
			{
                CanReadProperty("CmbBoxNo", true);
				return _cmb_box_no;
			}
			set
			{
                CanWriteProperty("CmbBoxNo", true);
				if ( _cmb_box_no != value )
				{
					_cmb_box_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? TcId
		{
			get
			{
                CanReadProperty("TcId", true);
				return _tc_id;
			}
			set
			{
                CanWriteProperty("TcId", true);
				if ( _tc_id != value )
				{
					_tc_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PostCodeId
		{
			get
			{
                CanReadProperty("PostCodeId", true);
				return _post_code_id;
			}
			set
			{
                CanWriteProperty("PostCodeId", true);
				if ( _post_code_id != value )
				{
					_post_code_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CmbCustSurname
		{
			get
			{
                CanReadProperty("CmbCustSurname", true);
				return _cmb_cust_surname;
			}
			set
			{
                CanWriteProperty("CmbCustSurname", true);
				if ( _cmb_cust_surname != value )
				{
					_cmb_cust_surname = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CmbCustInitials
		{
			get
			{
                CanReadProperty("CmbCustInitials", true);
				return _cmb_cust_initials;
			}
			set
			{
                CanWriteProperty("CmbCustInitials", true);
				if ( _cmb_cust_initials != value )
				{
					_cmb_cust_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CmbDateAdded
		{
			get
			{
                CanReadProperty("CmbDateAdded", true);
				return _cmb_date_added;
			}
			set
			{
                CanWriteProperty("CmbDateAdded", true);
				if ( _cmb_date_added != value )
				{
					_cmb_date_added = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CmbLastAmendedDate
		{
			get
			{
                CanReadProperty("CmbLastAmendedDate", true);
				return _cmb_last_amended_date;
			}
			set
			{
                CanWriteProperty("CmbLastAmendedDate", true);
				if ( _cmb_last_amended_date != value )
				{
					_cmb_last_amended_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CmbLastAmendedUser
		{
			get
			{
                CanReadProperty("CmbLastAmendedUser", true);
				return _cmb_last_amended_user;
			}
			set
			{
                CanWriteProperty("CmbLastAmendedUser", true);
				if ( _cmb_last_amended_user != value )
				{
					_cmb_last_amended_user = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PostCode
		{
			get
			{
                CanReadProperty("PostCode", true);
				return _post_code;
			}
			set
			{
                CanWriteProperty("PostCode", true);
				if ( _post_code != value )
				{
					_post_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdNo
		{
			get
			{
                CanReadProperty("RdNo", true);
				return _rd_no;
			}
			set
			{
                CanWriteProperty("RdNo", true);
				if ( _rd_no != value )
				{
					_rd_no = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _cmb_id );
		}
		#endregion

		#region Factory Methods
		public static CmbAddressDetail NewCmbAddressDetail( int? in_cmb_id )
		{
			return Create(in_cmb_id);
		}

		public static CmbAddressDetail[] GetAllCmbAddressDetail( int? in_cmb_id )
		{
			return Fetch(in_cmb_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_cmb_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_cmb_id", in_cmb_id);

                    cm.CommandText ="SELECT cmb_address.cmb_id,cmb_address.contract_no,cmb_address.cmb_box_no,"
                                   +       "cmb_address.tc_id,cmb_address.post_code_id,cmb_address.cmb_cust_surname,"
                                   +       "cmb_address.cmb_cust_initials,cmb_address.cmb_date_added,"
                                   +       "cmb_address.cmb_last_amended_date,cmb_address.cmb_last_amended_user," 
                                   +       "'0000' as post_code,cmb_address.adr_rd_no " 
                                   +  "FROM rd.cmb_address "
                                   + "WHERE cmb_address.cmb_id = @in_cmb_id";
					List<CmbAddressDetail> _list = new List<CmbAddressDetail>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CmbAddressDetail instance = new CmbAddressDetail();
						    instance._cmb_id = GetValueFromReader<int?>(dr,0);
                            instance._contract_no = GetValueFromReader<int?>(dr,1);
                            instance._cmb_box_no = GetValueFromReader<string>(dr,2);
                            instance._tc_id = GetValueFromReader<int?>(dr,3);
                            instance._post_code_id = GetValueFromReader<int?>(dr,4);
                            instance._cmb_cust_surname = GetValueFromReader<string>(dr,5);
                            instance._cmb_cust_initials = GetValueFromReader<string>(dr,6);
                            instance._cmb_date_added = GetValueFromReader<DateTime?>(dr,7);
                            instance._cmb_last_amended_date = GetValueFromReader<DateTime?>(dr,8);
                            instance._cmb_last_amended_user = GetValueFromReader<string>(dr,9);
                            instance._post_code = GetValueFromReader<string>(dr,10);
                            instance._rd_no = GetValueFromReader<string>(dr,11);
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
				if (GenerateUpdateCommandText(cm, "cmb_address", ref pList))
				{
					cm.CommandText += " WHERE  cmb_address.cmb_id = @cmb_id ";

					pList.Add(cm, "cmb_id", GetInitialValue("_cmb_id"));
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
                pList.Add(cm, "contract_no",ContractNo);
                pList.Add(cm, "adr_rd_no", RdNo);
                pList.Add(cm, "cmb_id", CmbId);
                pList.Add(cm, "cmb_box_no", CmbBoxNo);
                pList.Add(cm, "tc_id", TcId);
                pList.Add(cm, "post_code_id", PostCodeId);
                pList.Add(cm, "cmb_cust_surname", CmbCustSurname);
                pList.Add(cm, "cmb_cust_initials", CmbCustInitials);
                pList.Add(cm, "cmb_date_added", CmbDateAdded);
                pList.Add(cm, "cmb_last_amended_date", CmbLastAmendedDate);
                pList.Add(cm, "cmb_last_amended_user", CmbLastAmendedUser);
                cm.CommandText = "INSERT INTO cmb_address(contract_no, adr_rd_no, cmb_id, cmb_box_no, tc_id, post_code_id, cmb_cust_surname, cmb_cust_initials, cmb_date_added, cmb_last_amended_date, cmb_last_amended_user)" 
                               + " VALUES(@contract_no, @adr_rd_no, @cmb_id, @cmb_box_no, @tc_id, @post_code_id, @cmb_cust_surname, @cmb_cust_initials, @cmb_date_added, @cmb_last_amended_date, @cmb_last_amended_user) ";
				//if (GenerateInsertCommandText(cm, "cmb_address", pList))
				try
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                catch
                {}
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
					pList.Add(cm,"cmb_id", GetInitialValue("_cmb_id"));
						cm.CommandText = "DELETE FROM cmb_address WHERE " +
						"cmb_address.cmb_id = @cmb_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? cmb_id )
		{
			_cmb_id = cmb_id;
		}
	}
}
