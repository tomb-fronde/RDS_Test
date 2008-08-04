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
	[MapInfo("contract_no", "_contract_no", "contract_allowance")]
	[MapInfo("contract_type", "_contract_type", "contract_type")]
	[MapInfo("alt_description", "_alt_description", "allowance_type")]
    [MapInfo("net_amount", "_net_amount", "compute_0004")]
	[MapInfo("alt_key", "_alt_key", "allowance_type")]
	[System.Serializable()]

	public class ContractAllowancesV2 : Entity<ContractAllowancesV2>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _contract_type;

		[DBField()]
		private string  _alt_description;

		[DBField()]
		private decimal?  _net_amount;

		[DBField()]
		private int?  _alt_key;


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

		public virtual string ContractType
		{
			get
			{
                CanReadProperty("ContractType", true);
				return _contract_type;
			}
			set
			{
                CanWriteProperty("ContractType", true);
				if ( _contract_type != value )
				{
					_contract_type = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AltDescription
		{
			get
			{
                CanReadProperty("AltDescription", true);
				return _alt_description;
			}
			set
			{
                CanWriteProperty("AltDescription", true);
				if ( _alt_description != value )
				{
					_alt_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? NetAmount
		{
			get
			{
                CanReadProperty("NetAmount", true);
				return _net_amount;
			}
			set
			{
                CanWriteProperty("NetAmount", true);
				if ( _net_amount != value )
				{
					_net_amount = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? AltKey
		{
			get
			{
                CanReadProperty("AltKey", true);
				return _alt_key;
			}
			set
			{
                CanWriteProperty("AltKey", true);
				if ( _alt_key != value )
				{
					_alt_key = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Compute0004
        {
            get
            {
                return _net_amount;
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractAllowancesV2 NewContractAllowancesV2( int? inContractNo )
		{
			return Create(inContractNo);
		}

		public static ContractAllowancesV2[] GetAllContractAllowancesV2( int? inContractNo )
		{
			return Fetch(inContractNo).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContractNo )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContractNo", inContractNo);
					
                    cm.CommandText= " SELECT  contract_allowance.contract_no,"+
                        "contract_type.contract_type,allowance_type.alt_description,"+
                        "sum(contract_allowance.ca_annual_amount) as compute_0004,allowance_type.alt_key "+     
                        "FROM rd.contract_allowance,rd.allowance_type,rd.types_for_contract,rd.contract_type "+
                        "WHERE ( allowance_type.alt_key = contract_allowance.alt_key ) and "+
                        "( contract_allowance.contract_no = types_for_contract.contract_no ) and  "+
                        "( contract_type.ct_key = types_for_contract.ct_key ) and  "+
                        "((contract_allowance.contract_no = @inContractNo )) "+
                        " GROUP BY contract_allowance.contract_no,contract_type.contract_type,"+
                        "allowance_type.alt_description,allowance_type.alt_key  "+
                        "ORDER BY contract_allowance.contract_no ASC,"+
                        "contract_type.contract_type ASC,"+
                        "allowance_type.alt_description   ASC  ";


					List<ContractAllowancesV2> _list = new List<ContractAllowancesV2>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractAllowancesV2 instance = new ContractAllowancesV2();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_type = GetValueFromReader<string>(dr,1);
                            instance._alt_description = GetValueFromReader<string>(dr,2);
                            instance._net_amount = GetValueFromReader<decimal?>(dr,3);
                            instance._alt_key = GetValueFromReader<int?>(dr,4);

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
