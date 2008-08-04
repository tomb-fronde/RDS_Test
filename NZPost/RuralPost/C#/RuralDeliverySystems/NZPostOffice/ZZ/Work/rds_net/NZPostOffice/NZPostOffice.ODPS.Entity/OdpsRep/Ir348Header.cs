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
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("hdr", "_hdr", "")]
    [MapInfo("ird_no", "_ird_no", "")]
    [MapInfo("return_period", "_return_period", "")]

    [MapInfo("contact_person", "_contact_person", "")]
    [MapInfo("contact_phone", "_contact_phone", "")]
    [MapInfo("total_paye", "_total_paye", "")]

    [MapInfo("child_support", "_child_support", "")]
    [MapInfo("student_loan", "_student_loan", "")]
    [MapInfo("family_assistance", "_family_assistance", "")]

    [MapInfo("gross", "_gross", "")]
    [MapInfo("not_liable", "_not_liable", "")]
    [MapInfo("form_version_no", "_form_version_no", "")]

    [MapInfoIndex(new string[] { 
        "hdr", "ird_no", "return_period", 
        "contact_person","contact_phone", "total_paye", 
        "child_support", "student_loan", "family_assistance",
        "gross", "not_liable","form_version_no" })]

    [System.Serializable()]

    public class Ir348Header : Entity<Ir348Header>
    {
        #region Business Methods
        [DBField()]
        private string _hdr;

        [DBField()]
        private string _ird_no;

        [DBField()]
        private string _return_period;

        [DBField()]
        private string _contact_person;

        [DBField()]
        private string _contact_phone;

        [DBField()]
        private string _total_paye;

        [DBField()]
        private string _child_support;

        [DBField()]
        private string _student_loan;

        [DBField()]
        private string _family_assistance;

        [DBField()]
        private string _gross;

        [DBField()]
        private string _not_liable;

        [DBField()]
        private string _form_version_no;

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

        public virtual string ReturnPeriod
        {
            get
            {
                CanReadProperty("ReturnPeriod", true);
                return _return_period;
            }
            set
            {
                CanWriteProperty("ReturnPeriod", true);
                if (_return_period != value)
                {
                    _return_period = value;
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

        public virtual string FormVersionNo
        {
            get
            {
                CanReadProperty("FormVersionNo", true);
                return _form_version_no;
            }
            set
            {
                CanWriteProperty("FormVersionNo", true);
                if (_form_version_no != value)
                {
                    _form_version_no = value;
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
        public static Ir348Header NewIr348Header(DateTime? startdate, DateTime? enddate)
        {
            return Create(startdate, enddate);
        }

        public static Ir348Header[] GetAllIr348Header(DateTime? startdate, DateTime? enddate)
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
                    cm.CommandText = "odps.od_rps_ir348header";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "startdate", startdate);
                    pList.Add(cm, "enddate", enddate);

                    List<Ir348Header> _list = new List<Ir348Header>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Ir348Header instance = new Ir348Header();
                            instance._hdr = GetValueFromReader<string>(dr, 0);
                            instance._ird_no = GetValueFromReader<string>(dr, 1);
                            instance._return_period = GetValueFromReader<string>(dr, 2);
                            instance._contact_person = GetValueFromReader<string>(dr, 3);
                            instance._contact_phone = GetValueFromReader<string>(dr, 4);
                            instance._total_paye = GetValueFromReader<string>(dr, 5);
                            instance._child_support = GetValueFromReader<string>(dr, 6);
                            instance._student_loan = GetValueFromReader<string>(dr, 7);
                            instance._family_assistance = GetValueFromReader<string>(dr, 8);
                            instance._gross = GetValueFromReader<string>(dr, 9);
                            instance._not_liable = GetValueFromReader<string>(dr, 10);
                            instance._form_version_no = GetValueFromReader<string>(dr, 11);

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
