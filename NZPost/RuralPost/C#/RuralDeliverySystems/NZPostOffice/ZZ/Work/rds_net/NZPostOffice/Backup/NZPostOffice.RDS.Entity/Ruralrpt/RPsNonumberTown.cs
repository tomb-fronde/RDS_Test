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
	[MapInfo("cust_name", "_cust_surname", "")]
	[MapInfo("road_name", "_road_name", "")]
	[MapInfo("locality", "_locality", "")]
	[MapInfo("towncity", "_towncity", "")]
	[MapInfo("rd_id", "_rd_id", "")]
	[MapInfo("phone_day", "_phone_day", "")]
	[MapInfo("phone_night", "_phone_night", "")]
	[MapInfo("phone_mob", "_phone_mob", "")]
	[System.Serializable()]

	public class PsNonumberTown : Entity<PsNonumberTown>
	{
		#region Business Methods
		[DBField()]
		private string  _cust_surname;

		[DBField()]
		private string  _road_name;

		[DBField()]
		private string  _locality;

		[DBField()]
		private string  _towncity;

		[DBField()]
		private string  _rd_id;

		[DBField()]
		private string  _phone_day;

		[DBField()]
		private string  _phone_night;

		[DBField()]
		private string  _phone_mob;


		public virtual string CustSurname
		{
			get
			{
                CanReadProperty("CustSurname", true);
				return _cust_surname;
			}
			set
			{
                CanWriteProperty("CustSurname", true);
				if ( _cust_surname != value )
				{
					_cust_surname = value;
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

		public virtual string Locality
		{
			get
			{
                CanReadProperty("Locality", true);
				return _locality;
			}
			set
			{
                CanWriteProperty("Locality", true);
				if ( _locality != value )
				{
					_locality = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Towncity
		{
			get
			{
                CanReadProperty("Towncity", true);
				return _towncity;
			}
			set
			{
                CanWriteProperty("Towncity", true);
				if ( _towncity != value )
				{
					_towncity = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RdId
		{
			get
			{
                CanReadProperty("RdId", true);
				return _rd_id;
			}
			set
			{
                CanWriteProperty("RdId", true);
				if ( _rd_id != value )
				{
					_rd_id = value;
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
				if ( _phone_day != value )
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
				if ( _phone_night != value )
				{
					_phone_night = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PhoneMob
		{
			get
			{
                CanReadProperty("PhoneMob", true);
				return _phone_mob;
			}
			set
			{
                CanWriteProperty("PhoneMob", true);
				if ( _phone_mob != value )
				{
					_phone_mob = value;
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
		public static PsNonumberTown NewPsNonumberTown( int? town_id )
		{
			return Create(town_id);
		}

		public static PsNonumberTown[] GetAllPsNonumberTown( int? town_id )
		{
			return Fetch(town_id).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? town_id )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_nonumber_town";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "town_id", town_id);

					List<PsNonumberTown> _list = new List<PsNonumberTown>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PsNonumberTown instance = new PsNonumberTown();
                            instance._cust_surname = GetValueFromReader<string>(dr,0);
                            instance._road_name = GetValueFromReader<string>(dr,1);
                            instance._locality = GetValueFromReader<string>(dr,2);
                            instance._towncity = GetValueFromReader<string>(dr,3);
                            instance._rd_id = GetValueFromReader<string>(dr,4);
                            instance._phone_day = GetValueFromReader<string>(dr,5);
                            instance._phone_night = GetValueFromReader<string>(dr,6);
                            instance._phone_mob = GetValueFromReader<string>(dr,7);
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
