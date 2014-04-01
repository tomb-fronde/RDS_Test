using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB RPCR_017 July-2010
    // Added column ca_approved and associated changes
    // Reformatted query strings

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("driver_no", "_driver_no", "")]
    [MapInfo("title", "_title", "")]
    [MapInfo("firstnames", "_firstnames", "")]
    [MapInfo("surname", "_surname", "")]
    [MapInfo("phone_day", "_phone_day", "")]
    [MapInfo("phone_night", "_phone_night", "")]
    [MapInfo("mobile", "_mobile", "")]
    [MapInfo("mobile2", "_mobile2", "")]
    [System.Serializable()]

	public class DuplicateDrivers : Entity<DuplicateDrivers>
	{
		#region Business Methods
		[DBField()]
		private int?  _driver_no;

        [DBField()]
        private string _title;

        [DBField()]
        private string _firstnames;

        [DBField()]
        private string _surname;

        [DBField()]
        private string _phone_day;

        [DBField()]
        private string _phone_night;

        [DBField()]
        private string _mobile;

        [DBField()]
        private string _mobile2;


		public virtual int? DriverNo
		{
			get
			{
                CanReadProperty("DriverNo", true);
                return _driver_no;
			}
			set
			{
                CanWriteProperty("DriverNo", true);
                if (_driver_no != value)
				{
                    _driver_no = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string Title
        {
            get
            {
                CanReadProperty("Title", true);
                return _title;
            }
            set
            {
                CanWriteProperty("Title", true);
                if (_title != value)
                {
                    _title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Firstnames
        {
            get
            {
                CanReadProperty("Firstnames", true);
                return _firstnames;
            }
            set
            {
                CanWriteProperty("Firstnames", true);
                if (_firstnames != value)
                {
                    _firstnames = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Surname
        {
            get
            {
                CanReadProperty("Surname", true);
                return _surname;
            }
            set
            {
                CanWriteProperty("Surname", true);
                if (_surname != value)
                {
                    _surname = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PhoneDay
        {
            get
            {
                CanReadProperty("PhoneDay", true);
                return _phone_day;
            }
            set
            {
                CanWriteProperty("PhoneDay", true);
                if (_phone_day != value)
                {
                    _phone_day = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PhoneNight
        {
            get
            {
                CanReadProperty("PhoneNight", true);
                return _phone_night;
            }
            set
            {
                CanWriteProperty("PhoneNight", true);
                if (_phone_night != value)
                {
                    _phone_night = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Mobile
        {
            get
            {
                CanReadProperty("Mobile", true);
                return _mobile;
            }
            set
            {
                CanWriteProperty("Mobile", true);
                if (_mobile != value)
                {
                    _mobile = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Mobile2
        {
            get
            {
                CanReadProperty("Mobile2", true);
                return _mobile2;
            }
            set
            {
                CanWriteProperty("Mobile2", true);
                if (_mobile2 != value)
                {
                    _mobile2 = value;
                    PropertyHasChanged();
                }
            }
        }


        protected override object GetIdValue()
		{
			return string.Format( "{0}", _driver_no );
		}
		#endregion

		#region Factory Methods
        public static DuplicateDrivers NewDuplicateDrivers(string inFirstnames, string inSurname)
		{
			return Create(inFirstnames, inSurname);
		}

		public static DuplicateDrivers[] GetAllDuplicateDrivers( string inFirstnames, string inSurname )
		{
			return Fetch(inFirstnames, inSurname).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(string inFirstnames, string inSurname)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT driver_no, "
                                        + "d_title, "
                                        + "d_first_names, "
                                        + "d_surname, "
                                        + "d_phone_day, "
                                        + "d_phone_night, "
                                        + "d_mobile, "
                                        + "d_mobile2 "
                                   + "FROM rd.driver "
                                  + "WHERE d_first_names = @Firstnames "
                                    + "and d_surname = @Surname ";
                    
                    ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "Firstnames", inFirstnames);
					pList.Add(cm, "Surname", inSurname);

                    List<DuplicateDrivers> _list = new List<DuplicateDrivers>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DuplicateDrivers instance = new DuplicateDrivers();
                            instance._driver_no = GetValueFromReader<int?>(dr,0);
                            instance._title= GetValueFromReader<string>(dr,1);
                            instance._firstnames = GetValueFromReader<string>(dr, 2);
                            instance._surname = GetValueFromReader<string>(dr, 3);
                            instance._phone_day = GetValueFromReader<string>(dr, 4);
                            instance._phone_night = GetValueFromReader<string>(dr,5);
                            instance._mobile = GetValueFromReader<string>(dr,6);
                            instance._mobile2 = GetValueFromReader<string>(dr, 7);
                            instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		[ServerMethod()]
        private void CreateEntity(string inFirstnames, string inSurname)
		{
            _firstnames = inFirstnames;
            _surname = inSurname;
		}
		#endregion
	}
}
