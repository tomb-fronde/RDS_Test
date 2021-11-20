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
	[MapInfo("region_id", "_region_id", "outlet")]
	[MapInfo("outlet_id", "_outlet_id", "outlet")]
	[MapInfo("o_name", "_o_name", "outlet")]
	[MapInfo("outlet_picklist", "_outlet_picklist", "outlet")]
	[MapInfo("ct_key", "_ct_key", "contract_type")]
	[MapInfo("rg_code", "_rg_code", "renewal_group")]
	[MapInfo("sf_key", "_sf_key", "standard_frequency")]
	[MapInfo("rg_code1", "_rg_code1", "outlet")]
	[MapInfo("rg_code2", "_rg_code2", "outlet")]
	[MapInfo("mail_count_date", "_mail_count_date", "outlet")]
	[MapInfo("blankforms", "_blankforms", "outlet")]
	[MapInfo("contract_no", "_contract_no", "outlet")]
	[MapInfo("date_commenced", "_date_commenced", "outlet")]
	[System.Serializable()]

	public class ReportGenericRegOutletContcriteria : Entity<ReportGenericRegOutletContcriteria>
	{
		#region Business Methods
		[DBField()]
		private int?  _region_id;

		[DBField()]
		private int?  _outlet_id;

		[DBField()]
		private string  _o_name="<All Outlets>";

		[DBField()]
		private int?  _outlet_picklist;

		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private int?  _rg_code1;

		[DBField()]
		private int?  _rg_code2;

		[DBField()]
		private DateTime?  _mail_count_date;

		[DBField()]
		private int?  _blankforms;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private DateTime?  _date_commenced;


		public virtual int? RegionId
		{
			get
			{
                CanReadProperty("RegionId", true);
				return _region_id;
			}
			set
			{
                CanWriteProperty("RegionId", true);
				if ( _region_id != value )
				{
					_region_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? OutletId
		{
			get
			{
                CanReadProperty("OutletId", true);
				return _outlet_id;
			}
			set
			{
                CanWriteProperty("OutletId", true);
				if ( _outlet_id != value )
				{
					_outlet_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string OName
		{
			get
			{
                CanReadProperty("OName", true);
				return _o_name;
			}
			set
			{
                CanWriteProperty("OName", true);
				if ( _o_name != value )
				{
					_o_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? OutletPicklist
		{
			get
			{
                CanReadProperty("OutletPicklist", true);
				return _outlet_picklist;
			}
			set
			{
                CanWriteProperty("OutletPicklist", true);
				if ( _outlet_picklist != value )
				{
					_outlet_picklist = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CtKey
		{
			get
			{
                CanReadProperty("CtKey", true);
				return _ct_key;
			}
			set
			{
                CanWriteProperty("CtKey", true);
				if ( _ct_key != value )
				{
					_ct_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RgCode
		{
			get
			{
                CanReadProperty("RgCode", true);
				return _rg_code;
			}
			set
			{
                CanWriteProperty("RgCode", true);
				if ( _rg_code != value )
				{
					_rg_code = value;
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

		public virtual int? RgCode1
		{
			get
			{
                CanReadProperty("RgCode1", true);
				return _rg_code1;
			}
			set
			{
                CanWriteProperty("RgCode1", true);
				if ( _rg_code1 != value )
				{
					_rg_code1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RgCode2
		{
			get
			{
                CanReadProperty("RgCode2", true);
				return _rg_code2;
			}
			set
			{
                CanWriteProperty("RgCode2", true);
				if ( _rg_code2 != value )
				{
					_rg_code2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? MailCountDate
		{
			get
			{
                CanReadProperty("MailCountDate", true);
				return _mail_count_date;
			}
			set
			{
                CanWriteProperty("MailCountDate", true);
				if ( _mail_count_date != value )
				{
					_mail_count_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Blankforms
		{
			get
			{
                CanReadProperty("Blankforms", true);
				return _blankforms;
			}
			set
			{
                CanWriteProperty("Blankforms", true);
				if ( _blankforms != value )
				{
					_blankforms = value;
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

		public virtual DateTime? DateCommenced
		{
			get
			{
                CanReadProperty("DateCommenced", true);
				return _date_commenced;
			}
			set
			{
                CanWriteProperty("DateCommenced", true);
				if ( _date_commenced != value )
				{
					_date_commenced = value;
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
		public static ReportGenericRegOutletContcriteria NewReportGenericRegOutletContcriteria(  )
		{
			return Create();
		}

		public static ReportGenericRegOutletContcriteria[] GetAllReportGenericRegOutletContcriteria(  )
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
                    cm.CommandText = @"SELECT outlet.region_id,
                                            outlet.outlet_id,
                                            outlet.o_name,
                                            0 outlet_picklist,
                                            contract_type.ct_key,
                                            renewal_group.rg_code,
                                            standard_frequency.sf_key,
                                            0 rg_code1,
                                            0 rg_code2,
                                            CAST(CAST(GETDATE() AS INTEGER) AS DATETIME) mail_count_date,
                                            0 blankforms,
                                            0 contract_no,
                                            CAST(CAST(GETDATE() AS INTEGER) AS DATETIME) date_commenced
                                       FROM outlet, contract_type,renewal_group,standard_frequency  ";

					List<ReportGenericRegOutletContcriteria> _list = new List<ReportGenericRegOutletContcriteria>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ReportGenericRegOutletContcriteria instance = new ReportGenericRegOutletContcriteria();
                            instance._region_id = GetValueFromReader<Int32?>(dr,0);
                            instance._outlet_id = GetValueFromReader<Int32?>(dr,1);
                            instance._o_name = GetValueFromReader<String>(dr,2);
                            instance._outlet_picklist = GetValueFromReader<Int32?>(dr,3);
                            instance._ct_key = GetValueFromReader<Int32?>(dr,4);

                            instance._rg_code = GetValueFromReader<Int32?>(dr,5);
                            instance._sf_key = GetValueFromReader<Int32?>(dr,6);
                            instance._rg_code1 = GetValueFromReader<Int32?>(dr,7);
                            instance._rg_code2 = GetValueFromReader<Int32?>(dr,8);
                            instance._mail_count_date = GetValueFromReader<DateTime?>(dr,9);

                            instance._blankforms = GetValueFromReader<Int32?>(dr,10);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,10);
                            instance._date_commenced = GetValueFromReader<DateTime?>(dr,10);

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
