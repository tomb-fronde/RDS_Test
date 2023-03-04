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
	[MapInfo("mon", "_mon", "")]
	[MapInfo("tue", "_tue", "")]
	[MapInfo("wed", "_wed", "")]
	[MapInfo("thu", "_thu", "")]
	[MapInfo("fri", "_fri", "")]
	[MapInfo("sat", "_sat", "")]
	[MapInfo("sun", "_sun", "")]
	[System.Serializable()]

	public class DeliveryDays : Entity<DeliveryDays>
	{
		#region Business Methods
		[DBField()]
		private string  _mon="N";

		[DBField()]
        private string _tue = "N";

		[DBField()]
        private string _wed = "N";

		[DBField()]
        private string _thu = "N";

		[DBField()]
        private string _fri = "N";

		[DBField()]
        private string _sat = "N";

		[DBField()]
        private string _sun = "N";


		public virtual string Mon
		{
			get
			{
                CanReadProperty("Mon", true);
				return _mon;
			}
			set
			{
                CanWriteProperty("Mon", true);
				if ( _mon != value )
				{
					_mon = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tue
		{
			get
			{
                CanReadProperty("Tue", true);
				return _tue;
			}
			set
			{
                CanWriteProperty("Tue", true);
				if ( _tue != value )
				{
					_tue = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Wed
		{
			get
			{
                CanReadProperty("Wed", true);
				return _wed;
			}
			set
			{
                CanWriteProperty("Wed", true);
				if ( _wed != value )
				{
					_wed = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Thu
		{
			get
			{
                CanReadProperty("Thu", true);
				return _thu;
			}
			set
			{
                CanWriteProperty("Thu", true);
				if ( _thu != value )
				{
					_thu = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Fri
		{
			get
			{
                CanReadProperty("Fri", true);
				return _fri;
			}
			set
			{
                CanWriteProperty("Fri", true);
				if ( _fri != value )
				{
					_fri = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Sat
		{
			get
			{
                CanReadProperty("Sat", true);
				return _sat;
			}
			set
			{
                CanWriteProperty("Sat", true);
				if ( _sat != value )
				{
					_sat = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Sun
		{
			get
			{
                CanReadProperty("Sun", true);
				return _sun;
			}
			set
			{
                CanWriteProperty("Sun", true);
				if ( _sun != value )
				{
					_sun = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[deliverystring]
			//mon  +  tue  +  wed  +  thu  +  fri  +  sat  +  sun
        public virtual string Deliverystring
        {
            get
            {
                CanReadProperty("",true);
                return _mon + _tue + _wed + _thu + _fri + _sat + _sun;
            }
        }


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static DeliveryDays NewDeliveryDays(  )
		{
			return Create();
		}

		public static DeliveryDays[] GetAllDeliveryDays(  )
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

        //            List<DeliveryDays> _list = new List<DeliveryDays>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    DeliveryDays instance = new DeliveryDays();
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
