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
    [MapInfo("gptaxable", "_gptaxable", "")]
    [MapInfo("gpnontaxable", "_gpnontaxable", "")]
    [MapInfo("paye", "_paye", "")]
    [MapInfo("acc", "_acc", "")]
    [System.Serializable()]

    public class Ir68aIr68p : Entity<Ir68aIr68p>
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
        private decimal? _gptaxable;

        [DBField()]
        private decimal? _gpnontaxable;

        [DBField()]
        private decimal? _paye;

        [DBField()]
        private decimal? _acc;

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

        public virtual decimal? Gptaxable
        {
            get
            {
                CanReadProperty("Gptaxable", true);
                return _gptaxable;
            }
            set
            {
                CanWriteProperty("Gptaxable", true);
                if (_gptaxable != value)
                {
                    _gptaxable = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REGptaxable
        {
            get
            {
                return (decimal)_gptaxable;
            }
        }

        public virtual decimal? Gpnontaxable
        {
            get
            {
                CanReadProperty("Gpnontaxable", true);
                return _gpnontaxable;
            }
            set
            {
                CanWriteProperty("Gpnontaxable", true);
                if (_gpnontaxable != value)
                {
                    _gpnontaxable = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REGpnontaxable
        {
            get
            {
                return (decimal)_gpnontaxable;
            }
        }

        public virtual decimal? Paye
        {
            get
            {
                CanReadProperty("Paye", true);
                return _paye;
            }
            set
            {
                CanWriteProperty("Paye", true);
                if (_paye != value)
                {
                    _paye = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REPaye
        {
            get
            {
                return (decimal)_paye;
            }
        }

        public virtual decimal? Acc
        {
            get
            {
                CanReadProperty("Acc", true);
                return _acc;
            }
            set
            {
                CanWriteProperty("Acc", true);
                if (_acc != value)
                {
                    _acc = value;
                    PropertyHasChanged();
                }
            }
        }

        public decimal REAcc
        {
            get
            {
                return (decimal)_acc;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static Ir68aIr68p NewIr68aIr68p(DateTime? sdate, DateTime? edate)
        {
            return Create(sdate, edate);
        }

        public static Ir68aIr68p[] GetAllIr68aIr68p(DateTime? sdate, DateTime? edate)
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
                    cm.CommandText = "odps.od_rps_ir68a_ir68p";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "sdate", sdate);
                    pList.Add(cm, "edate", edate);

                    List<Ir68aIr68p> _list = new List<Ir68aIr68p>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Ir68aIr68p instance = new Ir68aIr68p();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
                            instance._c_initials = GetValueFromReader<string>(dr, 3);
                            instance._gptaxable = GetValueFromReader<decimal?>(dr, 4);
                            instance._gpnontaxable = GetValueFromReader<decimal?>(dr, 5);
                            instance._paye = GetValueFromReader<decimal?>(dr, 6);
                            instance._acc = GetValueFromReader<decimal?>(dr, 7);
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
