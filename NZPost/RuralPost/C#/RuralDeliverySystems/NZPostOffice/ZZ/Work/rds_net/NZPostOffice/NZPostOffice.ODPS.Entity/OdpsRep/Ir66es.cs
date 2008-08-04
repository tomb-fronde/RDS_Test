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
    [MapInfo("c_surname_company", "_c_surname_company", "")]
    [MapInfo("c_first_names", "_c_first_names", "")]
    [MapInfo("c_initials", "_c_initials", "")]
    [MapInfo("startdate", "_startdate", "")]
    [MapInfo("enddate", "_enddate", "")]
    [MapInfo("taxcategory", "_taxcategory", "")]
    [MapInfo("c_ird_no", "_c_ird_no", "")]
    [System.Serializable()]

    public class Ir66es : Entity<Ir66es>
    {
        #region Business Methods
        [DBField()]
        private string _c_surname_company;

        [DBField()]
        private string _c_first_names;

        [DBField()]
        private string _c_initials;

        [DBField()]
        private DateTime? _startdate;

        [DBField()]
        private DateTime? _enddate;

        [DBField()]
        private string _taxcategory;

        [DBField()]
        private string _c_ird_no;

        public virtual string CSurnameCompany
        {
            get
            {
                CanReadProperty("CSurnameCompany", true);
                return _c_surname_company;
            }
            set
            {
                CanWriteProperty("CSurnameCompany", true);
                if (_c_surname_company != value)
                {
                    _c_surname_company = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CFirstNames
        {
            get
            {
                CanReadProperty("CFirstNames", true);
                return _c_first_names;
            }
            set
            {
                CanWriteProperty("CFirstNames", true);
                if (_c_first_names != value)
                {
                    _c_first_names = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CInitials
        {
            get
            {
                CanReadProperty("CInitials", true);
                return _c_initials;
            }
            set
            {
                CanWriteProperty("CInitials", true);
                if (_c_initials != value)
                {
                    _c_initials = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? Startdate
        {
            get
            {
                CanReadProperty("Startdate", true);
                return _startdate;
            }
            set
            {
                CanWriteProperty("Startdate", true);
                if (_startdate != value)
                {
                    _startdate = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime REStartdate
        {
            get
            {
                return DateTime.MinValue;// (DateTime)_startdate;
            }

        }

        public virtual DateTime? Enddate
        {
            get
            {
                CanReadProperty("Enddate", true);
                return _enddate;
            }
            set
            {
                CanWriteProperty("Enddate", true);
                if (_enddate != value)
                {
                    _enddate = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime REEnddate
        {
            get
            {
                return DateTime.MinValue;// (DateTime)_enddate;
            }
        }

        public virtual string Taxcategory
        {
            get
            {
                CanReadProperty("Taxcategory", true);
                return _taxcategory;
            }
            set
            {
                CanWriteProperty("Taxcategory", true);
                if (_taxcategory != value)
                {
                    _taxcategory = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CIrdNo
        {
            get
            {
                CanReadProperty("CIrdNo", true);
                return _c_ird_no;
            }
            set
            {
                CanWriteProperty("CIrdNo", true);
                if (_c_ird_no != value)
                {
                    _c_ird_no = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[cname]
        //c_surname_company + if(isnull( c_first_names ),'',', '+ c_first_names )

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static Ir66es NewIr66es(DateTime? sdate, DateTime? edate)
        {
            return Create(sdate, edate);
        }

        public static Ir66es[] GetAllIr66es(DateTime? sdate, DateTime? edate)
        {
            return Fetch(sdate, edate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? sdate, DateTime? edate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_ir66es";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);

                    List<Ir66es> _list = new List<Ir66es>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Ir66es instance = new Ir66es();
                            instance._c_surname_company = GetValueFromReader<string>(dr, 0);
                            instance._c_first_names = GetValueFromReader<string>(dr, 1);
                            instance._c_initials = GetValueFromReader<string>(dr, 2);
                            instance._startdate = GetValueFromReader<DateTime?>(dr, 3);
                            instance._enddate = GetValueFromReader<DateTime?>(dr, 4);
                            instance._taxcategory = GetValueFromReader<string>(dr, 5);
                            instance._c_ird_no = GetValueFromReader<string>(dr, 6);
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
