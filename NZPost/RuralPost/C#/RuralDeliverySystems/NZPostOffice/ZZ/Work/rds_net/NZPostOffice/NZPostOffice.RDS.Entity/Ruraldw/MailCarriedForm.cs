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
    [MapInfo("sf_key", "_sf_key", "mail_carried")]
    [MapInfo("contract_no", "_contract_no", "mail_carried")]
    [MapInfo("mc_sequence_no", "_mc_sequence_no", "mail_carried")]
    [MapInfo("rf_delivery_days", "_rf_delivery_days", "mail_carried")]
    [MapInfo("mc_dispatch_carried", "_mc_dispatch_carried", "mail_carried")]
    [MapInfo("mc_uplift_time", "_mc_uplift_time", "mail_carried")]
    [MapInfo("mc_uplift_outlet", "_mc_up_outlet", "mail_carried")]
    [MapInfo("mc_uplift_outlet_name", "_mc_up_outlet_name", "")]
    [MapInfo("mc_set_down_time", "_mc_set_down_time", "mail_carried")]
    [MapInfo("mc_set_down_outlet", "_mc_dn_outlet", "mail_carried")]
    [MapInfo("mc_set_down_outlet_name", "_mc_dn_outlet_name", "")]
    [MapInfo("mc_disbanded_date", "_mc_disbanded_date", "mail_carried")]
    [MapInfo("uplift_picklist", "_up_picklist", "")]
    [MapInfo("setdown_picklist", "_dn_picklist", "")]
    [MapInfo("mc_set_down_next_day", "_next_day", "mail_carried")]
	[System.Serializable()]

	public class MailCarriedForm : Entity<MailCarriedForm>
	{
		#region Business Methods
		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _mc_sequence_no;

		[DBField()]
		private string  _rf_delivery_days;

		[DBField()]
		private string  _mc_dispatch_carried;

		[DBField()]
		private DateTime?  _mc_uplift_time;

		[DBField()]
		private int?  _mc_up_outlet;

		[DBField()]
		private string  _mc_up_outlet_name;

		[DBField()]
		private DateTime?  _mc_set_down_time;

		[DBField()]
		private int?  _mc_dn_outlet;

		[DBField()]
		private string  _mc_dn_outlet_name;

		[DBField()]
		private DateTime?  _mc_disbanded_date;

		[DBField()]
		private int?  _up_picklist;

		[DBField()]
		private int?  _dn_picklist;

		[DBField()]
		private string  _next_day="N";


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

		public virtual int? McSequenceNo
		{
			get
			{
                CanReadProperty("McSequenceNo", true);
				return _mc_sequence_no;
			}
			set
			{
                CanWriteProperty("McSequenceNo", true);
				if ( _mc_sequence_no != value )
				{
					_mc_sequence_no = value;
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

		public virtual string McDispatchCarried
		{
			get
			{
                CanReadProperty("McDispatchCarried", true);
				return _mc_dispatch_carried;
			}
			set
			{
                CanWriteProperty("McDispatchCarried", true);
				if ( _mc_dispatch_carried != value )
				{
					_mc_dispatch_carried = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? McUpliftTime
		{
			get
			{
                CanReadProperty("McUpliftTime", true);
				return _mc_uplift_time;
			}
			set
			{
                CanWriteProperty("McUpliftTime", true);
				if ( _mc_uplift_time != value )
				{
					_mc_uplift_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? McUpOutlet
		{
			get
			{
                CanReadProperty("McUpOutlet", true);
				return _mc_up_outlet;
			}
			set
			{
                CanWriteProperty("McUpOutlet", true);
				if ( _mc_up_outlet != value )
				{
					_mc_up_outlet = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string McUpOutletName
		{
			get
			{
                CanReadProperty("McUpOutletName", true);
				return _mc_up_outlet_name;
			}
			set
			{
                CanWriteProperty("McUpOutletName", true);
				if ( _mc_up_outlet_name != value )
				{
					_mc_up_outlet_name = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual DateTime? McSetDownTime
		{
			get
			{
                CanReadProperty("McSetDownTime", true);
				return _mc_set_down_time;
			}
			set
			{
                CanWriteProperty("McSetDownTime", true);
				if ( _mc_set_down_time != value )
				{
					_mc_set_down_time = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? McDnOutlet
		{
			get
			{
                CanReadProperty("McDnOutlet", true);
				return _mc_dn_outlet;
			}
			set
			{
                CanWriteProperty("McDnOutlet", true);
				if ( _mc_dn_outlet != value )
				{
					_mc_dn_outlet = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string McDnOutletName
		{
			get
			{
                CanReadProperty("McDnOutletName", true);
				return _mc_dn_outlet_name;
			}
			set
			{
                CanWriteProperty("McDnOutletName", true);
				if ( _mc_dn_outlet_name != value )
				{
					_mc_dn_outlet_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? McDisbandedDate
		{
			get
			{
                CanReadProperty("McDisbandedDate", true);
				return _mc_disbanded_date;
			}
			set
			{
                CanWriteProperty("McDisbandedDate", true);
				if ( _mc_disbanded_date != value )
				{
					_mc_disbanded_date = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? UpPicklist
		{
			get
			{
                CanReadProperty("UpPicklist", true);
				return _up_picklist;
			}
			set
			{
                CanWriteProperty("UpPicklist", true);
				if ( _up_picklist != value )
				{
					_up_picklist = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? DnPicklist
		{
			get
			{
                CanReadProperty("DnPicklist", true);
				return _dn_picklist;
			}
			set
			{
                CanWriteProperty("DnPicklist", true);
				if ( _dn_picklist != value )
				{
					_dn_picklist = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual bool NextDay
		{
			get
			{
                CanReadProperty("NextDay", true);
				return _next_day == "Y";
			}
			set
			{
                CanWriteProperty("NextDay", true);
                string new_value = value ? "Y" : "N";
                if (_next_day != new_value)
				{
                    _next_day = new_value;
                    PropertyHasChanged("_next_day");
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}/{3}", _sf_key,_contract_no,_mc_sequence_no,_rf_delivery_days );
		}
		#endregion

		#region Factory Methods
		public static MailCarriedForm NewMailCarriedForm( int? inContract, int? inSFKey, string inDeliveryDays )
		{
			return Create(inContract, inSFKey, inDeliveryDays);
		}

		public static MailCarriedForm[] GetAllMailCarriedForm( int? inContract, int? inSFKey, string inDeliveryDays )
		{
			return Fetch(inContract, inSFKey, inDeliveryDays).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSFKey, string inDeliveryDays )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSFKey", inSFKey);
					pList.Add(cm, "inDeliveryDays", inDeliveryDays);
                    cm.CommandText = "sp_GetMailCarried";
					List<MailCarriedForm> _list = new List<MailCarriedForm>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							MailCarriedForm instance = new MailCarriedForm();
                            instance._sf_key = GetValueFromReader<Int32?>(dr,0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,1);
                            instance._mc_sequence_no = GetValueFromReader<Int32?>(dr,2);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr,3);
                            instance._mc_dispatch_carried = GetValueFromReader<String>(dr,4);
                            instance._mc_uplift_time = GetValueFromReader<DateTime?>(dr,5);
                            instance._mc_up_outlet = GetValueFromReader<Int32?>(dr,6);
                            instance._mc_up_outlet_name = GetValueFromReader<String>(dr,7);
                            instance._mc_set_down_time = GetValueFromReader<DateTime?>(dr,8);
                            instance._mc_dn_outlet = GetValueFromReader<Int32?>(dr,9);
                            instance._mc_dn_outlet_name = GetValueFromReader<String>(dr,10);
                            instance._mc_disbanded_date = GetValueFromReader<DateTime?>(dr,11);
                            instance._up_picklist = GetValueFromReader<Int32?>(dr,12);
                            instance._dn_picklist = GetValueFromReader<Int32?>(dr,13);
                            instance._next_day = GetValueFromReader<String>(dr,14);

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
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "mail_carried", ref pList))
                {
                    cm.CommandText += " where contract_no = @inContract and sf_key = @inSFKey and rf_delivery_days = @inDeliveryDays ";

                    pList.Add(cm, "inContract", GetInitialValue("_contract_no"));
                    pList.Add(cm, "inSFKey", GetInitialValue("_sf_key"));
                    pList.Add(cm, "inDeliveryDays", GetInitialValue("_rf_delivery_days"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
                MarkOld();
            }
        }
        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "mail_carried", pList))
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                StoreInitialValues();
            }
        }
        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContract", GetInitialValue("_contract_no"));
                    pList.Add(cm, "inSFKey", GetInitialValue("_sf_key"));
                    pList.Add(cm, "inDeliveryDays", GetInitialValue("_rf_delivery_days"));
                    cm.CommandText = "DELETE FROM mail_carried where contract_no = @inContract and sf_key = @inSFKey and rf_delivery_days = @inDeliveryDays";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }

		#endregion

		[ServerMethod()]
		private void CreateEntity( int? sf_key, int? contract_no, int? mc_sequence_no, string rf_delivery_days )
		{
			_sf_key = sf_key;
			_contract_no = contract_no;
			_mc_sequence_no = mc_sequence_no;
			_rf_delivery_days = rf_delivery_days;
		}
	}
}
