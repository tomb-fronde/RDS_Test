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
    // Adapted from Ir348Header
    // Changed 'form_version_no' to 'Form_version'; stored procedure called
    // Otherwise unchanged

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("hdr", "_hdr", "")]
    [MapInfo("ird_no", "_ird_no", "")]
    [MapInfo("pay_date", "_pay_date", "")]

    [MapInfo("final_return", "_final_return", "")]
    [MapInfo("nil_return", "_nil_return", "")]
    [MapInfo("paye_intermediary", "_paye_intermediary", "")]

    [MapInfo("contact_person", "_contact_person", "")]
    [MapInfo("contact_phone", "_contact_phone", "")]
    [MapInfo("contact_email", "_contact_email", "")]

    [MapInfo("total_lines", "_total_lines", "")]
    [MapInfo("total_paye", "_total_paye", "")]

    [MapInfo("child_support", "_child_support", "")]
    [MapInfo("student_loan", "_student_loan", "")]
    [MapInfo("kiwi_deducted", "_kiwi_deducted", "")]
    [MapInfo("kiwi_emp_contrib", "_kiwi_emp_contrib", "")]

    [MapInfo("esct_deducted", "_esct_deducted", "")]
    [MapInfo("total_deducted", "_total_deducted", "")]
    [MapInfo("total_credits", "_total_credits", "")]

    [MapInfo("family_assistance", "_family_assistance", "")]
    [MapInfo("gross", "_gross", "")]
    [MapInfo("not_liable", "_not_liable", "")]
    [MapInfo("package", "_package", "")]
    [MapInfo("form_version", "_form_version", "")]


    [MapInfoIndex(new string[] { 
        "hdr", "ird_no", "pay_date", 
        "final_return", "nil_return", "paye_intermediary",
        "contact_person","contact_phone", "contact_email", 
        "total_lines", "total_paye", "child_support", 
        "student_loan", "kiwi_deducted", "kiwi_emp_contrib",
        "esct_deducted", "total_deducted", "total_credits",
        "family_assistance", "gross", "not_liable",
        "package", "form_version" })]

    [System.Serializable()]

    public class IrdPaydayHeader : Entity<IrdPaydayHeader>
    {
        #region Business Methods
        [DBField()]
        private string _hdr;

        [DBField()]
        private string _ird_no;

        [DBField()]
        private string _pay_date;

        [DBField()]
        private string _final_return;
        
        [DBField()]
        private string _nil_return;
        
        [DBField()]
        private string _paye_intermediary;

        [DBField()]
        private string _contact_person;

        [DBField()]
        private string _contact_phone;

        [DBField()]
        private string _contact_email;

        [DBField()]
        private string _total_lines;

        [DBField()]
        private string _total_paye;

        [DBField()]
        private string _child_support;

        [DBField()]
        private string _student_loan;

        [DBField()]
        private string _kiwi_deducted;

        [DBField()]
        private string _kiwi_emp_contrib;

        [DBField()]
        private string _esct_deducted;

        [DBField()]
        private string _total_deducted;

        [DBField()]
        private string _total_credits;

        [DBField()]
        private string _family_assistance;

        [DBField()]
        private string _gross;

        [DBField()]
        private string _not_liable;

        [DBField()]
        private string _package;

        [DBField()]
        private string _form_version;

        public virtual string Hdr
        {
            get
            {
                CanReadProperty(true);
                return _hdr;
            }
            set
            {
                CanWriteProperty(true);
                if (_hdr != value)
                {
                    _hdr = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string IrdNo
        {
            get
            {
                CanReadProperty("IrdNo", true);
                return _ird_no;
            }
            set
            {
                CanWriteProperty("IrdNo", true);
                if (_ird_no != value)
                {
                    _ird_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PayDate
        {
            get
            {
                CanReadProperty("PayDate", true);
                return _pay_date;
            }
            set
            {
                CanWriteProperty("PayDate", true);
                if (_pay_date != value)
                {
                    _pay_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string FinalReturn
        {
            get
            {
                CanReadProperty(true);
                return _final_return;
            }
            set
            {
                CanWriteProperty(true);
                if (_final_return != value)
                {
                    _final_return = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NilReturn
        {
            get
            {
                CanReadProperty(true);
                return _nil_return;
            }
            set
            {
                CanWriteProperty(true);
                if (_nil_return != value)
                {
                    _nil_return = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PayeIntermediary
        {
            get
            {
                CanReadProperty(true);
                return _paye_intermediary;
            }
            set
            {
                CanWriteProperty(true);
                if (_paye_intermediary != value)
                {
                    _paye_intermediary = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContactPerson
        {
            get
            {
                CanReadProperty("ContactPerson", true);
                return _contact_person;
            }
            set
            {
                CanWriteProperty("ContactPerson", true);
                if (_contact_person != value)
                {
                    _contact_person = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContactPhone
        {
            get
            {
                CanReadProperty("ContactPhone", true);
                return _contact_phone;
            }
            set
            {
                CanWriteProperty("ContactPhone", true);
                if (_contact_phone != value)
                {
                    _contact_phone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ContactEmail
        {
            get
            {
                CanReadProperty(true);
                return _contact_email;
            }
            set
            {
                CanWriteProperty(true);
                if (_contact_email != value)
                {
                    _contact_email = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TotalLines
        {
            get
            {
                CanReadProperty(true);
                return _total_lines;
            }
            set
            {
                CanWriteProperty(true);
                if (_total_lines != value)
                {
                    _total_lines = value;
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

        public virtual string ChildSupport
        {
            get
            {
                CanReadProperty("ChildSupport", true);
                return _child_support;
            }
            set
            {
                CanWriteProperty("ChildSupport", true);
                if (_child_support != value)
                {
                    _child_support = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string StudentLoan
        {
            get
            {
                CanReadProperty("StudentLoan", true);
                return _student_loan;
            }
            set
            {
                CanWriteProperty("StudentLoan", true);
                if (_student_loan != value)
                {
                    _student_loan = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string KiwiDeducted
        {
            get
            {
                CanReadProperty(true);
                return _kiwi_deducted;
            }
            set
            {
                CanWriteProperty(true);
                if (_kiwi_deducted != value)
                {
                    _kiwi_deducted = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string KiwiEmpContrib
        {
            get
            {
                CanReadProperty(true);
                return _kiwi_emp_contrib;
            }
            set
            {
                CanWriteProperty(true);
                if (_kiwi_emp_contrib != value)
                {
                    _kiwi_emp_contrib = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string EsctDeducted
        {
            get
            {
                CanReadProperty(true);
                return _esct_deducted;
            }
            set
            {
                CanWriteProperty(true);
                if (_esct_deducted != value)
                {
                    _esct_deducted = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TotalDeducted
        {
            get
            {
                CanReadProperty(true);
                return _total_deducted;
            }
            set
            {
                CanWriteProperty(true);
                if (_total_deducted != value)
                {
                    _total_deducted = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TotalCredits
        {
            get
            {
                CanReadProperty(true);
                return _total_credits;
            }
            set
            {
                CanWriteProperty(true);
                if (_total_credits != value)
                {
                    _total_credits = value;
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

        public virtual string Gross
        {
            get
            {
                CanReadProperty("Gross", true);
                return _gross;
            }
            set
            {
                CanWriteProperty("Gross", true);
                if (_gross != value)
                {
                    _gross = value;
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

        public virtual string Package
        {
            get
            {
                CanReadProperty(true);
                return _package;
            }
            set
            {
                CanWriteProperty(true);
                if (_package != value)
                {
                    _package = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string FormVersion
        {
            get
            {
                CanReadProperty("FormVersion", true);
                return _form_version;
            }
            set
            {
                CanWriteProperty("FormVersion", true);
                if (_form_version != value)
                {
                    _form_version = value;
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
        public static IrdPaydayHeader NewIrdPaydayHeader(DateTime? startdate, DateTime? enddate)
        {
            return Create(startdate, enddate);
        }

        public static IrdPaydayHeader[] GetAllIrdPaydayHeader(DateTime? startdate, DateTime? enddate)
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
                    cm.CommandText = "odps.od_rps_IrdPaydayHeader";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "startdate", startdate);
                    pList.Add(cm, "enddate", enddate);

                    List<IrdPaydayHeader> _list = new List<IrdPaydayHeader>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            IrdPaydayHeader instance = new IrdPaydayHeader();
                            instance._hdr = GetValueFromReader<string>(dr, 0);
                            instance._ird_no = GetValueFromReader<string>(dr, 1);
                            instance._pay_date = GetValueFromReader<string>(dr, 2);
                            instance._final_return = GetValueFromReader<string>(dr, 3);
                            instance._nil_return = GetValueFromReader<string>(dr, 4);
                            instance._paye_intermediary = GetValueFromReader<string>(dr, 5);
                            instance._contact_person = GetValueFromReader<string>(dr, 6);
                            instance._contact_phone = GetValueFromReader<string>(dr, 7);
                            instance._contact_email = GetValueFromReader<string>(dr, 8);
                            instance._total_lines = GetValueFromReader<string>(dr, 9);
                            instance._total_paye = GetValueFromReader<string>(dr, 10);
                            instance._child_support = GetValueFromReader<string>(dr, 11);
                            instance._student_loan = GetValueFromReader<string>(dr, 12);
                            instance._kiwi_deducted = GetValueFromReader<string>(dr, 13);
                            instance._kiwi_emp_contrib = GetValueFromReader<string>(dr, 14);
                            instance._esct_deducted = GetValueFromReader<string>(dr, 15);
                            instance._total_deducted = GetValueFromReader<string>(dr, 16);
                            instance._total_credits = GetValueFromReader<string>(dr, 17);
                            instance._family_assistance = GetValueFromReader<string>(dr, 18);
                            instance._gross = GetValueFromReader<string>(dr, 19);
                            instance._not_liable = GetValueFromReader<string>(dr, 20);
                            instance._package = GetValueFromReader<string>(dr, 21);
                            instance._form_version = GetValueFromReader<string>(dr, 22);

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
