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
    // All functions working (though Delete never used)
    //
    // TJB  RPCR_060  Jan-2014
    // Added Insert, Update, Delete dummy functions
    //
    // TJB  RPCR_060  Jan-2014:  NEW
    // Retrieves driver 'personal' info for the DDriverInfo DataControl

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("driver_no", "_driver_no", "driver")]
    [MapInfo("d_title", "_d_title", "driver")]
    [MapInfo("d_first_names", "_d_first_names", "driver")]
    [MapInfo("d_surname", "_d_surname", "driver")]
    [MapInfo("d_phone_day", "_d_phone_day", "driver")]
    [MapInfo("d_phone_night", "_d_phone_night", "driver")]
    [MapInfo("d_mobile", "_d_mobile", "driver")]
    [MapInfo("d_mobile2", "_d_mobile2", "driver")]
	[System.Serializable()]

	public class DriverInfo : Entity<DriverInfo>
	{
		#region Business Methods
		[DBField()]
		private int?  _driver_no;

        [DBField()]
        private string _d_title;

        [DBField()]
        private string _d_first_names;

        [DBField()]
        private string _d_surname;

        [DBField()]
        private string _d_phone_day;

        [DBField()]
        private string _d_phone_night;

        [DBField()]
        private string _d_mobile;

        [DBField()]
        private string _d_mobile2;


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

        public virtual string DTitle
        {
            get
            {
                CanReadProperty("DTitle", true);
                return _d_title;
            }
            set
            {
                CanWriteProperty("DTitle", true);
                if (_d_title != value)
                {
                    _d_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DFirstNames
        {
            get
            {
                CanReadProperty("DFirstNames", true);
                return _d_first_names;
            }
            set
            {
                CanWriteProperty("DFirstNames", true);
                if (_d_first_names != value)
                {
                    _d_first_names = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DSurname
        {
            get
            {
                CanReadProperty("DSurname", true);
                return _d_surname;
            }
            set
            {
                CanWriteProperty("DSurname", true);
                if (_d_surname != value)
                {
                    _d_surname = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DPhoneDay
        {
            get
            {
                CanReadProperty("DPhoneDay", true);
                return _d_phone_day;
            }
            set
            {
                CanWriteProperty("DPhoneDay", true);
                if (_d_phone_day != value)
                {
                    _d_phone_day = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DPhoneNight
        {
            get
            {
                CanReadProperty("DPhoneNight", true);
                return _d_phone_night;
            }
            set
            {
                CanWriteProperty("DPhoneNight", true);
                if (_d_phone_night != value)
                {
                    _d_phone_night = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DMobile
        {
            get
            {
                CanReadProperty("DMobile", true);
                return _d_mobile;
            }
            set
            {
                CanWriteProperty("DMobile", true);
                if (_d_mobile != value)
                {
                    _d_mobile = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DMobile2
        {
            get
            {
                CanReadProperty("DMobile2", true);
                return _d_mobile2;
            }
            set
            {
                CanWriteProperty("DMobile2", true);
                if (_d_mobile2 != value)
                {
                    _d_mobile2 = value;
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
		public static DriverInfo NewDriverInfo()
		{
			return Create();
		}

		public static DriverInfo[] GetAllDriverInfo( int? in_driver_no )
		{
            return Fetch(in_driver_no).list;
		}
		#endregion

		#region Data Access

        public virtual void marknew()
        {
            base.MarkClean();
            base.MarkNew();
        }

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
                    cm.CommandText = "rd.sp_getDriverInfo";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inDriverNo", in_driver_no);

                    try
                    {
                        SqlErrCode = 0;
                        List<DriverInfo> _list = new List<DriverInfo>();
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                DriverInfo instance = new DriverInfo();
                                instance._driver_no = GetValueFromReader<int?>(dr, 0);
                                instance._d_title = GetValueFromReader<string>(dr, 1);
                                instance._d_first_names = GetValueFromReader<string>(dr, 2);
                                instance._d_surname = GetValueFromReader<string>(dr, 3);
                                instance._d_phone_day = GetValueFromReader<string>(dr, 4);
                                instance._d_phone_night = GetValueFromReader<string>(dr, 5);
                                instance._d_mobile = GetValueFromReader<string>(dr, 6);
                                instance._d_mobile2 = GetValueFromReader<string>(dr, 7);
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

        [ServerMethod()]
        private void UpdateEntity()
        {
            if (GetInitialValue("_d_surname") == null)
            {
                InsertEntity();
                return;
            }
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                try
                {
                    if (GenerateUpdateCommandText(cm, "driver", ref pList))
                    {
                        cm.CommandText += " WHERE  driver_no = @driver_no ";
                        pList.Add(cm, "driver_no", GetInitialValue("_driver_no"));
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    StoreInitialValues();
                }
                catch (Exception e)
                {
                    SqlErrMsg  = e.Message;
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
                    if (GenerateInsertCommandText(cm, "driver", pList))
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
                    try
                    {
                        cm.CommandText = "DELETE FROM driver "
                                        + "WHERE driver_no = @driver_no ";
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
