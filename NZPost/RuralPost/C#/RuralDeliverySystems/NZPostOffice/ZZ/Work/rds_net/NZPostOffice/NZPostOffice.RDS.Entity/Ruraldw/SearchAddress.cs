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
	[MapInfo("adr_no", "_adr_no", "address")]
	[MapInfo("adr_rd_no", "_adr_rd_no", "address")]
	[MapInfo("post_code_id", "_post_code_id", "address")]
	[MapInfo("contract_no", "_contract_no", "address")]
	[MapInfo("road_id", "_road_id", "address")]
	[MapInfo("road_name", "_road_name", "road")]
	[MapInfo("rt_id", "_rt_id", "road")]
	[MapInfo("sl_id", "_sl_id", "address")]
	[MapInfo("tc_id", "_tc_id", "address")]
	[MapInfo("adr_id", "_adr_id", "address")]
	[MapInfo("adr_no_to", "_adr_no_to", "address")]
	[MapInfo("rs_id", "_rs_id", "road")]
	[MapInfo("adr_unit", "_adr_unit", "address")]
	[MapInfo("adr_alpha", "_adr_alpha", "address")]
	[MapInfo("adr_num", "_adr_num", "address")]
	[MapInfo("dp_id", "_dp_id", "address")]
	[MapInfo("rd_contract_select", "_rd_contract_select", "address")]
	[MapInfo("sl_name", "_sl_name", "address")]
	[System.Serializable()]

	public class SearchAddress : Entity<SearchAddress>
	{
		#region Business Methods
		[DBField()]
		private string  _adr_no;

		[DBField()]
		private string  _adr_rd_no;

		[DBField()]
		private int?  _post_code_id;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _road_id;

		[DBField()]
		private string  _road_name;

		[DBField()]
		private int?  _rt_id;

		[DBField()]
		private int?  _sl_id;

		[DBField()]
		private int?  _tc_id;

		[DBField()]
		private int?  _adr_id;

		[DBField()]
		private int?  _adr_no_to;

		[DBField()]
		private int?  _rs_id;

		[DBField()]
		private string  _adr_unit;

		[DBField()]
		private string  _adr_alpha;

		[DBField()]
		private string  _adr_num;

		[DBField()]
		private int?  _dp_id;

		[DBField()]
		private int?  _rd_contract_select;

		[DBField()]
		private string  _sl_name;


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

		public virtual string AdrRdNo
		{
			get
			{
                CanReadProperty("AdrRdNo", true);
				return _adr_rd_no;
			}
			set
			{
                CanWriteProperty("AdrRdNo", true);
				if ( _adr_rd_no != value )
				{
					_adr_rd_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PostCodeId
		{
			get
			{
                CanReadProperty("PostCodeId", true);
				return _post_code_id;
			}
			set
			{
                CanWriteProperty("PostCodeId", true);
				if ( _post_code_id != value )
				{
					_post_code_id = value;
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

		public virtual int? RoadId
		{
			get
			{
                CanReadProperty("RoadId", true);
				return _road_id;
			}
			set
			{
                CanWriteProperty("RoadId", true);
				if ( _road_id != value )
				{
					_road_id = value;
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

		public virtual int? RtId
		{
			get
			{
                CanReadProperty("RtId", true);
				return _rt_id;
			}
			set
			{
                CanWriteProperty("RtId", true);
				if ( _rt_id != value )
				{
					_rt_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? SlId
		{
			get
			{
                CanReadProperty("SlId", true);
				return _sl_id;
			}
			set
			{
                CanWriteProperty("SlId", true);
				if ( _sl_id != value )
				{
					_sl_id = value;
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

		public virtual int? AdrNoTo
		{
			get
			{
                CanReadProperty("AdrNoTo", true);
				return _adr_no_to;
			}
			set
			{
                CanWriteProperty("AdrNoTo", true);
				if ( _adr_no_to != value )
				{
					_adr_no_to = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RsId
		{
			get
			{
                CanReadProperty("RsId", true);
				return _rs_id;
			}
			set
			{
                CanWriteProperty("RsId", true);
				if ( _rs_id != value )
				{
					_rs_id = value;
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

		public virtual int? DpId
		{
			get
			{
                CanReadProperty("DpId", true);
				return _dp_id;
			}
			set
			{
                CanWriteProperty("DpId", true);
				if ( _dp_id != value )
				{
					_dp_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RdContractSelect
		{
			get
			{
                CanReadProperty("RdContractSelect", true);
				return _rd_contract_select;
			}
			set
			{
                CanWriteProperty("RdContractSelect", true);
				if ( _rd_contract_select != value )
				{
					_rd_contract_select = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SlName
		{
			get
			{
                CanReadProperty("SlName", true);
				return _sl_name;
			}
			set
			{
                CanWriteProperty("SlName", true);
				if ( _sl_name != value )
				{
					_sl_name = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format("{0}", _adr_id) + " ";
		}
		#endregion

		#region Factory Methods
		public static SearchAddress NewSearchAddress(  )
		{
			return Create();
		}

		public static SearchAddress[] GetAllSearchAddress(  )
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
                    cm.CommandText = " SELECT address.adr_no,"
                                    + " address.adr_rd_no,"
                                    + " address.post_code_id,"
                                    + " address.contract_no,"
                                    + " address.road_id,"
                                    + " road.road_name,"
                                    + " road.rt_id,"
                                    + " address.sl_id,"
                                    + " address.tc_id,"
                                    + " address.adr_id,"
                                    + " null as adr_no_to,"
                                    + " road.rs_id,"
                                    + " address.adr_unit,"
                                    + " address.adr_alpha,"
                                    + " adr_num="
                                    + " case when address.adr_unit is null then '' else address.adr_unit+'/' end"
                                    + " +address.adr_no+address.adr_alpha ,"
                                    + " address.dp_id,"
                                    + " 1   as rd_contract_select"
                                    + " , ''  as sl_name"
                                    + " FROM address left outer join road on address.road_id = road.road_id"
                                    + " WHERE	address.adr_id = -1";
					ParameterCollection pList = new ParameterCollection();

					List<SearchAddress> _list = new List<SearchAddress>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							SearchAddress instance = new SearchAddress();
                            instance._adr_no = GetValueFromReader<String>(dr,0);
                            instance._adr_rd_no = GetValueFromReader<String>(dr,1);
                            instance._post_code_id = GetValueFromReader<Int32?>(dr,2);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,3);
                            instance._road_id = GetValueFromReader<Int32?>(dr,4);

                            instance._road_name = GetValueFromReader<String>(dr,5);
                            instance._rt_id = GetValueFromReader<Int32?>(dr,6);
                            instance._sl_id = GetValueFromReader<Int32?>(dr,7);
                            instance._tc_id = GetValueFromReader<Int32?>(dr,8);
                            instance._adr_id = GetValueFromReader<Int32?>(dr,9);

                            instance._adr_no_to = GetValueFromReader<Int32?>(dr,10);
                            instance._rs_id = GetValueFromReader<Int32?>(dr,11);
                            instance._adr_unit = GetValueFromReader<String>(dr,12);
                            instance._adr_alpha = GetValueFromReader<String>(dr,13);
                            instance._adr_num = GetValueFromReader<String>(dr,14);

                            instance._dp_id = GetValueFromReader<Int32?>(dr,15);
                            instance._rd_contract_select = GetValueFromReader<Int32?>(dr,16);
                            instance._sl_name = GetValueFromReader<String>(dr,17);
                            
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
