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
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("c_surname_company", "_c_surname_company", "")]
    [MapInfo("c_first_names", "_c_first_names", "")]
    [MapInfo("c_initials", "_c_initials", "")]
    [MapInfo("lastmonth", "_lastmonth", "")]
    [MapInfo("thismonth", "_thismonth", "")]
    [MapInfo("wrate", "_wrate", "")]
    [System.Serializable()]

    public class Grosspayvariance : Entity<Grosspayvariance>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _c_surname_company;

        [DBField()]
        private string _c_first_names;

        [DBField()]
        private string _c_initials;

        [DBField()]
        private decimal? _lastmonth;

        [DBField()]
        private decimal? _thismonth;

        [DBField()]
        private int? _wrate;

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
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REContractNo
        {
            get
            {
                return (int)_contract_no;
            }
        }

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

        public virtual decimal? Lastmonth
        {
            get
            {
                CanReadProperty("Lastmonth", true);
                return _lastmonth;
            }
            set
            {
                CanWriteProperty("Lastmonth", true);
                if (_lastmonth != value)
                {
                    _lastmonth = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal RELastmonth
        {
            get
            {
                return (decimal)_lastmonth;
            }
        }

        public virtual decimal? Thismonth
        {
            get
            {
                CanReadProperty("Thismonth", true);
                return _thismonth;
            }
            set
            {
                CanWriteProperty("Thismonth", true);
                if (_thismonth != value)
                {
                    _thismonth = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REThismonth
        {
            get
            {
                return (decimal)_thismonth;
            }
        }

        public virtual int? Wrate
        {
            get
            {
                CanReadProperty("Wrate", true);
                return _wrate;
            }
            set
            {
                CanWriteProperty("Wrate", true);
                if (_wrate != value)
                {
                    _wrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REWrate
        {
            get
            {
                return (int)_wrate;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[compute_2]
        //c_surname_company + if(isnull( c_first_names ),'',', '+ c_first_names )

        // needs to implement compute expression manually:
        // compute control name=[var]
        //if( thismonth <;>;0,(( thismonth - lastmonth )/   lastmonth ) *100,0)

        // needs to implement compute expression manually:
        // compute control name=[compute_3]
        //var

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static Grosspayvariance NewGrosspayvariance(DateTime? sdate, DateTime? edate, DateTime? prevsdate, DateTime? prevedate)
        {
            return Create(sdate, edate, prevsdate, prevedate);
        }

        public static Grosspayvariance[] GetAllGrosspayvariance(DateTime? sdate, DateTime? edate, DateTime? prevsdate, DateTime? prevedate)
        {
            return Fetch(sdate, edate, prevsdate, prevedate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? sdate, DateTime? edate, DateTime? prevsdate, DateTime? prevedate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_grosspayvariance";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);
                    pList.Add(cm, "prevsdate", prevsdate);
                    pList.Add(cm, "prevedate", prevedate);

                    List<Grosspayvariance> _list = new List<Grosspayvariance>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Grosspayvariance instance = new Grosspayvariance();
                            instance._contract_no = GetValueFromReader<int?>(dr, 0);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
                            instance._c_initials = GetValueFromReader<string>(dr, 3);
                            instance._lastmonth = GetValueFromReader<decimal?>(dr, 4);
                            instance._thismonth = GetValueFromReader<decimal?>(dr, 5);
                            instance._wrate = GetValueFromReader<int?>(dr, 6);
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
