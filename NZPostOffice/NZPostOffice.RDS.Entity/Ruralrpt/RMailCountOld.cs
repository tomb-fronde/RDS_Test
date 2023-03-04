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
	[MapInfo("rg_description", "_renewal_group_rg_description", "renewal_group")]
	[MapInfo("contract_no", "_contract_contract_no", "contract")]
	[MapInfo("con_title", "_contract_con_title", "contract")]
	[MapInfo("mail_count_date", "_mail_count_date_mail_count_date", "mail_count_date")]
	[MapInfo("name", "_cname", "contract")]
	[System.Serializable()]

	public class MailCountOld : Entity<MailCountOld>
	{
		#region Business Methods
		[DBField()]
		private string  _renewal_group_rg_description;

		[DBField()]
		private int?  _contract_contract_no;

		[DBField()]
		private string  _contract_con_title;

		[DBField()]
		private DateTime?  _mail_count_date_mail_count_date;

		[DBField()]
		private string  _cname;


		public virtual string RenewalGroupRgDescription
		{
			get
			{
                CanReadProperty("RenewalGroupRgDescription", true);
				return _renewal_group_rg_description;
			}
			set
			{
                CanWriteProperty("RenewalGroupRgDescription", true);
				if ( _renewal_group_rg_description != value )
				{
					_renewal_group_rg_description = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual DateTime? MailCountDateMailCountDate
		{
			get
			{
                CanReadProperty("MailCountDateMailCountDate", true);
				return _mail_count_date_mail_count_date;
			}
			set
			{
                CanWriteProperty("MailCountDateMailCountDate", true);
				if ( _mail_count_date_mail_count_date != value )
				{
					_mail_count_date_mail_count_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Cname
		{
			get
			{
                CanReadProperty("Cname", true);
				return _cname;
			}
			set
			{
                CanWriteProperty("Cname", true);
				if ( _cname != value )
				{
					_cname = value;
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
		public static MailCountOld NewMailCountOld( int? contract )
		{
			return Create(contract);
		}

		public static MailCountOld[] GetAllMailCountOld( int? contract )
		{
			return Fetch(contract).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contract )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT renewal_group.rg_description, contract.contract_no, contract.con_title, mail_count_date.mail_count_date, (SELECT ifnull(contractor.c_first_names ,'',contractor.c_first_names+' ')+ ifnull(contractor.c_surname_company,'',contractor.c_surname_company) name FROM contractor, contractor_renewals WHERE ( contractor.contractor_supplier_no = contractor_renewals.contractor_supplier_no ) and ((contractor_renewals.contract_no = contract_renewals.contract_no ) AND ( contractor_renewals.contract_seq_number = contract_renewals.contract_seq_number ) AND (contractor_renewals.cr_effective_date = (select max(cr.cr_effective_date) from contractor_renewals as cr                          where cr.contract_seq_number = contractor_renewals.contract_seq_number and cr.contract_no = contractor_renewals.contract_no )))) FROM contract, renewal_group, mail_count_date, contract_renewals WHERE ((contract.contract_no = :contract and :contract is not null) or (:contract is null))  AND renewal_group.rg_code = contract.rg_code AND contract.contract_no = contract_renewals.contract_no AND contract_renewals.contract_seq_number = contract.con_active_sequence";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contract", contract);

					List<MailCountOld> _list = new List<MailCountOld>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MailCountOld instance = new MailCountOld();
                            instance._renewal_group_rg_description = GetValueFromReader<string>(dr,0);
                            instance._contract_contract_no = GetValueFromReader<int?>(dr,1);
                            instance._contract_con_title = GetValueFromReader<string>(dr,2);
                            instance._mail_count_date_mail_count_date = GetValueFromReader<DateTime?>(dr,3);
                            instance._cname = GetValueFromReader<string>(dr,4);
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
