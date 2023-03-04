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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
	[MapInfo("sf_description", "_sf_description", "")]
	[MapInfo("mon", "_mon", "")]
	[MapInfo("tue", "_tue", "")]
	[MapInfo("wed", "_wed", "")]
	[MapInfo("thu", "_thu", "")]
	[MapInfo("fri", "_fri", "")]
	[MapInfo("sat", "_sat", "")]
	[MapInfo("sun", "_sun", "")]
	[System.Serializable()]

	public class FrequencyTitle : Entity<FrequencyTitle>
	{
		#region Business Methods
		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private string  _sf_description;

		[DBField()]
		private string  _mon;

		[DBField()]
		private string  _tue;

		[DBField()]
		private string  _wed;

		[DBField()]
		private string  _thu;

		[DBField()]
		private string  _fri;

		[DBField()]
		private string  _sat;

		[DBField()]
		private string  _sun;


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

		public virtual bool? Mon
		{
			get
			{
                CanReadProperty("Mon", true);
				return GetBoolean(_mon, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Mon", true);
                SetFromBoolean(ref _mon, value, "Y", "N");				
			}
		}

        public virtual bool? Tue
		{
			get
			{
                CanReadProperty("Tue", true);
                return GetBoolean(_tue, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Tue", true);
                SetFromBoolean(ref _tue, value, "Y", "N");	
			}
		}

        public virtual bool? Wed
		{
			get
			{
                CanReadProperty("Wed", true);
                return GetBoolean(_wed, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Wed", true);
                SetFromBoolean(ref _wed, value, "Y", "N");	
			}
		}

        public virtual bool? Thu
		{
			get
			{
                CanReadProperty("Thu", true);
                return GetBoolean(_thu, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Thu", true);
                SetFromBoolean(ref _thu, value, "Y", "N");	
			}
		}

        public virtual bool? Fri
		{
			get
			{
                CanReadProperty("Fri", true);
                return GetBoolean(_fri, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Fri", true);
                SetFromBoolean(ref _fri, value, "Y", "N");	
			}
		}

        public virtual bool? Sat
		{
			get
			{
                CanReadProperty("Sat", true);
                return GetBoolean(_sat, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Sat", true);
                SetFromBoolean(ref _sat, value, "Y", "N");	
			}
		}

		public virtual bool? Sun
		{
			get
			{
                CanReadProperty("Sun", true);
                return GetBoolean(_sun, "Y", "N", false);
            }
            set
            {
                CanWriteProperty("Sun", true);
                SetFromBoolean(ref _sun, value, "Y", "N");	
			}
		}

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static FrequencyTitle NewFrequencyTitle(  )
		{
			return Create();
		}

		public static FrequencyTitle[] GetAllFrequencyTitle(  )
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

        //            List<FrequencyTitle> _list = new List<FrequencyTitle>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    FrequencyTitle instance = new FrequencyTitle();
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
