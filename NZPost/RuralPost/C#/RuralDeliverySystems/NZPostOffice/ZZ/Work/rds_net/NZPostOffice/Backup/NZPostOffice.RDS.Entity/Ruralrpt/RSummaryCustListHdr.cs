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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("con_rd_ref_text", "_con_rd_ref_text", "")]
	[MapInfo("c_title", "_c_title", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("c_initials", "_c_initials", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("rgn_name", "_rgn_name", "")]
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
	[MapInfo("sf_description", "_sf_description", "")]
	[System.Serializable()]

	public class SummaryCustListHdr : Entity<SummaryCustListHdr>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _con_rd_ref_text;

		[DBField()]
		private string  _c_title;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private string  _o_name;

		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private string  _sf_description;


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

		public virtual int? ContractSeqNumber
		{
			get
			{
                CanReadProperty("ContractSeqNumber", true);
				return _contract_seq_number;
			}
			set
			{
                CanWriteProperty("ContractSeqNumber", true);
				if ( _contract_seq_number != value )
				{
					_contract_seq_number = value;
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

		public virtual string ConRdRefText
		{
			get
			{
                CanReadProperty("ConRdRefText", true);
				return _con_rd_ref_text;
			}
			set
			{
                CanWriteProperty("ConRdRefText", true);
				if ( _con_rd_ref_text != value )
				{
					_con_rd_ref_text = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual string RgnName
		{
			get
			{
                CanReadProperty("RgnName", true);
				return _rgn_name;
			}
			set
			{
                CanWriteProperty("RgnName", true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
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

		public virtual string SfDescription
		{
			get
			{
                CanReadProperty("SfDescription", true);
				return _sf_description;
			}
			set
			{
                CanWriteProperty("SfDescription", true);
				if ( _sf_description != value )
				{
					_sf_description = value;
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
		public static SummaryCustListHdr NewSummaryCustListHdr( int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder )
		{
			return Create(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder);
		}

		public static SummaryCustListHdr[] GetAllSummaryCustListHdr( int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder )
		{
			return Fetch(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_summary_cust_list_hdr";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_contract_no", in_contract_no);
					pList.Add(cm, "in_sf_key", in_sf_key);
					pList.Add(cm, "in_rd_del_days", in_rd_del_days);
					pList.Add(cm, "in_sortorder", in_sortorder);

					List<SummaryCustListHdr> _list = new List<SummaryCustListHdr>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							SummaryCustListHdr instance = new SummaryCustListHdr();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,1);
                            instance._con_title = GetValueFromReader<string>(dr,2);
                            instance._con_rd_ref_text = GetValueFromReader<string>(dr,3);
                            instance._c_title = GetValueFromReader<string>(dr,4);
                            instance._c_surname_company = GetValueFromReader<string>(dr,5);
                            instance._c_first_names = GetValueFromReader<string>(dr,6);
                            instance._c_initials = GetValueFromReader<string>(dr,7);
                            instance._o_name = GetValueFromReader<string>(dr,8);
                            instance._rgn_name = GetValueFromReader<string>(dr,9);
                            instance._sf_key = GetValueFromReader<int?>(dr,10);
                            instance._rf_delivery_days = GetValueFromReader<string>(dr,11);
                            instance._sf_description = GetValueFromReader<string>(dr,12);
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
