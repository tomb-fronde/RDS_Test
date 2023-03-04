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
	[MapInfo("contract_no", "_contract_no", "contract")]
	[MapInfo("con_title", "_con_title", "contract")]
	[MapInfo("con_active_sequence", "_con_active_sequence", "contract")]
	[System.Serializable()]

	public class MailCountSearchResults : Entity<MailCountSearchResults>
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
			// needs to implement compute expression manually:
			// compute control name=[compute_1]
		//?	string( contract_no ) + '/' + string( if( isnull( con_active_sequence ), 0, con_active_sequence ))
        public virtual string Compute1
        {
            get
            {
                CanReadProperty(true);
                if (_contract_no == 0)
                    return "";
                string str1 = _contract_no.ToString();
                string str2 = Convert.ToString(_con_active_sequence == null ? 0 : _con_active_sequence);
                return str1 + "/" + str2;
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static MailCountSearchResults NewMailCountSearchResults( int? rgroup1, int? rgroup2, int? region, int? outlet )
		{
			return Create(rgroup1, rgroup2, region, outlet);
		}

		public static MailCountSearchResults[] GetAllMailCountSearchResults( int? rgroup1, int? rgroup2, int? region, int? outlet )
		{
			return Fetch(rgroup1, rgroup2, region, outlet).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? rgroup1, int? rgroup2, int? region, int? outlet )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT DISTINCT  contract.contract_no ,"
                        +" contract.con_title ,"
                        +" contract.con_active_sequence"
                        +" FROM contract ,"
                        +" outlet"
                        +" WHERE ( contract.con_base_office = outlet.outlet_id ) and          ((contract.rg_code = :rgroup1) or          (contract.rg_code = :rgroup2)) and          ((outlet.region_id = :region and          ( :region is not null) ) or          (:region is null)) and          ((outlet.outlet_id = :outlet and          ( :outlet is not null) ) or          (:outlet is null)) and          (contract.con_date_terminated is null or          ( contract.con_date_terminated >= getdate()) )";

					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "rgroup1", rgroup1);
					pList.Add(cm, "rgroup2", rgroup2);
					pList.Add(cm, "region", region);
					pList.Add(cm, "outlet", outlet);

					List<MailCountSearchResults> _list = new List<MailCountSearchResults>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MailCountSearchResults instance = new MailCountSearchResults();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._con_title = GetValueFromReader<string>(dr,1);
                            instance._con_active_sequence = GetValueFromReader<int?>(dr, 2);
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
