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
	[MapInfo("cust_id", "_cust_id", "")]
	[MapInfo("cust_adpost_quantity", "_cust_adpost_quantity", "")]
	[MapInfo("cust_date_first_loaded", "_cust_date_first_loaded", "")]
	[MapInfo("cust_date_last_transfered", "_cust_date_last_transfered", "")]
	[MapInfo("cust_date_left", "_cust_date_left", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("cust_title", "_cust_title", "")]
	[MapInfo("cust_surname_company", "_cust_surname_company", "")]
	[MapInfo("cust_initials", "_cust_initials", "")]
	[MapInfo("cust_rd_number", "_cust_rd_number", "")]
	[MapInfo("cust_mailing_address_no", "_cust_mailing_address_no", "")]
	[MapInfo("cust_mailing_address_road", "_cust_mailing_address_road", "")]
	[MapInfo("cust_mailing_address_locality", "_cust_mailing_address_locality", "")]
	[MapInfo("cust_mail_town", "_cust_mail_town", "")]
	[MapInfo("cust_nad_reference", "_cust_nad_reference", "")]
	[MapInfo("cust_phone_day", "_cust_phone_day", "")]
	[MapInfo("cust_phone_night", "_cust_phone_night", "")]
	[MapInfo("cust_dir_listing_text", "_cust_dir_listing_text", "")]
	[MapInfo("cust_delivery_days", "_cust_delivery_days", "")]
	[MapInfo("cust_business", "_cust_business", "")]
	[MapInfo("cust_rural_resident", "_cust_rural_resident", "")]
	[MapInfo("cust_rural_farmer", "_cust_rural_farmer", "")]
	[MapInfo("con_rd_ref_text", "_con_rd_ref_text", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("cust_dir_listing_ind", "_cust_dir_listing_ind", "")]
	[MapInfo("cust_property_identification", "_cust_property_identification", "")]
	[MapInfo("cust_post_code", "_cust_post_code", "")]
	[MapInfo("compute_0028", "_compute_0028", "")]
	[MapInfo("compute_0029", "_compute_0029", "")]
	[System.Serializable()]

	public class CustlistLabelFast : Entity<CustlistLabelFast>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;

		[DBField()]
		private int?  _cust_adpost_quantity;

		[DBField()]
		private DateTime?  _cust_date_first_loaded;

		[DBField()]
		private DateTime?  _cust_date_last_transfered;

		[DBField()]
		private DateTime?  _cust_date_left;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _cust_title;

		[DBField()]
		private string  _cust_surname_company;

		[DBField()]
		private string  _cust_initials;

		[DBField()]
		private string  _cust_rd_number;

		[DBField()]
		private string  _cust_mailing_address_no;

		[DBField()]
		private string  _cust_mailing_address_road;

		[DBField()]
		private string  _cust_mailing_address_locality;

		[DBField()]
		private string  _cust_mail_town;

		[DBField()]
		private string  _cust_nad_reference;

		[DBField()]
		private string  _cust_phone_day;

		[DBField()]
		private string  _cust_phone_night;

		[DBField()]
		private string  _cust_dir_listing_text;

		[DBField()]
		private string  _cust_delivery_days;

		[DBField()]
		private string  _cust_business;

		[DBField()]
		private string  _cust_rural_resident;

		[DBField()]
		private string  _cust_rural_farmer;

		[DBField()]
		private string  _con_rd_ref_text;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _cust_dir_listing_ind;

		[DBField()]
		private string  _cust_property_identification;

		[DBField()]
		private string  _cust_post_code;

		[DBField()]
		private string  _compute_0028;

		[DBField()]
		private string  _compute_0029;


		public virtual int? CustId
		{
			get
			{
                CanReadProperty("CustId", true);
				return _cust_id;
			}
			set
			{
                CanWriteProperty("CustId", true);
				if ( _cust_id != value )
				{
					_cust_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? CustAdpostQuantity
		{
			get
			{
                CanReadProperty("CustAdpostQuantity", true);
				return _cust_adpost_quantity;
			}
			set
			{
                CanWriteProperty("CustAdpostQuantity", true);
				if ( _cust_adpost_quantity != value )
				{
					_cust_adpost_quantity = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CustDateFirstLoaded
		{
			get
			{
                CanReadProperty("CustDateFirstLoaded", true);
				return _cust_date_first_loaded;
			}
			set
			{
                CanWriteProperty("CustDateFirstLoaded", true);
				if ( _cust_date_first_loaded != value )
				{
					_cust_date_first_loaded = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CustDateLastTransfered
		{
			get
			{
                CanReadProperty("CustDateLastTransfered", true);
				return _cust_date_last_transfered;
			}
			set
			{
                CanWriteProperty("CustDateLastTransfered", true);
				if ( _cust_date_last_transfered != value )
				{
					_cust_date_last_transfered = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? CustDateLeft
		{
			get
			{
                CanReadProperty("CustDateLeft", true);
				return _cust_date_left;
			}
			set
			{
                CanWriteProperty("CustDateLeft", true);
				if ( _cust_date_left != value )
				{
					_cust_date_left = value;
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

		public virtual string CustTitle
		{
			get
			{
                CanReadProperty("CustTitle", true);
				return _cust_title;
			}
			set
			{
                CanWriteProperty("CustTitle", true);
				if ( _cust_title != value )
				{
					_cust_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustSurnameCompany
		{
			get
			{
                CanReadProperty("CustSurnameCompany", true);
				return _cust_surname_company;
			}
			set
			{
                CanWriteProperty("CustSurnameCompany", true);
				if ( _cust_surname_company != value )
				{
					_cust_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustInitials
		{
			get
			{
                CanReadProperty("CustInitials", true);
				return _cust_initials;
			}
			set
			{
                CanWriteProperty("CustInitials", true);
				if ( _cust_initials != value )
				{
					_cust_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustRdNumber
		{
			get
			{
                CanReadProperty("CustRdNumber", true);
				return _cust_rd_number;
			}
			set
			{
                CanWriteProperty("CustRdNumber", true);
				if ( _cust_rd_number != value )
				{
					_cust_rd_number = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailingAddressNo
		{
			get
			{
                CanReadProperty("CustMailingAddressNo", true);
				return _cust_mailing_address_no;
			}
			set
			{
                CanWriteProperty("CustMailingAddressNo", true);
				if ( _cust_mailing_address_no != value )
				{
					_cust_mailing_address_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailingAddressRoad
		{
			get
			{
                CanReadProperty("CustMailingAddressRoad", true);
				return _cust_mailing_address_road;
			}
			set
			{
                CanWriteProperty("CustMailingAddressRoad", true);
				if ( _cust_mailing_address_road != value )
				{
					_cust_mailing_address_road = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailingAddressLocality
		{
			get
			{
                CanReadProperty("CustMailingAddressLocality", true);
				return _cust_mailing_address_locality;
			}
			set
			{
                CanWriteProperty("CustMailingAddressLocality", true);
				if ( _cust_mailing_address_locality != value )
				{
					_cust_mailing_address_locality = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustMailTown
		{
			get
			{
                CanReadProperty("CustMailTown", true);
				return _cust_mail_town;
			}
			set
			{
                CanWriteProperty("CustMailTown", true);
				if ( _cust_mail_town != value )
				{
					_cust_mail_town = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustNadReference
		{
			get
			{
                CanReadProperty("CustNadReference", true);
				return _cust_nad_reference;
			}
			set
			{
                CanWriteProperty("CustNadReference", true);
				if ( _cust_nad_reference != value )
				{
					_cust_nad_reference = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustPhoneDay
		{
			get
			{
                CanReadProperty("CustPhoneDay", true);
				return _cust_phone_day;
			}
			set
			{
                CanWriteProperty("CustPhoneDay", true);
				if ( _cust_phone_day != value )
				{
					_cust_phone_day = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustPhoneNight
		{
			get
			{
                CanReadProperty("CustPhoneNight", true);
				return _cust_phone_night;
			}
			set
			{
                CanWriteProperty("CustPhoneNight", true);
				if ( _cust_phone_night != value )
				{
					_cust_phone_night = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustDirListingText
		{
			get
			{
                CanReadProperty("CustDirListingText", true);
				return _cust_dir_listing_text;
			}
			set
			{
                CanWriteProperty("CustDirListingText", true);
				if ( _cust_dir_listing_text != value )
				{
					_cust_dir_listing_text = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustDeliveryDays
		{
			get
			{
                CanReadProperty("CustDeliveryDays", true);
				return _cust_delivery_days;
			}
			set
			{
                CanWriteProperty("CustDeliveryDays", true);
				if ( _cust_delivery_days != value )
				{
					_cust_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustBusiness
		{
			get
			{
                CanReadProperty("CustBusiness", true);
				return _cust_business;
			}
			set
			{
                CanWriteProperty("CustBusiness", true);
				if ( _cust_business != value )
				{
					_cust_business = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustRuralResident
		{
			get
			{
                CanReadProperty("CustRuralResident", true);
				return _cust_rural_resident;
			}
			set
			{
                CanWriteProperty("CustRuralResident", true);
				if ( _cust_rural_resident != value )
				{
					_cust_rural_resident = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustRuralFarmer
		{
			get
			{
                CanReadProperty("CustRuralFarmer", true);
				return _cust_rural_farmer;
			}
			set
			{
                CanWriteProperty("CustRuralFarmer", true);
				if ( _cust_rural_farmer != value )
				{
					_cust_rural_farmer = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string ConRdRefText
		{
			get
			{
                CanReadProperty("ConRdRefText", true);
				return _con_rd_ref_text;
			}
			set
			{
                CanWriteProperty("ConRdRefText", true);
				if ( _con_rd_ref_text != value )
				{
					_con_rd_ref_text = value;
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

		public virtual string CustDirListingInd
		{
			get
			{
                CanReadProperty("CustDirListingInd", true);
				return _cust_dir_listing_ind;
			}
			set
			{
                CanWriteProperty("CustDirListingInd", true);
				if ( _cust_dir_listing_ind != value )
				{
					_cust_dir_listing_ind = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustPropertyIdentification
		{
			get
			{
                CanReadProperty("CustPropertyIdentification", true);
				return _cust_property_identification;
			}
			set
			{
                CanWriteProperty("CustPropertyIdentification", true);
				if ( _cust_property_identification != value )
				{
					_cust_property_identification = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustPostCode
		{
			get
			{
                CanReadProperty("CustPostCode", true);
				return _cust_post_code;
			}
			set
			{
                CanWriteProperty("CustPostCode", true);
				if ( _cust_post_code != value )
				{
					_cust_post_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Compute0028
		{
			get
			{
                CanReadProperty("Compute0028", true);
				return _compute_0028;
			}
			set
			{
                CanWriteProperty("Compute0028", true);
				if ( _compute_0028 != value )
				{
					_compute_0028 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Compute0029
		{
			get
			{
                CanReadProperty("Compute0029", true);
				return _compute_0029;
			}
			set
			{
                CanWriteProperty("Compute0029", true);
				if ( _compute_0029 != value )
				{
					_compute_0029 = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[rdn]
			/*?if(isnull(cust_rd_number), con_rd_ref_text , cust_rd_number )

			// needs to implement compute expression manually:
			// compute control name=[compute_1]
			if(isnull(cust_title),'', cust_title + ' ')+if(isnull(cust_initials),'', cust_initials  + ' ') +cust_surname_company

			// needs to implement compute expression manually:
			// compute control name=[compute_2]
			if(isnull( cust_property_identification)  or len(cust_property_identification)=0, if(isnull(cust_mailing_address_road) or len(cust_mailing_address_road)=0,'', if(isnull(cust_mailing_address_no) or len(cust_mailing_address_no) = 0, '',string(cust_mailing_address_no)+' ') + cust_mailing_address_road + 'r') + if(isnull(cust_mailing_address_locality) or len(cust_mailing_address_locality)=0 , '',cust_mailing_address_locality+'r') + if(isnull(cust_rd_number) or len(cust_rd_number)=0 , if(isnull(con_rd_ref_text) or len(con_rd_ref_text)=0 ,'','RD '+con_rd_ref_text+'r'),'RD '+cust_rd_number),  cust_property_identification + 'r' +if(isnull(cust_mailing_address_road) or len(cust_mailing_address_road) = 0, '', if(isnull(cust_mailing_address_no) or len(cust_mailing_address_no)=0 ,'',string(cust_mailing_address_no)+' ') + cust_mailing_address_road + 'r') + if(isnull(cust_mailing_address_locality) or len(cust_mailing_address_locality) = 0,'',cust_mailing_address_locality+'r') + if(isnull(cust_rd_number) or len(cust_rd_number)=0, if(isnull(con_rd_ref_text),'','RD '+con_rd_ref_text+'r'),'RD '+cust_rd_number))*/

        public virtual string Compute1
        {
            get
            {
                string temp_cust_initials = "";
                if (_cust_initials == null)
                {
                    temp_cust_initials = "";
                }
                else
                {
                    temp_cust_initials = _cust_initials + " ";
                }

                string temp_cust_title = "";
                if (_cust_title == null)
                {
                    temp_cust_title = "";
                }
                else
                {
                    temp_cust_title = _cust_title + " ";
                }

                return temp_cust_title + temp_cust_initials + _cust_surname_company;
            }
        }
        public virtual string Compute2
        {
            get
            {
                string temp_cust_rd_number;
                string temp_con_rd_ref_text;
                string temp_cust_mailing_address_locality;
                string temp_cust_mailing_address_road;
                string temp_cust_mailing_address_no;
                string temp_cust_property_identification;

                if (_con_rd_ref_text == null)
                {
                    temp_con_rd_ref_text = "";
                }
                else
                {
                    temp_con_rd_ref_text = "RD" + _con_rd_ref_text + "\r\n";
                }
                if (string.IsNullOrEmpty(_cust_rd_number))
                {
                    temp_cust_rd_number = temp_con_rd_ref_text;
                }
                else
                {
                    temp_cust_rd_number = "RD" + _cust_rd_number;
                }
                if (string.IsNullOrEmpty(_cust_mailing_address_locality))
                {
                    temp_cust_mailing_address_locality = "";
                }
                else
                {
                    temp_cust_mailing_address_locality = _cust_mailing_address_locality + "\r\n";
                }
                if (string.IsNullOrEmpty(_cust_mailing_address_no))
                {
                    temp_cust_mailing_address_no = "";
                }
                else
                {
                    temp_cust_mailing_address_no = _cust_mailing_address_no + " ";
                }
                if (string.IsNullOrEmpty(_cust_mailing_address_road))
                {
                    temp_cust_mailing_address_road = "";
                }
                else
                {
                    temp_cust_mailing_address_road = temp_cust_mailing_address_no + _cust_mailing_address_road +"\r\n";
                }

                if (string.IsNullOrEmpty(_cust_property_identification))
                {
                    temp_cust_property_identification = temp_cust_mailing_address_road + temp_cust_mailing_address_locality + temp_cust_rd_number;
                }
                else
                {
                    temp_cust_property_identification = _cust_property_identification + "\r\n" + temp_cust_mailing_address_road + temp_cust_mailing_address_locality + temp_cust_rd_number;
                }

                return temp_cust_property_identification;
            }
        }

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static CustlistLabelFast NewCustlistLabelFast(  )
		{
			return Create();
		}

		public static CustlistLabelFast[] GetAllCustlistLabelFast(  )
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
                    cm.CommandText = "rd.jsresult";
                    cm.CommandTimeout = 500;
					ParameterCollection pList = new ParameterCollection();

					List<CustlistLabelFast> _list = new List<CustlistLabelFast>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							CustlistLabelFast instance = new CustlistLabelFast();
                            instance._cust_id = GetValueFromReader<int?>(dr,0);
                            instance._cust_adpost_quantity = GetValueFromReader<int?>(dr,1);
                            instance._cust_date_first_loaded = GetValueFromReader<DateTime?>(dr,2);
                            instance._cust_date_last_transfered = GetValueFromReader<DateTime?>(dr,3);
                            instance._cust_date_left = GetValueFromReader<DateTime?>(dr,4);
                            instance._contract_no = GetValueFromReader<int?>(dr,5);
                            instance._cust_title = GetValueFromReader<string>(dr,6);
                            instance._cust_surname_company = GetValueFromReader<string>(dr,7);
                            instance._cust_initials = GetValueFromReader<string>(dr,8);
                            instance._cust_rd_number = GetValueFromReader<string>(dr,9);
                            instance._cust_mailing_address_no = GetValueFromReader<string>(dr,10);
                            instance._cust_mailing_address_road = GetValueFromReader<string>(dr,11);
                            instance._cust_mailing_address_locality = GetValueFromReader<string>(dr,12);
                            instance._cust_mail_town = GetValueFromReader<string>(dr,13);
                            instance._cust_nad_reference = GetValueFromReader<string>(dr,14);
                            instance._cust_phone_day = GetValueFromReader<string>(dr,15);
                            instance._cust_phone_night = GetValueFromReader<string>(dr,16);
                            instance._cust_dir_listing_text = GetValueFromReader<string>(dr,17);
                            instance._cust_delivery_days = GetValueFromReader<string>(dr,18);
                            instance._cust_business = GetValueFromReader<string>(dr,19);
                            instance._cust_rural_resident = GetValueFromReader<string>(dr,20);
                            instance._cust_rural_farmer = GetValueFromReader<string>(dr,21);
                            instance._con_rd_ref_text = GetValueFromReader<string>(dr,22);
                            instance._con_title = GetValueFromReader<string>(dr,23);
                            instance._cust_dir_listing_ind = GetValueFromReader<string>(dr,24);
                            instance._cust_property_identification = GetValueFromReader<string>(dr,25);
                            instance._cust_post_code = GetValueFromReader<string>(dr,26);
                            instance._compute_0028 = GetValueFromReader<string>(dr,27);
                            instance._compute_0029 = GetValueFromReader<string>(dr,28);
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
