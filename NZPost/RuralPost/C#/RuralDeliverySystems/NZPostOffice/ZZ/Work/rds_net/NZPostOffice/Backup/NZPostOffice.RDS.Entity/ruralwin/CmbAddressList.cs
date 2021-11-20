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
	[MapInfo("tc_name", "_tc_name", "towncity")]
	[MapInfo("post_code", "_post_code", "post_code")]
	[MapInfo("adr_rd_no", "_adr_rd_no", "cmb_address")]
	[System.Serializable()]

	public class CmbAddressList : Entity<CmbAddressList>
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
		private string  _tc_name;

		[DBField()]
		private string  _post_code;

		[DBField()]
		private string  _adr_rd_no;


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

		public virtual string TcName
		{
			get
			{
                CanReadProperty("TcName", true);
				return _tc_name;
			}
			set
			{
                CanWriteProperty("TcName", true);
				if ( _tc_name != value )
				{
					_tc_name = value;
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

		public virtual string AdrRdNo
		{
			get
			{
                CanReadProperty("AdrRdNo", true);
				return _adr_rd_no;
			}
			set
			{
                CanWriteProperty("AdrRdNo", true);
				if ( _adr_rd_no != value )
				{
					_adr_rd_no = value;
					PropertyHasChanged();
				}
			}
		}
		
        // compute control name=[compute_1]
		//if( isNull( cmb_cust_surname ), '', cmb_cust_surname ) + if( (isNull( cmb_cust_initials ) or cmb_cust_initials = ''), '', if( (isnull( cmb_cust_surname ) or cmb_cust_surname = ''),  cmb_cust_initials, ', '+cmb_cust_initials ))
        public virtual string Compute1
        {
            get
            {
                CanReadProperty(true);
                return _cmb_cust_surname == null ? "" : _cmb_cust_surname + ((_cmb_cust_initials == null || _cmb_cust_initials == "") ? "" : ((_cmb_cust_surname == null || _cmb_cust_surname == "") ? _cmb_cust_initials : ", " + _cmb_cust_initials));
            }
        }

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _cmb_id );
		}
		#endregion

		#region Factory Methods
		public static CmbAddressList NewCmbAddressList( int? in_contract_no )
		{
			return Create(in_contract_no);
		}

		public static CmbAddressList[] GetAllCmbAddressList( int? in_contract_no )
		{
			return Fetch(in_contract_no).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_contract_no )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_contract_no", in_contract_no);

                    cm.CommandText = "SELECT cmb_address.cmb_id, cmb_address.contract_no, cmb_address.cmb_box_no," 
                                   +        "cmb_address.tc_id, cmb_address.post_code_id, cmb_address.cmb_cust_surname," 
                                   +        "cmb_address.cmb_cust_initials, towncity.tc_name, post_code.post_code," 
                                   +        "cmb_address.adr_rd_no " 
                                   +   "FROM rd.cmb_address, rd.towncity, rd.post_code "
                                   +  "WHERE towncity.tc_id = cmb_address.tc_id "
                                   +    "AND post_code.post_code_id = cmb_address.post_code_id "
                                   +    "AND cmb_address.contract_no = @in_contract_no "
                                   +  "ORDER BY towncity.tc_name ASC, cmb_address.adr_rd_no ASC, cmb_address.cmb_box_no ASC";
  
					List<CmbAddressList> _list = new List<CmbAddressList>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CmbAddressList instance = new CmbAddressList();
                            instance._cmb_id = GetValueFromReader<int?>(dr,0);
                            instance._contract_no = GetValueFromReader<int?>(dr,1);
                            instance._cmb_box_no = GetValueFromReader<string>(dr,2);
                            instance._tc_id = GetValueFromReader<int?>(dr,3);
                            instance._post_code_id = GetValueFromReader<int?>(dr,4);
                            instance._cmb_cust_surname = GetValueFromReader<string>(dr,5);
                            instance._cmb_cust_initials = GetValueFromReader<string>(dr,6);
                            instance._tc_name = GetValueFromReader<string>(dr,7);
                            instance._post_code = GetValueFromReader<string>(dr,8);
                            instance._adr_rd_no = GetValueFromReader<string>(dr,9);
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
				if (GenerateInsertCommandText(cm, "cmb_address", pList))
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
