using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  RPCR_060  Jan-2014:  NEW
    // Retrieves summary H&S information about a contractor's drivers
    // for the DDriverHSInfo DataControl

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("driver_no", "_driver_no", "driver_hs_info")]
    [MapInfo("hst_id", "_hst_id", "driver_hs_info")]
    [MapInfo("hst_name", "_hst_name", "")]
    [MapInfo("hsi_date_checked", "_hsi_date_checked", "driver_hs_info")]
    [MapInfo("hsi_passfail_ind", "_hsi_passfail_ind", "driver_hs_info")]
    [MapInfo("hsi_additional_date", "_hsi_additional_date", "driver_hs_info")]
    [MapInfo("hsi_notes", "_hsi_notes", "driver_hs_info")]
    [System.Serializable()]

	public class DriverHSInfo : Entity<DriverHSInfo>
	{
		#region Business Methods
		[DBField()]
		private int?  _driver_no;

        [DBField()]
        private int? _hst_id;

        [DBField()]
        private string _hst_name;

        [DBField()]
        private DateTime? _hsi_date_checked;

		[DBField()]
		private string  _hsi_passfail_ind;

        [DBField()]
        private DateTime? _hsi_additional_date;

        [DBField()]
        private string _hsi_notes;


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

        public virtual int? HstId
        {
            get
            {
                CanReadProperty("HstId", true);
                return _hst_id;
            }
            set
            {
                CanWriteProperty("HstId", true);
                if (_hst_id != value)
                {
                    _hst_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HstName
        {
            get
            {
                CanReadProperty("HstName", true);
                return _hst_name;
            }
            set
            {
                CanWriteProperty("HstName", true);
                if (_hst_name != value)
                {
                    _hst_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? HsiDateChecked
        {
            get
            {
                CanReadProperty("HsiDateChecked", true);
                return _hsi_date_checked;
            }
            set
            {
                CanWriteProperty("HsiDateChecked", true);
                if (_hsi_date_checked != value)
                {
                    _hsi_date_checked = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HsiPassfailInd
        {
            get
            {
                CanReadProperty("HsiPassfailInd", true);
                return _hsi_passfail_ind;
            }
            set
            {
                CanWriteProperty("HsiPassfailInd", true);
                if (_hsi_passfail_ind != value)
                {
                    _hsi_passfail_ind = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? HsiAdditionalDate
        {
            get
            {
                CanReadProperty("HsiAdditionalDate", true);
                return _hsi_additional_date;
            }
            set
            {
                CanWriteProperty("HsiAdditionalDate", true);
                if (_hsi_additional_date != value)
                {
                    _hsi_additional_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HsiNotes
        {
            get
            {
                CanReadProperty("HsiNotes", true);
                return _hsi_notes;
            }
            set
            {
                CanWriteProperty("HsiNotes", true);
                if (_hsi_notes != value)
                {
                    _hsi_notes = value;
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
		public static DriverHSInfo NewDriverHSInfo()
		{
			return Create();
		}

		public static DriverHSInfo[] GetAllDriverHSInfo( int? in_driver_no )
		{
            return Fetch(in_driver_no).list;
		}
		#endregion

		#region Data Access

        public int SqlErrCode = 0;
        public string SqlErrMsg = "";

		[ServerMethod]
        private void FetchEntity(int? in_driver_no)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_getDriverHSInfo";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inDriverNo", in_driver_no);

                    try
                    {
                        SqlErrCode = 0;
                        List<DriverHSInfo> _list = new List<DriverHSInfo>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                DriverHSInfo instance = new DriverHSInfo();
                                instance._driver_no = GetValueFromReader<int?>(dr, 0);
                                instance._hst_id = GetValueFromReader<int?>(dr, 1);
                                instance._hst_name = GetValueFromReader<string>(dr, 2);
                                instance._hsi_date_checked = GetValueFromReader<DateTime?>(dr, 3);
                                instance._hsi_passfail_ind = GetValueFromReader<string>(dr, 4);
                                instance._hsi_additional_date = GetValueFromReader<DateTime?>(dr, 5);
                                instance._hsi_notes = GetValueFromReader<string>(dr, 6);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        SqlErrCode = -1;
                        SqlErrMsg  = e.Message;
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
