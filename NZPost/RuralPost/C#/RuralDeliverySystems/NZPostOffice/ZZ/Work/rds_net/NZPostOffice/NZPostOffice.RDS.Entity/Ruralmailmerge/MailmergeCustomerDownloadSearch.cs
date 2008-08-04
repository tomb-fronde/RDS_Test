using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralmailmerge
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("region_id", "_region_id_ro", "")]
	[MapInfo("outlet_id", "_outlet_id", "")]
	[MapInfo("o_name", "_o_name", "")]
	[MapInfo("firstletter", "_firstletter", "")]
	[MapInfo("load_fromdate", "_load_fromdate", "")]
	[MapInfo("load_todate", "_load_todate", "")]
	[MapInfo("printedon_fromdate", "_printedon_fromdate", "")]
	[MapInfo("printedon_todate", "_printedon_todate", "")]
	[MapInfo("outlet_picklist", "_outlet_picklist", "")]
	[MapInfo("printlabels", "_printlabels", "")]
	[MapInfo("rg_code", "_rg_code", "")]
	[MapInfo("ct_key", "_ct_key", "")]
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("use_printedon", "_use_printedon", "")]
	[MapInfo("UpdateAfterPrint", "_updateafterprint", "")]
	[System.Serializable()]

	public class MailmergeCustomerDownloadSearch : Entity<MailmergeCustomerDownloadSearch>
	{
		#region Business Methods
		[DBField()]
		private int?  _region_id_ro;

		[DBField()]
		private int?  _outlet_id;

		[DBField()]
        private string _o_name = "<All Outlets>";

		[DBField()]
		private string  _firstletter;

		[DBField()]
		private DateTime?  _load_fromdate;

		[DBField()]
		private DateTime?  _load_todate;

		[DBField()]
		private DateTime?  _printedon_fromdate;

		[DBField()]
		private DateTime?  _printedon_todate;

		[DBField()]
		private int?  _outlet_picklist;

		[DBField()]
        private string _printlabels = "N";

		[DBField()]
		private int?  _rg_code;

		[DBField()]
		private int?  _ct_key;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _use_printedon="N";

		[DBField()]
		private string  _updateafterprint="N";


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

		public virtual string Firstletter
		{
			get
			{
                CanReadProperty("Firstletter", true);
				return _firstletter;
			}
			set
			{
                CanWriteProperty("Firstletter", true);
				if ( _firstletter != value )
				{
					_firstletter = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? LoadFromdate
		{
			get
			{
                CanReadProperty("LoadFromdate", true);
				return _load_fromdate;
			}
			set
			{
                CanWriteProperty("LoadFromdate", true);
				if ( _load_fromdate != value )
				{
					_load_fromdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? LoadTodate
		{
			get
			{
                CanReadProperty("LoadTodate", true);
				return _load_todate;
			}
			set
			{
                CanWriteProperty("LoadTodate", true);
				if ( _load_todate != value )
				{
					_load_todate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? PrintedonFromdate
		{
			get
			{
                CanReadProperty("PrintedonFromdate", true);
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
        public virtual string Printlabels
        {
            get
            {
                CanReadProperty("Printlabels", true);
                return _printlabels;
            }
            set
            {
                CanWriteProperty("Printlabels", true);
                if (_printlabels != value)
                {
                    _printlabels = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual bool Printlabels2
        {
            get
            {
                CanReadProperty("Printlabels2", true);
                return _printlabels == "Y";
            }
            set
            {
                CanWriteProperty("Printlabels2", true);
                string new_printlabels = value ? "Y" : "N";
                if (_printlabels != new_printlabels)
                {
                    _printlabels = new_printlabels;
                    PropertyHasChanged("Printlabels");
                }
            }
        }

        public virtual bool Printlabels1
        {
            get
            {
                CanReadProperty("Printlabels1", true);
                return _printlabels == "N";
            }
            set
            {
                CanWriteProperty("Printlabels1", true);
                string new_printlabels = value ? "N" : "Y";
                if (_printlabels != new_printlabels)
                {
                    _printlabels = new_printlabels;
                    PropertyHasChanged("Printlabels");
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
				if ( _use_printedon != value )
				{
					_use_printedon = value;
					PropertyHasChanged();
				}
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
				if ( _updateafterprint != value )
				{
					_updateafterprint = value;
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
		public static MailmergeCustomerDownloadSearch NewMailmergeCustomerDownloadSearch(  )
		{
			return Create();
		}

		public static MailmergeCustomerDownloadSearch[] GetAllMailmergeCustomerDownloadSearch(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
        //    using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<MailmergeCustomerDownloadSearch> _list = new List<MailmergeCustomerDownloadSearch>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    MailmergeCustomerDownloadSearch instance = new MailmergeCustomerDownloadSearch();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        }

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}
