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
	[MapInfo("contract_no", "_contract_no", "address")]
	[MapInfo("post_mail_town", "_mail_town", "post_code")]
	[MapInfo("tc_id", "_tc_id", "towncity")]
	[System.Serializable()]

	public class ContractMailtown : Entity<ContractMailtown>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _mail_town;

		[DBField()]
		private int?  _tc_id;


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

		public virtual string MailTown
		{
			get
			{
                CanReadProperty("MailTown", true);
				return _mail_town;
			}
			set
			{
                CanWriteProperty("MailTown", true);
				if ( _mail_town != value )
				{
					_mail_town = value;
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

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractMailtown NewContractMailtown(  )
		{
			return Create();
		}

		public static ContractMailtown[] GetAllContractMailtown(  )
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
					ParameterCollection pList = new ParameterCollection();
					cm.CommandText ="SELECT DISTINCT address.contract_no ,post_code.post_mail_town ,towncity.tc_id "
                                   +  "FROM rd.address, rd.post_code, rd.towncity "
                                   + "WHERE rd.post_code.post_code_id = rd.address.post_code_id " 
                                   +   "AND rd.post_code.post_mail_town =rd.towncity.tc_name "
                                   + "ORDER BY rd.address.contract_no ASC, rd.post_code.post_mail_town ASC";

					List<ContractMailtown> _list = new List<ContractMailtown>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractMailtown instance = new ContractMailtown();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._mail_town = GetValueFromReader<string>(dr,1);
                            instance._tc_id = GetValueFromReader<int?>(dr,2);
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
