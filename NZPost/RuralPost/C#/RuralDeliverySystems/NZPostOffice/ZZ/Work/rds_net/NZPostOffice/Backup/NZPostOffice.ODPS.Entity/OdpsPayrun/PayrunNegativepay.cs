using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsPayrun
{
    // TJB  RPCR_094  Mar-2015 - NEW
    // Based on ODPSRep.NegativePay
    // with contract_pay added

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("c_surname_company", "_c_surname_company", "")]
    [MapInfo("c_first_names", "_c_first_names", "")]
    [MapInfo("c_initials", "_c_initials", "")]
    [MapInfo("gross_pay", "_gross_pay", "")]
    [MapInfo("gst", "_gst", "")]
    [MapInfo("tax", "_tax", "")]
    [MapInfo("post_tax_adjustments", "_post_tax_adjustments", "")]
    [MapInfo("net_pay", "_net_pay", "")]
    [MapInfo("contract_pay", "_contract_pay", "")]
    [System.Serializable()]

    public class PayrunNegativepay : Entity<PayrunNegativepay>
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
        private decimal? _gross_pay;

        [DBField()]
        private decimal? _gst;

        [DBField()]
        private decimal? _tax;

        [DBField()]
        private decimal? _post_tax_adjustments;

        [DBField()]
        private decimal? _net_pay;

        [DBField()]
        private decimal? _contract_pay;

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

        public virtual decimal? GrossPay
        {
            get
            {
                CanReadProperty("GrossPay", true);
                return _gross_pay;
            }
            set
            {
                CanWriteProperty("GrossPay", true);
                if (_gross_pay != value)
                {
                    _gross_pay = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Gst
        {
            get
            {
                CanReadProperty("Gst", true);
                return _gst;
            }
            set
            {
                CanWriteProperty("Gst", true);
                if (_gst != value)
                {
                    _gst = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Tax
        {
            get
            {
                CanReadProperty("Tax", true);
                return _tax;
            }
            set
            {
                CanWriteProperty("Tax", true);
                if (_tax != value)
                {
                    _tax = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? PostTaxAdjustments
        {
            get
            {
                CanReadProperty("PostTaxAdjustments", true);
                return _post_tax_adjustments;
            }
            set
            {
                CanWriteProperty("PostTaxAdjustments", true);
                if (_post_tax_adjustments != value)
                {
                    _post_tax_adjustments = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? NetPay
        {
            get
            {
                CanReadProperty("NetPay", true);
                return _net_pay;
            }
            set
            {
                CanWriteProperty("NetPay", true);
                if (_net_pay != value)
                {
                    _net_pay = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? ContractPay
        {
            get
            {
                CanReadProperty("ContractPay", true);
                return _contract_pay;
            }
            set
            {
                CanWriteProperty("ContractPay", true);
                if (_contract_pay != value)
                {
                    _contract_pay = value;
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
        public static PayrunNegativepay NewPayrunNegativepay()
        {
            return Create();
        }

        public static PayrunNegativepay[] GetAllPayrunNegativepay()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_tnegativepay";
                    ParameterCollection pList = new ParameterCollection();

                    List<PayrunNegativepay> _list = new List<PayrunNegativepay>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PayrunNegativepay instance = new PayrunNegativepay();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
                            instance._c_initials = GetValueFromReader<string>(dr, 3);
                            instance._gross_pay = GetValueFromReader<decimal?>(dr, 4);
                            instance._gst = GetValueFromReader<decimal?>(dr, 5);
                            instance._tax = GetValueFromReader<decimal?>(dr, 6);
                            instance._post_tax_adjustments = GetValueFromReader<decimal?>(dr, 7);
                            instance._net_pay = GetValueFromReader<decimal?>(dr, 8);
                            instance._contract_pay = GetValueFromReader<decimal?>(dr, 9);
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
