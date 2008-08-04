using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralmailmerge
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "contract")]
	[MapInfo("con_title", "_con_title", "contract")]
	[MapInfo("con_active_sequence", "_con_active_sequence", "contract")]
	[System.Serializable()]

	public class MailmergeDownloadSearchResults : Entity<MailmergeDownloadSearchResults>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private int?  _con_active_sequence;


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

		public virtual int? ConActiveSequence
		{
			get
			{
                CanReadProperty("ConActiveSequence", true);
				return _con_active_sequence;
			}
			set
			{
                CanWriteProperty("ConActiveSequence", true);
				if ( _con_active_sequence != value )
				{
					_con_active_sequence = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual string Compute1
        { 
            get
            {
                CanWriteProperty("Compute1", true);
                if (_contract_no == null)
                {
                    return null;
                }
                return _contract_no.ToString() +"/"+ Convert.ToString(_con_active_sequence == null ? 0 : _con_active_sequence);
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static MailmergeDownloadSearchResults NewMailmergeDownloadSearchResults(  )
		{
			return Create();
		}

		public static MailmergeDownloadSearchResults[] GetAllMailmergeDownloadSearchResults()
		{
			return Fetch().list;
		}

        public static MailmergeDownloadSearchResults[] GetAllMailmergeDownloadSearchResultsList(string str_sql)
        {

            return Fetch(str_sql).list;
        }
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity()
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    cm.CommandText = @"  SELECT DISTINCT contract.contract_no,   
                                                         contract.con_title,   
                                                         contract.con_active_sequence  
                                                    FROM contract  
                                                   WHERE contract.con_date_terminated is null";
                    
					List<MailmergeDownloadSearchResults> _list = new List<MailmergeDownloadSearchResults>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MailmergeDownloadSearchResults instance = new MailmergeDownloadSearchResults();
                            instance._contract_no = GetValueFromReader<Int32?>(dr,0);
                            instance._con_title = GetValueFromReader<String>(dr,1);
                            instance._con_active_sequence = GetValueFromReader<Int32?>(dr,2);

							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

        [ServerMethod]
        private void FetchEntity(string str_sql)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;

                    cm.CommandText = str_sql;
                    ParameterCollection pList = new ParameterCollection();

                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        List<MailmergeDownloadSearchResults> _list = new List<MailmergeDownloadSearchResults>();
                        while (dr.Read())
                        {
                            MailmergeDownloadSearchResults be = new MailmergeDownloadSearchResults();
                            be.StoreFieldValues(dr, "contract");
                            be.MarkOld();
                            //be.StoreFieldValues(dr, "ep_na_company");
                            _list.Add(be);
                        }
                        list = new MailmergeDownloadSearchResults[_list.Count];
                        _list.CopyTo(list);
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
