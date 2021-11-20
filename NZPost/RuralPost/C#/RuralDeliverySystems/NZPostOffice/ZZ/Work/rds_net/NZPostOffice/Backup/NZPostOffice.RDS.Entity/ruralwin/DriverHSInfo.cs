using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin
{
    // TJB  RPCR_060  Feb-2014
    // Added HstHelp, HstAdditionalDateErrmsg, HstNotesErrmsg 
    //    - populated from the hs_type table
    // Fixed bugs in delete and update data access functions
    //    - added hst_id to where clauses
    //
    // TJB  RPCR_060  Feb-2014
    // All functions working (though Delete never used)
    //
    // TJB  RPCR_060  Jan-2014
    // Added Insert, Update, Delete dummy functions
    //
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
    [MapInfo("hst_help", "_hst_help", "")]
    [MapInfo("hst_additional_date_errmsg", "_hst_additional_date_errmsg", "")]
    [MapInfo("hst_notes_errmsg", "_hst_notes_errmsg", "")]
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

        [DBField()]
        private string _hst_help;

        [DBField()]
        private string _hst_additional_date_errmsg;

        [DBField()]
        private string _hst_notes_errmsg;


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

        public virtual DateTime? prevHsiDateChecked
        {
            get
            {
                CanReadProperty("HsiDateChecked", true);
                return (DateTime?)GetInitialValue("_hsi_date_checked");
            }
        }

        public virtual string HsiPassfailInd
        {
            get
            {
                CanReadProperty("HsiPassfailInd", true);
                return (_hsi_passfail_ind == null) ? _hsi_passfail_ind : _hsi_passfail_ind.ToUpper();
            }
            set
            {
                CanWriteProperty("HsiPassfailInd", true);
                if (_hsi_passfail_ind == null)
                {
                    _hsi_passfail_ind = (value == null) ? value : value.ToUpper();
                    PropertyHasChanged();
                }
                else
                if (value == null)
                {
                    _hsi_passfail_ind = null;
                    PropertyHasChanged();
                }
                else
                if (_hsi_passfail_ind.ToUpper() != value.ToUpper())
                {
                    _hsi_passfail_ind = value.ToUpper();
                    PropertyHasChanged();
                }
            }
        }

        public virtual string prevHsiPassfailInd
        {
            get
            {
                CanReadProperty("HsiPassfailInd", true);
                return (string)GetInitialValue("_hsi_passfail_ind");
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

        public virtual DateTime? prevHsiAdditionalDate
        {
            get
            {
                CanReadProperty("prevHsiAdditionalDate", true);
                return (DateTime?)GetInitialValue("_hsi_additional_date");
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

        public virtual string prevHsiNotes
        {
            get
            {
                CanReadProperty("prevHsiNotes", true);
                return (string)GetInitialValue("_hsi_notes");
            }
        }

        public virtual string HstHelp
        {
            get
            {
                CanReadProperty("HstHelp", true);
                return _hst_help;
            }
            set
            {
                CanWriteProperty("HstHelp", true);
                if (_hst_help != value)
                {
                    _hst_help = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HstAdditionalDateErrmsg
        {
            get
            {
                CanReadProperty("HstAdditionalDateErrmsg", true);
                return _hst_additional_date_errmsg;
            }
            set
            {
                CanWriteProperty("HstAdditionalDateErrmsg", true);
                if (_hst_additional_date_errmsg != value)
                {
                    _hst_additional_date_errmsg = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string HstNotesErrmsg
        {
            get
            {
                CanReadProperty("HstNotesErrmsg", true);
                return _hst_notes_errmsg;
            }
            set
            {
                CanWriteProperty("HstNotesErrmsg", true);
                if (_hst_notes_errmsg != value)
                {
                    _hst_notes_errmsg = value;
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
                    string newLine = Environment.NewLine;

					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_getDriverHSInfo";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inDriverNo", in_driver_no);

                    SqlErrCode = 0;
                    List<DriverHSInfo> _list = new List<DriverHSInfo>();

                    try
                    {
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
                                instance._hst_help = GetValueFromReader<string>(dr, 7);
                                if (instance._hst_help != null && instance._hst_help.Length > 0)
                                    instance._hst_help = instance._hst_help.Replace("|", newLine);
                                instance._hst_additional_date_errmsg = GetValueFromReader<string>(dr, 8);
                                if (instance._hst_additional_date_errmsg != null && instance._hst_additional_date_errmsg.Length > 0)
                                    instance._hst_additional_date_errmsg = instance._hst_additional_date_errmsg.Replace("|", newLine);
                                instance._hst_notes_errmsg = GetValueFromReader<string>(dr, 9);
                                if (instance._hst_notes_errmsg != null && instance._hst_notes_errmsg.Length > 0)
                                    instance._hst_notes_errmsg = instance._hst_notes_errmsg.Replace("|", newLine);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        SqlErrCode = -1;
                        SqlErrMsg  = e.Message;
                    }
                    list = _list.ToArray();
                }
			}
		}

        [ServerMethod()]
        private void UpdateEntity()
        {
            if (GetInitialValue("_hsi_date_checked") == null)
            {
                InsertEntity();
                return;
            }
            if (_hsi_date_checked == null)
            {
                DeleteEntity();
                return;
            }

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                try
                {
                    if (GenerateUpdateCommandText(cm, "driver_hs_info", ref pList))
                    {
                        cm.CommandText += " WHERE driver_no = @driver_no "
                                        + "   and hst_id = @hst_id";

                        pList.Add(cm, "driver_no", GetInitialValue("_driver_no"));
                        pList.Add(cm, "hst_id", GetInitialValue("_hst_id"));
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    StoreInitialValues();
                }
                catch (Exception e)
                {
                    SqlErrMsg = e.Message;
                    SqlErrCode = -1;
                }
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
                try
                {
                    if (GenerateInsertCommandText(cm, "driver_hs_info", pList))
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    StoreInitialValues();
                }
                catch (Exception e)
                {
                    SqlErrMsg = e.Message;
                    SqlErrCode = -1;
                }
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
                    pList.Add(cm, "driver_no", GetInitialValue("_driver_no"));
                    pList.Add(cm, "hst_id", GetInitialValue("_hst_id"));
                    try
                    {
                        cm.CommandText = "DELETE FROM driver_hs_info "
                                       + "WHERE driver_no = @driver_no "
                                       + "  AND hst_id = @hst_id";
                        DBHelper.ExecuteNonQuery(cm, pList);
                        tr.Commit();
                    }
                    catch (Exception e)
                    {
                        SqlErrMsg = e.Message;
                        SqlErrCode = -1;
                        tr.Rollback();
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
