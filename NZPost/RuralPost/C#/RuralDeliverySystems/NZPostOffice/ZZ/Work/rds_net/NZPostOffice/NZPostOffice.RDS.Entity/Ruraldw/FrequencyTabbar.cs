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
	[MapInfo("tab1", "_tab1", "")]
	[MapInfo("tab2", "_tab2", "")]
	[MapInfo("tab3", "_tab3", "")]
	[MapInfo("tab4", "_tab4", "")]
	[MapInfo("tab5", "_tab5", "")]
	[MapInfo("tab6", "_tab6", "")]
	[MapInfo("tab7", "_tab7", "")]
	[MapInfo("tab8", "_tab8", "")]
	[MapInfo("tab9", "_tab9", "")]
	[MapInfo("tab10", "_tab10", "")]
	[MapInfo("tab11", "_tab11", "")]
	[MapInfo("tab12", "_tab12", "")]
	[MapInfo("tab13", "_tab13", "")]
	[MapInfo("tab14", "_tab14", "")]
	[MapInfo("tab15", "_tab15", "")]
	[System.Serializable()]

	public class FrequencyTabbar : Entity<FrequencyTabbar>
	{
		#region Business Methods
		[DBField()]
		private string  _tab1;

		[DBField()]
		private string  _tab2;

		[DBField()]
		private string  _tab3;

		[DBField()]
		private string  _tab4;

		[DBField()]
		private string  _tab5;

		[DBField()]
		private string  _tab6;

		[DBField()]
		private string  _tab7;

		[DBField()]
		private string  _tab8;

		[DBField()]
		private string  _tab9;

		[DBField()]
		private string  _tab10;

		[DBField()]
		private string  _tab11;

		[DBField()]
		private string  _tab12;

		[DBField()]
		private string  _tab13;

		[DBField()]
		private string  _tab14;

		[DBField()]
		private string  _tab15;


		public virtual string Tab1
		{
			get
			{
                CanReadProperty("Tab1", true);
				return _tab1;
			}
			set
			{
                CanWriteProperty("Tab1", true);
				if ( _tab1 != value )
				{
					_tab1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab2
		{
			get
			{
                CanReadProperty("Tab2", true);
				return _tab2;
			}
			set
			{
                CanWriteProperty("Tab2", true);
				if ( _tab2 != value )
				{
					_tab2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab3
		{
			get
			{
                CanReadProperty("Tab3", true);
				return _tab3;
			}
			set
			{
                CanWriteProperty("Tab3", true);
				if ( _tab3 != value )
				{
					_tab3 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab4
		{
			get
			{
                CanReadProperty("Tab4", true);
				return _tab4;
			}
			set
			{
                CanWriteProperty("Tab4", true);
				if ( _tab4 != value )
				{
					_tab4 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab5
		{
			get
			{
                CanReadProperty("Tab5", true);
				return _tab5;
			}
			set
			{
                CanWriteProperty("Tab5", true);
				if ( _tab5 != value )
				{
					_tab5 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab6
		{
			get
			{
                CanReadProperty("Tab6", true);
				return _tab6;
			}
			set
			{
                CanWriteProperty("Tab6", true);
				if ( _tab6 != value )
				{
					_tab6 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab7
		{
			get
			{
                CanReadProperty("Tab7", true);
				return _tab7;
			}
			set
			{
                CanWriteProperty("Tab7", true);
				if ( _tab7 != value )
				{
					_tab7 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab8
		{
			get
			{
                CanReadProperty("Tab8", true);
				return _tab8;
			}
			set
			{
                CanWriteProperty("Tab8", true);
				if ( _tab8 != value )
				{
					_tab8 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab9
		{
			get
			{
                CanReadProperty("Tab9", true);
				return _tab9;
			}
			set
			{
                CanWriteProperty("Tab9", true);
				if ( _tab9 != value )
				{
					_tab9 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab10
		{
			get
			{
                CanReadProperty("Tab10", true);
				return _tab10;
			}
			set
			{
                CanWriteProperty("Tab10", true);
				if ( _tab10 != value )
				{
					_tab10 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab11
		{
			get
			{
                CanReadProperty("Tab11", true);
				return _tab11;
			}
			set
			{
                CanWriteProperty("Tab11", true);
				if ( _tab11 != value )
				{
					_tab11 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab12
		{
			get
			{
                CanReadProperty("Tab12", true);
				return _tab12;
			}
			set
			{
                CanWriteProperty("Tab12", true);
				if ( _tab12 != value )
				{
					_tab12 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab13
		{
			get
			{
                CanReadProperty("Tab13", true);
				return _tab13;
			}
			set
			{
                CanWriteProperty("Tab13", true);
				if ( _tab13 != value )
				{
					_tab13 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab14
		{
			get
			{
                CanReadProperty("Tab14", true);
				return _tab14;
			}
			set
			{
                CanWriteProperty("Tab14", true);
				if ( _tab14 != value )
				{
					_tab14 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Tab15
		{
			get
			{
                CanReadProperty("Tab15", true);
				return _tab15;
			}
			set
			{
                CanWriteProperty("Tab15", true);
				if ( _tab15 != value )
				{
					_tab15 = value;
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
		public static FrequencyTabbar NewFrequencyTabbar(  )
		{
			return Create();
		}

		public static FrequencyTabbar[] GetAllFrequencyTabbar(  )
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

        //            List<FrequencyTabbar> _list = new List<FrequencyTabbar>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    FrequencyTabbar instance = new FrequencyTabbar();
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
