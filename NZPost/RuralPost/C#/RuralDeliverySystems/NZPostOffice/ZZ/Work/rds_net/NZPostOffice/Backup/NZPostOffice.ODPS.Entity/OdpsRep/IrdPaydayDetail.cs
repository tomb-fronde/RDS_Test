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
    // Added new fields and stored procedure
    //
    // TJB  RPI_004  June-2010
    // Changed decimal? fields to strings so that, when saved to a csv file
    // the decimal places (.00) are not included.

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("hdr", "_hdr", "")]
    [MapInfo("ird_no", "_ird_no", "")]
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

    // TJB  RPCR_128  June-2019: added
    [MapInfo("pay_start_date", "_pay_start_date", "")]
    [MapInfo("pay_end_date", "_pay_end_date", "")]
    [MapInfo("pay_cycle", "_pay_cycle", "")]
    [MapInfo("ks_deductions", "_ks_deductions", "")]
    [MapInfo("ks_emp_contrib", "_ks_emp_contrib", "")]
    [MapInfo("esct_deductions", "_esct_deductions", "")]
    [MapInfo("tax_credits", "_tax_credits", "")]
    //-----------------------------------

    // TJB  RPCR_128  June-2019: added new fields to MapInfoIndex
    [MapInfoIndex(new string[] {
        "hdr","c_ird_no","employee_full_name",
        "tax_code","start_date","end_date",
        "pay_start_date","pay_end_date","pay_cycle",
        "gross_earnings","not_liable","lump_sum",
        "total_paye","cs_deductions","cs_deductioncode", 
        "sl_deductions","ks_deductions","ks_emp_contrib",
        "esct_deductions","tax_credits","family_assistance"})]

    [System.Serializable()]

    public class IrdPaydayDetail : Entity<IrdPaydayDetail>
    {
        #region Business Methods
        [DBField()]
        private string _hdr;

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
        private string _gross_earnings;

        [DBField()]
        private string _not_liable;

        [DBField()]
        private string _lump_sum;

        [DBField()]
        private string _total_paye;

        [DBField()]
        private string _cs_deductions;

        [DBField()]
        private string _cs_deductioncode;

        [DBField()]
        private string _sl_deductions;

        [DBField()]
        private string _family_assistance;

        // TJB  RPCR_128 June-2019: Added new variables
        [DBField()]
        private string _pay_start_date;

        [DBField()]
        private string _pay_end_date;

        [DBField()]
        private string _pay_cycle;

        [DBField()]
        private string _ks_deductions;

        [DBField()]
        private string _ks_emp_contrib;

        [DBField()]
        private string _esct_deductions;

        [DBField()]
        private string _tax_credits;
        //---------------------------------------

        public virtual string Hdr
        {
            get
            {
                CanReadProperty("Hdr", true);
                return _hdr;
            }
            set
            {
                CanWriteProperty("Hdr", true);
                if (_hdr != value)
                {
                    _hdr = value;
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

        // TJB  RPCR_128 June-2019: Added new variables
        public virtual string PayStartDate
        {
            get
            {
                CanReadProperty("PayStartDate", true);
                return _pay_start_date;
            }
            set
            {
                CanWriteProperty("PayStartDate", true);
                if (_pay_start_date != value)
                {
                    _pay_start_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PayEndDate
        {
            get
            {
                CanReadProperty("PayEndDate", true);
                return _pay_end_date;
            }
            set
            {
                CanWriteProperty("PayEndDate", true);
                if (_pay_end_date != value)
                {
                    _pay_end_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PayCycle
        {
            get
            {
                CanReadProperty("PayCycle", true);
                return _pay_cycle;
            }
            set
            {
                CanWriteProperty("PayCycle", true);
                if (_pay_cycle != value)
                {
                    _pay_cycle = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string KsDeductions
        {
            get
            {
                CanReadProperty("KsDeductions", true);
                return _ks_deductions;
            }
            set
            {
                CanWriteProperty("KsDeductions", true);
                if (_ks_deductions != value)
                {
                    _ks_deductions = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string KsEmpContrib
        {
            get
            {
                CanReadProperty("KsEmpContrib", true);
                return _ks_emp_contrib;
            }
            set
            {
                CanWriteProperty("KsEmpContrib", true);
                if (_ks_emp_contrib != value)
                {
                    _ks_emp_contrib = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EsctDeductions
        {
            get
            {
                CanReadProperty("EsctDeductions", true);
                return _esct_deductions;
            }
            set
            {
                CanWriteProperty("EsctDeductions", true);
                if (_esct_deductions != value)
                {
                    _esct_deductions = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TaxCredits
        {
            get
            {
                CanReadProperty("TaxCredits", true);
                return _tax_credits;
            }
            set
            {
                CanWriteProperty("TaxCredits", true);
                if (_tax_credits != value)
                {
                    _tax_credits = value;
                    PropertyHasChanged();
                }
            }
        }
        //---------------------------------------

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
                            // TJB  RPCR_128 June-2019
                            // Changed amount strings back to decimal and added new fields
                            IrdPaydayDetail instance = new IrdPaydayDetail();
                            instance._hdr = GetValueFromReader<string>(dr, 0);
                            instance._c_ird_no = GetValueFromReader<string>(dr, 1);
                            instance._employee_full_name = GetValueFromReader<string>(dr, 2);
                            instance._tax_code = GetValueFromReader<string>(dr, 3);
                            instance._start_date = GetValueFromReader<string>(dr, 4);
                            instance._end_date = GetValueFromReader<string>(dr, 5);
                            instance._pay_start_date = GetValueFromReader<string>(dr, 6);
                            instance._pay_end_date = GetValueFromReader<string>(dr, 7);
                            instance._pay_cycle = GetValueFromReader<string>(dr, 8);
                            instance._gross_earnings = GetValueFromReader<string>(dr, 9);
                            instance._not_liable = GetValueFromReader<string>(dr, 10);
                            instance._lump_sum = GetValueFromReader<string>(dr, 11);
                            instance._total_paye = GetValueFromReader<string>(dr, 12);
                            instance._cs_deductions = GetValueFromReader<string>(dr, 13);
                            instance._cs_deductioncode = GetValueFromReader<string>(dr, 14);
                            instance._sl_deductions = GetValueFromReader<string>(dr, 15);
                            instance._ks_deductions = GetValueFromReader<string>(dr, 16);
                            instance._ks_emp_contrib = GetValueFromReader<string>(dr, 17);
                            instance._esct_deductions = GetValueFromReader<string>(dr, 18);
                            instance._tax_credits = GetValueFromReader<string>(dr, 19);
                            instance._family_assistance = GetValueFromReader<string>(dr, 20);
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
