using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_contract_no", "contract")]
	[MapInfo("con_title", "_contract_con_title", "contract")]
	[MapInfo("c_surname_company", "_contractor_c_surname_company", "contractor")]
	[MapInfo("c_address", "_contractor_c_address", "contractor")]
	[System.Serializable()]

	public class Od : Entity<Od>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_contract_no;

		[DBField()]
		private string  _contract_con_title;

		[DBField()]
		private string  _contractor_c_surname_company;

		[DBField()]
		private string  _contractor_c_address;


		public virtual int? ContractContractNo
		{
			get
			{
                CanReadProperty("ContractContractNo", true);
				return _contract_contract_no;
			}
			set
			{
                CanWriteProperty("ContractContractNo", true);
				if ( _contract_contract_no != value )
				{
					_contract_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractConTitle
		{
			get
			{
                CanReadProperty("ContractConTitle", true);
				return _contract_con_title;
			}
			set
			{
                CanWriteProperty("ContractConTitle", true);
				if ( _contract_con_title != value )
				{
					_contract_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCSurnameCompany
		{
			get
			{
                CanReadProperty("ContractorCSurnameCompany", true);
				return _contractor_c_surname_company;
			}
			set
			{
                CanWriteProperty("ContractorCSurnameCompany", true);
				if ( _contractor_c_surname_company != value )
				{
					_contractor_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCAddress
		{
			get
			{
                CanReadProperty("ContractorCAddress", true);
				return _contractor_c_address;
			}
			set
			{
                CanWriteProperty("ContractorCAddress", true);
				if ( _contractor_c_address != value )
				{
					_contractor_c_address = value;
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
		public static Od NewOd(  )
		{
			return Create();
		}

		public static Od[] GetAllOd(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					cm.CommandText = "SELECT DISTINCT contract.contract_no, contract.con_title, contractor.c_surname_company, contractor.c_address FROM contract, contract_renewals, contractor, contractor_renewals WHERE ( contract.contract_no = contract_renewals.contract_no ) and ( contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no ) and ( contract_renewals.contract_no = contractor_renewals.contract_no ) and ( contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number ) and (contractor_renewals.cr_effective_date = (select max(cr_effective_date) from contractor_renewals cr where cr.contract_no = contract.contract_no and cr.contract_seq_number = contract_renewals.contract_seq_number) ) ORDER BY contract.contract_no ASC, contractor.c_surname_company ASC ";
					ParameterCollection pList = new ParameterCollection();

					List<Od> _list = new List<Od>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Od instance = new Od();
                            instance._contract_contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_con_title = GetValueFromReader<string>(dr,1);
                            instance._contractor_c_surname_company = GetValueFromReader<string>(dr,2);
                            instance._contractor_c_address = GetValueFromReader<string>(dr,3);
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
