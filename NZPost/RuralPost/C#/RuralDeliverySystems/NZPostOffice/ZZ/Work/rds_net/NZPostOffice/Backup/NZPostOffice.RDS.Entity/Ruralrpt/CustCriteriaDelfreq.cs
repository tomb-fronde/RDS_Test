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
	[MapInfo("region_id", "_region_id_ro", "")]
	[MapInfo("outlet_id", "_outlet_id", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("outlet_picklist", "_outlet_picklist", "")]
	[MapInfo("mail_category", "_mail_category", "")]
	[MapInfo("del_days_week", "_del_days_week", "")]
	[MapInfo("del_mon", "_del_mon", "")]
	[MapInfo("del_tue", "_del_tue", "")]
	[MapInfo("de_wed", "_de_wed", "")]
	[MapInfo("del_thur", "_del_thur", "")]
	[MapInfo("del_fri", "_del_fri", "")]
	[MapInfo("del_sat", "_del_sat", "")]
	[MapInfo("del_sun", "_del_sun", "")]
	[MapInfo("del_days_condition", "_del_days_condition", "")]
	[MapInfo("directory_listing", "_directory_listing", "")]
	[MapInfo("cust_de_type", "_cust_de_type", "")]
	[MapInfo("date_start", "_date_start", "")]
	[MapInfo("date_end", "_date_end", "")]
	[MapInfo("print_recipients", "_print_recipients", "")]
	[MapInfo("sort_order", "_sort_order", "")]
	[MapInfo("customer_count", "_customer_count", "")]
	[MapInfo("recipient_count", "_recipient_count", "")]
	[MapInfo("detailed_report", "_detailed_report", "")]
	[MapInfo("random_number", "_random_number", "")]
	[MapInfo("printedon_fromdate", "_printedon_fromdate", "")]
	[MapInfo("printedon_todate", "_printedon_todate", "")]
	[MapInfo("ct_key", "_ct_key", "")]
	[MapInfo("rg_code", "_rg_code", "")]
	[MapInfo("loaded_fromdate", "_loaded_fromdate", "")]
	[MapInfo("loaded_todate", "_loaded_todate", "")]
	[MapInfo("use_printedon", "_use_printedon", "")]
	[MapInfo("updateafterprint", "_updateafterprint", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[System.Serializable()]

	public class CustCriteriaDelfreq : Entity<CustCriteriaDelfreq>
	{
		#region Business Methods
		[DBField()]
		private int?  _region_id_ro;

		[DBField()]
		private int?  _outlet_id;

		[DBField()]
		private string  _o_name = "<All Outlets>";

		[DBField()]
		private int?  _outlet_picklist;

		[DBField()]
		private string  _mail_category="A";

		[DBField()]
		private int?  _del_days_week=0;

		[DBField()]
		private string  _del_mon="N";

		[DBField()]
		private string  _del_tue="N";

		[DBField()]
        private string _de_wed = "N";

		[DBField()]
        private string _del_thur = "N";

		[DBField()]
        private string _del_fri = "N";

		[DBField()]
        private string _del_sat = "N";

		[DBField()]
        private string _del_sun = "N";

		[DBField()]
		private string  _del_days_condition="A";

		[DBField()]
        private string _directory_listing = "_";

		[DBField()]
		private string  _cust_de_type = "A";

		[DBField()]
		private DateTime?  _date_start;

		[DBField()]
		private DateTime?  _date_end = DateTime.Today;

		[DBField()]
		private string  _print_recipients="N";

		[DBField()]
        private string _sort_order = "N";

		[DBField()]
		private int?  _customer_count;

		[DBField()]
		private int?  _recipient_count;

		[DBField()]
		private string  _detailed_report = "Y";

		[DBField()]
		private int?  _random_number;

		[DBField()]
		private DateTime?  _printedon_fromdate;

		[DBField()]
		private DateTime?  _printedon_todate;

		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private DateTime?  _loaded_fromdate;

		[DBField()]
		private DateTime?  _loaded_todate;

		[DBField()]
        private string _use_printedon = "N";

		[DBField()]
        private string _updateafterprint = "N";

		[DBField()]
		private int?  _contract_no;


		public virtual int? RegionIdRo
		{
			get
			{
                CanReadProperty("RegionIdRo", true);
				return _region_id_ro;
			}
			set
			{
                CanWriteProperty("RegionIdRo", true);
				if ( _region_id_ro != value )
				{
					_region_id_ro = value;
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

		public virtual string MailCategory
		{
			get
			{
                CanReadProperty("MailCategory", true);
				return _mail_category;
			}
			set
			{
                CanWriteProperty("MailCategory", true);
				if ( _mail_category != value )
				{
					_mail_category = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? DelDaysWeek
		{
			get
			{
                CanReadProperty("DelDaysWeek", true);
				return _del_days_week;
			}
			set
			{
                CanWriteProperty("DelDaysWeek", true);
				if ( _del_days_week != value )
				{
					_del_days_week = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DelMon
		{
			get
			{
                CanReadProperty("DelMon", true);
				return _del_mon;
			}
			set
			{
                CanWriteProperty("DelMon", true);
				if ( _del_mon != value )
				{
					_del_mon = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DelTue
		{
			get
			{
                CanReadProperty("DelTue", true);
				return _del_tue;
			}
			set
			{
                CanWriteProperty("DelTue", true);
				if ( _del_tue != value )
				{
					_del_tue = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DeWed
		{
			get
			{
                CanReadProperty("DeWed", true);
				return _de_wed;
			}
			set
			{
                CanWriteProperty("DeWed", true);
				if ( _de_wed != value )
				{
					_de_wed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DelThur
		{
			get
			{
                CanReadProperty("DelThur", true);
				return _del_thur;
			}
			set
			{
                CanWriteProperty("DelThur", true);
				if ( _del_thur != value )
				{
					_del_thur = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DelFri
		{
			get
			{
                CanReadProperty("DelFri", true);
				return _del_fri;
			}
			set
			{
                CanWriteProperty("DelFri", true);
				if ( _del_fri != value )
				{
					_del_fri = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DelSat
		{
			get
			{
                CanReadProperty("DelSat", true);
				return _del_sat;
			}
			set
			{
                CanWriteProperty("DelSat", true);
				if ( _del_sat != value )
				{
					_del_sat = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DelSun
		{
			get
			{
                CanReadProperty("DelSun", true);
				return _del_sun;
			}
			set
			{
                CanWriteProperty("DelSun", true);
				if ( _del_sun != value )
				{
					_del_sun = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DelDaysCondition
		{
			get
			{
                CanReadProperty("DelDaysCondition", true);
				return _del_days_condition;
			}
			set
			{
                CanWriteProperty("DelDaysCondition", true);
				if ( _del_days_condition != value )
				{
					_del_days_condition = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DirectoryListing
		{
			get
			{
                CanReadProperty("DirectoryListing", true);
				return _directory_listing;
			}
			set
			{
                CanWriteProperty("DirectoryListing", true);
				if ( _directory_listing != value )
				{
					_directory_listing = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual bool DirectoryListing1
        {
            get
            {
                CanReadProperty("DirectoryListing1", true);
                return _directory_listing == "Y";
            }

            set
            {
                CanWriteProperty("DirectoryListing1", true);
                string new_directory_listing = value ? "Y" : "N";
                if (_directory_listing != new_directory_listing)
                {
                    _directory_listing = new_directory_listing;
                    PropertyHasChanged("DirectoryListing");
                }
            }
        }

        public virtual bool DirectoryListing2
        {
            get
            {
                CanReadProperty("DirectoryListing2", true);
                return _directory_listing == "N";
            }

            set
            {
                CanWriteProperty("DirectoryListing2", true);
                string new_directory_listing = value ? "N" : "_";
                if (_directory_listing != new_directory_listing)
                {
                    _directory_listing = new_directory_listing;
                    PropertyHasChanged("DirectoryListing");
                }
            }
        }

        public virtual bool DirectoryListing3
        {
            get
            {
                CanReadProperty("DirectoryListing3", true);
                return _directory_listing == "_";
            }

            set
            {
                CanWriteProperty("DirectoryListing3", true);
                string new_directory_listing = value ? "_" : "Y";
                if (_directory_listing != new_directory_listing)
                {
                    _directory_listing = new_directory_listing;
                    PropertyHasChanged("DirectoryListing");
                }
            }
        }

		public virtual string CustDeType
		{
			get
			{
                CanReadProperty("CustDeType", true);
				return _cust_de_type;
			}
			set
			{
                CanWriteProperty("CustDeType", true);
				if ( _cust_de_type != value )
				{
					_cust_de_type = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual bool CustDeType1
        {
            get
            {
                CanReadProperty("CustDeType1", true);
                return _cust_de_type == "A";
            }

            set
            {
                CanWriteProperty("CustDeType1", true);
                string new_cust_de_type = value ? "A" : "N";
                if (_cust_de_type != new_cust_de_type)
                {
                    _cust_de_type = new_cust_de_type;
                    PropertyHasChanged("CustDeType");
                }
            }
        }

        public virtual bool CustDeType2
        {
            get
            {
                CanReadProperty("CustDeType2", true);
                return _cust_de_type == "N";
            }

            set
            {
                CanWriteProperty("CustDeType2", true);
                string new_cust_de_type = value ? "N" : "A";
                if (_cust_de_type != new_cust_de_type)
                {
                    _cust_de_type = new_cust_de_type;
                    PropertyHasChanged("CustDeType");
                }
            }
        }
        
        public virtual DateTime? DateStart
		{
			get
			{
                CanReadProperty("DateStart", true);
                if (_date_start.GetValueOrDefault().ToShortDateString() == "01/01/0001")//--add by mkwang
                {
                    return null;
                }
                return _date_start;
			}
			set
			{
                CanWriteProperty("DateStart", true);
				if ( _date_start != value )
				{
					_date_start = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? DateEnd
		{
			get
			{
                CanReadProperty("DateEnd", true);
                if (_date_end.GetValueOrDefault().ToShortDateString() == "01/01/0001")//--add by mkwang
                {
                    return null;
                }
                return _date_end;
			}
			set
			{
                CanWriteProperty("DateEnd", true);
				if ( _date_end != value )
				{
					_date_end = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string PrintRecipients
        {
            get
            {
                CanReadProperty("PrintRecipients", true);
                return _print_recipients;
            }
            set
            {
                CanWriteProperty("PrintRecipients", true);
                if (_print_recipients != value)
                {
                    _print_recipients = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool? PrintRecipients1
        {
            get
            {
                CanReadProperty("PrintRecipients1", true);
                return GetBoolean(_print_recipients, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("PrintRecipients1", true);
                SetFromBoolean(ref _print_recipients, value, "Y", "N");
                PropertyHasChanged("PrintRecipients");
            }
        }

		public virtual string SortOrder
		{
			get
			{
                CanReadProperty("SortOrder", true);
				return _sort_order;
			}
			set
			{
                CanWriteProperty("SortOrder", true);
				if ( _sort_order != value )
				{
					_sort_order = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CustomerCount
		{
			get
			{
                CanReadProperty("CustomerCount", true);
				return _customer_count;
			}
			set
			{
                CanWriteProperty("CustomerCount", true);
				if ( _customer_count != value )
				{
					_customer_count = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RecipientCount
		{
			get
			{
                CanReadProperty("RecipientCount", true);
				return _recipient_count;
			}
			set
			{
                CanWriteProperty("RecipientCount", true);
				if ( _recipient_count != value )
				{
					_recipient_count = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string DetailedReport
		{
			get
			{
                CanReadProperty("DetailedReport", true);
				return _detailed_report;
			}
			set
			{
                CanWriteProperty("DetailedReport", true);
				if ( _detailed_report != value )
				{
					_detailed_report = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual bool DetailedReport1
        {
            get
            {
                CanReadProperty("DetailedReport1", true);
                return _detailed_report == "Y";
            }

            set
            {
                CanWriteProperty("DetailedReport1", true);
                string new_detailed_report = value ? "Y" : "N";
                if (_detailed_report != new_detailed_report)
                {
                    _detailed_report = new_detailed_report;
                    PropertyHasChanged("DetailedReport");
                }
            }
        }

        public virtual bool DetailedReport2
        {
            get
            {
                CanReadProperty("DetailedReport2", true);
                return _detailed_report == "N";
            }

            set
            {
                CanWriteProperty("DetailedReport2", true);
                string new_detailed_report = value ? "N" : "R";
                if (_detailed_report != new_detailed_report)
                {
                    _detailed_report = new_detailed_report;
                    PropertyHasChanged("DetailedReport");
                }
            }
        }

        public virtual bool DetailedReport3
        {
            get
            {
                CanReadProperty("DetailedReport3", true);
                return _detailed_report == "R";
            }

            set
            {
                CanWriteProperty("DetailedReport3", true);
                string new_detailed_report = value ? "R" : "Y";
                if (_detailed_report != new_detailed_report)
                {
                    _detailed_report = new_detailed_report;
                    PropertyHasChanged("DetailedReport");
                }
            }
        }

		public virtual int? RandomNumber
		{
			get
			{
                CanReadProperty("RandomNumber", true);
				return _random_number;
			}
			set
			{
                CanWriteProperty("RandomNumber", true);
				if ( _random_number != value )
				{
					_random_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? PrintedonFromdate
		{
			get
			{
                CanReadProperty("PrintedonFromdate", true);
                if (_printedon_fromdate.GetValueOrDefault().ToShortDateString() == "01/01/0001")//--add by mkwang
                {
                    return null;
                }
                return _printedon_fromdate;
			}
			set
			{
                CanWriteProperty("PrintedonFromdate", true);
				if ( _printedon_fromdate != value )
				{
					_printedon_fromdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? PrintedonTodate
		{
			get
			{
                CanReadProperty("PrintedonTodate", true);
                if (_printedon_todate.GetValueOrDefault().ToShortDateString() == "01/01/0001")//--add by mkwang
                {
                    return null;
                }
                return _printedon_todate;
			}
			set
			{
                CanWriteProperty("PrintedonTodate", true);
				if ( _printedon_todate != value )
				{
					_printedon_todate = value;
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

		public virtual DateTime? LoadedFromdate
		{
			get
			{
                CanReadProperty("LoadedFromdate", true);

                if (_loaded_fromdate.GetValueOrDefault().ToShortDateString() == "01/01/0001")//--add by mkwang
                {
                    return null;
                }
				return _loaded_fromdate;
			}
			set
			{
                CanWriteProperty("LoadedFromdate", true);
				if ( _loaded_fromdate != value )
				{
					_loaded_fromdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? LoadedTodate
		{
			get
			{
                CanReadProperty("LoadedTodate", true);
                if (_loaded_todate.GetValueOrDefault().ToShortDateString() == "01/01/0001")//--add by mkwang
                {
                    return null;
                }
				return _loaded_todate;
			}
			set
			{
                CanWriteProperty("LoadedTodate", true);
				if ( _loaded_todate != value )
				{
					_loaded_todate = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string UsePrintedon
        {
            get
            {
                CanReadProperty("UsePrintedon", true);
                return _use_printedon;
            }
            set
            {
                CanWriteProperty("UsePrintedon", true);
                if (_use_printedon != value)
                {
                    _use_printedon = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool? UsePrintedon1
        {
            get
            {
                CanReadProperty("UsePrintedon1", true);
                return GetBoolean(_use_printedon, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("UsePrintedon1", true);
                SetFromBoolean(ref _use_printedon, value, "Y", "N");
                PropertyHasChanged("UsePrintedon");
            }
        }

        public virtual string Updateafterprint
        {
            get
            {
                CanReadProperty("Updateafterprint", true);
                return _updateafterprint;
            }
            set
            {
                CanWriteProperty("Updateafterprint", true);
                if (_updateafterprint != value)
                {
                    _updateafterprint = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool? Updateafterprint1
        {
            get
            {
                CanReadProperty("Updateafterprint1", true);
                return GetBoolean(_updateafterprint, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Updateafterprint1", true);
                SetFromBoolean(ref _updateafterprint, value, "Y", "N");
                PropertyHasChanged("Updateafterprint");
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
			// compute control name=[st_recipient]
        public virtual string StRecipient
        {
            get
            {
                CanReadProperty("StRecipient", true);
                return "Recipients Found: " + _recipient_count.GetValueOrDefault().ToString();//'Recipients Found: ' + string(recipient_count)
            }
        }

			// needs to implement compute expression manually:
			// compute control name=[st_counter]
        public virtual string StCounter
        {
            get
            {
                CanReadProperty("StCounter", true);
                return "Customers Found: " + _customer_count.GetValueOrDefault().ToString();//'Customers Found: ' + string( customer_count )
            }
        }

		protected override object GetIdValue()
		{
            return " ";
		}
		#endregion

		#region Factory Methods
		public static CustCriteriaDelfreq NewCustCriteriaDelfreq(  )
		{
			return Create();
		}

		public static CustCriteriaDelfreq[] GetAllCustCriteriaDelfreq(  )
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

					List<CustCriteriaDelfreq> _list = new List<CustCriteriaDelfreq>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustCriteriaDelfreq instance = new CustCriteriaDelfreq();
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
