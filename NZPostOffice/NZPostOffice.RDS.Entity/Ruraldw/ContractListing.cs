using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // TJB  RPCR_122  July-2018
    // Added in_pbu_id parameter in fetch parameter list and
    // in parameters for called stored procedure.
    // Changed called stored procedure to sp_SearchForContract4

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("con_date_terminated", "_con_date_terminated", "")]
	[System.Serializable()]

	public class ContractListing : Entity<ContractListing>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private DateTime?  _con_date_terminated;


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

		public virtual string ConTitle
		{
			get
			{
                CanReadProperty("ConTitle", true);
				return _con_title;
			}
			set
			{
                CanWriteProperty("ConTitle", true);
				if ( _con_title != value )
				{
					_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? ConDateTerminated
		{
			get
			{
                CanReadProperty("ConDateTerminated", true);
				return _con_date_terminated;
			}
			set
			{
                CanWriteProperty("ConDateTerminated", true);
				if ( _con_date_terminated != value )
				{
					_con_date_terminated = value;
					PropertyHasChanged();
				}
			}
        }

        public virtual string Compute1
		{
			get
			{
                CanReadProperty("Compute1", true);                
                //return ((_con_date_terminated == null || DateTime.MinValue == _con_date_terminated) ? "" : "?);

                //PP! used CharacterCode instead of hardcoding the character as it depends on character set of the client machine
                char symbol = (char)((byte)(0xFC));

                return ((_con_date_terminated == null || DateTime.MinValue == _con_date_terminated) ? "" :
                    new string(new char[] {symbol})); 
			}
        }

        protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractListing NewContractListing( int? in_Region, int? in_Contract, string in_ContractTitle
                                     , string in_ConMSN, DateTime? in_LastServiceStart, DateTime? in_LastServiceEnd
                                     , DateTime? in_LastDelStart, DateTime? in_LastDelEnd, DateTime? in_LastWorkStart
                                     , DateTime? in_LastWorkEnd, int? in_ContractType, int? in_PbuId )
		{
			return Create(in_Region, in_Contract, in_ContractTitle, in_ConMSN, in_LastServiceStart, in_LastServiceEnd
                        , in_LastDelStart, in_LastDelEnd, in_LastWorkStart, in_LastWorkEnd, in_ContractType, in_PbuId);
		}

		public static ContractListing[] GetAllContractListing( int? in_Region, int? in_Contract, string in_ContractTitle
                                     , string in_ConMSN, DateTime? in_LastServiceStart, DateTime? in_LastServiceEnd
                                     , DateTime? in_LastDelStart, DateTime? in_LastDelEnd, DateTime? in_LastWorkStart
                                     , DateTime? in_LastWorkEnd, int? in_ContractType, int? in_PbuId )
		{
			return Fetch(in_Region, in_Contract, in_ContractTitle, in_ConMSN, in_LastServiceStart, in_LastServiceEnd
                       , in_LastDelStart, in_LastDelEnd, in_LastWorkStart, in_LastWorkEnd, in_ContractType, in_PbuId).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_Region, int? in_Contract, string in_ContractTitle
                                , string in_ConMSN, DateTime? in_LastServiceStart
                                , DateTime? in_LastServiceEnd, DateTime? in_LastDelStart
                                , DateTime? in_LastDelEnd, DateTime? in_LastWorkStart
                                , DateTime? in_LastWorkEnd, int? in_ContractType
                                , int? in_PbuId )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_SearchForContract4";

                    ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_Region", in_Region);
					pList.Add(cm, "in_Contract", in_Contract);
					pList.Add(cm, "in_ContractTitle", in_ContractTitle);
					pList.Add(cm, "in_ConMSN", in_ConMSN);
					pList.Add(cm, "in_LastServiceStart", in_LastServiceStart);
					pList.Add(cm, "in_LastServiceEnd", in_LastServiceEnd);
					pList.Add(cm, "in_LastDelStart", in_LastDelStart);
					pList.Add(cm, "in_LastDelEnd", in_LastDelEnd);
					pList.Add(cm, "in_LastWorkStart", in_LastWorkStart);
					pList.Add(cm, "in_LastWorkEnd", in_LastWorkEnd);
                    pList.Add(cm, "in_ContractType", in_ContractType);
                    pList.Add(cm, "in_PbuId", in_PbuId);

					List<ContractListing> _list = new List<ContractListing>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractListing instance = new ContractListing();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._con_title = GetValueFromReader<String>(dr,1);
                            instance._con_date_terminated = GetValueFromReader<DateTime?>(dr,2);
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
