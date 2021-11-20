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
	[MapInfo("c_title", "_c_title", "contractor")]
	[MapInfo("c_surname_company", "_c_surname_company", "contractor")]
	[MapInfo("c_first_names", "_c_first_names", "contractor")]
	[MapInfo("c_initials", "_c_initials", "contractor")]
	[MapInfo("c_address", "_contractor_c_address", "contractor")]
	[MapInfo("label", "_clabel", "")]
	[System.Serializable()]

	public class ContractorLabel : Entity<ContractorLabel>
	{
		#region Business Methods
		[DBField()]
		private string  _c_title;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private string  _contractor_c_address;

		[DBField()]
		private string  _clabel;


		public virtual string CTitle
		{
			get
			{
                CanReadProperty("CTitle", true);
				return _c_title;
			}
			set
			{
                CanWriteProperty("CTitle", true);
				if ( _c_title != value )
				{
					_c_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CSurnameCompany
		{
			get
			{
                CanReadProperty("CSurnameCompany", true);
				return _c_surname_company;
			}
			set
			{
                CanWriteProperty("CSurnameCompany", true);
				if ( _c_surname_company != value )
				{
					_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CFirstNames
		{
			get
			{
                CanReadProperty("CFirstNames", true);
				return _c_first_names;
			}
			set
			{
                CanWriteProperty("CFirstNames", true);
				if ( _c_first_names != value )
				{
					_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CInitials
		{
			get
			{
                CanReadProperty("CInitials", true);
				return _c_initials;
			}
			set
			{
                CanWriteProperty("CInitials", true);
				if ( _c_initials != value )
				{
					_c_initials = value;
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

		public virtual string Clabel
		{
			get
			{
                CanReadProperty("Clabel", true);
				return _clabel;
			}
			set
			{
                CanWriteProperty("Clabel", true);
				if ( _clabel != value )
				{
					_clabel = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[compute_2]
		//?	if(isnull(c_title), '', c_title + ' ') + if(isnull(c_initials), '', c_initials + ' ') + c_surname_company

			// needs to implement compute expression manually:
			// compute control name=[compute_1]
		//?	if(len( c_initials )>;0,  contractor_c_address , contractor_c_address )


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractorLabel NewContractorLabel( int? region, string contractor, int? contract_type, int? renewal_group, int? outlet, int? contract, string contractflag )
		{
			return Create(region, contractor, contract_type, renewal_group, outlet, contract, contractflag);
		}

		public static ContractorLabel[] GetAllContractorLabel( int? region, string contractor, int? contract_type, int? renewal_group, int? outlet, int? contract, string contractflag )
		{
			return Fetch(region, contractor, contract_type, renewal_group, outlet, contract, contractflag).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? region, string contractor, int? contract_type, int? renewal_group, int? outlet, int? contract, string contractflag )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					//cm.CommandText = "SELECT DISTINCT 'contractor'.'c_title',  'contractor'.'c_surname_company',  'contractor'.'c_first_names',  'contractor'.'c_initials',  'contractor'.'c_address',  'Rural Delivery Owner Driver' Label  FROM {oj 'contract_renewals'  LEFT OUTER JOIN 'contractor_renewals'  ON 'contract_renewals'.'contract_no' = 'contractor_renewals'.'contract_no'  AND 'contract_renewals'.'contract_seq_number' = 'contractor_renewals'.'contract_seq_number'  AND 'contract_renewals'.'con_date_last_assigned' = 'contractor_renewals'.'cr_effective_date'},  {oj 'contractor'  LEFT OUTER JOIN 'types_for_contractor'  ON 'contractor'.'contractor_supplier_no' = 'types_for_contractor'.'contractor_supplier_no'},  'contract',  'outlet'  WHERE contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no  and contract_renewals.contract_no = contract.contract_no  and contract_renewals.contract_seq_number = contract.con_active_sequence  and contract.con_base_office = outlet.outlet_id  and (contractor.contractor_supplier_no  = (select c.contractor_supplier_no  from contractor_renewals as c  where c.contract_no = contractor_renewals.contract_no  and c.contract_seq_number = contractor_renewals.contract_seq_number  and c.cr_effective_date  = (select max(c2.cr_effective_date)  from contractor_renewals as c2  where c2.contract_no = c.contract_no  and c2.contract_seq_number = c.contract_seq_number  and c2.cr_effective_date <;= today() )))  and ((:region is not null AND outlet.region_id = :region)  OR (:region is null))  AND ((:contractor is not null AND contractor.c_surname_company like :contractor || '%')  OR (:contractor is null))  AND ((:contract_type is not null AND types_for_contractor.ct_key = :contract_type)  OR (:contract_type is null))  AND ((:renewal_group is not null AND contract.rg_code = :renewal_group)  OR (:renewal_group is null))  AND ((:outlet is not null AND outlet.outlet_id = :outlet)  OR (:outlet is null))  AND ((:contractflag = 'Y' AND contract.contract_no in ( :contract ))  OR (:contractflag = 'N'))  AND contract.con_date_terminated is null  -- TJB  SR4692  Aug 2006  -- Added  'c2.cr_effective_date <;= today()' clause  -- NOTE:  The '||' in the contractor clause is necessary if :contractor is ever null!!!   ";
                    cm.CommandText = " SELECT DISTINCT contractor.c_title,"   
                                   + " contractor.c_surname_company,   "
                                   + " contractor.c_first_names,   "
                                   + " contractor.c_initials,   "
                                   + " contractor.c_address,   "
                                   + " 'Rural Delivery Owner Driver' Label  "
                                   + " FROM NZDB.rd.contract_renewals "
                                   + " LEFT OUTER JOIN NZDB.rd.contractor_renewals  "
                                   + " ON contract_renewals.contract_no = contractor_renewals.contract_no"
                                   + " AND contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number "
                                   + " AND contract_renewals.con_date_last_assigned = contractor_renewals.cr_effective_date"
                                   + " INNER JOIN NZDB.rd.contractor "
                                   + " ON  contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no"
                                   + " LEFT OUTER JOIN NZDB.rd.types_for_contractor  "
                                   + " ON contractor.contractor_supplier_no = types_for_contractor.contractor_supplier_no"
                                   + " INNER JOIN NZDB.rd.contract"
                                   + " ON    contract_renewals.contract_no = contract.contract_no"
                                   + " AND contract_renewals.contract_seq_number = contract.con_active_sequence"
                                   + " INNER JOIN NZDB.rd.outlet "
                                   + " ON contract.con_base_office = outlet.outlet_id"
                                   + " WHERE "
                                   + " (contractor.contractor_supplier_no =(select c.contractor_supplier_no"
                                   + " from NZDB.rd.contractor_renewals as c"
                                   + " where c.contract_no=contractor_renewals.contract_no"
                                   + " and c.contract_seq_number=contractor_renewals.contract_seq_number"
                                   + " and c.cr_effective_date=(select max(c2.cr_effective_date)"
                                   + " from NZDB.rd.contractor_renewals as c2"
                                   + " where c.contract_no=c2.contract_no"
                                   + " and c.contract_seq_number=c2.contract_seq_number))) and(contractor.contractor_supplier_no"
                                   + " =(select c.contractor_supplier_no"
                                   + " from NZDB.rd.contractor_renewals as c"
                                   + " where c.contract_no=contractor_renewals.contract_no"
                                   + " and c.contract_seq_number=contractor_renewals.contract_seq_number"
                                   + " and c.cr_effective_date=(select max(c2.cr_effective_date)"
                                   + " from NZDB.rd.contractor_renewals as c2"
                                   + " where c.contract_no=c2.contract_no"
                                   + " and c.contract_seq_number=c2.contract_seq_number))) and"
                                   + " ((outlet.region_id = :region AND  "
                                   + " :region is not null) OR  "
                                   + " (:region is null)) AND  "
                                   + " (((contractor.c_surname_company like :contractor OR contractor.c_surname_company like '%') AND  "
                                   + " :contractor is not null) OR  "
                                   + " (:contractor is null)) AND  "
                                   + " ((types_for_contractor.ct_key = :contract_type AND  "
                                   + " :contract_type is not null) OR  "
                                   + " (:contract_type is null)) AND  "
                                   + " ((contract.rg_code = :renewal_group AND  "
                                   + " :renewal_group is not null) OR  "
                                   + " (:renewal_group is null)) AND  "
                                   + " ((outlet.outlet_id = :outlet AND  "
                                   + " :outlet is not null) OR  "
                                   + " (:outlet is null)) AND  "
                                   + " ((contract.contract_no in ( :contract ) AND  "
                                   + " :contractflag = 'Y') OR  "
                                   + " (:contractflag = 'N')) AND  "
                                   + " contract.con_date_terminated is null    ";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "region", region);
					pList.Add(cm, "contractor", contractor);
					pList.Add(cm, "contract_type", contract_type);
					pList.Add(cm, "renewal_group", renewal_group);
					pList.Add(cm, "outlet", outlet);
					pList.Add(cm, "contract", contract);
					pList.Add(cm, "contractflag", contractflag);

					List<ContractorLabel> _list = new List<ContractorLabel>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractorLabel instance = new ContractorLabel();
                            instance._c_title = GetValueFromReader<string>(dr,0);
                            instance._c_surname_company = GetValueFromReader<string>(dr,1);
                            instance._c_first_names = GetValueFromReader<string>(dr,2);
                            instance._c_initials = GetValueFromReader<string>(dr,3);
                            instance._contractor_c_address = GetValueFromReader<string>(dr,4);
                            instance._clabel = GetValueFromReader<string>(dr,5);
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
