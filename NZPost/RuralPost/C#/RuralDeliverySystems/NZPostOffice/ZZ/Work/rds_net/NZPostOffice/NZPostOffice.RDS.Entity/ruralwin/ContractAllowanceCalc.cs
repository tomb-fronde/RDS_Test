using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  Allowances  10-Mar-2021: New
    // Entity for new vehicle_allowance_rates table

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "contract_allowance")]
	[MapInfo("contract_type", "_contract_type", "contract_type")]
	[MapInfo("alt_description", "_alt_description", "allowance_type")]
    [MapInfo("net_amount", "_net_amount", "compute_0004")]
	[MapInfo("alt_key", "_alt_key", "allowance_type")]
    [MapInfo("ca_notes", "_ca_notes", "contract_allowance")]
    [MapInfo("ca_var1", "_ca_var1", "contract_allowance")]
    [MapInfo("ca_var2", "_ca_var2", "contract_allowance")]
    [MapInfo("ca_var3", "_ca_var3", "contract_allowance")]
    [MapInfo("ca_var4", "_ca_var4", "contract_allowance")]
    [System.Serializable()]

	public class ContractAllowanceCalc : Entity<ContractAllowanceCalc>
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

        [DBField()]
        private string _ca_notes;

		[DBField()]
		private int?  _ca_var1;

        [DBField()]
        private int? _ca_var2;

        [DBField()]
        private decimal? _ca_var3;

        [DBField()]
        private decimal? _ca_var4;


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

        public virtual string CaNotes
        {
            get
            {
                CanReadProperty("CaNotes", true);
                return _ca_notes;
            }
            set
            {
                CanWriteProperty("CaNotes", true);
                if (_ca_notes != value)
                {
                    _ca_notes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CaVar1
        {
            get
            {
                CanReadProperty("CaVar1", true);
                return _ca_var1;
            }
            set
            {
                CanWriteProperty("CaVar1", true);
                if (_ca_var1 != value)
                {
                    _ca_var1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CaVar2
        {
            get
            {
                CanReadProperty("CaVar2", true);
                return _ca_var2;
            }
            set
            {
                CanWriteProperty("CaVar2", true);
                if (_ca_var2 != value)
                {
                    _ca_var2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CaVar3
        {
            get
            {
                CanReadProperty("CaVar3", true);
                return _ca_var3;
            }
            set
            {
                CanWriteProperty("CaVar3", true);
                if (_ca_var3 != value)
                {
                    _ca_var3 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CaVar4
        {
            get
            {
                CanReadProperty("CaVar4", true);
                return _ca_var4;
            }
            set
            {
                CanWriteProperty("CaVar4", true);
                if (_ca_var4 != value)
                {
                    _ca_var4 = value;
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
		public static ContractAllowanceCalc NewContractAllowanceCalc( int? inContractNo )
		{
			return Create(inContractNo);
		}

        public static ContractAllowanceCalc[] GetAllContractAllowanceCalc(int? inContractNo)
		{
			return Fetch(inContractNo).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? inContractNo)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContractNo", inContractNo);
					
                    cm.CommandText= " SELECT contract_allowance.contract_no"
                                        + ", contract_type.contract_type" 
                                        + ", allowance_type.alt_description"
                                        + ", sum(contract_allowance.ca_annual_amount) as compute_0004" 
                                        + ", allowance_type.alt_key "
                                        + ", (select top 1 ca.ca_notes from contract_allowance ca"
                                        + "	   where ca.contract_no = contract_allowance.contract_no"
                                        + "	     and ca.alt_key = allowance_type.alt_key"
                                        + "	   order by ca.ca_effective_date desc)"
                                        + ", contract_allowance.ca_var1"
                                        + ", contract_allowance.ca_var2"
                                        + ", contract_allowance.ca_var3"
                                        + ", contract_allowance.ca_var4"
                                     + "FROM rd.contract_allowance" 
                                        + ", rd.allowance_type" 
                                        + ", rd.types_for_contract" 
                                        + ", rd.contract_type "
                                    + "WHERE allowance_type.alt_key = contract_allowance.alt_key " 
                                      + "and contract_allowance.contract_no = types_for_contract.contract_no " 
                                      + "and contract_type.ct_key = types_for_contract.ct_key " 
                                      + "and contract_allowance.contract_no = @inContractNo "
                                    + "GROUP BY contract_allowance.contract_no " 
                                        + ", contract_type.contract_type"
                                        + ", allowance_type.alt_description" 
                                        + ", allowance_type.alt_key "
                                    + "ORDER BY contract_allowance.contract_no ASC " 
                                           + ", contract_type.contract_type    ASC "
                                           + ", allowance_type.alt_description ASC"
                                    ;

					List<ContractAllowanceCalc> _list = new List<ContractAllowanceCalc>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractAllowanceCalc instance = new ContractAllowanceCalc();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_type = GetValueFromReader<string>(dr,1);
                            instance._alt_description = GetValueFromReader<string>(dr,2);
                            instance._net_amount = GetValueFromReader<decimal?>(dr,3);
                            instance._alt_key = GetValueFromReader<int?>(dr, 4);
                            instance._ca_notes = GetValueFromReader<string>(dr, 5);
                            instance._ca_var1 = GetValueFromReader<int?>(dr, 6);
                            instance._ca_var2 = GetValueFromReader<int?>(dr, 7);
                            instance._ca_var3 = GetValueFromReader<decimal?>(dr, 8);
                            instance._ca_var4 = GetValueFromReader<decimal?>(dr, 9);

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
