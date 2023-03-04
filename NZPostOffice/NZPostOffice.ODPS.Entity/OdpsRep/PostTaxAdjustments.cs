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
    [MapInfo("pbu_code", "_pbu_code", "")]
    [MapInfo("ac_code", "_ac_code", "")]
    [MapInfo("amount", "_amount", "")]
    [System.Serializable()]

    public class PostTaxAdjustments : Entity<PostTaxAdjustments>
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
        private string _pbu_code;

        [DBField()]
        private string _ac_code;

        [DBField()]
        private decimal? _amount;

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

        public virtual string PbuCode
        {
            get
            {
                CanReadProperty("PbuCode", true);
                return _pbu_code;
            }
            set
            {
                CanWriteProperty("PbuCode", true);
                if (_pbu_code != value)
                {
                    _pbu_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AcCode
        {
            get
            {
                CanReadProperty("AcCode", true);
                return _ac_code;
            }
            set
            {
                CanWriteProperty("AcCode", true);
                if (_ac_code != value)
                {
                    _ac_code = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Amount
        {
            get
            {
                CanReadProperty("Amount", true);
                return _amount;
            }
            set
            {
                CanWriteProperty("Amount", true);
                if (_amount != value)
                {
                    _amount = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REAmount
        {
            get
            {
                return (decimal)_amount;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static PostTaxAdjustments NewPostTaxAdjustments(DateTime? sdate, DateTime? edate)
        {
            return Create(sdate, edate);
        }

        public static PostTaxAdjustments[] GetAllPostTaxAdjustments(DateTime? sdate, DateTime? edate)
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
                    cm.CommandText = "odps.od_rps_posttaxadjustments";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);

                    List<PostTaxAdjustments> _list = new List<PostTaxAdjustments>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PostTaxAdjustments instance = new PostTaxAdjustments();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
                            instance._c_initials = GetValueFromReader<string>(dr, 3);
                            instance._pbu_code = GetValueFromReader<string>(dr, 4);
                            instance._ac_code = GetValueFromReader<string>(dr, 5);
                            instance._amount = GetValueFromReader<decimal?>(dr, 6);
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
