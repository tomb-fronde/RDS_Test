using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // TJB  RPCR_022  May-2011
    // Added OAddress, _o_address

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
    [MapInfo("c_address", "_c_address", "")]
    [MapInfo("c_phone_day", "_c_phone_day", "")]
	[MapInfo("con_relief_driver_name", "_con_relief_driver_name", "")]
	[MapInfo("con_relief_driver_address", "_con_relief_driver_address", "")]
	[MapInfo("con_relief_driver_home_phone", "_con_relief_driver_home_phone", "")]
	[MapInfo("con_start_date", "_con_start_date", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("lodgement", "_lodgement", "")]
	[MapInfo("usah", "_usah", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("c_initials", "_c_initials", "")]
	[MapInfo("c_title", "_c_title", "")]
	[MapInfo("rgn_rcm_manager", "_rgn_rcm_manager", "")]
	[MapInfo("c_phone_night", "_c_phone_night", "")]
	[MapInfo("c_mobile", "_c_mobile", "")]
	[MapInfo("c_email_address", "_c_email_address", "")]
	[MapInfo("c_mobile2", "_contractor_c_mobile2", "")]
	[MapInfo("c_prime_contact", "_c_prime_contact", "")]
	[MapInfo("rg_code", "_rg_code", "")]
    [MapInfo("o_address", "_o_address", "")]
    [System.Serializable()]

	public class ScheduleaSingleContract : Entity<ScheduleaSingleContract>
	{
		#region Business Methods
		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _c_address;

		[DBField()]
		private string  _c_phone_day;

		[DBField()]
		private string  _con_relief_driver_name;

		[DBField()]
		private string  _con_relief_driver_address;

		[DBField()]
		private string  _con_relief_driver_home_phone;

		[DBField()]
		private DateTime?  _con_start_date;

		[DBField()]
		private string  _o_name;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _lodgement;

		[DBField()]
		private string  _usah;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private string  _c_initials;

		[DBField()]
		private string  _c_title;

		[DBField()]
		private string  _rgn_rcm_manager;

		[DBField()]
		private string  _c_phone_night;

		[DBField()]
		private string  _c_mobile;

		[DBField()]
		private string  _c_email_address;

		[DBField()]
		private string  _contractor_c_mobile2;

		[DBField()]
		private int?  _c_prime_contact;

		[DBField()]
		private int?  _rg_code;

        [DBField()]
        private string _o_address;


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

		public virtual string CAddress
		{
			get
			{
                CanReadProperty("CAddress", true);
				return _c_address;
			}
			set
			{
                CanWriteProperty("CAddress", true);
				if ( _c_address != value )
				{
					_c_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CPhoneDay
		{
			get
			{
                CanReadProperty("CPhoneDay", true);
				return _c_phone_day;
			}
			set
			{
                CanWriteProperty("CPhoneDay", true);
				if ( _c_phone_day != value )
				{
					_c_phone_day = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConReliefDriverName
		{
			get
			{
                CanReadProperty("ConReliefDriverName", true);
				return _con_relief_driver_name;
			}
			set
			{
                CanWriteProperty("ConReliefDriverName", true);
				if ( _con_relief_driver_name != value )
				{
					_con_relief_driver_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConReliefDriverAddress
		{
			get
			{
                CanReadProperty("ConReliefDriverAddress", true);
				return _con_relief_driver_address;
			}
			set
			{
                CanWriteProperty("ConReliefDriverAddress", true);
				if ( _con_relief_driver_address != value )
				{
					_con_relief_driver_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConReliefDriverHomePhone
		{
			get
			{
                CanReadProperty("ConReliefDriverHomePhone", true);
				return _con_relief_driver_home_phone;
			}
			set
			{
                CanWriteProperty("ConReliefDriverHomePhone", true);
				if ( _con_relief_driver_home_phone != value )
				{
					_con_relief_driver_home_phone = value;
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

		public virtual string Lodgement
		{
			get
			{
                CanReadProperty("Lodgement", true);
				return _lodgement;
			}
			set
			{
                CanWriteProperty("Lodgement", true);
				if ( _lodgement != value )
				{
					_lodgement = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Usah
		{
			get
			{
                CanReadProperty("Usah", true);
				return _usah;
			}
			set
			{
                CanWriteProperty("Usah", true);
				if ( _usah != value )
				{
					_usah = value;
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

		public virtual string RgnRcmManager
		{
			get
			{
                CanReadProperty("RgnRcmManager", true);
				return _rgn_rcm_manager;
			}
			set
			{
                CanWriteProperty("RgnRcmManager", true);
				if ( _rgn_rcm_manager != value )
				{
					_rgn_rcm_manager = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CPhoneNight
		{
			get
			{
                CanReadProperty("CPhoneNight", true);
				return _c_phone_night;
			}
			set
			{
                CanWriteProperty("CPhoneNight", true);
				if ( _c_phone_night != value )
				{
					_c_phone_night = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CMobile
		{
			get
			{
                CanReadProperty("CMobile", true);
				return _c_mobile;
			}
			set
			{
                CanWriteProperty("CMobile", true);
				if ( _c_mobile != value )
				{
					_c_mobile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CEmailAddress
		{
			get
			{
                CanReadProperty("CEmailAddress", true);
				return _c_email_address;
			}
			set
			{
                CanWriteProperty("CEmailAddress", true);
				if ( _c_email_address != value )
				{
					_c_email_address = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ContractorCMobile2
		{
			get
			{
                CanReadProperty("ContractorCMobile2", true);
				return _contractor_c_mobile2;
			}
			set
			{
                CanWriteProperty("ContractorCMobile2", true);
				if ( _contractor_c_mobile2 != value )
				{
					_contractor_c_mobile2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CPrimeContact
		{
			get
			{
                CanReadProperty("CPrimeContact", true);
				return _c_prime_contact;
			}
			set
			{
                CanWriteProperty("CPrimeContact", true);
				if ( _c_prime_contact != value )
				{
					_c_prime_contact = value;
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

        public virtual string OAddress
        {
            get
            {
                CanReadProperty("OAddress", true);
                return _o_address;
            }
            set
            {
                CanWriteProperty("OAddress", true);
                if (_o_address != value)
                {
                    _o_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute1
        {
            get
            {
                CanReadProperty(true);
                return ContractNo.ToString() + "/" + ContractSeqNumber.ToString();
            }            
        }

        public virtual string Compute2
        {
            get
            {
                CanReadProperty(true);
                //if(isnull(c_first_names), if(isnull(c_initials),'',c_initials + ' '), c_first_names + ' ') + c_surname_company
                if (CFirstNames == null)
                {
                    if (CInitials == null)
                    {
                        return CSurnameCompany;
                    }
                    else
                    {
                        return CInitials + " " + CSurnameCompany;
                    }
                }
                else
                {
                    return CFirstNames + " " + CSurnameCompany;
                }
            }
        }

        public virtual string Compute3
        {
            get
            {
                CanReadProperty(true);
                //'3.1      ' + IF(ISNULL(string( con_start_date  ,'dd mmmm yyyy')),'n.a.',string( con_start_date  ,'dd mmmm yyyy'))
                if (ConStartDate == null)
                {
                    return "3.1      " + "n.a.";
                }
                else
                {
                    return "3.1      " + Convert.ToString(ConStartDate);
                }
            }
        }

        public virtual string Compute4
        {
            get
            {
                CanReadProperty(true);
                //if(  if(isnull(lodgement ),'',lodgement ) <> if(isnull(o_name),' ',o_name)  , if(isnull(lodgement),'',lodgement), '')
                string lodgement = Lodgement;
                string o_name = OName;
                if(Lodgement == null)
                    lodgement = "";
                if(OName == null)
                    o_name = " ";
                if (lodgement != o_name) {
                    if (Lodgement == null)
                        return "";
                    else
                        return Lodgement;
                }
                else{
                    return "";
                }                
            }
        }

        public virtual string Compute5
        {
            get
            {
                CanReadProperty(true);
                //if ( date(con_start_date) = date('01-11-2006') and rg_code = 2, 'Nine', 'Twelve')
                if (ConStartDate == Convert.ToDateTime("01-11-2006") && RgCode == 2)
                    return "Nine";
                else
                    return "Twelve";
            }
        }

        public virtual string Compute6
        {
            get
            {
                CanReadProperty(true);
                //string(today(),'dd/mm/yyyy hh:mm:ss')
                return Convert.ToString(DateTime.Today);
            }
        }

        public virtual string Compute7
        {
            get
            {
                CanReadProperty(true);
                //?'Page ' + page() + ' of ' + pageCount()
                return "";
            }
        }
			// needs to implement compute expression manually:
			// compute control name=[compute_1]
			/*?string(contract_no) + '/' + string(contract_seq_number)

			// needs to implement compute expression manually:
			// compute control name=[compute_2]
			if(isnull(c_first_names), if(isnull(c_initials),'',c_initials + ' '), c_first_names + ' ') + c_surname_company

			// needs to implement compute expression manually:
			// compute control name=[compute_3]
			'3.1      ' + IF(ISNULL(string( con_start_date  ,'dd mmmm yyyy')),'n.a.',string( con_start_date  ,'dd mmmm yyyy'))

			// needs to implement compute expression manually:
			// compute control name=[compute_4]
			if(  if(isnull(lodgement ),'',lodgement ) <;>; if(isnull(o_name),' ',o_name)  , if(isnull(lodgement),'',lodgement), '')

			// needs to implement compute expression manually:
			// compute control name=[compute_5]
			if ( date(con_start_date) = date('01-11-2006') and rg_code = 2, 'Nine', 'Twelve')*/


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ScheduleaSingleContract NewScheduleaSingleContract( int? inContract, int? inSequence )
		{
			return Create(inContract, inSequence);
		}

		public static ScheduleaSingleContract[] GetAllScheduleaSingleContract( int? inContract, int? inSequence )
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
                    cm.CommandText = "rd.sp_schedule_a";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);

					List<ScheduleaSingleContract> _list = new List<ScheduleaSingleContract>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ScheduleaSingleContract instance = new ScheduleaSingleContract();
                            instance._c_surname_company = GetValueFromReader<string>(dr,0);
                            instance._c_first_names = GetValueFromReader<string>(dr,1);
                            instance._c_address = GetValueFromReader<string>(dr,2);
                            instance._c_phone_day = GetValueFromReader<string>(dr,3);
                            instance._con_relief_driver_name = GetValueFromReader<string>(dr,4);
                            instance._con_relief_driver_address = GetValueFromReader<string>(dr,5);
                            instance._con_relief_driver_home_phone = GetValueFromReader<string>(dr,6);
                            instance._con_start_date = GetValueFromReader<DateTime?>(dr,7);
                            instance._o_name = GetValueFromReader<string>(dr,8);
                            instance._contract_no = GetValueFromReader<int?>(dr,9);
                            instance._con_title = GetValueFromReader<string>(dr,10);
                            instance._lodgement = GetValueFromReader<string>(dr,11);
                            instance._usah = GetValueFromReader<string>(dr,12);
                            instance._contract_seq_number = GetValueFromReader<int?>(dr,13);
                            instance._c_initials = GetValueFromReader<string>(dr,14);
                            instance._c_title = GetValueFromReader<string>(dr,15);
                            instance._rgn_rcm_manager = GetValueFromReader<string>(dr,16);
                            instance._c_phone_night = GetValueFromReader<string>(dr,17);
                            instance._c_mobile = GetValueFromReader<string>(dr,18);
                            instance._c_email_address = GetValueFromReader<string>(dr,19);
                            instance._contractor_c_mobile2 = GetValueFromReader<string>(dr,20);
                            instance._c_prime_contact = GetValueFromReader<int?>(dr,21);
                            instance._rg_code = GetValueFromReader<int?>(dr,22);
                            instance._o_address = GetValueFromReader<string>(dr, 23);
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
