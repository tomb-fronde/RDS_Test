using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("adr_id", "_adr_id", "address")]
	[MapInfo("adr_num", "_adr_num", "address")]
	[MapInfo("adr_alpha", "_adr_alpha", "address")]
	[MapInfo("adr_num_alpha", "_adr_num_alpha", "address")]
	[MapInfo("road_name", "_road_name", "address")]
	[MapInfo("customer", "_customer", "address")]
	[MapInfo("seq_num", "_seq_num", "address")]
	[MapInfo("sequence", "_sequence", "address")]
	[MapInfo("road_name_id", "_road_name_id", "address")]
	[MapInfo("adr_unit", "_adr_unit", "address")]
	[MapInfo("adr_no", "_adr_no", "address")]
	[MapInfo("sf_key", "_sf_key", "address")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "address")]
	[MapInfo("contract_no", "_contract_no", "address")]
	[System.Serializable()]

	public class UnseqAddresses : Entity<UnseqAddresses>
	{
		#region Business Methods
		[DBField()]
		private int?  _adr_id;

		[DBField()]
		private string  _adr_num;

		[DBField()]
		private string  _adr_alpha;

		[DBField()]
		private string  _adr_num_alpha;

		[DBField()]
		private string  _road_name;

		[DBField()]
		private string  _customer;

		[DBField()]
		private int?  _seq_num;

		[DBField()]
		private int?  _sequence;

		[DBField()]
		private int?  _road_name_id;

		[DBField()]
		private string  _adr_unit;

		[DBField()]
		private string  _adr_no;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private int?  _contract_no;


		public virtual int? AdrId
		{
			get
			{
                CanReadProperty("AdrId", true);
				return _adr_id;
			}
			set
			{
                CanWriteProperty("AdrId", true);
				if ( _adr_id != value )
				{
					_adr_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AdrNum
		{
			get
			{
                CanReadProperty("AdrNum", true);
				return _adr_num;
			}
			set
			{
                CanWriteProperty("AdrNum", true);
				if ( _adr_num != value )
				{
					_adr_num = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AdrAlpha
		{
			get
			{
                CanReadProperty("AdrAlpha", true);
				return _adr_alpha;
			}
			set
			{
                CanWriteProperty("AdrAlpha", true);
				if ( _adr_alpha != value )
				{
					_adr_alpha = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AdrNumAlpha
		{
			get
			{
                CanReadProperty("AdrNumAlpha", true);
				return _adr_num_alpha;
			}
			set
			{
                CanWriteProperty("AdrNumAlpha", true);
				if ( _adr_num_alpha != value )
				{
					_adr_num_alpha = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RoadName
		{
			get
			{
                CanReadProperty("RoadName", true);
				return _road_name;
			}
			set
			{
                CanWriteProperty("RoadName", true);
				if ( _road_name != value )
				{
					_road_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Customer
		{
			get
			{
                CanReadProperty("Customer", true);
				return _customer;
			}
			set
			{
                CanWriteProperty("Customer", true);
				if ( _customer != value )
				{
					_customer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SeqNum
		{
			get
			{
                CanReadProperty("SeqNum", true);
				return _seq_num;
			}
			set
			{
                CanWriteProperty("SeqNum", true);
				if ( _seq_num != value )
				{
					_seq_num = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Sequence
		{
			get
			{
                CanReadProperty("Sequence", true);
				return _sequence;
			}
			set
			{
                CanWriteProperty("Sequence", true);
				if ( _sequence != value )
				{
					_sequence = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RoadNameId
		{
			get
			{
                CanReadProperty("RoadNameId", true);
				return _road_name_id;
			}
			set
			{
                CanWriteProperty("RoadNameId", true);
				if ( _road_name_id != value )
				{
					_road_name_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AdrUnit
		{
			get
			{
                CanReadProperty("AdrUnit", true);
				return _adr_unit;
			}
			set
			{
                CanWriteProperty("AdrUnit", true);
				if ( _adr_unit != value )
				{
					_adr_unit = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AdrNo
		{
			get
			{
                CanReadProperty("AdrNo", true);
				return _adr_no;
			}
			set
			{
                CanWriteProperty("AdrNo", true);
				if ( _adr_no != value )
				{
					_adr_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SfKey
		{
			get
			{
                CanReadProperty("SfKey", true);
				return _sf_key;
			}
			set
			{
                CanWriteProperty("SfKey", true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfDeliveryDays
		{
			get
			{
                CanReadProperty("RfDeliveryDays", true);
				return _rf_delivery_days;
			}
			set
			{
                CanWriteProperty("RfDeliveryDays", true);
				if ( _rf_delivery_days != value )
				{
					_rf_delivery_days = value;
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
			// needs to implement compute expression manually:
			// compute control name=[adr_no_numeric]
			//?if(isNumber(adr_no), integer(adr_no), 0)
        public virtual int? AdrNoNumeric
        {
            get
            {
                CanReadProperty("AdrNoNumeric", true);
               int li_temp;
               if (_adr_no == null)
               {
                   return null;
               }
               else
               {
                   return (int.TryParse(_adr_no, out li_temp) ? System.Convert.ToInt32(_adr_no) : (_adr_no.IndexOf('-') > 0 ? System.Convert.ToInt32(_adr_no.Substring(_adr_no.IndexOf('-') + 1)) : 0));
               }
            }
            set { }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static UnseqAddresses NewUnseqAddresses( int? al_contract_no, int? al_sf_key, string as_rf_delivery_days )
		{
			return Create(al_contract_no, al_sf_key, as_rf_delivery_days);
		}

		public static UnseqAddresses[] GetAllUnseqAddresses( int? al_contract_no, int? al_sf_key, string as_rf_delivery_days )
		{
			return Fetch(al_contract_no, al_sf_key, as_rf_delivery_days).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? al_contract_no, int? al_sf_key, string as_rf_delivery_days )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandTimeout = 120;
                    cm.CommandText = "SELECT address.adr_id as adr_id, " +
                        "case when isNull(address.adr_unit,'') = '' then '' else address.adr_unit+'/' end + address.adr_no as adr_num,  " +
                        "address.adr_alpha as adr_alpha,  " +
                        "case when isNull(address.adr_unit,'') = '' then '' else address.adr_unit+'/' end + address.adr_no + isnull(address.adr_alpha, '') as adr_num_alpha,  " +
                        "road.road_name + (case when isnull(road_type.rt_name,'') = '' then '' else ' '+road_type.rt_name end) + (case when isnull(road_suffix.rs_name,'') = '' then '' else ' '+road_suffix.rs_name end )as road_name,  " +
                        "max(case when isnull(cust_initials,'') = '' then rds_customer.cust_surname_company else rds_customer.cust_surname_company+', '+cust_initials end) as customer,   " +
                        "0 as seq_num, " +
                        "null as sequence, " +
                        "0 as road_name_id,  " +
                        "address.adr_unit as adr_unit,  " +
                        "address.adr_no as adr_no, " +
                        "@al_sf_key as sf_key, " +
                        "@as_rf_delivery_days as rf_delivery_days, " +
                        "@al_contract_no as contract_no  " +
                        "FROM address  LEFT OUTER JOIN address_frequency_sequence  ON  address.adr_id = address_frequency_sequence.adr_id AND address_frequency_sequence.rf_delivery_days = @as_rf_delivery_days AND address_frequency_sequence.sf_key = @al_sf_key " +
                        "LEFT OUTER JOIN road  ON  address.road_id = road.road_id   " +
                        "LEFT OUTER JOIN road_type  ON  road_type.rt_id = road.rt_id   " +
                        "LEFT OUTER JOIN road_suffix  ON  road_suffix.rs_id = road.rs_id   " +
                        "LEFT OUTER JOIN customer_address_moves  ON  customer_address_moves.adr_id = address.adr_id AND customer_address_moves.move_out_date is null AND (customer_address_moves.move_in_date is null OR customer_address_moves.move_in_date  = (SELECT max(move_in_date) FROM customer_address_moves cam  WHERE cam.cust_id = customer_address_moves.cust_id )) " +
                        "LEFT OUTER JOIN rds_customer  ON rds_customer.cust_id = customer_address_moves.cust_id  AND rds_customer.master_cust_id is null " +
                        "WHERE address.contract_no = @al_contract_no  AND address_frequency_sequence.adr_id IS NULL " +
                        "GROUP BY address.adr_id, adr_unit, adr_no, adr_alpha, road.road_name + (case when isnull(road_type.rt_name,'') = '' then '' else ' '+road_type.rt_name end) + (case when isnull(road_suffix.rs_name,'') = '' then '' else ' '+road_suffix.rs_name end ),  sf_key, rf_delivery_days, seq_num"; 
					ParameterCollection pList = new ParameterCollection(); 
					pList.Add(cm, "al_contract_no", al_contract_no);
					pList.Add(cm, "al_sf_key", al_sf_key);
					pList.Add(cm, "as_rf_delivery_days", as_rf_delivery_days);

					List<UnseqAddresses> _list = new List<UnseqAddresses>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							UnseqAddresses instance = new UnseqAddresses();
                            instance._adr_id = GetValueFromReader<Int32?>(dr,0);
                            instance._adr_num = GetValueFromReader<String>(dr,1);
                            instance._adr_alpha = GetValueFromReader<String>(dr,2);
                            instance._adr_num_alpha = GetValueFromReader<String>(dr,3);
                            instance._road_name = GetValueFromReader<String>(dr,4);

                            instance._customer = GetValueFromReader<String>(dr,5);
                            instance._seq_num = GetValueFromReader<Int32?>(dr,6);
                            instance._sequence = GetValueFromReader<Int32?>(dr,7);
                            instance._road_name_id = GetValueFromReader<Int32?>(dr,8);
                            instance._adr_unit = GetValueFromReader<String>(dr,9);

                            instance._adr_no = GetValueFromReader<String>(dr,10);
                            instance._sf_key = GetValueFromReader<Int32?>(dr,11);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr,12);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,13);

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
