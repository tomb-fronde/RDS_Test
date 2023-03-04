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
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("rf_active", "_rf_active", "")]
	[MapInfo("rf_monday", "_rf_monday", "")]
	[MapInfo("rf_tuesday", "_rf_tuesday", "")]
	[MapInfo("rf_wednesday", "_rf_wednesday", "")]
	[MapInfo("rf_thursday", "_rf_thursday", "")]
	[MapInfo("rf_friday", "_rf_friday", "")]
	[MapInfo("rf_saturday", "_rf_saturday", "")]
	[MapInfo("rf_sunday", "_rf_sunday", "")]
	[MapInfo("rf_distance", "_rf_distance", "")]
	[System.Serializable()]

	public class WhatifFreqs : Entity<WhatifFreqs>
	{
		#region Business Methods
		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_active="N";

		[DBField()]
        private string _rf_monday = "N";

		[DBField()]
        private string _rf_tuesday = "N";

		[DBField()]
        private string _rf_wednesday = "N";

		[DBField()]
        private string _rf_thursday = "N";

		[DBField()]
        private string _rf_friday = "N";

		[DBField()]
        private string _rf_saturday = "N";

		[DBField()]
        private string _rf_sunday = "N";

		[DBField()]
		private decimal?  _rf_distance;


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

		public virtual string RfActive
		{
			get
			{
                CanReadProperty("RfActive", true);
				return _rf_active;
			}
			set
			{
                CanWriteProperty("RfActive", true);
				if ( _rf_active != value )
				{
					_rf_active = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfMonday
		{
			get
			{
                CanReadProperty("RfMonday", true);
				return _rf_monday;
			}
			set
			{
                CanWriteProperty("RfMonday", true);
				if ( _rf_monday != value )
				{
					_rf_monday = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfTuesday
		{
			get
			{
                CanReadProperty("RfTuesday", true);
				return _rf_tuesday;
			}
			set
			{
                CanWriteProperty("RfTuesday", true);
				if ( _rf_tuesday != value )
				{
					_rf_tuesday = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfWednesday
		{
			get
			{
                CanReadProperty("RfWednesday", true);
				return _rf_wednesday;
			}
			set
			{
                CanWriteProperty("RfWednesday", true);
				if ( _rf_wednesday != value )
				{
					_rf_wednesday = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfThursday
		{
			get
			{
                CanReadProperty("RfThursday", true);
				return _rf_thursday;
			}
			set
			{
                CanWriteProperty("RfThursday", true);
				if ( _rf_thursday != value )
				{
					_rf_thursday = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfFriday
		{
			get
			{
                CanReadProperty("RfFriday", true);
				return _rf_friday;
			}
			set
			{
                CanWriteProperty("RfFriday", true);
				if ( _rf_friday != value )
				{
					_rf_friday = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfSaturday
		{
			get
			{
                CanReadProperty("RfSaturday", true);
				return _rf_saturday;
			}
			set
			{
                CanWriteProperty("RfSaturday", true);
				if ( _rf_saturday != value )
				{
					_rf_saturday = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfSunday
		{
			get
			{
                CanReadProperty("RfSunday", true);
				return _rf_sunday;
			}
			set
			{
                CanWriteProperty("RfSunday", true);
				if ( _rf_sunday != value )
				{
					_rf_sunday = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? RfDistance
		{
			get
			{
                CanReadProperty("RfDistance", true);
				return _rf_distance;
			}
			set
			{
                CanWriteProperty("RfDistance", true);
				if ( _rf_distance != value )
				{
					_rf_distance = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[calc_deldays]
			//?if(rf_monday='Y',1,0) + if(rf_tuesday='Y',1,0) + if(rf_wednesday='Y',1,0) + if(rf_thursday='Y',1,0) + if(rf_friday='Y',1,0) + if(rf_saturday='Y',1,0) + if(rf_sunday='Y',1,0)
        public virtual int? CalcDeldays
        {
            get
            {
                CanReadProperty("",true);
                return (_rf_monday == "Y" ? 1 : 0) + (_rf_tuesday == "Y" ? 1 : 0) + (_rf_wednesday == "Y" ? 1 : 0) + (_rf_thursday == "Y" ? 1 : 0) + (_rf_friday == "Y" ? 1 : 0) + (_rf_saturday == "Y" ? 1 : 0) + (_rf_sunday == "Y" ? 1 : 0);
            }
        }

		protected override object GetIdValue()
		{
            return _sf_key;//return "";
		}
		#endregion

		#region Factory Methods
		public static WhatifFreqs NewWhatifFreqs(  )
		{
			return Create();
		}

		public static WhatifFreqs[] GetAllWhatifFreqs(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<WhatifFreqs> _list = new List<WhatifFreqs>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    WhatifFreqs instance = new WhatifFreqs();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
