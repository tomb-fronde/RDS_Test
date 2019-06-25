using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // TJB  RPCR_128  June-2019: New
    // Adapted from Ir348Detail

    // TJB  RPI_004  June-2010
    // Changed decimal? fields to strings so that, when saved to a csv file
    // the decimal places (.00) are not included.

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("dtl", "_dtl", "")]
    [MapInfo("c_ird_no", "_c_ird_no", "")]
    [MapInfo("employee_full_name", "_employee_full_name", "")]

    [MapInfo("tax_code", "_tax_code", "")]
    [MapInfo("start_date", "_start_date", "")]
    [MapInfo("end_date", "_end_date", "")]

    [MapInfo("gross_earnings", "_gross_earnings", "")]
    [MapInfo("not_liable", "_not_liable", "")]
    [MapInfo("lump_sum", "_lump_sum", "")]

    [MapInfo("total_paye", "_total_paye", "")]
    [MapInfo("cs_deductions", "_cs_deductions", "")]
    [MapInfo("cs_deductioncode", "_cs_deductioncode", "")]

    [MapInfo("sl_deductions", "_sl_deductions", "")]
    [MapInfo("family_assistance", "_family_assistance", "")]

    [MapInfoIndex(new string[] {
        "dtl","c_ird_no","employee_full_name",
        "tax_code","start_date","end_date",
        "gross_earnings","not_liable","lump_sum",
        "total_paye","cs_deductions","cs_deductioncode", 
        "sl_deductions","family_assistance"})]
    [System.Serializable()]

    public class IrdPaydayDetail : Entity<IrdPaydayDetail>
    {
        #region Business Methods
        [DBField()]
        private string _dtl;

        [DBField()]
        private string _c_ird_no;

        [DBField()]
        private string _employee_full_name;

        [DBField()]
        private string _tax_code;

        [DBField()]
        private string _start_date;

        [DBField()]
        private string _end_date;

        [DBField()]
        //private decimal? _gross_earnings;
        private string _gross_earnings;

        [DBField()]
        //private decimal? _not_liable;
        private string _not_liable;

        [DBField()]
        //private decimal? _lump_sum;
        private string _lump_sum;

        [DBField()]
        //private decimal? _total_paye;
        private string _total_paye;

        [DBField()]
        //private decimal? _cs_deductions;
        private string _cs_deductions;

        [DBField()]
        private string _cs_deductioncode;

        [DBField()]
        //private decimal? _sl_deductions;
        private string _sl_deductions;

        [DBField()]
        //private decimal? _family_assistance;
        private string _family_assistance;

        public virtual string Dtl
        {
            get
            {
                CanReadProperty("Dtl", true);
                return _dtl;
            }
            set
            {
                CanWriteProperty("Dtl", true);
                if (_dtl != value)
                {
                    _dtl = value;
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

        public virtual string EmployeeFullName
        {
            get
            {
                CanReadProperty("EmployeeFullName", true);
                return _employee_full_name;
            }
            set
            {
                CanWriteProperty("EmployeeFullName", true);
                if (_employee_full_name != value)
                {
                    _employee_full_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TaxCode
        {
            get
            {
                CanReadProperty("TaxCode", true);
                return _tax_code;
            }
            set
            {
                CanWriteProperty("TaxCode", true);
                if (_tax_code != value)
                {
                    _tax_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string StartDate
        {
            get
            {
                CanReadProperty("StartDate", true);
                return _start_date;
            }
            set
            {
                CanWriteProperty("StartDate", true);
                if (_start_date != value)
                {
                    _start_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EndDate
        {
            get
            {
                CanReadProperty("EndDate", true);
                return _end_date;
            }
            set
            {
                CanWriteProperty("EndDate", true);
                if (_end_date != value)
                {
                    _end_date = value;
                    PropertyHasChanged();
                }
            }
        }

        //public virtual decimal? GrossEarnings
        public virtual string GrossEarnings
        {
            get
            {
                CanReadProperty("GrossEarnings", true);
                return _gross_earnings;
            }
            set
            {
                CanWriteProperty("GrossEarnings", true);
                if (_gross_earnings != value)
                {
                    _gross_earnings = value;
                    PropertyHasChanged();
                }
            }
        }

        //public virtual decimal? NotLiable
        public virtual string NotLiable
        {
            get
            {
                CanReadProperty("NotLiable", true);
                return _not_liable;
            }
            set
            {
                CanWriteProperty("NotLiable", true);
                if (_not_liable != value)
                {
                    _not_liable = value;
                    PropertyHasChanged();
                }
            }
        }

        //public virtual decimal? LumpSum
        public virtual string LumpSum
        {
            get
            {
                CanReadProperty("LumpSum", true);
                return _lump_sum;
            }
            set
            {
                CanWriteProperty("LumpSum", true);
                if (_lump_sum != value)
                {
                    _lump_sum = value;
                    PropertyHasChanged();
                }
            }
        }

        //public virtual decimal? TotalPaye
        public virtual string TotalPaye
        {
            get
            {
                CanReadProperty("TotalPaye", true);
                return _total_paye;
            }
            set
            {
                CanWriteProperty("TotalPaye", true);
                if (_total_paye != value)
                {
                    _total_paye = value;
                    PropertyHasChanged();
                }
            }
        }

        //public virtual decimal? CsDeductions
        public virtual string CsDeductions
        {
            get
            {
                CanReadProperty("CsDeductions", true);
                return _cs_deductions;
            }
            set
            {
                CanWriteProperty("CsDeductions", true);
                if (_cs_deductions != value)
                {
                    _cs_deductions = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CsDeductioncode
        {
            get
            {
                CanReadProperty("CsDeductioncode", true);
                return _cs_deductioncode;
            }
            set
            {
                CanWriteProperty("CsDeductioncode", true);
                if (_cs_deductioncode != value)
                {
                    _cs_deductioncode = value;
                    PropertyHasChanged();
                }
            }
        }

        //public virtual decimal? SlDeductions
        public virtual string SlDeductions
        {
            get
            {
                CanReadProperty("SlDeductions", true);
                return _sl_deductions;
            }
            set
            {
                CanWriteProperty("SlDeductions", true);
                if (_sl_deductions != value)
                {
                    _sl_deductions = value;
                    PropertyHasChanged();
                }
            }
        }

        //public virtual decimal? FamilyAssistance
        public virtual string FamilyAssistance
        {
            get
            {
                CanReadProperty("FamilyAssistance", true);
                return _family_assistance;
            }
            set
            {
                CanWriteProperty("FamilyAssistance", true);
                if (_family_assistance != value)
                {
                    _family_assistance = value;
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
        public static IrdPaydayDetail NewIrdPaydayDetail(DateTime? startdate, DateTime? enddate)
        {
            return Create(startdate, enddate);
        }

        public static IrdPaydayDetail[] GetAllIrdPaydayDetail(DateTime? startdate, DateTime? enddate)
        {
            return Fetch(startdate, enddate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? startdate, DateTime? enddate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_irdPaydayDetail";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "startdate", startdate);
                    pList.Add(cm, "enddate", enddate);

                    List<IrdPaydayDetail> _list = new List<IrdPaydayDetail>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            IrdPaydayDetail instance = new IrdPaydayDetail();
                            instance._dtl = GetValueFromReader<string>(dr, 0);
                            instance._c_ird_no = GetValueFromReader<string>(dr, 1);
                            instance._employee_full_name = GetValueFromReader<string>(dr, 2);
                            instance._tax_code = GetValueFromReader<string>(dr, 3);
                            instance._start_date = GetValueFromReader<string>(dr, 4);
                            instance._end_date = GetValueFromReader<string>(dr, 5);
                            //instance._gross_earnings = GetValueFromReader<decimal?>(dr, 6);
                            //instance._not_liable = GetValueFromReader<decimal?>(dr, 7);
                            //instance._lump_sum = GetValueFromReader<decimal?>(dr, 8);
                            //instance._total_paye = GetValueFromReader<decimal?>(dr, 9);
                            //instance._cs_deductions = GetValueFromReader<decimal?>(dr, 10);
                            instance._gross_earnings = GetValueFromReader<string>(dr, 6);
                            instance._not_liable = GetValueFromReader<string>(dr, 7);
                            instance._lump_sum = GetValueFromReader<string>(dr, 8);
                            instance._total_paye = GetValueFromReader<string>(dr, 9);
                            instance._cs_deductions = GetValueFromReader<string>(dr, 10);
                            instance._cs_deductioncode = GetValueFromReader<string>(dr, 11);
                            //instance._sl_deductions = GetValueFromReader<decimal?>(dr, 12);
                            //instance._family_assistance = GetValueFromReader<decimal?>(dr, 13);
                            instance._sl_deductions = GetValueFromReader<string>(dr, 12);
                            instance._family_assistance = GetValueFromReader<string>(dr, 13);
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
