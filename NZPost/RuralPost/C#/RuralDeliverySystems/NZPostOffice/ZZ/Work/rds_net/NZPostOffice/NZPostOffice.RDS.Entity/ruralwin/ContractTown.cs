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
	[MapInfo("tc_id", "_tc_id", "v_contract_towns")]
	[MapInfo("contract_no", "_contract_no", "v_contract_towns")]
	[MapInfo("tc_name", "_tc_name", "v_contract_towns")]
	[MapInfo("post_code_id", "_post_code_id", "v_contract_towns")]
	[MapInfo("post_code", "_post_code", "v_contract_towns")]
	[System.Serializable()]

	public class ContractTown : Entity<ContractTown>
	{
		#region Business Methods
		[DBField()]
		private int?  _tc_id;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _tc_name;

		[DBField()]
		private int?  _post_code_id;

		[DBField()]
		private string  _post_code;

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

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractTown NewContractTown( int? in_contract )
		{
			return Create(in_contract);
		}

		public static ContractTown[] GetAllContractTown( int? in_contract )
		{
			return Fetch(in_contract).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_contract )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_contract", in_contract);
					cm.CommandText="SELECT v_contract_towns.tc_id, v_contract_towns.contract_no, "
                                  +       "v_contract_towns.tc_name, v_contract_towns.post_code_id, "
                                  +       "v_contract_towns.post_code " 
                                  +  "FROM v_contract_towns "
                                  + "WHERE v_contract_towns.contract_no = @in_contract ";

					List<ContractTown> _list = new List<ContractTown>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractTown instance = new ContractTown();
                            instance._tc_id = GetValueFromReader<int?>(dr,0);
                            instance._contract_no = GetValueFromReader<int?>(dr,1);
                            instance._tc_name = GetValueFromReader<string>(dr,2);
                            instance._post_code_id = GetValueFromReader<int?>(dr,3);
                            instance._post_code = GetValueFromReader<string>(dr,4);
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
