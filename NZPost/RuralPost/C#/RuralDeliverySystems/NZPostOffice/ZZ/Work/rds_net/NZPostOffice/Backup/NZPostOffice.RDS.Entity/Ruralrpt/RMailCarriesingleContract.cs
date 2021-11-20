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
	[MapInfo("con_start_date", "_con_start_date", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("c_initials", "_c_initials", "")]
	[MapInfo("sf_description", "_sf_description", "")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
	[MapInfo("mc_dispatch_carried", "_mc_dispatch_carried", "")]
	[MapInfo("uplift_outlet_name", "_uplift_outlet_name", "")]
	[MapInfo("mc_uplift_time", "_mc_uplift_time", "")]
	[MapInfo("set_down_outlet_namec", "_set_down_outlet_namec", "")]
	[MapInfo("mc_set_down_time", "_mc_set_down_time", "")]
	[MapInfo("rgn_name", "_rgn_name", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("con_rd_ref_text", "_con_rd_ref_text", "")]
	[System.Serializable()]

	public class MailCarriedSingleContract : Entity<MailCarriedSingleContract>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private DateTime?  _con_start_date;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private string  _sf_description;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private string  _mc_dispatch_carried;

		[DBField()]
		private string  _uplift_outlet_name;

		[DBField()]
		private string  _mc_uplift_time;

		[DBField()]
		private string  _set_down_outlet_namec;

		[DBField()]
		private  string  _mc_set_down_time;

		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private string  _o_name;

		[DBField()]
		private string  _con_rd_ref_text;


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

		public virtual DateTime? ConStartDate
		{
			get
			{
                CanReadProperty("ConStartDate", true);
				return _con_start_date;
			}
			set
			{
                CanWriteProperty("ConStartDate", true);
				if ( _con_start_date != value )
				{
					_con_start_date = value;
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

		public virtual string McDispatchCarried
		{
			get
			{
                CanReadProperty("McDispatchCarried", true);
				return _mc_dispatch_carried;
			}
			set
			{
                CanWriteProperty("McDispatchCarried", true);
				if ( _mc_dispatch_carried != value )
				{
					_mc_dispatch_carried = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string UpliftOutletName
		{
			get
			{
                CanReadProperty("UpliftOutletName", true);
				return _uplift_outlet_name;
			}
			set
			{
                CanWriteProperty("UpliftOutletName", true);
				if ( _uplift_outlet_name != value )
				{
					_uplift_outlet_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string McUpliftTime
		{
			get
			{
                CanReadProperty("McUpliftTime", true);
				return _mc_uplift_time;
			}
			set
			{
                CanWriteProperty("McUpliftTime", true);
				if ( _mc_uplift_time != value )
				{
					_mc_uplift_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string SetDownOutletNamec
		{
			get
			{
                CanReadProperty("SetDownOutletNamec", true);
				return _set_down_outlet_namec;
			}
			set
			{
                CanWriteProperty("SetDownOutletNamec", true);
				if ( _set_down_outlet_namec != value )
				{
					_set_down_outlet_namec = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string McSetDownTime
		{
			get
			{
                CanReadProperty("McSetDownTime", true);
				return _mc_set_down_time;
			}
			set
			{
                CanWriteProperty("McSetDownTime", true);
				if ( _mc_set_down_time != value )
				{
					_mc_set_down_time = value;
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

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static MailCarriedSingleContract NewMailCarriedSingleContract( int? inContract, int? inSequence )
		{
			return Create(inContract, inSequence);
		}

		public static MailCarriedSingleContract[] GetAllMailCarriedSingleContract( int? inContract, int? inSequence )
		{
			return Fetch(inContract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_RptMailCarried";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);

					List<MailCarriedSingleContract> _list = new List<MailCarriedSingleContract>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MailCarriedSingleContract instance = new MailCarriedSingleContract();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,1);
                            instance._con_title = GetValueFromReader<string>(dr,2);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr,3);
                            instance._c_surname_company = GetValueFromReader<string>(dr,4);
                            instance._c_first_names = GetValueFromReader<string>(dr,5);
                            instance._c_initials = GetValueFromReader<string>(dr,6);
                            instance._sf_description = GetValueFromReader<string>(dr,7);
                            instance._rf_delivery_days = GetValueFromReader<string>(dr,8);
                            instance._mc_dispatch_carried = GetValueFromReader<string>(dr,9);
                            instance._uplift_outlet_name = GetValueFromReader<string>(dr,10);
                            instance._mc_uplift_time = GetValueFromReader<string>(dr,11);
                            instance._set_down_outlet_namec = GetValueFromReader<string>(dr,12);
                            instance._mc_set_down_time = GetValueFromReader<string>(dr,13);
                            instance._rgn_name = GetValueFromReader<string>(dr,14);
                            instance._o_name = GetValueFromReader<string>(dr,15);
                            instance._con_rd_ref_text = GetValueFromReader<string>(dr,16);
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
