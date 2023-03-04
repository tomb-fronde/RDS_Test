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
	[MapInfo("sur_comp_name", "_sur_comp_name", "")]
	[MapInfo("initials", "_initials", "")]
	[MapInfo("prop_title", "_prop_title", "")]
	[MapInfo("road_no", "_road_no", "")]
	[MapInfo("road_alpha", "_road_alpha", "")]
	[MapInfo("road_name", "_road_name", "")]
	[MapInfo("locality", "_locality", "")]
	[MapInfo("rd_no", "_rd_no", "")]
	[MapInfo("mail_town", "_mail_town", "")]
	[MapInfo("recipients", "_recipients", "")]
	[MapInfo("categories", "_categories", "")]
	[MapInfo("kiwimail_qty", "_kiwimail_qty", "")]
	[MapInfo("business", "_business", "")]
	[MapInfo("residential", "_residential", "")]
	[MapInfo("farmer", "_farmer", "")]
	[MapInfo("cust_counter", "_cust_counter", "")]
	[MapInfo("del_counter", "_del_counter", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("con_title", "_con_title", "")]
	[System.Serializable()]

	public class PsCustListConExport : Entity<PsCustListConExport>
	{
		#region Business Methods
		[DBField()]
		private string  _sur_comp_name;

		[DBField()]
		private string  _initials;

		[DBField()]
		private string  _prop_title;

		[DBField()]
		private string  _road_no;

		[DBField()]
		private string  _road_alpha;

		[DBField()]
		private string  _road_name;

		[DBField()]
		private string  _locality;

		[DBField()]
		private string  _rd_no;

		[DBField()]
		private string  _mail_town;

		[DBField()]
		private string  _recipients;

		[DBField()]
		private string  _categories;

		[DBField()]
		private int?  _kiwimail_qty;

		[DBField()]
		private int?  _business;

		[DBField()]
		private int?  _residential;

		[DBField()]
		private int?  _farmer;

		[DBField()]
		private int?  _cust_counter;

		[DBField()]
		private int?  _del_counter;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _con_title;


		public virtual string SurCompName
		{
			get
			{
                CanReadProperty("SurCompName", true);
				return _sur_comp_name;
			}
			set
			{
                CanWriteProperty("SurCompName", true);
				if ( _sur_comp_name != value )
				{
					_sur_comp_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Initials
		{
			get
			{
                CanReadProperty("Initials", true);
				return _initials;
			}
			set
			{
                CanWriteProperty("Initials", true);
				if ( _initials != value )
				{
					_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PropTitle
		{
			get
			{
                CanReadProperty("PropTitle", true);
				return _prop_title;
			}
			set
			{
                CanWriteProperty("PropTitle", true);
				if ( _prop_title != value )
				{
					_prop_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RoadNo
		{
			get
			{
                CanReadProperty("RoadNo", true);
				return _road_no;
			}
			set
			{
                CanWriteProperty("RoadNo", true);
				if ( _road_no != value )
				{
					_road_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RoadAlpha
		{
			get
			{
                CanReadProperty("RoadAlpha", true);
				return _road_alpha;
			}
			set
			{
                CanWriteProperty("RoadAlpha", true);
				if ( _road_alpha != value )
				{
					_road_alpha = value;
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

		public virtual string RdNo
		{
			get
			{
                CanReadProperty("RdNo", true);
				return _rd_no;
			}
			set
			{
                CanWriteProperty("RdNo", true);
				if ( _rd_no != value )
				{
					_rd_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string MailTown
		{
			get
			{
                CanReadProperty("MailTown", true);
				return _mail_town;
			}
			set
			{
                CanWriteProperty("MailTown", true);
				if ( _mail_town != value )
				{
					_mail_town = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Recipients
		{
			get
			{
                CanReadProperty("Recipients", true);
				return _recipients;
			}
			set
			{
                CanWriteProperty("Recipients", true);
				if ( _recipients != value )
				{
					_recipients = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Categories
		{
			get
			{
                CanReadProperty("Categories", true);
				return _categories;
			}
			set
			{
                CanWriteProperty("Categories", true);
				if ( _categories != value )
				{
					_categories = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? KiwimailQty
		{
			get
			{
                CanReadProperty("KiwimailQty", true);
				return _kiwimail_qty;
			}
			set
			{
                CanWriteProperty("KiwimailQty", true);
				if ( _kiwimail_qty != value )
				{
					_kiwimail_qty = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Business
		{
			get
			{
                CanReadProperty("Business", true);
				return _business;
			}
			set
			{
                CanWriteProperty("Business", true);
				if ( _business != value )
				{
					_business = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Residential
		{
			get
			{
                CanReadProperty("Residential", true);
				return _residential;
			}
			set
			{
                CanWriteProperty("Residential", true);
				if ( _residential != value )
				{
					_residential = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Farmer
		{
			get
			{
                CanReadProperty("Farmer", true);
				return _farmer;
			}
			set
			{
                CanWriteProperty("Farmer", true);
				if ( _farmer != value )
				{
					_farmer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CustCounter
		{
			get
			{
                CanReadProperty("CustCounter", true);
				return _cust_counter;
			}
			set
			{
                CanWriteProperty("CustCounter", true);
				if ( _cust_counter != value )
				{
					_cust_counter = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? DelCounter
		{
			get
			{
                CanReadProperty("DelCounter", true);
				return _del_counter;
			}
			set
			{
                CanWriteProperty("DelCounter", true);
				if ( _del_counter != value )
				{
					_del_counter = value;
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

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static PsCustListConExport NewPsCustListConExport(  )
		{
			return Create();
		}

		public static PsCustListConExport[] GetAllPsCustListConExport(  )
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
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_cust_list_con_export";
					ParameterCollection pList = new ParameterCollection();

					List<PsCustListConExport> _list = new List<PsCustListConExport>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PsCustListConExport instance = new PsCustListConExport();
                            instance._sur_comp_name = GetValueFromReader<string>(dr,0);
                            instance._initials = GetValueFromReader<string>(dr,1);
                            instance._prop_title = GetValueFromReader<string>(dr,2);
                            instance._road_no = GetValueFromReader<string>(dr,3);
                            instance._road_alpha = GetValueFromReader<string>(dr,4);
                            instance._road_name = GetValueFromReader<string>(dr,5);
                            instance._locality = GetValueFromReader<string>(dr,6);
                            instance._rd_no = GetValueFromReader<string>(dr,7);
                            instance._mail_town = GetValueFromReader<string>(dr,8);
                            instance._recipients = GetValueFromReader<string>(dr,9);
                            instance._categories = GetValueFromReader<string>(dr,10);
                            instance._kiwimail_qty = GetValueFromReader<int?>(dr,11);
                            instance._business = GetValueFromReader<int?>(dr,12);
                            instance._residential = GetValueFromReader<int?>(dr,13);
                            instance._farmer = GetValueFromReader<int?>(dr,14);
                            instance._cust_counter = GetValueFromReader<int?>(dr,15);
                            instance._del_counter = GetValueFromReader<int?>(dr,16);
                            instance._contract_no = GetValueFromReader<int?>(dr,17);
                            instance._con_title = GetValueFromReader<string>(dr,18);
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
