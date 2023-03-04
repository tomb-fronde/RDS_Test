using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("a_key", "_a_key", "")]
    [MapInfo("a_datetime", "_a_datetime", "")]
    [MapInfo("a_userid", "_a_userid", "")]
    [MapInfo("a_contract", "_a_contract", "")]
    [MapInfo("a_contractor", "_a_contractor", "")]
    [MapInfo("a_comment", "_a_comment", "")]
    [MapInfo("a_oldvalue", "_a_oldvalue", "")]
    [MapInfo("a_newvalue", "_a_newvalue", "")]
    [MapInfo("ddate", "_ddate", "")]
    [System.Serializable()]

    public class AuditLog : Entity<AuditLog>
    {
        #region Business Methods
        [DBField()]
        private int? _a_key;

        [DBField()]
        private DateTime? _a_datetime;

        [DBField()]
        private string _a_userid;

        [DBField()]
        private int? _a_contract;

        [DBField()]
        private int? _a_contractor;

        [DBField()]
        private string _a_comment;

        [DBField()]
        private string _a_oldvalue;

        [DBField()]
        private string _a_newvalue;

        [DBField()]
        private DateTime? _ddate;

        public virtual int? AKey
        {
            get
            {
                CanReadProperty("AKey", true);
                return _a_key;
            }
            set
            {
                CanWriteProperty("AKey", true);
                if (_a_key != value)
                {
                    _a_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REAKey
        {
            get
            {
                return (int)_a_key;
            }
        }

        public virtual DateTime? ADatetime
        {
            get
            {
                CanReadProperty("ADatetime", true);
                return _a_datetime;
            }
            set
            {
                CanWriteProperty("ADatetime", true);
                if (_a_datetime != value)
                {
                    _a_datetime = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime READatetime
        {
            get
            {
                return (DateTime)_a_datetime;
            }
        }

        public virtual string AUserid
        {
            get
            {
                CanReadProperty("AUserid", true);
                return _a_userid;
            }
            set
            {
                CanWriteProperty("AUserid", true);
                if (_a_userid != value)
                {
                    _a_userid = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AContract
        {
            get
            {
                CanReadProperty("AContract", true);
                return _a_contract;
            }
            set
            {
                CanWriteProperty("AContract", true);
                if (_a_contract != value)
                {
                    _a_contract = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REAContract
        {
            get
            {
                if (_a_contract != null)
                {
                    return _a_contract.Value;
                }
                return 0;
            }
        }

        public virtual int? AContractor
        {
            get
            {
                CanReadProperty("AContractor", true);
                return _a_contractor;
            }
            set
            {
                CanWriteProperty("AContractor", true);
                if (_a_contractor != value)
                {
                    _a_contractor = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REAContractor
        {
            get
            {
                if (_a_contractor != null)
                {
                    return _a_contractor.Value;
                }
                return 0;
            }
        }

        public virtual string AComment
        {
            get
            {
                CanReadProperty("AComment", true);
                return _a_comment;
            }
            set
            {
                CanWriteProperty("AComment", true);
                if (_a_comment != value)
                {
                    _a_comment = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AOldvalue
        {
            get
            {
                CanReadProperty("AOldvalue", true);
                return _a_oldvalue;
            }
            set
            {
                CanWriteProperty("AOldvalue", true);
                if (_a_oldvalue != value)
                {
                    _a_oldvalue = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ANewvalue
        {
            get
            {
                CanReadProperty("ANewvalue", true);
                return _a_newvalue;
            }
            set
            {
                CanWriteProperty("ANewvalue", true);
                if (_a_newvalue != value)
                {
                    _a_newvalue = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? Ddate
        {
            get
            {
                CanReadProperty("Ddate", true);
                return _ddate;
            }
            set
            {
                CanWriteProperty("Ddate", true);
                if (_ddate != value)
                {
                    _ddate = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime REDdate
        {
            get
            {
                return (DateTime)_ddate;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static AuditLog NewAuditLog(DateTime? fromdate, DateTime? todate)
        {
            return Create(fromdate, todate);
        }

        public static AuditLog[] GetAllAuditLog(DateTime? fromdate, DateTime? todate)
        {
            return Fetch(fromdate, todate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? fromdate, DateTime? todate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.sp_rd_auditlog";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "fromdate", fromdate);
                    pList.Add(cm, "todate", todate);

                    List<AuditLog> _list = new List<AuditLog>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            AuditLog instance = new AuditLog();
                            instance._a_key = GetValueFromReader<int?>(dr, 0);
                            instance._a_datetime = GetValueFromReader<DateTime?>(dr, 1);
                            instance._a_userid = GetValueFromReader<string>(dr, 2);
                            instance._a_contract = GetValueFromReader<int?>(dr, 3);
                            instance._a_contractor = GetValueFromReader<int?>(dr, 4);
                            instance._a_comment = GetValueFromReader<string>(dr, 5);
                            instance._a_oldvalue = GetValueFromReader<string>(dr, 6);
                            instance._a_newvalue = GetValueFromReader<string>(dr, 7);
                            instance._ddate = GetValueFromReader<DateTime?>(dr, 8);
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
        private void CreateEntity()
        {
        }
    }
}
